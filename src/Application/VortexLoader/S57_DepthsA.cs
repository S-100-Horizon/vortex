using ArcGIS.Core.Data;
using S100FC;
using S100FC.S101.FeatureTypes;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_DepthsA(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "DepthsA";

            using var depthsA = source.OpenDataset<FeatureClass>(source.GetName("DepthsA"));
            var subtypes = depthsA.GetSubtypes();

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("surface"));

            using var buffer = featureClass.CreateRowBuffer();

            using var cursor = depthsA.Search(filter, true);

            var recordCount = 0;


            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;
                var current = new DepthsA(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (FeatureRelations.Instance.IsSlave(globalid)) {
                    continue;
                }

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    throw new Exception("Ups. Not supported");
                }




                var fcSubtype = current.FCSUBTYPE ?? default;

                var drval1 = current.DRVAL1 ?? default;
                var drval2 = current.DRVAL2 ?? default(decimal?);
                var sordat = current.SORDAT ?? default;

                var longname = current.LNAM ?? Strings.UNKNOWN;
                var restrn = current.RESTRN ?? default;
                var quasou = current.QUASOU ?? default;
                var tecsou = current.TECSOU ?? default;

                switch (fcSubtype) {
                    case 1: {     // DEPARE // SKIN OF EARTH
                            var instance = new DepthArea {
                                depthRangeMinimumValue = drval1,
                            };

                            if (drval2.HasValue)
                                instance.depthRangeMaximumValue = drval2.GetValueOrDefault();

                            // TODO: Spatial association to Spatial Quality

                            // TODO: InteroperabilityIdentifier

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, default);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;

                    case 5: {     // DRGARE // SKIN OF EARTH
                            var instance = new DredgedArea {
                                depthRangeMinimumValue = drval1,
                            };

                            if (drval2.HasValue)
                                instance.depthRangeMaximumValue = drval2.GetValueOrDefault();

                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var reportedDate)) {
                                    instance.dredgedDate = reportedDate;
                                }
                            }
                            else {
                                Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                            }


                            var featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            if (featureName is not null)
                                instance.featureName = featureName;

                            if (current.RESTRN != default) {
                                var restriction = EnumHelper.GetEnumValues(current.RESTRN);
                                if (restriction is not null && restriction.Any())
                                    instance.restriction = restriction;
                            }

                            // TODO: InteroperabilityIdentifier

                            // TODO: maximumPermittedDraught - From INFORM - No instances in GST - Not converted


                            // The S-57 attribute QUASOU for DEPARE will not be converted. It is considered that this attribute is
                            // not relevant for Depth Area in S-101.
                            //if (current.QUASOU != default) {
                            //    instance.qualityOfVerticalMeasurement = EnumHelper.GetEnumValue<qualityOfVerticalMeasurement>(current);
                            //}

                            if (!string.IsNullOrEmpty(restrn)) {
                                var restriction = EnumHelper.GetEnumValues(restrn);
                                if (restriction is not null && restriction.Any())
                                    instance.restriction = restriction;
                            }

                            if (!string.IsNullOrEmpty(tecsou)) {
                                var techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues(tecsou);
                                if (techniqueOfVerticalMeasurement is not null && techniqueOfVerticalMeasurement.Any())
                                    instance.techniqueOfVerticalMeasurement = techniqueOfVerticalMeasurement;
                            }

                            //TODO: verticalUncertainty - Not converted
                            //if (current.SOUACC.HasValue) {
                            //    instance.verticalUncertainty = new DomainModel.S101.ComplexAttributes.verticalUncertainty() {
                            //        uncertaintyFixed = current.SOUACC.Value
                            //    };
                            //}
                            //

                            if (current.INFORM is not null && instance.restriction is not null && instance.restriction.Contains(27 /*restriction.SpeedRestricted*/)) {
                                instance.vesselSpeedLimit = ImporterNIS.GetVesselSpeedLimit(current.INFORM);
                            }
                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, default);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);


                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                        }
                        break;

                    case 10: {    // SWPARE_SweptArea
                            throw new NotImplementedException($"No SWPARE_SweptArea in DK or GL. {tableName}");
                        }

                    case 15: {    // UNSARE  // SKIN OF EARTH
                            var instance = new UnsurveyedArea();

                            var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            instance.information = result.information.ToArray();
                            instance.SetInformationBindings(result.InformationBindings.ToArray());

                            // TODO: InteroperabilityIdentifier

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;


                            buffer["flatten"] = instance.Flatten();
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(instance.GetInformationBindings(), jsonSerializerOptions);

                            SetShape(buffer, current.SHAPE);
                            ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, default);
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
            }
            Logger.Current.DataTotalCount(tableName, recordCount, ConversionAnalytics.Instance.GetConvertedCount(tableName));
        }
    }
}
