using ArcGIS.Core.Data;

namespace S100Framework.Applications
{
    internal static class GeodatabaseExtensions
    {


        internal static string? GetName(this Geodatabase geodatabase, string name) {
            var _layerDefinitions = geodatabase.GetDefinitions<FeatureClassDefinition>();
            var _tableDefinitions = geodatabase.GetDefinitions<TableDefinition>();

            var tableName = _layerDefinitions?.FirstOrDefault<FeatureClassDefinition>(e => e.GetAliasName().ToLower().Equals(name.ToLower(), StringComparison.InvariantCultureIgnoreCase))?.GetName();
            if (tableName == null) {
                tableName = _tableDefinitions?.FirstOrDefault<TableDefinition>(e => e.GetAliasName().ToLower().Equals(name.ToLower(), StringComparison.InvariantCultureIgnoreCase))?.GetName();
            }
            return tableName;
        }
        internal static bool IsFeatureClass(this Geodatabase geodatabase, string name) {
            var _layerDefinitions = geodatabase.GetDefinitions<FeatureClassDefinition>();
            var _tableDefinitions = geodatabase.GetDefinitions<TableDefinition>();

            var tableName = _layerDefinitions?.FirstOrDefault<FeatureClassDefinition>(e => e.GetAliasName().ToLower().Equals(name.ToLower(), StringComparison.InvariantCultureIgnoreCase) || e.GetName().ToLower().Equals(name.ToLower(), StringComparison.InvariantCultureIgnoreCase))?.GetName();
            if (tableName == null) {
                tableName = _tableDefinitions?.FirstOrDefault<TableDefinition>(e => e.GetAliasName().ToLower().Equals(name.ToLower(), StringComparison.InvariantCultureIgnoreCase) || e.GetName().ToLower().Equals(name.ToLower(), StringComparison.InvariantCultureIgnoreCase))?.GetName();
                return false;
            }
            return true;
        }

        internal static SortedDictionary<int, string> GetSubtypes(this FeatureClass featureClass) {
            var subtypes = featureClass.GetDefinition().GetSubtypes();
            var sortedDict = new SortedDictionary<int, string>();
            foreach (var subtype in subtypes) {
                sortedDict.Add(subtype.GetCode(), subtype.GetName());
            }
            return sortedDict;
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
