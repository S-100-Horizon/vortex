using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_RegulatedAreasAndLimitsP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "RegulatedAreasAndLimitsP";
            var ps101 = "S-101";

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("surface"));

            using var regulatedAreasAndLimitsP = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            var subtypes = regulatedAreasAndLimitsP.GetSubtypes();
            var featureType = PrimitiveType.Point;

            int recordCount = 0;
            

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = regulatedAreasAndLimitsP.Search(filter, true);

            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;
                var current = new RegulatedAreasAndLimitsP(feature); // (Row)cursor.Current;

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;
                var verlen = current.VERLEN ?? default;

                switch (subtype) {
                    case 1: { // ACHARE_AnchorageArea
                            var instance = new AnchorageArea() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], featureType, current.PLTS_COMP_SCALE.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relations
                            
                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;
                    case 5: { // ACHBRT_AnchorBerth
                            var instance = new AnchorBerth() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], featureType, current.PLTS_COMP_SCALE.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relations
                            
                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;
                    case 10: { // CTSARE_CargoTranshipmentArea
                            var instance = new CargoTranshipmentArea() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], featureType, current.PLTS_COMP_SCALE.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relations
                            
                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;
                    case 15: { // DMPGRD_DumpingGround
                            var instance = new DumpingGround() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], featureType, current.PLTS_COMP_SCALE.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relations
                            
                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;
                    case 25: { // ICNARE_IncinerationArea
                            //The S-57 Object class ICNARE will not be converted. 
                            //https://iho.int/uploads/user/pubs/standards/s-65/S-65%20Annex%20B_Ed%201.2.0_Final.pdf
                            
                        }
                        break;
                    case 30: { // LOGPON_LogPond
                            var instance = new LogPond() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], featureType, current.PLTS_COMP_SCALE.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relations
                            
                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;
                    case 35: { // MARCUL_MarineFarmCulture
                            var instance = new MarineFarmCulture() {
                            };


                            if (current.CATMFA != null) {
                                instance.categoryOfMarineFarmCulture = EnumHelper.GetEnumValue<categoryOfMarineFarmCulture>(current.CATMFA);
                            }
                            
                            if (current.EXPSOU.HasValue) {
                                instance.expositionOfSounding = EnumHelper.GetEnumValue<expositionOfSounding>(current.EXPSOU.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);


                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: HEIGHT

                            // TODO: interoperability identifier

                            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
                            if (periodicDateRange != default) {
                                instance.periodicDateRange = periodicDateRange;
                            }

                            if (current.QUASOU != default) {
                                instance.qualityOfVerticalMeasurement = EnumHelper.GetEnumValues<qualityOfVerticalMeasurement>(current.QUASOU);
                            }

                            if (current.RESTRN != default) {
                                instance.restriction = EnumHelper.GetEnumValues<restriction>(current.RESTRN);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VALSOU.HasValue && current.VALSOU.Value != -32767) {
                                instance.valueOfSounding = current.VALSOU.Value;
                            }

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            // TODO: VerticalUncertainty

                            // TODO: VesselSpeedLimit

                            if (current.WATLEV.HasValue) {
                                instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(current.WATLEV);
                            }

                            //if (plts_comp_scale != default) {
                            //  instance.scaleMinimum = plts_comp_scale;
                            //}

                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relations
                            
                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;
                    case 40: { // SPLARE_SeaPlaneLandingArea
                            var instance = new SeaplaneLandingArea() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], featureType, current.PLTS_COMP_SCALE.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relations
                            
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




