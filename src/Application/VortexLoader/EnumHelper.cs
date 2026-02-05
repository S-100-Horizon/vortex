using System.Runtime.CompilerServices;

namespace S100Framework.Applications
{
    public static class EnumHelper
    {
        public static int? GetEnumValue(object? value, [CallerMemberName] string? propertyName = null) {
            if (value is null) return null;
            if (value is string strValue) {
                if (strValue.Equals("-32767"))
                    return null;
                if (int.TryParse(strValue, out int result))
                    return result;
                throw new ArgumentException($"Invalid string value for enum {propertyName}: {strValue}");
            }
            if (value is int intValue) {
                if (intValue == -32767)
                    return null;
                return intValue;
            }
            throw new ArgumentException($"Value must be of type string or int. Provided value type: {propertyName} - {value.GetType().Name}");
        }

        public static int?[]? GetEnumValues(object? value) {
            if (value is null) return null;
            int?[]? array = default;

            if (value is string strValue) {
                array = [];
                var values = strValue.Split(new[] { ',' });
                for (int i = 0; i < values.Length; i++) {
                    if (string.IsNullOrEmpty(values[i])) {
                        array = [.. array, null];
                    }
                    else {
                        var v = GetEnumValue(values[i]);
                        array = [.. array, GetEnumValue(values[i])];
                    }
                }
            }
            if (value is int intValue) {
                array = new int?[] { GetEnumValue(intValue) };
            }
            return array;
        }

        //public static TEnum? GetEnumValue(object value) where TEnum : struct, Enum where TType : class {

        //    var validEnumValues = S100Framework.Catalogues.Helper.GetValidEnumValues(typeof(TType), typeof(TEnum).Name);

        //    if (value is string strValue) {
        //        if (value.ToString() == "-32767") {
        //            //  @jesoe UNKNOWN is defined as null
        //            return null;
        //            //if (Enum.TryParse("-1", true, out TEnum enumValueUnknown)) {
        //            //    return enumValueUnknown;
        //            //}
        //            //else {
        //            //    throw new ArgumentException($"Invalid string value for enum {typeof(TEnum).Name}: {strValue}");
        //            //}
        //        }
        //        else if (Enum.TryParse(strValue, true, out TEnum enumValue) && Enum.IsDefined(typeof(TEnum), enumValue)) {
        //            return enumValue;
        //        }
        //        else {
        //            throw new ArgumentException($"Invalid string value for enum {typeof(TType).Name}::{typeof(TEnum).Name}: {strValue}");
        //        }
        //    }
        //    else if (value is int intValue) {
        //        if (intValue == -32767) {
        //            //  @jesoe UNKNOWN is defined as null
        //            return null;
        //        }

        //        else if (Enum.IsDefined(typeof(TEnum), intValue)) {
        //            if (!validEnumValues!.Contains<int>(intValue)) {
        //                //throw new ArgumentException($"Invalid integer value for enum {typeof(TEnum).Name}: {intValue} not in validEnumValues:{string.Join(",", validEnumValues)}");
        //                Logger.Current.DataError(-1, string.Empty, "enumvalue", $"Invalid integer value for enum {typeof(TType).Name}::{typeof(TEnum).Name}: {intValue} not in validEnumValues:{string.Join(",", validEnumValues!)}");
        //            }
        //            return (TEnum)(object)intValue;
        //        }
        //        else {
        //            throw new ArgumentException($"Invalid integer value for enum {typeof(TType).Name}::{typeof(TEnum).Name}: {intValue}");
        //        }
        //    }
        //    else {
        //        throw new ArgumentException($"Value must be of type string or int. Provided value type: {typeof(TType).Name}::{typeof(TEnum).Name} - {value.GetType().Name}");
        //    }
        //}

        //public static List<TEnum> GetEnumValues(object value) where TEnum : struct, Enum where TType : class { //DomainModel.FeatureNode {
        //    var validEnumValues = S100Framework.Catalogues.Helper.GetValidEnumValues(typeof(TType), typeof(TEnum).Name);

        //    List<TEnum> result = new List<TEnum>();

        //    if (value is string strValue) {
        //        var values = strValue.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        //        foreach (var item in values) {
        //            if (item == "-32767") {
        //                //  @jesoe UNKNOWN not allowed in list!
        //                //if (Enum.TryParse("-1", true, out TEnum enumValueUnknown)) {
        //                //    result.Add(enumValueUnknown);
        //                //}
        //                //else {
        //                //    throw new ArgumentException($"Invalid string value for enum {typeof(TEnum).Name}: {item.Trim()}");
        //                //}
        //                Logger.Current.DataError(-1, string.Empty, "enumvalues", $"Enum list contains -32767. This is not converted. {typeof(TType).Name}::{typeof(TEnum).Name} Total values in field: {values.Count()}");
        //            }
        //            else if (Enum.TryParse(item.Trim(), true, out TEnum enumValue) && Enum.IsDefined(typeof(TEnum), enumValue)) {
        //                var intValue = Convert.ToInt32(item);
        //                if (!validEnumValues!.Contains<int>(intValue)) {
        //                    //throw new ArgumentException($"Cannot convert enum value. Invalid integer value for enum {typeof(TType).Name}::{typeof(TEnum).Name}: {intValue} on {typeof(TType).Name} not in validEnumValues:{string.Join(",", validEnumValues)}");
        //                    Logger.Current.DataError(-1, string.Empty, "enumvalues", $"Invalid integer value for enum {typeof(TType).Name}::{typeof(TEnum).Name}: {intValue} not in validEnumValues:{string.Join(",", validEnumValues!)}");

        //                }
        //                result.Add(enumValue);
        //            }
        //            else {
        //                throw new ArgumentException($"Invalid string value for enum {typeof(TType).Name}::{typeof(TEnum).Name}: {item.Trim()}");
        //            }
        //        }
        //    }
        //    else if (value is int intValue) {
        //        if (intValue == -32767) {
        //            //  @jesoe UNKNOWN not allowed in list!
        //            //result.Add((TEnum)(object)-1);
        //        }
        //        else if (!validEnumValues!.Contains<int>(intValue)) {
        //            //throw new ArgumentException($"Cannot convert enum value. Invalid integer value for enum {typeof(TEnum).Name}: {intValue} on {typeof(TType).Name} not in validEnumValues:{string.Join(",", validEnumValues)}");
        //            Logger.Current.DataError(-1, string.Empty, "enumvalues", $"Invalid integer value for enum {typeof(TEnum).Name}: {intValue} not in validEnumValues:{validEnumValues}");
        //        }
        //        else if (Enum.IsDefined(typeof(TEnum), intValue)) {
        //            result.Add((TEnum)(object)intValue);
        //        }
        //        else {
        //            throw new ArgumentException($"Invalid integer value for enum {typeof(TEnum).Name}: {intValue}");
        //        }
        //    }
        //    else {
        //        throw new ArgumentException($"Value must be of type string or int. Provided value type: {value.GetType().Name}");
        //    }

        //    return result;
        //}
    }
}






