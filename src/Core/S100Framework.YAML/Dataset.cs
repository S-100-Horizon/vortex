using System.Globalization;
using YamlDotNet.Serialization;

namespace S100Framework.YAML
{
    public enum Primitive {
        Point,
        PointSet,
        Curve,
        Surface,
    }

    public class Dataset
    {
        public string CellName { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;

        public uint? Edition { get; set; }
        public uint? Update { get; set; }

        public string encver { get; set; } = "INT.IHO.S-101.2.0";

        public string? FCVer { get; set; } = default;

        public ICollection<Point>? Points => _points.Any() ? _points : null;

        public ICollection<Curve>? Curves => _curves.Any() ? _curves : null;

        public ICollection<Surface>? Surfaces => _surfaces.Any() ? _surfaces : null;

        public ICollection<CompositeCurve>? CompositeCurves => _compositeCurves.Any() ? _compositeCurves : null;

        public ICollection<Feature>? Features => _features.Any() ? _features : null;

        private ICollection<Point> _points = new HashSet<Point>();
        private ICollection<Curve> _curves = new HashSet<Curve>();
        private ICollection<CompositeCurve> _compositeCurves = new HashSet<CompositeCurve>();
        private ICollection<Surface> _surfaces = new HashSet<Surface>();

        private ICollection<Feature> _features = new HashSet<Feature>();

        public Dataset AddPoint(Point point) {
            _points.Add(point);
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
    }

    public class Point
    {
        public Point(decimal x, decimal y) {
            Coordinate = new Coordinate(x, y);
        }

        public string? Name { get; set; }

        public string? Location => Coordinate is null ? string.Empty : string.Format(CultureInfo.InvariantCulture, "{0},{1}", Coordinate.Y, Coordinate.X);

        [YamlIgnore]
        public Coordinate? Coordinate { get; private set; }
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

        public string? Vertices => Coordinate is null ? string.Empty : string.Join(", ", Coordinate.Select(e => string.Format(CultureInfo.InvariantCulture, "{0},{1}", e.Y, e.X)));

        [YamlIgnore]
        public Coordinate[]? Coordinate { get; private set; }
    }

    public class CompositeCurve {
        public string? Name { get; set; }

        public string? Components => Curves is null ? null : string.Join(',', Curves.Select(e=>e.Name));

        [YamlIgnore]
        public Curve[]? Curves { get; private set; }
    }

    public class Surface {
        public Surface(Curve exterior) {
            this.ExteriorRing=exterior;
        }

        public string? Name { get; set; }

        public string? Exterior => ExteriorRing?.Name;

        public dynamic[]? Interior => InteriorRings is null ? null : InteriorRings?.Select(e => new { Hole = e.Name }).ToArray();

        [YamlIgnore]
        public Curve ExteriorRing { get; set; }

        [YamlIgnore]
        public Curve[]? InteriorRings { get; set; }
    }

    public class Coordinate
    {
        public Coordinate(decimal x, decimal y) {
            this.X = x;
            this.Y = y;
        }

        public decimal X { get; set; }
        public decimal Y { get; set; }
    }

    public class Attribute {
        public string? Name { get; set; }

        public string? Value { get; set; }
    }

    public class Feature {
        public string? Name { get; set; }
        public Primitive Prim { get; set; }

        public ICollection<Attribute>? Attributes => _attributes.Any() ? _attributes : null;

        public string? Geometry { get; set; }

        private ICollection<Attribute> _attributes = new HashSet<Attribute>();

        public Feature Add(string name, string value) {
            _attributes.Add(new Attribute { Name = name, Value = value });
            return this;
        }

        public Feature Add(string name, int value) {
            _attributes.Add(new Attribute { Name = name, Value = $"{value}" });
            return this;
        }
    }
}
