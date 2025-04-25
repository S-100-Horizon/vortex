using ArcGIS.Core.Geometry;
using S100Framework.Applications.S57.esri;
using System.Formats.Asn1;
using System.Xml.Linq;
namespace S100Framework.Applications
{
    public enum PrimitiveType
    {
        Point = 1,
        Line = 2,
        Area = 4
    }
    class NamedPolygon
    {
        public string Name { get; }
        public Polygon Polygon { get; }

        public NamedPolygon(string name, Polygon polygon) {
            Name = name;
            Polygon = polygon;
        }
    }

    public class Scamin
    {
        private static Scamin? _instance;
        private static readonly Dictionary<string, ScaminFile> _scaminFiles = new();
        private static readonly List<NamedPolygon> _polygons = new();
        private static readonly object _lock = new object();

        private Scamin(string pathToScaminFiles) {
            var sr = SpatialReferences.WGS84;


            // TODO: Get Scamin polygons and corresponding filenames from external datasource. Ie. database, geopackage, shapefiles etc.
            AddPolygon("SCAMIN_GST_Danmark.xml", new List<Coordinate2D>
            {
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
            }, sr);

            AddPolygon("SCAMIN_GST_Grønland.xml", new List<Coordinate2D>
            {
                new(58.0858105,83.9901370),
                new(0.7072854,  84.3437797),
                new(8.6642457,  72.2315178),
                new(42.4371219,54.9914371),
                new(76.2984087,74.6186059),
                new(76.2099980,78.8623181),
                new(58.0858105,83.9901370)
            }, sr);

            foreach (var filePath in Directory.GetFiles(pathToScaminFiles, "*.xml")) {
                var fileName = System.IO.Path.GetFileName(filePath);
                _scaminFiles.Add(System.IO.Path.GetFileName(fileName), new ScaminFile(System.IO.Path.Combine(pathToScaminFiles, fileName)));
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


        public int? GetMinimumScale(Geometry geometry, string subtypeName/*, string relatedStructureName*/, PrimitiveType primitiveType, int compilationScale, bool isRelatedToStructure = false) {
            var touched = GetTouchedPolygonNames(geometry);
            if (touched.Count != 1) {
                throw new ArgumentException("Cannot determine scamin");
                //return null;
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
        private XElement root;
        private List<ObjectData> _objects  = new();
        private List<int> _radarScales = new();
        private List<int> _scaminValues = new();

        internal ScaminFile(string filePath) {
            string xmlData = File.ReadAllText(filePath);
            root = XElement.Parse(xmlData);
            LoadObjects();
            LoadRadarScales();
            LoadScaminValues();
        }

        private void LoadRadarScales() {
            _radarScales = root.Descendants("RadarScale")
                       .Select(r => (int)r.Attribute("Value"))
                       .ToList();
        }

        private void LoadScaminValues() {
            _scaminValues = root.Descendants("SCAMIN")
                       .Select(s => (int)s.Attribute("Value"))
                       .ToList();
        }

        private void LoadObjects() {
            _objects = new List<ObjectData>();
            foreach (var o in root.Descendants("Object")) {
                var name = Convert.ToString(o.Attribute("Name"));
                var ptype = Convert.ToString(o.Attribute("PrimitiveType"));
                var condition = Convert.ToBoolean(o.Attribute("HasCondition"));
                var stepValue = Convert.ToString(o.Attribute("DefaultStepValue"));

                if (name == null) {
                    throw new ArgumentException("Empty name in scamin file");
                }
                if (ptype == null) {
                    throw new ArgumentException("empty PrimitiveType in scamin file");
                }
                if (stepValue == null) {
                    throw new ArgumentException("empty stepvalue in scamin file");
                }

                List<List<string>> conditions = new List<List<string>>();

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

                _objects.Add(new ObjectData {
                    Name = name,
                    PrimitiveType = ptype,
                    HasCondition = condition,
                    DefaultStepValue = stepValue,
                    Conditions = conditions,
                });
            }
        }

        private int? GetDefaultStepValueByName(string name, PrimitiveType primitiveType, bool isRelatedToStructure) {
            var obj = _objects.FirstOrDefault(obj => obj.Name.Equals(name,StringComparison.InvariantCultureIgnoreCase));
            if (obj == null) {
                return null;
            }

            // https://pro.arcgis.com/en/pro-app/latest/help/production/maritime/scale-minimum-radar-range-method.htm
            // if type = R - Related - Object receives same step as related structure else defaultStepValue (if stand alone)
            // if type = S - Spatially associated - Operator = "Cover" or operator = "Share" - receives StepValue accordingly
            // if type = A - Attribute value - 
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
            var closestScamin = _scaminValues
                                .OrderBy(v => Math.Abs(v - inputValue))
                                .FirstOrDefault();
            return closestScamin;
        }

        internal protected int? GetMinimumScale(string name, PrimitiveType primitiveType, int compilationScale, bool isRelatedToStructure) {
            var closestScamin = GetClosestScaminValue(compilationScale);

            var defaultStepValue = GetDefaultStepValueByName(name, primitiveType, isRelatedToStructure);

            var higherScamins = _scaminValues.Where(v => v >= closestScamin).Order<int>().ToArray<int>();

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
        public List<List<string>> Conditions { get; set; } = new List<List<string>>();
    }
}
