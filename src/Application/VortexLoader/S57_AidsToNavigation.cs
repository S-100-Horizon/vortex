using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using CommandLine;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S128.FeatureTypes;
using VortexLoader;
using System;
using static S100Framework.Applications.VortexLoader;
using static System.Net.WebRequestMethods;
using IO = System.IO;
using VortexLoader.S57.esri;
using static ArcGIS.Core.Data.NetworkDiagrams.AngleDirectedDiagramLayoutParameters;
using System.Numerics;
using ArcGIS.Core.CIM;
using System.Collections.Generic;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_AidsToNavigationP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "AidsToNavigation";

            var plts_frels = LoadPltsFrels(source);

            var ps = "S-101";

            var aidstonavigation = source.OpenDataset<FeatureClass>("AidsToNavigationP");

            using var featureClass = target.OpenDataset<FeatureClass>("point");
            using var informationtype = target.OpenDataset<Table>("informationtype");

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
                var colour = current.COLOUR ?? default;   // list of integers
                var boyshp = current.BOYSHP ?? default;   // domain value
                var bcnshp = current.BCNSHP ?? default;   // domain value
                var colpat = current.COLPAT ?? default; 
                var litchr = current.LITCHR ?? default;
                var marsys = current.MARSYS ?? default;
                var orient = current.ORIENT ?? default;


                // if slave continue - retrieve related slaves for structure in the relevant structure
                if (plts_frels.ContainsKey(globalid)) {
                    var plts_frel = plts_frels[globalid];
                    continue;
                }

                switch (subtype) {
                    case 1: { // BCNCAR_BeaconCardinal
                            var instance = new CardinalBeacon();
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps;
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
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
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
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
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
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
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
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
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
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
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
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
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
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
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
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
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
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
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
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
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
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 60: { // FOGSIG_FogSignal
                            var instance = new FogSignal();
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 65: { // LIGHTS_Light

                            if (catlitVal == default) {
                                Logger.Current.DataError(objectid, tableName, longname, "empty catlit");
                                continue;
                            }

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

                                AddFeatureName(instance.featureName, feature);
                                AddInformation(instance.information, feature);
                                buffer["ps"] = ps;
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

                                AddFeatureName(instance.featureName, feature);
                                AddInformation(instance.information, feature);
                                buffer["ps"] = ps;
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

                                AddFeatureName(instance.featureName, feature);
                                AddInformation(instance.information, feature);
                                buffer["ps"] = ps;
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

                                AddFeatureName(instance.featureName, feature);
                                AddInformation(instance.information, feature);
                                buffer["ps"] = ps;
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
                        break;
                    case 70: { // LITFLT_LightFloat
                            var instance = new LightFloat();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
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

                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
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

                            //AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
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

                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
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

                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
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

                            //AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
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

                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
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
