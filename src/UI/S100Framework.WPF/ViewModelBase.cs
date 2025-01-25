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

        public static Func<InformationRefIdViewModel?, string[]> GetInformationsRefId { get; set; } = (e) => { return []; };

        public static Func<FeatureRefIdViewModel?, string[]> GetFeaturesRefId { get; set; } = (e) => { return []; };
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

    public abstract class AssociationViewModel : INotifyPropertyChanged
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

        [PropertyOrder(0)]
        public abstract string Code { get; }

        [Browsable(false)]
        public abstract string[] Roles { get; }
    }

    public abstract class InformationAssociationViewModel : AssociationViewModel
    {
        protected InformationAssociationConnector? _associationConnector;

        [Editor(typeof(InformationConnectorEditor), typeof(InformationConnectorEditor))]
        [ExpandableObject]
        public abstract InformationAssociationConnector? associationConnector { get; set; }

        [Browsable(false)]
        public abstract InformationAssociationConnector[] associationConnectorInformations { get; }
    }

    public abstract class FeatureAssociationViewModel : AssociationViewModel
    {
        protected FeatureAssociationConnector? _associationConnector;

        [Editor(typeof(FeatureConnectorEditor), typeof(FeatureConnectorEditor))]
        [ExpandableObject]
        public abstract FeatureAssociationConnector? associationConnector { get; set; }

        [Browsable(false)]
        public abstract FeatureAssociationConnector[] associationConnectorFeatures { get; }
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

    public abstract class RefIdViewModel : INotifyPropertyChanged
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

        private string _refId = string.Empty;

        [Editor(typeof(RefIdEditor), typeof(RefIdEditor))]
        public string RefId {
            get { return _refId; }
            set { this.SetValue(ref _refId, value); }
        }

        [Browsable(false)]
        public abstract string[] AssociationTypes { get; }
    }

    public abstract class InformationRefIdViewModel : RefIdViewModel
    {
        private string? _informationType = default;

        [Editor(typeof(InformationBindingEditor), typeof(InformationBindingEditor))]
        public string? InformationType {
            get { return _informationType; }
            set {
                this.SetValue(ref _informationType, value);

                RefIds.Clear();
                foreach (var e in Handles.GetInformationsRefId(this)!)
                    RefIds.Add(e);
            }
        }

        public override string ToString() => string.IsNullOrEmpty(_informationType) ? "RefId" : $"{_informationType}: {RefId}";

        [Browsable(false)]
        public ObservableCollection<string> RefIds { get; set; } = new ObservableCollection<string>();

        public override string[] AssociationTypes { get; } = [];
    }

    public abstract class FeatureRefIdViewModel : RefIdViewModel
    {
        private string? _featureType = default;

        [Editor(typeof(FeatureBindingEditor), typeof(FeatureBindingEditor))]
        public string? FeatureType {
            get { return _featureType; }
            set {
                this.SetValue(ref _featureType, value);

                RefIds.Clear();
                foreach (var e in Handles.GetFeaturesRefId(this))
                    RefIds.Add(e);
            }
        }

        public override string ToString() => string.IsNullOrEmpty(_featureType) ? "RefId" : $"{_featureType}: {RefId}";

        [Browsable(false)]
        public ObservableCollection<string> RefIds { get; set; } = new ObservableCollection<string>();

        public override string[] AssociationTypes { get; } = [];
    }

    public abstract class InformationBindingViewModel : INotifyPropertyChanged
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

        public abstract void Load(S100Framework.DomainModel.RefId[] refIds);
    }

    public abstract class InformationBindingViewModel<T> : InformationBindingViewModel where T : InformationRefIdViewModel
    {

    }

    public class SingleInformationBindingViewModel<T> : InformationBindingViewModel<T> where T : InformationRefIdViewModel, new()
    {
        private string _displayName;

        public SingleInformationBindingViewModel(string displayName) { _displayName = displayName; }

        public override string ToString() => _displayName;

        private T _refId = new();

        [ExpandableObject]
        public T RefId {
            get { return _refId; }
            set { this.SetValue(ref _refId, value); }
        }

        public override void Load(S100Framework.DomainModel.RefId[] refIds) {
            var v = refIds.FirstOrDefault();
            this.RefId.RefId = v?.Value!;
            this.RefId.InformationType = v?.Type;
        }
    }

    public class OptionalInformationBindingViewModel<T> : InformationBindingViewModel<T> where T : InformationRefIdViewModel, new()
    {
        private string _displayName;

        public OptionalInformationBindingViewModel(string displayName) { _displayName = displayName; }

        public override string ToString() => _displayName;


        private T? _refId = default;

        [ExpandableObject]
        public T? RefId {
            get { return _refId; }
            set { this.SetValue(ref _refId, value); }
        }

        public override void Load(S100Framework.DomainModel.RefId[] refIds) {
            var v = refIds.FirstOrDefault();
            if (v != default) {
                if (RefId is null) {
                    RefId = new();
                }
                this.RefId.RefId = v?.Value!;
                this.RefId.InformationType = v?.Type;
            }
        }
    }

    public class MultiInformationBindingViewModel<T> : InformationBindingViewModel<T> where T : InformationRefIdViewModel, new()
    {
        private string _displayName;

        public MultiInformationBindingViewModel(string displayName) { _displayName = displayName; }

        public override string ToString() => _displayName;


        [Editor(typeof(RefIdEditor), typeof(RefIdEditor))]
        public ObservableCollection<T> RefId { get; set; } = new ObservableCollection<T>();

        public override void Load(S100Framework.DomainModel.RefId[] refIds) {
            foreach (var e in refIds) {
                RefId.Add(new T {
                    InformationType = e.Type,
                    RefId = e.Value,
                });
            }
        }
    }

    public abstract class FeatureBindingViewModel : INotifyPropertyChanged
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

        public abstract void Load(S100Framework.DomainModel.RefId[] refIds);
    }

    public abstract class FeatureBindingViewModel<T> : FeatureBindingViewModel where T : FeatureRefIdViewModel
    {
    }

    public class SingleFeatureBindingViewModel<T> : FeatureBindingViewModel<T> where T : FeatureRefIdViewModel, new()
    {
        private string _displayName;

        public SingleFeatureBindingViewModel(string displayName) { _displayName = displayName; }

        public override string ToString() => _displayName;

        private T _refId = new();

        [ExpandableObject]
        public T RefId {
            get { return _refId; }
            set { this.SetValue(ref _refId, value); }
        }

        public override void Load(S100Framework.DomainModel.RefId[] refIds) {
            var v = refIds.FirstOrDefault();
            this.RefId.RefId = v?.Value!;
            this.RefId.FeatureType = v?.Type;
        }
    }

    public class OptionalFeatureBindingViewModel<T> : FeatureBindingViewModel<T> where T : FeatureRefIdViewModel, new()
    {
        private string _displayName;

        public OptionalFeatureBindingViewModel(string displayName) { _displayName = displayName; }

        public override string ToString() => _displayName;

        private T? _refId = default;

        [ExpandableObject]
        public T? RefId {
            get { return _refId; }
            set { this.SetValue(ref _refId, value); }
        }

        public override void Load(S100Framework.DomainModel.RefId[] refIds) {
            var v = refIds.FirstOrDefault();
            if (v != default) {
                if (RefId is null) {
                    RefId = new();
                }
                this.RefId.RefId = v?.Value!;
                this.RefId.FeatureType = v?.Type;
            }
        }
    }

    public class MultiFeatureBindingViewModel<T> : FeatureBindingViewModel<T> where T : FeatureRefIdViewModel, new()
    {
        private string _displayName;
        public MultiFeatureBindingViewModel(string displayName) { _displayName = displayName; }

        public override string ToString() => _displayName;

        public ObservableCollection<T> RefId { get; set; } = new ObservableCollection<T>();

        public override void Load(S100Framework.DomainModel.RefId[] refIds) {
            foreach (var e in refIds) {
                RefId.Add(new T {
                    FeatureType = e.Type,
                    RefId = e.Value,
                });
            }
        }
    }
}
