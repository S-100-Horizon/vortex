//using ArcGIS.Core.CIM;
using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ArcGIS.Core.SystemCore;
using CommandLine;
using ICSharpCode.SharpZipLib.Zip;
using NetTopologySuite.Utilities;
using S100FC.Applications;

//using S100Framework.DomainModel
using System.Text.RegularExpressions;
using Esri = ArcGIS.Core.Hosting.Host;
using IO = System.IO;




namespace S100Framework.Applications
{
    internal class VortexLoader
    {
        //GML: --v --cmd GML --dataset "c:\Users\Jens Søe\source\GitHub\Vortex\artifacts\S-131 Marine Harbour Infrastructure\samples\DKAAL\S100_ROOT\S-131\DATASET_FILES\DK00\131DK00_DKAAL.GML" --target "C:\Users\Jens Søe\OneDrive\ArcGIS\Projects\Vortex\S100ed4.gdb"

        //NIS: --v --cmd NIS --target "C:\Users\Jens Søe\OneDrive\ArcGIS\Projects\Vortex\S100ed4.gdb" --source "C:\Users\Jens Søe\OneDrive\ArcGIS\Projects\Vortex\s57.gdb"

        //  --query "PLTS_COMP_SCALE = 22000"

        //private static Serilog.Core.Logger? _logger;

        private static readonly Regex _substitute = new(@"^S(?<number>\d+)$", RegexOptions.Singleline | RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);

        public class Options
        {
            [Option('c', "cmd", Required = true, HelpText = "Command (GML|NIS|YAML)")]
            public string Command { get; set; } = string.Empty;

            [Option('d', "dataset", Required = false, HelpText = "")]
            public string? Dataset { get; set; }

            [Option('t', "target", Required = true, HelpText = "Target Geodatabase.")]
            public string? Target { get; set; }

            [Option('s', "source", Required = false, HelpText = "Source Geodatabase.")]
            public string? Source { get; set; }

            [Option('a', "append", Required = false, HelpText = "Append dataset.")]
            public bool Append { get; set; }

            [Option('q', "query", Required = false, HelpText = "Definition query.")]
            public string? Query { get; set; }

            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }

            [Option("s128", Required = false, HelpText = "Create ElectronicProducts.", Default = false)]
            public bool S128 { get; set; }

            [Option('n', "notespath", Required = false, HelpText = "Path to notes files references in TXTDSC.")]
            public string? NotesPath { get; set; }

            [Option('s', "skinofearthonly", Required = false, HelpText = "Exports only DEPARE, DRGARE, UNSARE and LNDARE.")]
            public string? SkinOfEarthOnly { get; set; }

            [Option('f', "scaminfiles", Required = false, HelpText = "Path to folder with scamin files. Supports only Grønland and Denmark scamin files.")]
            public string? ScaminFilesPath { get; set; }

            [Option("vdat", Required = false, Default = "3=44")]
            public string? VerticalDatumConverter { get; set; } //  --vdat 3=44            

        }

        static void Main(string[] args) {
            string command = string.Empty;

            var arguments = Parser.Default.ParseArguments<Options>(args)
                               .WithParsed<Options>(o => {
                                   command = o.Command.ToUpperInvariant();
                               });

            AppDomain.CurrentDomain.UnhandledException += (sender, e) => {
                Logger.Current.Fatal((Exception)e.ExceptionObject, "UnhandledException");
            };

            if (arguments.Errors.Any())
                return;

            Esri.Initialize();

            Func<Geodatabase> createGeodatabase = () => { throw new NotImplementedException(); };

            Action<bool> initialize = (append) => { };

            bool append = false;

            arguments.WithParsed<Options>(o => {
                var target = o.Target!;

                if (!string.IsNullOrEmpty(o.VerticalDatumConverter)) {
                    var dictionary = o.VerticalDatumConverter.Split(',').Select(e => e.Split('=')).ToDictionary(e => int.Parse(e[0]), e => int.Parse(e[1]));
                }

                if (IO.File.Exists(target) && ".sde".Equals(IO.Path.GetExtension(target), StringComparison.OrdinalIgnoreCase)) {
                    createGeodatabase = () => {
                        var geodatabase = new Geodatabase(new DatabaseConnectionFile(new Uri(IO.Path.GetFullPath(target))));

                        return geodatabase;
                    };
                }
                else if (IO.Directory.Exists(target) && ".gdb".Equals(IO.Path.GetExtension(target), StringComparison.OrdinalIgnoreCase)) {
                    initialize = (append) => {
                        if (!append) {
                            FastZip fastZip = new();

                            //IO.Directory.Delete(target, true);

                            fastZip.ExtractZip(IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "s100edX.gdb.zip"), IO.Path.GetFullPath(target), null);
                        }
                    };


                    createGeodatabase = () => {
                        var geodatabase = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(target))));

                        return geodatabase;
                    };
                }
                else if (Uri.IsWellFormedUriString(target, UriKind.Absolute)) {
                    var arcGisSignOn = ArcGISSignOn.Instance;

                    var signedId = arcGisSignOn.IsSignedOn(new Uri("https://nuvion.gst.dk/portal"));
                    Assert.IsTrue(signedId);

                    createGeodatabase = () => {
                        var serviceProps = new ServiceConnectionProperties(new Uri(target, UriKind.Absolute)) {
                            Version = "sde.DEFAULT"
                        };

                        var geodatabase = new Geodatabase(serviceProps);
                        return geodatabase;
                    };

                }
                else
                    throw new System.ArgumentOutOfRangeException(nameof(target));

                append = o.Append;
            });

            initialize(append);

            using Geodatabase target = createGeodatabase();


            var result = command switch {
                //"GML" => ImporterGML(target, arguments),
                "NIS" => ImporterNIS.Load(target, arguments),
                "YAML" => ImporterYAML.Load(target, arguments),
                _ => throw new System.ArgumentNullException(nameof(command)),
            };
        }
#if GML
        private static bool ImporterGML(Geodatabase geodatabase, ParserResult<Options> arguments) {
            S100Framework.GML.Dataset? dataset = null;

            bool append = false;

            arguments.WithParsed<Options>(o => {
                if (o.Append) {
                    append = o.Append;
                }

                if (!IO.File.Exists(o.Dataset))
                    throw new FileNotFoundException(o.Dataset);
                dataset = S100Framework.GML.Dataset.Load(o.Dataset);
            });

            if (dataset is null)
                throw new InvalidProgramException();

            using var tableInformationType = geodatabase.OpenDataset<Table>("informationtype");

            using var fcPoint = geodatabase.OpenDataset<FeatureClass>(geodatabase.GetName("point"));
            using var fcPointSet = geodatabase.OpenDataset<FeatureClass>(geodatabase.GetName("pointset"));
            using var fcCurve = geodatabase.OpenDataset<FeatureClass>(geodatabase.GetName("curve"));
            using var fcSurface = geodatabase.OpenDataset<FeatureClass>(geodatabase.GetName("surface"));

            using var bufferInformationType = tableInformationType.CreateRowBuffer();
            using var bufferPoint = fcPoint.CreateRowBuffer();
            using var bufferPointSet = fcPointSet.CreateRowBuffer();
            using var bufferCurve = fcCurve.CreateRowBuffer();
            using var bufferSurface = fcSurface.CreateRowBuffer();

            if (!append) {
                var filter = new QueryFilter {
                    WhereClause = $"ps = '{dataset.ProductSpecification}'",
                };
                tableInformationType.DeleteRows(filter);
                fcPoint.DeleteRows(filter);
                fcPointSet.DeleteRows(filter);
                fcCurve.DeleteRows(filter);
                fcSurface.DeleteRows(filter);
            }

            var members = dataset.Members();

            var referencedGeometry = new Dictionary<string, string[][]>();

            foreach (var m in members) {
                if (m is S100Framework.GML.Dataset.InformationType informationType) {
                    var value = informationType.Value;

                    Console.WriteLine($"InformationType: {value.GetType().Name}");

                    var json = JsonSerializer.Serialize(value, value!.GetType());

                    var rowbuffer = bufferInformationType;
                    rowbuffer["ps"] = dataset.ProductSpecification;
                    rowbuffer["code"] = value.GetType().Name;
                    row//buffer["__json__"] = json;

                    tableInformationType.CreateRow(bufferInformationType);
                }
                if (m is S100Framework.GML.Dataset.FeatureType featureType) {
                    var value = featureType.Value;

                    var geometryType = featureType.GeometryType;

                    if (geometryType == null)
                        continue;

                    var rowbuffer = geometryType switch {
                        "pointproperty" => bufferPoint,
                        "curveproperty" => bufferCurve,
                        "surfaceproperty" => bufferSurface,
                        _ => throw new NotImplementedException(),
                    };

                    var json = JsonSerializer.Serialize(value, value!.GetType());

                    rowbuffer["ps"] = dataset.ProductSpecification;
                    rowbuffer["code"] = value.GetType().Name;
                    row//buffer["__json__"] = json;

                    // Geometry
                    var coordinates = featureType.Coordinates();

                    if (coordinates == null || coordinates[0].Length == 0) {
                        if (string.IsNullOrEmpty(featureType.GeometryIdentifier))
                            continue;

                        var found = referencedGeometry.TryGetValue(featureType.GeometryIdentifier, out var coords);

                        if (!found)
                            continue;

                        coordinates = coords;
                    }
                    else if (!string.IsNullOrEmpty(featureType.GeometryIdentifier)) {
                        _ = referencedGeometry.TryAdd(featureType.GeometryIdentifier!, coordinates);
                    }

                    var geometry = GeometryExtensions.BuildGeometry(geometryType, coordinates!);

                    if (geometry is MapPoint point) {
                        if (point.HasZ == false)
                            bufferPoint["shape"] = MapPointBuilderEx.CreateMapPoint(point.X, point.Y, 0.00, geometry.SpatialReference);
                        else
                            bufferPoint["shape"] = point;

                        using var row = fcPoint.CreateRow(bufferPoint);
                    }
                    else if (geometry is Multipoint multipoint) {
                        bufferPointSet["shape"] = multipoint;
                        using var row = fcPointSet.CreateRow(bufferPointSet);
                    }
                    else if (geometry is Polyline curve) {
                        bufferCurve["shape"] = curve;
                        using var row = fcCurve.CreateRow(bufferCurve);
                    }
                    else if (geometry is Polygon polygon) {
                        bufferSurface["shape"] = polygon;
                        using var row = fcSurface.CreateRow(bufferSurface);
                    }
                }
            }

            return true;
        }
#endif
    }

    public static class YAMLExtensions
    {
        public static ArcGIS.Core.Geometry.Geometry? GetFeatureShape(this S100FC.YAML.Dataset dataset, S100FC.YAML.Feature feature) {
            switch (feature.Prim) {
                case S100FC.YAML.Primitive.Point: {
                        var depth = dataset?.Depths?.FirstOrDefault(e => e.Name == feature.Geometry);

                        // If point is depth
                        if (depth != default) {
                            var mapPoints = new List<MapPoint>();

                            for (int i = 0; i < depth.Points.Length; i++) {
                                var coord = depth.Points[i];
                                var z = depth.Depths.Length > 1 ? depth.Depths[i] : depth.Depths[0];

                                var point = MapPointBuilderEx.CreateMapPoint(coord.X, coord.Y, z);
                                mapPoints.Add(point);
                            }

                            return MultipointBuilderEx.CreateMultipoint(mapPoints);
                        }
                        // Point is simply a point
                        else {
                            var point = dataset!.Points!.FirstOrDefault(e => e.Name == feature.Geometry);

                            return MapPointBuilderEx.CreateMapPoint(point!.Coordinate!.X, point!.Coordinate.Y);
                        }
                    }
                case S100FC.YAML.Primitive.Curve: {
                        var points = new List<MapPoint>();
                        var compositeExist = dataset.FindCompositeCurve(feature.Geometry!);

                        // If feature references a composite curve
                        if (compositeExist != default) {
                            var curvesInComposite = feature.Geometry!.StartsWith('R') ? compositeExist.Curves.Reverse() : compositeExist.Curves;
                            foreach (var curveName in curvesInComposite) {
                                var curve = dataset.FindCurve(curveName);

                                if (curve.Coordinate == null || curve.Coordinate.Length == 0)
                                    continue;

                                var coords = curveName?.StartsWith('R') == true ? curve.Coordinate.Reverse() : curve.Coordinate;

                                foreach (var c in coords) {
                                    var point = MapPointBuilderEx.CreateMapPoint(c.X, c.Y);
                                    points.Add(point);
                                }
                            }
                        }
                        else {
                            var curve = dataset.Curves!.FirstOrDefault(e => e.Name == feature.Geometry) ?? throw new InvalidOperationException($"Curve with name {feature.Geometry} not found in dataset.");

                            foreach (var c in curve.Coordinate!) {
                                var point = MapPointBuilderEx.CreateMapPoint(c.X, c.Y);
                                points.Add(point);
                            }
                        }



                        return PolylineBuilderEx.CreatePolyline(points);
                    }
                case S100FC.YAML.Primitive.Surface: {
                        var surface = dataset.Surfaces!.FirstOrDefault(e => e.Name == feature.Geometry) ?? throw new InvalidOperationException($"Surface with name {feature.Geometry} not found in dataset.");

                        // Build Exterior ring
                        var compositeExist = dataset.FindCompositeCurve(surface.Exterior);
                        var exteriorPoints = new List<MapPoint>();

                        // If exterior ring is a composite curve, iterate these and build. If reverse curve, also reverse the coordinates.
                        if (compositeExist != default) {
                            var curvesInComposite = surface.Exterior.StartsWith('R') ? compositeExist.Curves.Reverse() : compositeExist.Curves;
                            foreach (var curveName in curvesInComposite) {
                                var curve = dataset.FindCurve(curveName);

                                if (curve.Coordinate == null || curve.Coordinate.Length == 0)
                                    continue;

                                var coords = curveName?.StartsWith('R') == true ? curve.Coordinate.Reverse() : curve.Coordinate;

                                foreach (var c in coords) {
                                    var point = MapPointBuilderEx.CreateMapPoint(c.X, c.Y);
                                    exteriorPoints.Add(point);
                                }
                            }
                        }
                        else {
                            var curve = dataset.FindCurve(surface.Exterior);

                            var coords = curve.Name?.StartsWith('R') == true
                                  ? curve.Coordinate!.Reverse()
                                  : curve.Coordinate;

                            foreach (var c in coords!) {
                                var point = MapPointBuilderEx.CreateMapPoint(c.X, c.Y);
                                exteriorPoints.Add(point);
                            }
                        }

                        var polyline = PolylineBuilderEx.CreatePolyline(exteriorPoints);

                        var polygonBuilder = new PolygonBuilderEx(polyline);


                        // Interior Rings
                        if (surface.InteriorRings is not null) {
                            var interiorRings = new List<Polyline>();

                            // Iterate all interior rings
                            foreach (var interiorCurveName in surface.InteriorRings) {
                                var interiorCompositeExist = dataset.FindCompositeCurve(interiorCurveName);
                                var interiorPoints = new List<MapPoint>();

                                // If interior ring is a composite curve, iterate these and build. If reverse curve, also reverse the coordinates.
                                if (interiorCompositeExist != default) {
                                    //TODO: var curvesInComposite = surface.Exterior.StartsWith('R') ? compositeExist!.Curves.Reverse() : compositeExist!.Curves;
                                    var curvesInComposite = interiorCompositeExist.Curves;
                                    foreach (var curveName in curvesInComposite) {
                                        var curve = dataset.FindCurve(curveName);

                                        if (curve.Coordinate == null || curve.Coordinate.Length == 0)
                                            continue;

                                        var coords = curveName?.StartsWith('R') == true ? curve.Coordinate.Reverse() : curve.Coordinate;

                                        foreach (var c in coords) {
                                            var point = MapPointBuilderEx.CreateMapPoint(c.X, c.Y);
                                            interiorPoints.Add(point);
                                        }
                                    }
                                }
                                else {
                                    var curve = dataset.FindCurve(interiorCurveName);

                                    if (curve.Coordinate == null || curve.Coordinate.Length == 0)
                                        continue;

                                    var coords = interiorCurveName?.StartsWith('R') == true ? curve.Coordinate.Reverse() : curve.Coordinate;

                                    foreach (var c in coords) {
                                        var point = MapPointBuilderEx.CreateMapPoint(c.X, c.Y);
                                        interiorPoints.Add(point);
                                    }
                                }

                                var interiorRing = PolylineBuilderEx.CreatePolyline(interiorPoints);
                                interiorRings.Add(interiorRing);
                            }


                            foreach (var ring in interiorRings) {
                                var segments = ring.Parts.First().ToList(); // get segments from the first part
                                polygonBuilder.AddPart(segments);
                            }
                        }

                        return polygonBuilder.ToGeometry();
                    }
                case S100FC.YAML.Primitive.NoGeometry: {
                        return null;
                    }
                default: {
                        throw new InvalidOperationException($"Unsupported Primtive type detected: {feature.Prim}");
                    }
            }
        }

        public static S100FC.YAML.Curve FindCurve(this S100FC.YAML.Dataset dataset, string name) {
            // Trim the 'R' to find the actual curve
            var trimmed = name.StartsWith('R') ? name[1..] : name;

            return dataset?.Curves?.FirstOrDefault(e => e.Name == trimmed)!;
        }
        public static S100FC.YAML.CompositeCurve FindCompositeCurve(this S100FC.YAML.Dataset dataset, string name) {
            // Trim the 'R' to find the actual curve
            var trimmed = name.StartsWith('R') ? name[1..] : name;

            return dataset?.CompositeCurves?.FirstOrDefault(e => e.Name == trimmed)!;
        }
    }
}