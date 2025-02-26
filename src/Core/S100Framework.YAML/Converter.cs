using System.Collections;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using S100Framework.DomainModel;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;

namespace S100Framework.YAML
{
    public static class Converter
    {
        public static string Serialize(object dataset) => Serializer.Serialize(dataset);

        private record YamlAttributeItem(string Name, object? Value, int? Id, int? Parent);

        private static readonly ISerializer Serializer = new SerializerBuilder()
           .WithNamingConvention(PascalCaseNamingConvention.Instance)
           .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitDefaults)
           .WithIndentedSequences()
           .WithTypeConverter(new CustomNodeConverter()) // Custom type converter for objects of Node
           .Build();

        private static List<YamlAttributeItem> FlattenAttributesRecursively(object obj, ref int propertyId, int? parentId = null) {
            var attributes = new List<YamlAttributeItem>();

            var type = obj.GetType();
            var properties = type.GetProperties();

            foreach (var property in properties) {
                var propertyValue = property.GetValue(obj, null);
                if (propertyValue == null)
                    continue;

                switch (property.PropertyType) {
                    case Type t when t == typeof(string):
                        attributes.Add(new(property.Name, propertyValue.ToString(), null, parentId));
                        break;

                    case Type t when t == typeof(decimal):
                        attributes.Add(new(property.Name, Convert.ToDecimal(propertyValue), null, parentId));
                        break;

                    case Type t when t.IsEnum:
                        attributes.Add(new(property.Name, Convert.ToInt32(propertyValue), null, parentId));
                        break;

                    case Type t when t.IsPrimitive:
                        attributes.Add(new(property.Name, propertyValue.ToString(), null, parentId));
                        break;

                    case Type t when typeof(IEnumerable).IsAssignableFrom(t):
                        attributes.AddRange(HandleCollection(property.Name, propertyValue, ref propertyId, parentId));
                        break;

                    case Type t when t.IsClass:
                        attributes.AddRange(HandleComplexObject(propertyValue, ref propertyId, parentId));
                        break;
                    default:
                        // error handling..
                        break;
                }
            }

            return attributes;
        }
        private static List<YamlAttributeItem> HandleComplexObject(object propertyValue, ref int propertyId, int? parentId) {
            var name = propertyValue.GetType().Name;

            var attributes = new List<YamlAttributeItem>() {
                new(name, null, propertyId, parentId)
            };

            parentId = propertyId;

            propertyId++;

            attributes.AddRange(FlattenAttributesRecursively(propertyValue, ref propertyId, parentId));
            return attributes;
        }
        private static List<YamlAttributeItem> HandleCollection(string propertyName, object propertyValue, ref int propertyId, int? parentId) {
            var collection = propertyValue as IEnumerable;
            var attributes = new List<YamlAttributeItem>();
            foreach (var item in collection!) {
                var itemType = item.GetType();

                switch (itemType) {
                    case Type t when t == typeof(string):
                        attributes.Add(new(propertyName, item.ToString(), null, parentId));
                        break;

                    case Type t when t == typeof(decimal):
                        attributes.Add(new(propertyName, Convert.ToDecimal(item), null, parentId));
                        break;

                    case Type t when t.IsEnum:
                        attributes.Add(new(propertyName, Convert.ToInt32(item), null, parentId));
                        break;

                    case Type t when t.IsPrimitive:
                        attributes.Add(new(propertyName, item.ToString(), null, parentId));
                        break;

                    case Type t when typeof(IEnumerable).IsAssignableFrom(t):
                        // no support for multidimensional arrays
                        break;

                    case Type t when t.IsClass:
                        attributes.AddRange(HandleComplexObject(item, ref propertyId, parentId));
                        break;
                    default:
                        // error handling..
                        break;
                }
            }

            return attributes;
        }

        private class CustomNodeConverter : IYamlTypeConverter
        {
            public bool Accepts(Type type) => typeof(Node).IsAssignableFrom(type);

            public object? ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer) => throw new NotImplementedException("Deserialization is not supported.");

            public void WriteYaml(IEmitter emitter, object? value, Type type, ObjectSerializer serializer) {
                if (value is not Node) return;

                var propertyId = 1;

                var flattenedAttributes = FlattenAttributesRecursively(value, ref propertyId);

                emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));     // YAML List

                foreach (var attr in flattenedAttributes) {
                    emitter.Emit(new MappingStart());                                       // YAML Object

                    emitter.Emit(new Scalar("Name"));                                       // YAML Primitive type
                    emitter.Emit(new Scalar(attr.Name));

                    if (attr.Value is not null) {
                        emitter.Emit(new Scalar("Value"));
                        emitter.Emit(new Scalar(attr.Value.ToString()!));   // Todo: Handle empty strings
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
    }
}