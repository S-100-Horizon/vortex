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
			"Berth" => new BerthViewModel { Name = name },
			"BerthPosition" => new BerthPositionViewModel { Name = name },
			"DockArea" => new DockAreaViewModel { Name = name },
			"DryDock" => new DryDockViewModel { Name = name },
			"DumpingGround" => new DumpingGroundViewModel { Name = name },
			"FloatingDock" => new FloatingDockViewModel { Name = name },
			"Gridiron" => new GridironViewModel { Name = name },
			"HarbourAreaAdministrative" => new HarbourAreaAdministrativeViewModel { Name = name },
			"HarbourAreaSection" => new HarbourAreaSectionViewModel { Name = name },
			"HarbourBasin" => new HarbourBasinViewModel { Name = name },
			"HarbourFacility" => new HarbourFacilityViewModel { Name = name },
			"MooringWarpingFacility" => new MooringWarpingFacilityViewModel { Name = name },
			"OuterLimit" => new OuterLimitViewModel { Name = name },
			"PilotBoardingPlace" => new PilotBoardingPlaceViewModel { Name = name },
			"SeaplaneLandingArea" => new SeaplaneLandingAreaViewModel { Name = name },
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
			("AdditionalInformation", "providesInformation") => ["NauticalInformation"],
			("InclusionType", "isApplicableTo") => ["Applicability"],
			("RelatedOrganisation", "theOrganisation") => ["Authority"],
			("InclusionType", "theApplicableRxN") => ["AbstractRxN"],
			("PermissionType", "vslLocation") => ["InformationType"],
			("AuthorityContact", "theContactDetails") => ["ContactDetails"],
			("RelatedOrganisation", "theInformation") => ["AbstractRxN"],
			("AuthorityHours", "theServiceHours") => ["ServiceHours"],
			("AuthorityContact", "theAuthority") => ["Authority"],
			("AdditionalInformation", "informationProvidedFor") => ["InformationType"],
			("ExceptionalWorkday", "partialWorkingDay") => ["NonStandardWorkingDay"],
			("AuthorityHours", "theAuthority_srvHrs") => ["Authority"],
			("PermissionType", "permission") => ["Applicability"],
			("AssociatedRxN", "theRxN") => ["AbstractRxN"],
			("ServiceContact", "theContactDetails") => ["ContactDetails"],
			("ServiceControl", "controlAuthority") => ["Authority"],
			("ServiceAvailability", "serviceDescriptionReference") => ["AvailablePortServices"],
			("LocationHours", "location_srvHrs") => ["ServiceHours"],
			("LimitEntrance", "entranceReference") => ["Entrance"],
			_ => throw new InvalidOperationException(),
		};

		public static ICollection<string> FeatureAssociationBindings(string association, string role) => (association, role) switch {
			("TextAssociation", "positions") => ["TextPlacement"],
			("Infrastructure", "infrastructureLocation") => ["HarbourAreaSection","Terminal"],
			("PrimaryAuxiliaryFacility", "auxiliaryFacility") => ["MooringWarpingFacility"],
			("LayoutDivision", "componentOf") => ["HarbourAreaSection","Terminal","HarbourAreaAdministrative"],
			("Demarcation", "demarcationIndicator") => ["BerthPosition"],
			("Demarcation", "demarcatedFeature") => ["Berth"],
			("JurisdictionalLimit", "limitExtent") => ["OuterLimit"],
			("LayoutDivision", "layoutUnit") => ["HarbourAreaSection","AnchorageArea","Berth","DockArea","DumpingGround","HarbourBasin","PilotBoardingPlace","SeaplaneLandingArea","Terminal","TurningBasin","WaterwayArea"],
			("Subsection", "constitute") => ["HarbourAreaSection"],
			("Subsection", "subUnit") => ["HarbourAreaSection"],
			("Infrastructure", "hasInfrastructure") => ["HarbourPhysicalInfrastructure"],
			("PrimaryAuxiliaryFacility", "primaryFacility") => ["AnchorBerth","BerthPosition"],
			("JurisdictionalLimit", "limitReference") => ["HarbourAreaAdministrative"],
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
	public partial class bearingInformationViewModel : ComplexViewModel<bearingInformation> {
		private cardinalDirection? _cardinalDirection  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(cardinalDirectionList), typeof(cardinalDirection))]
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


		public bearingInformationViewModel LoadbearingInformation(bearingInformation instance) {
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
					information.Add(new informationViewModel().Loadinformation(e));
			}
			orientation = new ();
			if (instance.orientation != default) {
				orientation.Loadorientation(instance.orientation);
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

		public override ComplexViewModel<bearingInformation> Load(bearingInformation instance) => this.LoadbearingInformation(instance);

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
	/// Description of services related to the goods or items carried by vessels.
	/// </summary>
	[CategoryOrder("cargoServicesDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class cargoServicesDescriptionViewModel : ComplexViewModel<cargoServicesDescription> {
		[Category("cargoServicesDescription")]
		[Multiplicity(1)]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public cargoServicesDescriptionViewModel LoadcargoServicesDescription(cargoServicesDescription instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
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

		public override ComplexViewModel<cargoServicesDescription> Load(cargoServicesDescription instance) => this.LoadcargoServicesDescription(instance);

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

		[Category("constructionInformation")]
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

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(conditionList), typeof(condition))]
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

		[Optional]
		public String? locationByText {
			get {
				return _locationByText;
			}
			set {
				SetValue(ref _locationByText, value);
			}
		}
		[Category("constructionInformation")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public constructionInformationViewModel LoadconstructionInformation(constructionInformation instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			condition = instance.condition;
			development = instance.development;
			locationByText = instance.locationByText;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
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

		public override ComplexViewModel<constructionInformation> Load(constructionInformation instance) => this.LoadconstructionInformation(instance);

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
		[Category("contactAddress")]
		[Optional]
		public ObservableCollection<String> deliveryPoint  { get; set; } = new ();
		private String? _cityName  = default;

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

		[Optional]
		public String? postalCode {
			get {
				return _postalCode;
			}
			set {
				SetValue(ref _postalCode, value);
			}
		}


		public contactAddressViewModel LoadcontactAddress(contactAddress instance) {
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

		public override ComplexViewModel<contactAddress> Load(contactAddress instance) => this.LoadcontactAddress(instance);

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

		[DomainModel.EnumerationAttribute(nameof(categoryOfDepthsDescriptionList), typeof(categoryOfDepthsDescription))]
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
		[Category("depthsDescription")]
		[Multiplicity(1)]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public depthsDescriptionViewModel LoaddepthsDescription(depthsDescription instance) {
			categoryOfDepthsDescription = instance.categoryOfDepthsDescription;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
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

		public override ComplexViewModel<depthsDescription> Load(depthsDescription instance) => this.LoaddepthsDescription(instance);

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
		[Category("facilitiesLayoutDescription")]
		[Multiplicity(1)]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public facilitiesLayoutDescriptionViewModel LoadfacilitiesLayoutDescription(facilitiesLayoutDescription instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
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

		public override ComplexViewModel<facilitiesLayoutDescription> Load(facilitiesLayoutDescription instance) => this.LoadfacilitiesLayoutDescription(instance);

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
		private Boolean? _displayName  = default;

		[Optional]
		public Boolean? displayName {
			get {
				return _displayName;
			}
			set {
				SetValue(ref _displayName, value);
			}
		}
		private String? _language  = default;

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

		[Mandatory]
		public String name {
			get {
				return _name;
			}
			set {
				SetValue(ref _name, value);
			}
		}


		public featureNameViewModel LoadfeatureName(featureName instance) {
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

		public override ComplexViewModel<featureName> Load(featureName instance) => this.LoadfeatureName(instance);

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
		[Optional]
		public String? dateEnd {
			get {
				return _dateEnd;
			}
			set {
				SetValue(ref _dateEnd, value);
			}
		}


		public fixedDateRangeViewModel LoadfixedDateRange(fixedDateRange instance) {
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

		public override ComplexViewModel<fixedDateRange> Load(fixedDateRange instance) => this.LoadfixedDateRange(instance);

		public override string? ToString() => $"Fixed Date Range";
	}


	/// <summary>
	/// A pair of frequencies for transmitting and receiving radio signals. The shore station transmits and receives on the frequencies indicated.
	/// </summary>
	[CategoryOrder("frequencyPair",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class frequencyPairViewModel : ComplexViewModel<frequencyPair> {
		[Category("frequencyPair")]
		[Optional]
		public ObservableCollection<int> frequencyShoreStationTransmits  { get; set; } = new ();
		[Category("frequencyPair")]
		[Optional]
		public ObservableCollection<int> frequencyShoreStationReceives  { get; set; } = new ();
		[Category("frequencyPair")]
		[Optional]
		public ObservableCollection<String> contactInstructions  { get; set; } = new ();


		public frequencyPairViewModel LoadfrequencyPair(frequencyPair instance) {
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

		public override ComplexViewModel<frequencyPair> Load(frequencyPair instance) => this.LoadfrequencyPair(instance);

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
	/// General information about the port or harbour area.
	/// </summary>
	[CategoryOrder("generalHarbourInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class generalHarbourInformationViewModel : ComplexViewModel<generalHarbourInformation> {
		private generalPortDescriptionViewModel? _generalPortDescription  = default;

		[Category("generalHarbourInformation")]
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

		[Category("generalHarbourInformation")]
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

		[Category("generalHarbourInformation")]
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

		[Category("generalHarbourInformation")]
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

		[Category("generalHarbourInformation")]
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
		[Category("generalHarbourInformation")]
		[Optional]
		public ObservableCollection<weatherResourceViewModel> weatherResource  { get; set; } = new ();


		public generalHarbourInformationViewModel LoadgeneralHarbourInformation(generalHarbourInformation instance) {
			generalPortDescription = new ();
			if (instance.generalPortDescription != default) {
				generalPortDescription.LoadgeneralPortDescription(instance.generalPortDescription);
			}
			facilitiesLayoutDescription = new ();
			if (instance.facilitiesLayoutDescription != default) {
				facilitiesLayoutDescription.LoadfacilitiesLayoutDescription(instance.facilitiesLayoutDescription);
			}
			limitsDescription = new ();
			if (instance.limitsDescription != default) {
				limitsDescription.LoadlimitsDescription(instance.limitsDescription);
			}
			constructionInformation = new ();
			if (instance.constructionInformation != default) {
				constructionInformation.LoadconstructionInformation(instance.constructionInformation);
			}
			cargoServicesDescription = new ();
			if (instance.cargoServicesDescription != default) {
				cargoServicesDescription.LoadcargoServicesDescription(instance.cargoServicesDescription);
			}
			weatherResource.Clear();
			if (instance.weatherResource is not null) {
				foreach(var e in instance.weatherResource)
					weatherResource.Add(new weatherResourceViewModel().LoadweatherResource(e));
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

		public override ComplexViewModel<generalHarbourInformation> Load(generalHarbourInformation instance) => this.LoadgeneralHarbourInformation(instance);

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
		[Category("generalPortDescription")]
		[Multiplicity(1)]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public generalPortDescriptionViewModel LoadgeneralPortDescription(generalPortDescription instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
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

		public override ComplexViewModel<generalPortDescription> Load(generalPortDescription instance) => this.LoadgeneralPortDescription(instance);

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
		[Category("graphic")]
		[Multiplicity(1)]
		public ObservableCollection<String> pictorialRepresentation  { get; set; } = new ();
		private String? _pictureCaption  = default;

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


		public graphicViewModel Loadgraphic(graphic instance) {
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
				bearingInformation.LoadbearingInformation(instance.bearingInformation);
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

		public override ComplexViewModel<graphic> Load(graphic instance) => this.Loadgraphic(instance);

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

		[Optional]
		public double? uncertaintyVariableFactor {
			get {
				return _uncertaintyVariableFactor;
			}
			set {
				SetValue(ref _uncertaintyVariableFactor, value);
			}
		}


		public horizontalPositionUncertaintyViewModel LoadhorizontalPositionUncertainty(horizontalPositionUncertainty instance) {
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

		public override ComplexViewModel<horizontalPositionUncertainty> Load(horizontalPositionUncertainty instance) => this.LoadhorizontalPositionUncertainty(instance);

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

		[Optional]
		public String? fileReference {
			get {
				return _fileReference;
			}
			set {
				SetValue(ref _fileReference, value);
			}
		}
		[Category("information")]
		[Optional]
		public ObservableCollection<String> headline  { get; set; } = new ();
		private String? _language  = default;

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

		[Optional]
		public String? text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
			}
		}


		public informationViewModel Loadinformation(information instance) {
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

		public override ComplexViewModel<information> Load(information instance) => this.Loadinformation(instance);

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
		[Category("landmarkDescription")]
		[Multiplicity(1)]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public landmarkDescriptionViewModel LoadlandmarkDescription(landmarkDescription instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
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

		public override ComplexViewModel<landmarkDescription> Load(landmarkDescription instance) => this.LoadlandmarkDescription(instance);

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
		[Category("limitsDescription")]
		[Multiplicity(1)]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public limitsDescriptionViewModel LoadlimitsDescription(limitsDescription instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
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

		public override ComplexViewModel<limitsDescription> Load(limitsDescription instance) => this.LoadlimitsDescription(instance);

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
		[Category("majorLightDescription")]
		[Multiplicity(1)]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public majorLightDescriptionViewModel LoadmajorLightDescription(majorLightDescription instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
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

		public override ComplexViewModel<majorLightDescription> Load(majorLightDescription instance) => this.LoadmajorLightDescription(instance);

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
		[Category("markedBy")]
		[Multiplicity(1)]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public markedByViewModel LoadmarkedBy(markedBy instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
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

		public override ComplexViewModel<markedBy> Load(markedBy instance) => this.LoadmarkedBy(instance);

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
		[Category("offshoreMarkDescription")]
		[Multiplicity(1)]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public offshoreMarkDescriptionViewModel LoadoffshoreMarkDescription(offshoreMarkDescription instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
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

		public override ComplexViewModel<offshoreMarkDescription> Load(offshoreMarkDescription instance) => this.LoadoffshoreMarkDescription(instance);

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
		private String _onlineResourceLinkageURL  = string.Empty;

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

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(onlineFunctionList), typeof(onlineFunction))]
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

		[Optional]
		public String? protocolRequest {
			get {
				return _protocolRequest;
			}
			set {
				SetValue(ref _protocolRequest, value);
			}
		}


		public onlineResourceViewModel LoadonlineResource(onlineResource instance) {
			onlineResourceLinkageURL = instance.onlineResourceLinkageURL;
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
		public onlineResource Model => new () {
			onlineResourceLinkageURL = this._onlineResourceLinkageURL,
			protocol = this._protocol,
			applicationProfile = this._applicationProfile,
			nameOfResource = this._nameOfResource,
			onlineResourceDescription = this._onlineResourceDescription,
			onlineFunction = this._onlineFunction,
			protocolRequest = this._protocolRequest,
		};

		public override ComplexViewModel<onlineResource> Load(onlineResource instance) => this.LoadonlineResource(instance);

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

		[Mandatory]
		public double orientationValue {
			get {
				return _orientationValue;
			}
			set {
				SetValue(ref _orientationValue, value);
			}
		}


		public orientationViewModel Loadorientation(orientation instance) {
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

		public override ComplexViewModel<orientation> Load(orientation instance) => this.Loadorientation(instance);

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


		public periodicDateRangeViewModel LoadperiodicDateRange(periodicDateRange instance) {
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

		public override ComplexViewModel<periodicDateRange> Load(periodicDateRange instance) => this.LoadperiodicDateRange(instance);

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
		[Category("rxNCode")]
		[Optional]
		public ObservableCollection<String> headline  { get; set; } = new ();


		public rxNCodeViewModel LoadrxNCode(rxNCode instance) {
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

		public override ComplexViewModel<rxNCode> Load(rxNCode instance) => this.LoadrxNCode(instance);

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

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfScheduleList), typeof(categoryOfSchedule))]
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
		[Multiplicity(1)]
		public ObservableCollection<timeIntervalsByDayOfWeekViewModel> timeIntervalsByDayOfWeek  { get; set; } = new ();


		public scheduleByDayOfWeekViewModel LoadscheduleByDayOfWeek(scheduleByDayOfWeek instance) {
			categoryOfSchedule = instance.categoryOfSchedule;
			timeIntervalsByDayOfWeek.Clear();
			if (instance.timeIntervalsByDayOfWeek is not null) {
				foreach(var e in instance.timeIntervalsByDayOfWeek)
					timeIntervalsByDayOfWeek.Add(new timeIntervalsByDayOfWeekViewModel().LoadtimeIntervalsByDayOfWeek(e));
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

		public override ComplexViewModel<scheduleByDayOfWeek> Load(scheduleByDayOfWeek instance) => this.LoadscheduleByDayOfWeek(instance);

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
	[CategoryOrder("spatialAccuracy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class spatialAccuracyViewModel : ComplexViewModel<spatialAccuracy> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("spatialAccuracy")]
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

		[Category("spatialAccuracy")]
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

		[Category("spatialAccuracy")]
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


		public spatialAccuracyViewModel LoadspatialAccuracy(spatialAccuracy instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			horizontalPositionUncertainty = new ();
			if (instance.horizontalPositionUncertainty != default) {
				horizontalPositionUncertainty.LoadhorizontalPositionUncertainty(instance.horizontalPositionUncertainty);
			}
			verticalUncertainty = new ();
			if (instance.verticalUncertainty != default) {
				verticalUncertainty.LoadverticalUncertainty(instance.verticalUncertainty);
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

		public override ComplexViewModel<spatialAccuracy> Load(spatialAccuracy instance) => this.LoadspatialAccuracy(instance);

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


		public surveyDateRangeViewModel LoadsurveyDateRange(surveyDateRange instance) {
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

		public override ComplexViewModel<surveyDateRange> Load(surveyDateRange instance) => this.LoadsurveyDateRange(instance);

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

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfCommunicationPreferenceList), typeof(categoryOfCommunicationPreference))]
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

		[Optional]
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
		[Optional]
		public ObservableCollection<telecommunicationService> telecommunicationService  { get; set; } = new ();

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


		public telecommunicationsViewModel Loadtelecommunications(telecommunications instance) {
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
				scheduleByDayOfWeek.LoadscheduleByDayOfWeek(instance.scheduleByDayOfWeek);
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

		public override ComplexViewModel<telecommunications> Load(telecommunications instance) => this.Loadtelecommunications(instance);

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

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfTextList), typeof(categoryOfText))]
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
		[Category("textContent")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private onlineResourceViewModel? _onlineResource  = default;

		[Category("textContent")]
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
		private String? _source  = default;

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

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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

		[S100TruncatedDateAttribute]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}


		public textContentViewModel LoadtextContent(textContent instance) {
			categoryOfText = instance.categoryOfText;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Loadinformation(e));
			}
			onlineResource = new ();
			if (instance.onlineResource != default) {
				onlineResource.LoadonlineResource(instance.onlineResource);
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			return this;
		}

		public override string Serialize() {
			var instance = new textContent {
				categoryOfText = this.categoryOfText,
				information = this.information.Select(e => e.Model).ToList(),
				onlineResource = this.onlineResource?.Model,
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public textContent Model => new () {
			categoryOfText = this._categoryOfText,
			information = this.information.Select(e => e.Model).ToList(),
			onlineResource = this._onlineResource?.Model,
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
		};

		public override ComplexViewModel<textContent> Load(textContent instance) => this.LoadtextContent(instance);

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
	public partial class timeIntervalsByDayOfWeekViewModel : ComplexViewModel<timeIntervalsByDayOfWeek> {
		[Category("timeIntervalsByDayOfWeek")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(dayOfWeekList), typeof(dayOfWeek))]
		[Multiplicity(0, 7)]
		public ObservableCollection<dayOfWeek> dayOfWeek  { get; set; } = new ();

		[Browsable(false)]
		public dayOfWeek[] dayOfWeekList => [(dayOfWeek)1,(dayOfWeek)2,(dayOfWeek)3,(dayOfWeek)4,(dayOfWeek)5,(dayOfWeek)6,(dayOfWeek)7];
		private Boolean? _dayOfWeekIsRange  = default;

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
		[Optional]
		public ObservableCollection<S100Framework.DomainModel.S100.Time> timeOfDayStart  { get; set; } = new ();
		[Category("timeIntervalsByDayOfWeek")]
		[Optional]
		public ObservableCollection<S100Framework.DomainModel.S100.Time> timeOfDayEnd  { get; set; } = new ();


		public timeIntervalsByDayOfWeekViewModel LoadtimeIntervalsByDayOfWeek(timeIntervalsByDayOfWeek instance) {
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

		public override ComplexViewModel<timeIntervalsByDayOfWeek> Load(timeIntervalsByDayOfWeek instance) => this.LoadtimeIntervalsByDayOfWeek(instance);

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
		[Category("usefulMarkDescription")]
		[Multiplicity(1)]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public usefulMarkDescriptionViewModel LoadusefulMarkDescription(usefulMarkDescription instance) {
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
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

		public override ComplexViewModel<usefulMarkDescription> Load(usefulMarkDescription instance) => this.LoadusefulMarkDescription(instance);

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

		[Optional]
		public double? uncertaintyVariableFactor {
			get {
				return _uncertaintyVariableFactor;
			}
			set {
				SetValue(ref _uncertaintyVariableFactor, value);
			}
		}


		public verticalUncertaintyViewModel LoadverticalUncertainty(verticalUncertainty instance) {
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

		public override ComplexViewModel<verticalUncertainty> Load(verticalUncertainty instance) => this.LoadverticalUncertainty(instance);

		public override string? ToString() => $"Vertical Uncertainty";
	}


	/// <summary>
	/// Values, discovered by measuring, that correspond to vessels characteristics.
	/// </summary>
	[CategoryOrder("vesselsMeasurements",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class vesselsMeasurementsViewModel : ComplexViewModel<vesselsMeasurements> {
		private comparisonOperator _comparisonOperator  = default;

		[DomainModel.EnumerationAttribute(nameof(comparisonOperatorList), typeof(comparisonOperator))]
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

		[DomainModel.EnumerationAttribute(nameof(vesselsCharacteristicsList), typeof(vesselsCharacteristics))]
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

		[DomainModel.EnumerationAttribute(nameof(vesselsCharacteristicsUnitList), typeof(vesselsCharacteristicsUnit))]
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


		public vesselsMeasurementsViewModel LoadvesselsMeasurements(vesselsMeasurements instance) {
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

		public override ComplexViewModel<vesselsMeasurements> Load(vesselsMeasurements instance) => this.LoadvesselsMeasurements(instance);

		public override string? ToString() => $"Vessels Measurements";
	}


	/// <summary>
	/// Links for relevant weather related information.
	/// </summary>
	[CategoryOrder("weatherResource",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class weatherResourceViewModel : ComplexViewModel<weatherResource> {
		private onlineResourceViewModel? _onlineResource  = default;

		[Category("weatherResource")]
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

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(dynamicResourceList), typeof(dynamicResource))]
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

		[Category("weatherResource")]
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


		public weatherResourceViewModel LoadweatherResource(weatherResource instance) {
			onlineResource = new ();
			if (instance.onlineResource != default) {
				onlineResource.LoadonlineResource(instance.onlineResource);
			}
			dynamicResource = instance.dynamicResource;
			textContent = new ();
			if (instance.textContent != default) {
				textContent.LoadtextContent(instance.textContent);
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

		public override ComplexViewModel<weatherResource> Load(weatherResource instance) => this.LoadweatherResource(instance);

		public override string? ToString() => $"Weather Resource";
	}



	/// <summary>
	/// A feature association for the binding between at least one instance of a geo feature and an instance of an information type.
	/// </summary>
	[CategoryOrder("AdditionalInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AdditionalInformationViewModel : AssociationViewModel {


		public AdditionalInformationViewModel LoadAdditionalInformation(AdditionalInformation instance) {

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

		public override string? ToString() => $"Additional information";
	}



	/// <summary>
	/// Contact information for an authority
	/// </summary>
	[CategoryOrder("AuthorityContact",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AuthorityContactViewModel : AssociationViewModel {


		public AuthorityContactViewModel LoadAuthorityContact(AuthorityContact instance) {

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

		public override string? ToString() => $"Authority contact";
	}



	/// <summary>
	/// Service hours for an authority
	/// </summary>
	[CategoryOrder("AuthorityHours",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AuthorityHoursViewModel : AssociationViewModel {


		public AuthorityHoursViewModel LoadAuthorityHours(AuthorityHours instance) {

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

		public override string? ToString() => $"Authority hours";
	}



	/// <summary>
	/// Association between a geographic location and a regulation, restriction, recommendation, or nautical information
	/// </summary>
	[CategoryOrder("AssociatedRxN",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AssociatedRxNViewModel : AssociationViewModel {


		public AssociatedRxNViewModel LoadAssociatedRxN(AssociatedRxN instance) {

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


		public ExceptionalWorkdayViewModel LoadExceptionalWorkday(ExceptionalWorkday instance) {

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

		public override string? ToString() => $"Exceptional workday";
	}



	/// <summary>
	/// The controlling authority for a service area
	/// </summary>
	[CategoryOrder("ServiceControl",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceControlViewModel : AssociationViewModel {


		public ServiceControlViewModel LoadServiceControl(ServiceControl instance) {

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

		public override string? ToString() => $"Service control";
	}



	/// <summary>
	/// Contact details for a service or facility
	/// </summary>
	[CategoryOrder("ServiceContact",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceContactViewModel : AssociationViewModel {


		public ServiceContactViewModel LoadServiceContact(ServiceContact instance) {

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

		public override string? ToString() => $"Service contact";
	}



	/// <summary>
	/// Working hours for a service or facility described by a geographic location
	/// </summary>
	[CategoryOrder("LocationHours",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LocationHoursViewModel : AssociationViewModel {


		public LocationHoursViewModel LoadLocationHours(LocationHours instance) {

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

		public override string? ToString() => $"Location hours";
	}



	/// <summary>
	/// Related organisation
	/// </summary>
	[CategoryOrder("RelatedOrganisation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RelatedOrganisationViewModel : AssociationViewModel {


		public RelatedOrganisationViewModel LoadRelatedOrganisation(RelatedOrganisation instance) {

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

		public override string? ToString() => $"Related organisation";
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
		[DomainModel.EnumerationAttribute(nameof(membershipList), typeof(membership))]
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


		public InclusionTypeViewModel LoadInclusionType(InclusionType instance) {
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

		public override string? ToString() => $"InclusionType";
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
		[DomainModel.EnumerationAttribute(nameof(categoryOfRelationshipList), typeof(categoryOfRelationship))]
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
		public categoryOfRelationship[] categoryOfRelationshipList => [(categoryOfRelationship)1,(categoryOfRelationship)2,(categoryOfRelationship)3,(categoryOfRelationship)4,(categoryOfRelationship)5,(categoryOfRelationship)6];


		public PermissionTypeViewModel LoadPermissionType(PermissionType instance) {
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
	/// Association for linking spatial quality to spatial objects.
	/// </summary>
	[CategoryOrder("SpatialAssociation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SpatialAssociationViewModel : AssociationViewModel {


		public SpatialAssociationViewModel LoadSpatialAssociation(SpatialAssociation instance) {

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
	/// Association between a limit feature and the entrance for the limit.
	/// </summary>
	[CategoryOrder("LimitEntrance",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LimitEntranceViewModel : AssociationViewModel {


		public LimitEntranceViewModel LoadLimitEntrance(LimitEntrance instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new LimitEntrance {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LimitEntrance Model => new () {

		};

		public override string? ToString() => $"Limit Entrance";
	}



	/// <summary>
	/// The services available within a location.
	/// </summary>
	[CategoryOrder("ServiceAvailability",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ServiceAvailabilityViewModel : AssociationViewModel {


		public ServiceAvailabilityViewModel LoadServiceAvailability(ServiceAvailability instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new ServiceAvailability {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ServiceAvailability Model => new () {

		};

		public override string? ToString() => $"Service Availability";
	}



	/// <summary>
	/// A feature association for the binding between a geo feature and the cartographically positioned location for text.
	/// </summary>
	[CategoryOrder("TextAssociation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TextAssociationViewModel : AssociationViewModel {


		public TextAssociationViewModel LoadTextAssociation(TextAssociation instance) {

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

		public override string? ToString() => $"Text association";
	}



	/// <summary>
	/// A division of a feature into parts of the same type as the whole.
	/// </summary>
	[CategoryOrder("Subsection",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SubsectionViewModel : AssociationViewModel {


		public SubsectionViewModel LoadSubsection(Subsection instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new Subsection {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Subsection Model => new () {

		};

		public override string? ToString() => $"Subsection";
	}



	/// <summary>
	/// The infrastructure facilities in an area.
	/// </summary>
	[CategoryOrder("Infrastructure",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class InfrastructureViewModel : AssociationViewModel {


		public InfrastructureViewModel LoadInfrastructure(Infrastructure instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new Infrastructure {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Infrastructure Model => new () {

		};

		public override string? ToString() => $"Infrastructure";
	}



	/// <summary>
	/// Describes the relationship between a primary feature and a feature that plays a supporting role in the use of the primary facility by a vessel.
	/// </summary>
	[CategoryOrder("PrimaryAuxiliaryFacility",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PrimaryAuxiliaryFacilityViewModel : AssociationViewModel {


		public PrimaryAuxiliaryFacilityViewModel LoadPrimaryAuxiliaryFacility(PrimaryAuxiliaryFacility instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new PrimaryAuxiliaryFacility {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PrimaryAuxiliaryFacility Model => new () {

		};

		public override string? ToString() => $"Primary/Auxiliary Facility";
	}



	/// <summary>
	/// Demarcation of location(s) within a feature by relation to another feature or features
	/// </summary>
	[CategoryOrder("Demarcation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DemarcationViewModel : AssociationViewModel {


		public DemarcationViewModel LoadDemarcation(Demarcation instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new Demarcation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Demarcation Model => new () {

		};

		public override string? ToString() => $"Demarcation";
	}



	/// <summary>
	/// The limit(s) of a jurisdiction claimed by a coastal State.
	/// </summary>
	[CategoryOrder("JurisdictionalLimit",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class JurisdictionalLimitViewModel : AssociationViewModel {


		public JurisdictionalLimitViewModel LoadJurisdictionalLimit(JurisdictionalLimit instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new JurisdictionalLimit {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public JurisdictionalLimit Model => new () {

		};

		public override string? ToString() => $"Jurisdictional Limit";
	}



	/// <summary>
	/// A division of a feature into parts of type(s) different from the type of the whole.
	/// </summary>
	[CategoryOrder("LayoutDivision",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LayoutDivisionViewModel : AssociationViewModel {


		public LayoutDivisionViewModel LoadLayoutDivision(LayoutDivision instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new LayoutDivision {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LayoutDivision Model => new () {

		};

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
		private String? _source  = default;

		[Category("InformationType")]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[S100TruncatedDateAttribute]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfCargoList), typeof(categoryOfCargo))]
		[Optional]
		public ObservableCollection<categoryOfCargo> categoryOfCargo  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfCargo[] categoryOfCargoList => [(categoryOfCargo)2,(categoryOfCargo)5,(categoryOfCargo)6,(categoryOfCargo)7,(categoryOfCargo)8,(categoryOfCargo)10,(categoryOfCargo)11,(categoryOfCargo)12,(categoryOfCargo)13,(categoryOfCargo)14,(categoryOfCargo)15];
		[Category("Applicability")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfDangerousOrHazardousCargoList), typeof(categoryOfDangerousOrHazardousCargo))]
		[Optional]
		public ObservableCollection<categoryOfDangerousOrHazardousCargo> categoryOfDangerousOrHazardousCargo  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfDangerousOrHazardousCargo[] categoryOfDangerousOrHazardousCargoList => [(categoryOfDangerousOrHazardousCargo)1,(categoryOfDangerousOrHazardousCargo)2,(categoryOfDangerousOrHazardousCargo)3,(categoryOfDangerousOrHazardousCargo)4,(categoryOfDangerousOrHazardousCargo)5,(categoryOfDangerousOrHazardousCargo)6,(categoryOfDangerousOrHazardousCargo)7,(categoryOfDangerousOrHazardousCargo)8,(categoryOfDangerousOrHazardousCargo)9,(categoryOfDangerousOrHazardousCargo)10,(categoryOfDangerousOrHazardousCargo)11,(categoryOfDangerousOrHazardousCargo)12,(categoryOfDangerousOrHazardousCargo)13,(categoryOfDangerousOrHazardousCargo)14,(categoryOfDangerousOrHazardousCargo)15,(categoryOfDangerousOrHazardousCargo)16,(categoryOfDangerousOrHazardousCargo)17,(categoryOfDangerousOrHazardousCargo)18,(categoryOfDangerousOrHazardousCargo)19,(categoryOfDangerousOrHazardousCargo)20,(categoryOfDangerousOrHazardousCargo)21];
		private categoryOfVessel? _categoryOfVessel  = default;

		[Category("Applicability")]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfVesselRegistryList), typeof(categoryOfVesselRegistry))]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(logicalConnectivesList), typeof(logicalConnectives))]
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


		public ApplicabilityViewModel LoadApplicability(Applicability instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
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
					information.Add(new informationViewModel().Loadinformation(e));
			}
			vesselsMeasurements.Clear();
			if (instance.vesselsMeasurements is not null) {
				foreach(var e in instance.vesselsMeasurements)
					vesselsMeasurements.Add(new vesselsMeasurementsViewModel().LoadvesselsMeasurements(e));
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

		public override InformationViewModel<Applicability> Load(Applicability instance) => this.LoadApplicability(instance);

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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[S100TruncatedDateAttribute]
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
		[DomainModel.EnumerationAttribute(nameof(categoryOfAuthorityList), typeof(categoryOfAuthority))]
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


		public AuthorityViewModel LoadAuthority(Authority instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			categoryOfAuthority = instance.categoryOfAuthority;
			textContent = new ();
			if (instance.textContent != default) {
				textContent.LoadtextContent(instance.textContent);
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
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			categoryOfAuthority = this._categoryOfAuthority,
			textContent = this._textContent?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Authority._informationBindingDefinitions;

		public override InformationViewModel<Authority> Load(Authority instance) => this.LoadAuthority(instance);

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
		private String? _source  = default;

		[Category("InformationType")]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[S100TruncatedDateAttribute]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		[Category("AvailablePortServices")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(firefightingServiceList), typeof(firefightingService))]
		[Optional]
		public ObservableCollection<firefightingService> firefightingService  { get; set; } = new ();

		[Browsable(false)]
		public firefightingService[] firefightingServiceList => [(firefightingService)1,(firefightingService)2,(firefightingService)3];
		[Category("AvailablePortServices")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(medicalServiceList), typeof(medicalService))]
		[Optional]
		public ObservableCollection<medicalService> medicalService  { get; set; } = new ();

		[Browsable(false)]
		public medicalService[] medicalServiceList => [(medicalService)1,(medicalService)2,(medicalService)3,(medicalService)4,(medicalService)5];
		[Category("AvailablePortServices")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(repairServiceList), typeof(repairService))]
		[Optional]
		public ObservableCollection<repairService> repairService  { get; set; } = new ();

		[Browsable(false)]
		public repairService[] repairServiceList => [(repairService)1,(repairService)2,(repairService)3,(repairService)4,(repairService)5,(repairService)6,(repairService)7,(repairService)8,(repairService)9,(repairService)10];
		[Category("AvailablePortServices")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(technicalPortServiceList), typeof(technicalPortService))]
		[Optional]
		public ObservableCollection<technicalPortService> technicalPortService  { get; set; } = new ();

		[Browsable(false)]
		public technicalPortService[] technicalPortServiceList => [(technicalPortService)1,(technicalPortService)2,(technicalPortService)3,(technicalPortService)4];
		[Category("AvailablePortServices")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(shipSanitationControlList), typeof(shipSanitationControl))]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(berthingAssistanceList), typeof(berthingAssistance))]
		[Optional]
		public ObservableCollection<berthingAssistance> berthingAssistance  { get; set; } = new ();

		[Browsable(false)]
		public berthingAssistance[] berthingAssistanceList => [(berthingAssistance)1,(berthingAssistance)2,(berthingAssistance)3,(berthingAssistance)4,(berthingAssistance)5,(berthingAssistance)6];
		[Category("AvailablePortServices")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(cargoServiceList), typeof(cargoService))]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(wasteDisposalServiceList), typeof(wasteDisposalService))]
		[Optional]
		public ObservableCollection<wasteDisposalService> wasteDisposalService  { get; set; } = new ();

		[Browsable(false)]
		public wasteDisposalService[] wasteDisposalServiceList => [(wasteDisposalService)1,(wasteDisposalService)2,(wasteDisposalService)3,(wasteDisposalService)4,(wasteDisposalService)5,(wasteDisposalService)6,(wasteDisposalService)7,(wasteDisposalService)8,(wasteDisposalService)9,(wasteDisposalService)10,(wasteDisposalService)11,(wasteDisposalService)12,(wasteDisposalService)13,(wasteDisposalService)14,(wasteDisposalService)15,(wasteDisposalService)16,(wasteDisposalService)17,(wasteDisposalService)18,(wasteDisposalService)19,(wasteDisposalService)20,(wasteDisposalService)21,(wasteDisposalService)22,(wasteDisposalService)23,(wasteDisposalService)24];
		[Category("AvailablePortServices")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(supplyServiceList), typeof(supplyService))]
		[Optional]
		public ObservableCollection<supplyService> supplyService  { get; set; } = new ();

		[Browsable(false)]
		public supplyService[] supplyServiceList => [(supplyService)1,(supplyService)2,(supplyService)3,(supplyService)4,(supplyService)5,(supplyService)6,(supplyService)7,(supplyService)8,(supplyService)9,(supplyService)10];
		private String? _tugInformation  = default;

		[Category("AvailablePortServices")]
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


		public AvailablePortServicesViewModel LoadAvailablePortServices(AvailablePortServices instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
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
					textContent.Add(new textContentViewModel().LoadtextContent(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new AvailablePortServices {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
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
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
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

		public override InformationViewModel<AvailablePortServices> Load(AvailablePortServices instance) => this.LoadAvailablePortServices(instance);

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
		private String? _source  = default;

		[Category("InformationType")]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[S100TruncatedDateAttribute]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private String? _callName  = default;

		[Category("ContactDetails")]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfCommunicationPreferenceList), typeof(categoryOfCommunicationPreference))]
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
		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<contactAddressViewModel> contactAddress  { get; set; } = new ();
		private String? _contactInstructions  = default;

		[Category("ContactDetails")]
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
		public ObservableCollection<int> signalFrequency  { get; set; } = new ();
		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<frequencyPairViewModel> frequencyPair  { get; set; } = new ();
		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private String? _mMSICode  = default;

		[Category("ContactDetails")]
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
		public ObservableCollection<onlineResourceViewModel> onlineResource  { get; set; } = new ();
		[Category("ContactDetails")]
		[Optional]
		public ObservableCollection<telecommunicationsViewModel> telecommunications  { get; set; } = new ();


		public ContactDetailsViewModel LoadContactDetails(ContactDetails instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
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
					contactAddress.Add(new contactAddressViewModel().LoadcontactAddress(e));
			}
			contactInstructions = instance.contactInstructions;
			signalFrequency.Clear();
			if (instance.signalFrequency is not null) {
				foreach(var e in instance.signalFrequency)
					signalFrequency.Add(e);
			}
			frequencyPair.Clear();
			if (instance.frequencyPair is not null) {
				foreach(var e in instance.frequencyPair)
					frequencyPair.Add(new frequencyPairViewModel().LoadfrequencyPair(e));
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Loadinformation(e));
			}
			mMSICode = instance.mMSICode;
			onlineResource.Clear();
			if (instance.onlineResource is not null) {
				foreach(var e in instance.onlineResource)
					onlineResource.Add(new onlineResourceViewModel().LoadonlineResource(e));
			}
			telecommunications.Clear();
			if (instance.telecommunications is not null) {
				foreach(var e in instance.telecommunications)
					telecommunications.Add(new telecommunicationsViewModel().Loadtelecommunications(e));
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
				callName = this.callName,
				callSign = this.callSign,
				categoryOfCommunicationPreference = this.categoryOfCommunicationPreference,
				communicationChannel = this.communicationChannel.ToList(),
				contactAddress = this.contactAddress.Select(e => e.Model).ToList(),
				contactInstructions = this.contactInstructions,
				signalFrequency = this.signalFrequency.ToList(),
				frequencyPair = this.frequencyPair.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				mMSICode = this.mMSICode,
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
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			callName = this._callName,
			callSign = this._callSign,
			categoryOfCommunicationPreference = this._categoryOfCommunicationPreference,
			communicationChannel = this.communicationChannel.ToList(),
			contactAddress = this.contactAddress.Select(e => e.Model).ToList(),
			contactInstructions = this._contactInstructions,
			signalFrequency = this.signalFrequency.ToList(),
			frequencyPair = this.frequencyPair.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			mMSICode = this._mMSICode,
			onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
			telecommunications = this.telecommunications.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => ContactDetails._informationBindingDefinitions;

		public override InformationViewModel<ContactDetails> Load(ContactDetails instance) => this.LoadContactDetails(instance);

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
		private String? _source  = default;

		[Category("InformationType")]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[S100TruncatedDateAttribute]
		[Optional]
		public String? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}

		private String? _entranceDescription  = default;

		[Category("Entrance")]
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


		public EntranceViewModel LoadEntrance(Entrance instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
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
					markedBy.Add(new markedByViewModel().LoadmarkedBy(e));
			}
			landmarkDescription.Clear();
			if (instance.landmarkDescription is not null) {
				foreach(var e in instance.landmarkDescription)
					landmarkDescription.Add(new landmarkDescriptionViewModel().LoadlandmarkDescription(e));
			}
			offshoreMarkDescription.Clear();
			if (instance.offshoreMarkDescription is not null) {
				foreach(var e in instance.offshoreMarkDescription)
					offshoreMarkDescription.Add(new offshoreMarkDescriptionViewModel().LoadoffshoreMarkDescription(e));
			}
			majorLightDescription.Clear();
			if (instance.majorLightDescription is not null) {
				foreach(var e in instance.majorLightDescription)
					majorLightDescription.Add(new majorLightDescriptionViewModel().LoadmajorLightDescription(e));
			}
			usefulMarkDescription.Clear();
			if (instance.usefulMarkDescription is not null) {
				foreach(var e in instance.usefulMarkDescription)
					usefulMarkDescription.Add(new usefulMarkDescriptionViewModel().LoadusefulMarkDescription(e));
			}
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Entrance {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				source = this.source,
				sourceType = this.sourceType,
				reportedDate = this.reportedDate,
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
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
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

		public override InformationViewModel<Entrance> Load(Entrance instance) => this.LoadEntrance(instance);

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
		private String? _source  = default;

		[Category("InformationType")]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[S100TruncatedDateAttribute]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfAuthorityList), typeof(categoryOfAuthority))]
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



		public NauticalInformationViewModel LoadNauticalInformation(NauticalInformation instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			categoryOfAuthority = instance.categoryOfAuthority;
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
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
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			categoryOfAuthority = this._categoryOfAuthority,
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => NauticalInformation._informationBindingDefinitions;

		public override InformationViewModel<NauticalInformation> Load(NauticalInformation instance) => this.LoadNauticalInformation(instance);

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
		private String? _source  = default;

		[Category("InformationType")]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[S100TruncatedDateAttribute]
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
		[S100TruncatedDateAttribute]
		[Optional]
		public ObservableCollection<String> dateFixed  { get; set; } = new ();
		[Category("NonStandardWorkingDay")]
		[Optional]
		public ObservableCollection<String> dateVariable  { get; set; } = new ();
		[Category("NonStandardWorkingDay")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public NonStandardWorkingDayViewModel LoadNonStandardWorkingDay(NonStandardWorkingDay instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
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
					information.Add(new informationViewModel().Loadinformation(e));
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

		public override InformationViewModel<NonStandardWorkingDay> Load(NonStandardWorkingDay instance) => this.LoadNonStandardWorkingDay(instance);

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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[S100TruncatedDateAttribute]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfAuthorityList), typeof(categoryOfAuthority))]
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



		public RecommendationsViewModel LoadRecommendations(Recommendations instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			categoryOfAuthority = instance.categoryOfAuthority;
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
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
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			categoryOfAuthority = this._categoryOfAuthority,
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Recommendations._informationBindingDefinitions;

		public override InformationViewModel<Recommendations> Load(Recommendations instance) => this.LoadRecommendations(instance);

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
		private String? _source  = default;

		[Category("InformationType")]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[S100TruncatedDateAttribute]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfAuthorityList), typeof(categoryOfAuthority))]
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



		public RegulationsViewModel LoadRegulations(Regulations instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			categoryOfAuthority = instance.categoryOfAuthority;
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
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
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			categoryOfAuthority = this._categoryOfAuthority,
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Regulations._informationBindingDefinitions;

		public override InformationViewModel<Regulations> Load(Regulations instance) => this.LoadRegulations(instance);

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
		private String? _source  = default;

		[Category("InformationType")]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[S100TruncatedDateAttribute]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfAuthorityList), typeof(categoryOfAuthority))]
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



		public RestrictionsViewModel LoadRestrictions(Restrictions instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			categoryOfAuthority = instance.categoryOfAuthority;
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
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
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			categoryOfAuthority = this._categoryOfAuthority,
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Restrictions._informationBindingDefinitions;

		public override InformationViewModel<Restrictions> Load(Restrictions instance) => this.LoadRestrictions(instance);

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
		private String? _source  = default;

		[Category("InformationType")]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[S100TruncatedDateAttribute]
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
		[Category("ServiceHours")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public ServiceHoursViewModel LoadServiceHours(ServiceHours instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			scheduleByDayOfWeek.Clear();
			if (instance.scheduleByDayOfWeek is not null) {
				foreach(var e in instance.scheduleByDayOfWeek)
					scheduleByDayOfWeek.Add(new scheduleByDayOfWeekViewModel().LoadscheduleByDayOfWeek(e));
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Loadinformation(e));
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
			source = this._source,
			sourceType = this._sourceType,
			reportedDate = this._reportedDate,
			scheduleByDayOfWeek = this.scheduleByDayOfWeek.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => ServiceHours._informationBindingDefinitions;

		public override InformationViewModel<ServiceHours> Load(ServiceHours instance) => this.LoadServiceHours(instance);

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
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(qualityOfHorizontalMeasurementList), typeof(qualityOfHorizontalMeasurement))]
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


		public SpatialQualityViewModel LoadSpatialQuality(SpatialQuality instance) {
			qualityOfHorizontalMeasurement = instance.qualityOfHorizontalMeasurement;
			spatialAccuracy.Clear();
			if (instance.spatialAccuracy is not null) {
				foreach(var e in instance.spatialAccuracy)
					spatialAccuracy.Add(new spatialAccuracyViewModel().LoadspatialAccuracy(e));
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

		public override InformationViewModel<SpatialQuality> Load(SpatialQuality instance) => this.LoadSpatialQuality(instance);

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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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






		public AnchorBerthViewModel LoadAnchorBerth(AnchorBerth instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new AnchorBerth {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
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
		public AnchorBerth Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
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

		public override informationBindingDefinition[] informationBindingDefinitions => AnchorBerth._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. AnchorBerth._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => AnchorBerth._featureBindingDefinitions;

		public override FeatureViewModel<AnchorBerth> Load(AnchorBerth instance) => this.LoadAnchorBerth(instance);

		public override string? ToString() => $"Anchor Berth";

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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		private String? _locationByText  = default;

		[Category("AnchorageArea")]
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
		private iSPSLevel? _iSPSLevel  = default;

		[Category("AnchorageArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(iSPSLevelList), typeof(iSPSLevel))]
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


		public AnchorageAreaViewModel LoadAnchorageArea(AnchorageArea instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
			}
			depthsDescription = new ();
			if (instance.depthsDescription != default) {
				depthsDescription.LoaddepthsDescription(instance.depthsDescription);
			}
			locationByText = instance.locationByText;
			markedBy = new ();
			if (instance.markedBy != default) {
				markedBy.LoadmarkedBy(instance.markedBy);
			}
			iSPSLevel = instance.iSPSLevel;
			return this;
		}

		public override string Serialize() {
			var instance = new AnchorageArea {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
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
		public AnchorageArea Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
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

		public override informationBindingDefinition[] informationBindingDefinitions => AnchorageArea._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. AnchorageArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => AnchorageArea._featureBindingDefinitions;

		public override FeatureViewModel<AnchorageArea> Load(AnchorageArea instance) => this.LoadAnchorageArea(instance);

		public override string? ToString() => $"Anchorage Area";

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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[Optional]
		public String? bollardDescription {
			get {
				return _bollardDescription;
			}
			set {
				SetValue(ref _bollardDescription, value);
			}
		}
		private double? _bollardPull  = default;

		[Category("Berth")]
		[Optional]
		public double? bollardPull {
			get {
				return _bollardPull;
			}
			set {
				SetValue(ref _bollardPull, value);
			}
		}
		private double? _minimumBerthDepth  = default;

		[Category("Berth")]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfBerthLocationList), typeof(categoryOfBerthLocation))]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(methodOfSecuringList), typeof(methodOfSecuring))]
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
		[Optional]
		public String? terminalIdentifier {
			get {
				return _terminalIdentifier;
			}
			set {
				SetValue(ref _terminalIdentifier, value);
			}
		}


		public BerthViewModel LoadBerth(Berth instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
			}
			availableBerthingLength = instance.availableBerthingLength;
			bollardDescription = instance.bollardDescription;
			bollardPull = instance.bollardPull;
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
			return this;
		}

		public override string Serialize() {
			var instance = new Berth {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
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
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Berth Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
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
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Berth._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Berth._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Berth._featureBindingDefinitions;

		public override FeatureViewModel<Berth> Load(Berth instance) => this.LoadBerth(instance);

		public override string? ToString() => $"Berth";

		public BerthViewModel() : base() {
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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

		[Category("BerthPosition")]
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

		[Category("BerthPosition")]
		[Optional]
		public String? bollardDescription {
			get {
				return _bollardDescription;
			}
			set {
				SetValue(ref _bollardDescription, value);
			}
		}
		private double? _bollardPull  = default;

		[Category("BerthPosition")]
		[Optional]
		public double? bollardPull {
			get {
				return _bollardPull;
			}
			set {
				SetValue(ref _bollardPull, value);
			}
		}
		[Category("BerthPosition")]
		[Multiplicity(0, 2)]
		public ObservableCollection<String> bollardNumber  { get; set; } = new ();
		private String? _gLNExtension  = default;

		[Category("BerthPosition")]
		[Optional]
		public String? gLNExtension {
			get {
				return _gLNExtension;
			}
			set {
				SetValue(ref _gLNExtension, value);
			}
		}
		[Category("BerthPosition")]
		[Multiplicity(0, 2)]
		public ObservableCollection<String> metreMarkNumber  { get; set; } = new ();
		[Category("BerthPosition")]
		[Multiplicity(0, 2)]
		public ObservableCollection<String> manifoldNumber  { get; set; } = new ();
		private String? _rampNumber  = default;

		[Category("BerthPosition")]
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
		[Optional]
		public String? locationByText {
			get {
				return _locationByText;
			}
			set {
				SetValue(ref _locationByText, value);
			}
		}


		public BerthPositionViewModel LoadBerthPosition(BerthPosition instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
			}
			availableBerthingLength = instance.availableBerthingLength;
			bollardDescription = instance.bollardDescription;
			bollardPull = instance.bollardPull;
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
			return this;
		}

		public override string Serialize() {
			var instance = new BerthPosition {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
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
				bollardPull = this.bollardPull,
				bollardNumber = this.bollardNumber.ToList(),
				gLNExtension = this.gLNExtension,
				metreMarkNumber = this.metreMarkNumber.ToList(),
				manifoldNumber = this.manifoldNumber.ToList(),
				rampNumber = this.rampNumber,
				locationByText = this.locationByText,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public BerthPosition Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
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
			bollardPull = this._bollardPull,
			bollardNumber = this.bollardNumber.ToList(),
			gLNExtension = this._gLNExtension,
			metreMarkNumber = this.metreMarkNumber.ToList(),
			manifoldNumber = this.manifoldNumber.ToList(),
			rampNumber = this._rampNumber,
			locationByText = this._locationByText,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => BerthPosition._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. BerthPosition._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => BerthPosition._featureBindingDefinitions;

		public override FeatureViewModel<BerthPosition> Load(BerthPosition instance) => this.LoadBerthPosition(instance);

		public override string? ToString() => $"Berth Position";

		public BerthPositionViewModel() : base() {
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(iSPSLevelList), typeof(iSPSLevel))]
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


		public DockAreaViewModel LoadDockArea(DockArea instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
			}
			depthsDescription = new ();
			if (instance.depthsDescription != default) {
				depthsDescription.LoaddepthsDescription(instance.depthsDescription);
			}
			locationByText = instance.locationByText;
			markedBy = new ();
			if (instance.markedBy != default) {
				markedBy.LoadmarkedBy(instance.markedBy);
			}
			iSPSLevel = instance.iSPSLevel;
			return this;
		}

		public override string Serialize() {
			var instance = new DockArea {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
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

		public override FeatureViewModel<DockArea> Load(DockArea instance) => this.LoadDockArea(instance);

		public override string? ToString() => $"Dock Area";

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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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

		[Category("HarbourPhysicalInfrastructure")]
		[Optional]
		public double? verticalClearanceValue {
			get {
				return _verticalClearanceValue;
			}
			set {
				SetValue(ref _verticalClearanceValue, value);
			}
		}

		private double? _sillDepth  = default;

		[Category("DryDock")]
		[Optional]
		public double? sillDepth {
			get {
				return _sillDepth;
			}
			set {
				SetValue(ref _sillDepth, value);
			}
		}


		public DryDockViewModel LoadDryDock(DryDock instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
			}
			verticalClearanceValue = instance.verticalClearanceValue;
			sillDepth = instance.sillDepth;
			return this;
		}

		public override string Serialize() {
			var instance = new DryDock {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
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
				sillDepth = this.sillDepth,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DryDock Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
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
			sillDepth = this._sillDepth,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => DryDock._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. DryDock._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => DryDock._featureBindingDefinitions;

		public override FeatureViewModel<DryDock> Load(DryDock instance) => this.LoadDryDock(instance);

		public override string? ToString() => $"Dry Dock";

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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(iSPSLevelList), typeof(iSPSLevel))]
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


		public DumpingGroundViewModel LoadDumpingGround(DumpingGround instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
			}
			depthsDescription = new ();
			if (instance.depthsDescription != default) {
				depthsDescription.LoaddepthsDescription(instance.depthsDescription);
			}
			locationByText = instance.locationByText;
			markedBy = new ();
			if (instance.markedBy != default) {
				markedBy.LoadmarkedBy(instance.markedBy);
			}
			iSPSLevel = instance.iSPSLevel;
			return this;
		}

		public override string Serialize() {
			var instance = new DumpingGround {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
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

		public override FeatureViewModel<DumpingGround> Load(DumpingGround instance) => this.LoadDumpingGround(instance);

		public override string? ToString() => $"Dumping Ground";

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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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

		[Category("HarbourPhysicalInfrastructure")]
		[Optional]
		public double? verticalClearanceValue {
			get {
				return _verticalClearanceValue;
			}
			set {
				SetValue(ref _verticalClearanceValue, value);
			}
		}

		private double? _sillDepth  = default;

		[Category("FloatingDock")]
		[Optional]
		public double? sillDepth {
			get {
				return _sillDepth;
			}
			set {
				SetValue(ref _sillDepth, value);
			}
		}


		public FloatingDockViewModel LoadFloatingDock(FloatingDock instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
			}
			verticalClearanceValue = instance.verticalClearanceValue;
			sillDepth = instance.sillDepth;
			return this;
		}

		public override string Serialize() {
			var instance = new FloatingDock {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
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
				sillDepth = this.sillDepth,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public FloatingDock Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
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
			sillDepth = this._sillDepth,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => FloatingDock._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. FloatingDock._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FloatingDock._featureBindingDefinitions;

		public override FeatureViewModel<FloatingDock> Load(FloatingDock instance) => this.LoadFloatingDock(instance);

		public override string? ToString() => $"Floating Dock";

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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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

		[Category("HarbourPhysicalInfrastructure")]
		[Optional]
		public double? verticalClearanceValue {
			get {
				return _verticalClearanceValue;
			}
			set {
				SetValue(ref _verticalClearanceValue, value);
			}
		}

		private double? _sillDepth  = default;

		[Category("Gridiron")]
		[Optional]
		public double? sillDepth {
			get {
				return _sillDepth;
			}
			set {
				SetValue(ref _sillDepth, value);
			}
		}


		public GridironViewModel LoadGridiron(Gridiron instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
			}
			verticalClearanceValue = instance.verticalClearanceValue;
			sillDepth = instance.sillDepth;
			return this;
		}

		public override string Serialize() {
			var instance = new Gridiron {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
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
				sillDepth = this.sillDepth,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Gridiron Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
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
			sillDepth = this._sillDepth,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Gridiron._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Gridiron._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Gridiron._featureBindingDefinitions;

		public override FeatureViewModel<Gridiron> Load(Gridiron instance) => this.LoadGridiron(instance);

		public override string? ToString() => $"Gridiron";

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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(iSPSLevelList), typeof(iSPSLevel))]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfHarbourFacilityList), typeof(categoryOfHarbourFacility))]
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


		public HarbourAreaAdministrativeViewModel LoadHarbourAreaAdministrative(HarbourAreaAdministrative instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
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
				generalHarbourInformation.LoadgeneralHarbourInformation(instance.generalHarbourInformation);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new HarbourAreaAdministrative {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
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

		public override FeatureViewModel<HarbourAreaAdministrative> Load(HarbourAreaAdministrative instance) => this.LoadHarbourAreaAdministrative(instance);

		public override string? ToString() => $"Harbour Area (Administrative)";

		public HarbourAreaAdministrativeViewModel() : base() {
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfPortSectionList), typeof(categoryOfPortSection))]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfHarbourFacilityList), typeof(categoryOfHarbourFacility))]
		[Optional]
		public ObservableCollection<categoryOfHarbourFacility> categoryOfHarbourFacility  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfHarbourFacility[] categoryOfHarbourFacilityList => [(categoryOfHarbourFacility)4,(categoryOfHarbourFacility)5,(categoryOfHarbourFacility)6,(categoryOfHarbourFacility)9,(categoryOfHarbourFacility)14,(categoryOfHarbourFacility)15,(categoryOfHarbourFacility)16,(categoryOfHarbourFacility)17];
		private iSPSLevel? _iSPSLevel  = default;

		[Category("HarbourAreaSection")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(iSPSLevelList), typeof(iSPSLevel))]
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


		public HarbourAreaSectionViewModel LoadHarbourAreaSection(HarbourAreaSection instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
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
				facilitiesLayoutDescription.LoadfacilitiesLayoutDescription(instance.facilitiesLayoutDescription);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new HarbourAreaSection {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
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

		public override FeatureViewModel<HarbourAreaSection> Load(HarbourAreaSection instance) => this.LoadHarbourAreaSection(instance);

		public override string? ToString() => $"Harbour Area Section";

		public HarbourAreaSectionViewModel() : base() {
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(iSPSLevelList), typeof(iSPSLevel))]
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


		public HarbourBasinViewModel LoadHarbourBasin(HarbourBasin instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
			}
			depthsDescription = new ();
			if (instance.depthsDescription != default) {
				depthsDescription.LoaddepthsDescription(instance.depthsDescription);
			}
			locationByText = instance.locationByText;
			markedBy = new ();
			if (instance.markedBy != default) {
				markedBy.LoadmarkedBy(instance.markedBy);
			}
			iSPSLevel = instance.iSPSLevel;
			return this;
		}

		public override string Serialize() {
			var instance = new HarbourBasin {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
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

		public override FeatureViewModel<HarbourBasin> Load(HarbourBasin instance) => this.LoadHarbourBasin(instance);

		public override string? ToString() => $"Harbour Basin";

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
	}



	/// <summary>
	/// A harbour installation with a service or commercial operation of public interest.
	/// </summary>
	[CategoryOrder("HarbourFacility",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class HarbourFacilityViewModel : FeatureViewModel<HarbourFacility> {
		private String? _locationMRN  = default;

		[Category("FeatureType")]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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

		[Category("HarbourPhysicalInfrastructure")]
		[Optional]
		public double? verticalClearanceValue {
			get {
				return _verticalClearanceValue;
			}
			set {
				SetValue(ref _verticalClearanceValue, value);
			}
		}

		[Category("HarbourFacility")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfHarbourFacilityList), typeof(categoryOfHarbourFacility))]
		[Multiplicity(1)]
		public ObservableCollection<categoryOfHarbourFacility> categoryOfHarbourFacility  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfHarbourFacility[] categoryOfHarbourFacilityList => [(categoryOfHarbourFacility)12,(categoryOfHarbourFacility)13];


		public HarbourFacilityViewModel LoadHarbourFacility(HarbourFacility instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
			}
			verticalClearanceValue = instance.verticalClearanceValue;
			categoryOfHarbourFacility.Clear();
			if (instance.categoryOfHarbourFacility is not null) {
				foreach(var e in instance.categoryOfHarbourFacility)
					categoryOfHarbourFacility.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new HarbourFacility {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
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
				categoryOfHarbourFacility = this.categoryOfHarbourFacility.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public HarbourFacility Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
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
			categoryOfHarbourFacility = this.categoryOfHarbourFacility.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => HarbourFacility._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. HarbourFacility._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => HarbourFacility._featureBindingDefinitions;

		public override FeatureViewModel<HarbourFacility> Load(HarbourFacility instance) => this.LoadHarbourFacility(instance);

		public override string? ToString() => $"Harbour Facility";

		public HarbourFacilityViewModel() : base() {
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[DomainModel.EnumerationAttribute(nameof(categoryOfMooringWarpingFacilityList), typeof(categoryOfMooringWarpingFacility))]
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
		public categoryOfMooringWarpingFacility[] categoryOfMooringWarpingFacilityList => [(categoryOfMooringWarpingFacility)1,(categoryOfMooringWarpingFacility)2,(categoryOfMooringWarpingFacility)3,(categoryOfMooringWarpingFacility)4,(categoryOfMooringWarpingFacility)5,(categoryOfMooringWarpingFacility)6,(categoryOfMooringWarpingFacility)7];
		private String _iDCode  = string.Empty;

		[Category("MooringWarpingFacility")]
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
		[Optional]
		public String? bollardDescription {
			get {
				return _bollardDescription;
			}
			set {
				SetValue(ref _bollardDescription, value);
			}
		}
		private double? _bollardPull  = default;

		[Category("MooringWarpingFacility")]
		[Optional]
		public double? bollardPull {
			get {
				return _bollardPull;
			}
			set {
				SetValue(ref _bollardPull, value);
			}
		}
		private Boolean? _heavingLinesFromShore  = default;

		[Category("MooringWarpingFacility")]
		[Optional]
		public Boolean? heavingLinesFromShore {
			get {
				return _heavingLinesFromShore;
			}
			set {
				SetValue(ref _heavingLinesFromShore, value);
			}
		}


		public MooringWarpingFacilityViewModel LoadMooringWarpingFacility(MooringWarpingFacility instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
			}
			categoryOfMooringWarpingFacility = instance.categoryOfMooringWarpingFacility;
			iDCode = instance.iDCode;
			bollardDescription = instance.bollardDescription;
			bollardPull = instance.bollardPull;
			heavingLinesFromShore = instance.heavingLinesFromShore;
			return this;
		}

		public override string Serialize() {
			var instance = new MooringWarpingFacility {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
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
				bollardPull = this.bollardPull,
				heavingLinesFromShore = this.heavingLinesFromShore,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public MooringWarpingFacility Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
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
			bollardPull = this._bollardPull,
			heavingLinesFromShore = this._heavingLinesFromShore,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => MooringWarpingFacility._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. MooringWarpingFacility._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => MooringWarpingFacility._featureBindingDefinitions;

		public override FeatureViewModel<MooringWarpingFacility> Load(MooringWarpingFacility instance) => this.LoadMooringWarpingFacility(instance);

		public override string? ToString() => $"Mooring/Warping Facility";

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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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


		public OuterLimitViewModel LoadOuterLimit(OuterLimit instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
			}
			limitsDescription = new ();
			if (instance.limitsDescription != default) {
				limitsDescription.LoadlimitsDescription(instance.limitsDescription);
			}
			markedBy.Clear();
			if (instance.markedBy is not null) {
				foreach(var e in instance.markedBy)
					markedBy.Add(new markedByViewModel().LoadmarkedBy(e));
			}
			landmarkDescription.Clear();
			if (instance.landmarkDescription is not null) {
				foreach(var e in instance.landmarkDescription)
					landmarkDescription.Add(new landmarkDescriptionViewModel().LoadlandmarkDescription(e));
			}
			offshoreMarkDescription.Clear();
			if (instance.offshoreMarkDescription is not null) {
				foreach(var e in instance.offshoreMarkDescription)
					offshoreMarkDescription.Add(new offshoreMarkDescriptionViewModel().LoadoffshoreMarkDescription(e));
			}
			majorLightDescription.Clear();
			if (instance.majorLightDescription is not null) {
				foreach(var e in instance.majorLightDescription)
					majorLightDescription.Add(new majorLightDescriptionViewModel().LoadmajorLightDescription(e));
			}
			usefulMarkDescription.Clear();
			if (instance.usefulMarkDescription is not null) {
				foreach(var e in instance.usefulMarkDescription)
					usefulMarkDescription.Add(new usefulMarkDescriptionViewModel().LoadusefulMarkDescription(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new OuterLimit {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
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

		public override FeatureViewModel<OuterLimit> Load(OuterLimit instance) => this.LoadOuterLimit(instance);

		public override string? ToString() => $"Outer Limit";

		public OuterLimitViewModel() : base() {
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(iSPSLevelList), typeof(iSPSLevel))]
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


		public PilotBoardingPlaceViewModel LoadPilotBoardingPlace(PilotBoardingPlace instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
			}
			depthsDescription = new ();
			if (instance.depthsDescription != default) {
				depthsDescription.LoaddepthsDescription(instance.depthsDescription);
			}
			locationByText = instance.locationByText;
			markedBy = new ();
			if (instance.markedBy != default) {
				markedBy.LoadmarkedBy(instance.markedBy);
			}
			iSPSLevel = instance.iSPSLevel;
			return this;
		}

		public override string Serialize() {
			var instance = new PilotBoardingPlace {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
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
		public PilotBoardingPlace Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
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

		public override informationBindingDefinition[] informationBindingDefinitions => PilotBoardingPlace._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. PilotBoardingPlace._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => PilotBoardingPlace._featureBindingDefinitions;

		public override FeatureViewModel<PilotBoardingPlace> Load(PilotBoardingPlace instance) => this.LoadPilotBoardingPlace(instance);

		public override string? ToString() => $"Pilot Boarding Place";

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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(iSPSLevelList), typeof(iSPSLevel))]
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


		public SeaplaneLandingAreaViewModel LoadSeaplaneLandingArea(SeaplaneLandingArea instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
			}
			depthsDescription = new ();
			if (instance.depthsDescription != default) {
				depthsDescription.LoaddepthsDescription(instance.depthsDescription);
			}
			locationByText = instance.locationByText;
			markedBy = new ();
			if (instance.markedBy != default) {
				markedBy.LoadmarkedBy(instance.markedBy);
			}
			iSPSLevel = instance.iSPSLevel;
			return this;
		}

		public override string Serialize() {
			var instance = new SeaplaneLandingArea {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
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

		public override FeatureViewModel<SeaplaneLandingArea> Load(SeaplaneLandingArea instance) => this.LoadSeaplaneLandingArea(instance);

		public override string? ToString() => $"Seaplane Landing Area";

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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[Optional]
		public String? portFacilityNumber {
			get {
				return _portFacilityNumber;
			}
			set {
				SetValue(ref _portFacilityNumber, value);
			}
		}
		private categoryOfHarbourFacility? _categoryOfHarbourFacility  = default;

		[Category("Terminal")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfHarbourFacilityList), typeof(categoryOfHarbourFacility))]
		[Optional]
		public categoryOfHarbourFacility? categoryOfHarbourFacility {
			get {
				return _categoryOfHarbourFacility;
			}
			set {
				SetValue(ref _categoryOfHarbourFacility, value);
			}
		}

		[Browsable(false)]
		public categoryOfHarbourFacility[] categoryOfHarbourFacilityList => [(categoryOfHarbourFacility)1,(categoryOfHarbourFacility)3,(categoryOfHarbourFacility)5,(categoryOfHarbourFacility)7,(categoryOfHarbourFacility)8,(categoryOfHarbourFacility)10,(categoryOfHarbourFacility)11];
		[Category("Terminal")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfCargoList), typeof(categoryOfCargo))]
		[Optional]
		public ObservableCollection<categoryOfCargo> categoryOfCargo  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfCargo[] categoryOfCargoList => [(categoryOfCargo)2,(categoryOfCargo)5,(categoryOfCargo)6,(categoryOfCargo)7,(categoryOfCargo)8,(categoryOfCargo)10,(categoryOfCargo)11,(categoryOfCargo)12,(categoryOfCargo)13,(categoryOfCargo)14,(categoryOfCargo)15];
		[Category("Terminal")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(productList), typeof(product))]
		[Optional]
		public ObservableCollection<product> product  { get; set; } = new ();

		[Browsable(false)]
		public product[] productList => [(product)1,(product)2,(product)4,(product)5,(product)6,(product)7,(product)9,(product)10,(product)11,(product)12,(product)13,(product)14,(product)15,(product)16,(product)17,(product)18,(product)19,(product)20,(product)21,(product)22];
		private String? _terminalIdentifier  = default;

		[Category("Terminal")]
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
		[Optional]
		public String? uNLocationCode {
			get {
				return _uNLocationCode;
			}
			set {
				SetValue(ref _uNLocationCode, value);
			}
		}


		public TerminalViewModel LoadTerminal(Terminal instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
			}
			portFacilityNumber = instance.portFacilityNumber;
			categoryOfHarbourFacility = instance.categoryOfHarbourFacility;
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
				categoryOfHarbourFacility = this.categoryOfHarbourFacility,
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
			categoryOfHarbourFacility = this._categoryOfHarbourFacility,
			categoryOfCargo = this.categoryOfCargo.ToList(),
			product = this.product.ToList(),
			terminalIdentifier = this._terminalIdentifier,
			sMDGTerminalCode = this._sMDGTerminalCode,
			uNLocationCode = this._uNLocationCode,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Terminal._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Terminal._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Terminal._featureBindingDefinitions;

		public override FeatureViewModel<Terminal> Load(Terminal instance) => this.LoadTerminal(instance);

		public override string? ToString() => $"Terminal";

		public TerminalViewModel() : base() {
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(iSPSLevelList), typeof(iSPSLevel))]
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


		public TurningBasinViewModel LoadTurningBasin(TurningBasin instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
			}
			depthsDescription = new ();
			if (instance.depthsDescription != default) {
				depthsDescription.LoaddepthsDescription(instance.depthsDescription);
			}
			locationByText = instance.locationByText;
			markedBy = new ();
			if (instance.markedBy != default) {
				markedBy.LoadmarkedBy(instance.markedBy);
			}
			iSPSLevel = instance.iSPSLevel;
			return this;
		}

		public override string Serialize() {
			var instance = new TurningBasin {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
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

		public override FeatureViewModel<TurningBasin> Load(TurningBasin instance) => this.LoadTurningBasin(instance);

		public override string? ToString() => $"Turning Basin";

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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sourceTypeList), typeof(sourceType))]
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
		[DomainModel.EnumerationAttribute(nameof(categoryOfPortSectionList), typeof(categoryOfPortSection))]
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


		public WaterwayAreaViewModel LoadWaterwayArea(WaterwayArea instance) {
			locationMRN = instance.locationMRN;
			globalLocationNumber = instance.globalLocationNumber;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().LoadfeatureName(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.LoadfixedDateRange(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().LoadperiodicDateRange(e));
			}
			rxNCode.Clear();
			if (instance.rxNCode is not null) {
				foreach(var e in instance.rxNCode)
					rxNCode.Add(new rxNCodeViewModel().LoadrxNCode(e));
			}
			graphic.Clear();
			if (instance.graphic is not null) {
				foreach(var e in instance.graphic)
					graphic.Add(new graphicViewModel().Loadgraphic(e));
			}
			source = instance.source;
			sourceType = instance.sourceType;
			reportedDate = instance.reportedDate;
			textContent.Clear();
			if (instance.textContent is not null) {
				foreach(var e in instance.textContent)
					textContent.Add(new textContentViewModel().LoadtextContent(e));
			}
			categoryOfPortSection = instance.categoryOfPortSection;
			depthsDescription = new ();
			if (instance.depthsDescription != default) {
				depthsDescription.LoaddepthsDescription(instance.depthsDescription);
			}
			locationByText = instance.locationByText;
			markedBy = new ();
			if (instance.markedBy != default) {
				markedBy.LoadmarkedBy(instance.markedBy);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new WaterwayArea {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
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

		public override FeatureViewModel<WaterwayArea> Load(WaterwayArea instance) => this.LoadWaterwayArea(instance);

		public override string? ToString() => $"Waterway Area";

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
		[Mandatory]
		public int minimumDisplayScale {
			get {
				return _minimumDisplayScale;
			}
			set {
				SetValue(ref _minimumDisplayScale, value);
			}
		}


		public DataCoverageViewModel LoadDataCoverage(DataCoverage instance) {
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

		public override FeatureViewModel<DataCoverage> Load(DataCoverage instance) => this.LoadDataCoverage(instance);

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
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfTemporalVariationList), typeof(categoryOfTemporalVariation))]
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
		[Optional]
		public double? horizontalDistanceUncertainty {
			get {
				return _horizontalDistanceUncertainty;
			}
			set {
				SetValue(ref _horizontalDistanceUncertainty, value);
			}
		}
		private horizontalPositionUncertaintyViewModel _horizontalPositionUncertainty  = default;

		[Category("QualityOfNonBathymetricData")]
		[ExpandableObject]
		[Mandatory]
		public horizontalPositionUncertaintyViewModel horizontalPositionUncertainty {
			get {
				return _horizontalPositionUncertainty;
			}
			set {
				SetValue(ref _horizontalPositionUncertainty, value);
			}
		}
		private double? _orientationUncertainty  = default;

		[Category("QualityOfNonBathymetricData")]
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


		public QualityOfNonBathymetricDataViewModel LoadQualityOfNonBathymetricData(QualityOfNonBathymetricData instance) {
			categoryOfTemporalVariation = instance.categoryOfTemporalVariation;
			horizontalDistanceUncertainty = instance.horizontalDistanceUncertainty;
			horizontalPositionUncertainty = new ();
			if (instance.horizontalPositionUncertainty != default) {
				horizontalPositionUncertainty.LoadhorizontalPositionUncertainty(instance.horizontalPositionUncertainty);
			}
			orientationUncertainty = instance.orientationUncertainty;
			surveyDateRange = new ();
			if (instance.surveyDateRange != default) {
				surveyDateRange.LoadsurveyDateRange(instance.surveyDateRange);
			}
			verticalUncertainty = new ();
			if (instance.verticalUncertainty != default) {
				verticalUncertainty.LoadverticalUncertainty(instance.verticalUncertainty);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Loadinformation(e));
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

		public override FeatureViewModel<QualityOfNonBathymetricData> Load(QualityOfNonBathymetricData instance) => this.LoadQualityOfNonBathymetricData(instance);

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
		[DomainModel.EnumerationAttribute(nameof(verticalDatumList), typeof(verticalDatum))]
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


		public SoundingDatumViewModel LoadSoundingDatum(SoundingDatum instance) {
			verticalDatum = instance.verticalDatum;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Loadinformation(e));
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

		public override FeatureViewModel<SoundingDatum> Load(SoundingDatum instance) => this.LoadSoundingDatum(instance);

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
		[DomainModel.EnumerationAttribute(nameof(verticalDatumList), typeof(verticalDatum))]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)3,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)44];
		[Category("VerticalDatumOfData")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public VerticalDatumOfDataViewModel LoadVerticalDatumOfData(VerticalDatumOfData instance) {
			verticalDatum = instance.verticalDatum;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Loadinformation(e));
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

		public override FeatureViewModel<VerticalDatumOfData> Load(VerticalDatumOfData instance) => this.LoadVerticalDatumOfData(instance);

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
		private double _orientationValue  = default;

		[Category("TextPlacement")]
		[Mandatory]
		public double orientationValue {
			get {
				return _orientationValue;
			}
			set {
				SetValue(ref _orientationValue, value);
			}
		}
		private String? _text  = default;

		[Category("TextPlacement")]
		[Optional]
		public String? text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
			}
		}
		private int _textOffsetMm  = default;

		[Category("TextPlacement")]
		[Mandatory]
		public int textOffsetMm {
			get {
				return _textOffsetMm;
			}
			set {
				SetValue(ref _textOffsetMm, value);
			}
		}
		private textType? _textType  = default;

		[Category("TextPlacement")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(textTypeList), typeof(textType))]
		[Optional]
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
		private int? _scaleMinimum  = default;

		[Category("TextPlacement")]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}


		public TextPlacementViewModel LoadTextPlacement(TextPlacement instance) {
			orientationValue = instance.orientationValue;
			text = instance.text;
			textOffsetMm = instance.textOffsetMm;
			textType = instance.textType;
			scaleMinimum = instance.scaleMinimum;
			return this;
		}

		public override string Serialize() {
			var instance = new TextPlacement {
				orientationValue = this.orientationValue,
				text = this.text,
				textOffsetMm = this.textOffsetMm,
				textType = this.textType,
				scaleMinimum = this.scaleMinimum,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public TextPlacement Model => new () {
			orientationValue = this._orientationValue,
			text = this._text,
			textOffsetMm = this._textOffsetMm,
			textType = this._textType,
			scaleMinimum = this._scaleMinimum,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => TextPlacement._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. TextPlacement._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => TextPlacement._featureBindingDefinitions;

		public override FeatureViewModel<TextPlacement> Load(TextPlacement instance) => this.LoadTextPlacement(instance);

		public override string? ToString() => $"Text Placement";
	}



}
