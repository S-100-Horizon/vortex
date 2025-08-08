using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Mapping;
using System.Collections.Generic;


namespace S100Framework.Applications.Singletons
{

    public class BridgeElement
    {
        public int Id { get; }  
        public string Name { get; set; }  

        public List<long> ObjectIDs { get; private set; }


        public Geometry DissolvedGeometry { get; private set; }

        public BridgeElement(int id, List<long> objectIDs, Geometry dissolvedGeometry) {
            Id = id;
            ObjectIDs = objectIDs;
            DissolvedGeometry = dissolvedGeometry;
        }

        public bool ContainsOID(long oid) {
            return ObjectIDs.Contains(oid);
        }
    }



    public class FeatureGrouper
    {
        public List<BridgeElement> GroupAndDissolveToBridgeElements(FeatureClass featureclass) {
            var groups = new List<List<long>>();


            var features = new List<(long ObjectID, Geometry Geometry)>();

            using (var cursor = featureclass.Search(new QueryFilter() { WhereClause = "fcsubtype in (5,45)" })) {
                while (cursor.MoveNext()) {
                    using (var row = (Feature)cursor.Current) {
                        long oid = row.GetObjectID();
                        var shape = row.GetShape();

                        features.Add((oid, shape));
                    }
                }
            }

            int FindGroupIndex(long oid) {
                for (int i = 0; i < groups.Count; i++) {
                    if (groups[i].Contains(oid))
                        return i;
                }
                return -1;
            }

            foreach (var feature in features) {
                long oid = feature.ObjectID;
                var geom = feature.Geometry;

                var touchingOids = features
                    .Where(f => f.ObjectID != oid && GeometryEngine.Instance.Touches(geom, f.Geometry))
                    .Select(f => f.ObjectID)
                    .ToList();

                if (!touchingOids.Any()) {
                    groups.Add(new List<long> { oid });
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
                        var newGroup = new List<long> { oid };
                        newGroup.AddRange(touchingOids);
                        groups.Add(newGroup);
                    }
                    else {
                        var mergedOids = new HashSet<long> { oid };
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
        public class Bridges
    {
        private static Bridges _instance;
        private static readonly object _lock = new object();

        private static Dictionary<string, FeatureClass> _featureClasses = new();

        private static List<BridgeElement>? _groups;


        public List<BridgeElement> GetBridgeElementsContainingOID(long oid) {
            return _groups.Where(be => be.ContainsOID(oid)).ToList();
        }
        public IEnumerable<BridgeElement> BridgeElements() {
            foreach (var bridgeElement in _groups) {
                yield return bridgeElement;
            }
        }

        private static Geodatabase _geodatabase;

        private Bridges(Geodatabase geodatabase) {
            _geodatabase = geodatabase ?? throw new ArgumentNullException(nameof(geodatabase));

            var tableName = "CulturalFeaturesA";

            using var culturalFeaturesA = _geodatabase.OpenDataset<FeatureClass>(_geodatabase.GetName(tableName));
            
            var featureGrouper = new FeatureGrouper();
            _groups = featureGrouper.GroupAndDissolveToBridgeElements(culturalFeaturesA);
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
