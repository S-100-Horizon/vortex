using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Reflection;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S122;
using S100Framework.DomainModel.S122.ComplexAttributes;
using S100Framework.DomainModel.S122.InformationTypes;
using S100Framework.DomainModel.S122.FeatureTypes;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

#nullable enable
namespace S100Framework.WPF.ViewModel.S122 {
    internal static class Preamble {
        public static ImmutableDictionary<string, Func<ViewModelBase>> _creators => ImmutableDictionary.Create<string, Func<ViewModelBase>>().AddRange(new Dictionary<string, Func<ViewModelBase>> { { "InformationType", () =>
        {
            return new InformationTypeViewModel();
        } }, { "AbstractRxN", () =>
        {
            return new AbstractRxNViewModel();
        } }, { "NauticalInformation", () =>
        {
            return new NauticalInformationViewModel();
        } }, { "Regulations", () =>
        {
            return new RegulationsViewModel();
        } }, { "Restrictions", () =>
        {
            return new RestrictionsViewModel();
        } }, { "Recommendations", () =>
        {
            return new RecommendationsViewModel();
        } }, { "Authority", () =>
        {
            return new AuthorityViewModel();
        } }, { "ContactDetails", () =>
        {
            return new ContactDetailsViewModel();
        } }, { "NonStandardWorkingDay", () =>
        {
            return new NonStandardWorkingDayViewModel();
        } }, { "ServiceHours", () =>
        {
            return new ServiceHoursViewModel();
        } }, { "Applicability", () =>
        {
            return new ApplicabilityViewModel();
        } }, { "RestrictedArea", () =>
        {
            return new RestrictedAreaViewModel();
        } }, { "MarineProtectedArea", () =>
        {
            return new MarineProtectedAreaViewModel();
        } }, { "VesselTrafficServiceArea", () =>
        {
            return new VesselTrafficServiceAreaViewModel();
        } }, { "DataCoverage", () =>
        {
            return new DataCoverageViewModel();
        } }, { "TextPlacement", () =>
        {
            return new TextPlacementViewModel();
        } }, });
    }

    public class Handles : iHandles {
        public static IDictionary<Type, Func<InformationAssociationConnector[]>> AssociationConnectorInformations => new Dictionary<Type, Func<InformationAssociationConnector[]>>
        {
        };
        public static IDictionary<Type, Func<FeatureAssociationConnector[]>> AssociationConnectorFeatures => new Dictionary<Type, Func<FeatureAssociationConnector[]>>
        {
        };
    }

    [CategoryOrder("contactAddress", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class contactAddressViewModel : ViewModelBase {
        private String _deliveryPoint = string.Empty;
        [Category("contactAddress")]
        public String deliveryPoint {
            get {
                return _deliveryPoint;
            }

            set {
                SetValue(ref _deliveryPoint, value);
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

        public void Load(DomainModel.S122.ComplexAttributes.contactAddress instance) {
            deliveryPoint = instance.deliveryPoint;
            cityName = instance.cityName;
            administrativeDivision = instance.administrativeDivision;
            countryName = instance.countryName;
            postalCode = instance.postalCode;
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.ComplexAttributes.contactAddress
            {
                deliveryPoint = this.deliveryPoint,
                cityName = this.cityName,
                administrativeDivision = this.administrativeDivision,
                countryName = this.countryName,
                postalCode = this.postalCode,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.contactAddress Model => new()
        {
            deliveryPoint = this._deliveryPoint,
            cityName = this._cityName,
            administrativeDivision = this._administrativeDivision,
            countryName = this._countryName,
            postalCode = this._postalCode,
        };

        public contactAddressViewModel() : base() {
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

        public void Load(DomainModel.S122.ComplexAttributes.featureName instance) {
            displayName = instance.displayName;
            language = instance.language;
            name = instance.name;
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.ComplexAttributes.featureName
            {
                displayName = this.displayName,
                language = this.language,
                name = this.name,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.featureName Model => new()
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

        public void Load(DomainModel.S122.ComplexAttributes.fixedDateRange instance) {
            dateStart = instance.dateStart;
            dateEnd = instance.dateEnd;
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.ComplexAttributes.fixedDateRange
            {
                dateStart = this.dateStart,
                dateEnd = this.dateEnd,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.fixedDateRange Model => new()
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
        private Int32? _frequencyShoreStationReceives = default;
        [Category("frequencyPair")]
        public Int32? frequencyShoreStationReceives {
            get {
                return _frequencyShoreStationReceives;
            }

            set {
                SetValue(ref _frequencyShoreStationReceives, value);
            }
        }

        private Int32? _frequencyShoreStationTransmits = default;
        [Category("frequencyPair")]
        public Int32? frequencyShoreStationTransmits {
            get {
                return _frequencyShoreStationTransmits;
            }

            set {
                SetValue(ref _frequencyShoreStationTransmits, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.frequencyPair instance) {
            frequencyShoreStationReceives = instance.frequencyShoreStationReceives;
            frequencyShoreStationTransmits = instance.frequencyShoreStationTransmits;
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.ComplexAttributes.frequencyPair
            {
                frequencyShoreStationReceives = this.frequencyShoreStationReceives,
                frequencyShoreStationTransmits = this.frequencyShoreStationTransmits,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.frequencyPair Model => new()
        {
            frequencyShoreStationReceives = this._frequencyShoreStationReceives,
            frequencyShoreStationTransmits = this._frequencyShoreStationTransmits,
        };

        public frequencyPairViewModel() : base() {
        }

        public override string? ToString() => $"Frequency Pair";
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

        public void Load(DomainModel.S122.ComplexAttributes.information instance) {
            fileLocator = instance.fileLocator;
            fileReference = instance.fileReference;
            headline = instance.headline;
            language = instance.language;
            text = instance.text;
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.ComplexAttributes.information
            {
                fileLocator = this.fileLocator,
                fileReference = this.fileReference,
                headline = this.headline,
                language = this.language,
                text = this.text,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.information Model => new()
        {
            fileLocator = this._fileLocator,
            fileReference = this._fileReference,
            headline = this._headline,
            language = this._language,
            text = this._text,
        };

        public informationViewModel() : base() {
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

        [Browsable(false)]
        public onlineFunction[] onlineFunctionList => [];

        public void Load(DomainModel.S122.ComplexAttributes.onlineResource instance) {
            onlineResourceLinkageURL = instance.onlineResourceLinkageURL;
            protocol = instance.protocol;
            applicationProfile = instance.applicationProfile;
            nameOfResource = instance.nameOfResource;
            onlineResourceDescription = instance.onlineResourceDescription;
            protocolRequest = instance.protocolRequest;
            onlineFunction = instance.onlineFunction;
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.ComplexAttributes.onlineResource
            {
                onlineResourceLinkageURL = this.onlineResourceLinkageURL,
                protocol = this.protocol,
                applicationProfile = this.applicationProfile,
                nameOfResource = this.nameOfResource,
                onlineResourceDescription = this.onlineResourceDescription,
                protocolRequest = this.protocolRequest,
                onlineFunction = this.onlineFunction,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.onlineResource Model => new()
        {
            onlineResourceLinkageURL = this._onlineResourceLinkageURL,
            protocol = this._protocol,
            applicationProfile = this._applicationProfile,
            nameOfResource = this._nameOfResource,
            onlineResourceDescription = this._onlineResourceDescription,
            protocolRequest = this._protocolRequest,
            onlineFunction = this._onlineFunction,
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

        public void Load(DomainModel.S122.ComplexAttributes.orientation instance) {
            orientationUncertainty = instance.orientationUncertainty;
            orientationValue = instance.orientationValue;
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.ComplexAttributes.orientation
            {
                orientationUncertainty = this.orientationUncertainty,
                orientationValue = this.orientationValue,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.orientation Model => new()
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

        public void Load(DomainModel.S122.ComplexAttributes.periodicDateRange instance) {
            dateStart = instance.dateStart;
            dateEnd = instance.dateEnd;
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.ComplexAttributes.periodicDateRange
            {
                dateStart = this.dateStart,
                dateEnd = this.dateEnd,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.periodicDateRange Model => new()
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

        private String _headline = string.Empty;
        [Category("rxNCode")]
        public String headline {
            get {
                return _headline;
            }

            set {
                SetValue(ref _headline, value);
            }
        }

        [Browsable(false)]
        public categoryOfRxN[] categoryOfRxNList => CodeList.categoryOfRxNS.ToArray();

        [Browsable(false)]
        public actionOrActivity[] actionOrActivityList => CodeList.actionOrActivities.ToArray();

        public void Load(DomainModel.S122.ComplexAttributes.rxNCode instance) {
            categoryOfRxN = instance.categoryOfRxN;
            actionOrActivity = instance.actionOrActivity;
            headline = instance.headline;
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.ComplexAttributes.rxNCode
            {
                categoryOfRxN = this.categoryOfRxN,
                actionOrActivity = this.actionOrActivity,
                headline = this.headline,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.rxNCode Model => new()
        {
            categoryOfRxN = this._categoryOfRxN,
            actionOrActivity = this._actionOrActivity,
            headline = this._headline,
        };

        public rxNCodeViewModel() : base() {
        }

        public override string? ToString() => $"RxN Code";
    }

    [CategoryOrder("sectorLimitOne", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class sectorLimitOneViewModel : ViewModelBase {
        private Decimal _sectorBearing;
        [Category("sectorLimitOne")]
        public Decimal sectorBearing {
            get {
                return _sectorBearing;
            }

            set {
                SetValue(ref _sectorBearing, value);
            }
        }

        private Int32? _sectorLineLength = default;
        [Category("sectorLimitOne")]
        public Int32? sectorLineLength {
            get {
                return _sectorLineLength;
            }

            set {
                SetValue(ref _sectorLineLength, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.sectorLimitOne instance) {
            sectorBearing = instance.sectorBearing;
            sectorLineLength = instance.sectorLineLength;
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.ComplexAttributes.sectorLimitOne
            {
                sectorBearing = this.sectorBearing,
                sectorLineLength = this.sectorLineLength,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.sectorLimitOne Model => new()
        {
            sectorBearing = this._sectorBearing,
            sectorLineLength = this._sectorLineLength,
        };

        public sectorLimitOneViewModel() : base() {
        }

        public override string? ToString() => $"Sector Limit One";
    }

    [CategoryOrder("sectorLimitTwo", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class sectorLimitTwoViewModel : ViewModelBase {
        private Decimal _sectorBearing;
        [Category("sectorLimitTwo")]
        public Decimal sectorBearing {
            get {
                return _sectorBearing;
            }

            set {
                SetValue(ref _sectorBearing, value);
            }
        }

        private Int32? _sectorLineLength = default;
        [Category("sectorLimitTwo")]
        public Int32? sectorLineLength {
            get {
                return _sectorLineLength;
            }

            set {
                SetValue(ref _sectorLineLength, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.sectorLimitTwo instance) {
            sectorBearing = instance.sectorBearing;
            sectorLineLength = instance.sectorLineLength;
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.ComplexAttributes.sectorLimitTwo
            {
                sectorBearing = this.sectorBearing,
                sectorLineLength = this.sectorLineLength,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.sectorLimitTwo Model => new()
        {
            sectorBearing = this._sectorBearing,
            sectorLineLength = this._sectorLineLength,
        };

        public sectorLimitTwoViewModel() : base() {
        }

        public override string? ToString() => $"Sector Limit Two";
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

        public void Load(DomainModel.S122.ComplexAttributes.textContent instance) {
            categoryOfText = instance.categoryOfText;
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.ComplexAttributes.textContent
            {
                categoryOfText = this.categoryOfText,
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.textContent Model => new()
        {
            categoryOfText = this._categoryOfText,
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public textContentViewModel() : base() {
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
        public ObservableCollection<TimeOnly> timeOfDayEnd { get; set; } = new();

        [Category("timeIntervalsByDayOfWeek")]
        public ObservableCollection<TimeOnly> timeOfDayStart { get; set; } = new();

        [Browsable(false)]
        public dayOfWeek[] dayOfWeekList => [(dayOfWeek)1, (dayOfWeek)2, (dayOfWeek)3, (dayOfWeek)4, (dayOfWeek)5, (dayOfWeek)6, (dayOfWeek)7];

        public void Load(DomainModel.S122.ComplexAttributes.timeIntervalsByDayOfWeek instance) {
            dayOfWeek.Clear();
            if (instance.dayOfWeek is not null)
                foreach (var e in instance.dayOfWeek)
                    dayOfWeek.Add(e);
            dayOfWeekIsRange = instance.dayOfWeekIsRange;
            timeOfDayEnd.Clear();
            if (instance.timeOfDayEnd is not null)
                foreach (var e in instance.timeOfDayEnd)
                    timeOfDayEnd.Add(e);
            timeOfDayStart.Clear();
            if (instance.timeOfDayStart is not null)
                foreach (var e in instance.timeOfDayStart)
                    timeOfDayStart.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.ComplexAttributes.timeIntervalsByDayOfWeek
            {
                dayOfWeek = this.dayOfWeek.ToList(),
                dayOfWeekIsRange = this.dayOfWeekIsRange,
                timeOfDayEnd = this.timeOfDayEnd.ToList(),
                timeOfDayStart = this.timeOfDayStart.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.timeIntervalsByDayOfWeek Model => new()
        {
            dayOfWeek = this.dayOfWeek.ToList(),
            dayOfWeekIsRange = this._dayOfWeekIsRange,
            timeOfDayEnd = this.timeOfDayEnd.ToList(),
            timeOfDayStart = this.timeOfDayStart.ToList(),
        };

        public timeIntervalsByDayOfWeekViewModel() : base() {
            dayOfWeek.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(dayOfWeek));
            };
            timeOfDayEnd.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(timeOfDayEnd));
            };
            timeOfDayStart.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(timeOfDayStart));
            };
        }

        public override string? ToString() => $"Time Intervals by Day of Week";
    }

    [CategoryOrder("vesselsMeasurements", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class vesselsMeasurementsViewModel : ViewModelBase {
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

        [Browsable(false)]
        public vesselsCharacteristics[] vesselsCharacteristicsList => [(vesselsCharacteristics)1, (vesselsCharacteristics)2, (vesselsCharacteristics)3, (vesselsCharacteristics)4, (vesselsCharacteristics)6, (vesselsCharacteristics)7, (vesselsCharacteristics)8, (vesselsCharacteristics)9, (vesselsCharacteristics)10, (vesselsCharacteristics)11, (vesselsCharacteristics)12, (vesselsCharacteristics)13];

        [Browsable(false)]
        public vesselsCharacteristicsUnit[] vesselsCharacteristicsUnitList => [(vesselsCharacteristicsUnit)3, (vesselsCharacteristicsUnit)4, (vesselsCharacteristicsUnit)5, (vesselsCharacteristicsUnit)6, (vesselsCharacteristicsUnit)7, (vesselsCharacteristicsUnit)9];

        [Browsable(false)]
        public comparisonOperator[] comparisonOperatorList => [(comparisonOperator)1, (comparisonOperator)2, (comparisonOperator)3, (comparisonOperator)4, (comparisonOperator)5, (comparisonOperator)6];

        public void Load(DomainModel.S122.ComplexAttributes.vesselsMeasurements instance) {
            vesselsCharacteristics = instance.vesselsCharacteristics;
            vesselsCharacteristicsValue = instance.vesselsCharacteristicsValue;
            vesselsCharacteristicsUnit = instance.vesselsCharacteristicsUnit;
            comparisonOperator = instance.comparisonOperator;
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.ComplexAttributes.vesselsMeasurements
            {
                vesselsCharacteristics = this.vesselsCharacteristics,
                vesselsCharacteristicsValue = this.vesselsCharacteristicsValue,
                vesselsCharacteristicsUnit = this.vesselsCharacteristicsUnit,
                comparisonOperator = this.comparisonOperator,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.vesselsMeasurements Model => new()
        {
            vesselsCharacteristics = this._vesselsCharacteristics,
            vesselsCharacteristicsValue = this._vesselsCharacteristicsValue,
            vesselsCharacteristicsUnit = this._vesselsCharacteristicsUnit,
            comparisonOperator = this._comparisonOperator,
        };

        public vesselsMeasurementsViewModel() : base() {
        }

        public override string? ToString() => $"Vessels Measurements";
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("designation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class designationViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        private String _designationScheme = string.Empty;
        [Category("designation")]
        public String designationScheme {
            get {
                return _designationScheme;
            }

            set {
                SetValue(ref _designationScheme, value);
            }
        }

        private String _designationIdentifier = string.Empty;
        [Category("designation")]
        public String designationIdentifier {
            get {
                return _designationIdentifier;
            }

            set {
                SetValue(ref _designationIdentifier, value);
            }
        }

        private jurisdiction? _jurisdiction = default;
        [DomainModel.EnumerationAttribute(nameof(jurisdictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("designation")]
        public jurisdiction? jurisdiction {
            get {
                return _jurisdiction;
            }

            set {
                SetValue(ref _jurisdiction, value);
            }
        }

        private String _text = string.Empty;
        [Category("designation")]
        public String text {
            get {
                return _text;
            }

            set {
                SetValue(ref _text, value);
            }
        }

        [Browsable(false)]
        public jurisdiction[] jurisdictionList => [];

        public void Load(DomainModel.S122.ComplexAttributes.designation instance) {
            designationScheme = instance.designationScheme;
            designationIdentifier = instance.designationIdentifier;
            jurisdiction = instance.jurisdiction;
            text = instance.text;
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.ComplexAttributes.designation
            {
                designationScheme = this.designationScheme,
                designationIdentifier = this.designationIdentifier,
                jurisdiction = this.jurisdiction,
                text = this.text,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.designation Model => new()
        {
            designationScheme = this._designationScheme,
            designationIdentifier = this._designationIdentifier,
            jurisdiction = this._jurisdiction,
            text = this._text,
        };

        public designationViewModel() : base() {
        }

        public override string? ToString() => $"designation";
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
        public cardinalDirection[] cardinalDirectionList => [];

        public void Load(DomainModel.S122.ComplexAttributes.bearingInformation instance) {
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
            var instance = new DomainModel.S122.ComplexAttributes.bearingInformation
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
        public DomainModel.S122.ComplexAttributes.bearingInformation Model => new()
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

        public void Load(DomainModel.S122.ComplexAttributes.graphic instance) {
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
            var instance = new DomainModel.S122.ComplexAttributes.graphic
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
        public DomainModel.S122.ComplexAttributes.graphic Model => new()
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

        public void Load(DomainModel.S122.ComplexAttributes.scheduleByDayOfWeek instance) {
            categoryOfSchedule = instance.categoryOfSchedule;
            timeIntervalsByDayOfWeek.Clear();
            if (instance.timeIntervalsByDayOfWeek is not null)
                foreach (var e in instance.timeIntervalsByDayOfWeek)
                    timeIntervalsByDayOfWeek.Add(e);
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.ComplexAttributes.scheduleByDayOfWeek
            {
                categoryOfSchedule = this.categoryOfSchedule,
                timeIntervalsByDayOfWeek = this.timeIntervalsByDayOfWeek.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.scheduleByDayOfWeek Model => new()
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

    [CategoryOrder("sectorLimit", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class sectorLimitViewModel : ViewModelBase {
        private sectorLimitOneViewModel _sectorLimitOne;
        [Category("sectorLimit")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sectorLimitOneViewModel sectorLimitOne {
            get {
                return _sectorLimitOne;
            }

            set {
                SetValue(ref _sectorLimitOne, value);
            }
        }

        private sectorLimitTwoViewModel _sectorLimitTwo;
        [Category("sectorLimit")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public sectorLimitTwoViewModel sectorLimitTwo {
            get {
                return _sectorLimitTwo;
            }

            set {
                SetValue(ref _sectorLimitTwo, value);
            }
        }

        public void Load(DomainModel.S122.ComplexAttributes.sectorLimit instance) {
            sectorLimitOne = new();
            if (instance.sectorLimitOne != null) {
                sectorLimitOne = new();
                sectorLimitOne.Load(instance.sectorLimitOne);
            }

            sectorLimitTwo = new();
            if (instance.sectorLimitTwo != null) {
                sectorLimitTwo = new();
                sectorLimitTwo.Load(instance.sectorLimitTwo);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.ComplexAttributes.sectorLimit
            {
                sectorLimitOne = this.sectorLimitOne?.Model,
                sectorLimitTwo = this.sectorLimitTwo?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.sectorLimit Model => new()
        {
            sectorLimitOne = this._sectorLimitOne?.Model,
            sectorLimitTwo = this._sectorLimitTwo?.Model,
        };

        public sectorLimitViewModel() : base() {
        }

        public override string? ToString() => $"Sector Limit";
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

        private String _telecomCarrier = string.Empty;
        [Category("telecommunications")]
        public String telecomCarrier {
            get {
                return _telecomCarrier;
            }

            set {
                SetValue(ref _telecomCarrier, value);
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

        private telecommunicationService? _telecommunicationService = default;
        [DomainModel.EnumerationAttribute(nameof(telecommunicationServiceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("telecommunications")]
        public telecommunicationService? telecommunicationService {
            get {
                return _telecommunicationService;
            }

            set {
                SetValue(ref _telecommunicationService, value);
            }
        }

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

        public void Load(DomainModel.S122.ComplexAttributes.telecommunications instance) {
            categoryOfCommunicationPreference = instance.categoryOfCommunicationPreference;
            contactInstructions = instance.contactInstructions;
            telecomCarrier = instance.telecomCarrier;
            telecommunicationIdentifier = instance.telecommunicationIdentifier;
            telecommunicationService = instance.telecommunicationService;
            scheduleByDayOfWeek = new();
            if (instance.scheduleByDayOfWeek != null) {
                scheduleByDayOfWeek = new();
                scheduleByDayOfWeek.Load(instance.scheduleByDayOfWeek);
            }
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.ComplexAttributes.telecommunications
            {
                categoryOfCommunicationPreference = this.categoryOfCommunicationPreference,
                contactInstructions = this.contactInstructions,
                telecomCarrier = this.telecomCarrier,
                telecommunicationIdentifier = this.telecommunicationIdentifier,
                telecommunicationService = this.telecommunicationService,
                scheduleByDayOfWeek = this.scheduleByDayOfWeek?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.ComplexAttributes.telecommunications Model => new()
        {
            categoryOfCommunicationPreference = this._categoryOfCommunicationPreference,
            contactInstructions = this._contactInstructions,
            telecomCarrier = this._telecomCarrier,
            telecommunicationIdentifier = this._telecommunicationIdentifier,
            telecommunicationService = this._telecommunicationService,
            scheduleByDayOfWeek = this._scheduleByDayOfWeek?.Model,
        };

        public telecommunicationsViewModel() : base() {
        }

        public override string? ToString() => $"Telecommunications";
    }

    [CategoryOrder("AssociatedRxN", 0)]
    [CategoryOrder("InformationBindings", 100)]
    public class AssociatedRxNViewModel<TAssociation> : ViewModelBase where TAssociation : DomainModel.S122.Associations.InformationAssociations.AssociatedRxN, new() {
        private roleType _roleType;
        [Category("AssociatedRxN")]
        public ObservableCollection<NewRefIdViewModel<TAssociation>> theRxN { get; set; } = new();

        [Browsable(false)]
        public string[] theRxNInformationTypes { get; private set; }

        public void Load(DomainModel.S122.Associations.InformationAssociations.AssociatedRxN instance) {
            foreach (var e in instance.theRxN) {
                theRxN.Add(new NewRefIdViewModel<TAssociation> { RefId = e.Value, });
            };
            theRxNInformationTypes = instance.theRxNInformationTypes;
            _roleType = instance.roleType!.Value;
        }

        public override string Serialize() {
            var instance = new TAssociation
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public AssociatedRxNViewModel() : base() {
        }

        public override string? ToString() => $"Associated RxN";
    }

    [CategoryOrder("ExceptionalWorkday", 0)]
    [CategoryOrder("InformationBindings", 100)]
    public class ExceptionalWorkdayViewModel<TAssociation> : ViewModelBase where TAssociation : DomainModel.S122.Associations.InformationAssociations.ExceptionalWorkday, new() {
        private roleType _roleType;
        [Category("ExceptionalWorkday")]
        public ObservableCollection<NewRefIdViewModel<TAssociation>> partialWorkingDay { get; set; } = new();

        [Browsable(false)]
        public string[] partialWorkingDayInformationTypes { get; private set; }

        [Category("ExceptionalWorkday")]
        public ObservableCollection<NewRefIdViewModel<TAssociation>> theServiceHours_nsdy { get; set; } = new();

        [Browsable(false)]
        public string[] theServiceHours_nsdyInformationTypes { get; private set; }

        public void Load(DomainModel.S122.Associations.InformationAssociations.ExceptionalWorkday instance) {
            foreach (var e in instance.partialWorkingDay) {
                partialWorkingDay.Add(new NewRefIdViewModel<TAssociation> { RefId = e.Value, });
            };
            partialWorkingDayInformationTypes = instance.partialWorkingDayInformationTypes;
            foreach (var e in instance.theServiceHours_nsdy) {
                theServiceHours_nsdy.Add(new NewRefIdViewModel<TAssociation> { RefId = e.Value, });
            };
            theServiceHours_nsdyInformationTypes = instance.theServiceHours_nsdyInformationTypes;
            _roleType = instance.roleType!.Value;
        }

        public override string Serialize() {
            var instance = new TAssociation
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public ExceptionalWorkdayViewModel() : base() {
        }

        public override string? ToString() => $"Exceptional workday";
    }

    [CategoryOrder("ProtectedAreaAuthority", 0)]
    [CategoryOrder("InformationBindings", 100)]
    public class ProtectedAreaAuthorityViewModel<TAssociation> : ViewModelBase where TAssociation : DomainModel.S122.Associations.InformationAssociations.ProtectedAreaAuthority, new() {
        private roleType _roleType;
        [Category("ProtectedAreaAuthority")]
        public ObservableCollection<NewRefIdViewModel<TAssociation>> responsibleAuthority { get; set; } = new();

        [Browsable(false)]
        public string[] responsibleAuthorityInformationTypes { get; private set; }

        public void Load(DomainModel.S122.Associations.InformationAssociations.ProtectedAreaAuthority instance) {
            foreach (var e in instance.responsibleAuthority) {
                responsibleAuthority.Add(new NewRefIdViewModel<TAssociation> { RefId = e.Value, });
            };
            responsibleAuthorityInformationTypes = instance.responsibleAuthorityInformationTypes;
            _roleType = instance.roleType!.Value;
        }

        public override string Serialize() {
            var instance = new TAssociation
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public ProtectedAreaAuthorityViewModel() : base() {
        }

        public override string? ToString() => $"Protected area authority";
    }

    [CategoryOrder("ServiceControl", 0)]
    [CategoryOrder("InformationBindings", 100)]
    public class ServiceControlViewModel<TAssociation> : ViewModelBase where TAssociation : DomainModel.S122.Associations.InformationAssociations.ServiceControl, new() {
        private roleType _roleType;
        private NewRefIdViewModel<TAssociation> _controlAuthority;
        [Editor(typeof(Editors.RefIdTypeEditor), typeof(Editors.RefIdTypeEditor))]
        [Category("ServiceControl")]
        public NewRefIdViewModel<TAssociation> controlAuthority {
            get {
                return _controlAuthority;
            }

            set {
                SetValue(ref _controlAuthority, value);
            }
        }

        [Browsable(false)]
        public string[] controlAuthorityInformationTypes { get; private set; }

        public void Load(DomainModel.S122.Associations.InformationAssociations.ServiceControl instance) {
            controlAuthority = new NewRefIdViewModel<TAssociation>
            {
                RefId = instance.controlAuthority?.Value,
            };
            controlAuthorityInformationTypes = instance.controlAuthorityInformationTypes;
            _roleType = instance.roleType!.Value;
        }

        public override string Serialize() {
            var instance = new TAssociation
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public ServiceControlViewModel() : base() {
        }

        public override string? ToString() => $"Service control";
    }

    [CategoryOrder("RelatedOrganisation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    public class RelatedOrganisationViewModel<TAssociation> : ViewModelBase where TAssociation : DomainModel.S122.Associations.InformationAssociations.RelatedOrganisation, new() {
        private roleType _roleType;
        [Category("RelatedOrganisation")]
        public ObservableCollection<NewRefIdViewModel<TAssociation>> theOrganisation { get; set; } = new();

        [Browsable(false)]
        public string[] theOrganisationInformationTypes { get; private set; }

        [Category("RelatedOrganisation")]
        public ObservableCollection<NewRefIdViewModel<TAssociation>> theInformation { get; set; } = new();

        [Browsable(false)]
        public string[] theInformationInformationTypes { get; private set; }

        public void Load(DomainModel.S122.Associations.InformationAssociations.RelatedOrganisation instance) {
            foreach (var e in instance.theOrganisation) {
                theOrganisation.Add(new NewRefIdViewModel<TAssociation> { RefId = e.Value, });
            };
            theOrganisationInformationTypes = instance.theOrganisationInformationTypes;
            foreach (var e in instance.theInformation) {
                theInformation.Add(new NewRefIdViewModel<TAssociation> { RefId = e.Value, });
            };
            theInformationInformationTypes = instance.theInformationInformationTypes;
            _roleType = instance.roleType!.Value;
        }

        public override string Serialize() {
            var instance = new TAssociation
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public RelatedOrganisationViewModel() : base() {
        }

        public override string? ToString() => $"Related organisation";
    }

    [CategoryOrder("PermissionType", 0)]
    [CategoryOrder("InformationBindings", 100)]
    public class PermissionTypeViewModel<TAssociation> : ViewModelBase where TAssociation : DomainModel.S122.Associations.InformationAssociations.PermissionType, new() {
        private roleType _roleType;
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
        public categoryOfRelationship[] categoryOfRelationshipList => [];

        public void Load(DomainModel.S122.Associations.InformationAssociations.PermissionType instance) {
            categoryOfRelationship = instance.categoryOfRelationship;
            _roleType = instance.roleType!.Value;
        }

        public override string Serialize() {
            var instance = new TAssociation
            {
                categoryOfRelationship = this.categoryOfRelationship,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public PermissionTypeViewModel() : base() {
        }

        public override string? ToString() => $"Permission Type";
    }

    [CategoryOrder("InclusionType", 0)]
    [CategoryOrder("InformationBindings", 100)]
    public class InclusionTypeViewModel<TAssociation> : ViewModelBase where TAssociation : DomainModel.S122.Associations.InformationAssociations.InclusionType, new() {
        private roleType _roleType;
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
        public membership[] membershipList => [];

        public void Load(DomainModel.S122.Associations.InformationAssociations.InclusionType instance) {
            membership = instance.membership;
            _roleType = instance.roleType!.Value;
        }

        public override string Serialize() {
            var instance = new TAssociation
            {
                membership = this.membership,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public InclusionTypeViewModel() : base() {
        }

        public override string? ToString() => $"Inclusion Type";
    }

    [CategoryOrder("AuthorityContact", 0)]
    [CategoryOrder("InformationBindings", 100)]
    public class AuthorityContactViewModel<TAssociation> : ViewModelBase where TAssociation : DomainModel.S122.Associations.InformationAssociations.AuthorityContact, new() {
        private roleType _roleType;
        [Category("AuthorityContact")]
        public ObservableCollection<NewRefIdViewModel<TAssociation>> theAuthority { get; set; } = new();

        [Browsable(false)]
        public string[] theAuthorityInformationTypes { get; private set; }

        [Category("AuthorityContact")]
        public ObservableCollection<NewRefIdViewModel<TAssociation>> theContactDetails { get; set; } = new();

        [Browsable(false)]
        public string[] theContactDetailsInformationTypes { get; private set; }

        public void Load(DomainModel.S122.Associations.InformationAssociations.AuthorityContact instance) {
            foreach (var e in instance.theAuthority) {
                theAuthority.Add(new NewRefIdViewModel<TAssociation> { RefId = e.Value, });
            };
            theAuthorityInformationTypes = instance.theAuthorityInformationTypes;
            foreach (var e in instance.theContactDetails) {
                theContactDetails.Add(new NewRefIdViewModel<TAssociation> { RefId = e.Value, });
            };
            theContactDetailsInformationTypes = instance.theContactDetailsInformationTypes;
            _roleType = instance.roleType!.Value;
        }

        public override string Serialize() {
            var instance = new TAssociation
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public AuthorityContactViewModel() : base() {
        }

        public override string? ToString() => $"Authority Contact";
    }

    [CategoryOrder("AuthorityHours", 0)]
    [CategoryOrder("InformationBindings", 100)]
    public class AuthorityHoursViewModel<TAssociation> : ViewModelBase where TAssociation : DomainModel.S122.Associations.InformationAssociations.AuthorityHours, new() {
        private roleType _roleType;
        [Category("AuthorityHours")]
        public ObservableCollection<NewRefIdViewModel<TAssociation>> theAuthority_srvHrs { get; set; } = new();

        [Browsable(false)]
        public string[] theAuthority_srvHrsInformationTypes { get; private set; }

        [Category("AuthorityHours")]
        public ObservableCollection<NewRefIdViewModel<TAssociation>> theServiceHours { get; set; } = new();

        [Browsable(false)]
        public string[] theServiceHoursInformationTypes { get; private set; }

        public void Load(DomainModel.S122.Associations.InformationAssociations.AuthorityHours instance) {
            foreach (var e in instance.theAuthority_srvHrs) {
                theAuthority_srvHrs.Add(new NewRefIdViewModel<TAssociation> { RefId = e.Value, });
            };
            theAuthority_srvHrsInformationTypes = instance.theAuthority_srvHrsInformationTypes;
            foreach (var e in instance.theServiceHours) {
                theServiceHours.Add(new NewRefIdViewModel<TAssociation> { RefId = e.Value, });
            };
            theServiceHoursInformationTypes = instance.theServiceHoursInformationTypes;
            _roleType = instance.roleType!.Value;
        }

        public override string Serialize() {
            var instance = new TAssociation
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public AuthorityHoursViewModel() : base() {
        }

        public override string? ToString() => $"Authority Hours";
    }

    [CategoryOrder("additionalInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    public class additionalInformationViewModel<TAssociation> : ViewModelBase where TAssociation : DomainModel.S122.Associations.InformationAssociations.additionalInformation, new() {
        private roleType _roleType;
        [Category("additionalInformation")]
        public ObservableCollection<NewRefIdViewModel<TAssociation>> providesInformation { get; set; } = new();

        [Browsable(false)]
        public string[] providesInformationInformationTypes { get; private set; }

        public void Load(DomainModel.S122.Associations.InformationAssociations.additionalInformation instance) {
            foreach (var e in instance.providesInformation) {
                providesInformation.Add(new NewRefIdViewModel<TAssociation> { RefId = e.Value, });
            };
            providesInformationInformationTypes = instance.providesInformationInformationTypes;
            _roleType = instance.roleType!.Value;
        }

        public override string Serialize() {
            var instance = new TAssociation
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public additionalInformationViewModel() : base() {
        }

        public override string? ToString() => $"Additional Information";
    }

    [CategoryOrder("InformationType", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class InformationTypeViewModel : ViewModelBase {
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

        public class InformationTypeRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["InformationType"];
        }

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public void Load(DomainModel.S122.InformationTypes.InformationType instance) {
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
            var instance = new DomainModel.S122.InformationTypes.InformationType
            {
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
        public DomainModel.S122.InformationTypes.InformationType Model => new()
        {
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public InformationTypeViewModel() : base() {
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

        public override string? ToString() => $"Information Type";
    }

    [CategoryOrder("AbstractRxN", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class AbstractRxNViewModel : ViewModelBase {
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

        private textContentViewModel? _textContent;
        [Category("AbstractRxN")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public textContentViewModel? textContent {
            get {
                return _textContent;
            }

            set {
                SetValue(ref _textContent, value);
            }
        }

        [Category("AbstractRxN")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

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

        public class AbstractRxNRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["AbstractRxN"];
        }

        [Browsable(false)]
        public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2, (categoryOfAuthority)3, (categoryOfAuthority)4, (categoryOfAuthority)5, (categoryOfAuthority)6, (categoryOfAuthority)7, (categoryOfAuthority)8, (categoryOfAuthority)9, (categoryOfAuthority)10, (categoryOfAuthority)11, (categoryOfAuthority)12, (categoryOfAuthority)13, (categoryOfAuthority)14, (categoryOfAuthority)15, (categoryOfAuthority)16];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public void Load(DomainModel.S122.InformationTypes.AbstractRxN instance) {
            categoryOfAuthority = instance.categoryOfAuthority;
            textContent = new();
            if (instance.textContent != null) {
                textContent = new();
                textContent.Load(instance.textContent);
            }

            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
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
            var instance = new DomainModel.S122.InformationTypes.AbstractRxN
            {
                categoryOfAuthority = this.categoryOfAuthority,
                textContent = this.textContent?.Model,
                rxNCode = this.rxNCode.ToList(),
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
        public DomainModel.S122.InformationTypes.AbstractRxN Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            textContent = this._textContent?.Model,
            rxNCode = this.rxNCode.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public AbstractRxNViewModel() : base() {
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
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

        public override string? ToString() => $"AbstractRxN";
    }

    [CategoryOrder("NauticalInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class NauticalInformationViewModel : ViewModelBase {
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

        private textContentViewModel? _textContent;
        [Category("AbstractRxN")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public textContentViewModel? textContent {
            get {
                return _textContent;
            }

            set {
                SetValue(ref _textContent, value);
            }
        }

        [Category("AbstractRxN")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

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

        public class NauticalInformationRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["NauticalInformation"];
        }

        [Browsable(false)]
        public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2, (categoryOfAuthority)3, (categoryOfAuthority)4, (categoryOfAuthority)5, (categoryOfAuthority)6, (categoryOfAuthority)7, (categoryOfAuthority)8, (categoryOfAuthority)9, (categoryOfAuthority)10, (categoryOfAuthority)11, (categoryOfAuthority)12, (categoryOfAuthority)13, (categoryOfAuthority)14, (categoryOfAuthority)15, (categoryOfAuthority)16];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public void Load(DomainModel.S122.InformationTypes.NauticalInformation instance) {
            categoryOfAuthority = instance.categoryOfAuthority;
            textContent = new();
            if (instance.textContent != null) {
                textContent = new();
                textContent.Load(instance.textContent);
            }

            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
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
            var instance = new DomainModel.S122.InformationTypes.NauticalInformation
            {
                categoryOfAuthority = this.categoryOfAuthority,
                textContent = this.textContent?.Model,
                rxNCode = this.rxNCode.ToList(),
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
        public DomainModel.S122.InformationTypes.NauticalInformation Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            textContent = this._textContent?.Model,
            rxNCode = this.rxNCode.ToList(),
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

    [CategoryOrder("Regulations", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RegulationsViewModel : ViewModelBase {
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

        private textContentViewModel? _textContent;
        [Category("AbstractRxN")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public textContentViewModel? textContent {
            get {
                return _textContent;
            }

            set {
                SetValue(ref _textContent, value);
            }
        }

        [Category("AbstractRxN")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

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

        public class RegulationsRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["Regulations"];
        }

        [Browsable(false)]
        public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2, (categoryOfAuthority)3, (categoryOfAuthority)4, (categoryOfAuthority)5, (categoryOfAuthority)6, (categoryOfAuthority)7, (categoryOfAuthority)8, (categoryOfAuthority)9, (categoryOfAuthority)10, (categoryOfAuthority)11, (categoryOfAuthority)12, (categoryOfAuthority)13, (categoryOfAuthority)14, (categoryOfAuthority)15, (categoryOfAuthority)16];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public void Load(DomainModel.S122.InformationTypes.Regulations instance) {
            categoryOfAuthority = instance.categoryOfAuthority;
            textContent = new();
            if (instance.textContent != null) {
                textContent = new();
                textContent.Load(instance.textContent);
            }

            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
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
            var instance = new DomainModel.S122.InformationTypes.Regulations
            {
                categoryOfAuthority = this.categoryOfAuthority,
                textContent = this.textContent?.Model,
                rxNCode = this.rxNCode.ToList(),
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
        public DomainModel.S122.InformationTypes.Regulations Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            textContent = this._textContent?.Model,
            rxNCode = this.rxNCode.ToList(),
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
    public partial class RestrictionsViewModel : ViewModelBase {
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

        private textContentViewModel? _textContent;
        [Category("AbstractRxN")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public textContentViewModel? textContent {
            get {
                return _textContent;
            }

            set {
                SetValue(ref _textContent, value);
            }
        }

        [Category("AbstractRxN")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

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

        public class RestrictionsRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["Restrictions"];
        }

        [Browsable(false)]
        public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2, (categoryOfAuthority)3, (categoryOfAuthority)4, (categoryOfAuthority)5, (categoryOfAuthority)6, (categoryOfAuthority)7, (categoryOfAuthority)8, (categoryOfAuthority)9, (categoryOfAuthority)10, (categoryOfAuthority)11, (categoryOfAuthority)12, (categoryOfAuthority)13, (categoryOfAuthority)14, (categoryOfAuthority)15, (categoryOfAuthority)16];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public void Load(DomainModel.S122.InformationTypes.Restrictions instance) {
            categoryOfAuthority = instance.categoryOfAuthority;
            textContent = new();
            if (instance.textContent != null) {
                textContent = new();
                textContent.Load(instance.textContent);
            }

            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
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
            var instance = new DomainModel.S122.InformationTypes.Restrictions
            {
                categoryOfAuthority = this.categoryOfAuthority,
                textContent = this.textContent?.Model,
                rxNCode = this.rxNCode.ToList(),
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
        public DomainModel.S122.InformationTypes.Restrictions Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            textContent = this._textContent?.Model,
            rxNCode = this.rxNCode.ToList(),
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

    [CategoryOrder("Recommendations", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RecommendationsViewModel : ViewModelBase {
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

        private textContentViewModel? _textContent;
        [Category("AbstractRxN")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public textContentViewModel? textContent {
            get {
                return _textContent;
            }

            set {
                SetValue(ref _textContent, value);
            }
        }

        [Category("AbstractRxN")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

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

        public class RecommendationsRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["Recommendations"];
        }

        [Browsable(false)]
        public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2, (categoryOfAuthority)3, (categoryOfAuthority)4, (categoryOfAuthority)5, (categoryOfAuthority)6, (categoryOfAuthority)7, (categoryOfAuthority)8, (categoryOfAuthority)9, (categoryOfAuthority)10, (categoryOfAuthority)11, (categoryOfAuthority)12, (categoryOfAuthority)13, (categoryOfAuthority)14, (categoryOfAuthority)15, (categoryOfAuthority)16];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public void Load(DomainModel.S122.InformationTypes.Recommendations instance) {
            categoryOfAuthority = instance.categoryOfAuthority;
            textContent = new();
            if (instance.textContent != null) {
                textContent = new();
                textContent.Load(instance.textContent);
            }

            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
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
            var instance = new DomainModel.S122.InformationTypes.Recommendations
            {
                categoryOfAuthority = this.categoryOfAuthority,
                textContent = this.textContent?.Model,
                rxNCode = this.rxNCode.ToList(),
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
        public DomainModel.S122.InformationTypes.Recommendations Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            textContent = this._textContent?.Model,
            rxNCode = this.rxNCode.ToList(),
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

    [CategoryOrder("Authority", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class AuthorityViewModel : ViewModelBase {
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

        [Category("Authority")]
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

        public class AuthorityRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["Authority"];
        }

        [Browsable(false)]
        public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2, (categoryOfAuthority)3, (categoryOfAuthority)4, (categoryOfAuthority)5, (categoryOfAuthority)6, (categoryOfAuthority)7, (categoryOfAuthority)8, (categoryOfAuthority)9, (categoryOfAuthority)10, (categoryOfAuthority)11, (categoryOfAuthority)12, (categoryOfAuthority)13, (categoryOfAuthority)14, (categoryOfAuthority)15, (categoryOfAuthority)16];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public void Load(DomainModel.S122.InformationTypes.Authority instance) {
            categoryOfAuthority = instance.categoryOfAuthority;
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
            var instance = new DomainModel.S122.InformationTypes.Authority
            {
                categoryOfAuthority = this.categoryOfAuthority,
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
        public DomainModel.S122.InformationTypes.Authority Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            textContent = this.textContent.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public AuthorityViewModel() : base() {
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

        public override string? ToString() => $"Authority";
    }

    [CategoryOrder("ContactDetails", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ContactDetailsViewModel : ViewModelBase {
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
        public ObservableCollection<Int32> signalFrequency { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<contactAddress> contactAddress { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<frequencyPair> frequencyPair { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<onlineResource> onlineResource { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<telecommunications> telecommunications { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<information> information { get; set; } = new();

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

        private textContentViewModel? _textContent;
        [Category("AbstractRxN")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public textContentViewModel? textContent {
            get {
                return _textContent;
            }

            set {
                SetValue(ref _textContent, value);
            }
        }

        [Category("AbstractRxN")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

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

        public class ContactDetailsRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["ContactDetails"];
        }

        [Browsable(false)]
        public categoryOfCommunicationPreference[] categoryOfCommunicationPreferenceList => [(categoryOfCommunicationPreference)1, (categoryOfCommunicationPreference)2, (categoryOfCommunicationPreference)3, (categoryOfCommunicationPreference)4];

        [Browsable(false)]
        public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2, (categoryOfAuthority)3, (categoryOfAuthority)4, (categoryOfAuthority)5, (categoryOfAuthority)6, (categoryOfAuthority)7, (categoryOfAuthority)8, (categoryOfAuthority)9, (categoryOfAuthority)10, (categoryOfAuthority)11, (categoryOfAuthority)12, (categoryOfAuthority)13, (categoryOfAuthority)14, (categoryOfAuthority)15, (categoryOfAuthority)16];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public void Load(DomainModel.S122.InformationTypes.ContactDetails instance) {
            callName = instance.callName;
            callSign = instance.callSign;
            categoryOfCommunicationPreference = instance.categoryOfCommunicationPreference;
            communicationChannel.Clear();
            if (instance.communicationChannel is not null)
                foreach (var e in instance.communicationChannel)
                    communicationChannel.Add(e);
            contactInstructions = instance.contactInstructions;
            mMSICode = instance.mMSICode;
            signalFrequency.Clear();
            if (instance.signalFrequency is not null)
                foreach (var e in instance.signalFrequency)
                    signalFrequency.Add(e);
            contactAddress.Clear();
            if (instance.contactAddress is not null)
                foreach (var e in instance.contactAddress)
                    contactAddress.Add(e);
            frequencyPair.Clear();
            if (instance.frequencyPair is not null)
                foreach (var e in instance.frequencyPair)
                    frequencyPair.Add(e);
            onlineResource.Clear();
            if (instance.onlineResource is not null)
                foreach (var e in instance.onlineResource)
                    onlineResource.Add(e);
            telecommunications.Clear();
            if (instance.telecommunications is not null)
                foreach (var e in instance.telecommunications)
                    telecommunications.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            categoryOfAuthority = instance.categoryOfAuthority;
            textContent = new();
            if (instance.textContent != null) {
                textContent = new();
                textContent.Load(instance.textContent);
            }

            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
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
            var instance = new DomainModel.S122.InformationTypes.ContactDetails
            {
                callName = this.callName,
                callSign = this.callSign,
                categoryOfCommunicationPreference = this.categoryOfCommunicationPreference,
                communicationChannel = this.communicationChannel.ToList(),
                contactInstructions = this.contactInstructions,
                mMSICode = this.mMSICode,
                signalFrequency = this.signalFrequency.ToList(),
                contactAddress = this.contactAddress.ToList(),
                frequencyPair = this.frequencyPair.ToList(),
                onlineResource = this.onlineResource.ToList(),
                telecommunications = this.telecommunications.ToList(),
                information = this.information.ToList(),
                categoryOfAuthority = this.categoryOfAuthority,
                textContent = this.textContent?.Model,
                rxNCode = this.rxNCode.ToList(),
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
        public DomainModel.S122.InformationTypes.ContactDetails Model => new()
        {
            callName = this._callName,
            callSign = this._callSign,
            categoryOfCommunicationPreference = this._categoryOfCommunicationPreference,
            communicationChannel = this.communicationChannel.ToList(),
            contactInstructions = this._contactInstructions,
            mMSICode = this._mMSICode,
            signalFrequency = this.signalFrequency.ToList(),
            contactAddress = this.contactAddress.ToList(),
            frequencyPair = this.frequencyPair.ToList(),
            onlineResource = this.onlineResource.ToList(),
            telecommunications = this.telecommunications.ToList(),
            information = this.information.ToList(),
            categoryOfAuthority = this._categoryOfAuthority,
            textContent = this._textContent?.Model,
            rxNCode = this.rxNCode.ToList(),
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
            signalFrequency.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(signalFrequency));
            };
            contactAddress.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(contactAddress));
            };
            frequencyPair.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(frequencyPair));
            };
            onlineResource.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(onlineResource));
            };
            telecommunications.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(telecommunications));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(information));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(rxNCode));
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

    [CategoryOrder("NonStandardWorkingDay", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class NonStandardWorkingDayViewModel : ViewModelBase {
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

        public class NonStandardWorkingDayRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["NonStandardWorkingDay"];
        }

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public void Load(DomainModel.S122.InformationTypes.NonStandardWorkingDay instance) {
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
            var instance = new DomainModel.S122.InformationTypes.NonStandardWorkingDay
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
        public DomainModel.S122.InformationTypes.NonStandardWorkingDay Model => new()
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

    [CategoryOrder("ServiceHours", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ServiceHoursViewModel : ViewModelBase {
        [Category("ServiceHours")]
        public ObservableCollection<scheduleByDayOfWeek> scheduleByDayOfWeek { get; set; } = new();

        private informationViewModel _information;
        [Category("ServiceHours")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public informationViewModel information {
            get {
                return _information;
            }

            set {
                SetValue(ref _information, value);
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

        public class ServiceHoursRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["ServiceHours"];
        }

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public void Load(DomainModel.S122.InformationTypes.ServiceHours instance) {
            scheduleByDayOfWeek.Clear();
            if (instance.scheduleByDayOfWeek is not null)
                foreach (var e in instance.scheduleByDayOfWeek)
                    scheduleByDayOfWeek.Add(e);
            information = new();
            if (instance.information != null) {
                information = new();
                information.Load(instance.information);
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
            var instance = new DomainModel.S122.InformationTypes.ServiceHours
            {
                scheduleByDayOfWeek = this.scheduleByDayOfWeek.ToList(),
                information = this.information?.Model,
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
        public DomainModel.S122.InformationTypes.ServiceHours Model => new()
        {
            scheduleByDayOfWeek = this.scheduleByDayOfWeek.ToList(),
            information = this._information?.Model,
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

    [CategoryOrder("Applicability", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ApplicabilityViewModel : ViewModelBase {
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

        public class ApplicabilityRefIdViewModel : InformationRefIdViewModel {
            public override string[] AssociationTypes => ["Applicability"];
        }

        [Browsable(false)]
        public categoryOfVessel[] categoryOfVesselList => CodeList.categoryOfVessels.ToArray();

        [Browsable(false)]
        public categoryOfCargo[] categoryOfCargoList => [(categoryOfCargo)1, (categoryOfCargo)2, (categoryOfCargo)3, (categoryOfCargo)4, (categoryOfCargo)5, (categoryOfCargo)6, (categoryOfCargo)7, (categoryOfCargo)8, (categoryOfCargo)9];

        [Browsable(false)]
        public categoryOfDangerousOrHazardousCargo[] categoryOfDangerousOrHazardousCargoList => [(categoryOfDangerousOrHazardousCargo)1, (categoryOfDangerousOrHazardousCargo)2, (categoryOfDangerousOrHazardousCargo)3, (categoryOfDangerousOrHazardousCargo)4, (categoryOfDangerousOrHazardousCargo)5, (categoryOfDangerousOrHazardousCargo)6, (categoryOfDangerousOrHazardousCargo)7, (categoryOfDangerousOrHazardousCargo)8, (categoryOfDangerousOrHazardousCargo)9, (categoryOfDangerousOrHazardousCargo)10, (categoryOfDangerousOrHazardousCargo)11, (categoryOfDangerousOrHazardousCargo)12, (categoryOfDangerousOrHazardousCargo)13, (categoryOfDangerousOrHazardousCargo)14, (categoryOfDangerousOrHazardousCargo)15, (categoryOfDangerousOrHazardousCargo)16, (categoryOfDangerousOrHazardousCargo)17, (categoryOfDangerousOrHazardousCargo)18, (categoryOfDangerousOrHazardousCargo)19, (categoryOfDangerousOrHazardousCargo)20, (categoryOfDangerousOrHazardousCargo)21];

        [Browsable(false)]
        public categoryOfVesselRegistry[] categoryOfVesselRegistryList => [(categoryOfVesselRegistry)1, (categoryOfVesselRegistry)2];

        [Browsable(false)]
        public logicalConnectives[] logicalConnectivesList => [(logicalConnectives)1, (logicalConnectives)2];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public void Load(DomainModel.S122.InformationTypes.Applicability instance) {
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
            var instance = new DomainModel.S122.InformationTypes.Applicability
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
        public DomainModel.S122.InformationTypes.Applicability Model => new()
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

    [CategoryOrder("RestrictedArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RestrictedAreaViewModel : ViewModelBase {
        [DomainModel.EnumerationAttribute(nameof(categoryOfRestrictedAreaList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("RestrictedArea")]
        public ObservableCollection<categoryOfRestrictedArea> categoryOfRestrictedArea { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(restrictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("RestrictedArea")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("RestrictedArea")]
        public ObservableCollection<status> status { get; set; } = new();

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
        public ObservableCollection<textContent> textContent { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("FeatureType")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

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

        public class RestrictedAreaRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["RestrictedArea"];
        }

        [Browsable(false)]
        public categoryOfRestrictedArea[] categoryOfRestrictedAreaList => [(categoryOfRestrictedArea)1, (categoryOfRestrictedArea)4, (categoryOfRestrictedArea)5, (categoryOfRestrictedArea)6, (categoryOfRestrictedArea)7, (categoryOfRestrictedArea)8, (categoryOfRestrictedArea)9, (categoryOfRestrictedArea)10, (categoryOfRestrictedArea)12, (categoryOfRestrictedArea)14, (categoryOfRestrictedArea)18, (categoryOfRestrictedArea)19, (categoryOfRestrictedArea)20, (categoryOfRestrictedArea)21, (categoryOfRestrictedArea)22, (categoryOfRestrictedArea)23, (categoryOfRestrictedArea)24, (categoryOfRestrictedArea)25, (categoryOfRestrictedArea)26, (categoryOfRestrictedArea)27, (categoryOfRestrictedArea)28, (categoryOfRestrictedArea)29, (categoryOfRestrictedArea)30, (categoryOfRestrictedArea)31, (categoryOfRestrictedArea)32, (categoryOfRestrictedArea)33];

        [Browsable(false)]
        public restriction[] restrictionList => [(restriction)1, (restriction)2, (restriction)3, (restriction)4, (restriction)5, (restriction)6, (restriction)7, (restriction)8, (restriction)9, (restriction)10, (restriction)11, (restriction)12, (restriction)13, (restriction)14, (restriction)15, (restriction)16, (restriction)17, (restriction)18, (restriction)19, (restriction)20, (restriction)21, (restriction)22, (restriction)23, (restriction)24, (restriction)25, (restriction)26, (restriction)27, (restriction)28, (restriction)29, (restriction)30, (restriction)31, (restriction)32, (restriction)33, (restriction)34, (restriction)35, (restriction)36, (restriction)37, (restriction)38, (restriction)39, (restriction)40, (restriction)41];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)3, (status)4, (status)5, (status)6, (status)7, (status)8, (status)9, (status)11, (status)12, (status)13, (status)14, (status)15, (status)16, (status)17, (status)18, (status)19, (status)20, (status)21, (status)22, (status)23, (status)24, (status)25, (status)26, (status)27, (status)28, (status)29, (status)30, (status)31, (status)32, (status)33, (status)34, (status)35, (status)36, (status)37, (status)38, (status)39, (status)41, (status)42, (status)43];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public void Load(DomainModel.S122.FeatureTypes.RestrictedArea instance) {
            categoryOfRestrictedArea.Clear();
            if (instance.categoryOfRestrictedArea is not null)
                foreach (var e in instance.categoryOfRestrictedArea)
                    categoryOfRestrictedArea.Add(e);
            restriction.Clear();
            if (instance.restriction is not null)
                foreach (var e in instance.restriction)
                    restriction.Add(e);
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
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
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.FeatureTypes.RestrictedArea
            {
                categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
                restriction = this.restriction.ToList(),
                status = this.status.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                textContent = this.textContent.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.FeatureTypes.RestrictedArea Model => new()
        {
            categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
            restriction = this.restriction.ToList(),
            status = this.status.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            textContent = this.textContent.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public RestrictedAreaViewModel() : base() {
            categoryOfRestrictedArea.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfRestrictedArea));
            };
            restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(restriction));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Restricted Area";
    }

    [CategoryOrder("MarineProtectedArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class MarineProtectedAreaViewModel : ViewModelBase {
        private categoryOfMarineProtectedArea _categoryOfMarineProtectedArea;
        [DomainModel.CodeList(nameof(categoryOfMarineProtectedAreaList))]
        [Editor(typeof(Editors.CodeListComboEditor), typeof(Editors.CodeListComboEditor))]
        [Category("MarineProtectedArea")]
        public categoryOfMarineProtectedArea categoryOfMarineProtectedArea {
            get {
                return _categoryOfMarineProtectedArea;
            }

            set {
                SetValue(ref _categoryOfMarineProtectedArea, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(categoryOfRestrictedAreaList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("MarineProtectedArea")]
        public ObservableCollection<categoryOfRestrictedArea> categoryOfRestrictedArea { get; set; } = new();

        private jurisdiction _jurisdiction;
        [DomainModel.EnumerationAttribute(nameof(jurisdictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("MarineProtectedArea")]
        public jurisdiction jurisdiction {
            get {
                return _jurisdiction;
            }

            set {
                SetValue(ref _jurisdiction, value);
            }
        }

        [DomainModel.EnumerationAttribute(nameof(restrictionList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("MarineProtectedArea")]
        public ObservableCollection<restriction> restriction { get; set; } = new();

        [DomainModel.EnumerationAttribute(nameof(statusList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("MarineProtectedArea")]
        public ObservableCollection<status> status { get; set; } = new();

        [Category("MarineProtectedArea")]
        public ObservableCollection<designation> designation { get; set; } = new();

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
        public ObservableCollection<textContent> textContent { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("FeatureType")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

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

        public class MarineProtectedAreaRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["MarineProtectedArea"];
        }

        [Browsable(false)]
        public categoryOfMarineProtectedArea[] categoryOfMarineProtectedAreaList => CodeList.categoryOfMarineProtectedAreas.ToArray();

        [Browsable(false)]
        public categoryOfRestrictedArea[] categoryOfRestrictedAreaList => [(categoryOfRestrictedArea)1, (categoryOfRestrictedArea)4, (categoryOfRestrictedArea)5, (categoryOfRestrictedArea)6, (categoryOfRestrictedArea)7, (categoryOfRestrictedArea)8, (categoryOfRestrictedArea)9, (categoryOfRestrictedArea)10, (categoryOfRestrictedArea)12, (categoryOfRestrictedArea)14, (categoryOfRestrictedArea)18, (categoryOfRestrictedArea)19, (categoryOfRestrictedArea)20, (categoryOfRestrictedArea)21, (categoryOfRestrictedArea)22, (categoryOfRestrictedArea)23, (categoryOfRestrictedArea)24, (categoryOfRestrictedArea)25, (categoryOfRestrictedArea)26, (categoryOfRestrictedArea)27, (categoryOfRestrictedArea)28, (categoryOfRestrictedArea)29, (categoryOfRestrictedArea)30, (categoryOfRestrictedArea)31, (categoryOfRestrictedArea)32, (categoryOfRestrictedArea)33];

        [Browsable(false)]
        public jurisdiction[] jurisdictionList => [(jurisdiction)1, (jurisdiction)2, (jurisdiction)3];

        [Browsable(false)]
        public restriction[] restrictionList => [(restriction)1, (restriction)2, (restriction)3, (restriction)4, (restriction)5, (restriction)6, (restriction)7, (restriction)8, (restriction)9, (restriction)10, (restriction)11, (restriction)12, (restriction)13, (restriction)14, (restriction)15, (restriction)16, (restriction)17, (restriction)18, (restriction)19, (restriction)20, (restriction)21, (restriction)22, (restriction)23, (restriction)24, (restriction)25, (restriction)26, (restriction)27, (restriction)28, (restriction)29, (restriction)30, (restriction)31, (restriction)32, (restriction)33, (restriction)34, (restriction)35, (restriction)36, (restriction)37, (restriction)38, (restriction)39, (restriction)40, (restriction)41];

        [Browsable(false)]
        public status[] statusList => [(status)1, (status)2, (status)3, (status)4, (status)5, (status)6, (status)7, (status)8, (status)9, (status)11, (status)12, (status)13, (status)14, (status)15, (status)16, (status)17, (status)18, (status)19, (status)20, (status)21, (status)22, (status)23, (status)24, (status)25, (status)26, (status)27, (status)28, (status)29, (status)30, (status)31, (status)32, (status)33, (status)34, (status)35, (status)36, (status)37, (status)38, (status)39, (status)41, (status)42, (status)43];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public void Load(DomainModel.S122.FeatureTypes.MarineProtectedArea instance) {
            categoryOfMarineProtectedArea = instance.categoryOfMarineProtectedArea;
            categoryOfRestrictedArea.Clear();
            if (instance.categoryOfRestrictedArea is not null)
                foreach (var e in instance.categoryOfRestrictedArea)
                    categoryOfRestrictedArea.Add(e);
            jurisdiction = instance.jurisdiction;
            restriction.Clear();
            if (instance.restriction is not null)
                foreach (var e in instance.restriction)
                    restriction.Add(e);
            status.Clear();
            if (instance.status is not null)
                foreach (var e in instance.status)
                    status.Add(e);
            designation.Clear();
            if (instance.designation is not null)
                foreach (var e in instance.designation)
                    designation.Add(e);
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
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.FeatureTypes.MarineProtectedArea
            {
                categoryOfMarineProtectedArea = this.categoryOfMarineProtectedArea,
                categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
                jurisdiction = this.jurisdiction,
                restriction = this.restriction.ToList(),
                status = this.status.ToList(),
                designation = this.designation.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                textContent = this.textContent.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.FeatureTypes.MarineProtectedArea Model => new()
        {
            categoryOfMarineProtectedArea = this._categoryOfMarineProtectedArea,
            categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
            jurisdiction = this._jurisdiction,
            restriction = this.restriction.ToList(),
            status = this.status.ToList(),
            designation = this.designation.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            textContent = this.textContent.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public MarineProtectedAreaViewModel() : base() {
            categoryOfRestrictedArea.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(categoryOfRestrictedArea));
            };
            restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(restriction));
            };
            status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(status));
            };
            designation.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(designation));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Marine Protected Area";
    }

    [CategoryOrder("VesselTrafficServiceArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class VesselTrafficServiceAreaViewModel : ViewModelBase {
        private categoryOfVesselTrafficService _categoryOfVesselTrafficService;
        [DomainModel.EnumerationAttribute(nameof(categoryOfVesselTrafficServiceList))]
        [Editor(typeof(Editors.EnumCheckComboEditor), typeof(Editors.EnumCheckComboEditor))]
        [Category("VesselTrafficServiceArea")]
        public categoryOfVesselTrafficService categoryOfVesselTrafficService {
            get {
                return _categoryOfVesselTrafficService;
            }

            set {
                SetValue(ref _categoryOfVesselTrafficService, value);
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
        public ObservableCollection<textContent> textContent { get; set; } = new();

        private String _interoperabilityIdentifier = string.Empty;
        [Category("FeatureType")]
        public String interoperabilityIdentifier {
            get {
                return _interoperabilityIdentifier;
            }

            set {
                SetValue(ref _interoperabilityIdentifier, value);
            }
        }

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

        public class VesselTrafficServiceAreaRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["VesselTrafficServiceArea"];
        }

        [Browsable(false)]
        public categoryOfVesselTrafficService[] categoryOfVesselTrafficServiceList => [(categoryOfVesselTrafficService)1, (categoryOfVesselTrafficService)2, (categoryOfVesselTrafficService)3, (categoryOfVesselTrafficService)4, (categoryOfVesselTrafficService)5];

        [Browsable(false)]
        public sourceType[] sourceTypeList => [(sourceType)1, (sourceType)2, (sourceType)7, (sourceType)8, (sourceType)9, (sourceType)10, (sourceType)11, (sourceType)12, (sourceType)13, (sourceType)14];

        public void Load(DomainModel.S122.FeatureTypes.VesselTrafficServiceArea instance) {
            categoryOfVesselTrafficService = instance.categoryOfVesselTrafficService;
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
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
            interoperabilityIdentifier = instance.interoperabilityIdentifier;
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.FeatureTypes.VesselTrafficServiceArea
            {
                categoryOfVesselTrafficService = this.categoryOfVesselTrafficService,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                textContent = this.textContent.ToList(),
                interoperabilityIdentifier = this.interoperabilityIdentifier,
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.FeatureTypes.VesselTrafficServiceArea Model => new()
        {
            categoryOfVesselTrafficService = this._categoryOfVesselTrafficService,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            textContent = this.textContent.ToList(),
            interoperabilityIdentifier = this._interoperabilityIdentifier,
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public VesselTrafficServiceAreaViewModel() : base() {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
                OnPropertyChanged(nameof(textContent));
            };
        }

        public override string? ToString() => $"Vessel Traffic Service Area";
    }

    [CategoryOrder("DataCoverage", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DataCoverageViewModel : ViewModelBase {
        public class DataCoverageRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["DataCoverage"];
        }

        public void Load(DomainModel.S122.FeatureTypes.DataCoverage instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.FeatureTypes.DataCoverage
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.FeatureTypes.DataCoverage Model => new()
        {
        };

        public DataCoverageViewModel() : base() {
        }

        public override string? ToString() => $"Data Coverage";
    }

    [CategoryOrder("TextPlacement", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class TextPlacementViewModel : ViewModelBase {
        public class TextPlacementRefIdViewModel : FeatureRefIdViewModel {
            public override string[] AssociationTypes => ["TextPlacement"];
        }

        public void Load(DomainModel.S122.FeatureTypes.TextPlacement instance) {
        }

        public override string Serialize() {
            var instance = new DomainModel.S122.FeatureTypes.TextPlacement
            {
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S122.FeatureTypes.TextPlacement Model => new()
        {
        };

        public TextPlacementViewModel() : base() {
        }

        public override string? ToString() => $"Text Placement";
    }
}