using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_MilitaryFeaturesP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "MilitaryFeaturesP";

            using var militaryFeaturesP = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(militaryFeaturesP);

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("point"));


            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = militaryFeaturesP.Search(filter, true);
            int recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new MilitaryFeaturesP(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    continue;
                }


                var fcSubtype = current.FCSUBTYPE ?? default;
                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;
                var status = current.STATUS ?? default;

                switch (fcSubtype) {

                    case 30: { // MIPARE_MilitaryPracticeArea
                            throw new NotImplementedException($"No MIPARE_MilitaryPracticeArea in DK or GL. {tableName}");
                        }
                    default:
                        // code block
                        System.Diagnostics.Debugger.Break();
                        break;
                }

            }
            Logger.Current.DataTotalCount(tableName, recordCount, ConversionAnalytics.Instance.GetConvertedCount(tableName));
        }


    }
}
