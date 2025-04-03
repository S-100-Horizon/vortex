using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_DangersA(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "DangersA";

            var dangersa = source.OpenDataset<FeatureClass>(source.GetName(tableName));

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("surface"));

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = dangersa.Search(filter, true);
            int recordCount = 0;
            int convertedCount = 0;
            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new DangersA(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;

                var valsou = current.VALSOU ?? default;
                var watlev = current.WATLEV ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;

                bool isValsouEmpty = !current.VALSOU.HasValue;

                // The attribute default clearance depth must be populated with a value, which must not be an empty(null)
                // value, only if the attribute value of sounding for the feature instance is populated with an empty(null) value
                // and the attribute height, if an allowable attribute for the feature, is not populated.
                // S-101 Annex A_DCEG Edition 1.5.0_Draft for Edition 2.0.0.pdf: p.771
                //Decimal defaultClearanceDepth = -1;

                switch (subtype) {
                    case 1: { // CTNARE_CautionArea
                            var instance = new CautionArea {

                            };
                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetSingleStatus(current.STATUS);
                            }
                            //instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            insert.Insert(buffer);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;


                        }
                        break;
                    case 10: { // FSHFAC_FishingFacility
                            var instance = new FishingFacility {

                            };
                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
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
                            SetShape(buffer,current.SHAPE);
                            insert.Insert(buffer);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 15: { // OBSTRN_Obstruction
                            //current.SOUACC
                            // DAM
                            if (current.INFORM?.Trim()?.ToLower() == "submerged weir") {
                                var instance = new Dam();
                                if (current.STATUS != default) {
                                    instance.status = GetStatus(current.STATUS);
                                }

                                if (current.PLTS_COMP_SCALE.HasValue)
                                    instance.scaleMinimum = current.PLTS_COMP_SCALE;

                                instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                                AddInformation(instance.information, feature);
                                buffer["ps"] = ps101;

                                buffer["code"] = instance.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                                ImporterNIS.SetShape(buffer, current.SHAPE);
                                insert.Insert(buffer);
                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                                convertedCount++;
                                break;
                            }
                            else if (current.CATOBS == 7) {
                                // Foul ground
                                var instance = new FoulGround();

                                //instance.verticalUncertainty = 
                                if (current.STATUS != default) {
                                    instance.status = GetStatus(current.STATUS);
                                }

                                if (current.PLTS_COMP_SCALE.HasValue)
                                    instance.scaleMinimum = current.PLTS_COMP_SCALE;

                                instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                                AddInformation(instance.information, feature);
                                buffer["ps"] = ps101;

                                buffer["code"] = instance.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                                ImporterNIS.SetShape(buffer, current.SHAPE);
                                insert.Insert(buffer);
                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                                convertedCount++;
                                break;
                            }
                            else {
                                var instance = new Obstruction();

                                if (plts_comp_scale != default) {
                                    //instance.scaleMinimum = plts_comp_scale;
                                }

                                if (current.WATLEV.HasValue) {
                                    if (current.WATLEV.Value == -32767)
                                        instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(-1);
                                    else {
                                        instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(current.WATLEV);
                                    }
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
                                SetShape(buffer,current.SHAPE);
                                insert.Insert(buffer);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                                convertedCount++;
                            }
                        }
                        break;
                    case 20: { // WATTUR_WaterTurbulence
                            var instance = new WaterTurbulence {

                            };
                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            if (current.CATWAT.HasValue) {
                                if (current.CATWAT.Value == -32767)
                                    instance.categoryOfWaterTurbulence = EnumHelper.GetEnumValue<categoryOfWaterTurbulence>(-1);
                                else {
                                    instance.categoryOfWaterTurbulence = EnumHelper.GetEnumValue<categoryOfWaterTurbulence>(current.CATWAT);
                                }
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            insert.Insert(buffer);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                        }
                        break;
                    case 25: { // WRECKS_Wreck
                            var instance = new Wreck {

                            };
                            if (plts_comp_scale != default) {
                                //instance.scaleMinimum = plts_comp_scale;
                            }

                            if (current.CATWRK.HasValue) {
                                if (current.CATWRK.Value == -32767)
                                    instance.categoryOfWreck = EnumHelper.GetEnumValue<categoryOfWreck>(-1);
                                else {
                                    instance.categoryOfWreck = EnumHelper.GetEnumValue<categoryOfWreck>(current.CATWRK.Value);
                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.WATLEV.HasValue) {
                                if (current.WATLEV.Value == -32767)
                                    instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(-1);
                                else {
                                    instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(current.WATLEV);
                                }
                            }


                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            insert.Insert(buffer);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                        }
                        break;
                    default:
                        // code block
                        System.Diagnostics.Debugger.Break();
                        break;
                }



            }
            Logger.Current.DataTotalCount(tableName, recordCount, convertedCount);
        }


    }
}
