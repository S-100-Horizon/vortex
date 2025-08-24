using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ICSharpCode.SharpZipLib.Zip;
using S100Framework.YAML;
using System.Diagnostics;
using System.Text.Json;
using Xunit.Abstractions;
using IO = System.IO;

namespace TestProductCatalogue
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

            //var geodatabase = new IO.DirectoryInfo(@"s100ed8.gdb");
            //if (!geodatabase.Exists) {
            //    fastZip.ExtractZip("s100ed8.gdb.zip", geodatabase.FullName, null);
            //}
        }

        [Fact]
        public void Test_ConnectionSerialization() {
            FastZip fastZip = new();

            var geodatabase = new IO.DirectoryInfo(@"s100ed8.gdb");
            if (!geodatabase.Exists) {
                fastZip.ExtractZip("s100ed8.gdb.zip", geodatabase.FullName, null);
            }

            var connectionFile = new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(@"s100ed8.gdb")));
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

            var zipFileS128 = new IO.DirectoryInfo(@"s100ed8.gdb");
            if (!zipFileS128.Exists) {
                fastZip.ExtractZip("s100ed8.gdb.zip", zipFileS128.FullName, null);
            }

            var connectionFile = new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(@"s100ed8.gdb")));
            using var geodatabase = new Geodatabase(connectionFile);

            using (var table = geodatabase.OpenDataset<Table>("configuration")) {

                using var buffer = table.CreateRowBuffer();
                buffer["ps"] = "S-128.Horizon";
                buffer["code"] = nameof(S100Horizon.Settings.ProductCatalogue);
                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(new S100Horizon.Settings.ProductCatalogue {
                    Connections = [new S100Horizon.Settings.Connection("S-101", new Uri(IO.Path.GetFullPath("s101.gdb")))],
                });
                table.CreateRow(buffer);
            }

            var productManager = await S100Framework.ProductCatalogue.ProductManager.CreateInstanceAsync(() => {
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

            var zipFileS128 = new IO.DirectoryInfo(@"s128ed8.gdb");

            if (zipFileS128.Exists) {
                zipFileS128.Delete(true);
            }
            fastZip.ExtractZip("s100ed8.gdb.zip", zipFileS128.FullName, null);

            var productManager = await S100Framework.ProductCatalogue.ProductManager.CreateInstanceAsync(() => {
                var connectionFile = new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(@"s128ed8.gdb")));

                var geodatabase = new Geodatabase(connectionFile);

                using (var table = geodatabase.OpenDataset<Table>("configuration")) {

                    using var buffer = table.CreateRowBuffer();
                    buffer["ps"] = "S-128.Horizon";
                    buffer["code"] = nameof(S100Horizon.Settings.ProductCatalogue);
                    buffer["json"] = System.Text.Json.JsonSerializer.Serialize(new S100Horizon.Settings.ProductCatalogue {
                        Connections = [new S100Horizon.Settings.Connection("S-101", new Uri(IO.Path.GetFullPath(Environment.GetEnvironmentVariable("S100-Horizon-S101-Database")!)))],
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

                var productSpecification = new S100Framework.DomainModel.S128.ComplexAttributes.productSpecification {
                    editionDate = S100Framework.DomainModel.S101.Summary.VersionDate,
                    name = S100Framework.DomainModel.S101.Summary.ProductId,
                    version = S100Framework.DomainModel.S101.Summary.Version.ToString(),
                };

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
                            var current = (ArcGIS.Core.Data.Feature)coverage.Current;
                            var polygon = (ArcGIS.Core.Geometry.Polygon)current.GetShape();

                            polygons.Add(polygon);
                            continue;
                        }
                        Debug.Assert(polygons.Any());

                        var cover = (ArcGIS.Core.Geometry.Polygon)GeometryEngine.Instance.Union(polygons);

                        tasks.Add(productManager.ElectronicProductManager.CreateElectronicProductAsync(name, productSpecification, specificUsage, cover));
                    }

                    Task.WaitAll([.. tasks]);
                }
            });
        }

        [Fact]
        public async Task Test_Export() {
            //var s101 = Environment.GetEnvironmentVariable("S100-Horizon-S101-Database");
            //Assert.False(string.IsNullOrEmpty(s101));

            FastZip fastZip = new();

            var zipFileS128 = new IO.DirectoryInfo(@"s128ed8.gdb");

            if (zipFileS128.Exists) {
                zipFileS128.Delete(true);
            }
            fastZip.ExtractZip("s128ed8.gdb.zip", zipFileS128.FullName, null);

            var productManager = await S100Framework.ProductCatalogue.ProductManager.CreateInstanceAsync(() => {
                var connectionFile = new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(@"s128ed8.gdb")));

                return new Geodatabase(connectionFile);
            });
            Assert.NotNull(productManager);



            var dataset = await productManager.ElectronicProductManager.CreateNewEditionAsync("101DK0040349E");

            var yaml = dataset.Serialize();

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public async Task Test_FullExport() {
            var s101 = Environment.GetEnvironmentVariable("S100-Horizon-S101-Database");
            Assert.False(string.IsNullOrEmpty(s101));

            s101 = @"g:\vortex\connections\s100ed8.sde";

            Func<Geodatabase> createGeodatabase = () => { throw new NotImplementedException(); };

            if (IO.File.Exists(s101) && ".sde".Equals(IO.Path.GetExtension(s101), StringComparison.InvariantCultureIgnoreCase)) {
                createGeodatabase = () => { return new Geodatabase(new DatabaseConnectionFile(new Uri(IO.Path.GetFullPath(s101)))); };
            }
            else if (IO.Directory.Exists(s101) && ".gdb".Equals(IO.Path.GetExtension(s101), StringComparison.InvariantCultureIgnoreCase)) {
                createGeodatabase = () => { return new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(s101)))); };
            }
            else
                throw new System.ArgumentOutOfRangeException(nameof(s101));

            var tt = new S100Horizon.Settings.ProductCatalogue {
                Connections = [new S100Horizon.Settings.Connection(S100Framework.DomainModel.S101.Summary.ProductId)],
            };
            var json = System.Text.Json.JsonSerializer.Serialize(tt);

            var productManager = await S100Framework.ProductCatalogue.ProductManager.CreateInstanceAsync(() => {
                return createGeodatabase();
            });
            Assert.NotNull(productManager);

            var productNames = productManager.ElectronicProductManager.ToArray();

            foreach (var name in productNames) {
                var product = productManager.ElectronicProductManager.ElectronicProduct(name);

                S100Framework.YAML.Dataset dataset;
                if (product.editionNumber == 1 && product.updateNumber == 0)
                    dataset = await productManager.ElectronicProductManager.CreateNewDatasetAsync(name);
                else
                    dataset = await productManager.ElectronicProductManager.ReissueAsync(name);
            }

            System.Diagnostics.Debugger.Break();
        }
    }
}