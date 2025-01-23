using ArcGIS.Core.Data;
using S100Framework.DomainModel.S101.FeatureTypes;
using DomainModel = S100Framework.DomainModel;
using VortexLoader.S57.esri;
using S100Framework.DomainModel.S101;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_NaturalFeaturesA(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "NaturalFeaturesA";
            
            using var s = source.OpenDataset<FeatureClass>(tableName);
            using var surface = target.OpenDataset<FeatureClass>("surface");

            using var bufferSurface = surface.CreateRowBuffer();
            using var insertSurface = surface.CreateInsertCursor();

            using var cursor = s.Search(filter, true);

            var convertedCount = 0;
            var recordCount = 0;


            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;
                var current = new NaturalFeaturesA(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;
                var condtn = current.CONDTN ?? default;
                var watlev = current.WATLEV ?? default;
                var catlnd = current.CATLND ?? default;
                var natsur = current.NATSUR ?? default;
                var catsea = current.CATSEA ?? default;
                var catslo = current.CATSLO ?? default;
                var color = current.COLOUR ?? default;
                var conrad = current.CONRAD ?? default;
                var convis = current.CONVIS ?? default;
                var catveg = current.CATVEG ?? default;
                var elevat = current.ELEVAT ?? default;
                var height = current.HEIGHT ?? default;
                var verlen = current.VERLEN ?? default;



                    switch (subtype) {
                    case 1: { //  LAKARE
                            var lakare = new Lake {
                                elevation = null,
                                status = null,
                                scaleMinimum = null,
                            };
                            if (elevat !=  default) {
                                lakare.elevation = elevat;
                            }

                            if (plts_comp_scale != default) {
                                lakare.scaleMinimum = plts_comp_scale;
                            }
                            
                            if (status != default) {
                                if (!string.IsNullOrEmpty(status)) {
                                    //TODO: STATUS
                                }
                            }
                            AddFeatureName(lakare.featureName, feature);
                            AddInformation(lakare.information, feature);

                            bufferSurface["ps"] = "S-101";
                            bufferSurface["code"] =  lakare.GetType().Name; 
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(lakare);
                            bufferSurface["shape"] = current.SHAPE;
                            var oid = insertSurface.Insert(bufferSurface);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(lakare));
                            convertedCount++;

                            /* S-57 allows for LAKARE to be covered by the Group 1 objects LNDARE or UNSARE, however in
                               S-101 all Lake features must be covered by the Skin of the Earth feature Land Area. During the
                               automated conversion process, the converter may have the capability to convert UNSARE covering
                               LAKARE to Land Area (taking into account the attribution of any adjoining LNDARE objects) and
                               merge with any adjoining Land Area features. If the converter does not have this capability, Data
                               Producers are advised to check their S-57 data holdings and amend their Group 1 coverage to have
                               LAKARE covered by LNDARE (and merge with adjoining LNDARE as appropriate). */

                            //TODO: LAKARE
                        }
                        break;

                    case 5: { //  LNDARE
                            var lndare = new LandArea {
                                condition = null,
                                status = null,
                                scaleMinimum = null,
                            };
                            if (condtn != default) {
                                lndare.condition = condtn switch {
                                    1 => condition.UnderConstruction,   //  under construction
                                    2 => condition.Ruined,   //  ruined
                                    3 => condition.UnderReclamation,   //  under reclamation                                    
                                    4 => throw new IndexOutOfRangeException(),   //  wingless
                                    5 => throw new IndexOutOfRangeException(),   //  planned construction
                                    -32767 => null,
                                    _ => throw new IndexOutOfRangeException(),
                                };
                            }
                            if (plts_comp_scale != default) {
                                lndare.scaleMinimum = plts_comp_scale;
                            }
                            if (status != default) {
                                if (!string.IsNullOrEmpty(status)) {
                                    /* See S-101 DCEG clause 5.4 for the listing of allowable values. Values populated in S-57 for this attribute
                                       other than the allowable values will not be converted across to S-101. Data Producers are advised to
                                       check any populated values for STATUS on LNDARE and amend appropriately. */

                                    //TODO: STATUS
                                }
                            }
                            AddFeatureName(lndare.featureName, feature);
                            AddInformation(lndare.information, feature);

                            bufferSurface["ps"] = "S-101";
                            bufferSurface["code"] = lndare.GetType().Name; 
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(lndare);
                            bufferSurface["shape"] = current.SHAPE;
                            insertSurface.Insert(bufferSurface);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(lndare));
                            convertedCount++;
                        }
                        break;

                    case 10: {    // LNDRGN
                            var lndrgn = new LandRegion {
                                categoryOfLandRegion = null,
                                natureOfSurface = null,
                                waterLevelEffect = null,
                                scaleMinimum = null,
                            };
                            if (watlev != default) {
                                lndrgn.waterLevelEffect = watlev switch {
                                    1 => waterLevelEffect.PartlySubmergedAtHighWater,  // partly submerged at high water
                                    2 => waterLevelEffect.AlwaysDry,  // always dry
                                    3 => throw new IndexOutOfRangeException(),  // always under water/submerged
                                    4 => throw new IndexOutOfRangeException(),  // covers and uncovers
                                    5 => throw new IndexOutOfRangeException(),  // awash
                                    6 => throw new IndexOutOfRangeException(),  // subject to inundation or flooding
                                    7 => throw new IndexOutOfRangeException(),  // floating
                                    -32767 => null,
                                    _ => throw new IndexOutOfRangeException(),
                                };
                            }
                            if (plts_comp_scale != default) {
                                lndrgn.scaleMinimum = plts_comp_scale;
                            }
                            if (status != default) {
                                if (!string.IsNullOrEmpty(status)) {
                                    //TODO: CATLND
                                }
                            }
                            if (natsur != default) {
                                if (!string.IsNullOrEmpty(status)) {
                                    //TODO: NATSUR
                                }
                            }

                            AddFeatureName(lndrgn.featureName, feature);
                            AddInformation(lndrgn.information, feature);

                            bufferSurface["ps"] = "S-101";
                            bufferSurface["code"] = lndrgn.GetType().Name;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(lndrgn);
                            bufferSurface["shape"] = current.SHAPE;
                            insertSurface.Insert(bufferSurface);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(lndrgn));
                            convertedCount++;

                        }
                        break;

                    case 15: {    // RAPIDS
                            System.Diagnostics.Debugger.Break();
                        }
                        break;

                    case 20: {    // RIVERS
                            var river = new River {
                                status = null,
                                scaleMinimum = null,
                            };
                            if (plts_comp_scale != default) {
                                river.scaleMinimum = plts_comp_scale;
                            }
                            if (status != default) {
                                if (!string.IsNullOrEmpty(status)) {
                                    //TODO: STATUS
                                }
                            }

                            AddFeatureName(river.featureName, feature);
                            AddInformation(river.information, feature);

                            bufferSurface["ps"] = "S-101";
                            bufferSurface["code"] = river.GetType().Name; 
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(river);
                            bufferSurface["shape"] = current.SHAPE;
                            insertSurface.Insert(bufferSurface);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(river));
                            convertedCount++;

                            /* S-57 allows for RIVERS of geometric primitive area to be covered by the Group 1 objects LNDARE
                               or UNSARE, however in S-101 all Rivers of geometric primitive area must be covered by the Skin
                               of the Earth feature Land Area. During the automated conversion process, the converter may have
                               the capability to convert UNSARE covering RIVERS to Land Area (taking into account the attribution
                               of any adjoining LNDARE objects) and merge with any adjoining Land Area features. If the
                               converter does not have this capability, Data Producers are advised to check their S-57 data
                               holdings and amend their Group 1 coverage to have RIVERS of geometric primitive area covered
                               by LNDARE (and merge with adjoining LNDARE as appropriate). */

                            /* S-57 guidance recommends the encoding of intermittent lakes using an instance of the S-57 Object
                               class RIVERS. Data Producers are advised to check all instances of RIVERS of geometric primitive
                               area having attribute STATUS = 5 (periodic/intermittent) and if the real-world feature is a lake to
                               amend to an instance of the S-101 Feature type Lake (see S-101 DCEG clause 5.10). */
                            //TODO: River
                        }
                        break;

                    case 25: {    // SEAARE
                            var seaareanamedwaterarea = new SeaAreaNamedWaterArea {
                                categoryOfSeaArea = null,
                                scaleMinimum = null,
                            };
                            if (catsea != default) {
                                seaareanamedwaterarea.categoryOfSeaArea = catsea switch {
                                    2 => categoryOfSeaArea.Gat,  // gat
                                    3 => categoryOfSeaArea.Bank,  // bank
                                    4 => categoryOfSeaArea.Deep,  // deep
                                    5 => categoryOfSeaArea.Bay,  // bay
                                    6 => categoryOfSeaArea.Trench,  // trench
                                    7 => categoryOfSeaArea.Basin,  // basin
                                    8 => categoryOfSeaArea.MudFlats,  // mud flats
                                    9 => categoryOfSeaArea.Reef,  // reef
                                    10 => categoryOfSeaArea.Ledge, // ledge
                                    11 => categoryOfSeaArea.Canyon, // canyon
                                    12 => categoryOfSeaArea.Narrows, // narrows
                                    13 => categoryOfSeaArea.Shoal, // shoal
                                    14 => categoryOfSeaArea.Knoll, // knoll
                                    15 => categoryOfSeaArea.Ridge, // ridge
                                    16 => categoryOfSeaArea.Seamount, // seamount
                                    17 => categoryOfSeaArea.Pinnacle, // pinnacle
                                    18 => categoryOfSeaArea.AbyssalPlain, // abyssal plain
                                    19 => categoryOfSeaArea.Plateau, // plateau
                                    20 => categoryOfSeaArea.Spur, // spur
                                    21 => categoryOfSeaArea.Shelf, // shelf
                                    22 => categoryOfSeaArea.Trough, // trough
                                    23 => categoryOfSeaArea.Saddle, // saddle
                                    24 => categoryOfSeaArea.AbyssalHill, // abyssal hills
                                    25 => categoryOfSeaArea.Apron, // apron
                                    26 => categoryOfSeaArea.ArchipelagicApron, // archipelagic apron
                                    27 => categoryOfSeaArea.Borderland, // borderland
                                    28 => categoryOfSeaArea.ContinentalMargin, // continental margin
                                    29 => categoryOfSeaArea.ContinentalRise, // continental rise
                                    30 => categoryOfSeaArea.Escarpment, // escarpment
                                    31 => categoryOfSeaArea.Fan, // fan
                                    32 => categoryOfSeaArea.FractureZone, // fracture zone
                                    33 => categoryOfSeaArea.Gap, // gap
                                    34 => categoryOfSeaArea.Guyot, // guyot
                                    35 => categoryOfSeaArea.Hill, // hill
                                    36 => categoryOfSeaArea.Hole, // hole
                                    37 => categoryOfSeaArea.Levee, // levee
                                    38 => categoryOfSeaArea.MedianValley, // median valley
                                    39 => categoryOfSeaArea.Moat, // moat
                                    40 => categoryOfSeaArea.Mountains, // mountains
                                    41 => categoryOfSeaArea.Peak, // peak
                                    42 => categoryOfSeaArea.Province, // province
                                    43 => categoryOfSeaArea.Rise, // rise
                                    44 => categoryOfSeaArea.SeaChannel, // sea channel
                                    45 => categoryOfSeaArea.SeamountChain, // seamount chain
                                    46 => categoryOfSeaArea.ShelfEdge, // shelf-edge
                                    47 => categoryOfSeaArea.Sill, // sill
                                    48 => categoryOfSeaArea.Slope, // slope
                                    49 => categoryOfSeaArea.Terrace, // terrace
                                    50 => categoryOfSeaArea.Valley, // valley
                                    51 => categoryOfSeaArea.Canal, // canal
                                    52 => categoryOfSeaArea.Lake, // lake
                                    53 => categoryOfSeaArea.River, // river
                                    54 => categoryOfSeaArea.Reach,  // reach
                                    -32767 => null,
                                    _ => throw new IndexOutOfRangeException(),
                                };
                            }
                            if (plts_comp_scale != default) {
                                seaareanamedwaterarea.scaleMinimum = plts_comp_scale;
                            }

                            AddFeatureName(seaareanamedwaterarea.featureName, feature);
                            AddInformation(seaareanamedwaterarea.information, feature);

                            bufferSurface["ps"] = "S-101";
                            bufferSurface["code"] = seaareanamedwaterarea.GetType().Name;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(seaareanamedwaterarea);
                            bufferSurface["shape"] = current.SHAPE;
                            insertSurface.Insert(bufferSurface);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(seaareanamedwaterarea));
                            convertedCount++;

                        }
                        break;

                    case 30: {    // SLOGRD
                            var slopingground = new SlopingGround {
                                categoryOfSlope = null,
                                radarConspicuous = null,
                                visualProminence = null,
                                scaleMinimum = null,
                            };
                            if (catslo != default) {
                                slopingground.categoryOfSlope = catslo switch {
                                    1 => categoryOfSlope.Cutting,  // cutting
                                    2 => categoryOfSlope.Embankment,  // embankment
                                    3 => categoryOfSlope.Dune,  // dune
                                    4 => categoryOfSlope.Hill,  // hill
                                    5 => categoryOfSlope.Pingo,  // pingo
                                    6 => categoryOfSlope.Cliff,  // cliff
                                    7 => categoryOfSlope.Scree,  // scree
                                    -32767 => null,
                                    _ => throw new IndexOutOfRangeException(),
                                };
                            }
                            if (color != default) {
                                if (!string.IsNullOrEmpty(color)) {
                                    foreach (var c in color.Split(',', StringSplitOptions.RemoveEmptyEntries)) {
                                        colour? e = c.ToLowerInvariant() switch {
                                            "white" => colour.White,
                                            "black" => colour.Black,
                                            "Red" => colour.Red,
                                            "green" => colour.Green,
                                            "blue" => colour.Blue,
                                            "yellow" => colour.Yellow,
                                            "grey" => colour.Grey,
                                            "brown" => colour.Brown,
                                            "amber" => colour.Grey,
                                            _ => throw new IndexOutOfRangeException(),
                                        };
                                        if (e.HasValue) {
                                            slopingground.colour.Add(e.Value);
                                        }
                                    }
                                }
                            }
                            if (natsur != default) {
                                if (!string.IsNullOrEmpty(natsur)) {
                                    foreach (var c in natsur.Split(',', StringSplitOptions.RemoveEmptyEntries)) {
                                        natureOfSurface? e = c.ToLowerInvariant() switch {
                                            "mud" => natureOfSurface.Mud,
                                            "clay" => natureOfSurface.Clay,
                                            "silt" => natureOfSurface.Silt,
                                            "sand" => natureOfSurface.Sand,
                                            "stone" => natureOfSurface.Stone,
                                            "gravel" => natureOfSurface.Gravel,
                                            _ => throw new IndexOutOfRangeException(),
                                        };
                                        if (e.HasValue) {
                                            slopingground.natureOfSurface.Add(e.Value);
                                        }
                                    }
                                }
                            }
                            if (conrad != default) {
                                slopingground.radarConspicuous = conrad switch {
                                    1 => true,  // radar conspicuous
                                    2 => false, // not radar conspicuous
                                    3 => true,  // radar conspicuous (has radar reflector)
                                    -32767 => null,
                                    _ => throw new IndexOutOfRangeException(),
                                };
                            }
                            if (convis != default) {
                                slopingground.visualProminence = convis switch {
                                    1 => visualProminence.VisuallyConspicuous,  // visually conspicuous
                                    2 => visualProminence.NotVisuallyConspicuous,  // not visually conspicuous                                
                                    -32767 => null,
                                    _ => throw new IndexOutOfRangeException(),
                                };
                            }
                            if (plts_comp_scale != default) {
                                slopingground.scaleMinimum = plts_comp_scale;
                            }

                            AddFeatureName(slopingground.featureName, feature);
                            AddInformation(slopingground.information, feature);

                            bufferSurface["ps"] = "S-101";
                            bufferSurface["code"] = slopingground.GetType().Name; 
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(slopingground);
                            bufferSurface["shape"] = current.SHAPE;
                            insertSurface.Insert(bufferSurface);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(slopingground));
                            convertedCount++;

                        }
                        break;

                    case 35: {    // VEGATN
                            var vegetationCategory = catveg?.ToLowerInvariant() switch {
                                "3" => categoryOfVegetation.Bush,
                                "4" => categoryOfVegetation.DeciduousWood,
                                "5" => categoryOfVegetation.ConiferousWood,
                                "6" => categoryOfVegetation.WoodInGeneralIncMixedWood,
                                "11" => categoryOfVegetation.Reed,
                                "13" => categoryOfVegetation.TreeInGeneral,
                                "14" => categoryOfVegetation.EvergreenTree,
                                _ => throw new IndexOutOfRangeException(),
                            };
                            var vegetation = new Vegetation {
                                categoryOfVegetation = vegetationCategory,
                                visualProminence = null,
                                elevation = null,
                                height = null,
                                verticalLength = null,
                                scaleMinimum = null,
                            };
                            if (elevat != default) {
                                vegetation.elevation = elevat;
                            }
                            if (height != default) {
                                vegetation.height = height;
                            }
                            if (verlen != default) {
                                vegetation.verticalLength = verlen;
                            }

                            if (convis != default) {
                                vegetation.visualProminence = convis switch {
                                    1 => visualProminence.VisuallyConspicuous,  // visually conspicuous
                                    2 => visualProminence.NotVisuallyConspicuous,  // not visually conspicuous                                
                                    -32767 => null,
                                    _ => throw new IndexOutOfRangeException(),
                                };
                            }
                            if (plts_comp_scale != default) {
                                vegetation.scaleMinimum = plts_comp_scale;
                            }

                            AddFeatureName(vegetation.featureName, feature);
                            AddInformation(vegetation.information, feature);

                            bufferSurface["ps"] = "S-101";
                            bufferSurface["code"] = vegetation.GetType().Name;
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(vegetation);
                            bufferSurface["shape"] = current.SHAPE;
                            insertSurface.Insert(bufferSurface);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(vegetation));
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
