using S100Framework.AttributeModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace S100Framework.WPF
{
    /// <summary>
    /// Interaction logic for PropertyGrid.xaml
    /// </summary>
    public partial class PropertyGrid : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged = default;

        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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

        #region Properties
        //public ObservableCollection<AttributeBinding> AttributeBindings { get; set; } = new ObservableCollection<AttributeBinding>();

        //public ObservableCollection<AttributeModel.Attribute> PropertyValues { get; set; } = new ObservableCollection<AttributeModel.Attribute>();

        //private string _title = string.Empty;

        //public string Title {
        //    get => _title;
        //    set {
        //        _title = value;
        //        OnPropertyChanged(); // Notifies the UI to update
        //    }
        //}
        #endregion

        public PropertyGrid() {
            InitializeComponent();
        }

        private static void OnSelectedObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (d is PropertyGrid grid) {
                grid._selectedObject = e.NewValue as ComplexAttributeViewModel;

                //grid.Title = grid._selectedObject!.code;

                //grid.AttributeBindings.Clear();
                //foreach (var p in grid._selectedObject!.attributeBindings)
                //    grid.AttributeBindings.Add(p);

                //grid.PropertyValues.Clear();
                //foreach (var p in grid._selectedObject!.attributeValues)
                //    grid.PropertyValues.Add(p);
            }
        }

        private ComplexAttributeViewModel? _selectedObject;
    }
}
