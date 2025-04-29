using S100Framework.DomainModel;
using S100Framework.WPF.Editors;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace S100Framework.WPF.ViewModel
{
    public static class Handles
    {
        public static Func<InformationBindingViewModel?, string[]> GetInformations { get; set; } = (e) => { return []; };

        public static Func<FeatureBindingViewModel?, string[]> GetFeatures { get; set; } = (e) => { return []; };

        public static Func<InformationRefIdViewModel?, Task<string[]>> GetInformationsRefId { get; set; } = (e) => { return Task.FromResult(Array.Empty<string>()); };

        public static Func<FeatureRefIdViewModel?, Task<string[]>> GetFeaturesRefId { get; set; } = (e) => { return Task.FromResult(Array.Empty<string>()); };
    }

    public interface PID
    {
        public string? PID { get; }
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

    public abstract class AssociationViewModel : ViewModelBase, PID
    {
        [Browsable(false)]
        public string? PID { get; set; } = default;
    }

    public abstract class InformationAssociationViewModel : AssociationViewModel
    {
        public abstract void Load(S100Framework.DomainModel.InformationAssociation informationAssociation);
    }

    public abstract class FeatureAssociationViewModel : AssociationViewModel
    {
        public abstract void Load(S100Framework.DomainModel.FeatureAssociation featureAssociation);
    }

    public abstract class InformationViewModel : ViewModelBase, PID, ISerializable
    {
        [Browsable(false)]
        public string? PID { get; set; } = default;

        [Browsable(false)]
        public abstract informationBindingDefinition[] informationBindingDefinitions { get; }

        //public abstract string Serialize();
    }

    public abstract class FeatureViewModel : ViewModelBase, PID, ISerializable
    {
        [Browsable(false)]
        public string? PID { get; set; } = default;

        [Browsable(false)]
        public abstract informationBindingDefinition[] informationBindingDefinitions { get; }

        [Browsable(false)]
        public abstract featureBindingDefinition[] featureBindingDefinitions { get; }

        //public abstract string Serialize();
    }

    public abstract class InformationViewModel<TInformationType> : InformationViewModel where TInformationType : InformationNode
    {
        public abstract InformationViewModel<TInformationType> Load(TInformationType instance);
    }

    public abstract class FeatureViewModel<TFeatureType> : FeatureViewModel where TFeatureType : FeatureNode
    {
        public abstract FeatureViewModel<TFeatureType> Load(TFeatureType instance);
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

        private string? _refId = string.Empty;

        [Editor(typeof(RefIdEditor), typeof(RefIdEditor))]
        public string? RefId {
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

                _ = UpdateInformationType(value);   // Fire and forget 
            }
        }

        private async Task UpdateInformationType(string? value) {
            RefIds.Clear();
            foreach (var e in await Handles.GetInformationsRefId(this))
                RefIds.Add(e);
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

                _ = UpdateFeatureType(value);   // Fire and forget
            }
        }

        private async Task UpdateFeatureType(string? value) {
            RefIds.Clear();
            foreach (var e in await Handles.GetFeaturesRefId(this))
                RefIds.Add(e);
        }

        public override string ToString() => string.IsNullOrEmpty(_featureType) ? "RefId" : $"{_featureType}: {RefId}";

        [Browsable(false)]
        public ObservableCollection<string> RefIds { get; set; } = new ObservableCollection<string>();

        public override string[] AssociationTypes { get; } = [];
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

        private String? _pid = string.Empty;

        public String? PID {
            get {
                return _pid;
            }

            set {
                SetValue(ref _pid, value);


            }
        }

        public InformationBindingViewModel Load(informationBinding binding) {
            _informationBindingDefintion = binding;
            _associationId = binding.associationId;
            _informationId = binding.informationId;
            _pid = binding.PID;
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

        private String? _pid = string.Empty;

        public String? PID {
            get {
                return _pid;
            }

            set {
                SetValue(ref _pid, value);
            }
        }


        public FeatureBindingViewModel Load(featureBinding binding) {
            _featureBindingDefintion = binding;
            _associationId = binding.associationId;
            _featureId = binding.featureId;
            _pid = binding.PID;
            return this;
        }

        //public abstract FeatureAssociation Save(FeatureAssociation featureAssociation, string role);
    }
}
