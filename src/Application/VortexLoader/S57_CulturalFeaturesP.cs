using ArcGIS.Core.Data;
using S100FC.S101.FeatureTypes;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_CulturalFeaturesP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "CulturalFeaturesP";

            using var culturalFeaturesP = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(culturalFeaturesP);

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("point"));

            using var buffer = featureClass.CreateRowBuffer();

            using var cursor = culturalFeaturesP.Search(filter, true);
            int recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new CulturalFeaturesP(feature);

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
                    case 1: { // AIRARE_AirportAirfield
                            var instance = new AirportAirfield();

                            if (current.CATAIR != default) {
                                var categoryOfAirportAirfield = EnumHelper.GetEnumValues(current.CATAIR);
                                if (categoryOfAirportAirfield is not null && categoryOfAirportAirfield.Any())
                                    instance.categoryOfAirportAirfield = categoryOfAirportAirfield;
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: interoperabilityIdentifier
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

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
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

                    case 5: { // BRIDGE_Bridge
                            throw new NotImplementedException($"No BRIDGE_Bridge in DK and GL. {tableName}");
                        }
                    case 10: { // BUAARE_BuiltUpArea
                            var instance = new BuiltUpArea();
                            if (current.CATBUA.HasValue) {
                                instance.categoryOfBuiltUpArea = EnumHelper.GetEnumValue(current.CATBUA.Value);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {

                            }

                            // TODO: interoperabilityIdentifier

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

                            if (current.CONVIS.HasValue /*&& current.CONVIS.Value != -32767*/) {
                                instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            /*
                                S - 101 includes the system attribute in the water to indicate that a building that is located offshore is to
                                be included in ECDIS Base display.This attribute is populated automatically during the conversion
                                process based on the underlying Skin of the Earth feature.As such, there is no requirement to include
                                an ECDIS Base display feature coincident with the S - 101 Building feature so as to ensure display of a
                                feature at the position of the building in ECDIS Base display.Data Producers should consider removing
                                these features from their S-101 data during the conversion process.
                            */
                            instance.inTheWater = LandAreas.Instance.Touch(current!.SHAPE!).Count() > 0;


                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
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

                    case 15: { // BUISGL_BuildingSingle
                            var instance = new Building();

                            if (current.BUISHP != null) {
                                instance.buildingShape = EnumHelper.GetEnumValue(current.BUISHP);
                            }

                            if (current.COLOUR != default) {
                                var colour = GetColours(current.COLOUR);
                                if (colour is not null && colour.Any())
                                    instance.colour = colour;
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT)!.value;
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.FUNCTN != default) {
                                var function = EnumHelper.GetEnumValues(current.FUNCTN);
                                if (function is not null && function.Any())
                                    instance.function = function;
                            }
                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {

                            }

                            // TODO: interoperabilityIdentifier

                            // TODO: multiplicity of features

                            if (current.NATCON != default) {
                                var natureOfConstruction = EnumHelper.GetEnumValues(current.NATCON);
                                if (natureOfConstruction is not null && natureOfConstruction.Any())
                                    instance.natureOfConstruction = natureOfConstruction;
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

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue /*&& current.CONVIS.Value != -32767*/) {
                                instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            instance.inTheWater = LandAreas.Instance.Touch(current!.SHAPE!).Count() > 0;


                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID(), name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;

                    case 20: { // CTRPNT_ControlPoint
                            if (current.CATCTR.HasValue && (current.CATCTR == 1 || current.CATCTR == 5)) {
                                var instance = new Landmark {
                                };
                                var categoryOfLandmark = EnumHelper.GetEnumValues(current.CATCTR);
                                if (categoryOfLandmark is not null)
                                    instance.categoryOfLandmark = categoryOfLandmark;
                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                }

                                var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                                instance.information = result.information.ToArray();
                                instance.SetInformationBindings(result.InformationBindings.ToArray());

                                if (current.PICREP != default) {
                                    instance.pictorialRepresentation = FixFilename(current.PICREP);
                                }

                                instance.inTheWater = LandAreas.Instance.Touch(current!.SHAPE!).Count() > 0;


                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["edition"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = featureN.UID();

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID(), name);
                                Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                            }
                            else
                                throw new NotImplementedException($"No CTRPNT_ControlPoint in DK and GL. {tableName}");
                        }
                        break;
                    case 25: { // DAMCON_Dam
                            throw new NotImplementedException($"DAMCON_Dam - CulturalFeaturesL. {tableName}");
                        }
                    case 30: { // FORSTC_FortifiedStructure
                            var instance = new FortifiedStructure() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
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

                    case 35: { // LNDMRK_Landmark
                            if (current.CATLMK == "19") {
                                var windturbine = ImporterNIS._converterRegistry.Convert<WindTurbine>(current);

                                buffer["ps"] = ps101;
                                buffer["code"] = windturbine.GetType().Name;
                                buffer["edition"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(windturbine, jsonSerializerOptions);
                                buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(windturbine.GetInformationBindings(), ImporterNIS.jsonSerializerOptions);

                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var windturbineFeature = featureClass.CreateRow(buffer);
                                var structureName = windturbineFeature.UID();

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment?.CreateRelatedPointEquipment(current, windturbine, windturbineFeature, windturbine.scaleMinimum);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, structureName ?? "Unknown structure name");
                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(windturbine, ImporterNIS.jsonSerializerOptions));
                                continue;
                            }

                            var instance = new Landmark {
                                visualProminence = default,
                            };

                            if (current.CATLMK != default) {
                                var categoryOfLandmark = EnumHelper.GetEnumValues(current.CATLMK);
                                if (categoryOfLandmark is not null)
                                    instance.categoryOfLandmark = categoryOfLandmark;
                            }

                            // TODO: CATSPM

                            if (current.COLOUR != default) {
                                var colour = GetColours(current.COLOUR);
                                if (colour is not null && colour.Any())
                                    instance.colour = colour;
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT)!.value;
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.FUNCTN != null) {
                                var function = EnumHelper.GetEnumValues(current.FUNCTN);
                                if (function is not null && function.Any())
                                    instance.function = function;
                            }

                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {

                            }

                            // TODO: interoperabilityIdentifier

                            // TODO: multiplicityOfFeatures

                            if (current.NATCON != default) {
                                var parts = current.NATCON.Split([',', ';'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                                foreach (var p in parts) {
                                    if (int.TryParse(p, out int value)) {
                                        var natcon = value switch {
                                            1 => 1, //natureOfConstruction.Masonry,
                                            2 => 2, //natureOfConstruction.Concreted,
                                            3 => 3, //natureOfConstruction.LooseBoulders,
                                            6 => 6, //natureOfConstruction.Wooden,
                                            7 => 7, //natureOfConstruction.Metal,
                                            8 => 8, //natureOfConstruction.GlassReinforcedPlastic,
                                            11 => 11,   //natureOfConstruction.Latticed,
                                            12 => 12,   //natureOfConstruction.Glass,
                                            -32767 => default,  //  Not supported in array
                                            _ => default,
                                        };
                                        if (natcon != default)
                                            instance.natureOfConstruction = [natcon];  //  append
                                    }
                                }
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

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            instance.inTheWater = LandAreas.Instance.Touch(current!.SHAPE!).Count() > 0;


                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
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

                    case 40: { // PRDARE_ProductionStorageArea
                            var instance = new ProductionStorageArea {
                                categoryOfProductionArea = default,
                            };

                            if (current.CATPRA.HasValue) {
                                instance.categoryOfProductionArea = EnumHelper.GetEnumValue(current.CATPRA.Value);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {

                            }

                            // TODO: interoperabilityIdentifier

                            if (current.PRODCT != null) {
                                var product = EnumHelper.GetEnumValues(current.PRODCT);
                                if (product is not null && product.Any())
                                    instance.product = product;
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

                            if (current.VERLEN.HasValue && current.VERLEN.Value != -32767d) {
                                instance.verticalLength = current.VERLEN.Value;
                            }
                            else {
                                //instance.verticalLength = default(double?);
                            }

                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
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

                    case 45: { // PYLONS_PylonBridgeSupport

                            var instance = new PylonBridgeSupport {
                                categoryOfPylon = default,
                            };

                            if (current.COLOUR != default) {
                                var colour = GetColours(current.COLOUR);
                                if (colour is not null && colour.Any())
                                    instance.colour = colour;
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT)!.value;
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {

                            }

                            // TODO: interoperabilityIdentifier

                            // TODO: multiplicityOfFeatures

                            if (current.NATCON != default) {
                                var natureOfConstruction = EnumHelper.GetEnumValues(current.NATCON);
                                if (natureOfConstruction is not null && natureOfConstruction.Any())
                                    instance.natureOfConstruction = natureOfConstruction;
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

                            if (current.VERLEN.HasValue && current.VERLEN.Value != -32767d) {
                                instance.verticalLength = current.VERLEN.Value;
                            }
                            else {
                                //instance.verticalLength = default(double?);
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
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            //if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                            //    relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            //}
                            //Bridges.Instance.AddRelation(relatedBridge.Name, name, typeof(Pylo));

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;

                    case 50: { // ROADWY_Road
                            throw new NotImplementedException($"No ROADWY_Road in DK or GL. {tableName}");
                        }
                    case 55: { // RUNWAY_Runway
                            throw new NotImplementedException($"No RUNWAY_Runway in DK or GL. {tableName}");
                        }
                    case 60: { // SILTNK_SiloTank
                            var instance = new SiloTank();

                            if (current.BUISHP.HasValue) {
                                instance.buildingShape = EnumHelper.GetEnumValue(current.BUISHP.Value);
                            }

                            if (current.CATSIL.HasValue) {
                                instance.categoryOfSiloTank = EnumHelper.GetEnumValue(current.CATSIL.Value);
                            }

                            if (current.COLOUR != default) {
                                var colour = GetColours(current.COLOUR);
                                if (colour is not null && colour.Any())
                                    instance.colour = colour;
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT)!.value;
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value)?.value;
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);


                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {

                            }

                            // TODO: interoperabilityIdentifier

                            // TODO: multiplicityOfFeatures

                            if (current.NATCON != default) {
                                var natureOfConstruction = EnumHelper.GetEnumValues(current.NATCON);
                                if (natureOfConstruction is not null && natureOfConstruction.Any())
                                    instance.natureOfConstruction = natureOfConstruction;
                            }

                            if (current.PRODCT != null) {
                                var product = EnumHelper.GetEnumValues(current.PRODCT);
                                if (product is not null && product.Any())
                                    instance.product = product;
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

                            if (current.VERLEN.HasValue && current.VERLEN.Value != -32767d) {
                                instance.verticalLength = current.VERLEN.Value;
                            }
                            else {
                                //instance.verticalLength = default(double?);
                            }

                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = FixFilename(current.PICREP);
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
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

                    case 65: { // TUNNEL_Tunnel
                            throw new NotImplementedException($"No TUNNEL_Tunnel in DK or GL. {tableName}");
                        }

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