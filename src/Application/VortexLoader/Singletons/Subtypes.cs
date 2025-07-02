using ArcGIS.Core.Data;
using ArcGIS.Core.Internal.CIM;
using ArcGIS.Desktop.Editing.Attributes;
using S100Framework.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace S100Framework.Applications.Singletons
{
    internal sealed class Subtypes
    {
        private static Subtypes _instance;
        private static readonly object _lock = new object();
        private readonly Geodatabase _geodatabase;
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

        }

        public static Subtypes Instance {
            get {
                if (_instance == null)
                    throw new InvalidOperationException("Must initialize before use.");
                return _instance;
            }
        }

        private void RegisterSubtypes(string tableName) {
            using var featureclass = _geodatabase.OpenDataset<FeatureClass>(tableName);

            var subtypes = new Dictionary<int, string>();
            foreach (var subtype in featureclass.GetSubtypes()) {
                subtypes.Add(subtype.Key, subtype.Value);

            }
            _subtypes[featureclass.GetName()] = subtypes;
        }

        public bool TryGetSubtype(string tableName, int code, out string value) {
            if (!_subtypes.ContainsKey(tableName)) {
                RegisterSubtypes(tableName);
            }

            if (_subtypes.TryGetValue(tableName, out var subtypes)) {
                value = subtypes[code];
                return true;
            }

            value = null;
            return false;
        }

        internal void RegisterSubtypes(FeatureClass metadataa) {
            ; // throw new NotImplementedException();
        }
    }
}
