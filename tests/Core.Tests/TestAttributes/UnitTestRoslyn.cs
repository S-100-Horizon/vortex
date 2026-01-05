using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Xunit.Abstractions;

namespace TestAttributes
{
    using S100Framework.DomainModel;
    using System.Reflection;
    using System.Security.Cryptography;
    using System.Text.Json.Serialization;

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

        private StringBuilder RoslynBuilder(XDocument ps) {
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

            var versionNumber = ps.XPathSelectElement("//S100FC:versionNumber", xmlNamespaceManager)!.Value;
            var versionDate = ps.XPathSelectElement("//S100FC:versionDate", xmlNamespaceManager)!.Value;

            var attributesKnown = new List<string>();

            var attributesKnownTypes = new Dictionary<string, string>();

            var attributesKnownComplex = new List<string>();

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
                        roslyn.AppendLine($"\tpublic class {code} : S100Framework.AttributeModel.SimpleEnumerationAttribute");
                        roslyn.AppendLine($"\t{{");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override string S100FC_code => nameof({code});");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override string S100FC_name => \"{name}\";");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override listedValue[] listedValues => [");

                        foreach (var listedValue in element.Element(XName.Get("listedValues", scopes["S100FC"]))!.Elements()) {
                            var listedValueLabel = listedValue.Element(XName.Get("label", scopes["S100FC"]))!.Value!;
                            var listedValueDefinition = listedValue.Element(XName.Get("definition", scopes["S100FC"]))!.Value!;
                            var listedValueCode = listedValue.Element(XName.Get("code", scopes["S100FC"]))!.Value!;

                            listedValueDefinition = listedValueDefinition.Replace("\"", "\\\"");

                            roslyn.AppendLine($"\t\t\t\tnew listedValue(\"{listedValueLabel}\", \"{listedValueDefinition}\",{listedValueCode}),");
                        }
                        roslyn.AppendLine($"\t\t\t];");
                        roslyn.AppendLine($"\t\tpublic int? value {{ get; set; }} = default;");
                        roslyn.AppendLine();
                        roslyn.AppendLine($"\t\tpublic static implicit operator {code}(int? value) => new {code} {{ value = value }};");
                        roslyn.AppendLine($"\t}}");
                    }
                    else if (valueType.Equals("S100_CodeList")) {
                        attributesKnownTypes.Add(code, "int");
                        roslyn.AppendLine($"\tpublic class {code} : S100Framework.AttributeModel.SimpleEnumerationAttribute");
                        roslyn.AppendLine($"\t{{");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override string S100FC_code => nameof({code});");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override string S100FC_name => \"{name}\";");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override listedValue[] listedValues => [");

                        foreach (var listedValue in element.Element(XName.Get("listedValues", scopes["S100FC"]))!.Elements()) {
                            var listedValueLabel = listedValue.Element(XName.Get("label", scopes["S100FC"]))!.Value!;
                            var listedValueDefinition = listedValue.Element(XName.Get("definition", scopes["S100FC"]))!.Value!;
                            var listedValueCode = listedValue.Element(XName.Get("code", scopes["S100FC"]))!.Value!;

                            listedValueDefinition = listedValueDefinition.Replace("\"", "\\\"");

                            roslyn.AppendLine($"\t\t\t\tnew listedValue(\"{listedValueLabel}\", \"{listedValueDefinition}\",{listedValueCode}),");
                        }
                        roslyn.AppendLine($"\t\t\t];");
                        roslyn.AppendLine($"\t\tpublic int? value {{ get; set; }} = default;");
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
                        attributesKnownTypes.Add(code, prefix);
                        roslyn.AppendLine($"\tpublic class {code} : S100Framework.AttributeModel.SimpleAttribute");
                        roslyn.AppendLine($"\t{{");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override string S100FC_code => nameof({code});");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override string S100FC_name => \"{name}\";");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override string valueType => \"{valueType}\";");
                        roslyn.AppendLine($"\t\tpublic {prefix}? value {{ get; set; }} = default;");
                        roslyn.AppendLine();
                        roslyn.AppendLine($"\t\tpublic static implicit operator {code}({prefix} value) => new {code} {{ value = value }};");
                        roslyn.AppendLine($"\t}}");
                    }
                    roslyn.AppendLine();
                }
                roslyn.AppendLine("}");
            }
            #endregion

            #region S100_FC_ComplexAttribute
            {
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

                        var definition = element.Element(XName.Get("definition", scopes["S100FC"]))!.Value;
                        roslyn.AppendLine("\t/// <summary>");
                        roslyn.AppendLine($"\t/// {definition}");
                        roslyn.AppendLine("\t/// </summary>");

                        roslyn.AppendLine($"\tpublic class {code} : S100Framework.AttributeModel.ComplexAttribute");
                        roslyn.AppendLine($"\t{{");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override string S100FC_code => nameof({code});");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override string S100FC_name => \"{name}\";");

                        foreach (var subAttributeBinding in element.XPathSelectElements("S100FC:subAttributeBinding", xmlNamespaceManager)) {
                            var referenceCode = subAttributeBinding.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                            var lower = int.Parse(subAttributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);

                            if (lower > 1) {
                                for (int i = 0; i < lower; i++) {
                                    //roslyn.AppendLine("\t\t[JsonIgnore]");
                                    roslyn.AppendLine($"\t\tpublic {referenceCode} {referenceCode}{i + 1} {{ get; init; }} = new {referenceCode}();");
                                }
                            }
                            else if (lower == 1) {
                                //roslyn.AppendLine("\t\t[JsonIgnore]");
                                roslyn.AppendLine($"\t\tpublic {referenceCode} {referenceCode} {{ get; init; }} = new {referenceCode}();");
                            }
                        }

                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override Attribute[] attributes => [");
                        foreach (var subAttributeBinding in element.XPathSelectElements("S100FC:subAttributeBinding", xmlNamespaceManager)) {
                            var referenceCode = subAttributeBinding.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                            var lower = int.Parse(subAttributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);

                            if (lower > 1) {
                                for (int i = 0; i < lower; i++)
                                    roslyn.AppendLine($"\t\t\t\t{referenceCode}{i + 1},");
                            }
                            else if (lower == 1) {
                                roslyn.AppendLine($"\t\t\t\t{referenceCode},");
                            }
                        }
                        roslyn.AppendLine("\t\t\t\t.. base.attributesOptional,");
                        roslyn.AppendLine($"\t\t\t];");

                        roslyn.AppendLine($"\t\tpublic override AttributeBinding[] attributeBindings() => [");
                        foreach (var subAttributeBinding in element.XPathSelectElements("S100FC:subAttributeBinding", xmlNamespaceManager)) {
                            var referenceCode = subAttributeBinding.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                            var permittedValues = subAttributeBinding.XPathSelectElement("S100FC:permittedValues", xmlNamespaceManager);
                            var lower = int.Parse(subAttributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                            var _ = subAttributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                            int upper = (_.Attribute(XName.Get("infinite")) != default && _.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? int.MaxValue : int.Parse(_.Value!);

                            roslyn.AppendLine($"\t\t\t\tnew AttributeBinding {{");
                            roslyn.AppendLine($"\t\t\t\t\tattribute = nameof({referenceCode}),");
                            roslyn.AppendLine($"\t\t\t\t\tlower = {lower},");
                            roslyn.AppendLine($"\t\t\t\t\tupper = {upper},");
                            if (permittedValues is not null)
                                roslyn.AppendLine($"\t\t\t\t\tpermitedValues = [{string.Join(',', permittedValues.XPathSelectElements("S100FC:value", xmlNamespaceManager).Select(e => $"{e.Value}"))}],");
                            roslyn.AppendLine($"\t\t\t\t\tCreateInstance = () => new {referenceCode}(),");
                            //roslyn.AppendLine($"\t\t\t\t\tFreeSeats =");
                            roslyn.AppendLine($"\t\t\t\t}},");
                        }
                        roslyn.AppendLine($"\t\t\t];");

                        roslyn.AppendLine();
                        roslyn.AppendLine("\t\t#region Optional Attributes");
                        foreach (var subAttributeBinding in element.XPathSelectElements("S100FC:subAttributeBinding", xmlNamespaceManager)) {
                            var referenceCode = subAttributeBinding.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                            var permittedValues = subAttributeBinding.XPathSelectElement("S100FC:permittedValues", xmlNamespaceManager);
                            var lower = int.Parse(subAttributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                            var _ = subAttributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                            int upper = (_.Attribute(XName.Get("infinite")) != default && _.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? int.MaxValue : int.Parse(_.Value!);

                            if (!(lower == 0 && upper == 1))
                                continue;

                            var prefix = attributesKnownTypes[referenceCode];
                            if (attributesKnownComplex.Contains(referenceCode))
                                roslyn.AppendLine($"\t\tpublic {prefix}? {referenceCode} {{ set {{ base.AddAttributeValue(value); }} }}");
                            else
                                roslyn.AppendLine($"\t\tpublic {prefix}? {referenceCode} {{ set {{ base.AddAttributeValue(new {referenceCode} {{ value = value }}); }} }}");
                        }
                        roslyn.AppendLine("\t\t#endregion");

                        roslyn.AppendLine($"\t}}");
                        roslyn.AppendLine();
                    }
                } while (notFinished);
                roslyn.AppendLine("}");
            }
            #endregion

            #region S100_FC_InformationType
            {
                var abstractTypesKnown = new List<string>();
                var featureTypesKnown = new List<string>();

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
                        var code = element.Element(XName.Get("code", scopes["S100FC"]))!.Value;
                        var name = element.Element(XName.Get("name", scopes["S100FC"]))!.Value;
                        if (featureTypesKnown.Any(a => a.Equals(code)))
                            continue;

                        var superType = element.Elements(XName.Get("superType", scopes["S100FC"])).FirstOrDefault();
                        if (superType != null) {
                            if (!featureTypesKnown.Contains(superType.Value)) {
                                notFinished = true;
                                continue;
                            }
                        }

                        if (element.Attribute("isAbstract") != default && bool.Parse(element.Attribute("isAbstract")!.Value)) {
                            abstractTypesKnown.Add(code);
                        }

                        featureTypesKnown.Add(code);

                        var definition = element.Element(XName.Get("definition", scopes["S100FC"]))!.Value;
                        roslyn.AppendLine("\t/// <summary>");
                        roslyn.AppendLine($"\t/// {definition}");
                        roslyn.AppendLine("\t/// </summary>");

                        roslyn.AppendLine($"\tpublic class {code} : S100Framework.AttributeModel.InformationType");
                        roslyn.AppendLine($"\t{{");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override string S100FC_code => nameof({code});");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override string S100FC_name => \"{name}\";");

                        foreach (var attributeBinding in element.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                            var referenceCode = attributeBinding.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                            var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);

                            if (lower > 1) {
                                for (int i = 0; i < lower; i++) {
                                    //roslyn.AppendLine("\t\t[JsonIgnore]");
                                    roslyn.AppendLine($"\t\tpublic {referenceCode} {referenceCode}{i + 1} {{ get; init; }} = new {referenceCode}();");
                                }
                            }
                            else if (lower == 1) {
                                //roslyn.AppendLine("\t\t[JsonIgnore]");
                                roslyn.AppendLine($"\t\tpublic {referenceCode} {referenceCode} {{ get; init; }} = new {referenceCode}();");
                            }
                        }

                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override Attribute[] attributes => [");
                        foreach (var attributeBinding in element.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                            var referenceCode = attributeBinding.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                            var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);

                            if (lower > 1) {
                                for (int i = 0; i < lower; i++)
                                    roslyn.AppendLine($"\t\t\t\t{referenceCode}{i + 1},");
                            }
                            else if (lower == 1) {
                                roslyn.AppendLine($"\t\t\t\t{referenceCode},");
                            }
                        }
                        roslyn.AppendLine("\t\t\t\t.. base.attributesOptional,");
                        roslyn.AppendLine($"\t\t\t];");

                        roslyn.AppendLine($"\t\tpublic override AttributeBinding[] attributeBindings() => [");
                        foreach (var attributeBinding in element.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                            var referenceCode = attributeBinding.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                            var permittedValues = attributeBinding.XPathSelectElement("S100FC:permittedValues", xmlNamespaceManager);
                            var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                            var _ = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                            int upper = (_.Attribute(XName.Get("infinite")) != default && _.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? int.MaxValue : int.Parse(_.Value!);

                            roslyn.AppendLine($"\t\t\t\tnew AttributeBinding {{");
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
                        roslyn.AppendLine("\t\t#region Optional Attributes");
                        foreach (var attributeBinding in element.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                            var referenceCode = attributeBinding.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                            var permittedValues = attributeBinding.XPathSelectElement("S100FC:permittedValues", xmlNamespaceManager);
                            var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                            var _ = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                            int upper = (_.Attribute(XName.Get("infinite")) != default && _.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? int.MaxValue : int.Parse(_.Value!);

                            if (!(lower == 0 && upper == 1))
                                continue;

                            var prefix = attributesKnownTypes[referenceCode];
                            if (attributesKnownComplex.Contains(referenceCode))
                                roslyn.AppendLine($"\t\tpublic {prefix}? {referenceCode} {{ set {{ base.AddAttributeValue(value); }} }}");
                            else
                                roslyn.AppendLine($"\t\tpublic {prefix}? {referenceCode} {{ set {{ base.AddAttributeValue(new {referenceCode} {{ value = value }}); }} }}");
                        }
                        roslyn.AppendLine("\t\t#endregion");

                        roslyn.AppendLine($"\t}}");
                        roslyn.AppendLine();
                    }
                } while (notFinished);
                roslyn.AppendLine("}");
            }
            #endregion

            #region S100_FC_FeatureType
            {
                var abstractTypesKnown = new List<string>();
                var featureTypesKnown = new List<string>();

                roslyn.AppendLine();
                roslyn.AppendLine($"namespace S100Framework.AttributeModel.{productId}.FeatureTypes");
                roslyn.AppendLine("{");
                roslyn.AppendLine($"\tusing S100Framework.AttributeModel.{productId}.SimpleAttributes;");
                roslyn.AppendLine($"\tusing S100Framework.AttributeModel.{productId}.ComplexAttributes;");
                roslyn.AppendLine();

                var notFinished = false;
                do {
                    notFinished = false;
                    foreach (var element in ps.XPathSelectElements("//S100FC:S100_FC_FeatureType", xmlNamespaceManager)) {
                        var code = element.Element(XName.Get("code", scopes["S100FC"]))!.Value;
                        var name = element.Element(XName.Get("name", scopes["S100FC"]))!.Value;
                        if (featureTypesKnown.Any(a => a.Equals(code)))
                            continue;

                        var superType = element.Elements(XName.Get("superType", scopes["S100FC"])).FirstOrDefault();
                        if (superType != null) {
                            if (!featureTypesKnown.Contains(superType.Value)) {
                                notFinished = true;
                                continue;
                            }
                        }

                        if (element.Attribute("isAbstract") != default && bool.Parse(element.Attribute("isAbstract")!.Value)) {
                            abstractTypesKnown.Add(code);
                        }

                        featureTypesKnown.Add(code);

                        var definition = element.Element(XName.Get("definition", scopes["S100FC"]))!.Value;
                        roslyn.AppendLine("\t/// <summary>");
                        roslyn.AppendLine($"\t/// {definition}");
                        roslyn.AppendLine("\t/// </summary>");

                        roslyn.AppendLine($"\tpublic class {code} : S100Framework.AttributeModel.FeatureType");
                        roslyn.AppendLine($"\t{{");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override string S100FC_code => nameof({code});");
                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override string S100FC_name => \"{name}\";");

                        foreach (var attributeBinding in element.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                            var referenceCode = attributeBinding.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                            var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);

                            if (lower > 1) {
                                for (int i = 0; i < lower; i++) {
                                //    roslyn.AppendLine("\t\t[JsonIgnore]");
                                    roslyn.AppendLine($"\t\tpublic {referenceCode} {referenceCode}{i + 1} {{ get; init; }} = new {referenceCode}();");
                                }
                            }
                            else if (lower == 1) {
                                //roslyn.AppendLine("\t\t[JsonIgnore]");
                                roslyn.AppendLine($"\t\tpublic {referenceCode} {referenceCode} {{ get; init; }} = new {referenceCode}();");
                            }
                        }

                        roslyn.AppendLine("\t\t[JsonIgnore]");
                        roslyn.AppendLine($"\t\tpublic override Attribute[] attributes => [");
                        foreach (var attributeBinding in element.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                            var referenceCode = attributeBinding.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                            var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);

                            if (lower > 1) {
                                for (int i = 0; i < lower; i++)
                                    roslyn.AppendLine($"\t\t\t\t{referenceCode}{i + 1},");
                            }
                            else if (lower == 1) {
                                roslyn.AppendLine($"\t\t\t\t{referenceCode},");
                            }
                        }
                        roslyn.AppendLine("\t\t\t\t.. base.attributesOptional,");
                        roslyn.AppendLine($"\t\t\t];");

                        roslyn.AppendLine($"\t\tpublic override AttributeBinding[] attributeBindings() => [");
                        foreach (var attributeBinding in element.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                            var referenceCode = attributeBinding.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                            var permittedValues = attributeBinding.XPathSelectElement("S100FC:permittedValues", xmlNamespaceManager);
                            var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                            var _ = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                            int upper = (_.Attribute(XName.Get("infinite")) != default && _.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? int.MaxValue : int.Parse(_.Value!);

                            roslyn.AppendLine($"\t\t\t\tnew AttributeBinding {{");
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
                        roslyn.AppendLine("\t\t#region Optional Attributes");
                        foreach (var attributeBinding in element.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                            var referenceCode = attributeBinding.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                            var permittedValues = attributeBinding.XPathSelectElement("S100FC:permittedValues", xmlNamespaceManager);
                            var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                            var _ = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                            int upper = (_.Attribute(XName.Get("infinite")) != default && _.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? int.MaxValue : int.Parse(_.Value!);

                            if (!(lower == 0 && upper == 1))
                                continue;

                            var prefix = attributesKnownTypes[referenceCode];
                            if (attributesKnownComplex.Contains(referenceCode))
                                roslyn.AppendLine($"\t\tpublic {prefix}? {referenceCode} {{ set {{ base.AddAttributeValue(value); }} }}");
                            else
                                roslyn.AppendLine($"\t\tpublic {prefix}? {referenceCode} {{ set {{ base.AddAttributeValue(new {referenceCode} {{ value = value }}); }} }}");
                        }
                        roslyn.AppendLine("\t\t#endregion");

                        roslyn.AppendLine($"\t}}");
                        roslyn.AppendLine();
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
                roslyn.AppendLine($"\tusing S100Framework.AttributeModel.{productId}.FeatureTypes;");
                roslyn.AppendLine();

                roslyn.AppendLine("\tpublic class Summary : ISummary");
                roslyn.AppendLine("\t{");
                roslyn.AppendLine($"\t\tpublic static string Name => \"{ps.XPathSelectElement("//S100FC:name", xmlNamespaceManager)!.Value}\";");
                roslyn.AppendLine($"\t\tpublic static string Scope => \"{ps.XPathSelectElement("//S100FC:scope", xmlNamespaceManager)!.Value}\";");
                roslyn.AppendLine($"\t\tpublic static string ProductId => \"{ps.XPathSelectElement("//S100FC:productId", xmlNamespaceManager)!.Value}\";");
                roslyn.AppendLine($"\t\tpublic static Version Version => new Version(\"{versionNumber}\");");
                roslyn.AppendLine($"\t\tpublic static DateOnly VersionDate => DateOnly.ParseExact(\"{versionDate}\", \"yyyy-MM-dd\");");
                roslyn.AppendLine("\t}");
                roslyn.AppendLine();

                roslyn.AppendLine("\tpublic static class Extensions {");
                roslyn.AppendLine("\t\tpublic static JsonSerializerOptions AppendTypeInfoResolver(this JsonSerializerOptions jsonSerializerOptions) {");
                roslyn.AppendLine("\t\t\tvar resolver = new System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver();");
                roslyn.AppendLine("\t\t\tresolver.Modifiers.Add(typeInfo => {");

                roslyn.AppendLine("\t\t\t\tif (typeInfo.Type == typeof(S100Framework.AttributeModel.Attribute)) {");
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
                roslyn.AppendLine("\t}");

                roslyn.AppendLine("}");
            }
            #endregion

            return roslyn;
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