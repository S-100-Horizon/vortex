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
        [Browsable(false)]
        public abstract InformationAssociationConnector[] associationConnectorInformations { get; }
    }

    public abstract class FeatureAssociationViewModel : AssociationViewModel
    {
        [Browsable(false)]
        public abstract FeatureAssociationConnector[] associationConnectorFeatures { get; }
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
    }

    public abstract class InformationAssociationConnector : AssociationConnector
    {
        public abstract Type InformationType { get; }
    }

    public abstract class FeatureAssociationConnector : AssociationConnector
    {
        public abstract Type FeatureType { get; }
    }

    public class InformationAssociationConnector<T> : InformationAssociationConnector where T : class
    {
        public override Type InformationType => typeof(T);

        public string DisplayName => $"{typeof(T).Name}, {base.role}";
    }

    public class FeatureAssociationConnector<T> : FeatureAssociationConnector where T : FeatureTypeBase
    {
        public override Type FeatureType => typeof(T);

        public string DisplayName => $"{typeof(T).Name}, {base.role}";
    }

    public abstract class InformationBinding
    {
        [Browsable(false)]
        public Type[] FeatureTypes { get; set; } = [];
    }

    public class InformationBindingSingle : InformationBinding
    {
        public string RefId { get; set; } = string.Empty;
    }

    public class InformationBindingOptional : InformationBinding
    {
        public string? RefId { get; set; } = default;
    }

    public class InformationBindingMulti : InformationBinding
    {
        public List<string> RefIds { get; set; } = new List<string>();
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
