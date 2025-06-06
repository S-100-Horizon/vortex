using S100Framework.DomainModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace S100Framework.WPF.ViewModel
{
    public interface iBootstrap
    {
        static AssociationViewModel CreateInformationAssociation(string type, string? name = default) { throw new NotImplementedException(); }

        static AssociationViewModel CreateFeatureAssociation(string type, string? name = default) { throw new NotImplementedException(); }

        static InformationViewModel CreateInformationType(string type, string? name = default) { throw new NotImplementedException(); }

        static FeatureViewModel CreateFeatureType(string type, string? name = default) { throw new NotImplementedException(); }

        static ICollection<string> InformationAssociationBindings(string association, string role) { throw new NotImplementedException(); }

        static ICollection<string> FeatureAssociationBindings(string association, string role) { throw new NotImplementedException(); }
    }

    public interface ISerializable
    {
        //public string Serialize();
    }

    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        [Browsable(false)]
        public Guid? UID { get; set; } = default;

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

    public abstract class AssociationViewModel : ViewModelBase
    {
        [Browsable(false)]
        public string? Name { get; set; } = default;
    }

    public abstract class InformationAssociationViewModel : AssociationViewModel
    {
        public abstract void Load(S100Framework.DomainModel.InformationAssociation informationAssociation);
    }

    public abstract class FeatureAssociationViewModel : AssociationViewModel
    {
        public abstract void Load(S100Framework.DomainModel.FeatureAssociation featureAssociation);
    }

    public abstract class InformationViewModel : ViewModelBase, ISerializable
    {
        [Browsable(false)]
        public string? Name { get; set; } = default;

        [Browsable(false)]
        public abstract informationBindingDefinition[] informationBindingDefinitions { get; }

        public ObservableCollection<InformationBindingViewModel> InformationBindings = [];

        public InformationViewModel() {
            this.InformationBindings.CollectionChanged += this.OnInformationBindings_CollectionChanged;
        }

        protected void OnInformationBindings_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) {
            if (e.OldItems != null) {
                foreach (var i in e.OldItems) {
                    ((InformationBindingViewModel)i).PropertyChanged -= OnInformationBindings_CollectionItemChanged;
                }
            }
            if (e.NewItems != null) {
                foreach (var i in e.NewItems) {
                    ((InformationBindingViewModel)i).PropertyChanged += OnInformationBindings_CollectionItemChanged;
                }
            }
            base.OnPropertyChanged(nameof(InformationBindings));
        }

        protected void OnInformationBindings_CollectionItemChanged(object? sender, PropertyChangedEventArgs e) {
            base.OnPropertyChanged(nameof(InformationBindings));
        }
    }

    public abstract class FeatureViewModel : ViewModelBase, ISerializable
    {
        [Browsable(false)]
        public string? Name { get; set; } = default;

        [Browsable(false)]
        public abstract informationBindingDefinition[] informationBindingDefinitions { get; }

        [Browsable(false)]
        public abstract featureBindingDefinition[] featureBindingDefinitions { get; }

        public ObservableCollection<InformationBindingViewModel> InformationBindings = [];

        public ObservableCollection<FeatureBindingViewModel> FeatureBindings = [];

        public FeatureViewModel() {
            this.InformationBindings.CollectionChanged += this.OnInformationBindings_CollectionChanged;
            this.FeatureBindings.CollectionChanged += this.OnFeatureBindings_CollectionChanged;
        }

        protected void OnInformationBindings_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) {
            if (e.OldItems != null) {
                foreach (var i in e.OldItems) {
                    ((InformationBindingViewModel)i).PropertyChanged -= OnInformationBindings_CollectionItemChanged;
                }
            }
            if (e.NewItems != null) {
                foreach (var i in e.NewItems) {
                    ((InformationBindingViewModel)i).PropertyChanged += OnInformationBindings_CollectionItemChanged;
                }
            }
            base.OnPropertyChanged(nameof(InformationBindings));
        }

        protected void OnInformationBindings_CollectionItemChanged(object? sender, PropertyChangedEventArgs e) {
            base.OnPropertyChanged(nameof(InformationBindings));
        }

        protected void OnFeatureBindings_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) {
            if (e.OldItems != null) {
                foreach (var i in e.OldItems) {
                    ((FeatureBindingViewModel)i).PropertyChanged -= OnFeatureBindings_CollectionItemChanged;
                }
            }
            if (e.NewItems != null) {
                foreach (var i in e.NewItems) {
                    ((FeatureBindingViewModel)i).PropertyChanged += OnFeatureBindings_CollectionItemChanged;
                }
            }
            base.OnPropertyChanged(nameof(FeatureBindings));
        }

        protected void OnFeatureBindings_CollectionItemChanged(object? sender, PropertyChangedEventArgs e) {
            base.OnPropertyChanged(nameof(FeatureBindings));
        }
    }

    public abstract class InformationViewModel<TInformationType> : InformationViewModel where TInformationType : InformationNode
    {
        public abstract InformationViewModel<TInformationType> Load(TInformationType instance);
    }

    public abstract class FeatureViewModel<TFeatureType> : FeatureViewModel where TFeatureType : FeatureNode
    {
        public abstract FeatureViewModel<TFeatureType> Load(TFeatureType instance);
    }

    public class InformationBindingViewModel : INotifyPropertyChanged
    {
        public Guid? UID { get; set; } = default;

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

        public roleType? roleType => string.IsNullOrEmpty(_informationBindingDefintion?.roleType) ? default : Enum.Parse<roleType>(_informationBindingDefintion.roleType);

        public String? association => _informationBindingDefintion?.association;

        public String? role => _informationBindingDefintion?.role;

        private informationBinding? _informationBindingDefintion;

        private String? _associationId = string.Empty;

        public String? associationId {
            get {
                return _associationId;
            }

            set {
                SetValue(ref _associationId, value);
            }
        }

        private String? _informationId = string.Empty;

        public String? informationId {
            get {
                return _informationId;
            }

            set {
                SetValue(ref _informationId, value);
            }
        }

        public InformationBindingViewModel Load(informationBinding binding) {
            _informationBindingDefintion = binding;
            _associationId = binding.associationId;
            _informationId = binding.informationId;
            return this;
        }

        //public abstract InformationAssociation Save(InformationAssociation featureAssociation, string role);
    }

    public class FeatureBindingViewModel : INotifyPropertyChanged
    {
        public Guid? UID { get; set; } = default;

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

        public roleType? roleType => string.IsNullOrEmpty(_featureBindingDefintion?.roleType) ? default : Enum.Parse<roleType>(_featureBindingDefintion.roleType);

        public String? association => _featureBindingDefintion?.association;

        public String? role => _featureBindingDefintion?.role;

        private featureBinding? _featureBindingDefintion;

        private String? _associationId = string.Empty;

        public String? associationId {
            get {
                return _associationId;
            }

            set {
                SetValue(ref _associationId, value);
            }
        }

        private String? _featureId = string.Empty;

        public String? featureId {
            get {
                return _featureId;
            }

            set {
                SetValue(ref _featureId, value);
            }
        }

        public FeatureBindingViewModel Load(featureBinding binding) {
            _featureBindingDefintion = binding;
            _associationId = binding.associationId;
            _featureId = binding.featureId;
            return this;
        }

        //public abstract FeatureAssociation Save(FeatureAssociation featureAssociation, string role);
    }
}
