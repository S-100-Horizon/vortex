using Microsoft.XmlDiffPatch;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Xunit.Abstractions;
using IO = System.IO;

namespace TestS100Framework.Roslyn
{
    public class UnitTestFeatureCatalogue
    {
        public string Path(string ps) => System.IO.Path.GetFullPath(System.IO.Path.Combine(@".\..\..\..\..\..\..\..\artifacts\Product Specifications", ps));

        private readonly ITestOutputHelper _output;

        public UnitTestFeatureCatalogue(ITestOutputHelper output) {
            this._output = output;
        }

        [Fact]
        public void Export_S125() {
            var s100 = XDocument.Load(this.Path(@"S-125 Marine Aids to Navigation\1.0.0\4. S-125 Feature Catalogue - Annex C.1 (XML).xml"));

            Export(s100, "S125");
        }

        [Fact]
        public void Export_S201() {
            var s100 = XDocument.Load(this.Path(@"S-201 Aids to Navigation Information\2.0.0\6. S-201 Feature Catalogue - Annex C2.xml"));

            Export(s100, "S201");
        }

        [Fact]
        public void Diff_201_vs_125() {
            var diff = new XmlDiffView();
            //diff.SideBySideHtmlHeader("S-201","S-125", false)

            var source = this.Path(@"S-201 Aids to Navigation Information\2.0.0\6. S-201 Feature Catalogue - Annex C2.xml");
            var compare = this.Path(@"S-125 Marine Aids to Navigation\1.0.0\4. S-125 Feature Catalogue - Annex C.1 (XML).xml");

            IO.File.Copy(source, IO.Path.Combine(IO.Path.GetPathRoot(source)!, "S-201.xml"), true);
            IO.File.Copy(compare, IO.Path.Combine(IO.Path.GetPathRoot(source)!, "S-125.xml"), true);

            var html = diff.DifferencesSideBySideAsHtml(
                IO.Path.Combine(IO.Path.GetPathRoot(source)!, "S-201.xml"),
                IO.Path.Combine(IO.Path.GetPathRoot(source)!, "S-125.xml"),
                false,
                XmlDiffOptions.IgnoreChildOrder | XmlDiffOptions.IgnoreWhitespace,
                true);

            IO.File.WriteAllText(@"c:\temp\s100\diff.html", html.ReadToEnd());
        }


        private void Export(XDocument xDocument, string name) {
            var output = @$"c:\temp\s100\{name}";

            if (IO.Directory.Exists(output))
                IO.Directory.Delete(output, true);
            IO.Directory.CreateDirectory(output);

            var navigator = xDocument.CreateNavigator();
            navigator.MoveToFollowing(XPathNodeType.Element);
            var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var e in scopes)
                xmlNamespaceManager.AddNamespace(e.Key, e.Value);

            var scope_S100 = scopes["S100FC"];

            //foreach(var e in xDocument.XPathSelectElements("//S100FC:S100_FC_ComplexAttribute", xmlNamespaceManager)) {
            //    var code = e.Element(XName.Get("code", scope_S100))!.Value;

            //    IO.File.WriteAllText(IO.Path.Combine(output, $"{code}.xml"), e.ToString());
            //}

            //foreach (var e in xDocument.XPathSelectElements("//S100FC:S100_FC_InformationAssociation", xmlNamespaceManager)) {
            //    var code = e.Element(XName.Get("code", scope_S100))!.Value;

            //    IO.File.WriteAllText(IO.Path.Combine(output, $"{code}.xml"), e.ToString());
            //}

            //foreach (var e in xDocument.XPathSelectElements("//S100FC:S100_FC_FeatureAssociation", xmlNamespaceManager)) {
            //    var code = e.Element(XName.Get("code", scope_S100))!.Value;

            //    IO.File.WriteAllText(IO.Path.Combine(output, $"{code}.xml"), e.ToString());
            //}

            foreach (var e in xDocument.XPathSelectElements("//S100FC:S100_FC_InformationType", xmlNamespaceManager)) {
                var code = e.Element(XName.Get("code", scope_S100))!.Value;

                IO.File.WriteAllText(IO.Path.Combine(output, $"{code}.xml"), e.ToString());
            }

            foreach (var e in xDocument.XPathSelectElements("//S100FC:S100_FC_FeatureType", xmlNamespaceManager)) {
                var code = e.Element(XName.Get("code", scope_S100))!.Value;

                XElement root = e;

                var sortedItems = root.Elements(XName.Get("attributeBinding", scope_S100))
                            .OrderBy(item => item.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value)
                            .ToList();

                root.Elements(XName.Get("attributeBinding", scope_S100)).Remove();
                root.Add(sortedItems);

                IO.File.WriteAllText(IO.Path.Combine(output, $"{code}.xml"), root.ToString());
            }
        }
    }
}
