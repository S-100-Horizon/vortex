using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcGIS.Desktop.Editing.Attributes
{
    internal static class Extensions
    {
        public static bool IsNull(this Inspector inspector, string fieldName) {
            if (inspector[fieldName] == null) return true;
            if (DBNull.Value.Equals(inspector[fieldName])) return true;
            return false;

        }
    }
}
