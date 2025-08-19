using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_CulturalFeaturesL(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "CulturalFeaturesL";

            using var culturalFeaturesL = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(culturalFeaturesL);

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("curve"));

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = culturalFeaturesL.Search(filter, true);
            int recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new CulturalFeaturesL(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;


                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    continue;
                }


                var fcSubtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;

                switch (fcSubtype) {
                    case 1: { // BRIDGE_Bridge
                            var instance = new Bridge() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
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
                                relatedEquipment?.CreateRelatedLineEquipment(current, instance, featureN);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 5: { // CBLOHD_CableOverhead
                            var instance = new CableOverhead();

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }


                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }


                            instance.verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT ?? 3);


                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

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
                                relatedEquipment?.CreateRelatedLineEquipment(current, instance, featureN);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 10: { // CONVYR_Conveyor
                            var instance = new Conveyor();

                            if (current.CATCON.HasValue) {
                                instance.categoryOfConveyor = EnumHelper.GetEnumValue<categoryOfConveyor>(current.CATCON.Value);
                            }
                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767m) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(decimal?);
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.LIFCAP.HasValue) {
                                instance.liftingCapacity = current.LIFCAP.Value;
                            }

                            //TODO: multiplicityOfFeatures

                            if (current.PRODCT != null) {
                                instance.product = EnumHelper.GetEnumValues<product>(current.PRODCT);
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


                            instance.verticalClearanceFixed = new() {
                                verticalUncertainty = new() {
                                    uncertaintyFixed = current.VERACC.HasValue && current.VERACC.Value != -32767m ? current.VERACC.Value : default(decimal?),
                                    uncertaintyVariableFactor = default(decimal?)
                                },
                                //verticalClearanceValue = current.VERCOP.HasValue && current.VERCOP.Value != -32767m ? current.VERCOP.Value : default(decimal?),
                                verticalClearanceValue = current.VERCLR.HasValue && current.VERCLR.Value != -32767m ? current.VERCLR.Value : default(decimal?),
                            };


                            instance.verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT ?? 3);

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["version"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedLineEquipment(current, instance, featureN);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 15: { // DAMCON_Dam
                            var instance = new Dam();

                            if (current.CATDAM.HasValue) {
                                instance.categoryOfDam = EnumHelper.GetEnumValue<categoryOfDam>(current.CATDAM.Value);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }                            
                           if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767m) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(decimal?);
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
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

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
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

                    case 20: { // FNCLNE_FenceWall
                            throw new NotImplementedException($"No FNCLNE_FenceWall in DK | GL. {tableName}");
                            //var instance = new FenceWall() {
                            //};
                            //if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                            //    string subtype = "";

                            //    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                            //        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                            //    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            //}


                            //if (current.COLOUR != default) {
                            //    instance.colour = GetColours(current.COLOUR);
                            //}

                            //if (current.COLPAT != default) {
                            //    instance.colourPattern = GetColourPattern(current.COLPAT);
                            //}

                            //if (current.CONDTN.HasValue) {
                            //    instance.condition = GetCondition(current.CONDTN.Value);
                            //}

                            //if (current.STATUS != default) {
                            //    instance.status = GetStatus(current.STATUS);
                            //}

                            //instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            //AddInformation(instance.information, feature);
                            //buffer["ps"] = ps101;

                            //buffer["code"] = instance.GetType().Name;
                            //buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            //SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);
                            //var featureN = featureClass.CreateRow(buffer);
                            //var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            //if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                            //    relatedEquipment?.CreateRelatedLineEquipment(current, instance, featureN);
                            //}

                            //ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            //Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 25: { // FORSTC_FortifiedStructure
                            var instance = new FortifiedStructure();

                            if (current.CATFOR.HasValue) {
                                instance.categoryOfFortifiedStructure = EnumHelper.GetEnumValue<categoryOfFortifiedStructure>(current.CATFOR.Value);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767m) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(decimal?);
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
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

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, feature);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }

                            //TODO: inTheWater
                            buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["version"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedLineEquipment(current, instance, featureN);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 30: { // LNDMRK_Landmark
                            throw new NotImplementedException($"No LNDMRK_Landmark in DK | GL. {tableName}");
                        }
                        break;

                    case 35: { // PIPOHD_PipelineOverhead
                            var instance = new PipelineOverhead();
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            instance.verticalDatum = ImporterNIS.GetVerticalDatum(current.VERDAT ?? 3);

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
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
                                relatedEquipment?.CreateRelatedLineEquipment(current, instance, featureN);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 40: { // RAILWY_Railway
                            var instance = new Railway() {
                            };

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }


                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
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
                                relatedEquipment?.CreateRelatedLineEquipment(current, instance, featureN);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 45: { // ROADWY_Road
                            var instance = new Road();

                            if (current.CATROD.HasValue) {
                                instance.categoryOfRoad = EnumHelper.GetEnumValue<categoryOfRoad>(current.CATROD.Value);
                            }


                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: interoperabilityIdentifier

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
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
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedLineEquipment(current, instance, featureN);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 50: { // RUNWAY_Runway
                            throw new NotImplementedException($"No RUNWAY_Runway in DK and GL. {tableName}");
                            //var instance = new Runway() {
                            //};
                            //if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                            //    string subtype = "";

                            //    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                            //        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                            //    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            //}


                            //if (current.CONDTN.HasValue) {
                            //    instance.condition = GetCondition(current.CONDTN.Value);
                            //}

                            //if (current.STATUS != default) {
                            //    instance.status = GetStatus(current.STATUS);
                            //}

                            //instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            //AddInformation(instance.information, feature);
                            //buffer["ps"] = ps101;

                            //buffer["code"] = instance.GetType().Name;
                            //buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            //SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);
                            //var featureN = featureClass.CreateRow(buffer);
                            //var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            //if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                            //    relatedEquipment?.CreateRelatedLineEquipment(current, instance, featureN);
                            //}

                            //ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            //Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 55: { // TUNNEL_Tunnel
                            throw new NotImplementedException($"No TUNNEL_Tunnel in DK and GL. {tableName}");
                            //var instance = new Tunnel() {
                            //};
                            //if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                            //    string subtype = "";

                            //    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                            //        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                            //    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            //}

                            //if (current.CONDTN.HasValue) {
                            //    instance.condition = GetCondition(current.CONDTN.Value);
                            //}

                            //if (current.STATUS != default) {
                            //    instance.status = GetStatus(current.STATUS);
                            //}

                            //instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            //AddInformation(instance.information, feature);
                            //buffer["ps"] = ps101;

                            //buffer["code"] = instance.GetType().Name;
                            //buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            //SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);
                            //var featureN = featureClass.CreateRow(buffer);
                            //var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            //if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                            //    relatedEquipment?.CreateRelatedLineEquipment(current, instance, featureN);
                            //}

                            //ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            //Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
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