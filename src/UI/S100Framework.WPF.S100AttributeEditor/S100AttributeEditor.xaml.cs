using Microsoft.Xaml.Behaviors;
using S100Framework.AttributeModel;
using S100Framework.AttributeModel.S101.ComplexAttributes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace S100Framework.WPF
{
    public class FeatureType
    {
        public string Code { get; set; } = "UNKNOWN";

        public AttributeBinding[] attributeBindings { get; set; } = [];
    }

    public abstract class AttributeViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged = default;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private Dictionary<AttributeViewModel, string> nestedProperties = new();

        protected void SetProperty<T>(ref T backingFiled, T value, [CallerMemberName] string? propertyName = null) {
            if (string.IsNullOrWhiteSpace(propertyName)) return;

            if (EqualityComparer<T>.Default.Equals(backingFiled, value)) return;
            if (backingFiled is AttributeViewModel viewModel) {   // if old value is ViewModel, than we assume that it was subscribed, so - unsubscribe it
                viewModel.PropertyChanged -= ChildViewModelChanged;
                nestedProperties.Remove(viewModel);
            }
            if (value is AttributeViewModel valueViewModel) {
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
            if (sender is AttributeViewModel viewModel) {
                propertyName = nestedProperties[viewModel];
            }
            // Rise parent PropertyChanged with parent property name
            OnPropertyChanged(propertyName);
        }

        #endregion

        #region Properties        

        public string code { get; init; } = "UNKNOWN";

        #endregion

        public AttributeViewModel(S100Framework.AttributeModel.Attribute attribute) {
            this.code = attribute.S100FC_code;
        }
    }

    public class SimpleAttributeViewModel : AttributeViewModel
    {
        public SimpleAttributeViewModel(SimpleAttribute attribute) : base(attribute) {
            this._attribute = attribute;
        }

        public string valueType => this._attribute!.valueType;

        private object? _value;

        public object? value {
            get {
                return _value;
            }
            set {
                SetProperty(ref _value, value);
            }
        }

        public S100Framework.AttributeModel.SimpleAttribute? _attribute { get; init; } = default;
    }

    public class ComplexAttributeViewModel : AttributeViewModel
    {
        public AttributeBinding[] attributeBindings { get; init; } = [];

        public ObservableCollection<AttributeViewModel> attributeValues { get; set; } = [];

        public ComplexAttributeViewModel(ComplexAttribute attribute) : base(attribute) {
            this._attribute = attribute;

            this.attributeBindings = this._attribute.attributeBindings();
            foreach (var e in attribute.attributes) {
                if (e is SimpleAttribute simpleAttribute)
                    this.attributeValues.Add(new SimpleAttributeViewModel(simpleAttribute));
                else if (e is ComplexAttribute complexAttribute)
                    this.attributeValues.Add(new ComplexAttributeViewModel(complexAttribute));
            }
        }

        private S100Framework.AttributeModel.ComplexAttribute? _attribute = default;
    }

    public class S100AttributeEditorViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged = default;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null) {
            if (Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion        

        public S100AttributeEditorViewModel(S100Framework.AttributeModel.FeatureType feature) {
            this._feature = feature;
            this.code = this._feature.S100FC_code;
            this.attributeBindings = this._feature.attributeBindings();
            foreach (var e in this._feature.attributes)
                if (e is SimpleAttribute simpleAttribute)
                    this.attributeValues.Add(new SimpleAttributeViewModel(simpleAttribute));
                else if (e is ComplexAttribute complexAttribute)
                    this.attributeValues.Add(new ComplexAttributeViewModel(complexAttribute));
        }

        #region Properties        

        private string _code = "UNKNOWN";

        //[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
        //[Category("RecommendedTrack")]
        public string code {
            get {
                return _code;
            }
            set {
                SetProperty(ref _code, value);
            }
        }

        public ObservableCollection<AttributeViewModel> attributeValues { get; set; } = [];

        public AttributeBinding[] attributeBindings { get; init; } = [];
        #endregion

        private S100Framework.AttributeModel.FeatureType? _feature = default;
    }



    /// <summary>
    /// Interaction logic for S100AttributeEditor.xaml
    /// </summary>
    public partial class S100AttributeEditor : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged = default;

        public ICommand CreateAttributeCommand { get; }

        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected void OnCreateAttributeCommand(object? parameter) {
            if (parameter is AttributeBinding attributeBinding) {
                this.SelectedObject?.attributeValues.Add(new ComplexAttributeViewModel(new zoneOfConfidence()));
            }
        }

        /// <summary>
        /// The object whose properties are being edited
        /// </summary>
        public static readonly DependencyProperty SelectedObjectProperty =
            DependencyProperty.Register(
                nameof(SelectedObject),
                typeof(S100AttributeEditorViewModel),
                typeof(S100AttributeEditor),
                new PropertyMetadata(null, OnSelectedObjectChanged));

        public S100AttributeEditorViewModel? SelectedObject {
            get => GetValue(SelectedObjectProperty) as S100AttributeEditorViewModel;
            set => SetValue(SelectedObjectProperty, value);
        }

        public S100AttributeEditor() {
            InitializeComponent();

            this.CreateAttributeCommand = new RelayCommand(this.OnCreateAttributeCommand);
        }

        private static void OnSelectedObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (d is S100AttributeEditor grid) {
                grid._selectedObject = e.NewValue as S100AttributeEditorViewModel;
            }
        }

        private S100AttributeEditorViewModel? _selectedObject;

    }
}
