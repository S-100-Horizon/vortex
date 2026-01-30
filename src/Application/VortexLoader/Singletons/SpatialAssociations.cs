using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using S100Framework.Applications.S57.esri;
using System.Globalization;
using System.Text.RegularExpressions;

namespace S100Framework.Applications.Singletons
{


    public class SpatialAssociations
    {
        const int P_QUAPOS_approximate = 4;

        private static SpatialAssociations? _instance;
        private static readonly object _lock = new object();

        private static readonly Dictionary<string, FeatureClass> _featureClasses = [];

        private static Geodatabase? _geodatabase;

        private static readonly Dictionary<string, (Guid globalId, int qualityOfPrecision, Geometry Shape)> _spatialAttributesL = [];

        private SpatialAssociations(Geodatabase geodatabase, QueryFilter filter) {
            _geodatabase = geodatabase ?? throw new ArgumentNullException(nameof(geodatabase));
            _spatialAttributesL.Clear();

            using var plts_spatialattributelTable = _geodatabase.OpenDataset<FeatureClass>(_geodatabase.GetName("PLTS_SpatialAttributeL"));

            using var cursor = plts_spatialattributelTable.Search(filter, true);

            int recordCount = 0;
            int errorCount = 0;
            while (cursor.MoveNext()) {
                recordCount += 1;
                var feature = (Feature)cursor.Current;
                var plts_spatialattributel = new PLTS_SpatialAttributeL(feature);


                var shape = feature.GetShape();

                Polyline[] polylines = [];
                if (shape is Polyline polyline) {
                    foreach (var polylinePart in polyline.Parts) {
                        polylines = [.. polylines, PolylineBuilderEx.CreatePolyline(polylinePart)];
                    }
                }
                else
                    throw new Exception($"Share geometry type not supported ({shape.GeometryType})");


                foreach (var p in polylines) {
                    var wkt = ToWktWithDecimals(p, 7);

                    if (_spatialAttributesL.ContainsKey(wkt)) {
                        errorCount++;
                        Console.WriteLine($"{plts_spatialattributel.OBJECTID!.Value}::{plts_spatialattributel.LNAM}::{plts_spatialattributel.GlobalId}");
                        Logger.Current.DataError(plts_spatialattributel.OBJECTID!.Value, "PLTS_SpatialAttributeL", plts_spatialattributel.LNAM!, $"Duplicate geometry. Ignoring this element");
                        //throw new Exception("Multiple spatialattributeL in same band");
                        continue;

                    }

                    var quapos = plts_spatialattributel.P_QUAPOS.HasValue ? plts_spatialattributel.P_QUAPOS.Value : P_QUAPOS_approximate;
                    _spatialAttributesL.Add(wkt, (plts_spatialattributel.GLOBALID!, quapos, plts_spatialattributel.SHAPE!));
                }
            }
            ;
        }

        public static string ToWktWithDecimals(Geometry geometry, int decimals) {
            if (geometry == null)
                throw new ArgumentNullException(nameof(geometry));
            if (decimals < 0)
                throw new ArgumentOutOfRangeException(nameof(decimals), "Decimals must be 0 or more.");

            string wkt = GeometryEngine.Instance.ExportToWKT(WktExportFlags.WktExportDefaults, geometry);

            string pattern = @"-?\d+\.\d+|-?\d+";

            string result = Regex.Replace(wkt, pattern, match => {
                if (decimal.TryParse(match.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal number)) {
                    decimal rounded = Math.Round(number, decimals);
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

        internal static void Initialize(Geodatabase geodatabase, QueryFilter filter) {
            if (_instance != null) {
                throw new InvalidOperationException("SpatialAssociations has already been initialized.");
            }

            lock (_lock) {
                if (_instance == null) {
                    _instance = new SpatialAssociations(geodatabase, filter);
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
