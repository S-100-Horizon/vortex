using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using CommandLine;
using S100Framework.DomainModel;
using S100Framework.YAML;
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
                CellName = "DK40349E.000",
                Comment = "Test Dataset"
            };


            // Informationtypes
            using var informationType = source.OpenDataset<Table>("s101.informationType");
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
            // Features
            foreach (var def in source.GetDefinitions<FeatureClassDefinition>()) {
                using var fc = source.OpenDataset<FeatureClass>(def.GetName());

                var filter = new SpatialQueryFilter {
                    FilterGeometry = shape,
                    SpatialRelationship = SpatialRelationship.Contains,
                };

                using var cursor = fc.Search(filter, true);
                while (cursor.MoveNext()) {
                    var current = (ArcGIS.Core.Data.Feature)cursor.Current;
                    var geometry = Convert.ToString(current["name"]);

                    var name = Convert.ToString(current["code"]);
                    var foid = $"110:{current.GetObjectID()}:1";       // Geodatastyrelsen (GST) 110 

                    var shaptyp = def.GetShapeType();


                    var prim = shaptyp switch {
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
                        dataset.AddGeometry(current.GetShape(), geometry!);
                    } catch(Exception ex) {
                        Console.WriteLine(ex.Message);
                        Logger.Current.Error("Exception: {ex}", ex);
                        continue;
                    }
                }
            }

            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            File.WriteAllText(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "test.yaml"), yaml);
            //Console.WriteLine(yaml);
            return 0;
        }

        private const string jsonSurface = "{\"rings\":[[[12.500000000000057,54.701546510000071],[12.473288500000081,54.694891000000041],[12.442108800000085,54.687110700000062],[12.432361900000046,54.679033900000093],[12.416730400000063,54.666072400000076],[12.409326500000077,54.659929600000055],[12.402119500000083,54.653947900000048],[12.397816900000066,54.650375800000063],[12.389526800000056,54.643491100000062],[12.377257500000042,54.633296100000052],[12.375878300000068,54.63214970000007],[12.370052200000089,54.627306100000055],[12.364987100000064,54.623094000000094],[12.36265190000006,54.621151700000041],[12.35901460000008,54.618125900000052],[12.354938100000084,54.614734100000078],[12.34944610000008,54.61016340000009],[12.341457400000081,54.603512600000045],[12.33932800000008,54.601739400000042],[12.336247900000046,54.599174100000084],[12.333286100000066,54.596707000000094],[12.324458600000071,54.589351600000043],[12.317033200000083,54.583162000000073],[12.301542700000084,54.570241900000042],[12.273327800000061,54.546682800000042],[12.261228500000072,54.536569400000076],[12.241313200000036,54.519909700000085],[12.240820000000042,54.519496900000092],[12.239674600000058,54.518538300000046],[12.235963500000082,54.515431600000056],[12.22853450000008,54.50921100000005],[12.217540970000073,54.500000000000057],[12.000000000000057,54.500000000000057],[12.000000000000057,55.000000000000057],[12.500000000000057,55.000000000000057],[12.500000000000057,54.701546510000071]]],\"spatialReference\":{\"wkid\":4326,\"latestWkid\":4326,\"xyTolerance\":3.5355339e-08,\"zTolerance\":0.001,\"mTolerance\":0.001,\"falseX\":-400,\"falseY\":-400,\"xyUnits\":99999999.999999985,\"falseZ\":-100000,\"zUnits\":10000,\"falseM\":-100000,\"mUnits\":10000}}";
    }
}

namespace S100Framework.YAML
{
    using ArcGIS.Core.Geometry;

    public static class Extension
    {
        public static void AddGeometry(this Dataset dataset, ArcGIS.Core.Geometry.Geometry geometry, string name) {
            switch (geometry) {
                case MapPoint point: {          // Point
                        dataset.AddPoint(new Point(point.X, point.Y) { Name = name });
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

                        Point first = default!;

                        var firstVertice = (vertices.First().X, vertices.First().Y);
                        var firstMatch = dataset.Points.FirstOrDefault(e => e.Coordinate.X == firstVertice.X && e.Coordinate.Y == firstVertice.Y);


                        if (firstMatch != null) {
                            first = new Point(firstMatch!.Coordinate!.X, firstMatch.Coordinate.Y) { Name = firstMatch.Name };
                        }
                        else {
                            first = new Point(firstVertice.X, firstVertice.Y) {
                                Name = $"{name}/0"
                            };
                            dataset.AddPoint(first);
                        }

                        var curve = new Curve(first, vertices) { Name = name };

                        dataset.AddCurve(curve);
                        break;
                    }
                case ArcGIS.Core.Geometry.Polygon polygon: {         // Surface
                        if (polygon.ExteriorRingCount == 0 || polygon.ExteriorRingCount > 1)
                            throw new ArgumentException("Unsupported exterior ring count");

                        var exteriorRing = polygon.GetExteriorRing(0);

                        var exteriorCoordinates = exteriorRing.Parts[0].Select(segment => new Coordinate(segment.StartPoint.X, segment.StartPoint.Y)).ToArray();

                        // Insert starting coordinate at the end of coordinate[] to ensure its a closed polygon
                        exteriorCoordinates = [.. exteriorCoordinates, exteriorCoordinates[0]];

                        var exteriorCurve = new Curve(exteriorCoordinates) {
                            Name = $"{name}/0"
                        };

                        dataset.AddCurve(exteriorCurve);

                        var surface = new Surface(exteriorCurve) {
                            Name = name,
                        };

                        // Add interior rings
                        int i = 1;
                        if (polygon.Parts.Count > 1) {
                            foreach (var interiorRing in polygon.Parts.Skip(1)) {
                                var interiorCoordinates = interiorRing.Select(segment => new Coordinate(segment.StartPoint.X, segment.StartPoint.Y)).ToArray();

                                // Insert starting coordinate at the end of coordinate[] to ensure its a closed polygon
                                interiorCoordinates = [.. interiorCoordinates, interiorCoordinates[0]];

                                var interiorCurve = new Curve(interiorCoordinates) {
                                    Name = $"{name}/{i}",
                                };
                                i++;
                                dataset.AddCurve(interiorCurve);

                                surface.InteriorRings = [.. surface.InteriorRings, interiorCurve];
                            }
                            ;
                        }

                        dataset.AddSurface(surface);

                        break;
                    }
                default:
                    throw new ArgumentException($"Unsupported geometry type: {geometry.GeometryType}");
            }
            ;
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
    }
}