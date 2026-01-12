using S100FC;
using S100Framework.WPF.ViewModel;
using System.Globalization;
using System.Reflection;
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
            if(value is SimpleAttributeViewModel simpleAttributeViewModel) {
                if (simpleAttributeViewModel._attribute is EnumerationAttribute propertyValue) {
                    var method = propertyValue.GetType().GetMethod("get_listedValues", BindingFlags.Public | BindingFlags.Static);
                    return method!.Invoke(null, new object[] { /* parameters */ });
                }
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
            if (value is ComplexAttributeViewModel complexAttribute) {
                return complexAttribute;
                //var selectedObject = new ComplexAttributeViewModel(complexAttribute);
                //return selectedObject;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

    }
}