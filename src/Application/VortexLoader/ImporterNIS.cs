using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using CommandLine;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using VortexLoader.S57.esri;
using static S100Framework.Applications.VortexLoader;
using IO = System.IO;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        //  https://github.com/iho-ohi/S-57-to-S-101-conversion-sub-WG

        static string _notesPath = "";

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

                if (!string.IsNullOrEmpty(o.NotesPath)) {
                    _notesPath = o.NotesPath;
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

            //  AidsToNavigation
            S57_AidsToNavigationP(source, destination, filter);

            //  PortsAndServicesP
            S57_PortsAndServicesP(source, destination, filter);

            //  DangersA
            S57_DangersA(source, destination, filter);

            //  DangersP
            S57_DangersP(source, destination, filter);

            //  DangersL
            S57_DangersL(source, destination, filter);


            // RegulatedAreasAndLimitsL
            S57_RegulatedAreasAndLimitsL(source, destination, filter);

            // OffshoreInstallationsL
            S57_OffshoreInstallationsL(source, destination, filter);
            
            // RegulatedAreasAndLimitsA
            S57_RegulatedAreasAndLimitsA(source, destination, filter);

            //  ProductCoverage
            S57_ProductCoverage(source, destination, filter);

            //  NaturalFeaturesL
            S57_NaturalFeaturesL(source, destination, filter);

            // DepthsL
            S57_DepthsL(source, destination, filter);

            //  DepthsA
            S57_DepthsA(source, destination, filter);

            //  NaturalFeaturesA
            S57_NaturalFeaturesA(source, destination, filter);

            //  SoundingsP
            S57_SoundingsP(source, destination, filter);



            return true;
        }





        public static IEnumerable<T> SelectIn<T>(Geometry geometry, FeatureClass in_featureclass) where T : class {

            SpatialQueryFilter spatialQueryFilter = new SpatialQueryFilter {
                FilterGeometry = geometry,
                SpatialRelationship = SpatialRelationship.Contains,
            };

            using (RowCursor spatialSearch = in_featureclass.Search(spatialQueryFilter, true)) {
                var shape = spatialSearch.FindField("SHAPE");
                while (spatialSearch.MoveNext()) {
                    using (Row row = spatialSearch.Current) {
                        Feature feature = (Feature)row;
                        if (feature != null) {
                            var val = Activator.CreateInstance(typeof(T), feature) as T;
                            if (val != null) {
                                yield return val;
                            }
                        }
                    }
                }
            }

        }

        private static void AddColour(List<colour> colours, Feature feature) {
            var color = Convert.ToString(feature["COLOUR"])?.Trim();

            if (color != default) {
                if (!string.IsNullOrEmpty(color)) {
                    foreach (var c in color.Split(',', StringSplitOptions.RemoveEmptyEntries)) {
                        colour? e = c.ToLowerInvariant() switch {
                            "1" => colour.White,
                            "2" => colour.Black,
                            "3" => colour.Red,
                            "4" => colour.Green,
                            "5" => colour.Blue,
                            "6" => colour.Yellow,
                            "7" => colour.Grey,
                            "8" => colour.Brown,
                            "9" => colour.Grey,
                            "10" => colour.Violet,
                            "11" => colour.Orange,
                            "12" => colour.Magenta,
                            "13" => colour.Pink,
                            "-32767" => (colour)(-32767),
                            _ => throw new IndexOutOfRangeException(),
                        };
                        if (e.HasValue) {
                            colours.Add(e.Value);
                        }
                    }
                }
            }
        }



        private static void AddStatus(status? status, Feature current) {
            if (DBNull.Value != current["STATUS"]) {
                var featureStatus = Convert.ToString(current["OBJNAM"])?.Trim();
                if (!string.IsNullOrEmpty(featureStatus)) {
                    /* See S-101 DCEG clause 5.4 for the listing of allowable values. Values populated in S-57 for this attribute
                       other than the allowable values will not be converted across to S-101. Data Producers are advised to
                       check any populated values for STATUS on LNDARE and amend appropriately. */

                    //TODO: STATUS
                }
            }
        }
        private static void AddStatus(List<status> status, Feature current) {
            if (DBNull.Value != current["STATUS"]) {
                var featureStatus = Convert.ToString(current["STATUS"])?.Trim();

                if (!string.IsNullOrEmpty(featureStatus)) {
                    /* See S-101 DCEG clause 5.4 for the listing of allowable values. Values populated in S-57 for this attribute
                       other than the allowable values will not be converted across to S-101. Data Producers are advised to
                       check any populated values for STATUS on LNDARE and amend appropriately. */

                    //TODO: STATUS
                }

            }
        }

        private static void AddFeatureName(IList<featureName> featureName, Feature current) {
            if (DBNull.Value != current["OBJNAM"]) {
                var objnam = Convert.ToString(current["OBJNAM"])?.Trim();
                if (!string.IsNullOrEmpty(objnam)) {
                    featureName.Add(new featureName {
                        language = "eng",
                        nameUsage = null,
                        name = objnam,
                    });
                }
            }
            if (DBNull.Value != current["NOBJNM"]) {
                var nobjnm = Convert.ToString(current["NOBJNM"])?.Trim();
                if (!string.IsNullOrEmpty(nobjnm)) {
                    featureName.Add(new featureName {
                        language = "dk",
                        nameUsage = nameUsage.AlternateNameDisplay,
                        name = nobjnm,
                    });
                }
            }
        }

        private static void AddInformation(IList<information> information, Feature current) {
            // TODO: Still missing decision on how GST wants handling of both files and a copy of the file content.
            // Sent to Nigel & Co.

            if (DBNull.Value != current["NTXTDS"]) {
                var ntxtds = Convert.ToString(current["NTXTDS"])?.Trim();
                if (!string.IsNullOrEmpty(ntxtds)) {
                    var filePath = System.IO.Path.Combine(_notesPath, ntxtds);
                    if (File.Exists(filePath)) {
                        var note = new Note(filePath);
                        string? fileLocator = default;
                        string fileReference = ntxtds;
                        string language = "eng";

                        var instance = new information {
                            fileLocator = fileLocator,
                            fileReference = fileReference,
                            headline = note.Header,
                            language = language,
                            text = note.Content,
                        };
                        information.Add(instance);
                    }
                }
            }

            if (DBNull.Value != current["TXTDSC"]) {
                var txtdsc = Convert.ToString(current["TXTDSC"])?.Trim();
                if (!string.IsNullOrEmpty(txtdsc)) {
                    var filePath = System.IO.Path.Combine(_notesPath, txtdsc);
                    if (File.Exists(filePath)) {
                        var note = new Note(filePath);
                        string? fileLocator = default;
                        string fileReference = txtdsc;
                        string language = "eng";

                        var instance = new information {
                            fileLocator = fileLocator,
                            fileReference = fileReference,
                            headline = note.Header,
                            language = language,
                            text = note.Content,
                        };
                        information.Add(instance);

                    }
                }
            }

            if (DBNull.Value != current["INFORM"]) {
                var inform = Convert.ToString(current["INFORM"])?.Trim();
                if (!string.IsNullOrEmpty(inform)) {


                    //https://geodatastyrelsen.atlassian.net/wiki/spaces/SOEKORT/pages/4404478463/S-65+Annex+B+Appendix+A+-+Impact+analysis
                    // Separate discrete information populated in INFORM using a standard separator such as semicolon “;”.

                    string[] informs = inform != null ? inform.Split(';') : Array.Empty<string>();


                    foreach (var value in informs) {
                        string? fileLocator = default;
                        string? fileReference = default;
                        string language = "eng";

                        var instance = new information {
                            fileLocator = fileLocator,
                            fileReference = fileReference,
                            headline = default,
                            language = language,
                            text = value,
                        };
                        information.Add(instance);
                    }
                }
            }
            if (DBNull.Value != current["NINFOM"]) {
                var ninfom = Convert.ToString(current["NINFOM"])?.Trim();

                // https://geodatastyrelsen.atlassian.net/wiki/spaces/SOEKORT/pages/4404478463/S-65+Annex+B+Appendix+A+-+Impact+analysis
                // Separate discrete information populated in INFORM using a standard separator such as semicolon “;”.
                if (!string.IsNullOrEmpty(ninfom)) {

                    string[] ninfoms = ninfom != null ? ninfom.Split(';') : Array.Empty<string>();

                    foreach (var value in ninfoms) {
                        string? fileLocator = default;
                        string? fileReference = default;
                        string language = "dan";

                        var instance = new information {
                            fileLocator = fileLocator,
                            fileReference = fileReference,
                            headline = default,
                            language = language,
                            text = value,
                        };
                        information.Add(instance);
                    }
                }
            }
        }
    }
}

