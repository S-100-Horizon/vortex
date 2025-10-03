using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

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

            using var cursor = naturalFeaturesA.Search(filter, true);

            var recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;
                var current = new NaturalFeaturesA(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (FeatureRelations.Instance.IsSlave(globalid)) {
                    continue;
                }

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    throw new Exception("Ups. Not supported");
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

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["edition"] = ImporterNIS.s101version;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(bufferSurface);
                            var name = $"{featureN.Crc32()}";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name); 

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


                            if (!string.IsNullOrEmpty(current.SORDAT)) {
                                if (DateHelper.TryConvertSordat(current.SORDAT, out var result)) {
                                    instance.reportedDate = result;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID ?? -1, current.GetType().Name, current.LNAM ?? "Unknown LNAM", $"Cannot convert date {current.SORDAT}");
                                }
                            }


                            if (current.STATUS != default) {
                                instance.status = GetSingleStatus(current.STATUS);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }


                            AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["edition"] = ImporterNIS.s101version;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);

                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            LandAreas.Instance.Add(current.SHAPE!.Clone());

                            var featureN = featureClass.CreateRow(bufferSurface);
                            var name = $"{featureN.Crc32()}";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name); 
                            
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;

                    case 10: {    // LNDRGN
                            var instance = new LandRegion();

                            if (current.CATLND != default) {
                                instance.categoryOfLandRegion = EnumHelper.GetEnumValues<LandRegion, categoryOfLandRegion>(current.CATLND);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: Interoperabilityidentifier

                            if (current.NATSUR != default) {
                                instance.natureOfSurface = EnumHelper.GetEnumValues<LandRegion, natureOfSurface>(current.NATSUR);
                            }

                            if (current.WATLEV.HasValue) {
                                instance.waterLevelEffect = EnumHelper.GetEnumValue<LandRegion, waterLevelEffect>(current.WATLEV);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";

                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");

                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["edition"] = ImporterNIS.s101version;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(bufferSurface, current.Shape);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);


                            var featureN = featureClass.CreateRow(bufferSurface);
                            var name = $"{featureN.Crc32()}";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name); 
                            
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        }
                        break;

                    case 15: {    // RAPIDS_Rapids
                            throw new NotImplementedException($"No RAPIDS in DK or GL. {tableName}");
                        }

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
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["edition"] = ImporterNIS.s101version;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(bufferSurface);
                            var name = $"{featureN.Crc32()}";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name); 
                            
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
                                instance.categoryOfSeaArea = EnumHelper.GetEnumValue<SeaAreaNamedWaterArea, categoryOfSeaArea>(current.CATSEA.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: interoperabilityIdentifier

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["edition"] = ImporterNIS.s101version;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(bufferSurface);
                            var name = $"{featureN.Crc32()}";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name); 
                            
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));

                        }
                        break;

                    case 30: {    // SLOGRD_SlopingGround
                            throw new NotImplementedException($"No SLOGRD_SlopingGround\r\n in DK or GL. {tableName}");
                        }

                    case 35: {    // VEGATN
                            var instance = new Vegetation {
                                categoryOfVegetation = default,
                            };

                            if (current.CATVEG != default) {
                                instance.categoryOfVegetation = EnumHelper.GetEnumValue<Vegetation, categoryOfVegetation>(current.CATVEG);
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767d) {
                                instance.height = current.HEIGHT.Value;
                            }
                            else {
                                instance.height = default(double?);
                            }

                            // TODO: interoperabilityIdentifier

                            if (current.VERLEN.HasValue) {
                                instance.verticalLength = current.VERLEN.Value;
                            }

                            if (current.CONVIS.HasValue && current.CONVIS.Value != -32767) {
                                instance.visualProminence = EnumHelper.GetEnumValue<Vegetation, visualProminence>(current.CONVIS.Value);
                            }

                            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                                string subtype = "";
                                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE!.Value, isRelatedToStructure: false);
                            }

                            AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);

                            bufferSurface["ps"] = ps101;
                            bufferSurface["code"] = instance.GetType().Name;
                            bufferSurface["edition"] = ImporterNIS.s101version;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(bufferSurface, current.SHAPE);
                            SetUsageBand(bufferSurface, current.PLTS_COMP_SCALE!.Value);

                            var featureN = featureClass.CreateRow(bufferSurface);
                            var name = $"{featureN.Crc32()}";

                            if (FeatureRelations.Instance.HasSlaves(current.GLOBALID)) {
                                relatedEquipment!.CreateRelatedAreaEquipment(current, instance, featureN, instance.scaleMinimum);
                            }

                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name); 
                            
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
