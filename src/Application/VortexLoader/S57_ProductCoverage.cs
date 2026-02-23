using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using S100FC;
using S100FC.S101.FeatureTypes;
using S100FC.S128.ComplexAttributes;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using System.Text.Json;
using VortexLoader.Singletons;

namespace S100Framework.Applications
{
    using S100FC.S128;

    internal static partial class ImporterNIS
    {
        private static void S57_ProductCoverage(Geodatabase source, Geodatabase target, QueryFilter filter, bool s128) {
            JsonSerializerOptions jsonSerializerOptions128 = new JsonSerializerOptions {
                WriteIndented = false,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                PropertyNameCaseInsensitive = true,
            }.AppendTypeInfoResolver();

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

                var displayScale = DisplayScale.GetDisplayScale(serie!)!;
                var dataCoverage_m_scl = new DataCoverage {
                    maximumDisplayScale = displayScale.MaximumDisplayScale,
                    optimumDisplayScale = displayScale.OptimumDisplayScale,
                    minimumDisplayScale = displayScale.MinimumDisplayScale
                };

                {
                    buffer["ps"] = ps101;
                    buffer["code"] = dataCoverage_m_scl.GetType().Name;

                    buffer["flatten"] = dataCoverage_m_scl.Flatten();
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
                    '5' => 5,   //S100FC.S128.specificUsage.NavigationalPurposeHarbour,
                    '4' => 4,   //S100FC.S128.specificUsage.NavigationalPurposeApproach,
                    '3' => 3,   //S100FC.S128.specificUsage.NavigationalPurposeCoastal,
                    '2' => 2,   //S100FC.S128.specificUsage.NavigationalPurposeGeneral,
                    '1' => 1,   //S100FC.S128.specificUsage.NavigationalPurposeOverview,
                    _ => throw new InvalidDataException(),
                };

                var instance = new S100FC.S128.FeatureTypes.ElectronicProduct {
                    catalogueElementClassification = [1], // catalogueElementClassification.Enc
                    editionNumber = edtn,
                    updateNumber = updn,
                    issueDate = DateOnly.FromDateTime(isdt),
                    notForNavigation = true,
                    typeOfProductFormat = 2,    //typeOfProductFormat.IsoIec8211,
                    datasetName = dsnm,
                    specificUsage = specificUsage,
                    productSpecification = new productSpecification {
                        editionDate = S100FC.S101.Summary.VersionDate,
                        name = S100FC.S101.Summary.ProductId,
                        version = S100FC.S101.Summary.Version.ToString(),
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
                    var displayScale = DisplayScale.GetDisplayScale(serie!)!;
                    var dataCoverage_m_scl = new DataCoverage {
                        maximumDisplayScale = displayScale.MaximumDisplayScale,
                        optimumDisplayScale = displayScale.OptimumDisplayScale,
                        minimumDisplayScale = displayScale.MinimumDisplayScale
                    };

                    var coverageShape = productCoverage.SHAPE!;

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
                                //buffer["__json__"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonTestSerializerOptions);
                                //SetShape(buffer, productCoverage.SHAPE);
                                //ImporterNIS.SetUsageBand(buffer, productCoverage!.PLTS_COMP_SCALE!.Value);
                                //var featureN = featureClass.CreateRow(buffer);
                                //var name = featureN.Crc32();
                                //// TODO: Create relations
                                //ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);
                            }

                            // DATACOVERAGE
                            var dataCoverage = new DataCoverage {
                                maximumDisplayScale = displayScale.MaximumDisplayScale,
                                optimumDisplayScale = displayScale.OptimumDisplayScale,
                                minimumDisplayScale = displayScale.MinimumDisplayScale
                            }; {
                                buffer["ps"] = ps101;
                                buffer["code"] = dataCoverage.GetType().Name;

                                buffer["flatten"] = dataCoverage.Flatten();
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

                                vdat.verticalDatum = GetVerticalDatum(current.VDAT ?? 3)?.value;

                                buffer["ps"] = ps101;
                                buffer["code"] = vdat.GetType().Name;

                                buffer["flatten"] = vdat.Flatten();
                                buffer["informationbindings"] = "[]";

                                SetShape(buffer, productCoverage.SHAPE);
                                ImporterNIS.SetUsageBand(buffer, productCoverage.PLTS_COMP_SCALE.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = featureN.UID();

                                // Registering vertical datum information for all areas
                                VerticalDatums.Instance.Add(productCoverage!.SHAPE!, vdat.verticalDatum);

                                SoundingDatums.Instance.Add(productCoverage!.SHAPE!, GetSoundingDatum(current.SDAT!.Value)!);

                                // TODO: Create relations
                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                VerticalDatums.Instance.Add(productCoverage.SHAPE!.Clone(), vdat.verticalDatum);

                            }
                            break;
                    }
                }

                if (s128) {
                    //Store S-128 polygons
                    buffer["ps"] = ps128;
                    buffer["code"] = instance.GetType().Name;

                    buffer["flatten"] = instance.Flatten();
                    buffer["informationbindings"] = "[]";

                    SetShape(buffer, (ArcGIS.Core.Geometry.Polygon)GeometryEngine.Instance.Union(polygons));
                    ImporterNIS.SetUsageBand(buffer, polygonsCompScale);
                    var featureN = featureClass.CreateRow(buffer);
                    var name = featureN.UID();
                    // TODO: Create relations
                    ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);
                }

                Logger.Current.DataObject(objectid, tableName, dsnm, System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions128));
            }
            Logger.Current.DataTotalCount(tableName, recordCount, ConversionAnalytics.Instance.GetConvertedCount(tableName));
        }
    }
}

