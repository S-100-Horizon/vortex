using S100Framework.DomainModel.Bindings;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace S100Framework.WPF.ViewModel
{
    public interface IViewModelHost {
        public object GetSource(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem);
    }

    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        private IViewModelHost? _host;

        public IViewModelHost? Host => _host;

        public ViewModelBase(IViewModelHost? host = null) {
            _host = host;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected Dictionary<ViewModelBase, string> nestedProperties = new Dictionary<ViewModelBase, string>();

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingFiled, T value, [CallerMemberName] string? propertyName = null) {
            if (string.IsNullOrWhiteSpace(propertyName)) return;

            if (EqualityComparer<T>.Default.Equals(backingFiled, value)) return;
            if (backingFiled is ViewModelBase viewModel) {   // if old value is ViewModel, than we assume that it was subscribed, so - unsubscribe it
                viewModel.PropertyChanged -= ChildViewModelChanged;
                nestedProperties.Remove(viewModel);
            }
            if (value is ViewModelBase valueViewModel) {
                // if new value is ViewModel, than we must subscribe it on PropertyChanged and add it into subscribe dictionary
                valueViewModel.PropertyChanged += ChildViewModelChanged;
                nestedProperties.Add(valueViewModel, propertyName);
            }
            backingFiled = value;
            OnPropertyChanged(propertyName);
        }

        private void ChildViewModelChanged(object? sender, PropertyChangedEventArgs e) {
            if (string.IsNullOrEmpty(e.PropertyName)) return;

            // this is child property name, need to get parent property name from dictionary
            string propertyName = e.PropertyName;
            if (sender is ViewModelBase viewModel) {
                propertyName = nestedProperties[viewModel];
            }
            // Rise parent PropertyChanged with parent property name
            OnPropertyChanged(propertyName);
        }

        public abstract string Serialize();

        public void Dispose() {   // need to make sure that we unsubscibed
            foreach (ViewModelBase viewModel in nestedProperties.Keys) {
                viewModel.PropertyChanged -= ChildViewModelChanged;
                viewModel.Dispose();
            }
        }
    }

    public abstract class ViewModelBase<T> : ViewModelBase
    {
        public abstract void Load(T instance);
    }

    public class informationBindingViewModel : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingFiled, T value, [CallerMemberName] string? propertyName = null) {
            if (string.IsNullOrWhiteSpace(propertyName)) return;

            if (EqualityComparer<T>.Default.Equals(backingFiled, value)) return;            
            backingFiled = value;
            OnPropertyChanged(propertyName);
        }

        private string? _linkId;

        //[Editor(typeof(Editors.BindingConnectorEditor), typeof(Editors.BindingConnectorEditor))]
        public string? LinkId {
            get {
                return _linkId;
            }

            set {
                SetValue(ref _linkId, value);
            }
        }

        private informationBinding? _informationBinding;

        //[Editor(typeof(Editors.BindingConnectorEditor), typeof(Editors.BindingConnectorEditor))]
        public informationBinding? informationBinding {
            get {
                return _informationBinding;
            }

            set {
                SetValue(ref _informationBinding, value);
            }
        }

        public string Name => $"{_linkId} {informationBinding?.informationType}";
    }

    public class informationBindingViewModel<T> : informationBindingViewModel where T : new()
    {
        public informationBindingViewModel() {
            _value = new T();
        }

        private T _value;

        public T Value {
            get { return _value; }
            set {
                SetValue(ref _value, value);
            }
        }
    }

    public class FeatureBindingConnector : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingFiled, T value, [CallerMemberName] string? propertyName = null) {
            if (string.IsNullOrWhiteSpace(propertyName)) return;

            if (EqualityComparer<T>.Default.Equals(backingFiled, value)) return;
            backingFiled = value;
            OnPropertyChanged(propertyName);
        }

        private string? _linkId;

        //[Editor(typeof(Editors.BindingConnectorEditor), typeof(Editors.BindingConnectorEditor))]
        public string? LinkId {
            get {
                return _linkId;
            }

            set {
                SetValue(ref _linkId, value);
            }
        }

        private informationBinding? _informationBinding;

        //[Editor(typeof(Editors.BindingConnectorEditor), typeof(Editors.BindingConnectorEditor))]
        public informationBinding? informationBinding {
            get {
                return _informationBinding;
            }

            set {
                SetValue(ref _informationBinding, value);
            }
        }
    }

}
