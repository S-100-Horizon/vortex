using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ICSharpCode.SharpZipLib.Zip;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S101.FeatureTypes;

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
        public void Test_GetEnumValues() {
            var instance = new Landmark();

            var attribute = (EnumerationValueAttribute?)typeof(Landmark).GetProperty("natureOfConstruction")!.GetCustomAttribute(typeof(EnumerationValueAttribute));
            //attribute.PropertyValues

            var values = Enum.GetValues(typeof(S100Framework.DomainModel.S101.natureOfConstruction));

            var tt = S100Framework.Catalogues.Helper.GetValidEnumValues(instance.GetType(), "natureOfConstruction");



            System.Diagnostics.Debugger.Break();
        }
    }
}
