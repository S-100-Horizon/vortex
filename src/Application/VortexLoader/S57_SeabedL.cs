using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class ImporterNIS
    {
        private static void S57_SeabedL(Geodatabase source, Geodatabase target, QueryFilter filter) {
            var tableName = "SeabedL";

            var ps101 = "S-101";

            var seabedL = source.OpenDataset<FeatureClass>(tableName);

            using var featureClass = target.OpenDataset<FeatureClass>(LayerDefinitions.GetName("curve"));


            using var buffer = featureClass.CreateRowBuffer();
            using var insert = featureClass.CreateInsertCursor();

            using var cursor = seabedL.Search(filter, true);
            int recordCount = 0;
            int convertedCount = 0;
            while (cursor.MoveNext()) {
                recordCount += 1;

                var feature = (Feature)cursor.Current;

                var current = new SeabedA(feature);

                var objectid = current.OBJECTID ?? default;
                var globalid = current.GLOBALID;
                var subtype = current.FCSUBTYPE ?? default;
                var watlev = current.WATLEV ?? default;

                var natsur = current.NATSUR ?? default;
                var natqua = current.NATQUA ?? default;

                // TODO: natsur, natqua


                var plts_comp_scale = current.PLTS_COMP_SCALE ?? default;
                var longname = current.LNAM ?? Strings.UNKNOWN;



                switch (subtype) {
                }



            }
            Logger.Current.DataTotalCount(tableName, recordCount, convertedCount);
        }


    }
}
