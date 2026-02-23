using ArcGIS.Core.Data;
using S100FC;
using S100FC.S101.FeatureTypes;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_DangersP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "DangersP";

            using var dangersp = source.OpenDataset<FeatureClass>(source.GetName("DangersP"));
            using var depthsA = source.OpenDataset<FeatureClass>(source.GetName("DepthsA"));
            Subtypes.Instance.RegisterSubtypes(dangersp);

            //var dredged = source.OpenDataset<FeatureClass>("Depare");

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("point"));

            using var buffer = featureClass.CreateRowBuffer();

            using var cursor = dangersp.Search(filter, true);
            int recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new DangersP(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (FeatureRelations.Instance.IsSlave(globalid)) {
                    continue;
                }

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    throw new Exception("Ups. Not supported");
                }


                var fcSubtype = current.FCSUBTYPE ?? default;

                var longname = current.LNAM ?? Strings.UNKNOWN;

                bool isValsouEmpty = !current.VALSOU.HasValue;

                // The attribute default clearance depth must be populated with a value, which must not be an empty(null)
                // value, only if the attribute value of sounding for the feature instance is populated with an empty(null) value
                // and the attribute height, if an allowable attribute for the feature, is not populated.
                // S-101 Annex A_DCEG Edition 1.5.0_Draft for Edition 2.0.0.pdf: p.771
                //Decimal defaultClearanceDepth = -1;

                //if (current.OBJECTID == 298) System.Diagnostics.Debugger.Break();

                switch (fcSubtype) {
                    case 1: { // CTNARE
                            var instance = new CautionArea();

                            if (current.CONDTN.HasValue) {
                                instance.condition = EnumHelper.GetEnumValue(current.CONDTN);
                            }

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRangeDAT);
                            if (dateRangeDAT != default) {
                                instance.fixedDateRange = dateRangeDAT;
                            }

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var dateRangePER);
                            if (dateRangePER != default) {
                                instance.periodicDateRange = dateRangePER;
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
                            var nameN = featureN.UID();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, nameN);
                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;
                    case 10: { // FSHFAC Fishing facilities
                            var instance = new FishingFacility();

                            if (current.CATFIF.HasValue) {
                                instance.categoryOfFishingFacility = EnumHelper.GetEnumValue(current.CATFIF.Value);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            // TODO: interoperabilityIdentifier

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.reportedDate = reportedDate;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
                            }
                            else {
                                //instance.verticalLength = default(decimal?);
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
                    case 20: { // OBSTRN

                            // Foul ground
                            if (current.CATOBS.HasValue && current.CATOBS.Value == 7) {
                                var instance = new FoulGround {
                                    featureName = GetFeatureName(current.OBJNAM, current.NOBJNM)
                                };

                                // TODO: interoperabilityIdentifier

                                if (current.QUASOU != default) {
                                    var qualityOfVerticalMeasurement = EnumHelper.GetEnumValues(current.QUASOU);
                                    if (qualityOfVerticalMeasurement is not null && qualityOfVerticalMeasurement.Any())
                                        instance.qualityOfVerticalMeasurement = qualityOfVerticalMeasurement;
                                }
                                if (!string.IsNullOrEmpty(current.SORDAT)) {
                                    if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                        instance.reportedDate = reportedDate;
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                    }
                                }

                                if (current.STATUS != default) {
                                    instance.status = GetStatus(current.STATUS);
                                }

                                if (current.TECSOU != null) {
                                    var techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues(current.TECSOU);
                                    if (techniqueOfVerticalMeasurement is not null && techniqueOfVerticalMeasurement.Any())
                                        instance.techniqueOfVerticalMeasurement = techniqueOfVerticalMeasurement;
                                }

                                if (current.VALSOU.HasValue) {
                                    instance.valueOfSounding = current.VALSOU.Value != -32767m ? current.VALSOU.Value : null;
                                }
                                else {

                                }

                                if (current.SOUACC.HasValue) {
                                    instance.verticalUncertainty = new() {
                                        uncertaintyFixed = current.SOUACC.Value
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
                                var nameN = featureN.UID();

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, nameN);
                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                                }

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                                break;
                            }

                            var obstruction = ImporterNIS._converterRegistry.Convert<Obstruction>(current); // new List<DangersP>() { current });

                            buffer["ps"] = ps101;
                            buffer["code"] = obstruction.GetType().Name;

                            buffer["flatten"] = obstruction.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(obstruction.GetInformationBindings(), ImporterNIS.jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureObs = featureClass.CreateRow(buffer);
                            var name = featureObs.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, obstruction, featureObs, obstruction.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(obstruction, ImporterNIS.jsonSerializerOptions));
                        }

                        break;

                    case 35: { // UWTROC
                            var instance = new UnderwaterAwashRock {
                                surroundingDepth = default,
                                valueOfSounding = default,
                                waterLevelEffect = default,
                            };

                            if (current.EXPSOU.HasValue) {
                                instance.expositionOfSounding = EnumHelper.GetEnumValue(current.EXPSOU.Value);
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            // TODO: interoperabilityIdentifier

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            if (current.NATSUR != null) {
                                instance.natureOfSurface = EnumHelper.GetEnumValue(current.NATSUR);
                            }

                            if (current.QUASOU != default) {
                                var qualityOfVerticalMeasurement = EnumHelper.GetEnumValues(current.QUASOU);
                                if (qualityOfVerticalMeasurement is not null && qualityOfVerticalMeasurement.Any())
                                    instance.qualityOfVerticalMeasurement = qualityOfVerticalMeasurement;
                            }

                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.reportedDate = reportedDate;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetSingleStatus(current.STATUS)?.value;
                            }

                            if (current.TECSOU != default) {
                                var techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues(current.TECSOU);
                                if (techniqueOfVerticalMeasurement is not null && techniqueOfVerticalMeasurement.Any())
                                    instance.techniqueOfVerticalMeasurement = techniqueOfVerticalMeasurement;
                            }

                            if (current.VALSOU.HasValue) {
                                instance.valueOfSounding = current.VALSOU.Value != -32767m ? current.VALSOU.Value : null;
                            }
                            else {

                            }

                            //      S57
                            //    Code Description
                            // 1   partly submerged at high water
                            // 2   always dry
                            // 3   always under water / submerged
                            // 4   covers and uncovers
                            // 5   awash
                            // 6   subject to inundation or flooding
                            // 7   floating
                            // -1  Unknown
                            if (current.WATLEV.HasValue) {
                                instance.waterLevelEffect = EnumHelper.GetEnumValue(current.WATLEV.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                var scamin = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                if (scamin.HasValue)
                                    instance.scaleMinimum = scamin.Value;
                            }

                            bool coveredByUnsurveyedArea = false;
                            bool coveredByDredgedArea = false;
                            decimal? leastDepth = null;

                            //if (current.OBJECTID == 37) System.Diagnostics.Debugger.Break();

                            if (current.SHAPE != null) {
                                foreach (DepthsA depthArea in SpatialRelationResolver.Instance.GetSpatialRelatedValueFrom<DepthsA>(current.SHAPE!)) {
                                    leastDepth = depthArea.DRVAL1.HasValue ? depthArea.DRVAL1.Value : null;
                                    if (depthArea.FcSubtype!.Value == 15) {  // UNSARE
                                        coveredByUnsurveyedArea = true;
                                        break;
                                    }
                                    if (depthArea.FcSubtype!.Value == 5) {  // DRGARE
                                        coveredByDredgedArea = true;
                                        instance.surroundingDepth = leastDepth != -32767m ? leastDepth : null;
                                    }
                                    if (depthArea.FcSubtype!.Value == 1) {  // DEPARE
                                        instance.surroundingDepth = leastDepth != -32767m ? leastDepth : null;
                                    }

                                    instance.surroundingDepth = leastDepth != -32767m ? leastDepth : null;
                                }
                            }

                            //if (current.OBJECTID == 37) System.Diagnostics.Debugger.Break();

                            bool allCoveringDepthRangeMinimumValuesAreKnown = instance.surroundingDepth is not null;

                            bool unknownDepthCoveredByUnsurveyedArea = coveredByUnsurveyedArea && (current.VALSOU.HasValue && current.VALSOU.Value == -32767m);

                            bool depthDredgedAreaWhereDepthMinimumValueIsUnknown = coveredByDredgedArea && !(instance.surroundingDepth is not null && instance.surroundingDepth.HasValue);

                            bool expositionOfSoundingIsUnknown = current.EXPSOU is -32767;

                            if (allCoveringDepthRangeMinimumValuesAreKnown) {
                                if (!(current.VALSOU.HasValue && current.VALSOU.Value != -32767m)) {
                                    if (current.EXPSOU.HasValue && (current.EXPSOU.Value == 1 || current.EXPSOU.Value == 3) &&
                                        (current.VALSOU.HasValue && current.VALSOU.Value == -32767m) &&
                                        (current.WATLEV.HasValue && (current.WATLEV.Value == 3))) {

                                        instance.defaultClearanceDepth = instance.surroundingDepth;
                                    }
                                    else if (((current.EXPSOU.HasValue && current.EXPSOU.Value == 2) || expositionOfSoundingIsUnknown || (!current.EXPSOU.HasValue)) &&
                                       (current.VALSOU.HasValue && current.VALSOU.Value == -32767m) &&
                                       (current.WATLEV.HasValue && (current.WATLEV.Value == 3))) {

                                        instance.defaultClearanceDepth = 0.1m;
                                    }
                                    else if (((current.EXPSOU.HasValue && current.EXPSOU.Value == 2) || expositionOfSoundingIsUnknown || (!current.EXPSOU.HasValue)) &&
                                       (current.VALSOU.HasValue && current.VALSOU.Value == -32767m) &&
                                       (current.WATLEV.HasValue && (current.WATLEV.Value == 5))) {

                                        instance.defaultClearanceDepth = 0m;
                                    }
                                    else if (((current.EXPSOU.HasValue && current.EXPSOU.Value == 2) || expositionOfSoundingIsUnknown || (!current.EXPSOU.HasValue)) &&
                                       (current.VALSOU.HasValue && current.VALSOU.Value == -32767m) &&
                                       (current.WATLEV.HasValue && (current.WATLEV.Value == 4 || current.WATLEV.Value == -32767m))) {

                                        instance.defaultClearanceDepth = -15m;
                                    }
                                    else {
                                        ;// Logger.Current.DataError(current.OBJECTID.Value, tableName, longname, $"Cannot convert defaultCleareanceDepth for underwater awash rock. Check S-101 Annex - A.");
                                    }
                                }
                            }
                            else if (unknownDepthCoveredByUnsurveyedArea || depthDredgedAreaWhereDepthMinimumValueIsUnknown) {
                                if ((current.VALSOU.HasValue && current.VALSOU.Value == -32767m) &&
                                   (current.WATLEV.HasValue && (current.WATLEV.Value == 3))) {
                                    instance.defaultClearanceDepth = 0.1m;
                                }
                                else if ((current.VALSOU.HasValue && current.VALSOU.Value == -32767m) &&
                                   (current.WATLEV.HasValue && (current.WATLEV.Value == 5))) {
                                    instance.defaultClearanceDepth = 0m;
                                }
                                else if ((current.VALSOU.HasValue && current.VALSOU.Value == -32767m) &&
                                        (current.WATLEV.HasValue && (current.WATLEV.Value == 4 || current.WATLEV.Value == -32767m))) {
                                    instance.defaultClearanceDepth = -15m;
                                }
                                else {
                                    ;// Logger.Current.DataError(current.OBJECTID.Value, tableName, longname, $"Cannot convert defaultCleareanceDepth for underwater awash rock. Check S-101 Annex - A.");
                                }

                            }
                            else {
                                Logger.Current.DataError(current.OBJECTID!.Value, current.TableName!, current.LNAM ?? "Unknown LNAM", $"Cannot set default clearance depth. Check loader.");
                            }

                            if (!instance.valueOfSounding.HasValue && instance.attributeBindings.Count(e => e.S100FC_code.Equals("defaultClearanceDepth")) == 0) {
                                Logger.Current.Error("!instance.valueOfSounding.HasValue && !defaultClearanceDepth");
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;

                    case 40: { // WATTUR
                            var instance = new WaterTurbulence {
                            };

                            if (current.CATWAT.HasValue) {
                                instance.categoryOfWaterTurbulence = EnumHelper.GetEnumValue(current.CATWAT);
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            // TODO: interoperabilityIdentifier

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

                    case 45: { // WRECKS
                            var instance = new Wreck {
                                surroundingDepth = default,
                                waterLevelEffect = default,
                            };

                            // action point #42 Attributes converted correctly but the combination of both is prohibited in S-101 (DCEG 13.5). Ignore/ drop CATWRK when VALSOU is populated on conversion.
                            if (current.CATWRK.HasValue && !current.VALSOU.HasValue) {
                                instance.categoryOfWreck = EnumHelper.GetEnumValue(current.CATWRK.Value);
                            }

                            if (current.EXPSOU.HasValue) {
                                instance.expositionOfSounding = EnumHelper.GetEnumValue(current.EXPSOU.Value);
                            }

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value != -32767m ? current.HEIGHT.Value : null;
                            }
                            else {

                            }

                            // TODO: interoperabilityIdentifier

                            if (current.QUASOU != default) {
                                var qualityOfVerticalMeasurement = EnumHelper.GetEnumValues(current.QUASOU);
                                if (qualityOfVerticalMeasurement is not null && qualityOfVerticalMeasurement.Any())
                                    instance.qualityOfVerticalMeasurement = qualityOfVerticalMeasurement;
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.reportedDate = reportedDate;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.TECSOU != null) {
                                /*
                                    The TECSOU value 6 (swept by wire-drag) is prohibited in S-101. 
                                    This value has been replaced by the technique of vertical measurement value 18 (mechanically swept). 
                                    During the automated conversion process, all instances of TECSOU = 6 will be converted to technique of vertical measurement = 18.
                                 */
                                var tecsou = !string.IsNullOrEmpty(current.TECSOU) && int.Parse(current.TECSOU) == 6 ? "18" : current.TECSOU;
                                var techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues(tecsou);
                                if (techniqueOfVerticalMeasurement is not null && techniqueOfVerticalMeasurement.Any())
                                    instance.techniqueOfVerticalMeasurement = techniqueOfVerticalMeasurement;
                            }

                            if (current.VALSOU.HasValue) {
                                instance.valueOfSounding = current.VALSOU.Value != -32767m ? current.VALSOU.Value : null;
                            }
                            else {

                            }

                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
                            }

                            if (current.WATLEV.HasValue) {
                                instance.waterLevelEffect = EnumHelper.GetEnumValue(current.WATLEV);
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

                            foreach (DepthsA depthArea in SpatialRelationResolver.Instance.GetSpatialRelatedValueFrom<DepthsA>(current.SHAPE!)) {
                                var drval1 = depthArea.DRVAL1 ?? default;
                                instance.surroundingDepth = drval1;
                            }

                            var defaultClearanceDepth = GetDefaultClearanceDepthWreck(current.SHAPE, current.VALSOU, current.EXPSOU, current.HEIGHT, current.WATLEV, current.CATWRK, current.OBJECTID!.Value, current.TableName!, current.LNAM!);
                            if (defaultClearanceDepth.HasValue)
                                instance.defaultClearanceDepth = defaultClearanceDepth;
                            //else if (!instance.valueOfSounding.HasValue && System.Diagnostics.Debugger.IsAttached) System.Diagnostics.Debugger.Break();

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
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