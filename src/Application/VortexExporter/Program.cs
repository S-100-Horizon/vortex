using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using CommandLine;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S124.FeatureTypes;
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
            [Option('d', "dataset", Required = false, HelpText = "")]
            public string? Dataset { get; set; }

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

                Func<Geodatabase> createGeodatabase = () => { throw new NotImplementedException(); };
                ;

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
                });

                var shape = GeometryEngine.Instance.ImportFromJson(JsonImportFlags.JsonImportDefaults, jsonSurface);
                using Geodatabase source = createGeodatabase();

                var featureCatalogue = S100Framework.Catalogues.FeatureCatalogue.Catalogues.Single(e => e.ProductID.Equals("S-101"));

                // Create dataset
                var dataset = new Dataset() {
                    CellName = "101DK40349E.000",
                    Comment = "Test Dataset",
                    Edition = 1,
                    ENCVer = "INT.IHO.S-101.2.0",
                    FCVer = "2.0.0",
                };

                var geometries = new List<(Geometry geometry, string name)>();
                var featureAssociations = new Dictionary<string, YAML.Association[]>();

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
                                Attributes = (FeatureNode)instance!,
                            };

                            // Associations
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
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using System.Text.RegularExpressions;

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
                case ArcGIS.Core.Geometry.Polyline polyline: {        // Curve
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
                case ArcGIS.Core.Geometry.Polygon polygon: {         // Surface
                        if (polygon.ExteriorRingCount == 0 || polygon.ExteriorRingCount > 1)
                            throw new ArgumentException("Unsupported exterior ring count");

                        // WITH SURFACE TOPOLOGY
                        {
                            //var nameWithoutIdentifier = Regex.Replace(name, @"\D", "");

                            //var exteriorRing = polygon.GetExteriorRing(0);

                            //var exteriorCoordinates = exteriorRing.Parts[0].Select(segment => new Coordinate(segment.StartCoordinate.X, segment.StartCoordinate.Y)).ToArray();

                            //// Insert starting coordinate at the end of coordinate[] to ensure its a closed polygon
                            //exteriorCoordinates = [.. exteriorCoordinates, exteriorCoordinates[0]];

                            //var exteriorCurve = new Curve(exteriorCoordinates) {
                            //    Name = nameWithoutIdentifier
                            //};

                            //var exterior = dataset.BuildTopology(exteriorCurve);

                            //var surface = new Surface(exterior) {
                            //    Name = name,
                            //};

                            //// Add interior rings
                            //int id = 1;
                            //if (polygon.Parts.Count > 1) {
                            //    foreach (var interiorRing in polygon.Parts.Skip(1)) {
                            //        var interiorCoordinates = interiorRing.Select(segment => new Coordinate(segment.StartPoint.X, segment.StartPoint.Y)).ToArray();

                            //        // Insert starting coordinate at the end of coordinate[] to ensure its a closed polygon
                            //        interiorCoordinates = [.. interiorCoordinates, interiorCoordinates[0]];

                            //        var interiorCurve = new Curve(interiorCoordinates) {
                            //            Name = $"{nameWithoutIdentifier}-{id}"
                            //        };

                            //        var interior = dataset.BuildTopology(interiorCurve);

                            //        id++;

                            //        if (surface.InteriorRings == null) {
                            //            surface.InteriorRings = [interior];
                            //        }
                            //        else {
                            //            surface.InteriorRings = [.. surface.InteriorRings, interior];
                            //        }
                            //    }
                            //    ;
                            //}
                            //dataset.AddSurface(surface);
                        }

                        // WITHOUT TOPOLOGY
                        {
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
                                ;
                            }
                            dataset.AddSurface(surface);
                        }
                        break;
                    }
                default:
                    throw new ArgumentException($"Unsupported geometry type: {geometry.GeometryType}");
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

        public static string BuildTopology(this Dataset dataset, Curve polygonCurve) {
            var polygonStr = polygonCurve.Vertices;
            var id = Regex.Replace(polygonCurve.Name, @"\D", "");

            var curvesFound = 0;

            foreach (var curve in dataset.Curves) {
                if (polygonStr.Contains(curve.Vertices)) {
                    curvesFound++;

                    var curveWithCoord = $"{curve.Name}";

                    //// If entire curve == polygonStr, replace everything and dont add surrounding coordinates
                    //if (polygonStr == curve.Vertices) {
                    ////    curveWithCoord = $"{curve.Name}";
                    //}
                    //// If start of curveStr, omit coordinate before
                    //else if (polygonStr.StartsWith(curve.Vertices)) {
                    //    var last = curve.Coordinate.Last();
                    //    curveWithCoord = $"{curve.Name},{string.Format(CultureInfo.InvariantCulture, "{0:0.0000000},{1:0.0000000}", last.X, last.Y)}";
                    //}
                    //// If End of curveStr, omit coordinate before
                    //else if (polygonStr.EndsWith(curve.Vertices)) {
                    //    var first = curve.Coordinate.First();
                    //    curveWithCoord = $"{string.Format(CultureInfo.InvariantCulture, "{0:0.0000000},{1:0.0000000}", first.X, first.Y)},{curve.Name}";
                    //}
                    //// If middle of str, keep everything
                    //else if (polygonStr.Contains(curve.Vertices)) {
                    //    var first = curve.Coordinate.First();
                    //    var firstStr = string.Format(CultureInfo.InvariantCulture, "{0:0.0000000},{1:0.0000000}", first.X, first.Y);

                    //    var last = curve.Coordinate.Last();
                    //    var lastStr = string.Format(CultureInfo.InvariantCulture, "{0:0.0000000},{1:0.0000000}", last.X, last.Y);

                    //    curveWithCoord = $"{firstStr},{curve.Name},{lastStr}";
                    //}
                    //else {
                    //    continue;
                    //}

                    polygonStr = polygonStr.Replace(curve.Vertices, curveWithCoord);
                }
                else if (polygonStr.Contains(curve.ReversedVertices)) {
                    curvesFound++;
                    var curveWithCoord = $"R{curve.Name}";

                    //// If entire curve == polygonStr, replace everything and dont add surrounding coordinates
                    //if (polygonStr == curve.ReversedVertices) {
                    ////    curveWithCoord = $"R{curve.Name}";
                    //}
                    //// If start of curveStr, omit coordinate before
                    //else if (polygonStr.StartsWith(curve.ReversedVertices)) {
                    //    var last = curve.Coordinate.First();
                    //    curveWithCoord = $"R{curve.Name},{string.Format(CultureInfo.InvariantCulture, "{0:0.0000000},{1:0.0000000}", last.X, last.Y)}";
                    //}
                    //// If End of curveStr, omit coordinate before
                    //else if (polygonStr.EndsWith(curve.ReversedVertices)) {
                    //    var first = curve.Coordinate.Last();
                    //    curveWithCoord = $"{string.Format(CultureInfo.InvariantCulture, "{0:0.0000000},{1:0.0000000}", first.X, first.Y)},R{curve.Name}";
                    //}
                    //// If middle of str, keep everything
                    //else if (polygonStr.Contains(curve.ReversedVertices)) {
                    //    var first = curve.Coordinate.Last();
                    //    var firstStr = string.Format(CultureInfo.InvariantCulture, "{0:0.0000000},{1:0.0000000}", first.X, first.Y);

                    //    var last = curve.Coordinate.First();
                    //    var lastStr = string.Format(CultureInfo.InvariantCulture, "{0:0.0000000},{1:0.0000000}", last.X, last.Y);

                    //    curveWithCoord = $"{firstStr},R{curve.Name},{lastStr}";
                    //}
                    //else {
                    //    continue;
                    //}

                    polygonStr = polygonStr.Replace(curve.ReversedVertices, curveWithCoord);
                }
            }

            // If string contains no curves, create new curve that contains entire coordinate[]
            if (curvesFound == 0) {
                //var curve = dataset.GetOrCreateCurve(polygonCurve.Coordinate, id);
                Log.Information("No shared or existing vertices detected for: {id}", id);
                var first = dataset?.GetOrCreateStartPoint(polygonCurve.Coordinate, id);
                var last = dataset.GetOrCreateEndPoint(polygonCurve.Coordinate, id);
                var curve = new Curve(first!, last!, polygonCurve.Coordinate) {
                    Name = $"C{id}",
                };

                dataset!.AddCurve(curve);

                return curve.Name;
            }

            // If string contains just one curve, reference it directly
            if (polygonStr.Split(",").Length == 1) {
                return polygonStr;
            }

            var compositeCurveArr = polygonStr.Split(",");

            // If coordinate but has references surrounding it, clip it and ship it
            for (int i = 0; i < compositeCurveArr.Length; i++) {
                var item = compositeCurveArr[i];

                bool IsReference(string s) => s.StartsWith('C') || s.StartsWith('R');
                bool IsCoordinate(string s) => double.TryParse(s, out _);

                if (IsReference(item))
                    continue;

                // It's only half a coordinate
                if (i == compositeCurveArr.Length - 1 || !IsCoordinate(compositeCurveArr[i + 1])) {
                    Log.Information("error: single coordinate without a pair");
                    continue;
                }

                // Pair exists
                var x = compositeCurveArr[i];
                var y = compositeCurveArr[i + 1];

                // Lookahead + lookbehind for context
                string before = i - 1 >= 0 ? compositeCurveArr[i - 1] : null;
                string after = i + 2 < compositeCurveArr.Length ? compositeCurveArr[i + 2] : null;

                bool beforeRef = before != null && IsReference(before);
                bool afterRef = after != null && IsReference(after);

                // If the single coordinate has references surrounding it, remove it
                if (beforeRef && afterRef) {
                    // middle test
                    polygonStr = polygonStr.Replace($"{x},{y}", "").Replace(",,", ",").Trim(',');
                    i++;
                    continue;

                    var next = dataset?.Curves?.FirstOrDefault(e => e.Name == after.Replace("R", ""));
                    var nextCoordinates = after.StartsWith('R') ? next.Coordinate.Last() : next.Coordinate.First();

                    var previous = dataset?.Curves?.FirstOrDefault(e => e.Name == before.Replace("R", ""));
                    var previousCoordinates = before.StartsWith('R') ? previous.Coordinate.First() : previous.Coordinate.Last();

                    var combined = new string[] {
                        string.Format(CultureInfo.InvariantCulture, "{0:0.0000000}", previousCoordinates.X),
                        string.Format(CultureInfo.InvariantCulture, "{0:0.0000000}", previousCoordinates.Y),
                        x,
                        y,
                        string.Format(CultureInfo.InvariantCulture, "{0:0.0000000}", nextCoordinates.X),
                        string.Format(CultureInfo.InvariantCulture, "{0:0.0000000}", nextCoordinates.Y),
                    };

                    var combinedCoordinatesArr = BuildCoordinateFromStringArray(combined);

                    var combinedStart = dataset.GetOrCreateStartPoint(combinedCoordinatesArr, $"{id}-555");
                    var combinedEnd = dataset.GetOrCreateEndPoint(combinedCoordinatesArr, $"{id}-555");
                    var curve = new Curve(combinedStart, combinedEnd, combinedCoordinatesArr) {
                        Name = $"C{id}-{i}-555"
                    };

                    dataset.AddCurve(curve);

                    polygonStr = polygonStr.Replace($"{x},{y}", curve.Name);

                    Log.Information("middle pair between refs: {before}, {after}", before, after);
                }
                // If the single coordinate is at the end of array and has reference before it, remove it
                else if (beforeRef && after == null) {
                    // middle test
                    polygonStr = polygonStr.Replace($"{x},{y}", "").Replace(",,", ",").Trim(',');
                    i++;
                    continue;

                    var previous = dataset?.Curves?.FirstOrDefault(e => e.Name == before.Replace("R", ""));
                    var previousCoordinates = before.StartsWith('R') ? previous.Coordinate.First() : previous.Coordinate.Last();

                    var combined = new string[] {
                        string.Format(CultureInfo.InvariantCulture, "{0:0.0000000}", previousCoordinates.X),
                        string.Format(CultureInfo.InvariantCulture, "{0:0.0000000}", previousCoordinates.Y),
                        x,
                        y,
                    };

                    var combinedCoordinatesArr = BuildCoordinateFromStringArray(combined);
                    var combinedStart = dataset.GetOrCreateStartPoint(combinedCoordinatesArr, $"{id}-999");
                    var combinedEnd = dataset.GetOrCreateEndPoint(combinedCoordinatesArr, $"{id}-999");
                    var curve = new Curve(combinedStart, combinedEnd, combinedCoordinatesArr) {
                        Name = $"C{id}-{i}-999"
                    };

                    dataset.AddCurve(curve);
                    polygonStr = polygonStr.Replace($"{x},{y}", curve.Name);

                    Log.Information("end pair after ref: {before}", before);
                }
                // If the single coordinate is at the start of array and has reference after it, remove it
                else if (before == null && afterRef) {
                    // middle test
                    polygonStr = polygonStr.Replace($"{x},{y}", "").Replace(",,", ",").Trim(',');
                    i++;
                    continue;

                    var next = dataset?.Curves?.FirstOrDefault(e => e.Name == after.Replace("R", ""));
                    var nextCoordinates = after.StartsWith('R') ? next.Coordinate.Last() : next.Coordinate.First();

                    var combined = new string[] {
                        x,
                        y,
                        string.Format(CultureInfo.InvariantCulture, "{0:0.0000000}", nextCoordinates.X),
                        string.Format(CultureInfo.InvariantCulture, "{0:0.0000000}", nextCoordinates.Y),
                    };

                    var combinedCoordinatesArr = BuildCoordinateFromStringArray(combined);

                    var combinedStart = dataset.GetOrCreateStartPoint(combinedCoordinatesArr, $"{id}-111");
                    var combinedEnd = dataset.GetOrCreateEndPoint(combinedCoordinatesArr, $"{id}-111");
                    var curve = new Curve(combinedStart, combinedEnd, combinedCoordinatesArr) {
                        Name = $"C{id}-{i}-111"
                    };

                    dataset.AddCurve(curve);

                    // only replace the first occurence
                    var target = $"{x},{y}";
                    var index = polygonStr.IndexOf(target);
                    if (index != -1) {
                        polygonStr = polygonStr.Substring(0, index) + curve.Name + polygonStr.Substring(index + target.Length);
                    }

                    Log.Information("start pair before ref: {after}", after);
                }
                // Replace entire curve in polygonStr between two curve references
                else {
                    var coords = new List<string> {
                        x,
                        y
                    };

                    // Look ahead until no more coordinate pairs.
                    for (int j = i + 2; j + 1 < compositeCurveArr.Length; j += 2) {
                        if (!IsCoordinate(compositeCurveArr[j]) || !IsCoordinate(compositeCurveArr[j + 1])) break;

                        coords.Add(compositeCurveArr[j]);     // x
                        coords.Add(compositeCurveArr[j + 1]); // y
                        i += 2;
                    }

                    var coordinatesArr = BuildCoordinateFromStringArray([.. coords]);

                    var start = dataset.GetOrCreateStartPoint(coordinatesArr, id);
                    var end = dataset.GetOrCreateEndPoint(coordinatesArr, id);
                    var curve = new Curve(start, end, coordinatesArr) {
                        Name = $"C{id}-{i}"
                    };

                    dataset.AddCurve(curve);

                    // replace both just in case
                    polygonStr = polygonStr.Replace(curve.Vertices, curve.Name);

                    Log.Information("Creating curve from remaining coordinates");
                }

                i++; // skip the next one since we handled a pair
            }

            // If string only consists of curves or reverseCurves, create CompositeCurve from these
            if (polygonStr.Split(",").All(s => s.StartsWith('C') || s.StartsWith('R'))) {
                var composite = new CompositeCurve(polygonStr) {
                    Name = $"CC{id}"
                };

                // To-Do: Handle duplicate composite curves? unlikely..
                dataset.AddCompositeCurve(composite);
                dataset.UpdateFeatureReferences(polygonCurve.Name, composite.Name);

                return composite.Name;
            }

            // Shouldn't reach here. Means composite curve still has remaining coordinates
            Log.Error("Surface {surface} still has remaining coordinates when building composite key", polygonCurve.Name);
            Log.Information("Compsite curve: {comp}", polygonStr);
            return polygonStr;

        }
    }
}