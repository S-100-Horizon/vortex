using ArcGIS.Core.Data;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using Xunit.Abstractions;

namespace TestNisImporter
{

    public class FeatureServiceEditing {
        private readonly ITestOutputHelper _output;

        public FeatureServiceEditing(ITestOutputHelper output) {
            this._output = output;
            ArcGIS.Core.Hosting.Host.Initialize();
        }

        [Fact]
        // This function will handle connecting to a feature service and inserting a feature
        public async void InsertFeatureToBranchVersionedService() {
            //await QueuedTask.Run(() => {
                //var url = @"https://enterprise.gst.dk/arcgisserver/rest/services/S-100/s100ed4raw/FeatureServer";
                var url = @"https://enterprise.gst.dk/arcgisserver/rest/services/S-100/s100ed4raw/FeatureServer";
            var serviceProps = new ServiceConnectionProperties(new Uri(url, UriKind.Absolute));
                serviceProps.Version = "B061450 @PROD.Test";
                var geodatabase = new Geodatabase(serviceProps);

                                

                var featureDefs = geodatabase.GetDefinitions<FeatureClassDefinition>();

                foreach (var def in featureDefs) {
                    var name = def.GetAliasName();
                }

                var fc = geodatabase.OpenDataset<FeatureClass>("RadioCallingInPoint");

            //});
        }
    }
}