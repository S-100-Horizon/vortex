namespace ArcGIS.Core.Data
{
    public static class DataExtensions
    {
        public static bool IsNull(this Feature? feature, string fieldName) {
            if (feature == null) return true;
            if (feature[fieldName] == null) return true;
            if (DBNull.Value.Equals(feature[fieldName])) return true;
            return false;
        }

        public static bool IsNull(this Row row, string fieldName) {
            if (row[fieldName] == null) return true;
            if (DBNull.Value.Equals(row[fieldName])) return true;
            return false;
        }

        private static string Prefix(string tabneName) => tabneName.ToLower() switch {
            "point" or "s100.point" => "P",
            "pointset" or "s100.pointset" => "M",
            "curve" or "s100.curve" => "C",
            "surface" or "s100.surface" => "S",
            "featuretype" or "s100.featuretype" => "F",
            "informationtype" or "s100.informationtype" => "I",
            _ => throw new NotImplementedException(),
        };

        //public static string Crc32(this Feature feature) => $"{System.IO.Hashing.Crc32.HashToUInt32(feature.GetGlobalID().ToByteArray())}";
        public static string UID(this Feature feature) => $"{Prefix(feature.GetTable().GetName())}{feature.GetObjectID()}";   // Convert.ToString(feature["UID"])!;

        //public static string Crc32(this Row row) => $"{System.IO.Hashing.Crc32.HashToUInt32(row.GetGlobalID().ToByteArray())}";
        public static string UID(this Row row) => $"{Prefix(row.GetTable().GetName())}{row.GetObjectID()}";   // Convert.ToString(row["UID"])!;
    }
}
