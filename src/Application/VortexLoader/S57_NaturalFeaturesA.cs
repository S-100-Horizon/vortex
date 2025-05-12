using ArcGIS.Core.Data;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S101;
using S100Framework.Applications.S57.esri;
using System;
using S100Framework.Applications.Singletons;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_NaturalFeaturesA(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "NaturalFeaturesA";
            
            using var naturalFeaturesA = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(naturalFeaturesA);

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("surface"));

            using var bufferSurface = featureClass.CreateRowBuffer();
            using var insertSurface = featureClass.CreateInsertCursor();

            using var cursor = naturalFeaturesA.Search(filter, true);
            
            var recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;
                var current = new NaturalFeaturesA(feature);

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
                var watlev = current.WATLEV ?? default;
                var catlnd = current.CATLND ?? default;
                var natsur = current.NATSUR ?? default;
                var catsea = current.CATSEA ?? default;
                var catslo = current.CATSLO ?? default;
                var color = current.COLOUR ?? default;
                var conrad = current.CONRAD ?? default;
                var convis = current.CONVIS ?? default;
                var catveg = current.CATVEG ?? default;
                var elevat = current.ELEVAT ?? default;
                var height = current.HEIGHT ?? default;
                var verlen = current.VERLEN ?? default;



                    switch (fcSubtype) {
                    case 1: { //  LAKARE
                            var instance = new Lake {
                                elevation = null,
                                status = null,
                                scaleMinimum = null,
                            };
                            if (elevat !=  default) {
                                instance.elevation = elevat;
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            
                            if (status != default) {
                                if (!string.IsNullOrEmpty(status)) {
                                    //TODO: STATUS
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetSingleStatus(current.STATUS);
                            }
                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name; 
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            bufferSurface["shape"] = current.SHAPE;
                            var featureN = featureClass.CreateRow(bufferSurface);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            // TODO: Create relations

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name); Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));


                            /* S-57 allows for LAKARE to be covered by the Group 1 objects LNDARE or UNSARE, however in
                               S-101 all Lake features must be covered by the Skin of the Earth feature Land Area. During the
                               automated conversion process, the converter may have the capability to convert UNSARE covering
                               LAKARE to Land Area (taking into account the attribution of any adjoining LNDARE objects) and
                               merge with any adjoining Land Area features. If the converter does not have this capability, Data
                               Producers are advised to check their S-57 data holdings and amend their Group 1 coverage to have
                               LAKARE covered by LNDARE (and merge with adjoining LNDARE as appropriate). */

                            //TODO: LAKARE
                        }
                        break;

                    case 5: { //  LNDARE // SKIN OF EARTH
                            var instance = new LandArea();

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: InteroperabilityIdentifier

                            if (current.SORDAT != default) {
                                if (DateHelper.TryConvertToDateOnly(current.SORDAT, out var dateOnly)) {
                                    instance.reportedDate = dateOnly;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, tableName, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetSingleStatus(current.STATUS);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            AddInformation(instance.information, feature);

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name; 
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            bufferSurface["shape"] = current.SHAPE;
                            
                            var featureN = featureClass.CreateRow(bufferSurface);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            // TODO: Create relations

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name); Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;

                    case 10: {    // LNDRGN
                            var instance = new LandRegion();


                            if (current.WATLEV.HasValue) {
                                if (current.WATLEV.Value == -32767)
                                    instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(-1);
                                else {
                                    instance.waterLevelEffect = EnumHelper.GetEnumValue<waterLevelEffect>(current.WATLEV);
                                }
                            }


                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            if (current.NATSUR != default) { 
                                instance.natureOfSurface = EnumHelper.GetEnumValues<natureOfSurface>(current.NATSUR);
                            }

                            if (current.CATLND != default) {
                                instance.categoryOfLandRegion = EnumHelper.GetEnumValues<categoryOfLandRegion>(current.CATLND);
                            }

                            // TODO: Interoperabilityidentifier

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            bufferSurface["shape"] = current.SHAPE;
                            var featureN = featureClass.CreateRow(bufferSurface);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            // TODO: Create relations

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name); Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 15: {    // RAPIDS
                            System.Diagnostics.Debugger.Break();
                        }
                        break;

                    case 20: {    // RIVERS
                            var instance = new River {
                                status = null,
                                scaleMinimum = null,
                            };
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            if (status != default) {
                                if (!string.IsNullOrEmpty(status)) {
                                    //TODO: STATUS
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetSingleStatus(current.STATUS);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name; 
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            bufferSurface["shape"] = current.SHAPE;
                            var featureN = featureClass.CreateRow(bufferSurface);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            // TODO: Create relations

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name); Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));


                            /* S-57 allows for RIVERS of geometric primitive area to be covered by the Group 1 objects LNDARE
                               or UNSARE, however in S-101 all Rivers of geometric primitive area must be covered by the Skin
                               of the Earth feature Land Area. During the automated conversion process, the converter may have
                               the capability to convert UNSARE covering RIVERS to Land Area (taking into account the attribution
                               of any adjoining LNDARE objects) and merge with any adjoining Land Area features. If the
                               converter does not have this capability, Data Producers are advised to check their S-57 data
                               holdings and amend their Group 1 coverage to have RIVERS of geometric primitive area covered
                               by LNDARE (and merge with adjoining LNDARE as appropriate). */

                            /* S-57 guidance recommends the encoding of intermittent lakes using an instance of the S-57 Object
                               class RIVERS. Data Producers are advised to check all instances of RIVERS of geometric primitive
                               area having attribute STATUS = 5 (periodic/intermittent) and if the real-world feature is a lake to
                               amend to an instance of the S-101 Feature _s101type Lake (see S-101 DCEG clause 5.10). */
                            //TODO: River
                        }
                        break;

                    case 25: {    // SEAARE
                            var instance = new SeaAreaNamedWaterArea {
                                categoryOfSeaArea = null,
                                scaleMinimum = null,
                            };
                            
                            if (current.CATSEA.HasValue) {
                                instance.categoryOfSeaArea = EnumHelper.GetEnumValue<categoryOfSeaArea>(current.CATSEA.Value);
                            }
                            
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            AddInformation(instance.information, feature);

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            bufferSurface["shape"] = current.SHAPE;

                            var featureN = featureClass.CreateRow(bufferSurface);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            // TODO: Create relations

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name); Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;

                    case 30: {    // SLOGRD
                            var instance = new SlopingGround {
                                categoryOfSlope = null,
                                radarConspicuous = null,
                                visualProminence = null,
                                scaleMinimum = null,
                            };
                            
                            if (current.CATSLO.HasValue) {
                                instance.categoryOfSlope = EnumHelper.GetEnumValue<categoryOfSlope>(current.CATSLO.Value);
                            }


                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.NATSUR != default) {
                                instance.natureOfSurface = EnumHelper.GetEnumValues<natureOfSurface>(current.NATSUR);
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }



                            if (convis != default) {
                                instance.visualProminence = convis switch {
                                    1 => visualProminence.VisuallyConspicuous,  // visually conspicuous
                                    2 => visualProminence.NotVisuallyConspicuous,  // not visually conspicuous                                
                                    -32767 =>null,
                                    _ => throw new IndexOutOfRangeException(),
                                };
                            }
                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }



                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name; 
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            bufferSurface["shape"] = current.SHAPE;
                            var featureN = featureClass.CreateRow(bufferSurface);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            // TODO: Create relations

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name); Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));


                        }
                        break;

                    case 35: {    // VEGATN
                            var vegetationCategory = catveg?.ToLowerInvariant() switch {
                                "3" => categoryOfVegetation.Bush,
                                "4" => categoryOfVegetation.DeciduousWood,
                                "5" => categoryOfVegetation.ConiferousWood,
                                "6" => categoryOfVegetation.WoodInGeneralIncMixedWood,
                                "11" => categoryOfVegetation.Reed,
                                "13" => categoryOfVegetation.TreeInGeneral,
                                "14" => categoryOfVegetation.EvergreenTree,
                                _ => throw new IndexOutOfRangeException(),
                            };
                            var instance = new Vegetation {
                                categoryOfVegetation = vegetationCategory,
                                visualProminence = null,
                                elevation = null,
                                height = null,
                                verticalLength = null,
                                scaleMinimum = null,
                            };
                            if (elevat != default) {
                                instance.elevation = elevat;
                            }
                            if (height != default) {
                                instance.height = height;
                            }
                            if (verlen != default) {
                                instance.verticalLength = verlen;
                            }

                            if (current.CONVIS.HasValue) {
                                instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            }


                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            bufferSurface["shape"] = current.SHAPE;
                            var featureN = featureClass.CreateRow(bufferSurface);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            // TODO: Create relations

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name); Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
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
