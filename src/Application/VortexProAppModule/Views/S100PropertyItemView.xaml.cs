using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using VortexProAppModule.S100PropertyGrid;

namespace VortexProAppModule.Views
{
    //public class Test {
    //    public string DisplayName { get; set; }
    //}

    //public abstract class Property
    //{
    //    public string DisplayName { get; set; }

    //    public Type Type { get; set; }

    //    public object Value { get; set; }
    //}

    //public class PropertyItem : Property
    //{
    //}

    //public class PropertyComplexItem : Property
    //{
    //    public List<Property> Properties { get; set; } = new List<Property>();
    //}

    public partial class S100PropertyItemView
    {
        //public static object MockDataSourceTest => new Test {
        //    DisplayName = "depthRangeMinimumValue",
        //};

        public static object MockDataSourceSimple => new PropertyItem {
            DisplayName = "depthRangeMinimumValue",
            PropertyType = typeof(decimal),
            Value = 10.2,
        };

        public static object MockDataSourceArray => new PropertyItemArray {
            DisplayName = "depthArray",
            Items = new List<PropertyItemBase> {
                new PropertyItemComplex {
                    DisplayName="Im complex",
                    Properties = new List<PropertyItemBase>() {
                        new PropertyItem {
                            DisplayName = "depthRangeMinimumValue",
                            PropertyType = typeof(decimal),
                            Value = 10.2,
                        },
                    }
                },
                new PropertyItem {
                    DisplayName = "depthRangeMinimumValue",
                    PropertyType = typeof(decimal),
                    Value = 10.2,
                },
                new PropertyItem {
                    DisplayName = "depthRangeMinimumValue",
                    PropertyType = typeof(decimal),
                    Value = 10.2,
                },
            }
        };

        public static object MockDataSource => new PropertyItemComplex {
            DisplayName = "DepthArea",
            Properties = new List<PropertyItemBase>() {
                new PropertyItem {
                    DisplayName = "depthRangeMinimumValue",
                    PropertyType = typeof(decimal),
                    Value = 10.2,
                },
                new PropertyItem {
                    DisplayName = "depthRangeMaximumValue",
                    PropertyType = typeof(decimal),
                    Value = 28.4
                },
            },
        };

        //
        // Summary:
        //     Occurs when a property value changes.
        public event PropertyChangedEventHandler PropertyChanged;

        public S100PropertyItemView() {
            InitializeComponent();
        }

        private object _selectedProperty;

        public object SelectedProperty {
            get { return _selectedProperty; }
            set { SetProperty(ref _selectedProperty, value); }
        }

        #region PropertyChangedBase

        //
        // Summary:
        //     Sets a property value and calls NotifyPropertyChanged when the new value differs
        //     from the current value.
        //
        // Returns:
        //     Returns true if the property changes.
        protected bool SetProperty<T>(ref T backingField, T value, Expression<Func<T>> property) {
            bool num = !EqualityComparer<T>.Default.Equals(backingField, value);
            if (num) {
                backingField = value;
                NotifyPropertyChanged(getName(property));
            }

            return num;
        }

        //
        // Summary:
        //     Sets a property value and calls NotifyPropertyChanged when the new value differs
        //     from the current value.
        //
        // Returns:
        //     Returns true if the property changes.
        protected bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string name = "") {
            bool num = !EqualityComparer<T>.Default.Equals(backingField, value);
            if (num) {
                backingField = value;
                NotifyPropertyChanged(name);
            }

            return num;
        }

        //
        // Summary:
        //     Raises the PropertyChanged event for the specified property.
        protected virtual void NotifyPropertyChanged<T>(Expression<Func<T>> property) {
            NotifyPropertyChanged(getName(property));
        }

        //
        // Summary:
        //     Raises the PropertyChanged event for the specified property.
        protected virtual void NotifyPropertyChanged([CallerMemberName] string name = "") {
            NotifyPropertyChanged(new PropertyChangedEventArgs(name));
        }

        //
        // Summary:
        //     Raises the PropertyChanged event for the specified property.
        protected virtual void NotifyPropertyChanged(PropertyChangedEventArgs args) {
            this.PropertyChanged?.Invoke(this, args);
        }

        private static string getName<T>(Expression<Func<T>> property) {
            MemberExpression memberExpression = ((!(property.Body is UnaryExpression)) ? ((MemberExpression)property.Body) : ((MemberExpression)((UnaryExpression)property.Body).Operand));
            return memberExpression.Member.Name;
        }

        #endregion
    }
}
