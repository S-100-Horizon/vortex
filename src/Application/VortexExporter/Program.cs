using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using CommandLine;
using S100Framework.DomainModel;
using S100Framework.YAML;
using Serilog;
using System.Diagnostics;
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
            public string? Dataset { get; set; } = default;

            [Option('g', "geodatabase", Required = true, HelpText = "Geodatabase.")]
            public string Geodatabase { get; set; } = string.Empty;

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
                });

                var shape = GeometryEngine.Instance.ImportFromJson(JsonImportFlags.JsonImportDefaults, jsonSurface);

                using Geodatabase source = createGeodatabase();

                var featureCatalogue = S100Framework.Catalogues.FeatureCatalogue.Catalogues.Single(e => e.ProductID.Equals("S-101"));

                Dataset dataset;
                if (string.IsNullOrEmpty(dsnm)) {
                    dataset = new Dataset {
                        CellName = "101DK40349E.000",
                        Comment = "Not for navigation!",
                        Edition = 1,
                        ENCVer = "INT.IHO.S-101.2.0",
                        FCVer = "2.0.0",
                    };
                }
                else {
                    using var surface = source.OpenDataset<FeatureClass>("surface");

                    using var cursor = surface.Search(new QueryFilter {
                        WhereClause = $"upper(ps) = 'S-128' and JSON LIKE '%\"datasetName\":\"{dsnm.ToUpperInvariant()}\"%'",
                    }, true);

                    cursor.MoveNext();
                    var current = (ArcGIS.Core.Data.Feature)cursor.Current;

                    var electricProduct = System.Text.Json.JsonSerializer.Deserialize<S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct>(Convert.ToString(current["json"])!);

                    dataset = new Dataset {
                        CellName = electricProduct!.datasetName!,
                        Comment = "Not for navigation!",
                        Edition = 1,
                        ENCVer = "INT.IHO.S-101.2.0",
                        FCVer = "2.0.0",
                    };

                    var polygon = (ArcGIS.Core.Geometry.Polygon)current.GetShape();
                    var json = polygon.ToJson();

                    shape = GeometryEngine.Instance.ImportFromJson(JsonImportFlags.JsonImportDefaults, json);
                }

                var filter = new SpatialQueryFilter {
                    FilterGeometry = shape,
                    SpatialRelationship = SpatialRelationship.Relation,
                    SpatialRelationshipDescription = "T*****FF*",
                    WhereClause = "upper(ps) = 'S-101'",
                    //WhereClause = "upper(ps) = 'S-101' and upper(code) IN ('DEPTHAREA','DREDGEDAREA','LANDAREA','UNSURVEYEDAREA')",
                };



                var geometries = new List<(Geometry geometry, string name)>();
                var featureAssociations = new Dictionary<string, YAML.Association[]>();

                // Build Topology
                Log.Information("Building topology..");
                var topology = source.BuildTopology(filter);

                Log.Information("Topology finished! Found {curves} Curves, {composites} CompositeCurves, {surfaces} Surfaces", topology!.Curves.Count, topology.CompositeCurves.Count, topology.Surfaces.Count);
                dataset.AddTopology(topology);


                // FeatureAssociations - Only typeof associations. Skip composition/aggregation roleTypes for now
                try {
                    using var type = source.OpenDataset<Table>("associationbinding");

                    using var cursor = type.Search(new QueryFilter {
                        WhereClause = "UPPER(type) = 'FEATUREBINDING' AND UPPER(roleType) = 'ASSOCIATION'"
                    });

                    while (cursor.MoveNext()) {
                        var current = cursor.Current;

                        var name = current["association"].ToString()!;
                        var role = current["role"].ToString()!;

                        var id = current["pid"].ToString()!;
                        var to = current["foreignid"].ToString()!;

                        if (topology.Mapping.TryGetValue(to, out var value))
                            to = value;

                        var foid = $"110:{to![1..]}:1";       // Geodatastyrelsen: 110 

                        var association = new YAML.Association() {
                            Name = name,
                            Role = role,
                            To = foid,
                        };

                        // Add or update
                        if (featureAssociations.TryGetValue(id, out var existingArray))
                            featureAssociations[id] = [.. existingArray, association];
                        else
                            featureAssociations[id] = [association];
                    }
                }
                catch (Exception ex) {
                    Log.Information("Table: associationbinding: {message} ", ex.Message);
                    Logger.Current.Error("Exception: {ex}", ex);
                }

                Log.Information("FeatureAssociations found: #{count}", featureAssociations.Count);

                // InformationTypes
                try {
                    using var informationType = source.OpenDataset<Table>("informationtype");
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
                    var tableName = def.GetName();

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
                        var geometry = Convert.ToString(current["name"]);

                        if (topology.Mapping.TryGetValue(geometry!, out var value))
                            geometry = value;

                        var shapetype = def.GetShapeType();

                        var name = Convert.ToString(current["code"]);

                        var foid = $"110:{geometry!.Substring(1)}:1";       // Geodatastyrelsen: 110 

                        var prim = shapetype switch {
                            GeometryType.Point => Primitive.Point,
                            GeometryType.Multipoint => Primitive.Point,
                            GeometryType.Polyline => Primitive.Curve,
                            GeometryType.Polygon => Primitive.Surface,
                            _ => throw new InvalidOperationException(),
                        };

                        try {
                            var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace("S101", "FeatureTypes")}.{name}", true) ?? default;

                            if (type == default)
                                continue;

                            var instance = DBNull.Value.Equals(current["json"]) ? null : System.Text.Json.JsonSerializer.Deserialize(Convert.ToString(current["json"])!, type);

                            var feature = new YAML.Feature {
                                Name = name,
                                Foid = foid,
                                Prim = prim,
                                Geometry = geometry,
                            };

                            // Only emit attributes if feature contains any non-static properties
                            if (!S100Framework.YAML.Converter.IsDefault(instance!))
                                feature.Attributes = (FeatureNode)instance!;

                            // FeatureAssociations
                            var hasAssociations = featureAssociations.TryGetValue(geometry, out var associations);

                            if (hasAssociations) {
                                foreach (var asso in associations!) {
                                    feature.AddFeatureAssociation(asso);
                                }
                            }

                            dataset.AddFeature(feature);

                            geometries.Add(new(current.GetShape(), geometry!));
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

                File.WriteAllText(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"101DK40349E.yaml"), yaml);
                File.WriteAllText(IO.Path.Combine(@"c:\temp", $"101DK40349E.yaml"), yaml);

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
    using ArcGIS.Core.Internal.CIM;
    using NetTopologySuite.Densify;
    using NetTopologySuite.Geometries;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using System.Text.RegularExpressions;
    using System.Xml.Linq;

    public class FeatureRef
    {
        public UInt64 Id { get; init; }
        public bool Reverse { get; init; } = false;
    }

    public abstract class FeatureType
    {
        public static UInt64 counter = 1;

        //public int Id { get; init; } = Interlocked.Increment(ref counter);
        public required UInt64 Id { get; init; }
    }

    public class CurveFeature : FeatureType
    {
        public CurveFeature(LineString lineString) {
            this.LineString = lineString;
            this.LineStringReverse = (LineString)lineString.Reverse();

            this.LineStringText = lineString.ToString();
            this.LineStringReverseText = this.LineStringReverse.ToString();
        }

        public LineString LineString { get; set; }

        public LineString LineStringReverse { get; set; }

        public string LineStringText { get; init; }
        public string LineStringReverseText { get; init; }

        public bool Equals(CurveFeature lineString) {
            if (lineString.LineStringText.Equals(this.LineStringText))
                return true;
            return false;
        }

        public bool Equals(LineString lineString) {
            if (lineString.ToString().Equals(this.LineStringText))
                return true;
            return false;
        }

        public override bool Equals(object? obj) {
            if (obj is CurveFeature curve)
                return (this.Equals(curve));
            if (obj is LineString lineString)
                return (this.Equals(lineString));
            return base.Equals(obj);
        }

        public override int GetHashCode() {
            return (int)System.IO.Hashing.XxHash32.HashToUInt32(this.LineString.ToBinary());
        }
    }

    public class CompositeCurveFeature : FeatureType
    {
        public FeatureRef[] Curves { get; init; } = [];
    }

    public class SurfaceFeature : FeatureType
    {
        public required FeatureRef Exterior { get; init; }

        public FeatureRef[]? Interior { get; init; } = default;

        public string? Ref { get; init; } = default;

        public LineString? LineString { get; set; } = default;
    }

    public record Polyline(long ObjectId, string name, LineString LineString);

    public record Polygon(long ObjectId, string name, LineString ExteriorRing, LineString[] InteriorRings) : Polyline(ObjectId, name, ExteriorRing);

    public class Topology
    {
        public required IList<CurveFeature> Curves { get; set; }

        public required IList<CompositeCurveFeature> CompositeCurves { get; set; }

        public required IList<SurfaceFeature> Surfaces { get; set; }

        public required IDictionary<string, string> Mapping { get; set; }
    }


    public static class Extension
    {
        public static void AddGeometry(this Dataset dataset, ArcGIS.Core.Geometry.Geometry geometry, string name) {
            switch (geometry) {
                case ArcGIS.Core.Geometry.MapPoint point: {                              // Point
                        //var datasetPoint = dataset?.Points?.FirstOrDefault(e => e.Coordinate?.X == point.X && e?.Coordinate?.Y == point.Y);
                        //// Create point if not exist
                        //if (datasetPoint == default) {
                        var p = new Point(point.X, point.Y) {
                            Name = $"{name}"
                        };

                        dataset!.AddPoint(p);
                        //}
                        //else {
                        //    dataset!.UpdateFeatureReferences(name, datasetPoint!.Name);
                        //}
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

        public static void AddTopology(this Dataset dataset, Topology topology) {
            // Curves
            CurveFeature? curveFeature = default;
            try {
                Log.Information("Adding curve #{count}", topology.Curves.Count());

                var concurrent = new ConcurrentBag<Curve>();

                foreach (var c in topology.Curves) {
                    curveFeature = c;

                    if (c.Id == 11053918727594573033) System.Diagnostics.Debugger.Break();

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
                Log.Information("Adding compositecurve #{count}", topology.CompositeCurves.Count());

                foreach (var c in topology.CompositeCurves) {
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
                Log.Information("Adding surface #{count}", topology.Surfaces.Count());

                foreach (var s in topology.Surfaces) {
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
                Log.Information("Error! Original cant be same as target!");
                return;
            }

            foreach (var feature in dataset?.Features?.Where(e => e.Geometry == original) ?? []) {
                Log.Information("  - Updating feature geometry reference with original {original} and target: {target}", original, target);
                feature.Geometry = target;

                // Associations
                foreach (var ass in feature?.FeatureAssociation ?? []) {
                    if (ass?.To?.Contains(original) ?? false) {
                        Log.Information("  - Updating feature association reference with original {original} and target: {target}", original, target);
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

        //static GeometryFactory factory = new GeometryFactory(new PrecisionModel(10000000)); // Or PrecisionModels.Floating
        static GeometryFactory factory = new GeometryFactory(new PrecisionModel(PrecisionModels.Floating)); // Or PrecisionModels.Floating

        public static S100Framework.YAML.Topology? BuildTopology(this Geodatabase geodatabase, QueryFilter? queryFilter = default) {
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

            S100Framework.YAML.Topology topology = new S100Framework.YAML.Topology {
                Curves = new List<CurveFeature>(),
                CompositeCurves = new List<CompositeCurveFeature>(),
                Surfaces = new List<SurfaceFeature>(),
                Mapping = new Dictionary<string, string>(),
            };

            var curves = new List<S100Framework.YAML.Polyline>();

            using (var curve = geodatabase.OpenDataset<FeatureClass>("curve")) {
                queryFilter.WhereClause = $"{whereClause}";

                using var cursor = curve.Search(queryFilter);

                while (cursor.MoveNext()) {
                    var f = (Feature)cursor.Current;

                    var shape = (ArcGIS.Core.Geometry.Polyline)f.GetShape();

                    var name = Convert.ToString(f["name"]);
                    if (string.IsNullOrEmpty(name))
                        name = string.Empty;

                    var coordinates = shape.Points.Select(segment => new Coordinate(segment.X, segment.Y)).ToArray();

                    var linestring = (LineString)factory.CreateLineString([.. coordinates]);

                    curves.Add(new S100Framework.YAML.Polyline(f.GetObjectID(), name, linestring));
                }
            }

            var polygons = new List<S100Framework.YAML.Polygon>();

            using (var surface = geodatabase.OpenDataset<FeatureClass>("surface")) {
                //queryFilter.WhereClause = $"{whereClause} AND (upper(code) IN ('DEPTHAREA','DREDGEDAREA','LANDAREA','UNSURVEYEDAREA'))";
                queryFilter.WhereClause = $"{whereClause}";

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

                    if (shape.PartCount > 1) {
                        var interiorRings = new List<LineString>();

                        foreach (var interiorRing in shape.Parts.Skip(1)) {
                            coordinates = interiorRing.Select(segment => new Coordinate(segment.StartPoint.X, segment.StartPoint.Y)).ToArray();

                            interiorRings.Add((LineString)factory.CreateLineString([.. coordinates, coordinates[0]]));
                        }

                        polygons.Add(new S100Framework.YAML.Polygon(f.GetObjectID(), name, ex, interiorRings.ToArray()));
                    }
                    else {
                        polygons.Add(new S100Framework.YAML.Polygon(f.GetObjectID(), name, ex, []));
                    }
                }
            }

            int count = polygons.Count();
            Log.Information("Total #{polylines}, #{polygons}", curves.Count, polygons.Count);

            var t = new S100Framework.YAML.Topology {
                Curves = new List<CurveFeature>(),
                CompositeCurves = new List<CompositeCurveFeature>(),
                Surfaces = new List<SurfaceFeature>(),
                Mapping = new Dictionary<string, string>(),
            };

            AppendTopology(curves.ToArray(), polygons.ToArray(), t);

            if (t.Curves.Any())
                topology.Curves = topology.Curves.Union(t.Curves).ToList();
            if (t.CompositeCurves.Any())
                topology.CompositeCurves = topology.CompositeCurves.Union(t.CompositeCurves).ToList();
            if (t.Surfaces.Any())
                topology.Surfaces = topology.Surfaces.Union(t.Surfaces).ToList();
            if (t.Mapping.Any())
                topology.Mapping = topology.Mapping.Union(t.Mapping).ToDictionary(e => e.Key, e => e.Value);

            Log.Verbose("Topology: #{curves}, #{composites}, #{surfaces}", topology.Curves.Count, topology.CompositeCurves.Count, topology.Surfaces.Count);
            return topology;
        }

        private static void AppendTopology(S100Framework.YAML.Polyline[] polylines, S100Framework.YAML.Polygon[] polygons, S100Framework.YAML.Topology topology) {
            int count = polygons.Count();

            var equalsList = new List<string>();
            var equalsDictionary = new Dictionary<string, List<CurveFeature>>();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var matchPolylines = new ConcurrentDictionary<string, List<LineString>>();

            for (int i = 0; i < polylines.Length; i++) {
                matchPolylines.GetOrAdd(polylines[i].name, []);
            }

            var matchPolygons = new ConcurrentDictionary<string, (List<LineString> exterior, List<LineString>[] interior)>();

            for (int i = 0; i < polygons.Length; i++) {
                matchPolygons.GetOrAdd(polygons[i].name, ([], []));
            }

            var options = new ParallelOptions {
                MaxDegreeOfParallelism = 8,
            };

            var curvePolygons = new Dictionary<UInt64, LineString>();

            var curvePolygonsToObjectId = new Dictionary<UInt64, string>();

            Log.Verbose("Loading...");

            foreach (var e in polygons) {
                var hash = IO.Hashing.XxHash64.HashToUInt64(e.ExteriorRing.ToBinary());
                var reverse = IO.Hashing.XxHash64.HashToUInt64(((LineString)e.ExteriorRing.Reverse()).ToBinary());
                if (!(curvePolygons.ContainsKey(hash) || curvePolygons.ContainsKey(reverse))) {
                    curvePolygons.Add(hash, e.LineString);
                    curvePolygonsToObjectId.Add(hash, $"e:{e.ObjectId}");
                }
                int index = 0;
                foreach (var i in e.InteriorRings) {
                    hash = IO.Hashing.XxHash64.HashToUInt64(i.ToBinary());
                    reverse = IO.Hashing.XxHash64.HashToUInt64(((LineString)i.Reverse()).ToBinary());
                    if (!(curvePolygons.ContainsKey(hash) || curvePolygons.ContainsKey(reverse))) {
                        curvePolygons.Add(hash, i);
                        curvePolygonsToObjectId.Add(hash, $"i{++index}{e.ObjectId}");
                    }
                }
            }

            //  --- TEST --------------------------------------------------------------
            {
                //var graph = new EdgeGraphBuilder();
                //graph.Add(curvePolygons.Values);

                //var edge = graph.GetGraph();

                //var boundary1 = polygons.Single(e => e.ObjectId == 159569).ExteriorRing;

                //var boundary2 = polygons.Single(e => e.ObjectId == 159577).ExteriorRing;

                //var intersection = boundary1.Intersection(boundary2);

                //var list = new List<LineString> {
                //    //boundary1,
                //    //boundary2
                //};

                //intersection = intersection.Combine();

                //AddLineStringsFromGeometry(intersection, list);

                //var difference = boundary1.SymmetricDifference(intersection);

                //AddLineStringsFromGeometry(difference, list);

                //using (var target = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri($"file://{IO.Path.GetFullPath(@".\..\..\..\..\..\artifacts\s100ed6.gdb")}")))) {
                //    ulong id = 0;
                //    target.PersistTopology(list.Select(e => new CurveFeature(e) { Id = id++ }).ToArray());
                //}

                //throw new NotImplementedException();
            }



            Log.Verbose("Intersection...");

            //options = new ParallelOptions {
            //    MaxDegreeOfParallelism = 1,
            //};

            Parallel.For(0, polygons.Length, options, (i) => {
                //if (polygons[i].ObjectId != 160361) return;
                //if (polygons[i].ObjectId == 160361) System.Diagnostics.Debugger.Break();

                {
                    IGeometry boundary1 = polygons[i].ExteriorRing;

                    var geometries = new List<LineString>();

                    for (var j = 0; j < polygons.Length; j++) {
                        if (j == i) continue;

                        var boundary2 = polygons[j].ExteriorRing;

                        if (boundary1.Disjoint(boundary2))
                            continue;

                        var contains = boundary1.Contains(boundary2);
                        var coveredby = boundary1.CoveredBy(boundary2);
                        var covers = boundary1.Covers(boundary2);
                        var crosses = boundary1.Crosses(boundary2);
                        var intersects = boundary1.Intersects(boundary2);
                        var overlaps = boundary1.Overlaps(boundary2);
                        //var touches = boundary1.Touches(boundary2);
                        //var within = boundary1.Within(boundary2);
                        //var equalsTopologically = boundary1.EqualsTopologically(boundary2);
                        //var relate = boundary1.Relate(boundary2, "1********");

                        //if (!(contains || equalsTopologically || overlaps))
                        //    continue;

                        if ((crosses && intersects) && !(contains | overlaps | coveredby))
                            continue;

                        var intersection = boundary1.Intersection(boundary2);

                        if (intersection is GeometryCollection geometryCollection) {
                            intersection = intersection.Factory.CreateMultiLineString(geometryCollection.OfType<LineString>().ToArray());
                        }

                        if (intersection == null || intersection.IsEmpty) continue;

                        intersection = intersection.Combine();

                        AddLineStringsFromGeometry(intersection, matchPolygons[polygons[i].name].exterior);

                        boundary1 = boundary1.SymmetricDifference(intersection);
                    }

                    var g = factory.CreateMultiLineString(matchPolygons[polygons[i].name].exterior.ToArray());

                    var diff = boundary1.SymmetricDifference(g);
                    if (!(diff == null || diff.IsEmpty))
                        AddLineStringsFromGeometry(diff, matchPolygons[polygons[i].name].exterior);
                }

                if (polygons[i].InteriorRings.Any()) {
                    var indexOf = polygons[i].name;

                    matchPolygons[polygons[i].name] = matchPolygons[polygons[i].name] with {
                        interior = new List<LineString>[polygons[i].InteriorRings.Length],
                    };

                    UInt64[] exclude = [IO.Hashing.XxHash64.HashToUInt64(polygons[i].ExteriorRing.ToBinary())];
                    exclude = [.. exclude, .. polygons[i].InteriorRings.Select(e => IO.Hashing.XxHash64.HashToUInt64(e.ToBinary()))];

                    for (int k = 0; k < polygons[i].InteriorRings.Length; k++) {
                        IGeometry boundary = (LineString)polygons[i].InteriorRings[k];//.Reverse();

                        //var hash = IO.Hashing.XxHash64.HashToUInt64(((LineString)polygons[i].InteriorRings[k]).ToBinary());

                        var interiorLineStrings = new List<LineString>();

                        foreach (var e in curvePolygons.Where(e => !exclude.Contains(e.Key))) {
                            var boundary2 = e.Value;

                            if (boundary.Disjoint(boundary2))
                                continue;

                            var contains = boundary.Contains(boundary2);
                            var coveredby = boundary.CoveredBy(boundary2);
                            var covers = boundary.Covers(boundary2);
                            var crosses = boundary.Crosses(boundary2);
                            var intersects = boundary.Intersects(boundary2);
                            var overlaps = boundary.Overlaps(boundary2);
                            //var touches = boundary.Touches(boundary2);
                            //var within = boundary.Within(boundary2);

                            if ((crosses && intersects) && !(contains | overlaps | coveredby))
                                continue;

                            var intersection = boundary.Intersection(boundary2);

                            if (intersection is GeometryCollection geometryCollection) {
                                intersection = intersection.Factory.CreateMultiLineString(geometryCollection.OfType<LineString>().ToArray());
                            }

                            if (intersection == null || intersection.IsEmpty) continue;

                            intersection = intersection.Combine();

                            AddLineStringsFromGeometry(intersection, interiorLineStrings);

                            boundary = boundary.SymmetricDifference(intersection);
                        }
                        if (!interiorLineStrings.Any())
                            interiorLineStrings.Add((LineString)polygons[i].InteriorRings[k]);
                        else {
                            var g = factory.CreateMultiLineString(interiorLineStrings.ToArray());

                            var diff = boundary.SymmetricDifference(g);

                            if (!(diff == null || diff.IsEmpty))
                                AddLineStringsFromGeometry(diff, interiorLineStrings);
                        }
                        matchPolygons[polygons[i].name].interior[k] = interiorLineStrings;
                    }
                }
            });

            //options = new ParallelOptions {
            //    MaxDegreeOfParallelism = 1,
            //};

            Parallel.For(0, polylines.Length, options, (i) => {
                var m = matchPolylines[polylines[i].name];

                IGeometry boundary1 = polylines[i].LineString;

                var hash = IO.Hashing.XxHash3.HashToUInt64(polylines[i].LineString.ToBinary());

                foreach (var e in curvePolygons.Where(e => e.Key != hash)) {
                    var boundary2 = e.Value;
                    if (boundary1.Disjoint(boundary2))
                        continue;
                    //if (boundary1.Equals(boundary2))
                    //    continue;

                    var contains = boundary1.Contains(boundary2);
                    var coveredby = boundary1.CoveredBy(boundary2);
                    var covers = boundary1.Covers(boundary2);
                    var crosses = boundary1.Crosses(boundary2);
                    var intersects = boundary1.Intersects(boundary2);
                    var overlaps = boundary1.Overlaps(boundary2);
                    //var touches = boundary1.Touches(boundary2);
                    //var within = boundary1.Within(boundary2);

                    if ((crosses && intersects) && !(contains | overlaps | coveredby))
                        continue;

                    if (!(boundary1.Overlaps(boundary2) || boundary1.Contains(boundary2))) continue;

                    var intersection = boundary1.Intersection(boundary2);

                    if (intersection is GeometryCollection geometryCollection) {
                        intersection = intersection.Factory.CreateMultiLineString(geometryCollection.OfType<LineString>().ToArray());
                    }

                    if (intersection == null || intersection.IsEmpty) continue;

                    intersection = intersection.Combine();

                    AddLineStringsFromGeometry(intersection, m);

                    boundary1 = boundary1.SymmetricDifference(intersection);
                }
                if (!m.Any()) {
                    m.Add(polylines[i].LineString);
                }
                else {
                    var g = factory.CreateMultiLineString(m.ToArray());

                    var diff = boundary1.SymmetricDifference(g);
                    if (!(diff == null || diff.IsEmpty))
                        AddLineStringsFromGeometry(diff, m);
                }
            });

            var mapping = new ConcurrentDictionary<string, string>();

            Log.Verbose("Hashing...");

            var hashing = new Dictionary<ulong, (FeatureRef fetureRef, CurveFeature curve)>();

            foreach (var m in matchPolygons) {
                //if("S688985".Equals(m.Key)) System.Diagnostics.Debugger.Break();
                //if (m.Key.Equals("S238034")) System.Diagnostics.Debugger.Break();

                if (m.Value.exterior.Count < 2) {
                    var origin = polygons.Single(e => e.name == m.Key);

                    var hash = System.IO.Hashing.XxHash3.HashToUInt64(origin.LineString.AsBinary());
                    var f = new CurveFeature(origin.LineString) {
                        //Id = hash,
                        Id = Interlocked.Increment(ref FeatureType.counter),
                    };
                    if (!hashing.ContainsKey(hash)) {
                        hashing.Add(hash, (new FeatureRef {
                            Id = f.Id,
                            Reverse = false,
                        }, f));

                        hash = System.IO.Hashing.XxHash3.HashToUInt64(f.LineString.Reverse().AsBinary());
                        hashing.Add(hash, (new FeatureRef {
                            Id = f.Id,
                            Reverse = true,
                        }, f));
                    }
                }
                else {
                    foreach (var l in m.Value.exterior) {
                        var hash = System.IO.Hashing.XxHash3.HashToUInt64(l.AsBinary());
                        var f = new CurveFeature(l) {
                            //Id = hash,
                            Id = Interlocked.Increment(ref FeatureType.counter),
                        };
                        if (!hashing.ContainsKey(hash)) {
                            hashing.Add(hash, (new FeatureRef {
                                Id = f.Id,
                                Reverse = false,
                            }, f));

                            hash = System.IO.Hashing.XxHash3.HashToUInt64(l.Reverse().AsBinary());
                            hashing.Add(hash, (new FeatureRef {
                                Id = f.Id,
                                Reverse = true,
                            }, f));
                        }
                    }
                }
                if (m.Value.interior.Any()) {
                    for (int i = 0; i < m.Value.interior.Length; i++) {
                        foreach (var l in m.Value.interior[i]) {
                            var hash = System.IO.Hashing.XxHash3.HashToUInt64(l.AsBinary());
                            var f = new CurveFeature(l) {
                                //Id = hash,
                                Id = Interlocked.Increment(ref FeatureType.counter),
                            };

                            if (!hashing.ContainsKey(hash)) {
                                hashing.Add(hash, (new FeatureRef {
                                    Id = f.Id,
                                    Reverse = false,
                                }, f));

                                hash = System.IO.Hashing.XxHash3.HashToUInt64(l.Reverse().AsBinary());
                                hashing.Add(hash, (new FeatureRef {
                                    Id = f.Id,
                                    Reverse = true,
                                }, f));
                            }
                        }
                    }
                }
            }

            foreach (var m in matchPolylines) {
                var origin = polylines.Single(e => e.name == m.Key);

                if (m.Value.Count < 2) {
                    var hash = System.IO.Hashing.XxHash3.HashToUInt64(origin.LineString.AsBinary());
                    var f = new CurveFeature(origin.LineString) {
                        //Id = hash,
                        Id = Interlocked.Increment(ref FeatureType.counter),
                    };
                    if (!hashing.ContainsKey(hash)) {
                        hashing.Add(hash, (new FeatureRef {
                            Id = f.Id,
                            Reverse = false,
                        }, f));
                    }
                    hash = System.IO.Hashing.XxHash3.HashToUInt64(f.LineString.Reverse().AsBinary());
                    if (!hashing.ContainsKey(hash)) {
                        hashing.Add(hash, (new FeatureRef {
                            Id = f.Id,
                            Reverse = true,
                        }, f));
                    }
                }
                else {
                    foreach (var l in m.Value) {
                        var hash = System.IO.Hashing.XxHash3.HashToUInt64(l.AsBinary());
                        var f = new CurveFeature(l) {
                            //Id = hash,
                            Id = Interlocked.Increment(ref FeatureType.counter),
                        };
                        if (!hashing.ContainsKey(hash)) {
                            hashing.Add(hash, (new FeatureRef {
                                Id = f.Id,
                                Reverse = false,
                            }, f));
                        }
                        hash = System.IO.Hashing.XxHash3.HashToUInt64(l.Reverse().AsBinary());
                        if (!hashing.ContainsKey(hash)) {
                            hashing.Add(hash, (new FeatureRef {
                                Id = f.Id,
                                Reverse = true,
                            }, f));
                        }
                    }
                }
            }

            Log.Verbose("Matching...");

            var bagCurves = new ConcurrentBag<CurveFeature>();
            //var bagCompositeCurves = new ConcurrentBag<CompositeCurveFeature>();
            var bagCompositeCurves = new ConcurrentDictionary<string, CompositeCurveFeature>();
            var bagSurfaces = new ConcurrentBag<SurfaceFeature>();


            Parallel.ForEach(matchPolygons, options, (m) => {
                var origin = polygons.Single(e => e.name == m.Key);

                FeatureRef exteriorId;

                if (m.Value.exterior.Count < 2) {
                    var tuple = hashing[IO.Hashing.XxHash3.HashToUInt64(origin.LineString.AsBinary())];
                    bagCurves.Add(tuple.curve);
                    exteriorId = tuple.fetureRef;
                }
                else {
                    var polygon = new List<LineString>(m.Value.exterior);

                    //if (origin.ObjectId == 154302) {
                    //    using (var target = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri($"file://{IO.Path.GetFullPath(@".\..\..\..\..\..\artifacts\s100ed6.gdb")}")))) {
                    //        ulong id = 0;
                    //        target.PersistTopology(polygon.Select(e => new CurveFeature(e) { Id = id++ }).ToArray());
                    //    }                        
                    //}
                    //return;

                    var startPoint = origin.ExteriorRing.StartPoint;
                    var endPoint = startPoint;

                    int countSegment = 1;
                    var c = polygon.Single(e => e.StartPoint.EqualsExact(startPoint));

                    var tuple = hashing[IO.Hashing.XxHash3.HashToUInt64(c.AsBinary())];
                    bagCurves.Add(tuple.curve);

                    var sorted = new FeatureRef[polygon.Count];
                    sorted[0] = tuple.fetureRef;

                    do {
                        var next = polygon.Single(e => e != c && e.StartPoint.EqualsExact(c.EndPoint));

                        tuple = hashing[IO.Hashing.XxHash3.HashToUInt64(next.AsBinary())];
                        bagCurves.Add(tuple.curve);

                        sorted[countSegment] = tuple.fetureRef;
                        c = next;

                        countSegment += 1;
                    } while (!c.EndPoint.EqualsExact(endPoint));

                    if (countSegment != polygon.Count)
                        System.Diagnostics.Debugger.Break();

                    var compositeExterior = new CompositeCurveFeature {
                        Id = Interlocked.Increment(ref FeatureType.counter),
                        Curves = [.. sorted],
                    };

                    var key = string.Join(',', sorted.Select(e => e.Reverse ? $"RC{e.Id}" : $"{e.Id}"));

                    compositeExterior = bagCompositeCurves.GetOrAdd(key, (key) => {
                        return compositeExterior;
                    });

                    exteriorId = new FeatureRef {
                        Id = compositeExterior.Id,
                        Reverse = false,
                    };
                }

                if (!m.Value.interior.Any()) {
                    var surface = new SurfaceFeature() {
                        Id = Interlocked.Increment(ref FeatureType.counter),
                        Ref = m.Key,
                        Exterior = exteriorId,
                    };
                    bagSurfaces.Add(surface);
                    mapping.GetOrAdd(m.Key, $"S{surface.Id}");
                }
                else {
                    FeatureRef[]? interiorRings = new FeatureRef[m.Value.interior.Length];
                    for (int i = 0; i < m.Value.interior.Length; i++) {
                        var interiorRing = m.Value.interior[i];

                        if (interiorRing.Count == 1) {
                            var tuple = hashing[IO.Hashing.XxHash3.HashToUInt64(interiorRing[0].AsBinary())];
                            interiorRings[i] = tuple.fetureRef;
                            bagCurves.Add(tuple.curve);
                        }
                        else {
                            var polygon = new List<LineString>(interiorRing);

                            var startPoint = origin.InteriorRings[i].StartPoint;
                            var endPoint = startPoint;

                            int countSegment = 1;
                            var c = polygon.First(e => e.StartPoint.EqualsExact(startPoint));

                            var tuple = hashing[IO.Hashing.XxHash3.HashToUInt64(c.AsBinary())];
                            bagCurves.Add(tuple.curve);

                            var sorted = new FeatureRef[polygon.Count];
                            sorted[0] = tuple.fetureRef;

                            do {
                                var next = polygon.Single(e => e != c && e.StartPoint.EqualsExact(c.EndPoint));
                                tuple = hashing[IO.Hashing.XxHash3.HashToUInt64(next.AsBinary())];
                                bagCurves.Add(tuple.curve);

                                sorted[countSegment] = tuple.fetureRef;
                                c = next;

                                countSegment += 1;
                            } while (!c.EndPoint.EqualsExact(endPoint));

                            if (countSegment != polygon.Count)
                                System.Diagnostics.Debugger.Break();

                            var compositeExterior = new CompositeCurveFeature {
                                Id = Interlocked.Increment(ref FeatureType.counter),
                                Curves = [.. sorted],
                            };

                            var key = string.Join(',', sorted.Select(e => e.Reverse ? $"RC{e.Id}" : $"{e.Id}"));

                            compositeExterior = bagCompositeCurves.GetOrAdd(key, (key) => {
                                return compositeExterior;
                            });

                            interiorRings[i] = new FeatureRef {
                                Id = compositeExterior.Id,
                                Reverse = false,
                            };
                        }
                    }

                    var surface = new SurfaceFeature() {
                        Id = Interlocked.Increment(ref FeatureType.counter),
                        Ref = m.Key,
                        Exterior = exteriorId,
                        Interior = interiorRings,
                    };
                    bagSurfaces.Add(surface);

                    mapping.GetOrAdd(m.Key, $"S{surface.Id}");
                }
            });

            Parallel.ForEach(matchPolylines, options, (m) => {
                var origin = polylines.Single(e => e.name == m.Key);

                FeatureRef featureRef;

                if (m.Value.Count < 2) {
                    var tuple = hashing[IO.Hashing.XxHash3.HashToUInt64(origin.LineString.AsBinary())];
                    bagCurves.Add(tuple.curve);
                    featureRef = tuple.fetureRef;
                }
                else {
                    var polyline = new List<LineString>(m.Value);

                    var startPoint = origin.LineString.StartPoint;
                    var endPoint = origin.LineString.EndPoint;

                    int countSegment = 1;
                    var c = polyline.Single(e => e.StartPoint.EqualsExact(startPoint));

                    var tuple = hashing[IO.Hashing.XxHash3.HashToUInt64(c.AsBinary())];
                    bagCurves.Add(tuple.curve);

                    var sorted = new FeatureRef[polyline.Count];
                    sorted[0] = tuple.fetureRef;

                    do {
                        var next = polyline.Single(e => e != c && e.StartPoint.EqualsExact(c.EndPoint));

                        tuple = hashing[IO.Hashing.XxHash3.HashToUInt64(next.AsBinary())];
                        bagCurves.Add(tuple.curve);

                        sorted[countSegment] = tuple.fetureRef;
                        c = next;

                        countSegment += 1;
                    } while (!c.EndPoint.EqualsExact(endPoint));

                    if (countSegment != polyline.Count)
                        System.Diagnostics.Debugger.Break();

                    var compositeExterior = new CompositeCurveFeature {
                        Id = Interlocked.Increment(ref FeatureType.counter),
                        Curves = [.. sorted],
                    };

                    var key = string.Join(',', sorted.Select(e => e.Reverse ? $"RC{e.Id}" : $"{e.Id}"));

                    compositeExterior = bagCompositeCurves.GetOrAdd(key, (key) => {
                        return compositeExterior;
                    });

                    featureRef = new FeatureRef {
                        Id = compositeExterior.Id,
                        Reverse = false,
                    };
                }

                mapping.GetOrAdd(m.Key, $"C{featureRef.Id}");
            });

            topology.Mapping = mapping;

            topology.CompositeCurves = [.. bagCompositeCurves.Values];
            topology.Surfaces = [.. bagSurfaces];

            var ids = new List<UInt64>();
            foreach (var e in bagCurves) {
                if (ids.Contains(e.Id))
                    continue;
                ids.Add(e.Id);
                topology.Curves.Add(e);
            }
        }

        private static void AddLineStringsFromGeometry(IGeometry geometry, List<LineString> targetList) {
            if (geometry is LineString line) {
                if (!line.IsEmpty) {
                    if (!targetList.Any(e => e.EqualsTopologically(line)))
                        targetList.Add(line);
                }
            }
            else if (geometry is MultiLineString multiLine) {
                foreach (var subLine in multiLine.Geometries.OfType<LineString>()) {
                    if (!subLine.IsEmpty) {
                        if (!targetList.Any(e => e.EqualsTopologically(subLine)))
                            targetList.Add(subLine);
                    }
                }
            }
            else if (geometry is GeometryCollection collection) // Recursively handle collections if needed
            {
                foreach (var geom in collection.Geometries) {
                    AddLineStringsFromGeometry(geom, targetList);
                }
            }
            // We primarily care about LineString results for shared *edges*.
            // Point/MultiPoint intersections mean polygons touch only at vertices.
        }
    }
}

namespace GeoAPI.Geometries
{
    using NetTopologySuite.Geometries;

    public static class Extension
    {
        public static IGeometry Combine(this IGeometry geometry) {
            if (geometry is MultiLineString multiLineString) {
                var last = ((LineString)multiLineString[0]);

                var geometries = new List<LineString>();

                var coordinates = new Coordinate[0];
                coordinates = [.. last.Coordinates];

                for (int i = 1; i < multiLineString.Count; i++) {
                    var next = ((LineString)multiLineString[i]);

                    if (next.StartPoint.EqualsTopologically(last.EndPoint))
                        coordinates = [.. coordinates, .. next.Coordinates];
                    else {
                        geometries.Add((LineString)geometry.Factory.CreateLineString(coordinates));
                        coordinates = next.Coordinates.ToArray();
                    }

                    last = next;
                }

                if (!geometries.Any()) {
                    geometry = geometry.Factory.CreateLineString(coordinates);
                }
                else {
                    geometries.Add((LineString)geometry.Factory.CreateLineString(coordinates));

                    geometry = geometry.Factory.CreateMultiLineString(geometries.ToArray());
                }
            }

            return geometry;
        }
    }
}