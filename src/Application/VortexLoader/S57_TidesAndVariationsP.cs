using ArcGIS.Core.Data;
using S100FC;
using S100FC.S101.FeatureTypes;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_TidesAndVariationsP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "TidesAndVariationsP";

            using var tidesAndVariationsP = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(tidesAndVariationsP);

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("point"));

            using var buffer = featureClass.CreateRowBuffer();

            using var cursor = tidesAndVariationsP.Search(filter, true);
            int recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new TidesAndVariationsP(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (FeatureRelations.Instance.IsSlave(globalid)) {
                    continue;
                }

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    throw new Exception("Ups. Not supported");
                }



                var fcSubtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;

                switch (fcSubtype) {
                    case 1: { // LOCMAG_LocalMagneticAnomaly
                            throw new NotImplementedException("No LOCMAG_LocalMagneticAnomaly in DK | GL NIS");
                        }
                    case 5: { // LOCMAG_LocalMagneticAnomaly
                            var instance = new LocalMagneticAnomaly {
                                /* s-65 Annex B -> LOCMAG
                                        The S-57 mandatory attribute VALLMA has been remodelled in S-101 as the mandatory complex
                                        attribute value of local magnetic anomaly, having sub-attributes magnetic anomaly value
                                        (mandatory) and reference direction, where:
                                        - magnetic anomaly value is intended to indicate both the positive (easterly) and negative
                                        (westerly) values where only a single instance of value of local magnetic anomaly is encoded,
                                        having no populated value for reference direction; or
                                        - magnetic anomaly value is intended to indicate an anomaly in a single direction, where only a
                                        single instance of value of local magnetic anomaly is encoded and reference direction is
                                        populated; or
                                        - magnetic anomaly value is intended to indicate an anomaly that is different in a positive
                                        (easterly) and negative (westerly) direction, where two instances of value of local magnetic
                                        anomaly are encoded and reference direction is populated for both instances.

                                        ** During the automated conversion process, the value populated in VALLMA will be converted across
                                        to magnetic anomaly value, noting that the value of VALLMA will be converted from minutes to
                                        decimal degrees for magnetic anomaly value. 

                                        Data Producers will be required to confirm whether
                                        the value populated in VALLMA is intended to indicate both the positive (easterly) and negative
                                        (westerly) values of the anomaly, or a disparate range; noting that S-57 guidance recommends
                                        encoding the values of a range in INFORM for the LOCMAG. Where the anomaly is a disparate
                                        range, Data Producers will be required to adjust value of local magnetic anomaly in accordance
                                        with the guidance above; and if the information contained in INFORM relates only to the range of
                                        anomaly values, remove the associated instance of the complex attribute information (see clause
                                        2.3).
                                        */


                                featureName = GetFeatureName(current.OBJNAM, current.NOBJNM)
                            };

                            // TODO: interoperabilityIdentifier

                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.reportedDate = reportedDate;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.VALLMA is not null) {
                                instance.valueOfLocalMagneticAnomaly = [new() {
                                    magneticAnomalyValue = current.VALLMA / 60,
                                }];
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();
                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleMinimum);
                            }
                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;
                    case 10: { // MAGVAR_MagneticVariation
                            var instance = new MagneticVariation {
                                referenceYearForMagneticVariation = default,
                                valueOfAnnualChangeInMagneticVariation = default,
                                valueOfMagneticVariation = default,
                            };

                            // TODO: interoperabilityIdentifier

                            /*  27.152 reference year for magnetic variation (RYRMGV)
                                IHO Definition: REFERENCE YEAR FOR MAGNETIC VARIATION. The reference calendar year for magnetic
                                variation values. (S-57 Edition 3.1, Appendix A – Chapter 2, Page 2.176, November 2000).
                                Attribute Type: Truncated date
                                Unit: Four digit year indication (YYYY)
                                Format: YYYY----
                                Example: 2009----
                                
                                Remarks:
                                The dashes (----) must be included in all cases.
                            */
                            if (current.RYRMGV != default) {
                                instance.referenceYearForMagneticVariation = current.RYRMGV.PadRight(8, '-');
                            }

                            if (current.VALACM.HasValue) {
                                instance.valueOfAnnualChangeInMagneticVariation = current.VALACM.Value;
                            }

                            if (current.VALMAG.HasValue) {
                                instance.valueOfMagneticVariation = current.VALMAG.Value;
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                var scamin = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                if (scamin.HasValue)
                                    instance.scaleMinimum = scamin.Value;
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();
                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleMinimum);
                            }
                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                        }
                        break;
                    case 15: { // T_HMON_TideHarmonicPrediction
                            throw new NotImplementedException("No T_HMON_TideHarmonicPrediction in DK | GL NIS");
                        }

                    case 20: { // T_NHMN_TideNonHarmonicPrediction
                            throw new NotImplementedException("No T_NHMN_TideNonHarmonicPrediction in DK | GL NIS");
                        }

                    case 25: { // T_TIMS_TideTimeSeries
                            throw new NotImplementedException("No T_TIMS_TideTimeSeries in DK | GL NIS");
                        }

                    case 30: { // TS_FEB_TidalStreamFloodEbb
                            var instance = new TidalStreamFloodEbb();


                            if (current.CAT_TS.HasValue) {
                                instance.categoryOfTidalStream = EnumHelper.GetEnumValue(current.CAT_TS.Value);
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            //The S-57 attributes PEREND and PERSTA for TS_FEB will not be converted.It is considered that
                            //these attributes are not relevant for Tidal Stream – Flood / Ebb in S - 101.

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.ORIENT.HasValue) {
                                instance.orientation = new() {
                                    orientationValue = current.ORIENT.HasValue && current.ORIENT.Value != -32767m ? current.ORIENT : default(decimal?),
                                    orientationUncertainty = default(decimal?)
                                };
                            }

                            if (current.CURVEL.HasValue) {
                                instance.speed = new() {
                                    speedMaximum = current.CURVEL
                                };
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                var scamin = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                if (scamin.HasValue)
                                    instance.scaleMinimum = scamin.Value;
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();
                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                        }
                        break;
                    case 35: { // TS_PAD_TidalStreamPanelData
                            throw new NotImplementedException("No TS_PAD_TidalStreamPanelData in DK | GL NIS");
                        }

                    case 40: { // TS_PNH_TidalStreamNonHarmonicPrediction
                            throw new NotImplementedException("No TS_PNH_TidalStreamNonHarmonicPrediction in DK | GL NIS");
                        }

                    case 45: { // TS_PRH_TidalStreamHarmonicPrediction
                            throw new NotImplementedException("No TS_PRH_TidalStreamHarmonicPrediction in DK | GL NIS");
                        }

                    case 50: { // TS_TIS_TidalStreamTimeSeries
                            throw new NotImplementedException("No TS_TIS_TidalStreamTimeSeries in DK | GL NIS");
                        }
                    default:
                        // code block
                        //System.Diagnostics.Debugger.Break();
                        throw new NotImplementedException("Unhandled subtype");


                }
            }
            Logger.Current.DataTotalCount(tableName, recordCount, ConversionAnalytics.Instance.GetConvertedCount(tableName));
        }


    }
}
