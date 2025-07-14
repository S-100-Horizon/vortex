using ArcGIS.Core.CIM;
using ArcGIS.Core.Data;
using ArcGIS.Core.Data.UtilityNetwork.Trace;
using ArcGIS.Core.Geometry;
using ArcGIS.Desktop.Internal.Core.Conda;
//using ArcGIS.Desktop.Internal.Editing.COGO;
using S100Framework.Applications;
using S100Framework.Applications.S57.esri;
using S100Framework.DomainModel.S201.FeatureTypes;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace S100Framework.Applications.Singletons
{
    public class SanityChecker
    {
        private static SanityChecker _instance;
        private static readonly object _lock = new object();

        private static Geodatabase _geodatabase;

        private static Dictionary<string, (Guid globalId, int qualityOfPrecision, Geometry Shape)> _spatialAttributesL = new Dictionary<string, (Guid globalId, int qualityOfPrecision, Geometry Shape)>();

        private SanityChecker(Geodatabase geodatabase) {
            _geodatabase = geodatabase ?? throw new ArgumentNullException(nameof(geodatabase));
        }

        internal static void Initialize(Geodatabase geodatabase) {
            if (_instance != null) {
                throw new InvalidOperationException("SpatialAssociations has already been initialized.");
            }

            lock (_lock) {
                if (_instance == null) {
                    _instance = new SanityChecker(geodatabase);
                }
            }
        }

        internal static SanityChecker Instance {
            get {
                if (_instance == null) {
                    throw new InvalidOperationException("SpatialAssociations must be initialized before use.");
                }

                return _instance;
            }
        }

        /// <summary>
        /// Checks sanity of drawing index for all features accross all datasets
        /// </summary>
        /// <returns>Error Count</returns>
        public int Check_DrawingIndex() {
            Int32 errorCount = 0;

            var featureClasses = new List<string>() {
                "curve",
                "point",
                "surface",
                "pointset"
            };
            int recordCount = 0;

            foreach (var featureclassName in featureClasses) {
                using var featureClass = _geodatabase.OpenDataset<FeatureClass>(_geodatabase.GetName(featureclassName));

                using var cursor = featureClass.Search(new QueryFilter() { WhereClause = "1=1" }, true);

                while (cursor.MoveNext()) {
                    recordCount++;
                    var feature = cursor.Current;
                    int? drawingIndex = default;

                    if (DBNull.Value != feature["drawingindex"] && feature["drawingindex"] is not null) {
                        drawingIndex = Convert.ToInt32(feature["drawingindex"]);
                    }

                    if (!drawingIndex.HasValue) {
                        errorCount++;
                    }
                }
            }
            return errorCount;
        }
    }


}
