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

            //var all_M_QUAL = Geometries.AllGeometries(metadataA, M_Qual_WhereFilter);
            //var all_M_SDAT = Geometries.AllGeometries(metadataA, M_SDAT_WhereFilter);

            var all_M_QUAL_geometries = Geometries.AllGeometries(metadataA, M_Qual_WhereFilter, ["verdat"]);
            var all_M_SDAT_geometries = Geometries.AllGeometries(metadataA, M_SDAT_WhereFilter, ["verdat"]);
            var all_M_QUAL_dissolved = Geometries.GetDissolvedClipped(metadataA, M_Qual_WhereFilter, productCoverage, productCoverageFilter);

            var all_dissolved_M_QUALs_without_M_SDATs = Geometries.EraseTouchingParts(all_M_QUAL_dissolved, [.. all_M_SDAT_geometries.Select(e => e.Geometry)]);

            // Store all dissolved m_quals
            foreach (var item in all_dissolved_M_QUALs_without_M_SDATs) {

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

            // Add all M_SDATs
            foreach (var item in all_M_SDAT_geometries) {
                if (item.Geometry!.IsEmpty) {
                    continue;
                }

                var instance = new SoundingDatum {
                    verticalDatum = default,
                };

                instance.verticalDatum = EnumHelper.GetEnumValue<DomainModel.S101.verticalDatum>(item.FieldName_FieldValue["verdat"]);

                buffer["ps"] = ps101;
                buffer["code"] = instance.GetType().Name;
                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                SetShape(buffer, item.Geometry);
                ImporterNIS.SetUsageBand(buffer, _compilationScale);

                var featureN = featureClass.CreateRow(buffer);
                var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

            }
        }
    }
}