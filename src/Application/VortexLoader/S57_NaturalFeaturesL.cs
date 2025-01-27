using ArcGIS.Core.Data;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using VortexLoader.S57.esri;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_NaturalFeaturesL(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "NaturalFeaturesL";

            using var s = source.OpenDataset<FeatureClass>(tableName);
            using var featureclass = target.OpenDataset<FeatureClass>("curve");

            using var buffer = featureclass.CreateRowBuffer();
            using var insert = featureclass.CreateInsertCursor();

            using var cursor = s.Search(filter, true);

            var convertedCount = 0;
            var recordCount = 0;


            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;
                var current = new NaturalFeaturesL(feature);

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
                            var instance = new LandArea {
                                condition = null,
                                status = null,
                                scaleMinimum = null,
                            };
                            if (condtn != default) {
                                instance.condition = condtn switch {
                                    1 => condition.UnderConstruction,   //  under construction
                                    2 => condition.Ruined,   //  ruined
                                    3 => condition.UnderReclamation,   //  under reclamation                                    
                                    4 => throw new IndexOutOfRangeException(),   //  wingless
                                    5 => throw new IndexOutOfRangeException(),   //  planned construction
                                    -32767 => null,
                                    _ => throw new IndexOutOfRangeException(),
                                };
                            }
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);

                            buffer["ps"] = "S-101";
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 5: { // LNDELV_LandElevation
                            var instance = new LandElevation {
                                scaleMinimum = null,
                            };

                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);

                            buffer["ps"] = "S-101";
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 10: { // RAPIDS_Rapids
                            var instance = new Rapids {
                                
                            };
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);

                            buffer["ps"] = "S-101";
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++; 
                        }
                        break;
                    case 15: { // RIVERS_River
                            var instance = new River {
                                
                            };
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);

                            buffer["ps"] = "S-101";
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++; 
                        }
                        break;
                    case 20: { // SLOTOP_SlopeTopline
                            var instance = new SlopeTopline {

                            };
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);

                            buffer["ps"] = "S-101";
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++; 
                        }
                        break;
                    case 25: { // VEGATN_Vegetation
                            var instance = new Vegetation {

                            };
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);

                            buffer["ps"] = "S-101";
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++; 
                        }
                        break;
                    case 30: { // WATFAL_Waterfall
                            var instance = new Waterfall {

                            };
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);

                            buffer["ps"] = "S-101";
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
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
