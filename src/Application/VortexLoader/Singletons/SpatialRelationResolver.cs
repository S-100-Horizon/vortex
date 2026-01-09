using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using S100Framework.Applications.S57.esri;

namespace S100Framework.Applications.Singletons
{


    public class SpatialRelationResolver
    {
        private static SpatialRelationResolver? _instance;
        private static readonly object _lock = new object();

        private static readonly Dictionary<string, FeatureClass> _featureClasses = [];

        private static Geodatabase? _geodatabase;
        private static SQLSyntax? _sqlSyntax;
        private static Tuple<string, string, string>? _tuple;

        private SpatialRelationResolver(Geodatabase geodatabase) {
            _geodatabase = geodatabase ?? throw new ArgumentNullException(nameof(geodatabase));

            _sqlSyntax = _geodatabase.GetSQLSyntax();
            var name = _geodatabase.GetDefinitions<TableDefinition>().First().GetName();
            _tuple = _sqlSyntax.ParseTableName(name);
        }

        private string GetFullTableName(string name) => _sqlSyntax!.QualifyTableName(_tuple!.Item1, _tuple!.Item2, name);

        internal static void Initialize(Geodatabase geodatabase) {
            if (_instance != null) {
                throw new InvalidOperationException("SpatialRelationResolver has already been initialized.");
            }

            lock (_lock) {
                if (_instance == null) {
                    _instance = new SpatialRelationResolver(geodatabase);
                }
            }
        }

        internal static SpatialRelationResolver Instance {
            get {
                if (_instance == null) {
                    throw new InvalidOperationException("SpatialRelationResolver must be initialized before use.");
                }

                return _instance;
            }
        }

        internal IEnumerable<T> GetSpatialRelatedValueFrom<T>(Geometry shape) where T : class {
            //return new List<T>() { (T)(object)current.GlobalId };

            if (!_featureClasses.ContainsKey(typeof(T).Name)) {
                _featureClasses[typeof(T).Name] = _geodatabase!.OpenDataset<FeatureClass>(this.GetFullTableName(typeof(T).Name));
            }
            var featureclass = _featureClasses[typeof(T).Name];

            if (shape != null) {
                foreach (var SpatialRelated in SelectIn<T>(shape, featureclass, SpatialRelationship.Intersects, ImporterNIS.QueryFilter)) {
                    yield return SpatialRelated;
                }
            }
        }

        internal IEnumerable<T> GetTouchesValueFrom<T>(S57Object current) where T : class {
            //return new List<T>() { (T)(object)current.GlobalId };

            if (!_featureClasses.ContainsKey(typeof(T).Name)) {
                _featureClasses[typeof(T).Name] = _geodatabase!.OpenDataset<FeatureClass>(this.GetFullTableName(typeof(T).Name));
            }
            var featureclass = _featureClasses[typeof(T).Name];

            if (current.Shape != null) {
                foreach (var SpatialRelated in SelectIn<T>(current.Shape, featureclass, SpatialRelationship.Touches, ImporterNIS.QueryFilter)) {
                    yield return SpatialRelated;
                }
            }
        }


        private static IEnumerable<T> SelectIn<T>(Geometry geometry, FeatureClass in_featureclass, SpatialRelationship spatialRelationship, QueryFilter queryFilter) where T : class {
            var spatialQueryFilter = new SpatialQueryFilter {
                FilterGeometry = geometry,
                SpatialRelationship = spatialRelationship,
                WhereClause = queryFilter.WhereClause
            };

            using (var spatialSearch = in_featureclass.Search(spatialQueryFilter, true)) {
                var shape = spatialSearch.FindField("SHAPE");
                while (spatialSearch.MoveNext()) {
                    var row = spatialSearch.Current;
                    var feature = (Feature)row;
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


}
