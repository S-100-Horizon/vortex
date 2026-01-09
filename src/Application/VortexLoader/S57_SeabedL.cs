using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_SeabedL(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "SeabedL";
            var seabedL = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(seabedL);


            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("curve"));

            using var buffer = featureClass.CreateRowBuffer();

            using var cursor = seabedL.Search(filter, true);
            int recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;
                var current = new SeabedL(feature);
                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (FeatureRelations.Instance.IsSlave(globalid)) {
                    continue;
                }

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    throw new Exception("Ups. Not supported");
                }



                var fcSubtype = current.FCSUBTYPE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;

                switch (fcSubtype) {
                    case 10: { // SBDARE_SeabedArea
                            throw new NotImplementedException($"No SBDARE_SeabedArea in DK or GL. {tableName}");
                        }
                    case 15: { // SNDWAV_SandWaves
                            throw new NotImplementedException($"No SNDWAV_SandWaves in DK or GL. {tableName}");
                        }
                    default:
                        throw new NotSupportedException($"SeabedL subtype:{fcSubtype}");
                }
            }
            Logger.Current.DataTotalCount(tableName, recordCount, ConversionAnalytics.Instance.GetConvertedCount(tableName));
        }


    }
}
