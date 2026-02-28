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
            var featureTypeTestFeature = new TestFeature {
                featuresDetectedNested = new featuresDetectedNested {
                    featureName = [new featureName {
                        name ="Nested",
                        language="eng",
                    }],
                },

                categoryOfTemporalVariation = 1,
                dataAssessment = 1,

                featuresDetected = new featuresDetected {
                    significantFeaturesDetected = true,
                    leastDepthOfDetectedFeaturesMeasured = false,
                },
                zoneOfConfidence = [new zoneOfConfidence {
                    categoryOfZoneOfConfidenceInData = 1,
                }]
            };

            var featureTypeWreck = new Wreck {

            };

            //var selectedObject = new S100AttributeEditorViewModel(featureType, "123456");

            //var featureType = new IslandGroup {

            //};

            //var featureType = new S100FC.S128.FeatureTypes.ElectronicProduct {

            //};

            var selectedObject = new S100AttributeEditorViewModel(featureTypeWreck, "123456") {
                RequestInformation = async (s, e) => {
                    var random = new Random(DateTime.Now.Millisecond);
                    string[] result = [];
                    for (int i = 0; i < random.Next(1, 8); i++) {
                        var text = RandomString(5).ToUpperInvariant();
                        result = [.. result, text];
                    }
                    return result;
                },
                RequestFeatures = async (s, e) => {
                    var random = new Random(DateTime.Now.Millisecond);
                    string[] result = [];
                    for (int i = 0; i < random.Next(1, 8); i++) {
                        var text = RandomString(5).ToUpperInvariant();
                        result = [.. result, text];
                    }
                    return result;
                },
            };

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


            var bindings = (featureBinding[])selectedObject;

            var json2 = System.Text.Json.JsonSerializer.Serialize(bindings, jsonSerializerOptions);


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