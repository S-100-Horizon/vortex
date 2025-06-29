using S100Framework.DomainModel;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;
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

    public abstract class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo, IDisposable
    {
        public ViewModelBase() {
            this.PropertyChanged += (sender, e) => {
                if (string.IsNullOrEmpty(e.PropertyName)) return;
                if (e.PropertyName == nameof(HasErrors)) return; // Prevent recursive validation call

                Validate();
            };
        }

        [Browsable(false)]
        public Guid? UID { get; set; } = default;

        public abstract string Serialize();

        protected virtual void Validate() {
            this._errors.Clear(); // Clear previous errors

            var context = new NullabilityInfoContext();

            bool IsNuallable(PropertyInfo property) {
                var info = context.Create(property);
                return info.ReadState == NullabilityState.Nullable;
            }

            var t = this.GetType().GetProperties()
                .Where(p => p.GetCustomAttribute<BrowsableAttribute>() == null && !IsNuallable(p))
                .ToList();

            this.GetType().GetProperties()
                .Where(p => p.GetCustomAttribute<BrowsableAttribute>() == null && !IsNuallable(p))
                .ToList()
                .ForEach(p => {
                    var value = p.GetValue(this);
                    if (value == null || (value is string str && string.IsNullOrWhiteSpace(str))) {
                        this.AddError(p.Name, $"{p.Name} is required.");
                    }
                });
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Dictionary<ViewModelBase, string> nestedProperties = new();

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

        #endregion


        #region INotifyDataErrorInfo

        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        [Browsable(false)]
        public bool HasErrors => _errors.Any();

        public IEnumerable GetErrors(string? propertyName) {
            if (string.IsNullOrEmpty(propertyName)) return Enumerable.Empty<string>();

            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : Enumerable.Empty<string>();
        }

        protected void OnErrorsChanged(string propertyName) {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void AddError(string propertyName, string error) {
            if (!_errors.ContainsKey(propertyName)) {
                _errors[propertyName] = new List<string>();
            }

            if (!_errors[propertyName].Contains(error)) {
                _errors[propertyName].Add(error);
                OnErrorsChanged(propertyName);
                OnPropertyChanged(nameof(HasErrors));
            }
        }

        protected void ClearErrors(string propertyName) {
            if (_errors.ContainsKey(propertyName)) {
                _errors.Remove(propertyName);
                OnErrorsChanged(propertyName);
                OnPropertyChanged(nameof(HasErrors));
            }
        }

        #endregion


        #region IDisposable

        public void Dispose() {   // need to make sure that we unsubscibed
            foreach (ViewModelBase viewModel in nestedProperties.Keys) {
                viewModel.PropertyChanged -= ChildViewModelChanged;
                viewModel.Dispose();
            }
        }

        #endregion
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
        public abstract informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive);

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
