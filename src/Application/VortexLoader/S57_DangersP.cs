using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.AttributeModel.S101;
using S100Framework.AttributeModel.S101.FeatureTypes;

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
                            instance.information_optional = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);


                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var nameN = featureN.UID();

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, nameN);
                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum_optional);
                            }

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;
                    case 10: { // FSHFAC Fishing facilities
                            throw new NotImplementedException($"No FSHFAC in DK or GL. {tableName}");
                        }
                    case 20: { // OBSTRN

                            // Foul ground
                            if (current.CATOBS.HasValue && current.CATOBS.Value == 7) {
                                var instance = new FoulGround();

                                instance.featureName_optional = GetFeatureName(current.OBJNAM, current.NOBJNM);

                                // TODO: interoperabilityIdentifier

                                if (current.QUASOU != default) {
                                    instance.qualityOfVerticalMeasurement = EnumHelper.GetEnumValues(current.QUASOU);
                                }
                                if (!string.IsNullOrEmpty(current.SORDAT)) {
                                    if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                        instance.reportedDate = result;
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                    }
                                }

                                if (current.STATUS != default) {
                                    instance.status_optional = GetStatus(current.STATUS);
                                }

                                if (current.TECSOU != null) {
                                    var techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues(current.TECSOU);
                                    if (techniqueOfVerticalMeasurement is not null && techniqueOfVerticalMeasurement.Any())
                                        instance.techniqueOfVerticalMeasurement_optional = techniqueOfVerticalMeasurement;
                                }

                                if (current.VALSOU.HasValue && current.VALSOU.Value != -32767d) {
                                    instance.valueOfSounding_optional = current.VALSOU.Value;
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

                                    instance.scaleMinimum_optional = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                }

                                var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                                instance.information_optional = result.information.ToArray();
                                instance.SetInformationBindings(result.InformationBindings.ToArray());

                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["edition"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                                buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);


                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var nameN = featureN.UID();

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, nameN);
                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum_optional);
                                }

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                                break;
                            }

                            var obstruction = ImporterNIS._converterRegistry.Convert<Obstruction>(current); // new List<DangersP>() { current });

                            buffer["ps"] = ps101;
                            buffer["code"] = obstruction.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(obstruction);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(obstruction.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureObs = featureClass.CreateRow(buffer);
                            var name = featureObs.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, obstruction, featureObs, obstruction.scaleMinimum_optional);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(obstruction));
                        }

                        break;

                    case 35: { // UWTROC
                            var instance = new UnderwaterAwashRock {
                                surroundingDepth = default,
                                valueOfSounding = default,
                                waterLevelEffect = default,
                            };

                            if (current.EXPSOU.HasValue) {
                                instance.expositionOfSounding_optional = EnumHelper.GetEnumValue(current.EXPSOU.Value);
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information_optional = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            // TODO: interoperabilityIdentifier

                            instance.featureName_optional = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.NATSUR != null) {
                                instance.natureOfSurface = EnumHelper.GetEnumValue(current.NATSUR);
                            }

                            if (current.QUASOU != default) {
                                instance.qualityOfVerticalMeasurement = EnumHelper.GetEnumValues(current.QUASOU);
                            }

                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status_optional = GetSingleStatus(current.STATUS)?.value;
                            }

                            if (current.TECSOU != default) {
                                var techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues(current.TECSOU);
                                if (techniqueOfVerticalMeasurement is not null && techniqueOfVerticalMeasurement.Any())
                                    instance.techniqueOfVerticalMeasurement_optional = techniqueOfVerticalMeasurement;
                            }

                            if (current.VALSOU.HasValue && current.VALSOU.Value != -32767d) {
                                instance.valueOfSounding_optional = current.VALSOU.Value;
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

                                instance.scaleMinimum_optional = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information_optional = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            bool coveredByUnsurveyedArea = false;
                            bool coveredByDredgedArea = false;
                            double? leastDepth = null;

                            if (current.SHAPE != null) {
                                foreach (DepthsA depthArea in SpatialRelationResolver.Instance.GetSpatialRelatedValueFrom<DepthsA>(current.SHAPE!)) {
                                    leastDepth = depthArea.DRVAL1.HasValue ? depthArea.DRVAL1.Value : null;
                                    if (depthArea.FcSubtype!.Value == 15) {  // UNSARE
                                        coveredByUnsurveyedArea = true;
                                        break;
                                    }
                                    if (depthArea.FcSubtype!.Value == 5) {  // DRGARE
                                        coveredByDredgedArea = true;
                                        instance.surroundingDepth = leastDepth != -32767d ? leastDepth : null;
                                    }
                                    if (depthArea.FcSubtype!.Value == 1) {  // DEPARE
                                        instance.surroundingDepth = leastDepth != -32767d ? leastDepth : null;
                                    }

                                    instance.surroundingDepth = leastDepth != -32767d ? leastDepth : null;
                                }
                            }


                            bool allCoveringDepthRangeMinimumValuesAreKnown = instance.surroundingDepth.HasValue;

                            bool unknownDepthCoveredByUnsurveyedArea = coveredByUnsurveyedArea && (current.VALSOU.HasValue && current.VALSOU.Value == -32767d);

                            bool depthDredgedAreaWhereDepthMinimumValueIsUnknown = coveredByDredgedArea && !instance.surroundingDepth.HasValue;

                            if (allCoveringDepthRangeMinimumValuesAreKnown) {
                                if (!(current.VALSOU.HasValue && current.VALSOU.Value != -32767d)) {
                                    if (current.EXPSOU.HasValue && (current.EXPSOU.Value == 1 || current.EXPSOU.Value == 3) &&
                                        (current.VALSOU.HasValue && current.VALSOU.Value == -32767d) &&
                                        (current.WATLEV.HasValue && (current.WATLEV.Value == 3))) {

                                        instance.defaultClearanceDepth = instance.surroundingDepth;
                                    }
                                    else if (((current.EXPSOU.HasValue && current.EXPSOU.Value == 2) || (!current.EXPSOU.HasValue)) &&
                                       (current.VALSOU.HasValue && current.VALSOU.Value == -32767d) &&
                                       (current.WATLEV.HasValue && (current.WATLEV.Value == 3))) {

                                        instance.defaultClearanceDepth = 0.1d;
                                    }
                                    else if (((current.EXPSOU.HasValue && current.EXPSOU.Value == 2) || (!current.EXPSOU.HasValue)) &&
                                       (current.VALSOU.HasValue && current.VALSOU.Value == -32767d) &&
                                       (current.WATLEV.HasValue && (current.WATLEV.Value == 5))) {

                                        instance.defaultClearanceDepth = 0d;
                                    }
                                    else if (((current.EXPSOU.HasValue && current.EXPSOU.Value == 2) || (!current.EXPSOU.HasValue)) &&
                                       (current.VALSOU.HasValue && current.VALSOU.Value == -32767d) &&
                                       (current.WATLEV.HasValue && (current.WATLEV.Value == 4 || current.WATLEV.Value == -32767d))) {

                                        instance.defaultClearanceDepth = -15d;
                                    }
                                    else {
                                        ;// Logger.Current.DataError(current.OBJECTID.Value, tableName, longname, $"Cannot convert defaultCleareanceDepth for underwater awash rock. Check S-101 Annex - A.");
                                    }
                                }                                
                            }
                            else if (unknownDepthCoveredByUnsurveyedArea || depthDredgedAreaWhereDepthMinimumValueIsUnknown) {
                                if ((current.VALSOU.HasValue && current.VALSOU.Value == -32767d) &&
                                   (current.WATLEV.HasValue && (current.WATLEV.Value == 3))) {
                                    instance.defaultClearanceDepth = 0.1d;
                                }
                                else if ((current.VALSOU.HasValue && current.VALSOU.Value == -32767d) &&
                                   (current.WATLEV.HasValue && (current.WATLEV.Value == 5))) {
                                    instance.defaultClearanceDepth = 0d;
                                }
                                else if ((current.VALSOU.HasValue && current.VALSOU.Value == -32767d) &&
                                        (current.WATLEV.HasValue && (current.WATLEV.Value == 4 || current.WATLEV.Value == -32767d))) {
                                    instance.defaultClearanceDepth = -15d;
                                }
                                else {
                                    ;// Logger.Current.DataError(current.OBJECTID.Value, tableName, longname, $"Cannot convert defaultCleareanceDepth for underwater awash rock. Check S-101 Annex - A.");
                                }

                            }
                            else {
                                Logger.Current.DataError(current.OBJECTID!.Value, current.TableName!, current.LNAM ?? "Unknown LNAM", $"Cannot set default clearance depth. Check loader.");
                            }


                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum_optional);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 40: { // WATTUR
                            var instance = new WaterTurbulence {
                                categoryOfWaterTurbulence = default,
                            };

                            if (current.CATWAT.HasValue) {
                                instance.categoryOfWaterTurbulence = EnumHelper.GetEnumValue(current.CATWAT);
                            }

                            instance.featureName_optional = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: interoperabilityIdentifier

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum_optional = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information_optional = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum_optional);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
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
                                instance.expositionOfSounding_optional = EnumHelper.GetEnumValue(current.EXPSOU.Value);
                            }

                            instance.featureName_optional = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height_optional = current.HEIGHT.Value;
                            }
                            else {
                                
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.QUASOU != default) {
                                instance.qualityOfVerticalMeasurement = EnumHelper.GetEnumValues(current.QUASOU);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous_optional = current.CONRAD.Value == 2 ? false : true;
                            }
                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status_optional = GetStatus(current.STATUS);
                            }

                            if (current.TECSOU != null) {
                                /*
                                    The TECSOU value 6 (swept by wire-drag) is prohibited in S-101. 
                                    This value has been replaced by the technique of vertical measurement value 18 (mechanically swept). 
                                    During the automated conversion process, all instances of TECSOU = 6 will be converted to technique of vertical measurement = 18.
                                 */
                                var tecsou = !string.IsNullOrEmpty(current.TECSOU) && int.Parse(current.TECSOU) == 6 ? "18" : current.TECSOU;
                                instance.techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues(tecsou);
                            }

                            if (current.VALSOU.HasValue && current.VALSOU.Value != -32767d) {
                                instance.valueOfSounding_optional = current.VALSOU.Value;
                            }
                            else {
                                
                            }

                            if (current.CONVIS.HasValue) {
                                instance.visualProminence_optional = EnumHelper.GetEnumValue(current.CONVIS.Value);
                            }

                            if (current.WATLEV.HasValue) {
                                instance.waterLevelEffect_optional = EnumHelper.GetEnumValue(current.WATLEV);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum_optional = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information_optional = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            foreach (DepthsA depthArea in SpatialRelationResolver.Instance.GetSpatialRelatedValueFrom<DepthsA>(current.SHAPE!)) {
                                var drval1 = depthArea.DRVAL1 ?? default;
                                instance.surroundingDepth = drval1;
                            }

                            instance.defaultClearanceDepth = GetDefaultClearanceDepthWreck(current.SHAPE, current.VALSOU, current.EXPSOU, current.HEIGHT, current.WATLEV, current.CATWRK, current.OBJECTID!.Value, current.TableName!, current.LNAM!);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonInformationTypeSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum_optional);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
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