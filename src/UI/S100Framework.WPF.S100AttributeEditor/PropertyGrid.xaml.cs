using S100FC;
using S100Framework.WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace S100Framework.WPF
{
    /// <summary>
    /// Interaction logic for PropertyGrid.xaml
    /// </summary>
    public partial class PropertyGrid : UserControl
    {
        public ICommand CreateAttributeCommand { get; }

        public ICommand DeleteAttributeCommand { get; }

        protected void OnCreateAttributeCommand(object? parameter) {
            if (this.SelectedObject is null) return;
            if (parameter is attributeBindingDefinition attributeBinding) {
                if (this.SelectedObject.HasCapacity(attributeBinding)) {
                    var instance = attributeBinding.CreateInstance();
                    if (instance is SimpleAttribute simpleAttribute)
                        this.SelectedObject?.attributeBindings.Add(new SimpleAttributeViewModel(simpleAttribute));
                    else if (instance is ComplexAttribute complexAttribute)
                        this.SelectedObject?.attributeBindings.Add(new ComplexAttributeViewModel(complexAttribute));
                    else
                        throw new NotImplementedException();
                }
            }
        }

        protected void OnDeleteAttributeCommand(object? parameter) {
            if (parameter is ClickedBehavior.DeleteAttributeCommandEventArgs e) {
                if (e.parameter is AttributeViewModel attributeViewModel) {
                    if (e.parent is PropertyGrid propertyGrid) {
                        var index = propertyGrid.SelectedObject?.attributeBindings.IndexOf(attributeViewModel);
                        if (index >= 0) {
                            propertyGrid.SelectedObject?.attributeBindings.RemoveAt(index.Value);
                        }
                    }
                    else if (e.parent is S100AttributeEditor attributeEditor) {
                        var index = attributeEditor.SelectedObject?.attributeBindings.IndexOf(attributeViewModel);
                        if (index >= 0) {
                            attributeEditor.SelectedObject?.attributeBindings.RemoveAt(index.Value);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The object whose properties are being edited
        /// </summary>
        public static readonly DependencyProperty SelectedObjectProperty =
            DependencyProperty.Register(
                nameof(SelectedObject),
                typeof(ComplexAttributeViewModel),
                typeof(PropertyGrid),
                new PropertyMetadata(null, OnSelectedObjectChanged));

        public ComplexAttributeViewModel? SelectedObject {
            get => GetValue(SelectedObjectProperty) as ComplexAttributeViewModel;
            set => SetValue(SelectedObjectProperty, value);
        }

        public PropertyGrid() {
            InitializeComponent();

            this.CreateAttributeCommand = new RelayCommand(this.OnCreateAttributeCommand);
            this.DeleteAttributeCommand = new RelayCommand(this.OnDeleteAttributeCommand);
        }

        private static void OnSelectedObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (d is PropertyGrid grid) {
                grid._selectedObject = e.NewValue as ComplexAttributeViewModel;
            }
        }

        private ComplexAttributeViewModel? _selectedObject;
    }
}
