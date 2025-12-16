using S100Framework.DomainModel.S128.ComplexAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Xunit.Abstractions;
using IO = System.IO;

namespace TestNIPWG
{
    public class UnitTest125
    {
        private readonly ITestOutputHelper _output;

        private string _iho;
        private string _iala;

        public UnitTest125(ITestOutputHelper output) {
            this._output = output;
            this._iho = Environment.GetEnvironmentVariable("GITHUB-IHO")!;
            this._iala = Environment.GetEnvironmentVariable("GITHUB-IALA")!;

            ArcGIS.Core.Hosting.Host.Initialize();
        }

        public string PathIHO(string ps) => System.IO.Path.GetFullPath(System.IO.Path.Combine(_iho, ps));
        public string PathIALA(string ps) => System.IO.Path.GetFullPath(System.IO.Path.Combine(_iala, ps));

        [Fact]
        public void ExportS125() {            

            var productSpecification = XDocument.Load(this.PathIHO(@"S-125-Product-Specification-Development\FC\S125FC.xml"));

            var builder = Build(productSpecification);

            _output.WriteLine(builder.ToString());

            IO.File.WriteAllText(@".\s-125.txt", builder.ToString());
        }

        [Fact]
        public void ExportS201() {
            var productSpecification = XDocument.Load(this.PathIALA(@"S-201 Aids to Navigation Information\FC\201_Feature_Catalogue_2.0.0.xml"));

            var builder = Build(productSpecification);

            _output.WriteLine(builder.ToString());

            IO.File.WriteAllText(@".\s-201.txt", builder.ToString());
        }

        private StringBuilder Build(XDocument productSpecification) {
            var navigator = productSpecification.CreateNavigator();
            navigator.MoveToFollowing(XPathNodeType.Element);
            var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            var scope_S100 = scopes["S100FC"];

            var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var e in scopes)
                xmlNamespaceManager.AddNamespace(e.Key, e.Value);

            var builder = new StringBuilder();

            {
                builder.AppendLine("--- S100FC:S100_FC_InformationType ------------------------------------");
                var notFinished = false;
                do {
                    notFinished = false;
                    var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationType", xmlNamespaceManager);


                    elements = elements
                        .OrderBy(e => (e.Attribute("isAbstract") is null || e.Attribute("isAbstract")!.Value.Equals("false", StringComparison.OrdinalIgnoreCase)) ? 10 : 1)
                        .ThenBy(e => e.Elements(XName.Get("superType", scope_S100)).FirstOrDefault() is null ? 10 : 1)
                        .ThenBy(e => e.Element(XName.Get("code", scope_S100))!.Value);

                    foreach (var element in elements) {
                        var name = element.Element(XName.Get("name", scope_S100))!.Value;
                        var code = element.Element(XName.Get("code", scope_S100))!.Value;

                        var prefix = "";
                        if (!(element.Attribute("isAbstract") is null || element.Attribute("isAbstract")!.Value.Equals("false", StringComparison.OrdinalIgnoreCase))) {
                            prefix = "abstract ";
                        }

                        var superType = element.Elements(XName.Get("superType", scope_S100)).FirstOrDefault();
                        if (superType != null) {
                            builder.AppendLine($"{prefix}{code} : {superType.Value!}");
                        }
                        else
                            builder.AppendLine($"{prefix}{code}");

                        if (!(element.Attribute("isAbstract") != default && bool.Parse(element.Attribute("isAbstract")!.Value))) {
                            Attributes(element, builder);
                        }
                    }
                } while (notFinished);
                builder.AppendLine();
            }

            {
                builder.AppendLine("--- S100FC:S100_FC_FeatureType ----------------------------------------");
                var notFinished = false;
                do {
                    notFinished = false;
                    var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureType", xmlNamespaceManager);

                    elements = elements
                        .OrderBy(e =>( e.Attribute("isAbstract") is null || e.Attribute("isAbstract")!.Value.Equals("false", StringComparison.OrdinalIgnoreCase)) ? 10 : 1)
                        .ThenBy(e => e.Elements(XName.Get("superType", scope_S100)).FirstOrDefault() is null ? 10 : 1)
                        .ThenBy(e => e.Element(XName.Get("code", scope_S100))!.Value);

                    foreach (var element in elements) {

                        var name = element.Element(XName.Get("name", scope_S100))!.Value;
                        var code = element.Element(XName.Get("code", scope_S100))!.Value;

                        var prefix = "";
                        if (!(element.Attribute("isAbstract") is null || element.Attribute("isAbstract")!.Value.Equals("false", StringComparison.OrdinalIgnoreCase))) {
                            prefix = "abstract ";
                        }

                            var superType = element.Elements(XName.Get("superType", scope_S100)).FirstOrDefault();
                        if (superType != null) {
                            builder.AppendLine($"{prefix}{code} : {superType.Value!}");
                        }
                        else
                            builder.AppendLine($"{prefix}{code}");

                        if (!(element.Attribute("isAbstract") != default && bool.Parse(element.Attribute("isAbstract")!.Value))) {
                            Attributes(element, builder);
                        }
                    }
                } while (notFinished);
                builder.AppendLine();
            }

            return builder;
        }

        private void Attributes(XElement element, StringBuilder builder) {
            var navigator = element.Parent!.CreateNavigator();
            navigator.MoveToFollowing(XPathNodeType.Element);
            var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            var scope_S100 = scopes["S100FC"];
            var superType = element.Elements(XName.Get("superType", scope_S100)).FirstOrDefault();
            if (superType != null) {
                Attributes(superType, builder);
            }

            var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var e in scopes)
                xmlNamespaceManager.AddNamespace(e.Key, e.Value);

            var elements = element.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager);
            elements = elements.OrderBy(e =>e.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!);
            foreach (var attributeBinding in elements) {
                var referenceCode = attributeBinding.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!;
                var permittedValues = attributeBinding.XPathSelectElement("S100FC:permittedValues", xmlNamespaceManager);
                var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                var _ = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                string upper = (_.Attribute(XName.Get("infinite")) != default && _.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? "infinite" : _.Value!;

                builder.AppendLine($"\t{referenceCode}, lower:{lower}, upper:{upper}");
            }
        }
    }
}
