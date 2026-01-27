using S100Framework.WPF.ViewModel;
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

        public DataTemplate? FeatureBindingEditorTemplate { get; set; } = default;

        public override DataTemplate? SelectTemplate(object item, DependencyObject container) {
            if (item is DateAttributeViewModel dateAttribute) {
                if (dateAttribute.valueType.Equals("date"))
                    return this.DateOnlyEditorTemplate;
            }
            if (item is DateTimeAttributeViewModel dateTimeAttribute) {
                if (dateTimeAttribute.valueType.Equals("datetime"))
                    return this.DateTimeEditorTemplate;
            }
            if (item is SimpleAttributeViewModel simpleAttribute) {
                if (simpleAttribute.valueType.Equals("text"))
                    return this.TextEditorTemplate;
                if (simpleAttribute.valueType.Equals("boolean"))
                    return this.BooleanEditorTemplate;
                if (simpleAttribute.valueType.Equals("integer"))
                    return this.IntegerEditorTemplate;
                if (simpleAttribute.valueType.Equals("real"))
                    return this.RealEditorTemplate;
                if (simpleAttribute.valueType.Equals("S100_TruncatedDate"))
                    return this.TruncatedDateEditorTemplate;
                if (simpleAttribute.valueType.Equals("time"))
                    return this.TimeEditorTemplate;
                if (simpleAttribute.valueType.Equals("enumeration"))
                    return this.EnumEditorTemplate;
                if (System.Diagnostics.Debugger.IsAttached)
                    System.Diagnostics.Debugger.Break();
            }

            if (item is ComplexAttributeViewModel complextAttribute) {
                return this.ComplexEditorTemplate;
            }

            return this.TextEditorTemplate; // Default
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
