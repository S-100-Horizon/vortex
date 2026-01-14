using S100FC;
using S100Framework.WPF.ViewModel;
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
        public DataTemplate? BooleanEditorTemplate { get; set; } = default;
        public DataTemplate? IntegerEditorTemplate { get; set; } = default;
        public DataTemplate? RealEditorTemplate { get; set; } = default;
        public DataTemplate? TextEditorTemplate { get; set; } = default;
        public DataTemplate? TruncatedDateEditorTemplate { get; set; } = default;
        public DataTemplate? DateOnlyEditorTemplate { get; set; } = default;
        public DataTemplate? DateTimeEditorTemplate { get; set; } = default;
        public DataTemplate? TimeEditorTemplate { get; set; } = default;
        public DataTemplate? EnumEditorTemplate { get; set; } = default;
        public DataTemplate? ComplexEditorTemplate { get; set; } = default;

        public override DataTemplate? SelectTemplate(object item, DependencyObject container) {
            if (item is SimpleAttributeViewModel simpleAttribute) {
                if (simpleAttribute.valueType.Equals("text"))
                    return TextEditorTemplate;
                if (simpleAttribute.valueType.Equals("boolean"))
                    return BooleanEditorTemplate;
                if (simpleAttribute.valueType.Equals("integer"))
                    return IntegerEditorTemplate;
                if (simpleAttribute.valueType.Equals("real"))
                    return RealEditorTemplate;
                if (simpleAttribute.valueType.Equals("S100_TruncatedDate"))
                    return TruncatedDateEditorTemplate;
                if (simpleAttribute.valueType.Equals("date"))
                    return DateOnlyEditorTemplate;
                if (simpleAttribute.valueType.Equals("datetime"))
                    return DateTimeEditorTemplate;
                if (simpleAttribute.valueType.Equals("time"))
                    return TimeEditorTemplate;
                if (simpleAttribute.valueType.Equals("enumeration"))
                    return EnumEditorTemplate;
                ;
            }

            if (item is ComplexAttributeViewModel complextAttribute) {
                return ComplexEditorTemplate;
            }

            return TextEditorTemplate; // Default
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
