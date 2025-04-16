using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using System.Linq;

namespace S100Framework.Applications
{
    internal class RelatedEquipment
    {

        FeatureRelations _featureRelations;
        Geodatabase _source;

        public RelatedEquipment(Geodatabase source, FeatureRelations featureRelations) {
            this._featureRelations = featureRelations;
            this._source = source;
        }

        internal topmark GetTopMark(AidsToNavigationP structure) {
            var topmarks = _featureRelations.GetRelated<AidsToNavigationP>(typeof(topmark), structure.GLOBALID);

            if (topmarks == null || topmarks.Count() == 0) {
                return null;
            }

            if (topmarks.Count() > 1) {
                throw new NotSupportedException("Multiple related topmarks");
            }

            var relatedTopmark = topmarks.First();

            if (relatedTopmark != null) {

                List<colour> topmarkColours = null;

                colourPattern? topmarkColourPattern = null;

                if (relatedTopmark.COLOUR != default) {
                    topmarkColours = ImporterNIS.GetColours(relatedTopmark.COLOUR);
                }

                if (relatedTopmark.COLPAT != default) {
                    topmarkColourPattern = ImporterNIS.GetColourPattern(relatedTopmark.COLPAT);
                }

                var topmark = new topmark() {
                    // TODO: shapeinformation #15 @https://geodatastyrelsen.atlassian.net/wiki/spaces/SOEKORT/pages/5070028848/S-57+to+S-101+Conversion+Action+Points?force_transition=910d1b59-0dc5-42d7-bd2c-a81edd431caf,
                    shapeInformation = default
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
                return topmark;
            }
            return null;
        }

        internal bool HasRelatedSlaves(Guid globalid) {
            return _featureRelations.GetRelatedCount(globalid) > 0;
        }

        internal Daymark GetDayMark(AidsToNavigationP structure) {
            var daymarks = _featureRelations.GetRelated<AidsToNavigationP>(typeof(Daymark), structure.GLOBALID);

            if (daymarks == null || daymarks.Count() == 0) {
                return null;
            }

            if (daymarks.Count() > 1) {
                throw new NotSupportedException("Multiple related daymarks");
            }

            var relatedDaymark = daymarks.First();

            if (relatedDaymark != null) {

                List<colour> daymarkColours = null;

                colourPattern? daymarkColourPattern = null;

                if (relatedDaymark.COLOUR != default) {
                    daymarkColours = ImporterNIS.GetColours(relatedDaymark.COLOUR);
                }

                if (relatedDaymark.COLPAT != default) {
                    daymarkColourPattern = ImporterNIS.GetColourPattern(relatedDaymark.COLPAT);
                }

                var daymark = new Daymark() {
                    // TODO: shapeinformation #15 @https://geodatastyrelsen.atlassian.net/wiki/spaces/SOEKORT/pages/5070028848/S-57+to+S-101+Conversion+Action+Points?force_transition=910d1b59-0dc5-42d7-bd2c-a81edd431caf,
                    shapeInformation = default
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
                return daymark;
            }
            return null;
        }

        internal void CreateRelatedEquipment(S57Object s57Object, string structureId, Geodatabase target) {
            if (s57Object is AidsToNavigationP) {
                var sourceTable = "AidsToNavigationP";
                var structure = (AidsToNavigationP)s57Object;
                bool hasRelated = _featureRelations.HasRelated(structure.GLOBALID);
                if (!hasRelated) {
                    return;
                }

                var tableName = target.GetName("point");
                using var featureClass = target.OpenDataset<FeatureClass>(tableName);
                using var buffer = featureClass.CreateRowBuffer();

                //var types = FeatureRelations.GetS101CatlitTypeFrom(structure);

                var related = _featureRelations.GetRelated<AidsToNavigationP>(typeof(LightSectored), structure.GLOBALID);
                var hasRelatedSectoredLights = related.Any();

                if (hasRelatedSectoredLights) {
                    var instance = ImporterNIS.CreateLightSectored(related);

                    buffer["ps"] = ImporterNIS.ps101;
                    buffer["code"] = instance.GetType().Name;
                    buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
                    ImporterNIS.SetShape(buffer, structure.SHAPE);

                    var featureN = featureClass.CreateRow(buffer);
                    var equipmentName = Convert.ToString(featureN["name"]);

                    // TODO: Create relation
                    ConversionAnalytics.Instance.AddConverted(sourceTable, related.ToDictionary(obj => obj.GLOBALID, obj => new List<string> { equipmentName }));
                    Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, equipmentName, System.Text.Json.JsonSerializer.Serialize(instance));
                }

                related = _featureRelations.GetRelated<AidsToNavigationP>(typeof(LightAllAround), structure.GLOBALID);
                var hasRelatedLightsAllAround = related.Any();
                if (hasRelatedLightsAllAround) {
                    foreach (var light in related) {
                        //var slave = pltsSlave.Fetch(_source, Direction.Destination);
                        var instance = ImporterNIS.CreateLightAllAround(light);

                        buffer["ps"] = ImporterNIS.ps101;
                        buffer["code"] = instance.GetType().Name;
                        buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
                        ImporterNIS.SetShape(buffer, light.SHAPE);

                        var featureN = featureClass.CreateRow(buffer);
                        var equipmentName = Convert.ToString(featureN["name"]);

                        // TODO: Create relation

                        ConversionAnalytics.Instance.AddConverted(sourceTable, light.GLOBALID, equipmentName);
                        Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, equipmentName, System.Text.Json.JsonSerializer.Serialize(instance));
                    }
                }
            }
            else if (s57Object is CulturalFeaturesP) {
                var sourceTable = "CulturalFeaturesP";
                var structure = (CulturalFeaturesP)s57Object;
                bool hasRelated = _featureRelations.HasRelated(structure.GLOBALID);
                if (!hasRelated) {
                    return;
                }

                var tableName = target.GetName("point");
                var featureClass = target.OpenDataset<FeatureClass>(tableName);
                var buffer = featureClass.CreateRowBuffer();

                //var types = FeatureRelations.GetS101CatlitTypeFrom(structure);

                var related = _featureRelations.GetRelated<AidsToNavigationP>(typeof(LightSectored), structure.GLOBALID);
                var hasRelatedSectoredLights = related.Any();

                if (hasRelatedSectoredLights) {
                    var instance = ImporterNIS.CreateLightSectored(related);

                    buffer["ps"] = ImporterNIS.ps101;
                    buffer["code"] = instance.GetType().Name;
                    buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
                    ImporterNIS.SetShape(buffer, structure.SHAPE);

                    var featureN = featureClass.CreateRow(buffer);
                    var equipmentName = Convert.ToString(featureN["name"]);

                    // TODO: Create relation
                    ConversionAnalytics.Instance.AddConverted(sourceTable, related.ToDictionary(obj => obj.GLOBALID, obj => new List<string> { equipmentName }));
                    Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, equipmentName, System.Text.Json.JsonSerializer.Serialize(instance));
                }

                related = _featureRelations.GetRelated<AidsToNavigationP>(typeof(LightAllAround), structure.GLOBALID);
                var hasRelatedLightsAllAround = related.Any();
                if (hasRelatedLightsAllAround) {
                    foreach (var light in related) {
                        //var slave = pltsSlave.Fetch(_source, Direction.Destination);
                        var instance = ImporterNIS.CreateLightAllAround(light);

                        buffer["ps"] = ImporterNIS.ps101;
                        buffer["code"] = instance.GetType().Name;
                        buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
                        ImporterNIS.SetShape(buffer, light.SHAPE);

                        var featureN = featureClass.CreateRow(buffer);
                        var equipmentName = Convert.ToString(featureN["name"]);

                        // TODO: Create relation

                        ConversionAnalytics.Instance.AddConverted(sourceTable, light.GLOBALID, equipmentName);
                        Logger.Current.DataObject((int)featureN.GetObjectID(), tableName, equipmentName, System.Text.Json.JsonSerializer.Serialize(instance));
                    }
                }
            }

            else {
                throw new NotSupportedException($"{s57Object.GetType()}");
            }

        }

    }
}