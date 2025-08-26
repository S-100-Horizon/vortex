using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;


namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_OffshoreInstallationsP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "OffshoreInstallationsP";


            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("point"));

            using var offshoreinstallations = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(offshoreinstallations);

            int recordCount = 0;


            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = offshoreinstallations.Search(filter, true);

            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;
                var current = new OffshoreInstallationsP(feature); // (Row)cursor.Current;

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    continue;
                }

                var fcSubtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;
                var condtn = current.CONDTN ?? default;
                var verlen = current.VERLEN ?? default;

                switch (fcSubtype) {

                    case 1: { // OFSPLF_OffshorePlatform
                            var instance = new OffshorePlatform();

                            if (current.CATOFP != default) {
                                instance.categoryOfOffshorePlatform = EnumHelper.GetEnumValue<OffshorePlatform,categoryOfOffshorePlatform>(current.CATOFP);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours<OffshorePlatform>(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                            if (dateRange != default) {
                                instance.fixedDateRange = dateRange;
                            }

                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767m) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(decimal?);
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.PRODCT != null) {
                                instance.product = EnumHelper.GetEnumValues<OffshorePlatform,product>(current.PRODCT);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            }                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.VERLEN.HasValue && current.VERLEN.Value != -32767m) {
                                instance.verticalLength = current.VERLEN.Value;
                            }
                            else {
                                instance.verticalLength = default(decimal?);
                            }

                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue<OffshorePlatform,visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information,current.OBJECTID!.Value,current.TableName!,current.NTXTDS,current.TXTDSC, current.INFORM,current.NINFOM);

                            if (current.PICREP != default) {
                                instance.pictorialRepresentation = current.PICREP;
                            }
                            buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["edition"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;
                    case 5: { // PIPARE_PipelineArea
                            throw new NotImplementedException($"No PIPARE_PipelineArea in DK or GL. {tableName}");
                        }
                        break;
                    case 10: { // PIPSOL_PipelineSubmarineOnLand
                            throw new NotImplementedException($"No PIPSOL_PipelineSubmarineOnLand in DK or GL. {tableName}");


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

