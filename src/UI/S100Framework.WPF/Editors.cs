using S100Framework.WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.PropertyGrid;
using static System.Net.Mime.MediaTypeNames;

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
            if (propertyItem.Instance is ViewModelBase) {

                var viewModel = (ViewModelBase)propertyItem.Instance;

                if (viewModel.Host is not null) {
                    var comboBox = new ComboBox {
                        Name = $"_comboBox{Guid.NewGuid():N}",
                        DisplayMemberPath = "Name",
                    };

                    var bindingItemsSourceProperty = new Binding() { Source = viewModel.Host.GetSource(propertyItem), Mode = BindingMode.OneWay };
                    BindingOperations.SetBinding(comboBox, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

                    return comboBox;
                }
            }
            var text = propertyItem.DisplayName;

            var connector = (dynamic)propertyItem.Instance;

            //if (connector.informationBinding is null)
            //    text += " null";
            return new Label {
                Content = text,
                IsEnabled = true,
            };
        }
    }

    public sealed class RefIdEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        public FrameworkElement ResolveEditor(PropertyItem propertyItem) {
            var text = propertyItem.DisplayName;

            return new Label {
                Content = text,
                IsEnabled = true,
            };
        }
    }

    public sealed class InformationTypeEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        public FrameworkElement ResolveEditor(PropertyItem propertyItem) {
            var text = ((Type)propertyItem.Value).Name;

            return new Label {
                Content = text,
                IsEnabled = true,
            };
        }
    }
    
}
