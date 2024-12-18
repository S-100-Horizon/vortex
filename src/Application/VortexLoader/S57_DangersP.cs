using ArcGIS.Core.Data;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_DangersP(Geodatabase source, Geodatabase target, QueryFilter filter) {
            Console.WriteLine("DangersP");

            using var s = source.OpenDataset<FeatureClass>("DangersP");
            using var point = target.OpenDataset<FeatureClass>("point");
            using var informationtype = target.OpenDataset<Table>("informationtype");

            using var bufferPoint = point.CreateRowBuffer();
            using var insertPoint = point.CreateInsertCursor();

            using var cursor = s.Search(filter, true);
            while (cursor.MoveNext()) {
                var current = (Feature)cursor.Current;
                var subtype = Convert.ToInt32(current["FCSubtype"]);

                switch (subtype) {
                    case 1: { // CTNARE
                        }
                        break;

                    case 10: { // FSHFAC
                        }
                        break;

                    case 20: { // OBSTRN
                        }
                        break;

                    case 35: { // UWTROC
                        }
                        break;

                    case 40: { // WATTUR
                        }
                        break;

                    case 45: { // WRECKS
                        }
                        break;
                }
            }
        }

    }
}
