using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
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
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = depthsA.Search(filter, true);
            
            var recordCount = 0;
            

            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;
                var current = new DepthsA(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    continue;
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
                                depthRangeMaximumValue = drval2.GetValueOrDefault()
                            };

                            // TODO: Spatial association to Spatial Quality

                            // TODO: InteroperabilityIdentifier

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

                    case 5: {     // DRGARE // SKIN OF EARTH
                            var instance = new DredgedArea {
                                depthRangeMinimumValue = drval1,
                                depthRangeMaximumValue = drval2,
                            };

                            if (current.SORDAT != default) {
                                if (DateHelper.TryConvertToDateOnly(current.SORDAT, out var dateOnly)) {
                                    instance.dredgedDate = dateOnly;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.RESTRN != default) {
                                instance.restriction = EnumHelper.GetEnumValues<restriction>(current.RESTRN);
                            }

                            // TODO: InteroperabilityIdentifier

                            // TODO: maximumPermittedDraught - Not converted
                            

                            // The S-57 attribute QUASOU for DEPARE will not be converted. It is considered that this attribute is
                            // not relevant for Depth Area in S-101.
                            //if (current.QUASOU != default) {
                            //    instance.qualityOfVerticalMeasurement = EnumHelper.GetEnumValue<qualityOfVerticalMeasurement>(current);
                            //}

                            if (!string.IsNullOrEmpty(restrn)) {
                                instance.restriction = EnumHelper.GetEnumValues<restriction>(restrn);
                            }

                            if (!string.IsNullOrEmpty(tecsou)) {
                                instance.techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues<techniqueOfVerticalMeasurement>(tecsou);
                            }

                            //TODO: verticalUncertainty - Not converted
                            //if (current.SOUACC.HasValue) {
                            //    instance.verticalUncertainty = new DomainModel.S101.ComplexAttributes.verticalUncertainty() {
                            //        uncertaintyFixed = current.SOUACC.Value
                            //    };
                            //}

                            // TODO: VesselSpeedLimit

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

                    case 10: {    //SWPARE
                            var instance = new SweptArea {
                                depthRangeMinimumValue = drval1,
                                scaleMinimum = null,
                                sweptDate = null,
                            };

                            if (current.DRVAL1.HasValue && current.DRVAL1.Value != -32767) {
                                instance.depthRangeMinimumValue = current.DRVAL1.Value;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.TryConvertToDateOnly(current.SORDAT, out var dateOnly)) {
                                    instance.sweptDate = dateOnly;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";
                          
                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            // TODO: Create relations

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;

                    case 15: {    // UNSARE  // SKIN OF EARTH
                            var instance = new UnsurveyedArea();

                            AddInformation(instance.information, feature);

                            // TODO: InteroperabilityIdentifier
                            
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
