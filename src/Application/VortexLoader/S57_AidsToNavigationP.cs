using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.FeatureTypes;


namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_AidsToNavigationP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "AidsToNavigationP";

            var featureRelations = new FeatureRelations();
            featureRelations.Initialize(source);

            var aidstonavigation = source.OpenDataset<FeatureClass>(source.GetName(tableName));

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("point"));
            

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            //// Load aidstonavigation slaves
            //using var cursorRelated = aidstonavigation.Search(filter, true);
            
            //while (cursorRelated.MoveNext()) {

            //}
            

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
                
                var colours = new List<colour>();


                // if slave continue - retrieve related slaves for structure in the relevant structure
                if (featureRelations.IsSlave(globalid)) {
                    continue;

                }

                switch (subtype) {
                    case 1: { // BCNCAR_BeaconCardinal
                            var instance = new CardinalBeacon();

                            AddCondition(instance.condition, feature);
                            AddColour(instance.colour, feature);
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
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

                            AddCondition(instance.condition, feature);
                            AddColour(instance.colour, feature);
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
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
                            AddCondition(instance.condition, feature);
                            AddColour(instance.colour, feature);
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
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

                            AddCondition(instance.condition, feature);
                            AddColour(instance.colour, feature);
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
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

                            AddCondition(instance.condition, feature);
                            AddColour(instance.colour, feature);
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
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
                            
                            AddColour(instance.colour, feature);
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
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
                            
                            AddColour(instance.colour, feature);
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
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
                            
                            
                            AddColour(instance.colour, feature);
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
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
                            
                            
                            AddColour(instance.colour, feature);
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
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
                    case 45: { // BOYSAW_BuoySafeWater
                            var instance = new SafeWaterBuoy();

                            

                            AddColour(instance.colour, feature); 
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
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

                            
                            AddColour(instance.colour, feature);
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
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

                            
                            AddColour(instance.colour, feature);
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
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
                            
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
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

                            if (catlitVal != default) {

                                List<int> catlits = catlitVal
                                                        .Split(',')
                                                        .Select(int.Parse)
                                                        .ToList();

                                if ((sectr1Val == default || sectr2Val == default) && !(catlits.Contains(1) || catlits.Contains(6) || catlits.Contains(7) || catlits.Contains(16))) {
                                    // LIGHTS: Attributes SECTR1 and SECTR2 not present; and/or attribute catlits is not 1, 6, 7, 16
                                    // Build "Light All Around");
                                    var instance = new LightAllAround();

                                    if (plts_comp_scale != default) {
                                        instance.scaleMinimum = plts_comp_scale;
                                    }
                                    
                                    
                                    AddColour(instance.colour, feature);
                                    AddStatus(instance.status, feature);
                                    AddFeatureName(instance.featureName, feature);
                                    AddInformation(instance.information, feature);
                                    buffer["ps"] = ps101;

                                    buffer["code"] = instance.GetType().Name;
                                    buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                                    buffer["shape"] = current.SHAPE;
                                    insert.Insert(buffer);
                                    Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                                    convertedCount++;
                                }
                                else if ((sectr1Val != default && sectr2Val != default) || (catlits.Contains(1) || catlits.Contains(16))) {
                                    // LIGHTS: Attributes SECTR1 and SECTR2 present; and/or attribute catlits = 1 (directional function) or 16 (moiré effect)
                                    // Build "Light Sectored");
                                    var instance = new LightSectored();
                                    if (plts_comp_scale != default) {
                                        instance.scaleMinimum = plts_comp_scale;
                                    }
                                    
                                    AddStatus(instance.status, feature);
                                    AddFeatureName(instance.featureName, feature);
                                    AddInformation(instance.information, feature);
                                    buffer["ps"] = ps101;

                                    buffer["code"] = instance.GetType().Name;
                                    buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                                    buffer["shape"] = current.SHAPE;
                                    insert.Insert(buffer);
                                    Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                                    convertedCount++;
                                }
                                else if (catlits.Contains(6)) {
                                    // LIGHTS: Attribute catlits contains value 6 (air obstruction light)
                                    // Build "Light Air Obstruction");
                                    var instance = new LightAirObstruction();
                                    if (plts_comp_scale != default) {
                                        instance.scaleMinimum = plts_comp_scale;
                                    }
                                    AddColour(instance.colour, feature);
                                    AddStatus(instance.status, feature);
                                    AddFeatureName(instance.featureName, feature);
                                    AddInformation(instance.information, feature);
                                    buffer["ps"] = ps101;

                                    buffer["code"] = instance.GetType().Name;
                                    buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                                    buffer["shape"] = current.SHAPE;
                                    insert.Insert(buffer);
                                    Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                                    convertedCount++;
                                }
                                else if (catlits.Contains(7)) {
                                    // LIGHTS: Attribute catlits contains value 7 (fog detector light)
                                    // Build "Light Fog Detector");
                                    var instance = new LightFogDetector();
                                    if (plts_comp_scale != default) {
                                        instance.scaleMinimum = plts_comp_scale;
                                    }
                                    AddColour(instance.colour, feature);
                                    AddStatus(instance.status, feature);
                                    AddFeatureName(instance.featureName, feature);
                                    AddInformation(instance.information, feature);
                                    buffer["ps"] = ps101;

                                    buffer["code"] = instance.GetType().Name;
                                    buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                                    buffer["shape"] = current.SHAPE;
                                    insert.Insert(buffer);
                                    Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                                    convertedCount++;
                                }
                                else {
                                    Logger.Current.DataError(objectid, tableName, longname, $"Unknown Light Type. Check catlit, sectr1, sectr2");
                                }
                            }
                            // Handle lights without CATLIT
                            

                        }
                        break;
                    case 70: { // LITFLT_LightFloat
                            var instance = new LightFloat();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            
                            AddColour(instance.colour, feature);
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
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
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            
                            AddColour(instance.colour, feature);
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
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
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            
                            AddStatus(instance.status, feature);
                            //AddFeatureName(instance.featureName, feature);
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
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
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


                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
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
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            
                            AddColour(instance.colour, feature);
                            AddStatus(instance.status, feature);
                            //AddFeatureName(instance.featureName, feature);
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
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }
                            
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
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
