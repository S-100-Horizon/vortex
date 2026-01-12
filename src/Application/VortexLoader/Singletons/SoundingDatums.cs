using ArcGIS.Core.Geometry;

namespace S100Framework.Applications.Singletons
{
    internal sealed class SoundingDatums
    {
        private static SoundingDatums? _instance;
        private static readonly object _lock = new object();

        private readonly List<(Geometry, S100FC.S101.SimpleAttributes.verticalDatum)> _polygons = [];


        internal static void Initialize() {
            if (_instance != null) {
                throw new InvalidOperationException("Subtypes has already been initialized.");
            }

            lock (_lock) {
                if (_instance == null) {
                    _instance = new SoundingDatums();
                }
            }
        }

        private SoundingDatums() {

        }

        public static SoundingDatums Instance {
            get {
                if (_instance == null)
                    Initialize();
                return _instance!;
            }
        }


        /// <summary>
        /// Adds a polygon geometry to the collection.
        /// </summary>
        public void Add(Geometry polygon, S100FC.S101.SimpleAttributes.verticalDatum vdat) {
            if (polygon == null)
                throw new ArgumentNullException(nameof(polygon));

            if (polygon.GeometryType != GeometryType.Polygon)
                throw new ArgumentException("Only polygon geometries are supported.");

            this._polygons.Add((polygon, vdat));
        }

        /// <summary>
        /// Returns all polygons from the collection that touch the specified geometry.
        /// </summary>
        public IEnumerable<(Geometry, S100FC.S101.SimpleAttributes.verticalDatum)> Touch(Geometry geometry) {
            if (geometry == null)
                throw new ArgumentNullException(nameof(geometry));

            return this._polygons.Where(p =>
                GeometryEngine.Instance.Touches(p.Item1, geometry) ||
                GeometryEngine.Instance.Intersects(p.Item1, geometry));
        }

    }
}


