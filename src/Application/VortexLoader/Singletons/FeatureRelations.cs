using ArcGIS.Core.Data;
using S100FC;
using S100FC.S101.ComplexAttributes;
using S100FC.S101.FeatureAssociation;
using S100FC.S101.FeatureTypes;
using S100Framework.Applications.S57.esri;
using System.Data;

namespace S100Framework.Applications.Singletons
{

    internal enum Direction
    {
        Source = 0,
        Destination = 1
    }

    /*
        RIND
        Code	Description
        1	Master
        2	Slave
        3	Peer
        999	Rep
     */

    internal class PltsCollection
    {
        private readonly List<PltsSlave> _related;

        private readonly PLTS_Collections _plts_collections;

        readonly Geodatabase? _source;

        public PltsCollection(Geodatabase source, PLTS_Collections plts_collections) {
            this._plts_collections = plts_collections;
            this._related = [];
            this._source = source;
        }

        internal void AddRelated(PLTS_Frel plts_frel) {
            this._related.Add(new PltsSlave(plts_frel));
        }
    }

    internal class PltsSlave
    {
        private S57Object? s57Object = null;

        public PLTS_Frel PLTS_Frel { get; internal set; }

        public S57Object? S57Object {
            get => this.s57Object;

            internal set {

                this.s57Object = value;

                var s57Obj = this.s57Object;

                if (s57Obj is AidsToNavigationP) {
                    var aton = s57Obj as AidsToNavigationP;
                    // Collections
                    if (aton != null && aton.FCSUBTYPE == 1) {
                        this.S101Type = typeof(CardinalBeacon);
                    }
                    else if (aton != null && aton.FCSUBTYPE == 5) {
                        this.S101Type = typeof(IsolatedDangerBeacon);
                    }
                    else if (aton != null && aton.FCSUBTYPE == 10) {
                        this.S101Type = typeof(LateralBeacon);
                    }
                    else if (aton != null && aton.FCSUBTYPE == 15) {
                        this.S101Type = typeof(SafeWaterBeacon);
                    }
                    else if (aton != null && aton.FCSUBTYPE == 20) {
                        this.S101Type = typeof(SpecialPurposeGeneralBeacon);
                    }
                    else if (aton != null && aton.FCSUBTYPE == 25) {
                        this.S101Type = typeof(CardinalBuoy);
                    }
                    else if (aton != null && aton.FCSUBTYPE == 30) {
                        this.S101Type = typeof(InstallationBuoy);
                    }
                    else if (aton != null && aton.FCSUBTYPE == 35) {
                        this.S101Type = typeof(IsolatedDangerBuoy);
                    }
                    else if (aton != null && aton.FCSUBTYPE == 40) {
                        this.S101Type = typeof(LateralBuoy);
                    }
                    else if (aton != null && aton.FCSUBTYPE == 45) {
                        this.S101Type = typeof(SafeWaterBuoy);
                    }
                    else if (aton != null && aton.FCSUBTYPE == 50) {
                        this.S101Type = typeof(SpecialPurposeGeneralBuoy);
                    }
                    else if (aton != null && aton.FCSUBTYPE == 70) {
                        this.S101Type = typeof(LightFloat);
                    }
                    else if (aton != null && aton.FCSUBTYPE == 75) {
                        this.S101Type = typeof(LightVessel);
                    }
                    // Slaves
                    else if (aton != null && aton.FCSUBTYPE == 55) {
                        this.S101Type = typeof(Daymark);
                    }
                    else if (aton != null && aton.FCSUBTYPE == 60) {
                        this.S101Type = typeof(FogSignal);
                    }
                    else if (aton != null && aton.FCSUBTYPE == 65) {
                        this.S101Type = FeatureRelations.Instance.GetS101CatlitTypeFrom(aton);
                    }
                    else if (aton != null && aton.FCSUBTYPE == 90) {
                        this.S101Type = typeof(RadarStation);
                    }
                    else if (aton != null && aton.FCSUBTYPE == 95) {
                        this.S101Type = typeof(RadioStation);
                    }
                    else if (aton != null && aton.FCSUBTYPE == 100) {
                        this.S101Type = typeof(Retroreflector);
                    }
                    else if (aton != null && aton.FCSUBTYPE == 105) {
                        this.S101Type = typeof(RadarTransponderBeacon);
                    }
                    else if (aton != null && aton.FCSUBTYPE == 110) {
                        this.S101Type = typeof(topmark);
                    }
                    else {
                        throw new NotSupportedException($"AtoN subtype: {aton?.FCSUBTYPE}");
                    }
                }
                else if (s57Obj is PortsAndServicesP) {
                    var psp = s57Obj as PortsAndServicesP;
                    if (psp != null && psp.FCSUBTYPE == 65) {
                        this.S101Type = typeof(SignalStationTraffic);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 70) {
                        this.S101Type = typeof(SignalStationWarning);
                    }
                    else {
                        throw new NotSupportedException($"AtoN subtype: {psp?.FCSUBTYPE}");
                    }
                }
                else if (s57Obj is NaturalFeaturesA) {
                    var psp = s57Obj as NaturalFeaturesA;
                    if (psp != null && psp.FCSUBTYPE == 1) {
                        this.S101Type = typeof(Lake);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 30) {
                        this.S101Type = typeof(SlopingGround);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 5) {
                        this.S101Type = typeof(LandArea);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 20) {
                        this.S101Type = typeof(River);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 10) {
                        this.S101Type = typeof(LandRegion);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 25) {
                        this.S101Type = typeof(SeaAreaNamedWaterArea);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 35) {
                        this.S101Type = typeof(Vegetation);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 15) {
                        this.S101Type = typeof(Rapids);
                    }

                    else {
                        throw new NotSupportedException($"AtoN subtype: {psp?.FCSUBTYPE}");
                    }
                }
                else if (s57Obj is TracksAndRoutesA) {
                    var psp = s57Obj as TracksAndRoutesA;
                    if (psp != null && psp.FCSUBTYPE == 15) {
                        this.S101Type = typeof(InshoreTrafficZone);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 5) {
                        this.S101Type = typeof(Fairway);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 50) {
                        this.S101Type = typeof(SeparationZoneOrLine);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 40) {
                        this.S101Type = typeof(RecommendedTrack);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 55) {
                        this.S101Type = typeof(TrafficSeparationSchemeCrossing);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 20) {
                        this.S101Type = typeof(PrecautionaryArea);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 70) {
                        this.S101Type = typeof(TwoWayRoutePart);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 25) {
                        this.S101Type = typeof(RadarRange);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 45) {
                        this.S101Type = typeof(SubmarineTransitLane);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 10) {
                        this.S101Type = typeof(FerryRoute);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 60) {
                        this.S101Type = typeof(TrafficSeparationScheme);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 1) {
                        this.S101Type = typeof(DeepWaterRoutePart);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 30) {
                        this.S101Type = typeof(RecommendedTrafficLanePart);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 65) {
                        this.S101Type = typeof(TrafficSeparationScheme);
                    }

                    else {
                        throw new NotSupportedException($"AtoN subtype: {psp?.FCSUBTYPE}");
                    }
                }
                else if (s57Obj is TracksAndRoutesL) {
                    var psp = s57Obj as TracksAndRoutesL;
                    if (psp != null && psp.FCSUBTYPE == 30) {
                        this.S101Type = typeof(RecommendedTrack);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 15) {
                        this.S101Type = typeof(RadarLine);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 25) {
                        this.S101Type = typeof(RadioCallingInPoint);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 40) {
                        this.S101Type = typeof(SeparationZoneOrLine);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 20) {
                        this.S101Type = typeof(RecommendedRouteCentreline);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 1) {
                        this.S101Type = typeof(DeepWaterRouteCentreline);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 45) {
                        this.S101Type = typeof(TrafficSeparationSchemeBoundary);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 10) {
                        this.S101Type = typeof(NavigationLine);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 15) {
                        this.S101Type = typeof(Fairway);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 5) {
                        this.S101Type = typeof(FerryRoute);
                    }
                    else {
                        throw new NotSupportedException($"AtoN subtype: {psp?.FCSUBTYPE}");
                    }
                }
                else if (s57Obj is DangersP) {
                    var psp = s57Obj as DangersP;
                    if (psp != null && psp.FCSUBTYPE == 35) {
                        this.S101Type = typeof(UnderwaterAwashRock);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 1) {
                        this.S101Type = typeof(CautionArea);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 45) {
                        this.S101Type = typeof(Wreck);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 40) {
                        this.S101Type = typeof(WaterTurbulence);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 20) {
                        this.S101Type = typeof(Obstruction);
                    }
                    else if (psp != null && psp.FCSUBTYPE == 10) {
                        this.S101Type = typeof(FishingFacility);
                    }

                    else {
                        throw new NotSupportedException($"AtoN subtype: {psp?.FCSUBTYPE}");
                    }
                }
                else {
                    throw new NotSupportedException($"AtoN subtype: {s57Obj?.GetType()}");
                }

            }
        }

        public Type? S101Type { get; private set; }

        public Guid GlobalId { get; private set; }

        public PltsSlave(PLTS_Frel plts_Frel) {
            this.PLTS_Frel = plts_Frel;

            if (Guid.TryParse(plts_Frel.DEST_UID, out var uid)) {
                this.GlobalId = uid;
            }
        }
    }

    internal class FeatureRelations
    {
        private static FeatureRelations? _instance;
        //        private static Geodatabase? _source;
        //        private static Geodatabase? _target;
        private static readonly HashSet<Relation> _relations = [];
        private static Dictionary<Guid, PltsCollection> _pltsCollections = [];
        private static Dictionary<Guid, IList<PltsSlave>> _srcObjectToSlaves = [];
        private static Dictionary<string, PLTS_Master_Slaves> _pltsMasterSlaves = [];

        private static readonly Dictionary<(string, string), Relation> _createdRelations = [];

        private static bool _isInitialized = false;

        private FeatureRelations() {
        }

        public static FeatureRelations Instance {
            get {

                if (_instance == null) {
                    _instance = new FeatureRelations();
                }
                return _instance;
            }
        }




        internal static void Initialize(Geodatabase source, Geodatabase target) {
            _pltsCollections = [];
            _srcObjectToSlaves = [];
            _pltsMasterSlaves = [];

            LoadPltsCollections(source);
            LoadPltsFrels2(source);
            LoadPLTS_Master_Slaves(source);
            _isInitialized = true;
        }

        private static void LoadPLTS_Master_Slaves(Geodatabase source) {
            // Read aggregations
            using var pltsMasterSLavesTable = source.OpenDataset<Table>(source.GetName("PLTS_MASTER_SLAVES"));

            using var cursor = pltsMasterSLavesTable.Search(null, true);

            while (cursor.MoveNext()) {
                var pltsMasterSlave = new PLTS_Master_Slaves(cursor.Current);
                var key = $"{pltsMasterSlave.FEATURECLASS?.ToLower()};{pltsMasterSlave.FCSUBTYPE}";
                if (!_pltsMasterSlaves.ContainsKey(key)) {
                    _pltsMasterSlaves.Add(key, pltsMasterSlave);
                }
                else {
                    throw new IndexOutOfRangeException($"Multiple pltsMasterSlave with same id (tablename,subtype) not allowed {key}");
                }
            }
        }

        private static void LoadPltsCollections(Geodatabase source) {
            if (source == null) {
                throw new ArgumentException("Source not set");
            }

            // Read aggregations
            var pltsCollectionsTable = source.OpenDataset<Table>(source.GetName("PLTS_COLLECTIONS"));
            //var pltsCollections = new Dictionary<Guid, IList<PLTS_Collections>>();

            var cursor = pltsCollectionsTable.Search(null, true);
            Guid uid;

            while (cursor.MoveNext()) {
                var plts_collection = new PLTS_Collections(cursor.Current);
                Guid.TryParse(Convert.ToString(plts_collection.GLOBALID), out uid);
                if (!_pltsCollections.ContainsKey(uid)) {
                    _pltsCollections[uid] = new PltsCollection(source, plts_collection);
                }
                else {
                    throw new IndexOutOfRangeException($"Multiple PltsCollections with same id not allowed {uid}");
                }
            }
        }

        internal Type GetS101CatlitTypeFrom(AidsToNavigationP aton) {
            if (aton.FCSUBTYPE != 65) {
                throw new NotImplementedException($"Only light types are supported.");
            }

            List<int> catlits = [];

            if (aton.CATLIT != default) {
                catlits = aton.CATLIT.Split(',')
                                   .Select(int.Parse)
                                   .ToList();
            }

            if ((aton.SECTR1 == default || aton.SECTR2 == default) && !(catlits.Contains(1) || catlits.Contains(6) || catlits.Contains(7) || catlits.Contains(16))) {
                return typeof(LightAllAround);
            }
            else if (aton.SECTR1 != default && aton.SECTR2 != default || catlits.Contains(1) || catlits.Contains(16)) {
                return typeof(LightSectored);
            }
            else if (catlits.Contains(6)) {
                return typeof(LightAirObstruction);
            }
            else if (catlits.Contains(7)) {
                return typeof(LightFogDetector);
            }
            else {
                throw new NotSupportedException($"LIGHT catlit: {aton.CATLIT} : {aton.LNAM}");
            }
        }


        internal int GetRelatedCount(Guid uid) {
            if (!_isInitialized)
                throw new ArgumentException("Not initalized. Call intialize.");
            if (_srcObjectToSlaves.ContainsKey(uid))
                return _srcObjectToSlaves[uid].Count;
            else {
                return 0;
            }
        }

        internal IList<PltsSlave> GetRelated(Guid uid) {
            var result = new List<PltsSlave>();
            if (_srcObjectToSlaves.ContainsKey(uid)) {


                return _srcObjectToSlaves[uid];
            }


            return result;
        }


        internal IList<T> GetRelated<T>(Type s101Type, Guid uid) where T : class {
            var result = new List<T>();

            if (!_srcObjectToSlaves.ContainsKey(uid))
                return result;

            foreach (var elm in _srcObjectToSlaves[uid]) {
                if (elm.S57Object != null) {
                    if (elm.S101Type == s101Type) {
                        if (elm.S57Object is T value)
                            result.Add(value);
                    }
                }

            }
            return result;
        }

        internal bool IsSlave(Guid globalid) {
            if (!_isInitialized)
                throw new ArgumentException("Not initalized. Call intialize.");

            var result = _srcObjectToSlaves.Values.SelectMany(list => list)
                                      .FirstOrDefault(obj => obj.GlobalId.Equals(globalid));

            return result != null;
        }

        //private static void LoadPltsFrels(Geodatabase source) {
        //    var pltsFrel = source.OpenDataset<Table>(source.GetName("PLTS_Frel"));
        //    var frelSourceFeatureClasses = new Dictionary<string, IList<PLTS_Frel>>();

        //    var cursor = pltsFrel.Search(null, true);
        //    Guid uid;

        //    while (cursor.MoveNext()) {
        //        var plts_frel = new PLTS_Frel(cursor.Current);

        //        var relationshipIndicator = plts_frel.RIND switch {
        //            1 => "Master",
        //            2 => "Slave",
        //            3 => "Peer",
        //            999 => "Rep",
        //            _ => throw new NotImplementedException()
        //        };

        //        Guid srcUid;

        //        if (relationshipIndicator == "Peer") {
        //            if (plts_frel?.SRC_FC?.ToLower() == "plts_collections") {
        //                Guid.TryParse(Convert.ToString(plts_frel.SRC_UID), out srcUid);
        //                _pltsCollections[srcUid].AddRelated(plts_frel);
        //            }
        //            else {
        //                throw new DataException("PLTS frel where relationship indicator is Peer and source feature class is plts_collections is not allowed ");
        //            }
        //        }
        //        else if (relationshipIndicator == "Master") {
        //            // source: equipment - destination: structure (??)
        //            throw new NotImplementedException("Master plts relationships");

        //        }
        //        else if (relationshipIndicator == "Slave") {
        //            // source: structure - destination: equipment
        //            Guid.TryParse(Convert.ToString(plts_frel.SRC_UID), out uid);
        //            if (!_srcObjectToSlaves.ContainsKey(uid)) {
        //                _srcObjectToSlaves[uid] = new List<PltsSlave>() { new(plts_frel) };
        //            }
        //            else {
        //                var pltsSlave = new PltsSlave(plts_frel);

        //                //pltsSlave.Fetch(_source, Direction.Destination);
        //                _srcObjectToSlaves[uid].Add(pltsSlave);
        //            }
        //        }
        //        else if (relationshipIndicator == "Rep") {
        //            throw new NotImplementedException("PLTS feature relations RelationshipIndicator = Rep");
        //        }
        //    }

        //    foreach (var item in _srcObjectToSlaves) {
        //        foreach (var frel in item.Value) {

        //            var key = frel?.PLTS_Frel?.SRC_FC?.ToLower();
        //            if (key != null) {
        //                if (frelSourceFeatureClasses.ContainsKey(key)) {
        //                    if (frel != null) {
        //                        frelSourceFeatureClasses[key].Add(frel.PLTS_Frel);
        //                    }
        //                }
        //                else {
        //                    if (frel != null) {
        //                        frelSourceFeatureClasses[key] = new List<PLTS_Frel>() { frel.PLTS_Frel };
        //                    }
        //                }
        //            }
        //        }
        //    }

        //}

        private static void LoadPltsFrels2(Geodatabase source) {
            using var pltsFrel = source.OpenDataset<Table>(source.GetName("PLTS_Frel"));
            var frelDestFeatureClasses = new Dictionary<string, IList<PLTS_Frel>>();

            var frels = new HashSet<PLTS_Frel>();

            using var cursor = pltsFrel.Search(null, true);
            Guid uid;

            while (cursor.MoveNext()) {
                var plts_frel = new PLTS_Frel(cursor.Current);

                frels.Add(plts_frel);

                var relationshipIndicator = plts_frel.RIND switch {
                    1 => "Master",
                    2 => "Slave",
                    3 => "Peer",
                    999 => "Rep",
                    _ => throw new NotImplementedException()
                };

                Guid srcUid;

                if (relationshipIndicator == "Peer") {
                    if (plts_frel?.SRC_FC?.ToLower() == "plts_collections") {
                        Guid.TryParse(Convert.ToString(plts_frel.SRC_UID), out srcUid);
                        if (!_pltsCollections.ContainsKey(srcUid)) {
                            Logger.Current.DataError(plts_frel.OBJECTID.GetValueOrDefault(), "plts_frel", plts_frel.DEST_LNAM ?? "Unknown DEST_LNAM", $"Missing {plts_frel.SRC_FC}::{plts_frel.SRC_SUB}::{srcUid}");
                            continue;
                        }

                        _pltsCollections[srcUid].AddRelated(plts_frel);
                    }
                    else {
                        throw new DataException("PLTS frel where relationship indicator is Peer and source feature class is plts_collections is not allowed ");
                    }
                }
                else if (relationshipIndicator == "Master") {
                    // source: equipment - destination: structure (??)
                    throw new NotImplementedException("Master plts relationships");
                }
                else if (relationshipIndicator == "Slave") {
                    // source: structure - destination: equipment
                    Guid.TryParse(Convert.ToString(plts_frel.SRC_UID), out uid);
                    if (!_srcObjectToSlaves.ContainsKey(uid)) {
                        _srcObjectToSlaves[uid] = [new PltsSlave(plts_frel)];
                    }
                    else {
                        // Same relation multiple times are ignored.
                        if (!_srcObjectToSlaves[uid].Any(o =>
                            o.PLTS_Frel.SRC_UID!.ToLower() == plts_frel.SRC_UID!.ToLower() && o.PLTS_Frel.DEST_UID!.ToLower() == plts_frel.DEST_UID!.ToLower() && o.PLTS_Frel.DEST_SUB!.ToLower() == plts_frel.DEST_SUB!.ToLower() && o.PLTS_Frel.SRC_SUB!.ToLower() == plts_frel.SRC_SUB!.ToLower()
                        )) {
                            var pltsSlave = new PltsSlave(plts_frel);
                            _srcObjectToSlaves[uid].Add(pltsSlave);
                        }
                    }
                }
                else if (relationshipIndicator == "Rep") {
                    throw new NotImplementedException("PLTS feature relations RelationshipIndicator = Rep");
                }
            }

            // for faster lookup
            var idIndex = _srcObjectToSlaves
                .SelectMany(group => group.Value)
                .GroupBy(frel => frel.GlobalId)
                .ToDictionary(group => group.Key, group => group.First());




            // foreach featureclass represented in plts_rels, load all destination objects
            var destinationFcToFrels = frels.GroupBy(obj => obj.DEST_FC ?? "Unknown DEST_FC").ToDictionary(group => group.Key, group => group.ToList());

            var loadedRelatedObjectsCount = 0;

            foreach (var destFc in destinationFcToFrels.Keys) {
                var destinationFeatureClassName = source?.GetName(destFc);

                if (destinationFeatureClassName == null) {
                    throw new NotSupportedException("empty featureclass name");
                }
                if (source == null) {
                    throw new NotSupportedException("source geodatabase");
                }


                if (!source.IsFeatureClass(destinationFeatureClassName)) {
                    continue;
                }

                using var relatedFeatureClass = source.OpenDataset<FeatureClass>(destinationFeatureClassName);

                using var cursorRelated = relatedFeatureClass.Search(null, true);

                while (cursorRelated.MoveNext()) {
                    Guid.TryParse(Convert.ToString(cursorRelated.Current["GLOBALID"]), out var currentGlobalId);

                    if (currentGlobalId == Guid.Parse("10C8B63E-9C6F-4A93-9D63-DA268D263E30")) {
                        ; // var t = _srcObjectToSlaves[System.Guid.Parse("37F8BF16-D879-4EB7-B6FA-49B143B320E2")];
                    }

                    if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("aidstonavigationp")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            //idIndex[currentGlobalId].S57Object = new AidsToNavigationP((Feature)cursorRelated.Current);

                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new AidsToNavigationP((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("dangersp")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            //idIndex[currentGlobalId].S57Object = new DangersP((Feature)cursorRelated.Current);
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new DangersP((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("naturalfeaturesa")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            //idIndex[currentGlobalId].S57Object = new NaturalFeaturesA((Feature)cursorRelated.Current);
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new NaturalFeaturesA((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("naturalfeaturesp")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            //idIndex[currentGlobalId].S57Object = new NaturalFeaturesP((Feature)cursorRelated.Current);
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new NaturalFeaturesP((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("naturalfeaturesl")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            //idIndex[currentGlobalId].S57Object = new NaturalFeaturesL((Feature)cursorRelated.Current);
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new NaturalFeaturesL((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("culturalfeaturesp")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            //idIndex[currentGlobalId].S57Object = new CulturalFeaturesP((Feature)cursorRelated.Current);
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new CulturalFeaturesP((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("culturalfeaturesl")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            //idIndex[currentGlobalId].S57Object = new CulturalFeaturesL((Feature)cursorRelated.Current);
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new CulturalFeaturesL((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("culturalfeaturesa")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            //idIndex[currentGlobalId].S57Object = new CulturalFeaturesA((Feature)cursorRelated.Current);
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new CulturalFeaturesA((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("tracksandroutesa")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            //idIndex[currentGlobalId].S57Object = new TracksAndRoutesA((Feature)cursorRelated.Current);
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new TracksAndRoutesA((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("tracksandroutesl")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            // idIndex[currentGlobalId].S57Object = new TracksAndRoutesL((Feature)cursorRelated.Current);
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new TracksAndRoutesL((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("portsandservicesp")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            //idIndex[currentGlobalId].S57Object = new PortsAndServicesP((Feature)cursorRelated.Current);
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new PortsAndServicesP((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("regulatedareasandlimitsp")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            //idIndex[currentGlobalId].S57Object = new RegulatedAreasAndLimitsP((Feature)cursorRelated.Current);
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new RegulatedAreasAndLimitsP((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("userdefinedfeaturesp")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            //idIndex[currentGlobalId].S57Object = new UserDefinedFeaturesP((Feature)cursorRelated.Current);
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new UserDefinedFeaturesP((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("tracksandroutesp")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            //idIndex[currentGlobalId].S57Object = new TracksAndRoutesP((Feature)cursorRelated.Current);
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new TracksAndRoutesP((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("offshoreinstallationsl")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            //idIndex[currentGlobalId].S57Object = new OffshoreInstallationsL((Feature)cursorRelated.Current);
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new OffshoreInstallationsL((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("depthsa")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            //idIndex[currentGlobalId].S57Object = new DepthsA((Feature)cursorRelated.Current);
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new DepthsA((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("portsandservicesl")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            //idIndex[currentGlobalId].S57Object = new PortsAndServicesL((Feature)cursorRelated.Current);
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new PortsAndServicesL((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("dangersa")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            //idIndex[currentGlobalId].S57Object = new DangersA((Feature)cursorRelated.Current);
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new DangersA((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("regulatedareasandlimitsa")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            //idIndex[currentGlobalId].S57Object = new RegulatedAreasAndLimitsA((Feature)cursorRelated.Current);
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new RegulatedAreasAndLimitsA((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("offshoreinstallationsa")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            //idIndex[currentGlobalId].S57Object = new OffshoreInstallationsA((Feature)cursorRelated.Current);
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new OffshoreInstallationsA((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("metadataa")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new MetaDataA((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("portsandservicesa")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            foreach (var kvp in _srcObjectToSlaves) {
                                var key = kvp.Key;
                                var list = kvp.Value;

                                if (list.Any(o => o.GlobalId == currentGlobalId)) {
                                    foreach (var obj in list) {
                                        if (obj.GlobalId == currentGlobalId) {
                                            obj.S57Object = new PortsAndServicesA((Feature)cursorRelated.Current);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else {
                        throw new NotSupportedException($"GetRelated: {destinationFeatureClassName}");
                    }
                }
                ;
            }
            ;
        }

        internal List<Relation> GetRelationsFor(string name) {
            return _relations.Where(o => o.Master!.Name == name).ToList();
        }

        internal bool HasSlaves(Guid globalId) {
            return _srcObjectToSlaves.ContainsKey(globalId);
        }

        internal void AddRelation(S57Master master, S57Slave slave, Feature s101SlaveFeature, Feature s101MasterFeature) {
            //if (_relationCount > 0) {
            //    return;
            //}

            Relation relation = new(master, slave);

            if (this.IsCircular(master, slave)) {
                throw new NotSupportedException($"{relation} is circular. Not permitted.");

            }

            //_relationCount++;
            if (_relations.Contains(relation)) {
                throw new NotSupportedException($"{relation} relation´already added");
            }

            // Legacy - is not in use... to be deleted.
            _relations.Add(relation);

            this.StoreRelation(master, slave, s101SlaveFeature, s101MasterFeature);
        }

        private void StoreRelation(S57Master master, S57Slave slave, Feature s101SlaveFeature, Feature s101MasterFeature) {
            Relation relation = new(master, slave);

            if (relation.Master == null) {
                throw new ArgumentNullException("relation master");
            }
            if (relation.Slave == null) {
                throw new ArgumentNullException("relation slave");
            }

            //Type TPrimary = relation.Master.S101Type;
            //Type TForeign = relation.Slave.S101Type;

            //var featureBindingsPrimary = AttributeModel.S101.FeatureBindings.featureBindingDefinitions(relation.Master.S101Type!.Name);
            //var featureBindingsForeign = AttributeModel.S101.FeatureBindings.featureBindingDefinitions(relation.Slave.S101Type!.Name);


            //featureBindingDefinition? bindingDefinitionForeign;
            //featureBindingDefinition? bindingDefinitionPrimary;

            // Create association
            {
                //bindingDefinitionForeign = featureBindingsPrimary?.FirstOrDefault(fbd => fbd.featureTypes.Contains(TForeign.Name));
                //if (bindingDefinitionForeign == null) {

                //    var tracebackMaster = ConversionAnalytics.Instance.GetTraceBack(relation.Master.Name);
                //    var tracebackMasterString = string.Join(", ", tracebackMaster.Select(tuple => $"{tuple.Item1} - {tuple.Item2}"));
                //    var tracebackSlave = ConversionAnalytics.Instance.GetTraceBack(relation.Slave.Name);
                //    var tracebackSlaveString = string.Join(", ", tracebackSlave.Select(tuple => $"{tuple.Item1} - {tuple.Item2}"));
                //    var msg = $"Cannot relate {relation.Master.GetType().Name} {relation.Master.S101Type.Name} with {relation.Slave.GetType().Name} {relation.Slave.S101Type.Name} - where name in ('{relation.Master.Name}','{relation.Slave.Name}') MASTERS:{tracebackMasterString} SLAVES:{tracebackSlaveString}";
                //    Logger.Current.DataError(-1, "", "relate", msg);
                //    return;
                //    //throw new NotSupportedException(msg);
                //}
            }

            // Store binding
            List<featureBinding> primaryBindings = [];
            List<featureBinding> foreignBindings = [];

            // Create binding
            {
                // Create primary end
                //bindingDefinitionPrimary = featureBindingsPrimary?.FirstOrDefault(fbd => fbd.featureTypes.Contains(TForeign.Name));
                //if (bindingDefinitionPrimary == null) {
                //    throw new NotSupportedException($"no bindingdefinition on {TPrimary.Name} for {TForeign.Name}");
                //}

                //var featureBindingPrimary = (featureBinding)Activator.CreateInstance(DomainModel.S101.Summary.FeatureBindings(bindingDefinitionPrimary.association))!;
                var key = $"{relation.Master.S101Type!.Name}::{relation.Slave.S101Type!.Name}";

                if (featureBindings.ContainsKey(key)) {
                    var featureBindingPrimary = featureBindings[key]();
                    featureBindingPrimary.featureId = relation!.Slave!.Name;
                    //featureBindingPrimary.role = bindingDefinitionPrimary.role;
                    //featureBindingPrimary.roleType = bindingDefinitionPrimary.roleType.ToString();
                    featureBindingPrimary.featureType = relation!.Slave!.S101Type.Name;

                    primaryBindings.Add(featureBindingPrimary);
                }
                else
                    Logger.Current.Error("featureBinding doesn't exist: {key}, master: {master}, slave: {slave}", key, master.Name, slave.Name);
            }
            {
                //TODO: Foreign end
                // Create foreign end
                //bindingDefinitionForeign = featureBindingsForeign?.FirstOrDefault(fbd => fbd.featureTypes.Contains(TPrimary.Name));
                //if (bindingDefinitionForeign == null) {
                //    throw new NotSupportedException($"no bindingdefinition on {TForeign.Name} for {TPrimary.Name}");
                //}

                //var featureBindingForeign = (featureBinding)Activator.CreateInstance(DomainModel.S101.Summary.FeatureBindings(bindingDefinitionForeign.association))!;
                var key = $"{relation.Slave.S101Type!.Name}::{relation.Master.S101Type!.Name}";
                if (featureBindings.ContainsKey(key)) {
                    var featureBindingForeign = featureBindings[key]();
                    featureBindingForeign.featureId = relation!.Master!.Name;
                    //featureBindingForeign.role = bindingDefinitionForeign.role;
                    //featureBindingForeign.roleType = bindingDefinitionForeign.roleType.ToString();
                    featureBindingForeign.featureType = relation!.Master!.S101Type.Name;

                    foreignBindings.Add(featureBindingForeign);
                }
                else
                    Logger.Current.Error("featureBinding doesn't exist: {key}, master: {master}, slave: {slave}", key, master.Name, slave.Name);
            }

            if (s101SlaveFeature["featurebindings"] is null) {
                s101SlaveFeature["featurebindings"] = System.Text.Json.JsonSerializer.Serialize(foreignBindings, ImporterNIS.jsonSerializerOptions);
                s101SlaveFeature.Store();
            }
            else {
                List<featureBinding> existingBinding = System.Text.Json.JsonSerializer.Deserialize<List<featureBinding>>(Convert.ToString(s101SlaveFeature["featurebindings"])!, ImporterNIS.jsonSerializerOptions)!;
                existingBinding.AddRange(foreignBindings);
                s101SlaveFeature["featurebindings"] = System.Text.Json.JsonSerializer.Serialize(existingBinding, ImporterNIS.jsonSerializerOptions);
                s101SlaveFeature.Store();
            }

            if (s101MasterFeature["featurebindings"] is null) {
                s101MasterFeature["featurebindings"] = System.Text.Json.JsonSerializer.Serialize(primaryBindings, ImporterNIS.jsonSerializerOptions);
                s101MasterFeature.Store();
            }
            else {
                List<featureBinding> existingBinding = System.Text.Json.JsonSerializer.Deserialize<List<featureBinding>>(Convert.ToString(s101MasterFeature["featurebindings"])!, ImporterNIS.jsonSerializerOptions)!;
                existingBinding.AddRange(primaryBindings);
                s101MasterFeature["featurebindings"] = System.Text.Json.JsonSerializer.Serialize(existingBinding, ImporterNIS.jsonSerializerOptions);
                s101MasterFeature.Store();
            }
        }

        internal bool IsCircular(S57Master master, S57Slave slave) {
            //if (_relationCount > 0) {
            //    return;
            //}

            S57Master master_ = new(master.S101Type, slave.Name);
            S57Slave slave_ = new(slave.S101Type, master.Name);

            Relation relation = new(master_, slave_);
            //_relationCount++;
            if (_relations.Contains(relation)) {
                return true;
            }
            return false;
        }

        public static Dictionary<string, Func<featureBinding>> featureBindings = new Dictionary<string, Func<featureBinding>> {
            { "QualityOfNonBathymetricData::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "NavigationalSystemOfMarks::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "LocalDirectionOfBuoyage::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "QualityOfBathymetricData::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SoundingDatum::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "VerticalDatumOfData::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "QualityOfSurvey::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "UpdateInformation::UpdateInformation", () => new featureBinding<UpdateAggregation> { role = "theComponent", roleType="association", } },
            { "UpdateInformation::AdministrationArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::AirportAirfield", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::AnchorBerth", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::AnchorageArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::ArchipelagicSeaLane", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::ArchipelagicSeaLaneArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::ArchipelagicSeaLaneAxis", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Berth", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Bollard", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Bridge", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Building", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::BuiltUpArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::CableArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::CableOverhead", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::CableSubmarine", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Canal", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::CardinalBeacon", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::CardinalBuoy", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::CargoTranshipmentArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Causeway", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::CautionArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Checkpoint", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::CoastGuardStation", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Coastline", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::CollisionRegulationsLimit", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::ContiguousZone", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::ContinentalShelfArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Conveyor", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Crane", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::CurrentNonGravitational", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::CustomZone", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Dam", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Daymark", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::DeepWaterRoute", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::DeepWaterRouteCentreline", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::DeepWaterRoutePart", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::DepthArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::DepthContour", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::DepthNoBottomFound", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::DiscolouredWater", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::DistanceMark", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::DockArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Dolphin", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::DredgedArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::DryDock", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::DumpingGround", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Dyke", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::EmergencyWreckMarkingBuoy", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::ExclusiveEconomicZone", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Fairway", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::FairwaySystem", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::FenceWall", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::FerryRoute", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::FisheryZone", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::FishingFacility", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::FishingGround", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::FloatingDock", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::FogSignal", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::FortifiedStructure", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::FoulGround", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::FreePortArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Gate", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Gridiron", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::HarbourAreaAdministrative", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::HarbourFacility", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Helipad", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Hulk", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::IceArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::InformationArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::InshoreTrafficZone", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::InstallationBuoy", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::IslandGroup", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::IsolatedDangerBeacon", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::IsolatedDangerBuoy", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Lake", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::LandArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::LandElevation", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::LandRegion", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Landmark", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::LateralBeacon", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::LateralBuoy", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::LightAirObstruction", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::LightAllAround", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::LightFloat", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::LightFogDetector", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::LightSectored", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::LightVessel", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::LocalDirectionOfBuoyage", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::LocalMagneticAnomaly", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::LockBasin", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::LogPond", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::MagneticVariation", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::MarineFarmCulture", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::MarinePollutionRegulationsArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::MilitaryPracticeArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::MooringArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::MooringBuoy", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::MooringTrot", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::NavigationLine", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::NavigationalSystemOfMarks", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Obstruction", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::OffshorePlatform", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::OffshoreProductionArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::OilBarrier", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::PhysicalAISAidToNavigation", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Pile", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::PilotBoardingPlace", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::PilotageDistrict", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::PipelineOverhead", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::PipelineSubmarineOnLand", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Pontoon", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::PrecautionaryArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::ProductionStorageArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::PylonBridgeSupport", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::QualityOfBathymetricData", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::QualityOfNonBathymetricData", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::QualityOfSurvey", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::RadarLine", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::RadarRange", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::RadarReflector", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::RadarStation", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::RadarTransponderBeacon", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::RadioCallingInPoint", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::RadioStation", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Railway", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::RangeSystem", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Rapids", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::RecommendedRouteCentreline", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::RecommendedTrack", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::RecommendedTrafficLanePart", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::RescueStation", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::RestrictedArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Retroreflector", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::River", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Road", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Runway", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::SafeWaterBeacon", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::SafeWaterBuoy", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Sandwave", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::SeaAreaNamedWaterArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::SeabedArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Seagrass", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::SeaplaneLandingArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::SeparationZoneOrLine", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::ShorelineConstruction", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::SignalStationTraffic", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::SignalStationWarning", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::SiloTank", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::SmallCraftFacility", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::SlopeTopline", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::SlopingGround", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Sounding", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::SoundingDatum", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::SpanFixed", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::SpanOpening", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::SpecialPurposeGeneralBeacon", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::SpecialPurposeGeneralBuoy", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Spring", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::StraightTerritorialSeaBaseline", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::StructureOverNavigableWater", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::SubmarinePipelineArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::SubmarineTransitLane", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::SweptArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::TerritorialSeaArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::TidalStreamPanelData", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::TidalStreamFloodEbb", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Tideway", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::TrafficSeparationScheme", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::TrafficSeparationSchemeBoundary", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::TrafficSeparationSchemeCrossing", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::TrafficSeparationSchemeLanePart", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::TrafficSeparationSchemeRoundabout", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Tunnel", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::TwoWayRoute", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::TwoWayRoutePart", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::UnderwaterAwashRock", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::UnsurveyedArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Vegetation", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::VerticalDatumOfData", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::VesselTrafficServiceArea", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::VirtualAISAidToNavigation", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::WaterTurbulence", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Waterfall", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::WeedKelp", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::WindTurbine", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "UpdateInformation::Wreck", () => new featureBinding<UpdatedInformation> { role = "theUpdatedObject", roleType="association", } },
            { "MagneticVariation::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "LocalMagneticAnomaly::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "LocalMagneticAnomaly::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Coastline::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Coastline::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "LandArea::IslandGroup", () => new featureBinding<IslandAggregation> { role = "theCollection", roleType="aggregation", } },
            { "LandArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "LandArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "IslandGroup::LandArea", () => new featureBinding<IslandAggregation> { role = "theComponent", roleType="association", } },
            { "IslandGroup::IslandGroup", () => new featureBinding<IslandAggregation> { role = "theComponent", roleType="association", } },
            { "IslandGroup::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "IslandGroup::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "LandElevation::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "LandElevation::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "River::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "River::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Rapids::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Rapids::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Waterfall::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Waterfall::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Lake::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Lake::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "LandRegion::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "LandRegion::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Vegetation::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Vegetation::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "IceArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "IceArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "SlopingGround::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SlopingGround::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "SlopeTopline::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SlopeTopline::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Tideway::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Tideway::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "BuiltUpArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "BuiltUpArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Building::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Building::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Building::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Building::Helipad", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Building::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Building::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Building::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Building::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Building::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Building::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Building::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Building::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Building::LightAirObstruction", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Building::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Building::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Building::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Building::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Building::RangeSystem", () => new featureBinding<RangeSystemAggregation> { role = "theCollection", roleType="aggregation", } },
            { "Building::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Building::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "AirportAirfield::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "AirportAirfield::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Runway::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Runway::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Helipad::Building", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Helipad::Landmark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Helipad::OffshorePlatform", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Helipad::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Helipad::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Bridge::SpanFixed", () => new featureBinding<BridgeAggregation> { role = "theComponent", roleType="association", } },
            { "Bridge::SpanOpening", () => new featureBinding<BridgeAggregation> { role = "theComponent", roleType="association", } },
            { "Bridge::Pontoon", () => new featureBinding<BridgeAggregation> { role = "theComponent", roleType="association", } },
            { "Bridge::PylonBridgeSupport", () => new featureBinding<BridgeAggregation> { role = "theComponent", roleType="association", } },
            { "Bridge::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Bridge::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Bridge::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Bridge::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Bridge::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Bridge::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Bridge::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Bridge::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Bridge::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Bridge::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Bridge::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Bridge::LightAirObstruction", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Bridge::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Bridge::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Bridge::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Bridge::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Bridge::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "SpanFixed::Bridge", () => new featureBinding<BridgeAggregation> { role = "theCollection", roleType="aggregation", } },
            { "SpanFixed::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanFixed::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanFixed::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanFixed::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanFixed::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanFixed::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanFixed::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanFixed::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanFixed::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanFixed::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanFixed::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanFixed::LightAirObstruction", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanFixed::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SpanFixed::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SpanFixed::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SpanFixed::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "SpanFixed::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SpanOpening::Bridge", () => new featureBinding<BridgeAggregation> { role = "theCollection", roleType="aggregation", } },
            { "SpanOpening::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanOpening::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanOpening::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanOpening::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanOpening::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanOpening::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanOpening::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanOpening::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanOpening::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanOpening::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanOpening::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanOpening::LightAirObstruction", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpanOpening::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SpanOpening::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SpanOpening::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SpanOpening::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "SpanOpening::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Conveyor::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Conveyor::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Conveyor::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Conveyor::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Conveyor::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Conveyor::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Conveyor::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Conveyor::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Conveyor::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Conveyor::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Conveyor::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Conveyor::LightAirObstruction", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Conveyor::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Conveyor::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Conveyor::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Conveyor::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Conveyor::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "CableOverhead::RadarReflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CableOverhead::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "CableOverhead::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "PipelineOverhead::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PipelineOverhead::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PipelineOverhead::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PipelineOverhead::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PipelineOverhead::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PipelineOverhead::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PipelineOverhead::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PipelineOverhead::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PipelineOverhead::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PipelineOverhead::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PipelineOverhead::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PipelineOverhead::RadarReflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PipelineOverhead::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "PipelineOverhead::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "PipelineOverhead::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "PipelineOverhead::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "PipelineOverhead::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "PylonBridgeSupport::Bridge", () => new featureBinding<BridgeAggregation> { role = "theCollection", roleType="aggregation", } },
            { "PylonBridgeSupport::StructureOverNavigableWater", () => new featureBinding<RoofedStructureAggregation> { role = "theRoofedStructure", roleType="aggregation", } },
            { "PylonBridgeSupport::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PylonBridgeSupport::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PylonBridgeSupport::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PylonBridgeSupport::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PylonBridgeSupport::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PylonBridgeSupport::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PylonBridgeSupport::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PylonBridgeSupport::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PylonBridgeSupport::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PylonBridgeSupport::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PylonBridgeSupport::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PylonBridgeSupport::Bollard", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PylonBridgeSupport::LightAirObstruction", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "PylonBridgeSupport::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "PylonBridgeSupport::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "PylonBridgeSupport::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "PylonBridgeSupport::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "PylonBridgeSupport::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "FenceWall::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "FenceWall::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Railway::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Railway::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Road::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Road::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Tunnel::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Tunnel::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Landmark::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Landmark::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Landmark::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Landmark::Helipad", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Landmark::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Landmark::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Landmark::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Landmark::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Landmark::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Landmark::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Landmark::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Landmark::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Landmark::Bollard", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Landmark::LightAirObstruction", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Landmark::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Landmark::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Landmark::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Landmark::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Landmark::RangeSystem", () => new featureBinding<RangeSystemAggregation> { role = "theCollection", roleType="aggregation", } },
            { "Landmark::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "Landmark::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Landmark::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "SiloTank::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SiloTank::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SiloTank::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SiloTank::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SiloTank::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SiloTank::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SiloTank::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SiloTank::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SiloTank::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SiloTank::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SiloTank::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SiloTank::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SiloTank::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SiloTank::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SiloTank::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SiloTank::RangeSystem", () => new featureBinding<RangeSystemAggregation> { role = "theCollection", roleType="aggregation", } },
            { "SiloTank::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SiloTank::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "WindTurbine::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "WindTurbine::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "WindTurbine::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "WindTurbine::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "WindTurbine::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "WindTurbine::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "WindTurbine::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "WindTurbine::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "WindTurbine::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "WindTurbine::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "WindTurbine::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "WindTurbine::LightAirObstruction", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "WindTurbine::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "WindTurbine::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "WindTurbine::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "WindTurbine::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "WindTurbine::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "WindTurbine::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "FortifiedStructure::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FortifiedStructure::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FortifiedStructure::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FortifiedStructure::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FortifiedStructure::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FortifiedStructure::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FortifiedStructure::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FortifiedStructure::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FortifiedStructure::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FortifiedStructure::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FortifiedStructure::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FortifiedStructure::Bollard", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FortifiedStructure::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "FortifiedStructure::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "FortifiedStructure::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "FortifiedStructure::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "FortifiedStructure::RangeSystem", () => new featureBinding<RangeSystemAggregation> { role = "theCollection", roleType="aggregation", } },
            { "FortifiedStructure::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "FortifiedStructure::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "ProductionStorageArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "ProductionStorageArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Checkpoint::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Checkpoint::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Hulk::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Hulk::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Hulk::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Hulk::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Hulk::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Hulk::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Hulk::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Hulk::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Hulk::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Hulk::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Hulk::Bollard", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Hulk::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Hulk::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Hulk::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Hulk::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Hulk::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Pile::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pile::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pile::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pile::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pile::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pile::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pile::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pile::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pile::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pile::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pile::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pile::Bollard", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pile::ArchipelagicSeaLane", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Pile::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Pile::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Pile::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Pile::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Pile::RangeSystem", () => new featureBinding<RangeSystemAggregation> { role = "theCollection", roleType="aggregation", } },
            { "Pile::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "Pile::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Pile::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Dyke::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Dyke::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "ShorelineConstruction::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "ShorelineConstruction::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "ShorelineConstruction::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "ShorelineConstruction::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "ShorelineConstruction::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "ShorelineConstruction::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "ShorelineConstruction::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "ShorelineConstruction::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "ShorelineConstruction::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "ShorelineConstruction::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "ShorelineConstruction::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "ShorelineConstruction::Bollard", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "ShorelineConstruction::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "ShorelineConstruction::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "ShorelineConstruction::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "ShorelineConstruction::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "ShorelineConstruction::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "StructureOverNavigableWater::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "StructureOverNavigableWater::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "StructureOverNavigableWater::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "StructureOverNavigableWater::PylonBridgeSupport", () => new featureBinding<RoofedStructureAggregation> { role = "theSupport", roleType="association", } },
            { "StructureOverNavigableWater::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "StructureOverNavigableWater::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "StructureOverNavigableWater::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "StructureOverNavigableWater::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "StructureOverNavigableWater::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "StructureOverNavigableWater::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "StructureOverNavigableWater::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "StructureOverNavigableWater::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "StructureOverNavigableWater::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "StructureOverNavigableWater::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "StructureOverNavigableWater::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "StructureOverNavigableWater::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "StructureOverNavigableWater::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Causeway::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Causeway::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Canal::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Canal::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "DistanceMark::Bridge", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::Building", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::Crane", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::CardinalBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::CardinalBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::Conveyor", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::Dolphin", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::EmergencyWreckMarkingBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::FishingFacility", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::FloatingDock", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::FortifiedStructure", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::Hulk", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::InstallationBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::IsolatedDangerBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::IsolatedDangerBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::Landmark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::LateralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::LateralBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::LightFloat", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::LightVessel", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::MooringBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::OffshorePlatform", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::Pile", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::PipelineOverhead", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::Pontoon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::PylonBridgeSupport", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::SafeWaterBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::SafeWaterBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::ShorelineConstruction", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::SiloTank", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::SpanFixed", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::SpanOpening", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::SpecialPurposeGeneralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::SpecialPurposeGeneralBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::StructureOverNavigableWater", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::WindTurbine", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::Wreck", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::Daymark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "DistanceMark::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "DistanceMark::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Gate::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Gate::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Dam::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Dam::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Crane::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Crane::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Crane::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Crane::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Crane::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Crane::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Crane::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Crane::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Crane::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Crane::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Crane::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Crane::LightAirObstruction", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Crane::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Crane::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Crane::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Crane::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Crane::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Crane::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Berth::MooringTrot", () => new featureBinding<MooringTrotAggregation> { role = "theCollection", roleType="aggregation", } },
            { "Berth::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Berth::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Dolphin::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Dolphin::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Dolphin::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Dolphin::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Dolphin::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Dolphin::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Dolphin::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Dolphin::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Dolphin::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Dolphin::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Dolphin::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Dolphin::Bollard", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Dolphin::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Dolphin::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Dolphin::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Dolphin::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Dolphin::RangeSystem", () => new featureBinding<RangeSystemAggregation> { role = "theCollection", roleType="aggregation", } },
            { "Dolphin::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Dolphin::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Bollard::Dolphin", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Bollard::FortifiedStructure", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Bollard::Hulk", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Bollard::Landmark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Bollard::OffshorePlatform", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Bollard::Pile", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Bollard::PylonBridgeSupport", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Bollard::ShorelineConstruction", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Bollard::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Bollard::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "DryDock::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "DryDock::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "FloatingDock::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FloatingDock::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FloatingDock::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FloatingDock::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FloatingDock::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FloatingDock::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FloatingDock::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FloatingDock::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FloatingDock::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FloatingDock::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FloatingDock::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "FloatingDock::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "FloatingDock::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "FloatingDock::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "FloatingDock::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Pontoon::Bridge", () => new featureBinding<BridgeAggregation> { role = "theCollection", roleType="aggregation", } },
            { "Pontoon::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pontoon::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pontoon::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pontoon::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pontoon::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pontoon::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pontoon::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pontoon::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pontoon::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pontoon::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Pontoon::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Pontoon::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Pontoon::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Pontoon::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Pontoon::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "DockArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "DockArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Gridiron::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Gridiron::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "LockBasin::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "LockBasin::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "MooringTrot::Berth", () => new featureBinding<MooringTrotAggregation> { role = "theComponent", roleType="association", } },
            { "MooringTrot::CableSubmarine", () => new featureBinding<MooringTrotAggregation> { role = "theComponent", roleType="association", } },
            { "MooringTrot::MooringBuoy", () => new featureBinding<MooringTrotAggregation> { role = "theComponent", roleType="association", } },
            { "MooringTrot::Obstruction", () => new featureBinding<MooringTrotAggregation> { role = "theComponent", roleType="association", } },
            { "MooringTrot::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "MooringTrot::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "SeaAreaNamedWaterArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SeaAreaNamedWaterArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "TidalStreamFloodEbb::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "TidalStreamFloodEbb::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "CurrentNonGravitational::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "CurrentNonGravitational::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "WaterTurbulence::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "WaterTurbulence::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "TidalStreamPanelData::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "TidalStreamPanelData::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Sounding::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Sounding::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "DredgedArea::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "DredgedArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "DredgedArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "SweptArea::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "SweptArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SweptArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "DepthContour::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "DepthArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "DepthNoBottomFound::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "UnsurveyedArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SeabedArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SeabedArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "WeedKelp::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "WeedKelp::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Seagrass::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Seagrass::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Sandwave::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Spring::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Spring::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "UnderwaterAwashRock::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "UnderwaterAwashRock::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Wreck::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Wreck::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Wreck::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Wreck::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Wreck::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Wreck::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Wreck::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Wreck::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Wreck::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Wreck::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Wreck::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Wreck::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Wreck::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Obstruction::MooringTrot", () => new featureBinding<MooringTrotAggregation> { role = "theCollection", roleType="aggregation", } },
            { "Obstruction::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Obstruction::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "FoulGround::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "FoulGround::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "DiscolouredWater::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "FishingFacility::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FishingFacility::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FishingFacility::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FishingFacility::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FishingFacility::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FishingFacility::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FishingFacility::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FishingFacility::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FishingFacility::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FishingFacility::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FishingFacility::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "FishingFacility::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "FishingFacility::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "FishingFacility::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "FishingFacility::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "FishingFacility::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "FishingFacility::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "MarineFarmCulture::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "MarineFarmCulture::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "OffshorePlatform::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "OffshorePlatform::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "OffshorePlatform::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "OffshorePlatform::Helipad", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "OffshorePlatform::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "OffshorePlatform::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "OffshorePlatform::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "OffshorePlatform::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "OffshorePlatform::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "OffshorePlatform::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "OffshorePlatform::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "OffshorePlatform::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "OffshorePlatform::Bollard", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "OffshorePlatform::LightAirObstruction", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "OffshorePlatform::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "OffshorePlatform::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "OffshorePlatform::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "OffshorePlatform::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "OffshorePlatform::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "OffshorePlatform::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "CableSubmarine::MooringTrot", () => new featureBinding<MooringTrotAggregation> { role = "theCollection", roleType="aggregation", } },
            { "CableSubmarine::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "CableSubmarine::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "CableArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "CableArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "PipelineSubmarineOnLand::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "PipelineSubmarineOnLand::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "SubmarinePipelineArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SubmarinePipelineArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "OffshoreProductionArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "OffshoreProductionArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "NavigationLine::RangeSystem", () => new featureBinding<RangeSystemAggregation> { role = "theCollection", roleType="aggregation", } },
            { "NavigationLine::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "RecommendedTrack::RangeSystem", () => new featureBinding<RangeSystemAggregation> { role = "theCollection", roleType="aggregation", } },
            { "RecommendedTrack::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "RecommendedTrack::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "RecommendedTrack::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "RangeSystem::CardinalBeacon", () => new featureBinding<RangeSystemAggregation> { role = "theComponent", roleType="association", } },
            { "RangeSystem::Building", () => new featureBinding<RangeSystemAggregation> { role = "theComponent", roleType="association", } },
            { "RangeSystem::Daymark", () => new featureBinding<RangeSystemAggregation> { role = "theComponent", roleType="association", } },
            { "RangeSystem::Dolphin", () => new featureBinding<RangeSystemAggregation> { role = "theComponent", roleType="association", } },
            { "RangeSystem::FortifiedStructure", () => new featureBinding<RangeSystemAggregation> { role = "theComponent", roleType="association", } },
            { "RangeSystem::IsolatedDangerBeacon", () => new featureBinding<RangeSystemAggregation> { role = "theComponent", roleType="association", } },
            { "RangeSystem::Landmark", () => new featureBinding<RangeSystemAggregation> { role = "theComponent", roleType="association", } },
            { "RangeSystem::LateralBeacon", () => new featureBinding<RangeSystemAggregation> { role = "theComponent", roleType="association", } },
            { "RangeSystem::LightAllAround", () => new featureBinding<RangeSystemAggregation> { role = "theComponent", roleType="association", } },
            { "RangeSystem::LightSectored", () => new featureBinding<RangeSystemAggregation> { role = "theComponent", roleType="association", } },
            { "RangeSystem::NavigationLine", () => new featureBinding<RangeSystemAggregation> { role = "theComponent", roleType="association", } },
            { "RangeSystem::Pile", () => new featureBinding<RangeSystemAggregation> { role = "theComponent", roleType="association", } },
            { "RangeSystem::RadarTransponderBeacon", () => new featureBinding<RangeSystemAggregation> { role = "theComponent", roleType="association", } },
            { "RangeSystem::RangeSystem", () => new featureBinding<RangeSystemAggregation> { role = "theComponent", roleType="association", } },
            { "RangeSystem::RecommendedRouteCentreline", () => new featureBinding<RangeSystemAggregation> { role = "theComponent", roleType="association", } },
            { "RangeSystem::RecommendedTrack", () => new featureBinding<RangeSystemAggregation> { role = "theComponent", roleType="association", } },
            { "RangeSystem::SafeWaterBeacon", () => new featureBinding<RangeSystemAggregation> { role = "theComponent", roleType="association", } },
            { "RangeSystem::SiloTank", () => new featureBinding<RangeSystemAggregation> { role = "theComponent", roleType="association", } },
            { "RangeSystem::SpecialPurposeGeneralBeacon", () => new featureBinding<RangeSystemAggregation> { role = "theComponent", roleType="association", } },
            { "RangeSystem::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "RangeSystem::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "RangeSystem::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Fairway::FairwaySystem", () => new featureBinding<FairwayAggregation> { role = "theCollection", roleType="aggregation", } },
            { "Fairway::CardinalBeacon", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::CardinalBuoy", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::CautionArea", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::Daymark", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::DredgedArea", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::IsolatedDangerBeacon", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::IsolatedDangerBuoy", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::LateralBeacon", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::LateralBuoy", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::LightFloat", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::LightVessel", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::Landmark", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::Pile", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::RangeSystem", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::RecommendedRouteCentreline", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::RecommendedTrack", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::RestrictedArea", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::SafeWaterBeacon", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::SafeWaterBuoy", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::SpecialPurposeGeneralBeacon", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::SpecialPurposeGeneralBuoy", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::SweptArea", () => new featureBinding<FairwayAuxiliary> { role = "theAuxiliaryFeature", roleType="association", } },
            { "Fairway::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Fairway::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "FairwaySystem::CardinalBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::CardinalBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::Daymark", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::EmergencyWreckMarkingBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::IsolatedDangerBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::IsolatedDangerBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::LateralBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::LateralBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::LightFloat", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::LightVessel", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::Pile", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::SafeWaterBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::SafeWaterBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::SpecialPurposeGeneralBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::SpecialPurposeGeneralBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::Building", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::Crane", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::Dolphin", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::FishingFacility", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::FortifiedStructure", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::Landmark", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::MooringBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::OffshorePlatform", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::SiloTank", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::WindTurbine", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::Bridge", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::Conveyor", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::FloatingDock", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::Hulk", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::PipelineOverhead", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::Pontoon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::PylonBridgeSupport", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::ShorelineConstruction", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::SpanFixed", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::SpanOpening", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::StructureOverNavigableWater", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::Fairway", () => new featureBinding<FairwayAggregation> { role = "theComponent", roleType="association", } },
            { "FairwaySystem::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "FairwaySystem::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "RecommendedRouteCentreline::RangeSystem", () => new featureBinding<RangeSystemAggregation> { role = "theCollection", roleType="aggregation", } },
            { "RecommendedRouteCentreline::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "RecommendedRouteCentreline::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "RecommendedRouteCentreline::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "TwoWayRoutePart::TwoWayRoute", () => new featureBinding<TwoWayRouteAggregation> { role = "theCollection", roleType="aggregation", } },
            { "TwoWayRoutePart::TrafficSeparationScheme", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theCollection", roleType="aggregation", } },
            { "TwoWayRoutePart::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "TwoWayRoute::CardinalBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::CardinalBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::Daymark", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::EmergencyWreckMarkingBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::IsolatedDangerBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::IsolatedDangerBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::LateralBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::LateralBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::LightFloat", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::LightVessel", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::Pile", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::SafeWaterBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::SafeWaterBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::SpecialPurposeGeneralBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::SpecialPurposeGeneralBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::Building", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::Crane", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::Dolphin", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::FishingFacility", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::FortifiedStructure", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::Landmark", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::MooringBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::OffshorePlatform", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::SiloTank", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::WindTurbine", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::Bridge", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::Conveyor", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::FloatingDock", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::Hulk", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::PipelineOverhead", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::Pontoon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::PylonBridgeSupport", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::ShorelineConstruction", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::SpanFixed", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::SpanOpening", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::StructureOverNavigableWater", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::TwoWayRoutePart", () => new featureBinding<TwoWayRouteAggregation> { role = "theComponent", roleType="association", } },
            { "TwoWayRoute::TrafficSeparationScheme", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theCollection", roleType="aggregation", } },
            { "TwoWayRoute::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "TwoWayRoute::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "RecommendedTrafficLanePart::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "DeepWaterRouteCentreline::DeepWaterRoute", () => new featureBinding<DeepWaterRouteAggregation> { role = "theCollection", roleType="aggregation", } },
            { "DeepWaterRouteCentreline::TrafficSeparationScheme", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theCollection", roleType="aggregation", } },
            { "DeepWaterRouteCentreline::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "DeepWaterRouteCentreline::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "DeepWaterRoutePart::DeepWaterRoute", () => new featureBinding<DeepWaterRouteAggregation> { role = "theCollection", roleType="aggregation", } },
            { "DeepWaterRoutePart::TrafficSeparationScheme", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theCollection", roleType="aggregation", } },
            { "DeepWaterRoutePart::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "DeepWaterRoutePart::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "DeepWaterRoute::CardinalBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::CardinalBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::Daymark", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::EmergencyWreckMarkingBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::IsolatedDangerBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::IsolatedDangerBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::LateralBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::LateralBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::LightFloat", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::LightVessel", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::Pile", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::SafeWaterBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::SafeWaterBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::SpecialPurposeGeneralBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::SpecialPurposeGeneralBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::Building", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::Crane", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::Dolphin", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::FishingFacility", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::FortifiedStructure", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::Landmark", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::MooringBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::OffshorePlatform", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::SiloTank", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::WindTurbine", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::DeepWaterRouteCentreline", () => new featureBinding<DeepWaterRouteAggregation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::DeepWaterRoutePart", () => new featureBinding<DeepWaterRouteAggregation> { role = "theComponent", roleType="association", } },
            { "DeepWaterRoute::TrafficSeparationScheme", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theCollection", roleType="aggregation", } },
            { "DeepWaterRoute::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "DeepWaterRoute::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "InshoreTrafficZone::TrafficSeparationScheme", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theCollection", roleType="aggregation", } },
            { "InshoreTrafficZone::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "PrecautionaryArea::TrafficSeparationScheme", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theCollection", roleType="aggregation", } },
            { "PrecautionaryArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "PrecautionaryArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "TrafficSeparationSchemeLanePart::TrafficSeparationScheme", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theCollection", roleType="aggregation", } },
            { "TrafficSeparationSchemeLanePart::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SeparationZoneOrLine::TrafficSeparationScheme", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theCollection", roleType="aggregation", } },
            { "SeparationZoneOrLine::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "TrafficSeparationSchemeBoundary::TrafficSeparationScheme", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theCollection", roleType="aggregation", } },
            { "TrafficSeparationSchemeBoundary::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "TrafficSeparationSchemeCrossing::TrafficSeparationScheme", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theCollection", roleType="aggregation", } },
            { "TrafficSeparationSchemeCrossing::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "TrafficSeparationSchemeRoundabout::TrafficSeparationScheme", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theCollection", roleType="aggregation", } },
            { "TrafficSeparationSchemeRoundabout::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "TrafficSeparationScheme::CardinalBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::CardinalBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::Daymark", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::EmergencyWreckMarkingBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::IsolatedDangerBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::IsolatedDangerBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::LateralBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::LateralBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::LightFloat", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::LightVessel", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::Pile", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::SafeWaterBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::SafeWaterBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::SpecialPurposeGeneralBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::SpecialPurposeGeneralBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::Building", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::Crane", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::Dolphin", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::FishingFacility", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::FortifiedStructure", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::Landmark", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::MooringBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::OffshorePlatform", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::SiloTank", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::WindTurbine", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::Bridge", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::Conveyor", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::FloatingDock", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::Hulk", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::PipelineOverhead", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::Pontoon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::PylonBridgeSupport", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::ShorelineConstruction", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::SpanFixed", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::SpanOpening", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::StructureOverNavigableWater", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::DeepWaterRoute", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::DeepWaterRouteCentreline", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::DeepWaterRoutePart", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::InshoreTrafficZone", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::PrecautionaryArea", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::RestrictedArea", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::SeparationZoneOrLine", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::TrafficSeparationScheme", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::TrafficSeparationSchemeBoundary", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::TrafficSeparationSchemeCrossing", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::TrafficSeparationSchemeLanePart", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::TrafficSeparationSchemeRoundabout", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::TwoWayRoute", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::TwoWayRoutePart", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theComponent", roleType="association", } },
            { "TrafficSeparationScheme::CautionArea", () => new featureBinding<CautionAreaAssociation> { role = "theCollection", roleType="aggregation", } },
            { "TrafficSeparationScheme::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "TrafficSeparationScheme::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "ArchipelagicSeaLaneArea::ArchipelagicSeaLane", () => new featureBinding<ASLAggregation> { role = "theCollection", roleType="aggregation", } },
            { "ArchipelagicSeaLaneArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "ArchipelagicSeaLaneArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "ArchipelagicSeaLaneAxis::ArchipelagicSeaLane", () => new featureBinding<ASLAggregation> { role = "theCollection", roleType="aggregation", } },
            { "ArchipelagicSeaLaneAxis::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "ArchipelagicSeaLaneAxis::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "ArchipelagicSeaLane::CardinalBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "ArchipelagicSeaLane::CardinalBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "ArchipelagicSeaLane::Daymark", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "ArchipelagicSeaLane::EmergencyWreckMarkingBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "ArchipelagicSeaLane::IsolatedDangerBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "ArchipelagicSeaLane::IsolatedDangerBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "ArchipelagicSeaLane::LateralBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "ArchipelagicSeaLane::LateralBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "ArchipelagicSeaLane::LightFloat", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "ArchipelagicSeaLane::LightVessel", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "ArchipelagicSeaLane::Pile", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "ArchipelagicSeaLane::SafeWaterBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "ArchipelagicSeaLane::SafeWaterBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "ArchipelagicSeaLane::SpecialPurposeGeneralBeacon", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "ArchipelagicSeaLane::SpecialPurposeGeneralBuoy", () => new featureBinding<AidsToNavigationAssociation> { role = "theComponent", roleType="association", } },
            { "ArchipelagicSeaLane::ArchipelagicSeaLaneArea", () => new featureBinding<ASLAggregation> { role = "theComponent", roleType="association", } },
            { "ArchipelagicSeaLane::ArchipelagicSeaLaneAxis", () => new featureBinding<ASLAggregation> { role = "theComponent", roleType="association", } },
            { "ArchipelagicSeaLane::CautionArea", () => new featureBinding<CautionAreaAssociation> { role = "theCollection", roleType="aggregation", } },
            { "ArchipelagicSeaLane::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "ArchipelagicSeaLane::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "RadioCallingInPoint::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "RadioCallingInPoint::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "FerryRoute::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "FerryRoute::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "RadarLine::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "RadarLine::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "RadarRange::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "RadarRange::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "RadarStation::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "RadarStation::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "AnchorageArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "AnchorageArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "MooringArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "MooringArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "AnchorBerth::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "AnchorBerth::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "SeaplaneLandingArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SeaplaneLandingArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "DumpingGround::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "DumpingGround::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "MilitaryPracticeArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "MilitaryPracticeArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "AdministrationArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "AdministrationArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "CargoTranshipmentArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "CargoTranshipmentArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "CautionArea::ArchipelagicSeaLane", () => new featureBinding<CautionAreaAssociation> { role = "theComponent", roleType="association", } },
            { "CautionArea::TrafficSeparationScheme", () => new featureBinding<CautionAreaAssociation> { role = "theComponent", roleType="association", } },
            { "CautionArea::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "CautionArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "InformationArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "InformationArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "ContiguousZone::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "ContinentalShelfArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "ContinentalShelfArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "CustomZone::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "ExclusiveEconomicZone::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "FisheryZone::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "FisheryZone::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "FishingGround::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "FishingGround::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "FreePortArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "FreePortArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "HarbourAreaAdministrative::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "HarbourAreaAdministrative::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "LogPond::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "LogPond::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "OilBarrier::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "OilBarrier::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "StraightTerritorialSeaBaseline::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "TerritorialSeaArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SubmarineTransitLane::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SubmarineTransitLane::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "PilotageDistrict::PilotBoardingPlace", () => new featureBinding<PilotageDistrictAssociation> { role = "theComponent", roleType="association", } },
            { "PilotageDistrict::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "PilotageDistrict::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "CollisionRegulationsLimit::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "CollisionRegulationsLimit::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "MarinePollutionRegulationsArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "MarinePollutionRegulationsArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "RestrictedArea::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "RestrictedArea::TrafficSeparationScheme", () => new featureBinding<TrafficSeparationSchemeAggregation> { role = "theCollection", roleType="aggregation", } },
            { "RestrictedArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "RestrictedArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "LightAllAround::Bridge", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::Building", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::Crane", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::CardinalBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::CardinalBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::Conveyor", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::Dolphin", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::EmergencyWreckMarkingBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::FishingFacility", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::FloatingDock", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::FortifiedStructure", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::Hulk", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::InstallationBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::IsolatedDangerBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::IsolatedDangerBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::Landmark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::LateralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::LateralBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::LightFloat", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::LightVessel", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::MooringBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::OffshorePlatform", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::Pile", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::PipelineOverhead", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::Pontoon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::PylonBridgeSupport", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::SafeWaterBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::SafeWaterBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::ShorelineConstruction", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::SiloTank", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::SpanFixed", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::SpanOpening", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::SpecialPurposeGeneralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::SpecialPurposeGeneralBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::StructureOverNavigableWater", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::WindTurbine", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::Wreck", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::LightSectored", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::Daymark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAllAround::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightAllAround::LightAirObstruction", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightAllAround::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightAllAround::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightAllAround::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightAllAround::RangeSystem", () => new featureBinding<RangeSystemAggregation> { role = "theCollection", roleType="aggregation", } },
            { "LightAllAround::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "LightAllAround::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "LightSectored::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightSectored::LightAirObstruction", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightSectored::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightSectored::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightSectored::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightSectored::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightSectored::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightSectored::Bridge", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::Building", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::Crane", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::CardinalBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::Conveyor", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::Dolphin", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::FishingFacility", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::FortifiedStructure", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::IsolatedDangerBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::Landmark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::LateralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::OffshorePlatform", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::Pile", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::PipelineOverhead", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::PylonBridgeSupport", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::SafeWaterBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::ShorelineConstruction", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::SiloTank", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::SpanFixed", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::SpanOpening", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::SpecialPurposeGeneralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::StructureOverNavigableWater", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::WindTurbine", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::Wreck", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::Daymark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightSectored::RangeSystem", () => new featureBinding<RangeSystemAggregation> { role = "theCollection", roleType="aggregation", } },
            { "LightSectored::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "LightSectored::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "LightFogDetector::Bridge", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::Building", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::Crane", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::CardinalBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::CardinalBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::Conveyor", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::Dolphin", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::EmergencyWreckMarkingBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::FishingFacility", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::FloatingDock", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::FortifiedStructure", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::Hulk", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::InstallationBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::IsolatedDangerBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::IsolatedDangerBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::Landmark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::LateralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::LateralBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::LightFloat", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::LightVessel", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::MooringBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::OffshorePlatform", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::Pile", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::PipelineOverhead", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::Pontoon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::PylonBridgeSupport", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::SafeWaterBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::SafeWaterBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::ShorelineConstruction", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::SiloTank", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::SpanFixed", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::SpanOpening", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::SpecialPurposeGeneralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::SpecialPurposeGeneralBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::StructureOverNavigableWater", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::WindTurbine", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::Wreck", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::LightSectored", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::Daymark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightFogDetector::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "LightFogDetector::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "LightAirObstruction::Bridge", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAirObstruction::Building", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAirObstruction::Crane", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAirObstruction::Conveyor", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAirObstruction::Landmark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAirObstruction::OffshorePlatform", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAirObstruction::PylonBridgeSupport", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAirObstruction::SpanFixed", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAirObstruction::SpanOpening", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAirObstruction::WindTurbine", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAirObstruction::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAirObstruction::LightSectored", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "LightAirObstruction::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "LightAirObstruction::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "LateralBuoy::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBuoy::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBuoy::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBuoy::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBuoy::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBuoy::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBuoy::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBuoy::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBuoy::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBuoy::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBuoy::ArchipelagicSeaLane", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "LateralBuoy::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "LateralBuoy::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "LateralBuoy::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "LateralBuoy::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "LateralBuoy::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "LateralBuoy::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "LateralBuoy::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "CardinalBuoy::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBuoy::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBuoy::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBuoy::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBuoy::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBuoy::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBuoy::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBuoy::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBuoy::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBuoy::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBuoy::ArchipelagicSeaLane", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "CardinalBuoy::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "CardinalBuoy::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "CardinalBuoy::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "CardinalBuoy::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "CardinalBuoy::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "CardinalBuoy::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "CardinalBuoy::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "IsolatedDangerBuoy::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBuoy::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBuoy::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBuoy::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBuoy::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBuoy::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBuoy::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBuoy::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBuoy::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBuoy::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBuoy::ArchipelagicSeaLane", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "IsolatedDangerBuoy::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "IsolatedDangerBuoy::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "IsolatedDangerBuoy::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "IsolatedDangerBuoy::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "IsolatedDangerBuoy::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "IsolatedDangerBuoy::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "IsolatedDangerBuoy::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "SafeWaterBuoy::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBuoy::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBuoy::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBuoy::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBuoy::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBuoy::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBuoy::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBuoy::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBuoy::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBuoy::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBuoy::ArchipelagicSeaLane", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SafeWaterBuoy::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SafeWaterBuoy::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SafeWaterBuoy::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SafeWaterBuoy::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SafeWaterBuoy::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "SafeWaterBuoy::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SafeWaterBuoy::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "SpecialPurposeGeneralBuoy::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBuoy::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBuoy::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBuoy::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBuoy::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBuoy::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBuoy::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBuoy::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBuoy::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBuoy::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBuoy::ArchipelagicSeaLane", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SpecialPurposeGeneralBuoy::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SpecialPurposeGeneralBuoy::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SpecialPurposeGeneralBuoy::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SpecialPurposeGeneralBuoy::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SpecialPurposeGeneralBuoy::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "SpecialPurposeGeneralBuoy::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SpecialPurposeGeneralBuoy::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "EmergencyWreckMarkingBuoy::ArchipelagicSeaLane", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "EmergencyWreckMarkingBuoy::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "EmergencyWreckMarkingBuoy::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "EmergencyWreckMarkingBuoy::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "EmergencyWreckMarkingBuoy::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "EmergencyWreckMarkingBuoy::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "EmergencyWreckMarkingBuoy::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "EmergencyWreckMarkingBuoy::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "EmergencyWreckMarkingBuoy::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "EmergencyWreckMarkingBuoy::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "EmergencyWreckMarkingBuoy::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "EmergencyWreckMarkingBuoy::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "EmergencyWreckMarkingBuoy::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "EmergencyWreckMarkingBuoy::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "EmergencyWreckMarkingBuoy::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "EmergencyWreckMarkingBuoy::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "EmergencyWreckMarkingBuoy::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "InstallationBuoy::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "InstallationBuoy::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "InstallationBuoy::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "InstallationBuoy::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "InstallationBuoy::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "InstallationBuoy::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "InstallationBuoy::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "InstallationBuoy::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "InstallationBuoy::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "InstallationBuoy::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "InstallationBuoy::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "InstallationBuoy::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "MooringBuoy::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "MooringBuoy::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "MooringBuoy::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "MooringBuoy::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "MooringBuoy::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "MooringBuoy::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "MooringBuoy::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "MooringBuoy::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "MooringBuoy::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "MooringBuoy::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "MooringBuoy::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "MooringBuoy::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "MooringBuoy::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "MooringBuoy::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "MooringBuoy::MooringTrot", () => new featureBinding<MooringTrotAggregation> { role = "theCollection", roleType="aggregation", } },
            { "MooringBuoy::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "MooringBuoy::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "LateralBeacon::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBeacon::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBeacon::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBeacon::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBeacon::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBeacon::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBeacon::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBeacon::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBeacon::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBeacon::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBeacon::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LateralBeacon::ArchipelagicSeaLane", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "LateralBeacon::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "LateralBeacon::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "LateralBeacon::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "LateralBeacon::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "LateralBeacon::RangeSystem", () => new featureBinding<RangeSystemAggregation> { role = "theCollection", roleType="aggregation", } },
            { "LateralBeacon::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "LateralBeacon::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "LateralBeacon::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "CardinalBeacon::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBeacon::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBeacon::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBeacon::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBeacon::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBeacon::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBeacon::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBeacon::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBeacon::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBeacon::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBeacon::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "CardinalBeacon::ArchipelagicSeaLane", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "CardinalBeacon::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "CardinalBeacon::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "CardinalBeacon::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "CardinalBeacon::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "CardinalBeacon::RangeSystem", () => new featureBinding<RangeSystemAggregation> { role = "theCollection", roleType="aggregation", } },
            { "CardinalBeacon::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "CardinalBeacon::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "CardinalBeacon::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "IsolatedDangerBeacon::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBeacon::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBeacon::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBeacon::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBeacon::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBeacon::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBeacon::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBeacon::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBeacon::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBeacon::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBeacon::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "IsolatedDangerBeacon::ArchipelagicSeaLane", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "IsolatedDangerBeacon::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "IsolatedDangerBeacon::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "IsolatedDangerBeacon::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "IsolatedDangerBeacon::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "IsolatedDangerBeacon::RangeSystem", () => new featureBinding<RangeSystemAggregation> { role = "theCollection", roleType="aggregation", } },
            { "IsolatedDangerBeacon::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "IsolatedDangerBeacon::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "IsolatedDangerBeacon::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "SafeWaterBeacon::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBeacon::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBeacon::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBeacon::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBeacon::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBeacon::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBeacon::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBeacon::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBeacon::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBeacon::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBeacon::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SafeWaterBeacon::ArchipelagicSeaLane", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SafeWaterBeacon::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SafeWaterBeacon::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SafeWaterBeacon::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SafeWaterBeacon::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SafeWaterBeacon::RangeSystem", () => new featureBinding<RangeSystemAggregation> { role = "theCollection", roleType="aggregation", } },
            { "SafeWaterBeacon::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "SafeWaterBeacon::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SafeWaterBeacon::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "SpecialPurposeGeneralBeacon::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBeacon::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBeacon::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBeacon::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBeacon::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBeacon::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBeacon::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBeacon::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBeacon::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBeacon::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBeacon::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "SpecialPurposeGeneralBeacon::ArchipelagicSeaLane", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SpecialPurposeGeneralBeacon::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SpecialPurposeGeneralBeacon::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SpecialPurposeGeneralBeacon::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SpecialPurposeGeneralBeacon::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "SpecialPurposeGeneralBeacon::RangeSystem", () => new featureBinding<RangeSystemAggregation> { role = "theCollection", roleType="aggregation", } },
            { "SpecialPurposeGeneralBeacon::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "SpecialPurposeGeneralBeacon::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SpecialPurposeGeneralBeacon::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Daymark::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Daymark::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Daymark::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Daymark::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Daymark::LightSectored", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Daymark::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Daymark::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Daymark::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Daymark::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Daymark::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "Daymark::Bridge", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::Building", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::Crane", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::CardinalBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::CardinalBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::Conveyor", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::Dolphin", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::EmergencyWreckMarkingBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::FishingFacility", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::FloatingDock", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::FortifiedStructure", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::Hulk", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::InstallationBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::IsolatedDangerBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::IsolatedDangerBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::Landmark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::LateralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::LateralBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::LightFloat", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::LightVessel", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::MooringBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::OffshorePlatform", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::Pile", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::PipelineOverhead", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::Pontoon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::PylonBridgeSupport", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::SafeWaterBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::SafeWaterBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::ShorelineConstruction", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::SiloTank", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::SpanFixed", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::SpanOpening", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::SpecialPurposeGeneralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::SpecialPurposeGeneralBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::StructureOverNavigableWater", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::WindTurbine", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::Wreck", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Daymark::ArchipelagicSeaLane", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Daymark::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Daymark::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Daymark::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Daymark::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "Daymark::RangeSystem", () => new featureBinding<RangeSystemAggregation> { role = "theCollection", roleType="aggregation", } },
            { "Daymark::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "Daymark::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "Daymark::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "LightFloat::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightFloat::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightFloat::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightFloat::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightFloat::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightFloat::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightFloat::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightFloat::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightFloat::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightFloat::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightFloat::ArchipelagicSeaLane", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "LightFloat::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "LightFloat::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "LightFloat::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "LightFloat::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "LightFloat::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "LightFloat::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "LightFloat::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "LightVessel::Daymark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightVessel::DistanceMark", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightVessel::FogSignal", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightVessel::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightVessel::LightFogDetector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightVessel::PhysicalAISAidToNavigation", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightVessel::RadarTransponderBeacon", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightVessel::Retroreflector", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightVessel::SignalStationTraffic", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightVessel::SignalStationWarning", () => new featureBinding<StructureEquipment> { role = "theEquipment", roleType="association", } },
            { "LightVessel::ArchipelagicSeaLane", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "LightVessel::DeepWaterRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "LightVessel::FairwaySystem", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "LightVessel::TrafficSeparationScheme", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "LightVessel::TwoWayRoute", () => new featureBinding<AidsToNavigationAssociation> { role = "theCollection", roleType="aggregation", } },
            { "LightVessel::Fairway", () => new featureBinding<FairwayAuxiliary> { role = "thePrimaryFeature", roleType="aggregation", } },
            { "LightVessel::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "LightVessel::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "Retroreflector::Bridge", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::Building", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::Crane", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::CardinalBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::CardinalBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::Conveyor", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::Dolphin", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::EmergencyWreckMarkingBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::FishingFacility", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::FloatingDock", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::FortifiedStructure", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::Hulk", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::InstallationBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::IsolatedDangerBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::IsolatedDangerBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::Landmark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::LateralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::LateralBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::LightFloat", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::LightVessel", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::MooringBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::OffshorePlatform", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::Pile", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::PipelineOverhead", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::Pontoon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::PylonBridgeSupport", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::SafeWaterBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::SafeWaterBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::ShorelineConstruction", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::SiloTank", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::SpanFixed", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::SpanOpening", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::SpecialPurposeGeneralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::SpecialPurposeGeneralBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::StructureOverNavigableWater", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::WindTurbine", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::Wreck", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::LightSectored", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::Daymark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "Retroreflector::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "RadarReflector::CableOverhead", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarReflector::PipelineOverhead", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarReflector::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "FogSignal::Bridge", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::Building", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::Crane", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::CardinalBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::CardinalBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::Conveyor", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::Dolphin", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::EmergencyWreckMarkingBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::FishingFacility", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::FloatingDock", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::FortifiedStructure", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::Hulk", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::InstallationBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::IsolatedDangerBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::IsolatedDangerBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::Landmark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::LateralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::LateralBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::LightFloat", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::LightVessel", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::MooringBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::OffshorePlatform", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::Pile", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::PipelineOverhead", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::Pontoon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::PylonBridgeSupport", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::SafeWaterBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::SafeWaterBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::ShorelineConstruction", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::SiloTank", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::SpanFixed", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::SpanOpening", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::SpecialPurposeGeneralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::SpecialPurposeGeneralBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::StructureOverNavigableWater", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::WindTurbine", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::Wreck", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::LightSectored", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::Daymark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "FogSignal::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "FogSignal::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "PhysicalAISAidToNavigation::Bridge", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::Building", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::Crane", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::CardinalBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::CardinalBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::Conveyor", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::Dolphin", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::EmergencyWreckMarkingBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::FishingFacility", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::FloatingDock", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::FortifiedStructure", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::Hulk", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::InstallationBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::IsolatedDangerBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::IsolatedDangerBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::Landmark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::LateralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::LateralBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::LightFloat", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::LightVessel", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::MooringBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::OffshorePlatform", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::Pile", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::PipelineOverhead", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::Pontoon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::PylonBridgeSupport", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::SafeWaterBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::SafeWaterBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::ShorelineConstruction", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::SiloTank", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::SpanFixed", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::SpanOpening", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::SpecialPurposeGeneralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::SpecialPurposeGeneralBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::StructureOverNavigableWater", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::WindTurbine", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::Wreck", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::Daymark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "PhysicalAISAidToNavigation::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "PhysicalAISAidToNavigation::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "VirtualAISAidToNavigation::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "VirtualAISAidToNavigation::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "RadioStation::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "RadioStation::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "RadarTransponderBeacon::Bridge", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::Building", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::Crane", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::CardinalBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::CardinalBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::Conveyor", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::Dolphin", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::EmergencyWreckMarkingBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::FishingFacility", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::FloatingDock", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::FortifiedStructure", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::Hulk", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::InstallationBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::IsolatedDangerBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::IsolatedDangerBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::Landmark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::LateralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::LateralBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::LightFloat", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::LightVessel", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::MooringBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::OffshorePlatform", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::Pile", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::PipelineOverhead", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::Pontoon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::PylonBridgeSupport", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::SafeWaterBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::SafeWaterBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::ShorelineConstruction", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::SiloTank", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::SpanFixed", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::SpanOpening", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::SpecialPurposeGeneralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::SpecialPurposeGeneralBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::StructureOverNavigableWater", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::WindTurbine", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::Wreck", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::LightAllAround", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::LightSectored", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::Daymark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "RadarTransponderBeacon::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "RadarTransponderBeacon::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "RadarTransponderBeacon::RangeSystem", () => new featureBinding<RangeSystemAggregation> { role = "theCollection", roleType="aggregation", } },
            { "PilotBoardingPlace::PilotageDistrict", () => new featureBinding<PilotageDistrictAssociation> { role = "theCollection", roleType="aggregation", } },
            { "PilotBoardingPlace::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "PilotBoardingPlace::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "VesselTrafficServiceArea::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "VesselTrafficServiceArea::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "CoastGuardStation::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "CoastGuardStation::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "SignalStationWarning::Bridge", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::Building", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::Crane", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::CardinalBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::CardinalBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::Conveyor", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::Dolphin", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::EmergencyWreckMarkingBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::FishingFacility", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::FloatingDock", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::FortifiedStructure", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::Hulk", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::InstallationBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::IsolatedDangerBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::IsolatedDangerBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::Landmark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::LateralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::LateralBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::LightFloat", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::LightVessel", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::MooringBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::OffshorePlatform", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::Pile", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::PipelineOverhead", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::Pontoon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::PylonBridgeSupport", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::SafeWaterBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::SafeWaterBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::ShorelineConstruction", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::SiloTank", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::SpanFixed", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::SpanOpening", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::SpecialPurposeGeneralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::SpecialPurposeGeneralBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::StructureOverNavigableWater", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::WindTurbine", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::Wreck", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::Daymark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationWarning::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SignalStationWarning::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "SignalStationTraffic::Bridge", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::Building", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::Crane", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::CardinalBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::CardinalBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::Conveyor", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::Dolphin", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::EmergencyWreckMarkingBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::FishingFacility", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::FloatingDock", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::FortifiedStructure", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::Hulk", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::InstallationBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::IsolatedDangerBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::IsolatedDangerBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::Landmark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::LateralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::LateralBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::LightFloat", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::LightVessel", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::MooringBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::OffshorePlatform", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::Pile", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::PipelineOverhead", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::Pontoon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::PylonBridgeSupport", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::SafeWaterBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::SafeWaterBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::ShorelineConstruction", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::SiloTank", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::SpanFixed", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::SpanOpening", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::SpecialPurposeGeneralBeacon", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::SpecialPurposeGeneralBuoy", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::StructureOverNavigableWater", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::WindTurbine", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::Wreck", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::Daymark", () => new featureBinding<StructureEquipment> { role = "theStructure", roleType="composition", } },
            { "SignalStationTraffic::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SignalStationTraffic::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "RescueStation::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "RescueStation::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "HarbourFacility::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "HarbourFacility::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "SmallCraftFacility::UpdateInformation", () => new featureBinding<UpdatedInformation> { role = "theUpdate", roleType="association", } },
            { "SmallCraftFacility::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
            { "TextPlacement::AdministrationArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::AirportAirfield", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::AnchorBerth", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::AnchorageArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::ArchipelagicSeaLane", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::ArchipelagicSeaLaneArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::ArchipelagicSeaLaneAxis", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Berth", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Bollard", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Bridge", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Building", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::BuiltUpArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::CableArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::CableOverhead", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::CableSubmarine", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Canal", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::CardinalBuoy", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::CardinalBeacon", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::CargoTranshipmentArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Causeway", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Chart1Feature", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Checkpoint", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::CoastGuardStation", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Coastline", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::CollisionRegulationsLimit", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::ContinentalShelfArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Conveyor", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Crane", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::CurrentNonGravitational", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Dam", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Daymark", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::DeepWaterRoute", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::DeepWaterRouteCentreline", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::DeepWaterRoutePart", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::DistanceMark", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::DockArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Dolphin", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::DredgedArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::DryDock", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::DumpingGround", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Dyke", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::EmergencyWreckMarkingBuoy", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Fairway", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::FairwaySystem", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::FenceWall", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::FerryRoute", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::FisheryZone", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::FishingFacility", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::FishingGround", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::FloatingDock", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::FogSignal", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::FortifiedStructure", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::FoulGround", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::FreePortArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Gate", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Gridiron", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::HarbourAreaAdministrative", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::HarbourFacility", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Helipad", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Hulk", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::IceArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::InformationArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::InstallationBuoy", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::IslandGroup", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::IsolatedDangerBeacon", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::IsolatedDangerBuoy", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Lake", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::LandArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::LandElevation", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::LandRegion", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Landmark", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::LateralBeacon", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::LateralBuoy", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::LightAirObstruction", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::LightAllAround", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::LightFloat", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::LightFogDetector", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::LightSectored", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::LightVessel", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::LocalMagneticAnomaly", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::LockBasin", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::LogPond", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::MarineFarmCulture", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::MarinePollutionRegulationsArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::MilitaryPracticeArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::MooringArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::MooringBuoy", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::MooringTrot", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Obstruction", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::OffshorePlatform", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::OffshoreProductionArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::OilBarrier", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::PhysicalAISAidToNavigation", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Pile", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::PilotBoardingPlace", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::PilotageDistrict", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::PipelineOverhead", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::PipelineSubmarineOnLand", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Pontoon", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::PrecautionaryArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::ProductionStorageArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::PylonBridgeSupport", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::RadarLine", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::RadarRange", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::RadarStation", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::RadarTransponderBeacon", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::RadioCallingInPoint", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::RadioStation", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Railway", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::RangeSystem", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Rapids", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::RecommendedRouteCentreline", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::RecommendedTrack", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::RescueStation", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::RestrictedArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::River", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Road", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Runway", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::SafeWaterBeacon", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::SafeWaterBuoy", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::SeaAreaNamedWaterArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::SeabedArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Seagrass", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::SeaplaneLandingArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::ShorelineConstruction", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::SignalStationTraffic", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::SignalStationWarning", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::SiloTank", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::SlopeTopline", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::SlopingGround", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::SmallCraftFacility", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Sounding", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::SpanFixed", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::SpanOpening", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::SpecialPurposeGeneralBeacon", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::SpecialPurposeGeneralBuoy", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Spring", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::StructureOverNavigableWater", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::SubmarinePipelineArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::SubmarineTransitLane", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::SweptArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::TidalStreamFloodEbb", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::TidalStreamPanelData", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Tideway", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::TrafficSeparationScheme", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Tunnel", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::TwoWayRoute", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::UnderwaterAwashRock", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Vegetation", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::VesselTrafficServiceArea", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::VirtualAISAidToNavigation", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::WaterTurbulence", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Waterfall", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::WeedKelp", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::WindTurbine", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "TextPlacement::Wreck", () => new featureBinding<TextAssociation> { role = "thePositionProvider", roleType="composition", } },
            { "Chart1Feature::TextPlacement", () => new featureBinding<TextAssociation> { role = "theCartographicText", roleType="association", } },
        };
#if null
        //internal void AddAssociation(S57Master master, S57Slave slave) {

        //}
        //public class TemplateFactory
        //{
        //    public T CreateEmptyInstance<T>() where T : new() {
        //        return new T();
        //    }
        //}

        internal void CreateRelation(Relation relation, Table featureAssociation, RowBuffer featureAssociationBuffer, Table associationBinding, RowBuffer associationBindingBuffer) {
            if (relation.Master == null) {
                throw new ArgumentNullException("relation master");
            }
            if (relation.Slave == null) {
                throw new ArgumentNullException("relation slave");
            }

            Type TPrimary = relation.Master.S101Type;
            Type TForeign = relation.Slave.S101Type;

            var featureBindingsPrimary = TPrimary?.GetProperty("featureBindingDefinitions")?.GetValue(null) as featureBindingDefinition[];
            var featureBindingsForeign = TForeign?.GetProperty("featureBindingDefinitions")?.GetValue(null) as featureBindingDefinition[];

            string featureAssociationName;
            featureBindingDefinition? bindingDefinitionForeign;
            featureBindingDefinition? bindingDefinitionPrimary;

            {
                // Create the association
                bindingDefinitionForeign = featureBindingsPrimary?.FirstOrDefault(fbd => fbd.featureTypes.Contains(TForeign?.Name));
                if (bindingDefinitionForeign == null) {

                    var tracebackMaster = ConversionAnalytics.Instance.GetTraceBack(relation.Master.Name);
                    var tracebackMasterString = string.Join(", ", tracebackMaster.Select(tuple => $"{tuple.Item1} - {tuple.Item2}"));
                    var tracebackSlave = ConversionAnalytics.Instance.GetTraceBack(relation.Slave.Name);
                    var tracebackSlaveString = string.Join(", ", tracebackSlave.Select(tuple => $"{tuple.Item1} - {tuple.Item2}"));
                    var msg = $"Cannot relate {relation.Master.GetType().Name} {relation.Master.S101Type.Name} with {relation.Slave.GetType().Name} {relation.Slave.S101Type.Name} - where name in ('{relation.Master.Name}','{relation.Slave.Name}') MASTERS:{tracebackMasterString} SLAVES:{tracebackSlaveString}";
                    Logger.Current.DataError(-1, "", "relate", msg);
                    return;
                    //throw new NotSupportedException(msg);
                }
                featureAssociationBuffer["ps"] = ImporterNIS.ps101;
                featureAssociationBuffer["code"] = bindingDefinitionForeign.association;
                var association = featureAssociation.CreateRow(featureAssociationBuffer);
                featureAssociationName = $"{association.Crc32()}";

            }
            {
                // Create primary end
                bindingDefinitionPrimary = featureBindingsPrimary?.FirstOrDefault(fbd => fbd.featureTypes.Contains(TForeign?.Name));
                if (bindingDefinitionPrimary == null) {
                    throw new NotSupportedException($"no bindingdefinition on {TPrimary?.Name} for {TForeign?.Name}");
                }
                associationBindingBuffer["ps"] = ImporterNIS.ps101;
                associationBindingBuffer["roleType"] = bindingDefinitionPrimary.roleType.ToString();
                associationBindingBuffer["associationId"] = featureAssociationName;
                associationBindingBuffer["association"] = bindingDefinitionPrimary.association;
                associationBindingBuffer["primaryid"] = relation?.Master?.Name;
                associationBindingBuffer["foreignid"] = relation?.Slave?.Name;
                associationBindingBuffer["role"] = bindingDefinitionPrimary.role;
                associationBindingBuffer["type"] = "FeatureBinding";
                var association = associationBinding.CreateRow(associationBindingBuffer);
                //_createdRelations.Add((relation?.Master?.Name, relation?.Slave?.Name), relation);
            }
            {
                // Create foreign end
                bindingDefinitionForeign = featureBindingsForeign?.FirstOrDefault(fbd => fbd.featureTypes.Contains(TPrimary?.Name));
                if (bindingDefinitionForeign == null) {
                    throw new NotSupportedException($"no bindingdefinition on {TForeign?.Name} for {TPrimary?.Name}");
                }
                associationBindingBuffer["ps"] = ImporterNIS.ps101;
                associationBindingBuffer["roleType"] = bindingDefinitionForeign.roleType.ToString();
                associationBindingBuffer["associationId"] = featureAssociationName;
                associationBindingBuffer["association"] = bindingDefinitionForeign.association;
                associationBindingBuffer["primaryid"] = relation?.Slave?.Name;
                associationBindingBuffer["foreignid"] = relation?.Master?.Name;
                associationBindingBuffer["role"] = bindingDefinitionForeign.role;
                associationBindingBuffer["type"] = "FeatureBinding";
                var association = associationBinding.CreateRow(associationBindingBuffer);
                //_createdRelations.Add((relation?.Slave?.Name, relation?.Master?.Name), relation);

            }
        }

        internal void CreateRelations(Geodatabase target) {
            throw new NotSupportedException("Featurebindings are created on the fly now...");

            if (target == default) {
                throw new NotSupportedException("Target is null");
            }

            using var featureAssociation = target.OpenDataset<Table>(target.GetName("featureassociation"));
            using var associationBinding = target.OpenDataset<Table>(target.GetName("associationbinding"));
            using var featureAssociationBuffer = featureAssociation.CreateRowBuffer();

            using var associationBindingBuffer = associationBinding.CreateRowBuffer();
            

            var duplicates = _relations
                .GroupBy(p => new { p = p.Master.Name, s = p.Slave.Name })
                .Where(g => g.Count() > 1)
                .SelectMany(g => g)
                .ToList();

            foreach (var relation in _relations) {
                if (relation == null) {
                    throw new NotSupportedException("null relation");
                }

                CreateRelation(relation, featureAssociation, featureAssociationBuffer, associationBinding, associationBindingBuffer);
#endif
#if null
                if (relation?.Master?.Type.ToLower() == typeof(LateralBuoy).Name.ToLower()) {
                    if (relation?.Slave?.Type.ToLower() == typeof(Daymark).Name.ToLower()) {
                        CreateRelation<LateralBuoy, Daymark>(relation, featureAssociation, featureAssociationBuffer, associationBinding, associationBindingBuffer);
                    }
                    else if (relation?.Slave?.Type.ToLower() == typeof(DistanceMark).Name.ToLower()) {
                        CreateRelation<LateralBuoy, DistanceMark>(relation, featureAssociation, featureAssociationBuffer, associationBinding, associationBindingBuffer);
                    }
                    else if (relation?.Slave?.Type.ToLower() == typeof(FogSignal).Name.ToLower()) {
                        CreateRelation<LateralBuoy, FogSignal>(relation, featureAssociation, featureAssociationBuffer, associationBinding, associationBindingBuffer);
                    }
                    else if (relation?.Slave?.Type.ToLower() == typeof(LightAllAround).Name.ToLower()) {
                        CreateRelation<LateralBuoy,LightAllAround>(relation,featureAssociation,featureAssociationBuffer,associationBinding,associationBindingBuffer);
                    }
                    else if (relation?.Slave?.Type.ToLower() == typeof(LightFogDetector).Name.ToLower()) {
                        CreateRelation<LateralBuoy, LightFogDetector>(relation, featureAssociation, featureAssociationBuffer, associationBinding, associationBindingBuffer);
                    }
                    else if (relation?.Slave?.Type.ToLower() == typeof(PhysicalAISAidToNavigation).Name.ToLower()) {
                        CreateRelation<LateralBuoy, PhysicalAISAidToNavigation>(relation, featureAssociation, featureAssociationBuffer, associationBinding, associationBindingBuffer);
                    }
                    else if (relation?.Slave?.Type.ToLower() == typeof(RadarTransponderBeacon).Name.ToLower()) {
                        CreateRelation<LateralBuoy, RadarTransponderBeacon>(relation, featureAssociation, featureAssociationBuffer, associationBinding, associationBindingBuffer);
                    }
                    else if (relation?.Slave?.Type.ToLower() == typeof(Retroreflector).Name.ToLower()) {
                        CreateRelation<LateralBuoy, Retroreflector>(relation, featureAssociation, featureAssociationBuffer, associationBinding, associationBindingBuffer);
                    }
                    else if (relation?.Slave?.Type.ToLower() == typeof(SignalStationTraffic).Name.ToLower()) {
                        CreateRelation<LateralBuoy, SignalStationTraffic>(relation, featureAssociation, featureAssociationBuffer, associationBinding, associationBindingBuffer);
                    }
                    else if (relation?.Slave?.Type.ToLower() == typeof(SignalStationWarning).Name.ToLower()) {
                        CreateRelation<LateralBuoy, SignalStationWarning>(relation, featureAssociation, featureAssociationBuffer, associationBinding, associationBindingBuffer);
                    }
                }
#endif
#if null

    }
        }
#endif
    }

    internal class S57Master : IEquatable<S57Master>
    {
        Type _s101type;
        string _s101name;

        public S57Master(Type type, string name) {
            this._s101type = type;
            this._s101name = name;
        }

        public Type S101Type { get => this._s101type; set => this._s101type = value; }
        public string Name { get => this._s101name; set => this._s101name = value; }

        // Implement IEquatable<MyObject>
        public bool Equals(S57Master? other) {
            if (other == null) {
                return false;
            }
            return this._s101type.Equals(other._s101type) && this._s101name.Equals(other._s101name);
        }

        // Override Equals (for compatibility with collections like HashSet)
        public override bool Equals(object? obj) {
            if (obj is Relation other) {
                return this.Equals(other); // Use the correct Equals method
            }
            return false;
        }

        public override int GetHashCode() {
            return HashCode.Combine(this._s101type, this._s101name);
        }
    }
    internal class S57Slave : IEquatable<S57Slave>
    {
        Type _s101type;
        string _s101name;

        internal S57Slave(Type type, string name) {
            this._s101type = type;
            this._s101name = name;
        }

        public Type S101Type { get => this._s101type; set => this._s101type = value; }
        public string Name { get => this._s101name; set => this._s101name = value; }

        // Implement IEquatable<MyObject>
        public bool Equals(S57Slave? other) {
            if (other == null) {
                return false;
            }
            return this._s101type.Equals(other._s101type) && this._s101name.Equals(other._s101name);
        }

        // Override Equals (for compatibility with collections like HashSet)
        public override bool Equals(object? obj) {
            if (obj is Relation other) {
                return this.Equals(other); // Use the correct Equals method
            }
            return false;
        }

        public override int GetHashCode() {
            return HashCode.Combine(this._s101type, this._s101name);
        }
    }

    internal class Relation : IEquatable<Relation>
    {

        S57Master? _master;
        S57Slave? _slave;
        bool _stored = false;

        public Relation(S57Master master, S57Slave slave) {
            this.Master = master;
            this.Slave = slave;
        }

        internal S57Master? Master { get => this._master; set => this._master = value; }
        internal S57Slave? Slave { get => this._slave; set => this._slave = value; }
        internal bool Stored { get => this._stored; set => this._stored = value; }

        // Implement IEquatable<MyObject>
        public bool Equals(Relation? other) {
            if (other == null) {
                return false;
            }
            return this._master!.Equals(other._master) && this._slave!.Equals(other._slave);
        }

        // Override Equals (for compatibility with collections like HashSet)
        public override bool Equals(object? obj) {
            if (obj is Relation other) {
                return this.Equals(other); // Use the correct Equals method
            }
            return false;
        }

        public override int GetHashCode() {
            return HashCode.Combine(this._master, this._slave);
        }
    }
}
