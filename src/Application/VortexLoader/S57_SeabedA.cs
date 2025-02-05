using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_SeabedA(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "SeabedA";

            var ps101 = "S-101";

            var seabedA = source.OpenDataset<FeatureClass>(tableName);

            using var featureClass = target.OpenDataset<FeatureClass>(LayerDefinitions.GetName("surface"));
            

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = seabedA.Search(filter, true);
            int recordCount = 0;
            int convertedCount = 0;
            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new SeabedA(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;
                var watlev = current.WATLEV ?? default;

                var natsur = current.NATSUR ?? default;
                var natqua = current.NATQUA ?? default; 

                // TODO: natsur, natqua


                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;



                switch (subtype) {
                    case 15: { // SBDARE_SeabedArea
                            var instance = new SeabedArea() {
                            };
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 30: { // SNDWAV_SandWaves
                            var instance = new Sandwave() {
                            };
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 40: { // WEDKLP_WeedKelp
                            var instance = new WeedKelp() {
                            };
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
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
