using ArcGIS.Core.Data;
using S100Framework.DomainModel.S101;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_NaturalFeaturesA(Geodatabase source, Geodatabase target, QueryFilter filter) {
            Console.WriteLine("NaturalFeaturesA");

            using var s = source.OpenDataset<FeatureClass>("NaturalFeaturesA");
            using var surface = target.OpenDataset<FeatureClass>("surface");

            using var bufferSurface = surface.CreateRowBuffer();
            using var insertSurface = surface.CreateInsertCursor();

            using var cursor = s.Search(filter, true);
            while (cursor.MoveNext()) {
                var current = (Feature)cursor.Current;
                var subtype = Convert.ToInt32(current["FCSubtype"]);

                switch (subtype) {
                    case 1: { //  LAKARE
                            var lakare = new S100Framework.DomainModel.S101.FeatureTypes.Lake {
                                elevation = null,
                                status = null,
                                scaleMinimum = null,
                            };
                            if (DBNull.Value != current["ELEVAT"]) {
                                lakare.elevation = Convert.ToDecimal(current["ELEVAT"]);
                            }
                            if (DBNull.Value != current["PLTS_COMP_SCALE"] && current["PLTS_COMP_SCALE"] is not null) {
                                lakare.scaleMinimum = Convert.ToInt32(current["PLTS_COMP_SCALE"]);
                            }
                            if (DBNull.Value != current["STATUS"]) {
                                var status = Convert.ToString(current["STATUS"]);
                                if (!string.IsNullOrEmpty(status)) {
                                    //TODO: STATUS
                                }
                            }
                            AddFeatureName(lakare.featureName, current);
                            AddInformation(lakare.information, current);

                            bufferSurface["ps"] = "S-101";
                            bufferSurface["code"] = "Lake";
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(lakare);
                            bufferSurface["shape"] = current.GetShape();
                            var oid = insertSurface.Insert(bufferSurface);

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
                            var lndare = new S100Framework.DomainModel.S101.FeatureTypes.LandArea {
                                condition = null,
                                status = null,
                                scaleMinimum = null,
                            };
                            if (DBNull.Value != current["CONDTN"] && current["CONDTN"] is not null) {
                                lndare.condition = Convert.ToInt32(current["CONDTN"]) switch {
                                    1 => condition.UnderConstruction,   //  under construction
                                    2 => condition.Ruined,   //  ruined
                                    3 => condition.UnderReclamation,   //  under reclamation                                    
                                    4 => throw new IndexOutOfRangeException(),   //  wingless
                                    5 => throw new IndexOutOfRangeException(),   //  planned construction
                                    -32767 => null,
                                    _ => throw new IndexOutOfRangeException(),
                                };
                            }
                            if (DBNull.Value != current["PLTS_COMP_SCALE"] && current["PLTS_COMP_SCALE"] is not null) {
                                lndare.scaleMinimum = Convert.ToInt32(current["PLTS_COMP_SCALE"]);
                            }
                            if (DBNull.Value != current["STATUS"]) {
                                var status = Convert.ToString(current["STATUS"]);
                                if (!string.IsNullOrEmpty(status)) {
                                    /* See S-101 DCEG clause 5.4 for the listing of allowable values. Values populated in S-57 for this attribute
                                       other than the allowable values will not be converted across to S-101. Data Producers are advised to
                                       check any populated values for STATUS on LNDARE and amend appropriately. */

                                    //TODO: STATUS
                                }
                            }
                            AddFeatureName(lndare.featureName, current);
                            AddInformation(lndare.information, current);

                            bufferSurface["ps"] = "S-101";
                            bufferSurface["code"] = "LandArea";
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(lndare);
                            bufferSurface["shape"] = current.GetShape();
                            insertSurface.Insert(bufferSurface);
                        }
                        break;

                    case 10: {    // LNDRGN
                            var lndrgn = new S100Framework.DomainModel.S101.FeatureTypes.LandRegion {
                                categoryOfLandRegion = null,
                                natureOfSurface = null,
                                waterLevelEffect = null,
                                scaleMinimum = null,
                            };
                            if (DBNull.Value != current["WATLEV"] && current["WATLEV"] is not null) {
                                lndrgn.waterLevelEffect = Convert.ToInt32(current["WATLEV"]) switch {
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
                            if (DBNull.Value != current["PLTS_COMP_SCALE"] && current["PLTS_COMP_SCALE"] is not null) {
                                lndrgn.scaleMinimum = Convert.ToInt32(current["PLTS_COMP_SCALE"]);
                            }
                            if (DBNull.Value != current["CATLND"]) {
                                var status = Convert.ToString(current["CATLND"]);
                                if (!string.IsNullOrEmpty(status)) {
                                    //TODO: CATLND
                                }
                            }
                            if (DBNull.Value != current["NATSUR"]) {
                                var status = Convert.ToString(current["NATSUR"]);
                                if (!string.IsNullOrEmpty(status)) {
                                    //TODO: NATSUR
                                }
                            }

                            AddFeatureName(lndrgn.featureName, current);
                            AddInformation(lndrgn.information, current);

                            bufferSurface["ps"] = "S-101";
                            bufferSurface["code"] = "LandRegion";
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(lndrgn);
                            bufferSurface["shape"] = current.GetShape();
                            insertSurface.Insert(bufferSurface);
                        }
                        break;

                    case 15: {    // RAPIDS
                            System.Diagnostics.Debugger.Break();
                        }
                        break;

                    case 20: {    // RIVERS
                            var river = new S100Framework.DomainModel.S101.FeatureTypes.River {
                                status = null,
                                scaleMinimum = null,
                            };
                            if (DBNull.Value != current["PLTS_COMP_SCALE"] && current["PLTS_COMP_SCALE"] is not null) {
                                river.scaleMinimum = Convert.ToInt32(current["PLTS_COMP_SCALE"]);
                            }
                            if (DBNull.Value != current["STATUS"]) {
                                var status = Convert.ToString(current["STATUS"]);
                                if (!string.IsNullOrEmpty(status)) {
                                    //TODO: STATUS
                                }
                            }

                            AddFeatureName(river.featureName, current);
                            AddInformation(river.information, current);

                            bufferSurface["ps"] = "S-101";
                            bufferSurface["code"] = "River";
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(river);
                            bufferSurface["shape"] = current.GetShape();
                            insertSurface.Insert(bufferSurface);

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
                            var seaareanamedwaterarea = new S100Framework.DomainModel.S101.FeatureTypes.SeaAreaNamedWaterArea {
                                categoryOfSeaArea = null,
                                scaleMinimum = null,
                            };
                            if (DBNull.Value != current["CATSEA"] && current["CATSEA"] is not null) {
                                seaareanamedwaterarea.categoryOfSeaArea = Convert.ToInt32(current["CATSEA"]) switch {
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
                            if (DBNull.Value != current["PLTS_COMP_SCALE"] && current["PLTS_COMP_SCALE"] is not null) {
                                seaareanamedwaterarea.scaleMinimum = Convert.ToInt32(current["PLTS_COMP_SCALE"]);
                            }

                            AddFeatureName(seaareanamedwaterarea.featureName, current);
                            AddInformation(seaareanamedwaterarea.information, current);

                            bufferSurface["ps"] = "S-101";
                            bufferSurface["code"] = "SeaAreaNamedWaterArea";
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(seaareanamedwaterarea);
                            bufferSurface["shape"] = current.GetShape();
                            insertSurface.Insert(bufferSurface);
                        }
                        break;

                    case 30: {    // SLOGRD
                            var slopingground = new S100Framework.DomainModel.S101.FeatureTypes.SlopingGround {
                                categoryOfSlope = null,
                                radarConspicuous = null,
                                visualProminence = null,
                                scaleMinimum = null,
                            };
                            if (DBNull.Value != current["CATSEA"] && current["CATSLO"] is not null) {
                                slopingground.categoryOfSlope = Convert.ToInt32(current["CATSLO"]) switch {
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
                            if (DBNull.Value != current["COLOUR"]) {
                                var colour = Convert.ToString(current["COLOUR"]);
                                if (!string.IsNullOrEmpty(colour)) {
                                    foreach (var c in colour.Split(',', StringSplitOptions.RemoveEmptyEntries)) {
                                        DomainModel.S101.colour? e = c.ToLowerInvariant() switch {
                                            "white" => DomainModel.S101.colour.White,
                                            "black" => DomainModel.S101.colour.Black,
                                            "Red" => DomainModel.S101.colour.Red,
                                            "green" => DomainModel.S101.colour.Green,
                                            "blue" => DomainModel.S101.colour.Blue,
                                            "yellow" => DomainModel.S101.colour.Yellow,
                                            "grey" => DomainModel.S101.colour.Grey,
                                            "brown" => DomainModel.S101.colour.Brown,
                                            "amber" => DomainModel.S101.colour.Grey,
                                            _ => throw new IndexOutOfRangeException(),
                                        };
                                        if (e.HasValue) {
                                            slopingground.colour.Add(e.Value);
                                        }
                                    }
                                }
                            }
                            if (DBNull.Value != current["NATSUR"]) {
                                var natsur = Convert.ToString(current["NATSUR"]);
                                if (!string.IsNullOrEmpty(natsur)) {
                                    foreach (var c in natsur.Split(',', StringSplitOptions.RemoveEmptyEntries)) {
                                        DomainModel.S101.natureOfSurface? e = c.ToLowerInvariant() switch {
                                            "mud" => DomainModel.S101.natureOfSurface.Mud,
                                            "clay" => DomainModel.S101.natureOfSurface.Clay,
                                            "silt" => DomainModel.S101.natureOfSurface.Silt,
                                            "sand" => DomainModel.S101.natureOfSurface.Sand,
                                            "stone" => DomainModel.S101.natureOfSurface.Stone,
                                            "gravel" => DomainModel.S101.natureOfSurface.Gravel,
                                            _ => throw new IndexOutOfRangeException(),
                                        };
                                        if (e.HasValue) {
                                            slopingground.natureOfSurface.Add(e.Value);
                                        }
                                    }
                                }
                            }
                            if (DBNull.Value != current["CONRAD"] && current["CONRAD"] is not null) {
                                var conrad = Convert.ToInt32(current["CONRAD"]);
                                slopingground.radarConspicuous = conrad switch {
                                    1 => true,  // radar conspicuous
                                    2 => false, // not radar conspicuous
                                    3 => true,  // radar conspicuous (has radar reflector)
                                    -32767 => null,
                                    _ => throw new IndexOutOfRangeException(),
                                };
                            }
                            if (DBNull.Value != current["CONVIS"] && current["CONVIS"] is not null) {
                                var convis = Convert.ToInt32(current["CONVIS"]);
                                slopingground.visualProminence = convis switch {
                                    1 => DomainModel.S101.visualProminence.VisuallyConspicuous,  // visually conspicuous
                                    2 => DomainModel.S101.visualProminence.NotVisuallyConspicuous,  // not visually conspicuous                                
                                    -32767 => null,
                                    _ => throw new IndexOutOfRangeException(),
                                };
                            }
                            if (DBNull.Value != current["PLTS_COMP_SCALE"] && current["PLTS_COMP_SCALE"] is not null) {
                                slopingground.scaleMinimum = Convert.ToInt32(current["PLTS_COMP_SCALE"]);
                            }

                            AddFeatureName(slopingground.featureName, current);
                            AddInformation(slopingground.information, current);

                            bufferSurface["ps"] = "S-101";
                            bufferSurface["code"] = "SlopingGround";
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(slopingground);
                            bufferSurface["shape"] = current.GetShape();
                            insertSurface.Insert(bufferSurface);
                        }
                        break;

                    case 35: {    // VEGATN
                            var categoryOfVegetation = Convert.ToString(current["CATVEG"])?.ToLowerInvariant() switch {
                                "3" => DomainModel.S101.categoryOfVegetation.Bush,
                                "4" => DomainModel.S101.categoryOfVegetation.DeciduousWood,
                                "5" => DomainModel.S101.categoryOfVegetation.ConiferousWood,
                                "6" => DomainModel.S101.categoryOfVegetation.WoodInGeneralIncMixedWood,
                                "11" => DomainModel.S101.categoryOfVegetation.Reed,
                                "13" => DomainModel.S101.categoryOfVegetation.TreeInGeneral,
                                "14" => DomainModel.S101.categoryOfVegetation.EvergreenTree,
                                _ => throw new IndexOutOfRangeException(),
                            };
                            var vegetation = new S100Framework.DomainModel.S101.FeatureTypes.Vegetation {
                                categoryOfVegetation = categoryOfVegetation,
                                visualProminence = null,
                                elevation = null,
                                height = null,
                                verticalLength = null,
                                scaleMinimum = null,
                            };
                            if (DBNull.Value != current["ELEVAT"]) {
                                vegetation.elevation = Convert.ToDecimal(current["ELEVAT"]);
                            }
                            if (DBNull.Value != current["HEIGHT"]) {
                                vegetation.height = Convert.ToDecimal(current["HEIGHT"]);
                            }
                            if (DBNull.Value != current["VERLEN"]) {
                                vegetation.verticalLength = Convert.ToDecimal(current["VERLEN"]);
                            }
                            if (DBNull.Value != current["CONVIS"] && current["CONVIS"] is not null) {
                                var convis = Convert.ToInt32(current["CONVIS"]);
                                vegetation.visualProminence = convis switch {
                                    1 => DomainModel.S101.visualProminence.VisuallyConspicuous,  // visually conspicuous
                                    2 => DomainModel.S101.visualProminence.NotVisuallyConspicuous,  // not visually conspicuous                                
                                    -32767 => null,
                                    _ => throw new IndexOutOfRangeException(),
                                };
                            }
                            if (DBNull.Value != current["PLTS_COMP_SCALE"] && current["PLTS_COMP_SCALE"] is not null) {
                                vegetation.scaleMinimum = Convert.ToInt32(current["PLTS_COMP_SCALE"]);
                            }

                            AddFeatureName(vegetation.featureName, current);
                            AddInformation(vegetation.information, current);

                            bufferSurface["ps"] = "S-101";
                            bufferSurface["code"] = "Vegetation";
                            bufferSurface["json"] = System.Text.Json.JsonSerializer.Serialize(vegetation);
                            bufferSurface["shape"] = current.GetShape();
                            insertSurface.Insert(bufferSurface);
                        }
                        break;
                }
            }
        }
    }
}
