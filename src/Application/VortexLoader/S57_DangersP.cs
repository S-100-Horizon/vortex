using ArcGIS.Core.Data;
using S100Framework.DomainModel.S101;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_DangersP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            Console.WriteLine("DangersP");


            var ps = "S-101";

            var s = source.OpenDataset<FeatureClass>("DangersP");

            var p = source.OpenDataset<FeatureClass>("Dredged");




            using var featureClass = target.OpenDataset<FeatureClass>("point");
            using var informationtype = target.OpenDataset<Table>("informationtype");

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = s.Search(filter, true);
            while (cursor.MoveNext()) {
                var current = (Feature)cursor.Current;
                var subtype = Convert.ToInt32(current["FCSubtype"]);

                var catobs = Convert.ToString(current["CATOBS"]); // 


                Decimal valsou = -32767;
                bool isValsouEmpty = true;

                if (DBNull.Value != current["VALSOU"] && current["VALSOU"] is not null) {
                    valsou = Convert.ToDecimal(current["VALSOU"]);
                    isValsouEmpty = false;
                }

                switch (subtype) {
                    case 1: { // CTNARE
                            // TODO: no instances in NIS
                            throw new NotImplementedException();
                        }
                    //break;

                    case 10: { // FSHFAC Fishing facilities
                            // TODO: no instances in NIS
                            throw new NotImplementedException();
                        }
                    //break;

                    case 20: { // OBSTRN

                            /*
                             OBSTRN of geometric primitive area or line with attribute INFORM = Submerged weir will be
                             converted to an instance of the S-101 Feature type Dam (see clause 4.8.5). Where this is the case,
                             the attributes CATOBS, EXPSOU, NATQUA, NATSUR, PRODCT, QUASOU, SOUACC, TECSOU
                             and VALSOU will not be converted. It is considered that these attributes are not relevant for Dam in
                             S-101. 
                            */

                            waterLevelEffect waterLeveleffectCurrent = default;

                            var obstruction = new S100Framework.DomainModel.S101.FeatureTypes.Obstruction {
                                surroundingDepth = valsou,
                                waterLevelEffect = waterLeveleffectCurrent
                            };

                            obstruction.condition = default;

                            if (isValsouEmpty) {
                                // TODO: implement
                                //var featureCursor = QueryByGeometry(current.GetShape(),)
                                obstruction.defaultClearanceDepth = valsou;

                            }


                            if (DBNull.Value != current["WATLEV"] && current["WATLEV"] is not null) {
                                obstruction.waterLevelEffect = Convert.ToInt32(current["WATLEV"]) switch {
                                    1 => waterLevelEffect.PartlySubmergedAtHighWater,  // partly submerged at high water
                                    2 => waterLevelEffect.AlwaysDry,  // always dry
                                    3 => waterLevelEffect.AlwaysUnderWaterSubmerged,  // always under water/submerged
                                    4 => waterLevelEffect.CoversAndUncovers,  // covers and uncovers
                                    5 => waterLevelEffect.Awash,  // awash
                                    6 => waterLevelEffect.SubjectToInundationOrFlooding,  // subject to inundation or flooding
                                    7 => waterLevelEffect.Floating,  // floating
                                    -32767 => (waterLevelEffect)(-32767),
                                    // TODO: QUESTION: how to handle -32767 on a required attribute without an S-101 equivalent "unknown". Illegal value assigned. MUST be fixed.

                                    _ => throw new IndexOutOfRangeException(),
                                };
                            }


                            if (DBNull.Value != current["PLTS_COMP_SCALE"] && current["PLTS_COMP_SCALE"] is not null) {
                                obstruction.scaleMinimum = Convert.ToInt32(current["PLTS_COMP_SCALE"]);
                            }

                            AddFeatureName(obstruction.featureName, current);
                            AddInformation(obstruction.information, current);

                            buffer["ps"] = ps;
                            buffer["code"] = nameof(S100Framework.DomainModel.S101.FeatureTypes.Obstruction); ;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(obstruction);
                            buffer["shape"] = current.GetShape();
                            insert.Insert(buffer);
                        }
                        break;

                    case 35: { // UWTROC
                            var uwtroc = new S100Framework.DomainModel.S101.FeatureTypes.UnderwaterAwashRock {
                                surroundingDepth = 0,
                                valueOfSounding = 0,
                                waterLevelEffect = waterLevelEffect.CoversAndUncovers

                            };
                            if (DBNull.Value != current["WATLEV"] && current["WATLEV"] is not null) {
                                uwtroc.waterLevelEffect = Convert.ToInt32(current["WATLEV"]) switch {
                                    1 => waterLevelEffect.PartlySubmergedAtHighWater,  // partly submerged at high water
                                    2 => waterLevelEffect.AlwaysDry,  // always dry
                                    3 => waterLevelEffect.AlwaysUnderWaterSubmerged,  // always under water/submerged
                                    4 => waterLevelEffect.CoversAndUncovers,  // covers and uncovers
                                    5 => waterLevelEffect.Awash,  // awash
                                    6 => waterLevelEffect.SubjectToInundationOrFlooding,  // subject to inundation or flooding
                                    7 => waterLevelEffect.Floating,  // floating
                                    -32767 => (waterLevelEffect)(-32767),
                                    // TODO: QUESTION: how to handle -32767 on a required attribute without an S-101 equivalent "unknown". Illegal value assigned. MUST be fixed.
                                    _ => throw new IndexOutOfRangeException(),
                                };
                            }


                            if (DBNull.Value != current["PLTS_COMP_SCALE"] && current["PLTS_COMP_SCALE"] is not null) {
                                uwtroc.scaleMinimum = Convert.ToInt32(current["PLTS_COMP_SCALE"]);
                            }

                            AddFeatureName(uwtroc.featureName, current);
                            AddInformation(uwtroc.information, current);

                            buffer["ps"] = ps;
                            buffer["code"] = nameof(S100Framework.DomainModel.S101.FeatureTypes.UnderwaterAwashRock);
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(uwtroc);
                            buffer["shape"] = current.GetShape();
                            insert.Insert(buffer);
                        }
                        break;

                    case 40: { // WATTUR

                        }
                        break;

                    case 45: { // WRECKS
                            waterLevelEffect waterLeveleffectCurrent = default;

                            var wreck = new S100Framework.DomainModel.S101.FeatureTypes.Wreck {
                                surroundingDepth = valsou,
                                waterLevelEffect = waterLeveleffectCurrent

                            };

                            if (DBNull.Value != current["WATLEV"] && current["WATLEV"] is not null) {
                                wreck.waterLevelEffect = Convert.ToInt32(current["WATLEV"]) switch {
                                    1 => waterLevelEffect.PartlySubmergedAtHighWater,  // partly submerged at high water
                                    2 => waterLevelEffect.AlwaysDry,  // always dry
                                    3 => waterLevelEffect.AlwaysUnderWaterSubmerged,  // always under water/submerged
                                    4 => waterLevelEffect.CoversAndUncovers,  // covers and uncovers
                                    5 => waterLevelEffect.Awash,  // awash
                                    6 => waterLevelEffect.SubjectToInundationOrFlooding,  // subject to inundation or flooding
                                    7 => waterLevelEffect.Floating,  // floating
                                    -32767 => (waterLevelEffect)(-32767),
                                    // TODO: QUESTION: how to handle -32767 on a required attribute without an S-101 equivalent "unknown". Illegal value assigned. MUST be fixed.
                                    _ => throw new IndexOutOfRangeException(),
                                };
                            }


                            if (DBNull.Value != current["PLTS_COMP_SCALE"] && current["PLTS_COMP_SCALE"] is not null) {
                                wreck.scaleMinimum = Convert.ToInt32(current["PLTS_COMP_SCALE"]);
                            }

                            AddFeatureName(wreck.featureName, current);
                            AddInformation(wreck.information, current);

                            buffer["ps"] = ps;
                            buffer["code"] = nameof(S100Framework.DomainModel.S101.FeatureTypes.Wreck);
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(wreck);
                            buffer["shape"] = current.GetShape();
                            insert.Insert(buffer);
                        }

                        break;
                }



            }
        }

    }
}
