using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit.PropertyGrid;

namespace VortexProAppModule.Views
{
    /// <summary>
    /// Interaction logic for S100AttributeEditorView.xaml
    /// </summary>
    public partial class S100AttributeEditorView : UserControl, INotifyPropertyChanged
    {
        public S100AttributeEditorView() {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingFiled, T value, [CallerMemberName] string? propertyName = null) {
            if (string.IsNullOrWhiteSpace(propertyName)) return;

            if (EqualityComparer<T>.Default.Equals(backingFiled, value)) return;
            backingFiled = value;
            OnPropertyChanged(propertyName);
        }

        #region SelectedObject

        public static readonly DependencyProperty SelectedObjectProperty = DependencyProperty.Register("SelectedPropertyObject", typeof(object), typeof(S100AttributeEditorView), new UIPropertyMetadata(null, OnSelectedPropertyObjectChanged));
        public object SelectedPropertyObject {
            get {
                return (object)GetValue(SelectedObjectProperty);
            }
            set {
                SetValue(SelectedObjectProperty, value);
            }
        }

        private static void OnSelectedPropertyObjectChanged(DependencyObject o, DependencyPropertyChangedEventArgs e) {
            var propertyInspector = o as S100AttributeEditorView;
            if (propertyInspector != null) {

            }

            //PropertyGrid propertyInspector = o as PropertyGrid;
            //if (propertyInspector != null)
            //    propertyInspector.OnSelectedObjectChanged((object)e.OldValue, (object)e.NewValue);
        }

        #endregion //SelectedObject

        private void _propertyGrid_PropertyValueChanged(object sender, Xceed.Wpf.Toolkit.PropertyGrid.PropertyValueChangedEventArgs e) {

        }

        private void _propertyGrid_PreparePropertyItem(object sender, Xceed.Wpf.Toolkit.PropertyGrid.PropertyItemEventArgs e) {
            //var displayName = e.PropertyItem.DisplayName;

            //var propertyItem = e.Item as Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem;
            //if (propertyItem == null)
            //    return;

            //if (propertyItem.PropertyType.IsInterface)  // IViewModelHost
            //    return;

            //if (!propertyItem.PropertyType.IsAbstract) {
            //    if (!propertyItem.PropertyType.IsValueType && propertyItem.PropertyType != typeof(string) && !propertyItem.PropertyType.IsArray && !"System.Collections.Generic".Equals(propertyItem.PropertyType.Namespace)) {

            //        var attribute = propertyItem.Instance.GetType().GetProperty(displayName)!.GetCustomAttribute<S100Framework.DomainModel.CodeListAttribute>();

            //        //propertyItem.IsExpandable = attribute is null ? !"System.Collections.ObjectModel".Equals(propertyItem.PropertyType.Namespace) : false;
            //        if (propertyItem.Value == null) {
            //            propertyItem.Value = Activator.CreateInstance(propertyItem.PropertyType);
            //        }
            //    }
            //}
        }

        private void _propertyGrid_SelectedPropertyItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<PropertyItemBase> e) {
            //_logger.Verbose("PreparePropertyItem: {PropertyName}", e.NewValue.DisplayName);
        }
    }
}
