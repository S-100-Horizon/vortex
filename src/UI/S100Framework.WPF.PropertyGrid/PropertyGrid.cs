using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.PropertyGrid;

namespace S100Framework.WPF
{
    public class PropertyGrid : Control, INotifyPropertyChanged, INotifyCollectionChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public static readonly DependencyProperty SelectedFeatureObjectProperty =
                    DependencyProperty.Register("SelectedFeatureObject", typeof(object), typeof(PropertyGrid), new UIPropertyMetadata(null, OnSelectedFeatureChanged));

        public object? SelectedFeatureObject {
            get {
                return (object?)GetValue(SelectedFeatureObjectProperty);
            }
            set {
                SetValue(SelectedFeatureObjectProperty, value);
            }
        }

        private static void OnSelectedFeatureChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args) {
        }
    }
}
