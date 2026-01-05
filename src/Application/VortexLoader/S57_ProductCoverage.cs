using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.AttributeModel.S101.FeatureTypes;
using VortexLoader.Singletons;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_ProductCoverage(Geodatabase source, Geodatabase target, QueryFilter filter, bool s128) {
            var tableName = "ProductCoverage";

            using var productDefinitionsTable = source.OpenDataset<Table>(source.GetName("ProductDefinitions"));
            using var productCoverageFeatureClass = source.OpenDataset<FeatureClass>(source.GetName("ProductCoverage"));
            using var metadataAFeatureClass = source.OpenDataset<FeatureClass>(source.GetName("MetaDataA"));

            var allM_CSCL = Geometries.Features<MetaDataA>(metadataAFeatureClass, new() { WhereClause = $"{filter.WhereClause} AND fcsubtype = 20" });

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("surface"));

            //featureClass.DeleteRows(new QueryFilter {
            //    WhereClause = $"ps = 'S-128' AND (code = 'ElectronicProduct' or code = 'instance')",
            //});

            int recordCount = 0;

            //replica.gdb has exporttype equal null!!
            //var whereclause = $"({filter.WhereClause.Replace("PLTS_COMP_SCALE", "CSCL")}) AND (exporttype is not null AND upper(exporttype) NOT IN ('CANCEL'))";

            var whereclause = $"({filter.WhereClause.Replace("PLTS_COMP_SCALE", "CSCL")})";

            using var buffer = featureClass.CreateRowBuffer();
            using var cursor = productDefinitionsTable.Search(new QueryFilter {
                WhereClause = whereclause,
            }, true);

            // Add all M_SCL as datacoverages
            foreach (var m_sclPolygon in allM_CSCL) {
                var serie = m_sclPolygon.DSNM!.ToString();

                var displayScale = DisplayScale.GetDisplayScale(serie!) ?? default;
                var dataCoverage_m_scl = new DataCoverage {
                    maximumDisplayScale = default,
                    minimumDisplayScale = default,
                    optimumDisplayScale = default,
                };

                if (displayScale != null) {
                    dataCoverage_m_scl.maximumDisplayScale = displayScale.MaximumDisplayScale;
                    dataCoverage_m_scl.minimumDisplayScale = displayScale.MinimumDisplayScale.GetValueOrDefault();
                    dataCoverage_m_scl.optimumDisplayScale = displayScale.OptimumDisplayScale;
                }
                else {
                    Logger.Current.DataError(m_sclPolygon.OBJECTID ?? -1, m_sclPolygon.TableName ?? "Unknown table name", m_sclPolygon.LNAM ?? "Unknown LNAM", "Optimumdisplayscale must be set");
                }

                {
                    buffer["ps"] = ps101;
                    buffer["code"] = dataCoverage_m_scl.GetType().Name;
                    buffer["edition"] = ImporterNIS.s101version;
                    buffer["json"] = System.Text.Json.JsonSerializer.Serialize(dataCoverage_m_scl);
                    SetShape(buffer, m_sclPolygon.SHAPE);
                    ImporterNIS.SetUsageBand(buffer, Convert.ToInt32(m_sclPolygon.PLTS_COMP_SCALE));

                    var featureN = featureClass.CreateRow(buffer);
                    var name = featureN.UID();

                    // TODO: Create relations
                }
            }

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
                    serie = dsnm!.Substring(0, 3);
                }

                dsnm = "101DK00" + dsnm!.Substring(2);

                var specificUsage = dsnm[7] switch {
                    '5' => S100Framework.AttributeModel.S128.specificUsage.NavigationalPurposeHarbour,
                    '4' => S100Framework.AttributeModel.S128.specificUsage.NavigationalPurposeApproach,
                    '3' => S100Framework.AttributeModel.S128.specificUsage.NavigationalPurposeCoastal,
                    '2' => S100Framework.AttributeModel.S128.specificUsage.NavigationalPurposeGeneral,
                    '1' => S100Framework.AttributeModel.S128.specificUsage.NavigationalPurposeOverview,
                    _ => throw new InvalidDataException(),
                };

                var instance = new S100Framework.AttributeModel.S128.FeatureTypes.ElectronicProduct {
                    catalogueElementClassification = new List<S100Framework.AttributeModel.S128.catalogueElementClassification> {
                                S100Framework.AttributeModel.S128.catalogueElementClassification.Enc,
                            },
                    editionNumber = edtn,
                    updateNumber = updn,
                    issueDate = DateOnly.FromDateTime(isdt),
                    notForNavigation = true,
                    typeOfProductFormat = S100Framework.AttributeModel.S128.typeOfProductFormat.IsoIec8211,
                    datasetName = dsnm,
                    specificUsage = specificUsage,
                    productSpecification = new S100Framework.AttributeModel.S128.ComplexAttributes.productSpecification {
                        editionDate = S100Framework.AttributeModel.S101.Summary.VersionDate,
                        name = S100Framework.AttributeModel.S101.Summary.ProductId,
                        version = S100Framework.AttributeModel.S101.Summary.Version.ToString(),
                    },
                };

                using var cursorCoverage = productCoverageFeatureClass.Search(new QueryFilter {
                    WhereClause = $"Product_GUID = '{globalid:B}'",
                }, true);

                var polygons = new List<ArcGIS.Core.Geometry.Polygon>();

                int polygonsCompScale = 0;

                while (cursorCoverage.MoveNext()) {
                    var productCoverage = new ProductCoverage((Feature)cursorCoverage.Current);
                    var catcov = productCoverage.CATCOV ?? default;
                    var plts_comp_scale = productCoverage.PLTS_COMP_SCALE ?? default;

                    //var displayScale = DisplayScale.GetNearestBelowKey(plts_comp_scale) ?? default;
                    var displayScale = DisplayScale.GetDisplayScale(serie) ?? default;

                    var coverageShape = productCoverage.SHAPE;

                    //(coverageShape as ArcGIS.Core.Geometry.Polygon).Area != (cutOutM_SCL[0] as ArcGIS.Core.Geometry.Polygon).Area
                    var cutOutM_SCL = Geometries.EraseTouchingParts([coverageShape], allM_CSCL.Select(e => e.SHAPE!).ToList());

                    //if ((coverageShape as ArcGIS.Core.Geometry.Polygon).Area != (cutOutM_SCL[0] as ArcGIS.Core.Geometry.Polygon).Area) {
                    //    ;
                    //}

                    if (cutOutM_SCL.Count == 0) {
                        throw new NotSupportedException("meta sea scale replaces coverage completely");
                    }
                    if (cutOutM_SCL.Count > 1) {
                        throw new NotSupportedException("Multiple coverages after M_SCL cut");
                    }

                    polygonsCompScale = productCoverage.PLTS_COMP_SCALE!.Value;
                    polygons.Add((ArcGIS.Core.Geometry.Polygon)productCoverage.SHAPE!);

                    switch (catcov) {
                        case 1: {
                                //buffer["ps"] = ps128;
                                //buffer["code"] = instance.GetType().Name;
                                //buffer["version"] = ImporterNIS.s101version;
                                //buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonTestSerializerOptions);
                                //SetShape(buffer, productCoverage.SHAPE);
                                //ImporterNIS.SetUsageBand(buffer, productCoverage!.PLTS_COMP_SCALE!.Value);
                                //var featureN = featureClass.CreateRow(buffer);
                                //var name = featureN.Crc32();
                                //// TODO: Create relations
                                //ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);
                            }

                            // DATACOVERAGE
                            var dataCoverage = new DataCoverage {
                                maximumDisplayScale = default,
                                minimumDisplayScale = default,
                                optimumDisplayScale = default,
                            };

                            if (displayScale != null) {
                                dataCoverage.maximumDisplayScale = displayScale.MaximumDisplayScale;
                                dataCoverage.minimumDisplayScale = displayScale.MinimumDisplayScale.GetValueOrDefault();
                                dataCoverage.optimumDisplayScale = displayScale.OptimumDisplayScale;
                            }
                            else {
                                Logger.Current.DataError(productCoverage.OBJECTID ?? -1, "DataCoverage", "Calculated", "Optimumdisplayscale must be set");
                            } {
                                buffer["ps"] = ps101;
                                buffer["code"] = dataCoverage.GetType().Name;
                                buffer["edition"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(dataCoverage);
                                buffer["informationbindings"] = "[]";

                                SetShape(buffer, cutOutM_SCL[0]); // productCoverage.SHAPE);
                                ImporterNIS.SetUsageBand(buffer, productCoverage.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = featureN.UID();

                                // TODO: Create relations
                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);
                            }

                            // VERTICAL DATUM OF DATA
                            {
                                var vdat = new VerticalDatumOfData {
                                    verticalDatum = default,
                                };

                                vdat.verticalDatum = GetVerticalDatum<VerticalDatumOfData>(current.VDAT ?? 3);

                                buffer["ps"] = ps101;
                                buffer["code"] = vdat.GetType().Name;
                                buffer["edition"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(vdat);
                                buffer["informationbindings"] = "[]";

                                SetShape(buffer, productCoverage.SHAPE);
                                ImporterNIS.SetUsageBand(buffer, productCoverage.PLTS_COMP_SCALE.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = featureN.UID();

                                // Registering vertical datum information for all areas
                                VerticalDatums.Instance.Add(productCoverage!.SHAPE!, vdat.verticalDatum!.Value);

                                SoundingDatums.Instance.Add(productCoverage!.SHAPE!, GetSoundingDatum<VerticalDatumOfData>(current.SDAT!.Value)!.Value);

                                // TODO: Create relations
                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                VerticalDatums.Instance.Add(productCoverage.SHAPE!.Clone(), vdat.verticalDatum!.Value);

                            }
                            break;
                    }
                }

                if (s128) {
                    //Store S-128 polygons
                    buffer["ps"] = ps128;
                    buffer["code"] = instance.GetType().Name;
                    buffer["edition"] = ImporterNIS.s101version;
                    buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                    buffer["informationbindings"] = "[]";

                    SetShape(buffer, (ArcGIS.Core.Geometry.Polygon)GeometryEngine.Instance.Union(polygons));
                    ImporterNIS.SetUsageBand(buffer, polygonsCompScale);
                    var featureN = featureClass.CreateRow(buffer);
                    var name = featureN.UID();
                    // TODO: Create relations
                    ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);
                }

                Logger.Current.DataObject(objectid, tableName, dsnm, System.Text.Json.JsonSerializer.Serialize(instance));
            }
            Logger.Current.DataTotalCount(tableName, recordCount, ConversionAnalytics.Instance.GetConvertedCount(tableName));
        }
    }
}

