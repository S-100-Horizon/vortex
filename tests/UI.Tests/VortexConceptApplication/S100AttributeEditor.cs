using S100Framework.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.Zoombox;

namespace VortexConceptApplication
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:VortexConceptApplication"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:VortexConceptApplication;assembly=VortexConceptApplication"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:S100AttributeEditor/>
    ///
    /// </summary>

    public class AssociationIdRequestEventArgs : RoutedEventArgs
    {
        public AssociationIdRequestEventArgs(string associationId) {
            AssociationId = associationId;
        }
        public string AssociationId { get; }
    }

    public delegate void AssociationIdRequestEventHandler(object sender, AssociationIdRequestEventArgs e);



    [TemplatePart(Name = PART_PropertyGrid, Type = typeof(Xceed.Wpf.Toolkit.PropertyGrid.PropertyGrid))]
    [TemplatePart(Name = PART_FeatureBindings, Type = typeof(ListView))]
    [TemplatePart(Name = PART_InformationBindings, Type = typeof(ListView))]
    [ContentProperty("Content")]
    public class S100AttributeEditor : Control
    {
        private const string PART_PropertyGrid = "PART_PropertyGrid";
        private const string PART_FeatureBindings = "PART_FeatureBindings";
        private const string PART_InformationBindings = "PART_InformationBindings";

        private PropertyGrid? _propertyGrid = default;
        public PropertyGrid? PropertyGrid {
            get {
                return _propertyGrid;
            }
            set {
                _propertyGrid = value;
            }
        }

        private ListView? _featureBindingsListView = default;
        public ListView? FeatureBindingsListView {
            get {
                return _featureBindingsListView;
            }
            set {
                _featureBindingsListView = value;
            }
        }

        private ListView? _informationBindingsListView = default;
        public ListView? InformationBindingsListView {
            get {
                return _informationBindingsListView;
            }
            set {
                _informationBindingsListView = value;
            }
        }

        static S100AttributeEditor() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(S100AttributeEditor), new FrameworkPropertyMetadata(typeof(S100AttributeEditor)));
        }

        public S100AttributeEditor() {
            this.InitCommands();

            if (System.Diagnostics.Debugger.IsAttached) {
                var binding = new FeatureBindingViewModel {
                    associationId = "AssociationId",
                    featureId = "FeatureId",
                    foreignId = "ForeignId",
                };
                binding.Load(new S100Framework.DomainModel.featureBinding {
                    roleType = "aggregation",
                    association = "TrafficSeparationSchemeAggregation",
                    role = "theCollection",
                    associationId = "AssociationId",
                    featureId = "FeatureId",
                    foreignId = "ForeignId",
                });

                _featureBindings.Add(binding);
            }
        }

        private void InitCommands() {

            var binding = new CommandBinding(S100AttributeEditor.UpdateAssociationIds, this.UpdateAssociationIdsContent);
            this.CommandBindings.Add(binding);
        }

        public override void OnApplyTemplate() {
            base.OnApplyTemplate();

            PropertyGrid = (PropertyGrid)GetTemplateChild(PART_PropertyGrid);

            FeatureBindingsListView = (ListView)GetTemplateChild(PART_FeatureBindings);
            FeatureBindingsListView.ItemsSource = _featureBindings;

            InformationBindingsListView = (ListView)GetTemplateChild(PART_InformationBindings);
            InformationBindingsListView.ItemsSource = _informationBindings;
        }


        public static readonly DependencyProperty SelectedNodeObject =
            DependencyProperty.Register("SelectedNode", typeof(object), typeof(S100AttributeEditor), new UIPropertyMetadata(null, OnSelectedNodeChanged));

        public object SelectedNode {
            get {
                return (object)GetValue(SelectedNodeObject);
            }
            set {
                SetValue(SelectedNodeObject, value);
            }
        }

        private static void OnSelectedNodeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args) {
            var control = sender as S100AttributeEditor;
            if (control != null) {
                //propertyGrid.OnSelectedPropertyChanged((object)args.OldValue, (object)args.NewValue);
            }
        }


        public static readonly RoutedEvent AssociationIdRequestEvent = EventManager.RegisterRoutedEvent("AssociationIdRequest", RoutingStrategy.Bubble, typeof(AssociationIdRequestEventHandler), typeof(S100AttributeEditor));

        public event AssociationIdRequestEventHandler AssociationIdRequest {
            add {
                this.AddHandler(S100AttributeEditor.AssociationIdRequestEvent, value);
            }
            remove {
                this.RemoveHandler(S100AttributeEditor.AssociationIdRequestEvent, value);
            }
        }


        public static RoutedUICommand UpdateAssociationIds = new("Request Association Ids", "UpdateAssociationIds", typeof(S100AttributeEditor));

        private void UpdateAssociationIdsContent(object sender, ExecutedRoutedEventArgs e) {
            System.Diagnostics.Debugger.Break();

        }


        private ObservableCollection<FeatureBindingViewModel> _featureBindings = new ObservableCollection<FeatureBindingViewModel>();

        private ObservableCollection<InformationBindingViewModel> _informationBindings = new ObservableCollection<InformationBindingViewModel>();
    }
}
