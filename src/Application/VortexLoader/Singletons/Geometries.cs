using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using S100Framework.Applications.S57.esri;

namespace VortexLoader.Singletons
{
    internal class GeometryResult {
        public Geometry? Geometry { get; set; }
        public Dictionary<string, object>? FieldName_FieldValue { get; set; } = [];
    }
    //https://pro.arcgis.com/en/pro-app/3.3/sdk/api-reference/topic22112.html
    internal class Geometries
    {

        internal static List<Geometry> EraseTouchingParts(
            List<Geometry> inputPolygons,
            List<Geometry> clipPolygons) {
            var geometryResult = new List<Geometry>();

            foreach (var inputPolygon in inputPolygons) {
                Geometry modifiedPolygon = inputPolygon;

                var intersectingClipPolygons = clipPolygons
                    .Where(c => GeometryEngine.Instance.Intersects(c, inputPolygon))
                    .ToList();

                foreach (var clipPolygon in intersectingClipPolygons) {
                    if (clipPolygon.GeometryType != GeometryType.Polygon)
                        continue;

                    var clipPoly = (Polygon)clipPolygon;

                    //var boundaryPolyline = new Polyline(clipPoly.Parts[0].Points);

                    var intersection = GeometryEngine.Instance.Intersection(modifiedPolygon, clipPoly);

                    if (intersection == null || intersection.IsEmpty)
                        continue;

                    modifiedPolygon = GeometryEngine.Instance.Difference(modifiedPolygon, intersection);

                    if (modifiedPolygon == null || modifiedPolygon.IsEmpty)
                        break;
                }

                if (!(modifiedPolygon == null || modifiedPolygon.IsEmpty)){
                    geometryResult.Add(modifiedPolygon);
                }
            }

            return geometryResult;
        }

        internal static List<T> AllGeometriesWithFields<T>(FeatureClass featureClass, QueryFilter filter) where T : S57Object {
            using var cursor = featureClass.Search(filter, false);

            List<T> result = new List<T>();

            while (cursor.MoveNext()) {
                var feature = (Feature)cursor.Current;
                var val = Activator.CreateInstance(typeof(T), feature) as T;
                result.Add(val);
            }

            return result;

        }

        internal static List<Geometry> AllGeometries(FeatureClass featureClass, QueryFilter filter) {
            using var cursor = featureClass.Search(filter, false);
            List<Geometry> geometries = new List<Geometry>();
            while (cursor.MoveNext()) {
                var result = new GeometryResult();
                var feature = (Feature)cursor.Current;
                geometries.Add(feature.GetShape());
            }
            return geometries;
        }

        internal static List<Geometry> GetDissolvedClipped(IEnumerable<Geometry> sourcePolygons, FeatureClass clipPolygons, QueryFilter clipFilter) {
            var allSourcePolygons = GeometryEngine.Instance.Union(sourcePolygons);
            var allClipPolygons = GeometryEngine.Instance.Union(AllGeometries(clipPolygons, clipFilter));

            var geometries = AllGeometries(clipPolygons, clipFilter);
            var result = new List<Geometry>();
            int currentCount = 0;
            int totalCount = geometries.Count;

            foreach (var polygon in geometries) {
                var clippedGeom = GeometryEngine.Instance.Intersection(allSourcePolygons, polygon);
                currentCount++;
                result.Add(clippedGeom);

                // TODO: Multipart polygons not supported. MultipartToSinglePart collapses coincident vertices.
                //var result = GeometryEngine.Instance.MultipartToSinglePart(clippedGeom);
                //foreach (var singlePart in result) {
                //    yield return singlePart;
                //}
            }
            return result;
        }

        internal static List<Geometry> GetDissolvedClipped(FeatureClass sourcePolygons, QueryFilter sourceFilter, FeatureClass clipPolygons, QueryFilter clipFilter) {
            var allSourcePolygons = GeometryEngine.Instance.Union(AllGeometries(sourcePolygons, sourceFilter));
            var allClipPolygons = GeometryEngine.Instance.Union(AllGeometries(clipPolygons, clipFilter));

            var geometries = AllGeometries(clipPolygons, clipFilter);
            var result = new List<Geometry>();
            int currentCount = 0;
            int totalCount = geometries.Count;

            foreach (var polygon in geometries) {
                var clippedGeom = GeometryEngine.Instance.Intersection(allSourcePolygons, polygon).Clone();
                currentCount++;
                //yield return clippedGeom;
                result.Add(clippedGeom);
                //var result = GeometryEngine.Instance.MultipartToSinglePart(clippedGeom);
                //foreach (var singlePart in result) {
                //    yield return singlePart;
                //}
            }
            return result;
        }

        internal static IReadOnlyList<Geometry> GetDissolved(FeatureClass sourcePolygons, QueryFilter sourceFilter, FeatureClass clipPolygons, QueryFilter clipFilter) {
            var allSourcePolygons = GeometryEngine.Instance.Union(AllGeometries(sourcePolygons, sourceFilter));
            var allClipPolygons = GeometryEngine.Instance.Union(AllGeometries(clipPolygons, clipFilter));
            var clippedGeom = GeometryEngine.Instance.Intersection(allSourcePolygons, allClipPolygons);

            var result = GeometryEngine.Instance.MultipartToSinglePart(clippedGeom);

            return result;


            //IList<Geometry> polygonsInClip = new List<Geometry>();
            //using RowCursor cursor = sourcePolygons.Search(default,false);

            //while (cursor.MoveNext()) {
            //    using (Feature feature = cursor.Current as Feature) {
            //        var geom = feature.GetShape();
            //        var centroid = GeometryEngine.Instance.Centroid(geom);
            //        if (GeometryEngine.Instance.Within(centroid, clip)) {
            //            polygonsInClip.Add(feature.GetShape());
            //        }
            //    }
            //}






            //using var cursor = sourcePolygons.Search(default, true);

            //IList<Geometry> polygons  = new List<Geometry>();
            //while (cursor.MoveNext()) {
            //    var feature = (Feature)cursor.Current;
            //    polygons.Add(feature.GetShape());
            //}

            //var geometry = GeometryEngine.Instance.Union(polygons);

            //var result = GeometryEngine.Instance.MultipartToSinglePart(geometry);

        }


        //public List<long> GetFeaturesWithCentroidWithin(FeatureLayer featureLayer, Geometry polygon) {
        //    var matchingObjectIds = new List<long>();

        //List<Coordinate2D> coords2D = new List<Coordinate2D>()
        //      {
        //        new Coordinate2D(0, 0),
        //        new Coordinate2D(1, 4),
        //        new Coordinate2D(2, 7),
        //        new Coordinate2D(-10, 3)
        //      };

        //    Multipoint multipoint = MultipointBuilderEx.CreateMultipoint(coords2D, SpatialReferences.WGS84);

        //    IReadOnlyList<Geometry> result = GeometryEngine.Instance.MultipartToSinglePart(multipoint);
        //    // result.Count = 4, 


        //    // 'explode' a multipart polygon
        //    result = GeometryEngine.Instance.MultipartToSinglePart(geometry);


        //    // create a bag of geometries
        //    Polygon polygon = PolygonBuilderEx.CreatePolygon(coords2D, SpatialReferences.WGS84);
        //    //At 2.x - GeometryBag bag = GeometryBagBuilder.CreateGeometryBag(new List<Geometry>() { multipoint, polygon });
        //    var bag = GeometryBagBuilderEx.CreateGeometryBag(new List<Geometry>() { multipoint, polygon });
        //    // bag.PartCount = =2

        //    result = GeometryEngine.Instance.MultipartToSinglePart(bag);
        //}



    }
}
