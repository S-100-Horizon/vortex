using Pluralize.NET.Core;
using S100Framework.DomainModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace S100Framework.Applications
{
    public static class Roslyn
    {
        private static Pluralizer pluralizer = new();

        //private static ICollection<string> spatialAssociationTypes = new List<string>() { "SpatialAssociation" };

        private static ICollection<Primitives> spatialAssociationPrimitives = [Primitives.curve, Primitives.pointSet, Primitives.point];

        public static (string DomainModel, string ViewModel) Build(XDocument productSpecification, bool supportingSpatialAssociation = false) {
            var navigator = productSpecification.CreateNavigator();
            navigator.MoveToFollowing(XPathNodeType.Element);
            var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var e in scopes)
                xmlNamespaceManager.AddNamespace(e.Key, e.Value);

            var productId = productSpecification.XPathSelectElement("//S100FC:productId", xmlNamespaceManager)!.Value.Replace("-", string.Empty).ToUpperInvariant();
            var versionNumber = productSpecification.XPathSelectElement("//S100FC:versionNumber", xmlNamespaceManager)!.Value;

            var scope_S100 = scopes["S100FC"];


            var builderDomainModel = new StringBuilder();

            builderDomainModel.AppendLine("using System;");
            builderDomainModel.AppendLine("using System.Collections.Immutable;");
            builderDomainModel.AppendLine("using System.Linq;");
            builderDomainModel.AppendLine("using System.Runtime.Serialization;");
            builderDomainModel.AppendLine("using System.Text.Json.Serialization;");
            builderDomainModel.AppendLine("using System.Xml.Serialization;");
            builderDomainModel.AppendLine();
            builderDomainModel.AppendLine("#nullable enable");
            builderDomainModel.AppendLine("#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.");
            builderDomainModel.AppendLine();
            builderDomainModel.AppendLine();
            builderDomainModel.AppendLine($"namespace S100Framework.DomainModel.{productId} {{");

            builderDomainModel.AppendLine("\tpublic static class Summary");
            builderDomainModel.AppendLine("\t{");
            builderDomainModel.AppendLine($"\t\tpublic static Version Version => new Version(\"{versionNumber}\");");
            var indexInformation = builderDomainModel.Length;
            {
                var names = productSpecification.XPathSelectElements("//S100FC:S100_FC_ComplexAttribute", xmlNamespaceManager).Select(e => e.Element(XName.Get("code", scope_S100))!.Value);
                builderDomainModel.AppendLine($"\t\tpublic static string[] ComplexTypes => [{string.Join(',', names.Select(e => $"\"{e}\""))}];");

                names = productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationAssociation", xmlNamespaceManager).Select(e => e.Element(XName.Get("code", scope_S100))!.Value);
                builderDomainModel.AppendLine($"\t\tpublic static string[] InformationAssociationTypes => [{string.Join(',', names.Select(e => $"\"{e}\""))}];");

                names = productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureAssociation", xmlNamespaceManager).Select(e => e.Element(XName.Get("code", scope_S100))!.Value);
                builderDomainModel.AppendLine($"\t\tpublic static string[] FeatureAssociationTypes => [{string.Join(',', names.Select(e => $"\"{e}\""))}];");

                names = productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationType", xmlNamespaceManager).Where(e => e.Attribute("isAbstract") is null || e.Attribute("isAbstract")!.Value.Equals("false", StringComparison.InvariantCultureIgnoreCase)).Select(e => e.Element(XName.Get("code", scope_S100))!.Value);
                builderDomainModel.AppendLine($"\t\tpublic static string[] InformationTypes => [{string.Join(',', names.Select(e => $"\"{e}\""))}];");

                names = productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureType", xmlNamespaceManager).Where(e => e.Attribute("isAbstract") is null || e.Attribute("isAbstract")!.Value.Equals("false", StringComparison.InvariantCultureIgnoreCase)).Select(e => e.Element(XName.Get("code", scope_S100))!.Value);
                builderDomainModel.AppendLine($"\t\tpublic static string[] FeatureTypes => [{string.Join(',', names.Select(e => $"\"{e}\""))}];");

                builderDomainModel.AppendLine("\t\tpublic static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {");
                var primitives = productSpecification.XPathSelectElements("//S100FC:permittedPrimitives", xmlNamespaceManager);
                foreach (var p in primitives.GroupBy(e => e.Value!)) {
                    var featureNames = p.Select(e => $"\"{e.Parent!.Element(XName.Get("code", scope_S100))!.Value}\"");
                    builderDomainModel.AppendLine($"\t\t\tPrimitives.{p.Key} => [{string.Join(',', featureNames)}],");
                }
                builderDomainModel.AppendLine("\t\t\t_ => throw new InvalidOperationException(),");
                builderDomainModel.AppendLine("\t\t};");

                builderDomainModel.AppendLine("\t\tpublic static Primitives[] FeaturePrimitives(string featureType) => featureType switch {");
                var featureTypes = productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureType", xmlNamespaceManager);
                foreach (var e in featureTypes) {
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;
                    var p = e.Elements(XName.Get("permittedPrimitives", scope_S100)).Select(e => $"Primitives.{e.Value!}");
                    builderDomainModel.AppendLine($"\t\t\t\"{code}\" => [{string.Join(',', p)}],");
                }
                builderDomainModel.AppendLine("\t\t\t_ or \"\" => throw new InvalidOperationException(),");
                builderDomainModel.AppendLine("\t\t};");
            }
            builderDomainModel.AppendLine("\t}");
            builderDomainModel.AppendLine();

            var knownTypes = new List<string>();

            var knowTypesPrefix = new Dictionary<string, string>();
            var knowTypesPostfix = new Dictionary<string, string>();

            var enumTypes = new List<string>();
            var codelistTypes = new List<string>();

            var informationAssociationsLookup = new Dictionary<string, ICollection<string>>();
            var featureAssociationsLookup = new Dictionary<string, ICollection<string>>();

            var editorBuilders = new Dictionary<string, Action<StringBuilder, int, int?>>();

            var shouldSerialize = new Dictionary<string, Func<string, string>> {
                { "Boolean?", (code) => $"{code}.HasValue" },
                { "bool?", (code) => $"{code}.HasValue" },
                { "integer?", (code) => $"{code}.HasValue" },
                { "int?", (code) => $"{code}.HasValue" },
                { "long?", (code) => $"{code}.HasValue" },
                { "Int32?", (code) => $"{code}.HasValue" },
                { "Int64?", (code) => $"{code}.HasValue" },
                { "real?", (code) => $"{code}.HasValue" },
                { "float?", (code) => $"{code}.HasValue" },
                { "double?", (code) => $"{code}.HasValue" },
                { "decimal?", (code) => $"{code}.HasValue" },
                { "DateTime?", (code) => $"{code}.HasValue" },
                { "DateOnly?", (code) => $"{code}.HasValue" },
                { "TimeOnly?", (code) => $"{code}.HasValue" },
                { "String", (code) => $"!string.IsNullOrEmpty({code})" },
                { "String?", (code) => $"!string.IsNullOrEmpty({code})" },
            };

            //  --- S100_FC_SimpleAttributes ----------------------------------------------------
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_SimpleAttribute", xmlNamespaceManager);

                //  Enumerations
                foreach (var e in elements.Where(e => e.Element(XName.Get("valueType", scope_S100))!.Value.Equals("enumeration"))) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    knownTypes.Add(code);
                    knowTypesPrefix.Add(code, code);
                    enumTypes.Add(code);

                    shouldSerialize.Add($"{code}?", (code) => {
                        return $"{code}.HasValue";
                    });

                    builderDomainModel.AppendLine("\t[System.Diagnostics.CodeAnalysis.SuppressMessage(\"Style\", \"IDE1006:Naming Styles\", Justification = \"<Pending>\")]");
                    builderDomainModel.AppendLine("\t[System.Serializable()]");
                    builderDomainModel.AppendLine($"\tpublic enum {code} : int {{");

                    var isFirst = true;
                    foreach (var listedValue in e.Element(XName.Get("listedValues", scope_S100))!.Elements()) {
                        if (!isFirst)
                            builderDomainModel.AppendLine();
                        isFirst = false;

                        var listedValueLabel = listedValue.Element(XName.Get("label", scope_S100))!.Value!;
                        var listedValueDefinition = listedValue.Element(XName.Get("definition", scope_S100))!.Value!;
                        var listedValueCode = listedValue.Element(XName.Get("code", scope_S100))!.Value!;

                        var literalName = RemoveSpecialChars(listedValueLabel);

                        listedValueDefinition = RemoveSpecialChars(listedValueDefinition).Replace("\"", "\\\"");

                        builderDomainModel.AppendLine($"\t\t[System.ComponentModel.Description(\"{listedValueDefinition}\")]");
                        builderDomainModel.AppendLine($"\t\t[EnumMember(Value = \"{listedValueLabel}\")] ");
                        builderDomainModel.AppendLine($"\t\t{literalName} = {listedValueCode},");
                        //builderDomainModel.AppendLine();
                    }


                    builderDomainModel.AppendLine("\t\t[System.ComponentModel.Description(\"Unknown value.\")]");
                    builderDomainModel.AppendLine("\t\t[EnumMember(Value = \"Unknown\")]");
                    builderDomainModel.AppendLine("\t\tUnknown = -1,");

                    builderDomainModel.AppendLine("\t}");
                    builderDomainModel.AppendLine();

                    editorBuilders.Add(code, (b, lower, upper) => {
                        if (lower > 1 || (upper.HasValue && upper.Value > 1))
                            b.AppendLine($"\t\t[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]");
                        else
                            b.AppendLine($"\t\t[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]");
                        b.AppendLine($"\t\t[DomainModel.EnumerationAttribute(nameof({code}List), typeof({code}))]");
                    });
                }

                //  CodeLists
                {
                    foreach (var e in elements.Where(e => e.Element(XName.Get("valueType", scope_S100))!.Value.Equals("S100_CodeList"))) {
                        var name = e.Element(XName.Get("name", scope_S100))!.Value;
                        var code = e.Element(XName.Get("code", scope_S100))!.Value;

                        builderDomainModel.AppendLine("\t[System.Serializable()]");
                        builderDomainModel.AppendLine($"\tpublic class {code}");
                        builderDomainModel.AppendLine("\t{");
                        builderDomainModel.AppendLine("\t\tpublic required string label { get; set; }");
                        builderDomainModel.AppendLine("\t\tpublic required string definition { get; set; }");
                        builderDomainModel.AppendLine("\t\tpublic required int code { get; set; }");
                        builderDomainModel.AppendLine("\t}");
                        builderDomainModel.AppendLine();

                        codelistTypes.Add(code);

                        shouldSerialize.Add($"{code}?", (code) => {
                            return $"{code} != default";
                        });
                    }

                    builderDomainModel.AppendLine("\tpublic static class CodeList");
                    builderDomainModel.AppendLine("\t{");

                    var isFirst = true;
                    foreach (var e in elements.Where(e => e.Element(XName.Get("valueType", scope_S100))!.Value.Equals("S100_CodeList"))) {
                        if (!isFirst)
                            builderDomainModel.AppendLine();
                        isFirst = false;

                        var name = e.Element(XName.Get("name", scope_S100))!.Value;
                        var code = e.Element(XName.Get("code", scope_S100))!.Value;

                        var pluralize = pluralizer.Pluralize(code);
                        builderDomainModel.AppendLine($"\t\tpublic static ImmutableArray<{code}> {pluralize} => ImmutableArray.Create<{code}>(new {code}[]{{");

                        var values = e.Element(XName.Get("listedValues", scope_S100))!.Elements();
                        foreach (var v in values) {
                            var valueLabel = v.Element(XName.Get("label", scope_S100))!.Value;
                            var valueCode = v.Element(XName.Get("code", scope_S100))!.Value;
                            var valueDefinition = v.Element(XName.Get("definition", scope_S100))!.Value;

                            valueDefinition = Regex.Replace(valueDefinition, "\\n{2,}\\s*", "\n");

                            var lines = valueDefinition.Split("\n", StringSplitOptions.RemoveEmptyEntries);
                            valueDefinition = string.Join("\" + Environment.NewLine +" + Environment.NewLine + "\"", lines);

                            builderDomainModel.AppendLine($"\t\t\tnew() {{");
                            builderDomainModel.AppendLine($"\t\t\t\tcode = {valueCode},");
                            builderDomainModel.AppendLine($"\t\t\t\tdefinition = \"{valueDefinition}\",");
                            builderDomainModel.AppendLine($"\t\t\t\tlabel = \"{valueLabel}\",");
                            builderDomainModel.AppendLine("\t\t\t},");
                        }

                        builderDomainModel.AppendLine("\t\t});");
                    }
                    builderDomainModel.AppendLine("\t}");
                    builderDomainModel.AppendLine();
                }

                //  SimpleAttributes
                foreach (var e in elements.Where(e => !e.Element(XName.Get("valueType", scope_S100))!.Value.Equals("enumeration"))) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    knownTypes.Add(code);

                    var prefix = e.Element(XName.Get("valueType", scope_S100))!.Value.ToLowerInvariant() switch {
                        "boolean" => "Boolean",
                        "enumeration" => code,
                        "real" => "decimal",
                        "text" => "String",
                        //"s100_truncateddate" => "DateOnly",
                        "s100_truncateddate" => "String",
                        "date" => "DateOnly",
                        "dateonly" => "DateOnly",
                        "datetime" => "DateTime",
                        "time" => "TimeOnly",
                        "integer" => "int",
                        "urn" => "String",
                        "s100_codelist" => code,
                        "url" => "String",
                        "uri" => "String",
                        _ => throw new InvalidDataException(),
                    };
                    knowTypesPrefix.Add(code, prefix);

                    if (e.Element(XName.Get("valueType", scope_S100))!.Value.Equals("s100_truncateddate", StringComparison.InvariantCultureIgnoreCase)) {
                        editorBuilders.Add(code, (b, lower, upper) => {
                            if (lower > 1 || (upper.HasValue && upper.Value > 1))
                                b.AppendLine($"\t\t[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]");
                        });
                    }

                    var postfix = e.Element(XName.Get("valueType", scope_S100))!.Value.ToLowerInvariant() switch {
                        "boolean" => "false",
                        //"enumeration" => code,
                        //"real" => "decimal",
                        "text" => "string.Empty",
                        //"S100_TruncatedDate" => "DateOnly",
                        //"date" => "DateOnly",
                        //"dateTime" => "DateTime",
                        //"time" => "TimeOnly",
                        //"integer" => "int",
                        "urn" => "string.Empty",
                        //"S100_CodeList" => codelistTypes[code],
                        "url" => "string.Empty",
                        "uri" => "string.Empty",
                        _ => null,
                    };
                    if (postfix != null) {
                        knowTypesPostfix.Add(code, postfix);
                    }
                }
            }

            var complexTypes = new List<string>();

            //  --- S100_FC_ComplexAttributes ---------------------------------------------------
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_ComplexAttribute", xmlNamespaceManager);

                if (elements.Any())
                    builderDomainModel.AppendLine("\tnamespace ComplexAttributes {");

                var notFinished = false;
                do {
                    notFinished = false;

                    foreach (var e in elements) {
                        var name = e.Element(XName.Get("name", scope_S100))!.Value;
                        var code = e.Element(XName.Get("code", scope_S100))!.Value;

                        if (complexTypes.Contains(code))
                            continue;

                        if (e.XPathSelectElements("S100FC:subAttributeBinding", xmlNamespaceManager).Any(attribute => !knownTypes.Contains(attribute.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!))) {
                            notFinished = true;
                            continue;
                        }

                        complexTypes.Add(code);
                        knownTypes.Add(code);
                        knowTypesPrefix.Add(code, code);

                        shouldSerialize.Add($"{code}?", (code) => {
                            return $"{code}!=default";
                        });

                        builderDomainModel.AppendLine("\t\t[System.Serializable()]");
                        builderDomainModel.AppendLine("\t\t[System.Diagnostics.CodeAnalysis.SuppressMessage(\"Style\", \"IDE1006:Naming Styles\", Justification = \"<Pending>\")]");

                        builderDomainModel.AppendLine($"\t\tpublic class {code} {{");

                        var isFirst = true;
                        foreach (var attributeBinding in e.XPathSelectElements("S100FC:subAttributeBinding", xmlNamespaceManager)) {
                            if (!isFirst)
                                builderDomainModel.AppendLine();
                            isFirst = false;

                            var referenceCode = attributeBinding.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!;
                            var permittedValues = attributeBinding.XPathSelectElement("S100FC:permittedValues", xmlNamespaceManager);
                            var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                            var _ = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                            int? upper = (_.Attribute(XName.Get("infinite")) != default && _.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? null : int.Parse(_.Value!);

                            var prefix = knowTypesPrefix[referenceCode];
                            var postfix = knowTypesPostfix.ContainsKey(referenceCode) ? $" = {knowTypesPostfix[referenceCode]};" : string.Empty;

                            if (permittedValues is not null) {
                                builderDomainModel.AppendLine($"\t\t\t[EnumerationValue([{string.Join(',', permittedValues.XPathSelectElements("S100FC:value", xmlNamespaceManager).Select(e => e.Value))}])]");
                            }

                            if (prefix.Equals("DateOnly")) {
                                builderDomainModel.AppendLine("\t\t\t[XmlIgnore]");
                            }

                            if (lower == 0 && upper.HasValue && upper.Value == 1) {
                                prefix += "?";
                                postfix = " = default;";
                            }
                            else if (lower == 1 && upper.HasValue && upper.Value == 1) {
                                if (!knowTypesPrefix[referenceCode].Equals("String"))
                                    builderDomainModel.AppendLine($"\t\t\t[Required()]");
                            }
                            else {
                                prefix = $"List<{prefix}>";
                                postfix = " = [];";
                            }
                            builderDomainModel.AppendLine($"\t\t\tpublic {prefix} {referenceCode} {{get;set;}}{postfix}");

                            if (prefix.Equals("DateOnly")) {
                                builderDomainModel.AppendLine();
                                builderDomainModel.AppendLine("\t\t\t[JsonIgnore]");
                                builderDomainModel.AppendLine($"\t\t\t[System.Xml.Serialization.XmlElementAttribute(DataType = \"date\", ElementName = \"{referenceCode}\")]");
                                builderDomainModel.AppendLine($"\t\t\tpublic DateTime {referenceCode}Field {{");
                                builderDomainModel.AppendLine($"\t\t\t\tget {{ return {referenceCode}.ToDateTime(TimeOnly.MinValue); }}");
                                builderDomainModel.AppendLine($"\t\t\t\tset {{ {referenceCode} = DateOnly.FromDateTime(value); }}");
                                builderDomainModel.AppendLine("\t\t\t}");
                            }

                            if (lower == 0 && upper.HasValue && upper.Value == 1) {
                                builderDomainModel.AppendLine();
                                builderDomainModel.AppendLine($"\t\t\tpublic bool ShouldSerialize{referenceCode}() {{ return {shouldSerialize[prefix](referenceCode)}; }}");
                            }
                            if (prefix.StartsWith("List<")) {
                                builderDomainModel.AppendLine();
                                builderDomainModel.AppendLine($"\t\t\tpublic bool ShouldSerialize{referenceCode}() {{ return {referenceCode}.Any(); }}");
                            }
                        }

                        builderDomainModel.AppendLine("\t\t}");
                        builderDomainModel.AppendLine();
                    }

                } while (notFinished);

                if (elements.Any())
                    builderDomainModel.AppendLine("\t}");
            }

            //  --- S100_FC_Roles ---------------------------------------------------------------
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_Role", xmlNamespaceManager);

                if (elements.Any()) {
                    builderDomainModel.AppendLine("\tpublic enum Role {");

                    foreach (var e in elements) {
                        var name = e.Element(XName.Get("name", scope_S100))!.Value;
                        var definition = e.Element(XName.Get("definition", scope_S100))!.Value;
                        var code = e.Element(XName.Get("code", scope_S100))!.Value;


                        var literalName = RemoveSpecialChars(definition); // definition.TrimEnd(new char[] { '\r', '\n', '\t', ' ' });

                        definition = definition.Replace("\"", "\\\"").Replace(Environment.NewLine, " ").Replace("\n", " ").TrimEnd('\t').TrimEnd(' ');

                        builderDomainModel.AppendLine($"\t\t[System.ComponentModel.Description(\"{definition}\")]");
                        builderDomainModel.AppendLine($"\t\t{code},");
                    }
                    builderDomainModel.AppendLine("\t}");
                    builderDomainModel.AppendLine();
                }
            }

            //  --- S100_FC_InformationAssociations ---------------------------------------------
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationAssociation", xmlNamespaceManager);

                if (elements.Any())
                    builderDomainModel.AppendLine("\tnamespace InformationAssociations {");

                var isFirst = true;
                foreach (var e in elements) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    var roles = e.Elements(XName.Get("role", scope_S100)).Select(e => e.Attribute("ref")!.Value);

                    roles = roles.Where(r => productSpecification.XPathSelectElements($"//S100FC:informationBinding[S100FC:association[@ref=\"{code}\"] and S100FC:role[@ref=\"{r}\"]]", xmlNamespaceManager).Any());

                    if (!isFirst)
                        builderDomainModel.AppendLine();
                    isFirst = false;

                    //if (spatialAssociationTypes.Contains(code))
                    //    builderDomainModel.AppendLine("\t\t[SpatialAssocation]");

                    var s = BuildClass(e, new BuildClassClient {
                        ProductSpecification = productSpecification,
                        KnownTypes = knownTypes,
                        KnowTypesPrefix = knowTypesPrefix,
                        KnowTypesPostfix = knowTypesPostfix,
                        InformationAssociationsLookup = informationAssociationsLookup,
                        FeatureAssociationsLookup = featureAssociationsLookup,
                        ShouldSerialize = shouldSerialize,
                        SupportingSpatialAssociation = supportingSpatialAssociation,
                    });

                    builderDomainModel.AppendLine(s);
                }

                if (elements.Any()) {
                    builderDomainModel.AppendLine("\t}");
                    builderDomainModel.AppendLine();
                }
            }

            //  --- S100_FC_FeatureAssociations -------------------------------------------------
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureAssociation", xmlNamespaceManager);

                if (elements.Any())
                    builderDomainModel.AppendLine("\tnamespace FeatureAssociations {");

                var isFirst = true;
                foreach (var e in elements) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    var roles = e.Elements(XName.Get("role", scope_S100)).Select(e => e.Attribute("ref")!.Value);

                    roles = roles.Where(r => productSpecification.XPathSelectElements($"//S100FC:featureBinding[S100FC:association[@ref=\"{code}\"] and S100FC:role[@ref=\"{r}\"]]", xmlNamespaceManager).Any());

                    //if (!spatialAssociationTypes.Contains(code))
                    {
                        if (!isFirst)
                            builderDomainModel.AppendLine();
                        isFirst = false;

                        var s = BuildClass(e, new BuildClassClient {
                            ProductSpecification = productSpecification,
                            KnownTypes = knownTypes,
                            KnowTypesPrefix = knowTypesPrefix,
                            KnowTypesPostfix = knowTypesPostfix,
                            InformationAssociationsLookup = informationAssociationsLookup,
                            FeatureAssociationsLookup = featureAssociationsLookup,
                            ShouldSerialize = shouldSerialize,
                            SupportingSpatialAssociation = supportingSpatialAssociation,
                        });

                        builderDomainModel.AppendLine(s);
                    }
                }

                if (elements.Any()) {
                    builderDomainModel.AppendLine("\t}");
                    builderDomainModel.AppendLine();
                }
            }

            //  --- S100_FC_SpatialAssociations -------------------------------------------------


            builderDomainModel.AppendLine("}");

            builderDomainModel.AppendLine();

            builderDomainModel.AppendLine($"namespace S100Framework.DomainModel.{productId} {{");
            builderDomainModel.AppendLine("\tusing ComplexAttributes;");
            if (productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationAssociation", xmlNamespaceManager).Any())
                builderDomainModel.AppendLine("\tusing InformationAssociations;");
            builderDomainModel.AppendLine();

            //  --- S100_FC_InformationType -----------------------------------------------------
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationType", xmlNamespaceManager);

                if (elements.Any())
                    builderDomainModel.AppendLine("\tnamespace InformationTypes {");

                var informationTypes = new List<string>();

                var notFinished = false;
                do {
                    notFinished = false;

                    var isFirst = true;
                    foreach (var e in elements) {
                        var name = e.Element(XName.Get("name", scope_S100))!.Value;
                        var code = e.Element(XName.Get("code", scope_S100))!.Value;

                        if (informationTypes.Contains(code))
                            continue;

                        if (e.XPathSelectElements("S100FC:subAttributeBinding", xmlNamespaceManager).Any(attribute => !knownTypes.Contains(attribute.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!))) {
                            notFinished = true;
                            continue;
                        }

                        var superType = e.Elements(XName.Get("superType", scope_S100)).FirstOrDefault();
                        if (superType != null) {
                            if (!informationTypes.Contains(superType.Value)) {
                                notFinished = true;
                                continue;
                            }
                        }

                        if (!isFirst)
                            builderDomainModel.AppendLine();
                        isFirst = false;

                        informationTypes.Add(code);
                        knownTypes.Add(code);
                        knowTypesPrefix.Add(code, code);

                        var s = BuildClass(e, new BuildClassClient {
                            ProductSpecification = productSpecification,
                            KnownTypes = knownTypes,
                            KnowTypesPrefix = knowTypesPrefix,
                            KnowTypesPostfix = knowTypesPostfix,
                            InformationAssociationsLookup = informationAssociationsLookup,
                            FeatureAssociationsLookup = featureAssociationsLookup,
                            ShouldSerialize = shouldSerialize,
                            SupportingSpatialAssociation = supportingSpatialAssociation,
                        }, (builder) => {
                            builder.AppendLine();
                            builder.AppendLine("\t\t\t[JsonIgnore]");
                            builder.AppendLine("\t\t\t[XmlAttribute(\"id\", Namespace = \"http://www.opengis.net/gml/3.2\")]");
                            builder.AppendLine("\t\t\tpublic string? gmlId { get; set; }");
                        });

                        builderDomainModel.AppendLine(s);
                    }
                } while (notFinished);

                if (elements.Any())
                    builderDomainModel.AppendLine("\t}");
            }

            //  --- S100_FC_FeatureType ---------------------------------------------------------
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureType", xmlNamespaceManager);

                if (elements.Any()) {
                    builderDomainModel.AppendLine("\tnamespace FeatureTypes {");
                    if (productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureAssociation", xmlNamespaceManager).Any())
                        builderDomainModel.AppendLine("\t\tusing FeatureAssociations;");
                    if (productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationAssociation", xmlNamespaceManager).Any())
                        builderDomainModel.AppendLine("\t\tusing InformationTypes;");
                    builderDomainModel.AppendLine("\t\tusing System.Xml;");
                    builderDomainModel.AppendLine();
                }

                var featureTypes = new List<string>();

                var notFinished = false;
                do {
                    notFinished = false;

                    var isFirst = true;
                    foreach (var e in elements) {
                        var name = e.Element(XName.Get("name", scope_S100))!.Value;
                        var code = e.Element(XName.Get("code", scope_S100))!.Value;

                        if (featureTypes.Contains(code))
                            continue;

                        if (e.XPathSelectElements("S100FC:subAttributeBinding", xmlNamespaceManager).Any(attribute => !knownTypes.Contains(attribute.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!))) {
                            notFinished = true;
                            continue;
                        }

                        var superType = e.Elements(XName.Get("superType", scope_S100)).FirstOrDefault();
                        if (superType != null) {
                            if (!featureTypes.Contains(superType.Value)) {
                                notFinished = true;
                                continue;
                            }
                        }

                        if (!isFirst)
                            builderDomainModel.AppendLine();
                        isFirst = false;

                        featureTypes.Add(code);
                        knownTypes.Add(code);
                        knowTypesPrefix.Add(code, code);

                        var s = BuildClass(e, new BuildClassClient {
                            ProductSpecification = productSpecification,
                            KnownTypes = knownTypes,
                            KnowTypesPrefix = knowTypesPrefix,
                            KnowTypesPostfix = knowTypesPostfix,
                            InformationAssociationsLookup = informationAssociationsLookup,
                            FeatureAssociationsLookup = featureAssociationsLookup,
                            ShouldSerialize = shouldSerialize,
                            SupportingSpatialAssociation = supportingSpatialAssociation,
                        }, (builder) => {
                            builder.AppendLine();
                            builder.AppendLine("\t\t\t[JsonIgnore]");
                            builder.AppendLine("\t\t\t[XmlAttribute(\"id\", Namespace = \"http://www.opengis.net/gml/3.2\")]");
                            builder.AppendLine("\t\t\tpublic string? gmlId { get; set; }");

                            if (!(e.Attribute("isAbstract") != default && bool.Parse(e.Attribute("isAbstract")!.Value))) {
                                builder.AppendLine();
                                builder.AppendLine("\t\t\t[JsonIgnore]");
                                builder.AppendLine("\t\t\t[XmlAnyElement]");
                                builder.AppendLine("\t\t\tpublic XmlElement[]? Geometry { get; set; } = default;");
                            }
                        });

                        builderDomainModel.AppendLine(s);
                    }
                } while (notFinished);

                if (elements.Any())
                    builderDomainModel.AppendLine("\t}");
            }


            //  --- GML -------------------------------------------------------------------------
            var xmlTypeNamespace = $"Namespace = \"http://www.iho.int/{productId}/{versionNumber.Remove(versionNumber.LastIndexOf('.'))}\"";
            builderDomainModel.AppendLine("");
            builderDomainModel.AppendLine($"\t[XmlType({xmlTypeNamespace})]");
            builderDomainModel.AppendLine("\tpublic class Dataset : S100Framework.DomainModel.S100.DatasetBase");
            builderDomainModel.AppendLine("\t{");

            builderDomainModel.AppendLine("\t\t[XmlElement(Order = 1)]");
            builderDomainModel.AppendLine("\t\tpublic Members? members { get; set; } = default;");

            builderDomainModel.AppendLine("\t}");
            builderDomainModel.AppendLine("");


            List<string> xmlElements;


            xmlElements = [.. productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationType", xmlNamespaceManager).Where(e => e.Attribute("isAbstract") is null || e.Attribute("isAbstract")!.Value.Equals("false", StringComparison.InvariantCultureIgnoreCase)).Select(e => "InformationTypes." + e.Element(XName.Get("code", scope_S100))!.Value),
                            .. productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureType", xmlNamespaceManager).Where(e => e.Attribute("isAbstract") is null || e.Attribute("isAbstract")!.Value.Equals("false", StringComparison.InvariantCultureIgnoreCase)).Select(e => "FeatureTypes." + e.Element(XName.Get("code", scope_S100))!.Value)];


            builderDomainModel.AppendLine($"\t[XmlType({xmlTypeNamespace}, TypeName = \"members\")]");
            builderDomainModel.AppendLine("\tpublic class Members");
            builderDomainModel.AppendLine("\t{");
            foreach (var name in xmlElements) {
                builderDomainModel.AppendLine($"\t\t[XmlElement(\"{name}\", typeof({name}), Order = 1, ElementName = \"{name.Split('.')[^1]}\")]");
            }
            builderDomainModel.AppendLine("\t\tpublic List<object> elements { get; set; } = new List<object>();");
            builderDomainModel.AppendLine("\t}");

            builderDomainModel.AppendLine("}");

            builderDomainModel.AppendLine();

            builderDomainModel.AppendLine("#pragma warning restore CS8981");

            var viewmodel = BuildViewModel(productSpecification, new BuildViewModelClient {
                ProductSpecification = productSpecification,
                KnownTypes = knownTypes,
                KnowTypesPrefix = knowTypesPrefix,
                KnowTypesPostfix = knowTypesPostfix,
                EnumerationTypes = enumTypes,
                CodeListTypes = codelistTypes,
                ComplexTypes = complexTypes,
                InformationAssociationsLookup = informationAssociationsLookup,
                FeatureAssociationsLookup = featureAssociationsLookup,
                Editors = editorBuilders,
            });

            return (builderDomainModel.ToString(), viewmodel);
        }

        struct BuildViewModelClient
        {
            public required XDocument ProductSpecification { get; init; }
            public required IReadOnlyCollection<string> KnownTypes { get; init; }
            public required IReadOnlyDictionary<string, string> KnowTypesPrefix { get; init; }
            public required IReadOnlyDictionary<string, string> KnowTypesPostfix { get; init; }
            public required IReadOnlyCollection<string> EnumerationTypes { get; init; }
            public required IReadOnlyCollection<string> CodeListTypes { get; init; }
            public required IReadOnlyCollection<string> ComplexTypes { get; init; }
            public required IReadOnlyDictionary<string, ICollection<string>> InformationAssociationsLookup { get; init; }
            public required IReadOnlyDictionary<string, ICollection<string>> FeatureAssociationsLookup { get; init; }

            public required IReadOnlyDictionary<string, Action<StringBuilder,int,int?>> Editors { get; init; }
        }

        private static string BuildViewModel(XDocument productSpecification, BuildViewModelClient client) {
            var navigator = productSpecification.CreateNavigator();
            navigator.MoveToFollowing(XPathNodeType.Element);
            var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var e in scopes)
                xmlNamespaceManager.AddNamespace(e.Key, e.Value);

            var productId = productSpecification.XPathSelectElement("//S100FC:productId", xmlNamespaceManager)!.Value.Replace("-", string.Empty).ToUpperInvariant();
            var versionNumber = productSpecification.XPathSelectElement("//S100FC:versionNumber", xmlNamespaceManager)!.Value;

            var scope_S100 = scopes["S100FC"];

            var builderViewModel = new StringBuilder();

            builderViewModel.AppendLine("using System;");
            builderViewModel.AppendLine("using System.Linq;");
            builderViewModel.AppendLine("using System.Runtime.CompilerServices;");
            builderViewModel.AppendLine("using System.Collections.Immutable;");
            builderViewModel.AppendLine("using System.Collections.ObjectModel;");
            builderViewModel.AppendLine("using System.Reflection;");
            builderViewModel.AppendLine("using System.ComponentModel;");
            builderViewModel.AppendLine("using S100Framework.DomainModel;");
            builderViewModel.AppendLine($"using S100Framework.DomainModel.{productId};");
            builderViewModel.AppendLine($"using S100Framework.DomainModel.{productId}.ComplexAttributes;");
            if (productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationType", xmlNamespaceManager).Any())
                builderViewModel.AppendLine($"using S100Framework.DomainModel.{productId}.InformationTypes;");
            if (productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureType", xmlNamespaceManager).Any())
                builderViewModel.AppendLine($"using S100Framework.DomainModel.{productId}.FeatureTypes;");
            if (productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationAssociation", xmlNamespaceManager).Any())
                builderViewModel.AppendLine($"using S100Framework.DomainModel.{productId}.InformationAssociations;");
            if (productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureAssociation", xmlNamespaceManager).Any())
                builderViewModel.AppendLine($"using S100Framework.DomainModel.{productId}.FeatureAssociations;");

            builderViewModel.AppendLine("using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;");
            builderViewModel.AppendLine();
            builderViewModel.AppendLine("#nullable enable");
            builderViewModel.AppendLine("#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.");
            builderViewModel.AppendLine();
            builderViewModel.AppendLine();
            builderViewModel.AppendLine($"namespace S100Framework.WPF.ViewModel.{productId} {{");

            builderViewModel.AppendLine("\tinternal static class Bootstrap {");
            var indexBootstrap = builderViewModel.Length;
            builderViewModel.AppendLine("\t}");
            builderViewModel.AppendLine();

            var bootstrapCreateInformationAssociation = new StringBuilder().AppendLine("\t\tpublic static AssociationViewModel CreateInformationAssociation(string type, string? name = default) => type switch {");
            var bootstrapCreateFeatureAssociation = new StringBuilder().AppendLine("\t\tpublic static AssociationViewModel CreateFeatureAssociation(string type, string? name = default) => type switch {");
            var bootstrapCreateInformationType = new StringBuilder().AppendLine("\t\tpublic static InformationViewModel CreateInformationType(string type, string? name = default) => type switch {");
            var bootstrapCreateFeatureType = new StringBuilder().AppendLine("\t\tpublic static FeatureViewModel CreateFeatureType(string type, string? name = default) => type switch {");

            //  --- S100_FC_ComplexAttributes ---------------------------------------------------
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_ComplexAttribute", xmlNamespaceManager);

                foreach (var e in elements) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    if (e.Attribute("isAbstract") != default && bool.Parse(e.Attribute("isAbstract")!.Value))
                        continue;

                    var s = BuildViewModelClass(e, new BuildViewModelClassClient {
                        ProductSpecification = client.ProductSpecification,
                        KnownTypes = client.KnownTypes,
                        KnowTypesPrefix = client.KnowTypesPrefix,
                        KnowTypesPostfix = client.KnowTypesPostfix,
                        CodeListTypes = client.CodeListTypes,
                        EnumerationTypes = client.EnumerationTypes,
                        ComplexTypes = client.ComplexTypes,
                        BaseClass = "ViewModelBase",
                        LoadPrefix = $"{code}ViewModel",
                        Editors = client.Editors,
                    });

                    builderViewModel.AppendLine(s);
                }
                builderViewModel.AppendLine();
            }

            //  --- S100_FC_InformationAssociations ---------------------------------------------
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationAssociation", xmlNamespaceManager);

                var isFirst = true;
                foreach (var e in elements) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    if (e.Attribute("isAbstract") != default && bool.Parse(e.Attribute("isAbstract")!.Value))
                        continue;

                    if (!isFirst)
                        builderViewModel.AppendLine();
                    isFirst = false;

                    var s = BuildViewModelClass(e, new BuildViewModelClassClient {
                        ProductSpecification = client.ProductSpecification,
                        KnownTypes = client.KnownTypes,
                        KnowTypesPrefix = client.KnowTypesPrefix,
                        KnowTypesPostfix = client.KnowTypesPostfix,
                        EnumerationTypes = client.EnumerationTypes,
                        CodeListTypes = client.CodeListTypes,
                        ComplexTypes = client.ComplexTypes,
                        BaseClass = "AssociationViewModel",
                        LoadPrefix = $"{code}ViewModel",
                        Editors = client.Editors,
                    });

                    builderViewModel.AppendLine(s);

                    bootstrapCreateInformationAssociation.AppendLine($"\t\t\t\"{code}\" => new {code}ViewModel {{ Name = name }},");
                }
                builderViewModel.AppendLine();
            }

            //  --- S100_FC_FeatureAssociations -------------------------------------------------
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureAssociation", xmlNamespaceManager);

                var isFirst = true;
                foreach (var e in elements) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    if (e.Attribute("isAbstract") != default && bool.Parse(e.Attribute("isAbstract")!.Value))
                        continue;

                    if (!isFirst)
                        builderViewModel.AppendLine();
                    isFirst = false;

                    var s = BuildViewModelClass(e, new BuildViewModelClassClient {
                        ProductSpecification = client.ProductSpecification,
                        KnownTypes = client.KnownTypes,
                        KnowTypesPrefix = client.KnowTypesPrefix,
                        KnowTypesPostfix = client.KnowTypesPostfix,
                        EnumerationTypes = client.EnumerationTypes,
                        CodeListTypes = client.CodeListTypes,
                        ComplexTypes = client.ComplexTypes,
                        BaseClass = "AssociationViewModel",
                        LoadPrefix = $"{code}ViewModel",
                        Editors = client.Editors,
                    });

                    builderViewModel.AppendLine(s);

                    bootstrapCreateFeatureAssociation.AppendLine($"\t\t\t\"{code}\" => new {code}ViewModel {{ Name = name }},");
                }
                builderViewModel.AppendLine();
            }

            //  --- S100_FC_InformationType -----------------------------------------------------
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationType", xmlNamespaceManager);

                var isFirst = true;
                foreach (var e in elements) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    if (e.Attribute("isAbstract") != default && bool.Parse(e.Attribute("isAbstract")!.Value))
                        continue;

                    if (!isFirst)
                        builderViewModel.AppendLine();
                    isFirst = false;

                    var s = BuildViewModelClass(e, new BuildViewModelClassClient {
                        ProductSpecification = client.ProductSpecification,
                        KnownTypes = client.KnownTypes,
                        KnowTypesPrefix = client.KnowTypesPrefix,
                        KnowTypesPostfix = client.KnowTypesPostfix,
                        EnumerationTypes = client.EnumerationTypes,
                        CodeListTypes = client.CodeListTypes,
                        ComplexTypes = client.ComplexTypes,
                        BaseClass = $"InformationViewModel<{code}>",
                        LoadPrefix = $"override InformationViewModel<{code}>",
                        Editors = client.Editors,
                    }, (b) => {
                        b.AppendLine($"\t\tpublic override informationBindingDefinition[] informationBindingDefinitions => {code}._informationBindingDefinitions;");
                    });

                    builderViewModel.AppendLine(s);

                    bootstrapCreateInformationType.AppendLine($"\t\t\t\"{code}\" => new {code}ViewModel {{ Name = name }},");
                }
                builderViewModel.AppendLine();
            }

            //  --- S100_FC_FeatureType ---------------------------------------------------------
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureType", xmlNamespaceManager);

                var isFirst = true;
                foreach (var e in elements) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    if (e.Attribute("isAbstract") != default && bool.Parse(e.Attribute("isAbstract")!.Value))
                        continue;

                    if (!isFirst)
                        builderViewModel.AppendLine();
                    isFirst = false;

                    var s = BuildViewModelClass(e, new BuildViewModelClassClient {
                        ProductSpecification = client.ProductSpecification,
                        KnownTypes = client.KnownTypes,
                        KnowTypesPrefix = client.KnowTypesPrefix,
                        KnowTypesPostfix = client.KnowTypesPostfix,
                        EnumerationTypes = client.EnumerationTypes,
                        CodeListTypes = client.CodeListTypes,
                        ComplexTypes = client.ComplexTypes,
                        BaseClass = $"FeatureViewModel<{code}>",
                        LoadPrefix = $"override FeatureViewModel<{code}>",
                        Editors = client.Editors,
                    }, (b) => {
                        b.AppendLine($"\t\tpublic override informationBindingDefinition[] informationBindingDefinitions => {code}._informationBindingDefinitions;");
                        b.AppendLine($"\t\tpublic override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. {code}._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];");
                        b.AppendLine();
                        b.AppendLine($"\t\tpublic override featureBindingDefinition[] featureBindingDefinitions => {code}._featureBindingDefinitions;");
                    });

                    builderViewModel.AppendLine(s);

                    bootstrapCreateFeatureType.AppendLine($"\t\t\t\"{code}\" => new {code}ViewModel {{ Name = name }},");
                }
                builderViewModel.AppendLine();
            }

            builderViewModel.AppendLine("}");

            var bootstrapInformationAssociationBindings = new StringBuilder().AppendLine("\t\tpublic static ICollection<string> InformationAssociationBindings(string association, string role) => (association, role) switch {");
            foreach (var e in client.InformationAssociationsLookup) {
                var values = e.Value.Distinct().Select(i => $"\"{i}\"");
                bootstrapInformationAssociationBindings.AppendLine($"\t\t\t({e.Key}) => [{string.Join(',', values)}],");
            }

            var bootstrapFeatureAssociationBindings = new StringBuilder().AppendLine("\t\tpublic static ICollection<string> FeatureAssociationBindings(string association, string role) => (association, role) switch {");
            foreach (var e in client.FeatureAssociationsLookup) {
                var values = e.Value.Distinct().Select(i => $"\"{i}\"");
                bootstrapFeatureAssociationBindings.AppendLine($"\t\t\t({e.Key}) => [{string.Join(',', values)}],");
            }

            builderViewModel.Insert(indexBootstrap, bootstrapFeatureAssociationBindings.AppendLine("\t\t\t_ => throw new InvalidOperationException(),").AppendLine("\t\t};").ToString());
            builderViewModel.Insert(indexBootstrap, bootstrapInformationAssociationBindings.AppendLine("\t\t\t_ => throw new InvalidOperationException(),").AppendLine("\t\t};").AppendLine().ToString());

            builderViewModel.Insert(indexBootstrap, bootstrapCreateFeatureType.AppendLine("\t\t\t_ or \"\" => throw new InvalidOperationException(),").AppendLine("\t\t};").AppendLine().ToString());
            builderViewModel.Insert(indexBootstrap, bootstrapCreateInformationType.AppendLine("\t\t\t_ or \"\" => throw new InvalidOperationException(),").AppendLine("\t\t};").AppendLine().ToString());
            builderViewModel.Insert(indexBootstrap, bootstrapCreateFeatureAssociation.AppendLine("\t\t\t_ or \"\" => throw new InvalidOperationException(),").AppendLine("\t\t};").AppendLine().ToString());
            builderViewModel.Insert(indexBootstrap, bootstrapCreateInformationAssociation.AppendLine("\t\t\t_ or \"\" => throw new InvalidOperationException(),").AppendLine("\t\t};").AppendLine().ToString());





            return builderViewModel.ToString();
        }

        struct BuildClassClient
        {
            public required XDocument ProductSpecification { get; init; }
            public required IReadOnlyCollection<string> KnownTypes { get; init; }
            public required IReadOnlyDictionary<string, string> KnowTypesPrefix { get; init; }
            public required IReadOnlyDictionary<string, string> KnowTypesPostfix { get; init; }

            public required IDictionary<string, ICollection<string>> InformationAssociationsLookup { get; init; }
            public required IDictionary<string, ICollection<string>> FeatureAssociationsLookup { get; init; }

            public required IDictionary<string, Func<string, string>> ShouldSerialize { get; init; }

            public required bool SupportingSpatialAssociation { get; init; }
        }

        private static string BuildClass(XElement e, BuildClassClient client, Action<StringBuilder>? postBuilder = default) {
            var navigator = client.ProductSpecification.CreateNavigator();
            navigator.MoveToFollowing(XPathNodeType.Element);
            var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var s in scopes)
                xmlNamespaceManager.AddNamespace(s.Key, s.Value);

            var productId = client.ProductSpecification.XPathSelectElement("//S100FC:productId", xmlNamespaceManager)!.Value.Replace("-", string.Empty).ToUpperInvariant();
            var versionNumber = client.ProductSpecification.XPathSelectElement("//S100FC:versionNumber", xmlNamespaceManager)!.Value;

            var scope_S100 = scopes["S100FC"];

            var builder = new StringBuilder();

            var name = e.Element(XName.Get("name", scope_S100))!.Value;
            var definition = e.Element(XName.Get("definition", scope_S100))!.Value.TrimEnd(Environment.NewLine.ToArray());
            var code = e.Element(XName.Get("code", scope_S100))!.Value;

            var inheritance = e.Name.LocalName switch {
                "S100_FC_InformationType" => "InformationNode, IInformationBindingDefinition",
                "S100_FC_FeatureType" => "FeatureNode, IFeatureBindingDefinition",
                "S100_FC_InformationAssociation" => "InformationAssociation",
                "S100_FC_FeatureAssociation" => "FeatureAssociation",
                _ => throw new InvalidDataException(),
            };

            var xmlType = $"[XmlType(Namespace = \"http://www.iho.int/{productId}/{versionNumber.Remove(versionNumber.LastIndexOf('.'))}\")]";

            var encapsulation = (e.Attribute("isAbstract") != default && bool.Parse(e.Attribute("isAbstract")!.Value)) ? "abstract" : "partial";

            var superType = e.Elements(XName.Get("superType", scope_S100)).FirstOrDefault();
            if (superType != null) {
                inheritance = $"{superType!.Value}";
            }

            builder.AppendLine($"\t\t/// <summary>");
            builder.AppendLine($"\t\t/// {definition}");
            builder.AppendLine($"\t\t/// </summary>");

            builder.AppendLine("\t\t[System.Serializable()]");
            builder.AppendLine("\t\t[System.Diagnostics.CodeAnalysis.SuppressMessage(\"Style\", \"IDE1006: Naming Styles\", Justification = \"<Pending>\")]");
            //builder.AppendLine($"\t\t{xmlType}");
            builder.AppendLine($"\t\tpublic {encapsulation} class {code} : {inheritance} {{");

            var isFirst = true;
            foreach (var attributeBinding in e.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                if (!isFirst)
                    builder.AppendLine();
                isFirst = false;

                var referenceCode = attributeBinding.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!;
                var permittedValues = attributeBinding.XPathSelectElement("S100FC:permittedValues", xmlNamespaceManager);
                var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                var _ = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                int? upper = (_.Attribute(XName.Get("infinite")) != default && _.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? null : int.Parse(_.Value!);

                var prefix = client.KnowTypesPrefix[referenceCode];
                var postfix = client.KnowTypesPostfix.ContainsKey(referenceCode) ? $" = {client.KnowTypesPostfix[referenceCode]};" : string.Empty;

                if (permittedValues is not null) {
                    builder.AppendLine($"\t\t\t[EnumerationValue([{string.Join(',', permittedValues.XPathSelectElements("S100FC:value", xmlNamespaceManager).Select(e => e.Value))}])]");
                }

                if (prefix.Equals("DateOnly")) {
                    builder.AppendLine("\t\t\t[XmlIgnore]");
                }

                if (lower == 0 && upper.HasValue && upper.Value == 1) {
                    prefix += "?";
                    postfix = " = default;";
                }
                else if (lower == 1 && upper.HasValue && upper.Value == 1) {
                    if (!client.KnowTypesPrefix[referenceCode].Equals("String"))
                        builder.AppendLine($"\t\t\t[Required()]");
                }
                else {
                    prefix = $"List<{prefix}>";
                    postfix = " = [];";
                }
                builder.AppendLine($"\t\t\tpublic {prefix} {referenceCode} {{get;set;}}{postfix}");

                if (prefix.Equals("DateOnly")) {
                    builder.AppendLine();
                    builder.AppendLine("\t\t\t[JsonIgnore]");
                    builder.AppendLine($"\t\t\t[System.Xml.Serialization.XmlElementAttribute(DataType = \"date\", ElementName = \"{referenceCode}\")]");
                    builder.AppendLine($"\t\t\tpublic DateTime {referenceCode}Field {{");
                    builder.AppendLine($"\t\t\t\tget {{ return {referenceCode}.ToDateTime(TimeOnly.MinValue); }}");
                    builder.AppendLine($"\t\t\t\tset {{ {referenceCode} = DateOnly.FromDateTime(value); }}");
                    builder.AppendLine("\t\t\t}");
                }

                if (lower == 0 && upper.HasValue && upper.Value == 1) {
                    builder.AppendLine();
                    builder.AppendLine($"\t\t\tpublic bool ShouldSerialize{referenceCode}() {{ return {client.ShouldSerialize[prefix](referenceCode)}; }}");
                }
                if (prefix.StartsWith("List<")) {
                    builder.AppendLine();
                    builder.AppendLine($"\t\t\tpublic bool ShouldSerialize{referenceCode}() {{ return {referenceCode}.Any(); }}");
                }
            }

            if (!isFirst)
                builder.AppendLine();
            builder.AppendLine("\t\t\t[JsonIgnore]");
            builder.AppendLine($"\t\t\tpublic override string Code => nameof({code});");

            if (new string[] { "S100_FC_InformationType", "S100_FC_FeatureType" }.Contains(e.Name.LocalName)) {
                builder.AppendLine();
                builder.AppendLine("\t\t\t[JsonIgnore]");
                if (superType != null)
                    builder.AppendLine($"\t\t\tpublic override informationBindingDefinition[] informationBindingDefinitions => [..{superType!.Value}._informationBindingDefinitions, ..{code}._informationBindingDefinitions];");
                else
                    builder.AppendLine($"\t\t\tpublic override informationBindingDefinition[] informationBindingDefinitions => {code}._informationBindingDefinitions;");

                var informationBindings = new StringBuilder();

                if (superType != null)
                    informationBindings.AppendLine("\t\t\tpublic new static informationBindingDefinition[] _informationBindingDefinitions => [");
                else
                    informationBindings.AppendLine("\t\t\tpublic static informationBindingDefinition[] _informationBindingDefinitions => [");

                foreach (var informationBinding in e.XPathSelectElements("S100FC:informationBinding", xmlNamespaceManager)) {
                    var roleType = informationBinding.Attribute("roleType")!.Value;
                    var association = informationBinding.Element(XName.Get("association", scope_S100))!.Attribute("ref")!.Value;
                    var role = informationBinding.Element(XName.Get("role", scope_S100))!.Attribute("ref")!.Value;

                    var lower = int.Parse(informationBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                    var upper = informationBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;

                    int? _ = (upper.Attribute(XName.Get("infinite")) != default && upper.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? null : int.Parse(upper.Value!);
                    informationBindings.AppendLine("\t\t\t\tnew informationBindingDefinition {");
                    informationBindings.AppendLine($"\t\t\t\t\troleType = roleType.{roleType},");
                    informationBindings.AppendLine($"\t\t\t\t\tlower = {lower},");
                    if (_.HasValue)
                        informationBindings.AppendLine($"\t\t\t\t\tupper =  {_.Value},");
                    else
                        informationBindings.AppendLine($"\t\t\t\t\tupper =  default,");
                    informationBindings.AppendLine($"\t\t\t\t\tassociation = nameof({association}),");
                    informationBindings.AppendLine($"\t\t\t\t\trole = Enum.GetName<Role>(Role.{role})!,");
                    informationBindings.AppendLine($"\t\t\t\t\tinformationTypes = [{string.Join(',', informationBinding.Elements(XName.Get("informationType", scope_S100)).Select(e => $"nameof({e.Attribute("ref")!.Value})"))}],");
                    informationBindings.AppendLine($"\t\t\t\t\tprimitives = [],");
                    informationBindings.AppendLine("\t\t\t\t},");

                    var key = $"\"{association}\", \"{role}\"";
                    if (!client.InformationAssociationsLookup.ContainsKey(key))
                        client.InformationAssociationsLookup.Add(key, new List<string>());
                    foreach (var informationType in informationBinding.Elements(XName.Get("informationType", scope_S100))) {
                        client.InformationAssociationsLookup[key].Add(informationType.Attribute("ref")!.Value);
                    }
                }

                //SPATIALASSOCIATION
                if (client.SupportingSpatialAssociation && new string[] { "S100_FC_FeatureType" }.Contains(e.Name.LocalName)) {
                    var primitives = e.XPathSelectElements("S100FC:permittedPrimitives", xmlNamespaceManager);
                    if (primitives.Any(e => spatialAssociationPrimitives.Contains(Enum.Parse<Primitives>(e.Value!)))) {
                        var p = primitives.Where(e => spatialAssociationPrimitives.Contains(Enum.Parse<Primitives>(e.Value!))).Select(e => $"Primitives.{Enum.Parse<Primitives>(e.Value!)}");
                        informationBindings.AppendLine("\t\t\t\tnew informationBindingDefinition {");
                        informationBindings.AppendLine($"\t\t\t\t\troleType = roleType.association,");
                        informationBindings.AppendLine($"\t\t\t\t\tlower = 0,");
                        informationBindings.AppendLine($"\t\t\t\t\tupper =  1,");
                        informationBindings.AppendLine($"\t\t\t\t\tassociation = nameof(SpatialAssociation),");
                        informationBindings.AppendLine($"\t\t\t\t\trole = Enum.GetName<Role>(Role.theQualityInformation)!,");
                        informationBindings.AppendLine($"\t\t\t\t\tinformationTypes = [{string.Join(',', "nameof(SpatialQuality)")}],");
                        informationBindings.AppendLine($"\t\t\t\t\tprimitives = [{string.Join(',', p)}],");
                        informationBindings.AppendLine("\t\t\t\t},");

                        //var key = $"\"SpatialAssociation\", \"theQualityInformation\"";
                        //if (!client.InformationAssociationsLookup.ContainsKey(key))
                        //    client.InformationAssociationsLookup.Add(key, new List<string>());
                        //foreach (var informationType in informationBinding.Elements(XName.Get("informationType", scope_S100))) {
                        //    client.InformationAssociationsLookup[key].Add(informationType.Attribute("ref")!.Value);
                        //}
                    }
                }


                informationBindings.AppendLine("\t\t\t];");
                builder.AppendLine(informationBindings.ToString().TrimEnd(Environment.NewLine.ToArray()));
            }

            if (new string[] { "S100_FC_FeatureType" }.Contains(e.Name.LocalName)) {
                builder.AppendLine();
                builder.AppendLine("\t\t\t[JsonIgnore]");
                if (superType != null)
                    builder.AppendLine($"\t\t\tpublic override featureBindingDefinition[] featureBindingDefinitions => [..{superType!.Value}._featureBindingDefinitions, ..{code}._featureBindingDefinitions];");
                else
                    builder.AppendLine($"\t\t\tpublic override featureBindingDefinition[] featureBindingDefinitions => {code}._featureBindingDefinitions;");

                var featureBindings = new StringBuilder();

                if (superType != null)
                    featureBindings.AppendLine("\t\t\tpublic new static featureBindingDefinition[] _featureBindingDefinitions => [");
                else
                    featureBindings.AppendLine("\t\t\tpublic static featureBindingDefinition[] _featureBindingDefinitions => [");

                foreach (var featureBinding in e.XPathSelectElements("S100FC:featureBinding", xmlNamespaceManager)) {
                    var roleType = featureBinding.Attribute("roleType")!.Value;
                    var association = featureBinding.Element(XName.Get("association", scope_S100))!.Attribute("ref")!.Value;
                    var role = featureBinding.Element(XName.Get("role", scope_S100))!.Attribute("ref")!.Value;

                    var lower = int.Parse(featureBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                    var upper = featureBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;

                    int? _ = (upper.Attribute(XName.Get("infinite")) != default && upper.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? null : int.Parse(upper.Value!);
                    featureBindings.AppendLine("\t\t\t\tnew featureBindingDefinition {");
                    featureBindings.AppendLine($"\t\t\t\t\troleType = roleType.{roleType},");
                    featureBindings.AppendLine($"\t\t\t\t\tlower = {lower},");
                    if (_.HasValue)
                        featureBindings.AppendLine($"\t\t\t\t\tupper =  {_.Value},");
                    else
                        featureBindings.AppendLine($"\t\t\t\t\tupper =  default,");
                    featureBindings.AppendLine($"\t\t\t\t\tassociation = nameof({association}),");
                    featureBindings.AppendLine($"\t\t\t\t\trole = Enum.GetName<Role>(Role.{role})!,");
                    featureBindings.AppendLine($"\t\t\t\t\tfeatureTypes = [{string.Join(',', featureBinding.Elements(XName.Get("featureType", scope_S100)).Select(e => $"nameof({e.Attribute("ref")!.Value})"))}],");
                    featureBindings.AppendLine("\t\t\t\t},");

                    var key = $"\"{association}\", \"{role}\"";
                    if (!client.FeatureAssociationsLookup.ContainsKey(key))
                        client.FeatureAssociationsLookup.Add(key, new List<string>());
                    foreach (var featureType in featureBinding.Elements(XName.Get("featureType", scope_S100))) {
                        client.FeatureAssociationsLookup[key].Add(featureType.Attribute("ref")!.Value);
                    }
                }
                featureBindings.AppendLine("\t\t\t];");

                builder.AppendLine();
                builder.AppendLine("\t\t\t[JsonIgnore]");
                if (superType != null)
                    builder.AppendLine($"\t\t\tpublic override Primitives[] primitives => [..{superType!.Value}._primitives, ..{code}._primitives];");
                else
                    builder.AppendLine($"\t\t\tpublic override Primitives[] primitives => {code}._primitives;");

                if (superType != null)
                    builder.AppendLine("\t\t\tpublic new static Primitives[] _primitives => [");
                else
                    builder.AppendLine("\t\t\tpublic static Primitives[] _primitives => [");

                var primitives = e.XPathSelectElements("S100FC:permittedPrimitives", xmlNamespaceManager);
                builder.AppendLine($"\t\t\t\t{string.Join(", ", primitives.Select(e => $"Primitives.{e.Value!}"))}");
                builder.AppendLine("\t\t\t];");
                builder.AppendLine();

                builder.AppendLine(featureBindings.ToString().TrimEnd(Environment.NewLine.ToArray()));
            }

            postBuilder?.Invoke(builder);

            builder.AppendLine("\t\t}");

            return builder.ToString().TrimEnd([.. Environment.NewLine]);
            //return Regex.Replace(builder.ToString().TrimEnd([.. Environment.NewLine]), @"\r(?!\n)", "\r\n");            
        }

        struct BuildViewModelClassClient
        {
            public required XDocument ProductSpecification { get; init; }
            public required IReadOnlyCollection<string> KnownTypes { get; init; }
            public required IReadOnlyDictionary<string, string> KnowTypesPrefix { get; init; }
            public required IReadOnlyDictionary<string, string> KnowTypesPostfix { get; init; }

            public required IReadOnlyCollection<string> EnumerationTypes { get; init; }

            public required IReadOnlyCollection<string> CodeListTypes { get; init; }

            public required IReadOnlyCollection<string> ComplexTypes { get; init; }

            public required string BaseClass { get; init; }

            public required string LoadPrefix { get; init; }

            public required IReadOnlyDictionary<string, Action<StringBuilder, int, int?>> Editors { get; init; }
        }

        private static string BuildViewModelClass(XElement e, BuildViewModelClassClient client, Action<StringBuilder>? postAction = null) {
            var navigator = client.ProductSpecification.CreateNavigator();
            navigator.MoveToFollowing(XPathNodeType.Element);
            var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var s in scopes)
                xmlNamespaceManager.AddNamespace(s.Key, s.Value);

            var scope_S100 = scopes["S100FC"];

            var name = e.Element(XName.Get("name", scope_S100))!.Value;
            var definition = e.Element(XName.Get("definition", scope_S100))!.Value;
            var code = e.Element(XName.Get("code", scope_S100))!.Value;

            var builder = new StringBuilder();

            builder.AppendLine($"\t/// <summary>");
            builder.AppendLine($"\t/// {definition}");
            builder.AppendLine($"\t/// </summary>");

            builder.AppendLine($"\t[CategoryOrder(\"{code}\",0)]");
            builder.AppendLine($"\t[CategoryOrder(\"InformationBindings\",100)]");
            builder.AppendLine($"\t[CategoryOrder(\"FeatureBindings\",200)]");

            builder.AppendLine($"\tpublic partial class {code}ViewModel : {client.BaseClass} {{");

            var constructorBuilder = new StringBuilder();

            var loadBuilder = new StringBuilder();

            var serializeBuilder = new StringBuilder();
            serializeBuilder.AppendLine($"\t\t\tvar instance = new {code} {{");

            var modelBuilder = new StringBuilder();

            BuildViewModelClassAttribute(code, e, builder, loadBuilder, serializeBuilder, modelBuilder, constructorBuilder, new BuildViewModelClassAttributeClient {
                BuildViewModelClassClient = client,
                XmlNamespaceManager = xmlNamespaceManager,
                XPathNavigator = navigator,
            });

            serializeBuilder.AppendLine("\t\t\t};");
            serializeBuilder.AppendLine("\t\t\treturn System.Text.Json.JsonSerializer.Serialize(instance);");

            builder.AppendLine();
            builder.AppendLine($"\t\tpublic {client.LoadPrefix} Load({code} instance) {{");
            builder.AppendLine(loadBuilder.ToString().TrimEnd([.. Environment.NewLine]));
            builder.AppendLine("\t\t\treturn this;");
            builder.AppendLine("\t\t}");

            builder.AppendLine();
            builder.AppendLine("\t\tpublic override string Serialize() {");
            builder.AppendLine(serializeBuilder.ToString().TrimEnd([.. Environment.NewLine]));
            builder.AppendLine("\t\t}");

            builder.AppendLine();
            builder.AppendLine("\t\t[Browsable(false)]");
            builder.AppendLine($"\t\tpublic {code} Model => new () {{");
            builder.AppendLine(modelBuilder.ToString().TrimEnd([.. Environment.NewLine]));
            builder.AppendLine("\t\t};");

            postAction?.Invoke(builder);

            builder.AppendLine();
            builder.AppendLine($"\t\tpublic override string? ToString() => $\"{name}\";");

            if (constructorBuilder.Length > 0) {
                builder.AppendLine();
                builder.AppendLine($"\t\tpublic {code}ViewModel() : base() {{");
                builder.AppendLine(constructorBuilder.ToString().TrimEnd([.. Environment.NewLine]));
                builder.AppendLine("\t\t}");
            }

            builder.AppendLine("\t}");
            builder.AppendLine();

            return builder.ToString().TrimEnd([.. Environment.NewLine]);
        }

        struct BuildViewModelClassAttributeClient
        {
            public required BuildViewModelClassClient BuildViewModelClassClient { get; init; }
            public required XmlNamespaceManager XmlNamespaceManager { get; init; }

            public required XPathNavigator XPathNavigator { get; init; }
        }

        private static void BuildViewModelClassAttribute(string code, XElement e, StringBuilder builder, StringBuilder loadBuilder, StringBuilder serializeBuilder, StringBuilder modelBuilder, StringBuilder constructorBuilder, BuildViewModelClassAttributeClient client) {
            var scopes = client.XPathNavigator.GetNamespacesInScope(XmlNamespaceScope.All);

            var xmlNamespaceManager = client.XmlNamespaceManager;

            var scope_S100 = scopes["S100FC"];

            var superType = e.Elements(XName.Get("superType", scope_S100)).FirstOrDefault();
            if (superType != null) {
                var super = client.BuildViewModelClassClient.ProductSpecification.XPathSelectElement($"//*[S100FC:code = '{superType.Value}']", xmlNamespaceManager)!;

                BuildViewModelClassAttribute(super.Element(XName.Get("code", scope_S100))!.Value, super, builder, loadBuilder, serializeBuilder, modelBuilder, constructorBuilder, client);
            }

            var attributeBindings = e.XPathSelectElements("S100FC:subAttributeBinding", xmlNamespaceManager).Union(e.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager));
            foreach (var attributeBinding in attributeBindings) {

                var referenceCode = attributeBinding.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!;
                var permittedValues = attributeBinding.XPathSelectElement("S100FC:permittedValues", xmlNamespaceManager);
                var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                var _ = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                int? upper = (_.Attribute(XName.Get("infinite")) != default && _.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? null : int.Parse(_.Value!);

                var prefix = client.BuildViewModelClassClient.KnowTypesPrefix[referenceCode];
                var postfix = client.BuildViewModelClassClient.KnowTypesPostfix.ContainsKey(referenceCode) ? $" = {client.BuildViewModelClassClient.KnowTypesPostfix[referenceCode]};" : ";";

                if (client.BuildViewModelClassClient.ComplexTypes.Contains(referenceCode)) {
                    prefix += "ViewModel";
                }

                var isCollection = false;
                if (lower == 0 && upper.HasValue && upper.Value == 1) {
                    prefix += "?";
                    postfix = " = default;";
                }
                else if (lower == 1 && upper.HasValue && upper.Value == 1) {
                }
                else {
                    isCollection = true;
                    prefix = $"ObservableCollection<{prefix}>";
                    postfix = " { get; set; } = new ();";
                }

                if (!isCollection) {
                    builder.AppendLine($"\t\tprivate {prefix} _{referenceCode} {postfix}");
                    builder.AppendLine();

                    if (!(client.BuildViewModelClassClient.ComplexTypes.Contains(code) && !client.BuildViewModelClassClient.ComplexTypes.Contains(referenceCode)))
                        builder.AppendLine($"\t\t[Category(\"{code}\")]");

                    if (client.BuildViewModelClassClient.Editors.ContainsKey(referenceCode)) {
                        client.BuildViewModelClassClient.Editors[referenceCode](builder,lower,upper);
                    }
                    //if (client.BuildViewModelClassClient.EnumerationTypes.Contains(referenceCode)) {
                    //    builder.AppendLine($"\t\t[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]");
                    //    builder.AppendLine($"\t\t[DomainModel.EnumerationAttribute(nameof({referenceCode}List), typeof({referenceCode}))]");
                    //}
                    if (client.BuildViewModelClassClient.ComplexTypes.Contains(referenceCode))
                        builder.AppendLine("\t\t[ExpandableObject]");
                    builder.AppendLine($"\t\tpublic {prefix} {referenceCode} {{");

                    builder.AppendLine("\t\t\tget {");
                    builder.AppendLine($"\t\t\t\treturn _{referenceCode};");
                    builder.AppendLine("\t\t\t}");
                    builder.AppendLine("\t\t\tset {");
                    builder.AppendLine($"\t\t\t\tSetValue(ref _{referenceCode}, value);");
                    builder.AppendLine("\t\t\t}");
                    builder.AppendLine("\t\t}");

                    if (client.BuildViewModelClassClient.ComplexTypes.Contains(referenceCode)) {
                        loadBuilder.AppendLine($"\t\t\t{referenceCode} = new ();");
                        loadBuilder.AppendLine($"\t\t\tif (instance.{referenceCode} != default) {{");
                        loadBuilder.AppendLine($"\t\t\t\t{referenceCode}.Load(instance.{referenceCode});");
                        loadBuilder.AppendLine($"\t\t\t}}");
                        serializeBuilder.AppendLine($"\t\t\t\t{referenceCode} = this.{referenceCode}?.Model,");
                        modelBuilder.AppendLine($"\t\t\t{referenceCode} = this._{referenceCode}?.Model,");
                    }
                    else {
                        loadBuilder.AppendLine($"\t\t\t{referenceCode} = instance.{referenceCode};");
                        serializeBuilder.AppendLine($"\t\t\t\t{referenceCode} = this.{referenceCode},");
                        modelBuilder.AppendLine($"\t\t\t{referenceCode} = this._{referenceCode},");
                    }
                }
                else {
                    constructorBuilder.AppendLine($"\t\t\t{referenceCode}.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {{");
                    constructorBuilder.AppendLine($"\t\t\t\tOnPropertyChanged(nameof({referenceCode}));");
                    constructorBuilder.AppendLine($"\t\t\t}};");

                    builder.AppendLine($"\t\t[Category(\"{code}\")]");
                    if (client.BuildViewModelClassClient.Editors.ContainsKey(referenceCode)) {
                        client.BuildViewModelClassClient.Editors[referenceCode](builder, lower, upper);
                    }
                    //if (client.BuildViewModelClassClient.EnumerationTypes.Contains(referenceCode)) {
                    //    builder.AppendLine($"\t\t[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]");
                    //    builder.AppendLine($"\t\t[DomainModel.EnumerationAttribute(nameof({referenceCode}List), typeof({referenceCode}))]");
                    //}                    
                    builder.AppendLine($"\t\tpublic {prefix} {referenceCode} {postfix}");
                    loadBuilder.AppendLine($"\t\t\t{referenceCode}.Clear();");
                    loadBuilder.AppendLine($"\t\t\tif (instance.{referenceCode} is not null) {{");
                    loadBuilder.AppendLine($"\t\t\t\tforeach(var e in instance.{referenceCode})");
                    if (client.BuildViewModelClassClient.ComplexTypes.Contains(referenceCode)) {
                        loadBuilder.AppendLine($"\t\t\t\t\t{referenceCode}.Add(new {referenceCode}ViewModel().Load(e));");
                        serializeBuilder.AppendLine($"\t\t\t\t{referenceCode} = this.{referenceCode}.Select(e => e.Model).ToList(),");
                        modelBuilder.AppendLine($"\t\t\t{referenceCode} = this.{referenceCode}.Select(e => e.Model).ToList(),");
                    }
                    else {
                        loadBuilder.AppendLine($"\t\t\t\t\t{referenceCode}.Add(e);");
                        serializeBuilder.AppendLine($"\t\t\t\t{referenceCode} = this.{referenceCode}.ToList(),");
                        modelBuilder.AppendLine($"\t\t\t{referenceCode} = this.{referenceCode}.ToList(),");
                    }
                    loadBuilder.AppendLine($"\t\t\t}}");
                }

                if (permittedValues is not null) {
                    if (client.BuildViewModelClassClient.CodeListTypes.Contains(referenceCode)) {
                        builder.AppendLine();
                        builder.AppendLine("\t\t[Browsable(false)]");
                        builder.AppendLine($"\t\tpublic {referenceCode}[] {referenceCode}List =>  CodeList.{pluralizer.Pluralize(referenceCode)}.ToArray();");
                    }
                    else {
                        var values = permittedValues.XPathSelectElements("S100FC:value", xmlNamespaceManager).Select(e => e.Value);

                        builder.AppendLine();
                        builder.AppendLine("\t\t[Browsable(false)]");
                        builder.AppendLine($"\t\tpublic {referenceCode}[] {referenceCode}List => [{string.Join(',', values.Select(e => $"({referenceCode}){e}"))}];");
                    }
                }
                else if (client.BuildViewModelClassClient.EnumerationTypes.Contains(referenceCode)) {
                    builder.AppendLine();
                    builder.AppendLine("\t\t[Browsable(false)]");
                    builder.AppendLine($"\t\tpublic {referenceCode}[] {referenceCode}List => Enum.GetValues<{referenceCode}>();");
                }
            }
            builder.AppendLine();
        }

        private static string RemoveSpecialChars(string input) {
            var text = Regex.Replace(input, @"[^0-9a-zA-Z_]", "##");

            var words = text.Split("##", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            for (int i = 0; i < words.Length; i++) {
                var t = words[i];

                words[i] = char.ToUpper(words[i].First()) + words[i].Substring(1).ToLowerInvariant();
            }

            text = string.Join(string.Empty, words);

            text = text.Replace(Environment.NewLine, " ").Replace("\n", " ");
            text = text.TrimEnd('\t').TrimEnd(' ');

            var match = Regex.Match(text, @"\d");
            foreach (var m in match.Captures) {
                //CurrencyWordsConverter converter = new CurrencyWordsConverter();
                //string words = converter.ToWords(amount)
            }

            foreach (var number in Enumerable.Range(0, 20)) {
                var v = $"{number}";
                if (text.StartsWith(v)) {
                    text = text.Replace(v, OnesEnglish[number]);
                }
            }
            return text;
        }

        private static readonly string[] OnesEnglish = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
    }
}
