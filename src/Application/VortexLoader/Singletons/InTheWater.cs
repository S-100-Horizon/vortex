using ArcGIS.Core.Geometry;
using S100Framework.DomainModel.S101.FeatureTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.Applications.Singletons
{
    internal sealed class LandAreas
    {
        private static LandAreas _instance;
        private static readonly object _lock = new object();

        private readonly List<Geometry> _polygons = new List<Geometry>();


        internal static void Initialize() {
            if (_instance != null) {
                throw new InvalidOperationException("Subtypes has already been initialized.");
            }

            lock (_lock) {
                if (_instance == null) {
                    _instance = new LandAreas();
                }
            }
        }

        private LandAreas() {

        }

        public static LandAreas Instance {
            get {
                if (_instance == null)
                    Initialize();
                return _instance;
            }
        }


        /// <summary>
        /// Adds a polygon geometry to the collection.
        /// </summary>
        public void Add(Geometry polygon) {
            if (polygon == null)
                throw new ArgumentNullException(nameof(polygon));

            if (polygon.GeometryType != GeometryType.Polygon)
                throw new ArgumentException("Only polygon geometries are supported.");

            _polygons.Add(polygon);
        }

        /// <summary>
        /// Returns all polygons from the collection that touch the specified geometry.
        /// </summary>
        public IEnumerable<Geometry> Touch(Geometry geometry) {
            if (geometry == null)
                throw new ArgumentNullException(nameof(geometry));

            return _polygons.Where(p =>
                GeometryEngine.Instance.Touches(p, geometry) ||
                GeometryEngine.Instance.Intersects(p, geometry));
        }

    }
}


