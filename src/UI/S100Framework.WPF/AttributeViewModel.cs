using S100FC;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.WPF.ViewModel
{
    public abstract class AttributeViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged = default;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private Dictionary<AttributeViewModel, string> nestedProperties = new();

        protected void SetProperty<T>(ref T backingFiled, T value, [CallerMemberName] string? propertyName = null) {
            System.Diagnostics.Debug.WriteLine($"SetProperty({propertyName})");
            if (string.IsNullOrWhiteSpace(propertyName)) return;

            //if (EqualityComparer<T>.Default.Equals(backingFiled, value)) return;
            //if (backingFiled is AttributeViewModel viewModel) {   // if old value is ViewModel, than we assume that it was subscribed, so - unsubscribe it
            //    viewModel.PropertyChanged -= ChildViewModelChanged;
            //    nestedProperties.Remove(viewModel);
            //}
            //if (value is AttributeViewModel valueViewModel) {
            //    // if new value is ViewModel, than we must subscribe it on PropertyChanged and add it into subscribe dictionary
            //    valueViewModel.PropertyChanged += ChildViewModelChanged;
            //    nestedProperties.Add(valueViewModel, propertyName);
            //}
            backingFiled = value;
            OnPropertyChanged(this.code);
        }

        private void ChildViewModelChanged(object? sender, PropertyChangedEventArgs e) {
            if (string.IsNullOrEmpty(e.PropertyName)) return;

            // this is child property name, need to get parent property name from dictionary
            string propertyName = e.PropertyName;
            if (sender is AttributeViewModel viewModel) {
                propertyName = nestedProperties[viewModel];
            }
            // Rise parent PropertyChanged with parent property name
            OnPropertyChanged(propertyName);
        }

        #endregion

        #region Properties        

        public string code { get; init; } = "UNKNOWN";

        #endregion

        public AttributeViewModel(S100FC.attributeBinding attribute) {
            this.code = attribute.S100FC_code;
        }
    }

    public class SimpleAttributeViewModel : AttributeViewModel
    {
        public SimpleAttributeViewModel(SimpleAttribute attribute) : base(attribute) {
            this._attribute = attribute;

            this.value = attribute.GetType().GetProperty("value")!.GetValue(attribute);
        }

        public string valueType => this._attribute!.valueType;

        private object? _value;

        public object? value {
            get {
                return _value;
            }
            set {
                SetProperty(ref _value, value);
            }
        }

        public S100FC.SimpleAttribute? _attribute { get; init; } = default;
    }

    public class ComplexAttributeViewModel : AttributeViewModel
    {
        public attributeBindingDefinition[] attributeBindingsCatalogue { get; init; } = [];

        public ObservableCollection<AttributeViewModel> attributeBindings { get; set; } = [];

        public ComplexAttributeViewModel(ComplexAttribute attribute) : base(attribute) {
            this._attribute = attribute;

            this.attributeBindingsCatalogue = this._attribute.attributeBindingsCatalogue;

            this.attributeBindings.CollectionChanged += (s, e) => {
                if (e.NewItems is not null) {
                    foreach (var item in e.NewItems) {
                        if (item is SimpleAttributeViewModel simpleAttribute) {
                            simpleAttribute.PropertyChanged += this.Viewmodel_PropertyChanged;
                        }
                        else if (item is ComplexAttributeViewModel complexAttribute) {
                            complexAttribute.PropertyChanged += this.Viewmodel_PropertyChanged;
                        }
                    }
                }
            };

            foreach (var e in attribute.attributeBindings) {
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
            //if(sender is S100FC.SimpleAttribute simpleAttribute)
            //    base.OnPropertyChanged(simpleAttribute.S100FC_code);
            //else
                base.OnPropertyChanged(e.PropertyName);
        }

        private S100FC.ComplexAttribute? _attribute = default;
    }
}
