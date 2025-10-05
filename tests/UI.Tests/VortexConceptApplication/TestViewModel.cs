using S100Framework.DomainModel;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.WPF.Converters;
using S100Framework.WPF.Editors;
using S100Framework.WPF.ViewModel;
using S100Framework.WPF.ViewModel.S101;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace VortexConceptApplication
{




    public class TestQualityOfBathymetricData : QualityOfBathymetricData
    {
    }

    public class TestViewModel : UnderwaterAwashRockViewModel
    {
        private double? _decimal;

        //[Category("Test")]
        //[Editor(typeof(S100Framework.WPF.Editors.UnknownDoubleEditor), typeof(S100Framework.WPF.Editors.UnknownDoubleEditor))]
        //public double? Decimal {
        //    get {
        //        return _decimal;
        //    }
        //    set {
        //        SetValue(ref _decimal, value);
        //    }
        //}

        private String _interoperabilityIdentifier2;

        [Category("Test")]               
        public bool? Bool {
            get {
                return _bool;
            }
            set {
                SetValue(ref _bool, value);
            }
        }

        private bool? _bool;

        [Category("Test")]
        public String interoperabilityIdentifier2 {
            get {
                return _interoperabilityIdentifier2;
            }
            set {
                SetValue(ref _interoperabilityIdentifier2, value);
            }
        }
    }

    public class BrushValidatorConvertor : IValueConverter
    {
        const string ColorCode = "#ffb6b6";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is null)
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString(ColorCode));
            return System.Windows.Media.Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    //public class UnknownBooleanEditor : UnknownEditor
    //{
    //    public override FrameworkElement ResolveEditor(PropertyItem propertyItem) {

    //        var viewModel = propertyItem.Instance as ViewModelBase;

    //        var instance = (bool?)propertyItem.Value;

    //        var border = new Border {
    //            BorderBrush = System.Windows.Media.Brushes.Transparent,
    //            Background = System.Windows.Media.Brushes.Transparent,
    //            BorderThickness = new Thickness(0),
    //            Padding = new Thickness(0),
    //            Margin = new Thickness(0),
    //        };
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



    //        Binding newBinding = new Binding(propertyItem.DisplayName) {
    //            Source = propertyItem.Instance,
    //            Mode = BindingMode.OneWay,
    //        };
    //        newBinding.Converter = new BrushValidatorConvertor();
    //        panel.SetBinding(Border.BackgroundProperty, newBinding);

    //        //border.Child = panel;
    //        panel.Children.Add(editor);

    //        return panel;
    //    }
    //}

    //public class TristateEditor<T> : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    //{
    //    private string[] _names = Enum.GetNames<TristateStatus>();

    //    private TristateStatus[] States => [TristateStatus.Unknown, TristateStatus.Value, TristateStatus.Null];

    //    //public event PropertyChangedEventHandler? PropertyChanged;

    //    //protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
    //    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    //}

    //    public FrameworkElement ResolveEditor(PropertyItem propertyItem) {

    //        var instance = (TristateViewModel<T>)propertyItem.Value;

    //        var panel = new DockPanel {
    //            LastChildFill = true,
    //        };

    //        var radioButtonNull = new RadioButton {
    //            ToolTip = "[Null]",
    //            GroupName = "TristateStatus",
    //            Background = System.Windows.Media.Brushes.LightSkyBlue,
    //        };
    //        radioButtonNull.Checked += (s, e) => {
    //            //OnPropertyChanged(nameof(instance));
    //        };

    //        var bindingSelectedItemProperty = new Binding("Status") { Source = instance, Mode = BindingMode.TwoWay };
    //        bindingSelectedItemProperty.Converter = new TristateConverter();
    //        bindingSelectedItemProperty.ConverterParameter = TristateStatus.Null;
    //        BindingOperations.SetBinding(radioButtonNull, RadioButton.IsCheckedProperty, bindingSelectedItemProperty);


    //        var radioButtonUnknown = new RadioButton {
    //            ToolTip = "[Unknown]",
    //            GroupName = "TristateStatus",
    //            Background = System.Windows.Media.Brushes.Orange,
    //        };
    //        radioButtonUnknown.Checked += (s, e) => {
    //            //OnPropertyChanged(nameof(instance));
    //        };

    //        bindingSelectedItemProperty = new Binding("Status") { Source = instance, Mode = BindingMode.TwoWay };
    //        bindingSelectedItemProperty.Converter = new TristateConverter();
    //        bindingSelectedItemProperty.ConverterParameter = TristateStatus.Unknown;
    //        BindingOperations.SetBinding(radioButtonUnknown, RadioButton.IsCheckedProperty, bindingSelectedItemProperty);

    //        var type = typeof(T);

    //        panel.Children.Add(radioButtonNull);
    //        panel.Children.Add(radioButtonUnknown);

    //        if (type.IsEnum) {
    //            var defaultEditor = new PropertyGridEditorComboBox() {
    //            };
    //            defaultEditor.SelectionChanged += (s, e) => {
    //                //  REMOVE WHEN SWITCHING TO VIEWMODEL
    //                radioButtonNull.IsChecked = false;
    //                radioButtonUnknown.IsChecked = false;
    //                //OnPropertyChanged(nameof(instance));
    //            };
    //            radioButtonNull.Click += (s, e) => {
    //                defaultEditor.SelectedValue = null;
    //                radioButtonNull.IsChecked = true;
    //            };
    //            radioButtonUnknown.Click += (s, e) => {
    //                defaultEditor.SelectedValue = null;
    //                radioButtonUnknown.IsChecked = true;
    //            };

    //            var attribute = (S100Framework.DomainModel.EnumerationAttribute)propertyItem.Instance.GetType().GetProperty(propertyItem.DisplayName)!.GetCustomAttributes(typeof(S100Framework.DomainModel.EnumerationAttribute), true)[0];

    //            var bindingItemsSourceProperty = new Binding(attribute.PropertyName) { Source = propertyItem.Instance, Mode = BindingMode.OneWay };
    //            BindingOperations.SetBinding(defaultEditor, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

    //            bindingSelectedItemProperty = new Binding("Value") { Source = instance, Mode = BindingMode.OneWay };
    //            //bindingSelectedItemProperty.Converter = new TristateConverter();
    //            BindingOperations.SetBinding(defaultEditor, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);
    //            panel.Children.Add(defaultEditor);
    //        }

    //        return panel;
    //    }
    //}
}
