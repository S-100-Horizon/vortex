using S100Framework.DomainModel;
using System.Globalization;
using YamlDotNet.Serialization;

namespace S100Framework.YAML
{
    public enum Primitive
    {
        Point = 1,
        Curve = 2,
        Surface = 3,
    }

    public class Dataset
    {
        public string CellName { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public uint? Edition { get; set; }
        public uint? Update { get; set; }
        [YamlMember(Alias = "encver", ApplyNamingConventions = false)]
        public string ENCVer { get; set; } = "INT.IHO.S-101.2.0";
        public string? FCVer { get; set; } = default;

        public ICollection<Information>? InformationTypes => _informationTypes.Any() ? _informationTypes : null;
        public ICollection<Point>? Points => _points.Any() ? _points : null;
        public ICollection<Curve>? Curves => _curves.Any() ? _curves : null;
        public ICollection<CompositeCurve>? CompositeCurves => _compositeCurves.Any() ? _compositeCurves : null;
        public ICollection<PointSet>? Depths => _pointSets.Any() ? _pointSets : null;
        public ICollection<Surface>? Surfaces => _surfaces.Any() ? _surfaces : null;
        public ICollection<Feature>? Features => _features.Any() ? _features : null;

        private ICollection<Information> _informationTypes = new HashSet<Information>();
        private ICollection<Point> _points = new HashSet<Point>();
        private ICollection<PointSet> _pointSets = new HashSet<PointSet>();
        private ICollection<Curve> _curves = new HashSet<Curve>();
        private ICollection<CompositeCurve> _compositeCurves = new HashSet<CompositeCurve>();
        private ICollection<Surface> _surfaces = new HashSet<Surface>();
        private ICollection<Feature> _features = new HashSet<Feature>();

        public Dataset AddPoint(Point point) {
            _points.Add(point);
            return this;
        }
        public Dataset AddPointSet(PointSet pointSet) {
            _pointSets.Add(pointSet);
            return this;
        }
        public Dataset AddCurve(Curve curve) {
            _curves.Add(curve);
            return this;
        }
        public Dataset AddCompositeCurve(CompositeCurve compositeCurve) {
            _compositeCurves.Add(compositeCurve);
            return this;
        }

        public Dataset AddSurface(Surface surface) {
            _surfaces.Add(surface);
            return this;
        }

        public Dataset AddFeature(Feature feature) {
            _features.Add(feature);
            return this;
        }

        public Dataset AddInformation(Information information) {
            _informationTypes.Add(information);
            return this;
        }
    }

    public class Point(double x, double y)
    {
        public string? Name { get; set; }

        public string? Location => Coordinate is null ? string.Empty : string.Format(CultureInfo.InvariantCulture, "{0:0.0000000},{1:0.0000000}", Coordinate.Y, Coordinate.X);

        [YamlIgnore]
        public Coordinate? Coordinate { get; private set; } = new Coordinate(x, y);
    }

    public class PointSet(Coordinate[] points, double[] depths)
    {
        public string? Name { get; set; }
        public string? Location => Points is null ? string.Empty : string.Join(",", Points.Select(e => string.Format(CultureInfo.InvariantCulture, "{0:0.0000000},{1:0.0000000}", e.Y, e.X)));
        public string? Z => Depths is null ? string.Empty : string.Join(",", Depths.Select(e => e.ToString(CultureInfo.InvariantCulture)));

        [YamlIgnore]
        public double[] Depths { get; private set; } = depths;

        [YamlIgnore]
        public Coordinate[] Points { get; private set; } = points;
    }

    public class Curve
    {
        private Point? _start;
        private Point? _end;

        public Curve(Coordinate[] vertices) {
            Coordinate = vertices;
        }

        public Curve(Point start, Coordinate[] vertices) {
            _start = start;
            Coordinate = vertices;
        }

        public Curve(Point start, Point end, Coordinate[] vertices) {
            _start = start;
            _end = end;
            Coordinate = vertices;
        }

        public string? Name { get; set; }

        public string? Start => _start?.Name ?? null;

        public string? End => _end?.Name ?? null;

        public string? Vertices => Coordinate is null ? string.Empty : string.Join(",", Coordinate.Select(e => string.Format(CultureInfo.InvariantCulture, "{0:0.0000000},{1:0.0000000}", e.Y, e.X)));

        [YamlIgnore]
        public Coordinate[]? Coordinate { get; private set; }
    }

    public class CompositeCurve
    {
        public string? Name { get; set; }

        public string? Components => Curves is null ? null : string.Join(',', Curves.Select(e => e.Name));

        [YamlIgnore]
        public Curve[]? Curves { get; private set; }
    }

    public class Surface(Curve exterior)
    {
        public string? Name { get; set; }

        public string? Exterior => ExteriorRing.Name;

        public dynamic[]? Interior => InteriorRings.Length == 0 ? null : InteriorRings?.Select(e => new { Hole = e.Name }).ToArray();

        [YamlIgnore]
        public Curve ExteriorRing { get; set; } = exterior;

        [YamlIgnore]
        public Curve[] InteriorRings { get; set; } = [];
    }

    public class Coordinate(double x, double y)
    {
        public double X { get; set; } = x;
        public double Y { get; set; } = y;
    }

    public class Information
    {
        public string? Name { get; set; }
        public string? ID { get; set; }
        public InformationNode? Attributes { get; set; }
    }

    public class Feature
    {
        public string? Name { get; set; }
        public Primitive Prim { get; set; }
        public string? Foid { get; set; }
        public FeatureNode? Attributes { get; set; }
        public string? Geometry { get; set; }

        public ICollection<Association>? Association => _associations.Any() ? _associations : null;
        private ICollection<Association> _associations = new HashSet<Association>();
        public Feature AddAssociation(Association association) {
            _associations.Add(association);
            return this;
        }
    }

    public class Association()
    {
        public string? To { get; set; }
        public string? Name { get; set; }
        public string? Role { get; set; }
    }
}