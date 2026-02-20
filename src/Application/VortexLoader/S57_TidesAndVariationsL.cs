using ArcGIS.Core.Data;
using S100FC;
using S100FC.S101.FeatureTypes;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_TidesAndVariationsL(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "TidesAndVariationsL";

            using var TidesAndVariationsL = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(TidesAndVariationsL);

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("curve"));


            using var buffer = featureClass.CreateRowBuffer();

            using var cursor = TidesAndVariationsL.Search(filter, true);
            int recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new TidesAndVariationsL(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (FeatureRelations.Instance.IsSlave(globalid)) {
                    continue;
                }

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    throw new Exception("Ups. Not supported");
                }

                var fcSubtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;

                switch (fcSubtype) {
                    case 5: { // LOCMAG_LocalMagneticAnomaly
                            throw new NotImplementedException("No MAGVAR_MagneticVariation in DK | GL NIS");
                        }
                    case 10: { // MAGVAR_MagneticVariation
                            throw new NotImplementedException("No MAGVAR_MagneticVariation in DK | GL NIS");
                        }
                    case 15: { // TIDEWY_Tideway
                            var instance = new Tideway();

                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            // TODO: interoperabilityIdentifier

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                var scamin = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                if (scamin.HasValue)
                                    instance.scaleMinimum = scamin.Value;
                            }

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();
                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedLineEquipment(current, instance, featureN);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));


                        }
                        break;
                    default:
                        // code block
                        System.Diagnostics.Debugger.Break();
                        break;
                }
                Logger.Current.DataTotalCount(tableName, recordCount, ConversionAnalytics.Instance.GetConvertedCount(tableName));
            }


        }
    }
}
