using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit.PropertyGrid;

namespace VortexConceptApplication
{
    /// <summary>
    /// Interaction logic for S100AttributeEditorView.xaml
    /// </summary>
    public partial class S100AttributeEditorView : UserControl
    {
        public S100AttributeEditorView() {
            InitializeComponent();
        }

        public static readonly DependencyProperty SelectedPropertyProperty =
            DependencyProperty.Register("SelectedPropertyObject", typeof(object), typeof(S100AttributeEditorView), new UIPropertyMetadata(null, OnSelectedPropertyChanged));

        public object SelectedPropertyObject {
            get {
                return (object)GetValue(SelectedPropertyProperty);
            }
            set {
                SetValue(SelectedPropertyProperty, value);
            }
        }

        private static void OnSelectedPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args) {
            var propertyGrid = sender as S100AttributeEditorView;
            if (propertyGrid != null) {
                //propertyGrid.OnSelectedPropertyChanged((object)args.OldValue, (object)args.NewValue);
            }
        }
    }
}
