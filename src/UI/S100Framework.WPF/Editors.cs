using S100Framework.DomainModel.S124;
using S100Framework.DomainModel.S124.FeatureTypes;
using System;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Xceed.Wpf.Toolkit;

namespace S100Framework.WPF.Editors
{
    public sealed class CodeListComboEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem) {
            var comboBox = new ComboBox {
                Name = $"_comboBox{Guid.NewGuid():N}",
                DisplayMemberPath = "label",
            };

            var attribute = (S100Framework.DomainModel.CodeListAttribute)propertyItem.Instance.GetType().GetProperty(propertyItem.DisplayName)!.GetCustomAttributes(typeof(S100Framework.DomainModel.CodeListAttribute), true)[0];

            var bindingItemsSourceProperty = new Binding(attribute.PropertyName) { Source = propertyItem.Instance, Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(comboBox, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

            var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
            BindingOperations.SetBinding(comboBox, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);

            return comboBox;
        }
    }

    public sealed class CodeListCheckComboEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem) {
            var checkComboBox = new CheckComboBox {
                Name = $"_checkComboBox{Guid.NewGuid():N}",
                IsEditable = false,
                IsSelectAllActive = true,
                IsDropDownOpen = false,
                DisplayMemberPath = "label",
            };

            var attribute = (S100Framework.DomainModel.CodeListAttribute)propertyItem.Instance.GetType().GetProperty(propertyItem.DisplayName)!.GetCustomAttributes(typeof(S100Framework.DomainModel.CodeListAttribute), true)[0];

            var bindingItemsSourceProperty = new Binding(attribute.PropertyName) { Source = propertyItem.Instance, Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(checkComboBox, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

            var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
            BindingOperations.SetBinding(checkComboBox, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);

            return checkComboBox;
        }
    }

    public sealed class BindingConnectorEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        //public DomainModel.Bindings.informationBinding[] informationBindingsItems => new DomainModel.Bindings.informationBinding[] {
        //        NAVWARNPart.headerNAVWARNPreamble,
        //    };

        public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem) {            
            //if (propertyItem.DisplayName.EndsWith("Binding")) {
            //    var comboBox = new ComboBox {
            //        Name = $"_comboBox{Guid.NewGuid():N}",
            //        DisplayMemberPath = "association.Name",
            //    };

            //    var bindingItemsSourceProperty = new Binding() { Source = informationBindingsItems, Mode = BindingMode.OneWay };
            //    BindingOperations.SetBinding(comboBox, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

            //    return comboBox;
            //}

            var text = propertyItem.DisplayName;

            var connector = (dynamic)propertyItem.Instance;

            if (connector.informationBinding is null)
                text += " null";
            return new Label {
                Content = text,
                IsEnabled = true,
            };
        }
    }
}
