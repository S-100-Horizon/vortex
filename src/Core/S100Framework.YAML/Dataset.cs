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
        [YamlMember(Alias = "verticalDatum", ApplyNamingConventions = false)]
        public string? verticalDatum { get; set; } = default;

        public Metadata Metadata { get; set; } = new Metadata();

        public ICollection<Information>? InformationTypes => _informationTypes.Any() ? _informationTypes : null;
        public ICollection<Point>? Points => _points.Any() ? _points : null;
        public ICollection<Curve>? Curves => _curves.Any() ? _curves : null;
        public ICollection<CompositeCurve>? CompositeCurves => _compositeCurves.Any() ? _compositeCurves : null;
        public ICollection<PointSet>? Depths => _pointSets.Any() ? _pointSets : null;
        public ICollection<Surface>? Surfaces => _surfaces.Any() ? _surfaces : null;
        public ICollection<Feature>? Features => _features.Any() ? SortedFeatures() : null;

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
        /// <summary>
        /// Returns the features in dependency-safe order.
        /// </summary>
        /// <remarks>
        /// A feature can declare associations that point to other features (via
        /// <c>Association.To</c>).  
        /// This method performs a depth-first <em>topological sort</em> so that
        /// every feature is placed <strong>after</strong> all the features it
        /// references.  
        /// If it encounters a cycle (i.e., feature A → B → … → A) it throws
        /// <see cref="InvalidOperationException"/> because such a reference chain
        /// makes a valid ordering impossible.
        /// </remarks>
        /// <returns>
        /// A new <see cref="List{Feature}"/> where:
        /// <list type="bullet">
        ///   <item>
        ///     <description>Features appear only once.</description>
        ///   </item>
        ///   <item>
        ///     <description>For every association <c>f → g</c>,
        ///                  <paramref name="g"/> precedes <paramref name="f"/>.</description>
        ///   </item>
        /// </list>
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when a circular reference between features is detected.
        /// </exception>
        private List<Feature> SortedFeatures() {
            var foidToFeature = _features.ToDictionary(f => f.Foid);
            var visited = new HashSet<string>();
            var temp = new HashSet<string>();
            var sorted = new List<Feature>();

            void Visit(Feature f) {
                if (visited.Contains(f.Foid))
                    return;
                if (temp.Contains(f.Foid))
                    throw new InvalidOperationException("Circular reference detected");

                temp.Add(f.Foid);

                foreach (var assoc in f.FeatureAssociation ?? []) {
                    if (foidToFeature.TryGetValue(assoc.To, out var target))
                        Visit(target);
                }

                temp.Remove(f.Foid);
                visited.Add(f.Foid);
                sorted.Add(f);
            }

            foreach (var f in _features)
                Visit(f);

            return sorted;
        }
    }

    public class Metadata
    {
        public string OrganisationName { get; set; } = "Geodatastyrelsen";
        public string? City { get; set; } = "Aalborg";
        public string? AdministrativeArea { get; set; } = "Denmark";
        public string? ElectronicMailAddress { get; set; } = "jesoe@gst.dk";

        public string? Country { get; set; } = "Denmark";

        public string? PrivateKey { get; set; } = "MIG2AgEAMBAGByqGSM49AgEGBSuBBAAiBIGeMIGbAgEBBDCCyAmgnCKlk+9DKnBbHIJzFL24ZEi1jnMdpAsKipF/PhD+HOHRVsb8/RWZn+I+E2ChZANiAAQCxI7MvQu+qBAvpCgc51ChmBq3f0I2oFSy5JzVZGvh2HektisVUDtJ+a/gnIoZbx+9QVy916B3TFeCPP+DEM385a3KuMbnFB2Wok5y07FRmoEkL5lckVGEMVg68WBfMKM=";
        public string? Certificate { get; set; } = "MIICJzCCAa0CFBA40nptJKsNLZakml5wkaz22UEIMAoGCCqGSM49BAMDMH4xCzAJBgNVBAYTAk1DMR0wGwYDVQQIDBRTQ0hFTUVfQURNSU5JU1RSQVRPUjEwMC4GA1UECgwnSW50ZXJuYXRpb25hbCBIeWRyb2dyYXBoaWMgT3JnYW5pc2F0aW9uMR4wHAYDVQQDDBV1cm46bXJuOmlobzowMEFBOjE4MTAwHhcNMjQwOTE2MDY0NTAwWhcNMjUwOTE2MDY0NTAwWjBxMQswCQYDVQQGEwJVSzEWMBQGA1UECAwNREFUQV9QUk9EVUNFUjErMCkGA1UECgwiVW5pdGVkIEtpbmdkb20gSHlkcm9ncmFwaGljIE9mZmljZTEdMBsGA1UEAwwUdXJuOm1ybjppaG86R0IwMDo1NDAwdjAQBgcqhkjOPQIBBgUrgQQAIgNiAAQCxI7MvQu+qBAvpCgc51ChmBq3f0I2oFSy5JzVZGvh2HektisVUDtJ+a/gnIoZbx+9QVy916B3TFeCPP+DEM385a3KuMbnFB2Wok5y07FRmoEkL5lckVGEMVg68WBfMKMwCgYIKoZIzj0EAwMDaAAwZQIxAIzDeMJ2/+Rnchi+gGY74zPDwxm0aL5eK9UXf8qMS4a9j7pSyH9/0M9+yxC6r32upAIwTEQeCgEH/ekCPEvZtfeU3sjEdiJ7MfNOzxpX69/Hk8L2AnMDh0awiVRmwkAK2iYe";

        public string Producer { get; set; } = "GST";
        public string ProducerCode { get; set; } = "DK00";
    }

    public class Point(double x, double y)
    {
        public string? Name { get; set; }

        public string? Location => Coordinate is null ? string.Empty : 
            Matrix.Factory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(Coordinate.X, Coordinate.Y)).ToText().Substring("Point (".Length).Trim(')').Replace(' ', ',');

        //public string? Location => Coordinate is null ? string.Empty : string.Format(CultureInfo.InvariantCulture, "{0:0.0000000},{1:0.0000000}", Coordinate.X, Coordinate.Y);

        public ICollection<Association>? Association => _associations.Any() ? _associations : null;
        private ICollection<Association> _associations = new HashSet<Association>();
        public Point AddAssociation(Association association) {
            _associations.Add(association);
            return this;
        }

        [YamlIgnore]
        public Coordinate? Coordinate { get; private set; } = new Coordinate(x, y);
    }

    public class PointSet(Coordinate[] points, double[] depths)
    {
        public string? Name { get; set; }


        public string? Location => Points is null ? string.Empty :
            string.Join(',', Points.Select(e => Matrix.Factory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(e.X, e.Y)).ToText().Substring("Point (".Length).Trim(')').Replace(' ', ',')));

        //public string? Location => Points is null ? string.Empty : string.Join(",", Points.Select(e => string.Format(CultureInfo.InvariantCulture, "{0:0.0000000},{1:0.0000000}", e.X, e.Y)));
        public string? Z => Depths is null ? string.Empty : string.Join(",", Depths.Select(e => e.ToString(CultureInfo.InvariantCulture)));

        public ICollection<Association>? Association => _associations.Any() ? _associations : null;
        private ICollection<Association> _associations = new HashSet<Association>();
        public PointSet AddAssociation(Association association) {
            _associations.Add(association);
            return this;
        }

        [YamlIgnore]
        public double[] Depths { get; private set; } = depths;

        [YamlIgnore]
        public Coordinate[] Points { get; private set; } = points;
    }

    public class Curve
    {
        private string? _start;
        private string? _end;

        public Curve(Coordinate[] vertices) {
            Coordinate = vertices;
        }
        public Curve(string start, Coordinate[] vertices) {
            _start = start;

            Coordinate = vertices;
        }
        public Curve(string? start, string? end, Coordinate[] vertices) {
            _start = start;
            _end = end;

            Coordinate = vertices;
        }

        public string? Name { get; set; }

        public string? Start => _start;

        public string? End => _end;
        public ICollection<Association>? Association => _associations.Any() ? _associations : null;
        private ICollection<Association> _associations = new HashSet<Association>();
        public Curve AddAssociation(Association association) {
            _associations.Add(association);
            return this;
        }


        //factory.CreatePoint(new Coordinate(location[0], location[1])).ToText()

        public string? Vertices => Coordinate is null ? string.Empty :
            string.Join(',', Coordinate.Select(e => Matrix.Factory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(e.X, e.Y)).ToText().Substring("Point (".Length).Trim(')').Replace(' ', ',')));

        //public string? Vertices => Coordinate is null ? string.Empty : string.Join(",", Coordinate.Select(e => string.Format(CultureInfo.InvariantCulture, "{0:0.0000000},{1:0.0000000}", e.X, e.Y)));

        //[YamlIgnore]
        //public string? ReversedVertices => Coordinate is null ? string.Empty : string.Join(",", Coordinate.Select(e => string.Format(CultureInfo.InvariantCulture, "{0:0.0000000},{1:0.0000000}", e.X, e.Y)).Reverse());

        [YamlIgnore]
        public Coordinate[]? Coordinate { get; private set; }
    }

    public class CompositeCurve
    {
        public CompositeCurve(string components) {
            Curves = components.Split(",");
        }

        public CompositeCurve(string[] curves) {
            Curves = curves;
        }
        public string? Name { get; set; }
        public ICollection<Association>? Association => _associations.Any() ? _associations : null;
        private ICollection<Association> _associations = new HashSet<Association>();
        public CompositeCurve AddAssociation(Association association) {
            _associations.Add(association);
            return this;
        }

        public string Components => string.Join(",", Curves);

        [YamlIgnore]
        public string[] Curves { get; set; } = [];
    }

    public class Surface(string exterior)
    {
        public string? Name { get; set; }

        public string Exterior { get; set; } = exterior;

        [YamlIgnore]
        public string[]? InteriorRings { get; set; }

        public ICollection<Association>? Association => _associations.Any() ? _associations : null;
        private ICollection<Association> _associations = new HashSet<Association>();
        public Surface AddAssociation(Association association) {
            _associations.Add(association);
            return this;
        }

        public dynamic[]? Interior => InteriorRings?.Length == 0 ? null : InteriorRings?.Select(e => new { Hole = e }).ToArray();

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
        public string Foid { get; set; } = default!;
        public FeatureNode? Attributes { get; set; }
        public string? Geometry { get; set; }

        public ICollection<Association>? Association => _associations.Any() ? _associations : null;
        private ICollection<Association> _associations = new HashSet<Association>();

        public ICollection<Association>? FeatureAssociation => _featureAssociations.Any() ? _featureAssociations : null;
        private ICollection<Association> _featureAssociations = new HashSet<Association>();

        public Feature AddAssociation(Association association) {
            _associations.Add(association);
            return this;
        }

        public Feature AddFeatureAssociation(Association association) {
            _featureAssociations.Add(association);
            return this;
        }
    }

    public class Association
    {
        public string To { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Role { get; set; } = default!;
    }
}