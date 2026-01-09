using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using S100Framework.AttributeModel;
using S100Framework.AttributeModel.S101.FeatureAssociation;
using S100Framework.AttributeModel.S101.FeatureTypes;
using System.Diagnostics;


namespace S100Framework.Applications.Singletons
{

    internal class BridgeElement
    {
        public int Id { get; }
        public string Name { get; set; } = null!;

        public List<string> ObjectIDs { get; private set; }

        public string BridgeAggregationName { get; set; } = null!;

        public Geometry DissolvedGeometry { get; private set; }

        public BridgeElement(int id, List<string> objectIDs, Geometry dissolvedGeometry) {
            this.Id = id;
            this.ObjectIDs = objectIDs;
            this.DissolvedGeometry = dissolvedGeometry;
        }

        public bool ContainsOID(string tableName, long oid) {
            return this.ObjectIDs.Contains($"{tableName.ToLower()}:{oid}");
        }
    }

    class FeatureGrouper
    {
        internal List<BridgeElement> GroupAndDissolveToBridgeElements(SQLSyntax syntax, List<FeatureClass> featureclasses, QueryFilter filter) {
            var groups = new List<List<string>>();

            var features = new List<(string ObjectID, Geometry Geometry)>();

            foreach (var featureclass in featureclasses) {
                var tuple = syntax.ParseTableName(featureclass.GetName());
                var tableName = tuple.Item3.ToLowerInvariant();
                using (var cursor = featureclass.Search(new QueryFilter() { WhereClause = $"{filter.WhereClause} and fcsubtype in (5,45)" })) {
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
                    groups.Add([oid]);
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

                Geometry dissolved = null!;
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
    internal class BridgeRelation
    {
        public string? ParentName { get; set; }
        public string? ChildName { get; set; }
        public Type? childTypeS101 { get; set; }
        public string? ChildDisplayName { get; set; }
        public string? NationalChildDisplayName { get; set; }
    }



    public class Bridges
    {

        private static Bridges? _instance;
        private static readonly object _lock = new object();

        private static List<BridgeElement>? _groups;

        private static readonly Dictionary<string, List<BridgeRelation>> _bindings = [];

        internal List<BridgeRelation> GetBindings(string bridgeName) {
            if (!_bindings.ContainsKey(bridgeName)) {
                return [];
            }


            return _bindings[bridgeName];
        }

        internal void AddRelation(string parentName, string childName, Type childTypeS101, string? childDisplayName, string? nationalChildDisplayName) {
            // featureBinding with bridge aggregation
            // samme a-nr - featureBinding.

            if (_bindings.ContainsKey(parentName)) {
                _bindings[parentName].Add(new BridgeRelation() {
                    ChildName = childName,
                    childTypeS101 = childTypeS101,
                    ParentName = parentName,
                    ChildDisplayName = childDisplayName,
                    NationalChildDisplayName = nationalChildDisplayName
                });
            }
            else {
                _bindings.Add(parentName, [ new BridgeRelation() {
                    ChildName = childName,
                    childTypeS101 = childTypeS101,
                    ParentName = parentName,
                    ChildDisplayName = childDisplayName,
                    NationalChildDisplayName = nationalChildDisplayName
                } ]);
            }
        }

        internal List<BridgeElement> GetBridgeElementsContainingOID(string tableName, long oid) {
            return _groups!.Where(be => be.ContainsOID(tableName.ToLower(), oid)).ToList();
        }

        internal IEnumerable<BridgeElement> BridgeElements() {
            foreach (var bridgeElement in _groups!) {
                yield return bridgeElement;
            }
        }

        private static Geodatabase? _source;
        private static Geodatabase? _destination;

        private Bridges(Geodatabase source, Geodatabase destination, QueryFilter whereClause) {
            _source = source ?? throw new ArgumentNullException(nameof(source));
            _destination = destination ?? throw new ArgumentNullException(nameof(destination));

            var culturalFeaturesATableName = "CulturalFeaturesA";
            var portsAndServicesTableName = "PortsAndServicesA";

            using var culturalFeaturesA = _source.OpenDataset<FeatureClass>(_source.GetName(culturalFeaturesATableName));
            using var portsAndServicesA = _source.OpenDataset<FeatureClass>(_source.GetName(portsAndServicesTableName));

            var featureGrouper = new FeatureGrouper();
            //_groups = featureGrouper.GroupAndDissolveToBridgeElements(new() { culturalFeaturesA, portsAndServicesA }, ImporterNIS.QueryFilter);

            var sqlSyntax = _source.GetSQLSyntax();

            _groups = featureGrouper.GroupAndDissolveToBridgeElements(sqlSyntax, [culturalFeaturesA], ImporterNIS.QueryFilter);
        }

        internal static void Initialize(Geodatabase source, Geodatabase destination) {
            if (_instance != null) {
                throw new InvalidOperationException("Bridges has already been initialized.");
            }

            lock (_lock) {
                if (_instance == null) {
                    _instance = new Bridges(source, destination, ImporterNIS.QueryFilter);
                }
            }
        }

        internal void CreateRelations() {
            var name = _destination!.GetName("featuretype");
            using var featuretypeTable = _destination!.OpenDataset<Table>(_destination.GetName("featuretype"));

            using var bufferFeatureType = featuretypeTable.CreateRowBuffer();

            var bridgeElements = _instance!.BridgeElements().ToList();

            using (var cursor = featuretypeTable.CreateUpdateCursor(new QueryFilter() { WhereClause = "code = 'Bridge'" }, useRecyclingCursor: true)) {
                while (cursor.MoveNext()) {
                    var row = cursor.Current;

                    long oid = row.GetObjectID();
                    //var shape = row.GetShape();
                    Bridge bridge = System.Text.Json.JsonSerializer.Deserialize<Bridge>(Convert.ToString(row["json"])!)!;

                    var bindings = _instance!.GetBindings(row.UID());

                    var featureBindings = new List<featureBinding>();

                    foreach (var binding in bindings) {
                        var relatedBridge = row.UID();
                        var bridgeElement = bridgeElements.SingleOrDefault(e => e.Name == relatedBridge);
                        featureBinding featureBinding = new featureBinding<BridgeAggregation> {
                            role = "theComponent",
                            roleType = "association",
                            featureId = binding.ChildName!,
                            featureType = name,
                        };
                        featureBindings.Add(featureBinding);
                    }
                    row["featurebindings"] = System.Text.Json.JsonSerializer.Serialize(featureBindings, ImporterNIS.jsonFeatureTypeSerializerOptions);

                    // Update opening bridge
                    var canOpen = bindings.Any(obj => {
                        return obj.childTypeS101 == typeof(SpanOpening);
                    });

                    var displayName = bindings.FirstOrDefault(obj => obj.ChildDisplayName != default)?.ChildDisplayName;
                    var ndisplayName = bindings.FirstOrDefault(obj => obj.NationalChildDisplayName != default)?.NationalChildDisplayName;

                    //S100Framework.AttributeModel.S101.FeatureTypes.Bridge bridge = System.Text.Json.JsonSerializer.Deserialize<S100Framework.AttributeModel.S101.FeatureTypes.Bridge>(Convert.ToString(row["json"].ToString()!))!;

                    bridge.openingBridge_optional = canOpen;
                    bridge.featureName_optional = ImporterNIS.GetFeatureName(displayName, ndisplayName);

                    row["json"] = System.Text.Json.JsonSerializer.Serialize(bridge);

                    cursor.Update(row);
                    //row.Store();
                }
            }
            // Note: all elements are already bound to the bridge - search for relatedBridge and follow the trail...

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
