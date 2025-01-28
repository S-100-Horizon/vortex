using S100Framework.DomainModel;
using S100Framework.DomainModel.Bindings;
using S100Framework.DomainModel.S128;
using S100Framework.DomainModel.S128.ComplexAttributes;
using S100Framework.DomainModel.S128.FeatureTypes;
using S100Framework.DomainModel.S128.InformationTypes;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

#nullable enable
namespace S100Framework.WPF.ViewModel.S128
{
    internal static class Preamble {
        public static ImmutableDictionary<string, Func<ViewModelBase>> _creators => ImmutableDictionary.Create<string, Func<ViewModelBase>>().AddRange(new Dictionary<string, Func<ViewModelBase>> { { typeof(DomainModel.S128.InformationTypes.CatalogueSectionHeader).Name, () =>
        {
            return new CatalogueSectionHeaderViewModel();
        } }, { typeof(DomainModel.S128.InformationTypes.ContactDetails).Name, () =>
        {
            return new ContactDetailsViewModel();
        } }, { typeof(DomainModel.S128.InformationTypes.IndicationOfCarriageRequirement).Name, () =>
        {
            return new IndicationOfCarriageRequirementViewModel();
        } }, { typeof(DomainModel.S128.InformationTypes.PriceInformation).Name, () =>
        {
            return new PriceInformationViewModel();
        } }, { typeof(DomainModel.S128.InformationTypes.ProducerInformation).Name, () =>
        {
            return new ProducerInformationViewModel();
        } }, { typeof(DomainModel.S128.InformationTypes.DistributorInformation).Name, () =>
        {
            return new DistributorInformationViewModel();
        } }, { typeof(DomainModel.S128.FeatureTypes.ElectronicProduct).Name, () =>
        {
            return new ElectronicProductViewModel();
        } }, { typeof(DomainModel.S128.FeatureTypes.PhysicalProduct).Name, () =>
        {
            return new PhysicalProductViewModel();
        } }, { typeof(DomainModel.S128.FeatureTypes.S100Service).Name, () =>
        {
            return new S100ServiceViewModel();
        } }, });
    }

    public class Handles : iHandles {
        public static IDictionary<Type, Func<InformationAssociationConnector[]>> AssociationConnectorInformations => new Dictionary<Type, Func<InformationAssociationConnector[]>>
        {
            {
                typeof(ProductPackageViewModel),
                () => [new InformationAssociationConnector<ElectronicProduct>()
                {
                    roleType = roleType.association,
                    role = "elementContainer",
                    Lower = 1,
                    Upper = default,
                    AssociationTypes = ["CatalogueSectionHeader"],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ProductPackageViewModel.elementContainerElectronicProductRefIdViewModel>("ProductPackage"),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<ElectronicProductViewModel.ElectronicProductRefIdViewModel>("ElectronicProduct"),
                }, new InformationAssociationConnector<PhysicalProduct>()
                {
                    roleType = roleType.association,
                    role = "elementContainer",
                    Lower = 1,
                    Upper = default,
                    AssociationTypes = ["CatalogueSectionHeader"],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ProductPackageViewModel.elementContainerPhysicalProductRefIdViewModel>("ProductPackage"),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<PhysicalProductViewModel.PhysicalProductRefIdViewModel>("PhysicalProduct"),
                }, new InformationAssociationConnector<S100Service>()
                {
                    roleType = roleType.association,
                    role = "elementContainer",
                    Lower = 1,
                    Upper = default,
                    AssociationTypes = ["CatalogueSectionHeader"],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ProductPackageViewModel.elementContainerS100ServiceRefIdViewModel>("ProductPackage"),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<S100ServiceViewModel.S100ServiceRefIdViewModel>("S100Service"),
                }

                ]
            },
            {
                typeof(ProductionDetailsViewModel),
                () => [new InformationAssociationConnector<ProducerInformation>()
                {
                    roleType = roleType.association,
                    role = "catalogueHeader",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = ["CatalogueSectionHeader"],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ProductionDetailsViewModel.catalogueHeaderProducerInformationRefIdViewModel>("ProductionDetails"),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<ProducerInformationViewModel.ProducerInformationRefIdViewModel>("ProducerInformation"),
                }, new InformationAssociationConnector<CatalogueSectionHeader>()
                {
                    roleType = roleType.association,
                    role = "theProducer",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = ["ProducerInformation"],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ProductionDetailsViewModel.theProducerCatalogueSectionHeaderRefIdViewModel>("ProductionDetails"),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<CatalogueSectionHeaderViewModel.CatalogueSectionHeaderRefIdViewModel>("CatalogueSectionHeader"),
                }

                ]
            },
            {
                typeof(ProducerContactViewModel),
                () => [new InformationAssociationConnector<ProducerInformation>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = ["ContactDetails"],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ProducerContactViewModel.theContactDetailsProducerInformationRefIdViewModel>("ProducerContact"),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<ProducerInformationViewModel.ProducerInformationRefIdViewModel>("ProducerInformation"),
                }, new InformationAssociationConnector<ContactDetails>()
                {
                    roleType = roleType.association,
                    role = "theProducer",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = ["ProducerInformation"],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ProducerContactViewModel.theProducerContactDetailsRefIdViewModel>("ProducerContact"),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<ContactDetailsViewModel.ContactDetailsRefIdViewModel>("ContactDetails"),
                }

                ]
            },
            {
                typeof(PriceOfNauticalProductViewModel),
                () => [new InformationAssociationConnector<PriceInformation>()
                {
                    roleType = roleType.association,
                    role = "theCatalogueOfNauticalProduct",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = ["CatalogueSectionHeader"],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PriceOfNauticalProductViewModel.theCatalogueOfNauticalProductPriceInformationRefIdViewModel>("PriceOfNauticalProduct"),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<PriceInformationViewModel.PriceInformationRefIdViewModel>("PriceInformation"),
                }, new InformationAssociationConnector<CatalogueSectionHeader>()
                {
                    roleType = roleType.association,
                    role = "thePriceInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = ["PriceInformation"],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PriceOfNauticalProductViewModel.thePriceInformationCatalogueSectionHeaderRefIdViewModel>("PriceOfNauticalProduct"),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<CatalogueSectionHeaderViewModel.CatalogueSectionHeaderRefIdViewModel>("CatalogueSectionHeader"),
                }

                ]
            },
            {
                typeof(PriceOfElementViewModel),
                () => [new InformationAssociationConnector<ElectronicProduct>()
                {
                    roleType = roleType.association,
                    role = "thePriceInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = ["PriceInformation"],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PriceOfElementViewModel.thePriceInformationElectronicProductRefIdViewModel>("PriceOfElement"),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<ElectronicProductViewModel.ElectronicProductRefIdViewModel>("ElectronicProduct"),
                }, new InformationAssociationConnector<PhysicalProduct>()
                {
                    roleType = roleType.association,
                    role = "thePriceInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = ["PriceInformation"],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PriceOfElementViewModel.thePriceInformationPhysicalProductRefIdViewModel>("PriceOfElement"),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<PhysicalProductViewModel.PhysicalProductRefIdViewModel>("PhysicalProduct"),
                }, new InformationAssociationConnector<S100Service>()
                {
                    roleType = roleType.association,
                    role = "thePriceInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = ["PriceInformation"],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PriceOfElementViewModel.thePriceInformationS100ServiceRefIdViewModel>("PriceOfElement"),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<S100ServiceViewModel.S100ServiceRefIdViewModel>("S100Service"),
                }

                ]
            },
            {
                typeof(DistributorContactViewModel),
                () => [new InformationAssociationConnector<DistributorInformation>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = ["ContactDetails"],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<DistributorContactViewModel.theContactDetailsDistributorInformationRefIdViewModel>("DistributorContact"),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<DistributorInformationViewModel.DistributorInformationRefIdViewModel>("DistributorInformation"),
                }, new InformationAssociationConnector<ContactDetails>()
                {
                    roleType = roleType.association,
                    role = "theDistributor",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = ["DistributorInformation"],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<DistributorContactViewModel.theDistributorContactDetailsRefIdViewModel>("DistributorContact"),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<ContactDetailsViewModel.ContactDetailsRefIdViewModel>("ContactDetails"),
                }

                ]
            },
            {
                typeof(DistributionDetailsViewModel),
                () => [new InformationAssociationConnector<DistributorInformation>()
                {
                    roleType = roleType.association,
                    role = "catalogueHeader",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = ["CatalogueSectionHeader"],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<DistributionDetailsViewModel.catalogueHeaderDistributorInformationRefIdViewModel>("DistributionDetails"),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<DistributorInformationViewModel.DistributorInformationRefIdViewModel>("DistributorInformation"),
                }, new InformationAssociationConnector<CatalogueSectionHeader>()
                {
                    roleType = roleType.association,
                    role = "theDistributor",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = ["DistributorInformation"],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<DistributionDetailsViewModel.theDistributorCatalogueSectionHeaderRefIdViewModel>("DistributionDetails"),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<CatalogueSectionHeaderViewModel.CatalogueSectionHeaderRefIdViewModel>("CatalogueSectionHeader"),
                }

                ]
            },
            {
                typeof(CarriageRequirementViewModel),
                () => [new InformationAssociationConnector<ElectronicProduct>()
                {
                    roleType = roleType.association,
                    role = "theRequirement",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = ["IndicationOfCarriageRequirement"],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<CarriageRequirementViewModel.theRequirementElectronicProductRefIdViewModel>("CarriageRequirement"),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<ElectronicProductViewModel.ElectronicProductRefIdViewModel>("ElectronicProduct"),
                }, new InformationAssociationConnector<PhysicalProduct>()
                {
                    roleType = roleType.association,
                    role = "theRequirement",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = ["IndicationOfCarriageRequirement"],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<CarriageRequirementViewModel.theRequirementPhysicalProductRefIdViewModel>("CarriageRequirement"),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<PhysicalProductViewModel.PhysicalProductRefIdViewModel>("PhysicalProduct"),
                }, new InformationAssociationConnector<S100Service>()
                {
                    roleType = roleType.association,
                    role = "theRequirement",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = ["IndicationOfCarriageRequirement"],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<CarriageRequirementViewModel.theRequirementS100ServiceRefIdViewModel>("CarriageRequirement"),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<S100ServiceViewModel.S100ServiceRefIdViewModel>("S100Service"),
                }

                ]
            },
        };
        public static IDictionary<Type, Func<FeatureAssociationConnector[]>> AssociationConnectorFeatures => new Dictionary<Type, Func<FeatureAssociationConnector[]>>
        {
            {
                typeof(CorrelatedViewModel),
                () => [new FeatureAssociationConnector<ElectronicProduct>()
                {
                    roleType = roleType.association,
                    role = "main",
                    Lower = 1,
                    Upper = 1,
                    AssociationTypes = ["ElectronicProduct", "PhysicalProduct"],
                    CreateForeignFeatureBinding = () => new SingleFeatureBindingViewModel<CorrelatedViewModel.mainElectronicProductRefIdViewModel>("Correlated"),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<ElectronicProductViewModel.ElectronicProductRefIdViewModel>("ElectronicProduct"),
                }, new FeatureAssociationConnector<PhysicalProduct>()
                {
                    roleType = roleType.association,
                    role = "main",
                    Lower = 1,
                    Upper = 1,
                    AssociationTypes = ["ElectronicProduct", "PhysicalProduct"],
                    CreateForeignFeatureBinding = () => new SingleFeatureBindingViewModel<CorrelatedViewModel.mainPhysicalProductRefIdViewModel>("Correlated"),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<PhysicalProductViewModel.PhysicalProductRefIdViewModel>("PhysicalProduct"),
                }

                ]
            },
            {
                typeof(ProductMappingViewModel),
                () => [new FeatureAssociationConnector<ElectronicProduct>()
                {
                    roleType = roleType.association,
                    role = "theReference",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = ["ElectronicProduct", "PhysicalProduct", "S100Service"],
                    CreateForeignFeatureBinding = () => new MultiFeatureBindingViewModel<ProductMappingViewModel.theReferenceElectronicProductRefIdViewModel>("ProductMapping"),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<ElectronicProductViewModel.ElectronicProductRefIdViewModel>("ElectronicProduct"),
                }, new FeatureAssociationConnector<PhysicalProduct>()
                {
                    roleType = roleType.association,
                    role = "theReference",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = ["ElectronicProduct", "PhysicalProduct", "S100Service"],
                    CreateForeignFeatureBinding = () => new MultiFeatureBindingViewModel<ProductMappingViewModel.theReferencePhysicalProductRefIdViewModel>("ProductMapping"),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<PhysicalProductViewModel.PhysicalProductRefIdViewModel>("PhysicalProduct"),
                }, new FeatureAssociationConnector<S100Service>()
                {
                    roleType = roleType.association,
                    role = "theReference",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = ["ElectronicProduct", "PhysicalProduct", "S100Service"],
                    CreateForeignFeatureBinding = () => new MultiFeatureBindingViewModel<ProductMappingViewModel.theReferenceS100ServiceRefIdViewModel>("ProductMapping"),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<S100ServiceViewModel.S100ServiceRefIdViewModel>("S100Service"),
                }

                ]
            },
        };
    }

    [CategoryOrder("contactAddress", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class contactAddressViewModel : ViewModelBase {
        private String _administrativeDivision = string.Empty;
        [Category("contactAddress")]
        public String administrativeDivision {
            get {
                return _administrativeDivision;
            }

            set {
                SetValue(ref _administrativeDivision, value);
            }
        }

        private String _cityName = string.Empty;
        [Category("contactAddress")]
        public String cityName {
            get {
                return _cityName;
            }

            set {
                SetValue(ref _cityName, value);
            }
        }

        private String _countryName = string.Empty;
        [Category("contactAddress")]
        public String countryName {
            get {
                return _countryName;
            }

            set {
                SetValue(ref _countryName, value);
            }
        }

        [Category("contactAddress")]
        public ObservableCollection<String> deliveryPoint { get; set; } = new();

        private String _postalCode = string.Empty;
        [Category("contactAddress")]
        public String postalCode {
            get {
                return _postalCode;
            }

            set {
                SetValue(ref _postalCode, value);
            }
        }

        public void Load(DomainModel.S128.ComplexAttributes.contactAddress instance) {
            administrativeDivision = instance.administrativeDivision;
            cityName = instance.cityName;
            countryName = instance.countryName;
            deliveryPoint.Clear();
            if (instance.deliveryPoint is not null)
                foreach (var e in instance.deliveryPoint)
                    deliveryPoint.Add(e);
            postalCode = instance.postalCode;
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.contactAddress
            {
                administrativeDivision = this.administrativeDivision,
                cityName = this.cityName,
                countryName = this.countryName,
                deliveryPoint = this.deliveryPoint.ToList(),
                postalCode = this.postalCode,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.contactAddress Model => new()
        {
            administrativeDivision = this._administrativeDivision,
            cityName = this._cityName,
            countryName = this._countryName,
            deliveryPoint = this.deliveryPoint.ToList(),
            postalCode = this._postalCode,
        };

        public contactAddressViewModel() : base() {
            deliveryPoint.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(deliveryPoint));
            };
        }

        public override string? ToString() => $"Contact Address";
    }

    [CategoryOrder("customPaperSize", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class customPaperSizeViewModel : ViewModelBase {
        private Int32 _x;
        [Category("customPaperSize")]
        public Int32 x {
            get {
                return _x;
            }

            set {
                SetValue(ref _x, value);
            }
        }

        private Int32 _y;
        [Category("customPaperSize")]
        public Int32 y {
            get {
                return _y;
            }

            set {
                SetValue(ref _y, value);
            }
        }

        public void Load(DomainModel.S128.ComplexAttributes.customPaperSize instance) {
            x = instance.x;
            y = instance.y;
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.customPaperSize
            {
                x = this.x,
                y = this.y,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.customPaperSize Model => new()
        {
            x = this._x,
            y = this._y,
        };

        public customPaperSizeViewModel() : base() {
        }

        public override string? ToString() => $"Custom Paper Size";
    }

    [CategoryOrder("defaultLocale", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class defaultLocaleViewModel : ViewModelBase {
        private String _characterEncoding = string.Empty;
        [Category("defaultLocale")]
        public String characterEncoding {
            get {
                return _characterEncoding;
            }

            set {
                SetValue(ref _characterEncoding, value);
            }
        }

        private String _countryName = string.Empty;
        [Category("defaultLocale")]
        public String countryName {
            get {
                return _countryName;
            }

            set {
                SetValue(ref _countryName, value);
            }
        }

        private String _language = string.Empty;
        [Category("defaultLocale")]
        public String language {
            get {
                return _language;
            }

            set {
                SetValue(ref _language, value);
            }
        }

        public void Load(DomainModel.S128.ComplexAttributes.defaultLocale instance) {
            characterEncoding = instance.characterEncoding;
            countryName = instance.countryName;
            language = instance.language;
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.defaultLocale
            {
                characterEncoding = this.characterEncoding,
                countryName = this.countryName,
                language = this.language,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.defaultLocale Model => new()
        {
            characterEncoding = this._characterEncoding,
            countryName = this._countryName,
            language = this._language,
        };

        public defaultLocaleViewModel() : base() {
        }

        public override string? ToString() => $"Default Locale";
    }

    [CategoryOrder("featureName", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class featureNameViewModel : ViewModelBase {
        private String _language = string.Empty;
        [Category("featureName")]
        public String language {
            get {
                return _language;
            }

            set {
                SetValue(ref _language, value);
            }
        }

        private String _name = string.Empty;
        [Category("featureName")]
        public String name {
            get {
                return _name;
            }

            set {
                SetValue(ref _name, value);
            }
        }

        private nameUsage? _nameUsage = default;
        [Category("featureName")]
        public nameUsage? nameUsage {
            get {
                return _nameUsage;
            }

            set {
                SetValue(ref _nameUsage, value);
            }
        }

        public void Load(DomainModel.S128.ComplexAttributes.featureName instance) {
            language = instance.language;
            name = instance.name;
            nameUsage = instance.nameUsage;
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.featureName
            {
                language = this.language,
                name = this.name,
                nameUsage = this.nameUsage,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.featureName Model => new()
        {
            language = this._language,
            name = this._name,
            nameUsage = this._nameUsage,
        };

        public featureNameViewModel() : base() {
        }

        public override string? ToString() => $"Feature Name";
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("information", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class informationViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        private String _fileLocator = string.Empty;
        [Category("information")]
        public String fileLocator {
            get {
                return _fileLocator;
            }

            set {
                SetValue(ref _fileLocator, value);
            }
        }

        private String _fileReference = string.Empty;
        [Category("information")]
        public String fileReference {
            get {
                return _fileReference;
            }

            set {
                SetValue(ref _fileReference, value);
            }
        }

        private String _headline = string.Empty;
        [Category("information")]
        public String headline {
            get {
                return _headline;
            }

            set {
                SetValue(ref _headline, value);
            }
        }

        private String _language = string.Empty;
        [Category("information")]
        public String language {
            get {
                return _language;
            }

            set {
                SetValue(ref _language, value);
            }
        }

        [Category("information")]
        public ObservableCollection<String> text { get; set; } = new();

        public void Load(DomainModel.S128.ComplexAttributes.information instance) {
            fileLocator = instance.fileLocator;
            fileReference = instance.fileReference;
            headline = instance.headline;
            language = instance.language;
            text.Clear();
            if (instance.text is not null)
                foreach (var e in instance.text)
                    text.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.information
            {
                fileLocator = this.fileLocator,
                fileReference = this.fileReference,
                headline = this.headline,
                language = this.language,
                text = this.text.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.information Model => new()
        {
            fileLocator = this._fileLocator,
            fileReference = this._fileReference,
            headline = this._headline,
            language = this._language,
            text = this.text.ToList(),
        };

        public informationViewModel() : base() {
            text.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(text));
            };
        }

        public override string? ToString() => $"Information";
    }

    [CategoryOrder("onlineResource", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class onlineResourceViewModel : ViewModelBase {
        private String _applicationProfile = string.Empty;
        [Category("onlineResource")]
        public String applicationProfile {
            get {
                return _applicationProfile;
            }

            set {
                SetValue(ref _applicationProfile, value);
            }
        }

        private String _linkage = string.Empty;
        [Category("onlineResource")]
        public String linkage {
            get {
                return _linkage;
            }

            set {
                SetValue(ref _linkage, value);
            }
        }

        private String _nameOfResource = string.Empty;
        [Category("onlineResource")]
        public String nameOfResource {
            get {
                return _nameOfResource;
            }

            set {
                SetValue(ref _nameOfResource, value);
            }
        }

        private String _onlineDescription = string.Empty;
        [Category("onlineResource")]
        public String onlineDescription {
            get {
                return _onlineDescription;
            }

            set {
                SetValue(ref _onlineDescription, value);
            }
        }

        private String _protocol = string.Empty;
        [Category("onlineResource")]
        public String protocol {
            get {
                return _protocol;
            }

            set {
                SetValue(ref _protocol, value);
            }
        }

        private String _protocolRequest = string.Empty;
        [Category("onlineResource")]
        public String protocolRequest {
            get {
                return _protocolRequest;
            }

            set {
                SetValue(ref _protocolRequest, value);
            }
        }

        public void Load(DomainModel.S128.ComplexAttributes.onlineResource instance) {
            applicationProfile = instance.applicationProfile;
            linkage = instance.linkage;
            nameOfResource = instance.nameOfResource;
            onlineDescription = instance.onlineDescription;
            protocol = instance.protocol;
            protocolRequest = instance.protocolRequest;
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.onlineResource
            {
                applicationProfile = this.applicationProfile,
                linkage = this.linkage,
                nameOfResource = this.nameOfResource,
                onlineDescription = this.onlineDescription,
                protocol = this.protocol,
                protocolRequest = this.protocolRequest,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.onlineResource Model => new()
        {
            applicationProfile = this._applicationProfile,
            linkage = this._linkage,
            nameOfResource = this._nameOfResource,
            onlineDescription = this._onlineDescription,
            protocol = this._protocol,
            protocolRequest = this._protocolRequest,
        };

        public onlineResourceViewModel() : base() {
        }

        public override string? ToString() => $"Online Resource";
    }

    [CategoryOrder("periodicDateRange", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class periodicDateRangeViewModel : ViewModelBase {
        private DateOnly _dateEnd;
        [Category("periodicDateRange")]
        public DateOnly dateEnd {
            get {
                return _dateEnd;
            }

            set {
                SetValue(ref _dateEnd, value);
            }
        }

        private DateOnly _dateStart;
        [Category("periodicDateRange")]
        public DateOnly dateStart {
            get {
                return _dateStart;
            }

            set {
                SetValue(ref _dateStart, value);
            }
        }

        public void Load(DomainModel.S128.ComplexAttributes.periodicDateRange instance) {
            dateEnd = instance.dateEnd;
            dateStart = instance.dateStart;
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.periodicDateRange
            {
                dateEnd = this.dateEnd,
                dateStart = this.dateStart,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.periodicDateRange Model => new()
        {
            dateEnd = this._dateEnd,
            dateStart = this._dateStart,
        };

        public periodicDateRangeViewModel() : base() {
        }

        public override string? ToString() => $"Periodic Date Range";
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("pricing", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class pricingViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        private String _contractPeriod = string.Empty;
        [Category("pricing")]
        public String contractPeriod {
            get {
                return _contractPeriod;
            }

            set {
                SetValue(ref _contractPeriod, value);
            }
        }

        private String _currency = string.Empty;
        [Category("pricing")]
        public String currency {
            get {
                return _currency;
            }

            set {
                SetValue(ref _currency, value);
            }
        }

        private Decimal _price;
        [Category("pricing")]
        public Decimal price {
            get {
                return _price;
            }

            set {
                SetValue(ref _price, value);
            }
        }

        public void Load(DomainModel.S128.ComplexAttributes.pricing instance) {
            contractPeriod = instance.contractPeriod;
            currency = instance.currency;
            price = instance.price;
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.pricing
            {
                contractPeriod = this.contractPeriod,
                currency = this.currency,
                price = this.price,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.pricing Model => new()
        {
            contractPeriod = this._contractPeriod,
            currency = this._currency,
            price = this._price,
        };

        public pricingViewModel() : base() {
        }

        public override string? ToString() => $"Pricing";
    }

    [CategoryOrder("printSize", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class printSizeViewModel : ViewModelBase {
        private iso216? _iso216 = default;
        [Category("printSize")]
        public iso216? iso216 {
            get {
                return _iso216;
            }

            set {
                SetValue(ref _iso216, value);
            }
        }

        private customPaperSizeViewModel? _customPaperSize;
        [Category("printSize")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public customPaperSizeViewModel? customPaperSize {
            get {
                return _customPaperSize;
            }

            set {
                SetValue(ref _customPaperSize, value);
            }
        }

        public void Load(DomainModel.S128.ComplexAttributes.printSize instance) {
            iso216 = instance.iso216;
            customPaperSize = new();
            if (instance.customPaperSize != null) {
                customPaperSize = new();
                customPaperSize.Load(instance.customPaperSize);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.printSize
            {
                iso216 = this.iso216,
                customPaperSize = this.customPaperSize?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.printSize Model => new()
        {
            iso216 = this._iso216,
            customPaperSize = this._customPaperSize?.Model,
        };

        public printSizeViewModel() : base() {
        }

        public override string? ToString() => $"Print Size";
    }

    [CategoryOrder("productSpecification", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class productSpecificationViewModel : ViewModelBase {
        private DateTime _date;
        [Category("productSpecification")]
        public DateTime date {
            get {
                return _date;
            }

            set {
                SetValue(ref _date, value);
            }
        }

        private String _ISSN = string.Empty;
        [Category("productSpecification")]
        public String ISSN {
            get {
                return _ISSN;
            }

            set {
                SetValue(ref _ISSN, value);
            }
        }

        private String _name = string.Empty;
        [Category("productSpecification")]
        public String name {
            get {
                return _name;
            }

            set {
                SetValue(ref _name, value);
            }
        }

        private String _version = string.Empty;
        [Category("productSpecification")]
        public String version {
            get {
                return _version;
            }

            set {
                SetValue(ref _version, value);
            }
        }

        public void Load(DomainModel.S128.ComplexAttributes.productSpecification instance) {
            date = instance.date;
            ISSN = instance.ISSN;
            name = instance.name;
            version = instance.version;
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.productSpecification
            {
                date = this.date,
                ISSN = this.ISSN,
                name = this.name,
                version = this.version,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.productSpecification Model => new()
        {
            date = this._date,
            ISSN = this._ISSN,
            name = this._name,
            version = this._version,
        };

        public productSpecificationViewModel() : base() {
        }

        public override string? ToString() => $"Product Specification";
    }

    [CategoryOrder("supportFileSpecification", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class supportFileSpecificationViewModel : ViewModelBase {
        private DateTime _date;
        [Category("supportFileSpecification")]
        public DateTime date {
            get {
                return _date;
            }

            set {
                SetValue(ref _date, value);
            }
        }

        private String _name = string.Empty;
        [Category("supportFileSpecification")]
        public String name {
            get {
                return _name;
            }

            set {
                SetValue(ref _name, value);
            }
        }

        private String _version = string.Empty;
        [Category("supportFileSpecification")]
        public String version {
            get {
                return _version;
            }

            set {
                SetValue(ref _version, value);
            }
        }

        public void Load(DomainModel.S128.ComplexAttributes.supportFileSpecification instance) {
            date = instance.date;
            name = instance.name;
            version = instance.version;
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.supportFileSpecification
            {
                date = this.date,
                name = this.name,
                version = this.version,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.supportFileSpecification Model => new()
        {
            date = this._date,
            name = this._name,
            version = this._version,
        };

        public supportFileSpecificationViewModel() : base() {
        }

        public override string? ToString() => $"S100_Support File Specification";
    }

    [CategoryOrder("serviceSpecification", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class serviceSpecificationViewModel : ViewModelBase {
        private DateTime _date;
        [Category("serviceSpecification")]
        public DateTime date {
            get {
                return _date;
            }

            set {
                SetValue(ref _date, value);
            }
        }

        private String _name = string.Empty;
        [Category("serviceSpecification")]
        public String name {
            get {
                return _name;
            }

            set {
                SetValue(ref _name, value);
            }
        }

        private String _version = string.Empty;
        [Category("serviceSpecification")]
        public String version {
            get {
                return _version;
            }

            set {
                SetValue(ref _version, value);
            }
        }

        public void Load(DomainModel.S128.ComplexAttributes.serviceSpecification instance) {
            date = instance.date;
            name = instance.name;
            version = instance.version;
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.serviceSpecification
            {
                date = this.date,
                name = this.name,
                version = this.version,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.serviceSpecification Model => new()
        {
            date = this._date,
            name = this._name,
            version = this._version,
        };

        public serviceSpecificationViewModel() : base() {
        }

        public override string? ToString() => $"Service Specification";
    }

    [CategoryOrder("sourceIndication", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class sourceIndicationViewModel : ViewModelBase {
        private categoryOfAuthority? _categoryOfAuthority = default;
        [Category("sourceIndication")]
        public categoryOfAuthority? categoryOfAuthority {
            get {
                return _categoryOfAuthority;
            }

            set {
                SetValue(ref _categoryOfAuthority, value);
            }
        }

        private String _countryName = string.Empty;
        [Category("sourceIndication")]
        public String countryName {
            get {
                return _countryName;
            }

            set {
                SetValue(ref _countryName, value);
            }
        }

        private DateTime? _reportedDate = default;
        [Category("sourceIndication")]
        public DateTime? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        private String _source = string.Empty;
        [Category("sourceIndication")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("sourceIndication")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        [Category("sourceIndication")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        public void Load(DomainModel.S128.ComplexAttributes.sourceIndication instance) {
            categoryOfAuthority = instance.categoryOfAuthority;
            countryName = instance.countryName;
            reportedDate = instance.reportedDate;
            source = instance.source;
            sourceType = instance.sourceType;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.sourceIndication
            {
                categoryOfAuthority = this.categoryOfAuthority,
                countryName = this.countryName,
                reportedDate = this.reportedDate,
                source = this.source,
                sourceType = this.sourceType,
                featureName = this.featureName.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.sourceIndication Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            countryName = this._countryName,
            reportedDate = this._reportedDate,
            source = this._source,
            sourceType = this._sourceType,
            featureName = this.featureName.ToList(),
        };

        public sourceIndicationViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"Source Indication";
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("telecommunications", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class telecommunicationsViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        private String _contactInstructions = string.Empty;
        [Category("telecommunications")]
        public String contactInstructions {
            get {
                return _contactInstructions;
            }

            set {
                SetValue(ref _contactInstructions, value);
            }
        }

        private String _telecommunicationIdentifier = string.Empty;
        [Category("telecommunications")]
        public String telecommunicationIdentifier {
            get {
                return _telecommunicationIdentifier;
            }

            set {
                SetValue(ref _telecommunicationIdentifier, value);
            }
        }

        [Category("telecommunications")]
        public ObservableCollection<telecommunicationService> telecommunicationService { get; set; } = new();

        public void Load(DomainModel.S128.ComplexAttributes.telecommunications instance) {
            contactInstructions = instance.contactInstructions;
            telecommunicationIdentifier = instance.telecommunicationIdentifier;
            telecommunicationService.Clear();
            if (instance.telecommunicationService is not null)
                foreach (var e in instance.telecommunicationService)
                    telecommunicationService.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.telecommunications
            {
                contactInstructions = this.contactInstructions,
                telecommunicationIdentifier = this.telecommunicationIdentifier,
                telecommunicationService = this.telecommunicationService.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.telecommunications Model => new()
        {
            contactInstructions = this._contactInstructions,
            telecommunicationIdentifier = this._telecommunicationIdentifier,
            telecommunicationService = this.telecommunicationService.ToList(),
        };

        public telecommunicationsViewModel() : base() {
            telecommunicationService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(telecommunicationService));
            };
        }

        public override string? ToString() => $"Telecommunications";
    }

    [CategoryOrder("timeIntervalOfCycle", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class timeIntervalOfCycleViewModel : ViewModelBase {
        [Category("timeIntervalOfCycle")]
        public ObservableCollection<typeOfTimeIntervalUnit> typeOfTimeIntervalUnit { get; set; } = new();

        private Int32 _valueOfTime;
        [Category("timeIntervalOfCycle")]
        public Int32 valueOfTime {
            get {
                return _valueOfTime;
            }

            set {
                SetValue(ref _valueOfTime, value);
            }
        }

        public void Load(DomainModel.S128.ComplexAttributes.timeIntervalOfCycle instance) {
            typeOfTimeIntervalUnit.Clear();
            if (instance.typeOfTimeIntervalUnit is not null)
                foreach (var e in instance.typeOfTimeIntervalUnit)
                    typeOfTimeIntervalUnit.Add(e);
            valueOfTime = instance.valueOfTime;
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.timeIntervalOfCycle
            {
                typeOfTimeIntervalUnit = this.typeOfTimeIntervalUnit.ToList(),
                valueOfTime = this.valueOfTime,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.timeIntervalOfCycle Model => new()
        {
            typeOfTimeIntervalUnit = this.typeOfTimeIntervalUnit.ToList(),
            valueOfTime = this._valueOfTime,
        };

        public timeIntervalOfCycleViewModel() : base() {
            typeOfTimeIntervalUnit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(typeOfTimeIntervalUnit));
            };
        }

        public override string? ToString() => $"Time Interval of Cycle";
    }

    [CategoryOrder("weekOfYear", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class weekOfYearViewModel : ViewModelBase {
        private Int32 _weekNumber;
        [Category("weekOfYear")]
        public Int32 weekNumber {
            get {
                return _weekNumber;
            }

            set {
                SetValue(ref _weekNumber, value);
            }
        }

        private Int32 _yearNumber;
        [Category("weekOfYear")]
        public Int32 yearNumber {
            get {
                return _yearNumber;
            }

            set {
                SetValue(ref _yearNumber, value);
            }
        }

        public void Load(DomainModel.S128.ComplexAttributes.weekOfYear instance) {
            weekNumber = instance.weekNumber;
            yearNumber = instance.yearNumber;
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.weekOfYear
            {
                weekNumber = this.weekNumber,
                yearNumber = this.yearNumber,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.weekOfYear Model => new()
        {
            weekNumber = this._weekNumber,
            yearNumber = this._yearNumber,
        };

        public weekOfYearViewModel() : base() {
        }

        public override string? ToString() => $"Week Of Year";
    }

    [CategoryOrder("issuanceCycle", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class issuanceCycleViewModel : ViewModelBase {
        private periodicDateRangeViewModel? _periodicDateRange;
        [Category("issuanceCycle")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public periodicDateRangeViewModel? periodicDateRange {
            get {
                return _periodicDateRange;
            }

            set {
                SetValue(ref _periodicDateRange, value);
            }
        }

        private timeIntervalOfCycleViewModel? _timeIntervalOfCycle;
        [Category("issuanceCycle")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public timeIntervalOfCycleViewModel? timeIntervalOfCycle {
            get {
                return _timeIntervalOfCycle;
            }

            set {
                SetValue(ref _timeIntervalOfCycle, value);
            }
        }

        public void Load(DomainModel.S128.ComplexAttributes.issuanceCycle instance) {
            periodicDateRange = new();
            if (instance.periodicDateRange != null) {
                periodicDateRange = new();
                periodicDateRange.Load(instance.periodicDateRange);
            }

            timeIntervalOfCycle = new();
            if (instance.timeIntervalOfCycle != null) {
                timeIntervalOfCycle = new();
                timeIntervalOfCycle.Load(instance.timeIntervalOfCycle);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.issuanceCycle
            {
                periodicDateRange = this.periodicDateRange?.Model,
                timeIntervalOfCycle = this.timeIntervalOfCycle?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.issuanceCycle Model => new()
        {
            periodicDateRange = this._periodicDateRange?.Model,
            timeIntervalOfCycle = this._timeIntervalOfCycle?.Model,
        };

        public issuanceCycleViewModel() : base() {
        }

        public override string? ToString() => $"Issuance Cycle";
    }

    [CategoryOrder("printInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class printInformationViewModel : ViewModelBase {
        private String _printAgency = string.Empty;
        [Category("printInformation")]
        public String printAgency {
            get {
                return _printAgency;
            }

            set {
                SetValue(ref _printAgency, value);
            }
        }

        private String _printNation = string.Empty;
        [Category("printInformation")]
        public String printNation {
            get {
                return _printNation;
            }

            set {
                SetValue(ref _printNation, value);
            }
        }

        private String _rePrintEdition = string.Empty;
        [Category("printInformation")]
        public String rePrintEdition {
            get {
                return _rePrintEdition;
            }

            set {
                SetValue(ref _rePrintEdition, value);
            }
        }

        private String _rePrintNation = string.Empty;
        [Category("printInformation")]
        public String rePrintNation {
            get {
                return _rePrintNation;
            }

            set {
                SetValue(ref _rePrintNation, value);
            }
        }

        private printSizeViewModel _printSize;
        [Category("printInformation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public printSizeViewModel printSize {
            get {
                return _printSize;
            }

            set {
                SetValue(ref _printSize, value);
            }
        }

        public void Load(DomainModel.S128.ComplexAttributes.printInformation instance) {
            printAgency = instance.printAgency;
            printNation = instance.printNation;
            rePrintEdition = instance.rePrintEdition;
            rePrintNation = instance.rePrintNation;
            printSize = new();
            if (instance.printSize != null) {
                printSize = new();
                printSize.Load(instance.printSize);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.printInformation
            {
                printAgency = this.printAgency,
                printNation = this.printNation,
                rePrintEdition = this.rePrintEdition,
                rePrintNation = this.rePrintNation,
                printSize = this.printSize?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.printInformation Model => new()
        {
            printAgency = this._printAgency,
            printNation = this._printNation,
            rePrintEdition = this._rePrintEdition,
            rePrintNation = this._rePrintNation,
            printSize = this._printSize?.Model,
        };

        public printInformationViewModel() : base() {
        }

        public override string? ToString() => $"Print Information";
    }

    [CategoryOrder("supportFile", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class supportFileViewModel : ViewModelBase {
        private String _comment = string.Empty;
        [Category("supportFile")]
        public String comment {
            get {
                return _comment;
            }

            set {
                SetValue(ref _comment, value);
            }
        }

        private digitalSignatureReference _digitalSignatureReference;
        [Category("supportFile")]
        public digitalSignatureReference digitalSignatureReference {
            get {
                return _digitalSignatureReference;
            }

            set {
                SetValue(ref _digitalSignatureReference, value);
            }
        }

        private String _digitalSignatureValue = string.Empty;
        [Category("supportFile")]
        public String digitalSignatureValue {
            get {
                return _digitalSignatureValue;
            }

            set {
                SetValue(ref _digitalSignatureValue, value);
            }
        }

        private Int32? _editionNumber = default;
        [Category("supportFile")]
        public Int32? editionNumber {
            get {
                return _editionNumber;
            }

            set {
                SetValue(ref _editionNumber, value);
            }
        }

        private String _fileLocator = string.Empty;
        [Category("supportFile")]
        public String fileLocator {
            get {
                return _fileLocator;
            }

            set {
                SetValue(ref _fileLocator, value);
            }
        }

        private String _fileName = string.Empty;
        [Category("supportFile")]
        public String fileName {
            get {
                return _fileName;
            }

            set {
                SetValue(ref _fileName, value);
            }
        }

        private DateTime? _issueDate = default;
        [Category("supportFile")]
        public DateTime? issueDate {
            get {
                return _issueDate;
            }

            set {
                SetValue(ref _issueDate, value);
            }
        }

        private String _otherDataTypeDescription = string.Empty;
        [Category("supportFile")]
        public String otherDataTypeDescription {
            get {
                return _otherDataTypeDescription;
            }

            set {
                SetValue(ref _otherDataTypeDescription, value);
            }
        }

        private supportFileFormat _supportFileFormat;
        [Category("supportFile")]
        public supportFileFormat supportFileFormat {
            get {
                return _supportFileFormat;
            }

            set {
                SetValue(ref _supportFileFormat, value);
            }
        }

        private supportFilePurpose _supportFilePurpose;
        [Category("supportFile")]
        public supportFilePurpose supportFilePurpose {
            get {
                return _supportFilePurpose;
            }

            set {
                SetValue(ref _supportFilePurpose, value);
            }
        }

        private defaultLocaleViewModel _defaultLocale;
        [Category("supportFile")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public defaultLocaleViewModel defaultLocale {
            get {
                return _defaultLocale;
            }

            set {
                SetValue(ref _defaultLocale, value);
            }
        }

        private supportFileSpecificationViewModel _supportFileSpecification;
        [Category("supportFile")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public supportFileSpecificationViewModel supportFileSpecification {
            get {
                return _supportFileSpecification;
            }

            set {
                SetValue(ref _supportFileSpecification, value);
            }
        }

        public void Load(DomainModel.S128.ComplexAttributes.supportFile instance) {
            comment = instance.comment;
            digitalSignatureReference = instance.digitalSignatureReference;
            digitalSignatureValue = instance.digitalSignatureValue;
            editionNumber = instance.editionNumber;
            fileLocator = instance.fileLocator;
            fileName = instance.fileName;
            issueDate = instance.issueDate;
            otherDataTypeDescription = instance.otherDataTypeDescription;
            supportFileFormat = instance.supportFileFormat;
            supportFilePurpose = instance.supportFilePurpose;
            defaultLocale = new();
            if (instance.defaultLocale != null) {
                defaultLocale = new();
                defaultLocale.Load(instance.defaultLocale);
            }

            supportFileSpecification = new();
            if (instance.supportFileSpecification != null) {
                supportFileSpecification = new();
                supportFileSpecification.Load(instance.supportFileSpecification);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.supportFile
            {
                comment = this.comment,
                digitalSignatureReference = this.digitalSignatureReference,
                digitalSignatureValue = this.digitalSignatureValue,
                editionNumber = this.editionNumber,
                fileLocator = this.fileLocator,
                fileName = this.fileName,
                issueDate = this.issueDate,
                otherDataTypeDescription = this.otherDataTypeDescription,
                supportFileFormat = this.supportFileFormat,
                supportFilePurpose = this.supportFilePurpose,
                defaultLocale = this.defaultLocale?.Model,
                supportFileSpecification = this.supportFileSpecification?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.supportFile Model => new()
        {
            comment = this._comment,
            digitalSignatureReference = this._digitalSignatureReference,
            digitalSignatureValue = this._digitalSignatureValue,
            editionNumber = this._editionNumber,
            fileLocator = this._fileLocator,
            fileName = this._fileName,
            issueDate = this._issueDate,
            otherDataTypeDescription = this._otherDataTypeDescription,
            supportFileFormat = this._supportFileFormat,
            supportFilePurpose = this._supportFilePurpose,
            defaultLocale = this._defaultLocale?.Model,
            supportFileSpecification = this._supportFileSpecification?.Model,
        };

        public supportFileViewModel() : base() {
        }

        public override string? ToString() => $"S100_Support File";
    }

    [CategoryOrder("timeIntervalOfProduct", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class timeIntervalOfProductViewModel : ViewModelBase {
        private DateTime _issueDate;
        [Category("timeIntervalOfProduct")]
        public DateTime issueDate {
            get {
                return _issueDate;
            }

            set {
                SetValue(ref _issueDate, value);
            }
        }

        private DateTime? _expirationDate = default;
        [Category("timeIntervalOfProduct")]
        public DateTime? expirationDate {
            get {
                return _expirationDate;
            }

            set {
                SetValue(ref _expirationDate, value);
            }
        }

        private issuanceCycleViewModel? _issuanceCycle;
        [Category("timeIntervalOfProduct")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public issuanceCycleViewModel? issuanceCycle {
            get {
                return _issuanceCycle;
            }

            set {
                SetValue(ref _issuanceCycle, value);
            }
        }

        public void Load(DomainModel.S128.ComplexAttributes.timeIntervalOfProduct instance) {
            issueDate = instance.issueDate;
            expirationDate = instance.expirationDate;
            issuanceCycle = new();
            if (instance.issuanceCycle != null) {
                issuanceCycle = new();
                issuanceCycle.Load(instance.issuanceCycle);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.timeIntervalOfProduct
            {
                issueDate = this.issueDate,
                expirationDate = this.expirationDate,
                issuanceCycle = this.issuanceCycle?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.timeIntervalOfProduct Model => new()
        {
            issueDate = this._issueDate,
            expirationDate = this._expirationDate,
            issuanceCycle = this._issuanceCycle?.Model,
        };

        public timeIntervalOfProductViewModel() : base() {
        }

        public override string? ToString() => $"Time Interval of Product";
    }

    [CategoryOrder("referenceToNM", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class referenceToNMViewModel : ViewModelBase {
        private DateTime _publicationDate;
        [Category("referenceToNM")]
        public DateTime publicationDate {
            get {
                return _publicationDate;
            }

            set {
                SetValue(ref _publicationDate, value);
            }
        }

        private weekOfYearViewModel? _weekOfYear;
        [Category("referenceToNM")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public weekOfYearViewModel? weekOfYear {
            get {
                return _weekOfYear;
            }

            set {
                SetValue(ref _weekOfYear, value);
            }
        }

        public void Load(DomainModel.S128.ComplexAttributes.referenceToNM instance) {
            publicationDate = instance.publicationDate;
            weekOfYear = new();
            if (instance.weekOfYear != null) {
                weekOfYear = new();
                weekOfYear.Load(instance.weekOfYear);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.ComplexAttributes.referenceToNM
            {
                publicationDate = this.publicationDate,
                weekOfYear = this.weekOfYear?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.ComplexAttributes.referenceToNM Model => new()
        {
            publicationDate = this._publicationDate,
            weekOfYear = this._weekOfYear?.Model,
        };

        public referenceToNMViewModel() : base() {
        }

        public override string? ToString() => $"Reference To NM";
    }

    [CategoryOrder("CatalogueSectionHeader", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class CatalogueSectionHeaderViewModel : ViewModelBase {
        private Int32 _catalogueSectionNumber;
        [Category("CatalogueSectionHeader")]
        public Int32 catalogueSectionNumber {
            get {
                return _catalogueSectionNumber;
            }

            set {
                SetValue(ref _catalogueSectionNumber, value);
            }
        }

        private String _catalogueSectionTitle = string.Empty;
        [Category("CatalogueSectionHeader")]
        public String catalogueSectionTitle {
            get {
                return _catalogueSectionTitle;
            }

            set {
                SetValue(ref _catalogueSectionTitle, value);
            }
        }

        private informationViewModel? _information;
        [Category("CatalogueSectionHeader")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public informationViewModel? information {
            get {
                return _information;
            }

            set {
                SetValue(ref _information, value);
            }
        }

        public class CatalogueSectionHeaderRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["CatalogueSectionHeader"];
        }

        public void Load(DomainModel.S128.InformationTypes.CatalogueSectionHeader instance) {
            catalogueSectionNumber = instance.catalogueSectionNumber;
            catalogueSectionTitle = instance.catalogueSectionTitle;
            information = new();
            if (instance.information != null) {
                information = new();
                information.Load(instance.information);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.InformationTypes.CatalogueSectionHeader
            {
                catalogueSectionNumber = this.catalogueSectionNumber,
                catalogueSectionTitle = this.catalogueSectionTitle,
                information = this.information?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.InformationTypes.CatalogueSectionHeader Model => new()
        {
            catalogueSectionNumber = this._catalogueSectionNumber,
            catalogueSectionTitle = this._catalogueSectionTitle,
            information = this._information?.Model,
        };

        public CatalogueSectionHeaderViewModel() : base() {
        }

        public override string? ToString() => $"Catalogue Section Header";
    }

    [CategoryOrder("ContactDetails", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ContactDetailsViewModel : ViewModelBase {
        private String _contactInstructions = string.Empty;
        [Category("ContactDetails")]
        public String contactInstructions {
            get {
                return _contactInstructions;
            }

            set {
                SetValue(ref _contactInstructions, value);
            }
        }

        [Category("ContactDetails")]
        public ObservableCollection<contactAddress> contactAddress { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<onlineResource> onlineResource { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<telecommunications> telecommunications { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<sourceIndication> sourceIndication { get; set; } = new();

        public class ContactDetailsRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["ContactDetails"];
        }

        public void Load(DomainModel.S128.InformationTypes.ContactDetails instance) {
            contactInstructions = instance.contactInstructions;
            contactAddress.Clear();
            if (instance.contactAddress is not null)
                foreach (var e in instance.contactAddress)
                    contactAddress.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            onlineResource.Clear();
            if (instance.onlineResource is not null)
                foreach (var e in instance.onlineResource)
                    onlineResource.Add(e);
            telecommunications.Clear();
            if (instance.telecommunications is not null)
                foreach (var e in instance.telecommunications)
                    telecommunications.Add(e);
            sourceIndication.Clear();
            if (instance.sourceIndication is not null)
                foreach (var e in instance.sourceIndication)
                    sourceIndication.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.InformationTypes.ContactDetails
            {
                contactInstructions = this.contactInstructions,
                contactAddress = this.contactAddress.ToList(),
                information = this.information.ToList(),
                onlineResource = this.onlineResource.ToList(),
                telecommunications = this.telecommunications.ToList(),
                sourceIndication = this.sourceIndication.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.InformationTypes.ContactDetails Model => new()
        {
            contactInstructions = this._contactInstructions,
            contactAddress = this.contactAddress.ToList(),
            information = this.information.ToList(),
            onlineResource = this.onlineResource.ToList(),
            telecommunications = this.telecommunications.ToList(),
            sourceIndication = this.sourceIndication.ToList(),
        };

        public ContactDetailsViewModel() : base() {
            contactAddress.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(contactAddress));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            onlineResource.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(onlineResource));
            };
            telecommunications.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(telecommunications));
            };
            sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(sourceIndication));
            };
        }

        public override string? ToString() => $"Contact Details";
    }

    [CategoryOrder("IndicationOfCarriageRequirement", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class IndicationOfCarriageRequirementViewModel : ViewModelBase {
        private String _domesticCarriageRequirements = string.Empty;
        [Category("IndicationOfCarriageRequirement")]
        public String domesticCarriageRequirements {
            get {
                return _domesticCarriageRequirements;
            }

            set {
                SetValue(ref _domesticCarriageRequirements, value);
            }
        }

        private String _internationalCarriageRequirements = string.Empty;
        [Category("IndicationOfCarriageRequirement")]
        public String internationalCarriageRequirements {
            get {
                return _internationalCarriageRequirements;
            }

            set {
                SetValue(ref _internationalCarriageRequirements, value);
            }
        }

        [Category("IndicationOfCarriageRequirement")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        public class IndicationOfCarriageRequirementRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["IndicationOfCarriageRequirement"];
        }

        public void Load(DomainModel.S128.InformationTypes.IndicationOfCarriageRequirement instance) {
            domesticCarriageRequirements = instance.domesticCarriageRequirements;
            internationalCarriageRequirements = instance.internationalCarriageRequirements;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.InformationTypes.IndicationOfCarriageRequirement
            {
                domesticCarriageRequirements = this.domesticCarriageRequirements,
                internationalCarriageRequirements = this.internationalCarriageRequirements,
                featureName = this.featureName.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.InformationTypes.IndicationOfCarriageRequirement Model => new()
        {
            domesticCarriageRequirements = this._domesticCarriageRequirements,
            internationalCarriageRequirements = this._internationalCarriageRequirements,
            featureName = this.featureName.ToList(),
        };

        public IndicationOfCarriageRequirementViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
        }

        public override string? ToString() => $"Indication Of Carriage Requirement";
    }

    [CategoryOrder("PriceInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class PriceInformationViewModel : ViewModelBase {
        [Category("PriceInformation")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("PriceInformation")]
        public ObservableCollection<onlineResource> onlineResource { get; set; } = new();

        [Category("PriceInformation")]
        public ObservableCollection<pricing> pricing { get; set; } = new();

        [Category("PriceInformation")]
        public ObservableCollection<sourceIndication> sourceIndication { get; set; } = new();

        public class PriceInformationRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["PriceInformation"];
        }

        public void Load(DomainModel.S128.InformationTypes.PriceInformation instance) {
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            onlineResource.Clear();
            if (instance.onlineResource is not null)
                foreach (var e in instance.onlineResource)
                    onlineResource.Add(e);
            pricing.Clear();
            if (instance.pricing is not null)
                foreach (var e in instance.pricing)
                    pricing.Add(e);
            sourceIndication.Clear();
            if (instance.sourceIndication is not null)
                foreach (var e in instance.sourceIndication)
                    sourceIndication.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.InformationTypes.PriceInformation
            {
                information = this.information.ToList(),
                onlineResource = this.onlineResource.ToList(),
                pricing = this.pricing.ToList(),
                sourceIndication = this.sourceIndication.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.InformationTypes.PriceInformation Model => new()
        {
            information = this.information.ToList(),
            onlineResource = this.onlineResource.ToList(),
            pricing = this.pricing.ToList(),
            sourceIndication = this.sourceIndication.ToList(),
        };

        public PriceInformationViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            onlineResource.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(onlineResource));
            };
            pricing.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(pricing));
            };
            sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(sourceIndication));
            };
        }

        public override string? ToString() => $"Price Information";
    }

    [CategoryOrder("ProducerInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ProducerInformationViewModel : ViewModelBase {
        private String _agencyResponsibleForProduction = string.Empty;
        [Category("ProducerInformation")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        private String _agencyName = string.Empty;
        [Category("ProducerInformation")]
        public String agencyName {
            get {
                return _agencyName;
            }

            set {
                SetValue(ref _agencyName, value);
            }
        }

        public class ProducerInformationRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["ProducerInformation"];
        }

        public void Load(DomainModel.S128.InformationTypes.ProducerInformation instance) {
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            agencyName = instance.agencyName;
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.InformationTypes.ProducerInformation
            {
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                agencyName = this.agencyName,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.InformationTypes.ProducerInformation Model => new()
        {
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            agencyName = this._agencyName,
        };

        public ProducerInformationViewModel() : base() {
        }

        public override string? ToString() => $"Producer Information";
    }

    [CategoryOrder("DistributorInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DistributorInformationViewModel : ViewModelBase {
        private String _distributorName = string.Empty;
        [Category("DistributorInformation")]
        public String distributorName {
            get {
                return _distributorName;
            }

            set {
                SetValue(ref _distributorName, value);
            }
        }

        public class DistributorInformationRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["DistributorInformation"];
        }

        public void Load(DomainModel.S128.InformationTypes.DistributorInformation instance) {
            distributorName = instance.distributorName;
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.InformationTypes.DistributorInformation
            {
                distributorName = this.distributorName,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.InformationTypes.DistributorInformation Model => new()
        {
            distributorName = this._distributorName,
        };

        public DistributorInformationViewModel() : base() {
        }

        public override string? ToString() => $"Distributor Information";
    }

    [CategoryOrder("ElectronicProduct", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ElectronicProductViewModel : ViewModelBase {
        private Boolean? _compressionFlag = default;
        [Category("ElectronicProduct")]
        public Boolean? compressionFlag {
            get {
                return _compressionFlag;
            }

            set {
                SetValue(ref _compressionFlag, value);
            }
        }

        private String _datasetName = string.Empty;
        [Category("ElectronicProduct")]
        public String datasetName {
            get {
                return _datasetName;
            }

            set {
                SetValue(ref _datasetName, value);
            }
        }

        private DateTime _issueDate;
        [Category("ElectronicProduct")]
        public DateTime issueDate {
            get {
                return _issueDate;
            }

            set {
                SetValue(ref _issueDate, value);
            }
        }

        private TimeOnly? _issueTime = default;
        [Category("ElectronicProduct")]
        public TimeOnly? issueTime {
            get {
                return _issueTime;
            }

            set {
                SetValue(ref _issueTime, value);
            }
        }

        private typeOfProductFormat _typeOfProductFormat;
        [Category("ElectronicProduct")]
        public typeOfProductFormat typeOfProductFormat {
            get {
                return _typeOfProductFormat;
            }

            set {
                SetValue(ref _typeOfProductFormat, value);
            }
        }

        private productSpecificationViewModel? _productSpecification;
        [Category("ElectronicProduct")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public productSpecificationViewModel? productSpecification {
            get {
                return _productSpecification;
            }

            set {
                SetValue(ref _productSpecification, value);
            }
        }

        [Category("NavigationalProduct")]
        public ObservableCollection<Decimal> approximateGridResolution { get; set; } = new();

        [Category("NavigationalProduct")]
        public ObservableCollection<Int32> compilationScale { get; set; } = new();

        private distributionStatus? _distributionStatus = default;
        [Category("NavigationalProduct")]
        public distributionStatus? distributionStatus {
            get {
                return _distributionStatus;
            }

            set {
                SetValue(ref _distributionStatus, value);
            }
        }

        private Int32? _editionNumber = default;
        [Category("NavigationalProduct")]
        public Int32? editionNumber {
            get {
                return _editionNumber;
            }

            set {
                SetValue(ref _editionNumber, value);
            }
        }

        private Int32? _maximumDisplayScale = default;
        [Category("NavigationalProduct")]
        public Int32? maximumDisplayScale {
            get {
                return _maximumDisplayScale;
            }

            set {
                SetValue(ref _maximumDisplayScale, value);
            }
        }

        private Int32? _minimumDisplayScale = default;
        [Category("NavigationalProduct")]
        public Int32? minimumDisplayScale {
            get {
                return _minimumDisplayScale;
            }

            set {
                SetValue(ref _minimumDisplayScale, value);
            }
        }

        [Category("NavigationalProduct")]
        public ObservableCollection<navigationPurpose> navigationPurpose { get; set; } = new();

        private String _optimumDisplayScale = string.Empty;
        [Category("NavigationalProduct")]
        public String optimumDisplayScale {
            get {
                return _optimumDisplayScale;
            }

            set {
                SetValue(ref _optimumDisplayScale, value);
            }
        }

        private String _originalProductNumber = string.Empty;
        [Category("NavigationalProduct")]
        public String originalProductNumber {
            get {
                return _originalProductNumber;
            }

            set {
                SetValue(ref _originalProductNumber, value);
            }
        }

        private String _producerNation = string.Empty;
        [Category("NavigationalProduct")]
        public String producerNation {
            get {
                return _producerNation;
            }

            set {
                SetValue(ref _producerNation, value);
            }
        }

        private String _productNumber = string.Empty;
        [Category("NavigationalProduct")]
        public String productNumber {
            get {
                return _productNumber;
            }

            set {
                SetValue(ref _productNumber, value);
            }
        }

        private specificUsage? _specificUsage = default;
        [Category("NavigationalProduct")]
        public specificUsage? specificUsage {
            get {
                return _specificUsage;
            }

            set {
                SetValue(ref _specificUsage, value);
            }
        }

        private DateTime? _updateDate = default;
        [Category("NavigationalProduct")]
        public DateTime? updateDate {
            get {
                return _updateDate;
            }

            set {
                SetValue(ref _updateDate, value);
            }
        }

        private Int32? _updateNumber = default;
        [Category("NavigationalProduct")]
        public Int32? updateNumber {
            get {
                return _updateNumber;
            }

            set {
                SetValue(ref _updateNumber, value);
            }
        }

        private horizontalDatumEpsg? _horizontalDatumEpsg;
        [DomainModel.CodeList(nameof(horizontalDatumEpsgList))]
        [Editor(typeof(Editors.CodeListComboEditor), typeof(Editors.CodeListComboEditor))]
        [Category("NavigationalProduct")]
        public horizontalDatumEpsg? horizontalDatumEpsg {
            get {
                return _horizontalDatumEpsg;
            }

            set {
                SetValue(ref _horizontalDatumEpsg, value);
            }
        }

        private verticalDatum? _verticalDatum = default;
        [Category("NavigationalProduct")]
        public verticalDatum? verticalDatum {
            get {
                return _verticalDatum;
            }

            set {
                SetValue(ref _verticalDatum, value);
            }
        }

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("CatalogueElement")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        [Category("CatalogueElement")]
        public ObservableCollection<catalogueElementClassification> catalogueElementClassification { get; set; } = new();

        private String _catalogueElementIdentifier = string.Empty;
        [Category("CatalogueElement")]
        public String catalogueElementIdentifier {
            get {
                return _catalogueElementIdentifier;
            }

            set {
                SetValue(ref _catalogueElementIdentifier, value);
            }
        }

        private String _classification = string.Empty;
        [Category("CatalogueElement")]
        public String classification {
            get {
                return _classification;
            }

            set {
                SetValue(ref _classification, value);
            }
        }

        [Category("CatalogueElement")]
        public ObservableCollection<IMOMaritimeService> IMOMaritimeService { get; set; } = new();

        private Boolean _notForNavigation;
        [Category("CatalogueElement")]
        public Boolean notForNavigation {
            get {
                return _notForNavigation;
            }

            set {
                SetValue(ref _notForNavigation, value);
            }
        }

        [Category("CatalogueElement")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("CatalogueElement")]
        public ObservableCollection<information> information { get; set; } = new();

        private onlineResourceViewModel? _onlineResource;
        [Category("CatalogueElement")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public onlineResourceViewModel? onlineResource {
            get {
                return _onlineResource;
            }

            set {
                SetValue(ref _onlineResource, value);
            }
        }

        private sourceIndicationViewModel? _sourceIndication;
        [Category("CatalogueElement")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIndicationViewModel? sourceIndication {
            get {
                return _sourceIndication;
            }

            set {
                SetValue(ref _sourceIndication, value);
            }
        }

        [Category("CatalogueElement")]
        public ObservableCollection<supportFile> supportFile { get; set; } = new();

        private timeIntervalOfProductViewModel? _timeIntervalOfProduct;
        [Category("CatalogueElement")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public timeIntervalOfProductViewModel? timeIntervalOfProduct {
            get {
                return _timeIntervalOfProduct;
            }

            set {
                SetValue(ref _timeIntervalOfProduct, value);
            }
        }

        public class ElectronicProductRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["ElectronicProduct"];
        }

        [Browsable(false)]
        public horizontalDatumEpsg[] horizontalDatumEpsgList => CodeList.horizontalDatumEpsgs.ToArray();

        public void Load(DomainModel.S128.FeatureTypes.ElectronicProduct instance) {
            compressionFlag = instance.compressionFlag;
            datasetName = instance.datasetName;
            issueDate = instance.issueDate;
            issueTime = instance.issueTime;
            typeOfProductFormat = instance.typeOfProductFormat;
            productSpecification = new();
            if (instance.productSpecification != null) {
                productSpecification = new();
                productSpecification.Load(instance.productSpecification);
            }

            approximateGridResolution.Clear();
            if (instance.approximateGridResolution is not null)
                foreach (var e in instance.approximateGridResolution)
                    approximateGridResolution.Add(e);
            compilationScale.Clear();
            if (instance.compilationScale is not null)
                foreach (var e in instance.compilationScale)
                    compilationScale.Add(e);
            distributionStatus = instance.distributionStatus;
            editionNumber = instance.editionNumber;
            maximumDisplayScale = instance.maximumDisplayScale;
            minimumDisplayScale = instance.minimumDisplayScale;
            navigationPurpose.Clear();
            if (instance.navigationPurpose is not null)
                foreach (var e in instance.navigationPurpose)
                    navigationPurpose.Add(e);
            optimumDisplayScale = instance.optimumDisplayScale;
            originalProductNumber = instance.originalProductNumber;
            producerNation = instance.producerNation;
            productNumber = instance.productNumber;
            specificUsage = instance.specificUsage;
            updateDate = instance.updateDate;
            updateNumber = instance.updateNumber;
            horizontalDatumEpsg = instance.horizontalDatumEpsg;
            verticalDatum = instance.verticalDatum;
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            catalogueElementClassification.Clear();
            if (instance.catalogueElementClassification is not null)
                foreach (var e in instance.catalogueElementClassification)
                    catalogueElementClassification.Add(e);
            catalogueElementIdentifier = instance.catalogueElementIdentifier;
            classification = instance.classification;
            IMOMaritimeService.Clear();
            if (instance.IMOMaritimeService is not null)
                foreach (var e in instance.IMOMaritimeService)
                    IMOMaritimeService.Add(e);
            notForNavigation = instance.notForNavigation;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            onlineResource = new();
            if (instance.onlineResource != null) {
                onlineResource = new();
                onlineResource.Load(instance.onlineResource);
            }

            sourceIndication = new();
            if (instance.sourceIndication != null) {
                sourceIndication = new();
                sourceIndication.Load(instance.sourceIndication);
            }

            supportFile.Clear();
            if (instance.supportFile is not null)
                foreach (var e in instance.supportFile)
                    supportFile.Add(e);
            timeIntervalOfProduct = new();
            if (instance.timeIntervalOfProduct != null) {
                timeIntervalOfProduct = new();
                timeIntervalOfProduct.Load(instance.timeIntervalOfProduct);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.FeatureTypes.ElectronicProduct
            {
                compressionFlag = this.compressionFlag,
                datasetName = this.datasetName,
                issueDate = this.issueDate,
                issueTime = this.issueTime,
                typeOfProductFormat = this.typeOfProductFormat,
                productSpecification = this.productSpecification?.Model,
                approximateGridResolution = this.approximateGridResolution.ToList(),
                compilationScale = this.compilationScale.ToList(),
                distributionStatus = this.distributionStatus,
                editionNumber = this.editionNumber,
                maximumDisplayScale = this.maximumDisplayScale,
                minimumDisplayScale = this.minimumDisplayScale,
                navigationPurpose = this.navigationPurpose.ToList(),
                optimumDisplayScale = this.optimumDisplayScale,
                originalProductNumber = this.originalProductNumber,
                producerNation = this.producerNation,
                productNumber = this.productNumber,
                specificUsage = this.specificUsage,
                updateDate = this.updateDate,
                updateNumber = this.updateNumber,
                horizontalDatumEpsg = this.horizontalDatumEpsg,
                verticalDatum = this.verticalDatum,
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                catalogueElementClassification = this.catalogueElementClassification.ToList(),
                catalogueElementIdentifier = this.catalogueElementIdentifier,
                classification = this.classification,
                IMOMaritimeService = this.IMOMaritimeService.ToList(),
                notForNavigation = this.notForNavigation,
                featureName = this.featureName.ToList(),
                information = this.information.ToList(),
                onlineResource = this.onlineResource?.Model,
                sourceIndication = this.sourceIndication?.Model,
                supportFile = this.supportFile.ToList(),
                timeIntervalOfProduct = this.timeIntervalOfProduct?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.FeatureTypes.ElectronicProduct Model => new()
        {
            compressionFlag = this._compressionFlag,
            datasetName = this._datasetName,
            issueDate = this._issueDate,
            issueTime = this._issueTime,
            typeOfProductFormat = this._typeOfProductFormat,
            productSpecification = this._productSpecification?.Model,
            approximateGridResolution = this.approximateGridResolution.ToList(),
            compilationScale = this.compilationScale.ToList(),
            distributionStatus = this._distributionStatus,
            editionNumber = this._editionNumber,
            maximumDisplayScale = this._maximumDisplayScale,
            minimumDisplayScale = this._minimumDisplayScale,
            navigationPurpose = this.navigationPurpose.ToList(),
            optimumDisplayScale = this._optimumDisplayScale,
            originalProductNumber = this._originalProductNumber,
            producerNation = this._producerNation,
            productNumber = this._productNumber,
            specificUsage = this._specificUsage,
            updateDate = this._updateDate,
            updateNumber = this._updateNumber,
            horizontalDatumEpsg = this._horizontalDatumEpsg,
            verticalDatum = this._verticalDatum,
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            catalogueElementClassification = this.catalogueElementClassification.ToList(),
            catalogueElementIdentifier = this._catalogueElementIdentifier,
            classification = this._classification,
            IMOMaritimeService = this.IMOMaritimeService.ToList(),
            notForNavigation = this._notForNavigation,
            featureName = this.featureName.ToList(),
            information = this.information.ToList(),
            onlineResource = this._onlineResource?.Model,
            sourceIndication = this._sourceIndication?.Model,
            supportFile = this.supportFile.ToList(),
            timeIntervalOfProduct = this._timeIntervalOfProduct?.Model,
        };

        public ElectronicProductViewModel() : base() {
            approximateGridResolution.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(approximateGridResolution));
            };
            compilationScale.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(compilationScale));
            };
            navigationPurpose.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(navigationPurpose));
            };
            catalogueElementClassification.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(catalogueElementClassification));
            };
            IMOMaritimeService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(IMOMaritimeService));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            supportFile.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(supportFile));
            };
        }

        public override string? ToString() => $"Electronic Product";
    }

    [CategoryOrder("PhysicalProduct", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class PhysicalProductViewModel : ViewModelBase {
        private DateTime _editionDate;
        [Category("PhysicalProduct")]
        public DateTime editionDate {
            get {
                return _editionDate;
            }

            set {
                SetValue(ref _editionDate, value);
            }
        }

        private String _isbn = string.Empty;
        [Category("PhysicalProduct")]
        public String isbn {
            get {
                return _isbn;
            }

            set {
                SetValue(ref _isbn, value);
            }
        }

        private String _publicationNumber = string.Empty;
        [Category("PhysicalProduct")]
        public String publicationNumber {
            get {
                return _publicationNumber;
            }

            set {
                SetValue(ref _publicationNumber, value);
            }
        }

        private String _typeOfPaper = string.Empty;
        [Category("PhysicalProduct")]
        public String typeOfPaper {
            get {
                return _typeOfPaper;
            }

            set {
                SetValue(ref _typeOfPaper, value);
            }
        }

        private printInformationViewModel? _printInformation;
        [Category("PhysicalProduct")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public printInformationViewModel? printInformation {
            get {
                return _printInformation;
            }

            set {
                SetValue(ref _printInformation, value);
            }
        }

        private referenceToNMViewModel? _referenceToNM;
        [Category("PhysicalProduct")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public referenceToNMViewModel? referenceToNM {
            get {
                return _referenceToNM;
            }

            set {
                SetValue(ref _referenceToNM, value);
            }
        }

        [Category("NavigationalProduct")]
        public ObservableCollection<Decimal> approximateGridResolution { get; set; } = new();

        [Category("NavigationalProduct")]
        public ObservableCollection<Int32> compilationScale { get; set; } = new();

        private distributionStatus? _distributionStatus = default;
        [Category("NavigationalProduct")]
        public distributionStatus? distributionStatus {
            get {
                return _distributionStatus;
            }

            set {
                SetValue(ref _distributionStatus, value);
            }
        }

        private Int32? _editionNumber = default;
        [Category("NavigationalProduct")]
        public Int32? editionNumber {
            get {
                return _editionNumber;
            }

            set {
                SetValue(ref _editionNumber, value);
            }
        }

        private Int32? _maximumDisplayScale = default;
        [Category("NavigationalProduct")]
        public Int32? maximumDisplayScale {
            get {
                return _maximumDisplayScale;
            }

            set {
                SetValue(ref _maximumDisplayScale, value);
            }
        }

        private Int32? _minimumDisplayScale = default;
        [Category("NavigationalProduct")]
        public Int32? minimumDisplayScale {
            get {
                return _minimumDisplayScale;
            }

            set {
                SetValue(ref _minimumDisplayScale, value);
            }
        }

        [Category("NavigationalProduct")]
        public ObservableCollection<navigationPurpose> navigationPurpose { get; set; } = new();

        private String _optimumDisplayScale = string.Empty;
        [Category("NavigationalProduct")]
        public String optimumDisplayScale {
            get {
                return _optimumDisplayScale;
            }

            set {
                SetValue(ref _optimumDisplayScale, value);
            }
        }

        private String _originalProductNumber = string.Empty;
        [Category("NavigationalProduct")]
        public String originalProductNumber {
            get {
                return _originalProductNumber;
            }

            set {
                SetValue(ref _originalProductNumber, value);
            }
        }

        private String _producerNation = string.Empty;
        [Category("NavigationalProduct")]
        public String producerNation {
            get {
                return _producerNation;
            }

            set {
                SetValue(ref _producerNation, value);
            }
        }

        private String _productNumber = string.Empty;
        [Category("NavigationalProduct")]
        public String productNumber {
            get {
                return _productNumber;
            }

            set {
                SetValue(ref _productNumber, value);
            }
        }

        private specificUsage? _specificUsage = default;
        [Category("NavigationalProduct")]
        public specificUsage? specificUsage {
            get {
                return _specificUsage;
            }

            set {
                SetValue(ref _specificUsage, value);
            }
        }

        private DateTime? _updateDate = default;
        [Category("NavigationalProduct")]
        public DateTime? updateDate {
            get {
                return _updateDate;
            }

            set {
                SetValue(ref _updateDate, value);
            }
        }

        private Int32? _updateNumber = default;
        [Category("NavigationalProduct")]
        public Int32? updateNumber {
            get {
                return _updateNumber;
            }

            set {
                SetValue(ref _updateNumber, value);
            }
        }

        private horizontalDatumEpsg? _horizontalDatumEpsg;
        [DomainModel.CodeList(nameof(horizontalDatumEpsgList))]
        [Editor(typeof(Editors.CodeListComboEditor), typeof(Editors.CodeListComboEditor))]
        [Category("NavigationalProduct")]
        public horizontalDatumEpsg? horizontalDatumEpsg {
            get {
                return _horizontalDatumEpsg;
            }

            set {
                SetValue(ref _horizontalDatumEpsg, value);
            }
        }

        private verticalDatum? _verticalDatum = default;
        [Category("NavigationalProduct")]
        public verticalDatum? verticalDatum {
            get {
                return _verticalDatum;
            }

            set {
                SetValue(ref _verticalDatum, value);
            }
        }

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("CatalogueElement")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        [Category("CatalogueElement")]
        public ObservableCollection<catalogueElementClassification> catalogueElementClassification { get; set; } = new();

        private String _catalogueElementIdentifier = string.Empty;
        [Category("CatalogueElement")]
        public String catalogueElementIdentifier {
            get {
                return _catalogueElementIdentifier;
            }

            set {
                SetValue(ref _catalogueElementIdentifier, value);
            }
        }

        private String _classification = string.Empty;
        [Category("CatalogueElement")]
        public String classification {
            get {
                return _classification;
            }

            set {
                SetValue(ref _classification, value);
            }
        }

        [Category("CatalogueElement")]
        public ObservableCollection<IMOMaritimeService> IMOMaritimeService { get; set; } = new();

        private Boolean _notForNavigation;
        [Category("CatalogueElement")]
        public Boolean notForNavigation {
            get {
                return _notForNavigation;
            }

            set {
                SetValue(ref _notForNavigation, value);
            }
        }

        [Category("CatalogueElement")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("CatalogueElement")]
        public ObservableCollection<information> information { get; set; } = new();

        private onlineResourceViewModel? _onlineResource;
        [Category("CatalogueElement")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public onlineResourceViewModel? onlineResource {
            get {
                return _onlineResource;
            }

            set {
                SetValue(ref _onlineResource, value);
            }
        }

        private sourceIndicationViewModel? _sourceIndication;
        [Category("CatalogueElement")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIndicationViewModel? sourceIndication {
            get {
                return _sourceIndication;
            }

            set {
                SetValue(ref _sourceIndication, value);
            }
        }

        [Category("CatalogueElement")]
        public ObservableCollection<supportFile> supportFile { get; set; } = new();

        private timeIntervalOfProductViewModel? _timeIntervalOfProduct;
        [Category("CatalogueElement")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public timeIntervalOfProductViewModel? timeIntervalOfProduct {
            get {
                return _timeIntervalOfProduct;
            }

            set {
                SetValue(ref _timeIntervalOfProduct, value);
            }
        }

        public class PhysicalProductRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["PhysicalProduct"];
        }

        [Browsable(false)]
        public horizontalDatumEpsg[] horizontalDatumEpsgList => CodeList.horizontalDatumEpsgs.ToArray();

        public void Load(DomainModel.S128.FeatureTypes.PhysicalProduct instance) {
            editionDate = instance.editionDate;
            isbn = instance.isbn;
            publicationNumber = instance.publicationNumber;
            typeOfPaper = instance.typeOfPaper;
            printInformation = new();
            if (instance.printInformation != null) {
                printInformation = new();
                printInformation.Load(instance.printInformation);
            }

            referenceToNM = new();
            if (instance.referenceToNM != null) {
                referenceToNM = new();
                referenceToNM.Load(instance.referenceToNM);
            }

            approximateGridResolution.Clear();
            if (instance.approximateGridResolution is not null)
                foreach (var e in instance.approximateGridResolution)
                    approximateGridResolution.Add(e);
            compilationScale.Clear();
            if (instance.compilationScale is not null)
                foreach (var e in instance.compilationScale)
                    compilationScale.Add(e);
            distributionStatus = instance.distributionStatus;
            editionNumber = instance.editionNumber;
            maximumDisplayScale = instance.maximumDisplayScale;
            minimumDisplayScale = instance.minimumDisplayScale;
            navigationPurpose.Clear();
            if (instance.navigationPurpose is not null)
                foreach (var e in instance.navigationPurpose)
                    navigationPurpose.Add(e);
            optimumDisplayScale = instance.optimumDisplayScale;
            originalProductNumber = instance.originalProductNumber;
            producerNation = instance.producerNation;
            productNumber = instance.productNumber;
            specificUsage = instance.specificUsage;
            updateDate = instance.updateDate;
            updateNumber = instance.updateNumber;
            horizontalDatumEpsg = instance.horizontalDatumEpsg;
            verticalDatum = instance.verticalDatum;
            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            catalogueElementClassification.Clear();
            if (instance.catalogueElementClassification is not null)
                foreach (var e in instance.catalogueElementClassification)
                    catalogueElementClassification.Add(e);
            catalogueElementIdentifier = instance.catalogueElementIdentifier;
            classification = instance.classification;
            IMOMaritimeService.Clear();
            if (instance.IMOMaritimeService is not null)
                foreach (var e in instance.IMOMaritimeService)
                    IMOMaritimeService.Add(e);
            notForNavigation = instance.notForNavigation;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            onlineResource = new();
            if (instance.onlineResource != null) {
                onlineResource = new();
                onlineResource.Load(instance.onlineResource);
            }

            sourceIndication = new();
            if (instance.sourceIndication != null) {
                sourceIndication = new();
                sourceIndication.Load(instance.sourceIndication);
            }

            supportFile.Clear();
            if (instance.supportFile is not null)
                foreach (var e in instance.supportFile)
                    supportFile.Add(e);
            timeIntervalOfProduct = new();
            if (instance.timeIntervalOfProduct != null) {
                timeIntervalOfProduct = new();
                timeIntervalOfProduct.Load(instance.timeIntervalOfProduct);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.FeatureTypes.PhysicalProduct
            {
                editionDate = this.editionDate,
                isbn = this.isbn,
                publicationNumber = this.publicationNumber,
                typeOfPaper = this.typeOfPaper,
                printInformation = this.printInformation?.Model,
                referenceToNM = this.referenceToNM?.Model,
                approximateGridResolution = this.approximateGridResolution.ToList(),
                compilationScale = this.compilationScale.ToList(),
                distributionStatus = this.distributionStatus,
                editionNumber = this.editionNumber,
                maximumDisplayScale = this.maximumDisplayScale,
                minimumDisplayScale = this.minimumDisplayScale,
                navigationPurpose = this.navigationPurpose.ToList(),
                optimumDisplayScale = this.optimumDisplayScale,
                originalProductNumber = this.originalProductNumber,
                producerNation = this.producerNation,
                productNumber = this.productNumber,
                specificUsage = this.specificUsage,
                updateDate = this.updateDate,
                updateNumber = this.updateNumber,
                horizontalDatumEpsg = this.horizontalDatumEpsg,
                verticalDatum = this.verticalDatum,
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                catalogueElementClassification = this.catalogueElementClassification.ToList(),
                catalogueElementIdentifier = this.catalogueElementIdentifier,
                classification = this.classification,
                IMOMaritimeService = this.IMOMaritimeService.ToList(),
                notForNavigation = this.notForNavigation,
                featureName = this.featureName.ToList(),
                information = this.information.ToList(),
                onlineResource = this.onlineResource?.Model,
                sourceIndication = this.sourceIndication?.Model,
                supportFile = this.supportFile.ToList(),
                timeIntervalOfProduct = this.timeIntervalOfProduct?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.FeatureTypes.PhysicalProduct Model => new()
        {
            editionDate = this._editionDate,
            isbn = this._isbn,
            publicationNumber = this._publicationNumber,
            typeOfPaper = this._typeOfPaper,
            printInformation = this._printInformation?.Model,
            referenceToNM = this._referenceToNM?.Model,
            approximateGridResolution = this.approximateGridResolution.ToList(),
            compilationScale = this.compilationScale.ToList(),
            distributionStatus = this._distributionStatus,
            editionNumber = this._editionNumber,
            maximumDisplayScale = this._maximumDisplayScale,
            minimumDisplayScale = this._minimumDisplayScale,
            navigationPurpose = this.navigationPurpose.ToList(),
            optimumDisplayScale = this._optimumDisplayScale,
            originalProductNumber = this._originalProductNumber,
            producerNation = this._producerNation,
            productNumber = this._productNumber,
            specificUsage = this._specificUsage,
            updateDate = this._updateDate,
            updateNumber = this._updateNumber,
            horizontalDatumEpsg = this._horizontalDatumEpsg,
            verticalDatum = this._verticalDatum,
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            catalogueElementClassification = this.catalogueElementClassification.ToList(),
            catalogueElementIdentifier = this._catalogueElementIdentifier,
            classification = this._classification,
            IMOMaritimeService = this.IMOMaritimeService.ToList(),
            notForNavigation = this._notForNavigation,
            featureName = this.featureName.ToList(),
            information = this.information.ToList(),
            onlineResource = this._onlineResource?.Model,
            sourceIndication = this._sourceIndication?.Model,
            supportFile = this.supportFile.ToList(),
            timeIntervalOfProduct = this._timeIntervalOfProduct?.Model,
        };

        public PhysicalProductViewModel() : base() {
            approximateGridResolution.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(approximateGridResolution));
            };
            compilationScale.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(compilationScale));
            };
            navigationPurpose.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(navigationPurpose));
            };
            catalogueElementClassification.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(catalogueElementClassification));
            };
            IMOMaritimeService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(IMOMaritimeService));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            supportFile.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(supportFile));
            };
        }

        public override string? ToString() => $"Physical Product";
    }

    [CategoryOrder("S100Service", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class S100ServiceViewModel : ViewModelBase {
        private Boolean? _compressionFlag = default;
        [Category("S100Service")]
        public Boolean? compressionFlag {
            get {
                return _compressionFlag;
            }

            set {
                SetValue(ref _compressionFlag, value);
            }
        }

        private String _serviceName = string.Empty;
        [Category("S100Service")]
        public String serviceName {
            get {
                return _serviceName;
            }

            set {
                SetValue(ref _serviceName, value);
            }
        }

        private serviceStatus? _serviceStatus = default;
        [Category("S100Service")]
        public serviceStatus? serviceStatus {
            get {
                return _serviceStatus;
            }

            set {
                SetValue(ref _serviceStatus, value);
            }
        }

        private typeOfProductFormat _typeOfProductFormat;
        [Category("S100Service")]
        public typeOfProductFormat typeOfProductFormat {
            get {
                return _typeOfProductFormat;
            }

            set {
                SetValue(ref _typeOfProductFormat, value);
            }
        }

        private serviceSpecificationViewModel? _serviceSpecification;
        [Category("S100Service")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public serviceSpecificationViewModel? serviceSpecification {
            get {
                return _serviceSpecification;
            }

            set {
                SetValue(ref _serviceSpecification, value);
            }
        }

        private productSpecificationViewModel? _productSpecification;
        [Category("S100Service")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public productSpecificationViewModel? productSpecification {
            get {
                return _productSpecification;
            }

            set {
                SetValue(ref _productSpecification, value);
            }
        }

        private String _agencyResponsibleForProduction = string.Empty;
        [Category("CatalogueElement")]
        public String agencyResponsibleForProduction {
            get {
                return _agencyResponsibleForProduction;
            }

            set {
                SetValue(ref _agencyResponsibleForProduction, value);
            }
        }

        [Category("CatalogueElement")]
        public ObservableCollection<catalogueElementClassification> catalogueElementClassification { get; set; } = new();

        private String _catalogueElementIdentifier = string.Empty;
        [Category("CatalogueElement")]
        public String catalogueElementIdentifier {
            get {
                return _catalogueElementIdentifier;
            }

            set {
                SetValue(ref _catalogueElementIdentifier, value);
            }
        }

        private String _classification = string.Empty;
        [Category("CatalogueElement")]
        public String classification {
            get {
                return _classification;
            }

            set {
                SetValue(ref _classification, value);
            }
        }

        [Category("CatalogueElement")]
        public ObservableCollection<IMOMaritimeService> IMOMaritimeService { get; set; } = new();

        private Boolean _notForNavigation;
        [Category("CatalogueElement")]
        public Boolean notForNavigation {
            get {
                return _notForNavigation;
            }

            set {
                SetValue(ref _notForNavigation, value);
            }
        }

        [Category("CatalogueElement")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        [Category("CatalogueElement")]
        public ObservableCollection<information> information { get; set; } = new();

        private onlineResourceViewModel? _onlineResource;
        [Category("CatalogueElement")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public onlineResourceViewModel? onlineResource {
            get {
                return _onlineResource;
            }

            set {
                SetValue(ref _onlineResource, value);
            }
        }

        private sourceIndicationViewModel? _sourceIndication;
        [Category("CatalogueElement")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sourceIndicationViewModel? sourceIndication {
            get {
                return _sourceIndication;
            }

            set {
                SetValue(ref _sourceIndication, value);
            }
        }

        [Category("CatalogueElement")]
        public ObservableCollection<supportFile> supportFile { get; set; } = new();

        private timeIntervalOfProductViewModel? _timeIntervalOfProduct;
        [Category("CatalogueElement")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public timeIntervalOfProductViewModel? timeIntervalOfProduct {
            get {
                return _timeIntervalOfProduct;
            }

            set {
                SetValue(ref _timeIntervalOfProduct, value);
            }
        }

        public class S100ServiceRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["S100Service"];
        }

        public void Load(DomainModel.S128.FeatureTypes.S100Service instance) {
            compressionFlag = instance.compressionFlag;
            serviceName = instance.serviceName;
            serviceStatus = instance.serviceStatus;
            typeOfProductFormat = instance.typeOfProductFormat;
            serviceSpecification = new();
            if (instance.serviceSpecification != null) {
                serviceSpecification = new();
                serviceSpecification.Load(instance.serviceSpecification);
            }

            productSpecification = new();
            if (instance.productSpecification != null) {
                productSpecification = new();
                productSpecification.Load(instance.productSpecification);
            }

            agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
            catalogueElementClassification.Clear();
            if (instance.catalogueElementClassification is not null)
                foreach (var e in instance.catalogueElementClassification)
                    catalogueElementClassification.Add(e);
            catalogueElementIdentifier = instance.catalogueElementIdentifier;
            classification = instance.classification;
            IMOMaritimeService.Clear();
            if (instance.IMOMaritimeService is not null)
                foreach (var e in instance.IMOMaritimeService)
                    IMOMaritimeService.Add(e);
            notForNavigation = instance.notForNavigation;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            onlineResource = new();
            if (instance.onlineResource != null) {
                onlineResource = new();
                onlineResource.Load(instance.onlineResource);
            }

            sourceIndication = new();
            if (instance.sourceIndication != null) {
                sourceIndication = new();
                sourceIndication.Load(instance.sourceIndication);
            }

            supportFile.Clear();
            if (instance.supportFile is not null)
                foreach (var e in instance.supportFile)
                    supportFile.Add(e);
            timeIntervalOfProduct = new();
            if (instance.timeIntervalOfProduct != null) {
                timeIntervalOfProduct = new();
                timeIntervalOfProduct.Load(instance.timeIntervalOfProduct);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S128.FeatureTypes.S100Service
            {
                compressionFlag = this.compressionFlag,
                serviceName = this.serviceName,
                serviceStatus = this.serviceStatus,
                typeOfProductFormat = this.typeOfProductFormat,
                serviceSpecification = this.serviceSpecification?.Model,
                productSpecification = this.productSpecification?.Model,
                agencyResponsibleForProduction = this.agencyResponsibleForProduction,
                catalogueElementClassification = this.catalogueElementClassification.ToList(),
                catalogueElementIdentifier = this.catalogueElementIdentifier,
                classification = this.classification,
                IMOMaritimeService = this.IMOMaritimeService.ToList(),
                notForNavigation = this.notForNavigation,
                featureName = this.featureName.ToList(),
                information = this.information.ToList(),
                onlineResource = this.onlineResource?.Model,
                sourceIndication = this.sourceIndication?.Model,
                supportFile = this.supportFile.ToList(),
                timeIntervalOfProduct = this.timeIntervalOfProduct?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S128.FeatureTypes.S100Service Model => new()
        {
            compressionFlag = this._compressionFlag,
            serviceName = this._serviceName,
            serviceStatus = this._serviceStatus,
            typeOfProductFormat = this._typeOfProductFormat,
            serviceSpecification = this._serviceSpecification?.Model,
            productSpecification = this._productSpecification?.Model,
            agencyResponsibleForProduction = this._agencyResponsibleForProduction,
            catalogueElementClassification = this.catalogueElementClassification.ToList(),
            catalogueElementIdentifier = this._catalogueElementIdentifier,
            classification = this._classification,
            IMOMaritimeService = this.IMOMaritimeService.ToList(),
            notForNavigation = this._notForNavigation,
            featureName = this.featureName.ToList(),
            information = this.information.ToList(),
            onlineResource = this._onlineResource?.Model,
            sourceIndication = this._sourceIndication?.Model,
            supportFile = this.supportFile.ToList(),
            timeIntervalOfProduct = this._timeIntervalOfProduct?.Model,
        };

        public S100ServiceViewModel() : base() {
            catalogueElementClassification.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(catalogueElementClassification));
            };
            IMOMaritimeService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(IMOMaritimeService));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            supportFile.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(supportFile));
            };
        }

        public override string? ToString() => $"S100 Service";
    }

    public class ProductMappingViewModel : FeatureAssociationViewModel {
        public override string Code => "ProductMapping";
        public override string[] Roles => ["theSource", "theReference"];

        private FeatureBindingViewModel? _theSource;
        [ExpandableObject]
        public FeatureBindingViewModel? theSource {
            get {
                return _theSource;
            }

            set {
                this.SetValue(ref _theSource, value);
            }
        }

        private FeatureBindingViewModel? _theReference;
        [ExpandableObject]
        public FeatureBindingViewModel? theReference {
            get {
                return _theReference;
            }

            set {
                this.SetValue(ref _theReference, value);
            }
        }

        public override FeatureAssociationConnector? associationConnector {
            get {
                return _associationConnector;
            }

            set {
                this.SetValue(ref _associationConnector, value);
                theReference = null;
                if (value is not null) {
                    theReference = value?.role switch
                    {
                        "theSource" => value.CreateForeignFeatureBinding(),
                        _ => value.CreateLocalFeatureBinding(),
                    };
                }
            }
        }

        public override void Load(S100Framework.DomainModel.FeatureAssociation featureAssociation) {
            associationConnector = associationConnectorFeatures.Single(e => e.FeatureType.Equals(featureAssociation.AssociationConnectorTypeName));
            theSource?.Load(featureAssociation, "theSource");
            theReference?.Load(featureAssociation, "theReference");
        }

        public override string Serialize() {
            var instance = new FeatureAssociation
            {
                Code = this.Code,
                AssociationConnectorTypeName = associationConnector!.FeatureType,
            };
            theSource?.Save(instance, "theSource");
            theReference?.Save(instance, "theReference");
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public override FeatureAssociationConnector[] associationConnectorFeatures => ProductMappingViewModel._associationConnectorFeatures;

        public class theReferenceElectronicProductRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["ElectronicProduct", "PhysicalProduct", "S100Service"];
        }

        public class theReferencePhysicalProductRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["ElectronicProduct", "PhysicalProduct", "S100Service"];
        }

        public class theReferenceS100ServiceRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["ElectronicProduct", "PhysicalProduct", "S100Service"];
        }

        public static FeatureAssociationConnector[] _associationConnectorFeatures => Handles.AssociationConnectorFeatures[typeof(ProductMappingViewModel)]();
    }

    public class CorrelatedViewModel : FeatureAssociationViewModel {
        public override string Code => "Correlated";
        public override string[] Roles => ["main", "panel"];

        private FeatureBindingViewModel? _main;
        [ExpandableObject]
        public FeatureBindingViewModel? main {
            get {
                return _main;
            }

            set {
                this.SetValue(ref _main, value);
            }
        }

        private FeatureBindingViewModel? _panel;
        [ExpandableObject]
        public FeatureBindingViewModel? panel {
            get {
                return _panel;
            }

            set {
                this.SetValue(ref _panel, value);
            }
        }

        public override FeatureAssociationConnector? associationConnector {
            get {
                return _associationConnector;
            }

            set {
                this.SetValue(ref _associationConnector, value);
                main = null;
                if (value is not null) {
                    main = value?.role switch
                    {
                        "panel" => value.CreateForeignFeatureBinding(),
                        _ => value.CreateLocalFeatureBinding(),
                    };
                }
            }
        }

        public override void Load(S100Framework.DomainModel.FeatureAssociation featureAssociation) {
            associationConnector = associationConnectorFeatures.Single(e => e.FeatureType.Equals(featureAssociation.AssociationConnectorTypeName));
            main?.Load(featureAssociation, "main");
            panel?.Load(featureAssociation, "panel");
        }

        public override string Serialize() {
            var instance = new FeatureAssociation
            {
                Code = this.Code,
                AssociationConnectorTypeName = associationConnector!.FeatureType,
            };
            main?.Save(instance, "main");
            panel?.Save(instance, "panel");
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public override FeatureAssociationConnector[] associationConnectorFeatures => CorrelatedViewModel._associationConnectorFeatures;

        public class mainElectronicProductRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["ElectronicProduct", "PhysicalProduct"];
        }

        public class mainPhysicalProductRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["ElectronicProduct", "PhysicalProduct"];
        }

        public static FeatureAssociationConnector[] _associationConnectorFeatures => Handles.AssociationConnectorFeatures[typeof(CorrelatedViewModel)]();
    }

    public class CarriageRequirementViewModel : InformationAssociationViewModel {
        public override string Code => "CarriageRequirement";
        public override string[] Roles => ["theElement", "theRequirement"];

        private InformationBindingViewModel? _theElement;
        [ExpandableObject]
        public InformationBindingViewModel? theElement {
            get {
                return _theElement;
            }

            set {
                this.SetValue(ref _theElement, value);
            }
        }

        private InformationBindingViewModel? _theRequirement;
        [ExpandableObject]
        public InformationBindingViewModel? theRequirement {
            get {
                return _theRequirement;
            }

            set {
                this.SetValue(ref _theRequirement, value);
            }
        }

        public override InformationAssociationConnector? associationConnector {
            get {
                return _associationConnector;
            }

            set {
                this.SetValue(ref _associationConnector, value);
                theElement = null;
                if (value is not null) {
                    theElement = value?.role switch
                    {
                        "theRequirement" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                theRequirement = null;
                if (value is not null) {
                    theRequirement = value?.role switch
                    {
                        "theElement" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override void Load(S100Framework.DomainModel.InformationAssociation informationAssociation) {
            associationConnector = associationConnectorInformations.Single(e => e.InformationType.Equals(informationAssociation.AssociationConnectorTypeName));
            theElement?.Load(informationAssociation, "theElement");
            theRequirement?.Load(informationAssociation, "theRequirement");
        }

        public override string Serialize() {
            var instance = new InformationAssociation
            {
                Code = this.Code,
                AssociationConnectorTypeName = associationConnector!.InformationType,
            };
            theElement?.Save(instance, "theElement");
            theRequirement?.Save(instance, "theRequirement");
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public override InformationAssociationConnector[] associationConnectorInformations => CarriageRequirementViewModel._associationConnectorInformations;

        public class theRequirementElectronicProductRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["IndicationOfCarriageRequirement"];
        }

        public class theRequirementPhysicalProductRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["IndicationOfCarriageRequirement"];
        }

        public class theRequirementS100ServiceRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["IndicationOfCarriageRequirement"];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(CarriageRequirementViewModel)]();
    }

    public class DistributionDetailsViewModel : InformationAssociationViewModel {
        public override string Code => "DistributionDetails";
        public override string[] Roles => ["catalogueHeader", "theDistributor"];

        private InformationBindingViewModel? _catalogueHeader;
        [ExpandableObject]
        public InformationBindingViewModel? catalogueHeader {
            get {
                return _catalogueHeader;
            }

            set {
                this.SetValue(ref _catalogueHeader, value);
            }
        }

        private InformationBindingViewModel? _theDistributor;
        [ExpandableObject]
        public InformationBindingViewModel? theDistributor {
            get {
                return _theDistributor;
            }

            set {
                this.SetValue(ref _theDistributor, value);
            }
        }

        public override InformationAssociationConnector? associationConnector {
            get {
                return _associationConnector;
            }

            set {
                this.SetValue(ref _associationConnector, value);
                catalogueHeader = null;
                if (value is not null) {
                    catalogueHeader = value?.role switch
                    {
                        "theDistributor" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                theDistributor = null;
                if (value is not null) {
                    theDistributor = value?.role switch
                    {
                        "catalogueHeader" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override void Load(S100Framework.DomainModel.InformationAssociation informationAssociation) {
            associationConnector = associationConnectorInformations.Single(e => e.InformationType.Equals(informationAssociation.AssociationConnectorTypeName));
            catalogueHeader?.Load(informationAssociation, "catalogueHeader");
            theDistributor?.Load(informationAssociation, "theDistributor");
        }

        public override string Serialize() {
            var instance = new InformationAssociation
            {
                Code = this.Code,
                AssociationConnectorTypeName = associationConnector!.InformationType,
            };
            catalogueHeader?.Save(instance, "catalogueHeader");
            theDistributor?.Save(instance, "theDistributor");
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public override InformationAssociationConnector[] associationConnectorInformations => DistributionDetailsViewModel._associationConnectorInformations;

        public class catalogueHeaderDistributorInformationRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["CatalogueSectionHeader"];
        }

        public class theDistributorCatalogueSectionHeaderRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["DistributorInformation"];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(DistributionDetailsViewModel)]();
    }

    public class DistributorContactViewModel : InformationAssociationViewModel {
        public override string Code => "DistributorContact";
        public override string[] Roles => ["theDistributor", "theContactDetails"];

        private InformationBindingViewModel? _theDistributor;
        [ExpandableObject]
        public InformationBindingViewModel? theDistributor {
            get {
                return _theDistributor;
            }

            set {
                this.SetValue(ref _theDistributor, value);
            }
        }

        private InformationBindingViewModel? _theContactDetails;
        [ExpandableObject]
        public InformationBindingViewModel? theContactDetails {
            get {
                return _theContactDetails;
            }

            set {
                this.SetValue(ref _theContactDetails, value);
            }
        }

        public override InformationAssociationConnector? associationConnector {
            get {
                return _associationConnector;
            }

            set {
                this.SetValue(ref _associationConnector, value);
                theDistributor = null;
                if (value is not null) {
                    theDistributor = value?.role switch
                    {
                        "theContactDetails" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                theContactDetails = null;
                if (value is not null) {
                    theContactDetails = value?.role switch
                    {
                        "theDistributor" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override void Load(S100Framework.DomainModel.InformationAssociation informationAssociation) {
            associationConnector = associationConnectorInformations.Single(e => e.InformationType.Equals(informationAssociation.AssociationConnectorTypeName));
            theDistributor?.Load(informationAssociation, "theDistributor");
            theContactDetails?.Load(informationAssociation, "theContactDetails");
        }

        public override string Serialize() {
            var instance = new InformationAssociation
            {
                Code = this.Code,
                AssociationConnectorTypeName = associationConnector!.InformationType,
            };
            theDistributor?.Save(instance, "theDistributor");
            theContactDetails?.Save(instance, "theContactDetails");
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public override InformationAssociationConnector[] associationConnectorInformations => DistributorContactViewModel._associationConnectorInformations;

        public class theContactDetailsDistributorInformationRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["ContactDetails"];
        }

        public class theDistributorContactDetailsRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["DistributorInformation"];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(DistributorContactViewModel)]();
    }

    public class PriceOfElementViewModel : InformationAssociationViewModel {
        public override string Code => "PriceOfElement";
        public override string[] Roles => ["theCatalogueElement", "thePriceInformation"];

        private InformationBindingViewModel? _theCatalogueElement;
        [ExpandableObject]
        public InformationBindingViewModel? theCatalogueElement {
            get {
                return _theCatalogueElement;
            }

            set {
                this.SetValue(ref _theCatalogueElement, value);
            }
        }

        private InformationBindingViewModel? _thePriceInformation;
        [ExpandableObject]
        public InformationBindingViewModel? thePriceInformation {
            get {
                return _thePriceInformation;
            }

            set {
                this.SetValue(ref _thePriceInformation, value);
            }
        }

        public override InformationAssociationConnector? associationConnector {
            get {
                return _associationConnector;
            }

            set {
                this.SetValue(ref _associationConnector, value);
                theCatalogueElement = null;
                if (value is not null) {
                    theCatalogueElement = value?.role switch
                    {
                        "thePriceInformation" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                thePriceInformation = null;
                if (value is not null) {
                    thePriceInformation = value?.role switch
                    {
                        "theCatalogueElement" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override void Load(S100Framework.DomainModel.InformationAssociation informationAssociation) {
            associationConnector = associationConnectorInformations.Single(e => e.InformationType.Equals(informationAssociation.AssociationConnectorTypeName));
            theCatalogueElement?.Load(informationAssociation, "theCatalogueElement");
            thePriceInformation?.Load(informationAssociation, "thePriceInformation");
        }

        public override string Serialize() {
            var instance = new InformationAssociation
            {
                Code = this.Code,
                AssociationConnectorTypeName = associationConnector!.InformationType,
            };
            theCatalogueElement?.Save(instance, "theCatalogueElement");
            thePriceInformation?.Save(instance, "thePriceInformation");
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public override InformationAssociationConnector[] associationConnectorInformations => PriceOfElementViewModel._associationConnectorInformations;

        public class thePriceInformationElectronicProductRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["PriceInformation"];
        }

        public class thePriceInformationPhysicalProductRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["PriceInformation"];
        }

        public class thePriceInformationS100ServiceRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["PriceInformation"];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(PriceOfElementViewModel)]();
    }

    public class PriceOfNauticalProductViewModel : InformationAssociationViewModel {
        public override string Code => "PriceOfNauticalProduct";
        public override string[] Roles => ["theCatalogueOfNauticalProduct", "thePriceInformation"];

        private InformationBindingViewModel? _theCatalogueOfNauticalProduct;
        [ExpandableObject]
        public InformationBindingViewModel? theCatalogueOfNauticalProduct {
            get {
                return _theCatalogueOfNauticalProduct;
            }

            set {
                this.SetValue(ref _theCatalogueOfNauticalProduct, value);
            }
        }

        private InformationBindingViewModel? _thePriceInformation;
        [ExpandableObject]
        public InformationBindingViewModel? thePriceInformation {
            get {
                return _thePriceInformation;
            }

            set {
                this.SetValue(ref _thePriceInformation, value);
            }
        }

        public override InformationAssociationConnector? associationConnector {
            get {
                return _associationConnector;
            }

            set {
                this.SetValue(ref _associationConnector, value);
                theCatalogueOfNauticalProduct = null;
                if (value is not null) {
                    theCatalogueOfNauticalProduct = value?.role switch
                    {
                        "thePriceInformation" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                thePriceInformation = null;
                if (value is not null) {
                    thePriceInformation = value?.role switch
                    {
                        "theCatalogueOfNauticalProduct" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override void Load(S100Framework.DomainModel.InformationAssociation informationAssociation) {
            associationConnector = associationConnectorInformations.Single(e => e.InformationType.Equals(informationAssociation.AssociationConnectorTypeName));
            theCatalogueOfNauticalProduct?.Load(informationAssociation, "theCatalogueOfNauticalProduct");
            thePriceInformation?.Load(informationAssociation, "thePriceInformation");
        }

        public override string Serialize() {
            var instance = new InformationAssociation
            {
                Code = this.Code,
                AssociationConnectorTypeName = associationConnector!.InformationType,
            };
            theCatalogueOfNauticalProduct?.Save(instance, "theCatalogueOfNauticalProduct");
            thePriceInformation?.Save(instance, "thePriceInformation");
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public override InformationAssociationConnector[] associationConnectorInformations => PriceOfNauticalProductViewModel._associationConnectorInformations;

        public class theCatalogueOfNauticalProductPriceInformationRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["CatalogueSectionHeader"];
        }

        public class thePriceInformationCatalogueSectionHeaderRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["PriceInformation"];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(PriceOfNauticalProductViewModel)]();
    }

    public class ProducerContactViewModel : InformationAssociationViewModel {
        public override string Code => "ProducerContact";
        public override string[] Roles => ["theProducer", "theContactDetails"];

        private InformationBindingViewModel? _theProducer;
        [ExpandableObject]
        public InformationBindingViewModel? theProducer {
            get {
                return _theProducer;
            }

            set {
                this.SetValue(ref _theProducer, value);
            }
        }

        private InformationBindingViewModel? _theContactDetails;
        [ExpandableObject]
        public InformationBindingViewModel? theContactDetails {
            get {
                return _theContactDetails;
            }

            set {
                this.SetValue(ref _theContactDetails, value);
            }
        }

        public override InformationAssociationConnector? associationConnector {
            get {
                return _associationConnector;
            }

            set {
                this.SetValue(ref _associationConnector, value);
                theProducer = null;
                if (value is not null) {
                    theProducer = value?.role switch
                    {
                        "theContactDetails" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                theContactDetails = null;
                if (value is not null) {
                    theContactDetails = value?.role switch
                    {
                        "theProducer" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override void Load(S100Framework.DomainModel.InformationAssociation informationAssociation) {
            associationConnector = associationConnectorInformations.Single(e => e.InformationType.Equals(informationAssociation.AssociationConnectorTypeName));
            theProducer?.Load(informationAssociation, "theProducer");
            theContactDetails?.Load(informationAssociation, "theContactDetails");
        }

        public override string Serialize() {
            var instance = new InformationAssociation
            {
                Code = this.Code,
                AssociationConnectorTypeName = associationConnector!.InformationType,
            };
            theProducer?.Save(instance, "theProducer");
            theContactDetails?.Save(instance, "theContactDetails");
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public override InformationAssociationConnector[] associationConnectorInformations => ProducerContactViewModel._associationConnectorInformations;

        public class theContactDetailsProducerInformationRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["ContactDetails"];
        }

        public class theProducerContactDetailsRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["ProducerInformation"];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(ProducerContactViewModel)]();
    }

    public class ProductionDetailsViewModel : InformationAssociationViewModel {
        public override string Code => "ProductionDetails";
        public override string[] Roles => ["catalogueHeader", "theProducer"];

        private InformationBindingViewModel? _catalogueHeader;
        [ExpandableObject]
        public InformationBindingViewModel? catalogueHeader {
            get {
                return _catalogueHeader;
            }

            set {
                this.SetValue(ref _catalogueHeader, value);
            }
        }

        private InformationBindingViewModel? _theProducer;
        [ExpandableObject]
        public InformationBindingViewModel? theProducer {
            get {
                return _theProducer;
            }

            set {
                this.SetValue(ref _theProducer, value);
            }
        }

        public override InformationAssociationConnector? associationConnector {
            get {
                return _associationConnector;
            }

            set {
                this.SetValue(ref _associationConnector, value);
                catalogueHeader = null;
                if (value is not null) {
                    catalogueHeader = value?.role switch
                    {
                        "theProducer" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                theProducer = null;
                if (value is not null) {
                    theProducer = value?.role switch
                    {
                        "catalogueHeader" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override void Load(S100Framework.DomainModel.InformationAssociation informationAssociation) {
            associationConnector = associationConnectorInformations.Single(e => e.InformationType.Equals(informationAssociation.AssociationConnectorTypeName));
            catalogueHeader?.Load(informationAssociation, "catalogueHeader");
            theProducer?.Load(informationAssociation, "theProducer");
        }

        public override string Serialize() {
            var instance = new InformationAssociation
            {
                Code = this.Code,
                AssociationConnectorTypeName = associationConnector!.InformationType,
            };
            catalogueHeader?.Save(instance, "catalogueHeader");
            theProducer?.Save(instance, "theProducer");
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public override InformationAssociationConnector[] associationConnectorInformations => ProductionDetailsViewModel._associationConnectorInformations;

        public class catalogueHeaderProducerInformationRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["CatalogueSectionHeader"];
        }

        public class theProducerCatalogueSectionHeaderRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["ProducerInformation"];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(ProductionDetailsViewModel)]();
    }

    public class ProductPackageViewModel : InformationAssociationViewModel {
        public override string Code => "ProductPackage";
        public override string[] Roles => ["theCatalogueElement", "elementContainer"];

        private InformationBindingViewModel? _theCatalogueElement;
        [ExpandableObject]
        public InformationBindingViewModel? theCatalogueElement {
            get {
                return _theCatalogueElement;
            }

            set {
                this.SetValue(ref _theCatalogueElement, value);
            }
        }

        private InformationBindingViewModel? _elementContainer;
        [ExpandableObject]
        public InformationBindingViewModel? elementContainer {
            get {
                return _elementContainer;
            }

            set {
                this.SetValue(ref _elementContainer, value);
            }
        }

        public override InformationAssociationConnector? associationConnector {
            get {
                return _associationConnector;
            }

            set {
                this.SetValue(ref _associationConnector, value);
                theCatalogueElement = null;
                if (value is not null) {
                    theCatalogueElement = value?.role switch
                    {
                        "elementContainer" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                elementContainer = null;
                if (value is not null) {
                    elementContainer = value?.role switch
                    {
                        "theCatalogueElement" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override void Load(S100Framework.DomainModel.InformationAssociation informationAssociation) {
            associationConnector = associationConnectorInformations.Single(e => e.InformationType.Equals(informationAssociation.AssociationConnectorTypeName));
            theCatalogueElement?.Load(informationAssociation, "theCatalogueElement");
            elementContainer?.Load(informationAssociation, "elementContainer");
        }

        public override string Serialize() {
            var instance = new InformationAssociation
            {
                Code = this.Code,
                AssociationConnectorTypeName = associationConnector!.InformationType,
            };
            theCatalogueElement?.Save(instance, "theCatalogueElement");
            elementContainer?.Save(instance, "elementContainer");
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public override InformationAssociationConnector[] associationConnectorInformations => ProductPackageViewModel._associationConnectorInformations;

        public class elementContainerElectronicProductRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["CatalogueSectionHeader"];
        }

        public class elementContainerPhysicalProductRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["CatalogueSectionHeader"];
        }

        public class elementContainerS100ServiceRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["CatalogueSectionHeader"];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(ProductPackageViewModel)]();
    }
}