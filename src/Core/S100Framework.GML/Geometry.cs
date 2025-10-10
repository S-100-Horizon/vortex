using System.Text;
using System.Xml;
using System.Xml.Linq;
namespace S100Framework.GML
{
    public static class Extensions
    {
        private static readonly XNamespace xlinkNs = "http://www.w3.org/1999/xlink";
        private static readonly XNamespace gmlNs = "http://www.opengis.net/gml/3.2";
        private static readonly XNamespace s100Ns = "http://www.iho.int/s100gml/5.0";

        public static string[][]? Coordinates(this S100Framework.GML.Dataset.FeatureType element) {
            var geometry = element.Geometry;

            if (geometry == null)
                return default;

            var property = geometry.Elements().First();

            var coordinates = new List<string[]>();

            using var reader = geometry.CreateReader();

            switch (property.Name.LocalName.ToLowerInvariant()) {
                case "pointproperty": {
                        string[] coordinate = [];

                        while (reader.Read()) {
                            if (reader.NodeType == System.Xml.XmlNodeType.Element) {
                                //  s100
                                if (reader.IsStartElement("Point", s100Ns.NamespaceName)) {
                                    element.GeometryIdentifier = reader.GetAttribute("id", gmlNs.NamespaceName);
                                }

                                //  gml
                                if (reader.IsStartElement("coord", gmlNs.NamespaceName)) {
                                    var content = reader.ReadElementContentAsString().Replace('\n', ' ').Replace('\t', ' ');
                                    coordinate = content.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                    break;
                                }
                                else if (reader.IsStartElement("pos", gmlNs.NamespaceName)) {
                                    var content = reader.ReadElementContentAsString().Replace('\n', ' ').Replace('\t', ' ');
                                    coordinate = content.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                }
                                else if (reader.IsStartElement("coordinates", gmlNs.NamespaceName)) {
                                    var content = reader.ReadElementContentAsString().Replace('\n', ' ').Replace('\t', ' ');
                                    coordinate = content.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                }
                            }
                        }
                        coordinates.Add(coordinate);
                    }
                    break;


                case "curveproperty": {
                        var segments = new List<string[]>();

                        while (reader.Read()) {
                            if (reader.NodeType == System.Xml.XmlNodeType.Element) {
                                //  s100
                                if (reader.IsStartElement("Curve", s100Ns.NamespaceName)) {
                                    element.GeometryIdentifier = reader.GetAttribute("id", gmlNs.NamespaceName);
                                }

                                //  gml
                                if (reader.IsStartElement("posList", gmlNs.NamespaceName)) {
                                    var segment = reader.ReadElementContentAsString().Replace('\n', ' ').Replace('\t', ' ').Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                    segments.Add(segment);
                                }
                            }
                        }

                        coordinates = [.. segments];
                    }
                    break;

                case "surfaceproperty": {
                        string[] exterior = [];
                        var interior = new List<string[]>();

                        while (reader.Read()) {
                            if (reader.NodeType == System.Xml.XmlNodeType.Element) {
                                //  s100
                                if (reader.IsStartElement("Surface", s100Ns.NamespaceName) || reader.IsStartElement("Polygon", s100Ns.NamespaceName)) {
                                    var srsName = reader.GetAttribute("srsName");

                                    element.GeometryIdentifier = reader.GetAttribute("id", gmlNs.NamespaceName);
                                }

                                //  gml
                                if (reader.IsStartElement("exterior", gmlNs.NamespaceName)) {
                                    var ring = ReadLinearRing(reader);
                                    exterior = ring;
                                }
                                else if (reader.IsStartElement("interior", gmlNs.NamespaceName)) {
                                    var ring = ReadLinearRing(reader);
                                    interior.Add(ring);
                                }
                                else if (property.Attribute(xlinkNs + "href") != null) {
                                    var referenceId = property.Attribute(xlinkNs + "href")?.Value.Replace("#", "");

                                    element.GeometryIdentifier = referenceId;
                                }
                            }
                        }

                        // Null geometry..
                        if (exterior == null)
                            return default;

                        // Populate exterior ring
                        coordinates.Add(exterior);

                        // Populate interior rings
                        foreach (var ring in interior) {
                            coordinates.Add(ring);
                        }
                    }
                    break;
                default: {
                        throw new InvalidOperationException();
                    }
            }
            return [.. coordinates];
        }


        private static string[] ReadLinearRing(XmlReader reader) {
            string[] coords = [];
            while (reader.Read()) {
                if (reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (reader.IsStartElement("posList", gmlNs.NamespaceName)) {
                        coords = reader.ReadElementContentAsString().Replace('\n', ' ').Replace('\t', ' ').Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    }
                }
            }
            return coords;
        }
    }
}


namespace NetTopologySuite.Geometries
{
    public static class Extension
    {
        private static readonly XNamespace gml = "http://www.opengis.net/gml/3.2";
        private static readonly XNamespace s100 = "http://www.iho.int/s100gml/5.0";
        //private static readonly XNamespace s128 = "http://www.iho.int/S128/gml";

        /// <summary>
        /// Creates a complete <S128:geometry> element from an NTS Polygon.
        /// </summary>
        public static XElement? ToGMLFeatureS100(this Polygon polygon, string gmlId, XmlQualifiedName ns, string srsName = "EPSG:4326") {
            if (polygon == null || polygon.IsEmpty) {
                return default;
            }

            // The core GML part is built first (same logic as before)
            var polygonPatch = new XElement(gml + "PolygonPatch",
                new XElement(gml + "exterior",
                    new XElement(gml + "LinearRing",
                        new XElement(gml + "posList", CoordinatesToPosList(polygon.ExteriorRing.Coordinates))
                    )
                )
            );

            // Add interior rings if they exist
            foreach (var interiorRing in polygon.InteriorRings) {
                polygonPatch.Add(
                    new XElement(gml + "interior",
                        new XElement(gml + "LinearRing",
                            new XElement(gml + "posList", CoordinatesToPosList(interiorRing.Coordinates))
                        )
                    )
                );
            }

            // 2. Assemble the final structure using the correct namespaces and prefixes.
            XNamespace s128 = XNamespace.Get(ns.Namespace);

            var root = new XElement(s128 + "root",
                                new XAttribute(XNamespace.Xmlns + "S128", s128),
                                new XAttribute("S100", s100),
                                new XAttribute("gml", gml),
                                new XElement(s128 + "geometry",
                                    new XElement(s100 + "surfaceProperty",
                                    new XElement(s100 + "Surface",
                                        new XAttribute(gml + "id", gmlId),
                                        new XAttribute("srsName", srsName),
                                        new XElement(gml + "patches",
                                            polygonPatch
                                        )
                                    ))));

            return root.Elements().First();
        }

        /// <summary>
        /// Helper function to convert an array of NTS Coordinates to a GML posList string.
        /// Format: "x1 y1 x2 y2 x3 y3..."
        /// </summary>
        private static string CoordinatesToPosList(Coordinate[] coordinates) {
            var sb = new StringBuilder();
            foreach (var coord in coordinates) {
                sb.Append($"{coord.Y} {coord.X} ");
            }
            return sb.ToString().Trim();
        }
    }
}
