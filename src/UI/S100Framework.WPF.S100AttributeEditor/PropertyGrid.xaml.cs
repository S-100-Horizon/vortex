using System.Windows;
using System.Windows.Controls;

namespace S100Framework.WPF
{
    /// <summary>
    /// Interaction logic for PropertyGrid.xaml
    /// </summary>
    public partial class PropertyGrid : UserControl
    {
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
        }

        private static void OnSelectedObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (d is PropertyGrid grid) {
                grid._selectedObject = e.NewValue as ComplexAttributeViewModel;
            }
        }

        private ComplexAttributeViewModel? _selectedObject;
    }
}
