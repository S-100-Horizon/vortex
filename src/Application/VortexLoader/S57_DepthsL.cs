﻿using ArcGIS.Core.Data;
using S100Framework.DomainModel.S101;
using VortexLoader.S57.esri;
using S100Framework.DomainModel.S101.InformationTypes;
using S100Framework.DomainModel.S101.FeatureTypes;


namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        /*
         *  curve
         *  point
         *  pointset
         *  surface
         *  
         */

        private static void S57_DepthsL(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "DepthsL";

            

            var depthsl = source.OpenDataset<FeatureClass>("DepthsL");
            var plts_spatialattributel = source.OpenDataset<FeatureClass>("PLTS_SpatialAttributeL");
            using var informationtype = target.OpenDataset<Table>("informationtype");

            using var featureClass = target.OpenDataset<FeatureClass>("curve");
            

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = depthsl.Search(filter, true);
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
                var valco = current.VALDCO ?? default;
                var quasou = current.QUASOU ?? default;
                var scamin_step = current.SCAMIN_STEP ?? default;
                var sordata = current.SORDAT ?? default;
                var sorind = current.SORIND ?? default;
                var souacc = current.SOUACC ?? default;

                switch (subtype) {
                    case 5: { // DEPCNT_DepthContour
                            var instance = new DepthContour() {
                                valueOfDepthContour = valco
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
                                            //spatialAccuracy = new List<DomainModel.ComplexAttributes.spatialAccuracy>() {
                                            //new DomainModel.ComplexAttributes.spatialAccuracy() {
                                            //    horizontalPositionUncertainty = default,
                                            //    fixedDateRange = default,
                                            //    verticalUncertainty = new DomainModel.ComplexAttributes.verticalUncertainty() {
                                            //        uncertaintyFixed = default,
                                            //        uncertaintyVariableFactor = default
                                            //    }
                                            //}
                                        //}
                                        };

                                        using var information = informationtype.CreateRowBuffer();
                                        information["ps"] = ps101;
                                        information["code"] = spatialQuality.GetType().Name;
                                        information["json"] = System.Text.Json.JsonSerializer.Serialize(spatialQuality);
                                        //information["shape"] = spatialAttributeL.SHAPE;

                                        using var _ = informationtype.CreateRow(information);

                                    }
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
