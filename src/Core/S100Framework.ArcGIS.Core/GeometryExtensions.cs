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