using System;

namespace ArcGIS.Core.Data
{
    internal static class Extensions
    {
        public static bool IsNull(this Row row, string fieldName) {
            if (row[fieldName] == null) return true;
            if (DBNull.Value.Equals(row[fieldName])) return true;
            return false;

        }
    }
}
