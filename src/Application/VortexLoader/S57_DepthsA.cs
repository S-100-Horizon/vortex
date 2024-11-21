using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using CommandLine;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using static S100Framework.Applications.VortexLoader;
using IO = System.IO;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_DepthsA(Geodatabase source, Geodatabase target, QueryFilter filter) {
            Console.WriteLine("DepthsA");

            using var s = source.OpenDataset<FeatureClass>("DepthsA");
            using var featureClass = target.OpenDataset<FeatureClass>("surface");

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = s.Search(filter, true);
            while (cursor.MoveNext()) {
                var current = (Feature)cursor.Current;
                var subtype = Convert.ToInt32(current["FCSubtype"]);

                switch (subtype) {
                    case 1: {     // DEPARE
                            var drval1 = Convert.ToDecimal(current["DRVAL1"]);
                            var drval2 = Convert.ToDecimal(current["DRVAL2"]);

                            var deptharea = new S100Framework.DomainModel.S101.FeatureTypes.DepthArea {
                                depthRangeMinimumValue = drval1,
                                depthRangeMaximumValue = drval2,
                            };

                            buffer["ps"] = "S-101";
                            buffer["code"] = "DepthArea";
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(deptharea);
                            buffer["shape"] = current.GetShape();
                            insert.Insert(buffer);
                        }
                        break;

                    case 5: {     // DRGARE
                            var drval1 = Convert.ToDecimal(current["DRVAL1"]);
                            var drval2 = DBNull.Value == current["DRVAL2"] ? default(decimal?) : Convert.ToDecimal(current["DRVAL2"]);

                            var dredgedarea = new S100Framework.DomainModel.S101.FeatureTypes.DredgedArea {
                                depthRangeMinimumValue = drval1,
                                depthRangeMaximumValue = drval2,
                                dredgedDate = null,
                                maximumPermittedDraught = null,
                                verticalUncertainty = null,
                            };
                            if (DBNull.Value != current["SORDAT"]) {
                                var sordat = Convert.ToString(current["SORDAT"]);
                                if (!string.IsNullOrEmpty(sordat)) {
                                    System.Diagnostics.Debugger.Break();    //  Dredged Date
                                }
                            }
                            if (DBNull.Value != current["RESTRN"]) {
                                var restrn = Convert.ToString(current["RESTRN"]);
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
                            }
                            if (DBNull.Value != current["QUASOU"]) {
                                var quasou = Convert.ToString(current["QUASOU"]);
                                if (!string.IsNullOrEmpty(quasou)) {
                                    dredgedarea.qualityOfVerticalMeasurement = quasou.ToLowerInvariant() switch {
                                        "1" => DomainModel.S101.qualityOfVerticalMeasurement.DepthKnown,
                                        "2" => DomainModel.S101.qualityOfVerticalMeasurement.DepthOrLeastDepthUnknown,
                                        _ => throw new IndexOutOfRangeException(),
                                    };
                                }
                            }
                            if (DBNull.Value != current["TECSOU"]) {
                                var tecsou = Convert.ToString(current["TECSOU"]);
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
                            }

                            //TODO: 	verticalUncertainty
                            //TODO: 	maximumPermittedDraught

                            AddFeatureName(dredgedarea.featureName, current);
                            AddInformation(dredgedarea.information, current);

                            buffer["ps"] = "S-101";
                            buffer["code"] = "DredgedArea";
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(dredgedarea);
                            buffer["shape"] = current.GetShape();
                            insert.Insert(buffer);
                        }
                        break;

                    case 10: {    //SWPARE
                            var drval1 = Convert.ToDecimal(current["DRVAL1"]);

                            var sweptarea = new S100Framework.DomainModel.S101.FeatureTypes.SweptArea {
                                depthRangeMinimumValue = drval1,
                                scaleMinimum = null,
                                sweptDate = null,
                            };
                            if (DBNull.Value != current["SORDAT"]) {
                                var sordat = Convert.ToString(current["SORDAT"]);
                                if (!string.IsNullOrEmpty(sordat)) {
                                    System.Diagnostics.Debugger.Break();    //  Swept Date
                                }
                            }

                            AddInformation(sweptarea.information, current);

                            buffer["ps"] = "S-101";
                            buffer["code"] = "SweptArea";
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(sweptarea);
                            buffer["shape"] = current.GetShape();
                            insert.Insert(buffer);
                        }
                        break;

                    case 15: {    // UNSARE
                            var unsurveyedarea = new S100Framework.DomainModel.S101.FeatureTypes.UnsurveyedArea {
                            };
                            AddInformation(unsurveyedarea.information, current);

                            buffer["ps"] = "S-101";
                            buffer["code"] = "UnsurveyedArea";
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(unsurveyedarea);
                            buffer["shape"] = current.GetShape();
                            insert.Insert(buffer);
                        }
                        break;
                }
            }
        }
    }
}
