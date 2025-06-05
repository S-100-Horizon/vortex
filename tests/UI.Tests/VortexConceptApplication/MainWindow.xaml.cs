//#define S124

using S100Framework.DomainModel;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S124;
using S100Framework.DomainModel.S131.InformationTypes;
using S100Framework.WPF;
using S100Framework.WPF.ViewModel;
using S100Framework.WPF.ViewModel.S101;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace VortexConceptApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    //  https://github.com/RWS/Multiselect-ComboBox/tree/master/MultiSelectComboBox/MultiSelectComboBox.Example

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public static object MockValue => new();

        public event PropertyChangedEventHandler? PropertyChanged = default;

        public MainWindow() {
            InitializeComponent();

            this.DataContext = this;
        }

        private object? _selectedProperty = default;

        public object? SelectedProperty {
            get => _selectedProperty;
            set => SetProperty(ref _selectedProperty, value);
        }

        //private S100AttributeEditorViewModel? _viewModel = default;

        //public S100AttributeEditorViewModel? S100AttributeEditorViewModel {
        //    get => _viewModel;
        //    set => SetProperty(ref _viewModel, value);
        //}


        public ObservableCollection<navwarnTypeDetails> Items { get; init; } = new ObservableCollection<navwarnTypeDetails>(CodeList.navwarnTypeDetails);

        protected bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string name = "") {
            bool num = !EqualityComparer<T>.Default.Equals(backingField, value);
            if (num) {
                backingField = value;
                NotifyPropertyChanged(name);
            }

            return num;
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string name = "") {
            NotifyPropertyChanged(new PropertyChangedEventArgs(name));
        }

        protected virtual void NotifyPropertyChanged(PropertyChangedEventArgs args) {
            this.PropertyChanged?.Invoke(this, args);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            var editorTemplateDefinition = new EditorTemplateDefinition() {
            };
            //var propertyDefinition = new PropertyDefinition();
            //propertyDefinition.TargetProperties.Add("navwarnTypeDetailsCodeBehind");
            editorTemplateDefinition.TargetProperties.Add("navwarnTypeDetailsCodeBehind");
            var factory = new FrameworkElementFactory(typeof(PropertyGridEditorComboBox));
            var dataTemplate = new DataTemplate {
                VisualTree = factory,
            };
            dataTemplate.Seal();
            editorTemplateDefinition.EditingTemplate = dataTemplate;

            var random = new Random();

            //Handles.GetFeaturesRefId = (e) => {
            //    var featureType = e.FeatureType;
            //    var associationTypes = e.AssociationTypes;

            //    var objectid = new List<string>();
            //    for (int i = 0; i < random.Next(1, 8); i++) {
            //        var prefix = random.Next(0, 99) switch {
            //            < 30 => "P",
            //            < 60 => "C",
            //            _ => "S",
            //        };

            //        objectid.Add($"{prefix}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}");
            //    }
            //    return Task.FromResult(objectid.ToArray());
            //};

            //Handles.GetInformationsRefId = (e) => {
            //    var informationType = e.InformationType;
            //    var associationTypes = e.AssociationTypes;

            //    var objectid = new List<string>();
            //    for (int i = 0; i < random.Next(1, 8); i++) {
            //        var prefix = "I";

            //        objectid.Add($"{prefix}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}");
            //    }
            //    return Task.FromResult(objectid.ToArray());
            //};


            S100AttributeEditor.Host = new S100AttributeEditorControlHost {
                QueryAssociation = async (QueryAssociationsEventArgs e) => {
                    var associations = new List<AssociationId>();

                    var r = new Random(DateTime.Now.Microsecond);
                    foreach (var i in Enumerable.Range(0, r.Next(1, 8))) {
                        associations.Add(new AssociationId($"A{r.Next(1, 1000):0000}"));
                    }
                    return associations;
                },
                QueryInformationTypes = async (QueryInformationTypesEventArgs e) => {
                    var informations = new List<InformationTypeId>();

                    var r = new Random(DateTime.Now.Microsecond);
                    foreach (var i in Enumerable.Range(0, r.Next(1, 8))) {
                        informations.Add(new InformationTypeId("ContactDetails", $"P{r.Next(1, 1000):0000}"));
                    }
                    return informations;
                },
                QueryFeatureTypes = async (QueryFeatureTypesEventArgs e) => {
                    var features = new List<FeatureTypeId>();

                    var r = new Random(DateTime.Now.Microsecond);
                    foreach (var i in Enumerable.Range(0, r.Next(1, 8))) {
                        features.Add(r.Next(0, 2) switch {
                            0 => new FeatureTypeId(featureTypes[0][r.Next(0, featureTypes[0].Count() - 1)], $"P{r.Next(1, 1000):0000}"),
                            1 => new FeatureTypeId(featureTypes[1][r.Next(0, featureTypes[1].Count() - 1)], $"C{r.Next(1, 1000):0000}"),
                            2 => new FeatureTypeId(featureTypes[2][r.Next(0, featureTypes[2].Count() - 1)], $"S{r.Next(1, 1000):0000}"),
                        });
                    }
                    return features;
                },
                CreateInformationBinding = async (CreateInformationBindingEventArgs e) => {
                    return Guid.NewGuid();
                },
                DeleteInformationBinding = async (DeleteInformationBindingEventArgs e) => {
                    return true;
                },
                CreateFeatureBinding = async (CreateFeatureBindingEventArgs e) => {
                    return Guid.NewGuid();
                },
                DeleteFeatureBinding = async (DeleteFeatureBindingEventArgs e) => {
                    return true;
                }
            };

            var model = new LightAllAround() { };

            model.colour.Add(S100Framework.DomainModel.S101.colour.Red);
            model.colour.Add(S100Framework.DomainModel.S101.colour.Green);

            var viewModel = new LightAllAroundViewModel() {
                PID = "S202600",
            }.Load(model);

            //viewModel.PropertyChanged += (object sender, PropertyChangedEventArgs e) => {
            //    Logger.Current.Verbose("PropertyChanged = {propertyName}", e.PropertyName);
            //};


            SelectedProperty = viewModel;

            var selectedFeature = new SelectedFeatureTypeObjectViewModel(viewModel, model);


            selectedFeature!.PropertyChanged += (object? sender, PropertyChangedEventArgs e) => {
                System.Diagnostics.Debugger.Break();
            };

            S100AttributeEditor.SelectedFeatureObject = selectedFeature;

            Task.Run(() => {
                Thread.Sleep(2000);
                System.Windows.Application.Current.Dispatcher.Invoke(() => {
                    S100AttributeEditor.IsEditingEnabled = true;
                });
            });
        }

        private void _propertyGrid_PreparePropertyItem(object sender, PropertyItemEventArgs e) {
            //Logger.Current.Verbose("PreparePropertyItem = {propertyName}", e.PropertyItem.Name);

            var displayName = e.PropertyItem.DisplayName;

            var propertyItem = e.Item as Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem;
            if (propertyItem == null)
                return;

            if (propertyItem.PropertyType.IsInterface)  // IViewModelHost
                return;

            //propertyItem.IsExpandable = true;
            //return;

            if (!propertyItem.PropertyType.IsAbstract) {
                if (!propertyItem.PropertyType.IsValueType && propertyItem.PropertyType != typeof(string) && !propertyItem.PropertyType.IsArray && !"System.Collections.Generic".Equals(propertyItem.PropertyType.Namespace)) {
                    var attribute = propertyItem.Instance.GetType().GetProperty(displayName)!.GetCustomAttribute<S100Framework.DomainModel.CodeListAttribute>();

                    //propertyItem.IsExpandable = attribute is null ? !"System.Collections.ObjectModel".Equals(propertyItem.PropertyType.Namespace) : false;
                    if (propertyItem.Value == null) {
                        propertyItem.Value = Activator.CreateInstance(propertyItem.PropertyType);
                    }
                }
            }
        }

        private void _propertyGrid_SelectedObjectChanged(object sender, RoutedPropertyChangedEventArgs<object> e) {
            //if (sender is PropertyGrid propertyGrid) {
            //    //propertyGrid.EditorDefinitions.Clear();

            //    var editorTemplateDefinition = new EditorTemplateDefinition() {
            //        TargetProperties = new List<string>() { "RefId" },
            //        EditingTemplate = this.Resources["RefIdEditingTemplate"] as DataTemplate
            //    };

            //    propertyGrid.EditorDefinitions.Add(editorTemplateDefinition);
            //}
        }

        private void SAVE_Click(object sender, RoutedEventArgs e) {
            var v = (S100Framework.WPF.ViewModel.S101.StructureEquipmentViewModel)SelectedProperty;

            var json = v.Serialize();

            System.Diagnostics.Debugger.Break();
        }

        static Dictionary<int, string[]> featureTypes = new Dictionary<int, string[]> {
            { 0, ["LandArea", "Sounding"] },
            { 1, ["Coastline"] },
            { 2, ["LandArea", "Lake"] },
        };
    }

    public class CodeListComboEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem) {
            var comboBox = new ComboBox();

            var bindingItemsSourceProperty = new Binding("navwarnTypeDetailsList") { Source = propertyItem.Instance, Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(comboBox, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

            comboBox.DisplayMemberPath = "label";

            var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
            BindingOperations.SetBinding(comboBox, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);

            return comboBox;
        }
    }



}

namespace VortexConceptApplication
{
    using S100Framework.DomainModel.S101;
    using Xceed.Wpf.Toolkit;
    using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public partial class TestLateralBuoyViewModel
    {
        private int? _buoyShape;
        [EnumerationAttribute(nameof(buoyShapeIntList))]
        [Editor(typeof(TestEnumCheckComboEditor), typeof(TestEnumCheckComboEditor))]
        [Category("LateralBuoy")]
        public int? buoyShape {
            get {
                return _buoyShape;
            }

            set {
                _buoyShape = value;
                //SetValue(ref _buoyShape, value);
            }
        }

        [ExpandableObject]
        public ObservableCollection<Person> Persons { get; set; } = new ObservableCollection<Person>();

        [Browsable(false)]
        public int[] buoyShapeIntList => [1, 2, 3, 4, 5, 6, 7, 8];



        [Browsable(false)]
        public buoyShape[] buoyShapeList => [(buoyShape)1, (buoyShape)2, (buoyShape)3, (buoyShape)4, (buoyShape)5, (buoyShape)6, (buoyShape)7, (buoyShape)8];

    }

    public class TestEnumCheckComboEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem) {
            var checkComboBox = new CheckComboBox {
                Name = $"_checkComboBox{Guid.NewGuid():N}",
                IsEditable = false,
                IsSelectAllActive = true,
                IsDropDownOpen = false,
            };

            var attribute = (EnumerationAttribute)propertyItem.Instance.GetType().GetProperty(propertyItem.DisplayName)!.GetCustomAttributes(typeof(EnumerationAttribute), true)[0];

            var bindingItemsSourceProperty = new Binding(attribute.PropertyName) { Source = propertyItem.Instance, Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(checkComboBox, CheckComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

            var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
            BindingOperations.SetBinding(checkComboBox, CheckComboBox.SelectedItemProperty, bindingSelectedItemProperty);

            return checkComboBox;
        }
    }
}