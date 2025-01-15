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

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void AidsToNavigation(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "AidsToNavigation";

            var ps = "S-101";

            var aidstonavigation = source.OpenDataset<FeatureClass>("AidsToNavigation");

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
                        }
                        break;
                    case 5: { // BCNISD_BeaconIsolatedDanger
                        }
                        break;
                    case 10: { // BCNLAT_BeaconLateral
                        }
                        break;
                    case 15: { // BCNSAW_BeaconSafeWater
                        }
                        break;
                    case 20: { // BCNSPP_BeaconSpecialPurpose
                        }
                        break;
                    case 25: { // BOYCAR_BuoyCardinal
                        }
                        break;
                    case 30: { // BOYINB_BuoyInstallation
                        }
                        break;
                    case 35: { // BOYISD_BuoyIsolatedDanger
                        }
                        break;
                    case 40: { // BOYLAT_BuoyLateral
                        }
                        break;
                    case 45: { // BOYSAW_BuoySafeWater
                        }
                        break;
                    case 50: { // BOYSPP_BuoySpecialPurpose
                        }
                        break;
                    case 55: { // DAYMAR_Daymark
                        }
                        break;
                    case 60: { // FOGSIG_FogSignal
                        }
                        break;
                    case 65: { // LIGHTS_Light
                        }
                        break;
                    case 70: { // LITFLT_LightFloat
                        }
                        break;
                    case 75: { // LITVES_LightVessel
                        }
                        break;
                    case 85: { // RADRFL_RadarReflector
                        }
                        break;
                    case 90: { // RADSTA_RadarStation
                        }
                        break;
                    case 95: { // RDOSTA_RadioStation
                        }
                        break;
                    case 100: { // RETRFL_RetroReflector
                        }
                        break;
                    case 105: { // RTPBCN_RadarTransponderBeacon
                        }
                        break;
                    case 110: { // TOPMAR_Topmark
                        }
                        break;

                }



            }
            Logger.Current.DataTotalCount(tableName, recordCount, convertedCount);
        }

    }
}
