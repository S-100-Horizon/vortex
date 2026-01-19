using ABI.System;
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
    public class ItemsControlTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? DefaultItemControlTemplate { get; set; } = default;
        public DataTemplate? ComplexItemControlTemplate { get; set; } = default;

        //public DataTemplate? FeatureTypeControlTemplate { get; set; } = default;

        public override DataTemplate SelectTemplate(object item, DependencyObject container) {            
            if (item is ComplexAttributeViewModel complexAttribute) {
                return ComplexItemControlTemplate!;
            }
            if (item is FeatureType featureType) {
                throw new NotImplementedException();
            }
            return DefaultItemControlTemplate!;

            //if (container is FrameworkElement fe) {
            //    if (item is ComplexAttribute complexAttribute) {
            //        return (DataTemplate)fe.TryFindResource("ComplexItemControlTemplate");
            //    }
            //    if (item is FeatureType featureType) {
            //        throw new NotImplementedException();
            //    }

            //    return (DataTemplate)fe.TryFindResource("DefaultItemControlTemplate");
            //}

            throw new NotImplementedException();
        }
    }
}
