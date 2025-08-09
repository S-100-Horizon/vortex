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
        public async Task Test_ProductManager() {
            var settings = new S100Framework.Settings.NauticalProducts {
                ConnectionFile = "",
            };

            var productManager = await S100Framework.NauticalProducts.ProductManager.CreateInstanceAsync(settings);
            Assert.NotNull(productManager);


        }
    }
}