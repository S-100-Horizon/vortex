using S100FC.S100;
using System.Collections;
using System.Globalization;
using System.Reflection;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using Scalar = YamlDotNet.Core.Events.Scalar;

namespace S100FC.YAML
{
    public static class Converter
    {
        public static string Serialize(object dataset) => Serializer.Serialize(dataset);
        public static T Deserialize<T>(string yaml) => Deserializer.Deserialize<T>(yaml);
        public static object Deserialize(string yaml) => Deserializer.Deserialize(yaml);
        private record YamlAttributeItem(string Name, string? Value, int? Id, int? Parent);
        private readonly static S100FC.Catalogues.FeatureCatalogue featureCatalogue = S100FC.Catalogues.FeatureCatalogue.Catalogues.Single(e => e.ProductID.Equals("S-101"));

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

            var prop = type.GetProperty(
                "attributeBindings",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
            );

            if (prop?.GetValue(obj) is IEnumerable bindings) {
                foreach (var binding in bindings) {
                    switch (binding) {
                        case SimpleAttribute sa:
                            var attribute = GetSimple100Attribute(sa);
                            attributes.BuildAttributeItem(attribute.Value, sa.S100FC_code, attribute.Type, ref propertyId, parentId);

                            break;

                        case ComplexAttribute ca:
                            attributes.BuildAttributeItem(ca.attributeBindings, ca.S100FC_code, typeof(object), ref propertyId, parentId);

                            break;
                    }
                }
            }
            return attributes;
        }

        private static (object? Value, Type Type) GetSimple100Attribute(SimpleAttribute simpleAttribute) {
            return simpleAttribute switch {
                BooleanAttribute attr => (attr.value, typeof(bool)),
                IntegerAttribute attr => (attr.value, typeof(int)),
                EnumerationAttribute attr => (attr.value, typeof(int)),
                CodeListAttribute attr => (attr.value, typeof(int)),
                RealAttribute attr => (attr.value, typeof(decimal)),
                TimeAttribute attr => (attr.value, typeof(Time)),
                DateAttribute attr => (attr.value, typeof(DateOnly)),
                DateTimeAttribute attr => (attr.value, typeof(DateTime)),
                TextAttribute attr => (attr.value, typeof(string)),
                S100_TruncatedDateAttribute attr => (attr.value, typeof(string)),
                UrnTimeAttribute attr => (attr.value, typeof(string)),
                UriTimeAttribute attr => (attr.value, typeof(string)),
                UrlTimeAttribute attr => (attr.value, typeof(string)),

                _ => throw new InvalidCastException()
            };
        }

        private static void BuildAttributeItem(this List<YamlAttributeItem> attributes, object? propertyValue, string propertyName, Type propertyType, ref int propertyId, int? parentId) {
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

                // Ensure valid S-101 TimeOfDay objects
                case Type t when t == typeof(Time):
                    var timeString = propertyValue.ToString();

                    var timeOfDay = Time.Parse(timeString);

                    attributes.Add(new(propertyName, timeOfDay.ToString(), null, parentId));

                    break;

                // Ensure decimals with point 2.0
                case Type t when t == typeof(decimal):
                    var parsed = (decimal?)propertyValue!;

                    attributes.Add(new(propertyName, parsed?.ToString(CultureInfo.InvariantCulture), null, parentId));
                    break;

                // Ensure doubles with point 2.0
                case Type t when t == typeof(double):
                    var parsedDouble = (double?)propertyValue!;

                    attributes.Add(new(propertyName, parsedDouble?.ToString(CultureInfo.InvariantCulture), null, parentId));
                    break;

                case Type t when t.IsEnum:
                    var enumvalue = ToEnumString(propertyValue);

                    attributes.Add(new(propertyName, enumvalue, null, parentId));
                    break;

                case Type t when t.IsPrimitive:
                    attributes.Add(new(propertyName, propertyValue?.ToString(), null, parentId));
                    break;

                case Type t when typeof(IEnumerable).IsAssignableFrom(t):
                    // If the property is a nullable collection, but still required, add it with null value
                    if (propertyValue == null) {
                        attributes.Add(new(propertyName, null, null, parentId));
                        break;
                    }

                    if (propertyValue is not IEnumerable collection)
                        break;

                    if (!collection.GetEnumerator().MoveNext()) {
                        attributes.Add(new(propertyName, null, null, parentId));
                    }

                    foreach (var item in collection!) {
                        var type = item.GetType();
                        type = Nullable.GetUnderlyingType(type) ?? type;

                        attributes.BuildAttributeItem(item, propertyName, type, ref propertyId, parentId);
                    }

                    break;

                case Type t when t.IsClass:
                    // Add root object with ID and value = null
                    attributes.Add(new(propertyName, null, propertyId, parentId));

                    parentId = propertyId;
                    propertyId++;

                    foreach (var property in propertyValue as IEnumerable<attributeBinding> ?? []) {
                        if (property is SimpleAttribute sp) {
                            var attribute = GetSimple100Attribute(sp);
                            attributes.BuildAttributeItem(attribute.Value, property.S100FC_code, attribute.Type, ref propertyId, parentId);
                        }
                        else if (property is ComplexAttribute cp) {

                            attributes.BuildAttributeItem(cp.attributeBindings, cp.S100FC_code, typeof(object), ref propertyId, parentId);
                        }
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
            if (enumValue.ToString() == "-1") return null;
            if (enumValue.ToString() == "Unknown") return null;
            return $"{(int)enumValue!}";
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

                    this.GetKeyValueScalar(parser, out string key, out string? value);

                    // if this is null, its the beginning of a list
                    if (!string.IsNullOrEmpty(value)) {
                        AddRootAttributes(key, value, dataset);
                    }
                    else if (key == "Metadata") {
                        this.AddMetadata(parser, dataset);
                    }
                    else {
                        this.AddCollection(parser, key, dataset);
                    }

                    // always move at the end. Should only reach this after each root collection or root attribute
                    parser.MoveNext();
                } while (parser.Current is not DocumentEnd);


                return dataset;
            }

            public void AddMetadata(IParser parser, Dataset dataset) {
                var metadata = this.AddMetadataAttribute(parser);
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

            private void AddCollection(IParser parser, string collectionName, Dataset dataset) {
                if (parser.Current is SequenceStart or MappingStart)
                    parser.MoveNext(); // skip the sequence/mapping start

                do {
                    switch (collectionName) {
                        case "InformationTypes":
                            // To-do Not implemented yet
                            var information = this.AddInformationType(parser);
                            dataset.AddInformation(information);
                            break;
                        case "Points":
                            var point = this.AddPoint(parser);
                            dataset.AddPoint(point);
                            break;
                        case "Curves":
                            var curve = this.AddCurve(parser);
                            dataset.AddCurve(curve);
                            break;
                        case "CompositeCurves":
                            var compCurve = AddCompositeCurve(parser);
                            dataset.AddCompositeCurve(compCurve);
                            break;
                        case "Depths":
                            var depth = this.AddDepth(parser);
                            dataset.AddPointSet(depth);
                            break;
                        case "Surfaces":
                            var surface = AddSurface(parser);
                            dataset.AddSurface(surface);
                            break;
                        case "Features":
                            var feature = this.AddFeatureAttribute(parser);
                            dataset.AddFeature(feature);
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
                    case "verticalDatum":
                        dataset.verticalDatum = value;
                        break;
                }
            }

            private Metadata AddMetadataAttribute(IParser parser) {
                var metadata = new Metadata();
                // Only iterate on the Metadata object at root level
                while (parser.Current is not MappingEnd) {
                    if (parser.Current is Scalar scalarKey) {
                        this.GetKeyValueScalar(parser, out string key, out string? value);
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
                return metadata;
            }

            private Point AddPoint(IParser parser) {
                string? name = null;
                double? x = null, y = null;
                List<Association> associations = [];
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
                            case "Association":
                                var assos = this.BuildAssociations(parser);
                                associations.AddRange(assos);
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

                var point = new Point(x.Value, y.Value) {
                    Name = name
                };

                foreach (var association in associations) {
                    point.AddAssociation(association);
                }
                return point;
            }

            private PointSet AddDepth(IParser parser) {
                string? name = null;
                List<Coordinate> coordinates = [];
                double[] depths = [];
                List<Association> associations = [];

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
                            case "Association":
                                var assos = this.BuildAssociations(parser);
                                associations.AddRange(assos);
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

                var pointSet = new PointSet([.. coordinates], depths) {
                    Name = name
                };

                foreach (var association in associations) {
                    pointSet.AddAssociation(association);
                }

                return pointSet;
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

            private static Surface AddSurface(IParser parser) {
                string? name = null;
                string? exterior = null;
                List<string> interior = [];

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
                            case "Exterior":
                                exterior = value;
                                break;
                            case "Interior":
                                parser.MoveNext(); // parse.movenext() since Interior's value is always null. 

                                while (parser.Current is not SequenceEnd) {
                                    parser.MoveNext(); // Another parse.movenext() since MappingStart
                                    parser.MoveNext(); // Skip value (we know its "Hole")

                                    var interiorValue = parser.Current as Scalar;
                                    interior.Add(interiorValue.Value);

                                    parser.MoveNext(); // Go next and skip current Scalar value
                                    parser.MoveNext(); // Go next and skip MappingEnd. Exits the loop if end of sequence
                                }

                                break;
                        }
                    }

                    parser.MoveNext();
                }

                if (name == null || exterior == null)
                    throw new InvalidOperationException("Missing name or exterior for CompositeCurve");

                return new Surface(exterior) {
                    Name = name,
                    InteriorRings = interior.Count != 0 ? [.. interior] : null
                };
            }

            private Curve AddCurve(IParser parser) {
                string? name = null;
                string? start = null;
                string? end = null;
                List<Association> associations = [];
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
                            case "Association":
                                var curveAssociations = this.BuildAssociations(parser);
                                associations.AddRange(curveAssociations);
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

                var curve = new Curve(start, end, [.. vertices]) {
                    Name = name,
                };

                foreach (var association in associations) {
                    curve.AddAssociation(association);
                }

                return curve;
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
                                feature.Prim = string.IsNullOrEmpty(value) ? Primitive.NoGeometry : Enum.Parse<Primitive>(value);
                                break;
                            case "Foid":
                                feature.Foid = value;
                                break;
                            case "Geometry":
                                feature.Geometry = value;
                                break;
                            case "Attributes":
                                // Keep on parsing.. 
                                parser.MoveNext();  // SequenceStart
                                parser.MoveNext();  // MappingStart

                                var attributeList = this.BuildAttributeList(parser);

                                var featureNode = BuildFeatureNodeObject(attributeList, feature.Name);

                                feature.Attributes = featureNode;

                                break;
                            case "FeatureAssociation":
                                var featureAssociations = this.BuildAssociations(parser);

                                foreach (var fa in featureAssociations) {
                                    feature.AddFeatureAssociation(fa);
                                }
                                break;
                            case "Association":
                                var associations = this.BuildAssociations(parser);

                                foreach (var a in associations) {
                                    feature.AddAssociation(a);
                                }
                                break;
                        }
                    }

                    parser.MoveNext();
                }
                return feature;
            }
            private Information AddInformationType(IParser parser) {
                var information = new Information();
                while (parser.Current is not MappingEnd) {
                    if (parser.Current is Scalar scalarKey) {
                        var key = scalarKey.Value;

                        // Check next element
                        parser.MoveNext();

                        parser.Accept(out Scalar scalarValue);

                        var value = scalarValue?.Value;
                        switch (key) {
                            case "Name":
                                information.Name = value;
                                break;
                            case "ID":
                                information.ID = value;
                                break;
                            case "Attributes":
                                // Keep on parsing.. 
                                parser.MoveNext();  // SequenceStart
                                parser.MoveNext();  // MappingStart

                                var attributeList = this.BuildAttributeList(parser);

                                S100FC.InformationType informationNode = BuildInformationNodeObject(attributeList, information.Name);

                                information.Attributes = informationNode;

                                break;
                        }
                    }

                    parser.MoveNext();
                }
                return information;
            }

            private List<Association> BuildAssociations(IParser parser) {
                var associations = new List<Association>();

                string? to = null;
                string? name = null;
                string? role = null;

                while (parser.Current is not SequenceEnd) {
                    if (parser.Current is Scalar) {

                        this.GetKeyValueScalar(parser, out var key, out var value);

                        if (key == "To")
                            to = value;
                        else if (key == "Name")
                            name = value;
                        else if (key == "Role")
                            role = value;

                    }
                    else if (parser.Current is MappingEnd) {
                        // Add to list and clear
                        associations.Add(new() {
                            To = to,
                            Name = name,
                            Role = role
                        });

                        to = "";
                        name = null;
                        role = null;
                    }


                    parser.MoveNext();
                }

                return associations;
            }
            private List<YamlAttributeItem> BuildAttributeList(IParser parser) {
                var attributes = new List<YamlAttributeItem>();

                string itemName = "";
                string? itemValue = null;
                int? itemId = null;
                int? itemParent = null;

                while (parser.Current is not SequenceEnd) {
                    if (parser.Current is Scalar) {
                        this.GetKeyValueScalar(parser, out var key, out var value);

                        if (key == "Name")
                            itemName = value;
                        else if (key == "Value")
                            itemValue = value;
                        else if (key == "id")
                            itemId = Int32.Parse(value);
                        else if (key == "parent")
                            itemParent = Int32.Parse(value);

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
            private static S100FC.InformationType BuildInformationNodeObject(List<YamlAttributeItem> attributes, string type) {
                var informationType = featureCatalogue.Assembly!.GetType($"{S100FC.Catalogues.FeatureCatalogue.Namespace("S101", "InformationTypes")}.{type}", true) ?? default;

                var informationNode = Activator.CreateInstance(informationType);
                var typeInstances = new Dictionary<int, object> { { 0, informationNode } };

                foreach (var attr in attributes) {
                    var parentId = attr.Parent ?? 0;
                    var parentInstance = typeInstances[parentId];
                    var parentType = parentInstance.GetType();
                    var prop = parentType.GetProperty(attr.Name);

                    if (prop == null)
                        continue;

                    // Unwrap nullable type
                    var typed = Nullable.GetUnderlyingType(prop.PropertyType!) ?? prop.PropertyType;

                    object? newInstance;

                    switch (typed) {
                        case Type t when t == typeof(string): {
                                if (attr.Value == null) continue;
                                var convertedValue = attr.Value;
                                prop.SetValue(parentInstance, convertedValue);
                                break;
                            }

                        case Type t when t == typeof(bool): {
                                if (attr.Value == null) continue;
                                var booleanValue = Convert.ToInt32(attr.Value) == 1;
                                prop.SetValue(parentInstance, booleanValue);
                                break;
                            }

                        case Type t when t == typeof(decimal): {
                                if (attr.Value == null) continue;
                                var decimalValue = decimal.Parse(attr.Value, CultureInfo.InvariantCulture);
                                prop.SetValue(parentInstance, decimalValue);
                                break;
                            }

                        case Type t when t == typeof(double): {
                                if (attr.Value == null) continue;
                                var doubleValue = double.Parse(attr.Value, CultureInfo.InvariantCulture);
                                prop.SetValue(parentInstance, doubleValue);
                                break;
                            }



                        case Type t when t.IsEnum: {
                                if (attr.Value == null) continue;
                                var enumValue = Enum.Parse(typed, attr.Value);
                                prop.SetValue(parentInstance, enumValue);
                                break;
                            }

                        case Type t when t.IsPrimitive: {
                                if (attr.Value == null) continue;
                                var convertedValue = Convert.ChangeType(attr.Value, typed);
                                prop.SetValue(parentInstance, convertedValue);
                                break;
                            }

                        case Type t when typeof(IEnumerable).IsAssignableFrom(t): {         // && t != typeof(string)
                                var elementType = t.IsArray ? t.GetElementType() : t.IsGenericType ? t.GetGenericArguments()[0] : null;
                                var listType = typeof(List<>).MakeGenericType(elementType!);

                                var list = (IList)Activator.CreateInstance(listType)!;

                                if (elementType == typeof(string) || elementType.IsPrimitive || elementType.IsEnum || elementType == typeof(decimal) || elementType == typeof(double)) {
                                    if (attr.Value == null) continue;

                                    var convertedItem = elementType.IsEnum
                                        ? Enum.Parse(elementType, attr.Value)
                                        : Convert.ChangeType(attr.Value, elementType, CultureInfo.InvariantCulture);

                                    list!.Add(convertedItem);
                                }
                                else {
                                    newInstance = Activator.CreateInstance(elementType)!;
                                    list!.Add(newInstance);

                                    if (attr.Id.HasValue)
                                        typeInstances[attr.Id.Value] = newInstance;
                                }

                                if (t.IsArray) {
                                    Array array = Array.CreateInstance(elementType!, list.Count);
                                    list.CopyTo(array, 0);

                                    prop.SetValue(parentInstance, array);
                                }
                                else {
                                    prop.SetValue(parentInstance, list);
                                }

                                break;
                            }

                        case Type t when t.IsClass: {
                                newInstance = Activator.CreateInstance(typed)!;
                                prop.SetValue(parentInstance, newInstance);

                                if (attr.Id.HasValue)
                                    typeInstances[attr.Id.Value] = newInstance;
                                break;
                            }

                        case Type t when t == typeof(DateOnly): {
                                if (attr.Value == null) continue;
                                var dateOnly = DateOnly.Parse(attr.Value, CultureInfo.InvariantCulture);
                                prop.SetValue(parentInstance, dateOnly);
                                break;
                            }

                        case Type t when t.IsValueType: {
                                if (attr.Value == null) continue;
                                var convertedValue = Convert.ChangeType(attr.Value, typed);
                                prop.SetValue(parentInstance, convertedValue);
                                break;
                            }

                        default:
                            break;
                    }
                }

                return informationNode as S100FC.InformationType;
            }
            private static S100FC.FeatureType BuildFeatureNodeObject(List<YamlAttributeItem> attributes, string type) {
                var featureType = featureCatalogue.Assembly!.GetType($"{S100FC.Catalogues.FeatureCatalogue.Namespace("S101", "FeatureTypes")}.{type}", true) ?? default;
                var featureNode = Activator.CreateInstance(featureType);
                var typeInstances = new Dictionary<int, object> { { 0, featureNode } };

                foreach (var attr in attributes) {
                    var parentId = attr.Parent ?? 0;
                    var parentInstance = typeInstances[parentId];
                    var parentType = parentInstance.GetType();
                    var prop = parentType.GetProperty(attr.Name);
                    if (attr.Name == "UnsurveyedArea")
                        Console.WriteLine();

                    if (prop == null)
                        continue;

                    // Unwrap nullable type
                    var typed = Nullable.GetUnderlyingType(prop.PropertyType!) ?? prop.PropertyType;

                    object? newInstance;

                    switch (typed) {
                        case Type t when t == typeof(string): {
                                if (attr.Value == null) continue;
                                var convertedValue = attr.Value;
                                prop.SetValue(parentInstance, convertedValue);
                                break;
                            }

                        case Type t when t == typeof(bool): {
                                if (attr.Value == null || string.IsNullOrEmpty(attr.Value)) continue;
                                bool booleanValue;
                                if (int.TryParse(attr.Value, out int intValue))
                                    booleanValue = intValue == 1;
                                else
                                    booleanValue = bool.Parse(attr.Value);
                                //var booleanValue = bool.Parse(attr.Value);  // Convert.ToInt32(attr.Value) == 1;
                                prop.SetValue(parentInstance, booleanValue);
                                break;
                            }

                        case Type t when t == typeof(decimal): {
                                if (attr.Value == null || string.IsNullOrEmpty(attr.Value)) continue;
                                var decimalValue = decimal.Parse(attr.Value, CultureInfo.InvariantCulture);
                                prop.SetValue(parentInstance, decimalValue);
                                break;
                            }

                        case Type t when t == typeof(double): {
                                if (attr.Value == null || string.IsNullOrEmpty(attr.Value)) continue;
                                var doubleValue = double.Parse(attr.Value, CultureInfo.InvariantCulture);
                                prop.SetValue(parentInstance, doubleValue);
                                break;
                            }

                        case Type t when t.IsEnum: {
                                if (attr.Value == null || string.IsNullOrEmpty(attr.Value)) continue;
                                var enumValue = Enum.Parse(typed, attr.Value);
                                prop.SetValue(parentInstance, enumValue);
                                break;
                            }

                        case Type t when t.IsPrimitive: {
                                if (attr.Value == null) continue;
                                var convertedValue = Convert.ChangeType(attr.Value, typed);
                                prop.SetValue(parentInstance, convertedValue);
                                break;
                            }

                        case Type t when typeof(IEnumerable).IsAssignableFrom(t): {
                                var elementType = t.IsArray ? t.GetElementType() : t.IsGenericType ? t.GetGenericArguments()[0] : null;
                                var listType = typeof(List<>).MakeGenericType(elementType!);

                                var list = (IList)Activator.CreateInstance(listType)!;

                                if (elementType == typeof(string) || elementType.IsPrimitive || elementType.IsEnum || elementType == typeof(decimal) || elementType == typeof(double)) {
                                    if (attr.Value == null || string.IsNullOrEmpty(attr.Value)) continue;

                                    var convertedItem = elementType.IsEnum
                                        ? Enum.Parse(elementType, attr.Value)
                                        : Convert.ChangeType(attr.Value, elementType, CultureInfo.InvariantCulture);

                                    list!.Add(convertedItem);
                                }
                                else {
                                    newInstance = Activator.CreateInstance(elementType)!;
                                    list!.Add(newInstance);

                                    if (attr.Id.HasValue)
                                        typeInstances[attr.Id.Value] = newInstance;
                                }

                                if (t.IsArray) {
                                    Array array = Array.CreateInstance(elementType!, list.Count);
                                    list.CopyTo(array, 0);

                                    prop.SetValue(parentInstance, array);
                                }
                                else {
                                    prop.SetValue(parentInstance, list);
                                }
                                break;
                            }

                        case Type t when t.IsClass: {
                                newInstance = Activator.CreateInstance(typed)!;
                                prop.SetValue(parentInstance, newInstance);

                                if (attr.Id.HasValue)
                                    typeInstances[attr.Id.Value] = newInstance;
                                break;
                            }

                        case Type t when t == typeof(DateOnly): {
                                if (attr.Value == null) continue;
                                var dateOnly = DateOnly.Parse(attr.Value, CultureInfo.InvariantCulture);
                                prop.SetValue(parentInstance, dateOnly);
                                break;
                            }

                        case Type t when t.IsValueType: {
                                if (attr.Value == null) continue;
                                var convertedValue = Convert.ChangeType(attr.Value, typed);
                                prop.SetValue(parentInstance, convertedValue);
                                break;
                            }

                        default:
                            break;
                    }
                }

                return featureNode as S100FC.FeatureType;
            }
        }

        private class NodeConverter : IYamlTypeConverter
        {
            public bool Accepts(Type type) => typeof(S100FC.FeatureType).IsAssignableFrom(type) || typeof(S100FC.InformationType).IsAssignableFrom(type);
            //public bool Accepts(Type type) => true;
            public object? ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer) => throw new NotImplementedException("Deserialization is not supported.");

            public void WriteYaml(IEmitter emitter, object? value, Type type, ObjectSerializer serializer) {
                //if (value is not S100FC.FeatureType or S100FC.InformationType) return;

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
                        emitter.Emit(new Scalar(attr.Value));
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