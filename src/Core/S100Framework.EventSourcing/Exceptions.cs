using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.EventSourcing
{
    public abstract class EventStoreException : Exception
    {
        protected EventStoreException(string message, Exception inner) : base(message, inner) { }

        protected EventStoreException(string message) : base(message) { }
    }

    public static class Exceptions
    {
        public class DuplicateTypeException<T> : ArgumentException
        {
            public DuplicateTypeException()
                : base(ExceptionMessages.DuplicateTypeKey<T>(), typeof(T).FullName) {
            }
        }

        public class StreamNotFound(string stream) : EventStoreException($"Stream {stream} does not exist");
    }

    static class ExceptionMessages
    {
        static readonly ResourceManager Resources = new("S100Framework.EventSourcing.ExceptionMessages", Assembly.GetExecutingAssembly());

        internal static string MissingCommandHandler(Type type) => string.Format(Resources.GetString("MissingCommandHandler")!, type.Name);

        internal static string DuplicateTypeKey<T>() => string.Format(Resources.GetString("DuplicateTypeKey")!, typeof(T).Name);

        internal static string DuplicateCommandHandler<T>() => string.Format(Resources.GetString("DuplicateCommandHandler")!, typeof(T).Name);

        internal static string MissingCommandMap<TIn, TOut>() => string.Format(Resources.GetString("MissingCommandMap")!, typeof(TIn).Name, typeof(TOut).Name);
    }
}
