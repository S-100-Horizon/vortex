using S100Framework.DomainModel;
using S100Framework.WPF.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.PropertyGrid;
using static VortexConceptApplication.QueryAssociationsEventArgs;

namespace VortexConceptApplication
{

    public record AssociationId(string Id);

    public record InformationId(string Code, string Id);
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

    public class QueryInformationsEventArgs : RoutedEventArgs
    {
        public QueryInformationsEventArgs(roleType? roleType, string? association, string? role, ICollection<InformationId> informations, RoutedEvent routedEvent, object source) : base(routedEvent, source) {
            this.roleType = roleType ?? S100Framework.DomainModel.roleType.association;
            this.association = association ?? string.Empty;
            this.role = role ?? string.Empty;
            this.informations = informations;
        }

        public roleType? roleType { get; }
        public string? association { get; }
        public string? role { get; }
        public ICollection<InformationId> informations { get; }
    }

    public delegate void QueryInformationsEventHandler(object sender, QueryInformationsEventArgs e);

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

    public class QueryInformationEventArgs : RoutedEventArgs
    {
        public QueryInformationEventArgs(roleType? roleType, string? association, string? role, ICollection<FeatureId> features, RoutedEvent routedEvent, object source) : base(routedEvent, source) {
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

    public delegate void QueryInformationEventHandler(object sender, QueryInformationEventArgs e);

    public class S100AttributeEditorViewModel : INotifyPropertyChanged
    {
        private S100AttributeEditorViewModel(string code, object selectedObject) {
            this.Code = code;
            this.SelectedObject = selectedObject;
        }

        public S100AttributeEditorViewModel(InformationNode informationNode, InformationViewModel selectedObject) : this(informationNode.Code, selectedObject) {
            informationBindingDefinitions = selectedObject.informationBindingDefinitions;
        }

        public S100AttributeEditorViewModel(FeatureNode featureNode, FeatureViewModel selectedObject) : this(featureNode.Code, selectedObject) {
            informationBindingDefinitions = selectedObject.informationBindingDefinitions;
            featureBindingDefinitions = selectedObject.featureBindingDefinitions;
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

        public string Code { get; set; } = string.Empty;

        private object? _selectedObject;

        public object? SelectedObject {
            get {
                return _selectedObject;
            }

            set {
                SetValue(ref _selectedObject, value);
            }
        }

        public ICollection<informationBindingDefinition> informationBindingDefinitions { get; } = Enumerable.Empty<informationBindingDefinition>().ToList();

        public ICollection<featureBindingDefinition> featureBindingDefinitions { get; } = Enumerable.Empty<featureBindingDefinition>().ToList();


        public ObservableCollection<FeatureBindingViewModel> FeatureBindings = new ObservableCollection<FeatureBindingViewModel>();

        public ObservableCollection<InformationBindingViewModel> InformationBindings = new ObservableCollection<InformationBindingViewModel>();
    }

    [TemplatePart(Name = PART_PropertyGrid, Type = typeof(Xceed.Wpf.Toolkit.PropertyGrid.PropertyGrid))]
    [TemplatePart(Name = PART_FeatureBindings, Type = typeof(StackPanel))]
    [TemplatePart(Name = PART_InformationBindings, Type = typeof(StackPanel))]
    [TemplatePart(Name = PART_FeatureBindingDefinitions, Type = typeof(CheckComboBox))]
    [TemplatePart(Name = PART_InformationBindingDefinitions, Type = typeof(CheckComboBox))]
    [TemplatePart(Name = PART_FeatureBindingsList, Type = typeof(ListView))]
    [TemplatePart(Name = PART_InformationBindingsList, Type = typeof(ListView))]
    [ContentProperty("Content")]
    public class S100AttributeEditor : Control
    {
        private const string PART_PropertyGrid = "PART_PropertyGrid";
        private const string PART_InformationBindings = "PART_InformationBindings";
        private const string PART_FeatureBindings = "PART_FeatureBindings";
        private const string PART_InformationBindingDefinitions = "PART_InformationBindingDefinitions";
        private const string PART_FeatureBindingDefinitions = "PART_FeatureBindingDefinitions";
        private const string PART_InformationBindingsList = "PART_InformationBindingsList";
        private const string PART_FeatureBindingsList = "PART_FeatureBindingsList";
        


        private PropertyGrid? _propertyGrid = default;
        public PropertyGrid? PropertyGrid {
            get {
                return _propertyGrid;
            }
            set {
                _propertyGrid = value;
            }
        }

        private StackPanel? _informationBindingsStackPanel = default;
        public StackPanel? InformationBindingsStackPanel {
            get {
                return _informationBindingsStackPanel;
            }
            set {
                _informationBindingsStackPanel = value;
            }
        }

        private StackPanel? _featureBindingsStackPanel = default;
        public StackPanel? FeatureBindingsStackPanel {
            get {
                return _featureBindingsStackPanel;
            }
            set {
                _featureBindingsStackPanel = value;
            }
        }


        private ComboBox? _informationBindingDefinitionsCheckComboBox = default;
        public ComboBox? InformationBindingDefinitionsCheckComboBox {
            get {
                return _informationBindingDefinitionsCheckComboBox;
            }
            set {
                _informationBindingDefinitionsCheckComboBox = value;
            }
        }

        private ComboBox? _featureBindingDefinitionsCheckComboBox = default;
        public ComboBox? FeatureBindingDefinitionsCheckComboBox {
            get {
                return _featureBindingDefinitionsCheckComboBox;
            }
            set {
                _featureBindingDefinitionsCheckComboBox = value;
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

            //if (System.Diagnostics.Debugger.IsAttached) {
            //    var bindingFeature = new FeatureBindingViewModel {
            //        //associationId = "A0000",
            //        //featureId = "FeatureId",
            //        //foreignId = "ForeignId",
            //    };
            //    bindingFeature.Load(new featureBinding {
            //        roleType = "aggregation",
            //        association = "TrafficSeparationSchemeAggregation",
            //        role = "theCollection",
            //        associationId = "A0001",
            //        featureId = "S0002",
            //        foreignId = "S0003",
            //    });
            //    _featureBindings.Add(bindingFeature);

            //    var bindingInformation = new InformationBindingViewModel {
            //    };
            //    bindingInformation.Load(new informationBinding {
            //        roleType = "association",
            //        association = "AdditionalInformation",
            //        role = "theInformation",
            //        associationId = "A0010",
            //        informationId = "I0001",
            //        foreignId = "????"
            //    });
            //    _informationBindings.Add(bindingInformation);
            //}
        }

        private void InitCommands() {

            CommandBinding binding;

            binding = new CommandBinding(S100AttributeEditor.DropDownContextMenuOpeningCommand, this.DropDownContextMenuOpeningCommandContent);
            this.CommandBindings.Add(binding);

            //  Associations
            binding = new CommandBinding(S100AttributeEditor.QueryAssociationsCommand, this.QueryAssociationsContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditor.AssociationIdLoaded, this.AssociationIdLoadedContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditor.InformationAssociationIdDoubleClick, this.InformationAssociationIdDoubleClickContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditor.FeatureAssociationIdDoubleClick, this.FeatureAssociationIdDoubleClickContent);
            this.CommandBindings.Add(binding);


            //  InformationBindings
            binding = new CommandBinding(S100AttributeEditor.InformationAssociationSelectedCommand, this.InformationAssociationSelectedContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditor.QueryInformationsCommand, this.QueryInformationsContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditor.InformationIdLoaded, this.InformationIdLoadedContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditor.InformationIdDoubleClick, this.InformationIdDoubleClickContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditor.AddInformationBindingCommand, this.AddInformationBindingCommandContent);
            this.CommandBindings.Add(binding);


            //  FeatureBindings
            binding = new CommandBinding(S100AttributeEditor.FeatureAssociationSelectedCommand, this.FeatureAssociationSelectedContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditor.QueryFeaturesCommand, this.QueryFeaturesContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditor.FeatureIdLoaded, this.FeatureIdLoadedContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditor.FeatureIdDoubleClick, this.FeatureIdDoubleClickContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditor.AddFeatureBindingCommand, this.AddFeatureBindingCommandContent);
            this.CommandBindings.Add(binding);
        }

        public override void OnApplyTemplate() {
            base.OnApplyTemplate();

            PropertyGrid = (PropertyGrid)GetTemplateChild(PART_PropertyGrid);

            InformationBindingsStackPanel = (StackPanel)GetTemplateChild(PART_InformationBindings);
            FeatureBindingsStackPanel = (StackPanel)GetTemplateChild(PART_FeatureBindings);

            InformationBindingDefinitionsCheckComboBox = (ComboBox)GetTemplateChild(PART_InformationBindingDefinitions);
            FeatureBindingDefinitionsCheckComboBox = (ComboBox)GetTemplateChild(PART_FeatureBindingDefinitions);

            FeatureBindingsListView = (ListView)GetTemplateChild(PART_FeatureBindingsList);
            //FeatureBindingsListView.ItemsSource = _featureBindings;

            InformationBindingsListView = (ListView)GetTemplateChild(PART_InformationBindingsList);
            //InformationBindingsListView.ItemsSource = _informationBindings;

            InformationBindingDefinitionsCheckComboBox.SelectionChanged += (object sender, SelectionChangedEventArgs e) => {
                if (e.AddedItems.Count > 0) {
                    _informationBindingDefinitionSelected = e.AddedItems[0] as informationBindingDefinition;
                }
            };

            FeatureBindingDefinitionsCheckComboBox.SelectionChanged += (object sender, SelectionChangedEventArgs e) => {
                if (e.AddedItems.Count > 0) {
                    _featureBindingDefinitionSelected = e.AddedItems[0] as featureBindingDefinition;
                }
            };
        }

        private informationBindingDefinition? _informationBindingDefinitionSelected = default;
        private featureBindingDefinition? _featureBindingDefinitionSelected = default;


        public static readonly DependencyProperty S100AttributeEditorViewModel =
            DependencyProperty.Register("ViewModel", typeof(S100AttributeEditorViewModel), typeof(S100AttributeEditor), new UIPropertyMetadata(null, OnViewModelChanged));

        public S100AttributeEditorViewModel ViewModel {
            get {
                return (S100AttributeEditorViewModel)GetValue(S100AttributeEditorViewModel);
            }
            set {
                SetValue(S100AttributeEditorViewModel, value);
            }
        }

        private static void OnViewModelChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args) {
            var control = sender as S100AttributeEditor;
            if (control != null) {
                control.ViewModel.PropertyChanged += control.ViewModel_PropertyChanged;

                if (control.PropertyGrid != null) {
                    control.PropertyGrid.SelectedObject = control.ViewModel.SelectedObject;
                }
                if(control.FeatureBindingDefinitionsCheckComboBox != null) {
                    control.FeatureBindingDefinitionsCheckComboBox.ItemsSource = control.ViewModel.featureBindingDefinitions;
                    if (!control.ViewModel.featureBindingDefinitions.Any()) {
                        if (control.FeatureBindingsStackPanel != null)
                            control.FeatureBindingsStackPanel.Visibility = Visibility.Hidden;
                    }
                }
                if (control.FeatureBindingsListView != null) {
                    control.FeatureBindingsListView.ItemsSource = control.ViewModel.FeatureBindings;
                }
                if (control.InformationBindingDefinitionsCheckComboBox != null) {
                    control.InformationBindingDefinitionsCheckComboBox.ItemsSource = control.ViewModel.informationBindingDefinitions;

                    if (!control.ViewModel.informationBindingDefinitions.Any()) {
                        if(control.InformationBindingsStackPanel != null)
                            control.InformationBindingsStackPanel.Visibility = Visibility.Hidden;
                    }
                }
                if (control.InformationBindingsListView != null) {
                    control.InformationBindingsListView.ItemsSource = control.ViewModel.InformationBindings;
                }
            }
        }

        private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e) {
            switch (e.PropertyName) {
                case "SelectedObject":
                    if (this.PropertyGrid != null) {
                        this.PropertyGrid.SelectedObject = this.ViewModel.SelectedObject;
                    }
                    break;

                case "FeatureBindings":
                    if (this.FeatureBindingsListView != null) {
                        this.FeatureBindingsListView.ItemsSource = this.ViewModel.FeatureBindings;
                    }
                    break;

                case "InformationBindings":
                    if (this.InformationBindingsListView != null) {
                        this.InformationBindingsListView.ItemsSource = this.ViewModel.InformationBindings;
                    }
                    break;
            }
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

        private DropDownButton? _activeDropDownButton = default;

        public static RoutedUICommand DropDownContextMenuOpeningCommand = new("DropDownContextMenuOpeningCommand", "DropDownContextMenuOpeningCommand", typeof(S100AttributeEditor));

        private void DropDownContextMenuOpeningCommandContent(object sender, ExecutedRoutedEventArgs e) {
            _activeDropDownButton = (DropDownButton)e.Parameter;
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

        public static RoutedUICommand InformationAssociationIdDoubleClick = new("InformationAssociationIdDoubleClick", "InformationAssociationIdDoubleClick", typeof(S100AttributeEditor));

        private void InformationAssociationIdDoubleClickContent(object sender, ExecutedRoutedEventArgs e) {
            var control = e.Parameter as ListBox;
            if (control != null) {
                var selectedItem = (AssociationId)control.SelectedItem;

                var informationBinding = InformationBindingsListView?.SelectedItem as InformationBindingViewModel;
                if (informationBinding != null) {
                    informationBinding.associationId = selectedItem.Id;

                    if (_activeDropDownButton != null) {
                        _activeDropDownButton.IsOpen = false;
                    }
                }
            }
        }

        public static RoutedUICommand FeatureAssociationIdDoubleClick = new("FeatureAssociationIdDoubleClick", "FeatureAssociationIdDoubleClick", typeof(S100AttributeEditor));

        private void FeatureAssociationIdDoubleClickContent(object sender, ExecutedRoutedEventArgs e) {
            var control = e.Parameter as ListBox;
            if (control != null) {
                var selectedItem = (AssociationId)control.SelectedItem;

                var featureBinding = FeatureBindingsListView?.SelectedItem as FeatureBindingViewModel;
                if (featureBinding != null) {
                    featureBinding.associationId = selectedItem.Id;

                    if (_activeDropDownButton != null) {
                        _activeDropDownButton.IsOpen = false;
                    }
                }
            }
        }

        private ObservableCollection<AssociationId> _associationsDropdown = new ObservableCollection<AssociationId>();

        #endregion


        #region InformationBindings

        public static RoutedUICommand InformationAssociationSelectedCommand = new("Information association selected.", "InformationAssociationSelectedCommand", typeof(S100AttributeEditor));

        private void InformationAssociationSelectedContent(object sender, ExecutedRoutedEventArgs e) {
        }

        public static readonly RoutedEvent QueryInformationsEvent = EventManager.RegisterRoutedEvent("QueryInformations", RoutingStrategy.Bubble, typeof(QueryInformationsEventHandler), typeof(S100AttributeEditor));

        public event QueryInformationsEventHandler QueryInformations {
            add {
                this.AddHandler(S100AttributeEditor.QueryInformationsEvent, value);
            }
            remove {
                this.RemoveHandler(S100AttributeEditor.QueryInformationsEvent, value);
            }
        }

        public static RoutedUICommand QueryInformationsCommand = new("Query informations.", "QueryInformationsCommand", typeof(S100AttributeEditor));

        private void QueryInformationsContent(object sender, ExecutedRoutedEventArgs e) {
            _informationsDropdown.Clear();

            var model = (InformationBindingViewModel)((ListViewItem)e.Parameter).Content;

            var eventArgs = new QueryInformationsEventArgs(model.roleType, model.association, model.role, _informationsDropdown, QueryInformationsEvent, this);
            RaiseEvent(eventArgs);
        }

        public static RoutedUICommand InformationIdLoaded = new("InformationIdLoaded", "InformationIdLoadedContent", typeof(S100AttributeEditor));

        private void InformationIdLoadedContent(object sender, ExecutedRoutedEventArgs e) {
            var control = e.Parameter as ListView;
            if (control != null) {
                control.ItemsSource = _informationsDropdown;
            }
        }

        public static RoutedUICommand InformationIdDoubleClick = new("InformationIdDoubleClick", "InformationIdDoubleClickContent", typeof(S100AttributeEditor));

        private void InformationIdDoubleClickContent(object sender, ExecutedRoutedEventArgs e) {
            var control = e.Parameter as ListView;
            if (control != null) {
                var selectedItem = (InformationId)control.SelectedItem;

                if (selectedItem != null) {
                    var informationBinding = InformationBindingsListView?.SelectedItem as InformationBindingViewModel;
                    if (informationBinding != null) {
                        informationBinding.foreignId = selectedItem.Id;

                        if (_activeDropDownButton != null) {
                            _activeDropDownButton.IsOpen = false;
                        }
                    }
                }
            }
        }

        private ObservableCollection<InformationId> _informationsDropdown = new ObservableCollection<InformationId>();

        public static RoutedUICommand AddInformationBindingCommand = new("Add information binding.", "AddInformationBindingCommandContent", typeof(S100AttributeEditor));

        private void AddInformationBindingCommandContent(object sender, ExecutedRoutedEventArgs e) {
            if (_informationBindingDefinitionSelected != null) {
                var binding = new informationBinding {
                    roleType = Enum.GetName<roleType>(_informationBindingDefinitionSelected.roleType),
                    association = _informationBindingDefinitionSelected.association,
                    role = _informationBindingDefinitionSelected.role,
                };

                ViewModel.InformationBindings.Add(new InformationBindingViewModel {
                    // foreeignId = ME
                }.Load(binding));
            }
        }

        #endregion


        #region FeatureBindingss

        public static RoutedUICommand FeatureAssociationSelectedCommand = new("Feature association selected.", "FeatureAssociationSelectedCommand", typeof(S100AttributeEditor));

        private void FeatureAssociationSelectedContent(object sender, ExecutedRoutedEventArgs e) {
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

                if (selectedItem != null) {
                    var featureBinding = FeatureBindingsListView?.SelectedItem as FeatureBindingViewModel;
                    if (featureBinding != null) {
                        featureBinding.foreignId = selectedItem.Id;

                        if (_activeDropDownButton != null) {
                            _activeDropDownButton.IsOpen = false;
                        }
                    }
                }
            }
        }

        private ObservableCollection<FeatureId> _featuresDropdown = new ObservableCollection<FeatureId>();

        public static RoutedUICommand AddFeatureBindingCommand = new("Add feature binding.", "AddFeatureBindingCommandContent", typeof(S100AttributeEditor));

        private void AddFeatureBindingCommandContent(object sender, ExecutedRoutedEventArgs e) {
            if (_featureBindingDefinitionSelected != null) {
                var binding = new featureBinding {
                    roleType = Enum.GetName<roleType>(_featureBindingDefinitionSelected.roleType),
                    association = _featureBindingDefinitionSelected.association,
                    role = _featureBindingDefinitionSelected.role,
                };

                ViewModel.FeatureBindings.Add(new FeatureBindingViewModel {
                    // foreeignId = ME
                }.Load(binding));
            }
        }

        #endregion


        //private ObservableCollection<FeatureBindingViewModel> _featureBindings = new ObservableCollection<FeatureBindingViewModel>();

        //private ObservableCollection<InformationBindingViewModel> _informationBindings = new ObservableCollection<InformationBindingViewModel>();
    }
}
