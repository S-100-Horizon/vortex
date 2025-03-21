using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel;
using VortexLoader;
using System.Text.Json;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS {


        private static object CreateRadarTransponderbeacon(AidsToNavigationP current, InsertCursor insert, RowBuffer buffer, Feature feature, string tableName, int convertedCount) {
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
                instance.status = GetStatus(current.STATUS);
            }

            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

            AddInformation(instance.information, feature);
            buffer["ps"] = ps101;

            buffer["code"] = instance.GetType().Name;
            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
            buffer["shape"] = current.SHAPE;
            insert.Insert(buffer);
            Logger.Current.DataObject(current.OBJECTID.Value, tableName, current.LNAM, System.Text.Json.JsonSerializer.Serialize(instance));
            convertedCount++;
            return instance;
        }



        private static FeatureNode CreateLight(AidsToNavigationP current, InsertCursor insert, RowBuffer buffer, Feature feature, string tableName, int convertedCount) {

            if (current.FCSUBTYPE != 65)
                throw new ArgumentOutOfRangeException($"Illegal subtype for lights {current}");


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
                // LIGHTS: Attributes SECTR1 and SECTR2 not present; and/or attribute catlits is not 1, 6, 7, 16
                // Build "Light All Around");
                var instance = new LightAllAround();

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
                insert.Insert(buffer);
                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                convertedCount++;
                return instance;
            }
            else if ((sectr1Val != default && sectr2Val != default) || (catlits.Contains(1) || catlits.Contains(16))) {
                // LIGHTS: Attributes SECTR1 and SECTR2 present; and/or attribute catlits = 1 (directional function) or 16 (moiré effect)
                // Build "Light Sectored");
                var instance = new LightSectored();

                if (catlitVal != null) {
                    instance.categoryOfLight = new List<categoryOfLight>() { categoryOfLight.Unknown }; // TODO: CategoryOfLight
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
                insert.Insert(buffer);
                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                convertedCount++;
                return instance;
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
                insert.Insert(buffer);
                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                convertedCount++;
                return instance;
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
                insert.Insert(buffer);
                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                convertedCount++;
                return instance;
            }
            else {
                Logger.Current.DataError(objectid, tableName, longname, $"Unknown Light Type. Check catlit, sectr1, sectr2");
                return null;
            }

        } 
        
        //else {
        //        Logger.Current.DataError(objectid, tableName, longname, $"Unknown Light Type. Check catlit.");
        //        return null;

        private static void S57_AidsToNavigationP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "AidsToNavigationP";

            var featureRelations = new FeatureRelations();
            featureRelations.Initialize(source);

            var aidstonavigation = source.OpenDataset<FeatureClass>(source.GetName(tableName));

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("point"));
            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = aidstonavigation.Search(filter, true);
            int recordCount = 0;
            int convertedCount = 0;
            
            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;
                var current = new AidsToNavigationP(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;

                if (featureRelations.IsSlave(globalid)) {
                    continue;
                }

                switch (subtype) {
                    case 1: { // BCNCAR_BeaconCardinal
                            var instance = new CardinalBeacon();

                            #region aidstonavigation
                            if (current.BCNSHP.HasValue) {
                                if (current.BCNSHP.Value == -32767)
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>("-1");
                                else {
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(current.BCNSHP);
                                }
                            }

                            if (current.CATCAM.HasValue) {
                                if (current.CATCAM.Value == -32767)
                                    instance.categoryOfCardinalMark = EnumHelper.GetEnumValue<categoryOfCardinalMark>("-1");
                                else {
                                    instance.categoryOfCardinalMark = EnumHelper.GetEnumValue<categoryOfCardinalMark>(current.CATCAM.Value);
                                }
                            }


                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);  
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.DATSTA != default) {
                                if (current.DATEND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.DATEND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.DATSTA, out var dateStart)) {
                                            instance.fixedDateRange = new fixedDateRange() {
                                                dateStart = dateStart,
                                                dateEnd = dateEnd
                                            };
                                        }
                                        else {
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.DATEND}");
                                    }
                                }
                            }

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = dateStart,
                                                    dateEnd = dateEnd
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.TryConvertToDateOnly(current.SORDAT, out var dateOnly)) {
                                    instance.reportedDate = dateOnly;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;
                            
                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;

                            #region related
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: Create relation

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
                                            // TODO: Build rtpbcn_radartransponderbeacon
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);

                                            // TODO: create relation
                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;


                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }
                            #endregion related

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>("-1");
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            #endregion aidstonavigation

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 5: { // BCNISD_BeaconIsolatedDanger
                            var instance = new IsolatedDangerBeacon();

                            #region aidstonavigation
                            if (current.BCNSHP.HasValue) {
                                if (current.BCNSHP.Value == -32767)
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>("-1");
                                else {
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(current.BCNSHP);
                                }
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.DATSTA != default) {
                                if (current.DATEND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.DATEND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.DATSTA, out var dateStart)) {
                                            instance.fixedDateRange = new fixedDateRange() {
                                                dateStart = dateStart,
                                                dateEnd = dateEnd
                                            };
                                        }
                                        else {
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.DATEND}");
                                    }
                                }
                            }

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = dateStart,
                                                    dateEnd = dateEnd
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.TryConvertToDateOnly(current.SORDAT, out var dateOnly)) {
                                    instance.reportedDate = dateOnly;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;

                            #region related
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: Create relation

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
                                            // TODO: Build rtpbcn_radartransponderbeacon
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);

                                            // TODO: create relation
                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;


                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }
                            #endregion related

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>("-1");
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            #endregion aidstonavigation

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 10: { // BCNLAT_BeaconLateral
                            var instance = new LateralBeacon();

                            #region aidstonavigation
                            if (current.BCNSHP.HasValue) {
                                if (current.BCNSHP.Value == -32767)
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>("-1");
                                else {
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(current.BCNSHP);
                                }
                            }

                            if (current.CATLAM.HasValue) {
                                if (current.CATLAM.Value == -32767)
                                    instance.categoryOfLateralMark = EnumHelper.GetEnumValue<categoryOfLateralMark>("-1");
                                else {
                                    instance.categoryOfLateralMark = EnumHelper.GetEnumValue<categoryOfLateralMark>(current.CATLAM.Value);
                                }
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.DATSTA != default) {
                                if (current.DATEND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.DATEND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.DATSTA, out var dateStart)) {
                                            instance.fixedDateRange = new fixedDateRange() {
                                                dateStart = dateStart,
                                                dateEnd = dateEnd
                                            };
                                        }
                                        else {
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.DATEND}");
                                    }
                                }
                            }

                            if (current.HEIGHT.HasValue) { 
                                instance.height = current.HEIGHT.Value;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = dateStart,
                                                    dateEnd = dateEnd
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.TryConvertToDateOnly(current.SORDAT, out var dateOnly)) {
                                    instance.reportedDate = dateOnly;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;

                            #region related
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: Create relation

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
                                            // TODO: Build rtpbcn_radartransponderbeacon
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);

                                            // TODO: create relation
                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;


                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }
                            #endregion related

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>("-1");
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            #endregion aidstonavigation

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 15: { // BCNSAW_BeaconSafeWater
                            var instance = new SafeWaterBeacon();

                            #region aidstonavigation
                            if (current.BCNSHP.HasValue) {
                                if (current.BCNSHP.Value == -32767)
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>("-1");
                                else {
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(current.BCNSHP);
                                }
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.DATSTA != default) {
                                if (current.DATEND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.DATEND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.DATSTA, out var dateStart)) {
                                            instance.fixedDateRange = new fixedDateRange() {
                                                dateStart = dateStart,
                                                dateEnd = dateEnd
                                            };
                                        }
                                        else {
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.DATEND}");
                                    }
                                }
                            }

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = dateStart,
                                                    dateEnd = dateEnd
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.TryConvertToDateOnly(current.SORDAT, out var dateOnly)) {
                                    instance.reportedDate = dateOnly;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;

                            #region related
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: Create relation

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
                                            // TODO: Build rtpbcn_radartransponderbeacon
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);

                                            // TODO: create relation
                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;


                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }
                            #endregion related

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>("-1");
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            #endregion aidstonavigation

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 20: { // BCNSPP_BeaconSpecialPurpose
                            var instance = new SpecialPurposeGeneralBeacon();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            #region aidstonavigation

                            if (current.BCNSHP.HasValue) {
                                if (current.BCNSHP.Value == -32767)
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>("-1");
                                else {
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(current.BCNSHP);
                                }
                            }

                            if (current.CATSPM != default) {
                                instance.categoryOfSpecialPurposeMark = EnumHelper.GetEnumValues<categoryOfSpecialPurposeMark>(current.CATSPM);
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.DATSTA != default) {
                                if (current.DATEND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.DATEND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.DATSTA, out var dateStart)) {
                                            instance.fixedDateRange = new fixedDateRange() {
                                                dateStart = dateStart,
                                                dateEnd = dateEnd
                                            };
                                        }
                                        else {
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.DATEND}");
                                    }
                                }
                            }

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = dateStart,
                                                    dateEnd = dateEnd
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.SORDAT != default) {
                                if (DateHelper.TryConvertToDateOnly(current.SORDAT, out var dateOnly)) {
                                    instance.reportedDate = dateOnly;
                                }
                                else {
                                    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.SORDAT}");
                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;

                            #region related
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: Create relation

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
                                            // TODO: Build rtpbcn_radartransponderbeacon
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);

                                            // TODO: create relation
                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;


                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }
                            #endregion related


                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>("-1");
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            #endregion aidstonavigation

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 25: { // BOYCAR_BuoyCardinal
                            var instance = new CardinalBuoy();

                            #region aidstonavigation


                            if (current.CATCAM.HasValue) {
                                if (current.CATCAM.Value == -32767)
                                    instance.categoryOfCardinalMark = EnumHelper.GetEnumValue<categoryOfCardinalMark>("-1");
                                else {
                                    instance.categoryOfCardinalMark = EnumHelper.GetEnumValue<categoryOfCardinalMark>(current.CATCAM.Value);
                                }
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.DATSTA != default) {
                                if (current.DATEND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.DATEND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.DATSTA, out var dateStart)) {
                                            instance.fixedDateRange = new fixedDateRange() {
                                                dateStart = dateStart,
                                                dateEnd = dateEnd
                                            };
                                        }
                                        else {
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.DATEND}");
                                    }
                                }
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = dateStart,
                                                    dateEnd = dateEnd
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;

                            #region related
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: Create relation

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
                                            // TODO: Build rtpbcn_radartransponderbeacon
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);

                                            // TODO: create relation
                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;


                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }
                            #endregion related

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            #endregion aidstonavigation

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 30: { // BOYINB_BuoyInstallation
                            var instance = new InstallationBuoy();

                            #region aidstonavigation
                            if (current.BOYSHP.HasValue) {
                                if (current.BOYSHP.Value == -32767)
                                    instance.buoyShape = EnumHelper.GetEnumValue<buoyShape>("-1");
                                else {
                                    instance.buoyShape = EnumHelper.GetEnumValue<buoyShape>(current.BOYSHP);
                                }
                            }

                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.DATSTA != default) {
                                if (current.DATEND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.DATEND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.DATSTA, out var dateStart)) {
                                            instance.fixedDateRange = new fixedDateRange() {
                                                dateStart = dateStart,
                                                dateEnd = dateEnd
                                            };
                                        }
                                        else {
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.DATEND}");
                                    }
                                }
                            }


                            // TODO: interoperabilityidentifier


                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = dateStart,
                                                    dateEnd = dateEnd
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            #region related
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: Create relation

                                        }

                                        else if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "rtpbcn_radartransponderbeacon") {
                                            // TODO: Build rtpbcn_radartransponderbeacon
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);

                                            // TODO: create relation
                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;


                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }
                            #endregion related

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>("-1");
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            #endregion aidstonavigation

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 35: { // BOYISD_BuoyIsolatedDanger
                            var instance = new IsolatedDangerBuoy();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            #region aidstonavigation

                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.DATSTA != default) {
                                if (current.DATEND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.DATEND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.DATSTA, out var dateStart)) {
                                            instance.fixedDateRange = new fixedDateRange() {
                                                dateStart = dateStart,
                                                dateEnd = dateEnd
                                            };
                                        }
                                        else {
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.DATEND}");
                                    }
                                }
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = dateStart,
                                                    dateEnd = dateEnd
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;

                            #region related
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: Create relation

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
                                            // TODO: Build rtpbcn_radartransponderbeacon
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);

                                            // TODO: create relation
                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;


                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }
                            #endregion related

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}


                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            #endregion aidstonavigation

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 40: { // BOYLAT_BuoyLateral
                            var instance = new LateralBuoy();

                            #region aidstonavigation


                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.DATSTA != default) {
                                if (current.DATEND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.DATEND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.DATSTA, out var dateStart)) {
                                            instance.fixedDateRange = new fixedDateRange() {
                                                dateStart = dateStart,
                                                dateEnd = dateEnd
                                            };
                                        }
                                        else {
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.DATEND}");
                                    }
                                }
                            }


                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = dateStart,
                                                    dateEnd = dateEnd
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }


                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;

                            #region related
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: Create relation

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
                                            // TODO: Build rtpbcn_radartransponderbeacon
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);

                                            // TODO: create relation
                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;
                                        

                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }
                            #endregion related

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            #endregion aidstonavigation


                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 45: { // BOYSAW_BuoySafeWater
                            var instance = new SafeWaterBuoy();

                            #region aidstonavigation
                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }


                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.DATSTA != default) {
                                if (current.DATEND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.DATEND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.DATSTA, out var dateStart)) {
                                            instance.fixedDateRange = new fixedDateRange() {
                                                dateStart = dateStart,
                                                dateEnd = dateEnd
                                            };
                                        }
                                        else {
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.DATEND}");
                                    }
                                }
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = dateStart,
                                                    dateEnd = dateEnd
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;

                            #region related
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: Create relation

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
                                            // TODO: Build rtpbcn_radartransponderbeacon
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);

                                            // TODO: create relation
                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;


                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }
                            #endregion related

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            #endregion aidstonavigation

                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 50: { // BOYSPP_BuoySpecialPurpose
                            var instance = new SpecialPurposeGeneralBuoy();


                            #region aidstonavigation
                            if (current.COLOUR != default) {
                                instance.colour = EnumHelper.GetEnumValues<colour>(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }


                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.DATSTA != default) {
                                if (current.DATEND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.DATEND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.DATSTA, out var dateStart)) {
                                            instance.fixedDateRange = new fixedDateRange() {
                                                dateStart = dateStart,
                                                dateEnd = dateEnd
                                            };
                                        }
                                        else {
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.DATEND}");
                                    }
                                }
                            }

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = dateStart,
                                                    dateEnd = dateEnd
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;

                            #region related
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: Create relation

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
                                            // TODO: Build rtpbcn_radartransponderbeacon
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);

                                            // TODO: create relation
                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;


                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }
                            #endregion related

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            #endregion aidstonavigation



                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 55: { // DAYMAR_Daymark
                            var instance = new Daymark();

                            #region aidstonavigation

                            if (current.COLOUR != default) {
                                instance.colour = EnumHelper.GetEnumValues<colour>(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (current.ELEVAT.HasValue) {
                                instance.elevation = current.ELEVAT.Value;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.DATSTA != default) {
                                if (current.DATEND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.DATEND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.DATSTA, out var dateStart)) {
                                            instance.fixedDateRange = new fixedDateRange() {
                                                dateStart = dateStart,
                                                dateEnd = dateEnd
                                            };
                                        }
                                        else {
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.DATEND}");
                                    }
                                }
                            }

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = dateStart,
                                                    dateEnd = dateEnd
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;

                            #region related
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: Create relation

                                        }

                                        else if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "rtpbcn_radartransponderbeacon") {
                                            // TODO: Build rtpbcn_radartransponderbeacon
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);

                                            // TODO: create relation
                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;


                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }
                            #endregion related

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            #endregion aidstonavigation


                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 60: { // FOGSIG_FogSignal

                            //https://geodatastyrelsen.atlassian.net/wiki/spaces/SOEKORT/pages/4404478463/S-65+Annex+B+Appendix+A+-+Impact+analysis
                            //We have one TOPMAR at the same location as a FOGSIG(in three scale bands).We need to add topmark shape in fog signal INFORM.
                            //We do not have in the database information regarding “Radio Activated” nor “Call Activated”. We do have one instance of “On request”. What does this refer to??

                            var instance = new FogSignal();

                            #region aidstonavigation

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.DATSTA != default) {
                                if (current.DATEND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.DATEND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.DATSTA, out var dateStart)) {
                                            instance.fixedDateRange = new fixedDateRange() {
                                                dateStart = dateStart,
                                                dateEnd = dateEnd
                                            };
                                        }
                                        else {
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.DATEND}");
                                    }
                                }
                            }

                            // TODO: interoperabilityidentifier

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = dateStart,
                                                    dateEnd = dateEnd
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            #region related
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: Create relation

                                        }

                                        else if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "rtpbcn_radartransponderbeacon") {
                                            // TODO: Build rtpbcn_radartransponderbeacon
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);

                                            // TODO: create relation
                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;


                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }
                            #endregion related

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}


                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            #endregion aidstonavigation

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 65: { // LIGHTS_Light
                            var light = CreateLight(current, insert, buffer, feature, tableName, convertedCount);


                        }
                        break;
                    case 70: { // LITFLT_LightFloat
                            var instance = new LightFloat();

                            #region aidstonavigation
                            if (current.COLOUR != default) {
                                instance.colour = EnumHelper.GetEnumValues<colour>(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.DATSTA != default) {
                                if (current.DATEND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.DATEND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.DATSTA, out var dateStart)) {
                                            instance.fixedDateRange = new fixedDateRange() {
                                                dateStart = dateStart,
                                                dateEnd = dateEnd
                                            };
                                        }
                                        else {
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.DATEND}");
                                    }
                                }
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = dateStart,
                                                    dateEnd = dateEnd
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;

                            #region related
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: Create relation

                                        }

                                        else if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "topmar_topmark") {
                                            List<colour> topmarkColours = new();
                                            colourPattern? topmarkColourPattern = null;

                                            if (relatedAidsToNavigationP.COLOUR != default) {
                                                topmarkColours = GetColours(relatedAidsToNavigationP.COLOUR);
                                            }

                                            if (relatedAidsToNavigationP.COLPAT != default) {
                                                topmarkColourPattern = GetColourPattern(relatedAidsToNavigationP.COLPAT);
                                            }

                                            var topmark = new topmark() {
                                                colour = topmarkColours,
                                                colourPattern = topmarkColourPattern,
                                                // TODO: shapeinformation #15 @https://geodatastyrelsen.atlassian.net/wiki/spaces/SOEKORT/pages/5070028848/S-57+to+S-101+Conversion+Action+Points?force_transition=910d1b59-0dc5-42d7-bd2c-a81edd431caf,
                                                shapeInformation = default
                                            };

                                            if (topmarkDaymark.HasValue) {
                                                topmark.topmarkDaymarkShape = topmarkDaymark.Value;
                                            }


                                            instance.topmark = topmark;

                                        }
                                        else if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "rtpbcn_radartransponderbeacon") {
                                            // TODO: Build rtpbcn_radartransponderbeacon
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);

                                            // TODO: create relation
                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;


                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }
                            #endregion related

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>("-1");
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            #endregion aidstonavigation

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 75: { // LITVES_LightVessel
                            var instance = new LightVessel();

                            #region aidstonavigation
                            if (current.COLOUR != default) {
                                instance.colour = EnumHelper.GetEnumValues<colour>(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.DATSTA != default) {
                                if (current.DATEND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.DATEND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.DATSTA, out var dateStart)) {
                                            instance.fixedDateRange = new fixedDateRange() {
                                                dateStart = dateStart,
                                                dateEnd = dateEnd
                                            };
                                        }
                                        else {
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.DATEND}");
                                    }
                                }
                            }

                            // TODO: interoperabilityidentifier

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = dateStart,
                                                    dateEnd = dateEnd
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            instance.verticalLength = current.VERLEN;

                            #region related
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: Create relation

                                        }

                                        else if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "rtpbcn_radartransponderbeacon") {
                                            // TODO: Build rtpbcn_radartransponderbeacon
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);

                                            // TODO: create relation
                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;


                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }
                            #endregion related

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>("-1");
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            instance.pictorialRepresentation = current.PICREP;

                            #endregion aidstonavigation

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 85: { // RADRFL_RadarReflector
                            var instance = new RadarReflector();

                            #region aidstonavigation

                            if (current.DATSTA != default) {
                                if (current.DATEND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.DATEND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.DATSTA, out var dateStart)) {
                                            instance.fixedDateRange = new fixedDateRange() {
                                                dateStart = dateStart,
                                                dateEnd = dateEnd
                                            };
                                        }
                                        else {
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.DATEND}");
                                    }
                                }
                            }

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = dateStart,
                                                    dateEnd = dateEnd
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            #region related
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: Create relation

                                        }

                                        else if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "rtpbcn_radartransponderbeacon") {
                                            // TODO: Build rtpbcn_radartransponderbeacon
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);

                                            // TODO: create relation
                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;


                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }
                            #endregion related

                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}

                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            #endregion aidstonavigation

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                        }
                        break;
                    case 90: { // RADSTA_RadarStation
                            var instance = new RadarStation();

                            #region aidstonavigation

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.HEIGHT.HasValue) {
                                instance.height = current.HEIGHT.Value;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = dateStart,
                                                    dateEnd = dateEnd
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            #region related
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: Create relation

                                        }

                                        else if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "rtpbcn_radartransponderbeacon") {
                                            // TODO: Build rtpbcn_radartransponderbeacon
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);

                                            // TODO: create relation
                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;


                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }
                            #endregion related


                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}


                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            #endregion aidstonavigation

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 95: { // RDOSTA_RadioStation
                            var instance = new RadioStation();

                            #region aidstonavigation

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.DATSTA != default) {
                                if (current.DATEND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.DATEND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.DATSTA, out var dateStart)) {
                                            instance.fixedDateRange = new fixedDateRange() {
                                                dateStart = dateStart,
                                                dateEnd = dateEnd
                                            };
                                        }
                                        else {
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.DATEND}");
                                    }
                                }
                            }

                            // TODO: interoperabilityidentifier

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = dateStart,
                                                    dateEnd = dateEnd
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }


                            #region related
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: Create relation

                                        }

                                        else if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "rtpbcn_radartransponderbeacon") {
                                            // TODO: Build rtpbcn_radartransponderbeacon
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);

                                            // TODO: create relation
                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;


                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }
                            #endregion related


                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}


                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            #endregion aidstonavigation

                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 100: { // RETRFL_RetroReflector
                            var instance = new Retroreflector();

                            #region aidstonavigation

                            if (current.COLOUR != default) {
                                instance.colour = EnumHelper.GetEnumValues<colour>(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (current.DATSTA != default) {
                                if (current.DATEND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.DATEND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.DATSTA, out var dateStart)) {
                                            instance.fixedDateRange = new fixedDateRange() {
                                                dateStart = dateStart,
                                                dateEnd = dateEnd
                                            };
                                        }
                                        else {
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.DATEND}");
                                    }
                                }
                            }

                            if (current.HEIGHT.HasValue) { 
                                instance.height = current.HEIGHT.Value;
                            }

                            // TODO: interoperabilityidentifier

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = dateStart,
                                                    dateEnd = dateEnd
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            #region related
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: Create relation

                                        }

                                        else if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "rtpbcn_radartransponderbeacon") {
                                            // TODO: Build rtpbcn_radartransponderbeacon
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);

                                            // TODO: create relation
                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;


                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }
                            #endregion related


                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}


                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            #endregion aidstonavigation

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 105: { // RTPBCN_RadarTransponderBeacon
                            var instance = new RadarTransponderBeacon();


                            #region aidstonavigation
                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            if (current.DATSTA != default) {
                                if (current.DATEND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.DATEND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.DATSTA, out var dateStart)) {
                                            instance.fixedDateRange = new fixedDateRange() {
                                                dateStart = dateStart,
                                                dateEnd = dateEnd
                                            };
                                        }
                                        else {
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.DATEND}");
                                    }
                                }
                            }

                            // TODO: interoperabilityidentifier

                            if (current.PERSTA != default) {
                                if (current.PEREND != default) {
                                    if (DateHelper.TryConvertToDateOnly(current.PEREND, out var dateEnd)) {
                                        if (DateHelper.TryConvertToDateOnly(current.PERSTA, out var dateStart)) {
                                            instance.periodicDateRange = new List<periodicDateRange>() {
                                                new periodicDateRange() {
                                                    dateStart = dateStart,
                                                    dateEnd = dateEnd
                                                }
                                            };
                                        }
                                        else {
                                            Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PERSTA}");
                                        }
                                    }
                                    else {
                                        Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Cannot convert date {current.PEREND}");
                                    }

                                }
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            // topmarkdayShape for topmark
                            topmarkDaymarkShape? topmarkDaymark = null;

                            if (current.TOPSHP.HasValue) {
                                topmarkDaymark = EnumHelper.GetEnumValue<topmarkDaymarkShape>(current.TOPSHP.Value);
                            }

                            #region related
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Destination);

                                    if (result is AidsToNavigationP) {
                                        var relatedAidsToNavigationP = result as AidsToNavigationP;

                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: Create relation

                                        }

                                        else if (plfrel.PLTS_Frel.DEST_SUB?.ToLower() == "rtpbcn_radartransponderbeacon") {
                                            var radarTransponderBeacon = CreateRadarTransponderbeacon(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // TODO: create relation

                                        }
                                        else {
                                            throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                        }
                                    }
                                    else if (result is DangersP) {
                                        var relatedDangersP = result as DangersP;


                                    }
                                    else {
                                        throw new NotImplementedException($"{plfrel.PLTS_Frel.DEST_SUB?.ToLower()} ");
                                    }
                                }
                            }
                            #endregion related


                            //if (!topmarkDaymarkHasValue && instance.topmark != null) {
                            //    Logger.Current.DataError(current.OBJECTID.Value, tableName, current.LNAM, $"Missing topmarkDaymark info on {nameof(instance)}");
                            //}


                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddInformation(instance.information, feature);

                            #endregion aidstonavigation

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 110: { // TOPMAR_Topmark
                            // TODO: TOPMAR
                            //System.Diagnostics.Debugger.Break();
                            //GetCorrespondingAidsToNav
                            /*

                                The S-101 complex attribute topmark has been introduced in S-101 to encode topmarks on aids to
                                navigation features. This information is encoded in S-57 using the Object class TOPMAR. All
                                instances of TOPMAR will be converted to topmark for the corresponding aid to navigation structure
                                feature during the automated conversion process. However, it must be noted that the TOPMAR
                                attributes DATEND, DATSTA, PEREND, PERSTA and STATUS will not be converted. Additional
                                topmark shape information populated in the S-57 attribute INFORM will be converted to the S-101
                                complex attribute shape information. See also clause 12.6.
                            */

                            convertedCount++;

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
