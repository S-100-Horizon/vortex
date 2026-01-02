using S100Framework.AttributeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace S100Framework.WPF
{
    public class ItemsControlTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? DefaultItemControlTemplate { get; set; } = default;
        public DataTemplate? ComplexItemControlTemplate { get; set; } = default;

        public DataTemplate? FeatureTypeControlTemplate { get; set; } = default;

        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            if (item is ComplexAttribute complextAttribute) {
                return ComplexItemControlTemplate!;
            }
            if (item is FeatureType featureType) {
                return FeatureTypeControlTemplate!;
            }

            return DefaultItemControlTemplate!; // Default
        }
    }
}
