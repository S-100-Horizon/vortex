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

    public class QueryAssociationsEventArgs
    {
        public enum AssociationsType
        {
            InformationAssociations = 1,
            FeatureAssociations = 2,
        }

        public QueryAssociationsEventArgs(AssociationsType type, roleType? roleType, string? association, string? role, object source) {
            this.type = type;
            this.roleType = roleType ?? S100Framework.DomainModel.roleType.association;
            this.association = association ?? string.Empty;
            this.role = role ?? string.Empty;
        }

        public AssociationsType type { get; }
        public roleType? roleType { get; }
        public string? association { get; }
        public string? role { get; }
    }

    public class QueryInformationTypesEventArgs
    {
        public QueryInformationTypesEventArgs(roleType? roleType, string? association, string? role, object source) {
            this.roleType = roleType ?? S100Framework.DomainModel.roleType.association;
            this.association = association ?? string.Empty;
            this.role = role ?? string.Empty;
        }

        public roleType? roleType { get; }
        public string? association { get; }
        public string? role { get; }
    }

    public class QueryFeatureTypesEventArgs
    {
        public QueryFeatureTypesEventArgs(roleType? roleType, string? association, string? role, object source) {
            this.roleType = roleType ?? S100Framework.DomainModel.roleType.association;
            this.association = association ?? string.Empty;
            this.role = role ?? string.Empty;
        }

        public roleType? roleType { get; }
        public string? association { get; }
        public string? role { get; }
    }

    public class SelectInformationBindingEventArgs
    {
        public SelectInformationBindingEventArgs(roleType? roleType, string? association, string? role, string? associationId, string? informationId) {
            this.roleType = roleType ?? S100Framework.DomainModel.roleType.association;
            this.association = association ?? string.Empty;
            this.role = role ?? string.Empty;
            this.associationId = associationId ?? default;
            this.informationId = informationId ?? default;
        }

        public roleType? roleType { get; }
        public string? association { get; }
        public string? role { get; }
        public string? associationId { get; }
        public string? informationId { get; }
    }


    public class SelectFeatureBindingEventArgs
    {
        public SelectFeatureBindingEventArgs(roleType? roleType, string? association, string? role, string? associationId, string? featureId) {
            this.roleType = roleType ?? S100Framework.DomainModel.roleType.association;
            this.association = association ?? string.Empty;
            this.role = role ?? string.Empty;
            this.associationId = associationId ?? default;
            this.featureId = featureId ?? default;
        }

        public roleType? roleType { get; }
        public string? association { get; }
        public string? role { get; }
        public string? associationId { get; }
        public string? featureId { get; }
    }

    public class SelectAssociationEventArgs
    {
        public SelectAssociationEventArgs(string? associationId) {
            this.associationId = associationId ?? default;
        }

        public string? associationId { get; }
    }

    #endregion

    public delegate void NotifyCollectionItemEventHandler(object? sender, object? item, PropertyChangedEventArgs e);

    public abstract class SelectedObjectViewModel : INotifyPropertyChanged, INotifyCollectionChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public event NotifyCollectionItemEventHandler? CollectionItemChanged;

        protected void OnPropertyChanged(object? sender, PropertyChangedEventArgs e) {
            this.PropertyChanged?.Invoke(sender, e);
        }

        protected void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) {
            this.CollectionChanged?.Invoke(sender, e);
        }

        protected void OnCollectionItemChanged(object? sender, object? item, PropertyChangedEventArgs e) {
            this.CollectionItemChanged?.Invoke(sender, item, e);
        }
    }

    public class SelectedInformationTypeObjectViewModel : SelectedObjectViewModel
    {
        public SelectedInformationTypeObjectViewModel(InformationViewModel informationObject/*, IInformationBindingDefinition informationBinding*/) {
            this.InformationObject = informationObject;
            this.informationBindingDefinitions = informationObject.informationBindingDefinitions;

            this.InformationObject.PropertyChanged += base.OnPropertyChanged;            
        }

        public informationBindingDefinition[] informationBindingDefinitions { get; private set; }

        public InformationViewModel InformationObject { get; private set; }        
    }

    public class SelectedFeatureTypeObjectViewModel : SelectedObjectViewModel
    {
        public SelectedFeatureTypeObjectViewModel(FeatureViewModel featureObject) {
            this.FeatureObject = featureObject;
            this.informationBindingDefinitions = featureObject.informationBindingDefinitions;
            this.featureBindingDefinitions = featureObject.featureBindingDefinitions;

            this.FeatureObject.PropertyChanged += base.OnPropertyChanged;
        }

        public SelectedFeatureTypeObjectViewModel(FeatureViewModel featureObject, Primitives primitive) {
            this.FeatureObject = featureObject;
            this.informationBindingDefinitions = featureObject.informationBindingDefinitionsByPrimitive(primitive);
            this.featureBindingDefinitions = featureObject.featureBindingDefinitions;

            this.FeatureObject.PropertyChanged += base.OnPropertyChanged;
        }

        public FeatureViewModel FeatureObject { get; private set; }

        public informationBindingDefinition[] informationBindingDefinitions { get; private set; }

        public featureBindingDefinition[] featureBindingDefinitions { get; private set; }
    }

    public class SelectedAssociationObjectViewModel : SelectedObjectViewModel
    {
        public SelectedAssociationObjectViewModel(AssociationViewModel associationObject) {
            this.AssociationObject = associationObject;

            this.InformationBindings.CollectionChanged += this.OnInformationBindings_CollectionChanged;
            this.FeatureBindings.CollectionChanged += this.OnFeatureBindings_CollectionChanged;
        }

        public AssociationViewModel AssociationObject { get; private set; }

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
            //base.OnCollectionChanged(sender, e);
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
            //base.OnCollectionChanged(sender, e);
        }

    }

    public class S100AttributeEditorControlHost
    {
        public required Func<QueryAssociationsEventArgs, Task<IEnumerable<AssociationId>>> QueryAssociation { get; set; }

        public required Func<QueryInformationTypesEventArgs, Task<IEnumerable<InformationTypeId>>> QueryInformationTypes { get; set; }

        public required Func<QueryFeatureTypesEventArgs, Task<IEnumerable<FeatureTypeId>>> QueryFeatureTypes { get; set; }

        public required Action<SelectInformationBindingEventArgs> SelectInformationBinding { get; set; }

        public required Action<SelectFeatureBindingEventArgs> SelectFeatureBinding { get; set; }

        public required Action<SelectAssociationEventArgs> SelectInformationAssociation { get; set; }

        public required Action<SelectAssociationEventArgs> SelectFeatureAssociation { get; set; }
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
        private const string PART_InformationBindingsCreator = "PART_InformationBindingsCreator";
        private const string PART_FeatureBindingsCreator = "PART_FeatureBindingsCreator";
        private const string PART_InformationBindingsList = "PART_InformationBindingsList";
        private const string PART_FeatureBindingsList = "PART_FeatureBindingsList";

        private informationBindingDefinition? InformationBindingDefinitionSelected { get; set; } = default;
        private featureBindingDefinition? FeatureBindingDefinitionSelected { get; set; } = default;

        private PropertyGrid? PropertyGrid { get; set; } = default;
        private StackPanel? InformationBindingsStackPanel { get; set; } = default;
        private StackPanel? FeatureBindingsStackPanel { get; set; } = default;
        private ComboBox? InformationBindingDefinitionsCheckComboBox { get; set; } = default;
        private ComboBox? FeatureBindingDefinitionsCheckComboBox { get; set; } = default;
        private StackPanel? InformationBindingsStackPanelCreator { get; set; } = default;
        private StackPanel? FeatureBindingsStackPanelCreator { get; set; } = default;
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
            binding = new CommandBinding(S100AttributeEditorControl.AssociationAddSelectionCommand, this.AssociationAddSelectionCommandContent);
            this.CommandBindings.Add(binding);

            //  InformationBindings
            binding = new CommandBinding(S100AttributeEditorControl.InformationAssociationSelectedCommand, this.InformationAssociationSelectedCommandContent);
            this.CommandBindings.Add(binding);
            binding = new CommandBinding(S100AttributeEditorControl.QueryInformationsCommand, this.QueryInformationsContent);
            this.CommandBindings.Add(binding);
            binding = new CommandBinding(S100AttributeEditorControl.InformationIdLoaded, this.InformationIdLoadedContent);
            this.CommandBindings.Add(binding);
            binding = new CommandBinding(S100AttributeEditorControl.InformationIdDoubleClick, this.InformationIdDoubleClickContent);
            this.CommandBindings.Add(binding);
            binding = new CommandBinding(S100AttributeEditorControl.AddInformationBindingCommand, this.AddInformationBindingCommandContent);
            this.CommandBindings.Add(binding);
            binding = new CommandBinding(S100AttributeEditorControl.InformationAssociationAddSelectionCommand, this.InformationAssociationAddSelectionCommandContent);
            this.CommandBindings.Add(binding);
            binding = new CommandBinding(S100AttributeEditorControl.InformationAssociationRemoveFromListSelectionCommand, this.InformationAssociationRemoveFromListSelectionCommandContent);
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
            binding = new CommandBinding(S100AttributeEditorControl.FeatureAssociationAddSelectionCommand, this.FeatureAssociationAddSelectionCommandContent);
            this.CommandBindings.Add(binding);
            binding = new CommandBinding(S100AttributeEditorControl.FeatureAssociationRemoveFromListSelectionCommand, this.FeatureAssociationRemoveFromListSelectionCommandContent);
            this.CommandBindings.Add(binding);

            //  Unknown/Nullable
            binding = new CommandBinding(S100AttributeEditorControl.UnknownCommand, this.UnknownCommandContent);
            this.CommandBindings.Add(binding);
            binding = new CommandBinding(S100AttributeEditorControl.ResetCommand, this.ResetCommandContent);
            this.CommandBindings.Add(binding);
        }

        public override void OnApplyTemplate() {
            base.OnApplyTemplate();

            PropertyGrid = (PropertyGrid)GetTemplateChild(PART_PropertyGrid);
            PropertyGrid.IsReadOnly = !this.IsEditingEnabled;

            PropertyGrid.PreparePropertyItem += this.PropertyGrid_PreparePropertyItem;            

            InformationBindingsStackPanel = (StackPanel)GetTemplateChild(PART_InformationBindings);
            InformationBindingsStackPanel.IsEnabled = this.IsEditingEnabled;

            FeatureBindingsStackPanel = (StackPanel)GetTemplateChild(PART_FeatureBindings);
            FeatureBindingsStackPanel.IsEnabled = this.IsEditingEnabled;

            InformationBindingDefinitionsCheckComboBox = (ComboBox)GetTemplateChild(PART_InformationBindingDefinitions);
            FeatureBindingDefinitionsCheckComboBox = (ComboBox)GetTemplateChild(PART_FeatureBindingDefinitions);

            InformationBindingsStackPanelCreator = (StackPanel)GetTemplateChild(PART_InformationBindingsCreator);
            FeatureBindingsStackPanelCreator = (StackPanel)GetTemplateChild(PART_FeatureBindingsCreator);

            InformationBindingsListView = (ListView)GetTemplateChild(PART_InformationBindingsList);

            FeatureBindingsListView = (ListView)GetTemplateChild(PART_FeatureBindingsList);

            //FeatureBindingsListView.Loaded += this.FeatureBindingsListView_Loaded;
            //FeatureBindingsListView.SizeChanged += this.FeatureBindingsListView_SizeChanged;

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

        private void PropertyGrid_PreparePropertyItem(object sender, PropertyItemEventArgs e) {
            var propertyItem = e.Item as Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem;
            if (propertyItem == null)
                return;

            if (propertyItem.PropertyType.IsInterface)  // IViewModelHost
                return;

            if (propertyItem.IsExpandable)
                propertyItem.IsExpanded = true;
        }

        private void FeatureBindingsListView_SizeChanged(object sender, SizeChangedEventArgs e) {
            if (sender is ListView listView) {
                if (listView.View is not GridView gridView || gridView.Columns.Count == 0) {
                    return;
                }

                double listViewWidth = listView.ActualWidth;
                double otherColumnsWidth = 0;
                for (int i = 0; i < gridView.Columns.Count - 1; i++) {
                    otherColumnsWidth += gridView.Columns[i].ActualWidth;
                }

                double buffer = 10;
                double newLastColumnWidth = listViewWidth - otherColumnsWidth - buffer;

                var lastColumn = gridView.Columns.Last();

                if (newLastColumnWidth > 0) {
                    // --- THE DEFENSIVE CHECK ---
                    // Only update the width if the new calculated width is different.
                    // This prevents unnecessary layout updates and breaks any potential for a loop.
                    // We compare with a small tolerance (epsilon) for floating-point inaccuracies.
                    if (double.IsNaN(lastColumn.Width) || Math.Abs(lastColumn.Width - newLastColumnWidth) >= 100d) {
                        lastColumn.Width = newLastColumnWidth;
                    }
                }
            }
        }

        private void FeatureBindingsListView_Loaded(object sender, RoutedEventArgs e) {
        }

        private object? _selectedObject = default;

        private ICollection<InformationBindingViewModel>? _selectedInformationBindings = default;
        private ICollection<FeatureBindingViewModel>? _selectedFeatureBindings = default;

        #region DependencyProperties       

        public static readonly DependencyProperty HostProperty =
            DependencyProperty.Register("Host", typeof(S100AttributeEditorControlHost), typeof(S100AttributeEditorControl), new UIPropertyMetadata(default, null));

        public S100AttributeEditorControlHost Host {
            get {
                return (S100AttributeEditorControlHost)GetValue(HostProperty);
            }
            set {
                SetValue(HostProperty, value);
            }
        }


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
                control.PropertyGrid.IsReadOnly = !(Boolean)args.NewValue;
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

        public SelectedInformationTypeObjectViewModel? SelectedInformationObject {
            get {
                return (SelectedInformationTypeObjectViewModel)GetValue(SelectedInformationObjectProperty);
            }
            set {
                //SelectedInformationObject = default;
                //SelectedAssociationObject = default;

                //if (SelectedFeatureObject != null) {
                //    this.SelectedFeatureObject.FeatureObject.PropertyChanged -= this.SelectedObject_PropertyChanged;
                //}
                if (SelectedInformationObject != null) {
                    this.SelectedInformationObject.InformationObject.PropertyChanged -= this.SelectedObject_PropertyChanged;
                }
                SetValue(SelectedAssociationObjectProperty, default);
                SetValue(SelectedInformationObjectProperty, value);
            }
        }

        private static void OnSelectedInformationChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args) {
            var control = sender as S100AttributeEditorControl;
            if (control is null)
                return;

            if (control.SelectedInformationObject is null)
                return;

            control._selectedObject = control.SelectedInformationObject.InformationObject;
            control._selectedInformationBindings = control.SelectedInformationObject.InformationObject.InformationBindings;
            control._selectedFeatureBindings = default;

            if (control.PropertyGrid != null) {
                control.PropertyGrid.SelectedObject = control._selectedObject;
                control.PropertyGrid.SelectedObjectTypeName = control._selectedObject.ToString();
            }

            var informationStackPanel = Visibility.Collapsed;

            if (control.SelectedInformationObject.InformationObject != null) {
                control.SelectedInformationObject.InformationObject.PropertyChanged += control.SelectedObject_PropertyChanged;
            }
            if (control.InformationBindingsStackPanelCreator != null)
                control.InformationBindingsStackPanelCreator.IsEnabled = true;
            //if (control.SelectedInformationObject.InformationBindings != null)
            {
                informationStackPanel = Visibility.Visible;

                if (control.InformationBindingDefinitionsCheckComboBox != null) {
                    control.InformationBindingDefinitionsCheckComboBox.ItemsSource = control.SelectedInformationObject.informationBindingDefinitions;

                    if (!control.SelectedInformationObject.informationBindingDefinitions.Any()) {
                        informationStackPanel = Visibility.Collapsed;
                    }
                }

                if (control.InformationBindingsListView != null) {
                    control.InformationBindingsListView.ItemsSource = control._selectedInformationBindings;
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

        public SelectedFeatureTypeObjectViewModel? SelectedFeatureObject {
            get {
                return (SelectedFeatureTypeObjectViewModel)GetValue(SelectedFeatureObjectProperty);
            }
            set {
                //SelectedFeatureObject = default;
                //SelectedAssociationObject = default;

                if (SelectedFeatureObject != null) {
                    this.SelectedFeatureObject.FeatureObject.PropertyChanged -= this.SelectedObject_PropertyChanged;
                }
                //if (SelectedInformationObject != null) {
                //    this.SelectedInformationObject.InformationObject.PropertyChanged -= this.SelectedObject_PropertyChanged;
                //}
                SetValue(SelectedAssociationObjectProperty, default);
                SetValue(SelectedFeatureObjectProperty, value);
            }
        }

        private static void OnSelectedFeatureChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args) {
            var control = sender as S100AttributeEditorControl;
            if (control is null)
                return;

            if (control.SelectedFeatureObject is null)
                return;

            control._selectedObject = control.SelectedFeatureObject.FeatureObject;
            control._selectedInformationBindings = control.SelectedFeatureObject.FeatureObject.InformationBindings;
            control._selectedFeatureBindings = control.SelectedFeatureObject.FeatureObject.FeatureBindings;

            if (control.PropertyGrid != null) {
                control.PropertyGrid.SelectedObject = control._selectedObject;
                control.PropertyGrid.SelectedObjectTypeName = control._selectedObject.ToString();
            }

            var informationStackPanel = Visibility.Collapsed;
            var featureStackPanel = Visibility.Collapsed;

            if (control.SelectedFeatureObject.FeatureObject != null) {
                control.SelectedFeatureObject.FeatureObject.PropertyChanged += control.SelectedObject_PropertyChanged;
            }
            if (control.InformationBindingsStackPanelCreator != null)
                control.InformationBindingsStackPanelCreator.IsEnabled = true;
            //if (control.SelectedFeatureObject.InformationBindings != null) 
            {
                informationStackPanel = Visibility.Visible;

                if (control.InformationBindingDefinitionsCheckComboBox != null) {
                    control.InformationBindingDefinitionsCheckComboBox.ItemsSource = control.SelectedFeatureObject.informationBindingDefinitions;

                    if (!control.SelectedFeatureObject.informationBindingDefinitions.Any()) {
                        informationStackPanel = Visibility.Collapsed;
                    }
                }

                if (control.InformationBindingsListView != null) {
                    control.InformationBindingsListView.ItemsSource = control._selectedInformationBindings;
                }
            }
            if (control.FeatureBindingsStackPanelCreator != null)
                control.FeatureBindingsStackPanelCreator.IsEnabled = true;
            //if (control.SelectedFeatureObject.FeatureBindings != null) 
            {
                featureStackPanel = Visibility.Visible;

                if (control.FeatureBindingDefinitionsCheckComboBox != null) {
                    control.FeatureBindingDefinitionsCheckComboBox.ItemsSource = control.SelectedFeatureObject.featureBindingDefinitions;

                    if (!control.SelectedFeatureObject.featureBindingDefinitions.Any()) {
                        featureStackPanel = Visibility.Collapsed;
                    }
                }

                if (control.FeatureBindingsListView != null) {
                    control.FeatureBindingsListView.ItemsSource = control._selectedFeatureBindings;
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

        public SelectedAssociationObjectViewModel? SelectedAssociationObject {
            get {
                return (SelectedAssociationObjectViewModel)GetValue(SelectedAssociationObjectProperty);
            }
            set {
                SelectedFeatureObject = default;
                SelectedInformationObject = default;
                //if (SelectedFeatureObject != null) {
                //    this.SelectedFeatureObject.FeatureObject.PropertyChanged -= this.SelectedObject_PropertyChanged;
                //}
                //if (SelectedInformationObject != null) {
                //    this.SelectedInformationObject.InformationObject.PropertyChanged -= this.SelectedObject_PropertyChanged;
                //}
                SetValue(SelectedAssociationObjectProperty, value);
            }
        }

        private static void OnSelectedAssociationChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args) {
            var control = sender as S100AttributeEditorControl;
            if (control is null)
                return;

            if (control.SelectedAssociationObject is null)
                return;

            control._selectedObject = control.SelectedAssociationObject.AssociationObject;
            control._selectedInformationBindings = default;
            control._selectedFeatureBindings = default;

            if (control.PropertyGrid != null) {
                control.PropertyGrid.SelectedObject = control._selectedObject;
                control.PropertyGrid.SelectedObjectTypeName = control._selectedObject.ToString();
            }

            var informationStackPanel = Visibility.Collapsed;
            var featureStackPanel = Visibility.Collapsed;

            if (control.SelectedAssociationObject.AssociationObject != null) {
                control.SelectedAssociationObject.AssociationObject.PropertyChanged += control.SelectedObject_PropertyChanged;
            }
            if (control.InformationBindingsStackPanelCreator != null)
                control.InformationBindingsStackPanelCreator.IsEnabled = true;
            if (control.SelectedAssociationObject.InformationBindings != null && control.SelectedAssociationObject.InformationBindings.Any()) {
                informationStackPanel = Visibility.Visible;

                if (control.InformationBindingDefinitionsCheckComboBox != null) {
                    control.InformationBindingDefinitionsCheckComboBox.ItemsSource = null;
                    //control.InformationBindingDefinitionsCheckComboBox.ItemsSource = control.SelectedAssociationObject.FeatureBinding.informationBindingDefinitions;

                    //if (!control.SelectedAssociationObject.FeatureBinding.informationBindingDefinitions.Any()) {
                    //    informationStackPanel = Visibility.Collapsed;
                    //}

                    if (control.InformationBindingsStackPanelCreator != null)
                        control.InformationBindingsStackPanelCreator.IsEnabled = false;
                }

                if (control.InformationBindingsListView != null) {
                    control.InformationBindingsListView.ItemsSource = control.SelectedAssociationObject.InformationBindings;
                }
            }

            if (control.FeatureBindingsStackPanelCreator != null)
                control.FeatureBindingsStackPanelCreator.IsEnabled = true;
            if (control.SelectedAssociationObject.FeatureBindings != null && control.SelectedAssociationObject.FeatureBindings.Any()) {
                featureStackPanel = Visibility.Visible;

                if (control.FeatureBindingDefinitionsCheckComboBox != null) {
                    control.FeatureBindingDefinitionsCheckComboBox.ItemsSource = null;
                    //control.FeatureBindingDefinitionsCheckComboBox.ItemsSource = control.SelectedAssociationObject.FeatureBinding.featureBindingDefinitions;

                    //if (!control.SelectedAssociationObject.FeatureBinding.featureBindingDefinitions.Any()) {
                    //    featureStackPanel = Visibility.Collapsed;
                    //}

                    if (control.FeatureBindingsStackPanelCreator != null)
                        control.FeatureBindingsStackPanelCreator.IsEnabled = false;
                }

                if (control.FeatureBindingsListView != null) {
                    control.FeatureBindingsListView.ItemsSource = control.SelectedAssociationObject.FeatureBindings;
                }
            }

            if (control.InformationBindingsStackPanel != null) {
                control.InformationBindingsStackPanel.Visibility = informationStackPanel;
            }
            if (control.FeatureBindingsStackPanel != null) {
                control.FeatureBindingsStackPanel.Visibility = featureStackPanel;
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

        public static RoutedUICommand QueryAssociationsCommand = new("Query association.", "QueryAssociationsCommand", typeof(S100AttributeEditorControl));

        private async void QueryAssociationsContent(object sender, ExecutedRoutedEventArgs e) {
            var eventArgs = ((ListViewItem)e.Parameter).Content switch {
                FeatureBindingViewModel model => new QueryAssociationsEventArgs(QueryAssociationsEventArgs.AssociationsType.FeatureAssociations, model.roleType, model.association, model.role, this),
                InformationBindingViewModel model => new QueryAssociationsEventArgs(QueryAssociationsEventArgs.AssociationsType.InformationAssociations, model.roleType, model.association, model.role, this),
                _ => throw new InvalidOperationException()
            };

            _associationsDropdown.Clear();
            foreach (var id in await Host.QueryAssociation(eventArgs)) {
                _associationsDropdown.Add(id);
            }
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

        public static RoutedUICommand AssociationAddSelectionCommand = new("Add association type to selection", "AssociationAddSelectionCommandContent", typeof(S100AttributeEditorControl));

        private void AssociationAddSelectionCommandContent(object sender, ExecutedRoutedEventArgs e) {
            if (e.Parameter is FeatureBindingViewModel featureBindingViewModel) {
                this.Host.SelectFeatureAssociation(new SelectAssociationEventArgs(featureBindingViewModel.associationId));
            }
            if (e.Parameter is InformationBindingViewModel informationBindingViewModel) {
                this.Host.SelectFeatureAssociation(new SelectAssociationEventArgs(informationBindingViewModel.associationId));
            }
        }

        private ObservableCollection<AssociationId> _associationsDropdown = new ObservableCollection<AssociationId>();

        #endregion


        #region InformationBindings

        public static RoutedUICommand InformationAssociationSelectedCommand = new("Information association selected.", "InformationAssociationSelectedCommand", typeof(S100AttributeEditorControl));

        private void InformationAssociationSelectedCommandContent(object sender, ExecutedRoutedEventArgs e) {
        }

        public static RoutedUICommand QueryInformationsCommand = new("Query informations.", "QueryInformationsCommand", typeof(S100AttributeEditorControl));

        private async void QueryInformationsContent(object sender, ExecutedRoutedEventArgs e) {
            var model = (InformationBindingViewModel)((ListViewItem)e.Parameter).Content;

            var eventArgs = new QueryInformationTypesEventArgs(model.roleType, model.association, model.role, this);

            _informationsDropdown.Clear();
            foreach (var id in await Host.QueryInformationTypes(eventArgs)) {
                _informationsDropdown.Add(id);
            }
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
                    association = InformationBindingDefinitionSelected.association,
                    roleType = Enum.GetName<roleType>(InformationBindingDefinitionSelected.roleType)!,
                    role = InformationBindingDefinitionSelected.role,
                };

                this._selectedInformationBindings!.Add(new InformationBindingViewModel {
                    //UID = uuid,
                }.Load(binding));
            }
        }

        public static RoutedUICommand InformationAssociationAddSelectionCommand = new("Add information type to selection", "InformationAssociationAddSelectionCommandContent", typeof(S100AttributeEditorControl));

        private void InformationAssociationAddSelectionCommandContent(object sender, ExecutedRoutedEventArgs e) {
            var viewModel = (InformationBindingViewModel)e.Parameter;
            if (viewModel != null) {
                this.Host.SelectInformationBinding(new SelectInformationBindingEventArgs(viewModel.roleType, viewModel.association, viewModel.role, viewModel.associationId, viewModel.informationId));
            }
        }

        public static RoutedUICommand InformationAssociationRemoveFromListSelectionCommand = new("Delete information binding.", "InformationAssociationRemoveFromListSelectionCommandContent", typeof(S100AttributeEditorControl));

        private void InformationAssociationRemoveFromListSelectionCommandContent(object sender, ExecutedRoutedEventArgs e) {
            if (InformationBindingDefinitionSelected != null) {
                var viewModel = (InformationBindingViewModel)e.Parameter;
                if (viewModel != null) {
                    this._selectedInformationBindings!.Remove(viewModel);
                }
            }
        }

        #endregion


        #region FeatureBindingss

        public static RoutedUICommand FeatureAssociationSelectedCommand = new("Feature association selected.", "FeatureAssociationSelectedCommand", typeof(S100AttributeEditorControl));

        private void FeatureAssociationSelectedContent(object sender, ExecutedRoutedEventArgs e) {
        }

        public static RoutedUICommand QueryFeaturesCommand = new("Query features.", "QueryFeaturesCommand", typeof(S100AttributeEditorControl));

        private async void QueryFeaturesContent(object sender, ExecutedRoutedEventArgs e) {
            var model = (FeatureBindingViewModel)((ListViewItem)e.Parameter).Content;

            var eventArgs = new QueryFeatureTypesEventArgs(model.roleType, model.association, model.role, this);

            _featuresDropdown.Clear();
            foreach (var id in await Host.QueryFeatureTypes(eventArgs)) {
                _featuresDropdown.Add(id);
            }
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
                    association = FeatureBindingDefinitionSelected.association,
                    roleType = Enum.GetName<roleType>(FeatureBindingDefinitionSelected.roleType)!,
                    role = FeatureBindingDefinitionSelected.role,
                };

                this._selectedFeatureBindings!.Add(new FeatureBindingViewModel {
                    //UID = uuid,
                }.Load(binding));
            }
        }

        public static RoutedUICommand FeatureAssociationAddSelectionCommand = new("Add feature type to selection", "FeatureAssociationAddSelectionCommandContent", typeof(S100AttributeEditorControl));

        private void FeatureAssociationAddSelectionCommandContent(object sender, ExecutedRoutedEventArgs e) {
            var viewModel = (FeatureBindingViewModel)e.Parameter;
            if (viewModel != null) {
                this.Host.SelectFeatureBinding(new SelectFeatureBindingEventArgs(viewModel.roleType, viewModel.association, viewModel.role, viewModel.associationId, viewModel.featureId));
            }
        }

        public static RoutedUICommand FeatureAssociationRemoveFromListSelectionCommand = new("Delete feature binding.", "FeatureAssociationRemoveFromListSelectionCommandContent", typeof(S100AttributeEditorControl));

        private void FeatureAssociationRemoveFromListSelectionCommandContent(object sender, ExecutedRoutedEventArgs e) {
            if (FeatureBindingDefinitionSelected != null) {
                var viewModel = (FeatureBindingViewModel)e.Parameter;
                if (viewModel != null) {
                    this._selectedFeatureBindings!.Remove(viewModel);
                }
            }
        }

        #endregion

        #region Unknown/Nullable

        public static RoutedUICommand UnknownCommand = new("Unknow.", "UnknownCommand", typeof(S100AttributeEditorControl));

        private void UnknownCommandContent(object sender, ExecutedRoutedEventArgs e) {
            System.Diagnostics.Debugger.Break();
        }

        public static RoutedUICommand ResetCommand = new("Reset.", "ResetCommand", typeof(S100AttributeEditorControl));

        private void ResetCommandContent(object sender, ExecutedRoutedEventArgs e) {
            System.Diagnostics.Debugger.Break();
        }

        #endregion
    }
}
