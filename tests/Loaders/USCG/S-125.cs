using Xunit.Abstractions;
using ArcGIS.Core.Hosting;
using NetTopologySuite.Features;
using NetTopologySuite.IO;

namespace USCG
{
    public class S125
    {
        private readonly ITestOutputHelper _output;

        private readonly string _iho;
        private readonly string _iala;

        public S125(ITestOutputHelper output) {
            this._output = output;

            this._iho = Environment.GetEnvironmentVariable("GITHUB-IHO")!;
            this._iala = Environment.GetEnvironmentVariable("GITHUB-IALA")!;

            Host.Initialize();
        }

        [Fact]
        public void Test1() {
            var features = LoadGeoJson("discFedAid_1.geojson");

            System.Diagnostics.Debugger.Break();
        }

        public FeatureCollection LoadGeoJson(string filePath) {
            string json = File.ReadAllText(filePath);
            var reader = new GeoJsonReader();

            // This creates a collection of NTS Features (Geometry + Attributes)
            var featureCollection = reader.Read<FeatureCollection>(json);

            return featureCollection;
        }
    }
}