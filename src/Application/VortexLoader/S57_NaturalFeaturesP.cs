using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;


namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_NaturalFeaturesP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "NaturalFeaturesP";

            using var naturalFeaturesP = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            var subtypes = naturalFeaturesP.GetSubtypes();
            var featureType = PrimitiveType.Point;

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("point"));

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = naturalFeaturesP.Search(filter, true);

            
            var recordCount = 0;


            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;
                var current = new NaturalFeaturesP(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;
                var condtn = current.CONDTN ?? default;
                var natsur = current.NATSUR ?? default;
                var catslo = current.CATSLO ?? default;
                var colour = current.COLOUR ?? default;
                var conrad = current.CONRAD ?? default;
                var convis = current.CONVIS ?? default;
                var catveg = current.CATVEG ?? default;
                var elevat = current.ELEVAT ?? default;
                var height = current.HEIGHT ?? default;
                var verlen = current.VERLEN ?? default;

                switch (subtype) {
                    case 1: { // LNDARE_LandArea
                            var instance = new LandArea();
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], featureType, current.PLTS_COMP_SCALE.Value);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetSingleStatus(current.STATUS);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedEquipment(current, instance, name, target);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;
                    case 5: { // LNDELV_LandElevation
                            var instance = new LandElevation();

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], featureType, current.PLTS_COMP_SCALE.Value);
                            }


                            if (current.ELEVAT != default) {
                                instance.elevation = current.ELEVAT ?? default;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedEquipment(current, instance, name, target);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;
                    case 10: { // LNDRGN_LandRegion
                            var instance = new LandRegion() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], featureType, current.PLTS_COMP_SCALE.Value);
                            }


                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedEquipment(current, instance, name, target);
                            }


                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;
                    case 15: { // RAPIDS_Rapids
                            var instance = new Rapids() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], featureType, current.PLTS_COMP_SCALE.Value);
                            }


                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedEquipment(current, instance, name, target);
                            }


                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;
                    case 20: { // SEAARE_SeaAreaNamedWaterArea
                            var instance = new SeaAreaNamedWaterArea() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], featureType, current.PLTS_COMP_SCALE.Value);
                            }

                            if (current.CATSEA.HasValue) {
                                instance.categoryOfSeaArea = EnumHelper.GetEnumValue<categoryOfSeaArea>(current.CATSEA.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedEquipment(current, instance, name, target);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;
                    case 25: { // SLOGRD_SlopingGround
                            var instance = new SlopingGround() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], featureType, current.PLTS_COMP_SCALE.Value);
                            }

                            if (current.CATSLO.HasValue) {
                                instance.categoryOfSlope = EnumHelper.GetEnumValue<categoryOfSlope>(current.CATSLO.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            
                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedEquipment(current, instance, name, target);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;
                    case 30: { // VEGATN_Vegetation
                            var instance = new Vegetation() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], featureType, current.PLTS_COMP_SCALE.Value);
                            }

                            if (current.CATVEG != default) {
                                instance.categoryOfVegetation = EnumHelper.GetEnumValue<categoryOfVegetation>(current.CATVEG);
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            AddInformation(instance.information, feature);
                            
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            
                            SetShape(buffer,current.SHAPE);
                            
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedEquipment(current, instance, name, target);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;
                    case 35: { // WATFAL_Waterfall
                            var instance = new Waterfall() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], featureType, current.PLTS_COMP_SCALE.Value);
                            }

                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedEquipment(current, instance, name, target);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

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
