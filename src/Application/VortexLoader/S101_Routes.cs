using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101.FeatureTypes;
using VortexLoader.Singletons;


namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S101_Routes(Geodatabase source, Geodatabase target, QueryFilter filter) {

            var metadataATableName = "MetaDataA";
            var productCoverageTableName = "ProductCoverage";

            using var metadataA = source.OpenDataset<FeatureClass>(source.GetName(metadataATableName));
            using var productCoverage = source.OpenDataset<FeatureClass>(source.GetName(productCoverageTableName));

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("surface"));

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            var whereClause = filter.WhereClause.Clone();
            var metadataAWhereFilter = new QueryFilter() {
                WhereClause = $"({whereClause}) AND (fcsubtype = 40)"
            };

            var productCoverageFilter = new QueryFilter() { 
                WhereClause = $"{whereClause}" 
            };

            var clipped = Geometries.GetDissolvedClipped(metadataA, metadataAWhereFilter, productCoverage, productCoverageFilter);

            //// Cut out V_DAT
            //metadataAWhereFilter = new QueryFilter() {
            //    WhereClause = $"({whereClause}) AND (fcsubtype = 55)"
            //};
            //var removedSubtype55 = Geometries.GetDissolvedClipped(result, metadataA, metadataAWhereFilter);

            // Cut out M_SDAT - // Will be added again
            metadataAWhereFilter = new QueryFilter() {
                WhereClause = $"({whereClause}) AND (fcsubtype = 45)"
            };

            var m_sdatCount = metadataA.GetCount(metadataAWhereFilter);

            if (m_sdatCount > 0) {
                clipped = Geometries.GetDissolvedClipped(clipped, metadataA, metadataAWhereFilter);
            }

            // Store clipped
            foreach (var item in clipped) {
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
                //TODO: ImporterNIS.SetDrawingIndex(buffer, plts_comp_scale);

                var featureN = featureClass.CreateRow(buffer);
                var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

            }

            // Add M_SDATs
            if (m_sdatCount > 0) {
                {
                    using var cursor = metadataA.Search(metadataAWhereFilter, false);

                    while (cursor.MoveNext()) {
                        var feature = (Feature)cursor.Current;

                        var current = new MetaDataA(feature);

                        var instance = new SoundingDatum {
                            verticalDatum = default,
                        };

                        // TODO: interoperabilityIdentifier

                        instance.verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT ?? 3);

                        AddInformation(instance.information, feature);
                        buffer["ps"] = ps101;
                        buffer["code"] = instance.GetType().Name;
                        buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                        SetShape(buffer, current.SHAPE);
                        ImporterNIS.SetDrawingIndex(buffer, current.PLTS_COMP_SCALE!.Value);

                        var featureN = featureClass.CreateRow(buffer);
                        var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                        if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                            relatedEquipment.CreateRelatedAreaEquipment(current, instance, featureN);
                        }

                        ConversionAnalytics.Instance.AddConverted(metadataATableName, current.GLOBALID, name);

                        Logger.Current.DataObject(current.OBJECTID!.Value, metadataATableName, current.LNAM!, System.Text.Json.JsonSerializer.Serialize(instance));
                    }
                }
            }

        }
    }
}