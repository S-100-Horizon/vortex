using S100FC;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace S100Framework.WPF
{
    using S100Framework.WPF.ViewModel;
    using Xceed.Wpf.AvalonDock.Properties;

    /// <summary>
    /// Interaction logic for S100AttributeEditor.xaml
    /// </summary>
    public partial class S100AttributeEditor : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged = default;

        public ICommand CreateAttributeCommand { get; }

        public ICommand DeleteAttributeCommand { get; }

        //protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        //protected static void OnPropertyChanged(object? sender, PropertyChangedEventArgs e) {
        //    ;
        //}

        protected void OnCreateAttributeCommand(object? parameter) {
            var e = parameter as SelectionChangedBehaviorEventArgs;

            var container = e?.Parameter as IAttributeBindingContainer;

            if (this.SelectedObject is null) return;

            if (e?.SelectedItem is attributeBindingDefinition attributeBinding) {
                if (container!.HasCapacity(attributeBinding)) {
                    var instance = attributeBinding.CreateInstance();
                    if (instance is SimpleAttribute simpleAttribute)
                        container?.attributeBindings.Add(new SimpleAttributeViewModel(ref simpleAttribute));
                    else if (instance is DateAttribute dateAttribute)
                        container?.attributeBindings.Add(new DateAttributeViewModel(ref dateAttribute));
                    else if (instance is DateTimeAttribute dateTimeAttribute)
                        container?.attributeBindings.Add(new DateTimeAttributeViewModel(ref dateTimeAttribute));
                    else if (instance is ComplexAttribute complexAttribute)
                        container?.attributeBindings.Add(new ComplexAttributeViewModel(ref complexAttribute));
                    else
                        throw new NotImplementedException();
                }
            }

            //if (e?.SelectedItem is attributeBindingDefinition attributeBinding) {
            //    if (e.SelectedObject!.HasCapacity(attributeBinding)) {
            //        var instance = attributeBinding.CreateInstance();
            //        if (instance is SimpleAttribute simpleAttribute)
            //            this.SelectedObject?.attributeBindings.Add(new SimpleAttributeViewModel(ref simpleAttribute));
            //        else if (instance is DateAttribute dateAttribute)
            //            this.SelectedObject?.attributeBindings.Add(new DateAttributeViewModel(ref dateAttribute));
            //        else if (instance is DateTimeAttribute dateTimeAttribute)
            //            this.SelectedObject?.attributeBindings.Add(new DateTimeAttributeViewModel(ref dateTimeAttribute));
            //        else if (instance is ComplexAttribute complexAttribute)
            //            this.SelectedObject?.attributeBindings.Add(new ComplexAttributeViewModel(ref complexAttribute));
            //        else
            //            throw new NotImplementedException();
            //    }
            //}

            if (parameter is IGrouping<string, informationBindingDefinition> informationBinding) {
                if (this.SelectedObject!.HasCapacity(informationBinding)) {
                    this.SelectedObject?.informationBindings.Add(new InformationBindingViewModel(informationBinding));
                }
            }
            if (parameter is IGrouping<string, featureBindingDefinition> featureBinding) {
                if (this.SelectedObject!.HasCapacity(featureBinding)) {
                    this.SelectedObject?.featureBindings.Add(new FeatureBindingViewModel(featureBinding));
                }
            }
        }

        protected void OnDeleteAttributeCommand(object? parameter) {
            if (this.SelectedObject is null) return;
            if (parameter is ClickedBehavior.DeleteAttributeCommandEventArgs e) {
                if (e.parameter is SimpleAttributeViewModel simpleAttribute) {
                    if (e.parent is ItemsControl itemsControl) {
                        var collection = (ObservableCollection<AttributeViewModel>)itemsControl.ItemsSource;
                        var index = collection.IndexOf(simpleAttribute);
                        if (index >= 0) {
                            collection.RemoveAt(index);
                        }
                    }
                }
                if (e.parameter is ComplexAttributeViewModel complexAttribute) {
                    if (e.parent is ItemsControl itemsControl) {
                        var collection = (ObservableCollection<AttributeViewModel>)itemsControl.ItemsSource;
                        var index = collection.IndexOf(complexAttribute);
                        if (index >= 0) {
                            collection.RemoveAt(index);
                        }
                    }
                }
            }
        }

        private async void InformationUID_OnDropDownOpened(object sender, EventArgs e) {
            if (sender is null) return;
            if (((FrameworkElement)sender).DataContext is InformationBindingViewModel informationBinding) {
                var informationType = informationBinding.informationType;
                if (!string.IsNullOrEmpty(informationType)) {
                    var items = await this.SelectedObject?.RequestInformation?.Invoke(this.SelectedObject, new S100AttributeEditorViewModel.RequestInformationsEventArgs(informationType))!;

                    var selectedValue = informationBinding.informationUID;

                    informationBinding.informationUIDs.Clear();

                    if (selectedValue is not null) {
                        informationBinding.informationUIDs.Add(selectedValue);
                    }

                    if (items is not null) {
                        foreach (var uid in items) {
                            if (uid.Equals(selectedValue?.UID)) continue;
                            informationBinding.informationUIDs.Add(new InformationTypeID(informationType, uid));
                        }
                    }

                    if (selectedValue is not null) {
                        informationBinding.informationUID = selectedValue;
                    }
                }
            }
        }

        private async void FeatureUID_OnDropDownOpened(object sender, EventArgs e) {
            if (sender is null) return;
            if (((FrameworkElement)sender).DataContext is FeatureBindingViewModel featureBinding) {
                var featureType = featureBinding.featureType;
                if (!string.IsNullOrEmpty(featureType)) {
                    var items = await this.SelectedObject?.RequestFeatures?.Invoke(this.SelectedObject, new S100AttributeEditorViewModel.RequestFeaturesEventArgs(featureType))!;

                    var selectedValue = featureBinding.featureUID;

                    featureBinding.featureUIDs.Clear();

                    if (selectedValue is not null) {
                        featureBinding.featureUIDs.Add(selectedValue);
                    }

                    if (items is not null) {
                        foreach (var uid in items) {
                            if (uid.Equals(selectedValue?.UID)) continue;
                            featureBinding.featureUIDs.Add(new FeatureTypeID(featureType, uid));
                        }
                    }

                    if (selectedValue is not null) {
                        featureBinding.featureUID = selectedValue;
                    }
                }
            }
        }

        /// <summary>
        /// The object whose properties are being edited
        /// </summary>
        public static readonly DependencyProperty SelectedObjectProperty =
            DependencyProperty.Register(
                nameof(SelectedObject),
                typeof(S100AttributeEditorViewModel),
                typeof(S100AttributeEditor),
                new PropertyMetadata(null, OnSelectedObjectChanged));

        public S100AttributeEditorViewModel? SelectedObject {
            get => this.GetValue(SelectedObjectProperty) as S100AttributeEditorViewModel;
            set => this.SetValue(SelectedObjectProperty, value);
        }

        public static readonly DependencyProperty IsEditingEnabledProperty =
            DependencyProperty.Register(
                nameof(IsEditingEnabled),
                typeof(Boolean),
                typeof(S100AttributeEditor),
                new UIPropertyMetadata(false, IsEditingEnabledChanged));

        public Boolean IsEditingEnabled {
            get {
                return (Boolean)GetValue(IsEditingEnabledProperty);
            }
            set {
                SetValue(IsEditingEnabledProperty, value);
            }
        }

        public S100AttributeEditor() {
            this.InitializeComponent();

            this.CreateAttributeCommand = new RelayCommand(this.OnCreateAttributeCommand);
            this.DeleteAttributeCommand = new RelayCommand(this.OnDeleteAttributeCommand);
        }

        private static void OnSelectedObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (d is S100AttributeEditor grid) {
                if (grid._selectedObject is not null) {
                    //grid._selectedObject.PropertyChanged -= OnPropertyChanged;
                }
                grid._selectedObject = e.NewValue as S100AttributeEditorViewModel;

                if (grid._selectedObject != null) {
                    //grid._selectedObject.PropertyChanged += OnPropertyChanged;
                }
            }
        }

        private static void IsEditingEnabledChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args) {
            var control = sender as S100AttributeEditor;
            if (control is null)
                return;
        }

        private S100AttributeEditorViewModel? _selectedObject;

    }
}
