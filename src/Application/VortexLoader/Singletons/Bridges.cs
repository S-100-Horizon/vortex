using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using System.Diagnostics;


namespace S100Framework.Applications.Singletons
{

    internal class BridgeElement
    {
        public int Id { get; }  
        public string Name { get; set; }  

        public List<string> ObjectIDs { get; private set; }

        public string BridgeAggregationName { get; set; }

        public Geometry DissolvedGeometry { get; private set; }

        public BridgeElement(int id, List<string> objectIDs, Geometry dissolvedGeometry) {
            Id = id;
            ObjectIDs = objectIDs;
            DissolvedGeometry = dissolvedGeometry;
        }

        public bool ContainsOID(string tableName, long oid) {
            return ObjectIDs.Contains($"{tableName.ToLower()}:{oid}");
        }
    }


    class FeatureGrouper
    {
        internal List<BridgeElement> GroupAndDissolveToBridgeElements(List<FeatureClass> featureclasses) {
            var groups = new List<List<string>>();

            var features = new List<(string ObjectID, Geometry Geometry)>();

            foreach (var featureclass in featureclasses) {
                var tableName = featureclass.GetName().ToLower();
                using (var cursor = featureclass.Search(new QueryFilter() { WhereClause = "fcsubtype in (5,45)" })) {
                    while (cursor.MoveNext()) {
                        using (var row = (Feature)cursor.Current) {
                            long oid = row.GetObjectID();
                            var shape = row.GetShape();

                            features.Add(($"{tableName}:{oid}", shape));
                        }
                    }
                }
            }


                int FindGroupIndex(string oid) {
                    for (int i = 0; i < groups.Count; i++) {
                        if (groups[i].Contains(oid))
                            return i;
                    }
                    return -1;
                }

                foreach (var feature in features) {
                    string oid = feature.ObjectID;
                    var geom = feature.Geometry;

                    var touchingOids = features
                        .Where(f => f.ObjectID != oid && GeometryEngine.Instance.Touches(geom, f.Geometry))
                        .Select(f => f.ObjectID)
                        .ToList();

                    if (!touchingOids.Any()) {
                        groups.Add(new List<string> { oid });
                    }
                    else {
                        var groupIndexes = new HashSet<int>();

                        int oidGroupIndex = FindGroupIndex(oid);
                        if (oidGroupIndex != -1)
                            groupIndexes.Add(oidGroupIndex);

                        foreach (var tOid in touchingOids) {
                            int tGroupIndex = FindGroupIndex(tOid);
                            if (tGroupIndex != -1)
                                groupIndexes.Add(tGroupIndex);
                        }

                        if (groupIndexes.Count == 0) {
                            var newGroup = new List<string> { oid };
                            newGroup.AddRange(touchingOids);
                            groups.Add(newGroup);
                        }
                        else {
                            var mergedOids = new HashSet<string> { oid };
                            foreach (var tOid in touchingOids)
                                mergedOids.Add(tOid);

                            var indexesToRemove = groupIndexes.OrderByDescending(i => i).ToList();
                            foreach (var idx in indexesToRemove) {
                                foreach (var item in groups[idx])
                                    mergedOids.Add(item);
                                groups.RemoveAt(idx);
                            }

                            groups.Add(mergedOids.ToList());
                        }
                    }
                }

                var bridgeElements = new List<BridgeElement>();
                int idCounter = 1;

                foreach (var group in groups) {
                    var geoms = group.Select(oid => features.First(f => f.ObjectID == oid).Geometry).ToList();

                    Geometry dissolved = null;
                    if (geoms.Count == 1) {
                        dissolved = geoms[0];
                    }
                    else {
                        dissolved = GeometryEngine.Instance.Union(geoms);
                    }

                    var element = new BridgeElement(idCounter++, group, dissolved);

                    bridgeElements.Add(element);
                }

                return bridgeElements;
        }
    }

    [DebuggerDisplay("{childTypeS101} {ChildName}")]
    internal class BridgeRelation {
        public string ParentName { get; set; }
        public string ChildName { get; set; }
        public Type childTypeS101 { get; set; }
    }

    public class Bridges  {

        private static Bridges? _instance;
        private static readonly object _lock = new object();

        private static List<BridgeElement>? _groups;

        private static Dictionary<string,List<BridgeRelation>> _bindings = new();

        internal List<BridgeRelation> GetBindings(string bridgeName) {
            return _bindings[bridgeName];
        }

        internal void AddRelation(string parentName, string childName, Type childTypeS101) {
            // featureBinding with bridge aggregation
            // samme a-nr - featureBinding.

            if (_bindings.ContainsKey(parentName)) {
                _bindings[parentName].Add(new BridgeRelation() {
                    ChildName = childName,
                    childTypeS101 = childTypeS101,
                    ParentName = parentName
                });
            } else {
                _bindings.Add(parentName, new List<BridgeRelation> { new BridgeRelation() {
                    ChildName = childName,
                    childTypeS101 = childTypeS101,
                    ParentName = parentName
                } });
            }
        }

        internal List<BridgeElement> GetBridgeElementsContainingOID(string tableName, long oid) {
            return _groups.Where(be => be.ContainsOID(tableName.ToLower(),oid)).ToList();
        }

        internal IEnumerable<BridgeElement> BridgeElements() {
            foreach (var bridgeElement in _groups) {
                yield return bridgeElement;
            }
        }

        private static Geodatabase _geodatabase;

        private Bridges(Geodatabase geodatabase) {
            _geodatabase = geodatabase ?? throw new ArgumentNullException(nameof(geodatabase));

            var culturalFeaturesATableName = "CulturalFeaturesA";
            var portsAndServicesTableName = "PortsAndServicesA";

            using var culturalFeaturesA = _geodatabase.OpenDataset<FeatureClass>(_geodatabase.GetName(culturalFeaturesATableName));
            using var portsAndServicesA = _geodatabase.OpenDataset<FeatureClass>(_geodatabase.GetName(portsAndServicesTableName));

            var featureGrouper = new FeatureGrouper();
            _groups = featureGrouper.GroupAndDissolveToBridgeElements(new() { culturalFeaturesA, portsAndServicesA } );
        }

        internal static void Initialize(Geodatabase geodatabase) {
            if (_instance != null) {
                throw new InvalidOperationException("Bridges has already been initialized.");
            }

            lock (_lock) {
                if (_instance == null) {
                    _instance = new Bridges(geodatabase);
                }
            }
        }

        internal void CreateRelations() {

            // Store all bridge relations
            foreach (var bridge in _instance!.BridgeElements()) {
                // Create relations for each bridge
                var bindings = _instance!.GetBindings(bridge.Name);
                // Todo: write all aggregations
                ;


            }
        }

        internal static Bridges Instance {
            get {
                if (_instance == null) {
                    throw new InvalidOperationException("Bridges must be initialized before use.");
                }
                return _instance;
            }
        }
    }
}
