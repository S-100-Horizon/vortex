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
        private static void S57_DangersP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            Logger.Current.Debug("DangersP");


            var ps = "S-101";

            var dangersp = source.OpenDataset<FeatureClass>("DangersP");

           // var dredged = source.OpenDataset<FeatureClass>("Depare");

            using var featureClass = target.OpenDataset<FeatureClass>("point");
            using var informationtype = target.OpenDataset<Table>("informationtype");

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = dangersp.Search(filter, true);
            while (cursor.MoveNext()) {
                var feature = (Feature)cursor.Current;

                var current = new DangersP(feature);

                var subtype = current.FCSUBTYPE.HasValue ? current.FCSUBTYPE.Value : default;
                var catObs = current.CATOBS.HasValue ? current.CATOBS.Value : default;
                var valsou = current.VALSOU.HasValue ? current.VALSOU.Value : default;
                var watlev = current.WATLEV.HasValue ? current.WATLEV.Value : default;
                var plts_comp_scale = current.PLTS_COMP_SCALE.HasValue ? current.PLTS_COMP_SCALE.Value : default;

                bool isValsouEmpty = !current.VALSOU.HasValue;


                // The attribute default clearance depth must be populated with a value, which must not be an empty(null)
                // value, only if the attribute value of sounding for the feature instance is populated with an empty(null) value
                // and the attribute height, if an allowable attribute for the feature, is not populated.
                // S-101 Annex A_DCEG Edition 1.5.0_Draft for Edition 2.0.0.pdf: p.771
                Decimal defaultClearanceDepth = -32767;

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
                            
                            // Foul ground
                            if (catObs == 7) {
                                var foulGround = new FoulGround();

                                //foulGround.verticalUncertainty = 


                                AddFeatureName(foulGround.featureName, feature);
                                AddInformation(foulGround.information, feature);
                                buffer["ps"] = ps;
                                buffer["code"] = nameof(S100Framework.DomainModel.S101.FeatureTypes.FoulGround); ;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(foulGround);
                                buffer["shape"] = feature.GetShape();
                                insert.Insert(buffer);
                                break;
                            }


                            //CONDTN, EXPSOU, NATCON, NATQUA, NATSUR, PRODCT, VERLEN, WATLEV

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

                            
                            obstruction.categoryOfObstruction = Convert.ToInt32(catObs) switch {
                                1 => categoryOfObstruction.SnagStump,
                                2 => categoryOfObstruction.Wellhead,
                                3 => categoryOfObstruction.Diffuser,
                                4 => categoryOfObstruction.Crib,
                                5 => categoryOfObstruction.FishHaven,
                                6 => categoryOfObstruction.FoulArea,
                                8 => categoryOfObstruction.IceBoom,
                                9 => categoryOfObstruction.GroundTackle,
                                10 => categoryOfObstruction.Boom,
                                12 => categoryOfObstruction.WaveEnergyDevice,
                                13 => categoryOfObstruction.SubsurfaceOceanDataAcquisitionSystem,
                                14 => categoryOfObstruction.ArtificialReef,
                                15 => categoryOfObstruction.Template,
                                16 => categoryOfObstruction.Manifold,
                                17 => categoryOfObstruction.SubmergedPingo,
                                18 => categoryOfObstruction.RemainsOfPlatform,
                                19 => categoryOfObstruction.ScientificInstrument,
                                20 => categoryOfObstruction.UnderwaterTurbine,
                                21 => categoryOfObstruction.ActiveSubmarineVolcano,
                                22 => categoryOfObstruction.SharkNet,
                                23 => categoryOfObstruction.Mangrove,
                                -32767 => (categoryOfObstruction)(-32767),
                                // TODO: QUESTION: how to handle -32767 on a required attribute without an S-101 equivalent "unknown". Illegal value assigned. MUST be fixed.

                                _ => throw new IndexOutOfRangeException(),
                            };
                            



                            if (isValsouEmpty) {
                                // TODO: implement
                                //var featureCursor = QueryByGeometry(current.GetShape())
                                obstruction.defaultClearanceDepth = valsou;

                            }

                            obstruction.waterLevelEffect = watlev switch {
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


                            if (current.PLTS_COMP_SCALE.HasValue)
                                obstruction.scaleMinimum = current.PLTS_COMP_SCALE;

                            AddFeatureName(obstruction.featureName, feature);
                            AddInformation(obstruction.information, feature);

                            buffer["ps"] = ps;
                            buffer["code"] = nameof(S100Framework.DomainModel.S101.FeatureTypes.Obstruction); ;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(obstruction);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                        }
                        break;
                        
                    case 35: { // UWTROC
                            var uwtroc = new S100Framework.DomainModel.S101.FeatureTypes.UnderwaterAwashRock {
                                surroundingDepth = 0,
                                valueOfSounding = 0,
                                waterLevelEffect = waterLevelEffect.CoversAndUncovers

                            };
                            if (current.WATLEV.HasValue) {
                                uwtroc.waterLevelEffect = current.WATLEV.Value switch {
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


                            if (current.PLTS_COMP_SCALE.HasValue) {
                                uwtroc.scaleMinimum = current.PLTS_COMP_SCALE;
                            }

                            AddFeatureName(uwtroc.featureName, feature);
                            AddInformation(uwtroc.information, feature);

                            buffer["ps"] = ps;
                            buffer["code"] = nameof(S100Framework.DomainModel.S101.FeatureTypes.UnderwaterAwashRock);
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(uwtroc);
                            buffer["shape"] = current.SHAPE;
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

                            if (current.WATLEV.HasValue) {
                                wreck.waterLevelEffect = current.WATLEV switch {
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


                            if (current.PLTS_COMP_SCALE.HasValue) {
                                wreck.scaleMinimum = current.PLTS_COMP_SCALE.Value;
                            }

                            AddFeatureName(wreck.featureName, feature);
                            AddInformation(wreck.information, feature);

                            buffer["ps"] = ps;
                            buffer["code"] = nameof(S100Framework.DomainModel.S101.FeatureTypes.Wreck);
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(wreck);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                        }

                        break;
                }



            }
        }

    }
}
