//#define S124

using S100Framework.DomainModel.S124;
using S100Framework.WPF.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow() {
            InitializeComponent();

            this.DataContext = this;
        }

        private object _selectedProperty = default;

        public object SelectedProperty {
            get => _selectedProperty;
            set => SetProperty(ref _selectedProperty, value);
        }


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

            this._propertyGrid.EditorDefinitions.Add(editorTemplateDefinition);

            var random = new Random();

            Handles.GetFeaturesRefId = (e) => {
                var featureType = e.FeatureType;
                var associationTypes = e.AssociationTypes;

                var objectid = new List<string>();
                for (int i = 0; i < random.Next(1, 8); i++) {
                    var prefix = random.Next(0, 99) switch {
                        < 30 => "P",
                        < 60 => "C",
                        _ => "S",
                    };

                    objectid.Add($"{prefix}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}");
                }
                return objectid.ToArray();
            };

            Handles.GetInformationsRefId = (e) => {
                var informationType = e.InformationType;
                var associationTypes = e.AssociationTypes;

                var objectid = new List<string>();
                for (int i = 0; i < random.Next(1, 8); i++) {
                    var prefix = "I";

                    objectid.Add($"{prefix}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}");
                }
                return objectid.ToArray();
            };


#if S124
            var viewModel = new S100Framework.WPF.ViewModel.S924.NAVWARNPartViewModel {

            };

            viewModel.Load(new S100Framework.DomainModel.S124.FeatureTypes.NAVWARNPart {
                warningInformation = new S100Framework.DomainModel.S124.ComplexAttributes.warningInformation {
                },                
            });
#elif S101
            var domainModelQualityOfBathymetricDataCustom = new S100Framework.DomainModel.S901.FeatureTypes.QualityOfBathymetricDataCustom() {
                categoryOfTemporalVariation = S100Framework.DomainModel.S101.categoryOfTemporalVariation.LikelyToChangeButSignificantShoalingNotExpected,
                dataAssessment = S100Framework.DomainModel.S101.dataAssessment.Assessed,
                featuresDetected = new S100Framework.DomainModel.S101.ComplexAttributes.featuresDetected {
                    leastDepthOfDetectedFeaturesMeasured = true,
                    significantFeaturesDetected = true,
                },
                fullSeafloorCoverageAchieved = true,
                zoneOfConfidence = new List<S100Framework.DomainModel.S101.ComplexAttributes.zoneOfConfidence> {
                    new S100Framework.DomainModel.S101.ComplexAttributes.zoneOfConfidence {
                        categoryOfZoneOfConfidenceInData = S100Framework.DomainModel.S101.categoryOfZoneOfConfidenceInData.ZoneOfConfidenceA1
                    }
                },
            };

            var domainModelUpdateInformation = new S100Framework.DomainModel.S101.FeatureTypes.UpdateInformation() {

            };


            var domainModelVesselTrafficServiceArea = new S100Framework.DomainModel.S122.FeatureTypes.VesselTrafficServiceArea() {
            };

            var domainModelElectronicProduct = new S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct() {

            };

            //var viewModel = new S100Framework.WPF.ViewModel.S901.QualityOfBathymetricDataViewModel((IViewModelHost)this) {
            //};

            //var viewModel = new S100Framework.WPF.ViewModel.S901.UpdateInformationViewModel((IViewModelHost)this) {
            //};

            //viewModel.Load(domainModelUpdateInformation);

            //var viewModel = new S100Framework.WPF.ViewModel.S922.VesselTrafficServiceAreaViewModel((IViewModelHost)this) {
            //};

            //viewModel.Load(domainModelVesselTrafficServiceArea);


            var viewModel = new S100Framework.WPF.ViewModel.S128.ElectronicProductViewModel((IViewModelHost)this) {
                //  Testing associations with attributes
            };

            viewModel.Load(domainModelElectronicProduct);
#elif S902
            var domainModel = new S100Framework.WPF.ViewModel.S902.S131_FeatureTypeTest() {

            };

            var viewModel = new S131_FeatureTypeTestViewModel() {

            };

            viewModel.Load(domainModel);
#elif S903
            var domainModel = new S100Framework.WPF.ViewModel.S903.S101_PileTest() {

            };

            var attributes = typeof(S100Framework.WPF.ViewModel.S903.S101_PileTest).GetProperty("theCollectionOfAidsToNavigationAssociationTest")!.GetCustomAttributes<FeatureTypeAttribute>();

            var viewModel = new S101_PileTestViewModel() {

            };

            viewModel.Load(domainModel);
#else
            //var viewModel = IslandAggregation.TestIslandGroup;

            var viewModel101 = new VortexConceptApplication.UpdatedInformationViewModel();




            var viewModel131 = new S100Framework.WPF.ViewModel.S131.TextAssociationViewModel();

            var viewModel = viewModel101;


            var fromJson = new S100Framework.DomainModel.FeatureAssociation {
                Code = "UpdatedInformation",
                AssociationConnectorTypeName = "AdministrationArea",
                RefIds = new[] {
                    new S100Framework.DomainModel.RefId {
                        Type = "AdministrationArea",
                        Role = "theUpdate",
                        Value = "Hello",
                    },
                    new S100Framework.DomainModel.RefId {
                        Type = "UpdateInformation",
                        Role = "theUpdatedObject",
                        Value = "World (1)",
                    },
                    new S100Framework.DomainModel.RefId {
                        Type = "UpdateInformation",
                        Role = "theUpdatedObject",
                        Value = "World (2)",
                    }
                },
            };

            viewModel.Load(fromJson);
#endif

            //this._propertyGrid.EditorDefinitions.Clear();

            //var editorTemplate = new EditorTemplateDefinition();
            //PropertyDefinition propertyDefinition = new PropertyDefinition();
            //propertyDefinition.TargetProperties.Add("navwarnTypeDetail");
            //////ed.PropertiesDefinitions.Add(pd);
            //editorTemplate.PropertyDefinitions.Add(propertyDefinition);

            //FrameworkElementFactory fac = new FrameworkElementFactory(typeof(PropertyGridEditorComboBox));
            //fac.SetBinding(PropertyGridEditorComboBox.SelectedValueProperty, new Binding("navwarnTypeDetail"));
            ////fac.SetValue(PropertyGridEditorComboBox..IncrementProperty, 10);

            //DataTemplate dt = new DataTemplate { VisualTree = fac };
            //dt.Seal();
            //editorTemplate.EditingTemplate = dt;
            //this._propertyGrid.EditorDefinitions.Add(editorTemplate);

            //var editorTemplate = new EditorTemplateDefinition();
            //PropertyDefinition propertyDefinition = new PropertyDefinition();
            //propertyDefinition.TargetProperties.Add("ReferenceId");            
            //editorTemplate.PropertyDefinitions.Add(propertyDefinition);

            //FrameworkElementFactory fac = new FrameworkElementFactory(typeof(ComboBox));
            //var bindingItemsSourceProperty = new Binding() { Source = Hello, Mode = BindingMode.OneWay };
            //fac.SetBinding(ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

            //DataTemplate dt = new DataTemplate { VisualTree = fac };
            //dt.Seal();
            //editorTemplate.EditingTemplate = dt;
            //this._propertyGrid.EditorDefinitions.Add(editorTemplate);

            //this._propertyGrid.Update();


            //var p = this._propertyGrid;

            //viewModel.PropertyChanged += (object sender, PropertyChangedEventArgs e) => {
            //    Logger.Current.Verbose("PropertyChanged = {propertyName}", e.PropertyName);
            //};

            //viewModel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
            //    ;
            //};

            SelectedProperty = viewModel;
        }

        private void _propertyGrid_PreparePropertyItem(object sender, PropertyItemEventArgs e) {
            Logger.Current.Verbose("PreparePropertyItem = {propertyName}", e.PropertyItem.Name);

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

            var v = (VortexConceptApplication.UpdatedInformationViewModel)SelectedProperty;

            var json = v.Serialize();


            System.Diagnostics.Debugger.Break();
        }
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