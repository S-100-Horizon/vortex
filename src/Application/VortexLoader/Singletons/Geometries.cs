using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ArcGIS.Core.Internal.Geometry;
using S100Framework.Applications.S57.esri;

namespace VortexLoader.Singletons
{
    internal class GeometryResult
    {
        public Geometry? Geometry { get; set; }
        public Dictionary<string, object>? FieldName_FieldValue { get; set; } = [];
    }
    //https://pro.arcgis.com/en/pro-app/3.3/sdk/api-reference/topic22112.html
    internal class Geometries
    {

        internal static List<GeometryResult> GetTouchingOrIntersectingGeometries(
                List<GeometryResult> geometries,
                Geometry polygon) {
            if (polygon == null)
                throw new ArgumentNullException(nameof(polygon));

            return geometries
                .Where(gr =>
                    gr.Geometry != null &&
                    (GeometryEngine.Instance.Touches(gr.Geometry, polygon) ||
                     GeometryEngine.Instance.Intersects(gr.Geometry, polygon)))
                .ToList();
        }

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

                if (!(modifiedPolygon == null || modifiedPolygon.IsEmpty)) {
                    geometryResult.Add(modifiedPolygon);
                }
            }

            return geometryResult;
        }
        //internal static List<GeometryResult> EraseTouchingParts(
        //    List<GeometryResult> inputPolygons,
        //    List<GeometryResult> clipPolygons) {
        //    var geometryResult = new List<GeometryResult>();

        //    foreach (var inputPolygon in inputPolygons) {
        //        Geometry modifiedPolygon = inputPolygon.Geometry!;

        //        var intersectingClipPolygons = clipPolygons
        //            .Where(c => GeometryEngine.Instance.Intersects(c.Geometry, inputPolygon.Geometry))
        //            .ToList();

        //        ;

        //        foreach (var clipPolygon in intersectingClipPolygons) {
        //            if (clipPolygon.Geometry!.GeometryType != GeometryType.Polygon)
        //                continue;

        //            var clipPoly = (Polygon)clipPolygon.Geometry!;

        //            //var boundaryPolyline = new Polyline(clipPoly.Parts[0].Points);

        //            var intersection = GeometryEngine.Instance.Intersection(modifiedPolygon, clipPoly);

        //            if (intersection == null || intersection.IsEmpty)
        //                continue;

        //            modifiedPolygon = GeometryEngine.Instance.Difference(modifiedPolygon, intersection);

        //            //if (modifiedPolygon == null || modifiedPolygon.IsEmpty)
        //            //    break;

        //            if (!(modifiedPolygon == null || modifiedPolygon.IsEmpty)) {
        //                geometryResult.Add(new GeometryResult() {
        //                    Geometry = modifiedPolygon,
        //                    FieldName_FieldValue = 
        //                });
        //            }

        //        }

        //        //if (!(modifiedPolygon == null || modifiedPolygon.IsEmpty)) {
        //        //    geometryResult.Add(new GeometryResult() {
        //        //        Geometry = modifiedPolygon
        //        //    });
        //        //}
        //    }

        //    return geometryResult;
        //}

        internal static List<T> Features<T>(FeatureClass featureClass, QueryFilter filter) where T : S57Object {
            using var cursor = featureClass.Search(filter, false);
            List<T> result = [];
            while (cursor.MoveNext()) {
                var feature = (Feature)cursor.Current;
                var val = Activator.CreateInstance(typeof(T), feature) as T;
                result.Add(val!);
            }
            return result;
        }

        internal static List<Geometry> AllGeometries(FeatureClass featureClass, QueryFilter filter) {
            using var cursor = featureClass.Search(filter, false);
            List<Geometry> geometries = [];
            while (cursor.MoveNext()) {
                var feature = (Feature)cursor.Current;
                geometries.Add(feature.GetShape());
            }
            return geometries;
        }
        internal static List<GeometryResult> AllGeometries(FeatureClass featureClass, QueryFilter filter, List<string> fieldsToReturn) {
            using var cursor = featureClass.Search(filter, false);
            List<GeometryResult> geometries = [];

            List<int> indices = [];

            foreach (var fieldName in fieldsToReturn) {
                indices.Add(cursor.FindField(fieldName));
            }

            while (cursor.MoveNext()) {
                var feature = (Feature)cursor.Current;

                var result = new GeometryResult {
                    Geometry = feature.GetShape()
                };
                int idx = 0;
                foreach (var index in indices) {

                    result.FieldName_FieldValue!.Add(fieldsToReturn[idx], cursor.Current[index]);
                    idx++;
                }
                geometries.Add(result);
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

                var ringGroups = PolygonRingExtractor.ExtractRingsWithHoles(clippedGeom);

                foreach (var group in ringGroups) {
                    result.Add(group.Geometry);

                }
            }
            return result;
        }

        /// <summary>
        /// Deprecated 20250908
        /// </summary>
        //internal static List<Geometry> GetDissolvedClipped(IEnumerable<Geometry> sourcePolygons, FeatureClass clipPolygons, QueryFilter clipFilter) {
        //    var allSourcePolygons = GeometryEngine.Instance.Union(sourcePolygons);
        //    var allClipPolygons = GeometryEngine.Instance.Union(AllGeometries(clipPolygons, clipFilter));

        //    var geometries = AllGeometries(clipPolygons, clipFilter);
        //    var result = new List<Geometry>();
        //    int currentCount = 0;
        //    int totalCount = geometries.Count;

        //    foreach (var polygon in geometries) {
        //        var clippedGeom = GeometryEngine.Instance.Intersection(allSourcePolygons, polygon);
        //        currentCount++;
        //        result.Add(clippedGeom);
        //    }
        //    return result;
        //}



        public class RingGrouping
        {

            public Polygon? OuterRing { get; set; }
            public List<Polygon> InnerRings { get; set; } = [];

            /// <summary>
            /// Gets the combined Polygon geometry from the outer and inner rings.
            /// </summary>
            public Polygon Geometry {
                get {
                    var builder = new PolygonBuilder(this.OuterRing!.Parts[0].SpatialReference);

                    if (this.OuterRing.Parts.Count != 1) {
                        throw new NotSupportedException("Building single polygon from multiple outer parts is not supported.");
                    }


                    builder.AddPart(this.OuterRing.Parts[0]);

                    foreach (var hole in this.InnerRings) {
                        builder.AddPart(hole.Parts[0]);
                    }

                    return builder.ToGeometry();
                }
            }
        }

        public static class PolygonRingExtractor
        {
            public static List<RingGrouping> ExtractRingsWithHoles(Geometry geometry) {
                if (geometry == null)
                    throw new ArgumentNullException(nameof(geometry));

                if (geometry.GeometryType != GeometryType.Polygon)
                    throw new ArgumentException("Geometry must be a Polygon");

                var polygon = geometry as Polygon;

                var outerRings = new List<Polygon>();
                var innerRings = new List<Polygon>();

                foreach (var segmentCollection in polygon!.Parts) {
                    var isClockwise = IsRingClockwise(segmentCollection);
                    var ringPolygon = PolygonBuilder.CreatePolygon(segmentCollection);

                    if (isClockwise)
                        outerRings.Add(ringPolygon);
                    else
                        innerRings.Add(ringPolygon);
                }

                var result = new List<RingGrouping>();

                foreach (var outer in outerRings) {
                    var group = new RingGrouping { OuterRing = outer };

                    foreach (var inner in innerRings) {
                        if (GeometryEngine.Instance.Contains(outer, inner)) {
                            group.InnerRings.Add(inner);
                        }
                    }

                    result.Add(group);
                }

                return result;
            }

            private static bool IsRingClockwise(ReadOnlySegmentCollection ringSegments) {
                var points = ringSegments.Select(s => s.StartCoordinate).ToList();

                // Ensure ring is closed
                if (points.Count < 3)
                    return false;

                // Close the ring if not already
                if (!points[0].Equals(points[^1]))
                    points.Add(points[0]);

                double signedArea = 0.0;

                for (int i = 0; i < points.Count - 1; i++) {
                    var p1 = points[i];
                    var p2 = points[i + 1];
                    signedArea += (p1.X * p2.Y) - (p2.X * p1.Y);
                }

                // Clockwise if signed area is negative
                return signedArea < 0;
            }
            //internal static IReadOnlyList<Geometry> GetDissolved(FeatureClass sourcePolygons, QueryFilter sourceFilter, FeatureClass clipPolygons, QueryFilter clipFilter) {
            //    var allSourcePolygons = GeometryEngine.Instance.Union(AllGeometries(sourcePolygons, sourceFilter));
            //    var allClipPolygons = GeometryEngine.Instance.Union(AllGeometries(clipPolygons, clipFilter));
            //    var clippedGeom = GeometryEngine.Instance.Intersection(allSourcePolygons, allClipPolygons);

            //    var result = GeometryEngine.Instance.MultipartToSinglePart(clippedGeom);

            //    return result;


            //    //IList<Geometry> polygonsInClip = new List<Geometry>();
            //    //using RowCursor cursor = sourcePolygons.Search(default,false);

            //    //while (cursor.MoveNext()) {
            //    //    using (Feature feature = cursor.Current as Feature) {
            //    //        var geom = feature.GetShape();
            //    //        var centroid = GeometryEngine.Instance.Centroid(geom);
            //    //        if (GeometryEngine.Instance.Within(centroid, clip)) {
            //    //            polygonsInClip.Add(feature.GetShape());
            //    //        }
            //    //    }
            //    //}






            //    //using var cursor = sourcePolygons.Search(default, true);

            //    //IList<Geometry> polygons  = new List<Geometry>();
            //    //while (cursor.MoveNext()) {
            //    //    var feature = (Feature)cursor.Current;
            //    //    polygons.Add(feature.GetShape());
            //    //}

            //    //var geometry = GeometryEngine.Instance.Union(polygons);

            //    //var result = GeometryEngine.Instance.MultipartToSinglePart(geometry);

            //}


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
}