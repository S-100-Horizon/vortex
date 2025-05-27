using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.Applications.Singletons;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_TidesAndVariationsL(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "TidesAndVariationsL";

            using var tidesAndVariationsA = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(tidesAndVariationsA);

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("surface"));


            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = tidesAndVariationsA.Search(filter, true);
            int recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new TracksAndRoutesA(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    continue;
                }

                var fcSubtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;

                //switch (fcSubtype) {
                throw new NotImplementedException("No TidesAndVariationLs in DK | GL NIS");
                //}
            }
            Logger.Current.DataTotalCount(tableName, recordCount, ConversionAnalytics.Instance.GetConvertedCount(tableName));
        }


    }
}
