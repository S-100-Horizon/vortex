using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Xunit.Abstractions;

namespace TestAttributes
{
    using S100FC;
    using static System.Runtime.InteropServices.JavaScript.JSType;

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
            this.Test_S101_Build();
            this.Test_S122_Build();
            this.Test_S123_Build();
            this.Test_S124_Build();
            this.Test_S125_Build();
            this.Test_S127_Build();
            this.Test_S128_Build();
            this.Test_S131_Build();
            this.Test_S501_Build();
        }

        [Fact]
        public void Test_S101_Build() {
            var ps = XDocument.Load(System.IO.Path.Combine(this._iho, @"S-101-Documentation-and-FC\S-101FC\FeatureCatalogue.xml"));

            var navigator = ps.CreateNavigator();
            navigator.MoveToFollowing(XPathNodeType.Element);

            var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            
            var roslyn = this.RoslynBuilder(ps, supportingSpatialAssociation: true, validation: (code, attributes, builder) => {
                var references = attributes.Select(e => e.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!);
                
                if ("UnderwaterAwashRock".Equals(code)) {
                    builder.AppendLine();
                    builder.AppendLine("\t\tpublic override bool Validate(ICollection<string>? errors) {");
                    builder.AppendLine("\t\t\tif (!this.valueOfSounding.HasValue) {");
                    builder.AppendLine("\t\t\t\tif(!this.defaultClearanceDepth.HasValue) errors.Add(\"This attribute is mandatory for all Underwater/Awash Rock having mandatory attribute value of sounding populated with an empty (null) value.\");");
                    builder.AppendLine("\t\t\t\treturn this.defaultClearanceDepth.HasValue;");
                    builder.AppendLine("\t\t\t}");
                    builder.AppendLine("\t\t\treturn true;");
                    builder.AppendLine("\t\t}");
                }

                if ("Wreck".Equals(code)) {
                    builder.AppendLine();
                    builder.AppendLine("\t\tpublic override bool Validate(ICollection<string>? errors) {");
                    builder.AppendLine("\t\t\tif (!this.valueOfSounding.HasValue && !this.height.HasValue) {");
                    builder.AppendLine("\t\t\t\tif(!this.defaultClearanceDepth.HasValue) errors.Add(\"This attribute is mandatory for all Wreck having mandatory attributes height not populated and value of sounding populated with an empty (null) value.\");");
                    builder.AppendLine("\t\t\t\treturn this.defaultClearanceDepth.HasValue;");
                    builder.AppendLine("\t\t\t}");
                    builder.AppendLine("\t\t\treturn true;");
                    builder.AppendLine("\t\t}");
                }

                if ("Obstruction".Equals(code)) {
                    builder.AppendLine();
                    builder.AppendLine("\t\tpublic override bool Validate(ICollection<string>? errors) {");
                    builder.AppendLine("\t\t\tif (!this.valueOfSounding.HasValue && !this.height.HasValue) {");
                    builder.AppendLine("\t\t\t\tif(!this.defaultClearanceDepth.HasValue) errors.Add(\"This attribute is mandatory for all Obstruction having mandatory attributes height not populated and value of sounding populated with an empty (null) value.\");");
                    builder.AppendLine("\t\t\t\treturn this.defaultClearanceDepth.HasValue;");
                    builder.AppendLine("\t\t\t}");
                    builder.AppendLine("\t\t\treturn true;");
                    builder.AppendLine("\t\t}");
                }

                if ("Bridge".Equals(code)) {
                    builder.AppendLine();
                    builder.AppendLine("\t\tpublic override bool Validate(ICollection<string>? errors) {");
                    builder.AppendLine("\t\t\tif (true.Equals(this.openingBridge))");
                    builder.AppendLine("\t\t\t\treturn this.categoryOfOpeningBridge.HasValue;");
                    builder.AppendLine("\t\t\treturn true;");
                    builder.AppendLine("\t\t}");
                }
            });

            var output = roslyn.ToString();

            File.WriteAllText(@".\..\..\..\S-101_FC.g.cs", output, Encoding.UTF8);

            var csv = this.TypeWriter(ps);
            this._output.WriteLine(csv);
        }

        [Fact]
        public void Test_S501_Build() {
            var ps = XDocument.Load(System.IO.Path.Combine(this._iho, @"S-501-Feature-Catalogue\S-501_FC.xml"));

            var roslyn = this.RoslynBuilder(ps, supportingSpatialAssociation: false);

            var output = roslyn.ToString();

            File.WriteAllText(@".\..\..\..\S-501_FC.g.cs", output, Encoding.UTF8);

            var csv = this.TypeWriter(ps);
            this._output.WriteLine(csv);
        }

        [Fact]
        public void Test_S122_Build() {
            var ps = XDocument.Load(System.IO.Path.Combine(this._iho, @"S-122-Product-Specification-Development\FC\122_FC_2.0.0.20260116.xml"));

            var roslyn = this.RoslynBuilder(ps);

            var output = roslyn.ToString();

            File.WriteAllText(@".\..\..\..\S-122_FC.g.cs", output, Encoding.UTF8);
        }

        [Fact]
        public void Test_S123_Build() {
            var ps = XDocument.Load(System.IO.Path.Combine(this._iho, @"S-123-Product-Specification-Development\FC\S-123_FC_Ed.2.0.0_20260118.xml"));

            var roslyn = this.RoslynBuilder(ps);

            var output = roslyn.ToString();

            File.WriteAllText(@".\..\..\..\S-123_FC.g.cs", output, Encoding.UTF8);
        }

        [Fact]
        public void Test_S124_Build() {
            var ps = XDocument.Load(System.IO.Path.Combine(this._iho, @"S-124 Navigational Warnings\FC\124_FC_2.0.0.xml"));

            var roslyn = this.RoslynBuilder(ps);

            var output = roslyn.ToString();

            File.WriteAllText(@".\..\..\..\S-124_FC.g.cs", output, Encoding.UTF8);
        }

        [Fact]
        public void Test_S125_Build() {
            var ps = XDocument.Load(System.IO.Path.Combine(this._iho, @"S-125-Product-Specification-Development-validation\FC\S125FC.xml"));

            var roslyn = this.RoslynBuilder(ps, "S125");

            var output = roslyn.ToString();

            File.WriteAllText(@".\..\..\..\S-125_FC.g.cs", output, Encoding.UTF8);
        }

        [Fact]
        public void Test_S127_Build() {
            var ps = XDocument.Load(System.IO.Path.Combine(this._iho, @"S-127-Product-Specification-Development\FC\127_FC_2.0.0.20251207.xml"));

            var roslyn = this.RoslynBuilder(ps);

            var output = roslyn.ToString();

            File.WriteAllText(@".\..\..\..\S-127_FC.g.cs", output, Encoding.UTF8);
        }

        [Fact]
        public void Test_S128_Build() {
            var ps = XDocument.Load(System.IO.Path.Combine(this._iho, @"S-128-Product-Specification-Development\FC\128_FC.xml"));

            var roslyn = this.RoslynBuilder(ps);

            var output = roslyn.ToString();

            File.WriteAllText(@".\..\..\..\S-128_FC.g.cs", output, Encoding.UTF8);
        }

        [Fact]
        public void Test_S131_Build() {
            var ps = XDocument.Load(System.IO.Path.Combine(this._iho, @"S-131-Product-Specification-Development\FC\131_FC_2.0.0.20260107.xml"));

            var roslyn = this.RoslynBuilder(ps);

            var output = roslyn.ToString();

            File.WriteAllText(@".\..\..\..\S-131_FC.g.cs", output, Encoding.UTF8);
        }


        private string TypeWriter(XDocument ps) {
            var csv = new StringBuilder();
            csv.AppendLine("code;syperType;");

            var navigator = ps.CreateNavigator();
            navigator.MoveToFollowing(XPathNodeType.Element);

            var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var s in scopes)
                xmlNamespaceManager.AddNamespace(s.Key, s.Value);

            foreach (var element in ps.XPathSelectElements("//S100FC:S100_FC_FeatureType", xmlNamespaceManager)) {
                var code = element.Element(XName.Get("code", scopes["S100FC"]))!.Value;
                var name = element.Element(XName.Get("name", scopes["S100FC"]))!.Value;

                var row = new StringBuilder();

                row.Append($"{code};");

                var superType = element.Elements(XName.Get("superType", scopes["S100FC"])).FirstOrDefault();
                if (superType != null)
                    row.Append($"{superType.Value};");
                else
                    row.Append($";");

                var attributeBindings = element.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager);

                foreach (var attributeBinding in attributeBindings.OrderBy(e => e.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!)) {
                    var referenceCode = attributeBinding.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                    row.Append($"{referenceCode};");
                }
                csv.AppendLine(row.ToString());
            }

            return csv.ToString();
        }


        // Define namespaces
        private static XNamespace s100fc = "http://www.iho.int/S100FC/5.2";
        private static XNamespace s100base = "http://www.iho.int/S100Base/5.0";
        private static XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";

        private static XElement informationBindingSpatialAssociation =
            new XElement(s100fc + "informationBinding",
                new XAttribute(XNamespace.Xmlns + "S100FC", s100fc),
                new XAttribute(XNamespace.Xmlns + "S100Base", s100base),
                new XAttribute(XNamespace.Xmlns + "xsi", xsi),
                new XAttribute("roleType", "association"),

                new XElement(s100fc + "multiplicity",
                    new XElement(s100base + "lower", 0),
                    new XElement(s100base + "upper",
                        new XAttribute(xsi + "nil", "false"),
                        new XAttribute("infinite", "false"),
                        1
                    )
                ),

                new XElement(s100fc + "association",
                    new XAttribute("ref", "SpatialAssociation")
                ),

                new XElement(s100fc + "role",
                    new XAttribute("ref", "theQualityInformation")
                ),

                new XElement(s100fc + "informationType",
                    new XAttribute("ref", "SpatialQuality")
                )
            );

        private StringBuilder RoslynBuilder(XDocument ps, string? id = null, bool supportingSpatialAssociation = false, Action<string, IEnumerable<XElement>, StringBuilder>? validation = default) {
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
                roslyn.AppendLine($"namespace S100FC.{productId}.SimpleAttributes");
                roslyn.AppendLine("{");
                foreach (var element in ps.XPathSelectElements("//S100FC:S100_FC_SimpleAttribute", xmlNamespaceManager)) {
                    var code = element.Element(XName.Get("code", scopes["S100FC"]))!.Value;
                    var name = element.Element(XName.Get("name", scopes["S100FC"]))!.Value;

                    attributesKnown.Add(code);

                    derivedTypesAttributes.AppendLine($"\t\t\t\t\ttypeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof({code}), typeDiscriminator: \"{code}\"));");

                    var valueType = element.Element(XName.Get("valueType", scopes["S100FC"]))!.Value;

                    var definition = element.Element(XName.Get("definition", scopes["S100FC"]))!.Value;

                    definition = definition.Trim().TrimEnd('\t').Trim(Environment.NewLine.ToArray());

                    roslyn.AppendLine("\t/// <summary>");
                    roslyn.AppendLine($"\t/// {definition}");
                    roslyn.AppendLine("\t/// </summary>");

                    var constraints = element.Element(XName.Get("constraints", scopes["S100FC"]));

                    if (valueType.Equals("enumeration")) {
                        attributesKnownTypes.Add(code, "int");
                        roslyn.AppendLine($"\tpublic class {code} : S100FC.EnumerationAttribute");
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

                        //validation?.Invoke(code, roslyn);

                        roslyn.AppendLine($"\t}}");
                    }
                    else if (valueType.Equals("S100_CodeList")) {
                        attributesKnownTypes.Add(code, "int");
                        roslyn.AppendLine($"\tpublic class {code} : S100FC.CodeListAttribute");
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

                        //validation?.Invoke(code, roslyn);

                        roslyn.AppendLine($"\t}}");
                    }
                    else {
                        var prefix = valueType.ToLowerInvariant() switch {
                            "boolean" => "Boolean",
                            "real" => "decimal",
                            "text" => "String",
                            //"s100_truncateddate" => "DateOnly",
                            "s100_truncateddate" => "String",
                            "date" => "DateOnly",
                            "dateonly" => "DateOnly",
                            "datetime" => "DateTime",
                            "time" => "S100FC.S100.Time",
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

                        if (constraints != default) {
                            if (constraints.Element(XName.Get("stringLength", scopes["S100CD"])) != default) {
                                var stringLength = constraints.Element(XName.Get("stringLength", scopes["S100CD"]))!.Value;
                                roslyn.AppendLine($"\t[StringLengthConstraint({stringLength})]");
                            }
                            if (constraints.Element(XName.Get("precision", scopes["S100CD"])) != default) {
                                var precision = constraints.Element(XName.Get("precision", scopes["S100CD"]))!.Value;
                                roslyn.AppendLine($"\t[PrecisionConstraint({int.Parse(precision)})]");
                            }
                            if (constraints.Element(XName.Get("textPattern", scopes["S100CD"])) != default) {
                                var textPattern = constraints.Element(XName.Get("textPattern", scopes["S100CD"]))!.Value;
                                roslyn.AppendLine($"\t[TextPatternConstraint(@\"{textPattern}\")]"); //Replace("\\","\\\\")
                            }
                            if (constraints.Element(XName.Get("range", scopes["S100CD"])) != default) {
                                var lowerBound = constraints.Element(XName.Get("range", scopes["S100CD"]))!.Element(XName.Get("lowerBound", scopes["S100Base"]));
                                var upperBound = constraints.Element(XName.Get("range", scopes["S100CD"]))!.Element(XName.Get("upperBound", scopes["S100Base"]));
                                var closure = constraints.Element(XName.Get("range", scopes["S100CD"]))!.Element(XName.Get("closure", scopes["S100Base"]));

                                if (!(lowerBound is null && upperBound is null)) {
                                    if (upperBound is null) {
                                        roslyn.AppendLine(prefix switch {
                                            "double" => $"\t[RangeConstraintReal({lowerBound!.Value}d, double.MaxValue, Closure.{closure!.Value})]",   //$"{double.Parse(v, CultureInfo.InvariantCulture)}",
                                            "decimal" => $"\t[RangeConstraintReal({lowerBound!.Value}d, double.MaxValue, Closure.{closure!.Value})]",   //$"{double.Parse(v, CultureInfo.InvariantCulture)}",
                                            "int" => $"\t[RangeConstraintInteger({int.Parse(lowerBound!.Value.Split('.')[0])}, int.MaxValue, Closure.{closure!.Value})]",
                                            _ => throw new InvalidOperationException()
                                        });
                                    }
                                    else {
                                        roslyn.AppendLine(prefix switch {
                                            "double" => $"\t[RangeConstraintReal({lowerBound!.Value}d, {upperBound!.Value}d, Closure.{closure!.Value})]",   //$"{double.Parse(v, CultureInfo.InvariantCulture)}",
                                            "decimal" => $"\t[RangeConstraintReal({lowerBound!.Value}d, {upperBound!.Value}d, Closure.{closure!.Value})]",   //$"{double.Parse(v, CultureInfo.InvariantCulture)}",
                                            "int" => $"\t[RangeConstraintInteger({int.Parse(lowerBound!.Value.Split('.')[0])}, {int.Parse(upperBound!.Value.Split('.')[0])}, Closure.{closure!.Value})]",
                                            _ => throw new InvalidOperationException()
                                        });
                                    }
                                }
                            }
                        }

                        attributesKnownTypes.Add(code, prefix);
                        roslyn.AppendLine($"\tpublic class {code} : S100FC.{type}");
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

                        //validation?.Invoke(code, roslyn);

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
                roslyn.AppendLine($"namespace S100FC.{productId}.ComplexAttributes");
                roslyn.AppendLine("{");
                roslyn.AppendLine($"\tusing S100FC.{productId}.SimpleAttributes;");
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
                            validation = validation,
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
                roslyn.AppendLine($"namespace S100FC.{productId}.InformationAssociation");
                roslyn.AppendLine("{");
                roslyn.AppendLine($"\tusing S100FC.{productId}.SimpleAttributes;");
                roslyn.AppendLine($"\tusing S100FC.{productId}.ComplexAttributes;");
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
                        validation = validation,
                    }, (b) => {
                        //b.AppendLine("\t\t[JsonIgnore]");
                        //roslyn.AppendLine($"\t\tpublic override string role => \"{role}\";");

                        roslyn.AppendLine($"\t\tpublic static string role => \"{role}\";");
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
                roslyn.AppendLine($"namespace S100FC.{productId}.FeatureAssociation");
                roslyn.AppendLine("{");
                roslyn.AppendLine($"\tusing S100FC.{productId}.SimpleAttributes;");
                roslyn.AppendLine($"\tusing S100FC.{productId}.ComplexAttributes;");
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
                        validation = validation,
                    }, (b) => {
                        //b.AppendLine("\t\t[JsonIgnore]");
                        //b.AppendLine($"\t\tpublic override string[] roles => [{string.Join(',', roles)}];");

                        b.AppendLine($"\t\tpublic static string[] roles => [{string.Join(',', roles)}];");
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
            var informationAssociationCreators = new List<string>();
            {
                var abstractTypesKnown = new List<string>();

                roslyn.AppendLine();
                roslyn.AppendLine($"namespace S100FC.{productId}.InformationTypes");
                roslyn.AppendLine("{");
                roslyn.AppendLine($"\tusing S100FC.{productId}.SimpleAttributes;");
                roslyn.AppendLine($"\tusing S100FC.{productId}.ComplexAttributes;");
                roslyn.AppendLine();

                var notFinished = false;
                do {
                    notFinished = false;
                    foreach (var element in ps.XPathSelectElements("//S100FC:S100_FC_InformationType", xmlNamespaceManager)) {
                        var success = this.ClassBuilder(roslyn, element, "InformationType, IInformationBindings", new ClassBuilderHost {
                            KnownTypes = informationTypesKnown,
                            KnownTypesAbstract = abstractTypesKnown,
                            KnownTypesComplex = attributesKnownComplex,
                            KnownAttributeTypes = attributesKnownTypes,
                            Attributes = element.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager),
                            informationAssociationCreators = informationAssociationCreators,
                            informationBindings = () => element.XPathSelectElements("S100FC:informationBinding", xmlNamespaceManager),
                            validation = validation,
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

            var featurePrimitives = new Dictionary<Primitives, ICollection<string>> {
                { Primitives.noGeometry, [] },
                { Primitives.point, [] },
                { Primitives.pointSet, [] },
                { Primitives.curve, [] },
                { Primitives.surface, [] },
            };


            #region S100_FC_FeatureType
            var featureTypesKnown = new List<string>();
            var featureAssociationCreators = new List<string>();
            {
                var abstractTypesKnown = new List<string>();

                roslyn.AppendLine();
                roslyn.AppendLine($"namespace S100FC.{productId}.FeatureTypes");
                roslyn.AppendLine("{");
                roslyn.AppendLine($"\tusing S100FC.{productId}.SimpleAttributes;");
                roslyn.AppendLine($"\tusing S100FC.{productId}.ComplexAttributes;");
                roslyn.AppendLine($"\tusing S100FC.{productId}.InformationTypes;");
                roslyn.AppendLine();

                var notFinished = false;
                do {
                    notFinished = false;
                    foreach (var element in ps.XPathSelectElements("//S100FC:S100_FC_FeatureType", xmlNamespaceManager)) {
                        var code = element.Element(XName.Get("code", scopes["S100FC"]))!.Value;

                        var informationBindings = () => element.XPathSelectElements("S100FC:informationBinding", xmlNamespaceManager).Union([informationBindingSpatialAssociation]);

                        var spatialAssociation = supportingSpatialAssociation && element.XPathSelectElements("S100FC:permittedPrimitives", xmlNamespaceManager).Any(e => Enum.Parse<Primitives>(e.Value!) != Primitives.noGeometry);

                        var success = this.ClassBuilder(roslyn, element, "FeatureType, IInformationBindings, IFeatureBindings", new ClassBuilderHost {
                            KnownTypes = featureTypesKnown,
                            KnownTypesAbstract = abstractTypesKnown,
                            KnownTypesComplex = attributesKnownComplex,
                            KnownAttributeTypes = attributesKnownTypes,
                            Attributes = element.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager),
                            informationAssociationCreators = informationAssociationCreators,
                            featureAssociationCreators = featureAssociationCreators,
                            informationBindings = () => spatialAssociation ? informationBindings() : element.XPathSelectElements("S100FC:informationBinding", xmlNamespaceManager),
                            validation = validation,
                        }, (b) => {

                        }, (b) => {
                            var permittedValues = element.XPathSelectElements("S100FC:permittedPrimitives", xmlNamespaceManager).Select(e => $"Primitives.{e.Value!}");

                            if (permittedValues.Any()) {
                                b.AppendLine();
                                b.AppendLine("\t\t[JsonIgnore]");
                                b.AppendLine($"\t\tpublic override Primitives[] permittedPrimitives => [{string.Join(',', permittedValues)}];");

                                foreach (var p in element.XPathSelectElements("S100FC:permittedPrimitives", xmlNamespaceManager)) {
                                    var value = Enum.Parse<Primitives>(p.Value!);
                                    featurePrimitives[value].Add(code);
                                }
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
                roslyn.AppendLine($"namespace S100FC.{productId}");
                roslyn.AppendLine("{");
                roslyn.AppendLine($"\tusing System.Text.Json;");
                roslyn.AppendLine($"\tusing S100FC.{productId}.SimpleAttributes;");
                roslyn.AppendLine($"\tusing S100FC.{productId}.ComplexAttributes;");
                roslyn.AppendLine($"\tusing S100FC.{productId}.InformationAssociation;");
                roslyn.AppendLine($"\tusing S100FC.{productId}.FeatureAssociation;");
                roslyn.AppendLine($"\tusing S100FC.{productId}.InformationTypes;");
                roslyn.AppendLine($"\tusing S100FC.{productId}.FeatureTypes;");
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

                types = featureTypesKnown.Select(e => $"\"{e}\"");
                roslyn.AppendLine($"\t\tpublic static string[] FeatureTypes => [{string.Join(',', types)}];");

                roslyn.AppendLine("\t\tpublic static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {");
                roslyn.AppendLine($"\t\t\tPrimitives.noGeometry => [{string.Join(',', featurePrimitives[Primitives.noGeometry].Select(e => $"\"{e}\""))}],");
                roslyn.AppendLine($"\t\t\tPrimitives.point => [{string.Join(',', featurePrimitives[Primitives.point].Select(e => $"\"{e}\""))}],");
                roslyn.AppendLine($"\t\t\tPrimitives.pointSet => [{string.Join(',', featurePrimitives[Primitives.pointSet].Select(e => $"\"{e}\""))}],");
                roslyn.AppendLine($"\t\t\tPrimitives.curve => [{string.Join(',', featurePrimitives[Primitives.curve].Select(e => $"\"{e}\""))}],");
                roslyn.AppendLine($"\t\t\tPrimitives.surface => [{string.Join(',', featurePrimitives[Primitives.surface].Select(e => $"\"{e}\""))}],");
                roslyn.AppendLine("\t\t\t_ => throw new InvalidOperationException(),");
                roslyn.AppendLine("\t\t};");

                roslyn.AppendLine("\t}");
                roslyn.AppendLine();

                //roslyn.AppendLine("\tpublic static class Validation {");
                //roslyn.AppendLine("\t\tpublic static bool IsValid(SimpleAttribute attribute, IEnumerable<SimpleAttribute> attributes) {");
                //validation?.Invoke(roslyn);
                //roslyn.AppendLine("\t\t\treturn true;");
                //roslyn.AppendLine("\t\t}");
                //roslyn.AppendLine("\t}");
                //roslyn.AppendLine();

                roslyn.AppendLine("\tpublic static class Extensions {");

                roslyn.AppendLine("\t\tpublic static informationBinding CreateInformationBinding(string informationType, string association) => $\"{informationType}::{association}\" switch {");
                foreach (var informationAssociation in informationAssociationCreators) {
                    roslyn.AppendLine($"\t\t\t{informationAssociation}");
                }
                roslyn.AppendLine("\t\t\t\"\" => throw new KeyNotFoundException(),");
                roslyn.AppendLine("\t\t\t_ => throw new KeyNotFoundException(),");
                roslyn.AppendLine("\t\t};");
                roslyn.AppendLine();

                //roslyn.AppendLine("\t\tpublic static object CreateInformationBinding(string association, string roleType, string role, string informationType, string informationId) => association switch {");
                //foreach (var informationAssociation in informationAssociationTypesKnown) {
                //    roslyn.AppendLine($"\t\t\t\"{informationAssociation}\" => new informationBinding<{informationAssociation}>() {{");
                //    roslyn.AppendLine("\t\t\t\troleType = roleType, role = role, informationType = informationType, informationId = informationId,");
                //    roslyn.AppendLine("\t\t\t},");
                //}
                //roslyn.AppendLine("\t\t\t\"\" => throw new KeyNotFoundException(),");
                //roslyn.AppendLine("\t\t\t_ => throw new KeyNotFoundException(),");
                //roslyn.AppendLine("\t\t};");
                //roslyn.AppendLine();


                roslyn.AppendLine("\t\tpublic static featureBinding CreateFeatureBinding(string featureType, string association, string role) => $\"{featureType}::{association}\" switch {");
                foreach (var featureAssociation in featureAssociationCreators) {
                    roslyn.AppendLine($"\t\t\t{featureAssociation}");
                }
                roslyn.AppendLine("\t\t\t\"\" => throw new KeyNotFoundException(),");
                roslyn.AppendLine("\t\t\t_ => throw new KeyNotFoundException(),");
                roslyn.AppendLine("\t\t};");
                roslyn.AppendLine();


                //roslyn.AppendLine("\t\tpublic static object CreateFeatureBinding(string association, string roleType, string role, string featureType, string featureId) => association switch {");
                //foreach (var featureAssociation in featureAssociationTypesKnown) {
                //    roslyn.AppendLine($"\t\t\t\"{featureAssociation}\" => new featureBinding<{featureAssociation}>() {{");
                //    roslyn.AppendLine("\t\t\t\troleType = roleType, role = role, featureType = featureType, featureId = featureId,");
                //    roslyn.AppendLine("\t\t\t},");
                //}
                //roslyn.AppendLine("\t\t\t\"\" => throw new KeyNotFoundException(),");
                //roslyn.AppendLine("\t\t\t_ => throw new KeyNotFoundException(),");
                //roslyn.AppendLine("\t\t};");
                //roslyn.AppendLine();

                roslyn.AppendLine("\t\tpublic static JsonSerializerOptions AppendTypeInfoResolver(this JsonSerializerOptions jsonSerializerOptions) {");
                roslyn.AppendLine("\t\t\tvar resolver = new System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver();");
                roslyn.AppendLine("\t\t\tresolver.Modifiers.Add(typeInfo => {");

                roslyn.AppendLine("\t\t\t\tif (typeInfo.Type == typeof(S100FC.informationBinding)) {");
                roslyn.AppendLine("\t\t\t\t\ttypeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {");
                roslyn.AppendLine("\t\t\t\t\t\tTypeDiscriminatorPropertyName = \"code\",");
                roslyn.AppendLine("\t\t\t\t\t\tIgnoreUnrecognizedTypeDiscriminators = true,");
                roslyn.AppendLine("\t\t\t\t\t};");
                roslyn.Append(derivedTypesInformationBindings.ToString());
                roslyn.AppendLine("\t\t\t\t}");

                roslyn.AppendLine("\t\t\t\tif (typeInfo.Type == typeof(S100FC.featureBinding)) {");
                roslyn.AppendLine("\t\t\t\t\ttypeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {");
                roslyn.AppendLine("\t\t\t\t\t\tTypeDiscriminatorPropertyName = \"code\",");
                roslyn.AppendLine("\t\t\t\t\t\tIgnoreUnrecognizedTypeDiscriminators = true,");
                roslyn.AppendLine("\t\t\t\t\t};");
                roslyn.Append(derivedTypesFeatureBindings.ToString());
                roslyn.AppendLine("\t\t\t\t}");

                roslyn.AppendLine("\t\t\t\tif (typeInfo.Type == typeof(S100FC.attributeBinding)) {");
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

            public ICollection<string> informationAssociationCreators { get; init; } = [];
            public ICollection<string> featureAssociationCreators { get; init; } = [];

            public Func<IEnumerable<XElement>> informationBindings { get; init; } = () => [];

            public Action<string, IEnumerable<XElement>, StringBuilder>? validation { get; set; } = default;
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

            var baseClass = $"S100FC.{type}";

            var superType = element.Elements(XName.Get("superType", scopes["S100FC"])).FirstOrDefault();
            if (superType != null) {
                if (!host.KnownTypes.Any(e => e.Equals(superType.Value, StringComparison.InvariantCultureIgnoreCase))) {
                    return false;
                }

                baseClass = $"{superType.Value}";
            }

            var accessibility = "public";

            if (element.Attribute("isAbstract") != default && bool.Parse(element.Attribute("isAbstract")!.Value)) {
                host.KnownTypesAbstract.Add(code);
                accessibility = "public abstract";
            }

            host.KnownTypes.Add(code);

            var definition = element.Element(XName.Get("definition", scopes["S100FC"]))!.Value;
            roslyn.AppendLine("\t/// <summary>");
            roslyn.AppendLine($"\t/// {definition}");
            roslyn.AppendLine("\t/// </summary>");

            roslyn.AppendLine($"\t{accessibility} class {code} : {baseClass}");
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

                        if (upper > 1)
                            roslyn.AppendLine($"\t\t\tset {{ base.SetAttribute(\"{referenceCode}\", value); }}");
                        else
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
                            roslyn.AppendLine($"\t\t\tset {{ base.SetAttribute(\"{referenceCode}\", [.. value.Select(e=> new {referenceCode} {{ value = e }})]); }}");
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
                int order = 0;

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
                    roslyn.AppendLine($"\t\t\t\t\torder = {order++},");
                    if (permittedValues is not null)
                        roslyn.AppendLine($"\t\t\t\t\tpermitedValues = [{string.Join(',', permittedValues.XPathSelectElements("S100FC:value", xmlNamespaceManager).Select(e => $"{e.Value}"))}],");
                    roslyn.AppendLine($"\t\t\t\t\tCreateInstance = () => new {referenceCode}(),");
                    roslyn.AppendLine($"\t\t\t\t}},");
                }
                roslyn.AppendLine($"\t\t\t];");
                roslyn.AppendLine();
            }

            string[] localNameInformationTypes = ["S100_FC_InformationType", "S100_FC_FeatureType"];
            if (localNameInformationTypes.Contains(element.Name.LocalName)) {
                roslyn.AppendLine($"\t\tpublic override informationBindingDefinition[] GetInformationBindingsDefinitions() => {code}.informationBindingsDefinitions;");
                roslyn.AppendLine();
                //var informationBindings = element.XPathSelectElements("S100FC:informationBinding", xmlNamespaceManager);
                var informationBindings = host.informationBindings();
                roslyn.AppendLine($"\t\tpublic static informationBindingDefinition[] informationBindingsDefinitions => [");
                if (informationBindings.Any()) {
                    //roslyn.AppendLine("\t\t[JsonIgnore]");
                    //roslyn.AppendLine($"\t\tpublic override informationBindingDefinition[] informationBindingsCatalogue => {code}.informationBindingsCatalogue;");

                    if (superType != null) {
                        roslyn.AppendLine($"\t\t\t\t.. {superType.Value!}.informationBindingsDefinitions,");
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

                        roslyn.AppendLine($"\t\t\t\t\tCreateInstance = () => new informationBinding<InformationAssociation.{association}>() {{");
                        roslyn.AppendLine($"\t\t\t\t\t\troleType = \"{roleType}\",");
                        roslyn.AppendLine($"\t\t\t\t\t\trole = \"{role}\",");
                        roslyn.AppendLine($"\t\t\t\t\t}},");

                        roslyn.AppendLine($"\t\t\t\t}},");
                    }
                }
                roslyn.AppendLine($"\t\t\t];");
                roslyn.AppendLine();

                foreach (var informationBinding in informationBindings) {
                    var association = informationBinding.Element(XName.Get("association", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                    var role = informationBinding.Element(XName.Get("role", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                    var roleType = informationBinding.Attribute("roleType")!.Value!;

                    roslyn.AppendLine($"\t\tpublic static informationBinding<InformationAssociation.{association}> {association} => new informationBinding<InformationAssociation.{association}> {{");
                    roslyn.AppendLine($"\t\t\troleType = \"{roleType}\",");
                    roslyn.AppendLine($"\t\t\trole = \"{role}\",");
                    roslyn.AppendLine($"\t\t}};");

                    host.informationAssociationCreators.Add($"\"{code}::{association}\" => {code}.{association},");
                }
                if (informationBindings.Any())
                    roslyn.AppendLine();
            }

            string[] localNameFeatureTypes = ["S100_FC_FeatureType"];
            if (localNameFeatureTypes.Contains(element.Name.LocalName)) {
                roslyn.AppendLine($"\t\tpublic override featureBindingDefinition[] GetFeatureBindingsDefinitions() => {code}.featureBindingsDefinitions;");
                roslyn.AppendLine();
                var featureBindings = element.XPathSelectElements("S100FC:featureBinding", xmlNamespaceManager);
                roslyn.AppendLine($"\t\tpublic static featureBindingDefinition[] featureBindingsDefinitions => [");
                if (featureBindings.Any()) {
                    //roslyn.AppendLine("\t\t[JsonIgnore]");
                    //roslyn.AppendLine($"\t\tpublic override featureBindingDefinition[] featureBindingsCatalogue => [");

                    if (superType != null) {
                        roslyn.AppendLine($"\t\t\t\t.. {superType.Value!}.featureBindingsDefinitions,");
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

                        roslyn.AppendLine($"\t\t\t\t\tCreateInstance = () => new featureBinding<FeatureAssociation.{association}>() {{");
                        roslyn.AppendLine($"\t\t\t\t\t\troleType = \"{roleType}\",");
                        roslyn.AppendLine($"\t\t\t\t\t\trole = \"{role}\",");
                        roslyn.AppendLine($"\t\t\t\t\t}},");

                        roslyn.AppendLine($"\t\t\t\t}},");
                    }
                }
                roslyn.AppendLine($"\t\t\t];");
                roslyn.AppendLine();


                if (featureBindings.Any()) {
                    var knownBindings = new List<string>();

                    foreach (var featureBinding in featureBindings) {
                        var association = featureBinding.Element(XName.Get("association", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                        var role = featureBinding.Element(XName.Get("role", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                        var roleType = featureBinding.Attribute("roleType")!.Value!;

                        if (knownBindings.Contains(association)) continue;
                        knownBindings.Add(association);
                        roslyn.AppendLine($"\t\tpublic static featureBinding<FeatureAssociation.{association}> {association}(string role) => new featureBinding<FeatureAssociation.{association}> {{");
                        roslyn.AppendLine($"\t\t\troleType = featureBindingsDefinitions.Single(binding => binding.association.Equals(\"{association}\") && binding.role.Equals(role)).roleType,");
                        roslyn.AppendLine($"\t\t\trole = role,");
                        roslyn.AppendLine($"\t\t}};");

                        host.featureAssociationCreators.Add($"\"{code}::{association}\" => {code}.{association}(role),");
                    }
                }
            }

            roslyn.AppendLine("\t\t#endregion");

            post?.Invoke(roslyn);

            host.validation?.Invoke(code, host.Attributes, roslyn);

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