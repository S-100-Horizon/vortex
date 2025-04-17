using S100Framework.DomainModel;
using S100Framework.WPF.ViewModel;
using System.Collections.ObjectModel;
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
    public record AssociationId(string Id);
    public record InformationTypeId(string Code, string Id);
    public record FeatureTypeId(string Code, string Id);

    #region EventArgs

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

    public class QueryInformationTypesEventArgs : RoutedEventArgs
    {
        public QueryInformationTypesEventArgs(roleType? roleType, string? association, string? role, ICollection<InformationTypeId> informations, RoutedEvent routedEvent, object source) : base(routedEvent, source) {
            this.roleType = roleType ?? S100Framework.DomainModel.roleType.association;
            this.association = association ?? string.Empty;
            this.role = role ?? string.Empty;
            this.informations = informations;
        }

        public roleType? roleType { get; }
        public string? association { get; }
        public string? role { get; }
        public ICollection<InformationTypeId> informations { get; }
    }

    public class QueryFeatureTypesEventArgs : RoutedEventArgs
    {
        public QueryFeatureTypesEventArgs(roleType? roleType, string? association, string? role, ICollection<FeatureTypeId> features, RoutedEvent routedEvent, object source) : base(routedEvent, source) {
            this.roleType = roleType ?? S100Framework.DomainModel.roleType.association;
            this.association = association ?? string.Empty;
            this.role = role ?? string.Empty;
            this.features = features;
        }

        public roleType? roleType { get; }
        public string? association { get; }
        public string? role { get; }
        public ICollection<FeatureTypeId> features { get; }
    }

    #endregion

    public delegate void QueryAssociationsEventHandler(object sender, QueryAssociationsEventArgs e);

    public delegate void QueryInformationTypessEventHandler(object sender, QueryInformationTypesEventArgs e);

    public delegate void QueryFeatureTypesEventHandler(object sender, QueryFeatureTypesEventArgs e);

    public abstract class SelectedObjectViewModel : INotifyPropertyChanged, INotifyCollectionChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        protected void OnPropertyChanged(object? sender, PropertyChangedEventArgs e) {
            this.PropertyChanged?.Invoke(sender, e);
        }

        protected void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) {
            this.CollectionChanged?.Invoke(sender, e);
        }
    }

    public class SelectedInformationTypeObjectViewModel : SelectedObjectViewModel
    {
        public SelectedInformationTypeObjectViewModel(InformationViewModel informationObject, IInformationBindingDefinition informationBinding) {
            this.InformationObject = informationObject;
            this.InformationBinding = informationBinding;

            this.InformationObject.PropertyChanged += base.OnPropertyChanged;

            this.InformationBindings.CollectionChanged += this.OnInformationBindings_CollectionChanged;
        }

        public InformationViewModel InformationObject { get; private set; }

        public IInformationBindingDefinition InformationBinding { get; private set; }

        public ObservableCollection<InformationBindingViewModel> InformationBindings = new ObservableCollection<InformationBindingViewModel>();

        protected void OnInformationBindings_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) {
            if (e.OldItems != null) {
                foreach (var i in e.OldItems) {
                    ((InformationBindingViewModel)i).PropertyChanged -= OnPropertyChanged;
                }
            }
            if (e.NewItems != null) {
                foreach (var i in e.NewItems) {
                    ((InformationBindingViewModel)i).PropertyChanged += OnPropertyChanged;
                }
            }
            base.OnCollectionChanged(sender, e);
        }
    }

    public class SelectedFeatureTypeObjectViewModel : SelectedObjectViewModel
    {
        public SelectedFeatureTypeObjectViewModel(FeatureViewModel featureObject, IFeatureBindingDefinition featureBinding) {
            this.FeatureObject = featureObject;
            this.FeatureBinding = featureBinding;

            this.FeatureObject.PropertyChanged += base.OnPropertyChanged;
            this.InformationBindings.CollectionChanged += this.OnInformationBindings_CollectionChanged;
            this.FeatureBindings.CollectionChanged += this.OnFeatureBindings_CollectionChanged;
        }

        public FeatureViewModel FeatureObject { get; private set; }

        public IFeatureBindingDefinition FeatureBinding { get; private set; }

        public ObservableCollection<FeatureBindingViewModel> FeatureBindings = new ObservableCollection<FeatureBindingViewModel>();

        public ObservableCollection<InformationBindingViewModel> InformationBindings = new ObservableCollection<InformationBindingViewModel>();

        protected void OnInformationBindings_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) {
            if (e.OldItems != null) {
                foreach (var i in e.OldItems) {
                    ((InformationBindingViewModel)i).PropertyChanged -= OnPropertyChanged;
                }
            }
            if (e.NewItems != null) {
                foreach (var i in e.NewItems) {
                    ((InformationBindingViewModel)i).PropertyChanged += OnPropertyChanged;
                }
            }
            base.OnCollectionChanged(sender, e);
        }

        protected void OnFeatureBindings_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) {
            if (e.OldItems != null) {
                foreach (var i in e.OldItems) {
                    ((FeatureBindingViewModel)i).PropertyChanged -= OnPropertyChanged;
                }
            }
            if (e.NewItems != null) {
                foreach (var i in e.NewItems) {
                    ((FeatureBindingViewModel)i).PropertyChanged += OnPropertyChanged;
                }
            }
            base.OnCollectionChanged(sender, e);
        }
    }

    public class SelectedAssociationObjectViewModel : SelectedObjectViewModel
    {
        public SelectedAssociationObjectViewModel(AssociationViewModel associationObject) {
            this.AssociationObject = associationObject;
        }

        public AssociationViewModel AssociationObject { get; private set; }
    }

    [TemplatePart(Name = PART_PropertyGrid, Type = typeof(Xceed.Wpf.Toolkit.PropertyGrid.PropertyGrid))]
    [TemplatePart(Name = PART_FeatureBindings, Type = typeof(StackPanel))]
    [TemplatePart(Name = PART_InformationBindings, Type = typeof(StackPanel))]
    [TemplatePart(Name = PART_FeatureBindingDefinitions, Type = typeof(CheckComboBox))]
    [TemplatePart(Name = PART_InformationBindingDefinitions, Type = typeof(CheckComboBox))]
    [TemplatePart(Name = PART_FeatureBindingsList, Type = typeof(ListView))]
    [TemplatePart(Name = PART_InformationBindingsList, Type = typeof(ListView))]
    [ContentProperty("Content")]
    public class S100AttributeEditorControl : Control, INotifyPropertyChanged, INotifyCollectionChanged
    {
        private const string PART_PropertyGrid = "PART_PropertyGrid";
        private const string PART_InformationBindings = "PART_InformationBindings";
        private const string PART_FeatureBindings = "PART_FeatureBindings";
        private const string PART_InformationBindingDefinitions = "PART_InformationBindingDefinitions";
        private const string PART_FeatureBindingDefinitions = "PART_FeatureBindingDefinitions";
        private const string PART_InformationBindingsList = "PART_InformationBindingsList";
        private const string PART_FeatureBindingsList = "PART_FeatureBindingsList";


        private informationBindingDefinition? InformationBindingDefinitionSelected { get; set; } = default;
        private featureBindingDefinition? FeatureBindingDefinitionSelected { get; set; } = default;

        private PropertyGrid? PropertyGrid { get; set; } = default;
        private StackPanel? InformationBindingsStackPanel { get; set; } = default;
        private StackPanel? FeatureBindingsStackPanel { get; set; } = default;
        private ComboBox? InformationBindingDefinitionsCheckComboBox { get; set; } = default;
        private ComboBox? FeatureBindingDefinitionsCheckComboBox { get; set; } = default;
        private ListView? FeatureBindingsListView { get; set; } = default;
        private ListView? InformationBindingsListView { get; set; } = default;

        public event PropertyChangedEventHandler? PropertyChanged;

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        static S100AttributeEditorControl() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(S100AttributeEditorControl), new FrameworkPropertyMetadata(typeof(S100AttributeEditorControl)));
        }

        public S100AttributeEditorControl() {
            this.InitCommands();
        }

        private void InitCommands() {

            CommandBinding binding;

            binding = new CommandBinding(S100AttributeEditorControl.DropDownContextMenuOpeningCommand, this.DropDownContextMenuOpeningCommandContent);
            this.CommandBindings.Add(binding);

            //  Associations
            binding = new CommandBinding(S100AttributeEditorControl.QueryAssociationsCommand, this.QueryAssociationsContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditorControl.AssociationIdLoaded, this.AssociationIdLoadedContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditorControl.InformationAssociationIdDoubleClick, this.InformationAssociationIdDoubleClickContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditorControl.FeatureAssociationIdDoubleClick, this.FeatureAssociationIdDoubleClickContent);
            this.CommandBindings.Add(binding);


            //  InformationBindings
            binding = new CommandBinding(S100AttributeEditorControl.InformationAssociationSelectedCommand, this.InformationAssociationSelectedContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditorControl.QueryInformationsCommand, this.QueryInformationsContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditorControl.InformationIdLoaded, this.InformationIdLoadedContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditorControl.InformationIdDoubleClick, this.InformationIdDoubleClickContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditorControl.AddInformationBindingCommand, this.AddInformationBindingCommandContent);
            this.CommandBindings.Add(binding);


            //  FeatureBindings
            binding = new CommandBinding(S100AttributeEditorControl.FeatureAssociationSelectedCommand, this.FeatureAssociationSelectedContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditorControl.QueryFeaturesCommand, this.QueryFeaturesContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditorControl.FeatureIdLoaded, this.FeatureIdLoadedContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditorControl.FeatureIdDoubleClick, this.FeatureIdDoubleClickContent);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(S100AttributeEditorControl.AddFeatureBindingCommand, this.AddFeatureBindingCommandContent);
            this.CommandBindings.Add(binding);
        }

        public override void OnApplyTemplate() {
            base.OnApplyTemplate();

            PropertyGrid = (PropertyGrid)GetTemplateChild(PART_PropertyGrid);
            PropertyGrid.IsEnabled = this.IsEditingEnabled;

            InformationBindingsStackPanel = (StackPanel)GetTemplateChild(PART_InformationBindings);
            InformationBindingsStackPanel.IsEnabled = this.IsEditingEnabled;

            FeatureBindingsStackPanel = (StackPanel)GetTemplateChild(PART_FeatureBindings);
            FeatureBindingsStackPanel.IsEnabled = this.IsEditingEnabled;

            InformationBindingDefinitionsCheckComboBox = (ComboBox)GetTemplateChild(PART_InformationBindingDefinitions);
            FeatureBindingDefinitionsCheckComboBox = (ComboBox)GetTemplateChild(PART_FeatureBindingDefinitions);

            InformationBindingsListView = (ListView)GetTemplateChild(PART_InformationBindingsList);
            //InformationBindingsListView.ItemsSource = this.InformationBindings;

            FeatureBindingsListView = (ListView)GetTemplateChild(PART_FeatureBindingsList);
            //FeatureBindingsListView.ItemsSource = this.FeatureBindings;

            InformationBindingDefinitionsCheckComboBox.SelectionChanged += (object sender, SelectionChangedEventArgs e) => {
                if (e.AddedItems.Count > 0) {
                    InformationBindingDefinitionSelected = e.AddedItems[0] as informationBindingDefinition;
                }
            };

            FeatureBindingDefinitionsCheckComboBox.SelectionChanged += (object sender, SelectionChangedEventArgs e) => {
                if (e.AddedItems.Count > 0) {
                    FeatureBindingDefinitionSelected = e.AddedItems[0] as featureBindingDefinition;
                }
            };
        }

        private object? _selectedObject = default;

        private ICollection<InformationBindingViewModel>? _selectedInformationBindings = default;
        private ICollection<FeatureBindingViewModel>? _selectedFeatureBindings = default;

        #region DependencyProperties       

        public static readonly DependencyProperty IsEditingEnabledProperty =
            DependencyProperty.Register("IsEditingEnabled", typeof(Boolean), typeof(S100AttributeEditorControl), new UIPropertyMetadata(false, IsEditingEnabledChanged));

        public Boolean IsEditingEnabled {
            get {
                return (Boolean)GetValue(IsEditingEnabledProperty);
            }
            set {
                SetValue(IsEditingEnabledProperty, value);
            }
        }

        private static void IsEditingEnabledChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args) {
            var control = sender as S100AttributeEditorControl;
            if (control is null)
                return;

            if (control.PropertyGrid != null) {
                control.PropertyGrid.IsEnabled = (Boolean)args.NewValue;
            }
            if (control.InformationBindingsStackPanel != null) {
                control.InformationBindingsStackPanel.IsEnabled = (Boolean)args.NewValue;
            }
            if (control.FeatureBindingsStackPanel != null) {
                control.FeatureBindingsStackPanel.IsEnabled = (Boolean)args.NewValue;
            }
        }

        public static readonly DependencyProperty SelectedInformationObjectProperty =
            DependencyProperty.Register("SelectedInformationObject", typeof(SelectedInformationTypeObjectViewModel), typeof(S100AttributeEditorControl), new UIPropertyMetadata(null, OnSelectedInformationChanged));

        public SelectedInformationTypeObjectViewModel SelectedInformationObject {
            get {
                return (SelectedInformationTypeObjectViewModel)GetValue(SelectedInformationObjectProperty);
            }
            set {
                if (SelectedFeatureObject != null) {
                    this.SelectedFeatureObject.FeatureObject.PropertyChanged -= this.SelectedObject_PropertyChanged;
                }
                if (SelectedInformationObject != null) {
                    this.SelectedInformationObject.InformationObject.PropertyChanged -= this.SelectedObject_PropertyChanged;
                }
                SetValue(SelectedInformationObjectProperty, value);
            }
        }

        private static void OnSelectedInformationChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args) {
            var control = sender as S100AttributeEditorControl;
            if (control is null)
                return;

            control._selectedObject = control.SelectedInformationObject.InformationObject;
            control._selectedInformationBindings = control.SelectedInformationObject.InformationBindings;
            control._selectedFeatureBindings = default;

            if (control.PropertyGrid != null) {
                control.PropertyGrid.SelectedObject = control._selectedObject;
            }

            var informationStackPanel = Visibility.Collapsed;

            if (control.SelectedInformationObject.InformationObject != null) {
                control.SelectedInformationObject.InformationObject.PropertyChanged += control.SelectedObject_PropertyChanged;
            }
            if (control.SelectedInformationObject.InformationBinding != null) {
                if (control.InformationBindingDefinitionsCheckComboBox != null) {
                    control.InformationBindingDefinitionsCheckComboBox.ItemsSource = control.SelectedInformationObject.InformationBinding.informationBindingDefinitions;

                    if (!control.SelectedInformationObject.InformationBinding.informationBindingDefinitions.Any()) {
                        if (control.InformationBindingsStackPanel != null)
                            informationStackPanel = Visibility.Collapsed;
                    }
                }

                if (control.InformationBindingsListView != null) {
                    control.InformationBindingsListView.ItemsSource = control.SelectedInformationObject.InformationBindings;
                }

                if (control.FeatureBindingsStackPanel != null) {
                    informationStackPanel = Visibility.Collapsed;
                }
            }

            if (control.InformationBindingsStackPanel != null) {
                control.InformationBindingsStackPanel.Visibility = informationStackPanel;
            }
            if (control.FeatureBindingsStackPanel != null) {
                control.FeatureBindingsStackPanel.Visibility = Visibility.Collapsed;
            }
        }

        public static readonly DependencyProperty SelectedFeatureObjectProperty =
            DependencyProperty.Register("SelectedFeatureObject", typeof(SelectedFeatureTypeObjectViewModel), typeof(S100AttributeEditorControl), new UIPropertyMetadata(null, OnSelectedFeatureChanged));

        public SelectedFeatureTypeObjectViewModel SelectedFeatureObject {
            get {
                return (SelectedFeatureTypeObjectViewModel)GetValue(SelectedFeatureObjectProperty);
            }
            set {
                if (SelectedFeatureObject != null) {
                    this.SelectedFeatureObject.FeatureObject.PropertyChanged -= this.SelectedObject_PropertyChanged;
                }
                if (SelectedInformationObject != null) {
                    this.SelectedInformationObject.InformationObject.PropertyChanged -= this.SelectedObject_PropertyChanged;
                }

                SetValue(SelectedFeatureObjectProperty, value);
            }
        }

        private static void OnSelectedFeatureChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args) {
            var control = sender as S100AttributeEditorControl;
            if (control is null)
                return;

            control._selectedObject = control.SelectedFeatureObject.FeatureObject;
            control._selectedInformationBindings = control.SelectedFeatureObject.InformationBindings;
            control._selectedFeatureBindings = control.SelectedFeatureObject.FeatureBindings;

            if (control.PropertyGrid != null) {
                control.PropertyGrid.SelectedObject = control._selectedObject;
            }

            var informationStackPanel = Visibility.Collapsed;
            var featureStackPanel = Visibility.Collapsed;

            if (control.SelectedFeatureObject.FeatureObject != null) {
                control.SelectedFeatureObject.FeatureObject.PropertyChanged += control.SelectedObject_PropertyChanged;
            }
            if (control.SelectedFeatureObject.FeatureBinding != null) {
                if (control.InformationBindingDefinitionsCheckComboBox != null) {
                    control.InformationBindingDefinitionsCheckComboBox.ItemsSource = control.SelectedFeatureObject.FeatureBinding.informationBindingDefinitions;

                    if (!control.SelectedFeatureObject.FeatureBinding.informationBindingDefinitions.Any()) {
                        if (control.InformationBindingsStackPanel != null)
                            informationStackPanel = Visibility.Collapsed;
                    }
                }

                if (control.FeatureBindingsStackPanel != null) {
                    featureStackPanel = Visibility.Visible;
                }

                if (control.FeatureBindingDefinitionsCheckComboBox != null) {
                    control.FeatureBindingDefinitionsCheckComboBox.ItemsSource = control.SelectedFeatureObject.FeatureBinding.featureBindingDefinitions;

                    if (!control.SelectedFeatureObject.FeatureBinding.featureBindingDefinitions.Any()) {
                        if (control.FeatureBindingsStackPanel != null)
                            featureStackPanel = Visibility.Collapsed;
                    }
                }

                if (control.InformationBindingsListView != null) {
                    control.InformationBindingsListView.ItemsSource = control.SelectedFeatureObject.InformationBindings;
                }
                if (control.FeatureBindingsListView != null) {
                    control.FeatureBindingsListView.ItemsSource = control.SelectedFeatureObject.FeatureBindings;
                }
            }

            if (control.InformationBindingsStackPanel != null) {
                control.InformationBindingsStackPanel.Visibility = informationStackPanel;
            }
            if (control.FeatureBindingsStackPanel != null) {
                control.FeatureBindingsStackPanel.Visibility = featureStackPanel;
            }
        }

        public static readonly DependencyProperty SelectedAssociationObjectProperty =
                    DependencyProperty.Register("SelectedAssociationObject", typeof(SelectedAssociationObjectViewModel), typeof(S100AttributeEditorControl), new UIPropertyMetadata(null, OnSelectedAssociationChanged));

        public SelectedAssociationObjectViewModel SelectedAssociationObject {
            get {
                return (SelectedAssociationObjectViewModel)GetValue(SelectedAssociationObjectProperty);
            }
            set {
                if (SelectedFeatureObject != null) {
                    this.SelectedFeatureObject.FeatureObject.PropertyChanged -= this.SelectedObject_PropertyChanged;
                }
                if (SelectedInformationObject != null) {
                    this.SelectedInformationObject.InformationObject.PropertyChanged -= this.SelectedObject_PropertyChanged;
                }

                SetValue(SelectedAssociationObjectProperty, value);
            }
        }

        private static void OnSelectedAssociationChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args) {
            var control = sender as S100AttributeEditorControl;
            if (control is null)
                return;

            control._selectedObject = control.SelectedAssociationObject.AssociationObject;
            control._selectedInformationBindings = default;
            control._selectedFeatureBindings = default;

            if (control.PropertyGrid != null) {
                control.PropertyGrid.SelectedObject = control._selectedObject;
            }

            if (control.SelectedAssociationObject.AssociationObject != null) {
                control.SelectedAssociationObject.AssociationObject.PropertyChanged += control.SelectedObject_PropertyChanged;
            }

            if (control.InformationBindingsStackPanel != null) {
                control.InformationBindingsStackPanel.Visibility = Visibility.Collapsed;
            }
            if (control.FeatureBindingsStackPanel != null) {
                control.FeatureBindingsStackPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void SelectedObject_PropertyChanged(object? sender, PropertyChangedEventArgs e) {
            this.PropertyChanged?.Invoke(sender, e);
        }


        #endregion


        #region Commands

        private DropDownButton? _activeDropDownButton = default;

        public static RoutedUICommand DropDownContextMenuOpeningCommand = new("DropDownContextMenuOpeningCommand", "DropDownContextMenuOpeningCommand", typeof(S100AttributeEditorControl));

        private void DropDownContextMenuOpeningCommandContent(object sender, ExecutedRoutedEventArgs e) {
            _activeDropDownButton = (DropDownButton)e.Parameter;
        }

        #endregion


        #region Associations

        public static readonly RoutedEvent QueryAssociationsEvent = EventManager.RegisterRoutedEvent("QueryAssociations", RoutingStrategy.Bubble, typeof(QueryAssociationsEventHandler), typeof(S100AttributeEditorControl));

        public event QueryAssociationsEventHandler QueryAssociations {
            add {
                this.AddHandler(S100AttributeEditorControl.QueryAssociationsEvent, value);
            }
            remove {
                this.RemoveHandler(S100AttributeEditorControl.QueryAssociationsEvent, value);
            }
        }


        public static RoutedUICommand QueryAssociationsCommand = new("Query association.", "QueryAssociationsCommand", typeof(S100AttributeEditorControl));

        private void QueryAssociationsContent(object sender, ExecutedRoutedEventArgs e) {
            _associationsDropdown.Clear();

            var eventArgs = ((ListViewItem)e.Parameter).Content switch {
                FeatureBindingViewModel model => new QueryAssociationsEventArgs(QueryAssociationsEventArgs.AssociationsType.FeatureAssociations, model.roleType, model.association, model.role, _associationsDropdown, QueryAssociationsEvent, this),
                InformationBindingViewModel model => new QueryAssociationsEventArgs(QueryAssociationsEventArgs.AssociationsType.InformationAssociations, model.roleType, model.association, model.role, _associationsDropdown, QueryAssociationsEvent, this),
                _ => throw new InvalidOperationException()
            };
            RaiseEvent(eventArgs);
        }

        public static RoutedUICommand AssociationIdLoaded = new("AssociationIdLoaded", "AssociationIdLoadedContent", typeof(S100AttributeEditorControl));

        private void AssociationIdLoadedContent(object sender, ExecutedRoutedEventArgs e) {
            var control = e.Parameter as ListBox;
            if (control != null) {
                control.ItemsSource = _associationsDropdown;
            }
        }

        public static RoutedUICommand InformationAssociationIdDoubleClick = new("InformationAssociationIdDoubleClick", "InformationAssociationIdDoubleClick", typeof(S100AttributeEditorControl));

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

        public static RoutedUICommand FeatureAssociationIdDoubleClick = new("FeatureAssociationIdDoubleClick", "FeatureAssociationIdDoubleClick", typeof(S100AttributeEditorControl));

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

        public static RoutedUICommand InformationAssociationSelectedCommand = new("Information association selected.", "InformationAssociationSelectedCommand", typeof(S100AttributeEditorControl));

        private void InformationAssociationSelectedContent(object sender, ExecutedRoutedEventArgs e) {
        }

        public static readonly RoutedEvent QueryInformationsEvent = EventManager.RegisterRoutedEvent("QueryInformations", RoutingStrategy.Bubble, typeof(QueryInformationTypessEventHandler), typeof(S100AttributeEditorControl));

        public event QueryInformationTypessEventHandler QueryInformations {
            add {
                this.AddHandler(S100AttributeEditorControl.QueryInformationsEvent, value);
            }
            remove {
                this.RemoveHandler(S100AttributeEditorControl.QueryInformationsEvent, value);
            }
        }

        public static RoutedUICommand QueryInformationsCommand = new("Query informations.", "QueryInformationsCommand", typeof(S100AttributeEditorControl));

        private void QueryInformationsContent(object sender, ExecutedRoutedEventArgs e) {
            _informationsDropdown.Clear();

            var model = (InformationBindingViewModel)((ListViewItem)e.Parameter).Content;

            var eventArgs = new QueryInformationTypesEventArgs(model.roleType, model.association, model.role, _informationsDropdown, QueryInformationsEvent, this);
            RaiseEvent(eventArgs);
        }

        public static RoutedUICommand InformationIdLoaded = new("InformationIdLoaded", "InformationIdLoadedContent", typeof(S100AttributeEditorControl));

        private void InformationIdLoadedContent(object sender, ExecutedRoutedEventArgs e) {
            var control = e.Parameter as ListView;
            if (control != null) {
                control.ItemsSource = _informationsDropdown;
            }
        }

        public static RoutedUICommand InformationIdDoubleClick = new("InformationIdDoubleClick", "InformationIdDoubleClickContent", typeof(S100AttributeEditorControl));

        private void InformationIdDoubleClickContent(object sender, ExecutedRoutedEventArgs e) {
            var control = e.Parameter as ListView;
            if (control != null) {
                var selectedItem = (InformationTypeId)control.SelectedItem;

                if (selectedItem != null) {
                    var informationBinding = InformationBindingsListView?.SelectedItem as InformationBindingViewModel;
                    if (informationBinding != null) {
                        informationBinding.informationId = selectedItem.Id;

                        if (_activeDropDownButton != null) {
                            _activeDropDownButton.IsOpen = false;
                        }
                    }
                }
            }
        }

        private ObservableCollection<InformationTypeId> _informationsDropdown = new ObservableCollection<InformationTypeId>();

        public static RoutedUICommand AddInformationBindingCommand = new("Add information binding.", "AddInformationBindingCommandContent", typeof(S100AttributeEditorControl));

        private void AddInformationBindingCommandContent(object sender, ExecutedRoutedEventArgs e) {
            if (InformationBindingDefinitionSelected != null) {
                var binding = new informationBinding {
                    roleType = Enum.GetName<roleType>(InformationBindingDefinitionSelected.roleType)!,
                    association = InformationBindingDefinitionSelected.association,
                    role = InformationBindingDefinitionSelected.role,
                    PID = ((PID?)this._selectedObject)?.PID,
                };

                this._selectedInformationBindings!.Add(new InformationBindingViewModel {
                }.Load(binding));
            }
        }

        #endregion


        #region FeatureBindingss

        public static RoutedUICommand FeatureAssociationSelectedCommand = new("Feature association selected.", "FeatureAssociationSelectedCommand", typeof(S100AttributeEditorControl));

        private void FeatureAssociationSelectedContent(object sender, ExecutedRoutedEventArgs e) {
        }

        public static readonly RoutedEvent QueryFeaturesEvent = EventManager.RegisterRoutedEvent("QueryFeatures", RoutingStrategy.Bubble, typeof(QueryFeatureTypesEventHandler), typeof(S100AttributeEditorControl));

        public event QueryFeatureTypesEventHandler QueryFeatures {
            add {
                this.AddHandler(S100AttributeEditorControl.QueryFeaturesEvent, value);
            }
            remove {
                this.RemoveHandler(S100AttributeEditorControl.QueryFeaturesEvent, value);
            }
        }

        public static RoutedUICommand QueryFeaturesCommand = new("Query features.", "QueryFeaturesCommand", typeof(S100AttributeEditorControl));

        private void QueryFeaturesContent(object sender, ExecutedRoutedEventArgs e) {
            _featuresDropdown.Clear();

            var model = (FeatureBindingViewModel)((ListViewItem)e.Parameter).Content;

            var eventArgs = new QueryFeatureTypesEventArgs(model.roleType, model.association, model.role, _featuresDropdown, QueryFeaturesEvent, this);
            RaiseEvent(eventArgs);
        }

        public static RoutedUICommand FeatureIdLoaded = new("FeatureIdLoaded", "FeatureIdLoadedContent", typeof(S100AttributeEditorControl));

        private void FeatureIdLoadedContent(object sender, ExecutedRoutedEventArgs e) {
            var control = e.Parameter as ListView;
            if (control != null) {
                control.ItemsSource = _featuresDropdown;
            }
        }

        public static RoutedUICommand FeatureIdDoubleClick = new("FeatureIdDoubleClick", "FeatureIdDoubleClickContent", typeof(S100AttributeEditorControl));

        private void FeatureIdDoubleClickContent(object sender, ExecutedRoutedEventArgs e) {
            var control = e.Parameter as ListView;
            if (control != null) {
                var selectedItem = (FeatureTypeId)control.SelectedItem;

                if (selectedItem != null) {
                    var featureBinding = FeatureBindingsListView?.SelectedItem as FeatureBindingViewModel;
                    if (featureBinding != null) {
                        featureBinding.featureId = selectedItem.Id;

                        if (_activeDropDownButton != null) {
                            _activeDropDownButton.IsOpen = false;
                        }
                    }
                }
            }
        }

        private ObservableCollection<FeatureTypeId> _featuresDropdown = new ObservableCollection<FeatureTypeId>();

        public static RoutedUICommand AddFeatureBindingCommand = new("Add feature binding.", "AddFeatureBindingCommandContent", typeof(S100AttributeEditorControl));

        private void AddFeatureBindingCommandContent(object sender, ExecutedRoutedEventArgs e) {
            if (FeatureBindingDefinitionSelected != null) {
                var binding = new featureBinding {
                    roleType = Enum.GetName<roleType>(FeatureBindingDefinitionSelected.roleType)!,
                    association = FeatureBindingDefinitionSelected.association,
                    role = FeatureBindingDefinitionSelected.role,
                    PID = ((PID?)this._selectedObject)?.PID,
                };

                this._selectedFeatureBindings!.Add(new FeatureBindingViewModel {
                }.Load(binding));
            }
        }

        #endregion
    }
}
