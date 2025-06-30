using S100Framework.DomainModel;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.WPF.Converters;
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




    public class TestQualityOfBathymetricData : QualityOfBathymetricData
    {
    }

    public class TestQualityOfBathymetricDataViewModel : QualityOfBathymetricDataViewModel
    {
        private Random _random = new Random();


        private Tristate<categoryOfTemporalVariation> _categoryOfTemporalVariationUnknown = Tristate<categoryOfTemporalVariation>.Unknown;

        [Category("QualityOfBathymetricData")]
        [Editor(typeof(TristateEditor<categoryOfTemporalVariation>), typeof(TristateEditor<categoryOfTemporalVariation>))]
        [S100Framework.DomainModel.EnumerationAttribute(nameof(categoryOfTemporalVariationList), typeof(categoryOfTemporalVariation))]
        public Tristate<categoryOfTemporalVariation> categoryOfTemporalVariationUnknown {
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

    public class TristateEditor<T> : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        private string[] _names = Enum.GetNames<TristateStatus>();

        private TristateStatus[] States => [TristateStatus.Unknown, TristateStatus.Value, TristateStatus.Null];

        //public event PropertyChangedEventHandler? PropertyChanged;

        //protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        public FrameworkElement ResolveEditor(PropertyItem propertyItem) {

            var instance = (Tristate<T>)propertyItem.Value;

            var panel = new DockPanel {
                LastChildFill = true,
            };

            var radioButtonNull = new RadioButton {
                ToolTip = "[Null]",
                GroupName = "TristateStatus",
                Background = System.Windows.Media.Brushes.LightSkyBlue,
            };
            radioButtonNull.Checked += (s, e) => {
                //OnPropertyChanged(nameof(instance));
            };

            var bindingSelectedItemProperty = new Binding("Status") { Source = instance, Mode = BindingMode.TwoWay };
            bindingSelectedItemProperty.Converter = new TristateConverter();
            bindingSelectedItemProperty.ConverterParameter = TristateStatus.Null;
            BindingOperations.SetBinding(radioButtonNull, RadioButton.IsCheckedProperty, bindingSelectedItemProperty);


            var radioButtonUnknown = new RadioButton {
                ToolTip = "[Unknown]",
                GroupName = "TristateStatus",
                Background = System.Windows.Media.Brushes.Orange,
            };
            radioButtonUnknown.Checked += (s, e) => {
                //OnPropertyChanged(nameof(instance));
            };

            bindingSelectedItemProperty = new Binding("Status") { Source = instance, Mode = BindingMode.TwoWay };
            bindingSelectedItemProperty.Converter = new TristateConverter();
            bindingSelectedItemProperty.ConverterParameter = TristateStatus.Unknown;
            BindingOperations.SetBinding(radioButtonUnknown, RadioButton.IsCheckedProperty, bindingSelectedItemProperty);

            var type = typeof(T);
            
            panel.Children.Add(radioButtonNull);
            panel.Children.Add(radioButtonUnknown);

            if (type.IsEnum) {
                var defaultEditor = new PropertyGridEditorComboBox() {
                };
                defaultEditor.SelectionChanged += (s, e) => {
                    //  REMOVE WHEN SWITCHING TO VIEWMODEL
                    radioButtonNull.IsChecked = false;
                    radioButtonUnknown.IsChecked = false;
                    //OnPropertyChanged(nameof(instance));
                };
                radioButtonNull.Click += (s, e) => {
                    defaultEditor.SelectedValue = null;
                    radioButtonNull.IsChecked = true;
                };
                radioButtonUnknown.Click += (s, e) => {
                    defaultEditor.SelectedValue = null;
                    radioButtonUnknown.IsChecked = true;
                };

                var attribute = (S100Framework.DomainModel.EnumerationAttribute)propertyItem.Instance.GetType().GetProperty(propertyItem.DisplayName)!.GetCustomAttributes(typeof(S100Framework.DomainModel.EnumerationAttribute), true)[0];

                var bindingItemsSourceProperty = new Binding(attribute.PropertyName) { Source = propertyItem.Instance, Mode = BindingMode.OneWay };
                BindingOperations.SetBinding(defaultEditor, ComboBox.ItemsSourceProperty, bindingItemsSourceProperty);

                bindingSelectedItemProperty = new Binding("Value") { Source = instance, Mode = BindingMode.OneWay };
                //bindingSelectedItemProperty.Converter = new TristateConverter();
                BindingOperations.SetBinding(defaultEditor, ComboBox.SelectedItemProperty, bindingSelectedItemProperty);
                panel.Children.Add(defaultEditor);
            }

            return panel;
        }
    }



}
