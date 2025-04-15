using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
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
            var subtypes = seabedA.GetSubtypes();
            var featureType = PrimitiveType.Area;

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("surface"));

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = seabedA.Search(filter, true);
            int recordCount = 0;
            int convertedCount = 0;
            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new SeabedA(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;
                var watlev = current.WATLEV ?? default;
                var catweed = current.CATWED ?? default;
                var natsur = current.NATSUR ?? default;
                var natqua = current.NATQUA ?? default; 

                // TODO: natsur, natqua

                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;

                switch (subtype) {
                    case 15: { // SBDARE_SeabedArea
                            var instance = new SeabedArea() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], featureType, current.PLTS_COMP_SCALE.Value);
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
                                            "-1" => natureOfSurfaceQualifyingTerms.Unknown,
                                            _ => throw new ArgumentOutOfRangeException(nameof(current.NATSUR), "Invalid value for nature of surface qualifying terms.")
                                        };
                                        if (e.HasValue) {
                                            natureOfSurfaceQualifyingTermsList.Add(e.Value);
                                        }
                                    }
                                }
                            }
                            
                            natureOfSurface natureOfSurfaceValue = (natureOfSurface)(-1);

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
                                    "-32767" => (natureOfSurface)(-1),
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
                    case 30: { // SNDWAV_SandWaves
                            var instance = new Sandwave() {
                            };
                            if (current.PLTS_COMP_SCALE.HasValue) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], featureType, current.PLTS_COMP_SCALE.Value);
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
                    case 40: { // WEDKLP_WeedKelp
                            if (catweed == 3) {
                                var instance = new Seagrass();
                                if (plts_comp_scale != default) {
                                    //instance.scaleMinimum = plts_comp_scale;
                                }
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
                            else {
                                var instance = new WeedKelp() {
                                };
                                if (plts_comp_scale != default) {
                                    //instance.scaleMinimum = plts_comp_scale;
                                }
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
