using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Xunit.Abstractions;
using static S100Framework.Roslyn;



namespace TestS100Framework
{
    public class UnitTestRoslyn
    {
        private readonly ITestOutputHelper _output;

        public UnitTestRoslyn(ITestOutputHelper output) {
            this._output = output;
        }

        [Fact]
        public void Test_Simple() {
            var fields = new[] {
                new FieldDescription("depthRangeMinimumValue", typeof(decimal)),
                new FieldDescription("depthRangeMaximumValue", typeof(decimal)),
                new FieldDescription("information", typeof(string[])),
            };

            var instance = S100Framework.Roslyn.CreateInstance(fields, "S100Framework.Attributes", "DepthArea");
        }

        [Fact]
        public void Test_List() {
            var type = typeof(int);

            var listType = typeof(List<>).MakeGenericType(type);

            Assert.NotNull(listType);
            Assert.True(listType.IsGenericType);

            Assert.True(listType.GetGenericTypeDefinition() == typeof(List<>));
        }

        [Fact]
        public void Test_Complex() {
            var moduleBuilder = S100Framework.Roslyn.GetModuleBuilder("S100Framework.Attributes");

            var name = moduleBuilder.Assembly.GetName().Name;

            var information = S100Framework.Roslyn.GetTypeBuilder(moduleBuilder, "information");
            S100Framework.Roslyn.CreateProperty(information, "fileLocator", typeof(string));
            S100Framework.Roslyn.CreateProperty(information, "fileReference", typeof(string));
            S100Framework.Roslyn.CreateProperty(information, "headline", typeof(string));
            S100Framework.Roslyn.CreateProperty(information, "language", typeof(string));
            S100Framework.Roslyn.CreateProperty(information, "text", typeof(string));

            var constructorInfo = typeof(Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObjectAttribute).GetConstructors().First();

            var expandableObjectAttributeBuilder = new CustomAttributeBuilder(constructorInfo, new object[0]);

            var informationType = information.CreateType();


            informationType = informationType.MakeArrayType();

            var deptharea = S100Framework.Roslyn.GetTypeBuilder(moduleBuilder, "DepthArea");
            S100Framework.Roslyn.CreateProperty(deptharea, "depthRangeMinimumValue", typeof(decimal));
            S100Framework.Roslyn.CreateProperty(deptharea, "depthRangeMaximumValue", typeof(decimal));
            S100Framework.Roslyn.CreateProperty(deptharea, "information", informationType);

            var depthareaType = deptharea.CreateType();

            var instance = Activator.CreateInstance(depthareaType);

            System.Diagnostics.Debugger.Break();

            //CustomAttributeBuilder displayNameAttributeBuilder = new CustomAttributeBuilder(constructorInfo, new object[] { "Property Name A" });

        }

        [Fact]
        public void Test_EnumCreation() {
            var moduleBuilder = S100Framework.Roslyn.GetModuleBuilder("S100Framework.Attributes");

            var name = moduleBuilder.Assembly.GetName().Name;

            var enumBuilder = moduleBuilder.DefineEnum("categoryOfTemporalVariation", TypeAttributes.Public, typeof(int));
            enumBuilder.DefineLiteral("Extreme Event", 1);
            enumBuilder.DefineLiteral("Likely to Change and Significant Shoaling Expected", 2);
            enumBuilder.DefineLiteral("Likely to Change But Significant Shoaling Not Expected", 3);
            enumBuilder.DefineLiteral("Likely to Change", 4);
            enumBuilder.DefineLiteral("Unlikely to Change", 5);
            enumBuilder.DefineLiteral("Unassessed", 6);

            var enumType = enumBuilder.CreateType();

            var enums = Enum.GetValues(enumType);
            Assert.NotNull(enums);
            Assert.True(enums.Length == 6);

            var qualityOfNonBathymetricData = S100Framework.Roslyn.GetTypeBuilder(moduleBuilder, "QualityOfNonBathymetricData");
            var propertyBuilder = S100Framework.Roslyn.CreateProperty(qualityOfNonBathymetricData, "categoryOfTemporalVariation", enumType);

            var qualityOfNonBathymetricDataType = qualityOfNonBathymetricData.CreateType();

            var instance = Activator.CreateInstance(qualityOfNonBathymetricDataType);
            Assert.NotNull(instance);
            Assert.IsType(qualityOfNonBathymetricDataType, instance);
        }

        [Fact]
        public void Nullable() {
            //  public class Test
            //  {
            //      public int? NullableValue { get; set;}
            //      public int  Value { get; set;}
            //  }

            var moduleBuilder = S100Framework.Roslyn.GetModuleBuilder("S100Framework.Attributes");

            var typeBuilder = S100Framework.Roslyn.GetTypeBuilder(moduleBuilder, "Test");

            var propertyBuilder1 = S100Framework.Roslyn.CreateProperty(typeBuilder, "NullableValue", typeof(int?));

            var propertyBuilder2 = S100Framework.Roslyn.CreateProperty(typeBuilder, "Value", typeof(int));

            var type = typeBuilder.CreateType();


            var ctor = typeBuilder.GetConstructor(Type.EmptyTypes);

            var instance = Activator.CreateInstance(type);

            var json = JsonSerializer.Serialize(instance);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_CreateAssembly_S101() {
            var s101 = XDocument.Load(@".\Artifacts\S-101_FC_1.2.3.xml");
            var featureCatalogue = S100Framework.Roslyn.CreateAssembly(s101);

            var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Roslyn.Namespace}.DepthArea", true)!;

            var instance = Activator.CreateInstance(type);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_CreateAssembly_S128() {
            var s128 = XDocument.Load(@".\Artifacts\S-128_FC_Ed2.0.0_SE_ALT.xml");
            var featureCatalogue = S100Framework.Roslyn.CreateAssembly(s128);

            var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Roslyn.Namespace}.ElectronicProduct", true)!;

            var instance1 = Activator.CreateInstance(type);

            var json = JsonSerializer.Serialize(instance1);

            var sample = "{\r\n  \"datasetName\": \"DK4KATGN\",\r\n  \"issueDate\": \"2024-06-01T00:00:00\",\r\n  \"compilationScale\": [\r\n    22000\r\n  ],\r\n  \"featureName\": [\r\n    {\r\n      \"displayName\": true,\r\n      \"name\": \"DK4KATGN\",\r\n      \"language\": \"ENG\"\r\n    }\r\n  ]\r\n}";

            var instance2 = System.Text.Json.JsonSerializer.Deserialize(sample, type);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_CreateAssembly_S313() {
            var s131 = XDocument.Load(@".\Artifacts\131_1_0_0_20230315_FC.xml");
            var featureCatalogue = S100Framework.Roslyn.CreateAssembly(s131);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_CreateAssembly3() {
            var s128 = XDocument.Load(@".\Artifacts\S-128_FC_Ed2.0.0.xml");

            var featureCatalogue = S100Framework.Roslyn.CreateAssembly(s128);

            var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Roslyn.Namespace}.ElectronicProduct", true)!;

            var instance1 = Activator.CreateInstance(type);

            var json = JsonSerializer.Serialize(instance1);

            var sample = "{\r\n  \"datasetName\": \"DK4KATGN\",\r\n  \"issueDate\": \"2024-06-01T00:00:00\",\r\n  \"compilationScale\": [\r\n    22000\r\n  ],\r\n  \"featureName\": [\r\n    {\r\n      \"displayName\": true,\r\n      \"name\": \"DK4KATGN\",\r\n      \"language\": \"ENG\"\r\n    }\r\n  ]\r\n}";

            var instance2 = System.Text.Json.JsonSerializer.Deserialize(sample, type);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_LoadFeatureCatalogue() {
            var assembly = new AssemblyName("S100Framework.Attributes");
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assembly, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");

            var assemblyName = moduleBuilder.Assembly.GetName().Name;

            var s100 = XDocument.Load(@"..\..\..\..\..\..\artifacts\S-101 Electronic Navigational Chart (ENC)\S-101_FC_1.2.3.xml");

            var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            xmlNamespaceManager.AddNamespace("S100FC", "http://www.iho.int/S100FC/5.0");
            xmlNamespaceManager.AddNamespace("S100Base", "http://www.iho.int/S100Base/5.0");
            xmlNamespaceManager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");

            var dictionaryTypes = new Dictionary<string, Type>();

            //  S100_FC_SimpleAttributes
            _output.WriteLine("S100_FC_SimpleAttributess");
            {
                var elements = s100.XPathSelectElements("//S100FC:S100_FC_SimpleAttribute", xmlNamespaceManager);

                foreach (var e in elements) {
                    var name = e.Element(XName.Get("name", "http://www.iho.int/S100FC/5.0"))!.Value;
                    var code = e.Element(XName.Get("code", "http://www.iho.int/S100FC/5.0"))!.Value;
                    var valueType = e.Element(XName.Get("valueType", "http://www.iho.int/S100FC/5.0"))!.Value switch {
                        "boolean" => typeof(Boolean),
                        "enumeration" => typeof(int),
                        "real" => typeof(decimal),
                        "text" => typeof(string),
                        "S100_TruncatedDate" => typeof(DateOnly),
                        "time" => typeof(TimeOnly),
                        "integer" => typeof(int),
                        _ => throw new InvalidDataException(),
                    };

                    dictionaryTypes.Add(code, valueType);
                }
            }

            //  S100_FC_ComplexAttribute
            _output.WriteLine("S100_FC_ComplexAttributes");
            {
                var elements = s100.XPathSelectElements("//S100FC:S100_FC_ComplexAttribute", xmlNamespaceManager);

                var notFinished = false;
                do {
                    notFinished = false;

                    foreach (var e in elements) {
                        var name = e.Element(XName.Get("name", "http://www.iho.int/S100FC/5.0"))!.Value;
                        var code = e.Element(XName.Get("code", "http://www.iho.int/S100FC/5.0"))!.Value;

                        if (dictionaryTypes.ContainsKey(code))
                            continue;

                        if (e.XPathSelectElements("S100FC:subAttributeBinding", xmlNamespaceManager).Any(attribute => !dictionaryTypes.ContainsKey(attribute.Element(XName.Get("attribute", "http://www.iho.int/S100FC/5.0"))!.Attribute("ref")!.Value!))) {
                            notFinished = true;
                            continue;
                        }

                        _output.WriteLine($"    {code}");

                        var complexTypeBuilder = S100Framework.Roslyn.GetTypeBuilder(moduleBuilder, code);

                        foreach (var attributeBinding in e.XPathSelectElements("S100FC:subAttributeBinding", xmlNamespaceManager)) {
                            var referenceCode = attributeBinding.Element(XName.Get("attribute", "http://www.iho.int/S100FC/5.0"))!.Attribute("ref")!.Value!;

                            var referenceType = dictionaryTypes[referenceCode];

                            var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                            var upper = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;

                            if (upper.Attribute(XName.Get("infinite")) != default && upper.Attribute(XName.Get("infinite"))!.Value.Equals("true") || int.Parse(upper!.Value) > 1) {
                                referenceType = referenceType.MakeArrayType();
                            }

                            if (lower == 0) {
                                //TODO: Optional ?
                            }
                            S100Framework.Roslyn.CreateProperty(complexTypeBuilder, referenceCode, referenceType);
                        }

                        var complexType = complexTypeBuilder.CreateType();

                        dictionaryTypes.Add(code, complexType);

                    }
                } while (notFinished);
            }

            //  S100_FC_InformationType
            _output.WriteLine("S100_FC_InformationTypes");
            {
                var elements = s100.XPathSelectElements("//S100FC:S100_FC_InformationType", xmlNamespaceManager);

                var notFinished = false;
                do {
                    notFinished = false;

                    foreach (var e in elements) {
                        var name = e.Element(XName.Get("name", "http://www.iho.int/S100FC/5.0"))!.Value;
                        var code = e.Element(XName.Get("code", "http://www.iho.int/S100FC/5.0"))!.Value;

                        if (dictionaryTypes.ContainsKey(code))
                            continue;

                        if (e.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager).Any(attribute => !dictionaryTypes.ContainsKey(attribute.Element(XName.Get("attribute", "http://www.iho.int/S100FC/5.0"))!.Attribute("ref")!.Value!))) {
                            notFinished = true;
                            continue;
                        }

                        _output.WriteLine($"    {code}");

                        var informationTypeBuilder = S100Framework.Roslyn.GetTypeBuilder(moduleBuilder, code);

                        foreach (var attributeBinding in e.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                            var referenceCode = attributeBinding.Element(XName.Get("attribute", "http://www.iho.int/S100FC/5.0"))!.Attribute("ref")!.Value!;

                            var referenceType = dictionaryTypes[referenceCode];

                            var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                            var upper = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;

                            if (upper.Attribute(XName.Get("infinite")) != default && upper.Attribute(XName.Get("infinite"))!.Value.Equals("true") || int.Parse(upper!.Value) > 1) {
                                referenceType = referenceType.MakeArrayType();
                            }

                            if (lower == 0) {
                                //TODO: Optional ?
                            }
                            S100Framework.Roslyn.CreateProperty(informationTypeBuilder, referenceCode, referenceType);
                        }

                        var complexType = informationTypeBuilder.CreateType();

                        dictionaryTypes.Add(code, complexType);

                    }
                } while (notFinished);
            }

            //  S100_FC_FeatureType
            _output.WriteLine("S100_FC_FeatureTypes");
            {
                var elements = s100.XPathSelectElements("//S100FC:S100_FC_FeatureType", xmlNamespaceManager);

                var notFinished = false;
                do {
                    notFinished = false;

                    foreach (var e in elements) {
                        var name = e.Element(XName.Get("name", "http://www.iho.int/S100FC/5.0"))!.Value;
                        var code = e.Element(XName.Get("code", "http://www.iho.int/S100FC/5.0"))!.Value;

                        if (dictionaryTypes.ContainsKey(code))
                            continue;

                        if (e.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager).Any(attribute => !dictionaryTypes.ContainsKey(attribute.Element(XName.Get("attribute", "http://www.iho.int/S100FC/5.0"))!.Attribute("ref")!.Value!))) {
                            notFinished = true;
                            continue;
                        }

                        _output.WriteLine($"    {code}");

                        var featureTypeBuilder = S100Framework.Roslyn.GetTypeBuilder(moduleBuilder, code);

                        foreach (var attributeBinding in e.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                            var referenceCode = attributeBinding.Element(XName.Get("attribute", "http://www.iho.int/S100FC/5.0"))!.Attribute("ref")!.Value!;

                            var referenceType = dictionaryTypes[referenceCode];

                            var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                            var upper = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;

                            if (upper.Attribute(XName.Get("infinite")) != default && upper.Attribute(XName.Get("infinite"))!.Value.Equals("true") || int.Parse(upper!.Value) > 1) {
                                referenceType = referenceType.MakeArrayType();
                            }

                            if (lower == 0) {
                                //TODO: Optional ?
                            }
                            S100Framework.Roslyn.CreateProperty(featureTypeBuilder, referenceCode, referenceType);
                        }

                        var complexType = featureTypeBuilder.CreateType();

                        dictionaryTypes.Add(code, complexType);

                    }
                } while (notFinished);
            }

            foreach (var t in dictionaryTypes.Where(e => !e.Value.IsAnsiClass)) {
                Assert.IsType(t.Value, Activator.CreateInstance(t.Value));
            }


            var testType = moduleBuilder.Assembly.GetType("S100Framework.Attributes.QualityOfSurvey", true)!;

            var testInstance = Activator.CreateInstance(testType);
        }
    }
}