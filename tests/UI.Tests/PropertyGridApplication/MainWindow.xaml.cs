using S100Framework.Catalogues;
using System.DirectoryServices.ActiveDirectory;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PropertyGridApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            var feature = System.Text.Json.JsonSerializer.Deserialize<S100Framework.DomainModel.S101.FeatureTypes.LightSectored>(json)!;
            var viewmodel = new S100Framework.WPF.ViewModel.S101.LightSectoredViewModel {

            }.Load(feature);

            //TODO: this.PropertyGrid.SelectedFeatureObject = viewmodel;
        }

        const string json = "{\"categoryOfLight\":[],\"exhibitionConditionOfLight\":null,\"featureName\":[],\"fixedDateRange\":null,\"height\":11,\"interoperabilityIdentifier\":null,\"marksNavigationalSystemOf\":null,\"multiplicityOfFeatures\":null,\"periodicDateRange\":[],\"sectorCharacteristics\":[{\"lightCharacteristic\":7,\"lightSector\":[{\"colour\":[1],\"directionalCharacter\":null,\"lightVisibility\":[],\"sectorLimit\":{\"sectorLimitOne\":{\"sectorBearing\":158,\"sectorLineLength\":null},\"sectorLimitTwo\":{\"sectorBearing\":171,\"sectorLineLength\":null}},\"valueOfNominalRange\":11,\"sectorInformation\":[],\"sectorArcExtension\":null}],\"signalGroup\":[\"(1)\"],\"signalPeriod\":4,\"signalSequence\":[]},{\"lightCharacteristic\":7,\"lightSector\":[{\"colour\":[3],\"directionalCharacter\":null,\"lightVisibility\":[],\"sectorLimit\":{\"sectorLimitOne\":{\"sectorBearing\":171,\"sectorLineLength\":null},\"sectorLimitTwo\":{\"sectorBearing\":290,\"sectorLineLength\":null}},\"valueOfNominalRange\":8.5,\"sectorInformation\":[],\"sectorArcExtension\":null}],\"signalGroup\":[\"(1)\"],\"signalPeriod\":4,\"signalSequence\":[]},{\"lightCharacteristic\":7,\"lightSector\":[{\"colour\":[4],\"directionalCharacter\":null,\"lightVisibility\":[],\"sectorLimit\":{\"sectorLimitOne\":{\"sectorBearing\":110,\"sectorLineLength\":null},\"sectorLimitTwo\":{\"sectorBearing\":158,\"sectorLineLength\":null}},\"valueOfNominalRange\":8.5,\"sectorInformation\":[],\"sectorArcExtension\":null}],\"signalGroup\":[\"(1)\"],\"signalPeriod\":4,\"signalSequence\":[]}],\"signalGeneration\":null,\"status\":[],\"verticalDatum\":null,\"scaleMinimum\":179999,\"information\":[]}";
    }
}