using Microsoft.Xaml.Behaviors;
using S100FC;
using S100FC.S101.ComplexAttributes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace S100Framework.WPF.ViewModel
{
    public class S100AttributeEditorViewModel : INotifyPropertyChanged {
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

        public S100AttributeEditorViewModel(S100FC.FeatureType feature, string uid) {
            this._feature = feature;
            this._uid = uid;
            this.code = this._feature.S100FC_code;
            this.attributeBindings = this._feature.attributeBindingsCatalogue;
            foreach (var e in this._feature.attributeBindings)
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

        public attributeBindingDefinition[] attributeBindings { get; init; } = [];
        #endregion

        private S100FC.FeatureType? _feature = default;
        private string _uid;
    }
}

namespace S100Framework.WPF
{
    using S100Framework.WPF.ViewModel;

    /// <summary>
    /// Interaction logic for S100AttributeEditor.xaml
    /// </summary>
    public partial class S100AttributeEditor : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged = default;

        public ICommand CreateAttributeCommand { get; }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected void OnCreateAttributeCommand(object? parameter) {
            if (parameter is attributeBindingDefinition attributeBinding) {
                var instance = attributeBinding.CreateInstance();
                if (instance is SimpleAttribute simpleAttribute)
                    this.SelectedObject?.attributeValues.Add(new SimpleAttributeViewModel(simpleAttribute));
                else if (instance is ComplexAttribute complexAttribute)
                    this.SelectedObject?.attributeValues.Add(new ComplexAttributeViewModel(complexAttribute));
                else
                    throw new NotImplementedException();
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
