using S100Framework.DomainModel;
using S100Framework.WPF.Editors;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace S100Framework.WPF.ViewModel
{
    public static class Handles
    {
        public static Func<InformationBindingViewModel?, string[]> GetInformations { get; set; } = (e) => { return []; };

        public static Func<FeatureBindingViewModel?, string[]> GetFeatures { get; set; } = (e) => { return []; };

        public static Func<InformationRefIdViewModel?, Task<string[]>> GetInformationsRefId { get; set; } = (e) => { return Task.FromResult(Array.Empty<string>()); };

        public static Func<FeatureRefIdViewModel?, Task<string[]>> GetFeaturesRefId { get; set; } = (e) => { return Task.FromResult(Array.Empty<string>()); };
    }

    public interface iHandles
    {
        public abstract static IDictionary<Type, Func<InformationAssociationConnector[]>> AssociationConnectorInformations { get; }
        public abstract static IDictionary<Type, Func<FeatureAssociationConnector[]>> AssociationConnectorFeatures { get; }
    }

    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
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

    public abstract class AssociationViewModel : ViewModelBase
    {
        [PropertyOrder(0)]
        public abstract string Code { get; }

        [Browsable(false)]
        public abstract string[] Roles { get; }        
    }

    public abstract class InformationAssociationViewModel : AssociationViewModel
    {
        protected InformationAssociationConnector? _associationConnector;

        [Editor(typeof(InformationConnectorEditor), typeof(InformationConnectorEditor))]
        public abstract InformationAssociationConnector? association { get; set; }

        [Browsable(false)]
        public abstract InformationAssociationConnector[] associationConnectorInformations { get; }

        public abstract void Load(S100Framework.DomainModel.InformationAssociation informationAssociation);
    }

    public abstract class FeatureAssociationViewModel : AssociationViewModel
    {
        protected FeatureAssociationConnector? _associationConnector;

        [Editor(typeof(FeatureConnectorEditor), typeof(FeatureConnectorEditor))]        
        public abstract FeatureAssociationConnector? association { get; set; }

        [Browsable(false)]
        public abstract FeatureAssociationConnector[] associationConnectorFeatures { get; }

        public abstract void Load(S100Framework.DomainModel.FeatureAssociation featureAssociation);
    }

    public abstract class AssociationConnector
    {
        public DomainModel.Bindings.roleType roleType { get; set; }

        public string role { get; set; } = string.Empty;

        [Browsable(false)]
        public string[] AssociationTypes { get; set; } = [];

        [PropertyOrder(1)]
        public int Lower { get; set; } = 0;

        [PropertyOrder(2)]
        public int? Upper { get; set; } = default;        
    }

    public abstract class InformationAssociationConnector : AssociationConnector
    {
        public abstract string InformationType { get; }

        public Func<InformationBindingViewModel?> CreateForeignInformationBinding { get; set; } = () => default;

        public Func<InformationBindingViewModel?> CreateLocalInformationBinding { get; set; } = () => default;

        public Func<FeatureBindingViewModel?> CreateLocalFeatureBinding { get; set; } = () => default;        
    }

    public class InformationAssociationConnector<T> : InformationAssociationConnector where T : Node
    {
        public override string InformationType => typeof(T).Name;

        public string DisplayName => $"{typeof(T).Name}, {base.role}";

        public override bool Equals(object? obj) {
            if (obj == null || GetType() != obj.GetType())
                return false;
            var other = (InformationAssociationConnector<T>)obj;
            return this.InformationType.Equals(other.InformationType, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode() {
            return this.InformationType.GetHashCode();
        }
    }

    public abstract class FeatureAssociationConnector : AssociationConnector
    {
        public abstract string FeatureType { get; }

        public Func<FeatureBindingViewModel?> CreateForeignFeatureBinding { get; set; } = () => default;

        public Func<FeatureBindingViewModel?> CreateLocalFeatureBinding { get; set; } = () => default;
    }

    public class FeatureAssociationConnector<T> : FeatureAssociationConnector where T : FeatureNode
    {
        public override string FeatureType => typeof(T).Name;

        public string DisplayName => $"{typeof(T).Name}, {base.role}";

        public override bool Equals(object? obj) {
            if (obj == null || GetType() != obj.GetType())
                return false;
            var other = (FeatureAssociationConnector<T>)obj;
            return this.FeatureType.Equals(other.FeatureType, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode() {
            return this.FeatureType.GetHashCode();
        }
    }

    public abstract class RefIdViewModel : ViewModelBase
    {
        protected string? _type = default;

        [Browsable(false)]
        public virtual string? Type {
            get { return _type; }
            set {
                this.SetValue(ref _type, value);
            }
        }

        private string? _refId = string.Empty;

        [Editor(typeof(RefIdEditor), typeof(RefIdEditor))]
        public string? RefId {
            get { return _refId; }
            set { this.SetValue(ref _refId, value); }
        }

        [Browsable(false)]
        public abstract string[] AssociationTypes { get; }

        public override string Serialize() {
            throw new NotImplementedException();
        }
    }

    public abstract class InformationRefIdViewModel : RefIdViewModel
    {        
        [Editor(typeof(InformationBindingEditor), typeof(InformationBindingEditor))]
        public string? InformationType {
            get { return _type; }
            set {
                this.SetValue(ref _type, value);

                _ = UpdateInformationType(value);   // Fire and forget 
            }
        }

        //public override string? Type { get => this.InformationType; set => this.InformationType = value; }

        private async Task UpdateInformationType(string? value) {
            RefIds.Clear();
            foreach (var e in await Handles.GetInformationsRefId(this))
                RefIds.Add(e);
        }


        public override string ToString() => string.IsNullOrEmpty(_type) ? "RefId" : $"{_type}: {RefId}";

        [Browsable(false)]
        public ObservableCollection<string> RefIds { get; set; } = new ObservableCollection<string>();

        public override string[] AssociationTypes { get; } = [];
    }

    public abstract class FeatureRefIdViewModel : RefIdViewModel
    {
        [Editor(typeof(FeatureBindingEditor), typeof(FeatureBindingEditor))]
        public string? FeatureType {
            get { return _type; }
            set {
                this.SetValue(ref _type, value);

                _ = UpdateFeatureType(value);   // Fire and forget
            }
        }

        //public override string? Type { get => this.FeatureType; set => this.FeatureType = value; }


        private async Task UpdateFeatureType(string? value) {
            RefIds.Clear();
            foreach (var e in await Handles.GetFeaturesRefId(this))
                RefIds.Add(e);
        }

        public override string ToString() => string.IsNullOrEmpty(_type) ? "RefId" : $"{_type}: {RefId}";

        [Browsable(false)]
        public ObservableCollection<string> RefIds { get; set; } = new ObservableCollection<string>();

        public override string[] AssociationTypes { get; } = [];
    }

    public abstract class InformationBindingViewModel : ViewModelBase
    {
        public abstract void Load(InformationAssociation informationAssociation, string role);

        public abstract InformationAssociation Save(InformationAssociation featureAssociation, string role);

        public override string Serialize() {
            throw new NotImplementedException();
        }
    }

    public abstract class InformationBindingViewModel<T> : InformationBindingViewModel where T : RefIdViewModel
    {

    }

    public class SingleInformationBindingViewModel<T> : InformationBindingViewModel<T> where T : RefIdViewModel, new()
    {
        private string _displayName;

        public SingleInformationBindingViewModel(string displayName) { 
            _displayName = displayName;
            this.RefId = new();
        }

        public override string ToString() => _displayName;

        private T? _refId = default;

        [ExpandableObject]
        public T? RefId {
            get { return _refId; }
            set { this.SetValue(ref _refId, value); }
        }

        public override void Load(InformationAssociation informationAssociation, string role) {
            var v = informationAssociation.RefIds.Where(e => e.Role.Equals(role, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            this.RefId!.RefId = v?.Value!;
            this.RefId!.Type = v?.Type;
        }

        public override InformationAssociation Save(InformationAssociation informationAssociation, string role) {
            informationAssociation.RefIds =
                [
                    .. informationAssociation.RefIds,
                    .. new []{
                        new RefId {
                            Role = role,
                            Type = _refId?.Type,
                            Value = _refId?.RefId,
                        }
                    }
                ];
            return informationAssociation;
        }
    }

    public class OptionalInformationBindingViewModel<T> : InformationBindingViewModel<T> where T : InformationRefIdViewModel, new()
    {
        private string _displayName;

        public OptionalInformationBindingViewModel(string displayName) { 
            _displayName = displayName;
        }

        public override string ToString() => _displayName;


        private T? _refId = default;

        [ExpandableObject]
        public T? RefId {
            get { return _refId; }
            set { this.SetValue(ref _refId, value); }
        }

        public override void Load(InformationAssociation informationAssociation, string role) {
            var v = informationAssociation.RefIds.Where(e => e.Role.Equals(role, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            if (v != default) {
                if (RefId is null) {
                    RefId = new();
                }
                this.RefId.RefId = v?.Value!;
                this.RefId.InformationType = v?.Type;
            }
        }

        public override InformationAssociation Save(InformationAssociation informationAssociation, string role) {
            if (_refId is default(T))
                return informationAssociation;
            informationAssociation.RefIds =
                [
                    .. informationAssociation.RefIds,
                    .. new []{
                        new RefId {
                            Role = role,
                            Type = _refId.InformationType,
                            Value = _refId.RefId,
                        }
                    }
                ];
            return informationAssociation;
        }
    }

    public class MultiInformationBindingViewModel<T> : InformationBindingViewModel<T> where T : InformationRefIdViewModel, new()
    {
        private string _displayName;

        public MultiInformationBindingViewModel(string displayName) { _displayName = displayName; }

        public override string ToString() => _displayName;


        [Editor(typeof(RefIdEditor), typeof(RefIdEditor))]
        public ObservableCollection<T> RefId { get; set; } = new ObservableCollection<T>();

        public override void Load(InformationAssociation informationAssociation, string role) {
            foreach (var e in informationAssociation.RefIds.Where(e => e.Role.Equals(role, StringComparison.InvariantCultureIgnoreCase))) {
                RefId.Add(new T {
                    InformationType = e.Type,
                    RefId = e.Value,
                });
            }
        }

        public override InformationAssociation Save(InformationAssociation informationAssociation, string role) {
            if (!RefId.Any())
                return informationAssociation;

            informationAssociation.RefIds =
            [
                .. informationAssociation.RefIds,
                .. RefId.Select(e => new RefId {
                    Role = role,
                    Type = e.InformationType,
                    Value = e.RefId,
                }),
            ];
            return informationAssociation;
        }
    }

    public abstract class FeatureBindingViewModel : ViewModelBase
    {
        public abstract void Load(FeatureAssociation featureAssociation, string role);

        public abstract FeatureAssociation Save(FeatureAssociation featureAssociation, string role);

        public override string Serialize() {
            throw new NotImplementedException();
        }
    }

    public abstract class FeatureBindingViewModel<T> : FeatureBindingViewModel where T : FeatureRefIdViewModel
    {
    }

    public class SingleFeatureBindingViewModel<T> : FeatureBindingViewModel<T> where T : FeatureRefIdViewModel, new()
    {

        private string _displayName;

        public SingleFeatureBindingViewModel(string displayName) { 
            _displayName = displayName;
            this.RefId = new();
        }

        public override string ToString() => _displayName;

        private T? _refId = default;

        [ExpandableObject]
        public T? RefId {
            get { return _refId; }
            set { this.SetValue(ref _refId, value); }
        }

        public override void Load(FeatureAssociation featureAssociation, string role) {
            var v = featureAssociation.RefIds.Where(e => e.Role.Equals(role, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            this.RefId!.RefId = v?.Value!;
            this.RefId!.FeatureType = v?.Type;
        }

        public override FeatureAssociation Save(FeatureAssociation featureAssociation, string role) {
            featureAssociation.RefIds =
                [
                    .. featureAssociation.RefIds,
                    .. new []{
                        new RefId {
                            Role = role,
                            Type = _refId?.FeatureType,
                            Value = _refId?.RefId,
                        }
                    }
                ];
            return featureAssociation;
        }
    }

    public class OptionalFeatureBindingViewModel<T> : FeatureBindingViewModel<T> where T : FeatureRefIdViewModel, new()
    {
        private string _displayName;

        public OptionalFeatureBindingViewModel(string displayName) { 
            _displayName = displayName; 
        }

        public override string ToString() => _displayName;

        private T? _refId = default;

        [ExpandableObject]
        public T? RefId {
            get { return _refId; }
            set { this.SetValue(ref _refId, value); }
        }

        public override void Load(FeatureAssociation featureAssociation, string role) {
            var v = featureAssociation.RefIds.Where(e => e.Role.Equals(role, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            if (v != default) {
                if (RefId is null) {
                    RefId = new();
                }
                this.RefId.RefId = v?.Value!;
                this.RefId.FeatureType = v?.Type;
            }
        }

        public override FeatureAssociation Save(FeatureAssociation featureAssociation, string role) {
            if (_refId is default(T))
                return featureAssociation;
            featureAssociation.RefIds =
                [
                    .. featureAssociation.RefIds,
                    .. new []{
                        new RefId {
                            Role = role,
                            Type = _refId.FeatureType,
                            Value = _refId.RefId,
                        }
                    }
                ];
            return featureAssociation;
        }
    }

    public class MultiFeatureBindingViewModel<T> : FeatureBindingViewModel<T> where T : FeatureRefIdViewModel, new()
    {
        private string _displayName;
        public MultiFeatureBindingViewModel(string displayName) { _displayName = displayName; }

        public override string ToString() => _displayName;

        public ObservableCollection<T> RefId { get; set; } = new ObservableCollection<T>();

        public override void Load(FeatureAssociation featureAssociation, string role) {
            foreach (var e in featureAssociation.RefIds.Where(e => e.Role.Equals(role, StringComparison.InvariantCultureIgnoreCase))) {
                RefId.Add(new T {
                    FeatureType = e.Type,
                    RefId = e.Value,
                });
            }
        }

        public override FeatureAssociation Save(FeatureAssociation featureAssociation, string role) {
            if (!RefId.Any())
                return featureAssociation;

            featureAssociation.RefIds =
            [
                .. featureAssociation.RefIds,
                .. RefId.Select(e => new RefId {
                    Role = role,
                    Type = e.FeatureType,
                    Value = e.RefId,
                }),
            ];
            return featureAssociation;
        }
    }
}
