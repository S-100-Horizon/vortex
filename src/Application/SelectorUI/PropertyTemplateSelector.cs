using S100Framework.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace S100Framework.WPF
{
    public class PropertyTemplateSelector : DataTemplateSelector
    {
        public DataTemplate StringEditorTemplate { get; set; }
        public DataTemplate IntegerEditorTemplate { get; set; }
        public DataTemplate BooleanEditorTemplate { get; set; }
        public DataTemplate EnumEditorTemplate { get; set; }
        public DataTemplate ComplexEditorTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            if (item is SimpleAttribute simpleAttribute) {
                if (simpleAttribute.valueType.Equals("boolean"))
                    return BooleanEditorTemplate;
                if (simpleAttribute.valueType.Equals("integer"))
                    return IntegerEditorTemplate;
                if (simpleAttribute.valueType.Equals("enumeration"))
                    return EnumEditorTemplate;
            }

            if (item is ComplexAttribute complextAttribute) {
                return ComplexEditorTemplate;
            }

            return StringEditorTemplate; // Default
        }

        private static bool IsNumericType(Type type) {
            return type == typeof(int) || type == typeof(int?) ||
                   type == typeof(long) || type == typeof(long?) ||
                   type == typeof(short) || type == typeof(short?) ||
                   type == typeof(byte) || type == typeof(byte?) ||
                   type == typeof(uint) || type == typeof(uint?) ||
                   type == typeof(ulong) || type == typeof(ulong?) ||
                   type == typeof(ushort) || type == typeof(ushort?) ||
                   type == typeof(sbyte) || type == typeof(sbyte?);
        }

        /*
                            type == typeof(float) || type == typeof(float) ||
                           type == typeof(double) ||
                           type == typeof(decimal);
        * 
         */

    }
}
