using S100Framework.DomainModel;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

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

    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class S100TruncatedDateAttribute : System.Attribute
    {
    }

    public abstract class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo, IDisposable
    {
        public ViewModelBase() {
            this.PropertyChanged += (sender, e) => {
                if (string.IsNullOrEmpty(e.PropertyName)) return;
                if (e.PropertyName == nameof(this.HasErrors)) return; // Prevent recursive validation call

                this.Validate();
            };
        }

        //[Browsable(false)]
        //public Guid? UID { get; set; } = default;

        public abstract string Serialize();

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly Dictionary<ViewModelBase, string> nestedProperties = [];

        protected void SetValue<T>(ref T backingFiled, T value, [CallerMemberName] string? propertyName = null) {
            if (string.IsNullOrWhiteSpace(propertyName)) return;

            if (EqualityComparer<T>.Default.Equals(backingFiled, value)) return;
            if (backingFiled is ViewModelBase viewModel) {   // if old value is ViewModel, than we assume that it was subscribed, so - unsubscribe it
                viewModel.PropertyChanged -= this.ChildViewModelChanged;
                this.nestedProperties.Remove(viewModel);
            }
            if (value is ViewModelBase valueViewModel) {
                // if new value is ViewModel, than we must subscribe it on PropertyChanged and add it into subscribe dictionary
                valueViewModel.PropertyChanged += this.ChildViewModelChanged;
                this.nestedProperties.Add(valueViewModel, propertyName);
            }
            backingFiled = value;
            this.OnPropertyChanged(propertyName);
        }

        private void ChildViewModelChanged(object? sender, PropertyChangedEventArgs e) {
            if (string.IsNullOrEmpty(e.PropertyName)) return;

            // this is child property name, need to get parent property name from dictionary
            string propertyName = e.PropertyName;
            if (sender is ViewModelBase viewModel) {
                propertyName = this.nestedProperties[viewModel];
            }
            // Rise parent PropertyChanged with parent property name
            this.OnPropertyChanged(propertyName);
        }

        #endregion

        #region INotifyDataErrorInfo

        private readonly Dictionary<string, List<string>> _errors = [];

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        [Browsable(false)]
        public bool HasErrors => this._errors.Any();

        public IEnumerable GetErrors(string? propertyName) {
            if (string.IsNullOrEmpty(propertyName) || !this._errors.ContainsKey(propertyName)) {
                return Enumerable.Empty<string>();
            }
            return this._errors[propertyName];
        }

        public IEnumerable<string> GetErrors() {
            return this._errors.Keys;
        }

        protected void OnErrorsChanged(string propertyName) {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        #endregion

        #region Validate

        protected abstract void Validate();

        //protected virtual void Validate() {
        //    this._errors.Clear(); // Clear previous errors

        //    var context = new NullabilityInfoContext();

        //    bool IsNuallable(PropertyInfo property) {
        //        var info = context.Create(property);
        //        return info.ReadState == NullabilityState.Nullable;
        //    }

        //    var t = this.GetType().GetProperties()
        //        .Where(p => p.GetCustomAttribute<BrowsableAttribute>() == null && !IsNuallable(p))
        //        .ToList();

        //    this.GetType().GetProperties()
        //        .Where(p => p.GetCustomAttribute<BrowsableAttribute>() == null && !IsNuallable(p))
        //        .ToList()
        //        .ForEach(p => {
        //            var value = p.GetValue(this);
        //            if (value == null || (value is string str && string.IsNullOrWhiteSpace(str))) {
        //                this.AddError(p.Name, $"{p.Name} is required.");
        //            }
        //        });

        //    this.GetType().GetProperties()
        //        .Where(p => p.GetCustomAttribute<S100TruncatedDateAttribute>() != null)
        //        .ToList()
        //        .ForEach(p => {
        //            var value = p.GetValue(this);
        //            if (value == null || (value is string str && string.IsNullOrWhiteSpace(str))) {
        //                this.AddError(p.Name, $"{p.Name} is required.");
        //            }
        //        });
        //}

        protected void AddError(string propertyName, string errorMessage) {
            if (!this._errors.ContainsKey(propertyName)) {
                this._errors[propertyName] = [];
            }
            if (!this._errors[propertyName].Contains(errorMessage)) {
                this._errors[propertyName].Add(errorMessage);
                this.OnErrorsChanged(propertyName);
            }
        }

        protected void RemoveError(string propertyName, string errorMessage) {
            if (this._errors.ContainsKey(propertyName) && this._errors[propertyName].Contains(errorMessage)) {
                this._errors[propertyName].Remove(errorMessage);
                if (this._errors[propertyName].Count == 0) {
                    this._errors.Remove(propertyName);
                }
                this.OnErrorsChanged(propertyName);
            }
        }

        protected void ClearErrors(string propertyName) {
            if (this._errors.ContainsKey(propertyName)) {
                this._errors.Remove(propertyName);
                this.OnErrorsChanged(propertyName);
            }
        }

        protected void ClearErrors() {
            foreach (var propertyName in this._errors.Keys.ToArray()) {
                this._errors.Remove(propertyName);
                this.OnErrorsChanged(propertyName);
            }
        }

        #endregion

        #region IDisposable
        public void Dispose() {   // need to make sure that we unsubscibed
            foreach (ViewModelBase viewModel in this.nestedProperties.Keys) {
                viewModel.PropertyChanged -= this.ChildViewModelChanged;
                viewModel.Dispose();
            }
        }

        #endregion

        protected void Validate(PropertyInfo[] properties, PropertyInfo[] viewmodelProperties) {
            string[] errors = [.. this.GetErrors()];

            this.ClearErrors();

            foreach (var p in properties) {
                var required = p.GetCustomAttribute<MandatoryAttribute>();
                if (required != default) {
                    var value = viewmodelProperties.Single(e => e.Name == p.Name)?.GetValue(this);
                    if (value is null) {
                        // UNKNOWN, this.AddError(p.Name, $"{p.Name} is required.");
                    }
                }

                //var attribute = p.GetCustomAttribute<DependentUnknownValueAttribute>();
                //if (attribute != default) {
                //    var value = viewmodelProperties.Single(e => e.Name == p.Name)?.GetValue(this);
                //    if (value is null) {
                //        var dependentValue = viewmodelProperties.Single(e => e.Name == attribute.PropertyName)?.GetValue(this);
                //        if (dependentValue is null) {
                //            this.AddError(p.Name, $"attribute {p.Name} must be populated with a value, which must not be an empty (null) value, if the attribute {attribute.PropertyName} is populated with an empty (null) value!");
                //        }
                //    }
                //}
            }

            //foreach (var e in this.GetErrors().Where(e => !errors.Contains(e)))
            //    this.OnErrorsChanged(e);
        }
    }

    public class InformationRefViewModel : ViewModelBase
    {
        private string _role = string.Empty;

        //[Editor(typeof(Editors.FeatureBindingRoleEditor), typeof(Editors.FeatureBindingRoleEditor))]
        public string role {
            get { return this._role; }
            set {
                this.SetValue(ref this._role, value);
            }
        }

        private string _referenceId = string.Empty;

        //[Editor(typeof(Editors.FeatureBindingLinkEditor), typeof(Editors.FeatureBindingLinkEditor))]
        public string informationId {
            get { return this._referenceId; }
            set {
                this.SetValue(ref this._referenceId, value);
            }
        }

        private string? _informationType = default;

        [ReadOnly(true)]
        public string? informationType {
            get { return this._informationType; }
            set {
                this.SetValue(ref this._informationType, value);
            }
        }

        public override string Serialize() {
            throw new NotImplementedException();
        }

        protected override void Validate() {
            throw new NotImplementedException();
        }
    }


    public class FeatureRefViewModel : ViewModelBase
    {
        private string _role = string.Empty;

        [Editor(typeof(Editors.FeatureBindingRoleEditor), typeof(Editors.FeatureBindingRoleEditor))]
        public string role {
            get { return this._role; }
            set {
                this.SetValue(ref this._role, value);
            }
        }

        private string _referenceId = string.Empty;

        [Editor(typeof(Editors.FeatureBindingLinkEditor), typeof(Editors.FeatureBindingLinkEditor))]
        public string featureId {
            get { return this._referenceId; }
            set {
                this.SetValue(ref this._referenceId, value);
            }
        }

        private string? _featureType = default;

        [ReadOnly(true)]
        public string? featureType {
            get { return this._featureType; }
            set {
                this.SetValue(ref this._featureType, value);
            }
        }

        public override string Serialize() {
            throw new NotImplementedException();
        }

        protected override void Validate() {
            throw new NotImplementedException();
        }
    }






    public abstract class AssociationViewModel : ViewModelBase
    {
        [Browsable(false)]
        public string? Name { get; set; } = default;

        protected override void Validate() {
        }
    }

    public interface IInformationBinding
    {
        abstract informationBindingDefinition[] informationBindings { get; }
    }

    public abstract class InformationAssociationViewModel : AssociationViewModel
    {
        //private String _role = string.Empty;

        //[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
        //public String role {
        //    get { return _role; }
        //    set {
        //        SetValue(ref _role, value);
        //    }
        //}

        //private String _informationId = string.Empty;

        //[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
        //public String informationId {
        //    get {
        //        return _informationId;
        //    }

        //    set {
        //        SetValue(ref _informationId, value);
        //    }
        //}
    }


    public abstract class informationBindingViewModel : ViewModelBase
    {
        private string _role = string.Empty;

        [Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
        public string role {
            get { return this._role; }
            set {
                this.SetValue(ref this._role, value);
            }
        }

        private string? _informationType = default;

        [ReadOnly(true)]
        public string? informationType {
            get { return this._informationType; }
            set {
                this.SetValue(ref this._informationType, value);
            }
        }

        private string _referenceId = string.Empty;

        [Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
        public string informationId {
            get { return this._referenceId; }
            set {
                this.SetValue(ref this._referenceId, value);
            }
        }

        //public string roleType { get; set; } = string.Empty;

        //public abstract informationBinding[] informationBindings { get; }
    }

    public abstract class informationBindingViewModel<TAssociation> : informationBindingViewModel where TAssociation : InformationAssociationViewModel, new()
    {
        private TAssociation _association = new();

        [ExpandableObject]
        public TAssociation association {
            get { return this._association; }
            set {
                this.SetValue(ref this._association, value);
            }
        }

        protected override void Validate() {
            //TODO: Validate role and referenceId
        }
    }



    public interface IFeatureBinding
    {
        abstract featureBindingDefinition[] featureBindings { get; }
    }

    public abstract class FeatureAssociationViewModel : AssociationViewModel
    {
        //private String _role = string.Empty;

        //[Editor(typeof(Editors.FeatureBindingRoleEditor), typeof(Editors.FeatureBindingRoleEditor))]
        //public String role {
        //    get { return _role; }
        //    set {
        //        SetValue(ref _role, value);
        //    }
        //}

        //private String _featureId = string.Empty;

        //[Editor(typeof(Editors.FeatureBindingLinkEditor), typeof(Editors.FeatureBindingLinkEditor))]
        //public String featureId {
        //    get {
        //        return _featureId;
        //    }

        //    set {
        //        SetValue(ref _featureId, value);
        //    }
        //}
    }

    public abstract class featureBindingViewModel : ViewModelBase
    {
        private string _role = string.Empty;

        [Editor(typeof(Editors.FeatureBindingRoleEditor), typeof(Editors.FeatureBindingRoleEditor))]
        public string role {
            get { return this._role; }
            set {
                this.SetValue(ref this._role, value);
            }
        }

        private string? _featureType = default;

        [ReadOnly(true)]
        public string? featureType {
            get { return this._featureType; }
            set {
                this.SetValue(ref this._featureType, value);
            }
        }

        private string _referenceId = string.Empty;

        [Editor(typeof(Editors.FeatureBindingLinkEditor), typeof(Editors.FeatureBindingLinkEditor))]
        public string featureId {
            get { return this._referenceId; }
            set {
                this.SetValue(ref this._referenceId, value);
            }
        }

        //public string roleType { get; set; } = string.Empty;

        //public abstract featureBinding[] featureBindings { get; }
    }

    public abstract class featureBindingViewModel<TAssociation> : featureBindingViewModel where TAssociation : FeatureAssociationViewModel, new()
    {
        private TAssociation _association = new();

        [ExpandableObject]
        public TAssociation association {
            get { return this._association; }
            set {
                this.SetValue(ref this._association, value);
            }
        }

        protected override void Validate() {
            //TODO: Validate role and referenceId
        }
    }

    public abstract class ComplexViewModel : ViewModelBase
    {
        protected override void Validate() {
        }
    }

    public abstract class ComplexViewModel<TComplexType> : ComplexViewModel where TComplexType : ComplexType
    {
        protected override void Validate() {
            base.Validate(typeof(TComplexType).GetProperties(), this.GetType().GetProperties());
        }
    }


    public abstract class InformationViewModel : ViewModelBase, ISerializable
    {
        [Browsable(false)]
        public string? Name { get; set; } = default;

        [Browsable(false)]
        public abstract informationBindingDefinition[] informationBindingDefinitions { get; }

        public event PropertyChangedEventHandler? InformationBindingCollectionChanged;
        protected virtual void OnInformationBindingCollectionChanged([CallerMemberName] string? propertyName = null) {
            InformationBindingCollectionChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract informationBinding[] GetInformationBindings();

        public InformationViewModel() {
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

        public event PropertyChangedEventHandler? InformationBindingCollectionChanged;

        protected virtual void OnInformationBindingCollectionChanged([CallerMemberName] string? propertyName = null) {
            InformationBindingCollectionChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? FeatureBindingCollectionChanged;

        protected virtual void OnFeatureBindingCollectionChanged([CallerMemberName] string? propertyName = null) {
            FeatureBindingCollectionChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract informationBinding[] GetInformationBindings();

        public abstract featureBinding[] GetFeatureBindings();

        public FeatureViewModel() {
        }
    }
    public abstract class InformationViewModel<TInformationType> : InformationViewModel where TInformationType : InformationNode
    {
        protected override void Validate() {
            base.Validate(typeof(TInformationType).GetProperties(), this.GetType().GetProperties());
        }
    }

    public abstract class FeatureViewModel<TFeatureType> : FeatureViewModel where TFeatureType : FeatureNode
    {
        protected override void Validate() {
            base.Validate(typeof(TFeatureType).GetProperties(), this.GetType().GetProperties());
        }
    }


    //    public class TristateViewModel<T> : ViewModelBase
    //    {
    //        private T? _value;

    //        public T? value {
    //            get { return _value; }
    //            set {
    //                SetValue(ref _value, value);
    //            }
    //        }

    //        private TristateStatus _status = TristateStatus.Null;

    //        public TristateStatus status {
    //            get { return _status; }
    //            set {
    //                SetValue(ref _status, value);
    //            }
    //        }

    //        public TristateViewModel<T> Load(Tristate<T> instance) {
    //            value = instance.Value;
    //            status = instance.Status;
    //            return this;
    //        }

    //        public override string Serialize() {
    //            throw new NotImplementedException();
    //        }
    //    }
}
