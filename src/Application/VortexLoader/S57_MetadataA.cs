using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {

        private static void S57_MetadataA(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "MetadataA";

            var coastlinea = source.OpenDataset<FeatureClass>(source.GetName(tableName));

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("surface"));

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = coastlinea.Search(filter, true);
            int recordCount = 0;
            int convertedCount = 0;
            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;

                var current = new MetaDataA(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;

                var displayScale = DisplayScale.GetNearestBelowKey(plts_comp_scale) ?? default;


                switch (subtype) {

                    case 1: { // M_ACCY_AccuracyOfData
                            //var instance = new QualityOfBathymetricData();

                            //AddInformation(instance.information, feature);
                            //buffer["ps"] = ps101;
                            //buffer["code"] = instance.GetType().Name;
                            //buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            //buffer["shape"] = current.SHAPE;
                            //insert.Insert(buffer);
                            //Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            //convertedCount++;
                        }
                        break;

                    case 20: { // M_CSCL_CompilationScaleOfData
                            var instance = new DataCoverage();

                            instance.maximumDisplayScale = displayScale.MaximumDisplayScale;
                            instance.minimumDisplayScale = displayScale.MinimumDisplayScale.Value;
                            instance.optimumDisplayScale = displayScale.OptimumDisplayScale;

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

                    case 25: { // M_HOPA_HorizontalDatumShiftParameters
                            //There is no equivalent Meta Feature type in S - 101 for the S-57 Meta Object M_HOPA.It is considered
                            //that this information is not required for S - 101.Data Producers should consider removing instances of
                            //M_HOPA from their S-57 data for consistency.

                            Logger.Current.DataObject(objectid, tableName, longname, "Not converted");
                            convertedCount++;
                        }
                        break;
                    case 30: { // M_NPUB_NauticalPublicationInformation
                            var instance = new InformationArea();
                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
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
                    case 35: { // M_NSYS_NavigationalSystemOfMarks // Navigational System of Marks - region A and B globally
                            var instance = new NavigationalSystemOfMarks();

                            if (current.MARSYS.HasValue) {
                                var marsys = Convert.ToInt32(current.MARSYS);
                                if (marsys != default) {
                                    instance.marksNavigationalSystemOf = marsys switch {
                                        1 => DomainModel.S101.marksNavigationalSystemOf.IalaA,
                                        2 => DomainModel.S101.marksNavigationalSystemOf.IalaB,
                                        -32767 => (DomainModel.S101.marksNavigationalSystemOf)(-1),
                                        _ => throw new IndexOutOfRangeException(),
                                    };
                                }
                            }

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
                    case 40: { // M_QUAL_QualityOfData

                            //var instance = new SpatialQuality();
                            //buffer["ps"] = ps101;
                            //buffer["code"] = instance.GetType().Name;
                            //buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            //buffer["shape"] = current.SHAPE;
                            //insert.Insert(buffer);
                            //Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            //convertedCount++;
                        }
                        break;
                    case 45: { // M_SDAT_SoundingDatum
                            var instance = new SoundingDatum();
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
                    case 50: { // M_SREL_SurveyReliability
                            var instance = new QualityOfSurvey();

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
                    case 55: { // M_VDAT_VerticalDatumOfData
                            var instance = new VerticalDatumOfData();

                            if (current.VERDAT.HasValue) {
                                var verdat = Convert.ToInt32(current.VERDAT);
                                if (verdat != default) {
                                    instance.verticalDatum = verdat switch {
                                        1 => verticalDatum.MeanLowWaterSprings,
                                        2 => verticalDatum.MeanLowerLowWaterSprings,
                                        3 => verticalDatum.MeanSeaLevel,
                                        4 => verticalDatum.LowestLowWater,
                                        5 => verticalDatum.MeanLowWater,
                                        6 => verticalDatum.LowestLowWaterSprings,
                                        7 => verticalDatum.ApproximateMeanLowWaterSprings,
                                        8 => verticalDatum.IndianSpringLowWater,
                                        9 => verticalDatum.LowWaterSprings,
                                        10 => verticalDatum.ApproximateLowestAstronomicalTide,
                                        11 => verticalDatum.NearlyLowestLowWater,
                                        12 => verticalDatum.MeanLowerLowWater,
                                        13 => verticalDatum.LowWater,
                                        14 => verticalDatum.ApproximateMeanLowWater,
                                        15 => verticalDatum.ApproximateMeanLowerLowWater,
                                        16 => verticalDatum.MeanHighWater,
                                        17 => verticalDatum.MeanHighWaterSprings,
                                        18 => verticalDatum.HighWater,
                                        19 => verticalDatum.ApproximateMeanSeaLevel,
                                        20 => verticalDatum.HighWaterSprings,
                                        21 => verticalDatum.MeanHigherHighWater,
                                        22 => verticalDatum.EquinoctialSpringLowWater,
                                        23 => verticalDatum.LowestAstronomicalTide,
                                        24 => verticalDatum.LocalDatum,
                                        25 => verticalDatum.InternationalGreatLakesDatum1985,
                                        26 => verticalDatum.MeanWaterLevel,
                                        27 => verticalDatum.LowerLowWaterLargeTide,
                                        28 => verticalDatum.HigherHighWaterLargeTide,
                                        29 => verticalDatum.NearlyHighestHighWater,
                                        30 => verticalDatum.HighestAstronomicalTide,
                                        44 => verticalDatum.BalticSeaChartDatum2000,
                                        -1 => verticalDatum.Unknown,
                                        _ => throw new ArgumentOutOfRangeException(nameof(verdat), "Invalid value for vertical datum.")
                                    };

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
                            }
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
