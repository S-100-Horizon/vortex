using GeoAPI.Geometries;
using NetTopologySuite.Algorithm.Match;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using NetTopologySuite.Operation.Linemerge;
using NetTopologySuite.Operation.Union;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow;
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

        public FeatureRef[]? Interior { get; set; } = default;

        public string? Ref { get; init; } = default;

        public LineString? LineString { get; set; } = default;
    }

    public record Polyline(long ObjectId, string name, LineString LineString);

    public record Polygon(long ObjectId, string name, LineString ExteriorRing, LineString[] InteriorRings) : Polyline(ObjectId, name, ExteriorRing);

    public class Matrix
    {
        public static ParallelOptions ParallelOptions { get; set; } = new ParallelOptions { MaxDegreeOfParallelism = 8 };

        public GeometryFactory Factory { get; set; } = new GeometryFactory(new PrecisionModel(PrecisionModels.Floating));

        public List<CurveFeature> Curves { get; private set; } = new List<CurveFeature>();

        public List<CompositeCurveFeature> CompositeCurves { get; private set; } = new List<CompositeCurveFeature>();

        public List<SurfaceFeature> Surfaces { get; private set; } = new List<SurfaceFeature>();

        public IDictionary<string, string> Mapping => _mapping;

        private ConcurrentDictionary<string, string> _mapping = new ConcurrentDictionary<string, string>();
        private ConcurrentDictionary<ulong, (FeatureRef fetureRef, CurveFeature curve)> _hashing = new ConcurrentDictionary<ulong, (FeatureRef fetureRef, CurveFeature curve)>();

        public S100Framework.YAML.Matrix Build(S100Framework.YAML.Polyline[] polylines, S100Framework.YAML.Polygon[] polygons, Action<ICollection<LineString>>? interceptor = default) {
            int count = polygons.Count();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            (string Name, NetTopologySuite.Geometries.Geometry Curve, List<LineString> LineStrings)[] matrixCurves = polylines.Select(e => (e.name, (NetTopologySuite.Geometries.Geometry)e.LineString, new List<LineString>())).ToArray();

            (string Name, NetTopologySuite.Geometries.Geometry ExterioRing, NetTopologySuite.Geometries.Geometry[] InteriorRings, List<LineString> LineStringsExterior, List<LineString>[] LineStringInterior)[] matrixPolygons = polygons.Select(e => (e.name, (NetTopologySuite.Geometries.Geometry)e.ExteriorRing, e.InteriorRings.Select(r => (NetTopologySuite.Geometries.Geometry)r).ToArray(), new List<LineString>(), Array.Empty<List<LineString>>())).ToArray();

            IList<LineString> AddRange(List<LineString> lineStrings, List<LineString> append) {
                var inserts = new List<LineString>();

                for (int k = 0; k < append.Count; k++) {
                    var boundary1 = append[k];

                    var intersects = false;
                    for (int l = 0; l < lineStrings.Count; l++) {
                        Geometry boundary2 = lineStrings[l];
                        if (boundary1.EqualsExact(boundary2)) {
                            intersects = true;
                            break;
                        }
                        if (boundary1.Intersects(boundary2)) {
                            var sharedEdgesGeometry = boundary1.Intersection(boundary2);

                            if (sharedEdgesGeometry is not NetTopologySuite.Geometries.Point) {
                                intersects = true;

                                if (sharedEdgesGeometry is GeometryCollection collection) {
                                    sharedEdgesGeometry = sharedEdgesGeometry.Factory.CreateMultiLineString(collection.OfType<LineString>().ToArray());
                                }
                                if (sharedEdgesGeometry.IsEmpty)
                                    break;

                                var lineMerger = new LineMerger();
                                lineMerger.Add(sharedEdgesGeometry);

                                var sharedEdgesLineString = lineMerger.GetMergedLineStrings().Select(e => (LineString)e).ToList();
                                boundary2 = boundary1.SymmetricDifference(sharedEdgesGeometry);

                                if (boundary2.IsEmpty)
                                    break;

                                AddLineStringsFromGeometry(boundary2, inserts);
                            }
                        }
                        else if (boundary1.Contains(boundary2)) {
                            intersects = true;
                            System.Diagnostics.Debugger.Break();
                        }
                        else if (boundary2.Contains(boundary1)) {
                            intersects = true;
                            System.Diagnostics.Debugger.Break();
                        }
                    }
                    if (!intersects && !boundary1.IsEmpty)
                        inserts.Add(boundary1);
                }
                lineStrings.AddRange(inserts);
                return lineStrings;
            }


            for (int i = 0; i < polygons.Length; i++) {

                var boundary1Name = matrixPolygons[i].Name;

                if (!matrixPolygons[i].ExterioRing.IsEmpty) {
                    NetTopologySuite.Geometries.Geometry boundary1 = matrixPolygons[i].ExterioRing;

                    //for (var j = i + 1; j < polygons.Length; j++) {
                    for (var j = 0; j < this.Curves.Count; j++) {                        
                        //if (boundary1Name.Equals("S2557775") && j == 809) System.Diagnostics.Debugger.Break();

                        var boundary2 = this.Curves[j].LineString;

                        if (!boundary1.Disjoint(boundary2)) {
                            var contains = boundary1.Contains(boundary2);
                            var coveredby = boundary1.CoveredBy(boundary2);
                            var covers = boundary1.Covers(boundary2);
                            var crosses = boundary1.Crosses(boundary2);
                            var intersects = boundary1.Intersects(boundary2);
                            var overlaps = boundary1.Overlaps(boundary2);

                            if ((crosses && intersects) && !(contains | overlaps | coveredby))
                                continue;

                            var sharedEdgesGeometry = boundary1.Intersection(boundary2);

                            if (sharedEdgesGeometry is GeometryCollection collection) {
                                sharedEdgesGeometry = sharedEdgesGeometry.Factory.CreateMultiLineString(collection.OfType<LineString>().ToArray());
                            }

                            if (sharedEdgesGeometry == null || sharedEdgesGeometry.IsEmpty) continue;

                            var lineMerger = new LineMerger();
                            lineMerger.Add(sharedEdgesGeometry);

                            var sharedEdgesLineString = lineMerger.GetMergedLineStrings().Select(e => (LineString)e).ToList();

                            boundary1 = boundary1.SymmetricDifference(sharedEdgesGeometry);
                            
                            AddRange(matrixPolygons[i].LineStringsExterior, sharedEdgesLineString);                            
                        }

                        if (boundary1.IsEmpty)
                            break;
                    }

                    if (!boundary1.IsEmpty) {                        
                        //AddLineStringsFromGeometry(boundary1, matrixPolygons[i].LineStringsExterior);
                        var append = new List<LineString>();
                        AddLineStringsFromGeometry(boundary1, append);
                        AddRange(matrixPolygons[i].LineStringsExterior, append);
                    }
                }

                if (polygons[i].InteriorRings.Any()) {
                    if (matrixPolygons[i].LineStringInterior.Length == 0)
                        matrixPolygons[i].LineStringInterior = new List<LineString>[polygons[i].InteriorRings.Length];

                    for (int ring = 0; ring < polygons[i].InteriorRings.Length; ring++) {
                        if (matrixPolygons[i].LineStringInterior[ring] is null)
                            matrixPolygons[i].LineStringInterior[ring] = new List<LineString>();

                        NetTopologySuite.Geometries.Geometry interior1 = polygons[i].InteriorRings[ring];

                        //for (var j = i + 1; j < polygons.Length; j++) {
                        for (var j = 0; j < this.Curves.Count; j++) {
                            var boundary2 = this.Curves[j].LineString;

                            if (interior1.Disjoint(boundary2))
                                continue;

                            var contains = interior1.Contains(boundary2);
                            var coveredby = interior1.CoveredBy(boundary2);
                            var covers = interior1.Covers(boundary2);
                            var crosses = interior1.Crosses(boundary2);
                            var intersects = interior1.Intersects(boundary2);
                            var overlaps = interior1.Overlaps(boundary2);

                            if ((crosses && intersects) && !(contains | overlaps | coveredby))
                                continue;

                            var sharedEdgesGeometry = interior1.Intersection(boundary2);

                            if (sharedEdgesGeometry is GeometryCollection collection) {
                                sharedEdgesGeometry = sharedEdgesGeometry.Factory.CreateMultiLineString(collection.OfType<LineString>().ToArray());
                            }

                            if (sharedEdgesGeometry == null || sharedEdgesGeometry.IsEmpty) continue;

                            var lineMerger = new LineMerger();

                            lineMerger.Add(sharedEdgesGeometry);

                            var sharedEdgesLineString = lineMerger.GetMergedLineStrings().Select(e => (LineString)e).ToList();

                            interior1 = interior1.SymmetricDifference(sharedEdgesGeometry);

                            matrixPolygons[i].LineStringInterior[ring].AddRange(sharedEdgesLineString);

                            if (interior1.IsEmpty)
                                break;
                        }

                        if (!interior1.IsEmpty) {
                            AddLineStringsFromGeometry(interior1, matrixPolygons[i].LineStringInterior[ring]);
                        }
                    }
                }

            }

            foreach (var m in matrixPolygons) {
                foreach (var lineString in m.LineStringsExterior) {
                    var hash = System.IO.Hashing.XxHash3.HashToUInt64(lineString.AsBinary());

                    var f = new CurveFeature(lineString);

                    this._hashing.GetOrAdd(hash, (new FeatureRef {
                        Id = f.Id,
                        Reverse = false,
                    }, f));

                    hash = System.IO.Hashing.XxHash3.HashToUInt64(f.LineString.Reverse().AsBinary());

                    this._hashing.GetOrAdd(hash, (new FeatureRef {
                        Id = f.Id,
                        Reverse = true,
                    }, f));
                }
                if (m.LineStringInterior.Any()) {
                    foreach (var interior in m.LineStringInterior) {
                        foreach (var lineString in interior) {
                            var hash = System.IO.Hashing.XxHash3.HashToUInt64(lineString.AsBinary());

                            var f = new CurveFeature(lineString);

                            this._hashing.GetOrAdd(hash, (new FeatureRef {
                                Id = f.Id,
                                Reverse = false,
                            }, f));

                            hash = System.IO.Hashing.XxHash3.HashToUInt64(f.LineString.Reverse().AsBinary());
                            this._hashing.GetOrAdd(hash, (new FeatureRef {
                                Id = f.Id,
                                Reverse = true,
                            }, f));
                        }
                    }

                }
            }

            Parallel.For(0, polylines.Length, (i) => {
                NetTopologySuite.Geometries.Geometry boundary1 = matrixCurves[i].Curve;

                foreach (var c in this.Curves) {
                    if (boundary1.Disjoint(c.LineString))
                        continue;

                    var contains = boundary1.Contains(c.LineString);
                    var coveredby = boundary1.CoveredBy(c.LineString);
                    var covers = boundary1.Covers(c.LineString);
                    var crosses = boundary1.Crosses(c.LineString);
                    var intersects = boundary1.Intersects(c.LineString);
                    var overlaps = boundary1.Overlaps(c.LineString);

                    if ((crosses && intersects) && !(contains | overlaps | coveredby))
                        continue;

                    var lineMerger = new LineMerger();

                    var sharedEdgesGeometry = boundary1.Intersection(c.LineString);

                    if (sharedEdgesGeometry is GeometryCollection collection) {
                        sharedEdgesGeometry = sharedEdgesGeometry.Factory.CreateMultiLineString(collection.OfType<LineString>().ToArray());
                    }

                    if (sharedEdgesGeometry == null || sharedEdgesGeometry.IsEmpty) continue;

                    lineMerger.Add(sharedEdgesGeometry);

                    var sharedEdgesLineString = lineMerger.GetMergedLineStrings().Select(e => (LineString)e).ToList();

                    matrixCurves[i].Curve = boundary1.SymmetricDifference(sharedEdgesGeometry);
                    matrixCurves[i].LineStrings.AddRange(sharedEdgesLineString);

                    boundary1 = matrixCurves[i].Curve;

                    if (boundary1.IsEmpty)
                        break;
                }

                if (!matrixCurves[i].Curve.IsEmpty) {
                    AddLineStringsFromGeometry(matrixCurves[i].Curve, matrixCurves[i].LineStrings);
                }
            });

            foreach (var m in matrixCurves) {
                foreach (var lineString in m.LineStrings) {
                    var hash = System.IO.Hashing.XxHash3.HashToUInt64(lineString.AsBinary());

                    var f = new CurveFeature(lineString);

                    this._hashing.GetOrAdd(hash, (new FeatureRef {
                        Id = f.Id,
                        Reverse = false,
                    }, f));

                    hash = System.IO.Hashing.XxHash3.HashToUInt64(f.LineString.Reverse().AsBinary());
                    this._hashing.GetOrAdd(hash, (new FeatureRef {
                        Id = f.Id,
                        Reverse = true,
                    }, f));
                }
            }

            var bagCompositeCurves = new ConcurrentDictionary<string, CompositeCurveFeature>();
            var bagSurfaces = new ConcurrentBag<SurfaceFeature>();

            //options = new ParallelOptions { MaxDegreeOfParallelism = 1 };            

            Func<List<LineString>, LinearRingOrientation, FeatureRef> action = (lineStrings, orientation) => {
                FeatureRef featureRef;

                if (lineStrings.Count == 1) {
                    var l = lineStrings[0];

                    if (l.IsRing && orientation != LinearRingOrientation.DontCare) {
                        var ring = l.Factory.CreateLinearRing(l.Coordinates);

                        l = ring.IsCCW switch {
                            true => orientation == LinearRingOrientation.CCW ? l : (LineString)l.Reverse(),
                            false => orientation == LinearRingOrientation.CW ? l : (LineString)l.Reverse(),
                        };
                    }

                    var hash = this._hashing[IO.Hashing.XxHash3.HashToUInt64(l.AsBinary())];
                    featureRef = hash.fetureRef;
                }
                else {
                    var lineMerger = new LineMerger();
                    lineMerger.Add(lineStrings);

                    var merged = (LineString)lineMerger.GetMergedLineStrings()[0];

                    if (merged.IsRing && orientation != LinearRingOrientation.DontCare) {
                        var ring = merged.Factory.CreateLinearRing(merged.Coordinates);

                        merged = ring.IsCCW switch {
                            true => orientation == LinearRingOrientation.CCW ? merged : (LineString)merged.Reverse(),
                            false => orientation == LinearRingOrientation.CW ? merged : (LineString)merged.Reverse(),
                        };
                    }

                    interceptor?.Invoke([.. lineStrings]);

                    var lineStringText = merged.ToText();

                    //var ring = origin.ExteriorRing.Factory.CreateLinearRing(((LineString)lineMerger.GetMergedLineStrings()[0]).Coordinates).ToString();

                    //var sorted = new FeatureRef[lineStrings.Count];

                    var sortedList = new SortedList<int, FeatureRef>();

                    for (int i = 0; i < lineStrings.Count; i++) {

                        var text = lineStrings[i].ToText().Substring("LINESTRING (".Length).TrimEnd(')');
                        if (lineStringText.Contains(text)) {
                            var hash = this._hashing[IO.Hashing.XxHash3.HashToUInt64(lineStrings[i].AsBinary())];

                            sortedList.Add(lineStringText.IndexOf(text), hash.fetureRef);
                        }
                        else {
                            var reverse = lineStrings[i].Reverse();

                            var hash = this._hashing[IO.Hashing.XxHash3.HashToUInt64(reverse.AsBinary())];

                            text = reverse.ToText().Substring("LINESTRING (".Length).TrimEnd(')');

                            sortedList.Add(lineStringText.IndexOf(text), hash.fetureRef);
                        }
                    }

                    var compositeExterior = new CompositeCurveFeature {
                        Curves = [.. sortedList.Values],
                    };

                    var key = string.Join(',', sortedList.Select(e => e.Value.Reverse ? $"RC{e.Value.Id}" : $"C{e.Value.Id}"));

                    compositeExterior = bagCompositeCurves.GetOrAdd(key, (key) => {
                        return compositeExterior;
                    });

                    featureRef = new FeatureRef {
                        Id = compositeExterior.Id,
                        Reverse = false,
                    };
                }

                return featureRef;
            };

            Parallel.ForEach(matrixPolygons, ParallelOptions, (m) => {
                if (m.LineStringsExterior.Count == 0)
                    return;

                var origin = polygons.Single(e => e.name == m.Name);

                if (origin.name.Equals("S2533324")) System.Diagnostics.Debugger.Break();
                FeatureRef exteriorId = action(m.LineStringsExterior, LinearRingOrientation.Clockwise);

                var surface = new SurfaceFeature() {
                    Ref = m.Name,
                    Exterior = exteriorId,
                };

                if (m.LineStringInterior.Any()) {
                    var interiorRefs = new List<FeatureRef>();

                    foreach (var interior in m.LineStringInterior) {
                        var interiorRef = action(interior, LinearRingOrientation.CounterClockwise);
                        interiorRefs.Add(interiorRef);
                    }

                    surface.Interior = [.. interiorRefs];
                }

                bagSurfaces.Add(surface);
                this._mapping.GetOrAdd(m.Name, $"S{surface.Id}");

            });

            Parallel.ForEach(matrixCurves, ParallelOptions, (m) => {
                if (m.LineStrings.Count == 0)
                    return;

                var origin = polylines.Single(e => e.name == m.Name);

                FeatureRef curveId = action(m.LineStrings, LinearRingOrientation.DontCare);

                this._mapping.GetOrAdd(m.Name, $"C{curveId.Id}");
            });

            this.CompositeCurves = [.. this.CompositeCurves, .. bagCompositeCurves.Values];
            this.Surfaces = [.. this.Surfaces, .. bagSurfaces];

            this.Curves = [.. this._hashing.Select(e => e.Value).DistinctBy(e => e.fetureRef.Id).Select(e => e.curve)];

            return this;
        }

        public S100Framework.YAML.Matrix BuildTopology(S100Framework.YAML.Polyline[] polylines, S100Framework.YAML.Polygon[] polygons) {
            int count = polygons.Count();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            (string Name, NetTopologySuite.Geometries.Geometry Curve, List<LineString> LineStrings)[] matrixCurves = polylines.Select(e => (e.name, (NetTopologySuite.Geometries.Geometry)e.LineString, new List<LineString>())).ToArray();

            (string Name, NetTopologySuite.Geometries.Geometry ExterioRing, NetTopologySuite.Geometries.Geometry[] InteriorRings, List<LineString> LineStringsExterior, List<LineString>[] LineStringInterior)[] matrixPolygons = polygons.Select(e => (e.name, (NetTopologySuite.Geometries.Geometry)e.ExteriorRing, e.InteriorRings.Select(r => (NetTopologySuite.Geometries.Geometry)r).ToArray(), new List<LineString>(), Array.Empty<List<LineString>>())).ToArray();


            for (int i = 0; i < polygons.Length; i++) {
                //if (matrixPolygons[i].Name.Equals("S2557165")) System.Diagnostics.Debugger.Break();

                //20250702, if (matrixPolygons[i].ExterioRing.IsEmpty) continue;                

                if (!matrixPolygons[i].ExterioRing.IsEmpty) {
                    NetTopologySuite.Geometries.Geometry boundary1 = matrixPolygons[i].ExterioRing;

                    for (var j = i + 1; j < polygons.Length; j++) {
                        var boundary2 = matrixPolygons[j].ExterioRing;

                        if (!boundary1.Disjoint(boundary2)) {
                            var contains = boundary1.Contains(boundary2);
                            var coveredby = boundary1.CoveredBy(boundary2);
                            var covers = boundary1.Covers(boundary2);
                            var crosses = boundary1.Crosses(boundary2);
                            var intersects = boundary1.Intersects(boundary2);
                            var overlaps = boundary1.Overlaps(boundary2);

                            if ((crosses && intersects) && !(contains | overlaps | coveredby))
                                continue;

                            var sharedEdgesGeometry = boundary1.Intersection(boundary2);
                            if (sharedEdgesGeometry is GeometryCollection geometryCollection) {
                                var lineStrings = geometryCollection.OfType<LineString>();
                                sharedEdgesGeometry = geometryCollection.Factory.CreateMultiLineString(lineStrings.ToArray());
                            }

                            if (sharedEdgesGeometry == null || sharedEdgesGeometry.IsEmpty) continue;

                            var lineMerger = new LineMerger();

                            lineMerger.Add(sharedEdgesGeometry);

                            var sharedEdgesLineString = lineMerger.GetMergedLineStrings().Select(e => (LineString)e).ToList();

                            boundary1 = boundary1.SymmetricDifference(sharedEdgesGeometry);
                            matrixPolygons[i].LineStringsExterior.AddRange(sharedEdgesLineString);

                            matrixPolygons[j].ExterioRing = boundary2.SymmetricDifference(sharedEdgesGeometry);
                            matrixPolygons[j].LineStringsExterior.AddRange(sharedEdgesLineString);

                            //boundary1 = matrixPolygons[i].ExterioRing;
                        }
                        if (matrixPolygons[j].InteriorRings.Any()) {
                            for (int ring = 0; ring < matrixPolygons[j].InteriorRings.Length; ring++) {
                                boundary2 = matrixPolygons[j].InteriorRings[ring];

                                if (boundary1.Disjoint(boundary2))
                                    continue;

                                var contains = boundary1.Contains(boundary2);
                                var coveredby = boundary1.CoveredBy(boundary2);
                                var covers = boundary1.Covers(boundary2);
                                var crosses = boundary1.Crosses(boundary2);
                                var intersects = boundary1.Intersects(boundary2);
                                var overlaps = boundary1.Overlaps(boundary2);

                                if ((crosses && intersects) && !(contains | overlaps | coveredby))
                                    continue;

                                var sharedEdgesGeometry = boundary1.Intersection(boundary2);
                                if (sharedEdgesGeometry is GeometryCollection geometryCollection) {
                                    var lineStrings = geometryCollection.OfType<LineString>();
                                    sharedEdgesGeometry = geometryCollection.Factory.CreateMultiLineString(lineStrings.ToArray());
                                }

                                if (sharedEdgesGeometry == null || sharedEdgesGeometry.IsEmpty) continue;

                                var lineMerger = new LineMerger();

                                lineMerger.Add(sharedEdgesGeometry);

                                var sharedEdgesLineString = lineMerger.GetMergedLineStrings().Select(e => (LineString)e).ToList();

                                boundary1 = boundary1.SymmetricDifference(sharedEdgesGeometry);
                                matrixPolygons[i].LineStringsExterior.AddRange(sharedEdgesLineString);

                                if (matrixPolygons[j].LineStringInterior.Length == 0)
                                    matrixPolygons[j].LineStringInterior = new List<LineString>[polygons[j].InteriorRings.Length];
                                if (matrixPolygons[j].LineStringInterior[ring] is null)
                                    matrixPolygons[j].LineStringInterior[ring] = new List<LineString>();

                                matrixPolygons[j].InteriorRings[ring] = boundary2.SymmetricDifference(sharedEdgesGeometry);
                                matrixPolygons[j].LineStringInterior[ring].AddRange(sharedEdgesLineString);
                            }
                        }
                        if (boundary1.IsEmpty)
                            break;
                    }

                    if (!boundary1.IsEmpty) {
                        AddLineStringsFromGeometry(boundary1, matrixPolygons[i].LineStringsExterior);
                    }
                }
                if (polygons[i].InteriorRings.Any()) {
                    if (matrixPolygons[i].LineStringInterior.Length == 0)
                        matrixPolygons[i].LineStringInterior = new List<LineString>[polygons[i].InteriorRings.Length];

                    for (int ring = 0; ring < polygons[i].InteriorRings.Length; ring++) {
                        if (matrixPolygons[i].LineStringInterior[ring] is null)
                            matrixPolygons[i].LineStringInterior[ring] = new List<LineString>();

                        NetTopologySuite.Geometries.Geometry interior1 = polygons[i].InteriorRings[ring];

                        for (var j = i + 1; j < polygons.Length; j++) {
                            var boundary2 = matrixPolygons[j].ExterioRing;

                            if (interior1.Disjoint(boundary2))
                                continue;

                            var contains = interior1.Contains(boundary2);
                            var coveredby = interior1.CoveredBy(boundary2);
                            var covers = interior1.Covers(boundary2);
                            var crosses = interior1.Crosses(boundary2);
                            var intersects = interior1.Intersects(boundary2);
                            var overlaps = interior1.Overlaps(boundary2);

                            if ((crosses && intersects) && !(contains | overlaps | coveredby))
                                continue;

                            var sharedEdgesGeometry = interior1.Intersection(boundary2);

                            if (sharedEdgesGeometry == null || sharedEdgesGeometry.IsEmpty) continue;

                            var lineMerger = new LineMerger();

                            lineMerger.Add(sharedEdgesGeometry);

                            var sharedEdgesLineString = lineMerger.GetMergedLineStrings().Select(e => (LineString)e).ToList();

                            interior1 = interior1.SymmetricDifference(sharedEdgesGeometry);

                            matrixPolygons[i].LineStringInterior[ring].AddRange(sharedEdgesLineString);

                            matrixPolygons[j].ExterioRing = boundary2.SymmetricDifference(sharedEdgesGeometry);
                            matrixPolygons[j].LineStringsExterior.AddRange(sharedEdgesLineString);

                            if (interior1.IsEmpty)
                                break;
                        }

                        if (!interior1.IsEmpty) {
                            AddLineStringsFromGeometry(interior1, matrixPolygons[i].LineStringInterior[ring]);
                        }
                    }
                }
            }

            foreach (var m in matrixPolygons) {
                foreach (var lineString in m.LineStringsExterior) {
                    var hash = System.IO.Hashing.XxHash3.HashToUInt64(lineString.AsBinary());

                    var f = new CurveFeature(lineString);

                    this._hashing.GetOrAdd(hash, (new FeatureRef {
                        Id = f.Id,
                        Reverse = false,
                    }, f));
                    hash = System.IO.Hashing.XxHash3.HashToUInt64(f.LineString.Reverse().AsBinary());
                    this._hashing.GetOrAdd(hash, (new FeatureRef {
                        Id = f.Id,
                        Reverse = true,
                    }, f));
                }
                if (m.LineStringInterior.Any()) {
                    foreach (var interior in m.LineStringInterior) {
                        foreach (var lineString in interior) {
                            var hash = System.IO.Hashing.XxHash3.HashToUInt64(lineString.AsBinary());

                            var f = new CurveFeature(lineString);

                            this._hashing.GetOrAdd(hash, (new FeatureRef {
                                Id = f.Id,
                                Reverse = false,
                            }, f));
                            hash = System.IO.Hashing.XxHash3.HashToUInt64(f.LineString.Reverse().AsBinary());
                            this._hashing.GetOrAdd(hash, (new FeatureRef {
                                Id = f.Id,
                                Reverse = true,
                            }, f));
                        }

                    }
                }
            }

            Parallel.For(0, polylines.Length, (i) => {
                NetTopologySuite.Geometries.Geometry boundary1 = matrixCurves[i].Curve;

                CurveFeature[] curves = [.. this._hashing.Select(e => e.Value).DistinctBy(e => e.fetureRef.Id).Select(e => e.curve)];

                foreach (var c in curves) {
                    if (boundary1.Disjoint(c.LineString))
                        continue;

                    var contains = boundary1.Contains(c.LineString);
                    var coveredby = boundary1.CoveredBy(c.LineString);
                    var covers = boundary1.Covers(c.LineString);
                    var crosses = boundary1.Crosses(c.LineString);
                    var intersects = boundary1.Intersects(c.LineString);
                    var overlaps = boundary1.Overlaps(c.LineString);

                    if ((crosses && intersects) && !(contains | overlaps | coveredby))
                        continue;

                    var lineMerger = new LineMerger();

                    var sharedEdgesGeometry = boundary1.Intersection(c.LineString);

                    if (sharedEdgesGeometry is GeometryCollection collection) {
                        sharedEdgesGeometry = sharedEdgesGeometry.Factory.CreateMultiLineString(collection.OfType<LineString>().ToArray());
                    }

                    if (sharedEdgesGeometry == null || sharedEdgesGeometry.IsEmpty) continue;

                    lineMerger.Add(sharedEdgesGeometry);

                    var sharedEdgesLineString = lineMerger.GetMergedLineStrings().Select(e => (LineString)e).ToList();

                    matrixCurves[i].Curve = boundary1.SymmetricDifference(sharedEdgesGeometry);
                    matrixCurves[i].LineStrings.AddRange(sharedEdgesLineString);

                    boundary1 = matrixCurves[i].Curve;

                    if (boundary1.IsEmpty)
                        break;
                }

                if (!matrixCurves[i].Curve.IsEmpty) {
                    AddLineStringsFromGeometry(matrixCurves[i].Curve, matrixCurves[i].LineStrings);
                }
            });

            foreach (var m in matrixCurves) {
                foreach (var lineString in m.LineStrings) {
                    var hash = System.IO.Hashing.XxHash3.HashToUInt64(lineString.AsBinary());

                    var f = new CurveFeature(lineString);

                    this._hashing.GetOrAdd(hash, (new FeatureRef {
                        Id = f.Id,
                        Reverse = false,
                    }, f));
                    hash = System.IO.Hashing.XxHash3.HashToUInt64(f.LineString.Reverse().AsBinary());
                    this._hashing.GetOrAdd(hash, (new FeatureRef {
                        Id = f.Id,
                        Reverse = true,
                    }, f));
                }
            }

            var bagCompositeCurves = new ConcurrentDictionary<string, CompositeCurveFeature>();
            var bagSurfaces = new ConcurrentBag<SurfaceFeature>();

            //options = new ParallelOptions { MaxDegreeOfParallelism = 1 };

            Func<List<LineString>, LinearRingOrientation, FeatureRef> action = (lineStrings, orientation) => {
                FeatureRef featureRef;

                if (lineStrings.Count == 1) {
                    var l = lineStrings[0];

                    if (l.IsRing && orientation != LinearRingOrientation.DontCare) {
                        var ring = l.Factory.CreateLinearRing(l.Coordinates);

                        l = ring.IsCCW switch {
                            true => orientation == LinearRingOrientation.CCW ? l : (LineString)l.Reverse(),
                            false => orientation == LinearRingOrientation.CW ? l : (LineString)l.Reverse(),
                        };
                    }

                    var hash = this._hashing[IO.Hashing.XxHash3.HashToUInt64(l.AsBinary())];
                    featureRef = hash.fetureRef;
                }
                else {
                    var lineMerger = new LineMerger();
                    lineMerger.Add(lineStrings);

                    var merged = (LineString)lineMerger.GetMergedLineStrings()[0];

                    if (merged.IsRing && orientation != LinearRingOrientation.DontCare) {
                        var ring = merged.Factory.CreateLinearRing(merged.Coordinates);

                        merged = ring.IsCCW switch {
                            true => orientation == LinearRingOrientation.CCW ? merged : (LineString)merged.Reverse(),
                            false => orientation == LinearRingOrientation.CW ? merged : (LineString)merged.Reverse(),
                        };
                    }

                    var lineStringText = merged.ToText();

                    //var ring = origin.ExteriorRing.Factory.CreateLinearRing(((LineString)lineMerger.GetMergedLineStrings()[0]).Coordinates).ToString();

                    //var sorted = new FeatureRef[lineStrings.Count];

                    var sortedList = new SortedList<int, FeatureRef>();

                    for (int i = 0; i < lineStrings.Count; i++) {

                        var text = lineStrings[i].ToText().Substring("LINESTRING (".Length).TrimEnd(')');
                        if (lineStringText.Contains(text)) {
                            var hash = this._hashing[IO.Hashing.XxHash3.HashToUInt64(lineStrings[i].AsBinary())];

                            sortedList.Add(lineStringText.IndexOf(text), hash.fetureRef);
                        }
                        else {
                            var reverse = lineStrings[i].Reverse();

                            var hash = this._hashing[IO.Hashing.XxHash3.HashToUInt64(reverse.AsBinary())];

                            text = reverse.ToText().Substring("LINESTRING (".Length).TrimEnd(')');

                            var index = lineStringText.IndexOf(text);
                            if (index < 0) System.Diagnostics.Debugger.Break();
                            sortedList.Add(lineStringText.IndexOf(text), hash.fetureRef);
                        }
                    }

                    var compositeExterior = new CompositeCurveFeature {
                        Curves = [.. sortedList.Values],
                    };

                    var key = string.Join(',', sortedList.Select(e => e.Value.Reverse ? $"RC{e.Value.Id}" : $"C{e.Value.Id}"));

                    compositeExterior = bagCompositeCurves.GetOrAdd(key, (key) => {
                        return compositeExterior;
                    });

                    featureRef = new FeatureRef {
                        Id = compositeExterior.Id,
                        Reverse = false,
                    };
                }

                return featureRef;
            };

            //options = new ParallelOptions { MaxDegreeOfParallelism = 1 };

            Parallel.ForEach(matrixPolygons, ParallelOptions, (m) => {
                if (m.LineStringsExterior.Count == 0)
                    return;

                var origin = polygons.Single(e => e.name == m.Name);

                //if (origin.name.Equals("S1287791")) System.Diagnostics.Debugger.Break();

                FeatureRef exteriorId = action(m.LineStringsExterior, LinearRingOrientation.Clockwise);

                var surface = new SurfaceFeature() {
                    Ref = m.Name,
                    Exterior = exteriorId,
                };

                if (m.LineStringInterior.Any()) {
                    var interiorRefs = new List<FeatureRef>();

                    foreach (var interior in m.LineStringInterior) {
                        var interiorRef = action(interior, LinearRingOrientation.CounterClockwise);
                        interiorRefs.Add(interiorRef);
                    }

                    surface.Interior = [.. interiorRefs];
                }

                bagSurfaces.Add(surface);
                this._mapping.GetOrAdd(m.Name, $"S{surface.Id}");

            });

            Parallel.ForEach(matrixCurves, ParallelOptions, (m) => {
                if (m.LineStrings.Count == 0)
                    return;

                var origin = polylines.Single(e => e.name == m.Name);

                FeatureRef curveId = action(m.LineStrings, LinearRingOrientation.DontCare);

                this._mapping.GetOrAdd(m.Name, $"C{curveId.Id}");
            });



            this.CompositeCurves = [.. this.CompositeCurves, .. bagCompositeCurves.Values];
            this.Surfaces = [.. this.Surfaces, .. bagSurfaces];

            this.Curves = [.. this._hashing.Select(e => e.Value).DistinctBy(e => e.fetureRef.Id).Select(e => e.curve)];
            return this;
        }



        public static void AddLineStringsFromGeometry(Geometry geometry, List<LineString> targetList) {
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

