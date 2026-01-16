using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ICSharpCode.SharpZipLib.Zip;
using S100FC.YAML;
using Serilog;
using System.Diagnostics;
using System.Text.Json;
using Xunit.Abstractions;
using static System.Runtime.InteropServices.JavaScript.JSType;
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

            var productManager = await S100FC.ProductCatalogue.ProductManager.CreateInstanceAsync(() => {
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

            var productManager = await S100FC.ProductCatalogue.ProductManager.CreateInstanceAsync(() => {
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

            var tasks = new List<Task>();

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

                var productSpecification = new S100FC.S128.ComplexAttributes.productSpecification {
                    editionDate = S100FC.S101.Summary.VersionDate,
                    name = S100FC.S101.Summary.ProductId,
                    version = S100FC.S101.Summary.Version.ToString(),
                };

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
                            '5' => 5, // NavigationalPurposeHarbour,
                            '4' => 4, // NavigationalPurposeApproach,
                            '3' => 3, // NavigationalPurposeCoastal,
                            '2' => 2, // NavigationalPurposeGeneral,
                            '1' => 1, // NavigationalPurposeOverview,
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
                }
            });

            await Task.WhenAll([.. tasks]);
        }

        [Fact]
        public async Task Test_LoadElectronicProducts2() {
            var s57 = Environment.GetEnvironmentVariable("S100-Horizon-S57-Database");
            Assert.False(string.IsNullOrEmpty(s57));

            FastZip fastZip = new();

            var zipFileS100ed9 = new IO.DirectoryInfo(@"s100ed9.gdb");

            if (zipFileS100ed9.Exists) {
                zipFileS100ed9.Delete(true);
            }


            fastZip.ExtractZip(Path.Combine(AppContext.BaseDirectory, "s100ed9.gdb.zip"), zipFileS100ed9.FullName, null);

            var productManager = await S100FC.ProductCatalogue.ProductManager.CreateInstanceAsync(() => {
                var connectionFile = new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(@"s100ed9.gdb")));

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

            var tasks = new List<Task>();

            //  S-57 ProductDefinitions
            await productManager.Dispatch(async () => {
                var connectionFile = new Uri(IO.Path.GetFullPath(s57));

                Func<Geodatabase> createGeodatabase = () => { throw new NotImplementedException(); };

                if (IO.File.Exists(s57) && ".sde".Equals(IO.Path.GetExtension(s57), StringComparison.InvariantCultureIgnoreCase)) {
                    createGeodatabase = () => { return new Geodatabase(new DatabaseConnectionFile(connectionFile)); };
                }
                else if (IO.Directory.Exists(s57) && ".gdb".Equals(IO.Path.GetExtension(s57), StringComparison.InvariantCultureIgnoreCase)) {
                    createGeodatabase = () => { return new Geodatabase(new FileGeodatabaseConnectionPath(connectionFile)); };
                }

                var productSpecification = new S100FC.S128.ComplexAttributes.productSpecification {
                    editionDate = S100FC.S101.Summary.VersionDate,
                    name = S100FC.S101.Summary.ProductId,
                    version = S100FC.S101.Summary.Version.ToString(),
                };



                using var geodatabase = createGeodatabase();

                var definitionTables = geodatabase.GetDefinitions<TableDefinition>();
                var definitionFeatureClasses = geodatabase.GetDefinitions<FeatureClassDefinition>();

                using var tableProductCoverage = geodatabase.OpenDataset<FeatureClass>(definitionFeatureClasses.Single(e => e.GetName().EndsWith("ProductCoverage")).GetName());

                using (var tableProductDefinitions = geodatabase.OpenDataset<Table>(definitionTables.Single(e => e.GetName().EndsWith("ProductDefinitions")).GetName())) {
                    using var cursor = tableProductDefinitions.Search(new QueryFilter {
                        //WhereClause = "upper(ExportType) <> 'CANCEL'",
                        WhereClause = "1 = 1",
                    }, true);

                    while (cursor.MoveNext()) {
                        var c = cursor.Current;

                        var series = Convert.ToString(c["series"])!.ToString();

                        var name = "101DK00" + Convert.ToString(c["DSNM"])!.Substring(2);
                        var specificUsage = name[7] switch {
                            '5' => 5, // NavigationalPurposeHarbour,
                            '4' => 4, // NavigationalPurposeApproach,
                            '3' => 3, // NavigationalPurposeCoastal,
                            '2' => 2, // NavigationalPurposeGeneral,
                            '1' => 1, // NavigationalPurposeOverview,
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

                        // todo: kald med s57
                        tasks.Add(productManager.ElectronicProductManager.CreateElectronicProductAsync(name, productSpecification, specificUsage, cover));
                    }
                }
            });

            await Task.WhenAll([.. tasks]);

            // 101DK0040349E

            var p = productManager.ElectronicProductManager.ElectronicProduct("101DK0040349E");
            await productManager.ElectronicProductManager.CreateNewEditionAsync("101DK0040349E");

            System.Diagnostics.Debugger.Break();
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

            var productManager = await S100FC.ProductCatalogue.ProductManager.CreateInstanceAsync(() => {
                var connectionFile = new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(@"s128ed8.gdb")));

                return new Geodatabase(connectionFile);
            });
            Assert.NotNull(productManager);



            var dataset = await productManager.ElectronicProductManager.CreateNewEditionAsync("101DK0040349E");

            var yaml = dataset.Serialize();

            System.Diagnostics.Debugger.Break();
        }


        [Fact]
        public void Test_BuildExchangeset() {
            var output = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string datasetName = "101DK0040349E";
            var edition = 1;


            var commandline = $"-f \"{IO.Path.Combine(output, $"{datasetName}.yaml")}\" -c \"{@$"{output}\101_Feature_Catalogue_2.0.0.xml"}\" -d \"{IO.Path.Combine(output, datasetName)}\"";

            // todo: figure out arguments

            Log.Information("s100compiler.exe -f {dataset}.yaml -d {dataset} -C {dataset} -c 101_Feature_Catalogue_2.0.0.xml", datasetName);
            commandline += $" -C {datasetName}";

            var p = new Process();
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = @"C:\Program Files\s100compiler\s100compiler.exe";
            p.StartInfo.Arguments = commandline;
            p.StartInfo.WorkingDirectory = output;
            p.EnableRaisingEvents = true;
            p.Exited += (s, e) => {
            };

            p.Start();
            p.WaitForExit();

            if (p.ExitCode != 0) {
                Log.Error("\"{filename}\" {arguments}", p.StartInfo.FileName, commandline);
                throw new ArgumentException(commandline);
            }
        }

        [Fact]
        public async Task Test_FullExport() {
            var s101 = Environment.GetEnvironmentVariable("S100-Horizon-S101-Database");
            Assert.False(string.IsNullOrEmpty(s101));

            //s101 = @"g:\vortex\connections\s100ed8.sde";

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
                Connections = [new S100Horizon.Settings.Connection(S100FC.S101.Summary.ProductId)],
            };
            var json = System.Text.Json.JsonSerializer.Serialize(tt);

            var productManager = await S100FC.ProductCatalogue.ProductManager.CreateInstanceAsync(() => {
                return createGeodatabase();
            });
            Assert.NotNull(productManager);

            var productNames = productManager.ElectronicProductManager.ToArray();

            foreach (var name in productNames) {
                var product = productManager.ElectronicProductManager.ElectronicProduct(name);

                S100FC.YAML.Dataset dataset;
                if (product.editionNumber == 1 && product.updateNumber == 0)
                    dataset = await productManager.ElectronicProductManager.CreateNewDatasetAsync(name);
                else
                    dataset = await productManager.ElectronicProductManager.ReissueAsync(name);
            }

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_AttachmentExport() {
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


            if (IO.Directory.Exists(@"c:\temp\AttachmentExport"))
                IO.Directory.Delete(@"c:\temp\AttachmentExport");
            IO.Directory.CreateDirectory(@"c:\temp\AttachmentExport");

            using var geodatabase = createGeodatabase();

            var definitions = geodatabase.GetDefinitions<TableDefinition>();

            using var attachment = geodatabase.OpenDataset<Table>(definitions.Single(e => e.GetName().EndsWith("attachment")).GetName());

            using var cursor = attachment.Search(null, true);

            while (cursor.MoveNext()) {
                var dataset = System.Text.Json.JsonSerializer.Deserialize<S100FC.ProductCatalogue.Dataset>(Convert.ToString(cursor.Current["json"])!)!;

                using var memoryStream = (MemoryStream)cursor.Current["data"];

                using (FileStream file = new FileStream($@"c:\temp\AttachmentExport\{dataset.DatasetName}.yaml", FileMode.Create, FileAccess.Write)) {
                    memoryStream.CopyTo(file);
                }
            }
        }
    }
}