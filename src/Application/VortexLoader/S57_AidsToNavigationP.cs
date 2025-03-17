using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.FeatureTypes;
using System.Collections.Generic;
using System;
using S100Framework.DomainModel;
using ArcGIS.Desktop.Internal.Mapping.Symbology;
using ArcGIS.Desktop.Internal.Core.Events;
using VortexLoader;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS {
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
            var boyshp = current.BOYSHP ?? default;   // domain value
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
                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
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
                if (plts_comp_scale != default) {
                    instance.scaleMinimum = plts_comp_scale;
                }

                if (current.STATUS != default) {
                    instance.status = GetStatus(current.STATUS);
                }

                instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                AddInformation(instance.information, feature);
                buffer["ps"] = ps101;

                buffer["code"] = instance.GetType().Name;
                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
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
                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
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
                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
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
                var catlitVal = current.CATLIT ?? default;
                var sectr1Val = current.SECTR1 ?? default;
                var sectr2Val = current.SECTR2 ?? default;
                var color = current.COLOUR ?? default;   // list of integers
                var boyshp = current.BOYSHP ?? default;   // domain value
                var bcnshp = current.BCNSHP ?? default;   // domain value
                var colpat = current.COLPAT ?? default; 
                var litchr = current.LITCHR ?? default;
                var marsys = current.MARSYS ?? default;
                var orient = current.ORIENT ?? default;
                var cat = current.CATCAM ?? default;

                var colours = new List<colour>();

                if (featureRelations.IsSlave(globalid)) {
                    continue;
                }

                switch (subtype) {
                    case 1: { // BCNCAR_BeaconCardinal
                            var instance = new CardinalBeacon();

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

                            instance.elevation = current.ELEVAT;

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            // TODO: fixeddaterange

                            instance.height = current.HEIGHT;

                            // TODO: interoperabilityidentifier

                            if (current.MARSYS != null) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS);
                            }

                            if (current.NATCON != default) {
                                instance.natureOfConstruction = EnumHelper.GetEnumValues<natureOfConstruction>(current.NATCON);
                            }

                            // TODO: periodicdatarange

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.SORDAT != default) {
                                instance.reportedDate = DateHelper.ConvertToDateOnly(current.SORDAT);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            if (current.TOPSHP.HasValue) {
                                // TODO: topshp
                            }
                                // Slaves
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Source);
                                    var relatedAidsToNavigationP = result as AidsToNavigationP;


                                    if (relatedAidsToNavigationP != null) {
                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // Create relation

                                        }
                                    }
                                }


                                //instance.topmark = new topmark() {
                                //    colour = 
                                //}
                            }


                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>("-1");
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }



                            instance.pictorialRepresentation = current.PICREP;




                            instance.verticalLength = current.VERLEN;




                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 5: { // BCNISD_BeaconIsolatedDanger
                            var instance = new IsolatedDangerBeacon();

                            if (current.BCNSHP.HasValue) {
                                if (current.BCNSHP.Value == -32767)
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>("-1");
                                else {
                                    instance.beaconShape = EnumHelper.GetEnumValue<beaconShape>(current.BCNSHP);
                                }
                            }

                            instance.elevation = current.ELEVAT;

                            //
                            //instance.reportedDate = new DateOnly(1, 2, 3);


                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }


                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>("-1");
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            if (current.CONVIS.HasValue) {
                                if (current.CONVIS.Value == -32767)
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>("-1");
                                else {
                                    instance.visualProminence = EnumHelper.GetEnumValue<visualProminence>(current.CONVIS.Value);
                                }
                            }

                            if (current.SORDAT != default) {
                                instance.reportedDate = DateHelper.ConvertToDateOnly(current.SORDAT);
                            }

                            instance.pictorialRepresentation = current.PICREP;

                            instance.height = current.HEIGHT;

                            instance.elevation = current.ELEVAT;

                            if (current.CONRAD.HasValue) {
                                instance.radarConspicuous = current.CONRAD.Value == 0 ? true : false;
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 10: { // BCNLAT_BeaconLateral
                            var instance = new LateralBeacon();

                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            instance.height = current.HEIGHT;
                            instance.elevation = current.ELEVAT;

                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);

                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 15: { // BCNSAW_BeaconSafeWater
                            var instance = new SafeWaterBeacon();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            instance.height = current.HEIGHT;
                            instance.elevation = current.ELEVAT;

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
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

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
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
                            instance.height = current.HEIGHT;
                            instance.elevation = current.ELEVAT;

                            if (current.COLOUR != default) {
                                instance.colour = GetColours(current.COLOUR);
                            }

                            if (current.COLPAT != default) {
                                instance.colourPattern = GetColourPattern(current.COLPAT);
                            }

                            if (current.CONDTN.HasValue) {
                                instance.condition = GetCondition(current.CONDTN.Value);
                            }

                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 25: { // BOYCAR_BuoyCardinal
                            var instance = new CardinalBuoy();


                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 30: { // BOYINB_BuoyInstallation
                            var instance = new InstallationBuoy();



                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
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




                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 40: { // BOYLAT_BuoyLateral
                            var instance = new LateralBuoy();

                            AddInformation(instance.information, feature);

                            // Slaves
                            var related = featureRelations.GetRelated(current.GLOBALID);
                            if (related != null) {
                                foreach (var plfrel in related) {
                                    //plfrel.RIND
                                    var slave = new PltsSlave(plfrel.PLTS_Frel);
                                    var result = slave.Fetch(source, Direction.Source);
                                    var relatedAidsToNavigationP = result as AidsToNavigationP;

                                    if (relatedAidsToNavigationP != null) {
                                        //relatedAidsToNavigationP
                                        if (plfrel.PLTS_Frel.DEST_SUB.ToLower() == "lights_light") {
                                            var light = CreateLight(relatedAidsToNavigationP, insert, buffer, feature, tableName, convertedCount);
                                            // Create relation
                                        }
                                    }
                                }
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 45: { // BOYSAW_BuoySafeWater
                            var instance = new SafeWaterBuoy();



                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 50: { // BOYSPP_BuoySpecialPurpose
                            var instance = new SpecialPurposeGeneralBuoy();




                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 55: { // DAYMAR_Daymark
                            var instance = new Daymark();



                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
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



                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
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




                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 75: { // LITVES_LightVessel
                            var instance = new LightVessel();

                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 85: { // RADRFL_RadarReflector
                            var instance = new RadarReflector();




                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                        }
                        break;
                    case 90: { // RADSTA_RadarStation
                            var instance = new RadarStation();



                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 95: { // RDOSTA_RadioStation
                            var instance = new RadioStation();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }


                            if (current.STATUS != default) {
                                instance.status = GetStatus(current.STATUS);
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 100: { // RETRFL_RetroReflector
                            var instance = new Retroreflector();



                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 105: { // RTPBCN_RadarTransponderBeacon
                            var instance = new RadarTransponderBeacon();



                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;

                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
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

                            // TODO: INFORM
                            var shapeInformation = new shapeInformation() {
                                
                            };

                            var instance = new topmark() {
                                
                            };

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
