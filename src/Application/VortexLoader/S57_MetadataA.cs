using ArcGIS.Core.Data;
using S100FC;
using S100FC.S101.ComplexAttributes;
using S100FC.S101.FeatureTypes;
using S100FC.S101.SimpleAttributes;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {

        private static void S57_MetadataA(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "MetadataA";

            using var metadataa = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(metadataa);

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("surface"));

            using var buffer = featureClass.CreateRowBuffer();

            using var cursor = metadataa.Search(filter, true);
            int recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;

                var current = new MetaDataA(feature);

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

                //var displayScale = GetDisplayScale(serie); // DisplayScale.GetNearestBelowKey(plts_comp_scale) ?? default;

                if (current.PUBREF != default) {
                    //if (System.Diagnostics.Debugger.IsAttached)
                    //System.Diagnostics.Debugger.Break();
                }

                switch (fcSubtype) {
                    case 1: { // M_ACCY_AccuracyOfData
                            throw new NotImplementedException($"No M_ACCY_AccuracyOfData in DK or GL. {tableName}");

                        }
                    case 20: { // M_CSCL_CompilationScaleOfData
                            throw new NotImplementedException($"No M_CSCL_CompilationScaleOfData in DK or GL. {tableName}");
                        }

                    case 25: { // M_HOPA_HorizontalDatumShiftParameters
                            throw new NotImplementedException($"No M_HOPA_HorizontalDatumShiftParameters in DK or GL. {tableName}");
                        }
                    case 30: { // M_NPUB_NauticalPublicationInformation
                            //if (current.OBJECTID == 6) System.Diagnostics.Debugger.Break();
                            var instance = new InformationArea();

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                var scamin = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                if (scamin.HasValue)
                                    instance.scaleMinimum = scamin.Value;
                            }

                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.reportedDate = reportedDate;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);

                            var informations = result.information.ToArray();

                            if (current.PUBREF != default) {
                                informations = [..informations, new information {
                                    language = "eng",
                                    headline = current.PUBREF.Equals("-32767") ? null : current.PUBREF.Trim(),
                                }];
                            }

                            if (informations.Any())
                                instance.information = informations;
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;
                    case 35: { // M_NSYS_NavigationalSystemOfMarks // Navigational System of Marks - region A and B globally
                            if (current.ORIENT.HasValue) {
                                var localDirectionOfBuoyage = new LocalDirectionOfBuoyage {
                                    marksNavigationalSystemOf = default,
                                    orientationValue = default,
                                };

                                // TODO: interoperabilityIdentifier

                                if (current.MARSYS.HasValue) {
                                    localDirectionOfBuoyage.marksNavigationalSystemOf = EnumHelper.GetEnumValue(current.MARSYS.Value);
                                }
                                //else {
                                //    Logger.Current.DataError(current.OBJECTID ?? default, current.TableName ?? "Unknown tablename", current.LNAM ?? "Unknown LNAM", $"Missing MARSYS value for M_NSYS where globalid = '{{{current.GLOBALID}}}'");
                                //}
                                localDirectionOfBuoyage.orientationValue = current.ORIENT.Value;

                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";
                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                    localDirectionOfBuoyage.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                }

                                var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                                localDirectionOfBuoyage.information = result.information.ToArray();
                                localDirectionOfBuoyage.SetInformationBindings(result.InformationBindings.ToArray());

                                buffer["ps"] = ps101;
                                buffer["code"] = localDirectionOfBuoyage.GetType().Name;

                                buffer["flatten"] = localDirectionOfBuoyage.Flatten();
                                buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(localDirectionOfBuoyage.GetInformationBindings(), ImporterNIS.jsonSerializerOptions);

                                SetShape(buffer, current.SHAPE);
                                ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featurelocalDirectionOfBuoyage = featureClass.CreateRow(buffer);
                                var namelocalDirectionOfBuoyage = $"{featurelocalDirectionOfBuoyage.GetGlobalID()}";

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment!.CreateRelatedAreaEquipment(current, localDirectionOfBuoyage, featurelocalDirectionOfBuoyage, localDirectionOfBuoyage.scaleMinimum);
                                }

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(localDirectionOfBuoyage, ImporterNIS.jsonSerializerOptions));
                            }
                            else {
                                var instance = new NavigationalSystemOfMarks {
                                };

                                if (current.MARSYS.HasValue) {
                                    instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue(current.MARSYS.Value);
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? default, current.TableName ?? "Unknown tablename", current.LNAM ?? "Unknown LNAM", $"Missing MARSYS value for M_NSYS where globalid = '{{{current.GLOBALID}}}'");
                                }

                                var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                                instance.information = result.information.ToArray();
                                instance.SetInformationBindings(result.InformationBindings.ToArray());

                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;


                                buffer["flatten"] = instance.Flatten();
                                buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                                SetShape(buffer, current.SHAPE);
                                ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = featureN.UID();

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, default);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                            }
                        }
                        break;
                    case 40: { // M_QUAL_QualityOfData // SKIN OF EARTH

                            var instance = new QualityOfBathymetricData {
                            };

                            // TODO: categoryOfTemporalVariation

                            /*
                                Temporal Variation: The S-101 mandatory attribute category of temporal variation introduces the
                                ability for the Data Producer to incorporate the temporal impact on bathymetric data quality in areas
                                where the seabed is likely to change over time, or in the wake of an extreme event such as a hurricane
                                S-57 ENC to S-101 Conversion Guidance 9
                                S-65 Annex B April 2024 Edition 1.2.0
                                or tsunami. During the automated conversion process, for all M_QUAL except those where CATZOC =
                                6 (zone of confidence U (data not assessed)), the corresponding Quality of Bathymetric Data will
                                have category of temporal variation populated with value 5 (unlikely to change). For full S-101
                                functionality, Data Producers will be required to reassess the value of this attribute as required. For
                                CATZOC = 6 (zone of confidence U (data not assessed)), category of temporal variation will be
                                populated with value 6 (unassessed).
                            */

                            if (current.DRVAL1.HasValue) {
                                instance.depthRangeMinimumValue = current.DRVAL1.Value != -32767m ? current.DRVAL1 : null;
                            }

                            if (current.DRVAL2.HasValue) {
                                instance.depthRangeMaximumValue = current.DRVAL2.Value != -32767m ? current.DRVAL2 : null;
                            }

                            // TODO: featuresDetected
                            //Code Description
                            //1   zone of confidence A1
                            //2   zone of confidence A2
                            //3   zone of confidence B
                            //4   zone of confidence C
                            //5   zone of confidence D
                            //6   zone of confidence U(data not assessed)

                            // During the automated conversion process, for all M_QUAL
                            // except those where CATZOC = 6 (zone of confidence U(data not assessed)),
                            // the corresponding Quality of Bathymetric Data will
                            // have category of temporal variation populated with value 5(unlikely to change).

                            /* S-65 Annex B p.8
                                Data Assessment: The S-101 mandatory attribute data assessment introduces an option to reduce
                                screen clutter in some ECDIS display modes through population of value 2 (assessed (oceanic)). This
                                value is intended for use where an indication of the overall data quality is not considered to be required
                                – generally in depths deeper the 200 metres. However, determination as to when this value may be
                                populated cannot be made during the automated conversion process, therefore for all M_QUAL except
                                those where CATZOC = 6 (zone of confidence U (data not assessed)), the corresponding Quality of
                                Bathymetric Data will have data assessment populated with value 1 (assessed).
                             */



                            if (current.CATZOC.HasValue) { // A1
                                int catzoc = current.CATZOC!.Value;

                                if (catzoc == 1) {
                                    instance.categoryOfTemporalVariation = 5;   // categoryOfTemporalVariation.UnlikelyToChange;
                                    instance.dataAssessment = 1;    // dataAssessment.Assessed;
                                    instance.featuresDetected = new featuresDetected() {
                                        significantFeaturesDetected = true,
                                        leastDepthOfDetectedFeaturesMeasured = true,

                                    };
                                    instance.fullSeafloorCoverageAchieved = true;
                                    instance.zoneOfConfidence = [new zoneOfConfidence() {
                                        categoryOfZoneOfConfidenceInData = 1,   //categoryOfZoneOfConfidenceInData.ZoneOfConfidenceA1
                                    }];
                                }
                                else if (catzoc == 2) { // A2
                                    instance.categoryOfTemporalVariation = 5;   // categoryOfTemporalVariation.UnlikelyToChange;
                                    instance.dataAssessment = 1;    // dataAssessment.Assessed;
                                    instance.featuresDetected = new featuresDetected() {
                                        significantFeaturesDetected = true,
                                        leastDepthOfDetectedFeaturesMeasured = true,

                                    };
                                    instance.fullSeafloorCoverageAchieved = true;
                                    instance.zoneOfConfidence = [new zoneOfConfidence() {
                                        categoryOfZoneOfConfidenceInData = 2,   //categoryOfZoneOfConfidenceInData.ZoneOfConfidenceA2,
                                    }];
                                }
                                else if (catzoc == 3) { // B
                                    instance.categoryOfTemporalVariation = 5;   // categoryOfTemporalVariation.UnlikelyToChange;
                                    instance.dataAssessment = 1;    // dataAssessment.Assessed;
                                    instance.featuresDetected = new featuresDetected() {
                                        significantFeaturesDetected = false,
                                        leastDepthOfDetectedFeaturesMeasured = false,

                                    };
                                    instance.fullSeafloorCoverageAchieved = false;
                                    instance.zoneOfConfidence = [new zoneOfConfidence() {
                                        categoryOfZoneOfConfidenceInData = 3,   //categoryOfZoneOfConfidenceInData.ZoneOfConfidenceB,                                        
                                    }];
                                }
                                else if (catzoc == 4) { // C
                                    instance.categoryOfTemporalVariation = 5;   // categoryOfTemporalVariation.UnlikelyToChange;
                                    instance.dataAssessment = 1;    // dataAssessment.Assessed;
                                    instance.featuresDetected = new featuresDetected() {
                                        significantFeaturesDetected = false,
                                        leastDepthOfDetectedFeaturesMeasured = false,

                                    };
                                    instance.fullSeafloorCoverageAchieved = false;
                                    instance.zoneOfConfidence = [new zoneOfConfidence() {
                                        categoryOfZoneOfConfidenceInData = 4,   //categoryOfZoneOfConfidenceInData.ZoneOfConfidenceC,                                        
                                    }];

                                }
                                else if (catzoc == 5) { // D
                                    instance.categoryOfTemporalVariation = 5;   // categoryOfTemporalVariation.UnlikelyToChange;
                                    instance.dataAssessment = 1;    // dataAssessment.Assessed;
                                    instance.featuresDetected = new featuresDetected() {
                                        significantFeaturesDetected = false,
                                        leastDepthOfDetectedFeaturesMeasured = false,

                                    };
                                    instance.fullSeafloorCoverageAchieved = false;
                                    instance.zoneOfConfidence = [new zoneOfConfidence() {
                                        categoryOfZoneOfConfidenceInData = 5,   //categoryOfZoneOfConfidenceInData.ZoneOfConfidenceD,                                        
                                    }];

                                }
                                else if (catzoc == 6) { // U
                                    instance.categoryOfTemporalVariation = 5;   // categoryOfTemporalVariation.Unassessed;
                                    instance.dataAssessment = 1;    // dataAssessment.Unassessed;
                                    instance.featuresDetected = new featuresDetected() {
                                        significantFeaturesDetected = false,
                                        leastDepthOfDetectedFeaturesMeasured = false,

                                    };
                                    instance.fullSeafloorCoverageAchieved = false;
                                    instance.zoneOfConfidence = [new zoneOfConfidence() {
                                        categoryOfZoneOfConfidenceInData = 6,   //categoryOfZoneOfConfidenceInData.ZoneOfConfidenceU,                                        
                                    }];
                                }
                                else {
                                    throw new NotSupportedException($"Unknown catzoc {catzoc}. objectid: {objectid} - {tableName}");
                                }
                            }

                            // TODO: interoperabilityIdentifier

                            if (DateHelper.TryGetSurveyDateRange(current.SURSTA, current.SUREND, out var dateRange)) {
                                instance.surveyDateRange = dateRange;
                            }

                            if (DateHelper.TryGetSurveyDateRange(current.SURSTA, current.SUREND, out var surveyDateRange)) {
                                instance.surveyDateRange = surveyDateRange;
                            }


                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;
                    case 45: { // M_SDAT_SoundingDatum
                               // Handled by S101_SoundingDatum
                               //var verticalDatum = !current.VERDAT.HasValue ? null : ImporterNIS.GetVerticalDatum<LightAirObstruction>(current.VERDAT ?? 3);
                               //VerticalDatums.Instance.Add(current.SHAPE!.Clone(), verticalDatum!.Value);

                        }
                        break;
                    case 50: { // M_SREL_SurveyReliability
                            var instance = new QualityOfSurvey {
                            };

                            if (current.DRVAL1.HasValue) {
                                instance.depthRangeMinimumValue = current.DRVAL1.Value != -32767m ? current.DRVAL1.Value : null;
                            }
                            if (current.DRVAL2.HasValue) {
                                instance.depthRangeMaximumValue = current.DRVAL2.Value != -32767m ? current.DRVAL2.Value : null;
                            }

                            // TODO: featuresdetected

                            // TODO: full seafloor covearge achieved

                            // TODO: interoperabilityIdentifier

                            // TODO: line spacing maximum

                            // TODO: line spacing minimum

                            if (current.SDISMX.HasValue) {
                                if (current.SDISMX.Value == -32767m) {
                                    instance.measurementDistanceMaximum = null;
                                }
                                else {
                                    if (current.SDISMX.Value % 1 == 0) {
                                        instance.measurementDistanceMaximum = Convert.ToInt32(current.SDISMX.Value);
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID!.Value, current.LNAM ?? "Empty LNAM", current.TableName ?? "Unknown tablename", $"SDISMX on M_SREL: value is {current.SDISMX} and cannot be converted to an integer");
                                    }
                                }
                            }

                            if (current.SDISMN.HasValue) {
                                if (current.SDISMN.Value == -32767m) {
                                    instance.measurementDistanceMaximum = null;
                                }
                                else {
                                    if (current.SDISMN.Value % 1 == 0) {
                                        instance.measurementDistanceMaximum = Convert.ToInt32(current.SDISMN.Value);
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID!.Value, current.LNAM ?? "Empty LNAM", current.TableName ?? "Unknown tablename", $"SDISMN on M_SREL: value is {current.SDISMN} and cannot be converted to an integer");
                                    }
                                }
                            }

                            if (current.QUAPOS.HasValue) {
                                instance.qualityOfHorizontalMeasurement = current.QUAPOS.Value switch {
                                    4 => 4, //qualityOfHorizontalMeasurement.Approximate,
                                    _ => default,
                                };
                            }

                            if (current.QUASOU != default) {
                                var qualityOfVerticalMeasurement = EnumHelper.GetEnumValues(current.QUASOU);
                                if (qualityOfVerticalMeasurement is not null && qualityOfVerticalMeasurement.Any())
                                    instance.qualityOfVerticalMeasurement = qualityOfVerticalMeasurement;
                            }

                            if (current.SCVAL1.HasValue && current.SCVAL1 != -32767) {
                                instance.scaleValueMaximum = current.SCVAL1;
                            }

                            if (current.SCVAL2.HasValue && current.SCVAL2 != -32767) {
                                instance.scaleValueMinimum = current.SCVAL2;
                            }

                            if (current.SURATH != default) {
                                instance.surveyAuthority = current.SURATH;
                            }

                            if (DateHelper.TryGetSurveyDateRange(current.SURSTA, current.SUREND, out var surveyDateRange)) {
                                instance.surveyDateRange = surveyDateRange!;
                            }

                            if (current.SURTYP != default) {
                                var surveyType = EnumHelper.GetEnumValues(current.SURTYP);
                                if (surveyType is not null)
                                    instance.surveyType = surveyType;
                            }

                            if (current.TECSOU != null) {
                                var techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues(current.TECSOU);
                                if (techniqueOfVerticalMeasurement is not null && techniqueOfVerticalMeasurement.Any())
                                    instance.techniqueOfVerticalMeasurement = techniqueOfVerticalMeasurement;
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleValueMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                        }
                        break;
                    case 55: { // M_VDAT_VerticalDatumOfData
                            var instance = new VerticalDatumOfData {
                                verticalDatum = default,
                            };

                            // TODO: interoperabilityIdentifier

                            var verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT);
                            if (verticalDatum != null) {
                                var update = true;
                                foreach (var elm in VerticalDatums.Instance.Touch(current.SHAPE!)) {
                                    if (elm.Item2.value == verticalDatum.value) {
                                        update = false;
                                    }
                                }
                                if (update)
                                    instance.verticalDatum = verticalDatum.value;
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
                                relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, default);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                            if (verticalDatum is not null) {
                                VerticalDatums.Instance.Add(current.SHAPE!.Clone(), verticalDatum!.value);
                            }
                            else {
                                Logger.Current.DataError(current.OBJECTID.Value, current.TableName!, current.LNAM!, $"M_VDAT_VerticalDatumOfData has no VERDAT");
                            }

                            // if (current.VERDAT.HasValue) {
                            //var verdat = Convert.ToInt32(current.VERDAT);
                            //if (verdat != default) {
                            //    instance.verticalDatum = verdat switch {
                            //        1 => verticalDatum.MeanLowWaterSprings,
                            //        2 => verticalDatum.MeanLowerLowWaterSprings,
                            //        3 => verticalDatum.MeanSeaLevel,
                            //        4 => verticalDatum.LowestLowWater,
                            //        5 => verticalDatum.MeanLowWater,
                            //        6 => verticalDatum.LowestLowWaterSprings,
                            //        7 => verticalDatum.ApproximateMeanLowWaterSprings,
                            //        8 => verticalDatum.IndianSpringLowWater,
                            //        9 => verticalDatum.LowWaterSprings,
                            //        10 => verticalDatum.ApproximateLowestAstronomicalTide,
                            //        11 => verticalDatum.NearlyLowestLowWater,
                            //        12 => verticalDatum.MeanLowerLowWater,
                            //        13 => verticalDatum.LowWater,
                            //        14 => verticalDatum.ApproximateMeanLowWater,
                            //        15 => verticalDatum.ApproximateMeanLowerLowWater,
                            //        16 => verticalDatum.MeanHighWater,
                            //        17 => verticalDatum.MeanHighWaterSprings,
                            //        18 => verticalDatum.HighWater,
                            //        19 => verticalDatum.ApproximateMeanSeaLevel,
                            //        20 => verticalDatum.HighWaterSprings,
                            //        21 => verticalDatum.MeanHigherHighWater,
                            //        22 => verticalDatum.EquinoctialSpringLowWater,
                            //        23 => verticalDatum.LowestAstronomicalTide,
                            //        24 => verticalDatum.LocalDatum,
                            //        25 => verticalDatum.InternationalGreatLakesDatum1985,
                            //        26 => verticalDatum.MeanWaterLevel,
                            //        27 => verticalDatum.LowerLowWaterLargeTide,
                            //        28 => verticalDatum.HigherHighWaterLargeTide,
                            //        29 => verticalDatum.NearlyHighestHighWater,
                            //        30 => verticalDatum.HighestAstronomicalTide,
                            //        44 => verticalDatum.BalticSeaChartDatum2000,
                            //        -1 => verticalDatum.Unknown,
                            //        _ => throw new ArgumentOutOfRangeException(nameof(verdat), "Invalid value for vertical datum.")
                            //    };

                            //}
                            //break;
                            //}
                        }
                        break;
                    default:
                        // code block
                        System.Diagnostics.Debugger.Break();
                        break;
                }



            }
            Logger.Current.DataTotalCount(tableName, recordCount, ConversionAnalytics.Instance.GetConvertedCount(tableName));
        }


    }
}
