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
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.regexTruncatedDateValidation.IsMatch(current.SORDAT)) {
                                    instance.reportedDate = current.SORDAT;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.GetValueOrDefault(), tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
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

                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["version"] = ImporterNIS.s101version;
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

                            var instance = new FishingFacility();

                            if (current.CATFIF.HasValue) {
                                instance.categoryOfFishingFacility = EnumHelper.GetEnumValue<categoryOfFishingFacility>(current.CATFIF.Value);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: interoperabilityIdentifier

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.regexTruncatedDateValidation.IsMatch(current.SORDAT)) {
                                    instance.reportedDate = current.SORDAT;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.GetValueOrDefault(), tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue && current.VERLEN.Value != -32767m) {
                                instance.verticalLength = current.VERLEN.Value;
                            }
                            else {
                                instance.verticalLength = default(decimal?);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["version"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
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

                    case 20: { // OBSTRN

                            // Foul ground
                            if (current.CATOBS.HasValue && current.CATOBS.Value == 7) {
                                var instance = new FoulGround();

                                instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                                // TODO: interoperabilityIdentifier

                                if (current.QUASOU != default) {
                                    instance.qualityOfVerticalMeasurement = EnumHelper.GetEnumValues<qualityOfVerticalMeasurement>(current.QUASOU);
                                }

                                if (current.SORDAT != default) {
                                    if (DateHelper.regexTruncatedDateValidation.IsMatch(current.SORDAT)) {
                                        instance.reportedDate = current.SORDAT;
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.GetValueOrDefault(), tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                    }
                                }

                                if (current.STATUS != default) {
                                    instance.status = GetStatus(current.STATUS);
                                }

                                if (current.TECSOU != null) {
                                    instance.techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues<techniqueOfVerticalMeasurement>(current.TECSOU);
                                }

                                if (current.VALSOU.HasValue && current.VALSOU.Value != -32767m) {
                                    instance.valueOfSounding = current.VALSOU.Value;
                                }
                                else {
                                    instance.valueOfSounding = default(decimal?);
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

                                AddInformation(instance.information, feature);
                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["version"] = ImporterNIS.s101version;
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
                            var obstruction = ImporterNIS._converterRegistry.Convert<Obstruction>(new List<DangersP>() { current });
                            
                            buffer["ps"] = ps101;
                            buffer["code"] = obstruction.GetType().Name;
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
                                instance.expositionOfSounding = EnumHelper.GetEnumValue<expositionOfSounding>(current.EXPSOU.Value);
                            }

                            AddInformation(instance.information, feature);

                            // TODO: interoperabilityIdentifier

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.NATSUR != null) {
                                instance.natureOfSurface = EnumHelper.GetEnumValue<natureOfSurface>(current.NATSUR);
                            }

                            if (current.QUASOU != default) {
                                instance.qualityOfVerticalMeasurement = EnumHelper.GetEnumValues<qualityOfVerticalMeasurement>(current.QUASOU);
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.regexTruncatedDateValidation.IsMatch(current.SORDAT)) {
                                    instance.reportedDate = current.SORDAT;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetSingleStatus(current.STATUS);
                            }

                            if (current.TECSOU != default) {
                                instance.techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues<techniqueOfVerticalMeasurement>(current.TECSOU);
                            }

                            if (current.VALSOU.HasValue && current.VALSOU.Value != -32767m) {
                                instance.valueOfSounding = current.VALSOU.Value;
                            }
                            else {
                                instance.valueOfSounding = default(decimal?);
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
                                instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(current.WATLEV.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, feature);

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
                                buffer["version"] = ImporterNIS.s101version;
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
                                instance.categoryOfWaterTurbulence = EnumHelper.GetEnumValue<categoryOfWaterTurbulence>(current.CATWAT);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: interoperabilityIdentifier

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["version"] = ImporterNIS.s101version;
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
                                instance.categoryOfWreck = EnumHelper.GetEnumValue<categoryOfWreck>(current.CATWRK.Value);
                            }

                            if (current.EXPSOU.HasValue) {
                                instance.expositionOfSounding = EnumHelper.GetEnumValue<expositionOfSounding>(current.EXPSOU.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767m) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(decimal?);
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.QUASOU != default) {
                                instance.qualityOfVerticalMeasurement = EnumHelper.GetEnumValues<qualityOfVerticalMeasurement>(current.QUASOU);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.regexTruncatedDateValidation.IsMatch(current.SORDAT)) {
                                    instance.reportedDate = current.SORDAT;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.GetValueOrDefault(), tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.TECSOU != null) {
                                instance.techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues<techniqueOfVerticalMeasurement>(current.TECSOU);
                            }

                            if (current.VALSOU.HasValue && current.VALSOU.Value != -32767m) {
                                instance.valueOfSounding = current.VALSOU.Value;
                            }
                            else {
                                instance.valueOfSounding = default(decimal?);
                            }

                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                            }

                            if (current.WATLEV.HasValue) {
                                instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(current.WATLEV);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, feature);

                            foreach (DepthsA depthArea in SpatialRelationResolver.Instance.GetSpatialRelatedValueFrom<DepthsA>(current)) {
                                var drval1 = depthArea.DRVAL1 ?? default;
                                instance.surroundingDepth = drval1;
                            }


                            buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["version"] = ImporterNIS.s101version;
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