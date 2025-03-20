using ArcGIS.Core.Data;

namespace S100Framework.Applications
{
    internal static class GeodatabaseExtensions
    {
        static bool _isInitialized = false;
        private static IReadOnlyList<FeatureClassDefinition> _layerDefinitions;
        private static IReadOnlyList<TableDefinition> _tableDefinitions;

        private static void Initialize(this Geodatabase geodatabase) {
            _layerDefinitions = geodatabase.GetDefinitions<FeatureClassDefinition>();
            _tableDefinitions = geodatabase.GetDefinitions<TableDefinition>();
        }

        public static IReadOnlyList<FeatureClassDefinition> Layers {
            get { return _layerDefinitions; }
            set { _layerDefinitions = value; }
        }

        internal static string GetName(this Geodatabase geodatabase, string name) {
            if (!_isInitialized) {
                geodatabase.Initialize();
                //_isInitialized = true;
            }

            var tableName = _layerDefinitions.FirstOrDefault<FeatureClassDefinition>(e => e.GetAliasName().ToLower().Equals(name.ToLower(), StringComparison.InvariantCultureIgnoreCase))?.GetName();
            if (tableName == null) {
                tableName = _tableDefinitions.FirstOrDefault<TableDefinition>(e => e.GetAliasName().ToLower().Equals(name.ToLower(), StringComparison.InvariantCultureIgnoreCase))?.GetName();

            }
            return tableName;
        }

        internal static bool IsTraditionallyVersioned(this Geodatabase geodatabase) {
            if (geodatabase.IsVersioningSupported()) {
                if (geodatabase.GetType().Name == "BranchVersionedWorkspace") {
                    return false;
                }

                return true;
            }
            return false;
        }

    }
}
