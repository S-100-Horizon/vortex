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
    }
}
