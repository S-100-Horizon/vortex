using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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

        public PropertyGrid()
        {
            InitializeComponent();
            _properties = new ObservableCollection<PropertyItem>();
            // DataContext is no longer set here - control is independent

            // Initialize commands
            AddCollectionItemCommand = new RelayCommand(ExecuteAddCollectionItem, CanExecuteAddCollectionItem);
            RemoveCollectionItemCommand = new RelayCommand(ExecuteRemoveCollectionItem, CanExecuteRemoveCollectionItem);
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

        public object? SelectedObject
        {
            get => GetValue(SelectedObjectProperty);
            set => SetValue(SelectedObjectProperty, value);
        }

        private static void OnSelectedObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PropertyGrid grid)
            {
                grid._selectedObject = e.NewValue;
                grid.RefreshProperties();
            }
        }

        #endregion

        #region Properties

        public ObservableCollection<PropertyItem> Properties
        {
            get => _properties;
            set
            {
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
        public void RefreshProperties()
        {
            Properties.Clear();

            if (_selectedObject == null)
                return;

            var items = PropertyGridBuilder.GetProperties(_selectedObject);
            foreach (var item in items)
            {
                Properties.Add(item);
            }
        }

        /// <summary>
        /// Updates the display to reflect changes in the object
        /// </summary>
        public void Refresh()
        {
            RefreshProperties();
        }

        #endregion

        #region Command Handlers

        private void ExecuteAddCollectionItem(object? parameter)
        {
            if (parameter is CollectionPropertyItem collectionItem)
            {
                collectionItem.AddItem();
            }
        }

        private bool CanExecuteAddCollectionItem(object? parameter)
        {
            return parameter is CollectionPropertyItem collectionItem && collectionItem.CanAddItems;
        }

        private void ExecuteRemoveCollectionItem(object? parameter)
        {
            System.Diagnostics.Debug.WriteLine($"ExecuteRemoveCollectionItem called with parameter: {parameter?.GetType().Name}");
            
            if (parameter is PropertyItem item)
            {
                System.Diagnostics.Debug.WriteLine($"Item Name: {item.Name}, CollectionIndex: {item.CollectionIndex}");
                System.Diagnostics.Debug.WriteLine($"ParentObject type: {item.ParentObject?.GetType().Name}");
                
                if (item.ParentObject is IList list)
                {
                    System.Diagnostics.Debug.WriteLine($"List Count: {list.Count}, IsReadOnly: {list.IsReadOnly}, IsFixedSize: {list.IsFixedSize}");
                    
                    try
                    {
                        // Use the stored collection index to remove the correct item
                        if (item.CollectionIndex >= 0 && item.CollectionIndex < list.Count)
                        {
                            System.Diagnostics.Debug.WriteLine($"Removing item at index {item.CollectionIndex}");
                            list.RemoveAt(item.CollectionIndex);
                            System.Diagnostics.Debug.WriteLine($"Item removed. New count: {list.Count}");
                            
                            // If we have a reference to the parent collection item, refresh it
                            // This will automatically update the UI
                            if (item.ParentCollectionItem != null)
                            {
                                System.Diagnostics.Debug.WriteLine("Refreshing parent collection item");
                                
                                // Ensure we're on the UI thread
                                Dispatcher.Invoke(() =>
                                {
                                    item.ParentCollectionItem.RefreshChildren();
                                });
                            }
                            else
                            {
                                // Fallback: refresh all properties
                                System.Diagnostics.Debug.WriteLine("No parent collection item, refreshing all properties");
                                Dispatcher.Invoke(() =>
                                {
                                    RefreshProperties();
                                });
                            }
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid index: {item.CollectionIndex}, List count: {list.Count}");
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error removing collection item: {ex.Message}");
                        System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("ParentObject is not IList");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Parameter is not PropertyItem");
            }
        }

        private bool CanExecuteRemoveCollectionItem(object? parameter)
        {
            System.Diagnostics.Debug.WriteLine($"CanExecuteRemoveCollectionItem called with parameter: {parameter?.GetType().Name ?? "null"}");
            
            if (parameter is PropertyItem item)
            {
                System.Diagnostics.Debug.WriteLine($"  Item Name: {item.Name}, CollectionIndex: {item.CollectionIndex}");
                System.Diagnostics.Debug.WriteLine($"  ParentObject: {item.ParentObject?.GetType().Name ?? "null"}");
                
                if (item.ParentObject is IList list)
                {
                    System.Diagnostics.Debug.WriteLine($"  List Count: {list.Count}, IsReadOnly: {list.IsReadOnly}, IsFixedSize: {list.IsFixedSize}");
                    bool canExecute = !list.IsReadOnly && !list.IsFixedSize && 
                           item.CollectionIndex >= 0 && item.CollectionIndex < list.Count;
                    System.Diagnostics.Debug.WriteLine($"  CanExecute result: {canExecute}");
                    return canExecute;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("  ParentObject is not IList - returning false");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("  Parameter is not PropertyItem - returning false");
            }
            
            return false;
        }

        #endregion

        #region Event Handlers

        private void NumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allow only numbers, decimal point, and minus sign
            Regex regex = new Regex("[^0-9.-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
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

        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
