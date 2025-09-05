using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using CommandLine;
using S100Framework.Catalogues;
using S100Framework.DomainModel;
using S100Framework.ProductCatalogue;
using S100Framework.YAML;
using Serilog;
using System.Diagnostics;
using System.Text.RegularExpressions;
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
            [Option('d', "dnsm", Required = false, HelpText = "")]
            public string? Dataset { get; set; }

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
                        WhereClause = string.IsNullOrEmpty(dsnm) ? $"upper(ps) = 'S-128'" : $"upper(ps) = 'S-128' and JSON LIKE '%\"datasetName\":\"{dsnm!.ToUpperInvariant()}\"%'",
                    }, true);

                    while (cursor.MoveNext()) {
                        var current = (ArcGIS.Core.Data.Feature)cursor.Current;

                        var electricProduct = System.Text.Json.JsonSerializer.Deserialize<S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct>(Convert.ToString(current["json"])!);

                        var shape = (ArcGIS.Core.Geometry.Polygon)current.GetShape().Clone();
                        //var json = polygon.ToJson();
                        //var shape = GeometryEngine.Instance.ImportFromJson(JsonImportFlags.JsonImportDefaults, json);

                        var whereClause = "upper(ps) = 'S-101'";
                        if (current.FindField("usageband") != -1 && !current.IsNull("usageband"))
                            whereClause += $" AND usageband = {Convert.ToInt32(current["usageband"])}";

                        datasets.Add((new Dataset {
                            CellName = $"{electricProduct!.datasetName!}.000",
                            Comment = "Not for navigation!",
                            Edition = 1,
                            ENCVer = "INT.IHO.S-101.2.0",
                            FCVer = "2.0",
                            verticalDatum = "Baltic Sea Chart Datum 2000,44",
                        }, new SpatialQueryFilter {
                            FilterGeometry = shape,
                            SpatialRelationship = SpatialRelationship.Relation,
                            SpatialRelationshipDescription = Topology.Matrix.DE9IM,
                            WhereClause = whereClause,
                        }));
                    }
                }

                //Matrix.ParallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 1 };

                var directoryNotes = new IO.DirectoryInfo(@"\\nas.gst.dk\ncps\production\indigo\ENC\NotesAndPictures");

                var regFileReference = new Regex("fileReference\":\"(?<filename>[^\"]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

                var regPictorialRepresentation = new Regex("pictorialRepresentation\":\"(?<filename>[^\"]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

                foreach (var e in datasets) {
                    var supportFiles = new List<string>();

                    var dataset = e.Dataset;
                    var filter = e.Filter;

                    var datasetName = dataset.CellName.Split('.')[0];

                    //if (datasetName.Equals("101DK40751E")) continue;
                    //if (datasetName.Equals("101DK40545E")) continue;
                    //if (datasetName.Equals("101DK40347E")) continue;

                    Log.Information("{dataset}", datasetName);
                    var spatialAssociations = new Dictionary<string, S100Framework.YAML.Association>();
                    var geometries = new List<(ArcGIS.Core.Geometry.Geometry geometry, string name)>();

                    // Build Topology
                    Log.Information("Building topology..");
                    var topology = source.BuildTopology(filter)!;

                    Log.Information("Topology finished! Found {curves} Curves, {composites} CompositeCurves, {surfaces} Surfaces", topology.Curves.Count(), topology.CompositeCurves.Count(), topology.Surfaces.Count());

                    // InformationTypes
                    var informationTypes = new List<YAML.Information>();
                    var informationsTypesAdded = new List<string>();

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
                            };
                            // Only emit attributes if feature contains any non-static properties
                            if (!S100Framework.YAML.Converter.IsDefault(instance!))
                                information.Attributes = (InformationNode)instance!;
                            informationTypes.Add(information);
                            //dataset.AddInformation(information);

                            if (regFileReference.IsMatch(json)) {
                                var matches = regFileReference.Matches(json);
                                foreach (Match m in matches) {
                                    var filename = m.Groups["filename"].Value;

                                    if (!supportFiles.Contains(filename)) {
                                        supportFiles.Add(filename);
                                        var file = directoryNotes.GetFiles(filename.Replace("101DK00", "DK"), SearchOption.AllDirectories).First();

                                        var base64 = Convert.ToBase64String(IO.File.ReadAllBytes(file.FullName));
                                        dataset?.Metadata.AddSupportFile(filename, base64);
                                    }
                                }
                            }
                            if (regPictorialRepresentation.IsMatch(json)) {
                                var matches = regPictorialRepresentation.Matches(json);
                                foreach (Match m in matches) {
                                    var filename = m.Groups["filename"].Value;

                                    if (!supportFiles.Contains(filename)) {
                                        supportFiles.Add(filename);
                                        var file = directoryNotes.GetFiles(filename.Replace("101DK00", "DK"), SearchOption.AllDirectories).First();

                                        var base64 = Convert.ToBase64String(IO.File.ReadAllBytes(file.FullName));
                                        dataset?.Metadata.AddSupportFile(filename, base64);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex) {
                        Log.Information("Table: informationtype: {message} ", ex.Message);
                        Logger.Current.Error("Exception: {ex}", ex);
                    }



                    // FeatureTypes
                    var featureTypes = new List<YAML.Feature>();
                    var featureTypesAdded = new List<string>();

                    try {
                        using var featureType = source.OpenDataset<Table>(definitionTables.Single(e => e.GetAliasName().Equals("featuretype")).GetName());
                        using var featureCursor = featureType.Search();
                        while (featureCursor.MoveNext()) {
                            var current = featureCursor.Current;

                            var name = current["name"].ToString()!;
                            var code = current["code"].ToString()!;
                            var json = current["json"].ToString()!;

                            var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace("S101", "FeatureTypes")}.{code}", true)!;

                            var instance = DBNull.Value.Equals(current["json"]) ? null : System.Text.Json.JsonSerializer.Deserialize(Convert.ToString(current["json"])!, type);

                            var foid = $"110:{name[1..]}:1";       // Geodatastyrelsen: 110 

                            var feature = new YAML.Feature {
                                Prim = Primitive.NoGeometry,
                                Name = code,
                                Foid = foid,
                            };
                            // Only emit attributes if feature contains any non-static properties
                            if (!S100Framework.YAML.Converter.IsDefault(instance!))
                                feature.Attributes = (FeatureNode)instance!;
                            featureTypes.Add(feature);

                            if (regFileReference.IsMatch(json)) {
                                var matches = regFileReference.Matches(json);
                                foreach (Match m in matches) {
                                    var filename = m.Groups["filename"].Value;

                                    if (!supportFiles.Contains(filename)) {
                                        supportFiles.Add(filename);
                                        var file = directoryNotes.GetFiles(filename.Replace("101DK00", "DK"), SearchOption.AllDirectories).First();

                                        var base64 = Convert.ToBase64String(IO.File.ReadAllBytes(file.FullName));
                                        dataset?.Metadata.AddSupportFile(filename, base64);
                                    }
                                }
                            }
                            if (regPictorialRepresentation.IsMatch(json)) {
                                var matches = regPictorialRepresentation.Matches(json);
                                foreach (Match m in matches) {
                                    var filename = m.Groups["filename"].Value;

                                    if (!supportFiles.Contains(filename)) {
                                        supportFiles.Add(filename);
                                        var file = directoryNotes.GetFiles(filename.Replace("101DK00", "DK"), SearchOption.AllDirectories).First();

                                        var base64 = Convert.ToBase64String(IO.File.ReadAllBytes(file.FullName));
                                        dataset?.Metadata.AddSupportFile(filename, base64);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex) {
                        Log.Information("Table: featuretype: {message} ", ex.Message);
                        Logger.Current.Error("Exception: {ex}", ex);
                    }


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

                            // Only map geometry, and keep name seperate so foids remain unique
                            var geometry = name;

                            if (topology.Mapping.TryGetValue(name!, out var value))
                                geometry = value;

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

                                var json = Convert.ToString(current["json"])!;
                                var instance = current.IsNull("json") ? null : System.Text.Json.JsonSerializer.Deserialize(Convert.ToString(current["json"])!, type);

                                if (regFileReference.IsMatch(json)) {
                                    var matches = regFileReference.Matches(json);
                                    foreach (Match m in matches) {
                                        var filename = m.Groups["filename"].Value;

                                        if (!supportFiles.Contains(filename)) {
                                            supportFiles.Add(filename);
                                            var file = directoryNotes.GetFiles(filename.Replace("101DK00", "DK"), SearchOption.AllDirectories).First();

                                            var base64 = Convert.ToBase64String(IO.File.ReadAllBytes(file.FullName));
                                            dataset?.Metadata.AddSupportFile(filename, base64);
                                        }
                                    }
                                }
                                if (regPictorialRepresentation.IsMatch(json)) {
                                    var matches = regPictorialRepresentation.Matches(json);
                                    foreach (Match m in matches) {
                                        var filename = m.Groups["filename"].Value;

                                        if (!supportFiles.Contains(filename)) {
                                            supportFiles.Add(filename);
                                            var file = directoryNotes.GetFiles(filename.Replace("101DK00", "DK"), SearchOption.AllDirectories).First();

                                            var base64 = Convert.ToBase64String(IO.File.ReadAllBytes(file.FullName));
                                            dataset?.Metadata.AddSupportFile(filename, base64);
                                        }
                                    }
                                }

                                // Surface Masks
                                var topologySurface = topology.Surfaces.FirstOrDefault(e => e.Ref!.Equals(name, StringComparison.InvariantCultureIgnoreCase));

                                // Build comma seperated string of masks, with :1 or :2 indicating which mask it is. Should be null/omitted if empty.
                                var masks = new[] {
                                    topologySurface?.Masks1?.Select(e => $"C{e}:1"),
                                    topologySurface?.Masks2?.Select(e => $"C{e}:2")
                                }.Where(m => m != null).SelectMany(m => m!);

                                var feature = new YAML.Feature {
                                    Name = code,
                                    Foid = foid,
                                    Prim = prim,
                                    Geometry = geometry,
                                    Masks = masks.Any() ? string.Join(",", masks) : null
                                };

                                // Only emit attributes if feature contains any non-static properties
                                if (!S100Framework.YAML.Converter.IsDefault(instance!))
                                    feature.Attributes = (FeatureNode)instance!;

                                // Information Associations
                                if (!current.IsNull("informationbindings")) {
                                    var informationBindings = System.Text.Json.JsonSerializer.Deserialize<informationBinding[]?>(Convert.ToString(current["informationbindings"])!);

                                    if (informationBindings != default && informationBindings.Any()) {
                                        foreach (var binding in informationBindings) {
                                            var asso = new YAML.Association {
                                                Name = binding.association,
                                                Role = binding.role,
                                                To = binding.informationId!,
                                            };

                                            // Special case for SpatialAssociation. Add to dictionary for later processing.
                                            if (prim != Primitive.Surface && asso.Name.Equals("SpatialAssociation", StringComparison.CurrentCultureIgnoreCase))
                                                spatialAssociations.TryAdd(geometry, asso);
                                            else
                                                feature?.AddAssociation(asso);

                                            if (!informationsTypesAdded.Contains(binding.informationId!)) {
                                                informationsTypesAdded.Add(binding.informationId!);
                                                dataset!.AddInformation(informationTypes.Single(e => e.ID!.Equals(binding.informationId!)));
                                            }
                                        }
                                    }
                                }

                                // Feature Associations
                                if (!current.IsNull("featurebindings")) {
                                    var featureBindings = System.Text.Json.JsonSerializer.Deserialize<featureBinding[]?>(Convert.ToString(current["featurebindings"])!);

                                    if (featureBindings != default && featureBindings.Any()) {
                                        foreach (var binding in featureBindings) {
                                            var roleType = binding.roleType;

                                            // Skip association roleType for now
                                            if (roleType == "association")
                                                continue;

                                            var asso = new YAML.Association {
                                                Name = binding.association,
                                                Role = binding.role,
                                                To = $"110:{binding.featureId![1..]}:1"
                                            };

                                            feature?.AddFeatureAssociation(asso);

                                            var noGeometry = featureTypes.SingleOrDefault(e => e.Foid.Equals($"110:{binding.featureId![1..]}:1"));
                                            if (noGeometry != null && !featureTypesAdded.Contains(binding.featureId)) {
                                                featureTypesAdded.Add(binding.featureId);
                                                dataset?.AddFeature(noGeometry);
                                            }
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

                    Log.Information("FeatureTypes (noGeometry) found: #{count}", featureTypesAdded.Count);
                    Log.Information("InformationTypes found: #{count}", informationsTypesAdded.Count);

                    // Geometries
                    foreach (var (geometry, name) in geometries.OrderBy(e => e.geometry.GeometryType)) {
                        if (geometry.GeometryType == GeometryType.Polygon) continue;    // Skip polygons after topology
                        if (geometry.GeometryType == GeometryType.Polyline) continue;    // Skip curves after topology
                        dataset?.AddGeometry(geometry, name!);
                        Log.Verbose("Adding {geometryType} with ID: {name}", geometry.GeometryType, name);
                    }

                    // Add curves/surfaces after points
                    dataset!.AddTopology(topology);

                    // Add Spatial Association Informationbindings. Must be handled after curves are added to dataset.
                    foreach (var sa in spatialAssociations) {
                        var curve = dataset?.Curves?.FirstOrDefault(e => e.Name == sa.Key);

                        curve?.AddAssociation(sa.Value);
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
                                Log.Error("\"{filename}\" {arguments}", p.StartInfo.FileName, commandline);
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
                                Log.Error("\"{filename}\" {arguments}", p.StartInfo.FileName, commandline);
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
