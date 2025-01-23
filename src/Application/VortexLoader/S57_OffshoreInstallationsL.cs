using ArcGIS.Core.Data;
using S100Framework.DomainModel.S101.FeatureTypes;
using VortexLoader.S57.esri;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_OffshoreInstallationsL(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "OffshoreInstallationsL";
            var ps = "S-101";

            using var featureclass = target.OpenDataset<FeatureClass>("curve");

            using var offshoreinstallations = source.OpenDataset<FeatureClass>(tableName);

            int recordCount = 0;
            int convertedCount = 0;

            using var buffer = featureclass.CreateRowBuffer();
            using var insert = featureclass.CreateInsertCursor();

            using var cursor = offshoreinstallations.Search(filter, true);

            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;
                var current = new OffshoreInstallationsL(feature); // (Row)cursor.Current;

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;
                var condtn = current.CONDTN ?? default;
                var verlen = current.VERLEN ?? default;

                switch (subtype) {
                    case 1: { // CBLSUB_CableSubmarine
                            var instance = new CableSubmarine();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 5: { // PIPSOL_PipelineSubmarineOnLand
                            var instance = new PipelineSubmarineOnLand();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                        }
                        break;
                }



            }
            Logger.Current.DataTotalCount(tableName, recordCount, convertedCount);
        }
    }
}

