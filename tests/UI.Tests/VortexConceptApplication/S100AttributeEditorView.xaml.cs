using S100Framework.DomainModel;
using S100Framework.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public record AssociationId(string Id);

    /// <summary>
    /// Interaction logic for S100AttributeEditorView.xaml
    /// </summary>
    public partial class S100AttributeEditorView : UserControl
    {
        public delegate Task<IEnumerable<AssociationId>> OnFeatureAssociationsChangedCallback(roleType roleType, string association);

        public S100AttributeEditorView() {            
            InitializeComponent();

            //this.DataContext = this;
            
        }


        public static readonly DependencyProperty SelectedProperty =
            DependencyProperty.Register("SelectedPropertyObject", typeof(object), typeof(S100AttributeEditorView), new UIPropertyMetadata(null, OnSelectedPropertyChanged));

        public object SelectedPropertyObject {
            get {
                return (object)GetValue(SelectedProperty);
            }
            set {
                SetValue(SelectedProperty, value);
            }
        }


        public OnFeatureAssociationsChangedCallback? OnFeatureAssociationsChanged { get; set; } = default;

        public void AddFeatureBinding() {
        }

        public ObservableCollection<FeatureBindingViewModel> FeatureBindings { get; set; } = new ObservableCollection<FeatureBindingViewModel>();

        public ObservableCollection<InformationBindingViewModel> InformationBindings { get; set; } = new ObservableCollection<InformationBindingViewModel>();

        private static void OnSelectedPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args) {
            var propertyGrid = sender as S100AttributeEditorView;
            if (propertyGrid != null) {
                //propertyGrid.OnSelectedPropertyChanged((object)args.OldValue, (object)args.NewValue);
            }
        }

        private async void _listViewFeatureBindings_SelectionChanged(object sender, SelectionChangedEventArgs e) {            
            if (OnFeatureAssociationsChanged is not null && e.AddedItems.Count > 0) {
                if (e.AddedItems[0] is not FeatureBindingViewModel)
                    return;
                var item = (e.AddedItems[0] as FeatureBindingViewModel)!;

                foreach(var i in item.AssociationIds.Where(x => x != item.associationId).ToArray()) {
                    item.AssociationIds.Remove(i);
                }

                var associationIds = await OnFeatureAssociationsChanged!(item.roleType!.Value, item.association!);

                foreach (var associationId in associationIds) {
                    item.AssociationIds.Add(associationId.Id);
                }
            }
        }

        private void _comboBox_DropDownOpened(object sender, EventArgs e) {

        }

        private void _associationIdDropDownButton_ContextMenuOpening(object sender, ContextMenuEventArgs e) {

        }

        private void _associationIdDropDownButton_Click(object sender, RoutedEventArgs e) {

        }
    }
}
