using NetTopologySuite.Geometries;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S128.ComplexAttributes;
using S100Framework.Topology;
using System.Globalization;
using System.Security.Cryptography;
using System.Threading.Channels;
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

    public class DatasetUpdate
    {
        public DatasetUpdate(string root, string update) {
            _rootDataset = S100Framework.YAML.Converter.Deserialize<S100Framework.YAML.Dataset>(root);
            _updateDataset = S100Framework.YAML.Converter.Deserialize<S100Framework.YAML.Dataset>(update);

            // CellName
            if (!DatasetEquals())
                throw new InvalidOperationException("The two datasets are not of the same cell.");

            // Deserialize to Dictionary
            var temp_root_raw = S100Framework.YAML.Converter.Deserialize<Dictionary<object, object>>(root);
            var temp_update_raw = S100Framework.YAML.Converter.Deserialize<Dictionary<object, object>>(update);


            // Read InformationTypes
            var temp_root_information = temp_root_raw["InformationTypes"] as List<object>;
            var temp_update_information = temp_update_raw["InformationTypes"] as List<object>;

            _rootInformationTypes = temp_root_information!
                .OfType<Dictionary<object, object>>()
                .ToDictionary(
                    dict => dict["ID"]!.ToString()!,
                    dict => Converter.Serialize(dict)
                );

            _updateInformationTypes = temp_update_information!
                .OfType<Dictionary<object, object>>()
                .ToDictionary(
                    dict => dict["ID"].ToString()!,
                    dict => Converter.Serialize(dict)
                );

            // Read Features
            var temp_root_feature = temp_root_raw["Features"] as List<object>;
            var temp_update_feature = temp_update_raw["Features"] as List<object>;

            _rootFeatures = temp_root_feature!
                .OfType<Dictionary<object, object>>()
                .ToDictionary(
                    dict => dict["Foid"].ToString()!,
                    dict => Converter.Serialize(dict)
                );

            _updateFeatures = temp_update_feature!
                .OfType<Dictionary<object, object>>()
                .ToDictionary(
                    dict => dict["Foid"].ToString()!,
                    dict => Converter.Serialize(dict)
                );


            // Read Metadata
            var temp_root_metadata = temp_root_raw["Metadata"];
            var temp_update_metadata = temp_update_raw["Metadata"];

            _rootMetadata = Converter.Serialize(temp_root_metadata);
            _updateMetadata = Converter.Serialize(temp_update_metadata);

            // Compare Metadata
            MetadataEquals();

            // Compare InformationTypes
            InformationTypeEquals();

            // Compare Features
            FeatureEquals();

            // Compare Points
            GeometryEquals(_rootDataset.Points!, _updateDataset.Points!);

            // Compare Depths
            GeometryEquals(_rootDataset.Depths!, _updateDataset.Depths!);

            // Compare Curves
            GeometryEquals(_rootDataset.Curves!, _updateDataset.Curves!);

            // Compare Composite Curves
            GeometryEquals(_rootDataset.CompositeCurves!, _updateDataset.CompositeCurves!);

            // Compare Surfaces
            GeometryEquals(_rootDataset.Surfaces!, _updateDataset.Surfaces!);
        }

        private readonly Dictionary<string, string> _rootFeatures = [];
        private readonly Dictionary<string, string> _updateFeatures = [];

        private readonly Dictionary<string, string> _rootInformationTypes = [];
        private readonly Dictionary<string, string> _updateInformationTypes = [];

        private readonly string _rootMetadata = string.Empty;
        private readonly string _updateMetadata = string.Empty;

        private readonly Dataset _rootDataset;
        private readonly Dataset _updateDataset;

        public Dictionary<string, string> FeaturesAdded { get; internal set; } = [];
        public Dictionary<string, string> FeaturesDeleted { get; internal set; } = [];
        public Dictionary<string, string> FeaturesUpdated { get; internal set; } = [];

        public Dictionary<string, string> InformationTypesAdded { get; internal set; } = [];
        public Dictionary<string, string> InformationTypesDeleted { get; internal set; } = [];
        public Dictionary<string, string> InformationTypesUpdated { get; internal set; } = [];

        public Dictionary<string, Geometry> GeometriesAdded { get; internal set; } = [];
        public Dictionary<string, Geometry> GeometriesDeleted { get; internal set; } = [];
        public Dictionary<string, Geometry> GeometriesUpdated { get; internal set; } = [];

        public string? MetadataUpdated { get; internal set; }

        private void FeatureEquals() {
            // Added
            FeaturesAdded = _updateFeatures.Keys
                .Except(_rootFeatures.Keys)
                .ToDictionary(k => k!, k => _updateFeatures[k]);

            // Deleted
            FeaturesDeleted = _rootFeatures.Keys
                .Except(_updateFeatures.Keys)
                .ToDictionary(k => k!, k => _rootFeatures[k]);

            // Updates
            FeaturesUpdated = _rootFeatures.Keys
                .Intersect(_updateFeatures.Keys)
                .Where(k => !_rootFeatures[k].Equals(_updateFeatures[k]))
                .ToDictionary(k => k!, k => _updateFeatures[k]);
        }

        private bool DatasetEquals() {
            return _rootDataset.CellName == _updateDataset.CellName;
        }

        private void MetadataEquals() {
            if (_rootMetadata.Equals(_updateMetadata))
                return;

            MetadataUpdated = _updateMetadata ?? string.Empty;
        }

        private void InformationTypeEquals() {
            // Added
            InformationTypesAdded = _updateInformationTypes.Keys
                .Except(_rootInformationTypes.Keys)
                .ToDictionary(k => k!, k => _updateInformationTypes[k]);

            // Deleted
            InformationTypesDeleted = _rootInformationTypes.Keys
                .Except(_updateInformationTypes.Keys)
                .ToDictionary(k => k!, k => _rootInformationTypes[k]);

            // Updates
            InformationTypesUpdated = _rootInformationTypes.Keys
                .Intersect(_updateInformationTypes.Keys)
                .Where(k => !_rootInformationTypes[k].Equals(_updateInformationTypes[k]))
                .ToDictionary(k => k!, k => _updateInformationTypes[k]);
        }

        private void GeometryEquals(IEnumerable<Geometry> original, IEnumerable<Geometry> update) {
            // Use Name as unique key
            var originalDict = original.ToDictionary(c => c.Name!);
            var updatedDict = update.ToDictionary(c => c.Name!);

            // Added
            var added = updatedDict.Keys
                .Except(originalDict.Keys)
                .ToDictionary(k => updatedDict[k].Name!, k => updatedDict[k]);

            foreach (var item in added) {
                GeometriesAdded.TryAdd(item.Key, item.Value);
            }

            // Deleted
            var deleted = originalDict.Keys
                .Except(updatedDict.Keys)
                .ToDictionary(k => originalDict[k].Name!, k => originalDict[k]);

            foreach (var item in deleted) {
                GeometriesDeleted.TryAdd(item.Key, item.Value);
            }

            // Updates
            var updated = originalDict.Keys
                .Intersect(updatedDict.Keys)
                .Where(k => !originalDict[k].Equals(updatedDict[k]))
                .ToDictionary(k => updatedDict[k].Name!, k => updatedDict[k]);

            foreach (var item in updated) {
                GeometriesUpdated.TryAdd(item.Key, item.Value);
            }
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

            return Name == other.Name && Location == other.Location;
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

            return Name == other.Name && Location == other.Location && Z == other.Z;
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
            return Vertices == other.Vertices;
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

            return Name == other.Name && Components == other.Components;
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

            // Use a more robust comparison for strings
            var nameEquals = string.Equals(Name, other.Name, StringComparison.Ordinal);
            var exteriorEquals = string.Equals(Exterior, other.Exterior, StringComparison.Ordinal);

            // Compare the InteriorRings arrays for value equality
            var interiorRingsEquals = (InteriorRings is null && other.InteriorRings is null) ||
                                      (InteriorRings is not null && other.InteriorRings is not null &&
                                       Enumerable.SequenceEqual(InteriorRings, other.InteriorRings));

            return nameEquals && exteriorEquals && interiorRingsEquals;
        }

        public override int GetHashCode() {
            var hash = new HashCode();
            hash.Add(Name);
            hash.Add(Exterior);

            // Include the hash codes of all elements in the array
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
    }
}