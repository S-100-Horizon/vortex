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




                var geometries = new List<(Geometry geometry, string name)>();
                var featureAssociations = new Dictionary<string, YAML.Association[]>();

                // Build Topology
                {
                    var filter = new SpatialQueryFilter {
                        FilterGeometry = shape,
                        SpatialRelationship = SpatialRelationship.Relation,
                        SpatialRelationshipDescription = "T*****FF*",
                        WhereClause = "upper(ps) = 'S-101'",
                    };

                    Log.Information("Building topology..");
                    var topology = source.BuildTopology(filter);

                    Log.Information("Topology finished! Found {curves} Curves, {composites} CompositeCurves, {surfaces} Surfaces", topology!.Curves.Count, topology.CompositeCurves.Count, topology.Surfaces.Count);
                    dataset.AddTopology(topology);
                }


                // FeatureAssociations - skip for now until two-way references sorted
                {
                    //try {
                    //    using var type = source.OpenDataset<Table>("associationbinding");
                    //    using var cursor = type.Search();
                    //    while (cursor.MoveNext()) {
                    //        var current = cursor.Current;

                    //        var name = current["association"].ToString()!;
                    //        var role = current["role"].ToString()!;

                    //        var id = current["pid"].ToString()!;
                    //        var to = current["foreignid"].ToString()!;

                    //        var foid = $"110:{to!.Substring(1)}:1";       // Geodatastyrelsen: 110 

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
                }


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

                    var filter = new SpatialQueryFilter {
                        FilterGeometry = shape,
                        SpatialRelationship = SpatialRelationship.Relation,
                        SpatialRelationshipDescription = "T*****FF*"
                    };

                    using var cursor = fc.Search(filter, true);
                    while (cursor.MoveNext()) {
                        var current = (ArcGIS.Core.Data.Feature)cursor.Current;
                        var geometry = Convert.ToString(current["name"]);

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
                                // Attributes = (FeatureNode)instance!,
                            };

                            // Only emit attributes if feature contains any non-static properties
                            if (!S100Framework.YAML.Converter.IsDefault(instance!))
                                feature.Attributes = (FeatureNode)instance!;

                            // FeatureAssociations
                            var hasAssociations = featureAssociations.TryGetValue(geometry, out var associations);

                            if (hasAssociations) {
                                foreach (var asso in associations) {
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
                    Log.Information("Adding {geometryType} with ID: {name}", geometry.GeometryType, name);
                }

                // Serialize to YAML
                var yaml = S100Framework.YAML.Converter.Serialize(dataset);

                File.WriteAllText(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"101DK40349E.yaml"), yaml);

                sw.Stop();
                Log.Information("Elapsed: {elapsed}", sw.Elapsed.TotalSeconds);

                return 0;
            }
            catch (Exception ex) {
                Log.Information(ex.Message);
                return -1;
            }
        }

        private const string jsonSurface = "{\"rings\":[[[12.5,54.7015465],[12.4732885,54.694891],[12.4421088,54.6871107],[12.4323619,54.6790339],[12.4167304,54.6660724],[12.4093265,54.6599296],[12.4021195,54.6539479],[12.3978169,54.6503758],[12.3895268,54.6434911],[12.3772575,54.6332961],[12.3758783,54.6321497],[12.3700522,54.6273061],[12.3649871,54.623094],[12.3626519,54.6211517],[12.3590146,54.6181259],[12.3549381,54.6147341],[12.3494461,54.6101634],[12.3414574,54.6035126],[12.339328,54.6017394],[12.3362479,54.5991741],[12.3332861,54.596707],[12.3244586,54.5893516],[12.3170332,54.583162],[12.3015427,54.5702419],[12.2733278,54.5466828],[12.2612285,54.5365694],[12.2413132,54.5199097],[12.24082,54.5194969],[12.2396746,54.5185383],[12.2359635,54.5154316],[12.2285345,54.509211],[12.217541,54.5],[12.0,54.5],[12.0,55.0],[12.5,55.0],[12.5,54.7015465]]],\"spatialReference\":{\"wkid\":4326,\"latestWkid\":4326,\"xyTolerance\":3.5355339e-08,\"zTolerance\":0.001,\"mTolerance\":0.001,\"falseX\":-400,\"falseY\":-400,\"xyUnits\":99999999.99999999,\"falseZ\":-100000,\"zUnits\":10000,\"falseM\":-100000,\"mUnits\":10000}}";

        // Small surface
        //private const string jsonSurface = "{\"rings\":[[[12.114831503446396,54.91362416884908],[12.065786844335435,54.91362416884908],[12.065786844335435,54.894064996042914],[12.114831503446396,54.894064996042914],[12.114831503446396,54.91362416884908]]],\"spatialReference\":{\"wkid\":4326,\"latestWkid\":4326,\"xyTolerance\":3.5355339e-08,\"zTolerance\":0.001,\"mTolerance\":0.001,\"falseX\":-400,\"falseY\":-400,\"xyUnits\":99999999.99999999,\"falseZ\":-100000,\"zUnits\":10000,\"falseM\":-100000,\"mUnits\":10000}}";
    }
}

namespace S100Framework.YAML
{
    using ArcGIS.Core.Internal.CIM;
    using NetTopologySuite.Densify;
    using NetTopologySuite.Geometries;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using System.Text.RegularExpressions;

    public class CurveFeature
    {
        public int Id { get; init; }

        public CurveFeature(int id, LineString lineString) {
            this.Id = id;
            this.LineString = lineString;
            this.HashCode = lineString.GetHashCode();
        }

        public LineString LineString { get; init; }

        public int HashCode { get; init; }
    }

    public class CompositeCurveFeature
    {
        public int Id { get; init; }

        public required int[] Curves { get; init; }
    }

    public class SurfaceFeature
    {
        public int Id { get; init; }

        public int Exterior { get; init; }

        public int[]? Interior { get; init; }

        public string? Ref { get; init; } = default;
    }

    public record Polyline(long ObjectId, string name, LineString LineString);

    public record Polygon(long ObjectId, string name, LineString ExteriorRing, LineString[] InteriorRings) : Polyline(ObjectId, name, ExteriorRing);

    public class Topology
    {
        public required ICollection<CurveFeature> Curves { get; set; }

        public required ICollection<CompositeCurveFeature> CompositeCurves { get; set; }

        public required ICollection<SurfaceFeature> Surfaces { get; set; }
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
            foreach (var c in topology.Curves) {    // todo: use ref instead of id
                try {
                    Log.Information("Adding curve C{curve} from topology", c.Id);
                    var coordinates = c.LineString.Coordinates.Select(e => new Coordinate(e.X, e.Y)).ToArray();

                    var first = dataset?.GetOrCreateStartPoint(coordinates, $"{c.Id}");
                    var last = dataset?.GetOrCreateEndPoint(coordinates, $"{c.Id}");

                    var curve = new Curve(first!, last!, coordinates) {
                        Name = $"C{c.Id}",
                    };

                    dataset!.AddCurve(curve);
                }
                catch (Exception ex) {
                    Log.Error("Exception! {ex} on curve: {curve}", ex, c.Id);
                }
            }

            // Composite Curves
            foreach (var composite in topology.CompositeCurves) {
                Log.Information("Adding composite C{curvecomposite} from topology", composite.Id);
                var compositecurveIds = composite.Curves.SelectMany(e => topology.Curves.Where(f => f.Id == e)).Select(x => $"C{x.Id}");

                var components = string.Join(",", compositecurveIds);

                var compositeCurve = new CompositeCurve(components) {
                    Name = $"C{composite.Id}"
                };

                _ = dataset.AddCompositeCurve(compositeCurve);
            }

            foreach (var s in topology.Surfaces) {
                Log.Information("Adding surface S{surface} from topology", s.Id);
                var exteriorRing = $"C{s.Exterior}";
                var interiorRings = s?.Interior?.Select(e => $"C{e}").ToArray();

                var surface = new Surface(exteriorRing) {
                    InteriorRings = interiorRings,
                    Name = s.Ref
                };

                _ = dataset.AddSurface(surface);
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
            var tempPoint = new Point(curve[0].X, curve[0].Y);
            var datasetPoint = dataset?.Points?.FirstOrDefault(e => e.Location == tempPoint.Location);

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
            var tempPoint = new Point(curve[^1].X, curve[^1].Y);
            var datasetPoint = dataset?.Points?.FirstOrDefault(e => e.Location == tempPoint.Location);

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

        public static List<CurveFeature> AddCurve(this List<CurveFeature> topology, CurveFeature curve) {
            if (topology.Any(e => e.HashCode == curve.HashCode)) return topology;
            topology.Add(curve);
            return topology;
        }

        public static CompositeCurveFeature AddCurve(this List<CompositeCurveFeature> topology, CompositeCurveFeature curve) {
            if (topology.Any(e => e.Curves.SequenceEqual(curve.Curves))) return topology.Single(e => e.Curves.SequenceEqual(curve.Curves));
            topology.Add(curve);
            return curve;
        }
    }
}

namespace ArcGIS.Core.Data
{
    using GeoAPI.Geometries;
    using NetTopologySuite.Geometries;
    using NetTopologySuite.Operation.Polygonize;

    internal static class Extension
    {
        static SpatialReference spatialReference = SpatialReferenceBuilder.CreateSpatialReference(4326);

        public static void PersistTopology(this Geodatabase geodatabase, ICollection<CurveFeature> curves) {
            using var topology = geodatabase.OpenDataset<FeatureClass>("topology");

            topology.DeleteRows(new QueryFilter {
                WhereClause = "1=1",
            });

            using var buffer = topology.CreateRowBuffer();
            using var cursor = topology.CreateInsertCursor();

            foreach (var c in curves) {
                buffer["shape"] = PolylineBuilderEx.CreatePolyline(c.LineString.Coordinates.Select(e => MapPointBuilderEx.CreateMapPoint(e.X, e.Y, spatialReference)), spatialReference);
                cursor.Insert(buffer);
            }
            cursor.Flush();
        }

        public static S100Framework.YAML.Topology? BuildTopology(this Geodatabase geodatabase, QueryFilter? queryFilter = default) {
            var factory = new GeometryFactory(new PrecisionModel(PrecisionModels.FloatingSingle)); // Or PrecisionModels.Floating

            var polylines = new List<S100Framework.YAML.Polyline>();

            using (var surface = geodatabase.OpenDataset<FeatureClass>("surface")) {
                if (queryFilter is null) {
                    queryFilter = new QueryFilter {
                        WhereClause = "upper(ps) = 'S-101'",
                    };
                }

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

                    //if (shape.PartCount > 1) {
                    //    var interiorRings = new List<LineString>();

                    //    foreach (var interiorRing in shape.Parts.Skip(1)) {
                    //        coordinates = interiorRing.Select(segment => new Coordinate(segment.StartPoint.X, segment.StartPoint.Y)).ToArray();

                    //        interiorRings.Add((LineString)factory.CreateLineString([.. coordinates, coordinates[0]]));
                    //    }

                    //    polylines.Add(new S100Framework.YAML.Polygon(f.GetObjectID(), name, ex, interiorRings.ToArray()));
                    //}
                    //else 
                    {
                        polylines.Add(new S100Framework.YAML.Polygon(f.GetObjectID(), name, ex, []));
                    }
                }
            }

            var curves = new List<CurveFeature>();
            var compositecurves = new List<CompositeCurveFeature>();
            var surfaces = new List<SurfaceFeature>();

            int count = polylines.Count();

            int geometryId = 1;

            var equalsList = new List<string>();

            foreach (var input in polylines) {
                count -= 1;
                if (count % 100 == 0)
                    Log.Verbose("#{count}", count);

                //if (input.ObjectId == 42794)
                //    System.Diagnostics.Debugger.Break();

                //var local = new List<int>();
                var local = new Dictionary<string, ICollection<int>>();

                var rings = new List<LineString> { input.LineString };

                if (input is S100Framework.YAML.Polygon polygon) {
                    foreach (var i in polygon.InteriorRings) {
                        rings.Add(i);
                    }
                }

                foreach (var ring in rings) {
                    var ringString = ring.ToString();
                    local.Add(ringString, new List<int>());

                    //if (ringString.Equals("LINESTRING (12.672781 55.707827, 12.67302 55.70782, 12.673021 55.707816, 12.673071 55.707638, 12.67517 55.70027, 12.67502 55.69838, 12.67489 55.6967, 12.67485 55.69617, 12.67482 55.69586, 12.67468 55.69453, 12.67459 55.69363, 12.6745 55.69276, 12.67443 55.69204, 12.67323 55.6802, 12.67312 55.67913, 12.67275 55.6755, 12.67262 55.67413, 12.6726 55.67396, 12.6725 55.67305, 12.672476 55.672811, 12.672458 55.672629, 12.67242 55.67225, 12.67153 55.67273, 12.67138 55.67281, 12.66918 55.67399, 12.66848 55.67437, 12.66692 55.6752, 12.66538 55.67604, 12.6645 55.67651, 12.66162 55.67806, 12.66102 55.67838, 12.65746 55.68029, 12.65725 55.68041, 12.65725 55.68087, 12.65726 55.68216, 12.65726 55.68316, 12.657305 55.689471, 12.657313 55.69233, 12.65732 55.694926, 12.657324 55.696431, 12.657319 55.6973, 12.657308 55.699362, 12.657291 55.702638, 12.65728 55.70373, 12.65726 55.70747, 12.65726 55.70803, 12.65725 55.70838, 12.657713 55.708363, 12.65887 55.70832, 12.65907 55.70831, 12.659179 55.708307, 12.65981 55.70829, 12.66427 55.70813, 12.665178 55.708098, 12.66764 55.70801, 12.6679 55.708, 12.66919 55.70796, 12.6714 55.70788, 12.67265 55.70783, 12.672781 55.707827)"))
                    //    System.Diagnostics.Debugger.Break();

                    var analyze = polylines.Where(e => !e.ObjectId.Equals(input.ObjectId));

                    var equals = polylines.Where(e => !e.ObjectId.Equals(input.ObjectId)).Where(e => ring.EqualsTopologically(e.LineString));
                    if (equals.Any()) {
                        //if (equalsList.Contains(ringString)) {
                        //    var curve = new CurveFeature(geometryId++, ring);

                        //    local[ringString].Add(curve.HashCode);
                        //    continue;
                        //}

                        //equalsList.Add(ringString);

                        var ids = equals.Select(e => e.ObjectId);
                        analyze = analyze.Where(e => !ids.Contains(e.ObjectId));
                    }

                    var overlaps = analyze.Where(e => ring.Overlaps(e.LineString)).Select(e => e.LineString).ToArray();
                    if (!overlaps.Any()) {
                        var curve = new CurveFeature(geometryId++, ring);
                        curves.AddCurve(curve);

                        local[ringString].Add(curve.HashCode);
                        continue;
                    }

                    var collection = factory.CreateMultiLineString(overlaps);

                    try {
                        var intersection = input.LineString.Intersection(collection);
                        if (intersection is GeometryCollection geometryCollection) {
                            var polylins = geometryCollection.Geometries.Where(e => e is LineString);
                            if (!polylins.Any()) {
                                var curve = new CurveFeature(geometryId++, input.LineString);
                                curves.AddCurve(curve);
                                local[ringString].Add(curve.HashCode);
                                continue;
                            }
                            intersection = factory.CreateMultiLineString(polylins.Select(e => e as LineString).ToArray());
                        }

                        if (intersection is MultiLineString multiLineStringIntersection) {
                            foreach (LineString lineString in multiLineStringIntersection.Geometries) {
                                if (!lineString.IsEmpty) {
                                    var curve = new CurveFeature(geometryId++, lineString);
                                    curves.AddCurve(curve);
                                    local[ringString].Add(curve.HashCode);
                                }
                            }
                        }
                        else if (intersection is LineString lineStringIntersection) {
                            if (!lineStringIntersection.IsEmpty) {
                                var curve = new CurveFeature(geometryId++, lineStringIntersection);
                                curves.AddCurve(curve);
                                local[ringString].Add(curve.HashCode);
                            }
                        }

                        var difference = input.LineString.Difference(intersection);

                        if (difference is MultiLineString multiLineStringDifference) {
                            foreach (LineString lineString in multiLineStringDifference.Geometries) {
                                if (!lineString.IsEmpty) {
                                    var curve = new CurveFeature(geometryId++, lineString);
                                    curves.AddCurve(curve);
                                    local[ringString].Add(curve.HashCode);
                                }
                            }
                        }
                        else if (difference is LineString lineStringDifference) {
                            if (!lineStringDifference.IsEmpty) {
                                var curve = new CurveFeature(geometryId++, lineStringDifference);
                                curves.AddCurve(curve);
                                local[ringString].Add(curve.HashCode);
                            }
                        }
                    }
                    catch (NetTopologySuite.Geometries.TopologyException ex) {
                        Log.Logger.Error(ex, "no intersections: {ObjectId}", input.ObjectId);
                        var curve = new CurveFeature(geometryId++, input.LineString);
                        curves.AddCurve(curve);
                        local[ringString].Add(curve.HashCode);
                        continue;
                    }
                }


                if (local.Any(e => e.Value.Count > 1)) {
                    var exterior = local.First();

                    var exteriorReferences = curves.Where(e => exterior.Value.Contains(e.HashCode));

                    if (!exteriorReferences.Any())
                        System.Diagnostics.Debugger.Break();

                    var interior = new List<int>();

                    foreach (var i in local.Skip(1)) {
                        var references = curves.Where(e => i.Value.Contains(e.HashCode)).Select(e => e.Id);

                        if (!references.Any())
                            System.Diagnostics.Debugger.Break();

                        var composite = new CompositeCurveFeature {
                            Id = geometryId++,
                            Curves = references.ToArray(),
                        };
                        composite = compositecurves.AddCurve(composite);
                        interior.Add(composite.Id);
                    }

                    //if (exteriorReferences.Count() > 1)
                    //    System.Diagnostics.Debugger.Break();

                    var lineStrings = curves.Where(e => exterior.Value.Contains(e.HashCode)).Select(e => e.LineString);

                    var polygonizer = new Polygonizer();
                    polygonizer.Add(lineStrings.ToArray());

                    var text = polygonizer.GetGeometry().ToString()!;

                    var compositeExterior = new CompositeCurveFeature {
                        Id = geometryId++,
                        Curves = exteriorReferences.OrderBy(e => {
                            return text.IndexOf(e.LineString.ToString());
                        }).Select(e => e.Id).ToArray(),
                    };
                    compositeExterior = compositecurves.AddCurve(compositeExterior);

                    //var p = factory.CreatePolygon(lineStrings);

                    var surface = new SurfaceFeature {
                        Id = geometryId++,
                        Exterior = compositeExterior.Id,
                        Interior = interior.Any() ? interior.ToArray() : default,
                        Ref = input.name,
                    };
                    surfaces.Add(surface);
                }
                else {
                    var reference = curves.Single(e => local.First().Value.Contains(e.HashCode));

                    var surface = new SurfaceFeature {
                        Id = geometryId++,
                        Exterior = reference.Id,
                        Ref = input.name,
                    };
                    surfaces.Add(surface);
                }

            }

            return new S100Framework.YAML.Topology {
                Curves = curves,
                CompositeCurves = compositecurves,
                Surfaces = surfaces,
            };
        }

    }
}