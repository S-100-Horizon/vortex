using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.EventSourcing
{
    public abstract record CommandController
    {
        private EventStore _eventStore;

        private readonly Dictionary<Type, Action<object>> _handlers = new Dictionary<Type, Action<object>>();

        protected CommandController(EventStore eventStore) {
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
        }

        protected IIdentityHandler<TCommand> On<TCommand>() where TCommand : class {
            return new CommandHandler<TCommand>(_eventStore);
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

        //protected void On<TCommand>(Action<TCommand> handle) {
        //    Ensure.NotNull(handle, "handle");
        //    if (!_handlers.TryAdd(typeof(TCommand), (object command) => handle((TCommand)command))) {
        //        throw new Exceptions.DuplicateTypeException<TCommand>();
        //    }
        //}
    }

    public interface IIdentityHandler<TCommand> where TCommand : class
    {
        ICommandHandler<TCommand> GetId(Func<TCommand, string> getId);
    }

    public interface ICommandHandler<TCommand> where TCommand : class
    {
        void Commit<TEvent>(TEvent message) where TEvent : class;
        void Commit<TEvent>(TEvent[] message) where TEvent : class;
    }

    public sealed class CommandHandler<TCommand> : IIdentityHandler<TCommand>, ICommandHandler<TCommand> where TCommand : class
    {
        private EventStore _eventStore;

        private Func<TCommand, string>? _getId = default;

        public CommandHandler(EventStore eventStore) {
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
        }

        public ICommandHandler<TCommand> GetId(Func<TCommand, string> getId) {
            _getId = (command) => getId((TCommand)command);
            return this;
        }

        public void Commit<TEvent>(TEvent message) where TEvent : class {
            this.Commit<TEvent>([message]);
        }

        public void Commit<TEvent>(TEvent[] message) where TEvent : class {

        }
    }
}
