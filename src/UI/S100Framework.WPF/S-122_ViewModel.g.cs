using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ComponentModel;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S122;
using S100Framework.DomainModel.S122.ComplexAttributes;
using S100Framework.DomainModel.S122.InformationTypes;
using S100Framework.DomainModel.S122.FeatureTypes;
using S100Framework.DomainModel.S122.InformationAssociations;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using System.Text.Json;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.WPF.ViewModel.S122 {
	internal static class Bootstrap {
		public static AssociationViewModel CreateInformationAssociation(string type, string? name = default) => type switch {
			"AssociatedRxN" => new AssociatedRxNViewModel { Name = name },
			"ExceptionalWorkday" => new ExceptionalWorkdayViewModel { Name = name },
			"ProtectedAreaAuthority" => new ProtectedAreaAuthorityViewModel { Name = name },
			"ServiceControl" => new ServiceControlViewModel { Name = name },
			"RelatedOrganisation" => new RelatedOrganisationViewModel { Name = name },
			"PermissionType" => new PermissionTypeViewModel { Name = name },
			"InclusionType" => new InclusionTypeViewModel { Name = name },
			"AuthorityContact" => new AuthorityContactViewModel { Name = name },
			"AuthorityHours" => new AuthorityHoursViewModel { Name = name },
			"additionalInformation" => new additionalInformationViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static AssociationViewModel CreateFeatureAssociation(string type, string? name = default) => type switch {
			_ or "" => throw new InvalidOperationException(),
		};

		public static InformationViewModel CreateInformationType(string type, string? name = default) => type switch {
			"InformationType" => new InformationTypeViewModel { Name = name },
			"AbstractRxN" => new AbstractRxNViewModel { Name = name },
			"NauticalInformation" => new NauticalInformationViewModel { Name = name },
			"Regulations" => new RegulationsViewModel { Name = name },
			"Restrictions" => new RestrictionsViewModel { Name = name },
			"Recommendations" => new RecommendationsViewModel { Name = name },
			"Authority" => new AuthorityViewModel { Name = name },
			"ContactDetails" => new ContactDetailsViewModel { Name = name },
			"NonStandardWorkingDay" => new NonStandardWorkingDayViewModel { Name = name },
			"ServiceHours" => new ServiceHoursViewModel { Name = name },
			"Applicability" => new ApplicabilityViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static FeatureViewModel CreateFeatureType(string type, string? name = default) => type switch {
			"RestrictedArea" => new RestrictedAreaViewModel { Name = name },
			"MarineProtectedArea" => new MarineProtectedAreaViewModel { Name = name },
			"VesselTrafficServiceArea" => new VesselTrafficServiceAreaViewModel { Name = name },
			"DataCoverage" => new DataCoverageViewModel { Name = name },
			"TextPlacement" => new TextPlacementViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static ICollection<string> InformationAssociationBindings(string association, string role) => (association, role) switch {
			("RelatedOrganisation", "theOrganisation") => ["Authority"],
			("RelatedOrganisation", "theInformation") => ["AbstractRxN"],
			("AuthorityContact", "theContactDetails") => ["ContactDetails"],
			("AuthorityHours", "theServiceHours") => ["ServiceHours"],
			("AuthorityContact", "theAuthority") => ["Authority"],
			("ExceptionalWorkday", "theServiceHours_nsdy") => ["ServiceHours"],
			("AuthorityHours", "theAuthority_srvHrs") => ["Authority"],
			("ExceptionalWorkday", "partialWorkingDay") => ["NonStandardWorkingDay"],
			("AssociatedRxN", "theRxN") => ["AbstractRxN"],
			("additionalInformation", "providesInformation") => ["NauticalInformation"],
			("ProtectedAreaAuthority", "responsibleAuthority") => ["Authority"],
			("ServiceControl", "controlAuthority") => ["Authority"],
			_ => throw new InvalidOperationException(),
		};

		public static ICollection<string> FeatureAssociationBindings(string association, string role) => (association, role) switch {
			_ => throw new InvalidOperationException(),
		};
	}

	/// <summary>
	/// A bearing is the direction one object is from another object.
	/// </summary>
	[CategoryOrder("bearingInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class bearingInformationViewModel : ComplexViewModel<bearingInformation> {
		private cardinalDirection? _cardinalDirection  = default;

		[Editor(typeof(Editors.HorizonEditor<bearingInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public cardinalDirection? cardinalDirection {
			get {
				return _cardinalDirection;
			}
			set {
				SetValue(ref _cardinalDirection, value);
			}
		}

		[Browsable(false)]
		public cardinalDirection[] cardinalDirectionList => Enum.GetValues<cardinalDirection>();

		private double? _distance  = default;

		[Editor(typeof(Editors.HorizonEditor<bearingInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? distance {
			get {
				return _distance;
			}
			set {
				SetValue(ref _distance, value);
			}
		}

		[Category("bearingInformation")]
		[Multiplicity(0, 2)]
		public ObservableCollection<double> sectorBearing  { get; set; } = new ();

		[Category("bearingInformation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private orientationViewModel? _orientation  = default;

		[Category("bearingInformation")]
		[ExpandableObject]
		[Optional]
		public orientationViewModel? orientation {
			get {
				return _orientation;
			}
			set {
				SetValue(ref _orientation, value);
			}
		}


		public bearingInformationViewModel Load(bearingInformation instance) {
			cardinalDirection = instance.cardinalDirection;
			distance = instance.distance;
			sectorBearing.Clear();
			if (instance.sectorBearing is not null) {
				foreach(var e in instance.sectorBearing)
					sectorBearing.Add(e);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			orientation = new ();
			if (instance.orientation != default) {
				orientation.Load(instance.orientation);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new bearingInformation {
				cardinalDirection = this.cardinalDirection,
				distance = this.distance,
				sectorBearing = this.sectorBearing.ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				orientation = this.orientation?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public bearingInformation Model => new () {
			cardinalDirection = this._cardinalDirection,
			distance = this._distance,
			sectorBearing = this.sectorBearing.ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			orientation = this._orientation?.Model,
		};

		public override string? ToString() => $"Bearing Information";

		public bearingInformationViewModel() : base() {
			sectorBearing.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sectorBearing));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}


	/// <summary>
	/// Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.
	/// </summary>
	[CategoryOrder("contactAddress",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class contactAddressViewModel : ComplexViewModel<contactAddress> {
		private String? _deliveryPoint  = default;

		[Editor(typeof(Editors.HorizonEditor<contactAddress>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? deliveryPoint {
			get {
				return _deliveryPoint;
			}
			set {
				SetValue(ref _deliveryPoint, value);
			}
		}

		private String? _cityName  = default;

		[Editor(typeof(Editors.HorizonEditor<contactAddress>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? cityName {
			get {
				return _cityName;
			}
			set {
				SetValue(ref _cityName, value);
			}
		}

		private String? _administrativeDivision  = default;

		[Editor(typeof(Editors.HorizonEditor<contactAddress>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? administrativeDivision {
			get {
				return _administrativeDivision;
			}
			set {
				SetValue(ref _administrativeDivision, value);
			}
		}

		private String? _countryName  = default;

		[Editor(typeof(Editors.HorizonEditor<contactAddress>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? countryName {
			get {
				return _countryName;
			}
			set {
				SetValue(ref _countryName, value);
			}
		}

		private String? _postalCode  = default;

		[Editor(typeof(Editors.HorizonEditor<contactAddress>), typeof(Editors.HorizonEditor))]
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
			deliveryPoint = instance.deliveryPoint;
			cityName = instance.cityName;
			administrativeDivision = instance.administrativeDivision;
			countryName = instance.countryName;
			postalCode = instance.postalCode;
			return this;
		}

		public override string Serialize() {
			var instance = new contactAddress {
				deliveryPoint = this.deliveryPoint,
				cityName = this.cityName,
				administrativeDivision = this.administrativeDivision,
				countryName = this.countryName,
				postalCode = this.postalCode,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public contactAddress Model => new () {
			deliveryPoint = this._deliveryPoint,
			cityName = this._cityName,
			administrativeDivision = this._administrativeDivision,
			countryName = this._countryName,
			postalCode = this._postalCode,
		};

		public override string? ToString() => $"Contact Address";
	}


	/// <summary>
	/// Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.
	/// </summary>
	[CategoryOrder("featureName",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class featureNameViewModel : ComplexViewModel<featureName> {
		private Boolean? _displayName  = default;

		[Editor(typeof(Editors.HorizonEditor<featureName>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? displayName {
			get {
				return _displayName;
			}
			set {
				SetValue(ref _displayName, value);
			}
		}

		private String _language  = string.Empty;

		[Editor(typeof(Editors.HorizonEditor<featureName>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}

		private String _name  = string.Empty;

		[Editor(typeof(Editors.HorizonEditor<featureName>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String name {
			get {
				return _name;
			}
			set {
				SetValue(ref _name, value);
			}
		}


		public featureNameViewModel Load(featureName instance) {
			displayName = instance.displayName;
			language = instance.language;
			name = instance.name;
			return this;
		}

		public override string Serialize() {
			var instance = new featureName {
				displayName = this.displayName,
				language = this.language,
				name = this.name,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public featureName Model => new () {
			displayName = this._displayName,
			language = this._language,
			name = this._name,
		};

		public override string? ToString() => $"Feature Name";
	}


	/// <summary>
	/// An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.
	/// </summary>
	[CategoryOrder("fixedDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class fixedDateRangeViewModel : ComplexViewModel<fixedDateRange> {
		private String? _dateStart  = default;

		[Editor(typeof(Editors.HorizonEditor<fixedDateRange>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? dateStart {
			get {
				return _dateStart;
			}
			set {
				SetValue(ref _dateStart, value);
			}
		}

		private String? _dateEnd  = default;

		[Editor(typeof(Editors.HorizonEditor<fixedDateRange>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? dateEnd {
			get {
				return _dateEnd;
			}
			set {
				SetValue(ref _dateEnd, value);
			}
		}


		public fixedDateRangeViewModel Load(fixedDateRange instance) {
			dateStart = instance.dateStart;
			dateEnd = instance.dateEnd;
			return this;
		}

		public override string Serialize() {
			var instance = new fixedDateRange {
				dateStart = this.dateStart,
				dateEnd = this.dateEnd,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public fixedDateRange Model => new () {
			dateStart = this._dateStart,
			dateEnd = this._dateEnd,
		};

		public override string? ToString() => $"Fixed Date Range";
	}


	/// <summary>
	/// A pair of frequencies for transmitting and receiving radio signals. The shore station transmits and receives on the frequencies indicated.
	/// </summary>
	[CategoryOrder("frequencyPair",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class frequencyPairViewModel : ComplexViewModel<frequencyPair> {
		private int? _frequencyShoreStationReceives  = default;

		[Editor(typeof(Editors.HorizonEditor<frequencyPair>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? frequencyShoreStationReceives {
			get {
				return _frequencyShoreStationReceives;
			}
			set {
				SetValue(ref _frequencyShoreStationReceives, value);
			}
		}

		private int? _frequencyShoreStationTransmits  = default;

		[Editor(typeof(Editors.HorizonEditor<frequencyPair>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? frequencyShoreStationTransmits {
			get {
				return _frequencyShoreStationTransmits;
			}
			set {
				SetValue(ref _frequencyShoreStationTransmits, value);
			}
		}


		public frequencyPairViewModel Load(frequencyPair instance) {
			frequencyShoreStationReceives = instance.frequencyShoreStationReceives;
			frequencyShoreStationTransmits = instance.frequencyShoreStationTransmits;
			return this;
		}

		public override string Serialize() {
			var instance = new frequencyPair {
				frequencyShoreStationReceives = this.frequencyShoreStationReceives,
				frequencyShoreStationTransmits = this.frequencyShoreStationTransmits,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public frequencyPair Model => new () {
			frequencyShoreStationReceives = this._frequencyShoreStationReceives,
			frequencyShoreStationTransmits = this._frequencyShoreStationTransmits,
		};

		public override string? ToString() => $"Frequency Pair";
	}


	/// <summary>
	/// Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.
	/// </summary>
	[CategoryOrder("graphic",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class graphicViewModel : ComplexViewModel<graphic> {
		[Category("graphic")]
		[Multiplicity(1)]
		public ObservableCollection<String> pictorialRepresentation  { get; set; } = new ();

		private String? _pictureCaption  = default;

		[Editor(typeof(Editors.HorizonEditor<graphic>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictureCaption {
			get {
				return _pictureCaption;
			}
			set {
				SetValue(ref _pictureCaption, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Editor(typeof(Editors.HorizonEditor<graphic>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _pictureInformation  = default;

		[Editor(typeof(Editors.HorizonEditor<graphic>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictureInformation {
			get {
				return _pictureInformation;
			}
			set {
				SetValue(ref _pictureInformation, value);
			}
		}

		private bearingInformationViewModel? _bearingInformation  = default;

		[Category("graphic")]
		[ExpandableObject]
		[Optional]
		public bearingInformationViewModel? bearingInformation {
			get {
				return _bearingInformation;
			}
			set {
				SetValue(ref _bearingInformation, value);
			}
		}


		public graphicViewModel Load(graphic instance) {
			pictorialRepresentation.Clear();
			if (instance.pictorialRepresentation is not null) {
				foreach(var e in instance.pictorialRepresentation)
					pictorialRepresentation.Add(e);
			}
			pictureCaption = instance.pictureCaption;
			sourceDate = instance.sourceDate;
			pictureInformation = instance.pictureInformation;
			bearingInformation = new ();
			if (instance.bearingInformation != default) {
				bearingInformation.Load(instance.bearingInformation);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new graphic {
				pictorialRepresentation = this.pictorialRepresentation.ToList(),
				pictureCaption = this.pictureCaption,
				sourceDate = this.sourceDate,
				pictureInformation = this.pictureInformation,
				bearingInformation = this.bearingInformation?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public graphic Model => new () {
			pictorialRepresentation = this.pictorialRepresentation.ToList(),
			pictureCaption = this._pictureCaption,
			sourceDate = this._sourceDate,
			pictureInformation = this._pictureInformation,
			bearingInformation = this._bearingInformation?.Model,
		};

		public override string? ToString() => $"Graphic";

		public graphicViewModel() : base() {
			pictorialRepresentation.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(pictorialRepresentation));
			};
		}
	}


	/// <summary>
	/// Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.
	/// </summary>
	[CategoryOrder("information",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class informationViewModel : ComplexViewModel<information> {
		private String? _fileLocator  = default;

		[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
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

		[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
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

		[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
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

		[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}

		private String? _text  = default;

		[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
			}
		}


		public informationViewModel Load(information instance) {
			fileLocator = instance.fileLocator;
			fileReference = instance.fileReference;
			headline = instance.headline;
			language = instance.language;
			text = instance.text;
			return this;
		}

		public override string Serialize() {
			var instance = new information {
				fileLocator = this.fileLocator,
				fileReference = this.fileReference,
				headline = this.headline,
				language = this.language,
				text = this.text,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public information Model => new () {
			fileLocator = this._fileLocator,
			fileReference = this._fileReference,
			headline = this._headline,
			language = this._language,
			text = this._text,
		};

		public override string? ToString() => $"Information";
	}


	/// <summary>
	/// Information about online sources from which a resource or data can be obtained.
	/// </summary>
	[CategoryOrder("onlineResource",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class onlineResourceViewModel : ComplexViewModel<onlineResource> {
		private String _onlineResourceLinkageURL  = string.Empty;

		[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String onlineResourceLinkageURL {
			get {
				return _onlineResourceLinkageURL;
			}
			set {
				SetValue(ref _onlineResourceLinkageURL, value);
			}
		}

		private String? _protocol  = default;

		[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? protocol {
			get {
				return _protocol;
			}
			set {
				SetValue(ref _protocol, value);
			}
		}

		private String? _applicationProfile  = default;

		[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? applicationProfile {
			get {
				return _applicationProfile;
			}
			set {
				SetValue(ref _applicationProfile, value);
			}
		}

		private String? _nameOfResource  = default;

		[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? nameOfResource {
			get {
				return _nameOfResource;
			}
			set {
				SetValue(ref _nameOfResource, value);
			}
		}

		private String? _onlineResourceDescription  = default;

		[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? onlineResourceDescription {
			get {
				return _onlineResourceDescription;
			}
			set {
				SetValue(ref _onlineResourceDescription, value);
			}
		}

		private String? _protocolRequest  = default;

		[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? protocolRequest {
			get {
				return _protocolRequest;
			}
			set {
				SetValue(ref _protocolRequest, value);
			}
		}

		private onlineFunction? _onlineFunction  = default;

		[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[Optional]
		public onlineFunction? onlineFunction {
			get {
				return _onlineFunction;
			}
			set {
				SetValue(ref _onlineFunction, value);
			}
		}

		[Browsable(false)]
		public onlineFunction[] onlineFunctionList => Enum.GetValues<onlineFunction>();


		public onlineResourceViewModel Load(onlineResource instance) {
			onlineResourceLinkageURL = instance.onlineResourceLinkageURL;
			protocol = instance.protocol;
			applicationProfile = instance.applicationProfile;
			nameOfResource = instance.nameOfResource;
			onlineResourceDescription = instance.onlineResourceDescription;
			protocolRequest = instance.protocolRequest;
			onlineFunction = instance.onlineFunction;
			return this;
		}

		public override string Serialize() {
			var instance = new onlineResource {
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
		public onlineResource Model => new () {
			onlineResourceLinkageURL = this._onlineResourceLinkageURL,
			protocol = this._protocol,
			applicationProfile = this._applicationProfile,
			nameOfResource = this._nameOfResource,
			onlineResourceDescription = this._onlineResourceDescription,
			protocolRequest = this._protocolRequest,
			onlineFunction = this._onlineFunction,
		};

		public override string? ToString() => $"Online Resource";
	}


	/// <summary>
	/// (1) The angular distance measured from true north to the major axis of the feature. (2) In ECDIS, the mode in which information on the ECDIS is being presented. Typical modes include: north-up - as shown on a nautical chart, north is at the top of the display; Ships head-up - based on the actual heading of the ship, (e.g. Ships gyrocompass); course-up display - based on the course or route being taken.
	/// </summary>
	[CategoryOrder("orientation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class orientationViewModel : ComplexViewModel<orientation> {
		private double? _orientationUncertainty  = default;

		[Editor(typeof(Editors.HorizonEditor<orientation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? orientationUncertainty {
			get {
				return _orientationUncertainty;
			}
			set {
				SetValue(ref _orientationUncertainty, value);
			}
		}

		private double _orientationValue  = default;

		[Editor(typeof(Editors.HorizonEditor<orientation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double orientationValue {
			get {
				return _orientationValue;
			}
			set {
				SetValue(ref _orientationValue, value);
			}
		}


		public orientationViewModel Load(orientation instance) {
			orientationUncertainty = instance.orientationUncertainty;
			orientationValue = instance.orientationValue;
			return this;
		}

		public override string Serialize() {
			var instance = new orientation {
				orientationUncertainty = this.orientationUncertainty,
				orientationValue = this.orientationValue,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public orientation Model => new () {
			orientationUncertainty = this._orientationUncertainty,
			orientationValue = this._orientationValue,
		};

		public override string? ToString() => $"Orientation";
	}


	/// <summary>
	/// The active period of a recurring event or occurrence.
	/// </summary>
	[CategoryOrder("periodicDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class periodicDateRangeViewModel : ComplexViewModel<periodicDateRange> {
		private String _dateStart  = string.Empty;

		[Editor(typeof(Editors.HorizonEditor<periodicDateRange>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String dateStart {
			get {
				return _dateStart;
			}
			set {
				SetValue(ref _dateStart, value);
			}
		}

		private String _dateEnd  = string.Empty;

		[Editor(typeof(Editors.HorizonEditor<periodicDateRange>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String dateEnd {
			get {
				return _dateEnd;
			}
			set {
				SetValue(ref _dateEnd, value);
			}
		}


		public periodicDateRangeViewModel Load(periodicDateRange instance) {
			dateStart = instance.dateStart;
			dateEnd = instance.dateEnd;
			return this;
		}

		public override string Serialize() {
			var instance = new periodicDateRange {
				dateStart = this.dateStart,
				dateEnd = this.dateEnd,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public periodicDateRange Model => new () {
			dateStart = this._dateStart,
			dateEnd = this._dateEnd,
		};

		public override string? ToString() => $"Periodic Date Range";
	}


	/// <summary>
	/// A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.
	/// </summary>
	[CategoryOrder("rxNCode",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class rxNCodeViewModel : ComplexViewModel<rxNCode> {
		private categoryOfRxN? _categoryOfRxN  = default;

		[Editor(typeof(Editors.HorizonEditor<rxNCode>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfRxN? categoryOfRxN {
			get {
				return _categoryOfRxN;
			}
			set {
				SetValue(ref _categoryOfRxN, value);
			}
		}

		private actionOrActivity? _actionOrActivity  = default;

		[Editor(typeof(Editors.HorizonEditor<rxNCode>), typeof(Editors.HorizonEditor))]
		[Optional]
		public actionOrActivity? actionOrActivity {
			get {
				return _actionOrActivity;
			}
			set {
				SetValue(ref _actionOrActivity, value);
			}
		}

		private String? _headline  = default;

		[Editor(typeof(Editors.HorizonEditor<rxNCode>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? headline {
			get {
				return _headline;
			}
			set {
				SetValue(ref _headline, value);
			}
		}


		public rxNCodeViewModel Load(rxNCode instance) {
			categoryOfRxN = instance.categoryOfRxN;
			actionOrActivity = instance.actionOrActivity;
			headline = instance.headline;
			return this;
		}

		public override string Serialize() {
			var instance = new rxNCode {
				categoryOfRxN = this.categoryOfRxN,
				actionOrActivity = this.actionOrActivity,
				headline = this.headline,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public rxNCode Model => new () {
			categoryOfRxN = this._categoryOfRxN,
			actionOrActivity = this._actionOrActivity,
			headline = this._headline,
		};

		public override string? ToString() => $"RxN Code";
	}


	/// <summary>
	/// The nature and timings of a daily schedule by days of the week.
	/// </summary>
	[CategoryOrder("scheduleByDayOfWeek",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class scheduleByDayOfWeekViewModel : ComplexViewModel<scheduleByDayOfWeek> {
		private categoryOfSchedule? _categoryOfSchedule  = default;

		[Editor(typeof(Editors.HorizonEditor<scheduleByDayOfWeek>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfSchedule? categoryOfSchedule {
			get {
				return _categoryOfSchedule;
			}
			set {
				SetValue(ref _categoryOfSchedule, value);
			}
		}

		[Browsable(false)]
		public categoryOfSchedule[] categoryOfScheduleList => [(categoryOfSchedule)1,(categoryOfSchedule)2,(categoryOfSchedule)3];

		[Category("scheduleByDayOfWeek")]
		[Multiplicity(1, 10)]
		public ObservableCollection<timeIntervalsByDayOfWeekViewModel> timeIntervalsByDayOfWeek  { get; set; } = new ();


		public scheduleByDayOfWeekViewModel Load(scheduleByDayOfWeek instance) {
			categoryOfSchedule = instance.categoryOfSchedule;
			timeIntervalsByDayOfWeek.Clear();
			if (instance.timeIntervalsByDayOfWeek is not null) {
				foreach(var e in instance.timeIntervalsByDayOfWeek)
					timeIntervalsByDayOfWeek.Add(new timeIntervalsByDayOfWeekViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new scheduleByDayOfWeek {
				categoryOfSchedule = this.categoryOfSchedule,
				timeIntervalsByDayOfWeek = this.timeIntervalsByDayOfWeek.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public scheduleByDayOfWeek Model => new () {
			categoryOfSchedule = this._categoryOfSchedule,
			timeIntervalsByDayOfWeek = this.timeIntervalsByDayOfWeek.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"Schedule by Day of Week";

		public scheduleByDayOfWeekViewModel() : base() {
			timeIntervalsByDayOfWeek.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(timeIntervalsByDayOfWeek));
			};
		}
	}


	/// <summary>
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. The sector limit specifies the limits of the sector In a clockwise direction around the central feature (for example a light).
	/// </summary>
	[CategoryOrder("sectorLimit",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorLimitViewModel : ComplexViewModel<sectorLimit> {
		private sectorLimitOneViewModel _sectorLimitOne  = default;

		[Category("sectorLimit")]
		[ExpandableObject]
		[Mandatory]
		public sectorLimitOneViewModel sectorLimitOne {
			get {
				return _sectorLimitOne;
			}
			set {
				SetValue(ref _sectorLimitOne, value);
			}
		}

		private sectorLimitTwoViewModel _sectorLimitTwo  = default;

		[Category("sectorLimit")]
		[ExpandableObject]
		[Mandatory]
		public sectorLimitTwoViewModel sectorLimitTwo {
			get {
				return _sectorLimitTwo;
			}
			set {
				SetValue(ref _sectorLimitTwo, value);
			}
		}


		public sectorLimitViewModel Load(sectorLimit instance) {
			sectorLimitOne = new ();
			if (instance.sectorLimitOne != default) {
				sectorLimitOne.Load(instance.sectorLimitOne);
			}
			sectorLimitTwo = new ();
			if (instance.sectorLimitTwo != default) {
				sectorLimitTwo.Load(instance.sectorLimitTwo);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new sectorLimit {
				sectorLimitOne = this.sectorLimitOne?.Model,
				sectorLimitTwo = this.sectorLimitTwo?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public sectorLimit Model => new () {
			sectorLimitOne = this._sectorLimitOne?.Model,
			sectorLimitTwo = this._sectorLimitTwo?.Model,
		};

		public override string? ToString() => $"Sector Limit";
	}


	/// <summary>
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit one specifies the first limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).
	/// </summary>
	[CategoryOrder("sectorLimitOne",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorLimitOneViewModel : ComplexViewModel<sectorLimitOne> {
		private double _sectorBearing  = default;

		[Editor(typeof(Editors.HorizonEditor<sectorLimitOne>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double sectorBearing {
			get {
				return _sectorBearing;
			}
			set {
				SetValue(ref _sectorBearing, value);
			}
		}

		private int? _sectorLineLength  = default;

		[Editor(typeof(Editors.HorizonEditor<sectorLimitOne>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? sectorLineLength {
			get {
				return _sectorLineLength;
			}
			set {
				SetValue(ref _sectorLineLength, value);
			}
		}


		public sectorLimitOneViewModel Load(sectorLimitOne instance) {
			sectorBearing = instance.sectorBearing;
			sectorLineLength = instance.sectorLineLength;
			return this;
		}

		public override string Serialize() {
			var instance = new sectorLimitOne {
				sectorBearing = this.sectorBearing,
				sectorLineLength = this.sectorLineLength,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public sectorLimitOne Model => new () {
			sectorBearing = this._sectorBearing,
			sectorLineLength = this._sectorLineLength,
		};

		public override string? ToString() => $"Sector Limit One";
	}


	/// <summary>
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit two specifies the second limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).
	/// </summary>
	[CategoryOrder("sectorLimitTwo",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorLimitTwoViewModel : ComplexViewModel<sectorLimitTwo> {
		private double _sectorBearing  = default;

		[Editor(typeof(Editors.HorizonEditor<sectorLimitTwo>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double sectorBearing {
			get {
				return _sectorBearing;
			}
			set {
				SetValue(ref _sectorBearing, value);
			}
		}

		private int? _sectorLineLength  = default;

		[Editor(typeof(Editors.HorizonEditor<sectorLimitTwo>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? sectorLineLength {
			get {
				return _sectorLineLength;
			}
			set {
				SetValue(ref _sectorLineLength, value);
			}
		}


		public sectorLimitTwoViewModel Load(sectorLimitTwo instance) {
			sectorBearing = instance.sectorBearing;
			sectorLineLength = instance.sectorLineLength;
			return this;
		}

		public override string Serialize() {
			var instance = new sectorLimitTwo {
				sectorBearing = this.sectorBearing,
				sectorLineLength = this.sectorLineLength,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public sectorLimitTwo Model => new () {
			sectorBearing = this._sectorBearing,
			sectorLineLength = this._sectorLineLength,
		};

		public override string? ToString() => $"Sector Limit Two";
	}


	/// <summary>
	/// A means or channel of communicating at a distance by electrical or electromagnetic means such as telegraphy, telephony, or broadcasting.
	/// </summary>
	[CategoryOrder("telecommunications",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class telecommunicationsViewModel : ComplexViewModel<telecommunications> {
		private categoryOfCommunicationPreference? _categoryOfCommunicationPreference  = default;

		[Editor(typeof(Editors.HorizonEditor<telecommunications>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfCommunicationPreference? categoryOfCommunicationPreference {
			get {
				return _categoryOfCommunicationPreference;
			}
			set {
				SetValue(ref _categoryOfCommunicationPreference, value);
			}
		}

		[Browsable(false)]
		public categoryOfCommunicationPreference[] categoryOfCommunicationPreferenceList => [(categoryOfCommunicationPreference)1,(categoryOfCommunicationPreference)2,(categoryOfCommunicationPreference)3,(categoryOfCommunicationPreference)4];

		private String? _contactInstructions  = default;

		[Editor(typeof(Editors.HorizonEditor<telecommunications>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? contactInstructions {
			get {
				return _contactInstructions;
			}
			set {
				SetValue(ref _contactInstructions, value);
			}
		}

		private String? _telecomCarrier  = default;

		[Editor(typeof(Editors.HorizonEditor<telecommunications>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? telecomCarrier {
			get {
				return _telecomCarrier;
			}
			set {
				SetValue(ref _telecomCarrier, value);
			}
		}

		private String _telecommunicationIdentifier  = string.Empty;

		[Editor(typeof(Editors.HorizonEditor<telecommunications>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String telecommunicationIdentifier {
			get {
				return _telecommunicationIdentifier;
			}
			set {
				SetValue(ref _telecommunicationIdentifier, value);
			}
		}

		private telecommunicationService? _telecommunicationService  = default;

		[Editor(typeof(Editors.HorizonEditor<telecommunications>), typeof(Editors.HorizonEditor))]
		[Optional]
		public telecommunicationService? telecommunicationService {
			get {
				return _telecommunicationService;
			}
			set {
				SetValue(ref _telecommunicationService, value);
			}
		}

		[Browsable(false)]
		public telecommunicationService[] telecommunicationServiceList => [(telecommunicationService)1,(telecommunicationService)2,(telecommunicationService)3,(telecommunicationService)4,(telecommunicationService)5,(telecommunicationService)6,(telecommunicationService)7,(telecommunicationService)8];

		private scheduleByDayOfWeekViewModel? _scheduleByDayOfWeek  = default;

		[Category("telecommunications")]
		[ExpandableObject]
		[Optional]
		public scheduleByDayOfWeekViewModel? scheduleByDayOfWeek {
			get {
				return _scheduleByDayOfWeek;
			}
			set {
				SetValue(ref _scheduleByDayOfWeek, value);
			}
		}


		public telecommunicationsViewModel Load(telecommunications instance) {
			categoryOfCommunicationPreference = instance.categoryOfCommunicationPreference;
			contactInstructions = instance.contactInstructions;
			telecomCarrier = instance.telecomCarrier;
			telecommunicationIdentifier = instance.telecommunicationIdentifier;
			telecommunicationService = instance.telecommunicationService;
			scheduleByDayOfWeek = new ();
			if (instance.scheduleByDayOfWeek != default) {
				scheduleByDayOfWeek.Load(instance.scheduleByDayOfWeek);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new telecommunications {
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
		public telecommunications Model => new () {
			categoryOfCommunicationPreference = this._categoryOfCommunicationPreference,
			contactInstructions = this._contactInstructions,
			telecomCarrier = this._telecomCarrier,
			telecommunicationIdentifier = this._telecommunicationIdentifier,
			telecommunicationService = this._telecommunicationService,
			scheduleByDayOfWeek = this._scheduleByDayOfWeek?.Model,
		};

		public override string? ToString() => $"Telecommunications";
	}


	/// <summary>
	/// Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.
	/// </summary>
	[CategoryOrder("textContent",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class textContentViewModel : ComplexViewModel<textContent> {
		private categoryOfText? _categoryOfText  = default;

		[Editor(typeof(Editors.HorizonEditor<textContent>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfText? categoryOfText {
			get {
				return _categoryOfText;
			}
			set {
				SetValue(ref _categoryOfText, value);
			}
		}

		[Browsable(false)]
		public categoryOfText[] categoryOfTextList => [(categoryOfText)1,(categoryOfText)2,(categoryOfText)3];

		private String? _source  = default;

		[Editor(typeof(Editors.HorizonEditor<textContent>), typeof(Editors.HorizonEditor))]
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

		[Editor(typeof(Editors.HorizonEditor<textContent>), typeof(Editors.HorizonEditor))]
		[Optional]
		public sourceType? sourceType {
			get {
				return _sourceType;
			}
			set {
				SetValue(ref _sourceType, value);
			}
		}

		[Browsable(false)]
		public sourceType[] sourceTypeList => [(sourceType)1,(sourceType)2,(sourceType)7,(sourceType)8,(sourceType)9,(sourceType)10,(sourceType)11,(sourceType)12,(sourceType)13,(sourceType)14];

		private String? _reportedDate  = default;

		[Editor(typeof(Editors.HorizonEditor<textContent>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}


		public textContentViewModel Load(textContent instance) {
			categoryOfText = instance.categoryOfText;
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			return this;
		}

		public override string Serialize() {
			var instance = new textContent {
				categoryOfText = this.categoryOfText,
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public textContent Model => new () {
			categoryOfText = this._categoryOfText,
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
		};

		public override string? ToString() => $"Text Content";
	}


	/// <summary>
	/// The regular weekly operation times of a service or schedule.
	/// </summary>
	[CategoryOrder("timeIntervalsByDayOfWeek",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class timeIntervalsByDayOfWeekViewModel : ComplexViewModel<timeIntervalsByDayOfWeek> {
		[Category("timeIntervalsByDayOfWeek")]
		[Multiplicity(0, 7)]
		public ObservableCollection<dayOfWeek> dayOfWeek  { get; set; } = new ();

		[Browsable(false)]
		public dayOfWeek[] dayOfWeekList => [(dayOfWeek)1,(dayOfWeek)2,(dayOfWeek)3,(dayOfWeek)4,(dayOfWeek)5,(dayOfWeek)6,(dayOfWeek)7];

		private Boolean? _dayOfWeekIsRange  = default;

		[Editor(typeof(Editors.HorizonEditor<timeIntervalsByDayOfWeek>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? dayOfWeekIsRange {
			get {
				return _dayOfWeekIsRange;
			}
			set {
				SetValue(ref _dayOfWeekIsRange, value);
			}
		}

		[Category("timeIntervalsByDayOfWeek")]
		[Multiplicity(0, 99)]
		public ObservableCollection<S100Framework.DomainModel.S100.Time> timeOfDayEnd  { get; set; } = new ();

		[Category("timeIntervalsByDayOfWeek")]
		[Multiplicity(0, 99)]
		public ObservableCollection<S100Framework.DomainModel.S100.Time> timeOfDayStart  { get; set; } = new ();


		public timeIntervalsByDayOfWeekViewModel Load(timeIntervalsByDayOfWeek instance) {
			dayOfWeek.Clear();
			if (instance.dayOfWeek is not null) {
				foreach(var e in instance.dayOfWeek)
					dayOfWeek.Add(e);
			}
			dayOfWeekIsRange = instance.dayOfWeekIsRange;
			timeOfDayEnd.Clear();
			if (instance.timeOfDayEnd is not null) {
				foreach(var e in instance.timeOfDayEnd)
					timeOfDayEnd.Add(e);
			}
			timeOfDayStart.Clear();
			if (instance.timeOfDayStart is not null) {
				foreach(var e in instance.timeOfDayStart)
					timeOfDayStart.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new timeIntervalsByDayOfWeek {
				dayOfWeek = this.dayOfWeek.ToList(),
				dayOfWeekIsRange = this.dayOfWeekIsRange,
				timeOfDayEnd = this.timeOfDayEnd.ToList(),
				timeOfDayStart = this.timeOfDayStart.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public timeIntervalsByDayOfWeek Model => new () {
			dayOfWeek = this.dayOfWeek.ToList(),
			dayOfWeekIsRange = this._dayOfWeekIsRange,
			timeOfDayEnd = this.timeOfDayEnd.ToList(),
			timeOfDayStart = this.timeOfDayStart.ToList(),
		};

		public override string? ToString() => $"Time Intervals by Day of Week";

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
	}


	/// <summary>
	/// Values, discovered by measuring, that correspond to vessels characteristics.
	/// </summary>
	[CategoryOrder("vesselsMeasurements",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class vesselsMeasurementsViewModel : ComplexViewModel<vesselsMeasurements> {
		private vesselsCharacteristics _vesselsCharacteristics  = default;

		[Editor(typeof(Editors.HorizonEditor<vesselsMeasurements>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public vesselsCharacteristics vesselsCharacteristics {
			get {
				return _vesselsCharacteristics;
			}
			set {
				SetValue(ref _vesselsCharacteristics, value);
			}
		}

		[Browsable(false)]
		public vesselsCharacteristics[] vesselsCharacteristicsList => [(vesselsCharacteristics)1,(vesselsCharacteristics)2,(vesselsCharacteristics)3,(vesselsCharacteristics)4,(vesselsCharacteristics)6,(vesselsCharacteristics)7,(vesselsCharacteristics)8,(vesselsCharacteristics)9,(vesselsCharacteristics)10,(vesselsCharacteristics)11,(vesselsCharacteristics)12,(vesselsCharacteristics)13];

		private double _vesselsCharacteristicsValue  = default;

		[Editor(typeof(Editors.HorizonEditor<vesselsMeasurements>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double vesselsCharacteristicsValue {
			get {
				return _vesselsCharacteristicsValue;
			}
			set {
				SetValue(ref _vesselsCharacteristicsValue, value);
			}
		}

		private vesselsCharacteristicsUnit _vesselsCharacteristicsUnit  = default;

		[Editor(typeof(Editors.HorizonEditor<vesselsMeasurements>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public vesselsCharacteristicsUnit vesselsCharacteristicsUnit {
			get {
				return _vesselsCharacteristicsUnit;
			}
			set {
				SetValue(ref _vesselsCharacteristicsUnit, value);
			}
		}

		[Browsable(false)]
		public vesselsCharacteristicsUnit[] vesselsCharacteristicsUnitList => [(vesselsCharacteristicsUnit)3,(vesselsCharacteristicsUnit)4,(vesselsCharacteristicsUnit)5,(vesselsCharacteristicsUnit)6,(vesselsCharacteristicsUnit)7,(vesselsCharacteristicsUnit)9];

		private comparisonOperator _comparisonOperator  = default;

		[Editor(typeof(Editors.HorizonEditor<vesselsMeasurements>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public comparisonOperator comparisonOperator {
			get {
				return _comparisonOperator;
			}
			set {
				SetValue(ref _comparisonOperator, value);
			}
		}

		[Browsable(false)]
		public comparisonOperator[] comparisonOperatorList => [(comparisonOperator)1,(comparisonOperator)2,(comparisonOperator)3,(comparisonOperator)4,(comparisonOperator)5,(comparisonOperator)6];


		public vesselsMeasurementsViewModel Load(vesselsMeasurements instance) {
			vesselsCharacteristics = instance.vesselsCharacteristics;
			vesselsCharacteristicsValue = instance.vesselsCharacteristicsValue;
			vesselsCharacteristicsUnit = instance.vesselsCharacteristicsUnit;
			comparisonOperator = instance.comparisonOperator;
			return this;
		}

		public override string Serialize() {
			var instance = new vesselsMeasurements {
				vesselsCharacteristics = this.vesselsCharacteristics,
				vesselsCharacteristicsValue = this.vesselsCharacteristicsValue,
				vesselsCharacteristicsUnit = this.vesselsCharacteristicsUnit,
				comparisonOperator = this.comparisonOperator,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public vesselsMeasurements Model => new () {
			vesselsCharacteristics = this._vesselsCharacteristics,
			vesselsCharacteristicsValue = this._vesselsCharacteristicsValue,
			vesselsCharacteristicsUnit = this._vesselsCharacteristicsUnit,
			comparisonOperator = this._comparisonOperator,
		};

		public override string? ToString() => $"Vessels Measurements";
	}


	/// <summary>
	/// An official name, title or description. This can be an identifier itself, or an identifier which is an instance of a named designation scheme.
	/// </summary>
	[CategoryOrder("designation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class designationViewModel : ComplexViewModel<designation> {
		private String? _designationScheme  = default;

		[Editor(typeof(Editors.HorizonEditor<designation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? designationScheme {
			get {
				return _designationScheme;
			}
			set {
				SetValue(ref _designationScheme, value);
			}
		}

		private String? _designationIdentifier  = default;

		[Editor(typeof(Editors.HorizonEditor<designation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? designationIdentifier {
			get {
				return _designationIdentifier;
			}
			set {
				SetValue(ref _designationIdentifier, value);
			}
		}

		private jurisdiction? _jurisdiction  = default;

		[Editor(typeof(Editors.HorizonEditor<designation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public jurisdiction? jurisdiction {
			get {
				return _jurisdiction;
			}
			set {
				SetValue(ref _jurisdiction, value);
			}
		}

		[Browsable(false)]
		public jurisdiction[] jurisdictionList => Enum.GetValues<jurisdiction>();

		private String? _text  = default;

		[Editor(typeof(Editors.HorizonEditor<designation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
			}
		}


		public designationViewModel Load(designation instance) {
			designationScheme = instance.designationScheme;
			designationIdentifier = instance.designationIdentifier;
			jurisdiction = instance.jurisdiction;
			text = instance.text;
			return this;
		}

		public override string Serialize() {
			var instance = new designation {
				designationScheme = this.designationScheme,
				designationIdentifier = this.designationIdentifier,
				jurisdiction = this.jurisdiction,
				text = this.text,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public designation Model => new () {
			designationScheme = this._designationScheme,
			designationIdentifier = this._designationIdentifier,
			jurisdiction = this._jurisdiction,
			text = this._text,
		};

		public override string? ToString() => $"designation";
	}



	/// <summary>
	/// Association between a geographic location and a regulation, restriction, recommendation, or nautical information
	/// </summary>
	[CategoryOrder("AssociatedRxN",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AssociatedRxNViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new AssociatedRxN {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Associated RxN";
	}



	/// <summary>
	/// Exception to the usual working day
	/// </summary>
	[CategoryOrder("ExceptionalWorkday",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ExceptionalWorkdayViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new ExceptionalWorkday {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Exceptional workday";
	}



	/// <summary>
	/// There may be more than one such authority depending on how responsibilities are divided
	/// </summary>
	[CategoryOrder("ProtectedAreaAuthority",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ProtectedAreaAuthorityViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new ProtectedAreaAuthority {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Protected area authority";
	}



	/// <summary>
	/// The controlling authority for a service area
	/// </summary>
	[CategoryOrder("ServiceControl",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceControlViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new ServiceControl {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Service control";
	}



	/// <summary>
	/// Related organisation
	/// </summary>
	[CategoryOrder("RelatedOrganisation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RelatedOrganisationViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new RelatedOrganisation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Related organisation";
	}



	/// <summary>
	/// Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit, enter, or use a feature.
	/// </summary>
	[CategoryOrder("PermissionType",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PermissionTypeViewModel : InformationAssociationViewModel {
		private categoryOfRelationship _categoryOfRelationship  = default;

		[Category("PermissionType")]
		[Editor(typeof(Editors.HorizonEditor<PermissionType>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public categoryOfRelationship categoryOfRelationship {
			get {
				return _categoryOfRelationship;
			}
			set {
				SetValue(ref _categoryOfRelationship, value);
			}
		}

		[Browsable(false)]
		public categoryOfRelationship[] categoryOfRelationshipList => Enum.GetValues<categoryOfRelationship>();


		public override string Serialize() {
			var instance = new PermissionType {
				categoryOfRelationship = this.categoryOfRelationship,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Permission Type";
	}



	/// <summary>
	/// Association class specifying the relationship between the subset of vessels described by an APPLIC data object and a regulation (restriction, recommendation, or nautical information).
	/// </summary>
	[CategoryOrder("InclusionType",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class InclusionTypeViewModel : InformationAssociationViewModel {
		private membership _membership  = default;

		[Category("InclusionType")]
		[Editor(typeof(Editors.HorizonEditor<InclusionType>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public membership membership {
			get {
				return _membership;
			}
			set {
				SetValue(ref _membership, value);
			}
		}

		[Browsable(false)]
		public membership[] membershipList => Enum.GetValues<membership>();


		public override string Serialize() {
			var instance = new InclusionType {
				membership = this.membership,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Inclusion Type";
	}



	/// <summary>
	/// -
	/// </summary>
	[CategoryOrder("AuthorityContact",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AuthorityContactViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new AuthorityContact {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Authority Contact";
	}



	/// <summary>
	/// -
	/// </summary>
	[CategoryOrder("AuthorityHours",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AuthorityHoursViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new AuthorityHours {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Authority Hours";
	}



	/// <summary>
	/// -
	/// </summary>
	[CategoryOrder("additionalInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class additionalInformationViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new additionalInformation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Additional Information";
	}




	/// <summary>
	/// Generalized information type which carries all the common attributes.
	/// </summary>
	[CategoryOrder("InformationType",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class InformationTypeViewModel : InformationViewModel<InformationType> {
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public sourceType? sourceType {
			get {
				return _sourceType;
			}
			set {
				SetValue(ref _sourceType, value);
			}
		}

		[Browsable(false)]
		public sourceType[] sourceTypeList => [(sourceType)1,(sourceType)2,(sourceType)7,(sourceType)8,(sourceType)9,(sourceType)10,(sourceType)11,(sourceType)12,(sourceType)13,(sourceType)14];

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}


		public InformationTypeViewModel Load(InformationType instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			return this;
		}

		public override string Serialize() {
			var instance = new InformationType {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public InformationType Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationType._informationBindingDefinitions;

		public InformationTypeViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Information Type";

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
	}



	/// <summary>
	/// An abstract superclass for information types that encode rules, recommendations, and general information in text or graphic form.
	/// </summary>
	[CategoryOrder("AbstractRxN",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AbstractRxNViewModel : InformationViewModel<AbstractRxN> {
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public sourceType? sourceType {
			get {
				return _sourceType;
			}
			set {
				SetValue(ref _sourceType, value);
			}
		}

		[Browsable(false)]
		public sourceType[] sourceTypeList => [(sourceType)1,(sourceType)2,(sourceType)7,(sourceType)8,(sourceType)9,(sourceType)10,(sourceType)11,(sourceType)12,(sourceType)13,(sourceType)14];

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Category("AbstractRxN")]
		[Editor(typeof(Editors.HorizonEditor<AbstractRxN>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		[Browsable(false)]
		public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2,(categoryOfAuthority)3,(categoryOfAuthority)4,(categoryOfAuthority)5,(categoryOfAuthority)6,(categoryOfAuthority)7,(categoryOfAuthority)8,(categoryOfAuthority)9,(categoryOfAuthority)10,(categoryOfAuthority)11,(categoryOfAuthority)12,(categoryOfAuthority)13,(categoryOfAuthority)14,(categoryOfAuthority)15,(categoryOfAuthority)16];

		private textContentViewModel? _textContent  = default;

		[Category("AbstractRxN")]
		[ExpandableObject]
		[Optional]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}

		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();


		#region InformationBindings

		public class RelatedOrganisationViewModel : S100Framework.WPF.ViewModel.S122.RelatedOrganisationViewModel, IInformationBindings {
			public RelatedOrganisationViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "RelatedOrganisation",
					role = "theOrganisation",
					roleType = roleType.association,
					informationTypes = ["Authority"],
				},
			];
		}

		[Category("InformationBindings")]
		public ObservableCollection<AbstractRxNViewModel.RelatedOrganisationViewModel> RelatedOrganisations { get; set; } = new();
		#endregion


		public AbstractRxNViewModel Load(AbstractRxN instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			categoryOfAuthority = instance.categoryOfAuthority;
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new AbstractRxN {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				categoryOfAuthority = this.categoryOfAuthority,
				textContent = this.textContent?.Model,
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AbstractRxN Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			categoryOfAuthority = this._categoryOfAuthority,
			textContent = this._textContent?.Model,
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => AbstractRxN._informationBindingDefinitions;

		public AbstractRxNViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"AbstractRxN";

		public AbstractRxNViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(graphic));
			};
			rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(rxNCode));
			};
		}
	}



	/// <summary>
	/// Nautical information about a related area or facility.
	/// </summary>
	[CategoryOrder("NauticalInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NauticalInformationViewModel : InformationViewModel<NauticalInformation> {
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public sourceType? sourceType {
			get {
				return _sourceType;
			}
			set {
				SetValue(ref _sourceType, value);
			}
		}

		[Browsable(false)]
		public sourceType[] sourceTypeList => [(sourceType)1,(sourceType)2,(sourceType)7,(sourceType)8,(sourceType)9,(sourceType)10,(sourceType)11,(sourceType)12,(sourceType)13,(sourceType)14];

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Category("AbstractRxN")]
		[Editor(typeof(Editors.HorizonEditor<AbstractRxN>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		[Browsable(false)]
		public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2,(categoryOfAuthority)3,(categoryOfAuthority)4,(categoryOfAuthority)5,(categoryOfAuthority)6,(categoryOfAuthority)7,(categoryOfAuthority)8,(categoryOfAuthority)9,(categoryOfAuthority)10,(categoryOfAuthority)11,(categoryOfAuthority)12,(categoryOfAuthority)13,(categoryOfAuthority)14,(categoryOfAuthority)15,(categoryOfAuthority)16];

		private textContentViewModel? _textContent  = default;

		[Category("AbstractRxN")]
		[ExpandableObject]
		[Optional]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}

		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();



		#region InformationBindings

		public class RelatedOrganisationViewModel : S100Framework.WPF.ViewModel.S122.RelatedOrganisationViewModel, IInformationBindings {
			public RelatedOrganisationViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "RelatedOrganisation",
					role = "theOrganisation",
					roleType = roleType.association,
					informationTypes = ["Authority"],
				},
			];
		}

		[Category("InformationBindings")]
		public ObservableCollection<NauticalInformationViewModel.RelatedOrganisationViewModel> RelatedOrganisations { get; set; } = new();
		#endregion


		public NauticalInformationViewModel Load(NauticalInformation instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			categoryOfAuthority = instance.categoryOfAuthority;
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new NauticalInformation {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				categoryOfAuthority = this.categoryOfAuthority,
				textContent = this.textContent?.Model,
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public NauticalInformation Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			categoryOfAuthority = this._categoryOfAuthority,
			textContent = this._textContent?.Model,
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => NauticalInformation._informationBindingDefinitions;

		public NauticalInformationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Nautical Information";

		public NauticalInformationViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(graphic));
			};
			rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(rxNCode));
			};
		}
	}



	/// <summary>
	/// Regulations for a related area or facility.
	/// </summary>
	[CategoryOrder("Regulations",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RegulationsViewModel : InformationViewModel<Regulations> {
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public sourceType? sourceType {
			get {
				return _sourceType;
			}
			set {
				SetValue(ref _sourceType, value);
			}
		}

		[Browsable(false)]
		public sourceType[] sourceTypeList => [(sourceType)1,(sourceType)2,(sourceType)7,(sourceType)8,(sourceType)9,(sourceType)10,(sourceType)11,(sourceType)12,(sourceType)13,(sourceType)14];

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Category("AbstractRxN")]
		[Editor(typeof(Editors.HorizonEditor<AbstractRxN>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		[Browsable(false)]
		public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2,(categoryOfAuthority)3,(categoryOfAuthority)4,(categoryOfAuthority)5,(categoryOfAuthority)6,(categoryOfAuthority)7,(categoryOfAuthority)8,(categoryOfAuthority)9,(categoryOfAuthority)10,(categoryOfAuthority)11,(categoryOfAuthority)12,(categoryOfAuthority)13,(categoryOfAuthority)14,(categoryOfAuthority)15,(categoryOfAuthority)16];

		private textContentViewModel? _textContent  = default;

		[Category("AbstractRxN")]
		[ExpandableObject]
		[Optional]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}

		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();



		public RegulationsViewModel Load(Regulations instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			categoryOfAuthority = instance.categoryOfAuthority;
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Regulations {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				categoryOfAuthority = this.categoryOfAuthority,
				textContent = this.textContent?.Model,
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Regulations Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			categoryOfAuthority = this._categoryOfAuthority,
			textContent = this._textContent?.Model,
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Regulations._informationBindingDefinitions;

		public RegulationsViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Regulations";

		public RegulationsViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(graphic));
			};
			rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(rxNCode));
			};
		}
	}



	/// <summary>
	/// Restrictions for a related area or facility.
	/// </summary>
	[CategoryOrder("Restrictions",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RestrictionsViewModel : InformationViewModel<Restrictions> {
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public sourceType? sourceType {
			get {
				return _sourceType;
			}
			set {
				SetValue(ref _sourceType, value);
			}
		}

		[Browsable(false)]
		public sourceType[] sourceTypeList => [(sourceType)1,(sourceType)2,(sourceType)7,(sourceType)8,(sourceType)9,(sourceType)10,(sourceType)11,(sourceType)12,(sourceType)13,(sourceType)14];

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Category("AbstractRxN")]
		[Editor(typeof(Editors.HorizonEditor<AbstractRxN>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		[Browsable(false)]
		public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2,(categoryOfAuthority)3,(categoryOfAuthority)4,(categoryOfAuthority)5,(categoryOfAuthority)6,(categoryOfAuthority)7,(categoryOfAuthority)8,(categoryOfAuthority)9,(categoryOfAuthority)10,(categoryOfAuthority)11,(categoryOfAuthority)12,(categoryOfAuthority)13,(categoryOfAuthority)14,(categoryOfAuthority)15,(categoryOfAuthority)16];

		private textContentViewModel? _textContent  = default;

		[Category("AbstractRxN")]
		[ExpandableObject]
		[Optional]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}

		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();



		public RestrictionsViewModel Load(Restrictions instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			categoryOfAuthority = instance.categoryOfAuthority;
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Restrictions {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				categoryOfAuthority = this.categoryOfAuthority,
				textContent = this.textContent?.Model,
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Restrictions Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			categoryOfAuthority = this._categoryOfAuthority,
			textContent = this._textContent?.Model,
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Restrictions._informationBindingDefinitions;

		public RestrictionsViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Restrictions";

		public RestrictionsViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(graphic));
			};
			rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(rxNCode));
			};
		}
	}



	/// <summary>
	/// Recommendations for a related area or facility.
	/// </summary>
	[CategoryOrder("Recommendations",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RecommendationsViewModel : InformationViewModel<Recommendations> {
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public sourceType? sourceType {
			get {
				return _sourceType;
			}
			set {
				SetValue(ref _sourceType, value);
			}
		}

		[Browsable(false)]
		public sourceType[] sourceTypeList => [(sourceType)1,(sourceType)2,(sourceType)7,(sourceType)8,(sourceType)9,(sourceType)10,(sourceType)11,(sourceType)12,(sourceType)13,(sourceType)14];

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Category("AbstractRxN")]
		[Editor(typeof(Editors.HorizonEditor<AbstractRxN>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		[Browsable(false)]
		public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2,(categoryOfAuthority)3,(categoryOfAuthority)4,(categoryOfAuthority)5,(categoryOfAuthority)6,(categoryOfAuthority)7,(categoryOfAuthority)8,(categoryOfAuthority)9,(categoryOfAuthority)10,(categoryOfAuthority)11,(categoryOfAuthority)12,(categoryOfAuthority)13,(categoryOfAuthority)14,(categoryOfAuthority)15,(categoryOfAuthority)16];

		private textContentViewModel? _textContent  = default;

		[Category("AbstractRxN")]
		[ExpandableObject]
		[Optional]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}

		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();



		public RecommendationsViewModel Load(Recommendations instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			categoryOfAuthority = instance.categoryOfAuthority;
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Recommendations {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				categoryOfAuthority = this.categoryOfAuthority,
				textContent = this.textContent?.Model,
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Recommendations Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			categoryOfAuthority = this._categoryOfAuthority,
			textContent = this._textContent?.Model,
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Recommendations._informationBindingDefinitions;

		public RecommendationsViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Recommendations";

		public RecommendationsViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(graphic));
			};
			rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(rxNCode));
			};
		}
	}



	/// <summary>
	/// A person or organisation having political or administrative power and control.
	/// </summary>
	[CategoryOrder("Authority",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AuthorityViewModel : InformationViewModel<Authority> {
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public sourceType? sourceType {
			get {
				return _sourceType;
			}
			set {
				SetValue(ref _sourceType, value);
			}
		}

		[Browsable(false)]
		public sourceType[] sourceTypeList => [(sourceType)1,(sourceType)2,(sourceType)7,(sourceType)8,(sourceType)9,(sourceType)10,(sourceType)11,(sourceType)12,(sourceType)13,(sourceType)14];

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private categoryOfAuthority _categoryOfAuthority  = default;

		[Category("Authority")]
		[Editor(typeof(Editors.HorizonEditor<Authority>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public categoryOfAuthority categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		[Browsable(false)]
		public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2,(categoryOfAuthority)3,(categoryOfAuthority)4,(categoryOfAuthority)5,(categoryOfAuthority)6,(categoryOfAuthority)7,(categoryOfAuthority)8,(categoryOfAuthority)9,(categoryOfAuthority)10,(categoryOfAuthority)11,(categoryOfAuthority)12,(categoryOfAuthority)13,(categoryOfAuthority)14,(categoryOfAuthority)15,(categoryOfAuthority)16];

		[Category("Authority")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		#region InformationBindings

		public class RelatedOrganisationViewModel : S100Framework.WPF.ViewModel.S122.RelatedOrganisationViewModel, IInformationBindings {
			public RelatedOrganisationViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "RelatedOrganisation",
					role = "theInformation",
					roleType = roleType.association,
					informationTypes = ["AbstractRxN"],
				},
			];
		}

		public class AuthorityContactViewModel : S100Framework.WPF.ViewModel.S122.AuthorityContactViewModel, IInformationBindings {
			public AuthorityContactViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "AuthorityContact",
					role = "theContactDetails",
					roleType = roleType.association,
					informationTypes = ["ContactDetails"],
				},
			];
		}

		public class AuthorityHoursViewModel : S100Framework.WPF.ViewModel.S122.AuthorityHoursViewModel, IInformationBindings {
			public AuthorityHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "AuthorityHours",
					role = "theServiceHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
		}

		[Category("InformationBindings")]
		public ObservableCollection<AuthorityViewModel.RelatedOrganisationViewModel> RelatedOrganisations { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<AuthorityViewModel.AuthorityContactViewModel> AuthorityContacts { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<AuthorityViewModel.AuthorityHoursViewModel> AuthorityHours { get; set; } = new();
		#endregion


		public AuthorityViewModel Load(Authority instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			categoryOfAuthority = instance.categoryOfAuthority;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Authority {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				categoryOfAuthority = this.categoryOfAuthority,
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Authority Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			categoryOfAuthority = this._categoryOfAuthority,
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Authority._informationBindingDefinitions;

		public AuthorityViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Authority";

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
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}



	/// <summary>
	/// Information on how to reach a person or organisation by postal, internet, telephone, telex and radio systems.
	/// </summary>
	[CategoryOrder("ContactDetails",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ContactDetailsViewModel : InformationViewModel<ContactDetails> {
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public sourceType? sourceType {
			get {
				return _sourceType;
			}
			set {
				SetValue(ref _sourceType, value);
			}
		}

		[Browsable(false)]
		public sourceType[] sourceTypeList => [(sourceType)1,(sourceType)2,(sourceType)7,(sourceType)8,(sourceType)9,(sourceType)10,(sourceType)11,(sourceType)12,(sourceType)13,(sourceType)14];

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Category("AbstractRxN")]
		[Editor(typeof(Editors.HorizonEditor<AbstractRxN>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		[Browsable(false)]
		public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)2,(categoryOfAuthority)3,(categoryOfAuthority)4,(categoryOfAuthority)5,(categoryOfAuthority)6,(categoryOfAuthority)7,(categoryOfAuthority)8,(categoryOfAuthority)9,(categoryOfAuthority)10,(categoryOfAuthority)11,(categoryOfAuthority)12,(categoryOfAuthority)13,(categoryOfAuthority)14,(categoryOfAuthority)15,(categoryOfAuthority)16];

		private textContentViewModel? _textContent  = default;

		[Category("AbstractRxN")]
		[ExpandableObject]
		[Optional]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}

		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		private String? _callName  = default;

		[Category("ContactDetails")]
		[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? callName {
			get {
				return _callName;
			}
			set {
				SetValue(ref _callName, value);
			}
		}

		private String? _callSign  = default;

		[Category("ContactDetails")]
		[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? callSign {
			get {
				return _callSign;
			}
			set {
				SetValue(ref _callSign, value);
			}
		}

		private categoryOfCommunicationPreference? _categoryOfCommunicationPreference  = default;

		[Category("ContactDetails")]
		[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfCommunicationPreference? categoryOfCommunicationPreference {
			get {
				return _categoryOfCommunicationPreference;
			}
			set {
				SetValue(ref _categoryOfCommunicationPreference, value);
			}
		}

		[Browsable(false)]
		public categoryOfCommunicationPreference[] categoryOfCommunicationPreferenceList => [(categoryOfCommunicationPreference)1,(categoryOfCommunicationPreference)2,(categoryOfCommunicationPreference)3,(categoryOfCommunicationPreference)4];

		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();

		private String? _contactInstructions  = default;

		[Category("ContactDetails")]
		[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? contactInstructions {
			get {
				return _contactInstructions;
			}
			set {
				SetValue(ref _contactInstructions, value);
			}
		}

		private String? _mMSICode  = default;

		[Category("ContactDetails")]
		[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? mMSICode {
			get {
				return _mMSICode;
			}
			set {
				SetValue(ref _mMSICode, value);
			}
		}

		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<int> signalFrequency  { get; set; } = new ();

		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<contactAddressViewModel> contactAddress  { get; set; } = new ();

		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<frequencyPairViewModel> frequencyPair  { get; set; } = new ();

		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<onlineResourceViewModel> onlineResource  { get; set; } = new ();

		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<telecommunicationsViewModel> telecommunications  { get; set; } = new ();

		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		#region InformationBindings

		public class AuthorityContactViewModel : S100Framework.WPF.ViewModel.S122.AuthorityContactViewModel, IInformationBindings {
			public AuthorityContactViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "AuthorityContact",
					role = "theAuthority",
					roleType = roleType.association,
					informationTypes = ["Authority"],
				},
			];
		}

		[Category("InformationBindings")]
		public ObservableCollection<ContactDetailsViewModel.AuthorityContactViewModel> AuthorityContacts { get; set; } = new();
		#endregion


		public ContactDetailsViewModel Load(ContactDetails instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			categoryOfAuthority = instance.categoryOfAuthority;
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			callName = instance.callName;
			callSign = instance.callSign;
			categoryOfCommunicationPreference = instance.categoryOfCommunicationPreference;
			communicationChannel.Clear();
			if (instance.communicationChannel is not null) {
				foreach(var e in instance.communicationChannel)
					communicationChannel.Add(e);
			}
			contactInstructions = instance.contactInstructions;
			mMSICode = instance.mMSICode;
			signalFrequency.Clear();
			if (instance.signalFrequency is not null) {
				foreach(var e in instance.signalFrequency)
					signalFrequency.Add(e);
			}
			contactAddress.Clear();
			if (instance.contactAddress is not null) {
				foreach(var e in instance.contactAddress)
					contactAddress.Add(new contactAddressViewModel().Load(e));
			}
			frequencyPair.Clear();
			if (instance.frequencyPair is not null) {
				foreach(var e in instance.frequencyPair)
					frequencyPair.Add(new frequencyPairViewModel().Load(e));
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
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new ContactDetails {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				categoryOfAuthority = this.categoryOfAuthority,
				textContent = this.textContent?.Model,
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				callName = this.callName,
				callSign = this.callSign,
				categoryOfCommunicationPreference = this.categoryOfCommunicationPreference,
				communicationChannel = this.communicationChannel.ToList(),
				contactInstructions = this.contactInstructions,
				mMSICode = this.mMSICode,
				signalFrequency = this.signalFrequency.ToList(),
				contactAddress = this.contactAddress.Select(e => e.Model).ToList(),
				frequencyPair = this.frequencyPair.Select(e => e.Model).ToList(),
				onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
				telecommunications = this.telecommunications.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ContactDetails Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			categoryOfAuthority = this._categoryOfAuthority,
			textContent = this._textContent?.Model,
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			callName = this._callName,
			callSign = this._callSign,
			categoryOfCommunicationPreference = this._categoryOfCommunicationPreference,
			communicationChannel = this.communicationChannel.ToList(),
			contactInstructions = this._contactInstructions,
			mMSICode = this._mMSICode,
			signalFrequency = this.signalFrequency.ToList(),
			contactAddress = this.contactAddress.Select(e => e.Model).ToList(),
			frequencyPair = this.frequencyPair.Select(e => e.Model).ToList(),
			onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
			telecommunications = this.telecommunications.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => ContactDetails._informationBindingDefinitions;

		public ContactDetailsViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Contact Details";

		public ContactDetailsViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(graphic));
			};
			rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(rxNCode));
			};
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
		}
	}



	/// <summary>
	/// Days when many services are not available. Often days of festivity or recreation or public holidays when normal working hours are limited, especially a national or religious festival, etc.
	/// </summary>
	[CategoryOrder("NonStandardWorkingDay",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NonStandardWorkingDayViewModel : InformationViewModel<NonStandardWorkingDay> {
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public sourceType? sourceType {
			get {
				return _sourceType;
			}
			set {
				SetValue(ref _sourceType, value);
			}
		}

		[Browsable(false)]
		public sourceType[] sourceTypeList => [(sourceType)1,(sourceType)2,(sourceType)7,(sourceType)8,(sourceType)9,(sourceType)10,(sourceType)11,(sourceType)12,(sourceType)13,(sourceType)14];

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		[Category("NonStandardWorkingDay")]
		[Optional]
		public ObservableCollection<String> dateFixed  { get; set; } = new ();

		[Category("NonStandardWorkingDay")]
		[Optional]
		public ObservableCollection<String> dateVariable  { get; set; } = new ();

		[Category("NonStandardWorkingDay")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		#region InformationBindings

		public class ExceptionalWorkdayViewModel : S100Framework.WPF.ViewModel.S122.ExceptionalWorkdayViewModel, IInformationBindings {
			public ExceptionalWorkdayViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ExceptionalWorkday",
					role = "theServiceHours_nsdy",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
		}

		[Category("InformationBindings")]
		public ObservableCollection<NonStandardWorkingDayViewModel.ExceptionalWorkdayViewModel> ExceptionalWorkdays { get; set; } = new();
		#endregion


		public NonStandardWorkingDayViewModel Load(NonStandardWorkingDay instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			dateFixed.Clear();
			if (instance.dateFixed is not null) {
				foreach(var e in instance.dateFixed)
					dateFixed.Add(e);
			}
			dateVariable.Clear();
			if (instance.dateVariable is not null) {
				foreach(var e in instance.dateVariable)
					dateVariable.Add(e);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new NonStandardWorkingDay {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				dateFixed = this.dateFixed.ToList(),
				dateVariable = this.dateVariable.ToList(),
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public NonStandardWorkingDay Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			dateFixed = this.dateFixed.ToList(),
			dateVariable = this.dateVariable.ToList(),
			information = this.information.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => NonStandardWorkingDay._informationBindingDefinitions;

		public NonStandardWorkingDayViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Non-Standard Working Day";

		public NonStandardWorkingDayViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(graphic));
			};
			dateFixed.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(dateFixed));
			};
			dateVariable.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(dateVariable));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}



	/// <summary>
	/// The time when a service is available and known exceptions.
	/// </summary>
	[CategoryOrder("ServiceHours",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceHoursViewModel : InformationViewModel<ServiceHours> {
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public sourceType? sourceType {
			get {
				return _sourceType;
			}
			set {
				SetValue(ref _sourceType, value);
			}
		}

		[Browsable(false)]
		public sourceType[] sourceTypeList => [(sourceType)1,(sourceType)2,(sourceType)7,(sourceType)8,(sourceType)9,(sourceType)10,(sourceType)11,(sourceType)12,(sourceType)13,(sourceType)14];

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		[Category("ServiceHours")]
		[Multiplicity(1)]
		public ObservableCollection<scheduleByDayOfWeekViewModel> scheduleByDayOfWeek  { get; set; } = new ();

		private informationViewModel _information  = default;

		[Category("ServiceHours")]
		[ExpandableObject]
		[Mandatory]
		public informationViewModel information {
			get {
				return _information;
			}
			set {
				SetValue(ref _information, value);
			}
		}


		#region InformationBindings

		public class AuthorityHoursViewModel : S100Framework.WPF.ViewModel.S122.AuthorityHoursViewModel, IInformationBindings {
			public AuthorityHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "AuthorityHours",
					role = "theAuthority_srvHrs",
					roleType = roleType.association,
					informationTypes = ["Authority"],
				},
			];
		}

		public class ExceptionalWorkdayViewModel : S100Framework.WPF.ViewModel.S122.ExceptionalWorkdayViewModel, IInformationBindings {
			public ExceptionalWorkdayViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ExceptionalWorkday",
					role = "partialWorkingDay",
					roleType = roleType.association,
					informationTypes = ["NonStandardWorkingDay"],
				},
			];
		}

		[Category("InformationBindings")]
		public ObservableCollection<ServiceHoursViewModel.AuthorityHoursViewModel> AuthorityHours { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<ServiceHoursViewModel.ExceptionalWorkdayViewModel> ExceptionalWorkdays { get; set; } = new();
		#endregion


		public ServiceHoursViewModel Load(ServiceHours instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			scheduleByDayOfWeek.Clear();
			if (instance.scheduleByDayOfWeek is not null) {
				foreach(var e in instance.scheduleByDayOfWeek)
					scheduleByDayOfWeek.Add(new scheduleByDayOfWeekViewModel().Load(e));
			}
			information = new ();
			if (instance.information != default) {
				information.Load(instance.information);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new ServiceHours {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				scheduleByDayOfWeek = this.scheduleByDayOfWeek.Select(e => e.Model).ToList(),
				information = this.information?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ServiceHours Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			scheduleByDayOfWeek = this.scheduleByDayOfWeek.Select(e => e.Model).ToList(),
			information = this._information?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => ServiceHours._informationBindingDefinitions;

		public ServiceHoursViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Service Hours";

		public ServiceHoursViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(graphic));
			};
			scheduleByDayOfWeek.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(scheduleByDayOfWeek));
			};
		}
	}



	/// <summary>
	/// Describes the relationship between vessel characteristics and: (i) the applicability of an associated information object or feature to the vessel; or, (ii) the use of a facility, place, or service by the vessel; or, (iii) passage of the vessel through an area.
	/// </summary>
	[CategoryOrder("Applicability",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ApplicabilityViewModel : InformationViewModel<Applicability> {
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		private String? _source  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public sourceType? sourceType {
			get {
				return _sourceType;
			}
			set {
				SetValue(ref _sourceType, value);
			}
		}

		[Browsable(false)]
		public sourceType[] sourceTypeList => [(sourceType)1,(sourceType)2,(sourceType)7,(sourceType)8,(sourceType)9,(sourceType)10,(sourceType)11,(sourceType)12,(sourceType)13,(sourceType)14];

		private String? _reportedDate  = default;

		[Category("InformationType")]
		[Editor(typeof(Editors.HorizonEditor<InformationType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private Boolean? _inBallast  = default;

		[Category("Applicability")]
		[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? inBallast {
			get {
				return _inBallast;
			}
			set {
				SetValue(ref _inBallast, value);
			}
		}

		[Category("Applicability")]
		[Optional]
		public ObservableCollection<categoryOfCargo> categoryOfCargo  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfCargo[] categoryOfCargoList => [(categoryOfCargo)1,(categoryOfCargo)2,(categoryOfCargo)3,(categoryOfCargo)4,(categoryOfCargo)5,(categoryOfCargo)6,(categoryOfCargo)7,(categoryOfCargo)8,(categoryOfCargo)9];

		[Category("Applicability")]
		[Optional]
		public ObservableCollection<categoryOfDangerousOrHazardousCargo> categoryOfDangerousOrHazardousCargo  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfDangerousOrHazardousCargo[] categoryOfDangerousOrHazardousCargoList => [(categoryOfDangerousOrHazardousCargo)1,(categoryOfDangerousOrHazardousCargo)2,(categoryOfDangerousOrHazardousCargo)3,(categoryOfDangerousOrHazardousCargo)4,(categoryOfDangerousOrHazardousCargo)5,(categoryOfDangerousOrHazardousCargo)6,(categoryOfDangerousOrHazardousCargo)7,(categoryOfDangerousOrHazardousCargo)8,(categoryOfDangerousOrHazardousCargo)9,(categoryOfDangerousOrHazardousCargo)10,(categoryOfDangerousOrHazardousCargo)11,(categoryOfDangerousOrHazardousCargo)12,(categoryOfDangerousOrHazardousCargo)13,(categoryOfDangerousOrHazardousCargo)14,(categoryOfDangerousOrHazardousCargo)15,(categoryOfDangerousOrHazardousCargo)16,(categoryOfDangerousOrHazardousCargo)17,(categoryOfDangerousOrHazardousCargo)18,(categoryOfDangerousOrHazardousCargo)19,(categoryOfDangerousOrHazardousCargo)20,(categoryOfDangerousOrHazardousCargo)21];

		private categoryOfVessel? _categoryOfVessel  = default;

		[Category("Applicability")]
		[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfVessel? categoryOfVessel {
			get {
				return _categoryOfVessel;
			}
			set {
				SetValue(ref _categoryOfVessel, value);
			}
		}

		[Browsable(false)]
		public categoryOfVessel[] categoryOfVesselList =>  CodeList.categoryOfVessels.ToArray();

		private categoryOfVesselRegistry? _categoryOfVesselRegistry  = default;

		[Category("Applicability")]
		[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfVesselRegistry? categoryOfVesselRegistry {
			get {
				return _categoryOfVesselRegistry;
			}
			set {
				SetValue(ref _categoryOfVesselRegistry, value);
			}
		}

		[Browsable(false)]
		public categoryOfVesselRegistry[] categoryOfVesselRegistryList => [(categoryOfVesselRegistry)1,(categoryOfVesselRegistry)2];

		private logicalConnectives? _logicalConnectives  = default;

		[Category("Applicability")]
		[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
		[Optional]
		public logicalConnectives? logicalConnectives {
			get {
				return _logicalConnectives;
			}
			set {
				SetValue(ref _logicalConnectives, value);
			}
		}

		[Browsable(false)]
		public logicalConnectives[] logicalConnectivesList => [(logicalConnectives)1,(logicalConnectives)2];

		private int? _thicknessOfIceCapability  = default;

		[Category("Applicability")]
		[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? thicknessOfIceCapability {
			get {
				return _thicknessOfIceCapability;
			}
			set {
				SetValue(ref _thicknessOfIceCapability, value);
			}
		}

		private String? _vesselPerformance  = default;

		[Category("Applicability")]
		[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? vesselPerformance {
			get {
				return _vesselPerformance;
			}
			set {
				SetValue(ref _vesselPerformance, value);
			}
		}

		[Category("Applicability")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("Applicability")]
		[Optional]
		public ObservableCollection<vesselsMeasurementsViewModel> vesselsMeasurements  { get; set; } = new ();


		public ApplicabilityViewModel Load(Applicability instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			inBallast = instance.inBallast;
			categoryOfCargo.Clear();
			if (instance.categoryOfCargo is not null) {
				foreach(var e in instance.categoryOfCargo)
					categoryOfCargo.Add(e);
			}
			categoryOfDangerousOrHazardousCargo.Clear();
			if (instance.categoryOfDangerousOrHazardousCargo is not null) {
				foreach(var e in instance.categoryOfDangerousOrHazardousCargo)
					categoryOfDangerousOrHazardousCargo.Add(e);
			}
			categoryOfVessel = instance.categoryOfVessel;
			categoryOfVesselRegistry = instance.categoryOfVesselRegistry;
			logicalConnectives = instance.logicalConnectives;
			thicknessOfIceCapability = instance.thicknessOfIceCapability;
			vesselPerformance = instance.vesselPerformance;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			vesselsMeasurements.Clear();
			if (instance.vesselsMeasurements is not null) {
				foreach(var e in instance.vesselsMeasurements)
					vesselsMeasurements.Add(new vesselsMeasurementsViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Applicability {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				inBallast = this.inBallast,
				categoryOfCargo = this.categoryOfCargo.ToList(),
				categoryOfDangerousOrHazardousCargo = this.categoryOfDangerousOrHazardousCargo.ToList(),
				categoryOfVessel = this.categoryOfVessel,
				categoryOfVesselRegistry = this.categoryOfVesselRegistry,
				logicalConnectives = this.logicalConnectives,
				thicknessOfIceCapability = this.thicknessOfIceCapability,
				vesselPerformance = this.vesselPerformance,
				information = this.information.Select(e => e.Model).ToList(),
				vesselsMeasurements = this.vesselsMeasurements.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Applicability Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			inBallast = this._inBallast,
			categoryOfCargo = this.categoryOfCargo.ToList(),
			categoryOfDangerousOrHazardousCargo = this.categoryOfDangerousOrHazardousCargo.ToList(),
			categoryOfVessel = this._categoryOfVessel,
			categoryOfVesselRegistry = this._categoryOfVesselRegistry,
			logicalConnectives = this._logicalConnectives,
			thicknessOfIceCapability = this._thicknessOfIceCapability,
			vesselPerformance = this._vesselPerformance,
			information = this.information.Select(e => e.Model).ToList(),
			vesselsMeasurements = this.vesselsMeasurements.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Applicability._informationBindingDefinitions;

		public ApplicabilityViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Applicability";

		public ApplicabilityViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(graphic));
			};
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
		}
	}



	/// <summary>
	/// A specified area designated by an appropriate authority within which navigation is restricted in accordance with certain specified conditions.
	/// </summary>
	[CategoryOrder("RestrictedArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RestrictedAreaViewModel : FeatureViewModel<RestrictedArea> {
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		private String? _source  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public sourceType? sourceType {
			get {
				return _sourceType;
			}
			set {
				SetValue(ref _sourceType, value);
			}
		}

		[Browsable(false)]
		public sourceType[] sourceTypeList => [(sourceType)1,(sourceType)2,(sourceType)7,(sourceType)8,(sourceType)9,(sourceType)10,(sourceType)11,(sourceType)12,(sourceType)13,(sourceType)14];

		private String? _reportedDate  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		[Category("RestrictedArea")]
		[Optional]
		public ObservableCollection<categoryOfRestrictedArea> categoryOfRestrictedArea  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfRestrictedArea[] categoryOfRestrictedAreaList => [(categoryOfRestrictedArea)1,(categoryOfRestrictedArea)4,(categoryOfRestrictedArea)5,(categoryOfRestrictedArea)6,(categoryOfRestrictedArea)7,(categoryOfRestrictedArea)8,(categoryOfRestrictedArea)9,(categoryOfRestrictedArea)10,(categoryOfRestrictedArea)12,(categoryOfRestrictedArea)14,(categoryOfRestrictedArea)18,(categoryOfRestrictedArea)19,(categoryOfRestrictedArea)20,(categoryOfRestrictedArea)21,(categoryOfRestrictedArea)22,(categoryOfRestrictedArea)23,(categoryOfRestrictedArea)24,(categoryOfRestrictedArea)25,(categoryOfRestrictedArea)26,(categoryOfRestrictedArea)27,(categoryOfRestrictedArea)28,(categoryOfRestrictedArea)29,(categoryOfRestrictedArea)30,(categoryOfRestrictedArea)31,(categoryOfRestrictedArea)32,(categoryOfRestrictedArea)33];

		[Category("RestrictedArea")]
		[Multiplicity(1)]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)7,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)14,(restriction)15,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)26,(restriction)27,(restriction)28,(restriction)29,(restriction)30,(restriction)31,(restriction)32,(restriction)33,(restriction)34,(restriction)35,(restriction)36,(restriction)37,(restriction)38,(restriction)39,(restriction)40,(restriction)41];

		[Category("RestrictedArea")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];


		public RestrictedAreaViewModel Load(RestrictedArea instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			categoryOfRestrictedArea.Clear();
			if (instance.categoryOfRestrictedArea is not null) {
				foreach(var e in instance.categoryOfRestrictedArea)
					categoryOfRestrictedArea.Add(e);
			}
			restriction.Clear();
			if (instance.restriction is not null) {
				foreach(var e in instance.restriction)
					restriction.Add(e);
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new RestrictedArea {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
				restriction = this.restriction.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RestrictedArea Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
			restriction = this.restriction.ToList(),
			status = this.status.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => RestrictedArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RestrictedArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RestrictedArea._featureBindingDefinitions;

		public RestrictedAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public RestrictedAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Restricted Area";

		public RestrictedAreaViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			categoryOfRestrictedArea.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfRestrictedArea));
			};
			restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(restriction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// Any area of the intertidal or sub-tidal terrain, together with its overlying water and associated flora, fauna, historical and cultural features, which has been reserved by law or other effective means to protect part or all of the enclosed environment.
	/// </summary>
	[CategoryOrder("MarineProtectedArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class MarineProtectedAreaViewModel : FeatureViewModel<MarineProtectedArea> {
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		private String? _source  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public sourceType? sourceType {
			get {
				return _sourceType;
			}
			set {
				SetValue(ref _sourceType, value);
			}
		}

		[Browsable(false)]
		public sourceType[] sourceTypeList => [(sourceType)1,(sourceType)2,(sourceType)7,(sourceType)8,(sourceType)9,(sourceType)10,(sourceType)11,(sourceType)12,(sourceType)13,(sourceType)14];

		private String? _reportedDate  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private categoryOfMarineProtectedArea _categoryOfMarineProtectedArea  = default;

		[Category("MarineProtectedArea")]
		[Editor(typeof(Editors.HorizonEditor<MarineProtectedArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public categoryOfMarineProtectedArea categoryOfMarineProtectedArea {
			get {
				return _categoryOfMarineProtectedArea;
			}
			set {
				SetValue(ref _categoryOfMarineProtectedArea, value);
			}
		}

		[Browsable(false)]
		public categoryOfMarineProtectedArea[] categoryOfMarineProtectedAreaList =>  CodeList.categoryOfMarineProtectedAreas.ToArray();

		[Category("MarineProtectedArea")]
		[Optional]
		public ObservableCollection<categoryOfRestrictedArea> categoryOfRestrictedArea  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfRestrictedArea[] categoryOfRestrictedAreaList => [(categoryOfRestrictedArea)1,(categoryOfRestrictedArea)4,(categoryOfRestrictedArea)5,(categoryOfRestrictedArea)6,(categoryOfRestrictedArea)7,(categoryOfRestrictedArea)8,(categoryOfRestrictedArea)9,(categoryOfRestrictedArea)10,(categoryOfRestrictedArea)12,(categoryOfRestrictedArea)14,(categoryOfRestrictedArea)18,(categoryOfRestrictedArea)19,(categoryOfRestrictedArea)20,(categoryOfRestrictedArea)21,(categoryOfRestrictedArea)22,(categoryOfRestrictedArea)23,(categoryOfRestrictedArea)24,(categoryOfRestrictedArea)25,(categoryOfRestrictedArea)26,(categoryOfRestrictedArea)27,(categoryOfRestrictedArea)28,(categoryOfRestrictedArea)29,(categoryOfRestrictedArea)30,(categoryOfRestrictedArea)31,(categoryOfRestrictedArea)32,(categoryOfRestrictedArea)33];

		private jurisdiction _jurisdiction  = default;

		[Category("MarineProtectedArea")]
		[Editor(typeof(Editors.HorizonEditor<MarineProtectedArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public jurisdiction jurisdiction {
			get {
				return _jurisdiction;
			}
			set {
				SetValue(ref _jurisdiction, value);
			}
		}

		[Browsable(false)]
		public jurisdiction[] jurisdictionList => [(jurisdiction)1,(jurisdiction)2,(jurisdiction)3];

		[Category("MarineProtectedArea")]
		[Optional]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)7,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)14,(restriction)15,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)26,(restriction)27,(restriction)28,(restriction)29,(restriction)30,(restriction)31,(restriction)32,(restriction)33,(restriction)34,(restriction)35,(restriction)36,(restriction)37,(restriction)38,(restriction)39,(restriction)40,(restriction)41];

		[Category("MarineProtectedArea")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		[Category("MarineProtectedArea")]
		[Optional]
		public ObservableCollection<designationViewModel> designation  { get; set; } = new ();


		#region InformationBindings

		public class ProtectedAreaAuthorityViewModel : S100Framework.WPF.ViewModel.S122.ProtectedAreaAuthorityViewModel, IInformationBindings {
			public ProtectedAreaAuthorityViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "ProtectedAreaAuthority",
					role = "responsibleAuthority",
					roleType = roleType.association,
					informationTypes = ["Authority"],
				},
			];
		}

		[Category("InformationBindings")]
		public ObservableCollection<MarineProtectedAreaViewModel.ProtectedAreaAuthorityViewModel> ProtectedAreaAuthorities { get; set; } = new();
		#endregion


		public MarineProtectedAreaViewModel Load(MarineProtectedArea instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			categoryOfMarineProtectedArea = instance.categoryOfMarineProtectedArea;
			categoryOfRestrictedArea.Clear();
			if (instance.categoryOfRestrictedArea is not null) {
				foreach(var e in instance.categoryOfRestrictedArea)
					categoryOfRestrictedArea.Add(e);
			}
			jurisdiction = instance.jurisdiction;
			restriction.Clear();
			if (instance.restriction is not null) {
				foreach(var e in instance.restriction)
					restriction.Add(e);
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			designation.Clear();
			if (instance.designation is not null) {
				foreach(var e in instance.designation)
					designation.Add(new designationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new MarineProtectedArea {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				categoryOfMarineProtectedArea = this.categoryOfMarineProtectedArea,
				categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
				jurisdiction = this.jurisdiction,
				restriction = this.restriction.ToList(),
				status = this.status.ToList(),
				designation = this.designation.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public MarineProtectedArea Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			categoryOfMarineProtectedArea = this._categoryOfMarineProtectedArea,
			categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
			jurisdiction = this._jurisdiction,
			restriction = this.restriction.ToList(),
			status = this.status.ToList(),
			designation = this.designation.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => MarineProtectedArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. MarineProtectedArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => MarineProtectedArea._featureBindingDefinitions;

		public MarineProtectedAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public MarineProtectedAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Marine Protected Area";

		public MarineProtectedAreaViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
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
		}
	}



	/// <summary>
	/// The area of any service implemented by a relevant authority primarily designed to improve safety and efficiency of traffic flow and the protection of the environment. It may range from simple information messages, to extensive organisation of the traffic involving national or regional schemes.
	/// </summary>
	[CategoryOrder("VesselTrafficServiceArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class VesselTrafficServiceAreaViewModel : FeatureViewModel<VesselTrafficServiceArea> {
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		private String? _source  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public sourceType? sourceType {
			get {
				return _sourceType;
			}
			set {
				SetValue(ref _sourceType, value);
			}
		}

		[Browsable(false)]
		public sourceType[] sourceTypeList => [(sourceType)1,(sourceType)2,(sourceType)7,(sourceType)8,(sourceType)9,(sourceType)10,(sourceType)11,(sourceType)12,(sourceType)13,(sourceType)14];

		private String? _reportedDate  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private categoryOfVesselTrafficService _categoryOfVesselTrafficService  = default;

		[Category("VesselTrafficServiceArea")]
		[Editor(typeof(Editors.HorizonEditor<VesselTrafficServiceArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public categoryOfVesselTrafficService categoryOfVesselTrafficService {
			get {
				return _categoryOfVesselTrafficService;
			}
			set {
				SetValue(ref _categoryOfVesselTrafficService, value);
			}
		}

		[Browsable(false)]
		public categoryOfVesselTrafficService[] categoryOfVesselTrafficServiceList => [(categoryOfVesselTrafficService)1,(categoryOfVesselTrafficService)2,(categoryOfVesselTrafficService)3,(categoryOfVesselTrafficService)4,(categoryOfVesselTrafficService)5];


		#region InformationBindings

		public class ServiceControlViewModel : S100Framework.WPF.ViewModel.S122.ServiceControlViewModel, IInformationBindings {
			public ServiceControlViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "ServiceControl",
					role = "controlAuthority",
					roleType = roleType.association,
					informationTypes = ["Authority"],
				},
			];
		}

		[Category("InformationBindings")]
		public ObservableCollection<VesselTrafficServiceAreaViewModel.ServiceControlViewModel> ServiceControls { get; set; } = new();
		#endregion


		public VesselTrafficServiceAreaViewModel Load(VesselTrafficServiceArea instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			categoryOfVesselTrafficService = instance.categoryOfVesselTrafficService;
			return this;
		}

		public override string Serialize() {
			var instance = new VesselTrafficServiceArea {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				categoryOfVesselTrafficService = this.categoryOfVesselTrafficService,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public VesselTrafficServiceArea Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			categoryOfVesselTrafficService = this._categoryOfVesselTrafficService,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => VesselTrafficServiceArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. VesselTrafficServiceArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => VesselTrafficServiceArea._featureBindingDefinitions;

		public VesselTrafficServiceAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public VesselTrafficServiceAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Vessel Traffic Service Area";

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
	}



	/// <summary>
	/// A geographical area that describes the coverage and extent of spatial objects.
	/// </summary>
	[CategoryOrder("DataCoverage",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DataCoverageViewModel : FeatureViewModel<DataCoverage> {


		public DataCoverageViewModel Load(DataCoverage instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new DataCoverage {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DataCoverage Model => new () {

		};

		public override informationBindingDefinition[] informationBindingDefinitions => DataCoverage._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. DataCoverage._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => DataCoverage._featureBindingDefinitions;

		public DataCoverageViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public DataCoverageViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Data Coverage";
	}



	/// <summary>
	/// The Text Placement feature is used in association with the Feature Name attribute or a light description to optimize text positioning in ECDIS.
	/// </summary>
	[CategoryOrder("TextPlacement",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TextPlacementViewModel : FeatureViewModel<TextPlacement> {


		public TextPlacementViewModel Load(TextPlacement instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new TextPlacement {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public TextPlacement Model => new () {

		};

		public override informationBindingDefinition[] informationBindingDefinitions => TextPlacement._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. TextPlacement._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => TextPlacement._featureBindingDefinitions;

		public TextPlacementViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public TextPlacementViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Text Placement";
	}



	public static class InformationBindingExtension {
		public static InformationTypeViewModel LoadInformationBinding(this InformationTypeViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static AbstractRxNViewModel LoadInformationBinding(this AbstractRxNViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<RelatedOrganisation> relatedOrganisation) {
					instance.RelatedOrganisations.Add(new AbstractRxNViewModel.RelatedOrganisationViewModel {
						informationId = relatedOrganisation.referenceId,
						role = relatedOrganisation.role,
					});
				}
			}
			return instance;
		}

		public static NauticalInformationViewModel LoadInformationBinding(this NauticalInformationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<RelatedOrganisation> relatedOrganisation) {
					instance.RelatedOrganisations.Add(new NauticalInformationViewModel.RelatedOrganisationViewModel {
						informationId = relatedOrganisation.referenceId,
						role = relatedOrganisation.role,
					});
				}
			}
			return instance;
		}

		public static RegulationsViewModel LoadInformationBinding(this RegulationsViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RestrictionsViewModel LoadInformationBinding(this RestrictionsViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RecommendationsViewModel LoadInformationBinding(this RecommendationsViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static AuthorityViewModel LoadInformationBinding(this AuthorityViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<RelatedOrganisation> relatedOrganisation) {
					instance.RelatedOrganisations.Add(new AuthorityViewModel.RelatedOrganisationViewModel {
						informationId = relatedOrganisation.referenceId,
						role = relatedOrganisation.role,
					});
				}
				if(informationBinding is informationBinding<AuthorityContact> authorityContact) {
					instance.AuthorityContacts.Add(new AuthorityViewModel.AuthorityContactViewModel {
						informationId = authorityContact.referenceId,
						role = authorityContact.role,
					});
				}
				if(informationBinding is informationBinding<AuthorityHours> authorityHours) {
					instance.AuthorityHours.Add(new AuthorityViewModel.AuthorityHoursViewModel {
						informationId = authorityHours.referenceId,
						role = authorityHours.role,
					});
				}
			}
			return instance;
		}

		public static ContactDetailsViewModel LoadInformationBinding(this ContactDetailsViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<AuthorityContact> authorityContact) {
					instance.AuthorityContacts.Add(new ContactDetailsViewModel.AuthorityContactViewModel {
						informationId = authorityContact.referenceId,
						role = authorityContact.role,
					});
				}
			}
			return instance;
		}

		public static NonStandardWorkingDayViewModel LoadInformationBinding(this NonStandardWorkingDayViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ExceptionalWorkday> exceptionalWorkday) {
					instance.ExceptionalWorkdays.Add(new NonStandardWorkingDayViewModel.ExceptionalWorkdayViewModel {
						informationId = exceptionalWorkday.referenceId,
						role = exceptionalWorkday.role,
					});
				}
			}
			return instance;
		}

		public static ServiceHoursViewModel LoadInformationBinding(this ServiceHoursViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<AuthorityHours> authorityHours) {
					instance.AuthorityHours.Add(new ServiceHoursViewModel.AuthorityHoursViewModel {
						informationId = authorityHours.referenceId,
						role = authorityHours.role,
					});
				}
				if(informationBinding is informationBinding<ExceptionalWorkday> exceptionalWorkday) {
					instance.ExceptionalWorkdays.Add(new ServiceHoursViewModel.ExceptionalWorkdayViewModel {
						informationId = exceptionalWorkday.referenceId,
						role = exceptionalWorkday.role,
					});
				}
			}
			return instance;
		}

		public static ApplicabilityViewModel LoadInformationBinding(this ApplicabilityViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RestrictedAreaViewModel LoadInformationBinding(this RestrictedAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static MarineProtectedAreaViewModel LoadInformationBinding(this MarineProtectedAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ProtectedAreaAuthority> protectedAreaAuthority) {
					instance.ProtectedAreaAuthorities.Add(new MarineProtectedAreaViewModel.ProtectedAreaAuthorityViewModel {
						informationId = protectedAreaAuthority.referenceId,
						role = protectedAreaAuthority.role,
					});
				}
			}
			return instance;
		}

		public static VesselTrafficServiceAreaViewModel LoadInformationBinding(this VesselTrafficServiceAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceControl> serviceControl) {
					instance.ServiceControls.Add(new VesselTrafficServiceAreaViewModel.ServiceControlViewModel {
						informationId = serviceControl.referenceId,
						role = serviceControl.role,
					});
				}
			}
			return instance;
		}

		public static DataCoverageViewModel LoadInformationBinding(this DataCoverageViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static TextPlacementViewModel LoadInformationBinding(this TextPlacementViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

	}

	public static class FeatureBindingExtension {
		public static RestrictedAreaViewModel LoadFeatureBinding(this RestrictedAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static MarineProtectedAreaViewModel LoadFeatureBinding(this MarineProtectedAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static VesselTrafficServiceAreaViewModel LoadFeatureBinding(this VesselTrafficServiceAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static DataCoverageViewModel LoadFeatureBinding(this DataCoverageViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static TextPlacementViewModel LoadFeatureBinding(this TextPlacementViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

	}

}
