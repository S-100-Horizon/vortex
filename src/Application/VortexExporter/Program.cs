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
                    //WhereClause = "upper(ps) = 'S-101'",
                    WhereClause = "upper(ps) = 'S-101' and upper(code) IN ('DEPTHAREA','DREDGEDAREA','LANDAREA','UNSURVEYEDAREA')",
                };



                var geometries = new List<(Geometry geometry, string name)>();
                var featureAssociations = new Dictionary<string, YAML.Association[]>();

                // Build Topology
                Log.Information("Building topology..");
                var topology = source.BuildTopology(filter);

                Log.Information("Topology finished! Found {curves} Curves, {composites} CompositeCurves, {surfaces} Surfaces", topology!.Curves.Count, topology.CompositeCurves.Count, topology.Surfaces.Count);
                dataset.AddTopology(topology);


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
                Log.Information("Elapsed: {elapsed}", sw.Elapsed);

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
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using System.Text.RegularExpressions;

    public abstract class FeatureType
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }

    public class CurveFeature : FeatureType
    {
        public CurveFeature(LineString lineString) {
            this.LineString = lineString;
            this.LineStringReverse = (LineString)lineString.Reverse();
            this.HashCode = lineString.ToString();//.GetHashCode();

            this.Forward = lineString.ToString();
            this.Reverse = this.LineStringReverse.ToString();
        }

        public LineString LineString { get; set; }

        public LineString LineStringReverse { get; set; }

        public string Forward { get; init; }
        public string Reverse { get; init; }

        public string HashCode { get; init; }

        public bool Equals(CurveFeature lineString) {
            if (lineString.Forward.Equals(this.Forward))
                return true;
            if (lineString.Reverse.Equals(this.Reverse))
                return true;
            var reverse = lineString.Reverse;
            if (reverse.Equals(this.Forward))
                return true;
            if (reverse.Equals(this.Reverse))
                return true;
            return false;
        }

        public bool Equals(LineString lineString) {
            if (lineString.ToString().Equals(this.Forward))
                return true;
            if (lineString.ToString().Equals(this.Reverse))
                return true;
            var reverse = (LineString)lineString.Reverse();
            if (reverse.ToString().Equals(this.Forward))
                return true;
            if (reverse.ToString().Equals(this.Reverse))
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
    }

    public class CompositeCurveFeature : FeatureType
    {
        public Guid[] Curves { get; init; }
    }

    public class SurfaceFeature : FeatureType
    {
        public Guid Exterior { get; init; }

        public Guid[]? Interior { get; init; }

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
            var options = new ParallelOptions {
                MaxDegreeOfParallelism = 16,
            };

            // Curves
            CurveFeature? curveFeature = default;
            try {
                Log.Information("Adding curve #{count}", topology.Curves.Count());

                //var concurrent = new ConcurrentBag<Curve>();

                //Parallel.ForEach(topology.Curves, options, (c) => {
                //    curveFeature = c;

                //    //Log.Information("Adding curve C{curve} from topology", c.Id);
                //    var coordinates = c.LineString.Coordinates.Select(e => new Coordinate(e.X, e.Y)).ToArray();

                //    var first = dataset?.GetOrCreateStartPoint(coordinates, $"{c.Id}");
                //    var last = dataset?.GetOrCreateEndPoint(coordinates, $"{c.Id}");

                //    var curve = new Curve(first!, last!, coordinates) {
                //        Name = $"C{c.Id}",
                //    };

                //    concurrent.Add(curve);
                //});

                //foreach(var curve in concurrent) {
                //    dataset!.AddCurve(curve);
                //}

                foreach (var c in topology.Curves) {    // todo: use ref instead of id
                    curveFeature = c;

                    //Log.Information("Adding curve C{curve} from topology", c.Id);
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

                    //Log.Information("Adding composite C{curvecomposite} from topology", composite.Id);
                    var compositecurveIds = c.Curves.SelectMany(e => topology.Curves.Where(f => f.Id == e)).Select(x => $"C{x.Id}");

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

                    //Log.Information("Adding surface S{surface} from topology", s.Id);
                    var exteriorRing = $"C{s.Exterior}";
                    var interiorRings = s?.Interior?.Select(e => $"C{e}").ToArray();

                    var surface = new Surface(exteriorRing) {
                        InteriorRings = interiorRings,
                        Name = s.Ref
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

        public static IList<CurveFeature> AddCurve(this IList<CurveFeature> topology, CurveFeature curve) {
            if (topology.Any(e => e.Equals(curve))) return topology;
            topology.Add(curve);
            return topology;
        }

        public static CompositeCurveFeature AddCurve(this IList<CompositeCurveFeature> topology, CompositeCurveFeature curve) {
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
    using System.Linq;

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
            };

            goto SkinOfEarth;

            {
                var codes = new List<string>();

                using (var surface = geodatabase.OpenDataset<FeatureClass>("surface")) {
                    var prefixClause = queryFilter.PrefixClause;
                    var subFields = queryFilter.SubFields;

                    queryFilter.PrefixClause = "DISTINCT";
                    queryFilter.WhereClause = $"{whereClause} AND NOT (upper(code) IN ('DEPTHAREA','DREDGEDAREA','LANDAREA','UNSURVEYEDAREA'))";
                    queryFilter.SubFields = "CODE";

                    using (var cursor = surface.Search(queryFilter)) {
                        while (cursor.MoveNext()) {
                            var r = cursor.Current;
                            codes.Add(Convert.ToString(r["code"])!.ToUpperInvariant());
                        }
                    }

                    queryFilter.PrefixClause = prefixClause;
                    queryFilter.SubFields = subFields;

                    foreach (var code in codes.Distinct()) {
                        var polylines = new List<S100Framework.YAML.Polyline>();

                        queryFilter.WhereClause = $"{whereClause} AND (upper(code) = upper('{code}'))";

                        using (var cursor = surface.Search(queryFilter)) {
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

                                    polylines.Add(new S100Framework.YAML.Polygon(f.GetObjectID(), name, ex, interiorRings.ToArray()));
                                }
                                else {
                                    polylines.Add(new S100Framework.YAML.Polygon(f.GetObjectID(), name, ex, []));
                                }
                            }
                        }

                        int count = polylines.Count();
                        Log.Information("{code}: #{count}", code, count);

                        var t = new S100Framework.YAML.Topology {
                            Curves = new List<CurveFeature>(),
                            CompositeCurves = new List<CompositeCurveFeature>(),
                            Surfaces = new List<SurfaceFeature>(),
                        };

                        AppendSurface(polylines, t);

                        if (t.Curves.Any())
                            topology.Curves = topology.Curves.Union(t.Curves).ToList();
                        if (t.CompositeCurves.Any())
                            topology.CompositeCurves = topology.CompositeCurves.Union(t.CompositeCurves).ToList();
                        if (t.Surfaces.Any())
                            topology.Surfaces = topology.Surfaces.Union(t.Surfaces).ToList();
                    }
                }
            }

        SkinOfEarth:
            //  Skin of Earth
            {
                var polylines = new List<S100Framework.YAML.Polyline>();

                using (var surface = geodatabase.OpenDataset<FeatureClass>("surface")) {
                    queryFilter.WhereClause = $"{whereClause} AND (upper(code) IN ('DEPTHAREA','DREDGEDAREA','LANDAREA','UNSURVEYEDAREA'))";

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

                            polylines.Add(new S100Framework.YAML.Polygon(f.GetObjectID(), name, ex, interiorRings.ToArray()));
                        }
                        else {
                            polylines.Add(new S100Framework.YAML.Polygon(f.GetObjectID(), name, ex, []));
                        }
                    }
                }

                int count = polylines.Count();
                Log.Information("Skin of Earth #{count}", count);

                var t = new S100Framework.YAML.Topology {
                    Curves = new List<CurveFeature>(),
                    CompositeCurves = new List<CompositeCurveFeature>(),
                    Surfaces = new List<SurfaceFeature>(),
                };

                AppendSurface(polylines, t);

                if (t.Curves.Any())
                    topology.Curves = topology.Curves.Union(t.Curves).ToList();
                if (t.CompositeCurves.Any())
                    topology.CompositeCurves = topology.CompositeCurves.Union(t.CompositeCurves).ToList();
                if (t.Surfaces.Any())
                    topology.Surfaces = topology.Surfaces.Union(t.Surfaces).ToList();
            }

            Log.Verbose("Topology: #{curves}, #{composites}, #{surfaces}", topology.Curves.Count, topology.CompositeCurves.Count, topology.Surfaces.Count);
            return topology;
        }

        private static void AppendSurface(ICollection<S100Framework.YAML.Polyline> polylines, S100Framework.YAML.Topology topology) {
            var factory = new GeometryFactory(new PrecisionModel(PrecisionModels.FloatingSingle)); // Or PrecisionModels.Floating

            int count = polylines.Count();

            var curves = topology.Curves;
            var compositecurves = topology.CompositeCurves;
            var surfaces = topology.Surfaces;

            var equalsList = new List<string>();
            var equalsDictionary = new Dictionary<string, List<CurveFeature>>();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var input in polylines/*.Where(e => e.ObjectId == 43950)*/) {
                var startTime = stopwatch.Elapsed;

                count -= 1;
                if (System.Diagnostics.Debugger.IsAttached) {
                    if (count > 0 && count % 20 == 0)
                        Log.Verbose("#{count}", count);
                }

                var local = new Dictionary<LineString, List<CurveFeature>>();

                var rings = new List<LineString> { input.LineString };

                if (input is S100Framework.YAML.Polygon polygon) {
                    foreach (var i in polygon.InteriorRings) {
                        rings.Add(i);
                    }
                }

                foreach (var ring in rings) {
                    var ringString = ring.ToString();
                    local.Add(ring, new List<CurveFeature>());

                    var analyze = polylines.Where(e => !e.ObjectId.Equals(input.ObjectId));

                    var equals = polylines.Where(e => !e.ObjectId.Equals(input.ObjectId)).Where(e => ring.EqualsTopologically(e.LineString));
                    if (equals.Any()) {
                        if (equalsList.Contains(ringString)) {
                            var curve = equalsDictionary[ringString];
                            local[ring] = curve;
                            continue;
                        }

                        equalsList.Add(ringString);

                        var ids = equals.Select(e => e.ObjectId);
                        analyze = analyze.Where(e => !ids.Contains(e.ObjectId));
                    }

                    var overlaps = analyze.Where(e => ring.Intersects(e.LineString)).Select(e => e.LineString).ToArray();

                    //using (var target = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri($"file://{IO.Path.GetFullPath(@".\..\..\..\..\..\artifacts\s100ed6.gdb")}")))) {
                    //    var t = overlaps.Select(e => new CurveFeature(e)).ToList();
                    //    target.PersistTopology(t);
                    //    return null;
                    //}

                    if (!overlaps.Any()) {
                        var curve = new CurveFeature(ring);
                        curves.AddCurve(curve);

                        local[ring].Add(curve);
                        continue;
                    }

                    var collection = factory.CreateMultiLineString(overlaps);

                    try {
                        var intersection = input.LineString.Intersection(collection);

                        if (intersection.IsEmpty) {
                            var curve = new CurveFeature(ring);
                            curves.AddCurve(curve);
                            local[ring].Add(curve);
                            continue;
                        }

                        if (intersection is GeometryCollection geometryCollection) {
                            var polylins = geometryCollection.Geometries.Where(e => e is LineString);
                            if (!polylins.Any()) {
                                var curve = new CurveFeature(input.LineString);
                                curves.AddCurve(curve);
                                local[ring].Add(curve);
                                continue;
                            }
                            intersection = factory.CreateMultiLineString(polylins.Select(e => e as LineString).ToArray());
                        }

                        if (intersection is MultiLineString multiLineStringIntersection) {
                            foreach (LineString lineString in multiLineStringIntersection.Geometries) {
                                if (!lineString.IsEmpty) {
                                    if (lineString.Coordinates.All(e => ring.Coordinates.Contains(e))) {
                                        var curve = new CurveFeature(lineString);
                                        curves.AddCurve(curve);
                                        local[ring].Add(curve);
                                    }
                                }
                            }
                        }
                        else if (intersection is LineString lineStringIntersection) {
                            if (!lineStringIntersection.IsEmpty) {
                                if (lineStringIntersection.Coordinates.All(e => ring.Coordinates.Contains(e))) {
                                    var curve = new CurveFeature(lineStringIntersection);
                                    curves.AddCurve(curve);
                                    local[ring].Add(curve);
                                }
                            }
                        }

                        var difference = input.LineString.Difference(intersection);

                        if (difference is MultiLineString multiLineStringDifference) {
                            foreach (LineString lineString in multiLineStringDifference.Geometries) {
                                if (!lineString.IsEmpty) {
                                    var curve = new CurveFeature(lineString);
                                    curves.AddCurve(curve);
                                    local[ring].Add(curve);

                                }
                            }
                        }
                        else if (difference is LineString lineStringDifference) {
                            if (!lineStringDifference.IsEmpty) {
                                var curve = new CurveFeature(lineStringDifference);
                                curves.AddCurve(curve);
                                local[ring].Add(curve);
                            }
                        }
                    }
                    catch (NetTopologySuite.Geometries.TopologyException ex) {
                        Log.Logger.Error(ex, "no intersections: {ObjectId}", input.ObjectId);
                        var curve = new CurveFeature(ring);
                        curves.AddCurve(curve);
                        local[ring].Add(curve);
                        continue;
                    }
                }

                int loop = 0;
                foreach (var l in local) {
                    //using (var target = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri($"file://{IO.Path.GetFullPath(@".\..\..\..\..\..\artifacts\s100ed6.gdb")}")))) {
                    //    target.PersistTopology(l.Value.Select(e => new CurveFeature(e)).ToList());
                    //    return null;
                    //}

                    var start = l.Value.Single(e => e.LineString.StartPoint.EqualsNormalized(l.Key.StartPoint));
                    var end = l.Value.Single(e => e.LineString.EndPoint.EqualsNormalized(l.Key.EndPoint));

                    var sorted = new List<CurveFeature> { start };

                    int countSegment = 1;
                    var c = start;
                    do {
                        countSegment += 1;
                        var next = l.Value.Single(e => e.LineString.StartPoint.EqualsNormalized(c.LineString.EndPoint));
                        sorted.Add(next);
                        c = next;
                    } while (c != end);

                    local[l.Key] = sorted;

                    //using (var target = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri($"file://{IO.Path.GetFullPath(@".\..\..\..\..\..\artifacts\s100ed6.gdb")}")))) {
                    //    target.PersistTopology(sorted.Select(e => new CurveFeature(e)).ToList());
                    //    return null;
                    //}

                    loop += 1;
                }

                if (local.Any(e => e.Value.Count > 1)) {
                    var exterior = local.First();

                    CurveFeature[] exteriorReferences = new CurveFeature[exterior.Value.Count];
                    for (int i = 0; i < exteriorReferences.Length; i++) {
                        exteriorReferences[i] = curves.Single(e => e.Equals(exterior.Value[i]));
                    }

                    if (!exteriorReferences.Any())
                        System.Diagnostics.Debugger.Break();

                    if (equalsList.Contains(exterior.Key.ToString())) {
                        if (!equalsDictionary.ContainsKey(exterior.Key.ToString()))
                            equalsDictionary.Add(exterior.Key.ToString(), exterior.Value);
                    }

                    var interior = new List<Guid>();

                    foreach (var i in local.Skip(1)) {
                        CurveFeature[] interiorReferences = new CurveFeature[i.Value.Count];
                        for (int j = 0; j < interiorReferences.Length; j++) {
                            interiorReferences[j] = curves.Single(e => e.Equals(i.Value[j]));
                        }

                        if (!interiorReferences.Any())
                            System.Diagnostics.Debugger.Break();

                        if (equalsList.Contains(i.Key.ToString())) {
                            if (!equalsDictionary.ContainsKey(i.Key.ToString()))
                                equalsDictionary.Add(i.Key.ToString(), i.Value);
                        }


                        //var references = curves.Where(e => i.Value.Contains(e.LineString) || i.Value.Contains(e.LineStringReverse)).Select(e => e.Id).Distinct();

                        //if (!references.Any())
                        //    System.Diagnostics.Debugger.Break();

                        var composite = new CompositeCurveFeature {
                            Curves = interiorReferences.Select(e => e.Id).ToArray(),
                        };
                        composite = compositecurves.AddCurve(composite);
                        interior.Add(composite.Id);
                    }

                    var compositeExterior = new CompositeCurveFeature {
                        //Curves = sorted.Select(e => e.Id).ToArray(),
                        Curves = exteriorReferences.Select(e => e.Id).ToArray(),
                    };
                    compositeExterior = compositecurves.AddCurve(compositeExterior);

                    var surface = new SurfaceFeature {
                        Exterior = compositeExterior.Id,
                        Interior = interior.Any() ? interior.ToArray() : default,
                        Ref = input.name,
                        //LineString = (LineString)((NetTopologySuite.Geometries.Polygon)polygonizer.GetPolygons().First()).ExteriorRing,
                    };
                    surfaces.Add(surface);
                }
                else {
                    var reference = curves.Single(e => local.First().Value.Contains(e));

                    if (equalsList.Contains(reference.LineString.ToString())) {
                        if (!equalsDictionary.ContainsKey(reference.LineString.ToString()))
                            equalsDictionary.Add(reference.LineString.ToString(), local.First().Value);
                    }

                    var surface = new SurfaceFeature {
                        Exterior = reference.Id,
                        Ref = input.name,
                    };
                    surfaces.Add(surface);
                }

                var elapsed = stopwatch.Elapsed - startTime;
                if (System.Diagnostics.Debugger.IsAttached) {
                    Log.Verbose("objectid: {objectid} {elapsed}", input.ObjectId, elapsed);
                }
            }
        }

    }
}