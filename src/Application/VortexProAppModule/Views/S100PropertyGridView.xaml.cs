using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using VortexProAppModule.S100PropertyGrid;

//  https://formatexception.com/2014/04/binding-a-dependency-property-of-a-view-to-its-viewmodel/

//  https://stackoverflow.com/questions/25672037/how-to-correctly-bind-to-a-dependency-property-of-a-usercontrol-in-a-mvvm-framew

namespace VortexProAppModule.Views
{
    /// <summary>
    /// Interaction logic for S100PropertyGrid.xaml
    /// </summary>
    public partial class S100PropertyGridView : UserControl, ISupportInitialize
    {
        public static object MockDataSource => new PropertyItemComplex {
            DisplayName = "QualityOfNonBathymetricData",
            PropertyType = typeof(object),
            Properties = new List<PropertyItemBase> {
                new PropertyItem {
                    DisplayName = "categoryOfTemporalVariation",
                    PropertyType = typeof(int),
                    Value = 1,
                },
                new PropertyItem {
                    DisplayName = "horizontalDistanceUncertainty",
                    PropertyType = typeof(decimal),
                    Value = 28.4
                },
                new PropertyItemComplex {
                    DisplayName = "horizontalPositionUncertainty",
                    PropertyType = typeof(object),
                    Properties = new List<PropertyItemBase> {
                        new PropertyItem {
                            DisplayName = "uncertaintyFixed",
                            PropertyType = typeof(decimal),
                            Value = 2.8,
                        },
                        new PropertyItem {
                            DisplayName = "uncertaintyVariableFactor",
                            PropertyType = typeof(decimal),
                            Value = 3,
                        },
                    },
                },
            },
        };

        public static object MockViewModel => new {
            ViewModel = new S100PropertyGridViewModel {
                DisplayName = "QualityOfNonBathymetricData",
            }
        };

        public S100PropertyGridView() {
            InitializeComponent();
        }


        #region Members

        private bool _hasPendingSelectedObjectChanged;
        private int _initializationCount;
        //private Toolkit.ObjectContainerHelper _objectContainerHelper;

        public S100PropertyGridViewModel ViewModel { get; set; } = new S100PropertyGridViewModel();

        #endregion

        #region Interfaces

        #region ISupportInitialize Members

        public override void BeginInit() {
            base.BeginInit();
            _initializationCount++;
        }

        public override void EndInit() {
            base.EndInit();
            if (--_initializationCount == 0) {
                if (_hasPendingSelectedObjectChanged) {
                    //This will update SelectedObject, Type, Name based on the actual config.
                    this.UpdateContainerHelper();
                    _hasPendingSelectedObjectChanged = false;
                }
                //if (_containerHelper != null) {
                //    _containerHelper.OnEndInit();
                //}
            }
        }

        #endregion

        #endregion

        #region SelectedObject

        public static readonly DependencyProperty SelectedObjectProperty = DependencyProperty.Register(
            "SelectedObject",
            typeof(object),
            typeof(S100PropertyGridView),
            new UIPropertyMetadata(null, OnSelectedObjectChanged));

        public object SelectedObject {
            get {
                return (object)GetValue(SelectedObjectProperty);
            }
            set {
                SetValue(SelectedObjectProperty, value);
            }
        }

        private static void OnSelectedObjectChanged(DependencyObject o, DependencyPropertyChangedEventArgs e) {
            S100PropertyGridView propertyInspector = o as S100PropertyGridView;
            if (propertyInspector != null)
                propertyInspector.OnSelectedObjectChanged((object)e.OldValue, (object)e.NewValue);
        }

        protected virtual void OnSelectedObjectChanged(object oldValue, object newValue) {
            //// We do not want to process the change now if the grid is initializing (ie. BeginInit/EndInit).
            if (_initializationCount != 0) {
                _hasPendingSelectedObjectChanged = true;
                return;
            }

            this.UpdateContainerHelper();

            RaiseEvent(new RoutedPropertyChangedEventArgs<object>(oldValue, newValue, S100PropertyGridView.SelectedObjectChangedEvent));
        }

        #endregion //SelectedObject

        #region SelectedObjectChangedEventRouted Routed Event

        public static readonly RoutedEvent SelectedObjectChangedEvent = EventManager.RegisterRoutedEvent("SelectedObjectChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<object>), typeof(S100PropertyGridView));

        public event RoutedPropertyChangedEventHandler<object> SelectedObjectChanged {
            add {
                AddHandler(SelectedObjectChangedEvent, value);
            }
            remove {
                RemoveHandler(SelectedObjectChangedEvent, value);
            }
        }

        #endregion

        private void UpdateContainerHelper() {
            // Keep a backup of the template element and initialize the
            // new helper with it.
            //ItemsControl childrenItemsControl = (_containerHelper != null) ? _containerHelper.ChildrenItemsControl : null;
            //ObjectContainerHelperBase objectContainerHelper = null;


            //_objectContainerHelper = new ObjectContainerHelper(this, SelectedObject);
            //objectContainerHelper.ObjectsGenerated += this.ObjectContainerHelper_ObjectsGenerated;
            //objectContainerHelper.GenerateProperties();

            //this.DisplayName = string.Empty;

            if (SelectedObject == default) return;

            this.ViewModel.Load(SelectedObject);

            //((S100PropertyGridViewModel)this.DataContext).Load(SelectedObject);
            //this._viewModel.Load(SelectedObject);
            //this.ViewModel.Load(SelectedObject);

            //DataContext = new S100PropertyGridViewModel(SelectedObject);

            //this.ViewModel=new S100PropertyGridViewModel(SelectedObject);

            //this.DisplayName = SelectedObject.GetType().Name;

            //var properties = PropertyCollection.GetPropertyItemCollection(SelectedObject);
        }
    }
}

#if null

namespace VortexProAppModule.Toolkit.Core
{
    internal static class ReflectionHelper {
        [DebuggerStepThrough]
        internal static string GetPropertyOrFieldName(MemberExpression expression) {
            string propertyOrFieldName;
            if (!ReflectionHelper.TryGetPropertyOrFieldName(expression, out propertyOrFieldName))
                throw new InvalidOperationException("Unable to retrieve the property or field name.");

            return propertyOrFieldName;
        }

        [DebuggerStepThrough]
        internal static string GetPropertyOrFieldName<TMember>(Expression<Func<TMember>> expression) {
            string propertyOrFieldName;
            if (!ReflectionHelper.TryGetPropertyOrFieldName(expression, out propertyOrFieldName))
                throw new InvalidOperationException("Unable to retrieve the property or field name.");

            return propertyOrFieldName;
        }

        [DebuggerStepThrough]
        internal static bool TryGetPropertyOrFieldName(MemberExpression expression, out string propertyOrFieldName) {
            propertyOrFieldName = null;

            if (expression == null)
                return false;

            propertyOrFieldName = expression.Member.Name;

            return true;
        }

        [DebuggerStepThrough]
        internal static bool TryGetPropertyOrFieldName<TMember>(Expression<Func<TMember>> expression, out string propertyOrFieldName) {
            propertyOrFieldName = null;

            if (expression == null)
                return false;

            return ReflectionHelper.TryGetPropertyOrFieldName(expression.Body as MemberExpression, out propertyOrFieldName);
        }
    }
}

namespace VortexProAppModule.Toolkit.Converters
{
    internal class ListConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
            return true;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
            return (destinationType == typeof(string));
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) {
            if (value == null)
                return null;

            string names = value as string;

            var list = new List<object>();
            if (names == null && value != null) {
                list.Add(value);
            }
            else {
                if (names == null)
                    return null;

                foreach (var name in names.Split(',')) {
                    list.Add(name.Trim());
                }
            }

            return new ReadOnlyCollection<object>(list);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType) {
            if (destinationType != typeof(string))
                throw new InvalidOperationException("Can only convert to string.");


            IList strs = (IList)value;

            if (strs == null)
                return null;

            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (object o in strs) {
                if (o == null)
                    throw new InvalidOperationException("Property names cannot be null.");

                string s = o as string;
                if (s == null)
                    throw new InvalidOperationException("Does not support serialization of non-string property names.");

                if (s.Contains(','))
                    throw new InvalidOperationException("Property names cannot contain commas.");

                if (s.Trim().Length != s.Length)
                    throw new InvalidOperationException("Property names cannot start or end with whitespace characters.");

                if (!first) {
                    sb.Append(", ");
                }
                first = false;

                sb.Append(s);
            }

            return sb.ToString();
        }
    }
}

namespace VortexProAppModule.Toolkit
{
    using System.Linq.Expressions;
    using VortexProAppModule.Toolkit.Core;
    using VortexProAppModule.Toolkit.Converters;
    using System.Collections.Specialized;
    using System.Windows.Data;

    public abstract class DefinitionBase : DependencyObject
    {
        private bool _isLocked;

        internal bool IsLocked {
            get {
                return _isLocked;
            }
        }

        internal void ThrowIfLocked<TMember>(Expression<Func<TMember>> propertyExpression) {
            //In XAML, when using any properties of PropertyDefinition, the error of ThrowIfLocked is always thrown => prevent it !
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            if (this.IsLocked) {
                string propertyName = ReflectionHelper.GetPropertyOrFieldName(propertyExpression);
                string message = string.Format(
                    @"Cannot modify {0} once the definition has beed added to a collection.",
                    propertyName);
                throw new InvalidOperationException(message);
            }
        }

        internal virtual void Lock() {
            if (!_isLocked) {
                _isLocked = true;
            }
        }
    }

    public abstract class PropertyDefinitionBase : DefinitionBase
    {
        #region Constructors

        internal PropertyDefinitionBase() {
            _targetProperties = new List<object>();
            this.PropertyDefinitions = new PropertyDefinitionCollection();
        }

        #endregion

        #region Properties

        #region TargetProperties

        [TypeConverter(typeof(ListConverter))]
        public IList TargetProperties {
            get {
                return _targetProperties;
            }
            set {
                this.ThrowIfLocked(() => this.TargetProperties);
                _targetProperties = value;
            }
        }

        private IList _targetProperties;

        #endregion

        #region PropertyDefinitions

        public PropertyDefinitionCollection PropertyDefinitions {
            get {
                return _propertyDefinitions;
            }
            set {
                this.ThrowIfLocked(() => this.PropertyDefinitions);
                _propertyDefinitions = value;
            }
        }

        private PropertyDefinitionCollection _propertyDefinitions;

        #endregion //PropertyDefinitions

        #endregion

        #region Overrides

        internal override void Lock() {
            if (this.IsLocked)
                return;

            base.Lock();

            // Just create a new copy of the properties target to ensure 
            // that the list doesn't ever get modified.

            List<object> newList = new List<object>();
            if (_targetProperties != null) {
                foreach (object p in _targetProperties) {
                    object prop = p;
                    // Convert all TargetPropertyType to Types
                    var targetType = prop as TargetPropertyType;
                    if (targetType != null) {
                        prop = targetType.Type;
                    }
                    newList.Add(prop);
                }
            }

            //In Designer Mode, the Designer is broken if using a ReadOnlyCollection
            _targetProperties = DesignerProperties.GetIsInDesignMode(this)
                                ? new Collection<object>(newList)
                                : new ReadOnlyCollection<object>(newList) as IList;
        }

        #endregion
    }

    public class PropertyDefinition : PropertyDefinitionBase
    {
        private string _name;
        private bool? _isBrowsable = true;
        private bool? _isExpandable = null;
        private string _displayName = null;
        private string _description = null;
        private string _category = null;
        private int? _displayOrder = null;

        [Obsolete(@"Use 'TargetProperties' instead of 'Name'")]
        public string Name {
            get {
                return _name;
            }
            set {
                const string usageError = "{0}: \'Name\' property is obsolete. Instead use \'TargetProperties\'. (XAML example: <t:PropertyDefinition TargetProperties=\"FirstName,LastName\" />)";
                System.Diagnostics.Trace.TraceWarning(usageError, typeof(PropertyDefinition));
                _name = value;
            }
        }

        public string Category {
            get {
                return _category;
            }
            set {
                this.ThrowIfLocked(() => this.Category);
                _category = value;
            }
        }

        public string DisplayName {
            get {
                return _displayName;
            }
            set {
                this.ThrowIfLocked(() => this.DisplayName);
                _displayName = value;
            }
        }

        public string Description {
            get {
                return _description;
            }
            set {
                this.ThrowIfLocked(() => this.Description);
                _description = value;
            }
        }

        public int? DisplayOrder {
            get {
                return _displayOrder;
            }
            set {
                this.ThrowIfLocked(() => this.DisplayOrder);
                _displayOrder = value;
            }
        }

        public bool? IsBrowsable {
            get {
                return _isBrowsable;
            }
            set {
                this.ThrowIfLocked(() => this.IsBrowsable);
                _isBrowsable = value;
            }
        }

        public bool? IsExpandable {
            get {
                return _isExpandable;
            }
            set {
                this.ThrowIfLocked(() => this.IsExpandable);
                _isExpandable = value;
            }
        }

        internal override void Lock() {
            if (_name != null
              && this.TargetProperties != null
              && this.TargetProperties.Count > 0) {
                throw new InvalidOperationException(
                  string.Format(
                    @"{0}: When using 'TargetProperties' property, do not use 'Name' property.",
                    typeof(PropertyDefinition)));
            }

            if (_name != null) {
                this.TargetProperties = new List<object>() { _name };
            }
            base.Lock();
        }
    }

    public class PropertyItemCollection : ReadOnlyObservableCollection<PropertyItem>
    {
        internal static readonly string CategoryPropertyName;
        internal static readonly string CategoryOrderPropertyName;
        internal static readonly string PropertyOrderPropertyName;
        internal static readonly string DisplayNamePropertyName;

        private bool _preventNotification;

        static PropertyItemCollection() {
            PropertyItem p = null;
            CategoryPropertyName = ReflectionHelper.GetPropertyOrFieldName(() => p.Category);
            CategoryOrderPropertyName = ReflectionHelper.GetPropertyOrFieldName(() => p.CategoryOrder);
            PropertyOrderPropertyName = ReflectionHelper.GetPropertyOrFieldName(() => p.PropertyOrder);
            DisplayNamePropertyName = ReflectionHelper.GetPropertyOrFieldName(() => p.DisplayName);
        }

        public PropertyItemCollection(ObservableCollection<PropertyItem> editableCollection)
          : base(editableCollection) {
            EditableCollection = editableCollection;
        }

        internal Predicate<object> FilterPredicate {
            get {
                return GetDefaultView().Filter;
            }
            set {
                GetDefaultView().Filter = value;
            }
        }

        public ObservableCollection<PropertyItem> EditableCollection {
            get; private set;
        }

        private ICollectionView GetDefaultView() {
            return CollectionViewSource.GetDefaultView(this);
        }

        public void GroupBy(string name) {
            GetDefaultView().GroupDescriptions.Add(new PropertyGroupDescription(name));
        }

        public void SortBy(string name, ListSortDirection sortDirection) {
            GetDefaultView().SortDescriptions.Add(new SortDescription(name, sortDirection));
        }

        public void Filter(string text) {
            Predicate<object> filter = PropertyItemCollection.CreateFilter(text, this.Items, null);
            GetDefaultView().Filter = filter;
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs args) {
            if (_preventNotification)
                return;

            base.OnCollectionChanged(args);
        }

        internal void UpdateItems(IEnumerable<PropertyItem> newItems) {
            if (newItems == null)
                throw new ArgumentNullException("newItems");

            _preventNotification = true;
            using (GetDefaultView().DeferRefresh()) {
                EditableCollection.Clear();
                foreach (var item in newItems) {
                    this.EditableCollection.Add(item);
                }
            }
            _preventNotification = false;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        internal void UpdateCategorization(GroupDescription groupDescription, bool isPropertyGridCategorized, bool sortAlphabetically) {
            // Compute Display Order relative to PropertyOrderAttributes on PropertyItem
            // which could be different in Alphabetical or Categorized mode.
            foreach (PropertyItem item in this.Items) {
                item.DescriptorDefinition.DisplayOrder = item.DescriptorDefinition.ComputeDisplayOrderInternal(isPropertyGridCategorized);
                item.PropertyOrder = item.DescriptorDefinition.DisplayOrder;
            }

            // Clear view values
            ICollectionView view = this.GetDefaultView();
            using (view.DeferRefresh()) {
                view.GroupDescriptions.Clear();
                view.SortDescriptions.Clear();

                // Update view values
                if (groupDescription != null) {
                    view.GroupDescriptions.Add(groupDescription);
                    SortBy(CategoryOrderPropertyName, ListSortDirection.Ascending);
                    SortBy(CategoryPropertyName, ListSortDirection.Ascending);
                }

                SortBy(PropertyOrderPropertyName, ListSortDirection.Ascending);

                if (sortAlphabetically) {
                    SortBy(DisplayNamePropertyName, ListSortDirection.Ascending);
                }
            }
        }

        internal void RefreshView() {
            GetDefaultView().Refresh();
        }

        internal static Predicate<object> CreateFilter(string text, IList<PropertyItem> PropertyItems, IPropertyContainer propertyContainer) {
            Predicate<object> filter = null;

            if (!string.IsNullOrEmpty(text)) {
                filter = (item) =>
                {
                    var property = item as PropertyItem;
                    if (property.DisplayName != null) {
#if !VS2008
                        var displayAttribute = PropertyGridUtilities.GetAttribute<DisplayAttribute>(property.PropertyDescriptor);
                        if (displayAttribute != null) {
                            var canBeFiltered = displayAttribute.GetAutoGenerateFilter();
                            if (canBeFiltered.HasValue && !canBeFiltered.Value)
                                return false;
                        }
#endif
                        property.HighlightedText = property.DisplayName.ToLower().Contains(text.ToLower()) ? text : null;
                        return (property.HighlightedText != null);
                    }

                    return false;
                };
            }
            else {
                ClearFilterSubItems(PropertyItems.ToList());
            }

            return filter;
        }

        private static void ClearFilterSubItems(IList items) {
            foreach (var item in items) {
                var propertyItem = item as PropertyItemBase;
                if (propertyItem != null) {
                    propertyItem.HighlightedText = null;


                }
            }
        }
    }

    public interface IPropertyContainer {
        //bool HideInheritedProperties { get; }

        //bool AutoGenerateProperties { get; }

        //bool? IsPropertyVisible(PropertyDescriptor pd);

        //PropertyDefinitionCollection PropertyDefinitions { get; }
    }

#if null
    internal class ObjectContainerHelper
    {
        private object _selectedObject;

        private PropertyItemCollection _propertyItemCollection;

        protected readonly IPropertyContainer _propertyContainer;

        public ObjectContainerHelper(IPropertyContainer propertyContainer, object selectedObject) {
            _propertyContainer = propertyContainer;
            _selectedObject = selectedObject;
        }

        public void GenerateProperties() {
            if ((PropertyItems.Count == 0)
              ) {
                this.RegenerateProperties();
            }
        }

        private void RegenerateProperties() {
            this.GenerateSubPropertiesCore(this.UpdatePropertyItemsCallback);
        }

        protected void GenerateSubPropertiesCore(Action<IEnumerable<PropertyItem>> updatePropertyItemsCallback) {
            var propertyItems = new List<PropertyItem>();

            if (SelectedObject != null) {
                try {
                    var descriptors = new List<PropertyDescriptor>();
                    {
                        descriptors = ObjectContainerHelper.GetPropertyDescriptors(SelectedObject, this.PropertyContainer.HideInheritedProperties);
                    }

                    foreach (var descriptor in descriptors) {
                        var propertyDef = this.GetPropertyDefinition(descriptor);
                        bool isBrowsable = false;

                        var isPropertyBrowsable = this.PropertyContainer.IsPropertyVisible(descriptor);
                        if (isPropertyBrowsable.HasValue) {
                            isBrowsable = isPropertyBrowsable.Value;
                        }
                        else {
#if !VS2008
                            var displayAttribute = PropertyGridUtilities.GetAttribute<DisplayAttribute>(descriptor);
                            if (displayAttribute != null) {
                                var autoGenerateField = displayAttribute.GetAutoGenerateField();
                                isBrowsable = this.PropertyContainer.AutoGenerateProperties
                                              && ((autoGenerateField.HasValue && autoGenerateField.Value) || !autoGenerateField.HasValue);
                            }
                            else
#endif
                            {
                                isBrowsable = descriptor.IsBrowsable && this.PropertyContainer.AutoGenerateProperties;
                            }

                            if (propertyDef != null) {
                                isBrowsable = propertyDef.IsBrowsable.GetValueOrDefault(isBrowsable);
                            }
                        }

                        if (isBrowsable) {
                            var prop = this.CreatePropertyItem(descriptor, propertyDef);
                            if (prop != null) {
                                propertyItems.Add(prop);
                            }
                        }
                    }
                }
                catch (Exception e) {
                    //TODO: handle this some how
                    Debug.WriteLine("Property creation failed.");
                    Debug.WriteLine(e.StackTrace);
                }
            }

            updatePropertyItemsCallback.Invoke(propertyItems);
        }

        private PropertyItem CreatePropertyItem(PropertyDescriptor property, PropertyDefinition propertyDef) {
            //DescriptorPropertyDefinition definition = new DescriptorPropertyDefinition(property, SelectedObject, this.PropertyContainer);
            //definition.InitProperties();

            //this.InitializeDescriptorDefinition(definition, propertyDef);
            //PropertyItem propertyItem = new PropertyItem(definition);
            //Debug.Assert(SelectedObject != null);
            //propertyItem.Instance = SelectedObject;
            //propertyItem.CategoryOrder = this.GetCategoryOrder(definition.CategoryValue);

            //propertyItem.WillRefreshPropertyGrid = this.GetWillRefreshPropertyGrid(property);
            PropertyItem propertyItem = null;
            return propertyItem;
        }

        private PropertyDefinition GetPropertyDefinition(PropertyDescriptor descriptor) {
            PropertyDefinition def = null;

            var propertyDefs = this.PropertyContainer.PropertyDefinitions;
            if (propertyDefs != null) {
                def = propertyDefs[descriptor.Name];
                if (def == null) {
                    def = propertyDefs.GetRecursiveBaseTypes(descriptor.PropertyType);
                }
            }

            return def;
        }

        protected static List<PropertyDescriptor> GetPropertyDescriptors(object instance, bool hideInheritedProperties) {
            PropertyDescriptorCollection descriptors = null;

            TypeConverter tc = TypeDescriptor.GetConverter(instance);
            if (tc == null || !tc.GetPropertiesSupported()) {
                if (instance is ICustomTypeDescriptor) {
                    descriptors = ((ICustomTypeDescriptor)instance).GetProperties();
                }
                //ICustomTypeProvider is only available in .net 4.5 and over. Use reflection so the .net 4.0 and .net 3.5 still works.
                else if (instance.GetType().GetInterface("ICustomTypeProvider", true) != null) {
                    var methodInfo = instance.GetType().GetMethod("GetCustomType");
                    var result = methodInfo.Invoke(instance, null) as Type;
                    descriptors = TypeDescriptor.GetProperties(result);
                }
                else {
                    descriptors = TypeDescriptor.GetProperties(instance.GetType());
                }
            }
            else {
                try {
                    descriptors = tc.GetProperties(instance);
                }
                catch (Exception) {
                }
            }

            if ((descriptors != null)) {
                var descriptorsProperties = descriptors.Cast<PropertyDescriptor>();
                if (hideInheritedProperties) {
                    var properties = from p in descriptorsProperties
                                     where p.ComponentType == instance.GetType()
                                     select p;
                    return properties.ToList();
                }
                else {
                    return descriptorsProperties.ToList();
                }
            }

            return null;
        }

        protected IPropertyContainer PropertyContainer => _propertyContainer;

        protected object SelectedObject => _selectedObject;

        protected PropertyItemCollection PropertyItems => _propertyItemCollection;
    }
#endif
}

#endif