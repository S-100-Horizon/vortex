namespace VortexLoader
{
    public static class EnumHelper
    {
        public static TEnum GetEnumValue<TEnum>(object value) where TEnum : struct, Enum {
            if (value is string strValue) {

                if (Enum.TryParse(strValue, true, out TEnum enumValue) && Enum.IsDefined(typeof(TEnum), enumValue)) {
                    return enumValue;
                }
                else {
                    throw new ArgumentException($"Invalid string value for enum {typeof(TEnum).Name}: {strValue}");
                }
            }
            else if (value is int intValue) {
                if (Enum.IsDefined(typeof(TEnum), intValue)) {
                    return (TEnum)(object)intValue;
                }
                else {
                    throw new ArgumentException($"Invalid integer value for enum {typeof(TEnum).Name}: {intValue}");
                }
            }
            else {
                throw new ArgumentException($"Value must be of type string or int. Provided value type: {value.GetType().Name}");
            }
        }

        public static List<TEnum> GetEnumValues<TEnum>(object value) where TEnum : struct, Enum {
            List<TEnum> result = new List<TEnum>();

            if (value is string strValue) {
                var values = strValue.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in values) {
                    if (Enum.TryParse(item.Trim(), true, out TEnum enumValue) && Enum.IsDefined(typeof(TEnum), enumValue)) {
                        result.Add(enumValue);
                    }
                    else {
                        throw new ArgumentException($"Invalid string value for enum {typeof(TEnum).Name}: {item.Trim()}");
                    }
                }
            }
            else if (value is int intValue) {
                if (Enum.IsDefined(typeof(TEnum), intValue)) {
                    result.Add((TEnum)(object)intValue);
                }
                else {
                    throw new ArgumentException($"Invalid integer value for enum {typeof(TEnum).Name}: {intValue}");
                }
            }
            else {
                throw new ArgumentException($"Value must be of type string or int. Provided value type: {value.GetType().Name}");
            }

            return result;
        }


    }





}
