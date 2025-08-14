using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_ProductCoverage(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "ProductCoverage";

            using var productDefinitionsTable = source.OpenDataset<Table>(source.GetName("ProductDefinitions"));
            using var productCoverageFeatureClass = source.OpenDataset<FeatureClass>(source.GetName("ProductCoverage"));
            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("surface"));

            featureClass.DeleteRows(new QueryFilter {
                WhereClause = $"ps = 'S-128' AND (code = 'ElectronicProduct' or code = 'instance')",
            });

            int recordCount = 0;

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();
            using var cursor = productDefinitionsTable.Search(null, true);

            while (cursor.MoveNext()) {
                recordCount += 1;
                var row = (Row)cursor.Current;
                var current = new ProductDefinitions(row); // (Row)cursor.Current;

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    continue;
                }


                var dsnm = current.DSNM ?? default;
                var edtn = current.EDTN ?? default;
                var updn = current.UPDN ?? default;
                var isdt = current.ISDT ?? default;
                var serie = current.SERIES ?? default;

                if (serie == default) {
                    serie = dsnm.Substring(0, 3);
                }



                var instance = new S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct {
                    catalogueElementClassification = new List<S100Framework.DomainModel.S128.catalogueElementClassification> {
                                S100Framework.DomainModel.S128.catalogueElementClassification.Enc,
                            },
                    editionNumber = edtn,
                    issueDate = DateOnly.FromDateTime(isdt),
                    notForNavigation = true,
                    typeOfProductFormat = S100Framework.DomainModel.S128.typeOfProductFormat.IsoIec8211,
                    datasetName = dsnm,
                };

                if (updn > 0)
                    instance.updateNumber = updn;

                using var cursorCoverage = productCoverageFeatureClass.Search(new QueryFilter {
                    WhereClause = $"Product_GUID = '{globalid:B}'",
                }, true);

                while (cursorCoverage.MoveNext()) {
                    var productCoverage = new ProductCoverage((Feature)cursorCoverage.Current);
                    var catcov = productCoverage.CATCOV ?? default;
                    var plts_comp_scale = productCoverage.PLTS_COMP_SCALE ?? default;

                    //var displayScale = DisplayScale.GetNearestBelowKey(plts_comp_scale) ?? default;
                    var displayScale = DisplayScale.GetDisplayScale(serie) ?? default;


                    switch (catcov) {
                        case 1: {
                                buffer["ps"] = ps128;
                                buffer["code"] = instance.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                SetShape(buffer, productCoverage.SHAPE);
                                ImporterNIS.SetUsageBand(buffer, productCoverage!.PLTS_COMP_SCALE!.Value);



                                var featureN = featureClass.CreateRow(buffer);
                                var name = Convert.ToString(featureN["name"]) ?? "Unknown name";
                                // TODO: Create relations
                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);
                            }

                            var dataCoverage = new DataCoverage {
                                maximumDisplayScale = default,
                                minimumDisplayScale = default,
                                optimumDisplayScale = default,
                            };

                            if (displayScale != null) {
                                dataCoverage.maximumDisplayScale = displayScale.MaximumDisplayScale;
                                dataCoverage.minimumDisplayScale = displayScale.MinimumDisplayScale.GetValueOrDefault();
                                dataCoverage.optimumDisplayScale = displayScale.OptimumDisplayScale;
                            } {
                                var vdat = new VerticalDatumOfData {
                                    verticalDatum = default,
                                };


                                //    TODO: Fix hardcoded vertical datum of dataset -> EnumHelper.GetEnumValue<DomainModel.S101.verticalDatum>(current.VDAT.Value);
                                if (current.VDAT.HasValue) {
                                    vdat.verticalDatum = DomainModel.S101.verticalDatum.BalticSeaChartDatum2000;
                                }

                                buffer["ps"] = ps101;
                                buffer["code"] = vdat.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(vdat);
                                SetShape(buffer, productCoverage.SHAPE);
                                ImporterNIS.SetUsageBand(buffer, productCoverage.PLTS_COMP_SCALE.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                                // TODO: Create relations
                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);
                            } {
                                buffer["ps"] = ps101;
                                buffer["code"] = dataCoverage.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(dataCoverage);
                                SetShape(buffer, productCoverage.SHAPE);
                                ImporterNIS.SetUsageBand(buffer, productCoverage.PLTS_COMP_SCALE.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                                // TODO: Create relations
                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);
                            }
                            break;
                    }
                }
                Logger.Current.DataObject(objectid, tableName, dsnm, System.Text.Json.JsonSerializer.Serialize(instance));
            }
            Logger.Current.DataTotalCount(tableName, recordCount, ConversionAnalytics.Instance.GetConvertedCount(tableName));
        }
    }
}

