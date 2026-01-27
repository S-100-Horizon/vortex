using JsonFlatten;
using Newtonsoft.Json.Linq;
using S100FC;
using System.Text.Json;

namespace S100Framework.Catalogues
{
    public static class AttributeFlattenExtensions
    {
        public static string Flatten(this FeatureType feature) => FlattenAttributes(feature.attributeBindings, feature.attributeBindingsCatalogue);
        public static string Flatten(this InformationType information) => FlattenAttributes(information.attributeBindings, information.attributeBindingsCatalogue);

        public static string FlattenAttributes(attributeBinding[] attributes, attributeBindingDefinition[] catalogue) {
            var root = new JObject();

            foreach (var attr in attributes) {
                var isCollection = catalogue.Single(e => e.attribute == attr.S100FC_code).IsCollection;
                
                AddAttribute(root, attr, catalogue, isCollection);
            }

            var flattened = root.Flatten();
            return JsonSerializer.Serialize(flattened);
        }

        private static void AddAttribute(JObject parent, attributeBinding attribute, attributeBindingDefinition[] catalogue, bool isCollection = false) {
            switch (attribute) {
                case BooleanAttribute s:
                    if (s.value == null) break;
                    AddValue(parent, attribute.S100FC_code, s.value, isCollection);
                    break;
                case IntegerAttribute s:
                    if (s.value == null) break;
                    AddValue(parent, attribute.S100FC_code, s.value, isCollection);
                    break;
                case RealAttribute s:
                    if (s.value == null) break;
                    AddValue(parent, attribute.S100FC_code, s.value, isCollection);
                    break;
                case TextAttribute s:
                    if (s.value == null) break;
                    AddValue(parent, attribute.S100FC_code, s.value, isCollection);
                    break;
                case S100_TruncatedDateAttribute s:
                    if (s.value == null) break;
                    AddValue(parent, attribute.S100FC_code, s.value, isCollection);
                    break;
                case DateAttribute s:
                    if (s.value == null) break;
                    AddValue(parent, attribute.S100FC_code, s.value, isCollection);
                    break;
                case DateTimeAttribute s:
                    if (s.value == null) break;
                    AddValue(parent, attribute.S100FC_code, s.value, isCollection);
                    break;
                case TimeAttribute s:
                    if (s.value == null) break;
                    AddValue(parent, attribute.S100FC_code, s.value, isCollection);
                    break;

                case UrnTimeAttribute s:
                    if (s.value == null) break;
                    AddValue(parent, attribute.S100FC_code, s.value, isCollection);
                    break;
                case UrlTimeAttribute s:
                    if (s.value == null) break;
                    AddValue(parent, attribute.S100FC_code, s.value, isCollection);
                    break;

                case UriTimeAttribute s:
                    if (s.value == null) break;
                    AddValue(parent, attribute.S100FC_code, s.value, isCollection);
                    break;

                case EnumerationAttribute s:
                    if (s.value == null) break;
                    AddValue(parent, attribute.S100FC_code, s.value, isCollection);
                    break;

                case CodeListAttribute s:
                    if (s.value == null) break;
                    AddValue(parent, attribute.S100FC_code, s.value, isCollection);
                    break;

                case ComplexAttribute c:
                    if (isCollection) {
                        var array = parent[attribute.S100FC_code] as JArray ?? new JArray();
                        var obj = new JObject();

                        foreach (var child in c.attributeBindings) {
                            var childDef = c.attributeBindingsCatalogue.Single(d => d.attribute == child.S100FC_code);
                            AddAttribute(obj, child, c.attributeBindingsCatalogue, childDef.IsCollection);
                        }

                        array.Add(obj);
                        parent[attribute.S100FC_code] = array;
                    }
                    else {
                        var obj = new JObject();
                        foreach (var child in c.attributeBindings) {
                            var childDef = c.attributeBindingsCatalogue.Single(d => d.attribute == child.S100FC_code);
                            AddAttribute(obj, child, c.attributeBindingsCatalogue, childDef.IsCollection);
                        }
                        parent[attribute.S100FC_code] = obj;
                    }
                    break;
            }
        }

        private static void AddValue(JObject parent, string key, object value, bool isCollection) {
            if (isCollection) {
                var array = parent[key] as JArray ?? [];
                array.Add(JToken.FromObject(value));
                parent[key] = array;
            }
            else {
                parent[key] = JToken.FromObject(value);
            }
        }
    }
}