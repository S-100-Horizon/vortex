using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S101.InformationTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_SoundingsP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "SoundingsP";

            using var s = source.OpenDataset<FeatureClass>(source.GetName("SoundingsP"));
            using var pointset = target.OpenDataset<FeatureClass>(target.GetName("pointset"));
            using var informationtype = target.OpenDataset<Table>(target.GetName("informationType"));

            using var bufferPointset = pointset.CreateRowBuffer();
            using var insertPointset = pointset.CreateInsertCursor();

            using var cursor = s.Search(filter, true);

            var convertedCount = 0;
            var recordCount = 0;


            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;
                var current = new SoundingsP(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var subtype = current.FCSUBTYPE ?? default;
                var depth = current.DEPTH ?? default;
                var quasou = current.QUASOU ?? default;
                var quapos = current.P_QUAPOS ?? default;
                var tecsou = current.TECSOU ?? default;
                var objnam = current.OBJNAM ?? default;
                var nobjnm = current.NOBJNM ?? default;



                switch (subtype) {
                    case 1:
                        var shape = current.SHAPE as MapPoint;
                        if (shape == default) {
                            Logger.Current.DataError(objectid, tableName, longname, Strings.ERR_NULL_SHAPE);
                            continue;
                        }

                        var mappoint = MapPointBuilderEx.CreateMapPoint(shape.X, shape.Y, Convert.ToDouble(depth), shape.SpatialReference);
                        bufferPointset["shape"] = MultipointBuilderEx.CreateMultipoint(mappoint);

                        if (quasou == default || !string.Equals(quasou, "5", StringComparison.InvariantCultureIgnoreCase)) {
                            var sounding = new Sounding {
                            };
                            if (quasou != default) {
                                sounding.qualityOfVerticalMeasurement = new List<qualityOfVerticalMeasurement> {
                                            (qualityOfVerticalMeasurement)Enum.Parse(typeof(qualityOfVerticalMeasurement), quasou)
                                        };
                            }
                            if (tecsou != default && !string.IsNullOrEmpty(tecsou)) {
                                sounding.techniqueOfVerticalMeasurement = new List<techniqueOfVerticalMeasurement> {
                                            (techniqueOfVerticalMeasurement)Enum.Parse(typeof(techniqueOfVerticalMeasurement), tecsou)
                                        };
                            }
                            //if (objnam != default) {

                            //    if (!string.IsNullOrEmpty(objnam.Trim())) {
                            //        sounding.featureName.Add(new featureName {
                            //            language = "eng",
                            //            nameUsage = null,
                            //            name = objnam.Trim(),
                            //        });
                            //    }
                            //}
                            //if (nobjnm != default) {

                            //    if (!string.IsNullOrEmpty(nobjnm.Trim())) {
                            //        sounding.featureName.Add(new featureName {
                            //            language = "dk",
                            //            nameUsage = nameUsage.AlternateNameDisplay,
                            //            name = nobjnm.Trim(),
                            //        });
                            //    }
                            //}

                            AddFeatureName(sounding.featureName, feature);
                            AddInformation(sounding.information, feature);

                            bufferPointset["json"] = System.Text.Json.JsonSerializer.Serialize(sounding);
                            bufferPointset["ps"] = ps101;
                            bufferPointset["code"] = sounding.GetType().Name;

                            var oid = insertPointset.Insert(bufferPointset);
                            Logger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(sounding));
                            convertedCount++;

                            if (quapos != default && quapos == 4) {
                                /*  SOUNDG with attribute QUAPOS = 4 (approximate) will also be converted to an instance of the S101 Information type Spatial Quality (see S-101 DCEG clause 24.5), attribute quality of horizontal
                                    measurement = 4 (approximate), associated to the geometry of the Sounding feature using the
                                    association Spatial Association. */
                                using var information = informationtype.CreateRowBuffer();


                                var row = new SpatialQuality {
                                    qualityOfHorizontalMeasurement = qualityOfHorizontalMeasurement.Approximate,
                                };

                                information["ps"] = ps101;
                                information["code"] = row.GetType().Name;
                                information["json"] = System.Text.Json.JsonSerializer.Serialize(row);
                                using var _ = informationtype.CreateRow(information);
                            }
                        }
                        else {
                            /*  SOUNDG with attribute QUASOU = 5 (no bottom found at value shown) will be converted to an
                                instance of the S-101 Feature type Depth – No Bottom Found. Where this is the case, the attributes
                                EXPSOU, NOBJNM, OBJNAM, SOUACC and STATUS will not be converted. It is considered that
                                these attributes are not relevant for Depth – No Bottom Found in S-101. */
                            var instance = new DepthNoBottomFound {

                            };

                            bufferPointset["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            var oid = insertPointset.Insert(bufferPointset);
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
