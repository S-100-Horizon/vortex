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

    /// <summary>
    /// Interaction logic for S100AttributeEditor.xaml
    /// </summary>
    public partial class S100AttributeEditor : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged = default;

        public ICommand CreateAttributeCommand { get; }

        public ICommand DeleteAttributeCommand { get; }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected void OnCreateAttributeCommand(object? parameter) {
            if (this.SelectedObject is null) return;
            if (parameter is attributeBindingDefinition attributeBinding) {
                if (this.SelectedObject!.HasCapacity(attributeBinding)) {
                    var instance = attributeBinding.CreateInstance();
                    if (instance is SimpleAttribute simpleAttribute)
                        this.SelectedObject?.attributeBindings.Add(new SimpleAttributeViewModel(simpleAttribute));
                    else if (instance is ComplexAttribute complexAttribute)
                        this.SelectedObject?.attributeBindings.Add(new ComplexAttributeViewModel(complexAttribute));
                    else
                        throw new NotImplementedException();
                }
            }
            if(parameter is IGrouping<string, informationBindingDefinition> informationBinding) {
                if (this.SelectedObject!.HasCapacity(informationBinding)) {
                    this.SelectedObject?.informationBindings.Add(new InformationBindingViewModel(informationBinding));
                }
            }
            if(parameter is IGrouping<string,featureBindingDefinition> featureBinding) {
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

        public S100AttributeEditor() {
            this.InitializeComponent();

            this.CreateAttributeCommand = new RelayCommand(this.OnCreateAttributeCommand);
            this.DeleteAttributeCommand = new RelayCommand(this.OnDeleteAttributeCommand);
        }

        private static void OnSelectedObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (d is S100AttributeEditor grid) {
                grid._selectedObject = e.NewValue as S100AttributeEditorViewModel;
            }
        }

        private S100AttributeEditorViewModel? _selectedObject;

    }
}
