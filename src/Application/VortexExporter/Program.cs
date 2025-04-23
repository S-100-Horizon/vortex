using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using CommandLine;
using S100Framework.DomainModel;
using S100Framework.YAML;
using System.Diagnostics;
using Dataset = S100Framework.YAML.Dataset;
using Esri = ArcGIS.Core.Hosting.Host;
using IO = System.IO;

namespace S100Framework.Applications
{
    internal class VortexExporter
    {
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

                var s100TablePrefix = "";

                arguments.WithParsed<Options>(o => {
                    var geodatabase = o.Geodatabase.ToLowerInvariant();

                    if (IO.File.Exists(geodatabase) && ".sde".Equals(IO.Path.GetExtension(geodatabase), StringComparison.InvariantCultureIgnoreCase)) {
                        s100TablePrefix = "s101.";
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

                // Informationtypes
                try {
                    using var informationType = source.OpenDataset<Table>($"{s100TablePrefix}informationType");
                    using var informationCursor = informationType.Search(null, false);

                    while (informationCursor.MoveNext()) {
                        var current = informationCursor.Current;

                        var name = current["name"];
                        var code = current["code"].ToString()!;
                        var json = current["json"].ToString()!;

                        var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace("S101", "InformationTypes")}.{code}", true)!;

                        var instance = DBNull.Value.Equals(current["json"]) ? null : System.Text.Json.JsonSerializer.Deserialize(Convert.ToString(current["json"])!, type);

                        var information = new YAML.Information {
                            Name = code,
                            ID = $"{name}",
                            Attributes = (InformationNode)instance!,
                        };

                        dataset.AddInformation(information);
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine("Table: InformationType: " + ex.Message);
                    Logger.Current.Error("Exception: {ex}", ex);
                }

                var geometries = new List<(Geometry geometry, string name)>();

                // Features
                foreach (var def in source.GetDefinitions<FeatureClassDefinition>()) {
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


                            dataset.AddFeature(feature);
                            //dataset.AddGeometry(current.GetShape(), geometry!);

                            geometries.Add(new(current.GetShape(), geometry!));

                        }
                        catch (Exception ex) {
                            Console.WriteLine(ex.Message);
                            Logger.Current.Error("Exception: {ex}", ex);
                            continue;
                        }
                    }
                }

                foreach (var (geometry, name) in geometries.OrderBy(e => e.geometry.GeometryType)) {
                    dataset.AddGeometry(geometry, name!);
                }

                // Build composite curves from curves and change feature references
                //dataset.BuildTopologyFromCurves();

                // Ensure there are no unreferenced points
                //dataset.KillOrphanPoints();

                var yaml = S100Framework.YAML.Converter.Serialize(dataset);

                File.WriteAllText(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"101DK40349E.yaml"), yaml);

                sw.Stop();
                Console.WriteLine("Elapsed: " + sw.Elapsed.TotalSeconds);

                return 0;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
        private const string jsonSurface = "{\"rings\":[[[12.5,54.7015465],[12.4732885,54.694891],[12.4421088,54.6871107],[12.4323619,54.6790339],[12.4167304,54.6660724],[12.4093265,54.6599296],[12.4021195,54.6539479],[12.3978169,54.6503758],[12.3895268,54.6434911],[12.3772575,54.6332961],[12.3758783,54.6321497],[12.3700522,54.6273061],[12.3649871,54.623094],[12.3626519,54.6211517],[12.3590146,54.6181259],[12.3549381,54.6147341],[12.3494461,54.6101634],[12.3414574,54.6035126],[12.339328,54.6017394],[12.3362479,54.5991741],[12.3332861,54.596707],[12.3244586,54.5893516],[12.3170332,54.583162],[12.3015427,54.5702419],[12.2733278,54.5466828],[12.2612285,54.5365694],[12.2413132,54.5199097],[12.24082,54.5194969],[12.2396746,54.5185383],[12.2359635,54.5154316],[12.2285345,54.509211],[12.217541,54.5],[12.0,54.5],[12.0,55.0],[12.5,55.0],[12.5,54.7015465]]],\"spatialReference\":{\"wkid\":4326,\"latestWkid\":4326,\"xyTolerance\":3.5355339e-08,\"zTolerance\":0.001,\"mTolerance\":0.001,\"falseX\":-400,\"falseY\":-400,\"xyUnits\":99999999.99999999,\"falseZ\":-100000,\"zUnits\":10000,\"falseM\":-100000,\"mUnits\":10000}}";
    }
}

namespace S100Framework.YAML
{
    using ArcGIS.Core.Geometry;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using System.Text.RegularExpressions;

    public static class Extension
    {
        public static void AddGeometry(this Dataset dataset, ArcGIS.Core.Geometry.Geometry geometry, string name) {
            switch (geometry) {
                case MapPoint point: {                              // Point
                        var datasetPoint = dataset?.Points?.FirstOrDefault(e => e.Coordinate?.X == point.X && e?.Coordinate?.Y == point.Y);

                        if (datasetPoint == default) {
                            var p = new Point(point.X, point.Y) {
                                Name = $"{name}"
                            };

                            dataset!.AddPoint(p);
                        }
                        else {
                            Console.WriteLine("Point already exists");
                            dataset?.UpdateReferences(name, datasetPoint.Name!);
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
                case ArcGIS.Core.Geometry.Polyline polyline: {        // Curve
                        var vertices = polyline.Points.Select(p => new Coordinate(p.X, p.Y)).ToArray();
                        var id = Regex.Replace(name, @"\D", "");

                        // Create curve if another doesnt exist with the exact same vertices
                        _ = dataset.GetOrCreateCurve(vertices, id);

                        break;
                    }
                case ArcGIS.Core.Geometry.Polygon polygon: {         // Surface
                        if (polygon.ExteriorRingCount == 0 || polygon.ExteriorRingCount > 1)
                            throw new ArgumentException("Unsupported exterior ring count");

                        // WITH SURFACE TOPOLOGY
                        {
                            //var exteriorRing = polygon.GetExteriorRing(0);

                            //var exteriorCoordinates = exteriorRing.Parts[0].Select(segment => new Coordinate(segment.StartPoint.X, segment.StartPoint.Y)).ToArray();

                            //// Insert starting coordinate at the end of coordinate[] to ensure its a closed polygon
                            //exteriorCoordinates = [.. exteriorCoordinates, exteriorCoordinates[0]];

                            //var polygonCurve = new Curve(exteriorCoordinates) {
                            //    Name = name
                            //};

                            //var exterior = dataset.BuildTopology(polygonCurve);

                            //var surface = new Surface(exterior) {
                            //    Name = name,
                            //};

                            ////dataset.AddSurface(surface);
                            //var nameWithoutIdentifier = Regex.Replace(name, @"\D", "");


                            //// Add interior rings
                            //int id = 1;
                            //if (polygon.Parts.Count > 1) {
                            //    foreach (var interiorRing in polygon.Parts.Skip(1)) {
                            //        var interiorCoordinates = interiorRing.Select(segment => new Coordinate(segment.StartPoint.X, segment.StartPoint.Y)).ToArray();


                            //        // Insert starting coordinate at the end of coordinate[] to ensure its a closed polygon
                            //        interiorCoordinates = [.. interiorCoordinates, interiorCoordinates[0]];

                            //        var startPoint = dataset.GetStartPoint(interiorCoordinates, nameWithoutIdentifier, id);
                            //        var endPoint = dataset.GetEndPoint(interiorCoordinates, nameWithoutIdentifier, id + 1);

                            //        var interiorCurve = new Curve(startPoint, endPoint, interiorCoordinates) {
                            //            Name = $"C{nameWithoutIdentifier}-{id}",
                            //        };

                            //        var interior = dataset.BuildTopology(interiorCurve);
                            //        id++;
                            //        //dataset.AddCurve(interiorCurve);

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

        public static void UpdateReferences(this Dataset dataset, string original, string target) {
            Console.WriteLine($"Attempting to update feature: {original} to target {target}");
            if (original == target) {
                Console.WriteLine("Error! Original cant be same as target!");
                return;
            }

            foreach (var point in dataset?.Points?.Where(e => e.Name == original)?.ToList() ?? []) {
                Console.WriteLine(" - Deleting point");
                dataset?.Points?.Remove(point);
            }

            foreach (var exterior in dataset?.Surfaces?.Where(e => e.Exterior == original) ?? []) {
                Console.WriteLine($" - Replacing curve in exterior ring with original {original} and target: {target}");
                exterior.Exterior = target;
            }

            foreach (var ext in dataset?.Surfaces?.Where(e => e.InteriorRings != null && e.InteriorRings.Any(i => i == original)) ?? []) {
                for (int i = 0; i < ext.InteriorRings?.Length; i++) {
                    if (ext.InteriorRings[i] == original) {
                        ext.InteriorRings[i] = target;
                        Console.WriteLine($" - Replacing curve in interior ring with original {original} and target: {target}");
                    }
                }
            }

            foreach (var feature in dataset?.Features?.Where(e => e.Geometry == original) ?? []) {
                Console.WriteLine($" - Updating feature geometry reference with original {original} and target: {target}");
                feature.Geometry = target;
            }
        }

        public static Curve GetOrCreateCurve(this Dataset dataset, Coordinate[] coordinates, string name, int identifier = 0) {
            var tempCurve = new Curve(coordinates);
            var datasetCurve = dataset?.Curves?.FirstOrDefault(e => e.Vertices == tempCurve.Vertices);

            if (datasetCurve == default) {
                var first = dataset?.GetOrCreateStartPoint(coordinates, name, identifier);
                var last = dataset?.GetOrCreateEndPoint(coordinates, name, identifier + 1);

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
            var datasetPoint = dataset?.Points?.FirstOrDefault(e => e.Coordinate?.X == curve[0].X && e?.Coordinate?.Y == curve?[0].Y);

            if (datasetPoint == default) {
                var pointName = identifier == 0 ? $"P{name}" : $"P{name}-{identifier}";
                var point = new Point(curve[0].X, curve[0].Y) {
                    Name = pointName
                };

                dataset!.AddPoint(point);

                return point;
            }
            else {
                // Nessecary?
                //dataset.UpdateReferences($"P{name}", datasetPoint.Name);
                return datasetPoint;
            }
        }

        public static Point GetOrCreateEndPoint(this Dataset dataset, Coordinate[] curve, string name, int identifier = 1) {
            var datasetPoint = dataset?.Points?.FirstOrDefault(e => e.Coordinate?.X == curve[^1].X && e?.Coordinate?.Y == curve?[^1].Y);

            if (datasetPoint == default) {
                var pointName = $"P{name}-{identifier}";
                var point = new Point(curve[^1].X, curve[^1].Y) {
                    Name = pointName
                };

                dataset!.AddPoint(point);

                return point;
            }
            else {
                // Nessecary?
                //dataset.UpdateReferences($"P{name}", datasetPoint.Name);
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

        public static void KillOrphanPoints(this Dataset dataset) {

            int i = 0;
            var points = dataset?.Points?.ToList() ?? [];
            foreach (var point in points) {
                // Check if point is referenced by a feature
                if (dataset?.Features?.Where(e => e.Geometry == point.Name).Any() ?? true)
                    continue;

                // Check if point is referenced in a startCurve
                if (dataset?.Curves?.Where(e => e.Start == point.Name).Any() ?? true)
                    continue;

                // Check if point is referenced in a endCurve
                if (dataset?.Curves?.Where(e => e.End == point.Name).Any() ?? true)
                    continue;


                // Remove if passed all 3 guards
                dataset?.Points?.Remove(point);
                i++;

                Console.WriteLine("Removing orphan point: " + point.Name);
            }
            Console.WriteLine("Points interated: " + points.Count);
            Console.WriteLine("Orphan points removed in total: " + i);
        }

        // https://pro.arcgis.com/en/pro-app/latest/tool-reference/data-management/polygon-to-line.htm
        #region Surface and Curve Topology
        //public static void BuildTopologyFromCurves(this Dataset dataset) {
        //    foreach (var polygonCurve in dataset.Curves.ToList()) {
        //        var coordinateStr = polygonCurve.Vertices;
        //        var id = Regex.Replace(polygonCurve.Name, @"\D", "");
        //        var matches = 0;

        //        // Check for a curve match for all curves in dataset
        //        foreach (var curve in dataset.Curves.Where(e => coordinateStr.Contains(e.Vertices) && e.Name != polygonCurve.Name)) {
        //            coordinateStr = coordinateStr.Replace(curve.Vertices, curve.Name);
        //            matches++;
        //        }

        //        // If there are no matches for any segments of this curve, leave it as is
        //        if (matches == 0)
        //            continue;


        //        var split = coordinateStr.Split(",");

        //        // If there is one match with no trailing coordinates, reference this match instead
        //        if (split.Length == 1) {
        //            // Change all feature references
        //            dataset.UpdateReferences(polygonCurve.Name, coordinateStr);

        //            continue;
        //        }


        //        // If string only consists of curves, create CompositeCurve from these and reference the compositeCurve instead everywhere
        //        if (split.All(s => s.StartsWith('C'))) {
        //            var composite = new CompositeCurve(coordinateStr) {
        //                Name = $"CC{id}"
        //            };

        //            dataset.AddCompositeCurve(composite);
        //            dataset.UpdateReferences(polygonCurve.Name, composite.Name);

        //            continue;
        //        }


        //        // If string contains a mix of curves and coordinates, take all coordinates and create curves from them. replace them in the string
        //        var curveIndices = split.Select((s, i) => new { s, i }).Where(x => x.s.StartsWith('C')).Select(x => x.i).Append(split.Length);

        //        var startIndex = 0;
        //        var s2r = "";
        //        int curveId = 0;

        //        foreach (var index in curveIndices) {
        //            var range = new Range(startIndex, index);

        //            startIndex = index + 1;

        //            var curvesStr = split.Take(range).ToArray();

        //            // If uneven and ends with a point
        //            if (curvesStr.Length % 2 != 0) {
        //                curvesStr = [.. curvesStr.SkipLast(1)];
        //            }

        //            if (curvesStr.Length == 0) {
        //                continue;
        //            }

        //            if (curvesStr.Length % 2 == 0 && curvesStr.Length > 3) {
        //                var coords = BuildCoordinateFromStringArray(curvesStr);

        //                var curve = dataset.GetOrCreateCurve(coords, id, curveId);

        //                s2r = string.Join(",", curvesStr);

        //                coordinateStr = coordinateStr.Replace(s2r, curve.Name);
        //            }

        //            curveId++;
        //        }

        //        var polygonSplit = coordinateStr.Split(",");

        //        // If string only consists of curves, create CompositeCurve from these
        //        if (polygonSplit.All(s => s.StartsWith('C'))) {
        //            var compCurve = new CompositeCurve(coordinateStr) {
        //                Name = $"CC{id}"
        //            };
        //            dataset.AddCompositeCurve(compCurve);

        //            dataset.UpdateReferences(polygonCurve.Name, compCurve.Name);

        //            continue;
        //        }

        //        var coordinatesSplit = polygonSplit.Where(e => !e.StartsWith('C'));

        //        var pairs = new List<(decimal X, decimal Y, string Position, int Index)>();

        //        // Detect remaining coordinates
        //        for (int i = 0; i < polygonSplit.Length - 1; i++) {
        //            if (decimal.TryParse(polygonSplit[i], CultureInfo.InvariantCulture, out decimal x) &&
        //                decimal.TryParse(polygonSplit[i + 1], CultureInfo.InvariantCulture, out decimal y)) {
        //                var position = "";
        //                if (i == 0)
        //                    position = "Start";
        //                else if (i == polygonSplit.Length - 2)
        //                    position = "End";
        //                else
        //                    position = "Mid";
        //                pairs.Add((x, y, position, i));
        //                i++; // Skip the next element since it's part of the pair
        //            }
        //        }

        //        var replacementDict = new Dictionary<string, string>();

        //        // Iterate remaining coordinates and replace them with curves
        //        foreach (var coordinate in pairs) {
        //            var strToReplace = $"{coordinate.X.ToString(CultureInfo.InvariantCulture)},{coordinate.Y.ToString(CultureInfo.InvariantCulture)}";
        //            if (coordinate.Position == "Start") {
        //                //Console.WriteLine("Found at the start! " + coordinatesSplit.Count());
        //                var curve = polygonSplit.Skip(2).First();

        //                // Find the next 
        //                var next = dataset.Curves.FirstOrDefault(e => e.Name == curve).Vertices.Split(",").Take(2);

        //                var combinedArray = next.Concat(coordinatesSplit).ToArray();

        //                var coords = BuildCoordinateFromStringArray(combinedArray);

        //                var curveFromComposite = dataset.GetOrCreateCurve(coords, id, 111);


        //                replacementDict.Add(strToReplace, curveFromComposite.Name);

        //            }
        //            else if (coordinate.Position == "End") {
        //                //Console.WriteLine("Found at the End! " + coordinatesSplit.Count());
        //                var curve = polygonSplit.SkipLast(2).Last();

        //                // Find the previous 
        //                var previous = dataset.Curves.FirstOrDefault(e => e.Name == curve).Vertices.Split(",").TakeLast(2);

        //                var combinedArray = previous.Concat(coordinatesSplit).ToArray();

        //                var coords = BuildCoordinateFromStringArray(combinedArray);

        //                var curveFromComposite = dataset.GetOrCreateCurve(coords, id, 999);

        //                replacementDict.Add(strToReplace, curveFromComposite.Name);
        //            }
        //            else if (coordinate.Position == "Mid") {
        //                //Console.WriteLine("Found at the Middle! " + coordinatesSplit.Count());

        //                // Find the previous 
        //                var previousCurve = polygonSplit[coordinate.Index - 1];
        //                var previous = dataset.Curves.FirstOrDefault(e => e.Name == previousCurve).Vertices.Split(",").TakeLast(coordinatesSplit.Count());

        //                // Find the next
        //                var nextCurve = polygonSplit[coordinate.Index + 2];
        //                var next = dataset.Curves.FirstOrDefault(e => e.Name == nextCurve).Vertices.Split(",").Take(coordinatesSplit.Count());

        //                var combinedArray = previous.Concat(coordinatesSplit).Concat(next).ToArray();

        //                var cd = BuildCoordinateFromStringArray(coordinatesSplit.ToArray());


        //                var curveFromComposite = dataset.GetOrCreateCurve(cd, id, 555);

        //                replacementDict.Add(strToReplace, curveFromComposite.Name);
        //            }
        //            else {
        //                Console.WriteLine("Leftover! couldnt find anywhere" + polygonCurve.Name);
        //            }
        //        }

        //        foreach (var kvp in replacementDict) {
        //            coordinateStr = coordinateStr.Replace(kvp.Key, kvp.Value);
        //        }
        //        polygonSplit = coordinateStr.Split(",");

        //        if (polygonSplit.Any(e => !e.StartsWith('C'))) {
        //            Console.WriteLine("STILL missing! " + polygonCurve.Name);
        //        }

        //        //Create a new composite curve with these coordinates
        //        var compositeCurve = new CompositeCurve(coordinateStr) {
        //            Name = $"CC{id}"
        //        };

        //        dataset.AddCompositeCurve(compositeCurve);
        //        dataset.UpdateReferences(polygonCurve.Name, compositeCurve.Name);

        //        continue;
        //    }
        //}














        //public static string BuildTopology(this Dataset dataset, Curve polygonCurve) {
        //    var polygonStr = polygonCurve.Vertices;
        //    var id = Regex.Replace(polygonCurve.Name, @"\D", "");

        //    var curvesFound = 0;

        //    // Check for a curve match for all curves in dataset
        //    foreach (var curve in dataset.Curves) {
        //        if (polygonStr.Contains(curve.Vertices)) {
        //            curvesFound++;
        //        }

        //        polygonStr = polygonStr.Replace(curve.Vertices, curve.Name);
        //    }

        //    var split = polygonStr.Split(",");

        //    // If string contains no curves, create new curve that contains entire coordinate[]
        //    if (curvesFound == 0) {
        //        var curve = dataset.GetOrCreateCurve(polygonCurve.Coordinate, id);
        //        //var first = dataset.GetOrCreateStartPoint(polygonCurve.Coordinate, id);
        //        //var last = dataset.GetOrCreateEndPoint(polygonCurve.Coordinate, id);
        //        //var curve = new Curve(first, last, polygonCurve.Coordinate) {
        //        //    Name = $"C{id}_0"
        //        //};
        //        //dataset.AddCurve(curve);
        //        return curve.Name;
        //    }

        //    // If string contains just one curve, reference it directly
        //    if (split.Length == 1) {
        //        return polygonStr;
        //    }

        //    // If string only consists of curves, create CompositeCurve from these
        //    if (split.All(s => s.StartsWith('C'))) {
        //        var composite = new CompositeCurve(polygonStr) {
        //            Name = $"CC{id}"
        //        };

        //        dataset.AddCompositeCurve(composite);

        //        return composite.Name;
        //    }


        //    // If string contains a mix of curves and coordinates, take all coordinates and create curves from them. replace them in the string
        //    try {
        //        var curveIndices = split.Select((s, i) => new { s, i }).Where(x => x.s.StartsWith('C')).Select(x => x.i).Append(split.Length);

        //        var startIndex = 0;
        //        var s2r = "";
        //        int curveId = 0;

        //        foreach (var index in curveIndices) {
        //            var range = new Range(startIndex, index);

        //            startIndex = index + 1;

        //            var curvesStr = split.Take(range).ToArray();

        //            // If uneven and ends with a point
        //            if (curvesStr.Length % 2 != 0) {
        //                curvesStr = [.. curvesStr.SkipLast(1)];
        //            }

        //            if (curvesStr.Length == 0) {
        //                //Console.WriteLine("Skipped: " + polygonCurve.Name);
        //                continue;
        //            }

        //            if (curvesStr.Length % 2 == 0 && curvesStr.Length > 3) {
        //                var coords = BuildCoordinateFromStringArray(curvesStr);
        //                var first = dataset.GetOrCreateStartPoint(coords, id);
        //                var last = dataset.GetOrCreateEndPoint(coords, id);
        //                var curve = new Curve(first, last, coords) {
        //                    Name = $"C{id}_{curveId}"
        //                };
        //                dataset.AddCurve(curve);

        //                s2r = string.Join(",", curvesStr);

        //                polygonStr = polygonStr.Replace(s2r, curve.Name);
        //            }

        //            curveId++;
        //        }

        //        var polygonSplit = polygonStr.Split(",");

        //        // If string only consists of curves, create CompositeCurve from these
        //        if (polygonSplit.All(s => s.StartsWith('C'))) {
        //            var compCurve = new CompositeCurve(polygonStr) {
        //                Name = $"CC{id}"
        //            };
        //            dataset.AddCompositeCurve(compCurve);

        //            return compCurve.Name;
        //        }

        //        var coordinatesSplit = polygonSplit.Where(e => !e.StartsWith('C'));

        //        var pairs = new List<(decimal X, decimal Y, string Position, int Index)>();

        //        // Detect remaining coordinates
        //        for (int i = 0; i < polygonSplit.Length - 1; i++) {
        //            if (decimal.TryParse(polygonSplit[i], CultureInfo.InvariantCulture, out decimal x) &&
        //                decimal.TryParse(polygonSplit[i + 1], CultureInfo.InvariantCulture, out decimal y)) {
        //                var position = "";
        //                if (i == 0)
        //                    position = "Start";
        //                else if (i == polygonSplit.Length - 2)
        //                    position = "End";
        //                else
        //                    position = "Mid";
        //                pairs.Add((x, y, position, i));
        //                i++; // Skip the next element since it's part of the pair
        //            }
        //        }

        //        var replacementDict = new Dictionary<string, string>();

        //        // Iterate remaining coordinates and replace them with curves
        //        foreach (var coordinate in pairs) {
        //            var strToReplace = $"{coordinate.X.ToString(CultureInfo.InvariantCulture)},{coordinate.Y.ToString(CultureInfo.InvariantCulture)}";
        //            if (coordinate.Position == "Start") {
        //                Console.WriteLine("Found at the start! " + coordinatesSplit.Count());
        //                var curve = polygonSplit.Skip(2).First();

        //                // Find the next 
        //                var next = dataset.Curves.FirstOrDefault(e => e.Name == curve).Vertices.Split(",").Take(2);

        //                var combinedArray = next.Concat(coordinatesSplit).ToArray();

        //                var coords = BuildCoordinateFromStringArray(combinedArray);

        //                var first = dataset.GetOrCreateStartPoint(coords, $"{id}");
        //                var last = dataset.GetOrCreateEndPoint(coords, $"{id}");
        //                var curveFromComposite = new Curve(first, last, coords) {
        //                    Name = $"C{id}_111"
        //                };

        //                dataset.AddCurve(curveFromComposite);

        //                replacementDict.Add(strToReplace, curveFromComposite.Name);
        //                //polygonStr = polygonStr.Replace(strToReplace, curveFromComposite.Name);
        //                //polygonSplit = polygonStr.Split(",");
        //            }
        //            else if (coordinate.Position == "End") {
        //                Console.WriteLine("Found at the End! " + coordinatesSplit.Count());
        //                var curve = polygonSplit.SkipLast(2).Last();

        //                // Find the previous 
        //                var previous = dataset.Curves.FirstOrDefault(e => e.Name == curve).Vertices.Split(",").TakeLast(2);

        //                var combinedArray = previous.Concat(coordinatesSplit).ToArray();

        //                var coords = BuildCoordinateFromStringArray(combinedArray);

        //                var first = dataset.GetOrCreateStartPoint(coords, $"{id}");
        //                var last = dataset.GetOrCreateEndPoint(coords, $"{id}");

        //                var curveFromComposite = new Curve(first, last, coords) {
        //                    Name = $"C{id}_999"
        //                };

        //                dataset.AddCurve(curveFromComposite);

        //                replacementDict.Add(strToReplace, curveFromComposite.Name);
        //            }
        //            else if (coordinate.Position == "Mid") {
        //                Console.WriteLine("Found at the Middle! " + coordinatesSplit.Count());

        //                // Find the previous 
        //                var previousCurve = polygonSplit[coordinate.Index - 1];
        //                var previous = dataset.Curves.FirstOrDefault(e => e.Name == previousCurve).Vertices.Split(",").TakeLast(coordinatesSplit.Count());

        //                // Find the next
        //                var nextCurve = polygonSplit[coordinate.Index + 2];
        //                var next = dataset.Curves.FirstOrDefault(e => e.Name == nextCurve).Vertices.Split(",").Take(coordinatesSplit.Count());

        //                var combinedArray = previous.Concat(coordinatesSplit).Concat(next).ToArray();

        //                var cd = BuildCoordinateFromStringArray(coordinatesSplit.ToArray());
        //                var first = dataset.GetOrCreateStartPoint(cd, $"{id}");
        //                var last = dataset.GetOrCreateEndPoint(cd, $"{id}");

        //                var curveFromComposite = new Curve(first, last, cd) {
        //                    Name = $"C{id}_555"
        //                };

        //                dataset.AddCurve(curveFromComposite);

        //                replacementDict.Add(strToReplace, curveFromComposite.Name);
        //            }
        //            else {
        //                Console.WriteLine("Leftover! couldnt find anywhere" + polygonCurve.Name);
        //            }
        //        }

        //        foreach (var kvp in replacementDict) {
        //            polygonStr = polygonStr.Replace(kvp.Key, kvp.Value);
        //        }
        //        polygonSplit = polygonStr.Split(",");

        //        if (polygonSplit.Any(e => !e.StartsWith('C'))) {
        //            Console.WriteLine("STILL missing! " + polygonCurve.Name);
        //        }

        //        //Create a new composite curve with these coordinates
        //        var compositeCurve = new CompositeCurve(polygonStr) {
        //            Name = $"CC{id}"
        //        };

        //        dataset.AddCompositeCurve(compositeCurve);

        //        return compositeCurve.Name;
        //    }
        //    catch (Exception ex) {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return polygonStr;
        //}

        #endregion
    }
}