using S100Framework.DomainModel;
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.PropertyGrid;
using static VortexConceptApplication.QueryAssociationsEventArgs;

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

    public record AssociationId(string Id);

    public record FeatureId(string Code, string Id);

    public class QueryAssociationsEventArgs : RoutedEventArgs
    {
        public enum AssociationsType
        {
            InformationAssociations = 1,
            FeatureAssociations = 2,
        }

        public QueryAssociationsEventArgs(AssociationsType type, roleType? roleType, string? association, string? role, ICollection<AssociationId> associations, RoutedEvent routedEvent, object source) : base(routedEvent, source) {
            this.type = type;
            this.roleType = roleType ?? S100Framework.DomainModel.roleType.association;
            this.association = association ?? string.Empty;
            this.role = role ?? string.Empty;
            this.associations = associations;
        }

        public AssociationsType type { get; }
        public roleType? roleType { get; }
        public string? association { get; }
        public string? role { get; }
        public ICollection<AssociationId> associations { get; }
    }

    public delegate void QueryAssociationsEventHandler(object sender, QueryAssociationsEventArgs e);

    public class QueryFeaturesEventArgs : RoutedEventArgs
    {
        public QueryFeaturesEventArgs(roleType? roleType, string? association, string? role, ICollection<FeatureId> features, RoutedEvent routedEvent, object source) : base(routedEvent, source) {
            this.roleType = roleType ?? S100Framework.DomainModel.roleType.association;
            this.association = association ?? string.Empty;
            this.role = role ?? string.Empty;
            this.features = features;
        }

        public roleType? roleType { get; }
        public string? association { get; }
        public string? role { get; }
        public ICollection<FeatureId> features { get; }
    }

    public delegate void QueryFeaturesEventHandler(object sender, QueryFeaturesEventArgs e);

    [TemplatePart(Name = PART_PropertyGrid, Type = typeof(Xceed.Wpf.Toolkit.PropertyGrid.PropertyGrid))]
    [TemplatePart(Name = PART_FeatureBindings, Type = typeof(ListView))]
    [TemplatePart(Name = PART_InformationBindings, Type = typeof(ListView))]
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
                var bindingFeature = new FeatureBindingViewModel {
                    //associationId = "A0000",
                    //featureId = "FeatureId",
                    //foreignId = "ForeignId",
                };
                bindingFeature.Load(new featureBinding {
                    roleType = "aggregation",
                    association = "TrafficSeparationSchemeAggregation",
                    role = "theCollection",
                    associationId = "A0001",
                    featureId = "S0002",
                    foreignId = "S0003",
                });
                _featureBindings.Add(bindingFeature);

                var bindingInformation = new InformationBindingViewModel {
                };
                bindingInformation.Load(new informationBinding {
                    roleType = "association",
                    association = "AdditionalInformation",
                    role = "theInformation",
                    associationId = "A0010",
                    informationId = "I0001",
                    foreignId = "????"
                });
                _informationBindings.Add(bindingInformation);
            }
        }

        private void InitCommands() {

            CommandBinding binding;

            binding = new CommandBinding(S100AttributeEditor.FeatureAssociationSelectedCommand, this.FeatureAssociationSelectedContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditor.QueryAssociationsCommand, this.QueryAssociationsContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditor.AssociationIdLoaded, this.AssociationIdLoadedContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditor.QueryFeaturesCommand, this.QueryFeaturesContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditor.FeatureIdLoaded, this.FeatureIdLoadedContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditor.FeatureIdDoubleClick, this.FeatureIdDoubleClickContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditor.AddInformationBindingCommand, this.AddInformationBindingCommandContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditor.AddFeatureBindingCommand, this.AddFeatureBindingCommandContent);
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

        #region Associations

        public static readonly RoutedEvent QueryAssociationsEvent = EventManager.RegisterRoutedEvent("QueryAssociations", RoutingStrategy.Bubble, typeof(QueryAssociationsEventHandler), typeof(S100AttributeEditor));

        public event QueryAssociationsEventHandler QueryAssociations {
            add {
                this.AddHandler(S100AttributeEditor.QueryAssociationsEvent, value);
            }
            remove {
                this.RemoveHandler(S100AttributeEditor.QueryAssociationsEvent, value);
            }
        }


        public static RoutedUICommand QueryAssociationsCommand = new("Query association.", "QueryAssociationsCommand", typeof(S100AttributeEditor));

        private void QueryAssociationsContent(object sender, ExecutedRoutedEventArgs e) {
            _associationsDropdown.Clear();

            var eventArgs = ((ListViewItem)e.Parameter).Content switch {
                FeatureBindingViewModel model => new QueryAssociationsEventArgs(AssociationsType.FeatureAssociations, model.roleType, model.association, model.role, _associationsDropdown, QueryAssociationsEvent, this),
                InformationBindingViewModel model => new QueryAssociationsEventArgs(AssociationsType.InformationAssociations, model.roleType, model.association, model.role, _associationsDropdown, QueryAssociationsEvent, this),
                _ => throw new InvalidOperationException()
            };
            RaiseEvent(eventArgs);
        }

        public static RoutedUICommand AssociationIdLoaded = new("AssociationIdLoaded", "AssociationIdLoadedContent", typeof(S100AttributeEditor));

        private void AssociationIdLoadedContent(object sender, ExecutedRoutedEventArgs e) {
            var control = e.Parameter as ListBox;
            if (control != null) {
                control.ItemsSource = _associationsDropdown;
            }
        }

        private ObservableCollection<AssociationId> _associationsDropdown = new ObservableCollection<AssociationId>();

        #endregion

        #region Features

        public static RoutedUICommand FeatureAssociationSelectedCommand = new("Feature association selected.", "FeatureAssociationSelectedCommand", typeof(S100AttributeEditor));

        private void FeatureAssociationSelectedContent(object sender, ExecutedRoutedEventArgs e) {
            var model = (FeatureBindingViewModel)((ListViewItem)e.Parameter).Content;
        }


        public static readonly RoutedEvent QueryFeaturesEvent = EventManager.RegisterRoutedEvent("QueryFeatures", RoutingStrategy.Bubble, typeof(QueryFeaturesEventHandler), typeof(S100AttributeEditor));

        public event QueryFeaturesEventHandler QueryFeatures {
            add {
                this.AddHandler(S100AttributeEditor.QueryFeaturesEvent, value);
            }
            remove {
                this.RemoveHandler(S100AttributeEditor.QueryFeaturesEvent, value);
            }
        }


        public static RoutedUICommand QueryFeaturesCommand = new("Query features.", "QueryFeaturesCommand", typeof(S100AttributeEditor));

        private void QueryFeaturesContent(object sender, ExecutedRoutedEventArgs e) {
            _featuresDropdown.Clear();

            var model = (FeatureBindingViewModel)((ListViewItem)e.Parameter).Content;

            var eventArgs = new QueryFeaturesEventArgs(model.roleType, model.association, model.role, _featuresDropdown, QueryFeaturesEvent, this);
            RaiseEvent(eventArgs);
        }

        public static RoutedUICommand FeatureIdLoaded = new("FeatureIdLoaded", "FeatureIdLoadedContent", typeof(S100AttributeEditor));

        private void FeatureIdLoadedContent(object sender, ExecutedRoutedEventArgs e) {
            var control = e.Parameter as ListView;
            if (control != null) {
                control.ItemsSource = _featuresDropdown;
            }
        }

        public static RoutedUICommand FeatureIdDoubleClick = new("FeatureIdDoubleClick", "FeatureIdDoubleClickContent", typeof(S100AttributeEditor));

        private void FeatureIdDoubleClickContent(object sender, ExecutedRoutedEventArgs e) {
            var control = e.Parameter as ListView;
            if (control != null) {
                var selectedItem = (FeatureId)control.SelectedItem;

                var featureBinding = FeatureBindingsListView?.SelectedItem as FeatureBindingViewModel;
                if (featureBinding != null) {
                    featureBinding.foreignId = selectedItem.Id;
                }
            }
        }

        private ObservableCollection<FeatureId> _featuresDropdown = new ObservableCollection<FeatureId>();

        #endregion

        public static RoutedUICommand AddFeatureBindingCommand = new("Add feature binding.", "AddFeatureBindingCommandContent", typeof(S100AttributeEditor));

        private void AddFeatureBindingCommandContent(object sender, ExecutedRoutedEventArgs e) {
            _featureBindings.Add(new FeatureBindingViewModel {
            });
        }

        public static RoutedUICommand AddInformationBindingCommand = new("Add information binding.", "AddInformationBindingCommandContent", typeof(S100AttributeEditor));

        private void AddInformationBindingCommandContent(object sender, ExecutedRoutedEventArgs e) {
            _informationBindings.Add(new InformationBindingViewModel {
            });
        }

        private ObservableCollection<FeatureBindingViewModel> _featureBindings = new ObservableCollection<FeatureBindingViewModel>();

        private ObservableCollection<InformationBindingViewModel> _informationBindings = new ObservableCollection<InformationBindingViewModel>();
    }
}
