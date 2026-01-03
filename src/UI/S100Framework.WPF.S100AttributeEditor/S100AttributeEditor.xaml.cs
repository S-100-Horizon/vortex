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

    public class SelectedObject
    {
        //public FeatureType? Instance { get; init; }
        public string code { get; set; } = "UNKNOWN";

        public AttributeBinding[] attributeBindings { get; set; } = [];

        public Collection<AttributeModel.Attribute> attributeValues { get; set; } = [];
    }

    public class SelectedType
    {
        private XElement _element { get; set; }

        public XElement XElement {
            get { return _element; }
            set {
                if (_element != value) {
                    _element = value;


                    //foreach (var attributeBinding in e.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {

                    //}
                }
            }
        }
    }

    /// <summary>
    /// Interaction logic for PropertyGrid.xaml
    /// </summary>
    public partial class S100AttributeEditor : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged = default;

        public ICommand CreateAttributeCommand { get; }

        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected void OnCreateAttributeCommand(object? parameter) {            
            if(parameter is AttributeBinding attributeBinding) {
                this.SelectedObject?.attributeValues.Add(new featureName());
            }
        }

        /// <summary>
        /// The object whose properties are being edited
        /// </summary>
        public static readonly DependencyProperty SelectedObjectProperty =
            DependencyProperty.Register(
                nameof(SelectedObject),
                typeof(SelectedObject),
                typeof(S100AttributeEditor),
                new PropertyMetadata(null, OnSelectedObjectChanged));

        public SelectedObject? SelectedObject {
            get => GetValue(SelectedObjectProperty) as SelectedObject;
            set => SetValue(SelectedObjectProperty, value);
        }

        #region Properties
        public ObservableCollection<AttributeBinding> AttributeBindings { get; set; } = new ObservableCollection<AttributeBinding>();

        public ObservableCollection<AttributeModel.Attribute> PropertyValues { get; set; } = new ObservableCollection<AttributeModel.Attribute>();

        private string _title = string.Empty;

        public string Title {
            get => _title;
            set {
                _title = value;
                OnPropertyChanged(); // Notifies the UI to update
            }
        }
        #endregion



        public S100AttributeEditor() {
            InitializeComponent();

            this.CreateAttributeCommand = new RelayCommand(this.OnCreateAttributeCommand);
        }

        private static void OnSelectedObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (d is S100AttributeEditor grid) {
                grid._selectedObject = e.NewValue as SelectedObject;

                grid.Title = grid._selectedObject!.code;

                grid.AttributeBindings.Clear();
                foreach (var p in grid._selectedObject!.attributeBindings)
                    grid.AttributeBindings.Add(p);

                grid.PropertyValues.Clear();
                foreach (var p in grid._selectedObject!.attributeValues)
                    grid.PropertyValues.Add(p);
            }
        }

        private SelectedObject? _selectedObject;

    }
}
