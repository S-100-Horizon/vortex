using S100Framework.DomainModel;
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

        [Browsable(false)]
        public IViewModelHost? Host => _host;

        public ViewModelBase(IViewModelHost? host = null) {
            _host = host;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected Dictionary<ViewModelBase, string> nestedProperties = new();

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
    }

    public abstract class InformationBindingViewModel : BindingViewModel
    {
        private InformationTypeAttribute[] _informationTypes;

        [Browsable(false)]
        public InformationTypeAttribute[] informationTypes => _informationTypes;

        public InformationBindingViewModel(IEnumerable<InformationTypeAttribute> informationTypes) {
            _informationTypes = informationTypes.ToArray();
        }
    }

    public class InformationBindingViewModel<TAssociation> : InformationBindingViewModel where TAssociation : InformationAssociation, new()
    {
        public InformationBindingViewModel(IEnumerable<InformationTypeAttribute> informationTypes) : base(informationTypes) {
        }

        public override string ToString() => typeof(TAssociation).Name;

        private string? _refId;

        [PropertyOrder(20)]
        public string? RefId {
            get { return _refId; }
            set { this.SetValue(ref _refId, value); }
        }

        private string? _informationType;

        [PropertyOrder(10)]
        [Editor(typeof(InformationTypeEditor), typeof(InformationTypeEditor))]
        public string? informationType {
            get { return _informationType; }
            set {
                this.SetValue(ref _informationType, value);
                this.RefId = default;
            }
        }

        private TAssociation _association = new();

        [PropertyOrder(30)]
        [ExpandableObject]
        //[Editor(typeof(AssociationEditor), typeof(AssociationEditor))]
        public TAssociation association {
            get { return _association; }
            set { this.SetValue(ref _association, value); }
        }
    }


    public abstract class FeatureBindingViewModel : BindingViewModel
    {
        private FeatureTypeAttribute[] _featureTypes;

        [Browsable(false)]
        public FeatureTypeAttribute[] featureTypes => _featureTypes;

        public FeatureBindingViewModel(IEnumerable<FeatureTypeAttribute> featureTypes) {
            _featureTypes = featureTypes.ToArray();
        }
    }

    public class FeatureBindingViewModel<TAssociation> : FeatureBindingViewModel where TAssociation : FeatureAssociation, new()
    {
        public FeatureBindingViewModel(IEnumerable<FeatureTypeAttribute> featureTypes) : base(featureTypes) {
        }

        public override string ToString() => typeof(TAssociation).Name;

        private string? _refId;

        [PropertyOrder(20)]
        public string? RefId {
            get { return _refId; }
            set { this.SetValue(ref _refId, value); }
        }

        private string? _featureType;

        [PropertyOrder(10)]
        [Editor(typeof(FeatureTypeEditor), typeof(FeatureTypeEditor))]
        public string? featureType {
            get { return _featureType; }
            set {
                this.SetValue(ref _featureType, value);
                this.RefId = default;
            }
        }

        private TAssociation _association = new();

        [PropertyOrder(30)]
        [ExpandableObject]
        //[Editor(typeof(AssociationEditor), typeof(AssociationEditor))]
        public TAssociation association {
            get { return _association; }
            set { this.SetValue(ref _association, value); }
        }
    }









    public abstract class FeatureAssociationViewModel : INotifyPropertyChanged {
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

        [PropertyOrder(0)]
        public abstract string Code { get; }

        [Browsable(false)]
        public abstract string[] Roles { get; }

        [Browsable(false)]
        public abstract AssociationConnector[] associationConnectors { get; }
    }

    public abstract class AssociationConnector
    {
        public DomainModel.Bindings.roleType roleType { get; set; }

        public string role { get; set; } = string.Empty;

        [Browsable(false)]
        public Type[] AssociationTypes { get; set; } = [];

        [PropertyOrder(1)]
        public int Lower { get; set; } = 0;

        [PropertyOrder(2)]
        public int? Upper { get; set; } = default;

        public abstract Type FeatureType { get; }
    }

    public class AssociationConnector<T> : AssociationConnector where T : FeatureTypeBase
    {
        public override Type FeatureType => typeof(T);

        public string DisplayName => $"{typeof(T).Name}, {base.role}";
    }

    public abstract class FeatureBinding
    {
        [Browsable(false)]
        public Type[] FeatureTypes { get; set; } = [];
    }

    public class FeatureBindingSingle : FeatureBinding
    {
        public string RefId { get; set; } = string.Empty;
    }

    public class FeatureBindingOptional : FeatureBinding
    {
        public string? RefId { get; set; } = default;
    }

    public class FeatureBindingMulti : FeatureBinding
    {
        public List<string> RefIds { get; set; } = new List<string>();
    }
}
