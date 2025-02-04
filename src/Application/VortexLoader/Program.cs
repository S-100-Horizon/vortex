using ArcGIS.Core.CIM;
using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using CommandLine;
using S100Framework.ArcGIS.Core;
using System;
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
            [Option('c', "cmd", Required = true, HelpText = "Command (GML|NIS)")]
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

                if (IO.File.Exists(target) && ".sde".Equals(IO.Path.GetExtension(target), StringComparison.InvariantCultureIgnoreCase)) {
                    createGeodatabase = () => { return new Geodatabase(new DatabaseConnectionFile(new Uri(IO.Path.GetFullPath(target)))); };
                }
                else if (IO.Directory.Exists(target) && ".gdb".Equals(IO.Path.GetExtension(target), StringComparison.InvariantCultureIgnoreCase)) {
                    createGeodatabase = () => { return new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(target)))); };
                }
                else if (Uri.IsWellFormedUriString(target, UriKind.Absolute)) {

                    createGeodatabase = () => {
                        var serviceProps = new ServiceConnectionProperties(new Uri(target, UriKind.Absolute));
                        serviceProps.Version = "sde.DEFAULT";

                        var geodatabase = new Geodatabase(serviceProps);
                        geodatabase.GetVersionManager().CreateVersion(new VersionDescription() {
                            AccessType = VersionAccessType.Public,
                            Description = "S-57 Conversion",
                            Name = "20250203"
                        });

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
                _ => throw new System.ArgumentNullException(nameof(command)),
            };
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

            using var fcPoint = geodatabase.OpenDataset<FeatureClass>("point");
            using var fcPointSet = geodatabase.OpenDataset<FeatureClass>("pointset");
            using var fcCurve = geodatabase.OpenDataset<FeatureClass>("curve");
            using var fcSurface = geodatabase.OpenDataset<FeatureClass>("surface");

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
                if (m is S100Framework.GML.Dataset.InformationType) {
                    var value = ((S100Framework.GML.Dataset.InformationType)m).Value;

                    Console.WriteLine($"InformationType: {value.GetType().Name}");

                    var json = JsonSerializer.Serialize(value, value!.GetType());

                    var rowbuffer = bufferInformationType;
                    rowbuffer["ps"] = dataset.ProductSpecification;
                    rowbuffer["code"] = value.GetType().Name;
                    rowbuffer["json"] = json;

                    tableInformationType.CreateRow(bufferInformationType);
                }
                if (m is S100Framework.GML.Dataset.FeatureType) {
                    var value = ((S100Framework.GML.Dataset.FeatureType)m).Value;

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

                        if (point.HasZ) {
                            rowbuffer["z"] = point.Z;
                            point = MapPointBuilderEx.CreateMapPoint(point.X, point.Y, point.SpatialReference);
                        }
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
}
