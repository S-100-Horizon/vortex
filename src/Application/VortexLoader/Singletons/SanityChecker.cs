using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;

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
                throw new InvalidOperationException("SanityChecker has already been initialized.");
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
                    throw new InvalidOperationException("SanityChecker must be initialized before use.");
                }

                return _instance;
            }
        }

        /// <summary>
        /// Checks sanity of drawing index for all features accross all datasets
        /// </summary>
        /// <returns>Error Count</returns>
        public int Check_GetUsageBandErrorCount() {
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
                    int? usageband = default;

                    if (DBNull.Value != feature["usageband"] && feature["usageband"] is not null) {
                        usageband = Convert.ToInt32(feature["usageband"]);
                    }

                    if (!usageband.HasValue) {
                        errorCount++;
                    }
                }
            }
            return errorCount;
        }

        /// <summary>
        /// Checks sanity of Esri unknown values accross all datasets
        /// </summary>
        /// <returns>Error Count</returns>
        public int Check_GetEsriUnknown32767ErrorCount() {
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
                    string? jsonValue = feature["json"]?.ToString();

                    if (jsonValue != default && jsonValue.Contains("-32767")) {
                        errorCount++;
                    }
                }
            }
            return errorCount;
        }

        internal int Check_GetEditionsErrorCount() {
            Int32 errorCount = 0;

            var featureClasses = new List<string>() {
                "curve",
                "point",
                "surface",
                "pointset",
                "attachment",
                "configuration",
                "featureassociation",
                "featuretype",
                "informationassociation",
                "informationtype",
                "messages"
            };
            int recordCount = 0;

            foreach (var featureclassName in featureClasses) {
                using var featureClass = _geodatabase.OpenDataset<Table>(_geodatabase.GetName(featureclassName));

                using var cursor = featureClass.Search(new QueryFilter() { WhereClause = "1=1" }, true);

                while (cursor.MoveNext()) {
                    recordCount++;
                    var feature = cursor.Current;
                    var edition = feature["edition"];
                    if (edition == null || edition == DBNull.Value || string.IsNullOrEmpty(edition.ToString()))
                        errorCount++;
                }
            }
            return errorCount;
        }

        internal int Check_GetDefaultClearanceViolationCount() {
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
                    var json = feature["json"].ToString()!.ToLower();

                    if (json.Contains("\"defaultclearancedepth\":null") && json.Contains("\"valueofsounding\":null"))
                        errorCount++;
                }
            }
             return errorCount;

        }



    }


}
