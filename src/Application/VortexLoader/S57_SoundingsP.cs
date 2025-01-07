using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_SoundingsP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            Console.WriteLine("SoundingsP");

            using var s = source.OpenDataset<FeatureClass>("SoundingsP");
            using var pointset = target.OpenDataset<FeatureClass>("pointset");
            using var informationtype = target.OpenDataset<Table>("informationtype");

            using var bufferPointset = pointset.CreateRowBuffer();
            using var insertPointset = pointset.CreateInsertCursor();

            using var cursor = s.Search(filter, true);
            while (cursor.MoveNext()) {
                var current = (Feature)cursor.Current;
                var subtype = Convert.ToInt32(current["FCSubtype"]);

                switch (subtype) {
                    case 1:
                        var depth = Convert.ToDouble(current["DEPTH"]);
                        int? quasou = DBNull.Value == current["QUASOU"] || string.IsNullOrEmpty(Convert.ToString(current["QUASOU"])) ? null : Convert.ToInt32(current["QUASOU"]);
                        int? quapos = DBNull.Value == current["P_QUAPOS"] || string.IsNullOrEmpty(Convert.ToString(current["P_QUAPOS"])) ? null : Convert.ToInt32(current["P_QUAPOS"]);

                        bufferPointset["ps"] = "S-101";
                        bufferPointset["code"] = "Sounding";

                        var shape = (MapPoint)current.GetShape();
                        var mappoint = MapPointBuilderEx.CreateMapPoint(shape.X, shape.Y, depth, shape.SpatialReference);
                        bufferPointset["shape"] = MultipointBuilderEx.CreateMultipoint(mappoint);

                        if (!quasou.HasValue || quasou != 5) {
                            var sounding = new S100Framework.DomainModel.S101.FeatureTypes.Sounding {
                            };
                            if (quasou.HasValue) {
                                sounding.qualityOfVerticalMeasurement = new List<S100Framework.DomainModel.S101.qualityOfVerticalMeasurement> {
                                            (S100Framework.DomainModel.S101.qualityOfVerticalMeasurement)quasou
                                        };
                            }
                            if (DBNull.Value != current["TECSOU"] && !string.IsNullOrEmpty(Convert.ToString(current["TECSOU"]))) {
                                sounding.techniqueOfVerticalMeasurement = new List<S100Framework.DomainModel.S101.techniqueOfVerticalMeasurement> {
                                            (S100Framework.DomainModel.S101.techniqueOfVerticalMeasurement)Convert.ToInt32(current["TECSOU"])
                                        };
                            }
                            if (DBNull.Value != current["OBJNAM"]) {
                                var objnam = Convert.ToString(current["OBJNAM"])?.Trim();
                                if (!string.IsNullOrEmpty(objnam)) {
                                    sounding.featureName.Add(new DomainModel.S101.ComplexAttributes.featureName {
                                        language = "eng",
                                        nameUsage = null,
                                        name = objnam,
                                    });
                                }
                            }
                            if (DBNull.Value != current["NOBJNM"]) {
                                var nobjnm = Convert.ToString(current["NOBJNM"])?.Trim();
                                if (!string.IsNullOrEmpty(nobjnm)) {
                                    sounding.featureName.Add(new DomainModel.S101.ComplexAttributes.featureName {
                                        language = "dk",
                                        nameUsage = DomainModel.S101.nameUsage.AlternateNameDisplay,
                                        name = nobjnm,
                                    });
                                }
                            }

                            AddFeatureName(sounding.featureName, current);
                            AddInformation(sounding.information, current);

                            bufferPointset["json"] = System.Text.Json.JsonSerializer.Serialize(sounding);
                            var oid = insertPointset.Insert(bufferPointset);

                            if (quapos.HasValue && quapos == 4) {
                                /*  SOUNDG with attribute QUAPOS = 4 (approximate) will also be converted to an instance of the S101 Information type Spatial Quality (see S-101 DCEG clause 24.5), attribute quality of horizontal
                                    measurement = 4 (approximate), associated to the geometry of the Sounding feature using the
                                    association Spatial Association. */
                                using var information = informationtype.CreateRowBuffer();

                                information["ps"] = "S-101";
                                information["code"] = "SpatialQuality";

                                var row = new S100Framework.DomainModel.S101.InformationTypes.SpatialQuality {
                                    qualityOfHorizontalMeasurement = DomainModel.S101.qualityOfHorizontalMeasurement.Approximate,
                                };
                                information["json"] = System.Text.Json.JsonSerializer.Serialize(row);
                                using var _ = informationtype.CreateRow(information);
                            }
                        }
                        else {
                            /*  SOUNDG with attribute QUASOU = 5 (no bottom found at value shown) will be converted to an
                                instance of the S-101 Feature type Depth – No Bottom Found. Where this is the case, the attributes
                                EXPSOU, NOBJNM, OBJNAM, SOUACC and STATUS will not be converted. It is considered that
                                these attributes are not relevant for Depth – No Bottom Found in S-101. */
                            var instance = new S100Framework.DomainModel.S101.FeatureTypes.DepthNoBottomFound {
                            };

                            bufferPointset["json"] = System.Text.Json.JsonSerializer.Serialize(instance);
                            var oid = insertPointset.Insert(bufferPointset);
                        }
                        break;
                }
            }
        }
    }
}
