using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using CommandLine;
using NetTopologySuite.Utilities;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S101.InformationTypes;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using VortexLoader;
using static S100Framework.Applications.VortexLoader;
using IO = System.IO;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {

        internal static readonly JsonSerializerOptions jsonSerializerOptions = new() {
            WriteIndented = false,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNameCaseInsensitive = true,
        };

        //  https://github.com/iho-ohi/S-57-to-S-101-conversion-sub-WG
        internal static string _notesPath = "";
        internal static int _compilationScale = -1;
        internal static string _scaminFilesPath = "";
        internal static string ps101 = "S-101";
        internal static string ps128 = "S-128";
        internal static Geodatabase _geodatabase;

        //internal static FeatureRelations featureRelations = null;
        internal static RelatedEquipment? relatedEquipment;

        internal static ConverterRegistry _converterRegistry = new ConverterRegistry();

        public static bool Load(Geodatabase destination, ParserResult<Options> arguments) {

            Logger.Current.Information("Starting");
            Func<Geodatabase> createGeodatabase = () => { throw new NotImplementedException(); };

            // default value - overwritten by args
            var filter = new QueryFilter {
                WhereClause = "PLTS_COMP_SCALE = 22000",
            };

            // default value - overwritten by args
            var skinOfEarthOnly = false;

            arguments.WithParsed<Options>(o => {
                var source = o.Source!;

                if (IO.File.Exists(source) && ".sde".Equals(IO.Path.GetExtension(source), StringComparison.OrdinalIgnoreCase)) {
                    createGeodatabase = () => { return new Geodatabase(new DatabaseConnectionFile(new Uri(IO.Path.GetFullPath(source)))); };
                }
                else if (IO.Directory.Exists(source) && ".gdb".Equals(IO.Path.GetExtension(source), StringComparison.OrdinalIgnoreCase)) {
                    createGeodatabase = () => { return new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(source)))); };
                }
                else
                    throw new System.ArgumentOutOfRangeException(nameof(source));

                if (!string.IsNullOrEmpty(o.Query)) {
                    filter.WhereClause = o.Query!.Trim();

                    string pattern = @"PLTS_COMP_SCALE\s*=\s*(\d+)";

                    Match match = Regex.Match((string)o.Query, pattern, RegexOptions.IgnoreCase);

                    if (match.Success) {
                        string value = match.Groups[1].Value;
                        if (!int.TryParse(value, out _compilationScale)) {
                            throw new NotSupportedException("PLTS_COMP_SCALE must be part of whereclause! Fix your arguments.");
                        }
                    }
                    else {
                        throw new NotSupportedException("PLTS_COMP_SCALE must be part of whereclause! Fix your arguments.");
                    }
                }
                else {
                    _compilationScale = 22000;
                    filter.WhereClause = "PLTS_COMP_SCALE = 22000";
                }

                if (!string.IsNullOrEmpty(o.NotesPath)) {
                    _notesPath = o.NotesPath;
                }
                if (!string.IsNullOrEmpty(o.SkinOfEarthOnly)) {
                    skinOfEarthOnly = bool.Parse(o.SkinOfEarthOnly);
                }
                if (!string.IsNullOrEmpty(o.ScaminFilesPath)) {
                    _scaminFilesPath = o.ScaminFilesPath;
                }
            });

            Func<Action, bool> Store = (a) => {
                a.Invoke();
                return true;
            };

            if (destination.IsTraditionallyVersioned()) {
                Store = (a) => {
                    destination.ApplyEdits(() => {
                        a.Invoke();
                    }, true);
                    return true;
                };
            }

            _converterRegistry.Register<AidsToNavigationP, CardinalBeacon>(Converters.CreateCardinalBeacon);
            _converterRegistry.Register<AidsToNavigationP, RadarTransponderBeacon>(Converters.CreateRadarTransponderBeacon);
            _converterRegistry.Register<AidsToNavigationP, LightAllAround>(Converters.CreateLightAllAround);
            _converterRegistry.Register<CulturalFeaturesP, LightSectored>(Converters.CreateLightSectored);
            _converterRegistry.Register<AidsToNavigationP, LightSectored>(Converters.CreateLightSectored);
            _converterRegistry.Register<AidsToNavigationP, LightAirObstruction>(Converters.CreateLightAirObstruction);
            _converterRegistry.Register<AidsToNavigationP, LightFogDetector>(Converters.CreateLightFogDetector);
            _converterRegistry.Register<AidsToNavigationP, Daymark>(Converters.CreateDaymark);
            _converterRegistry.Register<DangersP, Obstruction>(Converters.CreateObstruction);
            _converterRegistry.Register<CulturalFeaturesA, LightSectored>(Converters.CreateLightSectored);
            _converterRegistry.Register<PortsAndServicesP, LightSectored>(Converters.CreateLightSectored);
            _converterRegistry.Register<PortsAndServicesP, SignalStationWarning>(Converters.CreateSignalStationWarning);
            _converterRegistry.Register<AidsToNavigationP, FogSignal>(Converters.CreateFogSignal);
            _converterRegistry.Register<AidsToNavigationP, RadarStation>(Converters.CreateRadarStation);
            _converterRegistry.Register<CulturalFeaturesP, WindTurbine>(Converters.CreateWindturbine);
            _converterRegistry.Register<PortsAndServicesP, SignalStationTraffic>(Converters.CreateSignalStationTraffic);
            _converterRegistry.Register<AidsToNavigationP, RadioStation>(Converters.CreateRadioStation);
            _converterRegistry.Register<AidsToNavigationP, Retroreflector>(Converters.CreateRetroreflector);

            using (Geodatabase source = createGeodatabase()) {

                Store(() => {
                    var query = new QueryFilter {
                        WhereClause = $"1=1",
                    };
                    using var point = destination.OpenDataset<FeatureClass>(destination.GetName("point"));
                    using var pointset = destination.OpenDataset<FeatureClass>(destination.GetName("pointset"));
                    using var curve = destination.OpenDataset<FeatureClass>(destination.GetName("curve"));
                    using var surface = destination.OpenDataset<FeatureClass>(destination.GetName("surface"));

                    //using var associationBinding = destination.OpenDataset<Table>(destination.GetName("associationbinding"));
                    //using var attributeBinding = destination.OpenDataset<Table>(destination.GetName("attributebinding"));
                    using var featureAssociation = destination.OpenDataset<Table>(destination.GetName("featureassociation"));
                    using var informationAssociation = destination.OpenDataset<Table>(destination.GetName("InformationAssociation"));
                    using var informationtype = destination.OpenDataset<Table>(destination.GetName("InformationType"));

                    Logger.Current.Information($"Deleting data from destination: {point.GetName()}");
                    point.DeleteRows(query);
                    Logger.Current.Information($"Deleting data from destination: {pointset.GetName()}");
                    pointset.DeleteRows(query);
                    Logger.Current.Information($"Deleting data from destination: {curve.GetName()}");
                    curve.DeleteRows(query);
                    Logger.Current.Information($"Deleting data from destination: {surface.GetName()}");
                    surface.DeleteRows(query);
                    //Logger.Current.Information($"Deleting data from destination: {associationBinding.GetName()}");
                    //associationBinding.DeleteRows(query);
                    //Logger.Current.Information($"Deleting data from destination: {attributeBinding.GetName()}");
                    //attributeBinding.DeleteRows(query);
                    Logger.Current.Information($"Deleting data from destination: {featureAssociation.GetName()}");
                    featureAssociation.DeleteRows(query);
                    Logger.Current.Information($"Deleting data from destination: {informationAssociation.GetName()}");
                    informationAssociation.DeleteRows(query);
                    Logger.Current.Information($"Deleting data from destination: {informationtype.GetName()}");
                    informationtype.DeleteRows(query);
                });

                Logger.Current.Information($"Loading subtypes codes to subtype name");
                Subtypes.Initialize(source);

                Logger.Current.Information($"Loading featurerelations");
                FeatureRelations.Initialize(source, destination);

                Logger.Current.Information($"Initializing SpatialRelationResolver");
                SpatialRelationResolver.Initialize(source);

                Logger.Current.Information($"Initializing SpatialAssociations");
                SpatialAssociations.Initialize(source);

                relatedEquipment = new RelatedEquipment(source, destination);

                if (skinOfEarthOnly) {
                    Logger.Current.Information($"Converting skin of earth only Filter: {filter.WhereClause}");
                    // All "SKIN OF EARTH" cases / subtypes are marked with a "skin of earth" comment
                    var whereClause = filter.WhereClause.Clone();
                    filter.WhereClause = $"{whereClause} and fcsubtype in (1,5,15)";
                    Store(() => S57_DepthsA(source, destination, filter));
                    filter.WhereClause = $"{whereClause} and fcsubtype in (5)";
                    Store(() => S57_NaturalFeaturesA(source, destination, filter));
                    filter.WhereClause = $"{whereClause} and fcsubtype in (40,60,80)";
                    Store(() => S57_PortsAndServicesA(source, destination, filter));
                    filter.WhereClause = $"{whereClause} and fcsubtype in (40)";
                    Store(() => S57_MetadataA(source, destination, filter));
                    filter.WhereClause = $"{whereClause} and fcsubtype in (1)";
                    Store(() => S57_ProductCoverage(source, destination, filter));
                    //Store(() => FeatureRelations.Instance.CreateRelations(destination));

                }
                else {
                    /*var whereClause = filter.WhereClause.Clone();
                    filter.WhereClause = $"{whereClause} and globalid = '{{CA71EEFC-AF9F-4DB0-A55E-FD9D394FF58D}}'";
                    filter.WhereClause = $"{whereClause}";
                    */
                    Logger.Current.Information($"Converting all tables: {filter.WhereClause}");

                    //filter.WhereClause = "globalid = '{D7DE9631-CF20-4143-B3F4-47BB4A2AE541}'";
                    //filter.WhereClause = "globalid = '{855B900E-760C-4D68-AE02-8F3CA6FE60DD}'";
                    //filter.WhereClause = "globalid = '{BAFFC1F3-A89C-4E13-982F-B577E50A06DC}'";

                    //filter.WhereClause = "globalid = '{1F1D8B58-4959-4202-80F5-6CA4DD47D209}'";

                    Logger.Current.Information($"Converting Sounding Datums");
                    Store(() => S57_CulturalFeaturesA(source, destination, filter));

                    Store(() => S101_SoundingDatum(source, destination, filter));


                    //Store(() => S57_CulturalFeaturesA(source, destination, filter));

                    Logger.Current.Information($"Converting PortsAndServices");
                    Store(() => S57_PortsAndServicesA(source, destination, filter));
                    Store(() => S57_PortsAndServicesL(source, destination, filter));
                    Store(() => S57_PortsAndServicesP(source, destination, filter));

                    //Store(() => S101_RecommendedTracksAndRoutes(source, destination, filter));


                    Logger.Current.Information($"Converting Soundings");
                    Store(() => S57_SoundingsP(source, destination, filter));

                    Logger.Current.Information($"Converting Contours");
                    Store(() => S57_DepthsL(source, destination, filter));

                    Logger.Current.Information($"Converting Tides And Variations");
                    Store(() => S57_TidesAndVariationsA(source, destination, filter));
                    Store(() => S57_TidesAndVariationsL(source, destination, filter));
                    Store(() => S57_TidesAndVariationsP(source, destination, filter));

                    Logger.Current.Information($"Converting Seabeds");
                    Store(() => S57_SeabedA(source, destination, filter));
                    Store(() => S57_SeabedL(source, destination, filter));
                    Store(() => S57_SeabedP(source, destination, filter));

                    Logger.Current.Information($"Converting Cultural Features");
                    Store(() => S57_CulturalFeaturesL(source, destination, filter));
                    //Store(() => S57_CulturalFeaturesA(source, destination, filter));
                    Store(() => S57_CulturalFeaturesP(source, destination, filter));

                    Logger.Current.Information($"Converting CoastLines");
                    Store(() => S57_CoastlineA(source, destination, filter));
                    Store(() => S57_CoastlineL(source, destination, filter));
                    Store(() => S57_CoastlineP(source, destination, filter));

                    Logger.Current.Information($"Converting Dangers");
                    Store(() => S57_DangersA(source, destination, filter));
                    Store(() => S57_DangersL(source, destination, filter));
                    Store(() => S57_DangersP(source, destination, filter));

                    Logger.Current.Information($"Converting Depth Areas");
                    Store(() => S57_DepthsA(source, destination, filter));

                    Logger.Current.Information($"Converting Ice features");
                    Store(() => S57_IcefeaturesA(source, destination, filter));

                    Logger.Current.Information($"Converting Metadata");
                    Store(() => S57_MetadataA(source, destination, filter));

                    Logger.Current.Information($"Converting Military Features");
                    Store(() => S57_MilitaryFeatureA(source, destination, filter));
                    Store(() => S57_MilitaryFeaturesP(source, destination, filter));

                    Logger.Current.Information($"Converting Natural Features");
                    Store(() => S57_NaturalFeaturesA(source, destination, filter));
                    Store(() => S57_NaturalFeaturesL(source, destination, filter));
                    Store(() => S57_NaturalFeaturesP(source, destination, filter));

                    Logger.Current.Information($"Converting Offshore Installations");
                    Store(() => S57_OffshoreInstallationsA(source, destination, filter));
                    Store(() => S57_OffshoreInstallationsL(source, destination, filter));
                    Store(() => S57_OffshoreInstallationsP(source, destination, filter));

                    Logger.Current.Information($"Converting Product Coverages");
                    Store(() => S57_ProductCoverage(source, destination, filter));

                    Logger.Current.Information($"Converting Areas And Limits");
                    Store(() => S57_RegulatedAreasAndLimitsA(source, destination, filter));
                    Store(() => S57_RegulatedAreasAndLimitsL(source, destination, filter));
                    Store(() => S57_RegulatedAreasAndLimitsP(source, destination, filter));

                    Logger.Current.Information($"Converting Tracks And Routes");
                    Store(() => S57_TracksAndRoutesA(source, destination, filter));
                    Store(() => S57_TracksAndRoutesL(source, destination, filter));
                    Store(() => S57_TracksAndRoutesP(source, destination, filter));

                    Logger.Current.Information($"Converting Aids to Navigation");
                    Store(() => S57_AidsToNavigationP(source, destination, filter));

                    //Store(() => FeatureRelations.Instance.CreateRelations(destination));
                }


                Logger.Current.Information($"Loading sanity checker");
                SanityChecker.Initialize(destination);

                string status = null;

                status = SanityChecker.Instance.Check_GetUsageBandErrorCount() == 0 ? "PASSED" : "FAILED";
                Logger.Current.Information($"No Empty drawing index in S-101: {status}");

                status = SanityChecker.Instance.Check_GetEsriUnknown32767ErrorCount() == 0 ? "PASSED" : "FAILED";
                Logger.Current.Information($"No ESRI unknown values (-31767) in S-101: {status}");

                Logger.Current.Information("Done");
                return true;
            }
        }

        internal static string GetNation(string nation) {
            return nation switch {
                "DK" => "DK",
                _ => throw new NotSupportedException($"Nation {nation} cannot be converted")
            };
        }

        internal static void SetShape(RowBuffer buffer, Geometry? shape) {
            if (shape == null) {
                throw new ArgumentException("Null geometry not supported");
            }

            if (shape.GeometryType == GeometryType.Point && shape.HasZ == false) {
                buffer["shape"] = MapPointBuilderEx.CreateMapPoint(((MapPoint)shape).X, ((MapPoint)shape).Y, 0.00, shape.SpatialReference);
            }
            else {
                buffer["shape"] = shape;
            }
        }
        internal static void SetUsageBand(RowBuffer buffer, int comp_scale) {
            _ = comp_scale switch {
                -1 => throw new InvalidOperationException("compilation scale isn't initialized!"),
                < 22000 => buffer["usageband"] = 5,
                < 90000 => buffer["usageband"] = 4,
                < 180000 => buffer["usageband"] = 3,
                < 700000 => buffer["usageband"] = 2,
                _ => buffer["usageband"] = 1
            };


            //_ = shape.GeometryType switch {
            //    GeometryType.Unknown => throw new NotSupportedException("Geometry type: unknown "),
            //    GeometryType.Point => null,
            //    GeometryType.Envelope => throw new NotSupportedException("Geometry type: envelope"),
            //    GeometryType.Multipoint => null,
            //    GeometryType.Polyline => buffer["usageband"] = 4,
            //    GeometryType.Polygon => buffer["usageband"] = 4,
            //    GeometryType.Multipatch => throw new NotSupportedException("Geometry type: multipatch"),
            //    GeometryType.GeometryBag => throw new NotSupportedException("Geometry type: geometrybag"),
            //    _ => throw new NotSupportedException($"Unhandled geometry type {shape.GeometryType}")
            //};
        }

        /// <summary>
        /// DCEG p460
        /// </summary>
        /// <param _s101name="current"></param>
        /// <returns></returns>
        internal static rhythmOfLight GetRythmOfLight(AidsToNavigationP current) {

            /*
                When populating rhythm of light, the
                sub-attributes signal group, signal period and signal sequence are only valid for non-fixed lights
                (that is, sub-attribute light characteristic ≠ 1 (fixed)), with signal group and signal period being
                mandatory
            */

            //current.SIGGRP != default ? new List<string> { current.SIGGRP } : new();
            List<string> parenthesisParts = new List<string>();

            if (!String.IsNullOrEmpty(current.SIGGRP)) {
                string pattern = @"\([^()]*\)";
                if (!Regex.Match(current.SIGGRP, pattern).Success) {
                    Logger.Current.DataError(current.OBJECTID ?? -1, current.TableName!, current.LNAM!, $"Cannot parse SIGGRP string: {current.SIGGRP} on {current.GlobalId}");
                    ;
                }
                foreach (Match m in Regex.Matches(current.SIGGRP, pattern)) {
                    parenthesisParts.Add(m.Value);
                }
            }
            var signalPeriodN = current.SIGPER == -32767 ? null : current.SIGPER;

            var sigseq = current.SIGSEQ;

            lightCharacteristic lightCharacteristicsValue = default;

            if (current.LITCHR.HasValue) {
                lightCharacteristicsValue = EnumHelper.GetEnumValue<lightCharacteristic>(current.LITCHR.Value);
            }

            var signalSequences = GetSignalSequences(current.SIGSEQ);

            var rhythmOfLight = new rhythmOfLight() {
                lightCharacteristic = lightCharacteristicsValue,
                signalGroup = parenthesisParts,
                signalPeriod = signalPeriodN,
                signalSequence = signalSequences
            };
            return rhythmOfLight;
        }

        internal static verticalDatum GetVerticalDatum(int value) {
            /*
            if (current.VERDAT.HasValue) {
                instance.verticalDatum = EnumHelper.GetEnumValue<verticalDatum>(current.VERDAT.Value);
            }
            */
            if (value != 3) {
                return EnumHelper.GetEnumValue<verticalDatum>(value);
            }

            return verticalDatum.BalticSeaChartDatum2000;
        }


        internal static List<signalSequence> GetSignalSequences(string? sigseq) {
            var signalSequences = new List<signalSequence>();

            string pattern = @"(\d+\.\d+)|\((\d+\.\d+)\)";

            if (sigseq != default) {

                Regex regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(sigseq);

                foreach (Match match in matches) {
                    if (!string.IsNullOrEmpty(match.Groups[1].Value)) {
                        var duration = decimal.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
                        // Interval of light
                        signalSequences.Add(new signalSequence() {
                            signalDuration = duration,
                            signalStatus = signalStatus.LitSound
                        });
                    }
                    else if (!string.IsNullOrEmpty(match.Groups[2].Value)) {
                        decimal duration = decimal.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);
                        // Eclipse
                        signalSequences.Add(new signalSequence() {
                            signalDuration = duration,
                            signalStatus = signalStatus.EclipsedSilent
                        });
                    }
                }
            }
            return signalSequences;
        }

        internal static List<colour> GetColours(string color) {
            if (color == "-32767") {
                return new List<colour>() { (colour)(-1) };
            }
            return EnumHelper.GetEnumValues<colour>(color);


            //List<colour> colours = new List<colour>();
            //if (color != default) {
            //    if (!string.IsNullOrEmpty(color)) {
            //        foreach (var c in color.Split(',', StringSplitOptions.RemoveEmptyEntries)) {
            //            colour? e = c.ToLowerInvariant() switch {
            //                "1" => colour.White,
            //                "2" => colour.Black,
            //                "3" => colour.Red,
            //                "4" => colour.Green,
            //                "5" => colour.Blue,
            //                "6" => colour.Yellow,
            //                "7" => colour.Grey,
            //                "8" => colour.Brown,
            //                "9" => colour.Amber,
            //                "10" => colour.Violet,
            //                "11" => colour.Orange,
            //                "12" => colour.Magenta,
            //                "13" => colour.Pink,
            //                "-32767" =>(colour)(-1),
            //                _ => throw new IndexOutOfRangeException(),
            //            };
            //            if (e.HasValue) {
            //                colours.Add(e.Value);
            //            }
            //        }
            //    }
            //}
            //return colours;
        }

        //private static buoyShape GetBuoyShape(int? buoyShapeValue) {
        //    return buoyShapeValue.Value switch {
        //        1 => buoyShape.Conical,
        //        2 => buoyShape.Can,
        //        3 => buoyShape.Spherical,
        //        4 => buoyShape.Pillar,
        //        5 => buoyShape.Spar,
        //        6 => buoyShape.Barrel,
        //        7 => buoyShape.Superbuoy,
        //        8 => buoyShape.IceBuoy,
        //        -32767 => (buoyShape)(-1),
        //        _ => throw new IndexOutOfRangeException("Invalid buoy shape value."),
        //    };
        //}

        internal static colourPattern GetColourPattern(string colorPattern) {
            var colourPat = colorPattern switch {
                "1" => colourPattern.HorizontalStripes,
                "2" => colourPattern.VerticalStripes,
                "3" => colourPattern.DiagonalStripes,
                "4" => colourPattern.Squared,
                "5" => colourPattern.StripesDirectionUnknown,
                "6" => colourPattern.BorderStripe,
                "-32767" => (colourPattern)(-1),
                _ => throw new IndexOutOfRangeException($"Colourpattern value is not legal {colorPattern}")
            };
            return colourPat;
        }

        private static status GetSingleStatus(string status) {
            return GetStatus(status)[0];


        }

        internal static List<status> GetStatus(string statuses) {
            List<status> statusList = new List<status>();

            var featureStatus = statuses.Trim();

            /*
             * code	status
            alias	STATUS
            _s101name	Status
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
                    status? e = c.ToLowerInvariant() switch {
                        "1" => status.Permanent,
                        "2" => status.Occasional,
                        "3" => status.Recommended,
                        "4" => status.NotInUse,
                        "5" => status.PeriodicIntermittent,
                        "6" => status.Reserved,
                        "7" => status.Temporary,
                        "8" => status.Private,
                        "9" => status.Mandatory,
                        "11" => status.Extinguished,
                        "12" => status.Illuminated,
                        "13" => status.Historic,
                        "14" => status.Public,
                        "15" => status.Synchronized,
                        "16" => status.Watched,
                        "17" => status.Unwatched,
                        "18" => status.ExistenceDoubtful,
                        //"28" => ??, // TODO: what to do? STATUS 28
                        "-32767" => (status)(-1),
                        _ => throw new IndexOutOfRangeException(),
                    };
                    if (e.HasValue) {
                        statusList.Add(e.Value);
                    }
                }

            }
            return statusList;
        }



        /*
                code	condition
                alias	CONDTN
                _s101name	Condition
                definition	The various conditions of buildings and other constructions.
                valueType	enumeration
                listedValues	
                Under Construction	    1	IHOREG	Being built but not yet capable of function.
                Ruined	                2	IHOREG	A structure in a decayed or deteriorated condition resulting from neglect or disuse, or a damaged structure in need of repair.
                Under Reclamation	    3	IHOREG	An area of the sea, a lake or the navigable part of a river that is being reclaimed as land, usually by the dumping of earth and other material.
                Wingless	            4	IHOREG	A windmill or wind turbine from which the vanes or turbine blades are missing.
                Planned Construction	5	IHOREG	Detailed planning has been completed but construction has not been initiated.

         */

        //public static colour GetColour(string value) {
        //    return conditionValue switch {
        //        1 => condition.UnderConstruction,      // under construction
        //        2 => condition.Ruined,                 // ruined
        //        3 => condition.UnderReclamation,       // under reclamation
        //        5 => condition.PlannedConstruction,    // planned construction
        //        -32767 => (condition)(-1),                        // unknown or no condition
        //        _ => throw new IndexOutOfRangeException("Invalid condition value.")  // Invalid condition value
        //    };
        //}



        public static condition GetCondition(int conditionValue) {
            return conditionValue switch {
                1 => condition.UnderConstruction,      // under construction
                2 => condition.Ruined,                 // ruined
                3 => condition.UnderReclamation,       // under reclamation
                5 => condition.PlannedConstruction,    // planned construction
                -32767 => (condition)(-1),                        // unknown or no condition
                _ => throw new IndexOutOfRangeException("Invalid condition value.")  // Invalid condition value
            };
        }


        internal static List<featureName> GetFeatureName(string? objname, string? nobjnme) {
            List<featureName> featureName = new List<featureName>();
            if (objname != default) {
                var objnam = objname.Trim();
                if (!string.IsNullOrEmpty(objnam)) {
                    featureName.Add(new featureName {
                        language = "eng",
                        nameUsage = nameUsage.DefaultNameDisplay,
                        name = objnam,
                    });
                }
            }
            if (nobjnme != default) {
                var nobjnm = nobjnme.Trim();
                if (!string.IsNullOrEmpty(nobjnm)) {
                    featureName.Add(new featureName {
                        language = "dan",
                        nameUsage = nameUsage.AlternateNameDisplay,
                        name = nobjnm,
                    });
                }
            }

            return featureName;
        }

        internal static List<information> CreateInformationFrom(Feature current) {
            List<information> information = new List<information>();

            if (DBNull.Value != current["NTXTDS"]) {
                var ntxtds = Convert.ToString(current["NTXTDS"])?.Trim();

                if (!string.IsNullOrEmpty(ntxtds) && ntxtds.EndsWith(".txt", StringComparison.InvariantCultureIgnoreCase)) {
                    var filePath = System.IO.Path.Combine(_notesPath, ntxtds);
                    if (File.Exists(filePath)) {
                        var note = new Note(filePath);
                        string? fileLocator = default;
                        string fileReference = ntxtds;
                        string language = "eng";

                        var instance = new information {
                            fileLocator = fileLocator,
                            fileReference = FixFilename(fileReference) ?? default,
                            language = language,
                        };
                        information.Add(instance);
                    }
                    else {
                        Logger.Current.DataError(current.GetObjectID(), current.GetTable().GetName(), "", $"AddInformation: Cannot find note {filePath}");
                    }

                }
                else if (!string.IsNullOrEmpty(ntxtds)) {
                    string language = "eng";

                    var instance = new information {
                        language = language,
                        text = ntxtds,
                    };
                    information.Add(instance);
                }
            }

            if (DBNull.Value != current["TXTDSC"]) {
                var txtdsc = Convert.ToString(current["TXTDSC"])?.Trim();
                if (!string.IsNullOrEmpty(txtdsc) && txtdsc.EndsWith(".txt", StringComparison.InvariantCultureIgnoreCase)) {
                    var filePath = System.IO.Path.Combine(_notesPath, txtdsc);
                    if (File.Exists(filePath)) {
                        var note = new Note(filePath);
                        string? fileLocator = default;
                        string fileReference = txtdsc;
                        string language = "eng";

                        var instance = new information {
                            fileLocator = fileLocator,
                            fileReference = FixFilename(fileReference) ?? default,
                            language = language,
                        };
                        information.Add(instance);

                    }
                    else {
                        Logger.Current.DataError(current.GetObjectID(), current.GetTable().GetName(), "", $"AddInformation: Cannot find note {filePath}");
                    }
                }
                else if (!string.IsNullOrEmpty(txtdsc)) {
                    string? fileLocator = default;
                    string fileReference = txtdsc;
                    string language = "eng";

                    var instance = new information {
                        fileLocator = fileLocator,
                        language = language,
                        text = txtdsc,
                    };
                    information.Add(instance);
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
                        string language = "eng";

                        if (!string.IsNullOrEmpty(value) && value.EndsWith(".txt", StringComparison.InvariantCultureIgnoreCase)) {
                            var filePath = System.IO.Path.Combine(_notesPath, value);
                            if (File.Exists(value)) {
                                var instance = new information {
                                    fileLocator = fileLocator,
                                    fileReference = FixFilename(value) ?? default,
                                    headline = default,
                                    language = language,
                                    text = value,
                                };
                                information.Add(instance);
                            }
                            else {
                                Logger.Current.DataError(current.GetObjectID(), current.GetTable().GetName(), "", $"AddInformation: Cannot find note {value}");
                            }
                        }
                        else if (!string.IsNullOrEmpty(value)) {
                            var instance = new information {
                                fileLocator = fileLocator,
                                language = language,
                                text = value,
                            };
                            information.Add(instance);
                        }
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
                        string language = "dan";

                        if (!string.IsNullOrEmpty(value) && value.EndsWith(".txt", StringComparison.InvariantCultureIgnoreCase)) {
                            var filePath = System.IO.Path.Combine(_notesPath, value);
                            if (File.Exists(value)) {
                                var instance = new information {
                                    fileLocator = fileLocator,
                                    fileReference = FixFilename(value) ?? default,
                                    headline = default,
                                    language = language,
                                    text = value,
                                };
                                information.Add(instance);
                            }
                            else {
                                Logger.Current.DataError(current.GetObjectID(), current.GetTable().GetName(), "", $"AddInformation: Cannot find note {value}");
                            }
                        }
                        else if (!string.IsNullOrEmpty(value)) {
                            var instance = new information {
                                fileLocator = fileLocator,
                                language = language,
                                text = value,
                            };
                            information.Add(instance);
                        }
                    }
                }
            }
            return information;
        }

        internal static List<string> GetCommunicationChannel(string input) {
            var result = new List<string>();
            if (string.IsNullOrWhiteSpace(input)) return result;

            var tokens = input.Split(';');
            foreach (var token in tokens) {
                var trimmed = token.Trim();
                if (!trimmed.StartsWith("[") || !trimmed.EndsWith("]")) {
                    result.Add(trimmed); // Unrecognized format, keep as is
                    continue;
                }

                var content = trimmed.Substring(1, trimmed.Length - 2);

                if (Regex.IsMatch(content, @"[A-Za-z]")) {
                    var match = Regex.Match(content, @"^([A-Za-z]+)(\d+)$");
                    if (match.Success) {
                        var prefix = match.Groups[1].Value;
                        var number = int.Parse(match.Groups[2].Value).ToString("D4");
                        result.Add($"[{prefix}{number}]");
                    }
                    else {
                        result.Add(trimmed);
                    }
                }
                else {
                    if (int.TryParse(content, out int number)) {
                        var formatted = $"[VHF{number:D4}]";
                        result.Add(formatted);
                    }
                    else {
                        result.Add(trimmed);
                    }
                }
            }

            return result;
        }

        private static string? FixFilename(string fileReference) {
            if (fileReference == default) {
                return default;
            }

            string result = Regex.Replace(fileReference, @"^dk", match => {
                string matched = match.Value;

                string replacement = "101";

                replacement += char.IsUpper(matched[0]) ? 'D' : 'd';
                replacement += char.IsUpper(matched[1]) ? 'K' : 'k';
                replacement += "00";

                return replacement;
            }, RegexOptions.IgnoreCase);

            return result;
        }

        internal static NauticalInformation CreateNauticalInformation(string picrep, string datsta, string datend, string persta, string perend, List<information> information) {
            NauticalInformation nobj = new NauticalInformation();
            if (picrep != default) {
                nobj.pictorialRepresentation = picrep;
            }

            nobj.information = information;
            nobj.Code = ps101;

            DateHelper.TryGetFixedDateRange(datsta, datend, out var dateRange);
            if (dateRange != default) {
                nobj.fixedDateRange = dateRange;
            }

            DateHelper.TryGetPeriodicDateRange(persta, perend, out var periodicDateRange);
            if (periodicDateRange != default) {
                nobj.periodicDateRange = periodicDateRange;
            }

            return nobj;
        }

        internal static void AddInformation(List<information> instanceInformation, Feature current) {
            // TODO: Still missing decision on how GST wants handling of both files and a copy of the file content.
            // Sent to Nigel & Co.
            List<information> information = CreateInformationFrom(current);
            instanceInformation.AddRange(information);
        }
    }
}

