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
	[CategoryOrder("contactAddress",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class contactAddressViewModel : ViewModelBase {
		private String? _deliveryPoint  = default;

		public String? deliveryPoint {
			get {
				return _deliveryPoint;
			}
			set {
				SetValue(ref _deliveryPoint, value);
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
	[CategoryOrder("directionalCharacter",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class directionalCharacterViewModel : ViewModelBase {
		private Boolean? _moireEffect  = default;

		public Boolean? moireEffect {
			get {
				return _moireEffect;
			}
			set {
				SetValue(ref _moireEffect, value);
			}
		}
		private orientationViewModel _orientation ;

		[Category("directionalCharacter")]
		[ExpandableObject]
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
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference.
	/// </summary>
	[CategoryOrder("lightSector",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class lightSectorViewModel : ViewModelBase {
		[Category("lightSector")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		private directionalCharacterViewModel? _directionalCharacter  = default;

		[Category("lightSector")]
		[ExpandableObject]
		public directionalCharacterViewModel? directionalCharacter {
			get {
				return _directionalCharacter;
			}
			set {
				SetValue(ref _directionalCharacter, value);
			}
		}
		[Category("lightSector")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(lightVisibilityList), typeof(lightVisibility))]
		public ObservableCollection<lightVisibility> lightVisibility  { get; set; } = new ();

		[Browsable(false)]
		public lightVisibility[] lightVisibilityList => [(lightVisibility)1,(lightVisibility)2,(lightVisibility)3,(lightVisibility)4,(lightVisibility)5,(lightVisibility)6,(lightVisibility)7,(lightVisibility)8,(lightVisibility)9];
		private sectorLimitViewModel? _sectorLimit  = default;

		[Category("lightSector")]
		[ExpandableObject]
		public sectorLimitViewModel? sectorLimit {
			get {
				return _sectorLimit;
			}
			set {
				SetValue(ref _sectorLimit, value);
			}
		}
		private decimal? _valueOfNominalRange  = default;

		public decimal? valueOfNominalRange {
			get {
				return _valueOfNominalRange;
			}
			set {
				SetValue(ref _valueOfNominalRange, value);
			}
		}
		[Category("lightSector")]
		public ObservableCollection<sectorInformationViewModel> sectorInformation  { get; set; } = new ();
		private Boolean? _sectorExtension  = default;

		public Boolean? sectorExtension {
			get {
				return _sectorExtension;
			}
			set {
				SetValue(ref _sectorExtension, value);
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
			sectorExtension = instance.sectorExtension;
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
				sectorExtension = this.sectorExtension,
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
			sectorExtension = this._sectorExtension,
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
	[CategoryOrder("multiplicityOfFeatures",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class multiplicityOfFeaturesViewModel : ViewModelBase {
		private Boolean _multiplicityKnown  = false;

		[Editor(typeof(Editors.UnknownEditor<Boolean?>), typeof(Editors.UnknownEditor<Boolean?>))]
		public Boolean multiplicityKnown {
			get {
				return _multiplicityKnown;
			}
			set {
				SetValue(ref _multiplicityKnown, value);
			}
		}
		private int? _numberOfFeatures  = default;

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
		private decimal _orientationValue ;

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
	/// The active period of a recurring event or occurrence.
	/// </summary>
	[CategoryOrder("periodicDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class periodicDateRangeViewModel : ViewModelBase {
		private String _dateEnd ;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String dateEnd {
			get {
				return _dateEnd;
			}
			set {
				SetValue(ref _dateEnd, value);
			}
		}
		private String _dateStart ;

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
	/// The distance between two successive peaks (or other points of identical phase) on an electromagnetic wave in the radar band of the electromagnetic spectrum.
	/// </summary>
	[CategoryOrder("radarWaveLength",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class radarWaveLengthViewModel : ViewModelBase {
		private String _radarBand  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String radarBand {
			get {
				return _radarBand;
			}
			set {
				SetValue(ref _radarBand, value);
			}
		}
		private decimal _waveLengthValue ;

		[Editor(typeof(Editors.UnknownEditor<decimal?>), typeof(Editors.UnknownEditor<decimal?>))]
		public decimal waveLengthValue {
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
	[CategoryOrder("rhythmOfLight",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class rhythmOfLightViewModel : ViewModelBase {
		private lightCharacteristic _lightCharacteristic ;

		[Editor(typeof(Editors.UnknownEditor<lightCharacteristic?>), typeof(Editors.UnknownEditor<lightCharacteristic?>))]
		[DomainModel.EnumerationAttribute(nameof(lightCharacteristicList), typeof(lightCharacteristic))]
		public lightCharacteristic lightCharacteristic {
			get {
				return _lightCharacteristic;
			}
			set {
				SetValue(ref _lightCharacteristic, value);
			}
		}

		[Browsable(false)]
		public lightCharacteristic[] lightCharacteristicList => [(lightCharacteristic)1,(lightCharacteristic)2,(lightCharacteristic)3,(lightCharacteristic)4,(lightCharacteristic)5,(lightCharacteristic)6,(lightCharacteristic)7,(lightCharacteristic)8,(lightCharacteristic)12,(lightCharacteristic)13,(lightCharacteristic)14,(lightCharacteristic)15,(lightCharacteristic)16,(lightCharacteristic)17,(lightCharacteristic)18,(lightCharacteristic)19,(lightCharacteristic)20,(lightCharacteristic)25,(lightCharacteristic)26,(lightCharacteristic)27,(lightCharacteristic)28,(lightCharacteristic)29,(lightCharacteristic)30,(lightCharacteristic)31,(lightCharacteristic)32,(lightCharacteristic)33,(lightCharacteristic)34,(lightCharacteristic)35];
		[Category("rhythmOfLight")]
		public ObservableCollection<String> signalGroup  { get; set; } = new ();
		private decimal? _signalPeriod  = default;

		public decimal? signalPeriod {
			get {
				return _signalPeriod;
			}
			set {
				SetValue(ref _signalPeriod, value);
			}
		}
		[Category("rhythmOfLight")]
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
	[CategoryOrder("sectorCharacteristics",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorCharacteristicsViewModel : ViewModelBase {
		private lightCharacteristic _lightCharacteristic ;

		[Editor(typeof(Editors.UnknownEditor<lightCharacteristic?>), typeof(Editors.UnknownEditor<lightCharacteristic?>))]
		[DomainModel.EnumerationAttribute(nameof(lightCharacteristicList), typeof(lightCharacteristic))]
		public lightCharacteristic lightCharacteristic {
			get {
				return _lightCharacteristic;
			}
			set {
				SetValue(ref _lightCharacteristic, value);
			}
		}

		[Browsable(false)]
		public lightCharacteristic[] lightCharacteristicList => [(lightCharacteristic)1,(lightCharacteristic)2,(lightCharacteristic)3,(lightCharacteristic)4,(lightCharacteristic)5,(lightCharacteristic)6,(lightCharacteristic)7,(lightCharacteristic)8,(lightCharacteristic)12,(lightCharacteristic)13,(lightCharacteristic)14,(lightCharacteristic)15,(lightCharacteristic)16,(lightCharacteristic)17,(lightCharacteristic)18,(lightCharacteristic)19,(lightCharacteristic)20,(lightCharacteristic)25,(lightCharacteristic)26,(lightCharacteristic)27,(lightCharacteristic)28,(lightCharacteristic)29,(lightCharacteristic)30,(lightCharacteristic)31,(lightCharacteristic)32,(lightCharacteristic)33,(lightCharacteristic)34,(lightCharacteristic)35];
		[Category("sectorCharacteristics")]
		public ObservableCollection<lightSectorViewModel> lightSector  { get; set; } = new ();
		[Category("sectorCharacteristics")]
		public ObservableCollection<String> signalGroup  { get; set; } = new ();
		private decimal? _signalPeriod  = default;

		public decimal? signalPeriod {
			get {
				return _signalPeriod;
			}
			set {
				SetValue(ref _signalPeriod, value);
			}
		}
		[Category("sectorCharacteristics")]
		public ObservableCollection<signalSequenceViewModel> signalSequence  { get; set; } = new ();
		private decimal? _candela  = default;

		public decimal? candela {
			get {
				return _candela;
			}
			set {
				SetValue(ref _candela, value);
			}
		}


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
			candela = instance.candela;
			return this;
		}

		public override string Serialize() {
			var instance = new sectorCharacteristics {
				lightCharacteristic = this.lightCharacteristic,
				lightSector = this.lightSector.Select(e => e.Model).ToList(),
				signalGroup = this.signalGroup.ToList(),
				signalPeriod = this.signalPeriod,
				signalSequence = this.signalSequence.Select(e => e.Model).ToList(),
				candela = this.candela,
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
			candela = this._candela,
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
	[CategoryOrder("sectorInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorInformationViewModel : ViewModelBase {
		private String? _language  = default;

		public String? language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}
		private String _text  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
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
	[CategoryOrder("sectorLimit",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorLimitViewModel : ViewModelBase {
		private sectorLimitOneViewModel _sectorLimitOne ;

		[Category("sectorLimit")]
		[ExpandableObject]
		public sectorLimitOneViewModel sectorLimitOne {
			get {
				return _sectorLimitOne;
			}
			set {
				SetValue(ref _sectorLimitOne, value);
			}
		}
		private sectorLimitTwoViewModel _sectorLimitTwo ;

		[Category("sectorLimit")]
		[ExpandableObject]
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
	public partial class sectorLimitOneViewModel : ViewModelBase {
		private decimal _sectorBearing ;

		[Editor(typeof(Editors.UnknownEditor<decimal?>), typeof(Editors.UnknownEditor<decimal?>))]
		public decimal sectorBearing {
			get {
				return _sectorBearing;
			}
			set {
				SetValue(ref _sectorBearing, value);
			}
		}
		private int? _sectorLineLength  = default;

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
	public partial class sectorLimitTwoViewModel : ViewModelBase {
		private decimal _sectorBearing ;

		[Editor(typeof(Editors.UnknownEditor<decimal?>), typeof(Editors.UnknownEditor<decimal?>))]
		public decimal sectorBearing {
			get {
				return _sectorBearing;
			}
			set {
				SetValue(ref _sectorBearing, value);
			}
		}
		private int? _sectorLineLength  = default;

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
	[CategoryOrder("shapeInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class shapeInformationViewModel : ViewModelBase {
		private String? _language  = default;

		public String? language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}
		private String _text  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
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
	[CategoryOrder("signalSequence",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class signalSequenceViewModel : ViewModelBase {
		private decimal _signalDuration ;

		[Editor(typeof(Editors.UnknownEditor<decimal?>), typeof(Editors.UnknownEditor<decimal?>))]
		public decimal signalDuration {
			get {
				return _signalDuration;
			}
			set {
				SetValue(ref _signalDuration, value);
			}
		}
		private signalStatus _signalStatus ;

		[Editor(typeof(Editors.UnknownEditor<signalStatus?>), typeof(Editors.UnknownEditor<signalStatus?>))]
		[DomainModel.EnumerationAttribute(nameof(signalStatusList), typeof(signalStatus))]
		public signalStatus signalStatus {
			get {
				return _signalStatus;
			}
			set {
				SetValue(ref _signalStatus, value);
			}
		}

		[Browsable(false)]
		public signalStatus[] signalStatusList => [(signalStatus)1,(signalStatus)2];


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
	[CategoryOrder("spatialAccuracy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class spatialAccuracyViewModel : ViewModelBase {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("spatialAccuracy")]
		[ExpandableObject]
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
	[CategoryOrder("CableDimensions",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CableDimensionsViewModel : ViewModelBase {
		private decimal _cableLength ;

		[Editor(typeof(Editors.UnknownEditor<decimal?>), typeof(Editors.UnknownEditor<decimal?>))]
		public decimal cableLength {
			get {
				return _cableLength;
			}
			set {
				SetValue(ref _cableLength, value);
			}
		}
		private heightLengthUnits _heightLengthUnits ;

		[Editor(typeof(Editors.UnknownEditor<heightLengthUnits?>), typeof(Editors.UnknownEditor<heightLengthUnits?>))]
		[DomainModel.EnumerationAttribute(nameof(heightLengthUnitsList), typeof(heightLengthUnits))]
		public heightLengthUnits heightLengthUnits {
			get {
				return _heightLengthUnits;
			}
			set {
				SetValue(ref _heightLengthUnits, value);
			}
		}

		[Browsable(false)]
		public heightLengthUnits[] heightLengthUnitsList => [(heightLengthUnits)1,(heightLengthUnits)2,(heightLengthUnits)3,(heightLengthUnits)4,(heightLengthUnits)5,(heightLengthUnits)6];
		private decimal _diameter ;

		[Editor(typeof(Editors.UnknownEditor<decimal?>), typeof(Editors.UnknownEditor<decimal?>))]
		public decimal diameter {
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
	[CategoryOrder("ChangeDetails",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ChangeDetailsViewModel : ViewModelBase {
		private atonCommissioning? _atonCommissioning  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(atonCommissioningList), typeof(atonCommissioning))]
		public atonCommissioning? atonCommissioning {
			get {
				return _atonCommissioning;
			}
			set {
				SetValue(ref _atonCommissioning, value);
			}
		}

		[Browsable(false)]
		public atonCommissioning[] atonCommissioningList => [(atonCommissioning)1,(atonCommissioning)2,(atonCommissioning)3,(atonCommissioning)4,(atonCommissioning)5,(atonCommissioning)6,(atonCommissioning)7,(atonCommissioning)8,(atonCommissioning)9,(atonCommissioning)10,(atonCommissioning)11,(atonCommissioning)12,(atonCommissioning)13];
		private atonRemoval? _atonRemoval  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(atonRemovalList), typeof(atonRemoval))]
		public atonRemoval? atonRemoval {
			get {
				return _atonRemoval;
			}
			set {
				SetValue(ref _atonRemoval, value);
			}
		}

		[Browsable(false)]
		public atonRemoval[] atonRemovalList => [(atonRemoval)1,(atonRemoval)2,(atonRemoval)3,(atonRemoval)4,(atonRemoval)5,(atonRemoval)6,(atonRemoval)7,(atonRemoval)8,(atonRemoval)9,(atonRemoval)10,(atonRemoval)11,(atonRemoval)12,(atonRemoval)13,(atonRemoval)14,(atonRemoval)15,(atonRemoval)16,(atonRemoval)17,(atonRemoval)18,(atonRemoval)19,(atonRemoval)20,(atonRemoval)21,(atonRemoval)22,(atonRemoval)23,(atonRemoval)24,(atonRemoval)25,(atonRemoval)26,(atonRemoval)27];
		private atonReplacement? _atonReplacement  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(atonReplacementList), typeof(atonReplacement))]
		public atonReplacement? atonReplacement {
			get {
				return _atonReplacement;
			}
			set {
				SetValue(ref _atonReplacement, value);
			}
		}

		[Browsable(false)]
		public atonReplacement[] atonReplacementList => [(atonReplacement)1,(atonReplacement)2,(atonReplacement)3,(atonReplacement)4,(atonReplacement)5,(atonReplacement)6,(atonReplacement)7,(atonReplacement)8,(atonReplacement)9,(atonReplacement)10,(atonReplacement)11,(atonReplacement)12,(atonReplacement)13,(atonReplacement)14,(atonReplacement)15,(atonReplacement)16];
		private fixedAtonChange? _fixedAtonChange  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(fixedAtonChangeList), typeof(fixedAtonChange))]
		public fixedAtonChange? fixedAtonChange {
			get {
				return _fixedAtonChange;
			}
			set {
				SetValue(ref _fixedAtonChange, value);
			}
		}

		[Browsable(false)]
		public fixedAtonChange[] fixedAtonChangeList => [(fixedAtonChange)1,(fixedAtonChange)2,(fixedAtonChange)3,(fixedAtonChange)4,(fixedAtonChange)5,(fixedAtonChange)6,(fixedAtonChange)7,(fixedAtonChange)8,(fixedAtonChange)9,(fixedAtonChange)10,(fixedAtonChange)11];
		private floatingAtonChange? _floatingAtonChange  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(floatingAtonChangeList), typeof(floatingAtonChange))]
		public floatingAtonChange? floatingAtonChange {
			get {
				return _floatingAtonChange;
			}
			set {
				SetValue(ref _floatingAtonChange, value);
			}
		}

		[Browsable(false)]
		public floatingAtonChange[] floatingAtonChangeList => [(floatingAtonChange)1,(floatingAtonChange)2,(floatingAtonChange)3,(floatingAtonChange)4,(floatingAtonChange)5,(floatingAtonChange)6,(floatingAtonChange)7,(floatingAtonChange)8,(floatingAtonChange)9,(floatingAtonChange)10,(floatingAtonChange)11,(floatingAtonChange)12,(floatingAtonChange)13,(floatingAtonChange)14,(floatingAtonChange)15,(floatingAtonChange)16,(floatingAtonChange)17,(floatingAtonChange)18,(floatingAtonChange)19,(floatingAtonChange)20,(floatingAtonChange)21,(floatingAtonChange)22,(floatingAtonChange)23,(floatingAtonChange)24,(floatingAtonChange)25,(floatingAtonChange)26];
		private audibleSignalAtonChange? _audibleSignalAtonChange  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(audibleSignalAtonChangeList), typeof(audibleSignalAtonChange))]
		public audibleSignalAtonChange? audibleSignalAtonChange {
			get {
				return _audibleSignalAtonChange;
			}
			set {
				SetValue(ref _audibleSignalAtonChange, value);
			}
		}

		[Browsable(false)]
		public audibleSignalAtonChange[] audibleSignalAtonChangeList => [(audibleSignalAtonChange)1,(audibleSignalAtonChange)2,(audibleSignalAtonChange)3,(audibleSignalAtonChange)4];
		private lightedAtonChange? _lightedAtonChange  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(lightedAtonChangeList), typeof(lightedAtonChange))]
		public lightedAtonChange? lightedAtonChange {
			get {
				return _lightedAtonChange;
			}
			set {
				SetValue(ref _lightedAtonChange, value);
			}
		}

		[Browsable(false)]
		public lightedAtonChange[] lightedAtonChangeList => [(lightedAtonChange)1,(lightedAtonChange)2,(lightedAtonChange)3,(lightedAtonChange)4,(lightedAtonChange)5,(lightedAtonChange)6,(lightedAtonChange)7,(lightedAtonChange)8,(lightedAtonChange)9,(lightedAtonChange)10,(lightedAtonChange)11,(lightedAtonChange)12,(lightedAtonChange)13,(lightedAtonChange)14,(lightedAtonChange)15,(lightedAtonChange)16,(lightedAtonChange)17,(lightedAtonChange)18,(lightedAtonChange)19,(lightedAtonChange)20,(lightedAtonChange)21,(lightedAtonChange)22,(lightedAtonChange)23,(lightedAtonChange)24];
		private electronicAtonChange? _electronicAtonChange  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(electronicAtonChangeList), typeof(electronicAtonChange))]
		public electronicAtonChange? electronicAtonChange {
			get {
				return _electronicAtonChange;
			}
			set {
				SetValue(ref _electronicAtonChange, value);
			}
		}

		[Browsable(false)]
		public electronicAtonChange[] electronicAtonChangeList => [(electronicAtonChange)1,(electronicAtonChange)2,(electronicAtonChange)3,(electronicAtonChange)4,(electronicAtonChange)5,(electronicAtonChange)6,(electronicAtonChange)7,(electronicAtonChange)8,(electronicAtonChange)9,(electronicAtonChange)10,(electronicAtonChange)11,(electronicAtonChange)12,(electronicAtonChange)13,(electronicAtonChange)14,(electronicAtonChange)15,(electronicAtonChange)16,(electronicAtonChange)17,(electronicAtonChange)18,(electronicAtonChange)19,(electronicAtonChange)20,(electronicAtonChange)21,(electronicAtonChange)22,(electronicAtonChange)23,(electronicAtonChange)24,(electronicAtonChange)25,(electronicAtonChange)26,(electronicAtonChange)27,(electronicAtonChange)28,(electronicAtonChange)29,(electronicAtonChange)30];


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
	[CategoryOrder("ObscuredSector",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ObscuredSectorViewModel : ViewModelBase {
		private sectorLimitViewModel _sectorLimit ;

		[Category("ObscuredSector")]
		[ExpandableObject]
		public sectorLimitViewModel sectorLimit {
			get {
				return _sectorLimit;
			}
			set {
				SetValue(ref _sectorLimit, value);
			}
		}
		private sectorInformationViewModel? _sectorInformation  = default;

		[Category("ObscuredSector")]
		[ExpandableObject]
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
	[CategoryOrder("sinkerDimensions",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sinkerDimensionsViewModel : ViewModelBase {
		private heightLengthUnits _heightLengthUnits ;

		[Editor(typeof(Editors.UnknownEditor<heightLengthUnits?>), typeof(Editors.UnknownEditor<heightLengthUnits?>))]
		[DomainModel.EnumerationAttribute(nameof(heightLengthUnitsList), typeof(heightLengthUnits))]
		public heightLengthUnits heightLengthUnits {
			get {
				return _heightLengthUnits;
			}
			set {
				SetValue(ref _heightLengthUnits, value);
			}
		}

		[Browsable(false)]
		public heightLengthUnits[] heightLengthUnitsList => [(heightLengthUnits)1,(heightLengthUnits)2,(heightLengthUnits)3,(heightLengthUnits)4,(heightLengthUnits)5,(heightLengthUnits)6];
		private decimal? _horizontalLength  = default;

		public decimal? horizontalLength {
			get {
				return _horizontalLength;
			}
			set {
				SetValue(ref _horizontalLength, value);
			}
		}
		private decimal? _horizontalWidth  = default;

		public decimal? horizontalWidth {
			get {
				return _horizontalWidth;
			}
			set {
				SetValue(ref _horizontalWidth, value);
			}
		}
		private decimal? _verticalLength  = default;

		public decimal? verticalLength {
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
	[CategoryOrder("positioningMethod",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class positioningMethodViewModel : ViewModelBase {
		private positioningEquipment _positioningEquipment ;

		[Editor(typeof(Editors.UnknownEditor<positioningEquipment?>), typeof(Editors.UnknownEditor<positioningEquipment?>))]
		[DomainModel.EnumerationAttribute(nameof(positioningEquipmentList), typeof(positioningEquipment))]
		public positioningEquipment positioningEquipment {
			get {
				return _positioningEquipment;
			}
			set {
				SetValue(ref _positioningEquipment, value);
			}
		}

		[Browsable(false)]
		public positioningEquipment[] positioningEquipmentList => [(positioningEquipment)1,(positioningEquipment)2,(positioningEquipment)3,(positioningEquipment)4];
		private String _NMEAString  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
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
	[CategoryOrder("horizontalPositionUncertainty",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class horizontalPositionUncertaintyViewModel : ViewModelBase {
		private decimal _uncertaintyFixed ;

		[Editor(typeof(Editors.UnknownEditor<decimal?>), typeof(Editors.UnknownEditor<decimal?>))]
		public decimal uncertaintyFixed {
			get {
				return _uncertaintyFixed;
			}
			set {
				SetValue(ref _uncertaintyFixed, value);
			}
		}
		private decimal? _uncertaintyVariableFactor  = default;

		public decimal? uncertaintyVariableFactor {
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
		private String _language  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String language {
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
	/// Encodes the file name of a single external text file that contains the text in a defined language, which provides additional textual information that cannot be provided using other allowable attributes for the feature.
	/// </summary>
	[CategoryOrder("textualDescription",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class textualDescriptionViewModel : ViewModelBase {
		private String _fileReference  = string.Empty;

		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String fileReference {
			get {
				return _fileReference;
			}
			set {
				SetValue(ref _fileReference, value);
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
	[CategoryOrder("verticalUncertainty",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class verticalUncertaintyViewModel : ViewModelBase {
		private decimal _uncertaintyFixed ;

		[Editor(typeof(Editors.UnknownEditor<decimal?>), typeof(Editors.UnknownEditor<decimal?>))]
		public decimal uncertaintyFixed {
			get {
				return _uncertaintyFixed;
			}
			set {
				SetValue(ref _uncertaintyFixed, value);
			}
		}
		private decimal? _uncertaintyVariableFactor  = default;

		public decimal? uncertaintyVariableFactor {
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
	[CategoryOrder("Atonstatus",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonstatusViewModel : AssociationViewModel {


		public AtonstatusViewModel Load(Atonstatus instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new Atonstatus {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Atonstatus Model => new () {

		};

		public override string? ToString() => $"Aton Status";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("AtonFixingMethodAssociation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonFixingMethodAssociationViewModel : AssociationViewModel {


		public AtonFixingMethodAssociationViewModel Load(AtonFixingMethodAssociation instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new AtonFixingMethodAssociation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AtonFixingMethodAssociation Model => new () {

		};

		public override string? ToString() => $"Aton Fixing Method Association";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("AtonPositioningInformationAssociation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonPositioningInformationAssociationViewModel : AssociationViewModel {


		public AtonPositioningInformationAssociationViewModel Load(AtonPositioningInformationAssociation instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new AtonPositioningInformationAssociation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AtonPositioningInformationAssociation Model => new () {

		};

		public override string? ToString() => $"Aton Positioning Information Association";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("BuoyTopmark",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BuoyTopmarkViewModel : AssociationViewModel {


		public BuoyTopmarkViewModel Load(BuoyTopmark instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new BuoyTopmark {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public BuoyTopmark Model => new () {

		};

		public override string? ToString() => $"Buoy Topmark";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("StructureEquipment",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class StructureEquipmentViewModel : AssociationViewModel {


		public StructureEquipmentViewModel Load(StructureEquipment instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new StructureEquipment {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public StructureEquipment Model => new () {

		};

		public override string? ToString() => $"Structure Equipment";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("PhysicalAIS",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PhysicalAISViewModel : AssociationViewModel {


		public PhysicalAISViewModel Load(PhysicalAIS instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new PhysicalAIS {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PhysicalAIS Model => new () {

		};

		public override string? ToString() => $"Physical AIS";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("SyntheticAIS",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SyntheticAISViewModel : AssociationViewModel {


		public SyntheticAISViewModel Load(SyntheticAIS instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new SyntheticAIS {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SyntheticAIS Model => new () {

		};

		public override string? ToString() => $"Synthetic AIS";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("VirtualAIS",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class VirtualAISViewModel : AssociationViewModel {


		public VirtualAISViewModel Load(VirtualAIS instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new VirtualAIS {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public VirtualAIS Model => new () {

		};

		public override string? ToString() => $"Virtual AIS";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("BuoyCounterWeight",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BuoyCounterWeightViewModel : AssociationViewModel {


		public BuoyCounterWeightViewModel Load(BuoyCounterWeight instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new BuoyCounterWeight {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public BuoyCounterWeight Model => new () {

		};

		public override string? ToString() => $"Buoy Counter Weight";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("BridleConnection",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BridleConnectionViewModel : AssociationViewModel {


		public BridleConnectionViewModel Load(BridleConnection instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new BridleConnection {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public BridleConnection Model => new () {

		};

		public override string? ToString() => $"Bridle Connection";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("ShackleConnection",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ShackleConnectionViewModel : AssociationViewModel {


		public ShackleConnectionViewModel Load(ShackleConnection instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new ShackleConnection {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ShackleConnection Model => new () {

		};

		public override string? ToString() => $"Shackle Connection";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("ShackleConnectionFromCable",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ShackleConnectionFromCableViewModel : AssociationViewModel {


		public ShackleConnectionFromCableViewModel Load(ShackleConnectionFromCable instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new ShackleConnectionFromCable {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ShackleConnectionFromCable Model => new () {

		};

		public override string? ToString() => $"Shackle Connection From Cable";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("SwivelCableConnection",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SwivelCableConnectionViewModel : AssociationViewModel {


		public SwivelCableConnectionViewModel Load(SwivelCableConnection instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new SwivelCableConnection {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SwivelCableConnection Model => new () {

		};

		public override string? ToString() => $"Swivel Cable Connection";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("BridleCableConnection",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BridleCableConnectionViewModel : AssociationViewModel {


		public BridleCableConnectionViewModel Load(BridleCableConnection instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new BridleCableConnection {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public BridleCableConnection Model => new () {

		};

		public override string? ToString() => $"Bridle Cable Connection";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("ShackleToBridleConnection",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ShackleToBridleConnectionViewModel : AssociationViewModel {


		public ShackleToBridleConnectionViewModel Load(ShackleToBridleConnection instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new ShackleToBridleConnection {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ShackleToBridleConnection Model => new () {

		};

		public override string? ToString() => $"Shackle To Bridle Connection";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("ShackleToSwivelConnection",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ShackleToSwivelConnectionViewModel : AssociationViewModel {


		public ShackleToSwivelConnectionViewModel Load(ShackleToSwivelConnection instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new ShackleToSwivelConnection {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ShackleToSwivelConnection Model => new () {

		};

		public override string? ToString() => $"Shackle To Swivel Connection";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("ShackleToAnchorConnection",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ShackleToAnchorConnectionViewModel : AssociationViewModel {


		public ShackleToAnchorConnectionViewModel Load(ShackleToAnchorConnection instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new ShackleToAnchorConnection {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ShackleToAnchorConnection Model => new () {

		};

		public override string? ToString() => $"ShackleToAnchorConnection";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("SwivelConnection",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SwivelConnectionViewModel : AssociationViewModel {


		public SwivelConnectionViewModel Load(SwivelConnection instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new SwivelConnection {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SwivelConnection Model => new () {

		};

		public override string? ToString() => $"Swivel Connection";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("AtonAggregations",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonAggregationsViewModel : AssociationViewModel {


		public AtonAggregationsViewModel Load(AtonAggregations instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new AtonAggregations {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AtonAggregations Model => new () {

		};

		public override string? ToString() => $"Aton Aggregations";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("AtonAssociations",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonAssociationsViewModel : AssociationViewModel {


		public AtonAssociationsViewModel Load(AtonAssociations instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new AtonAssociations {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AtonAssociations Model => new () {

		};

		public override string? ToString() => $"Aton Associations";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("RangeSystem",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RangeSystemViewModel : AssociationViewModel {


		public RangeSystemViewModel Load(RangeSystem instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new RangeSystem {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RangeSystem Model => new () {

		};

		public override string? ToString() => $"Range System";
	}

	/// <summary>
	/// 
	/// </summary>
	[CategoryOrder("DangerousFeatureAssociation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DangerousFeatureAssociationViewModel : AssociationViewModel {


		public DangerousFeatureAssociationViewModel Load(DangerousFeatureAssociation instance) {

			return this;
		}

		public override string Serialize() {
			var instance = new DangerousFeatureAssociation {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DangerousFeatureAssociation Model => new () {

		};

		public override string? ToString() => $"Dangerous Feature Association";
	}

	/// <summary>
	/// Method used for fixing the position of an aid to navigation.
	/// </summary>
	[CategoryOrder("AtoNFixingMethod",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtoNFixingMethodViewModel : InformationViewModel<AtoNFixingMethod> {
		private String? _referencePoint  = default;

		[Category("AtoNFixingMethod")]
		public String? referencePoint {
			get {
				return _referencePoint;
			}
			set {
				SetValue(ref _referencePoint, value);
			}
		}
		private horizontalDatum? _horizontalDatum  = default;

		[Category("AtoNFixingMethod")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(horizontalDatumList), typeof(horizontalDatum))]
		public horizontalDatum? horizontalDatum {
			get {
				return _horizontalDatum;
			}
			set {
				SetValue(ref _horizontalDatum, value);
			}
		}

		[Browsable(false)]
		public horizontalDatum[] horizontalDatumList => [(horizontalDatum)1,(horizontalDatum)2,(horizontalDatum)3,(horizontalDatum)4,(horizontalDatum)5,(horizontalDatum)6,(horizontalDatum)7,(horizontalDatum)8,(horizontalDatum)9,(horizontalDatum)10,(horizontalDatum)11,(horizontalDatum)12,(horizontalDatum)13,(horizontalDatum)14,(horizontalDatum)15,(horizontalDatum)16,(horizontalDatum)17,(horizontalDatum)18,(horizontalDatum)19,(horizontalDatum)20,(horizontalDatum)21,(horizontalDatum)22,(horizontalDatum)23,(horizontalDatum)24,(horizontalDatum)25,(horizontalDatum)26,(horizontalDatum)27,(horizontalDatum)28,(horizontalDatum)29,(horizontalDatum)30,(horizontalDatum)31,(horizontalDatum)32,(horizontalDatum)33,(horizontalDatum)34,(horizontalDatum)35,(horizontalDatum)36,(horizontalDatum)37,(horizontalDatum)38,(horizontalDatum)39,(horizontalDatum)40,(horizontalDatum)41,(horizontalDatum)42,(horizontalDatum)43,(horizontalDatum)44,(horizontalDatum)45,(horizontalDatum)46,(horizontalDatum)47,(horizontalDatum)48,(horizontalDatum)49,(horizontalDatum)50,(horizontalDatum)51,(horizontalDatum)52,(horizontalDatum)53,(horizontalDatum)54,(horizontalDatum)55,(horizontalDatum)56,(horizontalDatum)57,(horizontalDatum)58,(horizontalDatum)59,(horizontalDatum)60,(horizontalDatum)61,(horizontalDatum)62,(horizontalDatum)63,(horizontalDatum)64,(horizontalDatum)65,(horizontalDatum)66,(horizontalDatum)67,(horizontalDatum)68,(horizontalDatum)69,(horizontalDatum)70,(horizontalDatum)71,(horizontalDatum)72,(horizontalDatum)73,(horizontalDatum)74,(horizontalDatum)75,(horizontalDatum)76,(horizontalDatum)77,(horizontalDatum)78,(horizontalDatum)79,(horizontalDatum)80,(horizontalDatum)81,(horizontalDatum)82,(horizontalDatum)83,(horizontalDatum)84,(horizontalDatum)85,(horizontalDatum)86,(horizontalDatum)87,(horizontalDatum)88,(horizontalDatum)89,(horizontalDatum)90,(horizontalDatum)91,(horizontalDatum)92,(horizontalDatum)93,(horizontalDatum)94,(horizontalDatum)95,(horizontalDatum)96,(horizontalDatum)97,(horizontalDatum)98,(horizontalDatum)99,(horizontalDatum)100,(horizontalDatum)101,(horizontalDatum)102,(horizontalDatum)103,(horizontalDatum)104,(horizontalDatum)105,(horizontalDatum)106,(horizontalDatum)107,(horizontalDatum)108,(horizontalDatum)109,(horizontalDatum)110,(horizontalDatum)111,(horizontalDatum)112,(horizontalDatum)113,(horizontalDatum)114,(horizontalDatum)116,(horizontalDatum)117,(horizontalDatum)118,(horizontalDatum)119,(horizontalDatum)120,(horizontalDatum)121,(horizontalDatum)122,(horizontalDatum)123,(horizontalDatum)124,(horizontalDatum)125,(horizontalDatum)126,(horizontalDatum)127,(horizontalDatum)128,(horizontalDatum)129,(horizontalDatum)130,(horizontalDatum)131];
		private DateOnly _sourceDate ;

		[Category("AtoNFixingMethod")]
		[Editor(typeof(Editors.UnknownEditor<DateOnly?>), typeof(Editors.UnknownEditor<DateOnly?>))]
		public DateOnly sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String _positioningProcedure  = string.Empty;

		[Category("AtoNFixingMethod")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String positioningProcedure {
			get {
				return _positioningProcedure;
			}
			set {
				SetValue(ref _positioningProcedure, value);
			}
		}


		public override InformationViewModel<AtoNFixingMethod> Load(AtoNFixingMethod instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => AtoNFixingMethod._informationBindingDefinitions;

		public override string? ToString() => $"AtoN Fixing Method";
	}

	/// <summary>
	/// -
	/// </summary>
	[CategoryOrder("AtonStatusInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonStatusInformationViewModel : InformationViewModel<AtonStatusInformation> {
		private ChangeDetailsViewModel _ChangeDetails ;

		[Category("AtonStatusInformation")]
		[ExpandableObject]
		public ChangeDetailsViewModel ChangeDetails {
			get {
				return _ChangeDetails;
			}
			set {
				SetValue(ref _ChangeDetails, value);
			}
		}
		private ChangeTypes? _ChangeTypes  = default;

		[Category("AtonStatusInformation")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(ChangeTypesList), typeof(ChangeTypes))]
		public ChangeTypes? ChangeTypes {
			get {
				return _ChangeTypes;
			}
			set {
				SetValue(ref _ChangeTypes, value);
			}
		}

		[Browsable(false)]
		public ChangeTypes[] ChangeTypesList => [(ChangeTypes)1,(ChangeTypes)2,(ChangeTypes)3,(ChangeTypes)4];


		public override InformationViewModel<AtonStatusInformation> Load(AtonStatusInformation instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => AtonStatusInformation._informationBindingDefinitions;

		public override string? ToString() => $"Aton Status Information";
	}

	/// <summary>
	/// Information about how a position was obtained. (proposed by CCG)
	/// </summary>
	[CategoryOrder("PositioningInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PositioningInformationViewModel : InformationViewModel<PositioningInformation> {
		private String _positioningDevice  = string.Empty;

		[Category("PositioningInformation")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String positioningDevice {
			get {
				return _positioningDevice;
			}
			set {
				SetValue(ref _positioningDevice, value);
			}
		}
		private positioningMethodViewModel? _positioningMethod  = default;

		[Category("PositioningInformation")]
		[ExpandableObject]
		public positioningMethodViewModel? positioningMethod {
			get {
				return _positioningMethod;
			}
			set {
				SetValue(ref _positioningMethod, value);
			}
		}


		public override InformationViewModel<PositioningInformation> Load(PositioningInformation instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => PositioningInformation._informationBindingDefinitions;

		public override string? ToString() => $"Positioning Information";
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
		private spatialAccuracyViewModel? _spatialAccuracy  = default;

		[Category("SpatialQuality")]
		[ExpandableObject]
		public spatialAccuracyViewModel? spatialAccuracy {
			get {
				return _spatialAccuracy;
			}
			set {
				SetValue(ref _spatialAccuracy, value);
			}
		}


		public override InformationViewModel<SpatialQuality> Load(SpatialQuality instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => SpatialQuality._informationBindingDefinitions;

		public override string? ToString() => $"Spatial Quality";
	}

	/// <summary>
	/// A prominent object at a fixed location on land which can be used in determining a location or a direction.
	/// </summary>
	[CategoryOrder("Landmark",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LandmarkViewModel : FeatureViewModel<Landmark> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		[Category("Landmark")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfLandmarkList), typeof(categoryOfLandmark))]
		public ObservableCollection<categoryOfLandmark> categoryOfLandmark  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfLandmark[] categoryOfLandmarkList => [(categoryOfLandmark)1,(categoryOfLandmark)2,(categoryOfLandmark)3,(categoryOfLandmark)4,(categoryOfLandmark)5,(categoryOfLandmark)6,(categoryOfLandmark)7,(categoryOfLandmark)8,(categoryOfLandmark)9,(categoryOfLandmark)10,(categoryOfLandmark)11,(categoryOfLandmark)12,(categoryOfLandmark)13,(categoryOfLandmark)14,(categoryOfLandmark)15,(categoryOfLandmark)16,(categoryOfLandmark)17,(categoryOfLandmark)18,(categoryOfLandmark)19,(categoryOfLandmark)20,(categoryOfLandmark)21,(categoryOfLandmark)22,(categoryOfLandmark)23,(categoryOfLandmark)24,(categoryOfLandmark)25,(categoryOfLandmark)26,(categoryOfLandmark)27];
		[Category("Landmark")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("Landmark")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		[Category("Landmark")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(functionList), typeof(function))]
		public ObservableCollection<function> function  { get; set; } = new ();

		[Browsable(false)]
		public function[] functionList => [(function)2,(function)3,(function)4,(function)5,(function)6,(function)7,(function)8,(function)9,(function)10,(function)11,(function)12,(function)13,(function)14,(function)15,(function)16,(function)17,(function)18,(function)19,(function)20,(function)21,(function)22,(function)23,(function)24,(function)25,(function)26,(function)27,(function)28,(function)29,(function)30,(function)31,(function)32,(function)33,(function)34,(function)35,(function)36,(function)37,(function)38,(function)39,(function)40,(function)41,(function)42,(function)43,(function)44,(function)45,(function)46,(function)47,(function)48];
		[Category("Landmark")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private Boolean? _radarConspicuous  = default;

		[Category("Landmark")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("Landmark")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private verticalDatum? _verticalDatum  = default;

		[Category("Landmark")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45];
		private visualProminence _visualProminence ;

		[Category("Landmark")]
		[Editor(typeof(Editors.UnknownEditor<visualProminence?>), typeof(Editors.UnknownEditor<visualProminence?>))]
		[DomainModel.EnumerationAttribute(nameof(visualProminenceList), typeof(visualProminence))]
		public visualProminence visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		[Browsable(false)]
		public visualProminence[] visualProminenceList => [(visualProminence)1,(visualProminence)2,(visualProminence)3];
		private decimal? _elevation  = default;

		[Category("Landmark")]
		public decimal? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}
		private decimal? _height  = default;

		[Category("Landmark")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private Boolean? _mannedStructure  = default;

		[Category("Landmark")]
		public Boolean? mannedStructure {
			get {
				return _mannedStructure;
			}
			set {
				SetValue(ref _mannedStructure, value);
			}
		}
		private decimal? _verticalLength  = default;

		[Category("Landmark")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private decimal? _verticalAccuracy  = default;

		[Category("Landmark")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}


		public override FeatureViewModel<Landmark> Load(Landmark instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => Landmark._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Landmark._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Landmark._featureBindingDefinitions;

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
	/// A beacon is a prominent specially constructed object forming a conspicuous mark as a fixed aid to navigation or for use in hydrographic survey (IHO Dictionary, S-32, 5th Edition, 420). A lateral beacon is used to indicate the port or starboard hand side of the route to be followed. They are generally used for well defined channels and are used in conjunction with a conventional direction of buoyage. (UKHO NP 735, 5th Edition)
	/// </summary>
	[CategoryOrder("LateralBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LateralBeaconViewModel : FeatureViewModel<LateralBeacon> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private beaconShape _beaconShape ;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.UnknownEditor<beaconShape?>), typeof(Editors.UnknownEditor<beaconShape?>))]
		[DomainModel.EnumerationAttribute(nameof(beaconShapeList), typeof(beaconShape))]
		public beaconShape beaconShape {
			get {
				return _beaconShape;
			}
			set {
				SetValue(ref _beaconShape, value);
			}
		}

		[Browsable(false)]
		public beaconShape[] beaconShapeList => [(beaconShape)1,(beaconShape)2,(beaconShape)3,(beaconShape)4,(beaconShape)5,(beaconShape)6,(beaconShape)7];
		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		private decimal? _elevation  = default;

		[Category("GenericBeacon")]
		public decimal? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}
		private decimal? _height  = default;

		[Category("GenericBeacon")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList), typeof(marksNavigationalSystemOf))]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Browsable(false)]
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)14,(marksNavigationalSystemOf)15];
		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private Boolean? _radarConspicuous  = default;

		[Category("GenericBeacon")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private decimal? _verticalLength  = default;

		[Category("GenericBeacon")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private visualProminence? _visualProminence  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(visualProminenceList), typeof(visualProminence))]
		public visualProminence? visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		[Browsable(false)]
		public visualProminence[] visualProminenceList => [(visualProminence)1,(visualProminence)2,(visualProminence)3];
		private decimal? _verticalAccuracy  = default;

		[Category("GenericBeacon")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}

		private categoryOfLateralMark _categoryOfLateralMark ;

		[Category("LateralBeacon")]
		[Editor(typeof(Editors.UnknownEditor<categoryOfLateralMark?>), typeof(Editors.UnknownEditor<categoryOfLateralMark?>))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfLateralMarkList), typeof(categoryOfLateralMark))]
		public categoryOfLateralMark categoryOfLateralMark {
			get {
				return _categoryOfLateralMark;
			}
			set {
				SetValue(ref _categoryOfLateralMark, value);
			}
		}

		[Browsable(false)]
		public categoryOfLateralMark[] categoryOfLateralMarkList => [(categoryOfLateralMark)1,(categoryOfLateralMark)2,(categoryOfLateralMark)3,(categoryOfLateralMark)4,(categoryOfLateralMark)5,(categoryOfLateralMark)6,(categoryOfLateralMark)7,(categoryOfLateralMark)8,(categoryOfLateralMark)9,(categoryOfLateralMark)10,(categoryOfLateralMark)11,(categoryOfLateralMark)12,(categoryOfLateralMark)13,(categoryOfLateralMark)14,(categoryOfLateralMark)15,(categoryOfLateralMark)16,(categoryOfLateralMark)17,(categoryOfLateralMark)18,(categoryOfLateralMark)19,(categoryOfLateralMark)20,(categoryOfLateralMark)21,(categoryOfLateralMark)22,(categoryOfLateralMark)23,(categoryOfLateralMark)24,(categoryOfLateralMark)25,(categoryOfLateralMark)26,(categoryOfLateralMark)27];


		public override FeatureViewModel<LateralBeacon> Load(LateralBeacon instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => LateralBeacon._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LateralBeacon._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LateralBeacon._featureBindingDefinitions;

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
	/// A buoy is a floating object moored to the bottom in a particular place, as an aid to navigation or for other specific purposes. (IHO Dictionary, S-32, 5th Edition, 565). A lateral buoy is used to indicate the port or starboard hand side of the route to be followed. They are generally used for well defined channels and are used in conjunction with a conventional direction of buoyage. (UKHO NP 735, 5th Edition)
	/// </summary>
	[CategoryOrder("LateralBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LateralBuoyViewModel : FeatureViewModel<LateralBuoy> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private buoyShape _buoyShape ;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.UnknownEditor<buoyShape?>), typeof(Editors.UnknownEditor<buoyShape?>))]
		[DomainModel.EnumerationAttribute(nameof(buoyShapeList), typeof(buoyShape))]
		public buoyShape buoyShape {
			get {
				return _buoyShape;
			}
			set {
				SetValue(ref _buoyShape, value);
			}
		}

		[Browsable(false)]
		public buoyShape[] buoyShapeList => [(buoyShape)1,(buoyShape)2,(buoyShape)3,(buoyShape)4,(buoyShape)5,(buoyShape)6,(buoyShape)7,(buoyShape)8];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList), typeof(marksNavigationalSystemOf))]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Browsable(false)]
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)14,(marksNavigationalSystemOf)15];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private Boolean? _radarConspicuous  = default;

		[Category("GenericBuoy")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private String? _typeOfBuoy  = default;

		[Category("GenericBuoy")]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}
		private decimal? _verticalLength  = default;

		[Category("GenericBuoy")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private decimal? _verticalAccuracy  = default;

		[Category("GenericBuoy")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}

		private categoryOfLateralMark _categoryOfLateralMark ;

		[Category("LateralBuoy")]
		[Editor(typeof(Editors.UnknownEditor<categoryOfLateralMark?>), typeof(Editors.UnknownEditor<categoryOfLateralMark?>))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfLateralMarkList), typeof(categoryOfLateralMark))]
		public categoryOfLateralMark categoryOfLateralMark {
			get {
				return _categoryOfLateralMark;
			}
			set {
				SetValue(ref _categoryOfLateralMark, value);
			}
		}

		[Browsable(false)]
		public categoryOfLateralMark[] categoryOfLateralMarkList => [(categoryOfLateralMark)1,(categoryOfLateralMark)2,(categoryOfLateralMark)3,(categoryOfLateralMark)4,(categoryOfLateralMark)5,(categoryOfLateralMark)6,(categoryOfLateralMark)7,(categoryOfLateralMark)8,(categoryOfLateralMark)9,(categoryOfLateralMark)10,(categoryOfLateralMark)11,(categoryOfLateralMark)12,(categoryOfLateralMark)13,(categoryOfLateralMark)14,(categoryOfLateralMark)15,(categoryOfLateralMark)16,(categoryOfLateralMark)17,(categoryOfLateralMark)18,(categoryOfLateralMark)19,(categoryOfLateralMark)20,(categoryOfLateralMark)21,(categoryOfLateralMark)22,(categoryOfLateralMark)23,(categoryOfLateralMark)24,(categoryOfLateralMark)25,(categoryOfLateralMark)26,(categoryOfLateralMark)27];


		public override FeatureViewModel<LateralBuoy> Load(LateralBuoy instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => LateralBuoy._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LateralBuoy._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LateralBuoy._featureBindingDefinitions;

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
	[CategoryOrder("NavigationLine",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NavigationLineViewModel : FeatureViewModel<NavigationLine> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private categoryOfNavigationLine _categoryOfNavigationLine ;

		[Category("NavigationLine")]
		[Editor(typeof(Editors.UnknownEditor<categoryOfNavigationLine?>), typeof(Editors.UnknownEditor<categoryOfNavigationLine?>))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfNavigationLineList), typeof(categoryOfNavigationLine))]
		public categoryOfNavigationLine categoryOfNavigationLine {
			get {
				return _categoryOfNavigationLine;
			}
			set {
				SetValue(ref _categoryOfNavigationLine, value);
			}
		}

		[Browsable(false)]
		public categoryOfNavigationLine[] categoryOfNavigationLineList => [(categoryOfNavigationLine)1,(categoryOfNavigationLine)2,(categoryOfNavigationLine)3];
		[Category("NavigationLine")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private orientationViewModel _orientation ;

		[Category("NavigationLine")]
		[ExpandableObject]
		public orientationViewModel orientation {
			get {
				return _orientation;
			}
			set {
				SetValue(ref _orientation, value);
			}
		}


		public override FeatureViewModel<NavigationLine> Load(NavigationLine instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => NavigationLine._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. NavigationLine._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => NavigationLine._featureBindingDefinitions;

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
		}
	}

	/// <summary>
	/// A route which has been specially examined to ensure so far as possible that it is free of dangers and along which ships are advised to navigate.
	/// </summary>
	[CategoryOrder("RecommendedTrack",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RecommendedTrackViewModel : FeatureViewModel<RecommendedTrack> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private Boolean _basedOnFixedMarks  = false;

		[Category("RecommendedTrack")]
		[Editor(typeof(Editors.UnknownEditor<Boolean?>), typeof(Editors.UnknownEditor<Boolean?>))]
		public Boolean basedOnFixedMarks {
			get {
				return _basedOnFixedMarks;
			}
			set {
				SetValue(ref _basedOnFixedMarks, value);
			}
		}
		private decimal? _depthRangeMinimumValue  = default;

		[Category("RecommendedTrack")]
		public decimal? depthRangeMinimumValue {
			get {
				return _depthRangeMinimumValue;
			}
			set {
				SetValue(ref _depthRangeMinimumValue, value);
			}
		}
		private decimal? _maximalPermittedDraught  = default;

		[Category("RecommendedTrack")]
		public decimal? maximalPermittedDraught {
			get {
				return _maximalPermittedDraught;
			}
			set {
				SetValue(ref _maximalPermittedDraught, value);
			}
		}
		[Category("RecommendedTrack")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private verticalDatum? _verticalDatum  = default;

		[Category("RecommendedTrack")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45];
		private orientationViewModel _orientation ;

		[Category("RecommendedTrack")]
		[ExpandableObject]
		public orientationViewModel orientation {
			get {
				return _orientation;
			}
			set {
				SetValue(ref _orientation, value);
			}
		}
		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Category("RecommendedTrack")]
		[ExpandableObject]
		public verticalUncertaintyViewModel? verticalUncertainty {
			get {
				return _verticalUncertainty;
			}
			set {
				SetValue(ref _verticalUncertainty, value);
			}
		}
		[Category("RecommendedTrack")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(qualityOfVerticalMeasurementList), typeof(qualityOfVerticalMeasurement))]
		public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1,(qualityOfVerticalMeasurement)2,(qualityOfVerticalMeasurement)3,(qualityOfVerticalMeasurement)4,(qualityOfVerticalMeasurement)5,(qualityOfVerticalMeasurement)6,(qualityOfVerticalMeasurement)7,(qualityOfVerticalMeasurement)8,(qualityOfVerticalMeasurement)9,(qualityOfVerticalMeasurement)10,(qualityOfVerticalMeasurement)11];
		[Category("RecommendedTrack")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(techniqueOfVerticalMeasurementList), typeof(techniqueOfVerticalMeasurement))]
		public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1,(techniqueOfVerticalMeasurement)2,(techniqueOfVerticalMeasurement)3,(techniqueOfVerticalMeasurement)4,(techniqueOfVerticalMeasurement)5,(techniqueOfVerticalMeasurement)6,(techniqueOfVerticalMeasurement)7,(techniqueOfVerticalMeasurement)8,(techniqueOfVerticalMeasurement)9,(techniqueOfVerticalMeasurement)10,(techniqueOfVerticalMeasurement)11,(techniqueOfVerticalMeasurement)12,(techniqueOfVerticalMeasurement)13,(techniqueOfVerticalMeasurement)14,(techniqueOfVerticalMeasurement)15,(techniqueOfVerticalMeasurement)16,(techniqueOfVerticalMeasurement)17];
		private trafficFlow _trafficFlow ;

		[Category("RecommendedTrack")]
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


		public override FeatureViewModel<RecommendedTrack> Load(RecommendedTrack instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => RecommendedTrack._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RecommendedTrack._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RecommendedTrack._featureBindingDefinitions;

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
		}
	}

	/// <summary>
	/// A light presenting different appearances (in particular, different colours) over various parts of the horizon of interest to maritime navigation.
	/// </summary>
	[CategoryOrder("LightSectored",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LightSectoredViewModel : FeatureViewModel<LightSectored> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Category("Equipment")]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		[Category("GenericLight")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13,(colour)14,(colour)15,(colour)16,(colour)17,(colour)18,(colour)19,(colour)20];
		private decimal? _height  = default;

		[Category("GenericLight")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		[Category("GenericLight")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private verticalDatum? _verticalDatum  = default;

		[Category("GenericLight")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45];
		private decimal? _verticalLength  = default;

		[Category("GenericLight")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private decimal? _effectiveIntensity  = default;

		[Category("GenericLight")]
		public decimal? effectiveIntensity {
			get {
				return _effectiveIntensity;
			}
			set {
				SetValue(ref _effectiveIntensity, value);
			}
		}
		private decimal? _peakIntensity  = default;

		[Category("GenericLight")]
		public decimal? peakIntensity {
			get {
				return _peakIntensity;
			}
			set {
				SetValue(ref _peakIntensity, value);
			}
		}

		[Category("LightSectored")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfLightList), typeof(categoryOfLight))]
		public ObservableCollection<categoryOfLight> categoryOfLight  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfLight[] categoryOfLightList => [(categoryOfLight)1,(categoryOfLight)4,(categoryOfLight)5,(categoryOfLight)6,(categoryOfLight)8,(categoryOfLight)9,(categoryOfLight)10,(categoryOfLight)11,(categoryOfLight)12,(categoryOfLight)13,(categoryOfLight)14,(categoryOfLight)15,(categoryOfLight)17,(categoryOfLight)18,(categoryOfLight)19,(categoryOfLight)20];
		private exhibitionConditionOfLight? _exhibitionConditionOfLight  = default;

		[Category("LightSectored")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(exhibitionConditionOfLightList), typeof(exhibitionConditionOfLight))]
		public exhibitionConditionOfLight? exhibitionConditionOfLight {
			get {
				return _exhibitionConditionOfLight;
			}
			set {
				SetValue(ref _exhibitionConditionOfLight, value);
			}
		}

		[Browsable(false)]
		public exhibitionConditionOfLight[] exhibitionConditionOfLightList => [(exhibitionConditionOfLight)1,(exhibitionConditionOfLight)2,(exhibitionConditionOfLight)3,(exhibitionConditionOfLight)4];
		[Category("LightSectored")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList), typeof(marksNavigationalSystemOf))]
		public ObservableCollection<marksNavigationalSystemOf> marksNavigationalSystemOf  { get; set; } = new ();

		[Browsable(false)]
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)14,(marksNavigationalSystemOf)15];
		private signalGeneration? _signalGeneration  = default;

		[Category("LightSectored")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(signalGenerationList), typeof(signalGeneration))]
		public signalGeneration? signalGeneration {
			get {
				return _signalGeneration;
			}
			set {
				SetValue(ref _signalGeneration, value);
			}
		}

		[Browsable(false)]
		public signalGeneration[] signalGenerationList => [(signalGeneration)1,(signalGeneration)2,(signalGeneration)3,(signalGeneration)4,(signalGeneration)5,(signalGeneration)6];
		[Category("LightSectored")]
		public ObservableCollection<ObscuredSectorViewModel> ObscuredSector  { get; set; } = new ();
		[Category("LightSectored")]
		public ObservableCollection<sectorCharacteristicsViewModel> sectorCharacteristics  { get; set; } = new ();


		public override FeatureViewModel<LightSectored> Load(LightSectored instance) {
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
			categoryOfLight.Clear();
			if (instance.categoryOfLight is not null) {
				foreach(var e in instance.categoryOfLight)
					categoryOfLight.Add(e);
			}
			exhibitionConditionOfLight = instance.exhibitionConditionOfLight;
			marksNavigationalSystemOf.Clear();
			if (instance.marksNavigationalSystemOf is not null) {
				foreach(var e in instance.marksNavigationalSystemOf)
					marksNavigationalSystemOf.Add(e);
			}
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
				colour = this.colour.ToList(),
				height = this.height,
				status = this.status.ToList(),
				verticalDatum = this.verticalDatum,
				verticalLength = this.verticalLength,
				effectiveIntensity = this.effectiveIntensity,
				peakIntensity = this.peakIntensity,
				categoryOfLight = this.categoryOfLight.ToList(),
				exhibitionConditionOfLight = this.exhibitionConditionOfLight,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf.ToList(),
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
			colour = this.colour.ToList(),
			height = this._height,
			status = this.status.ToList(),
			verticalDatum = this._verticalDatum,
			verticalLength = this._verticalLength,
			effectiveIntensity = this._effectiveIntensity,
			peakIntensity = this._peakIntensity,
			categoryOfLight = this.categoryOfLight.ToList(),
			exhibitionConditionOfLight = this._exhibitionConditionOfLight,
			marksNavigationalSystemOf = this.marksNavigationalSystemOf.ToList(),
			signalGeneration = this._signalGeneration,
			ObscuredSector = this.ObscuredSector.Select(e => e.Model).ToList(),
			sectorCharacteristics = this.sectorCharacteristics.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => LightSectored._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LightSectored._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LightSectored._featureBindingDefinitions;

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
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			categoryOfLight.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfLight));
			};
			marksNavigationalSystemOf.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(marksNavigationalSystemOf));
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
	[CategoryOrder("LightAllAround",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LightAllAroundViewModel : FeatureViewModel<LightAllAround> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Category("Equipment")]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		[Category("GenericLight")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13,(colour)14,(colour)15,(colour)16,(colour)17,(colour)18,(colour)19,(colour)20];
		private decimal? _height  = default;

		[Category("GenericLight")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		[Category("GenericLight")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private verticalDatum? _verticalDatum  = default;

		[Category("GenericLight")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45];
		private decimal? _verticalLength  = default;

		[Category("GenericLight")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private decimal? _effectiveIntensity  = default;

		[Category("GenericLight")]
		public decimal? effectiveIntensity {
			get {
				return _effectiveIntensity;
			}
			set {
				SetValue(ref _effectiveIntensity, value);
			}
		}
		private decimal? _peakIntensity  = default;

		[Category("GenericLight")]
		public decimal? peakIntensity {
			get {
				return _peakIntensity;
			}
			set {
				SetValue(ref _peakIntensity, value);
			}
		}

		[Category("LightAllAround")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfLightList), typeof(categoryOfLight))]
		public ObservableCollection<categoryOfLight> categoryOfLight  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfLight[] categoryOfLightList => [(categoryOfLight)1,(categoryOfLight)4,(categoryOfLight)5,(categoryOfLight)6,(categoryOfLight)8,(categoryOfLight)9,(categoryOfLight)10,(categoryOfLight)11,(categoryOfLight)12,(categoryOfLight)13,(categoryOfLight)14,(categoryOfLight)15,(categoryOfLight)17,(categoryOfLight)18,(categoryOfLight)19,(categoryOfLight)20];
		[Category("LightAllAround")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(exhibitionConditionOfLightList), typeof(exhibitionConditionOfLight))]
		public ObservableCollection<exhibitionConditionOfLight> exhibitionConditionOfLight  { get; set; } = new ();

		[Browsable(false)]
		public exhibitionConditionOfLight[] exhibitionConditionOfLightList => [(exhibitionConditionOfLight)1,(exhibitionConditionOfLight)2,(exhibitionConditionOfLight)3,(exhibitionConditionOfLight)4];
		private lightVisibility? _lightVisibility  = default;

		[Category("LightAllAround")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(lightVisibilityList), typeof(lightVisibility))]
		public lightVisibility? lightVisibility {
			get {
				return _lightVisibility;
			}
			set {
				SetValue(ref _lightVisibility, value);
			}
		}

		[Browsable(false)]
		public lightVisibility[] lightVisibilityList => [(lightVisibility)1,(lightVisibility)2,(lightVisibility)3,(lightVisibility)4,(lightVisibility)5,(lightVisibility)6,(lightVisibility)7,(lightVisibility)8,(lightVisibility)9];
		private Boolean? _majorLight  = default;

		[Category("LightAllAround")]
		public Boolean? majorLight {
			get {
				return _majorLight;
			}
			set {
				SetValue(ref _majorLight, value);
			}
		}
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("LightAllAround")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList), typeof(marksNavigationalSystemOf))]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Browsable(false)]
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)14,(marksNavigationalSystemOf)15];
		private signalGeneration? _signalGeneration  = default;

		[Category("LightAllAround")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(signalGenerationList), typeof(signalGeneration))]
		public signalGeneration? signalGeneration {
			get {
				return _signalGeneration;
			}
			set {
				SetValue(ref _signalGeneration, value);
			}
		}

		[Browsable(false)]
		public signalGeneration[] signalGenerationList => [(signalGeneration)1,(signalGeneration)2,(signalGeneration)3,(signalGeneration)4,(signalGeneration)5,(signalGeneration)6];
		private decimal? _valueOfNominalRange  = default;

		[Category("LightAllAround")]
		public decimal? valueOfNominalRange {
			get {
				return _valueOfNominalRange;
			}
			set {
				SetValue(ref _valueOfNominalRange, value);
			}
		}
		private multiplicityOfFeaturesViewModel? _multiplicityOfFeatures  = default;

		[Category("LightAllAround")]
		[ExpandableObject]
		public multiplicityOfFeaturesViewModel? multiplicityOfFeatures {
			get {
				return _multiplicityOfFeatures;
			}
			set {
				SetValue(ref _multiplicityOfFeatures, value);
			}
		}
		private rhythmOfLightViewModel _rhythmOfLight ;

		[Category("LightAllAround")]
		[ExpandableObject]
		public rhythmOfLightViewModel rhythmOfLight {
			get {
				return _rhythmOfLight;
			}
			set {
				SetValue(ref _rhythmOfLight, value);
			}
		}
		private int? _flareBearing  = default;

		[Category("LightAllAround")]
		public int? flareBearing {
			get {
				return _flareBearing;
			}
			set {
				SetValue(ref _flareBearing, value);
			}
		}


		public override FeatureViewModel<LightAllAround> Load(LightAllAround instance) {
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
			categoryOfLight.Clear();
			if (instance.categoryOfLight is not null) {
				foreach(var e in instance.categoryOfLight)
					categoryOfLight.Add(e);
			}
			exhibitionConditionOfLight.Clear();
			if (instance.exhibitionConditionOfLight is not null) {
				foreach(var e in instance.exhibitionConditionOfLight)
					exhibitionConditionOfLight.Add(e);
			}
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
				colour = this.colour.ToList(),
				height = this.height,
				status = this.status.ToList(),
				verticalDatum = this.verticalDatum,
				verticalLength = this.verticalLength,
				effectiveIntensity = this.effectiveIntensity,
				peakIntensity = this.peakIntensity,
				categoryOfLight = this.categoryOfLight.ToList(),
				exhibitionConditionOfLight = this.exhibitionConditionOfLight.ToList(),
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
			colour = this.colour.ToList(),
			height = this._height,
			status = this.status.ToList(),
			verticalDatum = this._verticalDatum,
			verticalLength = this._verticalLength,
			effectiveIntensity = this._effectiveIntensity,
			peakIntensity = this._peakIntensity,
			categoryOfLight = this.categoryOfLight.ToList(),
			exhibitionConditionOfLight = this.exhibitionConditionOfLight.ToList(),
			lightVisibility = this._lightVisibility,
			majorLight = this._majorLight,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			signalGeneration = this._signalGeneration,
			valueOfNominalRange = this._valueOfNominalRange,
			multiplicityOfFeatures = this._multiplicityOfFeatures?.Model,
			rhythmOfLight = this._rhythmOfLight?.Model,
			flareBearing = this._flareBearing,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => LightAllAround._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LightAllAround._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LightAllAround._featureBindingDefinitions;

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
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			categoryOfLight.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfLight));
			};
			exhibitionConditionOfLight.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(exhibitionConditionOfLight));
			};
		}
	}

	/// <summary>
	/// An air obstruction light is a light marking an obstacle which constitutes a danger to air navigation.
	/// </summary>
	[CategoryOrder("LightAirObstruction",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LightAirObstructionViewModel : FeatureViewModel<LightAirObstruction> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Category("Equipment")]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		[Category("GenericLight")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13,(colour)14,(colour)15,(colour)16,(colour)17,(colour)18,(colour)19,(colour)20];
		private decimal? _height  = default;

		[Category("GenericLight")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		[Category("GenericLight")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private verticalDatum? _verticalDatum  = default;

		[Category("GenericLight")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45];
		private decimal? _verticalLength  = default;

		[Category("GenericLight")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private decimal? _effectiveIntensity  = default;

		[Category("GenericLight")]
		public decimal? effectiveIntensity {
			get {
				return _effectiveIntensity;
			}
			set {
				SetValue(ref _effectiveIntensity, value);
			}
		}
		private decimal? _peakIntensity  = default;

		[Category("GenericLight")]
		public decimal? peakIntensity {
			get {
				return _peakIntensity;
			}
			set {
				SetValue(ref _peakIntensity, value);
			}
		}

		private exhibitionConditionOfLight? _exhibitionConditionOfLight  = default;

		[Category("LightAirObstruction")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(exhibitionConditionOfLightList), typeof(exhibitionConditionOfLight))]
		public exhibitionConditionOfLight? exhibitionConditionOfLight {
			get {
				return _exhibitionConditionOfLight;
			}
			set {
				SetValue(ref _exhibitionConditionOfLight, value);
			}
		}

		[Browsable(false)]
		public exhibitionConditionOfLight[] exhibitionConditionOfLightList => [(exhibitionConditionOfLight)1,(exhibitionConditionOfLight)2,(exhibitionConditionOfLight)3,(exhibitionConditionOfLight)4];
		[Category("LightAirObstruction")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(lightVisibilityList), typeof(lightVisibility))]
		public ObservableCollection<lightVisibility> lightVisibility  { get; set; } = new ();

		[Browsable(false)]
		public lightVisibility[] lightVisibilityList => [(lightVisibility)1,(lightVisibility)2,(lightVisibility)3,(lightVisibility)4,(lightVisibility)5,(lightVisibility)6,(lightVisibility)7,(lightVisibility)8,(lightVisibility)9];
		private decimal? _valueOfGeographicRange  = default;

		[Category("LightAirObstruction")]
		public decimal? valueOfGeographicRange {
			get {
				return _valueOfGeographicRange;
			}
			set {
				SetValue(ref _valueOfGeographicRange, value);
			}
		}
		private decimal? _valueOfLuminousRange  = default;

		[Category("LightAirObstruction")]
		public decimal? valueOfLuminousRange {
			get {
				return _valueOfLuminousRange;
			}
			set {
				SetValue(ref _valueOfLuminousRange, value);
			}
		}
		private decimal? _valueOfNominalRange  = default;

		[Category("LightAirObstruction")]
		public decimal? valueOfNominalRange {
			get {
				return _valueOfNominalRange;
			}
			set {
				SetValue(ref _valueOfNominalRange, value);
			}
		}
		private multiplicityOfFeaturesViewModel? _multiplicityOfFeatures  = default;

		[Category("LightAirObstruction")]
		[ExpandableObject]
		public multiplicityOfFeaturesViewModel? multiplicityOfFeatures {
			get {
				return _multiplicityOfFeatures;
			}
			set {
				SetValue(ref _multiplicityOfFeatures, value);
			}
		}
		private rhythmOfLightViewModel _rhythmOfLight ;

		[Category("LightAirObstruction")]
		[ExpandableObject]
		public rhythmOfLightViewModel rhythmOfLight {
			get {
				return _rhythmOfLight;
			}
			set {
				SetValue(ref _rhythmOfLight, value);
			}
		}
		private int? _flareBearing  = default;

		[Category("LightAirObstruction")]
		public int? flareBearing {
			get {
				return _flareBearing;
			}
			set {
				SetValue(ref _flareBearing, value);
			}
		}


		public override FeatureViewModel<LightAirObstruction> Load(LightAirObstruction instance) {
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
			exhibitionConditionOfLight = instance.exhibitionConditionOfLight;
			lightVisibility.Clear();
			if (instance.lightVisibility is not null) {
				foreach(var e in instance.lightVisibility)
					lightVisibility.Add(e);
			}
			valueOfGeographicRange = instance.valueOfGeographicRange;
			valueOfLuminousRange = instance.valueOfLuminousRange;
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
				colour = this.colour.ToList(),
				height = this.height,
				status = this.status.ToList(),
				verticalDatum = this.verticalDatum,
				verticalLength = this.verticalLength,
				effectiveIntensity = this.effectiveIntensity,
				peakIntensity = this.peakIntensity,
				exhibitionConditionOfLight = this.exhibitionConditionOfLight,
				lightVisibility = this.lightVisibility.ToList(),
				valueOfGeographicRange = this.valueOfGeographicRange,
				valueOfLuminousRange = this.valueOfLuminousRange,
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
			colour = this.colour.ToList(),
			height = this._height,
			status = this.status.ToList(),
			verticalDatum = this._verticalDatum,
			verticalLength = this._verticalLength,
			effectiveIntensity = this._effectiveIntensity,
			peakIntensity = this._peakIntensity,
			exhibitionConditionOfLight = this._exhibitionConditionOfLight,
			lightVisibility = this.lightVisibility.ToList(),
			valueOfGeographicRange = this._valueOfGeographicRange,
			valueOfLuminousRange = this._valueOfLuminousRange,
			valueOfNominalRange = this._valueOfNominalRange,
			multiplicityOfFeatures = this._multiplicityOfFeatures?.Model,
			rhythmOfLight = this._rhythmOfLight?.Model,
			flareBearing = this._flareBearing,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => LightAirObstruction._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LightAirObstruction._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LightAirObstruction._featureBindingDefinitions;

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
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			lightVisibility.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(lightVisibility));
			};
		}
	}

	/// <summary>
	/// A fog detector light is a light used to automatically determine conditions of visibility which warrant the turning on or off of a sound signal.
	/// </summary>
	[CategoryOrder("LightFogDetector",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LightFogDetectorViewModel : FeatureViewModel<LightFogDetector> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Category("Equipment")]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		[Category("GenericLight")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13,(colour)14,(colour)15,(colour)16,(colour)17,(colour)18,(colour)19,(colour)20];
		private decimal? _height  = default;

		[Category("GenericLight")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		[Category("GenericLight")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private verticalDatum? _verticalDatum  = default;

		[Category("GenericLight")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45];
		private decimal? _verticalLength  = default;

		[Category("GenericLight")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private decimal? _effectiveIntensity  = default;

		[Category("GenericLight")]
		public decimal? effectiveIntensity {
			get {
				return _effectiveIntensity;
			}
			set {
				SetValue(ref _effectiveIntensity, value);
			}
		}
		private decimal? _peakIntensity  = default;

		[Category("GenericLight")]
		public decimal? peakIntensity {
			get {
				return _peakIntensity;
			}
			set {
				SetValue(ref _peakIntensity, value);
			}
		}

		private signalGeneration? _signalGeneration  = default;

		[Category("LightFogDetector")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(signalGenerationList), typeof(signalGeneration))]
		public signalGeneration? signalGeneration {
			get {
				return _signalGeneration;
			}
			set {
				SetValue(ref _signalGeneration, value);
			}
		}

		[Browsable(false)]
		public signalGeneration[] signalGenerationList => [(signalGeneration)1,(signalGeneration)2,(signalGeneration)3,(signalGeneration)4,(signalGeneration)5,(signalGeneration)6];
		private rhythmOfLightViewModel _rhythmOfLight ;

		[Category("LightFogDetector")]
		[ExpandableObject]
		public rhythmOfLightViewModel rhythmOfLight {
			get {
				return _rhythmOfLight;
			}
			set {
				SetValue(ref _rhythmOfLight, value);
			}
		}


		public override FeatureViewModel<LightFogDetector> Load(LightFogDetector instance) {
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
				colour = this.colour.ToList(),
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
			colour = this.colour.ToList(),
			height = this._height,
			status = this.status.ToList(),
			verticalDatum = this._verticalDatum,
			verticalLength = this._verticalLength,
			effectiveIntensity = this._effectiveIntensity,
			peakIntensity = this._peakIntensity,
			signalGeneration = this._signalGeneration,
			rhythmOfLight = this._rhythmOfLight?.Model,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => LightFogDetector._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LightFogDetector._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LightFogDetector._featureBindingDefinitions;

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
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}

	/// <summary>
	/// A device capable of, or intended for, reflecting radar signals.
	/// </summary>
	[CategoryOrder("RadarReflector",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadarReflectorViewModel : FeatureViewModel<RadarReflector> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Category("Equipment")]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		private decimal? _height  = default;

		[Category("RadarReflector")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		[Category("RadarReflector")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private verticalDatum? _verticalDatum  = default;

		[Category("RadarReflector")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45];
		private decimal? _verticalAccuracy  = default;

		[Category("RadarReflector")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}


		public override FeatureViewModel<RadarReflector> Load(RadarReflector instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => RadarReflector._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RadarReflector._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RadarReflector._featureBindingDefinitions;

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
	[CategoryOrder("FogSignal",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class FogSignalViewModel : FeatureViewModel<FogSignal> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Category("Equipment")]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		private categoryOfFogSignal _categoryOfFogSignal ;

		[Category("FogSignal")]
		[Editor(typeof(Editors.UnknownEditor<categoryOfFogSignal?>), typeof(Editors.UnknownEditor<categoryOfFogSignal?>))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfFogSignalList), typeof(categoryOfFogSignal))]
		public categoryOfFogSignal categoryOfFogSignal {
			get {
				return _categoryOfFogSignal;
			}
			set {
				SetValue(ref _categoryOfFogSignal, value);
			}
		}

		[Browsable(false)]
		public categoryOfFogSignal[] categoryOfFogSignalList => [(categoryOfFogSignal)1,(categoryOfFogSignal)2,(categoryOfFogSignal)3,(categoryOfFogSignal)4,(categoryOfFogSignal)5,(categoryOfFogSignal)6,(categoryOfFogSignal)7,(categoryOfFogSignal)8,(categoryOfFogSignal)9,(categoryOfFogSignal)10];
		private int? _signalFrequency  = default;

		[Category("FogSignal")]
		public int? signalFrequency {
			get {
				return _signalFrequency;
			}
			set {
				SetValue(ref _signalFrequency, value);
			}
		}
		private signalGeneration? _signalGeneration  = default;

		[Category("FogSignal")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(signalGenerationList), typeof(signalGeneration))]
		public signalGeneration? signalGeneration {
			get {
				return _signalGeneration;
			}
			set {
				SetValue(ref _signalGeneration, value);
			}
		}

		[Browsable(false)]
		public signalGeneration[] signalGenerationList => [(signalGeneration)1,(signalGeneration)2,(signalGeneration)3,(signalGeneration)4,(signalGeneration)5,(signalGeneration)6];
		private String? _signalGroup  = default;

		[Category("FogSignal")]
		public String? signalGroup {
			get {
				return _signalGroup;
			}
			set {
				SetValue(ref _signalGroup, value);
			}
		}
		private decimal? _signalOutput  = default;

		[Category("FogSignal")]
		public decimal? signalOutput {
			get {
				return _signalOutput;
			}
			set {
				SetValue(ref _signalOutput, value);
			}
		}
		private decimal? _signalPeriod  = default;

		[Category("FogSignal")]
		public decimal? signalPeriod {
			get {
				return _signalPeriod;
			}
			set {
				SetValue(ref _signalPeriod, value);
			}
		}
		[Category("FogSignal")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private decimal? _valueOfMaximumRange  = default;

		[Category("FogSignal")]
		public decimal? valueOfMaximumRange {
			get {
				return _valueOfMaximumRange;
			}
			set {
				SetValue(ref _valueOfMaximumRange, value);
			}
		}
		private signalSequenceViewModel? _signalSequence  = default;

		[Category("FogSignal")]
		[ExpandableObject]
		public signalSequenceViewModel? signalSequence {
			get {
				return _signalSequence;
			}
			set {
				SetValue(ref _signalSequence, value);
			}
		}


		public override FeatureViewModel<FogSignal> Load(FogSignal instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => FogSignal._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. FogSignal._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FogSignal._featureBindingDefinitions;

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
	[CategoryOrder("EnvironmentObservationEquipment",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class EnvironmentObservationEquipmentViewModel : FeatureViewModel<EnvironmentObservationEquipment> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Category("Equipment")]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		private decimal? _height  = default;

		[Category("EnvironmentObservationEquipment")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		[Category("EnvironmentObservationEquipment")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		[Category("EnvironmentObservationEquipment")]
		public ObservableCollection<String> typeOfEnvironmentalObservationEquipment  { get; set; } = new ();


		public override FeatureViewModel<EnvironmentObservationEquipment> Load(EnvironmentObservationEquipment instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => EnvironmentObservationEquipment._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. EnvironmentObservationEquipment._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => EnvironmentObservationEquipment._featureBindingDefinitions;

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
	[CategoryOrder("RadioStation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadioStationViewModel : FeatureViewModel<RadioStation> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Category("Equipment")]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		private categoryOfRadioStation _categoryOfRadioStation ;

		[Category("RadioStation")]
		[Editor(typeof(Editors.UnknownEditor<categoryOfRadioStation?>), typeof(Editors.UnknownEditor<categoryOfRadioStation?>))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfRadioStationList), typeof(categoryOfRadioStation))]
		public categoryOfRadioStation categoryOfRadioStation {
			get {
				return _categoryOfRadioStation;
			}
			set {
				SetValue(ref _categoryOfRadioStation, value);
			}
		}

		[Browsable(false)]
		public categoryOfRadioStation[] categoryOfRadioStationList => [(categoryOfRadioStation)1,(categoryOfRadioStation)2,(categoryOfRadioStation)3,(categoryOfRadioStation)4,(categoryOfRadioStation)5,(categoryOfRadioStation)6,(categoryOfRadioStation)7,(categoryOfRadioStation)8,(categoryOfRadioStation)9,(categoryOfRadioStation)10,(categoryOfRadioStation)11,(categoryOfRadioStation)12,(categoryOfRadioStation)13,(categoryOfRadioStation)14,(categoryOfRadioStation)19,(categoryOfRadioStation)20];
		private decimal? _estimatedRangeOfTransmission  = default;

		[Category("RadioStation")]
		public decimal? estimatedRangeOfTransmission {
			get {
				return _estimatedRangeOfTransmission;
			}
			set {
				SetValue(ref _estimatedRangeOfTransmission, value);
			}
		}
		private status? _status  = default;

		[Category("RadioStation")]
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
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];


		public override FeatureViewModel<RadioStation> Load(RadioStation instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => RadioStation._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RadioStation._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RadioStation._featureBindingDefinitions;

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
		}
	}

	/// <summary>
	/// (1) The identifying characteristics of an aid to navigation which serve to facilitate its recognition against a daylight viewing background. On those structures that do not by themselves present an adequate viewing area to be seen at the required distance, the aid is made more visible by affixing a daymark to the structure. A daymark so affixed has a distinctive colour and shape depending on the purpose of the aid. (2) An unlighted navigational mark.
	/// </summary>
	[CategoryOrder("Daymark",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DaymarkViewModel : FeatureViewModel<Daymark> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Category("Equipment")]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		private categoryOfSpecialPurposeMark? _categoryOfSpecialPurposeMark  = default;

		[Category("Daymark")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfSpecialPurposeMarkList), typeof(categoryOfSpecialPurposeMark))]
		public categoryOfSpecialPurposeMark? categoryOfSpecialPurposeMark {
			get {
				return _categoryOfSpecialPurposeMark;
			}
			set {
				SetValue(ref _categoryOfSpecialPurposeMark, value);
			}
		}

		[Browsable(false)]
		public categoryOfSpecialPurposeMark[] categoryOfSpecialPurposeMarkList => [(categoryOfSpecialPurposeMark)1,(categoryOfSpecialPurposeMark)2,(categoryOfSpecialPurposeMark)3,(categoryOfSpecialPurposeMark)4,(categoryOfSpecialPurposeMark)5,(categoryOfSpecialPurposeMark)6,(categoryOfSpecialPurposeMark)7,(categoryOfSpecialPurposeMark)8,(categoryOfSpecialPurposeMark)9,(categoryOfSpecialPurposeMark)10,(categoryOfSpecialPurposeMark)11,(categoryOfSpecialPurposeMark)12,(categoryOfSpecialPurposeMark)13,(categoryOfSpecialPurposeMark)14,(categoryOfSpecialPurposeMark)15,(categoryOfSpecialPurposeMark)16,(categoryOfSpecialPurposeMark)17,(categoryOfSpecialPurposeMark)18,(categoryOfSpecialPurposeMark)19,(categoryOfSpecialPurposeMark)20,(categoryOfSpecialPurposeMark)21,(categoryOfSpecialPurposeMark)22,(categoryOfSpecialPurposeMark)23,(categoryOfSpecialPurposeMark)24,(categoryOfSpecialPurposeMark)25,(categoryOfSpecialPurposeMark)26,(categoryOfSpecialPurposeMark)27,(categoryOfSpecialPurposeMark)28,(categoryOfSpecialPurposeMark)29,(categoryOfSpecialPurposeMark)30,(categoryOfSpecialPurposeMark)31,(categoryOfSpecialPurposeMark)32,(categoryOfSpecialPurposeMark)33,(categoryOfSpecialPurposeMark)34,(categoryOfSpecialPurposeMark)35,(categoryOfSpecialPurposeMark)36,(categoryOfSpecialPurposeMark)37,(categoryOfSpecialPurposeMark)39,(categoryOfSpecialPurposeMark)40,(categoryOfSpecialPurposeMark)41,(categoryOfSpecialPurposeMark)42,(categoryOfSpecialPurposeMark)43,(categoryOfSpecialPurposeMark)44,(categoryOfSpecialPurposeMark)45,(categoryOfSpecialPurposeMark)46,(categoryOfSpecialPurposeMark)47,(categoryOfSpecialPurposeMark)48,(categoryOfSpecialPurposeMark)49,(categoryOfSpecialPurposeMark)50,(categoryOfSpecialPurposeMark)51,(categoryOfSpecialPurposeMark)52,(categoryOfSpecialPurposeMark)53,(categoryOfSpecialPurposeMark)54,(categoryOfSpecialPurposeMark)55,(categoryOfSpecialPurposeMark)56,(categoryOfSpecialPurposeMark)57,(categoryOfSpecialPurposeMark)58,(categoryOfSpecialPurposeMark)59,(categoryOfSpecialPurposeMark)60,(categoryOfSpecialPurposeMark)61,(categoryOfSpecialPurposeMark)62,(categoryOfSpecialPurposeMark)63,(categoryOfSpecialPurposeMark)64];
		[Category("Daymark")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("Daymark")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		private decimal? _elevation  = default;

		[Category("Daymark")]
		public decimal? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}
		private decimal? _height  = default;

		[Category("Daymark")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		[Category("Daymark")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private decimal? _orientationValue  = default;

		[Category("Daymark")]
		public decimal? orientationValue {
			get {
				return _orientationValue;
			}
			set {
				SetValue(ref _orientationValue, value);
			}
		}
		[Category("Daymark")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private topmarkDaymarkShape _topmarkDaymarkShape ;

		[Category("Daymark")]
		[Editor(typeof(Editors.UnknownEditor<topmarkDaymarkShape?>), typeof(Editors.UnknownEditor<topmarkDaymarkShape?>))]
		[DomainModel.EnumerationAttribute(nameof(topmarkDaymarkShapeList), typeof(topmarkDaymarkShape))]
		public topmarkDaymarkShape topmarkDaymarkShape {
			get {
				return _topmarkDaymarkShape;
			}
			set {
				SetValue(ref _topmarkDaymarkShape, value);
			}
		}

		[Browsable(false)]
		public topmarkDaymarkShape[] topmarkDaymarkShapeList => [(topmarkDaymarkShape)1,(topmarkDaymarkShape)2,(topmarkDaymarkShape)3,(topmarkDaymarkShape)4,(topmarkDaymarkShape)5,(topmarkDaymarkShape)6,(topmarkDaymarkShape)7,(topmarkDaymarkShape)8,(topmarkDaymarkShape)9,(topmarkDaymarkShape)10,(topmarkDaymarkShape)11,(topmarkDaymarkShape)12,(topmarkDaymarkShape)13,(topmarkDaymarkShape)14,(topmarkDaymarkShape)15,(topmarkDaymarkShape)16,(topmarkDaymarkShape)17,(topmarkDaymarkShape)18,(topmarkDaymarkShape)19,(topmarkDaymarkShape)20,(topmarkDaymarkShape)21,(topmarkDaymarkShape)22,(topmarkDaymarkShape)23,(topmarkDaymarkShape)24,(topmarkDaymarkShape)25,(topmarkDaymarkShape)26,(topmarkDaymarkShape)27,(topmarkDaymarkShape)28,(topmarkDaymarkShape)29,(topmarkDaymarkShape)30,(topmarkDaymarkShape)31,(topmarkDaymarkShape)32,(topmarkDaymarkShape)33,(topmarkDaymarkShape)34];
		private verticalDatum? _verticalDatum  = default;

		[Category("Daymark")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45];
		private decimal? _verticalLength  = default;

		[Category("Daymark")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private shapeInformationViewModel? _shapeInformation  = default;

		[Category("Daymark")]
		[ExpandableObject]
		public shapeInformationViewModel? shapeInformation {
			get {
				return _shapeInformation;
			}
			set {
				SetValue(ref _shapeInformation, value);
			}
		}
		private Boolean _isSlatted  = false;

		[Category("Daymark")]
		[Editor(typeof(Editors.UnknownEditor<Boolean?>), typeof(Editors.UnknownEditor<Boolean?>))]
		public Boolean isSlatted {
			get {
				return _isSlatted;
			}
			set {
				SetValue(ref _isSlatted, value);
			}
		}


		public override FeatureViewModel<Daymark> Load(Daymark instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => Daymark._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Daymark._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Daymark._featureBindingDefinitions;

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
	[CategoryOrder("Retroreflector",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RetroreflectorViewModel : FeatureViewModel<Retroreflector> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Category("Equipment")]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		[Category("Retroreflector")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("Retroreflector")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("Retroreflector")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList), typeof(marksNavigationalSystemOf))]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Browsable(false)]
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)14,(marksNavigationalSystemOf)15];
		[Category("Retroreflector")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private verticalDatum? _verticalDatum  = default;

		[Category("Retroreflector")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45];
		private decimal? _height  = default;

		[Category("Retroreflector")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private decimal? _verticalAccuracy  = default;

		[Category("Retroreflector")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}


		public override FeatureViewModel<Retroreflector> Load(Retroreflector instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => Retroreflector._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Retroreflector._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Retroreflector._featureBindingDefinitions;

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
	[CategoryOrder("RadarTransponderBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadarTransponderBeaconViewModel : FeatureViewModel<RadarTransponderBeacon> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Category("Equipment")]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		private categoryOfRadarTransponderBeacon _categoryOfRadarTransponderBeacon ;

		[Category("RadarTransponderBeacon")]
		[Editor(typeof(Editors.UnknownEditor<categoryOfRadarTransponderBeacon?>), typeof(Editors.UnknownEditor<categoryOfRadarTransponderBeacon?>))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfRadarTransponderBeaconList), typeof(categoryOfRadarTransponderBeacon))]
		public categoryOfRadarTransponderBeacon categoryOfRadarTransponderBeacon {
			get {
				return _categoryOfRadarTransponderBeacon;
			}
			set {
				SetValue(ref _categoryOfRadarTransponderBeacon, value);
			}
		}

		[Browsable(false)]
		public categoryOfRadarTransponderBeacon[] categoryOfRadarTransponderBeaconList => [(categoryOfRadarTransponderBeacon)1,(categoryOfRadarTransponderBeacon)2,(categoryOfRadarTransponderBeacon)3];
		private radarWaveLengthViewModel? _radarWaveLength  = default;

		[Category("RadarTransponderBeacon")]
		[ExpandableObject]
		public radarWaveLengthViewModel? radarWaveLength {
			get {
				return _radarWaveLength;
			}
			set {
				SetValue(ref _radarWaveLength, value);
			}
		}
		private String? _signalGroup  = default;

		[Category("RadarTransponderBeacon")]
		public String? signalGroup {
			get {
				return _signalGroup;
			}
			set {
				SetValue(ref _signalGroup, value);
			}
		}
		[Category("RadarTransponderBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private decimal? _valueOfNominalRange  = default;

		[Category("RadarTransponderBeacon")]
		public decimal? valueOfNominalRange {
			get {
				return _valueOfNominalRange;
			}
			set {
				SetValue(ref _valueOfNominalRange, value);
			}
		}
		private String? _manufactorer  = default;

		[Category("RadarTransponderBeacon")]
		public String? manufactorer {
			get {
				return _manufactorer;
			}
			set {
				SetValue(ref _manufactorer, value);
			}
		}
		private sectorLimitOneViewModel? _sectorLimitOne  = default;

		[Category("RadarTransponderBeacon")]
		[ExpandableObject]
		public sectorLimitOneViewModel? sectorLimitOne {
			get {
				return _sectorLimitOne;
			}
			set {
				SetValue(ref _sectorLimitOne, value);
			}
		}
		private sectorLimitTwoViewModel? _sectorLimitTwo  = default;

		[Category("RadarTransponderBeacon")]
		[ExpandableObject]
		public sectorLimitTwoViewModel? sectorLimitTwo {
			get {
				return _sectorLimitTwo;
			}
			set {
				SetValue(ref _sectorLimitTwo, value);
			}
		}
		private signalSequenceViewModel? _signalSequence  = default;

		[Category("RadarTransponderBeacon")]
		[ExpandableObject]
		public signalSequenceViewModel? signalSequence {
			get {
				return _signalSequence;
			}
			set {
				SetValue(ref _signalSequence, value);
			}
		}


		public override FeatureViewModel<RadarTransponderBeacon> Load(RadarTransponderBeacon instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => RadarTransponderBeacon._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RadarTransponderBeacon._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RadarTransponderBeacon._featureBindingDefinitions;

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
	[CategoryOrder("VirtualAISAidToNavigation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class VirtualAISAidToNavigationViewModel : FeatureViewModel<VirtualAISAidToNavigation> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String? _AtoNNumber  = default;

		[Category("ElectronicAton")]
		public String? AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private String _mMSICode  = string.Empty;

		[Category("ElectronicAton")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String mMSICode {
			get {
				return _mMSICode;
			}
			set {
				SetValue(ref _mMSICode, value);
			}
		}
		[Category("ElectronicAton")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => Enum.GetValues<status>();

		private virtualAISAidToNavigationType _virtualAISAidToNavigationType ;

		[Category("VirtualAISAidToNavigation")]
		[Editor(typeof(Editors.UnknownEditor<virtualAISAidToNavigationType?>), typeof(Editors.UnknownEditor<virtualAISAidToNavigationType?>))]
		[DomainModel.EnumerationAttribute(nameof(virtualAISAidToNavigationTypeList), typeof(virtualAISAidToNavigationType))]
		public virtualAISAidToNavigationType virtualAISAidToNavigationType {
			get {
				return _virtualAISAidToNavigationType;
			}
			set {
				SetValue(ref _virtualAISAidToNavigationType, value);
			}
		}

		[Browsable(false)]
		public virtualAISAidToNavigationType[] virtualAISAidToNavigationTypeList => [(virtualAISAidToNavigationType)1,(virtualAISAidToNavigationType)2,(virtualAISAidToNavigationType)3,(virtualAISAidToNavigationType)4,(virtualAISAidToNavigationType)5,(virtualAISAidToNavigationType)6,(virtualAISAidToNavigationType)7,(virtualAISAidToNavigationType)8,(virtualAISAidToNavigationType)9,(virtualAISAidToNavigationType)10,(virtualAISAidToNavigationType)11,(virtualAISAidToNavigationType)12];


		public override FeatureViewModel<VirtualAISAidToNavigation> Load(VirtualAISAidToNavigation instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => VirtualAISAidToNavigation._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. VirtualAISAidToNavigation._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => VirtualAISAidToNavigation._featureBindingDefinitions;

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
		}
	}

	/// <summary>
	/// An Automatic Identification System (AIS) message 21 transmitted from a physical Aid to Navigation, or transmitted from an AIS station for an Aid to Navigation which physically exists.
	/// </summary>
	[CategoryOrder("PhysicalAISAidToNavigation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PhysicalAISAidToNavigationViewModel : FeatureViewModel<PhysicalAISAidToNavigation> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String? _AtoNNumber  = default;

		[Category("ElectronicAton")]
		public String? AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private String _mMSICode  = string.Empty;

		[Category("ElectronicAton")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String mMSICode {
			get {
				return _mMSICode;
			}
			set {
				SetValue(ref _mMSICode, value);
			}
		}
		[Category("ElectronicAton")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => Enum.GetValues<status>();

		private CategoryOfPhysicalAISAidToNavigation _CategoryOfPhysicalAISAidToNavigation ;

		[Category("PhysicalAISAidToNavigation")]
		[Editor(typeof(Editors.UnknownEditor<CategoryOfPhysicalAISAidToNavigation?>), typeof(Editors.UnknownEditor<CategoryOfPhysicalAISAidToNavigation?>))]
		[DomainModel.EnumerationAttribute(nameof(CategoryOfPhysicalAISAidToNavigationList), typeof(CategoryOfPhysicalAISAidToNavigation))]
		public CategoryOfPhysicalAISAidToNavigation CategoryOfPhysicalAISAidToNavigation {
			get {
				return _CategoryOfPhysicalAISAidToNavigation;
			}
			set {
				SetValue(ref _CategoryOfPhysicalAISAidToNavigation, value);
			}
		}

		[Browsable(false)]
		public CategoryOfPhysicalAISAidToNavigation[] CategoryOfPhysicalAISAidToNavigationList => [(CategoryOfPhysicalAISAidToNavigation)1,(CategoryOfPhysicalAISAidToNavigation)2,(CategoryOfPhysicalAISAidToNavigation)3];


		public override FeatureViewModel<PhysicalAISAidToNavigation> Load(PhysicalAISAidToNavigation instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => PhysicalAISAidToNavigation._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. PhysicalAISAidToNavigation._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => PhysicalAISAidToNavigation._featureBindingDefinitions;

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
		}
	}

	/// <summary>
	/// -
	/// </summary>
	[CategoryOrder("SyntheticAISAidToNavigation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SyntheticAISAidToNavigationViewModel : FeatureViewModel<SyntheticAISAidToNavigation> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String? _AtoNNumber  = default;

		[Category("ElectronicAton")]
		public String? AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private String _mMSICode  = string.Empty;

		[Category("ElectronicAton")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String mMSICode {
			get {
				return _mMSICode;
			}
			set {
				SetValue(ref _mMSICode, value);
			}
		}
		[Category("ElectronicAton")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => Enum.GetValues<status>();

		private CategoryOfSyntheticAISAidtoNavigation _CategoryOfSyntheticAISAidtoNavigation ;

		[Category("SyntheticAISAidToNavigation")]
		[Editor(typeof(Editors.UnknownEditor<CategoryOfSyntheticAISAidtoNavigation?>), typeof(Editors.UnknownEditor<CategoryOfSyntheticAISAidtoNavigation?>))]
		[DomainModel.EnumerationAttribute(nameof(CategoryOfSyntheticAISAidtoNavigationList), typeof(CategoryOfSyntheticAISAidtoNavigation))]
		public CategoryOfSyntheticAISAidtoNavigation CategoryOfSyntheticAISAidtoNavigation {
			get {
				return _CategoryOfSyntheticAISAidtoNavigation;
			}
			set {
				SetValue(ref _CategoryOfSyntheticAISAidtoNavigation, value);
			}
		}

		[Browsable(false)]
		public CategoryOfSyntheticAISAidtoNavigation[] CategoryOfSyntheticAISAidtoNavigationList => [(CategoryOfSyntheticAISAidtoNavigation)1,(CategoryOfSyntheticAISAidtoNavigation)2];
		private virtualAISAidToNavigationType _virtualAISAidToNavigationType ;

		[Category("SyntheticAISAidToNavigation")]
		[Editor(typeof(Editors.UnknownEditor<virtualAISAidToNavigationType?>), typeof(Editors.UnknownEditor<virtualAISAidToNavigationType?>))]
		[DomainModel.EnumerationAttribute(nameof(virtualAISAidToNavigationTypeList), typeof(virtualAISAidToNavigationType))]
		public virtualAISAidToNavigationType virtualAISAidToNavigationType {
			get {
				return _virtualAISAidToNavigationType;
			}
			set {
				SetValue(ref _virtualAISAidToNavigationType, value);
			}
		}

		[Browsable(false)]
		public virtualAISAidToNavigationType[] virtualAISAidToNavigationTypeList => [(virtualAISAidToNavigationType)1,(virtualAISAidToNavigationType)2,(virtualAISAidToNavigationType)3,(virtualAISAidToNavigationType)4,(virtualAISAidToNavigationType)5,(virtualAISAidToNavigationType)6,(virtualAISAidToNavigationType)7,(virtualAISAidToNavigationType)8,(virtualAISAidToNavigationType)9,(virtualAISAidToNavigationType)10,(virtualAISAidToNavigationType)11,(virtualAISAidToNavigationType)12];


		public override FeatureViewModel<SyntheticAISAidToNavigation> Load(SyntheticAISAidToNavigation instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => SyntheticAISAidToNavigation._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SyntheticAISAidToNavigation._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SyntheticAISAidToNavigation._featureBindingDefinitions;

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
		}
	}

	/// <summary>
	/// -
	/// </summary>
	[CategoryOrder("PowerSource",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PowerSourceViewModel : FeatureViewModel<PowerSource> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Category("Equipment")]
		public ObservableCollection<String> remoteMonitoringSystem  { get; set; } = new ();

		private CategoryOfPowerSource _CategoryOfPowerSource ;

		[Category("PowerSource")]
		[Editor(typeof(Editors.UnknownEditor<CategoryOfPowerSource?>), typeof(Editors.UnknownEditor<CategoryOfPowerSource?>))]
		[DomainModel.EnumerationAttribute(nameof(CategoryOfPowerSourceList), typeof(CategoryOfPowerSource))]
		public CategoryOfPowerSource CategoryOfPowerSource {
			get {
				return _CategoryOfPowerSource;
			}
			set {
				SetValue(ref _CategoryOfPowerSource, value);
			}
		}

		[Browsable(false)]
		public CategoryOfPowerSource[] CategoryOfPowerSourceList => [(CategoryOfPowerSource)1,(CategoryOfPowerSource)2,(CategoryOfPowerSource)3,(CategoryOfPowerSource)4];
		[Category("PowerSource")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];


		public override FeatureViewModel<PowerSource> Load(PowerSource instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => PowerSource._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. PowerSource._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => PowerSource._featureBindingDefinitions;

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
	/// A beacon is a prominent specially constructed object forming a conspicuous mark as a fixed aid to navigation or for use in hydrographic survey (IHO Dictionary, S-32, 5th Edition, 420). An isolated danger beacon is a beacon erected on an isolated danger of limited extent, which has navigable water all around it. (UKHO NP735, 5th Edition)
	/// </summary>
	[CategoryOrder("IsolatedDangerBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class IsolatedDangerBeaconViewModel : FeatureViewModel<IsolatedDangerBeacon> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private beaconShape _beaconShape ;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.UnknownEditor<beaconShape?>), typeof(Editors.UnknownEditor<beaconShape?>))]
		[DomainModel.EnumerationAttribute(nameof(beaconShapeList), typeof(beaconShape))]
		public beaconShape beaconShape {
			get {
				return _beaconShape;
			}
			set {
				SetValue(ref _beaconShape, value);
			}
		}

		[Browsable(false)]
		public beaconShape[] beaconShapeList => [(beaconShape)1,(beaconShape)2,(beaconShape)3,(beaconShape)4,(beaconShape)5,(beaconShape)6,(beaconShape)7];
		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		private decimal? _elevation  = default;

		[Category("GenericBeacon")]
		public decimal? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}
		private decimal? _height  = default;

		[Category("GenericBeacon")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList), typeof(marksNavigationalSystemOf))]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Browsable(false)]
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)14,(marksNavigationalSystemOf)15];
		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private Boolean? _radarConspicuous  = default;

		[Category("GenericBeacon")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private decimal? _verticalLength  = default;

		[Category("GenericBeacon")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private visualProminence? _visualProminence  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(visualProminenceList), typeof(visualProminence))]
		public visualProminence? visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		[Browsable(false)]
		public visualProminence[] visualProminenceList => [(visualProminence)1,(visualProminence)2,(visualProminence)3];
		private decimal? _verticalAccuracy  = default;

		[Category("GenericBeacon")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}



		public override FeatureViewModel<IsolatedDangerBeacon> Load(IsolatedDangerBeacon instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => IsolatedDangerBeacon._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. IsolatedDangerBeacon._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => IsolatedDangerBeacon._featureBindingDefinitions;

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
	[CategoryOrder("CardinalBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CardinalBeaconViewModel : FeatureViewModel<CardinalBeacon> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private beaconShape _beaconShape ;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.UnknownEditor<beaconShape?>), typeof(Editors.UnknownEditor<beaconShape?>))]
		[DomainModel.EnumerationAttribute(nameof(beaconShapeList), typeof(beaconShape))]
		public beaconShape beaconShape {
			get {
				return _beaconShape;
			}
			set {
				SetValue(ref _beaconShape, value);
			}
		}

		[Browsable(false)]
		public beaconShape[] beaconShapeList => [(beaconShape)1,(beaconShape)2,(beaconShape)3,(beaconShape)4,(beaconShape)5,(beaconShape)6,(beaconShape)7];
		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		private decimal? _elevation  = default;

		[Category("GenericBeacon")]
		public decimal? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}
		private decimal? _height  = default;

		[Category("GenericBeacon")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList), typeof(marksNavigationalSystemOf))]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Browsable(false)]
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)14,(marksNavigationalSystemOf)15];
		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private Boolean? _radarConspicuous  = default;

		[Category("GenericBeacon")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private decimal? _verticalLength  = default;

		[Category("GenericBeacon")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private visualProminence? _visualProminence  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(visualProminenceList), typeof(visualProminence))]
		public visualProminence? visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		[Browsable(false)]
		public visualProminence[] visualProminenceList => [(visualProminence)1,(visualProminence)2,(visualProminence)3];
		private decimal? _verticalAccuracy  = default;

		[Category("GenericBeacon")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}

		private categoryOfCardinalMark _categoryOfCardinalMark ;

		[Category("CardinalBeacon")]
		[Editor(typeof(Editors.UnknownEditor<categoryOfCardinalMark?>), typeof(Editors.UnknownEditor<categoryOfCardinalMark?>))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfCardinalMarkList), typeof(categoryOfCardinalMark))]
		public categoryOfCardinalMark categoryOfCardinalMark {
			get {
				return _categoryOfCardinalMark;
			}
			set {
				SetValue(ref _categoryOfCardinalMark, value);
			}
		}

		[Browsable(false)]
		public categoryOfCardinalMark[] categoryOfCardinalMarkList => [(categoryOfCardinalMark)1,(categoryOfCardinalMark)2,(categoryOfCardinalMark)3,(categoryOfCardinalMark)4];


		public override FeatureViewModel<CardinalBeacon> Load(CardinalBeacon instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => CardinalBeacon._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. CardinalBeacon._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => CardinalBeacon._featureBindingDefinitions;

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
	/// A buoy is a floating object moored to the bottom in a particular place, as an aid to navigation or for other specific purposes. (IHO Dictionary, S-32, 5th Edition, 565). A isolated danger buoy is a buoy moored on or above an isolated danger of limited extent, which has navigable water all around it. (UKHO NP735, 5th Edition)
	/// </summary>
	[CategoryOrder("IsolatedDangerBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class IsolatedDangerBuoyViewModel : FeatureViewModel<IsolatedDangerBuoy> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private buoyShape _buoyShape ;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.UnknownEditor<buoyShape?>), typeof(Editors.UnknownEditor<buoyShape?>))]
		[DomainModel.EnumerationAttribute(nameof(buoyShapeList), typeof(buoyShape))]
		public buoyShape buoyShape {
			get {
				return _buoyShape;
			}
			set {
				SetValue(ref _buoyShape, value);
			}
		}

		[Browsable(false)]
		public buoyShape[] buoyShapeList => [(buoyShape)1,(buoyShape)2,(buoyShape)3,(buoyShape)4,(buoyShape)5,(buoyShape)6,(buoyShape)7,(buoyShape)8];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList), typeof(marksNavigationalSystemOf))]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Browsable(false)]
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)14,(marksNavigationalSystemOf)15];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private Boolean? _radarConspicuous  = default;

		[Category("GenericBuoy")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private String? _typeOfBuoy  = default;

		[Category("GenericBuoy")]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}
		private decimal? _verticalLength  = default;

		[Category("GenericBuoy")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private decimal? _verticalAccuracy  = default;

		[Category("GenericBuoy")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}



		public override FeatureViewModel<IsolatedDangerBuoy> Load(IsolatedDangerBuoy instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => IsolatedDangerBuoy._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. IsolatedDangerBuoy._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => IsolatedDangerBuoy._featureBindingDefinitions;

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
	[CategoryOrder("CardinalBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CardinalBuoyViewModel : FeatureViewModel<CardinalBuoy> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private buoyShape _buoyShape ;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.UnknownEditor<buoyShape?>), typeof(Editors.UnknownEditor<buoyShape?>))]
		[DomainModel.EnumerationAttribute(nameof(buoyShapeList), typeof(buoyShape))]
		public buoyShape buoyShape {
			get {
				return _buoyShape;
			}
			set {
				SetValue(ref _buoyShape, value);
			}
		}

		[Browsable(false)]
		public buoyShape[] buoyShapeList => [(buoyShape)1,(buoyShape)2,(buoyShape)3,(buoyShape)4,(buoyShape)5,(buoyShape)6,(buoyShape)7,(buoyShape)8];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList), typeof(marksNavigationalSystemOf))]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Browsable(false)]
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)14,(marksNavigationalSystemOf)15];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private Boolean? _radarConspicuous  = default;

		[Category("GenericBuoy")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private String? _typeOfBuoy  = default;

		[Category("GenericBuoy")]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}
		private decimal? _verticalLength  = default;

		[Category("GenericBuoy")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private decimal? _verticalAccuracy  = default;

		[Category("GenericBuoy")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}

		private categoryOfCardinalMark _categoryOfCardinalMark ;

		[Category("CardinalBuoy")]
		[Editor(typeof(Editors.UnknownEditor<categoryOfCardinalMark?>), typeof(Editors.UnknownEditor<categoryOfCardinalMark?>))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfCardinalMarkList), typeof(categoryOfCardinalMark))]
		public categoryOfCardinalMark categoryOfCardinalMark {
			get {
				return _categoryOfCardinalMark;
			}
			set {
				SetValue(ref _categoryOfCardinalMark, value);
			}
		}

		[Browsable(false)]
		public categoryOfCardinalMark[] categoryOfCardinalMarkList => [(categoryOfCardinalMark)1,(categoryOfCardinalMark)2,(categoryOfCardinalMark)3,(categoryOfCardinalMark)4];


		public override FeatureViewModel<CardinalBuoy> Load(CardinalBuoy instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => CardinalBuoy._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. CardinalBuoy._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => CardinalBuoy._featureBindingDefinitions;

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
	[CategoryOrder("InstallationBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class InstallationBuoyViewModel : FeatureViewModel<InstallationBuoy> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private buoyShape _buoyShape ;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.UnknownEditor<buoyShape?>), typeof(Editors.UnknownEditor<buoyShape?>))]
		[DomainModel.EnumerationAttribute(nameof(buoyShapeList), typeof(buoyShape))]
		public buoyShape buoyShape {
			get {
				return _buoyShape;
			}
			set {
				SetValue(ref _buoyShape, value);
			}
		}

		[Browsable(false)]
		public buoyShape[] buoyShapeList => [(buoyShape)1,(buoyShape)2,(buoyShape)3,(buoyShape)4,(buoyShape)5,(buoyShape)6,(buoyShape)7,(buoyShape)8];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList), typeof(marksNavigationalSystemOf))]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Browsable(false)]
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)14,(marksNavigationalSystemOf)15];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private Boolean? _radarConspicuous  = default;

		[Category("GenericBuoy")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private String? _typeOfBuoy  = default;

		[Category("GenericBuoy")]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}
		private decimal? _verticalLength  = default;

		[Category("GenericBuoy")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private decimal? _verticalAccuracy  = default;

		[Category("GenericBuoy")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}

		private categoryOfInstallationBuoy _categoryOfInstallationBuoy ;

		[Category("InstallationBuoy")]
		[Editor(typeof(Editors.UnknownEditor<categoryOfInstallationBuoy?>), typeof(Editors.UnknownEditor<categoryOfInstallationBuoy?>))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfInstallationBuoyList), typeof(categoryOfInstallationBuoy))]
		public categoryOfInstallationBuoy categoryOfInstallationBuoy {
			get {
				return _categoryOfInstallationBuoy;
			}
			set {
				SetValue(ref _categoryOfInstallationBuoy, value);
			}
		}

		[Browsable(false)]
		public categoryOfInstallationBuoy[] categoryOfInstallationBuoyList => [(categoryOfInstallationBuoy)1,(categoryOfInstallationBuoy)2];


		public override FeatureViewModel<InstallationBuoy> Load(InstallationBuoy instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => InstallationBuoy._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InstallationBuoy._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => InstallationBuoy._featureBindingDefinitions;

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
	[CategoryOrder("MooringBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class MooringBuoyViewModel : FeatureViewModel<MooringBuoy> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private buoyShape _buoyShape ;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.UnknownEditor<buoyShape?>), typeof(Editors.UnknownEditor<buoyShape?>))]
		[DomainModel.EnumerationAttribute(nameof(buoyShapeList), typeof(buoyShape))]
		public buoyShape buoyShape {
			get {
				return _buoyShape;
			}
			set {
				SetValue(ref _buoyShape, value);
			}
		}

		[Browsable(false)]
		public buoyShape[] buoyShapeList => [(buoyShape)1,(buoyShape)2,(buoyShape)3,(buoyShape)4,(buoyShape)5,(buoyShape)6,(buoyShape)7,(buoyShape)8];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList), typeof(marksNavigationalSystemOf))]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Browsable(false)]
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)14,(marksNavigationalSystemOf)15];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private Boolean? _radarConspicuous  = default;

		[Category("GenericBuoy")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private String? _typeOfBuoy  = default;

		[Category("GenericBuoy")]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}
		private decimal? _verticalLength  = default;

		[Category("GenericBuoy")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private decimal? _verticalAccuracy  = default;

		[Category("GenericBuoy")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}



		public override FeatureViewModel<MooringBuoy> Load(MooringBuoy instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => MooringBuoy._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. MooringBuoy._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => MooringBuoy._featureBindingDefinitions;

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
	[CategoryOrder("EmergencyWreckMarkingBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class EmergencyWreckMarkingBuoyViewModel : FeatureViewModel<EmergencyWreckMarkingBuoy> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private buoyShape _buoyShape ;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.UnknownEditor<buoyShape?>), typeof(Editors.UnknownEditor<buoyShape?>))]
		[DomainModel.EnumerationAttribute(nameof(buoyShapeList), typeof(buoyShape))]
		public buoyShape buoyShape {
			get {
				return _buoyShape;
			}
			set {
				SetValue(ref _buoyShape, value);
			}
		}

		[Browsable(false)]
		public buoyShape[] buoyShapeList => [(buoyShape)1,(buoyShape)2,(buoyShape)3,(buoyShape)4,(buoyShape)5,(buoyShape)6,(buoyShape)7,(buoyShape)8];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList), typeof(marksNavigationalSystemOf))]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Browsable(false)]
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)14,(marksNavigationalSystemOf)15];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private Boolean? _radarConspicuous  = default;

		[Category("GenericBuoy")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private String? _typeOfBuoy  = default;

		[Category("GenericBuoy")]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}
		private decimal? _verticalLength  = default;

		[Category("GenericBuoy")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private decimal? _verticalAccuracy  = default;

		[Category("GenericBuoy")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}



		public override FeatureViewModel<EmergencyWreckMarkingBuoy> Load(EmergencyWreckMarkingBuoy instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => EmergencyWreckMarkingBuoy._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. EmergencyWreckMarkingBuoy._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => EmergencyWreckMarkingBuoy._featureBindingDefinitions;

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
	[CategoryOrder("Lighthouse",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LighthouseViewModel : FeatureViewModel<Lighthouse> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		[Category("Landmark")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfLandmarkList), typeof(categoryOfLandmark))]
		public ObservableCollection<categoryOfLandmark> categoryOfLandmark  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfLandmark[] categoryOfLandmarkList => [(categoryOfLandmark)1,(categoryOfLandmark)2,(categoryOfLandmark)3,(categoryOfLandmark)4,(categoryOfLandmark)5,(categoryOfLandmark)6,(categoryOfLandmark)7,(categoryOfLandmark)8,(categoryOfLandmark)9,(categoryOfLandmark)10,(categoryOfLandmark)11,(categoryOfLandmark)12,(categoryOfLandmark)13,(categoryOfLandmark)14,(categoryOfLandmark)15,(categoryOfLandmark)16,(categoryOfLandmark)17,(categoryOfLandmark)18,(categoryOfLandmark)19,(categoryOfLandmark)20,(categoryOfLandmark)21,(categoryOfLandmark)22,(categoryOfLandmark)23,(categoryOfLandmark)24,(categoryOfLandmark)25,(categoryOfLandmark)26,(categoryOfLandmark)27];
		[Category("Landmark")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("Landmark")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		[Category("Landmark")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(functionList), typeof(function))]
		public ObservableCollection<function> function  { get; set; } = new ();

		[Browsable(false)]
		public function[] functionList => [(function)2,(function)3,(function)4,(function)5,(function)6,(function)7,(function)8,(function)9,(function)10,(function)11,(function)12,(function)13,(function)14,(function)15,(function)16,(function)17,(function)18,(function)19,(function)20,(function)21,(function)22,(function)23,(function)24,(function)25,(function)26,(function)27,(function)28,(function)29,(function)30,(function)31,(function)32,(function)33,(function)34,(function)35,(function)36,(function)37,(function)38,(function)39,(function)40,(function)41,(function)42,(function)43,(function)44,(function)45,(function)46,(function)47,(function)48];
		[Category("Landmark")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private Boolean? _radarConspicuous  = default;

		[Category("Landmark")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("Landmark")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private verticalDatum? _verticalDatum  = default;

		[Category("Landmark")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45];
		private visualProminence _visualProminence ;

		[Category("Landmark")]
		[Editor(typeof(Editors.UnknownEditor<visualProminence?>), typeof(Editors.UnknownEditor<visualProminence?>))]
		[DomainModel.EnumerationAttribute(nameof(visualProminenceList), typeof(visualProminence))]
		public visualProminence visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		[Browsable(false)]
		public visualProminence[] visualProminenceList => [(visualProminence)1,(visualProminence)2,(visualProminence)3];
		private decimal? _elevation  = default;

		[Category("Landmark")]
		public decimal? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}
		private decimal? _height  = default;

		[Category("Landmark")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private Boolean? _mannedStructure  = default;

		[Category("Landmark")]
		public Boolean? mannedStructure {
			get {
				return _mannedStructure;
			}
			set {
				SetValue(ref _mannedStructure, value);
			}
		}
		private decimal? _verticalLength  = default;

		[Category("Landmark")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private decimal? _verticalAccuracy  = default;

		[Category("Landmark")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}



		public override FeatureViewModel<Lighthouse> Load(Lighthouse instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => Lighthouse._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Lighthouse._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Lighthouse._featureBindingDefinitions;

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
	[CategoryOrder("LightFloat",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LightFloatViewModel : FeatureViewModel<LightFloat> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		[Category("LightFloat")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("LightFloat")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		private decimal? _horizontalLength  = default;

		[Category("LightFloat")]
		public decimal? horizontalLength {
			get {
				return _horizontalLength;
			}
			set {
				SetValue(ref _horizontalLength, value);
			}
		}
		private decimal? _horizontalWidth  = default;

		[Category("LightFloat")]
		public decimal? horizontalWidth {
			get {
				return _horizontalWidth;
			}
			set {
				SetValue(ref _horizontalWidth, value);
			}
		}
		private Boolean? _mannedStructure  = default;

		[Category("LightFloat")]
		public Boolean? mannedStructure {
			get {
				return _mannedStructure;
			}
			set {
				SetValue(ref _mannedStructure, value);
			}
		}
		[Category("LightFloat")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private Boolean? _radarConspicuous  = default;

		[Category("LightFloat")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("LightFloat")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private decimal? _verticalLength  = default;

		[Category("LightFloat")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private visualProminence? _visualProminence  = default;

		[Category("LightFloat")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(visualProminenceList), typeof(visualProminence))]
		public visualProminence? visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		[Browsable(false)]
		public visualProminence[] visualProminenceList => [(visualProminence)1,(visualProminence)2,(visualProminence)3];
		private decimal? _verticalAccuracy  = default;

		[Category("LightFloat")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}
		private decimal? _horizontalAccuracy  = default;

		[Category("LightFloat")]
		public decimal? horizontalAccuracy {
			get {
				return _horizontalAccuracy;
			}
			set {
				SetValue(ref _horizontalAccuracy, value);
			}
		}


		public override FeatureViewModel<LightFloat> Load(LightFloat instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => LightFloat._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LightFloat._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LightFloat._featureBindingDefinitions;

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
	[CategoryOrder("LightVessel",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LightVesselViewModel : FeatureViewModel<LightVessel> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		[Category("LightVessel")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("LightVessel")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		private decimal? _horizontalLength  = default;

		[Category("LightVessel")]
		public decimal? horizontalLength {
			get {
				return _horizontalLength;
			}
			set {
				SetValue(ref _horizontalLength, value);
			}
		}
		private decimal? _horizontalWidth  = default;

		[Category("LightVessel")]
		public decimal? horizontalWidth {
			get {
				return _horizontalWidth;
			}
			set {
				SetValue(ref _horizontalWidth, value);
			}
		}
		private Boolean? _mannedStructure  = default;

		[Category("LightVessel")]
		public Boolean? mannedStructure {
			get {
				return _mannedStructure;
			}
			set {
				SetValue(ref _mannedStructure, value);
			}
		}
		[Category("LightVessel")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private Boolean? _radarConspicuous  = default;

		[Category("LightVessel")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("LightVessel")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private decimal? _verticalLength  = default;

		[Category("LightVessel")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private visualProminence? _visualProminence  = default;

		[Category("LightVessel")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(visualProminenceList), typeof(visualProminence))]
		public visualProminence? visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		[Browsable(false)]
		public visualProminence[] visualProminenceList => [(visualProminence)1,(visualProminence)2,(visualProminence)3];
		private decimal? _verticalAccuracy  = default;

		[Category("LightVessel")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}
		private decimal? _horizontalAccuracy  = default;

		[Category("LightVessel")]
		public decimal? horizontalAccuracy {
			get {
				return _horizontalAccuracy;
			}
			set {
				SetValue(ref _horizontalAccuracy, value);
			}
		}


		public override FeatureViewModel<LightVessel> Load(LightVessel instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => LightVessel._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LightVessel._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LightVessel._featureBindingDefinitions;

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
	[CategoryOrder("OffshorePlatform",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class OffshorePlatformViewModel : FeatureViewModel<OffshorePlatform> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		[Category("OffshorePlatform")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfOffshorePlatformList), typeof(categoryOfOffshorePlatform))]
		public ObservableCollection<categoryOfOffshorePlatform> categoryOfOffshorePlatform  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfOffshorePlatform[] categoryOfOffshorePlatformList => [(categoryOfOffshorePlatform)1,(categoryOfOffshorePlatform)2,(categoryOfOffshorePlatform)3,(categoryOfOffshorePlatform)4,(categoryOfOffshorePlatform)5,(categoryOfOffshorePlatform)6,(categoryOfOffshorePlatform)7,(categoryOfOffshorePlatform)8,(categoryOfOffshorePlatform)9,(categoryOfOffshorePlatform)10,(categoryOfOffshorePlatform)11];
		[Category("OffshorePlatform")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("OffshorePlatform")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		private decimal? _height  = default;

		[Category("OffshorePlatform")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private Boolean? _mannedStructure  = default;

		[Category("OffshorePlatform")]
		public Boolean? mannedStructure {
			get {
				return _mannedStructure;
			}
			set {
				SetValue(ref _mannedStructure, value);
			}
		}
		[Category("OffshorePlatform")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		[Category("OffshorePlatform")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(productList), typeof(product))]
		public ObservableCollection<product> product  { get; set; } = new ();

		[Browsable(false)]
		public product[] productList => [(product)1,(product)2,(product)3,(product)4,(product)5,(product)6,(product)7,(product)8,(product)9,(product)10,(product)11,(product)12,(product)13,(product)14,(product)15,(product)16,(product)17,(product)18,(product)19,(product)20,(product)21,(product)22,(product)23,(product)24,(product)25];
		private Boolean? _radarConspicuous  = default;

		[Category("OffshorePlatform")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("OffshorePlatform")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private verticalDatum? _verticalDatum  = default;

		[Category("OffshorePlatform")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45];
		private decimal? _verticalLength  = default;

		[Category("OffshorePlatform")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private visualProminence? _visualProminence  = default;

		[Category("OffshorePlatform")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(visualProminenceList), typeof(visualProminence))]
		public visualProminence? visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		[Browsable(false)]
		public visualProminence[] visualProminenceList => [(visualProminence)1,(visualProminence)2,(visualProminence)3];
		private decimal? _verticalAccuracy  = default;

		[Category("OffshorePlatform")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}


		public override FeatureViewModel<OffshorePlatform> Load(OffshorePlatform instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => OffshorePlatform._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. OffshorePlatform._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => OffshorePlatform._featureBindingDefinitions;

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
	[CategoryOrder("SiloTank",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SiloTankViewModel : FeatureViewModel<SiloTank> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private buildingShape? _buildingShape  = default;

		[Category("SiloTank")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(buildingShapeList), typeof(buildingShape))]
		public buildingShape? buildingShape {
			get {
				return _buildingShape;
			}
			set {
				SetValue(ref _buildingShape, value);
			}
		}

		[Browsable(false)]
		public buildingShape[] buildingShapeList => [(buildingShape)5,(buildingShape)6,(buildingShape)7,(buildingShape)8,(buildingShape)9];
		private categoryOfSiloTank? _categoryOfSiloTank  = default;

		[Category("SiloTank")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfSiloTankList), typeof(categoryOfSiloTank))]
		public categoryOfSiloTank? categoryOfSiloTank {
			get {
				return _categoryOfSiloTank;
			}
			set {
				SetValue(ref _categoryOfSiloTank, value);
			}
		}

		[Browsable(false)]
		public categoryOfSiloTank[] categoryOfSiloTankList => [(categoryOfSiloTank)1,(categoryOfSiloTank)2,(categoryOfSiloTank)3,(categoryOfSiloTank)4];
		[Category("SiloTank")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("SiloTank")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		private decimal? _elevation  = default;

		[Category("SiloTank")]
		public decimal? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}
		private decimal? _height  = default;

		[Category("SiloTank")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		[Category("SiloTank")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private Boolean? _radarConspicuous  = default;

		[Category("SiloTank")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("SiloTank")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private verticalDatum? _verticalDatum  = default;

		[Category("SiloTank")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45];
		private decimal? _verticalLength  = default;

		[Category("SiloTank")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private visualProminence? _visualProminence  = default;

		[Category("SiloTank")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(visualProminenceList), typeof(visualProminence))]
		public visualProminence? visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		[Browsable(false)]
		public visualProminence[] visualProminenceList => [(visualProminence)1,(visualProminence)2,(visualProminence)3];
		private decimal? _verticalAccuracy  = default;

		[Category("SiloTank")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}


		public override FeatureViewModel<SiloTank> Load(SiloTank instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => SiloTank._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SiloTank._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SiloTank._featureBindingDefinitions;

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
	[CategoryOrder("Pile",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PileViewModel : FeatureViewModel<Pile> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private categoryOfPile? _categoryOfPile  = default;

		[Category("Pile")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfPileList), typeof(categoryOfPile))]
		public categoryOfPile? categoryOfPile {
			get {
				return _categoryOfPile;
			}
			set {
				SetValue(ref _categoryOfPile, value);
			}
		}

		[Browsable(false)]
		public categoryOfPile[] categoryOfPileList => [(categoryOfPile)1,(categoryOfPile)3,(categoryOfPile)4,(categoryOfPile)5,(categoryOfPile)6,(categoryOfPile)7];
		[Category("Pile")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("Pile")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		private decimal? _height  = default;

		[Category("Pile")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private verticalDatum? _verticalDatum  = default;

		[Category("Pile")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45];
		private decimal? _verticalLength  = default;

		[Category("Pile")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private visualProminence? _visualProminence  = default;

		[Category("Pile")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(visualProminenceList), typeof(visualProminence))]
		public visualProminence? visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		[Browsable(false)]
		public visualProminence[] visualProminenceList => [(visualProminence)1,(visualProminence)2,(visualProminence)3];
		private decimal? _verticalAccuracy  = default;

		[Category("Pile")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}


		public override FeatureViewModel<Pile> Load(Pile instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => Pile._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Pile._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Pile._featureBindingDefinitions;

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
	[CategoryOrder("Building",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BuildingViewModel : FeatureViewModel<Building> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}



		public override FeatureViewModel<Building> Load(Building instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => Building._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Building._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Building._featureBindingDefinitions;

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
	[CategoryOrder("Bridge",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BridgeViewModel : FeatureViewModel<Bridge> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}



		public override FeatureViewModel<Bridge> Load(Bridge instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => Bridge._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Bridge._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Bridge._featureBindingDefinitions;

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
	[CategoryOrder("SinkerAnchor",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SinkerAnchorViewModel : FeatureViewModel<SinkerAnchor> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private natureOfConstruction? _natureOfConstruction  = default;

		[Category("SinkerAnchor")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public natureOfConstruction? natureOfConstruction {
			get {
				return _natureOfConstruction;
			}
			set {
				SetValue(ref _natureOfConstruction, value);
			}
		}

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private sinkerDimensionsViewModel? _sinkerDimensions  = default;

		[Category("SinkerAnchor")]
		[ExpandableObject]
		public sinkerDimensionsViewModel? sinkerDimensions {
			get {
				return _sinkerDimensions;
			}
			set {
				SetValue(ref _sinkerDimensions, value);
			}
		}
		private decimal _weight ;

		[Category("SinkerAnchor")]
		[Editor(typeof(Editors.UnknownEditor<decimal?>), typeof(Editors.UnknownEditor<decimal?>))]
		public decimal weight {
			get {
				return _weight;
			}
			set {
				SetValue(ref _weight, value);
			}
		}
		private String? _sinkerType  = default;

		[Category("SinkerAnchor")]
		public String? sinkerType {
			get {
				return _sinkerType;
			}
			set {
				SetValue(ref _sinkerType, value);
			}
		}


		public override FeatureViewModel<SinkerAnchor> Load(SinkerAnchor instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => SinkerAnchor._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SinkerAnchor._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SinkerAnchor._featureBindingDefinitions;

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
		}
	}

	/// <summary>
	/// A shackle at the lower end of a mooring chain, for attachment to an anchor or sinker. (IALA Dictionary, 8-5-150)
	/// </summary>
	[CategoryOrder("MooringShackle",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class MooringShackleViewModel : FeatureViewModel<MooringShackle> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private natureOfConstruction? _natureOfConstruction  = default;

		[Category("MooringShackle")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public natureOfConstruction? natureOfConstruction {
			get {
				return _natureOfConstruction;
			}
			set {
				SetValue(ref _natureOfConstruction, value);
			}
		}

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private ShackleType? _ShackleType  = default;

		[Category("MooringShackle")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(ShackleTypeList), typeof(ShackleType))]
		public ShackleType? ShackleType {
			get {
				return _ShackleType;
			}
			set {
				SetValue(ref _ShackleType, value);
			}
		}

		[Browsable(false)]
		public ShackleType[] ShackleTypeList => [(ShackleType)1,(ShackleType)2,(ShackleType)3,(ShackleType)4,(ShackleType)5,(ShackleType)6];
		private decimal? _weight  = default;

		[Category("MooringShackle")]
		public decimal? weight {
			get {
				return _weight;
			}
			set {
				SetValue(ref _weight, value);
			}
		}


		public override FeatureViewModel<MooringShackle> Load(MooringShackle instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => MooringShackle._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. MooringShackle._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => MooringShackle._featureBindingDefinitions;

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
		}
	}

	/// <summary>
	/// An assembly of wires or fibres, or a wire rope or chain, which has been laid underwater or buried beneath the sea floor.
	/// </summary>
	[CategoryOrder("CableSubmarine",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CableSubmarineViewModel : FeatureViewModel<CableSubmarine> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private CableDimensionsViewModel? _CableDimensions  = default;

		[Category("CableSubmarine")]
		[ExpandableObject]
		public CableDimensionsViewModel? CableDimensions {
			get {
				return _CableDimensions;
			}
			set {
				SetValue(ref _CableDimensions, value);
			}
		}
		private categoryOfCable _categoryOfCable ;

		[Category("CableSubmarine")]
		[Editor(typeof(Editors.UnknownEditor<categoryOfCable?>), typeof(Editors.UnknownEditor<categoryOfCable?>))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfCableList), typeof(categoryOfCable))]
		public categoryOfCable categoryOfCable {
			get {
				return _categoryOfCable;
			}
			set {
				SetValue(ref _categoryOfCable, value);
			}
		}

		[Browsable(false)]
		public categoryOfCable[] categoryOfCableList => [(categoryOfCable)1,(categoryOfCable)3,(categoryOfCable)4,(categoryOfCable)5,(categoryOfCable)6,(categoryOfCable)7,(categoryOfCable)8];
		[Category("CableSubmarine")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];


		public override FeatureViewModel<CableSubmarine> Load(CableSubmarine instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => CableSubmarine._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. CableSubmarine._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => CableSubmarine._featureBindingDefinitions;

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
		}
	}

	/// <summary>
	/// A chain link that provides for rotary motion between the lengths of chain that it connects. (IALA Dictionary, 8-5-165)
	/// </summary>
	[CategoryOrder("Swivel",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SwivelViewModel : FeatureViewModel<Swivel> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private natureOfConstruction? _natureOfConstruction  = default;

		[Category("Swivel")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public natureOfConstruction? natureOfConstruction {
			get {
				return _natureOfConstruction;
			}
			set {
				SetValue(ref _natureOfConstruction, value);
			}
		}

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private decimal? _weight  = default;

		[Category("Swivel")]
		public decimal? weight {
			get {
				return _weight;
			}
			set {
				SetValue(ref _weight, value);
			}
		}
		private String? _swivelType  = default;

		[Category("Swivel")]
		public String? swivelType {
			get {
				return _swivelType;
			}
			set {
				SetValue(ref _swivelType, value);
			}
		}


		public override FeatureViewModel<Swivel> Load(Swivel instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => Swivel._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Swivel._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Swivel._featureBindingDefinitions;

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
		}
	}

	/// <summary>
	/// Two lengths of chain connected by a central ring and used for lifting wide loads. (IALA Dictionary,8-3-195)
	/// </summary>
	[CategoryOrder("Bridle",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BridleViewModel : FeatureViewModel<Bridle> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String? _bridleLinkType  = default;

		[Category("Bridle")]
		public String? bridleLinkType {
			get {
				return _bridleLinkType;
			}
			set {
				SetValue(ref _bridleLinkType, value);
			}
		}
		private String? _legsDetails  = default;

		[Category("Bridle")]
		public String? legsDetails {
			get {
				return _legsDetails;
			}
			set {
				SetValue(ref _legsDetails, value);
			}
		}


		public override FeatureViewModel<Bridle> Load(Bridle instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => Bridle._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Bridle._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Bridle._featureBindingDefinitions;

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
		}
	}

	/// <summary>
	/// -
	/// </summary>
	[CategoryOrder("CounterWeight",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CounterWeightViewModel : FeatureViewModel<CounterWeight> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private natureOfConstruction? _natureOfConstruction  = default;

		[Category("CounterWeight")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public natureOfConstruction? natureOfConstruction {
			get {
				return _natureOfConstruction;
			}
			set {
				SetValue(ref _natureOfConstruction, value);
			}
		}

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private decimal _weight ;

		[Category("CounterWeight")]
		[Editor(typeof(Editors.UnknownEditor<decimal?>), typeof(Editors.UnknownEditor<decimal?>))]
		public decimal weight {
			get {
				return _weight;
			}
			set {
				SetValue(ref _weight, value);
			}
		}
		private String? _counterWeightType  = default;

		[Category("CounterWeight")]
		public String? counterWeightType {
			get {
				return _counterWeightType;
			}
			set {
				SetValue(ref _counterWeightType, value);
			}
		}


		public override FeatureViewModel<CounterWeight> Load(CounterWeight instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => CounterWeight._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. CounterWeight._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => CounterWeight._featureBindingDefinitions;

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
		}
	}

	/// <summary>
	/// A characteristic shape secured at the top of a buoy or beacon to aid in its identification. (IHO Dictionary, S-32, 5th Edition, 5548)
	/// </summary>
	[CategoryOrder("Topmark",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TopmarkViewModel : FeatureViewModel<Topmark> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		[Category("Topmark")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("Topmark")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		[Category("Topmark")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private topmarkDaymarkShape _topmarkDaymarkShape ;

		[Category("Topmark")]
		[Editor(typeof(Editors.UnknownEditor<topmarkDaymarkShape?>), typeof(Editors.UnknownEditor<topmarkDaymarkShape?>))]
		[DomainModel.EnumerationAttribute(nameof(topmarkDaymarkShapeList), typeof(topmarkDaymarkShape))]
		public topmarkDaymarkShape topmarkDaymarkShape {
			get {
				return _topmarkDaymarkShape;
			}
			set {
				SetValue(ref _topmarkDaymarkShape, value);
			}
		}

		[Browsable(false)]
		public topmarkDaymarkShape[] topmarkDaymarkShapeList => [(topmarkDaymarkShape)1,(topmarkDaymarkShape)2,(topmarkDaymarkShape)3,(topmarkDaymarkShape)4,(topmarkDaymarkShape)5,(topmarkDaymarkShape)6,(topmarkDaymarkShape)7,(topmarkDaymarkShape)8,(topmarkDaymarkShape)9,(topmarkDaymarkShape)10,(topmarkDaymarkShape)11,(topmarkDaymarkShape)12,(topmarkDaymarkShape)13,(topmarkDaymarkShape)14,(topmarkDaymarkShape)15,(topmarkDaymarkShape)16,(topmarkDaymarkShape)17,(topmarkDaymarkShape)18,(topmarkDaymarkShape)19,(topmarkDaymarkShape)20,(topmarkDaymarkShape)21,(topmarkDaymarkShape)22,(topmarkDaymarkShape)23,(topmarkDaymarkShape)24,(topmarkDaymarkShape)25,(topmarkDaymarkShape)26,(topmarkDaymarkShape)27,(topmarkDaymarkShape)28,(topmarkDaymarkShape)29,(topmarkDaymarkShape)30,(topmarkDaymarkShape)31,(topmarkDaymarkShape)32,(topmarkDaymarkShape)33,(topmarkDaymarkShape)34];
		private decimal? _verticalLength  = default;

		[Category("Topmark")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}


		public override FeatureViewModel<Topmark> Load(Topmark instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => Topmark._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Topmark._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Topmark._featureBindingDefinitions;

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
		}
	}

	/// <summary>
	/// A safe water beacon is a prominent specially constructed object forming a conspicuous mark as a fixed aid to navigation or for use in hydrographic survey (IHO Dictionary, S-32, 5th Edition, 420). A safe water beacon may be used to indicate that there is navigable water around the mark. (UKHO NP735, 5th Edition)
	/// </summary>
	[CategoryOrder("SafeWaterBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SafeWaterBeaconViewModel : FeatureViewModel<SafeWaterBeacon> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private beaconShape _beaconShape ;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.UnknownEditor<beaconShape?>), typeof(Editors.UnknownEditor<beaconShape?>))]
		[DomainModel.EnumerationAttribute(nameof(beaconShapeList), typeof(beaconShape))]
		public beaconShape beaconShape {
			get {
				return _beaconShape;
			}
			set {
				SetValue(ref _beaconShape, value);
			}
		}

		[Browsable(false)]
		public beaconShape[] beaconShapeList => [(beaconShape)1,(beaconShape)2,(beaconShape)3,(beaconShape)4,(beaconShape)5,(beaconShape)6,(beaconShape)7];
		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		private decimal? _elevation  = default;

		[Category("GenericBeacon")]
		public decimal? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}
		private decimal? _height  = default;

		[Category("GenericBeacon")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList), typeof(marksNavigationalSystemOf))]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Browsable(false)]
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)14,(marksNavigationalSystemOf)15];
		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private Boolean? _radarConspicuous  = default;

		[Category("GenericBeacon")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private decimal? _verticalLength  = default;

		[Category("GenericBeacon")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private visualProminence? _visualProminence  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(visualProminenceList), typeof(visualProminence))]
		public visualProminence? visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		[Browsable(false)]
		public visualProminence[] visualProminenceList => [(visualProminence)1,(visualProminence)2,(visualProminence)3];
		private decimal? _verticalAccuracy  = default;

		[Category("GenericBeacon")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}



		public override FeatureViewModel<SafeWaterBeacon> Load(SafeWaterBeacon instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => SafeWaterBeacon._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SafeWaterBeacon._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SafeWaterBeacon._featureBindingDefinitions;

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
	/// A beacon is a prominent specially constructed object forming a conspicuous mark as a fixed aid to navigation or for use in hydrographic survey (IHO Dictionary, S-32, 5th Edition, 420). A special purpose beacon is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notices to Mariners. (UKHO NP 735, 5th Edition) Beacon in general: A beacon whose appearance or purpose is not adequately known.
	/// </summary>
	[CategoryOrder("SpecialPurposeGeneralBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SpecialPurposeGeneralBeaconViewModel : FeatureViewModel<SpecialPurposeGeneralBeacon> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private beaconShape _beaconShape ;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.UnknownEditor<beaconShape?>), typeof(Editors.UnknownEditor<beaconShape?>))]
		[DomainModel.EnumerationAttribute(nameof(beaconShapeList), typeof(beaconShape))]
		public beaconShape beaconShape {
			get {
				return _beaconShape;
			}
			set {
				SetValue(ref _beaconShape, value);
			}
		}

		[Browsable(false)]
		public beaconShape[] beaconShapeList => [(beaconShape)1,(beaconShape)2,(beaconShape)3,(beaconShape)4,(beaconShape)5,(beaconShape)6,(beaconShape)7];
		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		private decimal? _elevation  = default;

		[Category("GenericBeacon")]
		public decimal? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}
		private decimal? _height  = default;

		[Category("GenericBeacon")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList), typeof(marksNavigationalSystemOf))]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Browsable(false)]
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)14,(marksNavigationalSystemOf)15];
		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private Boolean? _radarConspicuous  = default;

		[Category("GenericBeacon")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private decimal? _verticalLength  = default;

		[Category("GenericBeacon")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private visualProminence? _visualProminence  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(visualProminenceList), typeof(visualProminence))]
		public visualProminence? visualProminence {
			get {
				return _visualProminence;
			}
			set {
				SetValue(ref _visualProminence, value);
			}
		}

		[Browsable(false)]
		public visualProminence[] visualProminenceList => [(visualProminence)1,(visualProminence)2,(visualProminence)3];
		private decimal? _verticalAccuracy  = default;

		[Category("GenericBeacon")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}

		[Category("SpecialPurposeGeneralBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfSpecialPurposeMarkList), typeof(categoryOfSpecialPurposeMark))]
		public ObservableCollection<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfSpecialPurposeMark[] categoryOfSpecialPurposeMarkList => [(categoryOfSpecialPurposeMark)1,(categoryOfSpecialPurposeMark)2,(categoryOfSpecialPurposeMark)3,(categoryOfSpecialPurposeMark)4,(categoryOfSpecialPurposeMark)5,(categoryOfSpecialPurposeMark)6,(categoryOfSpecialPurposeMark)7,(categoryOfSpecialPurposeMark)8,(categoryOfSpecialPurposeMark)9,(categoryOfSpecialPurposeMark)10,(categoryOfSpecialPurposeMark)11,(categoryOfSpecialPurposeMark)12,(categoryOfSpecialPurposeMark)13,(categoryOfSpecialPurposeMark)14,(categoryOfSpecialPurposeMark)15,(categoryOfSpecialPurposeMark)16,(categoryOfSpecialPurposeMark)17,(categoryOfSpecialPurposeMark)18,(categoryOfSpecialPurposeMark)19,(categoryOfSpecialPurposeMark)20,(categoryOfSpecialPurposeMark)21,(categoryOfSpecialPurposeMark)22,(categoryOfSpecialPurposeMark)23,(categoryOfSpecialPurposeMark)24,(categoryOfSpecialPurposeMark)25,(categoryOfSpecialPurposeMark)26,(categoryOfSpecialPurposeMark)27,(categoryOfSpecialPurposeMark)28,(categoryOfSpecialPurposeMark)29,(categoryOfSpecialPurposeMark)30,(categoryOfSpecialPurposeMark)31,(categoryOfSpecialPurposeMark)32,(categoryOfSpecialPurposeMark)33,(categoryOfSpecialPurposeMark)34,(categoryOfSpecialPurposeMark)35,(categoryOfSpecialPurposeMark)36,(categoryOfSpecialPurposeMark)37,(categoryOfSpecialPurposeMark)39,(categoryOfSpecialPurposeMark)40,(categoryOfSpecialPurposeMark)41,(categoryOfSpecialPurposeMark)42,(categoryOfSpecialPurposeMark)43,(categoryOfSpecialPurposeMark)44,(categoryOfSpecialPurposeMark)45,(categoryOfSpecialPurposeMark)46,(categoryOfSpecialPurposeMark)47,(categoryOfSpecialPurposeMark)48,(categoryOfSpecialPurposeMark)49,(categoryOfSpecialPurposeMark)50,(categoryOfSpecialPurposeMark)51,(categoryOfSpecialPurposeMark)52,(categoryOfSpecialPurposeMark)53,(categoryOfSpecialPurposeMark)54,(categoryOfSpecialPurposeMark)55,(categoryOfSpecialPurposeMark)56,(categoryOfSpecialPurposeMark)57,(categoryOfSpecialPurposeMark)58,(categoryOfSpecialPurposeMark)59,(categoryOfSpecialPurposeMark)60,(categoryOfSpecialPurposeMark)61,(categoryOfSpecialPurposeMark)62,(categoryOfSpecialPurposeMark)63,(categoryOfSpecialPurposeMark)64];


		public override FeatureViewModel<SpecialPurposeGeneralBeacon> Load(SpecialPurposeGeneralBeacon instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => SpecialPurposeGeneralBeacon._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SpecialPurposeGeneralBeacon._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SpecialPurposeGeneralBeacon._featureBindingDefinitions;

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
	/// A buoy is a floating object moored to the bottom in a particular place, as an aid to navigation or for other specific purposes. (IHO Dictionary, S-32, 5th Edition, 565). A safe water buoy is used to indicate that there is navigable water around the mark. (UKHO NP735, 5th Edition)
	/// </summary>
	[CategoryOrder("SafeWaterBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SafeWaterBuoyViewModel : FeatureViewModel<SafeWaterBuoy> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private buoyShape _buoyShape ;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.UnknownEditor<buoyShape?>), typeof(Editors.UnknownEditor<buoyShape?>))]
		[DomainModel.EnumerationAttribute(nameof(buoyShapeList), typeof(buoyShape))]
		public buoyShape buoyShape {
			get {
				return _buoyShape;
			}
			set {
				SetValue(ref _buoyShape, value);
			}
		}

		[Browsable(false)]
		public buoyShape[] buoyShapeList => [(buoyShape)1,(buoyShape)2,(buoyShape)3,(buoyShape)4,(buoyShape)5,(buoyShape)6,(buoyShape)7,(buoyShape)8];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList), typeof(marksNavigationalSystemOf))]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Browsable(false)]
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)14,(marksNavigationalSystemOf)15];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private Boolean? _radarConspicuous  = default;

		[Category("GenericBuoy")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private String? _typeOfBuoy  = default;

		[Category("GenericBuoy")]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}
		private decimal? _verticalLength  = default;

		[Category("GenericBuoy")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private decimal? _verticalAccuracy  = default;

		[Category("GenericBuoy")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}



		public override FeatureViewModel<SafeWaterBuoy> Load(SafeWaterBuoy instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => SafeWaterBuoy._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SafeWaterBuoy._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SafeWaterBuoy._featureBindingDefinitions;

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
	/// A buoy is a floating object moored to the bottom in a particular place, as an aid to navigation or for other specific purposes. (IHO Dictionary, S-32, 5th Edition, 565). A special purpose buoy is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notices to Mariners. (UKHO NP 735, 5th Edition) Buoy in general: A buoy whose appearance or purpose is not adequately known.
	/// </summary>
	[CategoryOrder("SpecialPurposeGeneralBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SpecialPurposeGeneralBuoyViewModel : FeatureViewModel<SpecialPurposeGeneralBuoy> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AidsToNavigation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _sourceDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? sourceDate {
			get {
				return _sourceDate;
			}
			set {
				SetValue(ref _sourceDate, value);
			}
		}
		private String? _source  = default;

		[Category("AidsToNavigation")]
		public String? source {
			get {
				return _source;
			}
			set {
				SetValue(ref _source, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AidsToNavigation")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _inspectionFrequency  = default;

		[Category("AidsToNavigation")]
		public String? inspectionFrequency {
			get {
				return _inspectionFrequency;
			}
			set {
				SetValue(ref _inspectionFrequency, value);
			}
		}
		private String? _inspectionRequirements  = default;

		[Category("AidsToNavigation")]
		public String? inspectionRequirements {
			get {
				return _inspectionRequirements;
			}
			set {
				SetValue(ref _inspectionRequirements, value);
			}
		}
		private String? _aToNMaintenanceRecord  = default;

		[Category("AidsToNavigation")]
		public String? aToNMaintenanceRecord {
			get {
				return _aToNMaintenanceRecord;
			}
			set {
				SetValue(ref _aToNMaintenanceRecord, value);
			}
		}
		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		public DateOnly? installationDate {
			get {
				return _installationDate;
			}
			set {
				SetValue(ref _installationDate, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private periodicDateRangeViewModel? _periodicDateRange  = default;

		[Category("AidsToNavigation")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AidsToNavigation")]
		public ObservableCollection<String> SeasonalActionRequired  { get; set; } = new ();

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.UnknownStringEditor), typeof(Editors.UnknownStringEditor))]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}
		private aidAvailabilityCategory? _aidAvailabilityCategory  = default;

		[Category("StructureObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(aidAvailabilityCategoryList), typeof(aidAvailabilityCategory))]
		public aidAvailabilityCategory? aidAvailabilityCategory {
			get {
				return _aidAvailabilityCategory;
			}
			set {
				SetValue(ref _aidAvailabilityCategory, value);
			}
		}

		[Browsable(false)]
		public aidAvailabilityCategory[] aidAvailabilityCategoryList => [(aidAvailabilityCategory)1,(aidAvailabilityCategory)2,(aidAvailabilityCategory)3];
		private condition? _condition  = default;

		[Category("StructureObject")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];
		private contactAddressViewModel? _contactAddress  = default;

		[Category("StructureObject")]
		[ExpandableObject]
		public contactAddressViewModel? contactAddress {
			get {
				return _contactAddress;
			}
			set {
				SetValue(ref _contactAddress, value);
			}
		}

		private buoyShape _buoyShape ;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.UnknownEditor<buoyShape?>), typeof(Editors.UnknownEditor<buoyShape?>))]
		[DomainModel.EnumerationAttribute(nameof(buoyShapeList), typeof(buoyShape))]
		public buoyShape buoyShape {
			get {
				return _buoyShape;
			}
			set {
				SetValue(ref _buoyShape, value);
			}
		}

		[Browsable(false)]
		public buoyShape[] buoyShapeList => [(buoyShape)1,(buoyShape)2,(buoyShape)3,(buoyShape)4,(buoyShape)5,(buoyShape)6,(buoyShape)7,(buoyShape)8];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList), typeof(marksNavigationalSystemOf))]
		public marksNavigationalSystemOf? marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Browsable(false)]
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)14,(marksNavigationalSystemOf)15];
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];
		private Boolean? _radarConspicuous  = default;

		[Category("GenericBuoy")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("GenericBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];
		private String? _typeOfBuoy  = default;

		[Category("GenericBuoy")]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}
		private decimal? _verticalLength  = default;

		[Category("GenericBuoy")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private decimal? _verticalAccuracy  = default;

		[Category("GenericBuoy")]
		public decimal? verticalAccuracy {
			get {
				return _verticalAccuracy;
			}
			set {
				SetValue(ref _verticalAccuracy, value);
			}
		}

		[Category("SpecialPurposeGeneralBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfSpecialPurposeMarkList), typeof(categoryOfSpecialPurposeMark))]
		public ObservableCollection<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfSpecialPurposeMark[] categoryOfSpecialPurposeMarkList => [(categoryOfSpecialPurposeMark)1,(categoryOfSpecialPurposeMark)2,(categoryOfSpecialPurposeMark)3,(categoryOfSpecialPurposeMark)4,(categoryOfSpecialPurposeMark)5,(categoryOfSpecialPurposeMark)6,(categoryOfSpecialPurposeMark)7,(categoryOfSpecialPurposeMark)8,(categoryOfSpecialPurposeMark)9,(categoryOfSpecialPurposeMark)10,(categoryOfSpecialPurposeMark)11,(categoryOfSpecialPurposeMark)12,(categoryOfSpecialPurposeMark)13,(categoryOfSpecialPurposeMark)14,(categoryOfSpecialPurposeMark)15,(categoryOfSpecialPurposeMark)16,(categoryOfSpecialPurposeMark)17,(categoryOfSpecialPurposeMark)18,(categoryOfSpecialPurposeMark)19,(categoryOfSpecialPurposeMark)20,(categoryOfSpecialPurposeMark)21,(categoryOfSpecialPurposeMark)22,(categoryOfSpecialPurposeMark)23,(categoryOfSpecialPurposeMark)24,(categoryOfSpecialPurposeMark)25,(categoryOfSpecialPurposeMark)26,(categoryOfSpecialPurposeMark)27,(categoryOfSpecialPurposeMark)28,(categoryOfSpecialPurposeMark)29,(categoryOfSpecialPurposeMark)30,(categoryOfSpecialPurposeMark)31,(categoryOfSpecialPurposeMark)32,(categoryOfSpecialPurposeMark)33,(categoryOfSpecialPurposeMark)34,(categoryOfSpecialPurposeMark)35,(categoryOfSpecialPurposeMark)36,(categoryOfSpecialPurposeMark)37,(categoryOfSpecialPurposeMark)39,(categoryOfSpecialPurposeMark)40,(categoryOfSpecialPurposeMark)41,(categoryOfSpecialPurposeMark)42,(categoryOfSpecialPurposeMark)43,(categoryOfSpecialPurposeMark)44,(categoryOfSpecialPurposeMark)45,(categoryOfSpecialPurposeMark)46,(categoryOfSpecialPurposeMark)47,(categoryOfSpecialPurposeMark)48,(categoryOfSpecialPurposeMark)49,(categoryOfSpecialPurposeMark)50,(categoryOfSpecialPurposeMark)51,(categoryOfSpecialPurposeMark)52,(categoryOfSpecialPurposeMark)53,(categoryOfSpecialPurposeMark)54,(categoryOfSpecialPurposeMark)55,(categoryOfSpecialPurposeMark)56,(categoryOfSpecialPurposeMark)57,(categoryOfSpecialPurposeMark)58,(categoryOfSpecialPurposeMark)59,(categoryOfSpecialPurposeMark)60,(categoryOfSpecialPurposeMark)61,(categoryOfSpecialPurposeMark)62,(categoryOfSpecialPurposeMark)63,(categoryOfSpecialPurposeMark)64];


		public override FeatureViewModel<SpecialPurposeGeneralBuoy> Load(SpecialPurposeGeneralBuoy instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => SpecialPurposeGeneralBuoy._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SpecialPurposeGeneralBuoy._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SpecialPurposeGeneralBuoy._featureBindingDefinitions;

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
	[CategoryOrder("DangerousFeature",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DangerousFeatureViewModel : FeatureViewModel<DangerousFeature> {
		[Category("DangerousFeature")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override FeatureViewModel<DangerousFeature> Load(DangerousFeature instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => DangerousFeature._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. DangerousFeature._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => DangerousFeature._featureBindingDefinitions;

		public override string? ToString() => $"Dangerous Feature";

		public DangerousFeatureViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// Used to identify an aggregation of two or more objects. This aggregation may be named content of categoryOfAggregation should be put in information attribute when converting to S-57.
	/// </summary>
	[CategoryOrder("AtonAggregation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonAggregationViewModel : FeatureViewModel<AtonAggregation> {
		private CategoryOfAggregation _CategoryOfAggregation ;

		[Category("AtonAggregation")]
		[Editor(typeof(Editors.UnknownEditor<CategoryOfAggregation?>), typeof(Editors.UnknownEditor<CategoryOfAggregation?>))]
		public CategoryOfAggregation CategoryOfAggregation {
			get {
				return _CategoryOfAggregation;
			}
			set {
				SetValue(ref _CategoryOfAggregation, value);
			}
		}

		[Browsable(false)]
		public CategoryOfAggregation[] CategoryOfAggregationList =>  CodeList.CategoryOfAggregations.ToArray();


		public override FeatureViewModel<AtonAggregation> Load(AtonAggregation instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => AtonAggregation._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. AtonAggregation._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => AtonAggregation._featureBindingDefinitions;

		public override string? ToString() => $"Aton Aggregation";
	}

	/// <summary>
	/// Used to identify an association between two or more objects. The association may be named content of categoryOfAssociation should be put in information attribute when converting to S-57
	/// </summary>
	[CategoryOrder("AtonAssociation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonAssociationViewModel : FeatureViewModel<AtonAssociation> {
		private CategoryOfAssociation _CategoryOfAssociation ;

		[Category("AtonAssociation")]
		[Editor(typeof(Editors.UnknownEditor<CategoryOfAssociation?>), typeof(Editors.UnknownEditor<CategoryOfAssociation?>))]
		public CategoryOfAssociation CategoryOfAssociation {
			get {
				return _CategoryOfAssociation;
			}
			set {
				SetValue(ref _CategoryOfAssociation, value);
			}
		}

		[Browsable(false)]
		public CategoryOfAssociation[] CategoryOfAssociationList =>  CodeList.CategoryOfAssociations.ToArray();


		public override FeatureViewModel<AtonAssociation> Load(AtonAssociation instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => AtonAssociation._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. AtonAssociation._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => AtonAssociation._featureBindingDefinitions;

		public override string? ToString() => $"Aton Association";
	}

	/// <summary>
	/// An area within which a uniform assessment of the quality of the non-bathymetric data exists.
	/// </summary>
	[CategoryOrder("QualityOfNonBathymetricData",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class QualityOfNonBathymetricDataViewModel : FeatureViewModel<QualityOfNonBathymetricData> {
		private categoryOfTemporalVariation _categoryOfTemporalVariation ;

		[Category("QualityOfNonBathymetricData")]
		[Editor(typeof(Editors.UnknownEditor<categoryOfTemporalVariation?>), typeof(Editors.UnknownEditor<categoryOfTemporalVariation?>))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfTemporalVariationList), typeof(categoryOfTemporalVariation))]
		public categoryOfTemporalVariation categoryOfTemporalVariation {
			get {
				return _categoryOfTemporalVariation;
			}
			set {
				SetValue(ref _categoryOfTemporalVariation, value);
			}
		}

		[Browsable(false)]
		public categoryOfTemporalVariation[] categoryOfTemporalVariationList => [(categoryOfTemporalVariation)1,(categoryOfTemporalVariation)2,(categoryOfTemporalVariation)3,(categoryOfTemporalVariation)4,(categoryOfTemporalVariation)5,(categoryOfTemporalVariation)6];
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
		private horizontalPositionUncertaintyViewModel _horizontalPositionUncertainty ;

		[Category("QualityOfNonBathymetricData")]
		[ExpandableObject]
		public horizontalPositionUncertaintyViewModel horizontalPositionUncertainty {
			get {
				return _horizontalPositionUncertainty;
			}
			set {
				SetValue(ref _horizontalPositionUncertainty, value);
			}
		}
		private informationViewModel? _information  = default;

		[Category("QualityOfNonBathymetricData")]
		[ExpandableObject]
		public informationViewModel? information {
			get {
				return _information;
			}
			set {
				SetValue(ref _information, value);
			}
		}
		private String? _informationInNationalLanguage  = default;

		[Category("QualityOfNonBathymetricData")]
		public String? informationInNationalLanguage {
			get {
				return _informationInNationalLanguage;
			}
			set {
				SetValue(ref _informationInNationalLanguage, value);
			}
		}
		private textualDescriptionViewModel? _textualDescription  = default;

		[Category("QualityOfNonBathymetricData")]
		[ExpandableObject]
		public textualDescriptionViewModel? textualDescription {
			get {
				return _textualDescription;
			}
			set {
				SetValue(ref _textualDescription, value);
			}
		}
		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Category("QualityOfNonBathymetricData")]
		[ExpandableObject]
		public verticalUncertaintyViewModel? verticalUncertainty {
			get {
				return _verticalUncertainty;
			}
			set {
				SetValue(ref _verticalUncertainty, value);
			}
		}


		public override FeatureViewModel<QualityOfNonBathymetricData> Load(QualityOfNonBathymetricData instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => QualityOfNonBathymetricData._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. QualityOfNonBathymetricData._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => QualityOfNonBathymetricData._featureBindingDefinitions;

		public override string? ToString() => $"Quality of Non-Bathymetric Data";
	}

	/// <summary>
	/// A geographical area that describes the coverage and extent of spatial objects.
	/// </summary>
	[CategoryOrder("DataCoverage",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DataCoverageViewModel : FeatureViewModel<DataCoverage> {
		private int _maximumDisplayScale ;

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
		private int _minimumDisplayScale ;

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
	/// An area within which the navigational system of marks has been established in relation to a specific direction.
	/// </summary>
	[CategoryOrder("LocalDirectionOfBuoyage",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LocalDirectionOfBuoyageViewModel : FeatureViewModel<LocalDirectionOfBuoyage> {
		private orientationViewModel _orientation ;

		[Category("LocalDirectionOfBuoyage")]
		[ExpandableObject]
		public orientationViewModel orientation {
			get {
				return _orientation;
			}
			set {
				SetValue(ref _orientation, value);
			}
		}


		public override FeatureViewModel<LocalDirectionOfBuoyage> Load(LocalDirectionOfBuoyage instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => LocalDirectionOfBuoyage._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LocalDirectionOfBuoyage._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LocalDirectionOfBuoyage._featureBindingDefinitions;

		public override string? ToString() => $"Local Direction of Buoyage";
	}

	/// <summary>
	/// An area within which the navigational system of marks has been established in relation to a specific direction.
	/// </summary>
	[CategoryOrder("NavigationalSystemOfMarks",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NavigationalSystemOfMarksViewModel : FeatureViewModel<NavigationalSystemOfMarks> {
		private marksNavigationalSystemOf _marksNavigationalSystemOf ;

		[Category("NavigationalSystemOfMarks")]
		[Editor(typeof(Editors.UnknownEditor<marksNavigationalSystemOf?>), typeof(Editors.UnknownEditor<marksNavigationalSystemOf?>))]
		[DomainModel.EnumerationAttribute(nameof(marksNavigationalSystemOfList), typeof(marksNavigationalSystemOf))]
		public marksNavigationalSystemOf marksNavigationalSystemOf {
			get {
				return _marksNavigationalSystemOf;
			}
			set {
				SetValue(ref _marksNavigationalSystemOf, value);
			}
		}

		[Browsable(false)]
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)15];


		public override FeatureViewModel<NavigationalSystemOfMarks> Load(NavigationalSystemOfMarks instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => NavigationalSystemOfMarks._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. NavigationalSystemOfMarks._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => NavigationalSystemOfMarks._featureBindingDefinitions;

		public override string? ToString() => $"Navigational System of Marks";
	}

	/// <summary>
	/// The horizontal plane or tidal datum to which soundings have been reduced. Also called datum for sounding reduction.
	/// </summary>
	[CategoryOrder("SoundingDatum",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SoundingDatumViewModel : FeatureViewModel<SoundingDatum> {
		private verticalDatum _verticalDatum ;

		[Category("SoundingDatum")]
		[Editor(typeof(Editors.UnknownEditor<verticalDatum?>), typeof(Editors.UnknownEditor<verticalDatum?>))]
		[DomainModel.EnumerationAttribute(nameof(verticalDatumList), typeof(verticalDatum))]
		public verticalDatum verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		[Browsable(false)]
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45,(verticalDatum)46,(verticalDatum)47,(verticalDatum)48,(verticalDatum)49];


		public override FeatureViewModel<SoundingDatum> Load(SoundingDatum instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => SoundingDatum._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SoundingDatum._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SoundingDatum._featureBindingDefinitions;

		public override string? ToString() => $"Sounding Datum";
	}

	/// <summary>
	/// Any level surface (for example Mean Sea Level) taken as a surface of reference to which the elevations within a data set are reduced. Also called datum level, reference level, reference plane, levelling datum, datum for heights.
	/// </summary>
	[CategoryOrder("VerticalDatumOfData",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class VerticalDatumOfDataViewModel : FeatureViewModel<VerticalDatumOfData> {
		private verticalDatum _verticalDatum ;

		[Category("VerticalDatumOfData")]
		[Editor(typeof(Editors.UnknownEditor<verticalDatum?>), typeof(Editors.UnknownEditor<verticalDatum?>))]
		[DomainModel.EnumerationAttribute(nameof(verticalDatumList), typeof(verticalDatum))]
		public verticalDatum verticalDatum {
			get {
				return _verticalDatum;
			}
			set {
				SetValue(ref _verticalDatum, value);
			}
		}

		[Browsable(false)]
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45,(verticalDatum)46,(verticalDatum)47,(verticalDatum)48,(verticalDatum)49];


		public override FeatureViewModel<VerticalDatumOfData> Load(VerticalDatumOfData instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitions => VerticalDatumOfData._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. VerticalDatumOfData._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => VerticalDatumOfData._featureBindingDefinitions;

		public override string? ToString() => $"Vertical Datum of Data";
	}

}
