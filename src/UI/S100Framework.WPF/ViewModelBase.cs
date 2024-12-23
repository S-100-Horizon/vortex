using S100Framework.DomainModel;
using S100Framework.DomainModel.Bindings;
using S100Framework.WPF.Editors;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace S100Framework.WPF.ViewModel
{
    public interface IViewModelHost
    {
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

    public abstract class BindingViewModel : INotifyPropertyChanged
    {
        private Type[] _types;

        public event PropertyChangedEventHandler? PropertyChanged;

        public BindingViewModel(Type[] types) {
            _types = types;
        }

        [Browsable(false)]
        public Type[] Types => _types;

        private string? _refId = default;

        [PropertyOrder(0)]
        [Editor(typeof(RefIdEditor), typeof(RefIdEditor))]
        public string? RefId {
            get { return _refId; }
            set {
                SetValue(ref _refId, value);
            }
        }

        protected void SetValue<T>(ref T backingFiled, T value, [CallerMemberName] string? propertyName = null) {
            if (string.IsNullOrWhiteSpace(propertyName)) return;

            if (EqualityComparer<T>.Default.Equals(backingFiled, value)) return;
            backingFiled = value;
            OnPropertyChanged(propertyName);
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public abstract class InformationBindingViewModel : BindingViewModel
    {
        public InformationBindingViewModel(Type[] types) : base(types) {
            InformationType = base.Types.FirstOrDefault();
        }

        private Type? _informationType = default;

        [PropertyOrder(1)]
        [Editor(typeof(InformationTypeEditor), typeof(InformationTypeEditor))]
        public Type? InformationType {
            get { return _informationType; }
            set {
                base.RefId = default;
                SetValue(ref _informationType, value);
            }
        }
    }

    public abstract class FeatureBindingViewModel : BindingViewModel
    {
        public FeatureBindingViewModel(Type[] types) : base(types) {
            FeatureType = base.Types.FirstOrDefault();
        }

        private Type? _featureType = default;

        [PropertyOrder(1)]
        [Editor(typeof(FeatureTypeEditor), typeof(FeatureTypeEditor))]
        public Type? FeatureType {
            get { return _featureType; }
            set {
                base.RefId = default;
                SetValue(ref _featureType, value);
            }
        }
    }

    public class InformationBindingViewModel<TAssociation, TBinding> : InformationBindingViewModel
        where TAssociation : InformationAssociation, new()
        where TBinding : informationBinding
    {
        public InformationBindingViewModel() : base(TBinding.informationTypes) {
            InformationAssociation = new TAssociation();
        }

        [PropertyOrder(2)]
        [ExpandableObject]
        public TAssociation InformationAssociation { get; set; }
    }

    public class FeatureBindingViewModel<TAssociation, TBinding> : FeatureBindingViewModel
        where TAssociation : FeatureAssociation, new()
        where TBinding : featureBinding
    {
        public FeatureBindingViewModel() : base(TBinding.featureTypes) {
            FeatureAssociation = new TAssociation();
        }

        [PropertyOrder(2)]
        [ExpandableObject]
        public TAssociation FeatureAssociation { get; set; }
    }
}
