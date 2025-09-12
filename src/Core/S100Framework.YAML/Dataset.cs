using S100Framework.DomainModel;
using S100Framework.Topology;
using System.Globalization;
using YamlDotNet.Serialization;

namespace S100Framework.YAML
{
    public enum Primitive
    {
        NoGeometry = -1,
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

    public record FeatureDiff(
        Dictionary<string, string> Added,
        Dictionary<string, string> Deleted,
        Dictionary<string, string> Updated
    );
    public record SupportFileDiff(
        Dictionary<string, string> Added,
        Dictionary<string, string> Deleted,
        Dictionary<string, string> Updated
    );
    public record InformationTypeDiff(
        Dictionary<string, string> Added,
        Dictionary<string, string> Deleted,
        Dictionary<string, string> Updated
    );

    public record GeometryDiff(
        Dictionary<string, Geometry> Added,
        Dictionary<string, Geometry> Deleted,
        Dictionary<string, Geometry> Updated
    );

    public class DatasetDiff
    {
        public FeatureDiff? Features { get; init; }
        public InformationTypeDiff? InformationTypes { get; init; }
        public GeometryDiff? Points { get; init; }
        public GeometryDiff? Depths { get; init; }
        public GeometryDiff? Curves { get; init; }
        public GeometryDiff? CompositeCurves { get; init; }
        public GeometryDiff? Surfaces { get; init; }
        public SupportFileDiff? SupportFiles { get; init; }
    }

    public static class DatasetComparer
    {
        public static DatasetDiff Compare(string root, string update) {
            var rootDataset = BuildDatasetUpdate(root);
            var updateDataset = BuildDatasetUpdate(update);


            // Compare SupportFiles
            var supportFileDiff = SupportFileEquals(rootDataset.SupportFiles, updateDataset.SupportFiles);

            // Compare InformationTypes
            var informationTypeDiff = InformationTypeEquals(rootDataset.InformationTypes, updateDataset.InformationTypes);

            // Compare Features
            var featureDiff = FeatureEquals(rootDataset.Features, updateDataset.Features);

            // Compare Points
            var pointDiff = GeometryEquals(rootDataset.Points!, updateDataset.Points!);

            // Compare Depths
            var depthDiff = GeometryEquals<PointSet>(rootDataset.Depths!, updateDataset.Depths!);

            // Compare Curves
            var curveDiff = GeometryEquals(rootDataset.Curves!, updateDataset.Curves!);

            // Compare Composite Curves
            var compositeCurveDiff = GeometryEquals(rootDataset.CompositeCurves!, updateDataset.CompositeCurves!);

            // Compare Surfaces
            var surfaceDiff = GeometryEquals(rootDataset.Surfaces!, updateDataset.Surfaces!);


            // Build result return it
            var result = new DatasetDiff() {
                SupportFiles = supportFileDiff,
                Features = featureDiff,
                InformationTypes = informationTypeDiff,
                Points = pointDiff,
                Depths = depthDiff,
                Curves = curveDiff,
                CompositeCurves = compositeCurveDiff,
                Surfaces = surfaceDiff,
            };

            return result;
        }

        private static DatasetUpdate BuildDatasetUpdate(string dataset) {
            // Deserialize to Dictionary
            var rawDictionary = S100Framework.YAML.Converter.Deserialize<Dictionary<object, object>>(dataset);

            // TO-DO: Read associations from Geometry
            // Cleanup after full updates

            // Read InformationTypes
            var informationTypes = (rawDictionary["InformationTypes"] as List<object>)!
                .OfType<Dictionary<object, object>>()
                .ToDictionary(
                    dict => dict["ID"]!.ToString()!,
                    dict => Converter.Serialize(dict)
                );

            // Read Features
            var features = (rawDictionary["Features"] as List<object>)!
                .OfType<Dictionary<object, object>>()
                .ToDictionary(
                    dict => dict["Foid"]!.ToString()!,
                    dict => Converter.Serialize(dict)
                );

            // Read SupportFiles
            var supportFiles = ((rawDictionary["Metadata"] as Dictionary<object, object>)?["SupportFiles"] as List<object> ?? [])
                .OfType<Dictionary<object, object>>()
                .Select(d => new SupportFile(
                    d["Name"]?.ToString() ?? string.Empty,
                    d["Content"]?.ToString() ?? string.Empty
                ))
                .ToDictionary(sf => sf.Name);

            // Read Points
            var points = (rawDictionary["Points"] as List<object> ?? [])
                .OfType<Dictionary<object, object>>()
                .Select(d => {
                    var location = d["Location"]?.ToString() ?? string.Empty;
                    var split = location.Split(',');
                    var point = new Point(
                        double.Parse(split[0]),
                        double.Parse(split[1])
                    ) {
                        Name = d["Name"].ToString()
                    };
                    return point;
                }).ToDictionary(p => p.Name!);

            // Read Depths
            var depths = (rawDictionary["Depths"] as List<object> ?? [])
                .OfType<Dictionary<object, object>>()
                .Select(d => {
                    var location = d["Location"]?.ToString() ?? string.Empty;
                    var split = location.Split(',');
                    var pointSet = new PointSet(
                        [new Coordinate(
                            double.Parse(split[0]),
                            double.Parse(split[1])
                        )],
                        [double.Parse(d["Z"].ToString()!)]
                    ) {
                        Name = d["Name"].ToString()
                    };
                    return pointSet;
                }).ToDictionary(ps => ps.Name!);


            // Read Curves
            var curves = (rawDictionary["Curves"] as List<object> ?? new List<object>())
                .OfType<Dictionary<object, object>>()
                .Select(d => {
                    var location = d["Vertices"]?.ToString() ?? string.Empty;
                    var split = location.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(s => double.Parse(s, CultureInfo.InvariantCulture))
                                        .ToArray();

                    var vertices = new List<Coordinate>();
                    for (int i = 0; i < split.Length; i += 2) {
                        vertices.Add(new Coordinate(split[i], split[i + 1]));
                    }

                    return new Curve(
                        start: d["Start"].ToString(),
                        end: d["End"].ToString(),
                        vertices: [.. vertices]
                    ) {
                        Name = d["Name"].ToString()
                    };
                }).ToDictionary(c => c.Name!);


            // Read CompositeCurves
            var compositeCurves = (rawDictionary["CompositeCurves"] as List<object> ?? [])
                .OfType<Dictionary<object, object>>()
                .Select(d => {
                    var compositeCurve = new CompositeCurve(
                        d["Components"]?.ToString()!) {
                        Name = d["Name"].ToString()
                    };
                    return compositeCurve;
                }).ToDictionary(cc => cc.Name!);


            // Read Surfaces
            var surfaces = (rawDictionary["Surfaces"] as List<object> ?? [])
                .OfType<Dictionary<object, object>>()
                .Select(d => {
                    var surface = new Surface(
                        d["Exterior"]?.ToString()!) {
                        Name = d["Name"].ToString()
                    };

                    if (d["Exterior"] is List<object> interior && interior.Count > 0) {
                        var interiorRings = new List<string>();
                        foreach (var hole in interior) {
                            if (hole is Dictionary<object, object> holeDict) {
                                var ring = holeDict["Hole"].ToString();
                                if (!string.IsNullOrEmpty(ring))
                                    interiorRings.Add(ring);
                            }
                        }
                        surface.InteriorRings = [.. interiorRings];
                    }

                    return surface;
                }).ToDictionary(s => s.Name!);


            return new DatasetUpdate() {
                Features = features,
                SupportFiles = supportFiles,
                InformationTypes = informationTypes,
                Points = points,
                Depths = depths,
                Curves = curves,
                CompositeCurves = compositeCurves,
                Surfaces = surfaces
            };
        }

        private static string AppendUpdates(string dataset, string[] updates) {
            // To-Do

            return dataset;
        }

        private static FeatureDiff FeatureEquals(Dictionary<string, string> rootFeatures, Dictionary<string, string> updateFeatures) {
            var featureDiff = new FeatureDiff(
                // Added
                updateFeatures.Keys
                    .Except(rootFeatures.Keys)
                    .ToDictionary(k => k!, k => updateFeatures[k]),

                // Deleted
                rootFeatures.Keys
                    .Except(updateFeatures.Keys)
                    .ToDictionary(k => k!, k => rootFeatures[k]),

                // Updates
                rootFeatures.Keys
                    .Intersect(updateFeatures.Keys)
                    .Where(k => !rootFeatures[k].Equals(updateFeatures[k]))
                    .ToDictionary(k => k!, k => updateFeatures[k])
            );

            return featureDiff;
        }
        private static SupportFileDiff SupportFileEquals(Dictionary<string, SupportFile> rootcasted, Dictionary<string, SupportFile> updatecasted) {
            //var rootcasted = rootSupportFiles
            //   .OfType<Dictionary<object, object>>() // skips anything that isn't a dict
            //   .Select(d => new SupportFile(
            //       d["Name"]?.ToString() ?? string.Empty,
            //       d["Content"]?.ToString() ?? string.Empty
            //   )).ToDictionary(sf => sf.Name);

            //var updatecasted = updateSupportFiles
            //   .OfType<Dictionary<object, object>>() // skips anything that isn't a dict
            //   .Select(d => new SupportFile(
            //       d["Name"]?.ToString() ?? string.Empty,
            //       d["Content"]?.ToString() ?? string.Empty
            //   )).ToDictionary(sf => sf.Name);

            var supportFileDiff = new SupportFileDiff(
                // Added
                updatecasted.Keys
                .Except(rootcasted.Keys)
                .ToDictionary(k => k!, k => updatecasted[k].Content),

                // Deleted
                rootcasted.Keys
                    .Except(updatecasted.Keys)
                    .ToDictionary(k => k!, k => rootcasted[k].Content),

                // Updated
                rootcasted.Keys
                    .Intersect(updatecasted.Keys)
                    .Where(k => !rootcasted[k].Equals(updatecasted[k]))
                    .ToDictionary(k => k!, k => updatecasted[k].Content)
            );

            return supportFileDiff;
        }
        private static InformationTypeDiff InformationTypeEquals(Dictionary<string, string> rootInformationTypes, Dictionary<string, string> updateInformationTypes) {
            var informationTypeDiff = new InformationTypeDiff(
                // Added
                updateInformationTypes.Keys
                    .Except(rootInformationTypes.Keys)
                    .ToDictionary(k => k!, k => updateInformationTypes[k]),

                // Deleted
                rootInformationTypes.Keys
                    .Except(updateInformationTypes.Keys)
                    .ToDictionary(k => k!, k => rootInformationTypes[k]),

                // Updated
                rootInformationTypes.Keys
                    .Intersect(updateInformationTypes.Keys)
                    .Where(k => !rootInformationTypes[k].Equals(updateInformationTypes[k]))
                    .ToDictionary(k => k!, k => updateInformationTypes[k])
            );

            return informationTypeDiff;

            // Added
            //InformationTypesAdded = _updateInformationTypes.Keys
            //    .Except(_rootInformationTypes.Keys)
            //    .ToDictionary(k => k!, k => _updateInformationTypes[k]);

            //// Deleted
            //InformationTypesDeleted = _rootInformationTypes.Keys
            //    .Except(_updateInformationTypes.Keys)
            //    .ToDictionary(k => k!, k => _rootInformationTypes[k]);

            //// Updates
            //InformationTypesUpdated = _rootInformationTypes.Keys
            //    .Intersect(_updateInformationTypes.Keys)
            //    .Where(k => !_rootInformationTypes[k].Equals(_updateInformationTypes[k]))
            //    .ToDictionary(k => k!, k => _updateInformationTypes[k]);
        }
        private static GeometryDiff GeometryEquals<T>(Dictionary<string, T> originalDict, Dictionary<string, T> updatedDict) where T : Geometry {
            var geometryDiff = new GeometryDiff(
                // Added
                updatedDict.Keys
                    .Except(originalDict.Keys)
                    .ToDictionary(k => updatedDict[k].Name!, k => updatedDict[k] as Geometry),

                // Deleted
                originalDict.Keys
                    .Except(updatedDict.Keys)
                    .ToDictionary(k => originalDict[k].Name!, k => originalDict[k] as Geometry),

                // Updated
                originalDict.Keys
                    .Intersect(updatedDict.Keys)
                    .Where(k => !originalDict[k].Equals(updatedDict[k]))
                    .ToDictionary(k => updatedDict[k].Name!, k => updatedDict[k] as Geometry)
            );

            return geometryDiff;
        }

        private class DatasetUpdate
        {
            public Dictionary<string, SupportFile> SupportFiles { get; init; } = [];
            public Dictionary<string, string> Features { get; init; } = [];
            public Dictionary<string, string> InformationTypes { get; init; } = [];
            public Dictionary<string, Point> Points { get; init; } = [];
            public Dictionary<string, PointSet> Depths { get; init; } = [];
            public Dictionary<string, Curve> Curves { get; init; } = [];
            public Dictionary<string, CompositeCurve> CompositeCurves { get; init; } = [];
            public Dictionary<string, Surface> Surfaces { get; init; } = [];
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
        public ICollection<SupportFile>? SupportFiles => _supportFiles.Any() ? _supportFiles : null;
        private ICollection<SupportFile> _supportFiles = [];

        public void AddSupportFile(string name, string content) => _supportFiles.Add(new(name, content));

        public override bool Equals(object? obj) {
            if (obj is null || GetType() != obj.GetType())
                return false;

            return Equals((Metadata)obj);
        }

        public bool Equals(Metadata? other) {
            if (other is null)
                return false;

            return OrganisationName == other.OrganisationName &&
                   City == other.City &&
                   AdministrativeArea == other.AdministrativeArea &&
                   ElectronicMailAddress == other.ElectronicMailAddress &&
                   Country == other.Country &&
                   PrivateKey == other.PrivateKey &&
                   Certificate == other.Certificate &&
                   Producer == other.Producer &&
                   ProducerCode == other.ProducerCode &&
                   _supportFiles.SequenceEqual(other._supportFiles);
        }

        public override int GetHashCode() {
            var hash = new HashCode();
            hash.Add(OrganisationName);
            hash.Add(City);
            hash.Add(AdministrativeArea);
            hash.Add(ElectronicMailAddress);
            hash.Add(Country);
            hash.Add(PrivateKey);
            hash.Add(Certificate);
            hash.Add(Producer);
            hash.Add(ProducerCode);

            foreach (var file in _supportFiles)
                hash.Add(file);

            return hash.ToHashCode();
        }
    }

    public class SupportFile(string Name, string Content)
    {
        [YamlMember(Order = 0)]
        public string Name = Name;
        [YamlMember(Order = 1)]
        public string Content = Content;

        public override bool Equals(object? obj) {
            return Equals(obj as SupportFile);
        }

        public bool Equals(SupportFile? other) {
            if (other is null)
                return false;

            return Name == other.Name && Content == other.Content;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Name, Content);
        }
    }


    public abstract class Geometry
    {
        [YamlMember(Order = 0)]
        public string? Name { get; set; }
        [YamlMember(Order = 9)]
        public ICollection<Association>? Association => _associations.Any() ? _associations : null;
        private ICollection<Association> _associations = new HashSet<Association>();
        public void AddAssociation(Association association) => _associations.Add(association);
    }

    public class Point(double x, double y) : Geometry
    {
        [YamlMember(Order = 1)]
        public string? Location => Coordinate is null ? string.Empty :
            Matrix.Factory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(Coordinate.X, Coordinate.Y)).ToText().Substring("Point (".Length).Trim(')').Replace(' ', ',');

        [YamlIgnore]
        public Coordinate? Coordinate { get; private set; } = new Coordinate(x, y);

        public override bool Equals(object? obj) {
            return Equals(obj as Point);
        }

        public bool Equals(Point? other) {
            if (other is null)
                return false;

            return Name == other.Name && Location == other.Location && Enumerable.SequenceEqual(Association ?? [], other.Association ?? []);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Name, Location);
        }
    }

    public class PointSet(Coordinate[] points, double[] depths) : Geometry
    {
        [YamlMember(Order = 1)]
        public string? Location => Points is null ? string.Empty :
            string.Join(',', Points.Select(e => Matrix.Factory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(e.X, e.Y)).ToText().Substring("Point (".Length).Trim(')').Replace(' ', ',')));

        [YamlMember(Order = 2)]
        public string? Z => Depths is null ? string.Empty : string.Join(",", Depths.Select(e => e.ToString(CultureInfo.InvariantCulture)));

        [YamlIgnore]
        public double[] Depths { get; private set; } = depths;

        [YamlIgnore]
        public Coordinate[] Points { get; private set; } = points;

        public override bool Equals(object? obj) {
            return Equals(obj as PointSet);
        }

        public bool Equals(PointSet? other) {
            if (other is null)
                return false;

            return Name == other.Name && Location == other.Location && Z == other.Z && Enumerable.SequenceEqual(Association ?? [], other.Association ?? []);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Name, Location, Z);
        }
    }

    public class Curve : Geometry
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
        [YamlMember(Order = 1)]
        public string? Start => _start;
        [YamlMember(Order = 2)]
        public string? End => _end;
        [YamlMember(Order = 3)]
        public string? Vertices => Coordinate is null ? string.Empty :
            string.Join(',', Coordinate.Select(e => Matrix.Factory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(e.X, e.Y)).ToText().Substring("Point (".Length).Trim(')').Replace(' ', ',')));

        [YamlIgnore]
        public Coordinate[]? Coordinate { get; private set; }

        public override bool Equals(object? obj) {
            return Equals(obj as Curve);
        }

        public bool Equals(Curve? other) {
            if (other is null)
                return false;

            //return Name == other.Name && Vertices == other.Vertices;
            return Vertices == other.Vertices && Enumerable.SequenceEqual(Association ?? [], other.Association ?? []);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Name, Vertices);
        }
    }

    public class CompositeCurve : Geometry
    {
        public CompositeCurve(string components) {
            Curves = components.Split(",");
        }

        public CompositeCurve(string[] curves) {
            Curves = curves;
        }
        [YamlMember(Order = 1)]
        public string Components => string.Join(",", Curves);

        [YamlIgnore]
        public string[] Curves { get; set; } = [];

        public override bool Equals(object? obj) {
            return Equals(obj as CompositeCurve);
        }

        public bool Equals(CompositeCurve? other) {
            if (other is null)
                return false;

            return Name == other.Name && Components == other.Components && Enumerable.SequenceEqual(Association ?? [], other.Association ?? []);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Name, Components);
        }
    }

    public class Surface(string exterior) : Geometry
    {
        [YamlMember(Order = 1)]
        public string Exterior { get; set; } = exterior;

        [YamlIgnore]
        public string[]? InteriorRings { get; set; }
        [YamlMember(Order = 2)]

        public dynamic[]? Interior => InteriorRings?.Length == 0 ? null : InteriorRings?.Select(e => new { Hole = e }).ToArray();

        public override bool Equals(object? obj) {
            return Equals(obj as Surface);
        }

        public bool Equals(Surface? other) {
            if (other is null)
                return false;

            var nameEquals = string.Equals(Name, other.Name, StringComparison.Ordinal);
            var exteriorEquals = string.Equals(Exterior, other.Exterior, StringComparison.Ordinal);

            var interiorRingsEquals = (InteriorRings is null && other.InteriorRings is null) ||
                                      (InteriorRings is not null && other.InteriorRings is not null &&
                                       Enumerable.SequenceEqual(InteriorRings, other.InteriorRings));

            return nameEquals && exteriorEquals && interiorRingsEquals && Enumerable.SequenceEqual(Association ?? [], other.Association ?? []);
        }

        public override int GetHashCode() {
            var hash = new HashCode();
            hash.Add(Name);
            hash.Add(Exterior);

            if (InteriorRings != null) {
                foreach (var ring in InteriorRings) {
                    hash.Add(ring);
                }
            }
            return hash.ToHashCode();
        }
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

        public override bool Equals(object? obj) {
            return Equals(obj as Information);
        }

        public bool Equals(Information? other) {
            if (other is null)
                return false;

            return Name == other.Name && ID == other.ID;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Name, ID);
        }
    }

    public class Feature
    {
        public string? Name { get; set; }
        public Primitive Prim { get; set; }
        public string Foid { get; set; } = default!;
        public FeatureNode? Attributes { get; set; }
        public string? Geometry { get; set; }
        public string? Masks { get; set; }

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

        public override bool Equals(object? obj) {
            return Equals(obj as Feature);
        }

        public bool Equals(Feature? other) {
            if (other is null)
                return false;

            return Name == other.Name && Foid == other.Foid && Geometry == other.Geometry && Masks == other.Masks;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Name, Foid, Geometry, Masks);
        }

    }

    public class Association
    {
        public string To { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Role { get; set; } = default!;

        public override bool Equals(object? obj) {
            return Equals(obj as Association);
        }

        public bool Equals(Association? other) {
            if (other is null)
                return false;

            return Name == other.Name && To == other.To && Role == other.Role;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Name, To, Role);
        }
    }
}