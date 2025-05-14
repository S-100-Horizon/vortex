using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using System.Linq;
using S100Framework.DomainModel;
using ArcGIS.Core.Internal.CIM;
using ArcGIS.Desktop.Editing.Attributes;
using System.Text;
using System.Data;
using System.ComponentModel;
using VortexLoader;
using System;
using ArcGIS.Core.Geometry;
using Microsoft.AspNetCore.Http.HttpResults;
using S100Framework.Applications.Singletons;
using ArcGIS.Core.CIM;

namespace S100Framework.Applications
{
    internal class RelatedEquipment {
        Geodatabase _source;

        HashSet<(string TableName,int Subtype, Guid globalid)> _converted = new();

        public RelatedEquipment(Geodatabase source) {
            this._source = source;
        }

        internal topmark? GetTopMark(AidsToNavigationP structure) {
            var topmarks = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(topmark), structure.GLOBALID);

            if (topmarks == null || topmarks.Count() == 0) {
                return null;
            }

            if (topmarks.Count() > 1) {
                throw new NotSupportedException("Multiple related topmarks");
            }

            var relatedTopmark = topmarks.First();

            if (relatedTopmark != null) {

                List<colour>? topmarkColours = null;

                colourPattern? topmarkColourPattern = null;

                if (relatedTopmark.COLOUR != default) {
                    topmarkColours = ImporterNIS.GetColours(relatedTopmark.COLOUR);
                }

                if (relatedTopmark.COLPAT != default) {
                    topmarkColourPattern = ImporterNIS.GetColourPattern(relatedTopmark.COLPAT);
                }

                var topmark = new topmark() {
                    // TODO: shapeinformation #15 @https://geodatastyrelsen.atlassian.net/wiki/spaces/SOEKORT/pages/5070028848/S-57+to+S-101+Conversion+Action+Points?force_transition=910d1b59-0dc5-42d7-bd2c-a81edd431caf,

                };

                if (topmarkColours != null) {
                    topmark.colour = topmarkColours;
                }

                if (topmarkColourPattern.HasValue) {
                    topmark.colourPattern = topmarkColourPattern.Value;
                }

                if (relatedTopmark.TOPSHP.HasValue) {
                    topmark.topmarkDaymarkShape = EnumHelper.GetEnumValue<topmarkDaymarkShape>(relatedTopmark.TOPSHP.Value);
                }

                ConversionAnalytics.Instance.AddConverted("AidsToNavigationP", relatedTopmark.GLOBALID, "ATTRIBUTE. NO NAME AVAILABLE");

                return topmark;
            }
            return null;
        }

        internal bool HasRelatedSlaves(Guid globalid) {
            return FeatureRelations.Instance.GetRelatedCount(globalid) > 0;
        }



        internal Daymark? GetDayMark(AidsToNavigationP structure) {
            var daymarks = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(Daymark), structure.GLOBALID);

            if (daymarks == null || daymarks.Count() == 0) {
                return null;
            }

            if (daymarks.Count() > 1) {
                throw new NotSupportedException("Multiple related daymarks");
            }

            var relatedDaymark = daymarks.First();

            if (relatedDaymark != null) {

                List<colour>? daymarkColours = null;

                colourPattern? daymarkColourPattern = null;

                if (relatedDaymark.COLOUR != default) {
                    daymarkColours = ImporterNIS.GetColours(relatedDaymark.COLOUR);
                }

                if (relatedDaymark.COLPAT != default) {
                    daymarkColourPattern = ImporterNIS.GetColourPattern(relatedDaymark.COLPAT);
                }

                var daymark = new Daymark() {
                    // TODO: shapeinformation #15 @https://geodatastyrelsen.atlassian.net/wiki/spaces/SOEKORT/pages/5070028848/S-57+to+S-101+Conversion+Action+Points?force_transition=910d1b59-0dc5-42d7-bd2c-a81edd431caf,

                };

                if (daymarkColours != null) {
                    daymark.colour = daymarkColours;
                }

                if (daymarkColourPattern.HasValue) {
                    daymark.colourPattern = daymarkColourPattern.Value;
                }

                if (relatedDaymark.TOPSHP.HasValue) {
                    daymark.topmarkDaymarkShape = EnumHelper.GetEnumValue<topmarkDaymarkShape>(relatedDaymark.TOPSHP.Value);
                }

                ConversionAnalytics.Instance.AddConverted("AidsToNavigationP", relatedDaymark.GLOBALID, "ATTRIBUTE. NO NAME AVAILABLE");

                return daymark;
            }
            return null;
        }

        internal void CreateRelatedLineEquipment(S57Object structure, FeatureNode s101Object, string name, Geodatabase target, Geodatabase source) {
            throw new NotImplementedException();
        }

        internal void CreateRelatedAreaEquipment(S57Object structure, FeatureNode s101Object, string name, Geodatabase target, Geodatabase source) {
            var areaRelated = FeatureRelations.Instance.GetRelated(structure.GlobalId);

            var tableName = target.GetName("point");
            using var featureClass = target.OpenDataset<FeatureClass>(tableName);
            using var buffer = featureClass.CreateRowBuffer();

            // group structures per location
            var relatedPerLocation = areaRelated
                    .GroupBy(obj => (X:Math.Round(((MapPoint)obj.S57Object.Shape).X,7), Y:Math.Round(((MapPoint)obj.S57Object.Shape).Y,7), obj.S57Object.Shape.SpatialReference))
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
                    var lightSectored = Converters.CreateLightSectored(relatedLightSectored, source);

                    buffer["ps"] = ImporterNIS.ps101;
                    buffer["code"] = lightSectored.GetType().Name;
                    buffer["json"] = System.Text.Json.JsonSerializer.Serialize(lightSectored, ImporterNIS.jsonSerializerOptions);
                    ImporterNIS.SetShape(buffer, shape);

                    var featureN = featureClass.CreateRow(buffer);
                    var equipmentName = Convert.ToString(featureN["name"]);

                    if (equipmentName == null) {
                        throw new NotSupportedException("empty equipment name");
                    }

                    foreach (var relatedObject in relatedLightSectored) {

                        if (relatedObject.PLTS_Frel.DEST_FC == null) {
                            throw new NotSupportedException($"Empty PLTS_Frel.DEST_FC");
                        }
                        ConversionAnalytics.Instance.AddConverted(relatedObject.PLTS_Frel.DEST_FC, relatedObject.GlobalId, equipmentName ?? "Unknown equipment");
                        Logger.Current.DataObject(-1, relatedObject.PLTS_Frel.DEST_FC, equipmentName ?? "Unknown equipment name", System.Text.Json.JsonSerializer.Serialize(lightSectored));
                    }

                    // Add relation between master polygon and slave equipment
                    FeatureRelations.Instance.AddRelation(new(s101Object.GetType(), name), new(lightSectored.GetType(), equipmentName));

                }
                // 
                foreach (var relatedObject in relatedNonSectoredEquipment) {
                    if (relatedObject.S101Type == typeof(topmark))
                        continue;


                    if (relatedObject.S57Object != null && relatedObject.S101Type != null) {
                        var instance = ImporterNIS._converterRegistry.Convert(relatedObject.S57Object, relatedObject.S101Type);

                        buffer["ps"] = ImporterNIS.ps101;
                        buffer["code"] = instance.GetType().Name;
                        buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
                        ImporterNIS.SetShape(buffer, shape);

                        var featureN = featureClass.CreateRow(buffer);
                        var equipmentName = Convert.ToString(featureN["name"]);
                        if (equipmentName == null) {
                            throw new NotSupportedException("empty equipment name");
                        }

                        FeatureRelations.Instance.AddRelation(new(s101Object.GetType(), name), new(relatedObject.S101Type, equipmentName));

                        if (relatedObject.S57Object.TableName != null) {
                            ConversionAnalytics.Instance.AddConverted(relatedObject.S57Object.TableName, relatedObject.GlobalId, equipmentName ?? "Unknown equipment name");
                        }

                        if (equipmentName == null) {
                            throw new NotSupportedException("empty equipment name");
                        }

                        FeatureRelations.Instance.AddRelation(new(s101Object.GetType(), equipmentName), new(instance.GetType(), name));

                        Logger.Current.DataObject((int)featureN.GetObjectID(), relatedObject.S57Object.TableName ?? "Uknown table name", equipmentName ?? "Unknown equipment name", System.Text.Json.JsonSerializer.Serialize(instance));
                    }
                }
            }
        }

        internal void CreateRelatedPointEquipment(S57Object structure, FeatureNode s101Object, string name, Geodatabase target) {

            var key = (structure.TableName.ToLower(), structure.FcSubtype.Value, structure.GlobalId);
            if (_converted.Contains(key)) {
                throw new DuplicateNameException($"Related equipment already converted for {key}");
            }

            _converted.Add(key);

            // if all related equipments are topmarks - return. Topmarks have become attributes
            if (!FeatureRelations.Instance.GetRelated(structure.GlobalId).Any(e => e?.PLTS_Frel?.DEST_SUB?.ToLower() != "topmar_topmark"))
                return;

            var totalRelated = FeatureRelations.Instance.GetRelated(structure.GlobalId);
            
            var relatedLightSectored = totalRelated.Where(e => e.S101Type == typeof(LightSectored)).ToList();

            var relatedNonSectoredEquipment = totalRelated.Where(e => e.S101Type != typeof(LightSectored)).ToList();

            var tableName = target.GetName("point");
            using var featureClass = target.OpenDataset<FeatureClass>(tableName);
            using var buffer = featureClass.CreateRowBuffer();


            // IF SECTORED LIGHTS
            var related = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(LightSectored), structure.GlobalId);
            if (related.Count > 0) {
                var instance = ImporterNIS._converterRegistry.Convert(structure,typeof(LightSectored));

                buffer["ps"] = ImporterNIS.ps101;
                buffer["code"] = instance.GetType().Name;
                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
                ImporterNIS.SetShape(buffer, structure.Shape);

                var featureN = featureClass.CreateRow(buffer);
                var equipmentName = Convert.ToString(featureN["name"]);
                if (equipmentName == null) {
                    throw new NotSupportedException("empty equipment name");
                }

                foreach (var relatedObject in related) {
                    ConversionAnalytics.Instance.AddConverted(relatedObject.GetType().Name, relatedObject.GLOBALID, equipmentName);
                    Logger.Current.DataObject((int)featureN.GetObjectID(), relatedObject.TableName ?? "Uknown table name", equipmentName ?? "Unknown equipment name", System.Text.Json.JsonSerializer.Serialize(instance));
                }

                if (equipmentName == null) {
                    throw new NotSupportedException("empty equipment name");
                }

                FeatureRelations.Instance.AddRelation(new(s101Object.GetType(), equipmentName), new(instance.GetType(), name));
               // return;
            }
            
            // IF NOT SECTORED LIGHTS
            foreach (PltsSlave relatedObject in relatedNonSectoredEquipment) {
                if (relatedObject.S101Type == typeof(topmark))
                    continue;


                if (relatedObject.S57Object != null && relatedObject.S101Type != null) {
                    var instance = ImporterNIS._converterRegistry.Convert(relatedObject.S57Object, relatedObject.S101Type);

                    buffer["ps"] = ImporterNIS.ps101;
                    buffer["code"] = instance.GetType().Name;
                    buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
                    ImporterNIS.SetShape(buffer, structure.Shape);

                    var featureN = featureClass.CreateRow(buffer);
                    var equipmentName = Convert.ToString(featureN["name"]);
                    if (equipmentName == null) {
                        throw new NotSupportedException("empty equipment name");
                    }

                    if (relatedObject.S57Object.TableName != null) {
                        ConversionAnalytics.Instance.AddConverted(relatedObject.S57Object.TableName, relatedObject.GlobalId, equipmentName ?? "Unknown equipment name");
                    }

                    if (equipmentName == null) {
                        throw new NotSupportedException("empty equipment name");
                    }

                    FeatureRelations.Instance.AddRelation(new(s101Object.GetType(), equipmentName), new(instance.GetType(), name));

                    Logger.Current.DataObject((int)featureN.GetObjectID(), relatedObject.S57Object.TableName ?? "Uknown table name", equipmentName ?? "Unknown equipment name", System.Text.Json.JsonSerializer.Serialize(instance));

                }
            }

            //if (s57Object is AidsToNavigationP) {
            //    var sourceTable = "AidsToNavigationP";
            //    var structure = (AidsToNavigationP)s57Object;
            //    bool hasRelated = FeatureRelations.Instance.HasRelated(structure.GLOBALID);
            //    if (!hasRelated) {
            //        return;
            //    }

            //    var tableName = target.GetName("point");
            //    using var featureClass = target.OpenDataset<FeatureClass>(tableName);
            //    using var buffer = featureClass.CreateRowBuffer();

            //    //var types = FeatureRelations.GetS101CatlitTypeFrom(structure);

            //    var related = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(LightSectored), structure.GLOBALID);

            //    if (related == null) {
            //        throw new NotSupportedException("empty relationships");
            //    }

            //    var hasRelatedSectoredLights = related.Any();

            //    if (hasRelatedSectoredLights) {
            //        var instance = ImporterNIS._converterRegistry.ConvertList<LightSectored>(related);

            //        if (structure.PLTS_COMP_SCALE.HasValue && structure.SHAPE != null) {
            //            instance.scaleMinimum = Scamin.Instance.GetMinimumScale(structure.SHAPE, "LIGHTS_Light", PrimitiveType.Point, structure.PLTS_COMP_SCALE.Value);
            //        }

            //        buffer["ps"] = ImporterNIS.ps101;
            //        buffer["code"] = instance.GetType().Name;
            //        buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
            //        ImporterNIS.SetShape(buffer, structure.SHAPE);

            //        var featureN = featureClass.CreateRow(buffer);
            //        var equipmentName = Convert.ToString(featureN["name"]);

            //        if (equipmentName == null) {
            //            throw new NotSupportedException("empty equipment name");
            //        }

            //        ConversionAnalytics.Instance.AddConverted(sourceTable, related.ToDictionary(obj => obj.GLOBALID, obj => new List<string> { equipmentName }));
            //        aidsToNavigationConverted = true;

            //        FeatureRelations.Instance.AddRelation(new(s101Object.GetType(), equipmentName), new(instance.GetType(), name));

            //        Logger.Current.DataObject((int)featureN.GetObjectID(), tableName ?? "Uknown table name", equipmentName, System.Text.Json.JsonSerializer.Serialize(instance));

            //        return;
            //    }

            //    related = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(LightAllAround), structure.GLOBALID);
            //    if (related == null) {
            //        throw new NotSupportedException("empty relationships");
            //    }

            //    var hasRelatedLightsAllAround = related.Any();
            //    if (hasRelatedLightsAllAround) {
            //        foreach (var light in related) {
            //            //var _slave = pltsSlave.Fetch(_source, Direction.Destination);
            //            var instance = ImporterNIS._converterRegistry.Convert<LightAllAround>(light);

            //            if (structure.PLTS_COMP_SCALE.HasValue && structure.SHAPE != null) {
            //                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(structure.SHAPE, "LIGHTS_Light", PrimitiveType.Point, structure.PLTS_COMP_SCALE.Value);
            //            }


            //            buffer["ps"] = ImporterNIS.ps101;
            //            buffer["code"] = instance.GetType().Name;
            //            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
            //            ImporterNIS.SetShape(buffer, light.SHAPE);

            //            var featureN = featureClass.CreateRow(buffer);
            //            var equipmentName = Convert.ToString(featureN["name"]);
            //            if (equipmentName == null) {
            //                throw new NotSupportedException("empty equipment name");
            //            }

            //            ConversionAnalytics.Instance.AddConverted(sourceTable, light.GLOBALID, equipmentName ?? "Unknown equipment name");
            //            aidsToNavigationConverted = true;

            //            if (equipmentName == null) {
            //                throw new NotSupportedException("empty equipment name");
            //            }

            //            FeatureRelations.Instance.AddRelation(new(s101Object.GetType(), equipmentName), new(instance.GetType(), name));

            //            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName ?? "Uknown table name", equipmentName ?? "Unknown equipment name", System.Text.Json.JsonSerializer.Serialize(instance));
            //        }
            //        return;
            //    }

            //    if (!aidsToNavigationConverted) {
            //        var relatedObjects = FeatureRelations.Instance.GetRelated(s57Object.GlobalId);
            //        StringBuilder info = new();
            //        foreach (var relatedObject in relatedObjects) {
            //            info.Append($"{relatedObject.PLTS_Frel.SRC_SUB}::{relatedObject.PLTS_Frel.DEST_SUB}");
            //        }
            //        throw new NotSupportedException($"{structure.GetType().Name}: {info.ToString()}");
            //    }
            //}

            //else if (s57Object is CulturalFeaturesP) {
            //    var structure = (CulturalFeaturesP)s57Object;
            //    bool hasRelated = FeatureRelations.Instance.HasRelated(structure.GLOBALID);
            //    if (!hasRelated) {
            //        return;
            //    }

            //    var tableName = target.GetName("point");
            //    var featureClass = target.OpenDataset<FeatureClass>(tableName);
            //    var buffer = featureClass.CreateRowBuffer();

            //    //var types = FeatureRelations.GetS101CatlitTypeFrom(structure);

            //    var related = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(LightSectored), structure.GLOBALID);
            //    if (related == null) {
            //        throw new NotSupportedException("empty relationships");
            //    }
            //    var hasRelatedSectoredLights = related.Any();
            //    if (hasRelatedSectoredLights) {
            //        var instance = ImporterNIS._converterRegistry.ConvertList<LightSectored>(related);

            //        if (structure.PLTS_COMP_SCALE.HasValue && structure.SHAPE != null) {
            //            instance.scaleMinimum = Scamin.Instance.GetMinimumScale(structure.SHAPE, "LIGHTS_Light", PrimitiveType.Point, structure.PLTS_COMP_SCALE.Value);
            //        }

            //        buffer["ps"] = ImporterNIS.ps101;
            //        buffer["code"] = instance.GetType().Name;
            //        buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
            //        ImporterNIS.SetShape(buffer, structure.SHAPE);

            //        var featureN = featureClass.CreateRow(buffer);
            //        var equipmentName = Convert.ToString(featureN["name"]);
            //        if (equipmentName == null) {
            //            throw new NotSupportedException("empty equipment name");
            //        }
            //        culturalFeaturesPConverted = true;
            //        foreach (var rel in related) {
            //            ConversionAnalytics.Instance.AddConverted(rel.GetType().Name, rel.GLOBALID, equipmentName);
            //        }

            //        FeatureRelations.Instance.AddRelation(new(s101Object.GetType(), equipmentName), new(instance.GetType(), name));

            //        Logger.Current.DataObject((int)featureN.GetObjectID(), tableName ?? "Uknown table name", equipmentName ?? "Unknown equipment name", System.Text.Json.JsonSerializer.Serialize(instance));
            //    }

            //    related = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(LightAllAround), structure.GLOBALID);
            //    var hasRelatedLightsAllAround = related.Any();
            //    if (hasRelatedLightsAllAround) {
            //        foreach (var light in related) {
            //            //var _slave = pltsSlave.Fetch(_source, Direction.Destination);
            //            var instance = ImporterNIS._converterRegistry.Convert<LightAllAround>(light);

            //            if (light.PLTS_COMP_SCALE.HasValue && light.SHAPE != null) {
            //                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(light.SHAPE, "LIGHTS_Light", PrimitiveType.Point, light.PLTS_COMP_SCALE.Value);
            //            }

            //            buffer["ps"] = ImporterNIS.ps101;
            //            buffer["code"] = instance.GetType().Name;
            //            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
            //            ImporterNIS.SetShape(buffer, light.SHAPE);

            //            culturalFeaturesPConverted = true;

            //            var featureN = featureClass.CreateRow(buffer);
            //            var equipmentName = Convert.ToString(featureN["name"]);

            //            if (equipmentName == null) {
            //                throw new NotSupportedException("empty equipment name");
            //            }

            //            FeatureRelations.Instance.AddRelation(new(s101Object.GetType(), equipmentName), new(instance.GetType(), name));


            //            ConversionAnalytics.Instance.AddConverted("AidsToNavigationP", light.GLOBALID, equipmentName);


            //            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName ?? "Uknown table name", equipmentName ?? "Unknown equipment name", System.Text.Json.JsonSerializer.Serialize(instance));
            //        }
            //        return;
            //    }

            //    related = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(LightAirObstruction), structure.GLOBALID);
            //    var hasRelatedLightsAirObstruction = related.Any();
            //    if (hasRelatedLightsAirObstruction) {
            //        foreach (var light in related) {
            //            //var _slave = pltsSlave.Fetch(_source, Direction.Destination);
            //            var instance = ImporterNIS.CreateLightAirObstruction(light);

            //            if (light.PLTS_COMP_SCALE.HasValue && light.SHAPE != null) {
            //                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(light.SHAPE, "LIGHTS_Light", PrimitiveType.Point, light.PLTS_COMP_SCALE.Value);
            //            }

            //            buffer["ps"] = ImporterNIS.ps101;
            //            buffer["code"] = instance.GetType().Name;
            //            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
            //            ImporterNIS.SetShape(buffer, light.SHAPE);

            //            culturalFeaturesPConverted = true;

            //            var featureN = featureClass.CreateRow(buffer);
            //            var equipmentName = Convert.ToString(featureN["name"]);

            //            if (equipmentName == null) {
            //                throw new NotSupportedException("empty equipment name");
            //            }

            //            FeatureRelations.Instance.AddRelation(new(s101Object.GetType(), equipmentName), new(instance.GetType(), name));


            //            ConversionAnalytics.Instance.AddConverted("AidsToNavigationP", light.GLOBALID, equipmentName);


            //            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName ?? "Uknown table name", equipmentName ?? "Unknown equipment name", System.Text.Json.JsonSerializer.Serialize(instance));
            //        }
            //        return;
            //    }

            //    related = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(RadarTransponderBeacon), structure.GLOBALID);
            //    var hasRelatedRadarTransponder = related.Any();
            //    if (hasRelatedRadarTransponder) {
            //        foreach (var radarTransponder in related) {
            //            var instance = ImporterNIS.CreateRadarTransponderBeacon(radarTransponder);

            //            if (radarTransponder.PLTS_COMP_SCALE.HasValue && radarTransponder.SHAPE != null) {
            //                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(radarTransponder.SHAPE, "LIGHTS_Light", PrimitiveType.Point, radarTransponder.PLTS_COMP_SCALE.Value);
            //            }

            //            buffer["ps"] = ImporterNIS.ps101;
            //            buffer["code"] = instance.GetType().Name;
            //            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
            //            ImporterNIS.SetShape(buffer, radarTransponder.SHAPE);

            //            culturalFeaturesPConverted = true;

            //            var featureN = featureClass.CreateRow(buffer);
            //            var equipmentName = Convert.ToString(featureN["name"]);

            //            if (equipmentName == null) {
            //                throw new NotSupportedException("empty equipment name");
            //            }

            //            FeatureRelations.Instance.AddRelation(new(s101Object.GetType(), equipmentName), new(instance.GetType(), name));

            //            ConversionAnalytics.Instance.AddConverted("AidsToNavigationP", radarTransponder.GLOBALID, equipmentName);

            //            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName ?? "Uknown table name", equipmentName ?? "Unknown equipment name", System.Text.Json.JsonSerializer.Serialize(instance));

            //            ;
            //        }
            //    }

            //    related = FeatureRelations.Instance.GetRelated<AidsToNavigationP>(typeof(Daymark), structure.GLOBALID);
            //    var hasRelatedDaymark = related.Any();
            //    if (hasRelatedDaymark) {
            //        foreach (var daymark in related) {
            //            var instance = ImporterNIS.CreateDaymark(daymark);

            //            if (daymark.PLTS_COMP_SCALE.HasValue && daymark.SHAPE != null) {
            //                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(daymark.SHAPE, "LIGHTS_Light", PrimitiveType.Point, daymark.PLTS_COMP_SCALE.Value);
            //            }

            //            buffer["ps"] = ImporterNIS.ps101;
            //            buffer["code"] = instance.GetType().Name;
            //            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
            //            ImporterNIS.SetShape(buffer, daymark.SHAPE);

            //            culturalFeaturesPConverted = true;

            //            var featureN = featureClass.CreateRow(buffer);
            //            var equipmentName = Convert.ToString(featureN["name"]);

            //            if (equipmentName == null) {
            //                throw new NotSupportedException("empty equipment name");
            //            }

            //            FeatureRelations.Instance.AddRelation(new(s101Object.GetType(), equipmentName), new(instance.GetType(), name));

            //            ConversionAnalytics.Instance.AddConverted("AidsToNavigationP", daymark.GLOBALID, equipmentName);

            //            Logger.Current.DataObject((int)featureN.GetObjectID(), tableName ?? "Uknown table name", equipmentName ?? "Unknown equipment name", System.Text.Json.JsonSerializer.Serialize(instance));

            //            ;
            //        }
            //    }


            //    var relatedLandmarks = FeatureRelations.Instance.GetRelated<CulturalFeaturesP>(typeof(Landmark), structure.GLOBALID);
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
            //        throw new NotSupportedException($"{structure.GetType().Name}: {info.ToString()}");
            //    }

            //}

            //else {
            //    throw new NotSupportedException($"{s57Object.GetType()}");
            //}

            foreach  (var plts in totalRelated) {
                if (!ConversionAnalytics.Instance.IsConverted(plts.S57Object.GlobalId)) {
                    // TODO: handle missing related - TOMOREDO: REFACTURE!!!
                    ;
                }
            }



        }

    }
}