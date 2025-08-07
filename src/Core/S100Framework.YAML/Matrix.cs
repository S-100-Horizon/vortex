using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using NetTopologySuite.Operation.Linemerge;
using System.Collections.Concurrent;
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

        public ICollection<UInt64>? Masks1 { get; set; } = default;
        public ICollection<UInt64>? Masks2 { get; set; } = default;
    }

    public record Polyline(long ObjectId, string Name, string Code, LineString LineString);

    public record Polygon(long ObjectId, string Name, string Code, LineString ExteriorRing, LineString[] InteriorRings) : Polyline(ObjectId, Name, Code, ExteriorRing);


    public class CurveContainer
    {
        private Dictionary<UInt64, CurveFeature> _feature = new Dictionary<UInt64, CurveFeature>();
        private Dictionary<ulong, (UInt64 Id, bool Reverse)> _keys = new Dictionary<ulong, (UInt64, bool)>();

        public ICollection<CurveFeature> CurveFeatures => _feature.Values;

        public (UInt64 Id, bool Reverse) AddOrGet(LineString lineString) {
            var keyStraight = System.IO.Hashing.XxHash3.HashToUInt64(lineString.AsBinary());
            var keyReverse = System.IO.Hashing.XxHash3.HashToUInt64(lineString.Reverse().AsBinary());

            var curve = new CurveFeature(lineString);

            lock (this) {
                if (_keys.ContainsKey(keyStraight)) {
                    var value = _keys[keyStraight];
                    return (value.Id, value.Reverse);
                }
                _feature.Add(curve.Id, curve);
                _keys.Add(keyStraight, (curve.Id, false));
                _keys.Add(keyReverse, (curve.Id, true));

                return (curve.Id, false);
            }
        }
    }

    public class CompositeCurveContainer
    {
        private Dictionary<UInt64, CompositeCurveFeature> _feature = new Dictionary<ulong, CompositeCurveFeature>();
        private Dictionary<string, (UInt64 Id, bool Reverse)> _keys = new Dictionary<string, (ulong, bool)>();

        public ICollection<CompositeCurveFeature> CompositeCurveFeatures => _feature.Values;

        public (UInt64 Id, bool Reverse) AddOrGet(IList<FeatureRef> sortedList) {
            var keyStraight = string.Join(',', sortedList.Select(e => e.Reverse ? $"RC{e.Id}" : $"C{e.Id}"));
            var keyReverse = string.Join(',', sortedList.Reverse().Select(e => !e.Reverse ? $"RC{e.Id}" : $"C{e.Id}"));

            var compositeCurve = new CompositeCurveFeature {
                Curves = [.. sortedList],
            };

            lock (this) {
                if (_keys.ContainsKey(keyStraight)) {
                    var value = _keys[keyStraight];
                    return (value.Id, value.Reverse);
                }
                _feature.Add(compositeCurve.Id, compositeCurve);
                _keys.Add(keyStraight, (compositeCurve.Id, false));
                _keys.Add(keyReverse, (compositeCurve.Id, true));

                return (compositeCurve.Id, false);
            }
        }
    }

    public interface iTopologyBuilder
    {
        iTopologyBuilder AddTopologyFeatures(ICollection<S100Framework.YAML.Polygon> surfaces, ICollection<S100Framework.YAML.Polyline> curves);
        iTopologyBuilder AddNavigationalFeatures(ICollection<S100Framework.YAML.Polygon> surfaces, ICollection<S100Framework.YAML.Polyline> curves);

        iTopologyBuilder AddSingletonFeatures(ICollection<S100Framework.YAML.Polyline> curves);

        iMatrix BuildTopology();
    }

    public interface iMatrix
    {
        IEnumerable<CurveFeature> Curves { get; }

        IEnumerable<CompositeCurveFeature> CompositeCurves { get; }

        IEnumerable<SurfaceFeature> Surfaces { get; }

        IDictionary<string, string> Mapping { get; }
    }

    public class Matrix : iTopologyBuilder, iMatrix
    {
        public static ParallelOptions ParallelOptions { get; set; } = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount > 8 ? 8 : Environment.ProcessorCount };

        public static GeometryFactory Factory { get; set; } = new GeometryFactory(new PrecisionModel(100000000), srid: 4326);

        public static string[] Mask1FeatureTypes { get; set; } = ["DataCoverage"];

        protected Matrix() {
            //  Default protected constructor
        }

        private Action<ICollection<LineString>>? _interceptor = default;

        private ConcurrentBag<(string Name, IEnumerable<LineString> ExteriorRing, List<IEnumerable<LineString>> InteriorRings)> _bagPolygons = new ConcurrentBag<(string Name, IEnumerable<LineString> ExteriorRing, List<IEnumerable<LineString>> InteriorRings)>();

        private ConcurrentBag<(string Name, IEnumerable<LineString> LineStrings)> _bagPolylines = new ConcurrentBag<(string Name, IEnumerable<LineString> LineStrings)>();

        private ConcurrentDictionary<string, string> _mapping = new ConcurrentDictionary<string, string>();

        private ConcurrentBag<SurfaceFeature> _bagSurfaces = new ConcurrentBag<SurfaceFeature>();

        private IDictionary<string, List<LineString>> _featureToEdges;

        private ICollection<S100Framework.YAML.Polygon> _surfacesTopology;
        private ICollection<S100Framework.YAML.Polyline> _curvesTopology;

        private ICollection<S100Framework.YAML.Polygon> _surfacesNavigational;
        private ICollection<S100Framework.YAML.Polyline> _curvesNavigational;

        private ICollection<S100Framework.YAML.Polyline> _curvesSingleton;

        private ConcurrentDictionary<ulong, (FeatureRef fetureRef, CurveFeature curve)> _hashing = new ConcurrentDictionary<ulong, (FeatureRef fetureRef, CurveFeature curve)>();

        //private CurveContainer _curveContainer = new CurveContainer();
        private CompositeCurveContainer _compositeCurveContainer = new CompositeCurveContainer();

        public static iTopologyBuilder CreateMatrix(Action<ICollection<LineString>>? interceptor = default) {
            return new Matrix() {
                _interceptor = interceptor,
            };
        }

        private static LineString MakePrecise(LineString lineString) {
            for (int i = 0; i < lineString.NumPoints; i++) {
                Matrix.Factory.PrecisionModel.MakePrecise(lineString[i]);
            }
            return lineString;
        }

        private static ICollection<S100Framework.YAML.Polygon> MakePrecise(ICollection<S100Framework.YAML.Polygon> surfaces) {
            foreach (var p in surfaces) {
                MakePrecise(p.ExteriorRing);

                foreach (var interior in p.InteriorRings)
                    MakePrecise(interior);
            }
            return surfaces;
        }

        private static ICollection<S100Framework.YAML.Polyline> MakePrecise(ICollection<S100Framework.YAML.Polyline> curves) {
            foreach (var c in curves) {
                MakePrecise(c.LineString);
            }
            return curves;
        }

        iTopologyBuilder iTopologyBuilder.AddTopologyFeatures(ICollection<S100Framework.YAML.Polygon> surfaces, ICollection<S100Framework.YAML.Polyline> curves) {
            this._surfacesTopology = MakePrecise(surfaces);
            this._curvesTopology = MakePrecise(curves);

            return (iTopologyBuilder)this;
        }

        iTopologyBuilder iTopologyBuilder.AddNavigationalFeatures(ICollection<Polygon> surfaces, ICollection<S100Framework.YAML.Polyline> curves) {
            this._surfacesNavigational = MakePrecise(surfaces);
            this._curvesNavigational = MakePrecise(curves);

            return (iTopologyBuilder)this;
        }

        iTopologyBuilder iTopologyBuilder.AddSingletonFeatures(ICollection<Polyline> curves) {
            this._curvesSingleton = MakePrecise(curves);

            return (iTopologyBuilder)this;
        }

        iMatrix iTopologyBuilder.BuildTopology() {
            IEnumerable<S100Framework.YAML.Polygon> surfaces = Enumerable.Empty<S100Framework.YAML.Polygon>();
            IEnumerable<S100Framework.YAML.Polyline> curves = Enumerable.Empty<S100Framework.YAML.Polyline>();

            if (this._surfacesTopology.Any() || this._curvesTopology.Any()) {
                surfaces = surfaces.UnionBy(this._surfacesTopology, e => e.Name);
                curves = curves.UnionBy(this._curvesTopology, e => e.Name);
            }

            if (this._surfacesNavigational.Any() || this._curvesNavigational.Any()) {
                surfaces = surfaces.UnionBy(this._surfacesNavigational, e => e.Name);
                curves = curves.UnionBy(this._curvesNavigational, e => e.Name);
            }

            var mask1Objects = surfaces.Where(e => Matrix.Mask1FeatureTypes.Contains(e.Code)).Select(e => e.Name).Distinct();

            this.BuildSharedEdges([.. surfaces], [.. curves]);

            if (null != this._curvesSingleton) {
                foreach (var curve in this._curvesSingleton) {
                    var hash = System.IO.Hashing.XxHash3.HashToUInt64(curve.LineString.AsBinary());

                    var f = new CurveFeature(curve.LineString);
                    this._hashing.GetOrAdd(hash, (new FeatureRef {
                        Id = f.Id,
                        Reverse = false,
                    }, f));
                    hash = System.IO.Hashing.XxHash3.HashToUInt64(f.LineString.Reverse().AsBinary());
                    this._hashing.GetOrAdd(hash, (new FeatureRef {
                        Id = f.Id,
                        Reverse = true,
                    }, f));

                    var featureRef = this._hashing[hash];

                    this._mapping.GetOrAdd(curve.Name, $"C{featureRef.fetureRef.Id}");
                }
            }

            var mask1Hashes = new List<UInt64>();

            foreach (var polygon in this._bagPolygons.Where(e => mask1Objects.Contains(e.Name))) {
                foreach (var lineString in polygon.ExteriorRing) {
                    var hash = System.IO.Hashing.XxHash3.HashToUInt64(lineString.AsBinary());

                    var f = new CurveFeature(lineString);
                    var r = this._hashing.GetOrAdd(hash, (new FeatureRef {
                        Id = f.Id,
                        Reverse = false,
                    }, f));
                    mask1Hashes.Add(r.curve.Id);
                    hash = System.IO.Hashing.XxHash3.HashToUInt64(f.LineString.Reverse().AsBinary());
                    r = this._hashing.GetOrAdd(hash, (new FeatureRef {
                        Id = f.Id,
                        Reverse = true,
                    }, f));
                    mask1Hashes.Add(r.curve.Id);
                }
                if (polygon.InteriorRings.Any()) {
                    foreach (var interior in polygon.InteriorRings) {
                        foreach (var lineString in interior) {
                            var hash = System.IO.Hashing.XxHash3.HashToUInt64(lineString.AsBinary());
                            var f = new CurveFeature(lineString);
                            var r = this._hashing.GetOrAdd(hash, (new FeatureRef {
                                Id = f.Id,
                                Reverse = false,
                            }, f));
                            mask1Hashes.Add(r.curve.Id);
                            hash = System.IO.Hashing.XxHash3.HashToUInt64(f.LineString.Reverse().AsBinary());
                            r = this._hashing.GetOrAdd(hash, (new FeatureRef {
                                Id = f.Id,
                                Reverse = true,
                            }, f));
                            mask1Hashes.Add(r.curve.Id);
                        }
                    }
                }
            }

            mask1Hashes = mask1Hashes.DistinctBy(e => e).ToList();

            Parallel.ForEach(this._bagPolygons, ParallelOptions, (polygon) => {
                foreach (var lineString in polygon.ExteriorRing) {
                    var hash = System.IO.Hashing.XxHash3.HashToUInt64(lineString.AsBinary());

                    var f = new CurveFeature(lineString);
                    var r = this._hashing.GetOrAdd(hash, (new FeatureRef {
                        Id = f.Id,
                        Reverse = false,
                    }, f));
                    hash = System.IO.Hashing.XxHash3.HashToUInt64(f.LineString.Reverse().AsBinary());
                    r = this._hashing.GetOrAdd(hash, (new FeatureRef {
                        Id = f.Id,
                        Reverse = true,
                    }, f));
                }
                if (polygon.InteriorRings.Any()) {
                    foreach (var interior in polygon.InteriorRings) {
                        foreach (var lineString in interior) {
                            var hash = System.IO.Hashing.XxHash3.HashToUInt64(lineString.AsBinary());
                            var f = new CurveFeature(lineString);
                            var r = this._hashing.GetOrAdd(hash, (new FeatureRef {
                                Id = f.Id,
                                Reverse = false,
                            }, f));
                            hash = System.IO.Hashing.XxHash3.HashToUInt64(f.LineString.Reverse().AsBinary());
                            r = this._hashing.GetOrAdd(hash, (new FeatureRef {
                                Id = f.Id,
                                Reverse = true,
                            }, f));
                        }
                    }
                }
            });

            Parallel.ForEach(this._bagPolylines, ParallelOptions, (Polyline) => {
                foreach (var lineString in Polyline.LineStrings) {
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
            });

            //_interceptor?.Invoke(this._hashing.Where(e => !e.Value.fetureRef.Reverse).Select(e => e.Value.curve.LineString).ToList());

            Func<IEnumerable<LineString>, LinearRingOrientation, bool, (FeatureRef featureRef, ICollection<CurveFeature> masks1)> action = (lineStrings, orientation, allowMultiLineString) => {
                FeatureRef featureRef;
                var masks1 = new List<CurveFeature>();
                var masks2 = new List<CurveFeature>();

                if (lineStrings.Count() == 1) {
                    var l = lineStrings.ElementAt(0);

                    if (l.IsRing && orientation != LinearRingOrientation.DontCare) {
                        var ring = l.Factory.CreateLinearRing(l.Coordinates);

                        l = ring.IsCCW switch {
                            true => orientation == LinearRingOrientation.CCW ? l : (LineString)l.Reverse(),
                            false => orientation == LinearRingOrientation.CW ? l : (LineString)l.Reverse(),
                        };
                    }

                    var hash = this._hashing[IO.Hashing.XxHash3.HashToUInt64(l.AsBinary())];
                    if (mask1Hashes.Contains(hash.curve.Id))
                        masks1.Add(hash.curve);
                    featureRef = hash.fetureRef;

                    //var curve = this._curveContainer.AddOrGet(l);
                    //featureRef = new FeatureRef {
                    //    Id = curve.Id,
                    //    Reverse = curve.Reverse,
                    //};
                }
                else {
                    var lineMerger = new LineMerger();
                    lineMerger.Add(lineStrings);

                    var mergedLineStrings = lineMerger.GetMergedLineStrings();

                    string lineStringText = string.Empty;

                    if (allowMultiLineString && mergedLineStrings.Count > 1) {
                        var merged = Matrix.Factory.CreateMultiLineString([.. mergedLineStrings.OfType<LineString>()]);

                        lineStringText = merged.ToText();
                    }
                    else {
                        if (mergedLineStrings.Count > 1) System.Diagnostics.Debugger.Break();

                        var merged = (LineString)mergedLineStrings[0];

                        if (merged.IsRing && orientation != LinearRingOrientation.DontCare) {
                            var ring = merged.Factory.CreateLinearRing(merged.Coordinates);

                            merged = ring.IsCCW switch {
                                true => orientation == LinearRingOrientation.CCW ? merged : (LineString)merged.Reverse(),
                                false => orientation == LinearRingOrientation.CW ? merged : (LineString)merged.Reverse(),
                            };
                        }

                        lineStringText = merged.ToText();
                    }

                    var sortedList = new SortedList<int, FeatureRef>();

                    for (int i = 0; i < lineStrings.Count(); i++) {
                        //var curve = this._curveContainer.AddOrGet(lineStrings.ElementAt(i));

                        var text = lineStrings.ElementAt(i).ToText().Substring("LINESTRING (".Length).TrimEnd(')');
                        if (lineStringText.Contains(text)) {
                            var hash = this._hashing[IO.Hashing.XxHash3.HashToUInt64(lineStrings.ElementAt(i).AsBinary())];

                            if (mask1Hashes.Contains(hash.curve.Id))
                                masks1.Add(hash.curve);

                            sortedList.Add(lineStringText.IndexOf(text), hash.fetureRef);
                            //var curve = this._curveContainer.AddOrGet(lineStrings.ElementAt(i));
                            //sortedList.Add(lineStringText.IndexOf(text), new FeatureRef {
                            //    Id = curve.Id,
                            //    Reverse = curve.Reverse,
                            //});
                        }
                        else {
                            var reverse = lineStrings.ElementAt(i).Reverse();
                            text = reverse.ToText().Substring("LINESTRING (".Length).TrimEnd(')');

                            var hash = this._hashing[IO.Hashing.XxHash3.HashToUInt64(reverse.AsBinary())];

                            if (mask1Hashes.Contains(hash.curve.Id))
                                masks1.Add(hash.curve);

                            var index = lineStringText.IndexOf(text);
                            if (index < 0) System.Diagnostics.Debugger.Break();
                            sortedList.Add(lineStringText.IndexOf(text), hash.fetureRef);
                            //var curve = this._curveContainer.AddOrGet((LineString)reverse);
                            //sortedList.Add(lineStringText.IndexOf(text), new FeatureRef {
                            //    Id = curve.Id,
                            //    Reverse = curve.Reverse,
                            //});
                        }
                    }

                    var compositeExterior = _compositeCurveContainer.AddOrGet(sortedList.Values);

                    featureRef = new FeatureRef {
                        Id = compositeExterior.Id,
                        Reverse = compositeExterior.Reverse,
                    };
                }

                return (featureRef, masks1);
            };

            Parallel.ForEach(this._bagPolygons, ParallelOptions, (polygon) => {
                if (!polygon.ExteriorRing.Any()) return;

                var exteriorId = action(polygon.ExteriorRing, LinearRingOrientation.Clockwise, false);
                var surface = new SurfaceFeature() {
                    Ref = polygon.Name,
                    Exterior = exteriorId.featureRef,
                };
                if (!mask1Objects.Contains(polygon.Name)) {
                    if (exteriorId.masks1.Any())
                        surface.Masks1 = [.. exteriorId.masks1.Select(e => e.Id)];
                }
                if (polygon.InteriorRings.Any()) {
                    var interiorRings = polygon.InteriorRings.Select(e => action(e, LinearRingOrientation.CounterClockwise, false));
                    surface.Interior = [.. interiorRings.Select(e => e.featureRef)];

                    //  interior ring can't touch bondary!
                    //var masks1 = interiorRings.SelectMany(e => e.masks1).Select(e => e.Id).Distinct();
                    //if (masks1.Any()) {
                    //    if (surface.Masks1 != default && surface.Masks1.Any())
                    //        surface.Masks1 = [.. surface.Masks1, .. masks1];
                    //    else
                    //        surface.Masks1 = [.. masks1];
                    //}
                }
                this._bagSurfaces.Add(surface);
                this._mapping.GetOrAdd(polygon.Name, $"S{surface.Id}");
            });

            Parallel.ForEach(this._bagPolylines, ParallelOptions, (polyline) => {
                if (!polyline.LineStrings.Any()) return;

                var curveId = action(polyline.LineStrings, LinearRingOrientation.DontCare, true);

                this._mapping.GetOrAdd(polyline.Name, $"C{curveId.featureRef.Id}");
            });

            return this;
        }

        private void BuildSharedEdges(ICollection<S100Framework.YAML.Polygon> surfaces, ICollection<S100Framework.YAML.Polyline> curves) {
            var minimalEdges = new HashSet<Edge>();

            var edgeToFeatureMap = new Dictionary<Edge, List<string>>();

            void AddLineString(string name, LineString lineString) {
                var coordinates = lineString.Coordinates;
                for (int i = 0; i < coordinates.Length - 1; i++) {
                    var edge = new Edge(coordinates[i], coordinates[i + 1]);
                    minimalEdges.Add(edge);

                    if (!edgeToFeatureMap.ContainsKey(edge)) {
                        edgeToFeatureMap[edge] = new List<string>();
                    }
                    edgeToFeatureMap[edge].Add(name);
                }
            }

            foreach (var polygon in surfaces) {
                AddLineString(polygon.Name, polygon.ExteriorRing);
                if (polygon.InteriorRings.Any()) {
                    for (int i = 0; i < polygon.InteriorRings.Count(); i++)
                        AddLineString($"{polygon.Name}i{i}", polygon.InteriorRings[i]);
                }
            }

            foreach (var curve in curves) {
                AddLineString(curve.Name, curve.LineString);
            }

            this._featureToEdges = new Dictionary<string, List<LineString>>();

            foreach (var e in edgeToFeatureMap.GroupBy(e => string.Join(',', e.Value))) {
                //if (e.Key.Contains("S2674311")) System.Diagnostics.Debugger.Break();

                //if (e.Any(x => x.Key.LineString.ToText().Equals("LINESTRING (11.7465969 54.8704114, 11.7468865 54.8707256)"))) System.Diagnostics.Debugger.Break();

                var merger = new LineMerger();
                merger.Add(e.Select(x => x.Key.LineString));

                var mergedLineStrings = merger.GetMergedLineStrings().OfType<LineString>();

                var hits = e.Key.Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var p in hits) {
                    if (!this._featureToEdges.ContainsKey(p))
                        this._featureToEdges.Add(p, new List<LineString>());
                    this._featureToEdges[p].AddRange(mergedLineStrings);
                }
            }

            //LineString[] array = [.. featureToEdges.SelectMany(e => e.Value)];
            //this._interceptor?.Invoke(array);

            Parallel.For(0, surfaces.Count, Matrix.ParallelOptions, (p) => {
                var surface = surfaces.ElementAt(p);
                IEnumerable<LineString> exteriorRing = this._featureToEdges[surface.Name];
                var interiorRings = new List<IEnumerable<LineString>>();
                for (int i = 0; i < surface.InteriorRings.Count(); i++) {
                    interiorRings.Add(this._featureToEdges[$"{surface.Name}i{i}"]);
                }
                this._bagPolygons.Add((surface.Name, exteriorRing, interiorRings));
            });

            Parallel.For(0, curves.Count, Matrix.ParallelOptions, (c) => {
                var curve = curves.ElementAt(c);

                IEnumerable<LineString> lineStrings = this._featureToEdges[curve.Name];

                this._bagPolylines.Add((curve.Name, lineStrings));
            });
        }

        IEnumerable<CurveFeature> iMatrix.Curves => this._hashing.Select(e => e.Value.curve).DistinctBy(e => e.Id);
        //IEnumerable<CurveFeature> iMatrix.Curves => this._curveContainer.CurveFeatures; //this._hashing.Select(e => e.Value.curve).DistinctBy(e => e.Id);

        IEnumerable<CompositeCurveFeature> iMatrix.CompositeCurves => this._compositeCurveContainer.CompositeCurveFeatures; // this._bagCompositeCurves.Values;

        IEnumerable<SurfaceFeature> iMatrix.Surfaces => this._bagSurfaces;

        IDictionary<string, string> iMatrix.Mapping => this._mapping;


        private class Edge : IEquatable<Edge>
        {
            public NetTopologySuite.Geometries.Coordinate Start { get; }
            public NetTopologySuite.Geometries.Coordinate End { get; }

            public Edge(NetTopologySuite.Geometries.Coordinate p1, NetTopologySuite.Geometries.Coordinate p2) {
                if (p1.CompareTo(p2) < 0) { Start = p1; End = p2; }
                else { Start = p2; End = p1; }
            }

            public bool Equals(Edge? other) {
                if (other is null) return false;
                return Start.Equals(other.Start) && End.Equals(other.End);
            }
            public override bool Equals(object? obj) => Equals(obj as Edge);
            public override int GetHashCode() => (Start, End).GetHashCode();
            public override string ToString() => $"EDGE ({Start.X} {Start.Y}, {End.X} {End.Y})";

            public LineString LineString => Matrix.Factory.CreateLineString([Start, End]);
        }

        public static void AddLineStringsFromGeometry(NetTopologySuite.Geometries.Geometry geometry, List<LineString> targetList) {
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
        }

        public static bool IsGeometryOverlapping(IEnumerable<LineString> lineStrings) {
            //  Validate
            var result = false;
            Parallel.For(0, lineStrings.Count(), new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, (i) => {
                var boundary1 = lineStrings.ElementAt(i);
                for (var j = 0; j < lineStrings.Count(); j++) {
                    if (j == i) continue;

                    var boundary2 = lineStrings.ElementAt(j);

                    var intersection = boundary1.Intersection(boundary2);

                    if (intersection.IsEmpty)
                        continue;
                    if (intersection is NetTopologySuite.Geometries.Point || intersection is NetTopologySuite.Geometries.MultiPoint) {
                        continue;
                    }
                    else
                        result |= true;
                }
            });
            return result;
        }
    }
}

namespace GeoAPI.Geometries
{
    using NetTopologySuite.Geometries;

    public static class Extension
    {
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

