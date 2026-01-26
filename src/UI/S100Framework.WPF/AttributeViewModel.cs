using S100FC;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace S100Framework.WPF.ViewModel
{
    public class InformationTypeID(string informationType, string UID)
    {
        public string UID { get; set; } = UID;
        public string InformationType { get; set; } = informationType;

        public override string ToString() => $"{InformationType}:{UID}";
    }

    public class FeatureTypeID(string featureType, string UID)
    {
        public string UID { get; set; } = UID;
        public string FeatureType { get; set; } = featureType;

        public override string ToString() => $"{FeatureType}:{UID}";
    }

    public abstract class AttributeViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged = default;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private readonly Dictionary<AttributeViewModel, string> nestedProperties = [];

        protected void SetProperty<T>(ref T backingFiled, T value, [CallerMemberName] string? propertyName = null) {
            System.Diagnostics.Debug.WriteLine($"SetProperty({propertyName})");
            if (string.IsNullOrWhiteSpace(propertyName)) return;

            //if (EqualityComparer<T>.Default.Equals(backingFiled, value)) return;
            //if (backingFiled is AttributeViewModel viewModel) {   // if old value is ViewModel, than we assume that it was subscribed, so - unsubscribe it
            //    viewModel.PropertyChanged -= ChildViewModelChanged;
            //    nestedProperties.Remove(viewModel);
            //}
            //if (value is AttributeViewModel valueViewModel) {
            //    // if new value is ViewModel, than we must subscribe it on PropertyChanged and add it into subscribe dictionary
            //    valueViewModel.PropertyChanged += ChildViewModelChanged;
            //    nestedProperties.Add(valueViewModel, propertyName);
            //}
            backingFiled = value;
            this.OnPropertyChanged(this.code);
        }

        private void ChildViewModelChanged(object? sender, PropertyChangedEventArgs e) {
            if (string.IsNullOrEmpty(e.PropertyName)) return;

            // this is child property name, need to get parent property name from dictionary
            string propertyName = e.PropertyName;
            if (sender is AttributeViewModel viewModel) {
                propertyName = this.nestedProperties[viewModel];
            }
            // Rise parent PropertyChanged with parent property name
            this.OnPropertyChanged(propertyName);
        }

        #endregion

        #region Properties        

        public string code { get; init; } = "UNKNOWN";

        #endregion

        public AttributeViewModel(S100FC.attributeBinding attribute) {
            this.code = attribute.S100FC_code;
        }
    }

    public class SimpleAttributeViewModel : AttributeViewModel
    {
        public SimpleAttributeViewModel(SimpleAttribute attribute) : base(attribute) {
            this._attribute = attribute;

            this.value = attribute.GetType().GetProperty("value")!.GetValue(attribute);
        }

        public string valueType => this._attribute!.valueType;

        private object? _value;

        public object? value {
            get {
                return this._value;
            }
            set {
                this.SetProperty(ref this._value, value);
            }
        }

        public S100FC.SimpleAttribute? _attribute { get; init; } = default;
    }

    public class ComplexAttributeViewModel : AttributeViewModel
    {
        public attributeBindingDefinition[] attributeBindingsCatalogue { get; init; } = [];

        public ObservableCollection<AttributeViewModel> attributeBindings { get; set; } = [];

        public ComplexAttributeViewModel(ComplexAttribute attribute) : base(attribute) {
            this._attribute = attribute;

            this.attributeBindingsCatalogue = this._attribute.attributeBindingsCatalogue;

            this.attributeBindings.CollectionChanged += (s, e) => {
                if (e.NewItems is not null) {
                    foreach (var item in e.NewItems) {
                        if (item is SimpleAttributeViewModel simpleAttribute) {
                            simpleAttribute.PropertyChanged += this.Viewmodel_PropertyChanged;
                        }
                        else if (item is ComplexAttributeViewModel complexAttribute) {
                            complexAttribute.PropertyChanged += this.Viewmodel_PropertyChanged;
                        }
                    }
                }
            };

            foreach (var e in attribute.attributeBindings.OrderBy(e => this.attributeBindingsCatalogue.Single(a => a.attribute.Equals(e.S100FC_code)).order)) {
                if (e is SimpleAttribute simpleAttribute) {
                    var viewmodel = new SimpleAttributeViewModel(simpleAttribute);
                    this.attributeBindings.Add(viewmodel);
                }
                else if (e is ComplexAttribute complexAttribute) {
                    var viewmodel = new ComplexAttributeViewModel(complexAttribute);
                    this.attributeBindings.Add(viewmodel);
                }
            }
        }

        public bool HasCapacity(attributeBindingDefinition binding) {
            var count = this.attributeBindings.Count(e => e.code.Equals(binding.attribute));
            return binding.upper > count;
        }

        private void Viewmodel_PropertyChanged(object? sender, PropertyChangedEventArgs e) {
            //if(sender is S100FC.SimpleAttribute simpleAttribute)
            //    base.OnPropertyChanged(simpleAttribute.S100FC_code);
            //else
            base.OnPropertyChanged(e.PropertyName);
        }

        private readonly S100FC.ComplexAttribute? _attribute = default;
    }

    public class InformationBindingViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged = default;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetProperty<T>(ref T backingField, T newValue, [System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null) {
            if (EqualityComparer<T>.Default.Equals(backingField, newValue))
                return false;

            backingField = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion

        public string association { get; init; }

        public InformationBindingViewModel(IGrouping<string, informationBindingDefinition> informationBinding) {
            this._informationBindingDefinitions = [.. informationBinding];

            this.association = informationBinding.Key;


            foreach (var e in this._informationBindingDefinitions) {
                this.roles.Add(e.role);
            }            

            this.PropertyChanged += (s, e) => {
                if (string.IsNullOrEmpty(e.PropertyName)) {
                    this.role = null;
                    this.roleType = null;
                    this.informationTypes.Clear();
                    this.informationType = null;
                    this.informationUIDs.Clear();
                    this.informationUID = null;
                }
                else if (e.PropertyName.Equals(nameof(role))) {
                    var featureBinding = this._informationBindingDefinitions.Single(e => e.role.Equals(this.role));
                    this.roleType = featureBinding.roleType;

                    this.informationType = null;
                    this.informationTypes.Clear();
                    foreach (var featureType in featureBinding.informationTypes) {
                        this.informationTypes.Add(featureType);
                    }

                    this.informationUID = null;
                    this.informationUIDs.Clear();
                }
                else if (e.PropertyName.Equals(nameof(informationType))) {
                }
            };

            this.role = this.roles[0];
        }

        private string? _roleType;
        public string? roleType {
            get => this._roleType;
            set {
                this.SetProperty(ref this._roleType, value);
            }
        }

        public ObservableCollection<string> roles { get; init; } = [];

        public ObservableCollection<string> informationTypes { get; init; } = [];

        public ObservableCollection<InformationTypeID> informationUIDs { get; init; } = [];

        private string? _role;
        public string? role {
            get => this._role;
            set {
                this.SetProperty(ref this._role, value);
            }
        }

        private string? _informationType;

        public string? informationType {
            get => this._informationType;
            set {
                this.SetProperty(ref this._informationType, value);
            }
        }

        private InformationTypeID? _informationUID;

        public InformationTypeID? informationUID {
            get => this._informationUID;
            set {
                this.SetProperty(ref this._informationUID, value);
            }
        }

        private informationBindingDefinition[] _informationBindingDefinitions;
    }

    public class FeatureBindingViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged = default;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetProperty<T>(ref T backingField, T newValue, [System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null) {
            if (EqualityComparer<T>.Default.Equals(backingField, newValue))
                return false;

            backingField = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion

        public string association { get; init; }

        public FeatureBindingViewModel(IGrouping<string, featureBindingDefinition> featureBindings) {
            this._featureBindingDefinitions = [.. featureBindings];

            this.association = featureBindings.Key;

            foreach (var e in this._featureBindingDefinitions) {
                this.roles.Add(e.role);
            }

            this.PropertyChanged += (s, e) => {
                if (string.IsNullOrEmpty(e.PropertyName)) {
                    this.role = null;
                    this.roleType = null;
                    this.featureTypes.Clear();
                    this.featureType = null;
                    this.featureUIDs.Clear();
                    this.featureUID = null;
                }
                else if (e.PropertyName.Equals(nameof(role))) {
                    var featureBinding = this._featureBindingDefinitions.Single(e => e.role.Equals(this.role));
                    this.roleType = featureBinding.roleType;

                    this.featureType = null;
                    this.featureTypes.Clear();
                    foreach (var featureType in featureBinding.featureTypes) {
                        this.featureTypes.Add(featureType);
                    }

                    this.featureUID = null;
                    this.featureUIDs.Clear();
                }
                else if (e.PropertyName.Equals(nameof(featureType))) {                    
                }
            };                
        }

        private string? _roleType;
        public string? roleType {
            get => this._roleType;
            set {
                this.SetProperty(ref this._roleType, value);
            }
        }

        public ObservableCollection<string> roles { get; init; } = [];

        public ObservableCollection<string> featureTypes { get; init; } = [];

        public ObservableCollection<FeatureTypeID> featureUIDs { get; init; } = [];

        private string? _role;
        public string? role {
            get => this._role;
            set {
                this.SetProperty(ref this._role, value);
            }
        }

        private string? _featureType;

        public string? featureType {
            get => this._featureType;
            set {
                this.SetProperty(ref this._featureType, value);
            }
        }

        private FeatureTypeID? _featureUID;

        public FeatureTypeID? featureUID {
            get => this._featureUID;
            set {
                this.SetProperty(ref this._featureUID, value);
            }
        }

        private featureBindingDefinition[] _featureBindingDefinitions;
    }
}
