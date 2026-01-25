using PropertyGridApplication;
using S100FC;
using S100FC.S101;
using S100FC.S101.ComplexAttributes;
using S100FC.S101.FeatureAssociation;
using S100FC.S101.FeatureTypes;
using S100FC.S101.InformationAssociation;
using S100Framework.WPF.ViewModel;
using System.Text.Json;
using System.Windows;

namespace SelectorUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Never,
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        }.AppendTypeInfoResolver();

        public MainWindow() {
            this.InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            //var featureType = new TestFeature {
            //    featuresDetectedNested = new featuresDetectedNested {
            //        featureName = [new featureName {
            //            name ="Nested",
            //            language="eng",
            //        }],
            //    },

            //    categoryOfTemporalVariation = 1,
            //    dataAssessment = 1,

            //    featuresDetected = new featuresDetected {
            //        significantFeaturesDetected = true,
            //        leastDepthOfDetectedFeaturesMeasured = false,
            //    },
            //    zoneOfConfidence = [new zoneOfConfidence {
            //        categoryOfZoneOfConfidenceInData = 1,
            //    }]
            //};

            //var selectedObject = new S100AttributeEditorViewModel(featureType, "123456");

            //selectedObject += new informationBinding<QualityOfBathymetricDataComposition> {
            //    roleType = "association",
            //    role = "theQualityInformation",
            //    informationType = "SpatialQuality",
            //    informationId = RandomString(5),
            //};

            //selectedObject += new featureBinding<UpdatedInformation> {
            //    roleType = "association",
            //    role = "theUpdate",
            //    featureType = "UpdateInformation",
            //    featureId = RandomString(5),
            //};

            var featureType = new IslandGroup {

            };

            var selectedObject = new S100AttributeEditorViewModel(featureType, "123456");

            selectedObject.PropertyChanged += this.PropertyGrid_PropertyChanged;

            this.PropertyGrid.SelectedObject = selectedObject;

            this.PropertyGrid.PropertyChanged += this.PropertyGrid_PropertyChanged;
        }

        private void PropertyGrid_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e) {

        }

        private static readonly char[] _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

        public static string RandomString(int length) { var result = new char[length]; var rng = Random.Shared; for (int i = 0; i < length; i++) result[i] = _chars[rng.Next(_chars.Length)]; return new string(result); }
    }
}