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
    /// Represents a property in the property grid with metadata and editing capabilities.
    /// Implements INotifyDataErrorInfo to proxy validation errors from the source object.
    /// </summary>
    public class PropertyItem : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private object? _value;
        private bool _isExpanded;
        private INotifyDataErrorInfo? _validationSource;
        private string? _validationPropertyName;
        private EventHandler<DataErrorsChangedEventArgs>? _sourceErrorsChangedHandler;

        public string Name { get; set; }
        public string DisplayName { get; set; }
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
        public int CollectionIndex { get; set; } = -1;
        public CollectionPropertyItem? ParentCollectionItem { get; set; }
        public Attribute[] Attributes { get; set; } = Array.Empty<Attribute>();

        public PropertyItem() {
            Name = string.Empty;
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
                    OnPropertyChanged(nameof(Value));

                    // Update the actual property on the parent object
                    if (ParentObject != null && PropertyInfo != null && PropertyInfo.CanWrite && !IsReadOnly) {
                        try {
                            object? convertedValue = ConvertValue(value, PropertyType);
                            PropertyInfo.SetValue(ParentObject, convertedValue);
                        }
                        catch (Exception ex) {
                            System.Diagnostics.Debug.WriteLine($"Error setting property {Name}: {ex.Message}");
                        }
                    }

                    // After setting value, check for validation errors
                    OnPropertyChanged(nameof(HasErrors));
                    OnPropertyChanged(nameof(ErrorMessage));
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

        #region INotifyDataErrorInfo Implementation

        /// <summary>
        /// Gets a value indicating whether this property has validation errors
        /// </summary>
        public bool HasErrors => GetErrorsCore().Any();

        /// <summary>
        /// Gets the first error message for display, or null if no errors
        /// </summary>
        public string? ErrorMessage => HasErrors
            ? string.Join(Environment.NewLine, GetErrorsCore().Select(e => e?.ToString() ?? string.Empty))
            : null;

        /// <summary>
        /// Occurs when the validation errors have changed
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        /// <summary>
        /// Gets the validation errors for this property
        /// </summary>
        public IEnumerable GetErrors(string? propertyName) {
            // We only return errors for our own property (or when propertyName is null/empty)
            if (string.IsNullOrEmpty(propertyName) || propertyName == nameof(Value)) {
                return GetErrorsCore();
            }
            return Enumerable.Empty<object>();
        }

        /// <summary>
        /// Core method to retrieve validation errors from the source object
        /// </summary>
        private IEnumerable<object> GetErrorsCore() {
            var propName = _validationPropertyName ?? Name;

            // First check INotifyDataErrorInfo
            if (_validationSource != null) {
                var errors = _validationSource.GetErrors(propName);
                if (errors != null) {
                    foreach (var error in errors) {
                        if (error != null) yield return error;
                    }
                }
                yield break;
            }

            // Fallback to IDataErrorInfo
            if (ParentObject is IDataErrorInfo dataErrorInfo) {
                var error = dataErrorInfo[propName];
                if (!string.IsNullOrEmpty(error)) {
                    yield return error;
                }
            }
        }

        /// <summary>
        /// Sets up validation by subscribing to the source object's ErrorsChanged event
        /// </summary>
        /// <param name="sourceObject">The object that implements validation</param>
        /// <param name="propertyName">The property name to track errors for</param>
        internal void SetupValidation(object sourceObject, string propertyName) {
            // Clean up any existing subscription
            DetachValidation();

            _validationPropertyName = propertyName;

            if (sourceObject is INotifyDataErrorInfo notifyDataErrorInfo) {
                _validationSource = notifyDataErrorInfo;

                // Create and store the handler so we can unsubscribe later
                _sourceErrorsChangedHandler = (sender, e) => {
                    // Only propagate if it's for our property or for all properties
                    if (string.IsNullOrEmpty(e.PropertyName) || e.PropertyName == propertyName) {
                        OnPropertyChanged(nameof(HasErrors));
                        OnPropertyChanged(nameof(ErrorMessage));
                        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Value)));
                    }
                };

                notifyDataErrorInfo.ErrorsChanged += _sourceErrorsChangedHandler;

                // Check for initial errors
                if (notifyDataErrorInfo.HasErrors) {
                    OnPropertyChanged(nameof(HasErrors));
                    OnPropertyChanged(nameof(ErrorMessage));
                }
            }
        }

        /// <summary>
        /// Detaches validation by unsubscribing from events
        /// </summary>
        internal void DetachValidation() {
            if (_validationSource != null && _sourceErrorsChangedHandler != null) {
                _validationSource.ErrorsChanged -= _sourceErrorsChangedHandler;
            }
            _validationSource = null;
            _sourceErrorsChangedHandler = null;
            _validationPropertyName = null;
        }

        /// <summary>
        /// Raises the ErrorsChanged event
        /// </summary>
        protected void OnErrorsChanged(string propertyName) {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        #endregion

        private object? ConvertValue(object? value, Type targetType) {
            if (value == null) return null;
            if (targetType.IsAssignableFrom(value.GetType())) return value;

            try {
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

        protected internal virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
