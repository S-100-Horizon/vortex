using S100Framework.DomainModel;
using S100Framework.WPF.ViewModel;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace S100Framework.WPF.Editors
{
    public abstract class ValidatingEditor<T> : ITypeEditor where T : struct
    {
        public virtual FrameworkElement ResolveEditor(PropertyItem propertyItem) {
            throw new NotImplementedException();
        }
    }

    public abstract class ValidatingUnknownEditor<T> : ValidatingEditor<T> where T : struct
    {
    }

    //  https://www.webfx.com/web-design/color-picker/

    public class BrushValidatorConvertor : IValueConverter
    {
        const string ColorCode = "#e9c8ca";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is null)
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString(ColorCode));
            return System.Windows.Media.Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class BrushUnknownConvertor : IValueConverter
    {
        const string ColorCode = "#c8dae9";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is null)
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString(ColorCode));
            return System.Windows.Media.Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }


    public abstract class HorizonEditor : ITypeEditor
    {
        public abstract FrameworkElement ResolveEditor(PropertyItem propertyItem);
    }

    public class HorizonEditor<T> : HorizonEditor where T : class
    {
        public override FrameworkElement ResolveEditor(PropertyItem propertyItem) {
            var attributes = typeof(T).GetProperty(propertyItem.DisplayName)!.GetCustomAttributes(true);

            var supportsUnknown = false;

            if (attributes.Any(attr => attr.GetType() == typeof(UnknownValueAttribute))) {
                supportsUnknown = true;
            }

            var multiplicity = (MultiplicityAttribute?)attributes.SingleOrDefault(attr => attr.GetType() == typeof(MultiplicityAttribute));


            var panel = new Grid {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
            };

            if (supportsUnknown) {
                Binding newBinding = new Binding(propertyItem.DisplayName) {
                    Source = propertyItem.Instance,
                    Mode = BindingMode.OneWay,
                };
                newBinding.Converter = new BrushUnknownConvertor();
                panel.SetBinding(Grid.BackgroundProperty, newBinding);
            }

                Control? editor = default;
            if (propertyItem.PropertyType == typeof(double) || propertyItem.PropertyType == typeof(double?)) {
                var editorDecimalUpDown = new PropertyGridEditorDecimalUpDown {
                    Background = System.Windows.Media.Brushes.Transparent,
                };

                if (supportsUnknown) {
                    var radioButtonUnknown = new RadioButton {
                        ToolTip = "[Unknown]",
                        GroupName = propertyItem.DisplayName,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Center,
                        IsChecked = propertyItem.Value is null,
                        Margin = new Thickness(0, 0, 18, 0),
                    };

                    editorDecimalUpDown.ValueChanged += (sender, e) => {
                        radioButtonUnknown.IsChecked = !editorDecimalUpDown.Value.HasValue;
                    };
                    radioButtonUnknown.Click += (sender, e) => {
                        if (editorDecimalUpDown.Value != default)
                            editorDecimalUpDown.Value = default;
                        else
                            radioButtonUnknown.IsChecked = true;
                    };

                    panel.Children.Add(radioButtonUnknown);
                }
                editor = editorDecimalUpDown;
            }
            else if (propertyItem.PropertyType == typeof(int) || propertyItem.PropertyType == typeof(int?) || propertyItem.PropertyType == typeof(short) || propertyItem.PropertyType == typeof(short?) || propertyItem.PropertyType == typeof(long) || propertyItem.PropertyType == typeof(long?)) {
                var editorIntegerUpDown = new PropertyGridEditorIntegerUpDown {
                    Background = System.Windows.Media.Brushes.Transparent,
                };

                if (supportsUnknown) {
                    var radioButtonUnknown = new RadioButton {
                        ToolTip = "[Unknown]",
                        GroupName = propertyItem.DisplayName,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Center,
                        IsChecked = propertyItem.Value is null,
                        Margin = new Thickness(0, 0, 18, 0),
                    };
                    editorIntegerUpDown.ValueChanged += (sender, e) => {
                        radioButtonUnknown.IsChecked = !editorIntegerUpDown.Value.HasValue;
                    };
                    radioButtonUnknown.Click += (sender, e) => {
                        if (editorIntegerUpDown.Value != default)
                            editorIntegerUpDown.Value = default;
                        else
                            radioButtonUnknown.IsChecked = true;
                    };

                    panel.Children.Add(radioButtonUnknown);
                }
                editor = editorIntegerUpDown;
            }
            else
                throw new NotImplementedException();

            var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = BindingMode.TwoWay };
            BindingOperations.SetBinding(editor, PropertyGridEditorDecimalUpDown.ValueProperty, bindingSelectedItemProperty);
            panel.Children.Add(editor);
     
            return panel;
        }
    }


    public class S100TruncatedDateEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        private static readonly Regex _regexInput = new(@"^(\d|-{1,8})$");

        //public string? Value { get; set; } = default;

        public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem) {
            var control = new WatermarkTextBox {
                Name = $"_textBox{Guid.NewGuid():N}",
                MaxLength = 8,
                KeepWatermarkOnGotFocus = false,
                Watermark = "yyyyMMdd",
            };
            control.PreviewTextInput += this.Control_PreviewTextInput;

            //Value = $"{propertyItem.Value:yyyMMdd}";

            var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
            //BindingOperations.SetBinding(control, CheckComboBox.SelectedItemProperty, bindingSelectedItemProperty);

            //var bindingSelectedItemProperty = new Binding(nameof(Value)) { Source = this, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
            bindingSelectedItemProperty.ValidationRules.Add(new PartialDateRule());
            BindingOperations.SetBinding(control, TextBox.TextProperty, bindingSelectedItemProperty);

            return control;
        }

        private void Control_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e) {
            if (string.IsNullOrEmpty(e.Text)) return;
            e.Handled = !_regexInput.IsMatch(e.Text);
        }
    }

    public class PartialDateRule : ValidationRule
    {
        private static readonly Regex _regexValidation = new(@"^(\d{4}|-{4})(\d{2}|-{2})(\d{2}|-{2})$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
            var s = (value as string) ?? string.Empty;
            return _regexValidation.IsMatch(s) ? ValidationResult.ValidResult
                : new ValidationResult(false, "Must be yyyyMMdd, but yyyy, MM or dd may be all \"-\".");
        }
    }

    public class EnumComboBoxEditor : ComboBoxEditor
    {
        protected override IEnumerable CreateItemsSource(PropertyItem propertyItem) {
            var attribute = (S100Framework.DomainModel.EnumerationAttribute)propertyItem.Instance.GetType().GetProperty(propertyItem.DisplayName)!.GetCustomAttributes(typeof(S100Framework.DomainModel.EnumerationAttribute), true)[0];
            return (IEnumerable)propertyItem.Instance.GetType().GetProperty(attribute.PropertyName)!.GetValue(propertyItem.Instance)!;
        }
    }

    //public class EnumComboBoxEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    //{
    //    public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem) {
    //        //var control = new ComboBox {
    //        //    Name = $"_comboBox{Guid.NewGuid():N}",
    //        //    IsEditable = false,
    //        //    IsDropDownOpen = false,
    //        //    BorderBrush = System.Windows.Media.Brushes.Transparent,
    //        //    Background = System.Windows.Media.Brushes.Transparent,                
    //        //};

    //        var control = new PropertyGridEditorComboBox();

    //        var attribute = (S100Framework.DomainModel.EnumerationAttribute)propertyItem.Instance.GetType().GetProperty(propertyItem.DisplayName)!.GetCustomAttributes(typeof(S100Framework.DomainModel.EnumerationAttribute), true)[0];

    //        var bindingItemsSourceProperty = new Binding(attribute.PropertyName) { Source = propertyItem.Instance, Mode = BindingMode.OneWay };
    //        BindingOperations.SetBinding(control, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

    //        var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
    //        BindingOperations.SetBinding(control, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);

    //        var value = control.SelectedValue;

    //        //if (!string.IsNullOrEmpty(viewModel.RefId)) {
    //        //    checkComboBox.SelectedValue = viewModel.RefId;
    //        //}

    //        return control;
    //    }
    //}

    //public class EnumCollectionEditor : ITypeEditor
    //{
    //    private IList? _collection;
    //    private Type? _enumType;

    //    public FrameworkElement ResolveEditor(PropertyItem propertyItem) {
    //        // Get the underlying collection and enum type
    //        _collection = (IList)propertyItem.Value;
    //        _enumType = GetEnumType(propertyItem.PropertyType);

    //        // Create a stack panel to hold our controls
    //        var stackPanel = new StackPanel { Orientation = Orientation.Vertical };

    //        // Create a combo box for selecting new values
    //        var comboBox = new ComboBox {
    //            ItemsSource = Enum.GetValues(_enumType).Cast<object>(),
    //            Margin = new Thickness(0, 0, 0, 5)
    //        };

    //        // Create a button to add the selected value
    //        var addButton = new Button {
    //            Content = "Add",
    //            Margin = new Thickness(0, 0, 0, 10)
    //        };

    //        // Create a list box to display current values
    //        var listBox = new ListBox();

    //        // Initialize with current values
    //        foreach (var item in _collection) {
    //            listBox.Items.Add(item);
    //        }

    //        // Handle add button click
    //        addButton.Click += (sender, args) => {
    //            if (comboBox.SelectedItem != null) {
    //                _collection.Add(comboBox.SelectedItem);
    //                listBox.Items.Add(comboBox.SelectedItem);
    //            }
    //        };

    //        // Handle item removal
    //        listBox.KeyDown += (sender, args) => {
    //            if (args.Key == System.Windows.Input.Key.Delete && listBox.SelectedItem != null) {
    //                _collection.Remove(listBox.SelectedItem);
    //                listBox.Items.Remove(listBox.SelectedItem);
    //            }
    //        };

    //        // Add controls to the stack panel
    //        stackPanel.Children.Add(comboBox);
    //        stackPanel.Children.Add(addButton);
    //        stackPanel.Children.Add(listBox);

    //        return stackPanel;
    //    }

    //    private Type GetEnumType(Type collectionType) {
    //        // Handle ObservableCollection<T>
    //        if (collectionType.IsGenericType &&
    //            collectionType.GetGenericTypeDefinition() == typeof(ObservableCollection<>)) {
    //            return collectionType.GetGenericArguments()[0];
    //        }

    //        // Handle arrays
    //        if (collectionType.IsArray) {
    //            return collectionType.GetElementType()!;
    //        }

    //        throw new ArgumentException("Unsupported collection type");
    //    }
    //}

    //public sealed class EnumCheckComboEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    //{
    //    public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem) {
    //        var control = new CheckComboBox {
    //            Name = $"_checkComboBox{Guid.NewGuid():N}",
    //            IsEditable = false,
    //            IsSelectAllActive = true,
    //            IsDropDownOpen = false,
    //        };

    //        var attribute = (S100Framework.DomainModel.EnumerationAttribute)propertyItem.Instance.GetType().GetProperty(propertyItem.DisplayName)!.GetCustomAttributes(typeof(S100Framework.DomainModel.EnumerationAttribute), true)[0];

    //        var bindingItemsSourceProperty = new Binding(attribute.PropertyName) { Source = propertyItem.Instance, Mode = BindingMode.OneWay };
    //        BindingOperations.SetBinding(control, CheckComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

    //        var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
    //        BindingOperations.SetBinding(control, CheckComboBox.SelectedItemProperty, bindingSelectedItemProperty);

    //        var value = control.SelectedValue;

    //        //if (!string.IsNullOrEmpty(viewModel.RefId)) {
    //        //    checkComboBox.SelectedValue = viewModel.RefId;
    //        //}

    //        return control;
    //    }
    //}

    //public sealed class CodeListComboEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    //{
    //    public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem) {
    //        var control = new ComboBox {
    //            Name = $"_comboBox{Guid.NewGuid():N}",
    //            DisplayMemberPath = "label",
    //        };

    //        var attribute = (S100Framework.DomainModel.CodeListAttribute)propertyItem.Instance.GetType().GetProperty(propertyItem.DisplayName)!.GetCustomAttributes(typeof(S100Framework.DomainModel.CodeListAttribute), true)[0];

    //        var bindingItemsSourceProperty = new Binding(attribute.PropertyName) { Source = propertyItem.Instance, Mode = BindingMode.OneWay };
    //        BindingOperations.SetBinding(control, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

    //        var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
    //        BindingOperations.SetBinding(control, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);

    //        return control;
    //    }
    //}

    //public sealed class CodeListCheckComboEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    //{
    //    public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem) {
    //        var control = new CheckComboBox {
    //            Name = $"_checkComboBox{Guid.NewGuid():N}",
    //            IsEditable = false,
    //            IsSelectAllActive = true,
    //            IsDropDownOpen = false,
    //            DisplayMemberPath = "label",
    //        };

    //        var attribute = (S100Framework.DomainModel.CodeListAttribute)propertyItem.Instance.GetType().GetProperty(propertyItem.DisplayName)!.GetCustomAttributes(typeof(S100Framework.DomainModel.CodeListAttribute), true)[0];

    //        var bindingItemsSourceProperty = new Binding(attribute.PropertyName) { Source = propertyItem.Instance, Mode = BindingMode.OneWay };
    //        BindingOperations.SetBinding(control, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

    //        var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
    //        BindingOperations.SetBinding(control, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);

    //        return control;
    //    }
    //}

    //public class UnknownStringEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    //{
    //    public FrameworkElement ResolveEditor(PropertyItem propertyItem) {

    //        var instance = (String?)propertyItem.Value;

    //        var panel = new Grid {
    //            HorizontalAlignment = HorizontalAlignment.Stretch,
    //            VerticalAlignment = VerticalAlignment.Center,
    //        };

    //        var radioButtonUnknown = new RadioButton {
    //            ToolTip = "[Unknown]",
    //            GroupName = "Unknown",
    //            IsChecked = string.IsNullOrEmpty(instance),
    //            HorizontalAlignment = HorizontalAlignment.Right,
    //            VerticalAlignment = VerticalAlignment.Center,
    //            Margin = new Thickness(0, 0, 18, 0),
    //        };
    //        radioButtonUnknown.Checked += (s, e) => {
    //            //OnPropertyChanged(nameof(instance));
    //        };

    //        var editor = new PropertyGridEditorTextBox {

    //            Watermark = "[unknown]",
    //        };
    //        editor.SelectionChanged += (s, e) => {
    //            radioButtonUnknown.IsChecked = string.IsNullOrEmpty(editor.Text);
    //        };
    //        radioButtonUnknown.Click += (s, e) => {
    //            editor.Text = null;
    //            radioButtonUnknown.IsChecked = true;
    //        };

    //        var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = BindingMode.TwoWay };
    //        BindingOperations.SetBinding(editor, TextBox.TextProperty, bindingSelectedItemProperty);
    //        panel.Children.Add(editor);

    //        panel.Children.Add(radioButtonUnknown);
    //        return panel;
    //    }
    //}

    //public class UnknownS100TruncatedDateEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    //{
    //    private static readonly Regex _regexInput = new(@"^(\d|-{1,8})$");

    //    //public string? Value { get; set; } = default;

    //    public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem) {
    //        var instance = (String?)propertyItem.Value;

    //        var panel = new Grid {
    //            HorizontalAlignment = HorizontalAlignment.Stretch,
    //            VerticalAlignment = VerticalAlignment.Center,
    //        };

    //        var radioButtonUnknown = new RadioButton {
    //            ToolTip = "[Unknown]",
    //            GroupName = "Unknown",
    //            IsChecked = string.IsNullOrEmpty(instance),
    //            HorizontalAlignment = HorizontalAlignment.Right,
    //            VerticalAlignment = VerticalAlignment.Center,
    //            Margin = new Thickness(0, 0, 18, 0),
    //        };
    //        radioButtonUnknown.Checked += (s, e) => {
    //            //OnPropertyChanged(nameof(instance));
    //        };

    //        var editor = new WatermarkTextBox {
    //            Name = $"_textBox{Guid.NewGuid():N}",
    //            MaxLength = 8,
    //            KeepWatermarkOnGotFocus = false,
    //            Watermark = "yyyyMMdd",
    //        };
    //        editor.PreviewTextInput += this.Control_PreviewTextInput;

    //        editor.SelectionChanged += (s, e) => {
    //            radioButtonUnknown.IsChecked = string.IsNullOrEmpty(editor.Text);
    //        };
    //        radioButtonUnknown.Click += (s, e) => {
    //            editor.Text = null;
    //            radioButtonUnknown.IsChecked = true;
    //        };

    //        var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
    //        //BindingOperations.SetBinding(control, CheckComboBox.SelectedItemProperty, bindingSelectedItemProperty);

    //        //var bindingSelectedItemProperty = new Binding(nameof(Value)) { Source = this, Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay };
    //        bindingSelectedItemProperty.ValidationRules.Add(new PartialDateRule());
    //        BindingOperations.SetBinding(editor, TextBox.TextProperty, bindingSelectedItemProperty);
    //        panel.Children.Add(editor);

    //        panel.Children.Add(radioButtonUnknown);
    //        return panel;
    //    }

    //    private void Control_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e) {
    //        if (string.IsNullOrEmpty(e.Text)) return;
    //        e.Handled = !_regexInput.IsMatch(e.Text);
    //    }
    //}

    //public abstract class UnknownEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    //{
    //    public abstract FrameworkElement ResolveEditor(PropertyItem propertyItem);
    //}

    //public class UnknownBooleanEditor : UnknownEditor
    //{
    //    public override FrameworkElement ResolveEditor(PropertyItem propertyItem) {

    //        var viewModel = propertyItem.Instance as ViewModelBase;

    //        var instance = (bool?)propertyItem.Value;

    //        var panel = new StackPanel {
    //            Orientation = Orientation.Horizontal,
    //            VerticalAlignment = VerticalAlignment.Center,
    //        };

    //        var editor = new PropertyGridEditorCheckBox {
    //        };

    //        editor.IsThreeState = true;

    //        editor.Click += (sender, e) => {
    //            //viewModel![propertyItem.DisplayName] = ((PropertyGridEditorCheckBox)e.Source).IsChecked is null;
    //        };

    //        var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = BindingMode.TwoWay };
    //        BindingOperations.SetBinding(editor, CheckBox.IsCheckedProperty, bindingSelectedItemProperty);

    //        return editor;
    //    }
    //}

    //public class UnknownDoubleEditor : UnknownEditor
    //{
    //    public override FrameworkElement ResolveEditor(PropertyItem propertyItem) {

    //        var viewModel = propertyItem.Instance as ViewModelBase;

    //        var instance = (double?)propertyItem.Value;

    //        var panel = new Grid {
    //            HorizontalAlignment = HorizontalAlignment.Stretch,
    //            VerticalAlignment = VerticalAlignment.Center,
    //        };

    //        var radioButtonUnknown = new RadioButton {
    //            ToolTip = "[Unknown]",
    //            GroupName = propertyItem.DisplayName,
    //            HorizontalAlignment = HorizontalAlignment.Right,
    //            VerticalAlignment = VerticalAlignment.Center,
    //            //IsChecked = instance == null,
    //            IsChecked = instance is null,
    //            Margin = new Thickness(0, 0, 18, 0),
    //        };
    //        radioButtonUnknown.Checked += (sender, e) => {
    //            //OnPropertyChanged(nameof(instance));
    //        };

    //        var editor = new PropertyGridEditorDecimalUpDown {
    //            //Watermark = "[UNKNOWN]",                        
    //        };
    //        editor.ValueChanged += (sender, e) => {
    //            radioButtonUnknown.IsChecked = !editor.Value.HasValue;
    //        };
    //        radioButtonUnknown.Click += (sender, e) => {
    //            if (editor.Value != default)
    //                editor.Value = default;
    //            else
    //                radioButtonUnknown.IsChecked = true;
    //        };
    //        var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = BindingMode.TwoWay };
    //        BindingOperations.SetBinding(editor, PropertyGridEditorDecimalUpDown.ValueProperty, bindingSelectedItemProperty);
    //        panel.Children.Add(editor);

    //        panel.Children.Add(radioButtonUnknown);
    //        return panel;
    //    }
    //}

    //public class UnknownIntegerEditor : UnknownEditor
    //{
    //    public override FrameworkElement ResolveEditor(PropertyItem propertyItem) {

    //        var viewModel = propertyItem.Instance as ViewModelBase;

    //        var instance = (double?)propertyItem.Value;

    //        var panel = new Grid {
    //            HorizontalAlignment = HorizontalAlignment.Stretch,
    //            VerticalAlignment = VerticalAlignment.Center,
    //        };

    //        var radioButtonUnknown = new RadioButton {
    //            ToolTip = "[Unknown]",
    //            GroupName = propertyItem.DisplayName,
    //            HorizontalAlignment = HorizontalAlignment.Right,
    //            VerticalAlignment = VerticalAlignment.Center,
    //            //IsChecked = instance == null,
    //            IsChecked = instance is null,
    //            Margin = new Thickness(0, 0, 18, 0),
    //        };
    //        radioButtonUnknown.Checked += (sender, e) => {
    //            //OnPropertyChanged(nameof(instance));
    //        };

    //        var editor = new PropertyGridEditorDecimalUpDown {
    //            //Watermark = "[UNKNOWN]",                        
    //        };
    //        editor.ValueChanged += (sender, e) => {
    //            radioButtonUnknown.IsChecked = !editor.Value.HasValue;
    //        };
    //        radioButtonUnknown.Click += (sender, e) => {
    //            if (editor.Value != default)
    //                editor.Value = default;
    //            else
    //                radioButtonUnknown.IsChecked = true;
    //        };
    //        var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = BindingMode.TwoWay };
    //        BindingOperations.SetBinding(editor, PropertyGridEditorDecimalUpDown.ValueProperty, bindingSelectedItemProperty);
    //        panel.Children.Add(editor);

    //        panel.Children.Add(radioButtonUnknown);
    //        return panel;
    //    }
    //}

    //public class UnknownUriEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    //{
    //    public FrameworkElement ResolveEditor(PropertyItem propertyItem) {

    //        var instance = (String?)propertyItem.Value;

    //        var panel = new Grid {
    //            HorizontalAlignment = HorizontalAlignment.Stretch,
    //            VerticalAlignment = VerticalAlignment.Center,
    //        };

    //        var radioButtonUnknown = new RadioButton {
    //            ToolTip = "[Unknown]",
    //            GroupName = "Unknown",
    //            IsChecked = string.IsNullOrEmpty(instance),
    //            HorizontalAlignment = HorizontalAlignment.Right,
    //            VerticalAlignment = VerticalAlignment.Center,
    //            Margin = new Thickness(0, 0, 18, 0),
    //        };
    //        radioButtonUnknown.Checked += (s, e) => {
    //            //OnPropertyChanged(nameof(instance));
    //        };

    //        var editor = new PropertyGridEditorTextBox {

    //            Watermark = "[unknown]",
    //        };
    //        editor.SelectionChanged += (s, e) => {
    //            radioButtonUnknown.IsChecked = string.IsNullOrEmpty(editor.Text);
    //        };
    //        radioButtonUnknown.Click += (s, e) => {
    //            editor.Text = null;
    //            radioButtonUnknown.IsChecked = true;
    //        };

    //        var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = BindingMode.TwoWay };
    //        BindingOperations.SetBinding(editor, TextBox.TextProperty, bindingSelectedItemProperty);
    //        panel.Children.Add(editor);

    //        panel.Children.Add(radioButtonUnknown);
    //        return panel;
    //    }
    //}

    //public class UnknownUrnEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    //{
    //    public FrameworkElement ResolveEditor(PropertyItem propertyItem) {

    //        var instance = (String?)propertyItem.Value;

    //        var panel = new Grid {
    //            HorizontalAlignment = HorizontalAlignment.Stretch,
    //            VerticalAlignment = VerticalAlignment.Center,
    //        };

    //        var radioButtonUnknown = new RadioButton {
    //            ToolTip = "[Unknown]",
    //            GroupName = "Unknown",
    //            IsChecked = string.IsNullOrEmpty(instance),
    //            HorizontalAlignment = HorizontalAlignment.Right,
    //            VerticalAlignment = VerticalAlignment.Center,
    //            Margin = new Thickness(0, 0, 18, 0),
    //        };
    //        radioButtonUnknown.Checked += (s, e) => {
    //            //OnPropertyChanged(nameof(instance));
    //        };

    //        var editor = new PropertyGridEditorTextBox {

    //            Watermark = "[unknown]",
    //        };
    //        editor.SelectionChanged += (s, e) => {
    //            radioButtonUnknown.IsChecked = string.IsNullOrEmpty(editor.Text);
    //        };
    //        radioButtonUnknown.Click += (s, e) => {
    //            editor.Text = null;
    //            radioButtonUnknown.IsChecked = true;
    //        };

    //        var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = BindingMode.TwoWay };
    //        BindingOperations.SetBinding(editor, TextBox.TextProperty, bindingSelectedItemProperty);
    //        panel.Children.Add(editor);

    //        panel.Children.Add(radioButtonUnknown);
    //        return panel;
    //    }
    //}

    //public class UnknownUrlEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    //{
    //    public FrameworkElement ResolveEditor(PropertyItem propertyItem) {

    //        var instance = (String?)propertyItem.Value;

    //        var panel = new Grid {
    //            HorizontalAlignment = HorizontalAlignment.Stretch,
    //            VerticalAlignment = VerticalAlignment.Center,
    //        };

    //        var radioButtonUnknown = new RadioButton {
    //            ToolTip = "[Unknown]",
    //            GroupName = "Unknown",
    //            IsChecked = string.IsNullOrEmpty(instance),
    //            HorizontalAlignment = HorizontalAlignment.Right,
    //            VerticalAlignment = VerticalAlignment.Center,
    //            Margin = new Thickness(0, 0, 18, 0),
    //        };
    //        radioButtonUnknown.Checked += (s, e) => {
    //            //OnPropertyChanged(nameof(instance));
    //        };

    //        var editor = new PropertyGridEditorTextBox {

    //            Watermark = "[unknown]",
    //        };
    //        editor.SelectionChanged += (s, e) => {
    //            radioButtonUnknown.IsChecked = string.IsNullOrEmpty(editor.Text);
    //        };
    //        radioButtonUnknown.Click += (s, e) => {
    //            editor.Text = null;
    //            radioButtonUnknown.IsChecked = true;
    //        };

    //        var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = BindingMode.TwoWay };
    //        BindingOperations.SetBinding(editor, TextBox.TextProperty, bindingSelectedItemProperty);
    //        panel.Children.Add(editor);

    //        panel.Children.Add(radioButtonUnknown);
    //        return panel;
    //    }
    //}

    //public class UnknownDateOnlyEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    //{
    //    public FrameworkElement ResolveEditor(PropertyItem propertyItem) {

    //        var instance = (String?)propertyItem.Value;

    //        var panel = new Grid {
    //            HorizontalAlignment = HorizontalAlignment.Stretch,
    //            VerticalAlignment = VerticalAlignment.Center,
    //        };

    //        var radioButtonUnknown = new RadioButton {
    //            ToolTip = "[Unknown]",
    //            GroupName = "Unknown",
    //            IsChecked = string.IsNullOrEmpty(instance),
    //            HorizontalAlignment = HorizontalAlignment.Right,
    //            VerticalAlignment = VerticalAlignment.Center,
    //            Margin = new Thickness(0, 0, 18, 0),
    //        };
    //        radioButtonUnknown.Checked += (s, e) => {
    //            //OnPropertyChanged(nameof(instance));
    //        };

    //        var editor = new PropertyGridEditorTextBox {

    //            Watermark = "[unknown]",
    //        };
    //        editor.SelectionChanged += (s, e) => {
    //            radioButtonUnknown.IsChecked = string.IsNullOrEmpty(editor.Text);
    //        };
    //        radioButtonUnknown.Click += (s, e) => {
    //            editor.Text = null;
    //            radioButtonUnknown.IsChecked = true;
    //        };

    //        var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = BindingMode.TwoWay };
    //        BindingOperations.SetBinding(editor, TextBox.TextProperty, bindingSelectedItemProperty);
    //        panel.Children.Add(editor);

    //        panel.Children.Add(radioButtonUnknown);
    //        return panel;
    //    }
    //}



    //TODO: UnknownCodeListEditor
    public class UnknownCodeListEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        public FrameworkElement ResolveEditor(PropertyItem propertyItem) {

            var instance = (String?)propertyItem.Value;

            var panel = new Grid {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
            };

            var radioButtonUnknown = new RadioButton {
                ToolTip = "[Unknown]",
                GroupName = "Unknown",
                IsChecked = string.IsNullOrEmpty(instance),
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 18, 0),
            };
            radioButtonUnknown.Checked += (s, e) => {
                //OnPropertyChanged(nameof(instance));
            };

            var editor = new PropertyGridEditorTextBox {

                Watermark = "[unknown]",
            };
            editor.SelectionChanged += (s, e) => {
                radioButtonUnknown.IsChecked = string.IsNullOrEmpty(editor.Text);
            };
            radioButtonUnknown.Click += (s, e) => {
                editor.Text = null;
                radioButtonUnknown.IsChecked = true;
            };

            var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = BindingMode.TwoWay };
            BindingOperations.SetBinding(editor, TextBox.TextProperty, bindingSelectedItemProperty);
            panel.Children.Add(editor);

            panel.Children.Add(radioButtonUnknown);
            return panel;
        }
    }

    public static class Extensions
    {
        public static PropertyGrid FindRootPropertyGrid(this PropertyItemBase propertyItem) {
            if (propertyItem.ParentElement is PropertyGrid)
                return (PropertyGrid)propertyItem.ParentElement;
            return ((PropertyItemBase)propertyItem.ParentElement).FindRootPropertyGrid();
        }

        public static T? FindRoot<T>(this PropertyItem propertyItem) where T : class {
            if (propertyItem.Instance is T)
                return (T)propertyItem.Instance;
            if (propertyItem.ParentElement is null)
                return default;
            return ((PropertyItem)propertyItem.ParentElement).FindRoot<T>();
        }

    }
}
