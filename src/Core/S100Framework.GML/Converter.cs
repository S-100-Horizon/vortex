using S100FC.S100;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace S100Framework.GML
{
    public static class Converter
    {
        public static object Deserialize(XElement element, Type type) {
            if (element == null)
                throw new ArgumentNullException(nameof(element), "Element cannot be null");

            var instance = Activator.CreateInstance(type);

            var properties = type.GetProperties();

            foreach (var el in element.Elements()) {
                var property = properties.FirstOrDefault(e => string.Equals(e.Name, el.Name.LocalName, StringComparison.OrdinalIgnoreCase));

                // If property is null, continue to next element probably some geometry
                if (property == null)
                    continue;

                // Skip geometry. We handle this another place
                if (string.Equals(property.Name, "geometry", StringComparison.OrdinalIgnoreCase))
                    continue;

                var typed = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                AppendAttribute(typed, property, el, ref instance!);
            }

            // Set GML ID if it exists
            var gmlId = element.Attributes().FirstOrDefault(a => a.Name.LocalName == "id")?.Value;

            if (gmlId != null) {
                var prop = type.GetProperty("gmlId");
                if (prop != null && prop.CanWrite)
                    prop.SetValue(instance, gmlId);
            }

            return instance!;
        }

        public static string? GetEnumValueFromEnumMemberValue(Type enumType, string? enumMemberValue) {
            if (!enumType.IsEnum)
                throw new ArgumentException("Provided type must be an enum.", nameof(enumType));

            if (string.IsNullOrEmpty(enumMemberValue))
                return enumMemberValue;

            foreach (var field in enumType.GetFields(BindingFlags.Public | BindingFlags.Static)) {
                var attr = field.GetCustomAttribute<EnumMemberAttribute>();
                if (string.Equals(attr?.Value, enumMemberValue, StringComparison.OrdinalIgnoreCase)) {
                    return field.Name;
                }
            }

            return enumMemberValue;
        }


        public static void AppendAttribute(Type type, PropertyInfo property, XElement element, ref object instance) {
            try {
                var isNil = element.Attributes().Any(a => a.Name.LocalName == "nil" && a.Value.Equals("true", StringComparison.OrdinalIgnoreCase));

                switch (type) {
                    case var t when t == typeof(string):
                        var stringValue = isNil ? null : element.Value;
                        property.SetValue(instance, stringValue);
                        break;
                    case var t when t.IsEnum:
                        // Try to get the enum value from the attribute "code" or use the element value. If the element is nil, set it to null.
                        var enumValue = isNil ? null : element.Attribute("code")?.Value ?? element.Value;

                        // Try to get the Value from the [EnumMember] attribute if possible
                        var enumMemberValue = GetEnumValueFromEnumMemberValue(t, enumValue!);

                        // Tryparse to enum. Null can be valid
                        _ = Enum.TryParse(t, enumMemberValue, out var parsed);

                        property.SetValue(instance, parsed);

                        break;
                    case var t when t == typeof(int):
                        int? intValue = isNil ? null : int.Parse(element.Value, System.Globalization.CultureInfo.InvariantCulture);
                        property.SetValue(instance, intValue);
                        break;
                    case var t when t == typeof(double):
                        double? doubleValue = isNil ? null : Double.Parse(element.Value, System.Globalization.CultureInfo.InvariantCulture);
                        property.SetValue(instance, doubleValue);
                        break;
                    case var t when t == typeof(decimal):
                        decimal? decimalValue = isNil ? null : Decimal.Parse(element.Value, System.Globalization.CultureInfo.InvariantCulture);
                        property.SetValue(instance, decimalValue);
                        break;
                    case var t when t == typeof(bool):
                        bool? boolValue = null;

                        if (!isNil) {
                            var value = element.Value;

                            if (value == "0")
                                boolValue = false;
                            else if (value == "1")
                                boolValue = true;
                            else
                                boolValue = bool.Parse(value);
                        }

                        property.SetValue(instance, boolValue);
                        break;
                    case var t when t == typeof(DateTime):
                        DateTime? dateTimeValue = isNil ? (DateTime?)null : DateTime.Parse(element.Value, CultureInfo.InvariantCulture);
                        property.SetValue(instance, dateTimeValue);
                        break;
                    case var t when t == typeof(DateOnly):
                        DateOnly? dateOnlyValue = isNil ? (DateOnly?)null : DateOnly.Parse(element.Value, CultureInfo.InvariantCulture);
                        property.SetValue(instance, dateOnlyValue);
                        break;
                    case var t when t == typeof(TimeOnly):
                        TimeOnly? timeOnlyValue = isNil ? (TimeOnly?)null : TimeOnly.Parse(element.Value, CultureInfo.InvariantCulture);
                        property.SetValue(instance, timeOnlyValue);
                        break;

                    // Ensure valid S-101 TimeOfDay objects
                    case var t when t == typeof(Time):
                        Time? timeOfDayValue = isNil ? null : Time.Parse(element.Value);
                        property.SetValue(instance, timeOfDayValue);
                        break;

                    case var t when t == typeof(Guid):
                        Guid? uuidValue = isNil ? (Guid?)null : Guid.Parse(element.Value, CultureInfo.InvariantCulture);
                        property.SetValue(instance, uuidValue);
                        break;

                    case var t when typeof(IEnumerable).IsAssignableFrom(t) && t != typeof(string):
                        // If element is null, dont append null to list
                        if (isNil)
                            break;

                        // Try to get the existing collection from the property
                        var collection = property.GetValue(instance) as IList;

                        // If the collection is null, create a new instance of the collection
                        collection ??= Activator.CreateInstance(property.PropertyType) as IList;

                        // Figure out what type of the list is of
                        var itemType = t.GetGenericArguments().FirstOrDefault() ?? typeof(object);

                        // Get underlying type if nullable
                        var itemTyped = Nullable.GetUnderlyingType(itemType) ?? itemType;

                        switch (itemTyped) {
                            case var tt when tt == typeof(string):
                                collection!.Add(element.Value);
                                break;
                            case var tt when typeof(IEnumerable).IsAssignableFrom(tt) && tt != typeof(string):
                                throw new InvalidOperationException("Cannot deserialize a collection of collections.");
                            case var tt when tt.IsClass:
                                // Create an instance of the object (featureName)
                                var tItemInstance = Activator.CreateInstance(itemType);

                                // Get the properties of the object
                                var ttProperties = itemType.GetProperties();

                                // Íterate elements and match them with properties
                                foreach (var ttElement in element.Elements()) {
                                    // Check if the element exists as a property of the object
                                    var ttProperty = ttProperties.FirstOrDefault(e => string.Equals(e.Name, ttElement.Name.LocalName, StringComparison.OrdinalIgnoreCase));

                                    if (ttProperty == null)
                                        continue;

                                    // Get the type of the property (string, another object..?)
                                    var tItemType = ttProperty.PropertyType;

                                    // .. and its undelying type if nullable
                                    var tItemTyped = Nullable.GetUnderlyingType(tItemType) ?? tItemType;

                                    AppendAttribute(tItemTyped, ttProperty, ttElement, ref tItemInstance!);
                                }
                                // Add object to list<object> e.g. featureName to List<featureName>
                                collection!.Add(tItemInstance);

                                break;

                            case var tt when tt.IsEnum:
                                // Try to get the enum value from the attribute "code" or use the element value.
                                var tEnumValue = element.Attribute("code")?.Value ?? element.Value;

                                // Try to get the Value from the [EnumMember] attribute if possible
                                var tEnumMemberValue = GetEnumValueFromEnumMemberValue(tt, tEnumValue!);

                                // TryParse to enum. Null can be valid
                                _ = Enum.TryParse(tt, tEnumMemberValue, out var parsedValue);

                                collection!.Add(parsedValue);
                                break;
                            // Default case
                            case var tt when tt == typeof(int):
                                var tIntValue = int.Parse(element.Value, System.Globalization.CultureInfo.InvariantCulture);
                                collection!.Add(tIntValue);

                                break;
                            case var tt when tt == typeof(double):
                                var tDoubleValue = Double.Parse(element.Value, System.Globalization.CultureInfo.InvariantCulture);
                                collection!.Add(tDoubleValue);

                                break;
                            case var tt when tt == typeof(decimal):
                                var tDecimalValue = Decimal.Parse(element.Value, System.Globalization.CultureInfo.InvariantCulture);
                                collection!.Add(tDecimalValue);

                                break;
                            case var tt when tt == typeof(bool):
                                bool? tBoolValue = null;

                                var value = element.Value;

                                if (value == "0")
                                    boolValue = false;
                                else if (value == "1")
                                    boolValue = true;
                                else
                                    boolValue = bool.Parse(value);

                                collection!.Add(tBoolValue);
                                break;
                            case var tt when tt == typeof(DateTime):
                                var tDateTimeValue = DateTime.Parse(element.Value, CultureInfo.InvariantCulture);
                                collection!.Add(tDateTimeValue);
                                break;
                            case var tt when tt == typeof(DateOnly):
                                var tDateOnlyValue = DateOnly.Parse(element.Value, CultureInfo.InvariantCulture);
                                collection!.Add(tDateOnlyValue);
                                break;
                            case var tt when tt == typeof(TimeOnly):
                                var tTimeOnlyValue = TimeOnly.Parse(element.Value, CultureInfo.InvariantCulture);
                                collection!.Add(tTimeOnlyValue);
                                break;
                            case var tt when tt == typeof(Time):
                                var tTimeOfDayValue = Time.Parse(element.Value);
                                collection!.Add(tTimeOfDayValue);
                                break;
                            case var tt when tt == typeof(Guid):
                                var tUuidValue = Guid.Parse(element.Value, CultureInfo.InvariantCulture);
                                collection!.Add(tUuidValue);
                                break;
                            default:
                                collection!.Add(element.Value);
                                break;
                        }
                        // Set the collection to the property of the parent object
                        property.SetValue(instance, collection);

                        break;

                    case var t when t.IsClass:
                        // Create instance of the class (featureName)
                        var tInstance = Activator.CreateInstance(t);

                        // Get properties of the featureName class
                        var tProperties = t.GetProperties();

                        foreach (var tElement in element.Elements()) {
                            // If the element exists as a property of the object
                            var tProperty = tProperties.FirstOrDefault(e => string.Equals(e.Name, tElement.Name.LocalName, StringComparison.OrdinalIgnoreCase));

                            // If property is null, continue to next element probably geometry.
                            if (tProperty == null)
                                continue;

                            // Get the type of the property of featureName
                            var tTyped = Nullable.GetUnderlyingType(tProperty.PropertyType) ?? tProperty.PropertyType;

                            // Add the element value to the property (e.g string) of the object (featureName)
                            AppendAttribute(tTyped, tProperty, tElement, ref tInstance!);
                        }

                        property.SetValue(instance, tInstance);

                        break;

                    default:
                        //System.Diagnostics.Debugger.Break();
                        break;
                }
            }
            catch (Exception) {
                // Never dont stop!
                //System.Diagnostics.Debugger.Break();
            }
        }
    }
}