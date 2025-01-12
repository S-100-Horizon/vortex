#define prop
//#define propfull

using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Xunit.Abstractions;


namespace TestS100Framework
{
    public static class Information
    {
        public static Version Version => new("");
    }

    namespace Test
    {
        public class NullableTest
        {
            public int? Value { get; set; }
        }
    }



    //public class informationBinding<T>
    //{
    //    public Type? Association { get; set; }
    //    public Role? Role { get; set; }

    //    public Type? informationType { get; set; }
    //}

    //namespace TestS100Framework.Bindings
    //{
    //    using S100Framework.DomainModel.S131;
    //    using S100Framework.DomainModel.S131.Bindings.InformationAssociations;
    //    using S100Framework.DomainModel.S131.Bindings.Roles;
    //    using S100Framework.DomainModel.S131.ComplexAttributes;
    //    using S100Framework.DomainModel.S131.InformationTypes;


    //    public class AbstractRxNInformationAssociations {
    //        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
    //        public List<InclusionType<isApplicableTo>> isApplicableTo { get; set; } = [];

    //        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
    //        public List<RelatedOrganisation<theOrganisation>> theOrganisation { get; set; } = [];
    //    }

    //    public abstract class AbstractRxN : InformationType
    //    {
    //        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
    //        public categoryOfAuthority? categoryOfAuthority { get; set; } = default;

    //        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
    //        public List<rxNCode> rxNCode { get; set; } = [];

    //        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
    //        public List<textContent> textContent { get; set; } = [];

    //        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
    //        public List<InclusionType<isApplicableTo>> isApplicableTo { get; set; } = [];

    //        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S131/1.0")]
    //        public List<RelatedOrganisation<theOrganisation>> theOrganisation { get; set; } = [];

    //        public AbstractRxNInformationAssociations InformationAssociations { get; set; } = new();

    //        public AbstractRxN() {
    //        }
    //    }
    //}

    namespace TestS100Framework
    {
        public class UnitTestCodeBuilder
        {
            private readonly ITestOutputHelper _output;

            public UnitTestCodeBuilder(ITestOutputHelper output) {
                this._output = output;
            }

            [Fact]
            public void Test_CreateClass() {
                var type1 = typeof(Test.NullableTest);
                var type2 = typeof(bool?);

                var s100 = XDocument.Load(@"..\..\..\..\..\..\artifacts\S-101 Electronic Navigational Chart (ENC)\S-101_FC_1.2.3.xml");

                var content = S100Framework.ClassBuilder.CatalogueBuilder52(s100);

                File.WriteAllText(@"c:\temp\content.cs", content.fc, Encoding.UTF8);
            }

            [Fact]
            public void Test_Bindings() {
            }

            [Fact]
            public void Build_KnownFeatureCataloguesLocal() {
                Build_S101();

                Build_S122();

                Build_S124();

                Build_S128();

                Build_S131();

                //Build_S201();
            }

            [Fact]
            public void Build_KnownFeatureCatalogues() {
                Build_S101();
                File.WriteAllText(@"..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-101_FC.g.cs", File.ReadAllText(@".\..\..\..\S-101_FC.cs"));
                File.WriteAllText(@"..\..\..\..\..\..\src\UI\S100Framework.WPF\S-101_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\S-101_ViewModel.cs"));

                Build_S122();
                File.WriteAllText(@"..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-122_FC.g.cs", File.ReadAllText(@".\..\..\..\S-122_FC.cs"));
                File.WriteAllText(@"..\..\..\..\..\..\src\UI\S100Framework.WPF\S-122_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\S-122_ViewModel.cs"));

                Build_S124();
                File.WriteAllText(@"..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-124_FC.g.cs", File.ReadAllText(@".\..\..\..\S-124_FC.cs"));
                File.WriteAllText(@"..\..\..\..\..\..\src\UI\S100Framework.WPF\S-124_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\S-124_ViewModel.cs"));

                Build_S128();
                File.WriteAllText(@"..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-128_FC.g.cs", File.ReadAllText(@".\..\..\..\S-128_FC.cs"));
                File.WriteAllText(@"..\..\..\..\..\..\src\UI\S100Framework.WPF\S-128_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\S-128_ViewModel.cs"));

                Build_S131();
                File.WriteAllText(@"..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-131_FC.g.cs", File.ReadAllText(@".\..\..\..\S-131_FC.cs"));
                File.WriteAllText(@"..\..\..\..\..\..\src\UI\S100Framework.WPF\S-131_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\S-131_ViewModel.cs"));

                //Build_S201();
                //File.WriteAllText(@"..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-201_FC.g.cs", File.ReadAllText(@".\..\..\..\S-201_FC.cs"));
                //File.WriteAllText(@"..\..\..\..\..\..\src\UI\S100Framework.WPF\S-201_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\S-201_ViewModel.cs"));

                File.WriteAllText(@"..\..\..\..\..\..\src\Core\S100Framework.Catalogues\DomainModelBase.cs", File.ReadAllText(@".\..\..\..\DomainModelBase.cs"));
            }

            [Fact]
            public void Build_S101() {
                var type1 = typeof(Test.NullableTest);
                var type2 = typeof(bool?);

                var s100 = XDocument.Load(@".\Artifacts\S-101_FC_2.0.0.20241016.xml");

                var content = S100Framework.ClassBuilder.CatalogueBuilder52(s100);

                File.WriteAllText(@".\..\..\..\S-101_FC.cs", content.fc, Encoding.UTF8);
                File.WriteAllText(@".\..\..\..\S-101_ViewModel.cs", content.view, Encoding.UTF8);

                File.WriteAllText(@".\..\..\..\DomainModelBase.cs", content.common, Encoding.UTF8);
            }

            [Fact]
            public void Build_S122() {

                var s100 = XDocument.Load(@".\Artifacts\jpS-122_FC_1.2.1.xml");
                //var s100 = XDocument.Load(@".\Artifacts\S-122_FC_1.2.1.xml");                

                var content = S100Framework.ClassBuilder.CatalogueBuilder52(s100);

                File.WriteAllText(@".\..\..\..\S-122_FC.cs", content.fc, Encoding.UTF8);
                File.WriteAllText(@".\..\..\..\S-122_ViewModel.cs", content.view, Encoding.UTF8);

                File.WriteAllText(@".\..\..\..\DomainModelBase.cs", content.common, Encoding.UTF8);
            }

            [Fact]
            public void Build_S124() {
                var type1 = typeof(Test.NullableTest);
                var type2 = typeof(bool?);

                var v = RuntimeHelpers.GetUninitializedObject(typeof(DateTime));

                var s100 = XDocument.Load(@".\Artifacts\S-124FC_1.5_20240330.xml");

                var content = S100Framework.ClassBuilder.CatalogueBuilder52(s100);

                File.WriteAllText(@".\..\..\..\S-124_FC.cs", content.fc, Encoding.UTF8);
                File.WriteAllText(@".\..\..\..\S-124_ViewModel.cs", content.view, Encoding.UTF8);

                File.WriteAllText(@".\..\..\..\DomainModelBase.cs", content.common, Encoding.UTF8);
            }

            [Fact]
            public void Build_S128() {
                var type1 = typeof(Test.NullableTest);
                var type2 = typeof(bool?);

                var s100 = XDocument.Load(@".\Artifacts\S-128_FC_Ed2.0.0.xml");

                var content = S100Framework.ClassBuilder.CatalogueBuilder(s100, "http://www.iho.int/S128/2.0");

                File.WriteAllText(@".\..\..\..\S-128_FC.cs", content.fc, Encoding.UTF8);
                File.WriteAllText(@".\..\..\..\S-128_ViewModel.cs", content.view, Encoding.UTF8);

                File.WriteAllText(@".\..\..\..\DomainModelBase.cs", content.common, Encoding.UTF8);
            }

            [Fact]
            public void Build_S131() {
                var s100 = XDocument.Load(@".\Artifacts\131_1_0_0_20230315_FC.xml");

                var content = S100Framework.ClassBuilder.CatalogueBuilder(s100, "http://www.iho.int/S131/1.0");

                File.WriteAllText(@".\..\..\..\S-131_FC.cs", content.fc, Encoding.UTF8);
                File.WriteAllText(@".\..\..\..\S-131_ViewModel.cs", content.view, Encoding.UTF8);

                File.WriteAllText(@".\..\..\..\DomainModelBase.cs", content.common, Encoding.UTF8);
            }

            [Fact]
            public void Build_S201() {
                var s100 = XDocument.Load(@".\Artifacts\8. S-201 Ed 1.1.0_Annex D2_Feature Catalogue.xml");

                var content = S100Framework.ClassBuilder.CatalogueBuilder(s100, "http://www.iho.int/S201/1.0");

                File.WriteAllText(@".\..\..\..\S-201_FC.cs", content.fc, Encoding.UTF8);
                File.WriteAllText(@".\..\..\..\S-201_ViewModel.cs", content.view, Encoding.UTF8);

                File.WriteAllText(@".\..\..\..\DomainModelBase.cs", content.common, Encoding.UTF8);
            }

            [Fact]
            public void Test_FeatureBindings() {
                var productSpecification = XDocument.Load(@".\Artifacts\S-101_FC_2.0.0.20241016.xml");

                var navigator = productSpecification.CreateNavigator();
                navigator.MoveToFollowing(XPathNodeType.Element);
                var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

                var scope_S100 = scopes["S100FC"];

                var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
                foreach (var e in scopes)
                    xmlNamespaceManager.AddNamespace(e.Key, e.Value);

                var elements = productSpecification.XPathSelectElements("//S100FC:featureBinding", xmlNamespaceManager).ToList();

                var islandAggregation = elements.Where(e => e.Element(XName.Get("association", scope_S100))!.Attribute("ref")!.Value.Equals("IslandAggregation")).ToList();

                var theCollection = islandAggregation.Where(e => e.Element(XName.Get("role", scope_S100))!.Attribute("ref")!.Value.Equals("theCollection")).ToList();

                var theComponent = islandAggregation.Where(e => e.Element(XName.Get("role", scope_S100))!.Attribute("ref")!.Value.Equals("theComponent")).ToList();

                Assert.Equal(2, theCollection.Count());
                Assert.Single(theComponent);
                System.Diagnostics.Debugger.Break();
            }

            [Fact]
            public void Test_FeatureBindingEndpoints() {
                var productSpecifications = new string[] {
                    @".\Artifacts\S-101_FC_2.0.0.20241016.xml",
                    @".\Artifacts\jpS-122_FC_1.2.1.xml",
                    @".\Artifacts\S-124FC_1.5_20240330.xml",
                    @".\Artifacts\S-128_FC_Ed2.0.0.xml",
                    @".\Artifacts\131_1_0_0_20230315_FC.xml",
                };

                foreach (var p in productSpecifications) {
                    var endpoints = new List<featureBinding>();

                    var productSpecification = XDocument.Load(p);

                    var navigator = productSpecification.CreateNavigator();
                    navigator.MoveToFollowing(XPathNodeType.Element);
                    var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

                    var scope_S100 = scopes["S100FC"];

                    var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
                    foreach (var e in scopes)
                        xmlNamespaceManager.AddNamespace(e.Key, e.Value);

                    var elements = productSpecification.XPathSelectElements("//S100FC:featureBinding", xmlNamespaceManager).ToList();

                    foreach (var element in elements) {
                        var roleType = element.Attribute("roleType")!.Value;

                        var association = element.Element(XName.Get("association", scope_S100))!.Attribute("ref")!.Value;
                        var role = element.Element(XName.Get("role", scope_S100))!.Attribute("ref")!.Value;

                        var lower = int.Parse(element.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                        var upper = element.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;

                        var u = default(int?);
                        if (!(upper.Attribute(XName.Get("infinite")) != default && upper.Attribute(XName.Get("infinite"))!.Value.Equals("true"))) {
                            u = int.Parse(upper!.Value);
                        }

                        var binding = new featureBinding(roleType, lower, u, association, role);
                        endpoints.Add(binding);
                    }

                    var productId = productSpecification.XPathSelectElement("//S100FC:productId", xmlNamespaceManager)!.Value.Replace("-", string.Empty).ToUpperInvariant();

                    _output.WriteLine($"{productId}");

                    foreach (var endpoint in endpoints.GroupBy(e => e.association)) {
                        //_output.WriteLine($"{endpoint.Key}");
                        foreach (var role in endpoint.GroupBy(e => e.role)) {
                            //_output.WriteLine($"\t{role.Key}");

                            var lower = role.First().lower;
                            var upper = role.First().upper;

                            if (!role.All(e => e.lower == lower && e.upper == upper)) {
                                foreach (var d in role.Distinct()) {
                                    _output.WriteLine($"\t\t{endpoint.Key}: {d.roleType}, {d.role}, {d.lower}, {d.upper}");
                                }

                            }
                        }
                    }
                    _output.WriteLine("");
                }
            }

            public record featureBinding(string roleType, int lower, int? upper, string association, string role);
        }
    }
}

/*
    public enum S100_FC_RoleType {
        [System.Xml.Serialization.XmlEnum("association")]
        association,

        [System.Xml.Serialization.XmlEnum("aggregation")]
        aggregation,

        [System.Xml.Serialization.XmlEnum("composition")]
        composition
    }

    public class informationBinding {
        public S100_FC_RoleType roleType { get; set; }

    }
*/