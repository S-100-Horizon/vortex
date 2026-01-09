using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ArcGIS.Core.Internal.Geometry;

namespace S100Framework.Applications.Singletons
{
    public class Afterburner
    {
        private static Afterburner? _instance;
        private static readonly object _lock = new object();

        private static Geodatabase? _target;

        private static readonly Dictionary<string, (Guid globalId, int qualityOfPrecision, Geometry Shape)> _spatialAttributesL = [];

        private Afterburner(Geodatabase target) {
            _target = target ?? throw new ArgumentNullException(nameof(target));
        }

        internal static void Initialize(Geodatabase target) {
            if (_instance != null) {
                throw new InvalidOperationException("Afterburner has already been initialized.");
            }

            lock (_lock) {
                if (_instance == null) {
                    _instance = new Afterburner(target);
                }
            }
        }

        internal static Afterburner Instance {
            get {
                if (_instance == null) {
                    throw new InvalidOperationException("Afterburner must be initialized before use.");
                }

                return _instance;
            }
        }

        /// <summary>
        /// Checks sanity of drawing index for all features accross all datasets
        /// </summary>
        /// <returns>Error Count</returns>
        public int CutClosedRoadLines() {
            Int32 errorCount = 0;

            int recordCount = 0;

            using var featureClass = _target!.OpenDataset<FeatureClass>(_target.GetName("curve"));
            using var updateCursor = featureClass.CreateUpdateCursor(new QueryFilter() { WhereClause = "code = 'Road'" }, true);
            using var rowBuffer = featureClass.CreateRowBuffer();

            while (updateCursor.MoveNext()) {
                recordCount++;
                var feature = (Feature)updateCursor.Current;

                var currentPolyline = (Polyline)feature.GetShape();

                if (IsClosedPolyline(currentPolyline)) {
                    var splitResult = SplitAtMidpoint(currentPolyline);

                    if (splitResult == null || splitResult.Count != 2) {
                        Logger.Current.DataError(feature.GetObjectID(), "curve", feature.UID(), $"Cannot split closingline in two. Check geometry for this curve.");
                        continue;
                    }

                    // Set shape to first half
                    feature.SetShape(splitResult[0]);

                    // Create new feature with second half
                    using (Feature newFeature = featureClass.CreateRow(rowBuffer)) {
                        newFeature.SetShape(splitResult[1]);

                        // Copy attributes (except ObjectID)
                        foreach (Field field in featureClass.GetDefinition().GetFields()) {
                            if (field.FieldType == FieldType.OID ||
                                field.FieldType == FieldType.Geometry ||
                                field.FieldType == FieldType.GlobalID) {
                                continue;
                            }
                            if (field.IsEditable) {
                                newFeature[field.Name] = feature[field.Name];
                            }
                        }

                        newFeature.Store();
                        Logger.Current.DataError(feature.GetObjectID(), "curve", feature.UID(), $"Split this feature in 2. Closing line on input. NewFeature name is {feature.GetGlobalID():N}");
                    }
                }
            }
            return errorCount;
        }

        private static bool IsClosedPolyline(Polyline polyline, double tolerance = 0.001) {
            MapPoint start = polyline.Points.First();
            MapPoint end = polyline.Points.Last();

            return GeometryEngine.Instance.Equals(start, end);
        }

        public static IReadOnlyList<Polyline> SplitAtMidpoint(Polyline polyline) {
            if (polyline == null || polyline.IsEmpty)
                return null!;

            var spatialRef = polyline.SpatialReference;

            double totalLength = GeometryEngine.Instance.Length(polyline);

            var locationResult = GeometryEngine.Instance.QueryPoint(polyline, SegmentExtensionType.NoExtension, totalLength / 2, AsRatioOrLength.AsLength);

            if (locationResult == null) {
                return null!;
            }

            MapPoint midpoint = MapPointBuilder.CreateMapPoint(locationResult.X, locationResult.Y, locationResult.Z, polyline.SpatialReference);

            double offset = 0.0001;

            var pt1 = MapPointBuilder.CreateMapPoint(midpoint.X, midpoint.Y - offset, spatialRef);
            var pt2 = MapPointBuilder.CreateMapPoint(midpoint.X, midpoint.Y + offset, spatialRef);
            var cutter = PolylineBuilder.CreatePolyline(new[] { pt1, pt2 }, spatialRef);


            var cutResult = GeometryEngine.Instance.Cut(polyline, cutter);

            if (cutResult == null || cutResult.Count != 2)
                return null!;

            return cutResult
                .Select(part => PolylineBuilder.CreatePolyline(part as Polyline, spatialRef))
                .ToList();
        }
    }
}
