using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using System;
using System.Reflection.Metadata.Ecma335;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_DangersP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "DangersP";

            var dangersp = source.OpenDataset<FeatureClass>(source.GetName("DangersP"));

            //var dredged = source.OpenDataset<FeatureClass>("Depare");

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("point"));
            

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = dangersp.Search(filter, true);
            int recordCount = 0;
            int convertedCount = 0;
            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new DangersP(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;
                var catObs = current.CATOBS ?? -32767;
                var valsou = current.VALSOU ?? default;
                var watlev = current.WATLEV ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;

                bool isValsouEmpty = !current.VALSOU.HasValue;

                // The attribute default clearance depth must be populated with a value, which must not be an empty(null)
                // value, only if the attribute value of sounding for the feature instance is populated with an empty(null) value
                // and the attribute height, if an allowable attribute for the feature, is not populated.
                // S-101 Annex A_DCEG Edition 1.5.0_Draft for Edition 2.0.0.pdf: p.771
                //Decimal defaultClearanceDepth = -32767;

                switch (subtype) {
                    case 1: { // CTNARE
                            var instance = new CautionArea {

                            };
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }



                            AddStatus(instance.status, feature);
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

                    case 10: { // FSHFAC Fishing facilities
                            var instance = new FishingFacility {

                            };
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

                    case 20: { // OBSTRN
                            if (catObs == default) {
                                Logger.Current.DataError(objectid, tableName, longname, $"Unknown catobs: {catObs}");
                                continue;
                            }



                            // Foul ground
                            if (catObs == 7) {
                                var foulGround = new FoulGround();

                                //foulGround.verticalUncertainty = 
                                AddStatus(foulGround.status, feature);
                                AddFeatureName(foulGround.featureName, feature);
                                AddInformation(foulGround.information, feature);
                                buffer["ps"] = ps101;

                                buffer["code"] = foulGround.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(foulGround);
                                buffer["shape"] = feature.GetShape();
                                insert.Insert(buffer);
                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(foulGround));
                                convertedCount++;
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

                            var obstruction = new Obstruction {
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

                            AddStatus(obstruction.status, feature);
                            AddFeatureName(obstruction.featureName, feature);
                            AddInformation(obstruction.information, feature);

                            buffer["ps"] = ps101;

                            buffer["code"] = obstruction.GetType().Name; 
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(obstruction);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(obstruction));
                            convertedCount++;
                        }
                        break;
                        
                    case 35: { // UWTROC
                            // TODO: surrounding depth, valueofsounding
                            var uwtroc = new UnderwaterAwashRock {
                                surroundingDepth = 0,
                                valueOfSounding = 0,
                                waterLevelEffect = waterLevelEffect.CoversAndUncovers
                            };

                            //      S57
                            //    Code Description
                            // 1   partly submerged at high water
                            // 2   always dry
                            // 3   always under water / submerged
                            // 4   covers and uncovers
                            // 5   awash
                            // 6   subject to inundation or flooding
                            // 7   floating
                            // -32767  Unknown


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
                            AddStatus(uwtroc.status, feature);
                            AddFeatureName(uwtroc.featureName, feature);
                            AddInformation(uwtroc.information, feature);

                            buffer["ps"] = ps101;

                            buffer["code"] = uwtroc.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(uwtroc);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(uwtroc));
                            convertedCount++;

                        }
                        break;

                    case 40: { // WATTUR
                            // TODO: no instances in NIS
                            // TODO: surrounding depth, valueofsounding
                            var instance = new WaterTurbulence {

                            };
                            if (current.WATLEV.HasValue) {
                                instance.categoryOfWaterTurbulence = current.WATLEV.Value switch {
                                    1 => categoryOfWaterTurbulence.Breakers,
                                    2 => categoryOfWaterTurbulence.Eddies,
                                    3 => categoryOfWaterTurbulence.Overfalls,
                                    4 => categoryOfWaterTurbulence.TideRips,
                                    5 => categoryOfWaterTurbulence.Bombora,
                                    - 32767 => (categoryOfWaterTurbulence)(-32767),
                                    // TODO: QUESTION: how to handle -32767 on a required attribute without an S-101 equivalent "unknown". Illegal value assigned. MUST be fixed.
                                    _ => throw new IndexOutOfRangeException(),
                                };
                            }

                            if (current.PLTS_COMP_SCALE.HasValue) {
                                instance.scaleMinimum = current.PLTS_COMP_SCALE;
                            }

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
                    case 45: { // WRECKS
                            waterLevelEffect waterLeveleffectCurrent = default;

                            var instance = new Wreck {
                                surroundingDepth = valsou,
                                waterLevelEffect = waterLeveleffectCurrent

                            };

                            if (current.CATWRK.HasValue) {
                                instance.categoryOfWreck = current.CATWRK switch {
                                    1 => categoryOfWreck.NonDangerousWreck,
                                    2 => categoryOfWreck.DangerousWreck,
                                    3 => categoryOfWreck.DistributedRemainsOfWreck,
                                    4 => categoryOfWreck.WreckShowingMastMasts,
                                    5 => categoryOfWreck.WreckShowingAnyPortionOfHullOrSuperstructure,
                                    - 32767 => (categoryOfWreck)(-32767),
                                    // TODO: QUESTION: how to handle -32767 on a required attribute without an S-101 equivalent "unknown". Illegal value assigned. MUST be fixed.
                                    _ => throw new IndexOutOfRangeException(),
                                };
                            }


                            if (current.WATLEV.HasValue) {
                                instance.waterLevelEffect = current.WATLEV switch {
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
                                instance.scaleMinimum = current.PLTS_COMP_SCALE.Value;
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
