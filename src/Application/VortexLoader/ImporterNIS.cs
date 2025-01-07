using ArcGIS.Core.Data;
using CommandLine;
using S100Framework.DomainModel.S101.ComplexAttributes;
using static S100Framework.Applications.VortexLoader;
using IO = System.IO;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        //  https://github.com/iho-ohi/S-57-to-S-101-conversion-sub-WG

        public static bool Load(Geodatabase destination, ParserResult<Options> arguments) {
            Func<Geodatabase> createGeodatabase = () => { throw new NotImplementedException(); };

            var filter = new QueryFilter {
                WhereClause = "1=1",
            };

            arguments.WithParsed<Options>(o => {
                var source = o.Source!;

                if (IO.File.Exists(source) && ".sde".Equals(IO.Path.GetExtension(source), StringComparison.InvariantCultureIgnoreCase)) {
                    createGeodatabase = () => { return new Geodatabase(new DatabaseConnectionFile(new Uri(IO.Path.GetFullPath(source)))); };
                }
                else if (IO.Directory.Exists(source) && ".gdb".Equals(IO.Path.GetExtension(source), StringComparison.InvariantCultureIgnoreCase)) {
                    createGeodatabase = () => { return new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(source)))); };
                }
                else
                    throw new System.ArgumentOutOfRangeException(nameof(source));

                if (!string.IsNullOrEmpty(o.Query)) {
                    filter.WhereClause = o.Query!.Trim();
                }
            });

            using Geodatabase source = createGeodatabase();
            {
                var query = new QueryFilter {
                    WhereClause = $"ps = 'S-101'",
                };

                using var point = destination.OpenDataset<FeatureClass>("point");
                using var pointset = destination.OpenDataset<FeatureClass>("pointset");
                using var curve = destination.OpenDataset<FeatureClass>("curve");
                using var surface = destination.OpenDataset<FeatureClass>("surface");
                using var informationtype = destination.OpenDataset<Table>("informationtype");

                point.DeleteRows(query);
                pointset.DeleteRows(query);
                curve.DeleteRows(query);
                surface.DeleteRows(query);
                informationtype.DeleteRows(query);
            }

            //  DepthsA
            S57_DepthsA(source, destination, filter);

            //  DepthsA
            S57_NaturalFeaturesA(source, destination, filter);

            //  SoundingsP
            S57_SoundingsP(source, destination, filter);

            //  SoundingsP
            S57_DangersP(source, destination, filter);

            //  ProductCoverage
            NIS_ProductCoverage(source, destination, filter);

            return true;
        }

        private static void AddFeatureName(IList<featureName> featureName, Feature current) {
            if (DBNull.Value != current["OBJNAM"]) {
                var objnam = Convert.ToString(current["OBJNAM"])?.Trim();
                if (!string.IsNullOrEmpty(objnam)) {
                    featureName.Add(new DomainModel.S101.ComplexAttributes.featureName {
                        language = "eng",
                        nameUsage = null,
                        name = objnam,
                    });
                }
            }
            if (DBNull.Value != current["NOBJNM"]) {
                var nobjnm = Convert.ToString(current["NOBJNM"])?.Trim();
                if (!string.IsNullOrEmpty(nobjnm)) {
                    featureName.Add(new DomainModel.S101.ComplexAttributes.featureName {
                        language = "dk",
                        nameUsage = DomainModel.S101.nameUsage.AlternateNameDisplay,
                        name = nobjnm,
                    });
                }
            }
        }

        private static void AddInformation(IList<information> information, Feature current) {
            //TODO: information
        }

        private static void NIS_ProductCoverage(Geodatabase source, Geodatabase target, QueryFilter filter) {
            Console.WriteLine("ProductCoverage");

            using var productDefinitions = source.OpenDataset<Table>("ProductDefinitions");
            using var productCoverage = source.OpenDataset<FeatureClass>("ProductCoverage");
            using var featureClass = target.OpenDataset<FeatureClass>("surface");

            featureClass.DeleteRows(new QueryFilter {
                WhereClause = $"ps = 'S-128' AND code = 'ElectronicProduct'",
            });

            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursorDefinitions = productDefinitions.Search(null, true);
            while (cursorDefinitions.MoveNext()) {
                var current = (Row)cursorDefinitions.Current;

                var dsnm = Convert.ToString(current["DSNM"])!;
                var edtn = Convert.ToInt32(current["EDTN"]);
                var updn = Convert.ToInt32(current["UPDN"]);
                var isdt = Convert.ToDateTime(current["ISDT"]);

                var electronicproduct = new S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct {
                    catalogueElementClassification = new List<S100Framework.DomainModel.S128.catalogueElementClassification> {
                                S100Framework.DomainModel.S128.catalogueElementClassification.Enc,
                            },
                    editionNumber = edtn,
                    issueDate = isdt,
                    notForNavigation = true,
                    typeOfProductFormat = S100Framework.DomainModel.S128.typeOfProductFormat.IsoIec8211,
                    datasetName = dsnm,
                };
                if (updn > 0)
                    electronicproduct.updateNumber = updn;

                using var cursorCoverage = productCoverage.Search(new QueryFilter {
                    WhereClause = $"Product_GUID = '{current.GetGlobalID():B}'",
                }, true);

                buffer["ps"] = "S-128";
                buffer["code"] = "ElectronicProduct";
                buffer["json"] = System.Text.Json.JsonSerializer.Serialize(electronicproduct);

                while (cursorCoverage.MoveNext()) {
                    var catcov = Convert.ToInt32(cursorCoverage.Current["CATCOV"]);

                    switch (catcov) {
                        case 1:
                            buffer["shape"] = ((Feature)cursorCoverage.Current).GetShape();
                            break;
                    }
                }

                insert.Insert(buffer);
            }
        }
    }
}
