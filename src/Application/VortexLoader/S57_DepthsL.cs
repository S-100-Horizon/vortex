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
using static ArcGIS.Core.Data.NetworkDiagrams.AngleDirectedDiagramLayoutParameters;
using System.Numerics;
using S100Framework.DomainModel.S101.InformationTypes;
using S100Framework.DomainModel.S131.ComplexAttributes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        /*
         *  curve
         *  point
         *  pointset
         *  curve
         *  
         */


        private static void S57_DepthsL(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "DepthsL";

            var ps = "S-101";

            var aidstonavigation = source.OpenDataset<FeatureClass>("DepthsL");
            var plts_spatialattributel = source.OpenDataset<FeatureClass>("PLTS_SpatialAttributeL");
            
            using var featureClass = target.OpenDataset<FeatureClass>("curve");
            using var informationtype = target.OpenDataset<Table>("informationtype");

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = aidstonavigation.Search(filter, true);
            int recordCount = 0;
            int convertedCount = 0;
            
            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new DepthsL(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var drval1 = current.DRVAL1 ?? default;
                var drval2 = current.DRVAL2 ?? default;
                var quasou = current.QUASOU ?? default;
                var scamin_step = current.SCAMIN_STEP ?? default;
                var sordata = current.SORDAT ?? default;
                var sorind = current.SORIND ?? default;
                var souacc = current.SOUACC ?? default;

                switch (subtype) {
                    case 5: { // DEPCNT_DepthContour
                            var instance = new DepthContour() {
                                valueOfDepthContour = drval1
                            };

                            if (plts_comp_scale != default) {
                                instance.scaleMinimum = plts_comp_scale;
                            }

                            /*
                               QUAPOS = 1 (surveyed) -> will not be converted
                               QUAPOS = 2 (unsurveyed) -> will not be converted
                               QUAPOS = 3 (inadequately surveyed) -> quality of horizontal measurement = 4 (approximate)
                               QUAPOS = 4 (approximate) -> quality of horizontal measurement = 4 (approximate)
                               QUAPOS = 5 (position doubtful) -> quality of horizontal measurement = 5 (position doubtful)
                               QUAPOS = 6 (unreliable) -> quality of horizontal measurement = 4 (approximate)
                               QUAPOS = 7 (reported (not surveyed)) -> quality of horizontal measurement = 4 (approximate)
                               QUAPOS = 8 (reported (not confirmed)) -> quality of horizontal measurement = 4 (approximate)
                               QUAPOS = 9 (estimated) -> quality of horizontal measurement = 4 (approximate)
                               QUAPOS = 10 (precisely known) -> will not be converted
                               QUAPOS = 11 (calculated) -> quality of horizontal measurement = 4 (approximate)

                            */

                            if (current.SHAPE != null) {
                                foreach (var spatialAttributeL in SelectIn<PLTS_SpatialAttributeL>(current.SHAPE, plts_spatialattributel)) {
                                    var p_quapos = spatialAttributeL.P_QUAPOS ?? default;
                                    if (p_quapos != default && p_quapos == 4) {
                                        var spatialQuality = new SpatialQuality() {
                                            qualityOfHorizontalMeasurement = qualityOfHorizontalMeasurement.Approximate,
                                            //spatialAccuracy = new List<DomainModel.S101.ComplexAttributes.spatialAccuracy>() {
                                            //new DomainModel.S101.ComplexAttributes.spatialAccuracy() {
                                            //    horizontalPositionUncertainty = default,
                                            //    fixedDateRange = default,
                                            //    verticalUncertainty = new DomainModel.S101.ComplexAttributes.verticalUncertainty() {
                                            //        uncertaintyFixed = default,
                                            //        uncertaintyVariableFactor = default
                                            //    }
                                            //}
                                        //}
                                        };

                                        using var information = informationtype.CreateRowBuffer();
                                        information["ps"] = ps;
                                        information["code"] = nameof(spatialQuality);
                                        information["json"] = System.Text.Json.JsonSerializer.Serialize(spatialQuality);
                                        //information["shape"] = spatialAttributeL.SHAPE;

                                        using var _ = informationtype.CreateRow(information);

                                    }
                                }
                            }
                            
                            AddInformation(instance.information, feature);
                            buffer["ps"] = ps;
                            buffer["code"] = nameof(instance);
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
