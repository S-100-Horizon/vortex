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
                
                // Add the new child item directly instead of full rebuild
                int newIndex = Collection.Count - 1;
                var childItem = CreateChildPropertyItem(newItem, newIndex);
                Children.Add(childItem);
                
                OnPropertyChanged(nameof(Value));
                OnPropertyChanged(nameof(HasChildren));
                OnPropertyChanged(nameof(CanAddItems));
                OnPropertyChanged(nameof(CanRemoveItems));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error adding item: {ex.Message}");
            }
        }

        /// <summary>
        /// Removes a child item by its current index in the Children collection.
        /// The caller must provide the PropertyItem to remove.
        /// </summary>
        public bool RemoveChildItem(PropertyItem childToRemove)
        {
            if (!CanRemoveItems || Collection == null) return false;

            try
            {
                // Find the current index of this child in our Children collection
                int childIndex = Children.IndexOf(childToRemove);
                
                if (childIndex < 0 || childIndex >= Collection.Count)
                {
                    System.Diagnostics.Debug.WriteLine($"Child not found or index out of range: {childIndex}");
                    return false;
                }

                System.Diagnostics.Debug.WriteLine($"Removing item at index {childIndex}. Collection count before: {Collection.Count}");

                // Remove from the actual collection first
                Collection.RemoveAt(childIndex);
                
                // Remove from Children
                Children.RemoveAt(childIndex);
                
                // Update indices for all remaining children after the removed item
                for (int i = childIndex; i < Children.Count; i++)
                {
                    Children[i].Name = $"[{i}]";
                    Children[i].DisplayName = $"[{i}]";
                    Children[i].CollectionIndex = i;
                }

                System.Diagnostics.Debug.WriteLine($"Item removed. Collection count after: {Collection.Count}, Children count: {Children.Count}");

                OnPropertyChanged(nameof(Value));
                OnPropertyChanged(nameof(HasChildren));
                OnPropertyChanged(nameof(CanAddItems));
                OnPropertyChanged(nameof(CanRemoveItems));
                
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error removing item: {ex.Message}");
                return false;
            }
        }
/*
        /// <summary>
        /// Full rebuild of children from the collection. Use sparingly.
        /// </summary>
        public void RefreshChildren()
        {
            if (Collection == null)
            {
                Children.Clear();
                OnPropertyChanged(nameof(HasChildren));
                OnPropertyChanged(nameof(CanAddItems));
                OnPropertyChanged(nameof(CanRemoveItems));
                return;
            }

            Children.Clear();
            
            int index = 0;
            foreach (var item in Collection)
            {
                var childItem = CreateChildPropertyItem(item, index);
                Children.Add(childItem);
                index++;
            }
            
            OnPropertyChanged(nameof(HasChildren));
            OnPropertyChanged(nameof(CanAddItems));
            OnPropertyChanged(nameof(CanRemoveItems));
        }
*/

        /// <summary>
        /// Creates a PropertyItem for a collection element
        /// </summary>
        private PropertyItem CreateChildPropertyItem(object? item, int index)
        {
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
                ParentCollectionItem = this,
                Attributes = this.Attributes,
            };

            // If the item is a complex type, expand its properties
            if (item != null && IsComplexTypeInternal(item.GetType()))
            {
                childItem.IsComplexType = true;
                var childProperties = PropertyGridBuilder.GetProperties(item, Level + 2);
                foreach (var childProp in childProperties)
                {
                    childProp.ParentCollectionItem = this;
                    childProp.Attributes = [.. childProp.Attributes, .. this.Attributes];
                    childItem.Children.Add(childProp);
                }
            }

            return childItem;
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
}
