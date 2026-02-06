using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using CommandLine;
using S100FC;
using S100FC.ProductCatalogue;
using S100FC.S101;
using S100FC.YAML;
using Serilog;
using System.Diagnostics;
using System.Text.Json;
using Dataset = S100FC.YAML.Dataset;
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

            [Option('b', "bulk", Required = false, HelpText = "Multiple datasets. Example: -b dataset1 dataset2 dataset3")]
            public IEnumerable<string> DatasetBulk { get; set; } = [];

            [Option('g', "geodatabase", Required = true, HelpText = "Geodatabase.")]
            public string Geodatabase { get; set; } = string.Empty;

            [Option('e', "exchangeset", Required = false, Default = false, HelpText = "Build exchangeset.")]
            public bool ExchangeSet { get; set; } = false;

            [Option('o', "outputpath", Required = false, HelpText = "OutputPath")]
            public string OutputPath { get; set; } = Directory.GetCurrentDirectory();

            [Option('n', "notespath", Required = false, HelpText = "Path to notes files references in TXTDSC.")]
            public string? NotesPath { get; set; }

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

                var jsonSerializerOptionsS101 = new JsonSerializerOptions {
                    WriteIndented = false,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                }.AppendTypeInfoResolver();

                var jsonSerializerOptionsS128 = new JsonSerializerOptions {
                    WriteIndented = false,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                };

                S100FC.S128.Extensions.AppendTypeInfoResolver(jsonSerializerOptionsS128);

                Esri.Initialize();

                string? output = default;
                bool exchangeset = false;
                string[] datasetNames = [];
                string? wildcard = default;

                IO.DirectoryInfo? directoryNotes = default;

                Func<Geodatabase> createGeodatabase = () => { throw new NotImplementedException(); };

                _ = arguments.WithParsed<Options>(o => {
                    var geodatabase = o.Geodatabase.ToLowerInvariant();

                    if (IO.File.Exists(geodatabase) && ".sde".Equals(IO.Path.GetExtension(geodatabase), StringComparison.InvariantCultureIgnoreCase)) {
                        createGeodatabase = () => { return new Geodatabase(new DatabaseConnectionFile(new Uri(IO.Path.GetFullPath(geodatabase)))); };
                    }
                    else if (IO.Directory.Exists(geodatabase) && ".gdb".Equals(IO.Path.GetExtension(geodatabase), StringComparison.InvariantCultureIgnoreCase)) {
                        createGeodatabase = () => { return new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(geodatabase)))); };
                    }
                    else
                        throw new System.ArgumentOutOfRangeException(nameof(geodatabase));

                    datasetNames = [.. o.DatasetBulk];

                    if (o.Dataset != null) {
                        datasetNames = [.. datasetNames, o.Dataset];
                    }

                    if (o.Dataset != null && o.Dataset.Contains("%")) {
                        datasetNames = [];
                        wildcard = o.Dataset;
                    }


                    exchangeset = o.ExchangeSet;

                    directoryNotes = new IO.DirectoryInfo(o.NotesPath!);

                    output = o.OutputPath;
                });

                if (datasetNames.Length == 0 && string.IsNullOrEmpty(wildcard))
                    throw new ArgumentNullException("No datasets specified. Use -d or -b to specify dataset(s).");

                Directory.CreateDirectory(output!);
                Log.Information("Output path: {output}", output);

                using Geodatabase source = createGeodatabase();

                var definitionTables = source.GetDefinitions<TableDefinition>();
                var definitionFeatures = source.GetDefinitions<FeatureClassDefinition>();

                var featureCatalogue = S100FC.Catalogues.FeatureCatalogue.Catalogues.Single(e => e.ProductID.Equals("S-101"));

                var datasets = new List<(Dataset Dataset, SpatialQueryFilter Filter)>();
                {
                    using var surface = source.OpenDataset<FeatureClass>(definitionFeatures.Single(e => e.GetAliasName().Equals("surface")).GetName());

                    if (!string.IsNullOrEmpty(wildcard)) {
                        using var cursor = surface.Search(new QueryFilter {
                            WhereClause = $"upper(ps) = 'S-128' and FLATTEN LIKE '%\"datasetName\":%\"{wildcard}\"%'",
                        }, true);

                        while (cursor.MoveNext()) {
                            var current = (ArcGIS.Core.Data.Feature)cursor.Current;

                            var electricProduct = (S100FC.S128.FeatureTypes.ElectronicProduct)S100FC.AttributeFlattenExtensions.Unflatten<FeatureType>(Convert.ToString(current["flatten"])!, typeof(S100FC.S128.FeatureTypes.ElectronicProduct));

                            datasetNames = [.. datasetNames, electricProduct.datasetName!];
                        }

                        ;
                    }

                    foreach (var ds in datasetNames) {
                        using var cursor = surface.Search(new QueryFilter {
                            WhereClause = string.IsNullOrEmpty(ds) ? "upper(ps) = 'S-128'" : $"upper(ps) = 'S-128' and FLATTEN LIKE '%\"datasetName\":%\"{ds.ToUpperInvariant()}\"%'",
                        }, true);

                        while (cursor.MoveNext()) {
                            var current = (ArcGIS.Core.Data.Feature)cursor.Current;

                            var electricProduct = (S100FC.S128.FeatureTypes.ElectronicProduct)S100FC.AttributeFlattenExtensions.Unflatten<FeatureType>(Convert.ToString(current["flatten"])!, typeof(S100FC.S128.FeatureTypes.ElectronicProduct));

                            var shape = (ArcGIS.Core.Geometry.Polygon)current.GetShape().Clone();

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
                                SpatialRelationshipDescription = S100FC.Topology.Matrix.DE9IM,
                                WhereClause = whereClause,
                            }));
                        }
                    }
                }

                //Matrix.ParallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 1 };

                //  TEST, TEST, TEST, TEST, TEST, 
                S100FC.Topology.Matrix.ParallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 1 };

                foreach (var e in datasets) {
                    var supportFiles = new List<string>();

                    var dataset = e.Dataset;
                    var filter = e.Filter;

                    var datasetName = dataset.CellName.Split('.')[0];

                    Log.Information("{dataset}", datasetName);
                    var spatialAssociations = new Dictionary<string, S100FC.YAML.Association>();
                    var geometries = new List<(ArcGIS.Core.Geometry.Geometry geometry, string name)>();

                    // Build Topology
                    Log.Information("Building topology..");
                    S100FC.Topology.IMatrix topology = source.BuildTopology(filter)!;

                    Log.Information("Topology finished! Found {curves} Curves, {composites} CompositeCurves, {surfaces} Surfaces", topology.Curves.Count(), topology.CompositeCurves.Count(), topology.Surfaces.Count());

                    // InformationTypes
                    var informationTypes = new List<S100FC.YAML.Information>();
                    var informationsTypesAdded = new List<string>();

                    try {
                        using var informationType = source.OpenDataset<Table>(definitionTables.Single(e => e.GetAliasName().Equals("informationtype")).GetName());
                        using var informationCursor = informationType.Search();
                        while (informationCursor.MoveNext()) {
                            var current = informationCursor.Current;

                            var name = current.UID();
                            var code = current["code"].ToString()!;
                            //var json = current["flatten"].ToString()!;

                            var type = featureCatalogue.Assembly!.GetType($"{S100FC.Catalogues.FeatureCatalogue.Namespace("S101", "InformationTypes")}.{code}", true)!;

                            var json = Convert.ToString(current["flatten"]);
                            var instance = string.IsNullOrEmpty(json) ? null : S100FC.AttributeFlattenExtensions.Unflatten<InformationType>(json, type);

                            //var instance = DBNull.Value.Equals(current["json"]) ? null : System.Text.Json.JsonSerializer.Deserialize(Convert.ToString(current["json"])!, type, jsonSerializerOptionsS101); // jsonSerializerOptionsS101

                            var information = new S100FC.YAML.Information {
                                Name = code,
                                ID = name,
                                Attributes = (S100FC.InformationType)instance!
                            };
                            informationTypes.Add(information);

                            var filenames = S100FC.YAML.Extensions.GetFileNames(json);

                            foreach (var filename in filenames) {
                                if (!supportFiles.Contains(filename)) {
                                    supportFiles.Add(filename);
                                    var file = directoryNotes?.GetFiles(filename.Replace("101DK00", "DK"), SearchOption.AllDirectories).First();
                                    if (file != null) {
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
                    var featureTypes = new List<S100FC.YAML.Feature>();
                    var featureTypesAdded = new List<string>();

                    try {
                        using var featureType = source.OpenDataset<Table>(definitionTables.Single(e => e.GetAliasName().Equals("featuretype")).GetName());
                        using var featureCursor = featureType.Search();
                        while (featureCursor.MoveNext()) {
                            var current = featureCursor.Current;

                            var name = current.UID();
                            var code = current["code"].ToString()!;
                            //var json = current["json"].ToString()!;

                            var json = Convert.ToString(current["flatten"]);

                            var type = featureCatalogue.Assembly!.GetType($"{S100FC.Catalogues.FeatureCatalogue.Namespace("S101", "FeatureTypes")}.{code}", true)!;

                            var instance = string.IsNullOrEmpty(json) ? null : S100FC.AttributeFlattenExtensions.Unflatten<FeatureType>(json, type);
                            //var instance = DBNull.Value.Equals(current["json"]) ? null : System.Text.Json.JsonSerializer.Deserialize(Convert.ToString(current["json"])!, type, jsonSerializerOptionsS101) as S100FC.FeatureType;// jsonSerializerOptionsS101

                            var foid = $"110:{name.Substring(1)}:1";       // Geodatastyrelsen: 110 

                            var feature = new S100FC.YAML.Feature {
                                Prim = Primitive.NoGeometry,
                                Name = code,
                                Foid = foid,
                                Attributes = instance,
                            };

                            featureTypes.Add(feature);

                            var filenames = S100FC.YAML.Extensions.GetFileNames(json);

                            foreach (var filename in filenames) {
                                if (!supportFiles.Contains(filename)) {
                                    supportFiles.Add(filename);
                                    var file = directoryNotes.GetFiles(filename.Replace("101DK00", "DK"), SearchOption.AllDirectories).First();
                                    var base64 = Convert.ToBase64String(IO.File.ReadAllBytes(file.FullName));
                                    dataset?.Metadata.AddSupportFile(filename, base64);
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
                            var name = current.UID();

                            // Only map geometry, and keep name seperate so foids remain unique
                            var geometry = name;

                            if (topology.Mapping.TryGetValue(name!, out var value))
                                geometry = value;

                            var shapetype = def.GetShapeType();

                            var code = Convert.ToString(current["code"]);

                            var foid = $"110:{name.Substring(1)}:1";       // Geodatastyrelsen: 110 

                            var prim = shapetype switch {
                                GeometryType.Point => Primitive.Point,
                                GeometryType.Multipoint => Primitive.Point,
                                GeometryType.Polyline => Primitive.Curve,
                                GeometryType.Polygon => Primitive.Surface,
                                _ => throw new InvalidOperationException(),
                            };

                            try {
                                var type = featureCatalogue.Assembly!.GetType($"{S100FC.Catalogues.FeatureCatalogue.Namespace("S101", "FeatureTypes")}.{code}", true) ?? default;

                                if (type == default) {
                                    Log.Error("Could not get type: {type} for feature: {name}", code, name);
                                    continue;
                                }

                                var json = Convert.ToString(current["flatten"])!;
                                var instance = string.IsNullOrEmpty(json) ? null : S100FC.AttributeFlattenExtensions.Unflatten<FeatureType>(json, type);
                                //var instance = current.IsNull("json") ? null : System.Text.Json.JsonSerializer.Deserialize(json, type, jsonSerializerOptionsS101) as S100FC.FeatureType;


                                var filenames = S100FC.YAML.Extensions.GetFileNames(json);

                                foreach (var filename in filenames) {
                                    if (!supportFiles.Contains(filename)) {
                                        supportFiles.Add(filename);
                                        var file = directoryNotes.GetFiles(filename.Replace("101DK00", "DK"), SearchOption.AllDirectories).First();
                                        var base64 = Convert.ToBase64String(IO.File.ReadAllBytes(file.FullName));
                                        dataset?.Metadata.AddSupportFile(filename, base64);
                                    }
                                }

                                // Surface Masks
                                var topologySurface = topology.Surfaces.FirstOrDefault(e => e.Ref!.Equals(name, StringComparison.InvariantCultureIgnoreCase));

                                // Build comma seperated string of masks, with :1 or :2 indicating which mask it is. Should be null/omitted if empty.
                                var masks = new[] {
                                    topologySurface?.Masks1?.Select(e => $"C{e}:1"),
                                    topologySurface?.Masks2?.Select(e => $"C{e}:2")
                                }.Where(m => m != null).SelectMany(m => m!);

                                var feature = new S100FC.YAML.Feature {
                                    Name = code,
                                    Foid = foid,
                                    Prim = prim,
                                    Geometry = geometry,
                                    Masks = masks.Any() ? string.Join(",", masks) : null,
                                    Attributes = instance?.attributeBindings.Length > 0 ? instance : null
                                };


                                // Information Associations
                                if (!current.IsNull("informationbindings")) {
                                    var informationBindings = System.Text.Json.JsonSerializer.Deserialize<informationBinding[]>(Convert.ToString(current["informationbindings"])!, jsonSerializerOptionsS101); // jsonSerializerOptionsS101

                                    if (informationBindings != default && informationBindings.Any()) {
                                        foreach (var binding in informationBindings) {
                                            var asso = new S100FC.YAML.Association {
                                                Name = binding.GetType().GenericTypeArguments[0].Name,
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
                                    var featureBindingsJson = Convert.ToString(current["featurebindings"])!;
                                    var featureBindings = System.Text.Json.JsonSerializer.Deserialize<featureBinding[]>(featureBindingsJson, jsonSerializerOptionsS101); // jsonSerializerOptionsS101

                                    if (featureBindings != default && featureBindings.Any()) {
                                        foreach (var binding in featureBindings) {
                                            var roleType = binding.roleType;

                                            // Skip association roleType for now
                                            if (roleType == "association")
                                                continue;

                                            var asso = new S100FC.YAML.Association {
                                                Name = binding.GetType().GenericTypeArguments[0].Name,
                                                Role = binding.role,
                                                To = $"110:{binding.featureId!.Substring(1)}:1"
                                            };

                                            feature?.AddFeatureAssociation(asso);

                                            var noGeometry = featureTypes.SingleOrDefault(e => e.Foid.Equals($"110:{binding.featureId.Substring(1)}:1"));
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
                    var yaml = S100FC.YAML.Converter.Serialize(dataset!);



                    File.WriteAllText(IO.Path.Combine(output, $"{datasetName}.yaml"), yaml);
                    File.WriteAllText(IO.Path.Combine(@"c:\temp", $"{datasetName}.yaml"), yaml);

                    if (IO.File.Exists(@"C:\Program Files\s100compiler\s100compiler.exe")) {
                        var commandline = $"-f \"{IO.Path.Combine(output, $"{datasetName}.yaml")}\" -c \"{@"\\nas.gst.dk\public\projektdata\produktion\S-100\Product Specifications\S-101 Electronic Navigational Chart\2.0.0\101_Feature_Catalogue_2.0.0.xml"}\" -d \"{output}\"";

                        if (IO.Directory.Exists(IO.Path.Combine(output, datasetName)))
                            IO.Directory.Delete(IO.Path.Combine(output, datasetName), true);
                        // IO.Directory.CreateDirectory(IO.Path.Combine(output, datasetName));

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

                            IO.Directory.Move(IO.Path.Combine(output, "S100_ROOT"), IO.Path.Combine(output, $"{datasetName}_ROOT"));
                        }
                    }
                    Log.Information("------------------------------------------------------------");
                }
                sw.Stop();
                Log.Information("Elapsed: {elapsed}", sw.Elapsed);

                return 0;
            }
            catch (Exception ex) {
                Log.Error(ex, ex.Message);
                return -1;
            }
        }
    }
}
