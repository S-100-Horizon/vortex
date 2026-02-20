using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using S100FC;
using S100FC.S101.ComplexAttributes;
using S100FC.S101.FeatureTypes;
using S100FC.S101.SimpleAttributes;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using System.Data;

namespace S100Framework.Applications
{
    internal class RelatedEquipment
    {
        readonly Geodatabase _source;
        readonly Geodatabase _target;

        readonly HashSet<(string TableName, int Subtype, Guid globalid)> _converted = [];

        readonly HashSet<string> _relations = [];

        public RelatedEquipment(Geodatabase source, Geodatabase target) {
            this._source = source;
            this._target = target;
        }

        internal topmark? GetTopMark<TType>(AidsToNavigationP structure) where TType : S100FC.FeatureType {
            var topmarks = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(topmark), structure.GLOBALID);

            if (topmarks == null || topmarks.Count() == 0) {
                return null;
            }

            if (topmarks.Count() > 1) {
                throw new NotSupportedException("Multiple related topmarks");
            }

            var relatedTopmark = topmarks.First();

            if (relatedTopmark != null) {

                int?[]? topmarkColours = null;

                colourPattern? topmarkColourPattern = null;

                if (relatedTopmark.COLOUR != default) {
                    topmarkColours = ImporterNIS.GetColours(relatedTopmark.COLOUR);
                }

                if (relatedTopmark.COLPAT != default) {
                    topmarkColourPattern = ImporterNIS.GetColourPattern(relatedTopmark.COLPAT);
                }

                var topmark = new topmark() {
                    //topmarkDaymarkShape = default,
                    // TODO: shapeinformation #15 @https://geodatastyrelsen.atlassian.net/wiki/spaces/SOEKORT/pages/5070028848/S-57+to+S-101+Conversion+Action+Points?force_transition=910d1b59-0dc5-42d7-bd2c-a81edd431caf,

                };

                if (topmarkColours != null) {
                    topmark.colour = topmarkColours;
                }

                if (topmarkColourPattern is not null) {
                    topmark.colourPattern = topmarkColourPattern.value;
                }

                if (relatedTopmark.TOPSHP.HasValue) {
                    topmark.topmarkDaymarkShape = EnumHelper.GetEnumValue(relatedTopmark.TOPSHP.Value);
                }

                ConversionAnalytics.Instance.AddConverted("AidsToNavigationP", relatedTopmark.GLOBALID, "ATTRIBUTE. NO NAME AVAILABLE");

                return topmark;
            }
            return null;
        }

        internal bool HasRelatedSlaves(Guid globalid) {
            return FeatureRelations.Instance.GetRelatedCount(globalid) > 0;
        }



        //internal Daymark? GetDayMark<TType>(AidsToNavigationP structure) where TType : DomainModel.FeatureNode {
        //    var daymarks = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(Daymark), structure.GLOBALID);

        //    if (daymarks == null || daymarks.Count() == 0) {
        //        return null;
        //    }

        //    if (daymarks.Count() > 1) {
        //        throw new NotSupportedException("Multiple related daymarks");
        //    }

        //    var relatedDaymark = daymarks.First();

        //    if (relatedDaymark != null) {

        //        List<colour>? daymarkColours = null;

        //        colourPattern? daymarkColourPattern = null;

        //        if (relatedDaymark.COLOUR != default) {
        //            daymarkColours = ImporterNIS.GetColours(relatedDaymark.COLOUR);
        //        }

        //        if (relatedDaymark.COLPAT != default) {
        //            daymarkColourPattern = ImporterNIS.GetColourPattern(relatedDaymark.COLPAT);
        //        }

        //        var daymark = new Daymark {
        //            topmarkDaymarkShape = default,
        //            // TODO: shapeinformation #15 @https://geodatastyrelsen.atlassian.net/wiki/spaces/SOEKORT/pages/5070028848/S-57+to+S-101+Conversion+Action+Points?force_transition=910d1b59-0dc5-42d7-bd2c-a81edd431caf,

        //        };

        //        if (daymarkColours != null) {
        //            daymark.colour = daymarkColours;
        //        }

        //        if (daymarkColourPattern.HasValue) {
        //            daymark.colourPattern = daymarkColourPattern.Value;
        //        }

        //        if (relatedDaymark.TOPSHP.HasValue) {
        //            daymark.topmarkDaymarkShape = EnumHelper.GetEnumValue(relatedDaymark.TOPSHP.Value);
        //        }

        //        ConversionAnalytics.Instance.AddConverted("AidsToNavigationP", relatedDaymark.GLOBALID, "ATTRIBUTE. NO NAME AVAILABLE");

        //        return daymark;
        //    }
        //    return null;
        //}

        internal void CreateRelatedLineEquipment(S57Object s57master, FeatureType s101master, Feature s101MasterFeature) {
            throw new NotImplementedException();
        }

        internal void CreateRelatedAreaEquipment(S57Object s57master, FeatureType s101master, Feature s101MasterFeature, int? scaleMinimum) {
            var areaRelated = FeatureRelations.Instance.GetRelated(s57master.GlobalId);

            //var nullS57Objects = areaRelated
            //        .Where(obj => obj.S57Object == null)
            //        .ToList();

            //if (nullS57Objects.Count > 0) {
            //    ;
            //}

            //if (areaRelated.Count == nullS57Objects.Count || nullS57Objects.Count > 0) {
            //    return;
            //}
            //else {
            //    ;
            //}

            var tableName = this._target.GetName("point");
            using var featureClass = this._target.OpenDataset<FeatureClass>(tableName);
            using var buffer = featureClass.CreateRowBuffer();

            // group structures per location
            var relatedPerLocation = areaRelated
                    .GroupBy(obj => (X: Math.Round(((MapPoint)obj.S57Object!.Shape!).X, 7), Y: Math.Round(((MapPoint)obj.S57Object.Shape).Y, 7), obj.S57Object.Shape.SpatialReference))
                    .ToDictionary(
                        group => group.Key,
                        group => group.ToList()
                    );

            // light sectored
            foreach (var location in relatedPerLocation.Keys) {
                var allRelatedLocationEquipment = relatedPerLocation[location];
                var relatedLightSectored = relatedPerLocation[location].Where(e => e.S101Type == typeof(LightSectored)).ToList();

                var relatedNonSectoredEquipment = relatedPerLocation[location].Where(e => e.S101Type != typeof(LightSectored)).ToList();

                var shape = MapPointBuilderEx.CreateMapPoint(location.X, location.Y, location.SpatialReference);

                // Sectoredlights
                if (relatedLightSectored.Count > 0) {
                    var lightSectored = Converters.CreateLightSectored(relatedLightSectored, scaleMinimum, this._source);

                    buffer["ps"] = ImporterNIS.ps101;
                    buffer["code"] = lightSectored.GetType().Name;

                    buffer["flatten"] = lightSectored.Flatten();
                    buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize(lightSectored.GetInformationBindings(), ImporterNIS.jsonSerializerOptions);  //System.Text.Json.JsonSerializer.Serialize(lightSectored.GetInformationBindings(), jsonSerializerOptions);

                    ImporterNIS.SetShape(buffer, shape);
                    ImporterNIS.SetUsageBand(buffer, s57master!.PLTS_COMP_SCALE!.Value);

                    var featureN = featureClass.CreateRow(buffer);
                    var equipmentName = featureN.UID();

                    if (equipmentName == null || string.IsNullOrEmpty(equipmentName)) {
                        throw new NotSupportedException("empty equipment name");
                    }

                    foreach (var relatedObject in relatedLightSectored) {

                        if (relatedObject.PLTS_Frel.DEST_FC == null) {
                            throw new NotSupportedException($"Empty PLTS_Frel.DEST_FC");
                        }
                        ConversionAnalytics.Instance.AddConverted(relatedObject.PLTS_Frel.DEST_FC, relatedObject.GlobalId, equipmentName ?? "Unknown equipment");
                        Logger.Current.DataObject(-1, relatedObject.S57Object!.TableName!, equipmentName ?? "Unknown equipment name", System.Text.Json.JsonSerializer.Serialize(lightSectored, ImporterNIS.jsonSerializerOptions));
                    }

                    // Add relation between s57master polygon and slave equipment

                    // TODO: ENABLE THIS 
                    FeatureRelations.Instance.AddRelation(new(s101master.GetType(), s101MasterFeature.UID()), new(lightSectored.GetType(), equipmentName!), featureN, s101MasterFeature);
                }
                // 
                foreach (var relatedObject in relatedNonSectoredEquipment) {
                    if (relatedObject.S101Type == typeof(topmark))
                        continue;


                    if (relatedObject.S57Object != null && relatedObject.S101Type != null) {
                        var instance = ImporterNIS._converterRegistry.Convert(relatedObject.S57Object, relatedObject.S101Type, scaleMinimum);

                        if (instance == null)
                            return;

                        buffer["ps"] = ImporterNIS.ps101;
                        buffer["code"] = instance.GetType().Name;

                        buffer["flatten"] = ((FeatureType)instance).Flatten();
                        if (instance is FeatureType) {
                            buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize((instance as FeatureType)!.GetInformationBindings(), ImporterNIS.jsonSerializerOptions);
                        }
                        else {
                            ;
                        }

                        ImporterNIS.SetShape(buffer, shape);
                        ImporterNIS.SetUsageBand(buffer, relatedObject.S57Object!.PLTS_COMP_SCALE!.Value);

                        var featureN = featureClass.CreateRow(buffer);
                        var equipmentName = featureN.UID();
                        if (equipmentName == null) {
                            throw new NotSupportedException("empty equipment name");
                        }

                        FeatureRelations.Instance.AddRelation(new(s101master.GetType(), s101MasterFeature.UID()), new(relatedObject.S101Type, equipmentName), featureN, s101MasterFeature);

                        if (relatedObject.S57Object.TableName != null) {
                            ConversionAnalytics.Instance.AddConverted(relatedObject.S57Object.TableName, relatedObject.GlobalId, equipmentName ?? "Unknown equipment name");
                        }

                        if (equipmentName == null) {
                            throw new NotSupportedException("empty equipment name");
                        }

                        // TODO: ENABLE THIS 
                        //FeatureRelations.Instance.AddRelation(new(s101master.GetType(), equipmentName), new(instance.GetType(), name));

                        Logger.Current.DataObject((int)featureN.GetObjectID(), relatedObject.S57Object.TableName ?? "Uknown table name", equipmentName ?? "Unknown equipment name", System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                    }
                }
            }
        }

        // S57Object s57master, FeatureNode s101master, Feature s101MasterFeature
        internal void CreateRelatedPointEquipment(S57Object s57master, FeatureType s101master, Feature s101MasterFeature, int? scaleMinimum) {

            var key = (s57master.TableName!.ToLower(), s57master.FcSubtype!.Value, s57master.GlobalId);
            if (this._converted.Contains(key)) {
                throw new DuplicateNameException($"Related equipment already converted for {key}");
            }

            this._converted.Add(key);

            // if all related equipments are topmarks - return. Topmarks have become attributes
            if (!FeatureRelations.Instance.GetRelated(s57master.GlobalId).Any(e => e?.PLTS_Frel?.DEST_SUB?.ToLower() != "topmar_topmark"))
                return;

            var totalRelated = FeatureRelations.Instance.GetRelated(s57master.GlobalId);

            var relatedLightSectored = totalRelated.Where(e => e.S101Type == typeof(LightSectored)).ToList();

            var relatedNonSectoredEquipment = totalRelated.Where(e => e.S101Type != typeof(LightSectored)).ToList();

            var tableName = this._target.GetName("point");
            using var featureClass = this._target.OpenDataset<FeatureClass>(tableName);
            using var buffer = featureClass.CreateRowBuffer();


            // IF SECTORED LIGHTS
            var related = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(LightSectored), s57master.GlobalId);
            if (related.Count > 0) {
                var instance = ImporterNIS._converterRegistry.Convert(s57master, typeof(LightSectored), scaleMinimum);

                buffer["ps"] = ImporterNIS.ps101;
                buffer["code"] = instance.GetType().Name;

                buffer["flatten"] = ((FeatureType)instance).Flatten();
                if (instance is FeatureType) {
                    buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize((instance as FeatureType)!.GetInformationBindings(), ImporterNIS.jsonSerializerOptions);
                }
                else {
                    ;
                }


                ImporterNIS.SetShape(buffer, s57master.Shape);
                ImporterNIS.SetUsageBand(buffer, s57master!.PLTS_COMP_SCALE!.Value);

                var featureN = featureClass.CreateRow(buffer);
                var equipmentName = featureN.UID();
                if (equipmentName == null) {
                    throw new NotSupportedException("empty equipment name");
                }

                foreach (var relatedObject in related) {
                    ConversionAnalytics.Instance.AddConverted(relatedObject.GetType().Name, relatedObject.GLOBALID, equipmentName!);
                    Logger.Current.DataObject((int)featureN.GetObjectID(), relatedObject.TableName ?? "Uknown table name", equipmentName ?? "Unknown equipment name", System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
                }

                if (equipmentName == null) {
                    throw new NotSupportedException("empty equipment name");
                }

                FeatureRelations.Instance.AddRelation(new(s101master.GetType(), s101MasterFeature.UID()), new(instance.GetType(), equipmentName), featureN, s101MasterFeature);

                // return;
            }

            // IF NOT SECTORED LIGHTS
            foreach (PltsSlave relatedObject in relatedNonSectoredEquipment) {
                if (relatedObject.S101Type == typeof(topmark)) {
                    continue;
                }

                //if (ConversionAnalytics.Instance.IsConverted(relatedObject.GlobalId)) { 
                //    continue; 
                //}

                if (relatedObject.S57Object != null && relatedObject.S101Type != null) {
                    var instance = ImporterNIS._converterRegistry.Convert(relatedObject.S57Object, relatedObject.S101Type, scaleMinimum);

                    if (instance == null) {
                        return;
                    }

                    buffer["ps"] = ImporterNIS.ps101;
                    buffer["code"] = instance.GetType().Name;

                    buffer["flatten"] = ((FeatureType)instance).Flatten();

                    if (instance is FeatureType) {
                        buffer["informationbindings"] = System.Text.Json.JsonSerializer.Serialize((instance as FeatureType)!.GetInformationBindings(), ImporterNIS.jsonSerializerOptions);
                    }
                    else {
                        ;
                    }

                    ImporterNIS.SetShape(buffer, s57master.Shape);
                    ImporterNIS.SetUsageBand(buffer, s57master.PLTS_COMP_SCALE!.Value);

                    var featureN = featureClass.CreateRow(buffer);
                    var equipmentName = featureN.UID();
                    if (equipmentName == null) {
                        throw new NotSupportedException("empty equipment name");
                    }

                    if (relatedObject.S57Object.TableName != null) {
                        ConversionAnalytics.Instance.AddConverted(relatedObject.S57Object.TableName, relatedObject.GlobalId, equipmentName ?? "Unknown equipment name");
                    }

                    if (equipmentName == null) {
                        throw new NotSupportedException("empty equipment name");
                    }

                    //FeatureRelations.Instance.AddRelation(new(s101master.GetType(), equipmentName), new(instance.GetType(), s101MasterFeature["name"].ToString()),buffer, s101structure);
                    FeatureRelations.Instance.AddRelation(new(s101master.GetType(), s101MasterFeature.UID()), new(instance.GetType(), equipmentName), featureN, s101MasterFeature);
                    featureN.Store();

                    Logger.Current.DataObject((int)featureN.GetObjectID(), relatedObject.S57Object.TableName ?? "Uknown table name", equipmentName ?? "Unknown equipment name", System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

                }
                else {
                    Logger.Current.DataError(-1, relatedObject.PLTS_Frel.TableName!, "", $"Broken FREL relationship {relatedObject.PLTS_Frel.SRC_FC}::{relatedObject.PLTS_Frel.SRC_LNAM} -> {relatedObject.PLTS_Frel.DEST_FC}::{relatedObject.PLTS_Frel.DEST_LNAM}");
                    continue;
                    //throw new NotSupportedException("Relation without related object or related object Type information.");
                }
            }

            //if (s57Object is AidsToNavigationP) {
            //    var sourceTable = "AidsToNavigationP";
            //    var s57master = (AidsToNavigationP)s57Object;
            //    bool hasRelated = FeatureRelations.Instance.HasSlaves(s57master.GLOBALID);
            //    if (!hasRelated) {
            //        return;
            //    }

            //    var tableName = target.GetName("point");
            //    using var featureClass = target.OpenDataset<FeatureClass>(tableName);
            //    using var buffer = featureClass.CreateRowBuffer();

            //    //var types = FeatureRelations.GetS101CatlitTypeFrom(s57master);

            //    var related = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(LightSectored), s57master.GLOBALID);

            //    if (related == null) {
            //        throw new NotSupportedException("empty relationships");
            //    }

            //    var hasRelatedSectoredLights = related.Any();

            //    if (hasRelatedSectoredLights) {
            //        var instance = ImporterNIS._converterRegistry.ConvertList<LightSectored>(related);

            //        if (s57master.PLTS_COMP_SCALE.HasValue && s57master.SHAPE != null) {
            //            instance.scaleMinimum = Scamin.Instance.GetMinimumScale(s57master.SHAPE, "LIGHTS_Light", PrimitiveType.Point, s57master.PLTS_COMP_SCALE.Value);
            //        }

            //        buffer["ps"] = ImporterNIS.ps101;
            //
            //                    buffer["code"] = instance.GetType().Name;
            //                   
            //        //buffer["__json__"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
            //        SetShape(buffer, s57master.SHAPE);

            //        var featureN = featureClass.CreateRow(buffer);
            //        var equipmentName = featureN.Crc32();

            //        if (equipmentName == null) {
            //            throw new NotSupportedException("empty equipment name");
            //        }

            //        ConversionAnalytics.Instance.AddConverted(sourceTable, related.ToDictionary(obj => obj.GLOBALID, obj => new List<string> { equipmentName }));
            //        aidsToNavigationConverted = true;

            //        FeatureRelations.Instance.AddRelation(new(slave.GetType(), equipmentName), new(instance.GetType(), name));

            //        Logger.Current.DataObject((int)featureN.GetObjectID(), tableName ?? "Uknown table name", equipmentName, System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

            //        return;
            //    }

            //    related = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(LightAllAround), s57master.GLOBALID);
            //    if (related == null) {
            //        throw new NotSupportedException("empty relationships");
            //    }

            //    var hasRelatedLightsAllAround = related.Any();
            //    if (hasRelatedLightsAllAround) {
            //        foreach (var light in related) {
            //            //var _slave = pltsSlave.Fetch(_source, Direction.Destination);
            //            var instance = ImporterNIS._converterRegistry.Convert<LightAllAround>(light);

            //            if (s57master.PLTS_COMP_SCALE.HasValue && s57master.SHAPE != null) {
            //                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(s57master.SHAPE, "LIGHTS_Light", PrimitiveType.Point, s57master.PLTS_COMP_SCALE.Value);
            //            }


            //            buffer["ps"] = ImporterNIS.ps101;
            //
            //                    buffer["code"] = instance.GetType().Name;
            //                    
            //            //buffer["__json__"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
            //            SetShape(buffer, light.SHAPE);

            //            var featureN = featureClass.CreateRow(buffer);
            //            var equipmentName = featureN.Crc32();
            //            if (equipmentName == null) {
            //                throw new NotSupportedException("empty equipment name");
            //            }

            //            ConversionAnalytics.Instance.AddConverted(sourceTable, light.GLOBALID, equipmentName ?? "Unknown equipment name");
            //            aidsToNavigationConverted = true;

            //            if (equipmentName == null) {
            //                throw new NotSupportedException("empty equipment name");
            //            }

            //            FeatureRelations.Instance.AddRelation(new(slave.GetType(), equipmentName), new(instance.GetType(), name));

            //            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName ?? "Uknown table name", equipmentName ?? "Unknown equipment name", System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
            //        }
            //        return;
            //    }

            //    if (!aidsToNavigationConverted) {
            //        var relatedObjects = FeatureRelations.Instance.GetRelated(s57Object.GlobalId);
            //        StringBuilder info = new();
            //        foreach (var relatedObject in relatedObjects) {
            //            info.Append($"{relatedObject.PLTS_Frel.SRC_SUB}::{relatedObject.PLTS_Frel.DEST_SUB}");
            //        }
            //        throw new NotSupportedException($"{s57master.GetType().Name}: {info.ToString()}");
            //    }
            //}

            //else if (s57Object is CulturalFeaturesP) {
            //    var s57master = (CulturalFeaturesP)s57Object;
            //    bool hasRelated = FeatureRelations.Instance.HasSlaves(s57master.GLOBALID);
            //    if (!hasRelated) {
            //        return;
            //    }

            //    var tableName = target.GetName("point");
            //    var featureClass = target.OpenDataset<FeatureClass>(tableName);
            //    var buffer = featureClass.CreateRowBuffer();

            //    //var types = FeatureRelations.GetS101CatlitTypeFrom(s57master);

            //    var related = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(LightSectored), s57master.GLOBALID);
            //    if (related == null) {
            //        throw new NotSupportedException("empty relationships");
            //    }
            //    var hasRelatedSectoredLights = related.Any();
            //    if (hasRelatedSectoredLights) {
            //        var instance = ImporterNIS._converterRegistry.ConvertList<LightSectored>(related);

            //        if (s57master.PLTS_COMP_SCALE.HasValue && s57master.SHAPE != null) {
            //            instance.scaleMinimum = Scamin.Instance.GetMinimumScale(s57master.SHAPE, "LIGHTS_Light", PrimitiveType.Point, s57master.PLTS_COMP_SCALE.Value);
            //        }

            //        buffer["ps"] = ImporterNIS.ps101;
            //
            //                    buffer["code"] = instance.GetType().Name;
            //                    
            //        //buffer["__json__"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
            //        SetShape(buffer, s57master.SHAPE);

            //        var featureN = featureClass.CreateRow(buffer);
            //        var equipmentName = featureN.Crc32();
            //        if (equipmentName == null) {
            //            throw new NotSupportedException("empty equipment name");
            //        }
            //        culturalFeaturesPConverted = true;
            //        foreach (var rel in related) {
            //            ConversionAnalytics.Instance.AddConverted(rel.GetType().Name, rel.GLOBALID, equipmentName);
            //        }

            //        FeatureRelations.Instance.AddRelation(new(slave.GetType(), equipmentName), new(instance.GetType(), name));

            //        Logger.Current.DataObject((int)featureN.GetObjectID(), tableName ?? "Uknown table name", equipmentName ?? "Unknown equipment name", System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
            //    }

            //    related = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(LightAllAround), s57master.GLOBALID);
            //    var hasRelatedLightsAllAround = related.Any();
            //    if (hasRelatedLightsAllAround) {
            //        foreach (var light in related) {
            //            //var _slave = pltsSlave.Fetch(_source, Direction.Destination);
            //            var instance = ImporterNIS._converterRegistry.Convert<LightAllAround>(light);

            //            if (light.PLTS_COMP_SCALE.HasValue && light.SHAPE != null) {
            //                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(light.SHAPE, "LIGHTS_Light", PrimitiveType.Point, light.PLTS_COMP_SCALE.Value);
            //            }

            //            buffer["ps"] = ImporterNIS.ps101;
            //
            //                    buffer["code"] = instance.GetType().Name;
            //                    
            //            //buffer["__json__"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
            //            SetShape(buffer, light.SHAPE);

            //            culturalFeaturesPConverted = true;

            //            var featureN = featureClass.CreateRow(buffer);
            //            var equipmentName = featureN.Crc32();

            //            if (equipmentName == null) {
            //                throw new NotSupportedException("empty equipment name");
            //            }

            //            FeatureRelations.Instance.AddRelation(new(slave.GetType(), equipmentName), new(instance.GetType(), name));


            //            ConversionAnalytics.Instance.AddConverted("AidsToNavigationP", light.GLOBALID, equipmentName);


            //            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName ?? "Uknown table name", equipmentName ?? "Unknown equipment name", System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
            //        }
            //        return;
            //    }

            //    related = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(LightAirObstruction), s57master.GLOBALID);
            //    var hasRelatedLightsAirObstruction = related.Any();
            //    if (hasRelatedLightsAirObstruction) {
            //        foreach (var light in related) {
            //            //var _slave = pltsSlave.Fetch(_source, Direction.Destination);
            //            var instance = ImporterNIS.CreateLightAirObstruction(light);

            //            if (light.PLTS_COMP_SCALE.HasValue && light.SHAPE != null) {
            //                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(light.SHAPE, "LIGHTS_Light", PrimitiveType.Point, light.PLTS_COMP_SCALE.Value);
            //            }

            //            buffer["ps"] = ImporterNIS.ps101;
            //
            // buffer["code"] = instance.GetType().Name;
            //                    
            //            //buffer["__json__"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
            //            SetShape(buffer, light.SHAPE);

            //            culturalFeaturesPConverted = true;

            //            var featureN = featureClass.CreateRow(buffer);
            //            var equipmentName = featureN.Crc32();

            //            if (equipmentName == null) {
            //                throw new NotSupportedException("empty equipment name");
            //            }

            //            FeatureRelations.Instance.AddRelation(new(slave.GetType(), equipmentName), new(instance.GetType(), name));


            //            ConversionAnalytics.Instance.AddConverted("AidsToNavigationP", light.GLOBALID, equipmentName);


            //            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName ?? "Uknown table name", equipmentName ?? "Unknown equipment name", System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));
            //        }
            //        return;
            //    }

            //    related = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(RadarTransponderBeacon), s57master.GLOBALID);
            //    var hasRelatedRadarTransponder = related.Any();
            //    if (hasRelatedRadarTransponder) {
            //        foreach (var radarTransponder in related) {
            //            var instance = ImporterNIS.CreateRadarTransponderBeacon(radarTransponder);

            //            if (radarTransponder.PLTS_COMP_SCALE.HasValue && radarTransponder.SHAPE != null) {
            //                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(radarTransponder.SHAPE, "LIGHTS_Light", PrimitiveType.Point, radarTransponder.PLTS_COMP_SCALE.Value);
            //            }

            //            buffer["ps"] = ImporterNIS.ps101;
            //
            //                    buffer["code"] = instance.GetType().Name;
            //                    
            //            //buffer["__json__"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
            //            SetShape(buffer, radarTransponder.SHAPE);

            //            culturalFeaturesPConverted = true;

            //            var featureN = featureClass.CreateRow(buffer);
            //            var equipmentName = featureN.Crc32();

            //            if (equipmentName == null) {
            //                throw new NotSupportedException("empty equipment name");
            //            }

            //            FeatureRelations.Instance.AddRelation(new(slave.GetType(), equipmentName), new(instance.GetType(), name));

            //            ConversionAnalytics.Instance.AddConverted("AidsToNavigationP", radarTransponder.GLOBALID, equipmentName);

            //            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName ?? "Uknown table name", equipmentName ?? "Unknown equipment name", System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

            //            ;
            //        }
            //    }

            //    related = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(Daymark), s57master.GLOBALID);
            //    var hasRelatedDaymark = related.Any();
            //    if (hasRelatedDaymark) {
            //        foreach (var daymark in related) {
            //            var instance = ImporterNIS.CreateDaymark(daymark);

            //            if (daymark.PLTS_COMP_SCALE.HasValue && daymark.SHAPE != null) {
            //                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(daymark.SHAPE, "LIGHTS_Light", PrimitiveType.Point, daymark.PLTS_COMP_SCALE.Value);
            //            }

            //            buffer["ps"] = ImporterNIS.ps101;
            //
            //                    buffer["code"] = instance.GetType().Name;
            //                    
            //            //buffer["__json__"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
            //            SetShape(buffer, daymark.SHAPE);

            //            culturalFeaturesPConverted = true;

            //            var featureN = featureClass.CreateRow(buffer);
            //            var equipmentName = featureN.Crc32();

            //            if (equipmentName == null) {
            //                throw new NotSupportedException("empty equipment name");
            //            }

            //            FeatureRelations.Instance.AddRelation(new(slave.GetType(), equipmentName), new(instance.GetType(), name));

            //            ConversionAnalytics.Instance.AddConverted("AidsToNavigationP", daymark.GLOBALID, equipmentName);

            //            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName ?? "Uknown table name", equipmentName ?? "Unknown equipment name", System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions));

            //            ;
            //        }
            //    }


            //    var relatedLandmarks = FeatureRelations.Instance.GetRelated<CulturalFeaturesP>(typeof(Landmark), s57master.GLOBALID);
            //    var hasRelatedLandmarks = relatedLandmarks.Any();
            //    if (hasRelatedLandmarks) {
            //        throw new NotSupportedException("related landmark");
            //    }

            //    if (!culturalFeaturesPConverted) {
            //        var relatedObjects = FeatureRelations.Instance.GetRelated(s57Object.GlobalId);
            //        StringBuilder info = new();
            //        foreach (var relatedObject in relatedObjects) {
            //            info.Append($"{relatedObject.PLTS_Frel.SRC_SUB}::{relatedObject.PLTS_Frel.DEST_SUB}");
            //        }
            //        throw new NotSupportedException($"{s57master.GetType().Name}: {info.ToString()}");
            //    }

            //}

            //else {
            //    throw new NotSupportedException($"{s57Object.GetType()}");
            //}

            foreach (var plts in totalRelated) {
                if (!ConversionAnalytics.Instance.IsConverted(Guid.Parse(plts.PLTS_Frel.DEST_UID))) {
                    Logger.Current.DataError(-1, plts.PLTS_Frel.TableName!, "", $"Broken FREL relationship {plts.PLTS_Frel.SRC_FC}::{plts.PLTS_Frel.SRC_LNAM} -> {plts.PLTS_Frel.DEST_FC}::{plts.PLTS_Frel.DEST_LNAM}")
                    // TODO: handle missing related - TOMOREDO: REFACTURE!!!
                    ;
                }
            }



        }
    }
}