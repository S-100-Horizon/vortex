using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;

using CommandLine;
using S100Framework.Catalogues;
//using S100Framework.YAML;
using Serilog;
using System.Text.Json;
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

        private static Regex _substitute = new(@"^S(?<number>\d+)$", RegexOptions.Singleline | RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);

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

            [Option('n', "notespath", Required = false, HelpText = "Path to notes files references in TXTDSC.")]
            public string? NotesPath { get; set; }

            [Option('s', "skinofearthonly", Required = false, HelpText = "Exports only DEPARE, DRGARE, UNSARE and LNDARE.")]
            public string? SkinOfEarthOnly { get; set; }

            [Option('f', "scaminfiles", Required = false, HelpText = "Path to folder with scamin files. Supports only Grønland and Denmark scamin files.")]
            public string? ScaminFilesPath { get; set; }
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



            arguments.WithParsed<Options>(o => {
                var target = o.Target!;

                if (IO.File.Exists(target) && ".sde".Equals(IO.Path.GetExtension(target), StringComparison.OrdinalIgnoreCase)) {
                    createGeodatabase = () => {
                        var geodatabase = new Geodatabase(new DatabaseConnectionFile(new Uri(IO.Path.GetFullPath(target))));

                        return geodatabase;
                    };
                }
                else if (IO.Directory.Exists(target) && ".gdb".Equals(IO.Path.GetExtension(target), StringComparison.OrdinalIgnoreCase)) {
                    createGeodatabase = () => {
                        var geodatabase = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(target))));

                        return geodatabase;
                    };
                }
                else if (Uri.IsWellFormedUriString(target, UriKind.Absolute)) {
                    createGeodatabase = () => {
                        var serviceProps = new ServiceConnectionProperties(new Uri(target, UriKind.Absolute));
                        serviceProps.Version = "sde.DEFAULT";

                        var geodatabase = new Geodatabase(serviceProps);

                        var destinationVersion = geodatabase.GetVersionManager().GetVersionNames().FirstOrDefault(name => name.EndsWith("20250203", StringComparison.OrdinalIgnoreCase));

                        if (destinationVersion == null) {
                            geodatabase.GetVersionManager().CreateVersion(new VersionDescription() {
                                AccessType = VersionAccessType.Public,
                                Description = "S-57 Conversion",
                                Name = "20250203"
                            });
                        }

                        serviceProps.Version = destinationVersion;
                        geodatabase = new Geodatabase(serviceProps);

                        return geodatabase;
                    };

                }
                else
                    throw new System.ArgumentOutOfRangeException(nameof(target));
            });

            using Geodatabase target = createGeodatabase();


            var result = command switch {
                "GML" => ImporterGML(target, arguments),
                "NIS" => ImporterNIS.Load(target, arguments),
                "YAML" => ImporterYAML(target, arguments),
                _ => throw new System.ArgumentNullException(nameof(command)),
            };
        }
        private static bool ImporterYAML(Geodatabase geodatabase, ParserResult<Options> arguments) {
            S100Framework.YAML.Dataset? dataset = null;

            bool append = false;

            var productSpecification = "S-101"; // Default product specification

            var featureCatalogue = S100Framework.Catalogues.FeatureCatalogue.Catalogues.Single(e => e.ProductID.Equals(productSpecification));

            arguments.WithParsed<Options>(o => {
                if (o.Append) {
                    append = o.Append;
                }

                if (!IO.File.Exists(o.Dataset))
                    throw new FileNotFoundException(o.Dataset);

                var yaml = IO.File.ReadAllText(o.Dataset);
                dataset = S100Framework.YAML.Converter.Deserialize<S100Framework.YAML.Dataset>(yaml);
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
                    WhereClause = $"ps = '{productSpecification}'",
                };
                tableInformationType.DeleteRows(filter);
                fcPoint.DeleteRows(filter);
                fcPointSet.DeleteRows(filter);
                fcCurve.DeleteRows(filter);
                fcSurface.DeleteRows(filter);
            }

            foreach (var feature in dataset.Features!) {
                // 1) Cast feature.Attributes to S101 Model
                var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace("S101", "FeatureTypes")}.{feature.Attributes.Code}", true) ?? default;

                if (type == default) {
                    Log.Error("Could not get type: {type} for feature: {name}", feature.Attributes.Code, feature.Name);
                    continue;
                }

                // 2) Serialize to JSON
                var json = System.Text.Json.JsonSerializer.Serialize(feature.Attributes, type);


                // 3) Find corresponding geometry and cast it to ArcGIS.Core.Geometry
                var geometry = dataset.GetFeatureShape(feature);


                // 4) Append row to table
                var rowbuffer = geometry switch {
                    MapPoint => bufferPoint,
                    Multipoint => bufferPointSet,
                    Polyline => bufferCurve,
                    Polygon => bufferSurface,
                    _ => throw new NotImplementedException(),
                };


                rowbuffer["ps"] = productSpecification;
                rowbuffer["code"] = feature.Name;
                rowbuffer["json"] = json;

                if (geometry is MapPoint) {
                    var point = (MapPoint)geometry;

                    if (point.HasZ == false)
                        bufferPoint["shape"] = MapPointBuilderEx.CreateMapPoint(((MapPoint)geometry).X, ((MapPoint)geometry).Y, 0.00, geometry.SpatialReference);
                    else
                        bufferPoint["shape"] = geometry;

                    using var row = fcPoint.CreateRow(bufferPoint);
                }
                if (geometry is Multipoint) {
                    bufferPointSet["shape"] = geometry;
                    using var row = fcPointSet.CreateRow(bufferPointSet);
                }
                if (geometry is Polyline) {
                    bufferCurve["shape"] = geometry;
                    using var row = fcCurve.CreateRow(bufferCurve);
                }
                if (geometry is Polygon) {
                    bufferSurface["shape"] = geometry;
                    using var row = fcSurface.CreateRow(bufferSurface);
                }
            }

            foreach (var informationType in dataset.InformationTypes!) {
                // 1) Cast feature.Attributes to S101 Model
                var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace("S101", "InformationTypes")}.{informationType!.Attributes!.Code}", true) ?? default;
                if (type == default) {
                    Log.Error("Could not get type: {type} for informationType: {name}", informationType.Attributes.Code, informationType.Name);
                    continue;
                }

                // 2) Serialize to JSON
                var json = System.Text.Json.JsonSerializer.Serialize(informationType.Attributes, type);

                // Write to table
                var rowbuffer = bufferInformationType;
                rowbuffer["ps"] = productSpecification;
                rowbuffer["code"] = informationType.Name;
                rowbuffer["json"] = json;
                tableInformationType.CreateRow(bufferInformationType);
            }

            return true;
        }
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

            var members = dataset!.Members().ToArray();
            foreach (var m in members) {
                if (m is S100Framework.GML.Dataset.InformationType informationType) {
                    var value = informationType.Value;

                    Console.WriteLine($"InformationType: {value.GetType().Name}");

                    var json = JsonSerializer.Serialize(value, value!.GetType());

                    var rowbuffer = bufferInformationType;
                    rowbuffer["ps"] = dataset.ProductSpecification;
                    rowbuffer["code"] = value.GetType().Name;
                    rowbuffer["json"] = json;

                    tableInformationType.CreateRow(bufferInformationType);
                }
                if (m is S100Framework.GML.Dataset.FeatureType featureType) {
                    var value = featureType.Value;

                    Console.WriteLine($"FeatureType: {value.GetType().Name}");

                    var geometry = ((S100Framework.GML.Dataset.FeatureType)m).Shape();
                    if (geometry is null)
                        continue;

                    var rowbuffer = geometry switch {
                        MapPoint => bufferPoint,
                        Multipoint => bufferPointSet,
                        Polyline => bufferCurve,
                        Polygon => bufferSurface,
                        _ => throw new NotImplementedException(),
                    };

                    var json = JsonSerializer.Serialize(value, value!.GetType());

                    rowbuffer["ps"] = dataset.ProductSpecification;
                    rowbuffer["code"] = value.GetType().Name;
                    rowbuffer["json"] = json;

                    if (geometry is MapPoint) {
                        var point = (MapPoint)geometry;

                        if (point.HasZ == false)
                            bufferPoint["shape"] = MapPointBuilderEx.CreateMapPoint(((MapPoint)geometry).X, ((MapPoint)geometry).Y, 0.00, geometry.SpatialReference);
                        else
                            bufferPoint["shape"] = geometry;

                        using var row = fcPoint.CreateRow(bufferPoint);
                    }
                    if (geometry is Multipoint) {
                        bufferPointSet["shape"] = geometry;
                        using var row = fcPointSet.CreateRow(bufferPointSet);
                    }
                    if (geometry is Polyline) {
                        bufferCurve["shape"] = geometry;
                        using var row = fcCurve.CreateRow(bufferCurve);
                    }
                    if (geometry is Polygon) {
                        bufferSurface["shape"] = geometry;
                        using var row = fcSurface.CreateRow(bufferSurface);
                    }
                }
            }

            return true;
        }
    }

    public static class YAMLExtensions
    {
        public static ArcGIS.Core.Geometry.Geometry GetFeatureShape(this S100Framework.YAML.Dataset dataset, S100Framework.YAML.Feature feature) {
            S100Framework.YAML.Geometry geometry = feature.Prim switch {
                S100Framework.YAML.Primitive.Point => dataset.Points!.FirstOrDefault(e => e.Name == feature.Geometry)!,
                S100Framework.YAML.Primitive.Curve => dataset.Curves!.FirstOrDefault(e => e.Name == feature.Geometry)!,
                S100Framework.YAML.Primitive.Surface => dataset.Surfaces!.FirstOrDefault(e => e.Name == feature.Geometry)!,
                _ => throw new NotImplementedException($"Primitive {feature.Prim} is not supported."),
            };

            // TODO: Implement conversion from S100Framework.YAML.Geometry to ArcGIS.Core.Geometry.Geometry
            // Get Underlying coordinates. E.g. Surface => composite curves => curve[] => Coordinates
            // Switch case on geometry and build ArcGIS.Core.Geometry object
            // Figure out how to detect PointSets (Depths)...


            throw new NotImplementedException($"GetFeatureShape not yet implemented.");
            return default;
        }
    }
}
