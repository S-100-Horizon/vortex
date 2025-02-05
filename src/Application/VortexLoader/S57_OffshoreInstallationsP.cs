using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using System.Reflection.Emit;


namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_OffshoreInstallationsP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "OffshoreInstallationsP";
            

            using var featureclass = target.OpenDataset<FeatureClass>(LayerDefinitions.GetName("point"));

            using var offshoreinstallations = source.OpenDataset<FeatureClass>(tableName);

            int recordCount = 0;
            int convertedCount = 0;

            using var buffer = featureclass.CreateRowBuffer();
            using var insert = featureclass.CreateInsertCursor();

            using var cursor = offshoreinstallations.Search(filter, true);

            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;
                var current = new OffshoreInstallationsP(feature); // (Row)cursor.Current;

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;
                var condtn = current.CONDTN ?? default;
                var verlen = current.VERLEN ?? default;

                switch (subtype) {

                    case 1: { // OFSPLF_OffshorePlatform
                            var instance = new OffshorePlatform();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

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
                    case 5: { // PIPARE_PipelineArea
                            var instance = new SubmarinePipelineArea();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

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
                    case 10: { // PIPSOL_PipelineSubmarineOnLand
                            var instance = new PipelineSubmarineOnLand();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

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

