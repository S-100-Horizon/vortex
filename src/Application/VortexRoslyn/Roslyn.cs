using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace S100Framework.Applications
{
    internal static class Roslyn
    {
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
            var builderViewModel = new StringBuilder();

            builderDomainModel.AppendLine("using System;");
            builderDomainModel.AppendLine("using System.Collections.Immutable;");
            builderDomainModel.AppendLine("using System.Linq;");
            builderDomainModel.AppendLine("using System.Runtime.Serialization;");
            builderDomainModel.AppendLine("using System.Text.Json.Serialization;");
            builderDomainModel.AppendLine();
            builderDomainModel.AppendLine("#nullable enable");
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

                        listedValueDefinition = listedValueDefinition.Replace("\"", "\\\"");

                        builderDomainModel.AppendLine($"\t\t[System.ComponentModel.Description(\"{listedValueDefinition}\")]");
                        builderDomainModel.AppendLine($"\t\t[EnumMember(Value = \"{listedValueLabel}\")] ");
                        builderDomainModel.AppendLine($"\t\t{literalName} = {listedValueCode},");
                        builderDomainModel.AppendLine();
                    }


                    builderDomainModel.AppendLine("\t\t[System.ComponentModel.Description(\"Unknown value.\")]");
                    builderDomainModel.AppendLine("\t\t[EnumMember(Value = \"Unknown\")]");
                    builderDomainModel.AppendLine("\t\tUnknown = -1,");

                    builderDomainModel.AppendLine("\t}");
                    builderDomainModel.AppendLine();
                }

                //  CodeLists
                //TODO

                //  SimpleAttributes
                foreach (var e in elements.Where(e => !e.Element(XName.Get("valueType", scope_S100))!.Value.Equals("enumeration"))) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    knownTypes.Add(code);

                    var prefix = e.Element(XName.Get("valueType", scope_S100))!.Value switch {
                        "boolean" => "Boolean",
                        "enumeration" => code,
                        "real" => "decimal",
                        "text" => "String",
                        "S100_TruncatedDate" => "DateOnly",
                        "date" => "DateOnly",
                        "dateTime" => "DateTime",
                        "time" => "TimeOnly",
                        "integer" => "int",
                        "URN" => "String",
                        //"S100_CodeList" => codelistTypes[code],
                        "URL" => "String",
                        "URI" => "String",
                        _ => throw new InvalidDataException(),
                    };
                    knowTypesPrefix.Add(code, prefix);

                    var psotfix = e.Element(XName.Get("valueType", scope_S100))!.Value switch {
                        "boolean" => "false",
                        //"enumeration" => code,
                        //"real" => "decimal",
                        "text" => "string.Empty",
                        //"S100_TruncatedDate" => "DateOnly",
                        //"date" => "DateOnly",
                        //"dateTime" => "DateTime",
                        //"time" => "TimeOnly",
                        //"integer" => "int",
                        "URN" => "string.Empty",
                        //"S100_CodeList" => codelistTypes[code],
                        "URL" => "string.Empty",
                        "URI" => "string.Empty",
                        _ => null,
                    };
                    if (psotfix != null) {
                        knowTypesPostfix.Add(code, psotfix);
                    }
                }
            }

            //  --- S100_FC_ComplexAttributes ---------------------------------------------------
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_ComplexAttribute", xmlNamespaceManager);

                var complexTypes = new List<string>();

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

                        builderDomainModel.AppendLine("\t[System.Diagnostics.CodeAnalysis.SuppressMessage(\"Style\", \"IDE1006:Naming Styles\", Justification = \"<Pending>\")]");
                        builderDomainModel.AppendLine("\t[System.Serializable()]");

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
                                    builderDomainModel.AppendLine($"\t\t[EnumerationValue({permittedValue})]");
                                }
                            }

                            if (lower == 0 && upper.HasValue && upper.Value == 1) {
                                prefix += "?";
                                postfix = " = default;";
                            }
                            else if (lower == 1 && upper.HasValue && upper.Value == 1) {
                                builderDomainModel.AppendLine($"\t\t[Required()]");
                            }
                            else {
                                prefix = $"List<{prefix}>";
                                postfix = " = [];";
                            }
                            builderDomainModel.AppendLine($"\t\tpublic {prefix} {referenceCode} {{get;set;}}{postfix}");
                        }

                        builderDomainModel.AppendLine("\t}");
                        builderDomainModel.AppendLine();
                    }

                } while (notFinished);                
            }


            //  --- S100_FC_Roles ---------------------------------------------------------------

            //  --- S100_FC_InformationAssociations ---------------------------------------------

            //  --- S100_FC_FeatureAssociations -------------------------------------------------

            //  --- S100_FC_SpatialAssociations -------------------------------------------------


            builderDomainModel.AppendLine("}");
            
            builderDomainModel.AppendLine();
            
            builderDomainModel.AppendLine($"namespace S100Framework.DomainModel.{productId} {{");

            //  --- S100_FC_InformationType -----------------------------------------------------

            //  --- S100_FC_FeatureType ---------------------------------------------------------

            builderDomainModel.AppendLine("}");
            
            builderDomainModel.AppendLine();

            builderDomainModel.AppendLine($"namespace S100Framework.DomainModel.{productId} {{");
            builderDomainModel.AppendLine("\t[System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]");
            builderDomainModel.AppendLine("\tpublic class RequiredAttribute : System.Attribute");
            builderDomainModel.AppendLine("\t{");
            builderDomainModel.AppendLine("\t}");
            builderDomainModel.AppendLine();

            builderDomainModel.AppendLine("\t[System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]");
            builderDomainModel.AppendLine("\tpublic class EnumerationValueAttribute : System.Attribute");
            builderDomainModel.AppendLine("\t{");
            builderDomainModel.AppendLine("\t\tprivate int _propertyValue;");
            builderDomainModel.AppendLine("\t\tpublic int PropertyValue => _propertyValue;");
            builderDomainModel.AppendLine("\t\tpublic EnumerationValueAttribute(int propertyValue) {");
            builderDomainModel.AppendLine("\t\t\t_propertyValue = propertyValue;");
            builderDomainModel.AppendLine("\t\t}");
            builderDomainModel.AppendLine("\t}");
            builderDomainModel.AppendLine("}");


            return (builderDomainModel.ToString(), builderViewModel.ToString());
        }

        private static string RemoveSpecialChars(string input) {
            var text = Regex.Replace(input, @"[^0-9a-zA-Z_]", "##");

            var words = text.Split("##", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            for (int i = 0; i < words.Length; i++) {
                var t = words[i];

                words[i] = char.ToUpper(words[i].First()) + words[i].Substring(1).ToLowerInvariant();
            }

            text = string.Join(string.Empty, words);

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
