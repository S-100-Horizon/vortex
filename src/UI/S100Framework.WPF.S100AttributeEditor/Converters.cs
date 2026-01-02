using S100Framework.AttributeModel;
using System.Globalization;
using System.Windows.Data;

namespace S100Framework.WPF.Converters
{
    /// <summary>
    /// Inverts a boolean value
    /// </summary>
    public class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is bool boolValue) {
                return !boolValue;
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is bool boolValue) {
                return !boolValue;
            }
            return true;
        }
    }

    /// <summary>
    /// Converts an enum type to its possible values
    /// </summary>
    public class EnumSourceConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is SimpleEnumerationAttribute propertyValue) {
                return propertyValue.listedValues;
            }
            if (value is Type type && type.IsEnum) {
                return Enum.GetValues(type);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class SelectedObjectSourceConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is ComplexAttribute complexAttribute) {
                var selectedObject = new SelectedObject {
                    code = complexAttribute.S100FC_name,                    
                };

                selectedObject.attributeBindings = complexAttribute.attributeBindings();

                selectedObject.attributeValues = [.. complexAttribute.attributes];

                return selectedObject;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

    }
}