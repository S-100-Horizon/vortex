using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_SeabedA(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "SeabedA";

            var ps101 = "S-101";

            using var seabedA = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(seabedA);

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("surface"));

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = seabedA.Search(filter, true);
            int recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new SeabedA(feature);

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
                var catweed = current.CATWED ?? default;
                var natsur = current.NATSUR ?? default;
                var natqua = current.NATQUA ?? default;

                // TODO: natsur, natqua

                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;

                switch (fcSubtype) {
                    case 15: { // SBDARE_SeabedArea
                            throw new NotImplementedException($"No SBDARE_SeabedArea in DK or GL. {tableName}");

                            var instance = new SeabedArea() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }



                            List<natureOfSurfaceQualifyingTerms> natureOfSurfaceQualifyingTermsList = new();

                            if (current.NATQUA != default) {
                                if (!string.IsNullOrEmpty(current.NATQUA)) {
                                    foreach (var c in current.NATQUA.Split(',', StringSplitOptions.RemoveEmptyEntries)) {
                                        natureOfSurfaceQualifyingTerms? e = c.ToLowerInvariant() switch {
                                            "1" => natureOfSurfaceQualifyingTerms.Fine,
                                            "2" => natureOfSurfaceQualifyingTerms.Medium,
                                            "3" => natureOfSurfaceQualifyingTerms.Coarse,
                                            "4" => natureOfSurfaceQualifyingTerms.Broken,
                                            "5" => natureOfSurfaceQualifyingTerms.Sticky,
                                            "6" => natureOfSurfaceQualifyingTerms.Soft,
                                            "7" => natureOfSurfaceQualifyingTerms.Stiff,
                                            "8" => natureOfSurfaceQualifyingTerms.Volcanic,
                                            "9" => natureOfSurfaceQualifyingTerms.Calcareous,
                                            "10" => natureOfSurfaceQualifyingTerms.Hard,
                                            "-1" => default,    //natureOfSurfaceQualifyingTerms.Unknown,
                                            _ => throw new ArgumentOutOfRangeException(nameof(current.NATSUR), "Invalid value for nature of surface qualifying terms.")
                                        };
                                        if (e.HasValue) {
                                            natureOfSurfaceQualifyingTermsList.Add(e.Value);
                                        }
                                    }
                                }
                            }

                            natureOfSurface? natureOfSurfaceValue = default;    // (natureOfSurface)(-1);

                            if (current.NATSUR != default) {
                                natureOfSurfaceValue = current.NATSUR switch {
                                    "1" => natureOfSurface.Mud,
                                    "2" => natureOfSurface.Clay,
                                    "3" => natureOfSurface.Silt,
                                    "4" => natureOfSurface.Sand,
                                    "5" => natureOfSurface.Stone,
                                    "6" => natureOfSurface.Gravel,
                                    "7" => natureOfSurface.Pebbles,
                                    "8" => natureOfSurface.Cobbles,
                                    "9" => natureOfSurface.Rock,
                                    "11" => natureOfSurface.Lava,
                                    "14" => natureOfSurface.Coral,
                                    "17" => natureOfSurface.Shells,
                                    "18" => natureOfSurface.Boulder,
                                    "-32767" => default, //(natureOfSurface)(-1),
                                    _ => throw new ArgumentOutOfRangeException(nameof(current.NATSUR), "Invalid value for nature of surface.")
                                };
                            }

                            instance.surfaceCharacteristics = new List<DomainModel.S101.ComplexAttributes.surfaceCharacteristics> {

                              new DomainModel.S101.ComplexAttributes.surfaceCharacteristics() {
                                 natureOfSurface = natureOfSurfaceValue,
                                 natureOfSurfaceQualifyingTerms = natureOfSurfaceQualifyingTermsList,
                                 // underlyingLayer = ?? TODO: Underlying layer for seabed
                              }

                            };

                            if (current.WATLEV.HasValue) {
                                instance.waterLevelEffect = current.WATLEV.Value switch {
                                    1 => waterLevelEffect.PartlySubmergedAtHighWater,  // partly submerged at high water
                                    2 => waterLevelEffect.AlwaysDry,  // always dry
                                    3 => waterLevelEffect.AlwaysUnderWaterSubmerged,  // always under water/submerged
                                    4 => waterLevelEffect.CoversAndUncovers,  // covers and uncovers
                                    5 => waterLevelEffect.Awash,  // awash
                                    6 => waterLevelEffect.SubjectToInundationOrFlooding,  // subject to inundation or flooding
                                    7 => waterLevelEffect.Floating,  // floating
                                    -32767 => (waterLevelEffect)(-1),
                                    _ => throw new IndexOutOfRangeException(),
                                };
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = $"{featureN.GetGlobalID():N}";

                            // TODO: Create relations

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;
                    case 30: { // SNDWAV_SandWaves

                            throw new NotImplementedException($"No SNDWAV_SandWaves in DK or GL. {tableName}");

                            var instance = new Sandwave() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }



                            AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["edition"] = ImporterNIS.s101version;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer, current.SHAPE);
                            ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = $"{featureN.GetGlobalID():N}";

                            // TODO: Create relations

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;
                    case 40: { // WEDKLP_WeedKelp
                            throw new NotImplementedException($"No WEDKLP_WeedKelp in DK or GL. {tableName}");

                            if (catweed == 3) {
                                var instance = new Seagrass();
                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                }

                                instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                                AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["edition"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                SetShape(buffer, current.SHAPE);
                                ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = $"{featureN.GetGlobalID():N}";

                                // TODO: Create relations

                                ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name);

                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                            }
                            else {
                                var instance = new WeedKelp() {
                                };
                                if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                    string subtype = "";

                                    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                                }

                                instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                                AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);
                                buffer["ps"] = ps101;
                                buffer["code"] = instance.GetType().Name;
                                buffer["edition"] = ImporterNIS.s101version;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                SetShape(buffer, current.SHAPE);
                                ImporterNIS.SetUsageBand(buffer, current.PLTS_COMP_SCALE!.Value);

                                var featureN = featureClass.CreateRow(buffer);
                                var name = $"{featureN.GetGlobalID():N}";

                                // TODO: Create relations

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
