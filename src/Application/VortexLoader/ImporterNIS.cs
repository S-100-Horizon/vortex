using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
//using ArcGIS.Desktop.Internal.Mapping;
using CommandLine;
using S100FC.S101;
using S100FC.S101.ComplexAttributes;
using S100FC.S101.FeatureTypes;
using S100FC.S101.InformationTypes;
using S100FC.S101.SimpleAttributes;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.RegularExpressions;
using VortexLoader;
using static S100Framework.Applications.VortexLoader;
using IO = System.IO;

[assembly: InternalsVisibleTo("TestNisImporter")]
namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {

        internal static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions {
            WriteIndented = false,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNameCaseInsensitive = true,
        }.AppendTypeInfoResolver();

        //internal static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions {
        //    WriteIndented = false,
        //    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        //    PropertyNameCaseInsensitive = true,
        //    //TypeInfoResolver = Summary.InformationBindingResolver(),
        //}.AppendTypeInfoResolver();

        //internal static readonly JsonSerializerOptions jsonFeatureTypeSerializerOptions = new JsonSerializerOptions {
        //    WriteIndented = false,
        //    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        //    PropertyNameCaseInsensitive = true,
        //}.AppendTypeInfoResolver();

        //  https://github.com/iho-ohi/S-57-to-S-101-conversion-sub-WG
        internal static string _notesPath = "";
        //internal static int _compilationScale = -1;
        internal static string _scaminFilesPath = "";

        internal static string ps101 = S100FC.S101.Summary.ProductId;
        internal static string ps128 = S100FC.S128.Summary.ProductId;
        internal static string s101version = S100FC.S101.Summary.Version.ToString();
        internal static Geodatabase? _geodatabase;

        internal static bool createBridgesAndRelations = true;

        //internal static FeatureRelations featureRelations = null;
        internal static RelatedEquipment? relatedEquipment;

        internal static ConverterRegistry _converterRegistry = new ConverterRegistry();

        public static QueryFilter QueryFilter { get; internal set; } = new();

        public static IDictionary<int, int> VerticalDatumConverter = new Dictionary<int, int>();


        public static bool Load(Geodatabase destination, ParserResult<Options> arguments) {

            Logger.Current.Information("Starting");
            Func<Geodatabase> createGeodatabase = () => { throw new NotImplementedException(); };

            // default value - overwritten by args
            var s128 = false;

            // default value - overwritten by args
            var skinOfEarthOnly = false;
            var append = false;
            string status = null!;
            arguments.WithParsed<Options>(o => {
                if (!string.IsNullOrEmpty(o.VerticalDatumConverter)) {
                    VerticalDatumConverter = o.VerticalDatumConverter.Split(',').Select(e => e.Split('=')).ToDictionary(e => int.Parse(e[0]), e => int.Parse(e[1]));
                }

                var source = o.Source!;

                if (IO.File.Exists(source) && ".sde".Equals(IO.Path.GetExtension(source), StringComparison.OrdinalIgnoreCase)) {
                    createGeodatabase = () => { return new Geodatabase(new DatabaseConnectionFile(new Uri(IO.Path.GetFullPath(source)))); };
                }
                else if (IO.Directory.Exists(source) && ".gdb".Equals(IO.Path.GetExtension(source), StringComparison.OrdinalIgnoreCase)) {
                    createGeodatabase = () => { return new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(source)))); };
                }
                else if (source.StartsWith("https://")) {
                    createGeodatabase = () => { return new Geodatabase(new ServiceConnectionProperties(new Uri(source))); };
                }
                else
                    throw new System.ArgumentOutOfRangeException(nameof(source));

                if (!string.IsNullOrEmpty(o.Query)) {
                    QueryFilter.WhereClause = o.Query!.Trim();
                }
                else {
                    throw new NotSupportedException("whereclause must be supplied.");
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

                append = o.Append;

                s128 = o.S128;
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
            _converterRegistry.Register<DangersA, Obstruction>(Converters.CreateObstruction);
            _converterRegistry.Register<DangersL, Obstruction>(Converters.CreateObstruction);

            _converterRegistry.Register<AidsToNavigationP, Retroreflector>(Converters.CreateRetroreflector);
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
                //#if null
                {
                    var query = new QueryFilter {
                        WhereClause = $"1=1",
                    };
                    using var point = destination.OpenDataset<FeatureClass>(destination.GetName("point"));
                    using var pointset = destination.OpenDataset<FeatureClass>(destination.GetName("pointset"));
                    using var curve = destination.OpenDataset<FeatureClass>(destination.GetName("curve"));
                    using var surface = destination.OpenDataset<FeatureClass>(destination.GetName("surface"));
                    using var attachment = destination.OpenDataset<Table>(destination.GetName("attachment"));

                    //using var associationBinding = destination.OpenDataset<Table>(destination.GetName("associationbinding"));
                    //using var attributeBinding = destination.OpenDataset<Table>(destination.GetName("attributebinding"));                                               
                    using var informationtype = destination.OpenDataset<Table>(destination.GetName("InformationType"));
                    using var featureType = destination.OpenDataset<Table>(destination.GetName("featureType"));
                    //using var messages = destination.OpenDataset<Table>(destination.GetName("messages"));

                    if (!append) {
                        Store(() => {
                            Logger.Current.Information($"Deleting data from destination: {featureType.GetName()}");
                            DeleteAll(featureType);//featureType.DeleteRows(query);
                        });
                        Store(() => {
                            Logger.Current.Information($"Deleting data from destination: {point.GetName()}");
                            DeleteAll(point); // point.DeleteRows(query);
                        });
                        Store(() => {
                            Logger.Current.Information($"Deleting data from destination: {pointset.GetName()}");
                            DeleteAll(pointset); // pointset.DeleteRows(query);
                        });
                        Store(() => {
                            Logger.Current.Information($"Deleting data from destination: {curve.GetName()}");
                            DeleteAll(curve); // curve.DeleteRows(query);
                        });
                        Store(() => {
                            Logger.Current.Information($"Deleting data from destination: {surface.GetName()}");
                            DeleteAll(surface); // surface.DeleteRows(query);
                        });
                        Store(() => {
                            Logger.Current.Information($"Deleting data from destination: {attachment.GetName()}");
                            DeleteAll(attachment);
                        });
                        Store(() => {
                            Logger.Current.Information($"Deleting data from destination: {informationtype.GetName()}");
                            DeleteAll(informationtype);
                        });
                    }
                }

                Logger.Current.Information($"Loading subtypes codes to subtype name");
                Subtypes.Initialize(source);

                Logger.Current.Information($"Loading featurerelations");
                FeatureRelations.Initialize(source, destination);

                Logger.Current.Information($"Initializing SpatialRelationResolver");
                SpatialRelationResolver.Initialize(source);

                Logger.Current.Information($"Initializing SpatialAssociations");
                SpatialAssociations.Initialize(source, QueryFilter);

                Logger.Current.Information($"Initializing NauticalInformations");
                NauticalInformations.Initialize(destination);

                relatedEquipment = new RelatedEquipment(source, destination);

                if (skinOfEarthOnly) {
                    Logger.Current.Information($"Converting skin of earth only Filter: {QueryFilter.WhereClause}");
                    // All "SKIN OF EARTH" cases / subtypes are marked with a "skin of earth" comment
                    var whereClause = QueryFilter.WhereClause.Clone();
                    QueryFilter.WhereClause = $"{whereClause} and fcsubtype in (1,5,15)";
                    Store(() => S57_DepthsA(source, destination, QueryFilter));
                    QueryFilter.WhereClause = $"{whereClause} and fcsubtype in (5)";
                    Store(() => S57_NaturalFeaturesA(source, destination, QueryFilter));
                    QueryFilter.WhereClause = $"{whereClause} and fcsubtype in (40,60,80)";
                    Store(() => S57_PortsAndServicesA(source, destination, QueryFilter));
                    QueryFilter.WhereClause = $"{whereClause} and fcsubtype in (40)";
                    Store(() => S57_MetadataA(source, destination, QueryFilter));
                    QueryFilter.WhereClause = $"{whereClause} and fcsubtype in (1)";
                    Store(() => S57_ProductCoverage(source, destination, QueryFilter, s128));
                    //Store(() => FeatureRelations.Instance.CreateRelations(destination));

                }
                else {
                    /*var whereClause = QueryFilter.WhereClause.Clone();
                    QueryFilter.WhereClause = $"{whereClause} and globalid = '{{EEC8A630-411C-43E0-8EF3-97B7A5FD5E4F}}'";
                    QueryFilter.WhereClause = $"{whereClause}";
                    */

                    Logger.Current.Information($"Converting all tables: {QueryFilter.WhereClause}");

                    Logger.Current.Information($"Converting Product Coverages");
                    Store(() => S57_ProductCoverage(source, destination, QueryFilter, s128));


                    Logger.Current.Information($"Converting Sounding Datums");
                    Store(() => S101_SoundingDatum(source, destination, QueryFilter));

                    Logger.Current.Information($"Converting Metadata");
                    Store(() => S57_MetadataA(source, destination, QueryFilter));
                    Store(() => S57_MetadataP(source, destination, QueryFilter));

                    Logger.Current.Information($"Converting Areas And Limits");
                    Store(() => S57_RegulatedAreasAndLimitsA(source, destination, QueryFilter));
                    Store(() => S57_RegulatedAreasAndLimitsL(source, destination, QueryFilter));
                    Store(() => S57_RegulatedAreasAndLimitsP(source, destination, QueryFilter));



                    //filter.WhereClause = "globalid = '{D7DE9631-CF20-4143-B3F4-47BB4A2AE541}'";
                    //filter.WhereClause = "globalid = '{855B900E-760C-4D68-AE02-8F3CA6FE60DD}'";
                    //filter.WhereClause = "globalid = '{BAFFC1F3-A89C-4E13-982F-B577E50A06DC}'";
                    //filter.WhereClause = "globalid = '{1F1D8B58-4959-4202-80F5-6CA4DD47D209}'";

                    Logger.Current.Information($"Converting Dangers");
                    Store(() => S57_DangersA(source, destination, QueryFilter));
                    Store(() => S57_DangersL(source, destination, QueryFilter));
                    Store(() => S57_DangersP(source, destination, QueryFilter));



                    Logger.Current.Information($"Converting Natural Features");
                    Store(() => S57_NaturalFeaturesA(source, destination, QueryFilter));
                    Store(() => S57_NaturalFeaturesL(source, destination, QueryFilter));
                    Store(() => S57_NaturalFeaturesP(source, destination, QueryFilter));


                    Logger.Current.Information($"Converting Cultural Features");
                    Store(() => S57_CulturalFeaturesA(source, destination, QueryFilter));
                    Store(() => S57_CulturalFeaturesL(source, destination, QueryFilter));
                    Store(() => S57_CulturalFeaturesP(source, destination, QueryFilter));


                    Logger.Current.Information($"Converting Contours");
                    Store(() => S57_DepthsL(source, destination, QueryFilter));


                    //Logger.Current.Information($"Converting S101_RecommendedTracksAndRoutes");
                    //Store(() => S101_RecommendedTracksAndRoutes(source, destination, QueryFilter));



                    Logger.Current.Information($"Converting PortsAndServices");
                    Store(() => S57_PortsAndServicesA(source, destination, QueryFilter));
                    Store(() => S57_PortsAndServicesL(source, destination, QueryFilter));
                    Store(() => S57_PortsAndServicesP(source, destination, QueryFilter));

                    Logger.Current.Information($"Converting Soundings");
                    Store(() => S57_SoundingsP(source, destination, QueryFilter));

                    Logger.Current.Information($"Converting Tides And Variations");
                    Store(() => S57_TidesAndVariationsA(source, destination, QueryFilter));
                    Store(() => S57_TidesAndVariationsL(source, destination, QueryFilter));
                    Store(() => S57_TidesAndVariationsP(source, destination, QueryFilter));


                    Logger.Current.Information($"Converting Seabeds");
                    Store(() => S57_SeabedA(source, destination, QueryFilter));
                    Store(() => S57_SeabedL(source, destination, QueryFilter));
                    Store(() => S57_SeabedP(source, destination, QueryFilter));

                    Logger.Current.Information($"Converting CoastLines");
                    Store(() => S57_CoastlineA(source, destination, QueryFilter));
                    Store(() => S57_CoastlineL(source, destination, QueryFilter));
                    Store(() => S57_CoastlineP(source, destination, QueryFilter));

                    Logger.Current.Information($"Converting Depth Areas");
                    Store(() => S57_DepthsA(source, destination, QueryFilter));

                    Logger.Current.Information($"Converting Ice features");
                    Store(() => S57_IcefeaturesA(source, destination, QueryFilter));

                    Logger.Current.Information($"Converting Military Features");
                    Store(() => S57_MilitaryFeatureA(source, destination, QueryFilter));
                    Store(() => S57_MilitaryFeaturesP(source, destination, QueryFilter));


                    Logger.Current.Information($"Converting Offshore Installations");
                    Store(() => S57_OffshoreInstallationsA(source, destination, QueryFilter));
                    Store(() => S57_OffshoreInstallationsL(source, destination, QueryFilter));
                    Store(() => S57_OffshoreInstallationsP(source, destination, QueryFilter));

                    Logger.Current.Information($"Converting Tracks And Routes");
                    Store(() => S57_TracksAndRoutesA(source, destination, QueryFilter));
                    Store(() => S57_TracksAndRoutesL(source, destination, QueryFilter));
                    Store(() => S57_TracksAndRoutesP(source, destination, QueryFilter));

                    Logger.Current.Information($"Converting Aids to Navigation");
                    Store(() => S57_AidsToNavigationP(source, destination, QueryFilter));

                    Logger.Current.Information($"Converting Note files");
                    Store(() => NauticalInformations.Instance.Flush(destination));


                    //Store(() => FeatureRelations.Instance.CreateRelations(destination));
                }
                //#endif
                //Logger.Current.Information($"Igniting afterburner");
                //Afterburner.Initialize(destination);
                //Afterburner.Instance.CutClosedRoadLines();

                Logger.Current.Information($"Loading sanity checker");
                SanityChecker.Initialize(destination);

                Logger.Current.Information($"Validating drawing index");
                status = SanityChecker.Instance.Check_GetUsageBandErrorCount() == 0 ? "PASSED" : "FAILED";
                Logger.Current.Information($"No Empty drawing index in S-101: {status}");

                Logger.Current.Information($"Validating ESRI Uknown values");
                status = SanityChecker.Instance.Check_GetEsriUnknown32767ErrorCount() == 0 ? "PASSED" : "FAILED";
                Logger.Current.Information($"No ESRI unknown values (-32767) in S-101: {status}");

                Logger.Current.Information($"Validating edition-info");
                status = SanityChecker.Instance.Check_GetEditionsErrorCount() == 0 ? "PASSED" : "FAILED";
                Logger.Current.Information($"No missing edition-info in S-101: {status}");

                Logger.Current.Information($"Validating default clearance");
                status = SanityChecker.Instance.Check_GetDefaultClearanceViolationCount() == 0 ? "PASSED" : "FAILED";
                Logger.Current.Information($"No defaultClearanceViolation in S-101: {status}");

                Logger.Current.Information("Done");

                Logger.Current.Information($"!: CHECK LOGS AT: {Logger.LogDir}");

                return true;
            }
        }

        private static void DeleteAll(Table table) {
            QueryFilter queryFilter = new QueryFilter {
                WhereClause = "1=1" // Gets all rows
            };

            table.DeleteRows(queryFilter);
            return;


            using (var rowCursor = table.CreateUpdateCursor(queryFilter, true)) {
                while (rowCursor.MoveNext()) {
                    rowCursor.Current.Delete();
                }
            }
        }

        internal static decimal? GetDefaultClearanceDepthWreck(Geometry? shape, decimal? valsou, int? expsou, decimal? height, int? watlev, int? catwrk, long objectid, string tablename, string lnam) {

            bool coveredByUnsurveyedArea = false;
            bool coveredByDredgedArea = false;
            decimal? surroundingDepth = null;
            decimal? leastDepth = null;

            if (shape != null) {
                foreach (DepthsA depthArea in SpatialRelationResolver.Instance.GetSpatialRelatedValueFrom<DepthsA>(shape)) {
                    if (leastDepth is null) {
                        leastDepth = depthArea.DRVAL1.HasValue ? depthArea.DRVAL1.Value : null;
                    }
                    else if (leastDepth > depthArea.DRVAL1) {
                        leastDepth = depthArea.DRVAL1.HasValue ? depthArea.DRVAL1.Value : null;
                    }

                    if (depthArea.FcSubtype is 15) {  // UNSARE
                        coveredByUnsurveyedArea = true;
                        break;
                    }
                    if (depthArea.FcSubtype is 5) {  // DRGARE
                        coveredByDredgedArea = true;
                        surroundingDepth = leastDepth != -32767m ? leastDepth : null;
                    }
                    if (depthArea.FcSubtype is 1) {  // DEPARE
                        surroundingDepth = leastDepth != -32767m ? leastDepth : null;
                    }

                    surroundingDepth = leastDepth != -32767m ? leastDepth : null;
                }
            }

            bool allCoveringDepthRangeMinimumValuesAreKnown = surroundingDepth.HasValue;

            bool unknownDepthCoveredByUnsurveyedArea = coveredByUnsurveyedArea && (valsou.HasValue && valsou is -32767m);

            bool depthDredgedAreaWhereDepthMinimumValueIsUnknown = coveredByDredgedArea && !surroundingDepth.HasValue;

            bool valsouIsKnown = valsou is not null && valsou is not -32767m;
            bool valsouIsUnknown = valsou is -32767m;

            bool catwrkIsUnknown = catwrk is -32767;

            bool heightIsKnown = height is not null && height is not -32767m;
            bool heightIsUnknown = height is -32767m;
            bool expositionOfSoundingIs1Or3 = expsou is 1 || expsou is 3; // || expsou == -32767;
            bool expositionOfSoundingIsUnknown = expsou is -32767;


            if (allCoveringDepthRangeMinimumValuesAreKnown) {
                if ((catwrk is 4 || catwrk is 5) &&
                    heightIsKnown &&
                    (watlev is 1 || watlev is 2 || watlev is -32767)) {
                    return null;
                }
                else if (valsouIsKnown &&
                    (watlev is 3 || watlev is 4 || watlev is 5 || watlev is -32767)) {
                    return null;
                }
                else if (expositionOfSoundingIs1Or3 &&
                    valsouIsUnknown &&
                    (watlev.HasValue && (watlev is 3))) {
                    return leastDepth;
                }
                else if (expositionOfSoundingIs1Or3 &&
                    (watlev.HasValue && (watlev is 3))) {
                    return leastDepth;
                }
                else if ((catwrk is 1) &&
                    ((watlev is 1 || watlev is 2 || watlev is 4 || watlev is 5 || watlev is -32767))) {

                    return 20.1m > (leastDepth - 66) ? 20.1m : (leastDepth - 66); // 20.1 or least depth - 66, whichever is largest
                }
                else if (catwrk is 1 &&
                    (expsou is null || expositionOfSoundingIsUnknown || (expsou is 2))) {
                    return 20.1m > (leastDepth - 66) ? 20.1m : (leastDepth - 66); // 20.1 or least depth - 66, whichever is largest
                }
                else if ((expsou is null || expositionOfSoundingIsUnknown || (expsou is 2)) &&
                    valsouIsUnknown &&
                    (watlev is 3 || watlev is 5)) {
                    return 0m;
                }
                else if ((expsou is null || expositionOfSoundingIsUnknown || (expsou is 2)) &&
                    valsouIsUnknown &&
                    (watlev is 4 || watlev is -32767)) {

                    return -15m;
                }
                else if (((catwrk is 2 || catwrk is 3 || catwrk is 4 || catwrk is 5 || catwrk is -32767)) &&
                    (watlev is 1 || watlev is 2 || watlev is 4 || watlev is 5 || watlev is -32767)) {
                    return -15m;
                }
                else if ((catwrk is 2 || catwrk is 3 || catwrk is 4 || catwrk is 5 || catwrk is -32767) &&
                    (expsou is null || expositionOfSoundingIsUnknown || (expsou is 2))) {
                    return -15m;
                }
                else {
                    Logger.Current.DataError(objectid, tablename, lnam, $"1:Cannot set default clearance depth. Check loader.");
                    return null;

                }
            }
            else if (unknownDepthCoveredByUnsurveyedArea || depthDredgedAreaWhereDepthMinimumValueIsUnknown) {

                if (catwrk is 1 &&
                    (watlev is 3 || watlev is -32767)) {
                    return 20.1m;
                }
                else if (valsouIsUnknown &&
                    (watlev is 3 || watlev is 5)) {
                    return 0m;
                }
                else if (valsouIsUnknown &&
                    (watlev is 4 || watlev is -32767)) {
                    return -15m;
                }
                else if (catwrkIsUnknown &&
                    (watlev is 3 || watlev is 5)) {
                    return 0m;
                }
                else if ((catwrk is 2 || catwrk is 3 || catwrk is 4 || catwrk is 5) &&
                    (watlev is 3 || watlev is 5)) {
                    return -15m;
                }
                else if ((catwrk is 2 || catwrk is 3 || catwrk is 4 || catwrk is 5 || catwrk is -32767) &&
                    (watlev is 4 || watlev is -32767)) {
                    return -15m;
                }
                else {
                    Logger.Current.DataError(objectid, tablename, lnam, $"2:Cannot set default clearance depth. Check loader.");
                    return null;
                }
            }
            else {
                Logger.Current.DataError(objectid, tablename, lnam, $"3:Cannot set default clearance depth. Check loader.");
                return null;
            }
        }

        internal static decimal? GetDefaultClearanceDepthObstruction(Geometry? shape, decimal? valsou, int? expsou, decimal? height, int? watlev, int? catobs, long objectid, string tablename, string lnam) {

            bool coveredByUnsurveyedArea = false;
            bool coveredByDredgedArea = false;
            decimal? surroundingDepth = null;
            decimal? leastDepth = null;

            if (shape != null) {
                foreach (DepthsA depthArea in SpatialRelationResolver.Instance.GetSpatialRelatedValueFrom<DepthsA>(shape)) {
                    leastDepth = depthArea.DRVAL1.HasValue ? depthArea.DRVAL1.Value : null;

                    if (depthArea.FcSubtype!.Value == 15) {  // UNSARE
                        coveredByUnsurveyedArea = true;
                        break;
                    }
                    if (depthArea.FcSubtype!.Value == 5) {  // DRGARE
                        coveredByDredgedArea = true;
                        surroundingDepth = leastDepth != -32767m ? leastDepth : null;
                    }
                    if (depthArea.FcSubtype!.Value == 1) {  // DEPARE
                        surroundingDepth = leastDepth != -32767m ? leastDepth : null;
                    }

                    surroundingDepth = leastDepth != -32767m ? leastDepth : null;
                }
            }

            bool allCoveringDepthRangeMinimumValuesAreKnown = surroundingDepth.HasValue;

            bool unknownDepthCoveredByUnsurveyedArea = coveredByUnsurveyedArea && (valsou.HasValue && valsou.Value == -32767m);

            bool depthDredgedAreaWhereDepthMinimumValueIsUnknown = coveredByDredgedArea && !surroundingDepth.HasValue;

            bool valsouIsKnown = valsou.HasValue && valsou.Value != -32767m;
            bool valsouIsUnknown = valsou.HasValue && valsou.Value == -32767m;
            bool heightIsKnown = height.HasValue && height.Value != -32767m;
            bool heightIsUnknown = height.HasValue && height.Value == -32767m;
            bool expositionOfSoundingIs1Or3 = expsou is 1 || expsou is 3;


            if (allCoveringDepthRangeMinimumValuesAreKnown) {
                if (heightIsKnown &&
                    (watlev is 1 || watlev is 2)) {
                    return null;
                }
                else if (heightIsUnknown &&
                    (watlev is 1 || watlev is 2 || watlev is 7)) {
                    return null;
                }
                else if (valsouIsKnown &&
                    (watlev is 3 || watlev is 4 || watlev is 5 || watlev is -32767)) {
                    return null;
                }
                else if (expositionOfSoundingIs1Or3 &&
                    valsouIsUnknown &&
                    (watlev is 3)) {
                    return leastDepth;
                }
                else if ((catobs is 6) &&
                    (expsou is null || (expsou is 2 || expsou is -32767)) &&
                    valsouIsUnknown) {
                    return 0.1m;
                }
                else if ((expsou is null || (expsou is 2 || expsou is -32767)) &&
                    valsouIsUnknown &&
                    watlev is 3) {
                    return 0.1m;
                }
                else if ((catobs is not 6) &&
                    (expsou is null || (expsou is 2 || expsou is -32767)) &&
                    valsouIsUnknown &&
                    (watlev is 5)) {
                    return 0m;
                }
                else if ((catobs is not 6) &&
                    (expsou is null || (expsou is 2 || expsou is -32767)) &&
                    valsouIsUnknown &&
                    (watlev is 4 || watlev is -32767)) {
                    return -15m;
                }
                else {
                    Logger.Current.DataError(objectid, tablename, lnam, $"1:Cannot set default clearance depth. Check loader.");
                    return null;

                }
            }
            else if (unknownDepthCoveredByUnsurveyedArea || depthDredgedAreaWhereDepthMinimumValueIsUnknown) {

                if ((catobs is 6) &&
                    valsouIsUnknown) {
                    return 0.1m;
                }
                else if (valsouIsUnknown &&
                    (watlev is 3)) {
                    return 0.1m;
                }
                else if ((catobs is 6) &&
                    valsouIsUnknown &&
                    (watlev is 5)) {
                    return 0m;
                }
                else if ((catobs is not 6) &&
                    valsouIsUnknown &&
                    (watlev is 4 || watlev is -32767)) {
                    return -15m;
                }
                else {
                    Logger.Current.DataError(objectid, tablename, lnam, $"2:Cannot set default clearance depth. Check loader.");
                    return null;
                }
            }
            else {
                Logger.Current.DataError(objectid, tablename, lnam, $"3:Cannot set default clearance depth. Check loader.");
                return null;
            }
        }

        static readonly string[] ISO3166 = ["AF", "AX", "AL", "DZ", "AS", "AD", "AO", "AI", "AQ", "AG", "AR", "AM", "AW", "AU", "AT", "AZ", "BS", "BH", "BD", "BB", "BY", "BE", "BZ", "BJ", "BM", "BT", "BO", "BQ", "BA", "BW", "BV", "BR", "IO", "BN", "BG", "BF", "BI", "CV", "KH", "CM", "CA", "KY", "CF", "TD", "CL", "CN", "CX", "CC", "CO", "KM", "CD", "CG", "CK", "CR", "CI", "HR", "CU", "CW", "CY", "CZ", "DK", "DJ", "DM", "DO", "EC", "EG", "SV", "GQ", "ER", "EE", "SZ", "ET", "FK", "FO", "FJ", "FI", "FR", "GF", "PF", "TF", "GA", "GM", "GE", "DE", "GH", "GI", "GR", "GL", "GD", "GP", "GU", "GT", "GG", "GN", "GW", "GY", "HT", "HM", "VA", "HN", "HK", "HU", "IS", "IN", "ID", "IR", "IQ", "IE", "IM", "IL", "IT", "JM", "JP", "JE", "JO", "KZ", "KE", "KI", "KP", "KR", "KW", "KG", "LA", "LV", "LB", "LS", "LR", "LY", "LI", "LT", "LU", "MO", "MG", "MW", "MY", "MV", "ML", "MT", "MH", "MQ", "MR", "MU", "YT", "MX", "FM", "MD", "MC", "MN", "ME", "MS", "MA", "MZ", "MM", "NA", "NR", "NP", "NL", "NC", "NZ", "NI", "NE", "NG", "NU", "NF", "MK", "MP", "NO", "OM", "PK", "PW", "PS", "PA", "PG", "PY", "PE", "PH", "PN", "PL", "PT", "PR", "QA", "RE", "RO", "RU", "RW", "BL", "SH", "KN", "LC", "MF", "PM", "VC", "WS", "SM", "ST", "SA", "SN", "RS", "SC", "SL", "SG", "SX", "SK", "SI", "SB", "SO", "ZA", "GS", "SS", "ES", "LK", "SD", "SR", "SJ", "SE", "CH", "SY", "TW", "TJ", "TZ", "TH", "TL", "TG", "TK", "TO", "TT", "TN", "TR", "TM", "TC", "TV", "UG", "UA", "AE", "GB", "UM", "US", "UY", "UZ", "VU", "VE", "VN", "VG", "VI", "WF", "EH", "YE", "ZM", "ZW"];

        internal static string GetNation(string nation) {
            if (ISO3166.Contains(nation.ToUpperInvariant()))
                return nation.ToUpperInvariant();
            throw new NotSupportedException($"Nation {nation} cannot be converted");
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

        internal static void SetUsageBand(RowBuffer buffer, int scale) {
            return;

            _ = scale switch {
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
        internal static rhythmOfLight GetRythmOfLight<TType>(AidsToNavigationP current) where TType : S100FC.FeatureType {
            /*
                When populating rhythm of light, the
                sub-attributes signal group, signal period and signal sequence are only valid for non-fixed lights
                (that is, sub-attribute light characteristic ≠ 1 (fixed)), with signal group and signal period being
                mandatory
            */

            //current.SIGGRP != default ? new List<string> { current.SIGGRP } : new();
            List<string> parenthesisParts = [];

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
            //var signalPeriodN = current.SIGPER == -32767m ? default : current.SIGPER;

            var sigseq = current.SIGSEQ;

            //lightCharacteristic? lightCharacteristicsValue = default;

            //if (current.LITCHR.HasValue) {
            //    lightCharacteristicsValue = EnumHelper.GetEnumValue(current.LITCHR.Value);
            //}

            var signalSequences = GetSignalSequences(current.SIGSEQ);

            var rhythmOfLight = new rhythmOfLight() {
                lightCharacteristic = EnumHelper.GetEnumValue(current.LITCHR),
                signalGroup = [.. parenthesisParts],
                signalSequence = [.. signalSequences],
            };
            //if (lightCharacteristicsValue != null)
            //    rhythmOfLight.lightCharacteristic = EnumHelper.GetEnumValue(current.LITCHR);
            //if (parenthesisParts.Any())
            //    rhythmOfLight.signalGroup = parenthesisParts.ToArray();
            if (current.SIGPER.HasValue)
                rhythmOfLight.signalPeriod = current.SIGPER == -32767m ? null : current.SIGPER.Value;
            //if (signalSequences.Any())
            //    rhythmOfLight.signalSequence = signalSequences.ToArray();
            return rhythmOfLight;
        }

        internal static verticalDatum? GetVerticalDatum(int? value) {
            if(!value.HasValue) return default(verticalDatum?);
            /*
            if (current.VERDAT.HasValue) {
                instance.verticalDatum = EnumHelper.GetEnumValue<verticalDatum>(current.VERDAT.Value);
            }
            */

            if (VerticalDatumConverter.ContainsKey(value.Value)) {
                return EnumHelper.GetEnumValue(VerticalDatumConverter[value.Value]);
            }
            return EnumHelper.GetEnumValue(value);

            //if (value != 3) {
            //    return EnumHelper.GetEnumValue(value);
            //}

            //return verticalDatum.BalticSeaChartDatum2000;
        }
        internal static verticalDatum? GetSoundingDatum(int value) {
            return EnumHelper.GetEnumValue(value);
        }

        //internal static verticalDatum? GetVerticalDatum<TType>(int value) where TType : DomainModel.FeatureNode {
        //    return EnumHelper.GetEnumValue(value);
        //}


        internal static signalSequence[] GetSignalSequences(string? sigseq) {
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
                            signalStatus = 1,   //signalStatus.LitSound
                        });
                    }
                    else if (!string.IsNullOrEmpty(match.Groups[2].Value)) {
                        var duration = decimal.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);
                        // Eclipse
                        signalSequences.Add(new signalSequence() {
                            signalDuration = duration,
                            signalStatus = 2,   //signalStatus.EclipsedSilent
                        });
                    }
                }
            }
            return signalSequences.ToArray();
        }

        internal static int?[]? GetColours(string color) {
            return EnumHelper.GetEnumValues(color);

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

        internal static colourPattern? GetColourPattern(string colorPattern) {
            if (colorPattern.Contains(",")) {
                Logger.Current.Error($"Multiple colorPatterns not supported in S-101 ({colorPattern})!");
            }
            var colourPat = colorPattern switch {
                "1" => 1,   //colourPattern.HorizontalStripes,
                "2" => 2,   //colourPattern.VerticalStripes,
                "3" => 3,   //colourPattern.DiagonalStripes,
                "4" => 4,   //colourPattern.Squared,
                "5" => 5,   //colourPattern.StripesDirectionUnknown,
                "6" => 6,   //colourPattern.BorderStripe,
                "-32767" => default,

                "3,4" => 3, //US

                _ => throw new IndexOutOfRangeException($"Colourpattern value is not legal {colorPattern}")
            };
            return colourPat;
        }

        private static status GetSingleStatus(string status) {
            return GetStatus(status)[0];


        }

        internal static int?[] GetStatus(string statuses) {
            List<int?> statusList = [];

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
                    int? e = c.ToLowerInvariant() switch {
                        "1" => 1,   //status.Permanent,
                        "2" => 2,   //status.Occasional,
                        "3" => 3,   //status.Recommended,
                        "4" => 4,   //status.NotInUse,
                        "5" => 5,   //status.PeriodicIntermittent,
                        "6" => 6,   //status.Reserved,
                        "7" => 7,   //status.Temporary,
                        "8" => 8,   //status.Private,
                        "9" => 9,   //status.Mandatory,
                        "11" => 11,   //status.Extinguished,
                        "12" => 12,   //status.Illuminated,
                        "13" => 13,   //status.Historic,
                        "14" => 14,   //status.Public,
                        "15" => 15,   //status.Synchronized,
                        "16" => 16,   //status.Watched,
                        "17" => 17,   //status.Unwatched,
                        "18" => 18,   //status.ExistenceDoubtful,
                        //"28" => ??, // TODO: what to do? STATUS 28
                        "-32767" => default,
                        _ => throw new IndexOutOfRangeException(),
                    };
                    if (e.HasValue) {
                        statusList.Add(e.Value);
                    }
                }

            }
            return statusList.ToArray();
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
                1 => 1,    // under construction
                2 => 2,    // ruined
                3 => 3,    // under reclamation
                5 => 5,    // planned construction
                -32767 => (condition)(-1),                        // unknown or no condition
                _ => throw new IndexOutOfRangeException("Invalid condition value.")  // Invalid condition value
            };
        }


        internal static featureName[]? GetFeatureName(string? objname, string? nobjnme) {
            List<featureName> featureName = [];
            if (objname != default) {
                var objnam = objname.Trim();
                if (!string.IsNullOrEmpty(objnam)) {
                    var item = new featureName {
                        language = "eng",
                        name = objnam,
                        nameUsage = 1    //nameUsage.DefaultNameDisplay,
                    };
                    featureName.Add(item);
                }
            }
            if (nobjnme != default) {
                var nobjnm = nobjnme.Trim();
                if (!string.IsNullOrEmpty(nobjnm)) {
                    var item = new featureName {
                        language = "dan",
                        name = nobjnm,
                        nameUsage = 2    //nameUsage.AlternateNameDisplay,
                    };
                    featureName.Add(item);
                }
            }

            if (featureName.Any())
                return featureName.ToArray();
            return null;
        }

        internal static InformationResult BindNauticalInformationFrom(int sourceObjectid, string? sourceTableName, string? ntxtds, string? txtdsc, string? inform, string? ninform) {
            InformationResult result = new();

            if (!string.IsNullOrEmpty(ntxtds)) {
                // TODO: make information binding -> Nautical Information - binding.
                if (!string.IsNullOrEmpty(ntxtds) && ntxtds.EndsWith(".txt", StringComparison.InvariantCultureIgnoreCase)) {
                    var filePath = System.IO.Path.Combine(_notesPath, ntxtds);
                    string fileReference = ntxtds;
                    string language = "eng";

                    var instance = new NauticalInformation {
                        information = [
                                new information() {
                                fileReference = FixFilename(fileReference) ?? default,
                                language = language
                                }]
                    };
                    result.InformationBindings.Add(NauticalInformations.Instance.Add(instance.information[0]!.fileReference!, instance));
                }
                else if (!string.IsNullOrEmpty(ntxtds)) {
                    string language = "eng";

                    var instance = new information {
                        language = language,
                        text = ntxtds?.Trim(),
                    };
                    result.information.Add(instance);
                }
            }

            if (!string.IsNullOrEmpty(txtdsc)) {

                // TODO: make information binding -> Nautical Information - binding.
                if (!string.IsNullOrEmpty(txtdsc) && txtdsc.EndsWith(".txt", StringComparison.InvariantCultureIgnoreCase)) {
                    var filePath = System.IO.Path.Combine(_notesPath, txtdsc);

                    string fileReference = txtdsc;
                    string language = "eng";

                    var instance = new NauticalInformation {
                        information = [
                                new information() {
                                fileReference = FixFilename(fileReference) ?? default,
                                language = language,
                            }]
                    };

                    result.InformationBindings.Add(NauticalInformations.Instance.Add(instance.information[0]!.fileReference!, instance));

                    // information.Add(instance);
                }
                else if (!string.IsNullOrEmpty(txtdsc)) {
                    string fileReference = txtdsc;
                    string language = "eng";

                    var instance = new information {
                        language = language,
                        text = txtdsc?.Trim(),
                    };
                    result.information.Add(instance);
                }
            }

            if (!string.IsNullOrEmpty(inform)) {

                //https://geodatastyrelsen.atlassian.net/wiki/spaces/SOEKORT/pages/4404478463/S-65+Annex+B+Appendix+A+-+Impact+analysis
                // Separate discrete information populated in INFORM using a standard separator such as semicolon “;”.

                string[] informs = inform != null ? inform.Split(';') : Array.Empty<string>();

                foreach (var value in informs) {
                    if (!string.IsNullOrEmpty(value) && value.EndsWith(".txt", StringComparison.InvariantCultureIgnoreCase)) {
                        var filePath = System.IO.Path.Combine(_notesPath, value);

                        string fileReference = txtdsc;
                        string language = "eng";

                        var instance = new NauticalInformation {
                            information = [
                                new information() {
                                fileReference = FixFilename(fileReference) ?? default,
                                language = language
                            }]
                        };

                        result.InformationBindings.Add(NauticalInformations.Instance.Add(instance.information[0]!.fileReference!, instance));

                    }
                    else if (!string.IsNullOrEmpty(value)) {
                        string fileReference = value;
                        string language = "eng";

                        var instance = new information {
                            language = language,
                            text = value?.Trim(),
                        };
                        result.information.Add(instance);
                    }
                }
            }

            if (!string.IsNullOrEmpty(ninform)) {
                // https://geodatastyrelsen.atlassian.net/wiki/spaces/SOEKORT/pages/4404478463/S-65+Annex+B+Appendix+A+-+Impact+analysis
                // Separate discrete information populated in INFORM using a standard separator such as semicolon “;”.
                if (!string.IsNullOrEmpty(ninform)) {

                    string[] ninfoms = ninform != null ? ninform.Split(';') : Array.Empty<string>();

                    foreach (var value in ninfoms) {

                        if (!string.IsNullOrEmpty(value) && value.EndsWith(".txt", StringComparison.InvariantCultureIgnoreCase)) {
                            var filePath = System.IO.Path.Combine(_notesPath, value);

                            string fileReference = value;
                            string language = "dan";

                            var instance = new NauticalInformation {
                                information = [new information() {
                                    fileReference = FixFilename(fileReference) ?? default,
                                    language = language
                                }]
                            };

                        }
                        else if (!string.IsNullOrEmpty(value)) {
                            string fileReference = value;
                            string language = "dan";

                            var instance = new information {
                                language = language,
                                text = value?.Trim(),
                            };
                            result.information.Add(instance);
                        }
                    }
                }
            }
            return result;
        }

        internal static string?[] GetCommunicationChannel(string input) {
            var result = new List<string>();
            if (string.IsNullOrWhiteSpace(input)) return [];

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

            return result.ToArray();
        }

        internal static string? FixFilename(string fileReference) {
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

        //internal static NauticalInformation CreateNauticalInformation(string picrep, string datsta, string datend, string persta, string perend, List<information> information) {
        //    NauticalInformation nobj = new NauticalInformation();
        //    if (picrep != default) {
        //        nobj.pictorialRepresentation = ImporterNIS.FixFilename(picrep) ?? default;
        //    }

        //    nobj.information = information;
        //    nobj.Code = ps101;

        //    DateHelper.TryGetFixedDateRange(datsta, datend, out var dateRange);
        //    if (dateRange != default) {
        //        nobj.fixedDateRange = dateRange;
        //    }

        //    DateHelper.TryGetPeriodicDateRange(persta, perend, out var periodicDateRange);
        //    if (periodicDateRange != default) {
        //        nobj.periodicDateRange = periodicDateRange;
        //    }

        //    return nobj;
        //}

        //internal static void AddInformation(List<information> instanceInformation, Row current) {
        //    List<information> information = CreateInformationFrom(current);
        //    instanceInformation.AddRange(information);
        //}
        internal static InformationResult AddInformation(int sourceObjectid, string? sourceTableName, string? ntxtds, string? txtdsc, string? inform, string? ninform) {
            // TODO: TBD.
            //List<information> information = CreateInformationFrom(sourceObjectid, sourceTableName, ntxtds, txtdsc, inform, ninform);
            //instanceInformation.AddRange(information);

            //TODO: Fix binding
            return BindNauticalInformationFrom(sourceObjectid, sourceTableName, ntxtds, txtdsc, inform, ninform);

            //if (!result.information.Any())
            //    return [];
            //instanceInformation.AddRange(result.information);

            //return result.InformationBindings;
        }
    }
}

