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

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_AidsToNavigationP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "AidsToNavigation";

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




                switch (subtype) {
                    case 1: { // BCNCAR_BeaconCardinal
                            var instance = new CardinalBeacon();
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps;
                            buffer["code"] = nameof(instance);
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
                            buffer["code"] = nameof(instance);
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
                            buffer["code"] = nameof(instance);
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
                            buffer["code"] = nameof(instance);
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
                            buffer["code"] = nameof(instance);
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
                            buffer["code"] = nameof(instance);
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
                            buffer["code"] = nameof(instance);
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
                            buffer["code"] = nameof(instance);
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
                            buffer["code"] = nameof(instance);
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
                            buffer["code"] = nameof(instance);
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
                            buffer["code"] = nameof(instance);
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
                            buffer["code"] = nameof(instance);
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
                            buffer["code"] = nameof(instance);
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 65: { // LIGHTS_Light
                            var catlit = current.CATLIT ?? default;

                            if (catlit == default) {
                                Logger.Current.DataError(objectid, tableName, longname, "empty catlit");
                                continue;
                            }

                            //// directional function
                            //if (!string.Equals(catlit, "1",StringComparison.InvariantCultureIgnoreCase)) {
                            //    var instance = new LightAllAround();
                            //    AddFeatureName(instance.featureName, feature);
                            //    AddInformation(instance.information, feature);
                            //    buffer["ps"] = ps;
                            //    buffer["code"] = nameof(instance);
                            //    buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            //    buffer["shape"] = current.SHAPE;
                            //    insert.Insert(buffer);
                            //    Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            //    convertedCount++;
                            //}

                            //// air obstruction light


                        }
                        break;
                    case 70: { // LITFLT_LightFloat
                            var instance = new LightFloat();
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
                            buffer["code"] = nameof(instance);
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                        }
                        break;
                    case 75: { // LITVES_LightVessel
                            var instance = new LightVessel();
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
                            buffer["code"] = nameof(instance);
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 85: { // RADRFL_RadarReflector
                            var instance = new RadarReflector();
                            //AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
                            buffer["code"] = nameof(instance);
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                        }
                        break;
                    case 90: { // RADSTA_RadarStation
                            var instance = new RadarStation();
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
                            buffer["code"] = nameof(instance);
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 95: { // RDOSTA_RadioStation
                            var instance = new RadioStation();
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
                            buffer["code"] = nameof(instance);
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 100: { // RETRFL_RetroReflector
                            var instance = new Retroreflector();
                            //AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
                            buffer["code"] = nameof(instance);
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 105: { // RTPBCN_RadarTransponderBeacon
                            var instance = new RadarTransponderBeacon();
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
                            buffer["code"] = nameof(instance);
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
                        }
                        break;

                }



            }
            Logger.Current.DataTotalCount(tableName, recordCount, convertedCount);
        }

    }
}
