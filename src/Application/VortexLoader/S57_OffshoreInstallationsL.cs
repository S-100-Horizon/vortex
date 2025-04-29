using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_OffshoreInstallationsL(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "OffshoreInstallationsL";
            

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("curve"));

            using var offshoreinstallations = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            var subtypes = offshoreinstallations.GetSubtypes();
            var featureType = PrimitiveType.Line;

            int recordCount = 0;
            

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

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

                            // The S-57 attributes DRVAL1 and DRVAL2 for CBLSUB will not be converted. It is considered that
                            // these attributes are not relevant for Cable Submarine in S - 101.

                            var instance = new CableSubmarine();
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], featureType, current.PLTS_COMP_SCALE.Value);
                            }

                            if (current.BURDEP.HasValue) {
                                instance.buriedDepth = current.BURDEP.Value;
                            }

                            if (current.CATCBL.HasValue) {
                                if (current.CATCBL.Value == 4) { // TODO: handle cable _s101type == 4
                                    continue;
                                }

                                instance.categoryOfCable = EnumHelper.GetEnumValue<categoryOfCable>(current.CATCBL.Value);
                            };

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);


                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], featureType, current.PLTS_COMP_SCALE.Value);
                            }

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
                    case 5: { // PIPSOL_PipelineSubmarineOnLand
                            var instance = new PipelineSubmarineOnLand();
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], featureType, current.PLTS_COMP_SCALE.Value);
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
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            // TODO: Create relations
                            
                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            

                        }
                        break;
                }



            }
            Logger.Current.DataTotalCount(tableName, recordCount, ConversionAnalytics.Instance.GetConvertedCount(tableName));
        }
    }
}

