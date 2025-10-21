using System;

namespace ArcGIS.Desktop.Editing.Attributes
{
    internal static class Extensions
    {
        public static bool IsNull(this Inspector inspector, string fieldName) {
            if (inspector[fieldName] == null) return true;
            if (DBNull.Value.Equals(inspector[fieldName])) return true;
            return false;

        }

        public static string Crc32(this Inspector inspector) {
            return $"{System.IO.Hashing.Crc32.HashToUInt32(Guid.Parse(Convert.ToString(inspector["GlobalID"])).ToByteArray())}";
        }
    }
}

