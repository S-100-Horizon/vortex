using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S124;
using S100Framework.DomainModel.S901.FeatureTypes;
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
        public static object MockValue => new object();

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

            //this._propertyGrid.EditorDefinitions.Add(new edit)

#if S124
            var viewModel = new S100Framework.WPF.ViewModel.S924.NAVWARNPartViewModel {

            };

            viewModel.Load(new S100Framework.DomainModel.S124.FeatureTypes.NAVWARNPart {
                warningInformation = new S100Framework.DomainModel.S124.ComplexAttributes.warningInformation {
                },                
            });
#endif
            var domailModel = new S100Framework.DomainModel.S901.FeatureTypes.QualityOfBathymetricDataCustom() {
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

            var viewModel = new S100Framework.WPF.ViewModel.S901.QualityOfBathymetricDataViewModel {                
            };

            viewModel.Load(domailModel);

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


            //var p = this._propertyGrid;

            viewModel.PropertyChanged += (object sender, PropertyChangedEventArgs e) => {
                Logger.Current.Verbose("PropertyChanged = {propertyName}", e.PropertyName);
            };

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

            if (!propertyItem.PropertyType.IsValueType && propertyItem.PropertyType != typeof(string) && !propertyItem.PropertyType.IsArray && !"System.Collections.Generic".Equals(propertyItem.PropertyType.Namespace)) {


                var attribute = propertyItem.Instance.GetType().GetProperty(displayName)!.GetCustomAttribute<S100Framework.DomainModel.CodeListAttribute>();

                //propertyItem.IsExpandable = attribute is null ? !"System.Collections.ObjectModel".Equals(propertyItem.PropertyType.Namespace) : false;
                if (propertyItem.Value == null) {
                    propertyItem.Value = Activator.CreateInstance(propertyItem.PropertyType);
                }
            }
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