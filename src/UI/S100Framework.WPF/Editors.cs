using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace S100Framework.WPF.Editors
{
    public sealed class TestEnumCheckComboEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.EnumCheckComboBoxEditor
    {

    }

    public class EnumArrayEditor : ITypeEditor
    {
        public FrameworkElement ResolveEditor(PropertyItem propertyItem) {

            // Create a stack panel to hold our controls
            var stackPanel = new StackPanel { Orientation = Orientation.Vertical };

            var attribute = (S100Framework.DomainModel.EnumerationAttribute)propertyItem.Instance.GetType().GetProperty(propertyItem.DisplayName)!.GetCustomAttributes(typeof(S100Framework.DomainModel.EnumerationAttribute), true)[0];

            // Get the enum type from the property
            //var enumType = propertyItem.PropertyType.GetElementType();

            // Create a combo box for selecting new values
            var comboBox = new ComboBox {
                Name = $"_comboBox{Guid.NewGuid():N}",
                //ItemsSource = Enum.GetValues(enumType).Cast<Enum>(),
                Margin = new Thickness(0, 0, 0, 5)
            };

            var bindingItemsSourceProperty = new Binding(attribute.PropertyName) { Source = propertyItem.Instance, Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(comboBox, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

            //var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
            //BindingOperations.SetBinding(comboBox, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);


            // Create a button to add the selected value
            var addButton = new Button {
                Content = "Add",
                Margin = new Thickness(0, 0, 0, 10)
            };

            // Create a list box to display current values
            var listBox = new ListBox();


            var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
            BindingOperations.SetBinding(listBox, ListBox.ItemsSourceProperty, bindingSelectedItemProperty);

            // Initialize with current values if they exist
            //if (propertyItem.Value is Array currentArray) {
            //    foreach (var item in currentArray) {
            //        listBox.Items.Add(item);
            //    }
            //}



            // Handle add button click
            addButton.Click += (sender, args) => {
                if (comboBox.SelectedItem != null) {
                    listBox.Items.Add(comboBox.SelectedItem);
                    //UpdatePropertyValue(propertyItem, listBox);
                }
            };

            // Handle item removal
            listBox.KeyDown += (sender, args) => {
                if (args.Key == System.Windows.Input.Key.Delete && listBox.SelectedItem != null) {
                    listBox.Items.Remove(listBox.SelectedItem);
                    UpdatePropertyValue(propertyItem, listBox);
                }
            };

            // Add controls to the stack panel
            stackPanel.Children.Add(comboBox);
            stackPanel.Children.Add(addButton);
            stackPanel.Children.Add(listBox);

            return stackPanel;
        }

        private void UpdatePropertyValue(PropertyItem propertyItem, ListBox listBox) {
            var attribute = (S100Framework.DomainModel.EnumerationAttribute)propertyItem.Instance.GetType().GetProperty(propertyItem.DisplayName)!.GetCustomAttributes(typeof(S100Framework.DomainModel.EnumerationAttribute), true)[0];

            // Convert the ListBox items back to an array
            var enumType = attribute.EnumType!;// propertyItem.PropertyType.GetElementType();
            var array = Array.CreateInstance(enumType, listBox.Items.Count);

            for (int i = 0; i < listBox.Items.Count; i++) {
                array.SetValue(listBox.Items[i], i);
            }



            propertyItem.Value = array;
        }
    }

    public sealed class EnumCheckComboEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem) {
            var checkComboBox = new CheckComboBox {
                Name = $"_checkComboBox{Guid.NewGuid():N}",
                IsEditable = false,
                IsSelectAllActive = true,
                IsDropDownOpen = false,
            };

            var attribute = (S100Framework.DomainModel.EnumerationAttribute)propertyItem.Instance.GetType().GetProperty(propertyItem.DisplayName)!.GetCustomAttributes(typeof(S100Framework.DomainModel.EnumerationAttribute), true)[0];

            var bindingItemsSourceProperty = new Binding(attribute.PropertyName) { Source = propertyItem.Instance, Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(checkComboBox, CheckComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

            var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
            BindingOperations.SetBinding(checkComboBox, CheckComboBox.SelectedItemProperty, bindingSelectedItemProperty);

            var value = checkComboBox.SelectedValue;

            //if (!string.IsNullOrEmpty(viewModel.RefId)) {
            //    checkComboBox.SelectedValue = viewModel.RefId;
            //}

            return checkComboBox;
        }
    }


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

    //public sealed class RefIdEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    //{
    //    public FrameworkElement ResolveEditor(PropertyItem propertyItem) {
    //        var source = propertyItem.Instance switch {
    //            FeatureRefIdViewModel e => e.RefIds,
    //            InformationRefIdViewModel e => e.RefIds,
    //            _ => throw new NotSupportedException()
    //        };

    //        var viewModel = (RefIdViewModel)propertyItem.Instance;

    //        var comboBox = new ComboBox {
    //            Name = $"_comboBox{Guid.NewGuid():N}",
    //            //DisplayMemberPath = "refId",
    //        };

    //        if (!string.IsNullOrEmpty(viewModel.RefId))
    //            source.Add(viewModel.RefId);

    //        var bindingItemsSourceProperty = new Binding() { Source = source, Mode = BindingMode.OneWay };
    //        BindingOperations.SetBinding(comboBox, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

    //        var bindingSelectedItemProperty = new Binding("RefId") { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
    //        BindingOperations.SetBinding(comboBox, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);

    //        if (!string.IsNullOrEmpty(viewModel.RefId)) {
    //            comboBox.SelectedValue = viewModel.RefId;
    //        }
    //        return comboBox;
    //    }
    //}

    //public sealed class InformationConnectorEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    //{
    //    public FrameworkElement ResolveEditor(PropertyItem propertyItem) {
    //        var viewModel = (InformationAssociationViewModel)propertyItem.Instance;

    //        var comboBox = new ComboBox {
    //            Name = $"_comboBox{Guid.NewGuid():N}",
    //            DisplayMemberPath = "DisplayName",
    //        };

    //        var bindingItemsSourceProperty = new Binding() { Source = viewModel.associationConnectorInformations, Mode = BindingMode.OneWay };
    //        BindingOperations.SetBinding(comboBox, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

    //        var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
    //        BindingOperations.SetBinding(comboBox, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);

    //        if (viewModel.association is not null) {
    //            comboBox.SelectedValue = viewModel.association;
    //        }
    //        return comboBox;
    //    }
    //}

    //public sealed class FeatureConnectorEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    //{
    //    public FrameworkElement ResolveEditor(PropertyItem propertyItem) {
    //        var viewModel = (FeatureAssociationViewModel)propertyItem.Instance;

    //        var comboBox = new ComboBox {
    //            Name = $"_comboBox{Guid.NewGuid():N}",
    //            DisplayMemberPath = "DisplayName",
    //        };

    //        var bindingItemsSourceProperty = new Binding() { Source = viewModel.associationConnectorFeatures, Mode = BindingMode.OneWay };
    //        BindingOperations.SetBinding(comboBox, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

    //        var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
    //        BindingOperations.SetBinding(comboBox, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);

    //        if (viewModel.association is not null) {
    //            comboBox.SelectedValue = viewModel.association;
    //        }
    //        return comboBox;
    //    }
    //}

    //public sealed class InformationBindingEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    //{
    //    public FrameworkElement ResolveEditor(PropertyItem propertyItem) {
    //        var viewModel = (InformationRefIdViewModel)propertyItem.Instance;

    //        var comboBox = new ComboBox {
    //            Name = $"_comboBox{Guid.NewGuid():N}",
    //        };

    //        var bindingItemsSourceProperty = new Binding() { Source = viewModel.AssociationTypes, Mode = BindingMode.OneWay };
    //        BindingOperations.SetBinding(comboBox, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

    //        var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
    //        BindingOperations.SetBinding(comboBox, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);

    //        if (viewModel.InformationType is not null) {
    //            comboBox.SelectedValue = viewModel.InformationType;
    //        }
    //        return comboBox;
    //    }
    //}

    //public sealed class FeatureBindingEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    //{
    //    public FrameworkElement ResolveEditor(PropertyItem propertyItem) {
    //        var viewModel = (FeatureRefIdViewModel)propertyItem.Instance;

    //        var comboBox = new ComboBox {
    //            Name = $"_comboBox{Guid.NewGuid():N}",
    //        };

    //        var bindingItemsSourceProperty = new Binding() { Source = viewModel.AssociationTypes, Mode = BindingMode.OneWay };
    //        BindingOperations.SetBinding(comboBox, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

    //        var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
    //        BindingOperations.SetBinding(comboBox, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);

    //        if (viewModel.FeatureType is not null) {
    //            comboBox.SelectedValue = viewModel.FeatureType;
    //        }
    //        return comboBox;
    //    }
    //}


    public static class Extensions
    {
        public static PropertyGrid FindRootPropertyGrid(this PropertyItemBase propertyItem) {
            if (propertyItem.ParentElement is PropertyGrid)
                return (PropertyGrid)propertyItem.ParentElement;
            return ((PropertyItemBase)propertyItem.ParentElement).FindRootPropertyGrid();
        }

        public static T? FindRoot<T>(this PropertyItem propertyItem) where T : class {
            if (propertyItem.Instance is T)
                return (T)propertyItem.Instance;
            if (propertyItem.ParentElement is null)
                return default;
            return ((PropertyItem)propertyItem.ParentElement).FindRoot<T>();
        }

    }
}
