//#define TheMatrix
#define TheMatrixReloaded

using GeoAPI.Geometries;
using NetTopologySuite.Algorithm.Match;
using NetTopologySuite.EdgeGraph;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using NetTopologySuite.Operation;
using NetTopologySuite.Operation.Buffer.Validate;
using NetTopologySuite.Operation.Linemerge;
using NetTopologySuite.Operation.Union;
using NetTopologySuite.Simplify;
using NetTopologySuite.Triangulate;
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


#if TheMatrixReloaded
    public interface iTopologyBuilder
    {
        iTopologyBuilder AddTopologyFeatures(ICollection<S100Framework.YAML.Polygon> surfaces, ICollection<S100Framework.YAML.Polyline> curves);
        iTopologyBuilder AddNavigationalFeatures(ICollection<S100Framework.YAML.Polygon> surfaces, ICollection<S100Framework.YAML.Polyline> curves);
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

        public static GeometryFactory? Factory { get; set; } = default;

        protected Matrix() {
            //  Default protected constructor
        }

        private Action<ICollection<LineString>>? _interceptor = default;

        private IEnumerable<LineString> _networkTopology = Enumerable.Empty<LineString>();

        private ConcurrentBag<(string Name, IEnumerable<LineString> ExteriorRing, List<IEnumerable<LineString>> InteriorRings)> _bagPolygons = new ConcurrentBag<(string Name, IEnumerable<LineString> ExteriorRing, List<IEnumerable<LineString>> InteriorRings)>();

        private ConcurrentBag<(string Name, IEnumerable<LineString> LineStrings)> _bagPolylines = new ConcurrentBag<(string Name, IEnumerable<LineString> LineStrings)>();

        private ConcurrentDictionary<ulong, (FeatureRef fetureRef, CurveFeature curve)> _hashing = new ConcurrentDictionary<ulong, (FeatureRef fetureRef, CurveFeature curve)>();

        private ConcurrentDictionary<string, CompositeCurveFeature> _bagCompositeCurves = new ConcurrentDictionary<string, CompositeCurveFeature>();

        private ConcurrentDictionary<string, string> _mapping = new ConcurrentDictionary<string, string>();

        private ConcurrentBag<SurfaceFeature> _bagSurfaces = new ConcurrentBag<SurfaceFeature>();

        private ICollection<S100Framework.YAML.Polygon> _surfacesTopology;
        private ICollection<S100Framework.YAML.Polyline> _curvesTopology;

        private ICollection<S100Framework.YAML.Polygon> _surfacesNavigational;
        private ICollection<S100Framework.YAML.Polyline> _curvesNavigational;

        private NetTopologySuite.Geometries.Geometry? _geometryCollection;

        public static iTopologyBuilder CreateMatrix(Action<ICollection<LineString>>? interceptor = default) {
            return new Matrix() {
                _interceptor = interceptor,
            };
        }

        iTopologyBuilder iTopologyBuilder.AddTopologyFeatures(ICollection<S100Framework.YAML.Polygon> surfaces, ICollection<S100Framework.YAML.Polyline> curves) {
            this._surfacesTopology = surfaces;
            this._curvesTopology = curves;

            var boundaries = this._surfacesTopology.Select(e => e.ExteriorRing.RemoveRepeatedVertices());//.Union(polygons.SelectMany(e => e.InteriorRings));
            foreach (var polygon in this._surfacesTopology) {
                boundaries.Concat(polygon.InteriorRings.Select(r => r.RemoveRepeatedVertices()));
            }

            //this._nodedNetwork = Matrix2.Factory!.CreateGeometryCollection([.. boundaries]).Union();

            var unionOp = new UnaryUnionOp(boundaries, Matrix.Factory);
            var nodedNetwork = unionOp.Union();

            //var simplifier = new DouglasPeuckerSimplifier(this._nodedNetwork) {
            //    DistanceTolerance = 0,
            //    EnsureValidTopology = true,
            //};

            //this._nodedNetwork = simplifier.GetResultGeometry();

            //var multiLineString = (MultiLineString)this._nodedNetwork;
            //this._network = multiLineString.OfType<LineString>();

            //this._interceptor?.Invoke([.. multiLineString.OfType<LineString>()]);

            var lineMerger = new LineMerger();
            lineMerger.Add(nodedNetwork);

            this._networkTopology = lineMerger.GetMergedLineStrings().OfType<LineString>();


            //this._interceptor?.Invoke([.. this._networkTopology]);

            this._geometryCollection =  Matrix.Factory!.CreateMultiLineString([.. this._networkTopology]);

            //if(this._network.Any(e=>!(e is LineString))) System.Diagnostics.Debugger.Break();

            //_edgeGraph = EdgeGraphBuilder.Build(boundaries);

            //if (this._interceptor != default) {
            //    var lineStrings = new List<LineString>();
            //    S100Framework.YAML.Matrix.AddLineStringsFromGeometry(this._nodedNetwork, lineStrings);

            //    //    var text = lineStrings[5912];
            //    //    _interceptor?.Invoke([text]);
            //    _interceptor?.Invoke(lineStrings);
            //}
            return (iTopologyBuilder)this;
        }

        iTopologyBuilder iTopologyBuilder.AddNavigationalFeatures(ICollection<Polygon> surfaces, ICollection<S100Framework.YAML.Polyline> curves) {
            this._surfacesNavigational = surfaces;
            this._curvesNavigational = curves;

            return (iTopologyBuilder)this;
        }

        iMatrix iTopologyBuilder.BuildTopology() {
            if (this._surfacesTopology.Any() || this._curvesTopology.Any())
                this.Build(this._surfacesTopology, this._curvesTopology, false);

            _interceptor?.Invoke([.. this._bagPolygons.SelectMany(e => e.ExteriorRing)]);

            if (this._surfacesNavigational.Any() || this._curvesNavigational.Any())
                this.Build(this._surfacesNavigational, this._curvesNavigational, true);

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

            _interceptor?.Invoke(this._hashing.Where(e => !e.Value.fetureRef.Reverse).Select(e => e.Value.curve.LineString).ToList());

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

            _interceptor?.Invoke(this._hashing.Where(e => !e.Value.fetureRef.Reverse).Select(e => e.Value.curve.LineString).ToList());

            Func<IEnumerable<LineString>, LinearRingOrientation, FeatureRef> action = (lineStrings, orientation) => {
                FeatureRef featureRef;

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
                    featureRef = hash.fetureRef;
                }
                else {
                    var lineMerger = new LineMerger();
                    lineMerger.Add(lineStrings);

                    var mergedLineStrings = lineMerger.GetMergedLineStrings();
                    if (mergedLineStrings.Count > 1) {
                        System.Diagnostics.Debugger.Break();                        
                    }
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

                    for (int i = 0; i < lineStrings.Count(); i++) {

                        var text = lineStrings.ElementAt(i).ToText().Substring("LINESTRING (".Length).TrimEnd(')');
                        if (lineStringText.Contains(text)) {
                            var hash = this._hashing[IO.Hashing.XxHash3.HashToUInt64(lineStrings.ElementAt(i).AsBinary())];

                            sortedList.Add(lineStringText.IndexOf(text), hash.fetureRef);
                        }
                        else {
                            var reverse = lineStrings.ElementAt(i).Reverse();

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

                    compositeExterior = this._bagCompositeCurves.GetOrAdd(key, (key) => {
                        return compositeExterior;
                    });

                    featureRef = new FeatureRef {
                        Id = compositeExterior.Id,
                        Reverse = false,
                    };
                }

                return featureRef;
            };

            Parallel.ForEach(this._bagPolygons, ParallelOptions, (polygon) => {
                if (!polygon.ExteriorRing.Any()) return;

                if (polygon.Name.Equals("S2675929")) System.Diagnostics.Debugger.Break();

                FeatureRef exteriorId = action(polygon.ExteriorRing, LinearRingOrientation.Clockwise);
                var surface = new SurfaceFeature() {
                    Ref = polygon.Name,
                    Exterior = exteriorId,
                };
                if (polygon.InteriorRings.Any()) {
                    surface.Interior = polygon.InteriorRings.Select(e => action(e, LinearRingOrientation.CounterClockwise)).ToArray();
                }
                this._bagSurfaces.Add(surface);
                this._mapping.GetOrAdd(polygon.Name, $"S{surface.Id}");
            });

            Parallel.ForEach(this._bagPolylines, ParallelOptions, (polyline) => {
                if (!polyline.LineStrings.Any()) return;

                FeatureRef curveId = action(polyline.LineStrings, LinearRingOrientation.DontCare);

                this._mapping.GetOrAdd(polyline.Name, $"C{curveId.Id}");
            });

            return this;
        }


        private void Build(ICollection<S100Framework.YAML.Polygon> surfaces, ICollection<S100Framework.YAML.Polyline> curves, bool gaps = false) {
            //var lineStringsForward = ((MultiLineString)this._nodedNetwork!)
            //    .ToDictionary(e => (LineString)e, e => e.ToText().Substring("LINESTRING (".Length).TrimEnd(')'));

            //var lineStringsReverse = ((MultiLineString)this._nodedNetwork!)
            //    .ToDictionary(e => (LineString)e, e => e.Reverse().ToText().Substring("LINESTRING (".Length).TrimEnd(')'));

            var lineStringsForward = this._networkTopology.ToDictionary(e => e, e => e.ToText().Substring("LINESTRING (".Length).TrimEnd(')'));
            var lineStringsReverse = this._networkTopology.ToDictionary(e => e, e => e.Reverse().ToText().Substring("LINESTRING (".Length).TrimEnd(')'));

            Parallel.For(0, surfaces.Count, Matrix.ParallelOptions, (i) => {
                var polygon = surfaces.ElementAt(i);

                //if (polygon.name.Equals("S2674462")) System.Diagnostics.Debugger.Break();
                //if (polygon.name.Equals("S2675929")) System.Diagnostics.Debugger.Break();

                IEnumerable<LineString> exteriorRing = Enumerable.Empty<LineString>();

                if (!polygon.ExteriorRing.IsEmpty) {
                    var boundary1 = polygon.ExteriorRing.ToText();

                    var hitsForward = lineStringsForward.Where(e => boundary1.Contains(e.Value));
                    var hitsReverse = lineStringsReverse.Where(e => boundary1.Contains(e.Value));

                    var hits = hitsForward.Concat(hitsReverse).Select(e => e.Key);

                    var difference = polygon.ExteriorRing.Difference(polygon.ExteriorRing.Factory.CreateMultiLineString(hits.ToArray()));

                    if (!difference.IsEmpty) {
                        var contains = this._networkTopology.Where(e => difference.Contains(e));

                        hits = [.. hits, .. contains];

                        difference = polygon.ExteriorRing.Difference(polygon.ExteriorRing.Factory.CreateMultiLineString(hits.ToArray()));
                        if (!difference.IsEmpty) {
                            if (gaps) {
                                //NetTopologySuite.Geometries.Geometry? boundary = polygon.ExteriorRing;

                                //var intersections = boundary.Intersection(this._geometryCollection);

                                //if (!intersections.IsEmpty) {
                                //    if (intersections is GeometryCollection collection) {
                                //        intersections = intersections.Factory.CreateMultiLineString(collection.OfType<LineString>().ToArray());
                                //    }

                                //    if (intersections is NetTopologySuite.Geometries.LineString lineStringIntersection)
                                //        hits = [.. hits, lineStringIntersection];
                                //    else if (intersections is NetTopologySuite.Geometries.MultiLineString multiLineStringIntersection)
                                //        hits = [.. hits, .. multiLineStringIntersection.OfType<LineString>()];
                                //    else
                                //        System.Diagnostics.Debugger.Break();

                                //    if (polygon.name.Equals("S2675929"))
                                //        this._interceptor?.Invoke([.. hits]);
                                //    difference = boundary.Difference(intersections);                                   
                                //}
                                //if (difference is LineString lineStringDifference) {
                                //    hits = [.. hits, lineStringDifference];
                                //}
                                //else if (difference is MultiLineString multiLineStringDifference) {
                                //    hits = [.. hits, .. multiLineStringDifference.OfType<LineString>()];
                                //}
                                //else
                                //    System.Diagnostics.Debugger.Break();

                                //if (polygon.name.Equals("S2675929"))
                                //    this._interceptor?.Invoke([.. hits]);


                                //for (int b = 0; b < this._networkTopology.Count(); b++) {
                                //    var boundary2 = this._networkTopology.ElementAt(b);
                                //    if (boundary.Disjoint(boundary))
                                //        continue;

                                //    if (boundary.Intersects(boundary2)) {
                                //        var sharedEdgesGeometry = boundary.Intersection(boundary2);
                                //        if (sharedEdgesGeometry is NetTopologySuite.Geometries.Point || sharedEdgesGeometry is NetTopologySuite.Geometries.MultiPoint) {
                                //            continue;
                                //        }
                                //        if (sharedEdgesGeometry is GeometryCollection collection) {
                                //            sharedEdgesGeometry = sharedEdgesGeometry.Factory.CreateMultiLineString(collection.OfType<LineString>().ToArray());
                                //        }
                                //        if (sharedEdgesGeometry.IsEmpty) {
                                //            continue;
                                //        }
                                //        if (sharedEdgesGeometry is LineString lineStringIntersects) {
                                //            hits = [.. hits, lineStringIntersects];
                                //        }
                                //        else if (sharedEdgesGeometry is MultiLineString multiLineStringIntersects) {
                                //            hits = [.. hits, .. multiLineStringIntersects.OfType<LineString>()];
                                //        }                                        

                                //        boundary = boundary.Difference(sharedEdgesGeometry);
                                //        if (boundary.IsEmpty)
                                //            break;
                                //    }
                                //}
                                //if (!boundary.IsEmpty) {
                                //    if (boundary is LineString lineStringDifference) {
                                //        hits = [.. hits, lineStringDifference];
                                //    }
                                //    else if (boundary is MultiLineString multiLineStringDifference) {
                                //        hits = [.. hits, .. multiLineStringDifference.OfType<LineString>()];
                                //    }
                                //    else
                                //        System.Diagnostics.Debugger.Break();
                                //}


                                if (difference is NetTopologySuite.Geometries.LineString lineString)
                                    hits = [.. hits, lineString];
                                else if (difference is NetTopologySuite.Geometries.MultiLineString multiLineString)
                                    hits = [.. hits, .. multiLineString.OfType<LineString>()];
                                else
                                    System.Diagnostics.Debugger.Break();
                            }
                            else
                                System.Diagnostics.Debugger.Break();
                        }
                    }

                    hits = hits.Where(e => e.IsValid && !e.IsEmpty).DistinctBy(e => System.IO.Hashing.XxHash3.HashToUInt64(e.ToBinary()));
                    exteriorRing = hits;
                }

                var interiorRings = new List<IEnumerable<LineString>>();
                foreach (var interior in polygon.InteriorRings) {
                    var boundary2 = interior.ToText();

                    var hitsForward = lineStringsForward.Where(e => boundary2.Contains(e.Value));
                    var hitsReverse = lineStringsReverse.Where(e => boundary2.Contains(e.Value));

                    var hits = hitsForward.Concat(hitsReverse).Select(e => e.Key);

                    var differenceInterior = interior.Difference(interior.Factory.CreateMultiLineString(hits.ToArray()));

                    if (!differenceInterior.IsEmpty) {
                        var contains = this._networkTopology.Where(e => differenceInterior.Contains(e));

                        hits = [.. hits, .. contains];

                        differenceInterior = interior.Difference(polygon.ExteriorRing.Factory.CreateMultiLineString(hits.ToArray()));
                        if (!differenceInterior.IsEmpty) {
                            if (gaps) {
                                if (differenceInterior is NetTopologySuite.Geometries.LineString lineString)
                                    hits = [.. hits, lineString];
                                else if (differenceInterior is NetTopologySuite.Geometries.MultiLineString multiLineString)
                                    hits = [.. hits, .. multiLineString.OfType<LineString>()];
                                else
                                    System.Diagnostics.Debugger.Break();
                            }
                            else
                                System.Diagnostics.Debugger.Break();
                        }
                    }
                    hits = hits.Where(e => e.IsValid && !e.IsEmpty).DistinctBy(e => System.IO.Hashing.XxHash3.HashToUInt64(e.ToBinary()));
                    interiorRings.Add(hits);
                }
                this._bagPolygons.Add((polygon.name, exteriorRing, interiorRings));
            });

            Parallel.For(0, curves.Count, Matrix.ParallelOptions, (i) => {
                var polyline = curves.ElementAt(i);

                IEnumerable<LineString> lineStrings = Enumerable.Empty<LineString>();

                if (!polyline.LineString.IsEmpty) {
                    var boundary1 = polyline.LineString.ToText();

                    var hitsForward = lineStringsForward.Where(e => boundary1.Contains(e.Value));
                    var hitsReverse = lineStringsReverse.Where(e => boundary1.Contains(e.Value));

                    var hits = hitsForward.Concat(hitsReverse).Select(e => e.Key);

                    var difference = polyline.LineString.Difference(polyline.LineString.Factory.CreateMultiLineString(hits.ToArray()));

                    if (difference is LineString lineString) {
                        hits = [.. hits, lineString];
                    }
                    else if (difference is MultiLineString multiLine) {
                        hits = [.. hits, .. multiLine.Geometries.OfType<LineString>()];
                    }

                    lineStrings = hits.Where(e => e.IsValid && !e.IsEmpty);
                }

                this._bagPolylines.Add((polyline.name, lineStrings));
            });
        }

        IEnumerable<CurveFeature> iMatrix.Curves => this._hashing.Select(e => e.Value.curve).DistinctBy(e => e.Id);

        IEnumerable<CompositeCurveFeature> iMatrix.CompositeCurves => this._bagCompositeCurves.Values;

        IEnumerable<SurfaceFeature> iMatrix.Surfaces => this._bagSurfaces;

        IDictionary<string, string> iMatrix.Mapping => this._mapping;

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
#endif

#if TheMatrix
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

        private List<LineString> Append(List<LineString> lineStrings, List<LineString> append) {
            foreach (var linestring in append) {
                lineStrings = Append(lineStrings, linestring);
            }
            return lineStrings;
        }

        private List<LineString> Append(List<LineString> lineStrings, Geometry geometry) {
            if (geometry is LineString line) {
                if (!line.IsEmpty) {
                    return Append(lineStrings, line);
                }
            }
            else if (geometry is MultiLineString multiLine) {
                foreach (var subLine in multiLine.Geometries.OfType<LineString>()) {
                    if (!subLine.IsEmpty) {
                        lineStrings = Append(lineStrings, subLine);
                    }
                }
            }
            else if (geometry is NetTopologySuite.Geometries.Point)
                return lineStrings;
            else if (geometry is NetTopologySuite.Geometries.MultiPoint)
                return lineStrings;
            else
                throw new NotImplementedException();
            return lineStrings;
        }

        private List<LineString> Split(List<LineString> lineStrings, Geometry geometry) {
            if (geometry is NetTopologySuite.Geometries.LineString line) {
                if (!line.IsEmpty) {
                    return Append(lineStrings, line, false);
                }
            }
            else if (geometry is NetTopologySuite.Geometries.MultiLineString multiLine) {
                foreach (var subLine in multiLine.Geometries.OfType<LineString>()) {
                    if (!subLine.IsEmpty) {
                        lineStrings = Append(lineStrings, subLine, false);
                    }
                }
            }
            else if (geometry is NetTopologySuite.Geometries.Point)
                return lineStrings;
            else if (geometry is NetTopologySuite.Geometries.MultiPoint)
                return lineStrings;
            else
                throw new NotImplementedException();
            return lineStrings;
        }

        private List<LineString> Append(List<LineString> lineStrings, LineString lineString, bool splitOnly = false) {
            var inserts = new List<LineString>();

            NetTopologySuite.Geometries.Geometry boundary1 = lineString;

            for (int l = 0; l < lineStrings.Count; l++) {
                var boundary2 = lineStrings[l];
                if (boundary1.Disjoint(boundary2)) {
                    inserts.Add(boundary2);
                    continue;
                }
                if (boundary1.EqualsTopologically(boundary2)) {
                    inserts.Add(boundary2);
                    continue;
                }
                if (boundary2.Intersects(boundary1)) {
                    var sharedEdgesGeometry = boundary1.Intersection(boundary2);

                    if (sharedEdgesGeometry is NetTopologySuite.Geometries.Point || sharedEdgesGeometry is NetTopologySuite.Geometries.MultiPoint) {
                        inserts.Add(boundary2);
                        continue;
                    }

                    if (sharedEdgesGeometry is not NetTopologySuite.Geometries.Point) {
                        if (sharedEdgesGeometry is GeometryCollection collection) {
                            sharedEdgesGeometry = sharedEdgesGeometry.Factory.CreateMultiLineString(collection.OfType<LineString>().ToArray());
                        }
                        if (sharedEdgesGeometry.IsEmpty) {
                            inserts.Add(boundary2);
                            continue;
                        }

                        var lineMerger = new LineMerger();
                        lineMerger.Add(sharedEdgesGeometry);

                        var sharedEdgesLineString = lineMerger.GetMergedLineStrings().Select(e => (LineString)e).ToList();

                        boundary1 = boundary1.SymmetricDifference(sharedEdgesGeometry);
                        //AddLineStringsFromGeometry(sharedEdgesGeometry, inserts);
                        inserts.AddRange(sharedEdgesLineString);

                        //boundary1 = boundary1.SymmetricDifference(boundary2);
                        // DUR MÅSKE IKKE VED POLYGON!!!!

                        var difference2 = boundary2.SymmetricDifference(sharedEdgesGeometry);
                        AddLineStringsFromGeometry(difference2, inserts);

                    }
                }
                else if (boundary1.Contains(boundary2)) {
                    System.Diagnostics.Debugger.Break();
                }
                else if (boundary2.Contains(boundary1)) {
                    System.Diagnostics.Debugger.Break();
                }
            }
            if (!boundary1.IsEmpty && !splitOnly) {
                //inserts.Add(boundary1);
                AddLineStringsFromGeometry(boundary1, inserts);
            }

            return inserts;
        }

        private void Validate(LineString[] lineStrings, Action<ICollection<LineString>>? interceptor = default) {
            interceptor?.Invoke(lineStrings.ToList());

            var selector = new List<int>();
            for (int i = 0; i < lineStrings.Length; i++) {
                var boundary1 = lineStrings[i];
                for (int j = i + 1; j < lineStrings.Length; j++) {
                    var boundary2 = lineStrings[j];

                    if (boundary1.EqualsTopologically(boundary2)) {
                        ;// System.Diagnostics.Debugger.Break();
                    }
                    else if (boundary1.Intersects(boundary2)) {
                        var intersection = boundary1.Intersection(boundary2);
                        if (intersection is NetTopologySuite.Geometries.Point) {
                            //  Don't care
                        }
                        else if (intersection is NetTopologySuite.Geometries.MultiPoint) {
                            //  Don't care
                        }
                        else {
                            selector.Add(i);
                            selector.Add(j);
                            var query = $"{i},{j}";
                            System.Diagnostics.Debugger.Break();
                        }
                    }
                }
            }
            var select = string.Join(',', selector.Distinct());
            if (selector.Any())
                System.Diagnostics.Debugger.Break();
        }

        public S100Framework.YAML.Matrix Build(S100Framework.YAML.Polyline[] polylines, S100Framework.YAML.Polygon[] polygons, Action<ICollection<LineString>>? interceptor = default) {
            int count = polygons.Count();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            (string Name, NetTopologySuite.Geometries.Geometry Curve, List<LineString> LineStrings)[] matrixCurves = polylines.Select(e => (e.name, (NetTopologySuite.Geometries.Geometry)e.LineString, new List<LineString>())).ToArray();

            (string Name, NetTopologySuite.Geometries.Geometry ExterioRing, NetTopologySuite.Geometries.Geometry[] InteriorRings, List<LineString> LineStringsExterior, List<LineString>[] LineStringInterior)[] matrixPolygons = polygons.Select(e => (e.name, (NetTopologySuite.Geometries.Geometry)e.ExteriorRing, e.InteriorRings.Select(r => (NetTopologySuite.Geometries.Geometry)r).ToArray(), new List<LineString>(), Array.Empty<List<LineString>>())).ToArray();

            for (int i = 0; i < polygons.Length; i++) {

                var boundary1Name = matrixPolygons[i].Name;

                //if (boundary1Name.Equals("S2557775")) System.Diagnostics.Debugger.Break();

                if (!matrixPolygons[i].ExterioRing.IsEmpty) {
                    NetTopologySuite.Geometries.Geometry boundary1 = matrixPolygons[i].ExterioRing;

                    for (var j = 0; j < this.Curves.Count; j++) {
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

                            if (sharedEdgesGeometry is GeometryCollection geometryCollection) {
                                sharedEdgesGeometry = sharedEdgesGeometry.Factory.CreateMultiLineString(geometryCollection.OfType<LineString>().ToArray());
                            }

                            if (sharedEdgesGeometry == null || sharedEdgesGeometry.IsEmpty) continue;

                            var lineMerger = new LineMerger();
                            lineMerger.Add(sharedEdgesGeometry);

                            var sharedEdgesLineString = lineMerger.GetMergedLineStrings().Select(e => (LineString)e).ToList();

                            boundary1 = boundary1.SymmetricDifference(sharedEdgesGeometry);
                            matrixPolygons[i].LineStringsExterior.AddRange(sharedEdgesLineString);
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

                    if (hash == 14838292432751665071) System.Diagnostics.Debugger.Break();

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

                            if (hash == 14838292432751665071) System.Diagnostics.Debugger.Break();

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

                    if (hash == 14838292432751665071) System.Diagnostics.Debugger.Break();

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

                //if (origin.name.Equals("S2533324")) System.Diagnostics.Debugger.Break();

                if (origin.name.Equals("S2557775"))
                    interceptor?.Invoke([.. m.LineStringsExterior]);

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

        public S100Framework.YAML.Matrix BuildGroupOne(S100Framework.YAML.Polyline[] polylines, S100Framework.YAML.Polygon[] polygons, S100Framework.YAML.Polyline[] splitters, Action<ICollection<LineString>>? interceptor = default) {
            int count = polygons.Count();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            (string Name, NetTopologySuite.Geometries.Geometry Curve, List<LineString> LineStrings)[] matrixCurves = polylines.Select(e => (e.name, (NetTopologySuite.Geometries.Geometry)e.LineString, new List<LineString>())).ToArray();

            (string Name, NetTopologySuite.Geometries.Geometry ExterioRing, NetTopologySuite.Geometries.Geometry[] InteriorRings, List<LineString> LineStringsExterior, List<LineString>[] LineStringInterior)[] matrixPolygons = polygons.Select(e => (e.name, (NetTopologySuite.Geometries.Geometry)e.ExteriorRing, e.InteriorRings.Select(r => (NetTopologySuite.Geometries.Geometry)r).ToArray(), new List<LineString>(), Array.Empty<List<LineString>>())).ToArray();


            for (int i = 0; i < polygons.Length; i++) {
                var boundary1Name = matrixPolygons[i].Name;

                //if (matrixPolygons[i].Name.Equals("S2678791")) System.Diagnostics.Debugger.Break();
                //if (matrixPolygons[i].Name.Equals("S2674464")) System.Diagnostics.Debugger.Break();

                //20250702, if (matrixPolygons[i].ExterioRing.IsEmpty) continue;                

                if (!matrixPolygons[i].ExterioRing.IsEmpty) {
                    NetTopologySuite.Geometries.Geometry boundary1 = matrixPolygons[i].ExterioRing;

                    ////var item = matrixPolygons.Single(e => e.Name.Equals("S2678791"));
                    ////var index = Array.IndexOf(matrixPolygons, item);

                    for (var j = i + 1; j < polygons.Length; j++) {
                        var boundary2Name = matrixPolygons[j].Name;

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

                            if (sharedEdgesGeometry is NetTopologySuite.Geometries.Point || sharedEdgesGeometry is NetTopologySuite.Geometries.MultiPoint)
                                continue;

                            if (sharedEdgesGeometry is GeometryCollection geometryCollection) {
                                sharedEdgesGeometry = geometryCollection.Factory.CreateMultiLineString(geometryCollection.OfType<LineString>().ToArray());
                            }

                            if (sharedEdgesGeometry == null || sharedEdgesGeometry.IsEmpty) continue;

                            var lineMerger = new LineMerger();
                            lineMerger.Add(sharedEdgesGeometry);

                            var sharedEdgesLineString = lineMerger.GetMergedLineStrings().Select(e => (LineString)e).ToList();

                            boundary1 = boundary1.SymmetricDifference(sharedEdgesGeometry);
                            //matrixPolygons[i].LineStringsExterior.AddRange(sharedEdgesLineString);
                            matrixPolygons[i].LineStringsExterior = Append(matrixPolygons[i].LineStringsExterior, sharedEdgesLineString);

                            matrixPolygons[j].ExterioRing = boundary2.SymmetricDifference(sharedEdgesGeometry);
                            //matrixPolygons[j].LineStringsExterior.AddRange(sharedEdgesLineString);
                            matrixPolygons[j].LineStringsExterior = Append(matrixPolygons[j].LineStringsExterior, sharedEdgesLineString);

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

                                ////if (matrixPolygons[j].Name.Equals("S2674391") && ring == 0) System.Diagnostics.Debugger.Break();

                                boundary1 = boundary1.SymmetricDifference(sharedEdgesGeometry);
                                //matrixPolygons[i].LineStringsExterior.AddRange(sharedEdgesLineString);
                                matrixPolygons[i].LineStringsExterior = Append(matrixPolygons[i].LineStringsExterior, sharedEdgesLineString);

                                if (matrixPolygons[j].LineStringInterior.Length == 0)
                                    matrixPolygons[j].LineStringInterior = new List<LineString>[polygons[j].InteriorRings.Length];
                                if (matrixPolygons[j].LineStringInterior[ring] is null)
                                    matrixPolygons[j].LineStringInterior[ring] = new List<LineString>();

                                matrixPolygons[j].InteriorRings[ring] = boundary2.SymmetricDifference(sharedEdgesGeometry);
                                //matrixPolygons[j].LineStringInterior[ring].AddRange(sharedEdgesLineString);
                                matrixPolygons[j].LineStringInterior[ring] = Append(matrixPolygons[j].LineStringInterior[ring], sharedEdgesLineString);

                                ////if (matrixPolygons[j].Name.Equals("S2674391") && ring == 0) {
                                ////    var dummies = new List<LineString>();
                                ////    AddLineStringsFromGeometry(matrixPolygons[j].InteriorRings[ring], dummies);
                                ////    interceptor?.Invoke(dummies);
                                ////    interceptor?.Invoke(matrixPolygons[j].LineStringInterior[ring]);
                                ////}
                            }
                        }

                        if (boundary1.IsEmpty)
                            break;
                    }

                    if (!boundary1.IsEmpty) {
                        //AddLineStringsFromGeometry(boundary1, matrixPolygons[i].LineStringsExterior);
                        matrixPolygons[i].LineStringsExterior = Append(matrixPolygons[i].LineStringsExterior, boundary1);
                    }
                }
                if (polygons[i].InteriorRings.Any()) {
                    if (matrixPolygons[i].LineStringInterior.Length == 0)
                        matrixPolygons[i].LineStringInterior = new List<LineString>[polygons[i].InteriorRings.Length];

                    for (int ring = 0; ring < polygons[i].InteriorRings.Length; ring++) {
                        if (matrixPolygons[i].LineStringInterior[ring] is null)
                            matrixPolygons[i].LineStringInterior[ring] = new List<LineString>();

                        NetTopologySuite.Geometries.Geometry interior1 = matrixPolygons[i].InteriorRings[ring];

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

                            if (sharedEdgesGeometry is GeometryCollection geometryCollection) {
                                sharedEdgesGeometry = geometryCollection.Factory.CreateMultiLineString(geometryCollection.OfType<LineString>().ToArray());
                            }

                            if (sharedEdgesGeometry == null || sharedEdgesGeometry.IsEmpty) continue;

                            var lineMerger = new LineMerger();
                            lineMerger.Add(sharedEdgesGeometry);

                            var sharedEdgesLineString = lineMerger.GetMergedLineStrings().Select(e => (LineString)e).ToList();

                            interior1 = interior1.SymmetricDifference(sharedEdgesGeometry);
                            //matrixPolygons[i].LineStringInterior[ring].AddRange(sharedEdgesLineString);
                            matrixPolygons[i].LineStringInterior[ring] = Append(matrixPolygons[i].LineStringInterior[ring], sharedEdgesLineString);

                            matrixPolygons[j].ExterioRing = boundary2.SymmetricDifference(sharedEdgesGeometry);
                            //matrixPolygons[j].LineStringsExterior.AddRange(sharedEdgesLineString);
                            matrixPolygons[j].LineStringsExterior = Append(matrixPolygons[j].LineStringsExterior, sharedEdgesLineString);

                            if (interior1.IsEmpty)
                                break;
                        }

                        if (!interior1.IsEmpty) {
                            //AddLineStringsFromGeometry(interior1, matrixPolygons[i].LineStringInterior[ring]);                     
                            matrixPolygons[i].LineStringInterior[ring] = Append(matrixPolygons[i].LineStringInterior[ring], interior1);
                        }
                    }
                }
            }

            if (interceptor != default) {
                Validate(matrixPolygons.SelectMany(e => e.LineStringsExterior).ToArray(), interceptor);
            }

            for (var i = 0; i < splitters.Length; i++) {
                NetTopologySuite.Geometries.Geometry boundary1 = splitters[i].LineString;

                for (var j = 0; j < polygons.Length; j++) {
                    if (boundary1.Disjoint(polygons[j].ExteriorRing)) continue;
                    if (boundary1.EqualsTopologically(polygons[j].ExteriorRing)) continue;

                    var sharedEdgesGeometry = boundary1.Intersection(boundary1.Factory.CreateMultiLineString([.. matrixPolygons[j].LineStringsExterior]));

                    if (sharedEdgesGeometry is GeometryCollection geometryCollection) {
                        sharedEdgesGeometry = geometryCollection.Factory.CreateMultiLineString(geometryCollection.OfType<LineString>().ToArray());
                    }

                    var lineMerger = new LineMerger();
                    lineMerger.Add(sharedEdgesGeometry);

                    var sharedEdgesLineString = lineMerger.GetMergedLineStrings().Select(e => (LineString)e).ToList();
                    matrixPolygons[j].LineStringsExterior = Append(matrixPolygons[j].LineStringsExterior, sharedEdgesLineString);
                }
            }

            if (interceptor != default) {
                Validate(matrixPolygons.SelectMany(e => e.LineStringsExterior).ToArray(), interceptor);

            }

            foreach (var m in matrixPolygons) {
                foreach (var lineString in m.LineStringsExterior) {
                    var hash = System.IO.Hashing.XxHash3.HashToUInt64(lineString.AsBinary());

                    var f = new CurveFeature(lineString);

                    var r1 = this._hashing.GetOrAdd(hash, (new FeatureRef {
                        Id = f.Id,
                        Reverse = false,
                    }, f));
                    hash = System.IO.Hashing.XxHash3.HashToUInt64(f.LineString.Reverse().AsBinary());
                    var r2 = this._hashing.GetOrAdd(hash, (new FeatureRef {
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


            CurveFeature[] curves = [.. this._hashing.Select(e => e.Value).DistinctBy(e => e.fetureRef.Id).Select(e => e.curve)];

            interceptor?.Invoke(curves.Select(e => e.LineString).ToArray());

            Parallel.For(0, polylines.Length, (i) => {
                NetTopologySuite.Geometries.Geometry boundary1 = matrixCurves[i].Curve;

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

                    var sharedEdgesGeometry = boundary1.Intersection(c.LineString);

                    if (sharedEdgesGeometry is GeometryCollection collection) {
                        sharedEdgesGeometry = sharedEdgesGeometry.Factory.CreateMultiLineString(collection.OfType<LineString>().ToArray());
                    }

                    if (sharedEdgesGeometry == null || sharedEdgesGeometry.IsEmpty) continue;

                    var lineMerger = new LineMerger();
                    lineMerger.Add(sharedEdgesGeometry);

                    var sharedEdgesLineString = lineMerger.GetMergedLineStrings().Select(e => (LineString)e).ToList();

                    matrixCurves[i].Curve = boundary1.SymmetricDifference(sharedEdgesGeometry);
                    //matrixCurves[i].LineStrings.AddRange(sharedEdgesLineString);
                    matrixCurves[i].LineStrings = Append(matrixCurves[i].LineStrings, sharedEdgesLineString);

                    boundary1 = matrixCurves[i].Curve;

                    if (boundary1.IsEmpty)
                        break;
                }

                if (!boundary1.IsEmpty) {
                    //AddLineStringsFromGeometry(matrixCurves[i].Curve, matrixCurves[i].LineStrings);
                    matrixCurves[i].LineStrings = Append(matrixCurves[i].LineStrings, boundary1);
                }
            });

            foreach (var m in matrixCurves) {
                foreach (var lineString in m.LineStrings) {
                    var hash = System.IO.Hashing.XxHash3.HashToUInt64(lineString.AsBinary());

                    ////var text = string.Join(",", lineString.Coordinates.Select(e => string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0.0000000},{1:0.0000000}", e.X, e.Y)));
                    ////if (text.Equals("12.6800700,55.6103400,12.6805700,55.6102700,12.6809422,55.6102650,12.6813100,55.6102600"))
                    ////    System.Diagnostics.Debugger.Break();

                    var f = new CurveFeature(lineString);

                    var r1 = this._hashing.GetOrAdd(hash, (new FeatureRef {
                        Id = f.Id,
                        Reverse = false,
                    }, f));
                    hash = System.IO.Hashing.XxHash3.HashToUInt64(f.LineString.Reverse().AsBinary());
                    var r2 = this._hashing.GetOrAdd(hash, (new FeatureRef {
                        Id = f.Id,
                        Reverse = true,
                    }, f));
                }
            }

            ////{
            ////    interceptor?.Invoke(_hashing.Where(e => !e.Value.fetureRef.Reverse).Select(e => e.Value.curve.LineString).ToArray());
            ////}

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
                        //if (origin.name.Equals("S2674391")) {
                        //    System.Diagnostics.Debugger.Break();
                        //    interceptor?.Invoke(interior);
                        //}
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

                //if (origin.name.Equals("C2672144")) System.Diagnostics.Debugger.Break();

                FeatureRef curveId = action(m.LineStrings, LinearRingOrientation.DontCare);

                this._mapping.GetOrAdd(m.Name, $"C{curveId.Id}");
            });



            this.CompositeCurves = [.. this.CompositeCurves, .. bagCompositeCurves.Values];
            this.Surfaces = [.. this.Surfaces, .. bagSurfaces];

            this.Curves = [.. this._hashing.Select(e => e.Value).DistinctBy(e => e.fetureRef.Id).Select(e => e.curve)];

            interceptor?.Invoke(curves.Select(e => e.LineString).ToArray());

            //if (this.Curves.Count(e => string.Join(",", e.LineString.Coordinates.Select(e => string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0.0000000},{1:0.0000000}", e.X, e.Y))).Equals("12.6800700,55.6103400,12.6805700,55.6102700,12.6809422,55.6102650,12.6813100,55.6102600"))>1)
            //    System.Diagnostics.Debugger.Break();
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
#endif
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

