using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Formatting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using Pluralize.NET.Core;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

//TODO: Enum som lister ala Aegir


namespace S100Framework
{
    namespace DomainModel
    {
        [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
        public class RoleAttribute : System.Attribute
        {
            private string _roleName;
            public string RoleName => _roleName;

            public RoleAttribute(string roleName) {
                _roleName = roleName;
            }
        }
    }


    public static class ClassBuilder
    {
        public record informationType(string code, string? superType, bool isAbstract);
        public record featureType(string code, string? superType, bool isAbstract);

        public const string S100FC_52 = "http://www.iho.int/S100FC/5.2";

        private static Pluralizer pluralizer = new();

        public static (string fc, string view, string common) CatalogueBuilder52(XDocument productSpecification) => CatalogueBuilder(productSpecification, S100FC_52);

        public static (string fc, string view, string common) CatalogueBuilder(XDocument productSpecification, string xmlNamespace) {
            var creatorBuilder = new StringBuilder();
            var classBuilder = new StringBuilder();
            var viewBuilder = new StringBuilder();

            var navigator = productSpecification.CreateNavigator();
            navigator.MoveToFollowing(XPathNodeType.Element);
            var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var e in scopes)
                xmlNamespaceManager.AddNamespace(e.Key, e.Value);

            var productId = productSpecification.XPathSelectElement("//S100FC:productId", xmlNamespaceManager)!.Value.Replace("-", string.Empty).ToUpperInvariant();
            var versionNumber = productSpecification.XPathSelectElement("//S100FC:versionNumber", xmlNamespaceManager)!.Value;

            classBuilder.AppendLine("using System;");
            classBuilder.AppendLine("using System.Collections.Immutable;");
            classBuilder.AppendLine("using System.Linq;");
            classBuilder.AppendLine();
            classBuilder.AppendLine("#nullable enable");
            classBuilder.AppendLine();
            classBuilder.AppendLine($"namespace S100Framework.DomainModel.{productId}");
            classBuilder.AppendLine("{");
            classBuilder.AppendLine("\tpublic static class Information");
            classBuilder.AppendLine("\t{");
            classBuilder.AppendLine($"\t\tpublic static Version Version => new Version(\"{versionNumber}\");");
            var informationPosition = classBuilder.Length;
            classBuilder.AppendLine("\t}");
            classBuilder.AppendLine();

            viewBuilder.AppendLine("using System;");
            viewBuilder.AppendLine("using System.Linq;");
            viewBuilder.AppendLine("using System.ComponentModel;");
            viewBuilder.AppendLine("using System.Runtime.CompilerServices;");
            viewBuilder.AppendLine("using System.Collections.Immutable;");
            viewBuilder.AppendLine("using System.Collections.ObjectModel;");
            viewBuilder.AppendLine("using System.Reflection;");
            viewBuilder.AppendLine("using S100Framework.DomainModel;");
            viewBuilder.AppendLine("using S100Framework.DomainModel.Bindings;");
            viewBuilder.AppendLine($"using S100Framework.DomainModel.{productId};");
            viewBuilder.AppendLine($"using S100Framework.DomainModel.{productId}.ComplexAttributes;");
            viewBuilder.AppendLine($"using S100Framework.DomainModel.{productId}.InformationTypes;");
            viewBuilder.AppendLine($"using S100Framework.DomainModel.{productId}.FeatureTypes;");
            //viewBuilder.AppendLine($"using S100Framework.DomainModel.{productId}.Associations.InformationAssociations;");
            //viewBuilder.AppendLine($"using S100Framework.DomainModel.{productId}.Associations.FeatureAssociations;");
            viewBuilder.AppendLine($"using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;");
            viewBuilder.AppendLine();
            viewBuilder.AppendLine("#nullable enable");
            viewBuilder.AppendLine();
            viewBuilder.AppendLine($"namespace S100Framework.WPF.ViewModel.{productId}");
            viewBuilder.AppendLine("{");
            var creatorPosition = viewBuilder.Length;

            var assembly = new AssemblyName("S100Framework.Attributes");
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assembly, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");

            var dictionaryTypes = new Dictionary<string, Type>();
            var dictionaryTypesComplex = new List<string>();

            var scope_S100 = scopes["S100FC"];

            var enumTypes = new Dictionary<string, Type>();

            var codelistTypes = new Dictionary<string, Type>();

            var roleTypes = new Dictionary<string, Type>();

            //  S100_FC_SimpleAttributes
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_SimpleAttribute", xmlNamespaceManager);

                //  Enumerations
                foreach (var e in elements) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    var getEnumType = (XElement simpleAttribute) => {
                        if (enumTypes.ContainsKey(code))
                            return enumTypes[code];

                        var enumBuilder = moduleBuilder.DefineEnum(code, TypeAttributes.Public, typeof(int));

                        var listedValues = new Dictionary<string, XElement>();

                        foreach (var listedValue in simpleAttribute.Element(XName.Get("listedValues", scope_S100))!.Elements()) {
                            var listedValueLabel = listedValue.Element(XName.Get("label", scope_S100))!.Value!;
                            var listedValueDefinition = listedValue.Element(XName.Get("definition", scope_S100))!.Value!;
                            var listedValueCode = listedValue.Element(XName.Get("code", scope_S100))!.Value!;

                            var literalName = RemoveSpecialChars(listedValueLabel);

                            listedValues.Add(literalName, listedValue);

                            enumBuilder.DefineLiteral(literalName, int.Parse(listedValueCode));
                        }
                        var enumType = enumBuilder.CreateType();
                        enumTypes.Add(code, enumType);
                        enumTypes.Add($"{code}?", GetNullableType(enumType));

                        //  Code generator
                        classBuilder.AppendLine("\t[System.Diagnostics.CodeAnalysis.SuppressMessage(\"Style\", \"IDE1006:Naming Styles\", Justification = \"<Pending>\")]");
                        classBuilder.AppendLine("\t[System.Serializable()]");
                        if (code.ToLowerInvariant().Equals(code))
                            classBuilder.AppendLine("#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.");
                        classBuilder.AppendLine($"\tpublic enum {code} : int");
                        if (code.ToLowerInvariant().Equals(code))
                            classBuilder.AppendLine("#pragma warning restore CS8981");
                        classBuilder.AppendLine("\t{");

                        bool isFirst = true;
                        foreach (var e in enumType.GetEnumValues()) {
                            if (!isFirst)
                                classBuilder.AppendLine();
                            var name = enumType.GetEnumName(e)!;
                            var listedValue = listedValues[name];
                            var listedValueLabel = listedValue.Element(XName.Get("label", scope_S100))!.Value!;
                            var listedValueDefinition = listedValue.Element(XName.Get("definition", scope_S100))!.Value!
                                                            .Replace("\"", "\\\"")
                                                            .Replace("\n\n", " ")
                                                            .Replace("\n", " ");

                            classBuilder.AppendLine($"\t\t[System.ComponentModel.Description(\"{listedValueDefinition}\")]");
                            classBuilder.AppendLine($"\t\t{e} = {(int)e},");
                            isFirst = false;
                        }

                        classBuilder.AppendLine("\t}");
                        classBuilder.AppendLine();

                        return enumType;
                    };

                    var valueType = e.Element(XName.Get("valueType", scope_S100))!.Value switch {
                        "enumeration" => getEnumType(e),
                        _ => default,
                    };
                }

                //  S100_CodeList
                foreach (var e in elements) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    var getCodeListType = (XElement simpleAttribute) => {
                        if (codelistTypes.ContainsKey(code))
                            return codelistTypes[code];

                        var codelistTypeBuilder = S100Framework.Roslyn.GetTypeBuilder(moduleBuilder, code);

                        var propertyBuilder = S100Framework.Roslyn.CreateProperty(codelistTypeBuilder, "label", typeof(string));
                        propertyBuilder = S100Framework.Roslyn.CreateProperty(codelistTypeBuilder, "definition", typeof(string));
                        propertyBuilder = S100Framework.Roslyn.CreateProperty(codelistTypeBuilder, "code", typeof(int));


                        var codelistType = codelistTypeBuilder.CreateType();

                        codelistTypes.Add(code, codelistType);
                        codelistTypes.Add($"{code}?", GetNullableType(codelistType));

                        classBuilder.AppendLine("\t[System.Serializable()]");
                        classBuilder.AppendLine($"\tpublic class {code}");
                        classBuilder.AppendLine("\t{");
                        classBuilder.AppendLine("\t\tpublic string label { get; set; }");
                        classBuilder.AppendLine();
                        classBuilder.AppendLine("\t\tpublic string definition { get; set; }");
                        classBuilder.AppendLine();
                        classBuilder.AppendLine("\t\tpublic int code { get; set; }");
                        classBuilder.AppendLine("\t}");
                        classBuilder.AppendLine();

                        return codelistType;
                    };

                    var valueType = e.Element(XName.Get("valueType", scope_S100))!.Value switch {
                        "S100_CodeList" => getCodeListType(e),
                        _ => default,
                    };
                }

                foreach (var e in elements) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    var getEnumListType = (XElement simpleAttribute) => {
                        var enumType = enumTypes[code];

                        var listType = typeof(List<>).MakeGenericType(enumType);
                        return listType;
                    };

                    var getCodeListType = (XElement simpleAttribute) => {
                        var codeType = codelistTypes[code];

                        var listType = typeof(List<>).MakeGenericType(codeType);
                        return listType;
                    };

                    var valueType = e.Element(XName.Get("valueType", scope_S100))!.Value switch {
                        "boolean" => typeof(bool),
                        "enumeration" => enumTypes[code],
                        "real" => typeof(decimal),
                        "text" => typeof(string),
                        "S100_TruncatedDate" => typeof(DateOnly),
                        "date" => typeof(DateTime),
                        "dateTime" => typeof(DateTime),
                        "time" => typeof(TimeOnly),
                        "integer" => typeof(int),
                        "URN" => typeof(string),
                        "S100_CodeList" => codelistTypes[code],
                        "URL" => typeof(string),
                        "URI" => typeof(string),
                        _ => throw new InvalidDataException(),
                    };
                    dictionaryTypes.Add(code, valueType);

                    var valueTypeGeneric = e.Element(XName.Get("valueType", scope_S100))!.Value switch {
                        "boolean" => typeof(bool?),
                        "enumeration" => enumTypes[$"{code}?"],
                        "real" => typeof(decimal?),
                        "text" => typeof(string),
                        "S100_TruncatedDate" => typeof(DateOnly?),
                        "date" => typeof(DateTime?),
                        "dateTime" => typeof(DateTime?),
                        "time" => typeof(TimeOnly?),
                        "integer" => typeof(int?),
                        "URN" => typeof(string),
                        "S100_CodeList" => codelistTypes[$"{code}?"],
                        "URL" => typeof(string),
                        "URI" => typeof(string),
                        _ => throw new InvalidDataException(),
                    };
                    if (valueTypeGeneric != null)
                        dictionaryTypes.Add($"{code}?", valueTypeGeneric);

                    var valueTypeList = e.Element(XName.Get("valueType", scope_S100))!.Value switch {
                        "boolean" => typeof(List<bool>),
                        "enumeration" => getEnumListType(e),
                        "real" => typeof(List<decimal>),
                        "text" => typeof(List<string>),
                        "S100_TruncatedDate" => typeof(List<DateOnly>),
                        "date" => typeof(List<DateTime>),
                        "dateTime" => typeof(List<DateTime>),
                        "time" => typeof(List<TimeOnly>),
                        "integer" => typeof(List<int>),
                        "URN" => typeof(List<string>),
                        "S100_CodeList" => getCodeListType(e),
                        "URL" => typeof(List<string>),
                        "URI" => typeof(List<string>),
                        _ => throw new InvalidDataException(),
                    };
                    dictionaryTypes.Add($"List<{code}>", valueTypeList);
                }
            }

            var staticBuilder = new StringBuilder();

            //  S100_CodeList
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_SimpleAttribute[S100FC:valueType='S100_CodeList']", xmlNamespaceManager);

                classBuilder.AppendLine("\tpublic static class CodeList");
                classBuilder.AppendLine("\t{");

                var first = true;
                foreach (var e in elements) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    if (!first)
                        classBuilder.AppendLine();
                    first = false;

                    var pluralize = pluralizer.Pluralize(code);
                    classBuilder.AppendLine($"\t\tpublic static ImmutableArray<{code}> {pluralize} => ImmutableArray.Create<{code}>(new {code}[]{{");

                    var values = e.Element(XName.Get("listedValues", scope_S100))!.Elements();
                    foreach (var v in values) {
                        var valueLabel = v.Element(XName.Get("label", scope_S100))!.Value;
                        var valueCode = v.Element(XName.Get("code", scope_S100))!.Value;
                        var valueDefinition = v.Element(XName.Get("definition", scope_S100))!.Value;

                        valueDefinition = Regex.Replace(valueDefinition, "\\n{2,}\\s*", "\n");

                        var lines = valueDefinition.Split("\n", StringSplitOptions.RemoveEmptyEntries);
                        valueDefinition = string.Join("\" + Environment.NewLine +" + Environment.NewLine + "\"", lines);

                        classBuilder.AppendLine($"\t\t\tnew() {{");
                        classBuilder.AppendLine($"\t\t\t\tcode = {valueCode},");
                        classBuilder.AppendLine($"\t\t\t\tdefinition = \"{valueDefinition}\",");
                        classBuilder.AppendLine($"\t\t\t\tlabel = \"{valueLabel}\",");
                        classBuilder.AppendLine("\t\t\t},");
                    }

                    classBuilder.AppendLine("\t\t});");

                }
                classBuilder.AppendLine("\t}");
                classBuilder.AppendLine();
            }

            //  S100_FC_ComplexAttribute
            classBuilder.AppendLine($"\tnamespace ComplexAttributes");
            classBuilder.AppendLine("\t{");
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_ComplexAttribute", xmlNamespaceManager);

                var complexTypes = new List<string>();

                var notFinished = false;
                do {
                    notFinished = false;

                    foreach (var e in elements) {
                        var name = e.Element(XName.Get("name", scope_S100))!.Value;
                        var code = e.Element(XName.Get("code", scope_S100))!.Value;

                        if (dictionaryTypes.ContainsKey(code))
                            continue;

                        if (e.XPathSelectElements("S100FC:subAttributeBinding", xmlNamespaceManager).Any(attribute => !dictionaryTypes.ContainsKey(attribute.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!))) {
                            notFinished = true;
                            continue;
                        }

                        complexTypes.Add(code);

                        var complexTypeBuilder = S100Framework.Roslyn.GetTypeBuilder(moduleBuilder, code);

                        var codeLists = new List<string>();

                        foreach (var attributeBinding in e.XPathSelectElements("S100FC:subAttributeBinding", xmlNamespaceManager)) {
                            var referenceCode = attributeBinding.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!;

                            var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                            var upper = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;

                            var isArray = false;
                            if (upper.Attribute(XName.Get("infinite")) != default && upper.Attribute(XName.Get("infinite"))!.Value.Equals("true") || int.Parse(upper!.Value) > 1) {
                                isArray = true;
                            }

                            var referenceType = isArray ? dictionaryTypes[$"List<{referenceCode}>"] : dictionaryTypes[referenceCode];

                            if (!isArray && lower == 0 /*&& !dictionaryTypesComplex.Contains(referenceCode)*/) {
                                referenceType = dictionaryTypes[$"{referenceCode}?"];
                            }

                            var propertyBuilder = S100Framework.Roslyn.CreateProperty(complexTypeBuilder, referenceCode, referenceType);

                            if (lower > 0) {
                                var constructorInfo = typeof(System.Runtime.CompilerServices.RequiredMemberAttribute).GetConstructors().First();

                                var requiredMemberAttributeBuilder = new CustomAttributeBuilder(constructorInfo, new object[0]);
                                propertyBuilder.SetCustomAttribute(requiredMemberAttributeBuilder);
                            }

                            if (!isArray && dictionaryTypesComplex.Contains(referenceCode)) {
                                var constructorInfo = typeof(Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObjectAttribute).GetConstructors().First();

                                var expandableObjectAttributeBuilder = new CustomAttributeBuilder(constructorInfo, new object[0]);
                                propertyBuilder.SetCustomAttribute(expandableObjectAttributeBuilder);
                            }

                            if (codelistTypes.ContainsKey(referenceCode)) {
                                //TODO: Add list property

                                //codeLists.Add($"public ImmutableArray<{referenceCode}> {referenceCode}List => CodeList.{pluralizer.Pluralize(referenceCode)};");
                            }
                        }

                        var complexType = complexTypeBuilder.CreateType();

                        classBuilder.AppendLine(BuildClass(code, complexType, xmlNamespace, (b) => {
                            foreach (var c in codeLists) {
                                b.AppendLine();
                                b.AppendLine("\t\t\t" + c);
                            }
                        }));

                        var attributes = TypeAttributes.Public | TypeAttributes.Class | /*TypeAttributes.AutoClass |*/ TypeAttributes.AutoLayout;
                        if (e.Attribute("isAbstract") != default && bool.Parse(e.Attribute("isAbstract")!.Value))
                            attributes |= TypeAttributes.Abstract;

                        if (!attributes.HasFlag(TypeAttributes.Abstract)) {
                            viewBuilder.AppendLine(BuildClassViewModel(code, complexType, $"DomainModel.{productId}.ComplexAttributes", codelistTypes.Keys, roleTypes.Keys));
                        }

                        dictionaryTypesComplex.Add(code);
                        dictionaryTypes.Add(code, complexType);

                        dictionaryTypes.Add($"{code}?", complexType);

                        var listType = typeof(List<>).MakeGenericType(complexType);
                        dictionaryTypes.Add($"List<{code}>", listType);
                    }
                } while (notFinished);

                staticBuilder.AppendLine();
                staticBuilder.AppendLine("\t\tpublic static string[] ComplexTypes => [");
                foreach (var code in complexTypes) {
                    staticBuilder.AppendLine($"\t\t\t\"{code}\",");
                }
                staticBuilder.AppendLine("\t\t];");
            }
            classBuilder.AppendLine("\t}");
            classBuilder.AppendLine();

            creatorBuilder.AppendLine("\tinternal static class Preamble {");
            creatorBuilder.AppendLine("\t\tpublic static ImmutableDictionary<string, Func<ViewModelBase>> _creators => ImmutableDictionary.Create<string, Func<ViewModelBase>>().AddRange(new Dictionary<string, Func<ViewModelBase>> {");

            //  Bindings
            {
                //  S100_FC_Roles
                {
                    var enumBuilder = moduleBuilder.DefineEnum("Role", TypeAttributes.Public, typeof(int));

                    var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_Role", xmlNamespaceManager);
                    var definitions = new Dictionary<string, string>();
                    int index = 1;
                    foreach (var e in elements) {
                        var name = e.Element(XName.Get("name", scope_S100))!.Value;
                        var definition = e.Element(XName.Get("definition", scope_S100))!.Value;
                        var code = e.Element(XName.Get("code", scope_S100))!.Value;


                        definition = definition.TrimEnd(new char[] { '\r', '\n', '\t', ' ' });


                        definitions.Add(code, definition);

                        enumBuilder.DefineLiteral(code, index++);
                    }

                    var enumType = enumBuilder.CreateType();

                    dictionaryTypes.Add("Role", enumType);

                    classBuilder.AppendLine($"\tpublic enum Role");
                    classBuilder.AppendLine("\t{");
                    bool isFirst = true;
                    foreach (var e in enumType.GetEnumValues()) {
                        if (!isFirst)
                            classBuilder.AppendLine();
                        var name = enumType.GetEnumName(e)!;

                        classBuilder.AppendLine($"\t\t[System.ComponentModel.Description(\"{definitions[name]}\")]");

                        classBuilder.AppendLine($"\t\t{e},");
                        isFirst = false;
                    }

                    classBuilder.AppendLine("\t\t}");
                    classBuilder.AppendLine();
                }

                classBuilder.AppendLine($"\tnamespace Associations");
                classBuilder.AppendLine("\t{");

                //  S100_FC_InformationAssociations
                {
                    classBuilder.AppendLine($"\tnamespace InformationAssociations");
                    classBuilder.AppendLine("\t\t{");

                    var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationAssociation", xmlNamespaceManager);

                    foreach (var e in elements) {
                        continue;
                        var name = e.Element(XName.Get("name", scope_S100))!.Value;
                        var definition = e.Element(XName.Get("definition", scope_S100))!.Value;
                        var code = e.Element(XName.Get("code", scope_S100))!.Value;

                        var attributes = TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoLayout;

                        var bindingTypeBuilder = moduleBuilder.DefineType($"{S100Framework.Roslyn.Namespace}.{code}", attributes);

                        foreach (var attributeBinding in e.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                            var referenceCode = attributeBinding.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!;

                            var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                            var upper = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;

                            var isArray = false;
                            if (upper.Attribute(XName.Get("infinite")) != default && upper.Attribute(XName.Get("infinite"))!.Value.Equals("true") || int.Parse(upper!.Value) > 1) {
                                isArray = true;
                            }

                            var referenceType = isArray ? dictionaryTypes[$"List<{referenceCode}>"] : dictionaryTypes[referenceCode];

                            if (!isArray && lower == 0 /*&& !dictionaryTypesComplex.Contains(referenceCode)*/) {
                                referenceType = dictionaryTypes[$"{referenceCode}?"];
                            }

                            var propertyBuilder = S100Framework.Roslyn.CreateProperty(bindingTypeBuilder, referenceCode, referenceType);

                            if (lower > 0) {
                                var constructorInfo = typeof(System.Runtime.CompilerServices.RequiredMemberAttribute).GetConstructors().First();

                                var requiredMemberAttributeBuilder = new CustomAttributeBuilder(constructorInfo, new object[0]);
                                propertyBuilder.SetCustomAttribute(requiredMemberAttributeBuilder);
                            }

                            if (!isArray && dictionaryTypesComplex.Contains(referenceCode)) {
                                var constructorInfo = typeof(Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObjectAttribute).GetConstructors().First();

                                var expandableObjectAttributeBuilder = new CustomAttributeBuilder(constructorInfo, new object[0]);
                                propertyBuilder.SetCustomAttribute(expandableObjectAttributeBuilder);
                            }
                        }

                        var bindingType = bindingTypeBuilder.CreateType();

                        var roles = string.Join(",", e.XPathSelectElements("S100FC:role", xmlNamespaceManager).Select(e => $"\"{e.Attribute("ref")!.Value}\""));
                        classBuilder.AppendLine($"\t\tpublic class {code} : InformationAssociation");
                        classBuilder.AppendLine($"\t\t{{");
                        classBuilder.AppendLine($"\t\t\tpublic override string Code => \"{code}\";");
                        classBuilder.AppendLine($"\t\t\tpublic override string[] Roles => [{roles}];");
                        classBuilder.AppendLine($"\t\t\tpublic {code}(){{");
                        var constructor = classBuilder.Length;
                        classBuilder.AppendLine($"\t\t\t}}");

                        var constructorBuilder = new StringBuilder();

                        foreach (var p in bindingType.GetProperties()) {
                            var attribute = p.GetCustomAttribute<System.Runtime.CompilerServices.RequiredMemberAttribute>();

                            if (attribute != null && !p.PropertyType.IsValueType) {
                                if (p.PropertyType == typeof(string))
                                    constructorBuilder.AppendLine($"\t\t\t\t{p.Name} = string.Empty;");
                                else {
                                    constructorBuilder.AppendLine($"\t\t\t\t{p.Name} = {BuildConstructor(p.PropertyType)}");
                                }
                            }

                            if (!p.PropertyType.IsGenericType && p.PropertyType != typeof(String)) {
                                if (attribute is not null)
                                    classBuilder.AppendLine("\t\t\t[Required()]");
                                //var prop_prefix = attribute != null ? "\t\t\tpublic required" : "\t\t\tpublic";
                                var prop_prefix = "\t\t\tpublic";   // attribute != null ? "\t\t\tpublic required" : "\t\t\tpublic";
                                var prop_type = attribute != null ? $"{p.PropertyType.Name}" : $"{p.PropertyType.Name}?";

                                if ("System.Collections.Generic".Equals(p.PropertyType.Namespace))
                                    prop_type = $"List<{p.Name}>";

                                classBuilder.AppendLine($"{prop_prefix} {prop_type} {p.Name} {{ get; set; }}");
                            }
                            else if (p.PropertyType == typeof(String)) {
                                var prop_type = p.PropertyType.Name;
                                if ("System.Collections.Generic".Equals(p.PropertyType.Namespace))
                                    prop_type = $"List<{p.Name}>";

                                classBuilder.AppendLine($"\t\t\tpublic {prop_type} {p.Name} {{ get; set; }} = string.Empty;");
                            }
                            else {
                                if (attribute is not null)
                                    classBuilder.AppendLine("\t\t\t[Required()]");
                                var prop_prefix = "\t\t\tpublic";   // attribute != null ? "\t\t\tpublic required" : "\t\t\tpublic";
                                var prop_type = GetPropertyType(p.PropertyType);

                                var prop_postfix = attribute != null ? "" : " = default;";

                                if ("System.Collections.Generic".Equals(p.PropertyType.Namespace)) {
                                    prop_type = $"List<{prop_type}>";
                                    prop_postfix = attribute != null ? "" : " = [];";
                                }
                                else if (attribute is null)
                                    prop_type += "?";

                                classBuilder.AppendLine($"{prop_prefix} {prop_type} {p.Name} {{ get; set; }}{prop_postfix}");
                            }
                        }

                        classBuilder.AppendLine($"\t\t}}");
                        classBuilder.AppendLine();

                        classBuilder.Insert(constructor, constructorBuilder.ToString());

                        dictionaryTypes.Add($"{code}", bindingType);
                    }

                    classBuilder.AppendLine("\t\t}");
                }

                //  S100_FC_FeatureAssociations
                {
                    classBuilder.AppendLine($"\tnamespace FeatureAssociations");
                    classBuilder.AppendLine("\t\t{");
                    classBuilder.AppendLine($"\t\tusing S100Framework.DomainModel.{productId}.FeatureTypes;");

                    var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureAssociation", xmlNamespaceManager);

                    foreach (var e in elements) {
                        continue;
                        var name = e.Element(XName.Get("name", scope_S100))!.Value;
                        var definition = e.Element(XName.Get("definition", scope_S100))!.Value;
                        var code = e.Element(XName.Get("code", scope_S100))!.Value;

                        var attributes = TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoLayout;

                        var bindingTypeBuilder = moduleBuilder.DefineType($"{S100Framework.Roslyn.Namespace}.{code}", attributes);

                        foreach (var attributeBinding in e.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                            var referenceCode = attributeBinding.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!;

                            var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                            var upper = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;

                            var isArray = false;
                            if (upper.Attribute(XName.Get("infinite")) != default && upper.Attribute(XName.Get("infinite"))!.Value.Equals("true") || int.Parse(upper!.Value) > 1) {
                                isArray = true;
                            }

                            var referenceType = isArray ? dictionaryTypes[$"List<{referenceCode}>"] : dictionaryTypes[referenceCode];

                            if (!isArray && lower == 0 /*&& !dictionaryTypesComplex.Contains(referenceCode)*/) {
                                referenceType = dictionaryTypes[$"{referenceCode}?"];
                            }

                            var propertyBuilder = S100Framework.Roslyn.CreateProperty(bindingTypeBuilder, referenceCode, referenceType);

                            if (lower > 0) {
                                var constructorInfo = typeof(System.Runtime.CompilerServices.RequiredMemberAttribute).GetConstructors().First();

                                var requiredMemberAttributeBuilder = new CustomAttributeBuilder(constructorInfo, new object[0]);
                                propertyBuilder.SetCustomAttribute(requiredMemberAttributeBuilder);
                            }

                            if (!isArray && dictionaryTypesComplex.Contains(referenceCode)) {
                                var constructorInfo = typeof(Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObjectAttribute).GetConstructors().First();

                                var expandableObjectAttributeBuilder = new CustomAttributeBuilder(constructorInfo, new object[0]);
                                propertyBuilder.SetCustomAttribute(expandableObjectAttributeBuilder);
                            }
                        }

                        var bindingType = bindingTypeBuilder.CreateType();

                        var roles = string.Join(",", e.XPathSelectElements("S100FC:role", xmlNamespaceManager).Select(e => $"\"{e.Attribute("ref")!.Value}\""));
                        classBuilder.AppendLine($"\t\tpublic class {code} : FeatureAssociation"); ;// where T : FeatureType");
                        classBuilder.AppendLine($"\t\t{{");

                        classBuilder.AppendLine($"\t\t\tpublic override string Code => \"{code}\";");
                        classBuilder.AppendLine($"\t\t\tpublic override string[] Roles => [{roles}];");
                        classBuilder.AppendLine($"\t\t\tpublic {code}(){{");
                        var constructor = classBuilder.Length;
                        classBuilder.AppendLine($"\t\t\t}}");

                        classBuilder.AppendLine($"");
                        foreach (var role in e.XPathSelectElements("S100FC:role", xmlNamespaceManager).Select(e => $"{e.Attribute("ref")!.Value}")) {
                            var p = pluralizer.Pluralize(role);

                            var association = productSpecification.XPathSelectElements("//S100FC:featureBinding", xmlNamespaceManager).Where(e => e.Element(XName.Get("association", scope_S100))!.Attribute("ref")!.Value.Equals(code));

                            var theCollection = association.Where(e => e.Element(XName.Get("role", scope_S100))!.Attribute("ref")!.Value.Equals(role));

                            var refTypes = theCollection.Elements(XName.Get("featureType", scope_S100)).Select(e => $"typeof({e.Attribute("ref")!.Value})").Distinct();

                            classBuilder.AppendLine($"\t\t\tpublic Type[] {p} => [{string.Join(',', refTypes)}];");
                        }

                        classBuilder.AppendLine($"");
                        classBuilder.AppendLine($"");

                        var constructorBuilder = new StringBuilder();

                        foreach (var p in bindingType.GetProperties()) {
                            var attribute = p.GetCustomAttribute<System.Runtime.CompilerServices.RequiredMemberAttribute>();

                            if (attribute != null && !p.PropertyType.IsValueType) {
                                if (p.PropertyType == typeof(string))
                                    constructorBuilder.AppendLine($"\t\t\t\t{p.Name} = string.Empty;");
                                else {
                                    constructorBuilder.AppendLine($"\t\t\t\t{p.Name} = {BuildConstructor(p.PropertyType)}");
                                }
                            }

                            if (!p.PropertyType.IsGenericType && p.PropertyType != typeof(String)) {
                                if (attribute is not null)
                                    classBuilder.AppendLine("\t\t\t[Required()]");
                                var prop_prefix = "\t\t\tpublic";   // attribute != null ? "\t\t\tpublic required" : "\t\t\tpublic";
                                var prop_type = attribute != null ? $"{p.PropertyType.Name}" : $"{p.PropertyType.Name}?";

                                if ("System.Collections.Generic".Equals(p.PropertyType.Namespace))
                                    prop_type = $"List<{p.Name}>";

                                classBuilder.AppendLine($"{prop_prefix} {prop_type} {p.Name} {{ get; set; }}");
                            }
                            else if (p.PropertyType == typeof(String)) {
                                var prop_type = p.PropertyType.Name;
                                if ("System.Collections.Generic".Equals(p.PropertyType.Namespace))
                                    prop_type = $"List<{p.Name}>";

                                classBuilder.AppendLine($"\t\t\tpublic {prop_type} {p.Name} {{ get; set; }} = string.Empty;");
                            }
                            else {
                                if (attribute is not null)
                                    classBuilder.AppendLine("\t\t\t[Required()]");
                                var prop_prefix = "\t\t\tpublic";   // attribute != null ? "\t\t\tpublic required" : "\t\t\tpublic";
                                var prop_type = GetPropertyType(p.PropertyType);

                                var prop_postfix = attribute != null ? "" : " = default;";

                                if ("System.Collections.Generic".Equals(p.PropertyType.Namespace)) {
                                    prop_type = $"List<{prop_type}>";
                                    prop_postfix = attribute != null ? "" : " = [];";
                                }
                                else if (attribute is null)
                                    prop_type += "?";

                                classBuilder.AppendLine($"{prop_prefix} {prop_type} {p.Name} {{ get; set; }}{prop_postfix}");
                            }
                        }

                        classBuilder.AppendLine($"\t\t}}");
                        classBuilder.AppendLine();

                        classBuilder.Insert(constructor, constructorBuilder.ToString());

                        dictionaryTypes.Add($"{code}", bindingType);
                    }

                    classBuilder.AppendLine("\t\t}");
                }

                classBuilder.AppendLine("\t}");
                classBuilder.AppendLine();

                classBuilder.AppendLine($"\tnamespace Bindings");
                classBuilder.AppendLine("\t{");

                classBuilder.AppendLine("\t}");
            }

            var handlesBuilder = new StringBuilder();
            handlesBuilder.AppendLine("\tpublic class Handles : iHandles {");
            handlesBuilder.AppendLine("\t\tpublic static IDictionary<Type, Func<InformationAssociationConnector[]>> AssociationConnectorInformations => new Dictionary<Type, Func<InformationAssociationConnector[]>> {");
            var handlesAssociationConnectorInformations = handlesBuilder.Length;
            handlesBuilder.AppendLine("\t\t};");
            handlesBuilder.AppendLine("\t\tpublic static IDictionary<Type, Func<FeatureAssociationConnector[]>> AssociationConnectorFeatures => new Dictionary<Type, Func<FeatureAssociationConnector[]>> {");
            var handlesAssociationConnectorFeatures = handlesBuilder.Length;
            handlesBuilder.AppendLine("\t\t};");


            handlesBuilder.AppendLine("\t}");

            var informationBindingTypes = new List<string>();
            var featureBindingTypes = new List<string>();

            //  S100_FC_InformationType
            classBuilder.AppendLine($"\tnamespace InformationTypes");
            classBuilder.AppendLine("\t{");
            classBuilder.AppendLine("\t\tusing ComplexAttributes;");
            classBuilder.AppendLine("\t\tusing DomainModel;");
            classBuilder.AppendLine();
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationType", xmlNamespaceManager);

                Type informationTypeBase;
                {
                    var attributes = TypeAttributes.Public | TypeAttributes.Class | /*TypeAttributes.AutoClass |*/ TypeAttributes.AutoLayout | TypeAttributes.Abstract;
                    var informationTypeBuilder = moduleBuilder.DefineType($"S100Framework.DomainModel.InformationNode", attributes);

                    informationTypeBase = informationTypeBuilder.CreateType();
                }

                var informationTypes = new List<string>();

                var superClassHierarchy = new Dictionary<string, string>();
                var superClassViewModels = new Dictionary<string, string>();

                var notFinished = false;
                do {
                    notFinished = false;

                    foreach (var e in elements) {
                        var name = e.Element(XName.Get("name", scope_S100))!.Value;
                        var code = e.Element(XName.Get("code", scope_S100))!.Value;

                        if (dictionaryTypes.ContainsKey(code))
                            continue;

                        if (e.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager).Any(attribute => !dictionaryTypes.ContainsKey(attribute.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!))) {
                            notFinished = true;
                            continue;
                        }

                        informationTypes.Add(code);

                        var attributes = TypeAttributes.Public | TypeAttributes.Class | /*TypeAttributes.AutoClass |*/ TypeAttributes.AutoLayout;
                        if (e.Attribute("isAbstract") != default && bool.Parse(e.Attribute("isAbstract")!.Value))
                            attributes |= TypeAttributes.Abstract;

                        var superType = e.Elements(XName.Get("superType", scope_S100)).FirstOrDefault();

                        TypeBuilder informationTypeBuilder;

                        if (superType != null) {
                            if (!dictionaryTypes.ContainsKey(superType.Value)) {
                                notFinished = true;
                                continue;
                            }
                            informationTypeBuilder = moduleBuilder.DefineType($"{S100Framework.Roslyn.Namespace}.{code}", attributes, dictionaryTypes[superType.Value]);

                            superClassHierarchy.Add(code, superType.Value);
                        }
                        else
                            informationTypeBuilder = moduleBuilder.DefineType($"{S100Framework.Roslyn.Namespace}.{code}", attributes, informationTypeBase);

                        //  attributeBinding
                        foreach (var attributeBinding in e.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                            var referenceCode = attributeBinding.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!;

                            var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                            var upper = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;

                            var isArray = false;
                            if (upper.Attribute(XName.Get("infinite")) != default && upper.Attribute(XName.Get("infinite"))!.Value.Equals("true") || int.Parse(upper!.Value) > 1) {
                                isArray = true;
                            }

                            var referenceType = isArray ? dictionaryTypes[$"List<{referenceCode}>"] : dictionaryTypes[referenceCode];

                            if (!isArray && lower == 0 /*&& !dictionaryTypesComplex.Contains(referenceCode)*/) {
                                referenceType = dictionaryTypes[$"{referenceCode}?"];
                            }

                            var propertyBuilder = S100Framework.Roslyn.CreateProperty(informationTypeBuilder, referenceCode, referenceType);

                            if (lower > 0) {
                                var constructorInfo = typeof(System.Runtime.CompilerServices.RequiredMemberAttribute).GetConstructors().First();

                                var requiredMemberAttributeBuilder = new CustomAttributeBuilder(constructorInfo, new object[0]);
                                propertyBuilder.SetCustomAttribute(requiredMemberAttributeBuilder);
                            }

                            if (!isArray && dictionaryTypesComplex.Contains(referenceCode)) {
                                var constructorInfo = typeof(Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObjectAttribute).GetConstructors().First();

                                var expandableObjectAttributeBuilder = new CustomAttributeBuilder(constructorInfo, new object[0]);
                                propertyBuilder.SetCustomAttribute(expandableObjectAttributeBuilder);
                            }
                        }

                        var informationType = informationTypeBuilder.CreateType();

                        var informationBindingIndex = classBuilder.Length;

                        var viewModelBindingBuilder = new StringBuilder();

                        var informationBindingsList = new List<string>();

                        classBuilder.AppendLine(BuildClass(code, informationType, xmlNamespace, "S100Framework.DomainModel.InformationType", (builder) => {
                            builder.AppendLine($"\t\t\tpublic override string Code => nameof({code});");
                        }));

                        if (!attributes.HasFlag(TypeAttributes.Abstract)) {
                            viewBuilder.AppendLine(BuildClassViewModel(code, informationType, $"DomainModel.{productId}.InformationTypes", codelistTypes.Keys, roleTypes.Keys, (builder) => {
                                var c = code;
                                while (!string.IsNullOrEmpty(c) && superClassHierarchy.ContainsKey(c)) {
                                    c = superClassHierarchy[c];
                                    if (superClassViewModels.ContainsKey(c)) {
                                        builder.AppendLine(superClassViewModels[c]);
                                    }
                                }

                                builder.AppendLine(viewModelBindingBuilder.ToString());

                                builder.AppendLine($"\t\t\tpublic class {code}RefIdViewModel : InformationRefIdViewModel {{");
                                builder.AppendLine($"\t\t\t\tpublic override string[] AssociationTypes => [\"{code}\"];");
                                //builder.AppendLine("\t\t\t\tpublic override string ToString() => \"RefId\";");
                                builder.AppendLine($"\t\t\t}}");
                            }));

                            creatorBuilder.AppendLine($"\t\t\t{{ typeof(DomainModel.{productId}.InformationTypes.{code}).Name, ()=> {{");
                            creatorBuilder.AppendLine($"\t\t\t\treturn new {code}ViewModel();");
                            creatorBuilder.AppendLine("\t\t\t  }");
                            creatorBuilder.AppendLine("\t\t\t},");
                        }
                        else
                            superClassViewModels.Add(code, viewModelBindingBuilder.ToString());

                        dictionaryTypes.Add(code, informationType);

                        var listType = typeof(List<>).MakeGenericType(informationType);
                        dictionaryTypes.Add($"List<{code}>", listType);
                    }
                } while (notFinished);

                staticBuilder.AppendLine();
                staticBuilder.AppendLine("\t\tpublic static string[] InformationTypes => [");
                foreach (var code in informationTypes) {
                    staticBuilder.AppendLine($"\t\t\t\"{code}\",");
                }
                staticBuilder.AppendLine("\t\t];");
            }
            classBuilder.AppendLine("\t}");
            classBuilder.AppendLine();

            //  S100_FC_FeatureType
            classBuilder.AppendLine($"\tnamespace FeatureTypes");
            classBuilder.AppendLine("\t{");
            classBuilder.AppendLine("\t\tusing ComplexAttributes;");
            classBuilder.AppendLine("\t\tusing InformationTypes;");
            classBuilder.AppendLine("\t\tusing DomainModel;");
            classBuilder.AppendLine();
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureType", xmlNamespaceManager);

                Type featureTypeBase;
                {
                    var attributes = TypeAttributes.Public | TypeAttributes.Class | /*TypeAttributes.AutoClass |*/ TypeAttributes.AutoLayout | TypeAttributes.Abstract;
                    var featureTypeBuilder = moduleBuilder.DefineType($"S100Framework.DomainModel.FeatureNode", attributes);

                    featureTypeBase = featureTypeBuilder.CreateType();
                }

                var featureTypes = new List<string>();

                var superClassHierarchy = new Dictionary<string, string>();
                var superClassViewModels = new Dictionary<string, string>();

                var notFinished = false;
                do {
                    notFinished = false;

                    foreach (var e in elements) {
                        var name = e.Element(XName.Get("name", scope_S100))!.Value;
                        var code = e.Element(XName.Get("code", scope_S100))!.Value;

                        if (dictionaryTypes.ContainsKey(code))
                            continue;

                        if (e.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager).Any(b => !dictionaryTypes.ContainsKey(b.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!))) {
                            notFinished = true;
                            continue;
                        }

                        featureTypes.Add(code);

                        var attributes = TypeAttributes.Public | TypeAttributes.Class | /*TypeAttributes.AutoClass |*/ TypeAttributes.AutoLayout;
                        if (e.Attribute("isAbstract") != default && bool.Parse(e.Attribute("isAbstract")!.Value))
                            attributes |= TypeAttributes.Abstract;

                        var superType = e.Elements(XName.Get("superType", scope_S100)).FirstOrDefault();

                        TypeBuilder featureTypeBuilder;

                        if (superType != null) {
                            if (!dictionaryTypes.ContainsKey(superType.Value)) {
                                notFinished = true;
                                continue;
                            }
                            featureTypeBuilder = moduleBuilder.DefineType($"{S100Framework.Roslyn.Namespace}.{code}", attributes, dictionaryTypes[superType.Value]);

                            superClassHierarchy.Add(code, superType.Value);
                        }
                        else
                            featureTypeBuilder = moduleBuilder.DefineType($"{S100Framework.Roslyn.Namespace}.{code}", attributes, featureTypeBase);

                        //  attributeBinding
                        foreach (var attributeBinding in e.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                            var referenceCode = attributeBinding.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!;

                            var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                            var upper = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;

                            var isArray = false;
                            if (upper.Attribute(XName.Get("infinite")) != default && upper.Attribute(XName.Get("infinite"))!.Value.Equals("true") || int.Parse(upper!.Value) > 1) {
                                isArray = true;
                            }

                            var referenceType = isArray ? dictionaryTypes[$"List<{referenceCode}>"] : dictionaryTypes[referenceCode];

                            if (!isArray && lower == 0 /*&& !dictionaryTypesComplex.Contains(referenceCode)*/) {
                                referenceType = dictionaryTypes[$"{referenceCode}?"];
                            }

                            var propertyBuilder = S100Framework.Roslyn.CreateProperty(featureTypeBuilder, referenceCode, referenceType);

                            if (lower > 0) {
                                var constructorInfo = typeof(System.Runtime.CompilerServices.RequiredMemberAttribute).GetConstructors().First();

                                var requiredMemberAttributeBuilder = new CustomAttributeBuilder(constructorInfo, new object[0]);
                                propertyBuilder.SetCustomAttribute(requiredMemberAttributeBuilder);
                            }

                            if (!isArray && dictionaryTypesComplex.Contains(referenceCode)) {
                                var constructorInfo = typeof(Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObjectAttribute).GetConstructors().First();

                                var expandableObjectAttributeBuilder = new CustomAttributeBuilder(constructorInfo, new object[0]);
                                propertyBuilder.SetCustomAttribute(expandableObjectAttributeBuilder);
                            }
                        }

                        var featureType = featureTypeBuilder.CreateType();

                        var bindingIndex = classBuilder.Length;

                        var viewModelBindingBuilder = new StringBuilder();

                        var informationBindingsList = new List<string>();
                        var featureBindingsList = new List<string>();

                        classBuilder.AppendLine(BuildClass(code, featureType, xmlNamespace, "S100Framework.DomainModel.FeatureType", (builder) => {
                            builder.AppendLine($"\t\t\tpublic override string Code => nameof({code});");
                        }));

                        if (!attributes.HasFlag(TypeAttributes.Abstract)) {
                            viewBuilder.AppendLine(BuildClassViewModel(code, featureType, $"DomainModel.{productId}.FeatureTypes", codelistTypes.Keys, roleTypes.Keys, (builder) => {
                                var c = code;
                                while (!string.IsNullOrEmpty(c) && superClassHierarchy.ContainsKey(c)) {
                                    c = superClassHierarchy[c];
                                    if (superClassViewModels.ContainsKey(c)) {
                                        builder.AppendLine(superClassViewModels[c]);
                                    }
                                }

                                builder.AppendLine(viewModelBindingBuilder.ToString());

                                builder.AppendLine($"\t\t\tpublic class {code}RefIdViewModel : FeatureRefIdViewModel {{");
                                builder.AppendLine($"\t\t\t\tpublic override string[] AssociationTypes => [\"{code}\"];");
                                //builder.AppendLine("\t\t\t\tpublic override string ToString() => \"RefId\";");
                                builder.AppendLine($"\t\t\t}}");
                            }));

                            creatorBuilder.AppendLine($"\t\t\t{{ typeof(DomainModel.{productId}.FeatureTypes.{code}).Name, ()=> {{");
                            creatorBuilder.AppendLine($"\t\t\t\treturn new {code}ViewModel();");
                            creatorBuilder.AppendLine("\t\t\t  }");
                            creatorBuilder.AppendLine("\t\t\t},");
                        }
                        else
                            superClassViewModels.Add(code, viewModelBindingBuilder.ToString());

                        dictionaryTypes.Add(code, featureType);
                    }
                } while (notFinished);

                staticBuilder.AppendLine();
                staticBuilder.AppendLine("\t\tpublic static string[] FeatureTypes => [");
                foreach (var code in featureTypes) {
                    staticBuilder.AppendLine($"\t\t\t\"{code}\",");
                }
                staticBuilder.AppendLine("\t\t];");
            }
            classBuilder.AppendLine("\t}");

            classBuilder.AppendLine("}");

            creatorBuilder.AppendLine("\t\t});");
            creatorBuilder.AppendLine("\t}");

            classBuilder.Insert(informationPosition, staticBuilder.ToString());

            //  Associations
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureAssociation", xmlNamespaceManager);

                var featureTypes = productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureType", xmlNamespaceManager);

                var featureHierarchy = new List<featureType>();

                foreach (var f in featureTypes) {
                    var name = f.Element(XName.Get("name", scope_S100))!.Value;
                    var code = f.Element(XName.Get("code", scope_S100))!.Value;

                    var superType = f.Elements(XName.Get("superType", scope_S100)).FirstOrDefault()?.Value;

                    var isAbstract = f.Attribute("isAbstract") != default && bool.Parse(f.Attribute("isAbstract")!.Value);

                    featureHierarchy.Add(new featureType(code, superType, isAbstract));
                }

                foreach (var e in elements) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var definition = e.Element(XName.Get("definition", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    var roles = e.XPathSelectElements("S100FC:role", xmlNamespaceManager).Select(e => e.Attribute("ref")!.Value);

                    var bindings = productSpecification.XPathSelectElements("//S100FC:featureBinding", xmlNamespaceManager);

                    var associations = bindings.Where(e => e.Element(XName.Get("association", scope_S100))!.Attribute("ref")!.Value.Equals(code));

                    viewBuilder.AppendLine($"\t\tpublic class {code}ViewModel : FeatureAssociationViewModel {{");

                    viewBuilder.AppendLine($"\t\t\tpublic override string Code => \"{code}\";");
                    viewBuilder.AppendLine($"\t\t\tpublic override string[] Roles => [{string.Join(',', roles.Select(e => $"\"{e}\""))}];");
                    viewBuilder.AppendLine();

                    foreach (var r in roles) {
                        if (!associations.Any(e => r.Equals(e.Element(XName.Get("role", scope_S100))!.Attribute("ref")!.Value)))
                            continue;

                        viewBuilder.AppendLine($"\t\t\tprivate FeatureBindingViewModel? _{r};");
                        viewBuilder.AppendLine($"\t\t\t[ExpandableObject]");
                        viewBuilder.AppendLine($"\t\t\tpublic FeatureBindingViewModel? {r} {{");
                        viewBuilder.AppendLine($"\t\t\t\tget {{ return _{r}; }}");
                        viewBuilder.AppendLine($"\t\t\t\tset {{ this.SetValue(ref _{r}, value); }}");
                        viewBuilder.AppendLine($"\t\t\t}}");
                    }

                    viewBuilder.AppendLine();
                    viewBuilder.AppendLine($"\t\t\tpublic override FeatureAssociationConnector? associationConnector {{");
                    viewBuilder.AppendLine($"\t\t\t\tget {{ return _associationConnector; }}");
                    viewBuilder.AppendLine($"\t\t\t\tset {{");
                    viewBuilder.AppendLine($"\t\t\t\t\tthis.SetValue(ref _associationConnector, value);");
                    foreach (var r in roles) {
                        if (!associations.Any(e => r.Equals(e.Element(XName.Get("role", scope_S100))!.Attribute("ref")!.Value)))
                            continue;

                        viewBuilder.AppendLine($"\t\t\t\t{r} = null;");

                        viewBuilder.AppendLine($"\t\t\t\tif (value is not null) {{");
                        viewBuilder.AppendLine($"\t\t\t\t\t{r} = value?.role switch {{");

                        foreach (var s in roles.Where(e => !e.Equals(r))) {
                            viewBuilder.AppendLine($"\t\t\t\t\t\t\"{s}\" => value.CreateForeignFeatureBinding(),");
                        }

                        viewBuilder.AppendLine($"\t\t\t\t\t\t_ => value.CreateLocalFeatureBinding(),");

                        //viewBuilder.AppendLine($"\t\t\t\t\t\t_ => new SingleFeatureBindingViewModel {{");
                        //viewBuilder.AppendLine($"\t\t\t\t\t\t\tFeatureTypes = [value!.FeatureType],");
                        //viewBuilder.AppendLine($"\t\t\t\t\t\t}},");

                        viewBuilder.AppendLine($"\t\t\t\t\t}};");
                        viewBuilder.AppendLine($"\t\t\t\t}}");
                    }
                    viewBuilder.AppendLine($"\t\t\t}}");
                    viewBuilder.AppendLine($"\t\t}}");

                    viewBuilder.AppendLine($"\t\t\tpublic override FeatureAssociationConnector[] associationConnectorFeatures => {code}ViewModel._associationConnectorFeatures;");
                    //viewBuilder.AppendLine($"\t\t\tpublic static FeatureAssociationConnector[] _associationConnectorFeatures => new FeatureAssociationConnector[] {{");

                    var b = new StringBuilder();
                    var lookup = new List<string>();
                    foreach (var association in associations.OrderBy(e => e.Element(XName.Get("role", scope_S100))!.Attribute("ref")!.Value).ThenBy(e => e.Parent!.Element(XName.Get("code", scope_S100))!.Value)) {
                        var featureType = association.Parent!.Element(XName.Get("code", scope_S100))!.Value;

                        var roleType = association.Attribute("roleType")!.Value;
                        var role = association.Element(XName.Get("role", scope_S100))!.Attribute("ref")!.Value;
                        var lower = int.Parse(association.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                        var upper = association.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                        int? u = default;    // "default";
                        if (!(upper.Attribute(XName.Get("infinite")) != default && upper.Attribute(XName.Get("infinite"))!.Value.Equals("true"))) {
                            u = int.Parse(upper!.Value);    // $"{int.Parse(upper!.Value)}";
                        }

                        var featureTypeRefs = association.Elements(XName.Get("featureType", scope_S100)).Select(e => $"{e.Attribute("ref")!.Value}").ToArray();

                        var featureTypeRefsHierarchy = new List<string>();
                        foreach (var f in featureTypeRefs) {
                            foreach (var h in featureHierarchy.Hierarchy(f)) {
                                featureTypeRefsHierarchy.Add(h);
                            }
                        }

                        featureTypeRefs = featureTypeRefsHierarchy.Select(e => $"\"{e}\"").ToArray();

                        foreach (var f in featureHierarchy.Hierarchy(featureType)) {
                            var refName = $"{role}{f}RefIdViewModel";
                            if (lookup.Contains(refName))
                                continue;
                            lookup.Add(refName);
                            b.AppendLine($"new FeatureAssociationConnector<{f}>() {{");
                            b.AppendLine($"\troleType = roleType.{roleType},");
                            b.AppendLine($"\trole = \"{role}\",");
                            b.AppendLine($"\tLower = {lower},");
                            if (u.HasValue)
                                b.AppendLine($"\tUpper = {u.Value},");
                            else
                                b.AppendLine($"\tUpper = default,");
                            b.AppendLine($"\tAssociationTypes = [{string.Join(',', featureTypeRefs)}],");

                            if (!u.HasValue || u.Value > 1)
                                b.AppendLine($"\tCreateForeignFeatureBinding = () => new MultiFeatureBindingViewModel<{code}ViewModel.{role}{f}RefIdViewModel>(\"{code.Replace("ViewModel", string.Empty)}\"),");
                            else if (lower > 0)
                                b.AppendLine($"\tCreateForeignFeatureBinding = () => new SingleFeatureBindingViewModel<{code}ViewModel.{role}{f}RefIdViewModel>(\"{code.Replace("ViewModel", string.Empty)}\"),");
                            else
                                b.AppendLine($"\tCreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<{code}ViewModel.{role}{f}RefIdViewModel>(\"{code.Replace("ViewModel", string.Empty)}\"),");

                            b.AppendLine($"\tCreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<{f}ViewModel.{f}RefIdViewModel>(\"{f}\"),");
                            b.AppendLine($"}},");

                            viewBuilder.AppendLine($"\t\t\tpublic class {role}{f}RefIdViewModel : FeatureRefIdViewModel {{");
                            viewBuilder.AppendLine($"\t\t\t\tpublic override string[] AssociationTypes => [{string.Join(',', featureTypeRefs)}];");
                            //viewBuilder.AppendLine("\t\t\t\tpublic override string ToString() => \"RefId\";");
                            viewBuilder.AppendLine($"\t\t\t}}");
                        }
                    }

                    viewBuilder.AppendLine($"\t\t\tpublic static FeatureAssociationConnector[] _associationConnectorFeatures => Handles.AssociationConnectorFeatures[typeof({code}ViewModel)]();");

                    if (b.Length > 0) {
                        handlesBuilder.Insert(handlesAssociationConnectorFeatures, $"\t\t\t{{ typeof({code}ViewModel), () => [{b.ToString().ReplaceLineEndings().TrimEnd().TrimEnd(',').ReplaceLineEndings()}] }},");
                    }

                    //viewBuilder.AppendLine($"\t\t\t}};");
                    viewBuilder.AppendLine("\t\t}");
                }

                elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationAssociation", xmlNamespaceManager);

                var informationTypes = productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationType", xmlNamespaceManager);

                var informationHierarchy = new List<informationType>();

                foreach (var f in informationTypes) {
                    var name = f.Element(XName.Get("name", scope_S100))!.Value;
                    var code = f.Element(XName.Get("code", scope_S100))!.Value;

                    var superType = f.Elements(XName.Get("superType", scope_S100)).FirstOrDefault()?.Value;

                    var isAbstract = f.Attribute("isAbstract") != default && bool.Parse(f.Attribute("isAbstract")!.Value);

                    informationHierarchy.Add(new informationType(code, superType, isAbstract));
                }

                foreach (var e in elements) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var definition = e.Element(XName.Get("definition", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    var roles = e.XPathSelectElements("S100FC:role", xmlNamespaceManager).Select(e => e.Attribute("ref")!.Value);

                    var bindings = productSpecification.XPathSelectElements("//S100FC:informationBinding", xmlNamespaceManager).ToList();

                    var associations = bindings.Where(e => e.Element(XName.Get("association", scope_S100))!.Attribute("ref")!.Value.Equals(code)).ToList();

                    viewBuilder.AppendLine($"\t\tpublic class {code}ViewModel : InformationAssociationViewModel {{");
                    viewBuilder.AppendLine($"\t\t\tpublic override string Code => \"{code}\";");
                    viewBuilder.AppendLine($"\t\t\tpublic override string[] Roles => [{string.Join(',', roles.Select(e => $"\"{e}\""))}];");
                    viewBuilder.AppendLine();

                    foreach (var r in roles) {
                        viewBuilder.AppendLine($"\t\t\tprivate InformationBindingViewModel? _{r};");
                        viewBuilder.AppendLine($"\t\t\t[ExpandableObject]");
                        viewBuilder.AppendLine($"\t\t\tpublic InformationBindingViewModel? {r} {{");
                        viewBuilder.AppendLine($"\t\t\t\tget {{ return _{r}; }}");
                        viewBuilder.AppendLine($"\t\t\t\tset {{ this.SetValue(ref _{r}, value); }}");
                        viewBuilder.AppendLine($"\t\t\t}}");
                    }
                    viewBuilder.AppendLine();
                    viewBuilder.AppendLine($"\t\t\tpublic override InformationAssociationConnector? associationConnector {{");
                    viewBuilder.AppendLine($"\t\t\t\tget {{ return _associationConnector; }}");
                    viewBuilder.AppendLine($"\t\t\t\tset {{");
                    viewBuilder.AppendLine($"\t\t\t\t\tthis.SetValue(ref _associationConnector, value);");

                    if (roles.Count() == 1) {
                        var r = roles.First();
                        viewBuilder.AppendLine($"\t\t\t\t{r} = null;");

                        viewBuilder.AppendLine($"\t\t\t\tif (value is not null) {{");
                        viewBuilder.AppendLine($"\t\t\t\t\t\t{r} = value.CreateLocalInformationBinding();");
                        viewBuilder.AppendLine($"\t\t\t\t\t}}");
                    }
                    else {

                        foreach (var r in roles) {
                            //if (!associations.Any(e => r.Equals(e.Element(XName.Get("role", scope_S100))!.Attribute("ref")!.Value)))
                            //    continue;

                            viewBuilder.AppendLine($"\t\t\t\t{r} = null;");

                            viewBuilder.AppendLine($"\t\t\t\tif (value is not null) {{");
                            viewBuilder.AppendLine($"\t\t\t\t\t{r} = value?.role switch {{");

                            foreach (var s in roles.Where(e => !e.Equals(r))) {
                                viewBuilder.AppendLine($"\t\t\t\t\t\t\"{s}\" => value.CreateForeignInformationBinding(),");
                            }

                            viewBuilder.AppendLine($"\t\t\t\t\t\t_ => value.CreateLocalInformationBinding(),");

                            //viewBuilder.AppendLine($"\t\t\t\t\t\t_ => new SingleInformationBindingViewModel() {{");
                            //viewBuilder.AppendLine($"\t\t\t\t\t\t\tInformationTypes = [value!.InformationType],");
                            //viewBuilder.AppendLine($"\t\t\t\t\t\t}},");

                            viewBuilder.AppendLine($"\t\t\t\t\t}};");
                            viewBuilder.AppendLine($"\t\t\t\t}}");
                        }
                    }
                    viewBuilder.AppendLine($"\t\t\t}}");
                    viewBuilder.AppendLine($"\t\t}}");

                    viewBuilder.AppendLine($"\t\t\tpublic override InformationAssociationConnector[] associationConnectorInformations => {code}ViewModel._associationConnectorInformations;");

                    var b = new StringBuilder();

                    var lookup = new List<string>();
                    foreach (var association in associations.OrderBy(e => e.Element(XName.Get("role", scope_S100))!.Attribute("ref")!.Value).ThenBy(e => e.Parent!.Element(XName.Get("code", scope_S100))!.Value)) {
                        var informationType = association.Parent!.Element(XName.Get("code", scope_S100))!.Value;

                        var roleType = association.Attribute("roleType")!.Value;
                        var role = association.Element(XName.Get("role", scope_S100))!.Attribute("ref")!.Value;
                        var lower = int.Parse(association.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                        var upper = association.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                        int? u = default;    // "default";
                        if (!(upper.Attribute(XName.Get("infinite")) != default && upper.Attribute(XName.Get("infinite"))!.Value.Equals("true"))) {
                            u = int.Parse(upper!.Value);    // $"{int.Parse(upper!.Value)}";
                        }

                        var informationTypeRefs = association.Elements(XName.Get("informationType", scope_S100)).Select(e => $"{e.Attribute("ref")!.Value}").ToArray();

                        var informationTypeRefsHierarchy = new List<string>();
                        foreach (var f in informationTypeRefs) {
                            foreach (var h in informationHierarchy.Hierarchy(f)) {
                                informationTypeRefsHierarchy.Add(h);
                            }
                        }
                        //if (informationTypeRefs.Count() != informationTypeRefsHierarchy.Count())
                        //    System.Diagnostics.Debugger.Break();
                        informationTypeRefs = informationTypeRefsHierarchy.Select(e => $"\"{e}\"").ToArray();

                        var hierarchy = association.Parent!.Name.LocalName switch {
                            "S100_FC_FeatureType" => featureHierarchy.Hierarchy(informationType),
                            _ or "S100_FC_InformationType" => informationHierarchy.Hierarchy(informationType),
                        };

                        foreach (var f in hierarchy) {
                            var refName = $"{role}{f}RefIdViewModel";
                            if (lookup.Contains(refName))
                                continue;
                            lookup.Add(refName);
                            b.AppendLine($"new InformationAssociationConnector<{f}>() {{");
                            b.AppendLine($"\troleType = roleType.{roleType},");
                            b.AppendLine($"\trole = \"{role}\",");
                            b.AppendLine($"\tLower = {lower},");
                            if (u.HasValue)
                                b.AppendLine($"\tUpper = {u.Value},");
                            else
                                b.AppendLine($"\tUpper = default,");
                            b.AppendLine($"\tAssociationTypes = [{string.Join(',', informationTypeRefs)}],");

                            if (!u.HasValue || u.Value > 1)
                                b.AppendLine($"\tCreateForeignInformationBinding = () => new MultiInformationBindingViewModel<{code}ViewModel.{role}{f}RefIdViewModel>(\"{code.Replace("ViewModel", string.Empty)}\"),");
                            else if (lower > 0)
                                b.AppendLine($"\tCreateForeignInformationBinding = () => new SingleInformationBindingViewModel<{code}ViewModel.{role}{f}RefIdViewModel>(\"{code.Replace("ViewModel", string.Empty)}\"),");
                            else
                                b.AppendLine($"\tCreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<{code}ViewModel.{role}{f}RefIdViewModel>(\"{code.Replace("ViewModel", string.Empty)}\"),");

                            var createLocal = association.Parent!.Name.LocalName switch {
                                "S100_FC_FeatureType" => $"\tCreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<{f}ViewModel.{f}RefIdViewModel>(\"{f}\"),",
                                _ or "S100_FC_InformationType" => $"\tCreateLocalInformationBinding = () => new SingleInformationBindingViewModel<{f}ViewModel.{f}RefIdViewModel>(\"{f}\"),",
                            };
                            b.AppendLine(createLocal);
                            b.AppendLine($"}},");


                            viewBuilder.AppendLine($"\t\t\tpublic class {role}{f}RefIdViewModel : InformationRefIdViewModel {{");
                            viewBuilder.AppendLine($"\t\t\t\tpublic override string[] AssociationTypes => [{string.Join(',', informationTypeRefs)}];");
                            //viewBuilder.AppendLine("\t\t\t\tpublic override string ToString() => \"RefId\";");
                            viewBuilder.AppendLine($"\t\t\t}}");
                        }
                    }

                    viewBuilder.AppendLine($"\t\t\tpublic static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof({code}ViewModel)]();");

                    if (b.Length > 0) {
                        handlesBuilder.Insert(handlesAssociationConnectorInformations, $"\t\t\t{{ typeof({code}ViewModel), () => [{b.ToString().ReplaceLineEndings().TrimEnd().TrimEnd(',')}] }},");
                    }

                    viewBuilder.AppendLine("\t\t}");
                }
            }


            creatorBuilder.AppendLine(handlesBuilder.ToString());

            viewBuilder.Insert(creatorPosition, creatorBuilder.ToString());

            viewBuilder.AppendLine("}");

            var common = new StringBuilder();

            common.AppendLine("using System;");
            common.AppendLine("using System.Linq;");
            common.AppendLine("using System.ComponentModel;");
            common.AppendLine();
            common.AppendLine("namespace S100Framework.DomainModel");
            common.AppendLine("{");
            common.AppendLine("\t[System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]");
            common.AppendLine("\tpublic class CodeListAttribute : System.Attribute");
            common.AppendLine("\t{");
            common.AppendLine("\t\tprivate string _propertyName;");
            common.AppendLine();
            common.AppendLine("\t\tpublic string PropertyName => _propertyName;");
            common.AppendLine();
            common.AppendLine("\t\tpublic CodeListAttribute(string propertyName) { ");
            common.AppendLine("\t\t\t_propertyName = propertyName;");
            common.AppendLine("\t\t}");
            common.AppendLine("\t}");
            common.AppendLine();
            common.AppendLine("\t[System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]");
            common.AppendLine("\tpublic class RoleAttribute : System.Attribute");
            common.AppendLine("\t{");
            common.AppendLine("\t\tprivate string _roleName;");
            common.AppendLine();
            common.AppendLine("\t\tpublic string RoleName => _roleName;");
            common.AppendLine();
            common.AppendLine("\t\tpublic RoleAttribute(string roleName) { ");
            common.AppendLine("\t\t\t_roleName = roleName;");
            common.AppendLine("\t\t}");
            common.AppendLine("\t}");
            common.AppendLine();
            common.AppendLine("\t[System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]");
            common.AppendLine("\tpublic class RequiredAttribute : System.Attribute");
            common.AppendLine("\t{");
            common.AppendLine("\t}");
            common.AppendLine();

            common.AppendLine("\t[System.SerializableAttribute()]");
            common.AppendLine("\tpublic abstract class Node {");
            common.AppendLine("\t\tpublic virtual string Code => string.Empty;");
            common.AppendLine("\t}");
            common.AppendLine();
            common.AppendLine("\t[System.SerializableAttribute()]");
            common.AppendLine("\tpublic abstract class InformationNode : Node {");
            common.AppendLine("\t}");
            common.AppendLine();
            common.AppendLine("\t[System.SerializableAttribute()]");
            common.AppendLine("\tpublic abstract class FeatureNode : Node {");
            common.AppendLine("\t}");

            common.AppendLine("\t[System.SerializableAttribute()]");
            common.AppendLine("\tpublic class RefId {");
            common.AppendLine("\t\tpublic required string Value { get; set; }");
            common.AppendLine("\t\tpublic required string Type { get; set; }");
            common.AppendLine("\t\tpublic required string Role { get; set; }");
            common.AppendLine("\t}");

            common.AppendLine("\t[System.SerializableAttribute()]");
            common.AppendLine("\tpublic class FeatureAssociation {");
            common.AppendLine("\t\tpublic required string Code {get; set; }");
            common.AppendLine("\t\tpublic required string AssociationConnectorTypeName { get; set; }");
            common.AppendLine("\t\tpublic RefId[] RefIds { get; set; } = new RefId[0];");
            common.AppendLine("\t}");


            /*
                public class RefId
                {
                    public required string Value { get; set; }

                    public required string Type { get; set; }

                    public required string Role { get; set; }
                }

                public class FeatureAssociation
                {
                    public required string AssociationConnectorTypeName { get; set; }

                    public RefId[] RefIds { get; set; } = new RefId[0];
                }
             */


            common.AppendLine();


            common.AppendLine($"\tnamespace Bindings");
            common.AppendLine("\t{");

            common.AppendLine("\t\tpublic enum roleType");
            common.AppendLine("\t\t{");
            common.AppendLine("\t\t\tassociation,");
            common.AppendLine("\t\t\taggregation,");
            common.AppendLine("\t\t\tcomposition,");
            common.AppendLine("\t\t}");
            common.AppendLine("\t}");
            common.AppendLine("}");

            // Create a workspace to apply formatting options
            var workspace = new AdhocWorkspace();

            // Define formatting options
            var options = workspace.Options
                .WithChangedOption(FormattingOptions.IndentationSize, LanguageNames.CSharp, 4)
                .WithChangedOption(FormattingOptions.TabSize, LanguageNames.CSharp, 4)
                .WithChangedOption(FormattingOptions.UseTabs, LanguageNames.CSharp, false)
                .WithChangedOption(FormattingOptions.SmartIndent, LanguageNames.CSharp, FormattingOptions.IndentStyle.Smart);


            // Configure the options to keep braces on the same line
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInMethods, false);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInProperties, false);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInTypes, false);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInAccessors, false);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInControlBlocks, false);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInAnonymousMethods, false);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInAnonymousTypes, false);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInObjectCollectionArrayInitializers, false);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInLambdaExpressionBody, false);

            // Configure indentation for complex object creation
            options = options.WithChangedOption(CSharpFormattingOptions.IndentBraces, false); // Indent braces
            options = options.WithChangedOption(CSharpFormattingOptions.IndentBlock, true); // Indent blocks within braces
            options = options.WithChangedOption(CSharpFormattingOptions.IndentSwitchCaseSectionWhenBlock, true);
            options = options.WithChangedOption(CSharpFormattingOptions.IndentSwitchCaseSection, true); // Indent case sections
            options = options.WithChangedOption(CSharpFormattingOptions.IndentSwitchSection, true); // Indent switch sections

            // For wrapping and newlines in initializers
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInObjectCollectionArrayInitializers, true);
            options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInAnonymousTypes, true);

            options = options.WithChangedOption(CSharpFormattingOptions.WrappingPreserveSingleLine, true);
            options = options.WithChangedOption(CSharpFormattingOptions.WrappingKeepStatementsOnSingleLine, true);

            // Replace the workspace options with the updated options
            workspace.TryApplyChanges(workspace.CurrentSolution.WithOptions(options));

            var rootDomainSyntax = CSharpSyntaxTree.ParseText(classBuilder.ToString().TrimEnd());
            var rootDomain = rootDomainSyntax.GetRoot();

            var rootViewSyntax = CSharpSyntaxTree.ParseText(viewBuilder.ToString().TrimEnd());
            var rootViewModel = rootViewSyntax.GetRoot();

            var rootCommonSyntax = CSharpSyntaxTree.ParseText(common.ToString().TrimEnd());
            var rootCommon = rootCommonSyntax.GetRoot();

            var rootDomainModified = rootDomain.EnsureOpeningBrace().EnsureNewline()!.NormalizeWhitespace();

            var rootViewModelModified = rootViewModel.EnsureOpeningBrace().EnsureNewline()!.NormalizeWhitespace();

            var rootCommonModified = rootCommon.EnsureOpeningBrace().EnsureNewline()!.NormalizeWhitespace();

            return (
                Formatter.Format(rootDomainModified, workspace).ToFullString(),
                Formatter.Format(rootViewModelModified, workspace).ToFullString(),
                Formatter.Format(rootCommonModified, workspace).ToFullString()
            );
        }

        private static string BuildClass(string code, Type type, string xmlNamespace, Action<StringBuilder>? postAction) {
            return BuildClass(code, type, xmlNamespace, null, postAction);
        }

        private static string BuildClass(string code, Type type, string xmlNamespace, string? parent = null, Action<StringBuilder>? postAction = null) {
            var S100FC = xmlNamespace;
            var classBuilder = new StringBuilder();

            var constructorBuilder = new StringBuilder();

            constructorBuilder.AppendLine($"\t\t\tpublic {code}(){{");


            classBuilder.AppendLine("\t\t[System.Serializable()]");
            classBuilder.AppendLine("\t\t[System.Diagnostics.CodeAnalysis.SuppressMessage(\"Style\", \"IDE1006:Naming Styles\", Justification = \"<Pending>\")]");
            if (code.ToLowerInvariant().Equals(code))
                classBuilder.AppendLine("#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.");
            var prefix = "\t\tpublic";
            if (type.IsAbstract)
                prefix += " abstract";

            if (type.BaseType != null && !type.BaseType.IsValueType && type.BaseType != typeof(Object)) {
                classBuilder.AppendLine($"{prefix} partial class {code} : {type.BaseType.Name}");
            }
            else {
                if (string.IsNullOrEmpty(parent))
                    classBuilder.AppendLine($"{prefix} partial class {code}");
                else
                    classBuilder.AppendLine($"{prefix} partial class {code}");
            }
            if (code.ToLowerInvariant().Equals(code))
                classBuilder.AppendLine("#pragma warning restore CS8981");
            classBuilder.AppendLine("\t\t{");

            var first = true;
            foreach (var p in type.GetProperties()) {
                if (p.DeclaringType != type)
                    continue;

                if (!first) {
                    classBuilder.AppendLine("");
                }

                var attribute1 = p.GetCustomAttribute<System.Runtime.CompilerServices.RequiredMemberAttribute>();

                if (attribute1 != null && !p.PropertyType.IsValueType) {
                    if (p.PropertyType == typeof(string))
                        constructorBuilder.AppendLine($"\t\t\t\t{p.Name} = string.Empty;");
                    else {
                        constructorBuilder.AppendLine($"\t\t\t\t{p.Name} = {BuildConstructor(p.PropertyType)}");
                    }
                }

                var attribute2 = p.GetCustomAttribute<S100Framework.DomainModel.RoleAttribute>();

                if (attribute2 is not null) {
                    classBuilder.AppendLine($"\t\t\t[S100Framework.DomainModel.Role({attribute2.RoleName})]");
                }

                if (!p.PropertyType.IsGenericType && p.PropertyType != typeof(String)) {
                    if (attribute1 is not null)
                        classBuilder.AppendLine("\t\t\t[Required()]");
                    var prop_prefix = "\t\t\tpublic";   // attribute1 != null ? "\t\t\tpublic required" : "\t\t\tpublic";
                    var prop_type = attribute1 != null ? $"{p.PropertyType.Name}" : $"{p.PropertyType.Name}?";

                    if ("System.Collections.Generic".Equals(p.PropertyType.Namespace))
                        prop_type = $"List<{p.Name}>";

                    classBuilder.AppendLine($"{prop_prefix} {prop_type} {p.Name} {{ get; set; }}");
                }
                else if (p.PropertyType == typeof(String)) {
                    var prop_type = p.PropertyType.Name;
                    if ("System.Collections.Generic".Equals(p.PropertyType.Namespace))
                        prop_type = $"List<{p.Name}>";

                    classBuilder.AppendLine($"\t\t\tpublic {prop_type} {p.Name} {{ get; set; }} = string.Empty;");
                }
                else {
                    if (attribute1 is not null)
                        classBuilder.AppendLine("\t\t\t[Required()]");
                    var prop_prefix = "\t\t\tpublic";   // attribute1 != null ? "\t\t\tpublic required" : "\t\t\tpublic";
                    var prop_type = GetPropertyType(p.PropertyType);

                    var prop_postfix = attribute1 != null ? "" : " = default;";

                    if ("System.Collections.Generic".Equals(p.PropertyType.Namespace)) {
                        prop_type = $"List<{prop_type}>";
                        prop_postfix = attribute1 != null ? "" : " = [];";
                    }
                    else if (attribute1 is null)
                        prop_type += "?";

                    classBuilder.AppendLine($"{prop_prefix} {prop_type} {p.Name} {{ get; set; }}{prop_postfix}");
                }
                first = false;
            }
            postAction?.Invoke(classBuilder);

            constructorBuilder.AppendLine("\t\t\t}");
            var constructor = constructorBuilder.ToString().TrimEnd(Environment.NewLine.ToCharArray());

            constructor = CSharpSyntaxTree.ParseText(constructor).GetRoot().NormalizeWhitespace().ToFullString();

            classBuilder.AppendLine();
            classBuilder.AppendLine(constructor);

            classBuilder.AppendLine("\t\t}");

            return classBuilder.ToString();
        }

        private static void BuildInformationBindings(string code, string xmlNamespace, XElement e, StringBuilder builder) {
        }

        private static string BuildClassViewModel(string code, Type type, string classNamespace, ICollection<string> codeLists, ICollection<string> roles, Action<StringBuilder>? postAction = null) {
            var classBuilder = new StringBuilder();

            if (code.ToLowerInvariant().Equals(code))
                classBuilder.AppendLine("#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.");
            var prefix = "\tpublic";
            if (type.IsAbstract)
                prefix += " abstract";
            else
                prefix += " partial";

            var prefixBuilder = new StringBuilder();

            classBuilder.AppendLine($"\t\t\t[CategoryOrder(\"{code}\", 0)]");
            classBuilder.AppendLine("\t\t\t[CategoryOrder(\"InformationBindings\", 100)]");
            classBuilder.AppendLine("\t\t\t[CategoryOrder(\"FeatureBindings\", 200)]");
            classBuilder.AppendLine($"{prefix} class {code}ViewModel : ViewModelBase");

            if (code.ToLowerInvariant().Equals(code))
                classBuilder.AppendLine("#pragma warning restore CS8981");
            classBuilder.AppendLine("\t{");
            classBuilder.AppendLine(prefixBuilder.ToString());
            var first = true;

            var loadBuilder = new StringBuilder();
            var serializeBuilder = new StringBuilder();
            var modelBuilder = new StringBuilder();

            var constructorBuilder = new StringBuilder();
            constructorBuilder.AppendLine($"\t\tpublic {code}ViewModel() : base() {{");

            serializeBuilder.AppendLine($"\t\t\tvar instance = new {classNamespace}.{code} {{");

            var insertCodeLists = new Dictionary<string, Action<StringBuilder>>();

            foreach (var p in type.GetProperties()) {
                var attribute2 = p.GetCustomAttribute<S100Framework.DomainModel.RoleAttribute>();

                if (attribute2 is not null) {
                    continue;
                }

                if (!first) {
                    classBuilder.AppendLine("");
                }

                var attribute1 = p.GetCustomAttribute<System.Runtime.CompilerServices.RequiredMemberAttribute>();

                var viewModel = !p.PropertyType.IsValueType && !codeLists.Contains(p.Name) /*&& !roles.Contains(p.Name) */? "ViewModel" : string.Empty;

                if (!p.PropertyType.IsGenericType) {
                    if (p.PropertyType == typeof(String)) {
                        var prop_type = p.PropertyType.Name;

                        loadBuilder.AppendLine($"\t\t\t{p.Name} = instance.{p.Name};");
                        serializeBuilder.AppendLine($"\t\t\t\t{p.Name} = this.{p.Name},");
                        modelBuilder.AppendLine($"\t\t\t{p.Name} = this._{p.Name},");

                        classBuilder.AppendLine($"\t\tprivate {prop_type} _{p.Name} = string.Empty;");
                        classBuilder.AppendLine();
                        classBuilder.AppendLine($"\t\t[Category(\"{p.DeclaringType!.Name}\")]");
                        classBuilder.AppendLine($"\t\tpublic {p.PropertyType.Name} {p.Name} {{");
                        classBuilder.AppendLine($"\t\t\tget {{ return _{p.Name}; }}");
                        classBuilder.AppendLine($"\t\t\tset {{");
                        classBuilder.AppendLine($"\t\t\t\tSetValue(ref _{p.Name}, value);");
                        classBuilder.AppendLine($"\t\t\t}}");
                        classBuilder.AppendLine($"\t\t}}");
                    }
                    else {
                        var prop_type = attribute1 != null ? $"{p.PropertyType.Name}{viewModel}" : $"{p.PropertyType.Name}{viewModel}?";

                        if (!p.PropertyType.IsValueType && !codeLists.Contains(p.Name)) {
                            loadBuilder.AppendLine($"\t\t\t{p.Name} = new ();");
                            loadBuilder.AppendLine($"\t\t\tif (instance.{p.Name} != null) {{");
                            loadBuilder.AppendLine($"\t\t\t\t{p.Name} = new ();");
                            loadBuilder.AppendLine($"\t\t\t\t{p.Name}.Load(instance.{p.Name});");
                            loadBuilder.AppendLine($"\t\t\t}}");
                            serializeBuilder.AppendLine($"\t\t\t\t{p.Name} = this.{p.Name}?.Model,");
                            modelBuilder.AppendLine($"\t\t\t{p.Name} = this._{p.Name}?.Model,");
                        }
                        else {
                            loadBuilder.AppendLine($"\t\t\t{p.Name} = instance.{p.Name};");
                            serializeBuilder.AppendLine($"\t\t\t\t{p.Name} = this.{p.Name},");
                            modelBuilder.AppendLine($"\t\t\t{p.Name} = this._{p.Name},");
                        }

                        classBuilder.AppendLine($"\t\tprivate {prop_type} _{p.Name};");
                        classBuilder.AppendLine();
                        if (codeLists.Contains(p.Name)) {
                            classBuilder.AppendLine($"\t\t[DomainModel.CodeList(nameof({p.PropertyType.Name}List))]");
                            classBuilder.AppendLine("\t\t[Editor(typeof(Editors.CodeListComboEditor), typeof(Editors.CodeListComboEditor))]");
                        }
                        classBuilder.AppendLine($"\t\t[Category(\"{p.DeclaringType!.Name}\")]");

                        if (p.GetCustomAttribute<Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObjectAttribute>() != null)
                            classBuilder.AppendLine($"\t\t[Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]");
                        classBuilder.AppendLine($"\t\tpublic {prop_type} {p.Name} {{");
                        classBuilder.AppendLine($"\t\t\tget {{ return _{p.Name}; }}");
                        classBuilder.AppendLine($"\t\t\tset {{");
                        classBuilder.AppendLine($"\t\t\t\tSetValue(ref _{p.Name}, value);");
                        classBuilder.AppendLine($"\t\t\t}}");
                        classBuilder.AppendLine($"\t\t}}");

                        if (codeLists.Contains(p.Name)) {
                            if (!insertCodeLists.ContainsKey(p.Name)) {
                                insertCodeLists.Add(p.Name, (s) => {
                                    s.AppendLine($"\t\t[Browsable(false)]");
                                    s.AppendLine($"\t\tpublic {p.PropertyType.Name}[] {p.PropertyType.Name}List => CodeList.{pluralizer.Pluralize(p.PropertyType.Name)}.ToArray();");
                                });
                            }
                        }
                    }
                }
                else {
                    var prop_name = GetPropertyType(p.PropertyType);

                    var prop_type = attribute1 != null ? $"{prop_name}{viewModel}" : $"{prop_name}?";
                    var prop_postfix = attribute1 != null ? "" : " = default";

                    if ("System.Collections.Generic".Equals(p.PropertyType.Namespace)) {
                        loadBuilder.AppendLine($"\t\t\t{p.Name}.Clear();");
                        loadBuilder.AppendLine($"\t\t\tif(instance.{p.Name} is not null)");
                        loadBuilder.AppendLine($"\t\t\t\tforeach(var e in instance.{p.Name})");
                        loadBuilder.AppendLine($"\t\t\t\t\t{p.Name}.Add(e);");

                        constructorBuilder.AppendLine($"\t\t\t{p.Name}.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {{");
                        constructorBuilder.AppendLine($"\t\t\t\tOnPropertyChanged(nameof({p.Name}));");
                        constructorBuilder.AppendLine($"\t\t\t}};");

                        serializeBuilder.AppendLine($"\t\t\t\t{p.Name} = this.{p.Name}.ToList(),");
                        modelBuilder.AppendLine($"\t\t\t\t{p.Name} = this.{p.Name}.ToList(),");

                        if (codeLists.Contains(prop_name)) {
                            classBuilder.AppendLine($"\t\t[DomainModel.CodeList(nameof({prop_name}List))]");
                            classBuilder.AppendLine("\t\t[Editor(typeof(Editors.CodeListCheckComboEditor), typeof(Editors.CodeListCheckComboEditor))]");
                        }
                        classBuilder.AppendLine($"\t\t[Category(\"{p.DeclaringType!.Name}\")]");
                        classBuilder.AppendLine($"\t\tpublic ObservableCollection<{prop_name}> {p.Name} {{get;set;}} = new ();");

                        if (codeLists.Contains(prop_name)) {
                            if (!insertCodeLists.ContainsKey(prop_name)) {
                                insertCodeLists.Add(prop_name, (s) => {
                                    s.AppendLine($"\t\t[Browsable(false)]");
                                    s.AppendLine($"\t\tpublic {prop_name}[] {prop_name}List => CodeList.{pluralizer.Pluralize(prop_name)}.ToArray();");
                                });
                            }
                        }
                    }
                    else {
                        loadBuilder.AppendLine($"\t\t\t{p.Name} = instance.{p.Name};");
                        serializeBuilder.AppendLine($"\t\t\t\t{p.Name} = this.{p.Name},");
                        modelBuilder.AppendLine($"\t\t\t{p.Name} = this._{p.Name},");

                        classBuilder.AppendLine($"\t\tprivate {prop_type} _{p.Name}{prop_postfix};");
                        classBuilder.AppendLine();
                        if (codeLists.Contains(p.Name)) {
                            classBuilder.AppendLine("\t\t[DomainModel.CodeListAttribute]");
                        }
                        classBuilder.AppendLine($"\t\t[Category(\"{p.DeclaringType!.Name}\")]");

                        if (p.GetCustomAttribute<Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObjectAttribute>() != null)
                            classBuilder.AppendLine($"\t\t[Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]");
                        classBuilder.AppendLine($"\t\tpublic {prop_type} {p.Name} {{");
                        classBuilder.AppendLine($"\t\t\tget {{ return _{p.Name}; }}");
                        classBuilder.AppendLine($"\t\t\tset {{");
                        classBuilder.AppendLine($"\t\t\t\tSetValue(ref _{p.Name}, value);");
                        classBuilder.AppendLine($"\t\t\t}}");
                        classBuilder.AppendLine($"\t\t}}");
                    }
                }

                first = false;
            }

            postAction?.Invoke(classBuilder);

            foreach (var codelist in insertCodeLists) {
                codelist.Value.Invoke(classBuilder);
            }
            serializeBuilder.AppendLine("\t\t\t};");
            serializeBuilder.AppendLine("\t\t\treturn System.Text.Json.JsonSerializer.Serialize(instance);");

            constructorBuilder.AppendLine("\t\t}");

            //  Loader
            classBuilder.AppendLine("");
            classBuilder.AppendLine($"\t\tpublic void Load({classNamespace}.{code} instance) {{");
            classBuilder.Append(loadBuilder.ToString());
            classBuilder.AppendLine("\t\t}");
            classBuilder.AppendLine("");

            //  Serializer
            classBuilder.AppendLine($"\t\tpublic override string Serialize() {{");
            classBuilder.Append(serializeBuilder.ToString());
            classBuilder.AppendLine("\t\t}");

            //  Model
            classBuilder.AppendLine("\t\t[Browsable(false)]");
            classBuilder.AppendLine($"\t\tpublic {classNamespace}.{code} Model => new () {{");
            classBuilder.Append(modelBuilder.ToString());
            classBuilder.AppendLine($"\t\t}};");

            //  Constructor
            classBuilder.AppendLine(constructorBuilder.ToString());

            classBuilder.AppendLine("\t}");


            var root = CSharpSyntaxTree.ParseText(classBuilder.ToString().TrimEnd()).GetRoot();

            return classBuilder.ToString();
        }

        private static string GetPropertyType(Type p) {
            if (!S100Framework.Roslyn.Namespace.Equals(p.Namespace))
                p = p.GenericTypeArguments[0];
            var propertyType = p.Name;
            if (p.GenericTypeArguments.Length > 0) {
                propertyType += $"<{GetPropertyType(p.GenericTypeArguments[0])}>";
            }
            return propertyType;
        }

        private static string BuildConstructor(Type type) {
            StringBuilder builder = new StringBuilder();


            if ("System.Collections.Generic".Equals(type.Namespace))
                builder.AppendLine($"new ();");
            else {
                var type_name = GetPropertyType(type);
                builder.AppendLine($"new {type_name} () {{");

                foreach (var p in type.GetProperties()) {
                    var attribute = p.GetCustomAttribute<System.Runtime.CompilerServices.RequiredMemberAttribute>();

                    if (attribute != null) {
                        if (p.PropertyType == typeof(string))
                            builder.AppendLine($"\t\t\t\t\t{p.Name} = string.Empty,");
                        else if (p.PropertyType.IsValueType) {
                            builder.AppendLine($"\t\t\t\t\t{p.Name} = default({p.PropertyType.Name}),");
                        }
                        else
                            builder.AppendLine($"\t\t\t\t\t{p.Name} = {BuildConstructor(p.PropertyType)};");
                    }
                }
                builder.AppendLine("};");
            }

            return builder.ToString();
        }

        private static Type GetNullableType(Type type) {
            type = Nullable.GetUnderlyingType(type) ?? type; // avoid type becoming null
            if (type.IsValueType)
                return typeof(Nullable<>).MakeGenericType(type);
            else
                return type;
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

        private static string Base64Encode(string plainText) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private static readonly string[] OnesEnglish = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
    }
}

namespace S100Framework
{
    public static class Extensions
    {
        public static IEnumerable<string> Hierarchy(this List<ClassBuilder.featureType> featureTypes, string code) {
            if (featureTypes.Single(e => e.code.Equals(code)).isAbstract == false)
                yield return code;

            foreach (var f in featureTypes.Where(e => code.Equals(e.superType))) {
                foreach (var s in featureTypes.Hierarchy(f.code))
                    yield return s;
            }

            yield break;
        }

        public static IEnumerable<string> Hierarchy(this List<ClassBuilder.informationType> informationTypes, string code) {
            if (informationTypes.Single(e => e.code.Equals(code)).isAbstract == false)
                yield return code;

            foreach (var f in informationTypes.Where(e => code.Equals(e.superType))) {
                foreach (var s in informationTypes.Hierarchy(f.code))
                    yield return s;
            }

            yield break;
        }

        public static SyntaxNode? EnsureOpeningBrace(this SyntaxNode? root) {
            return root;
            if (root is null)
                return root;
            return root.ReplaceNodes(
                root.DescendantNodes().OfType<MethodDeclarationSyntax>(),
                (original, rewritten) => {
                    if (rewritten!.Body is null)
                        return rewritten;
                    // Ensure the opening brace is on the same line as the method declaration
                    var openBraceToken = rewritten!.Body!.OpenBraceToken
                        .WithLeadingTrivia(SyntaxFactory.ElasticSpace);
                    var methodBody = rewritten.Body.WithOpenBraceToken(openBraceToken);
                    return rewritten.WithBody(methodBody);
                })!;
        }

        public static SyntaxNode? EnsureNewline(this SyntaxNode? root) {
            return root;
            if (root is null)
                return root;
            return root.ReplaceNodes(
                root.DescendantNodes().OfType<ClassDeclarationSyntax>(),
                (original, rewritten) => {
                    // Ensure there is a leading newline before the class
                    var leadingTrivia = rewritten.GetLeadingTrivia();
                    if (!leadingTrivia.ToString().Contains("\n\n")) {
                        leadingTrivia = leadingTrivia.Insert(0, SyntaxFactory.CarriageReturnLineFeed);
                    }
                    return rewritten.WithLeadingTrivia(leadingTrivia);
                });
        }

        public static SyntaxNode? RemoveUsings(this SyntaxNode? root, SemanticModel semanticModel) {
            if (root is null)
                return root;

            // Find and remove unused using directives
            var unusedUsings = new List<UsingDirectiveSyntax>();
            var usings = root.DescendantNodes().OfType<UsingDirectiveSyntax>();

            foreach (var usingDirective in usings) {
                // Check if the namespace or type in the using directive is used
                var symbolInfo = semanticModel.GetSymbolInfo(usingDirective.Name);
                var symbol = symbolInfo.Symbol;

                // If the symbol is not used, add it to the unused list
                if (symbol == null) {
                    unusedUsings.Add(usingDirective);
                }
            }

            // Remove unused using directives
            var rootWithoutUnusedUsings = root.RemoveNodes(unusedUsings, SyntaxRemoveOptions.KeepNoTrivia);
            return rootWithoutUnusedUsings;
        }
    }
}