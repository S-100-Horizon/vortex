using S100Framework.WPF.Models;
using S100Framework.WPF.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

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

        public DataTemplate? InformationRoleEditorTemplate { get; set; }
        public DataTemplate? InformationRefEditorTemplate { get; set; }
        public DataTemplate? InformationTypeEditorTemplate { get; set; }

        public DataTemplate? FeatureRoleEditorTemplate { get; set; }
        public DataTemplate? FeatureRefEditorTemplate { get; set; }
        public DataTemplate? FeatureTypeEditorTemplate { get; set; }

        public override DataTemplate? SelectTemplate(object item, DependencyObject container)
        {
            if (item is not PropertyItem propertyItem)
                return base.SelectTemplate(item, container);

            // Read-only properties get a special template
            if (propertyItem.IsReadOnly && propertyItem.IsSimpleType)
                return ReadOnlyEditorTemplate;

            // Collections
            if (propertyItem.IsCollection)
                return CollectionEditorTemplate;

            // Complex types
            if (propertyItem.IsComplexType)
                return ComplexTypeEditorTemplate;

            if (propertyItem.ParentObject is InformationRefViewModel informationRefViewModel) {
                return propertyItem.Name switch {
                    nameof(InformationRefViewModel.role) => InformationRoleEditorTemplate,
                    nameof(InformationRefViewModel.informationId)=> InformationRefEditorTemplate,
                    nameof(InformationRefViewModel.informationType)=> InformationTypeEditorTemplate,
                    _=>throw new InvalidOperationException(),
                };
            }
            else if (propertyItem.ParentObject is FeatureRefViewModel featureRefViewModel) {
                return propertyItem.Name switch {
                    nameof(FeatureRefViewModel.role) => FeatureRoleEditorTemplate,
                    nameof(FeatureRefViewModel.featureId) => FeatureRefEditorTemplate,
                    nameof(FeatureRefViewModel.featureType) => FeatureTypeEditorTemplate,
                    _ => throw new InvalidOperationException(),
                };
            }

            // Simple types
            Type propertyType = Nullable.GetUnderlyingType(propertyItem.PropertyType) ?? propertyItem.PropertyType;

            if (propertyType == typeof(bool))
                return BoolEditorTemplate;

            if (propertyType.IsEnum)
                return EnumEditorTemplate;

            if (propertyType == typeof(DateTime))
                return DateTimeEditorTemplate;

            if (IsNumericType(propertyType))
                return NumberEditorTemplate;

            if (propertyType == typeof(string))
                return StringEditorTemplate;

            // Default to string editor
            return StringEditorTemplate;
        }

        private bool IsNumericType(Type type)
        {
            return type == typeof(int) ||
                   type == typeof(long) ||
                   type == typeof(short) ||
                   type == typeof(byte) ||
                   type == typeof(uint) ||
                   type == typeof(ulong) ||
                   type == typeof(ushort) ||
                   type == typeof(sbyte) ||
                   type == typeof(float) ||
                   type == typeof(double) ||
                   type == typeof(decimal);
        }
    }
}
