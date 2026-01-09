using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel;
using S100Framework.AttributeModel.S101.ComplexAttributes;
using S100Framework.AttributeModel.S101.FeatureTypes;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using S100Framework.AttributeModel;

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
        private List<PltsSlave> _related;

        private PLTS_Collections _plts_collections;

        Geodatabase? _source;

        public PltsCollection(Geodatabase source, PLTS_Collections plts_collections) {
            _plts_collections = plts_collections;
            _related = new();
            _source = source;
        }

        internal void AddRelated(PLTS_Frel plts_frel) {
            _related.Add(new PltsSlave(plts_frel));
        }
    }

    internal class PltsSlave
    {
        private S57Object? s57Object = null;

        public PLTS_Frel PLTS_Frel { get; internal set; }

        public S57Object? S57Object {
            get => s57Object;

            internal set {

                s57Object = value;

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
        private static HashSet<Relation> _relations = new HashSet<Relation>();
        private static Dictionary<Guid, PltsCollection> _pltsCollections = new Dictionary<Guid, PltsCollection>();
        private static Dictionary<Guid, IList<PltsSlave>> _srcObjectToSlaves = new Dictionary<Guid, IList<PltsSlave>>();
        private static Dictionary<string, PLTS_Master_Slaves> _pltsMasterSlaves = new Dictionary<string, PLTS_Master_Slaves>();

        private static Dictionary<(string, string), Relation> _createdRelations = new Dictionary<(string, string), Relation>();

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
            _pltsCollections = new Dictionary<Guid, PltsCollection>();
            _srcObjectToSlaves = new Dictionary<Guid, IList<PltsSlave>>();
            _pltsMasterSlaves = new Dictionary<string, PLTS_Master_Slaves>();

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

            List<int> catlits = new();

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
                        _srcObjectToSlaves[uid] = new List<PltsSlave>() { new PltsSlave(plts_frel) };
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

        internal void AddRelation(S57Master master, S57Slave slave, Feature s101SlaveFeature, Feature s101MasterFeature, featureBinding featureBindingPrimary, featureBinding featureBindingForeign) {
            //if (_relationCount > 0) {
            //    return;
            //}

            Relation relation = new(master, slave);

            if (IsCircular(master, slave)) {
                throw new NotSupportedException($"{relation} is circular. Not permitted.");

            }

            //_relationCount++;
            if (_relations.Contains(relation)) {
                throw new NotSupportedException($"{relation} relation´already added");
            }

            // Legacy - is not in use... to be deleted.
            _relations.Add(relation);

            StoreRelation(master, slave, s101SlaveFeature, s101MasterFeature, featureBindingPrimary, featureBindingForeign);
        }

        private void StoreRelation(S57Master master, S57Slave slave, Feature s101SlaveFeature, Feature s101MasterFeature, featureBinding featureBindingPrimary, featureBinding featureBindingForeign) {
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
            List<featureBinding> primaryBindings = new List<featureBinding>();
            List<featureBinding> foreignBindings = new List<featureBinding>();

            // Create binding
            {
                // Create primary end
                //bindingDefinitionPrimary = featureBindingsPrimary?.FirstOrDefault(fbd => fbd.featureTypes.Contains(TForeign.Name));
                //if (bindingDefinitionPrimary == null) {
                //    throw new NotSupportedException($"no bindingdefinition on {TPrimary.Name} for {TForeign.Name}");
                //}

                //var featureBindingPrimary = (featureBinding)Activator.CreateInstance(DomainModel.S101.Summary.FeatureBindings(bindingDefinitionPrimary.association))!;
                featureBindingPrimary.featureId = relation!.Slave!.Name;
                //featureBindingPrimary.role = bindingDefinitionPrimary.role;
                //featureBindingPrimary.roleType = bindingDefinitionPrimary.roleType.ToString();
                featureBindingPrimary.featureType = relation!.Slave!.S101Type.Name;

                primaryBindings.Add(featureBindingPrimary);
            }
            {
                //TODO: Foreign end
                // Create foreign end
                //bindingDefinitionForeign = featureBindingsForeign?.FirstOrDefault(fbd => fbd.featureTypes.Contains(TPrimary.Name));
                //if (bindingDefinitionForeign == null) {
                //    throw new NotSupportedException($"no bindingdefinition on {TForeign.Name} for {TPrimary.Name}");
                //}

                //var featureBindingForeign = (featureBinding)Activator.CreateInstance(DomainModel.S101.Summary.FeatureBindings(bindingDefinitionForeign.association))!;
                featureBindingForeign.featureId = relation!.Master!.Name;
                //featureBindingForeign.role = bindingDefinitionForeign.role;
                //featureBindingForeign.roleType = bindingDefinitionForeign.roleType.ToString();
                featureBindingForeign.featureType = relation!.Master!.S101Type.Name;

                foreignBindings.Add(featureBindingForeign);
            }

            if (s101SlaveFeature["featurebindings"] is null) {
                s101SlaveFeature["featurebindings"] = System.Text.Json.JsonSerializer.Serialize(foreignBindings, ImporterNIS.jsonFeatureTypeSerializerOptions);
                s101SlaveFeature.Store();
            } else {
                List<featureBinding> existingBinding = System.Text.Json.JsonSerializer.Deserialize<List<featureBinding>>(Convert.ToString(s101SlaveFeature["featurebindings"])!, ImporterNIS.jsonFeatureTypeSerializerOptions)!;
                existingBinding.AddRange(foreignBindings);
                s101SlaveFeature["featurebindings"] = System.Text.Json.JsonSerializer.Serialize(existingBinding, ImporterNIS.jsonFeatureTypeSerializerOptions);
                s101SlaveFeature.Store();
            }

            if (s101MasterFeature["featurebindings"] is null) {
                s101MasterFeature["featurebindings"] = System.Text.Json.JsonSerializer.Serialize(primaryBindings, ImporterNIS.jsonFeatureTypeSerializerOptions);
                s101MasterFeature.Store();
            }
            else {
                List<featureBinding> existingBinding = System.Text.Json.JsonSerializer.Deserialize<List<featureBinding>>(Convert.ToString(s101MasterFeature["featurebindings"])!, ImporterNIS.jsonFeatureTypeSerializerOptions)!;
                existingBinding.AddRange(primaryBindings);
                s101MasterFeature["featurebindings"] = System.Text.Json.JsonSerializer.Serialize(existingBinding, ImporterNIS.jsonFeatureTypeSerializerOptions);
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
                return Equals(other); // Use the correct Equals method
            }
            return false;
        }

        public override int GetHashCode() {
            return HashCode.Combine(_s101type, _s101name);
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
                return Equals(other); // Use the correct Equals method
            }
            return false;
        }

        public override int GetHashCode() {
            return HashCode.Combine(_s101type, _s101name);
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
                return Equals(other); // Use the correct Equals method
            }
            return false;
        }

        public override int GetHashCode() {
            return HashCode.Combine(_master, _slave);
        }
    }
}
