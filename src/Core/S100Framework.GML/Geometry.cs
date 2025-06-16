using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace NetTopologySuite.Geometries
{
    public static class Extension
    {
        private static readonly XNamespace gml = "http://www.opengis.net/gml/3.2";
        private static readonly XNamespace s100 = "http://www.iho.int/S100/gml";
        private static readonly XNamespace s128 = "http://www.iho.int/S128/gml";

        /// <summary>
        /// Creates a complete <S128:geometry> element from an NTS Polygon.
        /// </summary>
        public static string ToGMLFeatureS100(this Polygon polygon, string gmlId, XmlQualifiedName ns, string srsName = "http://www.opengis.net/def/crs/EPSG/0/4326") {
            if (polygon == null || polygon.IsEmpty) {
                return string.Empty;
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
            var s128Geometry = new XElement(s128 + "geometry",
                new XAttribute(XNamespace.Xmlns + ns.Name, ns.Namespace),
                new XAttribute(XNamespace.Xmlns + "S100", s100.NamespaceName),
                new XAttribute(XNamespace.Xmlns + "gml", gml.NamespaceName),

                new XElement(s100 + "surfaceProperty",
                    new XElement(s100 + "Surface",
                        // 3. Add the namespaced attribute 'gml:id'
                        new XAttribute(gml + "id", gmlId),
                        new XAttribute("srsName", srsName),
                        new XElement(gml + "patches",
                            polygonPatch // <-- Insert the GML patch we built earlier
                        )
                    )
                )
            );

            return s128Geometry.ToString(SaveOptions.None);
        }

        /// <summary>
        /// Helper function to convert an array of NTS Coordinates to a GML posList string.
        /// Format: "x1 y1 x2 y2 x3 y3..."
        /// </summary>
        private static string CoordinatesToPosList(Coordinate[] coordinates) {
            var sb = new StringBuilder();
            foreach (var coord in coordinates) {
                sb.Append($"{coord.X} {coord.Y} ");
            }
            return sb.ToString().Trim();
        }
    }
}
