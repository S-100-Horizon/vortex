using ArcGIS.Core.Data;
using VortexLoader.S57.esri;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_DepthsA(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "DepthsA";



            using var s = source.OpenDataset<FeatureClass>("DepthsA");
            using var featureClass = target.OpenDataset<FeatureClass>("surface");

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = s.Search(filter, true);

            var recordCount = 0;
            var convertedCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;
                var current = new DepthsA(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;

                var drval1 = current.DRVAL1 ?? default;
                var drval2 = current.DRVAL2 ?? default(decimal?);
                var sordat = current.SORDAT ?? default;

                var longname = current.LNAM ?? Strings.UNKNOWN;
                var restrn = current.RESTRN ?? default;
                var quasou = current.QUASOU ?? default;
                var tecsou = current.TECSOU ?? default;

                switch (subtype) {
                    case 1: {     // DEPARE

                            var deptharea = new S100Framework.DomainModel.S101.FeatureTypes.DepthArea {
                                depthRangeMinimumValue = drval1,
                                depthRangeMaximumValue = drval2.GetValueOrDefault(),
                            };

                            buffer["ps"] = "S-101";
                            buffer["code"] = "DepthArea";
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(deptharea);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(deptharea));
                            convertedCount++;

                        }
                        break;

                    case 5: {     // DRGARE
                            var dredgedarea = new S100Framework.DomainModel.S101.FeatureTypes.DredgedArea {
                                depthRangeMinimumValue = drval1,
                                depthRangeMaximumValue = drval2,
                                dredgedDate = null,
                                maximumPermittedDraught = null,
                                verticalUncertainty = null,
                            };

                            if (!string.IsNullOrEmpty(sordat)) {

                                System.Diagnostics.Debugger.Break();    //  Dredged Date
                            }

                            if (!string.IsNullOrEmpty(restrn)) {
                                foreach (var c in restrn.Split(',', StringSplitOptions.RemoveEmptyEntries)) {
                                    DomainModel.S101.restriction? e = c.ToLowerInvariant() switch {
                                        "1" => DomainModel.S101.restriction.AnchoringProhibited,
                                        "2" => DomainModel.S101.restriction.AnchoringRestricted,
                                        "3" => DomainModel.S101.restriction.FishingProhibited,
                                        "4" => DomainModel.S101.restriction.FishingRestricted,
                                        "5" => DomainModel.S101.restriction.TrawlingProhibited,
                                        "6" => DomainModel.S101.restriction.TrawlingRestricted,
                                        "7" => DomainModel.S101.restriction.EntryProhibited,
                                        "8" => DomainModel.S101.restriction.EntryRestricted,
                                        "9" => DomainModel.S101.restriction.DredgingProhibited,
                                        "10" => DomainModel.S101.restriction.DredgingRestricted,
                                        "11" => DomainModel.S101.restriction.DischargingProhibited,
                                        "12" => DomainModel.S101.restriction.DischargingRestricted,
                                        "13" => DomainModel.S101.restriction.NoWake,
                                        "14" => DomainModel.S101.restriction.AreaToBeAvoided,
                                        "15" => DomainModel.S101.restriction.ConstructionProhibited,
                                        "16" => DomainModel.S101.restriction.DischargingProhibited,
                                        "17" => DomainModel.S101.restriction.DischargingRestricted,
                                        "18" => DomainModel.S101.restriction.IndustrialOrMineralExplorationDevelopmentProhibited,
                                        "19" => DomainModel.S101.restriction.IndustrialOrMineralExplorationDevelopmentRestricted,
                                        "20" => DomainModel.S101.restriction.DrillingProhibited,
                                        _ => throw new IndexOutOfRangeException(),
                                    };
                                    if (e.HasValue) {
                                        dredgedarea.restriction.Add(e.Value);
                                    }
                                }
                            }

                            if (!string.IsNullOrEmpty(quasou)) {

                                dredgedarea.qualityOfVerticalMeasurement = quasou.ToLowerInvariant() switch {
                                    "1" => DomainModel.S101.qualityOfVerticalMeasurement.DepthKnown,
                                    "2" => DomainModel.S101.qualityOfVerticalMeasurement.DepthOrLeastDepthUnknown,
                                    _ => throw new IndexOutOfRangeException(),
                                };
                            }

                            if (!string.IsNullOrEmpty(tecsou)) {
                                foreach (var c in tecsou.Split(',', StringSplitOptions.RemoveEmptyEntries)) {
                                    DomainModel.S101.techniqueOfVerticalMeasurement? e = c.ToLowerInvariant() switch {
                                        "1" => DomainModel.S101.techniqueOfVerticalMeasurement.FoundByEchoSounder,
                                        "2" => DomainModel.S101.techniqueOfVerticalMeasurement.FoundBySideScanSonar,
                                        "3" => DomainModel.S101.techniqueOfVerticalMeasurement.FoundByMultiBeam,
                                        "4" => DomainModel.S101.techniqueOfVerticalMeasurement.FoundByDiver,
                                        "5" => DomainModel.S101.techniqueOfVerticalMeasurement.FoundByLeadLine,
                                        "8" => DomainModel.S101.techniqueOfVerticalMeasurement.SweptByVerticalAcousticSystem,
                                        "9" => DomainModel.S101.techniqueOfVerticalMeasurement.FoundByElectromagneticSensor,
                                        "10" => DomainModel.S101.techniqueOfVerticalMeasurement.Photogrammetry,
                                        _ => throw new IndexOutOfRangeException(),
                                    };
                                    if (e.HasValue) {
                                        dredgedarea.techniqueOfVerticalMeasurement.Add(e.Value);
                                    }
                                }
                            }

                            //TODO: 	verticalUncertainty

                            //TODO: 	maximumPermittedDraught

                            AddFeatureName(dredgedarea.featureName, feature);
                            AddInformation(dredgedarea.information, feature);

                            buffer["ps"] = "S-101";
                            buffer["code"] = "DredgedArea";
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(dredgedarea);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(dredgedarea));
                            convertedCount++;
                        }
                        break;

                    case 10: {    //SWPARE
                            var sweptarea = new S100Framework.DomainModel.S101.FeatureTypes.SweptArea {
                                depthRangeMinimumValue = drval1,
                                scaleMinimum = null,
                                sweptDate = null,
                            };
                            if (!string.IsNullOrEmpty(sordat)) {
                                System.Diagnostics.Debugger.Break();    //  Swept Date
                            }

                            AddInformation(sweptarea.information, feature);

                            buffer["ps"] = "S-101";
                            buffer["code"] = "SweptArea";
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(sweptarea);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(sweptarea));
                            convertedCount++;
                        }
                        break;

                    case 15: {    // UNSARE
                            var unsurveyedarea = new S100Framework.DomainModel.S101.FeatureTypes.UnsurveyedArea {
                            };
                            AddInformation(unsurveyedarea.information, feature);

                            buffer["ps"] = "S-101";
                            buffer["code"] = "UnsurveyedArea";
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(unsurveyedarea);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(unsurveyedarea));
                            convertedCount++;


                        }
                        break;
                }
            }
            Logger.Current.DataTotalCount(tableName, recordCount, convertedCount);
        }
    }
}
