using S100Framework.DomainModel;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.SimpleAttributes;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.WPF;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Windows.Media.Protection.PlayReady;
using Windows.System;
using static System.Formats.Asn1.AsnWriter;

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

            var featureType = new QualityOfBathymetricData {

            };
            featureType.categoryOfTemporalVariation.value = 1;
            featureType.dataAssessment.value = 1;
            featureType.featuresDetected.significantFeaturesDetected.value = true;
            featureType.featuresDetected.leastDepthOfDetectedFeaturesMeasured.value = false;           
            featureType.zoneOfConfidence.categoryOfZoneOfConfidenceInData.value = 1;

            var selectedObject = new SelectedObject {
                code = nameof(QualityOfBathymetricData),
                attributeBindings = featureType.attributeBindings(),
                attributeValues = [.. featureType.attributes],
            };            

            this.PropertyGrid.SelectedObject = selectedObject;

            this.PropertyGrid.PropertyChanged += this.PropertyGrid_PropertyChanged;
        }

        private void PropertyGrid_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e) {

        }
    }
}