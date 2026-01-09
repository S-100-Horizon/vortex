using ArcGIS.Core.Data;

namespace S100Framework.Applications.Singletons
{
    internal sealed class Subtypes
    {
        private static Subtypes? _instance;
        private static readonly object _lock = new object();
        private readonly Geodatabase _geodatabase;
        private readonly SQLSyntax _sqlSyntax;
        private readonly Tuple<string, string, string> _tuple;

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
            this._subtypes = [];
            this._geodatabase = geodatabase;

            this._sqlSyntax = this._geodatabase.GetSQLSyntax();
            var name = this._geodatabase.GetDefinitions<TableDefinition>().First().GetName();
            this._tuple = this._sqlSyntax.ParseTableName(name);
        }

        private string GetFullTableName(string name) => this._sqlSyntax.QualifyTableName(this._tuple.Item1, this._tuple.Item2, name);

        public static Subtypes Instance {
            get {
                if (_instance == null)
                    throw new InvalidOperationException("Must initialize before use.");
                return _instance;
            }
        }

        private void RegisterSubtypes(string tableName) {
            using var featureclass = this._geodatabase.OpenDataset<FeatureClass>(this.GetFullTableName(tableName));

            var subtypes = new Dictionary<int, string>();
            foreach (var subtype in featureclass.GetSubtypes()) {
                subtypes.Add(subtype.Key, subtype.Value);

            }
            this._subtypes[this._sqlSyntax.ParseTableName(featureclass.GetName()).Item3] = subtypes;
        }

        public bool TryGetSubtype(string tableName, int code, out string value) {
            tableName = this._sqlSyntax.ParseTableName(tableName).Item3;

            if (!this._subtypes.ContainsKey(tableName)) {
                this.RegisterSubtypes(tableName);
            }

            if (this._subtypes.TryGetValue(tableName, out var subtypes)) {
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
            this._subtypes[this._sqlSyntax.ParseTableName(featureclass.GetName()).Item3] = subtypes;

        }
    }
}
