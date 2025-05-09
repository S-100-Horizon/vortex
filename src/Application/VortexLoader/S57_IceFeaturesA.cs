using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_IcefeaturesA(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "IcefeaturesA";

            using var icefeaturesa = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            var subtypes = icefeaturesa.GetSubtypes();
            var featureType = PrimitiveType.Area;

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("surface"));


            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = icefeaturesa.Search(filter, true);
            int recordCount = 0;
            
            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new IceFeaturesA(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    continue;
                }

                var subtype = current.FCSUBTYPE ?? default;
                
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;

                switch (subtype) {
                    case 15: { // ICEARE_IceArea
                            var instance = new IceArea() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], current.PLTS_COMP_SCALE.Value);
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
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

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
