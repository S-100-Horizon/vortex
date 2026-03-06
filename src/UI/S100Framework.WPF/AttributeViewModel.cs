using Newtonsoft.Json.Linq;
using S100FC;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace S100Framework.WPF.ViewModel
{
    public interface IAttributeBindingContainer
    {
        bool HasCapacity(attributeBindingDefinition binding);
        bool HasCapacity(IGrouping<string, informationBindingDefinition> binding);
        bool HasCapacity(IGrouping<string, featureBindingDefinition> binding);

        void AddAttribute(AttributeViewModel attribute);
    }

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
            this.attribute = attribute;
            this.code = this.attribute.S100FC_code;
        }

        public S100FC.attributeBinding attribute { get; protected set; }
    }

    public class SimpleAttributeViewModel : AttributeViewModel, INotifyDataErrorInfo
    {
        public SimpleAttributeViewModel(ref SimpleAttribute attribute, attributeBindingDefinition attributeBindingDefinition) : base(attribute) {
            this._attribute = attribute;
            this._attributeBindingDefinition = attributeBindingDefinition;

            var type = attribute.GetType();
            this.value = type.GetProperty("value")!.GetValue(attribute);

            var attributes = type.GetCustomAttributes(true);

            this._validators = [];

            var stringLengthConstraintAttribute = attributes.SingleOrDefault(e => e is StringLengthConstraintAttribute) as StringLengthConstraintAttribute;
            if (stringLengthConstraintAttribute is not null) {
                this._validators = [.. this._validators, () => {
                    if(this._value is String text){
                        if(text.Length>stringLengthConstraintAttribute.StringLength)
                            this._errors = $"StringLengthConstraint: {stringLengthConstraintAttribute.StringLength}!";
                    }
                }];
            }

            var precisionConstraintAttribute = attributes.SingleOrDefault(e => e is PrecisionConstraintAttribute) as PrecisionConstraintAttribute;
            if (precisionConstraintAttribute is not null) {
                this._validators = [.. this._validators, () => {
                    if(this._value is double _double){
                        var rounded = Math.Round(_double, precisionConstraintAttribute.Precision);
                        if(rounded!=_double)
                            this._errors = $"PrecisionConstraint: {precisionConstraintAttribute.Precision}!";
                    }
                    if(this._value is decimal _decimal){
                        var rounded = Math.Round(_decimal, precisionConstraintAttribute.Precision);
                        if(rounded!=_decimal)
                            this._errors = $"PrecisionConstraint: {precisionConstraintAttribute.Precision}!";
                    }
                }];
            }

            var textPatternConstraint = attributes.SingleOrDefault(e => e is TextPatternConstraint) as TextPatternConstraint;
            if (textPatternConstraint is not null) {
                this._validators = [.. this._validators, () => {
                    if(this._value is String text){
                        if(!textPatternConstraint.Regex.IsMatch(text)){
                            this._errors = $"TextPatternConstraint: {textPatternConstraint.TextPattern}!";
                        }
                    }
                }];
            }

            var rangeConstraintAttribute = attributes.SingleOrDefault(e => e is RangeConstraintAttribute) as RangeConstraintAttribute;
            if (rangeConstraintAttribute is not null) {
                if (rangeConstraintAttribute is RangeConstraintRealAttribute rangeConstraintRealAttribute) {
                    this._validators = [.. this._validators, () => {
                        var _double = Convert.ToDouble(this._value);
                        var error = rangeConstraintRealAttribute.Closure switch{
                            Closure.openInterval => !(_double>rangeConstraintRealAttribute.LowerBound && _double<rangeConstraintRealAttribute.UpperBound),
                            Closure.geLtInterval => !(_double>=rangeConstraintRealAttribute.LowerBound && _double<rangeConstraintRealAttribute.UpperBound),
                            Closure.gtLeInterval => !(_double>rangeConstraintRealAttribute.LowerBound && _double<=rangeConstraintRealAttribute.UpperBound),
                            Closure.closedInterval => !(_double>=rangeConstraintRealAttribute.LowerBound && _double<=rangeConstraintRealAttribute.UpperBound),
                            //Closure.gtSemiInterval => 
                            //Closure.geSemiInterval =>
                            //Closure.ltSemiInterval =>
                            //Closure.leSemiInterval =>
                            _ => throw new NotImplementedException(),
                        };
                        if(error)
                            this._errors = $"RangeConstraint: {rangeConstraintAttribute.Closure}, {rangeConstraintRealAttribute.LowerBound}, {rangeConstraintRealAttribute.UpperBound}!";
                    }];
                }
                if (rangeConstraintAttribute is RangeConstraintIntegerAttribute rangeConstraintIntegerAttribute) {
                    this._validators = [.. this._validators, () => {
                    var _integer = Convert.ToInt32(this._value);
                    var error = rangeConstraintIntegerAttribute.Closure switch{
                        Closure.openInterval => !(_integer>rangeConstraintIntegerAttribute.LowerBound && _integer<rangeConstraintIntegerAttribute.UpperBound),
                        Closure.geLtInterval => !(_integer>=rangeConstraintIntegerAttribute.LowerBound && _integer<rangeConstraintIntegerAttribute.UpperBound),
                        Closure.gtLeInterval => !(_integer>rangeConstraintIntegerAttribute.LowerBound && _integer<=rangeConstraintIntegerAttribute.UpperBound),
                        Closure.closedInterval => !(_integer>=rangeConstraintIntegerAttribute.LowerBound && _integer<=rangeConstraintIntegerAttribute.UpperBound),
                        //Closure.gtSemiInterval => 
                        //Closure.geSemiInterval =>
                        //Closure.ltSemiInterval =>
                        //Closure.leSemiInterval =>
                        _ => throw new NotImplementedException(),
                    };
                    if(error)
                        this._errors = $"RangeConstraint: {rangeConstraintAttribute.Closure}, {rangeConstraintIntegerAttribute.LowerBound}, {rangeConstraintIntegerAttribute.UpperBound}!";
                }];
                }
            }
        }

        public string valueType => this._attribute!.valueType;

        private object? _value;

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public object? value {
            get {
                return this._value;
            }
            set {
                attribute.GetType().GetProperty("value")!.SetValue(_attribute, value);
                this.SetProperty(ref this._value, value);

                this.Validate();
            }
        }

        public S100FC.SimpleAttribute? _attribute { get; init; } = default;

        public int[]? permitedValues => this._attributeBindingDefinition?.permitedValues;

        private S100FC.attributeBindingDefinition? _attributeBindingDefinition { get; init; } = default;

        public bool HasErrors => !string.IsNullOrEmpty(this._errors);

        public IEnumerable GetErrors(string? propertyName) {
            if (!nameof(value).Equals(propertyName)) return Enumerable.Empty<string>();
            return new string?[] { this._errors };
        }

        private void Validate() {
            this._errors = string.Empty;
            foreach (var action in this._validators)
                action.Invoke();
        }

        private Action[] _validators = [];

        private string? _errors = string.Empty;
    }

    public class DateAttributeViewModel : AttributeViewModel
    {
        public DateAttributeViewModel(ref DateAttribute attribute, attributeBindingDefinition attributeBindingDefinition) : base(attribute) {
            this._attribute = attribute;
            this._attributeBindingDefinition = attributeBindingDefinition;

            this.value = (DateTime?)attribute.GetType().GetProperty("value")!.GetValue(attribute);
        }

        public string valueType => this._attribute!.valueType;

        private DateTime? _value;

        public DateTime? value {
            get {
                return this._value;
            }
            set {
                if (value != null) {
                    var date = DateOnly.FromDateTime(value.Value);
                    attribute.GetType().GetProperty("value")!.SetValue(_attribute, date);
                }
                else
                    attribute.GetType().GetProperty("value")!.SetValue(_attribute, default);
                this.SetProperty(ref this._value, value);
            }
        }

        public S100FC.DateAttribute? _attribute { get; init; } = default;

        private S100FC.attributeBindingDefinition? _attributeBindingDefinition { get; init; } = default;
    }

    public class DateTimeAttributeViewModel : AttributeViewModel
    {
        public DateTimeAttributeViewModel(ref DateTimeAttribute attribute, attributeBindingDefinition attributeBindingDefinition) : base(attribute) {
            this._attribute = attribute;
            this._attributeBindingDefinition = attributeBindingDefinition;

            this.value = (DateTime?)attribute.GetType().GetProperty("value")!.GetValue(attribute);
        }

        public string valueType => this._attribute!.valueType;

        private DateTime? _value;

        public DateTime? value {
            get {
                return this._value;
            }
            set {
                attribute.GetType().GetProperty("value")!.SetValue(_attribute, value);
                this.SetProperty(ref this._value, value);
            }
        }

        public S100FC.DateTimeAttribute? _attribute { get; init; } = default;

        private S100FC.attributeBindingDefinition? _attributeBindingDefinition { get; init; } = default;
    }

    public class ComplexAttributeViewModel : AttributeViewModel, IAttributeBindingContainer
    {
        public attributeBindingDefinition[] attributeBindingsCatalogue { get; init; } = [];

        public ObservableCollection<AttributeViewModel> attributeBindings { get; set; } = [];

        public ComplexAttributeViewModel(ref ComplexAttribute attribute) : base(attribute) {
            this._attribute = attribute;

            this.attributeBindingsCatalogue = this._attribute.attributeBindingsCatalogue;

            this.attributeBindings.CollectionChanged += (s, e) => {
                if (e.OldItems is not null) {
                    foreach (var item in e.OldItems) {
                        if (item is SimpleAttributeViewModel simpleAttributeViewModel) {
                            this._attribute.RemoveAttribute(simpleAttributeViewModel.attribute);
                        }
                        if (item is ComplexAttributeViewModel complexAttributeViewModel) {
                            this._attribute.RemoveAttribute(complexAttributeViewModel.attribute);
                        }

                        if (item is AttributeViewModel attribute) {
                            attribute.PropertyChanged -= this.Viewmodel_PropertyChanged;
                        }
                    }
                }
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
                var attributeBindingDefinition = this.attributeBindingsCatalogue.Single(a => a.attribute.Equals(e.S100FC_code));

                if (e is SimpleAttribute simpleAttribute) {
                    var viewmodel = new SimpleAttributeViewModel(ref simpleAttribute, attributeBindingDefinition);
                    this.attributeBindings.Add(viewmodel);
                }
                else if (e is ComplexAttribute complexAttribute) {
                    var viewmodel = new ComplexAttributeViewModel(ref complexAttribute);
                    this.attributeBindings.Add(viewmodel);
                }
            }

            //note: Must be added right by the end!
            this.attributeBindings.CollectionChanged += (s, e) => {
                base.OnPropertyChanged(nameof(attributeBindings));
            };
        }

        public bool HasCapacity(attributeBindingDefinition binding) {
            var count = this.attributeBindings.Count(e => e.code.Equals(binding.attribute));
            return binding.upper > count;
        }

        public bool HasCapacity(IGrouping<string, informationBindingDefinition> binding) {
            return false;
        }

        public bool HasCapacity(IGrouping<string, featureBindingDefinition> binding) {
            return false;
        }

        public void AddAttribute(AttributeViewModel attributeBinding) {
            this.attributeBindings.Add(attributeBinding);
            this._attribute?.SetAttribute(attributeBinding.attribute);
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

            ValidateProperty(propertyName!, newValue);
            return true;
        }
        #endregion

        #region INotifyDataErrorInfo
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged = default;

        public bool HasErrors => this._errors.Any();

        public IEnumerable GetErrors(string propertyName) => "associations".Equals(propertyName) ? _errors.Values.SelectMany(x => x) ?? Enumerable.Empty<string>() : Enumerable.Empty<string>();

        private void ValidateProperty(string propertyName, object? value) {
            if (propertyName == nameof(roleType)) {
                var s = (string?)value ?? string.Empty;
                SetError(propertyName, string.IsNullOrWhiteSpace(s) ? "roleType is required." : null);
            }
            if (propertyName == nameof(role)) {
                var s = (string?)value ?? string.Empty;
                SetError(propertyName, string.IsNullOrWhiteSpace(s) ? "role is required." : null);
            }
            if (propertyName == nameof(informationType)) {
                var s = (string?)value ?? string.Empty;
                SetError(propertyName, string.IsNullOrWhiteSpace(s) ? "informationType is required." : null);
            }
            if (propertyName == nameof(informationUID)) {
                SetError(propertyName, value is null ? "informationUID is required." : null);
            }

            // Notify that HasErrors might have changed
            OnPropertyChanged(nameof(HasErrors));
        }

        private void SetError(string propertyName, string? error) {
            var had = _errors.Remove(propertyName);
            if (!string.IsNullOrEmpty(error))
                _errors[propertyName] = new List<string> { error };

            if (had || !string.IsNullOrEmpty(error))
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private readonly Dictionary<string, List<string>> _errors = new();
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
                    this._informationBindingDefinition = null;
                    this.role = null;
                    this.roleType = null;
                    this.informationTypes.Clear();
                    this.informationType = null;
                    this.informationUIDs.Clear();
                    this.informationUID = null;
                }
                else if (e.PropertyName.Equals(nameof(role))) {
                    this._informationBindingDefinition = this._informationBindingDefinitions.Single(e => e.role.Equals(this.role));
                    this.roleType = this._informationBindingDefinition.roleType;

                    this.informationType = null;
                    this.informationTypes.Clear();
                    foreach (var featureType in this._informationBindingDefinition.informationTypes) {
                        this.informationTypes.Add(featureType);
                    }

                    this.informationUID = null;
                    this.informationUIDs.Clear();
                }
                else if (e.PropertyName.Equals(nameof(informationType))) {
                }
                else if (e.PropertyName.Equals(nameof(informationUID))) {
                    if (this.informationUID is not null) {
                        if (!this.informationUIDs.Contains(this.informationUID)) {
                            this.informationUIDs.Insert(0, this.informationUID);
                        }
                    }
                }
                //this.Validate();
            };

            this.role = this.roles[0];

            this.ValidateProperty(nameof(roleType), this.roleType);
            this.ValidateProperty(nameof(role), this.role);
            this.ValidateProperty(nameof(informationType), this.informationType);
            this.ValidateProperty(nameof(informationUID), this.informationUID);
        }

        private informationBindingDefinition? _informationBindingDefinition { get; set; } = null;

        public informationBindingDefinition? informationBindingDefinition => this._informationBindingDefinition;

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

    public class FeatureBindingViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
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

            ValidateProperty(propertyName!, newValue);
            return true;
        }
        #endregion

        #region INotifyDataErrorInfo
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged = default;

        public bool HasErrors => this._errors.Any();

        public IEnumerable GetErrors(string propertyName) => "associations".Equals(propertyName) ? _errors.Values.SelectMany(x => x) ?? Enumerable.Empty<string>() : Enumerable.Empty<string>();

        private void ValidateProperty(string propertyName, object? value) {
            if (propertyName == nameof(roleType)) {
                var s = (string?)value ?? string.Empty;
                SetError(propertyName, string.IsNullOrWhiteSpace(s) ? "roleType is required." : null);
            }
            if (propertyName == nameof(role)) {
                var s = (string?)value ?? string.Empty;
                SetError(propertyName, string.IsNullOrWhiteSpace(s) ? "role is required." : null);
            }
            if (propertyName == nameof(featureType)) {
                var s = (string?)value ?? string.Empty;
                SetError(propertyName, string.IsNullOrWhiteSpace(s) ? "featureType is required." : null);
            }
            if (propertyName == nameof(featureUID)) {
                SetError(propertyName, value is null ? "featureUID is required." : null);
            }

            // Notify that HasErrors might have changed
            OnPropertyChanged(nameof(HasErrors));
        }

        private void SetError(string propertyName, string? error) {
            var had = _errors.Remove(propertyName);
            if (!string.IsNullOrEmpty(error))
                _errors[propertyName] = new List<string> { error };

            if (had || !string.IsNullOrEmpty(error))
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private readonly Dictionary<string, List<string>> _errors = new();
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
                    this._featureBindingDefinition = null;

                    this.role = null;
                    this.roleType = null;
                    this.featureTypes.Clear();
                    this.featureType = null;
                    this.featureUIDs.Clear();
                    this.featureUID = null;
                }
                else if (e.PropertyName.Equals(nameof(role))) {
                    this._featureBindingDefinition = this._featureBindingDefinitions.Single(e => e.role.Equals(this.role));
                    this.roleType = this._featureBindingDefinition.roleType;

                    this.featureType = null;
                    this.featureTypes.Clear();
                    foreach (var featureType in this._featureBindingDefinition.featureTypes) {
                        this.featureTypes.Add(featureType);
                    }

                    this.featureUID = null;
                    this.featureUIDs.Clear();
                }
                else if (e.PropertyName.Equals(nameof(featureType))) {
                }
                else if (e.PropertyName.Equals(nameof(featureUID))) {
                    if (this.featureUID is not null) {
                        if (!this.featureUIDs.Contains(this.featureUID)) {
                            this.featureUIDs.Insert(0, this.featureUID);
                        }
                    }
                }
                //this.Validate();
            };

            this.ValidateProperty(nameof(roleType), this.roleType);
            this.ValidateProperty(nameof(role), this.role);
            this.ValidateProperty(nameof(featureType), this.featureType);
            this.ValidateProperty(nameof(featureUID), this.featureUID);
        }

        private featureBindingDefinition? _featureBindingDefinition { get; set; } = null;

        public featureBindingDefinition? featureBindingDefinition => this._featureBindingDefinition;

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

        public static explicit operator featureBinding(FeatureBindingViewModel viewmodel) {
            return null;
        }
    }
}
