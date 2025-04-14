using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_DepthsA(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "DepthsA";

            using var s = source.OpenDataset<FeatureClass>(source.GetName("DepthsA"));
            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("surface"));

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = s.Search(filter, true);
            
            var recordCount = 0;
            var convertedCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;
                var current = new DepthsA(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;
                
                var drval1 = current.DRVAL1 ?? default;
                var drval2 = current.DRVAL2 ?? default(decimal?);
                var sordat = current.SORDAT ?? default;

                var longname = current.LNAM ?? Strings.UNKNOWN;
                var restrn = current.RESTRN ?? default;
                var quasou = current.QUASOU ?? default;
                var tecsou = current.TECSOU ?? default;

                switch (subtype) {
                    case 1: {     // DEPARE // SKIN OF EARTH
                            var instance = new DepthArea {
                                depthRangeMinimumValue = drval1,
                                depthRangeMaximumValue = drval2.GetValueOrDefault()
                            };

                            // TODO: Spatial association to Spatial Quality

                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);


                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                        }
                        break;

                    case 5: {     // DRGARE // SKIN OF EARTH
                            var instance = new DredgedArea {
                                depthRangeMinimumValue = drval1,
                                depthRangeMaximumValue = drval2,
                            };

                            

                            if (!string.IsNullOrEmpty(sordat)) {
                                DateHelper.TryConvertToDateOnly(sordat, out var date);
                                instance.dredgedDate = date;
                            }

                            if (current.RESTRN != default) {
                                instance.restriction = EnumHelper.GetEnumValues<restriction>(current.RESTRN);
                            }

                            // The S-57 attribute QUASOU for DEPARE will not be converted. It is considered that this attribute is
                            // not relevant for Depth Area in S - 101.
                            //if (current.QUASOU != default) {
                            //    instance.qualityOfVerticalMeasurement = EnumHelper.GetEnumValue<qualityOfVerticalMeasurement>(current);
                            //}

                            //if (current.SOUACC.HasValue) {
                            //    instance.verticalUncertainty = new DomainModel.S101.ComplexAttributes.verticalUncertainty() {
                            //        uncertaintyFixed = current.SOUACC.Value
                            //    };
                            //}

                            if (!string.IsNullOrEmpty(restrn)) {
                                instance.restriction = EnumHelper.GetEnumValues<restriction>(restrn);
                            }

                            if (!string.IsNullOrEmpty(tecsou)) {
                                instance.techniqueOfVerticalMeasurement = EnumHelper.GetEnumValues<techniqueOfVerticalMeasurement>(tecsou);
                            }

                            //TODO: 	verticalUncertainty

                            //TODO: maximumPermittedDraught - Not converted
                            
                            

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;

                    case 10: {    //SWPARE
                            var instance = new SweptArea {
                                depthRangeMinimumValue = drval1,
                                scaleMinimum = null,
                                sweptDate = null,
                            };
                            if (!string.IsNullOrEmpty(sordat)) {
                                System.Diagnostics.Debugger.Break();    //  Swept Date
                            }

                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;

                    case 15: {    // UNSARE  // SKIN OF EARTH
                            var instance = new UnsurveyedArea {
                            };
                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
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
