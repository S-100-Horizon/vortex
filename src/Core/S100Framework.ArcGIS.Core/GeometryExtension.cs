using ArcGIS.Core.Data.UtilityNetwork;
using System.Collections.Concurrent;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace ArcGIS.Core.Geometry
{
    public static class GeometryExtension
    {
        private static ConcurrentDictionary<int, SpatialReference> _spatialReferences = new();

        private static XNamespace xlink = "http://www.w3.org/1999/xlink";

        public static (ArcGIS.Core.Geometry.GeometryType?, Geometry?) Shape(this S100Framework.GML.Dataset.FeatureType element, Dictionary<string, Geometry> lookupDict) {
            var geometry = element.Geometry;
            if (geometry is null)
                return (null, null);

            var property = geometry.Elements().First();


            var id = "";

            GeometryType type;

            using var reader = geometry.CreateReader();

            switch (property.Name.LocalName?.ToLowerInvariant()) {
                case "pointproperty": {
                        SpatialReference? spatialReference = default;
                        id = property.Attribute(XName.Get("id", property.GetNamespaceOfPrefix("gml")!.NamespaceName))?.Value;
                        type = GeometryType.Point;
                        while (reader.Read()) {
                            if (reader.NodeType == System.Xml.XmlNodeType.Element) {
                                //  s100
                                if (reader.IsStartElement("S100:Point")) {
                                    var srsName = reader.GetAttribute("srsName");
                                    id = reader.GetAttribute("gml:id");

                                    var wkid = ReadWKID(srsName);

                                    //var wkid = string.IsNullOrEmpty(srsName) ? 4326 : int.Parse(srsName.Split('/', StringSplitOptions.RemoveEmptyEntries).Last());
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
                                    return (type, p);
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

                        var segments = new List<Polyline>();
                        type = GeometryType.Polyline;
                        while (reader.Read()) {
                            if (reader.NodeType == System.Xml.XmlNodeType.Element) {
                                //  s100
                                if (reader.IsStartElement("S100:Curve")) {
                                    var srsName = reader.GetAttribute("srsName");

                                    var wkid = ReadWKID(srsName);

                                    id = reader.GetAttribute("gml:id");

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
                        return (type, PolylineBuilderEx.CreatePolyline(segments));
                    }

                case "surfaceproperty": {
                        SpatialReference? spatialReference = default;

                        Polyline? exterior = default;
                        var interior = new List<Polyline>();
                        type = GeometryType.Polygon;
                        while (reader.Read()) {
                            if (reader.NodeType == System.Xml.XmlNodeType.Element) {
                                //  s100
                                if (reader.IsStartElement("S100:Surface") || reader.IsStartElement("S100:Polygon")) {
                                    var srsName = reader.GetAttribute("srsName");

                                    var wkid = ReadWKID(srsName);

                                    id = reader.GetAttribute("gml:id");

                                    //var wkid = string.IsNullOrEmpty(srsName) ? 4326 : int.Parse(srsName.Split('/', StringSplitOptions.RemoveEmptyEntries).Last());
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
                                else if (property.Attribute(xlink + "href") != null) {
                                  
                                    var referenceId = property.Attribute(xlink + "href")?.Value.Replace("#", "");
                                    var gmt = lookupDict[referenceId];

                                    return (type, gmt);
                                }
                            }
                        }

                        // Null geometry..
                        if (exterior == null)
                            return (type, null);

                        // Populate exterior ring
                        var polygonBuilder = new PolygonBuilderEx(exterior);

                        // Populate interior rings
                        foreach (var ring in interior) {
                            var segments = ring.Parts.First();
                            polygonBuilder.AddPart(segments);
                        }

                        var geometryRes = polygonBuilder.ToGeometry();

                        if (!string.IsNullOrEmpty(id))
                            lookupDict.Add(id, geometryRes);

                        return (type, geometryRes);
                    }
                default: {
                        throw new InvalidOperationException();
                    }
            }
            return (type, null);
        }

        private static Polyline ReadLinearRing(XmlReader reader, SpatialReference spatialReference) {
            while (reader.Read()) {
                if (reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (reader.IsStartElement("gml:posList")) {
                        var content = reader.ReadElementContentAsString();

                        var coords = content.Replace('\n', ' ').Replace('\t', ' ').Split(' ', StringSplitOptions.RemoveEmptyEntries);

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

        private static int ReadWKID(string? srsName) {
            //var slash = srsName?
            //   .Split('/', StringSplitOptions.RemoveEmptyEntries)
            //   .LastOrDefault();

            //var wkid = int.TryParse(
            //    slash ?? srsName?
            //        .Split(':', StringSplitOptions.RemoveEmptyEntries)
            //        .LastOrDefault(),
            //    out var parsed
            //) ? parsed : 4326;

            //return wkid;

            return 4326;
        }
    }
}