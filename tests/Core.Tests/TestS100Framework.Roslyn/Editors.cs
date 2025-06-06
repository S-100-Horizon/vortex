using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace S100Framework.WPF.Editors
{
    public class EnumComboBoxEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem) {
            var checkComboBox = new ComboBox {
                Name = $"_comboBox{Guid.NewGuid():N}",
                IsEditable = false,
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

    public class EnumCollectionEditor : ITypeEditor
    {
        private IList? _collection;
        private Type? _enumType;

        public FrameworkElement ResolveEditor(PropertyItem propertyItem) {
            // Get the underlying collection and enum type
            _collection = (IList)propertyItem.Value;
            _enumType = GetEnumType(propertyItem.PropertyType);

            // Create a stack panel to hold our controls
            var stackPanel = new StackPanel { Orientation = Orientation.Vertical };

            // Create a combo box for selecting new values
            var comboBox = new ComboBox {
                ItemsSource = Enum.GetValues(_enumType).Cast<object>(),
                Margin = new Thickness(0, 0, 0, 5)
            };

            // Create a button to add the selected value
            var addButton = new Button {
                Content = "Add",
                Margin = new Thickness(0, 0, 0, 10)
            };

            // Create a list box to display current values
            var listBox = new ListBox();

            // Initialize with current values
            foreach (var item in _collection) {
                listBox.Items.Add(item);
            }

            // Handle add button click
            addButton.Click += (sender, args) => {
                if (comboBox.SelectedItem != null) {
                    _collection.Add(comboBox.SelectedItem);
                    listBox.Items.Add(comboBox.SelectedItem);
                }
            };

            // Handle item removal
            listBox.KeyDown += (sender, args) => {
                if (args.Key == System.Windows.Input.Key.Delete && listBox.SelectedItem != null) {
                    _collection.Remove(listBox.SelectedItem);
                    listBox.Items.Remove(listBox.SelectedItem);
                }
            };

            // Add controls to the stack panel
            stackPanel.Children.Add(comboBox);
            stackPanel.Children.Add(addButton);
            stackPanel.Children.Add(listBox);

            return stackPanel;
        }

        private Type GetEnumType(Type collectionType) {
            // Handle ObservableCollection<T>
            if (collectionType.IsGenericType &&
                collectionType.GetGenericTypeDefinition() == typeof(ObservableCollection<>)) {
                return collectionType.GetGenericArguments()[0];
            }

            // Handle arrays
            if (collectionType.IsArray) {
                return collectionType.GetElementType()!;
            }

            throw new ArgumentException("Unsupported collection type");
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
