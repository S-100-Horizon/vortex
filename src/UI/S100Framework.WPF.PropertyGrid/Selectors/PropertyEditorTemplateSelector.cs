using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using S100Framework.WPF.Models;

namespace S100Framework.WPF.Selectors
{
    /// <summary>
    /// Selects the appropriate data template based on property type
    /// </summary>
    public class PropertyEditorTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? StringEditorTemplate { get; set; }
        public DataTemplate? NumberEditorTemplate { get; set; }
        public DataTemplate? BoolEditorTemplate { get; set; }
        public DataTemplate? EnumEditorTemplate { get; set; }
        public DataTemplate? DateTimeEditorTemplate { get; set; }
        public DataTemplate? ComplexTypeEditorTemplate { get; set; }
        public DataTemplate? CollectionEditorTemplate { get; set; }
        public DataTemplate? ReadOnlyEditorTemplate { get; set; }

        public override DataTemplate? SelectTemplate(object item, DependencyObject container)
        {
            if (item is not PropertyItem propItem)
                return base.SelectTemplate(item, container);

            // Check if read-only first
            if (propItem.IsReadOnly)
                return ReadOnlyEditorTemplate;

            Type propertyType = Nullable.GetUnderlyingType(propItem.PropertyType) ?? propItem.PropertyType;

            // Check for enum types (before collection check)
            if (propertyType.IsEnum)
            {
                return EnumEditorTemplate;
            }

            // Check for collection
            if (typeof(IList).IsAssignableFrom(propItem.PropertyType) && propItem.PropertyType != typeof(string))
            {
                return CollectionEditorTemplate;
            }

            // Check for complex types
            if (propItem.IsComplexType)
            {
                return ComplexTypeEditorTemplate;
            }

            // Primitive types
            if (propertyType == typeof(string))
                return StringEditorTemplate;

            if (propertyType == typeof(bool))
                return BoolEditorTemplate;

            if (propertyType == typeof(int) || propertyType == typeof(long) ||
                propertyType == typeof(short) || propertyType == typeof(byte) ||
                propertyType == typeof(double) || propertyType == typeof(float) ||
                propertyType == typeof(decimal))
                return NumberEditorTemplate;

            if (propertyType == typeof(DateTime) || propertyType == typeof(DateTimeOffset))
                return DateTimeEditorTemplate;

            // Default to string editor
            return StringEditorTemplate;
        }
    }
}
