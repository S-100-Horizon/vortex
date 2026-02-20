using ArcGIS.Core.Data;
using S100FC;
using S100FC.S101.FeatureTypes;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using surfaceCharacteristics = S100FC.S101.ComplexAttributes.surfaceCharacteristics;

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

            using var cursor = seabedp.Search(filter, true);
            int recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new SeabedP(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (FeatureRelations.Instance.IsSlave(globalid)) {
                    continue;
                }

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    throw new Exception("Ups. Not supported");
                }



                var fcSubtype = current.FCSUBTYPE ?? default;
                var watlev = current.WATLEV ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;

                switch (fcSubtype) {
                    case 15: { // SBDARE_SeabedArea
                            var instance = new SeabedArea {
                                featureName = GetFeatureName(current.OBJNAM, current.NOBJNM)
                            };

                            // TODO: interoperabilityIdentifier

                            var natureOfSurfaceQualifyingTermsCount = 0;
                            var naturOfSurfaceCount = 0;

                            string[] natsurValues = null!;
                            string[] natquaValues = null!;

                            int?[]? natureOfSurfaceQualifyingTermsList = null;

                            if (current.NATSUR != default && current.NATSUR.Trim().Length > 0) {
                                natsurValues = current.NATSUR.Trim().Trim(',').Split(',');
                                naturOfSurfaceCount = natsurValues.Count();
                            }

                            if (current.NATQUA != default && current.NATQUA.Trim().Length > 0) {
                                natquaValues = current.NATQUA.Trim().Trim(',').Split(',');
                                natureOfSurfaceQualifyingTermsCount = natquaValues.Count();

                                var enumValues = EnumHelper.GetEnumValues(current.NATQUA);
                                if (enumValues is not null && enumValues.Any())
                                    natureOfSurfaceQualifyingTermsList = enumValues;
                            }

                            // TODO: Verify this against action point 48

                            //surfaceCharacteristics surfaceChars = new();

                            surfaceCharacteristics[] surfaceCharacteristics = [];

                            var list1 = string.IsNullOrWhiteSpace(current.NATSUR) || string.IsNullOrEmpty(current.NATSUR.Trim().Trim(',')) ? [""] : current.NATSUR.Trim().Trim(',').Split(',').ToList();
                            var list2 = string.IsNullOrWhiteSpace(current.NATQUA) || string.IsNullOrEmpty(current.NATQUA.Trim().Trim(',')) ? [""] : current.NATQUA.Trim().Trim(',').Split(',').ToList();

                            //var result = new List<(string, string)>();

                            if (naturOfSurfaceCount > 0) {
                                for (int i = 0; i < list1.Count(); i++) {
                                    var natureOfSurface = EnumHelper.GetEnumValue(list1[i]);

                                    if (list2.Count() > i && !string.IsNullOrEmpty(list2[i])) {
                                        surfaceCharacteristics = [.. surfaceCharacteristics, new() {
                                            natureOfSurface = natureOfSurface,
                                            natureOfSurfaceQualifyingTerms = [natureOfSurfaceQualifyingTermsList![i]],
                                        }];
                                        //instance.surfaceCharacteristics.Add(new() {
                                        //    natureOfSurface = natureOfSurface,
                                        //    natureOfSurfaceQualifyingTerms = new() { natureOfSurfaceQualifyingTermsList![i] }

                                        //});
                                    }
                                    else {
                                        surfaceCharacteristics = [.. surfaceCharacteristics, new() {
                                             natureOfSurface = natureOfSurface
                                        }];
                                        //instance.surfaceCharacteristics.Add(new() {
                                        //    natureOfSurface = natureOfSurface
                                        //});
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
                                                surfaceCharacteristics = [.. surfaceCharacteristics, new() {
                                                     natureOfSurfaceQualifyingTerms = [natureOfSurfaceQualifyingTermsList![i]],
                                                }];
                                                //instance.surfaceCharacteristics.Add(new() {
                                                //    natureOfSurfaceQualifyingTerms = new() { natureOfSurfaceQualifyingTermsList![i] }
                                                //});
                                            }
                                        }

                                    }
                                }
                            }
                            instance.surfaceCharacteristics = surfaceCharacteristics;

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
                                instance.waterLevelEffect = EnumHelper.GetEnumValue(current.WATLEV);
                            }

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
                            ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = featureN.UID();

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                        }
                        break;
                    case 25: { // SNDWAV_SandWaves
                            var instance = new Sandwave();


                            // TODO: interoperabilityIdentifier

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value != -32767m ? current.VERLEN.Value : null;
                            }
                            else if (current.VERLEN.HasValue && current.VERLEN.Value == -32767m) {
                                //instance.verticalLength = default(decimal?);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
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
                                relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                        }
                        break;

                    case 30: { // SPRING_Spring
                            throw new NotImplementedException($"No SPRING_Spring in DK or GL. {tableName}");
                        }
                    case 35: { // WEDKLP_WeedKelp

                            if (current.CATWED.HasValue && current.CATWED.Value == 3) {
                                var seagrass = new Seagrass {
                                    featureName = GetFeatureName(current.OBJNAM, current.NOBJNM)
                                };

                                // TODO: interoperabilityIdentifier

                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    seagrass.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                }

                                var result = ImporterNIS.AddInformation(current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                                seagrass.information = result.information.ToArray();
                                seagrass.SetInformationBindings(result.InformationBindings.ToArray());

                                buffer["ps"] = ps101;
                                buffer["code"] = seagrass.GetType().Name;

                                buffer["flatten"] = seagrass.Flatten();
                                buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(seagrass.GetInformationBindings(), ImporterNIS.jsonSerializerOptions);

                                SetShape(buffer, current.SHAPE);
                                SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = featureN.UID();

                                if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                    relatedEquipment?.CreateRelatedPointEquipment(current, seagrass, featureN, seagrass.scaleMinimum);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(seagrass, ImporterNIS.jsonSerializerOptions));

                            }
                            else {

                                var instance = new WeedKelp();
                                if (current.CATWED.HasValue) {
                                    instance.categoryOfWeedKelp = EnumHelper.GetEnumValue(current.CATWED.Value);
                                }

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
                                    relatedEquipment!.CreateRelatedPointEquipment(current, instance, featureN, instance.scaleMinimum);
                                }

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

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
