using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_CoastlineL(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "CoastlineL";

            var coastlinel = source.OpenDataset<FeatureClass>(source.GetName(tableName));

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("curve"));
            

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = coastlinel.Search(filter, true);
            int recordCount = 0;
            int convertedCount = 0;
            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new CoastlineL(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;
                var watlev = current.WATLEV ?? default;

                var catcoa = current.CATCOA ?? default;
                var catslc = current.CATSLC ?? default;
                

                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;

                switch (subtype) {
                    case 1: { // COALNE_Coastline
                            var instance = new Coastline();

                            if (catcoa != default) {
                                natureOfSurface? e = catcoa switch {
                                    3 => natureOfSurface.Sand,
                                    4 => natureOfSurface.Stone,
                                    5 => natureOfSurface.Pebbles,
                                    9 => natureOfSurface.Coral,
                                    11 => natureOfSurface.Shells,
                                    -32767 => (natureOfSurface)(-32767),
                                    _ => null //lthrow new IndexOutOfRangeException($"catcoa to natureOfSurface: {catcoa}")
                                };  
                                if (e.HasValue) {
                                    instance.natureOfSurface = [e.Value];

                                }
                            }

                            if (catcoa != default && instance.natureOfSurface == default) {
                                categoryOfCoastline? e = catcoa switch {
                                    1 => categoryOfCoastline.SteepCoast,
                                    2 => categoryOfCoastline.FlatCoast,
                                    //3 => categoryOfCoastline.., // SANDY SHORE
                                    //4 => categoryOfCoastline., // STONY SHORE
                                    //5 => categoryOfCoastline., // SHINGLY SHORE
                                    6 => categoryOfCoastline.GlacierSeawardEnd,
                                    7 => categoryOfCoastline.Mangrove,
                                    8 => categoryOfCoastline.MarshyShore,
                                    //9 => categoryOfCoastline., //CORAL REEF
                                    //10 => categoryOfCoastline, // ICE COAST
                                    //11 => categoryOfCoastline, // SHELLY SHORE
                                    -32767 => (categoryOfCoastline)(-32767),
                                    _ => throw new IndexOutOfRangeException($"catcoa to categoryOfCoastLine: {catcoa}")
                                };
                                if (e.HasValue) {
                                    instance.categoryOfCoastline = e.Value;
                                }
                            }

                            AddColour(instance.colour, feature);
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
                    case 
                    5: { // SLCONS_ShorelineConstruction
                            // Restricted allowable S-101 enumerate values for STATUS.
                            // Reconcile conversion of CATSLC = 6(wharf(quay)) to
                            // category of shoreline construction = 6(wharf) or 22
                            // (quay).

                            var instance = new ShorelineConstruction();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            /*
                                NAUTICAL_ENC_CATSLC
			                    -32767: Unknown
			                    1: breakwater
			                    2: groyne (groin)
			                    3: mole
			                    4: pier (jetty)
			                    5: promenade pier
			                    6: wharf (quay)
			                    7: training wall
			                    8: rip rap
			                    9: revetment
			                    10: sea wall
			                    11: landing steps
			                    12: ramp
			                    13: slipway
			                    14: fender
			                    15: solid face wharf
			                    16: open face wharf
			                    17: log ramp
                            */

                            if (catslc != default) {
                                categoryOfShorelineConstruction? e = catslc switch {
                                    1 => categoryOfShorelineConstruction.Breakwater,
                                    2 => categoryOfShorelineConstruction.Groyne,
                                    3 => categoryOfShorelineConstruction.Mole,
                                    4 => categoryOfShorelineConstruction.PierJetty, 
                                    5 => categoryOfShorelineConstruction.PromenadePier, 
                                    6 => categoryOfShorelineConstruction.Wharf,
                                    7 => categoryOfShorelineConstruction.TrainingWall,
                                    8 => categoryOfShorelineConstruction.RipRap,
                                    9 => categoryOfShorelineConstruction.Revetment, 
                                    10 => categoryOfShorelineConstruction.SeaWall, 
                                    11 => categoryOfShorelineConstruction.LandingSteps, 
                                    12 => categoryOfShorelineConstruction.Ramp, 
                                    13 => categoryOfShorelineConstruction.Slipway, 
                                    14 => categoryOfShorelineConstruction.Fender, 
                                    15 => categoryOfShorelineConstruction.SolidFaceWharf, 
                                    16 => categoryOfShorelineConstruction.OpenFaceWharf, 
                                    17 => categoryOfShorelineConstruction.LogRamp, 
                                    -32767 => (categoryOfShorelineConstruction)(-32767),
                                    _ => throw new IndexOutOfRangeException($"catslc to categoryOfShorelineConstruction: {catslc}")
                                };
                                if (e.HasValue) {
                                    instance.categoryOfShorelineConstruction = e.Value;
                                }
                            }

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
