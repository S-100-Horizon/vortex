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
                if (e.PropertyName == nameof(HasErrors)) return; // Prevent recursive validation call

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
        public bool HasErrors => this._errors.Any();

        public IEnumerable GetErrors(string? propertyName) {
            if (string.IsNullOrEmpty(propertyName) || !_errors.ContainsKey(propertyName)) {
                return Enumerable.Empty<string>();
            }
            return _errors[propertyName];
        }

        public IEnumerable<string> GetErrors() {
            return _errors.Keys;
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
            if (!_errors.ContainsKey(propertyName)) {
                _errors[propertyName] = new List<string>();
            }
            if (!_errors[propertyName].Contains(errorMessage)) {
                _errors[propertyName].Add(errorMessage);
                OnErrorsChanged(propertyName);
            }
        }

        protected void RemoveError(string propertyName, string errorMessage) {
            if (_errors.ContainsKey(propertyName) && _errors[propertyName].Contains(errorMessage)) {
                _errors[propertyName].Remove(errorMessage);
                if (_errors[propertyName].Count == 0) {
                    _errors.Remove(propertyName);
                }
                OnErrorsChanged(propertyName);
            }
        }

        protected void ClearErrors(string propertyName) {
            if (_errors.ContainsKey(propertyName)) {
                _errors.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

        protected void ClearErrors() {
            foreach (var propertyName in _errors.Keys.ToArray()) {
                _errors.Remove(propertyName);
                OnErrorsChanged(propertyName);
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
            get { return _role; }
            set {
                SetValue(ref _role, value);
            }
        }

        private string _referenceId = string.Empty;

        //[Editor(typeof(Editors.FeatureBindingLinkEditor), typeof(Editors.FeatureBindingLinkEditor))]
        public string informationId {
            get { return _referenceId; }
            set {
                SetValue(ref _referenceId, value);
            }
        }

        private string? _informationType = default;

        [ReadOnly(true)]
        public string? informationType {
            get { return _informationType; }
            set {
                SetValue(ref _informationType, value);
            }
        }

        public override string Serialize() {
            throw new NotImplementedException();
        }

        protected override void Validate() {
            //TODO: Validation
        }
    }

    public class FeatureRefViewModel : ViewModelBase
    {
        private string _role = string.Empty;

        //[Editor(typeof(Editors.FeatureBindingRoleEditor), typeof(Editors.FeatureBindingRoleEditor))]
        public string role {
            get { return _role; }
            set {
                SetValue(ref _role, value);
            }
        }

        private string _referenceId = string.Empty;

        //[Editor(typeof(Editors.FeatureBindingLinkEditor), typeof(Editors.FeatureBindingLinkEditor))]
        public string featureId {
            get { return _referenceId; }
            set {
                SetValue(ref _referenceId, value);
            }
        }

        private string? _featureType = default;

        [ReadOnly(true)]
        public string? featureType {
            get { return _featureType; }
            set {
                SetValue(ref _featureType, value);
            }
        }

        public override string Serialize() {
            throw new NotImplementedException();
        }

        protected override void Validate() {
            //TODO: Validation
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
        public string role { get; set; }
        public string? informationType { get; set; }
        public string informationId { get; set; }

        abstract informationBindingDefinition[] informationBindings { get; }
    }

    public abstract class InformationAssociationViewModel : AssociationViewModel
    {
    }

    public interface IFeatureBinding
    {
        public string role { get; set; }
        public string? featureType { get; set; }
        public string featureId { get; set; }

        abstract featureBindingDefinition[] featureBindings { get; }
    }

    public abstract class FeatureAssociationViewModel : AssociationViewModel
    {
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
        
        //public InformationViewModel() {
        //}
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

        //public FeatureViewModel() {
        //}
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
