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
using System.Text.Json;

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
	[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
	[CategoryOrder("contactAddress",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class contactAddressViewModel : ComplexViewModel<contactAddress> {
		private String? _administrativeDivision  = default;

		[Description("A generic term for an administrative region within a country at a level below that of the sovereign state.")]
		//[Editor(typeof(Editors.HorizonEditor<contactAddress>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? administrativeDivision {
			get {
				return _administrativeDivision;
			}
			set {
				SetValue(ref _administrativeDivision, value);
			}
		}

		private String? _cityName  = default;

		[Description("The name of a town or city.")]
		//[Editor(typeof(Editors.HorizonEditor<contactAddress>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? cityName {
			get {
				return _cityName;
			}
			set {
				SetValue(ref _cityName, value);
			}
		}

		private String? _countryName  = default;

		[Description("The name of a nation.")]
		//[Editor(typeof(Editors.HorizonEditor<contactAddress>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? countryName {
			get {
				return _countryName;
			}
			set {
				SetValue(ref _countryName, value);
			}
		}

		[Description("Details of where post can be delivered such as the apartment, name and/or number of a street, building or PO Box.")]
		[Optional]
		public ObservableCollection<String> deliveryPoint  { get; set; } = new ();

		private String? _postalCode  = default;

		[Description("Known in various countries as a postcode, or ZIP code, the postal code is a series of letters and/or digits that identifies each postal delivery area.")]
		//[Editor(typeof(Editors.HorizonEditor<contactAddress>), typeof(Editors.HorizonEditor))]
		[Optional]
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
	[Description("User specified paper size width x, height y")]
	[CategoryOrder("customPaperSize",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class customPaperSizeViewModel : ComplexViewModel<customPaperSize> {
		private double _paperWidth  = default;

		[Description("The length in cm of the shorter side of a paper.")]
		//[Editor(typeof(Editors.HorizonEditor<customPaperSize>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double paperWidth {
			get {
				return _paperWidth;
			}
			set {
				SetValue(ref _paperWidth, value);
			}
		}

		private double _paperLength  = default;

		[Description("The length in cm of the longer side of a paper.")]
		//[Editor(typeof(Editors.HorizonEditor<customPaperSize>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double paperLength {
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
	[Description("Locale of an option that is selected automatically unless an alternative is specified.")]
	[CategoryOrder("defaultLocale",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class defaultLocaleViewModel : ComplexViewModel<defaultLocale> {
		private String _characterEncoding  = string.Empty;

		[Description("Designation of the character set to be used to encode the textual value of the locale.")]
		//[Editor(typeof(Editors.HorizonEditor<defaultLocale>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String characterEncoding {
			get {
				return _characterEncoding;
			}
			set {
				SetValue(ref _characterEncoding, value);
			}
		}

		private String _countryName  = string.Empty;

		[Description("The name of a nation.")]
		//[Editor(typeof(Editors.HorizonEditor<defaultLocale>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String countryName {
			get {
				return _countryName;
			}
			set {
				SetValue(ref _countryName, value);
			}
		}

		private String? _language  = default;

		[Description("The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.")]
		//[Editor(typeof(Editors.HorizonEditor<defaultLocale>), typeof(Editors.HorizonEditor))]
		[Optional]
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
	[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
	[CategoryOrder("featureName",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class featureNameViewModel : ComplexViewModel<featureName> {
		private String? _language  = default;

		[Description("The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.")]
		//[Editor(typeof(Editors.HorizonEditor<featureName>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}

		private String _name  = string.Empty;

		[Description("The individual name of a feature.")]
		//[Editor(typeof(Editors.HorizonEditor<featureName>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String name {
			get {
				return _name;
			}
			set {
				SetValue(ref _name, value);
			}
		}

		private nameUsage? _nameUsage  = default;

		[Description("Classification of the type and display level of the name of a feature in an end-user system.")]
		//[Editor(typeof(Editors.HorizonEditor<featureName>), typeof(Editors.HorizonEditor))]
		[Optional]
		public nameUsage? nameUsage {
			get {
				return _nameUsage;
			}
			set {
				SetValue(ref _nameUsage, value);
			}
		}

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
	[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
	[CategoryOrder("information",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class informationViewModel : ComplexViewModel<information> {
		private String? _fileLocator  = default;

		[Description("The location of a fragment of text or other information in a support file.")]
		//[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? fileLocator {
			get {
				return _fileLocator;
			}
			set {
				SetValue(ref _fileLocator, value);
			}
		}

		private String? _fileReference  = default;

		[Description("The file name of an externally referenced text file.")]
		//[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? fileReference {
			get {
				return _fileReference;
			}
			set {
				SetValue(ref _fileReference, value);
			}
		}

		private String? _headline  = default;

		[Description("Words set at the head of a passage or page to introduce or categorize.")]
		//[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? headline {
			get {
				return _headline;
			}
			set {
				SetValue(ref _headline, value);
			}
		}

		private String? _language  = default;

		[Description("The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.")]
		//[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}

		[Description("A non-formatted digital text string.")]
		[Optional]
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
	[Description("The cycle of issuing a product or service.")]
	[CategoryOrder("issuanceCycle",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class issuanceCycleViewModel : ComplexViewModel<issuanceCycle> {
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[ExpandableObject]
		[Optional]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}

		private timeIntervalOfCycleViewModel? _timeIntervalOfCycle  = default;

		[Description("The temporal interval of the cycle over which data is produced.")]
		[ExpandableObject]
		[Optional]
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
	[Description("Information about online sources from which a resource or data can be obtained.")]
	[CategoryOrder("onlineResource",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class onlineResourceViewModel : ComplexViewModel<onlineResource> {
		private String? _applicationProfile  = default;

		[Description("Name of an application profile that can be used with the online resource.")]
		//[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? applicationProfile {
			get {
				return _applicationProfile;
			}
			set {
				SetValue(ref _applicationProfile, value);
			}
		}

		private String _linkage  = string.Empty;

		[Description("Location (address) for online access using a URL/URI address or similar addressing scheme.")]
		//[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String linkage {
			get {
				return _linkage;
			}
			set {
				SetValue(ref _linkage, value);
			}
		}

		private String? _nameOfResource  = default;

		[Description("Name of the online resource.")]
		//[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? nameOfResource {
			get {
				return _nameOfResource;
			}
			set {
				SetValue(ref _nameOfResource, value);
			}
		}

		private String? _onlineDescription  = default;

		[Description("Description of online resources.")]
		//[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? onlineDescription {
			get {
				return _onlineDescription;
			}
			set {
				SetValue(ref _onlineDescription, value);
			}
		}

		private String? _protocol  = default;

		[Description("Connection protocol to be used. Example: ftp, http get KVP, http POST, etc.")]
		//[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? protocol {
			get {
				return _protocol;
			}
			set {
				SetValue(ref _protocol, value);
			}
		}

		private String? _protocolRequest  = default;

		[Description("Request used to access the resource. Structure and content depend on the protocol and standard used by the online resource, such as Web Feature Service standard.")]
		//[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[Optional]
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
	[Description("The active period of a recurring event or occurrence.")]
	[CategoryOrder("periodicDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class periodicDateRangeViewModel : ComplexViewModel<periodicDateRange> {
		private String _dateEnd  = string.Empty;

		[Description("The latest date on which an object (for example a buoy) will be present.")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Mandatory]
		public String dateEnd {
			get {
				return _dateEnd;
			}
			set {
				SetValue(ref _dateEnd, value);
			}
		}

		private String _dateStart  = string.Empty;

		[Description("The earliest date on which an object (for example a buoy) will be present.")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Mandatory]
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
	[Description("A decision or establishment of a price.")]
	[CategoryOrder("pricing",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class pricingViewModel : ComplexViewModel<pricing> {
		private String? _contractPeriod  = default;

		[Description("Definition of a period when a contract is valid.")]
		//[Editor(typeof(Editors.HorizonEditor<pricing>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? contractPeriod {
			get {
				return _contractPeriod;
			}
			set {
				SetValue(ref _contractPeriod, value);
			}
		}

		private String _currency  = string.Empty;

		[Description("Something (such as coins, treasury notes, and banknotes) that is in circulation as a medium of exchange.")]
		//[Editor(typeof(Editors.HorizonEditor<pricing>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String currency {
			get {
				return _currency;
			}
			set {
				SetValue(ref _currency, value);
			}
		}

		private double _price  = default;

		[Description("The amount of money expected, required, or given in payment for something.")]
		//[Editor(typeof(Editors.HorizonEditor<pricing>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double price {
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
	[Description("Information on the printing of nautical paper charts.")]
	[CategoryOrder("printInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class printInformationViewModel : ComplexViewModel<printInformation> {
		private String? _printAgency  = default;

		[Description("Name of the publishing institution of the paper chart for navigation.")]
		//[Editor(typeof(Editors.HorizonEditor<printInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? printAgency {
			get {
				return _printAgency;
			}
			set {
				SetValue(ref _printAgency, value);
			}
		}

		private String? _printNation  = default;

		[Description("The authority who printed a nautical paper chart.")]
		//[Editor(typeof(Editors.HorizonEditor<printInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? printNation {
			get {
				return _printNation;
			}
			set {
				SetValue(ref _printNation, value);
			}
		}

		private String? _reprintEdition  = default;

		[Description("Reprinted version of nautical paper chart.")]
		//[Editor(typeof(Editors.HorizonEditor<printInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? reprintEdition {
			get {
				return _reprintEdition;
			}
			set {
				SetValue(ref _reprintEdition, value);
			}
		}

		private String? _reprintNation  = default;

		[Description("The authority who reprinted a nautical paper chart.")]
		//[Editor(typeof(Editors.HorizonEditor<printInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? reprintNation {
			get {
				return _reprintNation;
			}
			set {
				SetValue(ref _reprintNation, value);
			}
		}

		private printSizeViewModel _printSize  = default;

		[Description("Size of nautical paper charts.")]
		[ExpandableObject]
		[Mandatory]
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
	[Description("Size of nautical paper charts.")]
	[CategoryOrder("printSize",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class printSizeViewModel : ComplexViewModel<printSize> {
		private iSO216? _iSO216  = default;

		[Description("ISO 216 is a paper-size standard established by the International Organization for Standardization (ISO).")]
		//[Editor(typeof(Editors.HorizonEditor<printSize>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8])]
		[Optional]
		public iSO216? iSO216 {
			get {
				return _iSO216;
			}
			set {
				SetValue(ref _iSO216, value);
			}
		}

		private customPaperSizeViewModel? _customPaperSize  = default;

		[Description("User specified paper size width x, height y")]
		[ExpandableObject]
		[Optional]
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
	[Description("The name of the product specification to which a nautical product adheres.")]
	[CategoryOrder("productSpecification",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class productSpecificationViewModel : ComplexViewModel<productSpecification> {
		private DateOnly _editionDate  = default;

		[Description("Date of publishing for example of a publication, chart, or product.")]
		//[Editor(typeof(Editors.HorizonEditor<productSpecification>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public DateOnly editionDate {
			get {
				return _editionDate;
			}
			set {
				SetValue(ref _editionDate, value);
			}
		}

		private String? _iSSN  = default;

		[Description("International Standard Serial Number.")]
		//[Editor(typeof(Editors.HorizonEditor<productSpecification>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iSSN {
			get {
				return _iSSN;
			}
			set {
				SetValue(ref _iSSN, value);
			}
		}

		private String _name  = string.Empty;

		[Description("The individual name of a feature.")]
		//[Editor(typeof(Editors.HorizonEditor<productSpecification>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String name {
			get {
				return _name;
			}
			set {
				SetValue(ref _name, value);
			}
		}

		private String _version  = string.Empty;

		[Description("Identification of a specific form or variation of an entity.")]
		//[Editor(typeof(Editors.HorizonEditor<productSpecification>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
	[Description("Information on additional files used in addition to nautical products.")]
	[CategoryOrder("supportFile",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class supportFileViewModel : ComplexViewModel<supportFile> {
		private String? _comment  = default;

		[Description("Comment regarding an entity obvious from context.")]
		//[Editor(typeof(Editors.HorizonEditor<supportFile>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? comment {
			get {
				return _comment;
			}
			set {
				SetValue(ref _comment, value);
			}
		}

		private digitalSignatureReference _digitalSignatureReference  = default;

		[Description("Specifies the algorithm used to compute digital signature value.")]
		//[Editor(typeof(Editors.HorizonEditor<supportFile>), typeof(Editors.HorizonEditor))]
		[PermittedValues([8])]
		[Mandatory]
		public digitalSignatureReference digitalSignatureReference {
			get {
				return _digitalSignatureReference;
			}
			set {
				SetValue(ref _digitalSignatureReference, value);
			}
		}

		private digitalSignatureValue? _digitalSignatureValue  = default;

		[Description("Value derived from the digital signature.")]
		//[Editor(typeof(Editors.HorizonEditor<supportFile>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2])]
		[Optional]
		public digitalSignatureValue? digitalSignatureValue {
			get {
				return _digitalSignatureValue;
			}
			set {
				SetValue(ref _digitalSignatureValue, value);
			}
		}

		private int? _editionNumber  = default;

		[Description("Edition of the ENC being referenced.")]
		//[Editor(typeof(Editors.HorizonEditor<supportFile>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? editionNumber {
			get {
				return _editionNumber;
			}
			set {
				SetValue(ref _editionNumber, value);
			}
		}

		private String _fileLocator  = string.Empty;

		[Description("The location of a fragment of text or other information in a support file.")]
		//[Editor(typeof(Editors.HorizonEditor<supportFile>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String fileLocator {
			get {
				return _fileLocator;
			}
			set {
				SetValue(ref _fileLocator, value);
			}
		}

		private String _fileName  = string.Empty;

		[Description("The name of a file within a system.")]
		//[Editor(typeof(Editors.HorizonEditor<supportFile>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String fileName {
			get {
				return _fileName;
			}
			set {
				SetValue(ref _fileName, value);
			}
		}

		private DateOnly? _issueDate  = default;

		[Description("Date up to which the data was made available by the Data Producer.")]
		//[Editor(typeof(Editors.HorizonEditor<supportFile>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? issueDate {
			get {
				return _issueDate;
			}
			set {
				SetValue(ref _issueDate, value);
			}
		}

		private String? _otherDataTypeDescription  = default;

		[Description("Description of a support file format other than those listed.")]
		//[Editor(typeof(Editors.HorizonEditor<supportFile>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? otherDataTypeDescription {
			get {
				return _otherDataTypeDescription;
			}
			set {
				SetValue(ref _otherDataTypeDescription, value);
			}
		}

		private supportFileFormat _supportFileFormat  = default;

		[Description("The format used for the support file.")]
		//[Editor(typeof(Editors.HorizonEditor<supportFile>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,100])]
		[Mandatory]
		public supportFileFormat supportFileFormat {
			get {
				return _supportFileFormat;
			}
			set {
				SetValue(ref _supportFileFormat, value);
			}
		}

		private supportFilePurpose _supportFilePurpose  = default;

		[Description("The reason for inclusion of the support file.")]
		//[Editor(typeof(Editors.HorizonEditor<supportFile>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Mandatory]
		public supportFilePurpose supportFilePurpose {
			get {
				return _supportFilePurpose;
			}
			set {
				SetValue(ref _supportFilePurpose, value);
			}
		}

		private defaultLocaleViewModel _defaultLocale  = default;

		[Description("Locale of an option that is selected automatically unless an alternative is specified.")]
		[ExpandableObject]
		[Mandatory]
		public defaultLocaleViewModel defaultLocale {
			get {
				return _defaultLocale;
			}
			set {
				SetValue(ref _defaultLocale, value);
			}
		}

		private supportFileSpecificationViewModel _supportFileSpecification  = default;

		[Description("The name of the product specification to which a support file adheres.")]
		[ExpandableObject]
		[Mandatory]
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
	[Description("The name of the product specification to which a support file adheres.")]
	[CategoryOrder("supportFileSpecification",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class supportFileSpecificationViewModel : ComplexViewModel<supportFileSpecification> {
		private DateOnly _editionDate  = default;

		[Description("Date of publishing for example of a publication, chart, or product.")]
		//[Editor(typeof(Editors.HorizonEditor<supportFileSpecification>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public DateOnly editionDate {
			get {
				return _editionDate;
			}
			set {
				SetValue(ref _editionDate, value);
			}
		}

		private String _name  = string.Empty;

		[Description("The individual name of a feature.")]
		//[Editor(typeof(Editors.HorizonEditor<supportFileSpecification>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String name {
			get {
				return _name;
			}
			set {
				SetValue(ref _name, value);
			}
		}

		private String _version  = string.Empty;

		[Description("Identification of a specific form or variation of an entity.")]
		//[Editor(typeof(Editors.HorizonEditor<supportFileSpecification>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
	[Description("The name of the (product) specification to which a nautical service adheres.")]
	[CategoryOrder("serviceSpecification",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class serviceSpecificationViewModel : ComplexViewModel<serviceSpecification> {
		private DateOnly _editionDate  = default;

		[Description("Date of publishing for example of a publication, chart, or product.")]
		//[Editor(typeof(Editors.HorizonEditor<serviceSpecification>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public DateOnly editionDate {
			get {
				return _editionDate;
			}
			set {
				SetValue(ref _editionDate, value);
			}
		}

		private String _name  = string.Empty;

		[Description("The individual name of a feature.")]
		//[Editor(typeof(Editors.HorizonEditor<serviceSpecification>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String name {
			get {
				return _name;
			}
			set {
				SetValue(ref _name, value);
			}
		}

		private String _version  = string.Empty;

		[Description("Identification of a specific form or variation of an entity.")]
		//[Editor(typeof(Editors.HorizonEditor<serviceSpecification>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
	[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
	[CategoryOrder("sourceIndication",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sourceIndicationViewModel : ComplexViewModel<sourceIndication> {
		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Description("The type of person, government agency or organisation granted powers of managing or controlling access to and/or activity in an area.")]
		//[Editor(typeof(Editors.HorizonEditor<sourceIndication>), typeof(Editors.HorizonEditor))]
		[PermittedValues([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19])]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		private String? _countryName  = default;

		[Description("The name of a nation.")]
		//[Editor(typeof(Editors.HorizonEditor<sourceIndication>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? countryName {
			get {
				return _countryName;
			}
			set {
				SetValue(ref _countryName, value);
			}
		}

		private DateOnly? _reportedDate  = default;

		[Description("The date that the item was observed, done, or investigated.")]
		//[Editor(typeof(Editors.HorizonEditor<sourceIndication>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		//[Editor(typeof(Editors.HorizonEditor<sourceIndication>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private sourceType? _sourceType  = default;

		[Description("Type of the source.")]
		//[Editor(typeof(Editors.HorizonEditor<sourceIndication>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,7,8,9,10,11,12,13,14,15])]
		[Optional]
		public sourceType? sourceType {
			get {
				return _sourceType;
			}
			set {
				SetValue(ref _sourceType, value);
			}
		}

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Optional]
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
	[Description("A means or channel of communicating at a distance by electrical or electromagnetic means such as telegraphy, telephony, or broadcasting.")]
	[CategoryOrder("telecommunications",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class telecommunicationsViewModel : ComplexViewModel<telecommunications> {
		private String _contactInstructions  = string.Empty;

		[Description("Instructions provided on how to contact a particular person, organisation or service.")]
		//[Editor(typeof(Editors.HorizonEditor<telecommunications>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String contactInstructions {
			get {
				return _contactInstructions;
			}
			set {
				SetValue(ref _contactInstructions, value);
			}
		}

		private String _telecommunicationIdentifier  = string.Empty;

		[Description("An identifier, such as words, numbers, letters, symbols, or any combination of those used to establish a contact to a particular person, organisation or service.")]
		//[Editor(typeof(Editors.HorizonEditor<telecommunications>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String telecommunicationIdentifier {
			get {
				return _telecommunicationIdentifier;
			}
			set {
				SetValue(ref _telecommunicationIdentifier, value);
			}
		}

		[Description("Classification of methods of communication over a distance by electrical, electronic, or electromagnetic means.")]
		[PermittedValues([1,2,3,4,5,6,7,8])]
		[Optional]
		public ObservableCollection<telecommunicationService> telecommunicationService  { get; set; } = new ();

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
	[Description("The temporal interval over which the product is updated or renewed.")]
	[CategoryOrder("timeIntervalOfProduct",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class timeIntervalOfProductViewModel : ComplexViewModel<timeIntervalOfProduct> {
		private DateOnly? _expirationDate  = default;

		[Description("Expiration date of a product or service")]
		//[Editor(typeof(Editors.HorizonEditor<timeIntervalOfProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? expirationDate {
			get {
				return _expirationDate;
			}
			set {
				SetValue(ref _expirationDate, value);
			}
		}

		private DateOnly _issueDate  = default;

		[Description("Date up to which the data was made available by the Data Producer.")]
		//[Editor(typeof(Editors.HorizonEditor<timeIntervalOfProduct>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public DateOnly issueDate {
			get {
				return _issueDate;
			}
			set {
				SetValue(ref _issueDate, value);
			}
		}

		private issuanceCycleViewModel? _issuanceCycle  = default;

		[Description("The cycle of issuing a product or service.")]
		[ExpandableObject]
		[Optional]
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
	[Description("The temporal interval of the cycle over which data is produced.")]
	[CategoryOrder("timeIntervalOfCycle",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class timeIntervalOfCycleViewModel : ComplexViewModel<timeIntervalOfCycle> {
		[Description("The unit of a value indicating a time Time Interval.")]
		[PermittedValues([1,2,3,4])]
		[Multiplicity(1)]
		public ObservableCollection<typeOfTimeIntervalUnit> typeOfTimeIntervalUnit  { get; set; } = new ();

		private int _valueOfTime  = default;

		[Description("The length or duration of a time interval, referred to a specified time interval unit.")]
		//[Editor(typeof(Editors.HorizonEditor<timeIntervalOfCycle>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
	[Description("A reference to a of specific Notice to Mariners.")]
	[CategoryOrder("referenceToNM",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class referenceToNMViewModel : ComplexViewModel<referenceToNM> {
		private DateOnly _publicationDate  = default;

		[Description("The official publication date of a notice, product or service.")]
		//[Editor(typeof(Editors.HorizonEditor<referenceToNM>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public DateOnly publicationDate {
			get {
				return _publicationDate;
			}
			set {
				SetValue(ref _publicationDate, value);
			}
		}

		private weekOfYearViewModel? _weekOfYear  = default;

		[Description("The indication of a specific week within a specific year.")]
		[ExpandableObject]
		[Optional]
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
	[Description("The indication of a specific week within a specific year.")]
	[CategoryOrder("weekOfYear",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class weekOfYearViewModel : ComplexViewModel<weekOfYear> {
		private int _weekNumber  = default;

		[Description("A consecutive number that specifies a week within a year.")]
		//[Editor(typeof(Editors.HorizonEditor<weekOfYear>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int weekNumber {
			get {
				return _weekNumber;
			}
			set {
				SetValue(ref _weekNumber, value);
			}
		}

		private int _yearNumber  = default;

		[Description("A number indicating a year.")]
		//[Editor(typeof(Editors.HorizonEditor<weekOfYear>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
	[Description("A carriage requirement required by SOLAS or other regulation.")]
	[CategoryOrder("CarriageRequirement",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CarriageRequirementViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new CarriageRequirement {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Carriage Requirement";
	}



	/// <summary>
	/// Details related to distribution.
	/// </summary>
	[Description("Details related to distribution.")]
	[CategoryOrder("DistributionDetails",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DistributionDetailsViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new DistributionDetails {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Distribution Details";
	}



	/// <summary>
	/// Contact information of distributor.
	/// </summary>
	[Description("Contact information of distributor.")]
	[CategoryOrder("DistributorContact",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DistributorContactViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new DistributorContact {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Distributor Contact";
	}



	/// <summary>
	/// An association of price information to a catalogue element.
	/// </summary>
	[Description("An association of price information to a catalogue element.")]
	[CategoryOrder("PriceOfElement",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PriceOfElementViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new PriceOfElement {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Price of Element";
	}



	/// <summary>
	/// The price of a nautical product.
	/// </summary>
	[Description("The price of a nautical product.")]
	[CategoryOrder("PriceOfNauticalProduct",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PriceOfNauticalProductViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new PriceOfNauticalProduct {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Price of Nautical Product";
	}



	/// <summary>
	/// Contact information of producer.
	/// </summary>
	[Description("Contact information of producer.")]
	[CategoryOrder("ProducerContact",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ProducerContactViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new ProducerContact {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Producer Contact";
	}



	/// <summary>
	/// Contact information of a producing organization.
	/// </summary>
	[Description("Contact information of a producing organization.")]
	[CategoryOrder("ProductionDetails",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ProductionDetailsViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new ProductionDetails {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Production Details";
	}



	/// <summary>
	/// A package or distinct set of products.
	/// </summary>
	[Description("A package or distinct set of products.")]
	[CategoryOrder("ProductPackage",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ProductPackageViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new ProductPackage {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Product Package";
	}



	/// <summary>
	/// Mapping between traditional products and S-100 Products.
	/// </summary>
	[Description("Mapping between traditional products and S-100 Products.")]
	[CategoryOrder("ProductMapping",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ProductMappingViewModel : FeatureAssociationViewModel {
		private categoryOfProductMapping _categoryOfProductMapping  = default;

		[Description("A classification of the internal relationships between products and services.")]
		[Category("ProductMapping")]
		//[Editor(typeof(Editors.HorizonEditor<ProductMapping>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Mandatory]
		public categoryOfProductMapping categoryOfProductMapping {
			get {
				return _categoryOfProductMapping;
			}
			set {
				SetValue(ref _categoryOfProductMapping, value);
			}
		}


		public override string Serialize() {
			var instance = new ProductMapping {
				categoryOfProductMapping = this.categoryOfProductMapping,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Product Mapping";
	}



	/// <summary>
	/// A supplementary or secondary part of the product, which may appear multiple times, offering control or display functionalities depending on its configuration.
	/// </summary>
	[Description("A supplementary or secondary part of the product, which may appear multiple times, offering control or display functionalities depending on its configuration.")]
	[CategoryOrder("Correlated",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CorrelatedViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new Correlated {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Correlated";
	}



	/// <summary>
	/// A header identifying a section within a catalogue.
	/// </summary>
	[Description("A header identifying a section within a catalogue.")]
	[CategoryOrder("CatalogueSectionHeader",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CatalogueSectionHeaderViewModel : InformationViewModel<CatalogueSectionHeader> {
		private int _catalogueSectionNumber  = default;

		[Description("A number identifying a section within a catalogue.")]
		[Category("CatalogueSectionHeader")]
		//[Editor(typeof(Editors.HorizonEditor<CatalogueSectionHeader>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int catalogueSectionNumber {
			get {
				return _catalogueSectionNumber;
			}
			set {
				SetValue(ref _catalogueSectionNumber, value);
			}
		}

		private String? _catalogueSectionTitle  = default;

		[Description("The catalogue section title.")]
		[Category("CatalogueSectionHeader")]
		//[Editor(typeof(Editors.HorizonEditor<CatalogueSectionHeader>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? catalogueSectionTitle {
			get {
				return _catalogueSectionTitle;
			}
			set {
				SetValue(ref _catalogueSectionTitle, value);
			}
		}

		private informationViewModel? _information  = default;

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("CatalogueSectionHeader")]
		[ExpandableObject]
		[Optional]
		public informationViewModel? information {
			get {
				return _information;
			}
			set {
				SetValue(ref _information, value);
			}
		}


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("PriceOfNauticalProduct","thePriceInformation",["PriceInformation"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> PriceOfNauticalProducts { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("ProductionDetails","theProducer",["ProducerInformation"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> ProductionDetails { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("DistributionDetails","theDistributor",["DistributorInformation"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> DistributionDetails { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. PriceOfNauticalProducts.Select(e => new informationBinding<DomainModel.S128.InformationAssociations.PriceOfNauticalProduct> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. ProductionDetails.Select(e => new informationBinding<DomainModel.S128.InformationAssociations.ProductionDetails> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. DistributionDetails.Select(e => new informationBinding<DomainModel.S128.InformationAssociations.DistributionDetails> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion

		public CatalogueSectionHeaderViewModel Load(CatalogueSectionHeader instance) {
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.CatalogueSectionHeader.informationBindingDefinitions;

		public CatalogueSectionHeaderViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Catalogue Section Header";
	}



	/// <summary>
	/// Information on how to reach a person or organisation by postal, internet, telephone, telex and radio systems.
	/// </summary>
	[Description("Information on how to reach a person or organisation by postal, internet, telephone, telex and radio systems.")]
	[CategoryOrder("ContactDetails",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ContactDetailsViewModel : InformationViewModel<ContactDetails> {
		private String _contactInstructions  = string.Empty;

		[Description("Instructions provided on how to contact a particular person, organisation or service.")]
		[Category("ContactDetails")]
		//[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String contactInstructions {
			get {
				return _contactInstructions;
			}
			set {
				SetValue(ref _contactInstructions, value);
			}
		}

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<contactAddressViewModel> contactAddress  { get; set; } = new ();

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Information about online sources from which a resource or data can be obtained.")]
		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<onlineResourceViewModel> onlineResource  { get; set; } = new ();

		[Description("A means or channel of communicating at a distance by electrical or electromagnetic means such as telegraphy, telephony, or broadcasting.")]
		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<telecommunicationsViewModel> telecommunications  { get; set; } = new ();

		[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("ProducerContact","theProducer",["ProducerInformation"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> ProducerContacts { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("DistributorContact","theDistributor",["DistributorInformation"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> DistributorContacts { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ProducerContacts.Select(e => new informationBinding<DomainModel.S128.InformationAssociations.ProducerContact> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. DistributorContacts.Select(e => new informationBinding<DomainModel.S128.InformationAssociations.DistributorContact> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion

		public ContactDetailsViewModel Load(ContactDetails instance) {
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.ContactDetails.informationBindingDefinitions;

		public ContactDetailsViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

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
	[Description("An indication of the type or justification of a carriage requirement.")]
	[CategoryOrder("IndicationOfCarriageRequirement",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class IndicationOfCarriageRequirementViewModel : InformationViewModel<IndicationOfCarriageRequirement> {
		private String? _domesticCarriageRequirements  = default;

		[Description("A carriage requirement that is specific to a country or region and is based on domestic legislation or regulation.")]
		[Category("IndicationOfCarriageRequirement")]
		//[Editor(typeof(Editors.HorizonEditor<IndicationOfCarriageRequirement>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? domesticCarriageRequirements {
			get {
				return _domesticCarriageRequirements;
			}
			set {
				SetValue(ref _domesticCarriageRequirements, value);
			}
		}

		private String? _internationalCarriageRequirements  = default;

		[Description("International Carriage requirements are carriage requirements based on the SOLAS-convention or similar international regulation.")]
		[Category("IndicationOfCarriageRequirement")]
		//[Editor(typeof(Editors.HorizonEditor<IndicationOfCarriageRequirement>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? internationalCarriageRequirements {
			get {
				return _internationalCarriageRequirements;
			}
			set {
				SetValue(ref _internationalCarriageRequirements, value);
			}
		}

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("IndicationOfCarriageRequirement")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];

		public IndicationOfCarriageRequirementViewModel Load(IndicationOfCarriageRequirement instance) {
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.IndicationOfCarriageRequirement.informationBindingDefinitions;

		public IndicationOfCarriageRequirementViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

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
	[Description("Pricing information of nautical products.")]
	[CategoryOrder("PriceInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PriceInformationViewModel : InformationViewModel<PriceInformation> {
		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("PriceInformation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Information about online sources from which a resource or data can be obtained.")]
		[Category("PriceInformation")]
		[Optional]
		public ObservableCollection<onlineResourceViewModel> onlineResource  { get; set; } = new ();

		[Description("A decision or establishment of a price.")]
		[Category("PriceInformation")]
		[Optional]
		public ObservableCollection<pricingViewModel> pricing  { get; set; } = new ();

		[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
		[Category("PriceInformation")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("PriceOfNauticalProduct","theCatalogueOfNauticalProduct",["CatalogueSectionHeader"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> PriceOfNauticalProducts { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. PriceOfNauticalProducts.Select(e => new informationBinding<DomainModel.S128.InformationAssociations.PriceOfNauticalProduct> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion

		public PriceInformationViewModel Load(PriceInformation instance) {
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.PriceInformation.informationBindingDefinitions;

		public PriceInformationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

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
	[Description("Information about the authority responsible for production.")]
	[CategoryOrder("ProducerInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ProducerInformationViewModel : InformationViewModel<ProducerInformation> {
		private String _agencyResponsibleForProduction  = string.Empty;

		[Description("Identifies the agency which produced the data.")]
		[Category("ProducerInformation")]
		//[Editor(typeof(Editors.HorizonEditor<ProducerInformation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}

		private String? _agencyName  = default;

		[Description("The name of an agency, entity or organization.")]
		[Category("ProducerInformation")]
		//[Editor(typeof(Editors.HorizonEditor<ProducerInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? agencyName {
			get {
				return _agencyName;
			}
			set {
				SetValue(ref _agencyName, value);
			}
		}


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("ProducerContact","theContactDetails",["ContactDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ProducerContacts { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("ProductionDetails","catalogueHeader",["CatalogueSectionHeader"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ProductionDetails { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ProducerContacts.Select(e => new informationBinding<DomainModel.S128.InformationAssociations.ProducerContact> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. ProductionDetails.Select(e => new informationBinding<DomainModel.S128.InformationAssociations.ProductionDetails> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion

		public ProducerInformationViewModel Load(ProducerInformation instance) {
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.ProducerInformation.informationBindingDefinitions;

		public ProducerInformationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Producer Information";
	}



	/// <summary>
	/// Information related to a distributor.
	/// </summary>
	[Description("Information related to a distributor.")]
	[CategoryOrder("DistributorInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DistributorInformationViewModel : InformationViewModel<DistributorInformation> {
		private String _distributorName  = string.Empty;

		[Description("Name of the distributor.")]
		[Category("DistributorInformation")]
		//[Editor(typeof(Editors.HorizonEditor<DistributorInformation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String distributorName {
			get {
				return _distributorName;
			}
			set {
				SetValue(ref _distributorName, value);
			}
		}


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("DistributionDetails","catalogueHeader",["CatalogueSectionHeader"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> DistributionDetails { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("DistributorContact","theContactDetails",["ContactDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> DistributorContacts { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. DistributionDetails.Select(e => new informationBinding<DomainModel.S128.InformationAssociations.DistributionDetails> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. DistributorContacts.Select(e => new informationBinding<DomainModel.S128.InformationAssociations.DistributorContact> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion

		public DistributorInformationViewModel Load(DistributorInformation instance) {
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.DistributorInformation.informationBindingDefinitions;

		public DistributorInformationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Distributor Information";
	}



	/// <summary>
	/// Electronic navigation product.
	/// </summary>
	[Description("Electronic navigation product.")]
	[CategoryOrder("ElectronicProduct",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ElectronicProductViewModel : FeatureViewModel<ElectronicProduct> {
		private String? _agencyResponsibleForProduction  = default;

		[Description("Identifies the agency which produced the data.")]
		[Category("CatalogueElement")]
		//[Editor(typeof(Editors.HorizonEditor<CatalogueElement>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}

		[Description("Classification of a catalogue element.")]
		[Category("CatalogueElement")]
		[Multiplicity(1)]
		public ObservableCollection<catalogueElementClassification> catalogueElementClassification  { get; set; } = new ();

		private String? _catalogueElementIdentifier  = default;

		[Description("Identifier of a catalogue element.")]
		[Category("CatalogueElement")]
		//[Editor(typeof(Editors.HorizonEditor<CatalogueElement>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? catalogueElementIdentifier {
			get {
				return _catalogueElementIdentifier;
			}
			set {
				SetValue(ref _catalogueElementIdentifier, value);
			}
		}

		private String? _classification  = default;

		[Description("Indicates a classification.")]
		[Category("CatalogueElement")]
		//[Editor(typeof(Editors.HorizonEditor<CatalogueElement>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? classification {
			get {
				return _classification;
			}
			set {
				SetValue(ref _classification, value);
			}
		}

		[Description("A maritime service as identified by the International Maritime Organization (IMO).")]
		[Category("CatalogueElement")]
		[Optional]
		public ObservableCollection<iMOMaritimeService> iMOMaritimeService  { get; set; } = new ();

		private Boolean _notForNavigation  = false;

		[Description("Indicates the dataset is not intended to be used for navigation.")]
		[Category("CatalogueElement")]
		//[Editor(typeof(Editors.HorizonEditor<CatalogueElement>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public Boolean notForNavigation {
			get {
				return _notForNavigation;
			}
			set {
				SetValue(ref _notForNavigation, value);
			}
		}

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("CatalogueElement")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("CatalogueElement")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private onlineResourceViewModel? _onlineResource  = default;

		[Description("Information about online sources from which a resource or data can be obtained.")]
		[Category("CatalogueElement")]
		[ExpandableObject]
		[Optional]
		public onlineResourceViewModel? onlineResource {
			get {
				return _onlineResource;
			}
			set {
				SetValue(ref _onlineResource, value);
			}
		}

		private sourceIndicationViewModel? _sourceIndication  = default;

		[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
		[Category("CatalogueElement")]
		[ExpandableObject]
		[Optional]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}

		[Description("Information on additional files used in addition to nautical products.")]
		[Category("CatalogueElement")]
		[Optional]
		public ObservableCollection<supportFileViewModel> supportFile  { get; set; } = new ();

		private timeIntervalOfProductViewModel? _timeIntervalOfProduct  = default;

		[Description("The temporal interval over which the product is updated or renewed.")]
		[Category("CatalogueElement")]
		[ExpandableObject]
		[Optional]
		public timeIntervalOfProductViewModel? timeIntervalOfProduct {
			get {
				return _timeIntervalOfProduct;
			}
			set {
				SetValue(ref _timeIntervalOfProduct, value);
			}
		}

		[Description("Approximate grid resolution for nautical products.")]
		[Category("NavigationalProduct")]
		[Optional]
		public ObservableCollection<double> approximateGridResolution  { get; set; } = new ();

		[Description("In ECDIS, the scale at which the data was compiled.")]
		[Category("NavigationalProduct")]
		[Optional]
		public ObservableCollection<int> compilationScale  { get; set; } = new ();

		private distributionStatus? _distributionStatus  = default;

		[Description("Supply status of nautical products.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2])]
		[Optional]
		public distributionStatus? distributionStatus {
			get {
				return _distributionStatus;
			}
			set {
				SetValue(ref _distributionStatus, value);
			}
		}

		private int? _editionNumber  = default;

		[Description("Edition of the ENC being referenced.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? editionNumber {
			get {
				return _editionNumber;
			}
			set {
				SetValue(ref _editionNumber, value);
			}
		}

		private int? _maximumDisplayScale  = default;

		[Description("The value considered by the Data Producer to be the maximum (largest) scale at which the data is to be displayed before it can be considered to be “grossly overscaled”.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? maximumDisplayScale {
			get {
				return _maximumDisplayScale;
			}
			set {
				SetValue(ref _maximumDisplayScale, value);
			}
		}

		private int? _minimumDisplayScale  = default;

		[Description("The smallest intended viewing scale for the data.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? minimumDisplayScale {
			get {
				return _minimumDisplayScale;
			}
			set {
				SetValue(ref _minimumDisplayScale, value);
			}
		}

		[Description("The navigational purpose of the dataset.")]
		[Category("NavigationalProduct")]
		[PermittedValues([1,2,3])]
		[Multiplicity(0, 3)]
		public ObservableCollection<navigationPurpose> navigationPurpose  { get; set; } = new ();

		private int? _optimumDisplayScale  = default;

		[Description("The largest intended viewing scale for the data.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? optimumDisplayScale {
			get {
				return _optimumDisplayScale;
			}
			set {
				SetValue(ref _optimumDisplayScale, value);
			}
		}

		private String? _originalProductNumber  = default;

		[Description("The original identification of a product that has been re-branded or distributed under multiple identification schemes.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? originalProductNumber {
			get {
				return _originalProductNumber;
			}
			set {
				SetValue(ref _originalProductNumber, value);
			}
		}

		private String? _producerNation  = default;

		[Description("The authority who produced a nautical product.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? producerNation {
			get {
				return _producerNation;
			}
			set {
				SetValue(ref _producerNation, value);
			}
		}

		private String? _productNumber  = default;

		[Description("Product number of a product or service.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? productNumber {
			get {
				return _productNumber;
			}
			set {
				SetValue(ref _productNumber, value);
			}
		}

		private specificUsage? _specificUsage  = default;

		[Description("The use for which the dataset is intended.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6])]
		[Optional]
		public specificUsage? specificUsage {
			get {
				return _specificUsage;
			}
			set {
				SetValue(ref _specificUsage, value);
			}
		}

		private DateOnly? _updateDate  = default;

		[Description("A date referring to the day a product or service was updated.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? updateDate {
			get {
				return _updateDate;
			}
			set {
				SetValue(ref _updateDate, value);
			}
		}

		private int? _updateNumber  = default;

		[Description("Update number of the ENC being referenced.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? updateNumber {
			get {
				return _updateNumber;
			}
			set {
				SetValue(ref _updateNumber, value);
			}
		}

		private horizontalDatumEPSGCode? _horizontalDatumEPSGCode  = default;

		[Description("Horizontal reference as an EPSG code representing a valid entry in the EPSG Geodetic Parameter Dataset, as maintained by the Geodesy Subcommittee of the IOGP Geomatics Committee, and provided online at epsg.org.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public horizontalDatumEPSGCode? horizontalDatumEPSGCode {
			get {
				return _horizontalDatumEPSGCode;
			}
			set {
				SetValue(ref _horizontalDatumEPSGCode, value);
			}
		}

		private verticalDatum? _verticalDatum  = default;

		[Description("The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45])]
		[Optional]
		public verticalDatum? verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		private Boolean? _compressionFlag  = default;

		[Description("Indicates if the resource is compressed.")]
		[Category("ElectronicProduct")]
		//[Editor(typeof(Editors.HorizonEditor<ElectronicProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? compressionFlag {
			get {
				return _compressionFlag;
			}
			set {
				SetValue(ref _compressionFlag, value);
			}
		}

		private String? _datasetName  = default;

		[Description("The name or identification of a dataset.")]
		[Category("ElectronicProduct")]
		//[Editor(typeof(Editors.HorizonEditor<ElectronicProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? datasetName {
			get {
				return _datasetName;
			}
			set {
				SetValue(ref _datasetName, value);
			}
		}

		private DateOnly _issueDate  = default;

		[Description("Date up to which the data was made available by the Data Producer.")]
		[Category("ElectronicProduct")]
		//[Editor(typeof(Editors.HorizonEditor<ElectronicProduct>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public DateOnly issueDate {
			get {
				return _issueDate;
			}
			set {
				SetValue(ref _issueDate, value);
			}
		}

		private S100Framework.DomainModel.S100.Time? _issueTime  = default;

		[Description("Time of day at which the data was made available by the Data Producer.")]
		[Category("ElectronicProduct")]
		//[Editor(typeof(Editors.HorizonEditor<ElectronicProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public S100Framework.DomainModel.S100.Time? issueTime {
			get {
				return _issueTime;
			}
			set {
				SetValue(ref _issueTime, value);
			}
		}

		private typeOfProductFormat _typeOfProductFormat  = default;

		[Description("The type of product format.")]
		[Category("ElectronicProduct")]
		//[Editor(typeof(Editors.HorizonEditor<ElectronicProduct>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12])]
		[Mandatory]
		public typeOfProductFormat typeOfProductFormat {
			get {
				return _typeOfProductFormat;
			}
			set {
				SetValue(ref _typeOfProductFormat, value);
			}
		}

		private productSpecificationViewModel? _productSpecification  = default;

		[Description("The name of the product specification to which a nautical product adheres.")]
		[Category("ElectronicProduct")]
		[ExpandableObject]
		[Optional]
		public productSpecificationViewModel? productSpecification {
			get {
				return _productSpecification;
			}
			set {
				SetValue(ref _productSpecification, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public ElectronicProductViewModel Load(ElectronicProduct instance) {
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.ElectronicProduct.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.ElectronicProduct.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.ElectronicProduct.featureBindingDefinitions;

		public ElectronicProductViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public ElectronicProductViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
	[Description("A product printed on paper.")]
	[CategoryOrder("PhysicalProduct",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PhysicalProductViewModel : FeatureViewModel<PhysicalProduct> {
		private String? _agencyResponsibleForProduction  = default;

		[Description("Identifies the agency which produced the data.")]
		[Category("CatalogueElement")]
		//[Editor(typeof(Editors.HorizonEditor<CatalogueElement>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}

		[Description("Classification of a catalogue element.")]
		[Category("CatalogueElement")]
		[Multiplicity(1)]
		public ObservableCollection<catalogueElementClassification> catalogueElementClassification  { get; set; } = new ();

		private String? _catalogueElementIdentifier  = default;

		[Description("Identifier of a catalogue element.")]
		[Category("CatalogueElement")]
		//[Editor(typeof(Editors.HorizonEditor<CatalogueElement>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? catalogueElementIdentifier {
			get {
				return _catalogueElementIdentifier;
			}
			set {
				SetValue(ref _catalogueElementIdentifier, value);
			}
		}

		private String? _classification  = default;

		[Description("Indicates a classification.")]
		[Category("CatalogueElement")]
		//[Editor(typeof(Editors.HorizonEditor<CatalogueElement>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? classification {
			get {
				return _classification;
			}
			set {
				SetValue(ref _classification, value);
			}
		}

		[Description("A maritime service as identified by the International Maritime Organization (IMO).")]
		[Category("CatalogueElement")]
		[Optional]
		public ObservableCollection<iMOMaritimeService> iMOMaritimeService  { get; set; } = new ();

		private Boolean _notForNavigation  = false;

		[Description("Indicates the dataset is not intended to be used for navigation.")]
		[Category("CatalogueElement")]
		//[Editor(typeof(Editors.HorizonEditor<CatalogueElement>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public Boolean notForNavigation {
			get {
				return _notForNavigation;
			}
			set {
				SetValue(ref _notForNavigation, value);
			}
		}

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("CatalogueElement")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("CatalogueElement")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private onlineResourceViewModel? _onlineResource  = default;

		[Description("Information about online sources from which a resource or data can be obtained.")]
		[Category("CatalogueElement")]
		[ExpandableObject]
		[Optional]
		public onlineResourceViewModel? onlineResource {
			get {
				return _onlineResource;
			}
			set {
				SetValue(ref _onlineResource, value);
			}
		}

		private sourceIndicationViewModel? _sourceIndication  = default;

		[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
		[Category("CatalogueElement")]
		[ExpandableObject]
		[Optional]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}

		[Description("Information on additional files used in addition to nautical products.")]
		[Category("CatalogueElement")]
		[Optional]
		public ObservableCollection<supportFileViewModel> supportFile  { get; set; } = new ();

		private timeIntervalOfProductViewModel? _timeIntervalOfProduct  = default;

		[Description("The temporal interval over which the product is updated or renewed.")]
		[Category("CatalogueElement")]
		[ExpandableObject]
		[Optional]
		public timeIntervalOfProductViewModel? timeIntervalOfProduct {
			get {
				return _timeIntervalOfProduct;
			}
			set {
				SetValue(ref _timeIntervalOfProduct, value);
			}
		}

		[Description("Approximate grid resolution for nautical products.")]
		[Category("NavigationalProduct")]
		[Optional]
		public ObservableCollection<double> approximateGridResolution  { get; set; } = new ();

		[Description("In ECDIS, the scale at which the data was compiled.")]
		[Category("NavigationalProduct")]
		[Optional]
		public ObservableCollection<int> compilationScale  { get; set; } = new ();

		private distributionStatus? _distributionStatus  = default;

		[Description("Supply status of nautical products.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2])]
		[Optional]
		public distributionStatus? distributionStatus {
			get {
				return _distributionStatus;
			}
			set {
				SetValue(ref _distributionStatus, value);
			}
		}

		private int? _editionNumber  = default;

		[Description("Edition of the ENC being referenced.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? editionNumber {
			get {
				return _editionNumber;
			}
			set {
				SetValue(ref _editionNumber, value);
			}
		}

		private int? _maximumDisplayScale  = default;

		[Description("The value considered by the Data Producer to be the maximum (largest) scale at which the data is to be displayed before it can be considered to be “grossly overscaled”.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? maximumDisplayScale {
			get {
				return _maximumDisplayScale;
			}
			set {
				SetValue(ref _maximumDisplayScale, value);
			}
		}

		private int? _minimumDisplayScale  = default;

		[Description("The smallest intended viewing scale for the data.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? minimumDisplayScale {
			get {
				return _minimumDisplayScale;
			}
			set {
				SetValue(ref _minimumDisplayScale, value);
			}
		}

		[Description("The navigational purpose of the dataset.")]
		[Category("NavigationalProduct")]
		[PermittedValues([1,2,3])]
		[Multiplicity(0, 3)]
		public ObservableCollection<navigationPurpose> navigationPurpose  { get; set; } = new ();

		private int? _optimumDisplayScale  = default;

		[Description("The largest intended viewing scale for the data.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? optimumDisplayScale {
			get {
				return _optimumDisplayScale;
			}
			set {
				SetValue(ref _optimumDisplayScale, value);
			}
		}

		private String? _originalProductNumber  = default;

		[Description("The original identification of a product that has been re-branded or distributed under multiple identification schemes.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? originalProductNumber {
			get {
				return _originalProductNumber;
			}
			set {
				SetValue(ref _originalProductNumber, value);
			}
		}

		private String? _producerNation  = default;

		[Description("The authority who produced a nautical product.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? producerNation {
			get {
				return _producerNation;
			}
			set {
				SetValue(ref _producerNation, value);
			}
		}

		private String? _productNumber  = default;

		[Description("Product number of a product or service.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? productNumber {
			get {
				return _productNumber;
			}
			set {
				SetValue(ref _productNumber, value);
			}
		}

		private specificUsage? _specificUsage  = default;

		[Description("The use for which the dataset is intended.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6])]
		[Optional]
		public specificUsage? specificUsage {
			get {
				return _specificUsage;
			}
			set {
				SetValue(ref _specificUsage, value);
			}
		}

		private DateOnly? _updateDate  = default;

		[Description("A date referring to the day a product or service was updated.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? updateDate {
			get {
				return _updateDate;
			}
			set {
				SetValue(ref _updateDate, value);
			}
		}

		private int? _updateNumber  = default;

		[Description("Update number of the ENC being referenced.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? updateNumber {
			get {
				return _updateNumber;
			}
			set {
				SetValue(ref _updateNumber, value);
			}
		}

		private horizontalDatumEPSGCode? _horizontalDatumEPSGCode  = default;

		[Description("Horizontal reference as an EPSG code representing a valid entry in the EPSG Geodetic Parameter Dataset, as maintained by the Geodesy Subcommittee of the IOGP Geomatics Committee, and provided online at epsg.org.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public horizontalDatumEPSGCode? horizontalDatumEPSGCode {
			get {
				return _horizontalDatumEPSGCode;
			}
			set {
				SetValue(ref _horizontalDatumEPSGCode, value);
			}
		}

		private verticalDatum? _verticalDatum  = default;

		[Description("The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.")]
		[Category("NavigationalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalProduct>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45])]
		[Optional]
		public verticalDatum? verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		private DateOnly _editionDate  = default;

		[Description("Date of publishing for example of a publication, chart, or product.")]
		[Category("PhysicalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<PhysicalProduct>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public DateOnly editionDate {
			get {
				return _editionDate;
			}
			set {
				SetValue(ref _editionDate, value);
			}
		}

		private String? _iSBN  = default;

		[Description("International Standard Book Number.")]
		[Category("PhysicalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<PhysicalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iSBN {
			get {
				return _iSBN;
			}
			set {
				SetValue(ref _iSBN, value);
			}
		}

		private String? _publicationNumber  = default;

		[Description("Publication number of a nautical product.")]
		[Category("PhysicalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<PhysicalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? publicationNumber {
			get {
				return _publicationNumber;
			}
			set {
				SetValue(ref _publicationNumber, value);
			}
		}

		private String? _typeOfPhysicalProduct  = default;

		[Description("The type of a physical (navigational) product, usually printed on paper.")]
		[Category("PhysicalProduct")]
		//[Editor(typeof(Editors.HorizonEditor<PhysicalProduct>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? typeOfPhysicalProduct {
			get {
				return _typeOfPhysicalProduct;
			}
			set {
				SetValue(ref _typeOfPhysicalProduct, value);
			}
		}

		private printInformationViewModel? _printInformation  = default;

		[Description("Information on the printing of nautical paper charts.")]
		[Category("PhysicalProduct")]
		[ExpandableObject]
		[Optional]
		public printInformationViewModel? printInformation {
			get {
				return _printInformation;
			}
			set {
				SetValue(ref _printInformation, value);
			}
		}

		private referenceToNMViewModel? _referenceToNM  = default;

		[Description("A reference to a of specific Notice to Mariners.")]
		[Category("PhysicalProduct")]
		[ExpandableObject]
		[Optional]
		public referenceToNMViewModel? referenceToNM {
			get {
				return _referenceToNM;
			}
			set {
				SetValue(ref _referenceToNM, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public PhysicalProductViewModel Load(PhysicalProduct instance) {
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.PhysicalProduct.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.PhysicalProduct.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.PhysicalProduct.featureBindingDefinitions;

		public PhysicalProductViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public PhysicalProductViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
	[Description("A service that makes use of S-100 based product specifications to support data transfer.")]
	[CategoryOrder("S100Service",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class S100ServiceViewModel : FeatureViewModel<S100Service> {
		private String? _agencyResponsibleForProduction  = default;

		[Description("Identifies the agency which produced the data.")]
		[Category("CatalogueElement")]
		//[Editor(typeof(Editors.HorizonEditor<CatalogueElement>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}

		[Description("Classification of a catalogue element.")]
		[Category("CatalogueElement")]
		[Multiplicity(1)]
		public ObservableCollection<catalogueElementClassification> catalogueElementClassification  { get; set; } = new ();

		private String? _catalogueElementIdentifier  = default;

		[Description("Identifier of a catalogue element.")]
		[Category("CatalogueElement")]
		//[Editor(typeof(Editors.HorizonEditor<CatalogueElement>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? catalogueElementIdentifier {
			get {
				return _catalogueElementIdentifier;
			}
			set {
				SetValue(ref _catalogueElementIdentifier, value);
			}
		}

		private String? _classification  = default;

		[Description("Indicates a classification.")]
		[Category("CatalogueElement")]
		//[Editor(typeof(Editors.HorizonEditor<CatalogueElement>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? classification {
			get {
				return _classification;
			}
			set {
				SetValue(ref _classification, value);
			}
		}

		[Description("A maritime service as identified by the International Maritime Organization (IMO).")]
		[Category("CatalogueElement")]
		[Optional]
		public ObservableCollection<iMOMaritimeService> iMOMaritimeService  { get; set; } = new ();

		private Boolean _notForNavigation  = false;

		[Description("Indicates the dataset is not intended to be used for navigation.")]
		[Category("CatalogueElement")]
		//[Editor(typeof(Editors.HorizonEditor<CatalogueElement>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public Boolean notForNavigation {
			get {
				return _notForNavigation;
			}
			set {
				SetValue(ref _notForNavigation, value);
			}
		}

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("CatalogueElement")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("CatalogueElement")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private onlineResourceViewModel? _onlineResource  = default;

		[Description("Information about online sources from which a resource or data can be obtained.")]
		[Category("CatalogueElement")]
		[ExpandableObject]
		[Optional]
		public onlineResourceViewModel? onlineResource {
			get {
				return _onlineResource;
			}
			set {
				SetValue(ref _onlineResource, value);
			}
		}

		private sourceIndicationViewModel? _sourceIndication  = default;

		[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
		[Category("CatalogueElement")]
		[ExpandableObject]
		[Optional]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}

		[Description("Information on additional files used in addition to nautical products.")]
		[Category("CatalogueElement")]
		[Optional]
		public ObservableCollection<supportFileViewModel> supportFile  { get; set; } = new ();

		private timeIntervalOfProductViewModel? _timeIntervalOfProduct  = default;

		[Description("The temporal interval over which the product is updated or renewed.")]
		[Category("CatalogueElement")]
		[ExpandableObject]
		[Optional]
		public timeIntervalOfProductViewModel? timeIntervalOfProduct {
			get {
				return _timeIntervalOfProduct;
			}
			set {
				SetValue(ref _timeIntervalOfProduct, value);
			}
		}

		private Boolean? _compressionFlag  = default;

		[Description("Indicates if the resource is compressed.")]
		[Category("S100Service")]
		//[Editor(typeof(Editors.HorizonEditor<S100Service>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? compressionFlag {
			get {
				return _compressionFlag;
			}
			set {
				SetValue(ref _compressionFlag, value);
			}
		}

		private String? _serviceName  = default;

		[Description("The name of a service.")]
		[Category("S100Service")]
		//[Editor(typeof(Editors.HorizonEditor<S100Service>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? serviceName {
			get {
				return _serviceName;
			}
			set {
				SetValue(ref _serviceName, value);
			}
		}

		private serviceStatus? _serviceStatus  = default;

		[Description("Types of status of services.")]
		[Category("S100Service")]
		//[Editor(typeof(Editors.HorizonEditor<S100Service>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Optional]
		public serviceStatus? serviceStatus {
			get {
				return _serviceStatus;
			}
			set {
				SetValue(ref _serviceStatus, value);
			}
		}

		private typeOfProductFormat _typeOfProductFormat  = default;

		[Description("The type of product format.")]
		[Category("S100Service")]
		//[Editor(typeof(Editors.HorizonEditor<S100Service>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12])]
		[Mandatory]
		public typeOfProductFormat typeOfProductFormat {
			get {
				return _typeOfProductFormat;
			}
			set {
				SetValue(ref _typeOfProductFormat, value);
			}
		}

		private serviceSpecificationViewModel? _serviceSpecification  = default;

		[Description("The name of the (product) specification to which a nautical service adheres.")]
		[Category("S100Service")]
		[ExpandableObject]
		[Optional]
		public serviceSpecificationViewModel? serviceSpecification {
			get {
				return _serviceSpecification;
			}
			set {
				SetValue(ref _serviceSpecification, value);
			}
		}

		private productSpecificationViewModel? _productSpecification  = default;

		[Description("The name of the product specification to which a nautical product adheres.")]
		[Category("S100Service")]
		[ExpandableObject]
		[Optional]
		public productSpecificationViewModel? productSpecification {
			get {
				return _productSpecification;
			}
			set {
				SetValue(ref _productSpecification, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public S100ServiceViewModel Load(S100Service instance) {
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.S100Service.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.S100Service.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.S100Service.featureBindingDefinitions;

		public S100ServiceViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public S100ServiceViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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



	public static class InformationBindingExtension {
		public static CatalogueSectionHeaderViewModel LoadInformationBinding(this CatalogueSectionHeaderViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<PriceOfNauticalProduct> priceOfNauticalProduct) {
					instance.PriceOfNauticalProducts.Add(new InformationRefViewModel {
						informationId = priceOfNauticalProduct.referenceId,
						informationType = priceOfNauticalProduct.informationType,
						role = priceOfNauticalProduct.role,
					});
				}
				if(informationBinding is informationBinding<ProductionDetails> productionDetails) {
					instance.ProductionDetails.Add(new InformationRefViewModel {
						informationId = productionDetails.referenceId,
						informationType = productionDetails.informationType,
						role = productionDetails.role,
					});
				}
				if(informationBinding is informationBinding<DistributionDetails> distributionDetails) {
					instance.DistributionDetails.Add(new InformationRefViewModel {
						informationId = distributionDetails.referenceId,
						informationType = distributionDetails.informationType,
						role = distributionDetails.role,
					});
				}
			}
			return instance;
		}

		public static ContactDetailsViewModel LoadInformationBinding(this ContactDetailsViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ProducerContact> producerContact) {
					instance.ProducerContacts.Add(new InformationRefViewModel {
						informationId = producerContact.referenceId,
						informationType = producerContact.informationType,
						role = producerContact.role,
					});
				}
				if(informationBinding is informationBinding<DistributorContact> distributorContact) {
					instance.DistributorContacts.Add(new InformationRefViewModel {
						informationId = distributorContact.referenceId,
						informationType = distributorContact.informationType,
						role = distributorContact.role,
					});
				}
			}
			return instance;
		}

		public static IndicationOfCarriageRequirementViewModel LoadInformationBinding(this IndicationOfCarriageRequirementViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static PriceInformationViewModel LoadInformationBinding(this PriceInformationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<PriceOfNauticalProduct> priceOfNauticalProduct) {
					instance.PriceOfNauticalProducts.Add(new InformationRefViewModel {
						informationId = priceOfNauticalProduct.referenceId,
						informationType = priceOfNauticalProduct.informationType,
						role = priceOfNauticalProduct.role,
					});
				}
			}
			return instance;
		}

		public static ProducerInformationViewModel LoadInformationBinding(this ProducerInformationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ProducerContact> producerContact) {
					instance.ProducerContacts.Add(new InformationRefViewModel {
						informationId = producerContact.referenceId,
						informationType = producerContact.informationType,
						role = producerContact.role,
					});
				}
				if(informationBinding is informationBinding<ProductionDetails> productionDetails) {
					instance.ProductionDetails.Add(new InformationRefViewModel {
						informationId = productionDetails.referenceId,
						informationType = productionDetails.informationType,
						role = productionDetails.role,
					});
				}
			}
			return instance;
		}

		public static DistributorInformationViewModel LoadInformationBinding(this DistributorInformationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<DistributionDetails> distributionDetails) {
					instance.DistributionDetails.Add(new InformationRefViewModel {
						informationId = distributionDetails.referenceId,
						informationType = distributionDetails.informationType,
						role = distributionDetails.role,
					});
				}
				if(informationBinding is informationBinding<DistributorContact> distributorContact) {
					instance.DistributorContacts.Add(new InformationRefViewModel {
						informationId = distributorContact.referenceId,
						informationType = distributorContact.informationType,
						role = distributorContact.role,
					});
				}
			}
			return instance;
		}

		public static ElectronicProductViewModel LoadInformationBinding(this ElectronicProductViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static PhysicalProductViewModel LoadInformationBinding(this PhysicalProductViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static S100ServiceViewModel LoadInformationBinding(this S100ServiceViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

	}

	public static class FeatureBindingExtension {
		public static ElectronicProductViewModel LoadFeatureBinding(this ElectronicProductViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static PhysicalProductViewModel LoadFeatureBinding(this PhysicalProductViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static S100ServiceViewModel LoadFeatureBinding(this S100ServiceViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

	}

}
