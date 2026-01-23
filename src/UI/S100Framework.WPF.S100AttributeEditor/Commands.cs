using System.Windows.Input;

namespace S100Framework.WPF
{
    public class RelayCommand(Action<object?> action) : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly Action<object?> _action = action;

        public bool CanExecute(object? parameter) {
            return this._action != null;
        }

        public void Execute(object? parameter) {
            this._action?.Invoke(parameter);
        }
    }

}
