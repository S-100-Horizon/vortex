using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace S100Framework.WPF.Converters
{
    /// <summary>
    /// Converts indentation level to margin for hierarchical display
    /// </summary>
    public class LevelToIndentConverter : IValueConverter
    {
        public double IndentSize { get; set; } = 20;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int level)
            {
                return new Thickness(level * IndentSize, 0, 0, 0);
            }
            return new Thickness(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Converts boolean to visibility
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        public bool Inverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = value is bool b && b;
            if (Inverted) boolValue = !boolValue;
            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Converts type to a friendly display name
    /// </summary>
    public class TypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Type type)
            {
                return GetFriendlyTypeName(type);
            }
            return value?.ToString() ?? string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a friendly display name for a type, handling generics
        /// </summary>
        /// <param name="type">The type to get a friendly name for</param>
        /// <returns>A human-readable type name</returns>
        private string GetFriendlyTypeName(Type type)
        {
            if (type.IsGenericType)
            {
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
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Type type && type.IsEnum)
            {
                return Enum.GetValues(type);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Inverts a boolean value
    /// </summary>
    public class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return !boolValue;
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
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

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string name && 
                name.StartsWith(CollectionItemPrefix) && 
                name.EndsWith(CollectionItemSuffix))
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
