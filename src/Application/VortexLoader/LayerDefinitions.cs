using ArcGIS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.Applications
{
    internal static class LayerDefinitions
    {

        static Geodatabase _geodatabase;
        private static IReadOnlyList<FeatureClassDefinition> _layerDefinitions;
        private static IReadOnlyList<TableDefinition> _tableDefinitions;

        static LayerDefinitions() {
        }
        internal static void Initialize(Geodatabase geodatabase) {
            _geodatabase = geodatabase;
            _layerDefinitions = geodatabase.GetDefinitions<FeatureClassDefinition>();
            _tableDefinitions = geodatabase.GetDefinitions<TableDefinition>();


        }

        public static IReadOnlyList<FeatureClassDefinition> Layers {
            get { return _layerDefinitions; }
            set { _layerDefinitions = value; }
        }

        internal static string GetName(string name) {
            var tableName = _layerDefinitions.FirstOrDefault<FeatureClassDefinition>(e => e.GetAliasName().ToLower().Equals(name.ToLower(), StringComparison.InvariantCultureIgnoreCase))?.GetName();
            if (tableName == null) {
                tableName = _tableDefinitions.FirstOrDefault<TableDefinition>(e => e.GetAliasName().ToLower().Equals(name.ToLower(), StringComparison.InvariantCultureIgnoreCase))?.GetName();

            }
            return tableName;
        }
    }
}
