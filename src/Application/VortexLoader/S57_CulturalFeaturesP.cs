using ArcGIS.Core.Data;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using ArcGIS.Core.CIM;
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
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = culturalFeaturesP.Search(filter, true);
            int recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new CulturalFeaturesP(feature);

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
                    case 1: { // AIRARE_AirportAirfield
                            var instance = new AirportAirfield() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
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
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, name, target);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 5: { // BRIDGE_Bridge
                            throw new NotImplementedException($"No BRIDGE_Bridge in DK and GL. {tableName}");

                            //var instance = new Bridge() {
                            //};
                            //if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                            //    string subtype = "";

                            //    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                            //        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                            //    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
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
                            //var featureN = featureClass.CreateRow(buffer);
                            //var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            //if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                            //    relatedEquipment?.CreateRelatedPointEquipment(current, instance, name, target);
                            //}

                            //ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            //Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 10: { // BUAARE_BuiltUpArea
                            var instance = new BuiltUpArea() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, name, target);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 15: { // BUISGL_BuildingSingle
                            var instance = new Building() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
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
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, name, target);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, featureN.GetGlobalID(), name);
                            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, name, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;

                    case 20: { // CTRPNT_ControlPoint
                            throw new NotImplementedException($"No CTRPNT_ControlPoint in DK and GL. {tableName}");

                            /*
                            4.3 Control points
                            S-57 Geo Object: Control point (CTRPNT) (P)
                            For S-101, it is considered that control point information is not required for ENC. In general, therefore,
                            encoded CTRPNT will not be converted. However, in certain circumstances where a control point may
                            be visible from seaward and therefore used as a navigational fixing mark, this information may be
                            encoded in S-101 using a Landmark feature. During the automated conversion process, the following
                            CTRPNT/CATCTR encoding instances will be converted to the corresponding Landmark/category of
                            landmark instances, along with any other common CTRPNT/Landmark attributes.
                            CATCTR = 1 (triangulation mark) -> category of landmark = 22 (triangulation mark)
                            CATCTR = 5 (boundary mark) -> category of landmark = 23 (boundary mark)
                            Data Producers are advised to evaluate their data holdings to ensure that any encoded CTRPNT
                            objects that may be used as a navigational fixing mark are encoded as CTRPNT with CATCTR = 1 or
                            5, or re-encode as a LNDMRK object, prior to conversion.
                            The following additional requirements for S-57 dataset conversion must be noted:
                            • When converting the S-57 CTRPNT Object class the S-101 mandatory attribute visual prominence
                            on the converted Landmark feature will be populated during the automated conversion process with
                            value 2 (not visually conspicuous). Data Producers will be required to amend this value as appropriate.
                             */

                            if (current.CATCTR == 1) {
                                var instance = new Landmark() {
                                };
                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                                instance.categoryOfLandmark = [categoryOfLandmark.TriangulationMark];

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
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                SetShape(buffer, current.SHAPE);
                                var featureN = featureClass.CreateRow(buffer);
                                var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                                if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                    relatedEquipment?.CreateRelatedPointEquipment(current, instance, name, target);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            }
                            else if (current.CATCTR == 5) {
                                var instance = new Landmark() {
                                };
                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                                }

                                instance.categoryOfLandmark = [categoryOfLandmark.BoundaryMark];

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
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                SetShape(buffer, current.SHAPE);
                                var featureN = featureClass.CreateRow(buffer);
                                var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                                if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                    relatedEquipment?.CreateRelatedPointEquipment(current, instance, name, target);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            }

                            else {
                                throw new Exception($"Unhandled controlpoint CATCTR {current.CATCTR}");
                            }
                        }
                        break;

                    case 25: { // DAMCON_Dam
                            throw new NotImplementedException($"DAMCON_Dam - CulturalFeaturesL. {tableName}");

                            ///*  S-65 Annex B
                            //    Point is not an allowable geometric primitive for Dam, therefore DAMCON of geometric primitive
                            //    point will convert to an instance of the S-101 Feature type Landmark (see S-101 DCEG clause 7.2).
                            //*/
                            //var instance = new Landmark();

                            //if (current.CATDAM.HasValue) {
                            //    instance.categoryOfLandmark = new() { categoryOfLandmark.Dam };
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

                            //instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            //if (current.HEIGHT.HasValue) {
                            //    instance.height = current.HEIGHT.Value;
                            //}

                            //// TODO: interoperabilityIdentifier

                            //if (current.NATCON != default) {
                            //    instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            //}

                            //if (current.CONRAD.HasValue) {
                            //    instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            //}

                            //if (current.STATUS != default) {
                            //    instance.status = GetStatus(current.STATUS);
                            //}

                            //if (current.VERLEN.HasValue) {
                            //    instance.verticalLength = current.VERLEN.Value;
                            //}

                            ///*  S-65 Annex B
                            //    When converting the S-57 DAMCON Object class of geometric primitive point the S-101 mandatory
                            //    attribute visual prominence on the converted Landmark feature will be populated during the
                            //    automated conversion process with value 2 (not visually conspicuous). Data Producers will be
                            //    required to evaluate their converted datasets and amend this value as appropriate.
                            //*/
                            //instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(2);


                            //if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                            //    string subtype = "";

                            //    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                            //        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                            //    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            //}

                            //AddInformation(instance.information, feature);

                            //buffer["ps"] = ps101;

                            //buffer["code"] = instance.GetType().Name;
                            //buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            //SetShape(buffer, current.SHAPE);
                            //var featureN = featureClass.CreateRow(buffer);
                            //var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            //if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                            //    relatedEquipment?.CreateRelatedPointEquipment(current, instance, name, target);
                            //}

                            //ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            //Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 30: { // FORSTC_FortifiedStructure
                            var instance = new FortifiedStructure() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
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
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, name, target);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 35: { // LNDMRK_Landmark
                            if (current.CATLMK == "19") {
                                var windturbine = ImporterNIS._converterRegistry.Convert<WindTurbine>(current);

                                AddInformation(windturbine.information, feature);
                                buffer["ps"] = ps101;
                                buffer["code"] = windturbine.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(windturbine, jsonSerializerOptions);
                                SetShape(buffer, current.SHAPE);

                                var windturbineFeature = featureClass.CreateRow(buffer);
                                var structureName = Convert.ToString(windturbineFeature["name"]);

                                if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                    relatedEquipment?.CreateRelatedPointEquipment(current, windturbine, structureName, target);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, structureName ?? "Unknown structure name");
                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(windturbine));
                                continue;
                            }

                            var instance = new Landmark();

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
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

                            if (current.CATLMK != default) {
                                instance.categoryOfLandmark = EnumHelper.GetEnumValues<categoryOfLandmark>(current.CATLMK);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, name, target);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 40: { // PRDARE_ProductionStorageArea
                            var instance = new ProductionStorageArea() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
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
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, name, target);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 45: { // PYLONS_PylonBridgeSupport
                            var instance = new PylonBridgeSupport() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
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
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, name, target);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 50: { // ROADWY_Road
                            throw new NotImplementedException($"No ROADWY_Road in DK or GL. {tableName}");

                            var instance = new Road() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
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
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, name, target);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 55: { // RUNWAY_Runway
                            throw new NotImplementedException($"No RUNWAY_Runway in DK or GL. {tableName}");

                            var instance = new Runway() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
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
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, name, target);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 60: { // SILTNK_SiloTank
                            var instance = new SiloTank() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
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
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, name, target);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 65: { // TUNNEL_Tunnel

                            throw new NotImplementedException($"No TUNNEL_Tunnel in DK or GL. {tableName}");

                            var instance = new Tunnel() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
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
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, name, target);
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