using S100Framework.DomainModel;
using S100Framework.WPF.ViewModel;
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
    public record InformationTypeId(string Code, string Id)
    {
        public override string ToString() => $"{Code}::{Id}";
    }

    public record FeatureTypeId(string Code, string Id)
    {
        public override string ToString() => $"{Code}::{Id}";
    }

    #region EventArgs

    public class QueryInformationTypesEventArgs
    {
        public QueryInformationTypesEventArgs(roleType? roleType, string? association, string? role, string[] informationTypes, Action<InformationTypeId[]>? callback) {
            this.roleType = roleType ?? S100Framework.DomainModel.roleType.association;
            this.association = association ?? string.Empty;
            this.role = role ?? string.Empty;
            this.informationTypes = informationTypes;
            this.callback = callback;
        }

        public roleType? roleType { get; }
        public string? association { get; }
        public string? role { get; }
        public string[] informationTypes { get; }
        public Action<InformationTypeId[]>? callback { get; } = default;
    }

    public class QueryFeatureTypesEventArgs
    {
        public QueryFeatureTypesEventArgs(roleType? roleType, string? association, string? role, string[] featureTypes, Action<FeatureTypeId[]>? callback) {
            this.roleType = roleType ?? S100Framework.DomainModel.roleType.association;
            this.association = association ?? string.Empty;
            this.role = role ?? string.Empty;
            this.featureTypes = featureTypes;
            this.callback = callback;
        }
        public roleType? roleType { get; }
        public string? association { get; }
        public string? role { get; }
        public string[] featureTypes { get; }
        public Action<FeatureTypeId[]>? callback { get; } = default;
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

        public event PropertyChangedEventHandler? InformationBindingCollectionChanged;

        public event PropertyChangedEventHandler? FeatureBindingCollectionChanged;

        protected void OnPropertyChanged(object? sender, PropertyChangedEventArgs e) {
            if ("HasErrors".Equals(e.PropertyName)) return;
            this.PropertyChanged?.Invoke(sender, e);
        }

        protected void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) {
            this.CollectionChanged?.Invoke(sender, e);
        }

        protected void OnCollectionItemChanged(object? sender, object? item, PropertyChangedEventArgs e) {
            this.CollectionItemChanged?.Invoke(sender, item, e);
        }

        protected void OnInformationBindingCollectionChanged(object? sender, PropertyChangedEventArgs e) {
            this.InformationBindingCollectionChanged?.Invoke(sender, e);
        }

        protected void OnFeatureBindingCollectionChanged(object? sender, PropertyChangedEventArgs e) {
            this.FeatureBindingCollectionChanged?.Invoke(sender, e);
        }
    }

    public class SelectedInformationTypeObjectViewModel : SelectedObjectViewModel
    {
        public SelectedInformationTypeObjectViewModel(InformationViewModel informationObject/*, IInformationBindingDefinition informationBinding*/) {
            this.InformationObject = informationObject;
            this.informationBindingDefinitions = informationObject.informationBindingDefinitions;

            this.InformationObject.PropertyChanged += base.OnPropertyChanged;
            this.InformationObject.InformationBindingCollectionChanged += base.OnInformationBindingCollectionChanged;
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
            this.FeatureObject.InformationBindingCollectionChanged += base.OnInformationBindingCollectionChanged;
            this.FeatureObject.FeatureBindingCollectionChanged += base.OnFeatureBindingCollectionChanged;
        }

        public SelectedFeatureTypeObjectViewModel(FeatureViewModel featureObject, Primitives primitive) {
            this.FeatureObject = featureObject;
            this.informationBindingDefinitions = featureObject.informationBindingDefinitionsByPrimitive(primitive);
            this.featureBindingDefinitions = featureObject.featureBindingDefinitions;

            this.FeatureObject.PropertyChanged += base.OnPropertyChanged;
            this.FeatureObject.InformationBindingCollectionChanged += base.OnInformationBindingCollectionChanged;
            this.FeatureObject.FeatureBindingCollectionChanged += base.OnFeatureBindingCollectionChanged;
        }

        public FeatureViewModel FeatureObject { get; private set; }

        public informationBindingDefinition[] informationBindingDefinitions { get; private set; }

        public featureBindingDefinition[] featureBindingDefinitions { get; private set; }
    }

    public class S100AttributeEditorControlHost
    {
        public required Func<QueryInformationTypesEventArgs, Task<IEnumerable<InformationTypeId>>> QueryInformationTypes { get; set; }

        public required Func<QueryFeatureTypesEventArgs, Task<IEnumerable<FeatureTypeId>>> QueryFeatureTypes { get; set; }

        public required Action<SelectInformationBindingEventArgs> SelectInformationBinding { get; set; }

        public required Action<SelectFeatureBindingEventArgs> SelectFeatureBinding { get; set; }
    }


    public class S100AttributeEditorFeatureViewModel<T> where T : class
    {
        public S100AttributeEditorControl Host { get; set; }
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

        public static S100AttributeEditorControl Singleton { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public event PropertyChangedEventHandler? InformationBindingCollectionChanged;

        public event PropertyChangedEventHandler? FeatureBindingCollectionChanged;

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        static S100AttributeEditorControl() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(S100AttributeEditorControl), new FrameworkPropertyMetadata(typeof(S100AttributeEditorControl)));
        }

        public S100AttributeEditorControl() {
            Singleton = this;
            this.InitCommands();
        }

        private void InitCommands() {

            CommandBinding binding;

            binding = new CommandBinding(S100AttributeEditorControl.DropDownContextMenuOpeningCommand, this.DropDownContextMenuOpeningCommandContent);
            this.CommandBindings.Add(binding);

            //  InformationBindings
            binding = new CommandBinding(S100AttributeEditorControl.InformationAssociationSelectedCommand, this.InformationAssociationSelectedCommandContent);
            this.CommandBindings.Add(binding);
            binding = new CommandBinding(S100AttributeEditorControl.QueryInformationsCommand, this.QueryInformationsContent);
            this.CommandBindings.Add(binding);

            //  FeatureBindings
            binding = new CommandBinding(S100AttributeEditorControl.FeatureAssociationSelectedCommand, this.FeatureAssociationSelectedContent);
            this.CommandBindings.Add(binding);
            binding = new CommandBinding(S100AttributeEditorControl.QueryFeaturesCommand, this.QueryFeaturesContent);
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
                    this.SelectedInformationObject.InformationObject.InformationBindingCollectionChanged -= this.SelectedObject_InformationBindingCollectionChanged;
                    this.SelectedInformationObject.InformationObject.PropertyChanged -= this.SelectedObject_PropertyChanged;
                }
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

            if (control.PropertyGrid != null) {
                control.PropertyGrid.SelectedObject = control._selectedObject;
                control.PropertyGrid.SelectedObjectTypeName = control._selectedObject.ToString();
            }

            if (control.SelectedInformationObject.InformationObject != null) {
                control.SelectedInformationObject.InformationObject.PropertyChanged += control.SelectedObject_PropertyChanged;
                control.SelectedInformationObject.InformationObject.InformationBindingCollectionChanged += control.SelectedObject_InformationBindingCollectionChanged;
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
                    this.SelectedFeatureObject.FeatureObject.InformationBindingCollectionChanged -= this.SelectedObject_InformationBindingCollectionChanged;
                    this.SelectedFeatureObject.FeatureObject.FeatureBindingCollectionChanged -= this.SelectedObject_FeatureBindingCollectionChanged;
                    this.SelectedFeatureObject.FeatureObject.PropertyChanged -= this.SelectedObject_PropertyChanged;
                }
                //if (SelectedInformationObject != null) {
                //    this.SelectedInformationObject.InformationObject.PropertyChanged -= this.SelectedObject_PropertyChanged;
                //}
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

            if (control.PropertyGrid != null) {
                control.PropertyGrid.SelectedObject = control._selectedObject;
                control.PropertyGrid.SelectedObjectTypeName = control._selectedObject.ToString();
            }

            if (control.SelectedFeatureObject.FeatureObject != null) {
                control.SelectedFeatureObject.FeatureObject.PropertyChanged += control.SelectedObject_PropertyChanged;
                control.SelectedFeatureObject.FeatureObject.InformationBindingCollectionChanged += control.SelectedObject_InformationBindingCollectionChanged;
                control.SelectedFeatureObject.FeatureObject.FeatureBindingCollectionChanged += control.SelectedObject_FeatureBindingCollectionChanged;
            }
        }

        private void SelectedObject_PropertyChanged(object? sender, PropertyChangedEventArgs e) {
            this.PropertyChanged?.Invoke(sender, e);
        }

        private void SelectedObject_InformationBindingCollectionChanged(object? sender, PropertyChangedEventArgs e) {
            this.InformationBindingCollectionChanged?.Invoke(sender, e);
        }

        private void SelectedObject_FeatureBindingCollectionChanged(object? sender, PropertyChangedEventArgs e) {
            this.FeatureBindingCollectionChanged?.Invoke(sender, e);
        }

        #endregion


        #region Commands

        private DropDownButton? _activeDropDownButton = default;

        public static RoutedUICommand DropDownContextMenuOpeningCommand = new("DropDownContextMenuOpeningCommand", "DropDownContextMenuOpeningCommand", typeof(S100AttributeEditorControl));

        private void DropDownContextMenuOpeningCommandContent(object sender, ExecutedRoutedEventArgs e) {
            _activeDropDownButton = (DropDownButton)e.Parameter;
        }

        #endregion


        #region InformationBindings

        public static RoutedUICommand InformationAssociationSelectedCommand = new("Information association selected.", "InformationAssociationSelectedCommand", typeof(S100AttributeEditorControl));

        private void InformationAssociationSelectedCommandContent(object sender, ExecutedRoutedEventArgs e) {
        }

        public static RoutedUICommand QueryInformationsCommand = new("Query informations.", "QueryInformationsCommand", typeof(S100AttributeEditorControl));

        private async void QueryInformationsContent(object sender, ExecutedRoutedEventArgs e) {
            var eventArgs = (QueryInformationTypesEventArgs)e.Parameter;

            var items = await Host.QueryInformationTypes(eventArgs);
            var parameter = (QueryInformationTypesEventArgs)e.Parameter;
            parameter?.callback?.Invoke([.. items]);
        }

        #endregion


        #region FeatureBindingss

        public static RoutedUICommand FeatureAssociationSelectedCommand = new("Feature association selected.", "FeatureAssociationSelectedCommand", typeof(S100AttributeEditorControl));

        private void FeatureAssociationSelectedContent(object sender, ExecutedRoutedEventArgs e) {
        }

        public static RoutedUICommand QueryFeaturesCommand = new("Query features.", "QueryFeaturesContent", typeof(S100AttributeEditorControl));

        private async void QueryFeaturesContent(object sender, ExecutedRoutedEventArgs e) {
            var eventArgs = (QueryFeatureTypesEventArgs)e.Parameter;

            var items = await Host.QueryFeatureTypes(eventArgs);

            var parameter = (QueryFeatureTypesEventArgs)e.Parameter;
            parameter?.callback?.Invoke([..items]);
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
