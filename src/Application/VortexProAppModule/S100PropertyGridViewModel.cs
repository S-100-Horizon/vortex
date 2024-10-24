using S100Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace VortexProAppModule.S100PropertyGrid
{
    public abstract class PropertyItemBase
    {
        public string DisplayName { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsNullable => PropertyType.IsGenericType && Nullable.GetUnderlyingType(PropertyType) != null;
        public bool HasValue => Value != null;
        public string Category { get; set; }
        public Type PropertyType { get; set; }

        public object Value { get; set; }
    }

    public class PropertyItem : PropertyItemBase
    {
    }

    public class PropertyItemArray : PropertyItemBase
    {
        public List<PropertyItemBase> Items { get; set; } = new List<PropertyItemBase>();
    }

    public class PropertyItemComplex : PropertyItemBase
    {
        public List<PropertyItemBase> Properties { get; set; } = new List<PropertyItemBase>();
    }

    public class S100PropertyGridViewModel : INotifyPropertyChanged
    {
        private object _selectedProperty;

        private string _displayName;

        public S100PropertyGridViewModel() {
        }

        public void Load(object instance) {
            DisplayName = instance.GetType().Name;
            Logger.Current.Verbose("DisplanName: {DisplayName}", DisplayName);

            var properties = PropertyCollection.GetPropertyItemCollection(instance);

            this.Properties.Clear();

            foreach (PropertyDescriptor p in properties) {
                var property = Build(instance, p);
                Logger.Current.Verbose("Property: {DisplayName}, {IsReadOnly}, {IsNullable}, {Value}", property.DisplayName, property.IsReadOnly, property.IsNullable, property.Value);
                this.Properties.Add(property);
            }
        }
        private PropertyItemBase Build(object instance, PropertyDescriptor property) {
            if (property.PropertyType.IsValueType || typeof(String) == property.PropertyType) {
                //if (property.ComponentType.IsArray || property.ComponentType.GetGenericTypeDefinition() == typeof(List<>)) {
                //    var p = new PropertyItemArray {
                //        DisplayName = property.DisplayName,
                //        Category = property.Category,
                //        IsReadOnly = property.IsReadOnly,
                //        PropertyType = property.ComponentType,
                //        Value = property.GetValue(instance),
                //    };
                //    if (p.Value == null)
                //        p.Value = Activator.CreateInstance(property.ComponentType);
                //    return p;
                //}
                return new PropertyItem {
                    DisplayName = property.DisplayName,
                    Category = property.Category,
                    IsReadOnly = property.IsReadOnly,
                    PropertyType = property.PropertyType,
                    Value = property.GetValue(instance),
                };
            }
            //else if (property.PropertyType.IsCollectible || property.PropertyType.IsArray) {
            else if (property.PropertyType.IsArray) {
                var p = new PropertyItemArray {
                    DisplayName = property.DisplayName,
                    Category = property.Category,
                    IsReadOnly = property.IsReadOnly,
                    PropertyType = property.PropertyType,
                    Value = property.GetValue(instance),
                };
                if (p.Value == null)
                    p.Value = Activator.CreateInstance(property.PropertyType);
                return p;
            }
            else if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>)) {
                var p = new PropertyItemArray {
                    DisplayName = property.DisplayName,
                    Category = property.Category,
                    IsReadOnly = property.IsReadOnly,
                    PropertyType = property.PropertyType,
                    Value = property.GetValue(instance),
                };
                if (p.Value == null)
                    p.Value = Activator.CreateInstance(property.PropertyType);
                else {
                    var items = (p.Value as IEnumerable<object>).Cast<object>().ToList();
                    foreach (var v in items) {
                        foreach (PropertyDescriptor sub in PropertyCollection.GetPropertyItemCollection(v)) {
                            var subproperty = Build(v, sub);
                            //Logger.Current.Verbose("Property: {DisplayName}, {IsReadOnly}, {IsNullable}, {Value}", property.DisplayName, property.IsReadOnly, property.IsNullable, property.Value);
                            p.Items.Add(subproperty);
                        }
                    }
                }
                return p;
            }
            else {
                var root = new PropertyItemComplex {
                    DisplayName = property.DisplayName,
                    Category = property.Category,
                    IsReadOnly = property.IsReadOnly,
                    PropertyType = property.PropertyType,
                    Value = property.GetValue(instance),
                };

                //if (property.Attributes.Contains(new System.Runtime.CompilerServices.RequiredMemberAttribute()) && root.Value==null) {
                if (!root.IsNullable) {
                    var test1 = root.PropertyType.IsGenericType;                        //  true
                    var test2 = Nullable.GetUnderlyingType(root.PropertyType) != null;  //  false

                    if (root.Value != null)
                        root.Value = Activator.CreateInstance(property.PropertyType);

                    var properties = property.GetChildProperties();

                    foreach (PropertyDescriptor item in properties) {
                        var subproperty = this.Build(root.Value, item);
                        Logger.Current.Verbose("Property: {DisplayName}, {IsReadOnly}, {IsNullable}, {Value}", subproperty.DisplayName, subproperty.IsReadOnly, subproperty.IsNullable, subproperty.Value);
                        root.Properties.Add(subproperty);
                    }
                }
                return root;
            }
        }

        public ObservableCollection<PropertyItemBase> Properties { get; set; } = new ObservableCollection<PropertyItemBase>();

        public string DisplayName {
            get => _displayName;
            set => SetProperty(ref _displayName, value);
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T backingField, T value, Expression<Func<T>> property) {
            bool num = !EqualityComparer<T>.Default.Equals(backingField, value);
            if (num) {
                backingField = value;
                NotifyPropertyChanged(getName(property));
            }

            return num;
        }
        protected bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string name = "") {
            bool num = !EqualityComparer<T>.Default.Equals(backingField, value);
            if (num) {
                backingField = value;
                NotifyPropertyChanged(name);
            }

            return num;
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string name = "") {
            NotifyPropertyChanged(new PropertyChangedEventArgs(name));
        }

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
