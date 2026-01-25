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
    public class S100AttributeEditorViewModel : INotifyPropertyChanged
    {
        public class informationBindingContainer
        {
            public string[] associations => [.. this._informationBindingDefinitions.Select(e => e.Key)];

            public IEnumerable<IGrouping<string, informationBindingDefinition>> GroupBy => this._informationBindingDefinitions;

            private IEnumerable<IGrouping<string, informationBindingDefinition>> _informationBindingDefinitions { get; init; } = [];

            public informationBindingContainer(S100FC.informationBindingDefinition[] informationBindingDefinitions) {
                this._informationBindingDefinitions = informationBindingDefinitions.GroupBy(e => e.association);
            }
        }

        public class featureBindingContainer {
            public string[] associations => [.. this._featureBindingDefinitions.Select(e => e.Key)];

            public IEnumerable<IGrouping<string, featureBindingDefinition>> GroupBy => this._featureBindingDefinitions;

            private IEnumerable<IGrouping<string, featureBindingDefinition>> _featureBindingDefinitions { get; init; } = [];

            public featureBindingContainer(S100FC.featureBindingDefinition[] featureBindingDefinitions) {
                this._featureBindingDefinitions = featureBindingDefinitions.GroupBy(e => e.association);
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged = default;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null) {
            if (Equals(field, value))
                return false;

            field = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        #endregion        

        public S100AttributeEditorViewModel(S100FC.FeatureType feature, string uid) {
            this._feature = feature;
            this._uid = uid;
            this.code = this._feature.S100FC_code;
            this.attributeBindingsCatalogue = this._feature.attributeBindingsCatalogue;

            if (feature is IInformationBindings informationBindings) {
                this.HasInformationBindings = true;

                informationBindingDefinitions = new informationBindingContainer(informationBindings.GetInformationBindingsDefinitions());
            }

            if (feature is IFeatureBindings featureBindings) {
                this.HasFeatureBindings = true;

                informationBindingDefinitions = new informationBindingContainer(featureBindings.GetInformationBindingsDefinitions());
                featureBindingDefinitions = new featureBindingContainer(featureBindings.GetFeatureBindingsDefinitions());
            }

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

        public bool HasInformationBindings { get; set; } = false;

        public informationBindingContainer? informationBindingDefinitions { get; set; } = null;

        public bool HasFeatureBindings { get; set; } = false;

        public featureBindingContainer? featureBindingDefinitions { get; set; } = null;

        public bool HasCapacity(attributeBindingDefinition binding) {
            var count = this.attributeBindings.Count(e => e.code.Equals(binding.attribute));
            return binding.upper > count;
        }

        private void Viewmodel_PropertyChanged(object? sender, PropertyChangedEventArgs e) {
            this.PropertyChanged?.Invoke(sender, e);
        }

        #region Operators
        public static S100AttributeEditorViewModel operator +(S100AttributeEditorViewModel viewModel, informationBinding informationBinding) {
            var association = informationBinding.GetType().GetGenericArguments()[0].Name;

            //var definition = viewModel.informationBindingDefinitions!.Single(e => e.association.Equals(association));

            //viewModel.informationBindings.Add(new InformationBindingViewModel(definition) {
            //    informationType = informationBinding.informationType,
            //    informationId = informationBinding.informationId,
            //});
            //viewModel.informationBindings.Add(new InformationBindingViewModel(informationBinding));
            return viewModel;
        }

        public static S100AttributeEditorViewModel operator +(S100AttributeEditorViewModel viewModel, featureBinding featureBinding) {
            var association = featureBinding.GetType().GetGenericArguments()[0].Name;

            //var definitions = viewModel.featureBindingDefinitions!.Where(e => e.association.Equals(association));

            //viewModel.featureBindings.Add(new FeatureBindingViewModel([.. definitions]) {
            //    roleType = featureBinding.roleType,
            //    role = featureBinding.role,
            //    featureType = featureBinding.featureType,
            //    featureId = featureBinding.featureId,
            //});
            return viewModel;
        }

        #endregion

        #region Properties        

        private string _code = "UNKNOWN";

        public string code {
            get {
                return this._code;
            }
            set {
                this.SetProperty(ref this._code, value);
            }
        }

        public ObservableCollection<AttributeViewModel> attributeBindings { get; set; } = [];

        public ObservableCollection<InformationBindingViewModel> informationBindings { get; set; } = [];

        public ObservableCollection<FeatureBindingViewModel> featureBindings { get; set; } = [];

        public attributeBindingDefinition[] attributeBindingsCatalogue { get; init; } = [];
        #endregion

        private readonly S100FC.FeatureType? _feature = default;
        private readonly string _uid;
    }
}
