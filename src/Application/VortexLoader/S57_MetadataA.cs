using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {

        private static void S57_MetadataA(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "MetadataA";

            using var coastlinea = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            var subtypes = coastlinea.GetSubtypes();
            var featureType = PrimitiveType.Area;

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("surface"));

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = coastlinea.Search(filter, true);
            int recordCount = 0;
            
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
                            //buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            //SetShape(buffer,current.SHAPE);
                            //                            var featureN = featureClass.CreateRow(buffer);
                            //var name = Convert.ToString(featureN["name"]);

                            //// TODO: Create relations
                            
                            //ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            //Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            //
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
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relations
                            
                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;

                    case 25: { // M_HOPA_HorizontalDatumShiftParameters
                            //There is no equivalent Meta Feature type in S - 101 for the S-57 Meta Object M_HOPA.It is considered
                            //that this information is not required for S - 101.Data Producers should consider removing instances of
                            //M_HOPA from their S-57 data for consistency.
                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, "DEPRECATED");
                            Logger.Current.DataObject(objectid, tableName, longname, "Not converted");
                            
                        }
                        break;
                    case 30: { // M_NPUB_NauticalPublicationInformation
                            var instance = new InformationArea();
                            if (current.PLTS_COMP_SCALE.HasValue) {
                                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtypes[subtype], featureType, current.PLTS_COMP_SCALE.Value);
                            }


                            instance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                                                        var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relations
                            
                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;
                    case 35: { // M_NSYS_NavigationalSystemOfMarks // Navigational System of Marks - region A and B globally
                            var instance = new NavigationalSystemOfMarks();

                            if (current.MARSYS.HasValue) {
                                instance.marksNavigationalSystemOf = EnumHelper.GetEnumValue<marksNavigationalSystemOf>(current.MARSYS.Value);
                            }

                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                                                        var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relations
                            
                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;
                    case 40: { // M_QUAL_QualityOfData // SKIN OF EARTH

                            var instance = new QualityOfBathymetricData();
                            // TODO: categoryOfTemporalVariation

                            /*
                                Temporal Variation: The S-101 mandatory attribute category of temporal variation introduces the
                                ability for the Data Producer to incorporate the temporal impact on bathymetric data quality in areas
                                where the seabed is likely to change over time, or in the wake of an extreme event such as a hurricane
                                S-57 ENC to S-101 Conversion Guidance 9
                                S-65 Annex B April 2024 Edition 1.2.0
                                or tsunami. During the automated conversion process, for all M_QUAL except those where CATZOC =
                                6 (zone of confidence U (data not assessed)), the corresponding Quality of Bathymetric Data will
                                have category of temporal variation populated with value 5 (unlikely to change). For full S-101
                                functionality, Data Producers will be required to reassess the value of this attribute as required. For
                                CATZOC = 6 (zone of confidence U (data not assessed)), category of temporal variation will be
                                populated with value 6 (unassessed).
                            */

                            if (current.CATZOC.HasValue && current.CATZOC.Value != -32767) {
                                if (current.CATZOC.Value == 6) {
                                    instance.categoryOfTemporalVariation = categoryOfTemporalVariation.Unassessed;
                                    instance.dataAssessment = dataAssessment.Unassessed;
                                } else {
                                    instance.categoryOfTemporalVariation = categoryOfTemporalVariation.UnlikelyToChange;
                                    instance.dataAssessment = dataAssessment.Unassessed;
                                }
                            }

                            if (DateHelper.TryGetSurveyDateRange(current.SURSTA, current.SUREND, out var dateRange)) {
                                instance.surveyDateRange = dateRange;
                            }

                            if (current.CATZOC.HasValue && current.CATZOC.Value != -32767) {
                                instance.zoneOfConfidence = new() { 
                                    new zoneOfConfidence() {
                                        categoryOfZoneOfConfidenceInData = EnumHelper.GetEnumValue<categoryOfZoneOfConfidenceInData>(current.CATZOC.Value)
                                    }
                                };
                            }

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);

                            var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);


                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;
                    case 45: { // M_SDAT_SoundingDatum
                            var instance = new SoundingDatum();



                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                                                        var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relations
                            
                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
                        }
                        break;
                    case 50: { // M_SREL_SurveyReliability
                            var instance = new QualityOfSurvey();

                            AddInformation(instance.information, feature);

                            buffer["ps"] = ps101;
                            buffer["code"] = instance.GetType().Name;
                            buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                            SetShape(buffer,current.SHAPE);
                                                        var featureN = featureClass.CreateRow(buffer);
                            var name = Convert.ToString(featureN["name"]);

                            // TODO: Create relations
                            
                            ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                            
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
                                    buffer["json"] = System.Text.Json.JsonSerializer.Serialize(instance, jsonSerializerOptions);
                                    SetShape(buffer,current.SHAPE);
                                    
                                    var featureN = featureClass.CreateRow(buffer);
                                    var name = Convert.ToString(featureN["name"]);

                                    // TODO: Create relations
                            
                                    ConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID,name);

                                    Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));
                                    
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
            Logger.Current.DataTotalCount(tableName, recordCount, ConversionAnalytics.Instance.GetConvertedCount(tableName));
        }


    }
}
