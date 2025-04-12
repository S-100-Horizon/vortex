using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Reflection;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S131;
using S100Framework.DomainModel.S131.ComplexAttributes;
using S100Framework.DomainModel.S131.InformationTypes;
using S100Framework.DomainModel.S131.FeatureTypes;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

#nullable enable
namespace S100Framework.WPF.ViewModel.S131 {
    internal static class Bootstrap {
        public static AssociationViewModel CreateInformationAssociation(string type, string? pid = default) => type switch
        {
            "AdditionalInformation" => new AdditionalInformationViewModel
            {
                PID = pid
            },
            "AuthorityContact" => new AuthorityContactViewModel
            {
                PID = pid
            },
            "AuthorityHours" => new AuthorityHoursViewModel
            {
                PID = pid
            },
            "AssociatedRxN" => new AssociatedRxNViewModel
            {
                PID = pid
            },
            "ExceptionalWorkday" => new ExceptionalWorkdayViewModel
            {
                PID = pid
            },
            "ServiceControl" => new ServiceControlViewModel
            {
                PID = pid
            },
            "ServiceContact" => new ServiceContactViewModel
            {
                PID = pid
            },
            "LocationHours" => new LocationHoursViewModel
            {
                PID = pid
            },
            "RelatedOrganisation" => new RelatedOrganisationViewModel
            {
                PID = pid
            },
            "InclusionType" => new InclusionTypeViewModel
            {
                PID = pid
            },
            "PermissionType" => new PermissionTypeViewModel
            {
                PID = pid
            },
            "LimitEntrance" => new LimitEntranceViewModel
            {
                PID = pid
            },
            "ServiceAvailability" => new ServiceAvailabilityViewModel
            {
                PID = pid
            },
            _ => throw new InvalidOperationException(),
        };
        public static AssociationViewModel CreateFeatureAssociation(string type, string? pid = default) => type switch
        {
            "TextAssociation" => new TextAssociationViewModel
            {
                PID = pid
            },
            "Subsection" => new SubsectionViewModel
            {
                PID = pid
            },
            "Infrastructure" => new InfrastructureViewModel
            {
                PID = pid
            },
            "PrimaryAuxiliaryFacility" => new PrimaryAuxiliaryFacilityViewModel
            {
                PID = pid
            },
            "Demarcation" => new DemarcationViewModel
            {
                PID = pid
            },
            "JurisdictionalLimit" => new JurisdictionalLimitViewModel
            {
                PID = pid
            },
            "LayoutDivision" => new LayoutDivisionViewModel
            {
                PID = pid
            },
            _ => throw new InvalidOperationException(),
        };
        public static InformationViewModel CreateInformationType(string type, string? pid = default) => type switch
        {
            "Applicability" => new ApplicabilityViewModel
            {
                PID = pid
            },
            "Authority" => new AuthorityViewModel
            {
                PID = pid
            },
            "AvailablePortServices" => new AvailablePortServicesViewModel
            {
                PID = pid
            },
            "ContactDetails" => new ContactDetailsViewModel
            {
                PID = pid
            },
            "Entrance" => new EntranceViewModel
            {
                PID = pid
            },
            "NauticalInformation" => new NauticalInformationViewModel
            {
                PID = pid
            },
            "NonStandardWorkingDay" => new NonStandardWorkingDayViewModel
            {
                PID = pid
            },
            "Recommendations" => new RecommendationsViewModel
            {
                PID = pid
            },
            "Regulations" => new RegulationsViewModel
            {
                PID = pid
            },
            "Restrictions" => new RestrictionsViewModel
            {
                PID = pid
            },
            "ServiceHours" => new ServiceHoursViewModel
            {
                PID = pid
            },
            "SpatialQuality" => new SpatialQualityViewModel
            {
                PID = pid
            },
            _ => throw new InvalidOperationException(),
        };
        public static FeatureViewModel CreateFeatureType(string type, string? pid = default) => type switch
        {
            "AnchorBerth" => new AnchorBerthViewModel
            {
                PID = pid
            },
            "AnchorageArea" => new AnchorageAreaViewModel
            {
                PID = pid
            },
            "Berth" => new BerthViewModel
            {
                PID = pid
            },
            "BerthPosition" => new BerthPositionViewModel
            {
                PID = pid
            },
            "DockArea" => new DockAreaViewModel
            {
                PID = pid
            },
            "DryDock" => new DryDockViewModel
            {
                PID = pid
            },
            "DumpingGround" => new DumpingGroundViewModel
            {
                PID = pid
            },
            "FloatingDock" => new FloatingDockViewModel
            {
                PID = pid
            },
            "Gridiron" => new GridironViewModel
            {
                PID = pid
            },
            "HarbourAreaAdministrative" => new HarbourAreaAdministrativeViewModel
            {
                PID = pid
            },
            "HarbourAreaSection" => new HarbourAreaSectionViewModel
            {
                PID = pid
            },
            "HarbourBasin" => new HarbourBasinViewModel
            {
                PID = pid
            },
            "HarbourFacility" => new HarbourFacilityViewModel
            {
                PID = pid
            },
            "MooringWarpingFacility" => new MooringWarpingFacilityViewModel
            {
                PID = pid
            },
            "OuterLimit" => new OuterLimitViewModel
            {
                PID = pid
            },
            "PilotBoardingPlace" => new PilotBoardingPlaceViewModel
            {
                PID = pid
            },
            "SeaplaneLandingArea" => new SeaplaneLandingAreaViewModel
            {
                PID = pid
            },
            "Terminal" => new TerminalViewModel
            {
                PID = pid
            },
            "TurningBasin" => new TurningBasinViewModel
            {
                PID = pid
            },
            "WaterwayArea" => new WaterwayAreaViewModel
            {
                PID = pid
            },
            "DataCoverage" => new DataCoverageViewModel
            {
                PID = pid
            },
            "QualityOfNonBathymetricData" => new QualityOfNonBathymetricDataViewModel
            {
                PID = pid
            },
            "SoundingDatum" => new SoundingDatumViewModel
            {
                PID = pid
            },
            "VerticalDatumOfData" => new VerticalDatumOfDataViewModel
            {
                PID = pid
            },
            "TextPlacement" => new TextPlacementViewModel
            {
                PID = pid
            },
            _ => throw new InvalidOperationException(),
        };
    }

    [CategoryOrder("contactAddress", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class contactAddressViewModel : ViewModelBase {
        [Category("contactAddress")]
        public ObservableCollection<String> deliveryPoint { get; set; } = new();

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

        public void Load(DomainModel.S131.ComplexAttributes.contactAddress instance) {
            deliveryPoint.Clear();
            if (instance.deliveryPoint is not null)
                foreach (var e in instance.deliveryPoint)
                    deliveryPoint.Add(e);
            cityName = instance.cityName;
            administrativeDivision = instance.administrativeDivision;
            countryName = instance.countryName;
            postalCode = instance.postalCode;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.contactAddress
            {
                deliveryPoint = this.deliveryPoint.ToList(),
                cityName = this.cityName,
                administrativeDivision = this.administrativeDivision,
                countryName = this.countryName,
                postalCode = this.postalCode,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.contactAddress Model => new()
        {
            deliveryPoint = this.deliveryPoint.ToList(),
            cityName = this._cityName,
            administrativeDivision = this._administrativeDivision,
            countryName = this._countryName,
            postalCode = this._postalCode,
        };

        public contactAddressViewModel() : base() {
            deliveryPoint.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(deliveryPoint));
            };
        }

        public override string? ToString() => $"Contact Address";
    }

    [CategoryOrder("featureName", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class featureNameViewModel : ViewModelBase {
        private Boolean? _displayName = default;
        [Category("featureName")]
        public Boolean? displayName {
            get {
                return _displayName;
            }

            set {
                SetValue(ref _displayName, value);
            }
        }

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

        public void Load(DomainModel.S131.ComplexAttributes.featureName instance) {
            displayName = instance.displayName;
            language = instance.language;
            name = instance.name;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.featureName
            {
                displayName = this.displayName,
                language = this.language,
                name = this.name,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.featureName Model => new()
        {
            displayName = this._displayName,
            language = this._language,
            name = this._name,
        };

        public featureNameViewModel() : base() {
        }

        public override string? ToString() => $"Feature Name";
    }

    [CategoryOrder("fixedDateRange", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class fixedDateRangeViewModel : ViewModelBase {
        private DateOnly? _dateStart = default;
        [Category("fixedDateRange")]
        public DateOnly? dateStart {
            get {
                return _dateStart;
            }

            set {
                SetValue(ref _dateStart, value);
            }
        }

        private DateOnly? _dateEnd = default;
        [Category("fixedDateRange")]
        public DateOnly? dateEnd {
            get {
                return _dateEnd;
            }

            set {
                SetValue(ref _dateEnd, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.fixedDateRange instance) {
            dateStart = instance.dateStart;
            dateEnd = instance.dateEnd;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.fixedDateRange
            {
                dateStart = this.dateStart,
                dateEnd = this.dateEnd,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.fixedDateRange Model => new()
        {
            dateStart = this._dateStart,
            dateEnd = this._dateEnd,
        };

        public fixedDateRangeViewModel() : base() {
        }

        public override string? ToString() => $"Fixed Date Range";
    }

    [CategoryOrder("frequencyPair", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class frequencyPairViewModel : ViewModelBase {
        [Category("frequencyPair")]
        public ObservableCollection<Int32> frequencyShoreStationTransmits { get; set; } = new();

        [Category("frequencyPair")]
        public ObservableCollection<Int32> frequencyShoreStationReceives { get; set; } = new();

        [Category("frequencyPair")]
        public ObservableCollection<String> contactInstructions { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.frequencyPair instance) {
            frequencyShoreStationTransmits.Clear();
            if (instance.frequencyShoreStationTransmits is not null)
                foreach (var e in instance.frequencyShoreStationTransmits)
                    frequencyShoreStationTransmits.Add(e);
            frequencyShoreStationReceives.Clear();
            if (instance.frequencyShoreStationReceives is not null)
                foreach (var e in instance.frequencyShoreStationReceives)
                    frequencyShoreStationReceives.Add(e);
            contactInstructions.Clear();
            if (instance.contactInstructions is not null)
                foreach (var e in instance.contactInstructions)
                    contactInstructions.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.frequencyPair
            {
                frequencyShoreStationTransmits = this.frequencyShoreStationTransmits.ToList(),
                frequencyShoreStationReceives = this.frequencyShoreStationReceives.ToList(),
                contactInstructions = this.contactInstructions.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.frequencyPair Model => new()
        {
            frequencyShoreStationTransmits = this.frequencyShoreStationTransmits.ToList(),
            frequencyShoreStationReceives = this.frequencyShoreStationReceives.ToList(),
            contactInstructions = this.contactInstructions.ToList(),
        };

        public frequencyPairViewModel() : base() {
            frequencyShoreStationTransmits.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(frequencyShoreStationTransmits));
            };
            frequencyShoreStationReceives.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(frequencyShoreStationReceives));
            };
            contactInstructions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(contactInstructions));
            };
        }

        public override string? ToString() => $"Frequency Pair";
    }

    [CategoryOrder("horizontalPositionUncertainty", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class horizontalPositionUncertaintyViewModel : ViewModelBase {
        private Decimal _uncertaintyFixed;
        [Category("horizontalPositionUncertainty")]
        public Decimal uncertaintyFixed {
            get {
                return _uncertaintyFixed;
            }

            set {
                SetValue(ref _uncertaintyFixed, value);
            }
        }

        private Decimal? _uncertaintyVariableFactor = default;
        [Category("horizontalPositionUncertainty")]
        public Decimal? uncertaintyVariableFactor {
            get {
                return _uncertaintyVariableFactor;
            }

            set {
                SetValue(ref _uncertaintyVariableFactor, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.horizontalPositionUncertainty instance) {
            uncertaintyFixed = instance.uncertaintyFixed;
            uncertaintyVariableFactor = instance.uncertaintyVariableFactor;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.horizontalPositionUncertainty
            {
                uncertaintyFixed = this.uncertaintyFixed,
                uncertaintyVariableFactor = this.uncertaintyVariableFactor,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.horizontalPositionUncertainty Model => new()
        {
            uncertaintyFixed = this._uncertaintyFixed,
            uncertaintyVariableFactor = this._uncertaintyVariableFactor,
        };

        public horizontalPositionUncertaintyViewModel() : base() {
        }

        public override string? ToString() => $"Horizontal Position Uncertainty";
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

        [Category("information")]
        public ObservableCollection<String> headline { get; set; } = new();

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

        private String _text = string.Empty;
        [Category("information")]
        public String text {
            get {
                return _text;
            }

            set {
                SetValue(ref _text, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.information instance) {
            fileLocator = instance.fileLocator;
            fileReference = instance.fileReference;
            headline.Clear();
            if (instance.headline is not null)
                foreach (var e in instance.headline)
                    headline.Add(e);
            language = instance.language;
            text = instance.text;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.information
            {
                fileLocator = this.fileLocator,
                fileReference = this.fileReference,
                headline = this.headline.ToList(),
                language = this.language,
                text = this.text,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.information Model => new()
        {
            fileLocator = this._fileLocator,
            fileReference = this._fileReference,
            headline = this.headline.ToList(),
            language = this._language,
            text = this._text,
        };

        public informationViewModel() : base() {
            headline.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(headline));
            };
        }

        public override string? ToString() => $"Information";
    }

    [CategoryOrder("onlineResource", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class onlineResourceViewModel : ViewModelBase {
        private String _onlineResourceLinkageURL = string.Empty;
        [Category("onlineResource")]
        public String onlineResourceLinkageURL {
            get {
                return _onlineResourceLinkageURL;
            }

            set {
                SetValue(ref _onlineResourceLinkageURL, value);
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

        private String _onlineResourceDescription = string.Empty;
        [Category("onlineResource")]
        public String onlineResourceDescription {
            get {
                return _onlineResourceDescription;
            }

            set {
                SetValue(ref _onlineResourceDescription, value);
            }
        }

        private onlineFunction? _onlineFunction = default;
        [DomainModel.EnumerationAttribute(nameof(onlineFunctionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("onlineResource")]
        public onlineFunction? onlineFunction {
            get {
                return _onlineFunction;
            }

            set {
                SetValue(ref _onlineFunction, value);
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

        [Browsable(false)]
        public onlineFunction[] onlineFunctionList => [(onlineFunction)1, (onlineFunction)3, (onlineFunction)4, (onlineFunction)5, (onlineFunction)6, (onlineFunction)7, (onlineFunction)8, (onlineFunction)9, (onlineFunction)10, (onlineFunction)11];

        public void Load(DomainModel.S131.ComplexAttributes.onlineResource instance) {
            onlineResourceLinkageURL = instance.onlineResourceLinkageURL;
            protocol = instance.protocol;
            applicationProfile = instance.applicationProfile;
            nameOfResource = instance.nameOfResource;
            onlineResourceDescription = instance.onlineResourceDescription;
            onlineFunction = instance.onlineFunction;
            protocolRequest = instance.protocolRequest;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.onlineResource
            {
                onlineResourceLinkageURL = this.onlineResourceLinkageURL,
                protocol = this.protocol,
                applicationProfile = this.applicationProfile,
                nameOfResource = this.nameOfResource,
                onlineResourceDescription = this.onlineResourceDescription,
                onlineFunction = this.onlineFunction,
                protocolRequest = this.protocolRequest,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.onlineResource Model => new()
        {
            onlineResourceLinkageURL = this._onlineResourceLinkageURL,
            protocol = this._protocol,
            applicationProfile = this._applicationProfile,
            nameOfResource = this._nameOfResource,
            onlineResourceDescription = this._onlineResourceDescription,
            onlineFunction = this._onlineFunction,
            protocolRequest = this._protocolRequest,
        };

        public onlineResourceViewModel() : base() {
        }

        public override string? ToString() => $"Online Resource";
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("orientation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class orientationViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        private Decimal? _orientationUncertainty = default;
        [Category("orientation")]
        public Decimal? orientationUncertainty {
            get {
                return _orientationUncertainty;
            }

            set {
                SetValue(ref _orientationUncertainty, value);
            }
        }

        private Decimal _orientationValue;
        [Category("orientation")]
        public Decimal orientationValue {
            get {
                return _orientationValue;
            }

            set {
                SetValue(ref _orientationValue, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.orientation instance) {
            orientationUncertainty = instance.orientationUncertainty;
            orientationValue = instance.orientationValue;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.orientation
            {
                orientationUncertainty = this.orientationUncertainty,
                orientationValue = this.orientationValue,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.orientation Model => new()
        {
            orientationUncertainty = this._orientationUncertainty,
            orientationValue = this._orientationValue,
        };

        public orientationViewModel() : base() {
        }

        public override string? ToString() => $"Orientation";
    }

    [CategoryOrder("periodicDateRange", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class periodicDateRangeViewModel : ViewModelBase {
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

        public void Load(DomainModel.S131.ComplexAttributes.periodicDateRange instance) {
            dateStart = instance.dateStart;
            dateEnd = instance.dateEnd;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.periodicDateRange
            {
                dateStart = this.dateStart,
                dateEnd = this.dateEnd,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.periodicDateRange Model => new()
        {
            dateStart = this._dateStart,
            dateEnd = this._dateEnd,
        };

        public periodicDateRangeViewModel() : base() {
        }

        public override string? ToString() => $"Periodic Date Range";
    }

    [CategoryOrder("rxNCode", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class rxNCodeViewModel : ViewModelBase {
        private categoryOfRxN? _categoryOfRxN;
        [DomainModel.CodeList(nameof(categoryOfRxNList))]
        [Editor(typeof(Editors.CodeListComboEditor), typeof(Editors.CodeListComboEditor))]
        [Category("rxNCode")]
        public categoryOfRxN? categoryOfRxN {
            get {
                return _categoryOfRxN;
            }

            set {
                SetValue(ref _categoryOfRxN, value);
            }
        }

        private actionOrActivity? _actionOrActivity;
        [DomainModel.CodeList(nameof(actionOrActivityList))]
        [Editor(typeof(Editors.CodeListComboEditor), typeof(Editors.CodeListComboEditor))]
        [Category("rxNCode")]
        public actionOrActivity? actionOrActivity {
            get {
                return _actionOrActivity;
            }

            set {
                SetValue(ref _actionOrActivity, value);
            }
        }

        [Category("rxNCode")]
        public ObservableCollection<String> headline { get; set; } = new();

        [Browsable(false)]
        public categoryOfRxN[] categoryOfRxNList => CodeList.categoryOfRxNS.ToArray();

        [Browsable(false)]
        public actionOrActivity[] actionOrActivityList => CodeList.actionOrActivities.ToArray();

        public void Load(DomainModel.S131.ComplexAttributes.rxNCode instance) {
            categoryOfRxN = instance.categoryOfRxN;
            actionOrActivity = instance.actionOrActivity;
            headline.Clear();
            if (instance.headline is not null)
                foreach (var e in instance.headline)
                    headline.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.rxNCode
            {
                categoryOfRxN = this.categoryOfRxN,
                actionOrActivity = this.actionOrActivity,
                headline = this.headline.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.rxNCode Model => new()
        {
            categoryOfRxN = this._categoryOfRxN,
            actionOrActivity = this._actionOrActivity,
            headline = this.headline.ToList(),
        };

        public rxNCodeViewModel() : base() {
            headline.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(headline));
            };
        }

        public override string? ToString() => $"RxN Code";
    }

    [CategoryOrder("surveyDateRange", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class surveyDateRangeViewModel : ViewModelBase {
        private DateOnly? _dateStart = default;
        [Category("surveyDateRange")]
        public DateOnly? dateStart {
            get {
                return _dateStart;
            }

            set {
                SetValue(ref _dateStart, value);
            }
        }

        private DateOnly _dateEnd;
        [Category("surveyDateRange")]
        public DateOnly dateEnd {
            get {
                return _dateEnd;
            }

            set {
                SetValue(ref _dateEnd, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.surveyDateRange instance) {
            dateStart = instance.dateStart;
            dateEnd = instance.dateEnd;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.surveyDateRange
            {
                dateStart = this.dateStart,
                dateEnd = this.dateEnd,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.surveyDateRange Model => new()
        {
            dateStart = this._dateStart,
            dateEnd = this._dateEnd,
        };

        public surveyDateRangeViewModel() : base() {
        }

        public override string? ToString() => $"Survey Date Range";
    }

    [CategoryOrder("textContent", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class textContentViewModel : ViewModelBase {
        private categoryOfText? _categoryOfText = default;
        [DomainModel.EnumerationAttribute(nameof(categoryOfTextList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("textContent")]
        public categoryOfText? categoryOfText {
            get {
                return _categoryOfText;
            }

            set {
                SetValue(ref _categoryOfText, value);
            }
        }

        [Category("textContent")]
        public ObservableCollection<information> information { get; set; } = new();

        private onlineResourceViewModel? _onlineResource;
        [Category("textContent")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public onlineResourceViewModel? onlineResource {
            get {
                return _onlineResource;
            }

            set {
                SetValue(ref _onlineResource, value);
            }
        }

        private String _source = string.Empty;
        [Category("textContent")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("textContent")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("textContent")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Browsable(false)]
        public categoryOfText[] categoryOfTextList => [(categoryOfText)1, (categoryOfText)2, (categoryOfText)3];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public void Load(DomainModel.S131.ComplexAttributes.textContent instance) {
            categoryOfText = instance.categoryOfText;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            onlineResource = new();
            if (instance.onlineResource != null) {
                onlineResource = new();
                onlineResource.Load(instance.onlineResource);
            }

            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.textContent
            {
                categoryOfText = this.categoryOfText,
                information = this.information.ToList(),
                onlineResource = this.onlineResource?.Model,
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.textContent Model => new()
        {
            categoryOfText = this._categoryOfText,
            information = this.information.ToList(),
            onlineResource = this._onlineResource?.Model,
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public textContentViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Text Content";
    }

    [CategoryOrder("timeIntervalsByDayOfWeek", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class timeIntervalsByDayOfWeekViewModel : ViewModelBase {
        [DomainModel.EnumerationAttribute(nameof(dayOfWeekList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("timeIntervalsByDayOfWeek")]
        public ObservableCollection<dayOfWeek> dayOfWeek { get; set; } = new();

        private Boolean? _dayOfWeekIsRange = default;
        [Category("timeIntervalsByDayOfWeek")]
        public Boolean? dayOfWeekIsRange {
            get {
                return _dayOfWeekIsRange;
            }

            set {
                SetValue(ref _dayOfWeekIsRange, value);
            }
        }

        [Category("timeIntervalsByDayOfWeek")]
        public ObservableCollection<TimeOnly> timeOfDayStart { get; set; } = new();

        [Category("timeIntervalsByDayOfWeek")]
        public ObservableCollection<TimeOnly> timeOfDayEnd { get; set; } = new();

        [Browsable(false)]
        public dayOfWeek[] dayOfWeekList => [(dayOfWeek)1, (dayOfWeek)2, (dayOfWeek)3, (dayOfWeek)4, (dayOfWeek)5, (dayOfWeek)6, (dayOfWeek)7];

        public void Load(DomainModel.S131.ComplexAttributes.timeIntervalsByDayOfWeek instance) {
            dayOfWeek.Clear();
            if (instance.dayOfWeek is not null)
                foreach (var e in instance.dayOfWeek)
                    dayOfWeek.Add(e);
            dayOfWeekIsRange = instance.dayOfWeekIsRange;
            timeOfDayStart.Clear();
            if (instance.timeOfDayStart is not null)
                foreach (var e in instance.timeOfDayStart)
                    timeOfDayStart.Add(e);
            timeOfDayEnd.Clear();
            if (instance.timeOfDayEnd is not null)
                foreach (var e in instance.timeOfDayEnd)
                    timeOfDayEnd.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.timeIntervalsByDayOfWeek
            {
                dayOfWeek = this.dayOfWeek.ToList(),
                dayOfWeekIsRange = this.dayOfWeekIsRange,
                timeOfDayStart = this.timeOfDayStart.ToList(),
                timeOfDayEnd = this.timeOfDayEnd.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.timeIntervalsByDayOfWeek Model => new()
        {
            dayOfWeek = this.dayOfWeek.ToList(),
            dayOfWeekIsRange = this._dayOfWeekIsRange,
            timeOfDayStart = this.timeOfDayStart.ToList(),
            timeOfDayEnd = this.timeOfDayEnd.ToList(),
        };

        public timeIntervalsByDayOfWeekViewModel() : base() {
            dayOfWeek.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(dayOfWeek));
            };
            timeOfDayStart.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(timeOfDayStart));
            };
            timeOfDayEnd.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(timeOfDayEnd));
            };
        }

        public override string? ToString() => $"Time Intervals by Day of Week";
    }

    [CategoryOrder("usefulMarkDescription", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class usefulMarkDescriptionViewModel : ViewModelBase {
        [Category("usefulMarkDescription")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.usefulMarkDescription instance) {
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.usefulMarkDescription
            {
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.usefulMarkDescription Model => new()
        {
            textContent = this.textContent.ToList(),
        };

        public usefulMarkDescriptionViewModel() : base() {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Useful Mark Description";
    }

    [CategoryOrder("verticalUncertainty", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class verticalUncertaintyViewModel : ViewModelBase {
        private Decimal _uncertaintyFixed;
        [Category("verticalUncertainty")]
        public Decimal uncertaintyFixed {
            get {
                return _uncertaintyFixed;
            }

            set {
                SetValue(ref _uncertaintyFixed, value);
            }
        }

        private Decimal? _uncertaintyVariableFactor = default;
        [Category("verticalUncertainty")]
        public Decimal? uncertaintyVariableFactor {
            get {
                return _uncertaintyVariableFactor;
            }

            set {
                SetValue(ref _uncertaintyVariableFactor, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.verticalUncertainty instance) {
            uncertaintyFixed = instance.uncertaintyFixed;
            uncertaintyVariableFactor = instance.uncertaintyVariableFactor;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.verticalUncertainty
            {
                uncertaintyFixed = this.uncertaintyFixed,
                uncertaintyVariableFactor = this.uncertaintyVariableFactor,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.verticalUncertainty Model => new()
        {
            uncertaintyFixed = this._uncertaintyFixed,
            uncertaintyVariableFactor = this._uncertaintyVariableFactor,
        };

        public verticalUncertaintyViewModel() : base() {
        }

        public override string? ToString() => $"Vertical Uncertainty";
    }

    [CategoryOrder("vesselsMeasurements", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class vesselsMeasurementsViewModel : ViewModelBase {
        private comparisonOperator _comparisonOperator;
        [DomainModel.EnumerationAttribute(nameof(comparisonOperatorList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("vesselsMeasurements")]
        public comparisonOperator comparisonOperator {
            get {
                return _comparisonOperator;
            }

            set {
                SetValue(ref _comparisonOperator, value);
            }
        }

        private vesselsCharacteristics _vesselsCharacteristics;
        [DomainModel.EnumerationAttribute(nameof(vesselsCharacteristicsList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("vesselsMeasurements")]
        public vesselsCharacteristics vesselsCharacteristics {
            get {
                return _vesselsCharacteristics;
            }

            set {
                SetValue(ref _vesselsCharacteristics, value);
            }
        }

        private Decimal _vesselsCharacteristicsValue;
        [Category("vesselsMeasurements")]
        public Decimal vesselsCharacteristicsValue {
            get {
                return _vesselsCharacteristicsValue;
            }

            set {
                SetValue(ref _vesselsCharacteristicsValue, value);
            }
        }

        private vesselsCharacteristicsUnit _vesselsCharacteristicsUnit;
        [DomainModel.EnumerationAttribute(nameof(vesselsCharacteristicsUnitList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("vesselsMeasurements")]
        public vesselsCharacteristicsUnit vesselsCharacteristicsUnit {
            get {
                return _vesselsCharacteristicsUnit;
            }

            set {
                SetValue(ref _vesselsCharacteristicsUnit, value);
            }
        }

        [Browsable(false)]
        public comparisonOperator[] comparisonOperatorList => [(comparisonOperator)1, (comparisonOperator)2, (comparisonOperator)3, (comparisonOperator)4, (comparisonOperator)5, (comparisonOperator)6];

        [Browsable(false)]
        public vesselsCharacteristics[] vesselsCharacteristicsList => [(vesselsCharacteristics)1, (vesselsCharacteristics)2, (vesselsCharacteristics)3, (vesselsCharacteristics)4, (vesselsCharacteristics)6, (vesselsCharacteristics)7, (vesselsCharacteristics)8, (vesselsCharacteristics)9, (vesselsCharacteristics)10, (vesselsCharacteristics)11, (vesselsCharacteristics)12, (vesselsCharacteristics)13];

        [Browsable(false)]
        public vesselsCharacteristicsUnit[] vesselsCharacteristicsUnitList => [(vesselsCharacteristicsUnit)1, (vesselsCharacteristicsUnit)3, (vesselsCharacteristicsUnit)4, (vesselsCharacteristicsUnit)5, (vesselsCharacteristicsUnit)6, (vesselsCharacteristicsUnit)7, (vesselsCharacteristicsUnit)9];

        public void Load(DomainModel.S131.ComplexAttributes.vesselsMeasurements instance) {
            comparisonOperator = instance.comparisonOperator;
            vesselsCharacteristics = instance.vesselsCharacteristics;
            vesselsCharacteristicsValue = instance.vesselsCharacteristicsValue;
            vesselsCharacteristicsUnit = instance.vesselsCharacteristicsUnit;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.vesselsMeasurements
            {
                comparisonOperator = this.comparisonOperator,
                vesselsCharacteristics = this.vesselsCharacteristics,
                vesselsCharacteristicsValue = this.vesselsCharacteristicsValue,
                vesselsCharacteristicsUnit = this.vesselsCharacteristicsUnit,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.vesselsMeasurements Model => new()
        {
            comparisonOperator = this._comparisonOperator,
            vesselsCharacteristics = this._vesselsCharacteristics,
            vesselsCharacteristicsValue = this._vesselsCharacteristicsValue,
            vesselsCharacteristicsUnit = this._vesselsCharacteristicsUnit,
        };

        public vesselsMeasurementsViewModel() : base() {
        }

        public override string? ToString() => $"Vessels Measurements";
    }

    [CategoryOrder("weatherResource", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class weatherResourceViewModel : ViewModelBase {
        private onlineResourceViewModel? _onlineResource;
        [Category("weatherResource")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public onlineResourceViewModel? onlineResource {
            get {
                return _onlineResource;
            }

            set {
                SetValue(ref _onlineResource, value);
            }
        }

        private dynamicResource? _dynamicResource = default;
        [DomainModel.EnumerationAttribute(nameof(dynamicResourceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("weatherResource")]
        public dynamicResource? dynamicResource {
            get {
                return _dynamicResource;
            }

            set {
                SetValue(ref _dynamicResource, value);
            }
        }

        private textContentViewModel? _textContent;
        [Category("weatherResource")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public textContentViewModel? textContent {
            get {
                return _textContent;
            }

            set {
                SetValue(ref _textContent, value);
            }
        }

        [Browsable(false)]
        public dynamicResource[] dynamicResourceList => [(dynamicResource)1, (dynamicResource)2, (dynamicResource)3, (dynamicResource)4];

        public void Load(DomainModel.S131.ComplexAttributes.weatherResource instance) {
            onlineResource = new();
            if (instance.onlineResource != null) {
                onlineResource = new();
                onlineResource.Load(instance.onlineResource);
            }

            dynamicResource = instance.dynamicResource;
            textContent = new();
            if (instance.textContent != null) {
                textContent = new();
                textContent.Load(instance.textContent);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.weatherResource
            {
                onlineResource = this.onlineResource?.Model,
                dynamicResource = this.dynamicResource,
                textContent = this.textContent?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.weatherResource Model => new()
        {
            onlineResource = this._onlineResource?.Model,
            dynamicResource = this._dynamicResource,
            textContent = this._textContent?.Model,
        };

        public weatherResourceViewModel() : base() {
        }

        public override string? ToString() => $"Weather Resource";
    }

    [CategoryOrder("bearingInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class bearingInformationViewModel : ViewModelBase {
        private cardinalDirection? _cardinalDirection = default;
        [DomainModel.EnumerationAttribute(nameof(cardinalDirectionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("bearingInformation")]
        public cardinalDirection? cardinalDirection {
            get {
                return _cardinalDirection;
            }

            set {
                SetValue(ref _cardinalDirection, value);
            }
        }

        private Decimal? _distance = default;
        [Category("bearingInformation")]
        public Decimal? distance {
            get {
                return _distance;
            }

            set {
                SetValue(ref _distance, value);
            }
        }

        [Category("bearingInformation")]
        public ObservableCollection<Decimal> sectorBearing { get; set; } = new();

        [Category("bearingInformation")]
        public ObservableCollection<information> information { get; set; } = new();

        private orientationViewModel? _orientation;
        [Category("bearingInformation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public orientationViewModel? orientation {
            get {
                return _orientation;
            }

            set {
                SetValue(ref _orientation, value);
            }
        }

        [Browsable(false)]
        public cardinalDirection[] cardinalDirectionList => [(cardinalDirection)1, (cardinalDirection)2, (cardinalDirection)3, (cardinalDirection)4, (cardinalDirection)5, (cardinalDirection)6, (cardinalDirection)7, (cardinalDirection)8, (cardinalDirection)9, (cardinalDirection)10, (cardinalDirection)11, (cardinalDirection)12, (cardinalDirection)13, (cardinalDirection)14, (cardinalDirection)15, (cardinalDirection)16];

        public void Load(DomainModel.S131.ComplexAttributes.bearingInformation instance) {
            cardinalDirection = instance.cardinalDirection;
            distance = instance.distance;
            sectorBearing.Clear();
            if (instance.sectorBearing is not null)
                foreach (var e in instance.sectorBearing)
                    sectorBearing.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            orientation = new();
            if (instance.orientation != null) {
                orientation = new();
                orientation.Load(instance.orientation);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.bearingInformation
            {
                cardinalDirection = this.cardinalDirection,
                distance = this.distance,
                sectorBearing = this.sectorBearing.ToList(),
                information = this.information.ToList(),
                orientation = this.orientation?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.bearingInformation Model => new()
        {
            cardinalDirection = this._cardinalDirection,
            distance = this._distance,
            sectorBearing = this.sectorBearing.ToList(),
            information = this.information.ToList(),
            orientation = this._orientation?.Model,
        };

        public bearingInformationViewModel() : base() {
            sectorBearing.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(sectorBearing));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Bearing Information";
    }

    [CategoryOrder("cargoServicesDescription", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class cargoServicesDescriptionViewModel : ViewModelBase {
        [Category("cargoServicesDescription")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.cargoServicesDescription instance) {
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.cargoServicesDescription
            {
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.cargoServicesDescription Model => new()
        {
            textContent = this.textContent.ToList(),
        };

        public cargoServicesDescriptionViewModel() : base() {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Cargo Services Description";
    }

    [CategoryOrder("constructionInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class constructionInformationViewModel : ViewModelBase {
        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("constructionInformation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private condition? _condition = default;
        [DomainModel.EnumerationAttribute(nameof(conditionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("constructionInformation")]
        public condition? condition {
            get {
                return _condition;
            }

            set {
                SetValue(ref _condition, value);
            }
        }

        private String _development = string.Empty;
        [Category("constructionInformation")]
        public String development {
            get {
                return _development;
            }

            set {
                SetValue(ref _development, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("constructionInformation")]
        public String locationByText {
            get {
                return _locationByText;
            }

            set {
                SetValue(ref _locationByText, value);
            }
        }

        [Category("constructionInformation")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        [Browsable(false)]
        public condition[] conditionList => [(condition)1, (condition)2, (condition)3, (condition)5];

        public void Load(DomainModel.S131.ComplexAttributes.constructionInformation instance) {
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            condition = instance.condition;
            development = instance.development;
            locationByText = instance.locationByText;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.constructionInformation
            {
                fixedDateRange = this.fixedDateRange?.Model,
                condition = this.condition,
                development = this.development,
                locationByText = this.locationByText,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.constructionInformation Model => new()
        {
            fixedDateRange = this._fixedDateRange?.Model,
            condition = this._condition,
            development = this._development,
            locationByText = this._locationByText,
            textContent = this.textContent.ToList(),
        };

        public constructionInformationViewModel() : base() {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Construction Information";
    }

    [CategoryOrder("depthsDescription", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class depthsDescriptionViewModel : ViewModelBase {
        private categoryOfDepthsDescription _categoryOfDepthsDescription;
        [DomainModel.EnumerationAttribute(nameof(categoryOfDepthsDescriptionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("depthsDescription")]
        public categoryOfDepthsDescription categoryOfDepthsDescription {
            get {
                return _categoryOfDepthsDescription;
            }

            set {
                SetValue(ref _categoryOfDepthsDescription, value);
            }
        }

        [Category("depthsDescription")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        [Browsable(false)]
        public categoryOfDepthsDescription[] categoryOfDepthsDescriptionList => [(categoryOfDepthsDescription)1, (categoryOfDepthsDescription)2, (categoryOfDepthsDescription)3];

        public void Load(DomainModel.S131.ComplexAttributes.depthsDescription instance) {
            categoryOfDepthsDescription = instance.categoryOfDepthsDescription;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.depthsDescription
            {
                categoryOfDepthsDescription = this.categoryOfDepthsDescription,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.depthsDescription Model => new()
        {
            categoryOfDepthsDescription = this._categoryOfDepthsDescription,
            textContent = this.textContent.ToList(),
        };

        public depthsDescriptionViewModel() : base() {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Depths Description";
    }

    [CategoryOrder("facilitiesLayoutDescription", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class facilitiesLayoutDescriptionViewModel : ViewModelBase {
        [Category("facilitiesLayoutDescription")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.facilitiesLayoutDescription instance) {
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.facilitiesLayoutDescription
            {
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.facilitiesLayoutDescription Model => new()
        {
            textContent = this.textContent.ToList(),
        };

        public facilitiesLayoutDescriptionViewModel() : base() {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Facilities Layout Description";
    }

    [CategoryOrder("generalPortDescription", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class generalPortDescriptionViewModel : ViewModelBase {
        [Category("generalPortDescription")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.generalPortDescription instance) {
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.generalPortDescription
            {
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.generalPortDescription Model => new()
        {
            textContent = this.textContent.ToList(),
        };

        public generalPortDescriptionViewModel() : base() {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"General Port Description";
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("graphic", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class graphicViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        [Category("graphic")]
        public ObservableCollection<String> pictorialRepresentation { get; set; } = new();

        private String _pictureCaption = string.Empty;
        [Category("graphic")]
        public String pictureCaption {
            get {
                return _pictureCaption;
            }

            set {
                SetValue(ref _pictureCaption, value);
            }
        }

        private DateTime? _sourceDate = default;
        [Category("graphic")]
        public DateTime? sourceDate {
            get {
                return _sourceDate;
            }

            set {
                SetValue(ref _sourceDate, value);
            }
        }

        private String _pictureInformation = string.Empty;
        [Category("graphic")]
        public String pictureInformation {
            get {
                return _pictureInformation;
            }

            set {
                SetValue(ref _pictureInformation, value);
            }
        }

        private bearingInformationViewModel? _bearingInformation;
        [Category("graphic")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public bearingInformationViewModel? bearingInformation {
            get {
                return _bearingInformation;
            }

            set {
                SetValue(ref _bearingInformation, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.graphic instance) {
            pictorialRepresentation.Clear();
            if (instance.pictorialRepresentation is not null)
                foreach (var e in instance.pictorialRepresentation)
                    pictorialRepresentation.Add(e);
            pictureCaption = instance.pictureCaption;
            sourceDate = instance.sourceDate;
            pictureInformation = instance.pictureInformation;
            bearingInformation = new();
            if (instance.bearingInformation != null) {
                bearingInformation = new();
                bearingInformation.Load(instance.bearingInformation);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.graphic
            {
                pictorialRepresentation = this.pictorialRepresentation.ToList(),
                pictureCaption = this.pictureCaption,
                sourceDate = this.sourceDate,
                pictureInformation = this.pictureInformation,
                bearingInformation = this.bearingInformation?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.graphic Model => new()
        {
            pictorialRepresentation = this.pictorialRepresentation.ToList(),
            pictureCaption = this._pictureCaption,
            sourceDate = this._sourceDate,
            pictureInformation = this._pictureInformation,
            bearingInformation = this._bearingInformation?.Model,
        };

        public graphicViewModel() : base() {
            pictorialRepresentation.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(pictorialRepresentation));
            };
        }

        public override string? ToString() => $"Graphic";
    }

    [CategoryOrder("landmarkDescription", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class landmarkDescriptionViewModel : ViewModelBase {
        [Category("landmarkDescription")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.landmarkDescription instance) {
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.landmarkDescription
            {
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.landmarkDescription Model => new()
        {
            textContent = this.textContent.ToList(),
        };

        public landmarkDescriptionViewModel() : base() {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Landmark Description";
    }

    [CategoryOrder("limitsDescription", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class limitsDescriptionViewModel : ViewModelBase {
        [Category("limitsDescription")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.limitsDescription instance) {
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.limitsDescription
            {
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.limitsDescription Model => new()
        {
            textContent = this.textContent.ToList(),
        };

        public limitsDescriptionViewModel() : base() {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Limits Description";
    }

    [CategoryOrder("majorLightDescription", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class majorLightDescriptionViewModel : ViewModelBase {
        [Category("majorLightDescription")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.majorLightDescription instance) {
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.majorLightDescription
            {
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.majorLightDescription Model => new()
        {
            textContent = this.textContent.ToList(),
        };

        public majorLightDescriptionViewModel() : base() {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Major Light Description";
    }

    [CategoryOrder("markedBy", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class markedByViewModel : ViewModelBase {
        [Category("markedBy")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.markedBy instance) {
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.markedBy
            {
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.markedBy Model => new()
        {
            textContent = this.textContent.ToList(),
        };

        public markedByViewModel() : base() {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Marked By";
    }

    [CategoryOrder("offshoreMarkDescription", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class offshoreMarkDescriptionViewModel : ViewModelBase {
        [Category("offshoreMarkDescription")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.offshoreMarkDescription instance) {
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.offshoreMarkDescription
            {
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.offshoreMarkDescription Model => new()
        {
            textContent = this.textContent.ToList(),
        };

        public offshoreMarkDescriptionViewModel() : base() {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Offshore Mark Description";
    }

    [CategoryOrder("scheduleByDayOfWeek", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class scheduleByDayOfWeekViewModel : ViewModelBase {
        private categoryOfSchedule? _categoryOfSchedule = default;
        [DomainModel.EnumerationAttribute(nameof(categoryOfScheduleList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("scheduleByDayOfWeek")]
        public categoryOfSchedule? categoryOfSchedule {
            get {
                return _categoryOfSchedule;
            }

            set {
                SetValue(ref _categoryOfSchedule, value);
            }
        }

        [Category("scheduleByDayOfWeek")]
        public ObservableCollection<timeIntervalsByDayOfWeek> timeIntervalsByDayOfWeek { get; set; } = new();

        [Browsable(false)]
        public categoryOfSchedule[] categoryOfScheduleList => [(categoryOfSchedule)1, (categoryOfSchedule)2, (categoryOfSchedule)3];

        public void Load(DomainModel.S131.ComplexAttributes.scheduleByDayOfWeek instance) {
            categoryOfSchedule = instance.categoryOfSchedule;
            timeIntervalsByDayOfWeek.Clear();
            if (instance.timeIntervalsByDayOfWeek is not null)
                foreach (var e in instance.timeIntervalsByDayOfWeek)
                    timeIntervalsByDayOfWeek.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.scheduleByDayOfWeek
            {
                categoryOfSchedule = this.categoryOfSchedule,
                timeIntervalsByDayOfWeek = this.timeIntervalsByDayOfWeek.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.scheduleByDayOfWeek Model => new()
        {
            categoryOfSchedule = this._categoryOfSchedule,
            timeIntervalsByDayOfWeek = this.timeIntervalsByDayOfWeek.ToList(),
        };

        public scheduleByDayOfWeekViewModel() : base() {
            timeIntervalsByDayOfWeek.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(timeIntervalsByDayOfWeek));
            };
        }

        public override string? ToString() => $"Schedule by Day of Week";
    }

    [CategoryOrder("spatialAccuracy", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class spatialAccuracyViewModel : ViewModelBase {
        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("spatialAccuracy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private horizontalPositionUncertaintyViewModel? _horizontalPositionUncertainty;
        [Category("spatialAccuracy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public horizontalPositionUncertaintyViewModel? horizontalPositionUncertainty {
            get {
                return _horizontalPositionUncertainty;
            }

            set {
                SetValue(ref _horizontalPositionUncertainty, value);
            }
        }

        private verticalUncertaintyViewModel? _verticalUncertainty;
        [Category("spatialAccuracy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public verticalUncertaintyViewModel? verticalUncertainty {
            get {
                return _verticalUncertainty;
            }

            set {
                SetValue(ref _verticalUncertainty, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.spatialAccuracy instance) {
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            horizontalPositionUncertainty = new();
            if (instance.horizontalPositionUncertainty != null) {
                horizontalPositionUncertainty = new();
                horizontalPositionUncertainty.Load(instance.horizontalPositionUncertainty);
            }

            verticalUncertainty = new();
            if (instance.verticalUncertainty != null) {
                verticalUncertainty = new();
                verticalUncertainty.Load(instance.verticalUncertainty);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.spatialAccuracy
            {
                fixedDateRange = this.fixedDateRange?.Model,
                horizontalPositionUncertainty = this.horizontalPositionUncertainty?.Model,
                verticalUncertainty = this.verticalUncertainty?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.spatialAccuracy Model => new()
        {
            fixedDateRange = this._fixedDateRange?.Model,
            horizontalPositionUncertainty = this._horizontalPositionUncertainty?.Model,
            verticalUncertainty = this._verticalUncertainty?.Model,
        };

        public spatialAccuracyViewModel() : base() {
        }

        public override string? ToString() => $"Spatial Accuracy";
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("telecommunications", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class telecommunicationsViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        private categoryOfCommunicationPreference? _categoryOfCommunicationPreference = default;
        [DomainModel.EnumerationAttribute(nameof(categoryOfCommunicationPreferenceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("telecommunications")]
        public categoryOfCommunicationPreference? categoryOfCommunicationPreference {
            get {
                return _categoryOfCommunicationPreference;
            }

            set {
                SetValue(ref _categoryOfCommunicationPreference, value);
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

        private String _telecommunicationCarrier = string.Empty;
        [Category("telecommunications")]
        public String telecommunicationCarrier {
            get {
                return _telecommunicationCarrier;
            }

            set {
                SetValue(ref _telecommunicationCarrier, value);
            }
        }

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

        [DomainModel.EnumerationAttribute(nameof(telecommunicationServiceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("telecommunications")]
        public ObservableCollection<telecommunicationService> telecommunicationService { get; set; } = new();

        private scheduleByDayOfWeekViewModel? _scheduleByDayOfWeek;
        [Category("telecommunications")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public scheduleByDayOfWeekViewModel? scheduleByDayOfWeek {
            get {
                return _scheduleByDayOfWeek;
            }

            set {
                SetValue(ref _scheduleByDayOfWeek, value);
            }
        }

        [Browsable(false)]
        public categoryOfCommunicationPreference[] categoryOfCommunicationPreferenceList => [(categoryOfCommunicationPreference)1, (categoryOfCommunicationPreference)2, (categoryOfCommunicationPreference)3, (categoryOfCommunicationPreference)4];

        [Browsable(false)]
        public telecommunicationService[] telecommunicationServiceList => [(telecommunicationService)1, (telecommunicationService)2, (telecommunicationService)3, (telecommunicationService)4, (telecommunicationService)5, (telecommunicationService)6, (telecommunicationService)7, (telecommunicationService)8];

        public void Load(DomainModel.S131.ComplexAttributes.telecommunications instance) {
            categoryOfCommunicationPreference = instance.categoryOfCommunicationPreference;
            telecommunicationIdentifier = instance.telecommunicationIdentifier;
            telecommunicationCarrier = instance.telecommunicationCarrier;
            contactInstructions = instance.contactInstructions;
            telecommunicationService.Clear();
            if (instance.telecommunicationService is not null)
                foreach (var e in instance.telecommunicationService)
                    telecommunicationService.Add(e);
            scheduleByDayOfWeek = new();
            if (instance.scheduleByDayOfWeek != null) {
                scheduleByDayOfWeek = new();
                scheduleByDayOfWeek.Load(instance.scheduleByDayOfWeek);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.telecommunications
            {
                categoryOfCommunicationPreference = this.categoryOfCommunicationPreference,
                telecommunicationIdentifier = this.telecommunicationIdentifier,
                telecommunicationCarrier = this.telecommunicationCarrier,
                contactInstructions = this.contactInstructions,
                telecommunicationService = this.telecommunicationService.ToList(),
                scheduleByDayOfWeek = this.scheduleByDayOfWeek?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.telecommunications Model => new()
        {
            categoryOfCommunicationPreference = this._categoryOfCommunicationPreference,
            telecommunicationIdentifier = this._telecommunicationIdentifier,
            telecommunicationCarrier = this._telecommunicationCarrier,
            contactInstructions = this._contactInstructions,
            telecommunicationService = this.telecommunicationService.ToList(),
            scheduleByDayOfWeek = this._scheduleByDayOfWeek?.Model,
        };

        public telecommunicationsViewModel() : base() {
            telecommunicationService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(telecommunicationService));
            };
        }

        public override string? ToString() => $"Telecommunications";
    }

    [CategoryOrder("generalHarbourInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class generalHarbourInformationViewModel : ViewModelBase {
        private generalPortDescriptionViewModel? _generalPortDescription;
        [Category("generalHarbourInformation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public generalPortDescriptionViewModel? generalPortDescription {
            get {
                return _generalPortDescription;
            }

            set {
                SetValue(ref _generalPortDescription, value);
            }
        }

        private facilitiesLayoutDescriptionViewModel? _facilitiesLayoutDescription;
        [Category("generalHarbourInformation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public facilitiesLayoutDescriptionViewModel? facilitiesLayoutDescription {
            get {
                return _facilitiesLayoutDescription;
            }

            set {
                SetValue(ref _facilitiesLayoutDescription, value);
            }
        }

        private limitsDescriptionViewModel? _limitsDescription;
        [Category("generalHarbourInformation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public limitsDescriptionViewModel? limitsDescription {
            get {
                return _limitsDescription;
            }

            set {
                SetValue(ref _limitsDescription, value);
            }
        }

        private constructionInformationViewModel? _constructionInformation;
        [Category("generalHarbourInformation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public constructionInformationViewModel? constructionInformation {
            get {
                return _constructionInformation;
            }

            set {
                SetValue(ref _constructionInformation, value);
            }
        }

        private cargoServicesDescriptionViewModel? _cargoServicesDescription;
        [Category("generalHarbourInformation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public cargoServicesDescriptionViewModel? cargoServicesDescription {
            get {
                return _cargoServicesDescription;
            }

            set {
                SetValue(ref _cargoServicesDescription, value);
            }
        }

        [Category("generalHarbourInformation")]
        public ObservableCollection<weatherResource> weatherResource { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.generalHarbourInformation instance) {
            generalPortDescription = new();
            if (instance.generalPortDescription != null) {
                generalPortDescription = new();
                generalPortDescription.Load(instance.generalPortDescription);
            }

            facilitiesLayoutDescription = new();
            if (instance.facilitiesLayoutDescription != null) {
                facilitiesLayoutDescription = new();
                facilitiesLayoutDescription.Load(instance.facilitiesLayoutDescription);
            }

            limitsDescription = new();
            if (instance.limitsDescription != null) {
                limitsDescription = new();
                limitsDescription.Load(instance.limitsDescription);
            }

            constructionInformation = new();
            if (instance.constructionInformation != null) {
                constructionInformation = new();
                constructionInformation.Load(instance.constructionInformation);
            }

            cargoServicesDescription = new();
            if (instance.cargoServicesDescription != null) {
                cargoServicesDescription = new();
                cargoServicesDescription.Load(instance.cargoServicesDescription);
            }

            weatherResource.Clear();
            if (instance.weatherResource is not null)
                foreach (var e in instance.weatherResource)
                    weatherResource.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.ComplexAttributes.generalHarbourInformation
            {
                generalPortDescription = this.generalPortDescription?.Model,
                facilitiesLayoutDescription = this.facilitiesLayoutDescription?.Model,
                limitsDescription = this.limitsDescription?.Model,
                constructionInformation = this.constructionInformation?.Model,
                cargoServicesDescription = this.cargoServicesDescription?.Model,
                weatherResource = this.weatherResource.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.generalHarbourInformation Model => new()
        {
            generalPortDescription = this._generalPortDescription?.Model,
            facilitiesLayoutDescription = this._facilitiesLayoutDescription?.Model,
            limitsDescription = this._limitsDescription?.Model,
            constructionInformation = this._constructionInformation?.Model,
            cargoServicesDescription = this._cargoServicesDescription?.Model,
            weatherResource = this.weatherResource.ToList(),
        };

        public generalHarbourInformationViewModel() : base() {
            weatherResource.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(weatherResource));
            };
        }

        public override string? ToString() => $"General Harbour Information";
    }

    [CategoryOrder("AdditionalInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class AdditionalInformationViewModel : AssociationViewModel {
        public void Load(DomainModel.S131.Associations.InformationAssociations.AdditionalInformation instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.Associations.InformationAssociations.AdditionalInformation
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.Associations.InformationAssociations.AdditionalInformation Model => new()
        {
        };

        public AdditionalInformationViewModel() : base() {
        }

        public override string? ToString() => $"Additional information";
    }

    [CategoryOrder("AuthorityContact", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class AuthorityContactViewModel : AssociationViewModel {
        public void Load(DomainModel.S131.Associations.InformationAssociations.AuthorityContact instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.Associations.InformationAssociations.AuthorityContact
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.Associations.InformationAssociations.AuthorityContact Model => new()
        {
        };

        public AuthorityContactViewModel() : base() {
        }

        public override string? ToString() => $"Authority contact";
    }

    [CategoryOrder("AuthorityHours", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class AuthorityHoursViewModel : AssociationViewModel {
        public void Load(DomainModel.S131.Associations.InformationAssociations.AuthorityHours instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.Associations.InformationAssociations.AuthorityHours
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.Associations.InformationAssociations.AuthorityHours Model => new()
        {
        };

        public AuthorityHoursViewModel() : base() {
        }

        public override string? ToString() => $"Authority hours";
    }

    [CategoryOrder("AssociatedRxN", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class AssociatedRxNViewModel : AssociationViewModel {
        public void Load(DomainModel.S131.Associations.InformationAssociations.AssociatedRxN instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.Associations.InformationAssociations.AssociatedRxN
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.Associations.InformationAssociations.AssociatedRxN Model => new()
        {
        };

        public AssociatedRxNViewModel() : base() {
        }

        public override string? ToString() => $"Associated RxN";
    }

    [CategoryOrder("ExceptionalWorkday", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ExceptionalWorkdayViewModel : AssociationViewModel {
        public void Load(DomainModel.S131.Associations.InformationAssociations.ExceptionalWorkday instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.Associations.InformationAssociations.ExceptionalWorkday
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.Associations.InformationAssociations.ExceptionalWorkday Model => new()
        {
        };

        public ExceptionalWorkdayViewModel() : base() {
        }

        public override string? ToString() => $"Exceptional workday";
    }

    [CategoryOrder("ServiceControl", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ServiceControlViewModel : AssociationViewModel {
        public void Load(DomainModel.S131.Associations.InformationAssociations.ServiceControl instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.Associations.InformationAssociations.ServiceControl
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.Associations.InformationAssociations.ServiceControl Model => new()
        {
        };

        public ServiceControlViewModel() : base() {
        }

        public override string? ToString() => $"Service control";
    }

    [CategoryOrder("ServiceContact", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ServiceContactViewModel : AssociationViewModel {
        public void Load(DomainModel.S131.Associations.InformationAssociations.ServiceContact instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.Associations.InformationAssociations.ServiceContact
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.Associations.InformationAssociations.ServiceContact Model => new()
        {
        };

        public ServiceContactViewModel() : base() {
        }

        public override string? ToString() => $"Service contact";
    }

    [CategoryOrder("LocationHours", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class LocationHoursViewModel : AssociationViewModel {
        public void Load(DomainModel.S131.Associations.InformationAssociations.LocationHours instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.Associations.InformationAssociations.LocationHours
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.Associations.InformationAssociations.LocationHours Model => new()
        {
        };

        public LocationHoursViewModel() : base() {
        }

        public override string? ToString() => $"Location hours";
    }

    [CategoryOrder("RelatedOrganisation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RelatedOrganisationViewModel : AssociationViewModel {
        public void Load(DomainModel.S131.Associations.InformationAssociations.RelatedOrganisation instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.Associations.InformationAssociations.RelatedOrganisation
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.Associations.InformationAssociations.RelatedOrganisation Model => new()
        {
        };

        public RelatedOrganisationViewModel() : base() {
        }

        public override string? ToString() => $"Related organisation";
    }

    [CategoryOrder("InclusionType", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class InclusionTypeViewModel : AssociationViewModel {
        private membership _membership;
        [DomainModel.EnumerationAttribute(nameof(membershipList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("InclusionType")]
        public membership membership {
            get {
                return _membership;
            }

            set {
                SetValue(ref _membership, value);
            }
        }

        [Browsable(false)]
        public membership[] membershipList => [(membership)1, (membership)2];

        public void Load(DomainModel.S131.Associations.InformationAssociations.InclusionType instance) {
            membership = instance.membership;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.Associations.InformationAssociations.InclusionType
            {
                membership = this.membership,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.Associations.InformationAssociations.InclusionType Model => new()
        {
            membership = this._membership,
        };

        public InclusionTypeViewModel() : base() {
        }

        public override string? ToString() => $"InclusionType";
    }

    [CategoryOrder("PermissionType", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class PermissionTypeViewModel : AssociationViewModel {
        private categoryOfRelationship _categoryOfRelationship;
        [DomainModel.EnumerationAttribute(nameof(categoryOfRelationshipList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("PermissionType")]
        public categoryOfRelationship categoryOfRelationship {
            get {
                return _categoryOfRelationship;
            }

            set {
                SetValue(ref _categoryOfRelationship, value);
            }
        }

        [Browsable(false)]
        public categoryOfRelationship[] categoryOfRelationshipList => [(categoryOfRelationship)1, (categoryOfRelationship)2, (categoryOfRelationship)3, (categoryOfRelationship)4, (categoryOfRelationship)5, (categoryOfRelationship)6];

        public void Load(DomainModel.S131.Associations.InformationAssociations.PermissionType instance) {
            categoryOfRelationship = instance.categoryOfRelationship;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.Associations.InformationAssociations.PermissionType
            {
                categoryOfRelationship = this.categoryOfRelationship,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.Associations.InformationAssociations.PermissionType Model => new()
        {
            categoryOfRelationship = this._categoryOfRelationship,
        };

        public PermissionTypeViewModel() : base() {
        }

        public override string? ToString() => $"Permission Type";
    }

    [CategoryOrder("LimitEntrance", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class LimitEntranceViewModel : AssociationViewModel {
        public void Load(DomainModel.S131.Associations.InformationAssociations.LimitEntrance instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.Associations.InformationAssociations.LimitEntrance
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.Associations.InformationAssociations.LimitEntrance Model => new()
        {
        };

        public LimitEntranceViewModel() : base() {
        }

        public override string? ToString() => $"Limit Entrance";
    }

    [CategoryOrder("ServiceAvailability", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ServiceAvailabilityViewModel : AssociationViewModel {
        public void Load(DomainModel.S131.Associations.InformationAssociations.ServiceAvailability instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.Associations.InformationAssociations.ServiceAvailability
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.Associations.InformationAssociations.ServiceAvailability Model => new()
        {
        };

        public ServiceAvailabilityViewModel() : base() {
        }

        public override string? ToString() => $"Service Availability";
    }

    [CategoryOrder("TextAssociation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class TextAssociationViewModel : AssociationViewModel {
        public void Load(DomainModel.S131.Associations.FeatureAssociations.TextAssociation instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.Associations.FeatureAssociations.TextAssociation
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.Associations.FeatureAssociations.TextAssociation Model => new()
        {
        };

        public TextAssociationViewModel() : base() {
        }

        public override string? ToString() => $"Text association";
    }

    [CategoryOrder("Subsection", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class SubsectionViewModel : AssociationViewModel {
        public void Load(DomainModel.S131.Associations.FeatureAssociations.Subsection instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.Associations.FeatureAssociations.Subsection
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.Associations.FeatureAssociations.Subsection Model => new()
        {
        };

        public SubsectionViewModel() : base() {
        }

        public override string? ToString() => $"Subsection";
    }

    [CategoryOrder("Infrastructure", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class InfrastructureViewModel : AssociationViewModel {
        public void Load(DomainModel.S131.Associations.FeatureAssociations.Infrastructure instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.Associations.FeatureAssociations.Infrastructure
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.Associations.FeatureAssociations.Infrastructure Model => new()
        {
        };

        public InfrastructureViewModel() : base() {
        }

        public override string? ToString() => $"Infrastructure";
    }

    [CategoryOrder("PrimaryAuxiliaryFacility", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class PrimaryAuxiliaryFacilityViewModel : AssociationViewModel {
        public void Load(DomainModel.S131.Associations.FeatureAssociations.PrimaryAuxiliaryFacility instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.Associations.FeatureAssociations.PrimaryAuxiliaryFacility
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.Associations.FeatureAssociations.PrimaryAuxiliaryFacility Model => new()
        {
        };

        public PrimaryAuxiliaryFacilityViewModel() : base() {
        }

        public override string? ToString() => $"Primary/Auxiliary Facility";
    }

    [CategoryOrder("Demarcation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DemarcationViewModel : AssociationViewModel {
        public void Load(DomainModel.S131.Associations.FeatureAssociations.Demarcation instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.Associations.FeatureAssociations.Demarcation
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.Associations.FeatureAssociations.Demarcation Model => new()
        {
        };

        public DemarcationViewModel() : base() {
        }

        public override string? ToString() => $"Demarcation";
    }

    [CategoryOrder("JurisdictionalLimit", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class JurisdictionalLimitViewModel : AssociationViewModel {
        public void Load(DomainModel.S131.Associations.FeatureAssociations.JurisdictionalLimit instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.Associations.FeatureAssociations.JurisdictionalLimit
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.Associations.FeatureAssociations.JurisdictionalLimit Model => new()
        {
        };

        public JurisdictionalLimitViewModel() : base() {
        }

        public override string? ToString() => $"Jurisdictional Limit";
    }

    [CategoryOrder("LayoutDivision", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class LayoutDivisionViewModel : AssociationViewModel {
        public void Load(DomainModel.S131.Associations.FeatureAssociations.LayoutDivision instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.Associations.FeatureAssociations.LayoutDivision
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.Associations.FeatureAssociations.LayoutDivision Model => new()
        {
        };

        public LayoutDivisionViewModel() : base() {
        }

        public override string? ToString() => $"Layout Division";
    }

    [CategoryOrder("Applicability", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ApplicabilityViewModel : InformationViewModel<Applicability> {
        private Boolean? _inBallast = default;
        [Category("Applicability")]
        public Boolean? inBallast {
            get {
                return _inBallast;
            }

            set {
                SetValue(ref _inBallast, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(categoryOfCargoList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("Applicability")]
        public ObservableCollection<categoryOfCargo> categoryOfCargo { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(categoryOfDangerousOrHazardousCargoList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("Applicability")]
        public ObservableCollection<categoryOfDangerousOrHazardousCargo> categoryOfDangerousOrHazardousCargo { get; set; } = new();

        private categoryOfVessel? _categoryOfVessel;
        [DomainModel.CodeList(nameof(categoryOfVesselList))]
        [Editor(typeof(Editors.CodeListComboEditor), typeof(Editors.CodeListComboEditor))]
        [Category("Applicability")]
        public categoryOfVessel? categoryOfVessel {
            get {
                return _categoryOfVessel;
            }

            set {
                SetValue(ref _categoryOfVessel, value);
            }
        }

        private categoryOfVesselRegistry? _categoryOfVesselRegistry = default;
        [DomainModel.EnumerationAttribute(nameof(categoryOfVesselRegistryList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("Applicability")]
        public categoryOfVesselRegistry? categoryOfVesselRegistry {
            get {
                return _categoryOfVesselRegistry;
            }

            set {
                SetValue(ref _categoryOfVesselRegistry, value);
            }
        }

        private logicalConnectives? _logicalConnectives = default;
        [DomainModel.EnumerationAttribute(nameof(logicalConnectivesList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("Applicability")]
        public logicalConnectives? logicalConnectives {
            get {
                return _logicalConnectives;
            }

            set {
                SetValue(ref _logicalConnectives, value);
            }
        }

        private Int32? _thicknessOfIceCapability = default;
        [Category("Applicability")]
        public Int32? thicknessOfIceCapability {
            get {
                return _thicknessOfIceCapability;
            }

            set {
                SetValue(ref _thicknessOfIceCapability, value);
            }
        }

        private String _vesselPerformance = string.Empty;
        [Category("Applicability")]
        public String vesselPerformance {
            get {
                return _vesselPerformance;
            }

            set {
                SetValue(ref _vesselPerformance, value);
            }
        }

        [Category("Applicability")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("Applicability")]
        public ObservableCollection<vesselsMeasurements> vesselsMeasurements { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("InformationType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => Applicability.informationBindingDefinitions;

        [Browsable(false)]
        public categoryOfVessel[] categoryOfVesselList => CodeList.categoryOfVessels.ToArray();

        [Browsable(false)]
        public categoryOfCargo[] categoryOfCargoList => [(categoryOfCargo)2, (categoryOfCargo)5, (categoryOfCargo)6, (categoryOfCargo)7, (categoryOfCargo)8, (categoryOfCargo)10, (categoryOfCargo)11, (categoryOfCargo)12, (categoryOfCargo)13, (categoryOfCargo)14, (categoryOfCargo)15];

        [Browsable(false)]
        public categoryOfDangerousOrHazardousCargo[] categoryOfDangerousOrHazardousCargoList => [(categoryOfDangerousOrHazardousCargo)1, (categoryOfDangerousOrHazardousCargo)2, (categoryOfDangerousOrHazardousCargo)3, (categoryOfDangerousOrHazardousCargo)4, (categoryOfDangerousOrHazardousCargo)5, (categoryOfDangerousOrHazardousCargo)6, (categoryOfDangerousOrHazardousCargo)7, (categoryOfDangerousOrHazardousCargo)8, (categoryOfDangerousOrHazardousCargo)9, (categoryOfDangerousOrHazardousCargo)10, (categoryOfDangerousOrHazardousCargo)11, (categoryOfDangerousOrHazardousCargo)12, (categoryOfDangerousOrHazardousCargo)13, (categoryOfDangerousOrHazardousCargo)14, (categoryOfDangerousOrHazardousCargo)15, (categoryOfDangerousOrHazardousCargo)16, (categoryOfDangerousOrHazardousCargo)17, (categoryOfDangerousOrHazardousCargo)18, (categoryOfDangerousOrHazardousCargo)19, (categoryOfDangerousOrHazardousCargo)20, (categoryOfDangerousOrHazardousCargo)21];

        [Browsable(false)]
        public categoryOfVesselRegistry[] categoryOfVesselRegistryList => [(categoryOfVesselRegistry)1, (categoryOfVesselRegistry)2];

        [Browsable(false)]
        public logicalConnectives[] logicalConnectivesList => [(logicalConnectives)1, (logicalConnectives)2];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.InformationTypes.Applicability instance) {
            inBallast = instance.inBallast;
            categoryOfCargo.Clear();
            if (instance.categoryOfCargo is not null)
                foreach (var e in instance.categoryOfCargo)
                    categoryOfCargo.Add(e);
            categoryOfDangerousOrHazardousCargo.Clear();
            if (instance.categoryOfDangerousOrHazardousCargo is not null)
                foreach (var e in instance.categoryOfDangerousOrHazardousCargo)
                    categoryOfDangerousOrHazardousCargo.Add(e);
            categoryOfVessel = instance.categoryOfVessel;
            categoryOfVesselRegistry = instance.categoryOfVesselRegistry;
            logicalConnectives = instance.logicalConnectives;
            thicknessOfIceCapability = instance.thicknessOfIceCapability;
            vesselPerformance = instance.vesselPerformance;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            vesselsMeasurements.Clear();
            if (instance.vesselsMeasurements is not null)
                foreach (var e in instance.vesselsMeasurements)
                    vesselsMeasurements.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.InformationTypes.Applicability
            {
                inBallast = this.inBallast,
                categoryOfCargo = this.categoryOfCargo.ToList(),
                categoryOfDangerousOrHazardousCargo = this.categoryOfDangerousOrHazardousCargo.ToList(),
                categoryOfVessel = this.categoryOfVessel,
                categoryOfVesselRegistry = this.categoryOfVesselRegistry,
                logicalConnectives = this.logicalConnectives,
                thicknessOfIceCapability = this.thicknessOfIceCapability,
                vesselPerformance = this.vesselPerformance,
                information = this.information.ToList(),
                vesselsMeasurements = this.vesselsMeasurements.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.Applicability Model => new()
        {
            inBallast = this._inBallast,
            categoryOfCargo = this.categoryOfCargo.ToList(),
            categoryOfDangerousOrHazardousCargo = this.categoryOfDangerousOrHazardousCargo.ToList(),
            categoryOfVessel = this._categoryOfVessel,
            categoryOfVesselRegistry = this._categoryOfVesselRegistry,
            logicalConnectives = this._logicalConnectives,
            thicknessOfIceCapability = this._thicknessOfIceCapability,
            vesselPerformance = this._vesselPerformance,
            information = this.information.ToList(),
            vesselsMeasurements = this.vesselsMeasurements.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public ApplicabilityViewModel() : base() {
            categoryOfCargo.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfCargo));
            };
            categoryOfDangerousOrHazardousCargo.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfDangerousOrHazardousCargo));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            vesselsMeasurements.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(vesselsMeasurements));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
        }

        public override string? ToString() => $"Applicability";
    }

    [CategoryOrder("Authority", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class AuthorityViewModel : InformationViewModel<Authority> {
        private categoryOfAuthority _categoryOfAuthority;
        [DomainModel.EnumerationAttribute(nameof(categoryOfAuthorityList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("Authority")]
        public categoryOfAuthority categoryOfAuthority {
            get {
                return _categoryOfAuthority;
            }

            set {
                SetValue(ref _categoryOfAuthority, value);
            }
        }

        private textContentViewModel? _textContent;
        [Category("Authority")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public textContentViewModel? textContent {
            get {
                return _textContent;
            }

            set {
                SetValue(ref _textContent, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("InformationType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => Authority.informationBindingDefinitions;

        [Browsable(false)]
        public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2, (categoryOfAuthority)3, (categoryOfAuthority)4, (categoryOfAuthority)5, (categoryOfAuthority)6, (categoryOfAuthority)7, (categoryOfAuthority)8, (categoryOfAuthority)9, (categoryOfAuthority)10, (categoryOfAuthority)11, (categoryOfAuthority)12, (categoryOfAuthority)13, (categoryOfAuthority)14, (categoryOfAuthority)15, (categoryOfAuthority)16];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.InformationTypes.Authority instance) {
            categoryOfAuthority = instance.categoryOfAuthority;
            textContent = new();
            if (instance.textContent != null) {
                textContent = new();
                textContent.Load(instance.textContent);
            }

            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.InformationTypes.Authority
            {
                categoryOfAuthority = this.categoryOfAuthority,
                textContent = this.textContent?.Model,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.Authority Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            textContent = this._textContent?.Model,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public AuthorityViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
        }

        public override string? ToString() => $"Authority";
    }

    [CategoryOrder("AvailablePortServices", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class AvailablePortServicesViewModel : InformationViewModel<AvailablePortServices> {
        [DomainModel.EnumerationAttribute(nameof(firefightingServiceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("AvailablePortServices")]
        public ObservableCollection<firefightingService> firefightingService { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(medicalServiceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("AvailablePortServices")]
        public ObservableCollection<medicalService> medicalService { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(repairServiceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("AvailablePortServices")]
        public ObservableCollection<repairService> repairService { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(technicalPortServiceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("AvailablePortServices")]
        public ObservableCollection<technicalPortService> technicalPortService { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(shipSanitationControlList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("AvailablePortServices")]
        public ObservableCollection<shipSanitationControl> shipSanitationControl { get; set; } = new();

        [DomainModel.CodeList(nameof(transportConnectionList))]
        [Editor(typeof(Editors.CodeListCheckComboEditor), typeof(Editors.CodeListCheckComboEditor))]
        [Category("AvailablePortServices")]
        public ObservableCollection<transportConnection> transportConnection { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(berthingAssistanceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("AvailablePortServices")]
        public ObservableCollection<berthingAssistance> berthingAssistance { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(cargoServiceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("AvailablePortServices")]
        public ObservableCollection<cargoService> cargoService { get; set; } = new();

        [DomainModel.CodeList(nameof(securitySafetyEmergencyServiceList))]
        [Editor(typeof(Editors.CodeListCheckComboEditor), typeof(Editors.CodeListCheckComboEditor))]
        [Category("AvailablePortServices")]
        public ObservableCollection<securitySafetyEmergencyService> securitySafetyEmergencyService { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(wasteDisposalServiceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("AvailablePortServices")]
        public ObservableCollection<wasteDisposalService> wasteDisposalService { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(supplyServiceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("AvailablePortServices")]
        public ObservableCollection<supplyService> supplyService { get; set; } = new();

        private String _tugInformation = string.Empty;
        [Category("AvailablePortServices")]
        public String tugInformation {
            get {
                return _tugInformation;
            }

            set {
                SetValue(ref _tugInformation, value);
            }
        }

        [Category("AvailablePortServices")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("InformationType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => AvailablePortServices.informationBindingDefinitions;

        [Browsable(false)]
        public transportConnection[] transportConnectionList => CodeList.transportConnections.ToArray();

        [Browsable(false)]
        public securitySafetyEmergencyService[] securitySafetyEmergencyServiceList => CodeList.securitySafetyEmergencyServices.ToArray();

        [Browsable(false)]
        public firefightingService[] firefightingServiceList => [(firefightingService)1, (firefightingService)2, (firefightingService)3];

        [Browsable(false)]
        public medicalService[] medicalServiceList => [(medicalService)1, (medicalService)2, (medicalService)3, (medicalService)4, (medicalService)5];

        [Browsable(false)]
        public repairService[] repairServiceList => [(repairService)1, (repairService)2, (repairService)3, (repairService)4, (repairService)5, (repairService)6, (repairService)7, (repairService)8, (repairService)9, (repairService)10];

        [Browsable(false)]
        public technicalPortService[] technicalPortServiceList => [(technicalPortService)1, (technicalPortService)2, (technicalPortService)3, (technicalPortService)4];

        [Browsable(false)]
        public shipSanitationControl[] shipSanitationControlList => [(shipSanitationControl)1, (shipSanitationControl)2, (shipSanitationControl)3];

        [Browsable(false)]
        public berthingAssistance[] berthingAssistanceList => [(berthingAssistance)1, (berthingAssistance)2, (berthingAssistance)3, (berthingAssistance)4, (berthingAssistance)5, (berthingAssistance)6];

        [Browsable(false)]
        public cargoService[] cargoServiceList => [(cargoService)1, (cargoService)2, (cargoService)3, (cargoService)4];

        [Browsable(false)]
        public wasteDisposalService[] wasteDisposalServiceList => [(wasteDisposalService)1, (wasteDisposalService)2, (wasteDisposalService)3, (wasteDisposalService)4, (wasteDisposalService)5, (wasteDisposalService)6, (wasteDisposalService)7, (wasteDisposalService)8, (wasteDisposalService)9, (wasteDisposalService)10, (wasteDisposalService)11, (wasteDisposalService)12, (wasteDisposalService)13, (wasteDisposalService)14, (wasteDisposalService)15, (wasteDisposalService)16, (wasteDisposalService)17, (wasteDisposalService)18, (wasteDisposalService)19, (wasteDisposalService)20, (wasteDisposalService)21, (wasteDisposalService)22, (wasteDisposalService)23, (wasteDisposalService)24];

        [Browsable(false)]
        public supplyService[] supplyServiceList => [(supplyService)1, (supplyService)2, (supplyService)3, (supplyService)4, (supplyService)5, (supplyService)6, (supplyService)7, (supplyService)8, (supplyService)9, (supplyService)10];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.InformationTypes.AvailablePortServices instance) {
            firefightingService.Clear();
            if (instance.firefightingService is not null)
                foreach (var e in instance.firefightingService)
                    firefightingService.Add(e);
            medicalService.Clear();
            if (instance.medicalService is not null)
                foreach (var e in instance.medicalService)
                    medicalService.Add(e);
            repairService.Clear();
            if (instance.repairService is not null)
                foreach (var e in instance.repairService)
                    repairService.Add(e);
            technicalPortService.Clear();
            if (instance.technicalPortService is not null)
                foreach (var e in instance.technicalPortService)
                    technicalPortService.Add(e);
            shipSanitationControl.Clear();
            if (instance.shipSanitationControl is not null)
                foreach (var e in instance.shipSanitationControl)
                    shipSanitationControl.Add(e);
            transportConnection.Clear();
            if (instance.transportConnection is not null)
                foreach (var e in instance.transportConnection)
                    transportConnection.Add(e);
            berthingAssistance.Clear();
            if (instance.berthingAssistance is not null)
                foreach (var e in instance.berthingAssistance)
                    berthingAssistance.Add(e);
            cargoService.Clear();
            if (instance.cargoService is not null)
                foreach (var e in instance.cargoService)
                    cargoService.Add(e);
            securitySafetyEmergencyService.Clear();
            if (instance.securitySafetyEmergencyService is not null)
                foreach (var e in instance.securitySafetyEmergencyService)
                    securitySafetyEmergencyService.Add(e);
            wasteDisposalService.Clear();
            if (instance.wasteDisposalService is not null)
                foreach (var e in instance.wasteDisposalService)
                    wasteDisposalService.Add(e);
            supplyService.Clear();
            if (instance.supplyService is not null)
                foreach (var e in instance.supplyService)
                    supplyService.Add(e);
            tugInformation = instance.tugInformation;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.InformationTypes.AvailablePortServices
            {
                firefightingService = this.firefightingService.ToList(),
                medicalService = this.medicalService.ToList(),
                repairService = this.repairService.ToList(),
                technicalPortService = this.technicalPortService.ToList(),
                shipSanitationControl = this.shipSanitationControl.ToList(),
                transportConnection = this.transportConnection.ToList(),
                berthingAssistance = this.berthingAssistance.ToList(),
                cargoService = this.cargoService.ToList(),
                securitySafetyEmergencyService = this.securitySafetyEmergencyService.ToList(),
                wasteDisposalService = this.wasteDisposalService.ToList(),
                supplyService = this.supplyService.ToList(),
                tugInformation = this.tugInformation,
                textContent = this.textContent.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.AvailablePortServices Model => new()
        {
            firefightingService = this.firefightingService.ToList(),
            medicalService = this.medicalService.ToList(),
            repairService = this.repairService.ToList(),
            technicalPortService = this.technicalPortService.ToList(),
            shipSanitationControl = this.shipSanitationControl.ToList(),
            transportConnection = this.transportConnection.ToList(),
            berthingAssistance = this.berthingAssistance.ToList(),
            cargoService = this.cargoService.ToList(),
            securitySafetyEmergencyService = this.securitySafetyEmergencyService.ToList(),
            wasteDisposalService = this.wasteDisposalService.ToList(),
            supplyService = this.supplyService.ToList(),
            tugInformation = this._tugInformation,
            textContent = this.textContent.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public AvailablePortServicesViewModel() : base() {
            firefightingService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(firefightingService));
            };
            medicalService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(medicalService));
            };
            repairService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(repairService));
            };
            technicalPortService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(technicalPortService));
            };
            shipSanitationControl.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(shipSanitationControl));
            };
            transportConnection.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(transportConnection));
            };
            berthingAssistance.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(berthingAssistance));
            };
            cargoService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(cargoService));
            };
            securitySafetyEmergencyService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(securitySafetyEmergencyService));
            };
            wasteDisposalService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(wasteDisposalService));
            };
            supplyService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(supplyService));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
        }

        public override string? ToString() => $"Available Port Services";
    }

    [CategoryOrder("ContactDetails", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ContactDetailsViewModel : InformationViewModel<ContactDetails> {
        private String _callName = string.Empty;
        [Category("ContactDetails")]
        public String callName {
            get {
                return _callName;
            }

            set {
                SetValue(ref _callName, value);
            }
        }

        private String _callSign = string.Empty;
        [Category("ContactDetails")]
        public String callSign {
            get {
                return _callSign;
            }

            set {
                SetValue(ref _callSign, value);
            }
        }

        private categoryOfCommunicationPreference? _categoryOfCommunicationPreference = default;
        [DomainModel.EnumerationAttribute(nameof(categoryOfCommunicationPreferenceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("ContactDetails")]
        public categoryOfCommunicationPreference? categoryOfCommunicationPreference {
            get {
                return _categoryOfCommunicationPreference;
            }

            set {
                SetValue(ref _categoryOfCommunicationPreference, value);
            }
        }

        [Category("ContactDetails")]
        public ObservableCollection<String> communicationChannel { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<contactAddress> contactAddress { get; set; } = new();

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
        public ObservableCollection<Int32> signalFrequency { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<frequencyPair> frequencyPair { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<information> information { get; set; } = new();

        private String _mMSICode = string.Empty;
        [Category("ContactDetails")]
        public String mMSICode {
            get {
                return _mMSICode;
            }

            set {
                SetValue(ref _mMSICode, value);
            }
        }

        [Category("ContactDetails")]
        public ObservableCollection<onlineResource> onlineResource { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<telecommunications> telecommunications { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("InformationType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => ContactDetails.informationBindingDefinitions;

        [Browsable(false)]
        public categoryOfCommunicationPreference[] categoryOfCommunicationPreferenceList => [(categoryOfCommunicationPreference)1, (categoryOfCommunicationPreference)2, (categoryOfCommunicationPreference)3, (categoryOfCommunicationPreference)4];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.InformationTypes.ContactDetails instance) {
            callName = instance.callName;
            callSign = instance.callSign;
            categoryOfCommunicationPreference = instance.categoryOfCommunicationPreference;
            communicationChannel.Clear();
            if (instance.communicationChannel is not null)
                foreach (var e in instance.communicationChannel)
                    communicationChannel.Add(e);
            contactAddress.Clear();
            if (instance.contactAddress is not null)
                foreach (var e in instance.contactAddress)
                    contactAddress.Add(e);
            contactInstructions = instance.contactInstructions;
            signalFrequency.Clear();
            if (instance.signalFrequency is not null)
                foreach (var e in instance.signalFrequency)
                    signalFrequency.Add(e);
            frequencyPair.Clear();
            if (instance.frequencyPair is not null)
                foreach (var e in instance.frequencyPair)
                    frequencyPair.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            mMSICode = instance.mMSICode;
            onlineResource.Clear();
            if (instance.onlineResource is not null)
                foreach (var e in instance.onlineResource)
                    onlineResource.Add(e);
            telecommunications.Clear();
            if (instance.telecommunications is not null)
                foreach (var e in instance.telecommunications)
                    telecommunications.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.InformationTypes.ContactDetails
            {
                callName = this.callName,
                callSign = this.callSign,
                categoryOfCommunicationPreference = this.categoryOfCommunicationPreference,
                communicationChannel = this.communicationChannel.ToList(),
                contactAddress = this.contactAddress.ToList(),
                contactInstructions = this.contactInstructions,
                signalFrequency = this.signalFrequency.ToList(),
                frequencyPair = this.frequencyPair.ToList(),
                information = this.information.ToList(),
                mMSICode = this.mMSICode,
                onlineResource = this.onlineResource.ToList(),
                telecommunications = this.telecommunications.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.ContactDetails Model => new()
        {
            callName = this._callName,
            callSign = this._callSign,
            categoryOfCommunicationPreference = this._categoryOfCommunicationPreference,
            communicationChannel = this.communicationChannel.ToList(),
            contactAddress = this.contactAddress.ToList(),
            contactInstructions = this._contactInstructions,
            signalFrequency = this.signalFrequency.ToList(),
            frequencyPair = this.frequencyPair.ToList(),
            information = this.information.ToList(),
            mMSICode = this._mMSICode,
            onlineResource = this.onlineResource.ToList(),
            telecommunications = this.telecommunications.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public ContactDetailsViewModel() : base() {
            communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(communicationChannel));
            };
            contactAddress.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(contactAddress));
            };
            signalFrequency.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(signalFrequency));
            };
            frequencyPair.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(frequencyPair));
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
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
        }

        public override string? ToString() => $"Contact Details";
    }

    [CategoryOrder("Entrance", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class EntranceViewModel : InformationViewModel<Entrance> {
        private String _entranceDescription = string.Empty;
        [Category("Entrance")]
        public String entranceDescription {
            get {
                return _entranceDescription;
            }

            set {
                SetValue(ref _entranceDescription, value);
            }
        }

        [Category("Entrance")]
        public ObservableCollection<String> associatedFeatureName { get; set; } = new();

        private String _localKnowledgeDescription = string.Empty;
        [Category("Entrance")]
        public String localKnowledgeDescription {
            get {
                return _localKnowledgeDescription;
            }

            set {
                SetValue(ref _localKnowledgeDescription, value);
            }
        }

        private String _approachDescription = string.Empty;
        [Category("Entrance")]
        public String approachDescription {
            get {
                return _approachDescription;
            }

            set {
                SetValue(ref _approachDescription, value);
            }
        }

        [Category("Entrance")]
        public ObservableCollection<markedBy> markedBy { get; set; } = new();

        [Category("Entrance")]
        public ObservableCollection<landmarkDescription> landmarkDescription { get; set; } = new();

        [Category("Entrance")]
        public ObservableCollection<offshoreMarkDescription> offshoreMarkDescription { get; set; } = new();

        [Category("Entrance")]
        public ObservableCollection<majorLightDescription> majorLightDescription { get; set; } = new();

        [Category("Entrance")]
        public ObservableCollection<usefulMarkDescription> usefulMarkDescription { get; set; } = new();

        [Category("Entrance")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("InformationType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => Entrance.informationBindingDefinitions;

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.InformationTypes.Entrance instance) {
            entranceDescription = instance.entranceDescription;
            associatedFeatureName.Clear();
            if (instance.associatedFeatureName is not null)
                foreach (var e in instance.associatedFeatureName)
                    associatedFeatureName.Add(e);
            localKnowledgeDescription = instance.localKnowledgeDescription;
            approachDescription = instance.approachDescription;
            markedBy.Clear();
            if (instance.markedBy is not null)
                foreach (var e in instance.markedBy)
                    markedBy.Add(e);
            landmarkDescription.Clear();
            if (instance.landmarkDescription is not null)
                foreach (var e in instance.landmarkDescription)
                    landmarkDescription.Add(e);
            offshoreMarkDescription.Clear();
            if (instance.offshoreMarkDescription is not null)
                foreach (var e in instance.offshoreMarkDescription)
                    offshoreMarkDescription.Add(e);
            majorLightDescription.Clear();
            if (instance.majorLightDescription is not null)
                foreach (var e in instance.majorLightDescription)
                    majorLightDescription.Add(e);
            usefulMarkDescription.Clear();
            if (instance.usefulMarkDescription is not null)
                foreach (var e in instance.usefulMarkDescription)
                    usefulMarkDescription.Add(e);
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.InformationTypes.Entrance
            {
                entranceDescription = this.entranceDescription,
                associatedFeatureName = this.associatedFeatureName.ToList(),
                localKnowledgeDescription = this.localKnowledgeDescription,
                approachDescription = this.approachDescription,
                markedBy = this.markedBy.ToList(),
                landmarkDescription = this.landmarkDescription.ToList(),
                offshoreMarkDescription = this.offshoreMarkDescription.ToList(),
                majorLightDescription = this.majorLightDescription.ToList(),
                usefulMarkDescription = this.usefulMarkDescription.ToList(),
                textContent = this.textContent.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.Entrance Model => new()
        {
            entranceDescription = this._entranceDescription,
            associatedFeatureName = this.associatedFeatureName.ToList(),
            localKnowledgeDescription = this._localKnowledgeDescription,
            approachDescription = this._approachDescription,
            markedBy = this.markedBy.ToList(),
            landmarkDescription = this.landmarkDescription.ToList(),
            offshoreMarkDescription = this.offshoreMarkDescription.ToList(),
            majorLightDescription = this.majorLightDescription.ToList(),
            usefulMarkDescription = this.usefulMarkDescription.ToList(),
            textContent = this.textContent.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public EntranceViewModel() : base() {
            associatedFeatureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(associatedFeatureName));
            };
            markedBy.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(markedBy));
            };
            landmarkDescription.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(landmarkDescription));
            };
            offshoreMarkDescription.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(offshoreMarkDescription));
            };
            majorLightDescription.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(majorLightDescription));
            };
            usefulMarkDescription.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(usefulMarkDescription));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
        }

        public override string? ToString() => $"Entrance";
    }

    [CategoryOrder("NauticalInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class NauticalInformationViewModel : InformationViewModel<NauticalInformation> {
        private categoryOfAuthority? _categoryOfAuthority = default;
        [DomainModel.EnumerationAttribute(nameof(categoryOfAuthorityList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("AbstractRxN")]
        public categoryOfAuthority? categoryOfAuthority {
            get {
                return _categoryOfAuthority;
            }

            set {
                SetValue(ref _categoryOfAuthority, value);
            }
        }

        [Category("AbstractRxN")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("AbstractRxN")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("InformationType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => NauticalInformation.informationBindingDefinitions;

        [Browsable(false)]
        public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2, (categoryOfAuthority)3, (categoryOfAuthority)4, (categoryOfAuthority)5, (categoryOfAuthority)6, (categoryOfAuthority)7, (categoryOfAuthority)8, (categoryOfAuthority)9, (categoryOfAuthority)10, (categoryOfAuthority)11, (categoryOfAuthority)12, (categoryOfAuthority)13, (categoryOfAuthority)14, (categoryOfAuthority)15, (categoryOfAuthority)16];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.InformationTypes.NauticalInformation instance) {
            categoryOfAuthority = instance.categoryOfAuthority;
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.InformationTypes.NauticalInformation
            {
                categoryOfAuthority = this.categoryOfAuthority,
                rxNCode = this.rxNCode.ToList(),
                textContent = this.textContent.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.NauticalInformation Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            rxNCode = this.rxNCode.ToList(),
            textContent = this.textContent.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public NauticalInformationViewModel() : base() {
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
        }

        public override string? ToString() => $"Nautical Information";
    }

    [CategoryOrder("NonStandardWorkingDay", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class NonStandardWorkingDayViewModel : InformationViewModel<NonStandardWorkingDay> {
        [Category("NonStandardWorkingDay")]
        public ObservableCollection<DateOnly> dateFixed { get; set; } = new();

        [Category("NonStandardWorkingDay")]
        public ObservableCollection<String> dateVariable { get; set; } = new();

        [Category("NonStandardWorkingDay")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("InformationType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => NonStandardWorkingDay.informationBindingDefinitions;

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.InformationTypes.NonStandardWorkingDay instance) {
            dateFixed.Clear();
            if (instance.dateFixed is not null)
                foreach (var e in instance.dateFixed)
                    dateFixed.Add(e);
            dateVariable.Clear();
            if (instance.dateVariable is not null)
                foreach (var e in instance.dateVariable)
                    dateVariable.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.InformationTypes.NonStandardWorkingDay
            {
                dateFixed = this.dateFixed.ToList(),
                dateVariable = this.dateVariable.ToList(),
                information = this.information.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.NonStandardWorkingDay Model => new()
        {
            dateFixed = this.dateFixed.ToList(),
            dateVariable = this.dateVariable.ToList(),
            information = this.information.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public NonStandardWorkingDayViewModel() : base() {
            dateFixed.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(dateFixed));
            };
            dateVariable.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(dateVariable));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
        }

        public override string? ToString() => $"Non-Standard Working Day";
    }

    [CategoryOrder("Recommendations", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RecommendationsViewModel : InformationViewModel<Recommendations> {
        private categoryOfAuthority? _categoryOfAuthority = default;
        [DomainModel.EnumerationAttribute(nameof(categoryOfAuthorityList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("AbstractRxN")]
        public categoryOfAuthority? categoryOfAuthority {
            get {
                return _categoryOfAuthority;
            }

            set {
                SetValue(ref _categoryOfAuthority, value);
            }
        }

        [Category("AbstractRxN")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("AbstractRxN")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("InformationType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => Recommendations.informationBindingDefinitions;

        [Browsable(false)]
        public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2, (categoryOfAuthority)3, (categoryOfAuthority)4, (categoryOfAuthority)5, (categoryOfAuthority)6, (categoryOfAuthority)7, (categoryOfAuthority)8, (categoryOfAuthority)9, (categoryOfAuthority)10, (categoryOfAuthority)11, (categoryOfAuthority)12, (categoryOfAuthority)13, (categoryOfAuthority)14, (categoryOfAuthority)15, (categoryOfAuthority)16];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.InformationTypes.Recommendations instance) {
            categoryOfAuthority = instance.categoryOfAuthority;
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.InformationTypes.Recommendations
            {
                categoryOfAuthority = this.categoryOfAuthority,
                rxNCode = this.rxNCode.ToList(),
                textContent = this.textContent.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.Recommendations Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            rxNCode = this.rxNCode.ToList(),
            textContent = this.textContent.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public RecommendationsViewModel() : base() {
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
        }

        public override string? ToString() => $"Recommendations";
    }

    [CategoryOrder("Regulations", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RegulationsViewModel : InformationViewModel<Regulations> {
        private categoryOfAuthority? _categoryOfAuthority = default;
        [DomainModel.EnumerationAttribute(nameof(categoryOfAuthorityList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("AbstractRxN")]
        public categoryOfAuthority? categoryOfAuthority {
            get {
                return _categoryOfAuthority;
            }

            set {
                SetValue(ref _categoryOfAuthority, value);
            }
        }

        [Category("AbstractRxN")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("AbstractRxN")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("InformationType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => Regulations.informationBindingDefinitions;

        [Browsable(false)]
        public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2, (categoryOfAuthority)3, (categoryOfAuthority)4, (categoryOfAuthority)5, (categoryOfAuthority)6, (categoryOfAuthority)7, (categoryOfAuthority)8, (categoryOfAuthority)9, (categoryOfAuthority)10, (categoryOfAuthority)11, (categoryOfAuthority)12, (categoryOfAuthority)13, (categoryOfAuthority)14, (categoryOfAuthority)15, (categoryOfAuthority)16];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.InformationTypes.Regulations instance) {
            categoryOfAuthority = instance.categoryOfAuthority;
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.InformationTypes.Regulations
            {
                categoryOfAuthority = this.categoryOfAuthority,
                rxNCode = this.rxNCode.ToList(),
                textContent = this.textContent.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.Regulations Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            rxNCode = this.rxNCode.ToList(),
            textContent = this.textContent.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public RegulationsViewModel() : base() {
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
        }

        public override string? ToString() => $"Regulations";
    }

    [CategoryOrder("Restrictions", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RestrictionsViewModel : InformationViewModel<Restrictions> {
        private categoryOfAuthority? _categoryOfAuthority = default;
        [DomainModel.EnumerationAttribute(nameof(categoryOfAuthorityList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("AbstractRxN")]
        public categoryOfAuthority? categoryOfAuthority {
            get {
                return _categoryOfAuthority;
            }

            set {
                SetValue(ref _categoryOfAuthority, value);
            }
        }

        [Category("AbstractRxN")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("AbstractRxN")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("InformationType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => Restrictions.informationBindingDefinitions;

        [Browsable(false)]
        public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2, (categoryOfAuthority)3, (categoryOfAuthority)4, (categoryOfAuthority)5, (categoryOfAuthority)6, (categoryOfAuthority)7, (categoryOfAuthority)8, (categoryOfAuthority)9, (categoryOfAuthority)10, (categoryOfAuthority)11, (categoryOfAuthority)12, (categoryOfAuthority)13, (categoryOfAuthority)14, (categoryOfAuthority)15, (categoryOfAuthority)16];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.InformationTypes.Restrictions instance) {
            categoryOfAuthority = instance.categoryOfAuthority;
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.InformationTypes.Restrictions
            {
                categoryOfAuthority = this.categoryOfAuthority,
                rxNCode = this.rxNCode.ToList(),
                textContent = this.textContent.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.Restrictions Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            rxNCode = this.rxNCode.ToList(),
            textContent = this.textContent.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public RestrictionsViewModel() : base() {
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
        }

        public override string? ToString() => $"Restrictions";
    }

    [CategoryOrder("ServiceHours", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ServiceHoursViewModel : InformationViewModel<ServiceHours> {
        [Category("ServiceHours")]
        public ObservableCollection<scheduleByDayOfWeek> scheduleByDayOfWeek { get; set; } = new();

        [Category("ServiceHours")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("InformationType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => ServiceHours.informationBindingDefinitions;

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.InformationTypes.ServiceHours instance) {
            scheduleByDayOfWeek.Clear();
            if (instance.scheduleByDayOfWeek is not null)
                foreach (var e in instance.scheduleByDayOfWeek)
                    scheduleByDayOfWeek.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.InformationTypes.ServiceHours
            {
                scheduleByDayOfWeek = this.scheduleByDayOfWeek.ToList(),
                information = this.information.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.ServiceHours Model => new()
        {
            scheduleByDayOfWeek = this.scheduleByDayOfWeek.ToList(),
            information = this.information.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public ServiceHoursViewModel() : base() {
            scheduleByDayOfWeek.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(scheduleByDayOfWeek));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
        }

        public override string? ToString() => $"Service Hours";
    }

    [CategoryOrder("SpatialQuality", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class SpatialQualityViewModel : InformationViewModel<SpatialQuality> {
        private qualityOfHorizontalMeasurement? _qualityOfHorizontalMeasurement = default;
        [DomainModel.EnumerationAttribute(nameof(qualityOfHorizontalMeasurementList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("SpatialQuality")]
        public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {
            get {
                return _qualityOfHorizontalMeasurement;
            }

            set {
                SetValue(ref _qualityOfHorizontalMeasurement, value);
            }
        }

        [Category("SpatialQuality")]
        public ObservableCollection<spatialAccuracy> spatialAccuracy { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => SpatialQuality.informationBindingDefinitions;

        [Browsable(false)]
        public qualityOfHorizontalMeasurement[] qualityOfHorizontalMeasurementList => [(qualityOfHorizontalMeasurement)1, (qualityOfHorizontalMeasurement)2, (qualityOfHorizontalMeasurement)3, (qualityOfHorizontalMeasurement)4, (qualityOfHorizontalMeasurement)5, (qualityOfHorizontalMeasurement)6, (qualityOfHorizontalMeasurement)7, (qualityOfHorizontalMeasurement)8, (qualityOfHorizontalMeasurement)9, (qualityOfHorizontalMeasurement)10, (qualityOfHorizontalMeasurement)11];

        public override void Load(DomainModel.S131.InformationTypes.SpatialQuality instance) {
            qualityOfHorizontalMeasurement = instance.qualityOfHorizontalMeasurement;
            spatialAccuracy.Clear();
            if (instance.spatialAccuracy is not null)
                foreach (var e in instance.spatialAccuracy)
                    spatialAccuracy.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.InformationTypes.SpatialQuality
            {
                qualityOfHorizontalMeasurement = this.qualityOfHorizontalMeasurement,
                spatialAccuracy = this.spatialAccuracy.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.SpatialQuality Model => new()
        {
            qualityOfHorizontalMeasurement = this._qualityOfHorizontalMeasurement,
            spatialAccuracy = this.spatialAccuracy.ToList(),
        };

        public SpatialQualityViewModel() : base() {
            spatialAccuracy.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(spatialAccuracy));
            };
        }

        public override string? ToString() => $"Spatial Quality";
    }

    [CategoryOrder("AnchorBerth", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class AnchorBerthViewModel : FeatureViewModel<AnchorBerth> {
        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN {
            get {
                return _locationMRN;
            }

            set {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber {
            get {
                return _globalLocationNumber;
            }

            set {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FeatureType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => AnchorBerth.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => AnchorBerth.featureBindingDefinitions;

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.FeatureTypes.AnchorBerth instance) {
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.AnchorBerth
            {
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.AnchorBerth Model => new()
        {
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public AnchorBerthViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Anchor Berth";
    }

    [CategoryOrder("AnchorageArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class AnchorageAreaViewModel : FeatureViewModel<AnchorageArea> {
        private depthsDescriptionViewModel? _depthsDescription;
        [Category("AnchorageArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public depthsDescriptionViewModel? depthsDescription {
            get {
                return _depthsDescription;
            }

            set {
                SetValue(ref _depthsDescription, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("AnchorageArea")]
        public String locationByText {
            get {
                return _locationByText;
            }

            set {
                SetValue(ref _locationByText, value);
            }
        }

        private markedByViewModel? _markedBy;
        [Category("AnchorageArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public markedByViewModel? markedBy {
            get {
                return _markedBy;
            }

            set {
                SetValue(ref _markedBy, value);
            }
        }

        private iSPSLevel? _iSPSLevel = default;
        [DomainModel.EnumerationAttribute(nameof(iSPSLevelList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("AnchorageArea")]
        public iSPSLevel? iSPSLevel {
            get {
                return _iSPSLevel;
            }

            set {
                SetValue(ref _iSPSLevel, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN {
            get {
                return _locationMRN;
            }

            set {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber {
            get {
                return _globalLocationNumber;
            }

            set {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FeatureType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => AnchorageArea.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => AnchorageArea.featureBindingDefinitions;

        [Browsable(false)]
        public iSPSLevel[] iSPSLevelList => [(iSPSLevel)1, (iSPSLevel)2, (iSPSLevel)3];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.FeatureTypes.AnchorageArea instance) {
            depthsDescription = new();
            if (instance.depthsDescription != null) {
                depthsDescription = new();
                depthsDescription.Load(instance.depthsDescription);
            }

            locationByText = instance.locationByText;
            markedBy = new();
            if (instance.markedBy != null) {
                markedBy = new();
                markedBy.Load(instance.markedBy);
            }

            iSPSLevel = instance.iSPSLevel;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.AnchorageArea
            {
                depthsDescription = this.depthsDescription?.Model,
                locationByText = this.locationByText,
                markedBy = this.markedBy?.Model,
                iSPSLevel = this.iSPSLevel,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.AnchorageArea Model => new()
        {
            depthsDescription = this._depthsDescription?.Model,
            locationByText = this._locationByText,
            markedBy = this._markedBy?.Model,
            iSPSLevel = this._iSPSLevel,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public AnchorageAreaViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Anchorage Area";
    }

    [CategoryOrder("Berth", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class BerthViewModel : FeatureViewModel<Berth> {
        private Decimal? _availableBerthingLength = default;
        [Category("Berth")]
        public Decimal? availableBerthingLength {
            get {
                return _availableBerthingLength;
            }

            set {
                SetValue(ref _availableBerthingLength, value);
            }
        }

        private String _bollardDescription = string.Empty;
        [Category("Berth")]
        public String bollardDescription {
            get {
                return _bollardDescription;
            }

            set {
                SetValue(ref _bollardDescription, value);
            }
        }

        private Decimal? _bollardPull = default;
        [Category("Berth")]
        public Decimal? bollardPull {
            get {
                return _bollardPull;
            }

            set {
                SetValue(ref _bollardPull, value);
            }
        }

        private Decimal? _minimumBerthDepth = default;
        [Category("Berth")]
        public Decimal? minimumBerthDepth {
            get {
                return _minimumBerthDepth;
            }

            set {
                SetValue(ref _minimumBerthDepth, value);
            }
        }

        private Decimal? _elevation = default;
        [Category("Berth")]
        public Decimal? elevation {
            get {
                return _elevation;
            }

            set {
                SetValue(ref _elevation, value);
            }
        }

        private Boolean? _cathodicProtectionSystem = default;
        [Category("Berth")]
        public Boolean? cathodicProtectionSystem {
            get {
                return _cathodicProtectionSystem;
            }

            set {
                SetValue(ref _cathodicProtectionSystem, value);
            }
        }

        private categoryOfBerthLocation? _categoryOfBerthLocation = default;
        [DomainModel.EnumerationAttribute(nameof(categoryOfBerthLocationList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("Berth")]
        public categoryOfBerthLocation? categoryOfBerthLocation {
            get {
                return _categoryOfBerthLocation;
            }

            set {
                SetValue(ref _categoryOfBerthLocation, value);
            }
        }

        private String _portFacilityNumber = string.Empty;
        [Category("Berth")]
        public String portFacilityNumber {
            get {
                return _portFacilityNumber;
            }

            set {
                SetValue(ref _portFacilityNumber, value);
            }
        }

        [Category("Berth")]
        public ObservableCollection<String> bollardNumber { get; set; } = new();

        private String _gLNExtension = string.Empty;
        [Category("Berth")]
        public String gLNExtension {
            get {
                return _gLNExtension;
            }

            set {
                SetValue(ref _gLNExtension, value);
            }
        }

        [Category("Berth")]
        public ObservableCollection<String> metreMarkNumber { get; set; } = new();

        [Category("Berth")]
        public ObservableCollection<String> manifoldNumber { get; set; } = new();

        private String _rampNumber = string.Empty;
        [Category("Berth")]
        public String rampNumber {
            get {
                return _rampNumber;
            }

            set {
                SetValue(ref _rampNumber, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("Berth")]
        public String locationByText {
            get {
                return _locationByText;
            }

            set {
                SetValue(ref _locationByText, value);
            }
        }

        private methodOfSecuring? _methodOfSecuring = default;
        [DomainModel.EnumerationAttribute(nameof(methodOfSecuringList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("Berth")]
        public methodOfSecuring? methodOfSecuring {
            get {
                return _methodOfSecuring;
            }

            set {
                SetValue(ref _methodOfSecuring, value);
            }
        }

        private String _uNLocationCode = string.Empty;
        [Category("Berth")]
        public String uNLocationCode {
            get {
                return _uNLocationCode;
            }

            set {
                SetValue(ref _uNLocationCode, value);
            }
        }

        private String _terminalIdentifier = string.Empty;
        [Category("Berth")]
        public String terminalIdentifier {
            get {
                return _terminalIdentifier;
            }

            set {
                SetValue(ref _terminalIdentifier, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN {
            get {
                return _locationMRN;
            }

            set {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber {
            get {
                return _globalLocationNumber;
            }

            set {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FeatureType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => Berth.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => Berth.featureBindingDefinitions;

        [Browsable(false)]
        public categoryOfBerthLocation[] categoryOfBerthLocationList => [(categoryOfBerthLocation)1, (categoryOfBerthLocation)2, (categoryOfBerthLocation)3, (categoryOfBerthLocation)4];

        [Browsable(false)]
        public methodOfSecuring[] methodOfSecuringList => [(methodOfSecuring)1, (methodOfSecuring)2, (methodOfSecuring)3, (methodOfSecuring)4, (methodOfSecuring)5, (methodOfSecuring)6, (methodOfSecuring)7, (methodOfSecuring)8, (methodOfSecuring)9, (methodOfSecuring)10];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.FeatureTypes.Berth instance) {
            availableBerthingLength = instance.availableBerthingLength;
            bollardDescription = instance.bollardDescription;
            bollardPull = instance.bollardPull;
            minimumBerthDepth = instance.minimumBerthDepth;
            elevation = instance.elevation;
            cathodicProtectionSystem = instance.cathodicProtectionSystem;
            categoryOfBerthLocation = instance.categoryOfBerthLocation;
            portFacilityNumber = instance.portFacilityNumber;
            bollardNumber.Clear();
            if (instance.bollardNumber is not null)
                foreach (var e in instance.bollardNumber)
                    bollardNumber.Add(e);
            gLNExtension = instance.gLNExtension;
            metreMarkNumber.Clear();
            if (instance.metreMarkNumber is not null)
                foreach (var e in instance.metreMarkNumber)
                    metreMarkNumber.Add(e);
            manifoldNumber.Clear();
            if (instance.manifoldNumber is not null)
                foreach (var e in instance.manifoldNumber)
                    manifoldNumber.Add(e);
            rampNumber = instance.rampNumber;
            locationByText = instance.locationByText;
            methodOfSecuring = instance.methodOfSecuring;
            uNLocationCode = instance.uNLocationCode;
            terminalIdentifier = instance.terminalIdentifier;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.Berth
            {
                availableBerthingLength = this.availableBerthingLength,
                bollardDescription = this.bollardDescription,
                bollardPull = this.bollardPull,
                minimumBerthDepth = this.minimumBerthDepth,
                elevation = this.elevation,
                cathodicProtectionSystem = this.cathodicProtectionSystem,
                categoryOfBerthLocation = this.categoryOfBerthLocation,
                portFacilityNumber = this.portFacilityNumber,
                bollardNumber = this.bollardNumber.ToList(),
                gLNExtension = this.gLNExtension,
                metreMarkNumber = this.metreMarkNumber.ToList(),
                manifoldNumber = this.manifoldNumber.ToList(),
                rampNumber = this.rampNumber,
                locationByText = this.locationByText,
                methodOfSecuring = this.methodOfSecuring,
                uNLocationCode = this.uNLocationCode,
                terminalIdentifier = this.terminalIdentifier,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.Berth Model => new()
        {
            availableBerthingLength = this._availableBerthingLength,
            bollardDescription = this._bollardDescription,
            bollardPull = this._bollardPull,
            minimumBerthDepth = this._minimumBerthDepth,
            elevation = this._elevation,
            cathodicProtectionSystem = this._cathodicProtectionSystem,
            categoryOfBerthLocation = this._categoryOfBerthLocation,
            portFacilityNumber = this._portFacilityNumber,
            bollardNumber = this.bollardNumber.ToList(),
            gLNExtension = this._gLNExtension,
            metreMarkNumber = this.metreMarkNumber.ToList(),
            manifoldNumber = this.manifoldNumber.ToList(),
            rampNumber = this._rampNumber,
            locationByText = this._locationByText,
            methodOfSecuring = this._methodOfSecuring,
            uNLocationCode = this._uNLocationCode,
            terminalIdentifier = this._terminalIdentifier,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public BerthViewModel() : base() {
            bollardNumber.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(bollardNumber));
            };
            metreMarkNumber.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(metreMarkNumber));
            };
            manifoldNumber.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(manifoldNumber));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Berth";
    }

    [CategoryOrder("BerthPosition", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class BerthPositionViewModel : FeatureViewModel<BerthPosition> {
        private Decimal? _availableBerthingLength = default;
        [Category("BerthPosition")]
        public Decimal? availableBerthingLength {
            get {
                return _availableBerthingLength;
            }

            set {
                SetValue(ref _availableBerthingLength, value);
            }
        }

        private String _bollardDescription = string.Empty;
        [Category("BerthPosition")]
        public String bollardDescription {
            get {
                return _bollardDescription;
            }

            set {
                SetValue(ref _bollardDescription, value);
            }
        }

        private Decimal? _bollardPull = default;
        [Category("BerthPosition")]
        public Decimal? bollardPull {
            get {
                return _bollardPull;
            }

            set {
                SetValue(ref _bollardPull, value);
            }
        }

        [Category("BerthPosition")]
        public ObservableCollection<String> bollardNumber { get; set; } = new();

        private String _gLNExtension = string.Empty;
        [Category("BerthPosition")]
        public String gLNExtension {
            get {
                return _gLNExtension;
            }

            set {
                SetValue(ref _gLNExtension, value);
            }
        }

        [Category("BerthPosition")]
        public ObservableCollection<String> metreMarkNumber { get; set; } = new();

        [Category("BerthPosition")]
        public ObservableCollection<String> manifoldNumber { get; set; } = new();

        private String _rampNumber = string.Empty;
        [Category("BerthPosition")]
        public String rampNumber {
            get {
                return _rampNumber;
            }

            set {
                SetValue(ref _rampNumber, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("BerthPosition")]
        public String locationByText {
            get {
                return _locationByText;
            }

            set {
                SetValue(ref _locationByText, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN {
            get {
                return _locationMRN;
            }

            set {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber {
            get {
                return _globalLocationNumber;
            }

            set {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FeatureType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => BerthPosition.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => BerthPosition.featureBindingDefinitions;

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.FeatureTypes.BerthPosition instance) {
            availableBerthingLength = instance.availableBerthingLength;
            bollardDescription = instance.bollardDescription;
            bollardPull = instance.bollardPull;
            bollardNumber.Clear();
            if (instance.bollardNumber is not null)
                foreach (var e in instance.bollardNumber)
                    bollardNumber.Add(e);
            gLNExtension = instance.gLNExtension;
            metreMarkNumber.Clear();
            if (instance.metreMarkNumber is not null)
                foreach (var e in instance.metreMarkNumber)
                    metreMarkNumber.Add(e);
            manifoldNumber.Clear();
            if (instance.manifoldNumber is not null)
                foreach (var e in instance.manifoldNumber)
                    manifoldNumber.Add(e);
            rampNumber = instance.rampNumber;
            locationByText = instance.locationByText;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.BerthPosition
            {
                availableBerthingLength = this.availableBerthingLength,
                bollardDescription = this.bollardDescription,
                bollardPull = this.bollardPull,
                bollardNumber = this.bollardNumber.ToList(),
                gLNExtension = this.gLNExtension,
                metreMarkNumber = this.metreMarkNumber.ToList(),
                manifoldNumber = this.manifoldNumber.ToList(),
                rampNumber = this.rampNumber,
                locationByText = this.locationByText,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.BerthPosition Model => new()
        {
            availableBerthingLength = this._availableBerthingLength,
            bollardDescription = this._bollardDescription,
            bollardPull = this._bollardPull,
            bollardNumber = this.bollardNumber.ToList(),
            gLNExtension = this._gLNExtension,
            metreMarkNumber = this.metreMarkNumber.ToList(),
            manifoldNumber = this.manifoldNumber.ToList(),
            rampNumber = this._rampNumber,
            locationByText = this._locationByText,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public BerthPositionViewModel() : base() {
            bollardNumber.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(bollardNumber));
            };
            metreMarkNumber.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(metreMarkNumber));
            };
            manifoldNumber.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(manifoldNumber));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Berth Position";
    }

    [CategoryOrder("DockArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DockAreaViewModel : FeatureViewModel<DockArea> {
        private depthsDescriptionViewModel? _depthsDescription;
        [Category("DockArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public depthsDescriptionViewModel? depthsDescription {
            get {
                return _depthsDescription;
            }

            set {
                SetValue(ref _depthsDescription, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("DockArea")]
        public String locationByText {
            get {
                return _locationByText;
            }

            set {
                SetValue(ref _locationByText, value);
            }
        }

        private markedByViewModel? _markedBy;
        [Category("DockArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public markedByViewModel? markedBy {
            get {
                return _markedBy;
            }

            set {
                SetValue(ref _markedBy, value);
            }
        }

        private iSPSLevel? _iSPSLevel = default;
        [DomainModel.EnumerationAttribute(nameof(iSPSLevelList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("DockArea")]
        public iSPSLevel? iSPSLevel {
            get {
                return _iSPSLevel;
            }

            set {
                SetValue(ref _iSPSLevel, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN {
            get {
                return _locationMRN;
            }

            set {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber {
            get {
                return _globalLocationNumber;
            }

            set {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FeatureType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => DockArea.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => DockArea.featureBindingDefinitions;

        [Browsable(false)]
        public iSPSLevel[] iSPSLevelList => [(iSPSLevel)1, (iSPSLevel)2, (iSPSLevel)3];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.FeatureTypes.DockArea instance) {
            depthsDescription = new();
            if (instance.depthsDescription != null) {
                depthsDescription = new();
                depthsDescription.Load(instance.depthsDescription);
            }

            locationByText = instance.locationByText;
            markedBy = new();
            if (instance.markedBy != null) {
                markedBy = new();
                markedBy.Load(instance.markedBy);
            }

            iSPSLevel = instance.iSPSLevel;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.DockArea
            {
                depthsDescription = this.depthsDescription?.Model,
                locationByText = this.locationByText,
                markedBy = this.markedBy?.Model,
                iSPSLevel = this.iSPSLevel,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.DockArea Model => new()
        {
            depthsDescription = this._depthsDescription?.Model,
            locationByText = this._locationByText,
            markedBy = this._markedBy?.Model,
            iSPSLevel = this._iSPSLevel,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public DockAreaViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Dock Area";
    }

    [CategoryOrder("DryDock", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DryDockViewModel : FeatureViewModel<DryDock> {
        private Decimal? _sillDepth = default;
        [Category("DryDock")]
        public Decimal? sillDepth {
            get {
                return _sillDepth;
            }

            set {
                SetValue(ref _sillDepth, value);
            }
        }

        private Decimal? _verticalClearanceValue = default;
        [Category("HarbourPhysicalInfrastructure")]
        public Decimal? verticalClearanceValue {
            get {
                return _verticalClearanceValue;
            }

            set {
                SetValue(ref _verticalClearanceValue, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN {
            get {
                return _locationMRN;
            }

            set {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber {
            get {
                return _globalLocationNumber;
            }

            set {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FeatureType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => DryDock.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => DryDock.featureBindingDefinitions;

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.FeatureTypes.DryDock instance) {
            sillDepth = instance.sillDepth;
            verticalClearanceValue = instance.verticalClearanceValue;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.DryDock
            {
                sillDepth = this.sillDepth,
                verticalClearanceValue = this.verticalClearanceValue,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.DryDock Model => new()
        {
            sillDepth = this._sillDepth,
            verticalClearanceValue = this._verticalClearanceValue,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public DryDockViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Dry Dock";
    }

    [CategoryOrder("DumpingGround", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DumpingGroundViewModel : FeatureViewModel<DumpingGround> {
        private depthsDescriptionViewModel? _depthsDescription;
        [Category("DumpingGround")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public depthsDescriptionViewModel? depthsDescription {
            get {
                return _depthsDescription;
            }

            set {
                SetValue(ref _depthsDescription, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("DumpingGround")]
        public String locationByText {
            get {
                return _locationByText;
            }

            set {
                SetValue(ref _locationByText, value);
            }
        }

        private markedByViewModel? _markedBy;
        [Category("DumpingGround")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public markedByViewModel? markedBy {
            get {
                return _markedBy;
            }

            set {
                SetValue(ref _markedBy, value);
            }
        }

        private iSPSLevel? _iSPSLevel = default;
        [DomainModel.EnumerationAttribute(nameof(iSPSLevelList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("DumpingGround")]
        public iSPSLevel? iSPSLevel {
            get {
                return _iSPSLevel;
            }

            set {
                SetValue(ref _iSPSLevel, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN {
            get {
                return _locationMRN;
            }

            set {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber {
            get {
                return _globalLocationNumber;
            }

            set {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FeatureType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => DumpingGround.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => DumpingGround.featureBindingDefinitions;

        [Browsable(false)]
        public iSPSLevel[] iSPSLevelList => [(iSPSLevel)1, (iSPSLevel)2, (iSPSLevel)3];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.FeatureTypes.DumpingGround instance) {
            depthsDescription = new();
            if (instance.depthsDescription != null) {
                depthsDescription = new();
                depthsDescription.Load(instance.depthsDescription);
            }

            locationByText = instance.locationByText;
            markedBy = new();
            if (instance.markedBy != null) {
                markedBy = new();
                markedBy.Load(instance.markedBy);
            }

            iSPSLevel = instance.iSPSLevel;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.DumpingGround
            {
                depthsDescription = this.depthsDescription?.Model,
                locationByText = this.locationByText,
                markedBy = this.markedBy?.Model,
                iSPSLevel = this.iSPSLevel,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.DumpingGround Model => new()
        {
            depthsDescription = this._depthsDescription?.Model,
            locationByText = this._locationByText,
            markedBy = this._markedBy?.Model,
            iSPSLevel = this._iSPSLevel,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public DumpingGroundViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Dumping Ground";
    }

    [CategoryOrder("FloatingDock", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class FloatingDockViewModel : FeatureViewModel<FloatingDock> {
        private Decimal? _sillDepth = default;
        [Category("FloatingDock")]
        public Decimal? sillDepth {
            get {
                return _sillDepth;
            }

            set {
                SetValue(ref _sillDepth, value);
            }
        }

        private Decimal? _verticalClearanceValue = default;
        [Category("HarbourPhysicalInfrastructure")]
        public Decimal? verticalClearanceValue {
            get {
                return _verticalClearanceValue;
            }

            set {
                SetValue(ref _verticalClearanceValue, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN {
            get {
                return _locationMRN;
            }

            set {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber {
            get {
                return _globalLocationNumber;
            }

            set {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FeatureType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => FloatingDock.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => FloatingDock.featureBindingDefinitions;

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.FeatureTypes.FloatingDock instance) {
            sillDepth = instance.sillDepth;
            verticalClearanceValue = instance.verticalClearanceValue;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.FloatingDock
            {
                sillDepth = this.sillDepth,
                verticalClearanceValue = this.verticalClearanceValue,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.FloatingDock Model => new()
        {
            sillDepth = this._sillDepth,
            verticalClearanceValue = this._verticalClearanceValue,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public FloatingDockViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Floating Dock";
    }

    [CategoryOrder("Gridiron", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class GridironViewModel : FeatureViewModel<Gridiron> {
        private Decimal? _sillDepth = default;
        [Category("Gridiron")]
        public Decimal? sillDepth {
            get {
                return _sillDepth;
            }

            set {
                SetValue(ref _sillDepth, value);
            }
        }

        private Decimal? _verticalClearanceValue = default;
        [Category("HarbourPhysicalInfrastructure")]
        public Decimal? verticalClearanceValue {
            get {
                return _verticalClearanceValue;
            }

            set {
                SetValue(ref _verticalClearanceValue, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN {
            get {
                return _locationMRN;
            }

            set {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber {
            get {
                return _globalLocationNumber;
            }

            set {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FeatureType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => Gridiron.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => Gridiron.featureBindingDefinitions;

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.FeatureTypes.Gridiron instance) {
            sillDepth = instance.sillDepth;
            verticalClearanceValue = instance.verticalClearanceValue;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.Gridiron
            {
                sillDepth = this.sillDepth,
                verticalClearanceValue = this.verticalClearanceValue,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.Gridiron Model => new()
        {
            sillDepth = this._sillDepth,
            verticalClearanceValue = this._verticalClearanceValue,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public GridironViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Gridiron";
    }

    [CategoryOrder("HarbourAreaAdministrative", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class HarbourAreaAdministrativeViewModel : FeatureViewModel<HarbourAreaAdministrative> {
        private String _uNLocationCode = string.Empty;
        [Category("HarbourAreaAdministrative")]
        public String uNLocationCode {
            get {
                return _uNLocationCode;
            }

            set {
                SetValue(ref _uNLocationCode, value);
            }
        }

        private String _nationality = string.Empty;
        [Category("HarbourAreaAdministrative")]
        public String nationality {
            get {
                return _nationality;
            }

            set {
                SetValue(ref _nationality, value);
            }
        }

        private String _applicableLoadLineZone = string.Empty;
        [Category("HarbourAreaAdministrative")]
        public String applicableLoadLineZone {
            get {
                return _applicableLoadLineZone;
            }

            set {
                SetValue(ref _applicableLoadLineZone, value);
            }
        }

        private iSPSLevel? _iSPSLevel = default;
        [DomainModel.EnumerationAttribute(nameof(iSPSLevelList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("HarbourAreaAdministrative")]
        public iSPSLevel? iSPSLevel {
            get {
                return _iSPSLevel;
            }

            set {
                SetValue(ref _iSPSLevel, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(categoryOfHarbourFacilityList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("HarbourAreaAdministrative")]
        public ObservableCollection<categoryOfHarbourFacility> categoryOfHarbourFacility { get; set; } = new();

        private generalHarbourInformationViewModel? _generalHarbourInformation;
        [Category("HarbourAreaAdministrative")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public generalHarbourInformationViewModel? generalHarbourInformation {
            get {
                return _generalHarbourInformation;
            }

            set {
                SetValue(ref _generalHarbourInformation, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN {
            get {
                return _locationMRN;
            }

            set {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber {
            get {
                return _globalLocationNumber;
            }

            set {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FeatureType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => HarbourAreaAdministrative.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => HarbourAreaAdministrative.featureBindingDefinitions;

        [Browsable(false)]
        public iSPSLevel[] iSPSLevelList => [(iSPSLevel)1, (iSPSLevel)2, (iSPSLevel)3];

        [Browsable(false)]
        public categoryOfHarbourFacility[] categoryOfHarbourFacilityList => [(categoryOfHarbourFacility)1, (categoryOfHarbourFacility)3, (categoryOfHarbourFacility)4, (categoryOfHarbourFacility)5, (categoryOfHarbourFacility)6, (categoryOfHarbourFacility)7, (categoryOfHarbourFacility)8, (categoryOfHarbourFacility)9, (categoryOfHarbourFacility)10, (categoryOfHarbourFacility)11, (categoryOfHarbourFacility)12, (categoryOfHarbourFacility)13, (categoryOfHarbourFacility)14, (categoryOfHarbourFacility)15];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.FeatureTypes.HarbourAreaAdministrative instance) {
            uNLocationCode = instance.uNLocationCode;
            nationality = instance.nationality;
            applicableLoadLineZone = instance.applicableLoadLineZone;
            iSPSLevel = instance.iSPSLevel;
            categoryOfHarbourFacility.Clear();
            if (instance.categoryOfHarbourFacility is not null)
                foreach (var e in instance.categoryOfHarbourFacility)
                    categoryOfHarbourFacility.Add(e);
            generalHarbourInformation = new();
            if (instance.generalHarbourInformation != null) {
                generalHarbourInformation = new();
                generalHarbourInformation.Load(instance.generalHarbourInformation);
            }

            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.HarbourAreaAdministrative
            {
                uNLocationCode = this.uNLocationCode,
                nationality = this.nationality,
                applicableLoadLineZone = this.applicableLoadLineZone,
                iSPSLevel = this.iSPSLevel,
                categoryOfHarbourFacility = this.categoryOfHarbourFacility.ToList(),
                generalHarbourInformation = this.generalHarbourInformation?.Model,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.HarbourAreaAdministrative Model => new()
        {
            uNLocationCode = this._uNLocationCode,
            nationality = this._nationality,
            applicableLoadLineZone = this._applicableLoadLineZone,
            iSPSLevel = this._iSPSLevel,
            categoryOfHarbourFacility = this.categoryOfHarbourFacility.ToList(),
            generalHarbourInformation = this._generalHarbourInformation?.Model,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public HarbourAreaAdministrativeViewModel() : base() {
            categoryOfHarbourFacility.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfHarbourFacility));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Harbour Area (Administrative)";
    }

    [CategoryOrder("HarbourAreaSection", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class HarbourAreaSectionViewModel : FeatureViewModel<HarbourAreaSection> {
        private categoryOfPortSection? _categoryOfPortSection = default;
        [DomainModel.EnumerationAttribute(nameof(categoryOfPortSectionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("HarbourAreaSection")]
        public categoryOfPortSection? categoryOfPortSection {
            get {
                return _categoryOfPortSection;
            }

            set {
                SetValue(ref _categoryOfPortSection, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(categoryOfHarbourFacilityList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("HarbourAreaSection")]
        public ObservableCollection<categoryOfHarbourFacility> categoryOfHarbourFacility { get; set; } = new();

        private iSPSLevel? _iSPSLevel = default;
        [DomainModel.EnumerationAttribute(nameof(iSPSLevelList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("HarbourAreaSection")]
        public iSPSLevel? iSPSLevel {
            get {
                return _iSPSLevel;
            }

            set {
                SetValue(ref _iSPSLevel, value);
            }
        }

        private facilitiesLayoutDescriptionViewModel? _facilitiesLayoutDescription;
        [Category("HarbourAreaSection")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public facilitiesLayoutDescriptionViewModel? facilitiesLayoutDescription {
            get {
                return _facilitiesLayoutDescription;
            }

            set {
                SetValue(ref _facilitiesLayoutDescription, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN {
            get {
                return _locationMRN;
            }

            set {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber {
            get {
                return _globalLocationNumber;
            }

            set {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FeatureType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => HarbourAreaSection.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => HarbourAreaSection.featureBindingDefinitions;

        [Browsable(false)]
        public categoryOfPortSection[] categoryOfPortSectionList => [(categoryOfPortSection)1, (categoryOfPortSection)3, (categoryOfPortSection)8, (categoryOfPortSection)9, (categoryOfPortSection)11, (categoryOfPortSection)12];

        [Browsable(false)]
        public categoryOfHarbourFacility[] categoryOfHarbourFacilityList => [(categoryOfHarbourFacility)4, (categoryOfHarbourFacility)5, (categoryOfHarbourFacility)6, (categoryOfHarbourFacility)9, (categoryOfHarbourFacility)14, (categoryOfHarbourFacility)15, (categoryOfHarbourFacility)16, (categoryOfHarbourFacility)17];

        [Browsable(false)]
        public iSPSLevel[] iSPSLevelList => [(iSPSLevel)1, (iSPSLevel)2, (iSPSLevel)3];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.FeatureTypes.HarbourAreaSection instance) {
            categoryOfPortSection = instance.categoryOfPortSection;
            categoryOfHarbourFacility.Clear();
            if (instance.categoryOfHarbourFacility is not null)
                foreach (var e in instance.categoryOfHarbourFacility)
                    categoryOfHarbourFacility.Add(e);
            iSPSLevel = instance.iSPSLevel;
            facilitiesLayoutDescription = new();
            if (instance.facilitiesLayoutDescription != null) {
                facilitiesLayoutDescription = new();
                facilitiesLayoutDescription.Load(instance.facilitiesLayoutDescription);
            }

            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.HarbourAreaSection
            {
                categoryOfPortSection = this.categoryOfPortSection,
                categoryOfHarbourFacility = this.categoryOfHarbourFacility.ToList(),
                iSPSLevel = this.iSPSLevel,
                facilitiesLayoutDescription = this.facilitiesLayoutDescription?.Model,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.HarbourAreaSection Model => new()
        {
            categoryOfPortSection = this._categoryOfPortSection,
            categoryOfHarbourFacility = this.categoryOfHarbourFacility.ToList(),
            iSPSLevel = this._iSPSLevel,
            facilitiesLayoutDescription = this._facilitiesLayoutDescription?.Model,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public HarbourAreaSectionViewModel() : base() {
            categoryOfHarbourFacility.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfHarbourFacility));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Harbour Area Section";
    }

    [CategoryOrder("HarbourBasin", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class HarbourBasinViewModel : FeatureViewModel<HarbourBasin> {
        private depthsDescriptionViewModel? _depthsDescription;
        [Category("HarbourBasin")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public depthsDescriptionViewModel? depthsDescription {
            get {
                return _depthsDescription;
            }

            set {
                SetValue(ref _depthsDescription, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("HarbourBasin")]
        public String locationByText {
            get {
                return _locationByText;
            }

            set {
                SetValue(ref _locationByText, value);
            }
        }

        private markedByViewModel? _markedBy;
        [Category("HarbourBasin")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public markedByViewModel? markedBy {
            get {
                return _markedBy;
            }

            set {
                SetValue(ref _markedBy, value);
            }
        }

        private iSPSLevel? _iSPSLevel = default;
        [DomainModel.EnumerationAttribute(nameof(iSPSLevelList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("HarbourBasin")]
        public iSPSLevel? iSPSLevel {
            get {
                return _iSPSLevel;
            }

            set {
                SetValue(ref _iSPSLevel, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN {
            get {
                return _locationMRN;
            }

            set {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber {
            get {
                return _globalLocationNumber;
            }

            set {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FeatureType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => HarbourBasin.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => HarbourBasin.featureBindingDefinitions;

        [Browsable(false)]
        public iSPSLevel[] iSPSLevelList => [(iSPSLevel)1, (iSPSLevel)2, (iSPSLevel)3];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.FeatureTypes.HarbourBasin instance) {
            depthsDescription = new();
            if (instance.depthsDescription != null) {
                depthsDescription = new();
                depthsDescription.Load(instance.depthsDescription);
            }

            locationByText = instance.locationByText;
            markedBy = new();
            if (instance.markedBy != null) {
                markedBy = new();
                markedBy.Load(instance.markedBy);
            }

            iSPSLevel = instance.iSPSLevel;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.HarbourBasin
            {
                depthsDescription = this.depthsDescription?.Model,
                locationByText = this.locationByText,
                markedBy = this.markedBy?.Model,
                iSPSLevel = this.iSPSLevel,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.HarbourBasin Model => new()
        {
            depthsDescription = this._depthsDescription?.Model,
            locationByText = this._locationByText,
            markedBy = this._markedBy?.Model,
            iSPSLevel = this._iSPSLevel,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public HarbourBasinViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Harbour Basin";
    }

    [CategoryOrder("HarbourFacility", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class HarbourFacilityViewModel : FeatureViewModel<HarbourFacility> {
        [DomainModel.EnumerationAttribute(nameof(categoryOfHarbourFacilityList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("HarbourFacility")]
        public ObservableCollection<categoryOfHarbourFacility> categoryOfHarbourFacility { get; set; } = new();

        private Decimal? _verticalClearanceValue = default;
        [Category("HarbourPhysicalInfrastructure")]
        public Decimal? verticalClearanceValue {
            get {
                return _verticalClearanceValue;
            }

            set {
                SetValue(ref _verticalClearanceValue, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN {
            get {
                return _locationMRN;
            }

            set {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber {
            get {
                return _globalLocationNumber;
            }

            set {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FeatureType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => HarbourFacility.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => HarbourFacility.featureBindingDefinitions;

        [Browsable(false)]
        public categoryOfHarbourFacility[] categoryOfHarbourFacilityList => [(categoryOfHarbourFacility)12, (categoryOfHarbourFacility)13];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.FeatureTypes.HarbourFacility instance) {
            categoryOfHarbourFacility.Clear();
            if (instance.categoryOfHarbourFacility is not null)
                foreach (var e in instance.categoryOfHarbourFacility)
                    categoryOfHarbourFacility.Add(e);
            verticalClearanceValue = instance.verticalClearanceValue;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.HarbourFacility
            {
                categoryOfHarbourFacility = this.categoryOfHarbourFacility.ToList(),
                verticalClearanceValue = this.verticalClearanceValue,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.HarbourFacility Model => new()
        {
            categoryOfHarbourFacility = this.categoryOfHarbourFacility.ToList(),
            verticalClearanceValue = this._verticalClearanceValue,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public HarbourFacilityViewModel() : base() {
            categoryOfHarbourFacility.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfHarbourFacility));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Harbour Facility";
    }

    [CategoryOrder("MooringWarpingFacility", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class MooringWarpingFacilityViewModel : FeatureViewModel<MooringWarpingFacility> {
        private categoryOfMooringWarpingFacility _categoryOfMooringWarpingFacility;
        [DomainModel.EnumerationAttribute(nameof(categoryOfMooringWarpingFacilityList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("MooringWarpingFacility")]
        public categoryOfMooringWarpingFacility categoryOfMooringWarpingFacility {
            get {
                return _categoryOfMooringWarpingFacility;
            }

            set {
                SetValue(ref _categoryOfMooringWarpingFacility, value);
            }
        }

        private String _iDCode = string.Empty;
        [Category("MooringWarpingFacility")]
        public String iDCode {
            get {
                return _iDCode;
            }

            set {
                SetValue(ref _iDCode, value);
            }
        }

        private String _bollardDescription = string.Empty;
        [Category("MooringWarpingFacility")]
        public String bollardDescription {
            get {
                return _bollardDescription;
            }

            set {
                SetValue(ref _bollardDescription, value);
            }
        }

        private Decimal? _bollardPull = default;
        [Category("MooringWarpingFacility")]
        public Decimal? bollardPull {
            get {
                return _bollardPull;
            }

            set {
                SetValue(ref _bollardPull, value);
            }
        }

        private Boolean? _heavingLinesFromShore = default;
        [Category("MooringWarpingFacility")]
        public Boolean? heavingLinesFromShore {
            get {
                return _heavingLinesFromShore;
            }

            set {
                SetValue(ref _heavingLinesFromShore, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN {
            get {
                return _locationMRN;
            }

            set {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber {
            get {
                return _globalLocationNumber;
            }

            set {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FeatureType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => MooringWarpingFacility.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => MooringWarpingFacility.featureBindingDefinitions;

        [Browsable(false)]
        public categoryOfMooringWarpingFacility[] categoryOfMooringWarpingFacilityList => [(categoryOfMooringWarpingFacility)1, (categoryOfMooringWarpingFacility)2, (categoryOfMooringWarpingFacility)3, (categoryOfMooringWarpingFacility)4, (categoryOfMooringWarpingFacility)5, (categoryOfMooringWarpingFacility)6, (categoryOfMooringWarpingFacility)7];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.FeatureTypes.MooringWarpingFacility instance) {
            categoryOfMooringWarpingFacility = instance.categoryOfMooringWarpingFacility;
            iDCode = instance.iDCode;
            bollardDescription = instance.bollardDescription;
            bollardPull = instance.bollardPull;
            heavingLinesFromShore = instance.heavingLinesFromShore;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.MooringWarpingFacility
            {
                categoryOfMooringWarpingFacility = this.categoryOfMooringWarpingFacility,
                iDCode = this.iDCode,
                bollardDescription = this.bollardDescription,
                bollardPull = this.bollardPull,
                heavingLinesFromShore = this.heavingLinesFromShore,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.MooringWarpingFacility Model => new()
        {
            categoryOfMooringWarpingFacility = this._categoryOfMooringWarpingFacility,
            iDCode = this._iDCode,
            bollardDescription = this._bollardDescription,
            bollardPull = this._bollardPull,
            heavingLinesFromShore = this._heavingLinesFromShore,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public MooringWarpingFacilityViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Mooring/Warping Facility";
    }

    [CategoryOrder("OuterLimit", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class OuterLimitViewModel : FeatureViewModel<OuterLimit> {
        private limitsDescriptionViewModel? _limitsDescription;
        [Category("OuterLimit")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public limitsDescriptionViewModel? limitsDescription {
            get {
                return _limitsDescription;
            }

            set {
                SetValue(ref _limitsDescription, value);
            }
        }

        [Category("OuterLimit")]
        public ObservableCollection<markedBy> markedBy { get; set; } = new();

        [Category("OuterLimit")]
        public ObservableCollection<landmarkDescription> landmarkDescription { get; set; } = new();

        [Category("OuterLimit")]
        public ObservableCollection<offshoreMarkDescription> offshoreMarkDescription { get; set; } = new();

        [Category("OuterLimit")]
        public ObservableCollection<majorLightDescription> majorLightDescription { get; set; } = new();

        [Category("OuterLimit")]
        public ObservableCollection<usefulMarkDescription> usefulMarkDescription { get; set; } = new();

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN {
            get {
                return _locationMRN;
            }

            set {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber {
            get {
                return _globalLocationNumber;
            }

            set {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FeatureType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => OuterLimit.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => OuterLimit.featureBindingDefinitions;

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.FeatureTypes.OuterLimit instance) {
            limitsDescription = new();
            if (instance.limitsDescription != null) {
                limitsDescription = new();
                limitsDescription.Load(instance.limitsDescription);
            }

            markedBy.Clear();
            if (instance.markedBy is not null)
                foreach (var e in instance.markedBy)
                    markedBy.Add(e);
            landmarkDescription.Clear();
            if (instance.landmarkDescription is not null)
                foreach (var e in instance.landmarkDescription)
                    landmarkDescription.Add(e);
            offshoreMarkDescription.Clear();
            if (instance.offshoreMarkDescription is not null)
                foreach (var e in instance.offshoreMarkDescription)
                    offshoreMarkDescription.Add(e);
            majorLightDescription.Clear();
            if (instance.majorLightDescription is not null)
                foreach (var e in instance.majorLightDescription)
                    majorLightDescription.Add(e);
            usefulMarkDescription.Clear();
            if (instance.usefulMarkDescription is not null)
                foreach (var e in instance.usefulMarkDescription)
                    usefulMarkDescription.Add(e);
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.OuterLimit
            {
                limitsDescription = this.limitsDescription?.Model,
                markedBy = this.markedBy.ToList(),
                landmarkDescription = this.landmarkDescription.ToList(),
                offshoreMarkDescription = this.offshoreMarkDescription.ToList(),
                majorLightDescription = this.majorLightDescription.ToList(),
                usefulMarkDescription = this.usefulMarkDescription.ToList(),
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.OuterLimit Model => new()
        {
            limitsDescription = this._limitsDescription?.Model,
            markedBy = this.markedBy.ToList(),
            landmarkDescription = this.landmarkDescription.ToList(),
            offshoreMarkDescription = this.offshoreMarkDescription.ToList(),
            majorLightDescription = this.majorLightDescription.ToList(),
            usefulMarkDescription = this.usefulMarkDescription.ToList(),
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public OuterLimitViewModel() : base() {
            markedBy.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(markedBy));
            };
            landmarkDescription.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(landmarkDescription));
            };
            offshoreMarkDescription.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(offshoreMarkDescription));
            };
            majorLightDescription.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(majorLightDescription));
            };
            usefulMarkDescription.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(usefulMarkDescription));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Outer Limit";
    }

    [CategoryOrder("PilotBoardingPlace", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class PilotBoardingPlaceViewModel : FeatureViewModel<PilotBoardingPlace> {
        private depthsDescriptionViewModel? _depthsDescription;
        [Category("PilotBoardingPlace")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public depthsDescriptionViewModel? depthsDescription {
            get {
                return _depthsDescription;
            }

            set {
                SetValue(ref _depthsDescription, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("PilotBoardingPlace")]
        public String locationByText {
            get {
                return _locationByText;
            }

            set {
                SetValue(ref _locationByText, value);
            }
        }

        private markedByViewModel? _markedBy;
        [Category("PilotBoardingPlace")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public markedByViewModel? markedBy {
            get {
                return _markedBy;
            }

            set {
                SetValue(ref _markedBy, value);
            }
        }

        private iSPSLevel? _iSPSLevel = default;
        [DomainModel.EnumerationAttribute(nameof(iSPSLevelList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("PilotBoardingPlace")]
        public iSPSLevel? iSPSLevel {
            get {
                return _iSPSLevel;
            }

            set {
                SetValue(ref _iSPSLevel, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN {
            get {
                return _locationMRN;
            }

            set {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber {
            get {
                return _globalLocationNumber;
            }

            set {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FeatureType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => PilotBoardingPlace.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => PilotBoardingPlace.featureBindingDefinitions;

        [Browsable(false)]
        public iSPSLevel[] iSPSLevelList => [(iSPSLevel)1, (iSPSLevel)2, (iSPSLevel)3];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.FeatureTypes.PilotBoardingPlace instance) {
            depthsDescription = new();
            if (instance.depthsDescription != null) {
                depthsDescription = new();
                depthsDescription.Load(instance.depthsDescription);
            }

            locationByText = instance.locationByText;
            markedBy = new();
            if (instance.markedBy != null) {
                markedBy = new();
                markedBy.Load(instance.markedBy);
            }

            iSPSLevel = instance.iSPSLevel;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.PilotBoardingPlace
            {
                depthsDescription = this.depthsDescription?.Model,
                locationByText = this.locationByText,
                markedBy = this.markedBy?.Model,
                iSPSLevel = this.iSPSLevel,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.PilotBoardingPlace Model => new()
        {
            depthsDescription = this._depthsDescription?.Model,
            locationByText = this._locationByText,
            markedBy = this._markedBy?.Model,
            iSPSLevel = this._iSPSLevel,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public PilotBoardingPlaceViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Pilot Boarding Place";
    }

    [CategoryOrder("SeaplaneLandingArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class SeaplaneLandingAreaViewModel : FeatureViewModel<SeaplaneLandingArea> {
        private depthsDescriptionViewModel? _depthsDescription;
        [Category("SeaplaneLandingArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public depthsDescriptionViewModel? depthsDescription {
            get {
                return _depthsDescription;
            }

            set {
                SetValue(ref _depthsDescription, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("SeaplaneLandingArea")]
        public String locationByText {
            get {
                return _locationByText;
            }

            set {
                SetValue(ref _locationByText, value);
            }
        }

        private markedByViewModel? _markedBy;
        [Category("SeaplaneLandingArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public markedByViewModel? markedBy {
            get {
                return _markedBy;
            }

            set {
                SetValue(ref _markedBy, value);
            }
        }

        private iSPSLevel? _iSPSLevel = default;
        [DomainModel.EnumerationAttribute(nameof(iSPSLevelList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("SeaplaneLandingArea")]
        public iSPSLevel? iSPSLevel {
            get {
                return _iSPSLevel;
            }

            set {
                SetValue(ref _iSPSLevel, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN {
            get {
                return _locationMRN;
            }

            set {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber {
            get {
                return _globalLocationNumber;
            }

            set {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FeatureType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => SeaplaneLandingArea.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => SeaplaneLandingArea.featureBindingDefinitions;

        [Browsable(false)]
        public iSPSLevel[] iSPSLevelList => [(iSPSLevel)1, (iSPSLevel)2, (iSPSLevel)3];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.FeatureTypes.SeaplaneLandingArea instance) {
            depthsDescription = new();
            if (instance.depthsDescription != null) {
                depthsDescription = new();
                depthsDescription.Load(instance.depthsDescription);
            }

            locationByText = instance.locationByText;
            markedBy = new();
            if (instance.markedBy != null) {
                markedBy = new();
                markedBy.Load(instance.markedBy);
            }

            iSPSLevel = instance.iSPSLevel;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.SeaplaneLandingArea
            {
                depthsDescription = this.depthsDescription?.Model,
                locationByText = this.locationByText,
                markedBy = this.markedBy?.Model,
                iSPSLevel = this.iSPSLevel,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.SeaplaneLandingArea Model => new()
        {
            depthsDescription = this._depthsDescription?.Model,
            locationByText = this._locationByText,
            markedBy = this._markedBy?.Model,
            iSPSLevel = this._iSPSLevel,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public SeaplaneLandingAreaViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Seaplane Landing Area";
    }

    [CategoryOrder("Terminal", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class TerminalViewModel : FeatureViewModel<Terminal> {
        private String _portFacilityNumber = string.Empty;
        [Category("Terminal")]
        public String portFacilityNumber {
            get {
                return _portFacilityNumber;
            }

            set {
                SetValue(ref _portFacilityNumber, value);
            }
        }

        private categoryOfHarbourFacility? _categoryOfHarbourFacility = default;
        [DomainModel.EnumerationAttribute(nameof(categoryOfHarbourFacilityList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("Terminal")]
        public categoryOfHarbourFacility? categoryOfHarbourFacility {
            get {
                return _categoryOfHarbourFacility;
            }

            set {
                SetValue(ref _categoryOfHarbourFacility, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(categoryOfCargoList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("Terminal")]
        public ObservableCollection<categoryOfCargo> categoryOfCargo { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(productList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("Terminal")]
        public ObservableCollection<product> product { get; set; } = new();

        private String _terminalIdentifier = string.Empty;
        [Category("Terminal")]
        public String terminalIdentifier {
            get {
                return _terminalIdentifier;
            }

            set {
                SetValue(ref _terminalIdentifier, value);
            }
        }

        private String _sMDGTerminalCode = string.Empty;
        [Category("Terminal")]
        public String sMDGTerminalCode {
            get {
                return _sMDGTerminalCode;
            }

            set {
                SetValue(ref _sMDGTerminalCode, value);
            }
        }

        private String _uNLocationCode = string.Empty;
        [Category("Terminal")]
        public String uNLocationCode {
            get {
                return _uNLocationCode;
            }

            set {
                SetValue(ref _uNLocationCode, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN {
            get {
                return _locationMRN;
            }

            set {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber {
            get {
                return _globalLocationNumber;
            }

            set {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FeatureType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => Terminal.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => Terminal.featureBindingDefinitions;

        [Browsable(false)]
        public categoryOfHarbourFacility[] categoryOfHarbourFacilityList => [(categoryOfHarbourFacility)1, (categoryOfHarbourFacility)3, (categoryOfHarbourFacility)5, (categoryOfHarbourFacility)7, (categoryOfHarbourFacility)8, (categoryOfHarbourFacility)10, (categoryOfHarbourFacility)11];

        [Browsable(false)]
        public categoryOfCargo[] categoryOfCargoList => [(categoryOfCargo)2, (categoryOfCargo)5, (categoryOfCargo)6, (categoryOfCargo)7, (categoryOfCargo)8, (categoryOfCargo)10, (categoryOfCargo)11, (categoryOfCargo)12, (categoryOfCargo)13, (categoryOfCargo)14, (categoryOfCargo)15];

        [Browsable(false)]
        public product[] productList => [(product)1, (product)2, (product)4, (product)5, (product)6, (product)7, (product)9, (product)10, (product)11, (product)12, (product)13, (product)14, (product)15, (product)16, (product)17, (product)18, (product)19, (product)20, (product)21, (product)22];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.FeatureTypes.Terminal instance) {
            portFacilityNumber = instance.portFacilityNumber;
            categoryOfHarbourFacility = instance.categoryOfHarbourFacility;
            categoryOfCargo.Clear();
            if (instance.categoryOfCargo is not null)
                foreach (var e in instance.categoryOfCargo)
                    categoryOfCargo.Add(e);
            product.Clear();
            if (instance.product is not null)
                foreach (var e in instance.product)
                    product.Add(e);
            terminalIdentifier = instance.terminalIdentifier;
            sMDGTerminalCode = instance.sMDGTerminalCode;
            uNLocationCode = instance.uNLocationCode;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.Terminal
            {
                portFacilityNumber = this.portFacilityNumber,
                categoryOfHarbourFacility = this.categoryOfHarbourFacility,
                categoryOfCargo = this.categoryOfCargo.ToList(),
                product = this.product.ToList(),
                terminalIdentifier = this.terminalIdentifier,
                sMDGTerminalCode = this.sMDGTerminalCode,
                uNLocationCode = this.uNLocationCode,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.Terminal Model => new()
        {
            portFacilityNumber = this._portFacilityNumber,
            categoryOfHarbourFacility = this._categoryOfHarbourFacility,
            categoryOfCargo = this.categoryOfCargo.ToList(),
            product = this.product.ToList(),
            terminalIdentifier = this._terminalIdentifier,
            sMDGTerminalCode = this._sMDGTerminalCode,
            uNLocationCode = this._uNLocationCode,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public TerminalViewModel() : base() {
            categoryOfCargo.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfCargo));
            };
            product.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(product));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Terminal";
    }

    [CategoryOrder("TurningBasin", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class TurningBasinViewModel : FeatureViewModel<TurningBasin> {
        private depthsDescriptionViewModel? _depthsDescription;
        [Category("TurningBasin")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public depthsDescriptionViewModel? depthsDescription {
            get {
                return _depthsDescription;
            }

            set {
                SetValue(ref _depthsDescription, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("TurningBasin")]
        public String locationByText {
            get {
                return _locationByText;
            }

            set {
                SetValue(ref _locationByText, value);
            }
        }

        private markedByViewModel? _markedBy;
        [Category("TurningBasin")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public markedByViewModel? markedBy {
            get {
                return _markedBy;
            }

            set {
                SetValue(ref _markedBy, value);
            }
        }

        private iSPSLevel? _iSPSLevel = default;
        [DomainModel.EnumerationAttribute(nameof(iSPSLevelList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("TurningBasin")]
        public iSPSLevel? iSPSLevel {
            get {
                return _iSPSLevel;
            }

            set {
                SetValue(ref _iSPSLevel, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN {
            get {
                return _locationMRN;
            }

            set {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber {
            get {
                return _globalLocationNumber;
            }

            set {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FeatureType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => TurningBasin.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => TurningBasin.featureBindingDefinitions;

        [Browsable(false)]
        public iSPSLevel[] iSPSLevelList => [(iSPSLevel)1, (iSPSLevel)2, (iSPSLevel)3];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.FeatureTypes.TurningBasin instance) {
            depthsDescription = new();
            if (instance.depthsDescription != null) {
                depthsDescription = new();
                depthsDescription.Load(instance.depthsDescription);
            }

            locationByText = instance.locationByText;
            markedBy = new();
            if (instance.markedBy != null) {
                markedBy = new();
                markedBy.Load(instance.markedBy);
            }

            iSPSLevel = instance.iSPSLevel;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.TurningBasin
            {
                depthsDescription = this.depthsDescription?.Model,
                locationByText = this.locationByText,
                markedBy = this.markedBy?.Model,
                iSPSLevel = this.iSPSLevel,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.TurningBasin Model => new()
        {
            depthsDescription = this._depthsDescription?.Model,
            locationByText = this._locationByText,
            markedBy = this._markedBy?.Model,
            iSPSLevel = this._iSPSLevel,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public TurningBasinViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Turning Basin";
    }

    [CategoryOrder("WaterwayArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class WaterwayAreaViewModel : FeatureViewModel<WaterwayArea> {
        private categoryOfPortSection _categoryOfPortSection;
        [DomainModel.EnumerationAttribute(nameof(categoryOfPortSectionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("WaterwayArea")]
        public categoryOfPortSection categoryOfPortSection {
            get {
                return _categoryOfPortSection;
            }

            set {
                SetValue(ref _categoryOfPortSection, value);
            }
        }

        private depthsDescriptionViewModel? _depthsDescription;
        [Category("WaterwayArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public depthsDescriptionViewModel? depthsDescription {
            get {
                return _depthsDescription;
            }

            set {
                SetValue(ref _depthsDescription, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("WaterwayArea")]
        public String locationByText {
            get {
                return _locationByText;
            }

            set {
                SetValue(ref _locationByText, value);
            }
        }

        private markedByViewModel? _markedBy;
        [Category("WaterwayArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public markedByViewModel? markedBy {
            get {
                return _markedBy;
            }

            set {
                SetValue(ref _markedBy, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN {
            get {
                return _locationMRN;
            }

            set {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber {
            get {
                return _globalLocationNumber;
            }

            set {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange {
            get {
                return _fixedDateRange;
            }

            set {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source {
            get {
                return _source;
            }

            set {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [DomainModel.EnumerationAttribute(nameof(sourceTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("FeatureType")]
        public sourceType? sourceType {
            get {
                return _sourceType;
            }

            set {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate {
            get {
                return _reportedDate;
            }

            set {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => WaterwayArea.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => WaterwayArea.featureBindingDefinitions;

        [Browsable(false)]
        public categoryOfPortSection[] categoryOfPortSectionList => [(categoryOfPortSection)1, (categoryOfPortSection)3, (categoryOfPortSection)8, (categoryOfPortSection)9, (categoryOfPortSection)11, (categoryOfPortSection)12];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public override void Load(DomainModel.S131.FeatureTypes.WaterwayArea instance) {
            categoryOfPortSection = instance.categoryOfPortSection;
            depthsDescription = new();
            if (instance.depthsDescription != null) {
                depthsDescription = new();
                depthsDescription.Load(instance.depthsDescription);
            }

            locationByText = instance.locationByText;
            markedBy = new();
            if (instance.markedBy != null) {
                markedBy = new();
                markedBy.Load(instance.markedBy);
            }

            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null) {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.WaterwayArea
            {
                categoryOfPortSection = this.categoryOfPortSection,
                depthsDescription = this.depthsDescription?.Model,
                locationByText = this.locationByText,
                markedBy = this.markedBy?.Model,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.WaterwayArea Model => new()
        {
            categoryOfPortSection = this._categoryOfPortSection,
            depthsDescription = this._depthsDescription?.Model,
            locationByText = this._locationByText,
            markedBy = this._markedBy?.Model,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public WaterwayAreaViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Waterway Area";
    }

    [CategoryOrder("DataCoverage", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DataCoverageViewModel : FeatureViewModel<DataCoverage> {
        private Int32 _maximumDisplayScale;
        [Category("DataCoverage")]
        public Int32 maximumDisplayScale {
            get {
                return _maximumDisplayScale;
            }

            set {
                SetValue(ref _maximumDisplayScale, value);
            }
        }

        private Int32 _minimumDisplayScale;
        [Category("DataCoverage")]
        public Int32 minimumDisplayScale {
            get {
                return _minimumDisplayScale;
            }

            set {
                SetValue(ref _minimumDisplayScale, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => DataCoverage.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => DataCoverage.featureBindingDefinitions;

        public override void Load(DomainModel.S131.FeatureTypes.DataCoverage instance) {
            maximumDisplayScale = instance.maximumDisplayScale;
            minimumDisplayScale = instance.minimumDisplayScale;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.DataCoverage
            {
                maximumDisplayScale = this.maximumDisplayScale,
                minimumDisplayScale = this.minimumDisplayScale,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.DataCoverage Model => new()
        {
            maximumDisplayScale = this._maximumDisplayScale,
            minimumDisplayScale = this._minimumDisplayScale,
        };

        public DataCoverageViewModel() : base() {
        }

        public override string? ToString() => $"Data Coverage";
    }

    [CategoryOrder("QualityOfNonBathymetricData", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class QualityOfNonBathymetricDataViewModel : FeatureViewModel<QualityOfNonBathymetricData> {
        private categoryOfTemporalVariation? _categoryOfTemporalVariation = default;
        [DomainModel.EnumerationAttribute(nameof(categoryOfTemporalVariationList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("QualityOfNonBathymetricData")]
        public categoryOfTemporalVariation? categoryOfTemporalVariation {
            get {
                return _categoryOfTemporalVariation;
            }

            set {
                SetValue(ref _categoryOfTemporalVariation, value);
            }
        }

        private Decimal? _horizontalDistanceUncertainty = default;
        [Category("QualityOfNonBathymetricData")]
        public Decimal? horizontalDistanceUncertainty {
            get {
                return _horizontalDistanceUncertainty;
            }

            set {
                SetValue(ref _horizontalDistanceUncertainty, value);
            }
        }

        private horizontalPositionUncertaintyViewModel _horizontalPositionUncertainty;
        [Category("QualityOfNonBathymetricData")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public horizontalPositionUncertaintyViewModel horizontalPositionUncertainty {
            get {
                return _horizontalPositionUncertainty;
            }

            set {
                SetValue(ref _horizontalPositionUncertainty, value);
            }
        }

        private Decimal? _orientationUncertainty = default;
        [Category("QualityOfNonBathymetricData")]
        public Decimal? orientationUncertainty {
            get {
                return _orientationUncertainty;
            }

            set {
                SetValue(ref _orientationUncertainty, value);
            }
        }

        private surveyDateRangeViewModel? _surveyDateRange;
        [Category("QualityOfNonBathymetricData")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public surveyDateRangeViewModel? surveyDateRange {
            get {
                return _surveyDateRange;
            }

            set {
                SetValue(ref _surveyDateRange, value);
            }
        }

        private verticalUncertaintyViewModel? _verticalUncertainty;
        [Category("QualityOfNonBathymetricData")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public verticalUncertaintyViewModel? verticalUncertainty {
            get {
                return _verticalUncertainty;
            }

            set {
                SetValue(ref _verticalUncertainty, value);
            }
        }

        [Category("QualityOfNonBathymetricData")]
        public ObservableCollection<information> information { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => QualityOfNonBathymetricData.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => QualityOfNonBathymetricData.featureBindingDefinitions;

        [Browsable(false)]
        public categoryOfTemporalVariation[] categoryOfTemporalVariationList => [(categoryOfTemporalVariation)1, (categoryOfTemporalVariation)2, (categoryOfTemporalVariation)3, (categoryOfTemporalVariation)4, (categoryOfTemporalVariation)5, (categoryOfTemporalVariation)6];

        public override void Load(DomainModel.S131.FeatureTypes.QualityOfNonBathymetricData instance) {
            categoryOfTemporalVariation = instance.categoryOfTemporalVariation;
            horizontalDistanceUncertainty = instance.horizontalDistanceUncertainty;
            horizontalPositionUncertainty = new();
            if (instance.horizontalPositionUncertainty != null) {
                horizontalPositionUncertainty = new();
                horizontalPositionUncertainty.Load(instance.horizontalPositionUncertainty);
            }

            orientationUncertainty = instance.orientationUncertainty;
            surveyDateRange = new();
            if (instance.surveyDateRange != null) {
                surveyDateRange = new();
                surveyDateRange.Load(instance.surveyDateRange);
            }

            verticalUncertainty = new();
            if (instance.verticalUncertainty != null) {
                verticalUncertainty = new();
                verticalUncertainty.Load(instance.verticalUncertainty);
            }

            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.QualityOfNonBathymetricData
            {
                categoryOfTemporalVariation = this.categoryOfTemporalVariation,
                horizontalDistanceUncertainty = this.horizontalDistanceUncertainty,
                horizontalPositionUncertainty = this.horizontalPositionUncertainty?.Model,
                orientationUncertainty = this.orientationUncertainty,
                surveyDateRange = this.surveyDateRange?.Model,
                verticalUncertainty = this.verticalUncertainty?.Model,
                information = this.information.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.QualityOfNonBathymetricData Model => new()
        {
            categoryOfTemporalVariation = this._categoryOfTemporalVariation,
            horizontalDistanceUncertainty = this._horizontalDistanceUncertainty,
            horizontalPositionUncertainty = this._horizontalPositionUncertainty?.Model,
            orientationUncertainty = this._orientationUncertainty,
            surveyDateRange = this._surveyDateRange?.Model,
            verticalUncertainty = this._verticalUncertainty?.Model,
            information = this.information.ToList(),
        };

        public QualityOfNonBathymetricDataViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Quality of Non-Bathymetric Data";
    }

    [CategoryOrder("SoundingDatum", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class SoundingDatumViewModel : FeatureViewModel<SoundingDatum> {
        private verticalDatum _verticalDatum;
        [DomainModel.EnumerationAttribute(nameof(verticalDatumList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("SoundingDatum")]
        public verticalDatum verticalDatum {
            get {
                return _verticalDatum;
            }

            set {
                SetValue(ref _verticalDatum, value);
            }
        }

        [Category("SoundingDatum")]
        public ObservableCollection<information> information { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => SoundingDatum.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => SoundingDatum.featureBindingDefinitions;

        [Browsable(false)]
        public verticalDatum[] verticalDatumList => [(verticalDatum)1, (verticalDatum)2, (verticalDatum)3, (verticalDatum)4, (verticalDatum)5, (verticalDatum)6, (verticalDatum)7, (verticalDatum)8, (verticalDatum)9, (verticalDatum)10, (verticalDatum)11, (verticalDatum)12, (verticalDatum)13, (verticalDatum)14, (verticalDatum)15, (verticalDatum)19, (verticalDatum)22, (verticalDatum)23, (verticalDatum)24, (verticalDatum)25, (verticalDatum)26, (verticalDatum)27, (verticalDatum)44];

        public override void Load(DomainModel.S131.FeatureTypes.SoundingDatum instance) {
            verticalDatum = instance.verticalDatum;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.SoundingDatum
            {
                verticalDatum = this.verticalDatum,
                information = this.information.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.SoundingDatum Model => new()
        {
            verticalDatum = this._verticalDatum,
            information = this.information.ToList(),
        };

        public SoundingDatumViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Sounding Datum";
    }

    [CategoryOrder("VerticalDatumOfData", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class VerticalDatumOfDataViewModel : FeatureViewModel<VerticalDatumOfData> {
        private verticalDatum _verticalDatum;
        [DomainModel.EnumerationAttribute(nameof(verticalDatumList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("VerticalDatumOfData")]
        public verticalDatum verticalDatum {
            get {
                return _verticalDatum;
            }

            set {
                SetValue(ref _verticalDatum, value);
            }
        }

        [Category("VerticalDatumOfData")]
        public ObservableCollection<information> information { get; set; } = new();
        public override informationBindingDefinition[] informationBindingDefinitions => VerticalDatumOfData.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => VerticalDatumOfData.featureBindingDefinitions;

        [Browsable(false)]
        public verticalDatum[] verticalDatumList => [(verticalDatum)3, (verticalDatum)16, (verticalDatum)17, (verticalDatum)18, (verticalDatum)19, (verticalDatum)20, (verticalDatum)21, (verticalDatum)24, (verticalDatum)25, (verticalDatum)26, (verticalDatum)28, (verticalDatum)29, (verticalDatum)30, (verticalDatum)44];

        public override void Load(DomainModel.S131.FeatureTypes.VerticalDatumOfData instance) {
            verticalDatum = instance.verticalDatum;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.VerticalDatumOfData
            {
                verticalDatum = this.verticalDatum,
                information = this.information.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.VerticalDatumOfData Model => new()
        {
            verticalDatum = this._verticalDatum,
            information = this.information.ToList(),
        };

        public VerticalDatumOfDataViewModel() : base() {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
        }

        public override string? ToString() => $"Vertical Datum of Data";
    }

    [CategoryOrder("TextPlacement", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class TextPlacementViewModel : FeatureViewModel<TextPlacement> {
        private Decimal _orientationValue;
        [Category("TextPlacement")]
        public Decimal orientationValue {
            get {
                return _orientationValue;
            }

            set {
                SetValue(ref _orientationValue, value);
            }
        }

        private String _text = string.Empty;
        [Category("TextPlacement")]
        public String text {
            get {
                return _text;
            }

            set {
                SetValue(ref _text, value);
            }
        }

        private Int32 _textOffsetMm;
        [Category("TextPlacement")]
        public Int32 textOffsetMm {
            get {
                return _textOffsetMm;
            }

            set {
                SetValue(ref _textOffsetMm, value);
            }
        }

        private textType? _textType = default;
        [DomainModel.EnumerationAttribute(nameof(textTypeList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("TextPlacement")]
        public textType? textType {
            get {
                return _textType;
            }

            set {
                SetValue(ref _textType, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("TextPlacement")]
        public Int32? scaleMinimum {
            get {
                return _scaleMinimum;
            }

            set {
                SetValue(ref _scaleMinimum, value);
            }
        }

        public override informationBindingDefinition[] informationBindingDefinitions => TextPlacement.informationBindingDefinitions;
        public override featureBindingDefinition[] featureBindingDefinitions => TextPlacement.featureBindingDefinitions;

        [Browsable(false)]
        public textType[] textTypeList => [(textType)1];

        public override void Load(DomainModel.S131.FeatureTypes.TextPlacement instance) {
            orientationValue = instance.orientationValue;
            text = instance.text;
            textOffsetMm = instance.textOffsetMm;
            textType = instance.textType;
            scaleMinimum = instance.scaleMinimum;
        }

        public override string Serialize() {
            var instance = new DomainModel.S131.FeatureTypes.TextPlacement
            {
                orientationValue = this.orientationValue,
                text = this.text,
                textOffsetMm = this.textOffsetMm,
                textType = this.textType,
                scaleMinimum = this.scaleMinimum,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.TextPlacement Model => new()
        {
            orientationValue = this._orientationValue,
            text = this._text,
            textOffsetMm = this._textOffsetMm,
            textType = this._textType,
            scaleMinimum = this._scaleMinimum,
        };

        public TextPlacementViewModel() : base() {
        }

        public override string? ToString() => $"Text Placement";
    }
}