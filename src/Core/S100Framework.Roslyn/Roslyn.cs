using System.Reflection;

using System.Reflection.Emit;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;


namespace S100Framework
{
    public static class Roslyn
    {
        public const string Namespace = "S100Framework.Attributes";

        public static FeatureCatalogue CreateAssembly(XDocument productSpecification) {
            var assembly = new AssemblyName(Roslyn.Namespace);
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assembly, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");

            var navigator = productSpecification.CreateNavigator();
            navigator.MoveToFollowing(XPathNodeType.Element);
            var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var e in scopes)
                xmlNamespaceManager.AddNamespace(e.Key, e.Value);

            var scope_S100 = scopes["S100FC"];

            var dictionaryTypes = new Dictionary<string, Type>();
            var dictionaryTypesComplex = new List<string>();

            var productId = productSpecification.XPathSelectElement("//S100FC:productId", xmlNamespaceManager)!.Value;
            var versionNumber = productSpecification.XPathSelectElement("//S100FC:versionNumber", xmlNamespaceManager)!.Value;

            var featureCatalogue = new FeatureCatalogue(productId, versionNumber);

            //  S100_FC_SimpleAttributes
            {
                var enumTypes = new Dictionary<string, Type>();

                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_SimpleAttribute", xmlNamespaceManager);

                foreach (var e in elements) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    var getEnumType = (XElement simpleAttribute) => {
                        if (enumTypes.ContainsKey(code))
                            return enumTypes[code];

                        var enumBuilder = moduleBuilder.DefineEnum(code, TypeAttributes.Public, typeof(int));

                        foreach (var listedValue in simpleAttribute.Element(XName.Get("listedValues", scope_S100))!.Elements()) {
                            var listedValueLabel = listedValue.Element(XName.Get("label", scope_S100))!.Value!;
                            var listedValueDefinition = listedValue.Element(XName.Get("definition", scope_S100))!.Value!;
                            var listedValueCode = listedValue.Element(XName.Get("code", scope_S100))!.Value!;

                            var literalName = listedValueLabel;
                            literalName = literalName.Replace(" ", "_");    //  remove spaces
                            literalName = literalName.Replace("/", "_and_");    //  remove /
                            literalName = literalName.Replace(".", "_");    //  remove .
                            literalName = literalName.Replace(",", "_");    //  remove ,

                            enumBuilder.DefineLiteral(literalName, int.Parse(listedValueCode));
                        }
                        var enumType = enumBuilder.CreateType();
                        enumTypes.Add(code, enumType);
                        return enumType;
                    };

                    var getEnumListType = (XElement simpleAttribute) => {
                        var enumType = enumTypes[code];

                        var listType = typeof(List<>).MakeGenericType(enumType);
                        return listType;
                    };

                    var valueType = e.Element(XName.Get("valueType", scope_S100))!.Value switch {
                        "boolean" => typeof(bool),
                        "enumeration" => getEnumType(e),
                        "real" => typeof(decimal),
                        "text" => typeof(string),
                        "S100_TruncatedDate" => typeof(DateOnly),
                        "date" => typeof(DateTime),
                        "dateTime" => typeof(DateTime),
                        "time" => typeof(TimeOnly),
                        "integer" => typeof(int),
                        "URN" => typeof(string),
                        "URL" => typeof(string),
                        _ => throw new InvalidDataException(),
                    };

                    dictionaryTypes.Add(code, valueType);

                    var valueTypeGeneric = e.Element(XName.Get("valueType", scope_S100))!.Value switch {
                        "boolean" => typeof(bool?),
                        "enumeration" => getEnumType(e),    //TODO: Should be nullable
                        "real" => typeof(decimal?),
                        "text" => typeof(string),
                        "S100_TruncatedDate" => typeof(DateOnly?),
                        "date" => typeof(DateTime?),
                        "dateTime" => typeof(DateTime?),
                        "time" => typeof(TimeOnly?),
                        "integer" => typeof(int?),
                        "URN" => typeof(string),
                        "URL" => typeof(string),
                        _ => throw new InvalidDataException(),
                    };

                    dictionaryTypes.Add($"{code}?", valueTypeGeneric);  //  Add the entry even through it doesn't make sense (string?), since it simplifies later on!


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
                        "URL" => typeof(List<string>),
                        _ => throw new InvalidDataException(),
                    };
                    if (valueTypeList != null)
                        dictionaryTypes.Add($"List<{code}>", valueTypeList);
                }
            }

            //  S100_FC_ComplexAttribute
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_ComplexAttribute", xmlNamespaceManager);

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

                        //if(code.Equals("featureName"))
                        //    System.Diagnostics.Debugger.Break();

                        var complexTypeBuilder = S100Framework.Roslyn.GetTypeBuilder(moduleBuilder, code);

                        foreach (var attributeBinding in e.XPathSelectElements("S100FC:subAttributeBinding", xmlNamespaceManager)) {
                            var referenceCode = attributeBinding.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!;

                            var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                            var upper = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;

                            var isArray = false;
                            if (upper.Attribute(XName.Get("infinite")) != default && upper.Attribute(XName.Get("infinite"))!.Value.Equals("true") || int.Parse(upper!.Value) > 1) {
                                isArray = true;
                            }

                            var referenceType = isArray ? dictionaryTypes[$"List<{referenceCode}>"] : dictionaryTypes[referenceCode];

                            if (!isArray && lower == 0 && !dictionaryTypesComplex.Contains(referenceCode)) {
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
                        }

                        var complexType = complexTypeBuilder.CreateType();

                        dictionaryTypesComplex.Add(code);
                        dictionaryTypes.Add(code, complexType);

                        var listType = typeof(List<>).MakeGenericType(complexType);
                        dictionaryTypes.Add($"List<{code}>", listType);
                    }
                } while (notFinished);
            }

            //  S100_FC_InformationType
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationType", xmlNamespaceManager);

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

                        var informationTypeBuilder = S100Framework.Roslyn.GetTypeBuilder(moduleBuilder, code);

                        foreach (var attributeBinding in e.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                            var referenceCode = attributeBinding.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!;

                            var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                            var upper = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;

                            var isArray = false;
                            if (upper.Attribute(XName.Get("infinite")) != default && upper.Attribute(XName.Get("infinite"))!.Value.Equals("true") || int.Parse(upper!.Value) > 1) {
                                isArray = true;
                            }

                            var referenceType = isArray ? dictionaryTypes[$"List<{referenceCode}>"] : dictionaryTypes[referenceCode];

                            if (!isArray && lower == 0 && !dictionaryTypesComplex.Contains(referenceCode)) {
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

                        dictionaryTypes.Add(code, informationType);

                        featureCatalogue.InformationTypes = featureCatalogue.InformationTypes.Add(new InformationTypeId(code, name));

                        var listType = typeof(List<>).MakeGenericType(informationType);
                        dictionaryTypes.Add($"List<{code}>", listType);
                    }
                } while (notFinished);
            }

            //  S100_FC_FeatureType
            {
                var elements = productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureType", xmlNamespaceManager);

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

                        var attributes = TypeAttributes.Public | TypeAttributes.Class | /*TypeAttributes.AutoClass |*/ TypeAttributes.AutoLayout;
                        if (bool.Parse(e.Attribute("isAbstract")!.Value))
                            attributes |= TypeAttributes.Abstract;

                        var superType = e.Elements(XName.Get("superType", scope_S100)).FirstOrDefault();

                        TypeBuilder featureTypeBuilder;

                        if (superType != null) {
                            if (!dictionaryTypes.ContainsKey(superType.Value))
                                continue;
                            featureTypeBuilder = moduleBuilder.DefineType($"{S100Framework.Roslyn.Namespace}.{code}", attributes, dictionaryTypes[superType.Value]);
                        }
                        else
                            featureTypeBuilder = moduleBuilder.DefineType($"{S100Framework.Roslyn.Namespace}.{code}", attributes);

                        //var featureTypeBuilder = S100Framework.Roslyn.GetTypeBuilder(moduleBuilder, code);

                        foreach (var attributeBinding in e.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                            var referenceCode = attributeBinding.Element(XName.Get("attribute", scope_S100))!.Attribute("ref")!.Value!;

                            var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                            var upper = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;

                            var isArray = false;
                            if (upper.Attribute(XName.Get("infinite")) != default && upper.Attribute(XName.Get("infinite"))!.Value.Equals("true") || int.Parse(upper!.Value) > 1) {
                                isArray = true;
                            }

                            var referenceType = isArray ? dictionaryTypes[$"List<{referenceCode}>"] : dictionaryTypes[referenceCode];

                            if (!isArray && lower == 0 && !dictionaryTypesComplex.Contains(referenceCode)) {
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

                        dictionaryTypes.Add(code, featureType);

                        if (!bool.Parse(e.Attribute("isAbstract")!.Value))
                            featureCatalogue.FeatureTypes = featureCatalogue.FeatureTypes.Add(new FeatureTypeId(code, name));
                    }
                } while (notFinished);
            }

            featureCatalogue.Assembly = moduleBuilder.Assembly;
            return featureCatalogue;
        }


        public record FieldDescription(string FieldName, Type FieldType);

        public static object? CreateInstance(FieldDescription[] fieldDescriptions, string namespaceName, string className) {
            var builder = GetTypeBuilder(GetModuleBuilder(namespaceName), className);

            var constructor = builder.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);

            // NOTE: assuming your list contains Field objects with fields FieldName(string) and FieldType(Type)
            foreach (var field in fieldDescriptions)
                CreateProperty(builder, field.FieldName, field.FieldType);

            var objectType = builder.CreateType();
            return Activator.CreateInstance(objectType);
        }

        public static ModuleBuilder GetModuleBuilder(string namespaceName) {
            var assembly = new AssemblyName(namespaceName);
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assembly, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
            return moduleBuilder;
        }

        public static TypeBuilder GetTypeBuilder(ModuleBuilder moduleBuilder, string className) {
            var typeSignature = $"{moduleBuilder.Assembly.GetName().Name}.{className}";
            var typeBuilder = moduleBuilder.DefineType(typeSignature,
                    TypeAttributes.Public |
                    TypeAttributes.Class |
                    //TypeAttributes.AutoClass |
                    TypeAttributes.AnsiClass |
                    TypeAttributes.BeforeFieldInit |
                    TypeAttributes.AutoLayout,
                    null);
            return typeBuilder;
        }

        public static PropertyBuilder CreateProperty(TypeBuilder typeBuilder, string propertyName, Type propertyType) {
            FieldBuilder fieldBuilder = typeBuilder.DefineField($"<{propertyName}>k__BackingField", propertyType, FieldAttributes.Private);


            PropertyBuilder propertyBuilder;
            //if (propertyType.IsValueType) {
            //    propertyBuilder = typeBuilder.DefineProperty(propertyName, PropertyAttributes.HasDefault, typeof(Nullable<>).MakeGenericType(propertyType), null);
            //}
            //else 
            {
                propertyBuilder = typeBuilder.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);
            }

            MethodBuilder getPropMthdBldr =
                typeBuilder.DefineMethod("get_" + propertyName,
                MethodAttributes.Public |
                MethodAttributes.SpecialName |
                MethodAttributes.HideBySig,
                propertyType, Type.EmptyTypes);

            ILGenerator getIl = getPropMthdBldr.GetILGenerator();

            getIl.Emit(OpCodes.Ldarg_0);
            getIl.Emit(OpCodes.Ldfld, fieldBuilder);
            getIl.Emit(OpCodes.Ret);

            MethodBuilder setPropMthdBldr =
                typeBuilder.DefineMethod("set_" + propertyName,
                  MethodAttributes.Public |
                  MethodAttributes.SpecialName |
                  MethodAttributes.HideBySig,
                  null, new[] { propertyType });

            ILGenerator setIl = setPropMthdBldr.GetILGenerator();
            Label modifyProperty = setIl.DefineLabel();
            Label exitSet = setIl.DefineLabel();

            setIl.MarkLabel(modifyProperty);
            setIl.Emit(OpCodes.Ldarg_0);
            setIl.Emit(OpCodes.Ldarg_1);
            setIl.Emit(OpCodes.Stfld, fieldBuilder);

            setIl.Emit(OpCodes.Nop);
            setIl.MarkLabel(exitSet);
            setIl.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getPropMthdBldr);
            propertyBuilder.SetSetMethod(setPropMthdBldr);
            return propertyBuilder;
        }
    }
}
