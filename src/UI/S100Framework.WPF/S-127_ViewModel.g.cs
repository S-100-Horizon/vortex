using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ComponentModel;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S127;
using S100Framework.DomainModel.S127.ComplexAttributes;
using S100Framework.DomainModel.S127.InformationTypes;
using S100Framework.DomainModel.S127.FeatureTypes;
using S100Framework.DomainModel.S127.InformationAssociations;
using S100Framework.DomainModel.S127.FeatureAssociations;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using System.Text.Json;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.WPF.ViewModel.S127 {
	internal static class Bootstrap {
		public static AssociationViewModel CreateInformationAssociation(string type, string? name = default) => type switch {
			"AdditionalInformation" => new AdditionalInformationViewModel { Name = name },
			"AuthorityContact" => new AuthorityContactViewModel { Name = name },
			"AuthorityHours" => new AuthorityHoursViewModel { Name = name },
			"AssociatedRxN" => new AssociatedRxNViewModel { Name = name },
			"ExceptionalWorkday" => new ExceptionalWorkdayViewModel { Name = name },
			"InclusionType" => new InclusionTypeViewModel { Name = name },
			"PermissionType" => new PermissionTypeViewModel { Name = name },
			"RelatedOrganisation" => new RelatedOrganisationViewModel { Name = name },
			"ReportingAuthority" => new ReportingAuthorityViewModel { Name = name },
			"ReportingRequirement" => new ReportingRequirementViewModel { Name = name },
			"ServiceContact" => new ServiceContactViewModel { Name = name },
			"ServiceControl" => new ServiceControlViewModel { Name = name },
			"SpatialAssociation" => new SpatialAssociationViewModel { Name = name },
			"LocationHours" => new LocationHoursViewModel { Name = name },
			"TrafficServiceReport" => new TrafficServiceReportViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static AssociationViewModel CreateFeatureAssociation(string type, string? name = default) => type switch {
			"ServiceProvisionArea" => new ServiceProvisionAreaViewModel { Name = name },
			"PilotageDistrictAssociation" => new PilotageDistrictAssociationViewModel { Name = name },
			"TextAssociation" => new TextAssociationViewModel { Name = name },
			"TrafficControlServiceAggregation" => new TrafficControlServiceAggregationViewModel { Name = name },
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
			"ShipReport" => new ShipReportViewModel { Name = name },
			"SpatialQuality" => new SpatialQualityViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static FeatureViewModel CreateFeatureType(string type, string? name = default) => type switch {
			"CautionArea" => new CautionAreaViewModel { Name = name },
			"ConcentrationOfShippingHazardArea" => new ConcentrationOfShippingHazardAreaViewModel { Name = name },
			"ISPSCodeSecurityLevel" => new ISPSCodeSecurityLevelViewModel { Name = name },
			"LocalPortBroadcastServiceArea" => new LocalPortBroadcastServiceAreaViewModel { Name = name },
			"MilitaryPracticeArea" => new MilitaryPracticeAreaViewModel { Name = name },
			"PilotBoardingPlace" => new PilotBoardingPlaceViewModel { Name = name },
			"PilotService" => new PilotServiceViewModel { Name = name },
			"PilotageDistrict" => new PilotageDistrictViewModel { Name = name },
			"PiracyRiskArea" => new PiracyRiskAreaViewModel { Name = name },
			"PlaceOfRefuge" => new PlaceOfRefugeViewModel { Name = name },
			"RadarRange" => new RadarRangeViewModel { Name = name },
			"RadioCallingInPoint" => new RadioCallingInPointViewModel { Name = name },
			"RestrictedArea" => new RestrictedAreaViewModel { Name = name },
			"RouteingMeasure" => new RouteingMeasureViewModel { Name = name },
			"ShipReportingServiceArea" => new ShipReportingServiceAreaViewModel { Name = name },
			"SignalStationWarning" => new SignalStationWarningViewModel { Name = name },
			"SignalStationTraffic" => new SignalStationTrafficViewModel { Name = name },
			"UnderKeelClearanceAllowanceArea" => new UnderKeelClearanceAllowanceAreaViewModel { Name = name },
			"UnderKeelClearanceManagementArea" => new UnderKeelClearanceManagementAreaViewModel { Name = name },
			"VesselTrafficServiceArea" => new VesselTrafficServiceAreaViewModel { Name = name },
			"WaterwayArea" => new WaterwayAreaViewModel { Name = name },
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
			("ReportingRequirement", "mustBeFiledBy") => ["Applicability"],
			("ReportingAuthority", "reportTo") => ["Authority"],
			("PermissionType", "permission") => ["Applicability"],
			("AssociatedRxN", "theRxN") => ["AbstractRxN"],
			("AdditionalInformation", "theInformation") => ["NauticalInformation"],
			("ServiceContact", "theContactDetails") => ["ContactDetails"],
			("ServiceControl", "controlAuthority") => ["Authority"],
			("TrafficServiceReport", "reptForTrafficServ") => ["ShipReport"],
			("LocationHours", "theServiceHours") => ["ServiceHours"],
			_ => throw new InvalidOperationException(),
		};

		public static ICollection<string> FeatureAssociationBindings(string association, string role) => (association, role) switch {
			("TextAssociation", "theCartographicText") => ["TextPlacement"],
			("TrafficControlServiceAggregation", "consistsOf") => ["RadioCallingInPoint","RadarRange","SignalStationWarning","SignalStationTraffic"],
			("PilotageDistrictAssociation", "theCollection") => ["PilotageDistrict"],
			("ServiceProvisionArea", "serviceProvider") => ["PilotService"],
			("ServiceProvisionArea", "serviceArea") => ["PilotageDistrict","PilotBoardingPlace"],
			("PilotageDistrictAssociation", "theComponent") => ["PilotBoardingPlace"],
			("TrafficControlServiceAggregation", "componentOf") => ["VesselTrafficServiceArea","LocalPortBroadcastServiceArea","ShipReportingServiceArea"],
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
		//[Editor(typeof(Editors.HorizonEditor<bearingInformation>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
		[Optional]
		public cardinalDirection? cardinalDirection {
			get {
				return _cardinalDirection;
			}
			set {
				SetValue(ref _cardinalDirection, value);
			}
		}

		private double? _distance  = default;

		[Description("A numeric measure of the spatial separation between two locations.")]
		//[Editor(typeof(Editors.HorizonEditor<bearingInformation>), typeof(Editors.HorizonEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<contactAddress>), typeof(Editors.HorizonEditor))]
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
	[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
	[CategoryOrder("featureName",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class featureNameViewModel : ComplexViewModel<featureName> {
		private String _language  = string.Empty;

		[Description("The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.")]
		//[Editor(typeof(Editors.HorizonEditor<featureName>), typeof(Editors.HorizonEditor))]
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
		[PermittedValues([1,2,3])]
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
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<frequencyPair>), typeof(Editors.HorizonEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<frequencyPair>), typeof(Editors.HorizonEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<graphic>), typeof(Editors.HorizonEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<graphic>), typeof(Editors.HorizonEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<graphic>), typeof(Editors.HorizonEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<horizontalPositionUncertainty>), typeof(Editors.HorizonEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<horizontalPositionUncertainty>), typeof(Editors.HorizonEditor))]
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

		[Description("Words set at the head of a passage or page to introduce or categorize.")]
		[Optional]
		public ObservableCollection<String> headline  { get; set; } = new ();

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

		private String? _text  = default;

		[Description("A non-formatted digital text string.")]
		//[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
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
	/// Span of time, prior to the time the service is needed, for preparations to be made to fulfill the requirement.
	/// </summary>
	[Description("Span of time, prior to the time the service is needed, for preparations to be made to fulfill the requirement.")]
	[CategoryOrder("noticeTime",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class noticeTimeViewModel : ComplexViewModel<noticeTime> {
		[Description("The time duration prior to the time the service is needed, when notice must be provided to the service provider.")]
		[Optional]
		public ObservableCollection<double> noticeTimeHours  { get; set; } = new ();

		private String? _noticeTimeText  = default;

		[Description("Text string qualifying the notice time hours. This may explain the time specification of the hours (for example, 3 working days for a value of 72 for the notice time hours intended to indicate a time period of 3 days) or consist of other language qualifying the time; for example, On departure from last port or On passing reporting line XY).")]
		//[Editor(typeof(Editors.HorizonEditor<noticeTime>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? noticeTimeText {
			get {
				return _noticeTimeText;
			}
			set {
				SetValue(ref _noticeTimeText, value);
			}
		}

		private operation? _operation  = default;

		[Description("Indicates whether the minimum or maximum value should be used to describe a condition or in application processing.")]
		//[Editor(typeof(Editors.HorizonEditor<noticeTime>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2])]
		[Optional]
		public operation? operation {
			get {
				return _operation;
			}
			set {
				SetValue(ref _operation, value);
			}
		}

		public noticeTimeViewModel Load(noticeTime instance) {
			noticeTimeHours.Clear();
			if (instance.noticeTimeHours is not null) {
				foreach(var e in instance.noticeTimeHours)
					noticeTimeHours.Add(e);
			}
			noticeTimeText = instance.noticeTimeText;
			operation = instance.operation;
			return this;
		}

		public override string Serialize() {
			var instance = new noticeTime {
				noticeTimeHours = this.noticeTimeHours.ToList(),
				noticeTimeText = this.noticeTimeText,
				operation = this.operation,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public noticeTime Model => new () {
			noticeTimeHours = this.noticeTimeHours.ToList(),
			noticeTimeText = this._noticeTimeText,
			operation = this._operation,
		};

		public override string? ToString() => $"Notice Time";

		public noticeTimeViewModel() : base() {
			noticeTimeHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(noticeTimeHours));
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

		[Description("Location (address) for on-line access using a URL/URI address or similar addressing scheme.")]
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

		private String? _onlineResourceDescription  = default;

		[Description("Detailed text description of what the online resource is/does.")]
		//[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? onlineResourceDescription {
			get {
				return _onlineResourceDescription;
			}
			set {
				SetValue(ref _onlineResourceDescription, value);
			}
		}

		private onlineFunction? _onlineFunction  = default;

		[Description("Code for function performed by the online resource.")]
		//[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,3,4,5,6,7,8,9,10,11])]
		[Optional]
		public onlineFunction? onlineFunction {
			get {
				return _onlineFunction;
			}
			set {
				SetValue(ref _onlineFunction, value);
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
			linkage = instance.linkage;
			protocol = instance.protocol;
			applicationProfile = instance.applicationProfile;
			nameOfResource = instance.nameOfResource;
			onlineResourceDescription = instance.onlineResourceDescription;
			onlineFunction = instance.onlineFunction;
			protocolRequest = instance.protocolRequest;
			return this;
		}

		public override string Serialize() {
			var instance = new onlineResource {
				linkage = this.linkage,
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
		public onlineResource Model => new () {
			linkage = this._linkage,
			protocol = this._protocol,
			applicationProfile = this._applicationProfile,
			nameOfResource = this._nameOfResource,
			onlineResourceDescription = this._onlineResourceDescription,
			onlineFunction = this._onlineFunction,
			protocolRequest = this._protocolRequest,
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
		//[Editor(typeof(Editors.HorizonEditor<orientation>), typeof(Editors.HorizonEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<orientation>), typeof(Editors.HorizonEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<rxNCode>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
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

		[Description("The action or activity of a vessel.")]
		//[Editor(typeof(Editors.HorizonEditor<rxNCode>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22])]
		[Optional]
		public actionOrActivity? actionOrActivity {
			get {
				return _actionOrActivity;
			}
			set {
				SetValue(ref _actionOrActivity, value);
			}
		}

		[Description("Words set at the head of a passage or page to introduce or categorize.")]
		[Optional]
		public ObservableCollection<String> headline  { get; set; } = new ();

		public rxNCodeViewModel Load(rxNCode instance) {
			categoryOfRxN = instance.categoryOfRxN;
			actionOrActivity = instance.actionOrActivity;
			headline.Clear();
			if (instance.headline is not null) {
				foreach(var e in instance.headline)
					headline.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new rxNCode {
				categoryOfRxN = this.categoryOfRxN,
				actionOrActivity = this.actionOrActivity,
				headline = this.headline.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public rxNCode Model => new () {
			categoryOfRxN = this._categoryOfRxN,
			actionOrActivity = this._actionOrActivity,
			headline = this.headline.ToList(),
		};

		public override string? ToString() => $"RxN Code";

		public rxNCodeViewModel() : base() {
			headline.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(headline));
			};
		}
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
		//[Editor(typeof(Editors.HorizonEditor<scheduleByDayOfWeek>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public categoryOfSchedule? categoryOfSchedule {
			get {
				return _categoryOfSchedule;
			}
			set {
				SetValue(ref _categoryOfSchedule, value);
			}
		}

		private String? _text  = default;

		[Description("A non-formatted digital text string.")]
		//[Editor(typeof(Editors.HorizonEditor<scheduleByDayOfWeek>), typeof(Editors.HorizonEditor))]
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
		[PermittedValues([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
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
		[PermittedValues([1,2,7,8,9,10,11,12,13,14])]
		[Optional]
		public sourceType? sourceType {
			get {
				return _sourceType;
			}
			set {
				SetValue(ref _sourceType, value);
			}
		}

		private String? _reportedDate  = default;

		[Description("The date that the item was observed, done, or investigated.")]
		[S100TruncatedDateAttribute]
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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
		//[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
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

		public spatialAccuracyViewModel Load(spatialAccuracy instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			horizontalPositionUncertainty = new ();
			if (instance.horizontalPositionUncertainty != default) {
				horizontalPositionUncertainty.Load(instance.horizontalPositionUncertainty);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new spatialAccuracy {
				fixedDateRange = this.fixedDateRange?.Model,
				horizontalPositionUncertainty = this.horizontalPositionUncertainty?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public spatialAccuracy Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			horizontalPositionUncertainty = this._horizontalPositionUncertainty?.Model,
		};

		public override string? ToString() => $"Spatial Accuracy";
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
		//[Editor(typeof(Editors.HorizonEditor<telecommunications>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Optional]
		public categoryOfCommunicationPreference? categoryOfCommunicationPreference {
			get {
				return _categoryOfCommunicationPreference;
			}
			set {
				SetValue(ref _categoryOfCommunicationPreference, value);
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

		private String? _telecommunicationCarrier  = default;

		[Description("The name of a provider or type of carrier for a telecommunication service. This service may include land line based, shore based or satellite based radio connections.")]
		//[Editor(typeof(Editors.HorizonEditor<telecommunications>), typeof(Editors.HorizonEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<telecommunications>), typeof(Editors.HorizonEditor))]
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
		[PermittedValues([1,2,3,4,5,6,7,8])]
		[Optional]
		public ObservableCollection<telecommunicationService> telecommunicationService  { get; set; } = new ();

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
		//[Editor(typeof(Editors.HorizonEditor<textContent>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public categoryOfText? categoryOfText {
			get {
				return _categoryOfText;
			}
			set {
				SetValue(ref _categoryOfText, value);
			}
		}

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
		[PermittedValues([1,2,3,4,5,6,7])]
		[Multiplicity(0, 7)]
		public ObservableCollection<dayOfWeek> dayOfWeek  { get; set; } = new ();

		private Boolean? _dayOfWeekIsRange  = default;

		[Description("A statement expressing if the days of the week identified define a range or not.")]
		//[Editor(typeof(Editors.HorizonEditor<timeIntervalsByDayOfWeek>), typeof(Editors.HorizonEditor))]
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
	/// 	A fixed figure, or a figure derived by calculation, which is added to draught in order to maintain the minimum under keel clearance taking into account the vessel's static and dynamic characteristics, sea state and weather forecast, the reliability of the chart and variance from predicted height of tide or water level.
	/// </summary>
	[Description("	A fixed figure, or a figure derived by calculation, which is added to draught in order to maintain the minimum under keel clearance taking into account the vessel's static and dynamic characteristics, sea state and weather forecast, the reliability of the chart and variance from predicted height of tide or water level.")]
	[CategoryOrder("underKeelAllowance",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class underKeelAllowanceViewModel : ComplexViewModel<underKeelAllowance> {
		private double? _underKeelAllowanceFixed  = default;

		[Description("A fixed allowance given by an authority, which is added to draught in order to maintain a minimum under keel clearance.")]
		//[Editor(typeof(Editors.HorizonEditor<underKeelAllowance>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? underKeelAllowanceFixed {
			get {
				return _underKeelAllowanceFixed;
			}
			set {
				SetValue(ref _underKeelAllowanceFixed, value);
			}
		}

		private double? _underKeelAllowanceVariableBeamBased  = default;

		[Description("A percentage value, given by an authority, which is applied to ship's beam in order to calculate under keel allowance.")]
		//[Editor(typeof(Editors.HorizonEditor<underKeelAllowance>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? underKeelAllowanceVariableBeamBased {
			get {
				return _underKeelAllowanceVariableBeamBased;
			}
			set {
				SetValue(ref _underKeelAllowanceVariableBeamBased, value);
			}
		}

		private double? _underKeelAllowanceVariableDraughtBased  = default;

		[Description("A percentage value, given by an authority, which is applied to ship's draught in order to calculate under keel allowance.")]
		//[Editor(typeof(Editors.HorizonEditor<underKeelAllowance>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? underKeelAllowanceVariableDraughtBased {
			get {
				return _underKeelAllowanceVariableDraughtBased;
			}
			set {
				SetValue(ref _underKeelAllowanceVariableDraughtBased, value);
			}
		}

		private operation? _operation  = default;

		[Description("Indicates whether the minimum or maximum value should be used to describe a condition or in application processing.")]
		//[Editor(typeof(Editors.HorizonEditor<underKeelAllowance>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2])]
		[Optional]
		public operation? operation {
			get {
				return _operation;
			}
			set {
				SetValue(ref _operation, value);
			}
		}

		public underKeelAllowanceViewModel Load(underKeelAllowance instance) {
			underKeelAllowanceFixed = instance.underKeelAllowanceFixed;
			underKeelAllowanceVariableBeamBased = instance.underKeelAllowanceVariableBeamBased;
			underKeelAllowanceVariableDraughtBased = instance.underKeelAllowanceVariableDraughtBased;
			operation = instance.operation;
			return this;
		}

		public override string Serialize() {
			var instance = new underKeelAllowance {
				underKeelAllowanceFixed = this.underKeelAllowanceFixed,
				underKeelAllowanceVariableBeamBased = this.underKeelAllowanceVariableBeamBased,
				underKeelAllowanceVariableDraughtBased = this.underKeelAllowanceVariableDraughtBased,
				operation = this.operation,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public underKeelAllowance Model => new () {
			underKeelAllowanceFixed = this._underKeelAllowanceFixed,
			underKeelAllowanceVariableBeamBased = this._underKeelAllowanceVariableBeamBased,
			underKeelAllowanceVariableDraughtBased = this._underKeelAllowanceVariableDraughtBased,
			operation = this._operation,
		};

		public override string? ToString() => $"Under Keel Allowance";
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
		//[Editor(typeof(Editors.HorizonEditor<vesselMeasurementsSpecification>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6])]
		[Mandatory]
		public comparisonOperator comparisonOperator {
			get {
				return _comparisonOperator;
			}
			set {
				SetValue(ref _comparisonOperator, value);
			}
		}

		private vesselsCharacteristics _vesselsCharacteristics  = default;

		[Description("Characteristics of vessels.")]
		//[Editor(typeof(Editors.HorizonEditor<vesselMeasurementsSpecification>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,6,7,8,9,10,11,12,13])]
		[Mandatory]
		public vesselsCharacteristics vesselsCharacteristics {
			get {
				return _vesselsCharacteristics;
			}
			set {
				SetValue(ref _vesselsCharacteristics, value);
			}
		}

		private double _vesselsCharacteristicsValue  = default;

		[Description("The value of a particular characteristic such as a dimension or tonnage of a vessel.")]
		//[Editor(typeof(Editors.HorizonEditor<vesselMeasurementsSpecification>), typeof(Editors.HorizonEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<vesselMeasurementsSpecification>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,3,4,5,6,7,9])]
		[Mandatory]
		public vesselsCharacteristicsUnit vesselsCharacteristicsUnit {
			get {
				return _vesselsCharacteristicsUnit;
			}
			set {
				SetValue(ref _vesselsCharacteristicsUnit, value);
			}
		}

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
		//[Editor(typeof(Editors.HorizonEditor<InclusionType>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2])]
		[Mandatory]
		public membership membership {
			get {
				return _membership;
			}
			set {
				SetValue(ref _membership, value);
			}
		}


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
		//[Editor(typeof(Editors.HorizonEditor<PermissionType>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7])]
		[Mandatory]
		public categoryOfRelationship categoryOfRelationship {
			get {
				return _categoryOfRelationship;
			}
			set {
				SetValue(ref _categoryOfRelationship, value);
			}
		}


		public override string Serialize() {
			var instance = new PermissionType {
				categoryOfRelationship = this.categoryOfRelationship,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Permission Type";
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
	/// The authority with which a report must be filed
	/// </summary>
	[Description("The authority with which a report must be filed")]
	[CategoryOrder("ReportingAuthority",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ReportingAuthorityViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new ReportingAuthority {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Reporting Authority";
	}



	/// <summary>
	/// Association between types of reports and classes of vessels which must file report of the type described
	/// </summary>
	[Description("Association between types of reports and classes of vessels which must file report of the type described")]
	[CategoryOrder("ReportingRequirement",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ReportingRequirementViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new ReportingRequirement {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Reporting Requirement";
	}



	/// <summary>
	/// Contact details for a service or facility
	/// </summary>
	[Description("Contact details for a service or facility")]
	[CategoryOrder("ServiceContact",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceContactViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new ServiceContact {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Service Contact";
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
	/// Working hours for a service or facility described by a geographic location
	/// </summary>
	[Description("Working hours for a service or facility described by a geographic location")]
	[CategoryOrder("LocationHours",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LocationHoursViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new LocationHours {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Location Hours";
	}



	/// <summary>
	/// Association between traffic control service and reports required of vessels pertaining to that area
	/// </summary>
	[Description("Association between traffic control service and reports required of vessels pertaining to that area")]
	[CategoryOrder("TrafficServiceReport",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TrafficServiceReportViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new TrafficServiceReport {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Traffic Service Report";
	}



	/// <summary>
	/// Association linking the location from which a service is provided and the area(s) served.
	/// </summary>
	[Description("Association linking the location from which a service is provided and the area(s) served.")]
	[CategoryOrder("ServiceProvisionArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceProvisionAreaViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new ServiceProvisionArea {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Service provision area";
	}



	/// <summary>
	/// A feature association for the binding between a pilotage district and its component pilot boarding places.
	/// </summary>
	[Description("A feature association for the binding between a pilotage district and its component pilot boarding places.")]
	[CategoryOrder("PilotageDistrictAssociation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PilotageDistrictAssociationViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new PilotageDistrictAssociation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Pilotage District Association";
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
	/// A feature association for the binding between a traffic control service and auxiliary features.
	/// </summary>
	[Description("A feature association for the binding between a traffic control service and auxiliary features.")]
	[CategoryOrder("TrafficControlServiceAggregation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TrafficControlServiceAggregationViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new TrafficControlServiceAggregation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Traffic Control Service Aggregation";
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
		//[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
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
		[PermittedValues([1,2,3,4,5,6,7,8,10,11,12,13,14,15])]
		[Optional]
		public ObservableCollection<categoryOfCargo> categoryOfCargo  { get; set; } = new ();

		[Description("Classification of dangerous goods or hazardous materials based on the International Maritime Dangerous Goods Code (IMDG Code).")]
		[Category("Applicability")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21])]
		[Optional]
		public ObservableCollection<categoryOfDangerousOrHazardousCargo> categoryOfDangerousOrHazardousCargo  { get; set; } = new ();

		private categoryOfVessel? _categoryOfVessel  = default;

		[Description("Classification of vessels by function or use.")]
		[Category("Applicability")]
		//[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17])]
		[Optional]
		public categoryOfVessel? categoryOfVessel {
			get {
				return _categoryOfVessel;
			}
			set {
				SetValue(ref _categoryOfVessel, value);
			}
		}

		private categoryOfVesselRegistry? _categoryOfVesselRegistry  = default;

		[Description("The locality of vessel registration or enrolment relative to the nationality of a port, territorial sea, administrative area, exclusive zone or other location.")]
		[Category("Applicability")]
		//[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2])]
		[Optional]
		public categoryOfVesselRegistry? categoryOfVesselRegistry {
			get {
				return _categoryOfVesselRegistry;
			}
			set {
				SetValue(ref _categoryOfVesselRegistry, value);
			}
		}

		private logicalConnectives? _logicalConnectives  = default;

		[Description("Expresses whether all the constraints described by its co-attributes must be satisfied, or only one such constraint need be satisfied.")]
		[Category("Applicability")]
		//[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2])]
		[Optional]
		public logicalConnectives? logicalConnectives {
			get {
				return _logicalConnectives;
			}
			set {
				SetValue(ref _logicalConnectives, value);
			}
		}

		private int? _thicknessOfIceCapability  = default;

		[Description("The thickness of ice that the ship can safely transit.")]
		[Category("Applicability")]
		//[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<Applicability>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationBindings")]
		[InformationBinding("InclusionType","theApplicableRxN",["AbstractRxN"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> InclusionTypes { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. InclusionTypes.Select(e => new informationBinding<DomainModel.S127.InformationAssociations.InclusionType> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
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
		//[Editor(typeof(Editors.HorizonEditor<Authority>), typeof(Editors.HorizonEditor))]
		[PermittedValues([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
		[Mandatory]
		public categoryOfAuthority categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

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

		[Category("InformationBindings")]
		[InformationBinding("AuthorityContact","theContactDetails",["ContactDetails"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> AuthorityContacts { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("RelatedOrganisation","organisationRelatedRxN",["AbstractRxN"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> RelatedOrganisations { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("AuthorityHours","theServiceHours",["ServiceHours"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> AuthorityHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. AuthorityContacts.Select(e => new informationBinding<DomainModel.S127.InformationAssociations.AuthorityContact> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. RelatedOrganisations.Select(e => new informationBinding<DomainModel.S127.InformationAssociations.RelatedOrganisation> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. AuthorityHours.Select(e => new informationBinding<DomainModel.S127.InformationAssociations.AuthorityHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
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
		//[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Optional]
		public categoryOfCommunicationPreference? categoryOfCommunicationPreference {
			get {
				return _categoryOfCommunicationPreference;
			}
			set {
				SetValue(ref _categoryOfCommunicationPreference, value);
			}
		}

		[Description("A channel number assigned to a specific radio frequency, frequencies or frequency band.")]
		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();

		private String? _contactInstructions  = default;

		[Description("Instructions provided on how to contact a particular person, organisation or service.")]
		[Category("ContactDetails")]
		//[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
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

		[Description("The Maritime Mobile Service Identity (MMSI) Code is formed of a series of nine digits which are transmitted over the radio path in order to uniquely identify ship stations, ship earth stations, coast stations, coast earth stations, and group calls. These identities are formed in such a way that the identity or part thereof can be used by telephone and telex subscribers connected to the general telecommunications network principally to call ships automatically.")]
		[Category("ContactDetails")]
		//[Editor(typeof(Editors.HorizonEditor<ContactDetails>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationBindings")]
		[InformationBinding("AuthorityContact","theAuthority",["Authority"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> AuthorityContacts { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. AuthorityContacts.Select(e => new informationBinding<DomainModel.S127.InformationAssociations.AuthorityContact> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
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
		//[Editor(typeof(Editors.HorizonEditor<AbstractRxN>), typeof(Editors.HorizonEditor))]
		[PermittedValues([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();



		public override informationBinding[] GetInformationBindings() => [];

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


		public override informationBinding[] GetInformationBindings() => [];

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
		//[Editor(typeof(Editors.HorizonEditor<AbstractRxN>), typeof(Editors.HorizonEditor))]
		[PermittedValues([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();



		public override informationBinding[] GetInformationBindings() => [];

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
		//[Editor(typeof(Editors.HorizonEditor<AbstractRxN>), typeof(Editors.HorizonEditor))]
		[PermittedValues([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();



		public override informationBinding[] GetInformationBindings() => [];

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
		//[Editor(typeof(Editors.HorizonEditor<AbstractRxN>), typeof(Editors.HorizonEditor))]
		[PermittedValues([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
		[Optional]
		public categoryOfAuthority? categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();



		public override informationBinding[] GetInformationBindings() => [];

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

		[Category("InformationBindings")]
		[InformationBinding("ExceptionalWorkday","partialWorkingDay",["NonStandardWorkingDay"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ExceptionalWorkdays { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("AuthorityHours","theAuthority_srvHrs",["Authority"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> AuthorityHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ExceptionalWorkdays.Select(e => new informationBinding<DomainModel.S127.InformationAssociations.ExceptionalWorkday> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. AuthorityHours.Select(e => new informationBinding<DomainModel.S127.InformationAssociations.AuthorityHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
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
		}
	}



	/// <summary>
	/// Description of how a ship should report to a maritime authority, including when to report, what to report and whether the format conforms to the IMO standard.
	/// </summary>
	[Description("Description of how a ship should report to a maritime authority, including when to report, what to report and whether the format conforms to the IMO standard.")]
	[CategoryOrder("ShipReport",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ShipReportViewModel : InformationViewModel<ShipReport> {
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

		[Description("Classification of ship reports based on IMO standard report formats.")]
		[Category("ShipReport")]
		[PermittedValues([1,2,3,4,5,6,7,8])]
		[Multiplicity(1)]
		public ObservableCollection<categoryOfShipReport> categoryOfShipReport  { get; set; } = new ();

		private Boolean _iMOFormatForReporting  = false;

		[Description("Whether a report must be in an IMO standard format.")]
		[Category("ShipReport")]
		//[Editor(typeof(Editors.HorizonEditor<ShipReport>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public Boolean iMOFormatForReporting {
			get {
				return _iMOFormatForReporting;
			}
			set {
				SetValue(ref _iMOFormatForReporting, value);
			}
		}

		[Description("The standard ship reporting formats according to IMO Resolution A.531(13) General Principles for Ship Reporting System or IMO A.851(20).")]
		[Category("ShipReport")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26])]
		[Optional]
		public ObservableCollection<sRSFormatCode> sRSFormatCode  { get; set; } = new ();

		[Description("Span of time, prior to the time the service is needed, for preparations to be made to fulfill the requirement.")]
		[Category("ShipReport")]
		[Multiplicity(1)]
		public ObservableCollection<noticeTimeViewModel> noticeTime  { get; set; } = new ();

		private textContentViewModel? _textContent  = default;

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("ShipReport")]
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

		[Category("InformationBindings")]
		[InformationBinding("ReportingRequirement","mustBeFiledBy",["Applicability"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ReportingRequirements { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("ReportingAuthority","reportTo",["Authority"], lower:0, upper:2147483647)]
		public ObservableCollection<InformationRefViewModel> ReportingAuthorities { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ReportingRequirements.Select(e => new informationBinding<DomainModel.S127.InformationAssociations.ReportingRequirement> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. ReportingAuthorities.Select(e => new informationBinding<DomainModel.S127.InformationAssociations.ReportingAuthority> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion

		public ShipReportViewModel Load(ShipReport instance) {
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
			categoryOfShipReport.Clear();
			if (instance.categoryOfShipReport is not null) {
				foreach(var e in instance.categoryOfShipReport)
					categoryOfShipReport.Add(e);
			}
			iMOFormatForReporting = instance.iMOFormatForReporting;
			sRSFormatCode.Clear();
			if (instance.sRSFormatCode is not null) {
				foreach(var e in instance.sRSFormatCode)
					sRSFormatCode.Add(e);
			}
			noticeTime.Clear();
			if (instance.noticeTime is not null) {
				foreach(var e in instance.noticeTime)
					noticeTime.Add(new noticeTimeViewModel().Load(e));
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new ShipReport {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				categoryOfShipReport = this.categoryOfShipReport.ToList(),
				iMOFormatForReporting = this.iMOFormatForReporting,
				sRSFormatCode = this.sRSFormatCode.ToList(),
				noticeTime = this.noticeTime.Select(e => e.Model).ToList(),
				textContent = this.textContent?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ShipReport Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			categoryOfShipReport = this.categoryOfShipReport.ToList(),
			iMOFormatForReporting = this._iMOFormatForReporting,
			sRSFormatCode = this.sRSFormatCode.ToList(),
			noticeTime = this.noticeTime.Select(e => e.Model).ToList(),
			textContent = this._textContent?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.ShipReport.informationBindingDefinitions;

		public ShipReportViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Ship Report";

		public ShipReportViewModel() : base() {
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
			categoryOfShipReport.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfShipReport));
			};
			sRSFormatCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sRSFormatCode));
			};
			noticeTime.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(noticeTime));
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
		//[Editor(typeof(Editors.HorizonEditor<SpatialQuality>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11])]
		[Optional]
		public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {
			get {
				return _qualityOfHorizontalMeasurement;
			}
			set {
				SetValue(ref _qualityOfHorizontalMeasurement, value);
			}
		}

		[Description("Provides an indication of the vertical and horizontal positional uncertainty of bathymetric data, optionally within a specified date range.")]
		[Category("SpatialQuality")]
		[Optional]
		public ObservableCollection<spatialAccuracyViewModel> spatialAccuracy  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];

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
	/// Generally, an area where the mariner has to be made aware of circumstances influencing the safety of navigation.
	/// </summary>
	[Description("Generally, an area where the mariner has to be made aware of circumstances influencing the safety of navigation.")]
	[CategoryOrder("CautionArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CautionAreaViewModel : FeatureViewModel<CautionArea> {
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

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("CautionArea")]
		//[Editor(typeof(Editors.HorizonEditor<CautionArea>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,3,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private status? _status  = default;

		[Description("The condition of an object at a given instant in time.")]
		[Category("CautionArea")]
		//[Editor(typeof(Editors.HorizonEditor<CautionArea>), typeof(Editors.HorizonEditor))]
		[PermittedValues([5,7])]
		[Optional]
		public status? status {
			get {
				return _status;
			}
			set {
				SetValue(ref _status, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public CautionAreaViewModel Load(CautionArea instance) {
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
			condition = instance.condition;
			status = instance.status;
			return this;
		}

		public override string Serialize() {
			var instance = new CautionArea {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				condition = this.condition,
				status = this.status,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CautionArea Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			condition = this._condition,
			status = this._status,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.CautionArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.CautionArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.CautionArea.featureBindingDefinitions;

		public CautionAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public CautionAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Caution Area";

		public CautionAreaViewModel() : base() {
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
	/// An area where hazards, caused by concentrations of shipping, may occur. Hazards are risks to shipping, which stem from sources other than shoal water or obstructions.
	/// </summary>
	[Description("An area where hazards, caused by concentrations of shipping, may occur. Hazards are risks to shipping, which stem from sources other than shoal water or obstructions.")]
	[CategoryOrder("ConcentrationOfShippingHazardArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ConcentrationOfShippingHazardAreaViewModel : FeatureViewModel<ConcentrationOfShippingHazardArea> {
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

		[Description("Classification of shipping hazards due to traffic volume or density.")]
		[Category("ConcentrationOfShippingHazardArea")]
		[PermittedValues([1,2,3,4])]
		[Optional]
		public ObservableCollection<categoryOfConcentrationOfShippingHazardArea> categoryOfConcentrationOfShippingHazardArea  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("ConcentrationOfShippingHazardArea")]
		[PermittedValues([1,2,5,7,16,17])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public ConcentrationOfShippingHazardAreaViewModel Load(ConcentrationOfShippingHazardArea instance) {
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
			categoryOfConcentrationOfShippingHazardArea.Clear();
			if (instance.categoryOfConcentrationOfShippingHazardArea is not null) {
				foreach(var e in instance.categoryOfConcentrationOfShippingHazardArea)
					categoryOfConcentrationOfShippingHazardArea.Add(e);
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new ConcentrationOfShippingHazardArea {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				categoryOfConcentrationOfShippingHazardArea = this.categoryOfConcentrationOfShippingHazardArea.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ConcentrationOfShippingHazardArea Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfConcentrationOfShippingHazardArea = this.categoryOfConcentrationOfShippingHazardArea.ToList(),
			status = this.status.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.ConcentrationOfShippingHazardArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.ConcentrationOfShippingHazardArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.ConcentrationOfShippingHazardArea.featureBindingDefinitions;

		public ConcentrationOfShippingHazardAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public ConcentrationOfShippingHazardAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Concentration of Shipping Hazard Area";

		public ConcentrationOfShippingHazardAreaViewModel() : base() {
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
			categoryOfConcentrationOfShippingHazardArea.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfConcentrationOfShippingHazardArea));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// The area to which an International Ship and Port Facility Security (ISPS) level applies. The ISPS Code is a comprehensive set of measures to enhance the security of ships and port facilities, developed in response to the perceived threats to ships and port facilities in the wake of the 9/11 attacks in the United States.
	/// </summary>
	[Description("The area to which an International Ship and Port Facility Security (ISPS) level applies. The ISPS Code is a comprehensive set of measures to enhance the security of ships and port facilities, developed in response to the perceived threats to ships and port facilities in the wake of the 9/11 attacks in the United States.")]
	[CategoryOrder("ISPSCodeSecurityLevel",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ISPSCodeSecurityLevelViewModel : FeatureViewModel<ISPSCodeSecurityLevel> {
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


		private iSPSLevel _iSPSLevel  = default;

		[Description("Classification of ISPS security levels according to the ISPS Code.")]
		[Category("ISPSCodeSecurityLevel")]
		//[Editor(typeof(Editors.HorizonEditor<ISPSCodeSecurityLevel>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Mandatory]
		public iSPSLevel iSPSLevel {
			get {
				return _iSPSLevel;
			}
			set {
				SetValue(ref _iSPSLevel, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public ISPSCodeSecurityLevelViewModel Load(ISPSCodeSecurityLevel instance) {
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
			iSPSLevel = instance.iSPSLevel;
			return this;
		}

		public override string Serialize() {
			var instance = new ISPSCodeSecurityLevel {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				iSPSLevel = this.iSPSLevel,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ISPSCodeSecurityLevel Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			iSPSLevel = this._iSPSLevel,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.ISPSCodeSecurityLevel.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.ISPSCodeSecurityLevel.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.ISPSCodeSecurityLevel.featureBindingDefinitions;

		public ISPSCodeSecurityLevelViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public ISPSCodeSecurityLevelViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"ISPS Code Security Level";

		public ISPSCodeSecurityLevelViewModel() : base() {
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
	/// A broadcast service established to provide port information without interaction between the customer and the service provider. This information could be inter alia berthing information, availability of port services, shipping schedules, meteorological and hydrological data.
	/// </summary>
	[Description("A broadcast service established to provide port information without interaction between the customer and the service provider. This information could be inter alia berthing information, availability of port services, shipping schedules, meteorological and hydrological data.")]
	[CategoryOrder("LocalPortBroadcastServiceArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LocalPortBroadcastServiceAreaViewModel : FeatureViewModel<LocalPortBroadcastServiceArea> {
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




		private String? _serviceAccessProcedure  = default;

		[Description("A description of the procedure to access the marine service.")]
		[Category("LocalPortBroadcastServiceArea")]
		//[Editor(typeof(Editors.HorizonEditor<LocalPortBroadcastServiceArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? serviceAccessProcedure {
			get {
				return _serviceAccessProcedure;
			}
			set {
				SetValue(ref _serviceAccessProcedure, value);
			}
		}

		private String _requirementsForMaintenanceOfListeningWatch  = string.Empty;

		[Description("Something needed to ensure constant acoustic monitoring.")]
		[Category("LocalPortBroadcastServiceArea")]
		//[Editor(typeof(Editors.HorizonEditor<LocalPortBroadcastServiceArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String requirementsForMaintenanceOfListeningWatch {
			get {
				return _requirementsForMaintenanceOfListeningWatch;
			}
			set {
				SetValue(ref _requirementsForMaintenanceOfListeningWatch, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("TrafficControlServiceAggregation","consistsOf",["RadioCallingInPoint","RadarRange","SignalStationWarning","SignalStationTraffic"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> TrafficControlServiceAggregations { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. TrafficControlServiceAggregations.Select(e => new featureBinding<DomainModel.S127.FeatureAssociations.TrafficControlServiceAggregation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public LocalPortBroadcastServiceAreaViewModel Load(LocalPortBroadcastServiceArea instance) {
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
			serviceAccessProcedure = instance.serviceAccessProcedure;
			requirementsForMaintenanceOfListeningWatch = instance.requirementsForMaintenanceOfListeningWatch;
			return this;
		}

		public override string Serialize() {
			var instance = new LocalPortBroadcastServiceArea {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				serviceAccessProcedure = this.serviceAccessProcedure,
				requirementsForMaintenanceOfListeningWatch = this.requirementsForMaintenanceOfListeningWatch,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LocalPortBroadcastServiceArea Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			serviceAccessProcedure = this._serviceAccessProcedure,
			requirementsForMaintenanceOfListeningWatch = this._requirementsForMaintenanceOfListeningWatch,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LocalPortBroadcastServiceArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.LocalPortBroadcastServiceArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LocalPortBroadcastServiceArea.featureBindingDefinitions;

		public LocalPortBroadcastServiceAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public LocalPortBroadcastServiceAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Local Port Broadcast Service Area";

		public LocalPortBroadcastServiceAreaViewModel() : base() {
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
			TrafficControlServiceAggregations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(TrafficControlServiceAggregations));
			};
		}
	}



	/// <summary>
	/// An area within which naval, military or aerial exercises are carried out. Also called an 'exercise area'.
	/// </summary>
	[Description("An area within which naval, military or aerial exercises are carried out. Also called an 'exercise area'.")]
	[CategoryOrder("MilitaryPracticeArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class MilitaryPracticeAreaViewModel : FeatureViewModel<MilitaryPracticeArea> {
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



		[Description("Classification of area by military use.")]
		[Category("MilitaryPracticeArea")]
		[PermittedValues([2,3,4,5,6])]
		[Optional]
		public ObservableCollection<categoryOfMilitaryPracticeArea> categoryOfMilitaryPracticeArea  { get; set; } = new ();

		private String? _nationality  = default;

		[Description("Identifier of membership of a particular nation.")]
		[Category("MilitaryPracticeArea")]
		//[Editor(typeof(Editors.HorizonEditor<MilitaryPracticeArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}

		[Description("The official legal statute of each kind of restricted area.")]
		[Category("MilitaryPracticeArea")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,15,16,17,18,19,20,21,22,23,24,25,26,27,39])]
		[Optional]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("MilitaryPracticeArea")]
		[PermittedValues([1,2,5,6,7,16,17])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","theServiceHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. LocationHours.Select(e => new informationBinding<DomainModel.S127.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		public override featureBinding[] GetFeatureBindings() => [];

		public MilitaryPracticeAreaViewModel Load(MilitaryPracticeArea instance) {
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
			categoryOfMilitaryPracticeArea.Clear();
			if (instance.categoryOfMilitaryPracticeArea is not null) {
				foreach(var e in instance.categoryOfMilitaryPracticeArea)
					categoryOfMilitaryPracticeArea.Add(e);
			}
			nationality = instance.nationality;
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
			var instance = new MilitaryPracticeArea {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				categoryOfMilitaryPracticeArea = this.categoryOfMilitaryPracticeArea.ToList(),
				nationality = this.nationality,
				restriction = this.restriction.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public MilitaryPracticeArea Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfMilitaryPracticeArea = this.categoryOfMilitaryPracticeArea.ToList(),
			nationality = this._nationality,
			restriction = this.restriction.ToList(),
			status = this.status.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.MilitaryPracticeArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.MilitaryPracticeArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.MilitaryPracticeArea.featureBindingDefinitions;

		public MilitaryPracticeAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public MilitaryPracticeAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Military Practice Area";

		public MilitaryPracticeAreaViewModel() : base() {
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
			categoryOfMilitaryPracticeArea.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfMilitaryPracticeArea));
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
	/// A location offshore where a pilot may board a vessel in preparation to piloting it through local waters.
	/// </summary>
	[Description("A location offshore where a pilot may board a vessel in preparation to piloting it through local waters.")]
	[CategoryOrder("PilotBoardingPlace",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PilotBoardingPlaceViewModel : FeatureViewModel<PilotBoardingPlace> {
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


		private String? _callSign  = default;

		[Description("The designated call-sign of a station (radio station, radar station, pilot, ...).")]
		[Category("PilotBoardingPlace")]
		//[Editor(typeof(Editors.HorizonEditor<PilotBoardingPlace>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? callSign {
			get {
				return _callSign;
			}
			set {
				SetValue(ref _callSign, value);
			}
		}

		private categoryOfPilotBoardingPlace? _categoryOfPilotBoardingPlace  = default;

		[Description("Classification of pilot boarding method.")]
		[Category("PilotBoardingPlace")]
		//[Editor(typeof(Editors.HorizonEditor<PilotBoardingPlace>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public categoryOfPilotBoardingPlace? categoryOfPilotBoardingPlace {
			get {
				return _categoryOfPilotBoardingPlace;
			}
			set {
				SetValue(ref _categoryOfPilotBoardingPlace, value);
			}
		}

		private categoryOfPreference? _categoryOfPreference  = default;

		[Description("The selection of a first choice compared to other options.")]
		[Category("PilotBoardingPlace")]
		//[Editor(typeof(Editors.HorizonEditor<PilotBoardingPlace>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2])]
		[Optional]
		public categoryOfPreference? categoryOfPreference {
			get {
				return _categoryOfPreference;
			}
			set {
				SetValue(ref _categoryOfPreference, value);
			}
		}

		private categoryOfVessel? _categoryOfVessel  = default;

		[Description("Classification of vessels by function or use.")]
		[Category("PilotBoardingPlace")]
		//[Editor(typeof(Editors.HorizonEditor<PilotBoardingPlace>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17])]
		[Optional]
		public categoryOfVessel? categoryOfVessel {
			get {
				return _categoryOfVessel;
			}
			set {
				SetValue(ref _categoryOfVessel, value);
			}
		}

		[Description("A channel number assigned to a specific radio frequency, frequencies or frequency band.")]
		[Category("PilotBoardingPlace")]
		[Optional]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();

		private String? _destination  = default;

		[Description("The place or general direction to which a vessel is going or directed.")]
		[Category("PilotBoardingPlace")]
		//[Editor(typeof(Editors.HorizonEditor<PilotBoardingPlace>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? destination {
			get {
				return _destination;
			}
			set {
				SetValue(ref _destination, value);
			}
		}

		private pilotMovement? _pilotMovement  = default;

		[Description("Classification of pilot activity by arrival, departure, or change of pilot. It may also describe the place where the pilot's advice begins, ends, or is transferred to a different pilot.")]
		[Category("PilotBoardingPlace")]
		//[Editor(typeof(Editors.HorizonEditor<PilotBoardingPlace>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public pilotMovement? pilotMovement {
			get {
				return _pilotMovement;
			}
			set {
				SetValue(ref _pilotMovement, value);
			}
		}

		private String? _pilotVessel  = default;

		[Description("Description of the pilot vessel. The pilot vessel is a small vessel used by a pilot to go to or from a vessel employing the pilot's services.")]
		[Category("PilotBoardingPlace")]
		//[Editor(typeof(Editors.HorizonEditor<PilotBoardingPlace>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pilotVessel {
			get {
				return _pilotVessel;
			}
			set {
				SetValue(ref _pilotVessel, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("PilotBoardingPlace")]
		[PermittedValues([1,2,5,6,9,16,17,28])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("PilotageDistrictAssociation","theCollection",["PilotageDistrict"], lower:0, upper:1)]
		public ObservableCollection<FeatureRefViewModel> PilotageDistrictAssociations { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("ServiceProvisionArea","serviceProvider",["PilotService"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> ServiceProvisionAreas { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. PilotageDistrictAssociations.Select(e => new featureBinding<DomainModel.S127.FeatureAssociations.PilotageDistrictAssociation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. ServiceProvisionAreas.Select(e => new featureBinding<DomainModel.S127.FeatureAssociations.ServiceProvisionArea> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public PilotBoardingPlaceViewModel Load(PilotBoardingPlace instance) {
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
			callSign = instance.callSign;
			categoryOfPilotBoardingPlace = instance.categoryOfPilotBoardingPlace;
			categoryOfPreference = instance.categoryOfPreference;
			categoryOfVessel = instance.categoryOfVessel;
			communicationChannel.Clear();
			if (instance.communicationChannel is not null) {
				foreach(var e in instance.communicationChannel)
					communicationChannel.Add(e);
			}
			destination = instance.destination;
			pilotMovement = instance.pilotMovement;
			pilotVessel = instance.pilotVessel;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new PilotBoardingPlace {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				callSign = this.callSign,
				categoryOfPilotBoardingPlace = this.categoryOfPilotBoardingPlace,
				categoryOfPreference = this.categoryOfPreference,
				categoryOfVessel = this.categoryOfVessel,
				communicationChannel = this.communicationChannel.ToList(),
				destination = this.destination,
				pilotMovement = this.pilotMovement,
				pilotVessel = this.pilotVessel,
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PilotBoardingPlace Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			callSign = this._callSign,
			categoryOfPilotBoardingPlace = this._categoryOfPilotBoardingPlace,
			categoryOfPreference = this._categoryOfPreference,
			categoryOfVessel = this._categoryOfVessel,
			communicationChannel = this.communicationChannel.ToList(),
			destination = this._destination,
			pilotMovement = this._pilotMovement,
			pilotVessel = this._pilotVessel,
			status = this.status.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.PilotBoardingPlace.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.PilotBoardingPlace.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.PilotBoardingPlace.featureBindingDefinitions;

		public PilotBoardingPlaceViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public PilotBoardingPlaceViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Pilot Boarding Place";

		public PilotBoardingPlaceViewModel() : base() {
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
			communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(communicationChannel));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			PilotageDistrictAssociations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(PilotageDistrictAssociations));
			};
			ServiceProvisionAreas.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ServiceProvisionAreas));
			};
		}
	}



	/// <summary>
	/// The service provided by a person who directs the movements of a vessel through pilot waters, usually a person who has demonstrated extensive knowledge of channels, aids to navigation, dangers to navigation, etc., in a particular area and is licensed for that area.
	/// </summary>
	[Description("The service provided by a person who directs the movements of a vessel through pilot waters, usually a person who has demonstrated extensive knowledge of channels, aids to navigation, dangers to navigation, etc., in a particular area and is licensed for that area.")]
	[CategoryOrder("PilotService",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PilotServiceViewModel : FeatureViewModel<PilotService> {
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




		[Description("Classification of pilots and pilot services by type of waterway where piloting services are provided.")]
		[Category("PilotService")]
		[PermittedValues([1,2,3,4,5,6,7])]
		[Optional]
		public ObservableCollection<categoryOfPilot> categoryOfPilot  { get; set; } = new ();

		private pilotQualification? _pilotQualification  = default;

		[Description("Classification of pilots and pilot services by type of license qualification or type of organization providing services.")]
		[Category("PilotService")]
		//[Editor(typeof(Editors.HorizonEditor<PilotService>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8])]
		[Optional]
		public pilotQualification? pilotQualification {
			get {
				return _pilotQualification;
			}
			set {
				SetValue(ref _pilotQualification, value);
			}
		}

		private String? _pilotRequest  = default;

		[Description("Description of the pilot request procedure.")]
		[Category("PilotService")]
		//[Editor(typeof(Editors.HorizonEditor<PilotService>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pilotRequest {
			get {
				return _pilotRequest;
			}
			set {
				SetValue(ref _pilotRequest, value);
			}
		}

		private Boolean _remotePilot  = false;

		[Description("Indication as to whether pilotage is available remotely from shore or other location remote from the vessel requiring pilotage or not.")]
		[Category("PilotService")]
		//[Editor(typeof(Editors.HorizonEditor<PilotService>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public Boolean remotePilot {
			get {
				return _remotePilot;
			}
			set {
				SetValue(ref _remotePilot, value);
			}
		}

		private noticeTimeViewModel? _noticeTime  = default;

		[Description("Span of time, prior to the time the service is needed, for preparations to be made to fulfill the requirement.")]
		[Category("PilotService")]
		[ExpandableObject]
		[Optional]
		public noticeTimeViewModel? noticeTime {
			get {
				return _noticeTime;
			}
			set {
				SetValue(ref _noticeTime, value);
			}
		}


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","theServiceHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. LocationHours.Select(e => new informationBinding<DomainModel.S127.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("ServiceProvisionArea","serviceArea",["PilotageDistrict"], lower:0, upper:1)]
		[FeatureBinding("ServiceProvisionArea","serviceArea",["PilotBoardingPlace"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> ServiceProvisionAreas { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. ServiceProvisionAreas.Select(e => new featureBinding<DomainModel.S127.FeatureAssociations.ServiceProvisionArea> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public PilotServiceViewModel Load(PilotService instance) {
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
			categoryOfPilot.Clear();
			if (instance.categoryOfPilot is not null) {
				foreach(var e in instance.categoryOfPilot)
					categoryOfPilot.Add(e);
			}
			pilotQualification = instance.pilotQualification;
			pilotRequest = instance.pilotRequest;
			remotePilot = instance.remotePilot;
			noticeTime = new ();
			if (instance.noticeTime != default) {
				noticeTime.Load(instance.noticeTime);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new PilotService {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				categoryOfPilot = this.categoryOfPilot.ToList(),
				pilotQualification = this.pilotQualification,
				pilotRequest = this.pilotRequest,
				remotePilot = this.remotePilot,
				noticeTime = this.noticeTime?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PilotService Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfPilot = this.categoryOfPilot.ToList(),
			pilotQualification = this._pilotQualification,
			pilotRequest = this._pilotRequest,
			remotePilot = this._remotePilot,
			noticeTime = this._noticeTime?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.PilotService.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.PilotService.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.PilotService.featureBindingDefinitions;

		public PilotServiceViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public PilotServiceViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Pilot Service";

		public PilotServiceViewModel() : base() {
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
			categoryOfPilot.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfPilot));
			};
			ServiceProvisionAreas.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ServiceProvisionAreas));
			};
		}
	}



	/// <summary>
	/// An area within which a pilotage direction exists. Such directions are regulated by a competent harbour authority which dictates circumstances under which they apply.
	/// </summary>
	[Description("An area within which a pilotage direction exists. Such directions are regulated by a competent harbour authority which dictates circumstances under which they apply.")]
	[CategoryOrder("PilotageDistrict",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PilotageDistrictViewModel : FeatureViewModel<PilotageDistrict> {
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

		[Description("A channel number assigned to a specific radio frequency, frequencies or frequency band.")]
		[Category("PilotageDistrict")]
		[Optional]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("PilotageDistrictAssociation","theComponent",["PilotBoardingPlace"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> PilotageDistrictAssociations { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("ServiceProvisionArea","serviceProvider",["PilotService"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> ServiceProvisionAreas { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. PilotageDistrictAssociations.Select(e => new featureBinding<DomainModel.S127.FeatureAssociations.PilotageDistrictAssociation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. ServiceProvisionAreas.Select(e => new featureBinding<DomainModel.S127.FeatureAssociations.ServiceProvisionArea> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public PilotageDistrictViewModel Load(PilotageDistrict instance) {
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
			communicationChannel.Clear();
			if (instance.communicationChannel is not null) {
				foreach(var e in instance.communicationChannel)
					communicationChannel.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new PilotageDistrict {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				communicationChannel = this.communicationChannel.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PilotageDistrict Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			communicationChannel = this.communicationChannel.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.PilotageDistrict.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.PilotageDistrict.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.PilotageDistrict.featureBindingDefinitions;

		public PilotageDistrictViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public PilotageDistrictViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Pilotage District";

		public PilotageDistrictViewModel() : base() {
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
			communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(communicationChannel));
			};
			PilotageDistrictAssociations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(PilotageDistrictAssociations));
			};
			ServiceProvisionAreas.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ServiceProvisionAreas));
			};
		}
	}



	/// <summary>
	/// An area where there is a raised risk of piracy or armed robbery.
	/// </summary>
	[Description("An area where there is a raised risk of piracy or armed robbery.")]
	[CategoryOrder("PiracyRiskArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PiracyRiskAreaViewModel : FeatureViewModel<PiracyRiskArea> {
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




		[Description("The official legal statute of each kind of restricted area.")]
		[Category("PiracyRiskArea")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,14,18,19,20,21,24,25,26,27,31,32,33,34])]
		[Optional]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("PiracyRiskArea")]
		[PermittedValues([1,2,5,7])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public PiracyRiskAreaViewModel Load(PiracyRiskArea instance) {
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
			var instance = new PiracyRiskArea {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				restriction = this.restriction.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PiracyRiskArea Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			restriction = this.restriction.ToList(),
			status = this.status.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.PiracyRiskArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.PiracyRiskArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.PiracyRiskArea.featureBindingDefinitions;

		public PiracyRiskAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public PiracyRiskAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Piracy Risk Area";

		public PiracyRiskAreaViewModel() : base() {
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
			restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(restriction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A place where a ship in need of assistance can take action to enable it to stabilize its condition and reduce the hazards to navigation, and to protect human life and the environment.
	/// </summary>
	[Description("A place where a ship in need of assistance can take action to enable it to stabilize its condition and reduce the hazards to navigation, and to protect human life and the environment.")]
	[CategoryOrder("PlaceOfRefuge",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PlaceOfRefugeViewModel : FeatureViewModel<PlaceOfRefuge> {
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




		[Description("A channel number assigned to a specific radio frequency, frequencies or frequency band.")]
		[Category("PlaceOfRefuge")]
		[Optional]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("PlaceOfRefuge")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,28])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public PlaceOfRefugeViewModel Load(PlaceOfRefuge instance) {
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
			communicationChannel.Clear();
			if (instance.communicationChannel is not null) {
				foreach(var e in instance.communicationChannel)
					communicationChannel.Add(e);
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new PlaceOfRefuge {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				communicationChannel = this.communicationChannel.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PlaceOfRefuge Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			communicationChannel = this.communicationChannel.ToList(),
			status = this.status.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.PlaceOfRefuge.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.PlaceOfRefuge.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.PlaceOfRefuge.featureBindingDefinitions;

		public PlaceOfRefugeViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public PlaceOfRefugeViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Place of Refuge";

		public PlaceOfRefugeViewModel() : base() {
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
			communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(communicationChannel));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// Indicates the coverage of a sea area by a radar surveillance station. Inside this area a vessel may request shore-based radar assistance, particularly in poor visibility.
	/// </summary>
	[Description("Indicates the coverage of a sea area by a radar surveillance station. Inside this area a vessel may request shore-based radar assistance, particularly in poor visibility.")]
	[CategoryOrder("RadarRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadarRangeViewModel : FeatureViewModel<RadarRange> {
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

		[Description("A channel number assigned to a specific radio frequency, frequencies or frequency band.")]
		[Category("RadarRange")]
		[Optional]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("RadarRange")]
		[PermittedValues([1,2,4,7])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("TrafficControlServiceAggregation","componentOf",["VesselTrafficServiceArea","LocalPortBroadcastServiceArea","ShipReportingServiceArea"], lower:0, upper:1)]
		public ObservableCollection<FeatureRefViewModel> TrafficControlServiceAggregations { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. TrafficControlServiceAggregations.Select(e => new featureBinding<DomainModel.S127.FeatureAssociations.TrafficControlServiceAggregation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public RadarRangeViewModel Load(RadarRange instance) {
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
			communicationChannel.Clear();
			if (instance.communicationChannel is not null) {
				foreach(var e in instance.communicationChannel)
					communicationChannel.Add(e);
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new RadarRange {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				communicationChannel = this.communicationChannel.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RadarRange Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			communicationChannel = this.communicationChannel.ToList(),
			status = this.status.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.RadarRange.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.RadarRange.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.RadarRange.featureBindingDefinitions;

		public RadarRangeViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public RadarRangeViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Radar Range";

		public RadarRangeViewModel() : base() {
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
			communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(communicationChannel));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			TrafficControlServiceAggregations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(TrafficControlServiceAggregations));
			};
		}
	}



	/// <summary>
	/// A designated position at which vessels are required to report to a traffic control centre. Also called reporting point or radio reporting point.
	/// </summary>
	[Description("A designated position at which vessels are required to report to a traffic control centre. Also called reporting point or radio reporting point.")]
	[CategoryOrder("RadioCallingInPoint",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadioCallingInPointViewModel : FeatureViewModel<RadioCallingInPoint> {
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

		private String? _callSign  = default;

		[Description("The designated call-sign of a station (radio station, radar station, pilot, ...).")]
		[Category("RadioCallingInPoint")]
		//[Editor(typeof(Editors.HorizonEditor<RadioCallingInPoint>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? callSign {
			get {
				return _callSign;
			}
			set {
				SetValue(ref _callSign, value);
			}
		}

		[Description("A channel number assigned to a specific radio frequency, frequencies or frequency band.")]
		[Category("RadioCallingInPoint")]
		[Optional]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();

		[Description("Classification of the different types of cargo that a ship may be carrying.")]
		[Category("RadioCallingInPoint")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<categoryOfCargo> categoryOfCargo  { get; set; } = new ();

		[Description("Classification of vessels by function or use.")]
		[Category("RadioCallingInPoint")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17])]
		[Optional]
		public ObservableCollection<categoryOfVessel> categoryOfVessel  { get; set; } = new ();

		[Description("The angular distance measured from true north to the major axis of the feature.")]
		[Category("RadioCallingInPoint")]
		[Multiplicity(0, 2)]
		public ObservableCollection<double> orientationValue  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("RadioCallingInPoint")]
		[PermittedValues([1,3,4,5,6,7,9])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private trafficFlow _trafficFlow  = default;

		[Description("Direction of vessels passing a reference point.")]
		[Category("RadioCallingInPoint")]
		//[Editor(typeof(Editors.HorizonEditor<RadioCallingInPoint>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Mandatory]
		public trafficFlow trafficFlow {
			get {
				return _trafficFlow;
			}
			set {
				SetValue(ref _trafficFlow, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("TrafficControlServiceAggregation","componentOf",["VesselTrafficServiceArea","LocalPortBroadcastServiceArea","ShipReportingServiceArea"], lower:0, upper:1)]
		public ObservableCollection<FeatureRefViewModel> TrafficControlServiceAggregations { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. TrafficControlServiceAggregations.Select(e => new featureBinding<DomainModel.S127.FeatureAssociations.TrafficControlServiceAggregation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public RadioCallingInPointViewModel Load(RadioCallingInPoint instance) {
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
			callSign = instance.callSign;
			communicationChannel.Clear();
			if (instance.communicationChannel is not null) {
				foreach(var e in instance.communicationChannel)
					communicationChannel.Add(e);
			}
			categoryOfCargo.Clear();
			if (instance.categoryOfCargo is not null) {
				foreach(var e in instance.categoryOfCargo)
					categoryOfCargo.Add(e);
			}
			categoryOfVessel.Clear();
			if (instance.categoryOfVessel is not null) {
				foreach(var e in instance.categoryOfVessel)
					categoryOfVessel.Add(e);
			}
			orientationValue.Clear();
			if (instance.orientationValue is not null) {
				foreach(var e in instance.orientationValue)
					orientationValue.Add(e);
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			trafficFlow = instance.trafficFlow;
			return this;
		}

		public override string Serialize() {
			var instance = new RadioCallingInPoint {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				callSign = this.callSign,
				communicationChannel = this.communicationChannel.ToList(),
				categoryOfCargo = this.categoryOfCargo.ToList(),
				categoryOfVessel = this.categoryOfVessel.ToList(),
				orientationValue = this.orientationValue.ToList(),
				status = this.status.ToList(),
				trafficFlow = this.trafficFlow,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RadioCallingInPoint Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			callSign = this._callSign,
			communicationChannel = this.communicationChannel.ToList(),
			categoryOfCargo = this.categoryOfCargo.ToList(),
			categoryOfVessel = this.categoryOfVessel.ToList(),
			orientationValue = this.orientationValue.ToList(),
			status = this.status.ToList(),
			trafficFlow = this._trafficFlow,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.RadioCallingInPoint.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.RadioCallingInPoint.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.RadioCallingInPoint.featureBindingDefinitions;

		public RadioCallingInPointViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public RadioCallingInPointViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Radio Calling-In Point";

		public RadioCallingInPointViewModel() : base() {
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
			communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(communicationChannel));
			};
			categoryOfCargo.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfCargo));
			};
			categoryOfVessel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfVessel));
			};
			orientationValue.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(orientationValue));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			TrafficControlServiceAggregations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(TrafficControlServiceAggregations));
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
		[PermittedValues([1,4,5,6,7,8,9,10,12,14,19,20,22,23,25,27,28,29,30,31,32])]
		[Optional]
		public ObservableCollection<categoryOfRestrictedArea> categoryOfRestrictedArea  { get; set; } = new ();

		[Description("The official legal statute of each kind of restricted area.")]
		[Category("RestrictedArea")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,35,36,37,38,39,40,41,42,43])]
		[Multiplicity(1)]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("RestrictedArea")]
		[PermittedValues([1,2,3,4,5,6,7,9,18,28])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

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
	/// An area or line designating the limits or central line of a routeing measure (or part of a routeing measure). Routeing measures include traffic separation schemes, deep-water routes, two-way routes, archipelagic sea lanes, and fairway systems.
	/// </summary>
	[Description("An area or line designating the limits or central line of a routeing measure (or part of a routeing measure). Routeing measures include traffic separation schemes, deep-water routes, two-way routes, archipelagic sea lanes, and fairway systems.")]
	[CategoryOrder("RouteingMeasure",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RouteingMeasureViewModel : FeatureViewModel<RouteingMeasure> {
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

		private categoryOfRouteingMeasure _categoryOfRouteingMeasure  = default;

		[Description("Classification of routeing measures by type.")]
		[Category("RouteingMeasure")]
		//[Editor(typeof(Editors.HorizonEditor<RouteingMeasure>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6])]
		[Mandatory]
		public categoryOfRouteingMeasure categoryOfRouteingMeasure {
			get {
				return _categoryOfRouteingMeasure;
			}
			set {
				SetValue(ref _categoryOfRouteingMeasure, value);
			}
		}

		private categoryOfTrafficSeparationScheme? _categoryOfTrafficSeparationScheme  = default;

		[Description("International classification of traffic separation scheme.")]
		[Category("RouteingMeasure")]
		//[Editor(typeof(Editors.HorizonEditor<RouteingMeasure>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2])]
		[Optional]
		public categoryOfTrafficSeparationScheme? categoryOfTrafficSeparationScheme {
			get {
				return _categoryOfTrafficSeparationScheme;
			}
			set {
				SetValue(ref _categoryOfTrafficSeparationScheme, value);
			}
		}

		private categoryOfNavigationLine? _categoryOfNavigationLine  = default;

		[Description("Classification of route guidance given to vessels.")]
		[Category("RouteingMeasure")]
		//[Editor(typeof(Editors.HorizonEditor<RouteingMeasure>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public categoryOfNavigationLine? categoryOfNavigationLine {
			get {
				return _categoryOfNavigationLine;
			}
			set {
				SetValue(ref _categoryOfNavigationLine, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public RouteingMeasureViewModel Load(RouteingMeasure instance) {
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
			categoryOfRouteingMeasure = instance.categoryOfRouteingMeasure;
			categoryOfTrafficSeparationScheme = instance.categoryOfTrafficSeparationScheme;
			categoryOfNavigationLine = instance.categoryOfNavigationLine;
			return this;
		}

		public override string Serialize() {
			var instance = new RouteingMeasure {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				categoryOfRouteingMeasure = this.categoryOfRouteingMeasure,
				categoryOfTrafficSeparationScheme = this.categoryOfTrafficSeparationScheme,
				categoryOfNavigationLine = this.categoryOfNavigationLine,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RouteingMeasure Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfRouteingMeasure = this._categoryOfRouteingMeasure,
			categoryOfTrafficSeparationScheme = this._categoryOfTrafficSeparationScheme,
			categoryOfNavigationLine = this._categoryOfNavigationLine,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.RouteingMeasure.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.RouteingMeasure.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.RouteingMeasure.featureBindingDefinitions;

		public RouteingMeasureViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public RouteingMeasureViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Routeing Measure";

		public RouteingMeasureViewModel() : base() {
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
	/// A service established by a relevant authority consisting of one or more reporting points or lines at which ships are required to report their identity, course, speed and other data to the monitoring authority.
	/// </summary>
	[Description("A service established by a relevant authority consisting of one or more reporting points or lines at which ships are required to report their identity, course, speed and other data to the monitoring authority.")]
	[CategoryOrder("ShipReportingServiceArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ShipReportingServiceAreaViewModel : FeatureViewModel<ShipReportingServiceArea> {
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




		private String? _serviceAccessProcedure  = default;

		[Description("A description of the procedure to access the marine service.")]
		[Category("ShipReportingServiceArea")]
		//[Editor(typeof(Editors.HorizonEditor<ShipReportingServiceArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? serviceAccessProcedure {
			get {
				return _serviceAccessProcedure;
			}
			set {
				SetValue(ref _serviceAccessProcedure, value);
			}
		}

		private String _requirementsForMaintenanceOfListeningWatch  = string.Empty;

		[Description("Something needed to ensure constant acoustic monitoring.")]
		[Category("ShipReportingServiceArea")]
		//[Editor(typeof(Editors.HorizonEditor<ShipReportingServiceArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String requirementsForMaintenanceOfListeningWatch {
			get {
				return _requirementsForMaintenanceOfListeningWatch;
			}
			set {
				SetValue(ref _requirementsForMaintenanceOfListeningWatch, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("TrafficControlServiceAggregation","consistsOf",["RadioCallingInPoint","RadarRange","SignalStationWarning","SignalStationTraffic"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> TrafficControlServiceAggregations { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. TrafficControlServiceAggregations.Select(e => new featureBinding<DomainModel.S127.FeatureAssociations.TrafficControlServiceAggregation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public ShipReportingServiceAreaViewModel Load(ShipReportingServiceArea instance) {
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
			serviceAccessProcedure = instance.serviceAccessProcedure;
			requirementsForMaintenanceOfListeningWatch = instance.requirementsForMaintenanceOfListeningWatch;
			return this;
		}

		public override string Serialize() {
			var instance = new ShipReportingServiceArea {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				serviceAccessProcedure = this.serviceAccessProcedure,
				requirementsForMaintenanceOfListeningWatch = this.requirementsForMaintenanceOfListeningWatch,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ShipReportingServiceArea Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			serviceAccessProcedure = this._serviceAccessProcedure,
			requirementsForMaintenanceOfListeningWatch = this._requirementsForMaintenanceOfListeningWatch,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.ShipReportingServiceArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.ShipReportingServiceArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.ShipReportingServiceArea.featureBindingDefinitions;

		public ShipReportingServiceAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public ShipReportingServiceAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Ship Reporting Service Area";

		public ShipReportingServiceAreaViewModel() : base() {
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
			TrafficControlServiceAggregations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(TrafficControlServiceAggregations));
			};
		}
	}



	/// <summary>
	/// A warning signal station is a place on shore from which warning signals are made to ships at sea.
	/// </summary>
	[Description("A warning signal station is a place on shore from which warning signals are made to ships at sea.")]
	[CategoryOrder("SignalStationWarning",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SignalStationWarningViewModel : FeatureViewModel<SignalStationWarning> {
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

		[Description("Classification of station based on the warning service provided.")]
		[Category("SignalStationWarning")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18])]
		[Multiplicity(1)]
		public ObservableCollection<categoryOfSignalStationWarning> categoryOfSignalStationWarning  { get; set; } = new ();

		[Description("A channel number assigned to a specific radio frequency, frequencies or frequency band.")]
		[Category("SignalStationWarning")]
		[Optional]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("SignalStationWarning")]
		[PermittedValues([1,2,4,5,7,8,12,14,15,16,17])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("TrafficControlServiceAggregation","componentOf",["VesselTrafficServiceArea","LocalPortBroadcastServiceArea","ShipReportingServiceArea"], lower:0, upper:1)]
		public ObservableCollection<FeatureRefViewModel> TrafficControlServiceAggregations { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. TrafficControlServiceAggregations.Select(e => new featureBinding<DomainModel.S127.FeatureAssociations.TrafficControlServiceAggregation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public SignalStationWarningViewModel Load(SignalStationWarning instance) {
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
			categoryOfSignalStationWarning.Clear();
			if (instance.categoryOfSignalStationWarning is not null) {
				foreach(var e in instance.categoryOfSignalStationWarning)
					categoryOfSignalStationWarning.Add(e);
			}
			communicationChannel.Clear();
			if (instance.communicationChannel is not null) {
				foreach(var e in instance.communicationChannel)
					communicationChannel.Add(e);
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new SignalStationWarning {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				categoryOfSignalStationWarning = this.categoryOfSignalStationWarning.ToList(),
				communicationChannel = this.communicationChannel.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SignalStationWarning Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfSignalStationWarning = this.categoryOfSignalStationWarning.ToList(),
			communicationChannel = this.communicationChannel.ToList(),
			status = this.status.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SignalStationWarning.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.SignalStationWarning.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SignalStationWarning.featureBindingDefinitions;

		public SignalStationWarningViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SignalStationWarningViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Signal Station Warning";

		public SignalStationWarningViewModel() : base() {
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
			categoryOfSignalStationWarning.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfSignalStationWarning));
			};
			communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(communicationChannel));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			TrafficControlServiceAggregations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(TrafficControlServiceAggregations));
			};
		}
	}



	/// <summary>
	/// A traffic signal station is a place on shore from which signals are made to regulate the movement of traffic.
	/// </summary>
	[Description("A traffic signal station is a place on shore from which signals are made to regulate the movement of traffic.")]
	[CategoryOrder("SignalStationTraffic",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SignalStationTrafficViewModel : FeatureViewModel<SignalStationTraffic> {
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


		[Description("Classification of station based on the traffic service provided.")]
		[Category("SignalStationTraffic")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,13])]
		[Multiplicity(1)]
		public ObservableCollection<categoryOfSignalStationTraffic> categoryOfSignalStationTraffic  { get; set; } = new ();

		[Description("A channel number assigned to a specific radio frequency, frequencies or frequency band.")]
		[Category("SignalStationTraffic")]
		[Optional]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("SignalStationTraffic")]
		[PermittedValues([1,2,4,5,7,8,12,14,15,16,17])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("TrafficControlServiceAggregation","componentOf",["VesselTrafficServiceArea","LocalPortBroadcastServiceArea","ShipReportingServiceArea"], lower:0, upper:1)]
		public ObservableCollection<FeatureRefViewModel> TrafficControlServiceAggregations { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. TrafficControlServiceAggregations.Select(e => new featureBinding<DomainModel.S127.FeatureAssociations.TrafficControlServiceAggregation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public SignalStationTrafficViewModel Load(SignalStationTraffic instance) {
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
			categoryOfSignalStationTraffic.Clear();
			if (instance.categoryOfSignalStationTraffic is not null) {
				foreach(var e in instance.categoryOfSignalStationTraffic)
					categoryOfSignalStationTraffic.Add(e);
			}
			communicationChannel.Clear();
			if (instance.communicationChannel is not null) {
				foreach(var e in instance.communicationChannel)
					communicationChannel.Add(e);
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new SignalStationTraffic {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				categoryOfSignalStationTraffic = this.categoryOfSignalStationTraffic.ToList(),
				communicationChannel = this.communicationChannel.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SignalStationTraffic Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfSignalStationTraffic = this.categoryOfSignalStationTraffic.ToList(),
			communicationChannel = this.communicationChannel.ToList(),
			status = this.status.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SignalStationTraffic.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.SignalStationTraffic.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SignalStationTraffic.featureBindingDefinitions;

		public SignalStationTrafficViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SignalStationTrafficViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Signal Station Traffic";

		public SignalStationTrafficViewModel() : base() {
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
			categoryOfSignalStationTraffic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfSignalStationTraffic));
			};
			communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(communicationChannel));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			TrafficControlServiceAggregations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(TrafficControlServiceAggregations));
			};
		}
	}



	/// <summary>
	/// An area for which an authority has stated under keel allowance requirements.
	/// </summary>
	[Description("An area for which an authority has stated under keel allowance requirements.")]
	[CategoryOrder("UnderKeelClearanceAllowanceArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class UnderKeelClearanceAllowanceAreaViewModel : FeatureViewModel<UnderKeelClearanceAllowanceArea> {
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

		private underKeelAllowanceViewModel? _underKeelAllowance  = default;

		[Description("	A fixed figure, or a figure derived by calculation, which is added to draught in order to maintain the minimum under keel clearance taking into account the vessel's static and dynamic characteristics, sea state and weather forecast, the reliability of the chart and variance from predicted height of tide or water level.")]
		[Category("UnderKeelClearanceAllowanceArea")]
		[ExpandableObject]
		[Optional]
		public underKeelAllowanceViewModel? underKeelAllowance {
			get {
				return _underKeelAllowance;
			}
			set {
				SetValue(ref _underKeelAllowance, value);
			}
		}

		private waterLevelTrend? _waterLevelTrend  = default;

		[Description("The tendency of water level to change in a particular direction.")]
		[Category("UnderKeelClearanceAllowanceArea")]
		//[Editor(typeof(Editors.HorizonEditor<UnderKeelClearanceAllowanceArea>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public waterLevelTrend? waterLevelTrend {
			get {
				return _waterLevelTrend;
			}
			set {
				SetValue(ref _waterLevelTrend, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public UnderKeelClearanceAllowanceAreaViewModel Load(UnderKeelClearanceAllowanceArea instance) {
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
			underKeelAllowance = new ();
			if (instance.underKeelAllowance != default) {
				underKeelAllowance.Load(instance.underKeelAllowance);
			}
			waterLevelTrend = instance.waterLevelTrend;
			return this;
		}

		public override string Serialize() {
			var instance = new UnderKeelClearanceAllowanceArea {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				underKeelAllowance = this.underKeelAllowance?.Model,
				waterLevelTrend = this.waterLevelTrend,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public UnderKeelClearanceAllowanceArea Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			underKeelAllowance = this._underKeelAllowance?.Model,
			waterLevelTrend = this._waterLevelTrend,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.UnderKeelClearanceAllowanceArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.UnderKeelClearanceAllowanceArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.UnderKeelClearanceAllowanceArea.featureBindingDefinitions;

		public UnderKeelClearanceAllowanceAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public UnderKeelClearanceAllowanceAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Under Keel Clearance Allowance Area";

		public UnderKeelClearanceAllowanceAreaViewModel() : base() {
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
	/// An area for which an authority permits use of dynamic under keel clearance information or provides dynamic information related to under keel clearances.
	/// </summary>
	[Description("An area for which an authority permits use of dynamic under keel clearance information or provides dynamic information related to under keel clearances.")]
	[CategoryOrder("UnderKeelClearanceManagementArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class UnderKeelClearanceManagementAreaViewModel : FeatureViewModel<UnderKeelClearanceManagementArea> {
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




		private dynamicResource _dynamicResource  = default;

		[Description("Whether a vessel must use a shore-based or other resource to obtain up-to-date information.")]
		[Category("UnderKeelClearanceManagementArea")]
		//[Editor(typeof(Editors.HorizonEditor<UnderKeelClearanceManagementArea>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Mandatory]
		public dynamicResource dynamicResource {
			get {
				return _dynamicResource;
			}
			set {
				SetValue(ref _dynamicResource, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public UnderKeelClearanceManagementAreaViewModel Load(UnderKeelClearanceManagementArea instance) {
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
			dynamicResource = instance.dynamicResource;
			return this;
		}

		public override string Serialize() {
			var instance = new UnderKeelClearanceManagementArea {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				dynamicResource = this.dynamicResource,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public UnderKeelClearanceManagementArea Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			dynamicResource = this._dynamicResource,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.UnderKeelClearanceManagementArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.UnderKeelClearanceManagementArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.UnderKeelClearanceManagementArea.featureBindingDefinitions;

		public UnderKeelClearanceManagementAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public UnderKeelClearanceManagementAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Under Keel Clearance Management Area";

		public UnderKeelClearanceManagementAreaViewModel() : base() {
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




		private String? _serviceAccessProcedure  = default;

		[Description("A description of the procedure to access the marine service.")]
		[Category("VesselTrafficServiceArea")]
		//[Editor(typeof(Editors.HorizonEditor<VesselTrafficServiceArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? serviceAccessProcedure {
			get {
				return _serviceAccessProcedure;
			}
			set {
				SetValue(ref _serviceAccessProcedure, value);
			}
		}

		private String _requirementsForMaintenanceOfListeningWatch  = string.Empty;

		[Description("Something needed to ensure constant acoustic monitoring.")]
		[Category("VesselTrafficServiceArea")]
		//[Editor(typeof(Editors.HorizonEditor<VesselTrafficServiceArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String requirementsForMaintenanceOfListeningWatch {
			get {
				return _requirementsForMaintenanceOfListeningWatch;
			}
			set {
				SetValue(ref _requirementsForMaintenanceOfListeningWatch, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("TrafficControlServiceAggregation","consistsOf",["RadioCallingInPoint","RadarRange","SignalStationWarning","SignalStationTraffic"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> TrafficControlServiceAggregations { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. TrafficControlServiceAggregations.Select(e => new featureBinding<DomainModel.S127.FeatureAssociations.TrafficControlServiceAggregation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

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
			serviceAccessProcedure = instance.serviceAccessProcedure;
			requirementsForMaintenanceOfListeningWatch = instance.requirementsForMaintenanceOfListeningWatch;
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
				serviceAccessProcedure = this.serviceAccessProcedure,
				requirementsForMaintenanceOfListeningWatch = this.requirementsForMaintenanceOfListeningWatch,
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
			serviceAccessProcedure = this._serviceAccessProcedure,
			requirementsForMaintenanceOfListeningWatch = this._requirementsForMaintenanceOfListeningWatch,
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
			TrafficControlServiceAggregations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(TrafficControlServiceAggregations));
			};
		}
	}



	/// <summary>
	/// An area in which uniform general information of the waterway exists.
	/// </summary>
	[Description("An area in which uniform general information of the waterway exists.")]
	[CategoryOrder("WaterwayArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class WaterwayAreaViewModel : FeatureViewModel<WaterwayArea> {
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



		private dynamicResource _dynamicResource  = default;

		[Description("Whether a vessel must use a shore-based or other resource to obtain up-to-date information.")]
		[Category("WaterwayArea")]
		//[Editor(typeof(Editors.HorizonEditor<WaterwayArea>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Mandatory]
		public dynamicResource dynamicResource {
			get {
				return _dynamicResource;
			}
			set {
				SetValue(ref _dynamicResource, value);
			}
		}

		private String? _siltationRate  = default;

		[Description("A description of the rate at which the depth in an area decreases.")]
		[Category("WaterwayArea")]
		//[Editor(typeof(Editors.HorizonEditor<WaterwayArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? siltationRate {
			get {
				return _siltationRate;
			}
			set {
				SetValue(ref _siltationRate, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("WaterwayArea")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,28])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public WaterwayAreaViewModel Load(WaterwayArea instance) {
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
			dynamicResource = instance.dynamicResource;
			siltationRate = instance.siltationRate;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new WaterwayArea {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
				dynamicResource = this.dynamicResource,
				siltationRate = this.siltationRate,
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public WaterwayArea Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			dynamicResource = this._dynamicResource,
			siltationRate = this._siltationRate,
			status = this.status.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.WaterwayArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.WaterwayArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.WaterwayArea.featureBindingDefinitions;

		public WaterwayAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public WaterwayAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Waterway Area";

		public WaterwayAreaViewModel() : base() {
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
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
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
		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("DataCoverage")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

		private int _maximumDisplayScale  = default;

		[Description("The largest intended viewing scale for the data.")]
		[Category("DataCoverage")]
		//[Editor(typeof(Editors.HorizonEditor<DataCoverage>), typeof(Editors.HorizonEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<DataCoverage>), typeof(Editors.HorizonEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<DataCoverage>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? optimumDisplayScale {
			get {
				return _optimumDisplayScale;
			}
			set {
				SetValue(ref _optimumDisplayScale, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public DataCoverageViewModel Load(DataCoverage instance) {
			interoperabilityIdentifier.Clear();
			if (instance.interoperabilityIdentifier is not null) {
				foreach(var e in instance.interoperabilityIdentifier)
					interoperabilityIdentifier.Add(e);
			}
			maximumDisplayScale = instance.maximumDisplayScale;
			minimumDisplayScale = instance.minimumDisplayScale;
			optimumDisplayScale = instance.optimumDisplayScale;
			return this;
		}

		public override string Serialize() {
			var instance = new DataCoverage {
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				maximumDisplayScale = this.maximumDisplayScale,
				minimumDisplayScale = this.minimumDisplayScale,
				optimumDisplayScale = this.optimumDisplayScale,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DataCoverage Model => new () {
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			maximumDisplayScale = this._maximumDisplayScale,
			minimumDisplayScale = this._minimumDisplayScale,
			optimumDisplayScale = this._optimumDisplayScale,
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
		//[Editor(typeof(Editors.HorizonEditor<QualityOfNonBathymetricData>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,4,5,6])]
		[Optional]
		public categoryOfTemporalVariation? categoryOfTemporalVariation {
			get {
				return _categoryOfTemporalVariation;
			}
			set {
				SetValue(ref _categoryOfTemporalVariation, value);
			}
		}

		private double? _horizontalDistanceUncertainty  = default;

		[Description("The best estimate of the horizontal accuracy of horizontal clearances and distances.")]
		[Category("QualityOfNonBathymetricData")]
		//[Editor(typeof(Editors.HorizonEditor<QualityOfNonBathymetricData>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalDistanceUncertainty {
			get {
				return _horizontalDistanceUncertainty;
			}
			set {
				SetValue(ref _horizontalDistanceUncertainty, value);
			}
		}

		private double? _orientationUncertainty  = default;

		[Description("The best estimate of the accuracy of a bearing.")]
		[Category("QualityOfNonBathymetricData")]
		//[Editor(typeof(Editors.HorizonEditor<QualityOfNonBathymetricData>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? orientationUncertainty {
			get {
				return _orientationUncertainty;
			}
			set {
				SetValue(ref _orientationUncertainty, value);
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


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public QualityOfNonBathymetricDataViewModel Load(QualityOfNonBathymetricData instance) {
			categoryOfTemporalVariation = instance.categoryOfTemporalVariation;
			horizontalDistanceUncertainty = instance.horizontalDistanceUncertainty;
			orientationUncertainty = instance.orientationUncertainty;
			horizontalPositionUncertainty = new ();
			if (instance.horizontalPositionUncertainty != default) {
				horizontalPositionUncertainty.Load(instance.horizontalPositionUncertainty);
			}
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
				orientationUncertainty = this.orientationUncertainty,
				horizontalPositionUncertainty = this.horizontalPositionUncertainty?.Model,
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
			orientationUncertainty = this._orientationUncertainty,
			horizontalPositionUncertainty = this._horizontalPositionUncertainty?.Model,
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
		//[Editor(typeof(Editors.HorizonEditor<TextPlacement>), typeof(Editors.HorizonEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<TextPlacement>), typeof(Editors.HorizonEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<TextPlacement>), typeof(Editors.HorizonEditor))]
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
		[PermittedValues([1])]
		[Multiplicity(1, 2)]
		public ObservableCollection<textType> textType  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("TextPlacement")]
		//[Editor(typeof(Editors.HorizonEditor<TextPlacement>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("TextAssociation","thePositionProvider",["FeatureType"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> TextAssociations { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. TextAssociations.Select(e => new featureBinding<DomainModel.S127.FeatureAssociations.TextAssociation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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
					instance.InclusionTypes.Add(new InformationRefViewModel {
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
					instance.AuthorityContacts.Add(new InformationRefViewModel {
						informationId = authorityContact.referenceId,
						informationType = authorityContact.informationType,
						role = authorityContact.role,
					});
				}
				if(informationBinding is informationBinding<RelatedOrganisation> relatedOrganisation) {
					instance.RelatedOrganisations.Add(new InformationRefViewModel {
						informationId = relatedOrganisation.referenceId,
						informationType = relatedOrganisation.informationType,
						role = relatedOrganisation.role,
					});
				}
				if(informationBinding is informationBinding<AuthorityHours> authorityHours) {
					instance.AuthorityHours.Add(new InformationRefViewModel {
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
					instance.AuthorityContacts.Add(new InformationRefViewModel {
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
					instance.ExceptionalWorkdays.Add(new InformationRefViewModel {
						informationId = exceptionalWorkday.referenceId,
						informationType = exceptionalWorkday.informationType,
						role = exceptionalWorkday.role,
					});
				}
				if(informationBinding is informationBinding<AuthorityHours> authorityHours) {
					instance.AuthorityHours.Add(new InformationRefViewModel {
						informationId = authorityHours.referenceId,
						informationType = authorityHours.informationType,
						role = authorityHours.role,
					});
				}
			}
			return instance;
		}

		public static ShipReportViewModel LoadInformationBinding(this ShipReportViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ReportingRequirement> reportingRequirement) {
					instance.ReportingRequirements.Add(new InformationRefViewModel {
						informationId = reportingRequirement.referenceId,
						informationType = reportingRequirement.informationType,
						role = reportingRequirement.role,
					});
				}
				if(informationBinding is informationBinding<ReportingAuthority> reportingAuthority) {
					instance.ReportingAuthorities.Add(new InformationRefViewModel {
						informationId = reportingAuthority.referenceId,
						informationType = reportingAuthority.informationType,
						role = reportingAuthority.role,
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

		public static CautionAreaViewModel LoadInformationBinding(this CautionAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static ConcentrationOfShippingHazardAreaViewModel LoadInformationBinding(this ConcentrationOfShippingHazardAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static ISPSCodeSecurityLevelViewModel LoadInformationBinding(this ISPSCodeSecurityLevelViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LocalPortBroadcastServiceAreaViewModel LoadInformationBinding(this LocalPortBroadcastServiceAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static MilitaryPracticeAreaViewModel LoadInformationBinding(this MilitaryPracticeAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new InformationRefViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static PilotBoardingPlaceViewModel LoadInformationBinding(this PilotBoardingPlaceViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static PilotServiceViewModel LoadInformationBinding(this PilotServiceViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new InformationRefViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static PilotageDistrictViewModel LoadInformationBinding(this PilotageDistrictViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static PiracyRiskAreaViewModel LoadInformationBinding(this PiracyRiskAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static PlaceOfRefugeViewModel LoadInformationBinding(this PlaceOfRefugeViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RadarRangeViewModel LoadInformationBinding(this RadarRangeViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RadioCallingInPointViewModel LoadInformationBinding(this RadioCallingInPointViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RestrictedAreaViewModel LoadInformationBinding(this RestrictedAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RouteingMeasureViewModel LoadInformationBinding(this RouteingMeasureViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static ShipReportingServiceAreaViewModel LoadInformationBinding(this ShipReportingServiceAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SignalStationWarningViewModel LoadInformationBinding(this SignalStationWarningViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SignalStationTrafficViewModel LoadInformationBinding(this SignalStationTrafficViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static UnderKeelClearanceAllowanceAreaViewModel LoadInformationBinding(this UnderKeelClearanceAllowanceAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static UnderKeelClearanceManagementAreaViewModel LoadInformationBinding(this UnderKeelClearanceManagementAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static VesselTrafficServiceAreaViewModel LoadInformationBinding(this VesselTrafficServiceAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static WaterwayAreaViewModel LoadInformationBinding(this WaterwayAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
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
		public static CautionAreaViewModel LoadFeatureBinding(this CautionAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static ConcentrationOfShippingHazardAreaViewModel LoadFeatureBinding(this ConcentrationOfShippingHazardAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static ISPSCodeSecurityLevelViewModel LoadFeatureBinding(this ISPSCodeSecurityLevelViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LocalPortBroadcastServiceAreaViewModel LoadFeatureBinding(this LocalPortBroadcastServiceAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<TrafficControlServiceAggregation> trafficControlServiceAggregation) {
					instance.TrafficControlServiceAggregations.Add(new FeatureRefViewModel {
						featureId = trafficControlServiceAggregation.referenceId,
						featureType = trafficControlServiceAggregation.featureType,
						role = trafficControlServiceAggregation.role,
					});
				}
			}
			return instance;
		}

		public static MilitaryPracticeAreaViewModel LoadFeatureBinding(this MilitaryPracticeAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static PilotBoardingPlaceViewModel LoadFeatureBinding(this PilotBoardingPlaceViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<PilotageDistrictAssociation> pilotageDistrictAssociation) {
					instance.PilotageDistrictAssociations.Add(new FeatureRefViewModel {
						featureId = pilotageDistrictAssociation.referenceId,
						featureType = pilotageDistrictAssociation.featureType,
						role = pilotageDistrictAssociation.role,
					});
				}
				if(featureBinding is featureBinding<ServiceProvisionArea> serviceProvisionArea) {
					instance.ServiceProvisionAreas.Add(new FeatureRefViewModel {
						featureId = serviceProvisionArea.referenceId,
						featureType = serviceProvisionArea.featureType,
						role = serviceProvisionArea.role,
					});
				}
			}
			return instance;
		}

		public static PilotServiceViewModel LoadFeatureBinding(this PilotServiceViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<ServiceProvisionArea> serviceProvisionArea) {
					instance.ServiceProvisionAreas.Add(new FeatureRefViewModel {
						featureId = serviceProvisionArea.referenceId,
						featureType = serviceProvisionArea.featureType,
						role = serviceProvisionArea.role,
					});
				}
			}
			return instance;
		}

		public static PilotageDistrictViewModel LoadFeatureBinding(this PilotageDistrictViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<PilotageDistrictAssociation> pilotageDistrictAssociation) {
					instance.PilotageDistrictAssociations.Add(new FeatureRefViewModel {
						featureId = pilotageDistrictAssociation.referenceId,
						featureType = pilotageDistrictAssociation.featureType,
						role = pilotageDistrictAssociation.role,
					});
				}
				if(featureBinding is featureBinding<ServiceProvisionArea> serviceProvisionArea) {
					instance.ServiceProvisionAreas.Add(new FeatureRefViewModel {
						featureId = serviceProvisionArea.referenceId,
						featureType = serviceProvisionArea.featureType,
						role = serviceProvisionArea.role,
					});
				}
			}
			return instance;
		}

		public static PiracyRiskAreaViewModel LoadFeatureBinding(this PiracyRiskAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static PlaceOfRefugeViewModel LoadFeatureBinding(this PlaceOfRefugeViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static RadarRangeViewModel LoadFeatureBinding(this RadarRangeViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<TrafficControlServiceAggregation> trafficControlServiceAggregation) {
					instance.TrafficControlServiceAggregations.Add(new FeatureRefViewModel {
						featureId = trafficControlServiceAggregation.referenceId,
						featureType = trafficControlServiceAggregation.featureType,
						role = trafficControlServiceAggregation.role,
					});
				}
			}
			return instance;
		}

		public static RadioCallingInPointViewModel LoadFeatureBinding(this RadioCallingInPointViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<TrafficControlServiceAggregation> trafficControlServiceAggregation) {
					instance.TrafficControlServiceAggregations.Add(new FeatureRefViewModel {
						featureId = trafficControlServiceAggregation.referenceId,
						featureType = trafficControlServiceAggregation.featureType,
						role = trafficControlServiceAggregation.role,
					});
				}
			}
			return instance;
		}

		public static RestrictedAreaViewModel LoadFeatureBinding(this RestrictedAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static RouteingMeasureViewModel LoadFeatureBinding(this RouteingMeasureViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static ShipReportingServiceAreaViewModel LoadFeatureBinding(this ShipReportingServiceAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<TrafficControlServiceAggregation> trafficControlServiceAggregation) {
					instance.TrafficControlServiceAggregations.Add(new FeatureRefViewModel {
						featureId = trafficControlServiceAggregation.referenceId,
						featureType = trafficControlServiceAggregation.featureType,
						role = trafficControlServiceAggregation.role,
					});
				}
			}
			return instance;
		}

		public static SignalStationWarningViewModel LoadFeatureBinding(this SignalStationWarningViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<TrafficControlServiceAggregation> trafficControlServiceAggregation) {
					instance.TrafficControlServiceAggregations.Add(new FeatureRefViewModel {
						featureId = trafficControlServiceAggregation.referenceId,
						featureType = trafficControlServiceAggregation.featureType,
						role = trafficControlServiceAggregation.role,
					});
				}
			}
			return instance;
		}

		public static SignalStationTrafficViewModel LoadFeatureBinding(this SignalStationTrafficViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<TrafficControlServiceAggregation> trafficControlServiceAggregation) {
					instance.TrafficControlServiceAggregations.Add(new FeatureRefViewModel {
						featureId = trafficControlServiceAggregation.referenceId,
						featureType = trafficControlServiceAggregation.featureType,
						role = trafficControlServiceAggregation.role,
					});
				}
			}
			return instance;
		}

		public static UnderKeelClearanceAllowanceAreaViewModel LoadFeatureBinding(this UnderKeelClearanceAllowanceAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static UnderKeelClearanceManagementAreaViewModel LoadFeatureBinding(this UnderKeelClearanceManagementAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static VesselTrafficServiceAreaViewModel LoadFeatureBinding(this VesselTrafficServiceAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<TrafficControlServiceAggregation> trafficControlServiceAggregation) {
					instance.TrafficControlServiceAggregations.Add(new FeatureRefViewModel {
						featureId = trafficControlServiceAggregation.referenceId,
						featureType = trafficControlServiceAggregation.featureType,
						role = trafficControlServiceAggregation.role,
					});
				}
			}
			return instance;
		}

		public static WaterwayAreaViewModel LoadFeatureBinding(this WaterwayAreaViewModel instance, featureBinding[] bindings) {
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
					instance.TextAssociations.Add(new FeatureRefViewModel {
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
