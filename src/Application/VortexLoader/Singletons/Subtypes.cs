using ArcGIS.Core.Data;
using ArcGIS.Core.Internal.CIM;

namespace S100Framework.Applications.Singletons
{
    internal sealed class Subtypes
    {
        private static Subtypes? _instance;
        private static readonly object _lock = new object();
        private readonly Geodatabase _geodatabase;
        private SQLSyntax _sqlSyntax;
        private Tuple<string, string, string> _tuple;

        private readonly Dictionary<string, Dictionary<int, string>> _subtypes;

        internal static void Initialize(Geodatabase geodatabase) {
            if (_instance != null) {
                throw new InvalidOperationException("Subtypes has already been initialized.");
            }

            lock (_lock) {
                if (_instance == null) {
                    _instance = new Subtypes(geodatabase);
                }
            }
        }

        private Subtypes(Geodatabase geodatabase) {
            _subtypes = new Dictionary<string, Dictionary<int, string>>();
            _geodatabase = geodatabase;

            _sqlSyntax = _geodatabase.GetSQLSyntax();
            var name = _geodatabase.GetDefinitions<TableDefinition>().First().GetName();
            _tuple = _sqlSyntax.ParseTableName(name);
        }

        private string GetFullTableName(string name) => _sqlSyntax.QualifyTableName(_tuple.Item1, _tuple.Item2, name);

        public static Subtypes Instance {
            get {
                if (_instance == null)
                    throw new InvalidOperationException("Must initialize before use.");
                return _instance;
            }
        }

        private void RegisterSubtypes(string tableName) {
            using var featureclass = _geodatabase.OpenDataset<FeatureClass>(GetFullTableName(tableName));

            var subtypes = new Dictionary<int, string>();
            foreach (var subtype in featureclass.GetSubtypes()) {
                subtypes.Add(subtype.Key, subtype.Value);

            }
            _subtypes[_sqlSyntax.ParseTableName(featureclass.GetName()).Item3] = subtypes;
        }

        public bool TryGetSubtype(string tableName, int code, out string value) {
            tableName = _sqlSyntax.ParseTableName(tableName).Item3;
            
            if (!_subtypes.ContainsKey(tableName)) {
                RegisterSubtypes(tableName);
            }

            if (_subtypes.TryGetValue(tableName, out var subtypes)) {
                value = subtypes[code];
                return true;
            }

            value = null!;
            return false;
        }

        internal void RegisterSubtypes(FeatureClass featureclass) {
            var subtypes = new Dictionary<int, string>();
            foreach (var subtype in featureclass.GetSubtypes()) {
                subtypes.Add(subtype.Key, subtype.Value);

            }
            _subtypes[_sqlSyntax.ParseTableName(featureclass.GetName()).Item3] = subtypes;

        }
    }
}
