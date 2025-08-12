using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using CommandLine;
using S100Framework.DomainModel;
using S100Framework.YAML;
using S100Framework.NauticalProducts;
using Serilog;
using System.Diagnostics;
using System.Text.Json;
using Dataset = S100Framework.YAML.Dataset;
using Esri = ArcGIS.Core.Hosting.Host;
using IO = System.IO;

namespace S100Framework.Applications
{
    internal class VortexExporter
    {
        private const string outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff}| [{Level:u3}] {Message:lj} {NewLine}{Exception}";
        public class Options
        {
            [Option('d', "dnsm", Required = false, HelpText = "", Default = "DK40349E")]
            public string Dataset { get; set; } = "DK40349E";

            [Option('g', "geodatabase", Required = true, HelpText = "Geodatabase.")]
            public string Geodatabase { get; set; } = string.Empty;

            [Option('e', "exchangeset", Required = false, Default = false, HelpText = "Build exchangeset.")]
            public bool ExchangeSet { get; set; } = false;

            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }
        }

        static int Main(string[] args) {
            var logpath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Geodatastyrelsen", "VortexExporter", "YAML-developer.log");

            // Clears log between each run
            if (File.Exists(logpath))
                File.Delete(logpath);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(
                    path: logpath,
                    rollingInterval: RollingInterval.Infinite,
                    retainedFileCountLimit: 1,
                    shared: true,
                    outputTemplate: outputTemplate)
                .CreateLogger();

            Log.Information("exporter.exe {args}", string.Join(' ', args));


            try {
                var sw = new Stopwatch();
                sw.Start();
                var arguments = Parser.Default.ParseArguments<Options>(args)
                                   .WithParsed<Options>(o => {
                                   });

                AppDomain.CurrentDomain.UnhandledException += (sender, e) => {
                    Logger.Current.Fatal((Exception)e.ExceptionObject, "UnhandledException");
                };

                Logger.Current.Information("VortexExporter.exe {args}", string.Join(" ", args));

                if (arguments.Errors.Any())
                    return -1;

                Esri.Initialize();

                string? dsnm = default;
                bool exchangeset = false;

                Func<Geodatabase> createGeodatabase = () => { throw new NotImplementedException(); };

                arguments.WithParsed<Options>(o => {
                    var geodatabase = o.Geodatabase.ToLowerInvariant();

                    if (IO.File.Exists(geodatabase) && ".sde".Equals(IO.Path.GetExtension(geodatabase), StringComparison.InvariantCultureIgnoreCase)) {
                        createGeodatabase = () => { return new Geodatabase(new DatabaseConnectionFile(new Uri(IO.Path.GetFullPath(geodatabase)))); };
                    }
                    else if (IO.Directory.Exists(geodatabase) && ".gdb".Equals(IO.Path.GetExtension(geodatabase), StringComparison.InvariantCultureIgnoreCase)) {
                        createGeodatabase = () => { return new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(geodatabase)))); };
                    }
                    else
                        throw new System.ArgumentOutOfRangeException(nameof(geodatabase));

                    dsnm = o.Dataset;
                    exchangeset = o.ExchangeSet;
                });

                using Geodatabase source = createGeodatabase();

                var definitionTables = source.GetDefinitions<TableDefinition>();
                var definitionFeatures = source.GetDefinitions<FeatureClassDefinition>();

                var featureCatalogue = S100Framework.Catalogues.FeatureCatalogue.Catalogues.Single(e => e.ProductID.Equals("S-101"));

                var datasets = new List<(Dataset Dataset, SpatialQueryFilter Filter)>();
                {
                    using var surface = source.OpenDataset<FeatureClass>(definitionFeatures.Single(e => e.GetAliasName().Equals("surface")).GetName());

                    using var cursor = surface.Search(new QueryFilter {
                        WhereClause = $"upper(ps) = 'S-128' and JSON LIKE '%\"datasetName\":\"{dsnm!.ToUpperInvariant()}\"%'",
                    }, true);

                    while (cursor.MoveNext()) {
                        var current = (ArcGIS.Core.Data.Feature)cursor.Current;

                        var electricProduct = System.Text.Json.JsonSerializer.Deserialize<S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct>(Convert.ToString(current["json"])!);

                        var polygon = (ArcGIS.Core.Geometry.Polygon)current.GetShape();
                        var json = polygon.ToJson();

                        var shape = GeometryEngine.Instance.ImportFromJson(JsonImportFlags.JsonImportDefaults, json);

                        var whereClause = "upper(ps) = 'S-101'";
                        if (!current.IsNull("usageband"))
                            whereClause += $" AND usageband = {Convert.ToInt32(current["usageband"])}";

                        datasets.Add((new Dataset {
                            CellName = $"101{electricProduct!.datasetName!}.000",
                            Comment = "Not for navigation!",
                            Edition = 1,
                            ENCVer = "INT.IHO.S-101.2.0",
                            FCVer = "2.0",
                            verticalDatum = "Baltic Sea Chart Datum 2000,44",
                        }, new SpatialQueryFilter {
                            FilterGeometry = shape,
                            SpatialRelationship = SpatialRelationship.Relation,
                            SpatialRelationshipDescription = "T*****FF*",
                            WhereClause = whereClause,
                        }));
                    }
                }

                //Matrix.ParallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 1 };

                foreach (var e in datasets) {
                    var dataset = e.Dataset;
                    var filter = e.Filter;

                    var datasetName = dataset.CellName.Split('.')[0];

                    //if (datasetName.Equals("101DK40751E")) continue;
                    //if (datasetName.Equals("101DK40545E")) continue;
                    //if (datasetName.Equals("101DK40347E")) continue;

                    Log.Information("{dataset}", datasetName);
                    var geometries = new List<(Geometry geometry, string name)>();

                    // Build Topology
                    Log.Information("Building topology..");
                    var topology = source.BuildTopology(filter)!;

                    Log.Verbose("Topology: #{curves}, #{composites}, #{surfaces}", topology.Curves.Count(), topology.CompositeCurves.Count(), topology.Surfaces.Count());

                    Log.Information("Topology finished! Found {curves} Curves, {composites} CompositeCurves, {surfaces} Surfaces", topology.Curves.Count(), topology.CompositeCurves.Count(), topology.Surfaces.Count());
                    dataset.AddTopology(topology);

                    // InformationTypes
                    try {
                        using var informationType = source.OpenDataset<Table>(definitionTables.Single(e => e.GetAliasName().Equals("informationtype")).GetName());
                        using var informationCursor = informationType.Search();
                        while (informationCursor.MoveNext()) {
                            var current = informationCursor.Current;

                            var name = current["name"].ToString()!;
                            var code = current["code"].ToString()!;
                            var json = current["json"].ToString()!;

                            var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace("S101", "InformationTypes")}.{code}", true)!;

                            var instance = DBNull.Value.Equals(current["json"]) ? null : System.Text.Json.JsonSerializer.Deserialize(Convert.ToString(current["json"])!, type);

                            var information = new YAML.Information {
                                Name = code,
                                ID = name,
                                Attributes = (InformationNode)instance!,
                            };

                            dataset.AddInformation(information);
                        }
                    }
                    catch (Exception ex) {
                        Log.Information("Table: informationtype: {message} ", ex.Message);
                        Logger.Current.Error("Exception: {ex}", ex);
                    }

                    Log.Information("InformationTypes found: #{count}", dataset.InformationTypes?.Count ?? 0);

                    // Features
                    foreach (var def in source.GetDefinitions<FeatureClassDefinition>()) {
                        var tableName = def.GetAliasName();

                        var supported = tableName switch {
                            "surface" => true,
                            "curve" => true,
                            "point" => true,
                            "pointset" => true,
                            _ => false
                        };

                        if (!supported) {
                            Log.Information("Unsupported table detected: {tableName}", tableName);
                            continue;
                        }

                        using var fc = source.OpenDataset<FeatureClass>(def.GetName());

                        using var cursor = fc.Search(filter, true);
                        while (cursor.MoveNext()) {
                            var current = (ArcGIS.Core.Data.Feature)cursor.Current;
                            var name = Convert.ToString(current["name"])!;

                            //if (name.Equals("S12233")) System.Diagnostics.Debugger.Break();
                            //if (name.Equals(topology.Surfaces.ElementAt(0).Ref)) System.Diagnostics.Debugger.Break();

                            // Only map geometry, and keep name seperate so foids remain unique
                            var geometry = name;

                            if (topology.Mapping.TryGetValue(name!, out var value))
                                geometry = value;
                            else if (!name.StartsWith("P"))
                                System.Diagnostics.Debugger.Break();

                            var shapetype = def.GetShapeType();

                            var code = Convert.ToString(current["code"]);

                            var foid = $"110:{name[1..]}:1";       // Geodatastyrelsen: 110 

                            var prim = shapetype switch {
                                GeometryType.Point => Primitive.Point,
                                GeometryType.Multipoint => Primitive.Point,
                                GeometryType.Polyline => Primitive.Curve,
                                GeometryType.Polygon => Primitive.Surface,
                                _ => throw new InvalidOperationException(),
                            };

                            try {
                                var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace("S101", "FeatureTypes")}.{code}", true) ?? default;

                                if (type == default) {
                                    Log.Error("Could not get type: {type} for feature: {name}", code, name);
                                    continue;
                                }

                                var instance = current.IsNull("json") ? null : System.Text.Json.JsonSerializer.Deserialize(Convert.ToString(current["json"])!, type);

                                var feature = new YAML.Feature {
                                    Name = code,
                                    Foid = foid,
                                    Prim = prim,
                                    Geometry = geometry,
                                };

                                // Only emit attributes if feature contains any non-static properties
                                if (!S100Framework.YAML.Converter.IsDefault(instance!))
                                    feature.Attributes = (FeatureNode)instance!;

                                // Information Associations
                                if (!current.IsNull("informationbindings")) {
                                    using var document = JsonDocument.Parse(Convert.ToString(current["informationbindings"])!);
                                    var root = document.RootElement;

                                    var association = root.GetProperty("association").GetString()!;
                                    var role = root.GetProperty("role").GetString()!;
                                    var informationId = root.GetProperty("informationId").GetString()!;

                                    var asso = new YAML.Association {
                                        Name = association,
                                        Role = role,
                                        To = informationId,
                                    };

                                    // Special case for SpatialAssociation
                                    if (prim != Primitive.Surface && association.Equals("SpatialAssociation", StringComparison.CurrentCultureIgnoreCase)) {
                                        var curve = dataset?.Curves?.FirstOrDefault(e => e.Name == geometry);

                                        curve?.AddAssociation(asso);
                                    }
                                    else {
                                        feature?.AddAssociation(asso);
                                    }
                                }

                                // Feature Associations
                                if (!current.IsNull("featurebindings")) {
                                    using var document = JsonDocument.Parse(Convert.ToString(current["featurebindings"])!);
                                    var root = document.RootElement;

                                    if (root.ValueKind == JsonValueKind.Array) {
                                        foreach (var element in root.EnumerateArray()) {
                                            var roleType = element.GetProperty("roleType").GetString();

                                            // Skip association roleType for now
                                            if (roleType == "association")
                                                continue;

                                            var association = element.GetProperty("association").GetString()!;
                                            var role = element.GetProperty("role").GetString()!;
                                            var featureId = element.GetProperty("featureId").GetString()!;


                                            var asso = new YAML.Association {
                                                Name = association,
                                                Role = role,
                                                To = $"110:{featureId[1..]}:1"
                                            };

                                            feature?.AddFeatureAssociation(asso);
                                        }
                                    }
                                }

                                dataset?.AddFeature(feature!);

                                geometries.Add(new(current.GetShape(), name!));
                            }
                            catch (Exception ex) {
                                Log.Information(ex.Message);
                                Logger.Current.Error("Exception: {ex}", ex);
                                continue;
                            }
                        }
                    }

                    // Geometries
                    foreach (var (geometry, name) in geometries.OrderBy(e => e.geometry.GeometryType)) {
                        if (geometry.GeometryType == GeometryType.Polygon) continue;    // Skip polygons after topology
                        dataset?.AddGeometry(geometry, name!);
                        Log.Verbose("Adding {geometryType} with ID: {name}", geometry.GeometryType, name);
                    }

                    // Serialize to YAML
                    var yaml = S100Framework.YAML.Converter.Serialize(dataset!);

                    var output = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    File.WriteAllText(IO.Path.Combine(output, $"{datasetName}.yaml"), yaml);
                    File.WriteAllText(IO.Path.Combine(@"c:\temp", $"{datasetName}.yaml"), yaml);

                    if (IO.File.Exists(@"C:\Program Files\s100compiler\s100compiler.exe")) {
                        var commandline = $"-f \"{IO.Path.Combine(output, $"{datasetName}.yaml")}\" -c \"{@"\\nas.gst.dk\public\projektdata\produktion\S-100\Product Specifications\S-101 Electronic Navigational Chart\2.0.0\101_Feature_Catalogue_2.0.0.xml"}\" -d \"{IO.Path.Combine(output, datasetName)}\"";

                        if (IO.Directory.Exists(IO.Path.Combine(output, datasetName)))
                            IO.Directory.Delete(IO.Path.Combine(output, datasetName), true);
                        IO.Directory.CreateDirectory(IO.Path.Combine(output, datasetName));

                        if (!exchangeset) {
                            Log.Information("s100compiler.exe -f {dataset}.yaml -d {dataset}.000 -c 101_Feature_Catalogue_2.0.0.xml", datasetName);

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
                                return p.ExitCode;
                            }
                        }
                        else {
                            Log.Information("s100compiler.exe -f {dataset}.yaml -d {dataset}.000 -C {dataset} -c 101_Feature_Catalogue_2.0.0.xml", datasetName);
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
                                return p.ExitCode;
                            }
                        }
                    }
                    Log.Information("------------------------------------------------------------");
                }
                sw.Stop();
                Log.Information("Elapsed: {elapsed}", sw.Elapsed);

                return 0;
            }
            catch (Exception ex) {
                Log.Information(ex.Message);
                return -1;
            }
        }
    }
}

