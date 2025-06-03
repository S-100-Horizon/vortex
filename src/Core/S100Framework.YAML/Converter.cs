using S100Framework.Catalogues;
using S100Framework.DomainModel;
using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

using Scalar = YamlDotNet.Core.Events.Scalar;

namespace S100Framework.YAML
{
    public static class Converter
    {
        public static string Serialize(object dataset) => Serializer.Serialize(dataset);
        public static T Deserialize<T>(string yaml) => Deserializer.Deserialize<T>(yaml);

        public static bool IsDefault(object? node) {
            if (node is not Node) return true;

            //var type = node.GetType();
            //var properties = type.GetProperties();

            //foreach (var property in properties) {
            //    if (property.GetCustomAttribute<JsonIgnoreAttribute>(true) != null)   // Include JsonIgnore to YAML serialization
            //        continue;

            //    if ((property.GetGetMethod(true)?.IsStatic ?? property.GetSetMethod(true)?.IsStatic) == true)
            //        continue;

            //    //if (property.GetValue(node) == null)
            //    //    continue;


            //    return false;
            //}

            //return true;

            var propertyId = 1;

            var flattenedAttributes = FlattenAttributesRecursively(node, ref propertyId);

            return flattenedAttributes.Count == 0;
        }
        private record YamlAttributeItem(string Name, string? Value, int? Id, int? Parent);
        private readonly static FeatureCatalogue featureCatalogue = S100Framework.Catalogues.FeatureCatalogue.Catalogues.Single(e => e.ProductID.Equals("S-101"));

        private static readonly ISerializer Serializer = new SerializerBuilder()
           .WithNamingConvention(PascalCaseNamingConvention.Instance)
           .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull)
           .WithIndentedSequences()
           .DisableAliases()
           .WithTypeConverter(new NodeConverter())                  // Custom type converter for objects of Node
           .WithTypeConverter(new BooleanAsNumberConverter())       // Custom type converter for booleans
           .Build();

        private static readonly IDeserializer Deserializer = new DeserializerBuilder()
           .WithNamingConvention(PascalCaseNamingConvention.Instance)
           .WithTypeConverter(new FeatureNodeDeserializer())
           .Build();

        private static List<YamlAttributeItem> FlattenAttributesRecursively(object obj, ref int propertyId, int? parentId = null) {
            var attributes = new List<YamlAttributeItem>();

            var type = obj.GetType();
            var properties = type.GetProperties();

            foreach (var property in properties) {
                if (property.GetCustomAttribute<JsonIgnoreAttribute>(true) != null)   // Include JsonIgnore to YAML serialization
                    continue;

                //if (property.GetAccessors(false).Any(x => x.IsStatic))                // Do not serialize static properties
                //    continue;

                if ((property.GetGetMethod(true)?.IsStatic ?? property.GetSetMethod(true)?.IsStatic) == true)
                    continue;

                var propertyValue = property.GetValue(obj, null);
                try {
                    attributes.BuildAttributeItem(propertyValue, property.Name, property.PropertyType, ref propertyId, parentId);
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
            return attributes;
        }

        private static void BuildAttributeItem(this List<YamlAttributeItem> attributes, object? propertyValue, string propertyName, Type propertyType, ref int propertyId, int? parentId) {
            if (propertyValue == null)
                return;

            var typed = Nullable.GetUnderlyingType(propertyType) ?? propertyType;

            switch (typed) {
                // Ensure strings are without newlines
                case Type t when t == typeof(string):
                    var stringval = propertyValue?.ToString();
                    stringval = stringval?.Replace(System.Environment.NewLine, " ");

                    attributes.Add(new(propertyName, stringval, null, parentId));
                    break;

                // Ensure booleans as integers
                case Type t when t == typeof(bool):
                    var booleanValue = propertyValue is bool b ? (b ? "1" : "0") : null;

                    attributes.Add(new(propertyName, booleanValue, null, parentId));
                    break;

                // Ensure valid DateOnly objects
                case Type t when t == typeof(DateOnly):
                    var dateString = propertyValue.ToString();

                    if (!DateOnly.TryParse(propertyValue.ToString(), out _))
                        throw new InvalidOperationException($"String could not be parsed into DateOnly: {dateString} for property: {propertyName}");

                    attributes.Add(new(propertyName, dateString, null, parentId));

                    break;

                // Ensure decimals with point 2.0
                case Type t when t == typeof(decimal):
                    var parsed = (decimal?)propertyValue!;

                    attributes.Add(new(propertyName, parsed?.ToString(CultureInfo.InvariantCulture), null, parentId));
                    break;

                // Ensure enum value comes 'EnumMemberAttribute' and no enums are sat to 0, -1 or "unknown".
                case Type t when t.IsEnum:
                    var enumvalue = ToEnumString(propertyValue);
                    if (enumvalue == null)
                        break;

                    enumvalue = enumvalue == "Unknown" ? null : enumvalue;

                    attributes.Add(new(propertyName, enumvalue, null, parentId));
                    break;

                case Type t when t.IsPrimitive:
                    attributes.Add(new(propertyName, propertyValue?.ToString(), null, parentId));
                    break;

                case Type t when typeof(IEnumerable).IsAssignableFrom(t):
                    if (propertyValue == null) break;
                    if (propertyValue is not IEnumerable collection) break;

                    foreach (var item in collection!) {
                        var type = item.GetType();
                        type = Nullable.GetUnderlyingType(type) ?? type;

                        attributes.BuildAttributeItem(item, propertyName, type, ref propertyId, parentId);
                    }

                    break;

                case Type t when t.IsClass:
                    if (propertyValue == null) break;

                    // Add root object with ID and value = null
                    attributes.Add(new(t.Name, null, propertyId, parentId));

                    parentId = propertyId;
                    propertyId++;

                    var properties = t.GetProperties();

                    foreach (var propInfo in properties) {
                        var propVal = propInfo.GetValue(propertyValue);
                        var objectName = propInfo.Name;

                        var propType = propInfo.PropertyType;
                        propType = Nullable.GetUnderlyingType(propType) ?? propType;

                        attributes.BuildAttributeItem(propVal, objectName, propType, ref propertyId, parentId);
                    }

                    break;

                case Type t when t.IsValueType:
                    attributes.Add(new(propertyName, propertyValue?.ToString(), null, parentId));
                    break;

                default:
                    throw new ArgumentException("Invalid property type provided: {propertyType}", nameof(propertyType));
            }
        }

        public static string? ToEnumString(object? enumValue) {
            if (enumValue == null) return null;
            if (enumValue.ToString() == "0") return null;

            return $"{(int)enumValue!}";

            var enumType = enumValue.GetType();

            if (!enumType.IsEnum) throw new ArgumentException($"Provided value is not an enum: {enumValue}");

            var name = Enum.GetName(enumType, enumValue!);

            if (name == null) throw new ArgumentException($"Invalid enum value: {enumValue}");
            return name;
            var field = enumType.GetField(name);
            var enumMemberAttribute = field?.GetCustomAttribute<EnumMemberAttribute>();

            return enumMemberAttribute?.Value ?? name; // Fallback to the enum name
        }

        private class FeatureNodeDeserializer : IYamlTypeConverter
        {
            public bool Accepts(Type type) => type == typeof(Dataset);

            public object ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer) {
                var dataset = new Dataset();

                if (parser.Current is not MappingStart)
                    throw new InvalidDataException("Invalid YAML content.");

                parser.MoveNext(); // move on from the map start

                // Should only iterate through the root level
                do {
                    //... Nessecary?
                    if (parser.Current is not Scalar) {
                        parser.MoveNext();
                        continue;
                    }

                    GetKeyValueScalar(parser, out string key, out string? value);

                    // if this is null, its the beginning of a list
                    if (!string.IsNullOrEmpty(value)) {
                        AddRootAttributes(key, value, dataset);
                    }
                    else if (key == "Metadata") {
                        AddMetadata(parser, dataset);
                    }
                    else {
                        AddCollection(parser, key, dataset);
                    }

                    // always move at the end. Should only reach this after each root collection or root attribute
                    parser.MoveNext();
                } while (parser.Current is not DocumentEnd);


                return dataset;
            }

            public void AddMetadata(IParser parser, Dataset dataset) {
                var metadata = new Metadata();
                AddMetadataAttribute(parser, metadata);
                dataset.Metadata = metadata;
            }

            public void WriteYaml(IEmitter emitter, object? value, Type type, ObjectSerializer serializer) => throw new NotImplementedException();

            private void GetKeyValueScalar(IParser parser, out string key, out string? value) {
                parser.Accept(out Scalar scalarKey);
                key = scalarKey!.Value;

                parser.MoveNext();

                if (parser.Accept(out Scalar scalarValue))
                    value = scalarValue.Value;
                else
                    value = null;
            }

            // To-do: handle all types of collections based on collectionName
            private void AddCollection(IParser parser, string collectionName, Dataset dataset) {
                if (parser.Current is SequenceStart or MappingStart)
                    parser.MoveNext(); // skip the sequence/mapping start

                do {
                    switch (collectionName) {
                        case "Points":
                            var point = AddPoint(parser);
                            dataset.AddPoint(point);
                            break;
                        case "Curves":
                            var curve = AddCurve(parser);
                            dataset.AddCurve(curve);
                            break;
                        case "CompositeCurves":
                            var compCurve = AddCompositeCurve(parser);
                            dataset.AddCompositeCurve(compCurve);
                            break;
                        case "Depths":
                            var depth = AddDepth(parser);
                            dataset.AddPointSet(depth);
                            break;
                        case "Surfaces":
                            //ReadSurfaceCollection(parser, key, dataset);
                            break;
                        case "Features":
                            //var item = new Feature();

                            var item = AddFeatureAttribute(parser);
                            dataset.AddFeature(item);
                            break;
                        default:
                            break;
                            //throw new Exception("Invalid or unknown collection detected!" + collectionName);
                    }

                    parser.MoveNext();
                } while (parser.Current is not SequenceEnd or SequenceStart);

            }

            private static void AddRootAttributes(string key, string value, Dataset dataset) {
                switch (key) {
                    case "CellName":
                        dataset.CellName = value;
                        break;
                    case "Comment":
                        dataset.Comment = value;
                        break;
                    case "Edition":
                        dataset.Edition = uint.Parse(value);
                        break;
                    case "encver":
                        dataset.ENCVer = value;
                        break;
                    case "FCVer":
                        dataset.FCVer = value;
                        break;
                }
            }

            private void AddMetadataAttribute(IParser parser, Metadata metadata) {
                // Only iterate on the Metadata object at root level
                while (parser.Current is not MappingEnd) {
                    if (parser.Current is Scalar scalarKey) {

                        GetKeyValueScalar(parser, out string key, out string? value);
                        switch (key) {
                            case "OrganisationName":
                                metadata.OrganisationName = value;
                                break;
                            case "City":
                                metadata.City = value;
                                break;
                            case "AdministrativeArea":
                                metadata.AdministrativeArea = value;
                                break;
                            case "ElectronicMailAddress":
                                metadata.ElectronicMailAddress = value;
                                break;
                            case "Country":
                                metadata.Country = value;
                                break;
                            case "PrivateKey":
                                metadata.PrivateKey = value;
                                break;
                            case "Certificate":
                                metadata.Certificate = value;
                                break;
                            case "Producer":
                                metadata.Producer = value;
                                break;
                            case "ProducerCode":
                                metadata.ProducerCode = value;
                                break;
                        }
                    }

                    parser.MoveNext();
                }
            }

            private static Point AddPoint(IParser parser) {
                string? name = null;
                double? x = null, y = null;

                while (parser.Current is not MappingEnd) {
                    if (parser.Current is Scalar scalarKey) {
                        var key = scalarKey.Value;

                        // Check next element
                        parser.MoveNext();

                        parser.Accept(out Scalar scalarValue);

                        var value = scalarValue?.Value!;
                        switch (key) {
                            case "Name":
                                name = value;
                                break;
                            case "Location":
                                var coords = value.Split(",").Select(e => double.Parse(e, CultureInfo.InvariantCulture)).ToArray();
                                x = coords[0];
                                y = coords[1];
                                break;
                        }
                    }

                    parser.MoveNext();
                }

                if (x == null || y == null)
                    throw new InvalidOperationException("Missing coordinates for Point");

                return new Point(x.Value, y.Value) {
                    Name = name
                };
            }

            private static PointSet AddDepth(IParser parser) {
                string? name = null;
                List<Coordinate> coordinates = [];
                double[] depths = [];

                while (parser.Current is not MappingEnd) {
                    if (parser.Current is Scalar scalarKey) {
                        var key = scalarKey.Value;

                        // Check next element
                        parser.MoveNext();

                        parser.Accept(out Scalar scalarValue);

                        var value = scalarValue?.Value!;
                        switch (key) {
                            case "Name":
                                name = value;
                                break;
                            case "Location":
                                var coords = value.Split(",");

                                for (int i = 0; i < coords.Length; i += 2) {
                                    _ = Double.TryParse(coords[i], CultureInfo.InvariantCulture, out double x);
                                    _ = Double.TryParse(coords[i + 1], CultureInfo.InvariantCulture, out double y);

                                    coordinates.Add(new(x, y));
                                }

                                break;
                            case "Z":
                                var depthsArr = value.Split(",").Select(e => Double.Parse(e, CultureInfo.InvariantCulture));


                                depths = [.. depthsArr];


                                break;
                        }
                    }

                    parser.MoveNext();
                }

                if (name == null || coordinates.Count == 0 || depths.Length == 0)
                    throw new InvalidOperationException("Missing name, coordinates or depth for CompositeCurve");

                return new PointSet([.. coordinates], depths) {
                    Name = name
                };
            }

            private static CompositeCurve AddCompositeCurve(IParser parser) {
                string? name = null;
                string? components = null;

                while (parser.Current is not MappingEnd) {
                    if (parser.Current is Scalar scalarKey) {
                        var key = scalarKey.Value;

                        // Check next element
                        parser.MoveNext();

                        parser.Accept(out Scalar scalarValue);

                        var value = scalarValue?.Value!;
                        switch (key) {
                            case "Name":
                                name = value;
                                break;
                            case "Components":
                                components = value;

                                break;
                        }
                    }

                    parser.MoveNext();
                }

                if (name == null || components == null)
                    throw new InvalidOperationException("Missing name or components for CompositeCurve");

                return new CompositeCurve(components) {
                    Name = name
                };
            }

            private static Curve AddCurve(IParser parser) {
                string? name = null;
                string? start = null;
                string? end = null;
                List<Coordinate> vertices = [];

                while (parser.Current is not MappingEnd) {
                    if (parser.Current is Scalar scalarKey) {
                        var key = scalarKey.Value;

                        // Check next element
                        parser.MoveNext();

                        parser.Accept(out Scalar scalarValue);

                        var value = scalarValue?.Value!;
                        switch (key) {
                            case "Name":
                                name = value;
                                break;
                            case "Start":
                                start = value;
                                break;
                            case "End":
                                end = value;
                                break;
                            case "Vertices":
                                var coords = value.Split(",");

                                for (int i = 0; i < coords.Length; i += 2) {
                                    _ = Double.TryParse(coords[i], CultureInfo.InvariantCulture, out double x);
                                    _ = Double.TryParse(coords[i + 1], CultureInfo.InvariantCulture, out double y);

                                    vertices.Add(new(x, y));
                                }
                                break;
                        }
                    }

                    parser.MoveNext();
                }

                if (name == null || vertices.Count == 0)
                    throw new InvalidOperationException("Missing name or vertices for Curve");

                // Add start and endpoint?
                return new Curve([.. vertices]) {
                    Name = name
                };

            }

            private Feature AddFeatureAttribute(IParser parser) {
                var feature = new Feature();
                while (parser.Current is not MappingEnd) {
                    if (parser.Current is Scalar scalarKey) {
                        var key = scalarKey.Value;

                        // Check next element
                        parser.MoveNext();

                        parser.Accept(out Scalar scalarValue);

                        var value = scalarValue?.Value;
                        switch (key) {
                            case "Name":
                                feature.Name = value;
                                break;
                            case "Prim":
                                feature.Prim = Enum.Parse<Primitive>(value);
                                break;
                            case "Foid":
                                feature.Foid = value;
                                break;
                            case "Geometry":
                                feature.Geometry = value;
                                break;
                            case "Attributes":
                                // Keep on parsing 
                                parser.MoveNext();  // SequenceStart
                                parser.MoveNext();  // MappingStart

                                var attributeList = BuildAttributeList(parser);

                                var featureNode = BuildObject(attributeList, feature.Name);

                                feature.Attributes = featureNode;

                                break;
                            case "FeatureAssociation":
                                // To-do
                                break;
                            case "Association":
                                // To-do
                                break;
                        }
                    }

                    parser.MoveNext();
                }
                return feature;
            }

            private List<YamlAttributeItem> BuildAttributeList(IParser parser) {
                var attributes = new List<YamlAttributeItem>();

                string itemName = "";
                string? itemValue = null;
                int? itemId = null;
                int? itemParent = null;

                while (parser.Current is not SequenceEnd) {
                    if (parser.Current is Scalar) {
                        GetKeyValueScalar(parser, out var key, out var value);

                        if (key == "Name")
                            itemName = value;
                        else if (key == "Value")
                            itemValue = value;
                        else if (key == "id")
                            itemId = Int32.Parse(value);
                        else if (key == "parent")
                            itemParent = Int32.Parse(value);

                    }
                    else if (parser.Current is MappingStart) {
                        // Probably do nothing? - Keep on keeping on
                    }
                    else if (parser.Current is MappingEnd) {
                        attributes.Add(new(itemName, itemValue, itemId, itemParent));
                        itemName = "";
                        itemValue = null;
                        itemId = null;
                        itemParent = null;
                    }

                    parser.MoveNext();
                }

                return attributes;

            }

            private static FeatureNode BuildObject(List<YamlAttributeItem> attributes, string type) {
                var featureType = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace("S101", "FeatureTypes")}.{type}", true) ?? default;
                var featureNode = Activator.CreateInstance(featureType);

                foreach (var item in attributes) {
                    Type? typed = null;

                    // Determine propetyName
                    if (item.Parent.HasValue) {
                        // Get parent attribute item
                        var parentName = item.Parent.HasValue ? attributes.First(e => e.Id == item.Parent).Name : item.Name;

                        // Determine PropertyType of parent
                        var propertyType = featureType.GetProperty(parentName).PropertyType;

                        // Get type of parent. Example List<string>
                        var elementType = propertyType.IsGenericType ? propertyType.GetGenericArguments()[0] : typeof(object);

                        // Get the string property - string
                        var attributeType = elementType.GetProperty(item.Name)?.PropertyType;

                        // Handle nullable
                        typed = Nullable.GetUnderlyingType(attributeType!) ?? attributeType;
                    }
                    else {
                        // Determine type
                        var propertyType = featureType.GetProperty(item.Name)?.PropertyType;

                        if (propertyType == null)
                            continue;

                        typed = Nullable.GetUnderlyingType(propertyType!) ?? propertyType;
                    }


                    switch (typed) {
                        // Strings need no conversion
                        case Type t when t == typeof(string): {

                                if (item.Parent.HasValue) {
                                    var parent = attributes.First(e => e.Parent == item.Id);

                                    var parentProp = featureType.GetProperty(parent.Name);
                                    var list = (IList)parentProp.GetValue(featureNode);

                                    if (list != null && item.Parent - 1 < list.Count) // item.ParentIndex = index you want
                                    {
                                        var element = list[item.Parent.Value - 1];
                                        var subProp = element.GetType().GetProperty(item.Name);

                                        subProp?.SetValue(element, Convert.ChangeType(item.Value, subProp.PropertyType));
                                    }
                                }
                                else {
                                    featureType.GetProperty(item.Name)?.SetValue(featureNode, item.Value);
                                }

                                break;
                            }

                        // Convert to bool
                        case Type t when t == typeof(bool): {
                                var booleanValue = Convert.ToInt32(item.Value) == 1;

                                featureType.GetProperty(item.Name)?.SetValue(featureNode, booleanValue);
                            }
                            break;

                        // Convert to decimal value
                        case Type t when t == typeof(decimal): {
                                var decimalValue = Convert.ChangeType(item.Value, typeof(decimal));
                                featureType.GetProperty(item.Name)?.SetValue(featureNode, decimalValue);

                                break;
                            }

                        // Ensure enum value comes 'EnumMemberAttribute' and no enums are sat to 0, -1 or "unknown".
                        case Type t when t.IsEnum: {
                                if (item.Parent.HasValue) {
                                    var parent = attributes.First(e => e.Id.HasValue && e.Id == item.Parent);

                                    var parentProp = featureType.GetProperty(parent.Name);
                                    var list = (IList)parentProp.GetValue(featureNode);

                                    var element = list[item.Parent.Value - 1];

                                    var subProp = element.GetType().GetProperty(item.Name);

                                    var enumValue = Enum.Parse(t, item.Value);

                                    //list.Add(enumValue);
                                    subProp?.SetValue(element, enumValue);
                                }
                                else {
                                    var enumValue = Enum.Parse(t, item.Value);
                                    featureType.GetProperty(item.Name)?.SetValue(featureNode, enumValue);
                                }

                                break;
                            }

                        case Type t when t.IsPrimitive: {
                                // Handle parentId??
                                var primValue = Convert.ChangeType(item.Value, t);
                                featureType.GetProperty(item.Name)?.SetValue(featureNode, primValue);
                                break;
                            }

                        case Type t when typeof(IEnumerable).IsAssignableFrom(t): {
                                var elementType = t.IsGenericType ? t.GetGenericArguments()[0] : typeof(object);

                                // Ensure we dont create new list each time!
                                var list = GetOrCreateListInstance(featureNode, featureType.GetProperty(item.Name));

                                // Yet another switch. Ensure we add correct type of value to the list.
                                switch (elementType) {
                                    case Type et when et == typeof(string): {
                                            list.Add(item.Value);

                                            break;
                                        }

                                    // Convert to bool
                                    case Type et when et == typeof(bool): {
                                            var booleanValue = Convert.ToInt32(item.Value) == 1;

                                            list.Add(booleanValue);
                                        }
                                        break;

                                    // Convert to decimal value
                                    case Type et when et == typeof(decimal): {
                                            var decimalValue = Convert.ChangeType(item.Value, typeof(decimal));

                                            list.Add(decimalValue);
                                            break;
                                        }
                                    case Type et when et.IsEnum: {
                                            var enumValue = Enum.Parse(et, item.Value);

                                            list.Add(enumValue);
                                            break;
                                        }

                                    case Type et when et.IsPrimitive: {
                                            var primValue = Convert.ChangeType(item.Value, et);

                                            list.Add(primValue);
                                            break;
                                        }

                                    // List of list not supported!
                                    case Type et when typeof(IEnumerable).IsAssignableFrom(et): {
                                            throw new NotImplementedException("List of list not supported!");
                                        }

                                    case Type et when et.IsClass: {
                                            // Create new instance of et
                                            var itemObj = Activator.CreateInstance(et)!;

                                            // Create null object and add it to list. update it alter with parentId?
                                            et.GetProperty(item.Name)?.SetValue(itemObj, item.Value);

                                            // add item to list
                                            list.Add(itemObj);

                                            break;
                                        }

                                    case Type et when et.IsValueType: {
                                            var valueType = Convert.ChangeType(item.Value, et);
                                            list.Add(valueType);
                                            break;
                                        }

                                    default:
                                        break;
                                }
                                featureType.GetProperty(item.Name)?.SetValue(featureNode, list);

                                break;
                            }

                        case Type t when t.IsClass: {
                                throw new NotImplementedException("List of object not implemented");
                                break;
                            }

                        case Type t when t.IsValueType: {
                                var valueType = Convert.ChangeType(item.Value, t);
                                featureType.GetProperty(item.Name)?.SetValue(featureNode, valueType);
                                break;
                            }

                        default:
                            throw new ArgumentException("Invalid property type provided: {propertyType}", "propertyType");
                    }
                }

                return featureNode as FeatureNode;
            }

            // Gemini magic
            private static IList GetOrCreateListInstance(object obj, PropertyInfo propertyInfo) {
                var currentValue = propertyInfo.GetValue(obj);

                if (currentValue != null && currentValue is IList existingList) {
                    return existingList;
                }
                else {
                    var propertyType = propertyInfo.PropertyType;

                    var elementType = propertyType.IsGenericType ? propertyType.GetGenericArguments()[0] : typeof(object);
                    var newList = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(elementType))!;
                    propertyInfo.SetValue(obj, newList); // Set the new list back to the object
                    return newList;
                }
            }
        }

        private class NodeConverter : IYamlTypeConverter
        {
            public bool Accepts(Type type) => typeof(Node).IsAssignableFrom(type);

            public object? ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer) => throw new NotImplementedException("Deserialization is not supported.");

            public void WriteYaml(IEmitter emitter, object? value, Type type, ObjectSerializer serializer) {
                if (value is not Node) return;

                var propertyId = 1;

                var flattenedAttributes = FlattenAttributesRecursively(value, ref propertyId);

                if (flattenedAttributes.Count == 0) {
                    emitter.Emit(new Scalar(""));
                    return;
                }


                emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));     // YAML List

                foreach (var attr in flattenedAttributes) {
                    emitter.Emit(new MappingStart());                                       // YAML Object

                    emitter.Emit(new Scalar("Name"));                                       // YAML Primitive type
                    emitter.Emit(new Scalar(attr.Name));

                    if (attr.Value is not null) {
                        emitter.Emit(new Scalar("Value"));
                        emitter.Emit(new Scalar(attr.Value));   // Todo: Handle empty strings
                    }

                    if (attr.Id.HasValue) {
                        emitter.Emit(new Scalar("id"));
                        emitter.Emit(new Scalar(attr.Id.Value.ToString()));
                    }

                    if (attr.Parent.HasValue) {
                        emitter.Emit(new Scalar("parent"));
                        emitter.Emit(new Scalar(attr.Parent.Value.ToString()));
                    }

                    emitter.Emit(new MappingEnd());
                }

                emitter.Emit(new SequenceEnd());
            }
        }

        public class BooleanAsNumberConverter : IYamlTypeConverter
        {
            public bool Accepts(Type type) => type == typeof(bool) || type == typeof(Boolean);

            public object? ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer) => throw new NotImplementedException("Deserialization is not supported.");

            public void WriteYaml(IEmitter emitter, object? value, Type type, ObjectSerializer serializer) {
                emitter.Emit(new Scalar(((bool)value!) ? "1" : "0"));
            }
        }
    }
}