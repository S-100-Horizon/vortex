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
    /// Represents a collection property with add/remove capabilities
    /// </summary>
    public class CollectionPropertyItem : PropertyItem
    {
        public IList? Collection { get; set; }
        public Type? ElementType { get; set; }

        public CollectionPropertyItem()
        {
            IsCollection = true;
        }

        public bool CanAddItems
        {
            get
            {
                if (Collection == null || IsReadOnly) return false;
                return !Collection.IsReadOnly && !Collection.IsFixedSize;
            }
        }

        public bool CanRemoveItems
        {
            get
            {
                if (Collection == null || IsReadOnly) return false;
                return !Collection.IsReadOnly && !Collection.IsFixedSize && Collection.Count > 0;
            }
        }

        public void AddItem()
        {
            if (!CanAddItems || ElementType == null) return;

            try
            {
                object? newItem = CreateDefaultInstance(ElementType);
                Collection!.Add(newItem);
                RefreshChildren();
                
                // Notify that the value (collection) has changed
                OnPropertyChanged(nameof(Value));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error adding item: {ex.Message}");
            }
        }

        public void RemoveItem(object item)
        {
            if (!CanRemoveItems) return;

            try
            {
                Collection!.Remove(item);
                RefreshChildren();
                
                // Notify that the value (collection) has changed
                OnPropertyChanged(nameof(Value));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error removing item: {ex.Message}");
            }
        }

        public void RemoveItemAt(int index)
        {
            if (!CanRemoveItems || index < 0 || index >= Collection!.Count) return;

            try
            {
                Collection.RemoveAt(index);
                RefreshChildren();
                
                // Notify that the value (collection) has changed
                OnPropertyChanged(nameof(Value));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error removing item at index {index}: {ex.Message}");
            }
        }

        public void RefreshChildren()
        {
            System.Diagnostics.Debug.WriteLine($"RefreshChildren called on collection with {Collection?.Count ?? 0} items");
            
            if (Collection == null)
            {
                Children.Clear();
                OnPropertyChanged(nameof(HasChildren));
                OnPropertyChanged(nameof(CanAddItems));
                OnPropertyChanged(nameof(CanRemoveItems));
                return;
            }

            // Instead of clearing everything, synchronize the children with the collection
            // This preserves existing items and their expansion state
            
            System.Diagnostics.Debug.WriteLine($"Current Children.Count: {Children.Count}, Collection.Count: {Collection.Count}");
            
            // First, update indices for existing children and remove obsolete ones
            for (int i = Children.Count - 1; i >= 0; i--)
            {
                if (i >= Collection.Count)
                {
                    // This child is beyond the collection size, remove it
                    System.Diagnostics.Debug.WriteLine($"Removing child at index {i}");
                    Children.RemoveAt(i);
                }
                else
                {
                    // Update the child to reflect current index and value
                    var childItem = Children[i];
                    var collectionItem = Collection[i];
                    
                    childItem.Name = $"[{i}]";
                    childItem.DisplayName = $"[{i}]";
                    childItem.CollectionIndex = i;
                    
                    System.Diagnostics.Debug.WriteLine($"Updated child {i}: Name={childItem.Name}");
                    
                    // Update value if it changed
                    if (!ReferenceEquals(childItem.Value, collectionItem))
                    {
                        childItem.Value = collectionItem;
                        childItem.PropertyType = collectionItem?.GetType() ?? ElementType ?? typeof(object);
                        
                        // If complex type, refresh its children
                        if (collectionItem != null && IsComplexTypeInternal(collectionItem.GetType()))
                        {
                            childItem.IsComplexType = true;
                            childItem.Children.Clear();
                            var childProperties = PropertyGridBuilder.GetProperties(collectionItem, Level + 2);
                            foreach (var childProp in childProperties)
                            {
                                childItem.Children.Add(childProp);
                            }
                        }
                    }
                }
            }
            
            // Add new children for any new items in the collection
            for (int index = Children.Count; index < Collection.Count; index++)
            {
                System.Diagnostics.Debug.WriteLine($"Adding new child at index {index}");
                var item = Collection[index];
                var childItem = new PropertyItem
                {
                    Name = $"[{index}]",
                    DisplayName = $"[{index}]",
                    PropertyType = item?.GetType() ?? ElementType ?? typeof(object),
                    ParentObject = Collection,
                    Level = Level + 1,
                    Value = item,
                    IsReadOnly = IsReadOnly,
                    CollectionIndex = index,
                    ParentCollectionItem = this
                };

                // If the item is a complex type, expand its properties
                if (item != null && IsComplexTypeInternal(item.GetType()))
                {
                    childItem.IsComplexType = true;
                    var childProperties = PropertyGridBuilder.GetProperties(item, Level + 2);
                    foreach (var childProp in childProperties)
                    {
                        childItem.Children.Add(childProp);
                    }
                }

                Children.Add(childItem);
            }

            System.Diagnostics.Debug.WriteLine($"RefreshChildren complete. Children.Count: {Children.Count}");
            
            // Notify property changes that depend on collection state
            OnPropertyChanged(nameof(HasChildren));
            OnPropertyChanged(nameof(CanAddItems));
            OnPropertyChanged(nameof(CanRemoveItems));
        }

        private object? CreateDefaultInstance(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }

            // Try to find a parameterless constructor
            var constructor = type.GetConstructor(Type.EmptyTypes);
            if (constructor != null)
            {
                return Activator.CreateInstance(type);
            }

            // For strings
            if (type == typeof(string))
            {
                return string.Empty;
            }

            return null;
        }

        private bool IsComplexTypeInternal(Type type)
        {
            return !type.IsPrimitive &&
                   type != typeof(string) &&
                   type != typeof(DateTime) &&
                   type != typeof(decimal) &&
                   type != typeof(Guid) &&
                   !type.IsEnum;
        }
    }

    /// <summary>
    /// Helper class to build property items from objects using reflection
    /// </summary>
    public static class PropertyGridBuilder
    {
        public static ObservableCollection<PropertyItem> GetProperties(object obj, int level = 0)
        {
            var items = new ObservableCollection<PropertyItem>();
            if (obj == null) return items;

            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in properties.OrderBy(p => p.Name))
            {
                // Skip indexed properties
                if (prop.GetIndexParameters().Length > 0)
                    continue;

                try
                {
                    object? value = prop.CanRead ? prop.GetValue(obj) : null;
                    
                    // Check if it's a collection
                    if (typeof(IList).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string))
                    {
                        var collectionItem = CreateCollectionItem(prop, obj, value as IList, level);
                        items.Add(collectionItem);
                    }
                    else if (IsComplexType(prop.PropertyType))
                    {
                        var complexItem = CreateComplexItem(prop, obj, value, level);
                        items.Add(complexItem);
                    }
                    else
                    {
                        var simpleItem = CreateSimpleItem(prop, obj, value, level);
                        items.Add(simpleItem);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error processing property {prop.Name}: {ex.Message}");
                }
            }

            return items;
        }

        private static CollectionPropertyItem CreateCollectionItem(PropertyInfo prop, object parentObj, IList? collection, int level)
        {
            Type elementType = typeof(object);
            
            // Try to determine element type
            if (prop.PropertyType.IsGenericType)
            {
                Type[] genericArgs = prop.PropertyType.GetGenericArguments();
                if (genericArgs.Length > 0)
                {
                    elementType = genericArgs[0];
                }
            }
            else if (prop.PropertyType.IsArray)
            {
                elementType = prop.PropertyType.GetElementType() ?? typeof(object);
            }

            var item = new CollectionPropertyItem
            {
                Name = prop.Name,
                DisplayName = GetDisplayName(prop),
                PropertyType = prop.PropertyType,
                PropertyInfo = prop,
                ParentObject = parentObj,
                Level = level,
                Value = collection,
                Collection = collection,
                ElementType = elementType,
                IsReadOnly = !prop.CanWrite,
                Category = GetCategory(prop),
                Description = GetDescription(prop)
            };

            // Populate collection items
            if (collection != null)
            {
                int index = 0;
                foreach (var element in collection)
                {
                    var childItem = new PropertyItem
                    {
                        Name = $"[{index}]",
                        DisplayName = $"[{index}]",
                        PropertyType = element?.GetType() ?? elementType,
                        ParentObject = collection,
                        Level = level + 1,
                        Value = element,
                        IsReadOnly = item.IsReadOnly,
                        CollectionIndex = index, // Store the index
                        ParentCollectionItem = item // Store reference to parent
                    };

                    if (element != null && IsComplexType(element.GetType()))
                    {
                        childItem.IsComplexType = true;
                        var childProperties = GetProperties(element, level + 2);
                        foreach (var childProp in childProperties)
                        {
                            childItem.Children.Add(childProp);
                        }
                    }

                    item.Children.Add(childItem);
                    index++;
                }
            }

            return item;
        }

        private static PropertyItem CreateComplexItem(PropertyInfo prop, object parentObj, object? value, int level)
        {
            var item = new PropertyItem
            {
                Name = prop.Name,
                DisplayName = GetDisplayName(prop),
                PropertyType = prop.PropertyType,
                PropertyInfo = prop,
                ParentObject = parentObj,
                Level = level,
                Value = value,
                IsReadOnly = !prop.CanWrite,
                IsComplexType = true,
                Category = GetCategory(prop),
                Description = GetDescription(prop)
            };

            // Recursively get properties of complex type
            if (value != null)
            {
                var childProperties = GetProperties(value, level + 1);
                foreach (var childProp in childProperties)
                {
                    item.Children.Add(childProp);
                }
            }

            return item;
        }

        private static PropertyItem CreateSimpleItem(PropertyInfo prop, object parentObj, object? value, int level)
        {
            return new PropertyItem
            {
                Name = prop.Name,
                DisplayName = GetDisplayName(prop),
                PropertyType = prop.PropertyType,
                PropertyInfo = prop,
                ParentObject = parentObj,
                Level = level,
                Value = value,
                IsReadOnly = !prop.CanWrite,
                Category = GetCategory(prop),
                Description = GetDescription(prop)
            };
        }

        private static bool IsComplexType(Type type)
        {
            // Unwrap nullable types
            Type actualType = Nullable.GetUnderlyingType(type) ?? type;

            return !actualType.IsPrimitive &&
                   actualType != typeof(string) &&
                   actualType != typeof(DateTime) &&
                   actualType != typeof(decimal) &&
                   actualType != typeof(Guid) &&
                   !actualType.IsEnum &&
                   actualType != typeof(object);
        }

        private static string GetDisplayName(PropertyInfo prop)
        {
            var displayAttr = prop.GetCustomAttribute<DisplayNameAttribute>();
            return displayAttr?.DisplayName ?? prop.Name;
        }

        private static string? GetCategory(PropertyInfo prop)
        {
            var categoryAttr = prop.GetCustomAttribute<CategoryAttribute>();
            return categoryAttr?.Category;
        }

        private static string? GetDescription(PropertyInfo prop)
        {
            var descAttr = prop.GetCustomAttribute<DescriptionAttribute>();
            return descAttr?.Description;
        }
    }
}
