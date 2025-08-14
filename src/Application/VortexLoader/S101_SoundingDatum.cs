using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101.FeatureTypes;
using VortexLoader.Singletons;


namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
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

            geometryResult.Add(modifiedPolygon);
        }

        return geometryResult;
    }


    private static void S101_SoundingDatum(Geodatabase source, Geodatabase target, QueryFilter filter) {

            var metadataATableName = "MetaDataA";
            var productCoverageTableName = "ProductCoverage";

            using var metadataA = source.OpenDataset<FeatureClass>(source.GetName(metadataATableName));
            using var productCoverage = source.OpenDataset<FeatureClass>(source.GetName(productCoverageTableName));

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("surface"));

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            var whereClause = filter.WhereClause.Clone();

            var M_Qual_WhereFilter = new QueryFilter() {
                WhereClause = $"({whereClause}) AND (fcsubtype = 40)"
            };

            var productCoverageFilter = new QueryFilter() {
                WhereClause = $"({whereClause}) AND CATCOV = 1"
            };
            var M_SDAT_WhereFilter = new QueryFilter() {
                WhereClause = $"({whereClause}) AND (fcsubtype = 45)"
            };

            // Take all M_QUAL and cut out M_SDAT

            var all_M_QUAL = Geometries.AllGeometries(metadataA, M_Qual_WhereFilter);
            var all_M_SDAT = Geometries.AllGeometries(metadataA, M_SDAT_WhereFilter);

            var polygons = EraseTouchingParts(all_M_QUAL, all_M_SDAT);

            foreach (var item in polygons) {
                if (item.IsEmpty) {
                    continue;
                }

                var instance = new SoundingDatum {
                    verticalDatum = default,
                };

                instance.verticalDatum = DomainModel.S101.verticalDatum.BalticSeaChartDatum2000;

                buffer["ps"] = ps101;
                buffer["code"] = instance.GetType().Name;
                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                SetShape(buffer, item);
                ImporterNIS.SetUsageBand(buffer, _compilationScale);

                var featureN = featureClass.CreateRow(buffer);
                var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

            }

            
            foreach (var item in all_M_SDAT) {
                if (item.IsEmpty) {
                    continue;
                }

                var instance = new SoundingDatum {
                    verticalDatum = default,
                };

                instance.verticalDatum = DomainModel.S101.verticalDatum.BalticSeaChartDatum2000;

                buffer["ps"] = ps101;
                buffer["code"] = instance.GetType().Name;
                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                SetShape(buffer, item);
                ImporterNIS.SetUsageBand(buffer, _compilationScale);

                var featureN = featureClass.CreateRow(buffer);
                var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

            }
        }
    }
}