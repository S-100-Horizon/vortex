using ArcGIS.Core.Data;
using ArcGIS.Core.Data;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static S100Framework.EventSourcing.EventStore;
using static S100Framework.EventSourcing.Exceptions;

namespace S100Framework.EventSourcing
{
    public readonly record struct ExpectedStreamVersion(long Value)
    {
        public static readonly ExpectedStreamVersion NoStream = new(-1);
        public static readonly ExpectedStreamVersion Any = new(-2);

        public bool ExistingStream => Value >= 0;
    }

    public record struct StreamReadPosition
    {
        public StreamReadPosition(long Value) {
            if (Value < 0) throw new ArgumentOutOfRangeException(nameof(Value), "StreamReadPosition cannot be negative.");
            this.Value = Value;
        }

        public static readonly StreamReadPosition Start = new(0);
        public static readonly StreamReadPosition End = new(long.MaxValue);
        public static implicit operator StreamReadPosition(long value) => new(value);
        public long Value { get; set; }

        public readonly void Deconstruct(out long value) => value = this.Value;
    }

    public sealed class EventStore
    {
        private Geodatabase _geodatabase;
        private Table _messages;

        [StructLayout(LayoutKind.Auto)]
        public record struct StreamEvent(Guid Id, object? Payload, /*Metadata Metadata, */string ContentType, long Position, bool FromArchive = false);

        public record FoldedEventStream<T> where T : State<T>, new()
        {
            public FoldedEventStream(string streamName, ExpectedStreamVersion streamVersion, object[] events) {
                StreamName = streamName;
                StreamVersion = streamVersion;
                Events = events;
                State = events.Aggregate(new T(), (state, o) => state.When(o));
            }

            public string StreamName { get; }
            public ExpectedStreamVersion StreamVersion { get; }
            public object[] Events { get; }
            public T State { get; init; }
        }

        private IDictionary<string, Type> _eventTypes = new Dictionary<string, Type>();

        internal EventStore(Geodatabase geodatabase) {
            _geodatabase = geodatabase ?? throw new ArgumentNullException(nameof(geodatabase));

            var syntax = geodatabase.GetSQLSyntax();

            _messages = _geodatabase.OpenDataset<Table>("messages");

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var attributeTypes = new List<Type>();
            foreach (var assembly in assemblies) {
                var types = assembly.GetTypes();
                attributeTypes.AddRange(types.Where(type => type.IsClass && type.GetCustomAttributes<EventTypeAttribute>().Any()));
            }

            _eventTypes = attributeTypes.ToDictionary(e => e.GetCustomAttribute<EventTypeAttribute>()!.EventType, e => e);
        }

        public async Task<FoldedEventStream<TState>> LoadState<TState>(string streamName, bool failIfNotFound = true, CancellationToken cancellationToken = default) where TState : State<TState>, new() {
            try {
                var streamEvents = await this.ReadStream(streamName, StreamReadPosition.Start, failIfNotFound, cancellationToken).NoContext();
                var events = streamEvents.Select(x => x.Payload!).ToArray();
                var expectedVersion = events.Length == 0 ? ExpectedStreamVersion.NoStream : new(streamEvents.Last().Position);

                return (new(streamName, expectedVersion, events));
            }
            catch (StreamNotFound) when (!failIfNotFound) {
                return new(streamName, ExpectedStreamVersion.NoStream, []);
            }
            catch (Exception e) {
                //_logger.UnableToLoadStream(streamName, e);

                throw;
            }

            return null;
        }

        private async Task<StreamEvent[]> ReadStream(string streamName, StreamReadPosition start, bool failIfNotFound = true, CancellationToken cancellationToken = default) {
            var streamEvents = new List<StreamEvent>();

            try {
                using var cursor = _messages.Search(new QueryFilter {
                    Offset = (int)start.Value,
                    //RowCount = pageSize,
                    WhereClause = $"streamname = '{streamName}'",
                    PostfixClause = "ORDER BY streamName, sequenceid asc"
                }, true);
                while (cursor.MoveNext()) {
                    var messagetype = Convert.ToString(cursor.Current["messagetype"])!;
                    var message = Convert.ToString(cursor.Current["message"])!;

                    var type = _eventTypes[messagetype];

                    var instance = System.Text.Json.JsonSerializer.Deserialize(message, type);

                    streamEvents.Add(new StreamEvent {
                        Payload = instance,
                        ContentType = messagetype,
                        Position = Convert.ToInt64(cursor.Current["sequenceid"]),
                        FromArchive = false,
                    });
                }
            }
            catch (Exceptions.StreamNotFound) when (!failIfNotFound) {
                return [];
            }

            return streamEvents.ToArray();
        }
    }

    public static class ArcGISExtension
    {
        public static EventStore OpenEventStore(this ArcGIS.Core.Data.Geodatabase geodatabase) {
            return new EventStore(geodatabase);
        }
    }

    static class TaskExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ConfiguredTaskAwaitable NoContext(this Task task) => task.ConfigureAwait(false);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ConfiguredTaskAwaitable<T> NoContext<T>(this Task<T> task) => task.ConfigureAwait(false);
    }
}
