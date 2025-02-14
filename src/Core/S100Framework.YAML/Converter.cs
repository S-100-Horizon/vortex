using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using S100Framework.DomainModel;

namespace S100Framework.YAML
{
    public static class Converter
    {
        private record YamlAttributeItem(string Name, object? Value, int? Id, int? Parent);

        public static string SerializeAttributes(object dataset) {
            var propertyId = 1;

            var flattenedObject = FlattenAttributesRecursively(dataset, ref propertyId);

            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitDefaults)
                .Build();

            return serializer.Serialize(flattenedObject);
        }

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
    }
}