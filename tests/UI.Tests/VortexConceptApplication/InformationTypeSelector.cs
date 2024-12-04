using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using Xceed.Wpf.Toolkit;

namespace VortexConceptApplication
{
    public sealed class InformationTypeSelectorEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem) {
            var attribute = (S100Framework.WPF.ViewModel.S901.WhereClauseAttribute)propertyItem.Instance.GetType().GetProperty(propertyItem.DisplayName)!.GetCustomAttributes(typeof(S100Framework.WPF.ViewModel.S901.WhereClauseAttribute), true)[0];

            //  SELECT ?

            var text = attribute.WhereClause;

            FrameworkElement comboBox;
            if (propertyItem.PropertyType.IsValueType) {
                comboBox = new ComboBox {
                    Name = $"_comboBox{Guid.NewGuid():N}",
                    IsEditable = false,
                    IsDropDownOpen = false,
                    DisplayMemberPath = "Label",
                    SelectedValuePath = "GlobalId",
                };
            }
            else {
                comboBox = new CheckComboBox {
                    Name = $"_comboBox{Guid.NewGuid():N}",
                    IsEditable = false,
                    IsDropDownOpen = false,
                    IsSelectAllActive = false,
                    DisplayMemberPath = "Label",
                    SelectedMemberPath = "GlobalId"
                    //SelectedValuePath = "GlobalId",
                };
            }


            //  TEST
            var selectedRows = new[] {
                new {
                    Code = "SpatialQuality",
                    GlobalId = Guid.Parse("C302DC37-2096-4129-85B4-E3B84E3CD079"),
                    Label = $"SpatialQuality: C302DC37-2096-4129-85B4-E3B84E3CD079",
                },
                new {
                    Code = "SpatialQuality",
                    GlobalId = Guid.Parse("F7EC985C-9743-4766-957A-EF3813A39883"),
                    Label = $"SpatialQuality: F7EC985C-9743-4766-957A-EF3813A39883",
                },
            };

            var bindingItemsSourceProperty = new Binding() { Source = selectedRows, Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(comboBox, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

            var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
            BindingOperations.SetBinding(comboBox, ComboBox.SelectedValueProperty, bindingSelectedItemProperty);

            return comboBox;
        }
    }
}
