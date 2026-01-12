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

        public ICollection<Information>? InformationTypes => _informationTypes.Count != 0 ? _informationTypes : null;
        public ICollection<Point>? Points => _points.Count != 0 ? _points : null;
        public ICollection<Curve>? Curves => _curves.Count != 0 ? _curves : null;
        public ICollection<CompositeCurve>? CompositeCurves => _compositeCurves.Count != 0 ? _compositeCurves : null;
        public ICollection<PointSet>? Depths => _pointSets.Count != 0 ? _pointSets : null;
        public ICollection<Surface>? Surfaces => _surfaces.Count != 0 ? _surfaces : null;
        public ICollection<Feature>? Features => _features.Count != 0 ? SortedFeatures() : null;

        private readonly ICollection<Information> _informationTypes = new HashSet<Information>();
        private readonly ICollection<Point> _points = new HashSet<Point>();
        private readonly ICollection<PointSet> _pointSets = new HashSet<PointSet>();
        private readonly ICollection<Curve> _curves = new HashSet<Curve>();
        private readonly ICollection<CompositeCurve> _compositeCurves = new HashSet<CompositeCurve>();
        private readonly ICollection<Surface> _surfaces = new HashSet<Surface>();
        private readonly ICollection<Feature> _features = new HashSet<Feature>();

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
        Dictionary<string, object> Added,
        Dictionary<string, object> Deleted
    );

    public record MetadataDiff(
        Dictionary<string, object> Value,
        Metadata Casted
    );

    public record SupportFileDiff(
        Dictionary<string, string> Added,
        Dictionary<string, string> Deleted
    );

    public record InformationTypeDiff(
        Dictionary<string, object> Added,
        Dictionary<string, object> Deleted
    );

    public record GeometryDiff(
        Dictionary<string, Geometry> Added,
        Dictionary<string, Geometry> Deleted
    );

    public class MetadataUpdate() {
        public string OrganisationName { get; set; } 
        public string? City { get; set; } 
        public string? AdministrativeArea { get; set; } 
        public string? ElectronicMailAddress { get; set; } 

        public string? Country { get; set; } 

        public string? PrivateKey { get; set; } 
        public string? Certificate { get; set; } 

        public string Producer { get; set; } 
        public string ProducerCode { get; set; } 
        public ICollection<SupportFileUpdate>? SupportFiles { get; set; }
    }
    public class SupportFileUpdate()
    {
        [YamlMember(Order = 0)]
        public string Name { get; set; }
        [YamlMember(Order = 1)]
        public string Content { get; set; }
    }

    public class DatasetDelta(GeometryDiff points,
                             GeometryDiff depths,
                             GeometryDiff curves,
                             GeometryDiff compositeCurves,
                             GeometryDiff surfaces,
                             //SupportFileDiff supportFiles,
                             MetadataUpdate metadata,
                             FeatureDiff features,
                             InformationTypeDiff informationTypes)
    {
        public string? CellName { get; set; }
        public string? Comment { get; set; }
        public int? Edition { get; set; }
        public int? Update { get; set; }
        [YamlMember(Alias = "encver", ApplyNamingConventions = false)]
        public string? ENCVer { get; set; }
        [YamlMember(Alias = "FCVer", ApplyNamingConventions = false)]
        public string? FCVer { get; set; }

        public MetadataUpdate Metadata => metadata;

        [YamlMember(Alias = "InformationTypes", ApplyNamingConventions = false)]
        public ICollection<object>? InformationTypesAdded => InformationTypes.Added.Count != 0 ? InformationTypes?.Added.Values : null;
        [YamlMember(Alias = "InfDel", ApplyNamingConventions = false)]
        public ICollection<string>? InformationTypesDeleted => InformationTypes.Deleted.Count != 0 ? InformationTypes?.Deleted.Keys : null;
        [YamlMember(Alias = "Features", ApplyNamingConventions = false)]
        public ICollection<object>? FeaturesAdded => Features.Added.Count != 0 ? Features?.Added.Values : null;
        [YamlMember(Alias = "FDel", ApplyNamingConventions = false)]
        public ICollection<string>? FeaturesDeleted => Features.Deleted.Count != 0 ? Features?.Deleted.Keys : null;

        [YamlMember(Alias = "Points", ApplyNamingConventions = false)]
        public ICollection<Geometry>? PointsAdded => Points.Added.Count != 0 ? Points?.Added.Values : null;
        [YamlMember(Alias = "Depths", ApplyNamingConventions = false)]
        public ICollection<Geometry>? DepthsAdded => Depths.Added.Count != 0 ? Depths?.Added.Values : null;
        [YamlMember(Alias = "Curves", ApplyNamingConventions = false)]
        public ICollection<Geometry>? CurvesAdded => Curves.Added.Count != 0 ? Curves?.Added.Values : null;
        [YamlMember(Alias = "CompositeCurves", ApplyNamingConventions = false)]
        public ICollection<Geometry>? CompositeCurvesAdded => CompositeCurves.Added.Count != 0 ? CompositeCurves?.Added.Values : null;
        [YamlMember(Alias = "Surfaces", ApplyNamingConventions = false)]
        public ICollection<Geometry>? SurfacesAdded => Surfaces.Added.Count != 0 ? Surfaces?.Added.Values : null;

        [YamlMember(Alias = "GDel", ApplyNamingConventions = false)]
        public ICollection<string>? GeometriesDeleted {
            get {
                var all = Points.Deleted.Keys
                    .Concat(Depths.Deleted.Keys)
                    .Concat(Curves.Deleted.Keys)
                    .Concat(CompositeCurves.Deleted.Keys)
                    .Concat(Surfaces.Deleted.Keys);

                return all.Any() ? [.. all] : null;
            }
        }

        //[YamlMember(Alias = "fileAdd", ApplyNamingConventions = false)]
        // public ICollection<string>? SupportFilesAdded => SupportFiles.Added.Count != 0 ? SupportFiles?.Added.Values : null;
        //[YamlMember(Alias = "fileDel", ApplyNamingConventions = false)]
        //public ICollection<string>? SupportFilesDeleted => SupportFiles.Deleted.Count != 0 ? SupportFiles?.Deleted.Keys : null;

        [YamlIgnore]
        public bool Any => (Features.Added.Count +
                            Features.Deleted.Count +
                            InformationTypes.Added.Count +
                            InformationTypes.Deleted.Count +
                            // SupportFiles.Added.Count +
                            // SupportFiles.Deleted.Count +
                            Points.Added.Count +
                            Points.Deleted.Count +
                            Depths.Added.Count +
                            Depths.Deleted.Count +
                            Curves.Added.Count +
                            Curves.Deleted.Count +
                            CompositeCurves.Added.Count +
                            CompositeCurves.Deleted.Count +
                            Surfaces.Added.Count +
                            Surfaces.Deleted.Count) == 0;

        [YamlIgnore]
        internal FeatureDiff Features { get; init; } = features;
        [YamlIgnore]
        internal InformationTypeDiff InformationTypes { get; init; } = informationTypes;
        // [YamlIgnore]
        //internal SupportFileDiff SupportFiles { get; init; } = supportFiles;
        [YamlIgnore]
        internal GeometryDiff Points { get; init; } = points;
        [YamlIgnore]
        internal GeometryDiff Depths { get; init; } = depths;
        [YamlIgnore]
        internal GeometryDiff Curves { get; init; } = curves;
        [YamlIgnore]
        internal GeometryDiff CompositeCurves { get; init; } = compositeCurves;
        [YamlIgnore]
        internal GeometryDiff Surfaces { get; init; } = surfaces;
    }

    public static class DatasetComparer
    {
        /// <summary>
        /// Compares two YAML datasets and build a delta object
        /// </summary>
        /// <returns>A DatasetDelta object, which can be serialized to a delta yaml dataset</returns>
        public static DatasetDelta Compare(string root, string update) {
            var rootDataset = ReadDataset(root);
            var updateDataset = ReadDataset(update);


            // Compare SupportFiles
            // var supportFileDiff = SupportFileEquals(rootDataset.SupportFiles, updateDataset.SupportFiles);

            // Compare InformationTypes
            var informationTypeDiff = InformationTypeEquals(rootDataset.InformationTypes, updateDataset.InformationTypes);

            // Compare Features
            var featureDiff = FeatureEquals(rootDataset.Features, updateDataset.Features);

            // Compare Metadata
            var metadataUpdate = MetadataEquals(rootDataset.Metadata, updateDataset.Metadata);

            // Compare Points
            var pointDiff = GeometryEquals<Point>(rootDataset.Points!, updateDataset.Points!);

            // Compare Depths
            var depthDiff = GeometryEquals<PointSet>(rootDataset.Depths!, updateDataset.Depths!);

            // Compare Curves
            var curveDiff = GeometryEquals<Curve>(rootDataset.Curves!, updateDataset.Curves!);

            // Compare Composite Curves
            var compositeCurveDiff = GeometryEquals<CompositeCurve>(rootDataset.CompositeCurves!, updateDataset.CompositeCurves!);

            // Compare Surfaces
            var surfaceDiff = GeometryEquals<Surface>(rootDataset.Surfaces!, updateDataset.Surfaces!);

            // Build result return it
            var result = new DatasetDelta(
                points: pointDiff,
                depths: depthDiff,
                curves: curveDiff,
                compositeCurves: compositeCurveDiff,
                surfaces: surfaceDiff,
                //  supportFiles: supportFileDiff,
                metadata: metadataUpdate,
                features: featureDiff,
                informationTypes: informationTypeDiff
            );

            return result;
        }

        private static DatasetUpdate ReadDataset(string dataset) {
            // Deserialize to Dictionary
            var rawDictionary = S100Framework.YAML.Converter.Deserialize<Dictionary<object, object>>(dataset);

            // Read InformationTypes
            rawDictionary.TryGetValue("InformationTypes", out var infoTypesObj);

            var informationTypes = (infoTypesObj as List<object>)?
                .OfType<Dictionary<object, object>>()
                .ToDictionary(
                    dict => dict["ID"]!.ToString()!,
                    dict => dict as object
                ) ?? [];

            // Read Features
            var features = (rawDictionary["Features"] as List<object>)!
                .OfType<Dictionary<object, object>>()
                .ToDictionary(
                    dict => dict["Foid"]!.ToString()!,
                    dict => dict as object
                );


            // Read Metadata
            //var metadata = rawDictionary["Metadata"] as Dictionary<string, object>;
            var metadataDict = rawDictionary["Metadata"] as Dictionary<object, object>;
            var metadata = metadataDict?.ToDictionary(
                kvp => kvp.Key.ToString()!,
                kvp => kvp.Value
            );


            // Read SupportFiles
            //var supportFiles = ((rawDictionary["Metadata"] as Dictionary<object, object>)?["SupportFiles"] as List<object> ?? [])
            //    .OfType<Dictionary<object, object>>()
            //    .Select(d => new SupportFile(
            //        d["Name"]?.ToString() ?? string.Empty,
            //        d["Content"]?.ToString() ?? string.Empty
            //    ))
            //    .ToDictionary(sf => sf.Name);

            // Read Points
            var points = (rawDictionary["Points"] as List<object> ?? [])
                .OfType<Dictionary<object, object>>()
                .Select(d => {
                    var location = d["Location"]?.ToString() ?? string.Empty;
                    var split = location.Split(',');
                    var point = new Point(
                        double.Parse(split[0], CultureInfo.InvariantCulture),
                        double.Parse(split[1], CultureInfo.InvariantCulture)
                    ) {
                        Name = d["Name"].ToString()
                    };

                    if (d.TryGetValue("Association", out var assocObj) && assocObj is List<object> assocList) {
                        foreach (var item in assocList) {
                            if (item is Dictionary<object, object> asso) {
                                var association = new Association {
                                    To = asso["To"]?.ToString() ?? "",
                                    Name = asso["Name"]?.ToString() ?? "",
                                    Role = asso["Role"]?.ToString() ?? ""
                                };

                                point.AddAssociation(association);
                            }
                        }
                    }
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

                    if (d.TryGetValue("Association", out var assocObj) && assocObj is List<object> assocList) {
                        foreach (var item in assocList) {
                            if (item is Dictionary<object, object> asso) {
                                var association = new Association {
                                    To = asso["To"]?.ToString() ?? "",
                                    Name = asso["Name"]?.ToString() ?? "",
                                    Role = asso["Role"]?.ToString() ?? ""
                                };

                                pointSet.AddAssociation(association);
                            }
                        }
                    }

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
                    var curve = new Curve(
                        start: d["Start"].ToString(),
                        end: d["End"].ToString(),
                        vertices: [.. vertices]
                    ) {
                        Name = d["Name"].ToString(),
                    };

                    if (d.TryGetValue("Association", out var assocObj) && assocObj is List<object> assocList) {
                        foreach (var item in assocList) {
                            if (item is Dictionary<object, object> asso) {
                                var association = new Association {
                                    To = asso["To"]?.ToString() ?? "",
                                    Name = asso["Name"]?.ToString() ?? "",
                                    Role = asso["Role"]?.ToString() ?? ""
                                };

                                curve.AddAssociation(association);
                            }
                        }
                    }

                    return curve;
                }).ToDictionary(c => c.Name!);


            // Read CompositeCurves
            var compositeCurves = (rawDictionary["CompositeCurves"] as List<object> ?? [])
                .OfType<Dictionary<object, object>>()
                .Select(d => {
                    var compositeCurve = new CompositeCurve(
                        d["Components"]?.ToString()!) {
                        Name = d["Name"].ToString()
                    };

                    if (d.TryGetValue("Association", out var assocObj) && assocObj is List<object> assocList) {
                        foreach (var item in assocList) {
                            if (item is Dictionary<object, object> asso) {
                                var association = new Association {
                                    To = asso["To"]?.ToString() ?? "",
                                    Name = asso["Name"]?.ToString() ?? "",
                                    Role = asso["Role"]?.ToString() ?? ""
                                };

                                compositeCurve.AddAssociation(association);
                            }
                        }
                    }

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

                    if (d.TryGetValue("Association", out var assocObj) && assocObj is List<object> assocList) {
                        foreach (var item in assocList) {
                            if (item is Dictionary<object, object> asso) {
                                var association = new Association {
                                    To = asso["To"]?.ToString() ?? "",
                                    Name = asso["Name"]?.ToString() ?? "",
                                    Role = asso["Role"]?.ToString() ?? ""
                                };

                                surface.AddAssociation(association);
                            }
                        }
                    }

                    return surface;
                }).ToDictionary(s => s.Name!);


            return new DatasetUpdate() {
                Features = features,
                //SupportFiles = supportFiles,
                InformationTypes = informationTypes,
                Metadata = metadata,
                Points = points,
                Depths = depths,
                Curves = curves,
                CompositeCurves = compositeCurves,
                Surfaces = surfaces
            };
        }

        public static string AppendUpdate(string root, string update) {
            var supportFiles = new List<Dictionary<object, object>>();

            var dataset = Converter.Deserialize<Dictionary<object, object>>(root);
            var updates = Converter.Deserialize<Dictionary<string, object>>(update);

            if (dataset.TryGetValue("Metadata", out var metadataObj)
                && metadataObj is Dictionary<object, object> metadata
                && metadata.TryGetValue("SupportFiles", out var supportFilesObj)
                && supportFilesObj is List<object> rawSupportFiles) {
                supportFiles = [.. rawSupportFiles.Cast<Dictionary<object, object>>()];
            }
            var features = (dataset["Features"] as List<object>)!.Cast<Dictionary<object, object>>().ToList();
            var informationTypes = (dataset["InformationTypes"] as List<object>)!.Cast<Dictionary<object, object>>().ToList();
            var points = (dataset["Points"] as List<object>)!.Cast<Dictionary<object, object>>().ToList();
            var depths = (dataset["Depths"] as List<object>)!.Cast<Dictionary<object, object>>().ToList();
            var curves = (dataset["Curves"] as List<object>)!.Cast<Dictionary<object, object>>().ToList();
            var compositeCurves = (dataset["CompositeCurves"] as List<object>)!.Cast<Dictionary<object, object>>().ToList();
            var surfaces = (dataset["Surfaces"] as List<object>)!.Cast<Dictionary<object, object>>().ToList();


            // SupportFile delete
            if (updates.TryGetValue("fileDel", out var fileDelValue)) {
                var fileDels = fileDelValue as List<object> ?? [];
                foreach (var fileDel in fileDels) {
                    var supportFile = supportFiles.FirstOrDefault(e => e["Name"].ToString() == fileDel.ToString());

                    if (supportFile != null)
                        supportFiles.Remove(supportFile);
                }
            }
            // SupportFile add
            if (updates.TryGetValue("fileAdd", out var fileAddValue)) {
                var fileAdds = (fileAddValue as List<object>)!.Cast<Dictionary<object, object>>().ToList();

                foreach (var fileAdd in fileAdds) {
                    if (fileAdd != null)
                        supportFiles.Add(fileAdd);
                }
            }
            // InformationType delete
            if (updates.TryGetValue("infDel", out var infDelValue)) {
                var infDels = infDelValue as List<object> ?? [];
                foreach (var infDel in infDels) {
                    var informationType = informationTypes.FirstOrDefault(e => e["ID"].ToString() == infDel.ToString());

                    if (informationType != null)
                        informationTypes.Remove(informationType);
                }
            }
            // InformationType add
            if (updates.TryGetValue("infAdd", out var infAddValue)) {
                var infAdds = (infAddValue as List<object>)!.Cast<Dictionary<object, object>>().ToList();

                foreach (var infAdd in infAdds) {
                    if (infAdd != null)
                        informationTypes.Add(infAdd);
                }
            }
            // Feature delete
            if (updates.TryGetValue("fDel", out var featureDelValue)) {
                var fDels = featureDelValue as List<object> ?? [];
                foreach (var fDel in fDels) {
                    var feature = features.FirstOrDefault(e => e["Foid"].ToString() == fDel.ToString());

                    if (feature != null)
                        features.Remove(feature);
                }
            }
            // Feature add
            if (updates.TryGetValue("fAdd", out var featureAddValue)) {
                var fAdds = (featureAddValue as List<object>)!.Cast<Dictionary<object, object>>().ToList();

                foreach (var fAdd in fAdds) {
                    if (fAdd != null)
                        features.Add(fAdd);
                }
            }
            // Geometry delete
            if (updates.TryGetValue("gDel", out var geometryDelValue)) {
                var gDels = geometryDelValue as List<object> ?? [];
                foreach (var gDel in gDels) {
                    // Points
                    var point = points.FirstOrDefault(e => e["Name"].ToString() == gDel.ToString());

                    if (point != null)
                        points.Remove(point);

                    // Depths
                    var depth = depths.FirstOrDefault(e => e["Name"].ToString() == gDel.ToString());

                    if (depth != null)
                        depths.Remove(depth);

                    // Curves
                    var curve = curves.FirstOrDefault(e => e["Name"].ToString() == gDel.ToString());

                    if (curve != null)
                        curves.Remove(curve);

                    // CompositeCurves
                    var compositeCurve = compositeCurves.FirstOrDefault(e => e["Name"].ToString() == gDel.ToString());

                    if (compositeCurve != null)
                        compositeCurves.Remove(compositeCurve);

                    // Surfaces
                    var surface = surfaces.FirstOrDefault(e => e["Name"].ToString() == gDel.ToString());

                    if (surface != null)
                        surfaces.Remove(surface);
                }
            }
            // Geometry add
            if (updates.TryGetValue("gAdd", out var geometryAddValue)) {
                var gAdds = (geometryAddValue as List<object>)!.Cast<Dictionary<object, object>>().ToList();

                foreach (var gAdd in gAdds) {
                    var name = gAdd["Name"].ToString()!;
                    if (gAdd == null)
                        continue;
                    switch (name[0]) {
                        case 'P': // Point
                            if (!gAdd.ContainsKey("Z"))         // if no Z, its point
                                points.Add(gAdd);
                            else
                                depths.Add(gAdd);
                            break;

                        case 'C': // Curves
                            if (!gAdd.ContainsKey("Vertices"))  // if no Vertices, its composite curve
                                compositeCurves.Add(gAdd);
                            else                               // if vertices, its a curve
                                curves.Add(gAdd);
                            break;

                        case 'S':   // Surfaces
                            surfaces.Add(gAdd);
                            break;

                        default:
                            System.Diagnostics.Debugger.Break();
                            break;
                    }
                }
            }

            // Save changes
            dataset["Features"] = features;
            dataset["InformationTypes"] = informationTypes;
            dataset["Points"] = points;
            dataset["Depths"] = depths;
            dataset["Curves"] = curves;
            dataset["CompositeCurves"] = compositeCurves;
            dataset["Surfaces"] = surfaces;
            (metadataObj as Dictionary<object, object>)!["SupportFiles"] = supportFiles;

            return Converter.Serialize(dataset);
        }
        private static FeatureDiff FeatureEquals(Dictionary<string, object> rootFeatures, Dictionary<string, object> updateFeatures) {
            // Updated
            var updatedKeys = rootFeatures.Keys
                .Intersect(updateFeatures.Keys)
                .Where(k => !Converter.Serialize(rootFeatures[k]).Equals(Converter.Serialize(updateFeatures[k])));

            var featureDiff = new FeatureDiff(
                // Added
                updateFeatures.Keys
                    .Except(rootFeatures.Keys)
                    .Concat(updatedKeys)
                    .ToDictionary(k => k!, k => updateFeatures[k]),

                // Deleted
                rootFeatures.Keys
                    .Except(updateFeatures.Keys)
                    .Concat(updatedKeys)
                    .ToDictionary(k => k!, k => rootFeatures[k])
            );

            return featureDiff;
        }

        private static MetadataUpdate MetadataEquals(Dictionary<string, object> rootFeatures, Dictionary<string, object> updateFeatures) {
            //// Updated
            //var updatedKeys = rootFeatures.Keys
            //    .Intersect(updateFeatures.Keys)
            //    .Where(k => !Converter.Serialize(rootFeatures[k]).Equals(Converter.Serialize(updateFeatures[k])));

            //var metadataDiff = new MetadataDiff(
            //    // Added
            //    updateFeatures.Keys
            //        .Except(rootFeatures.Keys)
            //        .Concat(updatedKeys)
            //        .ToDictionary(k => k!, k => updateFeatures[k]),

            //    // Deleted
            //    rootFeatures.Keys
            //        .Except(updateFeatures.Keys)
            //        .Concat(updatedKeys)
            //        .ToDictionary(k => k!, k => rootFeatures[k])
            //);

            // Only take the newest for now. TODO Detect specific updates in supportfiles?

            var stringed = Converter.Serialize(updateFeatures);

            var metadataDiff = Converter.Deserialize<MetadataUpdate>(stringed);

            return metadataDiff;
        }

        private static SupportFileDiff SupportFileEquals(Dictionary<string, SupportFile> rootcasted, Dictionary<string, SupportFile> updatecasted) {
            // Updated
            var updatedKeys = rootcasted.Keys
                .Intersect(updatecasted.Keys)
                .Where(k => !rootcasted[k].Equals(updatecasted[k]));

            var supportFileDiff = new SupportFileDiff(
                // Added
                updatecasted.Keys
                    .Except(rootcasted.Keys)
                    .Concat(updatedKeys)
                    .ToDictionary(k => k!, k => updatecasted[k].Content),

                // Deleted
                rootcasted.Keys
                    .Except(updatecasted.Keys)
                    .Concat(updatedKeys)
                    .ToDictionary(k => k!, k => rootcasted[k].Content)
            );

            return supportFileDiff;
        }
        private static InformationTypeDiff InformationTypeEquals(Dictionary<string, object> rootInformationTypes, Dictionary<string, object> updateInformationTypes) {
            // Updated
            var updatedKeys = rootInformationTypes.Keys
                .Intersect(updateInformationTypes.Keys)
                .Where(k => !Converter.Serialize(rootInformationTypes[k]).Equals(Converter.Serialize(updateInformationTypes[k])));

            var informationTypeDiff = new InformationTypeDiff(
                // Added
                updateInformationTypes.Keys
                    .Except(rootInformationTypes.Keys)
                    .Concat(updatedKeys)
                    .ToDictionary(k => k!, k => updateInformationTypes[k]),

                // Deleted
                rootInformationTypes.Keys
                    .Except(updateInformationTypes.Keys)
                    .Concat(updatedKeys)
                    .ToDictionary(k => k!, k => rootInformationTypes[k])
            );

            return informationTypeDiff;
        }
        private static GeometryDiff GeometryEquals<T>(Dictionary<string, T> originalDict, Dictionary<string, T> updatedDict) where T : Geometry {
            // Updated
            var updatedKeys = originalDict.Keys
                .Intersect(updatedDict.Keys)
                .Where(k => !originalDict[k].Equals(updatedDict[k]));

            var geometryDiff = new GeometryDiff(
                // Added 
                updatedDict.Keys
                    .Except(originalDict.Keys)
                    .Concat(updatedKeys)
                    .ToDictionary(k => updatedDict[k].Name!, k => updatedDict[k] as Geometry),

                // Deleted 
                originalDict.Keys
                    .Except(updatedDict.Keys)
                    .Concat(updatedKeys)
                    .ToDictionary(k => originalDict[k].Name!, k => originalDict[k] as Geometry)
            );
            return geometryDiff;
        }

        public class DatasetUpdate
        {
            // public Dictionary<string, SupportFile> SupportFiles { get; init; } = [];
            public Dictionary<string, object> Metadata { get; init; } = [];
            public Dictionary<string, object> Features { get; init; } = [];
            public Dictionary<string, object> InformationTypes { get; init; } = [];
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
        public ICollection<SupportFile>? SupportFiles => _supportFiles.Count != 0 ? _supportFiles : null;
        private readonly ICollection<SupportFile> _supportFiles = [];

        public void AddSupportFile(string name, string content) => _supportFiles.Add(new(name, content));
    }

    public class SupportFile(string Name, string Content)
    {
        [YamlMember(Order = 0)]
        public string Name = Name;
        [YamlMember(Order = 1)]
        public string Content = Content;
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
            Matrix.Factory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(Coordinate.X, Coordinate.Y)).ToText()["Point (".Length..].Trim(')').Replace(' ', ',');

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
            string.Join(',', Points.Select(e => Matrix.Factory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(e.X, e.Y)).ToText()["Point (".Length..].Trim(')').Replace(' ', ',')));

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
            string.Join(',', Coordinate.Select(e => Matrix.Factory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(e.X, e.Y)).ToText()["Point (".Length..].Trim(')').Replace(' ', ',')));

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
    }

    public class Association
    {
        public string To { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Role { get; set; } = default!;
    }
}