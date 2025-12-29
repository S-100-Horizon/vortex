using S100Framework.DomainModel;
using SelectorUI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Windows.UI.Text;

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
            if (value is SimpleAttributeValue propertyValue) {
                if (propertyValue.attributeBinding!.attribute is SimpleEnumerationAttribute simpleEnumerationAttribute) {
                    return simpleEnumerationAttribute.listedValues;
                    var underlyingType = typeof(S100Framework.DomainModel.S101.categoryOfLight);

                    //var underlyingType = Type.GetType($"S100Framework.DomainModel.S101.{simpleAttribute.Code}", true)!;
                    return propertyValue.attributeBinding.permitedValues!.Select(e => Enum.ToObject(underlyingType, e));
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

    public class S100AttributeEditorSourceConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if(value is ComplextAttributeValue complextAttributeValue) {
                var selectedObject = new SelectedObject {
                    code = complextAttributeValue.code,                    
                };

                if (complextAttributeValue.attributeBinding!.attribute is SimpleAttribute simpleAttribute) {
                    selectedObject.attributeBindings = [complextAttributeValue.attributeBinding];
                }
                if (complextAttributeValue.attributeBinding!.attribute is ComplextAttribute complextAttribute) {
                    selectedObject.attributeBindings = complextAttribute.subAttributeBindings;
                }

                selectedObject.AttributeValues= [.. complextAttributeValue.attributeValues];

                return selectedObject;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

    }
}