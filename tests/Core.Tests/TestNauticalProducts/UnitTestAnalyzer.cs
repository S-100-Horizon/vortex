using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using S100Framework.DomainModel.S128;
using S100Framework.Settings;
using System.Diagnostics;
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
        public async Task Test_ProductManagerCreation() {
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
                table.CreateRow(buffer);
            }

            var productManager = await S100Framework.NauticalProducts.ProductManager.CreateInstanceAsync(() => {
                return new Geodatabase(connectionFile);
            });
            Assert.NotNull(productManager);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public async Task Test_LoadElectronicProducts() {
            var s57 = Environment.GetEnvironmentVariable("S100-Horizon-S57-Database");
            Assert.False(string.IsNullOrEmpty(s57));

            FastZip fastZip = new();

            var zipFileS128 = new IO.DirectoryInfo(@"s128ed7.gdb");

            if (zipFileS128.Exists) {
                zipFileS128.Delete(true);
            }
            fastZip.ExtractZip("s100ed7.gdb.zip", zipFileS128.FullName, null);

            var productManager = await S100Framework.NauticalProducts.ProductManager.CreateInstanceAsync(() => {
                var connectionFile = new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(@"s128ed7.gdb")));

                var geodatabase = new Geodatabase(connectionFile);

                using (var table = geodatabase.OpenDataset<Table>("configuration")) {

                    using var buffer = table.CreateRowBuffer();
                    buffer["ps"] = "S-128";
                    buffer["code"] = nameof(S100Framework.Settings.NauticalProducts);
                    buffer["json"] = System.Text.Json.JsonSerializer.Serialize(new S100Framework.Settings.NauticalProducts {
                        Connections = [new Connection("S-101", new Uri(IO.Path.GetFullPath(Environment.GetEnvironmentVariable("S100-Horizon-S101-Database")!)))],
                    });
                    table.CreateRow(buffer);                   
                }

                return geodatabase;
            });
            Assert.NotNull(productManager);

            //  S-57 ProductDefinitions
            await productManager.Dispatch(() => {
                var connectionFile = new Uri(IO.Path.GetFullPath(s57));

                Func<Geodatabase> createGeodatabase = () => { throw new NotImplementedException(); };

                if (IO.File.Exists(s57) && ".sde".Equals(IO.Path.GetExtension(s57), StringComparison.InvariantCultureIgnoreCase)) {
                    createGeodatabase = () => { return new Geodatabase(new DatabaseConnectionFile(connectionFile)); };
                }
                else if (IO.Directory.Exists(s57) && ".gdb".Equals(IO.Path.GetExtension(s57), StringComparison.InvariantCultureIgnoreCase)) {
                    createGeodatabase = () => { return new Geodatabase(new FileGeodatabaseConnectionPath(connectionFile)); };
                }

                var tasks = new List<Task>();

                using var geodatabase = createGeodatabase();

                var definitionTables = geodatabase.GetDefinitions<TableDefinition>();
                var definitionFeatureClasses = geodatabase.GetDefinitions<FeatureClassDefinition>();

                using var tableProductCoverage = geodatabase.OpenDataset<FeatureClass>(definitionFeatureClasses.Single(e => e.GetName().EndsWith("ProductCoverage")).GetName());

                using (var tableProductDefinitions = geodatabase.OpenDataset<Table>(definitionTables.Single(e => e.GetName().EndsWith("ProductDefinitions")).GetName())) {
                    using var cursor = tableProductDefinitions.Search(new QueryFilter {
                        WhereClause = "upper(ExportType) <> 'CANCEL'",
                    }, true);

                    while (cursor.MoveNext()) {
                        var c = cursor.Current;

                        var series = Convert.ToString(c["series"])!.ToString();

                        var name = "101DK00" + Convert.ToString(c["DSNM"])!.Substring(2);
                        var specificUsage = name[7] switch {
                            '5' => S100Framework.DomainModel.S128.specificUsage.NavigationalPurposeHarbour,
                            '4' => S100Framework.DomainModel.S128.specificUsage.NavigationalPurposeApproach,
                            '3' => S100Framework.DomainModel.S128.specificUsage.NavigationalPurposeCoastal,
                            '2' => S100Framework.DomainModel.S128.specificUsage.NavigationalPurposeGeneral,
                            '1' => S100Framework.DomainModel.S128.specificUsage.NavigationalPurposeOverview,
                            _ => throw new InvalidDataException(),
                        };

                        using var coverage = tableProductCoverage.Search(new QueryFilter {
                            WhereClause = $"DSNM = '{Convert.ToString(c["DSNM"])}'",
                        }, true);

                        var polygons = new List<ArcGIS.Core.Geometry.Polygon>();
                        while (coverage.MoveNext()) {
                            var current = (Feature)coverage.Current;
                            var polygon = (ArcGIS.Core.Geometry.Polygon)current.GetShape();

                            polygons.Add(polygon);
                            continue;
                        }
                        Debug.Assert(polygons.Any());

                        var cover = (ArcGIS.Core.Geometry.Polygon)GeometryEngine.Instance.Union(polygons);

                        tasks.Add(productManager.ElectronicProductManager.CreateElectronicProductAsync(name, specificUsage, cover));
                    }

                    Task.WaitAll([.. tasks]);
                }
            });
        }

        [Fact]
        public async Task Test_Export() {
            var s101 = Environment.GetEnvironmentVariable("S100-Horizon-S101-Database");
            Assert.False(string.IsNullOrEmpty(s101));

            FastZip fastZip = new();

            var zipFileS128 = new IO.DirectoryInfo(@"s128ed7.gdb");

            if (zipFileS128.Exists) {
                zipFileS128.Delete(true);
            }
            fastZip.ExtractZip("s128ed7.gdb.zip", zipFileS128.FullName, null);

            var productManager = await S100Framework.NauticalProducts.ProductManager.CreateInstanceAsync(() => {
                var connectionFile = new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(@"s128ed7.gdb")));

                return new Geodatabase(connectionFile);
            });
            Assert.NotNull(productManager);

            await productManager.ElectronicProductManager.CreateNewEditionAsync("S-101", "101DK0040347E");
        }
    }
}