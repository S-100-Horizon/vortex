using S100FC.Topology;
using System.Globalization;
using YamlDotNet.Serialization;

namespace S100FC.YAML
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

        public ICollection<Information>? InformationTypes => this._informationTypes.Count != 0 ? this._informationTypes : null;
        public ICollection<Point>? Points => this._points.Count != 0 ? this._points : null;
        public ICollection<Curve>? Curves => this._curves.Count != 0 ? this._curves : null;
        public ICollection<CompositeCurve>? CompositeCurves => this._compositeCurves.Count != 0 ? this._compositeCurves : null;
        public ICollection<PointSet>? Depths => this._pointSets.Count != 0 ? this._pointSets : null;
        public ICollection<Surface>? Surfaces => this._surfaces.Count != 0 ? this._surfaces : null;
        public ICollection<Feature>? Features => this._features.Count != 0 ? this.SortedFeatures() : null;

        private readonly ICollection<Information> _informationTypes = new HashSet<Information>();
        private readonly ICollection<Point> _points = new HashSet<Point>();
        private readonly ICollection<PointSet> _pointSets = new HashSet<PointSet>();
        private readonly ICollection<Curve> _curves = new HashSet<Curve>();
        private readonly ICollection<CompositeCurve> _compositeCurves = new HashSet<CompositeCurve>();
        private readonly ICollection<Surface> _surfaces = new HashSet<Surface>();
        private readonly ICollection<Feature> _features = new HashSet<Feature>();

        public Dataset AddPoint(Point point) {
            this._points.Add(point);
            return this;
        }
        public Dataset AddPointSet(PointSet pointSet) {
            this._pointSets.Add(pointSet);
            return this;
        }
        public Dataset AddCurve(Curve curve) {
            this._curves.Add(curve);
            return this;
        }
        public Dataset AddCompositeCurve(CompositeCurve compositeCurve) {
            this._compositeCurves.Add(compositeCurve);
            return this;
        }

        public Dataset AddSurface(Surface surface) {
            this._surfaces.Add(surface);
            return this;
        }

        public Dataset AddFeature(Feature feature) {
            this._features.Add(feature);
            return this;
        }

        public Dataset AddInformation(Information information) {
            this._informationTypes.Add(information);
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
            var foidToFeature = this._features.ToDictionary(f => f.Foid);
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

            foreach (var f in this._features)
                Visit(f);

            return sorted;
        }
    }

    public record FeatureDiff(
        Dictionary<string, object> Added,
        Dictionary<string, object> Deleted,
        Dictionary<string, object> Updated
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

    public class MetadataUpdate()
    {
        public string? OrganisationName { get; set; }
        public string? City { get; set; }
        public string? AdministrativeArea { get; set; }
        public string? ElectronicMailAddress { get; set; }

        public string? Country { get; set; }

        public string? PrivateKey { get; set; }
        public string? Certificate { get; set; }

        public string? Producer { get; set; }
        public string? ProducerCode { get; set; }
        public ICollection<SupportFileUpdate>? SupportFiles { get; set; }
    }
    public class SupportFileUpdate()
    {
        [YamlMember(Order = 0)]
        public string? Name { get; set; }
        [YamlMember(Order = 1)]
        public string? Content { get; set; }
    }
    public sealed record DeletedFeature(
        string Name,
        string Foid
    );


    public class DatasetDelta()
    {
        public string? CellName { get; set; }
        public string? Comment { get; set; }
        public int? Edition { get; set; }
        public int? Update { get; set; }
        [YamlMember(Alias = "encver", ApplyNamingConventions = false)]
        public string? ENCVer { get; set; }
        [YamlMember(Alias = "FCVer", ApplyNamingConventions = false)]
        public string? FCVer { get; set; }

        public MetadataUpdate? Metadata { get; set; }

        [YamlMember(Alias = "InformationTypes", ApplyNamingConventions = false, DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public ICollection<object> InformationTypesAdded { get; set; } = [];
        [YamlMember(Alias = "InfDel", ApplyNamingConventions = false, DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public ICollection<string> InformationTypesDeleted { get; set; } = [];
        [YamlMember(Alias = "Features", ApplyNamingConventions = false, DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public ICollection<object> FeaturesAdded { get; set; } = [];
        [YamlMember(Alias = "FDel", ApplyNamingConventions = false, DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public ICollection<DeletedFeature> FeaturesDeleted { get; set; } = [];
        [YamlMember(Alias = "GDel", ApplyNamingConventions = false, DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public ICollection<string> GeometriesDeleted { get; set; } = [];
        [YamlMember(Alias = "Points", ApplyNamingConventions = false, DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public ICollection<Geometry> PointsAdded { get; set; } = [];
        [YamlMember(Alias = "Depths", ApplyNamingConventions = false, DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public ICollection<Geometry> DepthsAdded { get; set; } = [];
        [YamlMember(Alias = "Curves", ApplyNamingConventions = false, DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public ICollection<Geometry> CurvesAdded { get; set; } = [];
        [YamlMember(Alias = "CompositeCurves", ApplyNamingConventions = false, DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public ICollection<Geometry> CompositeCurvesAdded { get; set; } = [];
        [YamlMember(Alias = "Surfaces", ApplyNamingConventions = false, DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public ICollection<Geometry> SurfacesAdded { get; set; } = [];

        public void AddGeometryDiff(string type, Geometry data) {
            switch (type?.ToLowerInvariant()) {
                case "point":
                    if (data is Point p) this.PointsAdded.Add(p);
                    break;

                case "pointset":
                    if (data is PointSet ps) this.DepthsAdded.Add(ps);
                    break;

                case "curve":
                    if (data is Curve c) this.CurvesAdded.Add(c);
                    break;

                case "surface":
                    if (data is Surface s) this.SurfacesAdded.Add(s);
                    break;

                case "compositecurve":
                    if (data is CompositeCurve cc) this.CompositeCurvesAdded.Add(cc);
                    break;

                default:
                    throw new NotImplementedException($"Geometry type '{type}' is not supported.");
            }
        }

        [YamlIgnore]
        public bool HasEdits => this.PointsAdded.Count != 0 ||
                            this.CurvesAdded.Count != 0 ||
                            this.CompositeCurvesAdded.Count != 0 ||
                            this.SurfacesAdded.Count != 0 ||
                            this.FeaturesAdded.Count != 0 ||
                            this.FeaturesDeleted.Count != 0 ||
                            this.GeometriesDeleted.Count != 0 ||
                            this.InformationTypesAdded.Count != 0 ||
                            this.InformationTypesDeleted.Count != 0;
    }

    public static class DatasetComparer
    {
        /// <summary>
        /// Compares two YAML datasets and build a delta object
        /// </summary>
        /// <returns>A DatasetDelta object, which can be serialized to a delta yaml dataset</returns>

        public static DatasetDelta Compare(string root, string update) {
            var delta = new DatasetDelta();
            var rootDataset = ReadDataset(root);
            var updateDataset = ReadDataset(update);

            var features = FeatureEquals(rootDataset.Features, updateDataset.Features);
            var informationTypes = InformationTypeEquals(rootDataset.InformationTypes, updateDataset.InformationTypes);
            var metadata = MetadataEquals(rootDataset.Metadata, updateDataset.Metadata);

            // Iterate new features
            foreach (var feature in features.Added) {
                delta.FeaturesAdded.Add(feature.Value);
                var dict = feature.Value as Dictionary<object, object>;
                var targetType = dict?["Prim"]?.ToString() ?? "";
                var id = dict?["Geometry"]?.ToString() ?? "";

                // Figure out if the newly added feature references a new or existing geometry
                var rootGeometryDict = rootDataset.Dictionary(targetType)!;
                var updateGeometryDict = updateDataset.Dictionary(targetType)!;

                if (!rootGeometryDict.ContainsKey(id))
                    delta.AddGeometryDiff(targetType, updateGeometryDict[id]);
            }


            // Iterate updated features
            foreach (var feature in features.Updated) {
                delta.FeaturesAdded.Add(feature.Value);
               


                var dict = feature.Value as Dictionary<object, object>;
                var targetType = dict?["Prim"]?.ToString() ?? "";
                var id = dict?["Geometry"]?.ToString() ?? "";
                var name = dict?["Name"]?.ToString() ?? "";
                var foid = feature.Key;

                delta.FeaturesDeleted.Add(new(name, feature.Key));

                if (!rootDataset.Features.TryGetValue(foid, out var featureValue))
                    throw new InvalidOperationException("Incorrectly labelled as an update"); // Incorrectly labelled as an update

                var oldDict = featureValue as Dictionary<object, object>;
                var oldId = oldDict?.ContainsKey("Geometry") == true ? oldDict["Geometry"]?.ToString() ?? "" : "";

                // 3. If geometries are the same, do nothing
                if (id == oldId)
                    continue;

                var rootGeometryDict = rootDataset.Dictionary(targetType)!;
                var updateGeometryDict = updateDataset.Dictionary(targetType)!;


                // If new feature is updated to a geometry that DOESNT exist in root, Add new _geometriesAdded && check for cleanup
                if (!rootGeometryDict.ContainsKey(id))
                    delta.AddGeometryDiff(targetType, updateGeometryDict[id]);


                // If the old geometry is no longer referenced by any feature in the new dataset, cleanup
                if (!updateGeometryDict.ContainsKey(oldId!))
                    delta.GeometriesDeleted.Add(oldId!);
            }


            // Iterate deleted features
            foreach (var feature in features.Deleted) {
              

                var dict = feature.Value as Dictionary<object, object>;
                var targetType = dict?["Prim"]?.ToString() ?? "";
                var id = dict?["Geometry"]?.ToString() ?? "";
                var name = dict?["Name"]?.ToString() ?? "";
                var updateGeometryDict = updateDataset.Dictionary(targetType)!;


                delta.FeaturesDeleted.Add(new(name, feature.Key));

                // If the geometry is no longer referenced by any feature in the new dataset, cleanup
                if (!updateGeometryDict.ContainsKey(id))
                    delta.GeometriesDeleted.Add(id);
            }


            delta.Metadata = metadata;
            delta.InformationTypesAdded = informationTypes.Added.Values;
            delta.InformationTypesDeleted = informationTypes.Deleted.Keys;


            return delta;
        }

        private static DatasetUpdate ReadDataset(string dataset) {
            // Deserialize to Dictionary
            var rawDictionary = S100FC.YAML.Converter.Deserialize<Dictionary<object, object>>(dataset);

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
            )!;


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
            var curves = (rawDictionary["Curves"] as List<object> ?? [])
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
            if (updates.TryGetValue("InformationTypes", out var infAddValue)) {
                var infAdds = (infAddValue as List<object>)!.Cast<Dictionary<object, object>>().ToList();

                foreach (var infAdd in infAdds) {
                    if (infAdd != null)
                        informationTypes.Add(infAdd);
                }
            }
            // Feature delete
            if (updates.TryGetValue("FDel", out var featureDelValue)) {
                var fDels = featureDelValue as List<object> ?? [];
                foreach (var fDel in fDels) {
                    var feature = features.FirstOrDefault(e => e["Foid"].ToString() == fDel.ToString());

                    if (feature != null)
                        features.Remove(feature);
                }
            }
            // Feature add
            if (updates.TryGetValue("Features", out var featureAddValue)) {
                var fAdds = (featureAddValue as List<object>)!.Cast<Dictionary<object, object>>().ToList();

                foreach (var fAdd in fAdds) {
                    if (fAdd != null)
                        features.Add(fAdd);
                }
            }
            // Geometry delete
            if (updates.TryGetValue("GDel", out var geometryDelValue)) {
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
            if (updates.TryGetValue("Points", out var geometryAddValue)) {
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
            var updatedKeys = rootFeatures.Keys.Intersect(updateFeatures.Keys).Where(k => !Converter.Serialize(rootFeatures[k]).Equals(Converter.Serialize(updateFeatures[k])));

            var featureDiff = new FeatureDiff(
                // Added
                updateFeatures.Keys.Except(rootFeatures.Keys).ToDictionary(k => k!, k => updateFeatures[k]),

                // Deleted
                rootFeatures.Keys.Except(updateFeatures.Keys).ToDictionary(k => k!, k => rootFeatures[k]),

                // Updated
                updatedKeys.ToDictionary(k => k!, k => updateFeatures[k])
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


        public class DatasetUpdate
        {
            //public Dictionary<string, SupportFile> SupportFiles { get; init; } = [];
            public Dictionary<string, object> Metadata { get; init; } = [];
            public Dictionary<string, object> Features { get; init; } = [];
            public Dictionary<string, object> InformationTypes { get; init; } = [];
            public Dictionary<string, Point> Points { get; init; } = [];
            public Dictionary<string, PointSet> Depths { get; init; } = [];
            public Dictionary<string, Curve> Curves { get; init; } = [];
            public Dictionary<string, CompositeCurve> CompositeCurves { get; init; } = [];
            public Dictionary<string, Surface> Surfaces { get; init; } = [];

            public Dictionary<string, Geometry>? Dictionary(string type) {
                return type?.ToLowerInvariant() switch {
                    "point" => this.Points.ToDictionary(k => k.Key, v => (Geometry)v.Value),
                    "pointset" => this.Depths.ToDictionary(k => k.Key, v => (Geometry)v.Value),
                    "curve" => this.Curves.ToDictionary(k => k.Key, v => (Geometry)v.Value),
                    "surface" => this.Surfaces.ToDictionary(k => k.Key, v => (Geometry)v.Value),
                    "compositecurve" => this.CompositeCurves.ToDictionary(k => k.Key, v => (Geometry)v.Value),
                    "" => null,
                    _ => null
                };
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
        public ICollection<SupportFile>? SupportFiles => this._supportFiles.Count != 0 ? this._supportFiles : null;
        private readonly ICollection<SupportFile> _supportFiles = [];

        public void AddSupportFile(string name, string content) => this._supportFiles.Add(new(name, content));
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
        public ICollection<Association>? Association => this._associations.Any() ? this._associations : null;
        private readonly ICollection<Association> _associations = new HashSet<Association>();
        public void AddAssociation(Association association) => this._associations.Add(association);
    }

    public class Point(double x, double y) : Geometry
    {
        [YamlMember(Order = 1)]
        public string? Location => this.Coordinate is null ? string.Empty :
            Matrix.Factory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(this.Coordinate.X, this.Coordinate.Y)).ToText()["Point (".Length..].Trim(')').Replace(' ', ',');

        [YamlIgnore]
        public Coordinate? Coordinate { get; private set; } = new Coordinate(x, y);

        public override bool Equals(object? obj) {
            return this.Equals(obj as Point);
        }

        public bool Equals(Point? other) {
            if (other is null)
                return false;

            return this.Name == other.Name && this.Location == other.Location && Enumerable.SequenceEqual(this.Association ?? [], other.Association ?? []);
        }

        public override int GetHashCode() {
            return HashCode.Combine(this.Name, this.Location);
        }
    }

    public class PointSet(Coordinate[] points, double[] depths) : Geometry
    {
        [YamlMember(Order = 1)]
        public string? Location => this.Points is null ? string.Empty :
            string.Join(',', this.Points.Select(e => Matrix.Factory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(e.X, e.Y)).ToText()["Point (".Length..].Trim(')').Replace(' ', ',')));

        [YamlMember(Order = 2)]
        public string? Z => this.Depths is null ? string.Empty : string.Join(",", this.Depths.Select(e => e.ToString(CultureInfo.InvariantCulture)));

        [YamlIgnore]
        public double[] Depths { get; private set; } = depths;

        [YamlIgnore]
        public Coordinate[] Points { get; private set; } = points;

        public override bool Equals(object? obj) {
            return this.Equals(obj as PointSet);
        }

        public bool Equals(PointSet? other) {
            if (other is null)
                return false;

            return this.Name == other.Name && this.Location == other.Location && this.Z == other.Z && Enumerable.SequenceEqual(this.Association ?? [], other.Association ?? []);
        }

        public override int GetHashCode() {
            return HashCode.Combine(this.Name, this.Location, this.Z);
        }
    }

    public class Curve : Geometry
    {
        private readonly string? _start;
        private readonly string? _end;

        public Curve(Coordinate[] vertices) {
            this.Coordinate = vertices;
        }
        public Curve(string start, Coordinate[] vertices) {
            this._start = start;

            this.Coordinate = vertices;
        }
        public Curve(string? start, string? end, Coordinate[] vertices) {
            this._start = start;
            this._end = end;

            this.Coordinate = vertices;
        }
        [YamlMember(Order = 1)]
        public string? Start => this._start;
        [YamlMember(Order = 2)]
        public string? End => this._end;
        [YamlMember(Order = 3)]
        public string? Vertices => this.Coordinate is null ? string.Empty :
            string.Join(',', this.Coordinate.Select(e => Matrix.Factory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(e.X, e.Y)).ToText()["Point (".Length..].Trim(')').Replace(' ', ',')));

        [YamlIgnore]
        public Coordinate[]? Coordinate { get; private set; }

        public override bool Equals(object? obj) {
            return this.Equals(obj as Curve);
        }

        public bool Equals(Curve? other) {
            if (other is null)
                return false;

            //return Name == other.Name && Vertices == other.Vertices;
            return this.Vertices == other.Vertices && Enumerable.SequenceEqual(this.Association ?? [], other.Association ?? []);
        }

        public override int GetHashCode() {
            return HashCode.Combine(this.Name, this.Vertices);
        }
    }

    public class CompositeCurve : Geometry
    {
        public CompositeCurve(string components) {
            this.Curves = components.Split(",");
        }

        public CompositeCurve(string[] curves) {
            this.Curves = curves;
        }
        [YamlMember(Order = 1)]
        public string Components => string.Join(",", this.Curves);

        [YamlIgnore]
        public string[] Curves { get; set; } = [];

        public override bool Equals(object? obj) {
            return this.Equals(obj as CompositeCurve);
        }

        public bool Equals(CompositeCurve? other) {
            if (other is null)
                return false;

            return this.Name == other.Name && this.Components == other.Components && Enumerable.SequenceEqual(this.Association ?? [], other.Association ?? []);
        }

        public override int GetHashCode() {
            return HashCode.Combine(this.Name, this.Components);
        }
    }

    public class Surface(string exterior) : Geometry
    {
        [YamlMember(Order = 1)]
        public string Exterior { get; set; } = exterior;

        [YamlIgnore]
        public string[]? InteriorRings { get; set; }
        [YamlMember(Order = 2)]

        public dynamic[]? Interior => this.InteriorRings?.Length == 0 ? null : this.InteriorRings?.Select(e => new { Hole = e }).ToArray();

        public override bool Equals(object? obj) {
            return this.Equals(obj as Surface);
        }

        public bool Equals(Surface? other) {
            if (other is null)
                return false;

            var nameEquals = string.Equals(this.Name, other.Name, StringComparison.Ordinal);
            var exteriorEquals = string.Equals(this.Exterior, other.Exterior, StringComparison.Ordinal);

            var interiorRingsEquals = (this.InteriorRings is null && other.InteriorRings is null) ||
                                      (this.InteriorRings is not null && other.InteriorRings is not null &&
                                       Enumerable.SequenceEqual(this.InteriorRings, other.InteriorRings));

            return nameEquals && exteriorEquals && interiorRingsEquals && Enumerable.SequenceEqual(this.Association ?? [], other.Association ?? []);
        }

        public override int GetHashCode() {
            var hash = new HashCode();
            hash.Add(this.Name);
            hash.Add(this.Exterior);

            if (this.InteriorRings != null) {
                foreach (var ring in this.InteriorRings) {
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
        public S100FC.InformationType? Attributes { get; set; }
    }

    public class Feature
    {
        public string? Name { get; set; }
        public Primitive Prim { get; set; }
        public string Foid { get; set; } = default!;
        public S100FC.FeatureType? Attributes { get; set; }
        public string? Geometry { get; set; }
        public string? Masks { get; set; }

        public ICollection<Association>? Association => this._associations.Any() ? this._associations : null;
        private readonly ICollection<Association> _associations = new HashSet<Association>();

        public ICollection<Association>? FeatureAssociation => this._featureAssociations.Any() ? this._featureAssociations : null;
        private readonly ICollection<Association> _featureAssociations = new HashSet<Association>();

        public Feature AddAssociation(Association association) {
            this._associations.Add(association);
            return this;
        }

        public Feature AddFeatureAssociation(Association association) {
            this._featureAssociations.Add(association);
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