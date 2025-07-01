using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.EventSourcing
{
    public interface IHandlers {
        void RegisterHandle<TCommand>(Func<TCommand,(string streamname, object[] events)> commandHandler) where TCommand : class;
    }

    public abstract record CommandController : IHandlers
    {
        private EventStore _eventStore;

        private readonly Dictionary<Type, Action<object>> _handlers = new Dictionary<Type, Action<object>>();

        protected CommandController(EventStore eventStore) {
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
        }

        protected IIdentityHandler<TCommand> On<TCommand>() where TCommand : class {
            return new CommandHandler<TCommand>(this);
        }

        public void Handle<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : class {
            if (!_handlers.TryGetValue(command.GetType(), out var registeredHandler)) {
                //Log.CommandHandlerNotFound<TCommand>();
                //var exception = new Exceptions.CommandHandlerNotFound(command.GetType());

                //return Result<TState>.FromError(exception);
                return;
            }
            registeredHandler(command);
        }

        public void RegisterHandle<TCommand>(Func<TCommand, (string streamname, object[] events)> commandHandler) where TCommand : class {
            _handlers.Add(typeof(TCommand), async (cmd) => {
                TCommand command = (TCommand)cmd;
                var result = commandHandler(command);

                await _eventStore.WriteStream<object>(result.streamname, result.events, false);
            });            
        }
    }

    public interface IIdentityHandler<TCommand> where TCommand : class
    {
        ICommandHandler<TCommand> GetId(Func<TCommand, string> getId);
    }

    public interface ICommandHandler<TCommand> where TCommand : class
    {
        void Action(Action<TCommand, IPublisherHandler> getMessage);
    }

    public interface IPublisherHandler {
        void Publish<TEvent>(Func<TEvent> message) where TEvent : class;
    }

    public sealed class CommandHandler<TCommand> : IIdentityHandler<TCommand>, ICommandHandler<TCommand>, IPublisherHandler where TCommand : class
    {
        class PublisherHandler : IPublisherHandler
        {
            private object[] _events = [];

            public void Publish<TEvent>(Func<TEvent> message) where TEvent : class {
                _events = [.. _events, message()];
            }

            public object[] Events => _events;
        }

        private IHandlers _handler;

        private Func<TCommand, string>? _getId = default;


        public CommandHandler(IHandlers handler) {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        public ICommandHandler<TCommand> GetId(Func<TCommand, string> getId) {
            _getId = (command) => getId(command);
            return this;
        }

        public void Action(Action<TCommand, IPublisherHandler> getMessage) {
            Func<TCommand, (string streamname, object[] events)> func = (cmd) => {
                var publisher = new PublisherHandler();

                var streamid = _getId!(cmd);
                getMessage(cmd, publisher);

                return (streamid, publisher.Events);
            };
            _handler.RegisterHandle(func);
        }

        public void Publish<TEvent>(Func<TEvent> message) where TEvent : class {
            throw new NotImplementedException();
        }




        //public void Commit<TEvent>(Func<TCommand, TEvent> getMessage) where TEvent : class {          
        //    Func<TCommand, (string streamname, object[] events)> func = (cmd) => {
        //        var streamid = _getId!(cmd);
        //        var events = getMessage(cmd);

        //        return (streamid,[events]);
        //    };
        //    _handler.RegisterHandle(func);
        //}

        //public void Commit<TEvent>(Func<TCommand, TEvent[]> getMessage) where TEvent : class {
        //    Func<TCommand, (string streamname, object[] events)> func = (cmd) => {
        //        var streamid = _getId!(cmd);
        //        var events = getMessage(cmd);

        //        return (streamid, events);
        //    };
        //    _handler.RegisterHandle(func);
        //}
    }
}
