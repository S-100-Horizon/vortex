using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using S100Framework.WPF.Models;

namespace S100Framework.WPF
{
    /// <summary>
    /// Property Grid control for editing object properties at runtime using reflection
    /// </summary>
    public partial class PropertyGrid : UserControl, INotifyPropertyChanged
    {
        private object? _selectedObject;
        private ObservableCollection<PropertyItem> _properties;

        public PropertyGrid() {
            InitializeComponent();
            _properties = new ObservableCollection<PropertyItem>();

            // Initialize commands
            AddCollectionItemCommand = new RelayCommand(ExecuteAddCollectionItem, CanExecuteAddCollectionItem);
            RemoveCollectionItemCommand = new RelayCommand(ExecuteRemoveCollectionItem, CanExecuteRemoveCollectionItem);

            // Subscribe to property processing errors
            PropertyGridBuilder.PropertyProcessingError += OnPropertyGridBuilderError;
        }

        #region Dependency Properties

        /// <summary>
        /// The object whose properties are being edited
        /// </summary>
        public static readonly DependencyProperty SelectedObjectProperty =
            DependencyProperty.Register(
                nameof(SelectedObject),
                typeof(object),
                typeof(PropertyGrid),
                new PropertyMetadata(null, OnSelectedObjectChanged));

        public object? SelectedObject {
            get => GetValue(SelectedObjectProperty);
            set => SetValue(SelectedObjectProperty, value);
        }

        private static void OnSelectedObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (d is PropertyGrid grid) {
                grid._selectedObject = e.NewValue;
                grid.RefreshProperties();
                grid.UpdateDescriptionForRootObject();
            }
        }

        /// <summary>
        /// The description text to display in the description panel
        /// </summary>
        public static readonly DependencyProperty SelectedDescriptionProperty =
            DependencyProperty.Register(
                nameof(SelectedDescription),
                typeof(string),
                typeof(PropertyGrid),
                new PropertyMetadata(string.Empty));

        public string SelectedDescription {
            get => (string)GetValue(SelectedDescriptionProperty);
            set => SetValue(SelectedDescriptionProperty, value);
        }

        #endregion

        #region Properties

        public ObservableCollection<PropertyItem> Properties {
            get => _properties;
            set {
                _properties = value;
                OnPropertyChanged(nameof(Properties));
            }
        }

        public ICommand AddCollectionItemCommand { get; }
        public ICommand RemoveCollectionItemCommand { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Refreshes the property list from the selected object
        /// </summary>
        public void RefreshProperties() {
            Properties.Clear();

            if (_selectedObject == null)
                return;

            var items = PropertyGridBuilder.GetProperties(_selectedObject);
            foreach (var item in items) {
                Properties.Add(item);
            }
        }

        /// <summary>
        /// Updates the display to reflect changes in the object
        /// </summary>
        public void Refresh() {
            RefreshProperties();
        }

        /// <summary>
        /// Updates the description panel to show the root object's description
        /// </summary>
        private void UpdateDescriptionForRootObject() {
            if (_selectedObject == null) {
                SelectedDescription = string.Empty;
                return;
            }

            var description = GetDescriptionFromType(_selectedObject.GetType());
            SelectedDescription = description;
        }

        /// <summary>
        /// Extracts description from a Type using reflection
        /// </summary>
        private string GetDescriptionFromType(Type type) {
            var descriptionAttr = type.GetCustomAttribute<DescriptionAttribute>();
            return descriptionAttr?.Description ?? string.Empty;
        }

        /// <summary>
        /// Extracts description from a PropertyInfo using reflection
        /// </summary>
        private string GetDescriptionFromProperty(PropertyInfo propertyInfo) {
            var descriptionAttr = propertyInfo.GetCustomAttribute<DescriptionAttribute>();
            return descriptionAttr?.Description ?? string.Empty;
        }

        #endregion

        #region Command Handlers

        private void ExecuteAddCollectionItem(object? parameter) {
            if (parameter is CollectionPropertyItem collectionItem) {
                collectionItem.AddItem();
            }
        }

        private bool CanExecuteAddCollectionItem(object? parameter) {
            return parameter is CollectionPropertyItem collectionItem && collectionItem.CanAddItems;
        }

        private void ExecuteRemoveCollectionItem(object? parameter) {
            System.Diagnostics.Debug.WriteLine($"ExecuteRemoveCollectionItem called with parameter: {parameter?.GetType().Name}");

            if (parameter is not PropertyItem item) {
                System.Diagnostics.Debug.WriteLine("Parameter is not PropertyItem");
                return;
            }

            // Get the parent collection item
            var parentCollection = item.ParentCollectionItem;
            if (parentCollection == null) {
                System.Diagnostics.Debug.WriteLine("No ParentCollectionItem found");
                return;
            }

            System.Diagnostics.Debug.WriteLine($"Item Name: {item.Name}, removing from parent collection");

            // Use the parent's RemoveChildItem method which handles everything correctly
            bool success = parentCollection.RemoveChildItem(item);
            
            System.Diagnostics.Debug.WriteLine($"Remove result: {success}");
        }

        private bool CanExecuteRemoveCollectionItem(object? parameter) {
            if (parameter is not PropertyItem item) {
                return false;
            }

            // Must have a parent collection
            var parentCollection = item.ParentCollectionItem;
            if (parentCollection == null) {
                return false;
            }

            // Check if the collection allows removal
            return parentCollection.CanRemoveItems;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Handles errors from PropertyGridBuilder
        /// </summary>
        private void OnPropertyGridBuilderError(object? sender, PropertyGridErrorEventArgs e) {
            System.Diagnostics.Debug.WriteLine($"PropertyGrid: Error processing property '{e.PropertyName}': {e.Exception.Message}");
            // Future: Could display error in UI or raise event for consumer to handle
        }

        /// <summary>
        /// Handles TreeView selection changes to update the description panel
        /// </summary>
        private void PropertyTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e) {
            if (e.NewValue is PropertyItem selectedItem) {
                // Use the Description property if it's already populated
                if (!string.IsNullOrEmpty(selectedItem.Description)) {
                    SelectedDescription = selectedItem.Description;
                }
                // Otherwise, try to get it from reflection
                else if (selectedItem.PropertyInfo != null) {
                    SelectedDescription = GetDescriptionFromProperty(selectedItem.PropertyInfo);
                }
                else {
                    SelectedDescription = string.Empty;
                }
            }
            else {
                // No property selected, show root object description
                UpdateDescriptionForRootObject();
            }
        }

        private void NumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            // Allow only numbers, decimal point, and minus sign
            Regex regex = new Regex("[^0-9.-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    /// <summary>
    /// Simple RelayCommand implementation
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;

        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null) {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter) {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter) {
            _execute(parameter);
        }
    }
}
