namespace S100FC.YAML
{
    using S100FC.Topology;
    using Serilog;
    using System.Collections.Concurrent;
    using System.Globalization;
    using System.Linq;
    using System.Text.Json;

    public static class Extensions
    {
        public static void AddTopology(this Dataset dataset, IMatrix theMatrix) {
            // Curves
            CurveFeature? curveFeature = default;
            try {
                Log.Verbose("Adding curve #{count}", theMatrix.Curves.Count());

                var concurrent = new ConcurrentBag<Curve>();

                foreach (var c in theMatrix.Curves) {
                    curveFeature = c;
                    var coordinates = c.LineString.Coordinates.Select(e => new Coordinate(e.X, e.Y)).ToArray();

                    var first = dataset?.GetOrCreateStartPoint(coordinates, $"{c.Id}");
                    var last = dataset?.GetOrCreateEndPoint(coordinates, $"{c.Id}");

                    var curve = new Curve(first?.Name, last?.Name, coordinates) {
                        Name = $"C{c.Id}",
                    };

                    dataset!.AddCurve(curve);
                }
            }
            catch (Exception ex) {
                Log.Error("Exception! {ex} on curve: {curve}", ex, curveFeature?.Id);
            }


            //  Composite Curves
            CompositeCurveFeature? compositeCurveFeature = default;
            try {
                Log.Verbose("Adding compositecurve #{count}", theMatrix.CompositeCurves.Count());

                foreach (var c in theMatrix.CompositeCurves) {
                    compositeCurveFeature = c;

                    var compositecurveIds = new string[c.Curves.Length];
                    for (int i = 0; i < compositecurveIds.Length; i++) {
                        compositecurveIds[i] = c.Curves[i].Reverse ? $"RC{c.Curves[i].Id}" : $"C{c.Curves[i].Id}";
                    }

                    var components = string.Join(",", compositecurveIds);

                    var compositeCurve = new CompositeCurve(components) {
                        Name = $"C{c.Id}"
                    };

                    _ = dataset.AddCompositeCurve(compositeCurve);
                }
            }
            catch (Exception ex) {
                Log.Error("Exception! {ex} on compositecurve: {curve}", ex, compositeCurveFeature?.Id);
            }

            //  Surface
            SurfaceFeature? surfaceFeature = default;
            try {
                Log.Verbose("Adding surface #{count}", theMatrix.Surfaces.Count());

                foreach (var s in theMatrix.Surfaces) {
                    surfaceFeature = s;

                    var exteriorRing = surfaceFeature.Exterior.Reverse ? $"RC{surfaceFeature.Exterior.Id}" : $"C{surfaceFeature.Exterior.Id}";
                    var interiorRings = surfaceFeature?.Interior?.Select(e => e.Reverse ? $"RC{e.Id}" : $"C{e.Id}").ToArray();

                    var surface = new Surface(exteriorRing) {
                        InteriorRings = interiorRings,
                        Name = $"S{surfaceFeature!.Ref!.ToUpperInvariant().Substring(1)}",
                    };

                    _ = dataset.AddSurface(surface);
                    dataset.UpdateFeatureReferences($"S{surfaceFeature!.Id}", $"S{surfaceFeature.Ref!.ToUpperInvariant().Substring(1)}");
                }
            }
            catch (Exception ex) {
                Log.Error("Exception! {ex} on surface: {surface}", ex, surfaceFeature?.Id);
            }
        }

        public static void UpdateFeatureReferences(this Dataset dataset, string original, string target) {
            if (original == target) {
                Log.Error("Error! Original cant be same as target!");
                return;
            }

            foreach (var feature in dataset?.Features?.Where(e => e.Geometry == original) ?? []) {
                Log.Verbose("Updating feature geometry reference with original {original} and target: {target}", original, target);
                feature.Geometry = target;

                // Associations
                if (feature.FeatureAssociation == null || feature.FeatureAssociation.Count == 0)
                    continue;

                foreach (var asso in feature.FeatureAssociation.Where(e => e.To.Contains(original))) {
                    Log.Verbose("Updating feature association reference with original {original} and target: {target}", original, target);
                    asso.To = asso?.To?.Replace(original, target)!;
                }
            }
        }

        public static Point GetOrCreateStartPoint(this Dataset dataset, Coordinate[] curve, string name, int identifier = 0) {
            var pointLocation = string.Format(
                  CultureInfo.InvariantCulture,
                  "{0:0.#######},{1:0.#######}", curve[0].X, curve[0].Y
              );

            var datasetPoint = dataset?.Points?.FirstOrDefault(e => e.Location == pointLocation);

            if (datasetPoint == default) {
                var point = new Point(curve[0].X, curve[0].Y) {
                    Name = $"P{name}-{identifier}"
                };

                dataset!.AddPoint(point);

                return point;
            }
            else {
                return datasetPoint;
            }
        }

        public static Point GetOrCreateEndPoint(this Dataset dataset, Coordinate[] curve, string name, int identifier = 1) {
            var pointLocation = string.Format(
                CultureInfo.InvariantCulture,
                "{0:0.#######},{1:0.#######}", curve[^1].X, curve[^1].Y
            );

            var datasetPoint = dataset?.Points?.FirstOrDefault(e => e.Location == pointLocation);

            if (datasetPoint == default) {
                var point = new Point(curve[^1].X, curve[^1].Y) {
                    Name = $"P{name}-{identifier}"
                };

                dataset!.AddPoint(point);

                return point;
            }
            else {
                return datasetPoint;
            }
        }
        public static IEnumerable<string> GetFileNames(string json) {
            if(string.IsNullOrWhiteSpace(json))
                return [];
            //using var doc = JsonDocument.Parse(json);
            var dict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json) ?? [];

            // doc.RootElement.
            var keys = new[] { "fileReference", "pictorialRepresentation" };

            var results = dict
                .Where(kvp =>
                    keys.Any(k => kvp.Key.Contains(k, StringComparison.OrdinalIgnoreCase)) &&
                    kvp.Value.ValueKind == JsonValueKind.String)
                .Select(kvp => kvp.Value.GetString()!);


            return results ?? [];
            //foreach (var attr in doc.RootElement.GetProperty("attr").EnumerateArray()) {
            //    if (!attr.TryGetProperty("attr", out var innerAttrs))
            //        continue;

            //    foreach (var inner in innerAttrs.EnumerateArray()) {
            //        var code = inner.GetProperty("code").GetString();

            //        if (code?.Equals("fileReference", StringComparison.OrdinalIgnoreCase) == true
            //            || code?.Equals("pictorialRepresentation", StringComparison.OrdinalIgnoreCase) == true) {
            //            yield return inner.GetProperty("value").GetString()!;
            //        }
            //    }
            //}
        }

        public static string Serialize(this Dataset? dataset) {
            if ((dataset == null)) return string.Empty;
            return S100FC.YAML.Converter.Serialize(dataset);
        }

        public static void AddGeometry(this Dataset dataset, ArcGIS.Core.Geometry.Geometry geometry, string name) {
            switch (geometry) {
                case ArcGIS.Core.Geometry.MapPoint point: {                              // Point
                        var pointLocation = string.Format(
                             CultureInfo.InvariantCulture,
                             "{0:0.#######},{1:0.#######}", point.X, point.Y
                         );

                        var hashId = System.IO.Hashing.XxHash32.HashToUInt32(new NetTopologySuite.Geometries.Point(point.X, point.Y).ToBinary());

                        var datasetPoint = dataset?.Points?.FirstOrDefault(e => e.Name == $"P{hashId}");

                        // Create point if not exist
                        if (datasetPoint == default) {
                            var p = new Point(point.X, point.Y) {
                                Name = $"P{hashId}"
                            };

                            dataset?.AddPoint(p);
                        }

                        dataset?.UpdateFeatureReferences(name, $"P{hashId}"!);
                        break;
                    }
                case ArcGIS.Core.Geometry.Multipoint multiPoint: {   // Depths
                        var points = multiPoint.Points.Select(e => new Coordinate(e.X, e.Y)).ToArray();

                        var depths = multiPoint.Points.Select(e => Math.Round(e.Z, 7)).ToArray();

                        var hashId = System.IO.Hashing.XxHash32.HashToUInt32(new NetTopologySuite.Geometries.MultiPoint([.. multiPoint.Points.Select(e => new NetTopologySuite.Geometries.Point(e.X, e.Y, e.Z))]).ToBinary());

                        var pointSet = new PointSet(points, depths) { Name = $"P{hashId}" };
                        dataset.AddPointSet(pointSet);

                        dataset?.UpdateFeatureReferences(name, $"P{hashId}"!);
                        break;
                    }
                case ArcGIS.Core.Geometry.Polyline polyline:        // Curves are handled in Topology
                case ArcGIS.Core.Geometry.Polygon polygon:          // Surfaces are handled in Topology
                    break;
                default:
                    throw new ArgumentException($"Unsupported geometry type: {geometry.GeometryType}");
            }
        }

    }
}
