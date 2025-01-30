using ArcGIS.Core.Data;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using VortexLoader.S57.esri;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_OffshoreInstallationsL(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "OffshoreInstallationsL";
            

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

                            // The S-57 attributes DRVAL1 and DRVAL2 for CBLSUB will not be converted. It is considered that
                            // these attributes are not relevant for Cable Submarine in S - 101.

                            var instance = new CableSubmarine();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            /* S57
                             * Code	Description
                                1	power line
                                3	transmission line
                                4	telephone
                                5	telegraph
                                6	mooring cable/chain
                                -32767	Unknown
                             */


                            if (current.CATCBL != default) {
                                instance.categoryOfCable = current.CATCBL switch {
                                    1 => categoryOfCable.PowerLine,
                                    3 => categoryOfCable.TransmissionLine,
                                    4 => categoryOfCable.TelecommunicationsCable, //CATCBL value 4 (telephone) will convert to category of cable value 10 (telecommunications cable).
                                    5 => categoryOfCable.MooringCable,
                                    -32767 => null,
                                    _ => throw new IndexOutOfRangeException(),
                                };
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
                    case 5: { // PIPSOL_PipelineSubmarineOnLand
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
                }



            }
            Logger.Current.DataTotalCount(tableName, recordCount, convertedCount);
        }
    }
}

