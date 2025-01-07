using ArcGIS.Core.Geometry;
using System.Collections.Concurrent;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;

namespace S100Framework.ArcGIS.Core
{
    public static class Extension
    {
        private static ConcurrentDictionary<int, SpatialReference> _spatialReferences = new();

        public static Geometry? Shape(this S100Framework.GML.Dataset.FeatureType element) {
            var geometry = element.Geometry;
            if (geometry is null)
                return null;

            var property = (XElement)geometry.LastNode!;

            using var reader = geometry.CreateReader();

            switch (property.Name.LocalName?.ToLowerInvariant()) {
                case "pointproperty": {
                        SpatialReference? spatialReference = default;

                        while (reader.Read()) {
                            if (reader.NodeType == System.Xml.XmlNodeType.Element) {
                                //  s100
                                if (reader.IsStartElement("S100:Point")) {
                                    var srsName = reader.GetAttribute("srsName");
                                    var wkid = string.IsNullOrEmpty(srsName) ? 4326 : int.Parse(srsName.Split('/', StringSplitOptions.RemoveEmptyEntries).Last());
                                    spatialReference = _spatialReferences.GetOrAdd(wkid, (e) => {
                                        return SpatialReferenceBuilder.CreateSpatialReference(e);
                                    });
                                }

                                //  gml
                                if (reader.IsStartElement("gml:coord")) {
                                    var coords = reader.ReadElementContentAsString().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                    break;
                                }
                                else if (reader.IsStartElement("gml:pos")) {
                                    var coords = reader.ReadElementContentAsString().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                                    var p = coords.Length switch {
                                        2 => MapPointBuilderEx.CreateMapPoint(
                                                double.Parse(coords[1], CultureInfo.InvariantCulture),
                                                double.Parse(coords[0], CultureInfo.InvariantCulture),
                                                spatialReference),
                                        3 => MapPointBuilderEx.CreateMapPoint(
                                                double.Parse(coords[1], CultureInfo.InvariantCulture),
                                                double.Parse(coords[0], CultureInfo.InvariantCulture),
                                                double.Parse(coords[2], CultureInfo.InvariantCulture),
                                                spatialReference),
                                        _ => throw new InvalidOperationException(),
                                    };
                                    return p;
                                }
                                else if (reader.IsStartElement("gml:coordinates")) {
                                    var coords = reader.ReadElementContentAsString().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                    break;
                                }
                            }
                        }
                    }
                    break;

                case "curveproperty": {
                        SpatialReference? spatialReference = default;

                        List<Polyline> segments = new List<Polyline>();

                        while (reader.Read()) {
                            if (reader.NodeType == System.Xml.XmlNodeType.Element) {
                                //  s100
                                if (reader.IsStartElement("S100:Curve")) {
                                    var srsName = reader.GetAttribute("srsName");
                                    var wkid = string.IsNullOrEmpty(srsName) ? 4326 : int.Parse(srsName.Split('/', StringSplitOptions.RemoveEmptyEntries).Last());
                                    spatialReference = _spatialReferences.GetOrAdd(wkid, (e) => {
                                        return SpatialReferenceBuilder.CreateSpatialReference(e);
                                    });
                                }

                                //  gml
                                if (reader.IsStartElement("gml:segments")) {
                                    var ring = ReadLinearRing(reader, spatialReference!);
                                    segments.Add(ring);
                                }
                            }
                        }
                        return PolylineBuilderEx.CreatePolyline(segments);
                    }

                case "surfaceproperty": {
                        SpatialReference? spatialReference = default;

                        Polyline? exterior = default;
                        List<Polyline> interior = new List<Polyline>();

                        while (reader.Read()) {
                            if (reader.NodeType == System.Xml.XmlNodeType.Element) {
                                //  s100
                                if (reader.IsStartElement("S100:Surface")) {
                                    var srsName = reader.GetAttribute("srsName");
                                    var wkid = string.IsNullOrEmpty(srsName) ? 4326 : int.Parse(srsName.Split('/', StringSplitOptions.RemoveEmptyEntries).Last());
                                    spatialReference = _spatialReferences.GetOrAdd(wkid, (e) => {
                                        return SpatialReferenceBuilder.CreateSpatialReference(e);
                                    });
                                }

                                //  gml
                                if (reader.IsStartElement("gml:exterior")) {
                                    exterior = ReadLinearRing(reader, spatialReference!);
                                }
                                else if (reader.IsStartElement("gml:interior")) {
                                    var ring = ReadLinearRing(reader, spatialReference!);
                                    interior.Add(ring);
                                }
                            }
                        }

                        if (interior.Any())
                            ;
                        return PolygonBuilderEx.CreatePolygon(exterior);
                    }
            }
            throw new NotImplementedException();
        }

        private static Polyline ReadLinearRing(XmlReader reader, SpatialReference spatialReference) {
            while (reader.Read()) {
                if (reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (reader.IsStartElement("gml:posList")) {
                        var coords = reader.ReadElementContentAsString().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        var points = new MapPoint[coords.Length / 2];
                        for (int i = 0; i < coords.Length; i += 2) {
                            var p = MapPointBuilderEx.CreateMapPoint(
                                double.Parse(coords[i + 1], CultureInfo.InvariantCulture),
                                double.Parse(coords[i + 0], CultureInfo.InvariantCulture),
                                spatialReference);
                            points[i / 2] = p;
                        }
                        return PolylineBuilderEx.CreatePolyline(points, spatialReference);
                    }
                }
            }
            throw new NotImplementedException();
        }
    }
}
