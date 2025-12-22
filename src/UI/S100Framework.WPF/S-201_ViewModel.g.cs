using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ComponentModel;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S201;
using S100Framework.DomainModel.S201.ComplexAttributes;
using S100Framework.DomainModel.S201.InformationTypes;
using S100Framework.DomainModel.S201.FeatureTypes;
using S100Framework.DomainModel.S201.InformationAssociations;
using S100Framework.DomainModel.S201.FeatureAssociations;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using System.Text.Json;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.WPF.ViewModel.S201 {
	internal static class Bootstrap {
		public static AssociationViewModel CreateInformationAssociation(string type, string? name = default) => type switch {
			"Atonstatus" => new AtonstatusViewModel { Name = name },
			"AtonFixingMethodAssociation" => new AtonFixingMethodAssociationViewModel { Name = name },
			"AtonPositioningInformationAssociation" => new AtonPositioningInformationAssociationViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static AssociationViewModel CreateFeatureAssociation(string type, string? name = default) => type switch {
			"BuoyTopmark" => new BuoyTopmarkViewModel { Name = name },
			"StructureEquipment" => new StructureEquipmentViewModel { Name = name },
			"PhysicalAIS" => new PhysicalAISViewModel { Name = name },
			"SyntheticAIS" => new SyntheticAISViewModel { Name = name },
			"VirtualAIS" => new VirtualAISViewModel { Name = name },
			"BuoyCounterWeight" => new BuoyCounterWeightViewModel { Name = name },
			"BridleConnection" => new BridleConnectionViewModel { Name = name },
			"ShackleConnection" => new ShackleConnectionViewModel { Name = name },
			"ShackleConnectionFromCable" => new ShackleConnectionFromCableViewModel { Name = name },
			"SwivelCableConnection" => new SwivelCableConnectionViewModel { Name = name },
			"BridleCableConnection" => new BridleCableConnectionViewModel { Name = name },
			"ShackleToBridleConnection" => new ShackleToBridleConnectionViewModel { Name = name },
			"ShackleToSwivelConnection" => new ShackleToSwivelConnectionViewModel { Name = name },
			"ShackleToAnchorConnection" => new ShackleToAnchorConnectionViewModel { Name = name },
			"SwivelConnection" => new SwivelConnectionViewModel { Name = name },
			"AtonAggregations" => new AtonAggregationsViewModel { Name = name },
			"AtonAssociations" => new AtonAssociationsViewModel { Name = name },
			"RangeSystem" => new RangeSystemViewModel { Name = name },
			"DangerousFeatureAssociation" => new DangerousFeatureAssociationViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static InformationViewModel CreateInformationType(string type, string? name = default) => type switch {
			"AtoNFixingMethod" => new AtoNFixingMethodViewModel { Name = name },
			"AtonStatusInformation" => new AtonStatusInformationViewModel { Name = name },
			"PositioningInformation" => new PositioningInformationViewModel { Name = name },
			"SpatialQuality" => new SpatialQualityViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static FeatureViewModel CreateFeatureType(string type, string? name = default) => type switch {
			"Landmark" => new LandmarkViewModel { Name = name },
			"LateralBeacon" => new LateralBeaconViewModel { Name = name },
			"LateralBuoy" => new LateralBuoyViewModel { Name = name },
			"NavigationLine" => new NavigationLineViewModel { Name = name },
			"RecommendedTrack" => new RecommendedTrackViewModel { Name = name },
			"LightSectored" => new LightSectoredViewModel { Name = name },
			"LightAllAround" => new LightAllAroundViewModel { Name = name },
			"LightAirObstruction" => new LightAirObstructionViewModel { Name = name },
			"LightFogDetector" => new LightFogDetectorViewModel { Name = name },
			"RadarReflector" => new RadarReflectorViewModel { Name = name },
			"FogSignal" => new FogSignalViewModel { Name = name },
			"EnvironmentObservationEquipment" => new EnvironmentObservationEquipmentViewModel { Name = name },
			"RadioStation" => new RadioStationViewModel { Name = name },
			"Daymark" => new DaymarkViewModel { Name = name },
			"Retroreflector" => new RetroreflectorViewModel { Name = name },
			"RadarTransponderBeacon" => new RadarTransponderBeaconViewModel { Name = name },
			"VirtualAISAidToNavigation" => new VirtualAISAidToNavigationViewModel { Name = name },
			"PhysicalAISAidToNavigation" => new PhysicalAISAidToNavigationViewModel { Name = name },
			"SyntheticAISAidToNavigation" => new SyntheticAISAidToNavigationViewModel { Name = name },
			"PowerSource" => new PowerSourceViewModel { Name = name },
			"IsolatedDangerBeacon" => new IsolatedDangerBeaconViewModel { Name = name },
			"CardinalBeacon" => new CardinalBeaconViewModel { Name = name },
			"IsolatedDangerBuoy" => new IsolatedDangerBuoyViewModel { Name = name },
			"CardinalBuoy" => new CardinalBuoyViewModel { Name = name },
			"InstallationBuoy" => new InstallationBuoyViewModel { Name = name },
			"MooringBuoy" => new MooringBuoyViewModel { Name = name },
			"EmergencyWreckMarkingBuoy" => new EmergencyWreckMarkingBuoyViewModel { Name = name },
			"Lighthouse" => new LighthouseViewModel { Name = name },
			"LightFloat" => new LightFloatViewModel { Name = name },
			"LightVessel" => new LightVesselViewModel { Name = name },
			"OffshorePlatform" => new OffshorePlatformViewModel { Name = name },
			"SiloTank" => new SiloTankViewModel { Name = name },
			"Pile" => new PileViewModel { Name = name },
			"Building" => new BuildingViewModel { Name = name },
			"Bridge" => new BridgeViewModel { Name = name },
			"SinkerAnchor" => new SinkerAnchorViewModel { Name = name },
			"MooringShackle" => new MooringShackleViewModel { Name = name },
			"CableSubmarine" => new CableSubmarineViewModel { Name = name },
			"Swivel" => new SwivelViewModel { Name = name },
			"Bridle" => new BridleViewModel { Name = name },
			"CounterWeight" => new CounterWeightViewModel { Name = name },
			"Topmark" => new TopmarkViewModel { Name = name },
			"SafeWaterBeacon" => new SafeWaterBeaconViewModel { Name = name },
			"SpecialPurposeGeneralBeacon" => new SpecialPurposeGeneralBeaconViewModel { Name = name },
			"SafeWaterBuoy" => new SafeWaterBuoyViewModel { Name = name },
			"SpecialPurposeGeneralBuoy" => new SpecialPurposeGeneralBuoyViewModel { Name = name },
			"DangerousFeature" => new DangerousFeatureViewModel { Name = name },
			"AtonAggregation" => new AtonAggregationViewModel { Name = name },
			"AtonAssociation" => new AtonAssociationViewModel { Name = name },
			"QualityOfNonBathymetricData" => new QualityOfNonBathymetricDataViewModel { Name = name },
			"DataCoverage" => new DataCoverageViewModel { Name = name },
			"LocalDirectionOfBuoyage" => new LocalDirectionOfBuoyageViewModel { Name = name },
			"NavigationalSystemOfMarks" => new NavigationalSystemOfMarksViewModel { Name = name },
			"SoundingDatum" => new SoundingDatumViewModel { Name = name },
			"VerticalDatumOfData" => new VerticalDatumOfDataViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static ICollection<string> InformationAssociationBindings(string association, string role) => (association, role) switch {
			("Atonstatus", "Statuspart") => ["AtonStatusInformation"],
			("AtonPositioningInformationAssociation", "positioningMethod") => ["PositioningInformation"],
			("AtonFixingMethodAssociation", "fixingMethod") => ["AtoNFixingMethod"],
			_ => throw new InvalidOperationException(),
		};

		public static ICollection<string> FeatureAssociationBindings(string association, string role) => (association, role) switch {
			("AtonAggregations", "peerAtonAggregation") => ["AtonAggregation"],
			("AtonAssociations", "peerAtonAssociation") => ["AtonAssociation"],
			("StructureEquipment", "child") => ["Equipment"],
			("StructureEquipment", "parent") => ["StructureObject"],
			("BuoyTopmark", "topmarkPart") => ["Topmark"],
			("ShackleConnection", "shackleToBuoyconnected") => ["MooringShackle"],
			("BridleConnection", "buoyhangs") => ["Bridle"],
			("BuoyCounterWeight", "buoyattached") => ["CounterWeight"],
			("RangeSystem", "navigableTrack") => ["RecommendedTrack"],
			("RangeSystem", "navigationLine") => ["NavigationLine"],
			("PhysicalAIS", "physicalAISbroadcastBy") => ["PhysicalAISAidToNavigation"],
			("SyntheticAIS", "syntheticAISbroadcastBy") => ["SyntheticAISAidToNavigation"],
			("VirtualAIS", "virtualAISbroadcastBy") => ["VirtualAISAidToNavigation"],
			("VirtualAIS", "virtualAISbroadcasts") => ["RadioStation"],
			("PhysicalAIS", "physicalAISbroadcasts") => ["RadioStation"],
			("SyntheticAIS", "syntheticAISbroadcasts") => ["RadioStation"],
			("ShackleToAnchorConnection", "shackleToAnchorconnected") => ["MooringShackle"],
			("ShackleConnection", "shackleToBuoyconnectedTo") => ["GenericBuoy"],
			("ShackleToBridleConnection", "shackleToBridleconnectedTo") => ["Bridle"],
			("BridleCableConnection", "bridleattached") => ["CableSubmarine"],
			("ShackleToSwivelConnection", "shackleToSwivelconnectedTo") => ["Swivel"],
			("ShackleToAnchorConnection", "shackleToAnchorconnectedTo") => ["SinkerAnchor"],
			("BridleCableConnection", "cableholds") => ["Bridle"],
			("SwivelCableConnection", "cableholds") => ["Swivel"],
			("ShackleConnectionFromCable", "shackleToCableconnected") => ["MooringShackle"],
			("SwivelConnection", "swivelholds") => ["Bridle"],
			("SwivelCableConnection", "swivelattached") => ["CableSubmarine"],
			("ShackleToSwivelConnection", "shackleToSwivelconnected") => ["MooringShackle"],
			("BridleConnection", "bridleholds") => ["GenericBuoy"],
			("SwivelConnection", "bridlehangs") => ["Swivel"],
			("ShackleToBridleConnection", "shackleToBridleconnected") => ["MooringShackle"],
			("BuoyCounterWeight", "counterWeightholds") => ["GenericBuoy"],
			("BuoyTopmark", "buoyPart") => ["GenericBuoy"],
			("DangerousFeatureAssociation", "markingAton") => ["AtonAssociation"],
			("AtonAggregations", "atonAggregationBy") => ["AidsToNavigation"],
			("DangerousFeatureAssociation", "danger") => ["DangerousFeature"],
			("AtonAssociations", "atonAssociationBy") => ["AidsToNavigation"],
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
	/// A directional light is a light illuminating a sector of very narrow angle and intended to mark a direction to follow.
	/// </summary>
	[Description("A directional light is a light illuminating a sector of very narrow angle and intended to mark a direction to follow.")]
	[CategoryOrder("directionalCharacter",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class directionalCharacterViewModel : ComplexViewModel<directionalCharacter> {
		private Boolean? _moireEffect  = default;

		[Description("A short range (up to 2km) type of directional light. Sodium lighting gives a yellow background to a screen on which a vertical black line will be seen by an observer on the centre line.")]
		//[Editor(typeof(Editors.HorizonEditor<directionalCharacter>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? moireEffect {
			get {
				return _moireEffect;
			}
			set {
				SetValue(ref _moireEffect, value);
			}
		}

		private orientationViewModel _orientation  = default;

		[Description("(1) The angular distance measured from true north to the major axis of the feature. (2) In ECDIS, the mode in which information on the ECDIS is being presented. Typical modes include: north-up - as shown on a nautical chart, north is at the top of the display; Ships head-up - based on the actual heading of the ship, (e.g. Ships gyrocompass); course-up display - based on the course or route being taken.")]
		[ExpandableObject]
		[Mandatory]
		public orientationViewModel orientation {
			get {
				return _orientation;
			}
			set {
				SetValue(ref _orientation, value);
			}
		}

		public directionalCharacterViewModel Load(directionalCharacter instance) {
			moireEffect = instance.moireEffect;
			orientation = new ();
			if (instance.orientation != default) {
				orientation.Load(instance.orientation);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new directionalCharacter {
				moireEffect = this.moireEffect,
				orientation = this.orientation?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public directionalCharacter Model => new () {
			moireEffect = this._moireEffect,
			orientation = this._orientation?.Model,
		};

		public override string? ToString() => $"Directional Character";
	}


	/// <summary>
	/// Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.
	/// </summary>
	[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
	[CategoryOrder("featureName",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class featureNameViewModel : ComplexViewModel<featureName> {
		private Boolean? _displayName  = default;

		[Description("A statement expressing if a feature name is to be displayed in certain system display settings or not.")]
		//[Editor(typeof(Editors.HorizonEditor<featureName>), typeof(Editors.HorizonEditor))]
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
	[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
	[CategoryOrder("fixedDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class fixedDateRangeViewModel : ComplexViewModel<fixedDateRange> {
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
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference.
	/// </summary>
	[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference.")]
	[CategoryOrder("lightSector",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class lightSectorViewModel : ComplexViewModel<lightSector> {
		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		private directionalCharacterViewModel? _directionalCharacter  = default;

		[Description("A directional light is a light illuminating a sector of very narrow angle and intended to mark a direction to follow.")]
		[ExpandableObject]
		[Optional]
		public directionalCharacterViewModel? directionalCharacter {
			get {
				return _directionalCharacter;
			}
			set {
				SetValue(ref _directionalCharacter, value);
			}
		}

		[Description("The specific visibility of a light, with respect to the light's intensity and ease of recognition.")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<lightVisibility> lightVisibility  { get; set; } = new ();

		private sectorLimitViewModel? _sectorLimit  = default;

		[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. The sector limit specifies the limits of the sector In a clockwise direction around the central feature (for example a light).")]
		[ExpandableObject]
		[Optional]
		public sectorLimitViewModel? sectorLimit {
			get {
				return _sectorLimit;
			}
			set {
				SetValue(ref _sectorLimit, value);
			}
		}

		private double? _valueOfNominalRange  = default;

		[Description("The luminous range of a light in a homogenous atmosphere in which the meteorological visibility is 10 sea miles.")]
		//[Editor(typeof(Editors.HorizonEditor<lightSector>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? valueOfNominalRange {
			get {
				return _valueOfNominalRange;
			}
			set {
				SetValue(ref _valueOfNominalRange, value);
			}
		}

		[Description("Additional textual information about a light sector.")]
		[Optional]
		public ObservableCollection<sectorInformationViewModel> sectorInformation  { get; set; } = new ();

		private Boolean? _sectorArcExtension  = default;

		[Description("Distance in screen millimetres (mm) by which a sector arc is extended beyond the default.")]
		//[Editor(typeof(Editors.HorizonEditor<lightSector>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? sectorArcExtension {
			get {
				return _sectorArcExtension;
			}
			set {
				SetValue(ref _sectorArcExtension, value);
			}
		}

		public lightSectorViewModel Load(lightSector instance) {
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			directionalCharacter = new ();
			if (instance.directionalCharacter != default) {
				directionalCharacter.Load(instance.directionalCharacter);
			}
			lightVisibility.Clear();
			if (instance.lightVisibility is not null) {
				foreach(var e in instance.lightVisibility)
					lightVisibility.Add(e);
			}
			sectorLimit = new ();
			if (instance.sectorLimit != default) {
				sectorLimit.Load(instance.sectorLimit);
			}
			valueOfNominalRange = instance.valueOfNominalRange;
			sectorInformation.Clear();
			if (instance.sectorInformation is not null) {
				foreach(var e in instance.sectorInformation)
					sectorInformation.Add(new sectorInformationViewModel().Load(e));
			}
			sectorArcExtension = instance.sectorArcExtension;
			return this;
		}

		public override string Serialize() {
			var instance = new lightSector {
				colour = this.colour.ToList(),
				directionalCharacter = this.directionalCharacter?.Model,
				lightVisibility = this.lightVisibility.ToList(),
				sectorLimit = this.sectorLimit?.Model,
				valueOfNominalRange = this.valueOfNominalRange,
				sectorInformation = this.sectorInformation.Select(e => e.Model).ToList(),
				sectorArcExtension = this.sectorArcExtension,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public lightSector Model => new () {
			colour = this.colour.ToList(),
			directionalCharacter = this._directionalCharacter?.Model,
			lightVisibility = this.lightVisibility.ToList(),
			sectorLimit = this._sectorLimit?.Model,
			valueOfNominalRange = this._valueOfNominalRange,
			sectorInformation = this.sectorInformation.Select(e => e.Model).ToList(),
			sectorArcExtension = this._sectorArcExtension,
		};

		public override string? ToString() => $"Light Sector";

		public lightSectorViewModel() : base() {
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			lightVisibility.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(lightVisibility));
			};
			sectorInformation.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sectorInformation));
			};
		}
	}


	/// <summary>
	/// The number of features of identical character that exist as a colocated group.
	/// </summary>
	[Description("The number of features of identical character that exist as a colocated group.")]
	[CategoryOrder("multiplicityOfFeatures",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class multiplicityOfFeaturesViewModel : ComplexViewModel<multiplicityOfFeatures> {
		private Boolean _multiplicityKnown  = false;

		[Description("The number of features of identical character that exist as a co-located group is or is not known.")]
		//[Editor(typeof(Editors.HorizonEditor<multiplicityOfFeatures>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public Boolean multiplicityKnown {
			get {
				return _multiplicityKnown;
			}
			set {
				SetValue(ref _multiplicityKnown, value);
			}
		}

		private int? _numberOfFeatures  = default;

		[Description("The number of features of identical character that exist as a co-located group.")]
		//[Editor(typeof(Editors.HorizonEditor<multiplicityOfFeatures>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? numberOfFeatures {
			get {
				return _numberOfFeatures;
			}
			set {
				SetValue(ref _numberOfFeatures, value);
			}
		}

		public multiplicityOfFeaturesViewModel Load(multiplicityOfFeatures instance) {
			multiplicityKnown = instance.multiplicityKnown;
			numberOfFeatures = instance.numberOfFeatures;
			return this;
		}

		public override string Serialize() {
			var instance = new multiplicityOfFeatures {
				multiplicityKnown = this.multiplicityKnown,
				numberOfFeatures = this.numberOfFeatures,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public multiplicityOfFeatures Model => new () {
			multiplicityKnown = this._multiplicityKnown,
			numberOfFeatures = this._numberOfFeatures,
		};

		public override string? ToString() => $"Multiplicity of Features";
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
	/// The distance between two successive peaks (or other points of identical phase) on an electromagnetic wave in the radar band of the electromagnetic spectrum.
	/// </summary>
	[Description("The distance between two successive peaks (or other points of identical phase) on an electromagnetic wave in the radar band of the electromagnetic spectrum.")]
	[CategoryOrder("radarWaveLength",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class radarWaveLengthViewModel : ComplexViewModel<radarWaveLength> {
		private String _radarBand  = string.Empty;

		[Description("The band code character of the electromagnetic spectrum within which radar wave lengths lie.")]
		//[Editor(typeof(Editors.HorizonEditor<radarWaveLength>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String radarBand {
			get {
				return _radarBand;
			}
			set {
				SetValue(ref _radarBand, value);
			}
		}

		private double _waveLengthValue  = default;

		[Description("The distance between two successive peaks (or other points of identical phase) on an electromagnetic wave.")]
		//[Editor(typeof(Editors.HorizonEditor<radarWaveLength>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double waveLengthValue {
			get {
				return _waveLengthValue;
			}
			set {
				SetValue(ref _waveLengthValue, value);
			}
		}

		public radarWaveLengthViewModel Load(radarWaveLength instance) {
			radarBand = instance.radarBand;
			waveLengthValue = instance.waveLengthValue;
			return this;
		}

		public override string Serialize() {
			var instance = new radarWaveLength {
				radarBand = this.radarBand,
				waveLengthValue = this.waveLengthValue,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public radarWaveLength Model => new () {
			radarBand = this._radarBand,
			waveLengthValue = this._waveLengthValue,
		};

		public override string? ToString() => $"Radar Wave Length";
	}


	/// <summary>
	/// The sequence of times occupied by intervals of light/sound and eclipse/silence for all light characteristics or sound signals.
	/// </summary>
	[Description("The sequence of times occupied by intervals of light/sound and eclipse/silence for all light characteristics or sound signals.")]
	[CategoryOrder("rhythmOfLight",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class rhythmOfLightViewModel : ComplexViewModel<rhythmOfLight> {
		private lightCharacteristic _lightCharacteristic  = default;

		[Description("The distinct character, such as fixed, flashing, or occulting, which is given to each light to avoid confusion with neighbouring ones.")]
		//[Editor(typeof(Editors.HorizonEditor<rhythmOfLight>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,12,13,14,15,16,17,18,19,20,25,26,27,28,29,30,31,32,33,34,35])]
		[Mandatory]
		public lightCharacteristic lightCharacteristic {
			get {
				return _lightCharacteristic;
			}
			set {
				SetValue(ref _lightCharacteristic, value);
			}
		}

		[Description("The number of signals, the combination of signals or the morse character(s) within one period of full sequence.")]
		[Multiplicity(0, 10)]
		public ObservableCollection<String> signalGroup  { get; set; } = new ();

		private double? _signalPeriod  = default;

		[Description("The time occupied by an entire cycle of intervals of light and eclipse.")]
		//[Editor(typeof(Editors.HorizonEditor<rhythmOfLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? signalPeriod {
			get {
				return _signalPeriod;
			}
			set {
				SetValue(ref _signalPeriod, value);
			}
		}

		[Description("The sequence of times occupied by intervals of light and eclipse for all light characteristics.")]
		[Multiplicity(0, 10)]
		public ObservableCollection<signalSequenceViewModel> signalSequence  { get; set; } = new ();

		public rhythmOfLightViewModel Load(rhythmOfLight instance) {
			lightCharacteristic = instance.lightCharacteristic;
			signalGroup.Clear();
			if (instance.signalGroup is not null) {
				foreach(var e in instance.signalGroup)
					signalGroup.Add(e);
			}
			signalPeriod = instance.signalPeriod;
			signalSequence.Clear();
			if (instance.signalSequence is not null) {
				foreach(var e in instance.signalSequence)
					signalSequence.Add(new signalSequenceViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new rhythmOfLight {
				lightCharacteristic = this.lightCharacteristic,
				signalGroup = this.signalGroup.ToList(),
				signalPeriod = this.signalPeriod,
				signalSequence = this.signalSequence.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public rhythmOfLight Model => new () {
			lightCharacteristic = this._lightCharacteristic,
			signalGroup = this.signalGroup.ToList(),
			signalPeriod = this._signalPeriod,
			signalSequence = this.signalSequence.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"Rhythm of Light";

		public rhythmOfLightViewModel() : base() {
			signalGroup.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(signalGroup));
			};
			signalSequence.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(signalSequence));
			};
		}
	}


	/// <summary>
	/// Describes the characteristics of a light sector.
	/// </summary>
	[Description("Describes the characteristics of a light sector.")]
	[CategoryOrder("sectorCharacteristics",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorCharacteristicsViewModel : ComplexViewModel<sectorCharacteristics> {
		private lightCharacteristic _lightCharacteristic  = default;

		[Description("The distinct character, such as fixed, flashing, or occulting, which is given to each light to avoid confusion with neighbouring ones.")]
		//[Editor(typeof(Editors.HorizonEditor<sectorCharacteristics>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,12,13,14,15,16,17,18,19,20,25,26,27,28,29,30,31,32,33,34,35])]
		[Mandatory]
		public lightCharacteristic lightCharacteristic {
			get {
				return _lightCharacteristic;
			}
			set {
				SetValue(ref _lightCharacteristic, value);
			}
		}

		[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference.")]
		[Multiplicity(1, 10)]
		public ObservableCollection<lightSectorViewModel> lightSector  { get; set; } = new ();

		[Description("The number of signals, the combination of signals or the morse character(s) within one period of full sequence.")]
		[Multiplicity(0, 10)]
		public ObservableCollection<String> signalGroup  { get; set; } = new ();

		private double? _signalPeriod  = default;

		[Description("The time occupied by an entire cycle of intervals of light and eclipse.")]
		//[Editor(typeof(Editors.HorizonEditor<sectorCharacteristics>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? signalPeriod {
			get {
				return _signalPeriod;
			}
			set {
				SetValue(ref _signalPeriod, value);
			}
		}

		[Description("The sequence of times occupied by intervals of light and eclipse for all light characteristics.")]
		[Multiplicity(0, 10)]
		public ObservableCollection<signalSequenceViewModel> signalSequence  { get; set; } = new ();

		public sectorCharacteristicsViewModel Load(sectorCharacteristics instance) {
			lightCharacteristic = instance.lightCharacteristic;
			lightSector.Clear();
			if (instance.lightSector is not null) {
				foreach(var e in instance.lightSector)
					lightSector.Add(new lightSectorViewModel().Load(e));
			}
			signalGroup.Clear();
			if (instance.signalGroup is not null) {
				foreach(var e in instance.signalGroup)
					signalGroup.Add(e);
			}
			signalPeriod = instance.signalPeriod;
			signalSequence.Clear();
			if (instance.signalSequence is not null) {
				foreach(var e in instance.signalSequence)
					signalSequence.Add(new signalSequenceViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new sectorCharacteristics {
				lightCharacteristic = this.lightCharacteristic,
				lightSector = this.lightSector.Select(e => e.Model).ToList(),
				signalGroup = this.signalGroup.ToList(),
				signalPeriod = this.signalPeriod,
				signalSequence = this.signalSequence.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public sectorCharacteristics Model => new () {
			lightCharacteristic = this._lightCharacteristic,
			lightSector = this.lightSector.Select(e => e.Model).ToList(),
			signalGroup = this.signalGroup.ToList(),
			signalPeriod = this._signalPeriod,
			signalSequence = this.signalSequence.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"Sector Characteristics";

		public sectorCharacteristicsViewModel() : base() {
			lightSector.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(lightSector));
			};
			signalGroup.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(signalGroup));
			};
			signalSequence.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(signalSequence));
			};
		}
	}


	/// <summary>
	/// Additional textual information about a light sector.
	/// </summary>
	[Description("Additional textual information about a light sector.")]
	[CategoryOrder("sectorInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorInformationViewModel : ComplexViewModel<sectorInformation> {
		private String? _language  = default;

		[Description("The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.")]
		//[Editor(typeof(Editors.HorizonEditor<sectorInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}

		private String _text  = string.Empty;

		[Description("A non-formatted digital text string.")]
		//[Editor(typeof(Editors.HorizonEditor<sectorInformation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
			}
		}

		public sectorInformationViewModel Load(sectorInformation instance) {
			language = instance.language;
			text = instance.text;
			return this;
		}

		public override string Serialize() {
			var instance = new sectorInformation {
				language = this.language,
				text = this.text,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public sectorInformation Model => new () {
			language = this._language,
			text = this._text,
		};

		public override string? ToString() => $"Sector Information";
	}


	/// <summary>
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. The sector limit specifies the limits of the sector In a clockwise direction around the central feature (for example a light).
	/// </summary>
	[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. The sector limit specifies the limits of the sector In a clockwise direction around the central feature (for example a light).")]
	[CategoryOrder("sectorLimit",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorLimitViewModel : ComplexViewModel<sectorLimit> {
		private sectorLimitOneViewModel _sectorLimitOne  = default;

		[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit one specifies the first limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).")]
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

		[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit two specifies the second limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).")]
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
	[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit one specifies the first limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).")]
	[CategoryOrder("sectorLimitOne",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorLimitOneViewModel : ComplexViewModel<sectorLimitOne> {
		private double _sectorBearing  = default;

		[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector bearing specifies the limit of the sector.")]
		//[Editor(typeof(Editors.HorizonEditor<sectorLimitOne>), typeof(Editors.HorizonEditor))]
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

		[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector line length specifies the displayed length of the line, in ground units, defining the limit of the sector.")]
		//[Editor(typeof(Editors.HorizonEditor<sectorLimitOne>), typeof(Editors.HorizonEditor))]
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
	[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit two specifies the second limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).")]
	[CategoryOrder("sectorLimitTwo",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorLimitTwoViewModel : ComplexViewModel<sectorLimitTwo> {
		private double _sectorBearing  = default;

		[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector bearing specifies the limit of the sector.")]
		//[Editor(typeof(Editors.HorizonEditor<sectorLimitTwo>), typeof(Editors.HorizonEditor))]
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

		[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector line length specifies the displayed length of the line, in ground units, defining the limit of the sector.")]
		//[Editor(typeof(Editors.HorizonEditor<sectorLimitTwo>), typeof(Editors.HorizonEditor))]
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
	/// Textual information about the shape of a non-standard topmark.
	/// </summary>
	[Description("Textual information about the shape of a non-standard topmark.")]
	[CategoryOrder("shapeInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class shapeInformationViewModel : ComplexViewModel<shapeInformation> {
		private String? _language  = default;

		[Description("The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.")]
		//[Editor(typeof(Editors.HorizonEditor<shapeInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}

		private String _text  = string.Empty;

		[Description("A non-formatted digital text string.")]
		//[Editor(typeof(Editors.HorizonEditor<shapeInformation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
			}
		}

		public shapeInformationViewModel Load(shapeInformation instance) {
			language = instance.language;
			text = instance.text;
			return this;
		}

		public override string Serialize() {
			var instance = new shapeInformation {
				language = this.language,
				text = this.text,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public shapeInformation Model => new () {
			language = this._language,
			text = this._text,
		};

		public override string? ToString() => $"Shape Information";
	}


	/// <summary>
	/// The sequence of times occupied by intervals of light and eclipse for all light characteristics.
	/// </summary>
	[Description("The sequence of times occupied by intervals of light and eclipse for all light characteristics.")]
	[CategoryOrder("signalSequence",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class signalSequenceViewModel : ComplexViewModel<signalSequence> {
		private double _signalDuration  = default;

		[Description("The time occupied by a single instance of light/sound or eclipse/silence in a signal sequence.")]
		//[Editor(typeof(Editors.HorizonEditor<signalSequence>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double signalDuration {
			get {
				return _signalDuration;
			}
			set {
				SetValue(ref _signalDuration, value);
			}
		}

		private signalStatus _signalStatus  = default;

		[Description("The indication of an element of a signal sequence being a period of light/sound or eclipse/silence.")]
		//[Editor(typeof(Editors.HorizonEditor<signalSequence>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2])]
		[Mandatory]
		public signalStatus signalStatus {
			get {
				return _signalStatus;
			}
			set {
				SetValue(ref _signalStatus, value);
			}
		}

		public signalSequenceViewModel Load(signalSequence instance) {
			signalDuration = instance.signalDuration;
			signalStatus = instance.signalStatus;
			return this;
		}

		public override string Serialize() {
			var instance = new signalSequence {
				signalDuration = this.signalDuration,
				signalStatus = this.signalStatus,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public signalSequence Model => new () {
			signalDuration = this._signalDuration,
			signalStatus = this._signalStatus,
		};

		public override string? ToString() => $"Signal Sequence";
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
	/// The dimensions of a cable to give its length and diameter.
	/// </summary>
	[Description("The dimensions of a cable to give its length and diameter.")]
	[CategoryOrder("CableDimensions",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CableDimensionsViewModel : ComplexViewModel<CableDimensions> {
		private double _cableLength  = default;

		[Description("Total length of a cable.")]
		//[Editor(typeof(Editors.HorizonEditor<CableDimensions>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double cableLength {
			get {
				return _cableLength;
			}
			set {
				SetValue(ref _cableLength, value);
			}
		}

		private heightLengthUnits _heightLengthUnits  = default;

		[Description("Units of measure of waterway distances. (IHO Registry)")]
		//[Editor(typeof(Editors.HorizonEditor<CableDimensions>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6])]
		[Mandatory]
		public heightLengthUnits heightLengthUnits {
			get {
				return _heightLengthUnits;
			}
			set {
				SetValue(ref _heightLengthUnits, value);
			}
		}

		private double _diameter  = default;

		[Description("-")]
		//[Editor(typeof(Editors.HorizonEditor<CableDimensions>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double diameter {
			get {
				return _diameter;
			}
			set {
				SetValue(ref _diameter, value);
			}
		}

		public CableDimensionsViewModel Load(CableDimensions instance) {
			cableLength = instance.cableLength;
			heightLengthUnits = instance.heightLengthUnits;
			diameter = instance.diameter;
			return this;
		}

		public override string Serialize() {
			var instance = new CableDimensions {
				cableLength = this.cableLength,
				heightLengthUnits = this.heightLengthUnits,
				diameter = this.diameter,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CableDimensions Model => new () {
			cableLength = this._cableLength,
			heightLengthUnits = this._heightLengthUnits,
			diameter = this._diameter,
		};

		public override string? ToString() => $"Cable Dimensions";
	}


	/// <summary>
	/// -
	/// </summary>
	[Description("-")]
	[CategoryOrder("ChangeDetails",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ChangeDetailsViewModel : ComplexViewModel<ChangeDetails> {
		private atonCommissioning? _atonCommissioning  = default;

		[Description(".")]
		//[Editor(typeof(Editors.HorizonEditor<ChangeDetails>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Optional]
		public atonCommissioning? atonCommissioning {
			get {
				return _atonCommissioning;
			}
			set {
				SetValue(ref _atonCommissioning, value);
			}
		}

		private atonRemoval? _atonRemoval  = default;

		[Description(".")]
		//[Editor(typeof(Editors.HorizonEditor<ChangeDetails>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
		[Optional]
		public atonRemoval? atonRemoval {
			get {
				return _atonRemoval;
			}
			set {
				SetValue(ref _atonRemoval, value);
			}
		}

		private atonReplacement? _atonReplacement  = default;

		[Description(".")]
		//[Editor(typeof(Editors.HorizonEditor<ChangeDetails>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
		[Optional]
		public atonReplacement? atonReplacement {
			get {
				return _atonReplacement;
			}
			set {
				SetValue(ref _atonReplacement, value);
			}
		}

		private fixedAtonChange? _fixedAtonChange  = default;

		[Description(".")]
		//[Editor(typeof(Editors.HorizonEditor<ChangeDetails>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11])]
		[Optional]
		public fixedAtonChange? fixedAtonChange {
			get {
				return _fixedAtonChange;
			}
			set {
				SetValue(ref _fixedAtonChange, value);
			}
		}

		private floatingAtonChange? _floatingAtonChange  = default;

		[Description(".")]
		//[Editor(typeof(Editors.HorizonEditor<ChangeDetails>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26])]
		[Optional]
		public floatingAtonChange? floatingAtonChange {
			get {
				return _floatingAtonChange;
			}
			set {
				SetValue(ref _floatingAtonChange, value);
			}
		}

		private audibleSignalAtonChange? _audibleSignalAtonChange  = default;

		[Description(".")]
		//[Editor(typeof(Editors.HorizonEditor<ChangeDetails>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Optional]
		public audibleSignalAtonChange? audibleSignalAtonChange {
			get {
				return _audibleSignalAtonChange;
			}
			set {
				SetValue(ref _audibleSignalAtonChange, value);
			}
		}

		private lightedAtonChange? _lightedAtonChange  = default;

		[Description(".")]
		//[Editor(typeof(Editors.HorizonEditor<ChangeDetails>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24])]
		[Optional]
		public lightedAtonChange? lightedAtonChange {
			get {
				return _lightedAtonChange;
			}
			set {
				SetValue(ref _lightedAtonChange, value);
			}
		}

		private electronicAtonChange? _electronicAtonChange  = default;

		[Description(".")]
		//[Editor(typeof(Editors.HorizonEditor<ChangeDetails>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30])]
		[Optional]
		public electronicAtonChange? electronicAtonChange {
			get {
				return _electronicAtonChange;
			}
			set {
				SetValue(ref _electronicAtonChange, value);
			}
		}

		public ChangeDetailsViewModel Load(ChangeDetails instance) {
			atonCommissioning = instance.atonCommissioning;
			atonRemoval = instance.atonRemoval;
			atonReplacement = instance.atonReplacement;
			fixedAtonChange = instance.fixedAtonChange;
			floatingAtonChange = instance.floatingAtonChange;
			audibleSignalAtonChange = instance.audibleSignalAtonChange;
			lightedAtonChange = instance.lightedAtonChange;
			electronicAtonChange = instance.electronicAtonChange;
			return this;
		}

		public override string Serialize() {
			var instance = new ChangeDetails {
				atonCommissioning = this.atonCommissioning,
				atonRemoval = this.atonRemoval,
				atonReplacement = this.atonReplacement,
				fixedAtonChange = this.fixedAtonChange,
				floatingAtonChange = this.floatingAtonChange,
				audibleSignalAtonChange = this.audibleSignalAtonChange,
				lightedAtonChange = this.lightedAtonChange,
				electronicAtonChange = this.electronicAtonChange,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ChangeDetails Model => new () {
			atonCommissioning = this._atonCommissioning,
			atonRemoval = this._atonRemoval,
			atonReplacement = this._atonReplacement,
			fixedAtonChange = this._fixedAtonChange,
			floatingAtonChange = this._floatingAtonChange,
			audibleSignalAtonChange = this._audibleSignalAtonChange,
			lightedAtonChange = this._lightedAtonChange,
			electronicAtonChange = this._electronicAtonChange,
		};

		public override string? ToString() => $"Change Details";
	}


	/// <summary>
	/// -
	/// </summary>
	[Description("-")]
	[CategoryOrder("ObscuredSector",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ObscuredSectorViewModel : ComplexViewModel<ObscuredSector> {
		private sectorLimitViewModel _sectorLimit  = default;

		[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. The sector limit specifies the limits of the sector In a clockwise direction around the central feature (for example a light).")]
		[ExpandableObject]
		[Mandatory]
		public sectorLimitViewModel sectorLimit {
			get {
				return _sectorLimit;
			}
			set {
				SetValue(ref _sectorLimit, value);
			}
		}

		private sectorInformationViewModel? _sectorInformation  = default;

		[Description("Additional textual information about a light sector.")]
		[ExpandableObject]
		[Optional]
		public sectorInformationViewModel? sectorInformation {
			get {
				return _sectorInformation;
			}
			set {
				SetValue(ref _sectorInformation, value);
			}
		}

		public ObscuredSectorViewModel Load(ObscuredSector instance) {
			sectorLimit = new ();
			if (instance.sectorLimit != default) {
				sectorLimit.Load(instance.sectorLimit);
			}
			sectorInformation = new ();
			if (instance.sectorInformation != default) {
				sectorInformation.Load(instance.sectorInformation);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new ObscuredSector {
				sectorLimit = this.sectorLimit?.Model,
				sectorInformation = this.sectorInformation?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ObscuredSector Model => new () {
			sectorLimit = this._sectorLimit?.Model,
			sectorInformation = this._sectorInformation?.Model,
		};

		public override string? ToString() => $"Obscured Sector";
	}


	/// <summary>
	/// The dimensions of a sinker/anchor to give its three dimensional shape measurements.
	/// </summary>
	[Description("The dimensions of a sinker/anchor to give its three dimensional shape measurements.")]
	[CategoryOrder("sinkerDimensions",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sinkerDimensionsViewModel : ComplexViewModel<sinkerDimensions> {
		private heightLengthUnits _heightLengthUnits  = default;

		[Description("Units of measure of waterway distances. (IHO Registry)")]
		//[Editor(typeof(Editors.HorizonEditor<sinkerDimensions>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6])]
		[Mandatory]
		public heightLengthUnits heightLengthUnits {
			get {
				return _heightLengthUnits;
			}
			set {
				SetValue(ref _heightLengthUnits, value);
			}
		}

		private double? _horizontalLength  = default;

		[Description("A measurement of the longer of two linear axis.")]
		//[Editor(typeof(Editors.HorizonEditor<sinkerDimensions>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalLength {
			get {
				return _horizontalLength;
			}
			set {
				SetValue(ref _horizontalLength, value);
			}
		}

		private double? _horizontalWidth  = default;

		[Description("A measurement of the shorter of two linear axis.")]
		//[Editor(typeof(Editors.HorizonEditor<sinkerDimensions>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalWidth {
			get {
				return _horizontalWidth;
			}
			set {
				SetValue(ref _horizontalWidth, value);
			}
		}

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		//[Editor(typeof(Editors.HorizonEditor<sinkerDimensions>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		public sinkerDimensionsViewModel Load(sinkerDimensions instance) {
			heightLengthUnits = instance.heightLengthUnits;
			horizontalLength = instance.horizontalLength;
			horizontalWidth = instance.horizontalWidth;
			verticalLength = instance.verticalLength;
			return this;
		}

		public override string Serialize() {
			var instance = new sinkerDimensions {
				heightLengthUnits = this.heightLengthUnits,
				horizontalLength = this.horizontalLength,
				horizontalWidth = this.horizontalWidth,
				verticalLength = this.verticalLength,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public sinkerDimensions Model => new () {
			heightLengthUnits = this._heightLengthUnits,
			horizontalLength = this._horizontalLength,
			horizontalWidth = this._horizontalWidth,
			verticalLength = this._verticalLength,
		};

		public override string? ToString() => $"Sinker Dimensions";
	}


	/// <summary>
	/// A description of the method used to obtain a position.(proposed by CCG)
	/// </summary>
	[Description("A description of the method used to obtain a position.(proposed by CCG)")]
	[CategoryOrder("positioningMethod",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class positioningMethodViewModel : ComplexViewModel<positioningMethod> {
		private positioningEquipment _positioningEquipment  = default;

		[Description(".")]
		//[Editor(typeof(Editors.HorizonEditor<positioningMethod>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Mandatory]
		public positioningEquipment positioningEquipment {
			get {
				return _positioningEquipment;
			}
			set {
				SetValue(ref _positioningEquipment, value);
			}
		}

		private String _NMEAString  = string.Empty;

		[Description("NMEA string captured from the positioning device.(proposed by CCG)")]
		//[Editor(typeof(Editors.HorizonEditor<positioningMethod>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String NMEAString {
			get {
				return _NMEAString;
			}
			set {
				SetValue(ref _NMEAString, value);
			}
		}

		public positioningMethodViewModel Load(positioningMethod instance) {
			positioningEquipment = instance.positioningEquipment;
			NMEAString = instance.NMEAString;
			return this;
		}

		public override string Serialize() {
			var instance = new positioningMethod {
				positioningEquipment = this.positioningEquipment,
				NMEAString = this.NMEAString,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public positioningMethod Model => new () {
			positioningEquipment = this._positioningEquipment,
			NMEAString = this._NMEAString,
		};

		public override string? ToString() => $"Positioning Method";
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

		private String _language  = string.Empty;

		[Description("The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.")]
		//[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String language {
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
	/// Encodes the file name of a single external text file that contains the text in a defined language, which provides additional textual information that cannot be provided using other allowable attributes for the feature.
	/// </summary>
	[Description("Encodes the file name of a single external text file that contains the text in a defined language, which provides additional textual information that cannot be provided using other allowable attributes for the feature.")]
	[CategoryOrder("textualDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class textualDescriptionViewModel : ComplexViewModel<textualDescription> {
		private String _fileReference  = string.Empty;

		[Description("The file name of an externally referenced text file.")]
		//[Editor(typeof(Editors.HorizonEditor<textualDescription>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String fileReference {
			get {
				return _fileReference;
			}
			set {
				SetValue(ref _fileReference, value);
			}
		}

		private String? _language  = default;

		[Description("The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.")]
		//[Editor(typeof(Editors.HorizonEditor<textualDescription>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}

		public textualDescriptionViewModel Load(textualDescription instance) {
			fileReference = instance.fileReference;
			language = instance.language;
			return this;
		}

		public override string Serialize() {
			var instance = new textualDescription {
				fileReference = this.fileReference,
				language = this.language,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public textualDescription Model => new () {
			fileReference = this._fileReference,
			language = this._language,
		};

		public override string? ToString() => $"Textual Description";
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
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("Atonstatus",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonstatusViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new Atonstatus {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Aton Status";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("AtonFixingMethodAssociation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonFixingMethodAssociationViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new AtonFixingMethodAssociation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Aton Fixing Method Association";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("AtonPositioningInformationAssociation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonPositioningInformationAssociationViewModel : InformationAssociationViewModel {


		public override string Serialize() {
			var instance = new AtonPositioningInformationAssociation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Aton Positioning Information Association";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("BuoyTopmark",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BuoyTopmarkViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new BuoyTopmark {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Buoy Topmark";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("StructureEquipment",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class StructureEquipmentViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new StructureEquipment {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Structure Equipment";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("PhysicalAIS",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PhysicalAISViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new PhysicalAIS {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Physical AIS";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("SyntheticAIS",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SyntheticAISViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new SyntheticAIS {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Synthetic AIS";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("VirtualAIS",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class VirtualAISViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new VirtualAIS {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Virtual AIS";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("BuoyCounterWeight",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BuoyCounterWeightViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new BuoyCounterWeight {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Buoy Counter Weight";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("BridleConnection",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BridleConnectionViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new BridleConnection {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Bridle Connection";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("ShackleConnection",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ShackleConnectionViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new ShackleConnection {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Shackle Connection";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("ShackleConnectionFromCable",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ShackleConnectionFromCableViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new ShackleConnectionFromCable {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Shackle Connection From Cable";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("SwivelCableConnection",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SwivelCableConnectionViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new SwivelCableConnection {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Swivel Cable Connection";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("BridleCableConnection",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BridleCableConnectionViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new BridleCableConnection {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Bridle Cable Connection";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("ShackleToBridleConnection",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ShackleToBridleConnectionViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new ShackleToBridleConnection {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Shackle To Bridle Connection";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("ShackleToSwivelConnection",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ShackleToSwivelConnectionViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new ShackleToSwivelConnection {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Shackle To Swivel Connection";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("ShackleToAnchorConnection",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ShackleToAnchorConnectionViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new ShackleToAnchorConnection {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"ShackleToAnchorConnection";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("SwivelConnection",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SwivelConnectionViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new SwivelConnection {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Swivel Connection";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("AtonAggregations",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonAggregationsViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new AtonAggregations {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Aton Aggregations";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("AtonAssociations",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonAssociationsViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new AtonAssociations {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Aton Associations";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("RangeSystem",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RangeSystemViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new RangeSystem {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Range System";
	}



	/// <summary>
	/// 
	/// </summary>
	[Description("")]
	[CategoryOrder("DangerousFeatureAssociation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DangerousFeatureAssociationViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new DangerousFeatureAssociation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Dangerous Feature Association";
	}



	/// <summary>
	/// Method used for fixing the position of an aid to navigation.
	/// </summary>
	[Description("Method used for fixing the position of an aid to navigation.")]
	[CategoryOrder("AtoNFixingMethod",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtoNFixingMethodViewModel : InformationViewModel<AtoNFixingMethod> {
		private String? _referencePoint  = default;

		[Description("-")]
		[Category("AtoNFixingMethod")]
		//[Editor(typeof(Editors.HorizonEditor<AtoNFixingMethod>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? referencePoint {
			get {
				return _referencePoint;
			}
			set {
				SetValue(ref _referencePoint, value);
			}
		}

		private horizontalDatum? _horizontalDatum  = default;

		[Description("Horizontal reference surface or the reference coordinate system used for geodetic control in the calculation of coordinates of points on the earth.")]
		[Category("AtoNFixingMethod")]
		//[Editor(typeof(Editors.HorizonEditor<AtoNFixingMethod>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,116,117,118,119,120,121,122,123,124,125,126,127,128,129,130,131])]
		[Optional]
		public horizontalDatum? horizontalDatum {
			get {
				return _horizontalDatum;
			}
			set {
				SetValue(ref _horizontalDatum, value);
			}
		}

		private DateOnly _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AtoNFixingMethod")]
		//[Editor(typeof(Editors.HorizonEditor<AtoNFixingMethod>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public DateOnly sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String _positioningProcedure  = string.Empty;

		[Description("-")]
		[Category("AtoNFixingMethod")]
		//[Editor(typeof(Editors.HorizonEditor<AtoNFixingMethod>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String positioningProcedure {
			get {
				return _positioningProcedure;
			}
			set {
				SetValue(ref _positioningProcedure, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];

		public AtoNFixingMethodViewModel Load(AtoNFixingMethod instance) {
			referencePoint = instance.referencePoint;
			horizontalDatum = instance.horizontalDatum;
			sourceDate = instance.sourceDate;
			positioningProcedure = instance.positioningProcedure;
			return this;
		}

		public override string Serialize() {
			var instance = new AtoNFixingMethod {
				referencePoint = this.referencePoint,
				horizontalDatum = this.horizontalDatum,
				sourceDate = this.sourceDate,
				positioningProcedure = this.positioningProcedure,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AtoNFixingMethod Model => new () {
			referencePoint = this._referencePoint,
			horizontalDatum = this._horizontalDatum,
			sourceDate = this._sourceDate,
			positioningProcedure = this._positioningProcedure,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.AtoNFixingMethod.informationBindingDefinitions;

		public AtoNFixingMethodViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"AtoN Fixing Method";
	}



	/// <summary>
	/// -
	/// </summary>
	[Description("-")]
	[CategoryOrder("AtonStatusInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonStatusInformationViewModel : InformationViewModel<AtonStatusInformation> {
		private ChangeDetailsViewModel _ChangeDetails  = default;

		[Description("-")]
		[Category("AtonStatusInformation")]
		[ExpandableObject]
		[Mandatory]
		public ChangeDetailsViewModel ChangeDetails {
			get {
				return _ChangeDetails;
			}
			set {
				SetValue(ref _ChangeDetails, value);
			}
		}

		private ChangeTypes? _ChangeTypes  = default;

		[Description("-")]
		[Category("AtonStatusInformation")]
		//[Editor(typeof(Editors.HorizonEditor<AtonStatusInformation>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Optional]
		public ChangeTypes? ChangeTypes {
			get {
				return _ChangeTypes;
			}
			set {
				SetValue(ref _ChangeTypes, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];

		public AtonStatusInformationViewModel Load(AtonStatusInformation instance) {
			ChangeDetails = new ();
			if (instance.ChangeDetails != default) {
				ChangeDetails.Load(instance.ChangeDetails);
			}
			ChangeTypes = instance.ChangeTypes;
			return this;
		}

		public override string Serialize() {
			var instance = new AtonStatusInformation {
				ChangeDetails = this.ChangeDetails?.Model,
				ChangeTypes = this.ChangeTypes,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AtonStatusInformation Model => new () {
			ChangeDetails = this._ChangeDetails?.Model,
			ChangeTypes = this._ChangeTypes,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.AtonStatusInformation.informationBindingDefinitions;

		public AtonStatusInformationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Aton Status Information";
	}



	/// <summary>
	/// Information about how a position was obtained. (proposed by CCG)
	/// </summary>
	[Description("Information about how a position was obtained. (proposed by CCG)")]
	[CategoryOrder("PositioningInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PositioningInformationViewModel : InformationViewModel<PositioningInformation> {
		private String _positioningDevice  = string.Empty;

		[Description("-")]
		[Category("PositioningInformation")]
		//[Editor(typeof(Editors.HorizonEditor<PositioningInformation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String positioningDevice {
			get {
				return _positioningDevice;
			}
			set {
				SetValue(ref _positioningDevice, value);
			}
		}

		private positioningMethodViewModel? _positioningMethod  = default;

		[Description("A description of the method used to obtain a position.(proposed by CCG)")]
		[Category("PositioningInformation")]
		[ExpandableObject]
		[Optional]
		public positioningMethodViewModel? positioningMethod {
			get {
				return _positioningMethod;
			}
			set {
				SetValue(ref _positioningMethod, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];

		public PositioningInformationViewModel Load(PositioningInformation instance) {
			positioningDevice = instance.positioningDevice;
			positioningMethod = new ();
			if (instance.positioningMethod != default) {
				positioningMethod.Load(instance.positioningMethod);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new PositioningInformation {
				positioningDevice = this.positioningDevice,
				positioningMethod = this.positioningMethod?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PositioningInformation Model => new () {
			positioningDevice = this._positioningDevice,
			positioningMethod = this._positioningMethod?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.PositioningInformation.informationBindingDefinitions;

		public PositioningInformationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Positioning Information";
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

		private spatialAccuracyViewModel? _spatialAccuracy  = default;

		[Description("Provides an indication of the vertical and horizontal positional uncertainty of bathymetric data, optionally within a specified date range.")]
		[Category("SpatialQuality")]
		[ExpandableObject]
		[Optional]
		public spatialAccuracyViewModel? spatialAccuracy {
			get {
				return _spatialAccuracy;
			}
			set {
				SetValue(ref _spatialAccuracy, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];

		public SpatialQualityViewModel Load(SpatialQuality instance) {
			qualityOfHorizontalMeasurement = instance.qualityOfHorizontalMeasurement;
			spatialAccuracy = new ();
			if (instance.spatialAccuracy != default) {
				spatialAccuracy.Load(instance.spatialAccuracy);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new SpatialQuality {
				qualityOfHorizontalMeasurement = this.qualityOfHorizontalMeasurement,
				spatialAccuracy = this.spatialAccuracy?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SpatialQuality Model => new () {
			qualityOfHorizontalMeasurement = this._qualityOfHorizontalMeasurement,
			spatialAccuracy = this._spatialAccuracy?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SpatialQuality.informationBindingDefinitions;

		public SpatialQualityViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Spatial Quality";
	}



	/// <summary>
	/// A prominent object at a fixed location on land which can be used in determining a location or a direction.
	/// </summary>
	[Description("A prominent object at a fixed location on land which can be used in determining a location or a direction.")]
	[CategoryOrder("Landmark",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LandmarkViewModel : FeatureViewModel<Landmark> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		[Description("Classification of prominent cultural and natural features in the landscape.")]
		[Category("Landmark")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
		[Multiplicity(1)]
		public ObservableCollection<categoryOfLandmark> categoryOfLandmark  { get; set; } = new ();

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("Landmark")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("Landmark")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Description("A specific role that describes a feature.")]
		[Category("Landmark")]
		[PermittedValues([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48])]
		[Optional]
		public ObservableCollection<function> function  { get; set; } = new ();

		[Description("The building's primary construction material.")]
		[Category("Landmark")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Description("A feature which returns a strong radar echo.")]
		[Category("Landmark")]
		//[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("Landmark")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private verticalDatum? _verticalDatum  = default;

		[Description("The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.")]
		[Category("Landmark")]
		//[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
		[Optional]
		public verticalDatum? verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		private visualProminence _visualProminence  = default;

		[Description("The extent to which a feature, either natural or artificial, is visible from seaward.")]
		[Category("Landmark")]
		//[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Mandatory]
		public visualProminence visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		private double? _elevation  = default;

		[Description("The altitude of the ground level of an object, measured from a specified vertical datum.")]
		[Category("Landmark")]
		//[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the object, measured from a specified vertical datum.")]
		[Category("Landmark")]
		//[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private Boolean? _mannedStructure  = default;

		[Description("An expression of the feature being permanently manned or not.")]
		[Category("Landmark")]
		//[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? mannedStructure {
			get {
				return _mannedStructure;
			}
			set {
				SetValue(ref _mannedStructure, value);
			}
		}

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("Landmark")]
		//[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("Landmark")]
		//[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public LandmarkViewModel Load(Landmark instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			categoryOfLandmark.Clear();
			if (instance.categoryOfLandmark is not null) {
				foreach(var e in instance.categoryOfLandmark)
					categoryOfLandmark.Add(e);
			}
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			function.Clear();
			if (instance.function is not null) {
				foreach(var e in instance.function)
					function.Add(e);
			}
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalDatum = instance.verticalDatum;
			visualProminence = instance.visualProminence;
			elevation = instance.elevation;
			height = instance.height;
			mannedStructure = instance.mannedStructure;
			verticalLength = instance.verticalLength;
			verticalAccuracy = instance.verticalAccuracy;
			return this;
		}

		public override string Serialize() {
			var instance = new Landmark {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
				categoryOfLandmark = this.categoryOfLandmark.ToList(),
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				function = this.function.ToList(),
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous,
				status = this.status.ToList(),
				verticalDatum = this.verticalDatum,
				visualProminence = this.visualProminence,
				elevation = this.elevation,
				height = this.height,
				mannedStructure = this.mannedStructure,
				verticalLength = this.verticalLength,
				verticalAccuracy = this.verticalAccuracy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Landmark Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
			categoryOfLandmark = this.categoryOfLandmark.ToList(),
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			function = this.function.ToList(),
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this._radarConspicuous,
			status = this.status.ToList(),
			verticalDatum = this._verticalDatum,
			visualProminence = this._visualProminence,
			elevation = this._elevation,
			height = this._height,
			mannedStructure = this._mannedStructure,
			verticalLength = this._verticalLength,
			verticalAccuracy = this._verticalAccuracy,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Landmark.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.Landmark.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Landmark.featureBindingDefinitions;

		public LandmarkViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public LandmarkViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Landmark";

		public LandmarkViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			categoryOfLandmark.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfLandmark));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			function.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(function));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A lateral beacon is used to indicate the port or starboard hand side of the route to be followed. They are generally used for well defined channels and are used in conjunction with a conventional direction of buoyage.
	/// </summary>
	[Description("A lateral beacon is used to indicate the port or starboard hand side of the route to be followed. They are generally used for well defined channels and are used in conjunction with a conventional direction of buoyage.")]
	[CategoryOrder("LateralBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LateralBeaconViewModel : FeatureViewModel<LateralBeacon> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private beaconShape _beaconShape  = default;

		[Description("Describes the characteristic geometric form of the beacon.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7])]
		[Mandatory]
		public beaconShape beaconShape {
			get {
				return _beaconShape;
			}
			set {
				SetValue(ref _beaconShape, value);
			}
		}

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		private double? _elevation  = default;

		[Description("The altitude of the ground level of an object, measured from a specified vertical datum.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the object, measured from a specified vertical datum.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,14,15])]
		[Optional]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Description("The building's primary construction material.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Description("A feature which returns a strong radar echo.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private visualProminence? _visualProminence  = default;

		[Description("The extent to which a feature, either natural or artificial, is visible from seaward.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public visualProminence? visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}

		private categoryOfLateralMark _categoryOfLateralMark  = default;

		[Description("Classification of lateral marks in the IALA Buoyage System.")]
		[Category("LateralBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<LateralBeacon>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Mandatory]
		public categoryOfLateralMark categoryOfLateralMark {
			get {
				return _categoryOfLateralMark;
			}
			set {
				SetValue(ref _categoryOfLateralMark, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public LateralBeaconViewModel Load(LateralBeacon instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			beaconShape = instance.beaconShape;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			elevation = instance.elevation;
			height = instance.height;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalLength = instance.verticalLength;
			visualProminence = instance.visualProminence;
			verticalAccuracy = instance.verticalAccuracy;
			categoryOfLateralMark = instance.categoryOfLateralMark;
			return this;
		}

		public override string Serialize() {
			var instance = new LateralBeacon {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
				beaconShape = this.beaconShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				elevation = this.elevation,
				height = this.height,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous,
				status = this.status.ToList(),
				verticalLength = this.verticalLength,
				visualProminence = this.visualProminence,
				verticalAccuracy = this.verticalAccuracy,
				categoryOfLateralMark = this.categoryOfLateralMark,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LateralBeacon Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
			beaconShape = this._beaconShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			elevation = this._elevation,
			height = this._height,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this._radarConspicuous,
			status = this.status.ToList(),
			verticalLength = this._verticalLength,
			visualProminence = this._visualProminence,
			verticalAccuracy = this._verticalAccuracy,
			categoryOfLateralMark = this._categoryOfLateralMark,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LateralBeacon.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.LateralBeacon.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LateralBeacon.featureBindingDefinitions;

		public LateralBeaconViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public LateralBeaconViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Lateral Beacon";

		public LateralBeaconViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A lateral buoy is used to indicate the port or starboard hand side of the route to be followed. They are generally used for well-defined channels and are used in conjunction with a conventional direction of buoyage.
	/// </summary>
	[Description("A lateral buoy is used to indicate the port or starboard hand side of the route to be followed. They are generally used for well-defined channels and are used in conjunction with a conventional direction of buoyage.")]
	[CategoryOrder("LateralBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LateralBuoyViewModel : FeatureViewModel<LateralBuoy> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private buoyShape _buoyShape  = default;

		[Description("The principal shape and/or design of a buoy.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8])]
		[Mandatory]
		public buoyShape buoyShape {
			get {
				return _buoyShape;
			}
			set {
				SetValue(ref _buoyShape, value);
			}
		}

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,14,15])]
		[Optional]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Description("The building's primary construction material.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Description("A feature which returns a strong radar echo.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private String? _typeOfBuoy  = default;

		[Description("Type equipment used as a buoy in a particular installation.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}

		private categoryOfLateralMark _categoryOfLateralMark  = default;

		[Description("Classification of lateral marks in the IALA Buoyage System.")]
		[Category("LateralBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<LateralBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Mandatory]
		public categoryOfLateralMark categoryOfLateralMark {
			get {
				return _categoryOfLateralMark;
			}
			set {
				SetValue(ref _categoryOfLateralMark, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public LateralBuoyViewModel Load(LateralBuoy instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			buoyShape = instance.buoyShape;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			typeOfBuoy = instance.typeOfBuoy;
			verticalLength = instance.verticalLength;
			verticalAccuracy = instance.verticalAccuracy;
			categoryOfLateralMark = instance.categoryOfLateralMark;
			return this;
		}

		public override string Serialize() {
			var instance = new LateralBuoy {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
				buoyShape = this.buoyShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous,
				status = this.status.ToList(),
				typeOfBuoy = this.typeOfBuoy,
				verticalLength = this.verticalLength,
				verticalAccuracy = this.verticalAccuracy,
				categoryOfLateralMark = this.categoryOfLateralMark,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LateralBuoy Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this._radarConspicuous,
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
			verticalLength = this._verticalLength,
			verticalAccuracy = this._verticalAccuracy,
			categoryOfLateralMark = this._categoryOfLateralMark,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LateralBuoy.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.LateralBuoy.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LateralBuoy.featureBindingDefinitions;

		public LateralBuoyViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public LateralBuoyViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Lateral Buoy";

		public LateralBuoyViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A straight line extending towards an area of navigational interest and generally generated by two navigational aids or one navigational aid and a bearing.
	/// </summary>
	[Description("A straight line extending towards an area of navigational interest and generally generated by two navigational aids or one navigational aid and a bearing.")]
	[CategoryOrder("NavigationLine",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NavigationLineViewModel : FeatureViewModel<NavigationLine> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private categoryOfNavigationLine _categoryOfNavigationLine  = default;

		[Description("Classification of route guidance given to vessels.")]
		[Category("NavigationLine")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationLine>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Mandatory]
		public categoryOfNavigationLine categoryOfNavigationLine {
			get {
				return _categoryOfNavigationLine;
			}
			set {
				SetValue(ref _categoryOfNavigationLine, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("NavigationLine")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private orientationViewModel _orientation  = default;

		[Description("(1) The angular distance measured from true north to the major axis of the feature. (2) In ECDIS, the mode in which information on the ECDIS is being presented. Typical modes include: north-up - as shown on a nautical chart, north is at the top of the display; Ships head-up - based on the actual heading of the ship, (e.g. Ships gyrocompass); course-up display - based on the course or route being taken.")]
		[Category("NavigationLine")]
		[ExpandableObject]
		[Mandatory]
		public orientationViewModel orientation {
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
		[FeatureBinding("RangeSystem","navigableTrack",["RecommendedTrack"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> RangeSystems { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. RangeSystems.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.RangeSystem> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public NavigationLineViewModel Load(NavigationLine instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			categoryOfNavigationLine = instance.categoryOfNavigationLine;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			orientation = new ();
			if (instance.orientation != default) {
				orientation.Load(instance.orientation);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new NavigationLine {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				categoryOfNavigationLine = this.categoryOfNavigationLine,
				status = this.status.ToList(),
				orientation = this.orientation?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public NavigationLine Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			categoryOfNavigationLine = this._categoryOfNavigationLine,
			status = this.status.ToList(),
			orientation = this._orientation?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.NavigationLine.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.NavigationLine.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.NavigationLine.featureBindingDefinitions;

		public NavigationLineViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public NavigationLineViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Navigation Line";

		public NavigationLineViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			RangeSystems.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(RangeSystems));
			};
		}
	}



	/// <summary>
	/// A route which has been specially examined to ensure so far as possible that it is free of dangers and along which ships are advised to navigate.
	/// </summary>
	[Description("A route which has been specially examined to ensure so far as possible that it is free of dangers and along which ships are advised to navigate.")]
	[CategoryOrder("RecommendedTrack",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RecommendedTrackViewModel : FeatureViewModel<RecommendedTrack> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private Boolean _basedOnFixedMarks  = false;

		[Description("A straight route (known as a recommended track, range or leading line), which comprises: a. at least two structures (usually beacons or daymarks) and/or natural features, which may carry lights and/or top-marks. The structures/features are positioned so that when observed to be in line, a vessel can follow a known bearing with safety. (Adapted from International Association of Marine Aids to Navigation and Lighthouse Authorities - IALA Aids to Navigation Guide, 1990); or b. a single structure or natural feature, which may carry lights and/or a topmark, and a specified bearing which can be followed with safety. (S-57 Edition 3.1, Appendix A Chapter 2, Page 2.72, November 2000, as amended).")]
		[Category("RecommendedTrack")]
		//[Editor(typeof(Editors.HorizonEditor<RecommendedTrack>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public Boolean basedOnFixedMarks {
			get {
				return _basedOnFixedMarks;
			}
			set {
				SetValue(ref _basedOnFixedMarks, value);
			}
		}

		private double? _depthRangeMinimumValue  = default;

		[Description("The minimum (shoalest) value of a depth range.")]
		[Category("RecommendedTrack")]
		//[Editor(typeof(Editors.HorizonEditor<RecommendedTrack>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? depthRangeMinimumValue {
			get {
				return _depthRangeMinimumValue;
			}
			set {
				SetValue(ref _depthRangeMinimumValue, value);
			}
		}

		private double? _maximalPermittedDraught  = default;

		[Description("The maximal permitted draught of a vessel or convoy according to the particular article/clause of the applicable law/regulation.")]
		[Category("RecommendedTrack")]
		//[Editor(typeof(Editors.HorizonEditor<RecommendedTrack>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? maximalPermittedDraught {
			get {
				return _maximalPermittedDraught;
			}
			set {
				SetValue(ref _maximalPermittedDraught, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("RecommendedTrack")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private verticalDatum? _verticalDatum  = default;

		[Description("The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.")]
		[Category("RecommendedTrack")]
		//[Editor(typeof(Editors.HorizonEditor<RecommendedTrack>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
		[Optional]
		public verticalDatum? verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		private orientationViewModel _orientation  = default;

		[Description("(1) The angular distance measured from true north to the major axis of the feature. (2) In ECDIS, the mode in which information on the ECDIS is being presented. Typical modes include: north-up - as shown on a nautical chart, north is at the top of the display; Ships head-up - based on the actual heading of the ship, (e.g. Ships gyrocompass); course-up display - based on the course or route being taken.")]
		[Category("RecommendedTrack")]
		[ExpandableObject]
		[Mandatory]
		public orientationViewModel orientation {
			get {
				return _orientation;
			}
			set {
				SetValue(ref _orientation, value);
			}
		}

		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Description("The best estimate of the vertical accuracy of depths, heights, vertical distances and vertical clearances.")]
		[Category("RecommendedTrack")]
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

		[Description("The reliability of the value of a sounding.")]
		[Category("RecommendedTrack")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11])]
		[Optional]
		public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement  { get; set; } = new ();

		[Description("Survey method used to obtain depth information.")]
		[Category("RecommendedTrack")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17])]
		[Optional]
		public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement  { get; set; } = new ();

		private trafficFlow _trafficFlow  = default;

		[Description("Direction of vessels passing a reference point.")]
		[Category("RecommendedTrack")]
		//[Editor(typeof(Editors.HorizonEditor<RecommendedTrack>), typeof(Editors.HorizonEditor))]
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
		[FeatureBinding("RangeSystem","navigationLine",["NavigationLine"], lower:1, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> RangeSystems { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. RangeSystems.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.RangeSystem> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public RecommendedTrackViewModel Load(RecommendedTrack instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			basedOnFixedMarks = instance.basedOnFixedMarks;
			depthRangeMinimumValue = instance.depthRangeMinimumValue;
			maximalPermittedDraught = instance.maximalPermittedDraught;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalDatum = instance.verticalDatum;
			orientation = new ();
			if (instance.orientation != default) {
				orientation.Load(instance.orientation);
			}
			verticalUncertainty = new ();
			if (instance.verticalUncertainty != default) {
				verticalUncertainty.Load(instance.verticalUncertainty);
			}
			qualityOfVerticalMeasurement.Clear();
			if (instance.qualityOfVerticalMeasurement is not null) {
				foreach(var e in instance.qualityOfVerticalMeasurement)
					qualityOfVerticalMeasurement.Add(e);
			}
			techniqueOfVerticalMeasurement.Clear();
			if (instance.techniqueOfVerticalMeasurement is not null) {
				foreach(var e in instance.techniqueOfVerticalMeasurement)
					techniqueOfVerticalMeasurement.Add(e);
			}
			trafficFlow = instance.trafficFlow;
			return this;
		}

		public override string Serialize() {
			var instance = new RecommendedTrack {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				basedOnFixedMarks = this.basedOnFixedMarks,
				depthRangeMinimumValue = this.depthRangeMinimumValue,
				maximalPermittedDraught = this.maximalPermittedDraught,
				status = this.status.ToList(),
				verticalDatum = this.verticalDatum,
				orientation = this.orientation?.Model,
				verticalUncertainty = this.verticalUncertainty?.Model,
				qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
				techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
				trafficFlow = this.trafficFlow,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RecommendedTrack Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			basedOnFixedMarks = this._basedOnFixedMarks,
			depthRangeMinimumValue = this._depthRangeMinimumValue,
			maximalPermittedDraught = this._maximalPermittedDraught,
			status = this.status.ToList(),
			verticalDatum = this._verticalDatum,
			orientation = this._orientation?.Model,
			verticalUncertainty = this._verticalUncertainty?.Model,
			qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
			techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
			trafficFlow = this._trafficFlow,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.RecommendedTrack.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.RecommendedTrack.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.RecommendedTrack.featureBindingDefinitions;

		public RecommendedTrackViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public RecommendedTrackViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Recommended Track";

		public RecommendedTrackViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			qualityOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(qualityOfVerticalMeasurement));
			};
			techniqueOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(techniqueOfVerticalMeasurement));
			};
			RangeSystems.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(RangeSystems));
			};
		}
	}



	/// <summary>
	/// A light presenting different appearances (in particular, different colours) over various parts of the horizon of interest to maritime navigation.
	/// </summary>
	[Description("A light presenting different appearances (in particular, different colours) over various parts of the horizon of interest to maritime navigation.")]
	[CategoryOrder("LightSectored",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LightSectoredViewModel : FeatureViewModel<LightSectored> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Description("Classification or name of system used to remotely monitor a feature.")]
		[Category("Equipment")]
		[Optional]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the object, measured from a specified vertical datum.")]
		[Category("GenericLight")]
		//[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericLight")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private verticalDatum? _verticalDatum  = default;

		[Description("The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.")]
		[Category("GenericLight")]
		//[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
		[Optional]
		public verticalDatum? verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("GenericLight")]
		//[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private double? _effectiveIntensity  = default;

		[Description("The luminous intensity of a fictitious juxtaposed steady-burning point light source that would appear to exhibit a luminosity equal to that of the rhythmic point light source it describes. The apparent reduction in intensity of the rhythmic light is subjective and is due to the nature of the response of the eye of the observer.")]
		[Category("GenericLight")]
		//[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? effectiveIntensity {
			get {
				return _effectiveIntensity;
			}
			set {
				SetValue(ref _effectiveIntensity, value);
			}
		}

		private double? _peakIntensity  = default;

		[Description("The maximum luminous intensity of a light during its flash cycle.")]
		[Category("GenericLight")]
		//[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? peakIntensity {
			get {
				return _peakIntensity;
			}
			set {
				SetValue(ref _peakIntensity, value);
			}
		}

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("LightSectored")]
		[PermittedValues([1,3,4,5,6,9,10,11,14,15,16,17,18,19,20])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("Classification of different light types.")]
		[Category("LightSectored")]
		[PermittedValues([1,4,5,6,8,9,10,11,12,13,14,15,17,18,19,20])]
		[Optional]
		public ObservableCollection<categoryOfLight> categoryOfLight  { get; set; } = new ();

		private exhibitionConditionOfLight? _exhibitionConditionOfLight  = default;

		[Description("The outward display of the light.")]
		[Category("LightSectored")]
		//[Editor(typeof(Editors.HorizonEditor<LightSectored>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Optional]
		public exhibitionConditionOfLight? exhibitionConditionOfLight {
			get {
				return _exhibitionConditionOfLight;
			}
			set {
				SetValue(ref _exhibitionConditionOfLight, value);
			}
		}

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("LightSectored")]
		//[Editor(typeof(Editors.HorizonEditor<LightSectored>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,14,15])]
		[Optional]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		private signalGeneration? _signalGeneration  = default;

		[Description("The mechanism used to generate a fog or light signal.")]
		[Category("LightSectored")]
		//[Editor(typeof(Editors.HorizonEditor<LightSectored>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6])]
		[Optional]
		public signalGeneration? signalGeneration {
			get {
				return _signalGeneration;
			}
			set {
				SetValue(ref _signalGeneration, value);
			}
		}

		[Description("-")]
		[Category("LightSectored")]
		[Optional]
		public ObservableCollection<ObscuredSectorViewModel> ObscuredSector  { get; set; } = new ();

		[Description("Describes the characteristics of a light sector.")]
		[Category("LightSectored")]
		[Multiplicity(1)]
		public ObservableCollection<sectorCharacteristicsViewModel> sectorCharacteristics  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public LightSectoredViewModel Load(LightSectored instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			remoteMonitoringSystem.Clear();
			if (instance.remoteMonitoringSystem is not null) {
				foreach(var e in instance.remoteMonitoringSystem)
					remoteMonitoringSystem.Add(e);
			}
			height = instance.height;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalDatum = instance.verticalDatum;
			verticalLength = instance.verticalLength;
			effectiveIntensity = instance.effectiveIntensity;
			peakIntensity = instance.peakIntensity;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			categoryOfLight.Clear();
			if (instance.categoryOfLight is not null) {
				foreach(var e in instance.categoryOfLight)
					categoryOfLight.Add(e);
			}
			exhibitionConditionOfLight = instance.exhibitionConditionOfLight;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			signalGeneration = instance.signalGeneration;
			ObscuredSector.Clear();
			if (instance.ObscuredSector is not null) {
				foreach(var e in instance.ObscuredSector)
					ObscuredSector.Add(new ObscuredSectorViewModel().Load(e));
			}
			sectorCharacteristics.Clear();
			if (instance.sectorCharacteristics is not null) {
				foreach(var e in instance.sectorCharacteristics)
					sectorCharacteristics.Add(new sectorCharacteristicsViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new LightSectored {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
				height = this.height,
				status = this.status.ToList(),
				verticalDatum = this.verticalDatum,
				verticalLength = this.verticalLength,
				effectiveIntensity = this.effectiveIntensity,
				peakIntensity = this.peakIntensity,
				colour = this.colour.ToList(),
				categoryOfLight = this.categoryOfLight.ToList(),
				exhibitionConditionOfLight = this.exhibitionConditionOfLight,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				signalGeneration = this.signalGeneration,
				ObscuredSector = this.ObscuredSector.Select(e => e.Model).ToList(),
				sectorCharacteristics = this.sectorCharacteristics.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LightSectored Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
			height = this._height,
			status = this.status.ToList(),
			verticalDatum = this._verticalDatum,
			verticalLength = this._verticalLength,
			effectiveIntensity = this._effectiveIntensity,
			peakIntensity = this._peakIntensity,
			colour = this.colour.ToList(),
			categoryOfLight = this.categoryOfLight.ToList(),
			exhibitionConditionOfLight = this._exhibitionConditionOfLight,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			signalGeneration = this._signalGeneration,
			ObscuredSector = this.ObscuredSector.Select(e => e.Model).ToList(),
			sectorCharacteristics = this.sectorCharacteristics.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LightSectored.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.LightSectored.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LightSectored.featureBindingDefinitions;

		public LightSectoredViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public LightSectoredViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Light Sectored";

		public LightSectoredViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			remoteMonitoringSystem.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(remoteMonitoringSystem));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			categoryOfLight.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfLight));
			};
			ObscuredSector.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(ObscuredSector));
			};
			sectorCharacteristics.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sectorCharacteristics));
			};
		}
	}



	/// <summary>
	/// An all around light is a light that is visible over the whole horizon of interest to marine navigation and having no change in the characteristics of the light.
	/// </summary>
	[Description("An all around light is a light that is visible over the whole horizon of interest to marine navigation and having no change in the characteristics of the light.")]
	[CategoryOrder("LightAllAround",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LightAllAroundViewModel : FeatureViewModel<LightAllAround> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Description("Classification or name of system used to remotely monitor a feature.")]
		[Category("Equipment")]
		[Optional]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the object, measured from a specified vertical datum.")]
		[Category("GenericLight")]
		//[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericLight")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private verticalDatum? _verticalDatum  = default;

		[Description("The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.")]
		[Category("GenericLight")]
		//[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
		[Optional]
		public verticalDatum? verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("GenericLight")]
		//[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private double? _effectiveIntensity  = default;

		[Description("The luminous intensity of a fictitious juxtaposed steady-burning point light source that would appear to exhibit a luminosity equal to that of the rhythmic point light source it describes. The apparent reduction in intensity of the rhythmic light is subjective and is due to the nature of the response of the eye of the observer.")]
		[Category("GenericLight")]
		//[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? effectiveIntensity {
			get {
				return _effectiveIntensity;
			}
			set {
				SetValue(ref _effectiveIntensity, value);
			}
		}

		private double? _peakIntensity  = default;

		[Description("The maximum luminous intensity of a light during its flash cycle.")]
		[Category("GenericLight")]
		//[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? peakIntensity {
			get {
				return _peakIntensity;
			}
			set {
				SetValue(ref _peakIntensity, value);
			}
		}

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("LightAllAround")]
		[PermittedValues([1,3,4,5,6,9,10,11,14,15,16,17,18,19,20])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("Classification of different light types.")]
		[Category("LightAllAround")]
		[PermittedValues([1,4,5,6,8,9,10,11,12,13,14,15,17,18,19,20])]
		[Optional]
		public ObservableCollection<categoryOfLight> categoryOfLight  { get; set; } = new ();

		private exhibitionConditionOfLight? _exhibitionConditionOfLight  = default;

		[Description("The outward display of the light.")]
		[Category("LightAllAround")]
		//[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Optional]
		public exhibitionConditionOfLight? exhibitionConditionOfLight {
			get {
				return _exhibitionConditionOfLight;
			}
			set {
				SetValue(ref _exhibitionConditionOfLight, value);
			}
		}

		private lightVisibility? _lightVisibility  = default;

		[Description("The specific visibility of a light, with respect to the light's intensity and ease of recognition.")]
		[Category("LightAllAround")]
		//[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public lightVisibility? lightVisibility {
			get {
				return _lightVisibility;
			}
			set {
				SetValue(ref _lightVisibility, value);
			}
		}

		private Boolean? _majorLight  = default;

		[Description("A statement expressing if a light is considered to be a major light in terms of ECDIS display in a particular area.")]
		[Category("LightAllAround")]
		//[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? majorLight {
			get {
				return _majorLight;
			}
			set {
				SetValue(ref _majorLight, value);
			}
		}

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("LightAllAround")]
		//[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,14,15])]
		[Optional]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		private signalGeneration? _signalGeneration  = default;

		[Description("The mechanism used to generate a fog or light signal.")]
		[Category("LightAllAround")]
		//[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6])]
		[Optional]
		public signalGeneration? signalGeneration {
			get {
				return _signalGeneration;
			}
			set {
				SetValue(ref _signalGeneration, value);
			}
		}

		private double? _valueOfNominalRange  = default;

		[Description("The luminous range of a light in a homogenous atmosphere in which the meteorological visibility is 10 sea miles.")]
		[Category("LightAllAround")]
		//[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? valueOfNominalRange {
			get {
				return _valueOfNominalRange;
			}
			set {
				SetValue(ref _valueOfNominalRange, value);
			}
		}

		private multiplicityOfFeaturesViewModel? _multiplicityOfFeatures  = default;

		[Description("The number of features of identical character that exist as a colocated group.")]
		[Category("LightAllAround")]
		[ExpandableObject]
		[Optional]
		public multiplicityOfFeaturesViewModel? multiplicityOfFeatures {
			get {
				return _multiplicityOfFeatures;
			}
			set {
				SetValue(ref _multiplicityOfFeatures, value);
			}
		}

		private rhythmOfLightViewModel _rhythmOfLight  = default;

		[Description("The sequence of times occupied by intervals of light/sound and eclipse/silence for all light characteristics or sound signals.")]
		[Category("LightAllAround")]
		[ExpandableObject]
		[Mandatory]
		public rhythmOfLightViewModel rhythmOfLight {
			get {
				return _rhythmOfLight;
			}
			set {
				SetValue(ref _rhythmOfLight, value);
			}
		}

		private int? _flareBearing  = default;

		[Description("The bearing about which the light flare symbol is rotated to be displayed in ECDIS.")]
		[Category("LightAllAround")]
		//[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? flareBearing {
			get {
				return _flareBearing;
			}
			set {
				SetValue(ref _flareBearing, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public LightAllAroundViewModel Load(LightAllAround instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			remoteMonitoringSystem.Clear();
			if (instance.remoteMonitoringSystem is not null) {
				foreach(var e in instance.remoteMonitoringSystem)
					remoteMonitoringSystem.Add(e);
			}
			height = instance.height;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalDatum = instance.verticalDatum;
			verticalLength = instance.verticalLength;
			effectiveIntensity = instance.effectiveIntensity;
			peakIntensity = instance.peakIntensity;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			categoryOfLight.Clear();
			if (instance.categoryOfLight is not null) {
				foreach(var e in instance.categoryOfLight)
					categoryOfLight.Add(e);
			}
			exhibitionConditionOfLight = instance.exhibitionConditionOfLight;
			lightVisibility = instance.lightVisibility;
			majorLight = instance.majorLight;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			signalGeneration = instance.signalGeneration;
			valueOfNominalRange = instance.valueOfNominalRange;
			multiplicityOfFeatures = new ();
			if (instance.multiplicityOfFeatures != default) {
				multiplicityOfFeatures.Load(instance.multiplicityOfFeatures);
			}
			rhythmOfLight = new ();
			if (instance.rhythmOfLight != default) {
				rhythmOfLight.Load(instance.rhythmOfLight);
			}
			flareBearing = instance.flareBearing;
			return this;
		}

		public override string Serialize() {
			var instance = new LightAllAround {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
				height = this.height,
				status = this.status.ToList(),
				verticalDatum = this.verticalDatum,
				verticalLength = this.verticalLength,
				effectiveIntensity = this.effectiveIntensity,
				peakIntensity = this.peakIntensity,
				colour = this.colour.ToList(),
				categoryOfLight = this.categoryOfLight.ToList(),
				exhibitionConditionOfLight = this.exhibitionConditionOfLight,
				lightVisibility = this.lightVisibility,
				majorLight = this.majorLight,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				signalGeneration = this.signalGeneration,
				valueOfNominalRange = this.valueOfNominalRange,
				multiplicityOfFeatures = this.multiplicityOfFeatures?.Model,
				rhythmOfLight = this.rhythmOfLight?.Model,
				flareBearing = this.flareBearing,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LightAllAround Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
			height = this._height,
			status = this.status.ToList(),
			verticalDatum = this._verticalDatum,
			verticalLength = this._verticalLength,
			effectiveIntensity = this._effectiveIntensity,
			peakIntensity = this._peakIntensity,
			colour = this.colour.ToList(),
			categoryOfLight = this.categoryOfLight.ToList(),
			exhibitionConditionOfLight = this._exhibitionConditionOfLight,
			lightVisibility = this._lightVisibility,
			majorLight = this._majorLight,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			signalGeneration = this._signalGeneration,
			valueOfNominalRange = this._valueOfNominalRange,
			multiplicityOfFeatures = this._multiplicityOfFeatures?.Model,
			rhythmOfLight = this._rhythmOfLight?.Model,
			flareBearing = this._flareBearing,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LightAllAround.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.LightAllAround.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LightAllAround.featureBindingDefinitions;

		public LightAllAroundViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public LightAllAroundViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Light All Around";

		public LightAllAroundViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			remoteMonitoringSystem.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(remoteMonitoringSystem));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			categoryOfLight.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfLight));
			};
		}
	}



	/// <summary>
	/// An air obstruction light is a light marking an obstacle which constitutes a danger to air navigation.
	/// </summary>
	[Description("An air obstruction light is a light marking an obstacle which constitutes a danger to air navigation.")]
	[CategoryOrder("LightAirObstruction",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LightAirObstructionViewModel : FeatureViewModel<LightAirObstruction> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Description("Classification or name of system used to remotely monitor a feature.")]
		[Category("Equipment")]
		[Optional]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the object, measured from a specified vertical datum.")]
		[Category("GenericLight")]
		//[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericLight")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private verticalDatum? _verticalDatum  = default;

		[Description("The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.")]
		[Category("GenericLight")]
		//[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
		[Optional]
		public verticalDatum? verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("GenericLight")]
		//[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private double? _effectiveIntensity  = default;

		[Description("The luminous intensity of a fictitious juxtaposed steady-burning point light source that would appear to exhibit a luminosity equal to that of the rhythmic point light source it describes. The apparent reduction in intensity of the rhythmic light is subjective and is due to the nature of the response of the eye of the observer.")]
		[Category("GenericLight")]
		//[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? effectiveIntensity {
			get {
				return _effectiveIntensity;
			}
			set {
				SetValue(ref _effectiveIntensity, value);
			}
		}

		private double? _peakIntensity  = default;

		[Description("The maximum luminous intensity of a light during its flash cycle.")]
		[Category("GenericLight")]
		//[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? peakIntensity {
			get {
				return _peakIntensity;
			}
			set {
				SetValue(ref _peakIntensity, value);
			}
		}

		[Description("The outward display of the light.")]
		[Category("LightAirObstruction")]
		[PermittedValues([1,2,3,4])]
		[Optional]
		public ObservableCollection<exhibitionConditionOfLight> exhibitionConditionOfLight  { get; set; } = new ();

		[Description("The specific visibility of a light, with respect to the light's intensity and ease of recognition.")]
		[Category("LightAirObstruction")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<lightVisibility> lightVisibility  { get; set; } = new ();

		private double? _valueOfNominalRange  = default;

		[Description("The luminous range of a light in a homogenous atmosphere in which the meteorological visibility is 10 sea miles.")]
		[Category("LightAirObstruction")]
		//[Editor(typeof(Editors.HorizonEditor<LightAirObstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? valueOfNominalRange {
			get {
				return _valueOfNominalRange;
			}
			set {
				SetValue(ref _valueOfNominalRange, value);
			}
		}

		private multiplicityOfFeaturesViewModel? _multiplicityOfFeatures  = default;

		[Description("The number of features of identical character that exist as a colocated group.")]
		[Category("LightAirObstruction")]
		[ExpandableObject]
		[Optional]
		public multiplicityOfFeaturesViewModel? multiplicityOfFeatures {
			get {
				return _multiplicityOfFeatures;
			}
			set {
				SetValue(ref _multiplicityOfFeatures, value);
			}
		}

		private rhythmOfLightViewModel _rhythmOfLight  = default;

		[Description("The sequence of times occupied by intervals of light/sound and eclipse/silence for all light characteristics or sound signals.")]
		[Category("LightAirObstruction")]
		[ExpandableObject]
		[Mandatory]
		public rhythmOfLightViewModel rhythmOfLight {
			get {
				return _rhythmOfLight;
			}
			set {
				SetValue(ref _rhythmOfLight, value);
			}
		}

		private int? _flareBearing  = default;

		[Description("The bearing about which the light flare symbol is rotated to be displayed in ECDIS.")]
		[Category("LightAirObstruction")]
		//[Editor(typeof(Editors.HorizonEditor<LightAirObstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? flareBearing {
			get {
				return _flareBearing;
			}
			set {
				SetValue(ref _flareBearing, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public LightAirObstructionViewModel Load(LightAirObstruction instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			remoteMonitoringSystem.Clear();
			if (instance.remoteMonitoringSystem is not null) {
				foreach(var e in instance.remoteMonitoringSystem)
					remoteMonitoringSystem.Add(e);
			}
			height = instance.height;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalDatum = instance.verticalDatum;
			verticalLength = instance.verticalLength;
			effectiveIntensity = instance.effectiveIntensity;
			peakIntensity = instance.peakIntensity;
			exhibitionConditionOfLight.Clear();
			if (instance.exhibitionConditionOfLight is not null) {
				foreach(var e in instance.exhibitionConditionOfLight)
					exhibitionConditionOfLight.Add(e);
			}
			lightVisibility.Clear();
			if (instance.lightVisibility is not null) {
				foreach(var e in instance.lightVisibility)
					lightVisibility.Add(e);
			}
			valueOfNominalRange = instance.valueOfNominalRange;
			multiplicityOfFeatures = new ();
			if (instance.multiplicityOfFeatures != default) {
				multiplicityOfFeatures.Load(instance.multiplicityOfFeatures);
			}
			rhythmOfLight = new ();
			if (instance.rhythmOfLight != default) {
				rhythmOfLight.Load(instance.rhythmOfLight);
			}
			flareBearing = instance.flareBearing;
			return this;
		}

		public override string Serialize() {
			var instance = new LightAirObstruction {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
				height = this.height,
				status = this.status.ToList(),
				verticalDatum = this.verticalDatum,
				verticalLength = this.verticalLength,
				effectiveIntensity = this.effectiveIntensity,
				peakIntensity = this.peakIntensity,
				exhibitionConditionOfLight = this.exhibitionConditionOfLight.ToList(),
				lightVisibility = this.lightVisibility.ToList(),
				valueOfNominalRange = this.valueOfNominalRange,
				multiplicityOfFeatures = this.multiplicityOfFeatures?.Model,
				rhythmOfLight = this.rhythmOfLight?.Model,
				flareBearing = this.flareBearing,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LightAirObstruction Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
			height = this._height,
			status = this.status.ToList(),
			verticalDatum = this._verticalDatum,
			verticalLength = this._verticalLength,
			effectiveIntensity = this._effectiveIntensity,
			peakIntensity = this._peakIntensity,
			exhibitionConditionOfLight = this.exhibitionConditionOfLight.ToList(),
			lightVisibility = this.lightVisibility.ToList(),
			valueOfNominalRange = this._valueOfNominalRange,
			multiplicityOfFeatures = this._multiplicityOfFeatures?.Model,
			rhythmOfLight = this._rhythmOfLight?.Model,
			flareBearing = this._flareBearing,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LightAirObstruction.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.LightAirObstruction.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LightAirObstruction.featureBindingDefinitions;

		public LightAirObstructionViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public LightAirObstructionViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Light Air Obstruction";

		public LightAirObstructionViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			remoteMonitoringSystem.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(remoteMonitoringSystem));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			exhibitionConditionOfLight.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(exhibitionConditionOfLight));
			};
			lightVisibility.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(lightVisibility));
			};
		}
	}



	/// <summary>
	/// A fog detector light is a light used to automatically determine conditions of visibility which warrant the turning on or off of a sound signal.
	/// </summary>
	[Description("A fog detector light is a light used to automatically determine conditions of visibility which warrant the turning on or off of a sound signal.")]
	[CategoryOrder("LightFogDetector",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LightFogDetectorViewModel : FeatureViewModel<LightFogDetector> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Description("Classification or name of system used to remotely monitor a feature.")]
		[Category("Equipment")]
		[Optional]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the object, measured from a specified vertical datum.")]
		[Category("GenericLight")]
		//[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericLight")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private verticalDatum? _verticalDatum  = default;

		[Description("The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.")]
		[Category("GenericLight")]
		//[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
		[Optional]
		public verticalDatum? verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("GenericLight")]
		//[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private double? _effectiveIntensity  = default;

		[Description("The luminous intensity of a fictitious juxtaposed steady-burning point light source that would appear to exhibit a luminosity equal to that of the rhythmic point light source it describes. The apparent reduction in intensity of the rhythmic light is subjective and is due to the nature of the response of the eye of the observer.")]
		[Category("GenericLight")]
		//[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? effectiveIntensity {
			get {
				return _effectiveIntensity;
			}
			set {
				SetValue(ref _effectiveIntensity, value);
			}
		}

		private double? _peakIntensity  = default;

		[Description("The maximum luminous intensity of a light during its flash cycle.")]
		[Category("GenericLight")]
		//[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? peakIntensity {
			get {
				return _peakIntensity;
			}
			set {
				SetValue(ref _peakIntensity, value);
			}
		}

		private signalGeneration? _signalGeneration  = default;

		[Description("The mechanism used to generate a fog or light signal.")]
		[Category("LightFogDetector")]
		//[Editor(typeof(Editors.HorizonEditor<LightFogDetector>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6])]
		[Optional]
		public signalGeneration? signalGeneration {
			get {
				return _signalGeneration;
			}
			set {
				SetValue(ref _signalGeneration, value);
			}
		}

		private rhythmOfLightViewModel _rhythmOfLight  = default;

		[Description("The sequence of times occupied by intervals of light/sound and eclipse/silence for all light characteristics or sound signals.")]
		[Category("LightFogDetector")]
		[ExpandableObject]
		[Mandatory]
		public rhythmOfLightViewModel rhythmOfLight {
			get {
				return _rhythmOfLight;
			}
			set {
				SetValue(ref _rhythmOfLight, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public LightFogDetectorViewModel Load(LightFogDetector instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			remoteMonitoringSystem.Clear();
			if (instance.remoteMonitoringSystem is not null) {
				foreach(var e in instance.remoteMonitoringSystem)
					remoteMonitoringSystem.Add(e);
			}
			height = instance.height;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalDatum = instance.verticalDatum;
			verticalLength = instance.verticalLength;
			effectiveIntensity = instance.effectiveIntensity;
			peakIntensity = instance.peakIntensity;
			signalGeneration = instance.signalGeneration;
			rhythmOfLight = new ();
			if (instance.rhythmOfLight != default) {
				rhythmOfLight.Load(instance.rhythmOfLight);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new LightFogDetector {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
				height = this.height,
				status = this.status.ToList(),
				verticalDatum = this.verticalDatum,
				verticalLength = this.verticalLength,
				effectiveIntensity = this.effectiveIntensity,
				peakIntensity = this.peakIntensity,
				signalGeneration = this.signalGeneration,
				rhythmOfLight = this.rhythmOfLight?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LightFogDetector Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
			height = this._height,
			status = this.status.ToList(),
			verticalDatum = this._verticalDatum,
			verticalLength = this._verticalLength,
			effectiveIntensity = this._effectiveIntensity,
			peakIntensity = this._peakIntensity,
			signalGeneration = this._signalGeneration,
			rhythmOfLight = this._rhythmOfLight?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LightFogDetector.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.LightFogDetector.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LightFogDetector.featureBindingDefinitions;

		public LightFogDetectorViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public LightFogDetectorViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Light Fog Detector";

		public LightFogDetectorViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			remoteMonitoringSystem.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(remoteMonitoringSystem));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A device capable of, or intended for, reflecting radar signals.
	/// </summary>
	[Description("A device capable of, or intended for, reflecting radar signals.")]
	[CategoryOrder("RadarReflector",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadarReflectorViewModel : FeatureViewModel<RadarReflector> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Description("Classification or name of system used to remotely monitor a feature.")]
		[Category("Equipment")]
		[Optional]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the object, measured from a specified vertical datum.")]
		[Category("RadarReflector")]
		//[Editor(typeof(Editors.HorizonEditor<RadarReflector>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("RadarReflector")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private verticalDatum? _verticalDatum  = default;

		[Description("The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.")]
		[Category("RadarReflector")]
		//[Editor(typeof(Editors.HorizonEditor<RadarReflector>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
		[Optional]
		public verticalDatum? verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("RadarReflector")]
		//[Editor(typeof(Editors.HorizonEditor<RadarReflector>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public RadarReflectorViewModel Load(RadarReflector instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			remoteMonitoringSystem.Clear();
			if (instance.remoteMonitoringSystem is not null) {
				foreach(var e in instance.remoteMonitoringSystem)
					remoteMonitoringSystem.Add(e);
			}
			height = instance.height;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalDatum = instance.verticalDatum;
			verticalAccuracy = instance.verticalAccuracy;
			return this;
		}

		public override string Serialize() {
			var instance = new RadarReflector {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
				height = this.height,
				status = this.status.ToList(),
				verticalDatum = this.verticalDatum,
				verticalAccuracy = this.verticalAccuracy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RadarReflector Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
			height = this._height,
			status = this.status.ToList(),
			verticalDatum = this._verticalDatum,
			verticalAccuracy = this._verticalAccuracy,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.RadarReflector.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.RadarReflector.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.RadarReflector.featureBindingDefinitions;

		public RadarReflectorViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public RadarReflectorViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Radar Reflector";

		public RadarReflectorViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			remoteMonitoringSystem.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(remoteMonitoringSystem));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A warning signal transmitted by a vessel, or aid to navigation, during periods of low visibility. Also, the device producing such a signal.
	/// </summary>
	[Description("A warning signal transmitted by a vessel, or aid to navigation, during periods of low visibility. Also, the device producing such a signal.")]
	[CategoryOrder("FogSignal",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class FogSignalViewModel : FeatureViewModel<FogSignal> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Description("Classification or name of system used to remotely monitor a feature.")]
		[Category("Equipment")]
		[Optional]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		private categoryOfFogSignal _categoryOfFogSignal  = default;

		[Description("Classification of the various means of generating the fog signal.")]
		[Category("FogSignal")]
		//[Editor(typeof(Editors.HorizonEditor<FogSignal>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10])]
		[Mandatory]
		public categoryOfFogSignal categoryOfFogSignal {
			get {
				return _categoryOfFogSignal;
			}
			set {
				SetValue(ref _categoryOfFogSignal, value);
			}
		}

		private int? _signalFrequency  = default;

		[Description("The frequency of a signal.")]
		[Category("FogSignal")]
		//[Editor(typeof(Editors.HorizonEditor<FogSignal>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? signalFrequency {
			get {
				return _signalFrequency;
			}
			set {
				SetValue(ref _signalFrequency, value);
			}
		}

		private signalGeneration? _signalGeneration  = default;

		[Description("The mechanism used to generate a fog or light signal.")]
		[Category("FogSignal")]
		//[Editor(typeof(Editors.HorizonEditor<FogSignal>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6])]
		[Optional]
		public signalGeneration? signalGeneration {
			get {
				return _signalGeneration;
			}
			set {
				SetValue(ref _signalGeneration, value);
			}
		}

		private String? _signalGroup  = default;

		[Description("The number of signals, the combination of signals or the morse character(s) within one period of full sequence.")]
		[Category("FogSignal")]
		//[Editor(typeof(Editors.HorizonEditor<FogSignal>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? signalGroup {
			get {
				return _signalGroup;
			}
			set {
				SetValue(ref _signalGroup, value);
			}
		}

		private double? _signalOutput  = default;

		[Description("Strength of signal output.")]
		[Category("FogSignal")]
		//[Editor(typeof(Editors.HorizonEditor<FogSignal>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? signalOutput {
			get {
				return _signalOutput;
			}
			set {
				SetValue(ref _signalOutput, value);
			}
		}

		private double? _signalPeriod  = default;

		[Description("The time occupied by an entire cycle of intervals of light and eclipse.")]
		[Category("FogSignal")]
		//[Editor(typeof(Editors.HorizonEditor<FogSignal>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? signalPeriod {
			get {
				return _signalPeriod;
			}
			set {
				SetValue(ref _signalPeriod, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("FogSignal")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private double? _valueOfMaximumRange  = default;

		[Description("The extreme distance at which an feature can be seen or a signal detected.")]
		[Category("FogSignal")]
		//[Editor(typeof(Editors.HorizonEditor<FogSignal>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? valueOfMaximumRange {
			get {
				return _valueOfMaximumRange;
			}
			set {
				SetValue(ref _valueOfMaximumRange, value);
			}
		}

		private signalSequenceViewModel? _signalSequence  = default;

		[Description("The sequence of times occupied by intervals of light and eclipse for all light characteristics.")]
		[Category("FogSignal")]
		[ExpandableObject]
		[Optional]
		public signalSequenceViewModel? signalSequence {
			get {
				return _signalSequence;
			}
			set {
				SetValue(ref _signalSequence, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public FogSignalViewModel Load(FogSignal instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			remoteMonitoringSystem.Clear();
			if (instance.remoteMonitoringSystem is not null) {
				foreach(var e in instance.remoteMonitoringSystem)
					remoteMonitoringSystem.Add(e);
			}
			categoryOfFogSignal = instance.categoryOfFogSignal;
			signalFrequency = instance.signalFrequency;
			signalGeneration = instance.signalGeneration;
			signalGroup = instance.signalGroup;
			signalOutput = instance.signalOutput;
			signalPeriod = instance.signalPeriod;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			valueOfMaximumRange = instance.valueOfMaximumRange;
			signalSequence = new ();
			if (instance.signalSequence != default) {
				signalSequence.Load(instance.signalSequence);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new FogSignal {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
				categoryOfFogSignal = this.categoryOfFogSignal,
				signalFrequency = this.signalFrequency,
				signalGeneration = this.signalGeneration,
				signalGroup = this.signalGroup,
				signalOutput = this.signalOutput,
				signalPeriod = this.signalPeriod,
				status = this.status.ToList(),
				valueOfMaximumRange = this.valueOfMaximumRange,
				signalSequence = this.signalSequence?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public FogSignal Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
			categoryOfFogSignal = this._categoryOfFogSignal,
			signalFrequency = this._signalFrequency,
			signalGeneration = this._signalGeneration,
			signalGroup = this._signalGroup,
			signalOutput = this._signalOutput,
			signalPeriod = this._signalPeriod,
			status = this.status.ToList(),
			valueOfMaximumRange = this._valueOfMaximumRange,
			signalSequence = this._signalSequence?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.FogSignal.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.FogSignal.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.FogSignal.featureBindingDefinitions;

		public FogSignalViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public FogSignalViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Fog Signal";

		public FogSignalViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			remoteMonitoringSystem.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(remoteMonitoringSystem));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A sensor used to observe the environment.
	/// </summary>
	[Description("A sensor used to observe the environment.")]
	[CategoryOrder("EnvironmentObservationEquipment",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class EnvironmentObservationEquipmentViewModel : FeatureViewModel<EnvironmentObservationEquipment> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Description("Classification or name of system used to remotely monitor a feature.")]
		[Category("Equipment")]
		[Optional]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the object, measured from a specified vertical datum.")]
		[Category("EnvironmentObservationEquipment")]
		//[Editor(typeof(Editors.HorizonEditor<EnvironmentObservationEquipment>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("EnvironmentObservationEquipment")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Description("Type of sensor used to observe the environment. For example Anemometer, fog monitor, etc.")]
		[Category("EnvironmentObservationEquipment")]
		[Multiplicity(1)]
		public ObservableCollection<String> typeOfEnvironmentalObservationEquipment  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public EnvironmentObservationEquipmentViewModel Load(EnvironmentObservationEquipment instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			remoteMonitoringSystem.Clear();
			if (instance.remoteMonitoringSystem is not null) {
				foreach(var e in instance.remoteMonitoringSystem)
					remoteMonitoringSystem.Add(e);
			}
			height = instance.height;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			typeOfEnvironmentalObservationEquipment.Clear();
			if (instance.typeOfEnvironmentalObservationEquipment is not null) {
				foreach(var e in instance.typeOfEnvironmentalObservationEquipment)
					typeOfEnvironmentalObservationEquipment.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new EnvironmentObservationEquipment {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
				height = this.height,
				status = this.status.ToList(),
				typeOfEnvironmentalObservationEquipment = this.typeOfEnvironmentalObservationEquipment.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public EnvironmentObservationEquipment Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
			height = this._height,
			status = this.status.ToList(),
			typeOfEnvironmentalObservationEquipment = this.typeOfEnvironmentalObservationEquipment.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.EnvironmentObservationEquipment.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.EnvironmentObservationEquipment.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.EnvironmentObservationEquipment.featureBindingDefinitions;

		public EnvironmentObservationEquipmentViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public EnvironmentObservationEquipmentViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Environment Observation Equipment";

		public EnvironmentObservationEquipmentViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			remoteMonitoringSystem.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(remoteMonitoringSystem));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			typeOfEnvironmentalObservationEquipment.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(typeOfEnvironmentalObservationEquipment));
			};
		}
	}



	/// <summary>
	/// A place equipped to transmit radio waves. Such a station may be either stationary or mobile, and may also be provided with a radio receiver.
	/// </summary>
	[Description("A place equipped to transmit radio waves. Such a station may be either stationary or mobile, and may also be provided with a radio receiver.")]
	[CategoryOrder("RadioStation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadioStationViewModel : FeatureViewModel<RadioStation> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Description("Classification or name of system used to remotely monitor a feature.")]
		[Category("Equipment")]
		[Optional]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		private categoryOfRadioStation _categoryOfRadioStation  = default;

		[Description("Classification of radio services offered by a radio station.")]
		[Category("RadioStation")]
		//[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,19,20])]
		[Mandatory]
		public categoryOfRadioStation categoryOfRadioStation {
			get {
				return _categoryOfRadioStation;
			}
			set {
				SetValue(ref _categoryOfRadioStation, value);
			}
		}

		private double? _estimatedRangeOfTransmission  = default;

		[Description("The estimated range of a non-optical electromagnetic transmission.")]
		[Category("RadioStation")]
		//[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? estimatedRangeOfTransmission {
			get {
				return _estimatedRangeOfTransmission;
			}
			set {
				SetValue(ref _estimatedRangeOfTransmission, value);
			}
		}

		private status? _status  = default;

		[Description("The condition of an object at a given instant in time.")]
		[Category("RadioStation")]
		//[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
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


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("PhysicalAIS","physicalAISbroadcastBy",["PhysicalAISAidToNavigation"], lower:0, upper:1)]
		public ObservableCollection<FeatureRefViewModel> PhysicalAIS { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("SyntheticAIS","syntheticAISbroadcastBy",["SyntheticAISAidToNavigation"], lower:0, upper:1)]
		public ObservableCollection<FeatureRefViewModel> SyntheticAIS { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("VirtualAIS","virtualAISbroadcastBy",["VirtualAISAidToNavigation"], lower:0, upper:1)]
		public ObservableCollection<FeatureRefViewModel> VirtualAIS { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. PhysicalAIS.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.PhysicalAIS> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. SyntheticAIS.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.SyntheticAIS> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. VirtualAIS.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.VirtualAIS> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public RadioStationViewModel Load(RadioStation instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			remoteMonitoringSystem.Clear();
			if (instance.remoteMonitoringSystem is not null) {
				foreach(var e in instance.remoteMonitoringSystem)
					remoteMonitoringSystem.Add(e);
			}
			categoryOfRadioStation = instance.categoryOfRadioStation;
			estimatedRangeOfTransmission = instance.estimatedRangeOfTransmission;
			status = instance.status;
			return this;
		}

		public override string Serialize() {
			var instance = new RadioStation {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
				categoryOfRadioStation = this.categoryOfRadioStation,
				estimatedRangeOfTransmission = this.estimatedRangeOfTransmission,
				status = this.status,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RadioStation Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
			categoryOfRadioStation = this._categoryOfRadioStation,
			estimatedRangeOfTransmission = this._estimatedRangeOfTransmission,
			status = this._status,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.RadioStation.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.RadioStation.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.RadioStation.featureBindingDefinitions;

		public RadioStationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public RadioStationViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Radio Station";

		public RadioStationViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			remoteMonitoringSystem.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(remoteMonitoringSystem));
			};
			PhysicalAIS.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(PhysicalAIS));
			};
			SyntheticAIS.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(SyntheticAIS));
			};
			VirtualAIS.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(VirtualAIS));
			};
		}
	}



	/// <summary>
	/// (1) The identifying characteristics of an aid to navigation which serve to facilitate its recognition against a daylight viewing background. On those structures that do not by themselves present an adequate viewing area to be seen at the required distance, the aid is made more visible by affixing a daymark to the structure. A daymark so affixed has a distinctive colour and shape depending on the purpose of the aid. (2) An unlighted navigational mark.
	/// </summary>
	[Description("(1) The identifying characteristics of an aid to navigation which serve to facilitate its recognition against a daylight viewing background. On those structures that do not by themselves present an adequate viewing area to be seen at the required distance, the aid is made more visible by affixing a daymark to the structure. A daymark so affixed has a distinctive colour and shape depending on the purpose of the aid. (2) An unlighted navigational mark.")]
	[CategoryOrder("Daymark",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DaymarkViewModel : FeatureViewModel<Daymark> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Description("Classification or name of system used to remotely monitor a feature.")]
		[Category("Equipment")]
		[Optional]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		private categoryOfSpecialPurposeMark? _categoryOfSpecialPurposeMark  = default;

		[Description("Classification of an aid to navigation which signifies some special purpose.")]
		[Category("Daymark")]
		//[Editor(typeof(Editors.HorizonEditor<Daymark>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67])]
		[Optional]
		public categoryOfSpecialPurposeMark? categoryOfSpecialPurposeMark {
			get {
				return _categoryOfSpecialPurposeMark;
			}
			set {
				SetValue(ref _categoryOfSpecialPurposeMark, value);
			}
		}

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("Daymark")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("Daymark")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		private double? _elevation  = default;

		[Description("The altitude of the ground level of an object, measured from a specified vertical datum.")]
		[Category("Daymark")]
		//[Editor(typeof(Editors.HorizonEditor<Daymark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the object, measured from a specified vertical datum.")]
		[Category("Daymark")]
		//[Editor(typeof(Editors.HorizonEditor<Daymark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		[Description("The building's primary construction material.")]
		[Category("Daymark")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		private double? _orientationValue  = default;

		[Description("The angular distance measured from true north to the major axis of the feature.")]
		[Category("Daymark")]
		//[Editor(typeof(Editors.HorizonEditor<Daymark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? orientationValue {
			get {
				return _orientationValue;
			}
			set {
				SetValue(ref _orientationValue, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("Daymark")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private topmarkDaymarkShape _topmarkDaymarkShape  = default;

		[Description("The shape a topmark or daymark exhibits.")]
		[Category("Daymark")]
		//[Editor(typeof(Editors.HorizonEditor<Daymark>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34])]
		[Mandatory]
		public topmarkDaymarkShape topmarkDaymarkShape {
			get {
				return _topmarkDaymarkShape;
			}
			set {
				SetValue(ref _topmarkDaymarkShape, value);
			}
		}

		private verticalDatum? _verticalDatum  = default;

		[Description("The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.")]
		[Category("Daymark")]
		//[Editor(typeof(Editors.HorizonEditor<Daymark>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
		[Optional]
		public verticalDatum? verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("Daymark")]
		//[Editor(typeof(Editors.HorizonEditor<Daymark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private shapeInformationViewModel? _shapeInformation  = default;

		[Description("Textual information about the shape of a non-standard topmark.")]
		[Category("Daymark")]
		[ExpandableObject]
		[Optional]
		public shapeInformationViewModel? shapeInformation {
			get {
				return _shapeInformation;
			}
			set {
				SetValue(ref _shapeInformation, value);
			}
		}

		private Boolean _isSlatted  = false;

		[Description("-")]
		[Category("Daymark")]
		//[Editor(typeof(Editors.HorizonEditor<Daymark>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public Boolean isSlatted {
			get {
				return _isSlatted;
			}
			set {
				SetValue(ref _isSlatted, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public DaymarkViewModel Load(Daymark instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			remoteMonitoringSystem.Clear();
			if (instance.remoteMonitoringSystem is not null) {
				foreach(var e in instance.remoteMonitoringSystem)
					remoteMonitoringSystem.Add(e);
			}
			categoryOfSpecialPurposeMark = instance.categoryOfSpecialPurposeMark;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			elevation = instance.elevation;
			height = instance.height;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			orientationValue = instance.orientationValue;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			topmarkDaymarkShape = instance.topmarkDaymarkShape;
			verticalDatum = instance.verticalDatum;
			verticalLength = instance.verticalLength;
			shapeInformation = new ();
			if (instance.shapeInformation != default) {
				shapeInformation.Load(instance.shapeInformation);
			}
			isSlatted = instance.isSlatted;
			return this;
		}

		public override string Serialize() {
			var instance = new Daymark {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
				categoryOfSpecialPurposeMark = this.categoryOfSpecialPurposeMark,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				elevation = this.elevation,
				height = this.height,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				orientationValue = this.orientationValue,
				status = this.status.ToList(),
				topmarkDaymarkShape = this.topmarkDaymarkShape,
				verticalDatum = this.verticalDatum,
				verticalLength = this.verticalLength,
				shapeInformation = this.shapeInformation?.Model,
				isSlatted = this.isSlatted,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Daymark Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
			categoryOfSpecialPurposeMark = this._categoryOfSpecialPurposeMark,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			elevation = this._elevation,
			height = this._height,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			orientationValue = this._orientationValue,
			status = this.status.ToList(),
			topmarkDaymarkShape = this._topmarkDaymarkShape,
			verticalDatum = this._verticalDatum,
			verticalLength = this._verticalLength,
			shapeInformation = this._shapeInformation?.Model,
			isSlatted = this._isSlatted,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Daymark.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.Daymark.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Daymark.featureBindingDefinitions;

		public DaymarkViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public DaymarkViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Daymark";

		public DaymarkViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			remoteMonitoringSystem.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(remoteMonitoringSystem));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A means of distinguishing unlighted marks at night. Retro-reflective material is secured to the mark in a particular pattern to reflect back light.
	/// </summary>
	[Description("A means of distinguishing unlighted marks at night. Retro-reflective material is secured to the mark in a particular pattern to reflect back light.")]
	[CategoryOrder("Retroreflector",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RetroreflectorViewModel : FeatureViewModel<Retroreflector> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Description("Classification or name of system used to remotely monitor a feature.")]
		[Category("Equipment")]
		[Optional]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("Retroreflector")]
		[PermittedValues([1,3,4,5,6,7,8,9,10,11,12,13])]
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("Retroreflector")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("Retroreflector")]
		//[Editor(typeof(Editors.HorizonEditor<Retroreflector>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,14,15])]
		[Optional]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("Retroreflector")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private verticalDatum? _verticalDatum  = default;

		[Description("The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.")]
		[Category("Retroreflector")]
		//[Editor(typeof(Editors.HorizonEditor<Retroreflector>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
		[Optional]
		public verticalDatum? verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the object, measured from a specified vertical datum.")]
		[Category("Retroreflector")]
		//[Editor(typeof(Editors.HorizonEditor<Retroreflector>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("Retroreflector")]
		//[Editor(typeof(Editors.HorizonEditor<Retroreflector>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public RetroreflectorViewModel Load(Retroreflector instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			remoteMonitoringSystem.Clear();
			if (instance.remoteMonitoringSystem is not null) {
				foreach(var e in instance.remoteMonitoringSystem)
					remoteMonitoringSystem.Add(e);
			}
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalDatum = instance.verticalDatum;
			height = instance.height;
			verticalAccuracy = instance.verticalAccuracy;
			return this;
		}

		public override string Serialize() {
			var instance = new Retroreflector {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				status = this.status.ToList(),
				verticalDatum = this.verticalDatum,
				height = this.height,
				verticalAccuracy = this.verticalAccuracy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Retroreflector Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			status = this.status.ToList(),
			verticalDatum = this._verticalDatum,
			height = this._height,
			verticalAccuracy = this._verticalAccuracy,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Retroreflector.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.Retroreflector.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Retroreflector.featureBindingDefinitions;

		public RetroreflectorViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public RetroreflectorViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Retroreflector";

		public RetroreflectorViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			remoteMonitoringSystem.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(remoteMonitoringSystem));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A transponder beacon transmitting a coded signal on radar frequency, permitting an interrogating craft to determine the bearing and range of the transponder.
	/// </summary>
	[Description("A transponder beacon transmitting a coded signal on radar frequency, permitting an interrogating craft to determine the bearing and range of the transponder.")]
	[CategoryOrder("RadarTransponderBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadarTransponderBeaconViewModel : FeatureViewModel<RadarTransponderBeacon> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Description("Classification or name of system used to remotely monitor a feature.")]
		[Category("Equipment")]
		[Optional]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		private categoryOfRadarTransponderBeacon _categoryOfRadarTransponderBeacon  = default;

		[Description("Classification of radar transponder beacon based on functionality.")]
		[Category("RadarTransponderBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<RadarTransponderBeacon>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Mandatory]
		public categoryOfRadarTransponderBeacon categoryOfRadarTransponderBeacon {
			get {
				return _categoryOfRadarTransponderBeacon;
			}
			set {
				SetValue(ref _categoryOfRadarTransponderBeacon, value);
			}
		}

		private radarWaveLengthViewModel? _radarWaveLength  = default;

		[Description("The distance between two successive peaks (or other points of identical phase) on an electromagnetic wave in the radar band of the electromagnetic spectrum.")]
		[Category("RadarTransponderBeacon")]
		[ExpandableObject]
		[Optional]
		public radarWaveLengthViewModel? radarWaveLength {
			get {
				return _radarWaveLength;
			}
			set {
				SetValue(ref _radarWaveLength, value);
			}
		}

		private String? _signalGroup  = default;

		[Description("The number of signals, the combination of signals or the morse character(s) within one period of full sequence.")]
		[Category("RadarTransponderBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<RadarTransponderBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? signalGroup {
			get {
				return _signalGroup;
			}
			set {
				SetValue(ref _signalGroup, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("RadarTransponderBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private double? _valueOfNominalRange  = default;

		[Description("The luminous range of a light in a homogenous atmosphere in which the meteorological visibility is 10 sea miles.")]
		[Category("RadarTransponderBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<RadarTransponderBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? valueOfNominalRange {
			get {
				return _valueOfNominalRange;
			}
			set {
				SetValue(ref _valueOfNominalRange, value);
			}
		}

		private String? _manufactorer  = default;

		[Description("-")]
		[Category("RadarTransponderBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<RadarTransponderBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? manufactorer {
			get {
				return _manufactorer;
			}
			set {
				SetValue(ref _manufactorer, value);
			}
		}

		private sectorLimitOneViewModel? _sectorLimitOne  = default;

		[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit one specifies the first limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).")]
		[Category("RadarTransponderBeacon")]
		[ExpandableObject]
		[Optional]
		public sectorLimitOneViewModel? sectorLimitOne {
			get {
				return _sectorLimitOne;
			}
			set {
				SetValue(ref _sectorLimitOne, value);
			}
		}

		private sectorLimitTwoViewModel? _sectorLimitTwo  = default;

		[Description("A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit two specifies the second limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).")]
		[Category("RadarTransponderBeacon")]
		[ExpandableObject]
		[Optional]
		public sectorLimitTwoViewModel? sectorLimitTwo {
			get {
				return _sectorLimitTwo;
			}
			set {
				SetValue(ref _sectorLimitTwo, value);
			}
		}

		private signalSequenceViewModel? _signalSequence  = default;

		[Description("The sequence of times occupied by intervals of light and eclipse for all light characteristics.")]
		[Category("RadarTransponderBeacon")]
		[ExpandableObject]
		[Optional]
		public signalSequenceViewModel? signalSequence {
			get {
				return _signalSequence;
			}
			set {
				SetValue(ref _signalSequence, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public RadarTransponderBeaconViewModel Load(RadarTransponderBeacon instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			remoteMonitoringSystem.Clear();
			if (instance.remoteMonitoringSystem is not null) {
				foreach(var e in instance.remoteMonitoringSystem)
					remoteMonitoringSystem.Add(e);
			}
			categoryOfRadarTransponderBeacon = instance.categoryOfRadarTransponderBeacon;
			radarWaveLength = new ();
			if (instance.radarWaveLength != default) {
				radarWaveLength.Load(instance.radarWaveLength);
			}
			signalGroup = instance.signalGroup;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			valueOfNominalRange = instance.valueOfNominalRange;
			manufactorer = instance.manufactorer;
			sectorLimitOne = new ();
			if (instance.sectorLimitOne != default) {
				sectorLimitOne.Load(instance.sectorLimitOne);
			}
			sectorLimitTwo = new ();
			if (instance.sectorLimitTwo != default) {
				sectorLimitTwo.Load(instance.sectorLimitTwo);
			}
			signalSequence = new ();
			if (instance.signalSequence != default) {
				signalSequence.Load(instance.signalSequence);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new RadarTransponderBeacon {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
				categoryOfRadarTransponderBeacon = this.categoryOfRadarTransponderBeacon,
				radarWaveLength = this.radarWaveLength?.Model,
				signalGroup = this.signalGroup,
				status = this.status.ToList(),
				valueOfNominalRange = this.valueOfNominalRange,
				manufactorer = this.manufactorer,
				sectorLimitOne = this.sectorLimitOne?.Model,
				sectorLimitTwo = this.sectorLimitTwo?.Model,
				signalSequence = this.signalSequence?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RadarTransponderBeacon Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
			categoryOfRadarTransponderBeacon = this._categoryOfRadarTransponderBeacon,
			radarWaveLength = this._radarWaveLength?.Model,
			signalGroup = this._signalGroup,
			status = this.status.ToList(),
			valueOfNominalRange = this._valueOfNominalRange,
			manufactorer = this._manufactorer,
			sectorLimitOne = this._sectorLimitOne?.Model,
			sectorLimitTwo = this._sectorLimitTwo?.Model,
			signalSequence = this._signalSequence?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.RadarTransponderBeacon.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.RadarTransponderBeacon.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.RadarTransponderBeacon.featureBindingDefinitions;

		public RadarTransponderBeaconViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public RadarTransponderBeaconViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Radar Transponder Beacon";

		public RadarTransponderBeaconViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			remoteMonitoringSystem.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(remoteMonitoringSystem));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// An Automatic Identification System (AIS) message 21 transmitted from an AIS station to simulate on navigation systems an Aid to Navigation which does not physically exist.
	/// </summary>
	[Description("An Automatic Identification System (AIS) message 21 transmitted from an AIS station to simulate on navigation systems an Aid to Navigation which does not physically exist.")]
	[CategoryOrder("VirtualAISAidToNavigation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class VirtualAISAidToNavigationViewModel : FeatureViewModel<VirtualAISAidToNavigation> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String? _AtoNNumber  = default;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("ElectronicAton")]
		//[Editor(typeof(Editors.HorizonEditor<ElectronicAton>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private String _mMSICode  = string.Empty;

		[Description("The Maritime Mobile Service Identity (MMSI) Code is formed of a series of nine digits which are transmitted over the radio path in order to uniquely identify ship stations, ship earth stations,coast stations, coast earth stations, and group calls. These identities are formed in such a way that the identity or part thereof can be used by telephone and telex subscribers connected to the general telecommunications network principally to call ships automatically.")]
		[Category("ElectronicAton")]
		//[Editor(typeof(Editors.HorizonEditor<ElectronicAton>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String mMSICode {
			get {
				return _mMSICode;
			}
			set {
				SetValue(ref _mMSICode, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("ElectronicAton")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private virtualAISAidToNavigationType _virtualAISAidToNavigationType  = default;

		[Description("A purpose of a virtual AIS Aid to Navigation.")]
		[Category("VirtualAISAidToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<VirtualAISAidToNavigation>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12])]
		[Mandatory]
		public virtualAISAidToNavigationType virtualAISAidToNavigationType {
			get {
				return _virtualAISAidToNavigationType;
			}
			set {
				SetValue(ref _virtualAISAidToNavigationType, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("VirtualAIS","virtualAISbroadcasts",["RadioStation"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> VirtualAIS { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. VirtualAIS.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.VirtualAIS> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public VirtualAISAidToNavigationViewModel Load(VirtualAISAidToNavigation instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			mMSICode = instance.mMSICode;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			virtualAISAidToNavigationType = instance.virtualAISAidToNavigationType;
			return this;
		}

		public override string Serialize() {
			var instance = new VirtualAISAidToNavigation {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				mMSICode = this.mMSICode,
				status = this.status.ToList(),
				virtualAISAidToNavigationType = this.virtualAISAidToNavigationType,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public VirtualAISAidToNavigation Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			mMSICode = this._mMSICode,
			status = this.status.ToList(),
			virtualAISAidToNavigationType = this._virtualAISAidToNavigationType,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.VirtualAISAidToNavigation.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.VirtualAISAidToNavigation.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.VirtualAISAidToNavigation.featureBindingDefinitions;

		public VirtualAISAidToNavigationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public VirtualAISAidToNavigationViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Virtual AIS Aid to Navigation";

		public VirtualAISAidToNavigationViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			VirtualAIS.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(VirtualAIS));
			};
		}
	}



	/// <summary>
	/// An Automatic Identification System (AIS) message 21 transmitted from a physical Aid to Navigation, or transmitted from an AIS station for an Aid to Navigation which physically exists.
	/// </summary>
	[Description("An Automatic Identification System (AIS) message 21 transmitted from a physical Aid to Navigation, or transmitted from an AIS station for an Aid to Navigation which physically exists.")]
	[CategoryOrder("PhysicalAISAidToNavigation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PhysicalAISAidToNavigationViewModel : FeatureViewModel<PhysicalAISAidToNavigation> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String? _AtoNNumber  = default;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("ElectronicAton")]
		//[Editor(typeof(Editors.HorizonEditor<ElectronicAton>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private String _mMSICode  = string.Empty;

		[Description("The Maritime Mobile Service Identity (MMSI) Code is formed of a series of nine digits which are transmitted over the radio path in order to uniquely identify ship stations, ship earth stations,coast stations, coast earth stations, and group calls. These identities are formed in such a way that the identity or part thereof can be used by telephone and telex subscribers connected to the general telecommunications network principally to call ships automatically.")]
		[Category("ElectronicAton")]
		//[Editor(typeof(Editors.HorizonEditor<ElectronicAton>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String mMSICode {
			get {
				return _mMSICode;
			}
			set {
				SetValue(ref _mMSICode, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("ElectronicAton")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private CategoryOfPhysicalAISAidToNavigation _CategoryOfPhysicalAISAidToNavigation  = default;

		[Description("A classification of AIS AtoNs that correspond to an actual, physical Aid to Navigation at a real-world location.")]
		[Category("PhysicalAISAidToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<PhysicalAISAidToNavigation>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Mandatory]
		public CategoryOfPhysicalAISAidToNavigation CategoryOfPhysicalAISAidToNavigation {
			get {
				return _CategoryOfPhysicalAISAidToNavigation;
			}
			set {
				SetValue(ref _CategoryOfPhysicalAISAidToNavigation, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("PhysicalAIS","physicalAISbroadcasts",["RadioStation"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> PhysicalAIS { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. PhysicalAIS.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.PhysicalAIS> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public PhysicalAISAidToNavigationViewModel Load(PhysicalAISAidToNavigation instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			mMSICode = instance.mMSICode;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			CategoryOfPhysicalAISAidToNavigation = instance.CategoryOfPhysicalAISAidToNavigation;
			return this;
		}

		public override string Serialize() {
			var instance = new PhysicalAISAidToNavigation {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				mMSICode = this.mMSICode,
				status = this.status.ToList(),
				CategoryOfPhysicalAISAidToNavigation = this.CategoryOfPhysicalAISAidToNavigation,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PhysicalAISAidToNavigation Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			mMSICode = this._mMSICode,
			status = this.status.ToList(),
			CategoryOfPhysicalAISAidToNavigation = this._CategoryOfPhysicalAISAidToNavigation,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.PhysicalAISAidToNavigation.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.PhysicalAISAidToNavigation.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.PhysicalAISAidToNavigation.featureBindingDefinitions;

		public PhysicalAISAidToNavigationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public PhysicalAISAidToNavigationViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Physical AIS Aid to Navigation";

		public PhysicalAISAidToNavigationViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			PhysicalAIS.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(PhysicalAIS));
			};
		}
	}



	/// <summary>
	/// -
	/// </summary>
	[Description("-")]
	[CategoryOrder("SyntheticAISAidToNavigation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SyntheticAISAidToNavigationViewModel : FeatureViewModel<SyntheticAISAidToNavigation> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String? _AtoNNumber  = default;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("ElectronicAton")]
		//[Editor(typeof(Editors.HorizonEditor<ElectronicAton>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private String _mMSICode  = string.Empty;

		[Description("The Maritime Mobile Service Identity (MMSI) Code is formed of a series of nine digits which are transmitted over the radio path in order to uniquely identify ship stations, ship earth stations,coast stations, coast earth stations, and group calls. These identities are formed in such a way that the identity or part thereof can be used by telephone and telex subscribers connected to the general telecommunications network principally to call ships automatically.")]
		[Category("ElectronicAton")]
		//[Editor(typeof(Editors.HorizonEditor<ElectronicAton>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String mMSICode {
			get {
				return _mMSICode;
			}
			set {
				SetValue(ref _mMSICode, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("ElectronicAton")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private CategoryOfSyntheticAISAidtoNavigation _CategoryOfSyntheticAISAidtoNavigation  = default;

		[Description("-")]
		[Category("SyntheticAISAidToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<SyntheticAISAidToNavigation>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2])]
		[Mandatory]
		public CategoryOfSyntheticAISAidtoNavigation CategoryOfSyntheticAISAidtoNavigation {
			get {
				return _CategoryOfSyntheticAISAidtoNavigation;
			}
			set {
				SetValue(ref _CategoryOfSyntheticAISAidtoNavigation, value);
			}
		}

		private virtualAISAidToNavigationType _virtualAISAidToNavigationType  = default;

		[Description("A purpose of a virtual AIS Aid to Navigation.")]
		[Category("SyntheticAISAidToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<SyntheticAISAidToNavigation>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12])]
		[Mandatory]
		public virtualAISAidToNavigationType virtualAISAidToNavigationType {
			get {
				return _virtualAISAidToNavigationType;
			}
			set {
				SetValue(ref _virtualAISAidToNavigationType, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("SyntheticAIS","syntheticAISbroadcasts",["RadioStation"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> SyntheticAIS { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. SyntheticAIS.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.SyntheticAIS> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public SyntheticAISAidToNavigationViewModel Load(SyntheticAISAidToNavigation instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			mMSICode = instance.mMSICode;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			CategoryOfSyntheticAISAidtoNavigation = instance.CategoryOfSyntheticAISAidtoNavigation;
			virtualAISAidToNavigationType = instance.virtualAISAidToNavigationType;
			return this;
		}

		public override string Serialize() {
			var instance = new SyntheticAISAidToNavigation {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				mMSICode = this.mMSICode,
				status = this.status.ToList(),
				CategoryOfSyntheticAISAidtoNavigation = this.CategoryOfSyntheticAISAidtoNavigation,
				virtualAISAidToNavigationType = this.virtualAISAidToNavigationType,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SyntheticAISAidToNavigation Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			mMSICode = this._mMSICode,
			status = this.status.ToList(),
			CategoryOfSyntheticAISAidtoNavigation = this._CategoryOfSyntheticAISAidtoNavigation,
			virtualAISAidToNavigationType = this._virtualAISAidToNavigationType,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SyntheticAISAidToNavigation.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.SyntheticAISAidToNavigation.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SyntheticAISAidToNavigation.featureBindingDefinitions;

		public SyntheticAISAidToNavigationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SyntheticAISAidToNavigationViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Synthetic AIS Aid To Navigation";

		public SyntheticAISAidToNavigationViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			SyntheticAIS.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(SyntheticAIS));
			};
		}
	}



	/// <summary>
	/// -
	/// </summary>
	[Description("-")]
	[CategoryOrder("PowerSource",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PowerSourceViewModel : FeatureViewModel<PowerSource> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Description("Classification or name of system used to remotely monitor a feature.")]
		[Category("Equipment")]
		[Optional]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		private CategoryOfPowerSource _CategoryOfPowerSource  = default;

		[Description("-")]
		[Category("PowerSource")]
		//[Editor(typeof(Editors.HorizonEditor<PowerSource>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Mandatory]
		public CategoryOfPowerSource CategoryOfPowerSource {
			get {
				return _CategoryOfPowerSource;
			}
			set {
				SetValue(ref _CategoryOfPowerSource, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("PowerSource")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public PowerSourceViewModel Load(PowerSource instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			remoteMonitoringSystem.Clear();
			if (instance.remoteMonitoringSystem is not null) {
				foreach(var e in instance.remoteMonitoringSystem)
					remoteMonitoringSystem.Add(e);
			}
			CategoryOfPowerSource = instance.CategoryOfPowerSource;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new PowerSource {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
				CategoryOfPowerSource = this.CategoryOfPowerSource,
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PowerSource Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			remoteMonitoringSystem = this.remoteMonitoringSystem.ToList(),
			CategoryOfPowerSource = this._CategoryOfPowerSource,
			status = this.status.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.PowerSource.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.PowerSource.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.PowerSource.featureBindingDefinitions;

		public PowerSourceViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public PowerSourceViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Power Source";

		public PowerSourceViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			remoteMonitoringSystem.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(remoteMonitoringSystem));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// An isolated danger beacon is a beacon erected on an isolated danger of limited extent, which has navigable water all around it.
	/// </summary>
	[Description("An isolated danger beacon is a beacon erected on an isolated danger of limited extent, which has navigable water all around it.")]
	[CategoryOrder("IsolatedDangerBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class IsolatedDangerBeaconViewModel : FeatureViewModel<IsolatedDangerBeacon> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private beaconShape _beaconShape  = default;

		[Description("Describes the characteristic geometric form of the beacon.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7])]
		[Mandatory]
		public beaconShape beaconShape {
			get {
				return _beaconShape;
			}
			set {
				SetValue(ref _beaconShape, value);
			}
		}

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		private double? _elevation  = default;

		[Description("The altitude of the ground level of an object, measured from a specified vertical datum.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the object, measured from a specified vertical datum.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,14,15])]
		[Optional]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Description("The building's primary construction material.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Description("A feature which returns a strong radar echo.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private visualProminence? _visualProminence  = default;

		[Description("The extent to which a feature, either natural or artificial, is visible from seaward.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public visualProminence? visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}



		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public IsolatedDangerBeaconViewModel Load(IsolatedDangerBeacon instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			beaconShape = instance.beaconShape;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			elevation = instance.elevation;
			height = instance.height;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalLength = instance.verticalLength;
			visualProminence = instance.visualProminence;
			verticalAccuracy = instance.verticalAccuracy;
			return this;
		}

		public override string Serialize() {
			var instance = new IsolatedDangerBeacon {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
				beaconShape = this.beaconShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				elevation = this.elevation,
				height = this.height,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous,
				status = this.status.ToList(),
				verticalLength = this.verticalLength,
				visualProminence = this.visualProminence,
				verticalAccuracy = this.verticalAccuracy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public IsolatedDangerBeacon Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
			beaconShape = this._beaconShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			elevation = this._elevation,
			height = this._height,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this._radarConspicuous,
			status = this.status.ToList(),
			verticalLength = this._verticalLength,
			visualProminence = this._visualProminence,
			verticalAccuracy = this._verticalAccuracy,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.IsolatedDangerBeacon.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.IsolatedDangerBeacon.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.IsolatedDangerBeacon.featureBindingDefinitions;

		public IsolatedDangerBeaconViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public IsolatedDangerBeaconViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Isolated Danger Beacon";

		public IsolatedDangerBeaconViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A cardinal beacon is used in conjunction with the compass to indicate where the mariner may find the best navigable water. It is placed in one of the four quadrants (North, East, South and West), bounded by inter-cardinal bearings from the point marked.
	/// </summary>
	[Description("A cardinal beacon is used in conjunction with the compass to indicate where the mariner may find the best navigable water. It is placed in one of the four quadrants (North, East, South and West), bounded by inter-cardinal bearings from the point marked.")]
	[CategoryOrder("CardinalBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CardinalBeaconViewModel : FeatureViewModel<CardinalBeacon> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private beaconShape _beaconShape  = default;

		[Description("Describes the characteristic geometric form of the beacon.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7])]
		[Mandatory]
		public beaconShape beaconShape {
			get {
				return _beaconShape;
			}
			set {
				SetValue(ref _beaconShape, value);
			}
		}

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		private double? _elevation  = default;

		[Description("The altitude of the ground level of an object, measured from a specified vertical datum.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the object, measured from a specified vertical datum.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,14,15])]
		[Optional]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Description("The building's primary construction material.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Description("A feature which returns a strong radar echo.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private visualProminence? _visualProminence  = default;

		[Description("The extent to which a feature, either natural or artificial, is visible from seaward.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public visualProminence? visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}

		private categoryOfCardinalMark _categoryOfCardinalMark  = default;

		[Description("The four quadrants (north, east, south and west) are bounded by the true bearings NW-NE, NE-SE, SE-SW and SW-NW taken from the point of interest. A cardinal mark is named after the quadrant in which it is placed. The name of the cardinal mark indicates that it should be passed to the named side of the mark.")]
		[Category("CardinalBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<CardinalBeacon>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Mandatory]
		public categoryOfCardinalMark categoryOfCardinalMark {
			get {
				return _categoryOfCardinalMark;
			}
			set {
				SetValue(ref _categoryOfCardinalMark, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public CardinalBeaconViewModel Load(CardinalBeacon instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			beaconShape = instance.beaconShape;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			elevation = instance.elevation;
			height = instance.height;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalLength = instance.verticalLength;
			visualProminence = instance.visualProminence;
			verticalAccuracy = instance.verticalAccuracy;
			categoryOfCardinalMark = instance.categoryOfCardinalMark;
			return this;
		}

		public override string Serialize() {
			var instance = new CardinalBeacon {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
				beaconShape = this.beaconShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				elevation = this.elevation,
				height = this.height,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous,
				status = this.status.ToList(),
				verticalLength = this.verticalLength,
				visualProminence = this.visualProminence,
				verticalAccuracy = this.verticalAccuracy,
				categoryOfCardinalMark = this.categoryOfCardinalMark,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CardinalBeacon Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
			beaconShape = this._beaconShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			elevation = this._elevation,
			height = this._height,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this._radarConspicuous,
			status = this.status.ToList(),
			verticalLength = this._verticalLength,
			visualProminence = this._visualProminence,
			verticalAccuracy = this._verticalAccuracy,
			categoryOfCardinalMark = this._categoryOfCardinalMark,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.CardinalBeacon.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.CardinalBeacon.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.CardinalBeacon.featureBindingDefinitions;

		public CardinalBeaconViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public CardinalBeaconViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Cardinal Beacon";

		public CardinalBeaconViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// An isolated danger buoy is a buoy moored on or above an isolated danger of limited extent, which has navigable water all around it.
	/// </summary>
	[Description("An isolated danger buoy is a buoy moored on or above an isolated danger of limited extent, which has navigable water all around it.")]
	[CategoryOrder("IsolatedDangerBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class IsolatedDangerBuoyViewModel : FeatureViewModel<IsolatedDangerBuoy> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private buoyShape _buoyShape  = default;

		[Description("The principal shape and/or design of a buoy.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8])]
		[Mandatory]
		public buoyShape buoyShape {
			get {
				return _buoyShape;
			}
			set {
				SetValue(ref _buoyShape, value);
			}
		}

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,14,15])]
		[Optional]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Description("The building's primary construction material.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Description("A feature which returns a strong radar echo.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private String? _typeOfBuoy  = default;

		[Description("Type equipment used as a buoy in a particular installation.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}



		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public IsolatedDangerBuoyViewModel Load(IsolatedDangerBuoy instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			buoyShape = instance.buoyShape;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			typeOfBuoy = instance.typeOfBuoy;
			verticalLength = instance.verticalLength;
			verticalAccuracy = instance.verticalAccuracy;
			return this;
		}

		public override string Serialize() {
			var instance = new IsolatedDangerBuoy {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
				buoyShape = this.buoyShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous,
				status = this.status.ToList(),
				typeOfBuoy = this.typeOfBuoy,
				verticalLength = this.verticalLength,
				verticalAccuracy = this.verticalAccuracy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public IsolatedDangerBuoy Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this._radarConspicuous,
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
			verticalLength = this._verticalLength,
			verticalAccuracy = this._verticalAccuracy,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.IsolatedDangerBuoy.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.IsolatedDangerBuoy.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.IsolatedDangerBuoy.featureBindingDefinitions;

		public IsolatedDangerBuoyViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public IsolatedDangerBuoyViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Isolated Danger Buoy";

		public IsolatedDangerBuoyViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A cardinal buoy is used in conjunction with the compass to indicate where the mariner may find the best navigable water. It is placed in one of the four quadrants (North, East, South and West), bounded by inter-cardinal bearings from the point marked.
	/// </summary>
	[Description("A cardinal buoy is used in conjunction with the compass to indicate where the mariner may find the best navigable water. It is placed in one of the four quadrants (North, East, South and West), bounded by inter-cardinal bearings from the point marked.")]
	[CategoryOrder("CardinalBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CardinalBuoyViewModel : FeatureViewModel<CardinalBuoy> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private buoyShape _buoyShape  = default;

		[Description("The principal shape and/or design of a buoy.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8])]
		[Mandatory]
		public buoyShape buoyShape {
			get {
				return _buoyShape;
			}
			set {
				SetValue(ref _buoyShape, value);
			}
		}

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,14,15])]
		[Optional]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Description("The building's primary construction material.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Description("A feature which returns a strong radar echo.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private String? _typeOfBuoy  = default;

		[Description("Type equipment used as a buoy in a particular installation.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}

		private categoryOfCardinalMark _categoryOfCardinalMark  = default;

		[Description("The four quadrants (north, east, south and west) are bounded by the true bearings NW-NE, NE-SE, SE-SW and SW-NW taken from the point of interest. A cardinal mark is named after the quadrant in which it is placed. The name of the cardinal mark indicates that it should be passed to the named side of the mark.")]
		[Category("CardinalBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<CardinalBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Mandatory]
		public categoryOfCardinalMark categoryOfCardinalMark {
			get {
				return _categoryOfCardinalMark;
			}
			set {
				SetValue(ref _categoryOfCardinalMark, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public CardinalBuoyViewModel Load(CardinalBuoy instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			buoyShape = instance.buoyShape;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			typeOfBuoy = instance.typeOfBuoy;
			verticalLength = instance.verticalLength;
			verticalAccuracy = instance.verticalAccuracy;
			categoryOfCardinalMark = instance.categoryOfCardinalMark;
			return this;
		}

		public override string Serialize() {
			var instance = new CardinalBuoy {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
				buoyShape = this.buoyShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous,
				status = this.status.ToList(),
				typeOfBuoy = this.typeOfBuoy,
				verticalLength = this.verticalLength,
				verticalAccuracy = this.verticalAccuracy,
				categoryOfCardinalMark = this.categoryOfCardinalMark,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CardinalBuoy Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this._radarConspicuous,
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
			verticalLength = this._verticalLength,
			verticalAccuracy = this._verticalAccuracy,
			categoryOfCardinalMark = this._categoryOfCardinalMark,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.CardinalBuoy.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.CardinalBuoy.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.CardinalBuoy.featureBindingDefinitions;

		public CardinalBuoyViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public CardinalBuoyViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Cardinal Buoy";

		public CardinalBuoyViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A buoy is a floating object moored to the bottom in a particular place, as an aid to navigation or for other specific purposes. (IHO Dictionary, S-32, 5th Edition, 565). An installation buoy is a buoy used for loading tankers with gas or oil. (IHO Chart Specifications, M-4)
	/// </summary>
	[Description("A buoy is a floating object moored to the bottom in a particular place, as an aid to navigation or for other specific purposes. (IHO Dictionary, S-32, 5th Edition, 565). An installation buoy is a buoy used for loading tankers with gas or oil. (IHO Chart Specifications, M-4)")]
	[CategoryOrder("InstallationBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class InstallationBuoyViewModel : FeatureViewModel<InstallationBuoy> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private buoyShape _buoyShape  = default;

		[Description("The principal shape and/or design of a buoy.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8])]
		[Mandatory]
		public buoyShape buoyShape {
			get {
				return _buoyShape;
			}
			set {
				SetValue(ref _buoyShape, value);
			}
		}

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,14,15])]
		[Optional]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Description("The building's primary construction material.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Description("A feature which returns a strong radar echo.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private String? _typeOfBuoy  = default;

		[Description("Type equipment used as a buoy in a particular installation.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}

		private categoryOfInstallationBuoy _categoryOfInstallationBuoy  = default;

		[Description("	Classification of fixed installation buoy.")]
		[Category("InstallationBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<InstallationBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2])]
		[Mandatory]
		public categoryOfInstallationBuoy categoryOfInstallationBuoy {
			get {
				return _categoryOfInstallationBuoy;
			}
			set {
				SetValue(ref _categoryOfInstallationBuoy, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public InstallationBuoyViewModel Load(InstallationBuoy instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			buoyShape = instance.buoyShape;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			typeOfBuoy = instance.typeOfBuoy;
			verticalLength = instance.verticalLength;
			verticalAccuracy = instance.verticalAccuracy;
			categoryOfInstallationBuoy = instance.categoryOfInstallationBuoy;
			return this;
		}

		public override string Serialize() {
			var instance = new InstallationBuoy {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
				buoyShape = this.buoyShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous,
				status = this.status.ToList(),
				typeOfBuoy = this.typeOfBuoy,
				verticalLength = this.verticalLength,
				verticalAccuracy = this.verticalAccuracy,
				categoryOfInstallationBuoy = this.categoryOfInstallationBuoy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public InstallationBuoy Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this._radarConspicuous,
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
			verticalLength = this._verticalLength,
			verticalAccuracy = this._verticalAccuracy,
			categoryOfInstallationBuoy = this._categoryOfInstallationBuoy,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.InstallationBuoy.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.InstallationBuoy.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.InstallationBuoy.featureBindingDefinitions;

		public InstallationBuoyViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public InstallationBuoyViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Installation Buoy";

		public InstallationBuoyViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// The equipment or structure used to secure a vessel. (IHO Registry)
	/// </summary>
	[Description("The equipment or structure used to secure a vessel. (IHO Registry)")]
	[CategoryOrder("MooringBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class MooringBuoyViewModel : FeatureViewModel<MooringBuoy> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private buoyShape _buoyShape  = default;

		[Description("The principal shape and/or design of a buoy.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8])]
		[Mandatory]
		public buoyShape buoyShape {
			get {
				return _buoyShape;
			}
			set {
				SetValue(ref _buoyShape, value);
			}
		}

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,14,15])]
		[Optional]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Description("The building's primary construction material.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Description("A feature which returns a strong radar echo.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private String? _typeOfBuoy  = default;

		[Description("Type equipment used as a buoy in a particular installation.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}



		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public MooringBuoyViewModel Load(MooringBuoy instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			buoyShape = instance.buoyShape;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			typeOfBuoy = instance.typeOfBuoy;
			verticalLength = instance.verticalLength;
			verticalAccuracy = instance.verticalAccuracy;
			return this;
		}

		public override string Serialize() {
			var instance = new MooringBuoy {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
				buoyShape = this.buoyShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous,
				status = this.status.ToList(),
				typeOfBuoy = this.typeOfBuoy,
				verticalLength = this.verticalLength,
				verticalAccuracy = this.verticalAccuracy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public MooringBuoy Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this._radarConspicuous,
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
			verticalLength = this._verticalLength,
			verticalAccuracy = this._verticalAccuracy,
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
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// An emergency wreck marking buoy is a buoy moored on or above a new wreck, designed to provide a prominent (both visual and radio) and easily identifiable temporary (24-72 hours) first response. (IHO Registry)
	/// </summary>
	[Description("An emergency wreck marking buoy is a buoy moored on or above a new wreck, designed to provide a prominent (both visual and radio) and easily identifiable temporary (24-72 hours) first response. (IHO Registry)")]
	[CategoryOrder("EmergencyWreckMarkingBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class EmergencyWreckMarkingBuoyViewModel : FeatureViewModel<EmergencyWreckMarkingBuoy> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private buoyShape _buoyShape  = default;

		[Description("The principal shape and/or design of a buoy.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8])]
		[Mandatory]
		public buoyShape buoyShape {
			get {
				return _buoyShape;
			}
			set {
				SetValue(ref _buoyShape, value);
			}
		}

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,14,15])]
		[Optional]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Description("The building's primary construction material.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Description("A feature which returns a strong radar echo.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private String? _typeOfBuoy  = default;

		[Description("Type equipment used as a buoy in a particular installation.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}



		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public EmergencyWreckMarkingBuoyViewModel Load(EmergencyWreckMarkingBuoy instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			buoyShape = instance.buoyShape;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			typeOfBuoy = instance.typeOfBuoy;
			verticalLength = instance.verticalLength;
			verticalAccuracy = instance.verticalAccuracy;
			return this;
		}

		public override string Serialize() {
			var instance = new EmergencyWreckMarkingBuoy {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
				buoyShape = this.buoyShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous,
				status = this.status.ToList(),
				typeOfBuoy = this.typeOfBuoy,
				verticalLength = this.verticalLength,
				verticalAccuracy = this.verticalAccuracy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public EmergencyWreckMarkingBuoy Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this._radarConspicuous,
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
			verticalLength = this._verticalLength,
			verticalAccuracy = this._verticalAccuracy,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.EmergencyWreckMarkingBuoy.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.EmergencyWreckMarkingBuoy.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.EmergencyWreckMarkingBuoy.featureBindingDefinitions;

		public EmergencyWreckMarkingBuoyViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public EmergencyWreckMarkingBuoyViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Emergency Wreck Marking Buoy";

		public EmergencyWreckMarkingBuoyViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A distinctive structure on or off a coast exhibiting a major light designed to serve as an aid to navigation.
	/// </summary>
	[Description("A distinctive structure on or off a coast exhibiting a major light designed to serve as an aid to navigation.")]
	[CategoryOrder("Lighthouse",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LighthouseViewModel : FeatureViewModel<Lighthouse> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		[Description("Classification of prominent cultural and natural features in the landscape.")]
		[Category("Landmark")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
		[Multiplicity(1)]
		public ObservableCollection<categoryOfLandmark> categoryOfLandmark  { get; set; } = new ();

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("Landmark")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("Landmark")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Description("A specific role that describes a feature.")]
		[Category("Landmark")]
		[PermittedValues([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48])]
		[Optional]
		public ObservableCollection<function> function  { get; set; } = new ();

		[Description("The building's primary construction material.")]
		[Category("Landmark")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Description("A feature which returns a strong radar echo.")]
		[Category("Landmark")]
		//[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("Landmark")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private verticalDatum? _verticalDatum  = default;

		[Description("The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.")]
		[Category("Landmark")]
		//[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
		[Optional]
		public verticalDatum? verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		private visualProminence _visualProminence  = default;

		[Description("The extent to which a feature, either natural or artificial, is visible from seaward.")]
		[Category("Landmark")]
		//[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Mandatory]
		public visualProminence visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		private double? _elevation  = default;

		[Description("The altitude of the ground level of an object, measured from a specified vertical datum.")]
		[Category("Landmark")]
		//[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the object, measured from a specified vertical datum.")]
		[Category("Landmark")]
		//[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private Boolean? _mannedStructure  = default;

		[Description("An expression of the feature being permanently manned or not.")]
		[Category("Landmark")]
		//[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? mannedStructure {
			get {
				return _mannedStructure;
			}
			set {
				SetValue(ref _mannedStructure, value);
			}
		}

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("Landmark")]
		//[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("Landmark")]
		//[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}



		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public LighthouseViewModel Load(Lighthouse instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			categoryOfLandmark.Clear();
			if (instance.categoryOfLandmark is not null) {
				foreach(var e in instance.categoryOfLandmark)
					categoryOfLandmark.Add(e);
			}
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			function.Clear();
			if (instance.function is not null) {
				foreach(var e in instance.function)
					function.Add(e);
			}
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalDatum = instance.verticalDatum;
			visualProminence = instance.visualProminence;
			elevation = instance.elevation;
			height = instance.height;
			mannedStructure = instance.mannedStructure;
			verticalLength = instance.verticalLength;
			verticalAccuracy = instance.verticalAccuracy;
			return this;
		}

		public override string Serialize() {
			var instance = new Lighthouse {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
				categoryOfLandmark = this.categoryOfLandmark.ToList(),
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				function = this.function.ToList(),
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous,
				status = this.status.ToList(),
				verticalDatum = this.verticalDatum,
				visualProminence = this.visualProminence,
				elevation = this.elevation,
				height = this.height,
				mannedStructure = this.mannedStructure,
				verticalLength = this.verticalLength,
				verticalAccuracy = this.verticalAccuracy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Lighthouse Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
			categoryOfLandmark = this.categoryOfLandmark.ToList(),
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			function = this.function.ToList(),
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this._radarConspicuous,
			status = this.status.ToList(),
			verticalDatum = this._verticalDatum,
			visualProminence = this._visualProminence,
			elevation = this._elevation,
			height = this._height,
			mannedStructure = this._mannedStructure,
			verticalLength = this._verticalLength,
			verticalAccuracy = this._verticalAccuracy,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Lighthouse.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.Lighthouse.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Lighthouse.featureBindingDefinitions;

		public LighthouseViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public LighthouseViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Lighthouse";

		public LighthouseViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			categoryOfLandmark.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfLandmark));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			function.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(function));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A boat-like structure used instead of a light buoy in waters where strong streams or currents are experienced, or when a greater elevation than that of a light buoy is necessary.
	/// </summary>
	[Description("A boat-like structure used instead of a light buoy in waters where strong streams or currents are experienced, or when a greater elevation than that of a light buoy is necessary.")]
	[CategoryOrder("LightFloat",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LightFloatViewModel : FeatureViewModel<LightFloat> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("LightFloat")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("LightFloat")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		private double? _horizontalLength  = default;

		[Description("A measurement of the longer of two linear axis.")]
		[Category("LightFloat")]
		//[Editor(typeof(Editors.HorizonEditor<LightFloat>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalLength {
			get {
				return _horizontalLength;
			}
			set {
				SetValue(ref _horizontalLength, value);
			}
		}

		private double? _horizontalWidth  = default;

		[Description("A measurement of the shorter of two linear axis.")]
		[Category("LightFloat")]
		//[Editor(typeof(Editors.HorizonEditor<LightFloat>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalWidth {
			get {
				return _horizontalWidth;
			}
			set {
				SetValue(ref _horizontalWidth, value);
			}
		}

		private Boolean? _mannedStructure  = default;

		[Description("An expression of the feature being permanently manned or not.")]
		[Category("LightFloat")]
		//[Editor(typeof(Editors.HorizonEditor<LightFloat>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? mannedStructure {
			get {
				return _mannedStructure;
			}
			set {
				SetValue(ref _mannedStructure, value);
			}
		}

		[Description("The building's primary construction material.")]
		[Category("LightFloat")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Description("A feature which returns a strong radar echo.")]
		[Category("LightFloat")]
		//[Editor(typeof(Editors.HorizonEditor<LightFloat>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("LightFloat")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("LightFloat")]
		//[Editor(typeof(Editors.HorizonEditor<LightFloat>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private visualProminence? _visualProminence  = default;

		[Description("The extent to which a feature, either natural or artificial, is visible from seaward.")]
		[Category("LightFloat")]
		//[Editor(typeof(Editors.HorizonEditor<LightFloat>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public visualProminence? visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("LightFloat")]
		//[Editor(typeof(Editors.HorizonEditor<LightFloat>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}

		private double? _horizontalAccuracy  = default;

		[Description("-")]
		[Category("LightFloat")]
		//[Editor(typeof(Editors.HorizonEditor<LightFloat>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalAccuracy {
			get {
				return _horizontalAccuracy;
			}
			set {
				SetValue(ref _horizontalAccuracy, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public LightFloatViewModel Load(LightFloat instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			horizontalLength = instance.horizontalLength;
			horizontalWidth = instance.horizontalWidth;
			mannedStructure = instance.mannedStructure;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalLength = instance.verticalLength;
			visualProminence = instance.visualProminence;
			verticalAccuracy = instance.verticalAccuracy;
			horizontalAccuracy = instance.horizontalAccuracy;
			return this;
		}

		public override string Serialize() {
			var instance = new LightFloat {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				horizontalLength = this.horizontalLength,
				horizontalWidth = this.horizontalWidth,
				mannedStructure = this.mannedStructure,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous,
				status = this.status.ToList(),
				verticalLength = this.verticalLength,
				visualProminence = this.visualProminence,
				verticalAccuracy = this.verticalAccuracy,
				horizontalAccuracy = this.horizontalAccuracy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LightFloat Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			horizontalLength = this._horizontalLength,
			horizontalWidth = this._horizontalWidth,
			mannedStructure = this._mannedStructure,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this._radarConspicuous,
			status = this.status.ToList(),
			verticalLength = this._verticalLength,
			visualProminence = this._visualProminence,
			verticalAccuracy = this._verticalAccuracy,
			horizontalAccuracy = this._horizontalAccuracy,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LightFloat.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.LightFloat.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LightFloat.featureBindingDefinitions;

		public LightFloatViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public LightFloatViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Light Float";

		public LightFloatViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A distinctively marked vessel anchored or moored at a charted point, to serve as an aid to navigation. By night, it displays a characteristic light(s) and is usually equipped with other devices, such as fog signal, submarine sound signal, and radio-beacon, to assist navigation.
	/// </summary>
	[Description("A distinctively marked vessel anchored or moored at a charted point, to serve as an aid to navigation. By night, it displays a characteristic light(s) and is usually equipped with other devices, such as fog signal, submarine sound signal, and radio-beacon, to assist navigation.")]
	[CategoryOrder("LightVessel",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LightVesselViewModel : FeatureViewModel<LightVessel> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("LightVessel")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("LightVessel")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		private double? _horizontalLength  = default;

		[Description("A measurement of the longer of two linear axis.")]
		[Category("LightVessel")]
		//[Editor(typeof(Editors.HorizonEditor<LightVessel>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalLength {
			get {
				return _horizontalLength;
			}
			set {
				SetValue(ref _horizontalLength, value);
			}
		}

		private double? _horizontalWidth  = default;

		[Description("A measurement of the shorter of two linear axis.")]
		[Category("LightVessel")]
		//[Editor(typeof(Editors.HorizonEditor<LightVessel>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalWidth {
			get {
				return _horizontalWidth;
			}
			set {
				SetValue(ref _horizontalWidth, value);
			}
		}

		private Boolean? _mannedStructure  = default;

		[Description("An expression of the feature being permanently manned or not.")]
		[Category("LightVessel")]
		//[Editor(typeof(Editors.HorizonEditor<LightVessel>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? mannedStructure {
			get {
				return _mannedStructure;
			}
			set {
				SetValue(ref _mannedStructure, value);
			}
		}

		[Description("The building's primary construction material.")]
		[Category("LightVessel")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Description("A feature which returns a strong radar echo.")]
		[Category("LightVessel")]
		//[Editor(typeof(Editors.HorizonEditor<LightVessel>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("LightVessel")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("LightVessel")]
		//[Editor(typeof(Editors.HorizonEditor<LightVessel>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private visualProminence? _visualProminence  = default;

		[Description("The extent to which a feature, either natural or artificial, is visible from seaward.")]
		[Category("LightVessel")]
		//[Editor(typeof(Editors.HorizonEditor<LightVessel>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public visualProminence? visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("LightVessel")]
		//[Editor(typeof(Editors.HorizonEditor<LightVessel>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}

		private double? _horizontalAccuracy  = default;

		[Description("-")]
		[Category("LightVessel")]
		//[Editor(typeof(Editors.HorizonEditor<LightVessel>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalAccuracy {
			get {
				return _horizontalAccuracy;
			}
			set {
				SetValue(ref _horizontalAccuracy, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public LightVesselViewModel Load(LightVessel instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			horizontalLength = instance.horizontalLength;
			horizontalWidth = instance.horizontalWidth;
			mannedStructure = instance.mannedStructure;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalLength = instance.verticalLength;
			visualProminence = instance.visualProminence;
			verticalAccuracy = instance.verticalAccuracy;
			horizontalAccuracy = instance.horizontalAccuracy;
			return this;
		}

		public override string Serialize() {
			var instance = new LightVessel {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				horizontalLength = this.horizontalLength,
				horizontalWidth = this.horizontalWidth,
				mannedStructure = this.mannedStructure,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous,
				status = this.status.ToList(),
				verticalLength = this.verticalLength,
				visualProminence = this.visualProminence,
				verticalAccuracy = this.verticalAccuracy,
				horizontalAccuracy = this.horizontalAccuracy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LightVessel Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			horizontalLength = this._horizontalLength,
			horizontalWidth = this._horizontalWidth,
			mannedStructure = this._mannedStructure,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this._radarConspicuous,
			status = this.status.ToList(),
			verticalLength = this._verticalLength,
			visualProminence = this._visualProminence,
			verticalAccuracy = this._verticalAccuracy,
			horizontalAccuracy = this._horizontalAccuracy,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LightVessel.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.LightVessel.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LightVessel.featureBindingDefinitions;

		public LightVesselViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public LightVesselViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Light Vessel";

		public LightVesselViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A permanent offshore structure, either fixed or floating.
	/// </summary>
	[Description("A permanent offshore structure, either fixed or floating.")]
	[CategoryOrder("OffshorePlatform",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class OffshorePlatformViewModel : FeatureViewModel<OffshorePlatform> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		[Description("Classification of an offshore raised structure.")]
		[Category("OffshorePlatform")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11])]
		[Optional]
		public ObservableCollection<categoryOfOffshorePlatform> categoryOfOffshorePlatform  { get; set; } = new ();

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("OffshorePlatform")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("OffshorePlatform")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the object, measured from a specified vertical datum.")]
		[Category("OffshorePlatform")]
		//[Editor(typeof(Editors.HorizonEditor<OffshorePlatform>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private Boolean? _mannedStructure  = default;

		[Description("An expression of the feature being permanently manned or not.")]
		[Category("OffshorePlatform")]
		//[Editor(typeof(Editors.HorizonEditor<OffshorePlatform>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? mannedStructure {
			get {
				return _mannedStructure;
			}
			set {
				SetValue(ref _mannedStructure, value);
			}
		}

		[Description("The building's primary construction material.")]
		[Category("OffshorePlatform")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Description("The various substances which are transported, stored or exploited.")]
		[Category("OffshorePlatform")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25])]
		[Optional]
		public ObservableCollection<product> product  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Description("A feature which returns a strong radar echo.")]
		[Category("OffshorePlatform")]
		//[Editor(typeof(Editors.HorizonEditor<OffshorePlatform>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("OffshorePlatform")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private verticalDatum? _verticalDatum  = default;

		[Description("The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.")]
		[Category("OffshorePlatform")]
		//[Editor(typeof(Editors.HorizonEditor<OffshorePlatform>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
		[Optional]
		public verticalDatum? verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("OffshorePlatform")]
		//[Editor(typeof(Editors.HorizonEditor<OffshorePlatform>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private visualProminence? _visualProminence  = default;

		[Description("The extent to which a feature, either natural or artificial, is visible from seaward.")]
		[Category("OffshorePlatform")]
		//[Editor(typeof(Editors.HorizonEditor<OffshorePlatform>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public visualProminence? visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("OffshorePlatform")]
		//[Editor(typeof(Editors.HorizonEditor<OffshorePlatform>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public OffshorePlatformViewModel Load(OffshorePlatform instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			categoryOfOffshorePlatform.Clear();
			if (instance.categoryOfOffshorePlatform is not null) {
				foreach(var e in instance.categoryOfOffshorePlatform)
					categoryOfOffshorePlatform.Add(e);
			}
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			height = instance.height;
			mannedStructure = instance.mannedStructure;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			product.Clear();
			if (instance.product is not null) {
				foreach(var e in instance.product)
					product.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalDatum = instance.verticalDatum;
			verticalLength = instance.verticalLength;
			visualProminence = instance.visualProminence;
			verticalAccuracy = instance.verticalAccuracy;
			return this;
		}

		public override string Serialize() {
			var instance = new OffshorePlatform {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
				categoryOfOffshorePlatform = this.categoryOfOffshorePlatform.ToList(),
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				height = this.height,
				mannedStructure = this.mannedStructure,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				product = this.product.ToList(),
				radarConspicuous = this.radarConspicuous,
				status = this.status.ToList(),
				verticalDatum = this.verticalDatum,
				verticalLength = this.verticalLength,
				visualProminence = this.visualProminence,
				verticalAccuracy = this.verticalAccuracy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public OffshorePlatform Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
			categoryOfOffshorePlatform = this.categoryOfOffshorePlatform.ToList(),
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			height = this._height,
			mannedStructure = this._mannedStructure,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			product = this.product.ToList(),
			radarConspicuous = this._radarConspicuous,
			status = this.status.ToList(),
			verticalDatum = this._verticalDatum,
			verticalLength = this._verticalLength,
			visualProminence = this._visualProminence,
			verticalAccuracy = this._verticalAccuracy,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.OffshorePlatform.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.OffshorePlatform.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.OffshorePlatform.featureBindingDefinitions;

		public OffshorePlatformViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public OffshorePlatformViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Offshore Platform";

		public OffshorePlatformViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			categoryOfOffshorePlatform.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfOffshorePlatform));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			product.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(product));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A large storage structure used for storing loose materials, liquids and/or gases.
	/// </summary>
	[Description("A large storage structure used for storing loose materials, liquids and/or gases.")]
	[CategoryOrder("SiloTank",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SiloTankViewModel : FeatureViewModel<SiloTank> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private buildingShape? _buildingShape  = default;

		[Description("The specific shape of the building.")]
		[Category("SiloTank")]
		//[Editor(typeof(Editors.HorizonEditor<SiloTank>), typeof(Editors.HorizonEditor))]
		[PermittedValues([5,6,7,8,9])]
		[Optional]
		public buildingShape? buildingShape {
			get {
				return _buildingShape;
			}
			set {
				SetValue(ref _buildingShape, value);
			}
		}

		private categoryOfSiloTank? _categoryOfSiloTank  = default;

		[Description("Classification based on the product for which a silo or tank is used.")]
		[Category("SiloTank")]
		//[Editor(typeof(Editors.HorizonEditor<SiloTank>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4])]
		[Optional]
		public categoryOfSiloTank? categoryOfSiloTank {
			get {
				return _categoryOfSiloTank;
			}
			set {
				SetValue(ref _categoryOfSiloTank, value);
			}
		}

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("SiloTank")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("SiloTank")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		private double? _elevation  = default;

		[Description("The altitude of the ground level of an object, measured from a specified vertical datum.")]
		[Category("SiloTank")]
		//[Editor(typeof(Editors.HorizonEditor<SiloTank>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the object, measured from a specified vertical datum.")]
		[Category("SiloTank")]
		//[Editor(typeof(Editors.HorizonEditor<SiloTank>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		[Description("The building's primary construction material.")]
		[Category("SiloTank")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Description("A feature which returns a strong radar echo.")]
		[Category("SiloTank")]
		//[Editor(typeof(Editors.HorizonEditor<SiloTank>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("SiloTank")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private verticalDatum? _verticalDatum  = default;

		[Description("The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.")]
		[Category("SiloTank")]
		//[Editor(typeof(Editors.HorizonEditor<SiloTank>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
		[Optional]
		public verticalDatum? verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("SiloTank")]
		//[Editor(typeof(Editors.HorizonEditor<SiloTank>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private visualProminence? _visualProminence  = default;

		[Description("The extent to which a feature, either natural or artificial, is visible from seaward.")]
		[Category("SiloTank")]
		//[Editor(typeof(Editors.HorizonEditor<SiloTank>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public visualProminence? visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("SiloTank")]
		//[Editor(typeof(Editors.HorizonEditor<SiloTank>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public SiloTankViewModel Load(SiloTank instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			buildingShape = instance.buildingShape;
			categoryOfSiloTank = instance.categoryOfSiloTank;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			elevation = instance.elevation;
			height = instance.height;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalDatum = instance.verticalDatum;
			verticalLength = instance.verticalLength;
			visualProminence = instance.visualProminence;
			verticalAccuracy = instance.verticalAccuracy;
			return this;
		}

		public override string Serialize() {
			var instance = new SiloTank {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
				buildingShape = this.buildingShape,
				categoryOfSiloTank = this.categoryOfSiloTank,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				elevation = this.elevation,
				height = this.height,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous,
				status = this.status.ToList(),
				verticalDatum = this.verticalDatum,
				verticalLength = this.verticalLength,
				visualProminence = this.visualProminence,
				verticalAccuracy = this.verticalAccuracy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SiloTank Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
			buildingShape = this._buildingShape,
			categoryOfSiloTank = this._categoryOfSiloTank,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			elevation = this._elevation,
			height = this._height,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this._radarConspicuous,
			status = this.status.ToList(),
			verticalDatum = this._verticalDatum,
			verticalLength = this._verticalLength,
			visualProminence = this._visualProminence,
			verticalAccuracy = this._verticalAccuracy,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SiloTank.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.SiloTank.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SiloTank.featureBindingDefinitions;

		public SiloTankViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SiloTankViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Silo/Tank";

		public SiloTankViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A long heavy timber or section of steel, wood, concrete, etc., forced into the earth or sea floor to serve as a support, as for a pier, or to resist lateral pressure; or as a free standing pole within a marine environment.
	/// </summary>
	[Description("A long heavy timber or section of steel, wood, concrete, etc., forced into the earth or sea floor to serve as a support, as for a pier, or to resist lateral pressure; or as a free standing pole within a marine environment.")]
	[CategoryOrder("Pile",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PileViewModel : FeatureViewModel<Pile> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private categoryOfPile? _categoryOfPile  = default;

		[Description("Classification of pile, driven into the earth as a foundation or support for a structure.")]
		[Category("Pile")]
		//[Editor(typeof(Editors.HorizonEditor<Pile>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,3,4,5,6,7])]
		[Optional]
		public categoryOfPile? categoryOfPile {
			get {
				return _categoryOfPile;
			}
			set {
				SetValue(ref _categoryOfPile, value);
			}
		}

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("Pile")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("Pile")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the object, measured from a specified vertical datum.")]
		[Category("Pile")]
		//[Editor(typeof(Editors.HorizonEditor<Pile>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private verticalDatum? _verticalDatum  = default;

		[Description("The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.")]
		[Category("Pile")]
		//[Editor(typeof(Editors.HorizonEditor<Pile>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
		[Optional]
		public verticalDatum? verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("Pile")]
		//[Editor(typeof(Editors.HorizonEditor<Pile>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private visualProminence? _visualProminence  = default;

		[Description("The extent to which a feature, either natural or artificial, is visible from seaward.")]
		[Category("Pile")]
		//[Editor(typeof(Editors.HorizonEditor<Pile>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public visualProminence? visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("Pile")]
		//[Editor(typeof(Editors.HorizonEditor<Pile>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public PileViewModel Load(Pile instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			categoryOfPile = instance.categoryOfPile;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			height = instance.height;
			verticalDatum = instance.verticalDatum;
			verticalLength = instance.verticalLength;
			visualProminence = instance.visualProminence;
			verticalAccuracy = instance.verticalAccuracy;
			return this;
		}

		public override string Serialize() {
			var instance = new Pile {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
				categoryOfPile = this.categoryOfPile,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				height = this.height,
				verticalDatum = this.verticalDatum,
				verticalLength = this.verticalLength,
				visualProminence = this.visualProminence,
				verticalAccuracy = this.verticalAccuracy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Pile Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
			categoryOfPile = this._categoryOfPile,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			height = this._height,
			verticalDatum = this._verticalDatum,
			verticalLength = this._verticalLength,
			visualProminence = this._visualProminence,
			verticalAccuracy = this._verticalAccuracy,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Pile.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.Pile.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Pile.featureBindingDefinitions;

		public PileViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public PileViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Pile";

		public PileViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
		}
	}



	/// <summary>
	/// A free-standing self-supporting construction that is roofed, usually walled, and is intended for human occupancy (for example: a place of work or recreation) and/or habitation.
	/// </summary>
	[Description("A free-standing self-supporting construction that is roofed, usually walled, and is intended for human occupancy (for example: a place of work or recreation) and/or habitation.")]
	[CategoryOrder("Building",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BuildingViewModel : FeatureViewModel<Building> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}



		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public BuildingViewModel Load(Building instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Building {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Building Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Building.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.Building.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Building.featureBindingDefinitions;

		public BuildingViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public BuildingViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Building";

		public BuildingViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
		}
	}



	/// <summary>
	/// (1) An elevated structure extending across or over the weather deck of a vessel, or part of such a structure. The term is sometimes modified to indicate the intended use, such as navigating bridge or signal bridge.  (2) A structure erected over a depression or an obstacle such as a body of water, railroad, etc., to provide a roadway for vehicles or pedestrians.
	/// </summary>
	[Description("(1) An elevated structure extending across or over the weather deck of a vessel, or part of such a structure. The term is sometimes modified to indicate the intended use, such as navigating bridge or signal bridge.  (2) A structure erected over a depression or an obstacle such as a body of water, railroad, etc., to provide a roadway for vehicles or pedestrians.")]
	[CategoryOrder("Bridge",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BridgeViewModel : FeatureViewModel<Bridge> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}



		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public BridgeViewModel Load(Bridge instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Bridge {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Bridge Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Bridge.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.Bridge.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Bridge.featureBindingDefinitions;

		public BridgeViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public BridgeViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Bridge";

		public BridgeViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
		}
	}



	/// <summary>
	/// A heavy weight (of concrete, cast-iron, etc..) that rests on the sea bed and to which a mooring line can be attached. (IALA Dictionary, 8-5-025)
	/// </summary>
	[Description("A heavy weight (of concrete, cast-iron, etc..) that rests on the sea bed and to which a mooring line can be attached. (IALA Dictionary, 8-5-025)")]
	[CategoryOrder("SinkerAnchor",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SinkerAnchorViewModel : FeatureViewModel<SinkerAnchor> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private natureOfConstruction? _natureOfConstruction  = default;

		[Description("The building's primary construction material.")]
		[Category("SinkerAnchor")]
		//[Editor(typeof(Editors.HorizonEditor<SinkerAnchor>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public natureOfConstruction? natureOfConstruction {
			get {
				return _natureOfConstruction;
			}
			set {
				SetValue(ref _natureOfConstruction, value);
			}
		}

		private sinkerDimensionsViewModel? _sinkerDimensions  = default;

		[Description("The dimensions of a sinker/anchor to give its three dimensional shape measurements.")]
		[Category("SinkerAnchor")]
		[ExpandableObject]
		[Optional]
		public sinkerDimensionsViewModel? sinkerDimensions {
			get {
				return _sinkerDimensions;
			}
			set {
				SetValue(ref _sinkerDimensions, value);
			}
		}

		private double _weight  = default;

		[Description("-")]
		[Category("SinkerAnchor")]
		//[Editor(typeof(Editors.HorizonEditor<SinkerAnchor>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double weight {
			get {
				return _weight;
			}
			set {
				SetValue(ref _weight, value);
			}
		}

		private String? _sinkerType  = default;

		[Description("-")]
		[Category("SinkerAnchor")]
		//[Editor(typeof(Editors.HorizonEditor<SinkerAnchor>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? sinkerType {
			get {
				return _sinkerType;
			}
			set {
				SetValue(ref _sinkerType, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("ShackleToAnchorConnection","shackleToAnchorconnected",["MooringShackle"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> ShackleToAnchorConnections { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. ShackleToAnchorConnections.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.ShackleToAnchorConnection> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public SinkerAnchorViewModel Load(SinkerAnchor instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			natureOfConstruction = instance.natureOfConstruction;
			sinkerDimensions = new ();
			if (instance.sinkerDimensions != default) {
				sinkerDimensions.Load(instance.sinkerDimensions);
			}
			weight = instance.weight;
			sinkerType = instance.sinkerType;
			return this;
		}

		public override string Serialize() {
			var instance = new SinkerAnchor {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				natureOfConstruction = this.natureOfConstruction,
				sinkerDimensions = this.sinkerDimensions?.Model,
				weight = this.weight,
				sinkerType = this.sinkerType,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SinkerAnchor Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			natureOfConstruction = this._natureOfConstruction,
			sinkerDimensions = this._sinkerDimensions?.Model,
			weight = this._weight,
			sinkerType = this._sinkerType,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SinkerAnchor.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.SinkerAnchor.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SinkerAnchor.featureBindingDefinitions;

		public SinkerAnchorViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SinkerAnchorViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Sinker Anchor";

		public SinkerAnchorViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			ShackleToAnchorConnections.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ShackleToAnchorConnections));
			};
		}
	}



	/// <summary>
	/// A shackle at the lower end of a mooring chain, for attachment to an anchor or sinker. (IALA Dictionary, 8-5-150)
	/// </summary>
	[Description("A shackle at the lower end of a mooring chain, for attachment to an anchor or sinker. (IALA Dictionary, 8-5-150)")]
	[CategoryOrder("MooringShackle",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class MooringShackleViewModel : FeatureViewModel<MooringShackle> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private natureOfConstruction? _natureOfConstruction  = default;

		[Description("The building's primary construction material.")]
		[Category("MooringShackle")]
		//[Editor(typeof(Editors.HorizonEditor<MooringShackle>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public natureOfConstruction? natureOfConstruction {
			get {
				return _natureOfConstruction;
			}
			set {
				SetValue(ref _natureOfConstruction, value);
			}
		}

		private ShackleType? _ShackleType  = default;

		[Description("Types of shackle.")]
		[Category("MooringShackle")]
		//[Editor(typeof(Editors.HorizonEditor<MooringShackle>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6])]
		[Optional]
		public ShackleType? ShackleType {
			get {
				return _ShackleType;
			}
			set {
				SetValue(ref _ShackleType, value);
			}
		}

		private double? _weight  = default;

		[Description("-")]
		[Category("MooringShackle")]
		//[Editor(typeof(Editors.HorizonEditor<MooringShackle>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? weight {
			get {
				return _weight;
			}
			set {
				SetValue(ref _weight, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("ShackleConnection","shackleToBuoyconnectedTo",["GenericBuoy"], lower:0, upper:1)]
		public ObservableCollection<FeatureRefViewModel> ShackleConnections { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("ShackleToBridleConnection","shackleToBridleconnectedTo",["Bridle"], lower:0, upper:1)]
		public ObservableCollection<FeatureRefViewModel> ShackleToBridleConnections { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("BridleCableConnection","bridleattached",["CableSubmarine"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> BridleCableConnections { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("ShackleToSwivelConnection","shackleToSwivelconnectedTo",["Swivel"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> ShackleToSwivelConnections { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("ShackleToAnchorConnection","shackleToAnchorconnectedTo",["SinkerAnchor"], lower:0, upper:1)]
		public ObservableCollection<FeatureRefViewModel> ShackleToAnchorConnections { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. ShackleConnections.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.ShackleConnection> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. ShackleToBridleConnections.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.ShackleToBridleConnection> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. BridleCableConnections.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.BridleCableConnection> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. ShackleToSwivelConnections.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.ShackleToSwivelConnection> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. ShackleToAnchorConnections.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.ShackleToAnchorConnection> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public MooringShackleViewModel Load(MooringShackle instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			natureOfConstruction = instance.natureOfConstruction;
			ShackleType = instance.ShackleType;
			weight = instance.weight;
			return this;
		}

		public override string Serialize() {
			var instance = new MooringShackle {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				natureOfConstruction = this.natureOfConstruction,
				ShackleType = this.ShackleType,
				weight = this.weight,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public MooringShackle Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			natureOfConstruction = this._natureOfConstruction,
			ShackleType = this._ShackleType,
			weight = this._weight,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.MooringShackle.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.MooringShackle.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.MooringShackle.featureBindingDefinitions;

		public MooringShackleViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public MooringShackleViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Mooring Shackle";

		public MooringShackleViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			ShackleConnections.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ShackleConnections));
			};
			ShackleToBridleConnections.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ShackleToBridleConnections));
			};
			BridleCableConnections.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(BridleCableConnections));
			};
			ShackleToSwivelConnections.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ShackleToSwivelConnections));
			};
			ShackleToAnchorConnections.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ShackleToAnchorConnections));
			};
		}
	}



	/// <summary>
	/// An assembly of wires or fibres, or a wire rope or chain, which has been laid underwater or buried beneath the sea floor.
	/// </summary>
	[Description("An assembly of wires or fibres, or a wire rope or chain, which has been laid underwater or buried beneath the sea floor.")]
	[CategoryOrder("CableSubmarine",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CableSubmarineViewModel : FeatureViewModel<CableSubmarine> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private CableDimensionsViewModel? _CableDimensions  = default;

		[Description("The dimensions of a cable to give its length and diameter.")]
		[Category("CableSubmarine")]
		[ExpandableObject]
		[Optional]
		public CableDimensionsViewModel? CableDimensions {
			get {
				return _CableDimensions;
			}
			set {
				SetValue(ref _CableDimensions, value);
			}
		}

		private categoryOfCable _categoryOfCable  = default;

		[Description("Classification of the cable based on the services provided.")]
		[Category("CableSubmarine")]
		//[Editor(typeof(Editors.HorizonEditor<CableSubmarine>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,3,4,5,6,7,8])]
		[Mandatory]
		public categoryOfCable categoryOfCable {
			get {
				return _categoryOfCable;
			}
			set {
				SetValue(ref _categoryOfCable, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("CableSubmarine")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("BridleCableConnection","cableholds",["Bridle"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> BridleCableConnections { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("SwivelCableConnection","cableholds",["Swivel"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> SwivelCableConnections { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("ShackleConnectionFromCable","shackleToCableconnected",["MooringShackle"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> ShackleConnectionFromCables { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. BridleCableConnections.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.BridleCableConnection> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. SwivelCableConnections.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.SwivelCableConnection> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. ShackleConnectionFromCables.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.ShackleConnectionFromCable> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public CableSubmarineViewModel Load(CableSubmarine instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			CableDimensions = new ();
			if (instance.CableDimensions != default) {
				CableDimensions.Load(instance.CableDimensions);
			}
			categoryOfCable = instance.categoryOfCable;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new CableSubmarine {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				CableDimensions = this.CableDimensions?.Model,
				categoryOfCable = this.categoryOfCable,
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CableSubmarine Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			CableDimensions = this._CableDimensions?.Model,
			categoryOfCable = this._categoryOfCable,
			status = this.status.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.CableSubmarine.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.CableSubmarine.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.CableSubmarine.featureBindingDefinitions;

		public CableSubmarineViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public CableSubmarineViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Cable Submarine";

		public CableSubmarineViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			BridleCableConnections.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(BridleCableConnections));
			};
			SwivelCableConnections.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(SwivelCableConnections));
			};
			ShackleConnectionFromCables.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ShackleConnectionFromCables));
			};
		}
	}



	/// <summary>
	/// A chain link that provides for rotary motion between the lengths of chain that it connects. (IALA Dictionary, 8-5-165)
	/// </summary>
	[Description("A chain link that provides for rotary motion between the lengths of chain that it connects. (IALA Dictionary, 8-5-165)")]
	[CategoryOrder("Swivel",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SwivelViewModel : FeatureViewModel<Swivel> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private natureOfConstruction? _natureOfConstruction  = default;

		[Description("The building's primary construction material.")]
		[Category("Swivel")]
		//[Editor(typeof(Editors.HorizonEditor<Swivel>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public natureOfConstruction? natureOfConstruction {
			get {
				return _natureOfConstruction;
			}
			set {
				SetValue(ref _natureOfConstruction, value);
			}
		}

		private double? _weight  = default;

		[Description("-")]
		[Category("Swivel")]
		//[Editor(typeof(Editors.HorizonEditor<Swivel>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? weight {
			get {
				return _weight;
			}
			set {
				SetValue(ref _weight, value);
			}
		}

		private String? _swivelType  = default;

		[Description("-")]
		[Category("Swivel")]
		//[Editor(typeof(Editors.HorizonEditor<Swivel>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? swivelType {
			get {
				return _swivelType;
			}
			set {
				SetValue(ref _swivelType, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("SwivelConnection","swivelholds",["Bridle"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> SwivelConnections { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("SwivelCableConnection","swivelattached",["CableSubmarine"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> SwivelCableConnections { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("ShackleToSwivelConnection","shackleToSwivelconnected",["MooringShackle"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> ShackleToSwivelConnections { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. SwivelConnections.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.SwivelConnection> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. SwivelCableConnections.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.SwivelCableConnection> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. ShackleToSwivelConnections.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.ShackleToSwivelConnection> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public SwivelViewModel Load(Swivel instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			natureOfConstruction = instance.natureOfConstruction;
			weight = instance.weight;
			swivelType = instance.swivelType;
			return this;
		}

		public override string Serialize() {
			var instance = new Swivel {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				natureOfConstruction = this.natureOfConstruction,
				weight = this.weight,
				swivelType = this.swivelType,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Swivel Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			natureOfConstruction = this._natureOfConstruction,
			weight = this._weight,
			swivelType = this._swivelType,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Swivel.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.Swivel.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Swivel.featureBindingDefinitions;

		public SwivelViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SwivelViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Swivel";

		public SwivelViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			SwivelConnections.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(SwivelConnections));
			};
			SwivelCableConnections.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(SwivelCableConnections));
			};
			ShackleToSwivelConnections.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ShackleToSwivelConnections));
			};
		}
	}



	/// <summary>
	/// Two lengths of chain connected by a central ring and used for lifting wide loads. (IALA Dictionary,8-3-195)
	/// </summary>
	[Description("Two lengths of chain connected by a central ring and used for lifting wide loads. (IALA Dictionary,8-3-195)")]
	[CategoryOrder("Bridle",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BridleViewModel : FeatureViewModel<Bridle> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String? _bridleLinkType  = default;

		[Description("-")]
		[Category("Bridle")]
		//[Editor(typeof(Editors.HorizonEditor<Bridle>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? bridleLinkType {
			get {
				return _bridleLinkType;
			}
			set {
				SetValue(ref _bridleLinkType, value);
			}
		}

		private String? _legsDetails  = default;

		[Description("-")]
		[Category("Bridle")]
		//[Editor(typeof(Editors.HorizonEditor<Bridle>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? legsDetails {
			get {
				return _legsDetails;
			}
			set {
				SetValue(ref _legsDetails, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("BridleConnection","bridleholds",["GenericBuoy"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> BridleConnections { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("SwivelConnection","bridlehangs",["Swivel"], lower:0, upper:1)]
		public ObservableCollection<FeatureRefViewModel> SwivelConnections { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("ShackleToBridleConnection","shackleToBridleconnected",["MooringShackle"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> ShackleToBridleConnections { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("BridleCableConnection","bridleattached",["CableSubmarine"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> BridleCableConnections { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. BridleConnections.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.BridleConnection> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. SwivelConnections.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.SwivelConnection> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. ShackleToBridleConnections.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.ShackleToBridleConnection> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. BridleCableConnections.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.BridleCableConnection> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public BridleViewModel Load(Bridle instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			bridleLinkType = instance.bridleLinkType;
			legsDetails = instance.legsDetails;
			return this;
		}

		public override string Serialize() {
			var instance = new Bridle {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				bridleLinkType = this.bridleLinkType,
				legsDetails = this.legsDetails,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Bridle Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			bridleLinkType = this._bridleLinkType,
			legsDetails = this._legsDetails,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Bridle.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.Bridle.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Bridle.featureBindingDefinitions;

		public BridleViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public BridleViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Bridle";

		public BridleViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			BridleConnections.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(BridleConnections));
			};
			SwivelConnections.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(SwivelConnections));
			};
			ShackleToBridleConnections.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(ShackleToBridleConnections));
			};
			BridleCableConnections.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(BridleCableConnections));
			};
		}
	}



	/// <summary>
	/// -
	/// </summary>
	[Description("-")]
	[CategoryOrder("CounterWeight",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CounterWeightViewModel : FeatureViewModel<CounterWeight> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private natureOfConstruction? _natureOfConstruction  = default;

		[Description("The building's primary construction material.")]
		[Category("CounterWeight")]
		//[Editor(typeof(Editors.HorizonEditor<CounterWeight>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public natureOfConstruction? natureOfConstruction {
			get {
				return _natureOfConstruction;
			}
			set {
				SetValue(ref _natureOfConstruction, value);
			}
		}

		private double _weight  = default;

		[Description("-")]
		[Category("CounterWeight")]
		//[Editor(typeof(Editors.HorizonEditor<CounterWeight>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double weight {
			get {
				return _weight;
			}
			set {
				SetValue(ref _weight, value);
			}
		}

		private String? _counterWeightType  = default;

		[Description("-")]
		[Category("CounterWeight")]
		//[Editor(typeof(Editors.HorizonEditor<CounterWeight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? counterWeightType {
			get {
				return _counterWeightType;
			}
			set {
				SetValue(ref _counterWeightType, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("BuoyCounterWeight","counterWeightholds",["GenericBuoy"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> BuoyCounterWeights { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. BuoyCounterWeights.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.BuoyCounterWeight> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public CounterWeightViewModel Load(CounterWeight instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			natureOfConstruction = instance.natureOfConstruction;
			weight = instance.weight;
			counterWeightType = instance.counterWeightType;
			return this;
		}

		public override string Serialize() {
			var instance = new CounterWeight {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				natureOfConstruction = this.natureOfConstruction,
				weight = this.weight,
				counterWeightType = this.counterWeightType,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CounterWeight Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			natureOfConstruction = this._natureOfConstruction,
			weight = this._weight,
			counterWeightType = this._counterWeightType,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.CounterWeight.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.CounterWeight.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.CounterWeight.featureBindingDefinitions;

		public CounterWeightViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public CounterWeightViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Counter Weight";

		public CounterWeightViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			BuoyCounterWeights.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(BuoyCounterWeights));
			};
		}
	}



	/// <summary>
	/// A characteristic shape secured at the top of a buoy or beacon to aid in its identification. (IHO Dictionary, S-32, 5th Edition, 5548)
	/// </summary>
	[Description("A characteristic shape secured at the top of a buoy or beacon to aid in its identification. (IHO Dictionary, S-32, 5th Edition, 5548)")]
	[CategoryOrder("Topmark",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TopmarkViewModel : FeatureViewModel<Topmark> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("Topmark")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("Topmark")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Description("The condition of an object at a given instant in time.")]
		[Category("Topmark")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private topmarkDaymarkShape _topmarkDaymarkShape  = default;

		[Description("The shape a topmark or daymark exhibits.")]
		[Category("Topmark")]
		//[Editor(typeof(Editors.HorizonEditor<Topmark>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34])]
		[Mandatory]
		public topmarkDaymarkShape topmarkDaymarkShape {
			get {
				return _topmarkDaymarkShape;
			}
			set {
				SetValue(ref _topmarkDaymarkShape, value);
			}
		}

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("Topmark")]
		//[Editor(typeof(Editors.HorizonEditor<Topmark>), typeof(Editors.HorizonEditor))]
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


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("BuoyTopmark","buoyPart",["GenericBuoy"], lower:1, upper:1)]
		public ObservableCollection<FeatureRefViewModel> BuoyTopmarks { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. BuoyTopmarks.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.BuoyTopmark> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public TopmarkViewModel Load(Topmark instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			topmarkDaymarkShape = instance.topmarkDaymarkShape;
			verticalLength = instance.verticalLength;
			return this;
		}

		public override string Serialize() {
			var instance = new Topmark {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				status = this.status.ToList(),
				topmarkDaymarkShape = this.topmarkDaymarkShape,
				verticalLength = this.verticalLength,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Topmark Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			status = this.status.ToList(),
			topmarkDaymarkShape = this._topmarkDaymarkShape,
			verticalLength = this._verticalLength,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Topmark.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.Topmark.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Topmark.featureBindingDefinitions;

		public TopmarkViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public TopmarkViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Topmark";

		public TopmarkViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			BuoyTopmarks.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(BuoyTopmarks));
			};
		}
	}



	/// <summary>
	/// A safe water beacon is used to indicate that there is navigable water around the mark.
	/// </summary>
	[Description("A safe water beacon is used to indicate that there is navigable water around the mark.")]
	[CategoryOrder("SafeWaterBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SafeWaterBeaconViewModel : FeatureViewModel<SafeWaterBeacon> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private beaconShape _beaconShape  = default;

		[Description("Describes the characteristic geometric form of the beacon.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7])]
		[Mandatory]
		public beaconShape beaconShape {
			get {
				return _beaconShape;
			}
			set {
				SetValue(ref _beaconShape, value);
			}
		}

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		private double? _elevation  = default;

		[Description("The altitude of the ground level of an object, measured from a specified vertical datum.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the object, measured from a specified vertical datum.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,14,15])]
		[Optional]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Description("The building's primary construction material.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Description("A feature which returns a strong radar echo.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private visualProminence? _visualProminence  = default;

		[Description("The extent to which a feature, either natural or artificial, is visible from seaward.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public visualProminence? visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}



		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public SafeWaterBeaconViewModel Load(SafeWaterBeacon instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			beaconShape = instance.beaconShape;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			elevation = instance.elevation;
			height = instance.height;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalLength = instance.verticalLength;
			visualProminence = instance.visualProminence;
			verticalAccuracy = instance.verticalAccuracy;
			return this;
		}

		public override string Serialize() {
			var instance = new SafeWaterBeacon {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
				beaconShape = this.beaconShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				elevation = this.elevation,
				height = this.height,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous,
				status = this.status.ToList(),
				verticalLength = this.verticalLength,
				visualProminence = this.visualProminence,
				verticalAccuracy = this.verticalAccuracy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SafeWaterBeacon Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
			beaconShape = this._beaconShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			elevation = this._elevation,
			height = this._height,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this._radarConspicuous,
			status = this.status.ToList(),
			verticalLength = this._verticalLength,
			visualProminence = this._visualProminence,
			verticalAccuracy = this._verticalAccuracy,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SafeWaterBeacon.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.SafeWaterBeacon.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SafeWaterBeacon.featureBindingDefinitions;

		public SafeWaterBeaconViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SafeWaterBeaconViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Safe Water Beacon";

		public SafeWaterBeaconViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A special purpose beacon is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notices to Mariners.
	/// </summary>
	[Description("A special purpose beacon is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notices to Mariners.")]
	[CategoryOrder("SpecialPurposeGeneralBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SpecialPurposeGeneralBeaconViewModel : FeatureViewModel<SpecialPurposeGeneralBeacon> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private beaconShape _beaconShape  = default;

		[Description("Describes the characteristic geometric form of the beacon.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7])]
		[Mandatory]
		public beaconShape beaconShape {
			get {
				return _beaconShape;
			}
			set {
				SetValue(ref _beaconShape, value);
			}
		}

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		private double? _elevation  = default;

		[Description("The altitude of the ground level of an object, measured from a specified vertical datum.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}

		private double? _height  = default;

		[Description("The value of the vertical distance to the highest point of the object, measured from a specified vertical datum.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,14,15])]
		[Optional]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Description("The building's primary construction material.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Description("A feature which returns a strong radar echo.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private visualProminence? _visualProminence  = default;

		[Description("The extent to which a feature, either natural or artificial, is visible from seaward.")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public visualProminence? visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("GenericBeacon")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}

		[Description("Classification of an aid to navigation which signifies some special purpose.")]
		[Category("SpecialPurposeGeneralBeacon")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67])]
		[Multiplicity(1)]
		public ObservableCollection<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public SpecialPurposeGeneralBeaconViewModel Load(SpecialPurposeGeneralBeacon instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			beaconShape = instance.beaconShape;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			elevation = instance.elevation;
			height = instance.height;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalLength = instance.verticalLength;
			visualProminence = instance.visualProminence;
			verticalAccuracy = instance.verticalAccuracy;
			categoryOfSpecialPurposeMark.Clear();
			if (instance.categoryOfSpecialPurposeMark is not null) {
				foreach(var e in instance.categoryOfSpecialPurposeMark)
					categoryOfSpecialPurposeMark.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new SpecialPurposeGeneralBeacon {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
				beaconShape = this.beaconShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				elevation = this.elevation,
				height = this.height,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous,
				status = this.status.ToList(),
				verticalLength = this.verticalLength,
				visualProminence = this.visualProminence,
				verticalAccuracy = this.verticalAccuracy,
				categoryOfSpecialPurposeMark = this.categoryOfSpecialPurposeMark.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SpecialPurposeGeneralBeacon Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
			beaconShape = this._beaconShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			elevation = this._elevation,
			height = this._height,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this._radarConspicuous,
			status = this.status.ToList(),
			verticalLength = this._verticalLength,
			visualProminence = this._visualProminence,
			verticalAccuracy = this._verticalAccuracy,
			categoryOfSpecialPurposeMark = this.categoryOfSpecialPurposeMark.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SpecialPurposeGeneralBeacon.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.SpecialPurposeGeneralBeacon.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SpecialPurposeGeneralBeacon.featureBindingDefinitions;

		public SpecialPurposeGeneralBeaconViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SpecialPurposeGeneralBeaconViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Special Purpose General Beacon";

		public SpecialPurposeGeneralBeaconViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			categoryOfSpecialPurposeMark.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfSpecialPurposeMark));
			};
		}
	}



	/// <summary>
	/// A safe water buoy is used to indicate that there is navigable water around the mark.
	/// </summary>
	[Description("A safe water buoy is used to indicate that there is navigable water around the mark.")]
	[CategoryOrder("SafeWaterBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SafeWaterBuoyViewModel : FeatureViewModel<SafeWaterBuoy> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private buoyShape _buoyShape  = default;

		[Description("The principal shape and/or design of a buoy.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8])]
		[Mandatory]
		public buoyShape buoyShape {
			get {
				return _buoyShape;
			}
			set {
				SetValue(ref _buoyShape, value);
			}
		}

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,14,15])]
		[Optional]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Description("The building's primary construction material.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Description("A feature which returns a strong radar echo.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private String? _typeOfBuoy  = default;

		[Description("Type equipment used as a buoy in a particular installation.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}



		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public SafeWaterBuoyViewModel Load(SafeWaterBuoy instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			buoyShape = instance.buoyShape;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			typeOfBuoy = instance.typeOfBuoy;
			verticalLength = instance.verticalLength;
			verticalAccuracy = instance.verticalAccuracy;
			return this;
		}

		public override string Serialize() {
			var instance = new SafeWaterBuoy {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
				buoyShape = this.buoyShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous,
				status = this.status.ToList(),
				typeOfBuoy = this.typeOfBuoy,
				verticalLength = this.verticalLength,
				verticalAccuracy = this.verticalAccuracy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SafeWaterBuoy Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this._radarConspicuous,
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
			verticalLength = this._verticalLength,
			verticalAccuracy = this._verticalAccuracy,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SafeWaterBuoy.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.SafeWaterBuoy.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SafeWaterBuoy.featureBindingDefinitions;

		public SafeWaterBuoyViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SafeWaterBuoyViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Safe Water Buoy";

		public SafeWaterBuoyViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A special purpose buoy is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notices to Mariners.
	/// </summary>
	[Description("A special purpose buoy is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notices to Mariners.")]
	[CategoryOrder("SpecialPurposeGeneralBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SpecialPurposeGeneralBuoyViewModel : FeatureViewModel<SpecialPurposeGeneralBuoy> {
		private String? _iDCode  = default;

		[Description("Identification code as specified in predefined system. Also called identification number.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Description("Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Description("The minimum scale at which the feature may be used for example for ECDIS presentation.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private DateOnly? _sourceDate  = default;

		[Description("The production date of the source; for example the date of measurement.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}

		private String? _source  = default;

		[Description("The publication, document, or reference work from which information comes or is acquired.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Description("Indicates whether a pictorial representation of the feature is available.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _inspectionFrequency  = default;

		[Description("A statement of how frequently an item is inspected.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}

		private String? _inspectionRequirements  = default;

		[Description("A statement of what requirements are in place for how inspection of an item is carried out.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}

		private String? _aToNMaintenanceRecord  = default;

		[Description("A reference following the Uniform Resource Identifier (URI) principles to a record of maintenance.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Description("The date when an item was installed.")]
		[Category("AidsToNavigation")]
		//[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Description("An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.")]
		[Category("AidsToNavigation")]
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

		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Description("The active period of a recurring event or occurrence.")]
		[Category("AidsToNavigation")]
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

		[Description("-")]
		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Description("Identifier from a list of Aids to Navigation publication, such as List of Lights.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Description("A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3])]
		[Optional]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		private condition? _condition  = default;

		[Description("The various conditions of buildings and other constructions.")]
		[Category("StructureObject")]
		//[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5])]
		[Optional]
		public condition? condition {
			get {
				return _condition;
			}
			set {
				SetValue(ref _condition, value);
			}
		}

		private contactAddressViewModel? _contactAddress  = default;

		[Description("Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.")]
		[Category("StructureObject")]
		[ExpandableObject]
		[Optional]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private buoyShape _buoyShape  = default;

		[Description("The principal shape and/or design of a buoy.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6,7,8])]
		[Mandatory]
		public buoyShape buoyShape {
			get {
				return _buoyShape;
			}
			set {
				SetValue(ref _buoyShape, value);
			}
		}

		[Description("The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Description("A regular repeated design containing more than one colour.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9])]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,14,15])]
		[Optional]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Description("The building's primary construction material.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Description("A feature which returns a strong radar echo.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Description("The condition of an object at a given instant in time.")]
		[Category("GenericBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		private String? _typeOfBuoy  = default;

		[Description("Type equipment used as a buoy in a particular installation.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}

		private double? _verticalLength  = default;

		[Description("The total vertical length of a feature.")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private double? _verticalAccuracy  = default;

		[Description("-")]
		[Category("GenericBuoy")]
		//[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}

		[Description("Classification of an aid to navigation which signifies some special purpose.")]
		[Category("SpecialPurposeGeneralBuoy")]
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67])]
		[Multiplicity(1)]
		public ObservableCollection<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public SpecialPurposeGeneralBuoyViewModel Load(SpecialPurposeGeneralBuoy instance) {
			iDCode = instance.iDCode;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceDate = instance.sourceDate;
			source = instance.source;
			pictorialRepresentation = instance.pictorialRepresentation;
			inspectionFrequency = instance.inspectionFrequency;
			inspectionRequirements = instance.inspectionRequirements;
			aToNMaintenanceRecord = instance.aToNMaintenanceRecord;
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			SeasonalActionRequired.Clear();
			if (instance.SeasonalActionRequired is not null) {
				foreach(var e in instance.SeasonalActionRequired)
					SeasonalActionRequired.Add(e);
			}
			AtoNNumber = instance.AtoNNumber;
			aidAvailabilityCategory = instance.aidAvailabilityCategory;
			condition = instance.condition;
			contactAddress = new ();
			if (instance.contactAddress != default) {
				contactAddress.Load(instance.contactAddress);
			}
			buoyShape = instance.buoyShape;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern.Clear();
			if (instance.colourPattern is not null) {
				foreach(var e in instance.colourPattern)
					colourPattern.Add(e);
			}
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			typeOfBuoy = instance.typeOfBuoy;
			verticalLength = instance.verticalLength;
			verticalAccuracy = instance.verticalAccuracy;
			categoryOfSpecialPurposeMark.Clear();
			if (instance.categoryOfSpecialPurposeMark is not null) {
				foreach(var e in instance.categoryOfSpecialPurposeMark)
					categoryOfSpecialPurposeMark.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new SpecialPurposeGeneralBuoy {
				iDCode = this.iDCode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				inspectionFrequency = this.inspectionFrequency,
				inspectionRequirements = this.inspectionRequirements,
				aToNMaintenanceRecord = this.aToNMaintenanceRecord,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
				AtoNNumber = this.AtoNNumber,
				aidAvailabilityCategory = this.aidAvailabilityCategory,
				condition = this.condition,
				contactAddress = this.contactAddress?.Model,
				buoyShape = this.buoyShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous,
				status = this.status.ToList(),
				typeOfBuoy = this.typeOfBuoy,
				verticalLength = this.verticalLength,
				verticalAccuracy = this.verticalAccuracy,
				categoryOfSpecialPurposeMark = this.categoryOfSpecialPurposeMark.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SpecialPurposeGeneralBuoy Model => new () {
			iDCode = this._iDCode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			inspectionFrequency = this._inspectionFrequency,
			inspectionRequirements = this._inspectionRequirements,
			aToNMaintenanceRecord = this._aToNMaintenanceRecord,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			SeasonalActionRequired = this.SeasonalActionRequired.ToList(),
			AtoNNumber = this._AtoNNumber,
			aidAvailabilityCategory = this._aidAvailabilityCategory,
			condition = this._condition,
			contactAddress = this._contactAddress?.Model,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this._radarConspicuous,
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
			verticalLength = this._verticalLength,
			verticalAccuracy = this._verticalAccuracy,
			categoryOfSpecialPurposeMark = this.categoryOfSpecialPurposeMark.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SpecialPurposeGeneralBuoy.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.SpecialPurposeGeneralBuoy.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SpecialPurposeGeneralBuoy.featureBindingDefinitions;

		public SpecialPurposeGeneralBuoyViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SpecialPurposeGeneralBuoyViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Special Purpose General Buoy";

		public SpecialPurposeGeneralBuoyViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			SeasonalActionRequired.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(SeasonalActionRequired));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			categoryOfSpecialPurposeMark.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfSpecialPurposeMark));
			};
		}
	}



	/// <summary>
	/// -
	/// </summary>
	[Description("-")]
	[CategoryOrder("DangerousFeature",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DangerousFeatureViewModel : FeatureViewModel<DangerousFeature> {
		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("DangerousFeature")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("DangerousFeatureAssociation","markingAton",["AtonAssociation"], lower:1, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> DangerousFeatureAssociations { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. DangerousFeatureAssociations.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.DangerousFeatureAssociation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public DangerousFeatureViewModel Load(DangerousFeature instance) {
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new DangerousFeature {
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DangerousFeature Model => new () {
			information = this.information.Select(e => e.Model).ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.DangerousFeature.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.DangerousFeature.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.DangerousFeature.featureBindingDefinitions;

		public DangerousFeatureViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public DangerousFeatureViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Dangerous Feature";

		public DangerousFeatureViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			DangerousFeatureAssociations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(DangerousFeatureAssociations));
			};
		}
	}



	/// <summary>
	/// Used to identify an aggregation of two or more objects. This aggregation may be named content of categoryOfAggregation should be put in information attribute when converting to S-57.
	/// </summary>
	[Description("Used to identify an aggregation of two or more objects. This aggregation may be named content of categoryOfAggregation should be put in information attribute when converting to S-57.")]
	[CategoryOrder("AtonAggregation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonAggregationViewModel : FeatureViewModel<AtonAggregation> {
		private CategoryOfAggregation _CategoryOfAggregation  = default;

		[Description("named aggregations between two or more aids to navigation and/or navigationally relevant features")]
		[Category("AtonAggregation")]
		//[Editor(typeof(Editors.HorizonEditor<AtonAggregation>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,3,2])]
		[Mandatory]
		public CategoryOfAggregation CategoryOfAggregation {
			get {
				return _CategoryOfAggregation;
			}
			set {
				SetValue(ref _CategoryOfAggregation, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("AtonAggregations","atonAggregationBy",["AidsToNavigation"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> AtonAggregations { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. AtonAggregations.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.AtonAggregations> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public AtonAggregationViewModel Load(AtonAggregation instance) {
			CategoryOfAggregation = instance.CategoryOfAggregation;
			return this;
		}

		public override string Serialize() {
			var instance = new AtonAggregation {
				CategoryOfAggregation = this.CategoryOfAggregation,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AtonAggregation Model => new () {
			CategoryOfAggregation = this._CategoryOfAggregation,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.AtonAggregation.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.AtonAggregation.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.AtonAggregation.featureBindingDefinitions;

		public AtonAggregationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public AtonAggregationViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Aton Aggregation";

		public AtonAggregationViewModel() : base() {
			AtonAggregations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(AtonAggregations));
			};
		}
	}



	/// <summary>
	/// Used to identify an association between two or more objects. The association may be named content of categoryOfAssociation should be put in information attribute when converting to S-57
	/// </summary>
	[Description("Used to identify an association between two or more objects. The association may be named content of categoryOfAssociation should be put in information attribute when converting to S-57")]
	[CategoryOrder("AtonAssociation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonAssociationViewModel : FeatureViewModel<AtonAssociation> {
		private CategoryOfAssociation _CategoryOfAssociation  = default;

		[Description("named associations between two or more aids to navigation and/or navigationally relevant features")]
		[Category("AtonAssociation")]
		//[Editor(typeof(Editors.HorizonEditor<AtonAssociation>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2])]
		[Mandatory]
		public CategoryOfAssociation CategoryOfAssociation {
			get {
				return _CategoryOfAssociation;
			}
			set {
				SetValue(ref _CategoryOfAssociation, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		#region FeatureBindings

		[Category("FeatureBindings")]
		[FeatureBinding("DangerousFeatureAssociation","danger",["DangerousFeature"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> DangerousFeatureAssociations { get; set; } = new();

		[Category("FeatureBindings")]
		[FeatureBinding("AtonAssociations","atonAssociationBy",["AidsToNavigation"], lower:0, upper:2147483647)]
		public ObservableCollection<FeatureRefViewModel> AtonAssociations { get; set; } = new();

		public override featureBinding[] GetFeatureBindings() => [
			.. DangerousFeatureAssociations.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.DangerousFeatureAssociation> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
			.. AtonAssociations.Select(e => new featureBinding<DomainModel.S201.FeatureAssociations.AtonAssociations> {
				featureType = e.featureType, referenceId = e.featureId, role = e.role,}),
		];
		#endregion

		public AtonAssociationViewModel Load(AtonAssociation instance) {
			CategoryOfAssociation = instance.CategoryOfAssociation;
			return this;
		}

		public override string Serialize() {
			var instance = new AtonAssociation {
				CategoryOfAssociation = this.CategoryOfAssociation,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AtonAssociation Model => new () {
			CategoryOfAssociation = this._CategoryOfAssociation,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.AtonAssociation.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.AtonAssociation.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.AtonAssociation.featureBindingDefinitions;

		public AtonAssociationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public AtonAssociationViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Aton Association";

		public AtonAssociationViewModel() : base() {
			DangerousFeatureAssociations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(DangerousFeatureAssociations));
			};
			AtonAssociations.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(AtonAssociations));
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
		private categoryOfTemporalVariation _categoryOfTemporalVariation  = default;

		[Description("An assessment of the likelihood of change over time.")]
		[Category("QualityOfNonBathymetricData")]
		//[Editor(typeof(Editors.HorizonEditor<QualityOfNonBathymetricData>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,3,4,5,6])]
		[Mandatory]
		public categoryOfTemporalVariation categoryOfTemporalVariation {
			get {
				return _categoryOfTemporalVariation;
			}
			set {
				SetValue(ref _categoryOfTemporalVariation, value);
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

		private horizontalPositionUncertaintyViewModel _horizontalPositionUncertainty  = default;

		[Description("The best estimate of the accuracy of a position.")]
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

		private informationViewModel? _information  = default;

		[Description("Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.")]
		[Category("QualityOfNonBathymetricData")]
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

		private String? _informationInNationalLanguage  = default;

		[Description("Textual information in national language characters.")]
		[Category("QualityOfNonBathymetricData")]
		//[Editor(typeof(Editors.HorizonEditor<QualityOfNonBathymetricData>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? informationInNationalLanguage {
			get {
				return _informationInNationalLanguage;
			}
			set {
				SetValue(ref _informationInNationalLanguage, value);
			}
		}

		private textualDescriptionViewModel? _textualDescription  = default;

		[Description("Encodes the file name of a single external text file that contains the text in a defined language, which provides additional textual information that cannot be provided using other allowable attributes for the feature.")]
		[Category("QualityOfNonBathymetricData")]
		[ExpandableObject]
		[Optional]
		public textualDescriptionViewModel? textualDescription {
			get {
				return _textualDescription;
			}
			set {
				SetValue(ref _textualDescription, value);
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


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public QualityOfNonBathymetricDataViewModel Load(QualityOfNonBathymetricData instance) {
			categoryOfTemporalVariation = instance.categoryOfTemporalVariation;
			orientationUncertainty = instance.orientationUncertainty;
			horizontalDistanceUncertainty = instance.horizontalDistanceUncertainty;
			horizontalPositionUncertainty = new ();
			if (instance.horizontalPositionUncertainty != default) {
				horizontalPositionUncertainty.Load(instance.horizontalPositionUncertainty);
			}
			information = new ();
			if (instance.information != default) {
				information.Load(instance.information);
			}
			informationInNationalLanguage = instance.informationInNationalLanguage;
			textualDescription = new ();
			if (instance.textualDescription != default) {
				textualDescription.Load(instance.textualDescription);
			}
			verticalUncertainty = new ();
			if (instance.verticalUncertainty != default) {
				verticalUncertainty.Load(instance.verticalUncertainty);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new QualityOfNonBathymetricData {
				categoryOfTemporalVariation = this.categoryOfTemporalVariation,
				orientationUncertainty = this.orientationUncertainty,
				horizontalDistanceUncertainty = this.horizontalDistanceUncertainty,
				horizontalPositionUncertainty = this.horizontalPositionUncertainty?.Model,
				information = this.information?.Model,
				informationInNationalLanguage = this.informationInNationalLanguage,
				textualDescription = this.textualDescription?.Model,
				verticalUncertainty = this.verticalUncertainty?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public QualityOfNonBathymetricData Model => new () {
			categoryOfTemporalVariation = this._categoryOfTemporalVariation,
			orientationUncertainty = this._orientationUncertainty,
			horizontalDistanceUncertainty = this._horizontalDistanceUncertainty,
			horizontalPositionUncertainty = this._horizontalPositionUncertainty?.Model,
			information = this._information?.Model,
			informationInNationalLanguage = this._informationInNationalLanguage,
			textualDescription = this._textualDescription?.Model,
			verticalUncertainty = this._verticalUncertainty?.Model,
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

		[Description("The value considered by the Data Producer to be the maximum (largest) scale at which the data is to be displayed before it can be considered to be “grossly overscaled”.")]
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


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public DataCoverageViewModel Load(DataCoverage instance) {
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
	}



	/// <summary>
	/// An area within which the navigational system of marks has been established in relation to a specific direction.
	/// </summary>
	[Description("An area within which the navigational system of marks has been established in relation to a specific direction.")]
	[CategoryOrder("LocalDirectionOfBuoyage",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LocalDirectionOfBuoyageViewModel : FeatureViewModel<LocalDirectionOfBuoyage> {
		private orientationViewModel _orientation  = default;

		[Description("(1) The angular distance measured from true north to the major axis of the feature. (2) In ECDIS, the mode in which information on the ECDIS is being presented. Typical modes include: north-up - as shown on a nautical chart, north is at the top of the display; Ships head-up - based on the actual heading of the ship, (e.g. Ships gyrocompass); course-up display - based on the course or route being taken.")]
		[Category("LocalDirectionOfBuoyage")]
		[ExpandableObject]
		[Mandatory]
		public orientationViewModel orientation {
			get {
				return _orientation;
			}
			set {
				SetValue(ref _orientation, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public LocalDirectionOfBuoyageViewModel Load(LocalDirectionOfBuoyage instance) {
			orientation = new ();
			if (instance.orientation != default) {
				orientation.Load(instance.orientation);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new LocalDirectionOfBuoyage {
				orientation = this.orientation?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LocalDirectionOfBuoyage Model => new () {
			orientation = this._orientation?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LocalDirectionOfBuoyage.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.LocalDirectionOfBuoyage.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LocalDirectionOfBuoyage.featureBindingDefinitions;

		public LocalDirectionOfBuoyageViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public LocalDirectionOfBuoyageViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Local Direction of Buoyage";
	}



	/// <summary>
	/// An area within which the navigational system of marks has been established in relation to a specific direction.
	/// </summary>
	[Description("An area within which the navigational system of marks has been established in relation to a specific direction.")]
	[CategoryOrder("NavigationalSystemOfMarks",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NavigationalSystemOfMarksViewModel : FeatureViewModel<NavigationalSystemOfMarks> {
		private marksNavigationalSystemOf _marksNavigationalSystemOf  = default;

		[Description("The system of navigational buoyage a region complies with.")]
		[Category("NavigationalSystemOfMarks")]
		//[Editor(typeof(Editors.HorizonEditor<NavigationalSystemOfMarks>), typeof(Editors.HorizonEditor))]
		[PermittedValues([1,2,9,10,11,12,13,15])]
		[Mandatory]
		public marksNavigationalSystemOf marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public NavigationalSystemOfMarksViewModel Load(NavigationalSystemOfMarks instance) {
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			return this;
		}

		public override string Serialize() {
			var instance = new NavigationalSystemOfMarks {
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public NavigationalSystemOfMarks Model => new () {
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.NavigationalSystemOfMarks.informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InformationBindings.NavigationalSystemOfMarks.informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.NavigationalSystemOfMarks.featureBindingDefinitions;

		public NavigationalSystemOfMarksViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public NavigationalSystemOfMarksViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Navigational System of Marks";
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
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
		[Mandatory]
		public verticalDatum verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public SoundingDatumViewModel Load(SoundingDatum instance) {
			verticalDatum = instance.verticalDatum;
			return this;
		}

		public override string Serialize() {
			var instance = new SoundingDatum {
				verticalDatum = this.verticalDatum,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SoundingDatum Model => new () {
			verticalDatum = this._verticalDatum,
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
		[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
		[Mandatory]
		public verticalDatum verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}


		public override informationBinding[] GetInformationBindings() => [];


		public override featureBinding[] GetFeatureBindings() => [];

		public VerticalDatumOfDataViewModel Load(VerticalDatumOfData instance) {
			verticalDatum = instance.verticalDatum;
			return this;
		}

		public override string Serialize() {
			var instance = new VerticalDatumOfData {
				verticalDatum = this.verticalDatum,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public VerticalDatumOfData Model => new () {
			verticalDatum = this._verticalDatum,
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
	}



	public static class InformationBindingExtension {
		public static AtoNFixingMethodViewModel LoadInformationBinding(this AtoNFixingMethodViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static AtonStatusInformationViewModel LoadInformationBinding(this AtonStatusInformationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static PositioningInformationViewModel LoadInformationBinding(this PositioningInformationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SpatialQualityViewModel LoadInformationBinding(this SpatialQualityViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LandmarkViewModel LoadInformationBinding(this LandmarkViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LateralBeaconViewModel LoadInformationBinding(this LateralBeaconViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LateralBuoyViewModel LoadInformationBinding(this LateralBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static NavigationLineViewModel LoadInformationBinding(this NavigationLineViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RecommendedTrackViewModel LoadInformationBinding(this RecommendedTrackViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LightSectoredViewModel LoadInformationBinding(this LightSectoredViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LightAllAroundViewModel LoadInformationBinding(this LightAllAroundViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LightAirObstructionViewModel LoadInformationBinding(this LightAirObstructionViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LightFogDetectorViewModel LoadInformationBinding(this LightFogDetectorViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RadarReflectorViewModel LoadInformationBinding(this RadarReflectorViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static FogSignalViewModel LoadInformationBinding(this FogSignalViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static EnvironmentObservationEquipmentViewModel LoadInformationBinding(this EnvironmentObservationEquipmentViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RadioStationViewModel LoadInformationBinding(this RadioStationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DaymarkViewModel LoadInformationBinding(this DaymarkViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RetroreflectorViewModel LoadInformationBinding(this RetroreflectorViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RadarTransponderBeaconViewModel LoadInformationBinding(this RadarTransponderBeaconViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static VirtualAISAidToNavigationViewModel LoadInformationBinding(this VirtualAISAidToNavigationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static PhysicalAISAidToNavigationViewModel LoadInformationBinding(this PhysicalAISAidToNavigationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SyntheticAISAidToNavigationViewModel LoadInformationBinding(this SyntheticAISAidToNavigationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static PowerSourceViewModel LoadInformationBinding(this PowerSourceViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static IsolatedDangerBeaconViewModel LoadInformationBinding(this IsolatedDangerBeaconViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static CardinalBeaconViewModel LoadInformationBinding(this CardinalBeaconViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static IsolatedDangerBuoyViewModel LoadInformationBinding(this IsolatedDangerBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static CardinalBuoyViewModel LoadInformationBinding(this CardinalBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static InstallationBuoyViewModel LoadInformationBinding(this InstallationBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static MooringBuoyViewModel LoadInformationBinding(this MooringBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static EmergencyWreckMarkingBuoyViewModel LoadInformationBinding(this EmergencyWreckMarkingBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LighthouseViewModel LoadInformationBinding(this LighthouseViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LightFloatViewModel LoadInformationBinding(this LightFloatViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LightVesselViewModel LoadInformationBinding(this LightVesselViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static OffshorePlatformViewModel LoadInformationBinding(this OffshorePlatformViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SiloTankViewModel LoadInformationBinding(this SiloTankViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static PileViewModel LoadInformationBinding(this PileViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static BuildingViewModel LoadInformationBinding(this BuildingViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static BridgeViewModel LoadInformationBinding(this BridgeViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SinkerAnchorViewModel LoadInformationBinding(this SinkerAnchorViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static MooringShackleViewModel LoadInformationBinding(this MooringShackleViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static CableSubmarineViewModel LoadInformationBinding(this CableSubmarineViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SwivelViewModel LoadInformationBinding(this SwivelViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static BridleViewModel LoadInformationBinding(this BridleViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static CounterWeightViewModel LoadInformationBinding(this CounterWeightViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static TopmarkViewModel LoadInformationBinding(this TopmarkViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SafeWaterBeaconViewModel LoadInformationBinding(this SafeWaterBeaconViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SpecialPurposeGeneralBeaconViewModel LoadInformationBinding(this SpecialPurposeGeneralBeaconViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SafeWaterBuoyViewModel LoadInformationBinding(this SafeWaterBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SpecialPurposeGeneralBuoyViewModel LoadInformationBinding(this SpecialPurposeGeneralBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DangerousFeatureViewModel LoadInformationBinding(this DangerousFeatureViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static AtonAggregationViewModel LoadInformationBinding(this AtonAggregationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static AtonAssociationViewModel LoadInformationBinding(this AtonAssociationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static QualityOfNonBathymetricDataViewModel LoadInformationBinding(this QualityOfNonBathymetricDataViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DataCoverageViewModel LoadInformationBinding(this DataCoverageViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LocalDirectionOfBuoyageViewModel LoadInformationBinding(this LocalDirectionOfBuoyageViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static NavigationalSystemOfMarksViewModel LoadInformationBinding(this NavigationalSystemOfMarksViewModel instance, informationBinding[] bindings) {
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

	}

	public static class FeatureBindingExtension {
		public static LandmarkViewModel LoadFeatureBinding(this LandmarkViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LateralBeaconViewModel LoadFeatureBinding(this LateralBeaconViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LateralBuoyViewModel LoadFeatureBinding(this LateralBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static NavigationLineViewModel LoadFeatureBinding(this NavigationLineViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<RangeSystem> rangeSystem) {
					instance.RangeSystems.Add(new FeatureRefViewModel {
						featureId = rangeSystem.referenceId,
						featureType = rangeSystem.featureType,
						role = rangeSystem.role,
					});
				}
			}
			return instance;
		}

		public static RecommendedTrackViewModel LoadFeatureBinding(this RecommendedTrackViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<RangeSystem> rangeSystem) {
					instance.RangeSystems.Add(new FeatureRefViewModel {
						featureId = rangeSystem.referenceId,
						featureType = rangeSystem.featureType,
						role = rangeSystem.role,
					});
				}
			}
			return instance;
		}

		public static LightSectoredViewModel LoadFeatureBinding(this LightSectoredViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LightAllAroundViewModel LoadFeatureBinding(this LightAllAroundViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LightAirObstructionViewModel LoadFeatureBinding(this LightAirObstructionViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LightFogDetectorViewModel LoadFeatureBinding(this LightFogDetectorViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static RadarReflectorViewModel LoadFeatureBinding(this RadarReflectorViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static FogSignalViewModel LoadFeatureBinding(this FogSignalViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static EnvironmentObservationEquipmentViewModel LoadFeatureBinding(this EnvironmentObservationEquipmentViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static RadioStationViewModel LoadFeatureBinding(this RadioStationViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<PhysicalAIS> physicalAIS) {
					instance.PhysicalAIS.Add(new FeatureRefViewModel {
						featureId = physicalAIS.referenceId,
						featureType = physicalAIS.featureType,
						role = physicalAIS.role,
					});
				}
				if(featureBinding is featureBinding<SyntheticAIS> syntheticAIS) {
					instance.SyntheticAIS.Add(new FeatureRefViewModel {
						featureId = syntheticAIS.referenceId,
						featureType = syntheticAIS.featureType,
						role = syntheticAIS.role,
					});
				}
				if(featureBinding is featureBinding<VirtualAIS> virtualAIS) {
					instance.VirtualAIS.Add(new FeatureRefViewModel {
						featureId = virtualAIS.referenceId,
						featureType = virtualAIS.featureType,
						role = virtualAIS.role,
					});
				}
			}
			return instance;
		}

		public static DaymarkViewModel LoadFeatureBinding(this DaymarkViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static RetroreflectorViewModel LoadFeatureBinding(this RetroreflectorViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static RadarTransponderBeaconViewModel LoadFeatureBinding(this RadarTransponderBeaconViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static VirtualAISAidToNavigationViewModel LoadFeatureBinding(this VirtualAISAidToNavigationViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<VirtualAIS> virtualAIS) {
					instance.VirtualAIS.Add(new FeatureRefViewModel {
						featureId = virtualAIS.referenceId,
						featureType = virtualAIS.featureType,
						role = virtualAIS.role,
					});
				}
			}
			return instance;
		}

		public static PhysicalAISAidToNavigationViewModel LoadFeatureBinding(this PhysicalAISAidToNavigationViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<PhysicalAIS> physicalAIS) {
					instance.PhysicalAIS.Add(new FeatureRefViewModel {
						featureId = physicalAIS.referenceId,
						featureType = physicalAIS.featureType,
						role = physicalAIS.role,
					});
				}
			}
			return instance;
		}

		public static SyntheticAISAidToNavigationViewModel LoadFeatureBinding(this SyntheticAISAidToNavigationViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<SyntheticAIS> syntheticAIS) {
					instance.SyntheticAIS.Add(new FeatureRefViewModel {
						featureId = syntheticAIS.referenceId,
						featureType = syntheticAIS.featureType,
						role = syntheticAIS.role,
					});
				}
			}
			return instance;
		}

		public static PowerSourceViewModel LoadFeatureBinding(this PowerSourceViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static IsolatedDangerBeaconViewModel LoadFeatureBinding(this IsolatedDangerBeaconViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static CardinalBeaconViewModel LoadFeatureBinding(this CardinalBeaconViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static IsolatedDangerBuoyViewModel LoadFeatureBinding(this IsolatedDangerBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static CardinalBuoyViewModel LoadFeatureBinding(this CardinalBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static InstallationBuoyViewModel LoadFeatureBinding(this InstallationBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static MooringBuoyViewModel LoadFeatureBinding(this MooringBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static EmergencyWreckMarkingBuoyViewModel LoadFeatureBinding(this EmergencyWreckMarkingBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LighthouseViewModel LoadFeatureBinding(this LighthouseViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LightFloatViewModel LoadFeatureBinding(this LightFloatViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LightVesselViewModel LoadFeatureBinding(this LightVesselViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static OffshorePlatformViewModel LoadFeatureBinding(this OffshorePlatformViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static SiloTankViewModel LoadFeatureBinding(this SiloTankViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static PileViewModel LoadFeatureBinding(this PileViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static BuildingViewModel LoadFeatureBinding(this BuildingViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static BridgeViewModel LoadFeatureBinding(this BridgeViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static SinkerAnchorViewModel LoadFeatureBinding(this SinkerAnchorViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<ShackleToAnchorConnection> shackleToAnchorConnection) {
					instance.ShackleToAnchorConnections.Add(new FeatureRefViewModel {
						featureId = shackleToAnchorConnection.referenceId,
						featureType = shackleToAnchorConnection.featureType,
						role = shackleToAnchorConnection.role,
					});
				}
			}
			return instance;
		}

		public static MooringShackleViewModel LoadFeatureBinding(this MooringShackleViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<ShackleConnection> shackleConnection) {
					instance.ShackleConnections.Add(new FeatureRefViewModel {
						featureId = shackleConnection.referenceId,
						featureType = shackleConnection.featureType,
						role = shackleConnection.role,
					});
				}
				if(featureBinding is featureBinding<ShackleToBridleConnection> shackleToBridleConnection) {
					instance.ShackleToBridleConnections.Add(new FeatureRefViewModel {
						featureId = shackleToBridleConnection.referenceId,
						featureType = shackleToBridleConnection.featureType,
						role = shackleToBridleConnection.role,
					});
				}
				if(featureBinding is featureBinding<BridleCableConnection> bridleCableConnection) {
					instance.BridleCableConnections.Add(new FeatureRefViewModel {
						featureId = bridleCableConnection.referenceId,
						featureType = bridleCableConnection.featureType,
						role = bridleCableConnection.role,
					});
				}
				if(featureBinding is featureBinding<ShackleToSwivelConnection> shackleToSwivelConnection) {
					instance.ShackleToSwivelConnections.Add(new FeatureRefViewModel {
						featureId = shackleToSwivelConnection.referenceId,
						featureType = shackleToSwivelConnection.featureType,
						role = shackleToSwivelConnection.role,
					});
				}
				if(featureBinding is featureBinding<ShackleToAnchorConnection> shackleToAnchorConnection) {
					instance.ShackleToAnchorConnections.Add(new FeatureRefViewModel {
						featureId = shackleToAnchorConnection.referenceId,
						featureType = shackleToAnchorConnection.featureType,
						role = shackleToAnchorConnection.role,
					});
				}
			}
			return instance;
		}

		public static CableSubmarineViewModel LoadFeatureBinding(this CableSubmarineViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<BridleCableConnection> bridleCableConnection) {
					instance.BridleCableConnections.Add(new FeatureRefViewModel {
						featureId = bridleCableConnection.referenceId,
						featureType = bridleCableConnection.featureType,
						role = bridleCableConnection.role,
					});
				}
				if(featureBinding is featureBinding<SwivelCableConnection> swivelCableConnection) {
					instance.SwivelCableConnections.Add(new FeatureRefViewModel {
						featureId = swivelCableConnection.referenceId,
						featureType = swivelCableConnection.featureType,
						role = swivelCableConnection.role,
					});
				}
				if(featureBinding is featureBinding<ShackleConnectionFromCable> shackleConnectionFromCable) {
					instance.ShackleConnectionFromCables.Add(new FeatureRefViewModel {
						featureId = shackleConnectionFromCable.referenceId,
						featureType = shackleConnectionFromCable.featureType,
						role = shackleConnectionFromCable.role,
					});
				}
			}
			return instance;
		}

		public static SwivelViewModel LoadFeatureBinding(this SwivelViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<SwivelConnection> swivelConnection) {
					instance.SwivelConnections.Add(new FeatureRefViewModel {
						featureId = swivelConnection.referenceId,
						featureType = swivelConnection.featureType,
						role = swivelConnection.role,
					});
				}
				if(featureBinding is featureBinding<SwivelCableConnection> swivelCableConnection) {
					instance.SwivelCableConnections.Add(new FeatureRefViewModel {
						featureId = swivelCableConnection.referenceId,
						featureType = swivelCableConnection.featureType,
						role = swivelCableConnection.role,
					});
				}
				if(featureBinding is featureBinding<ShackleToSwivelConnection> shackleToSwivelConnection) {
					instance.ShackleToSwivelConnections.Add(new FeatureRefViewModel {
						featureId = shackleToSwivelConnection.referenceId,
						featureType = shackleToSwivelConnection.featureType,
						role = shackleToSwivelConnection.role,
					});
				}
			}
			return instance;
		}

		public static BridleViewModel LoadFeatureBinding(this BridleViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<BridleConnection> bridleConnection) {
					instance.BridleConnections.Add(new FeatureRefViewModel {
						featureId = bridleConnection.referenceId,
						featureType = bridleConnection.featureType,
						role = bridleConnection.role,
					});
				}
				if(featureBinding is featureBinding<SwivelConnection> swivelConnection) {
					instance.SwivelConnections.Add(new FeatureRefViewModel {
						featureId = swivelConnection.referenceId,
						featureType = swivelConnection.featureType,
						role = swivelConnection.role,
					});
				}
				if(featureBinding is featureBinding<ShackleToBridleConnection> shackleToBridleConnection) {
					instance.ShackleToBridleConnections.Add(new FeatureRefViewModel {
						featureId = shackleToBridleConnection.referenceId,
						featureType = shackleToBridleConnection.featureType,
						role = shackleToBridleConnection.role,
					});
				}
				if(featureBinding is featureBinding<BridleCableConnection> bridleCableConnection) {
					instance.BridleCableConnections.Add(new FeatureRefViewModel {
						featureId = bridleCableConnection.referenceId,
						featureType = bridleCableConnection.featureType,
						role = bridleCableConnection.role,
					});
				}
			}
			return instance;
		}

		public static CounterWeightViewModel LoadFeatureBinding(this CounterWeightViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<BuoyCounterWeight> buoyCounterWeight) {
					instance.BuoyCounterWeights.Add(new FeatureRefViewModel {
						featureId = buoyCounterWeight.referenceId,
						featureType = buoyCounterWeight.featureType,
						role = buoyCounterWeight.role,
					});
				}
			}
			return instance;
		}

		public static TopmarkViewModel LoadFeatureBinding(this TopmarkViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<BuoyTopmark> buoyTopmark) {
					instance.BuoyTopmarks.Add(new FeatureRefViewModel {
						featureId = buoyTopmark.referenceId,
						featureType = buoyTopmark.featureType,
						role = buoyTopmark.role,
					});
				}
			}
			return instance;
		}

		public static SafeWaterBeaconViewModel LoadFeatureBinding(this SafeWaterBeaconViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static SpecialPurposeGeneralBeaconViewModel LoadFeatureBinding(this SpecialPurposeGeneralBeaconViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static SafeWaterBuoyViewModel LoadFeatureBinding(this SafeWaterBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static SpecialPurposeGeneralBuoyViewModel LoadFeatureBinding(this SpecialPurposeGeneralBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static DangerousFeatureViewModel LoadFeatureBinding(this DangerousFeatureViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<DangerousFeatureAssociation> dangerousFeatureAssociation) {
					instance.DangerousFeatureAssociations.Add(new FeatureRefViewModel {
						featureId = dangerousFeatureAssociation.referenceId,
						featureType = dangerousFeatureAssociation.featureType,
						role = dangerousFeatureAssociation.role,
					});
				}
			}
			return instance;
		}

		public static AtonAggregationViewModel LoadFeatureBinding(this AtonAggregationViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<AtonAggregations> atonAggregations) {
					instance.AtonAggregations.Add(new FeatureRefViewModel {
						featureId = atonAggregations.referenceId,
						featureType = atonAggregations.featureType,
						role = atonAggregations.role,
					});
				}
			}
			return instance;
		}

		public static AtonAssociationViewModel LoadFeatureBinding(this AtonAssociationViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<DangerousFeatureAssociation> dangerousFeatureAssociation) {
					instance.DangerousFeatureAssociations.Add(new FeatureRefViewModel {
						featureId = dangerousFeatureAssociation.referenceId,
						featureType = dangerousFeatureAssociation.featureType,
						role = dangerousFeatureAssociation.role,
					});
				}
				if(featureBinding is featureBinding<AtonAssociations> atonAssociations) {
					instance.AtonAssociations.Add(new FeatureRefViewModel {
						featureId = atonAssociations.referenceId,
						featureType = atonAssociations.featureType,
						role = atonAssociations.role,
					});
				}
			}
			return instance;
		}

		public static QualityOfNonBathymetricDataViewModel LoadFeatureBinding(this QualityOfNonBathymetricDataViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static DataCoverageViewModel LoadFeatureBinding(this DataCoverageViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LocalDirectionOfBuoyageViewModel LoadFeatureBinding(this LocalDirectionOfBuoyageViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static NavigationalSystemOfMarksViewModel LoadFeatureBinding(this NavigationalSystemOfMarksViewModel instance, featureBinding[] bindings) {
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

	}

}
