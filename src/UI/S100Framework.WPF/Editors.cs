using S100Framework.DomainModel;
using S100Framework.WPF.ViewModel;
using System.Collections;
using System.Globalization;
using System.Reflection;
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

            var optional = attributes.SingleOrDefault(attr => attr.GetType() == typeof(OptionalAttribute)) != null;

            var border = new Border {
                BorderBrush = System.Windows.Media.Brushes.Transparent,
                BorderThickness = new Thickness(1),
            };

            var grid = new Grid { 
                //HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
            };
            grid.ColumnDefinitions.Add(new ColumnDefinition {
                Width = new GridLength(1, GridUnitType.Star),
            });
            grid.ColumnDefinitions.Add(new ColumnDefinition {
                Width = new GridLength(18),
            });

            if (supportsUnknown) {
                //Binding newBinding = new Binding(propertyItem.DisplayName) {
                //    Source = propertyItem.Instance,
                //    Mode = BindingMode.OneWay,
                //};
                //newBinding.Converter = new BrushUnknownConvertor();
                //border.SetBinding(Border.BorderBrushProperty, newBinding);
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
                    KeepWatermarkOnGotFocus = false,
                };

                var stringLengthConstraint = (StringLengthConstraintAttribute?)attributes.SingleOrDefault(attr => attr.GetType() == typeof(StringLengthConstraintAttribute));
                if (stringLengthConstraint != default) {
                    editorTextBox.MaxLength = stringLengthConstraint.StringLength;
                }

                if (supportsUnknown) {
                    editorTextBox.Watermark = "[UNKNOWN]";

                    var radioButtonUnknown = new RadioButton {
                        ToolTip = "[Unknown]",
                        GroupName = propertyItem.DisplayName,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Center,
                        IsChecked = propertyItem.Value is null,
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

                    Grid.SetColumn(radioButtonUnknown, 1);                    
                    grid.Children.Add(radioButtonUnknown);

                    Binding newBinding = new Binding(propertyItem.DisplayName) {
                        Source = propertyItem.Instance,
                        Mode = BindingMode.OneWay,
                    };
                    newBinding.Converter = new BrushUnknownConvertor();
                    radioButtonUnknown.SetBinding(RadioButton.BackgroundProperty, newBinding);
                }
                else if (optional) {
                    editorTextBox.Watermark = "[Null]";

                    var crossButton = new CrossButton {
                        ToolTip = "[Nullalbe]",
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Center,
                        IsTabStop = false,
                        Width = 14,
                        MaxWidth = 14,
                        Height = 14,
                        MaxHeight = 14,
                    };

                    editorTextBox.TextChanged += (sender, e) => {
                        //crossButton.IsEnabled = editorEnumCheckBox.SelectedValue != default;
                    };
                    crossButton.Click += (sender, e) => {
                        if (!string.IsNullOrEmpty(editorTextBox.Text))
                            editorTextBox.Text = null;
                    };

                    Grid.SetColumn(crossButton, 1);
                    grid.Children.Add(crossButton);
                }
                editor = editorTextBox;

                var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = BindingMode.TwoWay };
                BindingOperations.SetBinding(editor, PropertyGridEditorTextBox.TextProperty, bindingSelectedItemProperty);
            }
            else if (propertyItem.PropertyType == typeof(double) || propertyItem.PropertyType == typeof(double?)) {
                var editorDecimalUpDown = new PropertyGridEditorDecimalUpDown {
                    Background = System.Windows.Media.Brushes.Transparent,
                    ShowButtonSpinner = false,   
                    ParsingNumberStyle = NumberStyles.Float | NumberStyles.AllowDecimalPoint
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

                    Grid.SetColumn(radioButtonUnknown, 1);
                    grid.Children.Add(radioButtonUnknown);

                    Binding newBinding = new Binding(propertyItem.DisplayName) {
                        Source = propertyItem.Instance,
                        Mode = BindingMode.OneWay,
                    };
                    newBinding.Converter = new BrushUnknownConvertor();
                    radioButtonUnknown.SetBinding(RadioButton.BackgroundProperty, newBinding);
                }
                else if (optional) {
                    editorDecimalUpDown.Watermark = "[Null]";

                    var crossButton = new CrossButton {
                        ToolTip = "[Nullalbe]",
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Center,
                        IsTabStop = false,
                        Width = 14,
                        MaxWidth = 14,
                        Height = 14,
                        MaxHeight = 14,
                    };

                    editorDecimalUpDown.ValueChanged += (sender, e) => {
                        //crossButton.IsEnabled = editorEnumCheckBox.SelectedValue != default;
                    };
                    crossButton.Click += (sender, e) => {
                        if (editorDecimalUpDown.Value != null)
                            editorDecimalUpDown.Value = null;
                    };

                    Grid.SetColumn(crossButton, 1);
                    grid.Children.Add(crossButton);

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

                    Grid.SetColumn(radioButtonUnknown, 1);
                    grid.Children.Add(radioButtonUnknown);

                    Binding newBinding = new Binding(propertyItem.DisplayName) {
                        Source = propertyItem.Instance,
                        Mode = BindingMode.OneWay,
                    };
                    newBinding.Converter = new BrushUnknownConvertor();
                    radioButtonUnknown.SetBinding(RadioButton.BackgroundProperty, newBinding);
                }
                else if (optional) {
                    editorIntegerUpDown.Watermark = "[Null]";

                    var crossButton = new CrossButton {
                        ToolTip = "[Nullalbe]",
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Center,
                        IsTabStop = false,
                        Width = 14,
                        MaxWidth = 14,
                        Height = 14,
                        MaxHeight = 14,
                    };

                    editorIntegerUpDown.ValueChanged += (sender, e) => {
                        //crossButton.IsEnabled = editorEnumCheckBox.SelectedValue != default;
                    };
                    crossButton.Click += (sender, e) => {
                        if (editorIntegerUpDown.Value != null)
                            editorIntegerUpDown.Value = null;
                    };

                    Grid.SetColumn(crossButton, 1);
                    grid.Children.Add(crossButton);
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
                var editorEnumCheckBox = new WatermarkComboBox {
                    //Background = System.Windows.Media.Brushes.Transparent,
                };

                var bindingItemsSourceProperty = new Binding($"{propertyItem.DisplayName}List") { Source = propertyItem.Instance, Mode = BindingMode.OneWay };
                BindingOperations.SetBinding(editorEnumCheckBox, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

                var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = BindingMode.TwoWay };
                BindingOperations.SetBinding(editorEnumCheckBox, ComboBox.SelectedValueProperty, bindingSelectedItemProperty);

                if (supportsUnknown) {
                    editorEnumCheckBox.Watermark = "[UNKNOWN]";

                    var radioButtonUnknown = new RadioButton {
                        ToolTip = "[Unknown]",
                        GroupName = propertyItem.DisplayName,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Center,
                        IsChecked = propertyItem.Value is null,
                        IsTabStop = false,
                    };
                    editorEnumCheckBox.SelectionChanged += (sender, e) => {
                        radioButtonUnknown.IsChecked = editorEnumCheckBox.SelectedValue == default;
                    };
                    radioButtonUnknown.Click += (sender, e) => {
                        if (editorEnumCheckBox.SelectedValue != default)
                            editorEnumCheckBox.SelectedValue = default;
                        else
                            radioButtonUnknown.IsChecked = true;
                    };

                    Grid.SetColumn(radioButtonUnknown, 1);
                    grid.Children.Add(radioButtonUnknown);

                    Binding newBinding = new Binding(propertyItem.DisplayName) {
                        Source = propertyItem.Instance,
                        Mode = BindingMode.OneWay,
                    };
                    newBinding.Converter = new BrushUnknownConvertor();
                    radioButtonUnknown.SetBinding(RadioButton.BackgroundProperty, newBinding);
                }
                else if (optional) {
                    editorEnumCheckBox.Watermark = "[Null]";

                    var crossButton = new CrossButton {
                        ToolTip = "[Nullalbe]",                        
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Center,
                        IsTabStop = false,
                        Width = 14,
                        MaxWidth = 14,
                        Height = 14,
                        MaxHeight = 14,
                    };

                    editorEnumCheckBox.SelectionChanged += (sender, e) => {
                        //crossButton.IsEnabled = editorEnumCheckBox.SelectedValue != default;
                    };
                    crossButton.Click += (sender, e) => {
                        if (editorEnumCheckBox.SelectedItem != null)
                            editorEnumCheckBox.SelectedItem = null;
                    };

                    Grid.SetColumn(crossButton, 1);
                    grid.Children.Add(crossButton);
                }


                editor = editorEnumCheckBox;

                //else if (!multiplicity.Upper.HasValue && multiplicity.Upper > 1) {
                //    var editorEnumCheckBox = new CheckComboBox {
                //        Background = System.Windows.Media.Brushes.Transparent,
                //    };

                //    var bindingItemsSourceProperty = new Binding($"{propertyItem.DisplayName}List") { Source = propertyItem.Instance, Mode = BindingMode.OneWay };
                //    BindingOperations.SetBinding(editorEnumCheckBox, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

                //    var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = BindingMode.TwoWay };
                //    BindingOperations.SetBinding(editorEnumCheckBox, ComboBox.SelectedValueProperty, bindingSelectedItemProperty);

                //    if (supportsUnknown) {
                //        editorEnumCheckBox.Watermark = "[UNKNOWN]";

                //        var radioButtonUnknown = new RadioButton {
                //            ToolTip = "[Unknown]",
                //            GroupName = propertyItem.DisplayName,
                //            HorizontalAlignment = HorizontalAlignment.Right,
                //            VerticalAlignment = VerticalAlignment.Center,
                //            IsChecked = propertyItem.Value is null,
                //            Margin = new Thickness(0, 0, 18, 0),
                //            IsTabStop = false,
                //        };
                //        editorEnumCheckBox.ItemSelectionChanged += (sender, e) => {
                //            radioButtonUnknown.IsChecked = editorEnumCheckBox.SelectedValue == default;
                //        };
                //        radioButtonUnknown.Click += (sender, e) => {
                //            if (editorEnumCheckBox.SelectedValue != default)
                //                editorEnumCheckBox.SelectedValue = default;
                //            else
                //                radioButtonUnknown.IsChecked = true;
                //        };

                //        panel.Children.Add(radioButtonUnknown);
                //    }

                //    editor = editorEnumCheckBox;
                //}

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

            Grid.SetColumn(editor, 0);
            grid.Children.Add(editor);

            //Panel.SetZIndex(panel.Children[0], 10);
            //Panel.SetZIndex(editor, 0);

            border.Child = grid;
            return border;
        }
    }





    public abstract class BindingRoleEditor : ComboBoxEditor
    {
    }

    public class InformationBindingRoleEditor : BindingRoleEditor
    {
        protected override IEnumerable CreateItemsSource(PropertyItem propertyItem) {
            var bindings = propertyItem.Instance as IInformationBinding;
            return bindings!.informationBindings.Select(e => e.role);
        }
    }

    public class FeatureBindingRoleEditor : BindingRoleEditor
    {
        protected override IEnumerable CreateItemsSource(PropertyItem propertyItem) {
            var bindings = propertyItem.Instance as IFeatureBinding;
            return bindings!.featureBindings.Select(e => e.role);
        }
    }

    public abstract class BindingLinkEditor : ITypeEditor
    {
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

            var viewModel = (ViewModelBase)propertyItem.Instance;

            Binding newBinding = new Binding(propertyItem.DisplayName) {
                Source = propertyItem.Instance,
                Mode = BindingMode.OneWay,
            };
            newBinding.Converter = new BrushValidatorConvertor();
            border.SetBinding(Border.BorderBrushProperty, newBinding);

            if (propertyItem.Instance is IInformationBinding informationBindingViewModel) {
                control.IsEnabled = !string.IsNullOrEmpty(informationBindingViewModel.role);

                viewModel.PropertyChanged += (s, e) => {
                    if (string.IsNullOrEmpty(e.PropertyName) && !e.PropertyName!.Equals(nameof(IInformationBinding.role)))
                        return;
                    control.IsEnabled = !string.IsNullOrEmpty(informationBindingViewModel.role);
                };

                if (!string.IsNullOrEmpty(informationBindingViewModel.informationId)) {
                    var informationId = new InformationTypeId(informationBindingViewModel.informationType!, informationBindingViewModel.informationId);
                    control.Items.Add(informationId);
                    control.SelectedItem = informationId;
                }

                control.DropDownOpened += (s, e) => {
                    var association = (viewModel as IInformationBinding)!.informationBindings.SingleOrDefault(f => f.role == informationBindingViewModel.role)!;

                    var parameter = new QueryInformationTypesEventArgs(association.roleType, association.association, informationBindingViewModel.role, association.informationTypes, (items) => {
                        if (!string.IsNullOrEmpty(informationBindingViewModel.informationId)) {
                            if (control.Items.Count > 1)
                                control.Items.RemoveAt(1);

                            foreach (var item in items) {
                                if (item.Code.Equals(informationBindingViewModel.informationType) && item.Id.Equals(informationBindingViewModel.informationId))
                                    continue;
                                control.Items.Add(item);
                            }
                        }
                        else {
                            control.Items.Clear();
                            foreach (var item in items) {
                                control.Items.Add(item);
                            }
                        }
                    });

                    S100AttributeEditorControl.QueryInformationsCommand.Execute(parameter, S100AttributeEditorControl.Singleton);
                };
                control.DropDownClosed += (s, e) => {
                    if (control.SelectedItem is InformationTypeId informationTypeId) {
                        informationBindingViewModel.informationId = informationTypeId.Id;
                        informationBindingViewModel.informationType = informationTypeId.Code;
                    }
                };
            }
            else if (propertyItem.Instance is IFeatureBinding featureBindingViewModel) {
                control.IsEnabled = !string.IsNullOrEmpty(featureBindingViewModel.role);

                viewModel.PropertyChanged += (s, e) => {
                    if (string.IsNullOrEmpty(e.PropertyName) && !e.PropertyName!.Equals(nameof(IFeatureBinding.role)))
                        return;
                    control.IsEnabled = !string.IsNullOrEmpty(featureBindingViewModel.role);
                };

                if (!string.IsNullOrEmpty(featureBindingViewModel.featureId)) {
                    var featureId = new FeatureTypeId(featureBindingViewModel.featureType!, featureBindingViewModel.featureId!);
                    control.Items.Add(featureId);
                    control.SelectedItem = featureId;
                }

                control.DropDownOpened += (s, e) => {
                    var association = (viewModel as IFeatureBinding)!.featureBindings.SingleOrDefault(f => f.role == featureBindingViewModel.role)!;

                    var parameter = new QueryFeatureTypesEventArgs(association.roleType, association.association, featureBindingViewModel.role, association.featureTypes, (items) => {
                        if (!string.IsNullOrEmpty(featureBindingViewModel.featureId)) {
                            if (control.Items.Count > 1)
                                control.Items.RemoveAt(1);

                            foreach (var item in items) {
                                if (item.Code.Equals(featureBindingViewModel.featureType) && item.Id.Equals(featureBindingViewModel.featureId))
                                    continue;
                                control.Items.Add(item);
                            }
                        }
                        else {
                            control.Items.Clear();
                            foreach (var item in items) {
                                control.Items.Add(item);
                            }
                        }
                    });

                    S100AttributeEditorControl.QueryFeaturesCommand.Execute(parameter, S100AttributeEditorControl.Singleton);
                };
                control.DropDownClosed += (s, e) => {
                    if (control.SelectedItem is FeatureTypeId featureTypeId) {
                        featureBindingViewModel.featureId = featureTypeId.Id;
                        featureBindingViewModel.featureType = featureTypeId.Code;
                    }
                };
            }

            //panel.Child = control;

            border.Child = control;
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
            var attributes = ((PropertyItem)propertyItem.ParentElement).PropertyType.GetProperty(propertyItem.DisplayName)!.GetCustomAttributes(true);

            var grid = new Grid {
                //HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
            };
            grid.ColumnDefinitions.Add(new ColumnDefinition {
                Width = new GridLength(1, GridUnitType.Star),
            });
            grid.ColumnDefinitions.Add(new ColumnDefinition {
                Width = new GridLength(18),
            });

            var optional = attributes.SingleOrDefault(attr => attr.GetType() == typeof(OptionalAttribute)) != null;

            var editorTextBox = new PropertyGridEditorTextBox {
                Background = System.Windows.Media.Brushes.Transparent,
                MaxLength = 8,
                KeepWatermarkOnGotFocus = false,
                Watermark = "yyyyMMdd",
            };

            if (optional) {
                //editorTextBox.Watermark = "[Null]";

                var crossButton = new CrossButton {
                    ToolTip = "[Nullalbe]",
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Center,
                    IsTabStop = false,
                    Width = 14,
                    MaxWidth = 14,
                    Height = 14,
                    MaxHeight = 14,
                };

                editorTextBox.TextChanged += (sender, e) => {
                    //crossButton.IsEnabled = editorEnumCheckBox.SelectedValue != default;
                };
                crossButton.Click += (sender, e) => {
                    if (!string.IsNullOrEmpty(editorTextBox.Text))
                        editorTextBox.Text = null;
                };

                Grid.SetColumn(crossButton, 1);
                grid.Children.Add(crossButton);
            }

            editorTextBox.PreviewTextInput += this.Control_PreviewTextInput;

            var bindingSelectedItemProperty = new Binding(propertyItem.DisplayName) { Source = propertyItem.Instance, Mode = BindingMode.TwoWay };
            BindingOperations.SetBinding(editorTextBox, PropertyGridEditorTextBox.TextProperty, bindingSelectedItemProperty);

            bindingSelectedItemProperty.ValidationRules.Add(new PartialDateRule());
            BindingOperations.SetBinding(editorTextBox, PropertyGridEditorTextBox.TextProperty, bindingSelectedItemProperty);


            Grid.SetColumn(editorTextBox, 0);
            grid.Children.Add(editorTextBox);
            return grid;
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
                KeepWatermarkOnGotFocus = false,
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
