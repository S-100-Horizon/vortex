using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101.ComplexAttributes;
using surfaceCharacteristics = S100Framework.DomainModel.S101.ComplexAttributes.surfaceCharacteristics;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_SeabedP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "SeabedP";

            var ps101 = "S-101";

            using var seabedp = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(seabedp);

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("point"));
            

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = seabedp.Search(filter, true);
            int recordCount = 0;
            
            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new SeabedP(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    continue;
                }

                var fcSubtype = current.FCSUBTYPE ?? default;
                var watlev = current.WATLEV ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;

                switch (fcSubtype) {
                    case 15: { // SBDARE_SeabedArea
                            var instance = new SeabedArea();

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: interoperabilityIdentifier

                            var natureOfSurfaceQualifyingTermsCount = 0;
                            var naturOfSurfaceCount = 0;

                            string[] natsurValues = default;
                            string[] natquaValues = default;

                            List<natureOfSurfaceQualifyingTerms>? natureOfSurfaceQualifyingTermsList = null;

                            if (current.NATSUR != default && current.NATSUR.Trim().Length > 0) {
                                natsurValues = current.NATSUR.Trim().Trim(',').Split(',');
                                naturOfSurfaceCount = natsurValues.Count();
                            }
                            if (current.NATQUA != default && current.NATQUA.Trim().Length > 0) {
                                natquaValues = current.NATQUA.Trim().Trim(',').Split(',');
                                natureOfSurfaceQualifyingTermsCount = natquaValues.Count();
                                natureOfSurfaceQualifyingTermsList = EnumHelper.GetEnumValues<natureOfSurfaceQualifyingTerms>(current.NATQUA);
                            }

                            // TODO: Verify this against action point 48

                            surfaceCharacteristics surfaceChars = new();

                            instance.surfaceCharacteristics = new List<DomainModel.S101.ComplexAttributes.surfaceCharacteristics>();

                            var list1 = string.IsNullOrWhiteSpace(current.NATSUR) || string.IsNullOrEmpty(current.NATSUR.Trim().Trim(',')) ? new List<string> { "" } : current.NATSUR.Trim().Trim(',').Split(',').ToList();
                            var list2 = string.IsNullOrWhiteSpace(current.NATQUA) || string.IsNullOrEmpty(current.NATQUA.Trim().Trim(',')) ? new List<string> { "" } : current.NATQUA.Trim().Trim(',').Split(',').ToList();

                            var result = new List<(string, string)>();

                            if (naturOfSurfaceCount > 0) {
                                for (int i = 0; i < list1.Count(); i++) {
                                    var natureOfSurface = EnumHelper.GetEnumValue<natureOfSurface>(list1[i]);

                                    if (list2.Count() > i && !string.IsNullOrEmpty(list2[i])) {
                                        instance.surfaceCharacteristics.Add(new() {
                                            natureOfSurface = natureOfSurface,
                                            natureOfSurfaceQualifyingTerms = new() { natureOfSurfaceQualifyingTermsList[i] }

                                        });
                                    }
                                    else {
                                        instance.surfaceCharacteristics.Add(new() {
                                            natureOfSurface = natureOfSurface
                                        });
                                    }
                                }
                            }
                            else {
                                // S-57 Appendix B.1 Annex A_Ed 4.4.0_FINAL.pdf
                                // p.74 - (d) Hard bottom: The attribute NATQUA = 10 (hard) should be encoded, without being associated with NATSUR.

                                if (natureOfSurfaceQualifyingTermsCount > 0) {
                                    for (int i = 0; i < list2.Count(); i++) {
                                        if (list2.Count() > i && !string.IsNullOrEmpty(list2[i])) {
                                            if (list2[i] != "10") {
                                                Logger.Current.DataError(current.OBJECTID ?? -1, tableName, longname, "NatureOfSurface is empty but natureOfSurfaceQualifyingTerms are not. This is not permitted.");
                                            }
                                            else {
                                                instance.surfaceCharacteristics.Add(new() {
                                                    natureOfSurfaceQualifyingTerms = new() { natureOfSurfaceQualifyingTermsList[i] }
                                                });
                                            }
                                        }

                                    }
                                }
                            }

                            //foreach (var natsur in list1) {
                            //    foreach (var natqua in list2) {
                            //        if (natureOfSurfaceQualifyingTermsList != null && !string.IsNullOrEmpty(natsur)) {
                            //            instance.surfaceCharacteristics.Add(new() {
                            //                natureOfSurface = EnumHelper.GetEnumValue<natureOfSurface>(natsur),
                            //                natureOfSurfaceQualifyingTerms = natureOfSurfaceQualifyingTermsList
                            //            });
                            //        }

                            //        if (natureOfSurfaceQualifyingTermsList != null && string.IsNullOrEmpty(natsur)) {
                            //            instance.surfaceCharacteristics.Add(new() {
                            //                natureOfSurfaceQualifyingTerms = natureOfSurfaceQualifyingTermsList
                            //            });
                            //        }

                            //        if (natureOfSurfaceQualifyingTermsList == null && !string.IsNullOrEmpty(natsur)) {
                            //            instance.surfaceCharacteristics.Add(new() {
                            //                natureOfSurface = EnumHelper.GetEnumValue<natureOfSurface>(natsur),
                            //            });
                            //        }

                            //        if (natureOfSurfaceQualifyingTermsList == null && string.IsNullOrEmpty(natsur)) {

                            //        }
                            //    }
                            //}

                            if (current.WATLEV.HasValue) {
                                instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(current.WATLEV);
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
                            ImporterNIS.SetDrawingIndex(buffer, current.PLTS_COMP_SCALE.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;
                    case 25: { // SNDWAV_SandWaves
                            throw new NotImplementedException($"No SNDWAV_SandWaves in DK or GL. {tableName}");

                            var instance = new Sandwave() {
                            };
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
                            ImporterNIS.SetDrawingIndex(buffer, current.PLTS_COMP_SCALE.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }


                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;
                    case 30: { // SPRING_Spring
                            throw new NotImplementedException($"No SPRING_Spring in DK or GL. {tableName}");    

                            var instance = new Spring() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            ImporterNIS.SetDrawingIndex(buffer, current.PLTS_COMP_SCALE.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;
                    case 35: { // WEDKLP_WeedKelp

                            if (current.CATWED.HasValue && current.CATWED.Value == 3) {
                                var seagrass = new Seagrass();

                                seagrass.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                                // TODO: interoperabilityIdentifier

                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    seagrass.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                                }

                                AddInformation(seagrass.information, feature);

                                buffer["ps"] = ps101;
                                buffer["code"] = seagrass.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(seagrass, jsonSerializerOptions);
                                SetShape(buffer, current.SHAPE);
                                SetDrawingIndex(buffer, current.PLTS_COMP_SCALE.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment?.CreateRelatedPointEquipment(current, seagrass, featureN);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(seagrass));

                            }
                            else 
                            {
                                
                                var instance = new WeedKelp();
                                if (current.CATWED.HasValue) {
                                    instance.categoryOfWeedKelp = EnumHelper.GetEnumValue<categoryOfWeedKelp>(current.CATWED.Value);
                                }

                                instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                                // TODO: interoperabilityIdentifier

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
                                SetShape(buffer, current.SHAPE);
                                SetDrawingIndex(buffer, current.PLTS_COMP_SCALE.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment?.CreateRelatedPointEquipment(current, instance, featureN);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                            }
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
