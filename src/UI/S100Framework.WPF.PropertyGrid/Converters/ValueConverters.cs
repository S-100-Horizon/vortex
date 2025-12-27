using S100Framework.DomainModel;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace S100Framework.WPF.Converters
{
    public static class Nullable
    {
        public static Type GetUnderlyingType(Type type) {
            var underlyingType = System.Nullable.GetUnderlyingType(type);
            if (underlyingType == null)
                return type;
            return underlyingType;
        }
    }

    /// <summary>
    /// Converts indentation level to margin for hierarchical display
    /// </summary>
    public class LevelToIndentConverter : IValueConverter
    {
        public double IndentSize { get; set; } = 20;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is int level) {
                return new Thickness(level * IndentSize, 0, 0, 0);
            }
            return new Thickness(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Converts boolean to visibility
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        public bool Inverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            bool boolValue = value is bool b && b;
            if (Inverted) boolValue = !boolValue;
            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Converts nullable object to IsEnable
    /// </summary>
    public class NullToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is String text) return !string.IsNullOrEmpty(text);
            return !(value is null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Converts type to a friendly display name
    /// </summary>
    public class TypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is Type type) {
                return GetFriendlyTypeName(type);
            }
            return value?.ToString() ?? string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a friendly display name for a type, handling generics
        /// </summary>
        /// <param name="type">The type to get a friendly name for</param>
        /// <returns>A human-readable type name</returns>
        private string GetFriendlyTypeName(Type type) {
            if (type.IsGenericType) {
                string genericTypeName = type.GetGenericTypeDefinition().Name;
                genericTypeName = genericTypeName.Substring(0, genericTypeName.IndexOf('`'));
                string genericArgs = string.Join(", ", Array.ConvertAll(type.GetGenericArguments(), t => GetFriendlyTypeName(t)));
                return $"{genericTypeName}<{genericArgs}>";
            }

            return type.Name;
        }
    }

    /// <summary>
    /// Converts an enum type to its possible values
    /// </summary>
    public class EnumValuesConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var propertyItem = value as Models.PropertyItem;
            if (propertyItem is not null) {
                var permittedValues = propertyItem.Attributes.SingleOrDefault(e => e.GetType().Equals(typeof(PermittedValuesAttribute))) as PermittedValuesAttribute;
                if (permittedValues is not null) {
                    var underlyingType = Nullable.GetUnderlyingType(propertyItem.PropertyType);
                    return permittedValues.Values.Select(e => Enum.ToObject(underlyingType, e));                    
                }
            }

            if (value is Type type && type.IsEnum) {
                return Enum.GetValues(type);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Inverts a boolean value
    /// </summary>
    public class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is bool boolValue) {
                return !boolValue;
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is bool boolValue) {
                return !boolValue;
            }
            return true;
        }
    }

    /// <summary>
    /// Shows visibility for collection items (names like [0], [1], etc.)
    /// </summary>
    public class CollectionItemVisibilityConverter : IValueConverter
    {
        private const string CollectionItemPrefix = "[";
        private const string CollectionItemSuffix = "]";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is string name &&
                name.StartsWith(CollectionItemPrefix) &&
                name.EndsWith(CollectionItemSuffix)) {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Converts all properties of an informationBinding
    /// </summary>
    public class InformationBindingConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var propertyItem = value as Models.PropertyItem;
            if (propertyItem is not null) {
                var informationBindings = propertyItem.Attributes.Where(e => e.GetType().Equals(typeof(InformationBindingAttribute))).Cast<InformationBindingAttribute>();

                var parentObejct = (S100Framework.WPF.ViewModel.InformationRefViewModel)propertyItem.ParentObject!;

                if (propertyItem.Name.Equals(nameof(informationBinding.role))) {
                    if (targetType.Equals(typeof(Boolean))) return true;
                    return informationBindings?.Select(e => e.role);
                }
                if (propertyItem.Name.Equals(nameof(informationBinding.informationType))) {

                    if (targetType.Equals(typeof(Boolean))) {
                        var isReadOnly = !string.IsNullOrEmpty(parentObejct.role);

                        parentObejct.PropertyChanged += (s, e) => {
                            var instance = (S100Framework.WPF.ViewModel.InformationRefViewModel)s!;
                            isReadOnly = !string.IsNullOrEmpty(instance.role);
                        };
                        return isReadOnly;
                    }
                    else {
                        var observableCollection = new ObservableCollection<string>();
                        if (!string.IsNullOrEmpty(parentObejct.role)) {
                            foreach (var item in informationBindings?.Single(e => e.role.Equals(parentObejct.role)).informationTypes!)
                                observableCollection.Add(item);
                        }

                        parentObejct.PropertyChanged += (s, e) => {
                            observableCollection.Clear();
                            var instance = (S100Framework.WPF.ViewModel.InformationRefViewModel)s!;
                            foreach (var item in informationBindings?.Single(e => e.role.Equals(instance.role)).informationTypes!)
                                observableCollection.Add(item);
                        };
                        return observableCollection;
                    }
                }
                if (propertyItem.Name.Equals(nameof(informationBinding.referenceId))) {

                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }



    /// <summary>
    /// Converts all properties of a featureBinding
    /// </summary>
    public class FeatureBindingConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var propertyItem = value as Models.PropertyItem;
            if (propertyItem is not null) {
                var featureBindings = propertyItem.Attributes.Where(e => e.GetType().Equals(typeof(FeatureBindingAttribute))).Cast<FeatureBindingAttribute>();

                var parentObejct = (S100Framework.WPF.ViewModel.FeatureRefViewModel)propertyItem.ParentObject!;

                if (propertyItem.Name.Equals(nameof(featureBinding.role))) {
                    return featureBindings?.Select(e => e.role);
                }
                if (propertyItem.Name.Equals(nameof(featureBinding.featureType))) {
                    var observableCollection = new ObservableCollection<string>();
                    if (!string.IsNullOrEmpty(parentObejct.role)) {
                        foreach (var item in featureBindings?.Single(e => e.role.Equals(parentObejct.role)).featureTypes!)
                            observableCollection.Add(item);
                    }

                    parentObejct.PropertyChanged += (s, e) => {
                        observableCollection.Clear();
                        var instance = (S100Framework.WPF.ViewModel.FeatureRefViewModel)s!;
                        foreach (var item in featureBindings?.Single(e => e.role.Equals(instance.role)).featureTypes!)
                            observableCollection.Add(item);
                    };

                    return observableCollection;
                }
                if (propertyItem.Name.Equals(nameof(featureBinding.referenceId))) {

                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
