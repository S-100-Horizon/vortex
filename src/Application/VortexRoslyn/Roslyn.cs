using Pluralize.NET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace S100Framework.Applications
{
    public static class Roslyn
    {
        private static Pluralizer pluralizer = new();

        private static ICollection<string> spatialAssociationTypes = new List<string>() { "SpatialAssociation" };

        public static (string DomainModel, string ViewModel) Build(XDocument productSpecification) {
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
            builderDomainModel.AppendLine();
            builderDomainModel.AppendLine("#nullable enable");
            builderDomainModel.AppendLine("#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.");
            builderDomainModel.AppendLine();
            builderDomainModel.AppendLine();
            builderDomainModel.AppendLine($"namespace S100Framework.DomainModel.{productId} {{");

            builderDomainModel.AppendLine("\tpublic static class Information");
            builderDomainModel.AppendLine("\t{");
            builderDomainModel.AppendLine($"\t\tpublic static Version Version => new Version(\"{versionNumber}\");");
            var indexInformation = builderDomainModel.Length;
            builderDomainModel.AppendLine("\t}");
            builderDomainModel.AppendLine();

            var knownTypes = new List<string>();

            var knowTypesPrefix = new Dictionary<string, string>();
            var knowTypesPostfix = new Dictionary<string, string>();

            //  --- S100_FC_SimpleAttributes ----------------------------------------------------
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_SimpleAttribute", xmlNamespaceManager);

                var enumTypes = new List<string>();

                //  Enumerations
                foreach (var e in elements.Where(e => e.Element(XName.Get("valueType", scope_S100))!.Value.Equals("enumeration"))) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    knownTypes.Add(code);
                    knowTypesPrefix.Add(code, code);

                    builderDomainModel.AppendLine("\t[System.Diagnostics.CodeAnalysis.SuppressMessage(\"Style\", \"IDE1006:Naming Styles\", Justification = \"<Pending>\")]");
                    builderDomainModel.AppendLine("\t[System.Serializable()]");
                    builderDomainModel.AppendLine($"\tpublic enum {code} : int {{");

                    foreach (var listedValue in e.Element(XName.Get("listedValues", scope_S100))!.Elements()) {
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
                        "s100_truncateddate" => "DateOnly",
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

                        builderDomainModel.AppendLine("\t[System.Serializable()]");
                        builderDomainModel.AppendLine("\t[System.Diagnostics.CodeAnalysis.SuppressMessage(\"Style\", \"IDE1006:Naming Styles\", Justification = \"<Pending>\")]");

                        builderDomainModel.AppendLine($"\tpublic class {code} {{");

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
                                foreach (var permittedValue in permittedValues.XPathSelectElements("S100FC:value", xmlNamespaceManager).Select(e => e.Value).ToList()) {
                                    builderDomainModel.AppendLine($"\t\t\t[EnumerationValue({permittedValue})]");
                                }
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
                        });

                        builderDomainModel.AppendLine(s);
                    }
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

                    if (!spatialAssociationTypes.Contains(code)) {
                        if (!isFirst)
                            builderDomainModel.AppendLine();
                        isFirst = false;

                        var s = BuildClass(e, new BuildClassClient {
                            ProductSpecification = productSpecification,
                            KnownTypes = knownTypes,
                            KnowTypesPrefix = knowTypesPrefix,
                            KnowTypesPostfix = knowTypesPostfix,
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
                        });

                        builderDomainModel.AppendLine(s);
                    }
                } while (notFinished);

                if (elements.Any())
                    builderDomainModel.AppendLine("\t}");
            }

            builderDomainModel.AppendLine("}");

            builderDomainModel.AppendLine();

            builderDomainModel.AppendLine("#pragma warning restore CS8981");

            var viewmodel = BuildViewModel(productSpecification, new BuildViewModelClient {
                ProductSpecification = productSpecification,
                KnownTypes = knownTypes,
                KnowTypesPrefix = knowTypesPrefix,
                KnowTypesPostfix = knowTypesPostfix,
                ComplexTypes = complexTypes,
            });

            return (builderDomainModel.ToString(), viewmodel);
        }

        struct BuildViewModelClient
        {
            public required XDocument ProductSpecification { get; init; }
            public required IReadOnlyCollection<string> KnownTypes { get; init; }
            public required IReadOnlyDictionary<string, string> KnowTypesPrefix { get; init; }
            public required IReadOnlyDictionary<string, string> KnowTypesPostfix { get; init; }

            public required IReadOnlyCollection<string> ComplexTypes { get; init; }
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
                builderViewModel.AppendLine($"using S100Framework.DomainModel.{productId}.Associations.InformationAssociations;");
            if (productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureAssociation", xmlNamespaceManager).Any())
                builderViewModel.AppendLine($"using S100Framework.DomainModel.{productId}.Associations.FeatureAssociations;");

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

            var bootstrapCreateInformationAssociation = new StringBuilder().AppendLine("\t\tpublic static AssociationViewModel CreateInformationAssociation(string type, string? pid = default) => type switch {");
            var bootstrapCreateFeatureAssociation = new StringBuilder().AppendLine("\t\tpublic static AssociationViewModel CreateFeatureAssociation(string type, string? pid = default) => type switch {");
            var bootstrapCreateInformationType = new StringBuilder().AppendLine("\t\tpublic static InformationViewModel CreateInformationType(string type, string? pid = default) => type switch {");
            var bootstrapCreateFeatureType = new StringBuilder().AppendLine("\t\tpublic static FeatureViewModel CreateFeatureType(string type, string? pid = default) => type switch {");

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
                        ComplexTypes = client.ComplexTypes,
                        BaseClass = "ViewModelBase",
                        LoadPrefix=$"{code}ViewModel",
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
                        ComplexTypes = client.ComplexTypes,
                        BaseClass = "AssociationViewModel",
                        LoadPrefix = $"{code}ViewModel",
                    });

                    builderViewModel.AppendLine(s);

                    bootstrapCreateInformationAssociation.AppendLine($"\t\t\t\"{code}\" => new {code}ViewModel {{ PID = pid }},");
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
                        ComplexTypes = client.ComplexTypes,
                        BaseClass = "AssociationViewModel",
                        LoadPrefix = $"{code}ViewModel",
                    });

                    builderViewModel.AppendLine(s);

                    bootstrapCreateFeatureAssociation.AppendLine($"\t\t\t\"{code}\" => new {code}ViewModel {{ PID = pid }},");
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
                        ComplexTypes = client.ComplexTypes,
                        BaseClass = $"InformationViewModel<{code}>",
                        LoadPrefix = $"override InformationViewModel<{code}>",
                    }, (b) => {
                        b.AppendLine($"\t\tpublic override informationBindingDefinition[] informationBindingDefinitions => {code}._informationBindingDefinitions;");                       
                    });

                    builderViewModel.AppendLine(s);

                    bootstrapCreateInformationType.AppendLine($"\t\t\t\"{code}\" => new {code}ViewModel {{ PID = pid }},");
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
                        ComplexTypes = client.ComplexTypes,
                        BaseClass = $"FeatureViewModel<{code}>",
                        LoadPrefix = $"override FeatureViewModel<{code}>",
                    }, (b) => {
                        b.AppendLine($"\t\tpublic override informationBindingDefinition[] informationBindingDefinitions => {code}._informationBindingDefinitions;");
                        b.AppendLine();
                        b.AppendLine($"\t\tpublic override featureBindingDefinition[] featureBindingDefinitions => {code}._featureBindingDefinitions;");
                    });

                    builderViewModel.AppendLine(s);

                    bootstrapCreateFeatureType.AppendLine($"\t\t\t\"{code}\" => new {code}ViewModel {{ PID = pid }},");
                }
                builderViewModel.AppendLine();
            }

            builderViewModel.AppendLine("}");

            builderViewModel.Insert(indexBootstrap, bootstrapCreateFeatureType.AppendLine("\t\t\t_ or \"\" => throw new InvalidOperationException(),").AppendLine("\t\t};").ToString());
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
        }

        private static string BuildClass(XElement e, BuildClassClient client) {
            var navigator = client.ProductSpecification.CreateNavigator();
            navigator.MoveToFollowing(XPathNodeType.Element);
            var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var s in scopes)
                xmlNamespaceManager.AddNamespace(s.Key, s.Value);

            var scope_S100 = scopes["S100FC"];

            var builder = new StringBuilder();

            var name = e.Element(XName.Get("name", scope_S100))!.Value;
            var definition = e.Element(XName.Get("definition", scope_S100))!.Value;
            var code = e.Element(XName.Get("code", scope_S100))!.Value;

            var inheritance = e.Name.LocalName switch {
                "S100_FC_InformationType" => "InformationNode, IInformationBindingDefinition",
                "S100_FC_FeatureType" => "FeatureNode, IFeatureBindingDefinition",
                "S100_FC_InformationAssociation" => "InformationAssociation",
                "S100_FC_FeatureAssociation" => "FeatureAssociation",
                _ => throw new InvalidDataException(),
            };

            var encapsulation = (e.Attribute("isAbstract") != default && bool.Parse(e.Attribute("isAbstract")!.Value)) ? "abstract" : "partial";

            var superType = e.Elements(XName.Get("superType", scope_S100)).FirstOrDefault();
            if (superType != null) {
                inheritance = $"{superType!.Value}";
            }

            builder.AppendLine($"\t/// <summary>");
            builder.AppendLine($"\t/// {definition}");
            builder.AppendLine($"\t/// </summary>");

            builder.AppendLine("\t\t[System.Serializable()]");
            builder.AppendLine("\t\t[System.Diagnostics.CodeAnalysis.SuppressMessage(\"Style\", \"IDE1006: Naming Styles\", Justification = \"<Pending>\")]");
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
                    foreach (var permittedValue in permittedValues.XPathSelectElements("S100FC:value", xmlNamespaceManager).Select(e => e.Value).ToList()) {
                        builder.AppendLine($"\t\t\t[EnumerationValue({permittedValue})]");
                    }
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

            }

            if (!isFirst)
                builder.AppendLine();
            builder.AppendLine("\t\t\t[JsonIgnore]");
            builder.AppendLine($"\t\t\tpublic override string Code => nameof({code});");

            if (new string[] { "S100_FC_InformationType", "S100_FC_FeatureType" }.Contains(e.Name.LocalName)) {
                builder.AppendLine();
                builder.AppendLine($"\t\t\tpublic informationBindingDefinition[] informationBindingDefinitions => {code}._informationBindingDefinitions;");

                var informationBindings = new StringBuilder();

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
                    informationBindings.AppendLine("\t\t\t\t},");
                }
                informationBindings.AppendLine("\t\t\t];");
                builder.AppendLine(informationBindings.ToString().TrimEnd(Environment.NewLine.ToArray()));
            }

            if (new string[] { "S100_FC_FeatureType" }.Contains(e.Name.LocalName)) {
                builder.AppendLine();
                builder.AppendLine($"\t\t\tpublic featureBindingDefinition[] featureBindingDefinitions => {code}._featureBindingDefinitions;");

                var featureBindings = new StringBuilder();

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
                }
                featureBindings.AppendLine("\t\t\t];");
                builder.AppendLine(featureBindings.ToString().TrimEnd(Environment.NewLine.ToArray()));
            }

            builder.AppendLine("\t\t}");

            return builder.ToString().TrimEnd([.. Environment.NewLine]);
        }

        struct BuildViewModelClassClient
        {
            public required XDocument ProductSpecification { get; init; }
            public required IReadOnlyCollection<string> KnownTypes { get; init; }
            public required IReadOnlyDictionary<string, string> KnowTypesPrefix { get; init; }
            public required IReadOnlyDictionary<string, string> KnowTypesPostfix { get; init; }

            public required IReadOnlyCollection<string> ComplexTypes { get; init; }

            public required string BaseClass { get; init; }

            public required string LoadPrefix { get; init; }
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

            var isFirst = true;
            var attributeBindings = e.XPathSelectElements("S100FC:subAttributeBinding", xmlNamespaceManager).Union(e.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager));
            foreach (var attributeBinding in attributeBindings) {
                if (!isFirst)
                    builder.AppendLine();
                isFirst = false;

                var referenceCode = attributeBinding.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!;
                var permittedValues = attributeBinding.XPathSelectElement("S100FC:permittedValues", xmlNamespaceManager);
                var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                var _ = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                int? upper = (_.Attribute(XName.Get("infinite")) != default && _.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? null : int.Parse(_.Value!);

                var prefix = client.KnowTypesPrefix[referenceCode];
                var postfix = client.KnowTypesPostfix.ContainsKey(referenceCode) ? $" = {client.KnowTypesPostfix[referenceCode]};" : ";";

                if (client.ComplexTypes.Contains(referenceCode)) {
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
                    builder.AppendLine($"\t\t[Category(\"{code}\")]");
                    builder.AppendLine($"\t\tpublic {prefix} {referenceCode} {{");

                    builder.AppendLine("\t\t\tget {");
                    builder.AppendLine($"\t\t\t\treturn _{referenceCode};");
                    builder.AppendLine("\t\t\t}");
                    builder.AppendLine("\t\t\tset {");
                    builder.AppendLine($"\t\t\t\tSetValue(ref _{referenceCode}, value);");
                    builder.AppendLine("\t\t\t}");
                    builder.AppendLine("\t\t}");

                    if (client.ComplexTypes.Contains(referenceCode)) {
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
                    builder.AppendLine($"\t\tpublic {prefix} {referenceCode} {postfix}");
                    loadBuilder.AppendLine($"\t\t\t{referenceCode}.Clear();");
                    loadBuilder.AppendLine($"\t\t\tif (instance.{referenceCode} is not null) {{");
                    loadBuilder.AppendLine($"\t\t\t\tforeach(var e in instance.{referenceCode})");
                    if (client.ComplexTypes.Contains(referenceCode)) {
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
                    var values = permittedValues.XPathSelectElements("S100FC:value", xmlNamespaceManager).Select(e => e.Value);

                    builder.AppendLine();
                    builder.AppendLine("\t\t[Browsable(false)]");
                    builder.AppendLine($"\t\tpublic {referenceCode}[] {referenceCode}List => [{string.Join(',', values.Select(e => $"({referenceCode}){e}"))}];");
                }
            }

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
