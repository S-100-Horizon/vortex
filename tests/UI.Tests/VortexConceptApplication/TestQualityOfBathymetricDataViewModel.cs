using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.WPF.ViewModel;
using S100Framework.WPF.ViewModel.S101;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace VortexConceptApplication
{
    // Define an enum for the state
    public enum ValueState
    {
        [EnumMember(Value = "<unknown>")]
        Unknown,    // Default state, or explicitly unknown

        [EnumMember(Value = "<value>>")]
        HasValue,   // Contains a valid value (which could be null for reference types)

        [EnumMember(Value = "<null>")]
        IsNull      // Explicitly set to a "null" or "not applicable" state
    }


    public record struct TriState<T> {
        private ValueState _valueState;
        
        public T Value { get; set; }

        private TriState(T value) {
            Value = value;
            _valueState = ValueState.HasValue;
        }

        private TriState(T value, ValueState valueState) {
            Value = value;
            _valueState = valueState;
        }

        public bool HasValue => _valueState == ValueState.HasValue;
        public bool IsNull => _valueState == ValueState.IsNull;
        public bool IsUnknown => _valueState == ValueState.Unknown;



        public static TriState<T> FromValue(T value) => new TriState<T>(value);

        public static TriState<T> Null => new TriState<T>(default!, ValueState.IsNull);

        public static TriState<T> Unknown => default;
    }


    public readonly struct NullableUnknown<T> : IEquatable<NullableUnknown<T>>
    {
        private readonly T _value;
        private readonly ValueState _state = ValueState.IsNull;

        // Private constructor to control instantiation via factory methods
        private NullableUnknown(T value, ValueState state) {
            _value = value;
            _state = state;
        }

        /// <summary>
        /// Creates an instance with a specific value.
        /// If 'value' is null for a reference type, it's still considered 'HasValue'.
        /// </summary>
        public static NullableUnknown<T> FromValue(T value) {
            return new NullableUnknown<T>(value, ValueState.HasValue);
        }

        /// <summary>
        /// Represents an explicitly null/not-present state.
        /// </summary>
        public static NullableUnknown<T> Null => new NullableUnknown<T>(default!, ValueState.IsNull);

        /// <summary>
        /// Represents an unknown state. This is also the default state of the struct.
        /// </summary>
        public static NullableUnknown<T> Unknown => default; // Relies on default struct init

        // --- Properties ---

        public bool HasValue => _state == ValueState.HasValue;
        public bool IsNull => _state == ValueState.IsNull;
        public bool IsUnknown => _state == ValueState.Unknown; // Or _state == default(ValueState)

        /// <summary>
        /// Gets the value if HasValue is true.
        /// Throws InvalidOperationException if HasValue is false.
        /// </summary>
        public T Value {
            get {
                if (!HasValue) {
                    throw new InvalidOperationException("NullableUnknown does not have a value in its current state.");
                }
                return _value;
            }
        }

        /// <summary>
        /// Gets the value if HasValue is true, otherwise returns default(T).
        /// </summary>
        public T GetValueOrDefault() => _value; // Works because _value is default(T) if not HasValue

        /// <summary>
        /// Gets the value if HasValue is true, otherwise returns the specified default value.
        /// </summary>
        public T GetValueOrDefault(T defaultValue) => HasValue ? _value : defaultValue;


        public override bool Equals(object? obj) {
            return obj is NullableUnknown<T> other && Equals(other);
        }

        public bool Equals(NullableUnknown<T> other) {
            if (_state != other._state) {
                return false;
            }
            if (HasValue) // Only compare values if both have values
            {
                return EqualityComparer<T>.Default.Equals(_value, other._value);
            }
            // If not HasValue, states being equal is enough (e.g., Unknown == Unknown)
            return true;
        }

        public override int GetHashCode() {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = _state.GetHashCode();
                if (HasValue && _value != null) // Check _value for null to avoid NullReferenceException on _value.GetHashCode()
                {
                    hashCode = (hashCode * 397) ^ EqualityComparer<T>.Default.GetHashCode(_value);
                }
                return hashCode;
            }
        }

        public static bool operator ==(NullableUnknown<T> left, NullableUnknown<T> right) {
            return left.Equals(right);
        }

        public static bool operator !=(NullableUnknown<T> left, NullableUnknown<T> right) {
            return !left.Equals(right);
        }

        public override string ToString() {
            return _state switch {
                ValueState.HasValue => _value?.ToString() ?? "null (value)", // Differentiate value 'null' from state 'Null'
                ValueState.IsNull => "<null>",
                ValueState.Unknown => "<unknown>",
                _ => "Invalid State" // Should not happen
            };
        }

        // --- Implicit Conversions (Optional but can be convenient) ---

        /// <summary>
        /// Implicitly converts a value of T to NullableUnknown<T> with HasValue state.
        /// </summary>
        public static implicit operator NullableUnknown<T>(T value) => FromValue(value);

        // No implicit conversion from NullableUnknown<T> to T, as it might throw.
        // An explicit conversion could be added:
        // public static explicit operator T(NullableUnknown<T> value) => value.Value;
    }

    public class TestQualityOfBathymetricData : QualityOfBathymetricData
    {
        public NullableUnknown<categoryOfTemporalVariation?> categoryOfTemporalVariationUnknown { get; set; } = NullableUnknown<categoryOfTemporalVariation?>.Null;

    }

    public class NullableUnknownEditor<T> : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor, INotifyPropertyChanged
    {
        private ValueState _state { get; set; }

        private string[] _names = Enum.GetNames<ValueState>();

        private ValueState[] States => [ValueState.Unknown, ValueState.HasValue, ValueState.IsNull];

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public FrameworkElement ResolveEditor(PropertyItem propertyItem) {

            var instance = (NullableUnknown<T>)propertyItem.Value;

            if (instance.IsNull) {
                _state = ValueState.IsNull;
            }
            else if (instance.IsUnknown) {
                _state = ValueState.Unknown;
            }

            var editor = new ComboBox {
                Name = $"_comboBox{Guid.NewGuid():N}",
                ItemsSource = States,
                SelectedItem = _state,
            };

            //editor.SelectedItem = _names[0];

            //var bindingSelectedItemProperty = new Binding(nameof(_state)) { Source = this, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
            //BindingOperations.SetBinding(editor, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);

            return editor;
        }
    }



    public class TriStateEditor<T> : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor, INotifyPropertyChanged
    {
        private ValueState _state { get; set; }

        private string[] _names = Enum.GetNames<ValueState>();

        private ValueState[] States => [ValueState.Unknown, ValueState.HasValue, ValueState.IsNull];

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public FrameworkElement ResolveEditor(PropertyItem propertyItem) {

            var instance = (TriState<T>)propertyItem.Value;

            if (instance.IsNull) {
                _state = ValueState.IsNull;
            }
            else if (instance.IsUnknown) {
                _state = ValueState.Unknown;
            }


            var stackPanel = new StackPanel { Orientation = Orientation.Horizontal };

            // Create a combo box for selecting new values
            var checkBox = new CheckBox {
                IsChecked = _state == ValueState.Unknown,
            };

            var defaultEditor = new PropertyGridEditorComboBox() {                
            };

            var attribute = (S100Framework.DomainModel.EnumerationAttribute)propertyItem.Instance.GetType().GetProperty(propertyItem.DisplayName)!.GetCustomAttributes(typeof(S100Framework.DomainModel.EnumerationAttribute), true)[0];

            var bindingItemsSourceProperty = new Binding(attribute.PropertyName) { Source = propertyItem.Instance, Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(defaultEditor, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

            //var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
            //BindingOperations.SetBinding(instance.Value, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);


            stackPanel.Children.Add(checkBox);
            stackPanel.Children.Add(defaultEditor);

            //return Xceed.Wpf.Toolkit.PropertyGrid.Editors.ComboBoxEditor();

            //editor.SelectedItem = _names[0];

            //var bindingSelectedItemProperty = new Binding(nameof(_state)) { Source = this, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
            //BindingOperations.SetBinding(editor, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);

            return stackPanel;
        }
    }




    public class TestQualityOfBathymetricDataViewModel : QualityOfBathymetricDataViewModel
    {
        private Random _random = new Random();


        private TriState<categoryOfTemporalVariation> _categoryOfTemporalVariationUnknown = TriState<categoryOfTemporalVariation>.Unknown;

        [Category("QualityOfBathymetricData")]
        [Editor(typeof(TriStateEditor<categoryOfTemporalVariation>), typeof(TriStateEditor<categoryOfTemporalVariation>))]
        [S100Framework.DomainModel.EnumerationAttribute(nameof(categoryOfTemporalVariationList), typeof(categoryOfTemporalVariation))]
        public TriState<categoryOfTemporalVariation> categoryOfTemporalVariationUnknown {
            get {
                return _categoryOfTemporalVariationUnknown;
            }
            set {
                SetValue(ref _categoryOfTemporalVariationUnknown, value);
            }
        }

        private String _interoperabilityIdentifier2;

        [Category("QualityOfBathymetricData")]
        public String interoperabilityIdentifier2 {
            get {
                return _interoperabilityIdentifier2;
            }
            set {
                SetValue(ref _interoperabilityIdentifier2, value);
            }
        }



        public override FeatureViewModel<QualityOfBathymetricData> Load(QualityOfBathymetricData instance) {
            return base.Load(instance);
        }

        protected override void Validate() {
            base.Validate();

            //base.AddError("dataAssessment", "dataAssessment is invalid.");
        }

    }
}
