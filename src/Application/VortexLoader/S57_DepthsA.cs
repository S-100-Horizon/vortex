using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_DepthsA(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "DepthsA";

            

            using var s = source.OpenDataset<FeatureClass>(source.GetName("DepthsA"));
            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("surface"));

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

                            var instance = new DepthArea {
                                depthRangeMinimumValue = drval1,
                                depthRangeMaximumValue = drval2.GetValueOrDefault(),
                            };


                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                        }
                        break;

                    case 5: {     // DRGARE
                            var instance = new DredgedArea {
                                depthRangeMinimumValue = drval1,
                                depthRangeMaximumValue = drval2,
                                dredgedDate = null,
                                maximumPermittedDraught = null,
                                verticalUncertainty = null,
                            };

                            if (!string.IsNullOrEmpty(sordat)) {
                                //System.Diagnostics.Debugger.Break();    //  Dredged Date



                            }

                            if (!string.IsNullOrEmpty(restrn)) {
                                foreach (var c in restrn.Split(',', StringSplitOptions.RemoveEmptyEntries)) {
                                    restriction? e = c.ToLowerInvariant() switch {
                                        "1" => restriction.AnchoringProhibited,
                                        "2" => restriction.AnchoringRestricted,
                                        "3" => restriction.FishingProhibited,
                                        "4" => restriction.FishingRestricted,
                                        "5" => restriction.TrawlingProhibited,
                                        "6" => restriction.TrawlingRestricted,
                                        "7" => restriction.EntryProhibited,
                                        "8" => restriction.EntryRestricted,
                                        "9" => restriction.DredgingProhibited,
                                        "10" => restriction.DredgingRestricted,
                                        "11" => restriction.DischargingProhibited,
                                        "12" => restriction.DischargingRestricted,
                                        "13" => restriction.NoWake,
                                        "14" => restriction.AreaToBeAvoided,
                                        "15" => restriction.ConstructionProhibited,
                                        "16" => restriction.DischargingProhibited,
                                        "17" => restriction.DischargingRestricted,
                                        "18" => restriction.IndustrialOrMineralExplorationDevelopmentProhibited,
                                        "19" => restriction.IndustrialOrMineralExplorationDevelopmentRestricted,
                                        "20" => restriction.DrillingProhibited,
                                        _ => throw new IndexOutOfRangeException(),
                                    };
                                    if (e.HasValue) {
                                        instance.restriction.Add(e.Value);
                                    }
                                }
                            }

                            // The S-57 attribute QUASOU for DEPARE will not be converted. It is considered that this attribute is
                            // not relevant for Depth Area in S - 101.
                            
                            //if (!string.IsNullOrEmpty(quasou)) {

                                //    instance.qualityOfVerticalMeasurement = quasou.ToLowerInvariant() switch {
                                //        "1" => qualityOfVerticalMeasurement.DepthKnown,
                                //        "2" => qualityOfVerticalMeasurement.DepthOrLeastDepthUnknown,
                                //        _ => throw new IndexOutOfRangeException(),
                                //    };
                                //}

                            if (!string.IsNullOrEmpty(tecsou)) {
                                foreach (var c in tecsou.Split(',', StringSplitOptions.RemoveEmptyEntries)) {
                                    techniqueOfVerticalMeasurement? e = c.ToLowerInvariant() switch {
                                        "1" => techniqueOfVerticalMeasurement.FoundByEchoSounder,
                                        "2" => techniqueOfVerticalMeasurement.FoundBySideScanSonar,
                                        "3" => techniqueOfVerticalMeasurement.FoundByMultiBeam,
                                        "4" => techniqueOfVerticalMeasurement.FoundByDiver,
                                        "5" => techniqueOfVerticalMeasurement.FoundByLeadLine,
                                        "8" => techniqueOfVerticalMeasurement.SweptByVerticalAcousticSystem,
                                        "9" => techniqueOfVerticalMeasurement.FoundByElectromagneticSensor,
                                        "10" => techniqueOfVerticalMeasurement.Photogrammetry,
                                        _ => throw new IndexOutOfRangeException(),
                                    };
                                    if (e.HasValue) {
                                        instance.techniqueOfVerticalMeasurement.Add(e.Value);
                                    }
                                }
                            }

                            //TODO: 	verticalUncertainty

                            //TODO: 	maximumPermittedDraught

                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;

                    case 10: {    //SWPARE
                            var instance = new SweptArea {
                                depthRangeMinimumValue = drval1,
                                scaleMinimum = null,
                                sweptDate = null,
                            };
                            if (!string.IsNullOrEmpty(sordat)) {
                                System.Diagnostics.Debugger.Break();    //  Swept Date
                            }

                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;

                    case 15: {    // UNSARE
                            var instance = new UnsurveyedArea {
                            };
                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;


                        }
                        break;
                    default:
                        // code block
                        System.Diagnostics.Debugger.Break();
                        break;

                }
            }
            Logger.Current.DataTotalCount(tableName, recordCount, convertedCount);
        }
    }
}
