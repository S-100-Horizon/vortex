using S100Framework.DomainModel;
using S100Framework.WPF.ViewModel;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;
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
        const string ColorCode = "#d4000d";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {           
            if (value is null)
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString(ColorCode));
            if (value is string text) {
                if (string.IsNullOrEmpty(text))
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString(ColorCode));
            }
            return System.Windows.Media.Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class BrushUnknownConvertor : IValueConverter
    {
        const string ColorCode = "#0280e8";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is null)
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString(ColorCode));
            return System.Windows.Media.Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class DependentUnknownValueConvertor(string propertyName, string dependentPropertyName) : IValueConverter
    {
        const string ColorCode = "#d4000d";

        public string PropertyName { get; } = propertyName;

        public string DependentPropertyName { get; } = dependentPropertyName;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is null)
                return System.Windows.Media.Brushes.Transparent;

            var propertyValue = value.GetType().GetProperty(PropertyName)!.GetValue(value);

            var dependentValue = value.GetType().GetProperty(DependentPropertyName)!.GetValue(value);

            if (propertyValue is null && dependentValue is null)
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString(ColorCode));
            return System.Windows.Media.Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }



    public class RadioButtonAdorner : Adorner
    {
        private RadioButton _radioButton;

        public RadioButtonAdorner(UIElement adornedElement) : base(adornedElement) {
            _radioButton = new RadioButton();
            _radioButton.VerticalAlignment = VerticalAlignment.Center;
            _radioButton.HorizontalAlignment = HorizontalAlignment.Left;
            _radioButton.Margin = new Thickness(4, 0, 0, 0);

            AddVisualChild(_radioButton);
        }

        protected override int VisualChildrenCount => 1;

        protected override Visual GetVisualChild(int index) => _radioButton;

        protected override Size ArrangeOverride(Size finalSize) {
            _radioButton.Arrange(new Rect(new Point(0, 0), finalSize));
            return finalSize;
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

            var border = new Border {
                BorderBrush = System.Windows.Media.Brushes.Transparent,
                BorderThickness = new Thickness(1),
            };

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
                border.SetBinding(Border.BorderBrushProperty, newBinding);
            }

            var dependentUnknownValue = (DependentUnknownValueAttribute?)attributes.SingleOrDefault(attr => attr.GetType() == typeof(DependentUnknownValueAttribute));
            if (dependentUnknownValue is not null) {
                var propertyName = dependentUnknownValue.PropertyName;

                Binding newBinding = new Binding() {
                    Source = propertyItem.Instance,
                    Mode = BindingMode.OneWay,
                    //BindingGroupName
                };
                newBinding.Converter = new DependentUnknownValueConvertor(propertyItem.DisplayName, propertyName);
                border.SetBinding(Border.BorderBrushProperty, newBinding);
            }

            Control? editor = default;

            if (propertyItem.PropertyType == typeof(string) || (propertyItem.PropertyType.IsGenericType && propertyItem.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) && propertyItem.PropertyType.GenericTypeArguments[0] == typeof(string))) {
                var editorTextBox = new PropertyGridEditorTextBox {
                    Background = System.Windows.Media.Brushes.Transparent,
                };

                var stringLengthConstraint = (StringLengthConstraintAttribute?)attributes.SingleOrDefault(attr => attr.GetType() == typeof(StringLengthConstraintAttribute));
                if (stringLengthConstraint != default) {
                    editorTextBox.MaxLength = stringLengthConstraint.StringLength;
                }

                if (supportsUnknown) {
                    editorTextBox.Watermark = "[UNKNOWN]";

                    //var layer = AdornerLayer.GetAdornerLayer(editorTextBox);

                    //layer.Add(new RadioButtonAdorner(editorTextBox));

                    var radioButtonUnknown = new RadioButton {
                        ToolTip = "[Unknown]",
                        GroupName = propertyItem.DisplayName,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Center,
                        IsChecked = propertyItem.Value is null,
                        Margin = new Thickness(0, 0, 18, 0),
                        IsTabStop = false,
                    };
                    editorTextBox.TextChanged += (sender, e) => {
                        radioButtonUnknown.IsChecked = string.IsNullOrEmpty(editorTextBox.Text);
                    };
                    radioButtonUnknown.Click += (sender, e) => {
                        if (editorTextBox.Text != default)
                            editorTextBox.Text = default;
                        else
                            radioButtonUnknown.IsChecked = true;
                    };

                    panel.Children.Add(radioButtonUnknown);
                }
                editor = editorTextBox;

                var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = BindingMode.TwoWay };
                BindingOperations.SetBinding(editor, PropertyGridEditorTextBox.TextProperty, bindingSelectedItemProperty);
            }
            else if (propertyItem.PropertyType == typeof(double) || propertyItem.PropertyType == typeof(double?)) {
                var editorDecimalUpDown = new PropertyGridEditorDecimalUpDown {
                    Background = System.Windows.Media.Brushes.Transparent,
                    ShowButtonSpinner = false,
                };

                var rangeConstraint = (RangeConstraintAttribute<double>?)attributes.SingleOrDefault(attr => attr.GetType() == typeof(RangeConstraintAttribute<double>));
                if (rangeConstraint != default) {
                    editorDecimalUpDown.Minimum = (decimal)rangeConstraint!.LowerBound;
                    editorDecimalUpDown.Maximum = (decimal)rangeConstraint!.UpperBound;
                    editorDecimalUpDown.ClipValueToMinMax = true;
                }

                if (supportsUnknown) {
                    editorDecimalUpDown.Watermark = "[UNKNOWN]";

                    var radioButtonUnknown = new RadioButton {
                        ToolTip = "[Unknown]",
                        GroupName = propertyItem.DisplayName,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Center,
                        IsChecked = propertyItem.Value is null,
                        Margin = new Thickness(0, 0, 18, 0),
                        IsTabStop = false,
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

                var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = BindingMode.TwoWay };
                BindingOperations.SetBinding(editor, PropertyGridEditorDecimalUpDown.ValueProperty, bindingSelectedItemProperty);
            }
            else if (propertyItem.PropertyType == typeof(int) || propertyItem.PropertyType == typeof(int?) || propertyItem.PropertyType == typeof(short) || propertyItem.PropertyType == typeof(short?) || propertyItem.PropertyType == typeof(long) || propertyItem.PropertyType == typeof(long?)) {
                var editorIntegerUpDown = new PropertyGridEditorIntegerUpDown {
                    Background = System.Windows.Media.Brushes.Transparent,
                    ShowButtonSpinner = false,
                };

                var rangeConstraint = (RangeConstraintAttribute<int>?)attributes.SingleOrDefault(attr => attr.GetType() == typeof(RangeConstraintAttribute<int>));
                if (rangeConstraint != default) {
                    editorIntegerUpDown.Minimum = (int)rangeConstraint!.LowerBound;
                    editorIntegerUpDown.Maximum = (int)rangeConstraint!.UpperBound;
                    editorIntegerUpDown.ClipValueToMinMax = true;
                }

                if (supportsUnknown) {
                    editorIntegerUpDown.Watermark = "[UNKNOWN]";

                    var radioButtonUnknown = new RadioButton {
                        ToolTip = "[Unknown]",
                        GroupName = propertyItem.DisplayName,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Center,
                        IsChecked = propertyItem.Value is null,
                        Margin = new Thickness(0, 0, 18, 0),
                        IsTabStop = false,
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

                var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = BindingMode.TwoWay };
                BindingOperations.SetBinding(editor, PropertyGridEditorIntegerUpDown.ValueProperty, bindingSelectedItemProperty);
            }
            else if (propertyItem.PropertyType == typeof(bool) || propertyItem.PropertyType == typeof(bool?) || propertyItem.PropertyType == typeof(Boolean) || propertyItem.PropertyType == typeof(Boolean?)) {
                var editorCheckbox = new PropertyGridEditorCheckBox {
                    IsThreeState = propertyItem.PropertyType.IsGenericType && propertyItem.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>),
                };
                editor = editorCheckbox;

                var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = BindingMode.TwoWay };
                BindingOperations.SetBinding(editor, PropertyGridEditorCheckBox.IsCheckedProperty, bindingSelectedItemProperty);
            }
            else if (propertyItem.PropertyType.IsEnum || (propertyItem.PropertyType.IsGenericType && propertyItem.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) && propertyItem.PropertyType.GenericTypeArguments[0].IsEnum)) {

                var editorEnumCheckBox = new ComboBox {
                    Background = System.Windows.Media.Brushes.Transparent,          
                };

                var bindingItemsSourceProperty = new Binding($"{propertyItem.DisplayName}List") { Source = propertyItem.Instance, Mode = BindingMode.OneWay };
                BindingOperations.SetBinding(editorEnumCheckBox, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

                var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = BindingMode.TwoWay };
                BindingOperations.SetBinding(editorEnumCheckBox, ComboBox.SelectedValueProperty, bindingSelectedItemProperty);

                if (supportsUnknown) {
                    //editorEnumCheckBox.Watermark = "[UNKNOWN]";

                    var radioButtonUnknown = new RadioButton {
                        ToolTip = "[Unknown]",
                        GroupName = propertyItem.DisplayName,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Center,
                        IsChecked = propertyItem.Value is null,
                        Margin = new Thickness(0, 0, 18, 0),
                        IsTabStop = false,
                    };
                    editorEnumCheckBox.SelectionChanged += (sender, e) => {
                        radioButtonUnknown.IsChecked = editorEnumCheckBox.SelectedValue==default;
                    };
                    radioButtonUnknown.Click += (sender, e) => {
                        if (editorEnumCheckBox.SelectedValue!=default)
                            editorEnumCheckBox.SelectedValue = default;
                        else
                            radioButtonUnknown.IsChecked = true;
                    };

                    panel.Children.Add(radioButtonUnknown);
                }

                editor = editorEnumCheckBox;

                //var bindingItemsSourceProperty = new Binding($"{propertyItem.DisplayName}List") { Source = propertyItem.Instance, Mode = BindingMode.OneWay };
                //BindingOperations.SetBinding(editor, PropertyGridEditorEnumCheckComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

                //var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = BindingMode.TwoWay };
                //BindingOperations.SetBinding(editor, PropertyGridEditorEnumCheckComboBox.SelectedValueProperty, bindingSelectedItemProperty);

                //var specific = new EnumComboBoxEditor();

                //var control = (Control)specific.ResolveEditor(propertyItem);
                //control.BorderBrush= System.Windows.Media.Brushes.Transparent;
                //control.BorderThickness = new Thickness(0);

                //border.Child = control;
                //return border;
            }
            else
                throw new NotImplementedException();

            panel.Children.Add(editor);

            Panel.SetZIndex(panel.Children[0], 10);
            Panel.SetZIndex(editor, 0);

            border.Child = panel;
            return border;
        }
    }





    public abstract class BindingRoleEditor : ComboBoxEditor
    {
    }

    public class InformationBindingRoleEditor : BindingRoleEditor
    {
        protected override IEnumerable CreateItemsSource(PropertyItem propertyItem) {
            var bindings = propertyItem.Instance as IInformationBindings;
            return bindings!.informationBindings.Select(e => e.role);
        }
    }

    public class FeatureBindingRoleEditor : BindingRoleEditor
    {
        protected override IEnumerable CreateItemsSource(PropertyItem propertyItem) {
            var bindings = propertyItem.Instance as IFeatureBindings;
            return bindings!.featureBindings.Select(e => e.role);

            //var type = propertyItem.Value.GetType().GenericTypeArguments[0];
            //var informationBindingDefinitions = (informationBindingDefinition[])type.GetMethod("get__informationBindingDefinitions")!.Invoke(null, null)!;
            //var associations = informationBindingDefinitions.Where(e => e.association.Equals(propertyItem.DisplayName));
            //return associations.Select(e => e.role);
        }
    }

    public abstract class BindingLinkEditor : ITypeEditor
    {
        public class Fruit
        {
            public string Name { get; set; }
        }


        public FrameworkElement ResolveEditor(PropertyItem propertyItem) {
            var border = new Border {
                BorderBrush = System.Windows.Media.Brushes.Red,
                BorderThickness = new Thickness(2),
            };

            var control = new ComboBox {
                Name = $"_dropDownButton{Guid.NewGuid():N}",
                IsEditable = false,
                IsDropDownOpen = false,
                DisplayMemberPath = nameof(FeatureTypeId.Id),
                BorderThickness = new System.Windows.Thickness(0),
                BorderBrush = System.Windows.Media.Brushes.Transparent,
            };

            var viewModel = (featureBindingViewModel)propertyItem.Instance;

            control.IsEnabled = !string.IsNullOrEmpty(viewModel.role);

            Binding newBinding = new Binding(propertyItem.DisplayName) {
                Source = propertyItem.Instance,
                Mode = BindingMode.OneWay,
            };
            newBinding.Converter = new BrushValidatorConvertor();
            border.SetBinding(Border.BorderBrushProperty, newBinding);

            viewModel.PropertyChanged += (s, e) => {
                if (string.IsNullOrEmpty(e.PropertyName) && !e.PropertyName!.Equals(nameof(featureBindingViewModel.role)))
                    return;
                control.IsEnabled = !string.IsNullOrEmpty(viewModel.role);
            };

            var featureId = new FeatureTypeId(viewModel.featureType!, viewModel.featureId!);
            control.Items.Add(featureId);
            control.SelectedItem = featureId;

            control.DropDownOpened += (s, e) => {
                var association = (viewModel as IFeatureBindings)!.featureBindings.SingleOrDefault(f => f.role == viewModel.role)!;

                var parameter = new QueryFeatureTypesEventArgs(association.roleType, association.association, viewModel.role, association.featureTypes);

                S100AttributeEditorControl.QueryFeaturesCommand.Execute(parameter, S100AttributeEditorControl.Singleton);

                if (control.Items.Count > 1)
                    control.Items.RemoveAt(1);

                foreach (var item in parameter.items) {
                    if (item.Code.Equals(featureId.Code) && item.Id.Equals(featureId.Id))
                        continue;
                    control.Items.Add(item);
                }
            };

            control.DropDownClosed += (s, e) => {
                var featureId = (FeatureTypeId)control.SelectedItem;

                viewModel.featureId = featureId.Id;
                viewModel.featureType = featureId.Code;

            };

            //panel.Child = control;

            border.Child=control;
            return border;
        }

#if null
        public FrameworkElement ResolveEditor2(PropertyItem propertyItem) {
            var template =
                @"<ControlTemplate TargetType=""xctk:DropDownButton"">
                        <ListBox>
                            <ListBox.ItemTemplate>
                                <DataTemplate>
                                    <TextBlock Text=""{Binding Id}"" />
                                </DataTemplate>
                            </ListBox.ItemTemplate>
                        </ListBox>
                    </ControlTemplate>"";
                ";
            var control = new ComboBox {
                Name = $"_dropDownButton{Guid.NewGuid():N}",
                IsEditable = false,
                IsDropDownOpen = false,
            };
            //control.Template = (ControlTemplate)System.Windows.Markup.XamlReader.Parse(template);

            var viewModel = propertyItem.Instance as FeatureAssociationViewModel;
            //viewModel!.PropertyChanged += (s, e) => {
            //    if (string.IsNullOrEmpty(e.PropertyName) && !e.PropertyName!.Equals("role"))
            //        return;

            //    control.Items.Clear();
            //};

            control.DropDownOpened += (s, e) => {
                var association = (viewModel as IFeatureBindings)!.featureBindings.SingleOrDefault(f => f.role == viewModel.role)!;

                var p = new QueryFeatureTypesEventArgs(association.roleType, association.association, viewModel.role, association.featureTypes, control);

                S100AttributeEditorControl.QueryFeaturesCommand.Execute(p, S100AttributeEditorControl.Singleton);
            };

            var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) {
                Source = propertyItem.Instance,
                Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay
            };
            BindingOperations.SetBinding(control, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);

            control.ContextMenuOpening += (s, e) => {
                System.Diagnostics.Debugger.Break();
            };

            if (!string.IsNullOrEmpty(viewModel.featureId)) {
                control.SelectedValue = viewModel.featureId;
            }


            //Interaction.Triggers
            //InvokeCommandAction invokeCommandAction = new InvokeCommandAction {
            //    Command = S100AttributeEditorControl.QueryFeaturesCommand,
            //    CommandParameter = "{Binding Path=.}" 
            //};

            //var eventTrigger = new EventTrigger() { EventName = "DropDownClosed" };
            //eventTrigger.Actions.Add(invokeCommandAction);

            //control.Triggers.Add(eventTrigger);

            //Binding binding = new Binding { Path = new PropertyPath("DataContext.DropDownCommand") };
            //BindingOperations.SetBinding(invokeCommandAction, InvokeCommandAction.CommandProperty, binding);

            //Microsoft.Xaml.Behaviors.EventTrigger eventTrigger = new Microsoft.Xaml.Behaviors.EventTrigger { EventName = "DropDownClosed" };
            //eventTrigger.Actions.Add(invokeCommandAction);

            //TriggerCollection triggers = Interaction.GetTriggers(??);
            //triggers.Add(eventTrigger);

            return control;
        }
#endif
        private void Control_ContextMenuOpening(object sender, ContextMenuEventArgs e) {
            throw new NotImplementedException();
        }
    }

    public class InformationBindingLinkEditor : BindingLinkEditor
    {

    }

    public class FeatureBindingLinkEditor : BindingLinkEditor
    {

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
            var attributes = propertyItem.Instance.GetType().GetProperty(propertyItem.DisplayName)!.GetCustomAttributes(true);

            //var attribute = (EnumerationAttribute)attributes.Single(attr => attr.GetType() == typeof(EnumerationAttribute));
            //(S100Framework.DomainModel.EnumerationAttribute)propertyItem.Instance.GetType().GetProperty(propertyItem.DisplayName)!.GetCustomAttributes(typeof(S100Framework.DomainModel.EnumerationAttribute), true)[0];
            return (IEnumerable)propertyItem.Instance.GetType().GetProperty($"{propertyItem.DisplayName}List")!.GetValue(propertyItem.Instance)!;
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
