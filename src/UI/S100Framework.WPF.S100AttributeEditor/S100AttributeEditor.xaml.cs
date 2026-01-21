using Microsoft.Xaml.Behaviors;
using S100FC;
using S100FC.S101.ComplexAttributes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace S100Framework.WPF.ViewModel
{
    public class S100AttributeEditorViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged = default;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null) {
            if (Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion        

        public S100AttributeEditorViewModel(S100FC.FeatureType feature, string uid) {
            this._feature = feature;
            this._uid = uid;
            this.code = this._feature.S100FC_code;
            this.attributeBindingsCatalogue = this._feature.attributeBindingsCatalogue;

            this.attributeBindings.CollectionChanged += (s, e) => {
                if (e.NewItems is not null) {
                    foreach (var item in e.NewItems) {
                        if(item is SimpleAttributeViewModel simpleAttribute) {
                            simpleAttribute.PropertyChanged += this.Viewmodel_PropertyChanged;
                        }
                        else if (item is ComplexAttributeViewModel complexAttribute) {
                            complexAttribute.PropertyChanged += this.Viewmodel_PropertyChanged;
                        }
                    }
                    this.OnPropertyChanged("attributes");
                }
            };

            foreach (var e in this._feature.attributeBindings.OrderBy(e => this.attributeBindingsCatalogue.Single(a => a.attribute.Equals(e.S100FC_code)).order)) {
                if (e is SimpleAttribute simpleAttribute) {
                    var viewmodel = new SimpleAttributeViewModel(simpleAttribute);
                    this.attributeBindings.Add(viewmodel);
                }
                else if (e is ComplexAttribute complexAttribute) {
                    var viewmodel = new ComplexAttributeViewModel(complexAttribute);
                    this.attributeBindings.Add(viewmodel);
                }
            }
        }

        public bool HasCapacity(attributeBindingDefinition binding) {
            var count = this.attributeBindings.Count(e => e.code.Equals(binding.attribute));
            return binding.upper > count;
        }

        private void Viewmodel_PropertyChanged(object? sender, PropertyChangedEventArgs e) {
            this.PropertyChanged?.Invoke(sender, e);
        }

        #region Properties        

        private string _code = "UNKNOWN";

        //[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
        //[Category("RecommendedTrack")]
        public string code {
            get {
                return _code;
            }
            set {
                SetProperty(ref _code, value);
            }
        }

        public ObservableCollection<AttributeViewModel> attributeBindings { get; set; } = [];

        public attributeBindingDefinition[] attributeBindingsCatalogue { get; init; } = [];
        #endregion

        private S100FC.FeatureType? _feature = default;
        private string _uid;
    }
}

namespace S100Framework.WPF
{
    using S100Framework.WPF.ViewModel;
    using Xceed.Wpf.Toolkit.PropertyGrid;

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
                if (this.SelectedObject.HasCapacity(attributeBinding)) {
                    var instance = attributeBinding.CreateInstance();
                    if (instance is SimpleAttribute simpleAttribute)
                        this.SelectedObject?.attributeBindings.Add(new SimpleAttributeViewModel(simpleAttribute));
                    else if (instance is ComplexAttribute complexAttribute)
                        this.SelectedObject?.attributeBindings.Add(new ComplexAttributeViewModel(complexAttribute));
                    else
                        throw new NotImplementedException();
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
            get => GetValue(SelectedObjectProperty) as S100AttributeEditorViewModel;
            set => SetValue(SelectedObjectProperty, value);
        }

        public S100AttributeEditor() {
            InitializeComponent();

            this.CreateAttributeCommand = new RelayCommand(this.OnCreateAttributeCommand);
            this.DeleteAttributeCommand=new RelayCommand(this.OnDeleteAttributeCommand);
        }

        private static void OnSelectedObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (d is S100AttributeEditor grid) {
                grid._selectedObject = e.NewValue as S100AttributeEditorViewModel;
            }
        }

        private S100AttributeEditorViewModel? _selectedObject;

    }
}
