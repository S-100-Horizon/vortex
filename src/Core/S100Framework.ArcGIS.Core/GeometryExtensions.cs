using S100Framework.YAML;
using System.Globalization;

namespace ArcGIS.Core.Geometry
{
    public static class GeometryExtensions
    {
        public static Geometry BuildGeometry(string type, string[][] coordinates, int wkid = 4326) {
            var spatialReference = SpatialReferenceBuilder.CreateSpatialReference(wkid);

            switch (type) {
                case "pointproperty": {
                        var coords = coordinates[0];
                        var point = coords.Length switch {
                            2 => MapPointBuilderEx.CreateMapPoint(
                                    double.Parse(coords[1], CultureInfo.InvariantCulture),
                                    double.Parse(coords[0], CultureInfo.InvariantCulture),
                                    spatialReference),
                            3 => MapPointBuilderEx.CreateMapPoint(
                                    double.Parse(coords[1], CultureInfo.InvariantCulture),
                                    double.Parse(coords[0], CultureInfo.InvariantCulture),
                                    double.Parse(coords[2], CultureInfo.InvariantCulture),
                                    spatialReference),
                            _ => throw new InvalidOperationException(),
                        };
                        return point;
                    }
                case "curveproperty": {
                        var coords = coordinates[0];

                        return CreateLinearRing(coords, spatialReference);
                    }
                case "surfaceproperty": {
                        // Populate exterior ring
                        var exteriorCoords = coordinates[0];
                        var exterior = CreateLinearRing(exteriorCoords, spatialReference);

                        var polygonBuilder = new PolygonBuilderEx(exterior);

                        // Populate interior rings. Skip the first (exterior)
                        foreach (var interiorRing in coordinates.Skip(1)) {
                            var interior = CreateLinearRing(interiorRing, spatialReference);
                            polygonBuilder.AddPart(interior.Parts.First());
                        }

                        return polygonBuilder.ToGeometry();
                    }
                default:
                    throw new InvalidOperationException($"Invalid geometry type detected: {type}");
            }
        }

        public static void AddGeometry(this Dataset dataset, ArcGIS.Core.Geometry.Geometry geometry, string name) {
            switch (geometry) {
                case ArcGIS.Core.Geometry.MapPoint point: {                              // Point
                        var pointLocation = string.Format(
                             CultureInfo.InvariantCulture,
                             "{0:0.#######},{1:0.#######}", point.X, point.Y
                         );

                        var hashId = System.IO.Hashing.XxHash64.HashToUInt64(new NetTopologySuite.Geometries.Point(point.X, point.Y).ToBinary());

                        var datasetPoint = dataset?.Points?.FirstOrDefault(e => e.Name == $"P{hashId}");

                        // Create point if not exist
                        if (datasetPoint == default) {
                            var p = new Point(point.X, point.Y) {
                                Name = $"P{hashId}"
                            };

                            dataset?.AddPoint(p);
                        }

                        dataset?.UpdateFeatureReferences(name, $"P{hashId}"!);
                        break;
                    }
                case ArcGIS.Core.Geometry.Multipoint multiPoint: {   // Depths
                        var points = multiPoint.Points.Select(e => new Coordinate(e.X, e.Y)).ToArray();

                        var depths = multiPoint.Points.Select(e => Math.Round(e.Z, 7)).ToArray();

                        var hashId = System.IO.Hashing.XxHash64.HashToUInt64(new NetTopologySuite.Geometries.MultiPoint([.. multiPoint.Points.Select(e => new NetTopologySuite.Geometries.Point(e.X, e.Y, e.Z))]).ToBinary());

                        var pointSet = new PointSet(points, depths) { Name = $"P{hashId}" };
                        dataset.AddPointSet(pointSet);
                        break;
                    }
                case ArcGIS.Core.Geometry.Polyline polyline:        // Curves are handled in Topology
                case ArcGIS.Core.Geometry.Polygon polygon:          // Surfaces are handled in Topology
                    break;
                default:
                    throw new ArgumentException($"Unsupported geometry type: {geometry.GeometryType}");
            }
        }

        private static Polyline CreateLinearRing(string[] coords, SpatialReference spatialReference) {
            var points = new MapPoint[coords.Length / 2];
            for (int i = 0; i < coords.Length; i += 2) {
                var p = MapPointBuilderEx.CreateMapPoint(
                    double.Parse(coords[i + 1], CultureInfo.InvariantCulture),
                    double.Parse(coords[i + 0], CultureInfo.InvariantCulture),
                    spatialReference);
                points[i / 2] = p;
            }
            return PolylineBuilderEx.CreatePolyline(points, spatialReference);
        }
    }
}