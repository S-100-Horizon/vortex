using ArcGIS.Core.Geometry;
using System.Xml.Linq;

namespace S100Framework.Applications.Singletons
{
    public enum PrimitiveType
    {
        Point = 1,
        Line = 2,
        Area = 4
    }

    internal class NamedPolygon
    {
        public string Name { get; }
        public Polygon Polygon { get; }

        public NamedPolygon(string name, Polygon polygon) {
            this.Name = name;
            this.Polygon = polygon;
        }
    }

    public class Scamin
    {
        private static Scamin? _instance;
        private static readonly Dictionary<string, ScaminFile> _scaminFiles = [];
        internal static readonly List<NamedPolygon> _polygons = [];
        private static readonly object _lock = new object();

        private Scamin(string pathToScaminFiles) {
            var sr = SpatialReferences.WGS84;

            // TODO: Get Scamin polygons and corresponding filenames from external datasource. Ie. database, geopackage, shapefiles etc.
            AddPolygon("SCAMIN_GST_Danmark.xml",
            [
                new(14.8303810, 55.8645445),
                new(16.8899873, 55.8827711),
                new(16.8596097, 54.4003405),
                new(11.8350354, 54.2466303),
                new(7.3817750,  54.4307182),
                new(3.2261091,  55.6883540),
                new(3.2807889,  57.0188961),
                new(10.0732371, 58.4405713),
                new(12.0217782, 57.3854226),
                new(12.4852245, 56.3505873),
                new(14.8303810, 55.8645445)
            ], sr);

            AddPolygon("SCAMIN_GST_Grønland.xml",
            [
                new(-22.4155794, 84.4901456),
                new(-8.7395659,  83.1641702),
                new(-10.8451051, 75.0614524),
                new(-25.3660133, 67.1312766),
                new(-38.0642680, 55.4914457),
                new(-47.4617647, 55.8032143),
                new(-71.8371442, 72.7315264),
                new(-79.7941045, 84.8437883),
                new(-22.4155794, 84.4901456)
            ], sr);

            // TODO: Add US scamin file...
            AddPolygon("SCAMIN_GST_Grønland.xml",
            [
                new(-138.5403112, 53.7017463),
                new(-122.5440356, 61.2520361),
                new(-55.9168726,  62.1953461),
                new(-49.1210053,  59.9472275),
                new(-33.6216590,  54.2626086),
                new(-34.6946907,  35.0262922),
                new(-56.2745498,  36.1894478),
                new(-70.5816387,  24.9270265),
                new(-94.4267869,  9.1413510),
                new(-112.1914224, 7.1350314),
                new(-133.7712815, 28.5463887)
            ], sr);

            foreach (var filePath in Directory.GetFiles(pathToScaminFiles, "*.xml")) {
                var fileName = Path.GetFileName(filePath);
                _scaminFiles.Add(Path.GetFileName(fileName), new ScaminFile(Path.Combine(pathToScaminFiles, fileName)));
            }
        }

        public static Scamin Instance {
            get {
                if (_instance == null) {
                    {
                        lock (_lock) {
                            _instance = new Scamin(ImporterNIS._scaminFilesPath);
                        }
                    }
                }
                return _instance;
            }
        }

        internal List<NamedPolygon> Polygons {
            get => _polygons;
        }

        internal int? GetMinimumScale(S100Framework.Applications.S57.esri.S57Object feature, string subtypeName/*, string relatedStructureName*/, int compilationScale, bool isRelatedToStructure = false) {
            if (feature.SCAMIN_STEP.HasValue) {
                var scamin = feature.SCAMIN_STEP.Value;
                if (scamin > 10)
                    return scamin;

                //TODO: SCAMIN_step ?
            }

            var geometry = feature.Shape!;
            var touched = GetTouchedPolygonNames(geometry);
            if (touched.Count != 1) {
                throw new ArgumentException("Cannot determine scamin");
                //return null;
            }

            var primitiveType = PrimitiveType.Line;

            switch (geometry.GeometryType) {
                case GeometryType.Unknown:
                    throw new NotSupportedException("Unknown geometry type");
                case GeometryType.Point:
                    primitiveType = PrimitiveType.Point;
                    break;
                case GeometryType.Envelope:
                    throw new NotSupportedException("Unknown geometry type");
                case GeometryType.Multipoint:
                    throw new NotSupportedException("Unknown geometry type");
                case GeometryType.Polyline:
                    primitiveType = PrimitiveType.Line;
                    break;
                case GeometryType.Polygon:
                    primitiveType = PrimitiveType.Area;
                    break;
                case GeometryType.Multipatch:
                    throw new NotSupportedException("Unknown geometry type");
                case GeometryType.GeometryBag:
                    throw new NotSupportedException("Unknown geometry type");
                default:
                    throw new NotSupportedException("Unknown geometry type");
            }

            return _scaminFiles[touched[0]].GetMinimumScale(subtypeName, primitiveType, compilationScale, isRelatedToStructure);
        }

        /// <summary>
        /// Adds the polygon
        /// </summary>
        /// <param xmlFileName="xmlFileName"></param>
        /// <param xmlFileName="points">Coordinate2D points</param>
        /// <param xmlFileName="spatialReference">The spatial reference</param>
        private static void AddPolygon(string xmlFileName, IReadOnlyList<Coordinate2D> points, SpatialReference spatialReference) {
            var builder = new PolygonBuilderEx(spatialReference);
            builder.AddPart(points);
            var polygon = builder.ToGeometry();
            _polygons.Add(new NamedPolygon(xmlFileName, polygon));
        }

        private static List<string> GetTouchedPolygonNames(Geometry inputGeometry) {
            var touchedPolygons = new List<string>();

            foreach (var np in _polygons) {
                // Check if inputGeometry touches the polygon
                if (GeometryEngine.Instance.Touches(inputGeometry, np.Polygon) ||
                    GeometryEngine.Instance.Intersects(inputGeometry, np.Polygon)) {
                    touchedPolygons.Add(np.Name);
                }
            }

            return touchedPolygons;
        }
    }

    internal class ScaminFile
    {
        private readonly XElement root;
        private List<ObjectData> _objects = [];
        private List<int> _radarScales = [];
        private List<int> _scaminValues = [];

        internal ScaminFile(string filePath) {
            var xmlData = File.ReadAllText(filePath);
            this.root = XElement.Parse(xmlData);
            this.LoadObjects();
            this.LoadRadarScales();
            this.LoadScaminValues();
        }

        private void LoadRadarScales() {
            this._radarScales = this.root.Descendants("RadarScale")
                       .Select(r => Convert.ToInt32(r.Attribute("Value")?.Value))
                       .ToList();
        }

        private void LoadScaminValues() {
            this._scaminValues = this.root.Descendants("SCAMIN")
                       .Select(s => Convert.ToInt32(s.Attribute("Value")?.Value))
                       .ToList();
        }

        private void LoadObjects() {
            this._objects = [];
            foreach (var o in this.root.Descendants("Object")) {
                var name = Convert.ToString(o.Attribute("Name")?.Value);
                var ptype = Convert.ToString(o.Attribute("PrimitiveType")?.Value);
                var condition = Convert.ToBoolean(o.Attribute("HasCondition")?.Value);
                var stepValue = Convert.ToString(o.Attribute("DefaultStepValue")?.Value);

                if (name == null) {
                    throw new ArgumentException("Empty name in scamin file");
                }
                if (ptype == null) {
                    throw new ArgumentException("empty PrimitiveType in scamin file");
                }
                if (stepValue == null) {
                    throw new ArgumentException("empty stepvalue in scamin file");
                }

                var conditions = new List<List<string>>();

                foreach (var c in o.Descendants("Condition")) {
                    var rules = new List<string>();
                    foreach (var e in c.Descendants("Rule")) {
                        var ruleType = Convert.ToString(e.Attribute("Type"));
                        if (ruleType != null) {
                            rules.Add(ruleType);
                        }
                    }
                    conditions.Add(rules);
                }

                this._objects.Add(new ObjectData {
                    Name = name,
                    PrimitiveType = ptype,
                    HasCondition = condition,
                    DefaultStepValue = stepValue,
                    Conditions = conditions,
                });
            }
        }

        private int? GetDefaultStepValueByName(string name, PrimitiveType primitiveType, bool isRelatedToStructure) {
            var obj = this._objects.FirstOrDefault(o => o.Name != null && o.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

            if (obj == null) {
                return null;
            }

            // https://pro.arcgis.com/en/pro-app/latest/help/production/maritime/scale-minimum-radar-range-method.htm
            // if _s101type = R - Related - Object receives same step as related structure else defaultStepValue (if stand alone)
            // if _s101type = S - Spatially associated - Operator = "Cover" or operator = "Share" - receives StepValue accordingly
            // if _s101type = A - Attribute value -
            {
                if (!isRelatedToStructure) {
                    if (int.TryParse(obj.DefaultStepValue, out var defaultStepValue)) {
                        return defaultStepValue;
                    }
                    else {
                        return null;
                    }
                }
            }
            {
                // TODO: implement scamin conditions. For now returning null if
                if (obj.HasCondition) {
                    return null;
                }

                if (int.TryParse(obj.DefaultStepValue, out var defaultStepValue)) {
                    return defaultStepValue;
                }
                else {
                    return null;
                }
            }
        }

        internal int GetClosestScaminValue(int inputValue) {
            var closestScamin = this._scaminValues
                                .OrderBy(v => Math.Abs(v - inputValue))
                                .FirstOrDefault();
            return closestScamin;
        }

        protected internal int? GetMinimumScale(string name, PrimitiveType primitiveType, int compilationScale, bool isRelatedToStructure) {
            var closestScamin = this.GetClosestScaminValue(compilationScale);

            var defaultStepValue = this.GetDefaultStepValueByName(name, primitiveType, isRelatedToStructure);

            var higherScamins = this._scaminValues.Where(v => v >= closestScamin).Order().ToArray();

            int? index = null;

            if (defaultStepValue.HasValue && defaultStepValue.Value > 0)
                index = defaultStepValue.Value;
            else {
                return null;
            }
            return higherScamins[index.Value];
        }
    }

    internal class ObjectData
    {
        public string? Name { get; set; }
        public string? PrimitiveType { get; set; }
        public bool HasCondition { get; set; }
        public string? DefaultStepValue { get; set; }
        public List<List<string>> Conditions { get; set; } = [];
    }
}