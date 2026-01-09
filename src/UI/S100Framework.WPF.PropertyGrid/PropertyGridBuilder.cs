using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using S100Framework.WPF.Models;

namespace S100Framework.WPF
{
    /// <summary>
    /// Helper class to build property items from objects using reflection
    /// </summary>
    public static class PropertyGridBuilder
    {
        /// <summary>
        /// Event raised when an error occurs during property processing
        /// </summary>
        public static event EventHandler<PropertyGridErrorEventArgs>? PropertyProcessingError;

        /// <summary>
        /// Gets a collection of PropertyItem objects from the specified object
        /// </summary>
        /// <param name="obj">The object to extract properties from</param>
        /// <param name="level">The indentation level for hierarchical display</param>
        /// <returns>An observable collection of PropertyItem objects</returns>
        public static ObservableCollection<PropertyItem> GetProperties(object obj, int level = 0) {
            var items = new ObservableCollection<PropertyItem>();
            if (obj == null) return items;

            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in properties) {
                // Skip indexed properties
                if (prop.GetIndexParameters().Length > 0)
                    continue;

                // Filter by Browsable attribute
                var browsableAttr = prop.GetCustomAttribute<BrowsableAttribute>();
                if (browsableAttr != null && !browsableAttr.Browsable)
                    continue;

                // Skip properties marked with JsonIgnore
                if (prop.GetCustomAttribute<System.Text.Json.Serialization.JsonIgnoreAttribute>() != null)
                    continue;

                try {
                    object? value = prop.CanRead ? prop.GetValue(obj) : null;

                    // Check if it's a collection
                    if (typeof(System.Collections.IList).IsAssignableFrom(prop.PropertyType) &&
                        prop.PropertyType != typeof(string)) {
                        var collectionItem = CreateCollectionItem(prop, obj, value as System.Collections.IList, level, prop.GetCustomAttributes());
                        items.Add(collectionItem);
                    }
                    else if (IsComplexType(prop.PropertyType)) {
                        var complexItem = CreateComplexItem(prop, obj, value, level);
                        items.Add(complexItem);
                    }
                    else {
                        var simpleItem = CreateSimpleItem(prop, obj, value, level);
                        items.Add(simpleItem);
                    }
                }
                catch (Exception ex) {
                    OnPropertyProcessingError(prop.Name, ex);
                }
            }

            return items;
        }

        /// <summary>
        /// Creates a collection property item
        /// </summary>
        private static CollectionPropertyItem CreateCollectionItem(PropertyInfo prop, object parentObj,
            System.Collections.IList? collection, int level, IEnumerable<Attribute> attributes) {
            Type elementType = typeof(object);

            // Try to determine element type
            if (prop.PropertyType.IsGenericType) {
                Type[] genericArgs = prop.PropertyType.GetGenericArguments();
                if (genericArgs.Length > 0) {
                    elementType = genericArgs[0];
                }
            }
            else if (prop.PropertyType.IsArray) {
                elementType = prop.PropertyType.GetElementType() ?? typeof(object);
            }

            var item = new CollectionPropertyItem {
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
                Description = GetDescription(prop),
                Attributes = [.. attributes],
            };

            // Wire up validation for the collection property itself
            item.SetupValidation(parentObj, prop.Name);

            // Populate collection items
            if (collection != null) {
                int index = 0;
                foreach (var element in collection) {
                    var childItem = CreateCollectionChildItem(element, elementType, index, item, level);
                    item.Children.Add(childItem);
                    index++;
                }
            }

            return item;
        }

        /// <summary>
        /// Creates a child PropertyItem for a collection element
        /// </summary>
        internal static PropertyItem CreateCollectionChildItem(object? element, Type elementType, int index, 
            CollectionPropertyItem parentCollection, int parentLevel) {
            
            var childItem = new PropertyItem {
                Name = $"[{index}]",
                DisplayName = $"[{index}]",
                PropertyType = element?.GetType() ?? elementType,
                ParentObject = parentCollection.Collection,
                Level = parentLevel + 1,
                Value = element,
                IsReadOnly = parentCollection.IsReadOnly,
                CollectionIndex = index,
                ParentCollectionItem = parentCollection,
                Attributes = parentCollection.Attributes,
            };

            // For collection items that are complex types with validation support
            if (element != null) {
                if (IsComplexType(element.GetType())) {
                    childItem.IsComplexType = true;
                    var childProperties = GetProperties(element, parentLevel + 2);
                    foreach (var childProp in childProperties) {
                        childItem.Children.Add(childProp);
                    }
                }

                // Wire up validation if the element supports it
                if (element is INotifyDataErrorInfo || element is IDataErrorInfo) {
                    // For collection items, we track the whole object's validation
                    // The child properties will have their own validation wired up
                }
            }

            return childItem;
        }

        /// <summary>
        /// Creates a complex type property item
        /// </summary>
        private static PropertyItem CreateComplexItem(PropertyInfo prop, object parentObj, object? value, int level) {
            var item = new PropertyItem {
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
                Description = GetDescription(prop),
                Attributes = [.. prop.GetCustomAttributes()],
            };

            // Wire up validation for the complex property itself
            item.SetupValidation(parentObj, prop.Name);

            // Recursively get properties of complex type
            if (value != null) {
                var childProperties = GetProperties(value, level + 1);
                foreach (var childProp in childProperties) {
                    item.Children.Add(childProp);
                }
            }

            return item;
        }

        /// <summary>
        /// Creates a simple type property item
        /// </summary>
        private static PropertyItem CreateSimpleItem(PropertyInfo prop, object parentObj, object? value, int level) {
            var item = new PropertyItem {
                Name = prop.Name,
                DisplayName = GetDisplayName(prop),                
                PropertyType = prop.PropertyType,
                PropertyInfo = prop,
                ParentObject = parentObj,
                Level = level,
                Value = value,
                IsReadOnly = !prop.CanWrite,
                Category = GetCategory(prop),
                Description = GetDescription(prop),
                Attributes = [.. prop.GetCustomAttributes()],
            };

            // Wire up validation
            item.SetupValidation(parentObj, prop.Name);

            return item;
        }

        /// <summary>
        /// Determines if a type is a complex type (not a simple value type)
        /// </summary>
        internal static bool IsComplexType(Type type) {
            // Unwrap nullable types
            Type actualType = Nullable.GetUnderlyingType(type) ?? type;

            return !actualType.IsPrimitive &&
                   actualType != typeof(string) &&
                   actualType != typeof(DateTime) &&
                   actualType != typeof(DateTimeOffset) &&
                   actualType != typeof(TimeSpan) &&
                   actualType != typeof(decimal) &&
                   actualType != typeof(Guid) &&
                   !actualType.IsEnum &&
                   actualType != typeof(object);
        }

        /// <summary>
        /// Gets the display name for a property
        /// </summary>
        private static string GetDisplayName(PropertyInfo prop) {
            var displayAttr = prop.GetCustomAttribute<DisplayNameAttribute>();
            return displayAttr?.DisplayName ?? prop.Name;
        }

        /// <summary>
        /// Gets the category for a property
        /// </summary>
        private static string? GetCategory(PropertyInfo prop) {
            var categoryAttr = prop.GetCustomAttribute<CategoryAttribute>();
            return categoryAttr?.Category;
        }

        /// <summary>
        /// Gets the description for a property with fallback to type description
        /// </summary>
        private static string? GetDescription(PropertyInfo prop) {
            // First: Try property's Description attribute
            var propDescAttr = prop.GetCustomAttribute<DescriptionAttribute>();
            if (!string.IsNullOrEmpty(propDescAttr?.Description))
                return propDescAttr.Description;

            // Second: Try property TYPE's Description attribute (for enums, classes, etc.)
            var typeDescAttr = prop.PropertyType.GetCustomAttribute<DescriptionAttribute>();
            if (!string.IsNullOrEmpty(typeDescAttr?.Description))
                return typeDescAttr.Description;

            // Third: For generic types (like List<T>, ObservableCollection<T>), get T's description
            if (prop.PropertyType.IsGenericType) {
                var genericArg = prop.PropertyType.GetGenericArguments().FirstOrDefault();
                if (genericArg != null) {
                    var genericDescAttr = genericArg.GetCustomAttribute<DescriptionAttribute>();
                    if (!string.IsNullOrEmpty(genericDescAttr?.Description))
                        return genericDescAttr.Description;
                }
            }

            return null;
        }

        /// <summary>
        /// Raises the PropertyProcessingError event
        /// </summary>
        private static void OnPropertyProcessingError(string propertyName, Exception ex) {
            System.Diagnostics.Debug.WriteLine($"Error processing property {propertyName}: {ex.Message}");
            PropertyProcessingError?.Invoke(null, new PropertyGridErrorEventArgs(propertyName, ex));
        }
    }

    /// <summary>
    /// Event arguments for property grid errors
    /// </summary>
    public class PropertyGridErrorEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the name of the property that caused the error
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Gets the exception that occurred
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// Initializes a new instance of PropertyGridErrorEventArgs
        /// </summary>
        public PropertyGridErrorEventArgs(string propertyName, Exception exception) {
            PropertyName = propertyName;
            Exception = exception;
        }
    }
}
