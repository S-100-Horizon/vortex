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
        static string ps101 = "S-101";
        static string ps128 = "S-128";

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
                    //WhereClause = $"ps = 'S-101'",
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

            //  MilitaryFeaturesA
            S57_MilitaryFeatureA(source, destination, filter);
            
            //  MilitaryFeaturesP
            S57_MilitaryFeaturesP(source, destination, filter);

            //  TracksAndRoutesA
            S57_TracksAndRoutesA(source, destination, filter);

            //  TracksAndRoutesL
            S57_TracksAndRoutesL(source, destination, filter);
           
            //  TracksAndRoutesP
            S57_TracksAndRoutesP(source, destination, filter);

            //  IcefeaturesA
            S57_IcefeaturesA(source, destination, filter);

            //  CoastlineA
            S57_CoastlineA(source, destination, filter);

            //  CoastlineL
            S57_CoastlineL(source, destination, filter);

            //  CoastlineP
            S57_CoastlineP(source, destination, filter);

            //  CulturalFeaturesA
            S57_CulturalFeaturesA(source, destination, filter);
            
            //  CulturalFeaturesL
            S57_CulturalFeaturesL(source, destination, filter);
            
            //  CulturalFeaturesP
            S57_CulturalFeaturesP(source, destination, filter);

            //  Seabed
            S57_SeabedP(source, destination, filter);

            //  ProductCoverage
            S57_ProductCoverage(source, destination, filter);

            //  AidsToNavigation
            S57_AidsToNavigationP(source, destination, filter);

            //  PortsAndServicesP
            S57_PortsAndServicesP(source, destination, filter);

            //  PortsAndServicesA
            S57_PortsAndServicesA(source, destination, filter);

            //  PortsAndServicesL
            S57_PortsAndServicesL(source, destination, filter);

            //  DangersA
            S57_DangersA(source, destination, filter);

            //  DangersP
            S57_DangersP(source, destination, filter);

            //  DangersL
            S57_DangersL(source, destination, filter);

            // RegulatedAreasAndLimitsL
            S57_RegulatedAreasAndLimitsL(source, destination, filter);

            // RegulatedAreasAndLimitsA
            S57_RegulatedAreasAndLimitsA(source, destination, filter);

            // RegulatedAreasAndLimitsP
            S57_RegulatedAreasAndLimitsP(source, destination, filter);

            // OffshoreInstallationsL
            S57_OffshoreInstallationsL(source, destination, filter);
            
            // OffshoreInstallationsA
            S57_OffshoreInstallationsA(source, destination, filter);
            
            // OffshoreInstallationsP
            S57_OffshoreInstallationsP(source, destination, filter);

            //  NaturalFeaturesL
            S57_NaturalFeaturesL(source, destination, filter);

            //  NaturalFeaturesA
            S57_NaturalFeaturesA(source, destination, filter);

            //  NaturalFeaturesP
            S57_NaturalFeaturesP(source, destination, filter);

            // DepthsL
            S57_DepthsL(source, destination, filter);

            //  DepthsA
            S57_DepthsA(source, destination, filter);

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

        private static void AddOrientation(orientation orient, Feature feature) {
            if (DBNull.Value != feature["ORIENT"]) {
                var orientSource = Convert.ToDecimal(feature["ORIENT"]);
                if (orient == default) {
                    orient = new orientation();
                    orient.orientationValue = orientSource;
                } else {
                    orient.orientationValue = orientSource;
                }
            }
        }

        private static void AddOrientation(decimal orientationValue, Feature feature) {
            if (DBNull.Value != feature["ORIENT"]) {
                var orient = Convert.ToDecimal(feature["ORIENT"]);
                orientationValue = orient;
            }
        }


        private static void AddStatus(status? status, Feature current) {
            if (DBNull.Value != current["STATUS"]) {
                var featureStatus = Convert.ToString(current["STATUS"])?.Trim();
                if (!string.IsNullOrEmpty(featureStatus)) {
                    /* See S-101 DCEG clause 5.4 for the listing of allowable values. Values populated in S-57 for this attribute
                       other than the allowable values will not be converted across to S-101. Data Producers are advised to
                       check any populated values for STATUS on LNDARE and amend appropriately. */

                    //TODO: STATUS
                    ;
                }
            }
        }

        private static void AddStatus(List<status> statusList, Feature current) {
            if (DBNull.Value != current["STATUS"]) {
                var featureStatus = Convert.ToString(current["STATUS"])?.Trim();

                /*
                 * code	status
                alias	STATUS
                name	Status
                definition	The condition of an object at a given instant in time.
                valueType	enumeration  listedValues	

                Permanent	            1	IHOREG	Intended to last or function indefinitely.
                Occasional	            2	IHOREG	Acting on special occasions; happening irregularly.
                Recommended	            3	IHOREG	Presented as worthy of confidence, acceptance, use, etc.
                Not in Use	            4	IHOREG	Use has ceased, but the facility still exists intact; disused.
                Periodic/Intermittent	5	IHOREG	Recurring at intervals.
                Reserved	            6	IHOREG	Set apart for some specific use.
                Temporary	            7	IHOREG	Meant to last only for a time.
                Private	                8	IHOREG	Administered by an individual or corporation, rather than a State or a public body.
                Mandatory	            9	IHOREG	Compulsory; enforced.
                Extinguished	        11	IHOREG	No longer lit.
                Illuminated	            12	IHOREG	Lit by flood lights, strip lights, etc.
                Historic	            13	IHOREG	Famous in history; of historical interest.
                Public	                14	IHOREG	Belonging to, available to, used or shared by, the community as a whole and not restricted to private use.
                Synchronized	        15	IHOREG	Occur at a time, coincide in point of time, be contemporary or simultaneous.
                Watched	                16	IHOREG	Looked at or observed over a period of time especially so as to be aware of any movement or change.
                Unwatched	            17	IHOREG	Usually automatic in operation, without any permanently-stationed personnel to superintend it.
                Existence Doubtful	    18	IHOREG	A feature that has been reported but has not been definitely determined to exist.
                Buoyed	                28	IHOREG	Marked by buoys.

                */


                if (!string.IsNullOrEmpty(featureStatus)) {
                    /* See S-101 DCEG clause 5.4 for the listing of allowable values. Values populated in S-57 for this attribute
                        other than the allowable values will not be converted across to S-101. Data Producers are advised to
                        check any populated values for STATUS on LNDARE and amend appropriately. */
                    foreach (var c in featureStatus.Split(',', StringSplitOptions.RemoveEmptyEntries)) {
                        status? e = featureStatus.ToLowerInvariant() switch {
                            "1" => status.Permanent,
                            "2" => status.Occasional,
                            "3" => status.Recommended,
                            "4" => status.NotInUse,
                            "5" => status.PeriodicIntermittent,
                            "6" => status.Reserved,
                            "7" => status.Temporary,
                            "8" => status.Private,
                            "9" => status.Mandatory,
                            "11" =>status.Extinguished,
                            "12" =>status.Illuminated,
                            "13" => status.Historic,
                            "14" => status.Public,
                            "15" => status.Synchronized,
                            "16" => status.Watched,
                            "17" => status.Unwatched,
                            "18" => status.ExistenceDoubtful,
                            //"28" => ??, // TODO: what to do? STATUS 28
                            "-32767" => (status)(-32767),
                            _ => throw new IndexOutOfRangeException(),
                        };
                        if (e.HasValue) {
                            statusList.Add(e.Value);
                        }
                    }

                }
            }
        }



        /*
                code	condition
                alias	CONDTN
                name	Condition
                definition	The various conditions of buildings and other constructions.
                valueType	enumeration
                listedValues	
                Under Construction	    1	IHOREG	Being built but not yet capable of function.
                Ruined	                2	IHOREG	A structure in a decayed or deteriorated condition resulting from neglect or disuse, or a damaged structure in need of repair.
                Under Reclamation	    3	IHOREG	An area of the sea, a lake or the navigable part of a river that is being reclaimed as land, usually by the dumping of earth and other material.
                Wingless	            4	IHOREG	A windmill or wind turbine from which the vanes or turbine blades are missing.
                Planned Construction	5	IHOREG	Detailed planning has been completed but construction has not been initiated.

         */


        private static void AddCondition(condition? cndtn, Feature feature) {




            if (DBNull.Value != feature["CONDITION"]) {
                var condtn = Convert.ToInt32(feature["CONDITION"]);
                if (condtn != default) {
                    cndtn = condtn switch {
                        1 => condition.UnderConstruction,   //  under construction
                        2 => condition.Ruined,   //  ruined
                        3 => condition.UnderReclamation,   //  under reclamation                                    
                        4 => throw new IndexOutOfRangeException(),   //  wingless
                        5 => throw new IndexOutOfRangeException(),   //  planned construction
                        -32767 => null,
                        _ => throw new IndexOutOfRangeException(),
                    };
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

