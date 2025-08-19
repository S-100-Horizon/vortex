namespace S100Framework.YAML
{
    using S100Framework.Topology;
    using Serilog;
    using System.Collections.Concurrent;
    using System.Globalization;
    using System.Linq;

    public static class Extensions
    {
        public static void AddTopology(this Dataset dataset, IMatrix theMatrix) {
            // Curves
            CurveFeature? curveFeature = default;
            try {
                Log.Information("Adding curve #{count}", theMatrix.Curves.Count());

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
                Log.Information("Adding compositecurve #{count}", theMatrix.CompositeCurves.Count());

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
                Log.Information("Adding surface #{count}", theMatrix.Surfaces.Count());

                foreach (var s in theMatrix.Surfaces) {
                    surfaceFeature = s;

                    var exteriorRing = s.Exterior.Reverse ? $"RC{s.Exterior.Id}" : $"C{s.Exterior.Id}";
                    var interiorRings = s?.Interior?.Select(e => e.Reverse ? $"RC{e.Id}" : $"C{e.Id}").ToArray();

                    var surface = new Surface(exteriorRing) {
                        InteriorRings = interiorRings,
                        //Name = s.Ref
                        Name = $"S{s?.Id}",
                    };

                    _ = dataset.AddSurface(surface);
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
                Log.Information("Updating feature geometry reference with original {original} and target: {target}", original, target);
                feature.Geometry = target;

                // Associations
                if (feature.FeatureAssociation == null || feature.FeatureAssociation.Count == 0)
                    continue;

                foreach (var asso in feature.FeatureAssociation.Where(e => e.To.Contains(original))) {
                    Log.Information("Updating feature association reference with original {original} and target: {target}", original, target);
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

        public static string Serialize(this Dataset? dataset) {
            if ((dataset == null)) return string.Empty;
            return S100Framework.YAML.Converter.Serialize(dataset);
        }
    }
}
