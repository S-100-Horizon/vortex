using ArcGIS.Core.Data;
using ICSharpCode.SharpZipLib.Zip;
using S100Framework.Settings;
using System.Text.Json;
using Xunit.Abstractions;
using IO = System.IO;

namespace TestNauticalProducts
{
    public class UnitTestAnalyzer
    {
        private readonly ITestOutputHelper output;

        private static readonly JsonSerializerOptions jsonSerializerOptions = new() {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNameCaseInsensitive = true,
        };

        public UnitTestAnalyzer(ITestOutputHelper output) {
            this.output = output;

            ArcGIS.Core.Hosting.Host.Initialize();

            //FastZip fastZip = new();

            //var geodatabase = new IO.DirectoryInfo(@"s100ed7.gdb");
            //if (!geodatabase.Exists) {
            //    fastZip.ExtractZip("s100ed7.gdb.zip", geodatabase.FullName, null);
            //}
        }

        [Fact]
        public void Test_ConnectionSerialization() {
            FastZip fastZip = new();

            var geodatabase = new IO.DirectoryInfo(@"s100ed7.gdb");
            if (!geodatabase.Exists) {
                fastZip.ExtractZip("s100ed7.gdb.zip", geodatabase.FullName, null);
            }

            var connectionFile = new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(@"s100ed7.gdb")));
            using var connection = new Geodatabase(connectionFile);

            System.Diagnostics.Debugger.Break();


            
        }

        [Fact]
        public async Task Test_ProductManager() {
            FastZip fastZip = new();           

            var zipFileS101 = new IO.DirectoryInfo(@"s101.gdb");
            if (!zipFileS101.Exists) {
                fastZip.ExtractZip("s101.gdb.zip", zipFileS101.FullName, null);
            }

            var zipFileS128 = new IO.DirectoryInfo(@"s100ed7.gdb");
            if (!zipFileS128.Exists) {
                fastZip.ExtractZip("s100ed7.gdb.zip", zipFileS128.FullName, null);
            }

            var connectionFile = new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(@"s100ed7.gdb")));
            using var geodatabase = new Geodatabase(connectionFile);

            using (var table = geodatabase.OpenDataset<Table>("configuration")) {

                using var buffer = table.CreateRowBuffer();
                buffer["ps"] = "S-128";
                buffer["code"] = nameof(S100Framework.Settings.NauticalProducts);
                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(new S100Framework.Settings.NauticalProducts {
                    Connections = [new Connection("S-101", new Uri(IO.Path.GetFullPath("s101.gdb")))],
                });
                table.CreateRow(buffer).Store();
            }

            var productManager = await S100Framework.NauticalProducts.ProductManager.CreateInstanceAsync(() => {
                return geodatabase;
            });
            Assert.NotNull(productManager);


            var scheduler = TaskScheduler.Default;

            
        }
    }
}