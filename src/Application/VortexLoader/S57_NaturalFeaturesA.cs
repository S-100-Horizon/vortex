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


                switch (fcSubtype) {
                    case 1: { //  LAKARE_Lake
                            /* S-57 allows for LAKARE to be covered by the Group 1 objects LNDARE or UNSARE, however in
                               S-101 all Lake features must be covered by the Skin of the Earth feature Land Area. During the
                               automated conversion process, the converter may have the capability to convert UNSARE covering
                               LAKARE to Land Area (taking into account the attribution of any adjoining LNDARE objects) and
                               merge with any adjoining Land Area features. If the converter does not have this capability, Data
                               Producers are advised to check their S-57 data holdings and amend their Group 1 coverage to have
                               LAKARE covered by LNDARE (and merge with adjoining LNDARE as appropriate). */

                            var instance = new Lake();

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: interoperabilityIdentifier

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

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedAreaEquipment(current, instance, featureN);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name); Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
    
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
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
                                if (DateHelper.regexTruncatedDateValidation.IsMatch(current.SORDAT)) {
                                    instance.reportedDate = current.SORDAT;
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

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedAreaEquipment(current, instance, featureN);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name); Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;

                    case 10: {    // LNDRGN
                            var instance = new LandRegion();

                            if (current.CATLND != default) {
                                instance.categoryOfLandRegion = EnumHelper.GetEnumValues<categoryOfLandRegion>(current.CATLND);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: Interoperabilityidentifier

                            if (current.NATSUR != default) {
                                instance.natureOfSurface = EnumHelper.GetEnumValues<natureOfSurface>(current.NATSUR);
                            }

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

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            bufferSurface["shape"] = current.SHAPE;
                            var featureN = featureClass.CreateRow(bufferSurface);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedAreaEquipment(current, instance, featureN);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name); Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 15: {    // RAPIDS_Rapids
                            throw new NotImplementedException($"No RAPIDS in DK or GL. {tableName}");
                        }
                        break;

                    case 20: {    // RIVERS
                            var instance = new River();

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: interoperabilityIdentifier

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

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedAreaEquipment(current, instance, featureN);
                            }

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
                            var instance = new SeaAreaNamedWaterArea();
                            
                            if (current.CATSEA.HasValue) {
                                instance.categoryOfSeaArea = EnumHelper.GetEnumValue<categoryOfSeaArea>(current.CATSEA.Value);
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

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            bufferSurface["shape"] = current.SHAPE;

                            var featureN = featureClass.CreateRow(bufferSurface);
                            var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedAreaEquipment(current, instance, featureN);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name); Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;

                    case 30: {    // SLOGRD_SlopingGround
                            throw new NotImplementedException($"No SLOGRD_SlopingGround\r\n in DK or GL. {tableName}");

                            //var instance = new SlopingGround {
                            //    categoryOfSlope = null,
                            //    radarConspicuous = null,
                            //    visualProminence = null,
                            //    scaleMinimum = null,
                            //};
                            
                            //if (current.CATSLO.HasValue) {
                            //    instance.categoryOfSlope = EnumHelper.GetEnumValue<categoryOfSlope>(current.CATSLO.Value);
                            //}

                            //if (current.COLOUR != default) {
                            //    instance.colour = GetColours(current.COLOUR);
                            //}

                            //if (current.NATSUR != default) {
                            //    instance.natureOfSurface = EnumHelper.GetEnumValues<natureOfSurface>(current.NATSUR);
                            //}

                            //if (current.CONRAD.HasValue) {
                            //    instance.radarConspicuous = current.CONRAD.Value == 2 ? false : true;
                            //}

                            //if (convis != default) {
                            //    instance.visualProminence = convis switch {
                            //        1 => visualProminence.VisuallyConspicuous,  // visually conspicuous
                            //        2 => visualProminence.NotVisuallyConspicuous,  // not visually conspicuous                                
                            //        -32767 =>null,
                            //        _ => throw new IndexOutOfRangeException(),
                            //    };
                            //}
                            //if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                            //    string subtype = "";

                            //    if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                            //        throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                            //    instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
                            //}

                            //instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            //AddInformation(instance.information, feature);

                            //bufferSurface["ps"] = ps101;
                            //bufferSurface["code"] = instance.GetType().Name; 
                            //bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            //bufferSurface["shape"] = current.SHAPE;
                            //var featureN = featureClass.CreateRow(bufferSurface);
                            //var name = Convert.ToString(featureN["name"]) ?? "Unknown name";

                            //// TODO: Create relations

                            //ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name); Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            //Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 35: {    // VEGATN
                            var instance = new Vegetation();

                            if (current.CATVEG != default) {
                                instance.categoryOfVegetation = EnumHelper.GetEnumValue<categoryOfVegetation>(current.CATVEG);
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value;
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
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

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment?.CreateRelatedAreaEquipment(current, instance, featureN);
                            }

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
