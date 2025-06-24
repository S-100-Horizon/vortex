using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.EventSourcing
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EventTypeAttribute : Attribute
    {
        public string EventType { get; }

        public EventTypeAttribute(string eventType) {
            EventType = eventType;
        }
    }

    public abstract record State<T> where T : State<T>
    {
        private readonly Dictionary<Type, Func<T, object, T>> _handlers = new Dictionary<Type, Func<T, object, T>>();

        protected void On<TEvent>(Func<T, TEvent, T> handle) {
            Ensure.NotNull(handle, "handle");
            if (!_handlers.TryAdd(typeof(TEvent), (T state, object evt) => handle(state, (TEvent)evt))) {
                throw new Exceptions.DuplicateTypeException<TEvent>();
            }
        }

        public virtual T When(object @event) {
            var eventType = @event.GetType();

            if (!_handlers.TryGetValue(eventType, out var handler)) return (T)this;

            return handler((T)this, @event);
        }
    }
}

