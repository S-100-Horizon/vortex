using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.FeatureTypes;
using System.Data;


namespace S100Framework.Applications
{

    internal enum Direction {
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

    internal class PltsCollection {
        private List<PltsSlave> _related;

        PLTS_Collections _plts_collections;

        Geodatabase _source;

        public PltsCollection(Geodatabase source, PLTS_Collections plts_collections) {
            _plts_collections = plts_collections;
            _related = new();
            _source = source;
        }

        internal void AddRelated(PLTS_Frel plts_frel) {
            _related.Add(new PltsSlave(plts_frel));
        }
    }

    internal class PltsSlave {
        private S57Object s57Object;

        public PLTS_Frel PLTS_Frel { get; internal set; }

        public S57Object S57Object {
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
                        this.S101Type = FeatureRelations.GetS101CatlitTypeFrom(aton);
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
                        throw new NotSupportedException($"AtoN subtype: {aton.FCSUBTYPE}");
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
                        throw new NotSupportedException($"AtoN subtype: {psp.FCSUBTYPE}");
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
                        throw new NotSupportedException($"AtoN subtype: {psp.FCSUBTYPE}");
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
                        throw new NotSupportedException($"AtoN subtype: {psp.FCSUBTYPE}");
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
                        throw new NotSupportedException($"AtoN subtype: {psp.FCSUBTYPE}");
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
                        throw new NotSupportedException($"AtoN subtype: {psp.FCSUBTYPE}");
                    }
                }
                else {
                    throw new NotSupportedException($"AtoN subtype: {s57Obj.GetType()}");
                }

            }
        }

        public Type S101Type { get; private set; }
    


        public Guid GlobalId { get; private set; }

        public PltsSlave(PLTS_Frel plts_Frel) {
            this.PLTS_Frel = plts_Frel;
            Guid uid;

            if (Guid.TryParse(plts_Frel.DEST_UID, out uid)) {
                this.GlobalId = uid;
            }

            //Logger.Current.Debug($"Fetching related {plts_Frel.DEST_FC}");
            //this.Fetch(source,Direction.Destination);


        }

        private void Fetch(Geodatabase geodatabase, Direction direction) {
            S57Object result = null;

            var sourceFeatureClass = direction switch {
                Direction.Source => this.PLTS_Frel.SRC_FC,
                Direction.Destination => this.PLTS_Frel.DEST_FC
            };

            var queryDef = new QueryDef();
            queryDef.Tables = $"{geodatabase.GetName(sourceFeatureClass)}";

            queryDef.WhereClause = $"globalid = '{this.PLTS_Frel.DEST_UID}'";

            using var cursor = geodatabase.Evaluate(queryDef, true);

            while (cursor.MoveNext()) {
                if (sourceFeatureClass.ToLower().Equals("aidstonavigationp")) {
                    result = new AidsToNavigationP((Feature)cursor.Current);
                }
                else if (sourceFeatureClass.ToLower().Equals("dangersp")) {
                    result = new DangersP((Feature)cursor.Current);
                }
                else if (sourceFeatureClass.ToLower().Equals("naturalfeaturesa")) {
                    result = new NaturalFeaturesA((Feature)cursor.Current);
                }
                else if (sourceFeatureClass.ToLower().Equals("tracksandroutesa")) {
                    result = new TracksAndRoutesA((Feature)cursor.Current);
                }
                else if (sourceFeatureClass.ToLower().Equals("tracksandroutesl")) {
                    result = new TracksAndRoutesL((Feature)cursor.Current);
                }
                else if (sourceFeatureClass.ToLower().Equals("portsandservicesp")) {
                    result = new PortsAndServicesP((Feature)cursor.Current);
                }
                else {
                    throw new NotSupportedException($"GetRelated: {sourceFeatureClass}");
                }
            };
            this.S57Object = result;
        }
    }

    internal class FeatureRelations
    {
        private Dictionary<Guid, PltsCollection> _pltsCollections = new Dictionary<Guid, PltsCollection>();

        private Dictionary<Guid, IList<PltsSlave>> _srcObjectToSlaves = new Dictionary<Guid, IList<PltsSlave>>();

        private bool _isInitialized = false;

        private Geodatabase _source;

        public void Initialize(Geodatabase source) {
            _pltsCollections = new Dictionary<Guid, PltsCollection>();
            _srcObjectToSlaves = new Dictionary<Guid, IList<PltsSlave>>();
            _source = source;
            LoadPltsCollections();
            LoadPltsFrels2(source);
            _isInitialized = true;
        }


        private void LoadPltsCollections() {

            // Read aggregations
            var pltsCollectionsTable = _source.OpenDataset<Table>(_source.GetName("PLTS_COLLECTIONS"));
            var pltsCollections = new Dictionary<Guid, IList<PLTS_Collections>>();

            var cursor = pltsCollectionsTable.Search(null, true);
            Guid uid;

            while (cursor.MoveNext()) {
                var plts_collection = new PLTS_Collections(cursor.Current);
                Guid.TryParse(Convert.ToString(plts_collection.GLOBALID), out uid);
                if (!_pltsCollections.ContainsKey(uid)) {
                    _pltsCollections[uid] = new PltsCollection(_source, plts_collection);
                } else {
                    throw new IndexOutOfRangeException($"Multiple PltsCollections with same id not allowed {uid}");
                }
            }
        }

        internal static Type GetS101CatlitTypeFrom(AidsToNavigationP aton) {
            if (aton.FCSUBTYPE != 65) {
                throw new NotImplementedException("Only light types are supported");
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
            else if ((aton.SECTR1 != default && aton.SECTR2 != default) || (catlits.Contains(1) || catlits.Contains(16))) {
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
            if (!_srcObjectToSlaves.ContainsKey(uid))
                return _srcObjectToSlaves[uid].Count;

            else {
                return -1;
            }
        }

        internal IList<T> GetRelated<T>(Type s101Type, Guid uid) where T : class {
            if (!_isInitialized)
                throw new ArgumentException("Not initalized. Call intialize.");
            if (!_srcObjectToSlaves.ContainsKey(uid))
                return null;

            var result = new List<T>();

            foreach (var elm in _srcObjectToSlaves[uid]) {
                if (elm.S101Type == s101Type) {
                    result.Add(elm.S57Object as T);
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

        private void LoadPltsFrels(Geodatabase source) {
            var pltsFrel = source.OpenDataset<Table>(source.GetName("PLTS_Frel"));
            var frelSourceFeatureClasses = new Dictionary<string, IList<PLTS_Frel>>();

            var cursor = pltsFrel.Search(null, true);
            Guid uid;

            while (cursor.MoveNext()) {
                var plts_frel = new PLTS_Frel(cursor.Current);

                var relationshipIndicator = plts_frel.RIND switch {
                    1 => "Master",
                    2 => "Slave",
                    3 => "Peer",
                    999 => "Rep"
                };

                Guid srcUid;

                if (relationshipIndicator == "Peer") {
                    if (plts_frel.SRC_FC.ToLower() == "plts_collections") {
                        Guid.TryParse(Convert.ToString(plts_frel.SRC_UID), out srcUid);
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
                        var pltsSlave = new PltsSlave(plts_frel);


                        //pltsSlave.Fetch(_source, Direction.Destination);
                        _srcObjectToSlaves[uid].Add(pltsSlave);
                    }
                }
                else if (relationshipIndicator == "Rep") {
                    throw new NotImplementedException("PLTS feature relations RelationshipIndicator = Rep");
                }
            }

            foreach (var item in _srcObjectToSlaves) {
                foreach (var frel in item.Value) {
                    var key = frel.PLTS_Frel.SRC_FC.ToLower();
                    if (frelSourceFeatureClasses.ContainsKey(key)) {
                        frelSourceFeatureClasses[key].Add(frel.PLTS_Frel);
                    }
                    else {
                        frelSourceFeatureClasses[key] = new List<PLTS_Frel>() { frel.PLTS_Frel };
                    }
                }
            }
        }

        private void LoadPltsFrels2(Geodatabase source) {
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
                    999 => "Rep"
                };

                Guid srcUid;

                if (relationshipIndicator == "Peer") {
                    if (plts_frel.SRC_FC.ToLower() == "plts_collections") {
                        Guid.TryParse(Convert.ToString(plts_frel.SRC_UID), out srcUid);
                        if (!_pltsCollections.ContainsKey(srcUid)) {
                            Logger.Current.DataError(plts_frel.OBJECTID.Value, "plts_frel", plts_frel.DEST_LNAM, $"Missing {plts_frel.SRC_FC}::{plts_frel.SRC_SUB}::{srcUid}");
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
                        var pltsSlave = new PltsSlave(plts_frel);
                        _srcObjectToSlaves[uid].Add(pltsSlave);
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
            Dictionary<string, List<PLTS_Frel>> destinationFcToFrels = frels.GroupBy(obj => obj.DEST_FC).ToDictionary(group => group.Key, group => group.ToList());

            int loadedRelatedObjectsCount = 0;

            foreach (var destFc in destinationFcToFrels.Keys) {
                var destinationFeatureClassName = _source.GetName(destFc);

                if (!_source.IsFeatureClass(destinationFeatureClassName)) {
                    continue;
                }

                using var relatedFeatureClass = _source.OpenDataset<FeatureClass>(destinationFeatureClassName);

                using var cursorRelated = relatedFeatureClass.Search(null, true);

                while (cursorRelated.MoveNext()) {
                    Guid.TryParse(Convert.ToString(cursorRelated.Current["GLOBALID"]), out var currentGlobalId);

                    if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("aidstonavigationp")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            idIndex[currentGlobalId].S57Object = new AidsToNavigationP((Feature)cursorRelated.Current);
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("dangersp")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            idIndex[currentGlobalId].S57Object = new DangersP((Feature)cursorRelated.Current);
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("naturalfeaturesa")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            idIndex[currentGlobalId].S57Object = new NaturalFeaturesA((Feature)cursorRelated.Current); ;
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("naturalfeaturesp")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            idIndex[currentGlobalId].S57Object = new NaturalFeaturesP((Feature)cursorRelated.Current); 
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("culturalfeaturesp")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            idIndex[currentGlobalId].S57Object = new CulturalFeaturesP((Feature)cursorRelated.Current); 
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("tracksandroutesa")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            idIndex[currentGlobalId].S57Object = new TracksAndRoutesA((Feature)cursorRelated.Current); 
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("tracksandroutesl")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            idIndex[currentGlobalId].S57Object = new TracksAndRoutesL((Feature)cursorRelated.Current);
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("portsandservicesp")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            idIndex[currentGlobalId].S57Object = new PortsAndServicesP((Feature)cursorRelated.Current);
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("regulatedareasandlimitsp")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            idIndex[currentGlobalId].S57Object = new RegulatedAreasAndLimitsP((Feature)cursorRelated.Current);
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("userdefinedfeaturesp")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            idIndex[currentGlobalId].S57Object = new UserDefinedFeaturesP((Feature)cursorRelated.Current);
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("tracksandroutesp")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            idIndex[currentGlobalId].S57Object = new TracksAndRoutesP((Feature)cursorRelated.Current);
                        }
                    }
                    else if (destinationFeatureClassName.Split('.').Last().ToLower().Equals("offshoreinstallationsl")) {
                        if (idIndex.ContainsKey(currentGlobalId)) {
                            loadedRelatedObjectsCount++;
                            idIndex[currentGlobalId].S57Object = new OffshoreInstallationsL((Feature)cursorRelated.Current);
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

        internal bool HasRelated(Guid globalId) {
            
            return _srcObjectToSlaves.ContainsKey(globalId);
        }
    }
}
