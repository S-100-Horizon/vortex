#define prop
//#define propfull

using S100Framework.DomainModel;
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

    namespace Roslyn
    {
        public class UnitTestCodeBuilder
        {
            public string Path(string ps) => System.IO.Path.GetFullPath(System.IO.Path.Combine(@".\..\..\..\..\..\..\..\artifacts\Product Specifications", ps));

            static readonly string[] productSpecifications = new string[] {
                    @".\Artifacts\FeatureCatalogue.xml",
                    @".\Artifacts\jpS-122_FC_1.2.1.xml",
                    @".\Artifacts\S-124FC_1.5_20240330.xml",
                    @".\Artifacts\S-128_FC_Ed2.0.0.xml",
                    @".\Artifacts\131_1_0_0_20230315_FC.xml",
                };

            private readonly ITestOutputHelper _output;

            private readonly string _iho;
            private readonly string _iala;

            public UnitTestCodeBuilder(ITestOutputHelper output) {
                this._output = output;

                this._iho = Environment.GetEnvironmentVariable("GITHUB-IHO")!;
                this._iala = Environment.GetEnvironmentVariable("GITHUB-IALA")!;
            }

            [Fact]
            public void Test_Bindings() {
            }

            [Fact]
            public void Build_KnownFeatureCataloguesLocal() {
                this.Build_S101();

                this.Build_S122();

                this.Build_S123();

                this.Build_S124();

                //Build_S125();
                this.Build_S125_FIHO();

                this.Build_S127();

                this.Build_S128();

                this.Build_S131();

                this.Build_S201();

                //Build_S501();
            }

            [Fact]
            public void Build_KnownFeatureCatalogues() {
                this.Build_S101();
                File.WriteAllText(@"..\..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-101_FC.g.cs", File.ReadAllText(@".\..\..\..\..\S-101_FC.cs"));
                File.WriteAllText(@"..\..\..\..\..\..\..\src\UI\S100Framework.WPF\S-101_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\..\S-101_ViewModel.cs"));

                this.Build_S122();
                File.WriteAllText(@"..\..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-122_FC.g.cs", File.ReadAllText(@".\..\..\..\..\S-122_FC.cs"));
                File.WriteAllText(@"..\..\..\..\..\..\..\src\UI\S100Framework.WPF\S-122_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\..\S-122_ViewModel.cs"));

                this.Build_S123();
                File.WriteAllText(@"..\..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-123_FC.g.cs", File.ReadAllText(@".\..\..\..\..\S-123_FC.cs"));
                File.WriteAllText(@"..\..\..\..\..\..\..\src\UI\S100Framework.WPF\S-123_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\..\S-123_ViewModel.cs"));

                this.Build_S124();
                File.WriteAllText(@"..\..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-124_FC.g.cs", File.ReadAllText(@".\..\..\..\..\S-124_FC.cs"));
                File.WriteAllText(@"..\..\..\..\..\..\..\src\UI\S100Framework.WPF\S-124_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\..\S-124_ViewModel.cs"));

                this.Build_S125_FIHO();
                File.WriteAllText(@"..\..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-125_FC.g.cs", File.ReadAllText(@".\..\..\..\..\S-125_FC.cs"));
                File.WriteAllText(@"..\..\..\..\..\..\..\src\UI\S100Framework.WPF\S-125_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\..\S-125_ViewModel.cs"));

                this.Build_S127();
                File.WriteAllText(@"..\..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-127_FC.g.cs", File.ReadAllText(@".\..\..\..\..\S-127_FC.cs"));
                File.WriteAllText(@"..\..\..\..\..\..\..\src\UI\S100Framework.WPF\S-127_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\..\S-127_ViewModel.cs"));

                this.Build_S128();
                File.WriteAllText(@"..\..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-128_FC.g.cs", File.ReadAllText(@".\..\..\..\..\S-128_FC.cs"));
                File.WriteAllText(@"..\..\..\..\..\..\..\src\UI\S100Framework.WPF\S-128_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\..\S-128_ViewModel.cs"));

                this.Build_S131();
                File.WriteAllText(@"..\..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-131_FC.g.cs", File.ReadAllText(@".\..\..\..\..\S-131_FC.cs"));
                File.WriteAllText(@"..\..\..\..\..\..\..\src\UI\S100Framework.WPF\S-131_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\..\S-131_ViewModel.cs"));

                this.Build_S201();
                File.WriteAllText(@"..\..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-201_FC.g.cs", File.ReadAllText(@".\..\..\..\..\S-201_FC.cs"));
                File.WriteAllText(@"..\..\..\..\..\..\..\src\UI\S100Framework.WPF\S-201_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\..\S-201_ViewModel.cs"));

                //Build_S501();
                //File.WriteAllText(@"..\..\..\..\..\..\..\src\Core\S100Framework.Catalogues\S-501_FC.g.cs", File.ReadAllText(@".\..\..\..\..\S-501_FC.cs"));
                //File.WriteAllText(@"..\..\..\..\..\..\..\src\UI\S100Framework.WPF\S-501_ViewModel.g.cs", File.ReadAllText(@".\..\..\..\..\S-501_ViewModel.cs"));
            }


            [Fact]
            public void Validate() {
                string[] productSpecifications = [
                    @".\Artifacts\101_Feature_Catalogue_2.0.0.xml",
                    @".\Artifacts\jpS-122_FC_1.2.1.xml",
                    @".\Artifacts\S-124FC_1.5_20240330.xml",
                    @".\Artifacts\S-128_FC_Ed2.0.0.xml",
                    @".\Artifacts\131_1_0_0_20230315_FC - LOCAL.xml",
                ];

                foreach (var e in productSpecifications) {
                    this._output.WriteLine($"{System.IO.Path.GetFileName(e)}");
                    this._output.WriteLine("----------------------------------------------------------------------------------");
                    var s100 = XDocument.Load(e);
                    Assert.True(this.VerifyProductSpecification(s100));

                    this._output.WriteLine("");
                }
            }

            [Fact]
            public void Build_S101() {
                var type1 = typeof(Test.NullableTest);
                var type2 = typeof(bool?);

                var ps = System.IO.Path.Combine(this._iho, @"S-101-Documentation-and-FC\S-101FC\FeatureCatalogue.xml");
                var s100 = XDocument.Load(ps);

                Assert.True(this.VerifyProductSpecification(s100));

                var attributeRules = new S100Framework.Applications.Roslyn.AttributeRule[] {
                    new S100Framework.Applications.Roslyn.AttributeRule("Obstruction.defaultClearanceDepth","[DependentUnknownValue(\"valueOfSounding\")]"),
                    //new S100Framework.Applications.Roslyn.AttributeRule("Obstruction.defaultClearanceDepth","[DependsOn(\"valueOfSounding\")]"),

                    new S100Framework.Applications.Roslyn.AttributeRule("UnderwaterAwashRock.defaultClearanceDepth","[DependentUnknownValue(\"valueOfSounding\")]"),
                    //new S100Framework.Applications.Roslyn.AttributeRule("UnderwaterAwashRock.defaultClearanceDepthh","[DependsOn(\"valueOfSounding\")]"),

                    new S100Framework.Applications.Roslyn.AttributeRule("Wreck.defaultClearanceDepth","[DependentUnknownValue(\"valueOfSounding\")]"),
                    //new S100Framework.Applications.Roslyn.AttributeRule("Wreck.defaultClearanceDepth","[DependsOn(\"valueOfSounding\")]"),

                    new S100Framework.Applications.Roslyn.AttributeRule("rhythmOfLight.signalPeriod","[ConditionalUnknownDependency(\"rhythmOfLight.signalPeriod\")]"),

                    new S100Framework.Applications.Roslyn.AttributeRule("Bridge.categoryOfOpeningBridge","[ConditionalUnknownDependency(\"Bridge.categoryOfOpeningBridge\")]"),

                    new S100Framework.Applications.Roslyn.AttributeRule("Bridge.openingBridge","[ConditionalUnknownDependency(\"Bridge.openingBridge\")]"),

                    new S100Framework.Applications.Roslyn.AttributeRule("Obstruction.valueOfSounding","[DependentUnknownValue(\"height\")]"),
                    //new S100Framework.Applications.Roslyn.AttributeRule("Obstruction.valueOfSounding","[DependsOn(\"height\")]"),

                    new S100Framework.Applications.Roslyn.AttributeRule("MarineFarmCulture.valueOfSounding","[DependentUnknownValue(\"height\")]"),
                    //new S100Framework.Applications.Roslyn.AttributeRule("MarineFarmCulture.valueOfSounding","[DependsOn(\"height\")]"),

                    new S100Framework.Applications.Roslyn.AttributeRule("Wreck.categoryOfWreck","[DependentUnknownValue(\"valueOfSounding\")]"),
                    //new S100Framework.Applications.Roslyn.AttributeRule("Wreck.categoryOfWreck","[DependsOn(\"valueOfSounding\")]"),

                    new S100Framework.Applications.Roslyn.AttributeRule("surfaceCharacteristics.natureOfSurface","[ConditionalUnknownDependency(\"surfaceCharacteristics.natureOfSurface\")]"),
                };

                var dependencyRule = new S100Framework.Applications.Roslyn.DependencyRule[] {
                    new S100Framework.Applications.Roslyn.DependencyRule("Bridge", "Bridge.categoryOfOpeningBridge","(bridge) => bridge.openingBridge.HasValue && bridge.openingBridge.Value == true", typeof(ConditionalUnknownDependencyAttribute)),
                    new S100Framework.Applications.Roslyn.DependencyRule("Bridge", "Bridge.openingBridge","(bridge) => !bridge.openingBridge.HasValue", typeof(ConditionalUnknownDependencyAttribute)),
                    new S100Framework.Applications.Roslyn.DependencyRule("rhythmOfLight","rhythmOfLight.signalPeriod","(rhythmOfLight) => !rhythmOfLight.lightCharacteristic.HasValue || (rhythmOfLight.lightCharacteristic.HasValue && rhythmOfLight.lightCharacteristic.Value != (lightCharacteristic)1)", typeof(ConditionalUnknownDependencyAttribute)),
                    new S100Framework.Applications.Roslyn.DependencyRule("surfaceCharacteristics","surfaceCharacteristics.natureOfSurface","(surfaceCharacteristics) => surfaceCharacteristics.natureOfSurface is null && !surfaceCharacteristics.natureOfSurfaceQualifyingTerms.Any()", typeof(ConditionalUnknownDependencyAttribute)),
                };

                var validationChecks = new S100Framework.Applications.Roslyn.ValidationCheck[] {
                    new S100Framework.Applications.Roslyn.ValidationCheck("lightSector", "if (directionalCharacter is null && sectorLimit is null) directionalCharacter = new();"),
                    new S100Framework.Applications.Roslyn.ValidationCheck("CableOverhead", "if (verticalClearanceFixed is null && verticalClearanceSafe is null) verticalClearanceSafe = new();"),
                    new S100Framework.Applications.Roslyn.ValidationCheck("SeabedArea", "if (!surfaceCharacteristics.Any()) surfaceCharacteristics = [new()];"),
                    //new S100Framework.Applications.Roslyn.ValidationCheck("surfaceCharacteristics", "if (!natureOfSurfaceQualifyingTerms.Any() && natureOfSurface is null) natureOfSurfaceQualifyingTerms = [new()];"),
                };

                var content = S100Framework.Applications.Roslyn.Build(s100, S100Framework.Applications.Roslyn.ProductFormat.ISO8211, true, attributeRules, dependencyRule, validationChecks);

                //var content = S100Framework.ClassBuilder.CatalogueBuilder52(s100);

                File.WriteAllText(@".\..\..\..\..\S-101_FC.cs", content.DomainModel, Encoding.UTF8);
                File.WriteAllText(@".\..\..\..\..\S-101_ViewModel.cs", content.ViewModel, Encoding.UTF8);
            }

            [Fact]
            public void Build_S122() {
                var ps = System.IO.Path.Combine(this._iho, @"S-122-Product-Specification-Development\FC\122_FC_2.0.0.20251207.xml");
                var s100 = XDocument.Load(ps);

                Assert.True(this.VerifyProductSpecification(s100));

                var content = S100Framework.Applications.Roslyn.Build(s100, S100Framework.Applications.Roslyn.ProductFormat.GML);
                //var content = S100Framework.ClassBuilder.CatalogueBuilder52(s100);

                File.WriteAllText(@".\..\..\..\..\S-122_FC.cs", content.DomainModel, Encoding.UTF8);
                File.WriteAllText(@".\..\..\..\..\S-122_ViewModel.cs", content.ViewModel, Encoding.UTF8);
            }

            [Fact]
            public void Build_S123() {
                var type1 = typeof(Test.NullableTest);
                var type2 = typeof(bool?);

                var v = RuntimeHelpers.GetUninitializedObject(typeof(DateTime));

                var ps = System.IO.Path.Combine(this._iho, @"S-123-Product-Specification-Development\FC\S-123_FC_Ed.2.0.0_20251210.xml");
                var s100 = XDocument.Load(ps);

                //Assert.True(VerifyProductSpecification(s100));

                var content = S100Framework.Applications.Roslyn.Build(s100, S100Framework.Applications.Roslyn.ProductFormat.GML);
                //var content = S100Framework.ClassBuilder.CatalogueBuilder52(s100);

                File.WriteAllText(@".\..\..\..\..\S-123_FC.cs", content.DomainModel, Encoding.UTF8);
                File.WriteAllText(@".\..\..\..\..\S-123_ViewModel.cs", content.ViewModel, Encoding.UTF8);
            }

            [Fact]
            public void Build_S124() {
                var type1 = typeof(Test.NullableTest);
                var type2 = typeof(bool?);

                var v = RuntimeHelpers.GetUninitializedObject(typeof(DateTime));

                var ps = this.Path(@"S-124 Navigational Warnings\FC\124_FC_2.0.0.xml");
                var s100 = XDocument.Load(ps);

                Assert.True(this.VerifyProductSpecification(s100));

                var content = S100Framework.Applications.Roslyn.Build(s100, S100Framework.Applications.Roslyn.ProductFormat.GML);
                //var content = S100Framework.ClassBuilder.CatalogueBuilder52(s100);

                File.WriteAllText(@".\..\..\..\..\S-124_FC.cs", content.DomainModel, Encoding.UTF8);
                File.WriteAllText(@".\..\..\..\..\S-124_ViewModel.cs", content.ViewModel, Encoding.UTF8);
            }

            [Fact]
            public void Build_S125() {
                var type1 = typeof(Test.NullableTest);
                var type2 = typeof(bool?);

                var v = RuntimeHelpers.GetUninitializedObject(typeof(DateTime));

                var ps = System.IO.Path.Combine(this._iho, @"S-125-Product-Specification-Development\FC\S125FC.xml");
                var s100 = XDocument.Load(ps);

                //Assert.True(VerifyProductSpecification(s100));

                var content = S100Framework.Applications.Roslyn.Build(s100, S100Framework.Applications.Roslyn.ProductFormat.GML);

                File.WriteAllText(@".\..\..\..\..\S-125_FC.cs", content.DomainModel, Encoding.UTF8);
                File.WriteAllText(@".\..\..\..\..\S-125_ViewModel.cs", content.ViewModel, Encoding.UTF8);
            }

            [Fact]
            public void Build_S125_FIHO() {
                var type1 = typeof(Test.NullableTest);
                var type2 = typeof(bool?);

                var v = RuntimeHelpers.GetUninitializedObject(typeof(DateTime));

                var ps = System.IO.Path.Combine(this._iho, @"S-125-Product-Specification-Development\FC\S125FC_SE_FIX.xml");
                var s100 = XDocument.Load(ps);

                //Assert.True(VerifyProductSpecification(s100));

                var content = S100Framework.Applications.Roslyn.Build(s100, S100Framework.Applications.Roslyn.ProductFormat.GML);

                File.WriteAllText(@".\..\..\..\..\S-125_FC.cs", content.DomainModel, Encoding.UTF8);
                File.WriteAllText(@".\..\..\..\..\S-125_ViewModel.cs", content.ViewModel, Encoding.UTF8);
            }

            [Fact]
            public void Build_S125_GST() {
                var type1 = typeof(Test.NullableTest);
                var type2 = typeof(bool?);

                var v = RuntimeHelpers.GetUninitializedObject(typeof(DateTime));

                var s100 = XDocument.Load(this.Path(@"S-125 Marine Aids to Navigation\1.0.0_GST\S125FC - GST.xml"));

                //Assert.True(VerifyProductSpecification(s100));

                var content = S100Framework.Applications.Roslyn.Build(s100, S100Framework.Applications.Roslyn.ProductFormat.GML);

                File.WriteAllText(@".\..\..\..\..\S-125_FC.cs", content.DomainModel, Encoding.UTF8);
                //File.WriteAllText(@".\..\..\..\..\S-125_ViewModel.cs", content.ViewModel, Encoding.UTF8);
            }


            [Fact]
            public void Build_S127() {
                var type1 = typeof(Test.NullableTest);
                var type2 = typeof(bool?);

                var ps = System.IO.Path.Combine(this._iho, @"S-127-Product-Specification-Development\FC\127_FC_2.0.0.20251207.xml");
                var s100 = XDocument.Load(ps);

                //Assert.True(VerifyProductSpecification(s100));

                var content = S100Framework.Applications.Roslyn.Build(s100, S100Framework.Applications.Roslyn.ProductFormat.GML);
                //var content = S100Framework.ClassBuilder.CatalogueBuilder52(s100);

                File.WriteAllText(@".\..\..\..\..\S-127_FC.cs", content.DomainModel, Encoding.UTF8);
                File.WriteAllText(@".\..\..\..\..\S-127_ViewModel.cs", content.ViewModel, Encoding.UTF8);
            }

            [Fact]
            public void Build_S128() {
                var type1 = typeof(Test.NullableTest);
                var type2 = typeof(bool?);

                var ps = System.IO.Path.Combine(this._iho, @"S-128-Product-Specification-Development\FC\128_FC.xml");
                var s100 = XDocument.Load(ps);

                //Assert.True(VerifyProductSpecification(s100));

                var content = S100Framework.Applications.Roslyn.Build(s100, S100Framework.Applications.Roslyn.ProductFormat.GML);

                //var content = S100Framework.ClassBuilder.CatalogueBuilder(s100, "http://www.iho.int/S128/2.0");

                File.WriteAllText(@".\..\..\..\..\S-128_FC.cs", content.DomainModel, Encoding.UTF8);
                File.WriteAllText(@".\..\..\..\..\S-128_ViewModel.cs", content.ViewModel, Encoding.UTF8);
            }

            [Fact]
            public void Build_S131() {
                //var s100 = XDocument.Load(@".\Artifacts\131_1_0_0_20230315_FC - LOCAL.xml");

                var ps = System.IO.Path.Combine(this._iho, @"S-131-Product-Specification-Development\FC\131_FC_2.0.0.20251112.xml");
                var s100 = XDocument.Load(ps);

                //Assert.True(VerifyProductSpecification(s100));

                var content = S100Framework.Applications.Roslyn.Build(s100, S100Framework.Applications.Roslyn.ProductFormat.GML);

                //var content = S100Framework.ClassBuilder.CatalogueBuilder(s100, "http://www.iho.int/S131/1.0");

                File.WriteAllText(@".\..\..\..\..\S-131_FC.cs", content.DomainModel, Encoding.UTF8);
                File.WriteAllText(@".\..\..\..\..\S-131_ViewModel.cs", content.ViewModel, Encoding.UTF8);
            }

            [Fact]
            public void Build_S201() {
                var ps = this.Path(@"S-201 Aids to Navigation Information\FC\201_Feature_Catalogue_2.0.0.xml");
                var s100 = XDocument.Load(ps);

                Assert.True(this.VerifyProductSpecification(s100));

                var content = S100Framework.Applications.Roslyn.Build(s100, S100Framework.Applications.Roslyn.ProductFormat.GML);

                //var content = S100Framework.ClassBuilder.CatalogueBuilder(s100, "http://www.iho.int/S100FC/5.0");

                File.WriteAllText(@".\..\..\..\..\S-201_FC.cs", content.DomainModel, Encoding.UTF8);
                File.WriteAllText(@".\..\..\..\..\S-201_ViewModel.cs", content.ViewModel, Encoding.UTF8);
            }

            [Fact]
            public void Build_S501() {
                var ps = System.IO.Path.Combine(this._iho, @"S-501\Feature-Catalogue\S-501_FC.xml");
                var s100 = XDocument.Load(ps);

                //var s100 = XDocument.Load(this.Path(@"S-501 Additional Military Layers\0.9.3\S-501_FC.xml"));
                //var s100 = XDocument.Load(@".\Artifacts\S-501_FC_0_0_9_2025-02-14.xml");

                Assert.True(this.VerifyProductSpecification(s100));

                var content = S100Framework.Applications.Roslyn.Build(s100, S100Framework.Applications.Roslyn.ProductFormat.ISO8211, false, [], [], []);

                //var content = S100Framework.ClassBuilder.CatalogueBuilder52(s100);

                File.WriteAllText(@".\..\..\..\..\S-501_FC.cs", content.DomainModel, Encoding.UTF8);
                File.WriteAllText(@".\..\..\..\..\S-501_ViewModel.cs", content.ViewModel, Encoding.UTF8);
            }


            [Fact]
            public void Test_FeatureBindings() {
                var productSpecification = XDocument.Load(@".\Artifacts\FeatureCatalogue.xml");

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

                    this._output.WriteLine($"{productId}");

                    foreach (var endpoint in endpoints.GroupBy(e => e.association)) {
                        //_output.WriteLine($"{endpoint.Key}");
                        foreach (var role in endpoint.GroupBy(e => e.role)) {
                            //_output.WriteLine($"\t{role.Key}");

                            var lower = role.First().lower;
                            var upper = role.First().upper;

                            if (!role.All(e => e.lower == lower && e.upper == upper)) {
                                foreach (var d in role.Distinct()) {
                                    this._output.WriteLine($"\t\t{endpoint.Key}: {d.roleType}, {d.role}, {d.lower}, {d.upper}");
                                }

                            }
                        }
                    }
                    this._output.WriteLine("");
                }
            }

            [Fact]
            public void Test_RoleUsage() {
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

                    var productId = productSpecification.XPathSelectElement("//S100FC:productId", xmlNamespaceManager)!.Value.Replace("-", string.Empty).ToUpperInvariant();
                    var versionNumber = productSpecification.XPathSelectElement("//S100FC:versionNumber", xmlNamespaceManager)!.Value;

                    this._output.WriteLine($"--- {productId}, {versionNumber} --------------------------------------------------------");

                    var informationAssociations = productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationAssociation", xmlNamespaceManager);

                    foreach (var e in informationAssociations) {
                        var code = e.Element(XName.Get("code", scope_S100))!.Value;

                        var roles = e.XPathSelectElements("S100FC:role", xmlNamespaceManager).Select(e => e.Attribute("ref")!.Value);

                        foreach (var r in roles) {
                            var features = productSpecification.XPathSelectElements($"//S100FC:informationBinding/S100FC:role[@ref=\"{r}\"]", xmlNamespaceManager);
                            if (!features.Any()) {
                                this._output.WriteLine($"\tinformationBinding: {code}, {r}");
                            }
                        }
                    }


                    var featureAssociations = productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureAssociation", xmlNamespaceManager);

                    foreach (var e in featureAssociations) {
                        var code = e.Element(XName.Get("code", scope_S100))!.Value;

                        var roles = e.XPathSelectElements("S100FC:role", xmlNamespaceManager).Select(e => e.Attribute("ref")!.Value);

                        foreach (var r in roles) {
                            var features = productSpecification.XPathSelectElements($"//S100FC:S100_FC_FeatureType/S100FC:featureBinding/S100FC:role[@ref=\"{r}\"]", xmlNamespaceManager);
                            if (!features.Any()) {
                                this._output.WriteLine($"\t    featureBinding: {code}, {r}");
                            }
                        }
                    }

                    this._output.WriteLine("");
                }
            }

            [Fact]
            public void Test_Hierarchy() {
                //var productSpecification = XDocument.Load(@".\Artifacts\131_1_0_0_20230315_FC.xml");

                //var navigator = productSpecification.CreateNavigator();
                //navigator.MoveToFollowing(XPathNodeType.Element);
                //var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

                //var scope_S100 = scopes["S100FC"];

                //var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
                //foreach (var e in scopes)
                //    xmlNamespaceManager.AddNamespace(e.Key, e.Value);

                //var productId = productSpecification.XPathSelectElement("//S100FC:productId", xmlNamespaceManager)!.Value.Replace("-", string.Empty).ToUpperInvariant();
                //var versionNumber = productSpecification.XPathSelectElement("//S100FC:versionNumber", xmlNamespaceManager)!.Value;

                //var featureTypes = productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureType", xmlNamespaceManager);

                //var features = new List<S100Framework.ClassBuilder.featureType>();

                //foreach (var f in featureTypes) {
                //    var name = f.Element(XName.Get("name", scope_S100))!.Value;
                //    var code = f.Element(XName.Get("code", scope_S100))!.Value;

                //    var superType = f.Elements(XName.Get("superType", scope_S100)).FirstOrDefault()?.Value;

                //    var isAbstract = f.Attribute("isAbstract") != default && bool.Parse(f.Attribute("isAbstract")!.Value);

                //    features.Add(new S100Framework.ClassBuilder.featureType(code, superType, isAbstract));
                //}

                //features = features.OrderByDescending(e => e.isAbstract ? 1 : 0).ThenByDescending(e => e.superType is null ? 1 : 0).ToList();

                //var hierarchyFeatureType = features.Hierarchy("FeatureType").ToList();

                //System.Diagnostics.Debugger.Break();
            }

            [Fact]
            public void Test_SpatialAssociation() {
                var productSpecification = XDocument.Load(@".\Artifacts\FeatureCatalogue.xml");

                var navigator = productSpecification.CreateNavigator();
                navigator.MoveToFollowing(XPathNodeType.Element);
                var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

                var scope_S100 = scopes["S100FC"];

                var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
                foreach (var e in scopes)
                    xmlNamespaceManager.AddNamespace(e.Key, e.Value);

                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationAssociation", xmlNamespaceManager);

                foreach (var e in elements) {
                    var association = e.Element(XName.Get("code", scope_S100))!.Value;

                    var usage = productSpecification.XPathSelectElements($"//S100FC:informationBinding/S100FC:association[@ref=\"{association}\"]", xmlNamespaceManager);

                    if (!usage.Any())
                        this._output.WriteLine(association);
                }
            }

            [Fact]
            public void Test_Serialization() {
                //  DateOnly
                //var instance = new S100Framework.DomainModel.S101.ComplexAttributes.zoneOfConfidence {
                //    categoryOfZoneOfConfidenceInData = S100Framework.DomainModel.S101.categoryOfZoneOfConfidenceInData.ZoneOfConfidenceA1,
                //    fixedDateRange = new S100Framework.DomainModel.S101.ComplexAttributes.fixedDateRange {
                //        dateStart = new DateOnly(2025, 1, 1),
                //        dateEnd = new DateOnly(2025, 1, 31)
                //    },
                //    horizontalPositionUncertainty = new S100Framework.DomainModel.S101.ComplexAttributes.horizontalPositionUncertainty {
                //        uncertaintyFixed = 10.0M,
                //        uncertaintyVariableFactor = 1M,
                //    },
                //    verticalUncertainty = new S100Framework.DomainModel.S101.ComplexAttributes.verticalUncertainty {
                //        uncertaintyFixed = 10.0M,
                //        uncertaintyVariableFactor = 1M
                //    }
                //};

                //var json = System.Text.Json.JsonSerializer.Serialize(instance);

                //var deserialized = System.Text.Json.JsonSerializer.Deserialize<S100Framework.DomainModel.S101.ComplexAttributes.zoneOfConfidence>(json);

                //Assert.Equivalent(instance, deserialized);
            }

            [Fact]
            public void Test_Time() {
                int HoursPerDay = 24;
                long TicksPerMicrosecond = 10;
                int MicrosecondsPerMillisecond = 1000;
                long TicksPerMillisecond = TicksPerMicrosecond * MicrosecondsPerMillisecond;
                long TicksPerSecond = TicksPerMillisecond * 1000;
                long TicksPerMinute = TicksPerSecond * 60;
                long TicksPerHour = TicksPerMinute * 60;
                long TicksPerDay = TicksPerHour * HoursPerDay;

                var timeOnly = new TimeOnly(06, 00);
                var json = System.Text.Json.JsonSerializer.Serialize(timeOnly);

                var value1 = 216000000000L;

                var value2 = value1 == (863_999_999_999 + 1) ? 24 : (int)(value1 / TicksPerHour % HoursPerDay);


                var time1 = new S100Framework.DomainModel.S100.Time(06, 00);
                var time2 = new S100Framework.DomainModel.S100.Time(23, 32);
                var time3 = new S100Framework.DomainModel.S100.Time(24, 00);
                var time4 = new S100Framework.DomainModel.S100.Time(11, 32);

                var json1 = System.Text.Json.JsonSerializer.Serialize(time1);
                var json2 = System.Text.Json.JsonSerializer.Serialize(time2);
                var json3 = System.Text.Json.JsonSerializer.Serialize(time3);

                Assert.Equal(time1, System.Text.Json.JsonSerializer.Deserialize<S100Framework.DomainModel.S100.Time>(json1));
                Assert.Equal(time2, System.Text.Json.JsonSerializer.Deserialize<S100Framework.DomainModel.S100.Time>(json2));
                Assert.Equal(time3, System.Text.Json.JsonSerializer.Deserialize<S100Framework.DomainModel.S100.Time>(json3));

                System.Diagnostics.Debugger.Break();
            }

            [Fact]
            public void Test_Default() {

                //var spanFixed = new S100Framework.DomainModel.S101.FeatureTypes.SpanFixed {
                //    verticalClearanceFixed = new S100Framework.DomainModel.S101.ComplexAttributes.verticalClearanceFixed {
                //        verticalClearanceValue = default,
                //    }
                //};

                System.Diagnostics.Debugger.Break();
            }

            //[Fact]
            //public void Test_Required() {
            //    var type = typeof(QualityOfBathymetricData);

            //    var required = type.GetProperty("categoryOfTemporalVariation")!.GetCustomAttribute<RequiredAttribute>();
            //    if (required != null)
            //        ;   //  HAS ATTRIBUTE
            //}

            private bool VerifyProductSpecification(XDocument productSpecification) {
                var navigator = productSpecification.CreateNavigator();
                navigator.MoveToFollowing(XPathNodeType.Element);
                var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

                var scope_S100 = scopes["S100FC"];

                var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
                foreach (var e in scopes)
                    xmlNamespaceManager.AddNamespace(e.Key, e.Value);

                //  Roles
                {
                    var elementInformationTypes = productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationTypes", xmlNamespaceManager);
                    var elementFeatureTypes = productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureTypes", xmlNamespaceManager);

                    var elementRoles = productSpecification.XPathSelectElement("//S100FC:S100_FC_Roles", xmlNamespaceManager);
                    if (elementRoles == null) {
                        this._output.WriteLine("no roles found");
                    }
                    else {
                        foreach (var role in elementRoles!.Elements()) {
                            var name = role.Element(XName.Get("name", scope_S100))!.Value;
                            var code = role.Element(XName.Get("code", scope_S100))!.Value;

                            //var query = $"//S100FC:featureBinding/S100FC:role[@ref=\"{code}\"]";
                            var query = $"//S100FC:role[@ref=\"{code}\"]";

                            if (elementInformationTypes.Any(e => e.XPathSelectElements(query, xmlNamespaceManager).Any())) {
                                continue;
                            }
                            if (elementFeatureTypes.Any(e => e.XPathSelectElements(query, xmlNamespaceManager).Any())) {
                                continue;
                            }

                            this._output.WriteLine($"role not used: {code}");
                        }
                    }
                }

                //  Associations
                {
                    var elementInformationAssociations = productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationAssociation", xmlNamespaceManager);
                    if (elementInformationAssociations is null) {

                    }
                    else {
                        foreach (var e in elementInformationAssociations) {
                            var name = e.Element(XName.Get("name", scope_S100))!.Value;
                            var code = e.Element(XName.Get("code", scope_S100))!.Value;

                            this._output.WriteLine($"{code}:");

                            var roles = e.Elements(XName.Get("role", scope_S100)).Select(e => e.Attribute("ref")!.Value);

                            var dictionary = new Dictionary<string, (int lower, int? upper)>();

                            var bindings = productSpecification.XPathSelectElements($"//S100FC:informationBinding/S100FC:association[@ref=\"{code}\"]", xmlNamespaceManager);
                            foreach (var b in bindings) {
                                var binding = b.Parent!;

                                var role = binding.Element(XName.Get("role", scope_S100))!.Attribute("ref")!.Value;

                                var lower = int.Parse(binding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                                var _ = binding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                                int? upper = (_.Attribute(XName.Get("infinite")) != default && _.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? null : int.Parse(_.Value!);

                                if (!dictionary.ContainsKey(role)) {
                                    dictionary.Add(role, (lower, upper));
                                }
                                else {
                                    Assert.True(dictionary[role].Equals((lower, upper)));
                                }
                            }

                            foreach (var pair in dictionary) {
                                var upper = pair.Value.upper.HasValue ? $"{pair.Value.upper.Value}" : "∞";
                                this._output.WriteLine($"\t{pair.Key}: {pair.Value.lower} {upper}");
                            }
                            foreach (var r in roles) {
                                if (dictionary.ContainsKey(r))
                                    continue;
                                this._output.WriteLine($"\t{r} not used!");
                            }

                            this._output.WriteLine("");
                        }
                    }

                    var elementFeatureAssociations = productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureAssociation", xmlNamespaceManager);
                    if (elementFeatureAssociations is null) {

                    }
                    else {
                        foreach (var e in elementFeatureAssociations) {
                            var name = e.Element(XName.Get("name", scope_S100))!.Value;
                            var code = e.Element(XName.Get("code", scope_S100))!.Value;

                            this._output.WriteLine($"{code}:");

                            var roles = e.Elements(XName.Get("role", scope_S100)).Select(e => e.Attribute("ref")!.Value);

                            var dictionary = new Dictionary<string, (int lower, int? upper)>();

                            var bindings = productSpecification.XPathSelectElements($"//S100FC:featureBinding/S100FC:association[@ref=\"{code}\"]", xmlNamespaceManager);
                            foreach (var b in bindings) {
                                var binding = b.Parent!;

                                var role = binding.Element(XName.Get("role", scope_S100))!.Attribute("ref")!.Value;

                                var lower = int.Parse(binding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                                var _ = binding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                                int? upper = (_.Attribute(XName.Get("infinite")) != default && _.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? null : int.Parse(_.Value!);

                                if (!dictionary.ContainsKey(role)) {
                                    dictionary.Add(role, (lower, upper));
                                }
                                else {
                                    Assert.True(dictionary[role].Equals((lower, upper)));
                                }
                            }

                            foreach (var pair in dictionary) {
                                var upper = pair.Value.upper.HasValue ? $"{pair.Value.upper.Value}" : "∞";
                                this._output.WriteLine($"\t{pair.Key}: {pair.Value.lower} {upper}");
                            }
                            foreach (var r in roles) {
                                if (dictionary.ContainsKey(r))
                                    continue;
                                this._output.WriteLine($"\t{r} not used!");
                            }
                            this._output.WriteLine("");
                        }
                    }
                }
                return true;
            }

            public partial class StructureEquipment
            {
                public virtual String[] theStructureFeatureTypes => [];
            }

            public partial class SpecialStructureEquipment : StructureEquipment
            {
                public override String[] theStructureFeatureTypes => ["Bridge", "Building", "Crane", "CardinalBeacon", "CardinalBuoy", "Conveyor", "Dolphin", "EmergencyWreckMarkingBuoy", "FishingFacility", "FloatingDock", "FortifiedStructure", "Hulk", "InstallationBuoy", "IsolatedDangerBeacon", "IsolatedDangerBuoy", "Landmark", "LateralBeacon", "LateralBuoy", "LightFloat", "LightVessel", "MooringBuoy", "OffshorePlatform", "Pile", "PipelineOverhead", "Pontoon", "PylonBridgeSupport", "SafeWaterBeacon", "SafeWaterBuoy", "ShorelineConstruction", "SiloTank", "SpanFixed", "SpanOpening", "SpecialPurposeGeneralBeacon", "SpecialPurposeGeneralBuoy", "StructureOverNavigableWater", "WindTurbine", "Wreck", "Daymark", "LightAllAround", "LightSectored"];
            }

            public record featureBinding(string roleType, int lower, int? upper, string association, string role);
        }
    }

    namespace Nullable
    {
        // Define an enum for the state
        public enum ValueState
        {
            Unknown,    // Default state, or explicitly unknown
            HasValue,   // Contains a valid value (which could be null for reference types)
            IsNull      // Explicitly set to a "null" or "not applicable" state
        }

        public enum Colors
        {
            Red, Green, Yellow
        }

        public readonly struct NullableUnknown<T> : IEquatable<NullableUnknown<T>>
        {
            private readonly T _value;
            private readonly ValueState _state;

            // Private constructor to control instantiation via factory methods
            private NullableUnknown(T value, ValueState state) {
                this._value = value;
                this._state = state;
            }

            // --- Factory Methods ---

            /// <summary>
            /// Creates an instance with a specific value.
            /// If 'value' is null for a reference type, it's still considered 'HasValue'.
            /// </summary>
            public static NullableUnknown<T> FromValue(T value) {
                return new NullableUnknown<T>(value, ValueState.HasValue);
            }

            /// <summary>
            /// Represents an explicitly null/not-present state.
            /// </summary>
            public static NullableUnknown<T> Null => new NullableUnknown<T>(default!, ValueState.IsNull);
            // default! is used to satisfy nullable reference types if T is non-nullable.
            // The actual default(T) value isn't used if state is IsNull.

            /// <summary>
            /// Represents an unknown state. This is also the default state of the struct.
            /// </summary>
            public static NullableUnknown<T> Unknown => default; // Relies on default struct init

            // --- Properties ---

            public bool HasValue => this._state == ValueState.HasValue;
            public bool IsNull => this._state == ValueState.IsNull;
            public bool IsUnknown => this._state == ValueState.Unknown; // Or _state == default(ValueState)

            /// <summary>
            /// Gets the value if HasValue is true.
            /// Throws InvalidOperationException if HasValue is false.
            /// </summary>
            public T Value {
                get {
                    if (!this.HasValue) {
                        throw new InvalidOperationException("NullableUnknown does not have a value in its current state.");
                    }
                    return this._value;
                }
            }

            /// <summary>
            /// Gets the value if HasValue is true, otherwise returns default(T).
            /// </summary>
            public T GetValueOrDefault() => this._value; // Works because _value is default(T) if not HasValue

            /// <summary>
            /// Gets the value if HasValue is true, otherwise returns the specified default value.
            /// </summary>
            public T GetValueOrDefault(T defaultValue) => this.HasValue ? this._value : defaultValue;


            // --- Overrides and IEquatable ---

            public override bool Equals(object? obj) {
                return obj is NullableUnknown<T> other && this.Equals(other);
            }

            public bool Equals(NullableUnknown<T> other) {
                if (this._state != other._state) {
                    return false;
                }
                if (this.HasValue) // Only compare values if both have values
                {
                    return EqualityComparer<T>.Default.Equals(this._value, other._value);
                }
                // If not HasValue, states being equal is enough (e.g., Unknown == Unknown)
                return true;
            }

            public override int GetHashCode() {
                unchecked // Overflow is fine, just wrap
                {
                    int hashCode = this._state.GetHashCode();
                    if (this.HasValue && this._value != null) // Check _value for null to avoid NullReferenceException on _value.GetHashCode()
                    {
                        hashCode = (hashCode * 397) ^ EqualityComparer<T>.Default.GetHashCode(this._value);
                    }
                    return hashCode;
                }
            }

            public static bool operator ==(NullableUnknown<T> left, NullableUnknown<T> right) {
                return left.Equals(right);
            }

            public static bool operator !=(NullableUnknown<T> left, NullableUnknown<T> right) {
                return !left.Equals(right);
            }

            public override string ToString() {
                return this._state switch {
                    ValueState.HasValue => this._value?.ToString() ?? "null (value)", // Differentiate value 'null' from state 'Null'
                    ValueState.IsNull => "Null (state)",
                    ValueState.Unknown => "Unknown",
                    _ => "Invalid State" // Should not happen
                };
            }

            // --- Implicit Conversions (Optional but can be convenient) ---

            /// <summary>
            /// Implicitly converts a value of T to NullableUnknown<T> with HasValue state.
            /// </summary>
            public static implicit operator NullableUnknown<T>(T value) => FromValue(value);

            // No implicit conversion from NullableUnknown<T> to T, as it might throw.
            // An explicit conversion could be added:
            // public static explicit operator T(NullableUnknown<T> value) => value.Value;
        }

        public class UnitTestNullalbe
        {
            private readonly ITestOutputHelper _output;

            public UnitTestNullalbe(ITestOutputHelper output) {
                this._output = output;
            }

            [Fact]
            public void Test_NullableUnknown() {

                // Example with int (value type)
                NullableUnknown<int> age1 = NullableUnknown<int>.FromValue(30);
                NullableUnknown<int> age2 = NullableUnknown<int>.Null;
                NullableUnknown<int> age3 = NullableUnknown<int>.Unknown; // Or just default: NullableUnknown<int> age3;
                NullableUnknown<int> age4 = 25; // Using implicit conversion

                this.ProcessData(age1, NullableUnknown<string>.FromValue("Alice"));
                this.ProcessData(age2, NullableUnknown<string>.FromValue(null)); // Name has a value, and that value is null
                this.ProcessData(age3, NullableUnknown<string>.Null);          // Name is explicitly in the "Null state"
                this.ProcessData(age4, NullableUnknown<string>.Unknown);       // Name is "Unknown"
                this.ProcessData(default, "Bob"); // Default for NullableUnknown<int> is Unknown. Implicit for string.


            }

            private void ProcessData(NullableUnknown<int> age, NullableUnknown<string> name) {
                // Processing age
                if (age.HasValue) {
                    this._output.WriteLine($"Age: {age.Value}");
                }
                else if (age.IsNull) {
                    this._output.WriteLine("Age: Not Applicable/Provided as Null");
                }
                else // age.IsUnknown
                {
                    this._output.WriteLine("Age: Unknown");
                }

                // Processing name (string can be null itself)
                if (name.HasValue) {
                    if (name.Value == null) {
                        this._output.WriteLine("Name: Provided as a null string value");
                    }
                    else {
                        this._output.WriteLine($"Name: {name.Value}");
                    }
                }
                else if (name.IsNull) {
                    this._output.WriteLine("Name: Not Applicable/Provided as Null State");
                }
                else // name.IsUnknown
                {
                    this._output.WriteLine("Name: Unknown");
                }
                this._output.WriteLine("---");
            }
        }
    }
}


