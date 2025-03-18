using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using System.ComponentModel.Design;
using System.Data;


namespace S100Framework.Applications
{

    internal enum Direction {
        Source = 0,
        Direction = 1
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

        public PltsCollection(PLTS_Collections plts_collections) {
            _plts_collections = plts_collections;
            _related = new();
        }

        internal void AddRelated(PLTS_Frel plts_frel) {
            _related.Add(new PltsSlave(plts_frel));
        }
    }

    internal class PltsSlave {
        public PLTS_Frel PLTS_Frel { get; set; }
        
        private S57Object _s57Object;

        
        public Guid GlobalId { get; set; }

        public PltsSlave(PLTS_Frel plts_Frel) {
            this.PLTS_Frel = plts_Frel;
            Guid uid;


            if (Guid.TryParse(plts_Frel.DEST_UID, out uid)) {
                this.GlobalId = uid;
            }
        }

        internal S57Object Fetch(Geodatabase geodatabase, Direction direction) {
            S57Object result = null;

            var sourceFeatureClass = direction switch {
                Direction.Source => this.PLTS_Frel.SRC_FC,
                Direction.Direction => this.PLTS_Frel.DEST_FC
            };

            var queryDef = new QueryDef();
            queryDef.Tables = $"{geodatabase.GetName(sourceFeatureClass)}";

            queryDef.WhereClause = $"globalid = '{this.PLTS_Frel.DEST_UID}'";

            var cursor = geodatabase.Evaluate(queryDef, true);

            while (cursor.MoveNext()) {
                if (sourceFeatureClass.ToLower().Equals("aidstonavigationp")) {
                    result = new AidsToNavigationP((Feature)cursor.Current);
                }
                else {
                    throw new NotSupportedException($"GetRelated: {sourceFeatureClass}");
                }
            };
            _s57Object = result;
            return result;
        }
    }

    internal class FeatureRelations
    {
        private Dictionary<Guid, PltsCollection> _pltsCollections = new Dictionary<Guid, PltsCollection>();

        private Dictionary<Guid, IList<PltsSlave>> _srcObjectToSlave = new Dictionary<Guid, IList<PltsSlave>>();

        private bool _isInitialized = false;

        public void Initialize(Geodatabase source) {
            LoadPltsCollections(source);
            LoadPltsFrels(source);
            _isInitialized = true;
        }

        private void LoadPltsCollections(Geodatabase source) {

            // Read aggregations
            var pltsCollectionsTable = source.OpenDataset<Table>(source.GetName("PLTS_COLLECTIONS"));
            var pltsCollections = new Dictionary<Guid, IList<PLTS_Collections>>();

            var cursor = pltsCollectionsTable.Search(null, true);
            Guid uid;

            while (cursor.MoveNext()) {
                var plts_collection = new PLTS_Collections(cursor.Current);
                Guid.TryParse(Convert.ToString(plts_collection.GLOBALID), out uid);
                if (!_pltsCollections.ContainsKey(uid)) {
                    _pltsCollections[uid] = new PltsCollection(plts_collection);
                } else {
                    throw new IndexOutOfRangeException($"Multiple PltsCollections with same id not allowed {uid}");
                }

            }

            //foreach (var item in _srcObjectToSlave) {
            //    foreach (var frel in item.Value) {
            //        var key = frel.SRC_FC.ToLower();
            //        if (frelSourceFeatureClasses.ContainsKey(key)) {
            //            frelSourceFeatureClasses[key].Add(frel);
            //        }
            //        else {
            //            frelSourceFeatureClasses[key] = new List<PLTS_Frel>() { frel };
            //        }
            //    }
            //}
        }

        internal IList<PltsSlave> GetRelated(Guid uid) {
            if (!_isInitialized)
                throw new ArgumentException("Not initalized. Call intialize.");
            if (!_srcObjectToSlave.ContainsKey(uid))
                return null;

            return _srcObjectToSlave[uid];
        }

        internal bool IsSlave(Guid globalid) {
            if (!_isInitialized)
                throw new ArgumentException("Not initalized. Call intialize.");

            var result = _srcObjectToSlave.Values.SelectMany(list => list)
                                      .FirstOrDefault(obj => obj.GlobalId.Equals(globalid));

            return result != null;
        }

        private void LoadPltsFrels(Geodatabase source) {
            var aidstonavigation = source.OpenDataset<Table>(source.GetName("PLTS_Frel"));
            var frelSourceFeatureClasses = new Dictionary<string, IList<PLTS_Frel>>();

            var cursor = aidstonavigation.Search(null, true);
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
                    if (!_srcObjectToSlave.ContainsKey(uid)) {
                        _srcObjectToSlave[uid] = new List<PltsSlave>() { new PltsSlave(plts_frel) };
                    }
                    else {
                        _srcObjectToSlave[uid].Add(new PltsSlave(plts_frel));
                    }
                }
                else if (relationshipIndicator == "Rep") {
                    throw new NotImplementedException("PLTS feature relations RelationshipIndicator = Rep");
                }

            }

            foreach (var item in _srcObjectToSlave) {
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
    }
}
