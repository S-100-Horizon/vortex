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

namespace S100Framework.Applications
{
    internal sealed class Subtypes
    {
        private static readonly Lazy<Subtypes> _instance = new Lazy<Subtypes>(() => new Subtypes());

        private readonly Dictionary<string, Dictionary<int, string>> _subtypes;

        private Subtypes() {
            _subtypes = new Dictionary<string, Dictionary<int, string>>();
        }

        public static Subtypes Instance => _instance.Value;

        public void RegisterSubtypes(FeatureClass featureclass) {
             var subtypes = new Dictionary<int, string>();
            foreach (var subtype in featureclass.GetSubtypes()) {
                subtypes.Add(subtype.Key, subtype.Value);

            }
            _subtypes[featureclass.GetName()] = subtypes;
        }

        public bool TryGetSubtype(string tablename, int code, out string value) {
            if (_subtypes.TryGetValue(tablename, out var subtypes)) {
                value = subtypes[code];
                return true;
            }
            value = null;
            return false;
        }
    }
}
