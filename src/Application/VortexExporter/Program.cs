using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using CommandLine;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S101;
using S100Framework.YAML;
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


            var nameUsage1 = DomainModel.S101.nameUsage.DefaultNameDisplay;

            var v = (int)nameUsage1;

            var enumvalue = S100Framework.YAML.Converter.ToEnumString(nameUsage1);


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
                        if (!current.IsNull("drawingindex"))
                            whereClause += $" AND drawingindex = {Convert.ToInt32(current["drawingindex"])}";

                        datasets.Add((new Dataset {
                            CellName = $"101{electricProduct!.datasetName!}.000",
                            Comment = "Not for navigation!",
                            Edition = 1,
                            ENCVer = "INT.IHO.S-101.2.0",
                            FCVer = "2.0.0",
                        }, new SpatialQueryFilter {
                            FilterGeometry = shape,
                            SpatialRelationship = SpatialRelationship.Relation,
                            SpatialRelationshipDescription = "T*****FF*",
                            WhereClause = whereClause,
                        }));
                    }
                }

                foreach (var e in datasets) {
                    var dataset = e.Dataset;
                    var filter = e.Filter;

                    var datasetName = dataset.CellName.Split('.')[0];

                    if (datasetName.Equals("101DK40751E")) continue;
                    if (datasetName.Equals("101DK40545E")) continue;


                    Log.Information("{dataset}", datasetName);
                    var geometries = new List<(Geometry geometry, string name)>();
                    //var featureAssociations = new Dictionary<string, YAML.Association[]>();

                    // Build Topology
                    Log.Information("Building topology..");
                    var topology = source.BuildTopology(filter);

                    Log.Information("Topology finished! Found {curves} Curves, {composites} CompositeCurves, {surfaces} Surfaces", topology!.Curves.Count, topology.CompositeCurves.Count, topology.Surfaces.Count);
                    dataset.AddTopology(topology);

                    // FeatureAssociations - Only typeof associations. Skip composition/aggregation roleTypes for now
                    //try {
                    //    using var type = source.OpenDataset<Table>(definitionTables.Single(e => e.GetAliasName().Equals("associationbinding")).GetName());

                    //    using var cursor = type.Search(new QueryFilter {
                    //        WhereClause = "UPPER(type) = 'FEATUREBINDING' AND (UPPER(roleType) = 'AGGREGATION' OR UPPER(roleType) = 'COMPOSITION')"
                    //    });

                    //    while (cursor.MoveNext()) {
                    //        var current = cursor.Current;

                    //        var name = current["association"].ToString()!;
                    //        var role = current["role"].ToString()!;

                    //        var id = current["primaryid"].ToString()!;
                    //        var to = current["foreignid"].ToString()!;

                    //        var foid = $"110:{to![1..]}:1";       // Geodatastyrelsen: 110 

                    //        var association = new YAML.Association() {
                    //            Name = name,
                    //            Role = role,
                    //            To = foid,
                    //        };

                    //        // Add or update
                    //        if (featureAssociations.TryGetValue(id, out var existingArray))
                    //            featureAssociations[id] = [.. existingArray, association];
                    //        else
                    //            featureAssociations[id] = [association];
                    //    }
                    //}
                    //catch (Exception ex) {
                    //    Log.Information("Table: associationbinding: {message} ", ex.Message);
                    //    Logger.Current.Error("Exception: {ex}", ex);
                    //}

                    //Log.Information("FeatureAssociations found: #{count}", featureAssociations.Count);

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

                                    // Nessecary?
                                    var roleType = root.GetProperty("roleType").GetString();
                                    var associationId = root.GetProperty("associationId").GetString();

                                    var association = root.GetProperty("association").GetString();
                                    var role = root.GetProperty("role").GetString();
                                    var informationId = root.GetProperty("informationId").GetString();


                                    var asso = new YAML.Association {
                                        Name = association,
                                        Role = role,
                                        To = informationId,
                                    };

                                    feature.AddAssociation(asso);
                                }

                                // Feature Associations
                                //if (!current.IsNull("featurebindings")) {
                                //    using var document = JsonDocument.Parse(Convert.ToString(current["featurebindings"])!);
                                //    var root = document.RootElement;

                                //    if (root.ValueKind == JsonValueKind.Array) {
                                //        foreach (var element in root.EnumerateArray()) {
                                //            // Nessecary?
                                //            var roleType = element.GetProperty("roleType").GetString();
                                //            var associationId = element.GetProperty("associationId").GetString();

                                //            var association = element.GetProperty("association").GetString();
                                //            var role = element.GetProperty("role").GetString();
                                //            var featureId = element.GetProperty("featureId").GetString();


                                //            var asso = new YAML.Association {
                                //                Name = association,
                                //                Role = role,
                                //                To = $"110:{featureId[1..]}:1"
                                //            };

                                //            feature.AddFeatureAssociation(asso);
                                //        }
                                //    } else {
                                //        Console.WriteLine();
                                //    }
                                //}

                                dataset.AddFeature(feature);

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
                        dataset.AddGeometry(geometry, name!);
                        Log.Verbose("Adding {geometryType} with ID: {name}", geometry.GeometryType, name);
                    }

                    // Serialize to YAML
                    var yaml = S100Framework.YAML.Converter.Serialize(dataset);

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

        private const string jsonSurface = "{\"rings\":[[[12.5,54.7015465],[12.4732885,54.694891],[12.4421088,54.6871107],[12.4323619,54.6790339],[12.4167304,54.6660724],[12.4093265,54.6599296],[12.4021195,54.6539479],[12.3978169,54.6503758],[12.3895268,54.6434911],[12.3772575,54.6332961],[12.3758783,54.6321497],[12.3700522,54.6273061],[12.3649871,54.623094],[12.3626519,54.6211517],[12.3590146,54.6181259],[12.3549381,54.6147341],[12.3494461,54.6101634],[12.3414574,54.6035126],[12.339328,54.6017394],[12.3362479,54.5991741],[12.3332861,54.596707],[12.3244586,54.5893516],[12.3170332,54.583162],[12.3015427,54.5702419],[12.2733278,54.5466828],[12.2612285,54.5365694],[12.2413132,54.5199097],[12.24082,54.5194969],[12.2396746,54.5185383],[12.2359635,54.5154316],[12.2285345,54.509211],[12.217541,54.5],[12.0,54.5],[12.0,55.0],[12.5,55.0],[12.5,54.7015465]]],\"spatialReference\":{\"wkid\":4326,\"latestWkid\":4326,\"xyTolerance\":3.5355339e-08,\"zTolerance\":0.001,\"mTolerance\":0.001,\"falseX\":-400,\"falseY\":-400,\"xyUnits\":99999999.99999999,\"falseZ\":-100000,\"zUnits\":10000,\"falseM\":-100000,\"mUnits\":10000}}";
    }
}

namespace S100Framework.YAML
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using System.Text.RegularExpressions;

    public static class Extension
    {
        public static void AddGeometry(this Dataset dataset, ArcGIS.Core.Geometry.Geometry geometry, string name) {
            switch (geometry) {
                case ArcGIS.Core.Geometry.MapPoint point: {                              // Point
                        var datasetPoint = dataset?.Points?.FirstOrDefault(e => e.Coordinate?.X == point.X && e?.Coordinate?.Y == point.Y);
                        // Create point if not exist
                        if (datasetPoint == default) {
                            var p = new Point(point.X, point.Y) {
                                Name = $"{name}"
                            };

                            dataset!.AddPoint(p);
                        }
                        else {
                            dataset!.UpdateFeatureReferences(name, datasetPoint!.Name);
                        }
                        break;
                    }
                case ArcGIS.Core.Geometry.Multipoint multiPoint: {   // Depths
                        var points = multiPoint.Points.Select(e => new Coordinate(e.X, e.Y)).ToArray();
                        var depths = multiPoint.Points.Select(e => e.Z.RoundToIHO()).ToArray();

                        var pointSet = new PointSet(points, depths) { Name = name };
                        dataset.AddPointSet(pointSet);
                        break;
                    }
                case ArcGIS.Core.Geometry.Polyline polyline: {        // Curve will be handled in Topology
                        break;
                        var vertices = polyline.Points.Select(p => new Coordinate(p.X, p.Y)).ToArray();

                        var first = dataset?.GetOrCreateStartPoint(vertices, name);
                        var last = dataset?.GetOrCreateEndPoint(vertices, name);

                        var curve = new Curve(first!, last!, vertices) {
                            Name = name,
                        };

                        dataset!.AddCurve(curve);

                        // Create curve if another doesnt exist with the exact same vertices
                        //_ = dataset.GetOrCreateCurve(vertices, name);

                        break;
                    }
                case ArcGIS.Core.Geometry.Polygon polygon: {         // Surface are handled in Topology
                        break; // 
                        if (polygon.ExteriorRingCount == 0 || polygon.ExteriorRingCount > 1)
                            throw new ArgumentException("Unsupported exterior ring count");

                        if (polygon.ExteriorRingCount == 0 || polygon.ExteriorRingCount > 1)
                            throw new ArgumentException("Unsupported exterior ring count");

                        var nameWithoutIdentifier = Regex.Replace(name, @"\D", "");

                        var exteriorRing = polygon.GetExteriorRing(0);

                        var exteriorCoordinates = exteriorRing.Parts[0].Select(segment => new Coordinate(segment.StartPoint.X, segment.StartPoint.Y)).ToArray();

                        // Insert starting coordinate at the end of coordinate[] to ensure its a closed polygon
                        exteriorCoordinates = [.. exteriorCoordinates, exteriorCoordinates[0]];

                        var exteriorCurve = dataset.GetOrCreateCurve(exteriorCoordinates, nameWithoutIdentifier);

                        var surface = new Surface(exteriorCurve.Name!) {
                            Name = name
                        };

                        // Add interior rings
                        int id = 1;
                        if (polygon.Parts.Count > 1) {
                            foreach (var interiorRing in polygon.Parts.Skip(1)) {
                                var interiorCoordinates = interiorRing.Select(segment => new Coordinate(segment.StartPoint.X, segment.StartPoint.Y)).ToArray();

                                // Insert starting coordinate at the end of coordinate[] to ensure its a closed polygon
                                interiorCoordinates = [.. interiorCoordinates, interiorCoordinates[0]];

                                var interiorCurve = dataset.GetOrCreateCurve(interiorCoordinates, nameWithoutIdentifier, id);

                                id++;

                                if (surface.InteriorRings == null) {
                                    surface.InteriorRings = [interiorCurve.Name!];
                                }
                                else {
                                    surface.InteriorRings = [.. surface.InteriorRings, interiorCurve.Name!];
                                }
                            }

                            dataset.AddSurface(surface);
                        }
                        break;
                    }
                default:
                    throw new ArgumentException($"Unsupported geometry type: {geometry.GeometryType}");
            }
        }

        public static void AddTopology(this Dataset dataset, Matrix theMatrix) {
            // Curves
            CurveFeature? curveFeature = default;
            try {
                Log.Information("Adding curve #{count}", theMatrix.Curves.Count());

                var concurrent = new ConcurrentBag<Curve>();

                foreach (var c in theMatrix.Curves) {
                    curveFeature = c;

                    var coordinates = c.LineString.Coordinates.Select(e => new Coordinate(e.X, e.Y)).ToArray();

                    var first = dataset?.GetOrCreateStartPoint(coordinates, $"{c.Id}");
                    var last = dataset?.GetOrCreateEndPoint(coordinates, $"{c.Id}");

                    var curve = new Curve(first!, last!, coordinates) {
                        Name = $"C{c.Id}",
                    };

                    dataset!.AddCurve(curve);
                }
            }
            catch (Exception ex) {
                Log.Error("Exception! {ex} on curve: {curve}", ex, curveFeature?.Id);
            }


            //  Composite Curves
            CompositeCurveFeature? compositeCurveFeature = default;
            try {
                Log.Information("Adding compositecurve #{count}", theMatrix.CompositeCurves.Count());

                foreach (var c in theMatrix.CompositeCurves) {
                    compositeCurveFeature = c;

                    var compositecurveIds = new string[c.Curves.Length];
                    for (int i = 0; i < compositecurveIds.Length; i++) {
                        compositecurveIds[i] = c.Curves[i].Reverse ? $"RC{c.Curves[i].Id}" : $"C{c.Curves[i].Id}";
                    }

                    var components = string.Join(",", compositecurveIds);

                    var compositeCurve = new CompositeCurve(components) {
                        Name = $"C{c.Id}"
                    };

                    _ = dataset.AddCompositeCurve(compositeCurve);
                }
            }
            catch (Exception ex) {
                Log.Error("Exception! {ex} on compositecurve: {curve}", ex, compositeCurveFeature?.Id);
            }

            //  Surface
            SurfaceFeature? surfaceFeature = default;
            try {
                Log.Information("Adding surface #{count}", theMatrix.Surfaces.Count());

                foreach (var s in theMatrix.Surfaces) {
                    surfaceFeature = s;

                    var exteriorRing = s.Exterior.Reverse ? $"RC{s.Exterior.Id}" : $"C{s.Exterior.Id}";
                    var interiorRings = s?.Interior?.Select(e => e.Reverse ? $"RC{e.Id}" : $"C{e.Id}").ToArray();

                    var surface = new Surface(exteriorRing) {
                        InteriorRings = interiorRings,
                        //Name = s.Ref
                        Name = $"S{s.Id}",
                    };

                    _ = dataset.AddSurface(surface);
                }
            }
            catch (Exception ex) {
                Log.Error("Exception! {ex} on surface: {surface}", ex, surfaceFeature?.Id);
            }
        }

        /// <summary>
        /// The NCPS NIS was data loaded by ENCs for Denmark. The ENC only holds depth data to One decimal place and derived from paper chart practices <br />
        /// IHO Rounding rules applied (0-21m = decimeter, 21-31m = half meter 31+ = whole meter).
        /// </summary>
        public static double RoundToIHO(this double value) {

            if (value < -31d) {
                return Math.Floor(value);
            }
            else if (value < -21.0d) {
                return value % 1 < 0.5 ? Math.Ceiling(value) - 0.5d : Math.Ceiling(value);
            }
            else if (value < 0) {
                return RoundDownwards(value, 1, -0.5d);
            }
            else if (value < 21.0d) {
                return RoundDownwards(value, 1);
            }
            else if (value < 31) {
                return value % 1 < 0.5 ? Math.Floor(value) : Math.Floor(value) + 0.5;
            }

            return Math.Floor(value);
        }

        public static double RoundDownwards(double value, int digits, double offset = 0d) {
            var power10 = 1E1;
            value *= power10;
            value += offset;
            value = Math.Truncate(value);
            return value /= power10;
        }

        public static void UpdateFeatureReferences(this Dataset dataset, string original, string target) {
            if (original == target) {
                Log.Error("Error! Original cant be same as target!");
                return;
            }

            foreach (var feature in dataset?.Features?.Where(e => e.Geometry == original) ?? []) {
                Log.Verbose("  - Updating feature geometry reference with original {original} and target: {target}", original, target);
                feature.Geometry = target;

                // Associations
                foreach (var ass in feature?.FeatureAssociation ?? []) {
                    if (ass?.To?.Contains(original) ?? false) {
                        Log.Verbose("  - Updating feature association reference with original {original} and target: {target}", original, target);
                        ass.To = ass?.To?.Replace(original, target);
                    }
                }
            }
        }

        public static Curve GetOrCreateCurve(this Dataset dataset, Coordinate[] coordinates, string name, int identifier = 0) {
            var tempCurve = new Curve(coordinates);
            var datasetCurve = dataset?.Curves?.FirstOrDefault(e => e.Vertices == tempCurve.Vertices);

            // To-do: If curve vertices exist but only reversed, skip this element instead and return the ReverseCurve
            if (datasetCurve == default) {
                var first = dataset?.GetOrCreateStartPoint(coordinates, name, identifier);
                var last = dataset?.GetOrCreateEndPoint(coordinates, name, identifier);
                var curveName = identifier == 0 ? $"C{name}" : $"C{name}-{identifier}";
                //var curveName = $"C{name}-{identifier}";

                var curve = new Curve(first!, last!, coordinates) {
                    Name = curveName,
                };

                dataset!.AddCurve(curve);

                return curve;
            }
            else {
                // Nessecary?
                //dataset.UpdateReferences($"C{name}", datasetCurve.Name);
                return datasetCurve!;
            }
        }

        public static Point GetOrCreateStartPoint(this Dataset dataset, Coordinate[] curve, string name, int identifier = 0) {
            var datasetPoint = dataset?.Points?.FirstOrDefault(e => e.Coordinate!.X == curve[0].X && e.Coordinate!.Y == curve[0].Y);

            if (datasetPoint == default) {
                var point = new Point(curve[0].X, curve[0].Y) {
                    Name = $"P{name}-{identifier}"
                };

                dataset!.AddPoint(point);

                return point;
            }
            else {
                return datasetPoint;
            }
        }

        public static Point GetOrCreateEndPoint(this Dataset dataset, Coordinate[] curve, string name, int identifier = 1) {
            var datasetPoint = dataset?.Points?.FirstOrDefault(e => e.Coordinate!.X == curve[^1].X && e.Coordinate!.Y == curve[^1].Y);

            if (datasetPoint == default) {
                var pointName = $"P{name}-{identifier}";
                var point = new Point(curve[^1].X, curve[^1].Y) {
                    Name = pointName
                };

                dataset!.AddPoint(point);

                return point;
            }
            else {
                return datasetPoint;
            }
        }

        public static Coordinate[] BuildCoordinateFromStringArray(string[] curvesStr) {
            var coordinates = new List<Coordinate>();

            for (int i = 0; i < curvesStr.Length; i += 2) {
                _ = Double.TryParse(curvesStr[i], CultureInfo.InvariantCulture, out double x);
                _ = Double.TryParse(curvesStr[i + 1], CultureInfo.InvariantCulture, out double y);

                coordinates.Add(new(x, y));
            }

            return coordinates.ToArray();
        }
    }
}

namespace ArcGIS.Core.Data
{
    using GeoAPI.Geometries;
    using NetTopologySuite.Geometries;
    using System.Collections.Concurrent;
    using System.Linq;

    internal static class Extension
    {
        static SpatialReference spatialReference = SpatialReferenceBuilder.CreateSpatialReference(4326);

        static GeometryFactory factory = new GeometryFactory(new PrecisionModel(10000000)); // Or PrecisionModels.Floating
        //static GeometryFactory factory = new GeometryFactory(new PrecisionModel(PrecisionModels.Floating)); // Or PrecisionModels.Floating

        public static S100Framework.YAML.Matrix? BuildTopology(this Geodatabase geodatabase, QueryFilter? queryFilter = default) {
            queryFilter = queryFilter switch {
                SpatialQueryFilter spatial => new SpatialQueryFilter {
                    FilterGeometry = spatial.FilterGeometry,
                    ObjectIDs = spatial.ObjectIDs,
                    Offset = spatial.Offset,
                    OutputSpatialReference = spatial.OutputSpatialReference,
                    PostfixClause = spatial.PostfixClause,
                    PrefixClause = spatial.PrefixClause,
                    RowCount = spatial.RowCount,
                    SearchOrder = spatial.SearchOrder,
                    SpatialRelationship = spatial.SpatialRelationship,
                    SpatialRelationshipDescription = spatial.SpatialRelationshipDescription,
                    SubFields = spatial.SubFields,
                    WhereClause = $"({spatial.WhereClause})",
                },
                QueryFilter filter => new QueryFilter {
                    ObjectIDs = filter.ObjectIDs,
                    Offset = filter.Offset,
                    OutputSpatialReference = filter.OutputSpatialReference,
                    PostfixClause = filter.PostfixClause,
                    PrefixClause = filter.PrefixClause,
                    RowCount = filter.RowCount,
                    SubFields = filter.SubFields,
                    WhereClause = filter.WhereClause,
                },
                _ => new QueryFilter {
                    WhereClause = "upper(ps) = 'S-101'",
                },
            };

            var whereClause = queryFilter.WhereClause;
            var prefix = queryFilter.PrefixClause;

            S100Framework.YAML.Matrix topology = new S100Framework.YAML.Matrix {
                Factory = factory,
            };

            var definitions = geodatabase.GetDefinitions<FeatureClassDefinition>();

            //  Skin of Earth
            {
                var curves = new List<S100Framework.YAML.Polyline>();

                using (var curve = geodatabase.OpenDataset<FeatureClass>(definitions.Single(e => e.GetAliasName().Equals("curve")).GetName())) {
                    queryFilter.WhereClause = (!string.IsNullOrEmpty(whereClause) ? $"{whereClause} AND " : "") + $"(upper(code) IN ('COASTLINE','DEPTHCONTOUR','SHORELINECONSTRUCTION'))";

                    using var cursor = curve.Search(queryFilter);

                    while (cursor.MoveNext()) {
                        var f = (Feature)cursor.Current;

                        var shape = (ArcGIS.Core.Geometry.Polyline)f.GetShape();

                        var name = Convert.ToString(f["name"]);
                        if (string.IsNullOrEmpty(name))
                            name = string.Empty;

                        var coordinates = shape.Points.Select(segment => new Coordinate(segment.X, segment.Y)).ToArray();

                        var linestring = (LineString)factory.CreateLineString([.. coordinates]);
                        linestring = linestring.RemoveRepeatedVertices();

                        curves.Add(new S100Framework.YAML.Polyline(f.GetObjectID(), name, linestring));
                    }
                }

                //foreach (var c in curves) {
                //    for (int i = 0; i < c.LineString.Coordinates.Length - 1; i++) {
                //        if (c.LineString.Coordinates[i].Equals(c.LineString.Coordinates[i + 1])) System.Diagnostics.Debugger.Break();
                //    }
                //}

                var polygons = new List<S100Framework.YAML.Polygon>();

                using (var surface = geodatabase.OpenDataset<FeatureClass>(definitions.Single(e => e.GetAliasName().Equals("surface")).GetName())) {
                    queryFilter.WhereClause = (!string.IsNullOrEmpty(whereClause) ? $"{whereClause} AND " : "") + $"(upper(code) IN ('DEPTHAREA','DREDGEDAREA','LANDAREA','UNSURVEYEDAREA'))";

                    using var cursor = surface.Search(queryFilter);

                    while (cursor.MoveNext()) {
                        var f = (Feature)cursor.Current;

                        var shape = (ArcGIS.Core.Geometry.Polygon)f.GetShape();

                        var name = Convert.ToString(f["name"]);
                        if (string.IsNullOrEmpty(name))
                            name = string.Empty;

                        var exteriorRing = shape.GetExteriorRing(0);
                        var coordinates = exteriorRing.Parts[0].Select(segment => new Coordinate(segment.StartPoint.X, segment.StartPoint.Y)).ToArray();

                        var ex = (LineString)factory.CreateLineString([.. coordinates, coordinates[0]]);
                        ex = ex.RemoveRepeatedVertices();

                        if (shape.PartCount > 1) {
                            var interiorRings = new List<LineString>();

                            foreach (var interiorRing in shape.Parts.Skip(1)) {
                                coordinates = interiorRing.Select(segment => new Coordinate(segment.StartPoint.X, segment.StartPoint.Y)).ToArray();

                                var linestring = (LineString)factory.CreateLineString([.. coordinates, coordinates[0]]);
                                linestring = linestring.RemoveRepeatedVertices();
                                interiorRings.Add(linestring);
                            }

                            polygons.Add(new S100Framework.YAML.Polygon(f.GetObjectID(), name, ex, interiorRings.ToArray()));
                        }
                        else {
                            polygons.Add(new S100Framework.YAML.Polygon(f.GetObjectID(), name, ex, []));
                        }
                    }
                }

                //foreach (var c in polygons) {
                //    var coordinates = c.ExteriorRing.Coordinates;

                //    for (int i = 0; i < coordinates.Length - 1; i++) {
                //        if (coordinates[i].Equals(coordinates[i + 1])) System.Diagnostics.Debugger.Break();
                //    }

                //    foreach (var r in c.InteriorRings) {
                //        coordinates = r.Coordinates;

                //        for (int i = 0; i < coordinates.Length - 1; i++) {
                //            if (coordinates[i].Equals(coordinates[i + 1])) System.Diagnostics.Debugger.Break();
                //        }
                //    }
                //}

                int count = polygons.Count();

                topology.BuildTopology(curves.ToArray(), polygons.ToArray());
            }

            //  Everything else
            {
                var curves = new List<S100Framework.YAML.Polyline>();

                using (var curve = geodatabase.OpenDataset<FeatureClass>(definitions.Single(e => e.GetAliasName().Equals("curve")).GetName())) {
                    queryFilter.WhereClause = (!string.IsNullOrEmpty(whereClause) ? $"{whereClause} AND " : "") + $"(upper(code) NOT IN ('COASTLINE','DEPTHCONTOUR','SHORELINECONSTRUCTION'))";

                    using var cursor = curve.Search(queryFilter);

                    while (cursor.MoveNext()) {
                        var f = (Feature)cursor.Current;

                        var shape = (ArcGIS.Core.Geometry.Polyline)f.GetShape();

                        var name = Convert.ToString(f["name"]);
                        if (string.IsNullOrEmpty(name))
                            name = string.Empty;

                        var coordinates = shape.Points.Select(segment => new Coordinate(segment.X, segment.Y)).ToArray();

                        var linestring = (LineString)factory.CreateLineString([.. coordinates]);
                        linestring = linestring.RemoveRepeatedVertices();

                        curves.Add(new S100Framework.YAML.Polyline(f.GetObjectID(), name, linestring));
                    }
                }

                var polygons = new List<S100Framework.YAML.Polygon>();

                using (var surface = geodatabase.OpenDataset<FeatureClass>(definitions.Single(e => e.GetAliasName().Equals("surface")).GetName())) {
                    queryFilter.WhereClause = (!string.IsNullOrEmpty(whereClause) ? $"{whereClause} AND " : "") + $"(upper(code) NOT IN ('DEPTHAREA','DREDGEDAREA','LANDAREA','UNSURVEYEDAREA'))";

                    using var cursor = surface.Search(queryFilter);

                    while (cursor.MoveNext()) {
                        var f = (Feature)cursor.Current;

                        var shape = (ArcGIS.Core.Geometry.Polygon)f.GetShape();

                        var name = Convert.ToString(f["name"]);
                        if (string.IsNullOrEmpty(name))
                            name = string.Empty;

                        var exteriorRing = shape.GetExteriorRing(0);
                        var coordinates = exteriorRing.Parts[0].Select(segment => new Coordinate(segment.StartPoint.X, segment.StartPoint.Y)).ToArray();

                        var ex = (LineString)factory.CreateLineString([.. coordinates, coordinates[0]]);
                        ex = ex.RemoveRepeatedVertices();

                        if (shape.PartCount > 1) {
                            var interiorRings = new List<LineString>();

                            foreach (var interiorRing in shape.Parts.Skip(1)) {
                                coordinates = interiorRing.Select(segment => new Coordinate(segment.StartPoint.X, segment.StartPoint.Y)).ToArray();

                                var linestring = (LineString)factory.CreateLineString([.. coordinates, coordinates[0]]);
                                linestring = linestring.RemoveRepeatedVertices();
                                interiorRings.Add(linestring);
                            }

                            polygons.Add(new S100Framework.YAML.Polygon(f.GetObjectID(), name, ex, interiorRings.ToArray()));
                        }
                        else {
                            polygons.Add(new S100Framework.YAML.Polygon(f.GetObjectID(), name, ex, []));
                        }
                    }
                }

                int count = polygons.Count();

                topology.Build(curves.ToArray(), polygons.ToArray());
            }

            Log.Verbose("Topology: #{curves}, #{composites}, #{surfaces}", topology.Curves.Count, topology.CompositeCurves.Count, topology.Surfaces.Count);
            return topology;
        }

    }
}