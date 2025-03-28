using ArcGIS.Core.Data;
using S100Framework.Applications;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S101;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using S100Framework.DomainModel;

namespace S100Framework.Applications
{
    internal class RelatedEquipment
    {

        FeatureRelations _featureRelations;

        public RelatedEquipment(FeatureRelations featureRelations) {
            this._featureRelations = featureRelations;
        }

        internal void CreateRelatedEquipment(AidsToNavigationP structure, string id) {
            var related = _featureRelations.GetRelated(structure.GLOBALID);
            if (related == null || related.Count == 0) {
                return;
            }

            var equipmentTypes = _featureRelations.GetS101EquipmentType(related);

            if (equipmentTypes == null || equipmentTypes.Count == 0) {
                return;
            }

            




        }

        private static (FeatureNode node, string name, string type)? CreateRadarTransponderbeacon(AidsToNavigationP current, InsertCursor insert, RowBuffer buffer, Feature feature, string tableName, int convertedCount, FeatureClass featureClass) {
            //if (current.FCSUBTYPE != 65)
            //    throw new ArgumentOutOfRangeException($"Illegal subtype for transponder beacon {current}");

            var instance = new RadarTransponderBeacon();

            if (current.CATRTB != null) {
                instance.categoryOfRadarTransponderBeacon = EnumHelper.GetEnumValue<categoryOfRadarTransponderBeacon>(current.CATRTB);
            }

            if (current.PLTS_COMP_SCALE != default) {
                instance.scaleMinimum = current.PLTS_COMP_SCALE;
            }

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            ImporterNIS.AddInformation(instance.information, feature);
            buffer["ps"] = ImporterNIS.ps101;
            buffer["code"] = instance.GetType().Name;
            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, ImporterNIS.jsonSerializerOptions);
            buffer["shape"] = current.SHAPE;
            insert.Insert(buffer);

            var name = Convert.ToString(buffer["name"]);

            Logger.Current.DataObject(current.OBJECTID.Value, tableName, current.LNAM, System.Text.Json.JsonSerializer.Serialize(instance));
            convertedCount++;
            return (instance: instance, name: name, type: instance.GetType().Name);
        }
    }
}

#if null

                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount, featureClass);
                                                var rel = new CardinalBeacon.StructureEquipment_theEquipment();
                                                rel.RefIds = [new RefId {
                                                Role = nameof(Role.theStructure),
                                                Type = light?.type,
                                                Value = light?.name,
                                                },
                                            new RefId {
                                                Role = nameof(Role.theEquipment),
                                                Type = nameof(instance),
                                                Value = structureName,
                                                }];

                                                informationAssociationBuffer["ps"] = ps101;
                                                informationAssociationBuffer["code"] = rel.GetType().Name;
                                                informationAssociationBuffer["json"] = System.Text.Json.JsonSerializer.Serialize(rel, jsonSerializerOptions);
                                                informationAssociationInsert.Insert(informationAssociationBuffer);
                                            }

                                        else if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "topmar_topmark") {
                                            List<colour> topmarkColours = null;

                                            colourPattern? topmarkColourPattern = null;

                                            if (relatedAidsToNavigationP.COLOUR != default) {
                                                topmarkColours = GetColours(relatedAidsToNavigationP.COLOUR);
                                            }

                                            if (relatedAidsToNavigationP.COLPAT != default) {
                                                topmarkColourPattern = GetColourPattern(relatedAidsToNavigationP.COLPAT);
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

                                            if (topmarkDaymark.HasValue) {
                                                topmark.topmarkDaymarkShape = topmarkDaymark.Value;
                                            }

                                            instance.topmark = topmark;
                                        }
                                        else if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "rtpbcn_radartransponderbeacon") {
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount, featureClass);
                                            var rel = new CardinalBeacon.StructureEquipment_theEquipment();
                                            rel.RefIds = [new RefId {
                                                Role = nameof(Role.theStructure),
                                                Type = radarTransponderBeacon?.type,
                                                Value = radarTransponderBeacon?.name,
                                                },
                                            new RefId {
                                                Role = nameof(Role.theEquipment),
                                                Type = nameof(instance),
                                                Value = structureName,
                                                }];
                                            informationAssociationBuffer["ps"] = ps101;
                                            informationAssociationBuffer["code"] = rel.GetType().Name;
                                            informationAssociationBuffer["json"] = System.Text.Json.JsonSerializer.Serialize(rel, jsonSerializerOptions);
                                            informationAssociationInsert.Insert(informationAssociationBuffer);

                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;
                                        //var rel = new CardinalBeacon.StructureEquipment_theEquipment();
                                        //rel.RefIds = [new RefId {
                                        //        Role = nameof(Role.theStructure),
                                        //        Type = radarTransponderBeacon?.type,
                                        //        Value = radarTransponderBeacon?.name,
                                        //        }];
                                        //informationAssociationBuffer["ps"] = ps101;
                                        //informationAssociationBuffer["code"] = instance.GetType().Name;
                                        //informationAssociationBuffer["json"] = System.Text.Json.JsonSerializer.Serialize(rel, jsonSerializerOptions);
                                        //informationAssociationInsert.Insert(buffer);

                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }




#endif





#if null

#if null
        private static List<LightResult>? CreateLight(AidsToNavigationP current, InsertCursor insert, RowBuffer buffer, Feature feature, string tableName, int convertedCount, FeatureClass featureClass) {

            if (current.FCSUBTYPE != 65)
                throw new ArgumentOutOfRangeException($"Illegal subtype for lights {current}");

            var result = new List<LightResult>();

            var objectid = current.OBJECTID ?? default;
            var globalid = current.GLOBALID;
            var subtype = current.FCSUBTYPE ?? default;
            var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
            var longname = current.LNAM ?? Strings.UNKNOWN;
            var catlitVal = current.CATLIT ?? default;
            var sectr1Val = current.SECTR1 ?? default;
            var sectr2Val = current.SECTR2 ?? default;
            var color = current.COLOUR ?? default;   // list of integers
            
            var bcnshp = current.BCNSHP ?? default;   // domain value
            var colpat = current.COLPAT ?? default;
            var litchr = current.LITCHR ?? default;
            var marsys = current.MARSYS ?? default;
            var orient = current.ORIENT ?? default;
            List<int> catlits = new();

            if (catlitVal != default) {
                catlits = catlitVal.Split(',')
                                   .Select(int.Parse)
                                   .ToList();
            }

            /* CATLIT
                Code	Description
                1	directional function
                4	leading light
                5	aero light
                6	air obstruction light
                7	fog detector light
                8	flood light
                9	strip light
                10	subsidiary light
                11	spotlight
                12	front
                13	rear
                14	lower
                15	upper
                16	moiré effect
                17	emergency
                18	bearing light
                19	horizontally disposed
                20	vertically disposed
                -32767	Unknown
            */

            if ((sectr1Val == default || sectr2Val == default) && !(catlits.Contains(1) || catlits.Contains(6) || catlits.Contains(7) || catlits.Contains(16))) {
                // Fixed and flashing
                if (current.LITCHR.Value == 13) {
                    // Create one fixed and one flashing light
                    #region LIGHT 1
                    {
                        // LIGHTS: Attributes SECTR1 and SECTR2 not present; and/or attribute catlits is not 1, 6, 7, 16
                        // Build "Light All Around");
                        var instance = new LightAllAround();

                        if (plts_comp_scale != default) {
                            instance.scaleMinimum = plts_comp_scale;
                        }

                        var signalGroup = current.SIGGRP;
                        var signalPeriod = current.SIGPER;
                        var signalSequence = current.SIGFRQ;


                        // TODO: rythmOfLight
                        instance.rhythmOfLight = new rhythmOfLight() {
                            lightCharacteristic = EnumHelper.GetEnumValue<lightCharacteristic>(current.LITCHR.Value),
                            //signalGroup = signalGroup,
                            //signalPeriod = signalPeriod,
                            //signalSequence = signalSequence
                        };

                        if (current.COLOUR != default) {
                            instance.colour = GetColours(current.COLOUR);
                        }

                        if (current.STATUS != default) {
                            instance.status = GetStatus(current.STATUS);
                        }

                        instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                        AddInformation(instance.information, feature);
                        buffer["ps"] = ps101;
                        buffer["code"] = instance.GetType().Name;
                        buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                        buffer["shape"] = current.SHAPE;

                        //insert.Insert(buffer);
                        var featureN = featureClass.CreateRow(buffer);

                        Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                        convertedCount++;

                        result.Add(new LightResult { node = instance, name = Convert.ToString(featureN["name"]), TypeName = instance?.GetType().Name });
                    }
                    #endregion LIGHT 1

                    //#region LIGHT 2
                    //{
                    //    // LIGHTS: Attributes SECTR1 and SECTR2 not present; and/or attribute catlits is not 1, 6, 7, 16
                    //    // Build "Light All Around");
                    //    var instance = new LightAllAround();

                    //    if (plts_comp_scale != default) {
                    //        instance.scaleMinimum = plts_comp_scale;
                    //    }

                    //    var signalGroup = current.SIGGRP;
                    //    var signalPeriod = current.SIGPER;
                    //    var signalSequence = current.SIGFRQ;


                    //    // TODO: rythmOfLight
                    //    instance.rhythmOfLight = new rhythmOfLight() {
                    //        lightCharacteristic = EnumHelper.GetEnumValue<lightCharacteristic>(current.LITCHR.Value),
                    //        //signalGroup = signalGroup,
                    //        //signalPeriod = signalPeriod,
                    //        //signalSequence = signalSequence
                    //    };

                    //    if (current.COLOUR != default) {
                    //        instance.colour = GetColours(current.COLOUR);
                    //    }

                    //    if (current.STATUS != default) {
                    //        instance.status = GetStatus(current.STATUS);
                    //    }

                    //    instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                    //    AddInformation(instance.information, feature);
                    //    buffer["ps"] = ps101;
                    //    buffer["code"] = instance.GetType().Name;
                    //    buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                    //    buffer["shape"] = current.SHAPE;

                    //    //insert.Insert(buffer);
                    //    var featureN = featureClass.CreateRow(buffer);

                    //    Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                    //    convertedCount++;

                    //    result.Add(new LightResult { node = instance, name = Convert.ToString(featureN["name"]), TypeName = instance?.GetType().Name });

                    //}

                    //#endregion LIGHT 2

                    return result;
                } else {

                    #region default

                    // LIGHTS: Attributes SECTR1 and SECTR2 not present; and/or attribute catlits is not 1, 6, 7, 16
                    // Build "Light All Around");
                    var instance = new LightAllAround();

                    if (plts_comp_scale != default) {
                        instance.scaleMinimum = plts_comp_scale;
                    }

                    instance.rhythmOfLight = GetRythmOfLight(current);

                    if (current.COLOUR != default) {
                        instance.colour = GetColours(current.COLOUR);
                    }

                    if (current.STATUS != default) {
                        instance.status = GetStatus(current.STATUS);
                    }

                    instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                    AddInformation(instance.information, feature);
                    buffer["ps"] = ps101;
                    buffer["code"] = instance.GetType().Name;
                    buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                    buffer["shape"] = current.SHAPE;

                    //insert.Insert(buffer);
                    var featureN = featureClass.CreateRow(buffer);

                    Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                    convertedCount++;

                    result.Add(new LightResult { node = instance, name = Convert.ToString(featureN["name"]), TypeName = instance?.GetType().Name });

                    return new List<LightResult> { new LightResult { node = instance, name = Convert.ToString(featureN["name"]), TypeName = instance?.GetType().Name } };
                    #endregion default
                }


            }
            else if ((sectr1Val != default && sectr2Val != default) || (catlits.Contains(1) || catlits.Contains(16))) {
                // LIGHTS: Attributes SECTR1 and SECTR2 present; and/or attribute catlits = 1 (directional function) or 16 (moiré effect)
                // Build "Light Sectored");
                var instance = new LightSectored();

                if (catlitVal != null) {
                    instance.categoryOfLight = new List<categoryOfLight>() { categoryOfLight.Unknown }; 
                }

                if (current.EXCLIT.HasValue) {
                    instance.exhibitionConditionOfLight = EnumHelper.GetEnumValue<exhibitionConditionOfLight>(current.EXCLIT.Value);
                }

                instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                if (plts_comp_scale != default) {
                    instance.scaleMinimum = plts_comp_scale;
                }

                if (current.STATUS != default) {
                    instance.status = GetStatus(current.STATUS);
                }

                if (current.SIGGEN != null) {
                    instance.signalGeneration = EnumHelper.GetEnumValue<signalGeneration>(current.SIGGEN.Value);
                }


                //if (current.SECTR1 != null) {
                //    instance.sectorCharacteristics = new List<sectorCharacteristics>() {
                //        new sectorCharacteristics() {
                //            lightSector = new List<lightSector>() {
                //                new lightSector() {
                //                    valueOfNominalRange = current.no

                //                }
                //            }
                //        }
                //    }
                //}

                

                AddInformation(instance.information, feature);
                buffer["ps"] = ps101;

                buffer["code"] = instance.GetType().Name;
                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                buffer["shape"] = current.SHAPE;
                //insert.Insert(buffer);

                var featureN = featureClass.CreateRow(buffer);

                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                convertedCount++;
                return new List<LightResult> { new LightResult { node = instance, name = Convert.ToString(featureN["name"]), TypeName = instance?.GetType().Name } };
            }
            else if (catlits.Contains(6)) {
                // LIGHTS: Attribute catlits contains value 6 (air obstruction light)
                // Build "Light Air Obstruction");
                var instance = new LightAirObstruction();
                if (plts_comp_scale != default) {
                    instance.scaleMinimum = plts_comp_scale;
                }
                if (current.COLOUR != default) {
                    instance.colour = GetColours(current.COLOUR);
                }

                if (current.STATUS != default) {
                    instance.status = GetStatus(current.STATUS);
                }

                instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                AddInformation(instance.information, feature);
                buffer["ps"] = ps101;

                buffer["code"] = instance.GetType().Name;
                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                buffer["shape"] = current.SHAPE;
                //insert.Insert(buffer);

                var featureN = featureClass.CreateRow(buffer);

                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                convertedCount++;
                return new List<LightResult> { new LightResult { node = instance, name = Convert.ToString(featureN["name"]), TypeName = instance?.GetType().Name } };
            }
            else if (catlits.Contains(7)) {
                // LIGHTS: Attribute catlits contains value 7 (fog detector light)
                // Build "Light Fog Detector");
                var instance = new LightFogDetector();
                if (plts_comp_scale != default) {
                    instance.scaleMinimum = plts_comp_scale;
                }
                if (current.COLOUR != default) {
                    instance.colour = GetColours(current.COLOUR);
                }

                if (current.STATUS != default) {
                    instance.status = GetStatus(current.STATUS);
                }

                instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                AddInformation(instance.information, feature);
                buffer["ps"] = ps101;

                buffer["code"] = instance.GetType().Name;
                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                buffer["shape"] = current.SHAPE;
                //insert.Insert(buffer);

                var featureN = featureClass.CreateRow(buffer);

                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                convertedCount++;
                return new List<LightResult> { new LightResult { node = instance, name = Convert.ToString(featureN["name"]), TypeName = instance?.GetType().Name } };
            }
            else {
                Logger.Current.DataError(objectid, tableName, longname, $"Unknown Light Type. Check catlit, sectr1, sectr2");
                return null;
            }

        }


        //else {
        //        Logger.Current.DataError(objectid, tableName, longname, $"Unknown Light Type. Check catlit.");
        //        return null;
#endif

        private static (FeatureNode node, string name, string type)? CreateLight(AidsToNavigationP current, InsertCursor insert, RowBuffer buffer, Feature feature, string tableName, int convertedCount, FeatureClass featureClass) {

            if (current.FCSUBTYPE != 65)
                throw new ArgumentOutOfRangeException($"Illegal subtype for lights {current}");

            var objectid = current.OBJECTID ?? default;
            var globalid = current.GLOBALID;
            var subtype = current.FCSUBTYPE ?? default;
            var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
            var longname = current.LNAM ?? Strings.UNKNOWN;
            //var catlitVal = current.CATLIT ?? default;
            var sectr1Val = current.SECTR1 ?? default;
            var sectr2Val = current.SECTR2 ?? default;
            //var color = current.COLOUR ?? default;   // list of integers

            //var bcnshp = current.BCNSHP ?? default;   // domain value
            //var colpat = current.COLPAT ?? default;
            //var litchr = current.LITCHR ?? default;
            //var marsys = current.MARSYS ?? default;
            //var orient = current.ORIENT ?? default;
            List<int> catlits = new();

            if (current.CATLIT != default) {
                catlits = current.CATLIT.Split(',')
                                   .Select(int.Parse)
                                   .ToList();
            }

            /* CATLIT
                Code	Description
                1	directional function
                4	leading light
                5	aero light
                6	air obstruction light
                7	fog detector light
                8	flood light
                9	strip light
                10	subsidiary light
                11	spotlight
                12	front
                13	rear
                14	lower
                15	upper
                16	moiré effect
                17	emergency
                18	bearing light
                19	horizontally disposed
                20	vertically disposed
                -32767	Unknown
            */

            if ((sectr1Val == default || sectr2Val == default) && !(catlits.Contains(1) || catlits.Contains(6) || catlits.Contains(7) || catlits.Contains(16))) {
                // LIGHTS: Attributes SECTR1 and SECTR2 not present; and/or attribute catlits is not 1, 6, 7, 16
                // Build "Light All Around");
                var instance = new LightAllAround();

                if (plts_comp_scale != default) {
                    instance.scaleMinimum = plts_comp_scale;
                }


                instance.rhythmOfLight = GetRythmOfLight(current);


                if (current.COLOUR != default) {
                    instance.colour = GetColours(current.COLOUR);
                }

                if (current.STATUS != default) {
                    instance.status = GetStatus(current.STATUS);
                }

                


                instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                AddInformation(instance.information, feature);
                buffer["ps"] = ps101;

                buffer["code"] = instance.GetType().Name;
                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                buffer["shape"] = current.SHAPE;

                //insert.Insert(buffer);
                var featureN = featureClass.CreateRow(buffer);

                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                convertedCount++;
                return (instance: instance, name: Convert.ToString(featureN["name"]), type: instance?.GetType().Name);
            }
            else if ((sectr1Val != default && sectr2Val != default) || (catlits.Contains(1) || catlits.Contains(16))) {
                // LIGHTS: Attributes SECTR1 and SECTR2 present; and/or attribute catlits = 1 (directional function) or 16 (moiré effect)
                // Build "Light Sectored");
                var instance = new LightSectored();

                if (current.CATLIT != null) {
                    instance.categoryOfLight = EnumHelper.GetEnumValues<categoryOfLight>(current.CATLIT);
                }

                if (current.EXCLIT.HasValue) {
                    instance.exhibitionConditionOfLight = EnumHelper.GetEnumValue<exhibitionConditionOfLight>(current.EXCLIT.Value);
                }
                
                DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
                if (dateRange != default) {
                    instance.fixedDateRange = dateRange;
                }

                instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                if (plts_comp_scale != default) {
                    instance.scaleMinimum = plts_comp_scale;
                }

                if (current.STATUS != default) {
                    instance.status = GetStatus(current.STATUS);
                }

                if (current.SIGGEN != null) {
                    instance.signalGeneration = EnumHelper.GetEnumValue<signalGeneration>(current.SIGGEN.Value);
                }

                // Take all sectored lights related to this instance and convert them into one sector characteristics
                if (current.SECTR1 != null && current.SECTR2 != null) {
                    instance.sectorCharacteristics = new List<sectorCharacteristics>() {
                        new sectorCharacteristics() {
                            lightSector = new List<lightSector>() {
                                new lightSector() {
                                    valueOfNominalRange = default,
                                },
                                new lightSector() {
                                    valueOfNominalRange =default,
                                },

                            }
                        }
                    };
                }


                AddInformation(instance.information, feature);
                buffer["ps"] = ps101;

                buffer["code"] = instance.GetType().Name;
                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                buffer["shape"] = current.SHAPE;
                insert.Insert(buffer);

                var name = Convert.ToString(buffer["name"]);

                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                convertedCount++;
                return (instance: instance, name: name, type: instance.GetType().Name);

            }
            else if (catlits.Contains(6)) {
                // LIGHTS: Attribute catlits contains value 6 (air obstruction light)
                // Build "Light Air Obstruction");
                var instance = new LightAirObstruction();
                if (plts_comp_scale != default) {
                    instance.scaleMinimum = plts_comp_scale;
                }
                if (current.COLOUR != default) {
                    instance.colour = GetColours(current.COLOUR);
                }

                if (current.STATUS != default) {
                    instance.status = GetStatus(current.STATUS);
                }
                
                instance.rhythmOfLight = GetRythmOfLight(current);

                instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                AddInformation(instance.information, feature);
                buffer["ps"] = ps101;

                buffer["code"] = instance.GetType().Name;
                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                buffer["shape"] = current.SHAPE;
                insert.Insert(buffer);

                var name = Convert.ToString(buffer["name"]);
                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                convertedCount++;
                return (instance: instance, name: name, type: instance.GetType().Name);

            }
            else if (catlits.Contains(7)) {
                // LIGHTS: Attribute catlits contains value 7 (fog detector light)
                // Build "Light Fog Detector");
                var instance = new LightFogDetector();
                if (plts_comp_scale != default) {
                    instance.scaleMinimum = plts_comp_scale;
                }
                if (current.COLOUR != default) {
                    instance.colour = GetColours(current.COLOUR);
                }

                if (current.STATUS != default) {
                    instance.status = GetStatus(current.STATUS);
                }

                instance.rhythmOfLight = GetRythmOfLight(current);

                instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                AddInformation(instance.information, feature);
                buffer["ps"] = ps101;

                buffer["code"] = instance.GetType().Name;
                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                buffer["shape"] = current.SHAPE;
                insert.Insert(buffer);
                insert.Flush();

                var name = Convert.ToString(buffer["name"]);
                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                convertedCount++;
                return (instance: instance, name: name, type: instance.GetType().Name);

            }
            else {
                Logger.Current.DataError(objectid, tableName, longname, $"Unknown Light Type. Check catlit, sectr1, sectr2");
                return null;
            }

        }





#endif