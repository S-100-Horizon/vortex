using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ComponentModel;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S501;
using S100Framework.DomainModel.S501.ComplexAttributes;
using S100Framework.DomainModel.S501.InformationTypes;
using S100Framework.DomainModel.S501.FeatureTypes;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.WPF.ViewModel.S501 {
	internal static class Bootstrap {
		public static AssociationViewModel CreateInformationAssociation(string type, string? name = default) => type switch {
			_ or "" => throw new InvalidOperationException(),
		};

		public static AssociationViewModel CreateFeatureAssociation(string type, string? name = default) => type switch {
			_ or "" => throw new InvalidOperationException(),
		};

		public static InformationViewModel CreateInformationType(string type, string? name = default) => type switch {
			"ReferenceToAPublication" => new ReferenceToAPublicationViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static FeatureViewModel CreateFeatureType(string type, string? name = default) => type switch {
			"InstallationBuoy" => new InstallationBuoyViewModel { Name = name },
			"DepthArea" => new DepthAreaViewModel { Name = name },
			"RadioCallingInPoint" => new RadioCallingInPointViewModel { Name = name },
			"PatrolArea" => new PatrolAreaViewModel { Name = name },
			"Checkpoint" => new CheckpointViewModel { Name = name },
			"MarineManagementArea" => new MarineManagementAreaViewModel { Name = name },
			"DepthContour" => new DepthContourViewModel { Name = name },
			"EnvironmentallySensitiveSeaArea" => new EnvironmentallySensitiveSeaAreaViewModel { Name = name },
			"Road" => new RoadViewModel { Name = name },
			"River" => new RiverViewModel { Name = name },
			"MilitaryPracticeArea" => new MilitaryPracticeAreaViewModel { Name = name },
			"DiscolouredWater" => new DiscolouredWaterViewModel { Name = name },
			"CardinalBuoy" => new CardinalBuoyViewModel { Name = name },
			"SafeWaterBuoy" => new SafeWaterBuoyViewModel { Name = name },
			"RadioStation" => new RadioStationViewModel { Name = name },
			"MilitaryExerciseAirspace" => new MilitaryExerciseAirspaceViewModel { Name = name },
			"ContiguousZone" => new ContiguousZoneViewModel { Name = name },
			"NormalBaseline" => new NormalBaselineViewModel { Name = name },
			"CableArea" => new CableAreaViewModel { Name = name },
			"ContinentalShelfArea" => new ContinentalShelfAreaViewModel { Name = name },
			"InternalWaters" => new InternalWatersViewModel { Name = name },
			"AdministrationArea" => new AdministrationAreaViewModel { Name = name },
			"Bollard" => new BollardViewModel { Name = name },
			"Dolphin" => new DolphinViewModel { Name = name },
			"RadarRange" => new RadarRangeViewModel { Name = name },
			"IsolatedDangerBeacon" => new IsolatedDangerBeaconViewModel { Name = name },
			"IsolatedDangerBuoy" => new IsolatedDangerBuoyViewModel { Name = name },
			"SubmarineTransitLane" => new SubmarineTransitLaneViewModel { Name = name },
			"MaritimeSafetyInformationArea" => new MaritimeSafetyInformationAreaViewModel { Name = name },
			"AirspaceRestriction" => new AirspaceRestrictionViewModel { Name = name },
			"Sounding" => new SoundingViewModel { Name = name },
			"TrafficSeparationSchemeBoundary" => new TrafficSeparationSchemeBoundaryViewModel { Name = name },
			"DumpingGround" => new DumpingGroundViewModel { Name = name },
			"AirportAirfield" => new AirportAirfieldViewModel { Name = name },
			"FoulGround" => new FoulGroundViewModel { Name = name },
			"LightAirObstruction" => new LightAirObstructionViewModel { Name = name },
			"MooringBuoy" => new MooringBuoyViewModel { Name = name },
			"UnderwaterAwashRock" => new UnderwaterAwashRockViewModel { Name = name },
			"CableOverhead" => new CableOverheadViewModel { Name = name },
			"ControlledAirspace" => new ControlledAirspaceViewModel { Name = name },
			"Obstruction" => new ObstructionViewModel { Name = name },
			"FishingGround" => new FishingGroundViewModel { Name = name },
			"FishingFacility" => new FishingFacilityViewModel { Name = name },
			"NavigationSystem" => new NavigationSystemViewModel { Name = name },
			"TrafficSeparationSchemeCrossing" => new TrafficSeparationSchemeCrossingViewModel { Name = name },
			"TrafficSeparationSchemeLanePart" => new TrafficSeparationSchemeLanePartViewModel { Name = name },
			"TerritorialSeaArea" => new TerritorialSeaAreaViewModel { Name = name },
			"LateralBeacon" => new LateralBeaconViewModel { Name = name },
			"CoastGuardStation" => new CoastGuardStationViewModel { Name = name },
			"SeparationZoneOrLine" => new SeparationZoneOrLineViewModel { Name = name },
			"BottomFeature" => new BottomFeatureViewModel { Name = name },
			"ArchipelagicBaseline" => new ArchipelagicBaselineViewModel { Name = name },
			"SmallBottomObject" => new SmallBottomObjectViewModel { Name = name },
			"ExclusiveEconomicZone" => new ExclusiveEconomicZoneViewModel { Name = name },
			"RadarStation" => new RadarStationViewModel { Name = name },
			"DivingLocation" => new DivingLocationViewModel { Name = name },
			"RestrictedArea" => new RestrictedAreaViewModel { Name = name },
			"CableSubmarine" => new CableSubmarineViewModel { Name = name },
			"Wreck" => new WreckViewModel { Name = name },
			"QRoute" => new QRouteViewModel { Name = name },
			"CompletenessOfProductSpecification" => new CompletenessOfProductSpecificationViewModel { Name = name },
			"RescueStation" => new RescueStationViewModel { Name = name },
			"CardinalBeacon" => new CardinalBeaconViewModel { Name = name },
			"LightVessel" => new LightVesselViewModel { Name = name },
			"FisheryZone" => new FisheryZoneViewModel { Name = name },
			"DredgedArea" => new DredgedAreaViewModel { Name = name },
			"FerryRoute" => new FerryRouteViewModel { Name = name },
			"ShorelineConstruction" => new ShorelineConstructionViewModel { Name = name },
			"CautionArea" => new CautionAreaViewModel { Name = name },
			"DeepWaterRoutePart" => new DeepWaterRoutePartViewModel { Name = name },
			"CurrentNonGravitational" => new CurrentNonGravitationalViewModel { Name = name },
			"DataCoverage" => new DataCoverageViewModel { Name = name },
			"SeabedArea" => new SeabedAreaViewModel { Name = name },
			"SpecialPurposeGeneralBuoy" => new SpecialPurposeGeneralBuoyViewModel { Name = name },
			"LightSectored" => new LightSectoredViewModel { Name = name },
			"IceLine" => new IceLineViewModel { Name = name },
			"AnchorageArea" => new AnchorageAreaViewModel { Name = name },
			"LateralBuoy" => new LateralBuoyViewModel { Name = name },
			"TrafficSeparationSchemeRoundabout" => new TrafficSeparationSchemeRoundaboutViewModel { Name = name },
			"DeepWaterRouteCentreline" => new DeepWaterRouteCentrelineViewModel { Name = name },
			"LightFloat" => new LightFloatViewModel { Name = name },
			"LightAllAround" => new LightAllAroundViewModel { Name = name },
			"Coastline" => new CoastlineViewModel { Name = name },
			"SeaAreaNamedWaterArea" => new SeaAreaNamedWaterAreaViewModel { Name = name },
			"DropZone" => new DropZoneViewModel { Name = name },
			"Conveyor" => new ConveyorViewModel { Name = name },
			"LineOfDelimitation" => new LineOfDelimitationViewModel { Name = name },
			"StraightTerritorialSeaBaseline" => new StraightTerritorialSeaBaselineViewModel { Name = name },
			"SafeWaterBeacon" => new SafeWaterBeaconViewModel { Name = name },
			"SpecialPurposeGeneralBeacon" => new SpecialPurposeGeneralBeaconViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static ICollection<string> InformationAssociationBindings(string association, string role) => (association, role) switch {
			_ => throw new InvalidOperationException(),
		};

		public static ICollection<string> FeatureAssociationBindings(string association, string role) => (association, role) switch {
			_ => throw new InvalidOperationException(),
		};
	}

	/// <summary>
	/// The predefined span on clearance, determined after assessing geographical and Mine Countermeasure (MCM) conditions, within which a designated Q Route operates.
	/// </summary>
	[CategoryOrder("qRouteChannelWidth",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class qRouteChannelWidthViewModel : ViewModelBase {
		private decimal _rightQRouteWidth ;

		public decimal rightQRouteWidth {
			get {
				return _rightQRouteWidth;
			}
			set {
				SetValue(ref _rightQRouteWidth, value);
			}
		}


		public qRouteChannelWidthViewModel Load(qRouteChannelWidth instance) {
			rightQRouteWidth = instance.rightQRouteWidth;
			return this;
		}

		public override string Serialize() {
			var instance = new qRouteChannelWidth {
				rightQRouteWidth = this.rightQRouteWidth,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public qRouteChannelWidth Model => new () {
			rightQRouteWidth = this._rightQRouteWidth,
		};

		public override string? ToString() => $"Q-Route Channel Width";
	}
	/// <summary>
	/// The range in years in which the object was originally reported
	/// </summary>
	[CategoryOrder("detectionDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class detectionDateRangeViewModel : ViewModelBase {
		private DateOnly? _lastDetectionYear  = default;

		public DateOnly? lastDetectionYear {
			get {
				return _lastDetectionYear;
			}
			set {
				SetValue(ref _lastDetectionYear, value);
			}
		}
		private DateOnly? _firstDetectionYear  = default;

		public DateOnly? firstDetectionYear {
			get {
				return _firstDetectionYear;
			}
			set {
				SetValue(ref _firstDetectionYear, value);
			}
		}


		public detectionDateRangeViewModel Load(detectionDateRange instance) {
			lastDetectionYear = instance.lastDetectionYear;
			firstDetectionYear = instance.firstDetectionYear;
			return this;
		}

		public override string Serialize() {
			var instance = new detectionDateRange {
				lastDetectionYear = this.lastDetectionYear,
				firstDetectionYear = this.firstDetectionYear,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public detectionDateRange Model => new () {
			lastDetectionYear = this._lastDetectionYear,
			firstDetectionYear = this._firstDetectionYear,
		};

		public override string? ToString() => $"Detection Date Range";
	}
	/// <summary>
	/// The number of features of identical character that exist as a co-located group.
	/// </summary>
	[CategoryOrder("multiplicityOfFeatures",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class multiplicityOfFeaturesViewModel : ViewModelBase {
		private int? _numberOfFeatures  = default;

		public int? numberOfFeatures {
			get {
				return _numberOfFeatures;
			}
			set {
				SetValue(ref _numberOfFeatures, value);
			}
		}
		private Boolean _multiplicityKnown  = false;

		public Boolean multiplicityKnown {
			get {
				return _multiplicityKnown;
			}
			set {
				SetValue(ref _multiplicityKnown, value);
			}
		}


		public multiplicityOfFeaturesViewModel Load(multiplicityOfFeatures instance) {
			numberOfFeatures = instance.numberOfFeatures;
			multiplicityKnown = instance.multiplicityKnown;
			return this;
		}

		public override string Serialize() {
			var instance = new multiplicityOfFeatures {
				numberOfFeatures = this.numberOfFeatures,
				multiplicityKnown = this.multiplicityKnown,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public multiplicityOfFeatures Model => new () {
			numberOfFeatures = this._numberOfFeatures,
			multiplicityKnown = this._multiplicityKnown,
		};

		public override string? ToString() => $"Multiplicity of Features";
	}
	/// <summary>
	/// Information about online sources from which a resource or data can be obtained.
	/// </summary>
	[CategoryOrder("onlineResource",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class onlineResourceViewModel : ViewModelBase {
		private String? _headline  = default;

		public String? headline {
			get {
				return _headline;
			}
			set {
				SetValue(ref _headline, value);
			}
		}
		private String _linkage  = string.Empty;

		public String linkage {
			get {
				return _linkage;
			}
			set {
				SetValue(ref _linkage, value);
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


		public onlineResourceViewModel Load(onlineResource instance) {
			headline = instance.headline;
			linkage = instance.linkage;
			nameOfResource = instance.nameOfResource;
			return this;
		}

		public override string Serialize() {
			var instance = new onlineResource {
				headline = this.headline,
				linkage = this.linkage,
				nameOfResource = this.nameOfResource,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public onlineResource Model => new () {
			headline = this._headline,
			linkage = this._linkage,
			nameOfResource = this._nameOfResource,
		};

		public override string? ToString() => $"Online Resource";
	}
	/// <summary>
	/// A characteristic shape secured at the top of a buoy or beacon to aid in its identification.
	/// </summary>
	[CategoryOrder("topmark",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class topmarkViewModel : ViewModelBase {
		private topmarkDaymarkShape _topmarkDaymarkShape ;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		public topmarkDaymarkShape[] topmarkDaymarkShapeList => [(topmarkDaymarkShape)1,(topmarkDaymarkShape)2,(topmarkDaymarkShape)3,(topmarkDaymarkShape)4,(topmarkDaymarkShape)5,(topmarkDaymarkShape)6,(topmarkDaymarkShape)7,(topmarkDaymarkShape)8,(topmarkDaymarkShape)9,(topmarkDaymarkShape)10,(topmarkDaymarkShape)11,(topmarkDaymarkShape)12,(topmarkDaymarkShape)13,(topmarkDaymarkShape)14,(topmarkDaymarkShape)15,(topmarkDaymarkShape)16,(topmarkDaymarkShape)17,(topmarkDaymarkShape)18,(topmarkDaymarkShape)19,(topmarkDaymarkShape)20,(topmarkDaymarkShape)21,(topmarkDaymarkShape)22,(topmarkDaymarkShape)23,(topmarkDaymarkShape)24,(topmarkDaymarkShape)25,(topmarkDaymarkShape)26,(topmarkDaymarkShape)27,(topmarkDaymarkShape)28,(topmarkDaymarkShape)29,(topmarkDaymarkShape)30,(topmarkDaymarkShape)31,(topmarkDaymarkShape)32,(topmarkDaymarkShape)33];
		private colourPattern? _colourPattern  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public colourPattern? colourPattern {
			get {
				return _colourPattern;
			}
			set {
				SetValue(ref _colourPattern, value);
			}
		}

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6];
		private colour? _colour  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public colour? colour {
			get {
				return _colour;
			}
			set {
				SetValue(ref _colour, value);
			}
		}

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("topmark")]
		public ObservableCollection<shapeInformationViewModel> shapeInformation  { get; set; } = new ();


		public topmarkViewModel Load(topmark instance) {
			topmarkDaymarkShape = instance.topmarkDaymarkShape;
			colourPattern = instance.colourPattern;
			colour = instance.colour;
			shapeInformation.Clear();
			if (instance.shapeInformation is not null) {
				foreach(var e in instance.shapeInformation)
					shapeInformation.Add(new shapeInformationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new topmark {
				topmarkDaymarkShape = this.topmarkDaymarkShape,
				colourPattern = this.colourPattern,
				colour = this.colour,
				shapeInformation = this.shapeInformation.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public topmark Model => new () {
			topmarkDaymarkShape = this._topmarkDaymarkShape,
			colourPattern = this._colourPattern,
			colour = this._colour,
			shapeInformation = this.shapeInformation.Select(e => e.Model).ToList(),
		};

		public override string? ToString() => $"Topmark";

		public topmarkViewModel() : base() {
			shapeInformation.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(shapeInformation));
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
		private nameUsage? _nameUsage  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(nameUsageList), typeof(nameUsage))]
		public nameUsage? nameUsage {
			get {
				return _nameUsage;
			}
			set {
				SetValue(ref _nameUsage, value);
			}
		}

		[Browsable(false)]
		public nameUsage[] nameUsageList => [(nameUsage)1,(nameUsage)2];
		private String _name  = string.Empty;

		public String name {
			get {
				return _name;
			}
			set {
				SetValue(ref _name, value);
			}
		}
		private String _language  = string.Empty;

		public String language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}


		public featureNameViewModel Load(featureName instance) {
			nameUsage = instance.nameUsage;
			name = instance.name;
			language = instance.language;
			return this;
		}

		public override string Serialize() {
			var instance = new featureName {
				nameUsage = this.nameUsage,
				name = this.name,
				language = this.language,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public featureName Model => new () {
			nameUsage = this._nameUsage,
			name = this._name,
			language = this._language,
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
		private DateOnly? _dateStart  = default;

		public DateOnly? dateStart {
			get {
				return _dateStart;
			}
			set {
				SetValue(ref _dateStart, value);
			}
		}
		private DateOnly? _dateEnd  = default;

		public DateOnly? dateEnd {
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
	/// Altitude range encompasses both the maximum and minimum heights (AGL - above ground level) above the surface level, representing the vertical span from the highest to the lowest point of the feature.
	/// </summary>
	[CategoryOrder("altitudeRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class altitudeRangeViewModel : ViewModelBase {
		private int _minimumAltitude ;

		public int minimumAltitude {
			get {
				return _minimumAltitude;
			}
			set {
				SetValue(ref _minimumAltitude, value);
			}
		}
		private int _maximumAltitude ;

		public int maximumAltitude {
			get {
				return _maximumAltitude;
			}
			set {
				SetValue(ref _maximumAltitude, value);
			}
		}


		public altitudeRangeViewModel Load(altitudeRange instance) {
			minimumAltitude = instance.minimumAltitude;
			maximumAltitude = instance.maximumAltitude;
			return this;
		}

		public override string Serialize() {
			var instance = new altitudeRange {
				minimumAltitude = this.minimumAltitude,
				maximumAltitude = this.maximumAltitude,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public altitudeRange Model => new () {
			minimumAltitude = this._minimumAltitude,
			maximumAltitude = this._maximumAltitude,
		};

		public override string? ToString() => $"Altitude Range";
	}
	/// <summary>
	/// (1) The vertical distance of a level, a point or an object considered as a point (but not affixed to the surface of the earth), measured from a given datum, usually mean sea level. See also elevation and height. (2) In astronomy, the vertical angle between the plane of the horizon and the line to a celestial body. See also angle of depression and angle of elevation.
	/// </summary>
	[CategoryOrder("altitude",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class altitudeViewModel : ViewModelBase {
		private int _minimumAltitude ;

		public int minimumAltitude {
			get {
				return _minimumAltitude;
			}
			set {
				SetValue(ref _minimumAltitude, value);
			}
		}
		private int _maximumAltitude ;

		public int maximumAltitude {
			get {
				return _maximumAltitude;
			}
			set {
				SetValue(ref _maximumAltitude, value);
			}
		}


		public altitudeViewModel Load(altitude instance) {
			minimumAltitude = instance.minimumAltitude;
			maximumAltitude = instance.maximumAltitude;
			return this;
		}

		public override string Serialize() {
			var instance = new altitude {
				minimumAltitude = this.minimumAltitude,
				maximumAltitude = this.maximumAltitude,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public altitude Model => new () {
			minimumAltitude = this._minimumAltitude,
			maximumAltitude = this._maximumAltitude,
		};

		public override string? ToString() => $"Altitude";
	}
	/// <summary>
	/// missing definition
	/// </summary>
	[CategoryOrder("rythmOfLight",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class rythmOfLightViewModel : ViewModelBase {
		[Category("rythmOfLight")]
		public ObservableCollection<signalSequenceViewModel> signalSequence  { get; set; } = new ();
		private decimal? _signalPeriod  = default;

		public decimal? signalPeriod {
			get {
				return _signalPeriod;
			}
			set {
				SetValue(ref _signalPeriod, value);
			}
		}
		[Category("rythmOfLight")]
		public ObservableCollection<String> signalGroup  { get; set; } = new ();
		private lightCharacteristic _lightCharacteristic ;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		public lightCharacteristic[] lightCharacteristicList => [(lightCharacteristic)1,(lightCharacteristic)2,(lightCharacteristic)3,(lightCharacteristic)4,(lightCharacteristic)5,(lightCharacteristic)6,(lightCharacteristic)7,(lightCharacteristic)8,(lightCharacteristic)11,(lightCharacteristic)12,(lightCharacteristic)13,(lightCharacteristic)14,(lightCharacteristic)15,(lightCharacteristic)16,(lightCharacteristic)17,(lightCharacteristic)18,(lightCharacteristic)19,(lightCharacteristic)25,(lightCharacteristic)26,(lightCharacteristic)27,(lightCharacteristic)28,(lightCharacteristic)29];


		public rythmOfLightViewModel Load(rythmOfLight instance) {
			signalSequence.Clear();
			if (instance.signalSequence is not null) {
				foreach(var e in instance.signalSequence)
					signalSequence.Add(new signalSequenceViewModel().Load(e));
			}
			signalPeriod = instance.signalPeriod;
			signalGroup.Clear();
			if (instance.signalGroup is not null) {
				foreach(var e in instance.signalGroup)
					signalGroup.Add(e);
			}
			lightCharacteristic = instance.lightCharacteristic;
			return this;
		}

		public override string Serialize() {
			var instance = new rythmOfLight {
				signalSequence = this.signalSequence.Select(e => e.Model).ToList(),
				signalPeriod = this.signalPeriod,
				signalGroup = this.signalGroup.ToList(),
				lightCharacteristic = this.lightCharacteristic,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public rythmOfLight Model => new () {
			signalSequence = this.signalSequence.Select(e => e.Model).ToList(),
			signalPeriod = this._signalPeriod,
			signalGroup = this.signalGroup.ToList(),
			lightCharacteristic = this._lightCharacteristic,
		};

		public override string? ToString() => $"rythmOfLight (missing name)";

		public rythmOfLightViewModel() : base() {
			signalSequence.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(signalSequence));
			};
			signalGroup.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(signalGroup));
			};
		}
	}
	/// <summary>
	/// The safe vertical clearance of a feature measured from the horizontal plane towards the feature overhead.
	/// </summary>
	[CategoryOrder("verticalClearanceSafe",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class verticalClearanceSafeViewModel : ViewModelBase {
		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Category("verticalClearanceSafe")]
		[ExpandableObject]
		public verticalUncertaintyViewModel? verticalUncertainty {
			get {
				return _verticalUncertainty;
			}
			set {
				SetValue(ref _verticalUncertainty, value);
			}
		}
		private decimal _verticalClearanceValue ;

		public decimal verticalClearanceValue {
			get {
				return _verticalClearanceValue;
			}
			set {
				SetValue(ref _verticalClearanceValue, value);
			}
		}


		public verticalClearanceSafeViewModel Load(verticalClearanceSafe instance) {
			verticalUncertainty = new ();
			if (instance.verticalUncertainty != default) {
				verticalUncertainty.Load(instance.verticalUncertainty);
			}
			verticalClearanceValue = instance.verticalClearanceValue;
			return this;
		}

		public override string Serialize() {
			var instance = new verticalClearanceSafe {
				verticalUncertainty = this.verticalUncertainty?.Model,
				verticalClearanceValue = this.verticalClearanceValue,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public verticalClearanceSafe Model => new () {
			verticalUncertainty = this._verticalUncertainty?.Model,
			verticalClearanceValue = this._verticalClearanceValue,
		};

		public override string? ToString() => $"Vertical Clearance Safe";
	}
	/// <summary>
	/// The source and the sensor used of the subsequent report of the object. 
	/// </summary>
	[CategoryOrder("lastSourceInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class lastSourceInformationViewModel : ViewModelBase {
		private lastSensor? _lastSensor  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(lastSensorList), typeof(lastSensor))]
		public lastSensor? lastSensor {
			get {
				return _lastSensor;
			}
			set {
				SetValue(ref _lastSensor, value);
			}
		}

		[Browsable(false)]
		public lastSensor[] lastSensorList => [(lastSensor)501,(lastSensor)502,(lastSensor)503,(lastSensor)504,(lastSensor)506,(lastSensor)509];
		private String? _lastSource  = default;

		public String? lastSource {
			get {
				return _lastSource;
			}
			set {
				SetValue(ref _lastSource, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}


		public lastSourceInformationViewModel Load(lastSourceInformation instance) {
			lastSensor = instance.lastSensor;
			lastSource = instance.lastSource;
			reportedDate = instance.reportedDate;
			return this;
		}

		public override string Serialize() {
			var instance = new lastSourceInformation {
				lastSensor = this.lastSensor,
				lastSource = this.lastSource,
				reportedDate = this.reportedDate,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public lastSourceInformation Model => new () {
			lastSensor = this._lastSensor,
			lastSource = this._lastSource,
			reportedDate = this._reportedDate,
		};

		public override string? ToString() => $"Last Source Information";
	}
	/// <summary>
	/// Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.
	/// </summary>
	[CategoryOrder("information",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class informationViewModel : ViewModelBase {
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

		public String language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}
		private String? _fileLocator  = default;

		public String? fileLocator {
			get {
				return _fileLocator;
			}
			set {
				SetValue(ref _fileLocator, value);
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
		private String? _fileReference  = default;

		public String? fileReference {
			get {
				return _fileReference;
			}
			set {
				SetValue(ref _fileReference, value);
			}
		}


		public informationViewModel Load(information instance) {
			headline = instance.headline;
			language = instance.language;
			fileLocator = instance.fileLocator;
			text = instance.text;
			fileReference = instance.fileReference;
			return this;
		}

		public override string Serialize() {
			var instance = new information {
				headline = this.headline,
				language = this.language,
				fileLocator = this.fileLocator,
				text = this.text,
				fileReference = this.fileReference,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public information Model => new () {
			headline = this._headline,
			language = this._language,
			fileLocator = this._fileLocator,
			text = this._text,
			fileReference = this._fileReference,
		};

		public override string? ToString() => $"Information";
	}
	/// <summary>
	/// The source and the sensor used of the original report of the object.
	/// </summary>
	[CategoryOrder("firstSourceInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class firstSourceInformationViewModel : ViewModelBase {
		private firstSensor _firstSensor ;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(firstSensorList), typeof(firstSensor))]
		public firstSensor firstSensor {
			get {
				return _firstSensor;
			}
			set {
				SetValue(ref _firstSensor, value);
			}
		}

		[Browsable(false)]
		public firstSensor[] firstSensorList => [(firstSensor)501,(firstSensor)502,(firstSensor)503,(firstSensor)504,(firstSensor)506,(firstSensor)509];
		private String? _firstSource  = default;

		public String? firstSource {
			get {
				return _firstSource;
			}
			set {
				SetValue(ref _firstSource, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}


		public firstSourceInformationViewModel Load(firstSourceInformation instance) {
			firstSensor = instance.firstSensor;
			firstSource = instance.firstSource;
			reportedDate = instance.reportedDate;
			return this;
		}

		public override string Serialize() {
			var instance = new firstSourceInformation {
				firstSensor = this.firstSensor,
				firstSource = this.firstSource,
				reportedDate = this.reportedDate,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public firstSourceInformation Model => new () {
			firstSensor = this._firstSensor,
			firstSource = this._firstSource,
			reportedDate = this._reportedDate,
		};

		public override string? ToString() => $"First Source Information";
	}
	/// <summary>
	/// The horizontal clearance measured between two points for a fixed span.
	/// </summary>
	[CategoryOrder("horizontalClearanceFixed",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class horizontalClearanceFixedViewModel : ViewModelBase {
		private decimal _horizontalClearanceValue ;

		public decimal horizontalClearanceValue {
			get {
				return _horizontalClearanceValue;
			}
			set {
				SetValue(ref _horizontalClearanceValue, value);
			}
		}
		private decimal? _horizontalDistanceUncertainty  = default;

		public decimal? horizontalDistanceUncertainty {
			get {
				return _horizontalDistanceUncertainty;
			}
			set {
				SetValue(ref _horizontalDistanceUncertainty, value);
			}
		}


		public horizontalClearanceFixedViewModel Load(horizontalClearanceFixed instance) {
			horizontalClearanceValue = instance.horizontalClearanceValue;
			horizontalDistanceUncertainty = instance.horizontalDistanceUncertainty;
			return this;
		}

		public override string Serialize() {
			var instance = new horizontalClearanceFixed {
				horizontalClearanceValue = this.horizontalClearanceValue,
				horizontalDistanceUncertainty = this.horizontalDistanceUncertainty,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public horizontalClearanceFixed Model => new () {
			horizontalClearanceValue = this._horizontalClearanceValue,
			horizontalDistanceUncertainty = this._horizontalDistanceUncertainty,
		};

		public override string? ToString() => $"Horizontal Clearance Fixed";
	}
	/// <summary>
	/// The best estimate of the vertical accuracy of depths, heights, vertical distances and vertical clearances.
	/// </summary>
	[CategoryOrder("verticalUncertainty",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class verticalUncertaintyViewModel : ViewModelBase {
		private decimal? _uncertaintyVariableFactor  = default;

		public decimal? uncertaintyVariableFactor {
			get {
				return _uncertaintyVariableFactor;
			}
			set {
				SetValue(ref _uncertaintyVariableFactor, value);
			}
		}
		private decimal _uncertaintyFixed ;

		public decimal uncertaintyFixed {
			get {
				return _uncertaintyFixed;
			}
			set {
				SetValue(ref _uncertaintyFixed, value);
			}
		}


		public verticalUncertaintyViewModel Load(verticalUncertainty instance) {
			uncertaintyVariableFactor = instance.uncertaintyVariableFactor;
			uncertaintyFixed = instance.uncertaintyFixed;
			return this;
		}

		public override string Serialize() {
			var instance = new verticalUncertainty {
				uncertaintyVariableFactor = this.uncertaintyVariableFactor,
				uncertaintyFixed = this.uncertaintyFixed,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public verticalUncertainty Model => new () {
			uncertaintyVariableFactor = this._uncertaintyVariableFactor,
			uncertaintyFixed = this._uncertaintyFixed,
		};

		public override string? ToString() => $"Vertical Uncertainty";
	}
	/// <summary>
	/// A pair of frequencies for transmitting and receiving radio signals. The shore station transmits and receives on the frequencies indicated.
	/// </summary>
	[CategoryOrder("frequencyPair",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class frequencyPairViewModel : ViewModelBase {
		private int? _frequencyShoreStationReceives  = default;

		public int? frequencyShoreStationReceives {
			get {
				return _frequencyShoreStationReceives;
			}
			set {
				SetValue(ref _frequencyShoreStationReceives, value);
			}
		}
		private int _frequencyShoreStationTransmits ;

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
	/// Combinations of values of measurable characteristics or dimensions of vessels, used to specify size and tonnage ranges.
	/// </summary>
	[CategoryOrder("vesselMeasurementsSpecification",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class vesselMeasurementsSpecificationViewModel : ViewModelBase {
		private decimal _vesselsCharacteristicsValue ;

		public decimal vesselsCharacteristicsValue {
			get {
				return _vesselsCharacteristicsValue;
			}
			set {
				SetValue(ref _vesselsCharacteristicsValue, value);
			}
		}
		private vesselsCharacteristics _vesselsCharacteristics ;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		public vesselsCharacteristics[] vesselsCharacteristicsList => [(vesselsCharacteristics)1,(vesselsCharacteristics)2,(vesselsCharacteristics)3,(vesselsCharacteristics)4,(vesselsCharacteristics)6,(vesselsCharacteristics)10,(vesselsCharacteristics)11];
		private vesselsCharacteristicsUnit _vesselsCharacteristicsUnit ;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		public vesselsCharacteristicsUnit[] vesselsCharacteristicsUnitList => [(vesselsCharacteristicsUnit)1,(vesselsCharacteristicsUnit)3,(vesselsCharacteristicsUnit)4,(vesselsCharacteristicsUnit)5,(vesselsCharacteristicsUnit)6,(vesselsCharacteristicsUnit)7];
		private comparisonOperator? _comparisonOperator  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(comparisonOperatorList), typeof(comparisonOperator))]
		public comparisonOperator? comparisonOperator {
			get {
				return _comparisonOperator;
			}
			set {
				SetValue(ref _comparisonOperator, value);
			}
		}

		[Browsable(false)]
		public comparisonOperator[] comparisonOperatorList => [(comparisonOperator)1,(comparisonOperator)2,(comparisonOperator)3,(comparisonOperator)4,(comparisonOperator)5,(comparisonOperator)6];


		public vesselMeasurementsSpecificationViewModel Load(vesselMeasurementsSpecification instance) {
			vesselsCharacteristicsValue = instance.vesselsCharacteristicsValue;
			vesselsCharacteristics = instance.vesselsCharacteristics;
			vesselsCharacteristicsUnit = instance.vesselsCharacteristicsUnit;
			comparisonOperator = instance.comparisonOperator;
			return this;
		}

		public override string Serialize() {
			var instance = new vesselMeasurementsSpecification {
				vesselsCharacteristicsValue = this.vesselsCharacteristicsValue,
				vesselsCharacteristics = this.vesselsCharacteristics,
				vesselsCharacteristicsUnit = this.vesselsCharacteristicsUnit,
				comparisonOperator = this.comparisonOperator,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public vesselMeasurementsSpecification Model => new () {
			vesselsCharacteristicsValue = this._vesselsCharacteristicsValue,
			vesselsCharacteristics = this._vesselsCharacteristics,
			vesselsCharacteristicsUnit = this._vesselsCharacteristicsUnit,
			comparisonOperator = this._comparisonOperator,
		};

		public override string? ToString() => $"Vessel Measurements Specification";
	}
	/// <summary>
	/// The general nature of the material of which the land surface or the seabed is composed.
	/// </summary>
	[CategoryOrder("surfaceCharacteristics",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class surfaceCharacteristicsViewModel : ViewModelBase {
		private int? _underlyingLayer  = default;

		public int? underlyingLayer {
			get {
				return _underlyingLayer;
			}
			set {
				SetValue(ref _underlyingLayer, value);
			}
		}
		[Category("surfaceCharacteristics")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfSurfaceQualifyingTermsList), typeof(natureOfSurfaceQualifyingTerms))]
		public ObservableCollection<natureOfSurfaceQualifyingTerms> natureOfSurfaceQualifyingTerms  { get; set; } = new ();

		[Browsable(false)]
		public natureOfSurfaceQualifyingTerms[] natureOfSurfaceQualifyingTermsList => [(natureOfSurfaceQualifyingTerms)1,(natureOfSurfaceQualifyingTerms)2,(natureOfSurfaceQualifyingTerms)3,(natureOfSurfaceQualifyingTerms)4,(natureOfSurfaceQualifyingTerms)5,(natureOfSurfaceQualifyingTerms)6,(natureOfSurfaceQualifyingTerms)7,(natureOfSurfaceQualifyingTerms)8,(natureOfSurfaceQualifyingTerms)9,(natureOfSurfaceQualifyingTerms)10];
		private natureOfSurface? _natureOfSurface  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfSurfaceList), typeof(natureOfSurface))]
		public natureOfSurface? natureOfSurface {
			get {
				return _natureOfSurface;
			}
			set {
				SetValue(ref _natureOfSurface, value);
			}
		}

		[Browsable(false)]
		public natureOfSurface[] natureOfSurfaceList => [(natureOfSurface)1,(natureOfSurface)2,(natureOfSurface)3,(natureOfSurface)4,(natureOfSurface)5,(natureOfSurface)6,(natureOfSurface)7,(natureOfSurface)8,(natureOfSurface)9,(natureOfSurface)11,(natureOfSurface)14,(natureOfSurface)17,(natureOfSurface)18];


		public surfaceCharacteristicsViewModel Load(surfaceCharacteristics instance) {
			underlyingLayer = instance.underlyingLayer;
			natureOfSurfaceQualifyingTerms.Clear();
			if (instance.natureOfSurfaceQualifyingTerms is not null) {
				foreach(var e in instance.natureOfSurfaceQualifyingTerms)
					natureOfSurfaceQualifyingTerms.Add(e);
			}
			natureOfSurface = instance.natureOfSurface;
			return this;
		}

		public override string Serialize() {
			var instance = new surfaceCharacteristics {
				underlyingLayer = this.underlyingLayer,
				natureOfSurfaceQualifyingTerms = this.natureOfSurfaceQualifyingTerms.ToList(),
				natureOfSurface = this.natureOfSurface,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public surfaceCharacteristics Model => new () {
			underlyingLayer = this._underlyingLayer,
			natureOfSurfaceQualifyingTerms = this.natureOfSurfaceQualifyingTerms.ToList(),
			natureOfSurface = this._natureOfSurface,
		};

		public override string? ToString() => $"Surface Characteristics";

		public surfaceCharacteristicsViewModel() : base() {
			natureOfSurfaceQualifyingTerms.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfSurfaceQualifyingTerms));
			};
		}
	}
	/// <summary>
	/// Indication of the collective magnetic attributes and characteristics associated with an object, as measured and quantified through various magnetic detection methods.
	/// </summary>
	[CategoryOrder("magneticInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class magneticInformationViewModel : ViewModelBase {
		private strengthOfMagneticAnomaly? _strengthOfMagneticAnomaly  = default;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(strengthOfMagneticAnomalyList), typeof(strengthOfMagneticAnomaly))]
		public strengthOfMagneticAnomaly? strengthOfMagneticAnomaly {
			get {
				return _strengthOfMagneticAnomaly;
			}
			set {
				SetValue(ref _strengthOfMagneticAnomaly, value);
			}
		}

		[Browsable(false)]
		public strengthOfMagneticAnomaly[] strengthOfMagneticAnomalyList => [(strengthOfMagneticAnomaly)501,(strengthOfMagneticAnomaly)502,(strengthOfMagneticAnomaly)503,(strengthOfMagneticAnomaly)504];
		private int? _magneticIntensity  = default;

		public int? magneticIntensity {
			get {
				return _magneticIntensity;
			}
			set {
				SetValue(ref _magneticIntensity, value);
			}
		}
		private magneticAnomalyDetectorSignature _magneticAnomalyDetectorSignature ;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(magneticAnomalyDetectorSignatureList), typeof(magneticAnomalyDetectorSignature))]
		public magneticAnomalyDetectorSignature magneticAnomalyDetectorSignature {
			get {
				return _magneticAnomalyDetectorSignature;
			}
			set {
				SetValue(ref _magneticAnomalyDetectorSignature, value);
			}
		}

		[Browsable(false)]
		public magneticAnomalyDetectorSignature[] magneticAnomalyDetectorSignatureList => [(magneticAnomalyDetectorSignature)501,(magneticAnomalyDetectorSignature)502,(magneticAnomalyDetectorSignature)503,(magneticAnomalyDetectorSignature)504];


		public magneticInformationViewModel Load(magneticInformation instance) {
			strengthOfMagneticAnomaly = instance.strengthOfMagneticAnomaly;
			magneticIntensity = instance.magneticIntensity;
			magneticAnomalyDetectorSignature = instance.magneticAnomalyDetectorSignature;
			return this;
		}

		public override string Serialize() {
			var instance = new magneticInformation {
				strengthOfMagneticAnomaly = this.strengthOfMagneticAnomaly,
				magneticIntensity = this.magneticIntensity,
				magneticAnomalyDetectorSignature = this.magneticAnomalyDetectorSignature,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public magneticInformation Model => new () {
			strengthOfMagneticAnomaly = this._strengthOfMagneticAnomaly,
			magneticIntensity = this._magneticIntensity,
			magneticAnomalyDetectorSignature = this._magneticAnomalyDetectorSignature,
		};

		public override string? ToString() => $"Magnetic Information";
	}
	/// <summary>
	/// Rate of motion. The terms speed and velocity are often used interchangeably, but speed is a scalar, having magnitude only, while velocity is a vector quantity, having both magnitude and direction.
	/// </summary>
	[CategoryOrder("speed",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class speedViewModel : ViewModelBase {
		private decimal? _speedMinimum  = default;

		public decimal? speedMinimum {
			get {
				return _speedMinimum;
			}
			set {
				SetValue(ref _speedMinimum, value);
			}
		}
		private decimal _speedMaximum ;

		public decimal speedMaximum {
			get {
				return _speedMaximum;
			}
			set {
				SetValue(ref _speedMaximum, value);
			}
		}


		public speedViewModel Load(speed instance) {
			speedMinimum = instance.speedMinimum;
			speedMaximum = instance.speedMaximum;
			return this;
		}

		public override string Serialize() {
			var instance = new speed {
				speedMinimum = this.speedMinimum,
				speedMaximum = this.speedMaximum,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public speed Model => new () {
			speedMinimum = this._speedMinimum,
			speedMaximum = this._speedMaximum,
		};

		public override string? ToString() => $"Speed";
	}
	/// <summary>
	/// The vertical clearance measured from the horizontal plane towards a fixed (non-opening) feature overhead.
	/// </summary>
	[CategoryOrder("verticalClearanceFixed",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class verticalClearanceFixedViewModel : ViewModelBase {
		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Category("verticalClearanceFixed")]
		[ExpandableObject]
		public verticalUncertaintyViewModel? verticalUncertainty {
			get {
				return _verticalUncertainty;
			}
			set {
				SetValue(ref _verticalUncertainty, value);
			}
		}
		private decimal _verticalClearanceValue ;

		public decimal verticalClearanceValue {
			get {
				return _verticalClearanceValue;
			}
			set {
				SetValue(ref _verticalClearanceValue, value);
			}
		}


		public verticalClearanceFixedViewModel Load(verticalClearanceFixed instance) {
			verticalUncertainty = new ();
			if (instance.verticalUncertainty != default) {
				verticalUncertainty.Load(instance.verticalUncertainty);
			}
			verticalClearanceValue = instance.verticalClearanceValue;
			return this;
		}

		public override string Serialize() {
			var instance = new verticalClearanceFixed {
				verticalUncertainty = this.verticalUncertainty?.Model,
				verticalClearanceValue = this.verticalClearanceValue,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public verticalClearanceFixed Model => new () {
			verticalUncertainty = this._verticalUncertainty?.Model,
			verticalClearanceValue = this._verticalClearanceValue,
		};

		public override string? ToString() => $"Vertical Clearance Fixed";
	}
	/// <summary>
	/// A complex attribute that provides detailed information about the origin of a source, including the agency responsible for its production, the nation of origin, the type of source, and a unique identifier for the source.
	/// </summary>
	[CategoryOrder("sourceIdentification",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sourceIdentificationViewModel : ViewModelBase {
		private String? _producerNation  = default;

		public String? producerNation {
			get {
				return _producerNation;
			}
			set {
				SetValue(ref _producerNation, value);
			}
		}
		private String? _sourceType  = default;

		public String? sourceType {
			get {
				return _sourceType;
			}
			set {
				SetValue(ref _sourceType, value);
			}
		}
		private String? _productionAgency  = default;

		public String? productionAgency {
			get {
				return _productionAgency;
			}
			set {
				SetValue(ref _productionAgency, value);
			}
		}
		private String _sourceID  = string.Empty;

		public String sourceID {
			get {
				return _sourceID;
			}
			set {
				SetValue(ref _sourceID, value);
			}
		}


		public sourceIdentificationViewModel Load(sourceIdentification instance) {
			producerNation = instance.producerNation;
			sourceType = instance.sourceType;
			productionAgency = instance.productionAgency;
			sourceID = instance.sourceID;
			return this;
		}

		public override string Serialize() {
			var instance = new sourceIdentification {
				producerNation = this.producerNation,
				sourceType = this.sourceType,
				productionAgency = this.productionAgency,
				sourceID = this.sourceID,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public sourceIdentification Model => new () {
			producerNation = this._producerNation,
			sourceType = this._sourceType,
			productionAgency = this._productionAgency,
			sourceID = this._sourceID,
		};

		public override string? ToString() => $"Source Identification";
	}
	/// <summary>
	/// The best estimate of the accuracy of a position.
	/// </summary>
	[CategoryOrder("horizontalPositionUncertainty",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class horizontalPositionUncertaintyViewModel : ViewModelBase {
		private decimal _uncertaintyFixed ;

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
	/// Describes the characteristics of a light sector.
	/// </summary>
	[CategoryOrder("sectorCharacteristics",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorCharacteristicsViewModel : ViewModelBase {
		[Category("sectorCharacteristics")]
		public ObservableCollection<signalSequenceViewModel> signalSequence  { get; set; } = new ();
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
		public ObservableCollection<lightSectorViewModel> lightSector  { get; set; } = new ();
		private lightCharacteristic _lightCharacteristic ;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		public lightCharacteristic[] lightCharacteristicList => [(lightCharacteristic)1,(lightCharacteristic)2,(lightCharacteristic)3,(lightCharacteristic)4,(lightCharacteristic)5,(lightCharacteristic)6,(lightCharacteristic)7,(lightCharacteristic)8,(lightCharacteristic)11,(lightCharacteristic)12,(lightCharacteristic)13,(lightCharacteristic)14,(lightCharacteristic)15,(lightCharacteristic)16,(lightCharacteristic)17,(lightCharacteristic)18,(lightCharacteristic)19,(lightCharacteristic)25,(lightCharacteristic)26,(lightCharacteristic)27,(lightCharacteristic)28,(lightCharacteristic)29];
		[Category("sectorCharacteristics")]
		public ObservableCollection<String> signalGroup  { get; set; } = new ();


		public sectorCharacteristicsViewModel Load(sectorCharacteristics instance) {
			signalSequence.Clear();
			if (instance.signalSequence is not null) {
				foreach(var e in instance.signalSequence)
					signalSequence.Add(new signalSequenceViewModel().Load(e));
			}
			signalPeriod = instance.signalPeriod;
			lightSector.Clear();
			if (instance.lightSector is not null) {
				foreach(var e in instance.lightSector)
					lightSector.Add(new lightSectorViewModel().Load(e));
			}
			lightCharacteristic = instance.lightCharacteristic;
			signalGroup.Clear();
			if (instance.signalGroup is not null) {
				foreach(var e in instance.signalGroup)
					signalGroup.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new sectorCharacteristics {
				signalSequence = this.signalSequence.Select(e => e.Model).ToList(),
				signalPeriod = this.signalPeriod,
				lightSector = this.lightSector.Select(e => e.Model).ToList(),
				lightCharacteristic = this.lightCharacteristic,
				signalGroup = this.signalGroup.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public sectorCharacteristics Model => new () {
			signalSequence = this.signalSequence.Select(e => e.Model).ToList(),
			signalPeriod = this._signalPeriod,
			lightSector = this.lightSector.Select(e => e.Model).ToList(),
			lightCharacteristic = this._lightCharacteristic,
			signalGroup = this.signalGroup.ToList(),
		};

		public override string? ToString() => $"Sector Characteristics";

		public sectorCharacteristicsViewModel() : base() {
			signalSequence.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(signalSequence));
			};
			lightSector.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(lightSector));
			};
			signalGroup.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(signalGroup));
			};
		}
	}
	/// <summary>
	/// (1) The angular distance measured from true north to the major axis of the feature. (2) In ECDIS, the mode in which information on the ECDIS is being presented. Typical modes include: north-up - as shown on a nautical chart, north is at the top of the display; Ships head-up - based on the actual heading of the ship, (e.g. Ships gyrocompass); course-up display - based on the course or route being taken.
	/// </summary>
	[CategoryOrder("orientation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class orientationViewModel : ViewModelBase {
		private decimal _orientationValue ;

		public decimal orientationValue {
			get {
				return _orientationValue;
			}
			set {
				SetValue(ref _orientationValue, value);
			}
		}
		private decimal? _orientationUncertainty  = default;

		public decimal? orientationUncertainty {
			get {
				return _orientationUncertainty;
			}
			set {
				SetValue(ref _orientationUncertainty, value);
			}
		}


		public orientationViewModel Load(orientation instance) {
			orientationValue = instance.orientationValue;
			orientationUncertainty = instance.orientationUncertainty;
			return this;
		}

		public override string Serialize() {
			var instance = new orientation {
				orientationValue = this.orientationValue,
				orientationUncertainty = this.orientationUncertainty,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public orientation Model => new () {
			orientationValue = this._orientationValue,
			orientationUncertainty = this._orientationUncertainty,
		};

		public override string? ToString() => $"Orientation";
	}
	/// <summary>
	/// Indicates the the angular orientation from true north, often measured in degrees clockwise, along a specified route.
	/// </summary>
	[CategoryOrder("directionHeading",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class directionHeadingViewModel : ViewModelBase {
		private decimal _headingDownBearing ;

		public decimal headingDownBearing {
			get {
				return _headingDownBearing;
			}
			set {
				SetValue(ref _headingDownBearing, value);
			}
		}
		private decimal _headingUpBearing ;

		public decimal headingUpBearing {
			get {
				return _headingUpBearing;
			}
			set {
				SetValue(ref _headingUpBearing, value);
			}
		}


		public directionHeadingViewModel Load(directionHeading instance) {
			headingDownBearing = instance.headingDownBearing;
			headingUpBearing = instance.headingUpBearing;
			return this;
		}

		public override string Serialize() {
			var instance = new directionHeading {
				headingDownBearing = this.headingDownBearing,
				headingUpBearing = this.headingUpBearing,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public directionHeading Model => new () {
			headingDownBearing = this._headingDownBearing,
			headingUpBearing = this._headingUpBearing,
		};

		public override string? ToString() => $"Direction Heading";
	}
	/// <summary>
	/// The range of altitudes within which an object or aircraft operates, encompassing the highest and lowest points of constant atmospheric pressure in aviation, each separated from the next by a 500-foot interval, measured in relation to 1,013.2 hectopascals (hPa) or 29.92 inches of mercury.
	/// </summary>
	[CategoryOrder("flightLevel",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class flightLevelViewModel : ViewModelBase {
		private int _minimumFlightLevel ;

		public int minimumFlightLevel {
			get {
				return _minimumFlightLevel;
			}
			set {
				SetValue(ref _minimumFlightLevel, value);
			}
		}
		private int _maximumFlightLevel ;

		public int maximumFlightLevel {
			get {
				return _maximumFlightLevel;
			}
			set {
				SetValue(ref _maximumFlightLevel, value);
			}
		}


		public flightLevelViewModel Load(flightLevel instance) {
			minimumFlightLevel = instance.minimumFlightLevel;
			maximumFlightLevel = instance.maximumFlightLevel;
			return this;
		}

		public override string Serialize() {
			var instance = new flightLevel {
				minimumFlightLevel = this.minimumFlightLevel,
				maximumFlightLevel = this.maximumFlightLevel,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public flightLevel Model => new () {
			minimumFlightLevel = this._minimumFlightLevel,
			maximumFlightLevel = this._maximumFlightLevel,
		};

		public override string? ToString() => $"Flight Level ";
	}
	/// <summary>
	/// The maximum allowed rate of travel for a vessel in an area in knots.
	/// </summary>
	[CategoryOrder("vesselSpeedLimit",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class vesselSpeedLimitViewModel : ViewModelBase {
		private speedUnits _speedUnits ;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(speedUnitsList), typeof(speedUnits))]
		public speedUnits speedUnits {
			get {
				return _speedUnits;
			}
			set {
				SetValue(ref _speedUnits, value);
			}
		}

		[Browsable(false)]
		public speedUnits[] speedUnitsList => [(speedUnits)2,(speedUnits)3,(speedUnits)4];
		private String? _vesselClass  = default;

		public String? vesselClass {
			get {
				return _vesselClass;
			}
			set {
				SetValue(ref _vesselClass, value);
			}
		}
		private decimal _speedLimit ;

		public decimal speedLimit {
			get {
				return _speedLimit;
			}
			set {
				SetValue(ref _speedLimit, value);
			}
		}


		public vesselSpeedLimitViewModel Load(vesselSpeedLimit instance) {
			speedUnits = instance.speedUnits;
			vesselClass = instance.vesselClass;
			speedLimit = instance.speedLimit;
			return this;
		}

		public override string Serialize() {
			var instance = new vesselSpeedLimit {
				speedUnits = this.speedUnits,
				vesselClass = this.vesselClass,
				speedLimit = this.speedLimit,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public vesselSpeedLimit Model => new () {
			speedUnits = this._speedUnits,
			vesselClass = this._vesselClass,
			speedLimit = this._speedLimit,
		};

		public override string? ToString() => $"Vessel Speed Limit";
	}
	/// <summary>
	/// The active period of a recurring event or occurrence.
	/// </summary>
	[CategoryOrder("periodicDateRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class periodicDateRangeViewModel : ViewModelBase {
		private DateOnly _dateStart ;

		public DateOnly dateStart {
			get {
				return _dateStart;
			}
			set {
				SetValue(ref _dateStart, value);
			}
		}
		private DateOnly _dateEnd ;

		public DateOnly dateEnd {
			get {
				return _dateEnd;
			}
			set {
				SetValue(ref _dateEnd, value);
			}
		}
		private DateOnly _periodicDateEnd ;

		public DateOnly periodicDateEnd {
			get {
				return _periodicDateEnd;
			}
			set {
				SetValue(ref _periodicDateEnd, value);
			}
		}
		private DateOnly _periodicDateStart ;

		public DateOnly periodicDateStart {
			get {
				return _periodicDateStart;
			}
			set {
				SetValue(ref _periodicDateStart, value);
			}
		}


		public periodicDateRangeViewModel Load(periodicDateRange instance) {
			dateStart = instance.dateStart;
			dateEnd = instance.dateEnd;
			periodicDateEnd = instance.periodicDateEnd;
			periodicDateStart = instance.periodicDateStart;
			return this;
		}

		public override string Serialize() {
			var instance = new periodicDateRange {
				dateStart = this.dateStart,
				dateEnd = this.dateEnd,
				periodicDateEnd = this.periodicDateEnd,
				periodicDateStart = this.periodicDateStart,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public periodicDateRange Model => new () {
			dateStart = this._dateStart,
			dateEnd = this._dateEnd,
			periodicDateEnd = this._periodicDateEnd,
			periodicDateStart = this._periodicDateStart,
		};

		public override string? ToString() => $"Periodic Date Range";
	}
	/// <summary>
	/// Textual information about the shape of a non-standard topmark.
	/// </summary>
	[CategoryOrder("shapeInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class shapeInformationViewModel : ViewModelBase {
		private String _text  = string.Empty;

		public String text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
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


		public shapeInformationViewModel Load(shapeInformation instance) {
			text = instance.text;
			language = instance.language;
			return this;
		}

		public override string Serialize() {
			var instance = new shapeInformation {
				text = this.text,
				language = this.language,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public shapeInformation Model => new () {
			text = this._text,
			language = this._language,
		};

		public override string? ToString() => $"Shape Information";
	}
	/// <summary>
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference.
	/// </summary>
	[CategoryOrder("lightSector",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class lightSectorViewModel : ViewModelBase {
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
		[Category("lightSector")]
		public ObservableCollection<sectorInformationViewModel> sectorInformation  { get; set; } = new ();
		[Category("lightSector")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(lightVisibilityList), typeof(lightVisibility))]
		public ObservableCollection<lightVisibility> lightVisibility  { get; set; } = new ();

		[Browsable(false)]
		public lightVisibility[] lightVisibilityList => [(lightVisibility)1,(lightVisibility)2,(lightVisibility)3,(lightVisibility)4,(lightVisibility)5,(lightVisibility)6,(lightVisibility)8,(lightVisibility)9];
		private decimal? _valueOfNominalRange  = default;

		public decimal? valueOfNominalRange {
			get {
				return _valueOfNominalRange;
			}
			set {
				SetValue(ref _valueOfNominalRange, value);
			}
		}
		private Boolean? _sectorArcExtension  = default;

		public Boolean? sectorArcExtension {
			get {
				return _sectorArcExtension;
			}
			set {
				SetValue(ref _sectorArcExtension, value);
			}
		}
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
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)3,(colour)4,(colour)5,(colour)6,(colour)9,(colour)10,(colour)11];


		public lightSectorViewModel Load(lightSector instance) {
			sectorLimit = new ();
			if (instance.sectorLimit != default) {
				sectorLimit.Load(instance.sectorLimit);
			}
			sectorInformation.Clear();
			if (instance.sectorInformation is not null) {
				foreach(var e in instance.sectorInformation)
					sectorInformation.Add(new sectorInformationViewModel().Load(e));
			}
			lightVisibility.Clear();
			if (instance.lightVisibility is not null) {
				foreach(var e in instance.lightVisibility)
					lightVisibility.Add(e);
			}
			valueOfNominalRange = instance.valueOfNominalRange;
			sectorArcExtension = instance.sectorArcExtension;
			directionalCharacter = new ();
			if (instance.directionalCharacter != default) {
				directionalCharacter.Load(instance.directionalCharacter);
			}
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new lightSector {
				sectorLimit = this.sectorLimit?.Model,
				sectorInformation = this.sectorInformation.Select(e => e.Model).ToList(),
				lightVisibility = this.lightVisibility.ToList(),
				valueOfNominalRange = this.valueOfNominalRange,
				sectorArcExtension = this.sectorArcExtension,
				directionalCharacter = this.directionalCharacter?.Model,
				colour = this.colour.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public lightSector Model => new () {
			sectorLimit = this._sectorLimit?.Model,
			sectorInformation = this.sectorInformation.Select(e => e.Model).ToList(),
			lightVisibility = this.lightVisibility.ToList(),
			valueOfNominalRange = this._valueOfNominalRange,
			sectorArcExtension = this._sectorArcExtension,
			directionalCharacter = this._directionalCharacter?.Model,
			colour = this.colour.ToList(),
		};

		public override string? ToString() => $"Light Sector";

		public lightSectorViewModel() : base() {
			sectorInformation.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sectorInformation));
			};
			lightVisibility.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(lightVisibility));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
		}
	}
	/// <summary>
	/// The sequence of times occupied by intervals of light/sound and eclipse/silence for all “light characteristics” or sound signals.
	/// </summary>
	[CategoryOrder("signalSequence",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class signalSequenceViewModel : ViewModelBase {
		private signalStatus _signalStatus ;

		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		private decimal _signalDuration ;

		public decimal signalDuration {
			get {
				return _signalDuration;
			}
			set {
				SetValue(ref _signalDuration, value);
			}
		}


		public signalSequenceViewModel Load(signalSequence instance) {
			signalStatus = instance.signalStatus;
			signalDuration = instance.signalDuration;
			return this;
		}

		public override string Serialize() {
			var instance = new signalSequence {
				signalStatus = this.signalStatus,
				signalDuration = this.signalDuration,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public signalSequence Model => new () {
			signalStatus = this._signalStatus,
			signalDuration = this._signalDuration,
		};

		public override string? ToString() => $"Signal Sequence";
	}
	/// <summary>
	/// Additional textual information about a light sector.
	/// </summary>
	[CategoryOrder("sectorInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorInformationViewModel : ViewModelBase {
		private String _text  = string.Empty;

		public String text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
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


		public sectorInformationViewModel Load(sectorInformation instance) {
			text = instance.text;
			language = instance.language;
			return this;
		}

		public override string Serialize() {
			var instance = new sectorInformation {
				text = this.text,
				language = this.language,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public sectorInformation Model => new () {
			text = this._text,
			language = this._language,
		};

		public override string? ToString() => $"Sector Information";
	}
	/// <summary>
	/// A directional light is a light illuminating a sector of very narrow angle and intended to mark a direction to follow.
	/// </summary>
	[CategoryOrder("directionalCharacter",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class directionalCharacterViewModel : ViewModelBase {
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
		private Boolean? _moireEffect  = default;

		public Boolean? moireEffect {
			get {
				return _moireEffect;
			}
			set {
				SetValue(ref _moireEffect, value);
			}
		}


		public directionalCharacterViewModel Load(directionalCharacter instance) {
			orientation = new ();
			if (instance.orientation != default) {
				orientation.Load(instance.orientation);
			}
			moireEffect = instance.moireEffect;
			return this;
		}

		public override string Serialize() {
			var instance = new directionalCharacter {
				orientation = this.orientation?.Model,
				moireEffect = this.moireEffect,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public directionalCharacter Model => new () {
			orientation = this._orientation?.Model,
			moireEffect = this._moireEffect,
		};

		public override string? ToString() => $"Directional Character";
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
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit two specifies the second limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).
	/// </summary>
	[CategoryOrder("sectorLimitTwo",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorLimitTwoViewModel : ViewModelBase {
		private decimal? _sectorLineLength  = default;

		public decimal? sectorLineLength {
			get {
				return _sectorLineLength;
			}
			set {
				SetValue(ref _sectorLineLength, value);
			}
		}
		private decimal _sectorBearing ;

		public decimal sectorBearing {
			get {
				return _sectorBearing;
			}
			set {
				SetValue(ref _sectorBearing, value);
			}
		}


		public sectorLimitTwoViewModel Load(sectorLimitTwo instance) {
			sectorLineLength = instance.sectorLineLength;
			sectorBearing = instance.sectorBearing;
			return this;
		}

		public override string Serialize() {
			var instance = new sectorLimitTwo {
				sectorLineLength = this.sectorLineLength,
				sectorBearing = this.sectorBearing,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public sectorLimitTwo Model => new () {
			sectorLineLength = this._sectorLineLength,
			sectorBearing = this._sectorBearing,
		};

		public override string? ToString() => $"Sector Limit Two";
	}
	/// <summary>
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit one specifies the first limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).
	/// </summary>
	[CategoryOrder("sectorLimitOne",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorLimitOneViewModel : ViewModelBase {
		private decimal? _sectorLineLength  = default;

		public decimal? sectorLineLength {
			get {
				return _sectorLineLength;
			}
			set {
				SetValue(ref _sectorLineLength, value);
			}
		}
		private decimal _sectorBearing ;

		public decimal sectorBearing {
			get {
				return _sectorBearing;
			}
			set {
				SetValue(ref _sectorBearing, value);
			}
		}


		public sectorLimitOneViewModel Load(sectorLimitOne instance) {
			sectorLineLength = instance.sectorLineLength;
			sectorBearing = instance.sectorBearing;
			return this;
		}

		public override string Serialize() {
			var instance = new sectorLimitOne {
				sectorLineLength = this.sectorLineLength,
				sectorBearing = this.sectorBearing,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public sectorLimitOne Model => new () {
			sectorLineLength = this._sectorLineLength,
			sectorBearing = this._sectorBearing,
		};

		public override string? ToString() => $"Sector Limit One";
	}



	/// <summary>
	/// ReferenceToAPublication (missing definition)
	/// </summary>
	[CategoryOrder("ReferenceToAPublication",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ReferenceToAPublicationViewModel : InformationViewModel<ReferenceToAPublication> {
		private DateOnly? _editionDate  = default;

		[Category("ReferenceToAPublication")]
		public DateOnly? editionDate {
			get {
				return _editionDate;
			}
			set {
				SetValue(ref _editionDate, value);
			}
		}
		private String? _editionNumber  = default;

		[Category("ReferenceToAPublication")]
		public String? editionNumber {
			get {
				return _editionNumber;
			}
			set {
				SetValue(ref _editionNumber, value);
			}
		}
		[Category("ReferenceToAPublication")]
		public ObservableCollection<onlineResourceViewModel> onlineResource  { get; set; } = new ();
		[Category("ReferenceToAPublication")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override InformationViewModel<ReferenceToAPublication> Load(ReferenceToAPublication instance) {
			editionDate = instance.editionDate;
			editionNumber = instance.editionNumber;
			onlineResource.Clear();
			if (instance.onlineResource is not null) {
				foreach(var e in instance.onlineResource)
					onlineResource.Add(new onlineResourceViewModel().Load(e));
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new ReferenceToAPublication {
				editionDate = this.editionDate,
				editionNumber = this.editionNumber,
				onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ReferenceToAPublication Model => new () {
			editionDate = this._editionDate,
			editionNumber = this._editionNumber,
			onlineResource = this.onlineResource.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => ReferenceToAPublication._informationBindingDefinitions;

		public override string? ToString() => $"ReferenceToAPublication (missing Name)";

		public ReferenceToAPublicationViewModel() : base() {
			onlineResource.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(onlineResource));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// An installation buoy is a buoy used for loading tankers with gas or oil.
	/// </summary>
	[CategoryOrder("InstallationBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class InstallationBuoyViewModel : FeatureViewModel<InstallationBuoy> {
		[Category("InstallationBuoy")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private colourPattern? _colourPattern  = default;

		[Category("InstallationBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public colourPattern? colourPattern {
			get {
				return _colourPattern;
			}
			set {
				SetValue(ref _colourPattern, value);
			}
		}

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6];
		[Category("InstallationBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(productList), typeof(product))]
		public ObservableCollection<product> product  { get; set; } = new ();

		[Browsable(false)]
		public product[] productList => [(product)1,(product)2,(product)18,(product)19];
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InstallationBuoy")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("InstallationBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)18];
		private visualProminence? _visualProminence  = default;

		[Category("InstallationBuoy")]
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
		[Category("InstallationBuoy")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("InstallationBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		private int? _scaleMinimum  = default;

		[Category("InstallationBuoy")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("InstallationBuoy")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		private String? _pictorialRepresentation  = default;

		[Category("InstallationBuoy")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private buoyShape _buoyShape ;

		[Category("InstallationBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		private String? _interoperabilityIdentifier  = default;

		[Category("InstallationBuoy")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("InstallationBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)7,(natureOfConstruction)11];
		private Boolean? _radarConspicuous  = default;

		[Category("InstallationBuoy")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		private categoryOfInstallationBuoy? _categoryOfInstallationBuoy  = default;

		[Category("InstallationBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfInstallationBuoyList), typeof(categoryOfInstallationBuoy))]
		public categoryOfInstallationBuoy? categoryOfInstallationBuoy {
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
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			colourPattern = instance.colourPattern;
			product.Clear();
			if (instance.product is not null) {
				foreach(var e in instance.product)
					product.Add(e);
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			visualProminence = instance.visualProminence;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			scaleMinimum = instance.scaleMinimum;
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			pictorialRepresentation = instance.pictorialRepresentation;
			buoyShape = instance.buoyShape;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			categoryOfInstallationBuoy = instance.categoryOfInstallationBuoy;
			return this;
		}

		public override string Serialize() {
			var instance = new InstallationBuoy {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				colourPattern = this.colourPattern,
				product = this.product.ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				status = this.status.ToList(),
				visualProminence = this.visualProminence,
				information = this.information.Select(e => e.Model).ToList(),
				colour = this.colour.ToList(),
				scaleMinimum = this.scaleMinimum,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				pictorialRepresentation = this.pictorialRepresentation,
				buoyShape = this.buoyShape,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous,
				categoryOfInstallationBuoy = this.categoryOfInstallationBuoy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public InstallationBuoy Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			colourPattern = this._colourPattern,
			product = this.product.ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			status = this.status.ToList(),
			visualProminence = this._visualProminence,
			information = this.information.Select(e => e.Model).ToList(),
			colour = this.colour.ToList(),
			scaleMinimum = this._scaleMinimum,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			pictorialRepresentation = this._pictorialRepresentation,
			buoyShape = this._buoyShape,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this._radarConspicuous,
			categoryOfInstallationBuoy = this._categoryOfInstallationBuoy,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => InstallationBuoy._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => InstallationBuoy._featureBindingDefinitions;

		public override string? ToString() => $"Installation Buoy";

		public InstallationBuoyViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			product.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(product));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
		}
	}

	/// <summary>
	/// A water area whose depth is within a defined range of values.
	/// </summary>
	[CategoryOrder("DepthArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DepthAreaViewModel : FeatureViewModel<DepthArea> {
		private decimal _depthRangeMaximumValue ;

		[Category("DepthArea")]
		public decimal depthRangeMaximumValue {
			get {
				return _depthRangeMaximumValue;
			}
			set {
				SetValue(ref _depthRangeMaximumValue, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		[Category("DepthArea")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("DepthArea")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private decimal _depthRangeMinimumValue ;

		[Category("DepthArea")]
		public decimal depthRangeMinimumValue {
			get {
				return _depthRangeMinimumValue;
			}
			set {
				SetValue(ref _depthRangeMinimumValue, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("DepthArea")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}


		public override FeatureViewModel<DepthArea> Load(DepthArea instance) {
			depthRangeMaximumValue = instance.depthRangeMaximumValue;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			depthRangeMinimumValue = instance.depthRangeMinimumValue;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new DepthArea {
				depthRangeMaximumValue = this.depthRangeMaximumValue,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				depthRangeMinimumValue = this.depthRangeMinimumValue,
				sourceIdentification = this.sourceIdentification?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DepthArea Model => new () {
			depthRangeMaximumValue = this._depthRangeMaximumValue,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			depthRangeMinimumValue = this._depthRangeMinimumValue,
			sourceIdentification = this._sourceIdentification?.Model,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => DepthArea._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => DepthArea._featureBindingDefinitions;

		public override string? ToString() => $"Depth Area";

		public DepthAreaViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
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
		private categoryOfReportingRadioCallingInPoint? _categoryOfReportingRadioCallingInPoint  = default;

		[Category("RadioCallingInPoint")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfReportingRadioCallingInPointList), typeof(categoryOfReportingRadioCallingInPoint))]
		public categoryOfReportingRadioCallingInPoint? categoryOfReportingRadioCallingInPoint {
			get {
				return _categoryOfReportingRadioCallingInPoint;
			}
			set {
				SetValue(ref _categoryOfReportingRadioCallingInPoint, value);
			}
		}

		[Browsable(false)]
		public categoryOfReportingRadioCallingInPoint[] categoryOfReportingRadioCallingInPointList => [(categoryOfReportingRadioCallingInPoint)501];
		[Category("RadioCallingInPoint")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("RadioCallingInPoint")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("RadioCallingInPoint")]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();
		[Category("RadioCallingInPoint")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		private String? _interoperabilityIdentifier  = default;

		[Category("RadioCallingInPoint")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("RadioCallingInPoint")]
		public ObservableCollection<decimal> orientationValue  { get; set; } = new ();
		[Category("RadioCallingInPoint")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)3,(status)4,(status)5,(status)6,(status)7,(status)9,(status)501];
		[Category("RadioCallingInPoint")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("RadioCallingInPoint")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private trafficFlow _trafficFlow ;

		[Category("RadioCallingInPoint")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
			categoryOfReportingRadioCallingInPoint = instance.categoryOfReportingRadioCallingInPoint;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			communicationChannel.Clear();
			if (instance.communicationChannel is not null) {
				foreach(var e in instance.communicationChannel)
					communicationChannel.Add(e);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			trafficFlow = instance.trafficFlow;
			return this;
		}

		public override string Serialize() {
			var instance = new RadioCallingInPoint {
				categoryOfReportingRadioCallingInPoint = this.categoryOfReportingRadioCallingInPoint,
				information = this.information.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				communicationChannel = this.communicationChannel.ToList(),
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				orientationValue = this.orientationValue.ToList(),
				status = this.status.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				trafficFlow = this.trafficFlow,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RadioCallingInPoint Model => new () {
			categoryOfReportingRadioCallingInPoint = this._categoryOfReportingRadioCallingInPoint,
			information = this.information.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			communicationChannel = this.communicationChannel.ToList(),
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			orientationValue = this.orientationValue.ToList(),
			status = this.status.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			trafficFlow = this._trafficFlow,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => RadioCallingInPoint._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => RadioCallingInPoint._featureBindingDefinitions;

		public override string? ToString() => $"Radio Calling-In Point";

		public RadioCallingInPointViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(communicationChannel));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			orientationValue.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(orientationValue));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// A defined area on land or over water which is patrolled by a controlling or regulatory authority.
	/// </summary>
	[CategoryOrder("PatrolArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PatrolAreaViewModel : FeatureViewModel<PatrolArea> {
		private String? _agencyResponsibleForProduction  = default;

		[Category("PatrolArea")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("PatrolArea")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private String? _nationality  = default;

		[Category("PatrolArea")]
		public String? nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}
		private String? _controllingAuthority  = default;

		[Category("PatrolArea")]
		public String? controllingAuthority {
			get {
				return _controllingAuthority;
			}
			set {
				SetValue(ref _controllingAuthority, value);
			}
		}
		private categoryOfPatrolArea _categoryOfPatrolArea ;

		[Category("PatrolArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfPatrolAreaList), typeof(categoryOfPatrolArea))]
		public categoryOfPatrolArea categoryOfPatrolArea {
			get {
				return _categoryOfPatrolArea;
			}
			set {
				SetValue(ref _categoryOfPatrolArea, value);
			}
		}

		[Browsable(false)]
		public categoryOfPatrolArea[] categoryOfPatrolAreaList => [(categoryOfPatrolArea)501,(categoryOfPatrolArea)502];
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("PatrolArea")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		[Category("PatrolArea")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("PatrolArea")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("PatrolArea")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)501];


		public override FeatureViewModel<PatrolArea> Load(PatrolArea instance) {
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			reportedDate = instance.reportedDate;
			nationality = instance.nationality;
			controllingAuthority = instance.controllingAuthority;
			categoryOfPatrolArea = instance.categoryOfPatrolArea;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
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
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new PatrolArea {
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				reportedDate = this.reportedDate,
				nationality = this.nationality,
				controllingAuthority = this.controllingAuthority,
				categoryOfPatrolArea = this.categoryOfPatrolArea,
				sourceIdentification = this.sourceIdentification?.Model,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public PatrolArea Model => new () {
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			reportedDate = this._reportedDate,
			nationality = this._nationality,
			controllingAuthority = this._controllingAuthority,
			categoryOfPatrolArea = this._categoryOfPatrolArea,
			sourceIdentification = this._sourceIdentification?.Model,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			status = this.status.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => PatrolArea._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => PatrolArea._featureBindingDefinitions;

		public override string? ToString() => $"Patrol Area";

		public PatrolAreaViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}

	/// <summary>
	/// An official location at which to register, declare and/or inspect goods and/or people.
	/// </summary>
	[CategoryOrder("Checkpoint",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CheckpointViewModel : FeatureViewModel<Checkpoint> {
		private String? _controllingAuthority  = default;

		[Category("Checkpoint")]
		public String? controllingAuthority {
			get {
				return _controllingAuthority;
			}
			set {
				SetValue(ref _controllingAuthority, value);
			}
		}
		[Category("Checkpoint")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private String? _agencyResponsibleForProduction  = default;

		[Category("Checkpoint")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		[Category("Checkpoint")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)5,(status)7,(status)9,(status)12];
		[Category("Checkpoint")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private String? _interoperabilityIdentifier  = default;

		[Category("Checkpoint")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("Checkpoint")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private categoryOfCheckpoint? _categoryOfCheckpoint  = default;

		[Category("Checkpoint")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfCheckpointList), typeof(categoryOfCheckpoint))]
		public categoryOfCheckpoint? categoryOfCheckpoint {
			get {
				return _categoryOfCheckpoint;
			}
			set {
				SetValue(ref _categoryOfCheckpoint, value);
			}
		}

		[Browsable(false)]
		public categoryOfCheckpoint[] categoryOfCheckpointList => [(categoryOfCheckpoint)1,(categoryOfCheckpoint)501];


		public override FeatureViewModel<Checkpoint> Load(Checkpoint instance) {
			controllingAuthority = instance.controllingAuthority;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			scaleMinimum = instance.scaleMinimum;
			categoryOfCheckpoint = instance.categoryOfCheckpoint;
			return this;
		}

		public override string Serialize() {
			var instance = new Checkpoint {
				controllingAuthority = this.controllingAuthority,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				status = this.status.ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				scaleMinimum = this.scaleMinimum,
				categoryOfCheckpoint = this.categoryOfCheckpoint,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Checkpoint Model => new () {
			controllingAuthority = this._controllingAuthority,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			status = this.status.ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			scaleMinimum = this._scaleMinimum,
			categoryOfCheckpoint = this._categoryOfCheckpoint,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => Checkpoint._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => Checkpoint._featureBindingDefinitions;

		public override string? ToString() => $"Checkpoint";

		public CheckpointViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// An area which is managed and/or monitored by a controlling authority to protect the marine environment and ensure restrictions applicable to that area, or marine activities carried out within the area conform to current legislation/regulations.
	/// </summary>
	[CategoryOrder("MarineManagementArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class MarineManagementAreaViewModel : FeatureViewModel<MarineManagementArea> {
		private restriction? _restriction  = default;

		[Category("MarineManagementArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(restrictionList), typeof(restriction))]
		public restriction? restriction {
			get {
				return _restriction;
			}
			set {
				SetValue(ref _restriction, value);
			}
		}

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)7,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)14,(restriction)15,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)26,(restriction)27];
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("MarineManagementArea")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		[Category("MarineManagementArea")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(speciesGroupingList), typeof(speciesGrouping))]
		public ObservableCollection<speciesGrouping> speciesGrouping  { get; set; } = new ();

		[Browsable(false)]
		public speciesGrouping[] speciesGroupingList => [(speciesGrouping)501,(speciesGrouping)502,(speciesGrouping)503,(speciesGrouping)504,(speciesGrouping)505,(speciesGrouping)506,(speciesGrouping)507,(speciesGrouping)508,(speciesGrouping)509,(speciesGrouping)510];
		[Category("MarineManagementArea")]
		public ObservableCollection<String> nationalMaritimeAuthority  { get; set; } = new ();
		private jurisdiction _jurisdiction ;

		[Category("MarineManagementArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(jurisdictionList), typeof(jurisdiction))]
		public jurisdiction jurisdiction {
			get {
				return _jurisdiction;
			}
			set {
				SetValue(ref _jurisdiction, value);
			}
		}

		[Browsable(false)]
		public jurisdiction[] jurisdictionList => [(jurisdiction)1,(jurisdiction)2,(jurisdiction)2];
		[Category("MarineManagementArea")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private categoryofMarineProtectedArea? _categoryofMarineProtectedArea  = default;

		[Category("MarineManagementArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryofMarineProtectedAreaList), typeof(categoryofMarineProtectedArea))]
		public categoryofMarineProtectedArea? categoryofMarineProtectedArea {
			get {
				return _categoryofMarineProtectedArea;
			}
			set {
				SetValue(ref _categoryofMarineProtectedArea, value);
			}
		}

		[Browsable(false)]
		public categoryofMarineProtectedArea[] categoryofMarineProtectedAreaList => [(categoryofMarineProtectedArea)1,(categoryofMarineProtectedArea)2,(categoryofMarineProtectedArea)3,(categoryofMarineProtectedArea)4,(categoryofMarineProtectedArea)5,(categoryofMarineProtectedArea)6,(categoryofMarineProtectedArea)7];
		private DateOnly? _reportedDate  = default;

		[Category("MarineManagementArea")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private String? _agencyResponsibleForProduction  = default;

		[Category("MarineManagementArea")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		[Category("MarineManagementArea")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private String? _controllingAuthority  = default;

		[Category("MarineManagementArea")]
		public String? controllingAuthority {
			get {
				return _controllingAuthority;
			}
			set {
				SetValue(ref _controllingAuthority, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("MarineManagementArea")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private status? _status  = default;

		[Category("MarineManagementArea")]
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
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)13,(status)14,(status)16,(status)17,(status)519];
		[Category("MarineManagementArea")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryofRestrictionsList), typeof(categoryofRestrictions))]
		public ObservableCollection<categoryofRestrictions> categoryofRestrictions  { get; set; } = new ();

		[Browsable(false)]
		public categoryofRestrictions[] categoryofRestrictionsList => [(categoryofRestrictions)4,(categoryofRestrictions)5,(categoryofRestrictions)6,(categoryofRestrictions)7,(categoryofRestrictions)10,(categoryofRestrictions)20,(categoryofRestrictions)22,(categoryofRestrictions)23,(categoryofRestrictions)27,(categoryofRestrictions)28,(categoryofRestrictions)31,(categoryofRestrictions)32];
		[Category("MarineManagementArea")]
		public ObservableCollection<String> species  { get; set; } = new ();


		public override FeatureViewModel<MarineManagementArea> Load(MarineManagementArea instance) {
			restriction = instance.restriction;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			speciesGrouping.Clear();
			if (instance.speciesGrouping is not null) {
				foreach(var e in instance.speciesGrouping)
					speciesGrouping.Add(e);
			}
			nationalMaritimeAuthority.Clear();
			if (instance.nationalMaritimeAuthority is not null) {
				foreach(var e in instance.nationalMaritimeAuthority)
					nationalMaritimeAuthority.Add(e);
			}
			jurisdiction = instance.jurisdiction;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			categoryofMarineProtectedArea = instance.categoryofMarineProtectedArea;
			reportedDate = instance.reportedDate;
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			controllingAuthority = instance.controllingAuthority;
			pictorialRepresentation = instance.pictorialRepresentation;
			status = instance.status;
			categoryofRestrictions.Clear();
			if (instance.categoryofRestrictions is not null) {
				foreach(var e in instance.categoryofRestrictions)
					categoryofRestrictions.Add(e);
			}
			species.Clear();
			if (instance.species is not null) {
				foreach(var e in instance.species)
					species.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new MarineManagementArea {
				restriction = this.restriction,
				sourceIdentification = this.sourceIdentification?.Model,
				speciesGrouping = this.speciesGrouping.ToList(),
				nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
				jurisdiction = this.jurisdiction,
				information = this.information.Select(e => e.Model).ToList(),
				categoryofMarineProtectedArea = this.categoryofMarineProtectedArea,
				reportedDate = this.reportedDate,
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				controllingAuthority = this.controllingAuthority,
				pictorialRepresentation = this.pictorialRepresentation,
				status = this.status,
				categoryofRestrictions = this.categoryofRestrictions.ToList(),
				species = this.species.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public MarineManagementArea Model => new () {
			restriction = this._restriction,
			sourceIdentification = this._sourceIdentification?.Model,
			speciesGrouping = this.speciesGrouping.ToList(),
			nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
			jurisdiction = this._jurisdiction,
			information = this.information.Select(e => e.Model).ToList(),
			categoryofMarineProtectedArea = this._categoryofMarineProtectedArea,
			reportedDate = this._reportedDate,
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			controllingAuthority = this._controllingAuthority,
			pictorialRepresentation = this._pictorialRepresentation,
			status = this._status,
			categoryofRestrictions = this.categoryofRestrictions.ToList(),
			species = this.species.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => MarineManagementArea._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => MarineManagementArea._featureBindingDefinitions;

		public override string? ToString() => $"Marine Management Area";

		public MarineManagementAreaViewModel() : base() {
			speciesGrouping.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(speciesGrouping));
			};
			nationalMaritimeAuthority.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(nationalMaritimeAuthority));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			categoryofRestrictions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryofRestrictions));
			};
			species.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(species));
			};
		}
	}

	/// <summary>
	/// A line connecting points of equal water depth which is sometimes significantly displaced outside of soundings, symbols, and other chart detail for clarity as well as generalization. Depth contours therefore often represent an approximate location of the line of equal depth as related to the surveyed line delineated on the source.
	/// </summary>
	[CategoryOrder("DepthContour",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DepthContourViewModel : FeatureViewModel<DepthContour> {
		[Category("DepthContour")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Category("DepthContour")]
		[ExpandableObject]
		public verticalUncertaintyViewModel? verticalUncertainty {
			get {
				return _verticalUncertainty;
			}
			set {
				SetValue(ref _verticalUncertainty, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("DepthContour")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private decimal _valueOfDepthContour ;

		[Category("DepthContour")]
		public decimal valueOfDepthContour {
			get {
				return _valueOfDepthContour;
			}
			set {
				SetValue(ref _valueOfDepthContour, value);
			}
		}
		private String? _agencyResponsibleForProduction  = default;

		[Category("DepthContour")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		[Category("DepthContour")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("DepthContour")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}


		public override FeatureViewModel<DepthContour> Load(DepthContour instance) {
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			verticalUncertainty = new ();
			if (instance.verticalUncertainty != default) {
				verticalUncertainty.Load(instance.verticalUncertainty);
			}
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			valueOfDepthContour = instance.valueOfDepthContour;
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			scaleMinimum = instance.scaleMinimum;
			return this;
		}

		public override string Serialize() {
			var instance = new DepthContour {
				information = this.information.Select(e => e.Model).ToList(),
				verticalUncertainty = this.verticalUncertainty?.Model,
				sourceIdentification = this.sourceIdentification?.Model,
				valueOfDepthContour = this.valueOfDepthContour,
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				scaleMinimum = this.scaleMinimum,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DepthContour Model => new () {
			information = this.information.Select(e => e.Model).ToList(),
			verticalUncertainty = this._verticalUncertainty?.Model,
			sourceIdentification = this._sourceIdentification?.Model,
			valueOfDepthContour = this._valueOfDepthContour,
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			scaleMinimum = this._scaleMinimum,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => DepthContour._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => DepthContour._featureBindingDefinitions;

		public override string? ToString() => $"Depth Contour";

		public DepthContourViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// A generic term which may be used to describe a wide range of areas, considered sensitive for a variety of environmental reasons.
	/// </summary>
	[CategoryOrder("EnvironmentallySensitiveSeaArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class EnvironmentallySensitiveSeaAreaViewModel : FeatureViewModel<EnvironmentallySensitiveSeaArea> {
		[Category("EnvironmentallySensitiveSeaArea")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private String? _controllingAuthority  = default;

		[Category("EnvironmentallySensitiveSeaArea")]
		public String? controllingAuthority {
			get {
				return _controllingAuthority;
			}
			set {
				SetValue(ref _controllingAuthority, value);
			}
		}
		[Category("EnvironmentallySensitiveSeaArea")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override FeatureViewModel<EnvironmentallySensitiveSeaArea> Load(EnvironmentallySensitiveSeaArea instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			controllingAuthority = instance.controllingAuthority;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new EnvironmentallySensitiveSeaArea {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				controllingAuthority = this.controllingAuthority,
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public EnvironmentallySensitiveSeaArea Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			controllingAuthority = this._controllingAuthority,
			information = this.information.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => EnvironmentallySensitiveSeaArea._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => EnvironmentallySensitiveSeaArea._featureBindingDefinitions;

		public override string? ToString() => $"Environmentally Sensitive Sea Area";

		public EnvironmentallySensitiveSeaAreaViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// A route with a specially prepared surface that is intended for use by wheeled vehicles or pedestrians.
	/// </summary>
	[CategoryOrder("Road",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RoadViewModel : FeatureViewModel<Road> {
		[Category("Road")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)4,(natureOfConstruction)5];
		[Category("Road")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private String? _pictorialRepresentation  = default;

		[Category("Road")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("Road")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private categoryOfRoad? _categoryOfRoad  = default;

		[Category("Road")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfRoadList), typeof(categoryOfRoad))]
		public categoryOfRoad? categoryOfRoad {
			get {
				return _categoryOfRoad;
			}
			set {
				SetValue(ref _categoryOfRoad, value);
			}
		}

		[Browsable(false)]
		public categoryOfRoad[] categoryOfRoadList => [(categoryOfRoad)1,(categoryOfRoad)2,(categoryOfRoad)3,(categoryOfRoad)4,(categoryOfRoad)5,(categoryOfRoad)6];
		private condition? _condition  = default;

		[Category("Road")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)5,(condition)501];
		private String? _interoperabilityIdentifier  = default;

		[Category("Road")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("Road")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("Road")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)4,(status)6,(status)7,(status)8,(status)12,(status)13,(status)14];
		private int? _scaleMinimum  = default;

		[Category("Road")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}


		public override FeatureViewModel<Road> Load(Road instance) {
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			pictorialRepresentation = instance.pictorialRepresentation;
			reportedDate = instance.reportedDate;
			categoryOfRoad = instance.categoryOfRoad;
			condition = instance.condition;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			scaleMinimum = instance.scaleMinimum;
			return this;
		}

		public override string Serialize() {
			var instance = new Road {
				natureOfConstruction = this.natureOfConstruction.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				pictorialRepresentation = this.pictorialRepresentation,
				reportedDate = this.reportedDate,
				categoryOfRoad = this.categoryOfRoad,
				condition = this.condition,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				status = this.status.ToList(),
				scaleMinimum = this.scaleMinimum,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Road Model => new () {
			natureOfConstruction = this.natureOfConstruction.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			pictorialRepresentation = this._pictorialRepresentation,
			reportedDate = this._reportedDate,
			categoryOfRoad = this._categoryOfRoad,
			condition = this._condition,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			status = this.status.ToList(),
			scaleMinimum = this._scaleMinimum,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => Road._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => Road._featureBindingDefinitions;

		public override string? ToString() => $"Road";

		public RoadViewModel() : base() {
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}

	/// <summary>
	/// A relatively large natural stream of water.
	/// </summary>
	[CategoryOrder("River",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RiverViewModel : FeatureViewModel<River> {
		private int? _scaleMinimum  = default;

		[Category("River")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("River")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("River")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)5];
		private String? _interoperabilityIdentifier  = default;

		[Category("River")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("River")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override FeatureViewModel<River> Load(River instance) {
			scaleMinimum = instance.scaleMinimum;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new River {
				scaleMinimum = this.scaleMinimum,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				status = this.status.ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public River Model => new () {
			scaleMinimum = this._scaleMinimum,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			status = this.status.ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => River._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => River._featureBindingDefinitions;

		public override string? ToString() => $"River";

		public RiverViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// An area within which naval, military or aerial exercises are carried out.
	/// </summary>
	[CategoryOrder("MilitaryPracticeArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class MilitaryPracticeAreaViewModel : FeatureViewModel<MilitaryPracticeArea> {
		private altitudeRangeViewModel? _altitudeRange  = default;

		[Category("MilitaryPracticeArea")]
		[ExpandableObject]
		public altitudeRangeViewModel? altitudeRange {
			get {
				return _altitudeRange;
			}
			set {
				SetValue(ref _altitudeRange, value);
			}
		}
		private String _depthRestriction  = string.Empty;

		[Category("MilitaryPracticeArea")]
		public String depthRestriction {
			get {
				return _depthRestriction;
			}
			set {
				SetValue(ref _depthRestriction, value);
			}
		}
		private depthUnits? _depthUnits  = default;

		[Category("MilitaryPracticeArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(depthUnitsList), typeof(depthUnits))]
		public depthUnits? depthUnits {
			get {
				return _depthUnits;
			}
			set {
				SetValue(ref _depthUnits, value);
			}
		}

		[Browsable(false)]
		public depthUnits[] depthUnitsList => [(depthUnits)1];
		[Category("MilitaryPracticeArea")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
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
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(restrictionList), typeof(restriction))]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)7,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)15,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)26,(restriction)27,(restriction)39];
		private int? _scaleMinimum  = default;

		[Category("MilitaryPracticeArea")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("MilitaryPracticeArea")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("MilitaryPracticeArea")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(typeofMilitaryActivityList), typeof(typeofMilitaryActivity))]
		public ObservableCollection<typeofMilitaryActivity> typeofMilitaryActivity  { get; set; } = new ();

		[Browsable(false)]
		public typeofMilitaryActivity[] typeofMilitaryActivityList => [(typeofMilitaryActivity)501,(typeofMilitaryActivity)502,(typeofMilitaryActivity)503,(typeofMilitaryActivity)504,(typeofMilitaryActivity)505,(typeofMilitaryActivity)506,(typeofMilitaryActivity)507,(typeofMilitaryActivity)508,(typeofMilitaryActivity)509,(typeofMilitaryActivity)510,(typeofMilitaryActivity)511,(typeofMilitaryActivity)512,(typeofMilitaryActivity)513,(typeofMilitaryActivity)514,(typeofMilitaryActivity)515,(typeofMilitaryActivity)516,(typeofMilitaryActivity)517,(typeofMilitaryActivity)518,(typeofMilitaryActivity)519,(typeofMilitaryActivity)520,(typeofMilitaryActivity)521,(typeofMilitaryActivity)522,(typeofMilitaryActivity)523,(typeofMilitaryActivity)524,(typeofMilitaryActivity)525,(typeofMilitaryActivity)526,(typeofMilitaryActivity)527,(typeofMilitaryActivity)528,(typeofMilitaryActivity)529,(typeofMilitaryActivity)530,(typeofMilitaryActivity)531,(typeofMilitaryActivity)532,(typeofMilitaryActivity)533,(typeofMilitaryActivity)534,(typeofMilitaryActivity)535,(typeofMilitaryActivity)536,(typeofMilitaryActivity)537,(typeofMilitaryActivity)538,(typeofMilitaryActivity)539,(typeofMilitaryActivity)540,(typeofMilitaryActivity)541,(typeofMilitaryActivity)542,(typeofMilitaryActivity)543,(typeofMilitaryActivity)544,(typeofMilitaryActivity)545,(typeofMilitaryActivity)546,(typeofMilitaryActivity)547,(typeofMilitaryActivity)598,(typeofMilitaryActivity)599];
		private String? _activePeriod  = default;

		[Category("MilitaryPracticeArea")]
		public String? activePeriod {
			get {
				return _activePeriod;
			}
			set {
				SetValue(ref _activePeriod, value);
			}
		}
		[Category("MilitaryPracticeArea")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _minimumSafeDepth  = default;

		[Category("MilitaryPracticeArea")]
		public int? minimumSafeDepth {
			get {
				return _minimumSafeDepth;
			}
			set {
				SetValue(ref _minimumSafeDepth, value);
			}
		}
		[Category("MilitaryPracticeArea")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryofMilitaryPracticeAreaList), typeof(categoryofMilitaryPracticeArea))]
		public ObservableCollection<categoryofMilitaryPracticeArea> categoryofMilitaryPracticeArea  { get; set; } = new ();

		[Browsable(false)]
		public categoryofMilitaryPracticeArea[] categoryofMilitaryPracticeAreaList => [(categoryofMilitaryPracticeArea)2,(categoryofMilitaryPracticeArea)3,(categoryofMilitaryPracticeArea)4,(categoryofMilitaryPracticeArea)5,(categoryofMilitaryPracticeArea)501,(categoryofMilitaryPracticeArea)502,(categoryofMilitaryPracticeArea)503,(categoryofMilitaryPracticeArea)506,(categoryofMilitaryPracticeArea)507,(categoryofMilitaryPracticeArea)508,(categoryofMilitaryPracticeArea)510,(categoryofMilitaryPracticeArea)599];
		private int? _bottomVerticalSafetySeparation  = default;

		[Category("MilitaryPracticeArea")]
		public int? bottomVerticalSafetySeparation {
			get {
				return _bottomVerticalSafetySeparation;
			}
			set {
				SetValue(ref _bottomVerticalSafetySeparation, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		[Category("MilitaryPracticeArea")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private String? _agencyResponsibleForProduction  = default;

		[Category("MilitaryPracticeArea")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private areaCategory? _areaCategory  = default;

		[Category("MilitaryPracticeArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(areaCategoryList), typeof(areaCategory))]
		public areaCategory? areaCategory {
			get {
				return _areaCategory;
			}
			set {
				SetValue(ref _areaCategory, value);
			}
		}

		[Browsable(false)]
		public areaCategory[] areaCategoryList => [(areaCategory)501,(areaCategory)502];
		private verticalDatum? _verticalDatum  = default;

		[Category("MilitaryPracticeArea")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)3,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)44,(verticalDatum)501];
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("MilitaryPracticeArea")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("MilitaryPracticeArea")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		[Category("MilitaryPracticeArea")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)5,(status)6,(status)7,(status)16,(status)17,(status)501,(status)503,(status)517,(status)520];
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("MilitaryPracticeArea")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private String? _controllingAuthority  = default;

		[Category("MilitaryPracticeArea")]
		public String? controllingAuthority {
			get {
				return _controllingAuthority;
			}
			set {
				SetValue(ref _controllingAuthority, value);
			}
		}


		public override FeatureViewModel<MilitaryPracticeArea> Load(MilitaryPracticeArea instance) {
			altitudeRange = new ();
			if (instance.altitudeRange != default) {
				altitudeRange.Load(instance.altitudeRange);
			}
			depthRestriction = instance.depthRestriction;
			depthUnits = instance.depthUnits;
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			nationality = instance.nationality;
			restriction.Clear();
			if (instance.restriction is not null) {
				foreach(var e in instance.restriction)
					restriction.Add(e);
			}
			scaleMinimum = instance.scaleMinimum;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			typeofMilitaryActivity.Clear();
			if (instance.typeofMilitaryActivity is not null) {
				foreach(var e in instance.typeofMilitaryActivity)
					typeofMilitaryActivity.Add(e);
			}
			activePeriod = instance.activePeriod;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			minimumSafeDepth = instance.minimumSafeDepth;
			categoryofMilitaryPracticeArea.Clear();
			if (instance.categoryofMilitaryPracticeArea is not null) {
				foreach(var e in instance.categoryofMilitaryPracticeArea)
					categoryofMilitaryPracticeArea.Add(e);
			}
			bottomVerticalSafetySeparation = instance.bottomVerticalSafetySeparation;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			areaCategory = instance.areaCategory;
			verticalDatum = instance.verticalDatum;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			reportedDate = instance.reportedDate;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			controllingAuthority = instance.controllingAuthority;
			return this;
		}

		public override string Serialize() {
			var instance = new MilitaryPracticeArea {
				altitudeRange = this.altitudeRange?.Model,
				depthRestriction = this.depthRestriction,
				depthUnits = this.depthUnits,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				nationality = this.nationality,
				restriction = this.restriction.ToList(),
				scaleMinimum = this.scaleMinimum,
				information = this.information.Select(e => e.Model).ToList(),
				typeofMilitaryActivity = this.typeofMilitaryActivity.ToList(),
				activePeriod = this.activePeriod,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				minimumSafeDepth = this.minimumSafeDepth,
				categoryofMilitaryPracticeArea = this.categoryofMilitaryPracticeArea.ToList(),
				bottomVerticalSafetySeparation = this.bottomVerticalSafetySeparation,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				areaCategory = this.areaCategory,
				verticalDatum = this.verticalDatum,
				fixedDateRange = this.fixedDateRange?.Model,
				reportedDate = this.reportedDate,
				status = this.status.ToList(),
				sourceIdentification = this.sourceIdentification?.Model,
				controllingAuthority = this.controllingAuthority,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public MilitaryPracticeArea Model => new () {
			altitudeRange = this._altitudeRange?.Model,
			depthRestriction = this._depthRestriction,
			depthUnits = this._depthUnits,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			nationality = this._nationality,
			restriction = this.restriction.ToList(),
			scaleMinimum = this._scaleMinimum,
			information = this.information.Select(e => e.Model).ToList(),
			typeofMilitaryActivity = this.typeofMilitaryActivity.ToList(),
			activePeriod = this._activePeriod,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			minimumSafeDepth = this._minimumSafeDepth,
			categoryofMilitaryPracticeArea = this.categoryofMilitaryPracticeArea.ToList(),
			bottomVerticalSafetySeparation = this._bottomVerticalSafetySeparation,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			areaCategory = this._areaCategory,
			verticalDatum = this._verticalDatum,
			fixedDateRange = this._fixedDateRange?.Model,
			reportedDate = this._reportedDate,
			status = this.status.ToList(),
			sourceIdentification = this._sourceIdentification?.Model,
			controllingAuthority = this._controllingAuthority,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => MilitaryPracticeArea._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => MilitaryPracticeArea._featureBindingDefinitions;

		public override string? ToString() => $"Military Practice Area";

		public MilitaryPracticeAreaViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(restriction));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			typeofMilitaryActivity.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(typeofMilitaryActivity));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			categoryofMilitaryPracticeArea.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryofMilitaryPracticeArea));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}

	/// <summary>
	/// Unnatural coloured areas in the sea which may or may not indicate the existence of shoals.
	/// </summary>
	[CategoryOrder("DiscolouredWater",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DiscolouredWaterViewModel : FeatureViewModel<DiscolouredWater> {
		[Category("DiscolouredWater")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("DiscolouredWater")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("DiscolouredWater")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}


		public override FeatureViewModel<DiscolouredWater> Load(DiscolouredWater instance) {
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			reportedDate = instance.reportedDate;
			return this;
		}

		public override string Serialize() {
			var instance = new DiscolouredWater {
				information = this.information.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				reportedDate = this.reportedDate,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DiscolouredWater Model => new () {
			information = this.information.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			reportedDate = this._reportedDate,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => DiscolouredWater._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => DiscolouredWater._featureBindingDefinitions;

		public override string? ToString() => $"Discoloured Water";

		public DiscolouredWaterViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
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
		private categoryOfCardinalMark _categoryOfCardinalMark ;

		[Category("CardinalBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("CardinalBuoy")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("CardinalBuoy")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("CardinalBuoy")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("CardinalBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)11];
		private buoyShape _buoyShape ;

		[Category("CardinalBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		private decimal? _verticalLength  = default;

		[Category("CardinalBuoy")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		[Category("CardinalBuoy")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("CardinalBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)5,(status)7,(status)8,(status)18];
		private Boolean? _radarConspicuous  = default;

		[Category("CardinalBuoy")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("CardinalBuoy")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		[Category("CardinalBuoy")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("CardinalBuoy")]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)11];
		[Category("CardinalBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		private colourPattern? _colourPattern  = default;

		[Category("CardinalBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public colourPattern? colourPattern {
			get {
				return _colourPattern;
			}
			set {
				SetValue(ref _colourPattern, value);
			}
		}

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6];
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("CardinalBuoy")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private topmarkViewModel? _topmark  = default;

		[Category("CardinalBuoy")]
		[ExpandableObject]
		public topmarkViewModel? topmark {
			get {
				return _topmark;
			}
			set {
				SetValue(ref _topmark, value);
			}
		}
		[Category("CardinalBuoy")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private String? _pictorialRepresentation  = default;

		[Category("CardinalBuoy")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}


		public override FeatureViewModel<CardinalBuoy> Load(CardinalBuoy instance) {
			categoryOfCardinalMark = instance.categoryOfCardinalMark;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			buoyShape = instance.buoyShape;
			verticalLength = instance.verticalLength;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			reportedDate = instance.reportedDate;
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern = instance.colourPattern;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			topmark = new ();
			if (instance.topmark != default) {
				topmark.Load(instance.topmark);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			pictorialRepresentation = instance.pictorialRepresentation;
			return this;
		}

		public override string Serialize() {
			var instance = new CardinalBuoy {
				categoryOfCardinalMark = this.categoryOfCardinalMark,
				fixedDateRange = this.fixedDateRange?.Model,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				buoyShape = this.buoyShape,
				verticalLength = this.verticalLength,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				status = this.status.ToList(),
				radarConspicuous = this.radarConspicuous,
				reportedDate = this.reportedDate,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern,
				sourceIdentification = this.sourceIdentification?.Model,
				topmark = this.topmark?.Model,
				information = this.information.Select(e => e.Model).ToList(),
				pictorialRepresentation = this.pictorialRepresentation,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CardinalBuoy Model => new () {
			categoryOfCardinalMark = this._categoryOfCardinalMark,
			fixedDateRange = this._fixedDateRange?.Model,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			buoyShape = this._buoyShape,
			verticalLength = this._verticalLength,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			status = this.status.ToList(),
			radarConspicuous = this._radarConspicuous,
			reportedDate = this._reportedDate,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			colour = this.colour.ToList(),
			colourPattern = this._colourPattern,
			sourceIdentification = this._sourceIdentification?.Model,
			topmark = this._topmark?.Model,
			information = this.information.Select(e => e.Model).ToList(),
			pictorialRepresentation = this._pictorialRepresentation,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => CardinalBuoy._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => CardinalBuoy._featureBindingDefinitions;

		public override string? ToString() => $"Cardinal Buoy";

		public CardinalBuoyViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// A safe water buoy is used to indicate that there is navigable water around the mark.
	/// </summary>
	[CategoryOrder("SafeWaterBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SafeWaterBuoyViewModel : FeatureViewModel<SafeWaterBuoy> {
		private buoyShape _buoyShape ;

		[Category("SafeWaterBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		[Category("SafeWaterBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		private decimal? _verticalLength  = default;

		[Category("SafeWaterBuoy")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("SafeWaterBuoy")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		[Category("SafeWaterBuoy")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		private topmarkViewModel? _topmark  = default;

		[Category("SafeWaterBuoy")]
		[ExpandableObject]
		public topmarkViewModel? topmark {
			get {
				return _topmark;
			}
			set {
				SetValue(ref _topmark, value);
			}
		}
		[Category("SafeWaterBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)5,(status)7,(status)8,(status)18];
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("SafeWaterBuoy")]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)11];
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("SafeWaterBuoy")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("SafeWaterBuoy")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("SafeWaterBuoy")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("SafeWaterBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)11];
		[Category("SafeWaterBuoy")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private String? _interoperabilityIdentifier  = default;

		[Category("SafeWaterBuoy")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("SafeWaterBuoy")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private colourPattern? _colourPattern  = default;

		[Category("SafeWaterBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public colourPattern? colourPattern {
			get {
				return _colourPattern;
			}
			set {
				SetValue(ref _colourPattern, value);
			}
		}

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6];
		private Boolean? _radarConspicuous  = default;

		[Category("SafeWaterBuoy")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("SafeWaterBuoy")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override FeatureViewModel<SafeWaterBuoy> Load(SafeWaterBuoy instance) {
			buoyShape = instance.buoyShape;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			verticalLength = instance.verticalLength;
			pictorialRepresentation = instance.pictorialRepresentation;
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			topmark = new ();
			if (instance.topmark != default) {
				topmark.Load(instance.topmark);
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			scaleMinimum = instance.scaleMinimum;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			reportedDate = instance.reportedDate;
			colourPattern = instance.colourPattern;
			radarConspicuous = instance.radarConspicuous;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new SafeWaterBuoy {
				buoyShape = this.buoyShape,
				colour = this.colour.ToList(),
				verticalLength = this.verticalLength,
				pictorialRepresentation = this.pictorialRepresentation,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				topmark = this.topmark?.Model,
				status = this.status.ToList(),
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				sourceIdentification = this.sourceIdentification?.Model,
				fixedDateRange = this.fixedDateRange?.Model,
				scaleMinimum = this.scaleMinimum,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				reportedDate = this.reportedDate,
				colourPattern = this.colourPattern,
				radarConspicuous = this.radarConspicuous,
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SafeWaterBuoy Model => new () {
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			verticalLength = this._verticalLength,
			pictorialRepresentation = this._pictorialRepresentation,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			topmark = this._topmark?.Model,
			status = this.status.ToList(),
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			sourceIdentification = this._sourceIdentification?.Model,
			fixedDateRange = this._fixedDateRange?.Model,
			scaleMinimum = this._scaleMinimum,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			reportedDate = this._reportedDate,
			colourPattern = this._colourPattern,
			radarConspicuous = this._radarConspicuous,
			information = this.information.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => SafeWaterBuoy._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => SafeWaterBuoy._featureBindingDefinitions;

		public override string? ToString() => $"Safe Water Buoy";

		public SafeWaterBuoyViewModel() : base() {
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
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
		[Category("RadioStation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("RadioStation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("RadioStation")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		[Category("RadioStation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private frequencyPairViewModel? _frequencyPair  = default;

		[Category("RadioStation")]
		[ExpandableObject]
		public frequencyPairViewModel? frequencyPair {
			get {
				return _frequencyPair;
			}
			set {
				SetValue(ref _frequencyPair, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("RadioStation")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private String? _callsign  = default;

		[Category("RadioStation")]
		public String? callsign {
			get {
				return _callsign;
			}
			set {
				SetValue(ref _callsign, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("RadioStation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private String? _communicationChannel  = default;

		[Category("RadioStation")]
		public String? communicationChannel {
			get {
				return _communicationChannel;
			}
			set {
				SetValue(ref _communicationChannel, value);
			}
		}
		[Category("RadioStation")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8];
		[Category("RadioStation")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfRadioStationList), typeof(categoryOfRadioStation))]
		public ObservableCollection<categoryOfRadioStation> categoryOfRadioStation  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfRadioStation[] categoryOfRadioStationList => [(categoryOfRadioStation)5,(categoryOfRadioStation)10,(categoryOfRadioStation)11,(categoryOfRadioStation)14,(categoryOfRadioStation)19,(categoryOfRadioStation)20];
		[Category("RadioStation")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		private decimal? _estimatedRangeofTransmission  = default;

		[Category("RadioStation")]
		public decimal? estimatedRangeofTransmission {
			get {
				return _estimatedRangeofTransmission;
			}
			set {
				SetValue(ref _estimatedRangeofTransmission, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		[Category("RadioStation")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}


		public override FeatureViewModel<RadioStation> Load(RadioStation instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			reportedDate = instance.reportedDate;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			frequencyPair = new ();
			if (instance.frequencyPair != default) {
				frequencyPair.Load(instance.frequencyPair);
			}
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			callsign = instance.callsign;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			communicationChannel = instance.communicationChannel;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			categoryOfRadioStation.Clear();
			if (instance.categoryOfRadioStation is not null) {
				foreach(var e in instance.categoryOfRadioStation)
					categoryOfRadioStation.Add(e);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			estimatedRangeofTransmission = instance.estimatedRangeofTransmission;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			return this;
		}

		public override string Serialize() {
			var instance = new RadioStation {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				reportedDate = this.reportedDate,
				information = this.information.Select(e => e.Model).ToList(),
				frequencyPair = this.frequencyPair?.Model,
				sourceIdentification = this.sourceIdentification?.Model,
				callsign = this.callsign,
				fixedDateRange = this.fixedDateRange?.Model,
				communicationChannel = this.communicationChannel,
				status = this.status.ToList(),
				categoryOfRadioStation = this.categoryOfRadioStation.ToList(),
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				estimatedRangeofTransmission = this.estimatedRangeofTransmission,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RadioStation Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			reportedDate = this._reportedDate,
			information = this.information.Select(e => e.Model).ToList(),
			frequencyPair = this._frequencyPair?.Model,
			sourceIdentification = this._sourceIdentification?.Model,
			callsign = this._callsign,
			fixedDateRange = this._fixedDateRange?.Model,
			communicationChannel = this._communicationChannel,
			status = this.status.ToList(),
			categoryOfRadioStation = this.categoryOfRadioStation.ToList(),
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			estimatedRangeofTransmission = this._estimatedRangeofTransmission,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => RadioStation._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => RadioStation._featureBindingDefinitions;

		public override string? ToString() => $"Radio Station";

		public RadioStationViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			categoryOfRadioStation.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfRadioStation));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
		}
	}

	/// <summary>
	/// Airspace of defined dimension identified by area on Earth's surface where activities must be confined because of their nature and/or where limitations may be imposed on aircraft.
	/// </summary>
	[CategoryOrder("MilitaryExerciseAirspace",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class MilitaryExerciseAirspaceViewModel : FeatureViewModel<MilitaryExerciseAirspace> {
		[Category("MilitaryExerciseAirspace")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("MilitaryExerciseAirspace")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private String? _pictorialRepresentation  = default;

		[Category("MilitaryExerciseAirspace")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _controllingAuthority  = default;

		[Category("MilitaryExerciseAirspace")]
		public String? controllingAuthority {
			get {
				return _controllingAuthority;
			}
			set {
				SetValue(ref _controllingAuthority, value);
			}
		}
		private String? _activePeriod  = default;

		[Category("MilitaryExerciseAirspace")]
		public String? activePeriod {
			get {
				return _activePeriod;
			}
			set {
				SetValue(ref _activePeriod, value);
			}
		}
		private altitudeViewModel? _altitude  = default;

		[Category("MilitaryExerciseAirspace")]
		[ExpandableObject]
		public altitudeViewModel? altitude {
			get {
				return _altitude;
			}
			set {
				SetValue(ref _altitude, value);
			}
		}
		private String? _agencyResponsibleForProduction  = default;

		[Category("MilitaryExerciseAirspace")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private flightLevelViewModel? _flightLevel  = default;

		[Category("MilitaryExerciseAirspace")]
		[ExpandableObject]
		public flightLevelViewModel? flightLevel {
			get {
				return _flightLevel;
			}
			set {
				SetValue(ref _flightLevel, value);
			}
		}


		public override FeatureViewModel<MilitaryExerciseAirspace> Load(MilitaryExerciseAirspace instance) {
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
			pictorialRepresentation = instance.pictorialRepresentation;
			controllingAuthority = instance.controllingAuthority;
			activePeriod = instance.activePeriod;
			altitude = new ();
			if (instance.altitude != default) {
				altitude.Load(instance.altitude);
			}
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			flightLevel = new ();
			if (instance.flightLevel != default) {
				flightLevel.Load(instance.flightLevel);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new MilitaryExerciseAirspace {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				pictorialRepresentation = this.pictorialRepresentation,
				controllingAuthority = this.controllingAuthority,
				activePeriod = this.activePeriod,
				altitude = this.altitude?.Model,
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				flightLevel = this.flightLevel?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public MilitaryExerciseAirspace Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			pictorialRepresentation = this._pictorialRepresentation,
			controllingAuthority = this._controllingAuthority,
			activePeriod = this._activePeriod,
			altitude = this._altitude?.Model,
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			flightLevel = this._flightLevel?.Model,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => MilitaryExerciseAirspace._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => MilitaryExerciseAirspace._featureBindingDefinitions;

		public override string? ToString() => $"Military Exercise Airspace";

		public MilitaryExerciseAirspaceViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// A zone contiguous to a coastal State's Territorial Sea, which may not extend beyond 24 nautical miles from the baselines from which the breadth of the Territorial Sea is measured. The coastal State may exercise certain control in this zone subject to the provisions of International Law.
	/// </summary>
	[CategoryOrder("ContiguousZone",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ContiguousZoneViewModel : FeatureViewModel<ContiguousZone> {
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("ContiguousZone")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("ContiguousZone")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		[Category("ContiguousZone")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("ContiguousZone")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("ContiguousZone")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		[Category("ContiguousZone")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)502,(status)504,(status)520];
		private Boolean? _inDispute  = default;

		[Category("ContiguousZone")]
		public Boolean? inDispute {
			get {
				return _inDispute;
			}
			set {
				SetValue(ref _inDispute, value);
			}
		}
		[Category("ContiguousZone")]
		public ObservableCollection<String> nationality  { get; set; } = new ();
		[Category("ContiguousZone")]
		public ObservableCollection<String> nationalMaritimeAuthority  { get; set; } = new ();
		[Category("ContiguousZone")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override FeatureViewModel<ContiguousZone> Load(ContiguousZone instance) {
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			scaleMinimum = instance.scaleMinimum;
			reportedDate = instance.reportedDate;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			inDispute = instance.inDispute;
			nationality.Clear();
			if (instance.nationality is not null) {
				foreach(var e in instance.nationality)
					nationality.Add(e);
			}
			nationalMaritimeAuthority.Clear();
			if (instance.nationalMaritimeAuthority is not null) {
				foreach(var e in instance.nationalMaritimeAuthority)
					nationalMaritimeAuthority.Add(e);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new ContiguousZone {
				sourceIdentification = this.sourceIdentification?.Model,
				fixedDateRange = this.fixedDateRange?.Model,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				scaleMinimum = this.scaleMinimum,
				reportedDate = this.reportedDate,
				status = this.status.ToList(),
				inDispute = this.inDispute,
				nationality = this.nationality.ToList(),
				nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ContiguousZone Model => new () {
			sourceIdentification = this._sourceIdentification?.Model,
			fixedDateRange = this._fixedDateRange?.Model,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			scaleMinimum = this._scaleMinimum,
			reportedDate = this._reportedDate,
			status = this.status.ToList(),
			inDispute = this._inDispute,
			nationality = this.nationality.ToList(),
			nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
			information = this.information.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => ContiguousZone._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => ContiguousZone._featureBindingDefinitions;

		public override string? ToString() => $"Contiguous Zone";

		public ContiguousZoneViewModel() : base() {
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			nationality.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(nationality));
			};
			nationalMaritimeAuthority.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(nationalMaritimeAuthority));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// The low-water line along the coast as marked on large-scale charts officially recognized by the coastal State. In the case of islands situated on atolls or of islands having fringing reefs, the baseline for measuring the breadth of the territorial sea is the seaward low-water line of the reef, as shown by the appropriate symbol on charts officially recognized by the coastal State. Where a low-tide elevation is situated wholly or partly at a distance not exceeding the breadth of the territorial sea from the mainland or an island, the low-water line on that elevation may be used as the baseline for measuring the breadth of the territorial sea.
	/// </summary>
	[CategoryOrder("NormalBaseline",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NormalBaselineViewModel : FeatureViewModel<NormalBaseline> {
		[Category("NormalBaseline")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("NormalBaseline")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("NormalBaseline")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private String _nationality  = string.Empty;

		[Category("NormalBaseline")]
		public String nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}
		private String? _agencyResponsibleForProduction  = default;

		[Category("NormalBaseline")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private status? _status  = default;

		[Category("NormalBaseline")]
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
		public status[] statusList => [(status)502,(status)504];
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("NormalBaseline")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}


		public override FeatureViewModel<NormalBaseline> Load(NormalBaseline instance) {
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			reportedDate = instance.reportedDate;
			nationality = instance.nationality;
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			status = instance.status;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new NormalBaseline {
				information = this.information.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				reportedDate = this.reportedDate,
				nationality = this.nationality,
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				status = this.status,
				sourceIdentification = this.sourceIdentification?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public NormalBaseline Model => new () {
			information = this.information.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			reportedDate = this._reportedDate,
			nationality = this._nationality,
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			status = this._status,
			sourceIdentification = this._sourceIdentification?.Model,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => NormalBaseline._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => NormalBaseline._featureBindingDefinitions;

		public override string? ToString() => $"Normal Baseline";

		public NormalBaselineViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// An area which contains one or more submarine cables.
	/// </summary>
	[CategoryOrder("CableArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CableAreaViewModel : FeatureViewModel<CableArea> {
		[Category("CableArea")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("CableArea")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)7,(status)13];
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("CableArea")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("CableArea")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		[Category("CableArea")]
		public ObservableCollection<vesselSpeedLimitViewModel> vesselSpeedLimit  { get; set; } = new ();
		[Category("CableArea")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private DateOnly? _reportedDate  = default;

		[Category("CableArea")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("CableArea")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("CableArea")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(restrictionList), typeof(restriction))]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)7,(restriction)8,(restriction)9,(restriction)11,(restriction)12,(restriction)13,(restriction)14,(restriction)16,(restriction)17,(restriction)18,(restriction)20,(restriction)23,(restriction)24,(restriction)25,(restriction)27,(restriction)39];
		private String? _interoperabilityIdentifier  = default;

		[Category("CableArea")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("CableArea")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfCableList), typeof(categoryOfCable))]
		public ObservableCollection<categoryOfCable> categoryOfCable  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfCable[] categoryOfCableList => [(categoryOfCable)1,(categoryOfCable)7,(categoryOfCable)10];


		public override FeatureViewModel<CableArea> Load(CableArea instance) {
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			vesselSpeedLimit.Clear();
			if (instance.vesselSpeedLimit is not null) {
				foreach(var e in instance.vesselSpeedLimit)
					vesselSpeedLimit.Add(new vesselSpeedLimitViewModel().Load(e));
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			reportedDate = instance.reportedDate;
			scaleMinimum = instance.scaleMinimum;
			restriction.Clear();
			if (instance.restriction is not null) {
				foreach(var e in instance.restriction)
					restriction.Add(e);
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			categoryOfCable.Clear();
			if (instance.categoryOfCable is not null) {
				foreach(var e in instance.categoryOfCable)
					categoryOfCable.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new CableArea {
				information = this.information.Select(e => e.Model).ToList(),
				status = this.status.ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				sourceIdentification = this.sourceIdentification?.Model,
				vesselSpeedLimit = this.vesselSpeedLimit.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				reportedDate = this.reportedDate,
				scaleMinimum = this.scaleMinimum,
				restriction = this.restriction.ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				categoryOfCable = this.categoryOfCable.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CableArea Model => new () {
			information = this.information.Select(e => e.Model).ToList(),
			status = this.status.ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			sourceIdentification = this._sourceIdentification?.Model,
			vesselSpeedLimit = this.vesselSpeedLimit.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			reportedDate = this._reportedDate,
			scaleMinimum = this._scaleMinimum,
			restriction = this.restriction.ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			categoryOfCable = this.categoryOfCable.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => CableArea._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => CableArea._featureBindingDefinitions;

		public override string? ToString() => $"Cable Area";

		public CableAreaViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			vesselSpeedLimit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(vesselSpeedLimit));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(restriction));
			};
			categoryOfCable.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfCable));
			};
		}
	}

	/// <summary>
	/// The Continental Shelf of a coastal State comprises the seabed and subsoil of the submarine areas that extend beyond its Territorial Sea throughout the natural prolongation of its land territory to the outer edge of the continental margin, or to a distance of 200 nautical miles from the baselines from which the breadth of the Territorial Sea is measured where the outer edge of the continental margin does not extend up to that distance.
	/// </summary>
	[CategoryOrder("ContinentalShelfArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ContinentalShelfAreaViewModel : FeatureViewModel<ContinentalShelfArea> {
		private status? _status  = default;

		[Category("ContinentalShelfArea")]
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
		public status[] statusList => [(status)502,(status)504,(status)520];
		private Boolean? _inDispute  = default;

		[Category("ContinentalShelfArea")]
		public Boolean? inDispute {
			get {
				return _inDispute;
			}
			set {
				SetValue(ref _inDispute, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("ContinentalShelfArea")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		[Category("ContinentalShelfArea")]
		public ObservableCollection<String> nationalMaritimeAuthority  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("ContinentalShelfArea")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("ContinentalShelfArea")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("ContinentalShelfArea")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("ContinentalShelfArea")]
		public ObservableCollection<String> nationality  { get; set; } = new ();
		private String? _interoperabilityIdentifier  = default;

		[Category("ContinentalShelfArea")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}


		public override FeatureViewModel<ContinentalShelfArea> Load(ContinentalShelfArea instance) {
			status = instance.status;
			inDispute = instance.inDispute;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			nationalMaritimeAuthority.Clear();
			if (instance.nationalMaritimeAuthority is not null) {
				foreach(var e in instance.nationalMaritimeAuthority)
					nationalMaritimeAuthority.Add(e);
			}
			scaleMinimum = instance.scaleMinimum;
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
			nationality.Clear();
			if (instance.nationality is not null) {
				foreach(var e in instance.nationality)
					nationality.Add(e);
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			return this;
		}

		public override string Serialize() {
			var instance = new ContinentalShelfArea {
				status = this.status,
				inDispute = this.inDispute,
				sourceIdentification = this.sourceIdentification?.Model,
				nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
				scaleMinimum = this.scaleMinimum,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				nationality = this.nationality.ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ContinentalShelfArea Model => new () {
			status = this._status,
			inDispute = this._inDispute,
			sourceIdentification = this._sourceIdentification?.Model,
			nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
			scaleMinimum = this._scaleMinimum,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			nationality = this.nationality.ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => ContinentalShelfArea._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => ContinentalShelfArea._featureBindingDefinitions;

		public override string? ToString() => $"Continental Shelf Area";

		public ContinentalShelfAreaViewModel() : base() {
			nationalMaritimeAuthority.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(nationalMaritimeAuthority));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			nationality.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(nationality));
			};
		}
	}

	/// <summary>
	/// Waters on the landward side of the baseline of the territorial sea.
	/// </summary>
	[CategoryOrder("InternalWaters",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class InternalWatersViewModel : FeatureViewModel<InternalWaters> {
		[Category("InternalWaters")]
		public ObservableCollection<String> nationality  { get; set; } = new ();
		[Category("InternalWaters")]
		public ObservableCollection<String> nationalMaritimeAuthority  { get; set; } = new ();
		private Boolean? _inDispute  = default;

		[Category("InternalWaters")]
		public Boolean? inDispute {
			get {
				return _inDispute;
			}
			set {
				SetValue(ref _inDispute, value);
			}
		}
		private String? _agencyResponsibleForProduction  = default;

		[Category("InternalWaters")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("InternalWaters")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		[Category("InternalWaters")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private Boolean? _lineTypeGeodesic  = default;

		[Category("InternalWaters")]
		public Boolean? lineTypeGeodesic {
			get {
				return _lineTypeGeodesic;
			}
			set {
				SetValue(ref _lineTypeGeodesic, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("InternalWaters")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private status? _status  = default;

		[Category("InternalWaters")]
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
		public status[] statusList => [(status)502,(status)504,(status)520];


		public override FeatureViewModel<InternalWaters> Load(InternalWaters instance) {
			nationality.Clear();
			if (instance.nationality is not null) {
				foreach(var e in instance.nationality)
					nationality.Add(e);
			}
			nationalMaritimeAuthority.Clear();
			if (instance.nationalMaritimeAuthority is not null) {
				foreach(var e in instance.nationalMaritimeAuthority)
					nationalMaritimeAuthority.Add(e);
			}
			inDispute = instance.inDispute;
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			lineTypeGeodesic = instance.lineTypeGeodesic;
			reportedDate = instance.reportedDate;
			status = instance.status;
			return this;
		}

		public override string Serialize() {
			var instance = new InternalWaters {
				nationality = this.nationality.ToList(),
				nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
				inDispute = this.inDispute,
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				sourceIdentification = this.sourceIdentification?.Model,
				information = this.information.Select(e => e.Model).ToList(),
				lineTypeGeodesic = this.lineTypeGeodesic,
				reportedDate = this.reportedDate,
				status = this.status,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public InternalWaters Model => new () {
			nationality = this.nationality.ToList(),
			nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
			inDispute = this._inDispute,
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			sourceIdentification = this._sourceIdentification?.Model,
			information = this.information.Select(e => e.Model).ToList(),
			lineTypeGeodesic = this._lineTypeGeodesic,
			reportedDate = this._reportedDate,
			status = this._status,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => InternalWaters._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => InternalWaters._featureBindingDefinitions;

		public override string? ToString() => $"Internal Waters";

		public InternalWatersViewModel() : base() {
			nationality.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(nationality));
			};
			nationalMaritimeAuthority.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(nationalMaritimeAuthority));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// A defined area within which a jurisdiction applies. It may or may not be named.
	/// </summary>
	[CategoryOrder("AdministrationArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AdministrationAreaViewModel : FeatureViewModel<AdministrationArea> {
		private String? _pictorialRepresentation  = default;

		[Category("AdministrationArea")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private Boolean? _inDispute  = default;

		[Category("AdministrationArea")]
		public Boolean? inDispute {
			get {
				return _inDispute;
			}
			set {
				SetValue(ref _inDispute, value);
			}
		}
		private jurisdiction _jurisdiction ;

		[Category("AdministrationArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(jurisdictionList), typeof(jurisdiction))]
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
		private int? _scaleMinimum  = default;

		[Category("AdministrationArea")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("AdministrationArea")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AdministrationArea")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("AdministrationArea")]
		public ObservableCollection<String> nationality  { get; set; } = new ();


		public override FeatureViewModel<AdministrationArea> Load(AdministrationArea instance) {
			pictorialRepresentation = instance.pictorialRepresentation;
			inDispute = instance.inDispute;
			jurisdiction = instance.jurisdiction;
			scaleMinimum = instance.scaleMinimum;
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
			nationality.Clear();
			if (instance.nationality is not null) {
				foreach(var e in instance.nationality)
					nationality.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new AdministrationArea {
				pictorialRepresentation = this.pictorialRepresentation,
				inDispute = this.inDispute,
				jurisdiction = this.jurisdiction,
				scaleMinimum = this.scaleMinimum,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				nationality = this.nationality.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AdministrationArea Model => new () {
			pictorialRepresentation = this._pictorialRepresentation,
			inDispute = this._inDispute,
			jurisdiction = this._jurisdiction,
			scaleMinimum = this._scaleMinimum,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			nationality = this.nationality.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => AdministrationArea._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => AdministrationArea._featureBindingDefinitions;

		public override string? ToString() => $"Administration Area";

		public AdministrationAreaViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			nationality.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(nationality));
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
		private int? _scaleMinimum  = default;

		[Category("Bollard")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("Bollard")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("Bollard")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("Bollard")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("Bollard")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		[Category("Bollard")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private String? _pictorialRepresentation  = default;

		[Category("Bollard")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private condition? _condition  = default;

		[Category("Bollard")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)5];
		[Category("Bollard")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)3,(status)4,(status)6,(status)7,(status)8,(status)12,(status)14,(status)18];


		public override FeatureViewModel<Bollard> Load(Bollard instance) {
			scaleMinimum = instance.scaleMinimum;
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
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			reportedDate = instance.reportedDate;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			pictorialRepresentation = instance.pictorialRepresentation;
			condition = instance.condition;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Bollard {
				scaleMinimum = this.scaleMinimum,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				reportedDate = this.reportedDate,
				information = this.information.Select(e => e.Model).ToList(),
				pictorialRepresentation = this.pictorialRepresentation,
				condition = this.condition,
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Bollard Model => new () {
			scaleMinimum = this._scaleMinimum,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			reportedDate = this._reportedDate,
			information = this.information.Select(e => e.Model).ToList(),
			pictorialRepresentation = this._pictorialRepresentation,
			condition = this._condition,
			status = this.status.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => Bollard._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => Bollard._featureBindingDefinitions;

		public override string? ToString() => $"Bollard";

		public BollardViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
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
		private String? _pictorialRepresentation  = default;

		[Category("Dolphin")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private decimal? _verticalLength  = default;

		[Category("Dolphin")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private colourPattern? _colourPattern  = default;

		[Category("Dolphin")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public colourPattern? colourPattern {
			get {
				return _colourPattern;
			}
			set {
				SetValue(ref _colourPattern, value);
			}
		}

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6];
		private categoryOfDolphin _categoryOfDolphin ;

		[Category("Dolphin")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfDolphinList), typeof(categoryOfDolphin))]
		public categoryOfDolphin categoryOfDolphin {
			get {
				return _categoryOfDolphin;
			}
			set {
				SetValue(ref _categoryOfDolphin, value);
			}
		}

		[Browsable(false)]
		public categoryOfDolphin[] categoryOfDolphinList => [(categoryOfDolphin)1,(categoryOfDolphin)2,(categoryOfDolphin)3,(categoryOfDolphin)4];
		[Category("Dolphin")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		private visualProminence? _visualProminence  = default;

		[Category("Dolphin")]
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
		[Category("Dolphin")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("Dolphin")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private decimal? _elevation  = default;

		[Category("Dolphin")]
		public decimal? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}
		[Category("Dolphin")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)12,(status)14,(status)18];
		[Category("Dolphin")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private Boolean? _radarConspicuous  = default;

		[Category("Dolphin")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("Dolphin")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private condition? _condition  = default;

		[Category("Dolphin")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)5];
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("Dolphin")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("Dolphin")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private decimal? _height  = default;

		[Category("Dolphin")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		[Category("Dolphin")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)6,(natureOfConstruction)7];


		public override FeatureViewModel<Dolphin> Load(Dolphin instance) {
			pictorialRepresentation = instance.pictorialRepresentation;
			verticalLength = instance.verticalLength;
			colourPattern = instance.colourPattern;
			categoryOfDolphin = instance.categoryOfDolphin;
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			visualProminence = instance.visualProminence;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			elevation = instance.elevation;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			radarConspicuous = instance.radarConspicuous;
			reportedDate = instance.reportedDate;
			condition = instance.condition;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			scaleMinimum = instance.scaleMinimum;
			height = instance.height;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Dolphin {
				pictorialRepresentation = this.pictorialRepresentation,
				verticalLength = this.verticalLength,
				colourPattern = this.colourPattern,
				categoryOfDolphin = this.categoryOfDolphin,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				visualProminence = this.visualProminence,
				colour = this.colour.ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				elevation = this.elevation,
				status = this.status.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				radarConspicuous = this.radarConspicuous,
				reportedDate = this.reportedDate,
				condition = this.condition,
				fixedDateRange = this.fixedDateRange?.Model,
				scaleMinimum = this.scaleMinimum,
				height = this.height,
				natureOfConstruction = this.natureOfConstruction.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Dolphin Model => new () {
			pictorialRepresentation = this._pictorialRepresentation,
			verticalLength = this._verticalLength,
			colourPattern = this._colourPattern,
			categoryOfDolphin = this._categoryOfDolphin,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			visualProminence = this._visualProminence,
			colour = this.colour.ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			elevation = this._elevation,
			status = this.status.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			radarConspicuous = this._radarConspicuous,
			reportedDate = this._reportedDate,
			condition = this._condition,
			fixedDateRange = this._fixedDateRange?.Model,
			scaleMinimum = this._scaleMinimum,
			height = this._height,
			natureOfConstruction = this.natureOfConstruction.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => Dolphin._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => Dolphin._featureBindingDefinitions;

		public override string? ToString() => $"Dolphin";

		public DolphinViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
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
		[Category("RadarRange")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private String? _interoperabilityIdentifier  = default;

		[Category("RadarRange")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("RadarRange")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("RadarRange")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("RadarRange")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("RadarRange")]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();
		[Category("RadarRange")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)7];


		public override FeatureViewModel<RadarRange> Load(RadarRange instance) {
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			scaleMinimum = instance.scaleMinimum;
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
				information = this.information.Select(e => e.Model).ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				scaleMinimum = this.scaleMinimum,
				communicationChannel = this.communicationChannel.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RadarRange Model => new () {
			information = this.information.Select(e => e.Model).ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			scaleMinimum = this._scaleMinimum,
			communicationChannel = this.communicationChannel.ToList(),
			status = this.status.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => RadarRange._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => RadarRange._featureBindingDefinitions;

		public override string? ToString() => $"Radar Range";

		public RadarRangeViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
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
	/// An isolated danger beacon is a beacon erected on an isolated danger of limited extent, which has navigable water all around it.
	/// </summary>
	[CategoryOrder("IsolatedDangerBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class IsolatedDangerBeaconViewModel : FeatureViewModel<IsolatedDangerBeacon> {
		private condition? _condition  = default;

		[Category("IsolatedDangerBeacon")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)5];
		[Category("IsolatedDangerBeacon")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		private DateOnly? _reportedDate  = default;

		[Category("IsolatedDangerBeacon")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private beaconShape _beaconShape ;

		[Category("IsolatedDangerBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		private Boolean? _radarConspicuous  = default;

		[Category("IsolatedDangerBeacon")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		[Category("IsolatedDangerBeacon")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8];
		[Category("IsolatedDangerBeacon")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)12,(status)18];
		[Category("IsolatedDangerBeacon")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("IsolatedDangerBeacon")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private decimal? _elevation  = default;

		[Category("IsolatedDangerBeacon")]
		public decimal? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}
		private String? _agencyResponsibleForProduction  = default;

		[Category("IsolatedDangerBeacon")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("IsolatedDangerBeacon")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("IsolatedDangerBeacon")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private topmarkViewModel? _topmark  = default;

		[Category("IsolatedDangerBeacon")]
		[ExpandableObject]
		public topmarkViewModel? topmark {
			get {
				return _topmark;
			}
			set {
				SetValue(ref _topmark, value);
			}
		}
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("IsolatedDangerBeacon")]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)11];
		private decimal? _height  = default;

		[Category("IsolatedDangerBeacon")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private visualProminence? _visualProminence  = default;

		[Category("IsolatedDangerBeacon")]
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
		private decimal? _verticalLength  = default;

		[Category("IsolatedDangerBeacon")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		[Category("IsolatedDangerBeacon")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("IsolatedDangerBeacon")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("IsolatedDangerBeacon")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		[Category("IsolatedDangerBeacon")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private colourPattern? _colourPattern  = default;

		[Category("IsolatedDangerBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public colourPattern? colourPattern {
			get {
				return _colourPattern;
			}
			set {
				SetValue(ref _colourPattern, value);
			}
		}

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6];


		public override FeatureViewModel<IsolatedDangerBeacon> Load(IsolatedDangerBeacon instance) {
			condition = instance.condition;
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			reportedDate = instance.reportedDate;
			beaconShape = instance.beaconShape;
			radarConspicuous = instance.radarConspicuous;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			elevation = instance.elevation;
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			pictorialRepresentation = instance.pictorialRepresentation;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			topmark = new ();
			if (instance.topmark != default) {
				topmark.Load(instance.topmark);
			}
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			height = instance.height;
			visualProminence = instance.visualProminence;
			verticalLength = instance.verticalLength;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
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
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			colourPattern = instance.colourPattern;
			return this;
		}

		public override string Serialize() {
			var instance = new IsolatedDangerBeacon {
				condition = this.condition,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				reportedDate = this.reportedDate,
				beaconShape = this.beaconShape,
				radarConspicuous = this.radarConspicuous,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				elevation = this.elevation,
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				pictorialRepresentation = this.pictorialRepresentation,
				sourceIdentification = this.sourceIdentification?.Model,
				topmark = this.topmark?.Model,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				height = this.height,
				visualProminence = this.visualProminence,
				verticalLength = this.verticalLength,
				colour = this.colour.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				colourPattern = this.colourPattern,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public IsolatedDangerBeacon Model => new () {
			condition = this._condition,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			reportedDate = this._reportedDate,
			beaconShape = this._beaconShape,
			radarConspicuous = this._radarConspicuous,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			elevation = this._elevation,
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			pictorialRepresentation = this._pictorialRepresentation,
			sourceIdentification = this._sourceIdentification?.Model,
			topmark = this._topmark?.Model,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			height = this._height,
			visualProminence = this._visualProminence,
			verticalLength = this._verticalLength,
			colour = this.colour.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			colourPattern = this._colourPattern,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => IsolatedDangerBeacon._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => IsolatedDangerBeacon._featureBindingDefinitions;

		public override string? ToString() => $"Isolated Danger Beacon";

		public IsolatedDangerBeaconViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// An isolated danger buoy is a buoy moored on or above an isolated danger of limited extent, which has navigable water all around it.
	/// </summary>
	[CategoryOrder("IsolatedDangerBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class IsolatedDangerBuoyViewModel : FeatureViewModel<IsolatedDangerBuoy> {
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("IsolatedDangerBuoy")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private topmarkViewModel? _topmark  = default;

		[Category("IsolatedDangerBuoy")]
		[ExpandableObject]
		public topmarkViewModel? topmark {
			get {
				return _topmark;
			}
			set {
				SetValue(ref _topmark, value);
			}
		}
		[Category("IsolatedDangerBuoy")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private Boolean? _radarConspicuous  = default;

		[Category("IsolatedDangerBuoy")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		private decimal? _verticalLength  = default;

		[Category("IsolatedDangerBuoy")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		[Category("IsolatedDangerBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		private String? _interoperabilityIdentifier  = default;

		[Category("IsolatedDangerBuoy")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("IsolatedDangerBuoy")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("IsolatedDangerBuoy")]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)11];
		private buoyShape _buoyShape ;

		[Category("IsolatedDangerBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		[Category("IsolatedDangerBuoy")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		private colourPattern? _colourPattern  = default;

		[Category("IsolatedDangerBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public colourPattern? colourPattern {
			get {
				return _colourPattern;
			}
			set {
				SetValue(ref _colourPattern, value);
			}
		}

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6];
		private int? _scaleMinimum  = default;

		[Category("IsolatedDangerBuoy")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("IsolatedDangerBuoy")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		[Category("IsolatedDangerBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)11];
		[Category("IsolatedDangerBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)5,(status)7,(status)8,(status)18];


		public override FeatureViewModel<IsolatedDangerBuoy> Load(IsolatedDangerBuoy instance) {
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			topmark = new ();
			if (instance.topmark != default) {
				topmark.Load(instance.topmark);
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			radarConspicuous = instance.radarConspicuous;
			verticalLength = instance.verticalLength;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			buoyShape = instance.buoyShape;
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			colourPattern = instance.colourPattern;
			scaleMinimum = instance.scaleMinimum;
			pictorialRepresentation = instance.pictorialRepresentation;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new IsolatedDangerBuoy {
				fixedDateRange = this.fixedDateRange?.Model,
				topmark = this.topmark?.Model,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				radarConspicuous = this.radarConspicuous,
				verticalLength = this.verticalLength,
				colour = this.colour.ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				buoyShape = this.buoyShape,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				colourPattern = this.colourPattern,
				scaleMinimum = this.scaleMinimum,
				pictorialRepresentation = this.pictorialRepresentation,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public IsolatedDangerBuoy Model => new () {
			fixedDateRange = this._fixedDateRange?.Model,
			topmark = this._topmark?.Model,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			radarConspicuous = this._radarConspicuous,
			verticalLength = this._verticalLength,
			colour = this.colour.ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			buoyShape = this._buoyShape,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			colourPattern = this._colourPattern,
			scaleMinimum = this._scaleMinimum,
			pictorialRepresentation = this._pictorialRepresentation,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => IsolatedDangerBuoy._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => IsolatedDangerBuoy._featureBindingDefinitions;

		public override string? ToString() => $"Isolated Danger Buoy";

		public IsolatedDangerBuoyViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
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
	/// A lane where submarines may navigate under water or at the surface.
	/// </summary>
	[CategoryOrder("SubmarineTransitLane",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SubmarineTransitLaneViewModel : FeatureViewModel<SubmarineTransitLane> {
		[Category("SubmarineTransitLane")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private String? _interoperabilityIdentifier  = default;

		[Category("SubmarineTransitLane")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private String? _nationality  = default;

		[Category("SubmarineTransitLane")]
		public String? nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}
		private int? _bottomVerticalSafetySeparation  = default;

		[Category("SubmarineTransitLane")]
		public int? bottomVerticalSafetySeparation {
			get {
				return _bottomVerticalSafetySeparation;
			}
			set {
				SetValue(ref _bottomVerticalSafetySeparation, value);
			}
		}
		[Category("SubmarineTransitLane")]
		public ObservableCollection<vesselSpeedLimitViewModel> vesselSpeedLimit  { get; set; } = new ();
		private String? _controllingAuthority  = default;

		[Category("SubmarineTransitLane")]
		public String? controllingAuthority {
			get {
				return _controllingAuthority;
			}
			set {
				SetValue(ref _controllingAuthority, value);
			}
		}
		[Category("SubmarineTransitLane")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("SubmarineTransitLane")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(restrictionList), typeof(restriction))]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)7,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)27];
		private String? _agencyResponsibleForProduction  = default;

		[Category("SubmarineTransitLane")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private int? _minimumSafeDepth  = default;

		[Category("SubmarineTransitLane")]
		public int? minimumSafeDepth {
			get {
				return _minimumSafeDepth;
			}
			set {
				SetValue(ref _minimumSafeDepth, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("SubmarineTransitLane")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}


		public override FeatureViewModel<SubmarineTransitLane> Load(SubmarineTransitLane instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			nationality = instance.nationality;
			bottomVerticalSafetySeparation = instance.bottomVerticalSafetySeparation;
			vesselSpeedLimit.Clear();
			if (instance.vesselSpeedLimit is not null) {
				foreach(var e in instance.vesselSpeedLimit)
					vesselSpeedLimit.Add(new vesselSpeedLimitViewModel().Load(e));
			}
			controllingAuthority = instance.controllingAuthority;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			restriction.Clear();
			if (instance.restriction is not null) {
				foreach(var e in instance.restriction)
					restriction.Add(e);
			}
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			minimumSafeDepth = instance.minimumSafeDepth;
			scaleMinimum = instance.scaleMinimum;
			return this;
		}

		public override string Serialize() {
			var instance = new SubmarineTransitLane {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				nationality = this.nationality,
				bottomVerticalSafetySeparation = this.bottomVerticalSafetySeparation,
				vesselSpeedLimit = this.vesselSpeedLimit.Select(e => e.Model).ToList(),
				controllingAuthority = this.controllingAuthority,
				information = this.information.Select(e => e.Model).ToList(),
				restriction = this.restriction.ToList(),
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				minimumSafeDepth = this.minimumSafeDepth,
				scaleMinimum = this.scaleMinimum,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SubmarineTransitLane Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			nationality = this._nationality,
			bottomVerticalSafetySeparation = this._bottomVerticalSafetySeparation,
			vesselSpeedLimit = this.vesselSpeedLimit.Select(e => e.Model).ToList(),
			controllingAuthority = this._controllingAuthority,
			information = this.information.Select(e => e.Model).ToList(),
			restriction = this.restriction.ToList(),
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			minimumSafeDepth = this._minimumSafeDepth,
			scaleMinimum = this._scaleMinimum,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => SubmarineTransitLane._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => SubmarineTransitLane._featureBindingDefinitions;

		public override string? ToString() => $"Submarine Transit Lane";

		public SubmarineTransitLaneViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			vesselSpeedLimit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(vesselSpeedLimit));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(restriction));
			};
		}
	}

	/// <summary>
	/// MaritimeSafetyInformationArea (missing definition)
	/// </summary>
	[CategoryOrder("MaritimeSafetyInformationArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class MaritimeSafetyInformationAreaViewModel : FeatureViewModel<MaritimeSafetyInformationArea> {
		private DateOnly? _reportedDate  = default;

		[Category("MaritimeSafetyInformationArea")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("MaritimeSafetyInformationArea")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		[Category("MaritimeSafetyInformationArea")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private String? _agencyResponsibleForProduction  = default;

		[Category("MaritimeSafetyInformationArea")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		[Category("MaritimeSafetyInformationArea")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();


		public override FeatureViewModel<MaritimeSafetyInformationArea> Load(MaritimeSafetyInformationArea instance) {
			reportedDate = instance.reportedDate;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new MaritimeSafetyInformationArea {
				reportedDate = this.reportedDate,
				sourceIdentification = this.sourceIdentification?.Model,
				information = this.information.Select(e => e.Model).ToList(),
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				featureName = this.featureName.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public MaritimeSafetyInformationArea Model => new () {
			reportedDate = this._reportedDate,
			sourceIdentification = this._sourceIdentification?.Model,
			information = this.information.Select(e => e.Model).ToList(),
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			featureName = this.featureName.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => MaritimeSafetyInformationArea._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => MaritimeSafetyInformationArea._featureBindingDefinitions;

		public override string? ToString() => $"MaritimeSafetyInformationArea (missing Name)";

		public MaritimeSafetyInformationAreaViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// The airspace above a designated land or water area through which flight is prohibited or restricted.
	/// </summary>
	[CategoryOrder("AirspaceRestriction",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AirspaceRestrictionViewModel : FeatureViewModel<AirspaceRestriction> {
		[Category("AirspaceRestriction")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private String? _agencyResponsibleForProduction  = default;

		[Category("AirspaceRestriction")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private flightLevelViewModel? _flightLevel  = default;

		[Category("AirspaceRestriction")]
		[ExpandableObject]
		public flightLevelViewModel? flightLevel {
			get {
				return _flightLevel;
			}
			set {
				SetValue(ref _flightLevel, value);
			}
		}
		private String? _controllingAuthority  = default;

		[Category("AirspaceRestriction")]
		public String? controllingAuthority {
			get {
				return _controllingAuthority;
			}
			set {
				SetValue(ref _controllingAuthority, value);
			}
		}
		private altitudeRangeViewModel? _altitudeRange  = default;

		[Category("AirspaceRestriction")]
		[ExpandableObject]
		public altitudeRangeViewModel? altitudeRange {
			get {
				return _altitudeRange;
			}
			set {
				SetValue(ref _altitudeRange, value);
			}
		}
		[Category("AirspaceRestriction")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private verticalDatum? _verticalDatum  = default;

		[Category("AirspaceRestriction")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)3,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)44];
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("AirspaceRestriction")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("AirspaceRestriction")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private heightLengthUnits? _heightLengthUnits  = default;

		[Category("AirspaceRestriction")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(heightLengthUnitsList), typeof(heightLengthUnits))]
		public heightLengthUnits? heightLengthUnits {
			get {
				return _heightLengthUnits;
			}
			set {
				SetValue(ref _heightLengthUnits, value);
			}
		}

		[Browsable(false)]
		public heightLengthUnits[] heightLengthUnitsList => [(heightLengthUnits)2];
		private catagoryOfAirspaceRestriction? _catagoryOfAirspaceRestriction  = default;

		[Category("AirspaceRestriction")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(catagoryOfAirspaceRestrictionList), typeof(catagoryOfAirspaceRestriction))]
		public catagoryOfAirspaceRestriction? catagoryOfAirspaceRestriction {
			get {
				return _catagoryOfAirspaceRestriction;
			}
			set {
				SetValue(ref _catagoryOfAirspaceRestriction, value);
			}
		}

		[Browsable(false)]
		public catagoryOfAirspaceRestriction[] catagoryOfAirspaceRestrictionList => [(catagoryOfAirspaceRestriction)501,(catagoryOfAirspaceRestriction)502,(catagoryOfAirspaceRestriction)503];


		public override FeatureViewModel<AirspaceRestriction> Load(AirspaceRestriction instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			flightLevel = new ();
			if (instance.flightLevel != default) {
				flightLevel.Load(instance.flightLevel);
			}
			controllingAuthority = instance.controllingAuthority;
			altitudeRange = new ();
			if (instance.altitudeRange != default) {
				altitudeRange.Load(instance.altitudeRange);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			verticalDatum = instance.verticalDatum;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			reportedDate = instance.reportedDate;
			heightLengthUnits = instance.heightLengthUnits;
			catagoryOfAirspaceRestriction = instance.catagoryOfAirspaceRestriction;
			return this;
		}

		public override string Serialize() {
			var instance = new AirspaceRestriction {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				flightLevel = this.flightLevel?.Model,
				controllingAuthority = this.controllingAuthority,
				altitudeRange = this.altitudeRange?.Model,
				information = this.information.Select(e => e.Model).ToList(),
				verticalDatum = this.verticalDatum,
				sourceIdentification = this.sourceIdentification?.Model,
				reportedDate = this.reportedDate,
				heightLengthUnits = this.heightLengthUnits,
				catagoryOfAirspaceRestriction = this.catagoryOfAirspaceRestriction,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AirspaceRestriction Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			flightLevel = this._flightLevel?.Model,
			controllingAuthority = this._controllingAuthority,
			altitudeRange = this._altitudeRange?.Model,
			information = this.information.Select(e => e.Model).ToList(),
			verticalDatum = this._verticalDatum,
			sourceIdentification = this._sourceIdentification?.Model,
			reportedDate = this._reportedDate,
			heightLengthUnits = this._heightLengthUnits,
			catagoryOfAirspaceRestriction = this._catagoryOfAirspaceRestriction,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => AirspaceRestriction._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => AirspaceRestriction._featureBindingDefinitions;

		public override string? ToString() => $"Airspace Restriction";

		public AirspaceRestrictionViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// Measured or charted depth of water (may be a drying height), or the measurement of such a depth, which has been reduced to a vertical datum.
	/// </summary>
	[CategoryOrder("Sounding",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SoundingViewModel : FeatureViewModel<Sounding> {
		private status? _status  = default;

		[Category("Sounding")]
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
		public status[] statusList => [(status)18];
		[Category("Sounding")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(techniqueOfVerticalMeasurementList), typeof(techniqueOfVerticalMeasurement))]
		public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1,(techniqueOfVerticalMeasurement)2,(techniqueOfVerticalMeasurement)3,(techniqueOfVerticalMeasurement)4,(techniqueOfVerticalMeasurement)5,(techniqueOfVerticalMeasurement)8,(techniqueOfVerticalMeasurement)9,(techniqueOfVerticalMeasurement)10,(techniqueOfVerticalMeasurement)11,(techniqueOfVerticalMeasurement)12,(techniqueOfVerticalMeasurement)13,(techniqueOfVerticalMeasurement)15,(techniqueOfVerticalMeasurement)16,(techniqueOfVerticalMeasurement)17,(techniqueOfVerticalMeasurement)18];
		private int? _scaleMinimum  = default;

		[Category("Sounding")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("Sounding")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("Sounding")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(qualityOfVerticalMeasurementList), typeof(qualityOfVerticalMeasurement))]
		public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1,(qualityOfVerticalMeasurement)3,(qualityOfVerticalMeasurement)4,(qualityOfVerticalMeasurement)8,(qualityOfVerticalMeasurement)9];
		[Category("Sounding")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("Sounding")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("Sounding")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private Boolean? _displayUncertainties  = default;

		[Category("Sounding")]
		public Boolean? displayUncertainties {
			get {
				return _displayUncertainties;
			}
			set {
				SetValue(ref _displayUncertainties, value);
			}
		}


		public override FeatureViewModel<Sounding> Load(Sounding instance) {
			status = instance.status;
			techniqueOfVerticalMeasurement.Clear();
			if (instance.techniqueOfVerticalMeasurement is not null) {
				foreach(var e in instance.techniqueOfVerticalMeasurement)
					techniqueOfVerticalMeasurement.Add(e);
			}
			scaleMinimum = instance.scaleMinimum;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			qualityOfVerticalMeasurement.Clear();
			if (instance.qualityOfVerticalMeasurement is not null) {
				foreach(var e in instance.qualityOfVerticalMeasurement)
					qualityOfVerticalMeasurement.Add(e);
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			reportedDate = instance.reportedDate;
			displayUncertainties = instance.displayUncertainties;
			return this;
		}

		public override string Serialize() {
			var instance = new Sounding {
				status = this.status,
				techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
				scaleMinimum = this.scaleMinimum,
				information = this.information.Select(e => e.Model).ToList(),
				qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIdentification = this.sourceIdentification?.Model,
				reportedDate = this.reportedDate,
				displayUncertainties = this.displayUncertainties,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Sounding Model => new () {
			status = this._status,
			techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
			scaleMinimum = this._scaleMinimum,
			information = this.information.Select(e => e.Model).ToList(),
			qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIdentification = this._sourceIdentification?.Model,
			reportedDate = this._reportedDate,
			displayUncertainties = this._displayUncertainties,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => Sounding._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => Sounding._featureBindingDefinitions;

		public override string? ToString() => $"Sounding";

		public SoundingViewModel() : base() {
			techniqueOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(techniqueOfVerticalMeasurement));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			qualityOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(qualityOfVerticalMeasurement));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// The outer limit of a traffic lane part or a traffic separation scheme roundabout.
	/// </summary>
	[CategoryOrder("TrafficSeparationSchemeBoundary",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TrafficSeparationSchemeBoundaryViewModel : FeatureViewModel<TrafficSeparationSchemeBoundary> {
		private String? _interoperabilityIdentifier  = default;

		[Category("TrafficSeparationSchemeBoundary")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("TrafficSeparationSchemeBoundary")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)3,(status)9,(status)28];
		private DateOnly? _reportedDate  = default;

		[Category("TrafficSeparationSchemeBoundary")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		[Category("TrafficSeparationSchemeBoundary")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("TrafficSeparationSchemeBoundary")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("TrafficSeparationSchemeBoundary")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("TrafficSeparationSchemeBoundary")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}


		public override FeatureViewModel<TrafficSeparationSchemeBoundary> Load(TrafficSeparationSchemeBoundary instance) {
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			reportedDate = instance.reportedDate;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			scaleMinimum = instance.scaleMinimum;
			return this;
		}

		public override string Serialize() {
			var instance = new TrafficSeparationSchemeBoundary {
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				status = this.status.ToList(),
				reportedDate = this.reportedDate,
				information = this.information.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				sourceIdentification = this.sourceIdentification?.Model,
				scaleMinimum = this.scaleMinimum,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public TrafficSeparationSchemeBoundary Model => new () {
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			status = this.status.ToList(),
			reportedDate = this._reportedDate,
			information = this.information.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			sourceIdentification = this._sourceIdentification?.Model,
			scaleMinimum = this._scaleMinimum,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeBoundary._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeBoundary._featureBindingDefinitions;

		public override string? ToString() => $"Traffic Separation Scheme Boundary";

		public TrafficSeparationSchemeBoundaryViewModel() : base() {
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
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
		[Category("DumpingGround")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfDumpingGroundList), typeof(categoryOfDumpingGround))]
		public ObservableCollection<categoryOfDumpingGround> categoryOfDumpingGround  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfDumpingGround[] categoryOfDumpingGroundList => [(categoryOfDumpingGround)2,(categoryOfDumpingGround)3,(categoryOfDumpingGround)4,(categoryOfDumpingGround)5,(categoryOfDumpingGround)6];
		[Category("DumpingGround")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(restrictionList), typeof(restriction))]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)7,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)27];
		[Category("DumpingGround")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)6,(status)7];
		private int? _scaleMinimum  = default;

		[Category("DumpingGround")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _dateDisused  = default;

		[Category("DumpingGround")]
		public DateOnly? dateDisused {
			get {
				return _dateDisused;
			}
			set {
				SetValue(ref _dateDisused, value);
			}
		}
		[Category("DumpingGround")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("DumpingGround")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override FeatureViewModel<DumpingGround> Load(DumpingGround instance) {
			categoryOfDumpingGround.Clear();
			if (instance.categoryOfDumpingGround is not null) {
				foreach(var e in instance.categoryOfDumpingGround)
					categoryOfDumpingGround.Add(e);
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
			scaleMinimum = instance.scaleMinimum;
			dateDisused = instance.dateDisused;
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
			return this;
		}

		public override string Serialize() {
			var instance = new DumpingGround {
				categoryOfDumpingGround = this.categoryOfDumpingGround.ToList(),
				restriction = this.restriction.ToList(),
				status = this.status.ToList(),
				scaleMinimum = this.scaleMinimum,
				dateDisused = this.dateDisused,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DumpingGround Model => new () {
			categoryOfDumpingGround = this.categoryOfDumpingGround.ToList(),
			restriction = this.restriction.ToList(),
			status = this.status.ToList(),
			scaleMinimum = this._scaleMinimum,
			dateDisused = this._dateDisused,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => DumpingGround._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => DumpingGround._featureBindingDefinitions;

		public override string? ToString() => $"Dumping Ground";

		public DumpingGroundViewModel() : base() {
			categoryOfDumpingGround.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfDumpingGround));
			};
			restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(restriction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// A defined area on land (including any buildings, installations and equipment) intended to be used either wholly or in part for the arrival, departure and surface movement of aircraft.
	/// </summary>
	[CategoryOrder("AirportAirfield",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AirportAirfieldViewModel : FeatureViewModel<AirportAirfield> {
		[Category("AirportAirfield")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfAirportAirfieldList), typeof(categoryOfAirportAirfield))]
		public ObservableCollection<categoryOfAirportAirfield> categoryOfAirportAirfield  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfAirportAirfield[] categoryOfAirportAirfieldList => [(categoryOfAirportAirfield)1,(categoryOfAirportAirfield)2,(categoryOfAirportAirfield)3,(categoryOfAirportAirfield)4,(categoryOfAirportAirfield)5,(categoryOfAirportAirfield)6,(categoryOfAirportAirfield)8,(categoryOfAirportAirfield)9];
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("AirportAirfield")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		[Category("AirportAirfield")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		private condition? _condition  = default;

		[Category("AirportAirfield")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)5];
		private int? _runwayLength  = default;

		[Category("AirportAirfield")]
		public int? runwayLength {
			get {
				return _runwayLength;
			}
			set {
				SetValue(ref _runwayLength, value);
			}
		}
		private heightLengthUnits? _heightLengthUnits  = default;

		[Category("AirportAirfield")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(heightLengthUnitsList), typeof(heightLengthUnits))]
		public heightLengthUnits? heightLengthUnits {
			get {
				return _heightLengthUnits;
			}
			set {
				SetValue(ref _heightLengthUnits, value);
			}
		}

		[Browsable(false)]
		public heightLengthUnits[] heightLengthUnitsList => [(heightLengthUnits)2];
		private int? _scaleMinimum  = default;

		[Category("AirportAirfield")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private String? _controllingAuthority  = default;

		[Category("AirportAirfield")]
		public String? controllingAuthority {
			get {
				return _controllingAuthority;
			}
			set {
				SetValue(ref _controllingAuthority, value);
			}
		}
		private decimal? _elevation  = default;

		[Category("AirportAirfield")]
		public decimal? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}
		private verticalDatum? _verticalDatum  = default;

		[Category("AirportAirfield")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)3,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)44];
		private String? _agencyResponsibleForProduction  = default;

		[Category("AirportAirfield")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("AirportAirfield")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private String? _iCAOcode  = default;

		[Category("AirportAirfield")]
		public String? iCAOcode {
			get {
				return _iCAOcode;
			}
			set {
				SetValue(ref _iCAOcode, value);
			}
		}
		[Category("AirportAirfield")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AirportAirfield")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("AirportAirfield")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)6,(status)7,(status)8,(status)12,(status)14];
		private DateOnly? _reportedDate  = default;

		[Category("AirportAirfield")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		[Category("AirportAirfield")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}


		public override FeatureViewModel<AirportAirfield> Load(AirportAirfield instance) {
			categoryOfAirportAirfield.Clear();
			if (instance.categoryOfAirportAirfield is not null) {
				foreach(var e in instance.categoryOfAirportAirfield)
					categoryOfAirportAirfield.Add(e);
			}
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			condition = instance.condition;
			runwayLength = instance.runwayLength;
			heightLengthUnits = instance.heightLengthUnits;
			scaleMinimum = instance.scaleMinimum;
			controllingAuthority = instance.controllingAuthority;
			elevation = instance.elevation;
			verticalDatum = instance.verticalDatum;
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			pictorialRepresentation = instance.pictorialRepresentation;
			iCAOcode = instance.iCAOcode;
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
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			reportedDate = instance.reportedDate;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			return this;
		}

		public override string Serialize() {
			var instance = new AirportAirfield {
				categoryOfAirportAirfield = this.categoryOfAirportAirfield.ToList(),
				sourceIdentification = this.sourceIdentification?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				condition = this.condition,
				runwayLength = this.runwayLength,
				heightLengthUnits = this.heightLengthUnits,
				scaleMinimum = this.scaleMinimum,
				controllingAuthority = this.controllingAuthority,
				elevation = this.elevation,
				verticalDatum = this.verticalDatum,
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				pictorialRepresentation = this.pictorialRepresentation,
				iCAOcode = this.iCAOcode,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				status = this.status.ToList(),
				reportedDate = this.reportedDate,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AirportAirfield Model => new () {
			categoryOfAirportAirfield = this.categoryOfAirportAirfield.ToList(),
			sourceIdentification = this._sourceIdentification?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			condition = this._condition,
			runwayLength = this._runwayLength,
			heightLengthUnits = this._heightLengthUnits,
			scaleMinimum = this._scaleMinimum,
			controllingAuthority = this._controllingAuthority,
			elevation = this._elevation,
			verticalDatum = this._verticalDatum,
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			pictorialRepresentation = this._pictorialRepresentation,
			iCAOcode = this._iCAOcode,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			status = this.status.ToList(),
			reportedDate = this._reportedDate,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => AirportAirfield._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => AirportAirfield._featureBindingDefinitions;

		public override string? ToString() => $"Airport/Airfield";

		public AirportAirfieldViewModel() : base() {
			categoryOfAirportAirfield.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfAirportAirfield));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
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
	/// Areas over which it is safe to navigate but which should be avoided for anchoring, taking the ground or ground fishing.
	/// </summary>
	[CategoryOrder("FoulGround",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class FoulGroundViewModel : FeatureViewModel<FoulGround> {
		[Category("FoulGround")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)13,(status)18,(status)28];
		private decimal? _valueOfSounding  = default;

		[Category("FoulGround")]
		public decimal? valueOfSounding {
			get {
				return _valueOfSounding;
			}
			set {
				SetValue(ref _valueOfSounding, value);
			}
		}
		[Category("FoulGround")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(qualityOfVerticalMeasurementList), typeof(qualityOfVerticalMeasurement))]
		public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1,(qualityOfVerticalMeasurement)2,(qualityOfVerticalMeasurement)3,(qualityOfVerticalMeasurement)4,(qualityOfVerticalMeasurement)6,(qualityOfVerticalMeasurement)7,(qualityOfVerticalMeasurement)8,(qualityOfVerticalMeasurement)9];
		[Category("FoulGround")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(techniqueOfVerticalMeasurementList), typeof(techniqueOfVerticalMeasurement))]
		public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1,(techniqueOfVerticalMeasurement)2,(techniqueOfVerticalMeasurement)3,(techniqueOfVerticalMeasurement)4,(techniqueOfVerticalMeasurement)5,(techniqueOfVerticalMeasurement)8,(techniqueOfVerticalMeasurement)9,(techniqueOfVerticalMeasurement)10,(techniqueOfVerticalMeasurement)11,(techniqueOfVerticalMeasurement)12,(techniqueOfVerticalMeasurement)13,(techniqueOfVerticalMeasurement)15,(techniqueOfVerticalMeasurement)16,(techniqueOfVerticalMeasurement)17,(techniqueOfVerticalMeasurement)18];
		private DateOnly? _reportedDate  = default;

		[Category("FoulGround")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("FoulGround")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Category("FoulGround")]
		[ExpandableObject]
		public verticalUncertaintyViewModel? verticalUncertainty {
			get {
				return _verticalUncertainty;
			}
			set {
				SetValue(ref _verticalUncertainty, value);
			}
		}
		[Category("FoulGround")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("FoulGround")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override FeatureViewModel<FoulGround> Load(FoulGround instance) {
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			valueOfSounding = instance.valueOfSounding;
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
			reportedDate = instance.reportedDate;
			scaleMinimum = instance.scaleMinimum;
			verticalUncertainty = new ();
			if (instance.verticalUncertainty != default) {
				verticalUncertainty.Load(instance.verticalUncertainty);
			}
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
			return this;
		}

		public override string Serialize() {
			var instance = new FoulGround {
				status = this.status.ToList(),
				valueOfSounding = this.valueOfSounding,
				qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
				techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
				reportedDate = this.reportedDate,
				scaleMinimum = this.scaleMinimum,
				verticalUncertainty = this.verticalUncertainty?.Model,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public FoulGround Model => new () {
			status = this.status.ToList(),
			valueOfSounding = this._valueOfSounding,
			qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
			techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
			reportedDate = this._reportedDate,
			scaleMinimum = this._scaleMinimum,
			verticalUncertainty = this._verticalUncertainty?.Model,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => FoulGround._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => FoulGround._featureBindingDefinitions;

		public override string? ToString() => $"Foul Ground";

		public FoulGroundViewModel() : base() {
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			qualityOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(qualityOfVerticalMeasurement));
			};
			techniqueOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(techniqueOfVerticalMeasurement));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
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
		private String _pictorialRepresentation  = string.Empty;

		[Category("LightAirObstruction")]
		public String pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
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
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("LightAirObstruction")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("LightAirObstruction")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		private rythmOfLightViewModel? _rythmOfLight  = default;

		[Category("LightAirObstruction")]
		[ExpandableObject]
		public rythmOfLightViewModel? rythmOfLight {
			get {
				return _rythmOfLight;
			}
			set {
				SetValue(ref _rythmOfLight, value);
			}
		}
		[Category("LightAirObstruction")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)6,(status)7,(status)8,(status)11,(status)14,(status)15,(status)16,(status)17];
		private int? _scaleMinimum  = default;

		[Category("LightAirObstruction")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
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
		private decimal? _height  = default;

		[Category("LightAirObstruction")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("LightAirObstruction")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private heightLengthUnits? _heightLengthUnits  = default;

		[Category("LightAirObstruction")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(heightLengthUnitsList), typeof(heightLengthUnits))]
		public heightLengthUnits? heightLengthUnits {
			get {
				return _heightLengthUnits;
			}
			set {
				SetValue(ref _heightLengthUnits, value);
			}
		}

		[Browsable(false)]
		public heightLengthUnits[] heightLengthUnitsList => [(heightLengthUnits)1];
		[Category("LightAirObstruction")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(lightVisibilityList), typeof(lightVisibility))]
		public ObservableCollection<lightVisibility> lightVisibility  { get; set; } = new ();

		[Browsable(false)]
		public lightVisibility[] lightVisibilityList => [(lightVisibility)1,(lightVisibility)2,(lightVisibility)3,(lightVisibility)4,(lightVisibility)5,(lightVisibility)6,(lightVisibility)7,(lightVisibility)8,(lightVisibility)9];
		[Category("LightAirObstruction")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private decimal? _relativeHorizontalAccuracy  = default;

		[Category("LightAirObstruction")]
		public decimal? relativeHorizontalAccuracy {
			get {
				return _relativeHorizontalAccuracy;
			}
			set {
				SetValue(ref _relativeHorizontalAccuracy, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("LightAirObstruction")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		[Category("LightAirObstruction")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private verticalDatum? _verticalDatum  = default;

		[Category("LightAirObstruction")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)3,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)44];
		private decimal? _relativeVerticalAccuracy  = default;

		[Category("LightAirObstruction")]
		public decimal? relativeVerticalAccuracy {
			get {
				return _relativeVerticalAccuracy;
			}
			set {
				SetValue(ref _relativeVerticalAccuracy, value);
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
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("LightAirObstruction")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)3,(colour)4,(colour)5,(colour)6,(colour)9,(colour)10,(colour)11];


		public override FeatureViewModel<LightAirObstruction> Load(LightAirObstruction instance) {
			pictorialRepresentation = instance.pictorialRepresentation;
			valueOfNominalRange = instance.valueOfNominalRange;
			multiplicityOfFeatures = new ();
			if (instance.multiplicityOfFeatures != default) {
				multiplicityOfFeatures.Load(instance.multiplicityOfFeatures);
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
			rythmOfLight = new ();
			if (instance.rythmOfLight != default) {
				rythmOfLight.Load(instance.rythmOfLight);
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			scaleMinimum = instance.scaleMinimum;
			flareBearing = instance.flareBearing;
			height = instance.height;
			reportedDate = instance.reportedDate;
			heightLengthUnits = instance.heightLengthUnits;
			lightVisibility.Clear();
			if (instance.lightVisibility is not null) {
				foreach(var e in instance.lightVisibility)
					lightVisibility.Add(e);
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			relativeHorizontalAccuracy = instance.relativeHorizontalAccuracy;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			verticalDatum = instance.verticalDatum;
			relativeVerticalAccuracy = instance.relativeVerticalAccuracy;
			exhibitionConditionOfLight = instance.exhibitionConditionOfLight;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new LightAirObstruction {
				pictorialRepresentation = this.pictorialRepresentation,
				valueOfNominalRange = this.valueOfNominalRange,
				multiplicityOfFeatures = this.multiplicityOfFeatures?.Model,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				rythmOfLight = this.rythmOfLight?.Model,
				status = this.status.ToList(),
				scaleMinimum = this.scaleMinimum,
				flareBearing = this.flareBearing,
				height = this.height,
				reportedDate = this.reportedDate,
				heightLengthUnits = this.heightLengthUnits,
				lightVisibility = this.lightVisibility.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				relativeHorizontalAccuracy = this.relativeHorizontalAccuracy,
				sourceIdentification = this.sourceIdentification?.Model,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				verticalDatum = this.verticalDatum,
				relativeVerticalAccuracy = this.relativeVerticalAccuracy,
				exhibitionConditionOfLight = this.exhibitionConditionOfLight,
				information = this.information.Select(e => e.Model).ToList(),
				colour = this.colour.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LightAirObstruction Model => new () {
			pictorialRepresentation = this._pictorialRepresentation,
			valueOfNominalRange = this._valueOfNominalRange,
			multiplicityOfFeatures = this._multiplicityOfFeatures?.Model,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			rythmOfLight = this._rythmOfLight?.Model,
			status = this.status.ToList(),
			scaleMinimum = this._scaleMinimum,
			flareBearing = this._flareBearing,
			height = this._height,
			reportedDate = this._reportedDate,
			heightLengthUnits = this._heightLengthUnits,
			lightVisibility = this.lightVisibility.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			relativeHorizontalAccuracy = this._relativeHorizontalAccuracy,
			sourceIdentification = this._sourceIdentification?.Model,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			verticalDatum = this._verticalDatum,
			relativeVerticalAccuracy = this._relativeVerticalAccuracy,
			exhibitionConditionOfLight = this._exhibitionConditionOfLight,
			information = this.information.Select(e => e.Model).ToList(),
			colour = this.colour.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => LightAirObstruction._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => LightAirObstruction._featureBindingDefinitions;

		public override string? ToString() => $"Light Air Obstruction";

		public LightAirObstructionViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			lightVisibility.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(lightVisibility));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
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
		private decimal? _maximumPermittedVesselLength  = default;

		[Category("MooringBuoy")]
		public decimal? maximumPermittedVesselLength {
			get {
				return _maximumPermittedVesselLength;
			}
			set {
				SetValue(ref _maximumPermittedVesselLength, value);
			}
		}
		private decimal? _maximumPermittedDraught  = default;

		[Category("MooringBuoy")]
		public decimal? maximumPermittedDraught {
			get {
				return _maximumPermittedDraught;
			}
			set {
				SetValue(ref _maximumPermittedDraught, value);
			}
		}
		[Category("MooringBuoy")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("MooringBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)11];
		private colourPattern? _colourPattern  = default;

		[Category("MooringBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public colourPattern? colourPattern {
			get {
				return _colourPattern;
			}
			set {
				SetValue(ref _colourPattern, value);
			}
		}

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6];
		[Category("MooringBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("MooringBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)18];
		[Category("MooringBuoy")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("MooringBuoy")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private buoyShape _buoyShape ;

		[Category("MooringBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		private decimal? _verticalLength  = default;

		[Category("MooringBuoy")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("MooringBuoy")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private Boolean? _visitorsMooring  = default;

		[Category("MooringBuoy")]
		public Boolean? visitorsMooring {
			get {
				return _visitorsMooring;
			}
			set {
				SetValue(ref _visitorsMooring, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		[Category("MooringBuoy")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("MooringBuoy")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("MooringBuoy")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}


		public override FeatureViewModel<MooringBuoy> Load(MooringBuoy instance) {
			maximumPermittedVesselLength = instance.maximumPermittedVesselLength;
			maximumPermittedDraught = instance.maximumPermittedDraught;
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			colourPattern = instance.colourPattern;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			buoyShape = instance.buoyShape;
			verticalLength = instance.verticalLength;
			pictorialRepresentation = instance.pictorialRepresentation;
			visitorsMooring = instance.visitorsMooring;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new MooringBuoy {
				maximumPermittedVesselLength = this.maximumPermittedVesselLength,
				maximumPermittedDraught = this.maximumPermittedDraught,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				natureOfConstruction = this.natureOfConstruction.ToList(),
				colourPattern = this.colourPattern,
				colour = this.colour.ToList(),
				status = this.status.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				buoyShape = this.buoyShape,
				verticalLength = this.verticalLength,
				pictorialRepresentation = this.pictorialRepresentation,
				visitorsMooring = this.visitorsMooring,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public MooringBuoy Model => new () {
			maximumPermittedVesselLength = this._maximumPermittedVesselLength,
			maximumPermittedDraught = this._maximumPermittedDraught,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			natureOfConstruction = this.natureOfConstruction.ToList(),
			colourPattern = this._colourPattern,
			colour = this.colour.ToList(),
			status = this.status.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			buoyShape = this._buoyShape,
			verticalLength = this._verticalLength,
			pictorialRepresentation = this._pictorialRepresentation,
			visitorsMooring = this._visitorsMooring,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => MooringBuoy._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => MooringBuoy._featureBindingDefinitions;

		public override string? ToString() => $"Mooring Buoy";

		public MooringBuoyViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// A concreted mass of stony material or coral which dries, is awash or is below the water surface.
	/// </summary>
	[CategoryOrder("UnderwaterAwashRock",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class UnderwaterAwashRockViewModel : FeatureViewModel<UnderwaterAwashRock> {
		private decimal _valueOfSounding ;

		[Category("UnderwaterAwashRock")]
		public decimal valueOfSounding {
			get {
				return _valueOfSounding;
			}
			set {
				SetValue(ref _valueOfSounding, value);
			}
		}
		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Category("UnderwaterAwashRock")]
		[ExpandableObject]
		public verticalUncertaintyViewModel? verticalUncertainty {
			get {
				return _verticalUncertainty;
			}
			set {
				SetValue(ref _verticalUncertainty, value);
			}
		}
		private decimal? _horizontalWidth  = default;

		[Category("UnderwaterAwashRock")]
		public decimal? horizontalWidth {
			get {
				return _horizontalWidth;
			}
			set {
				SetValue(ref _horizontalWidth, value);
			}
		}
		private waterLevelEffect _waterLevelEffect ;

		[Category("UnderwaterAwashRock")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(waterLevelEffectList), typeof(waterLevelEffect))]
		public waterLevelEffect waterLevelEffect {
			get {
				return _waterLevelEffect;
			}
			set {
				SetValue(ref _waterLevelEffect, value);
			}
		}

		[Browsable(false)]
		public waterLevelEffect[] waterLevelEffectList => [(waterLevelEffect)3,(waterLevelEffect)4,(waterLevelEffect)5];
		private decimal? _surroundingDepth  = default;

		[Category("UnderwaterAwashRock")]
		public decimal? surroundingDepth {
			get {
				return _surroundingDepth;
			}
			set {
				SetValue(ref _surroundingDepth, value);
			}
		}
		[Category("UnderwaterAwashRock")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private natureOfSurface? _natureOfSurface  = default;

		[Category("UnderwaterAwashRock")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfSurfaceList), typeof(natureOfSurface))]
		public natureOfSurface? natureOfSurface {
			get {
				return _natureOfSurface;
			}
			set {
				SetValue(ref _natureOfSurface, value);
			}
		}

		[Browsable(false)]
		public natureOfSurface[] natureOfSurfaceList => [(natureOfSurface)14,(natureOfSurface)18];
		private int? _scaleMinimum  = default;

		[Category("UnderwaterAwashRock")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private Boolean? _displayUncertainties  = default;

		[Category("UnderwaterAwashRock")]
		public Boolean? displayUncertainties {
			get {
				return _displayUncertainties;
			}
			set {
				SetValue(ref _displayUncertainties, value);
			}
		}
		private expositionOfSounding? _expositionOfSounding  = default;

		[Category("UnderwaterAwashRock")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(expositionOfSoundingList), typeof(expositionOfSounding))]
		public expositionOfSounding? expositionOfSounding {
			get {
				return _expositionOfSounding;
			}
			set {
				SetValue(ref _expositionOfSounding, value);
			}
		}

		[Browsable(false)]
		public expositionOfSounding[] expositionOfSoundingList => [(expositionOfSounding)1,(expositionOfSounding)2];
		private decimal? _defaultClearanceDepth  = default;

		[Category("UnderwaterAwashRock")]
		public decimal? defaultClearanceDepth {
			get {
				return _defaultClearanceDepth;
			}
			set {
				SetValue(ref _defaultClearanceDepth, value);
			}
		}
		[Category("UnderwaterAwashRock")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)18];
		[Category("UnderwaterAwashRock")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(techniqueOfVerticalMeasurementList), typeof(techniqueOfVerticalMeasurement))]
		public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1,(techniqueOfVerticalMeasurement)2,(techniqueOfVerticalMeasurement)3,(techniqueOfVerticalMeasurement)4,(techniqueOfVerticalMeasurement)5,(techniqueOfVerticalMeasurement)8,(techniqueOfVerticalMeasurement)9,(techniqueOfVerticalMeasurement)10,(techniqueOfVerticalMeasurement)11,(techniqueOfVerticalMeasurement)12,(techniqueOfVerticalMeasurement)13,(techniqueOfVerticalMeasurement)15,(techniqueOfVerticalMeasurement)16,(techniqueOfVerticalMeasurement)17,(techniqueOfVerticalMeasurement)18];
		private decimal? _verticalLength  = default;

		[Category("UnderwaterAwashRock")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		[Category("UnderwaterAwashRock")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private decimal? _horizontalLength  = default;

		[Category("UnderwaterAwashRock")]
		public decimal? horizontalLength {
			get {
				return _horizontalLength;
			}
			set {
				SetValue(ref _horizontalLength, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("UnderwaterAwashRock")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("UnderwaterAwashRock")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private firstSourceInformationViewModel? _firstSourceInformation  = default;

		[Category("UnderwaterAwashRock")]
		[ExpandableObject]
		public firstSourceInformationViewModel? firstSourceInformation {
			get {
				return _firstSourceInformation;
			}
			set {
				SetValue(ref _firstSourceInformation, value);
			}
		}
		private lastSourceInformationViewModel? _lastSourceInformation  = default;

		[Category("UnderwaterAwashRock")]
		[ExpandableObject]
		public lastSourceInformationViewModel? lastSourceInformation {
			get {
				return _lastSourceInformation;
			}
			set {
				SetValue(ref _lastSourceInformation, value);
			}
		}
		private qualityOfVerticalMeasurement? _qualityOfVerticalMeasurement  = default;

		[Category("UnderwaterAwashRock")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(qualityOfVerticalMeasurementList), typeof(qualityOfVerticalMeasurement))]
		public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement {
			get {
				return _qualityOfVerticalMeasurement;
			}
			set {
				SetValue(ref _qualityOfVerticalMeasurement, value);
			}
		}

		[Browsable(false)]
		public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1,(qualityOfVerticalMeasurement)2,(qualityOfVerticalMeasurement)3,(qualityOfVerticalMeasurement)4,(qualityOfVerticalMeasurement)6,(qualityOfVerticalMeasurement)7,(qualityOfVerticalMeasurement)8,(qualityOfVerticalMeasurement)9];


		public override FeatureViewModel<UnderwaterAwashRock> Load(UnderwaterAwashRock instance) {
			valueOfSounding = instance.valueOfSounding;
			verticalUncertainty = new ();
			if (instance.verticalUncertainty != default) {
				verticalUncertainty.Load(instance.verticalUncertainty);
			}
			horizontalWidth = instance.horizontalWidth;
			waterLevelEffect = instance.waterLevelEffect;
			surroundingDepth = instance.surroundingDepth;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			natureOfSurface = instance.natureOfSurface;
			scaleMinimum = instance.scaleMinimum;
			displayUncertainties = instance.displayUncertainties;
			expositionOfSounding = instance.expositionOfSounding;
			defaultClearanceDepth = instance.defaultClearanceDepth;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			techniqueOfVerticalMeasurement.Clear();
			if (instance.techniqueOfVerticalMeasurement is not null) {
				foreach(var e in instance.techniqueOfVerticalMeasurement)
					techniqueOfVerticalMeasurement.Add(e);
			}
			verticalLength = instance.verticalLength;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			horizontalLength = instance.horizontalLength;
			reportedDate = instance.reportedDate;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			firstSourceInformation = new ();
			if (instance.firstSourceInformation != default) {
				firstSourceInformation.Load(instance.firstSourceInformation);
			}
			lastSourceInformation = new ();
			if (instance.lastSourceInformation != default) {
				lastSourceInformation.Load(instance.lastSourceInformation);
			}
			qualityOfVerticalMeasurement = instance.qualityOfVerticalMeasurement;
			return this;
		}

		public override string Serialize() {
			var instance = new UnderwaterAwashRock {
				valueOfSounding = this.valueOfSounding,
				verticalUncertainty = this.verticalUncertainty?.Model,
				horizontalWidth = this.horizontalWidth,
				waterLevelEffect = this.waterLevelEffect,
				surroundingDepth = this.surroundingDepth,
				information = this.information.Select(e => e.Model).ToList(),
				natureOfSurface = this.natureOfSurface,
				scaleMinimum = this.scaleMinimum,
				displayUncertainties = this.displayUncertainties,
				expositionOfSounding = this.expositionOfSounding,
				defaultClearanceDepth = this.defaultClearanceDepth,
				status = this.status.ToList(),
				techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
				verticalLength = this.verticalLength,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				horizontalLength = this.horizontalLength,
				reportedDate = this.reportedDate,
				sourceIdentification = this.sourceIdentification?.Model,
				firstSourceInformation = this.firstSourceInformation?.Model,
				lastSourceInformation = this.lastSourceInformation?.Model,
				qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public UnderwaterAwashRock Model => new () {
			valueOfSounding = this._valueOfSounding,
			verticalUncertainty = this._verticalUncertainty?.Model,
			horizontalWidth = this._horizontalWidth,
			waterLevelEffect = this._waterLevelEffect,
			surroundingDepth = this._surroundingDepth,
			information = this.information.Select(e => e.Model).ToList(),
			natureOfSurface = this._natureOfSurface,
			scaleMinimum = this._scaleMinimum,
			displayUncertainties = this._displayUncertainties,
			expositionOfSounding = this._expositionOfSounding,
			defaultClearanceDepth = this._defaultClearanceDepth,
			status = this.status.ToList(),
			techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
			verticalLength = this._verticalLength,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			horizontalLength = this._horizontalLength,
			reportedDate = this._reportedDate,
			sourceIdentification = this._sourceIdentification?.Model,
			firstSourceInformation = this._firstSourceInformation?.Model,
			lastSourceInformation = this._lastSourceInformation?.Model,
			qualityOfVerticalMeasurement = this._qualityOfVerticalMeasurement,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => UnderwaterAwashRock._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => UnderwaterAwashRock._featureBindingDefinitions;

		public override string? ToString() => $"Underwater/Awash Rock";

		public UnderwaterAwashRockViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			techniqueOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(techniqueOfVerticalMeasurement));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// A single continuous rope-like bundle consisting of multiple strands of fiber, plastic, metal, and/or glass, which is supported by structures such as poles or pylons and passing over or nearby navigable waters.
	/// </summary>
	[CategoryOrder("CableOverhead",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CableOverheadViewModel : FeatureViewModel<CableOverhead> {
		private condition? _condition  = default;

		[Category("CableOverhead")]
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
		public condition[] conditionList => [(condition)1,(condition)5];
		[Category("CableOverhead")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)4,(status)5,(status)7,(status)12,(status)28];
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("CableOverhead")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private verticalDatum? _verticalDatum  = default;

		[Category("CableOverhead")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)3,(verticalDatum)13,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)44];
		private categoryOfCable? _categoryOfCable  = default;

		[Category("CableOverhead")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfCableList), typeof(categoryOfCable))]
		public categoryOfCable? categoryOfCable {
			get {
				return _categoryOfCable;
			}
			set {
				SetValue(ref _categoryOfCable, value);
			}
		}

		[Browsable(false)]
		public categoryOfCable[] categoryOfCableList => [(categoryOfCable)1,(categoryOfCable)3];
		private verticalClearanceSafeViewModel? _verticalClearanceSafe  = default;

		[Category("CableOverhead")]
		[ExpandableObject]
		public verticalClearanceSafeViewModel? verticalClearanceSafe {
			get {
				return _verticalClearanceSafe;
			}
			set {
				SetValue(ref _verticalClearanceSafe, value);
			}
		}
		[Category("CableOverhead")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private DateOnly? _reportedDate  = default;

		[Category("CableOverhead")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private verticalClearanceFixedViewModel? _verticalClearanceFixed  = default;

		[Category("CableOverhead")]
		[ExpandableObject]
		public verticalClearanceFixedViewModel? verticalClearanceFixed {
			get {
				return _verticalClearanceFixed;
			}
			set {
				SetValue(ref _verticalClearanceFixed, value);
			}
		}
		private multiplicityOfFeaturesViewModel? _multiplicityOfFeatures  = default;

		[Category("CableOverhead")]
		[ExpandableObject]
		public multiplicityOfFeaturesViewModel? multiplicityOfFeatures {
			get {
				return _multiplicityOfFeatures;
			}
			set {
				SetValue(ref _multiplicityOfFeatures, value);
			}
		}
		private visualProminence? _visualProminence  = default;

		[Category("CableOverhead")]
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
		[Category("CableOverhead")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("CableOverhead")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private Boolean? _radarConspicuous  = default;

		[Category("CableOverhead")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		private decimal? _iceFactor  = default;

		[Category("CableOverhead")]
		public decimal? iceFactor {
			get {
				return _iceFactor;
			}
			set {
				SetValue(ref _iceFactor, value);
			}
		}


		public override FeatureViewModel<CableOverhead> Load(CableOverhead instance) {
			condition = instance.condition;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			verticalDatum = instance.verticalDatum;
			categoryOfCable = instance.categoryOfCable;
			verticalClearanceSafe = new ();
			if (instance.verticalClearanceSafe != default) {
				verticalClearanceSafe.Load(instance.verticalClearanceSafe);
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			reportedDate = instance.reportedDate;
			verticalClearanceFixed = new ();
			if (instance.verticalClearanceFixed != default) {
				verticalClearanceFixed.Load(instance.verticalClearanceFixed);
			}
			multiplicityOfFeatures = new ();
			if (instance.multiplicityOfFeatures != default) {
				multiplicityOfFeatures.Load(instance.multiplicityOfFeatures);
			}
			visualProminence = instance.visualProminence;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			radarConspicuous = instance.radarConspicuous;
			iceFactor = instance.iceFactor;
			return this;
		}

		public override string Serialize() {
			var instance = new CableOverhead {
				condition = this.condition,
				status = this.status.ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				verticalDatum = this.verticalDatum,
				categoryOfCable = this.categoryOfCable,
				verticalClearanceSafe = this.verticalClearanceSafe?.Model,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				reportedDate = this.reportedDate,
				verticalClearanceFixed = this.verticalClearanceFixed?.Model,
				multiplicityOfFeatures = this.multiplicityOfFeatures?.Model,
				visualProminence = this.visualProminence,
				information = this.information.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				radarConspicuous = this.radarConspicuous,
				iceFactor = this.iceFactor,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CableOverhead Model => new () {
			condition = this._condition,
			status = this.status.ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			verticalDatum = this._verticalDatum,
			categoryOfCable = this._categoryOfCable,
			verticalClearanceSafe = this._verticalClearanceSafe?.Model,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			reportedDate = this._reportedDate,
			verticalClearanceFixed = this._verticalClearanceFixed?.Model,
			multiplicityOfFeatures = this._multiplicityOfFeatures?.Model,
			visualProminence = this._visualProminence,
			information = this.information.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			radarConspicuous = this._radarConspicuous,
			iceFactor = this._iceFactor,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => CableOverhead._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => CableOverhead._featureBindingDefinitions;

		public override string? ToString() => $"Cable Overhead";

		public CableOverheadViewModel() : base() {
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// Designated airspace within which some or all aircraft may be subjected to air traffic control.
	/// </summary>
	[CategoryOrder("ControlledAirspace",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ControlledAirspaceViewModel : FeatureViewModel<ControlledAirspace> {
		private controlledAirspaceClassDesignation? _controlledAirspaceClassDesignation  = default;

		[Category("ControlledAirspace")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(controlledAirspaceClassDesignationList), typeof(controlledAirspaceClassDesignation))]
		public controlledAirspaceClassDesignation? controlledAirspaceClassDesignation {
			get {
				return _controlledAirspaceClassDesignation;
			}
			set {
				SetValue(ref _controlledAirspaceClassDesignation, value);
			}
		}

		[Browsable(false)]
		public controlledAirspaceClassDesignation[] controlledAirspaceClassDesignationList => [(controlledAirspaceClassDesignation)501,(controlledAirspaceClassDesignation)502,(controlledAirspaceClassDesignation)503,(controlledAirspaceClassDesignation)504,(controlledAirspaceClassDesignation)505,(controlledAirspaceClassDesignation)506,(controlledAirspaceClassDesignation)507];
		[Category("ControlledAirspace")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("ControlledAirspace")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private categoryOfControlledAirspace? _categoryOfControlledAirspace  = default;

		[Category("ControlledAirspace")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfControlledAirspaceList), typeof(categoryOfControlledAirspace))]
		public categoryOfControlledAirspace? categoryOfControlledAirspace {
			get {
				return _categoryOfControlledAirspace;
			}
			set {
				SetValue(ref _categoryOfControlledAirspace, value);
			}
		}

		[Browsable(false)]
		public categoryOfControlledAirspace[] categoryOfControlledAirspaceList => [(categoryOfControlledAirspace)501,(categoryOfControlledAirspace)502,(categoryOfControlledAirspace)503,(categoryOfControlledAirspace)504,(categoryOfControlledAirspace)505,(categoryOfControlledAirspace)506,(categoryOfControlledAirspace)507,(categoryOfControlledAirspace)508,(categoryOfControlledAirspace)509,(categoryOfControlledAirspace)510,(categoryOfControlledAirspace)511,(categoryOfControlledAirspace)512,(categoryOfControlledAirspace)513,(categoryOfControlledAirspace)514,(categoryOfControlledAirspace)515,(categoryOfControlledAirspace)516,(categoryOfControlledAirspace)517,(categoryOfControlledAirspace)518,(categoryOfControlledAirspace)519,(categoryOfControlledAirspace)520,(categoryOfControlledAirspace)521,(categoryOfControlledAirspace)522];
		private String? _controllingAuthority  = default;

		[Category("ControlledAirspace")]
		public String? controllingAuthority {
			get {
				return _controllingAuthority;
			}
			set {
				SetValue(ref _controllingAuthority, value);
			}
		}
		private altitudeViewModel? _altitude  = default;

		[Category("ControlledAirspace")]
		[ExpandableObject]
		public altitudeViewModel? altitude {
			get {
				return _altitude;
			}
			set {
				SetValue(ref _altitude, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("ControlledAirspace")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private verticalDatum? _verticalDatum  = default;

		[Category("ControlledAirspace")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)3,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)44];
		private heightLengthUnits? _heightLengthUnits  = default;

		[Category("ControlledAirspace")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(heightLengthUnitsList), typeof(heightLengthUnits))]
		public heightLengthUnits? heightLengthUnits {
			get {
				return _heightLengthUnits;
			}
			set {
				SetValue(ref _heightLengthUnits, value);
			}
		}

		[Browsable(false)]
		public heightLengthUnits[] heightLengthUnitsList => [(heightLengthUnits)2];
		private String? _agencyResponsibleForProduction  = default;

		[Category("ControlledAirspace")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("ControlledAirspace")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private flightLevelViewModel? _flightLevel  = default;

		[Category("ControlledAirspace")]
		[ExpandableObject]
		public flightLevelViewModel? flightLevel {
			get {
				return _flightLevel;
			}
			set {
				SetValue(ref _flightLevel, value);
			}
		}


		public override FeatureViewModel<ControlledAirspace> Load(ControlledAirspace instance) {
			controlledAirspaceClassDesignation = instance.controlledAirspaceClassDesignation;
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
			categoryOfControlledAirspace = instance.categoryOfControlledAirspace;
			controllingAuthority = instance.controllingAuthority;
			altitude = new ();
			if (instance.altitude != default) {
				altitude.Load(instance.altitude);
			}
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			verticalDatum = instance.verticalDatum;
			heightLengthUnits = instance.heightLengthUnits;
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			reportedDate = instance.reportedDate;
			flightLevel = new ();
			if (instance.flightLevel != default) {
				flightLevel.Load(instance.flightLevel);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new ControlledAirspace {
				controlledAirspaceClassDesignation = this.controlledAirspaceClassDesignation,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				categoryOfControlledAirspace = this.categoryOfControlledAirspace,
				controllingAuthority = this.controllingAuthority,
				altitude = this.altitude?.Model,
				sourceIdentification = this.sourceIdentification?.Model,
				verticalDatum = this.verticalDatum,
				heightLengthUnits = this.heightLengthUnits,
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				reportedDate = this.reportedDate,
				flightLevel = this.flightLevel?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ControlledAirspace Model => new () {
			controlledAirspaceClassDesignation = this._controlledAirspaceClassDesignation,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			categoryOfControlledAirspace = this._categoryOfControlledAirspace,
			controllingAuthority = this._controllingAuthority,
			altitude = this._altitude?.Model,
			sourceIdentification = this._sourceIdentification?.Model,
			verticalDatum = this._verticalDatum,
			heightLengthUnits = this._heightLengthUnits,
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			reportedDate = this._reportedDate,
			flightLevel = this._flightLevel?.Model,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => ControlledAirspace._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => ControlledAirspace._featureBindingDefinitions;

		public override string? ToString() => $"Controlled Airspace";

		public ControlledAirspaceViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// In marine navigation, anything that hinders or prevents movement, particularly anything that endangers or prevents passage of a vessel. The term is usually used to refer to an isolated danger to navigation, such as a sunken rock or pinnacle.
	/// </summary>
	[CategoryOrder("Obstruction",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ObstructionViewModel : FeatureViewModel<Obstruction> {
		[Category("Obstruction")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)11,(natureOfConstruction)12];
		private String? _controllingAuthority  = default;

		[Category("Obstruction")]
		public String? controllingAuthority {
			get {
				return _controllingAuthority;
			}
			set {
				SetValue(ref _controllingAuthority, value);
			}
		}
		[Category("Obstruction")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(productList), typeof(product))]
		public ObservableCollection<product> product  { get; set; } = new ();

		[Browsable(false)]
		public product[] productList => [(product)1,(product)3,(product)4,(product)5,(product)6,(product)7,(product)8,(product)9,(product)10,(product)11,(product)12,(product)13,(product)14,(product)15,(product)16,(product)17,(product)18,(product)19,(product)20,(product)21,(product)22,(product)23,(product)25,(product)502,(product)503,(product)505,(product)506,(product)507,(product)508,(product)509,(product)510,(product)511,(product)513,(product)514,(product)515,(product)516,(product)517,(product)519,(product)520,(product)521,(product)522,(product)523,(product)524,(product)525,(product)526,(product)527,(product)528,(product)529,(product)530,(product)531,(product)532,(product)533,(product)534,(product)535,(product)536,(product)537,(product)540,(product)541,(product)542];
		private Boolean? _existenceOfRestrictedArea  = default;

		[Category("Obstruction")]
		public Boolean? existenceOfRestrictedArea {
			get {
				return _existenceOfRestrictedArea;
			}
			set {
				SetValue(ref _existenceOfRestrictedArea, value);
			}
		}
		private decimal? _horizontalDistanceUncertainty  = default;

		[Category("Obstruction")]
		public decimal? horizontalDistanceUncertainty {
			get {
				return _horizontalDistanceUncertainty;
			}
			set {
				SetValue(ref _horizontalDistanceUncertainty, value);
			}
		}
		private lastSourceInformationViewModel? _lastSourceInformation  = default;

		[Category("Obstruction")]
		[ExpandableObject]
		public lastSourceInformationViewModel? lastSourceInformation {
			get {
				return _lastSourceInformation;
			}
			set {
				SetValue(ref _lastSourceInformation, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("Obstruction")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private expositionOfSounding? _expositionOfSounding  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(expositionOfSoundingList), typeof(expositionOfSounding))]
		public expositionOfSounding? expositionOfSounding {
			get {
				return _expositionOfSounding;
			}
			set {
				SetValue(ref _expositionOfSounding, value);
			}
		}

		[Browsable(false)]
		public expositionOfSounding[] expositionOfSoundingList => [(expositionOfSounding)1,(expositionOfSounding)2,(expositionOfSounding)3];
		private firstSourceInformationViewModel? _firstSourceInformation  = default;

		[Category("Obstruction")]
		[ExpandableObject]
		public firstSourceInformationViewModel? firstSourceInformation {
			get {
				return _firstSourceInformation;
			}
			set {
				SetValue(ref _firstSourceInformation, value);
			}
		}
		private DateOnly? _abandonmentDate  = default;

		[Category("Obstruction")]
		public DateOnly? abandonmentDate {
			get {
				return _abandonmentDate;
			}
			set {
				SetValue(ref _abandonmentDate, value);
			}
		}
		private decimal? _verticalLength  = default;

		[Category("Obstruction")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private decimal? _soundingDepth  = default;

		[Category("Obstruction")]
		public decimal? soundingDepth {
			get {
				return _soundingDepth;
			}
			set {
				SetValue(ref _soundingDepth, value);
			}
		}
		private orientationViewModel? _orientation  = default;

		[Category("Obstruction")]
		[ExpandableObject]
		public orientationViewModel? orientation {
			get {
				return _orientation;
			}
			set {
				SetValue(ref _orientation, value);
			}
		}
		private soundingDatum? _soundingDatum  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(soundingDatumList), typeof(soundingDatum))]
		public soundingDatum? soundingDatum {
			get {
				return _soundingDatum;
			}
			set {
				SetValue(ref _soundingDatum, value);
			}
		}

		[Browsable(false)]
		public soundingDatum[] soundingDatumList => [(soundingDatum)501,(soundingDatum)502,(soundingDatum)503,(soundingDatum)504,(soundingDatum)505,(soundingDatum)506,(soundingDatum)507,(soundingDatum)508,(soundingDatum)509,(soundingDatum)510,(soundingDatum)511,(soundingDatum)512,(soundingDatum)513,(soundingDatum)514,(soundingDatum)515,(soundingDatum)519,(soundingDatum)522,(soundingDatum)523,(soundingDatum)524,(soundingDatum)525,(soundingDatum)526,(soundingDatum)527,(soundingDatum)531,(soundingDatum)532];
		[Category("Obstruction")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private magneticInformationViewModel? _magneticInformation  = default;

		[Category("Obstruction")]
		[ExpandableObject]
		public magneticInformationViewModel? magneticInformation {
			get {
				return _magneticInformation;
			}
			set {
				SetValue(ref _magneticInformation, value);
			}
		}
		private decimal? _horizontalWidth  = default;

		[Category("Obstruction")]
		public decimal? horizontalWidth {
			get {
				return _horizontalWidth;
			}
			set {
				SetValue(ref _horizontalWidth, value);
			}
		}
		[Category("Obstruction")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)4,(status)5,(status)7,(status)8,(status)13,(status)18,(status)28,(status)501,(status)503,(status)505,(status)506,(status)507,(status)508,(status)509,(status)510,(status)511,(status)512,(status)516,(status)517,(status)518];
		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Category("Obstruction")]
		[ExpandableObject]
		public verticalUncertaintyViewModel? verticalUncertainty {
			get {
				return _verticalUncertainty;
			}
			set {
				SetValue(ref _verticalUncertainty, value);
			}
		}
		private condition? _condition  = default;

		[Category("Obstruction")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)5];
		private int? _generalWaterDepth  = default;

		[Category("Obstruction")]
		public int? generalWaterDepth {
			get {
				return _generalWaterDepth;
			}
			set {
				SetValue(ref _generalWaterDepth, value);
			}
		}
		[Category("Obstruction")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(qualityOfVerticalMeasurementList), typeof(qualityOfVerticalMeasurement))]
		public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1,(qualityOfVerticalMeasurement)2,(qualityOfVerticalMeasurement)3,(qualityOfVerticalMeasurement)4,(qualityOfVerticalMeasurement)6,(qualityOfVerticalMeasurement)7,(qualityOfVerticalMeasurement)8,(qualityOfVerticalMeasurement)9];
		private detectionDateRangeViewModel? _detectionDateRange  = default;

		[Category("Obstruction")]
		[ExpandableObject]
		public detectionDateRangeViewModel? detectionDateRange {
			get {
				return _detectionDateRange;
			}
			set {
				SetValue(ref _detectionDateRange, value);
			}
		}
		private String? _oprtor  = default;

		[Category("Obstruction")]
		public String? oprtor {
			get {
				return _oprtor;
			}
			set {
				SetValue(ref _oprtor, value);
			}
		}
		private verticalDatum? _verticalDatum  = default;

		[Category("Obstruction")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)3,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)44,(verticalDatum)501];
		private decimal? _height  = default;

		[Category("Obstruction")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private sonarSignalStrength? _sonarSignalStrength  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sonarSignalStrengthList), typeof(sonarSignalStrength))]
		public sonarSignalStrength? sonarSignalStrength {
			get {
				return _sonarSignalStrength;
			}
			set {
				SetValue(ref _sonarSignalStrength, value);
			}
		}

		[Browsable(false)]
		public sonarSignalStrength[] sonarSignalStrengthList => [(sonarSignalStrength)501,(sonarSignalStrength)502,(sonarSignalStrength)503,(sonarSignalStrength)504];
		private Boolean? _radarConspicuous  = default;

		[Category("Obstruction")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		private decimal? _maximumPermittedDraught  = default;

		[Category("Obstruction")]
		public decimal? maximumPermittedDraught {
			get {
				return _maximumPermittedDraught;
			}
			set {
				SetValue(ref _maximumPermittedDraught, value);
			}
		}
		[Category("Obstruction")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfSurfaceList), typeof(natureOfSurface))]
		public ObservableCollection<natureOfSurface> natureOfSurface  { get; set; } = new ();

		[Browsable(false)]
		public natureOfSurface[] natureOfSurfaceList => [(natureOfSurface)1,(natureOfSurface)2,(natureOfSurface)3,(natureOfSurface)4,(natureOfSurface)5,(natureOfSurface)6,(natureOfSurface)7,(natureOfSurface)8,(natureOfSurface)9,(natureOfSurface)11,(natureOfSurface)14,(natureOfSurface)17,(natureOfSurface)18];
		private DateOnly? _spuddedDate  = default;

		[Category("Obstruction")]
		public DateOnly? spuddedDate {
			get {
				return _spuddedDate;
			}
			set {
				SetValue(ref _spuddedDate, value);
			}
		}
		private categoryOfObstruction? _categoryOfObstruction  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfObstructionList), typeof(categoryOfObstruction))]
		public categoryOfObstruction? categoryOfObstruction {
			get {
				return _categoryOfObstruction;
			}
			set {
				SetValue(ref _categoryOfObstruction, value);
			}
		}

		[Browsable(false)]
		public categoryOfObstruction[] categoryOfObstructionList => [(categoryOfObstruction)1,(categoryOfObstruction)2,(categoryOfObstruction)3,(categoryOfObstruction)4,(categoryOfObstruction)5,(categoryOfObstruction)6,(categoryOfObstruction)8,(categoryOfObstruction)9,(categoryOfObstruction)10,(categoryOfObstruction)12,(categoryOfObstruction)13,(categoryOfObstruction)14,(categoryOfObstruction)15,(categoryOfObstruction)16,(categoryOfObstruction)17,(categoryOfObstruction)18,(categoryOfObstruction)19,(categoryOfObstruction)20,(categoryOfObstruction)21,(categoryOfObstruction)22,(categoryOfObstruction)23,(categoryOfObstruction)501,(categoryOfObstruction)502,(categoryOfObstruction)503,(categoryOfObstruction)504,(categoryOfObstruction)506,(categoryOfObstruction)508,(categoryOfObstruction)509];
		private visualProminence? _visualProminence  = default;

		[Category("Obstruction")]
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
		private DateOnly? _dateSunk  = default;

		[Category("Obstruction")]
		public DateOnly? dateSunk {
			get {
				return _dateSunk;
			}
			set {
				SetValue(ref _dateSunk, value);
			}
		}
		private decimal? _horizontalLength  = default;

		[Category("Obstruction")]
		public decimal? horizontalLength {
			get {
				return _horizontalLength;
			}
			set {
				SetValue(ref _horizontalLength, value);
			}
		}
		[Category("Obstruction")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("Obstruction")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private String? _currentScourDimensions  = default;

		[Category("Obstruction")]
		public String? currentScourDimensions {
			get {
				return _currentScourDimensions;
			}
			set {
				SetValue(ref _currentScourDimensions, value);
			}
		}
		[Category("Obstruction")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(techniqueOfVerticalMeasurementList), typeof(techniqueOfVerticalMeasurement))]
		public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1,(techniqueOfVerticalMeasurement)2,(techniqueOfVerticalMeasurement)3,(techniqueOfVerticalMeasurement)4,(techniqueOfVerticalMeasurement)5,(techniqueOfVerticalMeasurement)8,(techniqueOfVerticalMeasurement)9,(techniqueOfVerticalMeasurement)10,(techniqueOfVerticalMeasurement)11,(techniqueOfVerticalMeasurement)12,(techniqueOfVerticalMeasurement)13,(techniqueOfVerticalMeasurement)15,(techniqueOfVerticalMeasurement)16,(techniqueOfVerticalMeasurement)17,(techniqueOfVerticalMeasurement)18];
		private DateOnly? _reportedDate  = default;

		[Category("Obstruction")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private cardinalPointOrientation? _cardinalPointOrientation  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(cardinalPointOrientationList), typeof(cardinalPointOrientation))]
		public cardinalPointOrientation? cardinalPointOrientation {
			get {
				return _cardinalPointOrientation;
			}
			set {
				SetValue(ref _cardinalPointOrientation, value);
			}
		}

		[Browsable(false)]
		public cardinalPointOrientation[] cardinalPointOrientationList => [(cardinalPointOrientation)501,(cardinalPointOrientation)502,(cardinalPointOrientation)503,(cardinalPointOrientation)504];
		private decimal? _valueOfSounding  = default;

		[Category("Obstruction")]
		public decimal? valueOfSounding {
			get {
				return _valueOfSounding;
			}
			set {
				SetValue(ref _valueOfSounding, value);
			}
		}
		private waterLevelEffect _waterLevelEffect ;

		[Category("Obstruction")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(waterLevelEffectList), typeof(waterLevelEffect))]
		public waterLevelEffect waterLevelEffect {
			get {
				return _waterLevelEffect;
			}
			set {
				SetValue(ref _waterLevelEffect, value);
			}
		}

		[Browsable(false)]
		public waterLevelEffect[] waterLevelEffectList => [(waterLevelEffect)1,(waterLevelEffect)2,(waterLevelEffect)3,(waterLevelEffect)4,(waterLevelEffect)5,(waterLevelEffect)7];
		private String? _nation  = default;

		[Category("Obstruction")]
		public String? nation {
			get {
				return _nation;
			}
			set {
				SetValue(ref _nation, value);
			}
		}
		private decimal? _defaultClearanceDepth  = default;

		[Category("Obstruction")]
		public decimal? defaultClearanceDepth {
			get {
				return _defaultClearanceDepth;
			}
			set {
				SetValue(ref _defaultClearanceDepth, value);
			}
		}
		private Boolean? _displayUncertainties  = default;

		[Category("Obstruction")]
		public Boolean? displayUncertainties {
			get {
				return _displayUncertainties;
			}
			set {
				SetValue(ref _displayUncertainties, value);
			}
		}


		public override FeatureViewModel<Obstruction> Load(Obstruction instance) {
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			controllingAuthority = instance.controllingAuthority;
			product.Clear();
			if (instance.product is not null) {
				foreach(var e in instance.product)
					product.Add(e);
			}
			existenceOfRestrictedArea = instance.existenceOfRestrictedArea;
			horizontalDistanceUncertainty = instance.horizontalDistanceUncertainty;
			lastSourceInformation = new ();
			if (instance.lastSourceInformation != default) {
				lastSourceInformation.Load(instance.lastSourceInformation);
			}
			scaleMinimum = instance.scaleMinimum;
			expositionOfSounding = instance.expositionOfSounding;
			firstSourceInformation = new ();
			if (instance.firstSourceInformation != default) {
				firstSourceInformation.Load(instance.firstSourceInformation);
			}
			abandonmentDate = instance.abandonmentDate;
			verticalLength = instance.verticalLength;
			soundingDepth = instance.soundingDepth;
			orientation = new ();
			if (instance.orientation != default) {
				orientation.Load(instance.orientation);
			}
			soundingDatum = instance.soundingDatum;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			magneticInformation = new ();
			if (instance.magneticInformation != default) {
				magneticInformation.Load(instance.magneticInformation);
			}
			horizontalWidth = instance.horizontalWidth;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalUncertainty = new ();
			if (instance.verticalUncertainty != default) {
				verticalUncertainty.Load(instance.verticalUncertainty);
			}
			condition = instance.condition;
			generalWaterDepth = instance.generalWaterDepth;
			qualityOfVerticalMeasurement.Clear();
			if (instance.qualityOfVerticalMeasurement is not null) {
				foreach(var e in instance.qualityOfVerticalMeasurement)
					qualityOfVerticalMeasurement.Add(e);
			}
			detectionDateRange = new ();
			if (instance.detectionDateRange != default) {
				detectionDateRange.Load(instance.detectionDateRange);
			}
			oprtor = instance.oprtor;
			verticalDatum = instance.verticalDatum;
			height = instance.height;
			sonarSignalStrength = instance.sonarSignalStrength;
			radarConspicuous = instance.radarConspicuous;
			maximumPermittedDraught = instance.maximumPermittedDraught;
			natureOfSurface.Clear();
			if (instance.natureOfSurface is not null) {
				foreach(var e in instance.natureOfSurface)
					natureOfSurface.Add(e);
			}
			spuddedDate = instance.spuddedDate;
			categoryOfObstruction = instance.categoryOfObstruction;
			visualProminence = instance.visualProminence;
			dateSunk = instance.dateSunk;
			horizontalLength = instance.horizontalLength;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			currentScourDimensions = instance.currentScourDimensions;
			techniqueOfVerticalMeasurement.Clear();
			if (instance.techniqueOfVerticalMeasurement is not null) {
				foreach(var e in instance.techniqueOfVerticalMeasurement)
					techniqueOfVerticalMeasurement.Add(e);
			}
			reportedDate = instance.reportedDate;
			cardinalPointOrientation = instance.cardinalPointOrientation;
			valueOfSounding = instance.valueOfSounding;
			waterLevelEffect = instance.waterLevelEffect;
			nation = instance.nation;
			defaultClearanceDepth = instance.defaultClearanceDepth;
			displayUncertainties = instance.displayUncertainties;
			return this;
		}

		public override string Serialize() {
			var instance = new Obstruction {
				natureOfConstruction = this.natureOfConstruction.ToList(),
				controllingAuthority = this.controllingAuthority,
				product = this.product.ToList(),
				existenceOfRestrictedArea = this.existenceOfRestrictedArea,
				horizontalDistanceUncertainty = this.horizontalDistanceUncertainty,
				lastSourceInformation = this.lastSourceInformation?.Model,
				scaleMinimum = this.scaleMinimum,
				expositionOfSounding = this.expositionOfSounding,
				firstSourceInformation = this.firstSourceInformation?.Model,
				abandonmentDate = this.abandonmentDate,
				verticalLength = this.verticalLength,
				soundingDepth = this.soundingDepth,
				orientation = this.orientation?.Model,
				soundingDatum = this.soundingDatum,
				information = this.information.Select(e => e.Model).ToList(),
				magneticInformation = this.magneticInformation?.Model,
				horizontalWidth = this.horizontalWidth,
				status = this.status.ToList(),
				verticalUncertainty = this.verticalUncertainty?.Model,
				condition = this.condition,
				generalWaterDepth = this.generalWaterDepth,
				qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
				detectionDateRange = this.detectionDateRange?.Model,
				oprtor = this.oprtor,
				verticalDatum = this.verticalDatum,
				height = this.height,
				sonarSignalStrength = this.sonarSignalStrength,
				radarConspicuous = this.radarConspicuous,
				maximumPermittedDraught = this.maximumPermittedDraught,
				natureOfSurface = this.natureOfSurface.ToList(),
				spuddedDate = this.spuddedDate,
				categoryOfObstruction = this.categoryOfObstruction,
				visualProminence = this.visualProminence,
				dateSunk = this.dateSunk,
				horizontalLength = this.horizontalLength,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIdentification = this.sourceIdentification?.Model,
				currentScourDimensions = this.currentScourDimensions,
				techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
				reportedDate = this.reportedDate,
				cardinalPointOrientation = this.cardinalPointOrientation,
				valueOfSounding = this.valueOfSounding,
				waterLevelEffect = this.waterLevelEffect,
				nation = this.nation,
				defaultClearanceDepth = this.defaultClearanceDepth,
				displayUncertainties = this.displayUncertainties,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Obstruction Model => new () {
			natureOfConstruction = this.natureOfConstruction.ToList(),
			controllingAuthority = this._controllingAuthority,
			product = this.product.ToList(),
			existenceOfRestrictedArea = this._existenceOfRestrictedArea,
			horizontalDistanceUncertainty = this._horizontalDistanceUncertainty,
			lastSourceInformation = this._lastSourceInformation?.Model,
			scaleMinimum = this._scaleMinimum,
			expositionOfSounding = this._expositionOfSounding,
			firstSourceInformation = this._firstSourceInformation?.Model,
			abandonmentDate = this._abandonmentDate,
			verticalLength = this._verticalLength,
			soundingDepth = this._soundingDepth,
			orientation = this._orientation?.Model,
			soundingDatum = this._soundingDatum,
			information = this.information.Select(e => e.Model).ToList(),
			magneticInformation = this._magneticInformation?.Model,
			horizontalWidth = this._horizontalWidth,
			status = this.status.ToList(),
			verticalUncertainty = this._verticalUncertainty?.Model,
			condition = this._condition,
			generalWaterDepth = this._generalWaterDepth,
			qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
			detectionDateRange = this._detectionDateRange?.Model,
			oprtor = this._oprtor,
			verticalDatum = this._verticalDatum,
			height = this._height,
			sonarSignalStrength = this._sonarSignalStrength,
			radarConspicuous = this._radarConspicuous,
			maximumPermittedDraught = this._maximumPermittedDraught,
			natureOfSurface = this.natureOfSurface.ToList(),
			spuddedDate = this._spuddedDate,
			categoryOfObstruction = this._categoryOfObstruction,
			visualProminence = this._visualProminence,
			dateSunk = this._dateSunk,
			horizontalLength = this._horizontalLength,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIdentification = this._sourceIdentification?.Model,
			currentScourDimensions = this._currentScourDimensions,
			techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
			reportedDate = this._reportedDate,
			cardinalPointOrientation = this._cardinalPointOrientation,
			valueOfSounding = this._valueOfSounding,
			waterLevelEffect = this._waterLevelEffect,
			nation = this._nation,
			defaultClearanceDepth = this._defaultClearanceDepth,
			displayUncertainties = this._displayUncertainties,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => Obstruction._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => Obstruction._featureBindingDefinitions;

		public override string? ToString() => $"Obstruction";

		public ObstructionViewModel() : base() {
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			product.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(product));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			qualityOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(qualityOfVerticalMeasurement));
			};
			natureOfSurface.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfSurface));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			techniqueOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(techniqueOfVerticalMeasurement));
			};
		}
	}

	/// <summary>
	/// A water area in which fishing is frequently carried on.
	/// </summary>
	[CategoryOrder("FishingGround",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class FishingGroundViewModel : FeatureViewModel<FishingGround> {
		[Category("FishingGround")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)5,(status)6,(status)7,(status)8,(status)14,(status)16,(status)17,(status)28];
		private DateOnly? _reportedDate  = default;

		[Category("FishingGround")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		[Category("FishingGround")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("FishingGround")]
		public ObservableCollection<vesselSpeedLimitViewModel> vesselSpeedLimit  { get; set; } = new ();
		[Category("FishingGround")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("FishingGround")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("FishingGround")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("FishingGround")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("FishingGround")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(restrictionList), typeof(restriction))]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)4,(restriction)5,(restriction)6,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)15,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)26,(restriction)27,(restriction)39];
		[Category("FishingGround")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override FeatureViewModel<FishingGround> Load(FishingGround instance) {
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			reportedDate = instance.reportedDate;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			vesselSpeedLimit.Clear();
			if (instance.vesselSpeedLimit is not null) {
				foreach(var e in instance.vesselSpeedLimit)
					vesselSpeedLimit.Add(new vesselSpeedLimitViewModel().Load(e));
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			scaleMinimum = instance.scaleMinimum;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			restriction.Clear();
			if (instance.restriction is not null) {
				foreach(var e in instance.restriction)
					restriction.Add(e);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new FishingGround {
				status = this.status.ToList(),
				reportedDate = this.reportedDate,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				vesselSpeedLimit = this.vesselSpeedLimit.Select(e => e.Model).ToList(),
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				sourceIdentification = this.sourceIdentification?.Model,
				scaleMinimum = this.scaleMinimum,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				restriction = this.restriction.ToList(),
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public FishingGround Model => new () {
			status = this.status.ToList(),
			reportedDate = this._reportedDate,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			vesselSpeedLimit = this.vesselSpeedLimit.Select(e => e.Model).ToList(),
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			sourceIdentification = this._sourceIdentification?.Model,
			scaleMinimum = this._scaleMinimum,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			restriction = this.restriction.ToList(),
			information = this.information.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => FishingGround._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => FishingGround._featureBindingDefinitions;

		public override string? ToString() => $"Fishing Ground";

		public FishingGroundViewModel() : base() {
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			vesselSpeedLimit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(vesselSpeedLimit));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(restriction));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// A structure for fishing purposes which can be an obstruction to ships in general. The position of these structures may vary frequently over time.
	/// </summary>
	[CategoryOrder("FishingFacility",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class FishingFacilityViewModel : FeatureViewModel<FishingFacility> {
		[Category("FishingFacility")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("FishingFacility")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		private condition? _condition  = default;

		[Category("FishingFacility")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)5];
		private String? _interoperabilityIdentifier  = default;

		[Category("FishingFacility")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private decimal? _verticalLength  = default;

		[Category("FishingFacility")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		[Category("FishingFacility")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)4,(status)5,(status)6,(status)7,(status)8,(status)12,(status)18,(status)28];
		private categoryOfFishingFacility? _categoryOfFishingFacility  = default;

		[Category("FishingFacility")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfFishingFacilityList), typeof(categoryOfFishingFacility))]
		public categoryOfFishingFacility? categoryOfFishingFacility {
			get {
				return _categoryOfFishingFacility;
			}
			set {
				SetValue(ref _categoryOfFishingFacility, value);
			}
		}

		[Browsable(false)]
		public categoryOfFishingFacility[] categoryOfFishingFacilityList => [(categoryOfFishingFacility)1,(categoryOfFishingFacility)2,(categoryOfFishingFacility)3,(categoryOfFishingFacility)4];
		private int? _scaleMinimum  = default;

		[Category("FishingFacility")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("FishingFacility")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private DateOnly? _reportedDate  = default;

		[Category("FishingFacility")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}


		public override FeatureViewModel<FishingFacility> Load(FishingFacility instance) {
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			condition = instance.condition;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			verticalLength = instance.verticalLength;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			categoryOfFishingFacility = instance.categoryOfFishingFacility;
			scaleMinimum = instance.scaleMinimum;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			reportedDate = instance.reportedDate;
			return this;
		}

		public override string Serialize() {
			var instance = new FishingFacility {
				information = this.information.Select(e => e.Model).ToList(),
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				condition = this.condition,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				verticalLength = this.verticalLength,
				status = this.status.ToList(),
				categoryOfFishingFacility = this.categoryOfFishingFacility,
				scaleMinimum = this.scaleMinimum,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				reportedDate = this.reportedDate,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public FishingFacility Model => new () {
			information = this.information.Select(e => e.Model).ToList(),
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			condition = this._condition,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			verticalLength = this._verticalLength,
			status = this.status.ToList(),
			categoryOfFishingFacility = this._categoryOfFishingFacility,
			scaleMinimum = this._scaleMinimum,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			reportedDate = this._reportedDate,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => FishingFacility._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => FishingFacility._featureBindingDefinitions;

		public override string? ToString() => $"Fishing Facility";

		public FishingFacilityViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// Any visual or electronic device which provides point-to-point guidance information or position data 
	/// </summary>
	[CategoryOrder("NavigationSystem",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NavigationSystemViewModel : FeatureViewModel<NavigationSystem> {
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("NavigationSystem")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		[Category("NavigationSystem")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private String? _agencyResponsibleForProduction  = default;

		[Category("NavigationSystem")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private categoryOfRadioStation? _categoryOfRadioStation  = default;

		[Category("NavigationSystem")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfRadioStationList), typeof(categoryOfRadioStation))]
		public categoryOfRadioStation? categoryOfRadioStation {
			get {
				return _categoryOfRadioStation;
			}
			set {
				SetValue(ref _categoryOfRadioStation, value);
			}
		}

		[Browsable(false)]
		public categoryOfRadioStation[] categoryOfRadioStationList => [(categoryOfRadioStation)1,(categoryOfRadioStation)2,(categoryOfRadioStation)3,(categoryOfRadioStation)4,(categoryOfRadioStation)5,(categoryOfRadioStation)6,(categoryOfRadioStation)7,(categoryOfRadioStation)8,(categoryOfRadioStation)9,(categoryOfRadioStation)10,(categoryOfRadioStation)11,(categoryOfRadioStation)12,(categoryOfRadioStation)13,(categoryOfRadioStation)14,(categoryOfRadioStation)19,(categoryOfRadioStation)20,(categoryOfRadioStation)504,(categoryOfRadioStation)505,(categoryOfRadioStation)506,(categoryOfRadioStation)508,(categoryOfRadioStation)509,(categoryOfRadioStation)510];
		private DateOnly? _reportedDate  = default;

		[Category("NavigationSystem")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private String? _callsign  = default;

		[Category("NavigationSystem")]
		public String? callsign {
			get {
				return _callsign;
			}
			set {
				SetValue(ref _callsign, value);
			}
		}
		[Category("NavigationSystem")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private String? _communicationChannel  = default;

		[Category("NavigationSystem")]
		public String? communicationChannel {
			get {
				return _communicationChannel;
			}
			set {
				SetValue(ref _communicationChannel, value);
			}
		}
		private int? _signalFrequency  = default;

		[Category("NavigationSystem")]
		public int? signalFrequency {
			get {
				return _signalFrequency;
			}
			set {
				SetValue(ref _signalFrequency, value);
			}
		}


		public override FeatureViewModel<NavigationSystem> Load(NavigationSystem instance) {
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			categoryOfRadioStation = instance.categoryOfRadioStation;
			reportedDate = instance.reportedDate;
			callsign = instance.callsign;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			communicationChannel = instance.communicationChannel;
			signalFrequency = instance.signalFrequency;
			return this;
		}

		public override string Serialize() {
			var instance = new NavigationSystem {
				sourceIdentification = this.sourceIdentification?.Model,
				information = this.information.Select(e => e.Model).ToList(),
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				categoryOfRadioStation = this.categoryOfRadioStation,
				reportedDate = this.reportedDate,
				callsign = this.callsign,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				communicationChannel = this.communicationChannel,
				signalFrequency = this.signalFrequency,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public NavigationSystem Model => new () {
			sourceIdentification = this._sourceIdentification?.Model,
			information = this.information.Select(e => e.Model).ToList(),
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			categoryOfRadioStation = this._categoryOfRadioStation,
			reportedDate = this._reportedDate,
			callsign = this._callsign,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			communicationChannel = this._communicationChannel,
			signalFrequency = this._signalFrequency,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => NavigationSystem._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => NavigationSystem._featureBindingDefinitions;

		public override string? ToString() => $"Navigation System";

		public NavigationSystemViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// A defined area where traffic lanes cross.
	/// </summary>
	[CategoryOrder("TrafficSeparationSchemeCrossing",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TrafficSeparationSchemeCrossingViewModel : FeatureViewModel<TrafficSeparationSchemeCrossing> {
		[Category("TrafficSeparationSchemeCrossing")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(restrictionList), typeof(restriction))]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)27];
		[Category("TrafficSeparationSchemeCrossing")]
		public ObservableCollection<vesselSpeedLimitViewModel> vesselSpeedLimit  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("TrafficSeparationSchemeCrossing")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("TrafficSeparationSchemeCrossing")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		[Category("TrafficSeparationSchemeCrossing")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("TrafficSeparationSchemeCrossing")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)3,(status)6,(status)9];
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("TrafficSeparationSchemeCrossing")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("TrafficSeparationSchemeCrossing")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private DateOnly? _reportedDate  = default;

		[Category("TrafficSeparationSchemeCrossing")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}


		public override FeatureViewModel<TrafficSeparationSchemeCrossing> Load(TrafficSeparationSchemeCrossing instance) {
			restriction.Clear();
			if (instance.restriction is not null) {
				foreach(var e in instance.restriction)
					restriction.Add(e);
			}
			vesselSpeedLimit.Clear();
			if (instance.vesselSpeedLimit is not null) {
				foreach(var e in instance.vesselSpeedLimit)
					vesselSpeedLimit.Add(new vesselSpeedLimitViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			reportedDate = instance.reportedDate;
			return this;
		}

		public override string Serialize() {
			var instance = new TrafficSeparationSchemeCrossing {
				restriction = this.restriction.ToList(),
				vesselSpeedLimit = this.vesselSpeedLimit.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceIdentification = this.sourceIdentification?.Model,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				status = this.status.ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				information = this.information.Select(e => e.Model).ToList(),
				reportedDate = this.reportedDate,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public TrafficSeparationSchemeCrossing Model => new () {
			restriction = this.restriction.ToList(),
			vesselSpeedLimit = this.vesselSpeedLimit.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceIdentification = this._sourceIdentification?.Model,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			status = this.status.ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			information = this.information.Select(e => e.Model).ToList(),
			reportedDate = this._reportedDate,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeCrossing._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeCrossing._featureBindingDefinitions;

		public override string? ToString() => $"Traffic Separation Scheme Crossing";

		public TrafficSeparationSchemeCrossingViewModel() : base() {
			restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(restriction));
			};
			vesselSpeedLimit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(vesselSpeedLimit));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// An area within defined limits in which one-way traffic is established. Natural obstacles, including those forming separation zones, may constitute a boundary.
	/// </summary>
	[CategoryOrder("TrafficSeparationSchemeLanePart",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TrafficSeparationSchemeLanePartViewModel : FeatureViewModel<TrafficSeparationSchemeLanePart> {
		[Category("TrafficSeparationSchemeLanePart")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private DateOnly? _reportedDate  = default;

		[Category("TrafficSeparationSchemeLanePart")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		[Category("TrafficSeparationSchemeLanePart")]
		public ObservableCollection<vesselSpeedLimitViewModel> vesselSpeedLimit  { get; set; } = new ();
		private String? _interoperabilityIdentifier  = default;

		[Category("TrafficSeparationSchemeLanePart")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("TrafficSeparationSchemeLanePart")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(restrictionList), typeof(restriction))]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)27];
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("TrafficSeparationSchemeLanePart")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private decimal? _orientationValue  = default;

		[Category("TrafficSeparationSchemeLanePart")]
		public decimal? orientationValue {
			get {
				return _orientationValue;
			}
			set {
				SetValue(ref _orientationValue, value);
			}
		}
		[Category("TrafficSeparationSchemeLanePart")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)3,(status)9,(status)28];
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("TrafficSeparationSchemeLanePart")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("TrafficSeparationSchemeLanePart")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}


		public override FeatureViewModel<TrafficSeparationSchemeLanePart> Load(TrafficSeparationSchemeLanePart instance) {
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			reportedDate = instance.reportedDate;
			vesselSpeedLimit.Clear();
			if (instance.vesselSpeedLimit is not null) {
				foreach(var e in instance.vesselSpeedLimit)
					vesselSpeedLimit.Add(new vesselSpeedLimitViewModel().Load(e));
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			restriction.Clear();
			if (instance.restriction is not null) {
				foreach(var e in instance.restriction)
					restriction.Add(e);
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			orientationValue = instance.orientationValue;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			scaleMinimum = instance.scaleMinimum;
			return this;
		}

		public override string Serialize() {
			var instance = new TrafficSeparationSchemeLanePart {
				information = this.information.Select(e => e.Model).ToList(),
				reportedDate = this.reportedDate,
				vesselSpeedLimit = this.vesselSpeedLimit.Select(e => e.Model).ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				restriction = this.restriction.ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				orientationValue = this.orientationValue,
				status = this.status.ToList(),
				sourceIdentification = this.sourceIdentification?.Model,
				scaleMinimum = this.scaleMinimum,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public TrafficSeparationSchemeLanePart Model => new () {
			information = this.information.Select(e => e.Model).ToList(),
			reportedDate = this._reportedDate,
			vesselSpeedLimit = this.vesselSpeedLimit.Select(e => e.Model).ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			restriction = this.restriction.ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			orientationValue = this._orientationValue,
			status = this.status.ToList(),
			sourceIdentification = this._sourceIdentification?.Model,
			scaleMinimum = this._scaleMinimum,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeLanePart._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeLanePart._featureBindingDefinitions;

		public override string? ToString() => $"Traffic Separation Scheme Lane Part";

		public TrafficSeparationSchemeLanePartViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			vesselSpeedLimit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(vesselSpeedLimit));
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
	/// A belt of water of a defined breadth but not exceeding 12 nautical miles measured seaward from the territorial sea baseline.
	/// </summary>
	[CategoryOrder("TerritorialSeaArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TerritorialSeaAreaViewModel : FeatureViewModel<TerritorialSeaArea> {
		[Category("TerritorialSeaArea")]
		public ObservableCollection<String> nationality  { get; set; } = new ();
		[Category("TerritorialSeaArea")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private status? _status  = default;

		[Category("TerritorialSeaArea")]
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
		public status[] statusList => [(status)502,(status)504,(status)520];
		private String? _interoperabilityIdentifier  = default;

		[Category("TerritorialSeaArea")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private String? _agencyResponsibleForProduction  = default;

		[Category("TerritorialSeaArea")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		[Category("TerritorialSeaArea")]
		public ObservableCollection<vesselSpeedLimitViewModel> vesselSpeedLimit  { get; set; } = new ();
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("TerritorialSeaArea")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("TerritorialSeaArea")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		[Category("TerritorialSeaArea")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(restrictionList), typeof(restriction))]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)2,(restriction)4,(restriction)6,(restriction)8,(restriction)9,(restriction)10,(restriction)12,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)27];
		private int? _scaleMinimum  = default;

		[Category("TerritorialSeaArea")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("TerritorialSeaArea")]
		public ObservableCollection<String> nationalMaritimeAuthority  { get; set; } = new ();
		[Category("TerritorialSeaArea")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override FeatureViewModel<TerritorialSeaArea> Load(TerritorialSeaArea instance) {
			nationality.Clear();
			if (instance.nationality is not null) {
				foreach(var e in instance.nationality)
					nationality.Add(e);
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			status = instance.status;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			vesselSpeedLimit.Clear();
			if (instance.vesselSpeedLimit is not null) {
				foreach(var e in instance.vesselSpeedLimit)
					vesselSpeedLimit.Add(new vesselSpeedLimitViewModel().Load(e));
			}
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			reportedDate = instance.reportedDate;
			restriction.Clear();
			if (instance.restriction is not null) {
				foreach(var e in instance.restriction)
					restriction.Add(e);
			}
			scaleMinimum = instance.scaleMinimum;
			nationalMaritimeAuthority.Clear();
			if (instance.nationalMaritimeAuthority is not null) {
				foreach(var e in instance.nationalMaritimeAuthority)
					nationalMaritimeAuthority.Add(e);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new TerritorialSeaArea {
				nationality = this.nationality.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				status = this.status,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				vesselSpeedLimit = this.vesselSpeedLimit.Select(e => e.Model).ToList(),
				sourceIdentification = this.sourceIdentification?.Model,
				reportedDate = this.reportedDate,
				restriction = this.restriction.ToList(),
				scaleMinimum = this.scaleMinimum,
				nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public TerritorialSeaArea Model => new () {
			nationality = this.nationality.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			status = this._status,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			vesselSpeedLimit = this.vesselSpeedLimit.Select(e => e.Model).ToList(),
			sourceIdentification = this._sourceIdentification?.Model,
			reportedDate = this._reportedDate,
			restriction = this.restriction.ToList(),
			scaleMinimum = this._scaleMinimum,
			nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
			information = this.information.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => TerritorialSeaArea._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => TerritorialSeaArea._featureBindingDefinitions;

		public override string? ToString() => $"Territorial Sea Area";

		public TerritorialSeaAreaViewModel() : base() {
			nationality.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(nationality));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			vesselSpeedLimit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(vesselSpeedLimit));
			};
			restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(restriction));
			};
			nationalMaritimeAuthority.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(nationalMaritimeAuthority));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// A lateral beacon is used to indicate the port or starboard hand side of the route to be followed. They are generally used for well defined channels and are used in conjunction with a conventional direction of buoyage.
	/// </summary>
	[CategoryOrder("LateralBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LateralBeaconViewModel : FeatureViewModel<LateralBeacon> {
		private decimal? _elevation  = default;

		[Category("LateralBeacon")]
		public decimal? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}
		private beaconShape _beaconShape ;

		[Category("LateralBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("LateralBeacon")]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)11];
		private String? _pictorialRepresentation  = default;

		[Category("LateralBeacon")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private categoryOfLateralMark _categoryOfLateralMark ;

		[Category("LateralBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		public categoryOfLateralMark[] categoryOfLateralMarkList => [(categoryOfLateralMark)1,(categoryOfLateralMark)2,(categoryOfLateralMark)3,(categoryOfLateralMark)4];
		private DateOnly? _reportedDate  = default;

		[Category("LateralBeacon")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		[Category("LateralBeacon")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)12,(status)18];
		private visualProminence? _visualProminence  = default;

		[Category("LateralBeacon")]
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
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("LateralBeacon")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private decimal? _verticalLength  = default;

		[Category("LateralBeacon")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		[Category("LateralBeacon")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("LateralBeacon")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private Boolean? _radarConspicuous  = default;

		[Category("LateralBeacon")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		[Category("LateralBeacon")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("LateralBeacon")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private colourPattern? _colourPattern  = default;

		[Category("LateralBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public colourPattern? colourPattern {
			get {
				return _colourPattern;
			}
			set {
				SetValue(ref _colourPattern, value);
			}
		}

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6];
		[Category("LateralBeacon")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("LateralBeacon")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private topmarkViewModel? _topmark  = default;

		[Category("LateralBeacon")]
		[ExpandableObject]
		public topmarkViewModel? topmark {
			get {
				return _topmark;
			}
			set {
				SetValue(ref _topmark, value);
			}
		}
		private decimal? _height  = default;

		[Category("LateralBeacon")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private condition? _condition  = default;

		[Category("LateralBeacon")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)5];
		[Category("LateralBeacon")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8];
		[Category("LateralBeacon")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];


		public override FeatureViewModel<LateralBeacon> Load(LateralBeacon instance) {
			elevation = instance.elevation;
			beaconShape = instance.beaconShape;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			pictorialRepresentation = instance.pictorialRepresentation;
			categoryOfLateralMark = instance.categoryOfLateralMark;
			reportedDate = instance.reportedDate;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			visualProminence = instance.visualProminence;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			verticalLength = instance.verticalLength;
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			radarConspicuous = instance.radarConspicuous;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			colourPattern = instance.colourPattern;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			topmark = new ();
			if (instance.topmark != default) {
				topmark.Load(instance.topmark);
			}
			height = instance.height;
			condition = instance.condition;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new LateralBeacon {
				elevation = this.elevation,
				beaconShape = this.beaconShape,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				pictorialRepresentation = this.pictorialRepresentation,
				categoryOfLateralMark = this.categoryOfLateralMark,
				reportedDate = this.reportedDate,
				status = this.status.ToList(),
				visualProminence = this.visualProminence,
				fixedDateRange = this.fixedDateRange?.Model,
				verticalLength = this.verticalLength,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				sourceIdentification = this.sourceIdentification?.Model,
				radarConspicuous = this.radarConspicuous,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				colourPattern = this.colourPattern,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				topmark = this.topmark?.Model,
				height = this.height,
				condition = this.condition,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				colour = this.colour.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LateralBeacon Model => new () {
			elevation = this._elevation,
			beaconShape = this._beaconShape,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			pictorialRepresentation = this._pictorialRepresentation,
			categoryOfLateralMark = this._categoryOfLateralMark,
			reportedDate = this._reportedDate,
			status = this.status.ToList(),
			visualProminence = this._visualProminence,
			fixedDateRange = this._fixedDateRange?.Model,
			verticalLength = this._verticalLength,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			sourceIdentification = this._sourceIdentification?.Model,
			radarConspicuous = this._radarConspicuous,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			colourPattern = this._colourPattern,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			topmark = this._topmark?.Model,
			height = this._height,
			condition = this._condition,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			colour = this.colour.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => LateralBeacon._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => LateralBeacon._featureBindingDefinitions;

		public override string? ToString() => $"Lateral Beacon";

		public LateralBeaconViewModel() : base() {
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
		}
	}

	/// <summary>
	/// A station at which a visual/radio/radar marine watch is kept either continuously or at certain times only.
	/// </summary>
	[CategoryOrder("CoastGuardStation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CoastGuardStationViewModel : FeatureViewModel<CoastGuardStation> {
		[Category("CoastGuardStation")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)4,(status)5,(status)16,(status)17];
		private int? _scaleMinimum  = default;

		[Category("CoastGuardStation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("CoastGuardStation")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("CoastGuardStation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("CoastGuardStation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private Boolean? _isMRCC  = default;

		[Category("CoastGuardStation")]
		public Boolean? isMRCC {
			get {
				return _isMRCC;
			}
			set {
				SetValue(ref _isMRCC, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("CoastGuardStation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("CoastGuardStation")]
		public ObservableCollection<String> communicationsChannel  { get; set; } = new ();


		public override FeatureViewModel<CoastGuardStation> Load(CoastGuardStation instance) {
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			scaleMinimum = instance.scaleMinimum;
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
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
			isMRCC = instance.isMRCC;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			communicationsChannel.Clear();
			if (instance.communicationsChannel is not null) {
				foreach(var e in instance.communicationsChannel)
					communicationsChannel.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new CoastGuardStation {
				status = this.status.ToList(),
				scaleMinimum = this.scaleMinimum,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				isMRCC = this.isMRCC,
				fixedDateRange = this.fixedDateRange?.Model,
				communicationsChannel = this.communicationsChannel.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CoastGuardStation Model => new () {
			status = this.status.ToList(),
			scaleMinimum = this._scaleMinimum,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			isMRCC = this._isMRCC,
			fixedDateRange = this._fixedDateRange?.Model,
			communicationsChannel = this.communicationsChannel.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => CoastGuardStation._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => CoastGuardStation._featureBindingDefinitions;

		public override string? ToString() => $"Coast Guard Station";

		public CoastGuardStationViewModel() : base() {
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			communicationsChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(communicationsChannel));
			};
		}
	}

	/// <summary>
	/// A zone or line separating the traffic lanes in which ships are proceeding in opposite, or nearly opposite directions; or separating a traffic lane from the adjacent sea area; or separating traffic lanes designated for particular classes of ships proceeding in the same direction.
	/// </summary>
	[CategoryOrder("SeparationZoneOrLine",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SeparationZoneOrLineViewModel : FeatureViewModel<SeparationZoneOrLine> {
		private DateOnly? _reportedDate  = default;

		[Category("SeparationZoneOrLine")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		[Category("SeparationZoneOrLine")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("SeparationZoneOrLine")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)3,(status)9,(status)28];
		[Category("SeparationZoneOrLine")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("SeparationZoneOrLine")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("SeparationZoneOrLine")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("SeparationZoneOrLine")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}


		public override FeatureViewModel<SeparationZoneOrLine> Load(SeparationZoneOrLine instance) {
			reportedDate = instance.reportedDate;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			scaleMinimum = instance.scaleMinimum;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new SeparationZoneOrLine {
				reportedDate = this.reportedDate,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				status = this.status.ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				scaleMinimum = this.scaleMinimum,
				sourceIdentification = this.sourceIdentification?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SeparationZoneOrLine Model => new () {
			reportedDate = this._reportedDate,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			status = this.status.ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			scaleMinimum = this._scaleMinimum,
			sourceIdentification = this._sourceIdentification?.Model,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => SeparationZoneOrLine._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => SeparationZoneOrLine._featureBindingDefinitions;

		public override string? ToString() => $"Separation Zone or Line";

		public SeparationZoneOrLineViewModel() : base() {
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// A significant configuration of underwater topography 
	/// </summary>
	[CategoryOrder("BottomFeature",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class BottomFeatureViewModel : FeatureViewModel<BottomFeature> {
		[Category("BottomFeature")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private int? _migrationDirection  = default;

		[Category("BottomFeature")]
		public int? migrationDirection {
			get {
				return _migrationDirection;
			}
			set {
				SetValue(ref _migrationDirection, value);
			}
		}
		[Category("BottomFeature")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private decimal? _horizontalLength  = default;

		[Category("BottomFeature")]
		public decimal? horizontalLength {
			get {
				return _horizontalLength;
			}
			set {
				SetValue(ref _horizontalLength, value);
			}
		}
		private bottomFeatureClassification? _bottomFeatureClassification  = default;

		[Category("BottomFeature")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(bottomFeatureClassificationList), typeof(bottomFeatureClassification))]
		public bottomFeatureClassification? bottomFeatureClassification {
			get {
				return _bottomFeatureClassification;
			}
			set {
				SetValue(ref _bottomFeatureClassification, value);
			}
		}

		[Browsable(false)]
		public bottomFeatureClassification[] bottomFeatureClassificationList => [(bottomFeatureClassification)502,(bottomFeatureClassification)510];
		private DateOnly? _reportedDate  = default;

		[Category("BottomFeature")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private decimal? _verticalLength  = default;

		[Category("BottomFeature")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}


		public override FeatureViewModel<BottomFeature> Load(BottomFeature instance) {
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			migrationDirection = instance.migrationDirection;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			horizontalLength = instance.horizontalLength;
			bottomFeatureClassification = instance.bottomFeatureClassification;
			reportedDate = instance.reportedDate;
			verticalLength = instance.verticalLength;
			return this;
		}

		public override string Serialize() {
			var instance = new BottomFeature {
				information = this.information.Select(e => e.Model).ToList(),
				migrationDirection = this.migrationDirection,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				horizontalLength = this.horizontalLength,
				bottomFeatureClassification = this.bottomFeatureClassification,
				reportedDate = this.reportedDate,
				verticalLength = this.verticalLength,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public BottomFeature Model => new () {
			information = this.information.Select(e => e.Model).ToList(),
			migrationDirection = this._migrationDirection,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			horizontalLength = this._horizontalLength,
			bottomFeatureClassification = this._bottomFeatureClassification,
			reportedDate = this._reportedDate,
			verticalLength = this._verticalLength,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => BottomFeature._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => BottomFeature._featureBindingDefinitions;

		public override string? ToString() => $"Bottom Feature";

		public BottomFeatureViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// Straight baselines joining the outermost points of the outermost islands and drying reefs of the archipelago provided that within such baselines are included the main islands and an area in which the ratio of the area of the water to the area of the land, including atolls, is between 1 to 1 and 9 to 1.
	/// </summary>
	[CategoryOrder("ArchipelagicBaseline",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ArchipelagicBaselineViewModel : FeatureViewModel<ArchipelagicBaseline> {
		private DateOnly? _reportedDate  = default;

		[Category("ArchipelagicBaseline")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private status? _status  = default;

		[Category("ArchipelagicBaseline")]
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
		public status[] statusList => [(status)502,(status)504];
		private Boolean? _inDispute  = default;

		[Category("ArchipelagicBaseline")]
		public Boolean? inDispute {
			get {
				return _inDispute;
			}
			set {
				SetValue(ref _inDispute, value);
			}
		}
		private String _nationality  = string.Empty;

		[Category("ArchipelagicBaseline")]
		public String nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}
		[Category("ArchipelagicBaseline")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("ArchipelagicBaseline")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private String? _agencyResponsibleForProduction  = default;

		[Category("ArchipelagicBaseline")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("ArchipelagicBaseline")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}


		public override FeatureViewModel<ArchipelagicBaseline> Load(ArchipelagicBaseline instance) {
			reportedDate = instance.reportedDate;
			status = instance.status;
			inDispute = instance.inDispute;
			nationality = instance.nationality;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			scaleMinimum = instance.scaleMinimum;
			return this;
		}

		public override string Serialize() {
			var instance = new ArchipelagicBaseline {
				reportedDate = this.reportedDate,
				status = this.status,
				inDispute = this.inDispute,
				nationality = this.nationality,
				information = this.information.Select(e => e.Model).ToList(),
				sourceIdentification = this.sourceIdentification?.Model,
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				scaleMinimum = this.scaleMinimum,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ArchipelagicBaseline Model => new () {
			reportedDate = this._reportedDate,
			status = this._status,
			inDispute = this._inDispute,
			nationality = this._nationality,
			information = this.information.Select(e => e.Model).ToList(),
			sourceIdentification = this._sourceIdentification?.Model,
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			scaleMinimum = this._scaleMinimum,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => ArchipelagicBaseline._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => ArchipelagicBaseline._featureBindingDefinitions;

		public override string? ToString() => $"Archipelagic Baseline";

		public ArchipelagicBaselineViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// Underwater feature appearing mine-like on a sonar image (AML)
	/// </summary>
	[CategoryOrder("SmallBottomObject",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SmallBottomObjectViewModel : FeatureViewModel<SmallBottomObject> {
		private String? _agencyResponsibleForProduction  = default;

		[Category("SmallBottomObject")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private statusOfSmallBottomObject? _statusOfSmallBottomObject  = default;

		[Category("SmallBottomObject")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusOfSmallBottomObjectList), typeof(statusOfSmallBottomObject))]
		public statusOfSmallBottomObject? statusOfSmallBottomObject {
			get {
				return _statusOfSmallBottomObject;
			}
			set {
				SetValue(ref _statusOfSmallBottomObject, value);
			}
		}

		[Browsable(false)]
		public statusOfSmallBottomObject[] statusOfSmallBottomObjectList => [(statusOfSmallBottomObject)504];
		[Category("SmallBottomObject")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("SmallBottomObject")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private decimal _valueOfSounding ;

		[Category("SmallBottomObject")]
		public decimal valueOfSounding {
			get {
				return _valueOfSounding;
			}
			set {
				SetValue(ref _valueOfSounding, value);
			}
		}


		public override FeatureViewModel<SmallBottomObject> Load(SmallBottomObject instance) {
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			statusOfSmallBottomObject = instance.statusOfSmallBottomObject;
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
			valueOfSounding = instance.valueOfSounding;
			return this;
		}

		public override string Serialize() {
			var instance = new SmallBottomObject {
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				statusOfSmallBottomObject = this.statusOfSmallBottomObject,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				valueOfSounding = this.valueOfSounding,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SmallBottomObject Model => new () {
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			statusOfSmallBottomObject = this._statusOfSmallBottomObject,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			valueOfSounding = this._valueOfSounding,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => SmallBottomObject._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => SmallBottomObject._featureBindingDefinitions;

		public override string? ToString() => $"Small Bottom Object ";

		public SmallBottomObjectViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// An area, not exceeding 200 nautical miles from the baselines from which the breadth of the territorial sea is measured, subject to a specific legal regime established in the United Nations Convention on the Law of the Sea under which the coastal state has certain rights and jurisdiction.
	/// </summary>
	[CategoryOrder("ExclusiveEconomicZone",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ExclusiveEconomicZoneViewModel : FeatureViewModel<ExclusiveEconomicZone> {
		[Category("ExclusiveEconomicZone")]
		public ObservableCollection<String> nationalMaritimeAuthority  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("ExclusiveEconomicZone")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("ExclusiveEconomicZone")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		[Category("ExclusiveEconomicZone")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private DateOnly? _reportedDate  = default;

		[Category("ExclusiveEconomicZone")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		[Category("ExclusiveEconomicZone")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private String? _interoperabilityIdentifier  = default;

		[Category("ExclusiveEconomicZone")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private Boolean? _inDispute  = default;

		[Category("ExclusiveEconomicZone")]
		public Boolean? inDispute {
			get {
				return _inDispute;
			}
			set {
				SetValue(ref _inDispute, value);
			}
		}
		[Category("ExclusiveEconomicZone")]
		public ObservableCollection<String> nationality  { get; set; } = new ();


		public override FeatureViewModel<ExclusiveEconomicZone> Load(ExclusiveEconomicZone instance) {
			nationalMaritimeAuthority.Clear();
			if (instance.nationalMaritimeAuthority is not null) {
				foreach(var e in instance.nationalMaritimeAuthority)
					nationalMaritimeAuthority.Add(e);
			}
			scaleMinimum = instance.scaleMinimum;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			reportedDate = instance.reportedDate;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			inDispute = instance.inDispute;
			nationality.Clear();
			if (instance.nationality is not null) {
				foreach(var e in instance.nationality)
					nationality.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new ExclusiveEconomicZone {
				nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceIdentification = this.sourceIdentification?.Model,
				information = this.information.Select(e => e.Model).ToList(),
				reportedDate = this.reportedDate,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				inDispute = this.inDispute,
				nationality = this.nationality.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ExclusiveEconomicZone Model => new () {
			nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceIdentification = this._sourceIdentification?.Model,
			information = this.information.Select(e => e.Model).ToList(),
			reportedDate = this._reportedDate,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			inDispute = this._inDispute,
			nationality = this.nationality.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => ExclusiveEconomicZone._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => ExclusiveEconomicZone._featureBindingDefinitions;

		public override string? ToString() => $"Exclusive Economic Zone";

		public ExclusiveEconomicZoneViewModel() : base() {
			nationalMaritimeAuthority.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(nationalMaritimeAuthority));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			nationality.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(nationality));
			};
		}
	}

	/// <summary>
	/// A station with a transmitter emitting pulses of ultra-high frequency radio waves which are reflected by solid objects and are detected upon their return to the sending station.
	/// </summary>
	[CategoryOrder("RadarStation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadarStationViewModel : FeatureViewModel<RadarStation> {
		[Category("RadarStation")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)7,(status)8];
		private categoryOfRadarStation? _categoryOfRadarStation  = default;

		[Category("RadarStation")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfRadarStationList), typeof(categoryOfRadarStation))]
		public categoryOfRadarStation? categoryOfRadarStation {
			get {
				return _categoryOfRadarStation;
			}
			set {
				SetValue(ref _categoryOfRadarStation, value);
			}
		}

		[Browsable(false)]
		public categoryOfRadarStation[] categoryOfRadarStationList => [(categoryOfRadarStation)1,(categoryOfRadarStation)2];
		private decimal? _height  = default;

		[Category("RadarStation")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		[Category("RadarStation")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private String? _callsign  = default;

		[Category("RadarStation")]
		public String? callsign {
			get {
				return _callsign;
			}
			set {
				SetValue(ref _callsign, value);
			}
		}
		[Category("RadarStation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("RadarStation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("RadarStation")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("RadarStation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("RadarStation")]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();
		private decimal? _valueOfMaximumRange  = default;

		[Category("RadarStation")]
		public decimal? valueOfMaximumRange {
			get {
				return _valueOfMaximumRange;
			}
			set {
				SetValue(ref _valueOfMaximumRange, value);
			}
		}


		public override FeatureViewModel<RadarStation> Load(RadarStation instance) {
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			categoryOfRadarStation = instance.categoryOfRadarStation;
			height = instance.height;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			callsign = instance.callsign;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			communicationChannel.Clear();
			if (instance.communicationChannel is not null) {
				foreach(var e in instance.communicationChannel)
					communicationChannel.Add(e);
			}
			valueOfMaximumRange = instance.valueOfMaximumRange;
			return this;
		}

		public override string Serialize() {
			var instance = new RadarStation {
				status = this.status.ToList(),
				categoryOfRadarStation = this.categoryOfRadarStation,
				height = this.height,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				callsign = this.callsign,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				communicationChannel = this.communicationChannel.ToList(),
				valueOfMaximumRange = this.valueOfMaximumRange,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RadarStation Model => new () {
			status = this.status.ToList(),
			categoryOfRadarStation = this._categoryOfRadarStation,
			height = this._height,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			callsign = this._callsign,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			communicationChannel = this.communicationChannel.ToList(),
			valueOfMaximumRange = this._valueOfMaximumRange,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => RadarStation._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => RadarStation._featureBindingDefinitions;

		public override string? ToString() => $"Radar Station";

		public RadarStationViewModel() : base() {
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(communicationChannel));
			};
		}
	}

	/// <summary>
	/// Location where civilian diving activities take place. 
	/// </summary>
	[CategoryOrder("DivingLocation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DivingLocationViewModel : FeatureViewModel<DivingLocation> {
		private decimal? _waterClarity  = default;

		[Category("DivingLocation")]
		public decimal? waterClarity {
			get {
				return _waterClarity;
			}
			set {
				SetValue(ref _waterClarity, value);
			}
		}
		[Category("DivingLocation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private divingActivity? _divingActivity  = default;

		[Category("DivingLocation")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(divingActivityList), typeof(divingActivity))]
		public divingActivity? divingActivity {
			get {
				return _divingActivity;
			}
			set {
				SetValue(ref _divingActivity, value);
			}
		}

		[Browsable(false)]
		public divingActivity[] divingActivityList => [(divingActivity)501,(divingActivity)502,(divingActivity)503];


		public override FeatureViewModel<DivingLocation> Load(DivingLocation instance) {
			waterClarity = instance.waterClarity;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			divingActivity = instance.divingActivity;
			return this;
		}

		public override string Serialize() {
			var instance = new DivingLocation {
				waterClarity = this.waterClarity,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				divingActivity = this.divingActivity,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DivingLocation Model => new () {
			waterClarity = this._waterClarity,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			divingActivity = this._divingActivity,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => DivingLocation._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => DivingLocation._featureBindingDefinitions;

		public override string? ToString() => $"Diving Location";

		public DivingLocationViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
		[Category("RestrictedArea")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("RestrictedArea")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("RestrictedArea")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfRestrictedAreaList), typeof(categoryOfRestrictedArea))]
		public ObservableCollection<categoryOfRestrictedArea> categoryOfRestrictedArea  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfRestrictedArea[] categoryOfRestrictedAreaList => [(categoryOfRestrictedArea)1,(categoryOfRestrictedArea)4,(categoryOfRestrictedArea)5,(categoryOfRestrictedArea)6,(categoryOfRestrictedArea)7,(categoryOfRestrictedArea)8,(categoryOfRestrictedArea)9,(categoryOfRestrictedArea)10,(categoryOfRestrictedArea)12,(categoryOfRestrictedArea)14,(categoryOfRestrictedArea)18,(categoryOfRestrictedArea)19,(categoryOfRestrictedArea)20,(categoryOfRestrictedArea)21,(categoryOfRestrictedArea)22,(categoryOfRestrictedArea)23,(categoryOfRestrictedArea)24,(categoryOfRestrictedArea)25,(categoryOfRestrictedArea)27,(categoryOfRestrictedArea)28,(categoryOfRestrictedArea)29,(categoryOfRestrictedArea)30,(categoryOfRestrictedArea)31,(categoryOfRestrictedArea)32,(categoryOfRestrictedArea)501];
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("RestrictedArea")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private String? _nationality  = default;

		[Category("RestrictedArea")]
		public String? nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}
		[Category("RestrictedArea")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)9,(status)18,(status)28,(status)501];
		[Category("RestrictedArea")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("RestrictedArea")]
		public ObservableCollection<vesselSpeedLimitViewModel> vesselSpeedLimit  { get; set; } = new ();
		[Category("RestrictedArea")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		private String? _interoperabilityIdentifier  = default;

		[Category("RestrictedArea")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private String? _controllingAuthority  = default;

		[Category("RestrictedArea")]
		public String? controllingAuthority {
			get {
				return _controllingAuthority;
			}
			set {
				SetValue(ref _controllingAuthority, value);
			}
		}
		[Category("RestrictedArea")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(restrictionList), typeof(restriction))]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)7,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)14,(restriction)15,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)26,(restriction)27,(restriction)39,(restriction)42];


		public override FeatureViewModel<RestrictedArea> Load(RestrictedArea instance) {
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			categoryOfRestrictedArea.Clear();
			if (instance.categoryOfRestrictedArea is not null) {
				foreach(var e in instance.categoryOfRestrictedArea)
					categoryOfRestrictedArea.Add(e);
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			nationality = instance.nationality;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			vesselSpeedLimit.Clear();
			if (instance.vesselSpeedLimit is not null) {
				foreach(var e in instance.vesselSpeedLimit)
					vesselSpeedLimit.Add(new vesselSpeedLimitViewModel().Load(e));
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			controllingAuthority = instance.controllingAuthority;
			restriction.Clear();
			if (instance.restriction is not null) {
				foreach(var e in instance.restriction)
					restriction.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new RestrictedArea {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				nationality = this.nationality,
				status = this.status.ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				vesselSpeedLimit = this.vesselSpeedLimit.Select(e => e.Model).ToList(),
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				controllingAuthority = this.controllingAuthority,
				restriction = this.restriction.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RestrictedArea Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			categoryOfRestrictedArea = this.categoryOfRestrictedArea.ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			nationality = this._nationality,
			status = this.status.ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			vesselSpeedLimit = this.vesselSpeedLimit.Select(e => e.Model).ToList(),
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			controllingAuthority = this._controllingAuthority,
			restriction = this.restriction.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => RestrictedArea._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => RestrictedArea._featureBindingDefinitions;

		public override string? ToString() => $"Restricted Area";

		public RestrictedAreaViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			categoryOfRestrictedArea.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfRestrictedArea));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			vesselSpeedLimit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(vesselSpeedLimit));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(restriction));
			};
		}
	}

	/// <summary>
	/// An assembly of wires or fibres, or a wire rope or chain, which has been laid underwater or buried beneath the seafloor.
	/// </summary>
	[CategoryOrder("CableSubmarine",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CableSubmarineViewModel : FeatureViewModel<CableSubmarine> {
		[Category("CableSubmarine")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)4,(status)13,(status)18];
		private decimal? _depthRangeMinimumValue  = default;

		[Category("CableSubmarine")]
		public decimal? depthRangeMinimumValue {
			get {
				return _depthRangeMinimumValue;
			}
			set {
				SetValue(ref _depthRangeMinimumValue, value);
			}
		}
		private decimal? _buriedDepth  = default;

		[Category("CableSubmarine")]
		public decimal? buriedDepth {
			get {
				return _buriedDepth;
			}
			set {
				SetValue(ref _buriedDepth, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("CableSubmarine")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("CableSubmarine")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		[Category("CableSubmarine")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private categoryOfCable? _categoryOfCable  = default;

		[Category("CableSubmarine")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfCableList), typeof(categoryOfCable))]
		public categoryOfCable? categoryOfCable {
			get {
				return _categoryOfCable;
			}
			set {
				SetValue(ref _categoryOfCable, value);
			}
		}

		[Browsable(false)]
		public categoryOfCable[] categoryOfCableList => [(categoryOfCable)1,(categoryOfCable)6,(categoryOfCable)7,(categoryOfCable)9,(categoryOfCable)10];
		private String? _interoperabilityIdentifier  = default;

		[Category("CableSubmarine")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private condition? _condition  = default;

		[Category("CableSubmarine")]
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
		public condition[] conditionList => [(condition)1,(condition)5];
		[Category("CableSubmarine")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("CableSubmarine")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private String? _agencyResponsibleForProduction  = default;

		[Category("CableSubmarine")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("CableSubmarine")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}


		public override FeatureViewModel<CableSubmarine> Load(CableSubmarine instance) {
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			depthRangeMinimumValue = instance.depthRangeMinimumValue;
			buriedDepth = instance.buriedDepth;
			reportedDate = instance.reportedDate;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			categoryOfCable = instance.categoryOfCable;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			condition = instance.condition;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new CableSubmarine {
				status = this.status.ToList(),
				depthRangeMinimumValue = this.depthRangeMinimumValue,
				buriedDepth = this.buriedDepth,
				reportedDate = this.reportedDate,
				sourceIdentification = this.sourceIdentification?.Model,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				categoryOfCable = this.categoryOfCable,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				condition = this.condition,
				information = this.information.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				fixedDateRange = this.fixedDateRange?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CableSubmarine Model => new () {
			status = this.status.ToList(),
			depthRangeMinimumValue = this._depthRangeMinimumValue,
			buriedDepth = this._buriedDepth,
			reportedDate = this._reportedDate,
			sourceIdentification = this._sourceIdentification?.Model,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			categoryOfCable = this._categoryOfCable,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			condition = this._condition,
			information = this.information.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			fixedDateRange = this._fixedDateRange?.Model,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => CableSubmarine._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => CableSubmarine._featureBindingDefinitions;

		public override string? ToString() => $"Cable Submarine";

		public CableSubmarineViewModel() : base() {
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// The ruined remains of a stranded or sunken vessel which has been rendered useless.
	/// </summary>
	[CategoryOrder("Wreck",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class WreckViewModel : FeatureViewModel<Wreck> {
		private decimal? _surroundingDepth  = default;

		[Category("Wreck")]
		public decimal? surroundingDepth {
			get {
				return _surroundingDepth;
			}
			set {
				SetValue(ref _surroundingDepth, value);
			}
		}
		[Category("Wreck")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(techniqueOfVerticalMeasurementList), typeof(techniqueOfVerticalMeasurement))]
		public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1,(techniqueOfVerticalMeasurement)2,(techniqueOfVerticalMeasurement)3,(techniqueOfVerticalMeasurement)4,(techniqueOfVerticalMeasurement)5,(techniqueOfVerticalMeasurement)8,(techniqueOfVerticalMeasurement)9,(techniqueOfVerticalMeasurement)10,(techniqueOfVerticalMeasurement)11,(techniqueOfVerticalMeasurement)12,(techniqueOfVerticalMeasurement)13,(techniqueOfVerticalMeasurement)15,(techniqueOfVerticalMeasurement)16,(techniqueOfVerticalMeasurement)17,(techniqueOfVerticalMeasurement)18];
		private horizontalPositionUncertaintyViewModel? _horizontalPositionUncertainty  = default;

		[Category("Wreck")]
		[ExpandableObject]
		public horizontalPositionUncertaintyViewModel? horizontalPositionUncertainty {
			get {
				return _horizontalPositionUncertainty;
			}
			set {
				SetValue(ref _horizontalPositionUncertainty, value);
			}
		}
		private visualProminence? _visualProminence  = default;

		[Category("Wreck")]
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
		private DateOnly? _reportedDate  = default;

		[Category("Wreck")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private decimal? _horizontalLength  = default;

		[Category("Wreck")]
		public decimal? horizontalLength {
			get {
				return _horizontalLength;
			}
			set {
				SetValue(ref _horizontalLength, value);
			}
		}
		private Boolean? _radarConspicuous  = default;

		[Category("Wreck")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		private String? _currentScourDimensions  = default;

		[Category("Wreck")]
		public String? currentScourDimensions {
			get {
				return _currentScourDimensions;
			}
			set {
				SetValue(ref _currentScourDimensions, value);
			}
		}
		[Category("Wreck")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)7,(status)13,(status)18];
		private sonarSignalStrength? _sonarSignalStrength  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(sonarSignalStrengthList), typeof(sonarSignalStrength))]
		public sonarSignalStrength? sonarSignalStrength {
			get {
				return _sonarSignalStrength;
			}
			set {
				SetValue(ref _sonarSignalStrength, value);
			}
		}

		[Browsable(false)]
		public sonarSignalStrength[] sonarSignalStrengthList => [(sonarSignalStrength)501,(sonarSignalStrength)502,(sonarSignalStrength)503,(sonarSignalStrength)504];
		[Category("Wreck")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private magneticInformationViewModel? _magneticInformation  = default;

		[Category("Wreck")]
		[ExpandableObject]
		public magneticInformationViewModel? magneticInformation {
			get {
				return _magneticInformation;
			}
			set {
				SetValue(ref _magneticInformation, value);
			}
		}
		private String? _agencyResponsibleForProduction  = default;

		[Category("Wreck")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		[Category("Wreck")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8];
		private decimal? _defaultClearanceDepth  = default;

		[Category("Wreck")]
		public decimal? defaultClearanceDepth {
			get {
				return _defaultClearanceDepth;
			}
			set {
				SetValue(ref _defaultClearanceDepth, value);
			}
		}
		private natureOfSurface? _natureOfSurface  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfSurfaceList), typeof(natureOfSurface))]
		public natureOfSurface? natureOfSurface {
			get {
				return _natureOfSurface;
			}
			set {
				SetValue(ref _natureOfSurface, value);
			}
		}

		[Browsable(false)]
		public natureOfSurface[] natureOfSurfaceList => [(natureOfSurface)1,(natureOfSurface)2,(natureOfSurface)3,(natureOfSurface)4,(natureOfSurface)5,(natureOfSurface)6,(natureOfSurface)7,(natureOfSurface)8,(natureOfSurface)9,(natureOfSurface)11,(natureOfSurface)14,(natureOfSurface)17,(natureOfSurface)18];
		private decimal? _orientationValue  = default;

		[Category("Wreck")]
		public decimal? orientationValue {
			get {
				return _orientationValue;
			}
			set {
				SetValue(ref _orientationValue, value);
			}
		}
		private String? _typeOfWreck  = default;

		[Category("Wreck")]
		public String? typeOfWreck {
			get {
				return _typeOfWreck;
			}
			set {
				SetValue(ref _typeOfWreck, value);
			}
		}
		private waterLevelEffect _waterLevelEffect ;

		[Category("Wreck")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(waterLevelEffectList), typeof(waterLevelEffect))]
		public waterLevelEffect waterLevelEffect {
			get {
				return _waterLevelEffect;
			}
			set {
				SetValue(ref _waterLevelEffect, value);
			}
		}

		[Browsable(false)]
		public waterLevelEffect[] waterLevelEffectList => [(waterLevelEffect)1,(waterLevelEffect)2,(waterLevelEffect)3,(waterLevelEffect)4,(waterLevelEffect)5];
		private decimal? _verticalLength  = default;

		[Category("Wreck")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private categoryOfWreck? _categoryOfWreck  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfWreckList), typeof(categoryOfWreck))]
		public categoryOfWreck? categoryOfWreck {
			get {
				return _categoryOfWreck;
			}
			set {
				SetValue(ref _categoryOfWreck, value);
			}
		}

		[Browsable(false)]
		public categoryOfWreck[] categoryOfWreckList => [(categoryOfWreck)1,(categoryOfWreck)2,(categoryOfWreck)3,(categoryOfWreck)4,(categoryOfWreck)5];
		private qualityOfHorizontalMeasurement? _qualityOfHorizontalMeasurement  = default;

		[Category("Wreck")]
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
		public qualityOfHorizontalMeasurement[] qualityOfHorizontalMeasurementList => [(qualityOfHorizontalMeasurement)4,(qualityOfHorizontalMeasurement)5];
		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Category("Wreck")]
		[ExpandableObject]
		public verticalUncertaintyViewModel? verticalUncertainty {
			get {
				return _verticalUncertainty;
			}
			set {
				SetValue(ref _verticalUncertainty, value);
			}
		}
		private decimal? _height  = default;

		[Category("Wreck")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("Wreck")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private String? _debrisField  = default;

		[Category("Wreck")]
		public String? debrisField {
			get {
				return _debrisField;
			}
			set {
				SetValue(ref _debrisField, value);
			}
		}
		[Category("Wreck")]
		public ObservableCollection<String> nationality  { get; set; } = new ();
		private lastSourceInformationViewModel? _lastSourceInformation  = default;

		[Category("Wreck")]
		[ExpandableObject]
		public lastSourceInformationViewModel? lastSourceInformation {
			get {
				return _lastSourceInformation;
			}
			set {
				SetValue(ref _lastSourceInformation, value);
			}
		}
		private qualityOfVerticalMeasurement? _qualityOfVerticalMeasurement  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(qualityOfVerticalMeasurementList), typeof(qualityOfVerticalMeasurement))]
		public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement {
			get {
				return _qualityOfVerticalMeasurement;
			}
			set {
				SetValue(ref _qualityOfVerticalMeasurement, value);
			}
		}

		[Browsable(false)]
		public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1,(qualityOfVerticalMeasurement)2,(qualityOfVerticalMeasurement)3,(qualityOfVerticalMeasurement)4,(qualityOfVerticalMeasurement)6,(qualityOfVerticalMeasurement)7,(qualityOfVerticalMeasurement)8,(qualityOfVerticalMeasurement)9];
		private cardinalPointOrientation? _cardinalPointOrientation  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(cardinalPointOrientationList), typeof(cardinalPointOrientation))]
		public cardinalPointOrientation? cardinalPointOrientation {
			get {
				return _cardinalPointOrientation;
			}
			set {
				SetValue(ref _cardinalPointOrientation, value);
			}
		}

		[Browsable(false)]
		public cardinalPointOrientation[] cardinalPointOrientationList => [(cardinalPointOrientation)501,(cardinalPointOrientation)502,(cardinalPointOrientation)503,(cardinalPointOrientation)504];
		[Category("Wreck")]
		public ObservableCollection<vesselMeasurementsSpecificationViewModel> vesselMeasurementsSpecification  { get; set; } = new ();
		private Boolean? _existenceOfRestrictedArea  = default;

		[Category("Wreck")]
		public Boolean? existenceOfRestrictedArea {
			get {
				return _existenceOfRestrictedArea;
			}
			set {
				SetValue(ref _existenceOfRestrictedArea, value);
			}
		}
		private DateOnly? _dateSunk  = default;

		[Category("Wreck")]
		public DateOnly? dateSunk {
			get {
				return _dateSunk;
			}
			set {
				SetValue(ref _dateSunk, value);
			}
		}
		private firstSourceInformationViewModel? _firstSourceInformation  = default;

		[Category("Wreck")]
		[ExpandableObject]
		public firstSourceInformationViewModel? firstSourceInformation {
			get {
				return _firstSourceInformation;
			}
			set {
				SetValue(ref _firstSourceInformation, value);
			}
		}
		private decimal? _horizontalWidth  = default;

		[Category("Wreck")]
		public decimal? horizontalWidth {
			get {
				return _horizontalWidth;
			}
			set {
				SetValue(ref _horizontalWidth, value);
			}
		}
		private decimal? _valueOfSounding  = default;

		[Category("Wreck")]
		public decimal? valueOfSounding {
			get {
				return _valueOfSounding;
			}
			set {
				SetValue(ref _valueOfSounding, value);
			}
		}
		[Category("Wreck")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(productList), typeof(product))]
		public ObservableCollection<product> product  { get; set; } = new ();

		[Browsable(false)]
		public product[] productList => [(product)1,(product)2,(product)3,(product)4,(product)5,(product)6,(product)7,(product)8,(product)9,(product)10,(product)11,(product)12,(product)13,(product)14,(product)15,(product)16,(product)17,(product)18,(product)19,(product)20,(product)21,(product)22,(product)23,(product)24,(product)25];
		private String? _pictorialRepresentation  = default;

		[Category("Wreck")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private Boolean? _displayUncertainties  = default;

		[Category("Wreck")]
		public Boolean? displayUncertainties {
			get {
				return _displayUncertainties;
			}
			set {
				SetValue(ref _displayUncertainties, value);
			}
		}
		private expositionOfSounding? _expositionOfSounding  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(expositionOfSoundingList), typeof(expositionOfSounding))]
		public expositionOfSounding? expositionOfSounding {
			get {
				return _expositionOfSounding;
			}
			set {
				SetValue(ref _expositionOfSounding, value);
			}
		}

		[Browsable(false)]
		public expositionOfSounding[] expositionOfSoundingList => [(expositionOfSounding)1,(expositionOfSounding)2,(expositionOfSounding)3];
		[Category("Wreck")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();


		public override FeatureViewModel<Wreck> Load(Wreck instance) {
			surroundingDepth = instance.surroundingDepth;
			techniqueOfVerticalMeasurement.Clear();
			if (instance.techniqueOfVerticalMeasurement is not null) {
				foreach(var e in instance.techniqueOfVerticalMeasurement)
					techniqueOfVerticalMeasurement.Add(e);
			}
			horizontalPositionUncertainty = new ();
			if (instance.horizontalPositionUncertainty != default) {
				horizontalPositionUncertainty.Load(instance.horizontalPositionUncertainty);
			}
			visualProminence = instance.visualProminence;
			reportedDate = instance.reportedDate;
			horizontalLength = instance.horizontalLength;
			radarConspicuous = instance.radarConspicuous;
			currentScourDimensions = instance.currentScourDimensions;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			sonarSignalStrength = instance.sonarSignalStrength;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			magneticInformation = new ();
			if (instance.magneticInformation != default) {
				magneticInformation.Load(instance.magneticInformation);
			}
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			defaultClearanceDepth = instance.defaultClearanceDepth;
			natureOfSurface = instance.natureOfSurface;
			orientationValue = instance.orientationValue;
			typeOfWreck = instance.typeOfWreck;
			waterLevelEffect = instance.waterLevelEffect;
			verticalLength = instance.verticalLength;
			categoryOfWreck = instance.categoryOfWreck;
			qualityOfHorizontalMeasurement = instance.qualityOfHorizontalMeasurement;
			verticalUncertainty = new ();
			if (instance.verticalUncertainty != default) {
				verticalUncertainty.Load(instance.verticalUncertainty);
			}
			height = instance.height;
			scaleMinimum = instance.scaleMinimum;
			debrisField = instance.debrisField;
			nationality.Clear();
			if (instance.nationality is not null) {
				foreach(var e in instance.nationality)
					nationality.Add(e);
			}
			lastSourceInformation = new ();
			if (instance.lastSourceInformation != default) {
				lastSourceInformation.Load(instance.lastSourceInformation);
			}
			qualityOfVerticalMeasurement = instance.qualityOfVerticalMeasurement;
			cardinalPointOrientation = instance.cardinalPointOrientation;
			vesselMeasurementsSpecification.Clear();
			if (instance.vesselMeasurementsSpecification is not null) {
				foreach(var e in instance.vesselMeasurementsSpecification)
					vesselMeasurementsSpecification.Add(new vesselMeasurementsSpecificationViewModel().Load(e));
			}
			existenceOfRestrictedArea = instance.existenceOfRestrictedArea;
			dateSunk = instance.dateSunk;
			firstSourceInformation = new ();
			if (instance.firstSourceInformation != default) {
				firstSourceInformation.Load(instance.firstSourceInformation);
			}
			horizontalWidth = instance.horizontalWidth;
			valueOfSounding = instance.valueOfSounding;
			product.Clear();
			if (instance.product is not null) {
				foreach(var e in instance.product)
					product.Add(e);
			}
			pictorialRepresentation = instance.pictorialRepresentation;
			displayUncertainties = instance.displayUncertainties;
			expositionOfSounding = instance.expositionOfSounding;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Wreck {
				surroundingDepth = this.surroundingDepth,
				techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
				horizontalPositionUncertainty = this.horizontalPositionUncertainty?.Model,
				visualProminence = this.visualProminence,
				reportedDate = this.reportedDate,
				horizontalLength = this.horizontalLength,
				radarConspicuous = this.radarConspicuous,
				currentScourDimensions = this.currentScourDimensions,
				status = this.status.ToList(),
				sonarSignalStrength = this.sonarSignalStrength,
				information = this.information.Select(e => e.Model).ToList(),
				magneticInformation = this.magneticInformation?.Model,
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				defaultClearanceDepth = this.defaultClearanceDepth,
				natureOfSurface = this.natureOfSurface,
				orientationValue = this.orientationValue,
				typeOfWreck = this.typeOfWreck,
				waterLevelEffect = this.waterLevelEffect,
				verticalLength = this.verticalLength,
				categoryOfWreck = this.categoryOfWreck,
				qualityOfHorizontalMeasurement = this.qualityOfHorizontalMeasurement,
				verticalUncertainty = this.verticalUncertainty?.Model,
				height = this.height,
				scaleMinimum = this.scaleMinimum,
				debrisField = this.debrisField,
				nationality = this.nationality.ToList(),
				lastSourceInformation = this.lastSourceInformation?.Model,
				qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement,
				cardinalPointOrientation = this.cardinalPointOrientation,
				vesselMeasurementsSpecification = this.vesselMeasurementsSpecification.Select(e => e.Model).ToList(),
				existenceOfRestrictedArea = this.existenceOfRestrictedArea,
				dateSunk = this.dateSunk,
				firstSourceInformation = this.firstSourceInformation?.Model,
				horizontalWidth = this.horizontalWidth,
				valueOfSounding = this.valueOfSounding,
				product = this.product.ToList(),
				pictorialRepresentation = this.pictorialRepresentation,
				displayUncertainties = this.displayUncertainties,
				expositionOfSounding = this.expositionOfSounding,
				featureName = this.featureName.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Wreck Model => new () {
			surroundingDepth = this._surroundingDepth,
			techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
			horizontalPositionUncertainty = this._horizontalPositionUncertainty?.Model,
			visualProminence = this._visualProminence,
			reportedDate = this._reportedDate,
			horizontalLength = this._horizontalLength,
			radarConspicuous = this._radarConspicuous,
			currentScourDimensions = this._currentScourDimensions,
			status = this.status.ToList(),
			sonarSignalStrength = this._sonarSignalStrength,
			information = this.information.Select(e => e.Model).ToList(),
			magneticInformation = this._magneticInformation?.Model,
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			defaultClearanceDepth = this._defaultClearanceDepth,
			natureOfSurface = this._natureOfSurface,
			orientationValue = this._orientationValue,
			typeOfWreck = this._typeOfWreck,
			waterLevelEffect = this._waterLevelEffect,
			verticalLength = this._verticalLength,
			categoryOfWreck = this._categoryOfWreck,
			qualityOfHorizontalMeasurement = this._qualityOfHorizontalMeasurement,
			verticalUncertainty = this._verticalUncertainty?.Model,
			height = this._height,
			scaleMinimum = this._scaleMinimum,
			debrisField = this._debrisField,
			nationality = this.nationality.ToList(),
			lastSourceInformation = this._lastSourceInformation?.Model,
			qualityOfVerticalMeasurement = this._qualityOfVerticalMeasurement,
			cardinalPointOrientation = this._cardinalPointOrientation,
			vesselMeasurementsSpecification = this.vesselMeasurementsSpecification.Select(e => e.Model).ToList(),
			existenceOfRestrictedArea = this._existenceOfRestrictedArea,
			dateSunk = this._dateSunk,
			firstSourceInformation = this._firstSourceInformation?.Model,
			horizontalWidth = this._horizontalWidth,
			valueOfSounding = this._valueOfSounding,
			product = this.product.ToList(),
			pictorialRepresentation = this._pictorialRepresentation,
			displayUncertainties = this._displayUncertainties,
			expositionOfSounding = this._expositionOfSounding,
			featureName = this.featureName.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => Wreck._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => Wreck._featureBindingDefinitions;

		public override string? ToString() => $"Wreck";

		public WreckViewModel() : base() {
			techniqueOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(techniqueOfVerticalMeasurement));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			nationality.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(nationality));
			};
			vesselMeasurementsSpecification.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(vesselMeasurementsSpecification));
			};
			product.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(product));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// A pre-planned dormant channel and/or route, surveyed for mine-like contacts during peacetime that can be 'activated' to provide shipping with safe navigable routes.
	/// </summary>
	[CategoryOrder("QRoute",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class QRouteViewModel : FeatureViewModel<QRoute> {
		private String? _agencyResponsibleForProduction  = default;

		[Category("QRoute")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		[Category("QRoute")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("QRoute")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("QRoute")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)2,(status)503];
		private qRouteChannelWidthViewModel? _qRouteChannelWidth  = default;

		[Category("QRoute")]
		[ExpandableObject]
		public qRouteChannelWidthViewModel? qRouteChannelWidth {
			get {
				return _qRouteChannelWidth;
			}
			set {
				SetValue(ref _qRouteChannelWidth, value);
			}
		}
		private directionHeadingViewModel? _directionHeading  = default;

		[Category("QRoute")]
		[ExpandableObject]
		public directionHeadingViewModel? directionHeading {
			get {
				return _directionHeading;
			}
			set {
				SetValue(ref _directionHeading, value);
			}
		}
		private String? _nationality  = default;

		[Category("QRoute")]
		public String? nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}


		public override FeatureViewModel<QRoute> Load(QRoute instance) {
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
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
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			qRouteChannelWidth = new ();
			if (instance.qRouteChannelWidth != default) {
				qRouteChannelWidth.Load(instance.qRouteChannelWidth);
			}
			directionHeading = new ();
			if (instance.directionHeading != default) {
				directionHeading.Load(instance.directionHeading);
			}
			nationality = instance.nationality;
			return this;
		}

		public override string Serialize() {
			var instance = new QRoute {
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				status = this.status.ToList(),
				qRouteChannelWidth = this.qRouteChannelWidth?.Model,
				directionHeading = this.directionHeading?.Model,
				nationality = this.nationality,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public QRoute Model => new () {
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			status = this.status.ToList(),
			qRouteChannelWidth = this._qRouteChannelWidth?.Model,
			directionHeading = this._directionHeading?.Model,
			nationality = this._nationality,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => QRoute._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => QRoute._featureBindingDefinitions;

		public override string? ToString() => $"Q-Route";

		public QRouteViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
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
	/// CompletenessOfProductSpecification (missing definition)
	/// </summary>
	[CategoryOrder("CompletenessOfProductSpecification",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CompletenessOfProductSpecificationViewModel : FeatureViewModel<CompletenessOfProductSpecification> {
		private String? _agencyResponsibleForProduction  = default;

		[Category("CompletenessOfProductSpecification")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private categoryOfCompleteness _categoryOfCompleteness ;

		[Category("CompletenessOfProductSpecification")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfCompletenessList), typeof(categoryOfCompleteness))]
		public categoryOfCompleteness categoryOfCompleteness {
			get {
				return _categoryOfCompleteness;
			}
			set {
				SetValue(ref _categoryOfCompleteness, value);
			}
		}

		[Browsable(false)]
		public categoryOfCompleteness[] categoryOfCompletenessList => [(categoryOfCompleteness)501,(categoryOfCompleteness)502];
		private String? _copyrightStatement  = default;

		[Category("CompletenessOfProductSpecification")]
		public String? copyrightStatement {
			get {
				return _copyrightStatement;
			}
			set {
				SetValue(ref _copyrightStatement, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("CompletenessOfProductSpecification")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("CompletenessOfProductSpecification")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		[Category("CompletenessOfProductSpecification")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override FeatureViewModel<CompletenessOfProductSpecification> Load(CompletenessOfProductSpecification instance) {
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			categoryOfCompleteness = instance.categoryOfCompleteness;
			copyrightStatement = instance.copyrightStatement;
			reportedDate = instance.reportedDate;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new CompletenessOfProductSpecification {
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				categoryOfCompleteness = this.categoryOfCompleteness,
				copyrightStatement = this.copyrightStatement,
				reportedDate = this.reportedDate,
				sourceIdentification = this.sourceIdentification?.Model,
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CompletenessOfProductSpecification Model => new () {
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			categoryOfCompleteness = this._categoryOfCompleteness,
			copyrightStatement = this._copyrightStatement,
			reportedDate = this._reportedDate,
			sourceIdentification = this._sourceIdentification?.Model,
			information = this.information.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => CompletenessOfProductSpecification._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => CompletenessOfProductSpecification._featureBindingDefinitions;

		public override string? ToString() => $"CompletenessOfProductSpecification (missing Name)";

		public CompletenessOfProductSpecificationViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// A place where equipment for saving life at sea is maintained.
	/// </summary>
	[CategoryOrder("RescueStation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RescueStationViewModel : FeatureViewModel<RescueStation> {
		[Category("RescueStation")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)14,(status)16,(status)17];
		[Category("RescueStation")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("RescueStation")]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("RescueStation")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("RescueStation")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private String? _interoperabilityIdentifier  = default;

		[Category("RescueStation")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("RescueStation")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfRescueStationList), typeof(categoryOfRescueStation))]
		public ObservableCollection<categoryOfRescueStation> categoryOfRescueStation  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfRescueStation[] categoryOfRescueStationList => [(categoryOfRescueStation)1,(categoryOfRescueStation)2,(categoryOfRescueStation)4,(categoryOfRescueStation)5,(categoryOfRescueStation)6,(categoryOfRescueStation)7,(categoryOfRescueStation)8];
		private int? _scaleMinimum  = default;

		[Category("RescueStation")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("RescueStation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override FeatureViewModel<RescueStation> Load(RescueStation instance) {
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			communicationChannel.Clear();
			if (instance.communicationChannel is not null) {
				foreach(var e in instance.communicationChannel)
					communicationChannel.Add(e);
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			categoryOfRescueStation.Clear();
			if (instance.categoryOfRescueStation is not null) {
				foreach(var e in instance.categoryOfRescueStation)
					categoryOfRescueStation.Add(e);
			}
			scaleMinimum = instance.scaleMinimum;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new RescueStation {
				status = this.status.ToList(),
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				communicationChannel = this.communicationChannel.ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				categoryOfRescueStation = this.categoryOfRescueStation.ToList(),
				scaleMinimum = this.scaleMinimum,
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RescueStation Model => new () {
			status = this.status.ToList(),
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			communicationChannel = this.communicationChannel.ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			categoryOfRescueStation = this.categoryOfRescueStation.ToList(),
			scaleMinimum = this._scaleMinimum,
			information = this.information.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => RescueStation._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => RescueStation._featureBindingDefinitions;

		public override string? ToString() => $"Rescue Station";

		public RescueStationViewModel() : base() {
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(communicationChannel));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			categoryOfRescueStation.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfRescueStation));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
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
		[Category("CardinalBeacon")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("CardinalBeacon")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8];
		private colourPattern? _colourPattern  = default;

		[Category("CardinalBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public colourPattern? colourPattern {
			get {
				return _colourPattern;
			}
			set {
				SetValue(ref _colourPattern, value);
			}
		}

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6];
		private Boolean? _radarConspicuous  = default;

		[Category("CardinalBeacon")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		private beaconShape _beaconShape ;

		[Category("CardinalBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		public beaconShape[] beaconShapeList => [(beaconShape)1,(beaconShape)2,(beaconShape)3,(beaconShape)5,(beaconShape)6,(beaconShape)7];
		private topmarkViewModel? _topmark  = default;

		[Category("CardinalBeacon")]
		[ExpandableObject]
		public topmarkViewModel? topmark {
			get {
				return _topmark;
			}
			set {
				SetValue(ref _topmark, value);
			}
		}
		private categoryOfCardinalMark _categoryOfCardinalMark ;

		[Category("CardinalBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("CardinalBeacon")]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)11];
		[Category("CardinalBeacon")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)12,(status)18];
		private decimal? _height  = default;

		[Category("CardinalBeacon")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		[Category("CardinalBeacon")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("CardinalBeacon")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private decimal? _verticalLength  = default;

		[Category("CardinalBeacon")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("CardinalBeacon")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("CardinalBeacon")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		[Category("CardinalBeacon")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("CardinalBeacon")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		private decimal? _elevation  = default;

		[Category("CardinalBeacon")]
		public decimal? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("CardinalBeacon")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private condition? _condition  = default;

		[Category("CardinalBeacon")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)5];
		private visualProminence? _visualProminence  = default;

		[Category("CardinalBeacon")]
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
		[Category("CardinalBeacon")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();


		public override FeatureViewModel<CardinalBeacon> Load(CardinalBeacon instance) {
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			colourPattern = instance.colourPattern;
			radarConspicuous = instance.radarConspicuous;
			beaconShape = instance.beaconShape;
			topmark = new ();
			if (instance.topmark != default) {
				topmark.Load(instance.topmark);
			}
			categoryOfCardinalMark = instance.categoryOfCardinalMark;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			height = instance.height;
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			verticalLength = instance.verticalLength;
			scaleMinimum = instance.scaleMinimum;
			reportedDate = instance.reportedDate;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			elevation = instance.elevation;
			pictorialRepresentation = instance.pictorialRepresentation;
			condition = instance.condition;
			visualProminence = instance.visualProminence;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new CardinalBeacon {
				information = this.information.Select(e => e.Model).ToList(),
				natureOfConstruction = this.natureOfConstruction.ToList(),
				colourPattern = this.colourPattern,
				radarConspicuous = this.radarConspicuous,
				beaconShape = this.beaconShape,
				topmark = this.topmark?.Model,
				categoryOfCardinalMark = this.categoryOfCardinalMark,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				status = this.status.ToList(),
				height = this.height,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				verticalLength = this.verticalLength,
				scaleMinimum = this.scaleMinimum,
				reportedDate = this.reportedDate,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				colour = this.colour.ToList(),
				elevation = this.elevation,
				pictorialRepresentation = this.pictorialRepresentation,
				condition = this.condition,
				visualProminence = this.visualProminence,
				featureName = this.featureName.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CardinalBeacon Model => new () {
			information = this.information.Select(e => e.Model).ToList(),
			natureOfConstruction = this.natureOfConstruction.ToList(),
			colourPattern = this._colourPattern,
			radarConspicuous = this._radarConspicuous,
			beaconShape = this._beaconShape,
			topmark = this._topmark?.Model,
			categoryOfCardinalMark = this._categoryOfCardinalMark,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			status = this.status.ToList(),
			height = this._height,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			verticalLength = this._verticalLength,
			scaleMinimum = this._scaleMinimum,
			reportedDate = this._reportedDate,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			colour = this.colour.ToList(),
			elevation = this._elevation,
			pictorialRepresentation = this._pictorialRepresentation,
			condition = this._condition,
			visualProminence = this._visualProminence,
			featureName = this.featureName.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => CardinalBeacon._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => CardinalBeacon._featureBindingDefinitions;

		public override string? ToString() => $"Cardinal Beacon";

		public CardinalBeaconViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
		[Category("LightVessel")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)14,(status)16,(status)17];
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
		private String? _interoperabilityIdentifier  = default;

		[Category("LightVessel")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("LightVessel")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
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
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private String? _pictorialRepresentation  = default;

		[Category("LightVessel")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
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
		[Category("LightVessel")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("LightVessel")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6,(natureOfConstruction)7];
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("LightVessel")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("LightVessel")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		private colourPattern? _colourPattern  = default;

		[Category("LightVessel")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public colourPattern? colourPattern {
			get {
				return _colourPattern;
			}
			set {
				SetValue(ref _colourPattern, value);
			}
		}

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6];
		[Category("LightVessel")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
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


		public override FeatureViewModel<LightVessel> Load(LightVessel instance) {
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			visualProminence = instance.visualProminence;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			scaleMinimum = instance.scaleMinimum;
			radarConspicuous = instance.radarConspicuous;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			pictorialRepresentation = instance.pictorialRepresentation;
			horizontalLength = instance.horizontalLength;
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			colourPattern = instance.colourPattern;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			horizontalWidth = instance.horizontalWidth;
			verticalLength = instance.verticalLength;
			return this;
		}

		public override string Serialize() {
			var instance = new LightVessel {
				status = this.status.ToList(),
				visualProminence = this.visualProminence,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				scaleMinimum = this.scaleMinimum,
				radarConspicuous = this.radarConspicuous,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				pictorialRepresentation = this.pictorialRepresentation,
				horizontalLength = this.horizontalLength,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				natureOfConstruction = this.natureOfConstruction.ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern,
				information = this.information.Select(e => e.Model).ToList(),
				horizontalWidth = this.horizontalWidth,
				verticalLength = this.verticalLength,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LightVessel Model => new () {
			status = this.status.ToList(),
			visualProminence = this._visualProminence,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			scaleMinimum = this._scaleMinimum,
			radarConspicuous = this._radarConspicuous,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			pictorialRepresentation = this._pictorialRepresentation,
			horizontalLength = this._horizontalLength,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			natureOfConstruction = this.natureOfConstruction.ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			colour = this.colour.ToList(),
			colourPattern = this._colourPattern,
			information = this.information.Select(e => e.Model).ToList(),
			horizontalWidth = this._horizontalWidth,
			verticalLength = this._verticalLength,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => LightVessel._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => LightVessel._featureBindingDefinitions;

		public override string? ToString() => $"Light Vessel";

		public LightVesselViewModel() : base() {
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// The offshore zone in which exclusive fishing rights and management are held by the coastal nation.
	/// </summary>
	[CategoryOrder("FisheryZone",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class FisheryZoneViewModel : FeatureViewModel<FisheryZone> {
		private String? _interoperabilityIdentifier  = default;

		[Category("FisheryZone")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private String _nationality  = string.Empty;

		[Category("FisheryZone")]
		public String nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}
		[Category("FisheryZone")]
		public ObservableCollection<String> nationalMaritimeAuthority  { get; set; } = new ();
		[Category("FisheryZone")]
		public ObservableCollection<String> species  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("FisheryZone")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("FisheryZone")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("FisheryZone")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		[Category("FisheryZone")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private status? _status  = default;

		[Category("FisheryZone")]
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
		public status[] statusList => [(status)1,(status)5,(status)6,(status)7,(status)501,(status)502,(status)504,(status)519,(status)521];


		public override FeatureViewModel<FisheryZone> Load(FisheryZone instance) {
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			nationality = instance.nationality;
			nationalMaritimeAuthority.Clear();
			if (instance.nationalMaritimeAuthority is not null) {
				foreach(var e in instance.nationalMaritimeAuthority)
					nationalMaritimeAuthority.Add(e);
			}
			species.Clear();
			if (instance.species is not null) {
				foreach(var e in instance.species)
					species.Add(e);
			}
			scaleMinimum = instance.scaleMinimum;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			status = instance.status;
			return this;
		}

		public override string Serialize() {
			var instance = new FisheryZone {
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				nationality = this.nationality,
				nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
				species = this.species.ToList(),
				scaleMinimum = this.scaleMinimum,
				information = this.information.Select(e => e.Model).ToList(),
				sourceIdentification = this.sourceIdentification?.Model,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				status = this.status,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public FisheryZone Model => new () {
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			nationality = this._nationality,
			nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
			species = this.species.ToList(),
			scaleMinimum = this._scaleMinimum,
			information = this.information.Select(e => e.Model).ToList(),
			sourceIdentification = this._sourceIdentification?.Model,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			status = this._status,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => FisheryZone._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => FisheryZone._featureBindingDefinitions;

		public override string? ToString() => $"Fishery Zone";

		public FisheryZoneViewModel() : base() {
			nationalMaritimeAuthority.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(nationalMaritimeAuthority));
			};
			species.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(species));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// An area of the bottom of a body of water which has been deepened by dredging.
	/// </summary>
	[CategoryOrder("DredgedArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DredgedAreaViewModel : FeatureViewModel<DredgedArea> {
		private decimal? _maximumPermittedDraught  = default;

		[Category("DredgedArea")]
		public decimal? maximumPermittedDraught {
			get {
				return _maximumPermittedDraught;
			}
			set {
				SetValue(ref _maximumPermittedDraught, value);
			}
		}
		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Category("DredgedArea")]
		[ExpandableObject]
		public verticalUncertaintyViewModel? verticalUncertainty {
			get {
				return _verticalUncertainty;
			}
			set {
				SetValue(ref _verticalUncertainty, value);
			}
		}
		private DateOnly? _dredgedDate  = default;

		[Category("DredgedArea")]
		public DateOnly? dredgedDate {
			get {
				return _dredgedDate;
			}
			set {
				SetValue(ref _dredgedDate, value);
			}
		}
		[Category("DredgedArea")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private decimal? _depthRangeMaximumValue  = default;

		[Category("DredgedArea")]
		public decimal? depthRangeMaximumValue {
			get {
				return _depthRangeMaximumValue;
			}
			set {
				SetValue(ref _depthRangeMaximumValue, value);
			}
		}
		private qualityOfVerticalMeasurement? _qualityOfVerticalMeasurement  = default;

		[Category("DredgedArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(qualityOfVerticalMeasurementList), typeof(qualityOfVerticalMeasurement))]
		public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement {
			get {
				return _qualityOfVerticalMeasurement;
			}
			set {
				SetValue(ref _qualityOfVerticalMeasurement, value);
			}
		}

		[Browsable(false)]
		public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)10,(qualityOfVerticalMeasurement)11];
		[Category("DredgedArea")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(techniqueOfVerticalMeasurementList), typeof(techniqueOfVerticalMeasurement))]
		public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1,(techniqueOfVerticalMeasurement)2,(techniqueOfVerticalMeasurement)3,(techniqueOfVerticalMeasurement)8,(techniqueOfVerticalMeasurement)9,(techniqueOfVerticalMeasurement)13,(techniqueOfVerticalMeasurement)15,(techniqueOfVerticalMeasurement)16,(techniqueOfVerticalMeasurement)17,(techniqueOfVerticalMeasurement)18];
		private decimal _depthRangeMinimumValue ;

		[Category("DredgedArea")]
		public decimal depthRangeMinimumValue {
			get {
				return _depthRangeMinimumValue;
			}
			set {
				SetValue(ref _depthRangeMinimumValue, value);
			}
		}
		[Category("DredgedArea")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(restrictionList), typeof(restriction))]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)8,(restriction)11,(restriction)12,(restriction)13,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)23,(restriction)25,(restriction)27,(restriction)39];
		[Category("DredgedArea")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override FeatureViewModel<DredgedArea> Load(DredgedArea instance) {
			maximumPermittedDraught = instance.maximumPermittedDraught;
			verticalUncertainty = new ();
			if (instance.verticalUncertainty != default) {
				verticalUncertainty.Load(instance.verticalUncertainty);
			}
			dredgedDate = instance.dredgedDate;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			depthRangeMaximumValue = instance.depthRangeMaximumValue;
			qualityOfVerticalMeasurement = instance.qualityOfVerticalMeasurement;
			techniqueOfVerticalMeasurement.Clear();
			if (instance.techniqueOfVerticalMeasurement is not null) {
				foreach(var e in instance.techniqueOfVerticalMeasurement)
					techniqueOfVerticalMeasurement.Add(e);
			}
			depthRangeMinimumValue = instance.depthRangeMinimumValue;
			restriction.Clear();
			if (instance.restriction is not null) {
				foreach(var e in instance.restriction)
					restriction.Add(e);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new DredgedArea {
				maximumPermittedDraught = this.maximumPermittedDraught,
				verticalUncertainty = this.verticalUncertainty?.Model,
				dredgedDate = this.dredgedDate,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				depthRangeMaximumValue = this.depthRangeMaximumValue,
				qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement,
				techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
				depthRangeMinimumValue = this.depthRangeMinimumValue,
				restriction = this.restriction.ToList(),
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DredgedArea Model => new () {
			maximumPermittedDraught = this._maximumPermittedDraught,
			verticalUncertainty = this._verticalUncertainty?.Model,
			dredgedDate = this._dredgedDate,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			depthRangeMaximumValue = this._depthRangeMaximumValue,
			qualityOfVerticalMeasurement = this._qualityOfVerticalMeasurement,
			techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
			depthRangeMinimumValue = this._depthRangeMinimumValue,
			restriction = this.restriction.ToList(),
			information = this.information.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => DredgedArea._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => DredgedArea._featureBindingDefinitions;

		public override string? ToString() => $"Dredged Area";

		public DredgedAreaViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			techniqueOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(techniqueOfVerticalMeasurement));
			};
			restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(restriction));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// A route in a body of water where a ferry crosses from one shoreline to another.
	/// </summary>
	[CategoryOrder("FerryRoute",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class FerryRouteViewModel : FeatureViewModel<FerryRoute> {
		[Category("FerryRoute")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)14];
		private String? _interoperabilityIdentifier  = default;

		[Category("FerryRoute")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("FerryRoute")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("FerryRoute")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("FerryRoute")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		[Category("FerryRoute")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		private String? _agencyResponsibleForProduction  = default;

		[Category("FerryRoute")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("FerryRoute")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("FerryRoute")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		[Category("FerryRoute")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfFerryList), typeof(categoryOfFerry))]
		public ObservableCollection<categoryOfFerry> categoryOfFerry  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfFerry[] categoryOfFerryList => [(categoryOfFerry)1,(categoryOfFerry)2,(categoryOfFerry)3,(categoryOfFerry)5];
		[Category("FerryRoute")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FerryRoute")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}


		public override FeatureViewModel<FerryRoute> Load(FerryRoute instance) {
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			scaleMinimum = instance.scaleMinimum;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			pictorialRepresentation = instance.pictorialRepresentation;
			reportedDate = instance.reportedDate;
			categoryOfFerry.Clear();
			if (instance.categoryOfFerry is not null) {
				foreach(var e in instance.categoryOfFerry)
					categoryOfFerry.Add(e);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new FerryRoute {
				status = this.status.ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				scaleMinimum = this.scaleMinimum,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIdentification = this.sourceIdentification?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				pictorialRepresentation = this.pictorialRepresentation,
				reportedDate = this.reportedDate,
				categoryOfFerry = this.categoryOfFerry.ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public FerryRoute Model => new () {
			status = this.status.ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			scaleMinimum = this._scaleMinimum,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIdentification = this._sourceIdentification?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			pictorialRepresentation = this._pictorialRepresentation,
			reportedDate = this._reportedDate,
			categoryOfFerry = this.categoryOfFerry.ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => FerryRoute._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => FerryRoute._featureBindingDefinitions;

		public override string? ToString() => $"Ferry Route";

		public FerryRouteViewModel() : base() {
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			categoryOfFerry.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfFerry));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// A fixed artificial structure in the water and/or adjoining the land. It may also refer to features such as training walls, which are not necessarily connected to, nor form part of the shoreline.
	/// </summary>
	[CategoryOrder("ShorelineConstruction",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ShorelineConstructionViewModel : FeatureViewModel<ShorelineConstruction> {
		private decimal? _horizontalLength  = default;

		[Category("ShorelineConstruction")]
		public decimal? horizontalLength {
			get {
				return _horizontalLength;
			}
			set {
				SetValue(ref _horizontalLength, value);
			}
		}
		private gradientOfSlope? _gradientOfSlope  = default;

		[Category("ShorelineConstruction")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(gradientOfSlopeList), typeof(gradientOfSlope))]
		public gradientOfSlope? gradientOfSlope {
			get {
				return _gradientOfSlope;
			}
			set {
				SetValue(ref _gradientOfSlope, value);
			}
		}

		[Browsable(false)]
		public gradientOfSlope[] gradientOfSlopeList => [(gradientOfSlope)501,(gradientOfSlope)502,(gradientOfSlope)503,(gradientOfSlope)504,(gradientOfSlope)505];
		[Category("ShorelineConstruction")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private condition? _condition  = default;

		[Category("ShorelineConstruction")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)5];
		private visualProminence? _visualProminence  = default;

		[Category("ShorelineConstruction")]
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
		[Category("ShorelineConstruction")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		private decimal? _horizontalWidth  = default;

		[Category("ShorelineConstruction")]
		public decimal? horizontalWidth {
			get {
				return _horizontalWidth;
			}
			set {
				SetValue(ref _horizontalWidth, value);
			}
		}
		private Boolean? _radarConspicuous  = default;

		[Category("ShorelineConstruction")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("ShorelineConstruction")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private horizontalClearanceFixedViewModel? _horizontalClearanceFixed  = default;

		[Category("ShorelineConstruction")]
		[ExpandableObject]
		public horizontalClearanceFixedViewModel? horizontalClearanceFixed {
			get {
				return _horizontalClearanceFixed;
			}
			set {
				SetValue(ref _horizontalClearanceFixed, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("ShorelineConstruction")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		[Category("ShorelineConstruction")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)6,(status)7,(status)8,(status)12,(status)13,(status)14,(status)28];
		private decimal? _verticalLength  = default;

		[Category("ShorelineConstruction")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		[Category("ShorelineConstruction")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private waterLevelEffect _waterLevelEffect ;

		[Category("ShorelineConstruction")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(waterLevelEffectList), typeof(waterLevelEffect))]
		public waterLevelEffect waterLevelEffect {
			get {
				return _waterLevelEffect;
			}
			set {
				SetValue(ref _waterLevelEffect, value);
			}
		}

		[Browsable(false)]
		public waterLevelEffect[] waterLevelEffectList => [(waterLevelEffect)1,(waterLevelEffect)2,(waterLevelEffect)3,(waterLevelEffect)4,(waterLevelEffect)5,(waterLevelEffect)6,(waterLevelEffect)7];
		[Category("ShorelineConstruction")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)11];
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("ShorelineConstruction")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private categoryOfShorelineConstruction? _categoryOfShorelineConstruction  = default;

		[Category("ShorelineConstruction")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfShorelineConstructionList), typeof(categoryOfShorelineConstruction))]
		public categoryOfShorelineConstruction? categoryOfShorelineConstruction {
			get {
				return _categoryOfShorelineConstruction;
			}
			set {
				SetValue(ref _categoryOfShorelineConstruction, value);
			}
		}

		[Browsable(false)]
		public categoryOfShorelineConstruction[] categoryOfShorelineConstructionList => [(categoryOfShorelineConstruction)1,(categoryOfShorelineConstruction)2,(categoryOfShorelineConstruction)3,(categoryOfShorelineConstruction)4,(categoryOfShorelineConstruction)5,(categoryOfShorelineConstruction)6,(categoryOfShorelineConstruction)7,(categoryOfShorelineConstruction)8,(categoryOfShorelineConstruction)9,(categoryOfShorelineConstruction)10,(categoryOfShorelineConstruction)11,(categoryOfShorelineConstruction)12,(categoryOfShorelineConstruction)13,(categoryOfShorelineConstruction)14,(categoryOfShorelineConstruction)15,(categoryOfShorelineConstruction)16,(categoryOfShorelineConstruction)17,(categoryOfShorelineConstruction)20,(categoryOfShorelineConstruction)22,(categoryOfShorelineConstruction)23,(categoryOfShorelineConstruction)501];
		private colourPattern? _colourPattern  = default;

		[Category("ShorelineConstruction")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public colourPattern? colourPattern {
			get {
				return _colourPattern;
			}
			set {
				SetValue(ref _colourPattern, value);
			}
		}

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6];
		private decimal? _height  = default;

		[Category("ShorelineConstruction")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("ShorelineConstruction")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}


		public override FeatureViewModel<ShorelineConstruction> Load(ShorelineConstruction instance) {
			horizontalLength = instance.horizontalLength;
			gradientOfSlope = instance.gradientOfSlope;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			condition = instance.condition;
			visualProminence = instance.visualProminence;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			horizontalWidth = instance.horizontalWidth;
			radarConspicuous = instance.radarConspicuous;
			scaleMinimum = instance.scaleMinimum;
			horizontalClearanceFixed = new ();
			if (instance.horizontalClearanceFixed != default) {
				horizontalClearanceFixed.Load(instance.horizontalClearanceFixed);
			}
			pictorialRepresentation = instance.pictorialRepresentation;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalLength = instance.verticalLength;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			waterLevelEffect = instance.waterLevelEffect;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			categoryOfShorelineConstruction = instance.categoryOfShorelineConstruction;
			colourPattern = instance.colourPattern;
			height = instance.height;
			reportedDate = instance.reportedDate;
			return this;
		}

		public override string Serialize() {
			var instance = new ShorelineConstruction {
				horizontalLength = this.horizontalLength,
				gradientOfSlope = this.gradientOfSlope,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				condition = this.condition,
				visualProminence = this.visualProminence,
				colour = this.colour.ToList(),
				horizontalWidth = this.horizontalWidth,
				radarConspicuous = this.radarConspicuous,
				scaleMinimum = this.scaleMinimum,
				horizontalClearanceFixed = this.horizontalClearanceFixed?.Model,
				pictorialRepresentation = this.pictorialRepresentation,
				status = this.status.ToList(),
				verticalLength = this.verticalLength,
				information = this.information.Select(e => e.Model).ToList(),
				waterLevelEffect = this.waterLevelEffect,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				categoryOfShorelineConstruction = this.categoryOfShorelineConstruction,
				colourPattern = this.colourPattern,
				height = this.height,
				reportedDate = this.reportedDate,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public ShorelineConstruction Model => new () {
			horizontalLength = this._horizontalLength,
			gradientOfSlope = this._gradientOfSlope,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			condition = this._condition,
			visualProminence = this._visualProminence,
			colour = this.colour.ToList(),
			horizontalWidth = this._horizontalWidth,
			radarConspicuous = this._radarConspicuous,
			scaleMinimum = this._scaleMinimum,
			horizontalClearanceFixed = this._horizontalClearanceFixed?.Model,
			pictorialRepresentation = this._pictorialRepresentation,
			status = this.status.ToList(),
			verticalLength = this._verticalLength,
			information = this.information.Select(e => e.Model).ToList(),
			waterLevelEffect = this._waterLevelEffect,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			categoryOfShorelineConstruction = this._categoryOfShorelineConstruction,
			colourPattern = this._colourPattern,
			height = this._height,
			reportedDate = this._reportedDate,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => ShorelineConstruction._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => ShorelineConstruction._featureBindingDefinitions;

		public override string? ToString() => $"Shoreline Construction";

		public ShorelineConstructionViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
		}
	}

	/// <summary>
	/// Generally, an area where the mariner has to be made aware of circumstances influencing the safety of navigation.
	/// </summary>
	[CategoryOrder("CautionArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CautionAreaViewModel : FeatureViewModel<CautionArea> {
		private DateOnly? _reportedDate  = default;

		[Category("CautionArea")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		[Category("CautionArea")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("CautionArea")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
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
		private int? _scaleMinimum  = default;

		[Category("CautionArea")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("CautionArea")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		[Category("CautionArea")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override FeatureViewModel<CautionArea> Load(CautionArea instance) {
			reportedDate = instance.reportedDate;
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			status = instance.status;
			condition = instance.condition;
			scaleMinimum = instance.scaleMinimum;
			pictorialRepresentation = instance.pictorialRepresentation;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new CautionArea {
				reportedDate = this.reportedDate,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				status = this.status,
				condition = this.condition,
				scaleMinimum = this.scaleMinimum,
				pictorialRepresentation = this.pictorialRepresentation,
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CautionArea Model => new () {
			reportedDate = this._reportedDate,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			status = this._status,
			condition = this._condition,
			scaleMinimum = this._scaleMinimum,
			pictorialRepresentation = this._pictorialRepresentation,
			information = this.information.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => CautionArea._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => CautionArea._featureBindingDefinitions;

		public override string? ToString() => $"Caution Area";

		public CautionAreaViewModel() : base() {
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// An area of a deep water route within which ships proceed in the same direction.
	/// </summary>
	[CategoryOrder("DeepWaterRoutePart",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DeepWaterRoutePartViewModel : FeatureViewModel<DeepWaterRoutePart> {
		private Boolean? _imoAdopted  = default;

		[Category("DeepWaterRoutePart")]
		public Boolean? imoAdopted {
			get {
				return _imoAdopted;
			}
			set {
				SetValue(ref _imoAdopted, value);
			}
		}
		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Category("DeepWaterRoutePart")]
		[ExpandableObject]
		public verticalUncertaintyViewModel? verticalUncertainty {
			get {
				return _verticalUncertainty;
			}
			set {
				SetValue(ref _verticalUncertainty, value);
			}
		}
		[Category("DeepWaterRoutePart")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private trafficFlow _trafficFlow ;

		[Category("DeepWaterRoutePart")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		private int? _scaleMinimum  = default;

		[Category("DeepWaterRoutePart")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("DeepWaterRoutePart")]
		public ObservableCollection<vesselSpeedLimitViewModel> vesselSpeedLimit  { get; set; } = new ();
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("DeepWaterRoutePart")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		[Category("DeepWaterRoutePart")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private decimal _depthRangeMinimumValue ;

		[Category("DeepWaterRoutePart")]
		public decimal depthRangeMinimumValue {
			get {
				return _depthRangeMinimumValue;
			}
			set {
				SetValue(ref _depthRangeMinimumValue, value);
			}
		}
		[Category("DeepWaterRoutePart")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(techniqueOfVerticalMeasurementList), typeof(techniqueOfVerticalMeasurement))]
		public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1,(techniqueOfVerticalMeasurement)3,(techniqueOfVerticalMeasurement)5,(techniqueOfVerticalMeasurement)8,(techniqueOfVerticalMeasurement)9,(techniqueOfVerticalMeasurement)13,(techniqueOfVerticalMeasurement)15,(techniqueOfVerticalMeasurement)16,(techniqueOfVerticalMeasurement)17,(techniqueOfVerticalMeasurement)18];
		[Category("DeepWaterRoutePart")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("DeepWaterRoutePart")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)3,(status)6,(status)9,(status)28];
		private decimal _orientationValue ;

		[Category("DeepWaterRoutePart")]
		public decimal orientationValue {
			get {
				return _orientationValue;
			}
			set {
				SetValue(ref _orientationValue, value);
			}
		}
		[Category("DeepWaterRoutePart")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(restrictionList), typeof(restriction))]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)27];
		[Category("DeepWaterRoutePart")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(qualityOfVerticalMeasurementList), typeof(qualityOfVerticalMeasurement))]
		public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1,(qualityOfVerticalMeasurement)2,(qualityOfVerticalMeasurement)3,(qualityOfVerticalMeasurement)4,(qualityOfVerticalMeasurement)6,(qualityOfVerticalMeasurement)7];


		public override FeatureViewModel<DeepWaterRoutePart> Load(DeepWaterRoutePart instance) {
			imoAdopted = instance.imoAdopted;
			verticalUncertainty = new ();
			if (instance.verticalUncertainty != default) {
				verticalUncertainty.Load(instance.verticalUncertainty);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			trafficFlow = instance.trafficFlow;
			scaleMinimum = instance.scaleMinimum;
			vesselSpeedLimit.Clear();
			if (instance.vesselSpeedLimit is not null) {
				foreach(var e in instance.vesselSpeedLimit)
					vesselSpeedLimit.Add(new vesselSpeedLimitViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			depthRangeMinimumValue = instance.depthRangeMinimumValue;
			techniqueOfVerticalMeasurement.Clear();
			if (instance.techniqueOfVerticalMeasurement is not null) {
				foreach(var e in instance.techniqueOfVerticalMeasurement)
					techniqueOfVerticalMeasurement.Add(e);
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			orientationValue = instance.orientationValue;
			restriction.Clear();
			if (instance.restriction is not null) {
				foreach(var e in instance.restriction)
					restriction.Add(e);
			}
			qualityOfVerticalMeasurement.Clear();
			if (instance.qualityOfVerticalMeasurement is not null) {
				foreach(var e in instance.qualityOfVerticalMeasurement)
					qualityOfVerticalMeasurement.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new DeepWaterRoutePart {
				imoAdopted = this.imoAdopted,
				verticalUncertainty = this.verticalUncertainty?.Model,
				information = this.information.Select(e => e.Model).ToList(),
				trafficFlow = this.trafficFlow,
				scaleMinimum = this.scaleMinimum,
				vesselSpeedLimit = this.vesselSpeedLimit.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				depthRangeMinimumValue = this.depthRangeMinimumValue,
				techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				status = this.status.ToList(),
				orientationValue = this.orientationValue,
				restriction = this.restriction.ToList(),
				qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DeepWaterRoutePart Model => new () {
			imoAdopted = this._imoAdopted,
			verticalUncertainty = this._verticalUncertainty?.Model,
			information = this.information.Select(e => e.Model).ToList(),
			trafficFlow = this._trafficFlow,
			scaleMinimum = this._scaleMinimum,
			vesselSpeedLimit = this.vesselSpeedLimit.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			depthRangeMinimumValue = this._depthRangeMinimumValue,
			techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			status = this.status.ToList(),
			orientationValue = this._orientationValue,
			restriction = this.restriction.ToList(),
			qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => DeepWaterRoutePart._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => DeepWaterRoutePart._featureBindingDefinitions;

		public override string? ToString() => $"Deep Water Route Part";

		public DeepWaterRoutePartViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			vesselSpeedLimit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(vesselSpeedLimit));
			};
			techniqueOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(techniqueOfVerticalMeasurement));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(restriction));
			};
			qualityOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(qualityOfVerticalMeasurement));
			};
		}
	}

	/// <summary>
	/// Any current that is caused by other than tide producing forces.
	/// </summary>
	[CategoryOrder("CurrentNonGravitational",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CurrentNonGravitationalViewModel : FeatureViewModel<CurrentNonGravitational> {
		[Category("CurrentNonGravitational")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("CurrentNonGravitational")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("CurrentNonGravitational")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private orientationViewModel _orientation ;

		[Category("CurrentNonGravitational")]
		[ExpandableObject]
		public orientationViewModel orientation {
			get {
				return _orientation;
			}
			set {
				SetValue(ref _orientation, value);
			}
		}
		[Category("CurrentNonGravitational")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("CurrentNonGravitational")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private speedViewModel _speed ;

		[Category("CurrentNonGravitational")]
		[ExpandableObject]
		public speedViewModel speed {
			get {
				return _speed;
			}
			set {
				SetValue(ref _speed, value);
			}
		}
		private status? _status  = default;

		[Category("CurrentNonGravitational")]
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
		public status[] statusList => [(status)5];


		public override FeatureViewModel<CurrentNonGravitational> Load(CurrentNonGravitational instance) {
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
			scaleMinimum = instance.scaleMinimum;
			orientation = new ();
			if (instance.orientation != default) {
				orientation.Load(instance.orientation);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			speed = new ();
			if (instance.speed != default) {
				speed.Load(instance.speed);
			}
			status = instance.status;
			return this;
		}

		public override string Serialize() {
			var instance = new CurrentNonGravitational {
				featureName = this.featureName.Select(e => e.Model).ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				orientation = this.orientation?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				speed = this.speed?.Model,
				status = this.status,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CurrentNonGravitational Model => new () {
			featureName = this.featureName.Select(e => e.Model).ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			orientation = this._orientation?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			speed = this._speed?.Model,
			status = this._status,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => CurrentNonGravitational._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => CurrentNonGravitational._featureBindingDefinitions;

		public override string? ToString() => $"Current - Non-Gravitational";

		public CurrentNonGravitationalViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
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
		private int? _drawingIndex  = default;

		[Category("DataCoverage")]
		public int? drawingIndex {
			get {
				return _drawingIndex;
			}
			set {
				SetValue(ref _drawingIndex, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		[Category("DataCoverage")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private categoryOfCoverage? _categoryOfCoverage  = default;

		[Category("DataCoverage")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfCoverageList), typeof(categoryOfCoverage))]
		public categoryOfCoverage? categoryOfCoverage {
			get {
				return _categoryOfCoverage;
			}
			set {
				SetValue(ref _categoryOfCoverage, value);
			}
		}

		[Browsable(false)]
		public categoryOfCoverage[] categoryOfCoverageList => [(categoryOfCoverage)1,(categoryOfCoverage)2];
		private int _optimumDisplayScale ;

		[Category("DataCoverage")]
		public int optimumDisplayScale {
			get {
				return _optimumDisplayScale;
			}
			set {
				SetValue(ref _optimumDisplayScale, value);
			}
		}
		private int _minimumDisplayScale ;

		[Category("DataCoverage")]
		public int minimumDisplayScale {
			get {
				return _minimumDisplayScale;
			}
			set {
				SetValue(ref _minimumDisplayScale, value);
			}
		}
		[Category("DataCoverage")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private int _maximumDisplayScale ;

		[Category("DataCoverage")]
		public int maximumDisplayScale {
			get {
				return _maximumDisplayScale;
			}
			set {
				SetValue(ref _maximumDisplayScale, value);
			}
		}


		public override FeatureViewModel<DataCoverage> Load(DataCoverage instance) {
			drawingIndex = instance.drawingIndex;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			categoryOfCoverage = instance.categoryOfCoverage;
			optimumDisplayScale = instance.optimumDisplayScale;
			minimumDisplayScale = instance.minimumDisplayScale;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			maximumDisplayScale = instance.maximumDisplayScale;
			return this;
		}

		public override string Serialize() {
			var instance = new DataCoverage {
				drawingIndex = this.drawingIndex,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				categoryOfCoverage = this.categoryOfCoverage,
				optimumDisplayScale = this.optimumDisplayScale,
				minimumDisplayScale = this.minimumDisplayScale,
				information = this.information.Select(e => e.Model).ToList(),
				maximumDisplayScale = this.maximumDisplayScale,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DataCoverage Model => new () {
			drawingIndex = this._drawingIndex,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			categoryOfCoverage = this._categoryOfCoverage,
			optimumDisplayScale = this._optimumDisplayScale,
			minimumDisplayScale = this._minimumDisplayScale,
			information = this.information.Select(e => e.Model).ToList(),
			maximumDisplayScale = this._maximumDisplayScale,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => DataCoverage._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => DataCoverage._featureBindingDefinitions;

		public override string? ToString() => $"Data Coverage";

		public DataCoverageViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// A region of the seabed including the material of which it is composed and its physical characteristics. Also called nature of bottom, character (or characteristics) of the bottom, or quality of the bottom.
	/// </summary>
	[CategoryOrder("SeabedArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SeabedAreaViewModel : FeatureViewModel<SeabedArea> {
		[Category("SeabedArea")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private String? _agencyResponsibleForProduction  = default;

		[Category("SeabedArea")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("SeabedArea")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private waterLevelEffect _waterLevelEffect ;

		[Category("SeabedArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(waterLevelEffectList), typeof(waterLevelEffect))]
		public waterLevelEffect waterLevelEffect {
			get {
				return _waterLevelEffect;
			}
			set {
				SetValue(ref _waterLevelEffect, value);
			}
		}

		[Browsable(false)]
		public waterLevelEffect[] waterLevelEffectList => [(waterLevelEffect)3,(waterLevelEffect)4,(waterLevelEffect)5];
		[Category("SeabedArea")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("SeabedArea")]
		public ObservableCollection<surfaceCharacteristicsViewModel> surfaceCharacteristics  { get; set; } = new ();
		private decimal? _attenuation  = default;

		[Category("SeabedArea")]
		public decimal? attenuation {
			get {
				return _attenuation;
			}
			set {
				SetValue(ref _attenuation, value);
			}
		}


		public override FeatureViewModel<SeabedArea> Load(SeabedArea instance) {
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			scaleMinimum = instance.scaleMinimum;
			waterLevelEffect = instance.waterLevelEffect;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			surfaceCharacteristics.Clear();
			if (instance.surfaceCharacteristics is not null) {
				foreach(var e in instance.surfaceCharacteristics)
					surfaceCharacteristics.Add(new surfaceCharacteristicsViewModel().Load(e));
			}
			attenuation = instance.attenuation;
			return this;
		}

		public override string Serialize() {
			var instance = new SeabedArea {
				information = this.information.Select(e => e.Model).ToList(),
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				scaleMinimum = this.scaleMinimum,
				waterLevelEffect = this.waterLevelEffect,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				surfaceCharacteristics = this.surfaceCharacteristics.Select(e => e.Model).ToList(),
				attenuation = this.attenuation,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SeabedArea Model => new () {
			information = this.information.Select(e => e.Model).ToList(),
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			scaleMinimum = this._scaleMinimum,
			waterLevelEffect = this._waterLevelEffect,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			surfaceCharacteristics = this.surfaceCharacteristics.Select(e => e.Model).ToList(),
			attenuation = this._attenuation,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => SeabedArea._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => SeabedArea._featureBindingDefinitions;

		public override string? ToString() => $"Seabed Area";

		public SeabedAreaViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			surfaceCharacteristics.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(surfaceCharacteristics));
			};
		}
	}

	/// <summary>
	/// A special purpose buoy is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notices to Mariners.
	/// </summary>
	[CategoryOrder("SpecialPurposeGeneralBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SpecialPurposeGeneralBuoyViewModel : FeatureViewModel<SpecialPurposeGeneralBuoy> {
		[Category("SpecialPurposeGeneralBuoy")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private buoyShape _buoyShape ;

		[Category("SpecialPurposeGeneralBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		private int? _scaleMinimum  = default;

		[Category("SpecialPurposeGeneralBuoy")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("SpecialPurposeGeneralBuoy")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("SpecialPurposeGeneralBuoy")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private colourPattern? _colourPattern  = default;

		[Category("SpecialPurposeGeneralBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public colourPattern? colourPattern {
			get {
				return _colourPattern;
			}
			set {
				SetValue(ref _colourPattern, value);
			}
		}

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6];
		[Category("SpecialPurposeGeneralBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfSpecialPurposeMarkList), typeof(categoryOfSpecialPurposeMark))]
		public ObservableCollection<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfSpecialPurposeMark[] categoryOfSpecialPurposeMarkList => [(categoryOfSpecialPurposeMark)1,(categoryOfSpecialPurposeMark)2,(categoryOfSpecialPurposeMark)3,(categoryOfSpecialPurposeMark)4,(categoryOfSpecialPurposeMark)5,(categoryOfSpecialPurposeMark)6,(categoryOfSpecialPurposeMark)7,(categoryOfSpecialPurposeMark)8,(categoryOfSpecialPurposeMark)9,(categoryOfSpecialPurposeMark)10,(categoryOfSpecialPurposeMark)11,(categoryOfSpecialPurposeMark)12,(categoryOfSpecialPurposeMark)14,(categoryOfSpecialPurposeMark)15,(categoryOfSpecialPurposeMark)17,(categoryOfSpecialPurposeMark)18,(categoryOfSpecialPurposeMark)19,(categoryOfSpecialPurposeMark)20,(categoryOfSpecialPurposeMark)21,(categoryOfSpecialPurposeMark)22,(categoryOfSpecialPurposeMark)23,(categoryOfSpecialPurposeMark)24,(categoryOfSpecialPurposeMark)25,(categoryOfSpecialPurposeMark)26,(categoryOfSpecialPurposeMark)27,(categoryOfSpecialPurposeMark)28,(categoryOfSpecialPurposeMark)29,(categoryOfSpecialPurposeMark)30,(categoryOfSpecialPurposeMark)31,(categoryOfSpecialPurposeMark)32,(categoryOfSpecialPurposeMark)33,(categoryOfSpecialPurposeMark)34,(categoryOfSpecialPurposeMark)35,(categoryOfSpecialPurposeMark)36,(categoryOfSpecialPurposeMark)37,(categoryOfSpecialPurposeMark)39,(categoryOfSpecialPurposeMark)40,(categoryOfSpecialPurposeMark)42,(categoryOfSpecialPurposeMark)43,(categoryOfSpecialPurposeMark)45,(categoryOfSpecialPurposeMark)46,(categoryOfSpecialPurposeMark)47,(categoryOfSpecialPurposeMark)48,(categoryOfSpecialPurposeMark)49,(categoryOfSpecialPurposeMark)50,(categoryOfSpecialPurposeMark)51,(categoryOfSpecialPurposeMark)52,(categoryOfSpecialPurposeMark)53,(categoryOfSpecialPurposeMark)54,(categoryOfSpecialPurposeMark)55,(categoryOfSpecialPurposeMark)56,(categoryOfSpecialPurposeMark)57,(categoryOfSpecialPurposeMark)58,(categoryOfSpecialPurposeMark)59,(categoryOfSpecialPurposeMark)60,(categoryOfSpecialPurposeMark)61,(categoryOfSpecialPurposeMark)62,(categoryOfSpecialPurposeMark)63];
		private String? _pictorialRepresentation  = default;

		[Category("SpecialPurposeGeneralBuoy")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		[Category("SpecialPurposeGeneralBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)5,(status)7,(status)8,(status)18,(status)503];
		private decimal? _verticalLength  = default;

		[Category("SpecialPurposeGeneralBuoy")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private Boolean? _radarConspicuous  = default;

		[Category("SpecialPurposeGeneralBuoy")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		private topmarkViewModel? _topmark  = default;

		[Category("SpecialPurposeGeneralBuoy")]
		[ExpandableObject]
		public topmarkViewModel? topmark {
			get {
				return _topmark;
			}
			set {
				SetValue(ref _topmark, value);
			}
		}
		[Category("SpecialPurposeGeneralBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("SpecialPurposeGeneralBuoy")]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)11];
		[Category("SpecialPurposeGeneralBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)11];
		[Category("SpecialPurposeGeneralBuoy")]
		public ObservableCollection<fixedDateRangeViewModel> fixedDateRange  { get; set; } = new ();
		private String? _interoperabilityIdentifier  = default;

		[Category("SpecialPurposeGeneralBuoy")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("SpecialPurposeGeneralBuoy")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();


		public override FeatureViewModel<SpecialPurposeGeneralBuoy> Load(SpecialPurposeGeneralBuoy instance) {
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			buoyShape = instance.buoyShape;
			scaleMinimum = instance.scaleMinimum;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			colourPattern = instance.colourPattern;
			categoryOfSpecialPurposeMark.Clear();
			if (instance.categoryOfSpecialPurposeMark is not null) {
				foreach(var e in instance.categoryOfSpecialPurposeMark)
					categoryOfSpecialPurposeMark.Add(e);
			}
			pictorialRepresentation = instance.pictorialRepresentation;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			verticalLength = instance.verticalLength;
			radarConspicuous = instance.radarConspicuous;
			topmark = new ();
			if (instance.topmark != default) {
				topmark.Load(instance.topmark);
			}
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			fixedDateRange.Clear();
			if (instance.fixedDateRange is not null) {
				foreach(var e in instance.fixedDateRange)
					fixedDateRange.Add(new fixedDateRangeViewModel().Load(e));
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new SpecialPurposeGeneralBuoy {
				information = this.information.Select(e => e.Model).ToList(),
				buoyShape = this.buoyShape,
				scaleMinimum = this.scaleMinimum,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				sourceIdentification = this.sourceIdentification?.Model,
				colourPattern = this.colourPattern,
				categoryOfSpecialPurposeMark = this.categoryOfSpecialPurposeMark.ToList(),
				pictorialRepresentation = this.pictorialRepresentation,
				status = this.status.ToList(),
				verticalLength = this.verticalLength,
				radarConspicuous = this.radarConspicuous,
				topmark = this.topmark?.Model,
				colour = this.colour.ToList(),
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				fixedDateRange = this.fixedDateRange.Select(e => e.Model).ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SpecialPurposeGeneralBuoy Model => new () {
			information = this.information.Select(e => e.Model).ToList(),
			buoyShape = this._buoyShape,
			scaleMinimum = this._scaleMinimum,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			sourceIdentification = this._sourceIdentification?.Model,
			colourPattern = this._colourPattern,
			categoryOfSpecialPurposeMark = this.categoryOfSpecialPurposeMark.ToList(),
			pictorialRepresentation = this._pictorialRepresentation,
			status = this.status.ToList(),
			verticalLength = this._verticalLength,
			radarConspicuous = this._radarConspicuous,
			topmark = this._topmark?.Model,
			colour = this.colour.ToList(),
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			fixedDateRange = this.fixedDateRange.Select(e => e.Model).ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => SpecialPurposeGeneralBuoy._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => SpecialPurposeGeneralBuoy._featureBindingDefinitions;

		public override string? ToString() => $"Special Purpose/General Buoy";

		public SpecialPurposeGeneralBuoyViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			categoryOfSpecialPurposeMark.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfSpecialPurposeMark));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			fixedDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(fixedDateRange));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
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
		[Category("LightSectored")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)6,(status)7,(status)8,(status)11,(status)14,(status)15,(status)16,(status)17];
		private decimal? _relativeHorizontalAccuracy  = default;

		[Category("LightSectored")]
		public decimal? relativeHorizontalAccuracy {
			get {
				return _relativeHorizontalAccuracy;
			}
			set {
				SetValue(ref _relativeHorizontalAccuracy, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("LightSectored")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("LightSectored")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		private decimal? _relativeVerticalAccuracy  = default;

		[Category("LightSectored")]
		public decimal? relativeVerticalAccuracy {
			get {
				return _relativeVerticalAccuracy;
			}
			set {
				SetValue(ref _relativeVerticalAccuracy, value);
			}
		}
		[Category("LightSectored")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfLightList), typeof(categoryOfLight))]
		public ObservableCollection<categoryOfLight> categoryOfLight  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfLight[] categoryOfLightList => [(categoryOfLight)4,(categoryOfLight)5,(categoryOfLight)8,(categoryOfLight)9,(categoryOfLight)10,(categoryOfLight)11,(categoryOfLight)12,(categoryOfLight)13,(categoryOfLight)14,(categoryOfLight)15,(categoryOfLight)17,(categoryOfLight)18,(categoryOfLight)19,(categoryOfLight)20];
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
		public exhibitionConditionOfLight[] exhibitionConditionOfLightList => [(exhibitionConditionOfLight)1,(exhibitionConditionOfLight)2,(exhibitionConditionOfLight)4];
		private DateOnly? _reportedDate  = default;

		[Category("LightSectored")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("LightSectored")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("LightSectored")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private String _pictorialRepresentation  = string.Empty;

		[Category("LightSectored")]
		public String pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private decimal? _height  = default;

		[Category("LightSectored")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private heightLengthUnits? _heightLengthUnits  = default;

		[Category("LightSectored")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(heightLengthUnitsList), typeof(heightLengthUnits))]
		public heightLengthUnits? heightLengthUnits {
			get {
				return _heightLengthUnits;
			}
			set {
				SetValue(ref _heightLengthUnits, value);
			}
		}

		[Browsable(false)]
		public heightLengthUnits[] heightLengthUnitsList => [(heightLengthUnits)1];
		private String? _interoperabilityIdentifier  = default;

		[Category("LightSectored")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("LightSectored")]
		public ObservableCollection<sectorCharacteristicsViewModel> sectorCharacteristics  { get; set; } = new ();
		private verticalDatum? _verticalDatum  = default;

		[Category("LightSectored")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)3,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)44];
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("LightSectored")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
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
		public signalGeneration[] signalGenerationList => [(signalGeneration)5,(signalGeneration)6];
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("LightSectored")]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)11];
		[Category("LightSectored")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();


		public override FeatureViewModel<LightSectored> Load(LightSectored instance) {
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			relativeHorizontalAccuracy = instance.relativeHorizontalAccuracy;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			relativeVerticalAccuracy = instance.relativeVerticalAccuracy;
			categoryOfLight.Clear();
			if (instance.categoryOfLight is not null) {
				foreach(var e in instance.categoryOfLight)
					categoryOfLight.Add(e);
			}
			exhibitionConditionOfLight = instance.exhibitionConditionOfLight;
			reportedDate = instance.reportedDate;
			scaleMinimum = instance.scaleMinimum;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			pictorialRepresentation = instance.pictorialRepresentation;
			height = instance.height;
			heightLengthUnits = instance.heightLengthUnits;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			sectorCharacteristics.Clear();
			if (instance.sectorCharacteristics is not null) {
				foreach(var e in instance.sectorCharacteristics)
					sectorCharacteristics.Add(new sectorCharacteristicsViewModel().Load(e));
			}
			verticalDatum = instance.verticalDatum;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			signalGeneration = instance.signalGeneration;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new LightSectored {
				status = this.status.ToList(),
				relativeHorizontalAccuracy = this.relativeHorizontalAccuracy,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				relativeVerticalAccuracy = this.relativeVerticalAccuracy,
				categoryOfLight = this.categoryOfLight.ToList(),
				exhibitionConditionOfLight = this.exhibitionConditionOfLight,
				reportedDate = this.reportedDate,
				scaleMinimum = this.scaleMinimum,
				information = this.information.Select(e => e.Model).ToList(),
				pictorialRepresentation = this.pictorialRepresentation,
				height = this.height,
				heightLengthUnits = this.heightLengthUnits,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				sectorCharacteristics = this.sectorCharacteristics.Select(e => e.Model).ToList(),
				verticalDatum = this.verticalDatum,
				sourceIdentification = this.sourceIdentification?.Model,
				signalGeneration = this.signalGeneration,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				featureName = this.featureName.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LightSectored Model => new () {
			status = this.status.ToList(),
			relativeHorizontalAccuracy = this._relativeHorizontalAccuracy,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			relativeVerticalAccuracy = this._relativeVerticalAccuracy,
			categoryOfLight = this.categoryOfLight.ToList(),
			exhibitionConditionOfLight = this._exhibitionConditionOfLight,
			reportedDate = this._reportedDate,
			scaleMinimum = this._scaleMinimum,
			information = this.information.Select(e => e.Model).ToList(),
			pictorialRepresentation = this._pictorialRepresentation,
			height = this._height,
			heightLengthUnits = this._heightLengthUnits,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			sectorCharacteristics = this.sectorCharacteristics.Select(e => e.Model).ToList(),
			verticalDatum = this._verticalDatum,
			sourceIdentification = this._sourceIdentification?.Model,
			signalGeneration = this._signalGeneration,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			featureName = this.featureName.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => LightSectored._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => LightSectored._featureBindingDefinitions;

		public override string? ToString() => $"Light Sectored";

		public LightSectoredViewModel() : base() {
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			categoryOfLight.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfLight));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			sectorCharacteristics.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sectorCharacteristics));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// The Ice Line provides a measured, observed or estimated limit of the ice infested waters. (ECDIS Ice Objects Version 3.0)			
	/// </summary>
	[CategoryOrder("IceLine",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class IceLineViewModel : FeatureViewModel<IceLine> {
		[Category("IceLine")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("IceLine")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();


		public override FeatureViewModel<IceLine> Load(IceLine instance) {
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
			return this;
		}

		public override string Serialize() {
			var instance = new IceLine {
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public IceLine Model => new () {
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => IceLine._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => IceLine._featureBindingDefinitions;

		public override string? ToString() => $"Ice Line";

		public IceLineViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
		[Category("AnchorageArea")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(restrictionList), typeof(restriction))]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)15,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)23,(restriction)24,(restriction)27,(restriction)39];
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AnchorageArea")]
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

		[Category("AnchorageArea")]
		[ExpandableObject]
		public periodicDateRangeViewModel? periodicDateRange {
			get {
				return _periodicDateRange;
			}
			set {
				SetValue(ref _periodicDateRange, value);
			}
		}
		[Category("AnchorageArea")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("AnchorageArea")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfAnchorageList), typeof(categoryOfAnchorage))]
		public ObservableCollection<categoryOfAnchorage> categoryOfAnchorage  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfAnchorage[] categoryOfAnchorageList => [(categoryOfAnchorage)1,(categoryOfAnchorage)2,(categoryOfAnchorage)3,(categoryOfAnchorage)5,(categoryOfAnchorage)6,(categoryOfAnchorage)7,(categoryOfAnchorage)9,(categoryOfAnchorage)10,(categoryOfAnchorage)14,(categoryOfAnchorage)15];
		private int? _scaleMinimum  = default;

		[Category("AnchorageArea")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("AnchorageArea")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)5,(status)6,(status)7,(status)8,(status)9,(status)14];
		[Category("AnchorageArea")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("AnchorageArea")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfCargoList), typeof(categoryOfCargo))]
		public ObservableCollection<categoryOfCargo> categoryOfCargo  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfCargo[] categoryOfCargoList => [(categoryOfCargo)1,(categoryOfCargo)2,(categoryOfCargo)3,(categoryOfCargo)4,(categoryOfCargo)5,(categoryOfCargo)6,(categoryOfCargo)7,(categoryOfCargo)8,(categoryOfCargo)9,(categoryOfCargo)10,(categoryOfCargo)11,(categoryOfCargo)12,(categoryOfCargo)13,(categoryOfCargo)14,(categoryOfCargo)15];


		public override FeatureViewModel<AnchorageArea> Load(AnchorageArea instance) {
			restriction.Clear();
			if (instance.restriction is not null) {
				foreach(var e in instance.restriction)
					restriction.Add(e);
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			categoryOfAnchorage.Clear();
			if (instance.categoryOfAnchorage is not null) {
				foreach(var e in instance.categoryOfAnchorage)
					categoryOfAnchorage.Add(e);
			}
			scaleMinimum = instance.scaleMinimum;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			categoryOfCargo.Clear();
			if (instance.categoryOfCargo is not null) {
				foreach(var e in instance.categoryOfCargo)
					categoryOfCargo.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new AnchorageArea {
				restriction = this.restriction.ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				categoryOfAnchorage = this.categoryOfAnchorage.ToList(),
				scaleMinimum = this.scaleMinimum,
				status = this.status.ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				categoryOfCargo = this.categoryOfCargo.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public AnchorageArea Model => new () {
			restriction = this.restriction.ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			categoryOfAnchorage = this.categoryOfAnchorage.ToList(),
			scaleMinimum = this._scaleMinimum,
			status = this.status.ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			categoryOfCargo = this.categoryOfCargo.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => AnchorageArea._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => AnchorageArea._featureBindingDefinitions;

		public override string? ToString() => $"Anchorage Area";

		public AnchorageAreaViewModel() : base() {
			restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(restriction));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			categoryOfAnchorage.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfAnchorage));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			categoryOfCargo.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfCargo));
			};
		}
	}

	/// <summary>
	/// A lateral buoy is used to indicate the port or starboard hand side of the route to be followed. They are generally used for well-defined channels and are used in conjunction with a conventional direction of buoyage.
	/// </summary>
	[CategoryOrder("LateralBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LateralBuoyViewModel : FeatureViewModel<LateralBuoy> {
		private Boolean? _radarConspicuous  = default;

		[Category("LateralBuoy")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("LateralBuoy")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("LateralBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		private String? _interoperabilityIdentifier  = default;

		[Category("LateralBuoy")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("LateralBuoy")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		[Category("LateralBuoy")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("LateralBuoy")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("LateralBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)5,(status)7,(status)8,(status)18];
		private categoryOfLateralMark _categoryOfLateralMark ;

		[Category("LateralBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		public categoryOfLateralMark[] categoryOfLateralMarkList => [(categoryOfLateralMark)1,(categoryOfLateralMark)2,(categoryOfLateralMark)3,(categoryOfLateralMark)4];
		[Category("LateralBuoy")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		private colourPattern? _colourPattern  = default;

		[Category("LateralBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public colourPattern? colourPattern {
			get {
				return _colourPattern;
			}
			set {
				SetValue(ref _colourPattern, value);
			}
		}

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6];
		private buoyShape _buoyShape ;

		[Category("LateralBuoy")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		private topmarkViewModel? _topmark  = default;

		[Category("LateralBuoy")]
		[ExpandableObject]
		public topmarkViewModel? topmark {
			get {
				return _topmark;
			}
			set {
				SetValue(ref _topmark, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("LateralBuoy")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("LateralBuoy")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)11];
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("LateralBuoy")]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)11];
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("LateralBuoy")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private decimal? _verticalLength  = default;

		[Category("LateralBuoy")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}


		public override FeatureViewModel<LateralBuoy> Load(LateralBuoy instance) {
			radarConspicuous = instance.radarConspicuous;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			pictorialRepresentation = instance.pictorialRepresentation;
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
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			categoryOfLateralMark = instance.categoryOfLateralMark;
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			colourPattern = instance.colourPattern;
			buoyShape = instance.buoyShape;
			topmark = new ();
			if (instance.topmark != default) {
				topmark.Load(instance.topmark);
			}
			scaleMinimum = instance.scaleMinimum;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			verticalLength = instance.verticalLength;
			return this;
		}

		public override string Serialize() {
			var instance = new LateralBuoy {
				radarConspicuous = this.radarConspicuous,
				fixedDateRange = this.fixedDateRange?.Model,
				colour = this.colour.ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				pictorialRepresentation = this.pictorialRepresentation,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				status = this.status.ToList(),
				categoryOfLateralMark = this.categoryOfLateralMark,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				colourPattern = this.colourPattern,
				buoyShape = this.buoyShape,
				topmark = this.topmark?.Model,
				scaleMinimum = this.scaleMinimum,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				sourceIdentification = this.sourceIdentification?.Model,
				verticalLength = this.verticalLength,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LateralBuoy Model => new () {
			radarConspicuous = this._radarConspicuous,
			fixedDateRange = this._fixedDateRange?.Model,
			colour = this.colour.ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			pictorialRepresentation = this._pictorialRepresentation,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			status = this.status.ToList(),
			categoryOfLateralMark = this._categoryOfLateralMark,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			colourPattern = this._colourPattern,
			buoyShape = this._buoyShape,
			topmark = this._topmark?.Model,
			scaleMinimum = this._scaleMinimum,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			sourceIdentification = this._sourceIdentification?.Model,
			verticalLength = this._verticalLength,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => LateralBuoy._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => LateralBuoy._featureBindingDefinitions;

		public override string? ToString() => $"Lateral Buoy";

		public LateralBuoyViewModel() : base() {
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
		}
	}

	/// <summary>
	/// A routeing measure comprising a separation point or circular separation zone and a circular traffic lane within defined limits. Traffic within the roundabout is separated by moving in a counter-clockwise direction around the separation point or zone.
	/// </summary>
	[CategoryOrder("TrafficSeparationSchemeRoundabout",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TrafficSeparationSchemeRoundaboutViewModel : FeatureViewModel<TrafficSeparationSchemeRoundabout> {
		[Category("TrafficSeparationSchemeRoundabout")]
		public ObservableCollection<vesselSpeedLimitViewModel> vesselSpeedLimit  { get; set; } = new ();
		private String? _interoperabilityIdentifier  = default;

		[Category("TrafficSeparationSchemeRoundabout")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("TrafficSeparationSchemeRoundabout")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("TrafficSeparationSchemeRoundabout")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("TrafficSeparationSchemeRoundabout")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("TrafficSeparationSchemeRoundabout")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		[Category("TrafficSeparationSchemeRoundabout")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)3,(status)6,(status)9];
		private DateOnly? _reportedDate  = default;

		[Category("TrafficSeparationSchemeRoundabout")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		[Category("TrafficSeparationSchemeRoundabout")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(restrictionList), typeof(restriction))]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)27];


		public override FeatureViewModel<TrafficSeparationSchemeRoundabout> Load(TrafficSeparationSchemeRoundabout instance) {
			vesselSpeedLimit.Clear();
			if (instance.vesselSpeedLimit is not null) {
				foreach(var e in instance.vesselSpeedLimit)
					vesselSpeedLimit.Add(new vesselSpeedLimitViewModel().Load(e));
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			scaleMinimum = instance.scaleMinimum;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			reportedDate = instance.reportedDate;
			restriction.Clear();
			if (instance.restriction is not null) {
				foreach(var e in instance.restriction)
					restriction.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new TrafficSeparationSchemeRoundabout {
				vesselSpeedLimit = this.vesselSpeedLimit.Select(e => e.Model).ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				sourceIdentification = this.sourceIdentification?.Model,
				scaleMinimum = this.scaleMinimum,
				information = this.information.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				status = this.status.ToList(),
				reportedDate = this.reportedDate,
				restriction = this.restriction.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public TrafficSeparationSchemeRoundabout Model => new () {
			vesselSpeedLimit = this.vesselSpeedLimit.Select(e => e.Model).ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			sourceIdentification = this._sourceIdentification?.Model,
			scaleMinimum = this._scaleMinimum,
			information = this.information.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			status = this.status.ToList(),
			reportedDate = this._reportedDate,
			restriction = this.restriction.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeRoundabout._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeRoundabout._featureBindingDefinitions;

		public override string? ToString() => $"Traffic Separation Scheme Roundabout";

		public TrafficSeparationSchemeRoundaboutViewModel() : base() {
			vesselSpeedLimit.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(vesselSpeedLimit));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			restriction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(restriction));
			};
		}
	}

	/// <summary>
	/// The Deep Water route centreline indicates the centreline of a route, the width of which is not explicitly defined.
	/// </summary>
	[CategoryOrder("DeepWaterRouteCentreline",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DeepWaterRouteCentrelineViewModel : FeatureViewModel<DeepWaterRouteCentreline> {
		[Category("DeepWaterRouteCentreline")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(qualityOfVerticalMeasurementList), typeof(qualityOfVerticalMeasurement))]
		public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1,(qualityOfVerticalMeasurement)2,(qualityOfVerticalMeasurement)3,(qualityOfVerticalMeasurement)4,(qualityOfVerticalMeasurement)6,(qualityOfVerticalMeasurement)7];
		private decimal _orientationValue ;

		[Category("DeepWaterRouteCentreline")]
		public decimal orientationValue {
			get {
				return _orientationValue;
			}
			set {
				SetValue(ref _orientationValue, value);
			}
		}
		[Category("DeepWaterRouteCentreline")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private trafficFlow _trafficFlow ;

		[Category("DeepWaterRouteCentreline")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Category("DeepWaterRouteCentreline")]
		[ExpandableObject]
		public verticalUncertaintyViewModel? verticalUncertainty {
			get {
				return _verticalUncertainty;
			}
			set {
				SetValue(ref _verticalUncertainty, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("DeepWaterRouteCentreline")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("DeepWaterRouteCentreline")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)3,(status)6,(status)9];
		private Boolean? _imoAdopted  = default;

		[Category("DeepWaterRouteCentreline")]
		public Boolean? imoAdopted {
			get {
				return _imoAdopted;
			}
			set {
				SetValue(ref _imoAdopted, value);
			}
		}
		[Category("DeepWaterRouteCentreline")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("DeepWaterRouteCentreline")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		[Category("DeepWaterRouteCentreline")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private decimal? _depthRangeMinimumValue  = default;

		[Category("DeepWaterRouteCentreline")]
		public decimal? depthRangeMinimumValue {
			get {
				return _depthRangeMinimumValue;
			}
			set {
				SetValue(ref _depthRangeMinimumValue, value);
			}
		}
		private Boolean _basedOnFixedMarks  = false;

		[Category("DeepWaterRouteCentreline")]
		public Boolean basedOnFixedMarks {
			get {
				return _basedOnFixedMarks;
			}
			set {
				SetValue(ref _basedOnFixedMarks, value);
			}
		}
		[Category("DeepWaterRouteCentreline")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(techniqueOfVerticalMeasurementList), typeof(techniqueOfVerticalMeasurement))]
		public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1,(techniqueOfVerticalMeasurement)3,(techniqueOfVerticalMeasurement)5,(techniqueOfVerticalMeasurement)8,(techniqueOfVerticalMeasurement)9,(techniqueOfVerticalMeasurement)13,(techniqueOfVerticalMeasurement)15,(techniqueOfVerticalMeasurement)16,(techniqueOfVerticalMeasurement)17,(techniqueOfVerticalMeasurement)18];


		public override FeatureViewModel<DeepWaterRouteCentreline> Load(DeepWaterRouteCentreline instance) {
			qualityOfVerticalMeasurement.Clear();
			if (instance.qualityOfVerticalMeasurement is not null) {
				foreach(var e in instance.qualityOfVerticalMeasurement)
					qualityOfVerticalMeasurement.Add(e);
			}
			orientationValue = instance.orientationValue;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			trafficFlow = instance.trafficFlow;
			verticalUncertainty = new ();
			if (instance.verticalUncertainty != default) {
				verticalUncertainty.Load(instance.verticalUncertainty);
			}
			scaleMinimum = instance.scaleMinimum;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			imoAdopted = instance.imoAdopted;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			depthRangeMinimumValue = instance.depthRangeMinimumValue;
			basedOnFixedMarks = instance.basedOnFixedMarks;
			techniqueOfVerticalMeasurement.Clear();
			if (instance.techniqueOfVerticalMeasurement is not null) {
				foreach(var e in instance.techniqueOfVerticalMeasurement)
					techniqueOfVerticalMeasurement.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new DeepWaterRouteCentreline {
				qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
				orientationValue = this.orientationValue,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				trafficFlow = this.trafficFlow,
				verticalUncertainty = this.verticalUncertainty?.Model,
				scaleMinimum = this.scaleMinimum,
				status = this.status.ToList(),
				imoAdopted = this.imoAdopted,
				information = this.information.Select(e => e.Model).ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				depthRangeMinimumValue = this.depthRangeMinimumValue,
				basedOnFixedMarks = this.basedOnFixedMarks,
				techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DeepWaterRouteCentreline Model => new () {
			qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
			orientationValue = this._orientationValue,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			trafficFlow = this._trafficFlow,
			verticalUncertainty = this._verticalUncertainty?.Model,
			scaleMinimum = this._scaleMinimum,
			status = this.status.ToList(),
			imoAdopted = this._imoAdopted,
			information = this.information.Select(e => e.Model).ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			depthRangeMinimumValue = this._depthRangeMinimumValue,
			basedOnFixedMarks = this._basedOnFixedMarks,
			techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => DeepWaterRouteCentreline._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => DeepWaterRouteCentreline._featureBindingDefinitions;

		public override string? ToString() => $"Deep Water Route Centreline";

		public DeepWaterRouteCentrelineViewModel() : base() {
			qualityOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(qualityOfVerticalMeasurement));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			techniqueOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(techniqueOfVerticalMeasurement));
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
		[Category("LightFloat")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)14,(status)16,(status)17];
		private colourPattern? _colourPattern  = default;

		[Category("LightFloat")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public colourPattern? colourPattern {
			get {
				return _colourPattern;
			}
			set {
				SetValue(ref _colourPattern, value);
			}
		}

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6];
		[Category("LightFloat")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("LightFloat")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)11];
		[Category("LightFloat")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
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
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("LightFloat")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
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
		private String? _interoperabilityIdentifier  = default;

		[Category("LightFloat")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("LightFloat")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private topmarkViewModel? _topmark  = default;

		[Category("LightFloat")]
		[ExpandableObject]
		public topmarkViewModel? topmark {
			get {
				return _topmark;
			}
			set {
				SetValue(ref _topmark, value);
			}
		}
		[Category("LightFloat")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private int? _scaleMinimum  = default;

		[Category("LightFloat")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("LightFloat")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();


		public override FeatureViewModel<LightFloat> Load(LightFloat instance) {
			verticalLength = instance.verticalLength;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			colourPattern = instance.colourPattern;
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			horizontalWidth = instance.horizontalWidth;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			horizontalLength = instance.horizontalLength;
			visualProminence = instance.visualProminence;
			radarConspicuous = instance.radarConspicuous;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			pictorialRepresentation = instance.pictorialRepresentation;
			topmark = new ();
			if (instance.topmark != default) {
				topmark.Load(instance.topmark);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			scaleMinimum = instance.scaleMinimum;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new LightFloat {
				verticalLength = this.verticalLength,
				status = this.status.ToList(),
				colourPattern = this.colourPattern,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				natureOfConstruction = this.natureOfConstruction.ToList(),
				colour = this.colour.ToList(),
				horizontalWidth = this.horizontalWidth,
				fixedDateRange = this.fixedDateRange?.Model,
				horizontalLength = this.horizontalLength,
				visualProminence = this.visualProminence,
				radarConspicuous = this.radarConspicuous,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				pictorialRepresentation = this.pictorialRepresentation,
				topmark = this.topmark?.Model,
				information = this.information.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				featureName = this.featureName.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LightFloat Model => new () {
			verticalLength = this._verticalLength,
			status = this.status.ToList(),
			colourPattern = this._colourPattern,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			natureOfConstruction = this.natureOfConstruction.ToList(),
			colour = this.colour.ToList(),
			horizontalWidth = this._horizontalWidth,
			fixedDateRange = this._fixedDateRange?.Model,
			horizontalLength = this._horizontalLength,
			visualProminence = this._visualProminence,
			radarConspicuous = this._radarConspicuous,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			pictorialRepresentation = this._pictorialRepresentation,
			topmark = this._topmark?.Model,
			information = this.information.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			featureName = this.featureName.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => LightFloat._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => LightFloat._featureBindingDefinitions;

		public override string? ToString() => $"Light Float";

		public LightFloatViewModel() : base() {
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
		private decimal? _verticalLength  = default;

		[Category("LightAllAround")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)11];
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
		public signalGeneration[] signalGenerationList => [(signalGeneration)5,(signalGeneration)6];
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
		private String? _interoperabilityIdentifier  = default;

		[Category("LightAllAround")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("LightAllAround")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)6,(status)7,(status)8,(status)11,(status)14,(status)15,(status)16,(status)17];
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("LightAllAround")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("LightAllAround")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private multiplicityOfFeaturesViewModel _multiplicityOfFeatures ;

		[Category("LightAllAround")]
		[ExpandableObject]
		public multiplicityOfFeaturesViewModel multiplicityOfFeatures {
			get {
				return _multiplicityOfFeatures;
			}
			set {
				SetValue(ref _multiplicityOfFeatures, value);
			}
		}
		private exhibitionConditionOfLight? _exhibitionConditionOfLight  = default;

		[Category("LightAllAround")]
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
		private decimal? _height  = default;

		[Category("LightAllAround")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private decimal? _relativeHorizontalAccuracy  = default;

		[Category("LightAllAround")]
		public decimal? relativeHorizontalAccuracy {
			get {
				return _relativeHorizontalAccuracy;
			}
			set {
				SetValue(ref _relativeHorizontalAccuracy, value);
			}
		}
		private verticalDatum? _verticalDatum  = default;

		[Category("LightAllAround")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)3,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)44];
		[Category("LightAllAround")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
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
		public lightVisibility[] lightVisibilityList => [(lightVisibility)1,(lightVisibility)2];
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
		private heightLengthUnits? _heightLengthUnits  = default;

		[Category("LightAllAround")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(heightLengthUnitsList), typeof(heightLengthUnits))]
		public heightLengthUnits? heightLengthUnits {
			get {
				return _heightLengthUnits;
			}
			set {
				SetValue(ref _heightLengthUnits, value);
			}
		}

		[Browsable(false)]
		public heightLengthUnits[] heightLengthUnitsList => [(heightLengthUnits)1];
		[Category("LightAllAround")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfLightList), typeof(categoryOfLight))]
		public ObservableCollection<categoryOfLight> categoryOfLight  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfLight[] categoryOfLightList => [(categoryOfLight)4,(categoryOfLight)5,(categoryOfLight)8,(categoryOfLight)9,(categoryOfLight)10,(categoryOfLight)11,(categoryOfLight)12,(categoryOfLight)13,(categoryOfLight)14,(categoryOfLight)15,(categoryOfLight)17,(categoryOfLight)18,(categoryOfLight)19,(categoryOfLight)20];
		private rythmOfLightViewModel _rythmOfLight ;

		[Category("LightAllAround")]
		[ExpandableObject]
		public rythmOfLightViewModel rythmOfLight {
			get {
				return _rythmOfLight;
			}
			set {
				SetValue(ref _rythmOfLight, value);
			}
		}
		[Category("LightAllAround")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)3,(colour)4,(colour)5,(colour)6,(colour)9,(colour)10,(colour)11];
		[Category("LightAllAround")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("LightAllAround")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();


		public override FeatureViewModel<LightAllAround> Load(LightAllAround instance) {
			verticalLength = instance.verticalLength;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			signalGeneration = instance.signalGeneration;
			valueOfNominalRange = instance.valueOfNominalRange;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			scaleMinimum = instance.scaleMinimum;
			multiplicityOfFeatures = new ();
			if (instance.multiplicityOfFeatures != default) {
				multiplicityOfFeatures.Load(instance.multiplicityOfFeatures);
			}
			exhibitionConditionOfLight = instance.exhibitionConditionOfLight;
			height = instance.height;
			relativeHorizontalAccuracy = instance.relativeHorizontalAccuracy;
			verticalDatum = instance.verticalDatum;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			majorLight = instance.majorLight;
			lightVisibility = instance.lightVisibility;
			flareBearing = instance.flareBearing;
			heightLengthUnits = instance.heightLengthUnits;
			categoryOfLight.Clear();
			if (instance.categoryOfLight is not null) {
				foreach(var e in instance.categoryOfLight)
					categoryOfLight.Add(e);
			}
			rythmOfLight = new ();
			if (instance.rythmOfLight != default) {
				rythmOfLight.Load(instance.rythmOfLight);
			}
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
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
			return this;
		}

		public override string Serialize() {
			var instance = new LightAllAround {
				verticalLength = this.verticalLength,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				signalGeneration = this.signalGeneration,
				valueOfNominalRange = this.valueOfNominalRange,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				status = this.status.ToList(),
				fixedDateRange = this.fixedDateRange?.Model,
				scaleMinimum = this.scaleMinimum,
				multiplicityOfFeatures = this.multiplicityOfFeatures?.Model,
				exhibitionConditionOfLight = this.exhibitionConditionOfLight,
				height = this.height,
				relativeHorizontalAccuracy = this.relativeHorizontalAccuracy,
				verticalDatum = this.verticalDatum,
				information = this.information.Select(e => e.Model).ToList(),
				majorLight = this.majorLight,
				lightVisibility = this.lightVisibility,
				flareBearing = this.flareBearing,
				heightLengthUnits = this.heightLengthUnits,
				categoryOfLight = this.categoryOfLight.ToList(),
				rythmOfLight = this.rythmOfLight?.Model,
				colour = this.colour.ToList(),
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LightAllAround Model => new () {
			verticalLength = this._verticalLength,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			signalGeneration = this._signalGeneration,
			valueOfNominalRange = this._valueOfNominalRange,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			status = this.status.ToList(),
			fixedDateRange = this._fixedDateRange?.Model,
			scaleMinimum = this._scaleMinimum,
			multiplicityOfFeatures = this._multiplicityOfFeatures?.Model,
			exhibitionConditionOfLight = this._exhibitionConditionOfLight,
			height = this._height,
			relativeHorizontalAccuracy = this._relativeHorizontalAccuracy,
			verticalDatum = this._verticalDatum,
			information = this.information.Select(e => e.Model).ToList(),
			majorLight = this._majorLight,
			lightVisibility = this._lightVisibility,
			flareBearing = this._flareBearing,
			heightLengthUnits = this._heightLengthUnits,
			categoryOfLight = this.categoryOfLight.ToList(),
			rythmOfLight = this._rythmOfLight?.Model,
			colour = this.colour.ToList(),
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => LightAllAround._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => LightAllAround._featureBindingDefinitions;

		public override string? ToString() => $"Light All Around";

		public LightAllAroundViewModel() : base() {
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			categoryOfLight.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfLight));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// The line where shore and water meet. Shoreline and coastline are generally used synonymously.
	/// </summary>
	[CategoryOrder("Coastline",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class CoastlineViewModel : FeatureViewModel<Coastline> {
		[Category("Coastline")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)6,(colour)7,(colour)8,(colour)11,(colour)13];
		[Category("Coastline")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private categoryOfCoastline? _categoryOfCoastline  = default;

		[Category("Coastline")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfCoastlineList), typeof(categoryOfCoastline))]
		public categoryOfCoastline? categoryOfCoastline {
			get {
				return _categoryOfCoastline;
			}
			set {
				SetValue(ref _categoryOfCoastline, value);
			}
		}

		[Browsable(false)]
		public categoryOfCoastline[] categoryOfCoastlineList => [(categoryOfCoastline)1,(categoryOfCoastline)2,(categoryOfCoastline)6,(categoryOfCoastline)7,(categoryOfCoastline)8,(categoryOfCoastline)10];
		private decimal? _elevation  = default;

		[Category("Coastline")]
		public decimal? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("Coastline")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private String? _interoperabilityIdentifier  = default;

		[Category("Coastline")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		[Category("Coastline")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfSurfaceList), typeof(natureOfSurface))]
		public ObservableCollection<natureOfSurface> natureOfSurface  { get; set; } = new ();

		[Browsable(false)]
		public natureOfSurface[] natureOfSurfaceList => [(natureOfSurface)1,(natureOfSurface)2,(natureOfSurface)3,(natureOfSurface)4,(natureOfSurface)5,(natureOfSurface)6,(natureOfSurface)7,(natureOfSurface)8,(natureOfSurface)9,(natureOfSurface)11,(natureOfSurface)14,(natureOfSurface)17];
		[Category("Coastline")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private visualProminence? _visualProminence  = default;

		[Category("Coastline")]
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
		private String? _pictorialRepresentation  = default;

		[Category("Coastline")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("Coastline")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private Boolean? _radarConspicuous  = default;

		[Category("Coastline")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}


		public override FeatureViewModel<Coastline> Load(Coastline instance) {
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			categoryOfCoastline = instance.categoryOfCoastline;
			elevation = instance.elevation;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			natureOfSurface.Clear();
			if (instance.natureOfSurface is not null) {
				foreach(var e in instance.natureOfSurface)
					natureOfSurface.Add(e);
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			visualProminence = instance.visualProminence;
			pictorialRepresentation = instance.pictorialRepresentation;
			reportedDate = instance.reportedDate;
			radarConspicuous = instance.radarConspicuous;
			return this;
		}

		public override string Serialize() {
			var instance = new Coastline {
				colour = this.colour.ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				categoryOfCoastline = this.categoryOfCoastline,
				elevation = this.elevation,
				sourceIdentification = this.sourceIdentification?.Model,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				natureOfSurface = this.natureOfSurface.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				visualProminence = this.visualProminence,
				pictorialRepresentation = this.pictorialRepresentation,
				reportedDate = this.reportedDate,
				radarConspicuous = this.radarConspicuous,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Coastline Model => new () {
			colour = this.colour.ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			categoryOfCoastline = this._categoryOfCoastline,
			elevation = this._elevation,
			sourceIdentification = this._sourceIdentification?.Model,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			natureOfSurface = this.natureOfSurface.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			visualProminence = this._visualProminence,
			pictorialRepresentation = this._pictorialRepresentation,
			reportedDate = this._reportedDate,
			radarConspicuous = this._radarConspicuous,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => Coastline._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => Coastline._featureBindingDefinitions;

		public override string? ToString() => $"Coastline";

		public CoastlineViewModel() : base() {
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			natureOfSurface.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfSurface));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// A geographically defined part of the sea or other navigable waters. It may be specified within its limits by its proper name.
	/// </summary>
	[CategoryOrder("SeaAreaNamedWaterArea",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SeaAreaNamedWaterAreaViewModel : FeatureViewModel<SeaAreaNamedWaterArea> {
		private categoryOfSeaArea? _categoryOfSeaArea  = default;

		[Category("SeaAreaNamedWaterArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfSeaAreaList), typeof(categoryOfSeaArea))]
		public categoryOfSeaArea? categoryOfSeaArea {
			get {
				return _categoryOfSeaArea;
			}
			set {
				SetValue(ref _categoryOfSeaArea, value);
			}
		}

		[Browsable(false)]
		public categoryOfSeaArea[] categoryOfSeaAreaList => [(categoryOfSeaArea)2,(categoryOfSeaArea)3,(categoryOfSeaArea)4,(categoryOfSeaArea)5,(categoryOfSeaArea)6,(categoryOfSeaArea)7,(categoryOfSeaArea)8,(categoryOfSeaArea)9,(categoryOfSeaArea)10,(categoryOfSeaArea)11,(categoryOfSeaArea)12,(categoryOfSeaArea)13,(categoryOfSeaArea)14,(categoryOfSeaArea)15,(categoryOfSeaArea)16,(categoryOfSeaArea)17,(categoryOfSeaArea)18,(categoryOfSeaArea)19,(categoryOfSeaArea)20,(categoryOfSeaArea)21,(categoryOfSeaArea)22,(categoryOfSeaArea)23,(categoryOfSeaArea)24,(categoryOfSeaArea)25,(categoryOfSeaArea)26,(categoryOfSeaArea)27,(categoryOfSeaArea)28,(categoryOfSeaArea)29,(categoryOfSeaArea)30,(categoryOfSeaArea)31,(categoryOfSeaArea)32,(categoryOfSeaArea)33,(categoryOfSeaArea)34,(categoryOfSeaArea)35,(categoryOfSeaArea)36,(categoryOfSeaArea)37,(categoryOfSeaArea)38,(categoryOfSeaArea)39,(categoryOfSeaArea)40,(categoryOfSeaArea)41,(categoryOfSeaArea)42,(categoryOfSeaArea)43,(categoryOfSeaArea)44,(categoryOfSeaArea)45,(categoryOfSeaArea)46,(categoryOfSeaArea)47,(categoryOfSeaArea)48,(categoryOfSeaArea)49,(categoryOfSeaArea)50,(categoryOfSeaArea)51,(categoryOfSeaArea)52,(categoryOfSeaArea)53,(categoryOfSeaArea)54,(categoryOfSeaArea)55,(categoryOfSeaArea)56];
		[Category("SeaAreaNamedWaterArea")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private DateOnly? _reportedDate  = default;

		[Category("SeaAreaNamedWaterArea")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		[Category("SeaAreaNamedWaterArea")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private gradient? _gradient  = default;

		[Category("SeaAreaNamedWaterArea")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(gradientList), typeof(gradient))]
		public gradient? gradient {
			get {
				return _gradient;
			}
			set {
				SetValue(ref _gradient, value);
			}
		}

		[Browsable(false)]
		public gradient[] gradientList => [(gradient)501,(gradient)502,(gradient)503,(gradient)504,(gradient)505];
		private int? _scaleMinimum  = default;

		[Category("SeaAreaNamedWaterArea")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private qualityOfHorizontalMeasurement? _qualityOfHorizontalMeasurement  = default;

		[Category("SeaAreaNamedWaterArea")]
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
		public qualityOfHorizontalMeasurement[] qualityOfHorizontalMeasurementList => [(qualityOfHorizontalMeasurement)4];


		public override FeatureViewModel<SeaAreaNamedWaterArea> Load(SeaAreaNamedWaterArea instance) {
			categoryOfSeaArea = instance.categoryOfSeaArea;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			reportedDate = instance.reportedDate;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			gradient = instance.gradient;
			scaleMinimum = instance.scaleMinimum;
			qualityOfHorizontalMeasurement = instance.qualityOfHorizontalMeasurement;
			return this;
		}

		public override string Serialize() {
			var instance = new SeaAreaNamedWaterArea {
				categoryOfSeaArea = this.categoryOfSeaArea,
				information = this.information.Select(e => e.Model).ToList(),
				reportedDate = this.reportedDate,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				gradient = this.gradient,
				scaleMinimum = this.scaleMinimum,
				qualityOfHorizontalMeasurement = this.qualityOfHorizontalMeasurement,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SeaAreaNamedWaterArea Model => new () {
			categoryOfSeaArea = this._categoryOfSeaArea,
			information = this.information.Select(e => e.Model).ToList(),
			reportedDate = this._reportedDate,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			gradient = this._gradient,
			scaleMinimum = this._scaleMinimum,
			qualityOfHorizontalMeasurement = this._qualityOfHorizontalMeasurement,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => SeaAreaNamedWaterArea._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => SeaAreaNamedWaterArea._featureBindingDefinitions;

		public override string? ToString() => $"Sea Area/Named Water Area";

		public SeaAreaNamedWaterAreaViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
		}
	}

	/// <summary>
	/// Area designated for landing personnel and/or equipment by parachute 
	/// </summary>
	[CategoryOrder("DropZone",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DropZoneViewModel : FeatureViewModel<DropZone> {
		[Category("DropZone")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();


		public override FeatureViewModel<DropZone> Load(DropZone instance) {
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new DropZone {
				information = this.information.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DropZone Model => new () {
			information = this.information.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => DropZone._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => DropZone._featureBindingDefinitions;

		public override string? ToString() => $"Drop Zone";

		public DropZoneViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// A mechanical device for conveying bulk material or people using an endless moving belt or series of rollers.
	/// </summary>
	[CategoryOrder("Conveyor",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ConveyorViewModel : FeatureViewModel<Conveyor> {
		private categoryOfConveyor? _categoryOfConveyor  = default;

		[Category("Conveyor")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfConveyorList), typeof(categoryOfConveyor))]
		public categoryOfConveyor? categoryOfConveyor {
			get {
				return _categoryOfConveyor;
			}
			set {
				SetValue(ref _categoryOfConveyor, value);
			}
		}

		[Browsable(false)]
		public categoryOfConveyor[] categoryOfConveyorList => [(categoryOfConveyor)1,(categoryOfConveyor)2,(categoryOfConveyor)3,(categoryOfConveyor)4];
		[Category("Conveyor")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private condition? _condition  = default;

		[Category("Conveyor")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)5];
		private DateOnly? _reportedDate  = default;

		[Category("Conveyor")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		[Category("Conveyor")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("Conveyor")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private visualProminence? _visualProminence  = default;

		[Category("Conveyor")]
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
		private decimal? _height  = default;

		[Category("Conveyor")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private Boolean? _radarConspicuous  = default;

		[Category("Conveyor")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		private multiplicityOfFeaturesViewModel? _multiplicityOfFeatures  = default;

		[Category("Conveyor")]
		[ExpandableObject]
		public multiplicityOfFeaturesViewModel? multiplicityOfFeatures {
			get {
				return _multiplicityOfFeatures;
			}
			set {
				SetValue(ref _multiplicityOfFeatures, value);
			}
		}
		[Category("Conveyor")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)4,(status)12];
		private decimal? _liftingCapacity  = default;

		[Category("Conveyor")]
		public decimal? liftingCapacity {
			get {
				return _liftingCapacity;
			}
			set {
				SetValue(ref _liftingCapacity, value);
			}
		}
		private verticalClearanceFixedViewModel? _verticalClearanceFixed  = default;

		[Category("Conveyor")]
		[ExpandableObject]
		public verticalClearanceFixedViewModel? verticalClearanceFixed {
			get {
				return _verticalClearanceFixed;
			}
			set {
				SetValue(ref _verticalClearanceFixed, value);
			}
		}
		private verticalDatum? _verticalDatum  = default;

		[Category("Conveyor")]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)3,(verticalDatum)13,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)44];
		private String? _pictorialRepresentation  = default;

		[Category("Conveyor")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("Conveyor")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private colourPattern? _colourPattern  = default;

		[Category("Conveyor")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public colourPattern? colourPattern {
			get {
				return _colourPattern;
			}
			set {
				SetValue(ref _colourPattern, value);
			}
		}

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6];
		private int? _scaleMinimum  = default;

		[Category("Conveyor")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		[Category("Conveyor")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(productList), typeof(product))]
		public ObservableCollection<product> product  { get; set; } = new ();

		[Browsable(false)]
		public product[] productList => [(product)4,(product)5,(product)6,(product)10,(product)11,(product)12,(product)13,(product)14,(product)15,(product)16,(product)17,(product)22,(product)25];
		private decimal? _verticalLength  = default;

		[Category("Conveyor")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}


		public override FeatureViewModel<Conveyor> Load(Conveyor instance) {
			categoryOfConveyor = instance.categoryOfConveyor;
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			condition = instance.condition;
			reportedDate = instance.reportedDate;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			visualProminence = instance.visualProminence;
			height = instance.height;
			radarConspicuous = instance.radarConspicuous;
			multiplicityOfFeatures = new ();
			if (instance.multiplicityOfFeatures != default) {
				multiplicityOfFeatures.Load(instance.multiplicityOfFeatures);
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			liftingCapacity = instance.liftingCapacity;
			verticalClearanceFixed = new ();
			if (instance.verticalClearanceFixed != default) {
				verticalClearanceFixed.Load(instance.verticalClearanceFixed);
			}
			verticalDatum = instance.verticalDatum;
			pictorialRepresentation = instance.pictorialRepresentation;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			colourPattern = instance.colourPattern;
			scaleMinimum = instance.scaleMinimum;
			product.Clear();
			if (instance.product is not null) {
				foreach(var e in instance.product)
					product.Add(e);
			}
			verticalLength = instance.verticalLength;
			return this;
		}

		public override string Serialize() {
			var instance = new Conveyor {
				categoryOfConveyor = this.categoryOfConveyor,
				featureName = this.featureName.Select(e => e.Model).ToList(),
				condition = this.condition,
				reportedDate = this.reportedDate,
				colour = this.colour.ToList(),
				information = this.information.Select(e => e.Model).ToList(),
				visualProminence = this.visualProminence,
				height = this.height,
				radarConspicuous = this.radarConspicuous,
				multiplicityOfFeatures = this.multiplicityOfFeatures?.Model,
				status = this.status.ToList(),
				liftingCapacity = this.liftingCapacity,
				verticalClearanceFixed = this.verticalClearanceFixed?.Model,
				verticalDatum = this.verticalDatum,
				pictorialRepresentation = this.pictorialRepresentation,
				fixedDateRange = this.fixedDateRange?.Model,
				colourPattern = this.colourPattern,
				scaleMinimum = this.scaleMinimum,
				product = this.product.ToList(),
				verticalLength = this.verticalLength,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Conveyor Model => new () {
			categoryOfConveyor = this._categoryOfConveyor,
			featureName = this.featureName.Select(e => e.Model).ToList(),
			condition = this._condition,
			reportedDate = this._reportedDate,
			colour = this.colour.ToList(),
			information = this.information.Select(e => e.Model).ToList(),
			visualProminence = this._visualProminence,
			height = this._height,
			radarConspicuous = this._radarConspicuous,
			multiplicityOfFeatures = this._multiplicityOfFeatures?.Model,
			status = this.status.ToList(),
			liftingCapacity = this._liftingCapacity,
			verticalClearanceFixed = this._verticalClearanceFixed?.Model,
			verticalDatum = this._verticalDatum,
			pictorialRepresentation = this._pictorialRepresentation,
			fixedDateRange = this._fixedDateRange?.Model,
			colourPattern = this._colourPattern,
			scaleMinimum = this._scaleMinimum,
			product = this.product.ToList(),
			verticalLength = this._verticalLength,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => Conveyor._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => Conveyor._featureBindingDefinitions;

		public override string? ToString() => $"Conveyor";

		public ConveyorViewModel() : base() {
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			product.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(product));
			};
		}
	}

	/// <summary>
	/// A line drawn on a map or chart depicting the separation of any type of maritime jurisdiction.
	/// </summary>
	[CategoryOrder("LineOfDelimitation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LineOfDelimitationViewModel : FeatureViewModel<LineOfDelimitation> {
		[Category("LineOfDelimitation")]
		public ObservableCollection<String> nationalMaritimeAuthority  { get; set; } = new ();
		private boundaryStatusType? _boundaryStatusType  = default;

		[Category("LineOfDelimitation")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(boundaryStatusTypeList), typeof(boundaryStatusType))]
		public boundaryStatusType? boundaryStatusType {
			get {
				return _boundaryStatusType;
			}
			set {
				SetValue(ref _boundaryStatusType, value);
			}
		}

		[Browsable(false)]
		public boundaryStatusType[] boundaryStatusTypeList => [(boundaryStatusType)501,(boundaryStatusType)502,(boundaryStatusType)504,(boundaryStatusType)599];
		[Category("LineOfDelimitation")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private DateOnly? _reportedDate  = default;

		[Category("LineOfDelimitation")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("LineOfDelimitation")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private jurisdiction? _jurisdiction  = default;

		[Category("LineOfDelimitation")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(jurisdictionList), typeof(jurisdiction))]
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
		private categoryofBoundaryLine? _categoryofBoundaryLine  = default;

		[Category("LineOfDelimitation")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryofBoundaryLineList), typeof(categoryofBoundaryLine))]
		public categoryofBoundaryLine? categoryofBoundaryLine {
			get {
				return _categoryofBoundaryLine;
			}
			set {
				SetValue(ref _categoryofBoundaryLine, value);
			}
		}

		[Browsable(false)]
		public categoryofBoundaryLine[] categoryofBoundaryLineList => [(categoryofBoundaryLine)501,(categoryofBoundaryLine)506,(categoryofBoundaryLine)511,(categoryofBoundaryLine)599];
		private Boolean? _inDispute  = default;

		[Category("LineOfDelimitation")]
		public Boolean? inDispute {
			get {
				return _inDispute;
			}
			set {
				SetValue(ref _inDispute, value);
			}
		}


		public override FeatureViewModel<LineOfDelimitation> Load(LineOfDelimitation instance) {
			nationalMaritimeAuthority.Clear();
			if (instance.nationalMaritimeAuthority is not null) {
				foreach(var e in instance.nationalMaritimeAuthority)
					nationalMaritimeAuthority.Add(e);
			}
			boundaryStatusType = instance.boundaryStatusType;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			reportedDate = instance.reportedDate;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			jurisdiction = instance.jurisdiction;
			categoryofBoundaryLine = instance.categoryofBoundaryLine;
			inDispute = instance.inDispute;
			return this;
		}

		public override string Serialize() {
			var instance = new LineOfDelimitation {
				nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
				boundaryStatusType = this.boundaryStatusType,
				information = this.information.Select(e => e.Model).ToList(),
				reportedDate = this.reportedDate,
				sourceIdentification = this.sourceIdentification?.Model,
				jurisdiction = this.jurisdiction,
				categoryofBoundaryLine = this.categoryofBoundaryLine,
				inDispute = this.inDispute,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LineOfDelimitation Model => new () {
			nationalMaritimeAuthority = this.nationalMaritimeAuthority.ToList(),
			boundaryStatusType = this._boundaryStatusType,
			information = this.information.Select(e => e.Model).ToList(),
			reportedDate = this._reportedDate,
			sourceIdentification = this._sourceIdentification?.Model,
			jurisdiction = this._jurisdiction,
			categoryofBoundaryLine = this._categoryofBoundaryLine,
			inDispute = this._inDispute,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => LineOfDelimitation._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => LineOfDelimitation._featureBindingDefinitions;

		public override string? ToString() => $"Line of Delimitation";

		public LineOfDelimitationViewModel() : base() {
			nationalMaritimeAuthority.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(nationalMaritimeAuthority));
			};
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// Straight baselines are a system of straight lines joining specified or discrete points on the low-water line, usually known as straight baseline turning points. Straight baselines are used in delimitation.
	/// </summary>
	[CategoryOrder("StraightTerritorialSeaBaseline",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class StraightTerritorialSeaBaselineViewModel : FeatureViewModel<StraightTerritorialSeaBaseline> {
		private String _nationality  = string.Empty;

		[Category("StraightTerritorialSeaBaseline")]
		public String nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("StraightTerritorialSeaBaseline")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("StraightTerritorialSeaBaseline")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		[Category("StraightTerritorialSeaBaseline")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		private status? _status  = default;

		[Category("StraightTerritorialSeaBaseline")]
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
		public status[] statusList => [(status)502,(status)504];
		private Boolean? _inDispute  = default;

		[Category("StraightTerritorialSeaBaseline")]
		public Boolean? inDispute {
			get {
				return _inDispute;
			}
			set {
				SetValue(ref _inDispute, value);
			}
		}
		private String? _agencyResponsibleForProduction  = default;

		[Category("StraightTerritorialSeaBaseline")]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("StraightTerritorialSeaBaseline")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}


		public override FeatureViewModel<StraightTerritorialSeaBaseline> Load(StraightTerritorialSeaBaseline instance) {
			nationality = instance.nationality;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			reportedDate = instance.reportedDate;
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			status = instance.status;
			inDispute = instance.inDispute;
			agencyResponsibleForProduction = instance.agencyResponsibleForProduction;
			scaleMinimum = instance.scaleMinimum;
			return this;
		}

		public override string Serialize() {
			var instance = new StraightTerritorialSeaBaseline {
				nationality = this.nationality,
				sourceIdentification = this.sourceIdentification?.Model,
				reportedDate = this.reportedDate,
				information = this.information.Select(e => e.Model).ToList(),
				status = this.status,
				inDispute = this.inDispute,
				agencyResponsibleForProduction = this.agencyResponsibleForProduction,
				scaleMinimum = this.scaleMinimum,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public StraightTerritorialSeaBaseline Model => new () {
			nationality = this._nationality,
			sourceIdentification = this._sourceIdentification?.Model,
			reportedDate = this._reportedDate,
			information = this.information.Select(e => e.Model).ToList(),
			status = this._status,
			inDispute = this._inDispute,
			agencyResponsibleForProduction = this._agencyResponsibleForProduction,
			scaleMinimum = this._scaleMinimum,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => StraightTerritorialSeaBaseline._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => StraightTerritorialSeaBaseline._featureBindingDefinitions;

		public override string? ToString() => $"Straight Territorial Sea Baseline";

		public StraightTerritorialSeaBaselineViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
		}
	}

	/// <summary>
	/// A safe water beacon is used to indicate that there is navigable water around the mark.
	/// </summary>
	[CategoryOrder("SafeWaterBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SafeWaterBeaconViewModel : FeatureViewModel<SafeWaterBeacon> {
		[Category("SafeWaterBeacon")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("SafeWaterBeacon")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		private decimal? _elevation  = default;

		[Category("SafeWaterBeacon")]
		public decimal? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("SafeWaterBeacon")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private decimal? _height  = default;

		[Category("SafeWaterBeacon")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private topmarkViewModel? _topmark  = default;

		[Category("SafeWaterBeacon")]
		[ExpandableObject]
		public topmarkViewModel? topmark {
			get {
				return _topmark;
			}
			set {
				SetValue(ref _topmark, value);
			}
		}
		[Category("SafeWaterBeacon")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8];
		private Boolean? _radarConspicuous  = default;

		[Category("SafeWaterBeacon")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		private DateOnly? _reportedDate  = default;

		[Category("SafeWaterBeacon")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private condition? _condition  = default;

		[Category("SafeWaterBeacon")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)5];
		private colourPattern? _colourPattern  = default;

		[Category("SafeWaterBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public colourPattern? colourPattern {
			get {
				return _colourPattern;
			}
			set {
				SetValue(ref _colourPattern, value);
			}
		}

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6];
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("SafeWaterBeacon")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private decimal? _verticalLength  = default;

		[Category("SafeWaterBeacon")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private beaconShape _beaconShape ;

		[Category("SafeWaterBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		[Category("SafeWaterBeacon")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)5,(status)7,(status)8,(status)12,(status)18];
		private String? _pictorialRepresentation  = default;

		[Category("SafeWaterBeacon")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("SafeWaterBeacon")]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)11];
		private String? _interoperabilityIdentifier  = default;

		[Category("SafeWaterBeacon")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("SafeWaterBeacon")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		[Category("SafeWaterBeacon")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();
		[Category("SafeWaterBeacon")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		private visualProminence? _visualProminence  = default;

		[Category("SafeWaterBeacon")]
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


		public override FeatureViewModel<SafeWaterBeacon> Load(SafeWaterBeacon instance) {
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
			elevation = instance.elevation;
			scaleMinimum = instance.scaleMinimum;
			height = instance.height;
			topmark = new ();
			if (instance.topmark != default) {
				topmark.Load(instance.topmark);
			}
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			radarConspicuous = instance.radarConspicuous;
			reportedDate = instance.reportedDate;
			condition = instance.condition;
			colourPattern = instance.colourPattern;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			verticalLength = instance.verticalLength;
			beaconShape = instance.beaconShape;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			pictorialRepresentation = instance.pictorialRepresentation;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			visualProminence = instance.visualProminence;
			return this;
		}

		public override string Serialize() {
			var instance = new SafeWaterBeacon {
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				elevation = this.elevation,
				scaleMinimum = this.scaleMinimum,
				height = this.height,
				topmark = this.topmark?.Model,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				radarConspicuous = this.radarConspicuous,
				reportedDate = this.reportedDate,
				condition = this.condition,
				colourPattern = this.colourPattern,
				fixedDateRange = this.fixedDateRange?.Model,
				verticalLength = this.verticalLength,
				beaconShape = this.beaconShape,
				status = this.status.ToList(),
				pictorialRepresentation = this.pictorialRepresentation,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				sourceIdentification = this.sourceIdentification?.Model,
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
				colour = this.colour.ToList(),
				visualProminence = this.visualProminence,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SafeWaterBeacon Model => new () {
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			elevation = this._elevation,
			scaleMinimum = this._scaleMinimum,
			height = this._height,
			topmark = this._topmark?.Model,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			radarConspicuous = this._radarConspicuous,
			reportedDate = this._reportedDate,
			condition = this._condition,
			colourPattern = this._colourPattern,
			fixedDateRange = this._fixedDateRange?.Model,
			verticalLength = this._verticalLength,
			beaconShape = this._beaconShape,
			status = this.status.ToList(),
			pictorialRepresentation = this._pictorialRepresentation,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			sourceIdentification = this._sourceIdentification?.Model,
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			colour = this.colour.ToList(),
			visualProminence = this._visualProminence,
		};
		public override informationBindingDefinition[] informationBindingDefinitions => SafeWaterBeacon._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => SafeWaterBeacon._featureBindingDefinitions;

		public override string? ToString() => $"Safe Water Beacon";

		public SafeWaterBeaconViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
		}
	}

	/// <summary>
	/// A special purpose beacon is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notices to Mariners.
	/// </summary>
	[CategoryOrder("SpecialPurposeGeneralBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SpecialPurposeGeneralBeaconViewModel : FeatureViewModel<SpecialPurposeGeneralBeacon> {
		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		[ExpandableObject]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}
		[Category("SpecialPurposeGeneralBeacon")]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();
		[Category("SpecialPurposeGeneralBeacon")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(statusList), typeof(status))]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)12,(status)18];
		[Category("SpecialPurposeGeneralBeacon")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(natureOfConstructionList), typeof(natureOfConstruction))]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8];
		private String? _interoperabilityIdentifier  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}
		private int? _scaleMinimum  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}
		private decimal? _height  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		public decimal? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}
		private condition? _condition  = default;

		[Category("SpecialPurposeGeneralBeacon")]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)5];
		private decimal? _verticalLength  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		public decimal? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}
		private decimal? _elevation  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		public decimal? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}
		private colourPattern? _colourPattern  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourPatternList), typeof(colourPattern))]
		public colourPattern? colourPattern {
			get {
				return _colourPattern;
			}
			set {
				SetValue(ref _colourPattern, value);
			}
		}

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6];
		private Boolean? _radarConspicuous  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}
		private String? _pictorialRepresentation  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}
		private beaconShape _beaconShape ;

		[Category("SpecialPurposeGeneralBeacon")]
		[Editor(typeof(Editors.EnumComboBoxEditor), typeof(Editors.EnumComboBoxEditor))]
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
		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		[ExpandableObject]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}
		private topmarkViewModel? _topmark  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		[ExpandableObject]
		public topmarkViewModel? topmark {
			get {
				return _topmark;
			}
			set {
				SetValue(ref _topmark, value);
			}
		}
		[Category("SpecialPurposeGeneralBeacon")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(categoryOfSpecialPurposeMarkList), typeof(categoryOfSpecialPurposeMark))]
		public ObservableCollection<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfSpecialPurposeMark[] categoryOfSpecialPurposeMarkList => [(categoryOfSpecialPurposeMark)1,(categoryOfSpecialPurposeMark)2,(categoryOfSpecialPurposeMark)3,(categoryOfSpecialPurposeMark)4,(categoryOfSpecialPurposeMark)5,(categoryOfSpecialPurposeMark)6,(categoryOfSpecialPurposeMark)7,(categoryOfSpecialPurposeMark)8,(categoryOfSpecialPurposeMark)10,(categoryOfSpecialPurposeMark)11,(categoryOfSpecialPurposeMark)12,(categoryOfSpecialPurposeMark)14,(categoryOfSpecialPurposeMark)16,(categoryOfSpecialPurposeMark)17,(categoryOfSpecialPurposeMark)18,(categoryOfSpecialPurposeMark)19,(categoryOfSpecialPurposeMark)20,(categoryOfSpecialPurposeMark)21,(categoryOfSpecialPurposeMark)22,(categoryOfSpecialPurposeMark)23,(categoryOfSpecialPurposeMark)24,(categoryOfSpecialPurposeMark)25,(categoryOfSpecialPurposeMark)26,(categoryOfSpecialPurposeMark)27,(categoryOfSpecialPurposeMark)28,(categoryOfSpecialPurposeMark)29,(categoryOfSpecialPurposeMark)30,(categoryOfSpecialPurposeMark)31,(categoryOfSpecialPurposeMark)32,(categoryOfSpecialPurposeMark)33,(categoryOfSpecialPurposeMark)34,(categoryOfSpecialPurposeMark)35,(categoryOfSpecialPurposeMark)36,(categoryOfSpecialPurposeMark)37,(categoryOfSpecialPurposeMark)39,(categoryOfSpecialPurposeMark)40,(categoryOfSpecialPurposeMark)41,(categoryOfSpecialPurposeMark)42,(categoryOfSpecialPurposeMark)43,(categoryOfSpecialPurposeMark)44,(categoryOfSpecialPurposeMark)45,(categoryOfSpecialPurposeMark)46,(categoryOfSpecialPurposeMark)47,(categoryOfSpecialPurposeMark)48,(categoryOfSpecialPurposeMark)49,(categoryOfSpecialPurposeMark)50,(categoryOfSpecialPurposeMark)51,(categoryOfSpecialPurposeMark)52,(categoryOfSpecialPurposeMark)53,(categoryOfSpecialPurposeMark)54,(categoryOfSpecialPurposeMark)55,(categoryOfSpecialPurposeMark)56,(categoryOfSpecialPurposeMark)57,(categoryOfSpecialPurposeMark)58,(categoryOfSpecialPurposeMark)60,(categoryOfSpecialPurposeMark)61,(categoryOfSpecialPurposeMark)62,(categoryOfSpecialPurposeMark)63];
		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("SpecialPurposeGeneralBeacon")]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)11];
		private DateOnly? _reportedDate  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		public DateOnly? reportedDate {
			get {
				return _reportedDate;
			}
			set {
				SetValue(ref _reportedDate, value);
			}
		}
		private visualProminence? _visualProminence  = default;

		[Category("SpecialPurposeGeneralBeacon")]
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
		[Category("SpecialPurposeGeneralBeacon")]
		[Editor(typeof(Editors.EnumCollectionEditor), typeof(Editors.EnumCollectionEditor))]
		[DomainModel.EnumerationAttribute(nameof(colourList), typeof(colour))]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];
		[Category("SpecialPurposeGeneralBeacon")]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();
		[Category("SpecialPurposeGeneralBeacon")]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();


		public override FeatureViewModel<SpecialPurposeGeneralBeacon> Load(SpecialPurposeGeneralBeacon instance) {
			sourceIdentification = new ();
			if (instance.sourceIdentification != default) {
				sourceIdentification.Load(instance.sourceIdentification);
			}
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			scaleMinimum = instance.scaleMinimum;
			height = instance.height;
			condition = instance.condition;
			verticalLength = instance.verticalLength;
			elevation = instance.elevation;
			colourPattern = instance.colourPattern;
			radarConspicuous = instance.radarConspicuous;
			pictorialRepresentation = instance.pictorialRepresentation;
			beaconShape = instance.beaconShape;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			topmark = new ();
			if (instance.topmark != default) {
				topmark.Load(instance.topmark);
			}
			categoryOfSpecialPurposeMark.Clear();
			if (instance.categoryOfSpecialPurposeMark is not null) {
				foreach(var e in instance.categoryOfSpecialPurposeMark)
					categoryOfSpecialPurposeMark.Add(e);
			}
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			reportedDate = instance.reportedDate;
			visualProminence = instance.visualProminence;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			featureName.Clear();
			if (instance.featureName is not null) {
				foreach(var e in instance.featureName)
					featureName.Add(new featureNameViewModel().Load(e));
			}
			periodicDateRange.Clear();
			if (instance.periodicDateRange is not null) {
				foreach(var e in instance.periodicDateRange)
					periodicDateRange.Add(new periodicDateRangeViewModel().Load(e));
			}
			return this;
		}

		public override string Serialize() {
			var instance = new SpecialPurposeGeneralBeacon {
				sourceIdentification = this.sourceIdentification?.Model,
				information = this.information.Select(e => e.Model).ToList(),
				status = this.status.ToList(),
				natureOfConstruction = this.natureOfConstruction.ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				scaleMinimum = this.scaleMinimum,
				height = this.height,
				condition = this.condition,
				verticalLength = this.verticalLength,
				elevation = this.elevation,
				colourPattern = this.colourPattern,
				radarConspicuous = this.radarConspicuous,
				pictorialRepresentation = this.pictorialRepresentation,
				beaconShape = this.beaconShape,
				fixedDateRange = this.fixedDateRange?.Model,
				topmark = this.topmark?.Model,
				categoryOfSpecialPurposeMark = this.categoryOfSpecialPurposeMark.ToList(),
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				reportedDate = this.reportedDate,
				visualProminence = this.visualProminence,
				colour = this.colour.ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SpecialPurposeGeneralBeacon Model => new () {
			sourceIdentification = this._sourceIdentification?.Model,
			information = this.information.Select(e => e.Model).ToList(),
			status = this.status.ToList(),
			natureOfConstruction = this.natureOfConstruction.ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			scaleMinimum = this._scaleMinimum,
			height = this._height,
			condition = this._condition,
			verticalLength = this._verticalLength,
			elevation = this._elevation,
			colourPattern = this._colourPattern,
			radarConspicuous = this._radarConspicuous,
			pictorialRepresentation = this._pictorialRepresentation,
			beaconShape = this._beaconShape,
			fixedDateRange = this._fixedDateRange?.Model,
			topmark = this._topmark?.Model,
			categoryOfSpecialPurposeMark = this.categoryOfSpecialPurposeMark.ToList(),
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			reportedDate = this._reportedDate,
			visualProminence = this._visualProminence,
			colour = this.colour.ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			periodicDateRange = this.periodicDateRange.Select(e => e.Model).ToList(),
		};
		public override informationBindingDefinition[] informationBindingDefinitions => SpecialPurposeGeneralBeacon._informationBindingDefinitions;

		public override featureBindingDefinition[] featureBindingDefinitions => SpecialPurposeGeneralBeacon._featureBindingDefinitions;

		public override string? ToString() => $"Special Purpose/General Beacon";

		public SpecialPurposeGeneralBeaconViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			natureOfConstruction.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(natureOfConstruction));
			};
			categoryOfSpecialPurposeMark.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(categoryOfSpecialPurposeMark));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(periodicDateRange));
			};
		}
	}

}
