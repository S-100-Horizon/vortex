using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ICSharpCode.SharpZipLib.Zip;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S101.FeatureTypes;
using System.Text.Json;

using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using WinRT;
using Xunit.Abstractions;
namespace TestS100Framework
{
    public class UnitTestFramework
    {
        private readonly ITestOutputHelper _output;

        public UnitTestFramework(ITestOutputHelper output) {
            this._output = output;

            ArcGIS.Core.Hosting.Host.Initialize();
        }

        [Fact]
        public void Test_ModelNames() {
            using Geodatabase geodatabase = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(@".\..\..\..\..\..\..\artifacts\Workspaces\s100ed8.gdb")));

            var definitions = geodatabase.GetDefinitions<FeatureClassDefinition>();
            foreach(var d in definitions) {
                using var fc = geodatabase.OpenDataset<FeatureClass>(d.GetName());
            }
        }

        [Fact]
        public void Test_GetEnumValues() {
            var instance = new Landmark();

            var attribute = (EnumerationValueAttribute?)typeof(Landmark).GetProperty("natureOfConstruction")!.GetCustomAttribute(typeof(EnumerationValueAttribute));
            //attribute.PropertyValues

            var values = Enum.GetValues(typeof(S100Framework.DomainModel.S101.natureOfConstruction));

            var tt = S100Framework.Catalogues.Helper.GetValidEnumValues(instance.GetType(), "natureOfConstruction");



            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_AttributeRules() {
            FastZip fastZip = new();

            var output = new DirectoryInfo("s100ed8.gdb");

            if (output.Exists)
                output.Delete(true);

            fastZip.ExtractZip("s100ed8.gdb.zip", output.FullName, null);

            using Geodatabase geodatabase = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(output.FullName)));

            using var points = geodatabase.OpenDataset<FeatureClass>("point");

            using var buffer = points.CreateRowBuffer();

            using var cursor = points.CreateInsertCursor();

            buffer["ps"] = "S-XXX";
            buffer["code"] = "test";
            
            var id = cursor.Insert(buffer);
            
            cursor.Flush();            

            System.Diagnostics.Debugger.Break();

        }
    }
}
