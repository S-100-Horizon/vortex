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
			"InformationType" => new InformationTypeViewModel { Name = name },
			"AbstractRxN" => new AbstractRxNViewModel { Name = name },
			"Applicability" => new ApplicabilityViewModel { Name = name },
			"Authority" => new AuthorityViewModel { Name = name },
			"ContactDetails" => new ContactDetailsViewModel { Name = name },
			"NauticalInformation" => new NauticalInformationViewModel { Name = name },
			"NonStandardWorkingDay" => new NonStandardWorkingDayViewModel { Name = name },
			"ServiceHours" => new ServiceHoursViewModel { Name = name },
			"ShipReport" => new ShipReportViewModel { Name = name },
			"Recommendations" => new RecommendationsViewModel { Name = name },
			"Regulations" => new RegulationsViewModel { Name = name },
			"Restrictions" => new RestrictionsViewModel { Name = name },
			"SpatialQuality" => new SpatialQualityViewModel { Name = name },
			"SpatialQualityPoints" => new SpatialQualityPointsViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static FeatureViewModel CreateFeatureType(string type, string? name = default) => type switch {
			"CautionArea" => new CautionAreaViewModel { Name = name },
			"ConcentrationOfShippingHazardArea" => new ConcentrationOfShippingHazardAreaViewModel { Name = name },
			"ISPSCodeSecurityLevel" => new ISPSCodeSecurityLevelViewModel { Name = name },
			"LocalPortServiceArea" => new LocalPortServiceAreaViewModel { Name = name },
			"MilitaryPracticeArea" => new MilitaryPracticeAreaViewModel { Name = name },
			"PilotBoardingPlace" => new PilotBoardingPlaceViewModel { Name = name },
			"PilotService" => new PilotServiceViewModel { Name = name },
			"PilotageDistrict" => new PilotageDistrictViewModel { Name = name },
			"PiracyRiskArea" => new PiracyRiskAreaViewModel { Name = name },
			"PlaceOfRefuge" => new PlaceOfRefugeViewModel { Name = name },
			"RadarRange" => new RadarRangeViewModel { Name = name },
			"RadioCallingInPoint" => new RadioCallingInPointViewModel { Name = name },
			"RestrictedAreaNavigational" => new RestrictedAreaNavigationalViewModel { Name = name },
			"RestrictedAreaRegulatory" => new RestrictedAreaRegulatoryViewModel { Name = name },
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
			("AdditionalInformation", "providesInformation") => ["NauticalInformation"],
			("InclusionType", "isApplicableTo") => ["Applicability"],
			("RelatedOrganisation", "theOrganisation") => ["AbstractRxN"],
			("InclusionType", "theApplicableRxN") => ["AbstractRxN"],
			("ReportingRequirement", "theShipReport") => ["ShipReport"],
			("PermissionType", "vslLocation") => ["InformationType"],
			("AuthorityContact", "theContactDetails") => ["ContactDetails"],
			("ReportingAuthority", "theShipReport") => ["ShipReport"],
			("RelatedOrganisation", "theInformation") => ["AbstractRxN"],
			("AuthorityHours", "theServiceHours") => ["ServiceHours"],
			("AuthorityContact", "theAuthority") => ["Authority"],
			("AdditionalInformation", "informationProvidedFor") => ["InformationType"],
			("ExceptionalWorkday", "partialWorkingDay") => ["NonStandardWorkingDay"],
			("AuthorityHours", "theAuthority_srvHrs") => ["Authority"],
			("ReportingRequirement", "mustBeFiledBy") => ["Applicability"],
			("ReportingAuthority", "reportTo") => ["Authority"],
			("PermissionType", "permission") => ["Applicability"],
			("AssociatedRxN", "theRxN") => ["AbstractRxN"],
			("ServiceContact", "theContactDetails") => ["ContactDetails"],
			("ServiceControl", "controlAuthority") => ["Authority"],
			("TrafficServiceReport", "reptForTrafficServ") => ["ShipReport"],
			("LocationHours", "theServiceHours") => ["ServiceHours"],
			_ => throw new InvalidOperationException(),
		};

		public static ICollection<string> FeatureAssociationBindings(string association, string role) => (association, role) switch {
			("TextAssociation", "positions") => ["TextPlacement"],
			("TrafficControlServiceAggregation", "consistsOf") => ["RadioCallingInPoint","RadarRange","SignalStationWarning","SignalStationTraffic"],
			("PilotageDistrictAssociation", "componentOf") => ["PilotageDistrict"],
			("ServiceProvisionArea", "serviceProvider") => ["PilotService"],
			("ServiceProvisionArea", "serviceArea") => ["PilotageDistrict","PilotBoardingPlace"],
			("PilotageDistrictAssociation", "consistsOf") => ["PilotBoardingPlace"],
			("TrafficControlServiceAggregation", "componentOf") => ["VesselTrafficServiceArea","LocalPortServiceArea","ShipReportingServiceArea"],
			("TextAssociation", "identifies") => ["FeatureType"],
			_ => throw new InvalidOperationException(),
		};
	}

	/// <summary>
	/// A bearing is the direction one object is from another object.
	/// </summary>
	[CategoryOrder("bearingInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class bearingInformationViewModel : ViewModelBase {
		private cardinalDirection? _cardinalDirection  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(cardinalDirectionList), typeof(cardinalDirection))]
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
		private decimal? _distance  = default;

		public decimal? distance {
			get {
				return _distance;
			}
			set {
				SetValue(ref _distance, value);
			}
		}
		[Category("bearingInformation")]
		public ObservableCollection<decimal> sectorBearing  { get; set; } = new ();
		[Category("bearingInformation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private orientationViewModel? _orientation  = default;

		[Category("bearingInformation")]
		[ExpandableObject]
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
	public partial class contactAddressViewModel : ViewModelBase {
		[Category("contactAddress")]
		public ObservableCollection<String> deliveryPoint  { get; set; } = new ();
		private String? _cityName  = default;

		public String? cityName {
			get {
				return _cityName;
			}
			set {
				SetValue(ref _cityName, value);
			}
		}
		private String? _administrativeDivision  = default;

		public String? administrativeDivision {
			get {
				return _administrativeDivision;
			}
			set {
				SetValue(ref _administrativeDivision, value);
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
			deliveryPoint.Clear();
			if (instance.deliveryPoint is not null) {
				foreach(var e in instance.deliveryPoint)
					deliveryPoint.Add(e);
			}
			cityName = instance.cityName;
			administrativeDivision = instance.administrativeDivision;
			countryName = instance.countryName;
			postalCode = instance.postalCode;
			return this;
		}

		public override string Serialize() {
			var instance = new contactAddress {
				deliveryPoint = this.deliveryPoint.ToList(),
				cityName = this.cityName,
				administrativeDivision = this.administrativeDivision,
				countryName = this.countryName,
				postalCode = this.postalCode,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public contactAddress Model => new () {
			deliveryPoint = this.deliveryPoint.ToList(),
			cityName = this._cityName,
			administrativeDivision = this._administrativeDivision,
			countryName = this._countryName,
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
	/// Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.
	/// </summary>
	[CategoryOrder("featureName",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class featureNameViewModel : ViewModelBase {
		private Boolean? _displayName  = default;

		public Boolean? displayName {
			get {
				return _displayName;
			}
			set {
				SetValue(ref _displayName, value);
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
		private String _name  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
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
	public partial class fixedDateRangeViewModel : ViewModelBase {
		private String? _dateEnd  = default;

		public String? dateEnd {
			get {
				return _dateEnd;
			}
			set {
				SetValue(ref _dateEnd, value);
			}
		}
		private String? _dateStart  = default;

		public String? dateStart {
			get {
				return _dateStart;
			}
			set {
				SetValue(ref _dateStart, value);
			}
		}


		public fixedDateRangeViewModel Load(fixedDateRange instance) {
			dateEnd = instance.dateEnd;
			dateStart = instance.dateStart;
			return this;
		}

		public override string Serialize() {
			var instance = new fixedDateRange {
				dateEnd = this.dateEnd,
				dateStart = this.dateStart,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public fixedDateRange Model => new () {
			dateEnd = this._dateEnd,
			dateStart = this._dateStart,
		};

		public override string? ToString() => $"Fixed Date Range";
	}
	/// <summary>
	/// A pair of frequencies for transmitting and receiving radio signals. The shore station transmits and receives on the frequencies indicated.
	/// </summary>
	[CategoryOrder("frequencyPair",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class frequencyPairViewModel : ViewModelBase {
		[Category("frequencyPair")]
		public ObservableCollection<int> frequencyShoreStationTransmits  { get; set; } = new ();
		[Category("frequencyPair")]
		public ObservableCollection<int> frequencyShoreStationReceives  { get; set; } = new ();
		[Category("frequencyPair")]
		public ObservableCollection<String> contactInstructions  { get; set; } = new ();


		public frequencyPairViewModel Load(frequencyPair instance) {
			frequencyShoreStationTransmits.Clear();
			if (instance.frequencyShoreStationTransmits is not null) {
				foreach(var e in instance.frequencyShoreStationTransmits)
					frequencyShoreStationTransmits.Add(e);
			}
			frequencyShoreStationReceives.Clear();
			if (instance.frequencyShoreStationReceives is not null) {
				foreach(var e in instance.frequencyShoreStationReceives)
					frequencyShoreStationReceives.Add(e);
			}
			contactInstructions.Clear();
			if (instance.contactInstructions is not null) {
				foreach(var e in instance.contactInstructions)
					contactInstructions.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new frequencyPair {
				frequencyShoreStationTransmits = this.frequencyShoreStationTransmits.ToList(),
				frequencyShoreStationReceives = this.frequencyShoreStationReceives.ToList(),
				contactInstructions = this.contactInstructions.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public frequencyPair Model => new () {
			frequencyShoreStationTransmits = this.frequencyShoreStationTransmits.ToList(),
			frequencyShoreStationReceives = this.frequencyShoreStationReceives.ToList(),
			contactInstructions = this.contactInstructions.ToList(),
		};

		public override string? ToString() => $"Frequency Pair";

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
	}
	/// <summary>
	/// Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.
	/// </summary>
	[CategoryOrder("graphic",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class graphicViewModel : ViewModelBase {
		[Category("graphic")]
		public ObservableCollection<String> pictorialRepresentation  { get; set; } = new ();
		private String? _pictureCaption  = default;

		public String? pictureCaption {
			get {
				return _pictureCaption;
			}
			set {
				SetValue(ref _pictureCaption, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _pictureInformation  = default;

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
	[CategoryOrder("horizontalPositionUncertainty",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class horizontalPositionUncertaintyViewModel : ViewModelBase {
		private decimal _uncertaintyFixed  = default;

		[Editor(typeof(Editors.UnknownEditor<decimal?>), typeof(Editors.UnknownEditor<decimal?>))]
		public decimal uncertaintyFixed {
			get {
				return _uncertaintyFixed;
			}
			set {
				SetValue(ref _uncertaintyFixed, value);
			}
		}


		public horizontalPositionUncertaintyViewModel Load(horizontalPositionUncertainty instance) {
			uncertaintyFixed = instance.uncertaintyFixed;
			return this;
		}

		public override string Serialize() {
			var instance = new horizontalPositionUncertainty {
				uncertaintyFixed = this.uncertaintyFixed,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public horizontalPositionUncertainty Model => new () {
			uncertaintyFixed = this._uncertaintyFixed,
		};

		public override string? ToString() => $"Horizontal Position Uncertainty";
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
		private String? _text  = default;

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
	/// Span of time, prior to the time the service is needed, for preparations to be made to fulfill the requirement.
	/// </summary>
	[CategoryOrder("noticeTime",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class noticeTimeViewModel : ViewModelBase {
		[Category("noticeTime")]
		public ObservableCollection<decimal> noticeTimeHours  { get; set; } = new ();
		private String? _noticeTimeText  = default;

		public String? noticeTimeText {
			get {
				return _noticeTimeText;
			}
			set {
				SetValue(ref _noticeTimeText, value);
			}
		}
		private operation? _operation  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(operationList), typeof(operation))]
		public operation? operation {
			get {
				return _operation;
			}
			set {
				SetValue(ref _operation, value);
			}
		}

		[Browsable(false)]
		public operation[] operationList => [(operation)1,(operation)2];


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
	[CategoryOrder("onlineResource",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class onlineResourceViewModel : ViewModelBase {
		private String _linkage  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String linkage {
			get {
				return _linkage;
			}
			set {
				SetValue(ref _linkage, value);
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
		private String? _applicationProfile  = default;

		public String? applicationProfile {
			get {
				return _applicationProfile;
			}
			set {
				SetValue(ref _applicationProfile, value);
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
		private String? _onlineResourceDescription  = default;

		public String? onlineResourceDescription {
			get {
				return _onlineResourceDescription;
			}
			set {
				SetValue(ref _onlineResourceDescription, value);
			}
		}
		private onlineFunction? _onlineFunction  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(onlineFunctionList), typeof(onlineFunction))]
		public onlineFunction? onlineFunction {
			get {
				return _onlineFunction;
			}
			set {
				SetValue(ref _onlineFunction, value);
			}
		}

		[Browsable(false)]
		public onlineFunction[] onlineFunctionList => [(onlineFunction)1,(onlineFunction)2,(onlineFunction)3,(onlineFunction)4,(onlineFunction)5,(onlineFunction)6,(onlineFunction)7,(onlineFunction)8,(onlineFunction)9,(onlineFunction)10,(onlineFunction)11];
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
	[CategoryOrder("orientation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class orientationViewModel : ViewModelBase {
		private decimal? _orientationUncertainty  = default;

		public decimal? orientationUncertainty {
			get {
				return _orientationUncertainty;
			}
			set {
				SetValue(ref _orientationUncertainty, value);
			}
		}
		private decimal _orientationValue  = default;

		[Editor(typeof(Editors.UnknownEditor<decimal?>), typeof(Editors.UnknownEditor<decimal?>))]
		public decimal orientationValue {
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
	/// The nature and timings of a daily schedule by days of the week.
	/// </summary>
	[CategoryOrder("scheduleByDayOfWeek",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class scheduleByDayOfWeekViewModel : ViewModelBase {
		private categoryOfSchedule? _categoryOfSchedule  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfScheduleList), typeof(categoryOfSchedule))]
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
	/// The active period of a recurring event or occurrence.
	/// </summary>
	[CategoryOrder("periodicDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class periodicDateRangeViewModel : ViewModelBase {
		private String _dateEnd  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String dateEnd {
			get {
				return _dateEnd;
			}
			set {
				SetValue(ref _dateEnd, value);
			}
		}
		private String _dateStart  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
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
	/// Detailed radiocommunications description with channels, frequencies, preferences and time schedules.
	/// </summary>
	[CategoryOrder("radiocommunications",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class radiocommunicationsViewModel : ViewModelBase {
		private categoryOfCommunicationPreference? _categoryOfCommunicationPreference  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfCommunicationPreferenceList), typeof(categoryOfCommunicationPreference))]
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
		[Category("radiocommunications")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfMaritimeBroadcastList), typeof(categoryOfMaritimeBroadcast))]
		public ObservableCollection<categoryOfMaritimeBroadcast> categoryOfMaritimeBroadcast  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfMaritimeBroadcast[] categoryOfMaritimeBroadcastList => [(categoryOfMaritimeBroadcast)1,(categoryOfMaritimeBroadcast)2,(categoryOfMaritimeBroadcast)3,(categoryOfMaritimeBroadcast)4,(categoryOfMaritimeBroadcast)5,(categoryOfMaritimeBroadcast)6,(categoryOfMaritimeBroadcast)7,(categoryOfMaritimeBroadcast)8,(categoryOfMaritimeBroadcast)9,(categoryOfMaritimeBroadcast)10,(categoryOfMaritimeBroadcast)11,(categoryOfMaritimeBroadcast)12,(categoryOfMaritimeBroadcast)13,(categoryOfMaritimeBroadcast)14,(categoryOfMaritimeBroadcast)15,(categoryOfMaritimeBroadcast)16,(categoryOfMaritimeBroadcast)17,(categoryOfMaritimeBroadcast)18,(categoryOfMaritimeBroadcast)19];
		[Category("radiocommunications")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfRadioMethodsList), typeof(categoryOfRadioMethods))]
		public ObservableCollection<categoryOfRadioMethods> categoryOfRadioMethods  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfRadioMethods[] categoryOfRadioMethodsList => [(categoryOfRadioMethods)1,(categoryOfRadioMethods)2,(categoryOfRadioMethods)3,(categoryOfRadioMethods)4,(categoryOfRadioMethods)5,(categoryOfRadioMethods)6,(categoryOfRadioMethods)7,(categoryOfRadioMethods)8,(categoryOfRadioMethods)9,(categoryOfRadioMethods)10,(categoryOfRadioMethods)11,(categoryOfRadioMethods)12,(categoryOfRadioMethods)13,(categoryOfRadioMethods)14,(categoryOfRadioMethods)15,(categoryOfRadioMethods)16,(categoryOfRadioMethods)17,(categoryOfRadioMethods)18,(categoryOfRadioMethods)19,(categoryOfRadioMethods)20];
		[Category("radiocommunications")]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();
		private String? _contactInstructions  = default;

		public String? contactInstructions {
			get {
				return _contactInstructions;
			}
			set {
				SetValue(ref _contactInstructions, value);
			}
		}
		[Category("radiocommunications")]
		public ObservableCollection<frequencyPairViewModel> frequencyPair  { get; set; } = new ();
		[Category("radiocommunications")]
		public ObservableCollection<int> signalFrequency  { get; set; } = new ();
		private String? _transmissionContent  = default;

		public String? transmissionContent {
			get {
				return _transmissionContent;
			}
			set {
				SetValue(ref _transmissionContent, value);
			}
		}
		[Category("radiocommunications")]
		public ObservableCollection<timeIntervalsByDayOfWeekViewModel> timeIntervalsByDayOfWeek  { get; set; } = new ();


		public radiocommunicationsViewModel Load(radiocommunications instance) {
			categoryOfCommunicationPreference = instance.categoryOfCommunicationPreference;
			categoryOfMaritimeBroadcast.Clear();
			if (instance.categoryOfMaritimeBroadcast is not null) {
				foreach(var e in instance.categoryOfMaritimeBroadcast)
					categoryOfMaritimeBroadcast.Add(e);
			}
			categoryOfRadioMethods.Clear();
			if (instance.categoryOfRadioMethods is not null) {
				foreach(var e in instance.categoryOfRadioMethods)
					categoryOfRadioMethods.Add(e);
			}
			communicationChannel.Clear();
			if (instance.communicationChannel is not null) {
				foreach(var e in instance.communicationChannel)
					communicationChannel.Add(e);
			}
			contactInstructions = instance.contactInstructions;
			frequencyPair.Clear();
			if (instance.frequencyPair is not null) {
				foreach(var e in instance.frequencyPair)
					frequencyPair.Add(new frequencyPairViewModel().Load(e));
			}
			signalFrequency.Clear();
			if (instance.signalFrequency is not null) {
				foreach(var e in instance.signalFrequency)
					signalFrequency.Add(e);
			}
			transmissionContent = instance.transmissionContent;
			timeIntervalsByDayOfWeek.Clear();
			if (instance.timeIntervalsByDayOfWeek is not null) {
				foreach(var e in instance.timeIntervalsByDayOfWeek)
					timeIntervalsByDayOfWeek.Add(new timeIntervalsByDayOfWeekViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new radiocommunications {
				categoryOfCommunicationPreference = this.categoryOfCommunicationPreference,
				categoryOfMaritimeBroadcast = this.categoryOfMaritimeBroadcast.ToList(),
				categoryOfRadioMethods = this.categoryOfRadioMethods.ToList(),
				communicationChannel = this.communicationChannel.ToList(),
				contactInstructions = this.contactInstructions,
				frequencyPair = this.frequencyPair.Select(e => e.Model).ToList(),
				signalFrequency = this.signalFrequency.ToList(),
				transmissionContent = this.transmissionContent,
				timeIntervalsByDayOfWeek = this.timeIntervalsByDayOfWeek.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public radiocommunications Model => new () {
			categoryOfCommunicationPreference = this._categoryOfCommunicationPreference,
			categoryOfMaritimeBroadcast = this.categoryOfMaritimeBroadcast.ToList(),
			categoryOfRadioMethods = this.categoryOfRadioMethods.ToList(),
			communicationChannel = this.communicationChannel.ToList(),
			contactInstructions = this._contactInstructions,
			frequencyPair = this.frequencyPair.Select(e => e.Model).ToList(),
			signalFrequency = this.signalFrequency.ToList(),
			transmissionContent = this._transmissionContent,
			timeIntervalsByDayOfWeek = this.timeIntervalsByDayOfWeek.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"Radiocommunications";

		public radiocommunicationsViewModel() : base() {
			categoryOfMaritimeBroadcast.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfMaritimeBroadcast));
			};
			categoryOfRadioMethods.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfRadioMethods));
			};
			communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(communicationChannel));
			};
			frequencyPair.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(frequencyPair));
			};
			signalFrequency.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(signalFrequency));
			};
			timeIntervalsByDayOfWeek.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(timeIntervalsByDayOfWeek));
			};
		}
	}
	/// <summary>
	/// A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.
	/// </summary>
	[CategoryOrder("rxNCode",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class rxNCodeViewModel : ViewModelBase {
		private categoryOfRxN? _categoryOfRxN  = default;

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
		public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)1,(categoryOfAuthority)2,(categoryOfAuthority)3,(categoryOfAuthority)4,(categoryOfAuthority)5,(categoryOfAuthority)6,(categoryOfAuthority)7,(categoryOfAuthority)8,(categoryOfAuthority)9,(categoryOfAuthority)10,(categoryOfAuthority)11,(categoryOfAuthority)12,(categoryOfAuthority)13,(categoryOfAuthority)14,(categoryOfAuthority)15];
		private String? _countryName  = default;

		public String? countryName {
			get {
				return _countryName;
			}
			set {
				SetValue(ref _countryName, value);
			}
		}
		private String? _reportedDate  = default;

		public String? reportedDate {
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
		public sourceType[] sourceTypeList => [(sourceType)1,(sourceType)2,(sourceType)7,(sourceType)8,(sourceType)9,(sourceType)10,(sourceType)11,(sourceType)12,(sourceType)13,(sourceType)14];
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
	/// The complex attribute describes the period of the hydrographic survey, as the time between its sub-attributes.
	/// </summary>
	[CategoryOrder("surveyDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class surveyDateRangeViewModel : ViewModelBase {
		private String _dateEnd  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String dateEnd {
			get {
				return _dateEnd;
			}
			set {
				SetValue(ref _dateEnd, value);
			}
		}
		private String? _dateStart  = default;

		public String? dateStart {
			get {
				return _dateStart;
			}
			set {
				SetValue(ref _dateStart, value);
			}
		}


		public surveyDateRangeViewModel Load(surveyDateRange instance) {
			dateEnd = instance.dateEnd;
			dateStart = instance.dateStart;
			return this;
		}

		public override string Serialize() {
			var instance = new surveyDateRange {
				dateEnd = this.dateEnd,
				dateStart = this.dateStart,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public surveyDateRange Model => new () {
			dateEnd = this._dateEnd,
			dateStart = this._dateStart,
		};

		public override string? ToString() => $"Survey Date Range";
	}
	/// <summary>
	/// A means or channel of communicating at a distance by electrical or electromagnetic means such as telegraphy, telephony, or broadcasting.
	/// </summary>
	[CategoryOrder("telecommunications",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class telecommunicationsViewModel : ViewModelBase {
		private categoryOfCommunicationPreference? _categoryOfCommunicationPreference  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfCommunicationPreferenceList), typeof(categoryOfCommunicationPreference))]
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

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String telecommunicationIdentifier {
			get {
				return _telecommunicationIdentifier;
			}
			set {
				SetValue(ref _telecommunicationIdentifier, value);
			}
		}
		private String? _telecommunicationCarrier  = default;

		public String? telecommunicationCarrier {
			get {
				return _telecommunicationCarrier;
			}
			set {
				SetValue(ref _telecommunicationCarrier, value);
			}
		}
		private String? _contactInstructions  = default;

		public String? contactInstructions {
			get {
				return _contactInstructions;
			}
			set {
				SetValue(ref _contactInstructions, value);
			}
		}
		[Category("telecommunications")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(telecommunicationServiceList), typeof(telecommunicationService))]
		public ObservableCollection<telecommunicationService> telecommunicationService  { get; set; } = new ();

		[Browsable(false)]
		public telecommunicationService[] telecommunicationServiceList => [(telecommunicationService)1,(telecommunicationService)2,(telecommunicationService)3,(telecommunicationService)4,(telecommunicationService)5,(telecommunicationService)6,(telecommunicationService)7,(telecommunicationService)8];
		private scheduleByDayOfWeekViewModel? _scheduleByDayOfWeek  = default;

		[Category("telecommunications")]
		[ExpandableObject]
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
			telecommunicationIdentifier = instance.telecommunicationIdentifier;
			telecommunicationCarrier = instance.telecommunicationCarrier;
			contactInstructions = instance.contactInstructions;
			telecommunicationService.Clear();
			if (instance.telecommunicationService is not null) {
				foreach(var e in instance.telecommunicationService)
					telecommunicationService.Add(e);
			}
			scheduleByDayOfWeek = new ();
			if (instance.scheduleByDayOfWeek != default) {
				scheduleByDayOfWeek.Load(instance.scheduleByDayOfWeek);
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
				scheduleByDayOfWeek = this.scheduleByDayOfWeek?.Model,
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
			scheduleByDayOfWeek = this._scheduleByDayOfWeek?.Model,
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
	[CategoryOrder("textContent",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class textContentViewModel : ViewModelBase {
		private categoryOfText? _categoryOfText  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfTextList), typeof(categoryOfText))]
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
		[Category("textContent")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private onlineResourceViewModel? _onlineResource  = default;

		[Category("textContent")]
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

		[Category("textContent")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}


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
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new textContent {
				categoryOfText = this.categoryOfText,
				information = this.information.Select(e => e.Model).ToList(),
				onlineResource = this.onlineResource?.Model,
				sourceIndication = this.sourceIndication?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public textContent Model => new () {
			categoryOfText = this._categoryOfText,
			information = this.information.Select(e => e.Model).ToList(),
			onlineResource = this._onlineResource?.Model,
			sourceIndication = this._sourceIndication?.Model,
		};

		public override string? ToString() => $"Text Content";

		public textContentViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}
	/// <summary>
	/// The regular weekly operation times of a service or schedule.
	/// </summary>
	[CategoryOrder("timeIntervalsByDayOfWeek",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class timeIntervalsByDayOfWeekViewModel : ViewModelBase {
		[Category("timeIntervalsByDayOfWeek")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(dayOfWeekList), typeof(dayOfWeek))]
		public ObservableCollection<dayOfWeek> dayOfWeek  { get; set; } = new ();

		[Browsable(false)]
		public dayOfWeek[] dayOfWeekList => [(dayOfWeek)1,(dayOfWeek)2,(dayOfWeek)3,(dayOfWeek)4,(dayOfWeek)5,(dayOfWeek)6,(dayOfWeek)7];
		private Boolean? _dayOfWeekIsRange  = default;

		public Boolean? dayOfWeekIsRange {
			get {
				return _dayOfWeekIsRange;
			}
			set {
				SetValue(ref _dayOfWeekIsRange, value);
			}
		}
		[Category("timeIntervalsByDayOfWeek")]
		public ObservableCollection<TimeOnly> timeOfDayStart  { get; set; } = new ();
		[Category("timeIntervalsByDayOfWeek")]
		public ObservableCollection<TimeOnly> timeOfDayEnd  { get; set; } = new ();


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
	[CategoryOrder("underKeelAllowance",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class underKeelAllowanceViewModel : ViewModelBase {
		private decimal? _underKeelAllowanceFixed  = default;

		public decimal? underKeelAllowanceFixed {
			get {
				return _underKeelAllowanceFixed;
			}
			set {
				SetValue(ref _underKeelAllowanceFixed, value);
			}
		}
		private decimal? _underKeelAllowanceVariableBeamBased  = default;

		public decimal? underKeelAllowanceVariableBeamBased {
			get {
				return _underKeelAllowanceVariableBeamBased;
			}
			set {
				SetValue(ref _underKeelAllowanceVariableBeamBased, value);
			}
		}
		private decimal? _underKeelAllowanceVariableDraughtBased  = default;

		public decimal? underKeelAllowanceVariableDraughtBased {
			get {
				return _underKeelAllowanceVariableDraughtBased;
			}
			set {
				SetValue(ref _underKeelAllowanceVariableDraughtBased, value);
			}
		}
		private operation? _operation  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(operationList), typeof(operation))]
		public operation? operation {
			get {
				return _operation;
			}
			set {
				SetValue(ref _operation, value);
			}
		}

		[Browsable(false)]
		public operation[] operationList => [(operation)1,(operation)2];


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
	/// Values, discovered by measuring, that correspond to vessels characteristics.
	/// </summary>
	[CategoryOrder("vesselsMeasurements",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class vesselsMeasurementsViewModel : ViewModelBase {
		private comparisonOperator _comparisonOperator  = default;

		[Editor(typeof(Editors.UnknownEditor<comparisonOperator?>), typeof(Editors.UnknownEditor<comparisonOperator?>))]
		[DomainModel.EnumerationAttribute(nameof(comparisonOperatorList), typeof(comparisonOperator))]
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

		[Editor(typeof(Editors.UnknownEditor<vesselsCharacteristics?>), typeof(Editors.UnknownEditor<vesselsCharacteristics?>))]
		[DomainModel.EnumerationAttribute(nameof(vesselsCharacteristicsList), typeof(vesselsCharacteristics))]
		public vesselsCharacteristics vesselsCharacteristics {
			get {
				return _vesselsCharacteristics;
			}
			set {
				SetValue(ref _vesselsCharacteristics, value);
			}
		}

		[Browsable(false)]
		public vesselsCharacteristics[] vesselsCharacteristicsList => [(vesselsCharacteristics)1,(vesselsCharacteristics)2,(vesselsCharacteristics)3,(vesselsCharacteristics)4,(vesselsCharacteristics)5,(vesselsCharacteristics)6,(vesselsCharacteristics)7,(vesselsCharacteristics)8,(vesselsCharacteristics)9,(vesselsCharacteristics)10,(vesselsCharacteristics)11,(vesselsCharacteristics)12,(vesselsCharacteristics)13,(vesselsCharacteristics)14];
		private decimal _vesselsCharacteristicsValue  = default;

		[Editor(typeof(Editors.UnknownEditor<decimal?>), typeof(Editors.UnknownEditor<decimal?>))]
		public decimal vesselsCharacteristicsValue {
			get {
				return _vesselsCharacteristicsValue;
			}
			set {
				SetValue(ref _vesselsCharacteristicsValue, value);
			}
		}
		private vesselsCharacteristicsUnit _vesselsCharacteristicsUnit  = default;

		[Editor(typeof(Editors.UnknownEditor<vesselsCharacteristicsUnit?>), typeof(Editors.UnknownEditor<vesselsCharacteristicsUnit?>))]
		[DomainModel.EnumerationAttribute(nameof(vesselsCharacteristicsUnitList), typeof(vesselsCharacteristicsUnit))]
		public vesselsCharacteristicsUnit vesselsCharacteristicsUnit {
			get {
				return _vesselsCharacteristicsUnit;
			}
			set {
				SetValue(ref _vesselsCharacteristicsUnit, value);
			}
		}

		[Browsable(false)]
		public vesselsCharacteristicsUnit[] vesselsCharacteristicsUnitList => [(vesselsCharacteristicsUnit)1,(vesselsCharacteristicsUnit)2,(vesselsCharacteristicsUnit)3,(vesselsCharacteristicsUnit)4,(vesselsCharacteristicsUnit)5,(vesselsCharacteristicsUnit)6,(vesselsCharacteristicsUnit)7,(vesselsCharacteristicsUnit)8,(vesselsCharacteristicsUnit)9,(vesselsCharacteristicsUnit)10,(vesselsCharacteristicsUnit)11,(vesselsCharacteristicsUnit)12];


		public vesselsMeasurementsViewModel Load(vesselsMeasurements instance) {
			comparisonOperator = instance.comparisonOperator;
			vesselsCharacteristics = instance.vesselsCharacteristics;
			vesselsCharacteristicsValue = instance.vesselsCharacteristicsValue;
			vesselsCharacteristicsUnit = instance.vesselsCharacteristicsUnit;
			return this;
		}

		public override string Serialize() {
			var instance = new vesselsMeasurements {
				comparisonOperator = this.comparisonOperator,
				vesselsCharacteristics = this.vesselsCharacteristics,
				vesselsCharacteristicsValue = this.vesselsCharacteristicsValue,
				vesselsCharacteristicsUnit = this.vesselsCharacteristicsUnit,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public vesselsMeasurements Model => new () {
			comparisonOperator = this._comparisonOperator,
			vesselsCharacteristics = this._vesselsCharacteristics,
			vesselsCharacteristicsValue = this._vesselsCharacteristicsValue,
			vesselsCharacteristicsUnit = this._vesselsCharacteristicsUnit,
		};

		public override string? ToString() => $"Vessels Measurements";
	}

	/// <summary>
	/// A feature association for the binding between at least one instance of a geo feature and an instance of an information type.
	/// </summary>
	[CategoryOrder("AdditionalInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AdditionalInformationViewModel : AssociationViewModel {


		public AdditionalInformationViewModel Load(AdditionalInformation instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new AdditionalInformation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AdditionalInformation Model => new () {

		};

		public override string? ToString() => $"Additional Information";
	}

	/// <summary>
	/// Contact information for an authority
	/// </summary>
	[CategoryOrder("AuthorityContact",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AuthorityContactViewModel : AssociationViewModel {


		public AuthorityContactViewModel Load(AuthorityContact instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new AuthorityContact {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AuthorityContact Model => new () {

		};

		public override string? ToString() => $"Authority Contact";
	}

	/// <summary>
	/// Service hours for an authority
	/// </summary>
	[CategoryOrder("AuthorityHours",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AuthorityHoursViewModel : AssociationViewModel {


		public AuthorityHoursViewModel Load(AuthorityHours instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new AuthorityHours {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AuthorityHours Model => new () {

		};

		public override string? ToString() => $"Authority Hours";
	}

	/// <summary>
	/// Association between a geographic location and a regulation, restriction, recommendation, or nautical information
	/// </summary>
	[CategoryOrder("AssociatedRxN",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AssociatedRxNViewModel : AssociationViewModel {


		public AssociatedRxNViewModel Load(AssociatedRxN instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new AssociatedRxN {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AssociatedRxN Model => new () {

		};

		public override string? ToString() => $"Associated RxN";
	}

	/// <summary>
	/// Exception to the usual working day
	/// </summary>
	[CategoryOrder("ExceptionalWorkday",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ExceptionalWorkdayViewModel : AssociationViewModel {


		public ExceptionalWorkdayViewModel Load(ExceptionalWorkday instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new ExceptionalWorkday {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ExceptionalWorkday Model => new () {

		};

		public override string? ToString() => $"Exceptional Workday";
	}

	/// <summary>
	/// Association class specifying the relationship between the subset of vessels described by an APPLIC data object and a regulation (restriction, recommendation, or nautical information).
	/// </summary>
	[CategoryOrder("InclusionType",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class InclusionTypeViewModel : AssociationViewModel {
		private membership _membership  = default;

		[Category("InclusionType")]
		[Editor(typeof(Editors.UnknownEditor<membership?>), typeof(Editors.UnknownEditor<membership?>))]
		[DomainModel.EnumerationAttribute(nameof(membershipList), typeof(membership))]
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


		public InclusionTypeViewModel Load(InclusionType instance) {
			membership = instance.membership;
			return this;
		}

		public override string Serialize() {
			var instance = new InclusionType {
				membership = this.membership,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public InclusionType Model => new () {
			membership = this._membership,
		};

		public override string? ToString() => $"Inclusion Type";
	}

	/// <summary>
	/// Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit,  enter, or use  a feature.
	/// </summary>
	[CategoryOrder("PermissionType",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PermissionTypeViewModel : AssociationViewModel {
		private categoryOfRelationship _categoryOfRelationship  = default;

		[Category("PermissionType")]
		[Editor(typeof(Editors.UnknownEditor<categoryOfRelationship?>), typeof(Editors.UnknownEditor<categoryOfRelationship?>))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfRelationshipList), typeof(categoryOfRelationship))]
		public categoryOfRelationship categoryOfRelationship {
			get {
				return _categoryOfRelationship;
			}
			set {
				SetValue(ref _categoryOfRelationship, value);
			}
		}

		[Browsable(false)]
		public categoryOfRelationship[] categoryOfRelationshipList => [(categoryOfRelationship)1,(categoryOfRelationship)2,(categoryOfRelationship)3,(categoryOfRelationship)4,(categoryOfRelationship)5,(categoryOfRelationship)6];


		public PermissionTypeViewModel Load(PermissionType instance) {
			categoryOfRelationship = instance.categoryOfRelationship;
			return this;
		}

		public override string Serialize() {
			var instance = new PermissionType {
				categoryOfRelationship = this.categoryOfRelationship,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PermissionType Model => new () {
			categoryOfRelationship = this._categoryOfRelationship,
		};

		public override string? ToString() => $"Permission Type";
	}

	/// <summary>
	/// Related organisation
	/// </summary>
	[CategoryOrder("RelatedOrganisation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RelatedOrganisationViewModel : AssociationViewModel {


		public RelatedOrganisationViewModel Load(RelatedOrganisation instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new RelatedOrganisation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RelatedOrganisation Model => new () {

		};

		public override string? ToString() => $"Related Organisation";
	}

	/// <summary>
	/// The authority with which a report must be filed
	/// </summary>
	[CategoryOrder("ReportingAuthority",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ReportingAuthorityViewModel : AssociationViewModel {


		public ReportingAuthorityViewModel Load(ReportingAuthority instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new ReportingAuthority {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ReportingAuthority Model => new () {

		};

		public override string? ToString() => $"Reporting Authority";
	}

	/// <summary>
	/// Association between types of reports and classes of vessels which must file report of the type described
	/// </summary>
	[CategoryOrder("ReportingRequirement",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ReportingRequirementViewModel : AssociationViewModel {


		public ReportingRequirementViewModel Load(ReportingRequirement instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new ReportingRequirement {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ReportingRequirement Model => new () {

		};

		public override string? ToString() => $"Reporting Requirement";
	}

	/// <summary>
	/// Contact details for a service or facility
	/// </summary>
	[CategoryOrder("ServiceContact",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceContactViewModel : AssociationViewModel {


		public ServiceContactViewModel Load(ServiceContact instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new ServiceContact {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ServiceContact Model => new () {

		};

		public override string? ToString() => $"Service Contact";
	}

	/// <summary>
	/// Association between a geographically located service and the organisation that controls it
	/// </summary>
	[CategoryOrder("ServiceControl",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceControlViewModel : AssociationViewModel {


		public ServiceControlViewModel Load(ServiceControl instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new ServiceControl {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ServiceControl Model => new () {

		};

		public override string? ToString() => $"Service Control";
	}

	/// <summary>
	/// Association for linking spatial quality to spatial objects.
	/// </summary>
	[CategoryOrder("SpatialAssociation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SpatialAssociationViewModel : AssociationViewModel {


		public SpatialAssociationViewModel Load(SpatialAssociation instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new SpatialAssociation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SpatialAssociation Model => new () {

		};

		public override string? ToString() => $"Spatial Association";
	}

	/// <summary>
	/// Working hours for a service or facility described by a geographic location
	/// </summary>
	[CategoryOrder("LocationHours",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LocationHoursViewModel : AssociationViewModel {


		public LocationHoursViewModel Load(LocationHours instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new LocationHours {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LocationHours Model => new () {

		};

		public override string? ToString() => $"Location Hours";
	}

	/// <summary>
	/// Association between traffic control service and reports required of vessels pertaining to that area
	/// </summary>
	[CategoryOrder("TrafficServiceReport",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TrafficServiceReportViewModel : AssociationViewModel {


		public TrafficServiceReportViewModel Load(TrafficServiceReport instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new TrafficServiceReport {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public TrafficServiceReport Model => new () {

		};

		public override string? ToString() => $"Traffic Service Report";
	}

	/// <summary>
	/// Association linking the location from which a service is provided and the area(s) served.
	/// </summary>
	[CategoryOrder("ServiceProvisionArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceProvisionAreaViewModel : AssociationViewModel {


		public ServiceProvisionAreaViewModel Load(ServiceProvisionArea instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new ServiceProvisionArea {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ServiceProvisionArea Model => new () {

		};

		public override string? ToString() => $"Service provision area";
	}

	/// <summary>
	/// A feature association for the binding between a pilotage district and its component pilot boarding places.
	/// </summary>
	[CategoryOrder("PilotageDistrictAssociation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PilotageDistrictAssociationViewModel : AssociationViewModel {


		public PilotageDistrictAssociationViewModel Load(PilotageDistrictAssociation instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new PilotageDistrictAssociation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PilotageDistrictAssociation Model => new () {

		};

		public override string? ToString() => $"Pilotage District Association";
	}

	/// <summary>
	/// A feature association for the binding between a geo feature and the cartographically positioned location for text.
	/// </summary>
	[CategoryOrder("TextAssociation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TextAssociationViewModel : AssociationViewModel {


		public TextAssociationViewModel Load(TextAssociation instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new TextAssociation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public TextAssociation Model => new () {

		};

		public override string? ToString() => $"Text Association";
	}

	/// <summary>
	/// A feature association for the binding between a traffic control service and auxiliary features.
	/// </summary>
	[CategoryOrder("TrafficControlServiceAggregation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TrafficControlServiceAggregationViewModel : AssociationViewModel {


		public TrafficControlServiceAggregationViewModel Load(TrafficControlServiceAggregation instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new TrafficControlServiceAggregation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public TrafficControlServiceAggregation Model => new () {

		};

		public override string? ToString() => $"Traffic Control Service Aggregation";
	}

	/// <summary>
	/// Generalized information type which carries all the common attributes.
	/// </summary>
	[CategoryOrder("InformationType",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class InformationTypeViewModel : InformationViewModel<InformationType> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("InformationType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();


		public override InformationViewModel<InformationType> Load(InformationType instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new InformationType {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public InformationType Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => InformationType._informationBindingDefinitions;

		public override string? ToString() => $"Information Type";

		public InformationTypeViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
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
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("InformationType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Category("AbstractRxN")]
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
		public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)1,(categoryOfAuthority)2,(categoryOfAuthority)3,(categoryOfAuthority)4,(categoryOfAuthority)5,(categoryOfAuthority)6,(categoryOfAuthority)7,(categoryOfAuthority)8,(categoryOfAuthority)9,(categoryOfAuthority)10,(categoryOfAuthority)11,(categoryOfAuthority)12,(categoryOfAuthority)13,(categoryOfAuthority)14,(categoryOfAuthority)15];
		[Category("AbstractRxN")]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();
		[Category("AbstractRxN")]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();
		[Category("AbstractRxN")]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();


		public override InformationViewModel<AbstractRxN> Load(AbstractRxN instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
			categoryOfAuthority = instance.categoryOfAuthority;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				categoryOfAuthority = this.categoryOfAuthority,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AbstractRxN Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			categoryOfAuthority = this._categoryOfAuthority,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => AbstractRxN._informationBindingDefinitions;

		public override string? ToString() => $"AbstractRxN";

		public AbstractRxNViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
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
	/// Describes the relationship between vessel characteristics and: (i) the applicability of an associated information object or feature to the vessel; or, (ii) the use of a facility, place, or service by the vessel; or, (iii) passage of the vessel through an area.
	/// </summary>
	[CategoryOrder("Applicability",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ApplicabilityViewModel : InformationViewModel<Applicability> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("InformationType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		private Boolean? _inBallast  = default;

		[Category("Applicability")]
		public Boolean? inBallast {
			get {
				return _inBallast;
			}
			set {
				SetValue(ref _inBallast, value);
			}
		}
		[Category("Applicability")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfCargoList), typeof(categoryOfCargo))]
		public ObservableCollection<categoryOfCargo> categoryOfCargo  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfCargo[] categoryOfCargoList => [(categoryOfCargo)1,(categoryOfCargo)2,(categoryOfCargo)3,(categoryOfCargo)4,(categoryOfCargo)5,(categoryOfCargo)6,(categoryOfCargo)7,(categoryOfCargo)8,(categoryOfCargo)9];
		[Category("Applicability")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfDangerousOrHazardousCargoList), typeof(categoryOfDangerousOrHazardousCargo))]
		public ObservableCollection<categoryOfDangerousOrHazardousCargo> categoryOfDangerousOrHazardousCargo  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfDangerousOrHazardousCargo[] categoryOfDangerousOrHazardousCargoList => [(categoryOfDangerousOrHazardousCargo)1,(categoryOfDangerousOrHazardousCargo)2,(categoryOfDangerousOrHazardousCargo)3,(categoryOfDangerousOrHazardousCargo)4,(categoryOfDangerousOrHazardousCargo)5,(categoryOfDangerousOrHazardousCargo)6,(categoryOfDangerousOrHazardousCargo)7,(categoryOfDangerousOrHazardousCargo)8,(categoryOfDangerousOrHazardousCargo)9,(categoryOfDangerousOrHazardousCargo)10,(categoryOfDangerousOrHazardousCargo)11,(categoryOfDangerousOrHazardousCargo)12,(categoryOfDangerousOrHazardousCargo)13,(categoryOfDangerousOrHazardousCargo)14,(categoryOfDangerousOrHazardousCargo)15,(categoryOfDangerousOrHazardousCargo)16,(categoryOfDangerousOrHazardousCargo)17,(categoryOfDangerousOrHazardousCargo)18,(categoryOfDangerousOrHazardousCargo)19,(categoryOfDangerousOrHazardousCargo)20,(categoryOfDangerousOrHazardousCargo)21];
		private categoryOfVessel? _categoryOfVessel  = default;

		[Category("Applicability")]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfVesselRegistryList), typeof(categoryOfVesselRegistry))]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(logicalConnectivesList), typeof(logicalConnectives))]
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
		public String? vesselPerformance {
			get {
				return _vesselPerformance;
			}
			set {
				SetValue(ref _vesselPerformance, value);
			}
		}
		[Category("Applicability")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("Applicability")]
		public ObservableCollection<vesselsMeasurementsViewModel> vesselsMeasurements  { get; set; } = new ();


		public override InformationViewModel<Applicability> Load(Applicability instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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

		public override string? ToString() => $"Applicability";

		public ApplicabilityViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
			vesselsMeasurements.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(vesselsMeasurements));
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
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("InformationType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		private categoryOfAuthority _categoryOfAuthority  = default;

		[Category("Authority")]
		[Editor(typeof(Editors.UnknownEditor<categoryOfAuthority?>), typeof(Editors.UnknownEditor<categoryOfAuthority?>))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfAuthorityList), typeof(categoryOfAuthority))]
		public categoryOfAuthority categoryOfAuthority {
			get {
				return _categoryOfAuthority;
			}
			set {
				SetValue(ref _categoryOfAuthority, value);
			}
		}

		[Browsable(false)]
		public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)1,(categoryOfAuthority)2,(categoryOfAuthority)3,(categoryOfAuthority)4,(categoryOfAuthority)5,(categoryOfAuthority)6,(categoryOfAuthority)7,(categoryOfAuthority)8,(categoryOfAuthority)9,(categoryOfAuthority)10,(categoryOfAuthority)11,(categoryOfAuthority)12,(categoryOfAuthority)13,(categoryOfAuthority)14,(categoryOfAuthority)15];
		private textContentViewModel? _textContent  = default;

		[Category("Authority")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}


		public override InformationViewModel<Authority> Load(Authority instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				categoryOfAuthority = this.categoryOfAuthority,
				textContent = this.textContent?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Authority Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			categoryOfAuthority = this._categoryOfAuthority,
			textContent = this._textContent?.Model,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => Authority._informationBindingDefinitions;

		public override string? ToString() => $"Authority";

		public AuthorityViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
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
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("InformationType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		private String? _callName  = default;

		[Category("ContactDetails")]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfCommunicationPreferenceList), typeof(categoryOfCommunicationPreference))]
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
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();
		[Category("ContactDetails")]
		public ObservableCollection<contactAddressViewModel> contactAddress  { get; set; } = new ();
		private String? _contactInstructions  = default;

		[Category("ContactDetails")]
		public String? contactInstructions {
			get {
				return _contactInstructions;
			}
			set {
				SetValue(ref _contactInstructions, value);
			}
		}
		[Category("ContactDetails")]
		public ObservableCollection<frequencyPairViewModel> frequencyPair  { get; set; } = new ();
		[Category("ContactDetails")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private String? _language  = default;

		[Category("ContactDetails")]
		public String? language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}
		private String? _mMSICode  = default;

		[Category("ContactDetails")]
		public String? mMSICode {
			get {
				return _mMSICode;
			}
			set {
				SetValue(ref _mMSICode, value);
			}
		}
		[Category("ContactDetails")]
		public ObservableCollection<onlineResourceViewModel> onlineResource  { get; set; } = new ();
		[Category("ContactDetails")]
		public ObservableCollection<telecommunicationsViewModel> telecommunications  { get; set; } = new ();
		[Category("ContactDetails")]
		public ObservableCollection<radiocommunicationsViewModel> radiocommunications  { get; set; } = new ();


		public override InformationViewModel<ContactDetails> Load(ContactDetails instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
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
			contactAddress.Clear();
			if (instance.contactAddress is not null) {
				foreach(var e in instance.contactAddress)
					contactAddress.Add(new contactAddressViewModel().Load(e));
			}
			contactInstructions = instance.contactInstructions;
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
			language = instance.language;
			mMSICode = instance.mMSICode;
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
			radiocommunications.Clear();
			if (instance.radiocommunications is not null) {
				foreach(var e in instance.radiocommunications)
					radiocommunications.Add(new radiocommunicationsViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new ContactDetails {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				callName = this.callName,
				callSign = this.callSign,
				categoryOfCommunicationPreference = this.categoryOfCommunicationPreference,
				communicationChannel = this.communicationChannel.ToList(),
				contactAddress = this.contactAddress.Select(e => e.Model).ToList(),
				contactInstructions = this.contactInstructions,
				frequencyPair = this.frequencyPair.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				language = this.language,
				mMSICode = this.mMSICode,
				onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
				telecommunications = this.telecommunications.Select(e => e.Model).ToList(),
				radiocommunications = this.radiocommunications.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ContactDetails Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			callName = this._callName,
			callSign = this._callSign,
			categoryOfCommunicationPreference = this._categoryOfCommunicationPreference,
			communicationChannel = this.communicationChannel.ToList(),
			contactAddress = this.contactAddress.Select(e => e.Model).ToList(),
			contactInstructions = this._contactInstructions,
			frequencyPair = this.frequencyPair.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			language = this._language,
			mMSICode = this._mMSICode,
			onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
			telecommunications = this.telecommunications.Select(e => e.Model).ToList(),
			radiocommunications = this.radiocommunications.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => ContactDetails._informationBindingDefinitions;

		public override string? ToString() => $"Contact Details";

		public ContactDetailsViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(communicationChannel));
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
			radiocommunications.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(radiocommunications));
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
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("InformationType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Category("AbstractRxN")]
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
		public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)1,(categoryOfAuthority)2,(categoryOfAuthority)3,(categoryOfAuthority)4,(categoryOfAuthority)5,(categoryOfAuthority)6,(categoryOfAuthority)7,(categoryOfAuthority)8,(categoryOfAuthority)9,(categoryOfAuthority)10,(categoryOfAuthority)11,(categoryOfAuthority)12,(categoryOfAuthority)13,(categoryOfAuthority)14,(categoryOfAuthority)15];
		[Category("AbstractRxN")]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();
		[Category("AbstractRxN")]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();
		[Category("AbstractRxN")]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();



		public override InformationViewModel<NauticalInformation> Load(NauticalInformation instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
			categoryOfAuthority = instance.categoryOfAuthority;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				categoryOfAuthority = this.categoryOfAuthority,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public NauticalInformation Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			categoryOfAuthority = this._categoryOfAuthority,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => NauticalInformation._informationBindingDefinitions;

		public override string? ToString() => $"Nautical Information";

		public NauticalInformationViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
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
	/// Days when many services are not available. Often days of festivity or recreation or public holidays when normal working hours are limited, especially a national or religious festival, etc.
	/// </summary>
	[CategoryOrder("NonStandardWorkingDay",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NonStandardWorkingDayViewModel : InformationViewModel<NonStandardWorkingDay> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("InformationType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		[Category("NonStandardWorkingDay")]
		public ObservableCollection<String> dateFixed  { get; set; } = new ();
		[Category("NonStandardWorkingDay")]
		public ObservableCollection<String> dateVariable  { get; set; } = new ();
		[Category("NonStandardWorkingDay")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override InformationViewModel<NonStandardWorkingDay> Load(NonStandardWorkingDay instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				dateFixed = this.dateFixed.ToList(),
				dateVariable = this.dateVariable.ToList(),
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public NonStandardWorkingDay Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			dateFixed = this.dateFixed.ToList(),
			dateVariable = this.dateVariable.ToList(),
			information = this.information.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => NonStandardWorkingDay._informationBindingDefinitions;

		public override string? ToString() => $"Non-Standard Working Day";

		public NonStandardWorkingDayViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
	/// The time when a service is available and known exceptions.
	/// </summary>
	[CategoryOrder("ServiceHours",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceHoursViewModel : InformationViewModel<ServiceHours> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("InformationType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		[Category("ServiceHours")]
		public ObservableCollection<scheduleByDayOfWeekViewModel> scheduleByDayOfWeek  { get; set; } = new ();
		[Category("ServiceHours")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override InformationViewModel<ServiceHours> Load(ServiceHours instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				scheduleByDayOfWeek = this.scheduleByDayOfWeek.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ServiceHours Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			scheduleByDayOfWeek = this.scheduleByDayOfWeek.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => ServiceHours._informationBindingDefinitions;

		public override string? ToString() => $"Service Hours";

		public ServiceHoursViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
	[CategoryOrder("ShipReport",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ShipReportViewModel : InformationViewModel<ShipReport> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("InformationType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		[Category("ShipReport")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfShipReportList), typeof(categoryOfShipReport))]
		public ObservableCollection<categoryOfShipReport> categoryOfShipReport  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfShipReport[] categoryOfShipReportList => [(categoryOfShipReport)1,(categoryOfShipReport)2,(categoryOfShipReport)3,(categoryOfShipReport)4,(categoryOfShipReport)5,(categoryOfShipReport)6,(categoryOfShipReport)7,(categoryOfShipReport)8];
		private Boolean _iMOFormatForReporting  = false;

		[Category("ShipReport")]
		[Editor(typeof(Editors.UnknownEditor<Boolean?>), typeof(Editors.UnknownEditor<Boolean?>))]
		public Boolean iMOFormatForReporting {
			get {
				return _iMOFormatForReporting;
			}
			set {
				SetValue(ref _iMOFormatForReporting, value);
			}
		}
		[Category("ShipReport")]
		public ObservableCollection<noticeTimeViewModel> noticeTime  { get; set; } = new ();
		private textContentViewModel? _textContent  = default;

		[Category("ShipReport")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}


		public override InformationViewModel<ShipReport> Load(ShipReport instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				categoryOfShipReport = this.categoryOfShipReport.ToList(),
				iMOFormatForReporting = this.iMOFormatForReporting,
				noticeTime = this.noticeTime.Select(e => e.Model).ToList(),
				textContent = this.textContent?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ShipReport Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			categoryOfShipReport = this.categoryOfShipReport.ToList(),
			iMOFormatForReporting = this._iMOFormatForReporting,
			noticeTime = this.noticeTime.Select(e => e.Model).ToList(),
			textContent = this._textContent?.Model,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => ShipReport._informationBindingDefinitions;

		public override string? ToString() => $"Ship Report";

		public ShipReportViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			categoryOfShipReport.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfShipReport));
			};
			noticeTime.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(noticeTime));
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
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("InformationType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Category("AbstractRxN")]
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
		public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)1,(categoryOfAuthority)2,(categoryOfAuthority)3,(categoryOfAuthority)4,(categoryOfAuthority)5,(categoryOfAuthority)6,(categoryOfAuthority)7,(categoryOfAuthority)8,(categoryOfAuthority)9,(categoryOfAuthority)10,(categoryOfAuthority)11,(categoryOfAuthority)12,(categoryOfAuthority)13,(categoryOfAuthority)14,(categoryOfAuthority)15];
		[Category("AbstractRxN")]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();
		[Category("AbstractRxN")]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();
		[Category("AbstractRxN")]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();



		public override InformationViewModel<Recommendations> Load(Recommendations instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
			categoryOfAuthority = instance.categoryOfAuthority;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				categoryOfAuthority = this.categoryOfAuthority,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Recommendations Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			categoryOfAuthority = this._categoryOfAuthority,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => Recommendations._informationBindingDefinitions;

		public override string? ToString() => $"Recommendations";

		public RecommendationsViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
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
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("InformationType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Category("AbstractRxN")]
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
		public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)1,(categoryOfAuthority)2,(categoryOfAuthority)3,(categoryOfAuthority)4,(categoryOfAuthority)5,(categoryOfAuthority)6,(categoryOfAuthority)7,(categoryOfAuthority)8,(categoryOfAuthority)9,(categoryOfAuthority)10,(categoryOfAuthority)11,(categoryOfAuthority)12,(categoryOfAuthority)13,(categoryOfAuthority)14,(categoryOfAuthority)15];
		[Category("AbstractRxN")]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();
		[Category("AbstractRxN")]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();
		[Category("AbstractRxN")]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();



		public override InformationViewModel<Regulations> Load(Regulations instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
			categoryOfAuthority = instance.categoryOfAuthority;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				categoryOfAuthority = this.categoryOfAuthority,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Regulations Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			categoryOfAuthority = this._categoryOfAuthority,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => Regulations._informationBindingDefinitions;

		public override string? ToString() => $"Regulations";

		public RegulationsViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
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
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InformationType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("InformationType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("InformationType")]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		private categoryOfAuthority? _categoryOfAuthority  = default;

		[Category("AbstractRxN")]
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
		public categoryOfAuthority[] categoryOfAuthorityList => [(categoryOfAuthority)1,(categoryOfAuthority)2,(categoryOfAuthority)3,(categoryOfAuthority)4,(categoryOfAuthority)5,(categoryOfAuthority)6,(categoryOfAuthority)7,(categoryOfAuthority)8,(categoryOfAuthority)9,(categoryOfAuthority)10,(categoryOfAuthority)11,(categoryOfAuthority)12,(categoryOfAuthority)13,(categoryOfAuthority)14,(categoryOfAuthority)15];
		[Category("AbstractRxN")]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();
		[Category("AbstractRxN")]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();
		[Category("AbstractRxN")]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();



		public override InformationViewModel<Restrictions> Load(Restrictions instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication.Clear();
			if (instance.sourceIndication is not null) {
				foreach(var e in instance.sourceIndication)
					sourceIndication.Add(new sourceIndicationViewModel().Load(e));
			}
			categoryOfAuthority = instance.categoryOfAuthority;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				categoryOfAuthority = this.categoryOfAuthority,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Restrictions Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			categoryOfAuthority = this._categoryOfAuthority,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => Restrictions._informationBindingDefinitions;

		public override string? ToString() => $"Restrictions";

		public RestrictionsViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
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
	/// The indication of the quality of the locational information for features in a dataset.
	/// </summary>
	[CategoryOrder("SpatialQuality",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SpatialQualityViewModel : InformationViewModel<SpatialQuality> {
		private categoryOfTemporalVariation? _categoryOfTemporalVariation  = default;

		[Category("SpatialQuality")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfTemporalVariationList), typeof(categoryOfTemporalVariation))]
		public categoryOfTemporalVariation? categoryOfTemporalVariation {
			get {
				return _categoryOfTemporalVariation;
			}
			set {
				SetValue(ref _categoryOfTemporalVariation, value);
			}
		}

		[Browsable(false)]
		public categoryOfTemporalVariation[] categoryOfTemporalVariationList => [(categoryOfTemporalVariation)1,(categoryOfTemporalVariation)4,(categoryOfTemporalVariation)5];
		private qualityOfHorizontalMeasurement? _qualityOfHorizontalMeasurement  = default;

		[Category("SpatialQuality")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(qualityOfHorizontalMeasurementList), typeof(qualityOfHorizontalMeasurement))]
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
		private horizontalPositionUncertaintyViewModel? _horizontalPositionUncertainty  = default;

		[Category("SpatialQuality")]
		[ExpandableObject]
		public horizontalPositionUncertaintyViewModel? horizontalPositionUncertainty {
			get {
				return _horizontalPositionUncertainty;
			}
			set {
				SetValue(ref _horizontalPositionUncertainty, value);
			}
		}


		public override InformationViewModel<SpatialQuality> Load(SpatialQuality instance) {
			categoryOfTemporalVariation = instance.categoryOfTemporalVariation;
			qualityOfHorizontalMeasurement = instance.qualityOfHorizontalMeasurement;
			horizontalPositionUncertainty = new ();
			if (instance.horizontalPositionUncertainty != default) {
				horizontalPositionUncertainty.Load(instance.horizontalPositionUncertainty);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new SpatialQuality {
				categoryOfTemporalVariation = this.categoryOfTemporalVariation,
				qualityOfHorizontalMeasurement = this.qualityOfHorizontalMeasurement,
				horizontalPositionUncertainty = this.horizontalPositionUncertainty?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SpatialQuality Model => new () {
			categoryOfTemporalVariation = this._categoryOfTemporalVariation,
			qualityOfHorizontalMeasurement = this._qualityOfHorizontalMeasurement,
			horizontalPositionUncertainty = this._horizontalPositionUncertainty?.Model,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => SpatialQuality._informationBindingDefinitions;

		public override string? ToString() => $"Spatial Quality";
	}

	/// <summary>
	/// Spatial quality points.
	/// </summary>
	[CategoryOrder("SpatialQualityPoints",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SpatialQualityPointsViewModel : InformationViewModel<SpatialQualityPoints> {
		private categoryOfTemporalVariation? _categoryOfTemporalVariation  = default;

		[Category("SpatialQuality")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfTemporalVariationList), typeof(categoryOfTemporalVariation))]
		public categoryOfTemporalVariation? categoryOfTemporalVariation {
			get {
				return _categoryOfTemporalVariation;
			}
			set {
				SetValue(ref _categoryOfTemporalVariation, value);
			}
		}

		[Browsable(false)]
		public categoryOfTemporalVariation[] categoryOfTemporalVariationList => [(categoryOfTemporalVariation)1,(categoryOfTemporalVariation)4,(categoryOfTemporalVariation)5];
		private qualityOfHorizontalMeasurement? _qualityOfHorizontalMeasurement  = default;

		[Category("SpatialQuality")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(qualityOfHorizontalMeasurementList), typeof(qualityOfHorizontalMeasurement))]
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
		private horizontalPositionUncertaintyViewModel? _horizontalPositionUncertainty  = default;

		[Category("SpatialQuality")]
		[ExpandableObject]
		public horizontalPositionUncertaintyViewModel? horizontalPositionUncertainty {
			get {
				return _horizontalPositionUncertainty;
			}
			set {
				SetValue(ref _horizontalPositionUncertainty, value);
			}
		}



		public override InformationViewModel<SpatialQualityPoints> Load(SpatialQualityPoints instance) {
			categoryOfTemporalVariation = instance.categoryOfTemporalVariation;
			qualityOfHorizontalMeasurement = instance.qualityOfHorizontalMeasurement;
			horizontalPositionUncertainty = new ();
			if (instance.horizontalPositionUncertainty != default) {
				horizontalPositionUncertainty.Load(instance.horizontalPositionUncertainty);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new SpatialQualityPoints {
				categoryOfTemporalVariation = this.categoryOfTemporalVariation,
				qualityOfHorizontalMeasurement = this.qualityOfHorizontalMeasurement,
				horizontalPositionUncertainty = this.horizontalPositionUncertainty?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SpatialQualityPoints Model => new () {
			categoryOfTemporalVariation = this._categoryOfTemporalVariation,
			qualityOfHorizontalMeasurement = this._qualityOfHorizontalMeasurement,
			horizontalPositionUncertainty = this._horizontalPositionUncertainty?.Model,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => SpatialQualityPoints._informationBindingDefinitions;

		public override string? ToString() => $"Spatial Quality Points";
	}

	/// <summary>
	/// Generally, an area where the mariner has to be made aware of circumstances influencing the safety of navigation.
	/// </summary>
	[CategoryOrder("CautionArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CautionAreaViewModel : FeatureViewModel<CautionArea> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}

		private condition? _condition  = default;

		[Category("CautionArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(conditionList), typeof(condition))]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		[Browsable(false)]
		public condition[] conditionList => [(condition)1,(condition)3,(condition)5];
		private status? _status  = default;

		[Category("CautionArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public status? status {
			get {
				return _status;
			}
			set {
				SetValue(ref _status, value);
			}
		}

		[Browsable(false)]
		public status[] statusList => [(status)5,(status)7];


		public override FeatureViewModel<CautionArea> Load(CautionArea instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			condition = instance.condition;
			status = instance.status;
			return this;
		}

		public override string Serialize() {
			var instance = new CautionArea {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
				condition = this.condition,
				status = this.status,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CautionArea Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			condition = this._condition,
			status = this._status,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => CautionArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. CautionArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => CautionArea._featureBindingDefinitions;

		public override string? ToString() => $"Caution Area";

		public CautionAreaViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// An area where hazards, caused by concentrations of shipping, may occur. Hazards are risks to shipping, which stem from sources other than shoal water or obstructions.
	/// </summary>
	[CategoryOrder("ConcentrationOfShippingHazardArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ConcentrationOfShippingHazardAreaViewModel : FeatureViewModel<ConcentrationOfShippingHazardArea> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}

		[Category("ConcentrationOfShippingHazardArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfConcentrationOfShippingHazardAreaList), typeof(categoryOfConcentrationOfShippingHazardArea))]
		public ObservableCollection<categoryOfConcentrationOfShippingHazardArea> categoryOfConcentrationOfShippingHazardArea  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfConcentrationOfShippingHazardArea[] categoryOfConcentrationOfShippingHazardAreaList => [(categoryOfConcentrationOfShippingHazardArea)1,(categoryOfConcentrationOfShippingHazardArea)2,(categoryOfConcentrationOfShippingHazardArea)3,(categoryOfConcentrationOfShippingHazardArea)4];
		[Category("ConcentrationOfShippingHazardArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)5,(status)7,(status)16,(status)17];


		public override FeatureViewModel<ConcentrationOfShippingHazardArea> Load(ConcentrationOfShippingHazardArea instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
				categoryOfConcentrationOfShippingHazardArea = this.categoryOfConcentrationOfShippingHazardArea.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ConcentrationOfShippingHazardArea Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			categoryOfConcentrationOfShippingHazardArea = this.categoryOfConcentrationOfShippingHazardArea.ToList(),
			status = this.status.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => ConcentrationOfShippingHazardArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. ConcentrationOfShippingHazardArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => ConcentrationOfShippingHazardArea._featureBindingDefinitions;

		public override string? ToString() => $"Concentration of Shipping Hazard Area";

		public ConcentrationOfShippingHazardAreaViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
	[CategoryOrder("ISPSCodeSecurityLevel",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ISPSCodeSecurityLevelViewModel : FeatureViewModel<ISPSCodeSecurityLevel> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}


		private iSPSLevel _iSPSLevel  = default;

		[Category("ISPSCodeSecurityLevel")]
		[Editor(typeof(Editors.UnknownEditor<iSPSLevel?>), typeof(Editors.UnknownEditor<iSPSLevel?>))]
		[DomainModel.EnumerationAttribute(nameof(iSPSLevelList), typeof(iSPSLevel))]
		public iSPSLevel iSPSLevel {
			get {
				return _iSPSLevel;
			}
			set {
				SetValue(ref _iSPSLevel, value);
			}
		}

		[Browsable(false)]
		public iSPSLevel[] iSPSLevelList => [(iSPSLevel)1,(iSPSLevel)2,(iSPSLevel)3];


		public override FeatureViewModel<ISPSCodeSecurityLevel> Load(ISPSCodeSecurityLevel instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			iSPSLevel = instance.iSPSLevel;
			return this;
		}

		public override string Serialize() {
			var instance = new ISPSCodeSecurityLevel {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
				iSPSLevel = this.iSPSLevel,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ISPSCodeSecurityLevel Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			iSPSLevel = this._iSPSLevel,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => ISPSCodeSecurityLevel._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. ISPSCodeSecurityLevel._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => ISPSCodeSecurityLevel._featureBindingDefinitions;

		public override string? ToString() => $"ISPS Code Security Level";

		public ISPSCodeSecurityLevelViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// A service established to provide port information without interaction between the customer and the service provider. This information could be inter alia berthing information, availability of port services, shipping schedules, meteorological and hydrological data.
	/// </summary>
	[CategoryOrder("LocalPortServiceArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LocalPortServiceAreaViewModel : FeatureViewModel<LocalPortServiceArea> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}




		private String? _serviceAccessProcedure  = default;

		[Category("LocalPortServiceArea")]
		public String? serviceAccessProcedure {
			get {
				return _serviceAccessProcedure;
			}
			set {
				SetValue(ref _serviceAccessProcedure, value);
			}
		}
		private String _requirementsForMaintenanceOfListeningWatch  = string.Empty;

		[Category("LocalPortServiceArea")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String requirementsForMaintenanceOfListeningWatch {
			get {
				return _requirementsForMaintenanceOfListeningWatch;
			}
			set {
				SetValue(ref _requirementsForMaintenanceOfListeningWatch, value);
			}
		}


		public override FeatureViewModel<LocalPortServiceArea> Load(LocalPortServiceArea instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			serviceAccessProcedure = instance.serviceAccessProcedure;
			requirementsForMaintenanceOfListeningWatch = instance.requirementsForMaintenanceOfListeningWatch;
			return this;
		}

		public override string Serialize() {
			var instance = new LocalPortServiceArea {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
				serviceAccessProcedure = this.serviceAccessProcedure,
				requirementsForMaintenanceOfListeningWatch = this.requirementsForMaintenanceOfListeningWatch,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LocalPortServiceArea Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			serviceAccessProcedure = this._serviceAccessProcedure,
			requirementsForMaintenanceOfListeningWatch = this._requirementsForMaintenanceOfListeningWatch,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => LocalPortServiceArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LocalPortServiceArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LocalPortServiceArea._featureBindingDefinitions;

		public override string? ToString() => $"Local Port Service Area";

		public LocalPortServiceAreaViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// An area within which naval, military or aerial exercises are carried out. Also called an 'exercise area'.
	/// </summary>
	[CategoryOrder("MilitaryPracticeArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class MilitaryPracticeAreaViewModel : FeatureViewModel<MilitaryPracticeArea> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}



		[Category("MilitaryPracticeArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfMilitaryPracticeAreaList), typeof(categoryOfMilitaryPracticeArea))]
		public ObservableCollection<categoryOfMilitaryPracticeArea> categoryOfMilitaryPracticeArea  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfMilitaryPracticeArea[] categoryOfMilitaryPracticeAreaList => [(categoryOfMilitaryPracticeArea)2,(categoryOfMilitaryPracticeArea)3,(categoryOfMilitaryPracticeArea)4,(categoryOfMilitaryPracticeArea)5,(categoryOfMilitaryPracticeArea)6];
		private String? _nationality  = default;

		[Category("MilitaryPracticeArea")]
		public String? nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}
		[Category("MilitaryPracticeArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(restrictionList), typeof(restriction))]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)7,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)15,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)26,(restriction)27,(restriction)39];
		[Category("MilitaryPracticeArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)5,(status)6,(status)7,(status)16,(status)17];


		public override FeatureViewModel<MilitaryPracticeArea> Load(MilitaryPracticeArea instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
				categoryOfMilitaryPracticeArea = this.categoryOfMilitaryPracticeArea.ToList(),
				nationality = this.nationality,
				restriction = this.restriction.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public MilitaryPracticeArea Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			categoryOfMilitaryPracticeArea = this.categoryOfMilitaryPracticeArea.ToList(),
			nationality = this._nationality,
			restriction = this.restriction.ToList(),
			status = this.status.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => MilitaryPracticeArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. MilitaryPracticeArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => MilitaryPracticeArea._featureBindingDefinitions;

		public override string? ToString() => $"Military Practice Area";

		public MilitaryPracticeAreaViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
	[CategoryOrder("PilotBoardingPlace",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PilotBoardingPlaceViewModel : FeatureViewModel<PilotBoardingPlace> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}


		private String? _callSign  = default;

		[Category("PilotBoardingPlace")]
		public String? callSign {
			get {
				return _callSign;
			}
			set {
				SetValue(ref _callSign, value);
			}
		}
		private categoryOfPilotBoardingPlace? _categoryOfPilotBoardingPlace  = default;

		[Category("PilotBoardingPlace")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfPilotBoardingPlaceList), typeof(categoryOfPilotBoardingPlace))]
		public categoryOfPilotBoardingPlace? categoryOfPilotBoardingPlace {
			get {
				return _categoryOfPilotBoardingPlace;
			}
			set {
				SetValue(ref _categoryOfPilotBoardingPlace, value);
			}
		}

		[Browsable(false)]
		public categoryOfPilotBoardingPlace[] categoryOfPilotBoardingPlaceList => [(categoryOfPilotBoardingPlace)1,(categoryOfPilotBoardingPlace)2,(categoryOfPilotBoardingPlace)3];
		private categoryOfPreference? _categoryOfPreference  = default;

		[Category("PilotBoardingPlace")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfPreferenceList), typeof(categoryOfPreference))]
		public categoryOfPreference? categoryOfPreference {
			get {
				return _categoryOfPreference;
			}
			set {
				SetValue(ref _categoryOfPreference, value);
			}
		}

		[Browsable(false)]
		public categoryOfPreference[] categoryOfPreferenceList => [(categoryOfPreference)1,(categoryOfPreference)2];
		private categoryOfVessel? _categoryOfVessel  = default;

		[Category("PilotBoardingPlace")]
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
		[Category("PilotBoardingPlace")]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();
		private String? _destination  = default;

		[Category("PilotBoardingPlace")]
		public String? destination {
			get {
				return _destination;
			}
			set {
				SetValue(ref _destination, value);
			}
		}
		private pilotMovement? _pilotMovement  = default;

		[Category("PilotBoardingPlace")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(pilotMovementList), typeof(pilotMovement))]
		public pilotMovement? pilotMovement {
			get {
				return _pilotMovement;
			}
			set {
				SetValue(ref _pilotMovement, value);
			}
		}

		[Browsable(false)]
		public pilotMovement[] pilotMovementList => [(pilotMovement)1,(pilotMovement)2,(pilotMovement)3];
		private String? _pilotVessel  = default;

		[Category("PilotBoardingPlace")]
		public String? pilotVessel {
			get {
				return _pilotVessel;
			}
			set {
				SetValue(ref _pilotVessel, value);
			}
		}
		[Category("PilotBoardingPlace")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)5,(status)6,(status)9,(status)16,(status)17,(status)28];


		public override FeatureViewModel<PilotBoardingPlace> Load(PilotBoardingPlace instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
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
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
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
		public override informationBindingDefinition[] informationBindingDefinitions => PilotBoardingPlace._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. PilotBoardingPlace._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => PilotBoardingPlace._featureBindingDefinitions;

		public override string? ToString() => $"Pilot Boarding Place";

		public PilotBoardingPlaceViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
	/// The service provided by a person who directs the movements of a vessel through pilot waters, usually a person who has demonstrated extensive knowledge of channels, aids to navigation, dangers to navigation, etc., in a particular area and is licensed for that area.
	/// </summary>
	[CategoryOrder("PilotService",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PilotServiceViewModel : FeatureViewModel<PilotService> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}




		[Category("PilotService")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfPilotList), typeof(categoryOfPilot))]
		public ObservableCollection<categoryOfPilot> categoryOfPilot  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfPilot[] categoryOfPilotList => [(categoryOfPilot)1,(categoryOfPilot)2,(categoryOfPilot)3,(categoryOfPilot)4,(categoryOfPilot)5,(categoryOfPilot)6,(categoryOfPilot)7];
		private pilotQualification? _pilotQualification  = default;

		[Category("PilotService")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(pilotQualificationList), typeof(pilotQualification))]
		public pilotQualification? pilotQualification {
			get {
				return _pilotQualification;
			}
			set {
				SetValue(ref _pilotQualification, value);
			}
		}

		[Browsable(false)]
		public pilotQualification[] pilotQualificationList => [(pilotQualification)1,(pilotQualification)2,(pilotQualification)3,(pilotQualification)4,(pilotQualification)5,(pilotQualification)6,(pilotQualification)7,(pilotQualification)8];
		private String? _pilotRequest  = default;

		[Category("PilotService")]
		public String? pilotRequest {
			get {
				return _pilotRequest;
			}
			set {
				SetValue(ref _pilotRequest, value);
			}
		}
		private Boolean _remotePilot  = false;

		[Category("PilotService")]
		[Editor(typeof(Editors.UnknownEditor<Boolean?>), typeof(Editors.UnknownEditor<Boolean?>))]
		public Boolean remotePilot {
			get {
				return _remotePilot;
			}
			set {
				SetValue(ref _remotePilot, value);
			}
		}
		private noticeTimeViewModel? _noticeTime  = default;

		[Category("PilotService")]
		[ExpandableObject]
		public noticeTimeViewModel? noticeTime {
			get {
				return _noticeTime;
			}
			set {
				SetValue(ref _noticeTime, value);
			}
		}


		public override FeatureViewModel<PilotService> Load(PilotService instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
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
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			categoryOfPilot = this.categoryOfPilot.ToList(),
			pilotQualification = this._pilotQualification,
			pilotRequest = this._pilotRequest,
			remotePilot = this._remotePilot,
			noticeTime = this._noticeTime?.Model,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => PilotService._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. PilotService._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => PilotService._featureBindingDefinitions;

		public override string? ToString() => $"Pilot Service";

		public PilotServiceViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			categoryOfPilot.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfPilot));
			};
		}
	}

	/// <summary>
	/// An area within which a pilotage direction exists. Such directions are regulated by a competent harbour authority which dictates circumstances under which they apply.
	/// </summary>
	[CategoryOrder("PilotageDistrict",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PilotageDistrictViewModel : FeatureViewModel<PilotageDistrict> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}

		[Category("PilotageDistrict")]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();


		public override FeatureViewModel<PilotageDistrict> Load(PilotageDistrict instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
				communicationChannel = this.communicationChannel.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PilotageDistrict Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			communicationChannel = this.communicationChannel.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => PilotageDistrict._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. PilotageDistrict._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => PilotageDistrict._featureBindingDefinitions;

		public override string? ToString() => $"Pilotage District";

		public PilotageDistrictViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(communicationChannel));
			};
		}
	}

	/// <summary>
	/// An area where there is a raised risk of piracy or armed robbery.
	/// </summary>
	[CategoryOrder("PiracyRiskArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PiracyRiskAreaViewModel : FeatureViewModel<PiracyRiskArea> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}




		[Category("PiracyRiskArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(restrictionList), typeof(restriction))]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)7,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)14,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)24,(restriction)25,(restriction)26,(restriction)27,(restriction)31,(restriction)32,(restriction)33,(restriction)34];
		[Category("PiracyRiskArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)5,(status)7];


		public override FeatureViewModel<PiracyRiskArea> Load(PiracyRiskArea instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
				restriction = this.restriction.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PiracyRiskArea Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			restriction = this.restriction.ToList(),
			status = this.status.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => PiracyRiskArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. PiracyRiskArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => PiracyRiskArea._featureBindingDefinitions;

		public override string? ToString() => $"Piracy Risk Area";

		public PiracyRiskAreaViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
	[CategoryOrder("PlaceOfRefuge",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PlaceOfRefugeViewModel : FeatureViewModel<PlaceOfRefuge> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}




		[Category("PlaceOfRefuge")]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();
		[Category("PlaceOfRefuge")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)28];


		public override FeatureViewModel<PlaceOfRefuge> Load(PlaceOfRefuge instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
				communicationChannel = this.communicationChannel.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PlaceOfRefuge Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			communicationChannel = this.communicationChannel.ToList(),
			status = this.status.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => PlaceOfRefuge._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. PlaceOfRefuge._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => PlaceOfRefuge._featureBindingDefinitions;

		public override string? ToString() => $"Place of Refuge";

		public PlaceOfRefugeViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
	[CategoryOrder("RadarRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadarRangeViewModel : FeatureViewModel<RadarRange> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}

		[Category("RadarRange")]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();
		[Category("RadarRange")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)7];


		public override FeatureViewModel<RadarRange> Load(RadarRange instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
				communicationChannel = this.communicationChannel.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RadarRange Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			communicationChannel = this.communicationChannel.ToList(),
			status = this.status.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => RadarRange._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RadarRange._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RadarRange._featureBindingDefinitions;

		public override string? ToString() => $"Radar Range";

		public RadarRangeViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
	/// A designated position at which vessels are required to report to a traffic control centre. Also called reporting point or radio reporting point.
	/// </summary>
	[CategoryOrder("RadioCallingInPoint",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadioCallingInPointViewModel : FeatureViewModel<RadioCallingInPoint> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}

		private String? _callSign  = default;

		[Category("RadioCallingInPoint")]
		public String? callSign {
			get {
				return _callSign;
			}
			set {
				SetValue(ref _callSign, value);
			}
		}
		[Category("RadioCallingInPoint")]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();
		[Category("RadioCallingInPoint")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfCargoList), typeof(categoryOfCargo))]
		public ObservableCollection<categoryOfCargo> categoryOfCargo  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfCargo[] categoryOfCargoList => [(categoryOfCargo)1,(categoryOfCargo)2,(categoryOfCargo)3,(categoryOfCargo)4,(categoryOfCargo)5,(categoryOfCargo)6,(categoryOfCargo)7,(categoryOfCargo)8,(categoryOfCargo)9];
		[Category("RadioCallingInPoint")]
		public ObservableCollection<categoryOfVessel> categoryOfVessel  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfVessel[] categoryOfVesselList =>  CodeList.categoryOfVessels.ToArray();
		[Category("RadioCallingInPoint")]
		public ObservableCollection<decimal> orientationValue  { get; set; } = new ();
		[Category("RadioCallingInPoint")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)3,(status)4,(status)5,(status)6,(status)7,(status)9];
		private trafficFlow _trafficFlow  = default;

		[Category("RadioCallingInPoint")]
		[Editor(typeof(Editors.UnknownEditor<trafficFlow?>), typeof(Editors.UnknownEditor<trafficFlow?>))]
		[DomainModel.EnumerationAttribute(nameof(trafficFlowList), typeof(trafficFlow))]
		public trafficFlow trafficFlow {
			get {
				return _trafficFlow;
			}
			set {
				SetValue(ref _trafficFlow, value);
			}
		}

		[Browsable(false)]
		public trafficFlow[] trafficFlowList => [(trafficFlow)1,(trafficFlow)2,(trafficFlow)3,(trafficFlow)4];


		public override FeatureViewModel<RadioCallingInPoint> Load(RadioCallingInPoint instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
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
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			callSign = this._callSign,
			communicationChannel = this.communicationChannel.ToList(),
			categoryOfCargo = this.categoryOfCargo.ToList(),
			categoryOfVessel = this.categoryOfVessel.ToList(),
			orientationValue = this.orientationValue.ToList(),
			status = this.status.ToList(),
			trafficFlow = this._trafficFlow,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => RadioCallingInPoint._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RadioCallingInPoint._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RadioCallingInPoint._featureBindingDefinitions;

		public override string? ToString() => $"Radio Calling-In Point";

		public RadioCallingInPointViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
		}
	}

	/// <summary>
	/// A specified area on land or water designated by an appropriate authority within which access or navigation is restricted in accordance with certain specified conditions. A navigational restricted area is an area where the restrictions have a direct impact on the navigation of a vessel in the area.
	/// </summary>
	[CategoryOrder("RestrictedAreaNavigational",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RestrictedAreaNavigationalViewModel : FeatureViewModel<RestrictedAreaNavigational> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}



		[Category("RestrictedAreaNavigational")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfRestrictedAreaList), typeof(categoryOfRestrictedArea))]
		public ObservableCollection<categoryOfRestrictedArea> categoryOfRestrictedArea  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfRestrictedArea[] categoryOfRestrictedAreaList => [(categoryOfRestrictedArea)1,(categoryOfRestrictedArea)4,(categoryOfRestrictedArea)5,(categoryOfRestrictedArea)6,(categoryOfRestrictedArea)7,(categoryOfRestrictedArea)8,(categoryOfRestrictedArea)9,(categoryOfRestrictedArea)10,(categoryOfRestrictedArea)12,(categoryOfRestrictedArea)14,(categoryOfRestrictedArea)19,(categoryOfRestrictedArea)20,(categoryOfRestrictedArea)22,(categoryOfRestrictedArea)23,(categoryOfRestrictedArea)25,(categoryOfRestrictedArea)27,(categoryOfRestrictedArea)28,(categoryOfRestrictedArea)29,(categoryOfRestrictedArea)30,(categoryOfRestrictedArea)31,(categoryOfRestrictedArea)32];
		[Category("RestrictedAreaNavigational")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(restrictionList), typeof(restriction))]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)7,(restriction)8,(restriction)13,(restriction)14,(restriction)25,(restriction)26,(restriction)27,(restriction)28,(restriction)29,(restriction)30,(restriction)35,(restriction)36,(restriction)37];
		[Category("RestrictedAreaNavigational")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)9,(status)18,(status)28];


		public override FeatureViewModel<RestrictedAreaNavigational> Load(RestrictedAreaNavigational instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
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
			var instance = new RestrictedAreaNavigational {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
				categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
				restriction = this.restriction.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RestrictedAreaNavigational Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
			restriction = this.restriction.ToList(),
			status = this.status.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => RestrictedAreaNavigational._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RestrictedAreaNavigational._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RestrictedAreaNavigational._featureBindingDefinitions;

		public override string? ToString() => $"Restricted Area Navigational";

		public RestrictedAreaNavigationalViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
	/// A specified area on land or water designated by an appropriate authority within which access or navigation is restricted in accordance with certain specified conditions. A regulatory restricted area is an area where the restrictions have no direct impact on the navigation of a vessel in the area, but impact on the activities that can take place within the area.
	/// </summary>
	[CategoryOrder("RestrictedAreaRegulatory",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RestrictedAreaRegulatoryViewModel : FeatureViewModel<RestrictedAreaRegulatory> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}



		[Category("RestrictedAreaRegulatory")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfRestrictedAreaList), typeof(categoryOfRestrictedArea))]
		public ObservableCollection<categoryOfRestrictedArea> categoryOfRestrictedArea  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfRestrictedArea[] categoryOfRestrictedAreaList => [(categoryOfRestrictedArea)1,(categoryOfRestrictedArea)4,(categoryOfRestrictedArea)5,(categoryOfRestrictedArea)6,(categoryOfRestrictedArea)7,(categoryOfRestrictedArea)8,(categoryOfRestrictedArea)9,(categoryOfRestrictedArea)10,(categoryOfRestrictedArea)12,(categoryOfRestrictedArea)14,(categoryOfRestrictedArea)19,(categoryOfRestrictedArea)20,(categoryOfRestrictedArea)22,(categoryOfRestrictedArea)23,(categoryOfRestrictedArea)25,(categoryOfRestrictedArea)27,(categoryOfRestrictedArea)28,(categoryOfRestrictedArea)29,(categoryOfRestrictedArea)30,(categoryOfRestrictedArea)31,(categoryOfRestrictedArea)32];
		[Category("RestrictedAreaRegulatory")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(restrictionList), typeof(restriction))]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)15,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)39];
		[Category("RestrictedAreaRegulatory")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)9,(status)18,(status)28];


		public override FeatureViewModel<RestrictedAreaRegulatory> Load(RestrictedAreaRegulatory instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
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
			var instance = new RestrictedAreaRegulatory {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
				categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
				restriction = this.restriction.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RestrictedAreaRegulatory Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
			restriction = this.restriction.ToList(),
			status = this.status.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => RestrictedAreaRegulatory._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RestrictedAreaRegulatory._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RestrictedAreaRegulatory._featureBindingDefinitions;

		public override string? ToString() => $"Restricted Area Regulatory";

		public RestrictedAreaRegulatoryViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
	[CategoryOrder("RouteingMeasure",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RouteingMeasureViewModel : FeatureViewModel<RouteingMeasure> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}

		private categoryOfRouteingMeasure _categoryOfRouteingMeasure  = default;

		[Category("RouteingMeasure")]
		[Editor(typeof(Editors.UnknownEditor<categoryOfRouteingMeasure?>), typeof(Editors.UnknownEditor<categoryOfRouteingMeasure?>))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfRouteingMeasureList), typeof(categoryOfRouteingMeasure))]
		public categoryOfRouteingMeasure categoryOfRouteingMeasure {
			get {
				return _categoryOfRouteingMeasure;
			}
			set {
				SetValue(ref _categoryOfRouteingMeasure, value);
			}
		}

		[Browsable(false)]
		public categoryOfRouteingMeasure[] categoryOfRouteingMeasureList => [(categoryOfRouteingMeasure)1,(categoryOfRouteingMeasure)2,(categoryOfRouteingMeasure)3,(categoryOfRouteingMeasure)4,(categoryOfRouteingMeasure)5,(categoryOfRouteingMeasure)6];
		private categoryOfTrafficSeparationScheme? _categoryOfTrafficSeparationScheme  = default;

		[Category("RouteingMeasure")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfTrafficSeparationSchemeList), typeof(categoryOfTrafficSeparationScheme))]
		public categoryOfTrafficSeparationScheme? categoryOfTrafficSeparationScheme {
			get {
				return _categoryOfTrafficSeparationScheme;
			}
			set {
				SetValue(ref _categoryOfTrafficSeparationScheme, value);
			}
		}

		[Browsable(false)]
		public categoryOfTrafficSeparationScheme[] categoryOfTrafficSeparationSchemeList => [(categoryOfTrafficSeparationScheme)1,(categoryOfTrafficSeparationScheme)2];
		private categoryOfNavigationLine? _categoryOfNavigationLine  = default;

		[Category("RouteingMeasure")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfNavigationLineList), typeof(categoryOfNavigationLine))]
		public categoryOfNavigationLine? categoryOfNavigationLine {
			get {
				return _categoryOfNavigationLine;
			}
			set {
				SetValue(ref _categoryOfNavigationLine, value);
			}
		}

		[Browsable(false)]
		public categoryOfNavigationLine[] categoryOfNavigationLineList => [(categoryOfNavigationLine)1,(categoryOfNavigationLine)2,(categoryOfNavigationLine)3];


		public override FeatureViewModel<RouteingMeasure> Load(RouteingMeasure instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			categoryOfRouteingMeasure = instance.categoryOfRouteingMeasure;
			categoryOfTrafficSeparationScheme = instance.categoryOfTrafficSeparationScheme;
			categoryOfNavigationLine = instance.categoryOfNavigationLine;
			return this;
		}

		public override string Serialize() {
			var instance = new RouteingMeasure {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
				categoryOfRouteingMeasure = this.categoryOfRouteingMeasure,
				categoryOfTrafficSeparationScheme = this.categoryOfTrafficSeparationScheme,
				categoryOfNavigationLine = this.categoryOfNavigationLine,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RouteingMeasure Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			categoryOfRouteingMeasure = this._categoryOfRouteingMeasure,
			categoryOfTrafficSeparationScheme = this._categoryOfTrafficSeparationScheme,
			categoryOfNavigationLine = this._categoryOfNavigationLine,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => RouteingMeasure._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RouteingMeasure._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RouteingMeasure._featureBindingDefinitions;

		public override string? ToString() => $"Routeing Measure";

		public RouteingMeasureViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// A service established by a relevant authority consisting of one or more reporting points or lines at which ships are required to report their identity, course, speed and other data to the monitoring authority.
	/// </summary>
	[CategoryOrder("ShipReportingServiceArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ShipReportingServiceAreaViewModel : FeatureViewModel<ShipReportingServiceArea> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}




		private String? _serviceAccessProcedure  = default;

		[Category("ShipReportingServiceArea")]
		public String? serviceAccessProcedure {
			get {
				return _serviceAccessProcedure;
			}
			set {
				SetValue(ref _serviceAccessProcedure, value);
			}
		}
		private String _requirementsForMaintenanceOfListeningWatch  = string.Empty;

		[Category("ShipReportingServiceArea")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String requirementsForMaintenanceOfListeningWatch {
			get {
				return _requirementsForMaintenanceOfListeningWatch;
			}
			set {
				SetValue(ref _requirementsForMaintenanceOfListeningWatch, value);
			}
		}


		public override FeatureViewModel<ShipReportingServiceArea> Load(ShipReportingServiceArea instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			serviceAccessProcedure = instance.serviceAccessProcedure;
			requirementsForMaintenanceOfListeningWatch = instance.requirementsForMaintenanceOfListeningWatch;
			return this;
		}

		public override string Serialize() {
			var instance = new ShipReportingServiceArea {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
				serviceAccessProcedure = this.serviceAccessProcedure,
				requirementsForMaintenanceOfListeningWatch = this.requirementsForMaintenanceOfListeningWatch,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ShipReportingServiceArea Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			serviceAccessProcedure = this._serviceAccessProcedure,
			requirementsForMaintenanceOfListeningWatch = this._requirementsForMaintenanceOfListeningWatch,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => ShipReportingServiceArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. ShipReportingServiceArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => ShipReportingServiceArea._featureBindingDefinitions;

		public override string? ToString() => $"Ship Reporting Service Area";

		public ShipReportingServiceAreaViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// A warning signal station is a place on shore from which warning signals are made to ships at sea.
	/// </summary>
	[CategoryOrder("SignalStationWarning",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SignalStationWarningViewModel : FeatureViewModel<SignalStationWarning> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}

		[Category("SignalStationWarning")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfSignalStationWarningList), typeof(categoryOfSignalStationWarning))]
		public ObservableCollection<categoryOfSignalStationWarning> categoryOfSignalStationWarning  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfSignalStationWarning[] categoryOfSignalStationWarningList => [(categoryOfSignalStationWarning)1,(categoryOfSignalStationWarning)2,(categoryOfSignalStationWarning)3,(categoryOfSignalStationWarning)4,(categoryOfSignalStationWarning)5,(categoryOfSignalStationWarning)6,(categoryOfSignalStationWarning)7,(categoryOfSignalStationWarning)8,(categoryOfSignalStationWarning)9,(categoryOfSignalStationWarning)10,(categoryOfSignalStationWarning)11,(categoryOfSignalStationWarning)12,(categoryOfSignalStationWarning)13,(categoryOfSignalStationWarning)14,(categoryOfSignalStationWarning)15,(categoryOfSignalStationWarning)16,(categoryOfSignalStationWarning)17,(categoryOfSignalStationWarning)18];
		[Category("SignalStationWarning")]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();
		[Category("SignalStationWarning")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)12,(status)14,(status)15,(status)16,(status)17];


		public override FeatureViewModel<SignalStationWarning> Load(SignalStationWarning instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
				categoryOfSignalStationWarning = this.categoryOfSignalStationWarning.ToList(),
				communicationChannel = this.communicationChannel.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SignalStationWarning Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			categoryOfSignalStationWarning = this.categoryOfSignalStationWarning.ToList(),
			communicationChannel = this.communicationChannel.ToList(),
			status = this.status.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => SignalStationWarning._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SignalStationWarning._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SignalStationWarning._featureBindingDefinitions;

		public override string? ToString() => $"Signal Station Warning";

		public SignalStationWarningViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
		}
	}

	/// <summary>
	/// A traffic signal station is a place on shore from which signals are made to regulate the movement of traffic.
	/// </summary>
	[CategoryOrder("SignalStationTraffic",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SignalStationTrafficViewModel : FeatureViewModel<SignalStationTraffic> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}


		[Category("SignalStationTraffic")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfSignalStationTrafficList), typeof(categoryOfSignalStationTraffic))]
		public ObservableCollection<categoryOfSignalStationTraffic> categoryOfSignalStationTraffic  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfSignalStationTraffic[] categoryOfSignalStationTrafficList => [(categoryOfSignalStationTraffic)1,(categoryOfSignalStationTraffic)2,(categoryOfSignalStationTraffic)3,(categoryOfSignalStationTraffic)4,(categoryOfSignalStationTraffic)5,(categoryOfSignalStationTraffic)6,(categoryOfSignalStationTraffic)7,(categoryOfSignalStationTraffic)8,(categoryOfSignalStationTraffic)9,(categoryOfSignalStationTraffic)10,(categoryOfSignalStationTraffic)13];
		[Category("SignalStationTraffic")]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();
		[Category("SignalStationTraffic")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)12,(status)14,(status)15,(status)16,(status)17];


		public override FeatureViewModel<SignalStationTraffic> Load(SignalStationTraffic instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
				categoryOfSignalStationTraffic = this.categoryOfSignalStationTraffic.ToList(),
				communicationChannel = this.communicationChannel.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SignalStationTraffic Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			categoryOfSignalStationTraffic = this.categoryOfSignalStationTraffic.ToList(),
			communicationChannel = this.communicationChannel.ToList(),
			status = this.status.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => SignalStationTraffic._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SignalStationTraffic._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SignalStationTraffic._featureBindingDefinitions;

		public override string? ToString() => $"Signal Station Traffic";

		public SignalStationTrafficViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
		}
	}

	/// <summary>
	/// An area for which an authority has stated under keel allowance requirements.
	/// </summary>
	[CategoryOrder("UnderKeelClearanceAllowanceArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class UnderKeelClearanceAllowanceAreaViewModel : FeatureViewModel<UnderKeelClearanceAllowanceArea> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}

		private underKeelAllowanceViewModel? _underKeelAllowance  = default;

		[Category("UnderKeelClearanceAllowanceArea")]
		[ExpandableObject]
		public underKeelAllowanceViewModel? underKeelAllowance {
			get {
				return _underKeelAllowance;
			}
			set {
				SetValue(ref _underKeelAllowance, value);
			}
		}
		private waterLevelTrend? _waterLevelTrend  = default;

		[Category("UnderKeelClearanceAllowanceArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(waterLevelTrendList), typeof(waterLevelTrend))]
		public waterLevelTrend? waterLevelTrend {
			get {
				return _waterLevelTrend;
			}
			set {
				SetValue(ref _waterLevelTrend, value);
			}
		}

		[Browsable(false)]
		public waterLevelTrend[] waterLevelTrendList => [(waterLevelTrend)1,(waterLevelTrend)2,(waterLevelTrend)3];


		public override FeatureViewModel<UnderKeelClearanceAllowanceArea> Load(UnderKeelClearanceAllowanceArea instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
				underKeelAllowance = this.underKeelAllowance?.Model,
				waterLevelTrend = this.waterLevelTrend,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public UnderKeelClearanceAllowanceArea Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			underKeelAllowance = this._underKeelAllowance?.Model,
			waterLevelTrend = this._waterLevelTrend,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => UnderKeelClearanceAllowanceArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. UnderKeelClearanceAllowanceArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => UnderKeelClearanceAllowanceArea._featureBindingDefinitions;

		public override string? ToString() => $"Under Keel Clearance Allowance Area";

		public UnderKeelClearanceAllowanceAreaViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// An area for which an authority permits use of dynamic under keel clearance information or provides dynamic information related to under keel clearances.
	/// </summary>
	[CategoryOrder("UnderKeelClearanceManagementArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class UnderKeelClearanceManagementAreaViewModel : FeatureViewModel<UnderKeelClearanceManagementArea> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}




		private dynamicResource _dynamicResource  = default;

		[Category("UnderKeelClearanceManagementArea")]
		[Editor(typeof(Editors.UnknownEditor<dynamicResource?>), typeof(Editors.UnknownEditor<dynamicResource?>))]
		[DomainModel.EnumerationAttribute(nameof(dynamicResourceList), typeof(dynamicResource))]
		public dynamicResource dynamicResource {
			get {
				return _dynamicResource;
			}
			set {
				SetValue(ref _dynamicResource, value);
			}
		}

		[Browsable(false)]
		public dynamicResource[] dynamicResourceList => [(dynamicResource)1,(dynamicResource)2,(dynamicResource)3,(dynamicResource)4];


		public override FeatureViewModel<UnderKeelClearanceManagementArea> Load(UnderKeelClearanceManagementArea instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			dynamicResource = instance.dynamicResource;
			return this;
		}

		public override string Serialize() {
			var instance = new UnderKeelClearanceManagementArea {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
				dynamicResource = this.dynamicResource,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public UnderKeelClearanceManagementArea Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			dynamicResource = this._dynamicResource,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => UnderKeelClearanceManagementArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. UnderKeelClearanceManagementArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => UnderKeelClearanceManagementArea._featureBindingDefinitions;

		public override string? ToString() => $"Under Keel Clearance Management Area";

		public UnderKeelClearanceManagementAreaViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}




		[Category("VesselTrafficServiceArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfVesselTrafficServiceList), typeof(categoryOfVesselTrafficService))]
		public ObservableCollection<categoryOfVesselTrafficService> categoryOfVesselTrafficService  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfVesselTrafficService[] categoryOfVesselTrafficServiceList => [(categoryOfVesselTrafficService)1,(categoryOfVesselTrafficService)2,(categoryOfVesselTrafficService)3];
		private String? _serviceAccessProcedure  = default;

		[Category("VesselTrafficServiceArea")]
		public String? serviceAccessProcedure {
			get {
				return _serviceAccessProcedure;
			}
			set {
				SetValue(ref _serviceAccessProcedure, value);
			}
		}
		private String _requirementsForMaintenanceOfListeningWatch  = string.Empty;

		[Category("VesselTrafficServiceArea")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String requirementsForMaintenanceOfListeningWatch {
			get {
				return _requirementsForMaintenanceOfListeningWatch;
			}
			set {
				SetValue(ref _requirementsForMaintenanceOfListeningWatch, value);
			}
		}


		public override FeatureViewModel<VesselTrafficServiceArea> Load(VesselTrafficServiceArea instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			categoryOfVesselTrafficService.Clear();
			if (instance.categoryOfVesselTrafficService is not null) {
				foreach(var e in instance.categoryOfVesselTrafficService)
					categoryOfVesselTrafficService.Add(e);
			}
			serviceAccessProcedure = instance.serviceAccessProcedure;
			requirementsForMaintenanceOfListeningWatch = instance.requirementsForMaintenanceOfListeningWatch;
			return this;
		}

		public override string Serialize() {
			var instance = new VesselTrafficServiceArea {
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
				categoryOfVesselTrafficService = this.categoryOfVesselTrafficService.ToList(),
				serviceAccessProcedure = this.serviceAccessProcedure,
				requirementsForMaintenanceOfListeningWatch = this.requirementsForMaintenanceOfListeningWatch,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public VesselTrafficServiceArea Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			categoryOfVesselTrafficService = this.categoryOfVesselTrafficService.ToList(),
			serviceAccessProcedure = this._serviceAccessProcedure,
			requirementsForMaintenanceOfListeningWatch = this._requirementsForMaintenanceOfListeningWatch,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => VesselTrafficServiceArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. VesselTrafficServiceArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => VesselTrafficServiceArea._featureBindingDefinitions;

		public override string? ToString() => $"Vessel Traffic Service Area";

		public VesselTrafficServiceAreaViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			categoryOfVesselTrafficService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfVesselTrafficService));
			};
		}
	}

	/// <summary>
	/// An area in which uniform general information of the waterway exists.
	/// </summary>
	[CategoryOrder("WaterwayArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class WaterwayAreaViewModel : FeatureViewModel<WaterwayArea> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("FeatureType")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("FeatureType")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private textContentViewModel? _textContent  = default;

		[Category("FeatureType")]
		[ExpandableObject]
		public textContentViewModel? textContent {
			get {
				return _textContent;
			}
			set {
				SetValue(ref _textContent, value);
			}
		}



		private dynamicResource _dynamicResource  = default;

		[Category("WaterwayArea")]
		[Editor(typeof(Editors.UnknownEditor<dynamicResource?>), typeof(Editors.UnknownEditor<dynamicResource?>))]
		[DomainModel.EnumerationAttribute(nameof(dynamicResourceList), typeof(dynamicResource))]
		public dynamicResource dynamicResource {
			get {
				return _dynamicResource;
			}
			set {
				SetValue(ref _dynamicResource, value);
			}
		}

		[Browsable(false)]
		public dynamicResource[] dynamicResourceList => [(dynamicResource)1,(dynamicResource)2,(dynamicResource)3,(dynamicResource)4];
		private String? _siltationRate  = default;

		[Category("WaterwayArea")]
		public String? siltationRate {
			get {
				return _siltationRate;
			}
			set {
				SetValue(ref _siltationRate, value);
			}
		}
		[Category("WaterwayArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)28];


		public override FeatureViewModel<WaterwayArea> Load(WaterwayArea instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
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
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication?.Model,
				textContent = this.textContent?.Model,
				dynamicResource = this.dynamicResource,
				siltationRate = this.siltationRate,
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public WaterwayArea Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIndication = this._sourceIndication?.Model,
			textContent = this._textContent?.Model,
			dynamicResource = this._dynamicResource,
			siltationRate = this._siltationRate,
			status = this.status.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => WaterwayArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. WaterwayArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => WaterwayArea._featureBindingDefinitions;

		public override string? ToString() => $"Waterway Area";

		public WaterwayAreaViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
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
		private int _maximumDisplayScale  = default;

		[Category("DataCoverage")]
		[Editor(typeof(Editors.UnknownEditor<int?>), typeof(Editors.UnknownEditor<int?>))]
		public int maximumDisplayScale {
			get {
				return _maximumDisplayScale;
			}
			set {
				SetValue(ref _maximumDisplayScale, value);
			}
		}
		private int _minimumDisplayScale  = default;

		[Category("DataCoverage")]
		[Editor(typeof(Editors.UnknownEditor<int?>), typeof(Editors.UnknownEditor<int?>))]
		public int minimumDisplayScale {
			get {
				return _minimumDisplayScale;
			}
			set {
				SetValue(ref _minimumDisplayScale, value);
			}
		}


		public override FeatureViewModel<DataCoverage> Load(DataCoverage instance) {
			maximumDisplayScale = instance.maximumDisplayScale;
			minimumDisplayScale = instance.minimumDisplayScale;
			return this;
		}

		public override string Serialize() {
			var instance = new DataCoverage {
				maximumDisplayScale = this.maximumDisplayScale,
				minimumDisplayScale = this.minimumDisplayScale,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DataCoverage Model => new () {
			maximumDisplayScale = this._maximumDisplayScale,
			minimumDisplayScale = this._minimumDisplayScale,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => DataCoverage._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. DataCoverage._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => DataCoverage._featureBindingDefinitions;

		public override string? ToString() => $"Data Coverage";
	}

	/// <summary>
	/// An area within which a uniform assessment of the quality of the non-bathymetric data exists.
	/// </summary>
	[CategoryOrder("QualityOfNonBathymetricData",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class QualityOfNonBathymetricDataViewModel : FeatureViewModel<QualityOfNonBathymetricData> {
		[Category("DataQuality")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private categoryOfTemporalVariation? _categoryOfTemporalVariation  = default;

		[Category("QualityOfTemporalVariation")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfTemporalVariationList), typeof(categoryOfTemporalVariation))]
		public categoryOfTemporalVariation? categoryOfTemporalVariation {
			get {
				return _categoryOfTemporalVariation;
			}
			set {
				SetValue(ref _categoryOfTemporalVariation, value);
			}
		}

		[Browsable(false)]
		public categoryOfTemporalVariation[] categoryOfTemporalVariationList => [(categoryOfTemporalVariation)1,(categoryOfTemporalVariation)4,(categoryOfTemporalVariation)5];

		private decimal? _orientationUncertainty  = default;

		[Category("QualityOfNonBathymetricData")]
		public decimal? orientationUncertainty {
			get {
				return _orientationUncertainty;
			}
			set {
				SetValue(ref _orientationUncertainty, value);
			}
		}
		private decimal? _horizontalDistanceUncertainty  = default;

		[Category("QualityOfNonBathymetricData")]
		public decimal? horizontalDistanceUncertainty {
			get {
				return _horizontalDistanceUncertainty;
			}
			set {
				SetValue(ref _horizontalDistanceUncertainty, value);
			}
		}
		private horizontalPositionUncertaintyViewModel? _horizontalPositionUncertainty  = default;

		[Category("QualityOfNonBathymetricData")]
		[ExpandableObject]
		public horizontalPositionUncertaintyViewModel? horizontalPositionUncertainty {
			get {
				return _horizontalPositionUncertainty;
			}
			set {
				SetValue(ref _horizontalPositionUncertainty, value);
			}
		}
		private sourceIndicationViewModel? _sourceIndication  = default;

		[Category("QualityOfNonBathymetricData")]
		[ExpandableObject]
		public sourceIndicationViewModel? sourceIndication {
			get {
				return _sourceIndication;
			}
			set {
				SetValue(ref _sourceIndication, value);
			}
		}
		private surveyDateRangeViewModel? _surveyDateRange  = default;

		[Category("QualityOfNonBathymetricData")]
		[ExpandableObject]
		public surveyDateRangeViewModel? surveyDateRange {
			get {
				return _surveyDateRange;
			}
			set {
				SetValue(ref _surveyDateRange, value);
			}
		}


		public override FeatureViewModel<QualityOfNonBathymetricData> Load(QualityOfNonBathymetricData instance) {
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			categoryOfTemporalVariation = instance.categoryOfTemporalVariation;
			orientationUncertainty = instance.orientationUncertainty;
			horizontalDistanceUncertainty = instance.horizontalDistanceUncertainty;
			horizontalPositionUncertainty = new ();
			if (instance.horizontalPositionUncertainty != default) {
				horizontalPositionUncertainty.Load(instance.horizontalPositionUncertainty);
			}
			sourceIndication = new ();
			if (instance.sourceIndication != default) {
				sourceIndication.Load(instance.sourceIndication);
			}
			surveyDateRange = new ();
			if (instance.surveyDateRange != default) {
				surveyDateRange.Load(instance.surveyDateRange);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new QualityOfNonBathymetricData {
				information = this.information.Select(e => e.Model).ToList(),
				categoryOfTemporalVariation = this.categoryOfTemporalVariation,
				orientationUncertainty = this.orientationUncertainty,
				horizontalDistanceUncertainty = this.horizontalDistanceUncertainty,
				horizontalPositionUncertainty = this.horizontalPositionUncertainty?.Model,
				sourceIndication = this.sourceIndication?.Model,
				surveyDateRange = this.surveyDateRange?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public QualityOfNonBathymetricData Model => new () {
			information = this.information.Select(e => e.Model).ToList(),
			categoryOfTemporalVariation = this._categoryOfTemporalVariation,
			orientationUncertainty = this._orientationUncertainty,
			horizontalDistanceUncertainty = this._horizontalDistanceUncertainty,
			horizontalPositionUncertainty = this._horizontalPositionUncertainty?.Model,
			sourceIndication = this._sourceIndication?.Model,
			surveyDateRange = this._surveyDateRange?.Model,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => QualityOfNonBathymetricData._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. QualityOfNonBathymetricData._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => QualityOfNonBathymetricData._featureBindingDefinitions;

		public override string? ToString() => $"Quality of Non-Bathymetric Data";

		public QualityOfNonBathymetricDataViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// The Text Placement feature is used in association with the Feature Name attribute or a light description to optimize text positioning in ECDIS.
	/// </summary>
	[CategoryOrder("TextPlacement",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TextPlacementViewModel : FeatureViewModel<TextPlacement> {
		private decimal? _flipBearing  = default;

		[Category("TextPlacement")]
		public decimal? flipBearing {
			get {
				return _flipBearing;
			}
			set {
				SetValue(ref _flipBearing, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("TextPlacement")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private textJustification _textJustification  = default;

		[Category("TextPlacement")]
		[Editor(typeof(Editors.UnknownEditor<textJustification?>), typeof(Editors.UnknownEditor<textJustification?>))]
		[DomainModel.EnumerationAttribute(nameof(textJustificationList), typeof(textJustification))]
		public textJustification textJustification {
			get {
				return _textJustification;
			}
			set {
				SetValue(ref _textJustification, value);
			}
		}

		[Browsable(false)]
		public textJustification[] textJustificationList => [(textJustification)1,(textJustification)2,(textJustification)3];
		private String? _text  = default;

		[Category("TextPlacement")]
		public String? text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
			}
		}
		private textType? _textType  = default;

		[Category("TextPlacement")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(textTypeList), typeof(textType))]
		public textType? textType {
			get {
				return _textType;
			}
			set {
				SetValue(ref _textType, value);
			}
		}

		[Browsable(false)]
		public textType[] textTypeList => [(textType)1];


		public override FeatureViewModel<TextPlacement> Load(TextPlacement instance) {
			flipBearing = instance.flipBearing;
			scaleMinimum = instance.scaleMinimum;
			textJustification = instance.textJustification;
			text = instance.text;
			textType = instance.textType;
			return this;
		}

		public override string Serialize() {
			var instance = new TextPlacement {
				flipBearing = this.flipBearing,
				scaleMinimum = this.scaleMinimum,
				textJustification = this.textJustification,
				text = this.text,
				textType = this.textType,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public TextPlacement Model => new () {
			flipBearing = this._flipBearing,
			scaleMinimum = this._scaleMinimum,
			textJustification = this._textJustification,
			text = this._text,
			textType = this._textType,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => TextPlacement._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. TextPlacement._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => TextPlacement._featureBindingDefinitions;

		public override string? ToString() => $"Text Placement";
	}

}
