using ArcGIS.Core.Data;

using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using ArcGIS.Core.Data.UtilityNetwork.Trace;
using S100Framework.DomainModel.S101.ComplexAttributes;
using Serilog;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using S100Framework.Applications.S57.esri;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_MilitaryFeaturesP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "MilitaryFeaturesP";

            var coastlinea = source.OpenDataset<FeatureClass>(tableName);

            using var featureClass = target.OpenDataset<FeatureClass>(LayerDefinitions.GetName("point"));


            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = coastlinea.Search(filter, true);
            int recordCount = 0;
            int convertedCount = 0;
            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new MilitaryFeaturesP(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;

                switch (subtype) {

                    case 30: { // MIPARE_MilitaryPracticeArea
                            var instance = new MilitaryPracticeArea() {
                            };
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }


                            AddStatus(instance.status, feature);
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
