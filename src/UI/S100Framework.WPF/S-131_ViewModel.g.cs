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
			"HarbourFacility" => new HarbourFacilityViewModel { Name = name },
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
	/// Description of services related to the goods or items carried by vessels.
	/// </summary>
	[Description("Description of services related to the goods or items carried by vessels.")]
	[CategoryOrder("cargoServicesDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class cargoServicesDescriptionViewModel : ComplexViewModel<cargoServicesDescription> {
		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
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
	[Description("A description of construction or other development in a location where the work will affect vessel operations such as navigation, maneuvering or docking/berthing.")]
	[CategoryOrder("constructionInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class constructionInformationViewModel : ComplexViewModel<constructionInformation> {
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

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		//[Editor(typeof(Editors.HorizonEditor<constructionInformation>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private String _development  = string.Empty;

		[Description("Describes a feature that is in development.")]
		//[Editor(typeof(Editors.HorizonEditor<constructionInformation>), typeof(Editors.HorizonEditor))]
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

		[Description("A textual rendering of a geographic location.")]
		//[Editor(typeof(Editors.HorizonEditor<constructionInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationByText {
			get {
				return _locationByText;
			}
			set {
				SetValue(ref _locationByText, value);
			}
		}

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
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
	[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
	[CategoryOrder("contactAddress",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class contactAddressViewModel : ComplexViewModel<contactAddress> {
		[Description("Details of where post can be delivered such as the apartment, name and/or number of a street, building or PO Box.")]
		[Optional]
		public ObservableCollection<String> deliveryPoint  { get; set; } = new ();

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
	[Description("Textual description of the characteristics and notable matters pertaining to depths in an area.")]
	[CategoryOrder("depthsDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class depthsDescriptionViewModel : ComplexViewModel<depthsDescription> {
		private categoryOfDepthsDescription _categoryOfDepthsDescription  = default;

		[Description("Classification of significant aspects of depths about which information is provided.")]
		//[Editor(typeof(Editors.HorizonEditor<depthsDescription>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Mandatory]
		public categoryOfDepthsDescription categoryOfDepthsDescription {
			get {
				return _categoryOfDepthsDescription;
			}
			set {
				SetValue(ref _categoryOfDepthsDescription, value);
			}
		}

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
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
	[Description("Textual description of the layout of port facilities.")]
	[CategoryOrder("facilitiesLayoutDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class facilitiesLayoutDescriptionViewModel : ComplexViewModel<facilitiesLayoutDescription> {
		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
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
	/// General information about the port or harbour area.
	/// </summary>
	[Description("General information about the port or harbour area.")]
	[CategoryOrder("generalHarbourInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class generalHarbourInformationViewModel : ComplexViewModel<generalHarbourInformation> {
		private generalPortDescriptionViewModel? _generalPortDescription  = default;

		[Description("General, introductory information about the port.")]
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

		[Description("Textual description of the layout of port facilities.")]
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

		[Description("Description of the area covered by the information specified.")]
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

		[Description("A description of construction or other development in a location where the work will affect vessel operations such as navigation, maneuvering or docking/berthing.")]
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

		[Description("Description of services related to the goods or items carried by vessels.")]
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

		[Description("Links for relevant weather related information.")]
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
	[Description("General, introductory information about the port.")]
	[CategoryOrder("generalPortDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class generalPortDescriptionViewModel : ComplexViewModel<generalPortDescription> {
		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
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
	/// Textual description of selected landmarks that have significance in an area.
	/// </summary>
	[Description("Textual description of selected landmarks that have significance in an area.")]
	[CategoryOrder("landmarkDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class landmarkDescriptionViewModel : ComplexViewModel<landmarkDescription> {
		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
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
	[Description("Description of the area covered by the information specified.")]
	[CategoryOrder("limitsDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class limitsDescriptionViewModel : ComplexViewModel<limitsDescription> {
		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
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
	[Description("A description of navigationally significant lights essential for marking landfalls, offshore dangers, shipping routes, port access channels or protection of the marine environment.")]
	[CategoryOrder("majorLightDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class majorLightDescriptionViewModel : ComplexViewModel<majorLightDescription> {
		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
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
	[Description("Description of the aids to navigation used to mark an area or object.")]
	[CategoryOrder("markedBy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class markedByViewModel : ComplexViewModel<markedBy> {
		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
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
	[Description("Description of aids to navigation or prominent marks located away from the shore.")]
	[CategoryOrder("offshoreMarkDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class offshoreMarkDescriptionViewModel : ComplexViewModel<offshoreMarkDescription> {
		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
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
	[Description("Information about online sources from which a resource or data can be obtained.")]
	[CategoryOrder("onlineResource",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class onlineResourceViewModel : ComplexViewModel<onlineResource> {
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
	/// Description of Aids to Navigation or prominent marks which are usually clearly visible and identifiable enough to be used in determining location or direction.
	/// </summary>
	[Description("Description of Aids to Navigation or prominent marks which are usually clearly visible and identifiable enough to be used in determining location or direction.")]
	[CategoryOrder("usefulMarkDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class usefulMarkDescriptionViewModel : ComplexViewModel<usefulMarkDescription> {
		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
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
	[Description("The best estimate of the vertical accuracy of depths, heights, vertical distances and vertical clearances.")]
	[CategoryOrder("verticalUncertainty",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class verticalUncertaintyViewModel : ComplexViewModel<verticalUncertainty> {
		private double _uncertaintyFixed  = default;

		[Description("The best estimate of the fixed horizontal or vertical accuracy component for positions, depths, heights, vertical distances and vertical clearances.")]
		//[Editor(typeof(Editors.HorizonEditor<verticalUncertainty>), typeof(Editors.HorizonEditor))]
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
		//[Editor(typeof(Editors.HorizonEditor<verticalUncertainty>), typeof(Editors.HorizonEditor))]
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
	/// Links for relevant weather related information.
	/// </summary>
	[Description("Links for relevant weather related information.")]
	[CategoryOrder("weatherResource",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class weatherResourceViewModel : ComplexViewModel<weatherResource> {
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

		private dynamicResource? _dynamicResource  = default;

		[Description("Whether a vessel must use a shore-based or other resource to obtain up-to-date information.")]
		//[Editor(typeof(Editors.HorizonEditor<weatherResource>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Optional]
		public dynamicResource? dynamicResource {
			get {
				return _dynamicResource;
			}
			set {
				SetValue(ref _dynamicResource, value);
			}
		}

		private textContentViewModel? _textContent  = default;

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
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

		public override string? ToString() => $"Service contact";
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

		public override string? ToString() => $"Location hours";
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
	/// Association between a limit feature and the entrance for the limit.
	/// </summary>
	[Description("Association between a limit feature and the entrance for the limit.")]
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
	[Description("The services available within a location.")]
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
	/// A division of a feature into parts of the same type as the whole.
	/// </summary>
	[Description("A division of a feature into parts of the same type as the whole.")]
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
	[Description("The infrastructure facilities in an area.")]
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
	[Description("Describes the relationship between a primary feature and a feature that plays a supporting role in the use of the primary facility by a vessel.")]
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
	[Description("Demarcation of location(s) within a feature by relation to another feature or features")]
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
	[Description("The limit(s) of a jurisdiction claimed by a coastal State.")]
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
	[Description("A division of a feature into parts of type(s) different from the type of the whole.")]
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
		[PermittedValues([2,5,6,7,8,10,11,12,13,14,15])]
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
			.. InclusionTypes.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.InclusionType> {
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
			.. AuthorityContacts.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.AuthorityContact> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. RelatedOrganisations.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.RelatedOrganisation> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. AuthorityHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.AuthorityHours> {
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
	/// Services that are available for a given port.
	/// </summary>
	[Description("Services that are available for a given port.")]
	[CategoryOrder("AvailablePortServices",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AvailablePortServicesViewModel : InformationViewModel<AvailablePortServices> {
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

		[Description("Services for combating fires, provided by different methods.")]
		[Category("AvailablePortServices")]
		[PermittedValues([1,2,3])]
		[Optional]
		public ObservableCollection<firefightingService> firefightingService  { get; set; } = new ();

		[Description("Services for the prevention or treatment of, or response to injury or illness.")]
		[Category("AvailablePortServices")]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public ObservableCollection<medicalService> medicalService  { get; set; } = new ();

		[Description("Work or maintenance activities whereby vessels or equipment are restored to working order, renovated, or improved in condition.")]
		[Category("AvailablePortServices")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10])]
		[Optional]
		public ObservableCollection<repairService> repairService  { get; set; } = new ();

		[Description("Services for the adjustment of vessel equipment or for assessments pertaining to cargo, compliance with regulations, safety, or security.")]
		[Category("AvailablePortServices")]
		[PermittedValues([1,2,3,4])]
		[Optional]
		public ObservableCollection<technicalPortService> technicalPortService  { get; set; } = new ();

		[Description("Application of measures to ensure that a vessel is free of disease and disease risks, or issue of completion or exemption certificates for such measures.")]
		[Category("AvailablePortServices")]
		[PermittedValues([1,2,3])]
		[Optional]
		public ObservableCollection<shipSanitationControl> shipSanitationControl  { get; set; } = new ();

		[Description("Classification of services for the conveyance of persons and/or goods, according to means of transport, nature of path, or representative installation.")]
		[Category("AvailablePortServices")]
		[PermittedValues([2,3,4,5,6,8,9,11,12,13])]
		[Optional]
		public ObservableCollection<transportConnection> transportConnection  { get; set; } = new ();

		[Description("Classification of assistance for mooring or anchoring operations.")]
		[Category("AvailablePortServices")]
		[PermittedValues([1,2,3,4,5,6])]
		[Optional]
		public ObservableCollection<berthingAssistance> berthingAssistance  { get; set; } = new ();

		[Description("Classification of services related to the goods or items carried by vessels.")]
		[Category("AvailablePortServices")]
		[PermittedValues([1,2,3,4])]
		[Optional]
		public ObservableCollection<cargoService> cargoService  { get; set; } = new ();

		[Description("Protective services, law enforcement, or services for responding to sudden danger.")]
		[Category("AvailablePortServices")]
		[PermittedValues([1,2,3,4,5,6,7,8])]
		[Optional]
		public ObservableCollection<securitySafetyEmergencyService> securitySafetyEmergencyService  { get; set; } = new ();

		[Description("Service for the reception of residues, polluting substances, refuse, oily wastes, and by-products from ships.")]
		[Category("AvailablePortServices")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24])]
		[Optional]
		public ObservableCollection<wasteDisposalService> wasteDisposalService  { get; set; } = new ();

		[Description("Classification of services for the provision of materials, goods, utilities, or personal services to vessels, passengers, or crew.")]
		[Category("AvailablePortServices")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10])]
		[Optional]
		public ObservableCollection<supplyService> supplyService  { get; set; } = new ();

		private String? _tugInformation  = default;

		[Description("Textual description of the types and capacities of available tugs.")]
		[Category("AvailablePortServices")]
		//[Editor(typeof(Editors.HorizonEditor<AvailablePortServices>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? tugInformation {
			get {
				return _tugInformation;
			}
			set {
				SetValue(ref _tugInformation, value);
			}
		}

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("AvailablePortServices")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];

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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.AvailablePortServices.informationBindingDefinitions;

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

		[Description("The Maritime Mobile Service Identity (MMSI) Code is formed of a series of nine digits which are transmitted over the radio path in order to uniquely identify ship stations, ship earth stations,coast stations, coast earth stations, and group calls. These identities are formed in such a way that the identity or part thereof can be used by telephone and telex subscribers connected to the general telecommunications network principally to call ships automatically.")]
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
			.. AuthorityContacts.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.AuthorityContact> {
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
	/// The seaward end of a channel, harbour, dock, etc.
	/// </summary>
	[Description("The seaward end of a channel, harbour, dock, etc.")]
	[CategoryOrder("Entrance",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class EntranceViewModel : InformationViewModel<Entrance> {
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

		private String? _entranceDescription  = default;

		[Description("Description of the seaward end of a channel, harbour, dock, etc.")]
		[Category("Entrance")]
		//[Editor(typeof(Editors.HorizonEditor<Entrance>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? entranceDescription {
			get {
				return _entranceDescription;
			}
			set {
				SetValue(ref _entranceDescription, value);
			}
		}

		[Description("The name of an associated feature.")]
		[Category("Entrance")]
		[Optional]
		public ObservableCollection<String> associatedFeatureName  { get; set; } = new ();

		private String? _localKnowledgeDescription  = default;

		[Description("Description of local knowledge that may be needed, for example to traverse a location.")]
		[Category("Entrance")]
		//[Editor(typeof(Editors.HorizonEditor<Entrance>), typeof(Editors.HorizonEditor))]
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

		[Description("Description of the approach to a location.")]
		[Category("Entrance")]
		//[Editor(typeof(Editors.HorizonEditor<Entrance>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? approachDescription {
			get {
				return _approachDescription;
			}
			set {
				SetValue(ref _approachDescription, value);
			}
		}

		[Description("Description of the aids to navigation used to mark an area or object.")]
		[Category("Entrance")]
		[Optional]
		public ObservableCollection<markedByViewModel> markedBy  { get; set; } = new ();

		[Description("Textual description of selected landmarks that have significance in an area.")]
		[Category("Entrance")]
		[Optional]
		public ObservableCollection<landmarkDescriptionViewModel> landmarkDescription  { get; set; } = new ();

		[Description("Description of aids to navigation or prominent marks located away from the shore.")]
		[Category("Entrance")]
		[Optional]
		public ObservableCollection<offshoreMarkDescriptionViewModel> offshoreMarkDescription  { get; set; } = new ();

		[Description("A description of navigationally significant lights essential for marking landfalls, offshore dangers, shipping routes, port access channels or protection of the marine environment.")]
		[Category("Entrance")]
		[Optional]
		public ObservableCollection<majorLightDescriptionViewModel> majorLightDescription  { get; set; } = new ();

		[Description("Description of Aids to Navigation or prominent marks which are usually clearly visible and identifiable enough to be used in determining location or direction.")]
		[Category("Entrance")]
		[Optional]
		public ObservableCollection<usefulMarkDescriptionViewModel> usefulMarkDescription  { get; set; } = new ();

		[Description("Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.")]
		[Category("Entrance")]
		[Optional]
		public ObservableCollection<textContentViewModel> textContent  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];

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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Entrance.informationBindingDefinitions;

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
			.. ExceptionalWorkdays.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.ExceptionalWorkday> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. AuthorityHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.AuthorityHours> {
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
	/// A designated area of water where a vessel, sea plane, etc., may anchor.
	/// </summary>
	[Description("A designated area of water where a vessel, sea plane, etc., may anchor.")]
	[CategoryOrder("AnchorBerth",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AnchorBerthViewModel : FeatureViewModel<AnchorBerth> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		[Description("Classification of an area where different use types of vessel can remain static.")]
		[Category("AnchorBerth")]
		[PermittedValues([1,2,3,5,6,7,9,10,14])]
		[Optional]
		public ObservableCollection<categoryOfAnchorage> categoryOfAnchorage  { get; set; } = new ();

		[Description("Classification of the different types of cargo that a ship may be carrying.")]
		[Category("AnchorBerth")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15])]
		[Optional]
		public ObservableCollection<categoryOfCargo> categoryOfCargo  { get; set; } = new ();

		private double? _radius  = default;

		[Description("The vector extending from the centre to the periphery of a circular or spherical feature.")]
		[Category("AnchorBerth")]
		//[Editor(typeof(Editors.HorizonEditor<AnchorBerth>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationBindings")]
		[InformationBinding("ServiceAvailability","serviceDescriptionReference",["AvailablePortServices"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> ServiceAvailabilities { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ServiceAvailabilities.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.ServiceAvailability> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("PrimaryAuxiliaryFacility","auxiliaryFacility",["MooringWarpingFacility"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> PrimaryAuxiliaryFacilities { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. PrimaryAuxiliaryFacilities.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.PrimaryAuxiliaryFacility> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfAnchorage = this.categoryOfAnchorage.ToList(),
			categoryOfCargo = this.categoryOfCargo.ToList(),
			radius = this._radius,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.AnchorBerth.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.AnchorBerth.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.AnchorBerth.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
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
			PrimaryAuxiliaryFacilities.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(PrimaryAuxiliaryFacilities));
			};
		}
	}



	/// <summary>
	/// An area in which vessels or seaplanes anchor or may anchor.
	/// </summary>
	[Description("An area in which vessels or seaplanes anchor or may anchor.")]
	[CategoryOrder("AnchorageArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AnchorageAreaViewModel : FeatureViewModel<AnchorageArea> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		[Description("Classification of an area where different use types of vessel can remain static.")]
		[Category("AnchorageArea")]
		[PermittedValues([1,2,3,5,6,7,9,10,14,15])]
		[Optional]
		public ObservableCollection<categoryOfAnchorage> categoryOfAnchorage  { get; set; } = new ();

		private iSPSLevel? _iSPSLevel  = default;

		[Description("Classification of ISPS security levels according to the ISPS Code.")]
		[Category("AnchorageArea")]
		//[Editor(typeof(Editors.HorizonEditor<AnchorageArea>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public iSPSLevel? iSPSLevel {
			get {
				return _iSPSLevel;
			}
			set {
				SetValue(ref _iSPSLevel, value);
			}
		}

		[Description("Classification of the different types of cargo that a ship may be carrying.")]
		[Category("AnchorageArea")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15])]
		[Optional]
		public ObservableCollection<categoryOfCargo> categoryOfCargo  { get; set; } = new ();

		private String? _locationByText  = default;

		[Description("A textual rendering of a geographic location.")]
		[Category("AnchorageArea")]
		//[Editor(typeof(Editors.HorizonEditor<AnchorageArea>), typeof(Editors.HorizonEditor))]
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

		[Description("Textual description of the characteristics and notable matters pertaining to depths in an area.")]
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

		[Description("Description of the aids to navigation used to mark an area or object.")]
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

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("LayoutDivision","componentOf",["HarbourAreaSection"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> LayoutDivisions { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. LayoutDivisions.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.LayoutDivision> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfAnchorage = this.categoryOfAnchorage.ToList(),
			iSPSLevel = this._iSPSLevel,
			categoryOfCargo = this.categoryOfCargo.ToList(),
			locationByText = this._locationByText,
			depthsDescription = this._depthsDescription?.Model,
			markedBy = this._markedBy?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.AnchorageArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.AnchorageArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.AnchorageArea.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
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
			LayoutDivisions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(LayoutDivisions));
			};
		}
	}



	/// <summary>
	/// Equipment with material handling or operational capabilities, characterised by wheeled (including tracked) mobility, and which autonomously moves along a preset route based on environmental markers or external guidance signals.
	/// </summary>
	[Description("Equipment with material handling or operational capabilities, characterised by wheeled (including tracked) mobility, and which autonomously moves along a preset route based on environmental markers or external guidance signals.")]
	[CategoryOrder("AutomatedGuidedVehicle",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AutomatedGuidedVehicleViewModel : FeatureViewModel<AutomatedGuidedVehicle> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		public override featureBinding[] GetFeatureBindings() => [];

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
			var instance = new AutomatedGuidedVehicle {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.AutomatedGuidedVehicle.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.AutomatedGuidedVehicle.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.AutomatedGuidedVehicle.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}



	/// <summary>
	/// A place, generally named or numbered, where a vessel may moor or anchor.
	/// </summary>
	[Description("A place, generally named or numbered, where a vessel may moor or anchor.")]
	[CategoryOrder("Berth",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BerthViewModel : FeatureViewModel<Berth> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private double? _availableBerthingLength  = default;

		[Description("The length of a berth or dock which is available for use.")]
		[Category("Berth")]
		//[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
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

		[Description("A textual description of the type of bollard at a berth or mooring facility.")]
		[Category("Berth")]
		//[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
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

		[Description("The maximum safe force or load that a piece of equipment, device, or accessory can handle without breaking or failing under normal conditions.")]
		[Category("Berth")]
		//[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
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

		[Description("The least depth of the body of water at the berth or in a berth pocket adjacent to the berth.")]
		[Category("Berth")]
		//[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
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

		[Description("The altitude of the ground level of an object, measured from a specified vertical datum.")]
		[Category("Berth")]
		//[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
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

		[Description("A system used to protect metal structures against corrosion by supplying direct current to the immersed external surface of the structure.")]
		[Category("Berth")]
		//[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
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

		[Description("Classification of a berth according to the method of describing its location or extent.")]
		[Category("Berth")]
		//[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Optional]
		public categoryOfBerthLocation? categoryOfBerthLocation {
			get {
				return _categoryOfBerthLocation;
			}
			set {
				SetValue(ref _categoryOfBerthLocation, value);
			}
		}

		private String? _portFacilityNumber  = default;

		[Description("Number assigned to the port facility in the IMO port facility database.")]
		[Category("Berth")]
		//[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? portFacilityNumber {
			get {
				return _portFacilityNumber;
			}
			set {
				SetValue(ref _portFacilityNumber, value);
			}
		}

		[Description("An identifier used to locate a specific bollard.")]
		[Category("Berth")]
		[Multiplicity(0, 2)]
		public ObservableCollection<String> bollardNumber  { get; set; } = new ();

		private String? _gLNExtension  = default;

		[Description("The GLN extension component is used to identify internal physical locations within a location which is identified with a GLN. Must conform to the rules for GLN extension. (GS1 specification).")]
		[Category("Berth")]
		//[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? gLNExtension {
			get {
				return _gLNExtension;
			}
			set {
				SetValue(ref _gLNExtension, value);
			}
		}

		[Description("An identifier for a specific position along a linear or curvilinear extent of a wharf, quay, or jetty. Numbering may be continued over multiple segments.")]
		[Category("Berth")]
		[Multiplicity(0, 2)]
		public ObservableCollection<String> metreMarkNumber  { get; set; } = new ();

		[Description("An identifier for a specific location on a manifold (a pipe or chamber with several openings).")]
		[Category("Berth")]
		[Multiplicity(0, 2)]
		public ObservableCollection<String> manifoldNumber  { get; set; } = new ();

		private String? _rampNumber  = default;

		[Description("An identifier for a specific ramp (a sloping structure that can be used as a landing place for small vessels, landing ships, or a ferry boat, or for hauling a cradle carrying a vessel, or for the transfer of rolling cargo).")]
		[Category("Berth")]
		//[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
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

		[Description("A textual rendering of a geographic location.")]
		[Category("Berth")]
		//[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
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

		[Description("The process, arrangement or scheme of attachment used to secure a vessel to a berth.")]
		[Category("Berth")]
		//[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10])]
		[Optional]
		public methodOfSecuring? methodOfSecuring {
			get {
				return _methodOfSecuring;
			}
			set {
				SetValue(ref _methodOfSecuring, value);
			}
		}

		private String _uNLocationCode  = string.Empty;

		[Description("Used to encode the UN Location Code (http://www.unece.org/cefact/locode/service/location.html) or - in Europe - the Inland Ship Reporting Standard (ISRS) Code.")]
		[Category("Berth")]
		//[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
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

		[Description("The unique identifier for a given terminal.")]
		[Category("Berth")]
		//[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
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

		[Description("A textual description of precautions for shore power usage.")]
		[Category("Berth")]
		//[Editor(typeof(Editors.HorizonEditor<Berth>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? shorePowerDescription {
			get {
				return _shorePowerDescription;
			}
			set {
				SetValue(ref _shorePowerDescription, value);
			}
		}

		[Description("The electrical frequency provided by the power supply station.")]
		[Category("Berth")]
		[PermittedValues([1,2])]
		[Optional]
		public ObservableCollection<categoryOfFrequency> categoryOfFrequency  { get; set; } = new ();

		[Description("The electrical voltage provided by the power supply station.")]
		[Category("Berth")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<categoryOfVoltage> categoryOfVoltage  { get; set; } = new ();

		[Description("The type of plug(s) available at the power supply station.")]
		[Category("Berth")]
		[Optional]
		public ObservableCollection<String> categoryOfPlug  { get; set; } = new ();

		[Description("Classification of the different types of cargo that a ship may be carrying.")]
		[Category("Berth")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15])]
		[Optional]
		public ObservableCollection<categoryOfCargo> categoryOfCargo  { get; set; } = new ();


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("ServiceAvailability","serviceDescriptionReference",["AvailablePortServices"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> ServiceAvailabilities { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ServiceAvailabilities.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.ServiceAvailability> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("Demarcation","demarcationIndicator",["BerthPosition"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> Demarcations { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("LayoutDivision","componentOf",["HarbourAreaSection","Terminal"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> LayoutDivisions { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. Demarcations.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.Demarcation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. LayoutDivisions.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.LayoutDivision> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Berth.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.Berth.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Berth.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
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
	[Description("A specific position within a berth where a vessel may be moored or anchored.")]
	[CategoryOrder("BerthPosition",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BerthPositionViewModel : FeatureViewModel<BerthPosition> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private String? _bollardNumber  = default;

		[Description("An identifier used to locate a specific bollard.")]
		[Category("BerthPosition")]
		//[Editor(typeof(Editors.HorizonEditor<BerthPosition>), typeof(Editors.HorizonEditor))]
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

		[Description("The GLN extension component is used to identify internal physical locations within a location which is identified with a GLN. Must conform to the rules for GLN extension. (GS1 specification).")]
		[Category("BerthPosition")]
		//[Editor(typeof(Editors.HorizonEditor<BerthPosition>), typeof(Editors.HorizonEditor))]
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

		[Description("An identifier for a specific position along a linear or curvilinear extent of a wharf, quay, or jetty. Numbering may be continued over multiple segments.")]
		[Category("BerthPosition")]
		//[Editor(typeof(Editors.HorizonEditor<BerthPosition>), typeof(Editors.HorizonEditor))]
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

		[Description("An identifier for a specific location on a manifold (a pipe or chamber with several openings).")]
		[Category("BerthPosition")]
		//[Editor(typeof(Editors.HorizonEditor<BerthPosition>), typeof(Editors.HorizonEditor))]
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

		[Description("An identifier for a specific ramp (a sloping structure that can be used as a landing place for small vessels, landing ships, or a ferry boat, or for hauling a cradle carrying a vessel, or for the transfer of rolling cargo).")]
		[Category("BerthPosition")]
		//[Editor(typeof(Editors.HorizonEditor<BerthPosition>), typeof(Editors.HorizonEditor))]
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

		[Description("A textual rendering of a geographic location.")]
		[Category("BerthPosition")]
		//[Editor(typeof(Editors.HorizonEditor<BerthPosition>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationByText {
			get {
				return _locationByText;
			}
			set {
				SetValue(ref _locationByText, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("Demarcation","demarcatedFeature",["Berth"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> Demarcations { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("PrimaryAuxiliaryFacility","auxiliaryFacility",["MooringWarpingFacility"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> PrimaryAuxiliaryFacilities { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. Demarcations.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.Demarcation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. PrimaryAuxiliaryFacilities.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.PrimaryAuxiliaryFacility> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			bollardNumber = this._bollardNumber,
			gLNExtension = this._gLNExtension,
			metreMarkNumber = this._metreMarkNumber,
			manifoldNumber = this._manifoldNumber,
			rampNumber = this._rampNumber,
			locationByText = this._locationByText,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.BerthPosition.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.BerthPosition.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.BerthPosition.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
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
	[Description("Small shaped post, mounted on a wharf or dolphin used to secure ship's lines.")]
	[CategoryOrder("Bollard",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BollardViewModel : FeatureViewModel<Bollard> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the feature, measured from a specified vertical datum.")]
		[Category("Bollard")]
		//[Editor(typeof(Editors.HorizonEditor<Bollard>), typeof(Editors.HorizonEditor))]
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

		[Description("The total vertical length of a feature.")]
		[Category("Bollard")]
		//[Editor(typeof(Editors.HorizonEditor<Bollard>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			height = this._height,
			verticalLength = this._verticalLength,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Bollard.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.Bollard.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Bollard.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}



	/// <summary>
	/// An artificially enclosed area within which ships may moor and which may have gates to regulate water level.
	/// </summary>
	[Description("An artificially enclosed area within which ships may moor and which may have gates to regulate water level.")]
	[CategoryOrder("DockArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DockAreaViewModel : FeatureViewModel<DockArea> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private depthsDescriptionViewModel? _depthsDescription  = default;

		[Description("Textual description of the characteristics and notable matters pertaining to depths in an area.")]
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

		[Description("A textual rendering of a geographic location.")]
		[Category("DockArea")]
		//[Editor(typeof(Editors.HorizonEditor<DockArea>), typeof(Editors.HorizonEditor))]
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

		[Description("Description of the aids to navigation used to mark an area or object.")]
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

		[Description("Classification of ISPS security levels according to the ISPS Code.")]
		[Category("DockArea")]
		//[Editor(typeof(Editors.HorizonEditor<DockArea>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public iSPSLevel? iSPSLevel {
			get {
				return _iSPSLevel;
			}
			set {
				SetValue(ref _iSPSLevel, value);
			}
		}


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("ServiceAvailability","serviceDescriptionReference",["AvailablePortServices"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> ServiceAvailabilities { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ServiceAvailabilities.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.ServiceAvailability> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("LayoutDivision","componentOf",["HarbourAreaSection"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> LayoutDivisions { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. LayoutDivisions.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.LayoutDivision> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			depthsDescription = this._depthsDescription?.Model,
			locationByText = this._locationByText,
			markedBy = this._markedBy?.Model,
			iSPSLevel = this._iSPSLevel,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.DockArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.DockArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.DockArea.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
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
	/// An artificial basin fitted with a gate or caisson, into which vessels can be floated and the water pumped out to expose the vessel's bottom. Also called graving dock.
	/// </summary>
	[Description("An artificial basin fitted with a gate or caisson, into which vessels can be floated and the water pumped out to expose the vessel's bottom. Also called graving dock.")]
	[CategoryOrder("DryDock",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DryDockViewModel : FeatureViewModel<DryDock> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private double? _sillDepth  = default;

		[Description("The greatest depth over a sill.")]
		[Category("DryDock")]
		//[Editor(typeof(Editors.HorizonEditor<DryDock>), typeof(Editors.HorizonEditor))]
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

		[Description("The vertical clearance measured from the horizontal plane towards the feature overhead.")]
		[Category("DryDock")]
		//[Editor(typeof(Editors.HorizonEditor<DryDock>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		public override featureBinding[] GetFeatureBindings() => [];

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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			sillDepth = this._sillDepth,
			verticalClearanceValue = this._verticalClearanceValue,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.DryDock.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.DryDock.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.DryDock.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}



	/// <summary>
	/// A post or group of posts, used for mooring or warping a vessel, or as an aid to navigation. The dolphin may be in the water, on a wharf or on the beach.
	/// </summary>
	[Description("A post or group of posts, used for mooring or warping a vessel, or as an aid to navigation. The dolphin may be in the water, on a wharf or on the beach.")]
	[CategoryOrder("Dolphin",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DolphinViewModel : FeatureViewModel<Dolphin> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		[Description("Classification of a post or group of posts, used for mooring or warping a vessel.")]
		[Category("Dolphin")]
		[PermittedValues([1,2,3,4])]
		[Multiplicity(1)]
		public ObservableCollection<categoryOfDolphin> categoryOfDolphin  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfDolphin = this.categoryOfDolphin.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Dolphin.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.Dolphin.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Dolphin.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
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
	[Description("A sea area where dredged material or other potentially more harmful material, for example explosives, chemical waste, is deliberately deposited.")]
	[CategoryOrder("DumpingGround",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DumpingGroundViewModel : FeatureViewModel<DumpingGround> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private depthsDescriptionViewModel? _depthsDescription  = default;

		[Description("Textual description of the characteristics and notable matters pertaining to depths in an area.")]
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

		[Description("A textual rendering of a geographic location.")]
		[Category("DumpingGround")]
		//[Editor(typeof(Editors.HorizonEditor<DumpingGround>), typeof(Editors.HorizonEditor))]
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

		[Description("Description of the aids to navigation used to mark an area or object.")]
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

		[Description("Classification of ISPS security levels according to the ISPS Code.")]
		[Category("DumpingGround")]
		//[Editor(typeof(Editors.HorizonEditor<DumpingGround>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public iSPSLevel? iSPSLevel {
			get {
				return _iSPSLevel;
			}
			set {
				SetValue(ref _iSPSLevel, value);
			}
		}


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("LayoutDivision","componentOf",["HarbourAreaSection"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> LayoutDivisions { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. LayoutDivisions.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.LayoutDivision> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			depthsDescription = this._depthsDescription?.Model,
			locationByText = this._locationByText,
			markedBy = this._markedBy?.Model,
			iSPSLevel = this._iSPSLevel,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.DumpingGround.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.DumpingGround.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.DumpingGround.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
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
	/// An imaginary line parallel to a face of a berth or quay which touches the seaward face of the fenders.
	/// </summary>
	[Description("An imaginary line parallel to a face of a berth or quay which touches the seaward face of the fenders.")]
	[CategoryOrder("FenderLine",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class FenderLineViewModel : FeatureViewModel<FenderLine> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private orientationViewModel? _orientation  = default;

		[Description("(1) The angular distance measured from true north to the major axis of the feature. (2) In ECDIS, the mode in which information on the ECDIS is being presented. Typical modes include: north-up - as shown on a nautical chart, north is at the top of the display; Ships head-up - based on the actual heading of the ship, (e.g. Ships gyrocompass); course-up display - based on the course or route being taken.")]
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


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("LayoutDivision","componentOf",["HarbourAreaSection"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> LayoutDivisions { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. LayoutDivisions.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.LayoutDivision> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			orientation = this._orientation?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.FenderLine.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.FenderLine.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.FenderLine.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
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
	[Description("A form of dry dock consisting of a floating structure of one or more sections which can be partly submerged by controlled flooding to receive a vessel, then raised by pumping out the water so that the vessel's bottom can be exposed.")]
	[CategoryOrder("FloatingDock",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class FloatingDockViewModel : FeatureViewModel<FloatingDock> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private double? _sillDepth  = default;

		[Description("The greatest depth over a sill.")]
		[Category("FloatingDock")]
		//[Editor(typeof(Editors.HorizonEditor<FloatingDock>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		public override featureBinding[] GetFeatureBindings() => [];

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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			sillDepth = this._sillDepth,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.FloatingDock.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.FloatingDock.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.FloatingDock.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}



	/// <summary>
	/// A structure in the intertidal zone serving as a support for vessels at low stages of the tide to permit work on the exposed portion of the vessel's hull.
	/// </summary>
	[Description("A structure in the intertidal zone serving as a support for vessels at low stages of the tide to permit work on the exposed portion of the vessel's hull.")]
	[CategoryOrder("Gridiron",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class GridironViewModel : FeatureViewModel<Gridiron> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private double? _sillDepth  = default;

		[Description("The greatest depth over a sill.")]
		[Category("Gridiron")]
		//[Editor(typeof(Editors.HorizonEditor<Gridiron>), typeof(Editors.HorizonEditor))]
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

		[Description("The vertical clearance measured from the horizontal plane towards the feature overhead.")]
		[Category("Gridiron")]
		//[Editor(typeof(Editors.HorizonEditor<Gridiron>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		public override featureBinding[] GetFeatureBindings() => [];

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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			sillDepth = this._sillDepth,
			verticalClearanceValue = this._verticalClearanceValue,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Gridiron.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.Gridiron.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Gridiron.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}



	/// <summary>
	/// The area over which a harbour authority has jurisdiction.
	/// </summary>
	[Description("The area over which a harbour authority has jurisdiction.")]
	[CategoryOrder("HarbourAreaAdministrative",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class HarbourAreaAdministrativeViewModel : FeatureViewModel<HarbourAreaAdministrative> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private String? _uNLocationCode  = default;

		[Description("Used to encode the UN Location Code (http://www.unece.org/cefact/locode/service/location.html) or - in Europe - the Inland Ship Reporting Standard (ISRS) Code.")]
		[Category("HarbourAreaAdministrative")]
		//[Editor(typeof(Editors.HorizonEditor<HarbourAreaAdministrative>), typeof(Editors.HorizonEditor))]
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

		[Description("Identifier of membership of a particular nation.")]
		[Category("HarbourAreaAdministrative")]
		//[Editor(typeof(Editors.HorizonEditor<HarbourAreaAdministrative>), typeof(Editors.HorizonEditor))]
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

		[Description("The load line zone in which the port is located. Defined by the International Convention on Load Lines.")]
		[Category("HarbourAreaAdministrative")]
		//[Editor(typeof(Editors.HorizonEditor<HarbourAreaAdministrative>), typeof(Editors.HorizonEditor))]
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

		[Description("Classification of ISPS security levels according to the ISPS Code.")]
		[Category("HarbourAreaAdministrative")]
		//[Editor(typeof(Editors.HorizonEditor<HarbourAreaAdministrative>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public iSPSLevel? iSPSLevel {
			get {
				return _iSPSLevel;
			}
			set {
				SetValue(ref _iSPSLevel, value);
			}
		}

		[Description("Classification of harbour use.")]
		[Category("HarbourAreaAdministrative")]
		[PermittedValues([1,3,4,5,6,7,8,9,10,11,12,13,14,15])]
		[Optional]
		public ObservableCollection<categoryOfHarbourFacility> categoryOfHarbourFacility  { get; set; } = new ();

		private generalHarbourInformationViewModel? _generalHarbourInformation  = default;

		[Description("General information about the port or harbour area.")]
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

		[Category("InformationBindings")]
		[InformationBinding("ServiceAvailability","serviceDescriptionReference",["AvailablePortServices"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> ServiceAvailabilities { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ServiceAvailabilities.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.ServiceAvailability> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("JurisdictionalLimit","limitExtent",["OuterLimit"], lower:0, upper:1)]
		public ObservableCollection<FeatureRefViewModel> JurisdictionalLimits { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("LayoutDivision","layoutUnit",["HarbourAreaSection"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> LayoutDivisions { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. JurisdictionalLimits.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.JurisdictionalLimit> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. LayoutDivisions.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.LayoutDivision> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			uNLocationCode = this._uNLocationCode,
			nationality = this._nationality,
			applicableLoadLineZone = this._applicableLoadLineZone,
			iSPSLevel = this._iSPSLevel,
			categoryOfHarbourFacility = this.categoryOfHarbourFacility.ToList(),
			generalHarbourInformation = this._generalHarbourInformation?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.HarbourAreaAdministrative.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.HarbourAreaAdministrative.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.HarbourAreaAdministrative.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			categoryOfHarbourFacility.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfHarbourFacility));
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
	[Description("A distinguishable portion of the area over which a harbour authority has jurisdiction.")]
	[CategoryOrder("HarbourAreaSection",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class HarbourAreaSectionViewModel : FeatureViewModel<HarbourAreaSection> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private categoryOfPortSection? _categoryOfPortSection  = default;

		[Description("Classification of subdivisions of a port or harbour area by usage.")]
		[Category("HarbourAreaSection")]
		//[Editor(typeof(Editors.HorizonEditor<HarbourAreaSection>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,3,8,9,11,12])]
		[Optional]
		public categoryOfPortSection? categoryOfPortSection {
			get {
				return _categoryOfPortSection;
			}
			set {
				SetValue(ref _categoryOfPortSection, value);
			}
		}

		[Description("Classification of harbour use.")]
		[Category("HarbourAreaSection")]
		[PermittedValues([4,5,6,9,14,15,16,17])]
		[Optional]
		public ObservableCollection<categoryOfHarbourFacility> categoryOfHarbourFacility  { get; set; } = new ();

		private iSPSLevel? _iSPSLevel  = default;

		[Description("Classification of ISPS security levels according to the ISPS Code.")]
		[Category("HarbourAreaSection")]
		//[Editor(typeof(Editors.HorizonEditor<HarbourAreaSection>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public iSPSLevel? iSPSLevel {
			get {
				return _iSPSLevel;
			}
			set {
				SetValue(ref _iSPSLevel, value);
			}
		}

		private facilitiesLayoutDescriptionViewModel? _facilitiesLayoutDescription  = default;

		[Description("Textual description of the layout of port facilities.")]
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

		[Category("InformationBindings")]
		[InformationBinding("ServiceAvailability","serviceDescriptionReference",["AvailablePortServices"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> ServiceAvailabilities { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ServiceAvailabilities.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.ServiceAvailability> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("LayoutDivision","componentOf",["HarbourAreaAdministrative"], lower:0, upper:1)]
		[FeatureBinding("LayoutDivision","layoutUnit",["AnchorageArea","Berth","DockArea","DumpingGround","FenderLine","HarbourBasin","PilotBoardingPlace","SeaplaneLandingArea","Terminal","TurningBasin","WaterwayArea"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> LayoutDivisions { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("Subsection","constitute",["HarbourAreaSection"], lower:0, upper:1)]
		[FeatureBinding("Subsection","subUnit",["HarbourAreaSection"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> Subsections { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("Infrastructure","hasInfrastructure",["HarbourPhysicalInfrastructure"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> Infrastructures { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. LayoutDivisions.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.LayoutDivision> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. Subsections.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.Subsection> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. Infrastructures.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.Infrastructure> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfPortSection = this._categoryOfPortSection,
			categoryOfHarbourFacility = this.categoryOfHarbourFacility.ToList(),
			iSPSLevel = this._iSPSLevel,
			facilitiesLayoutDescription = this._facilitiesLayoutDescription?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.HarbourAreaSection.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.HarbourAreaSection.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.HarbourAreaSection.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			categoryOfHarbourFacility.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfHarbourFacility));
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
	[Description("An enclosed area of water surrounded by quay walls constructed to provide means for the transfer of cargos from and to ships.")]
	[CategoryOrder("HarbourBasin",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class HarbourBasinViewModel : FeatureViewModel<HarbourBasin> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private depthsDescriptionViewModel? _depthsDescription  = default;

		[Description("Textual description of the characteristics and notable matters pertaining to depths in an area.")]
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

		[Description("A textual rendering of a geographic location.")]
		[Category("HarbourBasin")]
		//[Editor(typeof(Editors.HorizonEditor<HarbourBasin>), typeof(Editors.HorizonEditor))]
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

		[Description("Description of the aids to navigation used to mark an area or object.")]
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

		[Description("Classification of ISPS security levels according to the ISPS Code.")]
		[Category("HarbourBasin")]
		//[Editor(typeof(Editors.HorizonEditor<HarbourBasin>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public iSPSLevel? iSPSLevel {
			get {
				return _iSPSLevel;
			}
			set {
				SetValue(ref _iSPSLevel, value);
			}
		}


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("LayoutDivision","componentOf",["HarbourAreaSection"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> LayoutDivisions { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. LayoutDivisions.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.LayoutDivision> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			depthsDescription = this._depthsDescription?.Model,
			locationByText = this._locationByText,
			markedBy = this._markedBy?.Model,
			iSPSLevel = this._iSPSLevel,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.HarbourBasin.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.HarbourBasin.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.HarbourBasin.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
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
	/// A harbour installation with a service or commercial operation of public interest.
	/// </summary>
	[Description("A harbour installation with a service or commercial operation of public interest.")]
	[CategoryOrder("HarbourFacility",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class HarbourFacilityViewModel : FeatureViewModel<HarbourFacility> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		public override featureBinding[] GetFeatureBindings() => [];

		public HarbourFacilityViewModel Load(HarbourFacility instance) {
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
			var instance = new HarbourFacility {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
				textContent = this.textContent.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public HarbourFacility Model => new () {
			locationMRN = this._locationMRN,
			globalLocationNumber = this._globalLocationNumber,
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
			graphic = this.graphic.Select(e => e.Model).ToList(),
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.HarbourFacility.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.HarbourFacility.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.HarbourFacility.featureBindingDefinitions;

		public HarbourFacilityViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public HarbourFacilityViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Harbour Facility";

		public HarbourFacilityViewModel() : base() {
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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}



	/// <summary>
	/// A wet dock in a waterway, permitting a ship to pass from one level to another.
	/// </summary>
	[Description("A wet dock in a waterway, permitting a ship to pass from one level to another.")]
	[CategoryOrder("LockBasin",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LockBasinViewModel : FeatureViewModel<LockBasin> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private double? _sillDepth  = default;

		[Description("The greatest depth over a sill.")]
		[Category("LockBasin")]
		//[Editor(typeof(Editors.HorizonEditor<LockBasin>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		public override featureBinding[] GetFeatureBindings() => [];

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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			sillDepth = this._sillDepth,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LockBasin.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.LockBasin.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LockBasin.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}



	/// <summary>
	/// A lock basin is divided into several lock basin parts, if this lock basin has one ground level but several gates.
	/// </summary>
	[Description("A lock basin is divided into several lock basin parts, if this lock basin has one ground level but several gates.")]
	[CategoryOrder("LockBasinPart",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LockBasinPartViewModel : FeatureViewModel<LockBasinPart> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private double? _sillDepth  = default;

		[Description("The greatest depth over a sill.")]
		[Category("LockBasinPart")]
		//[Editor(typeof(Editors.HorizonEditor<LockBasinPart>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		public override featureBinding[] GetFeatureBindings() => [];

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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			sillDepth = this._sillDepth,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LockBasinPart.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.LockBasinPart.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LockBasinPart.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}



	/// <summary>
	/// A buoy secured to the bottom by permanent moorings with means for mooring a vessel by use of its anchor chain or mooring lines.
	/// </summary>
	[Description("A buoy secured to the bottom by permanent moorings with means for mooring a vessel by use of its anchor chain or mooring lines.")]
	[CategoryOrder("MooringBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class MooringBuoyViewModel : FeatureViewModel<MooringBuoy> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private double? _maximumPermittedDraught  = default;

		[Description("The maximum draught of a vessel permitted along a route, in a channel or dock, at a berth, or over a submerged feature.")]
		[Category("MooringBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<MooringBuoy>), typeof(Editors.HorizonEditor))]
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

		[Description("The maximum length of a vessel permitted in a channel or dock, at a berth, or at an anchorage or mooring.")]
		[Category("MooringBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<MooringBuoy>), typeof(Editors.HorizonEditor))]
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

		[Description("The total vertical length of a feature.")]
		[Category("MooringBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<MooringBuoy>), typeof(Editors.HorizonEditor))]
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

		[Description("A mooring set aside for the use of visiting vessels.")]
		[Category("MooringBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<MooringBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? visitorsMooring {
			get {
				return _visitorsMooring;
			}
			set {
				SetValue(ref _visitorsMooring, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			maximumPermittedDraught = this._maximumPermittedDraught,
			maximumPermittedVesselLength = this._maximumPermittedVesselLength,
			verticalLength = this._verticalLength,
			visitorsMooring = this._visitorsMooring,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.MooringBuoy.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.MooringBuoy.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.MooringBuoy.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}



	/// <summary>
	/// The equipment or structure used to secure a vessel.
	/// </summary>
	[Description("The equipment or structure used to secure a vessel.")]
	[CategoryOrder("MooringWarpingFacility",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class MooringWarpingFacilityViewModel : FeatureViewModel<MooringWarpingFacility> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private categoryOfMooringWarpingFacility _categoryOfMooringWarpingFacility  = default;

		[Description("A place or structure to which a vessel can be secured.")]
		[Category("MooringWarpingFacility")]
		//[Editor(typeof(Editors.HorizonEditor<MooringWarpingFacility>), typeof(Editors.HorizonEditor))]
		[PermittedValues([4,5,6])]
		[Mandatory]
		public categoryOfMooringWarpingFacility categoryOfMooringWarpingFacility {
			get {
				return _categoryOfMooringWarpingFacility;
			}
			set {
				SetValue(ref _categoryOfMooringWarpingFacility, value);
			}
		}

		private String _iDCode  = string.Empty;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("MooringWarpingFacility")]
		//[Editor(typeof(Editors.HorizonEditor<MooringWarpingFacility>), typeof(Editors.HorizonEditor))]
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

		[Description("A textual description of the type of bollard at a berth or mooring facility.")]
		[Category("MooringWarpingFacility")]
		//[Editor(typeof(Editors.HorizonEditor<MooringWarpingFacility>), typeof(Editors.HorizonEditor))]
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

		[Description("The maximum safe force or load that a piece of equipment, device, or accessory can handle without breaking or failing under normal conditions.")]
		[Category("MooringWarpingFacility")]
		//[Editor(typeof(Editors.HorizonEditor<MooringWarpingFacility>), typeof(Editors.HorizonEditor))]
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

		[Description("Ships must take heaving lines thrown from the shore.")]
		[Category("MooringWarpingFacility")]
		//[Editor(typeof(Editors.HorizonEditor<MooringWarpingFacility>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationBindings")]
		[InformationBinding("ServiceAvailability","serviceDescriptionReference",["AvailablePortServices"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> ServiceAvailabilities { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ServiceAvailabilities.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.ServiceAvailability> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("PrimaryAuxiliaryFacility","primaryFacility",["AnchorBerth","BerthPosition"], lower:0, upper:1)]
		public ObservableCollection<FeatureRefViewModel> PrimaryAuxiliaryFacilities { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. PrimaryAuxiliaryFacilities.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.PrimaryAuxiliaryFacility> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfMooringWarpingFacility = this._categoryOfMooringWarpingFacility,
			iDCode = this._iDCode,
			bollardDescription = this._bollardDescription,
			safeWorkingLoad = this._safeWorkingLoad,
			heavingLinesFromShore = this._heavingLinesFromShore,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.MooringWarpingFacility.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.MooringWarpingFacility.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.MooringWarpingFacility.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
			PrimaryAuxiliaryFacilities.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(PrimaryAuxiliaryFacilities));
			};
		}
	}



	/// <summary>
	/// Facilities or infrastructure providing shore power to berthed vessels.
	/// </summary>
	[Description("Facilities or infrastructure providing shore power to berthed vessels.")]
	[CategoryOrder("OnshorePowerFacility",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class OnshorePowerFacilityViewModel : FeatureViewModel<OnshorePowerFacility> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private categoryOfShorePowerFacility? _categoryOfShorePowerFacility  = default;

		[Description("Classification of equipment or installations that are used for providing shoreside electrical power to a vessel at berth.")]
		[Category("OnshorePowerFacility")]
		//[Editor(typeof(Editors.HorizonEditor<OnshorePowerFacility>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public categoryOfShorePowerFacility? categoryOfShorePowerFacility {
			get {
				return _categoryOfShorePowerFacility;
			}
			set {
				SetValue(ref _categoryOfShorePowerFacility, value);
			}
		}

		private String _iDCode  = string.Empty;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("OnshorePowerFacility")]
		//[Editor(typeof(Editors.HorizonEditor<OnshorePowerFacility>), typeof(Editors.HorizonEditor))]
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

		[Description("A textual description of precautions for shore power usage.")]
		[Category("OnshorePowerFacility")]
		//[Editor(typeof(Editors.HorizonEditor<OnshorePowerFacility>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? shorePowerDescription {
			get {
				return _shorePowerDescription;
			}
			set {
				SetValue(ref _shorePowerDescription, value);
			}
		}

		[Description("The electrical voltage provided by the power supply station.")]
		[Category("OnshorePowerFacility")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<categoryOfVoltage> categoryOfVoltage  { get; set; } = new ();

		[Description("The electrical frequency provided by the power supply station.")]
		[Category("OnshorePowerFacility")]
		[Optional]
		public ObservableCollection<categoryOfFrequency> categoryOfFrequency  { get; set; } = new ();

		[Description("The type of plug(s) available at the power supply station.")]
		[Category("OnshorePowerFacility")]
		[Optional]
		public ObservableCollection<String> categoryOfPlug  { get; set; } = new ();

		private String? _shorePowerServiceProvider  = default;

		[Description("An entity that generates, sells, or is responsible for supplying shore power to vessels.")]
		[Category("OnshorePowerFacility")]
		//[Editor(typeof(Editors.HorizonEditor<OnshorePowerFacility>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		public override featureBinding[] GetFeatureBindings() => [];

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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfShorePowerFacility = this._categoryOfShorePowerFacility,
			iDCode = this._iDCode,
			shorePowerDescription = this._shorePowerDescription,
			categoryOfVoltage = this.categoryOfVoltage.ToList(),
			categoryOfFrequency = this.categoryOfFrequency.ToList(),
			categoryOfPlug = this.categoryOfPlug.ToList(),
			shorePowerServiceProvider = this._shorePowerServiceProvider,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.OnshorePowerFacility.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.OnshorePowerFacility.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.OnshorePowerFacility.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
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
		}
	}



	/// <summary>
	/// The extent to which a coastal State claims or may claim a specific jurisdiction in accordance with the provisions of International Law.
	/// </summary>
	[Description("The extent to which a coastal State claims or may claim a specific jurisdiction in accordance with the provisions of International Law.")]
	[CategoryOrder("OuterLimit",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class OuterLimitViewModel : FeatureViewModel<OuterLimit> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private limitsDescriptionViewModel? _limitsDescription  = default;

		[Description("Description of the area covered by the information specified.")]
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

		[Description("Description of the aids to navigation used to mark an area or object.")]
		[Category("OuterLimit")]
		[Optional]
		public ObservableCollection<markedByViewModel> markedBy  { get; set; } = new ();

		[Description("Textual description of selected landmarks that have significance in an area.")]
		[Category("OuterLimit")]
		[Optional]
		public ObservableCollection<landmarkDescriptionViewModel> landmarkDescription  { get; set; } = new ();

		[Description("Description of aids to navigation or prominent marks located away from the shore.")]
		[Category("OuterLimit")]
		[Optional]
		public ObservableCollection<offshoreMarkDescriptionViewModel> offshoreMarkDescription  { get; set; } = new ();

		[Description("A description of navigationally significant lights essential for marking landfalls, offshore dangers, shipping routes, port access channels or protection of the marine environment.")]
		[Category("OuterLimit")]
		[Optional]
		public ObservableCollection<majorLightDescriptionViewModel> majorLightDescription  { get; set; } = new ();

		[Description("Description of Aids to Navigation or prominent marks which are usually clearly visible and identifiable enough to be used in determining location or direction.")]
		[Category("OuterLimit")]
		[Optional]
		public ObservableCollection<usefulMarkDescriptionViewModel> usefulMarkDescription  { get; set; } = new ();


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("LimitEntrance","entranceReference",["Entrance"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LimitEntrances { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. LimitEntrances.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LimitEntrance> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("JurisdictionalLimit","limitReference",["HarbourAreaAdministrative"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> JurisdictionalLimits { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. JurisdictionalLimits.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.JurisdictionalLimit> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			limitsDescription = this._limitsDescription?.Model,
			markedBy = this.markedBy.Select(e => e.Model).ToList(),
			landmarkDescription = this.landmarkDescription.Select(e => e.Model).ToList(),
			offshoreMarkDescription = this.offshoreMarkDescription.Select(e => e.Model).ToList(),
			majorLightDescription = this.majorLightDescription.Select(e => e.Model).ToList(),
			usefulMarkDescription = this.usefulMarkDescription.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.OuterLimit.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.OuterLimit.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.OuterLimit.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
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
			JurisdictionalLimits.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(JurisdictionalLimits));
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
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private depthsDescriptionViewModel? _depthsDescription  = default;

		[Description("Textual description of the characteristics and notable matters pertaining to depths in an area.")]
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

		[Description("A textual rendering of a geographic location.")]
		[Category("PilotBoardingPlace")]
		//[Editor(typeof(Editors.HorizonEditor<PilotBoardingPlace>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? locationByText {
			get {
				return _locationByText;
			}
			set {
				SetValue(ref _locationByText, value);
			}
		}

		[Description("Classification of pilot activity by arrival, departure, or change of pilot. It may also describe the place where the pilot's advice begins, ends, or is transferred to a different pilot.")]
		[Category("PilotBoardingPlace")]
		[PermittedValues([1,2,3])]
		[Multiplicity(0, 3)]
		public ObservableCollection<pilotMovement> pilotMovement  { get; set; } = new ();

		private markedByViewModel? _markedBy  = default;

		[Description("Description of the aids to navigation used to mark an area or object.")]
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

		[Description("Classification of ISPS security levels according to the ISPS Code.")]
		[Category("PilotBoardingPlace")]
		//[Editor(typeof(Editors.HorizonEditor<PilotBoardingPlace>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public iSPSLevel? iSPSLevel {
			get {
				return _iSPSLevel;
			}
			set {
				SetValue(ref _iSPSLevel, value);
			}
		}


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("LayoutDivision","componentOf",["HarbourAreaSection"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> LayoutDivisions { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. LayoutDivisions.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.LayoutDivision> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			depthsDescription = this._depthsDescription?.Model,
			locationByText = this._locationByText,
			pilotMovement = this.pilotMovement.ToList(),
			markedBy = this._markedBy?.Model,
			iSPSLevel = this._iSPSLevel,
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
			rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(rxNCode));
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
			pilotMovement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(pilotMovement));
			};
			LayoutDivisions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(LayoutDivisions));
			};
		}
	}



	/// <summary>
	/// A designated portion of water for the landing and take-off of seaplanes.
	/// </summary>
	[Description("A designated portion of water for the landing and take-off of seaplanes.")]
	[CategoryOrder("SeaplaneLandingArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SeaplaneLandingAreaViewModel : FeatureViewModel<SeaplaneLandingArea> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private depthsDescriptionViewModel? _depthsDescription  = default;

		[Description("Textual description of the characteristics and notable matters pertaining to depths in an area.")]
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

		[Description("A textual rendering of a geographic location.")]
		[Category("SeaplaneLandingArea")]
		//[Editor(typeof(Editors.HorizonEditor<SeaplaneLandingArea>), typeof(Editors.HorizonEditor))]
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

		[Description("Description of the aids to navigation used to mark an area or object.")]
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

		[Description("Classification of ISPS security levels according to the ISPS Code.")]
		[Category("SeaplaneLandingArea")]
		//[Editor(typeof(Editors.HorizonEditor<SeaplaneLandingArea>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public iSPSLevel? iSPSLevel {
			get {
				return _iSPSLevel;
			}
			set {
				SetValue(ref _iSPSLevel, value);
			}
		}


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("LayoutDivision","componentOf",["HarbourAreaSection"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> LayoutDivisions { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. LayoutDivisions.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.LayoutDivision> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			depthsDescription = this._depthsDescription?.Model,
			locationByText = this._locationByText,
			markedBy = this._markedBy?.Model,
			iSPSLevel = this._iSPSLevel,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SeaplaneLandingArea.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.SeaplaneLandingArea.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SeaplaneLandingArea.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
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
	/// A platform powered by synchronous electric motors (for example syncrolift) used to lift vessels (larger than boats) in and out of the water.
	/// </summary>
	[Description("A platform powered by synchronous electric motors (for example syncrolift) used to lift vessels (larger than boats) in and out of the water.")]
	[CategoryOrder("ShipLift",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ShipLiftViewModel : FeatureViewModel<ShipLift> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private double? _verticalClearanceValue  = default;

		[Description("The vertical clearance measured from the horizontal plane towards the feature overhead.")]
		[Category("ShipLift")]
		//[Editor(typeof(Editors.HorizonEditor<ShipLift>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		public override featureBinding[] GetFeatureBindings() => [];

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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			verticalClearanceValue = this._verticalClearanceValue,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.ShipLift.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.ShipLift.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.ShipLift.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}



	/// <summary>
	/// A wheeled vehicle designed to lift and carry containers or vessels within its own framework. It is used for moving, and sometimes stacking, shipping containers and vessels.
	/// </summary>
	[Description("A wheeled vehicle designed to lift and carry containers or vessels within its own framework. It is used for moving, and sometimes stacking, shipping containers and vessels.")]
	[CategoryOrder("StraddleCarrier",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class StraddleCarrierViewModel : FeatureViewModel<StraddleCarrier> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		public override featureBinding[] GetFeatureBindings() => [];

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
			var instance = new StraddleCarrier {
				locationMRN = this.locationMRN,
				globalLocationNumber = this.globalLocationNumber,
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rxNCode = this.rxNCode.Select(e => e.Model).ToList(),
				graphic = this.graphic.Select(e => e.Model).ToList(),
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.StraddleCarrier.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.StraddleCarrier.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.StraddleCarrier.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
			};
			textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(textContent));
			};
		}
	}



	/// <summary>
	/// A terminal covers that area on shore which provides buildings and constructions for the transfer of cargo or passengers from and to ships.
	/// </summary>
	[Description("A terminal covers that area on shore which provides buildings and constructions for the transfer of cargo or passengers from and to ships.")]
	[CategoryOrder("Terminal",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TerminalViewModel : FeatureViewModel<Terminal> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private String? _portFacilityNumber  = default;

		[Description("Number assigned to the port facility in the IMO port facility database.")]
		[Category("Terminal")]
		//[Editor(typeof(Editors.HorizonEditor<Terminal>), typeof(Editors.HorizonEditor))]
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

		[Description("Classification of terminals according to type of use, purpose, or type of cargo loaded or unloaded.")]
		[Category("Terminal")]
		//[Editor(typeof(Editors.HorizonEditor<Terminal>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,3,7,8,10,11])]
		[Optional]
		public categoryOfTerminal? categoryOfTerminal {
			get {
				return _categoryOfTerminal;
			}
			set {
				SetValue(ref _categoryOfTerminal, value);
			}
		}

		[Description("Classification of the different types of cargo that a ship may be carrying.")]
		[Category("Terminal")]
		[PermittedValues([2,5,6,7,8,10,11,12,13,14,15])]
		[Optional]
		public ObservableCollection<categoryOfCargo> categoryOfCargo  { get; set; } = new ();

		[Description("The various substances which are transported, stored or exploited.")]
		[Category("Terminal")]
		[PermittedValues([1,2,4,5,6,7,9,10,11,12,13,14,15,16,17,18,19,20,21,22])]
		[Optional]
		public ObservableCollection<product> product  { get; set; } = new ();

		private String? _terminalIdentifier  = default;

		[Description("The unique identifier for a given terminal.")]
		[Category("Terminal")]
		//[Editor(typeof(Editors.HorizonEditor<Terminal>), typeof(Editors.HorizonEditor))]
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

		[Description("A code from the SMDG (Ship Message Design Group) Terminal Code List.")]
		[Category("Terminal")]
		//[Editor(typeof(Editors.HorizonEditor<Terminal>), typeof(Editors.HorizonEditor))]
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

		[Description("Used to encode the UN Location Code (http://www.unece.org/cefact/locode/service/location.html) or - in Europe - the Inland Ship Reporting Standard (ISRS) Code.")]
		[Category("Terminal")]
		//[Editor(typeof(Editors.HorizonEditor<Terminal>), typeof(Editors.HorizonEditor))]
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

		[Category("InformationBindings")]
		[InformationBinding("ServiceAvailability","serviceDescriptionReference",["AvailablePortServices"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> ServiceAvailabilities { get; set; } = new();

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. ServiceAvailabilities.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.ServiceAvailability> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("LayoutDivision","componentOf",["HarbourAreaSection"], lower:1, upper:1)]
		[FeatureBinding("LayoutDivision","layoutUnit",["Berth"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> LayoutDivisions { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("Infrastructure","hasInfrastructure",["HarbourPhysicalInfrastructure"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> Infrastructures { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. LayoutDivisions.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.LayoutDivision> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. Infrastructures.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.Infrastructure> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			portFacilityNumber = this._portFacilityNumber,
			categoryOfTerminal = this._categoryOfTerminal,
			categoryOfCargo = this.categoryOfCargo.ToList(),
			product = this.product.ToList(),
			terminalIdentifier = this._terminalIdentifier,
			sMDGTerminalCode = this._sMDGTerminalCode,
			uNLocationCode = this._uNLocationCode,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Terminal.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.Terminal.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Terminal.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
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
	[Description("An area of water or enlargement of a channel used for turning vessels.")]
	[CategoryOrder("TurningBasin",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TurningBasinViewModel : FeatureViewModel<TurningBasin> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private depthsDescriptionViewModel? _depthsDescription  = default;

		[Description("Textual description of the characteristics and notable matters pertaining to depths in an area.")]
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

		[Description("A textual rendering of a geographic location.")]
		[Category("TurningBasin")]
		//[Editor(typeof(Editors.HorizonEditor<TurningBasin>), typeof(Editors.HorizonEditor))]
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

		[Description("Description of the aids to navigation used to mark an area or object.")]
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

		[Description("Classification of ISPS security levels according to the ISPS Code.")]
		[Category("TurningBasin")]
		//[Editor(typeof(Editors.HorizonEditor<TurningBasin>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public iSPSLevel? iSPSLevel {
			get {
				return _iSPSLevel;
			}
			set {
				SetValue(ref _iSPSLevel, value);
			}
		}


		#region InformationBindings

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("LayoutDivision","componentOf",["HarbourAreaSection"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> LayoutDivisions { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. LayoutDivisions.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.LayoutDivision> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			depthsDescription = this._depthsDescription?.Model,
			locationByText = this._locationByText,
			markedBy = this._markedBy?.Model,
			iSPSLevel = this._iSPSLevel,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.TurningBasin.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.TurningBasin.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.TurningBasin.featureBindingDefinitions;

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
			sourceIndication.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sourceIndication));
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
	/// An area in which uniform general information of the waterway exists.
	/// </summary>
	[Description("An area in which uniform general information of the waterway exists.")]
	[CategoryOrder("WaterwayArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class WaterwayAreaViewModel : FeatureViewModel<WaterwayArea> {
		private String? _locationMRN  = default;

		[Description("Location identifier, based on MRN. This can be either a specific identifier for an identified physical location or a type-only identifier for a logical location, such as BERTH.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
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

		[Description("A globally unique, standardised identifier for parties and locations in business processes or supply chains.")]
		[Category("FeatureType")]
		//[Editor(typeof(Editors.HorizonEditor<FeatureType>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? globalLocationNumber {
			get {
				return _globalLocationNumber;
			}
			set {
				SetValue(ref _globalLocationNumber, value);
			}
		}

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

		[Description("A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.")]
		[Category("FeatureType")]
		[Optional]
		public ObservableCollection<rxNCodeViewModel> rxNCode  { get; set; } = new ();

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




		private categoryOfPortSection _categoryOfPortSection  = default;

		[Description("Classification of subdivisions of a port or harbour area by usage.")]
		[Category("WaterwayArea")]
		//[Editor(typeof(Editors.HorizonEditor<WaterwayArea>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,3,8,9,11,12])]
		[Mandatory]
		public categoryOfPortSection categoryOfPortSection {
			get {
				return _categoryOfPortSection;
			}
			set {
				SetValue(ref _categoryOfPortSection, value);
			}
		}

		private depthsDescriptionViewModel? _depthsDescription  = default;

		[Description("Textual description of the characteristics and notable matters pertaining to depths in an area.")]
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

		[Description("A textual rendering of a geographic location.")]
		[Category("WaterwayArea")]
		//[Editor(typeof(Editors.HorizonEditor<WaterwayArea>), typeof(Editors.HorizonEditor))]
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

		[Description("Description of the aids to navigation used to mark an area or object.")]
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

		[Category("InformationBindings")]
		[InformationBinding("LocationHours","facilityOperatingHours",["ServiceHours"], lower:0, upper:1)]
		public ObservableCollection<InformationRefViewModel> LocationHours { get; set; } = new();

		public override informationBinding[] GetInformationBindings() => [
			.. LocationHours.Select(e => new informationBinding<DomainModel.S131.InformationAssociations.LocationHours> {
				informationType = e.informationType, referenceId = e.informationId, role = e.role,}),
		];
		#endregion


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("LayoutDivision","componentOf",["HarbourAreaSection"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> LayoutDivisions { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. LayoutDivisions.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.LayoutDivision> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
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
				sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
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
			sourceIndication = this.sourceIndication.Select(e => e.Model).ToList(),
			textContent = this.textContent.Select(e => e.Model).ToList(),
			categoryOfPortSection = this._categoryOfPortSection,
			depthsDescription = this._depthsDescription?.Model,
			locationByText = this._locationByText,
			markedBy = this._markedBy?.Model,
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
			rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(rxNCode));
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
			LayoutDivisions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(LayoutDivisions));
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

		[Description("A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.")]
		[Category("DataCoverage")]
		[Optional]
		public ObservableCollection<String> interoperabilityIdentifier  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

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
		//[Editor(typeof(Editors.HorizonEditor<QualityOfNonBathymetricData>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6])]
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

		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Description("The best estimate of the vertical accuracy of depths, heights, vertical distances and vertical clearances.")]
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

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("QualityOfNonBathymetricData")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

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
				interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
				sourceIndication = this.sourceIndication?.Model,
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
			interoperabilityIdentifier = this.interoperabilityIdentifier.ToList(),
			sourceIndication = this._sourceIndication?.Model,
			surveyDateRange = this._surveyDateRange?.Model,
			verticalUncertainty = this._verticalUncertainty?.Model,
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
	/// The horizontal plane or tidal datum to which soundings have been reduced. Also called datum for sounding reduction.
	/// </summary>
	[Description("The horizontal plane or tidal datum to which soundings have been reduced. Also called datum for sounding reduction.")]
	[CategoryOrder("SoundingDatum",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SoundingDatumViewModel : FeatureViewModel<SoundingDatum> {
		private verticalDatum _verticalDatum  = default;

		[Description("The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.")]
		[Category("SoundingDatum")]
		//[Editor(typeof(Editors.HorizonEditor<SoundingDatum>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,19,22,23,24,25,26,27,44])]
		[Mandatory]
		public verticalDatum verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("SoundingDatum")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SoundingDatum.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.SoundingDatum.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SoundingDatum.featureBindingDefinitions;

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
	[Description("Any level surface (for example Mean Sea Level) taken as a surface of reference to which the elevations within a data set are reduced. Also called datum level, reference level, reference plane, levelling datum, datum for heights.")]
	[CategoryOrder("VerticalDatumOfData",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class VerticalDatumOfDataViewModel : FeatureViewModel<VerticalDatumOfData> {
		private verticalDatum _verticalDatum  = default;

		[Description("The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.")]
		[Category("VerticalDatumOfData")]
		//[Editor(typeof(Editors.HorizonEditor<VerticalDatumOfData>), typeof(Editors.HorizonEditor))]
		[PermittedValues([3,13,16,17,18,19,20,21,24,25,26,28,29,30,44])]
		[Mandatory]
		public verticalDatum verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("VerticalDatumOfData")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

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

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.VerticalDatumOfData.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.VerticalDatumOfData.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.VerticalDatumOfData.featureBindingDefinitions;

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
			.. TextAssociations.Select(e => new featureBinding<DomainModel.S131.FeatureAssociations.TextAssociation> {
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

		public static AvailablePortServicesViewModel LoadInformationBinding(this AvailablePortServicesViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
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

		public static SpatialQualityViewModel LoadInformationBinding(this SpatialQualityViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static AnchorBerthViewModel LoadInformationBinding(this AnchorBerthViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceAvailability> serviceAvailability) {
					instance.ServiceAvailabilities.Add(new InformationRefViewModel {
						informationId = serviceAvailability.referenceId,
						informationType = serviceAvailability.informationType,
						role = serviceAvailability.role,
					});
				}
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

		public static AnchorageAreaViewModel LoadInformationBinding(this AnchorageAreaViewModel instance, informationBinding[] bindings) {
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

		public static AutomatedGuidedVehicleViewModel LoadInformationBinding(this AutomatedGuidedVehicleViewModel instance, informationBinding[] bindings) {
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

		public static BerthViewModel LoadInformationBinding(this BerthViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceAvailability> serviceAvailability) {
					instance.ServiceAvailabilities.Add(new InformationRefViewModel {
						informationId = serviceAvailability.referenceId,
						informationType = serviceAvailability.informationType,
						role = serviceAvailability.role,
					});
				}
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
					instance.ServiceAvailabilities.Add(new InformationRefViewModel {
						informationId = serviceAvailability.referenceId,
						informationType = serviceAvailability.informationType,
						role = serviceAvailability.role,
					});
				}
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

		public static DryDockViewModel LoadInformationBinding(this DryDockViewModel instance, informationBinding[] bindings) {
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

		public static DolphinViewModel LoadInformationBinding(this DolphinViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DumpingGroundViewModel LoadInformationBinding(this DumpingGroundViewModel instance, informationBinding[] bindings) {
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

		public static FenderLineViewModel LoadInformationBinding(this FenderLineViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static FloatingDockViewModel LoadInformationBinding(this FloatingDockViewModel instance, informationBinding[] bindings) {
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

		public static GridironViewModel LoadInformationBinding(this GridironViewModel instance, informationBinding[] bindings) {
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

		public static HarbourAreaAdministrativeViewModel LoadInformationBinding(this HarbourAreaAdministrativeViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceAvailability> serviceAvailability) {
					instance.ServiceAvailabilities.Add(new InformationRefViewModel {
						informationId = serviceAvailability.referenceId,
						informationType = serviceAvailability.informationType,
						role = serviceAvailability.role,
					});
				}
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

		public static HarbourAreaSectionViewModel LoadInformationBinding(this HarbourAreaSectionViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceAvailability> serviceAvailability) {
					instance.ServiceAvailabilities.Add(new InformationRefViewModel {
						informationId = serviceAvailability.referenceId,
						informationType = serviceAvailability.informationType,
						role = serviceAvailability.role,
					});
				}
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

		public static HarbourBasinViewModel LoadInformationBinding(this HarbourBasinViewModel instance, informationBinding[] bindings) {
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

		public static HarbourFacilityViewModel LoadInformationBinding(this HarbourFacilityViewModel instance, informationBinding[] bindings) {
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

		public static LockBasinViewModel LoadInformationBinding(this LockBasinViewModel instance, informationBinding[] bindings) {
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

		public static LockBasinPartViewModel LoadInformationBinding(this LockBasinPartViewModel instance, informationBinding[] bindings) {
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

		public static MooringBuoyViewModel LoadInformationBinding(this MooringBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static MooringWarpingFacilityViewModel LoadInformationBinding(this MooringWarpingFacilityViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<ServiceAvailability> serviceAvailability) {
					instance.ServiceAvailabilities.Add(new InformationRefViewModel {
						informationId = serviceAvailability.referenceId,
						informationType = serviceAvailability.informationType,
						role = serviceAvailability.role,
					});
				}
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

		public static OnshorePowerFacilityViewModel LoadInformationBinding(this OnshorePowerFacilityViewModel instance, informationBinding[] bindings) {
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

		public static OuterLimitViewModel LoadInformationBinding(this OuterLimitViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
				if(informationBinding is informationBinding<LimitEntrance> limitEntrance) {
					instance.LimitEntrances.Add(new InformationRefViewModel {
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
					instance.LocationHours.Add(new InformationRefViewModel {
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
					instance.LocationHours.Add(new InformationRefViewModel {
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
					instance.LocationHours.Add(new InformationRefViewModel {
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
					instance.LocationHours.Add(new InformationRefViewModel {
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
					instance.ServiceAvailabilities.Add(new InformationRefViewModel {
						informationId = serviceAvailability.referenceId,
						informationType = serviceAvailability.informationType,
						role = serviceAvailability.role,
					});
				}
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

		public static TurningBasinViewModel LoadInformationBinding(this TurningBasinViewModel instance, informationBinding[] bindings) {
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

		public static WaterwayAreaViewModel LoadInformationBinding(this WaterwayAreaViewModel instance, informationBinding[] bindings) {
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
					instance.PrimaryAuxiliaryFacilities.Add(new FeatureRefViewModel {
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
					instance.LayoutDivisions.Add(new FeatureRefViewModel {
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
					instance.Demarcations.Add(new FeatureRefViewModel {
						featureId = demarcation.referenceId,
						featureType = demarcation.featureType,
						role = demarcation.role,
					});
				}
				if(featureBinding is featureBinding<LayoutDivision> layoutDivision) {
					instance.LayoutDivisions.Add(new FeatureRefViewModel {
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
					instance.Demarcations.Add(new FeatureRefViewModel {
						featureId = demarcation.referenceId,
						featureType = demarcation.featureType,
						role = demarcation.role,
					});
				}
				if(featureBinding is featureBinding<PrimaryAuxiliaryFacility> primaryAuxiliaryFacility) {
					instance.PrimaryAuxiliaryFacilities.Add(new FeatureRefViewModel {
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
					instance.LayoutDivisions.Add(new FeatureRefViewModel {
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
					instance.LayoutDivisions.Add(new FeatureRefViewModel {
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
					instance.LayoutDivisions.Add(new FeatureRefViewModel {
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
					instance.JurisdictionalLimits.Add(new FeatureRefViewModel {
						featureId = jurisdictionalLimit.referenceId,
						featureType = jurisdictionalLimit.featureType,
						role = jurisdictionalLimit.role,
					});
				}
				if(featureBinding is featureBinding<LayoutDivision> layoutDivision) {
					instance.LayoutDivisions.Add(new FeatureRefViewModel {
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
					instance.LayoutDivisions.Add(new FeatureRefViewModel {
						featureId = layoutDivision.referenceId,
						featureType = layoutDivision.featureType,
						role = layoutDivision.role,
					});
				}
				if(featureBinding is featureBinding<Subsection> subsection) {
					instance.Subsections.Add(new FeatureRefViewModel {
						featureId = subsection.referenceId,
						featureType = subsection.featureType,
						role = subsection.role,
					});
				}
				if(featureBinding is featureBinding<Infrastructure> infrastructure) {
					instance.Infrastructures.Add(new FeatureRefViewModel {
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
					instance.LayoutDivisions.Add(new FeatureRefViewModel {
						featureId = layoutDivision.referenceId,
						featureType = layoutDivision.featureType,
						role = layoutDivision.role,
					});
				}
			}
			return instance;
		}

		public static HarbourFacilityViewModel LoadFeatureBinding(this HarbourFacilityViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
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
					instance.PrimaryAuxiliaryFacilities.Add(new FeatureRefViewModel {
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
					instance.JurisdictionalLimits.Add(new FeatureRefViewModel {
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
					instance.LayoutDivisions.Add(new FeatureRefViewModel {
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
					instance.LayoutDivisions.Add(new FeatureRefViewModel {
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
					instance.LayoutDivisions.Add(new FeatureRefViewModel {
						featureId = layoutDivision.referenceId,
						featureType = layoutDivision.featureType,
						role = layoutDivision.role,
					});
				}
				if(featureBinding is featureBinding<Infrastructure> infrastructure) {
					instance.Infrastructures.Add(new FeatureRefViewModel {
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
					instance.LayoutDivisions.Add(new FeatureRefViewModel {
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
					instance.LayoutDivisions.Add(new FeatureRefViewModel {
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
