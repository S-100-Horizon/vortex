using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ICSharpCode.SharpZipLib.Zip;
using S100Framework.GML;
using System.Text.Json;

namespace TestNisImporter
{
    public class TestS124
    {
        [Fact]
        internal async Task Test_GetS124Data() {
            // Fetch all NW from Niord as GML
            var gml = await S124Extensions.GetGMLFromNiord();

            // Initialize ArcGIS and 
            ArcGIS.Core.Hosting.Host.Initialize();


            // Unzip database
            var fastZip = new FastZip();
            var output = new System.IO.DirectoryInfo(@"s124ed8.gdb");

            if (output.Exists)
                output.Delete(true);

            fastZip.ExtractZip("s124ed8.gdb.zip", output.FullName, null);

            // Establish database connection
            using var geodatabase = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(System.IO.Path.GetFullPath(output.FullName))));
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

            foreach (var g in gml) {
                try {
                    var dataset = S100Framework.GML.Dataset.Parse(g);

                    var referencedGeometry = new Dictionary<string, string[][]>();

                    var members = dataset.Members();

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

                            var geometryType = featureType.GeometryType;

                            if (geometryType == null)
                                continue;   // Keep on. Known bug

                            var rowbuffer = geometryType switch {
                                "pointproperty" => bufferPoint,
                                "curveproperty" => bufferCurve,
                                "surfaceproperty" => bufferSurface,
                                _ => throw new NotImplementedException(),
                            };

                            var json = JsonSerializer.Serialize(value, value!.GetType());

                            rowbuffer["ps"] = dataset.ProductSpecification;
                            rowbuffer["code"] = value.GetType().Name;
                            rowbuffer["json"] = json;

                            // Geometry
                            var coordinates = featureType.Coordinates();

                            if (coordinates == null || coordinates.Length == 0 || coordinates[0].Length == 0) {
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
                }
                catch (Exception) {
                    continue; // keep on
                }
            }
        }
    }
    internal static class S124Extensions
    {
        private static readonly HttpClient client = new() {
            BaseAddress = new Uri("http://niord.t-dma.dk/rest/"),
        };

        internal record Entry(string id);
        private static async Task<Guid[]> GetGmlUuids() {
            var res = await client.GetAsync("public/v1/messages?mainType=NW");

            res.EnsureSuccessStatusCode();

            var content = await res.Content.ReadAsStringAsync();

            var entries = JsonSerializer.Deserialize<Entry[]>(content) ?? [];

            return [.. entries.Select(e => Guid.Parse(e.id))];

        }

        public static async Task<IEnumerable<string>> GetGMLFromNiord() {
            var uuids = await GetGmlUuids();
            var gml = new List<string>();

            foreach (var e in uuids) {
                try {
                    await Task.Delay(150); // Delay to avoid timeout
                    var res = await client.GetAsync($"S-124/messages/{e}");

                    res.EnsureSuccessStatusCode();

                    var content = await res.Content.ReadAsStringAsync();

                    gml.Add(content);
                }
                catch (HttpRequestException) {
                    // Rate limit hit, waiting...
                    await Task.Delay(5000);
                    var res = await client.GetAsync($"S-124/messages/{e}");

                    res.EnsureSuccessStatusCode();

                    var content = await res.Content.ReadAsStringAsync();

                    gml.Add(content);
                }
                catch (Exception) {
                    continue;   // keep on
                }

            }

            return gml;
        }

        internal static string? GetName(this Geodatabase geodatabase, string name) {
            var _layerDefinitions = geodatabase.GetDefinitions<FeatureClassDefinition>();
            var _tableDefinitions = geodatabase.GetDefinitions<TableDefinition>();

            var tableName = _layerDefinitions?.FirstOrDefault<FeatureClassDefinition>(e => e.GetAliasName().ToLower().Equals(name.ToLower(), StringComparison.InvariantCultureIgnoreCase))?.GetName();
            tableName ??= _tableDefinitions?.FirstOrDefault<TableDefinition>(e => e.GetAliasName().ToLower().Equals(name.ToLower(), StringComparison.InvariantCultureIgnoreCase))?.GetName();
            return tableName;
        }
    }
}