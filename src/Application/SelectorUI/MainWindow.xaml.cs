using PropertyGridApplication;
using S100Framework.AttributeModel.S101;
using S100Framework.AttributeModel.S101.FeatureTypes;
using S100Framework.WPF;
using System.Text.Json;
using System.Windows;

namespace SelectorUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Never,
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        }.AppendTypeInfoResolver();

        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            //var viewModel = new CustomViewModel() {
            //    buoyShape = buoyShape.Barrel,
            //    MyValue = 123,
            //};
            //viewModel.colour.Add((colour)3);
            //viewModel.featureName.Add(new S100Framework.WPF.ViewModel.S101.featureNameViewModel {
            //    language = "eng",
            //    name = "Hello World",
            //    nameUsage = nameUsage.DefaultNameDisplay,
            //});

            var featureType = new TestFeature {

            };
            featureType.featuresDetectedNested.featureName.name = "Nested";
            featureType.featuresDetectedNested.featureName.language = "eng";

            featureType.categoryOfTemporalVariation = 1;
            featureType.dataAssessment = 1;
            featureType.featuresDetected.significantFeaturesDetected = true;
            featureType.featuresDetected.leastDepthOfDetectedFeaturesMeasured = false;
            featureType.zoneOfConfidence.categoryOfZoneOfConfidenceInData = 1;

            var selectedObject = new S100AttributeEditorViewModel(featureType);

            //var selectedObject = new SelectedObject {
            //    code = featureType.S100FC_name,
            //    attributeBindings = featureType.attributeBindings(),
            //    attributeValues = [.. featureType.attributes],
            //};            

            this.PropertyGrid.SelectedObject = selectedObject;

            this.PropertyGrid.PropertyChanged += this.PropertyGrid_PropertyChanged;
        }

        private void PropertyGrid_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e) {

        }
    }
}