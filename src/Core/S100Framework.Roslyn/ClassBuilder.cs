using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Formatting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using Pluralize.NET.Core;
using S100Framework.DomainModel;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

//TODO: Enum som lister ala Aegir


namespace S100Framework
{
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
            classBuilder.AppendLine("using System.Runtime.Serialization;");
            classBuilder.AppendLine("using System.Text.Json.Serialization;");
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
            viewBuilder.AppendLine($"using S100Framework.DomainModel.{productId};");
            viewBuilder.AppendLine($"using S100Framework.DomainModel.{productId}.ComplexAttributes;");
            viewBuilder.AppendLine($"using S100Framework.DomainModel.{productId}.InformationTypes;");
            viewBuilder.AppendLine($"using S100Framework.DomainModel.{productId}.FeatureTypes;");
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
                        if (simpleAttribute.Element(XName.Get("listedValues", scope_S100)) is null)
                            return default;

                        if (enumTypes.ContainsKey(code))
                            return enumTypes[code];

                        var enumBuilder = moduleBuilder.DefineEnum(code, TypeAttributes.Public, typeof(int));

                        var listedValues = new Dictionary<string, XElement>();

                        if (!simpleAttribute.Element(XName.Get("listedValues", scope_S100))!.Elements().Any(e => RemoveSpecialChars(e.Element(XName.Get("label", scope_S100))!.Value!).Equals("Unknown", StringComparison.InvariantCultureIgnoreCase))) {
                            enumBuilder.DefineLiteral("Unknown", -1);
                            listedValues.Add("Unknown", XElement.Parse($"<S100FC:listedValue xmlns:S100FC=\"{scope_S100}\"><S100FC:label>Unknown</S100FC:label><S100FC:definition>Unknown value.</S100FC:definition><S100FC:code>-1</S100FC:code></S100FC:listedValue>"));
                        }

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
                            classBuilder.AppendLine($"\t\t[EnumMember(Value = \"{listedValueLabel}\")] ");
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

                            var permittedValues = attributeBinding.XPathSelectElement("S100FC:permittedValues", xmlNamespaceManager);

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

                            if (permittedValues is not null) {
                                foreach (var v in permittedValues.XPathSelectElements("S100FC:value", xmlNamespaceManager).Select(e => e.Value).ToList()) {
                                    var constructorInfo = typeof(EnumerationValueAttribute).GetConstructors().First();

                                    var enumerationValueAttributeBuilder = new CustomAttributeBuilder(constructorInfo, new object[1] { int.Parse(v) });
                                    propertyBuilder.SetCustomAttribute(enumerationValueAttributeBuilder);
                                }
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
                            viewBuilder.AppendLine(BuildClassViewModel(code, name, complexType, $"DomainModel.{productId}.ComplexAttributes", codelistTypes.Keys, enumTypes.Keys, roleTypes.Keys));
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

            creatorBuilder.AppendLine("\tinternal static class Bootstrap {");
            //creatorBuilder.AppendLine("\t\tpublic static bool Exist(string type) => _creators.ContainsKey(type);");
            //creatorBuilder.AppendLine("\t\tpublic static ViewModelBase Create(string type) => _creators[type]();");
            //creatorBuilder.AppendLine("\t\tprivate static ImmutableDictionary<string, Func<ViewModelBase>> _creators => ImmutableDictionary.Create<string, Func<ViewModelBase>>().AddRange(new Dictionary<string, Func<ViewModelBase>> {");

            var creatorInformationAssociations = new StringBuilder();
            var creatorFeatureAssociations = new StringBuilder();

            var creatorInformationTypes = new StringBuilder();
            var creatorFeatureTypes = new StringBuilder();

            var spatialAssociationTypes = new List<string>();

            var informationAssociationRoles = new Dictionary<string, string[]>();
            var featureAssociationRoles = new Dictionary<string, string[]>();

            classBuilder.AppendLine("}");
            classBuilder.AppendLine($"namespace S100Framework.DomainModel.{productId}");
            classBuilder.AppendLine("{");

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


            //  S100_FC_SpatialAssociations
            {
                classBuilder.AppendLine($"\tnamespace Associations");
                classBuilder.AppendLine("\t{");

                var elementsInformationAssociation = productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationAssociation", xmlNamespaceManager);

                classBuilder.AppendLine($"\tnamespace SpatialAssociations");
                classBuilder.AppendLine("\t\t{");

                foreach (var e in elementsInformationAssociation) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    var usage = productSpecification.XPathSelectElements($"//S100FC:informationBinding/S100FC:association[@ref=\"{code}\"]", xmlNamespaceManager);

                    if (!usage.Any()) {
                        if (code.Contains("Spatial")) {
                            spatialAssociationTypes.Add(code);

                            var attributes = TypeAttributes.Public | TypeAttributes.Class | /*TypeAttributes.AutoClass |*/ TypeAttributes.AutoLayout;

                            TypeBuilder associationTypeBuilder;

                            associationTypeBuilder = moduleBuilder.DefineType($"{S100Framework.Roslyn.Namespace}.Associations.{code}", attributes);

                            foreach (var attributeBinding in e.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                                associationTypeBuilder.BuildAttributeBinding(attributeBinding, scope_S100, xmlNamespaceManager, dictionaryTypes, dictionaryTypesComplex);
                            }

                            var associationType = associationTypeBuilder.CreateType();

                            classBuilder.AppendLine(BuildClass(code, associationType, xmlNamespace, (builder) => {

                            }));
                        }
                    }

                }

                classBuilder.AppendLine("\t\t}");
            }

            staticBuilder.AppendLine();
            staticBuilder.AppendLine("\t\tpublic static string[] SpatialAssociationTypes => [");
            foreach (var code in spatialAssociationTypes) {
                staticBuilder.AppendLine($"\t\t\t\"{code}\",");
            }
            staticBuilder.AppendLine("\t\t];");

            //  S100_FC_InformationAssociations
            {
                classBuilder.AppendLine($"\tnamespace InformationAssociations");
                classBuilder.AppendLine("\t\t{");
                classBuilder.AppendLine($"\t\tusing S100Framework.DomainModel.{productId}.InformationTypes;");

                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationAssociation", xmlNamespaceManager);

                var informationAssociationTypes = new List<string>();

                var superClassHierarchy = new Dictionary<string, string>();
                var superClassViewModels = new Dictionary<string, string>();

                foreach (var e in elements) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    var roles = e.Elements(XName.Get("role", scope_S100)).Select(e => e.Attribute("ref")!.Value);

                    roles = roles.Where(r => productSpecification.XPathSelectElements($"//S100FC:informationBinding[S100FC:association[@ref=\"{code}\"] and S100FC:role[@ref=\"{r}\"]]", xmlNamespaceManager).Any());

                    informationAssociationRoles.Add(code, roles.ToArray());

                    if (!spatialAssociationTypes.Contains(code)) {
                        informationAssociationTypes.Add(code);

                        var attributes = TypeAttributes.Public | TypeAttributes.Class | /*TypeAttributes.AutoClass |*/ TypeAttributes.AutoLayout;

                        if (e.Attribute("isAbstract") != default && bool.Parse(e.Attribute("isAbstract")!.Value))
                            attributes |= TypeAttributes.Abstract;

                        TypeBuilder associationTypeBuilder;

                        associationTypeBuilder = moduleBuilder.DefineType($"{S100Framework.Roslyn.Namespace}.Associations.{code}", attributes, typeof(InformationAssociation));

                        foreach (var attributeBinding in e.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                            associationTypeBuilder.BuildAttributeBinding(attributeBinding, scope_S100, xmlNamespaceManager, dictionaryTypes, dictionaryTypesComplex);
                        }

                        var associationType = associationTypeBuilder.CreateType();

                        var viewModelBindingBuilder = new StringBuilder();

                        classBuilder.AppendLine(BuildClass($"{code}", associationType, xmlNamespace, (builder) => {
                            builder.AppendLine($"\t\t\tpublic string Code => nameof({code});");
                        }));

                        if (!attributes.HasFlag(TypeAttributes.Abstract)) {
                            viewBuilder.AppendLine(BuildClassViewModelAssociation(code, name, associationType, $"DomainModel.{productId}.Associations.InformationAssociations", codelistTypes.Keys, enumTypes.Keys, roleTypes.Keys, (builder) => {
                                var c = code;
                                while (!string.IsNullOrEmpty(c) && superClassHierarchy.ContainsKey(c)) {
                                    c = superClassHierarchy[c];
                                    if (superClassViewModels.ContainsKey(c)) {
                                        builder.AppendLine(superClassViewModels[c]);
                                    }
                                }

                                builder.AppendLine(viewModelBindingBuilder.ToString());

                                //builder.AppendLine($"\t\t\tpublic class {code}RefIdViewModel : FeatureRefIdViewModel {{");
                                //builder.AppendLine($"\t\t\t\tpublic override string[] AssociationTypes => [\"{code}\"];");
                                //builder.AppendLine($"\t\t\t}}");
                            }));


                            //creatorBuilder.AppendLine($"\t\t\t{{ \"{code}\", ()=> {{");
                            //creatorBuilder.AppendLine($"\t\t\t\treturn new {code}ViewModel();");
                            //creatorBuilder.AppendLine("\t\t\t  }");
                            //creatorBuilder.AppendLine("\t\t\t},");

                            creatorInformationAssociations.AppendLine($"\t\t\"{code}\" => new {code}ViewModel {{ PID = pid }},");
                        }
                        else
                            superClassViewModels.Add(code, viewModelBindingBuilder.ToString());
                    }
                }

                classBuilder.AppendLine("\t\t}");

                staticBuilder.AppendLine();
                staticBuilder.AppendLine("\t\tpublic static string[] InformationAssociationTypes => [");
                foreach (var code in informationAssociationTypes) {
                    staticBuilder.AppendLine($"\t\t\t\"{code}\",");
                }
                staticBuilder.AppendLine("\t\t];");
            }

            //  S100_FC_FeatureAssociations
            {
                classBuilder.AppendLine($"\tnamespace FeatureAssociations");
                classBuilder.AppendLine("\t\t{");
                classBuilder.AppendLine($"\t\tusing S100Framework.DomainModel.{productId}.FeatureTypes;");

                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureAssociation", xmlNamespaceManager);

                var featureAssociationTypes = new List<string>();

                var superClassHierarchy = new Dictionary<string, string>();
                var superClassViewModels = new Dictionary<string, string>();

                foreach (var e in elements) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    var roles = e.Elements(XName.Get("role", scope_S100)).Select(e => e.Attribute("ref")!.Value);

                    roles = roles.Where(r => productSpecification.XPathSelectElements($"//S100FC:featureBinding[S100FC:association[@ref=\"{code}\"] and S100FC:role[@ref=\"{r}\"]]", xmlNamespaceManager).Any());

                    featureAssociationRoles.Add(code, roles.ToArray());

                    if (!spatialAssociationTypes.Contains(code)) {
                        featureAssociationTypes.Add(code);

                        var attributes = TypeAttributes.Public | TypeAttributes.Class | /*TypeAttributes.AutoClass |*/ TypeAttributes.AutoLayout;

                        if (e.Attribute("isAbstract") != default && bool.Parse(e.Attribute("isAbstract")!.Value))
                            attributes |= TypeAttributes.Abstract;

                        TypeBuilder associationTypeBuilder;

                        associationTypeBuilder = moduleBuilder.DefineType($"{S100Framework.Roslyn.Namespace}.Associations.{code}", attributes, typeof(FeatureAssociation));

                        foreach (var attributeBinding in e.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                            associationTypeBuilder.BuildAttributeBinding(attributeBinding, scope_S100, xmlNamespaceManager, dictionaryTypes, dictionaryTypesComplex);
                        }

                        var associationType = associationTypeBuilder.CreateType();

                        var viewModelBindingBuilder = new StringBuilder();

                        classBuilder.AppendLine(BuildClass($"{code}", associationType, xmlNamespace, (builder) => {
                            builder.AppendLine($"\t\t\tpublic string Code => \"{code}\";");
                        }));

                        if (!attributes.HasFlag(TypeAttributes.Abstract)) {
                            viewBuilder.AppendLine(BuildClassViewModelAssociation(code, name, associationType, $"DomainModel.{productId}.Associations.FeatureAssociations", codelistTypes.Keys, enumTypes.Keys, roleTypes.Keys, (builder) => {
                                var c = code;
                                while (!string.IsNullOrEmpty(c) && superClassHierarchy.ContainsKey(c)) {
                                    c = superClassHierarchy[c];
                                    if (superClassViewModels.ContainsKey(c)) {
                                        builder.AppendLine(superClassViewModels[c]);
                                    }
                                }

                                builder.AppendLine(viewModelBindingBuilder.ToString());

                                //builder.AppendLine($"\t\t\tpublic class {code}RefIdViewModel : FeatureRefIdViewModel {{");
                                //builder.AppendLine($"\t\t\t\tpublic override string[] AssociationTypes => [\"{code}\"];");
                                //builder.AppendLine($"\t\t\t}}");
                            }));


                            //creatorBuilder.AppendLine($"\t\t\t{{ \"{code}\", ()=> {{");
                            //creatorBuilder.AppendLine($"\t\t\t\treturn new {code}ViewModel();");
                            //creatorBuilder.AppendLine("\t\t\t  }");
                            //creatorBuilder.AppendLine("\t\t\t},");

                            creatorFeatureAssociations.AppendLine($"\t\t\"{code}\" => new {code}ViewModel {{ PID = pid }},");
                        }
                        else
                            superClassViewModels.Add(code, viewModelBindingBuilder.ToString());
                    }
                }

                classBuilder.AppendLine("\t\t}");

                staticBuilder.AppendLine();
                staticBuilder.AppendLine("\t\tpublic static string[] FeatureAssociationTypes => [");
                foreach (var code in featureAssociationTypes) {
                    staticBuilder.AppendLine($"\t\t\t\"{code}\",");
                }
                staticBuilder.AppendLine("\t\t];");
            }

            classBuilder.AppendLine("\t}");
            classBuilder.AppendLine();

            classBuilder.AppendLine($"\tnamespace Bindings");
            classBuilder.AppendLine("\t{");

            classBuilder.AppendLine("\t}");


            //var handlesBuilder = new StringBuilder();
            //handlesBuilder.AppendLine("\tpublic class Handles : iHandles {");
            //handlesBuilder.AppendLine("\t\tpublic static IDictionary<Type, Func<InformationAssociationConnector[]>> AssociationConnectorInformations => new Dictionary<Type, Func<InformationAssociationConnector[]>> {");
            //var handlesAssociationConnectorInformations = handlesBuilder.Length;
            //handlesBuilder.AppendLine("\t\t};");
            //handlesBuilder.AppendLine("\t\tpublic static IDictionary<Type, Func<FeatureAssociationConnector[]>> AssociationConnectorFeatures => new Dictionary<Type, Func<FeatureAssociationConnector[]>> {");
            //var handlesAssociationConnectorFeatures = handlesBuilder.Length;
            //handlesBuilder.AppendLine("\t\t};");


            //handlesBuilder.AppendLine("\t}");

            classBuilder.AppendLine("}");
            classBuilder.AppendLine($"namespace S100Framework.DomainModel.{productId}");
            classBuilder.AppendLine("{");

            var informationBindingTypes = new List<string>();
            var featureBindingTypes = new List<string>();

            //  S100_FC_InformationType
            classBuilder.AppendLine($"\tnamespace InformationTypes");
            classBuilder.AppendLine("\t{");
            classBuilder.AppendLine("\t\tusing ComplexAttributes;");
            classBuilder.AppendLine("\t\tusing DomainModel;");
            //classBuilder.AppendLine("\t\tusing System.Runtime.Serialization;");
            classBuilder.AppendLine($"\t\tusing S100Framework.DomainModel.{productId}.Associations.InformationAssociations;");
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
                            informationTypeBuilder.BuildAttributeBinding(attributeBinding, scope_S100, xmlNamespaceManager, dictionaryTypes, dictionaryTypesComplex);
                        }

                        var informationType = informationTypeBuilder.CreateType();

                        var informationBindingIndex = classBuilder.Length;

                        var viewModelBindingBuilder = new StringBuilder();

                        var informationBindingsList = new List<string>();

                        classBuilder.AppendLine(BuildClass(code, informationType, xmlNamespace, "S100Framework.DomainModel.InformationType", (builder) => {
                            builder.AppendLine("\t\t\t[JsonIgnore]");
                            builder.AppendLine($"\t\t\tpublic override string Code => nameof({code});");

                            var associations = new List<string>();

                            var index_associations = builder.Length;

                            //var builderAssociations = new Dictionary<string, StringBuilder>();

                            var informationBindings = new StringBuilder();
                            informationBindings.AppendLine("\t\t\tpublic static informationBindingDefinition[] informationBindingDefinitions => [");

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
                            builder.AppendLine(informationBindings.ToString());
                        }));

                        if (!attributes.HasFlag(TypeAttributes.Abstract)) {
                            viewBuilder.AppendLine(BuildClassViewModelTemplate(code, name, "InformationViewModel", informationType, $"DomainModel.{productId}.InformationTypes", codelistTypes.Keys, enumTypes.Keys, roleTypes.Keys, (builder) => {
                                var c = code;
                                while (!string.IsNullOrEmpty(c) && superClassHierarchy.ContainsKey(c)) {
                                    c = superClassHierarchy[c];
                                    if (superClassViewModels.ContainsKey(c)) {
                                        builder.AppendLine(superClassViewModels[c]);
                                    }
                                }

                                builder.AppendLine(viewModelBindingBuilder.ToString());

                                //builder.AppendLine($"\t\t\tpublic class {code}RefIdViewModel : InformationRefIdViewModel {{");
                                //builder.AppendLine($"\t\t\t\tpublic override string[] AssociationTypes => [\"{code}\"];");
                                //builder.AppendLine($"\t\t\t}}");

                                builder.AppendLine($"\t\t\tpublic override informationBindingDefinition[] informationBindingDefinitions => {code}.informationBindingDefinitions;");
                            }));

                            //creatorBuilder.AppendLine($"\t\t\t{{ \"{code}\", ()=> {{");
                            //creatorBuilder.AppendLine($"\t\t\t\treturn new {code}ViewModel();");
                            //creatorBuilder.AppendLine("\t\t\t  }");
                            //creatorBuilder.AppendLine("\t\t\t},");

                            creatorInformationTypes.AppendLine($"\t\t\"{code}\" => new {code}ViewModel {{ PID = pid }},");
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
            classBuilder.AppendLine("\t\tusing System.Runtime.Serialization;");
            classBuilder.AppendLine($"\t\tusing S100Framework.DomainModel.{productId}.Associations.InformationAssociations;");
            classBuilder.AppendLine($"\t\tusing S100Framework.DomainModel.{productId}.Associations.FeatureAssociations;");
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
                            var attributesMissing = e.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager).Where(b => !dictionaryTypes.ContainsKey(b.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!)).ToList();
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
                            featureTypeBuilder.BuildAttributeBinding(attributeBinding, scope_S100, xmlNamespaceManager, dictionaryTypes, dictionaryTypesComplex);
                        }

                        var featureType = featureTypeBuilder.CreateType();

                        var bindingIndex = classBuilder.Length;

                        var viewModelBindingBuilder = new StringBuilder();

                        classBuilder.AppendLine(BuildClass(code, featureType, xmlNamespace, "S100Framework.DomainModel.FeatureType", (builder) => {
                            builder.AppendLine("\t\t\t[JsonIgnore]");
                            builder.AppendLine($"\t\t\tpublic override string Code => nameof({code});");

                            var associations = new List<string>();

                            var index_associations = builder.Length;

                            //var builderAssociations = new Dictionary<string, StringBuilder>();

                            var informationBindings = new StringBuilder();
                            informationBindings.AppendLine("\t\t\tpublic static informationBindingDefinition[] informationBindingDefinitions => [");

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
                            builder.AppendLine(informationBindings.ToString());

                            var featureBindings = new StringBuilder();
                            featureBindings.AppendLine("\t\t\tpublic static featureBindingDefinition[] featureBindingDefinitions => [");

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
                            builder.AppendLine(featureBindings.ToString());
                        }));

                        if (!attributes.HasFlag(TypeAttributes.Abstract)) {
                            viewBuilder.AppendLine(BuildClassViewModelTemplate(code, name, "FeatureViewModel", featureType, $"DomainModel.{productId}.FeatureTypes", codelistTypes.Keys, enumTypes.Keys, roleTypes.Keys, (builder) => {
                                var c = code;
                                while (!string.IsNullOrEmpty(c) && superClassHierarchy.ContainsKey(c)) {
                                    c = superClassHierarchy[c];
                                    if (superClassViewModels.ContainsKey(c)) {
                                        builder.AppendLine(superClassViewModels[c]);
                                    }
                                }

                                builder.AppendLine(viewModelBindingBuilder.ToString());

                                //builder.AppendLine($"\t\t\tpublic class {code}RefIdViewModel : FeatureRefIdViewModel {{");
                                //builder.AppendLine($"\t\t\t\tpublic override string[] AssociationTypes => [\"{code}\"];");
                                //builder.AppendLine($"\t\t\t}}");

                                builder.AppendLine($"\t\t\tpublic override informationBindingDefinition[] informationBindingDefinitions => {code}.informationBindingDefinitions;");

                                builder.AppendLine($"\t\t\tpublic override featureBindingDefinition[] featureBindingDefinitions => {code}.featureBindingDefinitions;");
                            }));


                            //creatorBuilder.AppendLine($"\t\t\t{{ \"{code}\", ()=> {{");
                            //creatorBuilder.AppendLine($"\t\t\t\treturn new {code}ViewModel();");
                            //creatorBuilder.AppendLine("\t\t\t  }");
                            //creatorBuilder.AppendLine("\t\t\t},");

                            creatorFeatureTypes.AppendLine($"\t\t\"{code}\" => new {code}ViewModel {{ PID = pid }},");
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

            //creatorBuilder.AppendLine("\t\t});");

            creatorBuilder.AppendLine("\t\tpublic static AssociationViewModel CreateInformationAssociation(string type, string? pid = default) => type switch {");
            creatorBuilder.AppendLine(creatorInformationAssociations.ToString());
            creatorBuilder.AppendLine("\t\t\t_ => throw new InvalidOperationException(),");
            creatorBuilder.AppendLine("\t\t};");

            creatorBuilder.AppendLine("\t\tpublic static AssociationViewModel CreateFeatureAssociation(string type, string? pid = default) => type switch {");
            creatorBuilder.AppendLine(creatorFeatureAssociations.ToString());
            creatorBuilder.AppendLine("\t\t\t_ => throw new InvalidOperationException(),");
            creatorBuilder.AppendLine("\t\t};");

            creatorBuilder.AppendLine("\t\tpublic static InformationViewModel CreateInformationType(string type, string? pid = default) => type switch {");
            creatorBuilder.AppendLine(creatorInformationTypes.ToString());
            creatorBuilder.AppendLine("\t\t\t_ => throw new InvalidOperationException(),");
            creatorBuilder.AppendLine("\t\t};");

            creatorBuilder.AppendLine("\t\tpublic static FeatureViewModel CreateFeatureType(string type, string? pid = default) => type switch {");
            creatorBuilder.AppendLine(creatorFeatureTypes.ToString());
            creatorBuilder.AppendLine("\t\t\t_ => throw new InvalidOperationException(),");
            creatorBuilder.AppendLine("\t\t};");

            creatorBuilder.AppendLine("\t}");


            classBuilder.Insert(informationPosition, staticBuilder.ToString());

            //creatorBuilder.AppendLine(handlesBuilder.ToString());

            viewBuilder.Insert(creatorPosition, creatorBuilder.ToString());

            viewBuilder.AppendLine("}");

            var common = new StringBuilder();

            common.AppendLine("using System;");
            common.AppendLine("using System.Linq;");
            common.AppendLine("using System.ComponentModel;");
            common.AppendLine("using System.Runtime.Serialization;");
            common.AppendLine("using System.Text.Json.Serialization;");
            common.AppendLine();
            common.AppendLine("namespace S100Framework.DomainModel");
            common.AppendLine("{");

            common.AppendLine("\t[System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]");
            common.AppendLine("\tpublic class EnumerationAttribute : System.Attribute");
            common.AppendLine("\t{");
            common.AppendLine("\t\tprivate string _propertyName;");
            common.AppendLine();
            common.AppendLine("\t\tpublic string PropertyName => _propertyName;");
            common.AppendLine();
            common.AppendLine("\t\tpublic EnumerationAttribute(string propertyName) { ");
            common.AppendLine("\t\t\t_propertyName = propertyName;");
            common.AppendLine("\t\t}");
            common.AppendLine("\t}");
            common.AppendLine();

            common.AppendLine("\t[System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]");
            common.AppendLine("\tpublic class EnumerationValueAttribute : System.Attribute");
            common.AppendLine("\t{");
            common.AppendLine("\t\tprivate int _propertyValue;");
            common.AppendLine();
            common.AppendLine("\t\tpublic int PropertyValue => _propertyValue;");
            common.AppendLine();
            common.AppendLine("\t\tpublic EnumerationValueAttribute(int propertyValue) { ");
            common.AppendLine("\t\t\t_propertyValue = propertyValue;");
            common.AppendLine("\t\t}");
            common.AppendLine("\t}");
            common.AppendLine();

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
            common.AppendLine("\t\tpublic virtual string Code { get; set; } = string.Empty;");
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
            common.AppendLine("\t\tpublic required string? Value { get; set; }");
            common.AppendLine("\t\tpublic required string? Type { get; set; }");
            common.AppendLine("\t\tpublic required string Role { get; set; }");
            common.AppendLine("\t}");

            common.AppendLine("\t[System.SerializableAttribute()]");
            common.AppendLine("\tpublic abstract class Association {");
            //common.AppendLine("\t\tpublic abstract string Code { get; }");
            common.AppendLine("\t}");
            common.AppendLine("\t[System.SerializableAttribute()]");
            common.AppendLine("\tpublic abstract class InformationAssociation : Association {");
            common.AppendLine("\t}");
            common.AppendLine("\t[System.SerializableAttribute()]");
            common.AppendLine("\tpublic abstract class FeatureAssociation : Association {");
            common.AppendLine("\t}");

            common.AppendLine("\tpublic class informationBinding {");
            common.AppendLine("\t\tpublic string roleType { get; set; } = string.Empty;");
            common.AppendLine("\t\tpublic string association { get; set; } = string.Empty;");
            common.AppendLine("\t\tpublic string role { get; set; } = string.Empty;");
            common.AppendLine("\t\tpublic string? associationId { get; set; } = null;");
            common.AppendLine("\t\tpublic string? informationId { get; set; } = null;");
            common.AppendLine("\t\tpublic string? foreignId { get; set; } = null;");
            common.AppendLine("\t}");

            common.AppendLine("\tpublic class informationBindingDefinition {");
            common.AppendLine("\t\tpublic roleType roleType { get; set; }");
            common.AppendLine("\t\tpublic int lower { get; set; }");
            common.AppendLine("\t\tpublic int? upper { get; set; }");
            common.AppendLine("\t\tpublic bool infinite => !upper.HasValue;");
            common.AppendLine("\t\tpublic string association { get; set; } = string.Empty;");
            common.AppendLine("\t\tpublic string role { get; set; } = string.Empty;");
            common.AppendLine("\t\tpublic string[] informationTypes { get; set; } = [];");
            common.AppendLine("\t\tpublic override string ToString() => $\"{association}, {role}\";");
            common.AppendLine("\t}");

            common.AppendLine("\tpublic class featureBinding {");
            common.AppendLine("\t\tpublic string roleType { get; set; } = string.Empty;");
            common.AppendLine("\t\tpublic string association { get; set; } = string.Empty;");
            common.AppendLine("\t\tpublic string role { get; set; } = string.Empty;");
            common.AppendLine("\t\tpublic string? associationId { get; set; } = null;");
            common.AppendLine("\t\tpublic string? featureId { get; set; } = null;");
            common.AppendLine("\t\tpublic string? foreignId { get; set; } = null;");
            common.AppendLine("\t\t}");

            common.AppendLine("\tpublic class featureBindingDefinition {");
            common.AppendLine("\t\tpublic roleType roleType { get; set; }");
            common.AppendLine("\t\tpublic int lower { get; set; }");
            common.AppendLine("\t\tpublic int? upper { get; set; }");
            common.AppendLine("\t\tpublic bool infinite => !upper.HasValue;");
            common.AppendLine("\t\tpublic string association { get; set; } = string.Empty;");
            common.AppendLine("\t\tpublic string role { get; set; } = string.Empty;");
            common.AppendLine("\t\tpublic string[] featureTypes { get; set; } = [];");
            common.AppendLine("\t\tpublic override string ToString() => $\"{association}, {role}\";");
            common.AppendLine("\t}");

            common.AppendLine();

            common.AppendLine("\tpublic enum roleType");
            common.AppendLine("\t{");
            common.AppendLine("\t\tassociation,");
            common.AppendLine("\t\taggregation,");
            common.AppendLine("\t\tcomposition,");
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

                var ignoreDataMemberAttribute = p.GetCustomAttribute<System.Runtime.Serialization.IgnoreDataMemberAttribute>();
                if (ignoreDataMemberAttribute is not null) {
                    classBuilder.AppendLine("\t\t\t[IgnoreDataMember]");
                }
                var jsonIgnoreAttribute = p.GetCustomAttribute<JsonIgnoreAttribute>();
                if (jsonIgnoreAttribute is not null) {
                    classBuilder.AppendLine("\t\t\t[JsonIgnore]");
                }

                var requiredMemberAttribute = p.GetCustomAttribute<System.Runtime.CompilerServices.RequiredMemberAttribute>();

                if (requiredMemberAttribute != null && !p.PropertyType.IsValueType) {
                    if (p.PropertyType == typeof(string))
                        constructorBuilder.AppendLine($"\t\t\t\t{p.Name} = string.Empty;");
                    else if (p.PropertyType == typeof(string[]))
                        constructorBuilder.AppendLine($"\t\t\t\t{p.Name} = [];");
                    else {
                        constructorBuilder.AppendLine($"\t\t\t\t{p.Name} = {BuildConstructor(p.PropertyType)};");
                    }
                }

                var roleAttribute = p.GetCustomAttribute<S100Framework.DomainModel.RoleAttribute>();

                if (roleAttribute is not null) {
                    classBuilder.AppendLine($"\t\t\t[S100Framework.DomainModel.Role({roleAttribute.RoleName})]");
                }

                var enumerationValueAttribute = p.GetCustomAttributes<S100Framework.DomainModel.EnumerationValueAttribute>();
                if (enumerationValueAttribute.Any()) {
                    foreach (var e in enumerationValueAttribute) {
                        classBuilder.AppendLine($"\t\t\t[EnumerationValue({e.PropertyValue})]");
                    }
                }

                if (!p.PropertyType.IsGenericType && p.PropertyType != typeof(String)) {
                    if (requiredMemberAttribute is not null)
                        classBuilder.AppendLine("\t\t\t[Required()]");
                    var prop_prefix = "\t\t\tpublic";   // requiredMemberAttribute != null ? "\t\t\tpublic required" : "\t\t\tpublic";
                    var prop_type = requiredMemberAttribute != null ? $"{p.PropertyType.Name}" : $"{p.PropertyType.Name}?";

                    if ("System.Collections.Generic".Equals(p.PropertyType.Namespace))
                        prop_type = $"List<{p.Name}>";

                    classBuilder.AppendLine($"{prop_prefix} {prop_type} {p.Name} {{ get; set; }}");
                }
                else if (p.PropertyType == typeof(String)) {
                    var prop_type = p.PropertyType.Name;
                    var prop_postfix = " = string.Empty;";

                    if (requiredMemberAttribute == null) {
                        prop_type = $"{p.PropertyType.Name}?";
                        prop_postfix = " = null;";
                    }

                    if ("System.Collections.Generic".Equals(p.PropertyType.Namespace)) {
                        prop_type = $"List<{p.Name}>";
                        prop_postfix = " new List<string>();";
                    }

                    classBuilder.AppendLine($"\t\t\tpublic {prop_type} {p.Name} {{ get; set; }}{prop_postfix}");
                }
                else {
                    if (requiredMemberAttribute is not null)
                        classBuilder.AppendLine("\t\t\t[Required()]");
                    var prop_prefix = "\t\t\tpublic";   // requiredMemberAttribute != null ? "\t\t\tpublic required" : "\t\t\tpublic";
                    var prop_type = GetPropertyType(p.PropertyType);

                    var prop_postfix = requiredMemberAttribute != null ? "" : " = default;";

                    if ("System.Collections.Generic".Equals(p.PropertyType.Namespace)) {
                        prop_type = $"List<{prop_type}>";
                        prop_postfix = requiredMemberAttribute != null ? "" : " = [];";
                    }
                    else if (requiredMemberAttribute is null)
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

        private static string BuildClassViewModel(string code, string name, Type type, string classNamespace, ICollection<string> codeLists, ICollection<string> enumLists, ICollection<string> roles, Action<StringBuilder>? postAction = null) {
            return iBuildClassViewModel(code, name, "ViewModelBase", type, false, classNamespace, codeLists, enumLists, roles, postAction);
        }

        private static string BuildClassViewModelAssociation(string code, string name, Type type, string classNamespace, ICollection<string> codeLists, ICollection<string> enumLists, ICollection<string> roles, Action<StringBuilder>? postAction = null) {
            return iBuildClassViewModel(code, name, "AssociationViewModel", type, false, classNamespace, codeLists, enumLists, roles, postAction);
        }



        private static string BuildClassViewModelTemplate(string code, string name, string baseClass, Type type, string classNamespace, ICollection<string> codeLists, ICollection<string> enumLists, ICollection<string> roles, Action<StringBuilder>? postAction = null) {
            return iBuildClassViewModel(code, name, baseClass, type, true, classNamespace, codeLists, enumLists, roles, postAction);
        }

        private static string iBuildClassViewModel(string code, string name, string baseClass, Type type, bool isTemplate, string classNamespace, ICollection<string> codeLists, ICollection<string> enumLists, ICollection<string> roles, Action<StringBuilder>? postAction = null) {
            var ps = classNamespace.Split('.')[1];

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

            if (!isTemplate)
                classBuilder.AppendLine($"{prefix} class {code}ViewModel : {baseClass}");
            else
                classBuilder.AppendLine($"{prefix} class {code}ViewModel : {baseClass}<{code}>");

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

            var insertEnumerationLists = new Dictionary<string, Action<StringBuilder>>();

            var insertCodeLists = new Dictionary<string, Action<StringBuilder>>();

            foreach (var p in type.GetProperties()) {
                var roleAttribute = p.GetCustomAttribute<S100Framework.DomainModel.RoleAttribute>();

                if (roleAttribute is not null) {
                    continue;
                }

                if (!first) {
                    classBuilder.AppendLine("");
                }

                var requiredMemberAttribute = p.GetCustomAttribute<System.Runtime.CompilerServices.RequiredMemberAttribute>();

                var viewModel = !p.PropertyType.IsValueType && !codeLists.Contains(p.Name) /*&& !roles.Contains(p.Name) */? "ViewModel" : string.Empty;

                var actions = BuildPropertyViewModel(p, classBuilder, constructorBuilder, loadBuilder, serializeBuilder, modelBuilder, codeLists, enumLists);

                first = false;

                foreach (var e in actions.insertEnumerationLists)
                    insertEnumerationLists.Add(e.Key, e.Value);
                foreach (var e in actions.insertCodeLists)
                    insertCodeLists.Add(e.Key, e.Value);
            }

            postAction?.Invoke(classBuilder);

            foreach (var codelist in insertCodeLists) {
                codelist.Value.Invoke(classBuilder);
            }
            foreach (var enumerationlist in insertEnumerationLists) {
                enumerationlist.Value.Invoke(classBuilder);
            }
            serializeBuilder.AppendLine("\t\t\t};");
            serializeBuilder.AppendLine("\t\t\treturn System.Text.Json.JsonSerializer.Serialize(instance);");

            constructorBuilder.AppendLine("\t\t}");

            //  Loader
            classBuilder.AppendLine("");
            if (!isTemplate)
                classBuilder.AppendLine($"\t\tpublic void Load({classNamespace}.{code} instance) {{");
            else
                classBuilder.AppendLine($"\t\tpublic override void Load({classNamespace}.{code} instance) {{");
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

            classBuilder.AppendLine($"\t\tpublic override string? ToString() => $\"{name}\";");

            classBuilder.AppendLine("\t}");


            var root = CSharpSyntaxTree.ParseText(classBuilder.ToString().TrimEnd()).GetRoot();

            return classBuilder.ToString();
        }

        private static (IDictionary<string, Action<StringBuilder>> insertEnumerationLists, IDictionary<string, Action<StringBuilder>> insertCodeLists) BuildPropertyViewModel(PropertyInfo p, StringBuilder classBuilder, StringBuilder constructorBuilder, StringBuilder loadBuilder, StringBuilder serializeBuilder, StringBuilder modelBuilder, ICollection<string> codeLists, ICollection<string> enumLists) {
            var insertEnumerationLists = new Dictionary<string, Action<StringBuilder>>();

            var insertCodeLists = new Dictionary<string, Action<StringBuilder>>();

            var requiredMemberAttribute = p.GetCustomAttribute<System.Runtime.CompilerServices.RequiredMemberAttribute>();

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
                    var prop_type = requiredMemberAttribute != null ? $"{p.PropertyType.Name}{viewModel}" : $"{p.PropertyType.Name}{viewModel}?";

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
                    else if (enumLists.Contains(p.Name)) {
                        classBuilder.AppendLine($"\t\t[DomainModel.EnumerationAttribute(nameof({p.PropertyType.Name}List))]");
                        classBuilder.AppendLine("\t\t[Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]");
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
                    else if (enumLists.Contains(p.Name)) {
                        var enumerationValueAttribute = p.GetCustomAttributes<EnumerationValueAttribute>();

                        insertEnumerationLists.Add(p.Name, (s) => {
                            s.AppendLine($"\t\t[Browsable(false)]");

                            var values = string.Join(',', enumerationValueAttribute.Select(e => $"({p.Name}){e.PropertyValue}"));
                            s.AppendLine($"\t\tpublic {p.PropertyType.Name}[] {p.PropertyType.Name}List => [{values}];");
                        });
                    }
                }
            }
            else {
                var prop_name = GetPropertyType(p.PropertyType);

                var prop_type = requiredMemberAttribute != null ? $"{prop_name}{viewModel}" : $"{prop_name}?";
                var prop_postfix = requiredMemberAttribute != null ? "" : " = default";

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
                    else if (enumLists.Contains(prop_name)) {
                        classBuilder.AppendLine($"\t\t[DomainModel.EnumerationAttribute(nameof({prop_name}List))]");
                        classBuilder.AppendLine("\t\t[Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]");
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
                    else if (enumLists.Contains(prop_name)) {
                        var enumerationValueAttribute = p.GetCustomAttributes<EnumerationValueAttribute>();

                        insertEnumerationLists.Add(p.Name, (s) => {
                            s.AppendLine($"\t\t[Browsable(false)]");

                            var values = string.Join(',', enumerationValueAttribute.Select(e => $"({p.Name}){e.PropertyValue}"));
                            s.AppendLine($"\t\tpublic {prop_name}[] {prop_name}List => [{values}];");
                        });
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
                    else if (enumLists.Contains(p.Name)) {
                        classBuilder.AppendLine($"\t\t[DomainModel.EnumerationAttribute(nameof({prop_name}List))]");
                        classBuilder.AppendLine("\t\t[Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]");
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

                    if (enumLists.Contains(prop_name)) {
                        var enumerationValueAttribute = p.GetCustomAttributes<EnumerationValueAttribute>();

                        insertEnumerationLists.Add(p.Name, (s) => {
                            s.AppendLine($"\t\t[Browsable(false)]");

                            var values = string.Join(',', enumerationValueAttribute.Select(e => $"({p.Name}){e.PropertyValue}"));
                            s.AppendLine($"\t\tpublic {prop_name}[] {prop_name}List => [{values}];");
                        });
                    }
                }
            }

            return (insertEnumerationLists, insertCodeLists);
        }

        private static string GetPropertyType(Type p) {
            if (p.IsArray)
                return p.Name;
            if (!S100Framework.Roslyn.Namespace.StartsWith(p.Namespace!.Split('.')[0]) && p.GenericTypeArguments.Any())
                p = p.GenericTypeArguments[0];
            //if(p.GenericTypeArguments.Any())
            //    p = p.GenericTypeArguments[0];
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
                            builder.AppendLine($"\t\t\t\t\t{p.Name} = {BuildConstructor(p.PropertyType)},");
                    }
                }
                builder.AppendLine("}");
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

namespace S100Framework.DomainModel
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class EnumerationAttribute : System.Attribute
    {
        private string _propertyName;
        public string PropertyName => _propertyName;

        public EnumerationAttribute(string propertyName) {
            _propertyName = propertyName;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class EnumerationValueAttribute : System.Attribute
    {
        private int _propertyValue;
        public int PropertyValue => _propertyValue;

        public EnumerationValueAttribute(int propertyValue) {
            _propertyValue = propertyValue;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class CodeListAttribute : System.Attribute
    {
        private string _propertyName;
        public string PropertyName => _propertyName;

        public CodeListAttribute(string propertyName) {
            _propertyName = propertyName;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class RoleAttribute : System.Attribute
    {
        private string _roleName;
        public string RoleName => _roleName;

        public RoleAttribute(string roleName) {
            _roleName = roleName;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredAttribute : System.Attribute
    {
    }

    [System.SerializableAttribute()]
    public abstract class Node
    {
        public virtual string Code => string.Empty;
    }

    [System.SerializableAttribute()]
    public abstract class InformationNode : Node
    {
    }

    [System.SerializableAttribute()]
    public abstract class FeatureNode : Node
    {
    }

    [System.SerializableAttribute()]
    public class RefId
    {
        public required string? Value { get; set; }
        public required string? Type { get; set; }
        public required string Role { get; set; }
    }

    [System.SerializableAttribute()]
    public abstract class Association
    {
        //public abstract string Code { get; }
    }


    [System.SerializableAttribute()]
    public abstract class InformationAssociation : Association
    {
    }

    [System.SerializableAttribute()]
    public abstract class FeatureAssociation : Association
    {
    }

    public class informationBinding
    {
        public string roleType { get; set; } = string.Empty;
        public string association { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;

        public string? associationId { get; set; } = null;
        public string? informationId { get; set; } = null;
        public string? foreignId { get; set; } = null;
    }

    public class informationBindingDefinition
    {
        public roleType roleType { get; set; }
        public int lower { get; set; }
        public int? upper { get; set; }
        public bool infinite => !upper.HasValue;
        public string association { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
        public string[] informationTypes { get; set; } = [];
        public override string ToString() => $"{association}, {role}";
    }

    public class featureBinding
    {
        public string roleType { get; set; } = string.Empty;
        public string association { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;

        public string? associationId { get; set; } = null;
        public string? featureId { get; set; } = null;
        public string? foreignId { get; set; } = null;
    }

    public class featureBindingDefinition
    {
        public roleType roleType { get; set; }
        public int lower { get; set; }
        public int? upper { get; set; }
        public bool infinite => !upper.HasValue;
        public string association { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
        public string[] featureTypes { get; set; } = [];
        public override string ToString() => $"{association}, {role}";
    }

    public enum roleType
    {
        association,
        aggregation,
        composition,
    }
}

namespace System.Reflection.Emit
{
    public static class Extension
    {
        public static void BuildAttributeBinding(this TypeBuilder typeBuilder, XElement attributeBinding, string scope_S100, XmlNamespaceManager xmlNamespaceManager, IDictionary<string, Type> dictionaryTypes, IList<string> dictionaryTypesComplex) {
            var referenceCode = attributeBinding.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!;

            var permittedValues = attributeBinding.XPathSelectElement("S100FC:permittedValues", xmlNamespaceManager);

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

            var propertyBuilder = S100Framework.Roslyn.CreateProperty(typeBuilder, referenceCode, referenceType);

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

            if (permittedValues is not null) {
                foreach (var v in permittedValues.XPathSelectElements("S100FC:value", xmlNamespaceManager).Select(e => e.Value).ToList()) {
                    var constructorInfo = typeof(EnumerationValueAttribute).GetConstructors().First();

                    var enumerationValueAttributeBuilder = new CustomAttributeBuilder(constructorInfo, new object[1] { int.Parse(v) });
                    propertyBuilder.SetCustomAttribute(enumerationValueAttributeBuilder);
                }
            }
        }

    }
}