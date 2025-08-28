using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

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
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = dangersp.Search(filter, true);
            int recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new DangersP(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    continue;
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
                            throw new NotImplementedException($"No CTNARE in DK or GL. {tableName}");

                            var instance = new CautionArea();


                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: interoperabilityIdentifier

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetSingleStatus(current.STATUS);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 10: { // FSHFAC Fishing facilities
                            throw new NotImplementedException($"No FSHFAC in DK or GL. {tableName}");
                        }
                        break;

                    case 20: { // OBSTRN

                            // Foul ground
                            if (current.CATOBS.HasValue && current.CATOBS.Value == 7) {
                                var instance = new FoulGround();

                                instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                                // TODO: interoperabilityIdentifier

                                if (current.QUASOU != default) {
                                    instance.qualityOfVerticalMeasurement = EnumHelper.GetEnumValues<FoulGround, qualityOfVerticalMeasurement>(current.QUASOU);
                                }                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                                if (current.STATUS != default) {
                                    instance.status = GetStatus(current.STATUS);
                                }

                                if (current.TECSOU != null) {
                                    instance.techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues<FoulGround, techniqueOfVerticalMeasurement>(current.TECSOU);
                                }

                                if (current.VALSOU.HasValue && current.VALSOU.Value != -32767d) {
                                    instance.valueOfSounding = current.VALSOU.Value;
                                }
                                else {
                                    instance.valueOfSounding = default(double?);
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

                                    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                }

                                AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);

                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["edition"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var nameN = Convert.ToString(featureN["name"]) ?? "Unknown name";

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, nameN);
                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                                }

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                                break;
                            }


                            //CONDTN, EXPSOU, NATCON, NATQUA, NATSUR, PRODCT, VERLEN, WATLEV

                            //var obstruction = new Obstruction {
                            //    surroundingDepth = default,
                            //    waterLevelEffect = default,
                            //};

                            ////if (current.CATOBS categoryOfObstruction

                            //if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                            //    string subtype = "";

                            //    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                            //        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                            //    obstruction.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            //}

                            //AddInformation(obstruction.information, feature);

                            //// TODO: defaultClearanceDepth
                            var obstruction = ImporterNIS._converterRegistry.Convert<Obstruction>(current); // new List<DangersP>() { current });

                            buffer["ps"] = ps101;
                            buffer["code"] = obstruction.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;

                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(obstruction);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureObs = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureObs["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, obstruction, featureObs, obstruction.scaleMinimum);
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
                                instance.expositionOfSounding = EnumHelper.GetEnumValue<UnderwaterAwashRock, expositionOfSounding>(current.EXPSOU.Value);
                            }

                            AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);

                            // TODO: interoperabilityIdentifier

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.NATSUR != null) {
                                instance.natureOfSurface = EnumHelper.GetEnumValue<UnderwaterAwashRock, natureOfSurface>(current.NATSUR);
                            }

                            if (current.QUASOU != default) {
                                instance.qualityOfVerticalMeasurement = EnumHelper.GetEnumValues<UnderwaterAwashRock, qualityOfVerticalMeasurement>(current.QUASOU);
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
                                instance.status = GetSingleStatus(current.STATUS);
                            }

                            if (current.TECSOU != default) {
                                instance.techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues<UnderwaterAwashRock, techniqueOfVerticalMeasurement>(current.TECSOU);
                            }

                            if (current.VALSOU.HasValue && current.VALSOU.Value != -32767d) {
                                instance.valueOfSounding = current.VALSOU.Value;
                            }
                            else {
                                instance.valueOfSounding = default(double?);
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
                                instance.waterLevelEffect = EnumHelper.GetEnumValue<UnderwaterAwashRock, waterLevelEffect>(current.WATLEV.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);

                            // TODO: defaultClearanceDepth

                            //instance.defaultClearanceDepth = current.

                            if (current.SHAPE != null) {
                                foreach (DepthsA depthArea in SpatialRelationResolver.Instance.GetSpatialRelatedValueFrom<DepthsA>(current)) {
                                    var drval1 = depthArea.DRVAL1 ?? default;
                                    instance.surroundingDepth = drval1;
                                }
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
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
                                instance.categoryOfWaterTurbulence = EnumHelper.GetEnumValue<WaterTurbulence, categoryOfWaterTurbulence>(current.CATWAT);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: interoperabilityIdentifier

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
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
                            if (current.CATWRK.HasValue && !instance.valueOfSounding.HasValue) {
                                instance.categoryOfWreck = EnumHelper.GetEnumValue<Wreck, categoryOfWreck>(current.CATWRK.Value);
                            }

                            if (current.EXPSOU.HasValue) {
                                instance.expositionOfSounding = EnumHelper.GetEnumValue<Wreck, expositionOfSounding>(current.EXPSOU.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(double?);
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.QUASOU != default) {
                                instance.qualityOfVerticalMeasurement = EnumHelper.GetEnumValues<Wreck, qualityOfVerticalMeasurement>(current.QUASOU);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
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
                                instance.techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues<Wreck, techniqueOfVerticalMeasurement>(tecsou);
                            }

                            if (current.VALSOU.HasValue && current.VALSOU.Value != -32767d) {
                                instance.valueOfSounding = current.VALSOU.Value;
                            }
                            else {
                                instance.valueOfSounding = default(double?);
                            }

                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue<Wreck, visualProminence>(current.CONVIS.Value);
                            }

                            if (current.WATLEV.HasValue) {
                                instance.waterLevelEffect = EnumHelper.GetEnumValue<Wreck, waterLevelEffect>(current.WATLEV);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);

                            foreach (DepthsA depthArea in SpatialRelationResolver.Instance.GetSpatialRelatedValueFrom<DepthsA>(current)) {
                                var drval1 = depthArea.DRVAL1 ?? default;
                                instance.surroundingDepth = drval1;
                            }


                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
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