using PropertyGridApplication;
using S100FC.S101;
using S100FC.S101.ComplexAttributes;
using S100FC.S101.FeatureTypes;
using S100Framework.WPF;
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
        private JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Never,
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        }.AppendTypeInfoResolver();

        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            var featureType = new TestFeature {
            };
            featureType.featuresDetectedNested = new featuresDetectedNested {
                featureName = [new featureName {
                    name ="Nested",
                    language="eng",
                }],
            };

            featureType.categoryOfTemporalVariation = 1;
            featureType.dataAssessment = 1;

            featureType.featuresDetected = new featuresDetected {
                significantFeaturesDetected = true,
                leastDepthOfDetectedFeaturesMeasured = false,
            };
            featureType.zoneOfConfidence = [new zoneOfConfidence {
                categoryOfZoneOfConfidenceInData = 1,
            }];

            var selectedObject = new S100AttributeEditorViewModel(featureType);         

            this.PropertyGrid.SelectedObject = selectedObject;

            this.PropertyGrid.PropertyChanged += this.PropertyGrid_PropertyChanged;
        }

        private void PropertyGrid_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e) {

        }
    }
}