using S100FC;
using S100FC.S128.SimpleAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace S100Framework.WPF.ViewModel
{
    public class S100AttributeEditorViewModel : INotifyPropertyChanged, IAttributeBindingContainer, INotifyDataErrorInfo
    {
        public class RequestInformationsEventArgs(string? informationType) : EventArgs
        {
            public string? InformationType { get; } = informationType;
        }

        public class RequestFeaturesEventArgs(string? featureType) : EventArgs
        {
            public string? FeatureType { get; } = featureType;
        }
        public class SelectInformationTypesEvenArgs(InformationTypeID[] uids) : EventArgs
        {
            public InformationTypeID[] UIDs { get; } = uids;
        }

        public class SelectFeatureTypesEvenArgs(FeatureTypeID[] uids) : EventArgs
        {
            public FeatureTypeID[] UIDs { get; } = uids;
        }

        public delegate Task<string[]> RequestInformationsEventHandler(object? sender, RequestInformationsEventArgs e);

        public delegate Task<string[]> RequestFeaturesEventHandler(object? sender, RequestFeaturesEventArgs e);

        public delegate Task SelectInformationTypesEventHandler(object? sender, SelectInformationTypesEvenArgs e);

        public delegate Task SelectFeatureTypessEventHandler(object? sender, SelectFeatureTypesEvenArgs e);

        public class informationBindingContainer
        {
            public string[] associations => [.. this._informationBindingDefinitions.Select(e => e.Key)];

            public IEnumerable<IGrouping<string, informationBindingDefinition>> GroupBy => this._informationBindingDefinitions;

            private IEnumerable<IGrouping<string, informationBindingDefinition>> _informationBindingDefinitions { get; init; } = [];

            public informationBindingContainer(S100FC.informationBindingDefinition[] informationBindingDefinitions) {
                this._informationBindingDefinitions = informationBindingDefinitions.GroupBy(e => e.association);
            }
        }

        public class featureBindingContainer
        {
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

        #region INotifyDataErrorInfo
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged = default;

        public bool HasErrors => this._errors.Any();

        public IEnumerable GetErrors(string? propertyName) {
            if(string.IsNullOrEmpty(propertyName)) return Enumerable.Empty<string>();

            if (!this._errors.ContainsKey(propertyName) || !this._errors[propertyName].Any()) return Enumerable.Empty<string>();

            return this._errors[propertyName];
        }

        private void Validate() {
            this._errors.Clear();

            if (this.Instance is InformationType informationType) {
                this._errors[nameof(attributeBindings)] = new List<string>();
                //this._errors[nameof(informationBindings)] = new List<string>();

            }
            else if (this.Instance is FeatureType featureType) {
                this._errors[nameof(attributeBindings)] = new List<string>();
                //this._errors[nameof(informationBindings)] = new List<string>();
                //this._errors[nameof(featureBindings)] = new List<string>();

                featureType.Validate(this._errors[nameof(attributeBindings)]);

                //foreach(var informationBinding in this.informationBindings) {
                //    informationBinding.Validate(this._errors[nameof(informationBindings)]);
                //}

                //foreach (var featureBinding in this.featureBindings) {
                //    featureBinding.Validate(this._errors[nameof(featureBindings)]);
                //}

                this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(HasErrors)));
            }
        }

        private readonly Dictionary<string, List<string>> _errors = new();
        #endregion

        public RequestInformationsEventHandler RequestInformation = async (s, e) => { return []; };

        public RequestFeaturesEventHandler RequestFeatures = async (s, e) => { return []; };

        public SelectInformationTypesEventHandler SelectInformationTypes = async (s, e) => { };

        public SelectFeatureTypessEventHandler SelectFeatureTypes = async (s, e) => { };

        public S100AttributeEditorViewModel(S100FC.InformationType informationType, string uid) {
            this._informationType = informationType;
            this._uid = uid;
            this.code = this._informationType.S100FC_code;
            this.attributeBindingsCatalogue = this._informationType.attributeBindingsCatalogue;

            this.Flatten = () => this._informationType.Flatten();

            if (informationType is IInformationBindings informationBindings) {
                this.HasInformationBindings = true;

                informationBindingDefinitions = new informationBindingContainer(informationBindings.GetInformationBindingsDefinitions());
            }

            this.attributeBindings.CollectionChanged += (s, e) => {
                if (e.OldItems is not null) {
                    foreach (var item in e.OldItems) {
                        if (item is SimpleAttributeViewModel simpleAttributeViewModel) {
                            this._informationType.RemoveAttribute(simpleAttributeViewModel.attribute);
                        }
                        if (item is ComplexAttributeViewModel complexAttributeViewModel) {
                            this._informationType.RemoveAttribute(complexAttributeViewModel.attribute);
                        }

                        if (item is AttributeViewModel attribute) {
                            attribute.PropertyChanged -= this.Viewmodel_PropertyChanged;
                        }
                    }
                }
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
                //this.OnPropertyChanged("attributeBindings");
            };

            this.informationBindings.CollectionChanged += (s, e) => {
                if (e.OldItems is not null) {
                    foreach (var item in e.OldItems) {
                        if (item is InformationBindingViewModel informationBinding) {
                            informationBinding.PropertyChanged -= this.Viewmodel_PropertyChanged;
                        }
                    }
                }
                if (e.NewItems is not null) {
                    foreach (var item in e.NewItems) {
                        if (item is InformationBindingViewModel informationBinding) {
                            informationBinding.PropertyChanged += this.Viewmodel_PropertyChanged;
                        }
                    }
                }
                this.OnPropertyChanged("informationBindings");

                this.Validate();
            };

            foreach (var e in this._informationType.attributeBindings.OrderBy(e => this.attributeBindingsCatalogue.Single(a => a.attribute.Equals(e.S100FC_code)).order)) {
                var attributeBindingDefinition = this.attributeBindingsCatalogue.Single(a => a.attribute.Equals(e.S100FC_code));

                if (e is DateAttribute dateAttribute)
                    this.attributeBindings.Add(new DateAttributeViewModel(ref dateAttribute, attributeBindingDefinition));
                else if (e is DateTimeAttribute dateTimeAttribute)
                    this.attributeBindings.Add(new DateTimeAttributeViewModel(ref dateTimeAttribute, attributeBindingDefinition));
                else if (e is SimpleAttribute simpleAttribute)
                    this.attributeBindings.Add(new SimpleAttributeViewModel(ref simpleAttribute, attributeBindingDefinition));
                else if (e is ComplexAttribute complexAttribute)
                    this.attributeBindings.Add(new ComplexAttributeViewModel(ref complexAttribute));
            }

            //note: Must be added right by the end!
            this.attributeBindings.CollectionChanged += (s, e) => {
                this.OnPropertyChanged("attributeBindings");
            };

            this.Validate();
        }

        public S100AttributeEditorViewModel(S100FC.FeatureType feature, string uid) {
            this._featureType = feature;
            this._uid = uid;
            this.code = this._featureType.S100FC_code;
            this.attributeBindingsCatalogue = this._featureType.attributeBindingsCatalogue;

            this.Flatten = () => this._featureType.Flatten();

            if (feature is IInformationBindings informationBindings) {
                var _informationBindingDefinitions = informationBindings.GetInformationBindingsDefinitions();

                if (_informationBindingDefinitions.Any())
                    informationBindingDefinitions = new informationBindingContainer(_informationBindingDefinitions);

                this.HasInformationBindings = this.informationBindingDefinitions is not null;
            }

            if (feature is IFeatureBindings featureBindings) {
                var _featureBindingDefinitions = featureBindings.GetFeatureBindingsDefinitions();

                if (_featureBindingDefinitions.Any())
                    featureBindingDefinitions = new featureBindingContainer(_featureBindingDefinitions);

                this.HasFeatureBindings = this.featureBindingDefinitions is not null;
            }

            this.attributeBindings.CollectionChanged += (s, e) => {
                if (e.OldItems is not null) {
                    foreach (var item in e.OldItems) {
                        if (item is SimpleAttributeViewModel simpleAttributeViewModel) {
                            this._featureType.RemoveAttribute(simpleAttributeViewModel.attribute);
                        }
                        if (item is ComplexAttributeViewModel complexAttributeViewModel) {
                            this._featureType.RemoveAttribute(complexAttributeViewModel.attribute);
                        }

                        if (item is AttributeViewModel attribute) {
                            attribute.PropertyChanged -= this.Viewmodel_PropertyChanged;
                        }
                    }
                }
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

            this.informationBindings.CollectionChanged += (s, e) => {
                if (e.OldItems is not null) {
                    foreach (var item in e.OldItems) {
                        if (item is InformationBindingViewModel informationBinding) {
                            informationBinding.PropertyChanged -= this.Viewmodel_PropertyChanged;
                        }
                    }
                }
                if (e.NewItems is not null) {
                    foreach (var item in e.NewItems) {
                        if (item is InformationBindingViewModel informationBinding) {
                            informationBinding.PropertyChanged += this.Viewmodel_PropertyChanged;
                        }
                    }
                }
                this.OnPropertyChanged("informationBindings");

                this.Validate();
            };

            this.featureBindings.CollectionChanged += (s, e) => {
                if (e.OldItems is not null) {
                    foreach (var item in e.OldItems) {
                        if (item is FeatureBindingViewModel featureBinding) {
                            featureBinding.PropertyChanged -= this.Viewmodel_PropertyChanged;
                        }
                    }
                }
                if (e.NewItems is not null) {
                    foreach (var item in e.NewItems) {
                        if (item is FeatureBindingViewModel featureBinding) {
                            featureBinding.PropertyChanged += this.Viewmodel_PropertyChanged;
                        }
                    }
                }
                this.OnPropertyChanged("featureBindings");

                this.Validate();
            };

            foreach (var e in this._featureType.attributeBindings.OrderBy(e => this.attributeBindingsCatalogue.Single(a => a.attribute.Equals(e.S100FC_code)).order)) {
                var attributeBindingDefinition = this.attributeBindingsCatalogue.Single(a => a.attribute.Equals(e.S100FC_code));

                if (e is DateAttribute dateAttribute)
                    this.attributeBindings.Add(new DateAttributeViewModel(ref dateAttribute, attributeBindingDefinition));
                else if (e is DateTimeAttribute dateTimeAttribute)
                    this.attributeBindings.Add(new DateTimeAttributeViewModel(ref dateTimeAttribute, attributeBindingDefinition));
                else if (e is SimpleAttribute simpleAttribute)
                    this.attributeBindings.Add(new SimpleAttributeViewModel(ref simpleAttribute, attributeBindingDefinition));
                else if (e is ComplexAttribute complexAttribute)
                    this.attributeBindings.Add(new ComplexAttributeViewModel(ref complexAttribute));
            }

            //note: Must be added right by the end!
            this.attributeBindings.CollectionChanged += (s, e) => {
                this.OnPropertyChanged("attributeBindings");
            };

            this.Validate();
        }

        public bool HasInformationBindings { get; init; } = false;

        public informationBindingContainer? informationBindingDefinitions { get; set; } = null;

        public bool HasFeatureBindings { get; init; } = false;

        public featureBindingContainer? featureBindingDefinitions { get; set; } = null;

        public bool HasCapacity(attributeBindingDefinition binding) {
            var count = this.attributeBindings.Count(e => e.code.Equals(binding.attribute));
            return binding.upper > count;
        }

        public bool HasCapacity(IGrouping<string, informationBindingDefinition> binding) {
            return true;
            //var count = this.informationBindings.Count(e => e.association.Equals(binding.association) && e.role!.Equals(binding.role));

            //var definition = this.informationBindingDefinitions!.GroupBy.Single(e => e.Key.Equals(binding.association)).Single(e => e.role.Equals(binding.role));

            //return definition.upper > count;
        }

        public bool HasCapacity(IGrouping<string, featureBindingDefinition> binding) {
            return true;
            //var count = this.featureBindings.Count(e => e.association.Equals(binding.association) && e.role!.Equals(binding.role));

            //var definition = this.featureBindingDefinitions!.GroupBy.Single(e => e.Key.Equals(binding.association)).Single(e => e.role.Equals(binding.role));

            //return definition.upper > count;
        }

        public void AddAttribute(AttributeViewModel attributeBinding) {
            this.attributeBindings.Add(attributeBinding);

            if (this.Instance is S100FC.InformationType informationType) {
                informationType.SetAttribute(attributeBinding.attribute);
            }
            if (this.Instance is S100FC.FeatureType featureType) {
                featureType.SetAttribute(attributeBinding.attribute);
            }
        }

        private void Viewmodel_PropertyChanged(object? sender, PropertyChangedEventArgs e) {            
            if (sender is AttributeViewModel attribute) {
                //if (!attribute.attribute.IsValid(this.attributeBindings.Select(e => e.attribute))) {
                //    this._errors[attribute.code] = new List<string> { "Dependency" };
                //    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(attribute.code));
                //}

                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(attributeBindings)));

                this.Validate();
            }
            else if (sender is InformationBindingViewModel informationBinding) {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(informationBindings)));
            }
            else if (sender is FeatureBindingViewModel featureBinding) {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(featureBindings)));
            }
            else if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();
        }


        #region Operators
        public static S100AttributeEditorViewModel operator +(S100AttributeEditorViewModel viewModel, informationBinding informationBinding) {
            var association = informationBinding.GetType().GetGenericArguments()[0].Name;

            var definitions = viewModel.informationBindingDefinitions!.GroupBy.Single(e => e.Key.Equals(association));

            viewModel.informationBindings.Add(new InformationBindingViewModel(definitions) {
                roleType = informationBinding.roleType,
                role = informationBinding.role,
                informationType = informationBinding.informationType,
                informationUID = new InformationTypeID(informationBinding.informationType!, informationBinding.informationId),
            });
            return viewModel;
        }

        public static S100AttributeEditorViewModel operator +(S100AttributeEditorViewModel viewModel, featureBinding featureBinding) {
            var association = featureBinding.GetType().GetGenericArguments()[0].Name;

            var definitions = viewModel.featureBindingDefinitions!.GroupBy.Single(e => e.Key.Equals(association));

            viewModel.featureBindings.Add(new FeatureBindingViewModel(definitions) {
                roleType = featureBinding.roleType,
                role = featureBinding.role,
                featureType = featureBinding.featureType,
                featureUID = new FeatureTypeID(featureBinding.featureType!, featureBinding.featureId),
            });
            return viewModel;
        }


        public static explicit operator informationBinding[](S100AttributeEditorViewModel viewmodel) {
            informationBinding[] informationBinding = [];
            if (viewmodel.informationBindings.Any()) {
                foreach (var binding in viewmodel.informationBindings.ToImmutableArray()) {
                    if (binding.roleType is null) continue;

                    var f = binding.informationBindingDefinition!.CreateInstance()!;
                    f.informationType = binding.informationType;
                    f.informationId = binding.informationUID?.UID!;

                    informationBinding = [.. informationBinding, f];
                }
            }
            return informationBinding;
        }

        public static explicit operator featureBinding[](S100AttributeEditorViewModel viewmodel) {
            featureBinding[] featureBindings = [];
            if (viewmodel.featureBindings.Any()) {
                foreach (var binding in viewmodel.featureBindings.ToImmutableArray()) {
                    if (binding.roleType is null) continue;

                    var f = binding.featureBindingDefinition!.CreateInstance()!;
                    f.featureType = binding.featureType;
                    f.featureId = binding.featureUID?.UID!;

                    featureBindings = [.. featureBindings, f];
                }
            }
            return featureBindings;
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

        public object? Instance => this._informationType != default ? this._informationType : this._featureType;

        public Func<string?> Flatten { get; private set; }

        private readonly S100FC.InformationType? _informationType = default;
        private readonly S100FC.FeatureType? _featureType = default;
        private readonly string _uid;
    }
}
