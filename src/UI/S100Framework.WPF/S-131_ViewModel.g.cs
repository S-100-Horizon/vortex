using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ComponentModel;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S131;
using S100Framework.DomainModel.S131.ComplexAttributes;
using S100Framework.DomainModel.S131.InformationTypes;
using S100Framework.DomainModel.S131.FeatureTypes;
using S100Framework.DomainModel.S131.InformationAssociations;
using S100Framework.DomainModel.S131.FeatureAssociations;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using System.Text.Json;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.WPF.ViewModel.S131 {
	internal static class Bootstrap {
		public static AssociationViewModel CreateInformationAssociation(string type, string? name = default) => type switch {
			"AdditionalInformation" => new AdditionalInformationViewModel { Name = name },
			"AuthorityContact" => new AuthorityContactViewModel { Name = name },
			"AuthorityHours" => new AuthorityHoursViewModel { Name = name },
			"AssociatedRxN" => new AssociatedRxNViewModel { Name = name },
			"ExceptionalWorkday" => new ExceptionalWorkdayViewModel { Name = name },
			"ServiceControl" => new ServiceControlViewModel { Name = name },
			"ServiceContact" => new ServiceContactViewModel { Name = name },
			"LocationHours" => new LocationHoursViewModel { Name = name },
			"RelatedOrganisation" => new RelatedOrganisationViewModel { Name = name },
			"InclusionType" => new InclusionTypeViewModel { Name = name },
			"PermissionType" => new PermissionTypeViewModel { Name = name },
			"SpatialAssociation" => new SpatialAssociationViewModel { Name = name },
			"LimitEntrance" => new LimitEntranceViewModel { Name = name },
			"ServiceAvailability" => new ServiceAvailabilityViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static AssociationViewModel CreateFeatureAssociation(string type, string? name = default) => type switch {
			"TextAssociation" => new TextAssociationViewModel { Name = name },
			"Subsection" => new SubsectionViewModel { Name = name },
			"Infrastructure" => new InfrastructureViewModel { Name = name },
			"PrimaryAuxiliaryFacility" => new PrimaryAuxiliaryFacilityViewModel { Name = name },
			"Demarcation" => new DemarcationViewModel { Name = name },
			"JurisdictionalLimit" => new JurisdictionalLimitViewModel { Name = name },
			"LayoutDivision" => new LayoutDivisionViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static InformationViewModel CreateInformationType(string type, string? name = default) => type switch {
			"Applicability" => new ApplicabilityViewModel { Name = name },
			"Authority" => new AuthorityViewModel { Name = name },
			"AvailablePortServices" => new AvailablePortServicesViewModel { Name = name },
			"ContactDetails" => new ContactDetailsViewModel { Name = name },
			"Entrance" => new EntranceViewModel { Name = name },
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
			"AnchorBerth" => new AnchorBerthViewModel { Name = name },
			"AnchorageArea" => new AnchorageAreaViewModel { Name = name },
			"AutomatedGuidedVehicle" => new AutomatedGuidedVehicleViewModel { Name = name },
			"Berth" => new BerthViewModel { Name = name },
			"BerthPosition" => new BerthPositionViewModel { Name = name },
			"Bollard" => new BollardViewModel { Name = name },
			"DockArea" => new DockAreaViewModel { Name = name },
			"DryDock" => new DryDockViewModel { Name = name },
			"Dolphin" => new DolphinViewModel { Name = name },
			"DumpingGround" => new DumpingGroundViewModel { Name = name },
			"FenderLine" => new FenderLineViewModel { Name = name },
			"FloatingDock" => new FloatingDockViewModel { Name = name },
			"Gridiron" => new GridironViewModel { Name = name },
			"HarbourAreaAdministrative" => new HarbourAreaAdministrativeViewModel { Name = name },
			"HarbourAreaSection" => new HarbourAreaSectionViewModel { Name = name },
			"HarbourBasin" => new HarbourBasinViewModel { Name = name },
			"LockBasin" => new LockBasinViewModel { Name = name },
			"LockBasinPart" => new LockBasinPartViewModel { Name = name },
			"MooringBuoy" => new MooringBuoyViewModel { Name = name },
			"MooringWarpingFacility" => new MooringWarpingFacilityViewModel { Name = name },
			"OnshorePowerFacility" => new OnshorePowerFacilityViewModel { Name = name },
			"OuterLimit" => new OuterLimitViewModel { Name = name },
			"PilotBoardingPlace" => new PilotBoardingPlaceViewModel { Name = name },
			"SeaplaneLandingArea" => new SeaplaneLandingAreaViewModel { Name = name },
			"ShipLift" => new ShipLiftViewModel { Name = name },
			"StraddleCarrier" => new StraddleCarrierViewModel { Name = name },
			"Terminal" => new TerminalViewModel { Name = name },
			"TurningBasin" => new TurningBasinViewModel { Name = name },
			"WaterwayArea" => new WaterwayAreaViewModel { Name = name },
			"DataCoverage" => new DataCoverageViewModel { Name = name },
			"QualityOfNonBathymetricData" => new QualityOfNonBathymetricDataViewModel { Name = name },
			"SoundingDatum" => new SoundingDatumViewModel { Name = name },
			"VerticalDatumOfData" => new VerticalDatumOfDataViewModel { Name = name },
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
			("ServiceContact", "theContactDetails") => ["ContactDetails"],
			("ServiceControl", "controlAuthority") => ["Authority"],
			("ServiceAvailability", "serviceDescriptionReference") => ["AvailablePortServices"],
			("LocationHours", "facilityOperatingHours") => ["ServiceHours"],
			("LimitEntrance", "entranceReference") => ["Entrance"],
			_ => throw new InvalidOperationException(),
		};

		public static ICollection<string> FeatureAssociationBindings(string association, string role) => (association, role) switch {
			("TextAssociation", "theCartographicText") => ["TextPlacement"],
			("Infrastructure", "infrastructureLocation") => ["HarbourAreaSection","Terminal"],
			("PrimaryAuxiliaryFacility", "auxiliaryFacility") => ["MooringWarpingFacility"],
			("LayoutDivision", "componentOf") => ["HarbourAreaSection","Terminal","HarbourAreaAdministrative"],
			("Demarcation", "demarcationIndicator") => ["BerthPosition"],
			("Demarcation", "demarcatedFeature") => ["Berth"],
			("JurisdictionalLimit", "limitExtent") => ["OuterLimit"],
			("LayoutDivision", "layoutUnit") => ["HarbourAreaSection","AnchorageArea","Berth","DockArea","DumpingGround","FenderLine","HarbourBasin","PilotBoardingPlace","SeaplaneLandingArea","Terminal","TurningBasin","WaterwayArea"],
			("Subsection", "constitute") => ["HarbourAreaSection"],
			("Subsection", "subUnit") => ["HarbourAreaSection"],
			("Infrastructure", "hasInfrastructure") => ["HarbourPhysicalInfrastructure"],
			("PrimaryAuxiliaryFacility", "primaryFacility") => ["AnchorBerth","BerthPosition"],
			("JurisdictionalLimit", "limitReference") => ["HarbourAreaAdministrative"],
			("TextAssociation", "thePositionProvider") => ["FeatureType"],
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
		public cardinalDirection[] cardinalDirectionList => [(cardinalDirection)1,(cardinalDirection)2,(cardinalDirection)3,(cardinalDirection)4,(cardinalDirection)5,(cardinalDirection)6,(cardinalDirection)7,(cardinalDirection)8,(cardinalDirection)9,(cardinalDirection)10,(cardinalDirection)11,(cardinalDirection)12,(cardinalDirection)13,(cardinalDirection)14,(cardinalDirection)15,(cardinalDirection)16];

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

		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private orientationViewModel? _orientation  = default;

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
	/// Description of services related to the goods or items carried by vessels.
	/// </summary>
	[CategoryOrder("cargoServicesDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class cargoServicesDescriptionViewModel : ComplexViewModel<cargoServicesDescription> {
		[Multiplicity(1)]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public cargoServicesDescriptionViewModel Load(cargoServicesDescription instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new cargoServicesDescription {
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public cargoServicesDescription Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"Cargo Services Description";

		public cargoServicesDescriptionViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}


	/// <summary>
	/// A description of construction or other development in a location where the work will affect vessel operations such as navigation, maneuvering or docking/berthing.
	/// </summary>
	[CategoryOrder("constructionInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class constructionInformationViewModel : ComplexViewModel<constructionInformation> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

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

		private condition? _condition  = default;

		[Editor(typeof(Editors.HorizonEditor<constructionInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		[Browsable(false)]
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)5];

		private String _development  = string.Empty;

		[Editor(typeof(Editors.HorizonEditor<constructionInformation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String development {
			get {
				return _development;
			}
			set {
				SetValue(ref _development, value);
			}
		}

		private String? _locationByText  = default;

		[Editor(typeof(Editors.HorizonEditor<constructionInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationByText {
			get {
				return _locationByText;
			}
			set {
				SetValue(ref _locationByText, value);
			}
		}

		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public constructionInformationViewModel Load(constructionInformation instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			condition = instance.condition;
			development = instance.development;
			locationByText = instance.locationByText;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new constructionInformation {
				fixedDateRange = this.fixedDateRange?.Model,
				condition = this.condition,
				development = this.development,
				locationByText = this.locationByText,
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public constructionInformation Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			condition = this._condition,
			development = this._development,
			locationByText = this._locationByText,
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"Construction Information";

		public constructionInformationViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
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
		[Optional]
		public ObservableCollection<String> deliveryPoint  { get; set; } = new ();

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
	/// Textual description of the characteristics and notable matters pertaining to depths in an area.
	/// </summary>
	[CategoryOrder("depthsDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class depthsDescriptionViewModel : ComplexViewModel<depthsDescription> {
		private categoryOfDepthsDescription _categoryOfDepthsDescription  = default;

		[Editor(typeof(Editors.HorizonEditor<depthsDescription>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public categoryOfDepthsDescription categoryOfDepthsDescription {
			get {
				return _categoryOfDepthsDescription;
			}
			set {
				SetValue(ref _categoryOfDepthsDescription, value);
			}
		}

		[Browsable(false)]
		public categoryOfDepthsDescription[] categoryOfDepthsDescriptionList => [(categoryOfDepthsDescription)1,(categoryOfDepthsDescription)2,(categoryOfDepthsDescription)3];

		[Multiplicity(1)]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public depthsDescriptionViewModel Load(depthsDescription instance) {
			categoryOfDepthsDescription = instance.categoryOfDepthsDescription;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new depthsDescription {
				categoryOfDepthsDescription = this.categoryOfDepthsDescription,
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public depthsDescription Model => new () {
			categoryOfDepthsDescription = this._categoryOfDepthsDescription,
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"Depths Description";

		public depthsDescriptionViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}


	/// <summary>
	/// Textual description of the layout of port facilities.
	/// </summary>
	[CategoryOrder("facilitiesLayoutDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class facilitiesLayoutDescriptionViewModel : ComplexViewModel<facilitiesLayoutDescription> {
		[Multiplicity(1)]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public facilitiesLayoutDescriptionViewModel Load(facilitiesLayoutDescription instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new facilitiesLayoutDescription {
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public facilitiesLayoutDescription Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"Facilities Layout Description";

		public facilitiesLayoutDescriptionViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}


	/// <summary>
	/// Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.
	/// </summary>
	[CategoryOrder("featureName",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class featureNameViewModel : ComplexViewModel<featureName> {
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

		private nameUsage? _nameUsage  = default;

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
	[CategoryOrder("fixedDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class fixedDateRangeViewModel : ComplexViewModel<fixedDateRange> {
		private String? _dateStart  = default;

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
	[CategoryOrder("frequencyPair",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class frequencyPairViewModel : ComplexViewModel<frequencyPair> {
		[Optional]
		public ObservableCollection<int> frequencyShoreStationTransmits  { get; set; } = new ();

		[Optional]
		public ObservableCollection<int> frequencyShoreStationReceives  { get; set; } = new ();


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
			return this;
		}

		public override string Serialize() {
			var instance = new frequencyPair {
				frequencyShoreStationTransmits = this.frequencyShoreStationTransmits.ToList(),
				frequencyShoreStationReceives = this.frequencyShoreStationReceives.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public frequencyPair Model => new () {
			frequencyShoreStationTransmits = this.frequencyShoreStationTransmits.ToList(),
			frequencyShoreStationReceives = this.frequencyShoreStationReceives.ToList(),
		};

		public override string? ToString() => $"Frequency Pair";

		public frequencyPairViewModel() : base() {
			frequencyShoreStationTransmits.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(frequencyShoreStationTransmits));
			};
			frequencyShoreStationReceives.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(frequencyShoreStationReceives));
			};
		}
	}


	/// <summary>
	/// General information about the port or harbour area.
	/// </summary>
	[CategoryOrder("generalHarbourInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class generalHarbourInformationViewModel : ComplexViewModel<generalHarbourInformation> {
		private generalPortDescriptionViewModel? _generalPortDescription  = default;

		[ExpandableObject]
		[Optional]
		public generalPortDescriptionViewModel? generalPortDescription {
			get {
				return _generalPortDescription;
			}
			set {
				SetValue(ref _generalPortDescription, value);
			}
		}

		private facilitiesLayoutDescriptionViewModel? _facilitiesLayoutDescription  = default;

		[ExpandableObject]
		[Optional]
		public facilitiesLayoutDescriptionViewModel? facilitiesLayoutDescription {
			get {
				return _facilitiesLayoutDescription;
			}
			set {
				SetValue(ref _facilitiesLayoutDescription, value);
			}
		}

		private limitsDescriptionViewModel? _limitsDescription  = default;

		[ExpandableObject]
		[Optional]
		public limitsDescriptionViewModel? limitsDescription {
			get {
				return _limitsDescription;
			}
			set {
				SetValue(ref _limitsDescription, value);
			}
		}

		private constructionInformationViewModel? _constructionInformation  = default;

		[ExpandableObject]
		[Optional]
		public constructionInformationViewModel? constructionInformation {
			get {
				return _constructionInformation;
			}
			set {
				SetValue(ref _constructionInformation, value);
			}
		}

		private cargoServicesDescriptionViewModel? _cargoServicesDescription  = default;

		[ExpandableObject]
		[Optional]
		public cargoServicesDescriptionViewModel? cargoServicesDescription {
			get {
				return _cargoServicesDescription;
			}
			set {
				SetValue(ref _cargoServicesDescription, value);
			}
		}

		[Optional]
		public ObservableCollection<weatherResourceViewModel> weatherResource  { get; set; } = new ();


		public generalHarbourInformationViewModel Load(generalHarbourInformation instance) {
			generalPortDescription = new ();
			if (instance.generalPortDescription != default) {
				generalPortDescription.Load(instance.generalPortDescription);
			}
			facilitiesLayoutDescription = new ();
			if (instance.facilitiesLayoutDescription != default) {
				facilitiesLayoutDescription.Load(instance.facilitiesLayoutDescription);
			}
			limitsDescription = new ();
			if (instance.limitsDescription != default) {
				limitsDescription.Load(instance.limitsDescription);
			}
			constructionInformation = new ();
			if (instance.constructionInformation != default) {
				constructionInformation.Load(instance.constructionInformation);
			}
			cargoServicesDescription = new ();
			if (instance.cargoServicesDescription != default) {
				cargoServicesDescription.Load(instance.cargoServicesDescription);
			}
			weatherResource.Clear();
			if (instance.weatherResource is not null) {
				foreach(var e in instance.weatherResource)
					weatherResource.Add(new weatherResourceViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new generalHarbourInformation {
				generalPortDescription = this.generalPortDescription?.Model,
				facilitiesLayoutDescription = this.facilitiesLayoutDescription?.Model,
				limitsDescription = this.limitsDescription?.Model,
				constructionInformation = this.constructionInformation?.Model,
				cargoServicesDescription = this.cargoServicesDescription?.Model,
				weatherResource = this.weatherResource.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public generalHarbourInformation Model => new () {
			generalPortDescription = this._generalPortDescription?.Model,
			facilitiesLayoutDescription = this._facilitiesLayoutDescription?.Model,
			limitsDescription = this._limitsDescription?.Model,
			constructionInformation = this._constructionInformation?.Model,
			cargoServicesDescription = this._cargoServicesDescription?.Model,
			weatherResource = this.weatherResource.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"General Harbour Information";

		public generalHarbourInformationViewModel() : base() {
			weatherResource.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(weatherResource));
			};
		}
	}


	/// <summary>
	/// General, introductory information about the port.
	/// </summary>
	[CategoryOrder("generalPortDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class generalPortDescriptionViewModel : ComplexViewModel<generalPortDescription> {
		[Multiplicity(1)]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public generalPortDescriptionViewModel Load(generalPortDescription instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new generalPortDescription {
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public generalPortDescription Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"General Port Description";

		public generalPortDescriptionViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}


	/// <summary>
	/// Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.
	/// </summary>
	[CategoryOrder("graphic",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class graphicViewModel : ComplexViewModel<graphic> {
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
	[CategoryOrder("horizontalPositionUncertainty",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class horizontalPositionUncertaintyViewModel : ComplexViewModel<horizontalPositionUncertainty> {
		private double _uncertaintyFixed  = default;

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

		[Optional]
		public ObservableCollection<String> headline  { get; set; } = new ();

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
	/// Textual description of selected landmarks that have significance in an area.
	/// </summary>
	[CategoryOrder("landmarkDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class landmarkDescriptionViewModel : ComplexViewModel<landmarkDescription> {
		[Multiplicity(1)]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public landmarkDescriptionViewModel Load(landmarkDescription instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new landmarkDescription {
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public landmarkDescription Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"Landmark Description";

		public landmarkDescriptionViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}


	/// <summary>
	/// Description of the area covered by the information specified.
	/// </summary>
	[CategoryOrder("limitsDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class limitsDescriptionViewModel : ComplexViewModel<limitsDescription> {
		[Multiplicity(1)]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public limitsDescriptionViewModel Load(limitsDescription instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new limitsDescription {
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public limitsDescription Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"Limits Description";

		public limitsDescriptionViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}


	/// <summary>
	/// A description of navigationally significant lights essential for marking landfalls, offshore dangers, shipping routes, port access channels or protection of the marine environment.
	/// </summary>
	[CategoryOrder("majorLightDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class majorLightDescriptionViewModel : ComplexViewModel<majorLightDescription> {
		[Multiplicity(1)]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public majorLightDescriptionViewModel Load(majorLightDescription instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new majorLightDescription {
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public majorLightDescription Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"Major Light Description";

		public majorLightDescriptionViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}


	/// <summary>
	/// Description of the aids to navigation used to mark an area or object.
	/// </summary>
	[CategoryOrder("markedBy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class markedByViewModel : ComplexViewModel<markedBy> {
		[Multiplicity(1)]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public markedByViewModel Load(markedBy instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new markedBy {
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public markedBy Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"Marked By";

		public markedByViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}


	/// <summary>
	/// Description of aids to navigation or prominent marks located away from the shore.
	/// </summary>
	[CategoryOrder("offshoreMarkDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class offshoreMarkDescriptionViewModel : ComplexViewModel<offshoreMarkDescription> {
		[Multiplicity(1)]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public offshoreMarkDescriptionViewModel Load(offshoreMarkDescription instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new offshoreMarkDescription {
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public offshoreMarkDescription Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"Offshore Mark Description";

		public offshoreMarkDescriptionViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}


	/// <summary>
	/// Information about online sources from which a resource or data can be obtained.
	/// </summary>
	[CategoryOrder("onlineResource",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class onlineResourceViewModel : ComplexViewModel<onlineResource> {
		private String _linkage  = string.Empty;

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
		public onlineFunction[] onlineFunctionList => [(onlineFunction)1,(onlineFunction)3,(onlineFunction)4,(onlineFunction)5,(onlineFunction)6,(onlineFunction)7,(onlineFunction)8,(onlineFunction)9,(onlineFunction)10,(onlineFunction)11];

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

		[Browsable(false)]
		public categoryOfRxN[] categoryOfRxNList =>  CodeList.categoryOfRxNS.ToArray();

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

		[Browsable(false)]
		public actionOrActivity[] actionOrActivityList =>  CodeList.actionOrActivities.ToArray();

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

		[Multiplicity(1)]
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
	/// Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.
	/// </summary>
	[CategoryOrder("sourceIndication",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sourceIndicationViewModel : ComplexViewModel<sourceIndication> {
		private categoryOfAuthority? _categoryOfAuthority  = default;

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
		public categoryOfAuthority[] categoryOfAuthorityList => Enum.GetValues<categoryOfAuthority>();

		private String? _countryName  = default;

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

		private String? _text  = default;

		[Editor(typeof(Editors.HorizonEditor<sourceIndication>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
			}
		}

		private String? _reportedDate  = default;

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

		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();


		public sourceIndicationViewModel Load(sourceIndication instance) {
			categoryOfAuthority = instance.categoryOfAuthority;
			countryName = instance.countryName;
			source = instance.source;
			text = instance.text;
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
				text = this.text,
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
			text = this._text,
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
	/// Provides an indication of the vertical and horizontal positional uncertainty of bathymetric data, optionally within a specified date range.
	/// </summary>
	[CategoryOrder("spatialAccuracy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class spatialAccuracyViewModel : ComplexViewModel<spatialAccuracy> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

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
	/// The complex attribute describes the period of the hydrographic survey, as the time between its sub-attributes.
	/// </summary>
	[CategoryOrder("surveyDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class surveyDateRangeViewModel : ComplexViewModel<surveyDateRange> {
		private String? _dateStart  = default;

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

		private String? _telecommunicationCarrier  = default;

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

		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private onlineResourceViewModel? _onlineResource  = default;

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
	[CategoryOrder("timeIntervalsByDayOfWeek",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class timeIntervalsByDayOfWeekViewModel : ComplexViewModel<timeIntervalsByDayOfWeek> {
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

		[Optional]
		public ObservableCollection<S100Framework.DomainModel.S100.Time> timeOfDayStart  { get; set; } = new ();

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
	/// Description of Aids to Navigation or prominent marks which are usually clearly visible and identifiable enough to be used in determining location or direction.
	/// </summary>
	[CategoryOrder("usefulMarkDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class usefulMarkDescriptionViewModel : ComplexViewModel<usefulMarkDescription> {
		[Multiplicity(1)]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public usefulMarkDescriptionViewModel Load(usefulMarkDescription instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new usefulMarkDescription {
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public usefulMarkDescription Model => new () {
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"Useful Mark Description";

		public usefulMarkDescriptionViewModel() : base() {
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}


	/// <summary>
	/// The best estimate of the vertical accuracy of depths, heights, vertical distances and vertical clearances.
	/// </summary>
	[CategoryOrder("verticalUncertainty",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class verticalUncertaintyViewModel : ComplexViewModel<verticalUncertainty> {
		private double _uncertaintyFixed  = default;

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
	[CategoryOrder("vesselMeasurementsSpecification",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class vesselMeasurementsSpecificationViewModel : ComplexViewModel<vesselMeasurementsSpecification> {
		private comparisonOperator _comparisonOperator  = default;

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
	/// Links for relevant weather related information.
	/// </summary>
	[CategoryOrder("weatherResource",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class weatherResourceViewModel : ComplexViewModel<weatherResource> {
		private onlineResourceViewModel? _onlineResource  = default;

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

		private dynamicResource? _dynamicResource  = default;

		[Editor(typeof(Editors.HorizonEditor<weatherResource>), typeof(Editors.HorizonEditor))]
		[Optional]
		public dynamicResource? dynamicResource {
			get {
				return _dynamicResource;
			}
			set {
				SetValue(ref _dynamicResource, value);
			}
		}

		[Browsable(false)]
		public dynamicResource[] dynamicResourceList => [(dynamicResource)1,(dynamicResource)2,(dynamicResource)3,(dynamicResource)4];

		private textContentViewModel? _textContent  = default;

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


		public weatherResourceViewModel Load(weatherResource instance) {
			onlineResource = new ();
			if (instance.onlineResource != default) {
				onlineResource.Load(instance.onlineResource);
			}
			dynamicResource = instance.dynamicResource;
			textContent = new ();
			if (instance.textContent != default) {
				textContent.Load(instance.textContent);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new weatherResource {
				onlineResource = this.onlineResource?.Model,
				dynamicResource = this.dynamicResource,
				textContent = this.textContent?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public weatherResource Model => new () {
			onlineResource = this._onlineResource?.Model,
			dynamicResource = this._dynamicResource,
			textContent = this._textContent?.Model,
		};

		public override string? ToString() => $"Weather Resource";
	}



	/// <summary>
	/// A feature association for the binding between at least one instance of a geo feature and an instance of an information type.
	/// </summary>
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
	/// Contact details for a service or facility
	/// </summary>
	[CategoryOrder("ServiceContact",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceContactViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new ServiceContact {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Service contact";
	}



	/// <summary>
	/// Working hours for a service or facility described by a geographic location
	/// </summary>
	[CategoryOrder("LocationHours",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LocationHoursViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new LocationHours {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Location hours";
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
	/// An association for the binding between a spatial type and its spatial quality information.
	/// </summary>
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
	/// Association between a limit feature and the entrance for the limit.
	/// </summary>
	[CategoryOrder("LimitEntrance",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LimitEntranceViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new LimitEntrance {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Limit Entrance";
	}



	/// <summary>
	/// The services available within a location.
	/// </summary>
	[CategoryOrder("ServiceAvailability",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceAvailabilityViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new ServiceAvailability {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Service Availability";
	}



	/// <summary>
	/// A feature association for the binding between a geo feature and the cartographically positioned location for text.
	/// </summary>
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
	/// A division of a feature into parts of the same type as the whole.
	/// </summary>
	[CategoryOrder("Subsection",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SubsectionViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new Subsection {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Subsection";
	}



	/// <summary>
	/// The infrastructure facilities in an area.
	/// </summary>
	[CategoryOrder("Infrastructure",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class InfrastructureViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new Infrastructure {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Infrastructure";
	}



	/// <summary>
	/// Describes the relationship between a primary feature and a feature that plays a supporting role in the use of the primary facility by a vessel.
	/// </summary>
	[CategoryOrder("PrimaryAuxiliaryFacility",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PrimaryAuxiliaryFacilityViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new PrimaryAuxiliaryFacility {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Primary/Auxiliary Facility";
	}



	/// <summary>
	/// Demarcation of location(s) within a feature by relation to another feature or features
	/// </summary>
	[CategoryOrder("Demarcation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DemarcationViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new Demarcation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Demarcation";
	}



	/// <summary>
	/// The limit(s) of a jurisdiction claimed by a coastal State.
	/// </summary>
	[CategoryOrder("JurisdictionalLimit",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class JurisdictionalLimitViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new JurisdictionalLimit {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Jurisdictional Limit";
	}



	/// <summary>
	/// A division of a feature into parts of type(s) different from the type of the whole.
	/// </summary>
	[CategoryOrder("LayoutDivision",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LayoutDivisionViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new LayoutDivision {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Layout Division";
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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

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
		public categoryOfCargo[] categoryOfCargoList => [(categoryOfCargo)2,(categoryOfCargo)5,(categoryOfCargo)6,(categoryOfCargo)7,(categoryOfCargo)8,(categoryOfCargo)10,(categoryOfCargo)11,(categoryOfCargo)12,(categoryOfCargo)13,(categoryOfCargo)14,(categoryOfCargo)15];

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

		private String? _destination  = default;

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

		[Category("Applicability")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("Applicability")]
		[Optional]
		public ObservableCollection<vesselMeasurementsSpecificationViewModel> vesselMeasurementsSpecification  { get; set; } = new ();


		#region InformationBindings

		public class InclusionTypeViewModel : informationBindingViewModel<S131.InclusionTypeViewModel>, IInformationBindings {
			public InclusionTypeViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

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

		private textContentViewModel? _textContent  = default;

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

		public class AuthorityContactViewModel : informationBindingViewModel<S131.AuthorityContactViewModel>, IInformationBindings {
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

		public class RelatedOrganisationViewModel : informationBindingViewModel<S131.RelatedOrganisationViewModel>, IInformationBindings {
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

		public class AuthorityHoursViewModel : informationBindingViewModel<S131.AuthorityHoursViewModel>, IInformationBindings {
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
	/// Services that are available for a given port.
	/// </summary>
	[CategoryOrder("AvailablePortServices",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AvailablePortServicesViewModel : InformationViewModel<AvailablePortServices> {
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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		[Category("AvailablePortServices")]
		[Optional]
		public ObservableCollection<firefightingService> firefightingService  { get; set; } = new ();

		[Browsable(false)]
		public firefightingService[] firefightingServiceList => [(firefightingService)1,(firefightingService)2,(firefightingService)3];

		[Category("AvailablePortServices")]
		[Optional]
		public ObservableCollection<medicalService> medicalService  { get; set; } = new ();

		[Browsable(false)]
		public medicalService[] medicalServiceList => [(medicalService)1,(medicalService)2,(medicalService)3,(medicalService)4,(medicalService)5];

		[Category("AvailablePortServices")]
		[Optional]
		public ObservableCollection<repairService> repairService  { get; set; } = new ();

		[Browsable(false)]
		public repairService[] repairServiceList => [(repairService)1,(repairService)2,(repairService)3,(repairService)4,(repairService)5,(repairService)6,(repairService)7,(repairService)8,(repairService)9,(repairService)10];

		[Category("AvailablePortServices")]
		[Optional]
		public ObservableCollection<technicalPortService> technicalPortService  { get; set; } = new ();

		[Browsable(false)]
		public technicalPortService[] technicalPortServiceList => [(technicalPortService)1,(technicalPortService)2,(technicalPortService)3,(technicalPortService)4];

		[Category("AvailablePortServices")]
		[Optional]
		public ObservableCollection<shipSanitationControl> shipSanitationControl  { get; set; } = new ();

		[Browsable(false)]
		public shipSanitationControl[] shipSanitationControlList => [(shipSanitationControl)1,(shipSanitationControl)2,(shipSanitationControl)3];

		[Category("AvailablePortServices")]
		[Optional]
		public ObservableCollection<transportConnection> transportConnection  { get; set; } = new ();

		[Browsable(false)]
		public transportConnection[] transportConnectionList =>  CodeList.transportConnections.ToArray();

		[Category("AvailablePortServices")]
		[Optional]
		public ObservableCollection<berthingAssistance> berthingAssistance  { get; set; } = new ();

		[Browsable(false)]
		public berthingAssistance[] berthingAssistanceList => [(berthingAssistance)1,(berthingAssistance)2,(berthingAssistance)3,(berthingAssistance)4,(berthingAssistance)5,(berthingAssistance)6];

		[Category("AvailablePortServices")]
		[Optional]
		public ObservableCollection<cargoService> cargoService  { get; set; } = new ();

		[Browsable(false)]
		public cargoService[] cargoServiceList => [(cargoService)1,(cargoService)2,(cargoService)3,(cargoService)4];

		[Category("AvailablePortServices")]
		[Optional]
		public ObservableCollection<securitySafetyEmergencyService> securitySafetyEmergencyService  { get; set; } = new ();

		[Browsable(false)]
		public securitySafetyEmergencyService[] securitySafetyEmergencyServiceList =>  CodeList.securitySafetyEmergencyServices.ToArray();

		[Category("AvailablePortServices")]
		[Optional]
		public ObservableCollection<wasteDisposalService> wasteDisposalService  { get; set; } = new ();

		[Browsable(false)]
		public wasteDisposalService[] wasteDisposalServiceList => [(wasteDisposalService)1,(wasteDisposalService)2,(wasteDisposalService)3,(wasteDisposalService)4,(wasteDisposalService)5,(wasteDisposalService)6,(wasteDisposalService)7,(wasteDisposalService)8,(wasteDisposalService)9,(wasteDisposalService)10,(wasteDisposalService)11,(wasteDisposalService)12,(wasteDisposalService)13,(wasteDisposalService)14,(wasteDisposalService)15,(wasteDisposalService)16,(wasteDisposalService)17,(wasteDisposalService)18,(wasteDisposalService)19,(wasteDisposalService)20,(wasteDisposalService)21,(wasteDisposalService)22,(wasteDisposalService)23,(wasteDisposalService)24];

		[Category("AvailablePortServices")]
		[Optional]
		public ObservableCollection<supplyService> supplyService  { get; set; } = new ();

		[Browsable(false)]
		public supplyService[] supplyServiceList => [(supplyService)1,(supplyService)2,(supplyService)3,(supplyService)4,(supplyService)5,(supplyService)6,(supplyService)7,(supplyService)8,(supplyService)9,(supplyService)10];

		private String? _tugInformation  = default;

		[Category("AvailablePortServices")]
		[Editor(typeof(Editors.HorizonEditor<AvailablePortServices>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? tugInformation {
			get {
				return _tugInformation;
			}
			set {
				SetValue(ref _tugInformation, value);
			}
		}

		[Category("AvailablePortServices")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		public AvailablePortServicesViewModel Load(AvailablePortServices instance) {
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
			firefightingService.Clear();
			if (instance.firefightingService is not null) {
				foreach(var e in instance.firefightingService)
					firefightingService.Add(e);
			}
			medicalService.Clear();
			if (instance.medicalService is not null) {
				foreach(var e in instance.medicalService)
					medicalService.Add(e);
			}
			repairService.Clear();
			if (instance.repairService is not null) {
				foreach(var e in instance.repairService)
					repairService.Add(e);
			}
			technicalPortService.Clear();
			if (instance.technicalPortService is not null) {
				foreach(var e in instance.technicalPortService)
					technicalPortService.Add(e);
			}
			shipSanitationControl.Clear();
			if (instance.shipSanitationControl is not null) {
				foreach(var e in instance.shipSanitationControl)
					shipSanitationControl.Add(e);
			}
			transportConnection.Clear();
			if (instance.transportConnection is not null) {
				foreach(var e in instance.transportConnection)
					transportConnection.Add(e);
			}
			berthingAssistance.Clear();
			if (instance.berthingAssistance is not null) {
				foreach(var e in instance.berthingAssistance)
					berthingAssistance.Add(e);
			}
			cargoService.Clear();
			if (instance.cargoService is not null) {
				foreach(var e in instance.cargoService)
					cargoService.Add(e);
			}
			securitySafetyEmergencyService.Clear();
			if (instance.securitySafetyEmergencyService is not null) {
				foreach(var e in instance.securitySafetyEmergencyService)
					securitySafetyEmergencyService.Add(e);
			}
			wasteDisposalService.Clear();
			if (instance.wasteDisposalService is not null) {
				foreach(var e in instance.wasteDisposalService)
					wasteDisposalService.Add(e);
			}
			supplyService.Clear();
			if (instance.supplyService is not null) {
				foreach(var e in instance.supplyService)
					supplyService.Add(e);
			}
			tugInformation = instance.tugInformation;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new AvailablePortServices {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AvailablePortServices Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => AvailablePortServices._informationBindingDefinitions;

		public AvailablePortServicesViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Available Port Services";

		public AvailablePortServicesViewModel() : base() {
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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

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

		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<String> language  { get; set; } = new ();

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
		public ObservableCollection<contactAddressViewModel> contactAddress  { get; set; } = new ();

		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<frequencyPairViewModel> frequencyPair  { get; set; } = new ();

		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<onlineResourceViewModel> onlineResource  { get; set; } = new ();

		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<telecommunicationsViewModel> telecommunications  { get; set; } = new ();


		#region InformationBindings

		public class AuthorityContactViewModel : informationBindingViewModel<S131.AuthorityContactViewModel>, IInformationBindings {
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
	/// The seaward end of a channel, harbour, dock, etc.
	/// </summary>
	[CategoryOrder("Entrance",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class EntranceViewModel : InformationViewModel<Entrance> {
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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		private String? _entranceDescription  = default;

		[Category("Entrance")]
		[Editor(typeof(Editors.HorizonEditor<Entrance>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? entranceDescription {
			get {
				return _entranceDescription;
			}
			set {
				SetValue(ref _entranceDescription, value);
			}
		}

		[Category("Entrance")]
		[Optional]
		public ObservableCollection<String> associatedFeatureName  { get; set; } = new ();

		private String? _localKnowledgeDescription  = default;

		[Category("Entrance")]
		[Editor(typeof(Editors.HorizonEditor<Entrance>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? localKnowledgeDescription {
			get {
				return _localKnowledgeDescription;
			}
			set {
				SetValue(ref _localKnowledgeDescription, value);
			}
		}

		private String? _approachDescription  = default;

		[Category("Entrance")]
		[Editor(typeof(Editors.HorizonEditor<Entrance>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? approachDescription {
			get {
				return _approachDescription;
			}
			set {
				SetValue(ref _approachDescription, value);
			}
		}

		[Category("Entrance")]
		[Optional]
		public ObservableCollection<markedByViewModel> markedBy  { get; set; } = new ();

		[Category("Entrance")]
		[Optional]
		public ObservableCollection<landmarkDescriptionViewModel> landmarkDescription  { get; set; } = new ();

		[Category("Entrance")]
		[Optional]
		public ObservableCollection<offshoreMarkDescriptionViewModel> offshoreMarkDescription  { get; set; } = new ();

		[Category("Entrance")]
		[Optional]
		public ObservableCollection<majorLightDescriptionViewModel> majorLightDescription  { get; set; } = new ();

		[Category("Entrance")]
		[Optional]
		public ObservableCollection<usefulMarkDescriptionViewModel> usefulMarkDescription  { get; set; } = new ();

		[Category("Entrance")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		public EntranceViewModel Load(Entrance instance) {
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
			entranceDescription = instance.entranceDescription;
			associatedFeatureName.Clear();
			if (instance.associatedFeatureName is not null) {
				foreach(var e in instance.associatedFeatureName)
					associatedFeatureName.Add(e);
			}
			localKnowledgeDescription = instance.localKnowledgeDescription;
			approachDescription = instance.approachDescription;
			markedBy.Clear();
			if (instance.markedBy is not null) {
				foreach(var e in instance.markedBy)
					markedBy.Add(new markedByViewModel().Load(e));
			}
			landmarkDescription.Clear();
			if (instance.landmarkDescription is not null) {
				foreach(var e in instance.landmarkDescription)
					landmarkDescription.Add(new landmarkDescriptionViewModel().Load(e));
			}
			offshoreMarkDescription.Clear();
			if (instance.offshoreMarkDescription is not null) {
				foreach(var e in instance.offshoreMarkDescription)
					offshoreMarkDescription.Add(new offshoreMarkDescriptionViewModel().Load(e));
			}
			majorLightDescription.Clear();
			if (instance.majorLightDescription is not null) {
				foreach(var e in instance.majorLightDescription)
					majorLightDescription.Add(new majorLightDescriptionViewModel().Load(e));
			}
			usefulMarkDescription.Clear();
			if (instance.usefulMarkDescription is not null) {
				foreach(var e in instance.usefulMarkDescription)
					usefulMarkDescription.Add(new usefulMarkDescriptionViewModel().Load(e));
			}
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Entrance {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				entranceDescription = this.entranceDescription,
				associatedFeatureName = this.associatedFeatureName.ToList(),
				localKnowledgeDescription = this.localKnowledgeDescription,
				approachDescription = this.approachDescription,
				markedBy = this.markedBy.Select(e => e.Model).ToList(),
				landmarkDescription = this.landmarkDescription.Select(e => e.Model).ToList(),
				offshoreMarkDescription = this.offshoreMarkDescription.Select(e => e.Model).ToList(),
				majorLightDescription = this.majorLightDescription.Select(e => e.Model).ToList(),
				usefulMarkDescription = this.usefulMarkDescription.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Entrance Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			entranceDescription = this._entranceDescription,
			associatedFeatureName = this.associatedFeatureName.ToList(),
			localKnowledgeDescription = this._localKnowledgeDescription,
			approachDescription = this._approachDescription,
			markedBy = this.markedBy.Select(e => e.Model).ToList(),
			landmarkDescription = this.landmarkDescription.Select(e => e.Model).ToList(),
			offshoreMarkDescription = this.offshoreMarkDescription.Select(e => e.Model).ToList(),
			majorLightDescription = this.majorLightDescription.Select(e => e.Model).ToList(),
			usefulMarkDescription = this.usefulMarkDescription.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Entrance._informationBindingDefinitions;

		public EntranceViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Entrance";

		public EntranceViewModel() : base() {
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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

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

		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		[Category("NonStandardWorkingDay")]
		[Optional]
		public ObservableCollection<String> dateFixed  { get; set; } = new ();

		[Category("NonStandardWorkingDay")]
		[Optional]
		public ObservableCollection<String> dateVariable  { get; set; } = new ();

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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

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

		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

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

		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

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

		[Category("AbstractRxN")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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

		[Category("InformationType")]
		[Optional]
		public ObservableCollection<sourceIndicationViewModel> sourceIndication  { get; set; } = new ();

		[Category("ServiceHours")]
		[Multiplicity(1)]
		public ObservableCollection<scheduleByDayOfWeekViewModel> scheduleByDayOfWeek  { get; set; } = new ();

		[Category("ServiceHours")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		#region InformationBindings

		public class ExceptionalWorkdayViewModel : informationBindingViewModel<S131.ExceptionalWorkdayViewModel>, IInformationBindings {
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

		public class AuthorityHoursViewModel : informationBindingViewModel<S131.AuthorityHoursViewModel>, IInformationBindings {
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
	[CategoryOrder("SpatialQuality",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SpatialQualityViewModel : InformationViewModel<SpatialQuality> {
		private qualityOfHorizontalMeasurement? _qualityOfHorizontalMeasurement  = default;

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

		public override informationBindingDefinition[] informationBindingDefinitions => SpatialQuality._informationBindingDefinitions;

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
	/// A designated area of water where a vessel, sea plane, etc., may anchor.
	/// </summary>
	[CategoryOrder("AnchorBerth",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AnchorBerthViewModel : FeatureViewModel<AnchorBerth> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		[Category("AnchorBerth")]
		[Optional]
		public ObservableCollection<categoryOfAnchorage> categoryOfAnchorage  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfAnchorage[] categoryOfAnchorageList => [(categoryOfAnchorage)1,(categoryOfAnchorage)2,(categoryOfAnchorage)3,(categoryOfAnchorage)5,(categoryOfAnchorage)6,(categoryOfAnchorage)7,(categoryOfAnchorage)9,(categoryOfAnchorage)10,(categoryOfAnchorage)14];

		[Category("AnchorBerth")]
		[Optional]
		public ObservableCollection<categoryOfCargo> categoryOfCargo  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfCargo[] categoryOfCargoList => [(categoryOfCargo)1,(categoryOfCargo)2,(categoryOfCargo)3,(categoryOfCargo)4,(categoryOfCargo)5,(categoryOfCargo)6,(categoryOfCargo)7,(categoryOfCargo)8,(categoryOfCargo)9,(categoryOfCargo)10,(categoryOfCargo)11,(categoryOfCargo)12,(categoryOfCargo)13,(categoryOfCargo)14,(categoryOfCargo)15];

		private double? _radius  = default;

		[Category("AnchorBerth")]
		[Editor(typeof(Editors.HorizonEditor<AnchorBerth>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? radius {
			get {
				return _radius;
			}
			set {
				SetValue(ref _radius, value);
			}
		}


		#region InformationBindings

		public class ServiceAvailabilityViewModel : informationBindingViewModel<S131.ServiceAvailabilityViewModel>, IInformationBindings {
			public ServiceAvailabilityViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "ServiceAvailability",
					role = "serviceDescriptionReference",
					roleType = roleType.association,
					informationTypes = ["AvailablePortServices"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceAvailability> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceAvailability,
			};
		}

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<AnchorBerthViewModel.ServiceAvailabilityViewModel> ServiceAvailabilities { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<AnchorBerthViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. ServiceAvailabilities.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class PrimaryAuxiliaryFacilityViewModel : featureBindingViewModel<S131.PrimaryAuxiliaryFacilityViewModel>, IFeatureBindings {
			public PrimaryAuxiliaryFacilityViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 0,
					upper = default,
					association = "PrimaryAuxiliaryFacility",
					role = "auxiliaryFacility",
					roleType = roleType.association,
					featureTypes = ["MooringWarpingFacility"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<PrimaryAuxiliaryFacility> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = PrimaryAuxiliaryFacility,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<AnchorBerthViewModel.PrimaryAuxiliaryFacilityViewModel> PrimaryAuxiliaryFacilities { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. PrimaryAuxiliaryFacilities.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public AnchorBerthViewModel Load(AnchorBerth instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			categoryOfAnchorage.Clear();
			if (instance.categoryOfAnchorage is not null) {
				foreach(var e in instance.categoryOfAnchorage)
					categoryOfAnchorage.Add(e);
			}
			categoryOfCargo.Clear();
			if (instance.categoryOfCargo is not null) {
				foreach(var e in instance.categoryOfCargo)
					categoryOfCargo.Add(e);
			}
			radius = instance.radius;
			return this;
		}

		public override string Serialize() {
			var instance = new AnchorBerth {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				categoryOfAnchorage = this.categoryOfAnchorage.ToList(),
				categoryOfCargo = this.categoryOfCargo.ToList(),
				radius = this.radius,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AnchorBerth Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfAnchorage = this.categoryOfAnchorage.ToList(),
			categoryOfCargo = this.categoryOfCargo.ToList(),
			radius = this._radius,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => AnchorBerth._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. AnchorBerth._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => AnchorBerth._featureBindingDefinitions;

		public AnchorBerthViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public AnchorBerthViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Anchor Berth";

		public AnchorBerthViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			categoryOfAnchorage.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfAnchorage));
			};
			categoryOfCargo.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfCargo));
			};
			ServiceAvailabilities.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceAvailabilities));
			};
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			PrimaryAuxiliaryFacilities.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(PrimaryAuxiliaryFacilities));
			};
		}
	}



	/// <summary>
	/// An area in which vessels or seaplanes anchor or may anchor.
	/// </summary>
	[CategoryOrder("AnchorageArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AnchorageAreaViewModel : FeatureViewModel<AnchorageArea> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		[Category("AnchorageArea")]
		[Optional]
		public ObservableCollection<categoryOfAnchorage> categoryOfAnchorage  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfAnchorage[] categoryOfAnchorageList => [(categoryOfAnchorage)1,(categoryOfAnchorage)2,(categoryOfAnchorage)3,(categoryOfAnchorage)5,(categoryOfAnchorage)6,(categoryOfAnchorage)7,(categoryOfAnchorage)9,(categoryOfAnchorage)10,(categoryOfAnchorage)14,(categoryOfAnchorage)15];

		private iSPSLevel? _iSPSLevel  = default;

		[Category("AnchorageArea")]
		[Editor(typeof(Editors.HorizonEditor<AnchorageArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public iSPSLevel? iSPSLevel {
			get {
				return _iSPSLevel;
			}
			set {
				SetValue(ref _iSPSLevel, value);
			}
		}

		[Browsable(false)]
		public iSPSLevel[] iSPSLevelList => [(iSPSLevel)1,(iSPSLevel)2,(iSPSLevel)3];

		[Category("AnchorageArea")]
		[Optional]
		public ObservableCollection<categoryOfCargo> categoryOfCargo  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfCargo[] categoryOfCargoList => [(categoryOfCargo)1,(categoryOfCargo)2,(categoryOfCargo)3,(categoryOfCargo)4,(categoryOfCargo)5,(categoryOfCargo)6,(categoryOfCargo)7,(categoryOfCargo)8,(categoryOfCargo)9,(categoryOfCargo)10,(categoryOfCargo)11,(categoryOfCargo)12,(categoryOfCargo)13,(categoryOfCargo)14,(categoryOfCargo)15];

		private String? _locationByText  = default;

		[Category("AnchorageArea")]
		[Editor(typeof(Editors.HorizonEditor<AnchorageArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationByText {
			get {
				return _locationByText;
			}
			set {
				SetValue(ref _locationByText, value);
			}
		}

		private depthsDescriptionViewModel? _depthsDescription  = default;

		[Category("AnchorageArea")]
		[ExpandableObject]
		[Optional]
		public depthsDescriptionViewModel? depthsDescription {
			get {
				return _depthsDescription;
			}
			set {
				SetValue(ref _depthsDescription, value);
			}
		}

		private markedByViewModel? _markedBy  = default;

		[Category("AnchorageArea")]
		[ExpandableObject]
		[Optional]
		public markedByViewModel? markedBy {
			get {
				return _markedBy;
			}
			set {
				SetValue(ref _markedBy, value);
			}
		}


		#region InformationBindings

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<AnchorageAreaViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class LayoutDivisionViewModel : featureBindingViewModel<S131.LayoutDivisionViewModel>, IFeatureBindings {
			public LayoutDivisionViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 1,
					upper = 1,
					association = "LayoutDivision",
					role = "componentOf",
					roleType = roleType.aggregation,
					featureTypes = ["HarbourAreaSection"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<LayoutDivision> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LayoutDivision,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<AnchorageAreaViewModel.LayoutDivisionViewModel> LayoutDivisions { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. LayoutDivisions.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public AnchorageAreaViewModel Load(AnchorageArea instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			categoryOfAnchorage.Clear();
			if (instance.categoryOfAnchorage is not null) {
				foreach(var e in instance.categoryOfAnchorage)
					categoryOfAnchorage.Add(e);
			}
			iSPSLevel = instance.iSPSLevel;
			categoryOfCargo.Clear();
			if (instance.categoryOfCargo is not null) {
				foreach(var e in instance.categoryOfCargo)
					categoryOfCargo.Add(e);
			}
			locationByText = instance.locationByText;
			depthsDescription = new ();
			if (instance.depthsDescription != default) {
				depthsDescription.Load(instance.depthsDescription);
			}
			markedBy = new ();
			if (instance.markedBy != default) {
				markedBy.Load(instance.markedBy);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new AnchorageArea {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				categoryOfAnchorage = this.categoryOfAnchorage.ToList(),
				iSPSLevel = this.iSPSLevel,
				categoryOfCargo = this.categoryOfCargo.ToList(),
				locationByText = this.locationByText,
				depthsDescription = this.depthsDescription?.Model,
				markedBy = this.markedBy?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AnchorageArea Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfAnchorage = this.categoryOfAnchorage.ToList(),
			iSPSLevel = this._iSPSLevel,
			categoryOfCargo = this.categoryOfCargo.ToList(),
			locationByText = this._locationByText,
			depthsDescription = this._depthsDescription?.Model,
			markedBy = this._markedBy?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => AnchorageArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. AnchorageArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => AnchorageArea._featureBindingDefinitions;

		public AnchorageAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public AnchorageAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Anchorage Area";

		public AnchorageAreaViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			categoryOfAnchorage.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfAnchorage));
			};
			categoryOfCargo.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfCargo));
			};
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			LayoutDivisions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(LayoutDivisions));
			};
		}
	}



	/// <summary>
	/// Equipment with material handling or operational capabilities, characterised by wheeled (including tracked) mobility, and which autonomously moves along a preset route based on environmental markers or external guidance signals.
	/// </summary>
	[CategoryOrder("AutomatedGuidedVehicle",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AutomatedGuidedVehicleViewModel : FeatureViewModel<AutomatedGuidedVehicle> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();






		#region InformationBindings

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<AutomatedGuidedVehicleViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public AutomatedGuidedVehicleViewModel Load(AutomatedGuidedVehicle instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new AutomatedGuidedVehicle {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AutomatedGuidedVehicle Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => AutomatedGuidedVehicle._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. AutomatedGuidedVehicle._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => AutomatedGuidedVehicle._featureBindingDefinitions;

		public AutomatedGuidedVehicleViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public AutomatedGuidedVehicleViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Automated Guided Vehicle";

		public AutomatedGuidedVehicleViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
		}
	}



	/// <summary>
	/// A place, generally named or numbered, where a vessel may moor or anchor.
	/// </summary>
	[CategoryOrder("Berth",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BerthViewModel : FeatureViewModel<Berth> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private double? _availableBerthingLength  = default;

		[Category("Berth")]
		[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? availableBerthingLength {
			get {
				return _availableBerthingLength;
			}
			set {
				SetValue(ref _availableBerthingLength, value);
			}
		}

		private String? _bollardDescription  = default;

		[Category("Berth")]
		[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? bollardDescription {
			get {
				return _bollardDescription;
			}
			set {
				SetValue(ref _bollardDescription, value);
			}
		}

		private double? _safeWorkingLoad  = default;

		[Category("Berth")]
		[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? safeWorkingLoad {
			get {
				return _safeWorkingLoad;
			}
			set {
				SetValue(ref _safeWorkingLoad, value);
			}
		}

		private double? _minimumBerthDepth  = default;

		[Category("Berth")]
		[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? minimumBerthDepth {
			get {
				return _minimumBerthDepth;
			}
			set {
				SetValue(ref _minimumBerthDepth, value);
			}
		}

		private double? _elevation  = default;

		[Category("Berth")]
		[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}

		private Boolean? _cathodicProtectionSystem  = default;

		[Category("Berth")]
		[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? cathodicProtectionSystem {
			get {
				return _cathodicProtectionSystem;
			}
			set {
				SetValue(ref _cathodicProtectionSystem, value);
			}
		}

		private categoryOfBerthLocation? _categoryOfBerthLocation  = default;

		[Category("Berth")]
		[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfBerthLocation? categoryOfBerthLocation {
			get {
				return _categoryOfBerthLocation;
			}
			set {
				SetValue(ref _categoryOfBerthLocation, value);
			}
		}

		[Browsable(false)]
		public categoryOfBerthLocation[] categoryOfBerthLocationList => [(categoryOfBerthLocation)1,(categoryOfBerthLocation)2,(categoryOfBerthLocation)3,(categoryOfBerthLocation)4];

		private String? _portFacilityNumber  = default;

		[Category("Berth")]
		[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? portFacilityNumber {
			get {
				return _portFacilityNumber;
			}
			set {
				SetValue(ref _portFacilityNumber, value);
			}
		}

		[Category("Berth")]
		[Multiplicity(0, 2)]
		public ObservableCollection<String> bollardNumber  { get; set; } = new ();

		private String? _gLNExtension  = default;

		[Category("Berth")]
		[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? gLNExtension {
			get {
				return _gLNExtension;
			}
			set {
				SetValue(ref _gLNExtension, value);
			}
		}

		[Category("Berth")]
		[Multiplicity(0, 2)]
		public ObservableCollection<String> metreMarkNumber  { get; set; } = new ();

		[Category("Berth")]
		[Multiplicity(0, 2)]
		public ObservableCollection<String> manifoldNumber  { get; set; } = new ();

		private String? _rampNumber  = default;

		[Category("Berth")]
		[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? rampNumber {
			get {
				return _rampNumber;
			}
			set {
				SetValue(ref _rampNumber, value);
			}
		}

		private String? _locationByText  = default;

		[Category("Berth")]
		[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationByText {
			get {
				return _locationByText;
			}
			set {
				SetValue(ref _locationByText, value);
			}
		}

		private methodOfSecuring? _methodOfSecuring  = default;

		[Category("Berth")]
		[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
		[Optional]
		public methodOfSecuring? methodOfSecuring {
			get {
				return _methodOfSecuring;
			}
			set {
				SetValue(ref _methodOfSecuring, value);
			}
		}

		[Browsable(false)]
		public methodOfSecuring[] methodOfSecuringList => [(methodOfSecuring)1,(methodOfSecuring)2,(methodOfSecuring)3,(methodOfSecuring)4,(methodOfSecuring)5,(methodOfSecuring)6,(methodOfSecuring)7,(methodOfSecuring)8,(methodOfSecuring)9,(methodOfSecuring)10];

		private String _uNLocationCode  = string.Empty;

		[Category("Berth")]
		[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String uNLocationCode {
			get {
				return _uNLocationCode;
			}
			set {
				SetValue(ref _uNLocationCode, value);
			}
		}

		private String? _terminalIdentifier  = default;

		[Category("Berth")]
		[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? terminalIdentifier {
			get {
				return _terminalIdentifier;
			}
			set {
				SetValue(ref _terminalIdentifier, value);
			}
		}

		private String? _shorePowerDescription  = default;

		[Category("Berth")]
		[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? shorePowerDescription {
			get {
				return _shorePowerDescription;
			}
			set {
				SetValue(ref _shorePowerDescription, value);
			}
		}

		[Category("Berth")]
		[Optional]
		public ObservableCollection<categoryOfFrequency> categoryOfFrequency  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfFrequency[] categoryOfFrequencyList => [(categoryOfFrequency)1,(categoryOfFrequency)2];

		[Category("Berth")]
		[Optional]
		public ObservableCollection<categoryOfVoltage> categoryOfVoltage  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfVoltage[] categoryOfVoltageList => [(categoryOfVoltage)1,(categoryOfVoltage)2,(categoryOfVoltage)3,(categoryOfVoltage)4,(categoryOfVoltage)5,(categoryOfVoltage)6,(categoryOfVoltage)7,(categoryOfVoltage)8,(categoryOfVoltage)9,(categoryOfVoltage)10,(categoryOfVoltage)11,(categoryOfVoltage)12,(categoryOfVoltage)13,(categoryOfVoltage)14];

		[Category("Berth")]
		[Optional]
		public ObservableCollection<String> categoryOfPlug  { get; set; } = new ();

		[Category("Berth")]
		[Optional]
		public ObservableCollection<categoryOfCargo> categoryOfCargo  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfCargo[] categoryOfCargoList => [(categoryOfCargo)1,(categoryOfCargo)2,(categoryOfCargo)3,(categoryOfCargo)4,(categoryOfCargo)5,(categoryOfCargo)6,(categoryOfCargo)7,(categoryOfCargo)8,(categoryOfCargo)9,(categoryOfCargo)10,(categoryOfCargo)11,(categoryOfCargo)12,(categoryOfCargo)13,(categoryOfCargo)14,(categoryOfCargo)15];


		#region InformationBindings

		public class ServiceAvailabilityViewModel : informationBindingViewModel<S131.ServiceAvailabilityViewModel>, IInformationBindings {
			public ServiceAvailabilityViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "ServiceAvailability",
					role = "serviceDescriptionReference",
					roleType = roleType.association,
					informationTypes = ["AvailablePortServices"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceAvailability> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceAvailability,
			};
		}

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<BerthViewModel.ServiceAvailabilityViewModel> ServiceAvailabilities { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<BerthViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. ServiceAvailabilities.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class DemarcationViewModel : featureBindingViewModel<S131.DemarcationViewModel>, IFeatureBindings {
			public DemarcationViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 0,
					upper = default,
					association = "Demarcation",
					role = "demarcationIndicator",
					roleType = roleType.association,
					featureTypes = ["BerthPosition"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<Demarcation> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = Demarcation,
			};
		}

		public class LayoutDivisionViewModel : featureBindingViewModel<S131.LayoutDivisionViewModel>, IFeatureBindings {
			public LayoutDivisionViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 1,
					upper = 1,
					association = "LayoutDivision",
					role = "componentOf",
					roleType = roleType.aggregation,
					featureTypes = ["HarbourAreaSection","Terminal"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<LayoutDivision> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LayoutDivision,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<BerthViewModel.DemarcationViewModel> Demarcations { get; set; } = new();

		[Category("FeatureBindings")]
		public ObservableCollection<BerthViewModel.LayoutDivisionViewModel> LayoutDivisions { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. Demarcations.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. LayoutDivisions.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public BerthViewModel Load(Berth instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			availableBerthingLength = instance.availableBerthingLength;
			bollardDescription = instance.bollardDescription;
			safeWorkingLoad = instance.safeWorkingLoad;
			minimumBerthDepth = instance.minimumBerthDepth;
			elevation = instance.elevation;
			cathodicProtectionSystem = instance.cathodicProtectionSystem;
			categoryOfBerthLocation = instance.categoryOfBerthLocation;
			portFacilityNumber = instance.portFacilityNumber;
			bollardNumber.Clear();
			if (instance.bollardNumber is not null) {
				foreach(var e in instance.bollardNumber)
					bollardNumber.Add(e);
			}
			gLNExtension = instance.gLNExtension;
			metreMarkNumber.Clear();
			if (instance.metreMarkNumber is not null) {
				foreach(var e in instance.metreMarkNumber)
					metreMarkNumber.Add(e);
			}
			manifoldNumber.Clear();
			if (instance.manifoldNumber is not null) {
				foreach(var e in instance.manifoldNumber)
					manifoldNumber.Add(e);
			}
			rampNumber = instance.rampNumber;
			locationByText = instance.locationByText;
			methodOfSecuring = instance.methodOfSecuring;
			uNLocationCode = instance.uNLocationCode;
			terminalIdentifier = instance.terminalIdentifier;
			shorePowerDescription = instance.shorePowerDescription;
			categoryOfFrequency.Clear();
			if (instance.categoryOfFrequency is not null) {
				foreach(var e in instance.categoryOfFrequency)
					categoryOfFrequency.Add(e);
			}
			categoryOfVoltage.Clear();
			if (instance.categoryOfVoltage is not null) {
				foreach(var e in instance.categoryOfVoltage)
					categoryOfVoltage.Add(e);
			}
			categoryOfPlug.Clear();
			if (instance.categoryOfPlug is not null) {
				foreach(var e in instance.categoryOfPlug)
					categoryOfPlug.Add(e);
			}
			categoryOfCargo.Clear();
			if (instance.categoryOfCargo is not null) {
				foreach(var e in instance.categoryOfCargo)
					categoryOfCargo.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Berth {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				availableBerthingLength = this.availableBerthingLength,
				bollardDescription = this.bollardDescription,
				safeWorkingLoad = this.safeWorkingLoad,
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
				shorePowerDescription = this.shorePowerDescription,
				categoryOfFrequency = this.categoryOfFrequency.ToList(),
				categoryOfVoltage = this.categoryOfVoltage.ToList(),
				categoryOfPlug = this.categoryOfPlug.ToList(),
				categoryOfCargo = this.categoryOfCargo.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Berth Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			availableBerthingLength = this._availableBerthingLength,
			bollardDescription = this._bollardDescription,
			safeWorkingLoad = this._safeWorkingLoad,
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
			shorePowerDescription = this._shorePowerDescription,
			categoryOfFrequency = this.categoryOfFrequency.ToList(),
			categoryOfVoltage = this.categoryOfVoltage.ToList(),
			categoryOfPlug = this.categoryOfPlug.ToList(),
			categoryOfCargo = this.categoryOfCargo.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Berth._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Berth._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Berth._featureBindingDefinitions;

		public BerthViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public BerthViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Berth";

		public BerthViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			bollardNumber.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(bollardNumber));
			};
			metreMarkNumber.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(metreMarkNumber));
			};
			manifoldNumber.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(manifoldNumber));
			};
			categoryOfFrequency.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfFrequency));
			};
			categoryOfVoltage.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfVoltage));
			};
			categoryOfPlug.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfPlug));
			};
			categoryOfCargo.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfCargo));
			};
			ServiceAvailabilities.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceAvailabilities));
			};
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			Demarcations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(Demarcations));
			};
			LayoutDivisions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(LayoutDivisions));
			};
		}
	}



	/// <summary>
	/// A specific position within a berth where a vessel may be moored or anchored.
	/// </summary>
	[CategoryOrder("BerthPosition",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BerthPositionViewModel : FeatureViewModel<BerthPosition> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private String? _bollardNumber  = default;

		[Category("BerthPosition")]
		[Editor(typeof(Editors.HorizonEditor<BerthPosition>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? bollardNumber {
			get {
				return _bollardNumber;
			}
			set {
				SetValue(ref _bollardNumber, value);
			}
		}

		private String? _gLNExtension  = default;

		[Category("BerthPosition")]
		[Editor(typeof(Editors.HorizonEditor<BerthPosition>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? gLNExtension {
			get {
				return _gLNExtension;
			}
			set {
				SetValue(ref _gLNExtension, value);
			}
		}

		private String? _metreMarkNumber  = default;

		[Category("BerthPosition")]
		[Editor(typeof(Editors.HorizonEditor<BerthPosition>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? metreMarkNumber {
			get {
				return _metreMarkNumber;
			}
			set {
				SetValue(ref _metreMarkNumber, value);
			}
		}

		private String? _manifoldNumber  = default;

		[Category("BerthPosition")]
		[Editor(typeof(Editors.HorizonEditor<BerthPosition>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? manifoldNumber {
			get {
				return _manifoldNumber;
			}
			set {
				SetValue(ref _manifoldNumber, value);
			}
		}

		private String? _rampNumber  = default;

		[Category("BerthPosition")]
		[Editor(typeof(Editors.HorizonEditor<BerthPosition>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? rampNumber {
			get {
				return _rampNumber;
			}
			set {
				SetValue(ref _rampNumber, value);
			}
		}

		private String? _locationByText  = default;

		[Category("BerthPosition")]
		[Editor(typeof(Editors.HorizonEditor<BerthPosition>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationByText {
			get {
				return _locationByText;
			}
			set {
				SetValue(ref _locationByText, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		#region FeatureBindings

		public class DemarcationViewModel : featureBindingViewModel<S131.DemarcationViewModel>, IFeatureBindings {
			public DemarcationViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 1,
					upper = 1,
					association = "Demarcation",
					role = "demarcatedFeature",
					roleType = roleType.composition,
					featureTypes = ["Berth"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<Demarcation> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = Demarcation,
			};
		}

		public class PrimaryAuxiliaryFacilityViewModel : featureBindingViewModel<S131.PrimaryAuxiliaryFacilityViewModel>, IFeatureBindings {
			public PrimaryAuxiliaryFacilityViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 0,
					upper = default,
					association = "PrimaryAuxiliaryFacility",
					role = "auxiliaryFacility",
					roleType = roleType.association,
					featureTypes = ["MooringWarpingFacility"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<PrimaryAuxiliaryFacility> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = PrimaryAuxiliaryFacility,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<BerthPositionViewModel.DemarcationViewModel> Demarcations { get; set; } = new();

		[Category("FeatureBindings")]
		public ObservableCollection<BerthPositionViewModel.PrimaryAuxiliaryFacilityViewModel> PrimaryAuxiliaryFacilities { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. Demarcations.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. PrimaryAuxiliaryFacilities.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public BerthPositionViewModel Load(BerthPosition instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			bollardNumber = instance.bollardNumber;
			gLNExtension = instance.gLNExtension;
			metreMarkNumber = instance.metreMarkNumber;
			manifoldNumber = instance.manifoldNumber;
			rampNumber = instance.rampNumber;
			locationByText = instance.locationByText;
			return this;
		}

		public override string Serialize() {
			var instance = new BerthPosition {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				bollardNumber = this.bollardNumber,
				gLNExtension = this.gLNExtension,
				metreMarkNumber = this.metreMarkNumber,
				manifoldNumber = this.manifoldNumber,
				rampNumber = this.rampNumber,
				locationByText = this.locationByText,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public BerthPosition Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			bollardNumber = this._bollardNumber,
			gLNExtension = this._gLNExtension,
			metreMarkNumber = this._metreMarkNumber,
			manifoldNumber = this._manifoldNumber,
			rampNumber = this._rampNumber,
			locationByText = this._locationByText,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => BerthPosition._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. BerthPosition._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => BerthPosition._featureBindingDefinitions;

		public BerthPositionViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public BerthPositionViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Berth Position";

		public BerthPositionViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			Demarcations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(Demarcations));
			};
			PrimaryAuxiliaryFacilities.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(PrimaryAuxiliaryFacilities));
			};
		}
	}



	/// <summary>
	/// Small shaped post, mounted on a wharf or dolphin used to secure ship's lines.
	/// </summary>
	[CategoryOrder("Bollard",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BollardViewModel : FeatureViewModel<Bollard> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private double? _height  = default;

		[Category("Bollard")]
		[Editor(typeof(Editors.HorizonEditor<Bollard>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private double? _verticalLength  = default;

		[Category("Bollard")]
		[Editor(typeof(Editors.HorizonEditor<Bollard>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public BollardViewModel Load(Bollard instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			height = instance.height;
			verticalLength = instance.verticalLength;
			return this;
		}

		public override string Serialize() {
			var instance = new Bollard {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				height = this.height,
				verticalLength = this.verticalLength,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Bollard Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			height = this._height,
			verticalLength = this._verticalLength,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Bollard._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Bollard._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Bollard._featureBindingDefinitions;

		public BollardViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public BollardViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Bollard";

		public BollardViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
	}



	/// <summary>
	/// An artificially enclosed area within which ships may moor and which may have gates to regulate water level.
	/// </summary>
	[CategoryOrder("DockArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DockAreaViewModel : FeatureViewModel<DockArea> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private depthsDescriptionViewModel? _depthsDescription  = default;

		[Category("DockArea")]
		[ExpandableObject]
		[Optional]
		public depthsDescriptionViewModel? depthsDescription {
			get {
				return _depthsDescription;
			}
			set {
				SetValue(ref _depthsDescription, value);
			}
		}

		private String? _locationByText  = default;

		[Category("DockArea")]
		[Editor(typeof(Editors.HorizonEditor<DockArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationByText {
			get {
				return _locationByText;
			}
			set {
				SetValue(ref _locationByText, value);
			}
		}

		private markedByViewModel? _markedBy  = default;

		[Category("DockArea")]
		[ExpandableObject]
		[Optional]
		public markedByViewModel? markedBy {
			get {
				return _markedBy;
			}
			set {
				SetValue(ref _markedBy, value);
			}
		}

		private iSPSLevel? _iSPSLevel  = default;

		[Category("DockArea")]
		[Editor(typeof(Editors.HorizonEditor<DockArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public iSPSLevel? iSPSLevel {
			get {
				return _iSPSLevel;
			}
			set {
				SetValue(ref _iSPSLevel, value);
			}
		}

		[Browsable(false)]
		public iSPSLevel[] iSPSLevelList => [(iSPSLevel)1,(iSPSLevel)2,(iSPSLevel)3];


		#region InformationBindings

		public class ServiceAvailabilityViewModel : informationBindingViewModel<S131.ServiceAvailabilityViewModel>, IInformationBindings {
			public ServiceAvailabilityViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "ServiceAvailability",
					role = "serviceDescriptionReference",
					roleType = roleType.association,
					informationTypes = ["AvailablePortServices"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceAvailability> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceAvailability,
			};
		}

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<DockAreaViewModel.ServiceAvailabilityViewModel> ServiceAvailabilities { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<DockAreaViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. ServiceAvailabilities.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class LayoutDivisionViewModel : featureBindingViewModel<S131.LayoutDivisionViewModel>, IFeatureBindings {
			public LayoutDivisionViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 1,
					upper = 1,
					association = "LayoutDivision",
					role = "componentOf",
					roleType = roleType.aggregation,
					featureTypes = ["HarbourAreaSection"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<LayoutDivision> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LayoutDivision,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<DockAreaViewModel.LayoutDivisionViewModel> LayoutDivisions { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. LayoutDivisions.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public DockAreaViewModel Load(DockArea instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			depthsDescription = new ();
			if (instance.depthsDescription != default) {
				depthsDescription.Load(instance.depthsDescription);
			}
			locationByText = instance.locationByText;
			markedBy = new ();
			if (instance.markedBy != default) {
				markedBy.Load(instance.markedBy);
			}
			iSPSLevel = instance.iSPSLevel;
			return this;
		}

		public override string Serialize() {
			var instance = new DockArea {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				depthsDescription = this.depthsDescription?.Model,
				locationByText = this.locationByText,
				markedBy = this.markedBy?.Model,
				iSPSLevel = this.iSPSLevel,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DockArea Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			depthsDescription = this._depthsDescription?.Model,
			locationByText = this._locationByText,
			markedBy = this._markedBy?.Model,
			iSPSLevel = this._iSPSLevel,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => DockArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. DockArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => DockArea._featureBindingDefinitions;

		public DockAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public DockAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Dock Area";

		public DockAreaViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			ServiceAvailabilities.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceAvailabilities));
			};
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			LayoutDivisions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(LayoutDivisions));
			};
		}
	}



	/// <summary>
	/// An artificial basin fitted with a gate or caisson, into which vessels can be floated and the water pumped out to expose the vessel's bottom. Also called graving dock.
	/// </summary>
	[CategoryOrder("DryDock",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DryDockViewModel : FeatureViewModel<DryDock> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private double? _sillDepth  = default;

		[Category("DryDock")]
		[Editor(typeof(Editors.HorizonEditor<DryDock>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? sillDepth {
			get {
				return _sillDepth;
			}
			set {
				SetValue(ref _sillDepth, value);
			}
		}

		private double? _verticalClearanceValue  = default;

		[Category("DryDock")]
		[Editor(typeof(Editors.HorizonEditor<DryDock>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalClearanceValue {
			get {
				return _verticalClearanceValue;
			}
			set {
				SetValue(ref _verticalClearanceValue, value);
			}
		}


		#region InformationBindings

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<DryDockViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public DryDockViewModel Load(DryDock instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			sillDepth = instance.sillDepth;
			verticalClearanceValue = instance.verticalClearanceValue;
			return this;
		}

		public override string Serialize() {
			var instance = new DryDock {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				sillDepth = this.sillDepth,
				verticalClearanceValue = this.verticalClearanceValue,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DryDock Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			sillDepth = this._sillDepth,
			verticalClearanceValue = this._verticalClearanceValue,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => DryDock._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. DryDock._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => DryDock._featureBindingDefinitions;

		public DryDockViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public DryDockViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Dry Dock";

		public DryDockViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
		}
	}



	/// <summary>
	/// A post or group of posts, used for mooring or warping a vessel, or as an aid to navigation. The dolphin may be in the water, on a wharf or on the beach.
	/// </summary>
	[CategoryOrder("Dolphin",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DolphinViewModel : FeatureViewModel<Dolphin> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		[Category("Dolphin")]
		[Multiplicity(1)]
		public ObservableCollection<categoryOfDolphin> categoryOfDolphin  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfDolphin[] categoryOfDolphinList => [(categoryOfDolphin)1,(categoryOfDolphin)2,(categoryOfDolphin)3,(categoryOfDolphin)4];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public DolphinViewModel Load(Dolphin instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			categoryOfDolphin.Clear();
			if (instance.categoryOfDolphin is not null) {
				foreach(var e in instance.categoryOfDolphin)
					categoryOfDolphin.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Dolphin {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				categoryOfDolphin = this.categoryOfDolphin.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Dolphin Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfDolphin = this.categoryOfDolphin.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Dolphin._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Dolphin._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Dolphin._featureBindingDefinitions;

		public DolphinViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public DolphinViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Dolphin";

		public DolphinViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			categoryOfDolphin.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfDolphin));
			};
		}
	}



	/// <summary>
	/// A sea area where dredged material or other potentially more harmful material, for example explosives, chemical waste, is deliberately deposited.
	/// </summary>
	[CategoryOrder("DumpingGround",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DumpingGroundViewModel : FeatureViewModel<DumpingGround> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private depthsDescriptionViewModel? _depthsDescription  = default;

		[Category("DumpingGround")]
		[ExpandableObject]
		[Optional]
		public depthsDescriptionViewModel? depthsDescription {
			get {
				return _depthsDescription;
			}
			set {
				SetValue(ref _depthsDescription, value);
			}
		}

		private String? _locationByText  = default;

		[Category("DumpingGround")]
		[Editor(typeof(Editors.HorizonEditor<DumpingGround>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationByText {
			get {
				return _locationByText;
			}
			set {
				SetValue(ref _locationByText, value);
			}
		}

		private markedByViewModel? _markedBy  = default;

		[Category("DumpingGround")]
		[ExpandableObject]
		[Optional]
		public markedByViewModel? markedBy {
			get {
				return _markedBy;
			}
			set {
				SetValue(ref _markedBy, value);
			}
		}

		private iSPSLevel? _iSPSLevel  = default;

		[Category("DumpingGround")]
		[Editor(typeof(Editors.HorizonEditor<DumpingGround>), typeof(Editors.HorizonEditor))]
		[Optional]
		public iSPSLevel? iSPSLevel {
			get {
				return _iSPSLevel;
			}
			set {
				SetValue(ref _iSPSLevel, value);
			}
		}

		[Browsable(false)]
		public iSPSLevel[] iSPSLevelList => [(iSPSLevel)1,(iSPSLevel)2,(iSPSLevel)3];


		#region InformationBindings

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<DumpingGroundViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class LayoutDivisionViewModel : featureBindingViewModel<S131.LayoutDivisionViewModel>, IFeatureBindings {
			public LayoutDivisionViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 1,
					upper = 1,
					association = "LayoutDivision",
					role = "componentOf",
					roleType = roleType.aggregation,
					featureTypes = ["HarbourAreaSection"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<LayoutDivision> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LayoutDivision,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<DumpingGroundViewModel.LayoutDivisionViewModel> LayoutDivisions { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. LayoutDivisions.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public DumpingGroundViewModel Load(DumpingGround instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			depthsDescription = new ();
			if (instance.depthsDescription != default) {
				depthsDescription.Load(instance.depthsDescription);
			}
			locationByText = instance.locationByText;
			markedBy = new ();
			if (instance.markedBy != default) {
				markedBy.Load(instance.markedBy);
			}
			iSPSLevel = instance.iSPSLevel;
			return this;
		}

		public override string Serialize() {
			var instance = new DumpingGround {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				depthsDescription = this.depthsDescription?.Model,
				locationByText = this.locationByText,
				markedBy = this.markedBy?.Model,
				iSPSLevel = this.iSPSLevel,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DumpingGround Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			depthsDescription = this._depthsDescription?.Model,
			locationByText = this._locationByText,
			markedBy = this._markedBy?.Model,
			iSPSLevel = this._iSPSLevel,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => DumpingGround._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. DumpingGround._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => DumpingGround._featureBindingDefinitions;

		public DumpingGroundViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public DumpingGroundViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Dumping Ground";

		public DumpingGroundViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			LayoutDivisions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(LayoutDivisions));
			};
		}
	}



	/// <summary>
	/// An imaginary line parallel to a face of a berth or quay which touches the seaward face of the fenders.
	/// </summary>
	[CategoryOrder("FenderLine",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class FenderLineViewModel : FeatureViewModel<FenderLine> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private orientationViewModel? _orientation  = default;

		[Category("FenderLine")]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		#region FeatureBindings

		public class LayoutDivisionViewModel : featureBindingViewModel<S131.LayoutDivisionViewModel>, IFeatureBindings {
			public LayoutDivisionViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 1,
					upper = 1,
					association = "LayoutDivision",
					role = "componentOf",
					roleType = roleType.aggregation,
					featureTypes = ["HarbourAreaSection"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<LayoutDivision> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LayoutDivision,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<FenderLineViewModel.LayoutDivisionViewModel> LayoutDivisions { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. LayoutDivisions.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public FenderLineViewModel Load(FenderLine instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			orientation = new ();
			if (instance.orientation != default) {
				orientation.Load(instance.orientation);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new FenderLine {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				orientation = this.orientation?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public FenderLine Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			orientation = this._orientation?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => FenderLine._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. FenderLine._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FenderLine._featureBindingDefinitions;

		public FenderLineViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public FenderLineViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Fender Line";

		public FenderLineViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			LayoutDivisions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(LayoutDivisions));
			};
		}
	}



	/// <summary>
	/// A form of dry dock consisting of a floating structure of one or more sections which can be partly submerged by controlled flooding to receive a vessel, then raised by pumping out the water so that the vessel's bottom can be exposed.
	/// </summary>
	[CategoryOrder("FloatingDock",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class FloatingDockViewModel : FeatureViewModel<FloatingDock> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private double? _sillDepth  = default;

		[Category("FloatingDock")]
		[Editor(typeof(Editors.HorizonEditor<FloatingDock>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? sillDepth {
			get {
				return _sillDepth;
			}
			set {
				SetValue(ref _sillDepth, value);
			}
		}


		#region InformationBindings

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<FloatingDockViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public FloatingDockViewModel Load(FloatingDock instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			sillDepth = instance.sillDepth;
			return this;
		}

		public override string Serialize() {
			var instance = new FloatingDock {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				sillDepth = this.sillDepth,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public FloatingDock Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			sillDepth = this._sillDepth,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => FloatingDock._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. FloatingDock._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FloatingDock._featureBindingDefinitions;

		public FloatingDockViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public FloatingDockViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Floating Dock";

		public FloatingDockViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
		}
	}



	/// <summary>
	/// A structure in the intertidal zone serving as a support for vessels at low stages of the tide to permit work on the exposed portion of the vessel's hull.
	/// </summary>
	[CategoryOrder("Gridiron",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class GridironViewModel : FeatureViewModel<Gridiron> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private double? _sillDepth  = default;

		[Category("Gridiron")]
		[Editor(typeof(Editors.HorizonEditor<Gridiron>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? sillDepth {
			get {
				return _sillDepth;
			}
			set {
				SetValue(ref _sillDepth, value);
			}
		}

		private double? _verticalClearanceValue  = default;

		[Category("Gridiron")]
		[Editor(typeof(Editors.HorizonEditor<Gridiron>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalClearanceValue {
			get {
				return _verticalClearanceValue;
			}
			set {
				SetValue(ref _verticalClearanceValue, value);
			}
		}


		#region InformationBindings

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<GridironViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public GridironViewModel Load(Gridiron instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			sillDepth = instance.sillDepth;
			verticalClearanceValue = instance.verticalClearanceValue;
			return this;
		}

		public override string Serialize() {
			var instance = new Gridiron {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				sillDepth = this.sillDepth,
				verticalClearanceValue = this.verticalClearanceValue,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Gridiron Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			sillDepth = this._sillDepth,
			verticalClearanceValue = this._verticalClearanceValue,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Gridiron._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Gridiron._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Gridiron._featureBindingDefinitions;

		public GridironViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public GridironViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Gridiron";

		public GridironViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
		}
	}



	/// <summary>
	/// The area over which a harbour authority has jurisdiction.
	/// </summary>
	[CategoryOrder("HarbourAreaAdministrative",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class HarbourAreaAdministrativeViewModel : FeatureViewModel<HarbourAreaAdministrative> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private String? _uNLocationCode  = default;

		[Category("HarbourAreaAdministrative")]
		[Editor(typeof(Editors.HorizonEditor<HarbourAreaAdministrative>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? uNLocationCode {
			get {
				return _uNLocationCode;
			}
			set {
				SetValue(ref _uNLocationCode, value);
			}
		}

		private String? _nationality  = default;

		[Category("HarbourAreaAdministrative")]
		[Editor(typeof(Editors.HorizonEditor<HarbourAreaAdministrative>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}

		private String? _applicableLoadLineZone  = default;

		[Category("HarbourAreaAdministrative")]
		[Editor(typeof(Editors.HorizonEditor<HarbourAreaAdministrative>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? applicableLoadLineZone {
			get {
				return _applicableLoadLineZone;
			}
			set {
				SetValue(ref _applicableLoadLineZone, value);
			}
		}

		private iSPSLevel? _iSPSLevel  = default;

		[Category("HarbourAreaAdministrative")]
		[Editor(typeof(Editors.HorizonEditor<HarbourAreaAdministrative>), typeof(Editors.HorizonEditor))]
		[Optional]
		public iSPSLevel? iSPSLevel {
			get {
				return _iSPSLevel;
			}
			set {
				SetValue(ref _iSPSLevel, value);
			}
		}

		[Browsable(false)]
		public iSPSLevel[] iSPSLevelList => [(iSPSLevel)1,(iSPSLevel)2,(iSPSLevel)3];

		[Category("HarbourAreaAdministrative")]
		[Optional]
		public ObservableCollection<categoryOfHarbourFacility> categoryOfHarbourFacility  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfHarbourFacility[] categoryOfHarbourFacilityList => [(categoryOfHarbourFacility)1,(categoryOfHarbourFacility)3,(categoryOfHarbourFacility)4,(categoryOfHarbourFacility)5,(categoryOfHarbourFacility)6,(categoryOfHarbourFacility)7,(categoryOfHarbourFacility)8,(categoryOfHarbourFacility)9,(categoryOfHarbourFacility)10,(categoryOfHarbourFacility)11,(categoryOfHarbourFacility)12,(categoryOfHarbourFacility)13,(categoryOfHarbourFacility)14,(categoryOfHarbourFacility)15];

		private generalHarbourInformationViewModel? _generalHarbourInformation  = default;

		[Category("HarbourAreaAdministrative")]
		[ExpandableObject]
		[Optional]
		public generalHarbourInformationViewModel? generalHarbourInformation {
			get {
				return _generalHarbourInformation;
			}
			set {
				SetValue(ref _generalHarbourInformation, value);
			}
		}


		#region InformationBindings

		public class ServiceAvailabilityViewModel : informationBindingViewModel<S131.ServiceAvailabilityViewModel>, IInformationBindings {
			public ServiceAvailabilityViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "ServiceAvailability",
					role = "serviceDescriptionReference",
					roleType = roleType.association,
					informationTypes = ["AvailablePortServices"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceAvailability> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceAvailability,
			};
		}

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<HarbourAreaAdministrativeViewModel.ServiceAvailabilityViewModel> ServiceAvailabilities { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<HarbourAreaAdministrativeViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. ServiceAvailabilities.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class JurisdictionalLimitViewModel : featureBindingViewModel<S131.JurisdictionalLimitViewModel>, IFeatureBindings {
			public JurisdictionalLimitViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 0,
					upper = 1,
					association = "JurisdictionalLimit",
					role = "limitExtent",
					roleType = roleType.association,
					featureTypes = ["OuterLimit"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<JurisdictionalLimit> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = JurisdictionalLimit,
			};
		}

		public class LayoutDivisionViewModel : featureBindingViewModel<S131.LayoutDivisionViewModel>, IFeatureBindings {
			public LayoutDivisionViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 0,
					upper = default,
					association = "LayoutDivision",
					role = "layoutUnit",
					roleType = roleType.association,
					featureTypes = ["HarbourAreaSection"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<LayoutDivision> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LayoutDivision,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<HarbourAreaAdministrativeViewModel.JurisdictionalLimitViewModel> JurisdictionalLimits { get; set; } = new();

		[Category("FeatureBindings")]
		public ObservableCollection<HarbourAreaAdministrativeViewModel.LayoutDivisionViewModel> LayoutDivisions { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. JurisdictionalLimits.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. LayoutDivisions.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public HarbourAreaAdministrativeViewModel Load(HarbourAreaAdministrative instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			uNLocationCode = instance.uNLocationCode;
			nationality = instance.nationality;
			applicableLoadLineZone = instance.applicableLoadLineZone;
			iSPSLevel = instance.iSPSLevel;
			categoryOfHarbourFacility.Clear();
			if (instance.categoryOfHarbourFacility is not null) {
				foreach(var e in instance.categoryOfHarbourFacility)
					categoryOfHarbourFacility.Add(e);
			}
			generalHarbourInformation = new ();
			if (instance.generalHarbourInformation != default) {
				generalHarbourInformation.Load(instance.generalHarbourInformation);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new HarbourAreaAdministrative {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				uNLocationCode = this.uNLocationCode,
				nationality = this.nationality,
				applicableLoadLineZone = this.applicableLoadLineZone,
				iSPSLevel = this.iSPSLevel,
				categoryOfHarbourFacility = this.categoryOfHarbourFacility.ToList(),
				generalHarbourInformation = this.generalHarbourInformation?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public HarbourAreaAdministrative Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			uNLocationCode = this._uNLocationCode,
			nationality = this._nationality,
			applicableLoadLineZone = this._applicableLoadLineZone,
			iSPSLevel = this._iSPSLevel,
			categoryOfHarbourFacility = this.categoryOfHarbourFacility.ToList(),
			generalHarbourInformation = this._generalHarbourInformation?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => HarbourAreaAdministrative._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. HarbourAreaAdministrative._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => HarbourAreaAdministrative._featureBindingDefinitions;

		public HarbourAreaAdministrativeViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public HarbourAreaAdministrativeViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Harbour Area (Administrative)";

		public HarbourAreaAdministrativeViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			categoryOfHarbourFacility.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfHarbourFacility));
			};
			ServiceAvailabilities.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceAvailabilities));
			};
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			JurisdictionalLimits.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(JurisdictionalLimits));
			};
			LayoutDivisions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(LayoutDivisions));
			};
		}
	}



	/// <summary>
	/// A distinguishable portion of the area over which a harbour authority has jurisdiction.
	/// </summary>
	[CategoryOrder("HarbourAreaSection",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class HarbourAreaSectionViewModel : FeatureViewModel<HarbourAreaSection> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private categoryOfPortSection? _categoryOfPortSection  = default;

		[Category("HarbourAreaSection")]
		[Editor(typeof(Editors.HorizonEditor<HarbourAreaSection>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfPortSection? categoryOfPortSection {
			get {
				return _categoryOfPortSection;
			}
			set {
				SetValue(ref _categoryOfPortSection, value);
			}
		}

		[Browsable(false)]
		public categoryOfPortSection[] categoryOfPortSectionList => [(categoryOfPortSection)1,(categoryOfPortSection)3,(categoryOfPortSection)8,(categoryOfPortSection)9,(categoryOfPortSection)11,(categoryOfPortSection)12];

		[Category("HarbourAreaSection")]
		[Optional]
		public ObservableCollection<categoryOfHarbourFacility> categoryOfHarbourFacility  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfHarbourFacility[] categoryOfHarbourFacilityList => [(categoryOfHarbourFacility)4,(categoryOfHarbourFacility)5,(categoryOfHarbourFacility)6,(categoryOfHarbourFacility)9,(categoryOfHarbourFacility)14,(categoryOfHarbourFacility)15,(categoryOfHarbourFacility)16,(categoryOfHarbourFacility)17];

		private iSPSLevel? _iSPSLevel  = default;

		[Category("HarbourAreaSection")]
		[Editor(typeof(Editors.HorizonEditor<HarbourAreaSection>), typeof(Editors.HorizonEditor))]
		[Optional]
		public iSPSLevel? iSPSLevel {
			get {
				return _iSPSLevel;
			}
			set {
				SetValue(ref _iSPSLevel, value);
			}
		}

		[Browsable(false)]
		public iSPSLevel[] iSPSLevelList => [(iSPSLevel)1,(iSPSLevel)2,(iSPSLevel)3];

		private facilitiesLayoutDescriptionViewModel? _facilitiesLayoutDescription  = default;

		[Category("HarbourAreaSection")]
		[ExpandableObject]
		[Optional]
		public facilitiesLayoutDescriptionViewModel? facilitiesLayoutDescription {
			get {
				return _facilitiesLayoutDescription;
			}
			set {
				SetValue(ref _facilitiesLayoutDescription, value);
			}
		}


		#region InformationBindings

		public class ServiceAvailabilityViewModel : informationBindingViewModel<S131.ServiceAvailabilityViewModel>, IInformationBindings {
			public ServiceAvailabilityViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "ServiceAvailability",
					role = "serviceDescriptionReference",
					roleType = roleType.association,
					informationTypes = ["AvailablePortServices"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceAvailability> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceAvailability,
			};
		}

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<HarbourAreaSectionViewModel.ServiceAvailabilityViewModel> ServiceAvailabilities { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<HarbourAreaSectionViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. ServiceAvailabilities.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class LayoutDivisionViewModel : featureBindingViewModel<S131.LayoutDivisionViewModel>, IFeatureBindings {
			public LayoutDivisionViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LayoutDivision",
					role = "componentOf",
					roleType = roleType.aggregation,
					featureTypes = ["HarbourAreaAdministrative"],
				},
				new featureBindingDefinition {
					lower = 0,
					upper = default,
					association = "LayoutDivision",
					role = "layoutUnit",
					roleType = roleType.association,
					featureTypes = ["AnchorageArea","Berth","DockArea","DumpingGround","FenderLine","HarbourBasin","PilotBoardingPlace","SeaplaneLandingArea","Terminal","TurningBasin","WaterwayArea"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<LayoutDivision> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LayoutDivision,
			};
		}

		public class SubsectionViewModel : featureBindingViewModel<S131.SubsectionViewModel>, IFeatureBindings {
			public SubsectionViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 0,
					upper = 1,
					association = "Subsection",
					role = "constitute",
					roleType = roleType.aggregation,
					featureTypes = ["HarbourAreaSection"],
				},
				new featureBindingDefinition {
					lower = 0,
					upper = default,
					association = "Subsection",
					role = "subUnit",
					roleType = roleType.association,
					featureTypes = ["HarbourAreaSection"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<Subsection> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = Subsection,
			};
		}

		public class InfrastructureViewModel : featureBindingViewModel<S131.InfrastructureViewModel>, IFeatureBindings {
			public InfrastructureViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 0,
					upper = default,
					association = "Infrastructure",
					role = "hasInfrastructure",
					roleType = roleType.association,
					featureTypes = ["HarbourPhysicalInfrastructure"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<Infrastructure> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = Infrastructure,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<HarbourAreaSectionViewModel.LayoutDivisionViewModel> LayoutDivisions { get; set; } = new();

		[Category("FeatureBindings")]
		public ObservableCollection<HarbourAreaSectionViewModel.SubsectionViewModel> Subsections { get; set; } = new();

		[Category("FeatureBindings")]
		public ObservableCollection<HarbourAreaSectionViewModel.InfrastructureViewModel> Infrastructures { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. LayoutDivisions.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. Subsections.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. Infrastructures.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public HarbourAreaSectionViewModel Load(HarbourAreaSection instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			categoryOfPortSection = instance.categoryOfPortSection;
			categoryOfHarbourFacility.Clear();
			if (instance.categoryOfHarbourFacility is not null) {
				foreach(var e in instance.categoryOfHarbourFacility)
					categoryOfHarbourFacility.Add(e);
			}
			iSPSLevel = instance.iSPSLevel;
			facilitiesLayoutDescription = new ();
			if (instance.facilitiesLayoutDescription != default) {
				facilitiesLayoutDescription.Load(instance.facilitiesLayoutDescription);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new HarbourAreaSection {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				categoryOfPortSection = this.categoryOfPortSection,
				categoryOfHarbourFacility = this.categoryOfHarbourFacility.ToList(),
				iSPSLevel = this.iSPSLevel,
				facilitiesLayoutDescription = this.facilitiesLayoutDescription?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public HarbourAreaSection Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfPortSection = this._categoryOfPortSection,
			categoryOfHarbourFacility = this.categoryOfHarbourFacility.ToList(),
			iSPSLevel = this._iSPSLevel,
			facilitiesLayoutDescription = this._facilitiesLayoutDescription?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => HarbourAreaSection._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. HarbourAreaSection._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => HarbourAreaSection._featureBindingDefinitions;

		public HarbourAreaSectionViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public HarbourAreaSectionViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Harbour Area Section";

		public HarbourAreaSectionViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			categoryOfHarbourFacility.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfHarbourFacility));
			};
			ServiceAvailabilities.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceAvailabilities));
			};
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			LayoutDivisions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(LayoutDivisions));
			};
			Subsections.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(Subsections));
			};
			Infrastructures.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(Infrastructures));
			};
		}
	}



	/// <summary>
	/// An enclosed area of water surrounded by quay walls constructed to provide means for the transfer of cargos from and to ships.
	/// </summary>
	[CategoryOrder("HarbourBasin",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class HarbourBasinViewModel : FeatureViewModel<HarbourBasin> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private depthsDescriptionViewModel? _depthsDescription  = default;

		[Category("HarbourBasin")]
		[ExpandableObject]
		[Optional]
		public depthsDescriptionViewModel? depthsDescription {
			get {
				return _depthsDescription;
			}
			set {
				SetValue(ref _depthsDescription, value);
			}
		}

		private String? _locationByText  = default;

		[Category("HarbourBasin")]
		[Editor(typeof(Editors.HorizonEditor<HarbourBasin>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationByText {
			get {
				return _locationByText;
			}
			set {
				SetValue(ref _locationByText, value);
			}
		}

		private markedByViewModel? _markedBy  = default;

		[Category("HarbourBasin")]
		[ExpandableObject]
		[Optional]
		public markedByViewModel? markedBy {
			get {
				return _markedBy;
			}
			set {
				SetValue(ref _markedBy, value);
			}
		}

		private iSPSLevel? _iSPSLevel  = default;

		[Category("HarbourBasin")]
		[Editor(typeof(Editors.HorizonEditor<HarbourBasin>), typeof(Editors.HorizonEditor))]
		[Optional]
		public iSPSLevel? iSPSLevel {
			get {
				return _iSPSLevel;
			}
			set {
				SetValue(ref _iSPSLevel, value);
			}
		}

		[Browsable(false)]
		public iSPSLevel[] iSPSLevelList => [(iSPSLevel)1,(iSPSLevel)2,(iSPSLevel)3];


		#region InformationBindings

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<HarbourBasinViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class LayoutDivisionViewModel : featureBindingViewModel<S131.LayoutDivisionViewModel>, IFeatureBindings {
			public LayoutDivisionViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 1,
					upper = 1,
					association = "LayoutDivision",
					role = "componentOf",
					roleType = roleType.aggregation,
					featureTypes = ["HarbourAreaSection"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<LayoutDivision> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LayoutDivision,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<HarbourBasinViewModel.LayoutDivisionViewModel> LayoutDivisions { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. LayoutDivisions.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public HarbourBasinViewModel Load(HarbourBasin instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			depthsDescription = new ();
			if (instance.depthsDescription != default) {
				depthsDescription.Load(instance.depthsDescription);
			}
			locationByText = instance.locationByText;
			markedBy = new ();
			if (instance.markedBy != default) {
				markedBy.Load(instance.markedBy);
			}
			iSPSLevel = instance.iSPSLevel;
			return this;
		}

		public override string Serialize() {
			var instance = new HarbourBasin {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				depthsDescription = this.depthsDescription?.Model,
				locationByText = this.locationByText,
				markedBy = this.markedBy?.Model,
				iSPSLevel = this.iSPSLevel,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public HarbourBasin Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			depthsDescription = this._depthsDescription?.Model,
			locationByText = this._locationByText,
			markedBy = this._markedBy?.Model,
			iSPSLevel = this._iSPSLevel,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => HarbourBasin._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. HarbourBasin._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => HarbourBasin._featureBindingDefinitions;

		public HarbourBasinViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public HarbourBasinViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Harbour Basin";

		public HarbourBasinViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			LayoutDivisions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(LayoutDivisions));
			};
		}
	}



	/// <summary>
	/// A wet dock in a waterway, permitting a ship to pass from one level to another.
	/// </summary>
	[CategoryOrder("LockBasin",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LockBasinViewModel : FeatureViewModel<LockBasin> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private double? _sillDepth  = default;

		[Category("LockBasin")]
		[Editor(typeof(Editors.HorizonEditor<LockBasin>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? sillDepth {
			get {
				return _sillDepth;
			}
			set {
				SetValue(ref _sillDepth, value);
			}
		}


		#region InformationBindings

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<LockBasinViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public LockBasinViewModel Load(LockBasin instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			sillDepth = instance.sillDepth;
			return this;
		}

		public override string Serialize() {
			var instance = new LockBasin {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				sillDepth = this.sillDepth,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LockBasin Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			sillDepth = this._sillDepth,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => LockBasin._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LockBasin._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LockBasin._featureBindingDefinitions;

		public LockBasinViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public LockBasinViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Lock Basin";

		public LockBasinViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
		}
	}



	/// <summary>
	/// A lock basin is divided into several lock basin parts, if this lock basin has one ground level but several gates.
	/// </summary>
	[CategoryOrder("LockBasinPart",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LockBasinPartViewModel : FeatureViewModel<LockBasinPart> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private double? _sillDepth  = default;

		[Category("LockBasinPart")]
		[Editor(typeof(Editors.HorizonEditor<LockBasinPart>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? sillDepth {
			get {
				return _sillDepth;
			}
			set {
				SetValue(ref _sillDepth, value);
			}
		}


		#region InformationBindings

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<LockBasinPartViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public LockBasinPartViewModel Load(LockBasinPart instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			sillDepth = instance.sillDepth;
			return this;
		}

		public override string Serialize() {
			var instance = new LockBasinPart {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				sillDepth = this.sillDepth,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LockBasinPart Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			sillDepth = this._sillDepth,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => LockBasinPart._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LockBasinPart._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LockBasinPart._featureBindingDefinitions;

		public LockBasinPartViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public LockBasinPartViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Lock Basin Part";

		public LockBasinPartViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
		}
	}



	/// <summary>
	/// A buoy secured to the bottom by permanent moorings with means for mooring a vessel by use of its anchor chain or mooring lines.
	/// </summary>
	[CategoryOrder("MooringBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class MooringBuoyViewModel : FeatureViewModel<MooringBuoy> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private double? _maximumPermittedDraught  = default;

		[Category("MooringBuoy")]
		[Editor(typeof(Editors.HorizonEditor<MooringBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? maximumPermittedDraught {
			get {
				return _maximumPermittedDraught;
			}
			set {
				SetValue(ref _maximumPermittedDraught, value);
			}
		}

		private double? _maximumPermittedVesselLength  = default;

		[Category("MooringBuoy")]
		[Editor(typeof(Editors.HorizonEditor<MooringBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? maximumPermittedVesselLength {
			get {
				return _maximumPermittedVesselLength;
			}
			set {
				SetValue(ref _maximumPermittedVesselLength, value);
			}
		}

		private double? _verticalLength  = default;

		[Category("MooringBuoy")]
		[Editor(typeof(Editors.HorizonEditor<MooringBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private Boolean? _visitorsMooring  = default;

		[Category("MooringBuoy")]
		[Editor(typeof(Editors.HorizonEditor<MooringBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? visitorsMooring {
			get {
				return _visitorsMooring;
			}
			set {
				SetValue(ref _visitorsMooring, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public MooringBuoyViewModel Load(MooringBuoy instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			maximumPermittedDraught = instance.maximumPermittedDraught;
			maximumPermittedVesselLength = instance.maximumPermittedVesselLength;
			verticalLength = instance.verticalLength;
			visitorsMooring = instance.visitorsMooring;
			return this;
		}

		public override string Serialize() {
			var instance = new MooringBuoy {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				maximumPermittedDraught = this.maximumPermittedDraught,
				maximumPermittedVesselLength = this.maximumPermittedVesselLength,
				verticalLength = this.verticalLength,
				visitorsMooring = this.visitorsMooring,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public MooringBuoy Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			maximumPermittedDraught = this._maximumPermittedDraught,
			maximumPermittedVesselLength = this._maximumPermittedVesselLength,
			verticalLength = this._verticalLength,
			visitorsMooring = this._visitorsMooring,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => MooringBuoy._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. MooringBuoy._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => MooringBuoy._featureBindingDefinitions;

		public MooringBuoyViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public MooringBuoyViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Mooring Buoy";

		public MooringBuoyViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
	}



	/// <summary>
	/// The equipment or structure used to secure a vessel.
	/// </summary>
	[CategoryOrder("MooringWarpingFacility",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class MooringWarpingFacilityViewModel : FeatureViewModel<MooringWarpingFacility> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private categoryOfMooringWarpingFacility _categoryOfMooringWarpingFacility  = default;

		[Category("MooringWarpingFacility")]
		[Editor(typeof(Editors.HorizonEditor<MooringWarpingFacility>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public categoryOfMooringWarpingFacility categoryOfMooringWarpingFacility {
			get {
				return _categoryOfMooringWarpingFacility;
			}
			set {
				SetValue(ref _categoryOfMooringWarpingFacility, value);
			}
		}

		[Browsable(false)]
		public categoryOfMooringWarpingFacility[] categoryOfMooringWarpingFacilityList => [(categoryOfMooringWarpingFacility)4,(categoryOfMooringWarpingFacility)5,(categoryOfMooringWarpingFacility)6];

		private String _iDCode  = string.Empty;

		[Category("MooringWarpingFacility")]
		[Editor(typeof(Editors.HorizonEditor<MooringWarpingFacility>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String? _bollardDescription  = default;

		[Category("MooringWarpingFacility")]
		[Editor(typeof(Editors.HorizonEditor<MooringWarpingFacility>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? bollardDescription {
			get {
				return _bollardDescription;
			}
			set {
				SetValue(ref _bollardDescription, value);
			}
		}

		private double? _safeWorkingLoad  = default;

		[Category("MooringWarpingFacility")]
		[Editor(typeof(Editors.HorizonEditor<MooringWarpingFacility>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? safeWorkingLoad {
			get {
				return _safeWorkingLoad;
			}
			set {
				SetValue(ref _safeWorkingLoad, value);
			}
		}

		private Boolean? _heavingLinesFromShore  = default;

		[Category("MooringWarpingFacility")]
		[Editor(typeof(Editors.HorizonEditor<MooringWarpingFacility>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? heavingLinesFromShore {
			get {
				return _heavingLinesFromShore;
			}
			set {
				SetValue(ref _heavingLinesFromShore, value);
			}
		}


		#region InformationBindings

		public class ServiceAvailabilityViewModel : informationBindingViewModel<S131.ServiceAvailabilityViewModel>, IInformationBindings {
			public ServiceAvailabilityViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "ServiceAvailability",
					role = "serviceDescriptionReference",
					roleType = roleType.association,
					informationTypes = ["AvailablePortServices"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceAvailability> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceAvailability,
			};
		}

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<MooringWarpingFacilityViewModel.ServiceAvailabilityViewModel> ServiceAvailabilities { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<MooringWarpingFacilityViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. ServiceAvailabilities.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class PrimaryAuxiliaryFacilityViewModel : featureBindingViewModel<S131.PrimaryAuxiliaryFacilityViewModel>, IFeatureBindings {
			public PrimaryAuxiliaryFacilityViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 0,
					upper = 1,
					association = "PrimaryAuxiliaryFacility",
					role = "primaryFacility",
					roleType = roleType.association,
					featureTypes = ["AnchorBerth","BerthPosition"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<PrimaryAuxiliaryFacility> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = PrimaryAuxiliaryFacility,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<MooringWarpingFacilityViewModel.PrimaryAuxiliaryFacilityViewModel> PrimaryAuxiliaryFacilities { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. PrimaryAuxiliaryFacilities.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public MooringWarpingFacilityViewModel Load(MooringWarpingFacility instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			categoryOfMooringWarpingFacility = instance.categoryOfMooringWarpingFacility;
			iDCode = instance.iDCode;
			bollardDescription = instance.bollardDescription;
			safeWorkingLoad = instance.safeWorkingLoad;
			heavingLinesFromShore = instance.heavingLinesFromShore;
			return this;
		}

		public override string Serialize() {
			var instance = new MooringWarpingFacility {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				categoryOfMooringWarpingFacility = this.categoryOfMooringWarpingFacility,
				iDCode = this.iDCode,
				bollardDescription = this.bollardDescription,
				safeWorkingLoad = this.safeWorkingLoad,
				heavingLinesFromShore = this.heavingLinesFromShore,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public MooringWarpingFacility Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfMooringWarpingFacility = this._categoryOfMooringWarpingFacility,
			iDCode = this._iDCode,
			bollardDescription = this._bollardDescription,
			safeWorkingLoad = this._safeWorkingLoad,
			heavingLinesFromShore = this._heavingLinesFromShore,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => MooringWarpingFacility._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. MooringWarpingFacility._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => MooringWarpingFacility._featureBindingDefinitions;

		public MooringWarpingFacilityViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public MooringWarpingFacilityViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Mooring/Warping Facility";

		public MooringWarpingFacilityViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			ServiceAvailabilities.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceAvailabilities));
			};
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			PrimaryAuxiliaryFacilities.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(PrimaryAuxiliaryFacilities));
			};
		}
	}



	/// <summary>
	/// Facilities or infrastructure providing shore power to berthed vessels.
	/// </summary>
	[CategoryOrder("OnshorePowerFacility",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class OnshorePowerFacilityViewModel : FeatureViewModel<OnshorePowerFacility> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private categoryOfShorePowerFacility? _categoryOfShorePowerFacility  = default;

		[Category("OnshorePowerFacility")]
		[Editor(typeof(Editors.HorizonEditor<OnshorePowerFacility>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfShorePowerFacility? categoryOfShorePowerFacility {
			get {
				return _categoryOfShorePowerFacility;
			}
			set {
				SetValue(ref _categoryOfShorePowerFacility, value);
			}
		}

		[Browsable(false)]
		public categoryOfShorePowerFacility[] categoryOfShorePowerFacilityList => [(categoryOfShorePowerFacility)1,(categoryOfShorePowerFacility)2,(categoryOfShorePowerFacility)3];

		private String _iDCode  = string.Empty;

		[Category("OnshorePowerFacility")]
		[Editor(typeof(Editors.HorizonEditor<OnshorePowerFacility>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String? _shorePowerDescription  = default;

		[Category("OnshorePowerFacility")]
		[Editor(typeof(Editors.HorizonEditor<OnshorePowerFacility>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? shorePowerDescription {
			get {
				return _shorePowerDescription;
			}
			set {
				SetValue(ref _shorePowerDescription, value);
			}
		}

		[Category("OnshorePowerFacility")]
		[Optional]
		public ObservableCollection<categoryOfVoltage> categoryOfVoltage  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfVoltage[] categoryOfVoltageList => [(categoryOfVoltage)1,(categoryOfVoltage)2,(categoryOfVoltage)3,(categoryOfVoltage)4,(categoryOfVoltage)5,(categoryOfVoltage)6,(categoryOfVoltage)7,(categoryOfVoltage)8,(categoryOfVoltage)9,(categoryOfVoltage)10,(categoryOfVoltage)11,(categoryOfVoltage)12,(categoryOfVoltage)13,(categoryOfVoltage)14];

		[Category("OnshorePowerFacility")]
		[Optional]
		public ObservableCollection<categoryOfFrequency> categoryOfFrequency  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfFrequency[] categoryOfFrequencyList => Enum.GetValues<categoryOfFrequency>();

		[Category("OnshorePowerFacility")]
		[Optional]
		public ObservableCollection<String> categoryOfPlug  { get; set; } = new ();

		private String? _shorePowerServiceProvider  = default;

		[Category("OnshorePowerFacility")]
		[Editor(typeof(Editors.HorizonEditor<OnshorePowerFacility>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? shorePowerServiceProvider {
			get {
				return _shorePowerServiceProvider;
			}
			set {
				SetValue(ref _shorePowerServiceProvider, value);
			}
		}


		#region InformationBindings

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<OnshorePowerFacilityViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public OnshorePowerFacilityViewModel Load(OnshorePowerFacility instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			categoryOfShorePowerFacility = instance.categoryOfShorePowerFacility;
			iDCode = instance.iDCode;
			shorePowerDescription = instance.shorePowerDescription;
			categoryOfVoltage.Clear();
			if (instance.categoryOfVoltage is not null) {
				foreach(var e in instance.categoryOfVoltage)
					categoryOfVoltage.Add(e);
			}
			categoryOfFrequency.Clear();
			if (instance.categoryOfFrequency is not null) {
				foreach(var e in instance.categoryOfFrequency)
					categoryOfFrequency.Add(e);
			}
			categoryOfPlug.Clear();
			if (instance.categoryOfPlug is not null) {
				foreach(var e in instance.categoryOfPlug)
					categoryOfPlug.Add(e);
			}
			shorePowerServiceProvider = instance.shorePowerServiceProvider;
			return this;
		}

		public override string Serialize() {
			var instance = new OnshorePowerFacility {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				categoryOfShorePowerFacility = this.categoryOfShorePowerFacility,
				iDCode = this.iDCode,
				shorePowerDescription = this.shorePowerDescription,
				categoryOfVoltage = this.categoryOfVoltage.ToList(),
				categoryOfFrequency = this.categoryOfFrequency.ToList(),
				categoryOfPlug = this.categoryOfPlug.ToList(),
				shorePowerServiceProvider = this.shorePowerServiceProvider,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public OnshorePowerFacility Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfShorePowerFacility = this._categoryOfShorePowerFacility,
			iDCode = this._iDCode,
			shorePowerDescription = this._shorePowerDescription,
			categoryOfVoltage = this.categoryOfVoltage.ToList(),
			categoryOfFrequency = this.categoryOfFrequency.ToList(),
			categoryOfPlug = this.categoryOfPlug.ToList(),
			shorePowerServiceProvider = this._shorePowerServiceProvider,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => OnshorePowerFacility._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. OnshorePowerFacility._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => OnshorePowerFacility._featureBindingDefinitions;

		public OnshorePowerFacilityViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public OnshorePowerFacilityViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Onshore Power Facility";

		public OnshorePowerFacilityViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			categoryOfVoltage.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfVoltage));
			};
			categoryOfFrequency.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfFrequency));
			};
			categoryOfPlug.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfPlug));
			};
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
		}
	}



	/// <summary>
	/// The extent to which a coastal State claims or may claim a specific jurisdiction in accordance with the provisions of International Law.
	/// </summary>
	[CategoryOrder("OuterLimit",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class OuterLimitViewModel : FeatureViewModel<OuterLimit> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private limitsDescriptionViewModel? _limitsDescription  = default;

		[Category("OuterLimit")]
		[ExpandableObject]
		[Optional]
		public limitsDescriptionViewModel? limitsDescription {
			get {
				return _limitsDescription;
			}
			set {
				SetValue(ref _limitsDescription, value);
			}
		}

		[Category("OuterLimit")]
		[Optional]
		public ObservableCollection<markedByViewModel> markedBy  { get; set; } = new ();

		[Category("OuterLimit")]
		[Optional]
		public ObservableCollection<landmarkDescriptionViewModel> landmarkDescription  { get; set; } = new ();

		[Category("OuterLimit")]
		[Optional]
		public ObservableCollection<offshoreMarkDescriptionViewModel> offshoreMarkDescription  { get; set; } = new ();

		[Category("OuterLimit")]
		[Optional]
		public ObservableCollection<majorLightDescriptionViewModel> majorLightDescription  { get; set; } = new ();

		[Category("OuterLimit")]
		[Optional]
		public ObservableCollection<usefulMarkDescriptionViewModel> usefulMarkDescription  { get; set; } = new ();


		#region InformationBindings

		public class LimitEntranceViewModel : informationBindingViewModel<S131.LimitEntranceViewModel>, IInformationBindings {
			public LimitEntranceViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LimitEntrance",
					role = "entranceReference",
					roleType = roleType.association,
					informationTypes = ["Entrance"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LimitEntrance> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LimitEntrance,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<OuterLimitViewModel.LimitEntranceViewModel> LimitEntrances { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. LimitEntrances.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class JurisdictionalLimitViewModel : featureBindingViewModel<S131.JurisdictionalLimitViewModel>, IFeatureBindings {
			public JurisdictionalLimitViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 1,
					upper = 1,
					association = "JurisdictionalLimit",
					role = "limitReference",
					roleType = roleType.association,
					featureTypes = ["HarbourAreaAdministrative"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<JurisdictionalLimit> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = JurisdictionalLimit,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<OuterLimitViewModel.JurisdictionalLimitViewModel> JurisdictionalLimits { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. JurisdictionalLimits.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public OuterLimitViewModel Load(OuterLimit instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			limitsDescription = new ();
			if (instance.limitsDescription != default) {
				limitsDescription.Load(instance.limitsDescription);
			}
			markedBy.Clear();
			if (instance.markedBy is not null) {
				foreach(var e in instance.markedBy)
					markedBy.Add(new markedByViewModel().Load(e));
			}
			landmarkDescription.Clear();
			if (instance.landmarkDescription is not null) {
				foreach(var e in instance.landmarkDescription)
					landmarkDescription.Add(new landmarkDescriptionViewModel().Load(e));
			}
			offshoreMarkDescription.Clear();
			if (instance.offshoreMarkDescription is not null) {
				foreach(var e in instance.offshoreMarkDescription)
					offshoreMarkDescription.Add(new offshoreMarkDescriptionViewModel().Load(e));
			}
			majorLightDescription.Clear();
			if (instance.majorLightDescription is not null) {
				foreach(var e in instance.majorLightDescription)
					majorLightDescription.Add(new majorLightDescriptionViewModel().Load(e));
			}
			usefulMarkDescription.Clear();
			if (instance.usefulMarkDescription is not null) {
				foreach(var e in instance.usefulMarkDescription)
					usefulMarkDescription.Add(new usefulMarkDescriptionViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new OuterLimit {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				limitsDescription = this.limitsDescription?.Model,
				markedBy = this.markedBy.Select(e => e.Model).ToList(),
				landmarkDescription = this.landmarkDescription.Select(e => e.Model).ToList(),
				offshoreMarkDescription = this.offshoreMarkDescription.Select(e => e.Model).ToList(),
				majorLightDescription = this.majorLightDescription.Select(e => e.Model).ToList(),
				usefulMarkDescription = this.usefulMarkDescription.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public OuterLimit Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			limitsDescription = this._limitsDescription?.Model,
			markedBy = this.markedBy.Select(e => e.Model).ToList(),
			landmarkDescription = this.landmarkDescription.Select(e => e.Model).ToList(),
			offshoreMarkDescription = this.offshoreMarkDescription.Select(e => e.Model).ToList(),
			majorLightDescription = this.majorLightDescription.Select(e => e.Model).ToList(),
			usefulMarkDescription = this.usefulMarkDescription.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => OuterLimit._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. OuterLimit._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => OuterLimit._featureBindingDefinitions;

		public OuterLimitViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public OuterLimitViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Outer Limit";

		public OuterLimitViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			LimitEntrances.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LimitEntrances));
			};
			JurisdictionalLimits.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(JurisdictionalLimits));
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
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private depthsDescriptionViewModel? _depthsDescription  = default;

		[Category("PilotBoardingPlace")]
		[ExpandableObject]
		[Optional]
		public depthsDescriptionViewModel? depthsDescription {
			get {
				return _depthsDescription;
			}
			set {
				SetValue(ref _depthsDescription, value);
			}
		}

		private String? _locationByText  = default;

		[Category("PilotBoardingPlace")]
		[Editor(typeof(Editors.HorizonEditor<PilotBoardingPlace>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationByText {
			get {
				return _locationByText;
			}
			set {
				SetValue(ref _locationByText, value);
			}
		}

		[Category("PilotBoardingPlace")]
		[Multiplicity(0, 3)]
		public ObservableCollection<pilotMovement> pilotMovement  { get; set; } = new ();

		[Browsable(false)]
		public pilotMovement[] pilotMovementList => [(pilotMovement)1,(pilotMovement)2,(pilotMovement)3];

		private markedByViewModel? _markedBy  = default;

		[Category("PilotBoardingPlace")]
		[ExpandableObject]
		[Optional]
		public markedByViewModel? markedBy {
			get {
				return _markedBy;
			}
			set {
				SetValue(ref _markedBy, value);
			}
		}

		private iSPSLevel? _iSPSLevel  = default;

		[Category("PilotBoardingPlace")]
		[Editor(typeof(Editors.HorizonEditor<PilotBoardingPlace>), typeof(Editors.HorizonEditor))]
		[Optional]
		public iSPSLevel? iSPSLevel {
			get {
				return _iSPSLevel;
			}
			set {
				SetValue(ref _iSPSLevel, value);
			}
		}

		[Browsable(false)]
		public iSPSLevel[] iSPSLevelList => [(iSPSLevel)1,(iSPSLevel)2,(iSPSLevel)3];


		#region InformationBindings

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<PilotBoardingPlaceViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class LayoutDivisionViewModel : featureBindingViewModel<S131.LayoutDivisionViewModel>, IFeatureBindings {
			public LayoutDivisionViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 1,
					upper = 1,
					association = "LayoutDivision",
					role = "componentOf",
					roleType = roleType.aggregation,
					featureTypes = ["HarbourAreaSection"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<LayoutDivision> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LayoutDivision,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<PilotBoardingPlaceViewModel.LayoutDivisionViewModel> LayoutDivisions { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. LayoutDivisions.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public PilotBoardingPlaceViewModel Load(PilotBoardingPlace instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			depthsDescription = new ();
			if (instance.depthsDescription != default) {
				depthsDescription.Load(instance.depthsDescription);
			}
			locationByText = instance.locationByText;
			pilotMovement.Clear();
			if (instance.pilotMovement is not null) {
				foreach(var e in instance.pilotMovement)
					pilotMovement.Add(e);
			}
			markedBy = new ();
			if (instance.markedBy != default) {
				markedBy.Load(instance.markedBy);
			}
			iSPSLevel = instance.iSPSLevel;
			return this;
		}

		public override string Serialize() {
			var instance = new PilotBoardingPlace {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				depthsDescription = this.depthsDescription?.Model,
				locationByText = this.locationByText,
				pilotMovement = this.pilotMovement.ToList(),
				markedBy = this.markedBy?.Model,
				iSPSLevel = this.iSPSLevel,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PilotBoardingPlace Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			depthsDescription = this._depthsDescription?.Model,
			locationByText = this._locationByText,
			pilotMovement = this.pilotMovement.ToList(),
			markedBy = this._markedBy?.Model,
			iSPSLevel = this._iSPSLevel,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => PilotBoardingPlace._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. PilotBoardingPlace._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => PilotBoardingPlace._featureBindingDefinitions;

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
			rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(rxNCode));
			};
			graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(graphic));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			pilotMovement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(pilotMovement));
			};
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			LayoutDivisions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(LayoutDivisions));
			};
		}
	}



	/// <summary>
	/// A designated portion of water for the landing and take-off of seaplanes.
	/// </summary>
	[CategoryOrder("SeaplaneLandingArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SeaplaneLandingAreaViewModel : FeatureViewModel<SeaplaneLandingArea> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private depthsDescriptionViewModel? _depthsDescription  = default;

		[Category("SeaplaneLandingArea")]
		[ExpandableObject]
		[Optional]
		public depthsDescriptionViewModel? depthsDescription {
			get {
				return _depthsDescription;
			}
			set {
				SetValue(ref _depthsDescription, value);
			}
		}

		private String? _locationByText  = default;

		[Category("SeaplaneLandingArea")]
		[Editor(typeof(Editors.HorizonEditor<SeaplaneLandingArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationByText {
			get {
				return _locationByText;
			}
			set {
				SetValue(ref _locationByText, value);
			}
		}

		private markedByViewModel? _markedBy  = default;

		[Category("SeaplaneLandingArea")]
		[ExpandableObject]
		[Optional]
		public markedByViewModel? markedBy {
			get {
				return _markedBy;
			}
			set {
				SetValue(ref _markedBy, value);
			}
		}

		private iSPSLevel? _iSPSLevel  = default;

		[Category("SeaplaneLandingArea")]
		[Editor(typeof(Editors.HorizonEditor<SeaplaneLandingArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public iSPSLevel? iSPSLevel {
			get {
				return _iSPSLevel;
			}
			set {
				SetValue(ref _iSPSLevel, value);
			}
		}

		[Browsable(false)]
		public iSPSLevel[] iSPSLevelList => [(iSPSLevel)1,(iSPSLevel)2,(iSPSLevel)3];


		#region InformationBindings

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<SeaplaneLandingAreaViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class LayoutDivisionViewModel : featureBindingViewModel<S131.LayoutDivisionViewModel>, IFeatureBindings {
			public LayoutDivisionViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 1,
					upper = 1,
					association = "LayoutDivision",
					role = "componentOf",
					roleType = roleType.aggregation,
					featureTypes = ["HarbourAreaSection"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<LayoutDivision> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LayoutDivision,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<SeaplaneLandingAreaViewModel.LayoutDivisionViewModel> LayoutDivisions { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. LayoutDivisions.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public SeaplaneLandingAreaViewModel Load(SeaplaneLandingArea instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			depthsDescription = new ();
			if (instance.depthsDescription != default) {
				depthsDescription.Load(instance.depthsDescription);
			}
			locationByText = instance.locationByText;
			markedBy = new ();
			if (instance.markedBy != default) {
				markedBy.Load(instance.markedBy);
			}
			iSPSLevel = instance.iSPSLevel;
			return this;
		}

		public override string Serialize() {
			var instance = new SeaplaneLandingArea {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				depthsDescription = this.depthsDescription?.Model,
				locationByText = this.locationByText,
				markedBy = this.markedBy?.Model,
				iSPSLevel = this.iSPSLevel,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SeaplaneLandingArea Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			depthsDescription = this._depthsDescription?.Model,
			locationByText = this._locationByText,
			markedBy = this._markedBy?.Model,
			iSPSLevel = this._iSPSLevel,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => SeaplaneLandingArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SeaplaneLandingArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SeaplaneLandingArea._featureBindingDefinitions;

		public SeaplaneLandingAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SeaplaneLandingAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Seaplane Landing Area";

		public SeaplaneLandingAreaViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			LayoutDivisions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(LayoutDivisions));
			};
		}
	}



	/// <summary>
	/// A platform powered by synchronous electric motors (for example syncrolift) used to lift vessels (larger than boats) in and out of the water.
	/// </summary>
	[CategoryOrder("ShipLift",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ShipLiftViewModel : FeatureViewModel<ShipLift> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private double? _verticalClearanceValue  = default;

		[Category("ShipLift")]
		[Editor(typeof(Editors.HorizonEditor<ShipLift>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalClearanceValue {
			get {
				return _verticalClearanceValue;
			}
			set {
				SetValue(ref _verticalClearanceValue, value);
			}
		}


		#region InformationBindings

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<ShipLiftViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public ShipLiftViewModel Load(ShipLift instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			verticalClearanceValue = instance.verticalClearanceValue;
			return this;
		}

		public override string Serialize() {
			var instance = new ShipLift {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				verticalClearanceValue = this.verticalClearanceValue,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ShipLift Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			verticalClearanceValue = this._verticalClearanceValue,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => ShipLift._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. ShipLift._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => ShipLift._featureBindingDefinitions;

		public ShipLiftViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public ShipLiftViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Ship Lift";

		public ShipLiftViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
		}
	}



	/// <summary>
	/// A wheeled vehicle designed to lift and carry containers or vessels within its own framework. It is used for moving, and sometimes stacking, shipping containers and vessels.
	/// </summary>
	[CategoryOrder("StraddleCarrier",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class StraddleCarrierViewModel : FeatureViewModel<StraddleCarrier> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();






		#region InformationBindings

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<StraddleCarrierViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public StraddleCarrierViewModel Load(StraddleCarrier instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new StraddleCarrier {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public StraddleCarrier Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => StraddleCarrier._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. StraddleCarrier._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => StraddleCarrier._featureBindingDefinitions;

		public StraddleCarrierViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public StraddleCarrierViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Straddle Carrier";

		public StraddleCarrierViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
		}
	}



	/// <summary>
	/// A terminal covers that area on shore which provides buildings and constructions for the transfer of cargo or passengers from and to ships.
	/// </summary>
	[CategoryOrder("Terminal",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TerminalViewModel : FeatureViewModel<Terminal> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private String? _portFacilityNumber  = default;

		[Category("Terminal")]
		[Editor(typeof(Editors.HorizonEditor<Terminal>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? portFacilityNumber {
			get {
				return _portFacilityNumber;
			}
			set {
				SetValue(ref _portFacilityNumber, value);
			}
		}

		private categoryOfTerminal? _categoryOfTerminal  = default;

		[Category("Terminal")]
		[Editor(typeof(Editors.HorizonEditor<Terminal>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfTerminal? categoryOfTerminal {
			get {
				return _categoryOfTerminal;
			}
			set {
				SetValue(ref _categoryOfTerminal, value);
			}
		}

		[Browsable(false)]
		public categoryOfTerminal[] categoryOfTerminalList => [(categoryOfTerminal)1,(categoryOfTerminal)3,(categoryOfTerminal)7,(categoryOfTerminal)8,(categoryOfTerminal)10,(categoryOfTerminal)11];

		[Category("Terminal")]
		[Optional]
		public ObservableCollection<categoryOfCargo> categoryOfCargo  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfCargo[] categoryOfCargoList => [(categoryOfCargo)2,(categoryOfCargo)5,(categoryOfCargo)6,(categoryOfCargo)7,(categoryOfCargo)8,(categoryOfCargo)10,(categoryOfCargo)11,(categoryOfCargo)12,(categoryOfCargo)13,(categoryOfCargo)14,(categoryOfCargo)15];

		[Category("Terminal")]
		[Optional]
		public ObservableCollection<product> product  { get; set; } = new ();

		[Browsable(false)]
		public product[] productList => [(product)1,(product)2,(product)4,(product)5,(product)6,(product)7,(product)9,(product)10,(product)11,(product)12,(product)13,(product)14,(product)15,(product)16,(product)17,(product)18,(product)19,(product)20,(product)21,(product)22];

		private String? _terminalIdentifier  = default;

		[Category("Terminal")]
		[Editor(typeof(Editors.HorizonEditor<Terminal>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? terminalIdentifier {
			get {
				return _terminalIdentifier;
			}
			set {
				SetValue(ref _terminalIdentifier, value);
			}
		}

		private String? _sMDGTerminalCode  = default;

		[Category("Terminal")]
		[Editor(typeof(Editors.HorizonEditor<Terminal>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? sMDGTerminalCode {
			get {
				return _sMDGTerminalCode;
			}
			set {
				SetValue(ref _sMDGTerminalCode, value);
			}
		}

		private String? _uNLocationCode  = default;

		[Category("Terminal")]
		[Editor(typeof(Editors.HorizonEditor<Terminal>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? uNLocationCode {
			get {
				return _uNLocationCode;
			}
			set {
				SetValue(ref _uNLocationCode, value);
			}
		}


		#region InformationBindings

		public class ServiceAvailabilityViewModel : informationBindingViewModel<S131.ServiceAvailabilityViewModel>, IInformationBindings {
			public ServiceAvailabilityViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "ServiceAvailability",
					role = "serviceDescriptionReference",
					roleType = roleType.association,
					informationTypes = ["AvailablePortServices"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<ServiceAvailability> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = ServiceAvailability,
			};
		}

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<TerminalViewModel.ServiceAvailabilityViewModel> ServiceAvailabilities { get; set; } = new();

		[Category("InformationBindings")]
		public ObservableCollection<TerminalViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. ServiceAvailabilities.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class LayoutDivisionViewModel : featureBindingViewModel<S131.LayoutDivisionViewModel>, IFeatureBindings {
			public LayoutDivisionViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 1,
					upper = 1,
					association = "LayoutDivision",
					role = "componentOf",
					roleType = roleType.aggregation,
					featureTypes = ["HarbourAreaSection"],
				},
				new featureBindingDefinition {
					lower = 0,
					upper = default,
					association = "LayoutDivision",
					role = "layoutUnit",
					roleType = roleType.association,
					featureTypes = ["Berth"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<LayoutDivision> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LayoutDivision,
			};
		}

		public class InfrastructureViewModel : featureBindingViewModel<S131.InfrastructureViewModel>, IFeatureBindings {
			public InfrastructureViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 0,
					upper = default,
					association = "Infrastructure",
					role = "hasInfrastructure",
					roleType = roleType.association,
					featureTypes = ["HarbourPhysicalInfrastructure"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<Infrastructure> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = Infrastructure,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<TerminalViewModel.LayoutDivisionViewModel> LayoutDivisions { get; set; } = new();

		[Category("FeatureBindings")]
		public ObservableCollection<TerminalViewModel.InfrastructureViewModel> Infrastructures { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. LayoutDivisions.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. Infrastructures.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public TerminalViewModel Load(Terminal instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			portFacilityNumber = instance.portFacilityNumber;
			categoryOfTerminal = instance.categoryOfTerminal;
			categoryOfCargo.Clear();
			if (instance.categoryOfCargo is not null) {
				foreach(var e in instance.categoryOfCargo)
					categoryOfCargo.Add(e);
			}
			product.Clear();
			if (instance.product is not null) {
				foreach(var e in instance.product)
					product.Add(e);
			}
			terminalIdentifier = instance.terminalIdentifier;
			sMDGTerminalCode = instance.sMDGTerminalCode;
			uNLocationCode = instance.uNLocationCode;
			return this;
		}

		public override string Serialize() {
			var instance = new Terminal {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				portFacilityNumber = this.portFacilityNumber,
				categoryOfTerminal = this.categoryOfTerminal,
				categoryOfCargo = this.categoryOfCargo.ToList(),
				product = this.product.ToList(),
				terminalIdentifier = this.terminalIdentifier,
				sMDGTerminalCode = this.sMDGTerminalCode,
				uNLocationCode = this.uNLocationCode,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Terminal Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			portFacilityNumber = this._portFacilityNumber,
			categoryOfTerminal = this._categoryOfTerminal,
			categoryOfCargo = this.categoryOfCargo.ToList(),
			product = this.product.ToList(),
			terminalIdentifier = this._terminalIdentifier,
			sMDGTerminalCode = this._sMDGTerminalCode,
			uNLocationCode = this._uNLocationCode,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Terminal._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Terminal._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Terminal._featureBindingDefinitions;

		public TerminalViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public TerminalViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Terminal";

		public TerminalViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			categoryOfCargo.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfCargo));
			};
			product.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(product));
			};
			ServiceAvailabilities.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(ServiceAvailabilities));
			};
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			LayoutDivisions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(LayoutDivisions));
			};
			Infrastructures.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(Infrastructures));
			};
		}
	}



	/// <summary>
	/// An area of water or enlargement of a channel used for turning vessels.
	/// </summary>
	[CategoryOrder("TurningBasin",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TurningBasinViewModel : FeatureViewModel<TurningBasin> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private depthsDescriptionViewModel? _depthsDescription  = default;

		[Category("TurningBasin")]
		[ExpandableObject]
		[Optional]
		public depthsDescriptionViewModel? depthsDescription {
			get {
				return _depthsDescription;
			}
			set {
				SetValue(ref _depthsDescription, value);
			}
		}

		private String? _locationByText  = default;

		[Category("TurningBasin")]
		[Editor(typeof(Editors.HorizonEditor<TurningBasin>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationByText {
			get {
				return _locationByText;
			}
			set {
				SetValue(ref _locationByText, value);
			}
		}

		private markedByViewModel? _markedBy  = default;

		[Category("TurningBasin")]
		[ExpandableObject]
		[Optional]
		public markedByViewModel? markedBy {
			get {
				return _markedBy;
			}
			set {
				SetValue(ref _markedBy, value);
			}
		}

		private iSPSLevel? _iSPSLevel  = default;

		[Category("TurningBasin")]
		[Editor(typeof(Editors.HorizonEditor<TurningBasin>), typeof(Editors.HorizonEditor))]
		[Optional]
		public iSPSLevel? iSPSLevel {
			get {
				return _iSPSLevel;
			}
			set {
				SetValue(ref _iSPSLevel, value);
			}
		}

		[Browsable(false)]
		public iSPSLevel[] iSPSLevelList => [(iSPSLevel)1,(iSPSLevel)2,(iSPSLevel)3];


		#region InformationBindings

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<TurningBasinViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class LayoutDivisionViewModel : featureBindingViewModel<S131.LayoutDivisionViewModel>, IFeatureBindings {
			public LayoutDivisionViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 1,
					upper = 1,
					association = "LayoutDivision",
					role = "componentOf",
					roleType = roleType.aggregation,
					featureTypes = ["HarbourAreaSection"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<LayoutDivision> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LayoutDivision,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<TurningBasinViewModel.LayoutDivisionViewModel> LayoutDivisions { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. LayoutDivisions.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public TurningBasinViewModel Load(TurningBasin instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			depthsDescription = new ();
			if (instance.depthsDescription != default) {
				depthsDescription.Load(instance.depthsDescription);
			}
			locationByText = instance.locationByText;
			markedBy = new ();
			if (instance.markedBy != default) {
				markedBy.Load(instance.markedBy);
			}
			iSPSLevel = instance.iSPSLevel;
			return this;
		}

		public override string Serialize() {
			var instance = new TurningBasin {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				depthsDescription = this.depthsDescription?.Model,
				locationByText = this.locationByText,
				markedBy = this.markedBy?.Model,
				iSPSLevel = this.iSPSLevel,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public TurningBasin Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			depthsDescription = this._depthsDescription?.Model,
			locationByText = this._locationByText,
			markedBy = this._markedBy?.Model,
			iSPSLevel = this._iSPSLevel,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => TurningBasin._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. TurningBasin._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => TurningBasin._featureBindingDefinitions;

		public TurningBasinViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public TurningBasinViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Turning Basin";

		public TurningBasinViewModel() : base() {
			interoperabilityIdentifier.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(interoperabilityIdentifier));
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
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			LayoutDivisions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(LayoutDivisions));
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
		private String? _locationMRN  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationMRN {
			get {
				return _locationMRN;
			}
			set {
				SetValue(ref _locationMRN, value);
			}
		}

		private String? _globalLocationNumber  = default;

		[Category("FeatureType")]
		[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();

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
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<graphicViewModel> graphic  { get; set; } = new ();

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

		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();




		private categoryOfPortSection _categoryOfPortSection  = default;

		[Category("WaterwayArea")]
		[Editor(typeof(Editors.HorizonEditor<WaterwayArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public categoryOfPortSection categoryOfPortSection {
			get {
				return _categoryOfPortSection;
			}
			set {
				SetValue(ref _categoryOfPortSection, value);
			}
		}

		[Browsable(false)]
		public categoryOfPortSection[] categoryOfPortSectionList => [(categoryOfPortSection)1,(categoryOfPortSection)3,(categoryOfPortSection)8,(categoryOfPortSection)9,(categoryOfPortSection)11,(categoryOfPortSection)12];

		private depthsDescriptionViewModel? _depthsDescription  = default;

		[Category("WaterwayArea")]
		[ExpandableObject]
		[Optional]
		public depthsDescriptionViewModel? depthsDescription {
			get {
				return _depthsDescription;
			}
			set {
				SetValue(ref _depthsDescription, value);
			}
		}

		private String? _locationByText  = default;

		[Category("WaterwayArea")]
		[Editor(typeof(Editors.HorizonEditor<WaterwayArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationByText {
			get {
				return _locationByText;
			}
			set {
				SetValue(ref _locationByText, value);
			}
		}

		private markedByViewModel? _markedBy  = default;

		[Category("WaterwayArea")]
		[ExpandableObject]
		[Optional]
		public markedByViewModel? markedBy {
			get {
				return _markedBy;
			}
			set {
				SetValue(ref _markedBy, value);
			}
		}


		#region InformationBindings

		public class LocationHoursViewModel : informationBindingViewModel<S131.LocationHoursViewModel>, IInformationBindings {
			public LocationHoursViewModel() {
				if (informationBindings.Length == 1)
					base.role = informationBindings[0].role;
			}

			[Browsable(false)]
			public informationBindingDefinition[] informationBindings => [
				new informationBindingDefinition {
					lower = 0,
					upper = 1,
					association = "LocationHours",
					role = "facilityOperatingHours",
					roleType = roleType.association,
					informationTypes = ["ServiceHours"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public informationBinding Model => new informationBinding<LocationHours> {
				referenceId = this.informationId,
				informationType = this.informationType,
				role = this.role,
				roleType = informationBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LocationHours,
			};
		}

		[Category("InformationBindings")]
		public ObservableCollection<WaterwayAreaViewModel.LocationHoursViewModel> LocationHours { get; set; } = new();
		[Browsable(false)]

		public override informationBinding[] informationBindings => [.. LocationHours.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		#region FeatureBindings

		public class LayoutDivisionViewModel : featureBindingViewModel<S131.LayoutDivisionViewModel>, IFeatureBindings {
			public LayoutDivisionViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
			}

			[Browsable(false)]
			public featureBindingDefinition[] featureBindings => [
				new featureBindingDefinition {
					lower = 1,
					upper = 1,
					association = "LayoutDivision",
					role = "componentOf",
					roleType = roleType.aggregation,
					featureTypes = ["HarbourAreaSection"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<LayoutDivision> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = LayoutDivision,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<WaterwayAreaViewModel.LayoutDivisionViewModel> LayoutDivisions { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. LayoutDivisions.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public WaterwayAreaViewModel Load(WaterwayArea instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
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
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().Load(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Load(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().Load(e));
			}
			categoryOfPortSection = instance.categoryOfPortSection;
			depthsDescription = new ();
			if (instance.depthsDescription != default) {
				depthsDescription.Load(instance.depthsDescription);
			}
			locationByText = instance.locationByText;
			markedBy = new ();
			if (instance.markedBy != default) {
				markedBy.Load(instance.markedBy);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new WaterwayArea {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
				textContent = this.textContent.Select(e => e.Model).ToList(),
				categoryOfPortSection = this.categoryOfPortSection,
				depthsDescription = this.depthsDescription?.Model,
				locationByText = this.locationByText,
				markedBy = this.markedBy?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public WaterwayArea Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfPortSection = this._categoryOfPortSection,
			depthsDescription = this._depthsDescription?.Model,
			locationByText = this._locationByText,
			markedBy = this._markedBy?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => WaterwayArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. WaterwayArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => WaterwayArea._featureBindingDefinitions;

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
			rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(rxNCode));
			};
			graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(graphic));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			LocationHours.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnInformationBindingCollectionChanged(nameof(LocationHours));
			};
			LayoutDivisions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(LayoutDivisions));
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public DataCoverageViewModel Load(DataCoverage instance) {
			maximumDisplayScale = instance.maximumDisplayScale;
			minimumDisplayScale = instance.minimumDisplayScale;
			optimumDisplayScale = instance.optimumDisplayScale;
			return this;
		}

		public override string Serialize() {
			var instance = new DataCoverage {
				maximumDisplayScale = this.maximumDisplayScale,
				minimumDisplayScale = this.minimumDisplayScale,
				optimumDisplayScale = this.optimumDisplayScale,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DataCoverage Model => new () {
			maximumDisplayScale = this._maximumDisplayScale,
			minimumDisplayScale = this._minimumDisplayScale,
			optimumDisplayScale = this._optimumDisplayScale,
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
	/// An area within which a uniform assessment of the quality of the non-bathymetric data exists.
	/// </summary>
	[CategoryOrder("QualityOfNonBathymetricData",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class QualityOfNonBathymetricDataViewModel : FeatureViewModel<QualityOfNonBathymetricData> {
		private categoryOfTemporalVariation? _categoryOfTemporalVariation  = default;

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
		public categoryOfTemporalVariation[] categoryOfTemporalVariationList => [(categoryOfTemporalVariation)1,(categoryOfTemporalVariation)2,(categoryOfTemporalVariation)3,(categoryOfTemporalVariation)4,(categoryOfTemporalVariation)5,(categoryOfTemporalVariation)6];

		private double? _horizontalDistanceUncertainty  = default;

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

		private surveyDateRangeViewModel? _surveyDateRange  = default;

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

		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Category("QualityOfNonBathymetricData")]
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
			surveyDateRange = new ();
			if (instance.surveyDateRange != default) {
				surveyDateRange.Load(instance.surveyDateRange);
			}
			verticalUncertainty = new ();
			if (instance.verticalUncertainty != default) {
				verticalUncertainty.Load(instance.verticalUncertainty);
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
				surveyDateRange = this.surveyDateRange?.Model,
				verticalUncertainty = this.verticalUncertainty?.Model,
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
			surveyDateRange = this._surveyDateRange?.Model,
			verticalUncertainty = this._verticalUncertainty?.Model,
			information = this.information.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => QualityOfNonBathymetricData._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. QualityOfNonBathymetricData._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => QualityOfNonBathymetricData._featureBindingDefinitions;

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
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}



	/// <summary>
	/// The horizontal plane or tidal datum to which soundings have been reduced. Also called datum for sounding reduction.
	/// </summary>
	[CategoryOrder("SoundingDatum",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SoundingDatumViewModel : FeatureViewModel<SoundingDatum> {
		private verticalDatum _verticalDatum  = default;

		[Category("SoundingDatum")]
		[Editor(typeof(Editors.HorizonEditor<SoundingDatum>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public verticalDatum verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		[Browsable(false)]
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)19,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)44];

		[Category("SoundingDatum")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public SoundingDatumViewModel Load(SoundingDatum instance) {
			verticalDatum = instance.verticalDatum;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new SoundingDatum {
				verticalDatum = this.verticalDatum,
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SoundingDatum Model => new () {
			verticalDatum = this._verticalDatum,
			information = this.information.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => SoundingDatum._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SoundingDatum._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SoundingDatum._featureBindingDefinitions;

		public SoundingDatumViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SoundingDatumViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Sounding Datum";

		public SoundingDatumViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}



	/// <summary>
	/// Any level surface (for example Mean Sea Level) taken as a surface of reference to which the elevations within a data set are reduced. Also called datum level, reference level, reference plane, levelling datum, datum for heights.
	/// </summary>
	[CategoryOrder("VerticalDatumOfData",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class VerticalDatumOfDataViewModel : FeatureViewModel<VerticalDatumOfData> {
		private verticalDatum _verticalDatum  = default;

		[Category("VerticalDatumOfData")]
		[Editor(typeof(Editors.HorizonEditor<VerticalDatumOfData>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public verticalDatum verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		[Browsable(false)]
		public verticalDatum[] verticalDatumList => [(verticalDatum)3,(verticalDatum)13,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)44];

		[Category("VerticalDatumOfData")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public VerticalDatumOfDataViewModel Load(VerticalDatumOfData instance) {
			verticalDatum = instance.verticalDatum;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new VerticalDatumOfData {
				verticalDatum = this.verticalDatum,
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public VerticalDatumOfData Model => new () {
			verticalDatum = this._verticalDatum,
			information = this.information.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => VerticalDatumOfData._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. VerticalDatumOfData._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => VerticalDatumOfData._featureBindingDefinitions;

		public VerticalDatumOfDataViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public VerticalDatumOfDataViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Vertical Datum of Data";

		public VerticalDatumOfDataViewModel() : base() {
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
		private int _textOffsetBearing  = default;

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

		[Category("TextPlacement")]
		[Multiplicity(1, 2)]
		public ObservableCollection<textType> textType  { get; set; } = new ();

		[Browsable(false)]
		public textType[] textTypeList => [(textType)1];

		private int? _scaleMinimum  = default;

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

		public class TextAssociationViewModel : featureBindingViewModel<S131.TextAssociationViewModel>, IFeatureBindings {
			public TextAssociationViewModel() {
				if (featureBindings.Length == 1)
					base.role = featureBindings[0].role;
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

		public static AvailablePortServicesViewModel LoadInformationBinding(this AvailablePortServicesViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
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

		public static EntranceViewModel LoadInformationBinding(this EntranceViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
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

		public static AnchorBerthViewModel LoadInformationBinding(this AnchorBerthViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceAvailability> serviceAvailability) {
					instance.ServiceAvailabilities.Add(new AnchorBerthViewModel.ServiceAvailabilityViewModel {
						informationId = serviceAvailability.referenceId,
						informationType = serviceAvailability.informationType,
						role = serviceAvailability.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new AnchorBerthViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static AnchorageAreaViewModel LoadInformationBinding(this AnchorageAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new AnchorageAreaViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static AutomatedGuidedVehicleViewModel LoadInformationBinding(this AutomatedGuidedVehicleViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new AutomatedGuidedVehicleViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static BerthViewModel LoadInformationBinding(this BerthViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceAvailability> serviceAvailability) {
					instance.ServiceAvailabilities.Add(new BerthViewModel.ServiceAvailabilityViewModel {
						informationId = serviceAvailability.referenceId,
						informationType = serviceAvailability.informationType,
						role = serviceAvailability.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new BerthViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static BerthPositionViewModel LoadInformationBinding(this BerthPositionViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static BollardViewModel LoadInformationBinding(this BollardViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DockAreaViewModel LoadInformationBinding(this DockAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceAvailability> serviceAvailability) {
					instance.ServiceAvailabilities.Add(new DockAreaViewModel.ServiceAvailabilityViewModel {
						informationId = serviceAvailability.referenceId,
						informationType = serviceAvailability.informationType,
						role = serviceAvailability.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new DockAreaViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static DryDockViewModel LoadInformationBinding(this DryDockViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new DryDockViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static DolphinViewModel LoadInformationBinding(this DolphinViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DumpingGroundViewModel LoadInformationBinding(this DumpingGroundViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new DumpingGroundViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static FenderLineViewModel LoadInformationBinding(this FenderLineViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static FloatingDockViewModel LoadInformationBinding(this FloatingDockViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new FloatingDockViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static GridironViewModel LoadInformationBinding(this GridironViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new GridironViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static HarbourAreaAdministrativeViewModel LoadInformationBinding(this HarbourAreaAdministrativeViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceAvailability> serviceAvailability) {
					instance.ServiceAvailabilities.Add(new HarbourAreaAdministrativeViewModel.ServiceAvailabilityViewModel {
						informationId = serviceAvailability.referenceId,
						informationType = serviceAvailability.informationType,
						role = serviceAvailability.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new HarbourAreaAdministrativeViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static HarbourAreaSectionViewModel LoadInformationBinding(this HarbourAreaSectionViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceAvailability> serviceAvailability) {
					instance.ServiceAvailabilities.Add(new HarbourAreaSectionViewModel.ServiceAvailabilityViewModel {
						informationId = serviceAvailability.referenceId,
						informationType = serviceAvailability.informationType,
						role = serviceAvailability.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new HarbourAreaSectionViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static HarbourBasinViewModel LoadInformationBinding(this HarbourBasinViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new HarbourBasinViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static LockBasinViewModel LoadInformationBinding(this LockBasinViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new LockBasinViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static LockBasinPartViewModel LoadInformationBinding(this LockBasinPartViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new LockBasinPartViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static MooringBuoyViewModel LoadInformationBinding(this MooringBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static MooringWarpingFacilityViewModel LoadInformationBinding(this MooringWarpingFacilityViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceAvailability> serviceAvailability) {
					instance.ServiceAvailabilities.Add(new MooringWarpingFacilityViewModel.ServiceAvailabilityViewModel {
						informationId = serviceAvailability.referenceId,
						informationType = serviceAvailability.informationType,
						role = serviceAvailability.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new MooringWarpingFacilityViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static OnshorePowerFacilityViewModel LoadInformationBinding(this OnshorePowerFacilityViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new OnshorePowerFacilityViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static OuterLimitViewModel LoadInformationBinding(this OuterLimitViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<LimitEntrance> limitEntrance) {
					instance.LimitEntrances.Add(new OuterLimitViewModel.LimitEntranceViewModel {
						informationId = limitEntrance.referenceId,
						informationType = limitEntrance.informationType,
						role = limitEntrance.role,
					});
				}
			}
			return instance;
		}

		public static PilotBoardingPlaceViewModel LoadInformationBinding(this PilotBoardingPlaceViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new PilotBoardingPlaceViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static SeaplaneLandingAreaViewModel LoadInformationBinding(this SeaplaneLandingAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new SeaplaneLandingAreaViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static ShipLiftViewModel LoadInformationBinding(this ShipLiftViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new ShipLiftViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static StraddleCarrierViewModel LoadInformationBinding(this StraddleCarrierViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new StraddleCarrierViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static TerminalViewModel LoadInformationBinding(this TerminalViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceAvailability> serviceAvailability) {
					instance.ServiceAvailabilities.Add(new TerminalViewModel.ServiceAvailabilityViewModel {
						informationId = serviceAvailability.referenceId,
						informationType = serviceAvailability.informationType,
						role = serviceAvailability.role,
					});
				}
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new TerminalViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static TurningBasinViewModel LoadInformationBinding(this TurningBasinViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new TurningBasinViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
					});
				}
			}
			return instance;
		}

		public static WaterwayAreaViewModel LoadInformationBinding(this WaterwayAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<LocationHours> locationHours) {
					instance.LocationHours.Add(new WaterwayAreaViewModel.LocationHoursViewModel {
						informationId = locationHours.referenceId,
						informationType = locationHours.informationType,
						role = locationHours.role,
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

		public static SoundingDatumViewModel LoadInformationBinding(this SoundingDatumViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static VerticalDatumOfDataViewModel LoadInformationBinding(this VerticalDatumOfDataViewModel instance, informationBinding[] bindings) {
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
		public static AnchorBerthViewModel LoadFeatureBinding(this AnchorBerthViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<PrimaryAuxiliaryFacility> primaryAuxiliaryFacility) {
					instance.PrimaryAuxiliaryFacilities.Add(new AnchorBerthViewModel.PrimaryAuxiliaryFacilityViewModel {
						featureId = primaryAuxiliaryFacility.referenceId,
						featureType = primaryAuxiliaryFacility.featureType,
						role = primaryAuxiliaryFacility.role,
					});
				}
			}
			return instance;
		}

		public static AnchorageAreaViewModel LoadFeatureBinding(this AnchorageAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<LayoutDivision> layoutDivision) {
					instance.LayoutDivisions.Add(new AnchorageAreaViewModel.LayoutDivisionViewModel {
						featureId = layoutDivision.referenceId,
						featureType = layoutDivision.featureType,
						role = layoutDivision.role,
					});
				}
			}
			return instance;
		}

		public static AutomatedGuidedVehicleViewModel LoadFeatureBinding(this AutomatedGuidedVehicleViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static BerthViewModel LoadFeatureBinding(this BerthViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<Demarcation> demarcation) {
					instance.Demarcations.Add(new BerthViewModel.DemarcationViewModel {
						featureId = demarcation.referenceId,
						featureType = demarcation.featureType,
						role = demarcation.role,
					});
				}
				if(featureBinding is featureBinding<LayoutDivision> layoutDivision) {
					instance.LayoutDivisions.Add(new BerthViewModel.LayoutDivisionViewModel {
						featureId = layoutDivision.referenceId,
						featureType = layoutDivision.featureType,
						role = layoutDivision.role,
					});
				}
			}
			return instance;
		}

		public static BerthPositionViewModel LoadFeatureBinding(this BerthPositionViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<Demarcation> demarcation) {
					instance.Demarcations.Add(new BerthPositionViewModel.DemarcationViewModel {
						featureId = demarcation.referenceId,
						featureType = demarcation.featureType,
						role = demarcation.role,
					});
				}
				if(featureBinding is featureBinding<PrimaryAuxiliaryFacility> primaryAuxiliaryFacility) {
					instance.PrimaryAuxiliaryFacilities.Add(new BerthPositionViewModel.PrimaryAuxiliaryFacilityViewModel {
						featureId = primaryAuxiliaryFacility.referenceId,
						featureType = primaryAuxiliaryFacility.featureType,
						role = primaryAuxiliaryFacility.role,
					});
				}
			}
			return instance;
		}

		public static BollardViewModel LoadFeatureBinding(this BollardViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static DockAreaViewModel LoadFeatureBinding(this DockAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<LayoutDivision> layoutDivision) {
					instance.LayoutDivisions.Add(new DockAreaViewModel.LayoutDivisionViewModel {
						featureId = layoutDivision.referenceId,
						featureType = layoutDivision.featureType,
						role = layoutDivision.role,
					});
				}
			}
			return instance;
		}

		public static DryDockViewModel LoadFeatureBinding(this DryDockViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static DolphinViewModel LoadFeatureBinding(this DolphinViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static DumpingGroundViewModel LoadFeatureBinding(this DumpingGroundViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<LayoutDivision> layoutDivision) {
					instance.LayoutDivisions.Add(new DumpingGroundViewModel.LayoutDivisionViewModel {
						featureId = layoutDivision.referenceId,
						featureType = layoutDivision.featureType,
						role = layoutDivision.role,
					});
				}
			}
			return instance;
		}

		public static FenderLineViewModel LoadFeatureBinding(this FenderLineViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<LayoutDivision> layoutDivision) {
					instance.LayoutDivisions.Add(new FenderLineViewModel.LayoutDivisionViewModel {
						featureId = layoutDivision.referenceId,
						featureType = layoutDivision.featureType,
						role = layoutDivision.role,
					});
				}
			}
			return instance;
		}

		public static FloatingDockViewModel LoadFeatureBinding(this FloatingDockViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static GridironViewModel LoadFeatureBinding(this GridironViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static HarbourAreaAdministrativeViewModel LoadFeatureBinding(this HarbourAreaAdministrativeViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<JurisdictionalLimit> jurisdictionalLimit) {
					instance.JurisdictionalLimits.Add(new HarbourAreaAdministrativeViewModel.JurisdictionalLimitViewModel {
						featureId = jurisdictionalLimit.referenceId,
						featureType = jurisdictionalLimit.featureType,
						role = jurisdictionalLimit.role,
					});
				}
				if(featureBinding is featureBinding<LayoutDivision> layoutDivision) {
					instance.LayoutDivisions.Add(new HarbourAreaAdministrativeViewModel.LayoutDivisionViewModel {
						featureId = layoutDivision.referenceId,
						featureType = layoutDivision.featureType,
						role = layoutDivision.role,
					});
				}
			}
			return instance;
		}

		public static HarbourAreaSectionViewModel LoadFeatureBinding(this HarbourAreaSectionViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<LayoutDivision> layoutDivision) {
					instance.LayoutDivisions.Add(new HarbourAreaSectionViewModel.LayoutDivisionViewModel {
						featureId = layoutDivision.referenceId,
						featureType = layoutDivision.featureType,
						role = layoutDivision.role,
					});
				}
				if(featureBinding is featureBinding<Subsection> subsection) {
					instance.Subsections.Add(new HarbourAreaSectionViewModel.SubsectionViewModel {
						featureId = subsection.referenceId,
						featureType = subsection.featureType,
						role = subsection.role,
					});
				}
				if(featureBinding is featureBinding<Infrastructure> infrastructure) {
					instance.Infrastructures.Add(new HarbourAreaSectionViewModel.InfrastructureViewModel {
						featureId = infrastructure.referenceId,
						featureType = infrastructure.featureType,
						role = infrastructure.role,
					});
				}
			}
			return instance;
		}

		public static HarbourBasinViewModel LoadFeatureBinding(this HarbourBasinViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<LayoutDivision> layoutDivision) {
					instance.LayoutDivisions.Add(new HarbourBasinViewModel.LayoutDivisionViewModel {
						featureId = layoutDivision.referenceId,
						featureType = layoutDivision.featureType,
						role = layoutDivision.role,
					});
				}
			}
			return instance;
		}

		public static LockBasinViewModel LoadFeatureBinding(this LockBasinViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LockBasinPartViewModel LoadFeatureBinding(this LockBasinPartViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static MooringBuoyViewModel LoadFeatureBinding(this MooringBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static MooringWarpingFacilityViewModel LoadFeatureBinding(this MooringWarpingFacilityViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<PrimaryAuxiliaryFacility> primaryAuxiliaryFacility) {
					instance.PrimaryAuxiliaryFacilities.Add(new MooringWarpingFacilityViewModel.PrimaryAuxiliaryFacilityViewModel {
						featureId = primaryAuxiliaryFacility.referenceId,
						featureType = primaryAuxiliaryFacility.featureType,
						role = primaryAuxiliaryFacility.role,
					});
				}
			}
			return instance;
		}

		public static OnshorePowerFacilityViewModel LoadFeatureBinding(this OnshorePowerFacilityViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static OuterLimitViewModel LoadFeatureBinding(this OuterLimitViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<JurisdictionalLimit> jurisdictionalLimit) {
					instance.JurisdictionalLimits.Add(new OuterLimitViewModel.JurisdictionalLimitViewModel {
						featureId = jurisdictionalLimit.referenceId,
						featureType = jurisdictionalLimit.featureType,
						role = jurisdictionalLimit.role,
					});
				}
			}
			return instance;
		}

		public static PilotBoardingPlaceViewModel LoadFeatureBinding(this PilotBoardingPlaceViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<LayoutDivision> layoutDivision) {
					instance.LayoutDivisions.Add(new PilotBoardingPlaceViewModel.LayoutDivisionViewModel {
						featureId = layoutDivision.referenceId,
						featureType = layoutDivision.featureType,
						role = layoutDivision.role,
					});
				}
			}
			return instance;
		}

		public static SeaplaneLandingAreaViewModel LoadFeatureBinding(this SeaplaneLandingAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<LayoutDivision> layoutDivision) {
					instance.LayoutDivisions.Add(new SeaplaneLandingAreaViewModel.LayoutDivisionViewModel {
						featureId = layoutDivision.referenceId,
						featureType = layoutDivision.featureType,
						role = layoutDivision.role,
					});
				}
			}
			return instance;
		}

		public static ShipLiftViewModel LoadFeatureBinding(this ShipLiftViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static StraddleCarrierViewModel LoadFeatureBinding(this StraddleCarrierViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static TerminalViewModel LoadFeatureBinding(this TerminalViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<LayoutDivision> layoutDivision) {
					instance.LayoutDivisions.Add(new TerminalViewModel.LayoutDivisionViewModel {
						featureId = layoutDivision.referenceId,
						featureType = layoutDivision.featureType,
						role = layoutDivision.role,
					});
				}
				if(featureBinding is featureBinding<Infrastructure> infrastructure) {
					instance.Infrastructures.Add(new TerminalViewModel.InfrastructureViewModel {
						featureId = infrastructure.referenceId,
						featureType = infrastructure.featureType,
						role = infrastructure.role,
					});
				}
			}
			return instance;
		}

		public static TurningBasinViewModel LoadFeatureBinding(this TurningBasinViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<LayoutDivision> layoutDivision) {
					instance.LayoutDivisions.Add(new TurningBasinViewModel.LayoutDivisionViewModel {
						featureId = layoutDivision.referenceId,
						featureType = layoutDivision.featureType,
						role = layoutDivision.role,
					});
				}
			}
			return instance;
		}

		public static WaterwayAreaViewModel LoadFeatureBinding(this WaterwayAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<LayoutDivision> layoutDivision) {
					instance.LayoutDivisions.Add(new WaterwayAreaViewModel.LayoutDivisionViewModel {
						featureId = layoutDivision.referenceId,
						featureType = layoutDivision.featureType,
						role = layoutDivision.role,
					});
				}
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

		public static SoundingDatumViewModel LoadFeatureBinding(this SoundingDatumViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static VerticalDatumOfDataViewModel LoadFeatureBinding(this VerticalDatumOfDataViewModel instance, featureBinding[] bindings) {
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
