using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ComponentModel;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S128;
using S100Framework.DomainModel.S128.ComplexAttributes;
using S100Framework.DomainModel.S128.InformationTypes;
using S100Framework.DomainModel.S128.FeatureTypes;
using S100Framework.DomainModel.S128.InformationAssociations;
using S100Framework.DomainModel.S128.FeatureAssociations;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.WPF.ViewModel.S128 {
	internal static class Bootstrap {
		public static AssociationViewModel CreateInformationAssociation(string type, string? name = default) => type switch {
			"CarriageRequirement" => new CarriageRequirementViewModel { Name = name },
			"DistributionDetails" => new DistributionDetailsViewModel { Name = name },
			"DistributorContact" => new DistributorContactViewModel { Name = name },
			"PriceOfElement" => new PriceOfElementViewModel { Name = name },
			"PriceOfNauticalProduct" => new PriceOfNauticalProductViewModel { Name = name },
			"ProducerContact" => new ProducerContactViewModel { Name = name },
			"ProductionDetails" => new ProductionDetailsViewModel { Name = name },
			"ProductPackage" => new ProductPackageViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static AssociationViewModel CreateFeatureAssociation(string type, string? name = default) => type switch {
			"ProductMapping" => new ProductMappingViewModel { Name = name },
			"Correlated" => new CorrelatedViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static InformationViewModel CreateInformationType(string type, string? name = default) => type switch {
			"CatalogueSectionHeader" => new CatalogueSectionHeaderViewModel { Name = name },
			"ContactDetails" => new ContactDetailsViewModel { Name = name },
			"IndicationOfCarriageRequirement" => new IndicationOfCarriageRequirementViewModel { Name = name },
			"PriceInformation" => new PriceInformationViewModel { Name = name },
			"ProducerInformation" => new ProducerInformationViewModel { Name = name },
			"DistributorInformation" => new DistributorInformationViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static FeatureViewModel CreateFeatureType(string type, string? name = default) => type switch {
			"ElectronicProduct" => new ElectronicProductViewModel { Name = name },
			"PhysicalProduct" => new PhysicalProductViewModel { Name = name },
			"S100Service" => new S100ServiceViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static ICollection<string> InformationAssociationBindings(string association, string role) => (association, role) switch {
			("PriceOfNauticalProduct", "thePriceInformation") => ["PriceInformation"],
			("ProductionDetails", "theProducer") => ["ProducerInformation"],
			("DistributionDetails", "theDistributor") => ["DistributorInformation"],
			("ProducerContact", "theProducer") => ["ProducerInformation"],
			("DistributorContact", "theDistributor") => ["DistributorInformation"],
			("PriceOfNauticalProduct", "theCatalogueOfNauticalProduct") => ["CatalogueSectionHeader"],
			("ProducerContact", "theContactDetails") => ["ContactDetails"],
			("ProductionDetails", "catalogueHeader") => ["CatalogueSectionHeader"],
			("DistributionDetails", "catalogueHeader") => ["CatalogueSectionHeader"],
			("DistributorContact", "theContactDetails") => ["ContactDetails"],
			("CarriageRequirement", "theRequirement") => ["IndicationOfCarriageRequirement"],
			("PriceOfElement", "thePriceInformation") => ["PriceInformation"],
			("ProductPackage", "elementContainer") => ["CatalogueSectionHeader"],
			_ => throw new InvalidOperationException(),
		};

		public static ICollection<string> FeatureAssociationBindings(string association, string role) => (association, role) switch {
			("ProductMapping", "theReference") => ["CatalogueElement"],
			("Correlated", "theMain") => ["NavigationalProduct"],
			("Correlated", "thePanel") => ["NavigationalProduct"],
			_ => throw new InvalidOperationException(),
		};
	}

	/// <summary>
	/// Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.
	/// </summary>
	[CategoryOrder("contactAddress",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class contactAddressViewModel : ViewModelBase {
		private String? _administrativeDivision  = default;

		public String? administrativeDivision {
			get {
				return _administrativeDivision;
			}
			set {
				SetValue(ref _administrativeDivision, value);
			}
		}
		private String? _cityName  = default;

		public String? cityName {
			get {
				return _cityName;
			}
			set {
				SetValue(ref _cityName, value);
			}
		}
		private String? _countryName  = default;

		public String? countryName {
			get {
				return _countryName;
			}
			set {
				SetValue(ref _countryName, value);
			}
		}
		[Category("contactAddress")]
		public ObservableCollection<String> deliveryPoint  { get; set; } = new ();
		private String? _postalCode  = default;

		public String? postalCode {
			get {
				return _postalCode;
			}
			set {
				SetValue(ref _postalCode, value);
			}
		}


		public contactAddressViewModel Load(contactAddress instance) {
			administrativeDivision = instance.administrativeDivision;
			cityName = instance.cityName;
			countryName = instance.countryName;
			deliveryPoint.Clear();
			if (instance.deliveryPoint is not null) {
				foreach(var e in instance.deliveryPoint)
					deliveryPoint.Add(e);
			}
			postalCode = instance.postalCode;
			return this;
		}

		public override string Serialize() {
			var instance = new contactAddress {
				administrativeDivision = this.administrativeDivision,
				cityName = this.cityName,
				countryName = this.countryName,
				deliveryPoint = this.deliveryPoint.ToList(),
				postalCode = this.postalCode,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public contactAddress Model => new () {
			administrativeDivision = this._administrativeDivision,
			cityName = this._cityName,
			countryName = this._countryName,
			deliveryPoint = this.deliveryPoint.ToList(),
			postalCode = this._postalCode,
		};

		public override string? ToString() => $"Contact Address";

		public contactAddressViewModel() : base() {
			deliveryPoint.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(deliveryPoint));
			};
		}
	}
	/// <summary>
	/// User specified paper size width x, height y
	/// </summary>
	[CategoryOrder("customPaperSize",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class customPaperSizeViewModel : ViewModelBase {
		private decimal _paperWidth ;

		public decimal paperWidth {
			get {
				return _paperWidth;
			}
			set {
				SetValue(ref _paperWidth, value);
			}
		}
		private decimal _paperLength ;

		public decimal paperLength {
			get {
				return _paperLength;
			}
			set {
				SetValue(ref _paperLength, value);
			}
		}


		public customPaperSizeViewModel Load(customPaperSize instance) {
			paperWidth = instance.paperWidth;
			paperLength = instance.paperLength;
			return this;
		}

		public override string Serialize() {
			var instance = new customPaperSize {
				paperWidth = this.paperWidth,
				paperLength = this.paperLength,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public customPaperSize Model => new () {
			paperWidth = this._paperWidth,
			paperLength = this._paperLength,
		};

		public override string? ToString() => $"Custom Paper Size";
	}
	/// <summary>
	/// Locale of an option that is selected automatically unless an alternative is specified.
	/// </summary>
	[CategoryOrder("defaultLocale",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class defaultLocaleViewModel : ViewModelBase {
		private String _characterEncoding  = string.Empty;

		public String characterEncoding {
			get {
				return _characterEncoding;
			}
			set {
				SetValue(ref _characterEncoding, value);
			}
		}
		private String _countryName  = string.Empty;

		public String countryName {
			get {
				return _countryName;
			}
			set {
				SetValue(ref _countryName, value);
			}
		}
		private String? _language  = default;

		public String? language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}


		public defaultLocaleViewModel Load(defaultLocale instance) {
			characterEncoding = instance.characterEncoding;
			countryName = instance.countryName;
			language = instance.language;
			return this;
		}

		public override string Serialize() {
			var instance = new defaultLocale {
				characterEncoding = this.characterEncoding,
				countryName = this.countryName,
				language = this.language,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public defaultLocale Model => new () {
			characterEncoding = this._characterEncoding,
			countryName = this._countryName,
			language = this._language,
		};

		public override string? ToString() => $"Default Locale";
	}
	/// <summary>
	/// Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.
	/// </summary>
	[CategoryOrder("featureName",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class featureNameViewModel : ViewModelBase {
		private String? _language  = default;

		public String? language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}
		private String _name  = string.Empty;

		public String name {
			get {
				return _name;
			}
			set {
				SetValue(ref _name, value);
			}
		}
		private nameUsage? _nameUsage  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(nameUsageList), typeof(nameUsage))]
		public nameUsage? nameUsage {
			get {
				return _nameUsage;
			}
			set {
				SetValue(ref _nameUsage, value);
			}
		}

		[Browsable(false)]
		public nameUsage[] nameUsageList => Enum.GetValues<nameUsage>();


		public featureNameViewModel Load(featureName instance) {
			language = instance.language;
			name = instance.name;
			nameUsage = instance.nameUsage;
			return this;
		}

		public override string Serialize() {
			var instance = new featureName {
				language = this.language,
				name = this.name,
				nameUsage = this.nameUsage,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public featureName Model => new () {
			language = this._language,
			name = this._name,
			nameUsage = this._nameUsage,
		};

		public override string? ToString() => $"Feature Name";
	}
	/// <summary>
	/// Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.
	/// </summary>
	[CategoryOrder("information",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class informationViewModel : ViewModelBase {
		private String? _fileLocator  = default;

		public String? fileLocator {
			get {
				return _fileLocator;
			}
			set {
				SetValue(ref _fileLocator, value);
			}
		}
		private String? _fileReference  = default;

		public String? fileReference {
			get {
				return _fileReference;
			}
			set {
				SetValue(ref _fileReference, value);
			}
		}
		private String? _headline  = default;

		public String? headline {
			get {
				return _headline;
			}
			set {
				SetValue(ref _headline, value);
			}
		}
		private String? _language  = default;

		public String? language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}
		[Category("information")]
		public ObservableCollection<String> text  { get; set; } = new ();


		public informationViewModel Load(information instance) {
			fileLocator = instance.fileLocator;
			fileReference = instance.fileReference;
			headline = instance.headline;
			language = instance.language;
			text.Clear();
			if (instance.text is not null) {
				foreach(var e in instance.text)
					text.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new information {
				fileLocator = this.fileLocator,
				fileReference = this.fileReference,
				headline = this.headline,
				language = this.language,
				text = this.text.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public information Model => new () {
			fileLocator = this._fileLocator,
			fileReference = this._fileReference,
			headline = this._headline,
			language = this._language,
			text = this.text.ToList(),
		};

		public override string? ToString() => $"Information";

		public informationViewModel() : base() {
			text.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(text));
			};
		}
	}
	/// <summary>
	/// The cycle of issuing a product or service.
	/// </summary>
	[CategoryOrder("issuanceCycle",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class issuanceCycleViewModel : ViewModelBase {
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("issuanceCycle")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		private timeIntervalOfCycleViewModel? _timeIntervalOfCycle  = default;

		[Category("issuanceCycle")]
		[ExpandableObject]
		public timeIntervalOfCycleViewModel? timeIntervalOfCycle {
			get {
				return _timeIntervalOfCycle;
			}
			set {
				SetValue(ref _timeIntervalOfCycle, value);
			}
		}


		public issuanceCycleViewModel Load(issuanceCycle instance) {
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			timeIntervalOfCycle = new ();
			if (instance.timeIntervalOfCycle != default) {
				timeIntervalOfCycle.Load(instance.timeIntervalOfCycle);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new issuanceCycle {
				periodicDateRange = this.periodicDateRange?.Model,
				timeIntervalOfCycle = this.timeIntervalOfCycle?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public issuanceCycle Model => new () {
			periodicDateRange = this._periodicDateRange?.Model,
			timeIntervalOfCycle = this._timeIntervalOfCycle?.Model,
		};

		public override string? ToString() => $"Issuance Cycle";
	}
	/// <summary>
	/// Information about online sources from which a resource or data can be obtained.
	/// </summary>
	[CategoryOrder("onlineResource",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class onlineResourceViewModel : ViewModelBase {
		private String? _applicationProfile  = default;

		public String? applicationProfile {
			get {
				return _applicationProfile;
			}
			set {
				SetValue(ref _applicationProfile, value);
			}
		}
		private String _linkage  = string.Empty;

		public String linkage {
			get {
				return _linkage;
			}
			set {
				SetValue(ref _linkage, value);
			}
		}
		private String? _nameOfResource  = default;

		public String? nameOfResource {
			get {
				return _nameOfResource;
			}
			set {
				SetValue(ref _nameOfResource, value);
			}
		}
		private String? _onlineDescription  = default;

		public String? onlineDescription {
			get {
				return _onlineDescription;
			}
			set {
				SetValue(ref _onlineDescription, value);
			}
		}
		private String? _protocol  = default;

		public String? protocol {
			get {
				return _protocol;
			}
			set {
				SetValue(ref _protocol, value);
			}
		}
		private String? _protocolRequest  = default;

		public String? protocolRequest {
			get {
				return _protocolRequest;
			}
			set {
				SetValue(ref _protocolRequest, value);
			}
		}


		public onlineResourceViewModel Load(onlineResource instance) {
			applicationProfile = instance.applicationProfile;
			linkage = instance.linkage;
			nameOfResource = instance.nameOfResource;
			onlineDescription = instance.onlineDescription;
			protocol = instance.protocol;
			protocolRequest = instance.protocolRequest;
			return this;
		}

		public override string Serialize() {
			var instance = new onlineResource {
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
		public onlineResource Model => new () {
			applicationProfile = this._applicationProfile,
			linkage = this._linkage,
			nameOfResource = this._nameOfResource,
			onlineDescription = this._onlineDescription,
			protocol = this._protocol,
			protocolRequest = this._protocolRequest,
		};

		public override string? ToString() => $"Online Resource";
	}
	/// <summary>
	/// The active period of a recurring event or occurrence.
	/// </summary>
	[CategoryOrder("periodicDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class periodicDateRangeViewModel : ViewModelBase {
		private String _dateEnd ;

		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		public String dateEnd {
			get {
				return _dateEnd;
			}
			set {
				SetValue(ref _dateEnd, value);
			}
		}
		private String _dateStart ;

		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		public String dateStart {
			get {
				return _dateStart;
			}
			set {
				SetValue(ref _dateStart, value);
			}
		}


		public periodicDateRangeViewModel Load(periodicDateRange instance) {
			dateEnd = instance.dateEnd;
			dateStart = instance.dateStart;
			return this;
		}

		public override string Serialize() {
			var instance = new periodicDateRange {
				dateEnd = this.dateEnd,
				dateStart = this.dateStart,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public periodicDateRange Model => new () {
			dateEnd = this._dateEnd,
			dateStart = this._dateStart,
		};

		public override string? ToString() => $"Periodic Date Range";
	}
	/// <summary>
	/// A decision or establishment of a price.
	/// </summary>
	[CategoryOrder("pricing",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class pricingViewModel : ViewModelBase {
		private String? _contractPeriod  = default;

		public String? contractPeriod {
			get {
				return _contractPeriod;
			}
			set {
				SetValue(ref _contractPeriod, value);
			}
		}
		private String _currency  = string.Empty;

		public String currency {
			get {
				return _currency;
			}
			set {
				SetValue(ref _currency, value);
			}
		}
		private decimal _price ;

		public decimal price {
			get {
				return _price;
			}
			set {
				SetValue(ref _price, value);
			}
		}


		public pricingViewModel Load(pricing instance) {
			contractPeriod = instance.contractPeriod;
			currency = instance.currency;
			price = instance.price;
			return this;
		}

		public override string Serialize() {
			var instance = new pricing {
				contractPeriod = this.contractPeriod,
				currency = this.currency,
				price = this.price,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public pricing Model => new () {
			contractPeriod = this._contractPeriod,
			currency = this._currency,
			price = this._price,
		};

		public override string? ToString() => $"Pricing";
	}
	/// <summary>
	/// Information on the printing of nautical paper charts.
	/// </summary>
	[CategoryOrder("printInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class printInformationViewModel : ViewModelBase {
		private String? _printAgency  = default;

		public String? printAgency {
			get {
				return _printAgency;
			}
			set {
				SetValue(ref _printAgency, value);
			}
		}
		private String? _printNation  = default;

		public String? printNation {
			get {
				return _printNation;
			}
			set {
				SetValue(ref _printNation, value);
			}
		}
		private String? _reprintEdition  = default;

		public String? reprintEdition {
			get {
				return _reprintEdition;
			}
			set {
				SetValue(ref _reprintEdition, value);
			}
		}
		private String? _reprintNation  = default;

		public String? reprintNation {
			get {
				return _reprintNation;
			}
			set {
				SetValue(ref _reprintNation, value);
			}
		}
		private printSizeViewModel _printSize ;

		[Category("printInformation")]
		[ExpandableObject]
		public printSizeViewModel printSize {
			get {
				return _printSize;
			}
			set {
				SetValue(ref _printSize, value);
			}
		}


		public printInformationViewModel Load(printInformation instance) {
			printAgency = instance.printAgency;
			printNation = instance.printNation;
			reprintEdition = instance.reprintEdition;
			reprintNation = instance.reprintNation;
			printSize = new ();
			if (instance.printSize != default) {
				printSize.Load(instance.printSize);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new printInformation {
				printAgency = this.printAgency,
				printNation = this.printNation,
				reprintEdition = this.reprintEdition,
				reprintNation = this.reprintNation,
				printSize = this.printSize?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public printInformation Model => new () {
			printAgency = this._printAgency,
			printNation = this._printNation,
			reprintEdition = this._reprintEdition,
			reprintNation = this._reprintNation,
			printSize = this._printSize?.Model,
		};

		public override string? ToString() => $"Print Information";
	}
	/// <summary>
	/// Size of nautical paper charts.
	/// </summary>
	[CategoryOrder("printSize",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class printSizeViewModel : ViewModelBase {
		private iSO216? _iSO216  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(iSO216List), typeof(iSO216))]
		public iSO216? iSO216 {
			get {
				return _iSO216;
			}
			set {
				SetValue(ref _iSO216, value);
			}
		}

		[Browsable(false)]
		public iSO216[] iSO216List => [(iSO216)1,(iSO216)2,(iSO216)3,(iSO216)4,(iSO216)5,(iSO216)6,(iSO216)7,(iSO216)8];
		private customPaperSizeViewModel? _customPaperSize  = default;

		[Category("printSize")]
		[ExpandableObject]
		public customPaperSizeViewModel? customPaperSize {
			get {
				return _customPaperSize;
			}
			set {
				SetValue(ref _customPaperSize, value);
			}
		}


		public printSizeViewModel Load(printSize instance) {
			iSO216 = instance.iSO216;
			customPaperSize = new ();
			if (instance.customPaperSize != default) {
				customPaperSize.Load(instance.customPaperSize);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new printSize {
				iSO216 = this.iSO216,
				customPaperSize = this.customPaperSize?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public printSize Model => new () {
			iSO216 = this._iSO216,
			customPaperSize = this._customPaperSize?.Model,
		};

		public override string? ToString() => $"Print Size";
	}
	/// <summary>
	/// The name of the product specification to which a nautical product adheres.
	/// </summary>
	[CategoryOrder("productSpecification",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class productSpecificationViewModel : ViewModelBase {
		private DateOnly _editionDate ;

		public DateOnly editionDate {
			get {
				return _editionDate;
			}
			set {
				SetValue(ref _editionDate, value);
			}
		}
		private String? _iSSN  = default;

		public String? iSSN {
			get {
				return _iSSN;
			}
			set {
				SetValue(ref _iSSN, value);
			}
		}
		private String _name  = string.Empty;

		public String name {
			get {
				return _name;
			}
			set {
				SetValue(ref _name, value);
			}
		}
		private String _version  = string.Empty;

		public String version {
			get {
				return _version;
			}
			set {
				SetValue(ref _version, value);
			}
		}


		public productSpecificationViewModel Load(productSpecification instance) {
			editionDate = instance.editionDate;
			iSSN = instance.iSSN;
			name = instance.name;
			version = instance.version;
			return this;
		}

		public override string Serialize() {
			var instance = new productSpecification {
				editionDate = this.editionDate,
				iSSN = this.iSSN,
				name = this.name,
				version = this.version,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public productSpecification Model => new () {
			editionDate = this._editionDate,
			iSSN = this._iSSN,
			name = this._name,
			version = this._version,
		};

		public override string? ToString() => $"Product Specification";
	}
	/// <summary>
	/// Information on additional files used in addition to nautical products.
	/// </summary>
	[CategoryOrder("supportFile",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class supportFileViewModel : ViewModelBase {
		private String? _comment  = default;

		public String? comment {
			get {
				return _comment;
			}
			set {
				SetValue(ref _comment, value);
			}
		}
		private digitalSignatureReference _digitalSignatureReference ;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(digitalSignatureReferenceList), typeof(digitalSignatureReference))]
		public digitalSignatureReference digitalSignatureReference {
			get {
				return _digitalSignatureReference;
			}
			set {
				SetValue(ref _digitalSignatureReference, value);
			}
		}

		[Browsable(false)]
		public digitalSignatureReference[] digitalSignatureReferenceList => [(digitalSignatureReference)8];
		private digitalSignatureValue? _digitalSignatureValue  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(digitalSignatureValueList), typeof(digitalSignatureValue))]
		public digitalSignatureValue? digitalSignatureValue {
			get {
				return _digitalSignatureValue;
			}
			set {
				SetValue(ref _digitalSignatureValue, value);
			}
		}

		[Browsable(false)]
		public digitalSignatureValue[] digitalSignatureValueList => [(digitalSignatureValue)1,(digitalSignatureValue)2];
		private int? _editionNumber  = default;

		public int? editionNumber {
			get {
				return _editionNumber;
			}
			set {
				SetValue(ref _editionNumber, value);
			}
		}
		private String _fileLocator  = string.Empty;

		public String fileLocator {
			get {
				return _fileLocator;
			}
			set {
				SetValue(ref _fileLocator, value);
			}
		}
		private String _fileName  = string.Empty;

		public String fileName {
			get {
				return _fileName;
			}
			set {
				SetValue(ref _fileName, value);
			}
		}
		private DateOnly? _issueDate  = default;

		public DateOnly? issueDate {
			get {
				return _issueDate;
			}
			set {
				SetValue(ref _issueDate, value);
			}
		}
		private String? _otherDataTypeDescription  = default;

		public String? otherDataTypeDescription {
			get {
				return _otherDataTypeDescription;
			}
			set {
				SetValue(ref _otherDataTypeDescription, value);
			}
		}
		private supportFileFormat _supportFileFormat ;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(supportFileFormatList), typeof(supportFileFormat))]
		public supportFileFormat supportFileFormat {
			get {
				return _supportFileFormat;
			}
			set {
				SetValue(ref _supportFileFormat, value);
			}
		}

		[Browsable(false)]
		public supportFileFormat[] supportFileFormatList => [(supportFileFormat)1,(supportFileFormat)2,(supportFileFormat)3,(supportFileFormat)4,(supportFileFormat)5,(supportFileFormat)6,(supportFileFormat)7,(supportFileFormat)8,(supportFileFormat)9,(supportFileFormat)100];
		private supportFilePurpose _supportFilePurpose ;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(supportFilePurposeList), typeof(supportFilePurpose))]
		public supportFilePurpose supportFilePurpose {
			get {
				return _supportFilePurpose;
			}
			set {
				SetValue(ref _supportFilePurpose, value);
			}
		}

		[Browsable(false)]
		public supportFilePurpose[] supportFilePurposeList => [(supportFilePurpose)1,(supportFilePurpose)2,(supportFilePurpose)3];
		private defaultLocaleViewModel _defaultLocale ;

		[Category("supportFile")]
		[ExpandableObject]
		public defaultLocaleViewModel defaultLocale {
			get {
				return _defaultLocale;
			}
			set {
				SetValue(ref _defaultLocale, value);
			}
		}
		private supportFileSpecificationViewModel _supportFileSpecification ;

		[Category("supportFile")]
		[ExpandableObject]
		public supportFileSpecificationViewModel supportFileSpecification {
			get {
				return _supportFileSpecification;
			}
			set {
				SetValue(ref _supportFileSpecification, value);
			}
		}


		public supportFileViewModel Load(supportFile instance) {
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
			defaultLocale = new ();
			if (instance.defaultLocale != default) {
				defaultLocale.Load(instance.defaultLocale);
			}
			supportFileSpecification = new ();
			if (instance.supportFileSpecification != default) {
				supportFileSpecification.Load(instance.supportFileSpecification);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new supportFile {
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
		public supportFile Model => new () {
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

		public override string? ToString() => $"Support File";
	}
	/// <summary>
	/// The name of the product specification to which a support file adheres.
	/// </summary>
	[CategoryOrder("supportFileSpecification",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class supportFileSpecificationViewModel : ViewModelBase {
		private DateOnly _editionDate ;

		public DateOnly editionDate {
			get {
				return _editionDate;
			}
			set {
				SetValue(ref _editionDate, value);
			}
		}
		private String _name  = string.Empty;

		public String name {
			get {
				return _name;
			}
			set {
				SetValue(ref _name, value);
			}
		}
		private String _version  = string.Empty;

		public String version {
			get {
				return _version;
			}
			set {
				SetValue(ref _version, value);
			}
		}


		public supportFileSpecificationViewModel Load(supportFileSpecification instance) {
			editionDate = instance.editionDate;
			name = instance.name;
			version = instance.version;
			return this;
		}

		public override string Serialize() {
			var instance = new supportFileSpecification {
				editionDate = this.editionDate,
				name = this.name,
				version = this.version,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public supportFileSpecification Model => new () {
			editionDate = this._editionDate,
			name = this._name,
			version = this._version,
		};

		public override string? ToString() => $"Support File Specification";
	}
	/// <summary>
	/// The name of the (product) specification to which a nautical service adheres.
	/// </summary>
	[CategoryOrder("serviceSpecification",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class serviceSpecificationViewModel : ViewModelBase {
		private DateOnly _editionDate ;

		public DateOnly editionDate {
			get {
				return _editionDate;
			}
			set {
				SetValue(ref _editionDate, value);
			}
		}
		private String _name  = string.Empty;

		public String name {
			get {
				return _name;
			}
			set {
				SetValue(ref _name, value);
			}
		}
		private String _version  = string.Empty;

		public String version {
			get {
				return _version;
			}
			set {
				SetValue(ref _version, value);
			}
		}


		public serviceSpecificationViewModel Load(serviceSpecification instance) {
			editionDate = instance.editionDate;
			name = instance.name;
			version = instance.version;
			return this;
		}

		public override string Serialize() {
			var instance = new serviceSpecification {
				editionDate = this.editionDate,
				name = this.name,
				version = this.version,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public serviceSpecification Model => new () {
			editionDate = this._editionDate,
			name = this._name,
			version = this._version,
		};

		public override string? ToString() => $"Service Specification";
	}
	/// <summary>
	/// Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.
	/// </summary>
	[CategoryOrder("sourceIndication",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sourceIndicationViewModel : ViewModelBase {
		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfAuthorityList), typeof(categoryOfAuthority))]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		[Browsable(false)]
		public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2,(categoryOfAuthority)3,(categoryOfAuthority)4,(categoryOfAuthority)5,(categoryOfAuthority)6,(categoryOfAuthority)7,(categoryOfAuthority)8,(categoryOfAuthority)9,(categoryOfAuthority)10,(categoryOfAuthority)11,(categoryOfAuthority)12,(categoryOfAuthority)13,(categoryOfAuthority)14,(categoryOfAuthority)15,(categoryOfAuthority)16,(categoryOfAuthority)17,(categoryOfAuthority)18,(categoryOfAuthority)19];
		private String? _countryName  = default;

		public String? countryName {
			get {
				return _countryName;
			}
			set {
				SetValue(ref _countryName, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private String? _source  = default;

		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private sourceType? _sourceType  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
		public sourceType? sourceType {
			get {
				return _sourceType;
			}
			set {
				SetValue(ref _sourceType, value);
			}
		}

		[Browsable(false)]
		public sourceType[] sourceTypeList => [(sourceType)1,(sourceType)2,(sourceType)7,(sourceType)8,(sourceType)9,(sourceType)10,(sourceType)11,(sourceType)12,(sourceType)13,(sourceType)14,(sourceType)15];
		[Category("sourceIndication")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();


		public sourceIndicationViewModel Load(sourceIndication instance) {
			categoryOfAuthority = instance.categoryOfAuthority;
			countryName = instance.countryName;
			reportedDate = instance.reportedDate;
			source = instance.source;
			sourceType = instance.sourceType;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new sourceIndication {
				categoryOfAuthority = this.categoryOfAuthority,
				countryName = this.countryName,
				reportedDate = this.reportedDate,
				source = this.source,
				sourceType = this.sourceType,
				featureName = this.featureName.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public sourceIndication Model => new () {
			categoryOfAuthority = this._categoryOfAuthority,
			countryName = this._countryName,
			reportedDate = this._reportedDate,
			source = this._source,
			sourceType = this._sourceType,
			featureName = this.featureName.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"Source Indication";

		public sourceIndicationViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}
	/// <summary>
	/// A means or channel of communicating at a distance by electrical or electromagnetic means such as telegraphy, telephony, or broadcasting.
	/// </summary>
	[CategoryOrder("telecommunications",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class telecommunicationsViewModel : ViewModelBase {
		private String _contactInstructions  = string.Empty;

		public String contactInstructions {
			get {
				return _contactInstructions;
			}
			set {
				SetValue(ref _contactInstructions, value);
			}
		}
		private String _telecommunicationIdentifier  = string.Empty;

		public String telecommunicationIdentifier {
			get {
				return _telecommunicationIdentifier;
			}
			set {
				SetValue(ref _telecommunicationIdentifier, value);
			}
		}
		[Category("telecommunications")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(telecommunicationServiceList), typeof(telecommunicationService))]
		public ObservableCollection<telecommunicationService> telecommunicationService  { get; set; } = new ();

		[Browsable(false)]
		public telecommunicationService[] telecommunicationServiceList => [(telecommunicationService)1,(telecommunicationService)2,(telecommunicationService)3,(telecommunicationService)4,(telecommunicationService)5,(telecommunicationService)6,(telecommunicationService)7,(telecommunicationService)8];


		public telecommunicationsViewModel Load(telecommunications instance) {
			contactInstructions = instance.contactInstructions;
			telecommunicationIdentifier = instance.telecommunicationIdentifier;
			telecommunicationService.Clear();
			if (instance.telecommunicationService is not null) {
				foreach(var e in instance.telecommunicationService)
					telecommunicationService.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new telecommunications {
				contactInstructions = this.contactInstructions,
				telecommunicationIdentifier = this.telecommunicationIdentifier,
				telecommunicationService = this.telecommunicationService.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public telecommunications Model => new () {
			contactInstructions = this._contactInstructions,
			telecommunicationIdentifier = this._telecommunicationIdentifier,
			telecommunicationService = this.telecommunicationService.ToList(),
		};

		public override string? ToString() => $"Telecommunications";

		public telecommunicationsViewModel() : base() {
			telecommunicationService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(telecommunicationService));
			};
		}
	}
	/// <summary>
	/// The temporal interval over which the product is updated or renewed.
	/// </summary>
	[CategoryOrder("timeIntervalOfProduct",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class timeIntervalOfProductViewModel : ViewModelBase {
		private DateOnly? _expirationDate  = default;

		public DateOnly? expirationDate {
			get {
				return _expirationDate;
			}
			set {
				SetValue(ref _expirationDate, value);
			}
		}
		private DateOnly _issueDate ;

		public DateOnly issueDate {
			get {
				return _issueDate;
			}
			set {
				SetValue(ref _issueDate, value);
			}
		}
		private issuanceCycleViewModel? _issuanceCycle  = default;

		[Category("timeIntervalOfProduct")]
		[ExpandableObject]
		public issuanceCycleViewModel? issuanceCycle {
			get {
				return _issuanceCycle;
			}
			set {
				SetValue(ref _issuanceCycle, value);
			}
		}


		public timeIntervalOfProductViewModel Load(timeIntervalOfProduct instance) {
			expirationDate = instance.expirationDate;
			issueDate = instance.issueDate;
			issuanceCycle = new ();
			if (instance.issuanceCycle != default) {
				issuanceCycle.Load(instance.issuanceCycle);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new timeIntervalOfProduct {
				expirationDate = this.expirationDate,
				issueDate = this.issueDate,
				issuanceCycle = this.issuanceCycle?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public timeIntervalOfProduct Model => new () {
			expirationDate = this._expirationDate,
			issueDate = this._issueDate,
			issuanceCycle = this._issuanceCycle?.Model,
		};

		public override string? ToString() => $"Time Interval Of Product";
	}
	/// <summary>
	/// The temporal interval of the cycle over which data is produced.
	/// </summary>
	[CategoryOrder("timeIntervalOfCycle",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class timeIntervalOfCycleViewModel : ViewModelBase {
		[Category("timeIntervalOfCycle")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(typeOfTimeIntervalUnitList), typeof(typeOfTimeIntervalUnit))]
		public ObservableCollection<typeOfTimeIntervalUnit> typeOfTimeIntervalUnit  { get; set; } = new ();

		[Browsable(false)]
		public typeOfTimeIntervalUnit[] typeOfTimeIntervalUnitList => [(typeOfTimeIntervalUnit)1,(typeOfTimeIntervalUnit)2,(typeOfTimeIntervalUnit)3,(typeOfTimeIntervalUnit)4];
		private int _valueOfTime ;

		public int valueOfTime {
			get {
				return _valueOfTime;
			}
			set {
				SetValue(ref _valueOfTime, value);
			}
		}


		public timeIntervalOfCycleViewModel Load(timeIntervalOfCycle instance) {
			typeOfTimeIntervalUnit.Clear();
			if (instance.typeOfTimeIntervalUnit is not null) {
				foreach(var e in instance.typeOfTimeIntervalUnit)
					typeOfTimeIntervalUnit.Add(e);
			}
			valueOfTime = instance.valueOfTime;
			return this;
		}

		public override string Serialize() {
			var instance = new timeIntervalOfCycle {
				typeOfTimeIntervalUnit = this.typeOfTimeIntervalUnit.ToList(),
				valueOfTime = this.valueOfTime,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public timeIntervalOfCycle Model => new () {
			typeOfTimeIntervalUnit = this.typeOfTimeIntervalUnit.ToList(),
			valueOfTime = this._valueOfTime,
		};

		public override string? ToString() => $"Time Interval Of Cycle";

		public timeIntervalOfCycleViewModel() : base() {
			typeOfTimeIntervalUnit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(typeOfTimeIntervalUnit));
			};
		}
	}
	/// <summary>
	/// A reference to a of specific Notice to Mariners.
	/// </summary>
	[CategoryOrder("referenceToNM",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class referenceToNMViewModel : ViewModelBase {
		private DateOnly _publicationDate ;

		public DateOnly publicationDate {
			get {
				return _publicationDate;
			}
			set {
				SetValue(ref _publicationDate, value);
			}
		}
		private weekOfYearViewModel? _weekOfYear  = default;

		[Category("referenceToNM")]
		[ExpandableObject]
		public weekOfYearViewModel? weekOfYear {
			get {
				return _weekOfYear;
			}
			set {
				SetValue(ref _weekOfYear, value);
			}
		}


		public referenceToNMViewModel Load(referenceToNM instance) {
			publicationDate = instance.publicationDate;
			weekOfYear = new ();
			if (instance.weekOfYear != default) {
				weekOfYear.Load(instance.weekOfYear);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new referenceToNM {
				publicationDate = this.publicationDate,
				weekOfYear = this.weekOfYear?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public referenceToNM Model => new () {
			publicationDate = this._publicationDate,
			weekOfYear = this._weekOfYear?.Model,
		};

		public override string? ToString() => $"Reference To NM";
	}
	/// <summary>
	/// The indication of a specific week within a specific year.
	/// </summary>
	[CategoryOrder("weekOfYear",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class weekOfYearViewModel : ViewModelBase {
		private int _weekNumber ;

		public int weekNumber {
			get {
				return _weekNumber;
			}
			set {
				SetValue(ref _weekNumber, value);
			}
		}
		private int _yearNumber ;

		public int yearNumber {
			get {
				return _yearNumber;
			}
			set {
				SetValue(ref _yearNumber, value);
			}
		}


		public weekOfYearViewModel Load(weekOfYear instance) {
			weekNumber = instance.weekNumber;
			yearNumber = instance.yearNumber;
			return this;
		}

		public override string Serialize() {
			var instance = new weekOfYear {
				weekNumber = this.weekNumber,
				yearNumber = this.yearNumber,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public weekOfYear Model => new () {
			weekNumber = this._weekNumber,
			yearNumber = this._yearNumber,
		};

		public override string? ToString() => $"Week Of Year";
	}

	/// <summary>
	/// A carriage requirement required by SOLAS or other regulation.
	/// </summary>
	[CategoryOrder("CarriageRequirement",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CarriageRequirementViewModel : AssociationViewModel {


		public CarriageRequirementViewModel Load(CarriageRequirement instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new CarriageRequirement {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CarriageRequirement Model => new () {

		};

		public override string? ToString() => $"Carriage Requirement";
	}

	/// <summary>
	/// Details related to distribution.
	/// </summary>
	[CategoryOrder("DistributionDetails",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DistributionDetailsViewModel : AssociationViewModel {


		public DistributionDetailsViewModel Load(DistributionDetails instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new DistributionDetails {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DistributionDetails Model => new () {

		};

		public override string? ToString() => $"Distribution Details";
	}

	/// <summary>
	/// Contact information of distributor.
	/// </summary>
	[CategoryOrder("DistributorContact",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DistributorContactViewModel : AssociationViewModel {


		public DistributorContactViewModel Load(DistributorContact instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new DistributorContact {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DistributorContact Model => new () {

		};

		public override string? ToString() => $"Distributor Contact";
	}

	/// <summary>
	/// An association of price information to a catalogue element.
	/// </summary>
	[CategoryOrder("PriceOfElement",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PriceOfElementViewModel : AssociationViewModel {


		public PriceOfElementViewModel Load(PriceOfElement instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new PriceOfElement {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PriceOfElement Model => new () {

		};

		public override string? ToString() => $"Price of Element";
	}

	/// <summary>
	/// The price of a nautical product.
	/// </summary>
	[CategoryOrder("PriceOfNauticalProduct",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PriceOfNauticalProductViewModel : AssociationViewModel {


		public PriceOfNauticalProductViewModel Load(PriceOfNauticalProduct instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new PriceOfNauticalProduct {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PriceOfNauticalProduct Model => new () {

		};

		public override string? ToString() => $"Price of Nautical Product";
	}

	/// <summary>
	/// Contact information of producer.
	/// </summary>
	[CategoryOrder("ProducerContact",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ProducerContactViewModel : AssociationViewModel {


		public ProducerContactViewModel Load(ProducerContact instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new ProducerContact {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ProducerContact Model => new () {

		};

		public override string? ToString() => $"Producer Contact";
	}

	/// <summary>
	/// Contact information of a producing organization.
	/// </summary>
	[CategoryOrder("ProductionDetails",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ProductionDetailsViewModel : AssociationViewModel {


		public ProductionDetailsViewModel Load(ProductionDetails instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new ProductionDetails {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ProductionDetails Model => new () {

		};

		public override string? ToString() => $"Production Details";
	}

	/// <summary>
	/// A package or distinct set of products.
	/// </summary>
	[CategoryOrder("ProductPackage",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ProductPackageViewModel : AssociationViewModel {


		public ProductPackageViewModel Load(ProductPackage instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new ProductPackage {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ProductPackage Model => new () {

		};

		public override string? ToString() => $"Product Package";
	}

	/// <summary>
	/// Mapping between traditional products and S-100 Products.
	/// </summary>
	[CategoryOrder("ProductMapping",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ProductMappingViewModel : AssociationViewModel {
		private categoryOfProductMapping _categoryOfProductMapping ;

		[Category("ProductMapping")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfProductMappingList), typeof(categoryOfProductMapping))]
		public categoryOfProductMapping categoryOfProductMapping {
			get {
				return _categoryOfProductMapping;
			}
			set {
				SetValue(ref _categoryOfProductMapping, value);
			}
		}

		[Browsable(false)]
		public categoryOfProductMapping[] categoryOfProductMappingList => [(categoryOfProductMapping)1,(categoryOfProductMapping)2,(categoryOfProductMapping)3,(categoryOfProductMapping)4];


		public ProductMappingViewModel Load(ProductMapping instance) {
			categoryOfProductMapping = instance.categoryOfProductMapping;
			return this;
		}

		public override string Serialize() {
			var instance = new ProductMapping {
				categoryOfProductMapping = this.categoryOfProductMapping,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ProductMapping Model => new () {
			categoryOfProductMapping = this._categoryOfProductMapping,
		};

		public override string? ToString() => $"Product Mapping";
	}

	/// <summary>
	/// A supplementary or secondary part of the product, which may appear multiple times, offering control or display functionalities depending on its configuration.
			
	/// </summary>
	[CategoryOrder("Correlated",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CorrelatedViewModel : AssociationViewModel {


		public CorrelatedViewModel Load(Correlated instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new Correlated {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Correlated Model => new () {

		};

		public override string? ToString() => $"Correlated";
	}

	/// <summary>
	/// A header identifying a section within a catalogue.
	/// </summary>
	[CategoryOrder("CatalogueSectionHeader",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CatalogueSectionHeaderViewModel : InformationViewModel<CatalogueSectionHeader> {
		private int _catalogueSectionNumber ;

		[Category("CatalogueSectionHeader")]
		public int catalogueSectionNumber {
			get {
				return _catalogueSectionNumber;
			}
			set {
				SetValue(ref _catalogueSectionNumber, value);
			}
		}
		private String? _catalogueSectionTitle  = default;

		[Category("CatalogueSectionHeader")]
		public String? catalogueSectionTitle {
			get {
				return _catalogueSectionTitle;
			}
			set {
				SetValue(ref _catalogueSectionTitle, value);
			}
		}
		private informationViewModel? _information  = default;

		[Category("CatalogueSectionHeader")]
		[ExpandableObject]
		public informationViewModel? information {
			get {
				return _information;
			}
			set {
				SetValue(ref _information, value);
			}
		}


		public override InformationViewModel<CatalogueSectionHeader> Load(CatalogueSectionHeader instance) {
			catalogueSectionNumber = instance.catalogueSectionNumber;
			catalogueSectionTitle = instance.catalogueSectionTitle;
			information = new ();
			if (instance.information != default) {
				information.Load(instance.information);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new CatalogueSectionHeader {
				catalogueSectionNumber = this.catalogueSectionNumber,
				catalogueSectionTitle = this.catalogueSectionTitle,
				information = this.information?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CatalogueSectionHeader Model => new () {
			catalogueSectionNumber = this._catalogueSectionNumber,
			catalogueSectionTitle = this._catalogueSectionTitle,
			information = this._information?.Model,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => CatalogueSectionHeader._informationBindingDefinitions;

		public override string? ToString() => $"Catalogue Section Header";
	}

	/// <summary>
	/// Information on how to reach a person or organisation by postal, internet, telephone, telex and radio systems.
	/// </summary>
	[CategoryOrder("ContactDetails",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ContactDetailsViewModel : InformationViewModel<ContactDetails> {
		private String _contactInstructions  = string.Empty;

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
		public ObservableCollection<contactAddressViewModel> contactAddress  { get; set; } = new ();
		[Category("ContactDetails")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("ContactDetails")]
		public ObservableCollection<onlineResourceViewModel> onlineResource  { get; set; } = new ();
		[Category("ContactDetails")]
		public ObservableCollection<telecommunicationsViewModel> telecommunications  { get; set; } = new ();
		[Category("ContactDetails")]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();


		public override InformationViewModel<ContactDetails> Load(ContactDetails instance) {
			contactInstructions = instance.contactInstructions;
			contactAddress.Clear();
			if (instance.contactAddress is not null) {
				foreach(var e in instance.contactAddress)
					contactAddress.Add(new contactAddressViewModel().Load(e));
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			onlineResource.Clear();
			if (instance.onlineResource is not null) {
				foreach(var e in instance.onlineResource)
					onlineResource.Add(new onlineResourceViewModel().Load(e));
			}
			telecommunications.Clear();
			if (instance.telecommunications is not null) {
				foreach(var e in instance.telecommunications)
					telecommunications.Add(new telecommunicationsViewModel().Load(e));
			}
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new ContactDetails {
				contactInstructions = this.contactInstructions,
				contactAddress = this.contactAddress.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
				telecommunications = this.telecommunications.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ContactDetails Model => new () {
			contactInstructions = this._contactInstructions,
			contactAddress = this.contactAddress.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
			telecommunications = this.telecommunications.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => ContactDetails._informationBindingDefinitions;

		public override string? ToString() => $"Contact Details";

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
	}

	/// <summary>
	/// An indication of the type or justification of a carriage requirement.
	/// </summary>
	[CategoryOrder("IndicationOfCarriageRequirement",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class IndicationOfCarriageRequirementViewModel : InformationViewModel<IndicationOfCarriageRequirement> {
		private String? _domesticCarriageRequirements  = default;

		[Category("IndicationOfCarriageRequirement")]
		public String? domesticCarriageRequirements {
			get {
				return _domesticCarriageRequirements;
			}
			set {
				SetValue(ref _domesticCarriageRequirements, value);
			}
		}
		private String? _internationalCarriageRequirements  = default;

		[Category("IndicationOfCarriageRequirement")]
		public String? internationalCarriageRequirements {
			get {
				return _internationalCarriageRequirements;
			}
			set {
				SetValue(ref _internationalCarriageRequirements, value);
			}
		}
		[Category("IndicationOfCarriageRequirement")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();


		public override InformationViewModel<IndicationOfCarriageRequirement> Load(IndicationOfCarriageRequirement instance) {
			domesticCarriageRequirements = instance.domesticCarriageRequirements;
			internationalCarriageRequirements = instance.internationalCarriageRequirements;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new IndicationOfCarriageRequirement {
				domesticCarriageRequirements = this.domesticCarriageRequirements,
				internationalCarriageRequirements = this.internationalCarriageRequirements,
				featureName = this.featureName.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public IndicationOfCarriageRequirement Model => new () {
			domesticCarriageRequirements = this._domesticCarriageRequirements,
			internationalCarriageRequirements = this._internationalCarriageRequirements,
			featureName = this.featureName.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => IndicationOfCarriageRequirement._informationBindingDefinitions;

		public override string? ToString() => $"Indication of Carriage Requirement";

		public IndicationOfCarriageRequirementViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// Pricing information of nautical products.
	/// </summary>
	[CategoryOrder("PriceInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PriceInformationViewModel : InformationViewModel<PriceInformation> {
		[Category("PriceInformation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("PriceInformation")]
		public ObservableCollection<onlineResourceViewModel> onlineResource  { get; set; } = new ();
		[Category("PriceInformation")]
		public ObservableCollection<pricingViewModel> pricing  { get; set; } = new ();
		[Category("PriceInformation")]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();


		public override InformationViewModel<PriceInformation> Load(PriceInformation instance) {
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			onlineResource.Clear();
			if (instance.onlineResource is not null) {
				foreach(var e in instance.onlineResource)
					onlineResource.Add(new onlineResourceViewModel().Load(e));
			}
			pricing.Clear();
			if (instance.pricing is not null) {
				foreach(var e in instance.pricing)
					pricing.Add(new pricingViewModel().Load(e));
			}
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new PriceInformation {
				information = this.information.Select(e => e.Model).ToList(),
				onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
				pricing = this.pricing.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PriceInformation Model => new () {
			information = this.information.Select(e => e.Model).ToList(),
			onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
			pricing = this.pricing.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => PriceInformation._informationBindingDefinitions;

		public override string? ToString() => $"Price Information";

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
	}

	/// <summary>
	/// Information about the authority responsible for production.
	/// </summary>
	[CategoryOrder("ProducerInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ProducerInformationViewModel : InformationViewModel<ProducerInformation> {
		private String _agencyResponsibleForProduction  = string.Empty;

		[Category("ProducerInformation")]
		public String agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private String? _agencyName  = default;

		[Category("ProducerInformation")]
		public String? agencyName {
			get {
				return _agencyName;
			}
			set {
				SetValue(ref _agencyName, value);
			}
		}


		public override InformationViewModel<ProducerInformation> Load(ProducerInformation instance) {
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			agencyName = instance.agencyName;
			return this;
		}

		public override string Serialize() {
			var instance = new ProducerInformation {
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				agencyName = this.agencyName,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ProducerInformation Model => new () {
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			agencyName = this._agencyName,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => ProducerInformation._informationBindingDefinitions;

		public override string? ToString() => $"Producer Information";
	}

	/// <summary>
	/// Information related to a distributor.
	/// </summary>
	[CategoryOrder("DistributorInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DistributorInformationViewModel : InformationViewModel<DistributorInformation> {
		private String _distributorName  = string.Empty;

		[Category("DistributorInformation")]
		public String distributorName {
			get {
				return _distributorName;
			}
			set {
				SetValue(ref _distributorName, value);
			}
		}


		public override InformationViewModel<DistributorInformation> Load(DistributorInformation instance) {
			distributorName = instance.distributorName;
			return this;
		}

		public override string Serialize() {
			var instance = new DistributorInformation {
				distributorName = this.distributorName,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DistributorInformation Model => new () {
			distributorName = this._distributorName,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => DistributorInformation._informationBindingDefinitions;

		public override string? ToString() => $"Distributor Information";
	}

	/// <summary>
	/// Electronic navigation product.
	/// </summary>
	[CategoryOrder("ElectronicProduct",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ElectronicProductViewModel : FeatureViewModel<ElectronicProduct> {
		private String? _agencyResponsibleForProduction  = default;

		[Category("CatalogueElement")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		[Category("CatalogueElement")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(catalogueElementClassificationList), typeof(catalogueElementClassification))]
		public ObservableCollection<catalogueElementClassification> catalogueElementClassification  { get; set; } = new ();

		[Browsable(false)]
		public catalogueElementClassification[] catalogueElementClassificationList => Enum.GetValues<catalogueElementClassification>();
		private String? _catalogueElementIdentifier  = default;

		[Category("CatalogueElement")]
		public String? catalogueElementIdentifier {
			get {
				return _catalogueElementIdentifier;
			}
			set {
				SetValue(ref _catalogueElementIdentifier, value);
			}
		}
		private String? _classification  = default;

		[Category("CatalogueElement")]
		public String? classification {
			get {
				return _classification;
			}
			set {
				SetValue(ref _classification, value);
			}
		}
		[Category("CatalogueElement")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(iMOMaritimeServiceList), typeof(iMOMaritimeService))]
		public ObservableCollection<iMOMaritimeService> iMOMaritimeService  { get; set; } = new ();

		[Browsable(false)]
		public iMOMaritimeService[] iMOMaritimeServiceList => Enum.GetValues<iMOMaritimeService>();
		private Boolean _notForNavigation  = false;

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
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("CatalogueElement")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private onlineResourceViewModel? _onlineResource  = default;

		[Category("CatalogueElement")]
		[ExpandableObject]
		public onlineResourceViewModel? onlineResource {
			get {
				return _onlineResource;
			}
			set {
				SetValue(ref _onlineResource, value);
			}
		}
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("CatalogueElement")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		[Category("CatalogueElement")]
		public ObservableCollection<supportFileViewModel> supportFile  { get; set; } = new ();
		private timeIntervalOfProductViewModel? _timeIntervalOfProduct  = default;

		[Category("CatalogueElement")]
		[ExpandableObject]
		public timeIntervalOfProductViewModel? timeIntervalOfProduct {
			get {
				return _timeIntervalOfProduct;
			}
			set {
				SetValue(ref _timeIntervalOfProduct, value);
			}
		}

		[Category("NavigationalProduct")]
		public ObservableCollection<decimal> approximateGridResolution  { get; set; } = new ();
		[Category("NavigationalProduct")]
		public ObservableCollection<int> compilationScale  { get; set; } = new ();
		private distributionStatus? _distributionStatus  = default;

		[Category("NavigationalProduct")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(distributionStatusList), typeof(distributionStatus))]
		public distributionStatus? distributionStatus {
			get {
				return _distributionStatus;
			}
			set {
				SetValue(ref _distributionStatus, value);
			}
		}

		[Browsable(false)]
		public distributionStatus[] distributionStatusList => [(distributionStatus)1,(distributionStatus)2];
		private int? _editionNumber  = default;

		[Category("NavigationalProduct")]
		public int? editionNumber {
			get {
				return _editionNumber;
			}
			set {
				SetValue(ref _editionNumber, value);
			}
		}
		private int? _maximumDisplayScale  = default;

		[Category("NavigationalProduct")]
		public int? maximumDisplayScale {
			get {
				return _maximumDisplayScale;
			}
			set {
				SetValue(ref _maximumDisplayScale, value);
			}
		}
		private int? _minimumDisplayScale  = default;

		[Category("NavigationalProduct")]
		public int? minimumDisplayScale {
			get {
				return _minimumDisplayScale;
			}
			set {
				SetValue(ref _minimumDisplayScale, value);
			}
		}
		[Category("NavigationalProduct")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(navigationPurposeList), typeof(navigationPurpose))]
		public ObservableCollection<navigationPurpose> navigationPurpose  { get; set; } = new ();

		[Browsable(false)]
		public navigationPurpose[] navigationPurposeList => [(navigationPurpose)1,(navigationPurpose)2,(navigationPurpose)3];
		private String? _optimumDisplayScale  = default;

		[Category("NavigationalProduct")]
		public String? optimumDisplayScale {
			get {
				return _optimumDisplayScale;
			}
			set {
				SetValue(ref _optimumDisplayScale, value);
			}
		}
		private String? _originalProductNumber  = default;

		[Category("NavigationalProduct")]
		public String? originalProductNumber {
			get {
				return _originalProductNumber;
			}
			set {
				SetValue(ref _originalProductNumber, value);
			}
		}
		private String? _producerNation  = default;

		[Category("NavigationalProduct")]
		public String? producerNation {
			get {
				return _producerNation;
			}
			set {
				SetValue(ref _producerNation, value);
			}
		}
		private String? _productNumber  = default;

		[Category("NavigationalProduct")]
		public String? productNumber {
			get {
				return _productNumber;
			}
			set {
				SetValue(ref _productNumber, value);
			}
		}
		private specificUsage? _specificUsage  = default;

		[Category("NavigationalProduct")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(specificUsageList), typeof(specificUsage))]
		public specificUsage? specificUsage {
			get {
				return _specificUsage;
			}
			set {
				SetValue(ref _specificUsage, value);
			}
		}

		[Browsable(false)]
		public specificUsage[] specificUsageList => [(specificUsage)1,(specificUsage)2,(specificUsage)3,(specificUsage)4,(specificUsage)5,(specificUsage)6];
		private DateOnly? _updateDate  = default;

		[Category("NavigationalProduct")]
		public DateOnly? updateDate {
			get {
				return _updateDate;
			}
			set {
				SetValue(ref _updateDate, value);
			}
		}
		private int? _updateNumber  = default;

		[Category("NavigationalProduct")]
		public int? updateNumber {
			get {
				return _updateNumber;
			}
			set {
				SetValue(ref _updateNumber, value);
			}
		}
		private horizontalDatumEPSGCode? _horizontalDatumEPSGCode  = default;

		[Category("NavigationalProduct")]
		public horizontalDatumEPSGCode? horizontalDatumEPSGCode {
			get {
				return _horizontalDatumEPSGCode;
			}
			set {
				SetValue(ref _horizontalDatumEPSGCode, value);
			}
		}
		private verticalDatum? _verticalDatum  = default;

		[Category("NavigationalProduct")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(verticalDatumList), typeof(verticalDatum))]
		public verticalDatum? verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		[Browsable(false)]
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)42,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45];

		private Boolean? _compressionFlag  = default;

		[Category("ElectronicProduct")]
		public Boolean? compressionFlag {
			get {
				return _compressionFlag;
			}
			set {
				SetValue(ref _compressionFlag, value);
			}
		}
		private String? _datasetName  = default;

		[Category("ElectronicProduct")]
		public String? datasetName {
			get {
				return _datasetName;
			}
			set {
				SetValue(ref _datasetName, value);
			}
		}
		private DateOnly _issueDate ;

		[Category("ElectronicProduct")]
		public DateOnly issueDate {
			get {
				return _issueDate;
			}
			set {
				SetValue(ref _issueDate, value);
			}
		}
		private TimeOnly? _issueTime  = default;

		[Category("ElectronicProduct")]
		public TimeOnly? issueTime {
			get {
				return _issueTime;
			}
			set {
				SetValue(ref _issueTime, value);
			}
		}
		private typeOfProductFormat _typeOfProductFormat ;

		[Category("ElectronicProduct")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(typeOfProductFormatList), typeof(typeOfProductFormat))]
		public typeOfProductFormat typeOfProductFormat {
			get {
				return _typeOfProductFormat;
			}
			set {
				SetValue(ref _typeOfProductFormat, value);
			}
		}

		[Browsable(false)]
		public typeOfProductFormat[] typeOfProductFormatList => [(typeOfProductFormat)1,(typeOfProductFormat)2,(typeOfProductFormat)3,(typeOfProductFormat)4,(typeOfProductFormat)5,(typeOfProductFormat)6,(typeOfProductFormat)7,(typeOfProductFormat)8,(typeOfProductFormat)9,(typeOfProductFormat)10,(typeOfProductFormat)11,(typeOfProductFormat)12];
		private productSpecificationViewModel? _productSpecification  = default;

		[Category("ElectronicProduct")]
		[ExpandableObject]
		public productSpecificationViewModel? productSpecification {
			get {
				return _productSpecification;
			}
			set {
				SetValue(ref _productSpecification, value);
			}
		}


		public override FeatureViewModel<ElectronicProduct> Load(ElectronicProduct instance) {
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			catalogueElementClassification.Clear();
			if (instance.catalogueElementClassification is not null) {
				foreach(var e in instance.catalogueElementClassification)
					catalogueElementClassification.Add(e);
			}
			catalogueElementIdentifier = instance.catalogueElementIdentifier;
			classification = instance.classification;
			iMOMaritimeService.Clear();
			if (instance.iMOMaritimeService is not null) {
				foreach(var e in instance.iMOMaritimeService)
					iMOMaritimeService.Add(e);
			}
			notForNavigation = instance.notForNavigation;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			onlineResource = new ();
			if (instance.onlineResource != default) {
				onlineResource.Load(instance.onlineResource);
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			supportFile.Clear();
			if (instance.supportFile is not null) {
				foreach(var e in instance.supportFile)
					supportFile.Add(new supportFileViewModel().Load(e));
			}
			timeIntervalOfProduct = new ();
			if (instance.timeIntervalOfProduct != default) {
				timeIntervalOfProduct.Load(instance.timeIntervalOfProduct);
			}
			approximateGridResolution.Clear();
			if (instance.approximateGridResolution is not null) {
				foreach(var e in instance.approximateGridResolution)
					approximateGridResolution.Add(e);
			}
			compilationScale.Clear();
			if (instance.compilationScale is not null) {
				foreach(var e in instance.compilationScale)
					compilationScale.Add(e);
			}
			distributionStatus = instance.distributionStatus;
			editionNumber = instance.editionNumber;
			maximumDisplayScale = instance.maximumDisplayScale;
			minimumDisplayScale = instance.minimumDisplayScale;
			navigationPurpose.Clear();
			if (instance.navigationPurpose is not null) {
				foreach(var e in instance.navigationPurpose)
					navigationPurpose.Add(e);
			}
			optimumDisplayScale = instance.optimumDisplayScale;
			originalProductNumber = instance.originalProductNumber;
			producerNation = instance.producerNation;
			productNumber = instance.productNumber;
			specificUsage = instance.specificUsage;
			updateDate = instance.updateDate;
			updateNumber = instance.updateNumber;
			horizontalDatumEPSGCode = instance.horizontalDatumEPSGCode;
			verticalDatum = instance.verticalDatum;
			compressionFlag = instance.compressionFlag;
			datasetName = instance.datasetName;
			issueDate = instance.issueDate;
			issueTime = instance.issueTime;
			typeOfProductFormat = instance.typeOfProductFormat;
			productSpecification = new ();
			if (instance.productSpecification != default) {
				productSpecification.Load(instance.productSpecification);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new ElectronicProduct {
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				catalogueElementClassification = this.catalogueElementClassification.ToList(),
				catalogueElementIdentifier = this.catalogueElementIdentifier,
				classification = this.classification,
				iMOMaritimeService = this.iMOMaritimeService.ToList(),
				notForNavigation = this.notForNavigation,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				onlineResource = this.onlineResource?.Model,
				sourceIndication = this.sourceIndication?.Model,
				supportFile = this.supportFile.Select(e => e.Model).ToList(),
				timeIntervalOfProduct = this.timeIntervalOfProduct?.Model,
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
				horizontalDatumEPSGCode = this.horizontalDatumEPSGCode,
				verticalDatum = this.verticalDatum,
				compressionFlag = this.compressionFlag,
				datasetName = this.datasetName,
				issueDate = this.issueDate,
				issueTime = this.issueTime,
				typeOfProductFormat = this.typeOfProductFormat,
				productSpecification = this.productSpecification?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ElectronicProduct Model => new () {
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			catalogueElementClassification = this.catalogueElementClassification.ToList(),
			catalogueElementIdentifier = this._catalogueElementIdentifier,
			classification = this._classification,
			iMOMaritimeService = this.iMOMaritimeService.ToList(),
			notForNavigation = this._notForNavigation,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			onlineResource = this._onlineResource?.Model,
			sourceIndication = this._sourceIndication?.Model,
			supportFile = this.supportFile.Select(e => e.Model).ToList(),
			timeIntervalOfProduct = this._timeIntervalOfProduct?.Model,
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
			horizontalDatumEPSGCode = this._horizontalDatumEPSGCode,
			verticalDatum = this._verticalDatum,
			compressionFlag = this._compressionFlag,
			datasetName = this._datasetName,
			issueDate = this._issueDate,
			issueTime = this._issueTime,
			typeOfProductFormat = this._typeOfProductFormat,
			productSpecification = this._productSpecification?.Model,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => ElectronicProduct._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => ElectronicProduct._featureBindingDefinitions;

		public override string? ToString() => $"Electronic Product";

		public ElectronicProductViewModel() : base() {
			catalogueElementClassification.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(catalogueElementClassification));
			};
			iMOMaritimeService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(iMOMaritimeService));
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
			approximateGridResolution.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(approximateGridResolution));
			};
			compilationScale.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(compilationScale));
			};
			navigationPurpose.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(navigationPurpose));
			};
		}
	}

	/// <summary>
	/// A product printed on paper.
	/// </summary>
	[CategoryOrder("PhysicalProduct",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PhysicalProductViewModel : FeatureViewModel<PhysicalProduct> {
		private String? _agencyResponsibleForProduction  = default;

		[Category("CatalogueElement")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		[Category("CatalogueElement")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(catalogueElementClassificationList), typeof(catalogueElementClassification))]
		public ObservableCollection<catalogueElementClassification> catalogueElementClassification  { get; set; } = new ();

		[Browsable(false)]
		public catalogueElementClassification[] catalogueElementClassificationList => Enum.GetValues<catalogueElementClassification>();
		private String? _catalogueElementIdentifier  = default;

		[Category("CatalogueElement")]
		public String? catalogueElementIdentifier {
			get {
				return _catalogueElementIdentifier;
			}
			set {
				SetValue(ref _catalogueElementIdentifier, value);
			}
		}
		private String? _classification  = default;

		[Category("CatalogueElement")]
		public String? classification {
			get {
				return _classification;
			}
			set {
				SetValue(ref _classification, value);
			}
		}
		[Category("CatalogueElement")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(iMOMaritimeServiceList), typeof(iMOMaritimeService))]
		public ObservableCollection<iMOMaritimeService> iMOMaritimeService  { get; set; } = new ();

		[Browsable(false)]
		public iMOMaritimeService[] iMOMaritimeServiceList => Enum.GetValues<iMOMaritimeService>();
		private Boolean _notForNavigation  = false;

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
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("CatalogueElement")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private onlineResourceViewModel? _onlineResource  = default;

		[Category("CatalogueElement")]
		[ExpandableObject]
		public onlineResourceViewModel? onlineResource {
			get {
				return _onlineResource;
			}
			set {
				SetValue(ref _onlineResource, value);
			}
		}
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("CatalogueElement")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		[Category("CatalogueElement")]
		public ObservableCollection<supportFileViewModel> supportFile  { get; set; } = new ();
		private timeIntervalOfProductViewModel? _timeIntervalOfProduct  = default;

		[Category("CatalogueElement")]
		[ExpandableObject]
		public timeIntervalOfProductViewModel? timeIntervalOfProduct {
			get {
				return _timeIntervalOfProduct;
			}
			set {
				SetValue(ref _timeIntervalOfProduct, value);
			}
		}

		[Category("NavigationalProduct")]
		public ObservableCollection<decimal> approximateGridResolution  { get; set; } = new ();
		[Category("NavigationalProduct")]
		public ObservableCollection<int> compilationScale  { get; set; } = new ();
		private distributionStatus? _distributionStatus  = default;

		[Category("NavigationalProduct")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(distributionStatusList), typeof(distributionStatus))]
		public distributionStatus? distributionStatus {
			get {
				return _distributionStatus;
			}
			set {
				SetValue(ref _distributionStatus, value);
			}
		}

		[Browsable(false)]
		public distributionStatus[] distributionStatusList => [(distributionStatus)1,(distributionStatus)2];
		private int? _editionNumber  = default;

		[Category("NavigationalProduct")]
		public int? editionNumber {
			get {
				return _editionNumber;
			}
			set {
				SetValue(ref _editionNumber, value);
			}
		}
		private int? _maximumDisplayScale  = default;

		[Category("NavigationalProduct")]
		public int? maximumDisplayScale {
			get {
				return _maximumDisplayScale;
			}
			set {
				SetValue(ref _maximumDisplayScale, value);
			}
		}
		private int? _minimumDisplayScale  = default;

		[Category("NavigationalProduct")]
		public int? minimumDisplayScale {
			get {
				return _minimumDisplayScale;
			}
			set {
				SetValue(ref _minimumDisplayScale, value);
			}
		}
		[Category("NavigationalProduct")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(navigationPurposeList), typeof(navigationPurpose))]
		public ObservableCollection<navigationPurpose> navigationPurpose  { get; set; } = new ();

		[Browsable(false)]
		public navigationPurpose[] navigationPurposeList => [(navigationPurpose)1,(navigationPurpose)2,(navigationPurpose)3];
		private String? _optimumDisplayScale  = default;

		[Category("NavigationalProduct")]
		public String? optimumDisplayScale {
			get {
				return _optimumDisplayScale;
			}
			set {
				SetValue(ref _optimumDisplayScale, value);
			}
		}
		private String? _originalProductNumber  = default;

		[Category("NavigationalProduct")]
		public String? originalProductNumber {
			get {
				return _originalProductNumber;
			}
			set {
				SetValue(ref _originalProductNumber, value);
			}
		}
		private String? _producerNation  = default;

		[Category("NavigationalProduct")]
		public String? producerNation {
			get {
				return _producerNation;
			}
			set {
				SetValue(ref _producerNation, value);
			}
		}
		private String? _productNumber  = default;

		[Category("NavigationalProduct")]
		public String? productNumber {
			get {
				return _productNumber;
			}
			set {
				SetValue(ref _productNumber, value);
			}
		}
		private specificUsage? _specificUsage  = default;

		[Category("NavigationalProduct")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(specificUsageList), typeof(specificUsage))]
		public specificUsage? specificUsage {
			get {
				return _specificUsage;
			}
			set {
				SetValue(ref _specificUsage, value);
			}
		}

		[Browsable(false)]
		public specificUsage[] specificUsageList => [(specificUsage)1,(specificUsage)2,(specificUsage)3,(specificUsage)4,(specificUsage)5,(specificUsage)6];
		private DateOnly? _updateDate  = default;

		[Category("NavigationalProduct")]
		public DateOnly? updateDate {
			get {
				return _updateDate;
			}
			set {
				SetValue(ref _updateDate, value);
			}
		}
		private int? _updateNumber  = default;

		[Category("NavigationalProduct")]
		public int? updateNumber {
			get {
				return _updateNumber;
			}
			set {
				SetValue(ref _updateNumber, value);
			}
		}
		private horizontalDatumEPSGCode? _horizontalDatumEPSGCode  = default;

		[Category("NavigationalProduct")]
		public horizontalDatumEPSGCode? horizontalDatumEPSGCode {
			get {
				return _horizontalDatumEPSGCode;
			}
			set {
				SetValue(ref _horizontalDatumEPSGCode, value);
			}
		}
		private verticalDatum? _verticalDatum  = default;

		[Category("NavigationalProduct")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(verticalDatumList), typeof(verticalDatum))]
		public verticalDatum? verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		[Browsable(false)]
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)42,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45];

		private DateOnly _editionDate ;

		[Category("PhysicalProduct")]
		public DateOnly editionDate {
			get {
				return _editionDate;
			}
			set {
				SetValue(ref _editionDate, value);
			}
		}
		private String? _iSBN  = default;

		[Category("PhysicalProduct")]
		public String? iSBN {
			get {
				return _iSBN;
			}
			set {
				SetValue(ref _iSBN, value);
			}
		}
		private String? _publicationNumber  = default;

		[Category("PhysicalProduct")]
		public String? publicationNumber {
			get {
				return _publicationNumber;
			}
			set {
				SetValue(ref _publicationNumber, value);
			}
		}
		private String? _typeOfPhysicalProduct  = default;

		[Category("PhysicalProduct")]
		public String? typeOfPhysicalProduct {
			get {
				return _typeOfPhysicalProduct;
			}
			set {
				SetValue(ref _typeOfPhysicalProduct, value);
			}
		}
		private printInformationViewModel? _printInformation  = default;

		[Category("PhysicalProduct")]
		[ExpandableObject]
		public printInformationViewModel? printInformation {
			get {
				return _printInformation;
			}
			set {
				SetValue(ref _printInformation, value);
			}
		}
		private referenceToNMViewModel? _referenceToNM  = default;

		[Category("PhysicalProduct")]
		[ExpandableObject]
		public referenceToNMViewModel? referenceToNM {
			get {
				return _referenceToNM;
			}
			set {
				SetValue(ref _referenceToNM, value);
			}
		}


		public override FeatureViewModel<PhysicalProduct> Load(PhysicalProduct instance) {
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			catalogueElementClassification.Clear();
			if (instance.catalogueElementClassification is not null) {
				foreach(var e in instance.catalogueElementClassification)
					catalogueElementClassification.Add(e);
			}
			catalogueElementIdentifier = instance.catalogueElementIdentifier;
			classification = instance.classification;
			iMOMaritimeService.Clear();
			if (instance.iMOMaritimeService is not null) {
				foreach(var e in instance.iMOMaritimeService)
					iMOMaritimeService.Add(e);
			}
			notForNavigation = instance.notForNavigation;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			onlineResource = new ();
			if (instance.onlineResource != default) {
				onlineResource.Load(instance.onlineResource);
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			supportFile.Clear();
			if (instance.supportFile is not null) {
				foreach(var e in instance.supportFile)
					supportFile.Add(new supportFileViewModel().Load(e));
			}
			timeIntervalOfProduct = new ();
			if (instance.timeIntervalOfProduct != default) {
				timeIntervalOfProduct.Load(instance.timeIntervalOfProduct);
			}
			approximateGridResolution.Clear();
			if (instance.approximateGridResolution is not null) {
				foreach(var e in instance.approximateGridResolution)
					approximateGridResolution.Add(e);
			}
			compilationScale.Clear();
			if (instance.compilationScale is not null) {
				foreach(var e in instance.compilationScale)
					compilationScale.Add(e);
			}
			distributionStatus = instance.distributionStatus;
			editionNumber = instance.editionNumber;
			maximumDisplayScale = instance.maximumDisplayScale;
			minimumDisplayScale = instance.minimumDisplayScale;
			navigationPurpose.Clear();
			if (instance.navigationPurpose is not null) {
				foreach(var e in instance.navigationPurpose)
					navigationPurpose.Add(e);
			}
			optimumDisplayScale = instance.optimumDisplayScale;
			originalProductNumber = instance.originalProductNumber;
			producerNation = instance.producerNation;
			productNumber = instance.productNumber;
			specificUsage = instance.specificUsage;
			updateDate = instance.updateDate;
			updateNumber = instance.updateNumber;
			horizontalDatumEPSGCode = instance.horizontalDatumEPSGCode;
			verticalDatum = instance.verticalDatum;
			editionDate = instance.editionDate;
			iSBN = instance.iSBN;
			publicationNumber = instance.publicationNumber;
			typeOfPhysicalProduct = instance.typeOfPhysicalProduct;
			printInformation = new ();
			if (instance.printInformation != default) {
				printInformation.Load(instance.printInformation);
			}
			referenceToNM = new ();
			if (instance.referenceToNM != default) {
				referenceToNM.Load(instance.referenceToNM);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new PhysicalProduct {
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				catalogueElementClassification = this.catalogueElementClassification.ToList(),
				catalogueElementIdentifier = this.catalogueElementIdentifier,
				classification = this.classification,
				iMOMaritimeService = this.iMOMaritimeService.ToList(),
				notForNavigation = this.notForNavigation,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				onlineResource = this.onlineResource?.Model,
				sourceIndication = this.sourceIndication?.Model,
				supportFile = this.supportFile.Select(e => e.Model).ToList(),
				timeIntervalOfProduct = this.timeIntervalOfProduct?.Model,
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
				horizontalDatumEPSGCode = this.horizontalDatumEPSGCode,
				verticalDatum = this.verticalDatum,
				editionDate = this.editionDate,
				iSBN = this.iSBN,
				publicationNumber = this.publicationNumber,
				typeOfPhysicalProduct = this.typeOfPhysicalProduct,
				printInformation = this.printInformation?.Model,
				referenceToNM = this.referenceToNM?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PhysicalProduct Model => new () {
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			catalogueElementClassification = this.catalogueElementClassification.ToList(),
			catalogueElementIdentifier = this._catalogueElementIdentifier,
			classification = this._classification,
			iMOMaritimeService = this.iMOMaritimeService.ToList(),
			notForNavigation = this._notForNavigation,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			onlineResource = this._onlineResource?.Model,
			sourceIndication = this._sourceIndication?.Model,
			supportFile = this.supportFile.Select(e => e.Model).ToList(),
			timeIntervalOfProduct = this._timeIntervalOfProduct?.Model,
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
			horizontalDatumEPSGCode = this._horizontalDatumEPSGCode,
			verticalDatum = this._verticalDatum,
			editionDate = this._editionDate,
			iSBN = this._iSBN,
			publicationNumber = this._publicationNumber,
			typeOfPhysicalProduct = this._typeOfPhysicalProduct,
			printInformation = this._printInformation?.Model,
			referenceToNM = this._referenceToNM?.Model,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => PhysicalProduct._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => PhysicalProduct._featureBindingDefinitions;

		public override string? ToString() => $"Physical Product";

		public PhysicalProductViewModel() : base() {
			catalogueElementClassification.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(catalogueElementClassification));
			};
			iMOMaritimeService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(iMOMaritimeService));
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
			approximateGridResolution.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(approximateGridResolution));
			};
			compilationScale.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(compilationScale));
			};
			navigationPurpose.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(navigationPurpose));
			};
		}
	}

	/// <summary>
	/// A service that makes use of S-100 based product specifications to support data transfer.
	/// </summary>
	[CategoryOrder("S100Service",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class S100ServiceViewModel : FeatureViewModel<S100Service> {
		private String? _agencyResponsibleForProduction  = default;

		[Category("CatalogueElement")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		[Category("CatalogueElement")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(catalogueElementClassificationList), typeof(catalogueElementClassification))]
		public ObservableCollection<catalogueElementClassification> catalogueElementClassification  { get; set; } = new ();

		[Browsable(false)]
		public catalogueElementClassification[] catalogueElementClassificationList => Enum.GetValues<catalogueElementClassification>();
		private String? _catalogueElementIdentifier  = default;

		[Category("CatalogueElement")]
		public String? catalogueElementIdentifier {
			get {
				return _catalogueElementIdentifier;
			}
			set {
				SetValue(ref _catalogueElementIdentifier, value);
			}
		}
		private String? _classification  = default;

		[Category("CatalogueElement")]
		public String? classification {
			get {
				return _classification;
			}
			set {
				SetValue(ref _classification, value);
			}
		}
		[Category("CatalogueElement")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(iMOMaritimeServiceList), typeof(iMOMaritimeService))]
		public ObservableCollection<iMOMaritimeService> iMOMaritimeService  { get; set; } = new ();

		[Browsable(false)]
		public iMOMaritimeService[] iMOMaritimeServiceList => Enum.GetValues<iMOMaritimeService>();
		private Boolean _notForNavigation  = false;

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
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("CatalogueElement")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private onlineResourceViewModel? _onlineResource  = default;

		[Category("CatalogueElement")]
		[ExpandableObject]
		public onlineResourceViewModel? onlineResource {
			get {
				return _onlineResource;
			}
			set {
				SetValue(ref _onlineResource, value);
			}
		}
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("CatalogueElement")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		[Category("CatalogueElement")]
		public ObservableCollection<supportFileViewModel> supportFile  { get; set; } = new ();
		private timeIntervalOfProductViewModel? _timeIntervalOfProduct  = default;

		[Category("CatalogueElement")]
		[ExpandableObject]
		public timeIntervalOfProductViewModel? timeIntervalOfProduct {
			get {
				return _timeIntervalOfProduct;
			}
			set {
				SetValue(ref _timeIntervalOfProduct, value);
			}
		}

		private Boolean? _compressionFlag  = default;

		[Category("S100Service")]
		public Boolean? compressionFlag {
			get {
				return _compressionFlag;
			}
			set {
				SetValue(ref _compressionFlag, value);
			}
		}
		private String? _serviceName  = default;

		[Category("S100Service")]
		public String? serviceName {
			get {
				return _serviceName;
			}
			set {
				SetValue(ref _serviceName, value);
			}
		}
		private serviceStatus? _serviceStatus  = default;

		[Category("S100Service")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(serviceStatusList), typeof(serviceStatus))]
		public serviceStatus? serviceStatus {
			get {
				return _serviceStatus;
			}
			set {
				SetValue(ref _serviceStatus, value);
			}
		}

		[Browsable(false)]
		public serviceStatus[] serviceStatusList => [(serviceStatus)1,(serviceStatus)2,(serviceStatus)3,(serviceStatus)4];
		private typeOfProductFormat _typeOfProductFormat ;

		[Category("S100Service")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(typeOfProductFormatList), typeof(typeOfProductFormat))]
		public typeOfProductFormat typeOfProductFormat {
			get {
				return _typeOfProductFormat;
			}
			set {
				SetValue(ref _typeOfProductFormat, value);
			}
		}

		[Browsable(false)]
		public typeOfProductFormat[] typeOfProductFormatList => [(typeOfProductFormat)1,(typeOfProductFormat)2,(typeOfProductFormat)3,(typeOfProductFormat)4,(typeOfProductFormat)5,(typeOfProductFormat)6,(typeOfProductFormat)7,(typeOfProductFormat)8,(typeOfProductFormat)9,(typeOfProductFormat)10,(typeOfProductFormat)11,(typeOfProductFormat)12];
		private serviceSpecificationViewModel? _serviceSpecification  = default;

		[Category("S100Service")]
		[ExpandableObject]
		public serviceSpecificationViewModel? serviceSpecification {
			get {
				return _serviceSpecification;
			}
			set {
				SetValue(ref _serviceSpecification, value);
			}
		}
		private productSpecificationViewModel? _productSpecification  = default;

		[Category("S100Service")]
		[ExpandableObject]
		public productSpecificationViewModel? productSpecification {
			get {
				return _productSpecification;
			}
			set {
				SetValue(ref _productSpecification, value);
			}
		}


		public override FeatureViewModel<S100Service> Load(S100Service instance) {
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			catalogueElementClassification.Clear();
			if (instance.catalogueElementClassification is not null) {
				foreach(var e in instance.catalogueElementClassification)
					catalogueElementClassification.Add(e);
			}
			catalogueElementIdentifier = instance.catalogueElementIdentifier;
			classification = instance.classification;
			iMOMaritimeService.Clear();
			if (instance.iMOMaritimeService is not null) {
				foreach(var e in instance.iMOMaritimeService)
					iMOMaritimeService.Add(e);
			}
			notForNavigation = instance.notForNavigation;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			onlineResource = new ();
			if (instance.onlineResource != default) {
				onlineResource.Load(instance.onlineResource);
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			supportFile.Clear();
			if (instance.supportFile is not null) {
				foreach(var e in instance.supportFile)
					supportFile.Add(new supportFileViewModel().Load(e));
			}
			timeIntervalOfProduct = new ();
			if (instance.timeIntervalOfProduct != default) {
				timeIntervalOfProduct.Load(instance.timeIntervalOfProduct);
			}
			compressionFlag = instance.compressionFlag;
			serviceName = instance.serviceName;
			serviceStatus = instance.serviceStatus;
			typeOfProductFormat = instance.typeOfProductFormat;
			serviceSpecification = new ();
			if (instance.serviceSpecification != default) {
				serviceSpecification.Load(instance.serviceSpecification);
			}
			productSpecification = new ();
			if (instance.productSpecification != default) {
				productSpecification.Load(instance.productSpecification);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new S100Service {
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				catalogueElementClassification = this.catalogueElementClassification.ToList(),
				catalogueElementIdentifier = this.catalogueElementIdentifier,
				classification = this.classification,
				iMOMaritimeService = this.iMOMaritimeService.ToList(),
				notForNavigation = this.notForNavigation,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				onlineResource = this.onlineResource?.Model,
				sourceIndication = this.sourceIndication?.Model,
				supportFile = this.supportFile.Select(e => e.Model).ToList(),
				timeIntervalOfProduct = this.timeIntervalOfProduct?.Model,
				compressionFlag = this.compressionFlag,
				serviceName = this.serviceName,
				serviceStatus = this.serviceStatus,
				typeOfProductFormat = this.typeOfProductFormat,
				serviceSpecification = this.serviceSpecification?.Model,
				productSpecification = this.productSpecification?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public S100Service Model => new () {
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			catalogueElementClassification = this.catalogueElementClassification.ToList(),
			catalogueElementIdentifier = this._catalogueElementIdentifier,
			classification = this._classification,
			iMOMaritimeService = this.iMOMaritimeService.ToList(),
			notForNavigation = this._notForNavigation,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			onlineResource = this._onlineResource?.Model,
			sourceIndication = this._sourceIndication?.Model,
			supportFile = this.supportFile.Select(e => e.Model).ToList(),
			timeIntervalOfProduct = this._timeIntervalOfProduct?.Model,
			compressionFlag = this._compressionFlag,
			serviceName = this._serviceName,
			serviceStatus = this._serviceStatus,
			typeOfProductFormat = this._typeOfProductFormat,
			serviceSpecification = this._serviceSpecification?.Model,
			productSpecification = this._productSpecification?.Model,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => S100Service._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => S100Service._featureBindingDefinitions;

		public override string? ToString() => $"S100 Service";

		public S100ServiceViewModel() : base() {
			catalogueElementClassification.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(catalogueElementClassification));
			};
			iMOMaritimeService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(iMOMaritimeService));
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
	}

}
