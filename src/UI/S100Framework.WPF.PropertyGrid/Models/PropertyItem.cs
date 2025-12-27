using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace S100Framework.WPF.Models
{
    /// <summary>
    /// Represents a property in the property grid with metadata and editing capabilities
    /// </summary>
    public class PropertyItem : INotifyPropertyChanged
    {
        private object? _value;
        private bool _isExpanded;

        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string PropertyName { get; set; }
        public Type PropertyType { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
        public object? ParentObject { get; set; }
        public int Level { get; set; }
        public ObservableCollection<PropertyItem> Children { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsCollection { get; set; }
        public bool IsComplexType { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public int CollectionIndex { get; set; } = -1; // Index in parent collection, -1 if not a collection item
        public CollectionPropertyItem? ParentCollectionItem { get; set; } // Reference to parent collection wrapper
        public Attribute[] Attributes { get; set; } = Array.Empty<Attribute>();

        public PropertyItem() {
            Name = PropertyName = string.Empty;
            DisplayName = string.Empty;
            PropertyType = typeof(object);
            PropertyInfo = null!;
            Children = new ObservableCollection<PropertyItem>();
        }

        public object? Value {
            get => _value;
            set {
                if (_value != value) {
                    _value = value;
                    OnPropertyChanged(this.PropertyName);

                    // Update the actual property on the parent object
                    if (ParentObject != null && PropertyInfo != null && PropertyInfo.CanWrite && !IsReadOnly) {
                        try {
                            // Convert value to appropriate type if needed
                            object? convertedValue = ConvertValue(value, PropertyType);
                            PropertyInfo.SetValue(ParentObject, convertedValue);
                        }
                        catch (Exception ex) {
                            System.Diagnostics.Debug.WriteLine($"Error setting property {Name}: {ex.Message}");
                        }
                    }
                }
            }
        }

        public bool IsExpanded {
            get => _isExpanded;
            set {
                if (_isExpanded != value) {
                    _isExpanded = value;
                    OnPropertyChanged(nameof(IsExpanded));
                }
            }
        }

        public bool HasChildren => Children.Count > 0;

        public bool IsSimpleType {
            get {
                return !IsCollection && !IsComplexType &&
                       (PropertyType.IsPrimitive ||
                        PropertyType == typeof(string) ||
                        PropertyType == typeof(DateTime) ||
                        PropertyType == typeof(decimal) ||
                        PropertyType == typeof(Guid) ||
                        PropertyType.IsEnum);
            }
        }

        private object? ConvertValue(object? value, Type targetType) {
            if (value == null) return null;
            if (targetType.IsAssignableFrom(value.GetType())) return value;

            try {
                // Handle nullable types
                Type underlyingType = Nullable.GetUnderlyingType(targetType) ?? targetType;

                if (underlyingType.IsEnum) {
                    return Enum.Parse(underlyingType, value.ToString()!);
                }

                return Convert.ChangeType(value, underlyingType);
            }
            catch {
                return value;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
