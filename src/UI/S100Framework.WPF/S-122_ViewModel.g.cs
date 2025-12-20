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
using S100Framework.DomainModel.S122.FeatureAssociations;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using System.Text.Json;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.WPF.ViewModel.S122 {
	internal static class Bootstrap {
		public static AssociationViewModel CreateInformationAssociation(string type, string? name = default) => type switch {
			"AdditionalInformation" => new AdditionalInformationViewModel { Name = name },
			"AuthorityContact" => new AuthorityContactViewModel { Name = name },
			"AuthorityHours" => new AuthorityHoursViewModel { Name = name },
			"AssociatedRxN" => new AssociatedRxNViewModel { Name = name },
			"ExceptionalWorkday" => new ExceptionalWorkdayViewModel { Name = name },
			"ProtectedAreaAuthority" => new ProtectedAreaAuthorityViewModel { Name = name },
			"RelatedOrganisation" => new RelatedOrganisationViewModel { Name = name },
			"InclusionType" => new InclusionTypeViewModel { Name = name },
			"PermissionType" => new PermissionTypeViewModel { Name = name },
			"ServiceControl" => new ServiceControlViewModel { Name = name },
			"SpatialAssociation" => new SpatialAssociationViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static AssociationViewModel CreateFeatureAssociation(string type, string? name = default) => type switch {
			"TextAssociation" => new TextAssociationViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static InformationViewModel CreateInformationType(string type, string? name = default) => type switch {
			"Applicability" => new ApplicabilityViewModel { Name = name },
			"Authority" => new AuthorityViewModel { Name = name },
			"ContactDetails" => new ContactDetailsViewModel { Name = name },
			"NauticalInformation" => new NauticalInformationViewModel { Name = name },
			"NonStandardWorkingDay" => new NonStandardWorkingDayViewModel { Name = name },
			"Recommendations" => new RecommendationsViewModel { Name = name },
			"Regulations" => new RegulationsViewModel { Name = name },
			"Restrictions" => new RestrictionsViewModel { Name = name },
			"ServiceHours" => new ServiceHoursViewModel { Name = name },
			"SpatialQuality" => new SpatialQualityViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static FeatureViewModel CreateFeatureType(string type, string? name = default) => type switch {
			"InformationArea" => new InformationAreaViewModel { Name = name },
			"MarineProtectedArea" => new MarineProtectedAreaViewModel { Name = name },
			"RestrictedArea" => new RestrictedAreaViewModel { Name = name },
			"VesselTrafficServiceArea" => new VesselTrafficServiceAreaViewModel { Name = name },
			"DataCoverage" => new DataCoverageViewModel { Name = name },
			"QualityOfNonBathymetricData" => new QualityOfNonBathymetricDataViewModel { Name = name },
			"TextPlacement" => new TextPlacementViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static ICollection<string> InformationAssociationBindings(string association, string role) => (association, role) switch {
			("InclusionType", "isApplicableTo") => ["Applicability"],
			("RelatedOrganisation", "theOrganisation") => ["Authority"],
			("InclusionType", "theApplicableRxN") => ["AbstractRxN"],
			("AuthorityContact", "theContactDetails") => ["ContactDetails"],
			("RelatedOrganisation", "organisationRelatedRxN") => ["AbstractRxN"],
			("AuthorityHours", "theServiceHours") => ["ServiceHours"],
			("AuthorityContact", "theAuthority") => ["Authority"],
			("ExceptionalWorkday", "partialWorkingDay") => ["NonStandardWorkingDay"],
			("AuthorityHours", "theAuthority_srvHrs") => ["Authority"],
			("PermissionType", "permission") => ["Applicability"],
			("AssociatedRxN", "theRxN") => ["AbstractRxN"],
			("AdditionalInformation", "theInformation") => ["NauticalInformation"],
			("ProtectedAreaAuthority", "responsibleAuthority") => ["Authority"],
			("ServiceControl", "controlAuthority") => ["Authority"],
			_ => throw new InvalidOperationException(),
		};

		public static ICollection<string> FeatureAssociationBindings(string association, string role) => (association, role) switch {
			("TextAssociation", "theCartographicText") => ["TextPlacement"],
			("TextAssociation", "thePositionProvider") => ["FeatureType"],
			_ => throw new InvalidOperationException(),
		};
	}

	/// <summary>
	/// A bearing is the direction one object is from another object.
	/// </summary>
	[Description("A bearing is the direction one object is from another object.")]
	[CategoryOrder("bearingInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class bearingInformationViewModel : ComplexViewModel<bearingInformation> {
		private cardinalDirection? _cardinalDirection  = default;

		[Description("Principal and intermediate compass points.")]
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
		public cardinalDirection[] cardinalDirectionList => [(cardinalDirection)1,(cardinalDirection)2,(cardinalDirection)3,(cardinalDirection)4,(cardinalDirection)5,(cardinalDirection)6,(cardinalDirection)7,(cardinalDirection)8,(cardinalDirection)9,(cardinalDirection)10,(cardinalDirection)11,(cardinalDirection)12,(cardinalDirection)13,(cardinalDirection)14,(cardinalDirection)15,(cardinalDirection)16];

		private double? _distance  = default;

		[Description("A numeric measure of the spatial separation between two locations.")]
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

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private orientationViewModel? _orientation  = default;

		[Description("(1) The angular distance measured from true north to the major axis of the feature. (2) In ECDIS, the mode in which information on the ECDIS is being presented. Typical modes include: north-up - as shown on a nautical chart, north is at the top of the display; Ships head-up - based on the actual heading of the ship, (e.g. Ships gyrocompass); course-up display - based on the course or route being taken.")]
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
				information = this.information.Select(e => e.Model).ToList(),
				orientation = this.orientation?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public bearingInformation Model => new () {
			cardinalDirection = this._cardinalDirection,
			distance = this._distance,
			information = this.information.Select(e => e.Model).ToList(),
			orientation = this._orientation?.Model,
		};

		public override string? ToString() => $"Bearing Information";

		public bearingInformationViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}


	/// <summary>
	/// Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.
	/// </summary>
	[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
	[CategoryOrder("contactAddress",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class contactAddressViewModel : ComplexViewModel<contactAddress> {
		private String? _deliveryPoint  = default;

		[Description("Details of where post can be delivered such as the apartment, name and/or number of a street, building or PO Box.")]
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

		[Description("The name of a town or city.")]
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

		[Description("A generic term for an administrative region within a country at a level below that of the sovereign state.")]
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

		[Description("The name of a nation.")]
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

		[Description("Known in various countries as a postcode, or ZIP code, the postal code is a series of letters and/or digits that identifies each postal delivery area.")]
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
	/// An official name, title or description. This can be an identifier or an identifier which is an instance of a named designation scheme.
	/// </summary>
	[Description("An official name, title or description. This can be an identifier or an identifier which is an instance of a named designation scheme.")]
	[CategoryOrder("designation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class designationViewModel : ComplexViewModel<designation> {
		private String? _designationScheme  = default;

		[Description("An official name, title or description. This can be an identifier itself, or an identifier which is an instance of a named designation scheme.")]
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

		[Description("An identifier which is an instance of a particular, named scheme")]
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

		[Description("The jurisdiction applicable to an administrative area.")]
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
		public jurisdiction[] jurisdictionList => [(jurisdiction)1,(jurisdiction)2,(jurisdiction)3];

		private String? _text  = default;

		[Description("A non-formatted digital text string.")]
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

		public override string? ToString() => $"Designation";
	}


	/// <summary>
	/// Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.
	/// </summary>
	[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
	[CategoryOrder("featureName",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class featureNameViewModel : ComplexViewModel<featureName> {
		private String _language  = string.Empty;

		[Description("The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.")]
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

		[Description("The individual name of a feature.")]
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

		private nameUsage? _nameUsage  = default;

		[Description("Classification of the type and display level of the name of a feature in an end-user system.")]
		[Editor(typeof(Editors.HorizonEditor<featureName>), typeof(Editors.HorizonEditor))]
		[Optional]
		public nameUsage? nameUsage {
			get {
				return _nameUsage;
			}
			set {
				SetValue(ref _nameUsage, value);
			}
		}

		[Browsable(false)]
		public nameUsage[] nameUsageList => [(nameUsage)1,(nameUsage)2,(nameUsage)3];


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
	/// An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.
	/// </summary>
	[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
	[CategoryOrder("fixedDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class fixedDateRangeViewModel : ComplexViewModel<fixedDateRange> {
		private String? _dateStart  = default;

		[Description("The earliest date on which an object (for example a buoy) will be present.")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("The latest date on which an object (for example a buoy) will be present.")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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
	[Description("A pair of frequencies for transmitting and receiving radio signals. The shore station transmits and receives on the frequencies indicated.")]
	[CategoryOrder("frequencyPair",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class frequencyPairViewModel : ComplexViewModel<frequencyPair> {
		private int? _frequencyShoreStationReceives  = default;

		[Description("The shore station receiver frequency.")]
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

		private int _frequencyShoreStationTransmits  = default;

		[Description("The shore station transmitter frequency.")]
		[Editor(typeof(Editors.HorizonEditor<frequencyPair>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int frequencyShoreStationTransmits {
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
	[Description("Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.")]
	[CategoryOrder("graphic",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class graphicViewModel : ComplexViewModel<graphic> {
		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Multiplicity(1)]
		public ObservableCollection<String> pictorialRepresentation  { get; set; } = new ();

		private String? _pictureCaption  = default;

		[Description("Short description of the purpose of the image.")]
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

		[Description("The production date of the source; for example the date of measurement.")]
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

		[Description("A set of information to provide credits to picture creator, copyright owner etc.")]
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

		[Description("A bearing is the direction one object is from another object.")]
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
	/// The best estimate of the accuracy of a position.
	/// </summary>
	[Description("The best estimate of the accuracy of a position.")]
	[CategoryOrder("horizontalPositionUncertainty",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class horizontalPositionUncertaintyViewModel : ComplexViewModel<horizontalPositionUncertainty> {
		private double _uncertaintyFixed  = default;

		[Description("The best estimate of the fixed horizontal or vertical accuracy component for positions, depths, heights, vertical distances and vertical clearances.")]
		[Editor(typeof(Editors.HorizonEditor<horizontalPositionUncertainty>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double uncertaintyFixed {
			get {
				return _uncertaintyFixed;
			}
			set {
				SetValue(ref _uncertaintyFixed, value);
			}
		}

		private double? _uncertaintyVariableFactor  = default;

		[Description("The factor to be applied to the variable component of an uncertainty equation so as to provide the best estimate of the variable horizontal or vertical accuracy component for positions, depths, heights, vertical distances and vertical clearances.")]
		[Editor(typeof(Editors.HorizonEditor<horizontalPositionUncertainty>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? uncertaintyVariableFactor {
			get {
				return _uncertaintyVariableFactor;
			}
			set {
				SetValue(ref _uncertaintyVariableFactor, value);
			}
		}


		public horizontalPositionUncertaintyViewModel Load(horizontalPositionUncertainty instance) {
			uncertaintyFixed = instance.uncertaintyFixed;
			uncertaintyVariableFactor = instance.uncertaintyVariableFactor;
			return this;
		}

		public override string Serialize() {
			var instance = new horizontalPositionUncertainty {
				uncertaintyFixed = this.uncertaintyFixed,
				uncertaintyVariableFactor = this.uncertaintyVariableFactor,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public horizontalPositionUncertainty Model => new () {
			uncertaintyFixed = this._uncertaintyFixed,
			uncertaintyVariableFactor = this._uncertaintyVariableFactor,
		};

		public override string? ToString() => $"Horizontal Position Uncertainty";
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

		[Description("The file name of an externally referenced text file.")]
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

		[Description("Words set at the head of a passage or page to introduce or categorize.")]
		[Optional]
		public ObservableCollection<String> headline  { get; set; } = new ();

		private String? _language  = default;

		[Description("The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.")]
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

		[Description("A non-formatted digital text string.")]
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
			headline.Clear();
			if (instance.headline is not null) {
				foreach(var e in instance.headline)
					headline.Add(e);
			}
			language = instance.language;
			text = instance.text;
			return this;
		}

		public override string Serialize() {
			var instance = new information {
				fileLocator = this.fileLocator,
				fileReference = this.fileReference,
				headline = this.headline.ToList(),
				language = this.language,
				text = this.text,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public information Model => new () {
			fileLocator = this._fileLocator,
			fileReference = this._fileReference,
			headline = this.headline.ToList(),
			language = this._language,
			text = this._text,
		};

		public override string? ToString() => $"Information";

		public informationViewModel() : base() {
			headline.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(headline));
			};
		}
	}


	/// <summary>
	/// Information about online sources from which a resource or data can be obtained.
	/// </summary>
	[Description("Information about online sources from which a resource or data can be obtained.")]
	[CategoryOrder("onlineResource",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class onlineResourceViewModel : ComplexViewModel<onlineResource> {
		private String _linkage  = string.Empty;

		[Description("Location (address) for online access using a URL/URI address or similar addressing scheme.")]
		[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String linkage {
			get {
				return _linkage;
			}
			set {
				SetValue(ref _linkage, value);
			}
		}

		private String? _protocol  = default;

		[Description("Connection protocol to be used. Example: ftp, http get KVP, http POST, etc.")]
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

		[Description("Name of an application profile that can be used with the online resource.")]
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

		[Description("Name of the online resource.")]
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

		[Description("Detailed text description of what the online resource is/does (ISO 19115)")]
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

		[Description("Request used to access the resource. Structure and content depend on the protocol and standard used by the online resource, such as Web Feature Service standard.")]
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

		[Description("Code for function performed by the online resource (ISO 19115)")]
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
		public onlineFunction[] onlineFunctionList => [(onlineFunction)1,(onlineFunction)3,(onlineFunction)4,(onlineFunction)5,(onlineFunction)6,(onlineFunction)7,(onlineFunction)8,(onlineFunction)9,(onlineFunction)10,(onlineFunction)11];


		public onlineResourceViewModel Load(onlineResource instance) {
			linkage = instance.linkage;
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
				linkage = this.linkage,
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
			linkage = this._linkage,
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
	[Description("(1) The angular distance measured from true north to the major axis of the feature. (2) In ECDIS, the mode in which information on the ECDIS is being presented. Typical modes include: north-up - as shown on a nautical chart, north is at the top of the display; Ships head-up - based on the actual heading of the ship, (e.g. Ships gyrocompass); course-up display - based on the course or route being taken.")]
	[CategoryOrder("orientation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class orientationViewModel : ComplexViewModel<orientation> {
		private double? _orientationUncertainty  = default;

		[Description("The best estimate of the accuracy of a bearing.")]
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

		[Description("The angular distance measured from true north to the major axis of the feature.")]
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
	[Description("The active period of a recurring event or occurrence.")]
	[CategoryOrder("periodicDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class periodicDateRangeViewModel : ComplexViewModel<periodicDateRange> {
		private String _dateStart  = string.Empty;

		[Description("The earliest date on which an object (for example a buoy) will be present.")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		[Description("The latest date on which an object (for example a buoy) will be present.")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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
	[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
	[CategoryOrder("rxNCode",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class rxNCodeViewModel : ComplexViewModel<rxNCode> {
		private categoryOfRxN? _categoryOfRxN  = default;

		[Description("The principal subject matter of regulations, restrictions, recommendations or nautical information.")]
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

		[Browsable(false)]
		public categoryOfRxN[] categoryOfRxNList =>  CodeList.categoryOfRxNS.ToArray();

		private actionOrActivity? _actionOrActivity  = default;

		[Description("The action or activity of a vessel.")]
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

		[Browsable(false)]
		public actionOrActivity[] actionOrActivityList =>  CodeList.actionOrActivities.ToArray();

		private String? _headline  = default;

		[Description("Words set at the head of a passage or page to introduce or categorize.")]
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
	[Description("The nature and timings of a daily schedule by days of the week.")]
	[CategoryOrder("scheduleByDayOfWeek",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class scheduleByDayOfWeekViewModel : ComplexViewModel<scheduleByDayOfWeek> {
		private categoryOfSchedule? _categoryOfSchedule  = default;

		[Description("The type of schedule, for instance opening, closure, etc.")]
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

		private String? _text  = default;

		[Description("A non-formatted digital text string.")]
		[Editor(typeof(Editors.HorizonEditor<scheduleByDayOfWeek>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
			}
		}

		[Description("The regular weekly operation times of a service or schedule.")]
		[Multiplicity(1)]
		public ObservableCollection<timeIntervalsByDayOfWeekViewModel> timeIntervalsByDayOfWeek  { get; set; } = new ();


		public scheduleByDayOfWeekViewModel Load(scheduleByDayOfWeek instance) {
			categoryOfSchedule = instance.categoryOfSchedule;
			text = instance.text;
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
				text = this.text,
				timeIntervalsByDayOfWeek = this.timeIntervalsByDayOfWeek.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public scheduleByDayOfWeek Model => new () {
			categoryOfSchedule = this._categoryOfSchedule,
			text = this._text,
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
	/// Provides an indication of the vertical and horizontal positional uncertainty of bathymetric data, optionally within a specified date range.
	/// </summary>
	[Description("Provides an indication of the vertical and horizontal positional uncertainty of bathymetric data, optionally within a specified date range.")]
	[CategoryOrder("spatialAccuracy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class spatialAccuracyViewModel : ComplexViewModel<spatialAccuracy> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		private horizontalPositionUncertaintyViewModel? _horizontalPositionUncertainty  = default;

		[Description("The best estimate of the accuracy of a position.")]
		[ExpandableObject]
		[Optional]
		public horizontalPositionUncertaintyViewModel? horizontalPositionUncertainty {
			get {
				return _horizontalPositionUncertainty;
			}
			set {
				SetValue(ref _horizontalPositionUncertainty, value);
			}
		}

		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Description("The best estimate of the vertical accuracy of depths, heights, vertical distances and vertical clearances.")]
		[ExpandableObject]
		[Optional]
		public verticalUncertaintyViewModel? verticalUncertainty {
			get {
				return _verticalUncertainty;
			}
			set {
				SetValue(ref _verticalUncertainty, value);
			}
		}


		public spatialAccuracyViewModel Load(spatialAccuracy instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			horizontalPositionUncertainty = new ();
			if (instance.horizontalPositionUncertainty != default) {
				horizontalPositionUncertainty.Load(instance.horizontalPositionUncertainty);
			}
			verticalUncertainty = new ();
			if (instance.verticalUncertainty != default) {
				verticalUncertainty.Load(instance.verticalUncertainty);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new spatialAccuracy {
				fixedDateRange = this.fixedDateRange?.Model,
				horizontalPositionUncertainty = this.horizontalPositionUncertainty?.Model,
				verticalUncertainty = this.verticalUncertainty?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public spatialAccuracy Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			horizontalPositionUncertainty = this._horizontalPositionUncertainty?.Model,
			verticalUncertainty = this._verticalUncertainty?.Model,
		};

		public override string? ToString() => $"Spatial Accuracy";
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
		[Editor(typeof(Editors.HorizonEditor<sourceIndication>), typeof(Editors.HorizonEditor))]
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

		private String? _countryName  = default;

		[Description("The name of a nation.")]
		[Editor(typeof(Editors.HorizonEditor<sourceIndication>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? countryName {
			get {
				return _countryName;
			}
			set {
				SetValue(ref _countryName, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Editor(typeof(Editors.HorizonEditor<sourceIndication>), typeof(Editors.HorizonEditor))]
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
		[Editor(typeof(Editors.HorizonEditor<sourceIndication>), typeof(Editors.HorizonEditor))]
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

		[Description("The date that the item was observed, done, or investigated.")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();


		public sourceIndicationViewModel Load(sourceIndication instance) {
			categoryOfAuthority = instance.categoryOfAuthority;
			countryName = instance.countryName;
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
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
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				featureName = this.featureName.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public sourceIndication Model => new () {
			categoryOfAuthority = this._categoryOfAuthority,
			countryName = this._countryName,
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
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
	/// The complex attribute describes the period of the hydrographic survey, as the time between its sub-attributes.
	/// </summary>
	[Description("The complex attribute describes the period of the hydrographic survey, as the time between its sub-attributes.")]
	[CategoryOrder("surveyDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class surveyDateRangeViewModel : ComplexViewModel<surveyDateRange> {
		private String? _dateStart  = default;

		[Description("The earliest date on which an object (for example a buoy) will be present.")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? dateStart {
			get {
				return _dateStart;
			}
			set {
				SetValue(ref _dateStart, value);
			}
		}

		private String _dateEnd  = string.Empty;

		[Description("The latest date on which an object (for example a buoy) will be present.")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Mandatory]
		public String dateEnd {
			get {
				return _dateEnd;
			}
			set {
				SetValue(ref _dateEnd, value);
			}
		}


		public surveyDateRangeViewModel Load(surveyDateRange instance) {
			dateStart = instance.dateStart;
			dateEnd = instance.dateEnd;
			return this;
		}

		public override string Serialize() {
			var instance = new surveyDateRange {
				dateStart = this.dateStart,
				dateEnd = this.dateEnd,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public surveyDateRange Model => new () {
			dateStart = this._dateStart,
			dateEnd = this._dateEnd,
		};

		public override string? ToString() => $"Survey Date Range";
	}


	/// <summary>
	/// A means or channel of communicating at a distance by electrical or electromagnetic means such as telegraphy, telephony, or broadcasting.
	/// </summary>
	[Description("A means or channel of communicating at a distance by electrical or electromagnetic means such as telegraphy, telephony, or broadcasting.")]
	[CategoryOrder("telecommunications",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class telecommunicationsViewModel : ComplexViewModel<telecommunications> {
		private categoryOfCommunicationPreference? _categoryOfCommunicationPreference  = default;

		[Description("Classification of frequencies, VHF channels, telephone numbers, or other means of communication based on preference.")]
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

		private String _telecommunicationIdentifier  = string.Empty;

		[Description("An identifier, such as words, numbers, letters, symbols, or any combination of those used to establish a contact to a particular person, organisation or service.")]
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

		private String? _telecommunicationCarrier  = default;

		[Description("The name of a provider or type of carrier for a telecommunication service. This service may include land line based, shore based or satellite based radio connections.")]
		[Editor(typeof(Editors.HorizonEditor<telecommunications>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? telecommunicationCarrier {
			get {
				return _telecommunicationCarrier;
			}
			set {
				SetValue(ref _telecommunicationCarrier, value);
			}
		}

		private String? _contactInstructions  = default;

		[Description("Instructions provided on how to contact a particular person, organisation or service.")]
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

		[Description("Classification of methods of communication over a distance by electrical, electronic, or electromagnetic means.")]
		[Optional]
		public ObservableCollection<telecommunicationService> telecommunicationService  { get; set; } = new ();

		[Browsable(false)]
		public telecommunicationService[] telecommunicationServiceList => [(telecommunicationService)1,(telecommunicationService)2,(telecommunicationService)3,(telecommunicationService)4,(telecommunicationService)5,(telecommunicationService)6,(telecommunicationService)7,(telecommunicationService)8];


		public telecommunicationsViewModel Load(telecommunications instance) {
			categoryOfCommunicationPreference = instance.categoryOfCommunicationPreference;
			telecommunicationIdentifier = instance.telecommunicationIdentifier;
			telecommunicationCarrier = instance.telecommunicationCarrier;
			contactInstructions = instance.contactInstructions;
			telecommunicationService.Clear();
			if (instance.telecommunicationService is not null) {
				foreach(var e in instance.telecommunicationService)
					telecommunicationService.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new telecommunications {
				categoryOfCommunicationPreference = this.categoryOfCommunicationPreference,
				telecommunicationIdentifier = this.telecommunicationIdentifier,
				telecommunicationCarrier = this.telecommunicationCarrier,
				contactInstructions = this.contactInstructions,
				telecommunicationService = this.telecommunicationService.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public telecommunications Model => new () {
			categoryOfCommunicationPreference = this._categoryOfCommunicationPreference,
			telecommunicationIdentifier = this._telecommunicationIdentifier,
			telecommunicationCarrier = this._telecommunicationCarrier,
			contactInstructions = this._contactInstructions,
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
	/// Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.
	/// </summary>
	[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
	[CategoryOrder("textContent",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class textContentViewModel : ComplexViewModel<textContent> {
		private categoryOfText? _categoryOfText  = default;

		[Description("Classification of completeness of textual information in relation to the source material from which it is derived.")]
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

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private onlineResourceViewModel? _onlineResource  = default;

		[Description("Information about online sources from which a resource or data can be obtained.")]
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

		[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();


		public textContentViewModel Load(textContent instance) {
			categoryOfText = instance.categoryOfText;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			onlineResource = new ();
			if (instance.onlineResource != default) {
				onlineResource.Load(instance.onlineResource);
			}
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new textContent {
				categoryOfText = this.categoryOfText,
				information = this.information.Select(e => e.Model).ToList(),
				onlineResource = this.onlineResource?.Model,
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public textContent Model => new () {
			categoryOfText = this._categoryOfText,
			information = this.information.Select(e => e.Model).ToList(),
			onlineResource = this._onlineResource?.Model,
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"Text Content";

		public textContentViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
		}
	}


	/// <summary>
	/// The regular weekly operation times of a service or schedule.
	/// </summary>
	[Description("The regular weekly operation times of a service or schedule.")]
	[CategoryOrder("timeIntervalsByDayOfWeek",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class timeIntervalsByDayOfWeekViewModel : ComplexViewModel<timeIntervalsByDayOfWeek> {
		[Description("Any one of seven days in a week.")]
		[Multiplicity(0, 7)]
		public ObservableCollection<dayOfWeek> dayOfWeek  { get; set; } = new ();

		[Browsable(false)]
		public dayOfWeek[] dayOfWeekList => [(dayOfWeek)1,(dayOfWeek)2,(dayOfWeek)3,(dayOfWeek)4,(dayOfWeek)5,(dayOfWeek)6,(dayOfWeek)7];

		private Boolean? _dayOfWeekIsRange  = default;

		[Description("A statement expressing if the days of the week identified define a range or not.")]
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

		[Description("The time corresponding to the start of an active period.")]
		[Optional]
		public ObservableCollection<S100Framework.DomainModel.S100.Time> timeOfDayStart  { get; set; } = new ();

		[Description("The time corresponding to the end of an active period.")]
		[Optional]
		public ObservableCollection<S100Framework.DomainModel.S100.Time> timeOfDayEnd  { get; set; } = new ();


		public timeIntervalsByDayOfWeekViewModel Load(timeIntervalsByDayOfWeek instance) {
			dayOfWeek.Clear();
			if (instance.dayOfWeek is not null) {
				foreach(var e in instance.dayOfWeek)
					dayOfWeek.Add(e);
			}
			dayOfWeekIsRange = instance.dayOfWeekIsRange;
			timeOfDayStart.Clear();
			if (instance.timeOfDayStart is not null) {
				foreach(var e in instance.timeOfDayStart)
					timeOfDayStart.Add(e);
			}
			timeOfDayEnd.Clear();
			if (instance.timeOfDayEnd is not null) {
				foreach(var e in instance.timeOfDayEnd)
					timeOfDayEnd.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new timeIntervalsByDayOfWeek {
				dayOfWeek = this.dayOfWeek.ToList(),
				dayOfWeekIsRange = this.dayOfWeekIsRange,
				timeOfDayStart = this.timeOfDayStart.ToList(),
				timeOfDayEnd = this.timeOfDayEnd.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public timeIntervalsByDayOfWeek Model => new () {
			dayOfWeek = this.dayOfWeek.ToList(),
			dayOfWeekIsRange = this._dayOfWeekIsRange,
			timeOfDayStart = this.timeOfDayStart.ToList(),
			timeOfDayEnd = this.timeOfDayEnd.ToList(),
		};

		public override string? ToString() => $"Time Intervals by Day of Week";

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
	}


	/// <summary>
	/// The best estimate of the vertical accuracy of depths, heights, vertical distances and vertical clearances.
	/// </summary>
	[Description("The best estimate of the vertical accuracy of depths, heights, vertical distances and vertical clearances.")]
	[CategoryOrder("verticalUncertainty",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class verticalUncertaintyViewModel : ComplexViewModel<verticalUncertainty> {
		private double _uncertaintyFixed  = default;

		[Description("The best estimate of the fixed horizontal or vertical accuracy component for positions, depths, heights, vertical distances and vertical clearances.")]
		[Editor(typeof(Editors.HorizonEditor<verticalUncertainty>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double uncertaintyFixed {
			get {
				return _uncertaintyFixed;
			}
			set {
				SetValue(ref _uncertaintyFixed, value);
			}
		}

		private double? _uncertaintyVariableFactor  = default;

		[Description("The factor to be applied to the variable component of an uncertainty equation so as to provide the best estimate of the variable horizontal or vertical accuracy component for positions, depths, heights, vertical distances and vertical clearances.")]
		[Editor(typeof(Editors.HorizonEditor<verticalUncertainty>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? uncertaintyVariableFactor {
			get {
				return _uncertaintyVariableFactor;
			}
			set {
				SetValue(ref _uncertaintyVariableFactor, value);
			}
		}


		public verticalUncertaintyViewModel Load(verticalUncertainty instance) {
			uncertaintyFixed = instance.uncertaintyFixed;
			uncertaintyVariableFactor = instance.uncertaintyVariableFactor;
			return this;
		}

		public override string Serialize() {
			var instance = new verticalUncertainty {
				uncertaintyFixed = this.uncertaintyFixed,
				uncertaintyVariableFactor = this.uncertaintyVariableFactor,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public verticalUncertainty Model => new () {
			uncertaintyFixed = this._uncertaintyFixed,
			uncertaintyVariableFactor = this._uncertaintyVariableFactor,
		};

		public override string? ToString() => $"Vertical Uncertainty";
	}


	/// <summary>
	/// Combinations of values of measurable characteristics or dimensions of vessels, used to specify size and tonnage ranges.
	/// </summary>
	[Description("Combinations of values of measurable characteristics or dimensions of vessels, used to specify size and tonnage ranges.")]
	[CategoryOrder("vesselMeasurementsSpecification",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class vesselMeasurementsSpecificationViewModel : ComplexViewModel<vesselMeasurementsSpecification> {
		private comparisonOperator _comparisonOperator  = default;

		[Description("Numerical comparison.")]
		[Editor(typeof(Editors.HorizonEditor<vesselMeasurementsSpecification>), typeof(Editors.HorizonEditor))]
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

		private vesselsCharacteristics _vesselsCharacteristics  = default;

		[Description("Characteristics of vessels.")]
		[Editor(typeof(Editors.HorizonEditor<vesselMeasurementsSpecification>), typeof(Editors.HorizonEditor))]
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

		[Description("The value of a particular characteristic such as a dimension or tonnage of a vessel.")]
		[Editor(typeof(Editors.HorizonEditor<vesselMeasurementsSpecification>), typeof(Editors.HorizonEditor))]
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

		[Description("The unit used for vessel characteristics attribute.")]
		[Editor(typeof(Editors.HorizonEditor<vesselMeasurementsSpecification>), typeof(Editors.HorizonEditor))]
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
		public vesselsCharacteristicsUnit[] vesselsCharacteristicsUnitList => [(vesselsCharacteristicsUnit)1,(vesselsCharacteristicsUnit)3,(vesselsCharacteristicsUnit)4,(vesselsCharacteristicsUnit)5,(vesselsCharacteristicsUnit)6,(vesselsCharacteristicsUnit)7,(vesselsCharacteristicsUnit)9];


		public vesselMeasurementsSpecificationViewModel Load(vesselMeasurementsSpecification instance) {
			comparisonOperator = instance.comparisonOperator;
			vesselsCharacteristics = instance.vesselsCharacteristics;
			vesselsCharacteristicsValue = instance.vesselsCharacteristicsValue;
			vesselsCharacteristicsUnit = instance.vesselsCharacteristicsUnit;
			return this;
		}

		public override string Serialize() {
			var instance = new vesselMeasurementsSpecification {
				comparisonOperator = this.comparisonOperator,
				vesselsCharacteristics = this.vesselsCharacteristics,
				vesselsCharacteristicsValue = this.vesselsCharacteristicsValue,
				vesselsCharacteristicsUnit = this.vesselsCharacteristicsUnit,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public vesselMeasurementsSpecification Model => new () {
			comparisonOperator = this._comparisonOperator,
			vesselsCharacteristics = this._vesselsCharacteristics,
			vesselsCharacteristicsValue = this._vesselsCharacteristicsValue,
			vesselsCharacteristicsUnit = this._vesselsCharacteristicsUnit,
		};

		public override string? ToString() => $"Vessel Measurements Specification";
	}



	/// <summary>
	/// A feature association for the binding between at least one instance of a geo feature and an instance of an information type.
	/// </summary>
	[Description("A feature association for the binding between at least one instance of a geo feature and an instance of an information type.")]
	[CategoryOrder("AdditionalInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AdditionalInformationViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new AdditionalInformation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Additional information";
	}



	/// <summary>
	/// Contact information for an authority
	/// </summary>
	[Description("Contact information for an authority")]
	[CategoryOrder("AuthorityContact",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AuthorityContactViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new AuthorityContact {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Authority contact";
	}



	/// <summary>
	/// Service hours for an authority
	/// </summary>
	[Description("Service hours for an authority")]
	[CategoryOrder("AuthorityHours",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AuthorityHoursViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new AuthorityHours {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Authority hours";
	}



	/// <summary>
	/// Association between a geographic location and a regulation, restriction, recommendation, or nautical information
	/// </summary>
	[Description("Association between a geographic location and a regulation, restriction, recommendation, or nautical information")]
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
	[Description("Exception to the usual working day")]
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
	[Description("There may be more than one such authority depending on how responsibilities are divided")]
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
	/// Related organisation
	/// </summary>
	[Description("Related organisation")]
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
	/// Association class specifying the relationship between the subset of vessels described by an APPLIC data object and a regulation (restriction, recommendation, or nautical information).
	/// </summary>
	[Description("Association class specifying the relationship between the subset of vessels described by an APPLIC data object and a regulation (restriction, recommendation, or nautical information).")]
	[CategoryOrder("InclusionType",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class InclusionTypeViewModel : InformationAssociationViewModel {
		private membership _membership  = default;

		[Description("Indicates whether a vessel is included or excluded from the regulation/restriction/recommendation/nautical information.")]
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
		public membership[] membershipList => [(membership)1,(membership)2];


		public override string Serialize() {
			var instance = new InclusionType {
				membership = this.membership,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"InclusionType";
	}



	/// <summary>
	/// Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit,  enter, or use  a feature.
	/// </summary>
	[Description("Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit,  enter, or use  a feature.")]
	[CategoryOrder("PermissionType",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PermissionTypeViewModel : InformationAssociationViewModel {
		private categoryOfRelationship _categoryOfRelationship  = default;

		[Description("Expresses constraints or requirements on vessel actions or activities in relation to a geographic feature, facility, or service.")]
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
		public categoryOfRelationship[] categoryOfRelationshipList => [(categoryOfRelationship)1,(categoryOfRelationship)2,(categoryOfRelationship)3,(categoryOfRelationship)4,(categoryOfRelationship)5,(categoryOfRelationship)6,(categoryOfRelationship)7];


		public override string Serialize() {
			var instance = new PermissionType {
				categoryOfRelationship = this.categoryOfRelationship,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Permission Type";
	}



	/// <summary>
	/// The controlling authority for a service area
	/// </summary>
	[Description("The controlling authority for a service area")]
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
	/// An association for the binding between a spatial type and its spatial quality information.
	/// </summary>
	[Description("An association for the binding between a spatial type and its spatial quality information.")]
	[CategoryOrder("SpatialAssociation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SpatialAssociationViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new SpatialAssociation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Spatial Association";
	}



	/// <summary>
	/// A feature association for the binding between a geo feature and the cartographically positioned location for text.
	/// </summary>
	[Description("A feature association for the binding between a geo feature and the cartographically positioned location for text.")]
	[CategoryOrder("TextAssociation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TextAssociationViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new TextAssociation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Text association";
	}



	/// <summary>
	/// Describes the relationship between vessel characteristics and: (i) the applicability of an associated information object or feature to the vessel; or, (ii) the use of a facility, place, or service by the vessel; or, (iii) passage of the vessel through an area.
	/// </summary>
	[Description("Describes the relationship between vessel characteristics and: (i) the applicability of an associated information object or feature to the vessel; or, (ii) the use of a facility, place, or service by the vessel; or, (iii) passage of the vessel through an area.")]
	[CategoryOrder("Applicability",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ApplicabilityViewModel : InformationViewModel<Applicability> {
		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		private Boolean? _inBallast  = default;

		[Description("Whether the vessel is in ballast.")]
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

		[Description("Classification of the different types of cargo that a ship may be carrying.")]
		[Category("Applicability")]
		[Optional]
		public ObservableCollection<categoryOfCargo> categoryOfCargo  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfCargo[] categoryOfCargoList => [(categoryOfCargo)1,(categoryOfCargo)2,(categoryOfCargo)3,(categoryOfCargo)4,(categoryOfCargo)5,(categoryOfCargo)6,(categoryOfCargo)7,(categoryOfCargo)8,(categoryOfCargo)10,(categoryOfCargo)11,(categoryOfCargo)12,(categoryOfCargo)13,(categoryOfCargo)14,(categoryOfCargo)15];

		[Description("Classification of dangerous goods or hazardous materials based on the International Maritime Dangerous Goods Code (IMDG Code).")]
		[Category("Applicability")]
		[Optional]
		public ObservableCollection<categoryOfDangerousOrHazardousCargo> categoryOfDangerousOrHazardousCargo  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfDangerousOrHazardousCargo[] categoryOfDangerousOrHazardousCargoList => [(categoryOfDangerousOrHazardousCargo)1,(categoryOfDangerousOrHazardousCargo)2,(categoryOfDangerousOrHazardousCargo)3,(categoryOfDangerousOrHazardousCargo)4,(categoryOfDangerousOrHazardousCargo)5,(categoryOfDangerousOrHazardousCargo)6,(categoryOfDangerousOrHazardousCargo)7,(categoryOfDangerousOrHazardousCargo)8,(categoryOfDangerousOrHazardousCargo)9,(categoryOfDangerousOrHazardousCargo)10,(categoryOfDangerousOrHazardousCargo)11,(categoryOfDangerousOrHazardousCargo)12,(categoryOfDangerousOrHazardousCargo)13,(categoryOfDangerousOrHazardousCargo)14,(categoryOfDangerousOrHazardousCargo)15,(categoryOfDangerousOrHazardousCargo)16,(categoryOfDangerousOrHazardousCargo)17,(categoryOfDangerousOrHazardousCargo)18,(categoryOfDangerousOrHazardousCargo)19,(categoryOfDangerousOrHazardousCargo)20,(categoryOfDangerousOrHazardousCargo)21];

		private categoryOfVessel? _categoryOfVessel  = default;

		[Description("Classification of vessels by function or use.")]
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

		[Description("The locality of vessel registration or enrolment relative to the nationality of a port, territorial sea, administrative area, exclusive zone or other location.")]
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

		[Description("Expresses whether all the constraints described by its co-attributes must be satisfied, or only one such constraint need be satisfied.")]
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

		[Description("The thickness of ice that the ship can safely transit.")]
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

		[Description("A description of the required handling characteristics of a vessel including hull design, main and auxiliary machinery, cargo handling equipment, navigation equipment and manoeuvring behaviour.")]
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

		private String? _destination  = default;

		[Description("The place or general direction to which a vessel is going or directed.")]
		[Category("Applicability")]
		[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? destination {
			get {
				return _destination;
			}
			set {
				SetValue(ref _destination, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("Applicability")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Combinations of values of measurable characteristics or dimensions of vessels, used to specify size and tonnage ranges.")]
		[Category("Applicability")]
		[Optional]
		public ObservableCollection<vesselMeasurementsSpecificationViewModel> vesselMeasurementsSpecification  { get; set; } = new ();


		#region InformationBindings

		public class InclusionTypeViewModel : ViewModelBase, IInformationBinding {
			public InclusionTypeViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "InclusionType",
					role = "theApplicableRxN",
					roleType = roleType.association,
					informationTypes = ["AbstractRxN"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<InclusionType> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = InclusionType,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<ApplicabilityViewModel.InclusionTypeViewModel> InclusionTypes { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. InclusionTypes.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


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
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
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
			destination = instance.destination;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			vesselMeasurementsSpecification.Clear();
			if (instance.vesselMeasurementsSpecification is not null) {
				foreach(var e in instance.vesselMeasurementsSpecification)
					vesselMeasurementsSpecification.Add(new vesselMeasurementsSpecificationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Applicability {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				inBallast = this.inBallast,
				categoryOfCargo = this.categoryOfCargo.ToList(),
				categoryOfDangerousOrHazardousCargo = this.categoryOfDangerousOrHazardousCargo.ToList(),
				categoryOfVessel = this.categoryOfVessel,
				categoryOfVesselRegistry = this.categoryOfVesselRegistry,
				logicalConnectives = this.logicalConnectives,
				thicknessOfIceCapability = this.thicknessOfIceCapability,
				vesselPerformance = this.vesselPerformance,
				destination = this.destination,
				information = this.information.Select(e => e.Model).ToList(),
				vesselMeasurementsSpecification = this.vesselMeasurementsSpecification.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Applicability Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			inBallast = this._inBallast,
			categoryOfCargo = this.categoryOfCargo.ToList(),
			categoryOfDangerousOrHazardousCargo = this.categoryOfDangerousOrHazardousCargo.ToList(),
			categoryOfVessel = this._categoryOfVessel,
			categoryOfVesselRegistry = this._categoryOfVesselRegistry,
			logicalConnectives = this._logicalConnectives,
			thicknessOfIceCapability = this._thicknessOfIceCapability,
			vesselPerformance = this._vesselPerformance,
			destination = this._destination,
			information = this.information.Select(e => e.Model).ToList(),
			vesselMeasurementsSpecification = this.vesselMeasurementsSpecification.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Applicability.informationBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
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
			vesselMeasurementsSpecification.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(vesselMeasurementsSpecification));
			};
			InclusionTypes.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(InclusionTypes));
			};
		}
	}



	/// <summary>
	/// A person or organisation having political or administrative power and control.
	/// </summary>
	[Description("A person or organisation having political or administrative power and control.")]
	[CategoryOrder("Authority",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AuthorityViewModel : InformationViewModel<Authority> {
		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		private categoryOfAuthority _categoryOfAuthority  = default;

		[Description("The type of person, government agency or organisation granted powers of managing or controlling access to and/or activity in an area.")]
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

		private textContentViewModel? _textContent  = default;

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("Authority")]
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


		#region InformationBindings

		public class AuthorityContactViewModel : ViewModelBase, IInformationBinding {
			public AuthorityContactViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
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
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<AuthorityContact> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = AuthorityContact,
			};
		}

		public class RelatedOrganisationViewModel : ViewModelBase, IInformationBinding {
			public RelatedOrganisationViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = default,
					association = "RelatedOrganisation",
					role = "organisationRelatedRxN",
					roleType = roleType.association,
					informationTypes = ["AbstractRxN"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<RelatedOrganisation> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = RelatedOrganisation,
			};
		}

		public class AuthorityHoursViewModel : ViewModelBase, IInformationBinding {
			public AuthorityHoursViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
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
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<AuthorityHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = AuthorityHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<AuthorityViewModel.AuthorityContactViewModel> AuthorityContacts { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<AuthorityViewModel.RelatedOrganisationViewModel> RelatedOrganisations { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<AuthorityViewModel.AuthorityHoursViewModel> AuthorityHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. AuthorityContacts.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. RelatedOrganisations.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. AuthorityHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

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
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
			categoryOfAuthority = instance.categoryOfAuthority;
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Authority {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				categoryOfAuthority = this.categoryOfAuthority,
				textContent = this.textContent?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Authority Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			categoryOfAuthority = this._categoryOfAuthority,
			textContent = this._textContent?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Authority.informationBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			AuthorityContacts.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(AuthorityContacts));
			};
			RelatedOrganisations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(RelatedOrganisations));
			};
			AuthorityHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(AuthorityHours));
			};
		}
	}



	/// <summary>
	/// Information on how to reach a person or organisation by postal, internet, telephone, telex and radio systems.
	/// </summary>
	[Description("Information on how to reach a person or organisation by postal, internet, telephone, telex and radio systems.")]
	[CategoryOrder("ContactDetails",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ContactDetailsViewModel : InformationViewModel<ContactDetails> {
		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		private String? _callName  = default;

		[Description("The designated call name of a station; for example, radio station, radar station, pilot.")]
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

		[Description("The designated call-sign of a station (radio station, radar station, pilot, ...).")]
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

		[Description("Classification of frequencies, VHF channels, telephone numbers, or other means of communication based on preference.")]
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

		[Description("A channel number assigned to a specific radio frequency, frequencies or frequency band.")]
		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();

		private String? _contactInstructions  = default;

		[Description("Instructions provided on how to contact a particular person, organisation or service.")]
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

		[Description("The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.")]
		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<String> language  { get; set; } = new ();

		private String? _mMSICode  = default;

		[Description("The Maritime Mobile Service Identity (MMSI) Code is formed of a series of nine digits which are transmitted over the radio path in order to uniquely identify ship stations, ship earth stations,coast stations, coast earth stations, and group calls. These identities are formed in such a way that the identity or part thereof can be used by telephone and telex subscribers connected to the general telecommunications network principally to call ships automatically.")]
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

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<contactAddressViewModel> contactAddress  { get; set; } = new ();

		[Description("A pair of frequencies for transmitting and receiving radio signals. The shore station transmits and receives on the frequencies indicated.")]
		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<frequencyPairViewModel> frequencyPair  { get; set; } = new ();

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


		#region InformationBindings

		public class AuthorityContactViewModel : ViewModelBase, IInformationBinding {
			public AuthorityContactViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
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
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<AuthorityContact> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = AuthorityContact,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<ContactDetailsViewModel.AuthorityContactViewModel> AuthorityContacts { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. AuthorityContacts.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

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
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
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
			language.Clear();
			if (instance.language is not null) {
				foreach(var e in instance.language)
					language.Add(e);
			}
			mMSICode = instance.mMSICode;
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
			return this;
		}

		public override string Serialize() {
			var instance = new ContactDetails {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				callName = this.callName,
				callSign = this.callSign,
				categoryOfCommunicationPreference = this.categoryOfCommunicationPreference,
				communicationChannel = this.communicationChannel.ToList(),
				contactInstructions = this.contactInstructions,
				language = this.language.ToList(),
				mMSICode = this.mMSICode,
				contactAddress = this.contactAddress.Select(e => e.Model).ToList(),
				frequencyPair = this.frequencyPair.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
				telecommunications = this.telecommunications.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ContactDetails Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			callName = this._callName,
			callSign = this._callSign,
			categoryOfCommunicationPreference = this._categoryOfCommunicationPreference,
			communicationChannel = this.communicationChannel.ToList(),
			contactInstructions = this._contactInstructions,
			language = this.language.ToList(),
			mMSICode = this._mMSICode,
			contactAddress = this.contactAddress.Select(e => e.Model).ToList(),
			frequencyPair = this.frequencyPair.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
			telecommunications = this.telecommunications.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.ContactDetails.informationBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(communicationChannel));
			};
			language.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(language));
			};
			contactAddress.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(contactAddress));
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
			AuthorityContacts.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(AuthorityContacts));
			};
		}
	}



	/// <summary>
	/// Nautical information about a related area or facility.
	/// </summary>
	[Description("Nautical information about a related area or facility.")]
	[CategoryOrder("NauticalInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NauticalInformationViewModel : InformationViewModel<NauticalInformation> {
		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Description("The type of person, government agency or organisation granted powers of managing or controlling access to and/or activity in an area.")]
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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


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
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
			categoryOfAuthority = instance.categoryOfAuthority;
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new NauticalInformation {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				categoryOfAuthority = this.categoryOfAuthority,
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public NauticalInformation Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			categoryOfAuthority = this._categoryOfAuthority,
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.NauticalInformation.informationBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(rxNCode));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}



	/// <summary>
	/// Days when many services are not available. Often days of festivity or recreation or public holidays when normal working hours are limited, especially a national or religious festival, etc.
	/// </summary>
	[Description("Days when many services are not available. Often days of festivity or recreation or public holidays when normal working hours are limited, especially a national or religious festival, etc.")]
	[CategoryOrder("NonStandardWorkingDay",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NonStandardWorkingDayViewModel : InformationViewModel<NonStandardWorkingDay> {
		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		[Description("The date of an event.")]
		[Category("NonStandardWorkingDay")]
		[Optional]
		public ObservableCollection<String> dateFixed  { get; set; } = new ();

		[Description("A day which is not fixed in the Gregorian calendar.")]
		[Category("NonStandardWorkingDay")]
		[Optional]
		public ObservableCollection<String> dateVariable  { get; set; } = new ();

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("NonStandardWorkingDay")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


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
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			dateFixed = this.dateFixed.ToList(),
			dateVariable = this.dateVariable.ToList(),
			information = this.information.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.NonStandardWorkingDay.informationBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
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
	/// Recommendations for a related area or facility.
	/// </summary>
	[Description("Recommendations for a related area or facility.")]
	[CategoryOrder("Recommendations",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RecommendationsViewModel : InformationViewModel<Recommendations> {
		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Description("The type of person, government agency or organisation granted powers of managing or controlling access to and/or activity in an area.")]
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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


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
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
			categoryOfAuthority = instance.categoryOfAuthority;
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Recommendations {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				categoryOfAuthority = this.categoryOfAuthority,
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Recommendations Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			categoryOfAuthority = this._categoryOfAuthority,
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Recommendations.informationBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(rxNCode));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}



	/// <summary>
	/// Regulations for a related area or facility.
	/// </summary>
	[Description("Regulations for a related area or facility.")]
	[CategoryOrder("Regulations",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RegulationsViewModel : InformationViewModel<Regulations> {
		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Description("The type of person, government agency or organisation granted powers of managing or controlling access to and/or activity in an area.")]
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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


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
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
			categoryOfAuthority = instance.categoryOfAuthority;
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Regulations {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				categoryOfAuthority = this.categoryOfAuthority,
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Regulations Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			categoryOfAuthority = this._categoryOfAuthority,
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Regulations.informationBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(rxNCode));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}



	/// <summary>
	/// Restrictions for a related area or facility.
	/// </summary>
	[Description("Restrictions for a related area or facility.")]
	[CategoryOrder("Restrictions",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RestrictionsViewModel : InformationViewModel<Restrictions> {
		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Description("The type of person, government agency or organisation granted powers of managing or controlling access to and/or activity in an area.")]
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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


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
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
			categoryOfAuthority = instance.categoryOfAuthority;
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Restrictions {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				categoryOfAuthority = this.categoryOfAuthority,
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Restrictions Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			categoryOfAuthority = this._categoryOfAuthority,
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Restrictions.informationBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(rxNCode));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}



	/// <summary>
	/// The time when a service is available and known exceptions.
	/// </summary>
	[Description("The time when a service is available and known exceptions.")]
	[CategoryOrder("ServiceHours",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceHoursViewModel : InformationViewModel<ServiceHours> {
		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
		[Category("InformationType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		[Description("The nature and timings of a daily schedule by days of the week.")]
		[Category("ServiceHours")]
		[Multiplicity(1)]
		public ObservableCollection<scheduleByDayOfWeekViewModel> scheduleByDayOfWeek  { get; set; } = new ();

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("ServiceHours")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		#region InformationBindings

		public class ExceptionalWorkdayViewModel : ViewModelBase, IInformationBinding {
			public ExceptionalWorkdayViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
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
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ExceptionalWorkday> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ExceptionalWorkday,
			};
		}

		public class AuthorityHoursViewModel : ViewModelBase, IInformationBinding {
			public AuthorityHoursViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
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
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<AuthorityHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = AuthorityHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<ServiceHoursViewModel.ExceptionalWorkdayViewModel> ExceptionalWorkdays { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<ServiceHoursViewModel.AuthorityHoursViewModel> AuthorityHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. ExceptionalWorkdays.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. AuthorityHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

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
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
			scheduleByDayOfWeek.Clear();
			if (instance.scheduleByDayOfWeek is not null) {
				foreach(var e in instance.scheduleByDayOfWeek)
					scheduleByDayOfWeek.Add(new scheduleByDayOfWeekViewModel().Load(e));
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new ServiceHours {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				scheduleByDayOfWeek = this.scheduleByDayOfWeek.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ServiceHours Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			scheduleByDayOfWeek = this.scheduleByDayOfWeek.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.ServiceHours.informationBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			scheduleByDayOfWeek.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(scheduleByDayOfWeek));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			ExceptionalWorkdays.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ExceptionalWorkdays));
			};
			AuthorityHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(AuthorityHours));
			};
		}
	}



	/// <summary>
	/// The indication of the quality of the locational information for features in a dataset.
	/// </summary>
	[Description("The indication of the quality of the locational information for features in a dataset.")]
	[CategoryOrder("SpatialQuality",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SpatialQualityViewModel : InformationViewModel<SpatialQuality> {
		private qualityOfHorizontalMeasurement? _qualityOfHorizontalMeasurement  = default;

		[Description("The degree of reliability attributed to a position.")]
		[Category("SpatialQuality")]
		[Editor(typeof(Editors.HorizonEditor<SpatialQuality>), typeof(Editors.HorizonEditor))]
		[Optional]
		public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {
			get {
				return _qualityOfHorizontalMeasurement;
			}
			set {
				SetValue(ref _qualityOfHorizontalMeasurement, value);
			}
		}

		[Browsable(false)]
		public qualityOfHorizontalMeasurement[] qualityOfHorizontalMeasurementList => [(qualityOfHorizontalMeasurement)1,(qualityOfHorizontalMeasurement)2,(qualityOfHorizontalMeasurement)3,(qualityOfHorizontalMeasurement)4,(qualityOfHorizontalMeasurement)5,(qualityOfHorizontalMeasurement)6,(qualityOfHorizontalMeasurement)7,(qualityOfHorizontalMeasurement)8,(qualityOfHorizontalMeasurement)9,(qualityOfHorizontalMeasurement)10,(qualityOfHorizontalMeasurement)11];

		[Description("Provides an indication of the vertical and horizontal positional uncertainty of bathymetric data, optionally within a specified date range.")]
		[Category("SpatialQuality")]
		[Optional]
		public ObservableCollection<spatialAccuracyViewModel> spatialAccuracy  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		public SpatialQualityViewModel Load(SpatialQuality instance) {
			qualityOfHorizontalMeasurement = instance.qualityOfHorizontalMeasurement;
			spatialAccuracy.Clear();
			if (instance.spatialAccuracy is not null) {
				foreach(var e in instance.spatialAccuracy)
					spatialAccuracy.Add(new spatialAccuracyViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new SpatialQuality {
				qualityOfHorizontalMeasurement = this.qualityOfHorizontalMeasurement,
				spatialAccuracy = this.spatialAccuracy.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SpatialQuality Model => new () {
			qualityOfHorizontalMeasurement = this._qualityOfHorizontalMeasurement,
			spatialAccuracy = this.spatialAccuracy.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SpatialQuality.informationBindingDefinitions;

		public SpatialQualityViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Spatial Quality";

		public SpatialQualityViewModel() : base() {
			spatialAccuracy.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(spatialAccuracy));
			};
		}
	}



	/// <summary>
	/// An area for which general information regarding navigation, but not directly related to safety of navigation, is available.
	/// </summary>
	[Description("An area for which general information regarding navigation, but not directly related to safety of navigation, is available.")]
	[CategoryOrder("InformationArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class InformationAreaViewModel : FeatureViewModel<InformationArea> {
		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		private categoryOfRelationship _categoryOfRelationship  = default;

		[Description("Expresses constraints or requirements on vessel actions or activities in relation to a geographic feature, facility, or service.")]
		[Category("InformationArea")]
		[Editor(typeof(Editors.HorizonEditor<InformationArea>), typeof(Editors.HorizonEditor))]
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
		public categoryOfRelationship[] categoryOfRelationshipList => [(categoryOfRelationship)1,(categoryOfRelationship)3];

		private actionOrActivity _actionOrActivity  = default;

		[Description("The action or activity of a vessel.")]
		[Category("InformationArea")]
		[Editor(typeof(Editors.HorizonEditor<InformationArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public actionOrActivity actionOrActivity {
			get {
				return _actionOrActivity;
			}
			set {
				SetValue(ref _actionOrActivity, value);
			}
		}

		[Browsable(false)]
		public actionOrActivity[] actionOrActivityList =>  CodeList.actionOrActivities.ToArray();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public InformationAreaViewModel Load(InformationArea instance) {
			interoperabilityIdentifier.Clear();
			if (instance.interoperabilityIdentifier is not null) {
				foreach(var e in instance.interoperabilityIdentifier)
					interoperabilityIdentifier.Add(e);
			}
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
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			categoryOfRelationship = instance.categoryOfRelationship;
			actionOrActivity = instance.actionOrActivity;
			return this;
		}

		public override string Serialize() {
			var instance = new InformationArea {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				categoryOfRelationship = this.categoryOfRelationship,
				actionOrActivity = this.actionOrActivity,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public InformationArea Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfRelationship = this._categoryOfRelationship,
			actionOrActivity = this._actionOrActivity,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.InformationArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.InformationArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.InformationArea.featureBindingDefinitions;

		public InformationAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public InformationAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Information Area";

		public InformationAreaViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}



	/// <summary>
	/// Any area of the intertidal or sub-tidal terrain, together with its overlying water and associated flora, fauna, historical and cultural features, which has been reserved by law or other effective means to protect part or all of the enclosed environment.
	/// </summary>
	[Description("Any area of the intertidal or sub-tidal terrain, together with its overlying water and associated flora, fauna, historical and cultural features, which has been reserved by law or other effective means to protect part or all of the enclosed environment.")]
	[CategoryOrder("MarineProtectedArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class MarineProtectedAreaViewModel : FeatureViewModel<MarineProtectedArea> {
		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Description("Classification of marine protected areas based on IUCN (International Union for Conservation of Nature and Natural Resources) categories.")]
		[Category("MarineProtectedArea")]
		[Multiplicity(1)]
		public ObservableCollection<categoryOfMarineProtectedArea> categoryOfMarineProtectedArea  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfMarineProtectedArea[] categoryOfMarineProtectedAreaList =>  CodeList.categoryOfMarineProtectedAreas.ToArray();

		[Description("The official legal status of each kind of restricted area defines the kind of restriction(s), for example the restriction for a 'game reserve' may be 'entering prohibited'.")]
		[Category("MarineProtectedArea")]
		[Optional]
		public ObservableCollection<categoryOfRestrictedArea> categoryOfRestrictedArea  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfRestrictedArea[] categoryOfRestrictedAreaList => [(categoryOfRestrictedArea)1,(categoryOfRestrictedArea)4,(categoryOfRestrictedArea)5,(categoryOfRestrictedArea)6,(categoryOfRestrictedArea)7,(categoryOfRestrictedArea)10,(categoryOfRestrictedArea)20,(categoryOfRestrictedArea)22,(categoryOfRestrictedArea)23,(categoryOfRestrictedArea)27,(categoryOfRestrictedArea)28,(categoryOfRestrictedArea)31,(categoryOfRestrictedArea)32,(categoryOfRestrictedArea)33];

		private jurisdiction? _jurisdiction  = default;

		[Description("The jurisdiction applicable to an administrative area.")]
		[Category("MarineProtectedArea")]
		[Editor(typeof(Editors.HorizonEditor<MarineProtectedArea>), typeof(Editors.HorizonEditor))]
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
		public jurisdiction[] jurisdictionList => [(jurisdiction)1,(jurisdiction)2,(jurisdiction)3];

		[Description("The official legal statute of each kind of restricted area.")]
		[Category("MarineProtectedArea")]
		[Optional]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)7,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)14,(restriction)15,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)26,(restriction)27,(restriction)38,(restriction)39,(restriction)40,(restriction)41,(restriction)42];

		[Description("The condition of an object at a given instant in time.")]
		[Category("MarineProtectedArea")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)9,(status)18,(status)28,(status)13,(status)14];

		[Description("An official name, title or description. This can be an identifier or an identifier which is an instance of a named designation scheme.")]
		[Category("MarineProtectedArea")]
		[Optional]
		public ObservableCollection<designationViewModel> designation  { get; set; } = new ();


		#region InformationBindings

		public class ProtectedAreaAuthorityViewModel : ViewModelBase, IInformationBinding {
			public ProtectedAreaAuthorityViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
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
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ProtectedAreaAuthority> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ProtectedAreaAuthority,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<MarineProtectedAreaViewModel.ProtectedAreaAuthorityViewModel> ProtectedAreaAuthorities { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. ProtectedAreaAuthorities.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public MarineProtectedAreaViewModel Load(MarineProtectedArea instance) {
			interoperabilityIdentifier.Clear();
			if (instance.interoperabilityIdentifier is not null) {
				foreach(var e in instance.interoperabilityIdentifier)
					interoperabilityIdentifier.Add(e);
			}
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
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			categoryOfMarineProtectedArea.Clear();
			if (instance.categoryOfMarineProtectedArea is not null) {
				foreach(var e in instance.categoryOfMarineProtectedArea)
					categoryOfMarineProtectedArea.Add(e);
			}
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
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				categoryOfMarineProtectedArea = this.categoryOfMarineProtectedArea.ToList(),
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
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfMarineProtectedArea = this.categoryOfMarineProtectedArea.ToList(),
			categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
			jurisdiction = this._jurisdiction,
			restriction = this.restriction.ToList(),
			status = this.status.ToList(),
			designation = this.designation.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.MarineProtectedArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.MarineProtectedArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.MarineProtectedArea.featureBindingDefinitions;

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
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			categoryOfMarineProtectedArea.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfMarineProtectedArea));
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
			ProtectedAreaAuthorities.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ProtectedAreaAuthorities));
			};
		}
	}



	/// <summary>
	/// A specified area designated by an appropriate authority within which navigation is restricted in accordance with certain specified conditions.
	/// </summary>
	[Description("A specified area designated by an appropriate authority within which navigation is restricted in accordance with certain specified conditions.")]
	[CategoryOrder("RestrictedArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RestrictedAreaViewModel : FeatureViewModel<RestrictedArea> {
		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Description("The official legal status of each kind of restricted area defines the kind of restriction(s), for example the restriction for a 'game reserve' may be 'entering prohibited'.")]
		[Category("RestrictedArea")]
		[Optional]
		public ObservableCollection<categoryOfRestrictedArea> categoryOfRestrictedArea  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfRestrictedArea[] categoryOfRestrictedAreaList => [(categoryOfRestrictedArea)1,(categoryOfRestrictedArea)4,(categoryOfRestrictedArea)5,(categoryOfRestrictedArea)6,(categoryOfRestrictedArea)7,(categoryOfRestrictedArea)10,(categoryOfRestrictedArea)20,(categoryOfRestrictedArea)22,(categoryOfRestrictedArea)23,(categoryOfRestrictedArea)27,(categoryOfRestrictedArea)28,(categoryOfRestrictedArea)31,(categoryOfRestrictedArea)32,(categoryOfRestrictedArea)33];

		[Description("The official legal statute of each kind of restricted area.")]
		[Category("RestrictedArea")]
		[Multiplicity(1)]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)7,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)14,(restriction)15,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)26,(restriction)27,(restriction)38,(restriction)39,(restriction)40,(restriction)41,(restriction)42];

		[Description("The condition of an object at a given instant in time.")]
		[Category("RestrictedArea")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)9,(status)18,(status)28,(status)13,(status)14];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public RestrictedAreaViewModel Load(RestrictedArea instance) {
			interoperabilityIdentifier.Clear();
			if (instance.interoperabilityIdentifier is not null) {
				foreach(var e in instance.interoperabilityIdentifier)
					interoperabilityIdentifier.Add(e);
			}
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
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
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
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
				restriction = this.restriction.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RestrictedArea Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
			restriction = this.restriction.ToList(),
			status = this.status.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.RestrictedArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.RestrictedArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.RestrictedArea.featureBindingDefinitions;

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
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
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
	/// The area of any service implemented by a relevant authority primarily designed to improve safety and efficiency of traffic flow and the protection of the environment. It may range from simple information messages, to extensive organisation of the traffic involving national or regional schemes.
	/// </summary>
	[Description("The area of any service implemented by a relevant authority primarily designed to improve safety and efficiency of traffic flow and the protection of the environment. It may range from simple information messages, to extensive organisation of the traffic involving national or regional schemes.")]
	[CategoryOrder("VesselTrafficServiceArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class VesselTrafficServiceAreaViewModel : FeatureViewModel<VesselTrafficServiceArea> {
		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
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

		[Description("The active period of a recurring event or occurrence.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Description("Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

		[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();



		#region InformationBindings

		public class ServiceControlViewModel : ViewModelBase, IInformationBinding {
			public ServiceControlViewModel() {
				if (informationBindings.Length == 1)
					this.role = informationBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.InformationBindingRoleEditor), typeof(Editors.InformationBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.InformationBindingLinkEditor), typeof(Editors.InformationBindingLinkEditor))]
			public string informationId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _informationType = default;

			[ReadOnly(true)]
			public string? informationType {
				get { return _informationType; }
				set {
					SetValue(ref _informationType, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
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
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceControl> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceControl,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<VesselTrafficServiceAreaViewModel.ServiceControlViewModel> ServiceControls { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. ServiceControls.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public VesselTrafficServiceAreaViewModel Load(VesselTrafficServiceArea instance) {
			interoperabilityIdentifier.Clear();
			if (instance.interoperabilityIdentifier is not null) {
				foreach(var e in instance.interoperabilityIdentifier)
					interoperabilityIdentifier.Add(e);
			}
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
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new VesselTrafficServiceArea {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public VesselTrafficServiceArea Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.VesselTrafficServiceArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.VesselTrafficServiceArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.VesselTrafficServiceArea.featureBindingDefinitions;

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
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			ServiceControls.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceControls));
			};
		}
	}



	/// <summary>
	/// A geographical area that describes the coverage and extent of spatial objects.
	/// </summary>
	[Description("A geographical area that describes the coverage and extent of spatial objects.")]
	[CategoryOrder("DataCoverage",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DataCoverageViewModel : FeatureViewModel<DataCoverage> {
		private int _maximumDisplayScale  = default;

		[Description("The largest intended viewing scale for the data.")]
		[Category("DataCoverage")]
		[Editor(typeof(Editors.HorizonEditor<DataCoverage>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int maximumDisplayScale {
			get {
				return _maximumDisplayScale;
			}
			set {
				SetValue(ref _maximumDisplayScale, value);
			}
		}

		private int _minimumDisplayScale  = default;

		[Description("The smallest intended viewing scale for the data.")]
		[Category("DataCoverage")]
		[Editor(typeof(Editors.HorizonEditor<DataCoverage>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int minimumDisplayScale {
			get {
				return _minimumDisplayScale;
			}
			set {
				SetValue(ref _minimumDisplayScale, value);
			}
		}

		private int? _optimumDisplayScale  = default;

		[Description("The largest intended viewing scale for the data.")]
		[Category("DataCoverage")]
		[Editor(typeof(Editors.HorizonEditor<DataCoverage>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? optimumDisplayScale {
			get {
				return _optimumDisplayScale;
			}
			set {
				SetValue(ref _optimumDisplayScale, value);
			}
		}

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("DataCoverage")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public DataCoverageViewModel Load(DataCoverage instance) {
			maximumDisplayScale = instance.maximumDisplayScale;
			minimumDisplayScale = instance.minimumDisplayScale;
			optimumDisplayScale = instance.optimumDisplayScale;
			interoperabilityIdentifier.Clear();
			if (instance.interoperabilityIdentifier is not null) {
				foreach(var e in instance.interoperabilityIdentifier)
					interoperabilityIdentifier.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new DataCoverage {
				maximumDisplayScale = this.maximumDisplayScale,
				minimumDisplayScale = this.minimumDisplayScale,
				optimumDisplayScale = this.optimumDisplayScale,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DataCoverage Model => new () {
			maximumDisplayScale = this._maximumDisplayScale,
			minimumDisplayScale = this._minimumDisplayScale,
			optimumDisplayScale = this._optimumDisplayScale,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.DataCoverage.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.DataCoverage.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.DataCoverage.featureBindingDefinitions;

		public DataCoverageViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public DataCoverageViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Data Coverage";

		public DataCoverageViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
			};
		}
	}



	/// <summary>
	/// An area within which a uniform assessment of the quality of the non-bathymetric data exists.
	/// </summary>
	[Description("An area within which a uniform assessment of the quality of the non-bathymetric data exists.")]
	[CategoryOrder("QualityOfNonBathymetricData",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class QualityOfNonBathymetricDataViewModel : FeatureViewModel<QualityOfNonBathymetricData> {
		private categoryOfTemporalVariation? _categoryOfTemporalVariation  = default;

		[Description("An assessment of the likelihood of change over time.")]
		[Category("QualityOfNonBathymetricData")]
		[Editor(typeof(Editors.HorizonEditor<QualityOfNonBathymetricData>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfTemporalVariation? categoryOfTemporalVariation {
			get {
				return _categoryOfTemporalVariation;
			}
			set {
				SetValue(ref _categoryOfTemporalVariation, value);
			}
		}

		[Browsable(false)]
		public categoryOfTemporalVariation[] categoryOfTemporalVariationList => [(categoryOfTemporalVariation)1,(categoryOfTemporalVariation)4,(categoryOfTemporalVariation)5,(categoryOfTemporalVariation)6];

		private double? _horizontalDistanceUncertainty  = default;

		[Description("The best estimate of the horizontal accuracy of horizontal clearances and distances.")]
		[Category("QualityOfNonBathymetricData")]
		[Editor(typeof(Editors.HorizonEditor<QualityOfNonBathymetricData>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalDistanceUncertainty {
			get {
				return _horizontalDistanceUncertainty;
			}
			set {
				SetValue(ref _horizontalDistanceUncertainty, value);
			}
		}

		private horizontalPositionUncertaintyViewModel? _horizontalPositionUncertainty  = default;

		[Description("The best estimate of the accuracy of a position.")]
		[Category("QualityOfNonBathymetricData")]
		[ExpandableObject]
		[Optional]
		public horizontalPositionUncertaintyViewModel? horizontalPositionUncertainty {
			get {
				return _horizontalPositionUncertainty;
			}
			set {
				SetValue(ref _horizontalPositionUncertainty, value);
			}
		}

		private double? _orientationUncertainty  = default;

		[Description("The best estimate of the accuracy of a bearing.")]
		[Category("QualityOfNonBathymetricData")]
		[Editor(typeof(Editors.HorizonEditor<QualityOfNonBathymetricData>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? orientationUncertainty {
			get {
				return _orientationUncertainty;
			}
			set {
				SetValue(ref _orientationUncertainty, value);
			}
		}

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("QualityOfNonBathymetricData")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

		private sourceIndicationViewModel? _sourceIndication  = default;

		[Description("Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.")]
		[Category("QualityOfNonBathymetricData")]
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

		private surveyDateRangeViewModel? _surveyDateRange  = default;

		[Description("The complex attribute describes the period of the hydrographic survey, as the time between its sub-attributes.")]
		[Category("QualityOfNonBathymetricData")]
		[ExpandableObject]
		[Optional]
		public surveyDateRangeViewModel? surveyDateRange {
			get {
				return _surveyDateRange;
			}
			set {
				SetValue(ref _surveyDateRange, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("QualityOfNonBathymetricData")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public QualityOfNonBathymetricDataViewModel Load(QualityOfNonBathymetricData instance) {
			categoryOfTemporalVariation = instance.categoryOfTemporalVariation;
			horizontalDistanceUncertainty = instance.horizontalDistanceUncertainty;
			horizontalPositionUncertainty = new ();
			if (instance.horizontalPositionUncertainty != default) {
				horizontalPositionUncertainty.Load(instance.horizontalPositionUncertainty);
			}
			orientationUncertainty = instance.orientationUncertainty;
			interoperabilityIdentifier.Clear();
			if (instance.interoperabilityIdentifier is not null) {
				foreach(var e in instance.interoperabilityIdentifier)
					interoperabilityIdentifier.Add(e);
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			surveyDateRange = new ();
			if (instance.surveyDateRange != default) {
				surveyDateRange.Load(instance.surveyDateRange);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new QualityOfNonBathymetricData {
				categoryOfTemporalVariation = this.categoryOfTemporalVariation,
				horizontalDistanceUncertainty = this.horizontalDistanceUncertainty,
				horizontalPositionUncertainty = this.horizontalPositionUncertainty?.Model,
				orientationUncertainty = this.orientationUncertainty,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				sourceIndication = this.sourceIndication?.Model,
				surveyDateRange = this.surveyDateRange?.Model,
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public QualityOfNonBathymetricData Model => new () {
			categoryOfTemporalVariation = this._categoryOfTemporalVariation,
			horizontalDistanceUncertainty = this._horizontalDistanceUncertainty,
			horizontalPositionUncertainty = this._horizontalPositionUncertainty?.Model,
			orientationUncertainty = this._orientationUncertainty,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			sourceIndication = this._sourceIndication?.Model,
			surveyDateRange = this._surveyDateRange?.Model,
			information = this.information.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.QualityOfNonBathymetricData.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.QualityOfNonBathymetricData.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.QualityOfNonBathymetricData.featureBindingDefinitions;

		public QualityOfNonBathymetricDataViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public QualityOfNonBathymetricDataViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Quality of Non-Bathymetric Data";

		public QualityOfNonBathymetricDataViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}



	/// <summary>
	/// The Text Placement feature is used in association with the Feature Name attribute or a light description to optimize text positioning in ECDIS.
	/// </summary>
	[Description("The Text Placement feature is used in association with the Feature Name attribute or a light description to optimize text positioning in ECDIS.")]
	[CategoryOrder("TextPlacement",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TextPlacementViewModel : FeatureViewModel<TextPlacement> {
		private int _textOffsetBearing  = default;

		[Description("The angular distance measured from true north that text associated with a feature is positioned from the feature in an end-user system.")]
		[Category("TextPlacement")]
		[Editor(typeof(Editors.HorizonEditor<TextPlacement>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int textOffsetBearing {
			get {
				return _textOffsetBearing;
			}
			set {
				SetValue(ref _textOffsetBearing, value);
			}
		}

		private int _textOffsetDistance  = default;

		[Description("The distance that text associated with a feature is positioned from the feature in an end-user system.")]
		[Category("TextPlacement")]
		[Editor(typeof(Editors.HorizonEditor<TextPlacement>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int textOffsetDistance {
			get {
				return _textOffsetDistance;
			}
			set {
				SetValue(ref _textOffsetDistance, value);
			}
		}

		private Boolean? _textRotation  = default;

		[Description("A statement that expresses if text associated with a feature is to be rotated in the ECDIS display or not.")]
		[Category("TextPlacement")]
		[Editor(typeof(Editors.HorizonEditor<TextPlacement>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? textRotation {
			get {
				return _textRotation;
			}
			set {
				SetValue(ref _textRotation, value);
			}
		}

		[Description("The attribute from which a text string is derived.")]
		[Category("TextPlacement")]
		[Multiplicity(1, 2)]
		public ObservableCollection<textType> textType  { get; set; } = new ();

		[Browsable(false)]
		public textType[] textTypeList => [(textType)1];

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("TextPlacement")]
		[Editor(typeof(Editors.HorizonEditor<TextPlacement>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		#region FeatureBindings

		public class TextAssociationViewModel : ViewModelBase, IFeatureBinding {
			public TextAssociationViewModel() {
				if (featureBindings.Length == 1)
					this.role = featureBindings[0].role;
			}

			private string _role = string.Empty;

			[Editor(typeof(Editors.FeatureBindingRoleEditor), typeof(Editors.FeatureBindingRoleEditor))]
			public string role {
				get { return _role; }
				set {
					SetValue(ref _role, value);
				}
			}

			private string _referenceId = string.Empty;

			[Editor(typeof(Editors.FeatureBindingLinkEditor), typeof(Editors.FeatureBindingLinkEditor))]
			public string featureId {
				get { return _referenceId; }
				set {
					SetValue(ref _referenceId, value);
				}
			}

			private string? _featureType = default;

			[ReadOnly(true)]
			public string? featureType {
				get { return _featureType; }
				set {
					SetValue(ref _featureType, value);
				}
			}

			private S122.TextAssociationViewModel _association = new();

			[ExpandableObject]
			public S122.TextAssociationViewModel association {
				get { return _association; }
				set {
					SetValue(ref _association, value);
				}
			}

			protected override void Validate() {
				//TODO: Validate role and referenceId
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 1,
					upper = 1,
					association = "TextAssociation",
					role = "thePositionProvider",
					roleType = roleType.composition,
					featureTypes = ["FeatureType"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<TextAssociation> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = TextAssociation,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<TextPlacementViewModel.TextAssociationViewModel> TextAssociations { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. TextAssociations.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public TextPlacementViewModel Load(TextPlacement instance) {
			textOffsetBearing = instance.textOffsetBearing;
			textOffsetDistance = instance.textOffsetDistance;
			textRotation = instance.textRotation;
			textType.Clear();
			if (instance.textType is not null) {
				foreach(var e in instance.textType)
					textType.Add(e);
			}
			scaleMinimum = instance.scaleMinimum;
			return this;
		}

		public override string Serialize() {
			var instance = new TextPlacement {
				textOffsetBearing = this.textOffsetBearing,
				textOffsetDistance = this.textOffsetDistance,
				textRotation = this.textRotation,
				textType = this.textType.ToList(),
				scaleMinimum = this.scaleMinimum,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public TextPlacement Model => new () {
			textOffsetBearing = this._textOffsetBearing,
			textOffsetDistance = this._textOffsetDistance,
			textRotation = this._textRotation,
			textType = this.textType.ToList(),
			scaleMinimum = this._scaleMinimum,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.TextPlacement.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.TextPlacement.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.TextPlacement.featureBindingDefinitions;

		public TextPlacementViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public TextPlacementViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Text Placement";

		public TextPlacementViewModel() : base() {
			textType.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textType));
			};
			TextAssociations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(TextAssociations));
			};
		}
	}



	public static class InformationBindingExtension {
		public static ApplicabilityViewModel LoadInformationBinding(this ApplicabilityViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<InclusionType> inclusionType) {
					instance.InclusionTypes.Add(new ApplicabilityViewModel.InclusionTypeViewModel {
						informationId = inclusionType.referenceId,
						informationType = inclusionType.informationType,
						role = inclusionType.role,
					});
				}
			}
			return instance;
		}

		public static AuthorityViewModel LoadInformationBinding(this AuthorityViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<AuthorityContact> authorityContact) {
					instance.AuthorityContacts.Add(new AuthorityViewModel.AuthorityContactViewModel {
						informationId = authorityContact.referenceId,
						informationType = authorityContact.informationType,
						role = authorityContact.role,
					});
				}
				if(informationBinding is informationBinding<RelatedOrganisation> relatedOrganisation) {
					instance.RelatedOrganisations.Add(new AuthorityViewModel.RelatedOrganisationViewModel {
						informationId = relatedOrganisation.referenceId,
						informationType = relatedOrganisation.informationType,
						role = relatedOrganisation.role,
					});
				}
				if(informationBinding is informationBinding<AuthorityHours> authorityHours) {
					instance.AuthorityHours.Add(new AuthorityViewModel.AuthorityHoursViewModel {
						informationId = authorityHours.referenceId,
						informationType = authorityHours.informationType,
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
						informationType = authorityContact.informationType,
						role = authorityContact.role,
					});
				}
			}
			return instance;
		}

		public static NauticalInformationViewModel LoadInformationBinding(this NauticalInformationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static NonStandardWorkingDayViewModel LoadInformationBinding(this NonStandardWorkingDayViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RecommendationsViewModel LoadInformationBinding(this RecommendationsViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
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

		public static ServiceHoursViewModel LoadInformationBinding(this ServiceHoursViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ExceptionalWorkday> exceptionalWorkday) {
					instance.ExceptionalWorkdays.Add(new ServiceHoursViewModel.ExceptionalWorkdayViewModel {
						informationId = exceptionalWorkday.referenceId,
						informationType = exceptionalWorkday.informationType,
						role = exceptionalWorkday.role,
					});
				}
				if(informationBinding is informationBinding<AuthorityHours> authorityHours) {
					instance.AuthorityHours.Add(new ServiceHoursViewModel.AuthorityHoursViewModel {
						informationId = authorityHours.referenceId,
						informationType = authorityHours.informationType,
						role = authorityHours.role,
					});
				}
			}
			return instance;
		}

		public static SpatialQualityViewModel LoadInformationBinding(this SpatialQualityViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static InformationAreaViewModel LoadInformationBinding(this InformationAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static MarineProtectedAreaViewModel LoadInformationBinding(this MarineProtectedAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ProtectedAreaAuthority> protectedAreaAuthority) {
					instance.ProtectedAreaAuthorities.Add(new MarineProtectedAreaViewModel.ProtectedAreaAuthorityViewModel {
						informationId = protectedAreaAuthority.referenceId,
						informationType = protectedAreaAuthority.informationType,
						role = protectedAreaAuthority.role,
					});
				}
			}
			return instance;
		}

		public static RestrictedAreaViewModel LoadInformationBinding(this RestrictedAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static VesselTrafficServiceAreaViewModel LoadInformationBinding(this VesselTrafficServiceAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceControl> serviceControl) {
					instance.ServiceControls.Add(new VesselTrafficServiceAreaViewModel.ServiceControlViewModel {
						informationId = serviceControl.referenceId,
						informationType = serviceControl.informationType,
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

		public static QualityOfNonBathymetricDataViewModel LoadInformationBinding(this QualityOfNonBathymetricDataViewModel instance, informationBinding[] bindings) {
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
		public static InformationAreaViewModel LoadFeatureBinding(this InformationAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static MarineProtectedAreaViewModel LoadFeatureBinding(this MarineProtectedAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static RestrictedAreaViewModel LoadFeatureBinding(this RestrictedAreaViewModel instance, featureBinding[] bindings) {
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

		public static QualityOfNonBathymetricDataViewModel LoadFeatureBinding(this QualityOfNonBathymetricDataViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static TextPlacementViewModel LoadFeatureBinding(this TextPlacementViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<TextAssociation> textAssociation) {
					instance.TextAssociations.Add(new TextPlacementViewModel.TextAssociationViewModel {
						featureId = textAssociation.referenceId,
						featureType = textAssociation.featureType,
						role = textAssociation.role,
					});
				}
			}
			return instance;
		}

	}

}
