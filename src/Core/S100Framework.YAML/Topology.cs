using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using NetTopologySuite.Operation.Union;
using System.Collections.Concurrent;
using System.Diagnostics;
using IO = System.IO;

namespace S100Framework.YAML
{
    public class FeatureRef
    {
        public UInt64 Id { get; init; }
        public bool Reverse { get; init; } = false;
    }

    public abstract class FeatureType
    {
        private static UInt64 counter = 1;

        public UInt64 Id { get; init; } = Interlocked.Increment(ref FeatureType.counter);
    }

    public class CurveFeature : FeatureType
    {
        public CurveFeature(LineString lineString) {
            this.LineString = lineString;
            this.LineStringReverse = (LineString)lineString.Reverse();

            this.LineStringText = lineString.ToString();
            this.LineStringReverseText = this.LineStringReverse.ToString();
        }

        public LineString LineString { get; set; }

        public LineString LineStringReverse { get; set; }

        public string LineStringText { get; init; }
        public string LineStringReverseText { get; init; }

        public bool Equals(CurveFeature lineString) {
            if (lineString.LineStringText.Equals(this.LineStringText))
                return true;
            return false;
        }

        public bool Equals(LineString lineString) {
            if (lineString.ToString().Equals(this.LineStringText))
                return true;
            return false;
        }

        public override bool Equals(object? obj) {
            if (obj is CurveFeature curve)
                return (this.Equals(curve));
            if (obj is LineString lineString)
                return (this.Equals(lineString));
            return base.Equals(obj);
        }

        public override int GetHashCode() {
            return (int)System.IO.Hashing.XxHash32.HashToUInt32(this.LineString.ToBinary());
        }
    }

    public class CompositeCurveFeature : FeatureType
    {
        public FeatureRef[] Curves { get; init; } = [];
    }

    public class SurfaceFeature : FeatureType
    {
        public required FeatureRef Exterior { get; init; }

        public FeatureRef[]? Interior { get; init; } = default;

        public string? Ref { get; init; } = default;

        public LineString? LineString { get; set; } = default;
    }

    public record Polyline(long ObjectId, string name, LineString LineString);

    public record Polygon(long ObjectId, string name, LineString ExteriorRing, LineString[] InteriorRings) : Polyline(ObjectId, name, ExteriorRing);

    public class Topology
    {
        public GeometryFactory Factory { get; set; } = new GeometryFactory(new PrecisionModel(PrecisionModels.Floating));

        public required IList<CurveFeature> Curves { get; set; }

        public required IList<CompositeCurveFeature> CompositeCurves { get; set; }

        public required IList<SurfaceFeature> Surfaces { get; set; }

        public required IDictionary<string, string> Mapping { get; set; }

        public static void Build(S100Framework.YAML.Polyline[] polylines, S100Framework.YAML.Polygon[] polygons, S100Framework.YAML.Topology topology) {
            int count = polygons.Count();

            var equalsList = new List<string>();
            var equalsDictionary = new Dictionary<string, List<CurveFeature>>();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var matchPolylines = new ConcurrentDictionary<string, List<LineString>>();

            for (int i = 0; i < polylines.Length; i++) {
                //matchPolylines.GetOrAdd(polylines[i].name, []);
            }

            var matchPolygons = new ConcurrentDictionary<string, (List<LineString> exterior, List<LineString>[] interior)>();

            for (int i = 0; i < polygons.Length; i++) {
                //matchPolygons.GetOrAdd(polygons[i].name, ([], []));
            }

            var options = new ParallelOptions {
                MaxDegreeOfParallelism = 8,
            };

            var curvePolygons = new Dictionary<UInt64, LineString>();

            var curvePolygonsToObjectId = new Dictionary<UInt64, string>();

            //Log.Verbose("Loading...");

            foreach (var e in polygons) {
                var hash = IO.Hashing.XxHash64.HashToUInt64(e.ExteriorRing.ToBinary());
                var reverse = IO.Hashing.XxHash64.HashToUInt64(((LineString)e.ExteriorRing.Reverse()).ToBinary());
                if (!(curvePolygons.ContainsKey(hash) || curvePolygons.ContainsKey(reverse))) {
                    curvePolygons.Add(hash, e.LineString);
                    curvePolygonsToObjectId.Add(hash, $"e:{e.ObjectId}");
                }
                int index = 0;
                foreach (var i in e.InteriorRings) {
                    hash = IO.Hashing.XxHash64.HashToUInt64(i.ToBinary());
                    reverse = IO.Hashing.XxHash64.HashToUInt64(((LineString)i.Reverse()).ToBinary());
                    if (!(curvePolygons.ContainsKey(hash) || curvePolygons.ContainsKey(reverse))) {
                        curvePolygons.Add(hash, i);
                        curvePolygonsToObjectId.Add(hash, $"i{++index}{e.ObjectId}");
                    }
                }
            }

            //foreach (var e in polylines) {
            //    var hash = IO.Hashing.XxHash64.HashToUInt64(e.LineString.ToBinary());
            //    var reverse = IO.Hashing.XxHash64.HashToUInt64(((LineString)e.LineString.Reverse()).ToBinary());
            //    if (!(curvePolygons.ContainsKey(hash) || curvePolygons.ContainsKey(reverse))) {
            //        curvePolygons.Add(hash, e.LineString);
            //        curvePolygonsToObjectId.Add(hash, $"e:{e.ObjectId}");
            //    }
            //}

            //Log.Verbose("Intersection...");

            //options = new ParallelOptions {
            //    MaxDegreeOfParallelism = 1,
            //};

            //var filterPolygons = new List<long> { 175805, 175751 };

            Parallel.For(0, polygons.Length, options, (i) => {
                matchPolygons.GetOrAdd(polygons[i].name, ([], []));
                //if (!filterPolygons.Contains(polygons[i].ObjectId)) return;
                //if (polygons[i].ObjectId == 160361) System.Diagnostics.Debugger.Break();

                {
                    NetTopologySuite.Geometries.Geometry boundary1 = polygons[i].ExteriorRing;

                    var geometries = new List<LineString>();

                    for (var j = 0; j < polygons.Length; j++) {
                        if (j == i) continue;

                        var boundary2 = polygons[j].ExteriorRing;

                        if (boundary1.Disjoint(boundary2))
                            continue;

                        var contains = boundary1.Contains(boundary2);
                        var coveredby = boundary1.CoveredBy(boundary2);
                        var covers = boundary1.Covers(boundary2);
                        var crosses = boundary1.Crosses(boundary2);
                        var intersects = boundary1.Intersects(boundary2);
                        var overlaps = boundary1.Overlaps(boundary2);
                        //var touches = boundary1.Touches(boundary2);
                        //var within = boundary1.Within(boundary2);
                        //var equalsTopologically = boundary1.EqualsTopologically(boundary2);
                        //var relate = boundary1.Relate(boundary2, "1********");

                        //if (!(contains || equalsTopologically || overlaps))
                        //    continue;

                        if ((crosses && intersects) && !(contains | overlaps | coveredby))
                            continue;

                        var intersection = boundary1.Intersection(boundary2);

                        if (intersection is GeometryCollection geometryCollection) {
                            intersection = intersection.Factory.CreateMultiLineString(geometryCollection.OfType<LineString>().ToArray());
                        }

                        if (intersection == null || intersection.IsEmpty) continue;

                        intersection = intersection.Combine();

                        AddLineStringsFromGeometry(intersection, matchPolygons[polygons[i].name].exterior);

                        boundary1 = boundary1.SymmetricDifference(intersection);
                    }
                    if (!(boundary1 == null || boundary1.IsEmpty)) {
                        var g = topology.Factory.CreateMultiLineString(matchPolygons[polygons[i].name].exterior.ToArray());

                        var diff = boundary1.SymmetricDifference(g);
                        if (!(diff == null || diff.IsEmpty))
                            AddLineStringsFromGeometry(diff, matchPolygons[polygons[i].name].exterior);
                    }
                }

                if (polygons[i].InteriorRings.Any()) {
                    var indexOf = polygons[i].name;

                    matchPolygons[polygons[i].name] = matchPolygons[polygons[i].name] with {
                        interior = new List<LineString>[polygons[i].InteriorRings.Length],
                    };

                    UInt64[] exclude = [IO.Hashing.XxHash64.HashToUInt64(polygons[i].ExteriorRing.ToBinary())];
                    exclude = [.. exclude, .. polygons[i].InteriorRings.Select(e => IO.Hashing.XxHash64.HashToUInt64(e.ToBinary()))];

                    for (int k = 0; k < polygons[i].InteriorRings.Length; k++) {
                        NetTopologySuite.Geometries.Geometry boundary = (LineString)polygons[i].InteriorRings[k];//.Reverse();

                        //var hash = IO.Hashing.XxHash64.HashToUInt64(((LineString)polygons[i].InteriorRings[k]).ToBinary());

                        var interiorLineStrings = new List<LineString>();

                        foreach (var e in curvePolygons.Where(e => !exclude.Contains(e.Key))) {
                            var boundary2 = e.Value;

                            if (boundary.Disjoint(boundary2))
                                continue;

                            var contains = boundary.Contains(boundary2);
                            var coveredby = boundary.CoveredBy(boundary2);
                            var covers = boundary.Covers(boundary2);
                            var crosses = boundary.Crosses(boundary2);
                            var intersects = boundary.Intersects(boundary2);
                            var overlaps = boundary.Overlaps(boundary2);
                            //var touches = boundary.Touches(boundary2);
                            //var within = boundary.Within(boundary2);
                            var equalsTopologically = boundary.EqualsTopologically(boundary2);

                            if (equalsTopologically) continue;

                            if ((crosses && intersects) && !(contains | overlaps | coveredby))
                                continue;

                            var intersection = boundary.Intersection(boundary2);

                            if (intersection is GeometryCollection geometryCollection) {
                                intersection = intersection.Factory.CreateMultiLineString(geometryCollection.OfType<LineString>().ToArray());
                            }

                            if (intersection == null || intersection.IsEmpty) continue;

                            intersection = intersection.Combine();

                            AddLineStringsFromGeometry(intersection, interiorLineStrings);

                            boundary = boundary.SymmetricDifference(intersection);
                        }
                        if (!interiorLineStrings.Any())
                            interiorLineStrings.Add((LineString)polygons[i].InteriorRings[k]);
                        else if (!(boundary == null || boundary.IsEmpty)) {
                            var g = topology.Factory.CreateMultiLineString(interiorLineStrings.ToArray());

                            var diff = boundary.SymmetricDifference(g);

                            if (!(diff == null || diff.IsEmpty))
                                AddLineStringsFromGeometry(diff, interiorLineStrings);
                        }
                        matchPolygons[polygons[i].name].interior[k] = interiorLineStrings;
                    }
                }
            });

            //options = new ParallelOptions {
            //    MaxDegreeOfParallelism = 1,
            //};

            Parallel.For(0, polylines.Length, options, (i) => {
                matchPolylines.GetOrAdd(polylines[i].name, []);

                //if (polylines[i].ObjectId != 169521) return;
                //if (polylines[i].ObjectId == 169631) System.Diagnostics.Debugger.Break();
                var m = matchPolylines[polylines[i].name];

                NetTopologySuite.Geometries.Geometry boundary1 = polylines[i].LineString;

                var hash = IO.Hashing.XxHash3.HashToUInt64(polylines[i].LineString.ToBinary());

                foreach (var e in curvePolygons.Where(e => e.Key != hash)) {
                    var boundary2 = e.Value;
                    if (boundary1.Disjoint(boundary2))
                        continue;
                    //if (boundary1.Equals(boundary2))
                    //    continue;

                    var contains = boundary1.Contains(boundary2);
                    var coveredby = boundary1.CoveredBy(boundary2);
                    var covers = boundary1.Covers(boundary2);
                    var crosses = boundary1.Crosses(boundary2);
                    var intersects = boundary1.Intersects(boundary2);
                    var overlaps = boundary1.Overlaps(boundary2);
                    //var touches = boundary1.Touches(boundary2);
                    //var within = boundary1.Within(boundary2);
                    var equalsTopologically = boundary1.EqualsTopologically(boundary2);

                    var origin = curvePolygonsToObjectId[e.Key];

                    if (equalsTopologically) continue;

                    if ((crosses && intersects) && !(contains | overlaps | coveredby))
                        continue;

                    if (!(boundary1.Overlaps(boundary2) || boundary1.Contains(boundary2))) continue;

                    var intersection = boundary1.Intersection(boundary2);

                    if (intersection is GeometryCollection geometryCollection) {
                        intersection = intersection.Factory.CreateMultiLineString(geometryCollection.OfType<LineString>().ToArray());
                    }

                    if (intersection == null || intersection.IsEmpty) continue;

                    intersection = intersection.Combine();

                    AddLineStringsFromGeometry(intersection, m);

                    boundary1 = boundary1.SymmetricDifference(intersection);
                }
                if (!m.Any()) {
                    m.Add(polylines[i].LineString);
                }
                else if (!(boundary1 == null || boundary1.IsEmpty)) {
                    var g = topology.Factory.CreateMultiLineString(m.ToArray());

                    var diff = boundary1.SymmetricDifference(g);
                    if (!(diff == null || diff.IsEmpty))
                        AddLineStringsFromGeometry(diff, m);
                }
            });

            var mapping = new ConcurrentDictionary<string, string>();

            //Log.Verbose("Hashing...");

            var hashing = new Dictionary<ulong, (FeatureRef fetureRef, CurveFeature curve)>();

            foreach (var m in matchPolygons) {
                //if("S688985".Equals(m.Key)) System.Diagnostics.Debugger.Break();
                //if (m.Key.Equals("S238034")) System.Diagnostics.Debugger.Break();

                if (m.Value.exterior.Count < 2) {
                    var origin = polygons.Single(e => e.name == m.Key);

                    var hash = System.IO.Hashing.XxHash3.HashToUInt64(origin.LineString.AsBinary());

                    var f = new CurveFeature(origin.LineString);
                    if (!hashing.ContainsKey(hash)) {
                        hashing.Add(hash, (new FeatureRef {
                            Id = f.Id,
                            Reverse = false,
                        }, f));
                    }
                    hash = System.IO.Hashing.XxHash3.HashToUInt64(f.LineString.Reverse().AsBinary());
                    if (!hashing.ContainsKey(hash)) {
                        hashing.Add(hash, (new FeatureRef {
                            Id = f.Id,
                            Reverse = true,
                        }, f));
                    }
                }
                else {
                    foreach (var l in m.Value.exterior) {
                        var hash = IO.Hashing.XxHash3.HashToUInt64(l.AsBinary());
                        var f = new CurveFeature(l);
                        if (!hashing.ContainsKey(hash)) {
                            hashing.Add(hash, (new FeatureRef {
                                Id = f.Id,
                                Reverse = false,
                            }, f));
                        }
                        hash = IO.Hashing.XxHash3.HashToUInt64(l.Reverse().AsBinary());
                        if (!hashing.ContainsKey(hash)) {
                            hashing.Add(hash, (new FeatureRef {
                                Id = f.Id,
                                Reverse = true,
                            }, f));
                        }
                    }
                }
                if (m.Value.interior.Any()) {
                    for (int i = 0; i < m.Value.interior.Length; i++) {
                        foreach (var l in m.Value.interior[i]) {
                            var hash = IO.Hashing.XxHash3.HashToUInt64(l.AsBinary());
                            var f = new CurveFeature(l);
                            if (!hashing.ContainsKey(hash)) {
                                hashing.Add(hash, (new FeatureRef {
                                    Id = f.Id,
                                    Reverse = false,
                                }, f));
                            }
                            hash = IO.Hashing.XxHash3.HashToUInt64(l.Reverse().AsBinary());
                            if (!hashing.ContainsKey(hash)) {
                                hashing.Add(hash, (new FeatureRef {
                                    Id = f.Id,
                                    Reverse = true,
                                }, f));
                            }
                        }
                    }
                }
            }

            foreach (var m in matchPolylines) {
                var origin = polylines.Single(e => e.name == m.Key);

                //if (origin.ObjectId != 169521) continue;

                if (m.Value.Count < 2) {
                    var hash = IO.Hashing.XxHash3.HashToUInt64(origin.LineString.AsBinary());
                    var f = new CurveFeature(origin.LineString);
                    if (!hashing.ContainsKey(hash)) {
                        hashing.Add(hash, (new FeatureRef {
                            Id = f.Id,
                            Reverse = false,
                        }, f));
                    }
                    hash = IO.Hashing.XxHash3.HashToUInt64(f.LineString.Reverse().AsBinary());
                    if (!hashing.ContainsKey(hash)) {
                        hashing.Add(hash, (new FeatureRef {
                            Id = f.Id,
                            Reverse = true,
                        }, f));
                    }
                }
                else {
                    foreach (var l in m.Value) {
                        var simplified = l;
                        var hash = IO.Hashing.XxHash3.HashToUInt64(simplified.AsBinary());
                        var f = new CurveFeature(simplified);
                        if (!hashing.ContainsKey(hash)) {
                            hashing.Add(hash, (new FeatureRef {
                                Id = f.Id,
                                Reverse = false,
                            }, f));
                        }
                        hash = IO.Hashing.XxHash3.HashToUInt64(simplified.Reverse().AsBinary());
                        if (!hashing.ContainsKey(hash)) {
                            hashing.Add(hash, (new FeatureRef {
                                Id = f.Id,
                                Reverse = true,
                            }, f));
                        }
                    }
                }
            }

            //Log.Verbose("Matching...");

            var bagCurves = new ConcurrentBag<CurveFeature>();
            //var bagCompositeCurves = new ConcurrentBag<CompositeCurveFeature>();
            var bagCompositeCurves = new ConcurrentDictionary<string, CompositeCurveFeature>();
            var bagSurfaces = new ConcurrentBag<SurfaceFeature>();


            Parallel.ForEach(matchPolygons, options, (m) => {
                var origin = polygons.Single(e => e.name == m.Key);

                //if (!filterPolygons.Contains(origin.ObjectId)) return;

                FeatureRef exteriorId;

                if (m.Value.exterior.Count < 2) {
                    var tuple = hashing[IO.Hashing.XxHash3.HashToUInt64(origin.LineString.AsBinary())];
                    bagCurves.Add(tuple.curve);
                    exteriorId = tuple.fetureRef;
                }
                else {
                    var polygon = new List<LineString>(m.Value.exterior);

                    //if (origin.ObjectId == 154302) {
                    //    using (var target = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri($"file://{IO.Path.GetFullPath(@".\..\..\..\..\..\artifacts\s100ed6.gdb")}")))) {
                    //        ulong id = 0;
                    //        target.PersistTopology(polygon.Select(e => new CurveFeature(e) { Id = id++ }).ToArray());
                    //    }                        
                    //}
                    //return;

                    var startPoint = origin.ExteriorRing.StartPoint;
                    var endPoint = startPoint;

                    int countSegment = 1;
                    var c = polygon.Single(e => e.StartPoint.EqualsExact(startPoint));

                    var tuple = hashing[IO.Hashing.XxHash3.HashToUInt64(c.AsBinary())];
                    bagCurves.Add(tuple.curve);

                    var sorted = new FeatureRef[polygon.Count];
                    sorted[0] = tuple.fetureRef;

                    do {
                        var next = polygon.Single(e => e != c && e.StartPoint.EqualsExact(c.EndPoint));

                        tuple = hashing[IO.Hashing.XxHash3.HashToUInt64(next.AsBinary())];
                        bagCurves.Add(tuple.curve);

                        sorted[countSegment] = tuple.fetureRef;
                        c = next;

                        countSegment += 1;
                    } while (!c.EndPoint.EqualsExact(endPoint));

                    if (countSegment != polygon.Count)
                        System.Diagnostics.Debugger.Break();

                    var compositeExterior = new CompositeCurveFeature {
                        Curves = [.. sorted],
                    };

                    var key = string.Join(',', sorted.Select(e => e.Reverse ? $"RC{e.Id}" : $"{e.Id}"));

                    compositeExterior = bagCompositeCurves.GetOrAdd(key, (key) => {
                        return compositeExterior;
                    });

                    exteriorId = new FeatureRef {
                        Id = compositeExterior.Id,
                        Reverse = false,
                    };
                }

                if (!m.Value.interior.Any()) {
                    var surface = new SurfaceFeature() {
                        Ref = m.Key,
                        Exterior = exteriorId,
                    };
                    bagSurfaces.Add(surface);
                    mapping.GetOrAdd(m.Key, $"S{surface.Id}");
                }
                else {
                    FeatureRef[]? interiorRings = new FeatureRef[m.Value.interior.Length];
                    for (int i = 0; i < m.Value.interior.Length; i++) {
                        var interiorRing = m.Value.interior[i];

                        if (interiorRing.Count == 1) {
                            //Log.Verbose("interiorRing{i}: {linestring}", i, interiorRing[0].ToString());

                            var tuple = hashing[IO.Hashing.XxHash3.HashToUInt64(interiorRing[0].AsBinary())];
                            interiorRings[i] = tuple.fetureRef;
                            bagCurves.Add(tuple.curve);
                        }
                        else {
                            var polygon = new List<LineString>(interiorRing);

                            var startPoint = origin.InteriorRings[i].StartPoint;
                            var endPoint = startPoint;

                            int countSegment = 1;
                            var c = polygon.First(e => e.StartPoint.EqualsExact(startPoint));

                            var tuple = hashing[IO.Hashing.XxHash3.HashToUInt64(c.AsBinary())];
                            bagCurves.Add(tuple.curve);

                            var sorted = new FeatureRef[polygon.Count];
                            sorted[0] = tuple.fetureRef;

                            do {
                                var next = polygon.Single(e => e != c && e.StartPoint.EqualsExact(c.EndPoint));
                                tuple = hashing[IO.Hashing.XxHash3.HashToUInt64(next.AsBinary())];
                                bagCurves.Add(tuple.curve);

                                sorted[countSegment] = tuple.fetureRef;
                                c = next;

                                countSegment += 1;
                            } while (!c.EndPoint.EqualsExact(endPoint));

                            if (countSegment != polygon.Count)
                                System.Diagnostics.Debugger.Break();

                            var compositeExterior = new CompositeCurveFeature {
                                Curves = [.. sorted],
                            };

                            var key = string.Join(',', sorted.Select(e => e.Reverse ? $"RC{e.Id}" : $"{e.Id}"));

                            compositeExterior = bagCompositeCurves.GetOrAdd(key, (key) => {
                                return compositeExterior;
                            });

                            interiorRings[i] = new FeatureRef {
                                Id = compositeExterior.Id,
                                Reverse = false,
                            };
                        }
                    }

                    var surface = new SurfaceFeature() {
                        Ref = m.Key,
                        Exterior = exteriorId,
                        Interior = interiorRings,
                    };
                    bagSurfaces.Add(surface);

                    mapping.GetOrAdd(m.Key, $"S{surface.Id}");
                }
            });

            Parallel.ForEach(matchPolylines, options, (m) => {
                var origin = polylines.Single(e => e.name == m.Key);

                //if (origin.ObjectId != 169521) return;

                FeatureRef featureRef;

                if (m.Value.Count < 2) {
                    var tuple = hashing[IO.Hashing.XxHash3.HashToUInt64(origin.LineString.AsBinary())];
                    bagCurves.Add(tuple.curve);
                    featureRef = tuple.fetureRef;
                }
                else {
                    var polyline = new List<LineString>(m.Value);

                    var startPoint = origin.LineString.StartPoint;
                    var endPoint = origin.LineString.EndPoint;

                    int countSegment = 1;
                    var c = polyline.Single(e => e.StartPoint.EqualsExact(startPoint));

                    var tuple = hashing[IO.Hashing.XxHash3.HashToUInt64(c.AsBinary())];
                    bagCurves.Add(tuple.curve);

                    var sorted = new FeatureRef[polyline.Count];
                    sorted[0] = tuple.fetureRef;

                    do {
                        var next = polyline.Single(e => e != c && e.StartPoint.EqualsExact(c.EndPoint));

                        tuple = hashing[IO.Hashing.XxHash3.HashToUInt64(next.AsBinary())];
                        bagCurves.Add(tuple.curve);

                        sorted[countSegment] = tuple.fetureRef;
                        c = next;

                        countSegment += 1;
                    } while (!c.EndPoint.EqualsExact(endPoint));

                    if (countSegment != polyline.Count)
                        System.Diagnostics.Debugger.Break();

                    var compositeExterior = new CompositeCurveFeature {
                        Curves = [.. sorted],
                    };

                    var key = string.Join(',', sorted.Select(e => e.Reverse ? $"RC{e.Id}" : $"{e.Id}"));

                    compositeExterior = bagCompositeCurves.GetOrAdd(key, (key) => {
                        return compositeExterior;
                    });

                    featureRef = new FeatureRef {
                        Id = compositeExterior.Id,
                        Reverse = false,
                    };
                }

                mapping.GetOrAdd(m.Key, $"C{featureRef.Id}");
            });

            topology.Mapping = mapping;

            topology.CompositeCurves = [.. bagCompositeCurves.Values];
            topology.Surfaces = [.. bagSurfaces];

            var ids = new List<UInt64>();
            foreach (var e in bagCurves) {
                if (ids.Contains(e.Id))
                    continue;
                ids.Add(e.Id);
                topology.Curves.Add(e);
            }
        }

        private static void AddLineStringsFromGeometry(Geometry geometry, List<LineString> targetList) {
            if (geometry is LineString line) {
                if (!line.IsEmpty) {
                    if (!targetList.Any(e => e.EqualsTopologically(line)))
                        targetList.Add(line.RemoveRepeatedVertices());
                }
            }
            else if (geometry is MultiLineString multiLine) {
                foreach (var subLine in multiLine.Geometries.OfType<LineString>()) {
                    if (!subLine.IsEmpty) {
                        if (!targetList.Any(e => e.EqualsTopologically(subLine)))
                            targetList.Add(subLine.RemoveRepeatedVertices());
                    }
                }
            }
            else if (geometry is GeometryCollection collection) // Recursively handle collections if needed
            {
                foreach (var geom in collection.Geometries) {
                    AddLineStringsFromGeometry(geom, targetList);
                }
            }
            // We primarily care about LineString results for shared *edges*.
            // Point/MultiPoint intersections mean polygons touch only at vertices.
        }
    }
}

namespace GeoAPI.Geometries
{
    using NetTopologySuite.Geometries;

    public static class Extension
    {
        public static Geometry Combine(this Geometry geometry) {
            if (geometry is MultiLineString multiLineString) {
                var last = ((LineString)multiLineString[0]);

                var geometries = new List<LineString>();

                var coordinates = new Coordinate[0];
                coordinates = [.. last.Coordinates];

                for (int i = 1; i < multiLineString.Count; i++) {
                    var next = ((LineString)multiLineString[i]);

                    if (next.StartPoint.EqualsTopologically(last.EndPoint))
                        coordinates = [.. coordinates, .. next.Coordinates];
                    else {
                        var linestring = (LineString)geometry.Factory.CreateLineString(coordinates);
                        linestring = linestring.RemoveRepeatedVertices();
                        geometries.Add(linestring);
                        coordinates = next.Coordinates.ToArray();
                    }

                    last = next;
                }

                if (!geometries.Any()) {
                    geometry = geometry.Factory.CreateLineString(coordinates);
                }
                else {
                    geometries.Add((LineString)geometry.Factory.CreateLineString(coordinates));

                    //var finished = true;
                    //do {
                    //    finished = true;

                    //    for (int i = 0; i < geometries.Count - 1; i++) {
                    //        var l = geometries[i];

                    //        var lookup = geometries.SingleOrDefault(e => e.StartPoint.EqualsExact(l.EndPoint));
                    //        if (lookup != null) {
                    //            geometries.RemoveAll(e => e.EqualsTopologically(l) || e.EqualsTopologically(lookup));
                    //            geometries.Insert(0, (LineString)l.Factory.CreateLineString([.. l.Coordinates, .. lookup.Coordinates]));
                    //            finished = false;
                    //        }
                    //        else {
                    //            lookup = geometries.SingleOrDefault(e => e.EndPoint.EqualsExact(l.StartPoint));
                    //            if (lookup != null) {
                    //                geometries.RemoveAll(e => e.EqualsTopologically(l) || e.EqualsTopologically(lookup));
                    //                geometries.Insert(0, (LineString)l.Factory.CreateLineString([.. lookup.Coordinates, .. l.Coordinates]));
                    //                finished = false;
                    //            }
                    //        }
                    //    }

                    //} while (!finished);
                    geometry = geometry.Factory.CreateMultiLineString(geometries.ToArray());
                }
            }

            return geometry;
        }

        public static bool Contains(this Coordinate[] coordinates, Coordinate[] match) {
            for (int i = 0; i <= coordinates.Length - match.Length; i++) {
                var found = true;
                for (int j = 0; j < match.Length; j++) {
                    if (!coordinates[i + j].Equals(match[j])) {
                        found = false;
                        break;
                    }
                }
                if (found) return true;
            }
            return false;
        }

        public static bool ContainsReverse(this Coordinate[] coordinates, Coordinate[] match) {
            for (int i = coordinates.Length - 1; i >= match.Length; i--) {
                var found = true;
                for (int j = 0; j < match.Length; j++) {
                    if (!coordinates[i - j].Equals(match[j])) {
                        found = false;
                        break;
                    }
                }
                if (found) return true;
            }
            return false;
        }

        public static LineString RemoveRepeatedVertices(this LineString lineString) {
            var coordinates = lineString.Coordinates.RemoveRepeatedVertices();
            if (coordinates.Length != lineString.Count)
                return (LineString)lineString.Factory.CreateLineString(coordinates.ToArray());
            return lineString;
        }

        public static Coordinate[] RemoveRepeatedVertices(this Coordinate[] coordinates) {
            var _ = new List<Coordinate> { coordinates[0] };

            for (int i = 1; i < coordinates.Length; i++) {
                if (coordinates[i - 1].Equals(coordinates[i])) continue;
                _.Add(coordinates[i]);
            }
            return _.ToArray();
        }
    }
}

