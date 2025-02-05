using Serilog;
using System;
using System.Reflection;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit.PropertyGrid;

namespace VortexProAppModule.Views
{
    /// <summary>
    /// Interaction logic for S100AttributeTabView.xaml
    /// </summary>
    public partial class S100AttributeTabView : UserControl /*ArcGIS.Desktop.Framework.Controls.ProWindow*/
    {
        private ILogger _logger = Logger.Current;

        public S100AttributeTabView() {
            InitializeComponent();
        }

        protected virtual void OnSelectedObjectChanged(object oldValue, object newValue) {
            if (oldValue == newValue)
                return;
        }

        private void _propertyGrid_PropertyValueChanged(object sender, Xceed.Wpf.Toolkit.PropertyGrid.PropertyValueChangedEventArgs e) {

        }

        private void _propertyGrid_PreparePropertyItem(object sender, Xceed.Wpf.Toolkit.PropertyGrid.PropertyItemEventArgs e) {
            _logger.Verbose("PreparePropertyItem: {PropertyName}", e.PropertyItem.DisplayName);

            var displayName = e.PropertyItem.DisplayName;

            var propertyItem = e.Item as Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem;
            if (propertyItem == null)
                return;

            if (propertyItem.PropertyType.IsInterface)  // IViewModelHost
                return;

            if (!propertyItem.PropertyType.IsAbstract) {
                if (!propertyItem.PropertyType.IsValueType && propertyItem.PropertyType != typeof(string) && !propertyItem.PropertyType.IsArray && !"System.Collections.Generic".Equals(propertyItem.PropertyType.Namespace)) {

                    var attribute = propertyItem.Instance.GetType().GetProperty(displayName)!.GetCustomAttribute<S100Framework.DomainModel.CodeListAttribute>();

                    //propertyItem.IsExpandable = attribute is null ? !"System.Collections.ObjectModel".Equals(propertyItem.PropertyType.Namespace) : false;
                    if (propertyItem.Value == null) {
                        propertyItem.Value = Activator.CreateInstance(propertyItem.PropertyType);
                    }
                }
            }
        }

        private void _propertyGrid_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            //_logger.Verbose("PropertyChanged: {PropertyName}", e.PropertyName);
        }

        private void _propertyGrid_SelectedPropertyItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<PropertyItemBase> e) {
            //_logger.Verbose("PreparePropertyItem: {PropertyName}", e.NewValue.DisplayName);
        }

        private void _propertyGrid_SelectedObjectChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e) {
            //_logger.Verbose("SelectedObjectChanged:");
        }
    }
}
