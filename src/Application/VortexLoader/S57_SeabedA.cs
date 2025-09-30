using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_SeabedA(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "SeabedA";

            using var seabedA = source.OpenDataset<FeatureClass>(source.GetName(tableName));
            Subtypes.Instance.RegisterSubtypes(seabedA);

            using var featureClass = target.OpenDataset<FeatureClass>(target.GetName("surface"));

            using var buffer = featureClass.CreateRowBuffer();

            using var cursor = seabedA.Search(filter, true);
            int recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new SeabedA(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;

                if (FeatureRelations.Instance.IsSlave(globalid)) {
                    continue;
                }

                if (ConversionAnalytics.Instance.IsConverted(globalid)) {
                    throw new Exception("Ups. Not supported");
                }



                var fcSubtype = current.FCSUBTYPE ?? default;
                var watlev = current.WATLEV ?? default;
                var catweed = current.CATWED ?? default;
                var natsur = current.NATSUR ?? default;
                var natqua = current.NATQUA ?? default;

                // TODO: natsur, natqua

                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;

                switch (fcSubtype) {
                    case 15: { // SBDARE_SeabedArea
                            throw new NotImplementedException($"No SBDARE_SeabedArea in DK or GL. {tableName}");
                        }
                    case 30: { // SNDWAV_SandWaves
                            throw new NotImplementedException($"No SNDWAV_SandWaves in DK or GL. {tableName}");
                        }
                    case 40: { // WEDKLP_WeedKelp
                            throw new NotImplementedException($"No WEDKLP_WeedKelp in DK or GL. {tableName}");
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
