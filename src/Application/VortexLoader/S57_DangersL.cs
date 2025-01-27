using ArcGIS.Core.Data;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using VortexLoader.S57.esri;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_DangersL(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "DangersL";

            var ps = "S-101";

            var dangersp = source.OpenDataset<FeatureClass>("DangersL");

            //var dredged = source.OpenDataset<FeatureClass>("Depare");

            using var featureClass = target.OpenDataset<FeatureClass>("curve");
            using var informationtype = target.OpenDataset<Table>("informationtype");

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = dangersp.Search(filter, true);
            int recordCount = 0;
            int convertedCount = 0;
            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new DangersL(feature);

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
                    case 1: { // FSHFAC_FishingFacility
                            var instance = new FishingFacility {

                            };
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddCondition(instance.condition, feature);
                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);

                            buffer["ps"] = "S-101";
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;
                        }
                        break;
                    case 5: { // OBSTRN_Obstruction
                            if (catObs == default) {
                                Logger.Current.DataError(objectid, tableName, longname, $"Unknown catobs: {catObs}");
                                continue;
                            }
                            // Foul ground
                            if (catObs == 7) {
                                var instance = new FoulGround();

                                //foulGround.verticalUncertainty = 

                                AddStatus(instance.status, feature);
                                AddFeatureName(instance.featureName, feature);
                                AddInformation(instance.information, feature);
                                buffer["ps"] = ps;
                                buffer["code"] = instance.GetType().Name;
                                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                                buffer["shape"] = feature.GetShape();
                                insert.Insert(buffer);
                                Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                                convertedCount++;
                                break;
                            }

                            if (catObs != 7) {

                                //CONDTN, EXPSOU, NATCON, NATQUA, NATSUR, PRODCT, VERLEN, WATLEV

                                /*
                                    OBSTRN of geometric primitive area or line with attribute INFORM = Submerged weir will be
                                    converted to an instance of the S-101 Feature type Dam (see clause 4.8.5). Where this is the case,
                                    the attributes CATOBS, EXPSOU, NATQUA, NATSUR, PRODCT, QUASOU, SOUACC, TECSOU
                                    and VALSOU will not be converted. It is considered that these attributes are not relevant for Dam in
                                    S-101. 
                                */

                                waterLevelEffect waterLeveleffectCurrent = default;

                                var instance = new Obstruction {
                                    surroundingDepth = valsou,
                                    waterLevelEffect = waterLeveleffectCurrent
                                };

                                


                                instance.categoryOfObstruction = Convert.ToInt32(catObs) switch {
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
                                    instance.defaultClearanceDepth = valsou;

                                }

                                instance.waterLevelEffect = watlev switch {
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
                                    instance.scaleMinimum = current.PLTS_COMP_SCALE;

                                AddCondition(instance.condition, feature);
                                AddStatus(instance.status, feature);
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
                        }
                        break;
                    case 10: { // OILBAR_OilBarrier
                            var instance = new OilBarrier {

                            };
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddStatus(instance.status, feature);
                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);

                            buffer["ps"] = "S-101";
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            buffer["shape"] = current.SHAPE;
                            insert.Insert(buffer);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            convertedCount++;

                        }
                        break;
                    case 15: { // WATTUR_WaterTurbulence
                            var instance = new WaterTurbulence {

                            };
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            AddFeatureName(instance.featureName, feature);
                            AddInformation(instance.information, feature);

                            buffer["ps"] = "S-101";
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
