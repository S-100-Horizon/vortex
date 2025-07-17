namespace ArcGIS.Core.Data
{
    public static class Extension
    {
        public static bool IsNull(this Feature? feature, string fieldName) {
            if (feature == null) return true;
            if (feature[fieldName] == null) return true;
            if (DBNull.Value.Equals(feature[fieldName])) return true;
            return false;
        }
    }
}
