using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ICSharpCode.SharpZipLib.Zip;
using S100Framework.DomainModel.S131.FeatureTypes;
using S100Framework.DomainModel.S201.FeatureTypes;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Xunit.Abstractions;

namespace TestS100Framework
{
    public class UnitTestGMLReader
    {
        private readonly ITestOutputHelper _output;

        public UnitTestGMLReader(ITestOutputHelper output) {
            this._output = output;

            ArcGIS.Core.Hosting.Host.Initialize();
        }
        [Fact]
        public void Test_SetupDatabase() {
            FastZip fastZip = new();

            var output = new DirectoryInfo("s100ed6.gdb");

            if (output.Exists)
                output.Delete(true);

            fastZip.ExtractZip("s100ed6.gdb.zip", output.FullName, null);

            using Geodatabase geodatabase = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(output.FullName)));


            System.Diagnostics.Debugger.Break();
        }

        //[Fact]
        //public void Test_ReadGML() {
        //    var S201 = @".\Samples\S201\201CAtestgml_Inline.gml";
        //    var S131 = @".\Samples\S131\131DK00_DKAAL.GML";

        //    var dataset = S100Framework.GML.Dataset.Load(S131);

        //    foreach (var m in dataset.Members()) {
        //        if (m is S100Framework.GML.Dataset.InformationType informationType) {
        //            var element = informationType.XElement;
        //            var value = informationType.Value;
        //        }
        //        if (m is S100Framework.GML.Dataset.FeatureType featureType) {
        //            var element = featureType.XElement;
        //            var value = featureType.Value;
        //            var geometry = featureType.Shape();
        //        }
        //    }

        //    System.Diagnostics.Debugger.Break();
        //}

        [Fact]
        public void Test_S131Reader() {
            //var types = Assembly.GetExecutingAssembly().GetTypes();

            //Assert.NotNull(types.SingleOrDefault(e => e.Name.Equals("MooringWarpingFacility")));

            var mooringWarpingFacility = new MooringWarpingFacility {
                iDCode = string.Empty,
                categoryOfMooringWarpingFacility = S100Framework.DomainModel.S131.categoryOfMooringWarpingFacility.Dolphin,
            };

            var gml = XDocument.Load(@".\Samples\S131\131DK00_DKAAL.GML");

            var members = gml.XPathSelectElement("//*[local-name()='members']");
            Assert.NotNull(members);

            foreach (var member in gml.Features()) {
                //var featureType = member.FeatureType();

                var geometry = member.Geometry();
            }

            System.Diagnostics.Debugger.Break();
        }
    }

    public static class S100
    {
        public static IEnumerable<XElement> Features(this XDocument doc) {
            var members = doc.XPathSelectElement("//*[local-name()='members']");
            if (members is null)
                yield break;
            var prefix = members.GetPrefixOfNamespace(members.Name.NamespaceName);
            foreach (var member in members.Elements()) {
                yield return member;
            }
            yield break;
        }

        public static Geometry? Geometry(this XElement element) {
            var prefix = element.GetPrefixOfNamespace(element.Name.NamespaceName)!;
            var ns = element.GetNamespaceOfPrefix(prefix)!;
            
            var geometry = element.Element(XName.Get("geometry", ns.NamespaceName))!;

            if (geometry == null) return null; // No geometry detected
            var property = (XElement)geometry.LastNode!;

            using var reader = geometry.CreateReader();

            switch (property.Name.LocalName?.ToLowerInvariant()) {
                case "pointproperty": {
                        var srsName = string.Empty;

                        while (reader.Read()) {
                            if (reader.NodeType == System.Xml.XmlNodeType.Element) {
                                //  s100
                                if (reader.IsStartElement("S100:Point")) {
                                    srsName = reader.GetAttribute("srsName");
                                }

                                //  gml
                                if (reader.IsStartElement("gml:coord")) {
                                    var coords = reader.ReadElementContentAsString().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                    break;
                                }
                                else if (reader.IsStartElement("gml:pos")) {
                                    var coords = reader.ReadElementContentAsString().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                                    var spatialreference = SpatialReferenceBuilder.CreateSpatialReference(int.Parse(srsName.Split('/', StringSplitOptions.RemoveEmptyEntries).Last()));

                                    var p = coords.Length switch {
                                        2 => MapPointBuilderEx.CreateMapPoint(double.Parse(coords[1], CultureInfo.InvariantCulture), double.Parse(coords[0], CultureInfo.InvariantCulture), spatialreference),
                                        3 => MapPointBuilderEx.CreateMapPoint(double.Parse(coords[1], CultureInfo.InvariantCulture), double.Parse(coords[0], CultureInfo.InvariantCulture), double.Parse(coords[2], CultureInfo.InvariantCulture), spatialreference),
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

                case "surfaceproperty": {
                        var srsName = string.Empty;

                        Polyline exterior = null;
                        List<Polyline> interior = new List<Polyline>();

                        while (reader.Read()) {
                            if (reader.NodeType == System.Xml.XmlNodeType.Element) {
                                //  s100
                                if (reader.IsStartElement("S100:Surface")) {
                                    srsName = reader.GetAttribute("srsName");
                                }

                                //  gml
                                if (reader.IsStartElement("gml:exterior")) {
                                    var spatialreference = SpatialReferenceBuilder.CreateSpatialReference(int.Parse(srsName.Split('/', StringSplitOptions.RemoveEmptyEntries).Last()));

                                    exterior = ReadLinearRing(reader, spatialreference);
                                }
                                else if (reader.IsStartElement("gml:interior")) {
                                    var spatialreference = SpatialReferenceBuilder.CreateSpatialReference(int.Parse(srsName.Split('/', StringSplitOptions.RemoveEmptyEntries).Last()));

                                    var ring = ReadLinearRing(reader, spatialreference);
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
                            var p = MapPointBuilderEx.CreateMapPoint(double.Parse(coords[i + 1], CultureInfo.InvariantCulture), double.Parse(coords[i + 0], CultureInfo.InvariantCulture), spatialReference);
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
