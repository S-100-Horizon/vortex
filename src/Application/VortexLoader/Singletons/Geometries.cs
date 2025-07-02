using ArcGIS.Core.Data;
using ArcGIS.Core.Data.UtilityNetwork.Trace;
using ArcGIS.Core.Geometry;
using ArcGIS.Desktop.Mapping;
using S100Framework.Applications.S57.esri;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexLoader.Singletons
{
    //https://pro.arcgis.com/en/pro-app/3.3/sdk/api-reference/topic22112.html
    internal class Geometries
    {

        private static IEnumerable<Geometry> AllGeometries(FeatureClass featureClass, QueryFilter filter) {
            using var cursor = featureClass.Search(filter, false);

            IList<Geometry> geometries = new List<Geometry>();
            
            while (cursor.MoveNext()) {
                var feature = (Feature)cursor.Current;
                yield return (feature.GetShape());
            }

        }

        internal static IEnumerable<Geometry> GetDissolvedClipped(IEnumerable<Geometry> sourcePolygons, FeatureClass clipPolygons, QueryFilter clipFilter) {
            var allSourcePolygons = GeometryEngine.Instance.Union(sourcePolygons);
            var allClipPolygons = GeometryEngine.Instance.Union(AllGeometries(clipPolygons, clipFilter));

            foreach (var polygon in AllGeometries(clipPolygons, clipFilter)) {
                var clippedGeom = GeometryEngine.Instance.Intersection(allSourcePolygons, polygon);
                var result = GeometryEngine.Instance.MultipartToSinglePart(clippedGeom);
                foreach (var singlePart in result) {
                    yield return singlePart;
                }
            }
        }

        internal static IEnumerable<Geometry> GetDissolvedClipped(FeatureClass sourcePolygons, QueryFilter sourceFilter, FeatureClass clipPolygons, QueryFilter clipFilter) {
            var allSourcePolygons = GeometryEngine.Instance.Union(AllGeometries(sourcePolygons, sourceFilter));
            var allClipPolygons = GeometryEngine.Instance.Union(AllGeometries(clipPolygons, clipFilter));

            foreach (var polygon in AllGeometries(clipPolygons, clipFilter)) {
                var clippedGeom = GeometryEngine.Instance.Intersection(allSourcePolygons, polygon);
                var result = GeometryEngine.Instance.MultipartToSinglePart(clippedGeom);
                foreach (var singlePart in result) {
                    yield return singlePart;
                }
                
            }
        }

        internal static IReadOnlyList<Geometry> GetDissolved(FeatureClass sourcePolygons, QueryFilter sourceFilter, FeatureClass clipPolygons, QueryFilter clipFilter) {
            var allSourcePolygons = GeometryEngine.Instance.Union(AllGeometries(sourcePolygons, sourceFilter));
            var allClipPolygons = GeometryEngine.Instance.Union(AllGeometries(clipPolygons,clipFilter));
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
