using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using CommandLine;
using S100Framework.Catalogues;
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

            var syntax = source.GetSQLSyntax();


            var featureCatalogue = S100Framework.Catalogues.FeatureCatalogue.Catalogues.Single(e => e.ProductID.Equals("S-101"));

            foreach (var def in source.GetDefinitions<FeatureClassDefinition>()) {
                Console.WriteLine(def.GetName());

                using var fc = source.OpenDataset<FeatureClass>(def.GetName());

                var filter = new SpatialQueryFilter {
                    FilterGeometry = shape,
                    SpatialRelationship = SpatialRelationship.Contains,

                };

                var tableName = syntax.ParseTableName(fc.GetName());

                using var cursor = fc.Search(filter, true);
                while (cursor.MoveNext()) {
                    var current = cursor.Current;

                    var name = Convert.ToString(current["code"]);
                    var foid = $"{current.GetObjectID()}:1";

                    var prim = def.GetShapeType() switch {
                        GeometryType.Point => "Point",
                        GeometryType.Multipoint => "PointSet",
                        GeometryType.Polyline => "Curve",
                        GeometryType.Polygon => "Surface",
                        _ => throw new InvalidOperationException(),
                    };

                    var geometry = Convert.ToString(current["name"]);

                    var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace("S101", "FeatureTypes")}.{name}", true)!;

                    var instance = DBNull.Value.Equals(current["json"]) ? null : System.Text.Json.JsonSerializer.Deserialize(Convert.ToString(current["json"])!, type);

                    Console.WriteLine($"\t{current.GetObjectID()}");
                    Console.WriteLine($"\t{new { 
                        Name = name,
                        Foid = foid,
                        Prim = prim,
                        Geometry = geometry,
                    }}");
                }
            }

            return 0;
        }

        private const string jsonSurface = "{\"rings\":[[[12.500000000000057,54.701546510000071],[12.473288500000081,54.694891000000041],[12.442108800000085,54.687110700000062],[12.432361900000046,54.679033900000093],[12.416730400000063,54.666072400000076],[12.409326500000077,54.659929600000055],[12.402119500000083,54.653947900000048],[12.397816900000066,54.650375800000063],[12.389526800000056,54.643491100000062],[12.377257500000042,54.633296100000052],[12.375878300000068,54.63214970000007],[12.370052200000089,54.627306100000055],[12.364987100000064,54.623094000000094],[12.36265190000006,54.621151700000041],[12.35901460000008,54.618125900000052],[12.354938100000084,54.614734100000078],[12.34944610000008,54.61016340000009],[12.341457400000081,54.603512600000045],[12.33932800000008,54.601739400000042],[12.336247900000046,54.599174100000084],[12.333286100000066,54.596707000000094],[12.324458600000071,54.589351600000043],[12.317033200000083,54.583162000000073],[12.301542700000084,54.570241900000042],[12.273327800000061,54.546682800000042],[12.261228500000072,54.536569400000076],[12.241313200000036,54.519909700000085],[12.240820000000042,54.519496900000092],[12.239674600000058,54.518538300000046],[12.235963500000082,54.515431600000056],[12.22853450000008,54.50921100000005],[12.217540970000073,54.500000000000057],[12.000000000000057,54.500000000000057],[12.000000000000057,55.000000000000057],[12.500000000000057,55.000000000000057],[12.500000000000057,54.701546510000071]]],\"spatialReference\":{\"wkid\":4326,\"latestWkid\":4326,\"xyTolerance\":3.5355339e-08,\"zTolerance\":0.001,\"mTolerance\":0.001,\"falseX\":-400,\"falseY\":-400,\"xyUnits\":99999999.999999985,\"falseZ\":-100000,\"zUnits\":10000,\"falseM\":-100000,\"mUnits\":10000}}";
    }
}
