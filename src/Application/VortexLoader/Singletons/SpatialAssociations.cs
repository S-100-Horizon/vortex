using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using S100Framework.Applications.S57.esri;
using System.Globalization;
using System.Text.RegularExpressions;

namespace S100Framework.Applications.Singletons
{


    public class SpatialAssociations
    {
        private static SpatialAssociations _instance;
        private static readonly object _lock = new object();

        private static Dictionary<string, FeatureClass> _featureClasses = new();

        private static Geodatabase _geodatabase;

        private static Dictionary<string, (Guid globalId, int qualityOfPrecision, Geometry Shape)> _spatialAttributesL = new Dictionary<string, (Guid globalId, int qualityOfPrecision, Geometry Shape)>();

        private SpatialAssociations(Geodatabase geodatabase) {
            _geodatabase = geodatabase ?? throw new ArgumentNullException(nameof(geodatabase));

            using var plts_spatialattributelTable = _geodatabase.OpenDataset<FeatureClass>(_geodatabase.GetName("PLTS_SpatialAttributeL"));

            using var cursor = plts_spatialattributelTable.Search(null, true);

            int recordCount = 0;

            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;
                var plts_spatialattributel = new PLTS_SpatialAttributeL(feature);

                var wkt = ToWktWithDecimals(feature.GetShape(), 7);
                _spatialAttributesL.Add(wkt, (plts_spatialattributel.GLOBALID, plts_spatialattributel.P_QUAPOS.Value, plts_spatialattributel.SHAPE));
            }
            ;
        }

        public static string ToWktWithDecimals(Geometry geometry, int decimals) {
            if (geometry == null)
                throw new ArgumentNullException(nameof(geometry));
            if (decimals < 0)
                throw new ArgumentOutOfRangeException(nameof(decimals), "Decimals must be 0 or more.");

            string wkt = GeometryEngine.Instance.ExportToWKT(WktExportFlags.WktExportLineString, geometry);

            string pattern = @"-?\d+\.\d+|-?\d+";

            string result = Regex.Replace(wkt, pattern, match => {
                if (double.TryParse(match.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out double number)) {
                    double rounded = Math.Round(number, decimals);
                    string formatString = "F" + decimals;
                    return rounded.ToString(formatString, CultureInfo.InvariantCulture);
                }
                else {
                    return match.Value;
                }
            });

            return result;
        }

        internal List<(Guid globalId, int qualityOfPrecision, Geometry Shape)> GetSpatialAttributeL(Geometry geometry) {
            var intersects = new List<(Guid globalId, int qualityOfPrecision, Geometry Shape)>();

            var value = ToWktWithDecimals(geometry, 7);
            if (_spatialAttributesL.ContainsKey(value)) {
                intersects.Add(_spatialAttributesL[value]);
            }
            return intersects;
        }

        internal static void Initialize(Geodatabase geodatabase) {
            if (_instance != null) {
                throw new InvalidOperationException("SpatialAssociations has already been initialized.");
            }

            lock (_lock) {
                if (_instance == null) {
                    _instance = new SpatialAssociations(geodatabase);
                }
            }
        }

        internal static SpatialAssociations Instance {
            get {
                if (_instance == null) {
                    throw new InvalidOperationException("SpatialAssociations must be initialized before use.");
                }

                return _instance;
            }
        }


    }


}
