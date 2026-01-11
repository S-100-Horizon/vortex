using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Xunit.Abstractions;

namespace TestAttributes
{
    using S100Framework.AttributeModel;
    using S100Framework.DomainModel;
    using System.Reflection;
    using System.Security.Cryptography;
    using System.Text.Json.Serialization;
    using Windows.System;

    public class UnitTestRoslyn
    {
        private readonly ITestOutputHelper _output;

        private readonly string _iho;
        private readonly string _iala;

        public UnitTestRoslyn(ITestOutputHelper output) {
            this._output = output;

            this._iho = Environment.GetEnvironmentVariable("GITHUB-IHO")!;
            this._iala = Environment.GetEnvironmentVariable("GITHUB-IALA")!;
        }

        [Fact]
        public void Test_Build() {
            Test_S101_Build();
            Test_S122_Build();
            Test_S123_Build();
            Test_S124_Build();
            //Test_S125_Build();
            Test_S127_Build();
            Test_S128_Build();
            Test_S131_Build();
        }

        [Fact]
        public void Test_S101_Build() {
            var ps = XDocument.Load(System.IO.Path.Combine(this._iho, @"S-101-Documentation-and-FC\S-101FC\FeatureCatalogue.xml"));

            var roslyn = RoslynBuilder(ps);

            var output = roslyn.ToString();

            File.WriteAllText(@".\..\..\..\S-101_FC.attribute.g.cs", output, Encoding.UTF8);
        }

        [Fact]
        public void Test_S122_Build() {
            var ps = XDocument.Load(System.IO.Path.Combine(this._iho, @"S-122-Product-Specification-Development\FC\122_FC_2.0.0.20251207.xml"));

            var roslyn = RoslynBuilder(ps);

            var output = roslyn.ToString();

            File.WriteAllText(@".\..\..\..\S-122_FC.attribute.g.cs", output, Encoding.UTF8);
        }

        [Fact]
        public void Test_S123_Build() {
            var ps = XDocument.Load(System.IO.Path.Combine(this._iho, @"S-123-Product-Specification-Development\FC\S-123_FC_Ed.2.0.0_20251210.xml"));

            var roslyn = RoslynBuilder(ps);

            var output = roslyn.ToString();

            File.WriteAllText(@".\..\..\..\S-123_FC.attribute.g.cs", output, Encoding.UTF8);
        }

        [Fact]
        public void Test_S124_Build() {
            var ps = XDocument.Load(System.IO.Path.Combine(this._iho, @"S-124 Navigational Warnings\FC\124_FC_2.0.0.xml"));

            var roslyn = RoslynBuilder(ps);

            var output = roslyn.ToString();

            File.WriteAllText(@".\..\..\..\S-124_FC.attribute.g.cs", output, Encoding.UTF8);
        }

        [Fact]
        public void Test_S125_Build() {
            var ps = XDocument.Load(System.IO.Path.Combine(this._iho, @"S-125-Product-Specification-Development\FC\S125FC.xml"));

            var roslyn = RoslynBuilder(ps, "S125");

            var output = roslyn.ToString();

            File.WriteAllText(@".\..\..\..\S-125_FC.attribute.g.cs", output, Encoding.UTF8);
        }

        [Fact]
        public void Test_S127_Build() {
            var ps = XDocument.Load(System.IO.Path.Combine(this._iho, @"S-127-Product-Specification-Development\FC\127_FC_2.0.0.20251207.xml"));

            var roslyn = RoslynBuilder(ps);

            var output = roslyn.ToString();

            File.WriteAllText(@".\..\..\..\S-127_FC.attribute.g.cs", output, Encoding.UTF8);
        }

        [Fact]
        public void Test_S128_Build() {
            var ps = XDocument.Load(System.IO.Path.Combine(this._iho, @"S-128-Product-Specification-Development\FC\128_FC.xml"));

            var roslyn = RoslynBuilder(ps);

            var output = roslyn.ToString();

            File.WriteAllText(@".\..\..\..\S-128_FC.attribute.g.cs", output, Encoding.UTF8);
        }

        [Fact]
        public void Test_S131_Build() {
            var ps = XDocument.Load(System.IO.Path.Combine(this._iho, @"S-131-Product-Specification-Development\FC\131_FC_2.0.0.20251112.xml"));

            var roslyn = RoslynBuilder(ps);

            var output = roslyn.ToString();

            File.WriteAllText(@".\..\..\..\S-131_FC.attribute.g.cs", output, Encoding.UTF8);
        }

        private StringBuilder RoslynBuilder(XDocument ps, string? id = null) {
            var roslyn = new StringBuilder();

            roslyn.AppendLine("using System;");
            roslyn.AppendLine("using System.Text.Json.Serialization;");
            roslyn.AppendLine("");
            roslyn.AppendLine("#nullable enable");
            roslyn.AppendLine("#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.");
            roslyn.AppendLine("");

            var navigator = ps.CreateNavigator();
            navigator.MoveToFollowing(XPathNodeType.Element);

            var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var s in scopes)
                xmlNamespaceManager.AddNamespace(s.Key, s.Value);

            var productId = ps.XPathSelectElement("//S100FC:productId", xmlNamespaceManager)!.Value.Replace("-", string.Empty).ToUpperInvariant();
            if (id is not null)
                productId = id;

            var versionNumber = ps.XPathSelectElement("//S100FC:versionNumber", xmlNamespaceManager)!.Value;
            var versionDate = ps.XPathSelectElement("//S100FC:versionDate", xmlNamespaceManager)!.Value;

            var attributesKnown = new List<string>();

            var attributesKnownTypes = new Dictionary<string, string>();

            var attributesKnownComplex = new List<string>();

            var derivedTypesInformationBindings = new StringBuilder();
            var derivedTypesFeatureBindings = new StringBuilder();
            var derivedTypesAttributes = new StringBuilder();


            #region S100_FC_SimpleAttribute
            {
                roslyn.AppendLine($"namespace S100Framework.AttributeModel.{productId}.SimpleAttributes");
                roslyn.AppendLine("{");
                foreach (var element in ps.XPathSelectElements("//S100FC:S100_FC_SimpleAttribute", xmlNamespaceManager)) {
                    var code = element.Element(XName.Get("code", scopes["S100FC"]))!.Value;
                    var name = element.Element(XName.Get("name", scopes["S100FC"]))!.Value;

                    attributesKnown.Add(code);

                    derivedTypesAttributes.AppendLine($"\t\t\t\t\ttypeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof({code}), typeDiscriminator: \"{code}\"));");

                    var valueType = element.Element(XName.Get("valueType", scopes["S100FC"]))!.Value;

                    var definition = element.Element(XName.Get("definition", scopes["S100FC"]))!.Value;
                    roslyn.AppendLine("\t/// <summary>");
                    roslyn.AppendLine($"\t/// {definition}");
                    roslyn.AppendLine("\t/// </summary>");

                    if (valueType.Equals("enumeration")) {
                        attributesKnownTypes.Add(code, "int");
                        roslyn.AppendLine($"\tpublic class {code} : S100Framework.AttributeModel.EnumerationAttribute");
                        roslyn.AppendLine($"\t{{");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override string S100FC_code => nameof({code});");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override string S100FC_name => \"{name}\";");
                        //roslyn.AppendLine("\t\t[JsonIgnore]");
                        //roslyn.AppendLine($"\t\tpublic override listedValue[] listedValues => {code}.listedValues");

                        roslyn.AppendLine($"\t\tpublic static listedValue[] listedValues => [");
                        foreach (var listedValue in element.Element(XName.Get("listedValues", scopes["S100FC"]))!.Elements()) {
                            var listedValueLabel = listedValue.Element(XName.Get("label", scopes["S100FC"]))!.Value!;
                            var listedValueDefinition = listedValue.Element(XName.Get("definition", scopes["S100FC"]))!.Value!;
                            var listedValueCode = listedValue.Element(XName.Get("code", scopes["S100FC"]))!.Value!;

                            listedValueDefinition = listedValueDefinition.Replace("\"", "\\\"");

                            if (string.IsNullOrEmpty(listedValueDefinition)) {
                                roslyn.AppendLine($"\t\t\t\tnew listedValue(\"{listedValueLabel}\", \"\",{listedValueCode}),");
                            }
                            else {
                                var multiline = listedValueDefinition.Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                                if (multiline.Length == 1)
                                    roslyn.AppendLine($"\t\t\t\tnew listedValue(\"{listedValueLabel}\", \"{multiline[0]}\",{listedValueCode}),");
                                else {
                                    roslyn.AppendLine($"\t\t\t\tnew listedValue(\"{listedValueLabel}\", \"{multiline[0]}\" +");
                                    for (int i = 1; i < multiline.Length - 1; i++)
                                        roslyn.AppendLine($"\t\t\t\t\t\t\t\t\t\t\"{multiline[i]}\" +");
                                    roslyn.AppendLine($"\t\t\t\t\t\t\t\t\t\t\"{multiline[^1]}\",{listedValueCode}),");
                                }
                            }
                        }
                        roslyn.AppendLine($"\t\t\t];");
                        //roslyn.AppendLine($"\t\tpublic int? value {{ get; set; }} = default;");
                        roslyn.AppendLine();
                        roslyn.AppendLine($"\t\tpublic static implicit operator {code}(int? value) => new {code} {{ value = value }};");
                        roslyn.AppendLine($"\t}}");
                    }
                    else if (valueType.Equals("S100_CodeList")) {
                        attributesKnownTypes.Add(code, "int");
                        roslyn.AppendLine($"\tpublic class {code} : S100Framework.AttributeModel.CodeListAttribute");
                        roslyn.AppendLine($"\t{{");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override string S100FC_code => nameof({code});");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override string S100FC_name => \"{name}\";");
                        //roslyn.AppendLine("\t\t[JsonIgnore]");
                        //roslyn.AppendLine($"\t\tpublic override listedValue[] listedValues => {code}.listedValues");

                        roslyn.AppendLine($"\t\tpublic static listedValue[] listedValues => [");
                        foreach (var listedValue in element.Element(XName.Get("listedValues", scopes["S100FC"]))!.Elements()) {
                            var listedValueLabel = listedValue.Element(XName.Get("label", scopes["S100FC"]))!.Value!;
                            var listedValueDefinition = listedValue.Element(XName.Get("definition", scopes["S100FC"]))!.Value!;
                            var listedValueCode = listedValue.Element(XName.Get("code", scopes["S100FC"]))!.Value!;

                            var multiline = listedValueDefinition.Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                            if (multiline.Length == 1)
                                roslyn.AppendLine($"\t\t\t\tnew listedValue(\"{listedValueLabel}\", \"{multiline[0]}\",{listedValueCode}),");
                            else {
                                roslyn.AppendLine($"\t\t\t\tnew listedValue(\"{listedValueLabel}\", \"{multiline[0]}\" +");
                                for (int i = 1; i < multiline.Length - 1; i++)
                                    roslyn.AppendLine($"\t\t\t\t\t\t\t\t\t\t\"{multiline[i]}\" +");
                                roslyn.AppendLine($"\t\t\t\t\t\t\t\t\t\t\"{multiline[^1]}\",{listedValueCode}),");
                            }
                        }
                        roslyn.AppendLine($"\t\t\t];");
                        //roslyn.AppendLine($"\t\tpublic int? value {{ get; set; }} = default;");
                        roslyn.AppendLine($"\t}}");
                    }
                    else {
                        var prefix = valueType.ToLowerInvariant() switch {
                            "boolean" => "Boolean",
                            "real" => "double",
                            "text" => "String",
                            //"s100_truncateddate" => "DateOnly",
                            "s100_truncateddate" => "String",
                            "date" => "DateOnly",
                            "dateonly" => "DateOnly",
                            "datetime" => "DateTime",
                            "time" => "S100Framework.DomainModel.S100.Time",
                            "integer" => "int",
                            "urn" => "String",
                            "url" => "String",
                            "uri" => "String",
                            _ => throw new InvalidDataException(),
                        };

                        var type = valueType.ToLowerInvariant() switch {
                            "boolean" => "BooleanAttribute",
                            "real" => "RealAttribute",
                            "text" => "TextAttribute",
                            //"s100_truncateddate" => "DateOnly",
                            "s100_truncateddate" => "S100_TruncatedDateAttribute",
                            "date" => "DateAttribute",
                            "dateonly" => "DateOnlyAttribute",
                            "datetime" => "DateTimeAttribute",
                            "time" => "TimeAttribute",
                            "integer" => "IntegerAttribute",
                            "urn" => "UrnTimeAttribute",
                            "url" => "UrlTimeAttribute",
                            "uri" => "UriTimeAttribute",
                            _ => throw new InvalidDataException(),
                        };

                        attributesKnownTypes.Add(code, prefix);
                        roslyn.AppendLine($"\tpublic class {code} : S100Framework.AttributeModel.{type}");
                        roslyn.AppendLine($"\t{{");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override string S100FC_code => nameof({code});");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override string S100FC_name => \"{name}\";");
                        //roslyn.AppendLine("\t\t[JsonIgnore]");
                        //roslyn.AppendLine($"\t\tpublic override string valueType => \"{valueType}\";");
                        //roslyn.AppendLine($"\t\tpublic {prefix}? value {{ get; set; }} = default;");
                        roslyn.AppendLine();
                        roslyn.AppendLine($"\t\tpublic static implicit operator {code}({prefix}? value) => new {code} {{ value = value }};");
                        roslyn.AppendLine($"\t}}");
                    }
                    roslyn.AppendLine();
                }
                roslyn.AppendLine("}");
            }
            #endregion

            #region S100_FC_ComplexAttribute
            {
                var abstractTypesKnown = new List<string>();
                var complexTypesKnown = new List<string>();

                roslyn.AppendLine();
                roslyn.AppendLine($"namespace S100Framework.AttributeModel.{productId}.ComplexAttributes");
                roslyn.AppendLine("{");
                roslyn.AppendLine($"\tusing S100Framework.AttributeModel.{productId}.SimpleAttributes;");
                roslyn.AppendLine();

                var notFinished = false;
                do {
                    notFinished = false;
                    foreach (var element in ps.XPathSelectElements("//S100FC:S100_FC_ComplexAttribute", xmlNamespaceManager)) {
                        var code = element.Element(XName.Get("code", scopes["S100FC"]))!.Value;
                        var name = element.Element(XName.Get("name", scopes["S100FC"]))!.Value;
                        if (attributesKnown.Any(a => a.Equals(code)))
                            continue;

                        if (!element.XPathSelectElements("S100FC:subAttributeBinding", xmlNamespaceManager)
                            .All(attribute => attributesKnown.Any(a => a.Equals(attribute.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!)))) {
                            notFinished = true;
                            continue;
                        }

                        //foreach(var x in element.XPathSelectElements("S100FC:subAttributeBinding", xmlNamespaceManager)) {
                        //    var reference = x.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!;

                        //    if (!attributesKnown.Contains(reference))
                        //        System.Diagnostics.Debugger.Break();
                        //}

                        attributesKnown.Add(code);
                        attributesKnownComplex.Add(code);
                        attributesKnownTypes.Add(code, code);

                        derivedTypesAttributes.AppendLine($"\t\t\t\t\ttypeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof({code}), typeDiscriminator: \"{code}\"));");


                        var success = this.ClassBuilder(roslyn, element, "ComplexAttribute", new ClassBuilderHost {
                            KnownTypes = complexTypesKnown,
                            KnownTypesAbstract = abstractTypesKnown,
                            KnownTypesComplex = attributesKnownComplex,
                            KnownAttributeTypes = attributesKnownTypes,
                            Attributes = element.XPathSelectElements("S100FC:subAttributeBinding", xmlNamespaceManager),
                        });
                        if (!success) {
                            notFinished = true;
                            continue;
                        }
                    }
                } while (notFinished);
                roslyn.AppendLine("}");
            }
            #endregion

            #region S100_FC_InformationAssociation
            var informationAssociationTypesKnown = new List<string>();
            {
                var abstractTypesKnown = new List<string>();

                roslyn.AppendLine();
                roslyn.AppendLine($"namespace S100Framework.AttributeModel.{productId}.InformationAssociation");
                roslyn.AppendLine("{");
                roslyn.AppendLine($"\tusing S100Framework.AttributeModel.{productId}.SimpleAttributes;");
                roslyn.AppendLine($"\tusing S100Framework.AttributeModel.{productId}.ComplexAttributes;");
                roslyn.AppendLine();

                foreach (var element in ps.XPathSelectElements("//S100FC:S100_FC_InformationAssociation", xmlNamespaceManager)) {
                    var code = element.Element(XName.Get("code", scopes["S100FC"]))!.Value;
                    var name = element.Element(XName.Get("name", scopes["S100FC"]))!.Value;

                    var role = element.Element(XName.Get("role", scopes["S100FC"]))!.Attribute("ref")!.Value;

                    var success = this.ClassBuilder(roslyn, element, "InformationAssociation", new ClassBuilderHost {
                        KnownTypes = informationAssociationTypesKnown,
                        KnownTypesAbstract = abstractTypesKnown,
                        KnownTypesComplex = attributesKnownComplex,
                        KnownAttributeTypes = attributesKnownTypes,
                        Attributes = element.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager),
                    }, (b) => {
                        b.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override string role => \"{role}\";");
                    });
                    if (!success) {
                        throw new InvalidOperationException();
                    }

                    derivedTypesInformationBindings.AppendLine($"\t\t\t\t\ttypeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.{code}>), typeDiscriminator: \"{code}\"));");
                }
                roslyn.AppendLine("}");
            }
            #endregion

            #region S100_FC_FeatureAssociation
            var featureAssociationTypesKnown = new List<string>();
            {
                var abstractTypesKnown = new List<string>();

                roslyn.AppendLine();
                roslyn.AppendLine($"namespace S100Framework.AttributeModel.{productId}.FeatureAssociation");
                roslyn.AppendLine("{");
                roslyn.AppendLine($"\tusing S100Framework.AttributeModel.{productId}.SimpleAttributes;");
                roslyn.AppendLine($"\tusing S100Framework.AttributeModel.{productId}.ComplexAttributes;");
                roslyn.AppendLine();

                foreach (var element in ps.XPathSelectElements("//S100FC:S100_FC_FeatureAssociation", xmlNamespaceManager)) {
                    var code = element.Element(XName.Get("code", scopes["S100FC"]))!.Value;
                    var name = element.Element(XName.Get("name", scopes["S100FC"]))!.Value;

                    var roles = element.Elements(XName.Get("role", scopes["S100FC"])).Select(e => e.Attribute("ref")!.Value).Select(e => $"\"{e}\"");

                    var success = this.ClassBuilder(roslyn, element, "FeatureAssociation", new ClassBuilderHost {
                        KnownTypes = featureAssociationTypesKnown,
                        KnownTypesAbstract = abstractTypesKnown,
                        KnownTypesComplex = attributesKnownComplex,
                        KnownAttributeTypes = attributesKnownTypes,
                        Attributes = element.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager),
                    }, (b) => {
                        b.AppendLine("\t\t[JsonIgnore]");
                        b.AppendLine($"\t\tpublic override string[] roles => [{string.Join(',', roles)}];");
                    });
                    if (!success) {
                        throw new InvalidOperationException();
                    }

                    derivedTypesFeatureBindings.AppendLine($"\t\t\t\t\ttypeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.{code}>), typeDiscriminator: \"{code}\"));");
                }
                roslyn.AppendLine("}");
            }
            #endregion

            #region S100_FC_InformationType
            var informationTypesKnown = new List<string>();
            {
                var abstractTypesKnown = new List<string>();

                roslyn.AppendLine();
                roslyn.AppendLine($"namespace S100Framework.AttributeModel.{productId}.InformationTypes");
                roslyn.AppendLine("{");
                roslyn.AppendLine($"\tusing S100Framework.AttributeModel.{productId}.SimpleAttributes;");
                roslyn.AppendLine($"\tusing S100Framework.AttributeModel.{productId}.ComplexAttributes;");
                roslyn.AppendLine();

                var notFinished = false;
                do {
                    notFinished = false;
                    foreach (var element in ps.XPathSelectElements("//S100FC:S100_FC_InformationType", xmlNamespaceManager)) {
                        var success = this.ClassBuilder(roslyn, element, "InformationType", new ClassBuilderHost {
                            KnownTypes = informationTypesKnown,
                            KnownTypesAbstract = abstractTypesKnown,
                            KnownTypesComplex = attributesKnownComplex,
                            KnownAttributeTypes = attributesKnownTypes,
                            Attributes = element.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager),
                        });
                        if (!success) {
                            notFinished = true;
                            continue;
                        }
                    }
                } while (notFinished);
                roslyn.AppendLine("}");
            }
            #endregion

            var featureBindingsCreatorKeys = new List<string>();
            var featureBindingsCreator = new StringBuilder();

            #region S100_FC_FeatureType
            var featureTypesKnown = new List<string>();
            {
                var abstractTypesKnown = new List<string>();

                roslyn.AppendLine();
                roslyn.AppendLine($"namespace S100Framework.AttributeModel.{productId}.FeatureTypes");
                roslyn.AppendLine("{");
                roslyn.AppendLine($"\tusing S100Framework.AttributeModel.{productId}.SimpleAttributes;");
                roslyn.AppendLine($"\tusing S100Framework.AttributeModel.{productId}.ComplexAttributes;");
                roslyn.AppendLine($"\tusing S100Framework.AttributeModel.{productId}.InformationTypes;");
                roslyn.AppendLine();

                var notFinished = false;
                do {
                    notFinished = false;
                    foreach (var element in ps.XPathSelectElements("//S100FC:S100_FC_FeatureType", xmlNamespaceManager)) {
                        var success = this.ClassBuilder(roslyn, element, "FeatureType", new ClassBuilderHost {
                            KnownTypes = featureTypesKnown,
                            KnownTypesAbstract = abstractTypesKnown,
                            KnownTypesComplex = attributesKnownComplex,
                            KnownAttributeTypes = attributesKnownTypes,
                            Attributes = element.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager),
                        }, (b) => {

                        }, (b) => {
                            //  permittedPrimitives
                            var permittedValues = element.XPathSelectElements("S100FC:permittedPrimitives", xmlNamespaceManager).Select(e => $"Primitives.{e.Value!}");
                            if (permittedValues.Any()) {
                                b.AppendLine();
                                b.AppendLine($"\t\tpublic override Primitives[] permittedPrimitives => [{string.Join(',', permittedValues)}];");
                            }
                        });
                        if (!success) {
                            notFinished = true;
                            continue;
                        }
                    }
                } while (notFinished);
                roslyn.AppendLine("}");
            }
            #endregion

            #region Helpers
            {
                roslyn.AppendLine();
                roslyn.AppendLine($"namespace S100Framework.AttributeModel.{productId}");
                roslyn.AppendLine("{");
                roslyn.AppendLine($"\tusing System.Text.Json;");
                roslyn.AppendLine($"\tusing S100Framework.AttributeModel.{productId}.SimpleAttributes;");
                roslyn.AppendLine($"\tusing S100Framework.AttributeModel.{productId}.ComplexAttributes;");
                roslyn.AppendLine($"\tusing S100Framework.AttributeModel.{productId}.FeatureAssociation;");
                roslyn.AppendLine($"\tusing S100Framework.AttributeModel.{productId}.FeatureTypes;");
                roslyn.AppendLine();

                roslyn.AppendLine("\tpublic class Summary : ISummary");
                roslyn.AppendLine("\t{");
                roslyn.AppendLine($"\t\tpublic static string Name => \"{ps.XPathSelectElement("//S100FC:name", xmlNamespaceManager)!.Value}\";");
                roslyn.AppendLine($"\t\tpublic static string Scope => \"{ps.XPathSelectElement("//S100FC:scope", xmlNamespaceManager)!.Value}\";");
                roslyn.AppendLine($"\t\tpublic static string ProductId => \"{ps.XPathSelectElement("//S100FC:productId", xmlNamespaceManager)!.Value}\";");
                roslyn.AppendLine($"\t\tpublic static Version Version => new Version(\"{versionNumber}\");");
                roslyn.AppendLine($"\t\tpublic static DateOnly VersionDate => DateOnly.ParseExact(\"{versionDate}\", \"yyyy-MM-dd\");");

                var types = attributesKnownComplex.Select(e => $"\"{e}\"");
                roslyn.AppendLine($"\t\tpublic static string[] ComplexTypes => [{string.Join(',', types)}];");

                types = informationAssociationTypesKnown.Select(e => $"\"{e}\"");
                roslyn.AppendLine($"\t\tpublic static string[] InformationAssociationTypes => [{string.Join(',', types)}];");

                types = featureAssociationTypesKnown.Select(e => $"\"{e}\"");
                roslyn.AppendLine($"\t\tpublic static string[] FeatureAssociationTypes => [{string.Join(',', types)}];");

                types = informationTypesKnown.Select(e => $"\"{e}\"");
                roslyn.AppendLine($"\t\tpublic static string[] InformationTypes => [{string.Join(',', types)}];");

                types = informationTypesKnown.Select(e => $"\"{e}\"");
                roslyn.AppendLine($"\t\tpublic static string[] FeatureTypes => [{string.Join(',', types)}];");

                roslyn.AppendLine("\t}");
                roslyn.AppendLine();

                roslyn.AppendLine("\tpublic static class Extensions {");
                roslyn.AppendLine("\t\tpublic static JsonSerializerOptions AppendTypeInfoResolver(this JsonSerializerOptions jsonSerializerOptions) {");
                roslyn.AppendLine("\t\t\tvar resolver = new System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver();");
                roslyn.AppendLine("\t\t\tresolver.Modifiers.Add(typeInfo => {");

                roslyn.AppendLine("\t\t\t\tif (typeInfo.Type == typeof(S100Framework.AttributeModel.informationBinding)) {");
                roslyn.AppendLine("\t\t\t\t\ttypeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {");
                roslyn.AppendLine("\t\t\t\t\t\tTypeDiscriminatorPropertyName = \"code\",");
                roslyn.AppendLine("\t\t\t\t\t\tIgnoreUnrecognizedTypeDiscriminators = true,");
                roslyn.AppendLine("\t\t\t\t\t};");
                roslyn.Append(derivedTypesInformationBindings.ToString());
                roslyn.AppendLine("\t\t\t\t}");

                roslyn.AppendLine("\t\t\t\tif (typeInfo.Type == typeof(S100Framework.AttributeModel.featureBinding)) {");
                roslyn.AppendLine("\t\t\t\t\ttypeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {");
                roslyn.AppendLine("\t\t\t\t\t\tTypeDiscriminatorPropertyName = \"code\",");
                roslyn.AppendLine("\t\t\t\t\t\tIgnoreUnrecognizedTypeDiscriminators = true,");
                roslyn.AppendLine("\t\t\t\t\t};");
                roslyn.Append(derivedTypesFeatureBindings.ToString());
                roslyn.AppendLine("\t\t\t\t}");

                roslyn.AppendLine("\t\t\t\tif (typeInfo.Type == typeof(S100Framework.AttributeModel.attributeBinding)) {");
                roslyn.AppendLine("\t\t\t\t\ttypeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {");
                roslyn.AppendLine("\t\t\t\t\t\tTypeDiscriminatorPropertyName = \"code\",");
                roslyn.AppendLine("\t\t\t\t\t\tIgnoreUnrecognizedTypeDiscriminators = true,");
                roslyn.AppendLine("\t\t\t\t\t};");
                roslyn.Append(derivedTypesAttributes.ToString());
                roslyn.AppendLine("\t\t\t\t}");

                roslyn.AppendLine("\t\t\t});");
                roslyn.AppendLine("\t\t\tjsonSerializerOptions.TypeInfoResolver = resolver;");
                roslyn.AppendLine("\t\t\treturn jsonSerializerOptions;");
                roslyn.AppendLine("\t\t}");

                //  featureBindings
                //roslyn.AppendLine();
                //roslyn.AppendLine("\t\tpublic static (featureBinding primary, featureBinding foreign) CreateFeatureBinding(FeatureType primary, FeatureType foreign) {");
                //roslyn.AppendLine("\t\t\tvar key = $\"{primary.S100FC_code}::{foreign.S100FC_code}\";");
                //roslyn.AppendLine("\t\t\tvar primaryBinding = featureBindings[$\"{primary.S100FC_code}::{foreign.S100FC_code}\"]();");
                //roslyn.AppendLine("\t\t\tvar foreignBinding = featureBindings[$\"{foreign.S100FC_code}::{primary.S100FC_code}\"]();");
                //roslyn.AppendLine("\t\t\treturn (primaryBinding, foreignBinding);");
                //roslyn.AppendLine("\t\t}");
                //roslyn.AppendLine();
                //roslyn.AppendLine("\t\tprivate static Dictionary<string, Func<featureBinding>> featureBindings = new Dictionary<string, Func<featureBinding>> {");
                //roslyn.Append(featureBindingsCreator.ToString());
                //roslyn.AppendLine("\t\t};");


                roslyn.AppendLine("\t}");
                roslyn.AppendLine("}");
            }
            #endregion

            return roslyn;
        }

        public class ClassBuilderHost
        {
            public ICollection<string> KnownTypes { get; init; } = [];
            public ICollection<string> KnownTypesAbstract { get; init; } = [];
            public ICollection<string> KnownTypesComplex { get; init; } = [];
            public IDictionary<string, string> KnownAttributeTypes { get; init; } = new Dictionary<string, string>();

            public IEnumerable<XElement> Attributes { get; init; } = [];
        }

        private bool ClassBuilder(StringBuilder roslyn, XElement element, string type, ClassBuilderHost host, Action<StringBuilder>? pre = default, Action<StringBuilder>? post = default) {
            var navigator = element.CreateNavigator();
            navigator.MoveToFollowing(XPathNodeType.Element);

            var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var s in scopes)
                xmlNamespaceManager.AddNamespace(s.Key, s.Value);

            var code = element.Element(XName.Get("code", scopes["S100FC"]))!.Value;
            var name = element.Element(XName.Get("name", scopes["S100FC"]))!.Value;
            if (host.KnownTypes.Any(a => a.Equals(code, StringComparison.InvariantCultureIgnoreCase)))
                return true;

            var baseClass = $"S100Framework.AttributeModel.{type}";

            var superType = element.Elements(XName.Get("superType", scopes["S100FC"])).FirstOrDefault();
            if (superType != null) {
                if (!host.KnownTypes.Any(e => e.Equals(superType.Value, StringComparison.InvariantCultureIgnoreCase))) {
                    return false;
                }

                baseClass = $"{superType.Value}";
            }

            if (element.Attribute("isAbstract") != default && bool.Parse(element.Attribute("isAbstract")!.Value)) {
                host.KnownTypesAbstract.Add(code);
            }

            host.KnownTypes.Add(code);

            var definition = element.Element(XName.Get("definition", scopes["S100FC"]))!.Value;
            roslyn.AppendLine("\t/// <summary>");
            roslyn.AppendLine($"\t/// {definition}");
            roslyn.AppendLine("\t/// </summary>");

            roslyn.AppendLine($"\tpublic class {code} : {baseClass}");
            roslyn.AppendLine($"\t{{");
            roslyn.AppendLine("\t\t[JsonIgnore]");
            roslyn.AppendLine($"\t\tpublic override string S100FC_code => nameof({code});");
            roslyn.AppendLine("\t\t[JsonIgnore]");
            roslyn.AppendLine($"\t\tpublic override string S100FC_name => \"{name}\";");

            pre?.Invoke(roslyn);

            var hasAttributes = host.Attributes.Any();

            if (hasAttributes) {
                roslyn.AppendLine();
                roslyn.AppendLine("\t\t#region Attributes");
                foreach (var attributeBinding in host.Attributes) {
                    var referenceCode = attributeBinding.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                    var permittedValues = attributeBinding.XPathSelectElement("S100FC:permittedValues", xmlNamespaceManager);
                    var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                    var _ = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                    int upper = (_.Attribute(XName.Get("infinite")) != default && _.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? int.MaxValue : int.Parse(_.Value!);

                    var prefix = (lower > 1 || upper > 1) ? $"{host.KnownAttributeTypes[referenceCode]}?[]" : $"{host.KnownAttributeTypes[referenceCode]}?";

                    if (host.KnownTypesComplex.Contains(referenceCode)) {
                        roslyn.AppendLine($"\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic {prefix} {referenceCode} {{");
                        roslyn.AppendLine($"\t\t\tset {{ base.SetAttribute(value); }}");
                        if (upper > 1)
                            roslyn.AppendLine($"\t\t\tget {{ return base.GetAttributeValues<{referenceCode}>(nameof({referenceCode})); }}");
                        else
                            roslyn.AppendLine($"\t\t\tget {{ return base.GetAttributeValue<{referenceCode}>(nameof({referenceCode})); }}");
                        roslyn.AppendLine($"\t\t}}");
                    }
                    else {
                        var postfix = "?";
                        //if (lower >= 1)
                        //    postfix = "!";

                        roslyn.AppendLine($"\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic {prefix} {referenceCode} {{");
                        if (upper > 1) {
                            roslyn.AppendLine($"\t\t\tset {{ base.SetAttribute([.. value.Select(e=> new {referenceCode} {{ value = e }})]); }}");
                            roslyn.AppendLine($"\t\t\tget {{ return base.GetAttributeValues<{referenceCode}>(nameof({referenceCode})).Select(e=>e.value).ToArray(); }}");
                        }
                        else {
                            roslyn.AppendLine($"\t\t\tset {{ base.SetAttribute(new {referenceCode} {{ value = value }}); }}");
                            roslyn.AppendLine($"\t\t\tget {{ return base.GetAttributeValue<{referenceCode}>(nameof({referenceCode})){postfix}.value; }}");
                        }
                        roslyn.AppendLine($"\t\t}}");
                    }
                }
                roslyn.AppendLine("\t\t#endregion");
            }

            roslyn.AppendLine();
            roslyn.AppendLine("\t\t#region Catalogue");

            if (hasAttributes) {
                roslyn.AppendLine("\t\t[JsonIgnore]");
                roslyn.AppendLine($"\t\tpublic override attributeBindingDefinition[] attributeBindingsCatalogue => [");
                if (superType != null) {
                    roslyn.AppendLine("\t\t\t\t.. base.attributeBindingsCatalogue,");
                }
                foreach (var attributeBinding in host.Attributes) {
                    var referenceCode = attributeBinding.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                    var permittedValues = attributeBinding.XPathSelectElement("S100FC:permittedValues", xmlNamespaceManager);
                    var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                    var _ = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                    int upper = (_.Attribute(XName.Get("infinite")) != default && _.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? int.MaxValue : int.Parse(_.Value!);

                    roslyn.AppendLine($"\t\t\t\tnew attributeBindingDefinition {{");
                    roslyn.AppendLine($"\t\t\t\t\tattribute = nameof({referenceCode}),");
                    roslyn.AppendLine($"\t\t\t\t\tlower = {lower},");
                    roslyn.AppendLine($"\t\t\t\t\tupper = {upper},");
                    if (permittedValues is not null)
                        roslyn.AppendLine($"\t\t\t\t\tpermitedValues = [{string.Join(',', permittedValues.XPathSelectElements("S100FC:value", xmlNamespaceManager).Select(e => $"{e.Value}"))}],");
                    roslyn.AppendLine($"\t\t\t\t\tCreateInstance = () => new {referenceCode}(),");
                    roslyn.AppendLine($"\t\t\t\t}},");
                }
                roslyn.AppendLine($"\t\t\t];");
                roslyn.AppendLine();
            }

            var informationBindings = element.XPathSelectElements("S100FC:informationBinding", xmlNamespaceManager);
            if (informationBindings.Any()) {
                roslyn.AppendLine("\t\t[JsonIgnore]");
                roslyn.AppendLine($"\t\tpublic override informationBindingDefinition[] informationBindingsCatalogue => [");
                if (superType != null) {
                    roslyn.AppendLine("\t\t\t\t.. base.informationBindingsCatalogue,");
                }

                foreach (var informationBinding in informationBindings) {
                    var association = informationBinding.Element(XName.Get("association", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                    var role = informationBinding.Element(XName.Get("role", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                    var roleType = informationBinding.Attribute("roleType")!.Value!;

                    var lower = int.Parse(informationBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                    var _ = informationBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                    int upper = (_.Attribute(XName.Get("infinite")) != default && _.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? int.MaxValue : int.Parse(_.Value!);

                    var informationTypes = informationBinding.XPathSelectElements("S100FC:informationType", xmlNamespaceManager);

                    roslyn.AppendLine($"\t\t\t\tnew informationBindingDefinition {{");
                    roslyn.AppendLine($"\t\t\t\t\troleType = \"{roleType}\",");
                    roslyn.AppendLine($"\t\t\t\t\trole = \"{role}\",");
                    roslyn.AppendLine($"\t\t\t\t\tassociation = \"{association}\",");
                    roslyn.AppendLine($"\t\t\t\t\tlower = {lower},");
                    roslyn.AppendLine($"\t\t\t\t\tupper = {upper},");
                    roslyn.AppendLine($"\t\t\t\t\tinformationTypes = [{string.Join(',', informationTypes.Select(e => $"nameof({e.Attribute("ref")!.Value})"))}],");
                    roslyn.AppendLine($"\t\t\t\t}},");
                }
                roslyn.AppendLine($"\t\t\t];");
                roslyn.AppendLine();
            }

            var featureBindings = element.XPathSelectElements("S100FC:featureBinding", xmlNamespaceManager);
            if (featureBindings.Any()) {
                roslyn.AppendLine("\t\t[JsonIgnore]");
                roslyn.AppendLine($"\t\tpublic override featureBindingDefinition[] featureBindingsCatalogue => [");
                if (superType != null) {
                    roslyn.AppendLine("\t\t\t\t.. base.featureBindingsCatalogue,");
                }

                foreach (var featureBinding in featureBindings) {
                    var association = featureBinding.Element(XName.Get("association", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                    var role = featureBinding.Element(XName.Get("role", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                    var roleType = featureBinding.Attribute("roleType")!.Value!;

                    var lower = int.Parse(featureBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                    var _ = featureBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                    int upper = (_.Attribute(XName.Get("infinite")) != default && _.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? int.MaxValue : int.Parse(_.Value!);

                    var featureTypes = featureBinding.XPathSelectElements("S100FC:featureType", xmlNamespaceManager);

                    roslyn.AppendLine($"\t\t\t\tnew featureBindingDefinition {{");
                    roslyn.AppendLine($"\t\t\t\t\troleType = \"{roleType}\",");
                    roslyn.AppendLine($"\t\t\t\t\trole = \"{role}\",");
                    roslyn.AppendLine($"\t\t\t\t\tassociation = \"{association}\",");
                    roslyn.AppendLine($"\t\t\t\t\tlower = {lower},");
                    roslyn.AppendLine($"\t\t\t\t\tupper = {upper},");
                    roslyn.AppendLine($"\t\t\t\t\tfeatureTypes = [{string.Join(',', featureTypes.Select(e => $"nameof({e.Attribute("ref")!.Value})"))}],");
                    roslyn.AppendLine($"\t\t\t\t}},");
                }
                roslyn.AppendLine($"\t\t\t];");
                roslyn.AppendLine();
            }

            roslyn.AppendLine("\t\t#endregion");

            post?.Invoke(roslyn);

            roslyn.AppendLine($"\t}}");
            roslyn.AppendLine();

            //foreach (var featureBinding in element.XPathSelectElements("S100FC:featureBinding", xmlNamespaceManager)) {
            //    var association = featureBinding.Element(XName.Get("association", scopes["S100FC"]))!.Attribute("ref")!.Value!;
            //    var role = featureBinding.Element(XName.Get("role", scopes["S100FC"]))!.Attribute("ref")!.Value!;
            //    var roleType = featureBinding.Attribute("roleType")!.Value!;

            //    foreach (var e in featureBinding.XPathSelectElements("S100FC:featureType", xmlNamespaceManager)) {
            //        var featureType = e.Attribute("ref")!.Value!;

            //        //if (!featureBindingsCreatorKeys.Contains($"{code}::{featureType}")) {
            //        //    featureBindingsCreatorKeys.Add($"{code}::{featureType}");
            //        //    featureBindingsCreator.AppendLine($"\t\t\t{{ \"{code}::{featureType}\", () => new featureBinding<{association}> {{ role = \"{role}\", roleType=\"{roleType}\", }} }},");
            //        //}
            //    }
            //}
            return true;
        }
    }
}

namespace Test
{
    public static class Extensions
    {
        public static JsonSerializerOptions AppendTypeInfoResolver(this JsonSerializerOptions jsonSerializerOptions) {
            return jsonSerializerOptions;
        }
        //JsonSerializerOptions
    }
}