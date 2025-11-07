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
using System.Text.Json;

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
	public partial class qRouteChannelWidthViewModel : ComplexViewModel<qRouteChannelWidth> {
		private double? _rightQRouteWidth  = default;

		[Editor(typeof(Editors.HorizonEditor<qRouteChannelWidth>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? rightQRouteWidth {
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
	public partial class detectionDateRangeViewModel : ComplexViewModel<detectionDateRange> {
		private String? _lastDetectionYear  = default;

		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? lastDetectionYear {
			get {
				return _lastDetectionYear;
			}
			set {
				SetValue(ref _lastDetectionYear, value);
			}
		}

		private String? _firstDetectionYear  = default;

		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? firstDetectionYear {
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
	public partial class multiplicityOfFeaturesViewModel : ComplexViewModel<multiplicityOfFeatures> {
		private int? _numberOfFeatures  = default;

		[Editor(typeof(Editors.HorizonEditor<multiplicityOfFeatures>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? numberOfFeatures {
			get {
				return _numberOfFeatures;
			}
			set {
				SetValue(ref _numberOfFeatures, value);
			}
		}

		private Boolean? _multiplicityKnown  = default;

		[Editor(typeof(Editors.HorizonEditor<multiplicityOfFeatures>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public Boolean? multiplicityKnown {
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
	public partial class onlineResourceViewModel : ComplexViewModel<onlineResource> {
		private String? _headline  = default;

		[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? headline {
			get {
				return _headline;
			}
			set {
				SetValue(ref _headline, value);
			}
		}

		private String? _linkage  = default;

		[Editor(typeof(Editors.HorizonEditor<onlineResource>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String? linkage {
			get {
				return _linkage;
			}
			set {
				SetValue(ref _linkage, value);
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
	public partial class topmarkViewModel : ComplexViewModel<topmark> {
		private topmarkDaymarkShape? _topmarkDaymarkShape  = default;

		[Editor(typeof(Editors.HorizonEditor<topmark>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public topmarkDaymarkShape? topmarkDaymarkShape {
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

		[Editor(typeof(Editors.HorizonEditor<topmark>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Editor(typeof(Editors.HorizonEditor<topmark>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Optional]
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
	public partial class featureNameViewModel : ComplexViewModel<featureName> {
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
		public nameUsage[] nameUsageList => [(nameUsage)1,(nameUsage)2];

		private String? _name  = default;

		[Editor(typeof(Editors.HorizonEditor<featureName>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String? name {
			get {
				return _name;
			}
			set {
				SetValue(ref _name, value);
			}
		}

		private String? _language  = default;

		[Editor(typeof(Editors.HorizonEditor<featureName>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String? language {
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
	/// Altitude range encompasses both the maximum and minimum heights (AGL - above ground level) above the surface level, representing the vertical span from the highest to the lowest point of the feature.
	/// </summary>
	[CategoryOrder("altitudeRange",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class altitudeRangeViewModel : ComplexViewModel<altitudeRange> {
		private int? _minimumAltitude  = default;

		[Editor(typeof(Editors.HorizonEditor<altitudeRange>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int? minimumAltitude {
			get {
				return _minimumAltitude;
			}
			set {
				SetValue(ref _minimumAltitude, value);
			}
		}

		private int? _maximumAltitude  = default;

		[Editor(typeof(Editors.HorizonEditor<altitudeRange>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int? maximumAltitude {
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
	public partial class altitudeViewModel : ComplexViewModel<altitude> {
		private int? _minimumAltitude  = default;

		[Editor(typeof(Editors.HorizonEditor<altitude>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int? minimumAltitude {
			get {
				return _minimumAltitude;
			}
			set {
				SetValue(ref _minimumAltitude, value);
			}
		}

		private int? _maximumAltitude  = default;

		[Editor(typeof(Editors.HorizonEditor<altitude>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int? maximumAltitude {
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
	public partial class rythmOfLightViewModel : ComplexViewModel<rythmOfLight> {
		[Optional]
		public ObservableCollection<signalSequenceViewModel> signalSequence  { get; set; } = new ();

		private double? _signalPeriod  = default;

		[Editor(typeof(Editors.HorizonEditor<rythmOfLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? signalPeriod {
			get {
				return _signalPeriod;
			}
			set {
				SetValue(ref _signalPeriod, value);
			}
		}

		[Optional]
		public ObservableCollection<String> signalGroup  { get; set; } = new ();

		private lightCharacteristic? _lightCharacteristic  = default;

		[Editor(typeof(Editors.HorizonEditor<rythmOfLight>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public lightCharacteristic? lightCharacteristic {
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
	public partial class verticalClearanceSafeViewModel : ComplexViewModel<verticalClearanceSafe> {
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

		private double? _verticalClearanceValue  = default;

		[Editor(typeof(Editors.HorizonEditor<verticalClearanceSafe>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? verticalClearanceValue {
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
	public partial class lastSourceInformationViewModel : ComplexViewModel<lastSourceInformation> {
		private lastSensor? _lastSensor  = default;

		[Editor(typeof(Editors.HorizonEditor<lastSourceInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Editor(typeof(Editors.HorizonEditor<lastSourceInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? lastSource {
			get {
				return _lastSource;
			}
			set {
				SetValue(ref _lastSource, value);
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
	public partial class informationViewModel : ComplexViewModel<information> {
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
		[Mandatory]
		public String? language {
			get {
				return _language;
			}
			set {
				SetValue(ref _language, value);
			}
		}

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
	public partial class firstSourceInformationViewModel : ComplexViewModel<firstSourceInformation> {
		private firstSensor? _firstSensor  = default;

		[Editor(typeof(Editors.HorizonEditor<firstSourceInformation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public firstSensor? firstSensor {
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

		[Editor(typeof(Editors.HorizonEditor<firstSourceInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? firstSource {
			get {
				return _firstSource;
			}
			set {
				SetValue(ref _firstSource, value);
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
	public partial class horizontalClearanceFixedViewModel : ComplexViewModel<horizontalClearanceFixed> {
		private double? _horizontalClearanceValue  = default;

		[Editor(typeof(Editors.HorizonEditor<horizontalClearanceFixed>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? horizontalClearanceValue {
			get {
				return _horizontalClearanceValue;
			}
			set {
				SetValue(ref _horizontalClearanceValue, value);
			}
		}

		private double? _horizontalDistanceUncertainty  = default;

		[Editor(typeof(Editors.HorizonEditor<horizontalClearanceFixed>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalDistanceUncertainty {
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
	public partial class verticalUncertaintyViewModel : ComplexViewModel<verticalUncertainty> {
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

		private double? _uncertaintyFixed  = default;

		[Editor(typeof(Editors.HorizonEditor<verticalUncertainty>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? uncertaintyFixed {
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
		[Mandatory]
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
	/// Combinations of values of measurable characteristics or dimensions of vessels, used to specify size and tonnage ranges.
	/// </summary>
	[CategoryOrder("vesselMeasurementsSpecification",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class vesselMeasurementsSpecificationViewModel : ComplexViewModel<vesselMeasurementsSpecification> {
		private double? _vesselsCharacteristicsValue  = default;

		[Editor(typeof(Editors.HorizonEditor<vesselMeasurementsSpecification>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? vesselsCharacteristicsValue {
			get {
				return _vesselsCharacteristicsValue;
			}
			set {
				SetValue(ref _vesselsCharacteristicsValue, value);
			}
		}

		private vesselsCharacteristics? _vesselsCharacteristics  = default;

		[Editor(typeof(Editors.HorizonEditor<vesselMeasurementsSpecification>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public vesselsCharacteristics? vesselsCharacteristics {
			get {
				return _vesselsCharacteristics;
			}
			set {
				SetValue(ref _vesselsCharacteristics, value);
			}
		}

		[Browsable(false)]
		public vesselsCharacteristics[] vesselsCharacteristicsList => [(vesselsCharacteristics)1,(vesselsCharacteristics)2,(vesselsCharacteristics)3,(vesselsCharacteristics)4,(vesselsCharacteristics)6,(vesselsCharacteristics)10,(vesselsCharacteristics)11];

		private vesselsCharacteristicsUnit? _vesselsCharacteristicsUnit  = default;

		[Editor(typeof(Editors.HorizonEditor<vesselMeasurementsSpecification>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public vesselsCharacteristicsUnit? vesselsCharacteristicsUnit {
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

		[Editor(typeof(Editors.HorizonEditor<vesselMeasurementsSpecification>), typeof(Editors.HorizonEditor))]
		[Optional]
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
	public partial class surfaceCharacteristicsViewModel : ComplexViewModel<surfaceCharacteristics> {
		private int? _underlyingLayer  = default;

		[Editor(typeof(Editors.HorizonEditor<surfaceCharacteristics>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? underlyingLayer {
			get {
				return _underlyingLayer;
			}
			set {
				SetValue(ref _underlyingLayer, value);
			}
		}

		[Multiplicity(0, 3)]
		public ObservableCollection<natureOfSurfaceQualifyingTerms> natureOfSurfaceQualifyingTerms  { get; set; } = new ();

		[Browsable(false)]
		public natureOfSurfaceQualifyingTerms[] natureOfSurfaceQualifyingTermsList => [(natureOfSurfaceQualifyingTerms)1,(natureOfSurfaceQualifyingTerms)2,(natureOfSurfaceQualifyingTerms)3,(natureOfSurfaceQualifyingTerms)4,(natureOfSurfaceQualifyingTerms)5,(natureOfSurfaceQualifyingTerms)6,(natureOfSurfaceQualifyingTerms)7,(natureOfSurfaceQualifyingTerms)8,(natureOfSurfaceQualifyingTerms)9,(natureOfSurfaceQualifyingTerms)10];

		private natureOfSurface? _natureOfSurface  = default;

		[Editor(typeof(Editors.HorizonEditor<surfaceCharacteristics>), typeof(Editors.HorizonEditor))]
		[Optional]
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
	public partial class magneticInformationViewModel : ComplexViewModel<magneticInformation> {
		private strengthOfMagneticAnomaly? _strengthOfMagneticAnomaly  = default;

		[Editor(typeof(Editors.HorizonEditor<magneticInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Editor(typeof(Editors.HorizonEditor<magneticInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? magneticIntensity {
			get {
				return _magneticIntensity;
			}
			set {
				SetValue(ref _magneticIntensity, value);
			}
		}

		private magneticAnomalyDetectorSignature? _magneticAnomalyDetectorSignature  = default;

		[Editor(typeof(Editors.HorizonEditor<magneticInformation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public magneticAnomalyDetectorSignature? magneticAnomalyDetectorSignature {
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
	public partial class speedViewModel : ComplexViewModel<speed> {
		private double? _speedMinimum  = default;

		[Editor(typeof(Editors.HorizonEditor<speed>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? speedMinimum {
			get {
				return _speedMinimum;
			}
			set {
				SetValue(ref _speedMinimum, value);
			}
		}

		private double? _speedMaximum  = default;

		[Editor(typeof(Editors.HorizonEditor<speed>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? speedMaximum {
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
	public partial class verticalClearanceFixedViewModel : ComplexViewModel<verticalClearanceFixed> {
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

		private double? _verticalClearanceValue  = default;

		[Editor(typeof(Editors.HorizonEditor<verticalClearanceFixed>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? verticalClearanceValue {
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
	public partial class sourceIdentificationViewModel : ComplexViewModel<sourceIdentification> {
		private String? _producerNation  = default;

		[Editor(typeof(Editors.HorizonEditor<sourceIdentification>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? producerNation {
			get {
				return _producerNation;
			}
			set {
				SetValue(ref _producerNation, value);
			}
		}

		private String? _sourceType  = default;

		[Editor(typeof(Editors.HorizonEditor<sourceIdentification>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? sourceType {
			get {
				return _sourceType;
			}
			set {
				SetValue(ref _sourceType, value);
			}
		}

		private String? _productionAgency  = default;

		[Editor(typeof(Editors.HorizonEditor<sourceIdentification>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? productionAgency {
			get {
				return _productionAgency;
			}
			set {
				SetValue(ref _productionAgency, value);
			}
		}

		private String? _sourceID  = default;

		[Editor(typeof(Editors.HorizonEditor<sourceIdentification>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String? sourceID {
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
	public partial class horizontalPositionUncertaintyViewModel : ComplexViewModel<horizontalPositionUncertainty> {
		private double? _uncertaintyFixed  = default;

		[Editor(typeof(Editors.HorizonEditor<horizontalPositionUncertainty>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? uncertaintyFixed {
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
	/// Describes the characteristics of a light sector.
	/// </summary>
	[CategoryOrder("sectorCharacteristics",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorCharacteristicsViewModel : ComplexViewModel<sectorCharacteristics> {
		[Optional]
		public ObservableCollection<signalSequenceViewModel> signalSequence  { get; set; } = new ();

		private double? _signalPeriod  = default;

		[Editor(typeof(Editors.HorizonEditor<sectorCharacteristics>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? signalPeriod {
			get {
				return _signalPeriod;
			}
			set {
				SetValue(ref _signalPeriod, value);
			}
		}

		[Multiplicity(1)]
		public ObservableCollection<lightSectorViewModel> lightSector  { get; set; } = new ();

		private lightCharacteristic? _lightCharacteristic  = default;

		[Editor(typeof(Editors.HorizonEditor<sectorCharacteristics>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public lightCharacteristic? lightCharacteristic {
			get {
				return _lightCharacteristic;
			}
			set {
				SetValue(ref _lightCharacteristic, value);
			}
		}

		[Browsable(false)]
		public lightCharacteristic[] lightCharacteristicList => [(lightCharacteristic)1,(lightCharacteristic)2,(lightCharacteristic)3,(lightCharacteristic)4,(lightCharacteristic)5,(lightCharacteristic)6,(lightCharacteristic)7,(lightCharacteristic)8,(lightCharacteristic)11,(lightCharacteristic)12,(lightCharacteristic)13,(lightCharacteristic)14,(lightCharacteristic)15,(lightCharacteristic)16,(lightCharacteristic)17,(lightCharacteristic)18,(lightCharacteristic)19,(lightCharacteristic)25,(lightCharacteristic)26,(lightCharacteristic)27,(lightCharacteristic)28,(lightCharacteristic)29];

		[Optional]
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
	public partial class orientationViewModel : ComplexViewModel<orientation> {
		private double? _orientationValue  = default;

		[Editor(typeof(Editors.HorizonEditor<orientation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? orientationValue {
			get {
				return _orientationValue;
			}
			set {
				SetValue(ref _orientationValue, value);
			}
		}

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
	public partial class directionHeadingViewModel : ComplexViewModel<directionHeading> {
		private double? _headingDownBearing  = default;

		[Editor(typeof(Editors.HorizonEditor<directionHeading>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? headingDownBearing {
			get {
				return _headingDownBearing;
			}
			set {
				SetValue(ref _headingDownBearing, value);
			}
		}

		private double? _headingUpBearing  = default;

		[Editor(typeof(Editors.HorizonEditor<directionHeading>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? headingUpBearing {
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
	public partial class flightLevelViewModel : ComplexViewModel<flightLevel> {
		private int? _minimumFlightLevel  = default;

		[Editor(typeof(Editors.HorizonEditor<flightLevel>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int? minimumFlightLevel {
			get {
				return _minimumFlightLevel;
			}
			set {
				SetValue(ref _minimumFlightLevel, value);
			}
		}

		private int? _maximumFlightLevel  = default;

		[Editor(typeof(Editors.HorizonEditor<flightLevel>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int? maximumFlightLevel {
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
	public partial class vesselSpeedLimitViewModel : ComplexViewModel<vesselSpeedLimit> {
		private speedUnits? _speedUnits  = default;

		[Editor(typeof(Editors.HorizonEditor<vesselSpeedLimit>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public speedUnits? speedUnits {
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

		[Editor(typeof(Editors.HorizonEditor<vesselSpeedLimit>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? vesselClass {
			get {
				return _vesselClass;
			}
			set {
				SetValue(ref _vesselClass, value);
			}
		}

		private double? _speedLimit  = default;

		[Editor(typeof(Editors.HorizonEditor<vesselSpeedLimit>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? speedLimit {
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
	public partial class periodicDateRangeViewModel : ComplexViewModel<periodicDateRange> {
		private String? _dateStart  = default;

		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Mandatory]
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
		[Mandatory]
		public String? dateEnd {
			get {
				return _dateEnd;
			}
			set {
				SetValue(ref _dateEnd, value);
			}
		}

		private String? _periodicDateEnd  = default;

		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Mandatory]
		public String? periodicDateEnd {
			get {
				return _periodicDateEnd;
			}
			set {
				SetValue(ref _periodicDateEnd, value);
			}
		}

		private String? _periodicDateStart  = default;

		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Mandatory]
		public String? periodicDateStart {
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
	public partial class shapeInformationViewModel : ComplexViewModel<shapeInformation> {
		private String? _text  = default;

		[Editor(typeof(Editors.HorizonEditor<shapeInformation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String? text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
			}
		}

		private String? _language  = default;

		[Editor(typeof(Editors.HorizonEditor<shapeInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
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
	public partial class lightSectorViewModel : ComplexViewModel<lightSector> {
		private sectorLimitViewModel? _sectorLimit  = default;

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

		[Optional]
		public ObservableCollection<sectorInformationViewModel> sectorInformation  { get; set; } = new ();

		[Optional]
		public ObservableCollection<lightVisibility> lightVisibility  { get; set; } = new ();

		[Browsable(false)]
		public lightVisibility[] lightVisibilityList => [(lightVisibility)1,(lightVisibility)2,(lightVisibility)3,(lightVisibility)4,(lightVisibility)5,(lightVisibility)6,(lightVisibility)8,(lightVisibility)9];

		private double? _valueOfNominalRange  = default;

		[Editor(typeof(Editors.HorizonEditor<lightSector>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? valueOfNominalRange {
			get {
				return _valueOfNominalRange;
			}
			set {
				SetValue(ref _valueOfNominalRange, value);
			}
		}

		private Boolean? _sectorArcExtension  = default;

		[Editor(typeof(Editors.HorizonEditor<lightSector>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? sectorArcExtension {
			get {
				return _sectorArcExtension;
			}
			set {
				SetValue(ref _sectorArcExtension, value);
			}
		}

		private directionalCharacterViewModel? _directionalCharacter  = default;

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

		[Multiplicity(1)]
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
	public partial class signalSequenceViewModel : ComplexViewModel<signalSequence> {
		private signalStatus? _signalStatus  = default;

		[Editor(typeof(Editors.HorizonEditor<signalSequence>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public signalStatus? signalStatus {
			get {
				return _signalStatus;
			}
			set {
				SetValue(ref _signalStatus, value);
			}
		}

		[Browsable(false)]
		public signalStatus[] signalStatusList => [(signalStatus)1,(signalStatus)2];

		private double? _signalDuration  = default;

		[Editor(typeof(Editors.HorizonEditor<signalSequence>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? signalDuration {
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
	public partial class sectorInformationViewModel : ComplexViewModel<sectorInformation> {
		private String? _text  = default;

		[Editor(typeof(Editors.HorizonEditor<sectorInformation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String? text {
			get {
				return _text;
			}
			set {
				SetValue(ref _text, value);
			}
		}

		private String? _language  = default;

		[Editor(typeof(Editors.HorizonEditor<sectorInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
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
	public partial class directionalCharacterViewModel : ComplexViewModel<directionalCharacter> {
		private orientationViewModel? _orientation  = default;

		[ExpandableObject]
		[Mandatory]
		public orientationViewModel? orientation {
			get {
				return _orientation;
			}
			set {
				SetValue(ref _orientation, value);
			}
		}

		private Boolean? _moireEffect  = default;

		[Editor(typeof(Editors.HorizonEditor<directionalCharacter>), typeof(Editors.HorizonEditor))]
		[Optional]
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
	public partial class sectorLimitViewModel : ComplexViewModel<sectorLimit> {
		private sectorLimitOneViewModel? _sectorLimitOne  = default;

		[ExpandableObject]
		[Mandatory]
		public sectorLimitOneViewModel? sectorLimitOne {
			get {
				return _sectorLimitOne;
			}
			set {
				SetValue(ref _sectorLimitOne, value);
			}
		}

		private sectorLimitTwoViewModel? _sectorLimitTwo  = default;

		[ExpandableObject]
		[Mandatory]
		public sectorLimitTwoViewModel? sectorLimitTwo {
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
	public partial class sectorLimitTwoViewModel : ComplexViewModel<sectorLimitTwo> {
		private double? _sectorLineLength  = default;

		[Editor(typeof(Editors.HorizonEditor<sectorLimitTwo>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? sectorLineLength {
			get {
				return _sectorLineLength;
			}
			set {
				SetValue(ref _sectorLineLength, value);
			}
		}

		private double? _sectorBearing  = default;

		[Editor(typeof(Editors.HorizonEditor<sectorLimitTwo>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? sectorBearing {
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
	public partial class sectorLimitOneViewModel : ComplexViewModel<sectorLimitOne> {
		private double? _sectorLineLength  = default;

		[Editor(typeof(Editors.HorizonEditor<sectorLimitOne>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? sectorLineLength {
			get {
				return _sectorLineLength;
			}
			set {
				SetValue(ref _sectorLineLength, value);
			}
		}

		private double? _sectorBearing  = default;

		[Editor(typeof(Editors.HorizonEditor<sectorLimitOne>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? sectorBearing {
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
		private String? _editionDate  = default;

		[Category("ReferenceToAPublication")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? editionDate {
			get {
				return _editionDate;
			}
			set {
				SetValue(ref _editionDate, value);
			}
		}

		private String? _editionNumber  = default;

		[Category("ReferenceToAPublication")]
		[Editor(typeof(Editors.HorizonEditor<ReferenceToAPublication>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? editionNumber {
			get {
				return _editionNumber;
			}
			set {
				SetValue(ref _editionNumber, value);
			}
		}

		[Category("ReferenceToAPublication")]
		[Optional]
		public ObservableCollection<onlineResourceViewModel> onlineResource  { get; set; } = new ();

		[Category("ReferenceToAPublication")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		public ReferenceToAPublicationViewModel Load(ReferenceToAPublication instance) {
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

		public ReferenceToAPublicationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private colourPattern? _colourPattern  = default;

		[Category("InstallationBuoy")]
		[Editor(typeof(Editors.HorizonEditor<InstallationBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<product> product  { get; set; } = new ();

		[Browsable(false)]
		public product[] productList => [(product)1,(product)2,(product)18,(product)19];

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("InstallationBuoy")]
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

		[Category("InstallationBuoy")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)18];

		private visualProminence? _visualProminence  = default;

		[Category("InstallationBuoy")]
		[Editor(typeof(Editors.HorizonEditor<InstallationBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("InstallationBuoy")]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		private int? _scaleMinimum  = default;

		[Category("InstallationBuoy")]
		[Editor(typeof(Editors.HorizonEditor<InstallationBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("InstallationBuoy")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _pictorialRepresentation  = default;

		[Category("InstallationBuoy")]
		[Editor(typeof(Editors.HorizonEditor<InstallationBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private buoyShape? _buoyShape  = default;

		[Category("InstallationBuoy")]
		[Editor(typeof(Editors.HorizonEditor<InstallationBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public buoyShape? buoyShape {
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
		[Editor(typeof(Editors.HorizonEditor<InstallationBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("InstallationBuoy")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)7,(natureOfConstruction)11];

		private Boolean? _radarConspicuous  = default;

		[Category("InstallationBuoy")]
		[Editor(typeof(Editors.HorizonEditor<InstallationBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<InstallationBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public InstallationBuoyViewModel Load(InstallationBuoy instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InstallationBuoy._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => InstallationBuoy._featureBindingDefinitions;

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
		private double? _depthRangeMaximumValue  = default;

		[Category("DepthArea")]
		[Editor(typeof(Editors.HorizonEditor<DepthArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? depthRangeMaximumValue {
			get {
				return _depthRangeMaximumValue;
			}
			set {
				SetValue(ref _depthRangeMaximumValue, value);
			}
		}

		private String? _interoperabilityIdentifier  = default;

		[Category("DepthArea")]
		[Editor(typeof(Editors.HorizonEditor<DepthArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("DepthArea")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private double? _depthRangeMinimumValue  = default;

		[Category("DepthArea")]
		[Editor(typeof(Editors.HorizonEditor<DepthArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? depthRangeMinimumValue {
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
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public DepthAreaViewModel Load(DepthArea instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. DepthArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => DepthArea._featureBindingDefinitions;

		public DepthAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public DepthAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Editor(typeof(Editors.HorizonEditor<RadioCallingInPoint>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("RadioCallingInPoint")]
		[Editor(typeof(Editors.HorizonEditor<RadioCallingInPoint>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("RadioCallingInPoint")]
		[Optional]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();

		[Category("RadioCallingInPoint")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _interoperabilityIdentifier  = default;

		[Category("RadioCallingInPoint")]
		[Editor(typeof(Editors.HorizonEditor<RadioCallingInPoint>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("RadioCallingInPoint")]
		[Multiplicity(0, 2)]
		public ObservableCollection<double> orientationValue  { get; set; } = new ();

		[Category("RadioCallingInPoint")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)3,(status)4,(status)5,(status)6,(status)7,(status)9,(status)501];

		[Category("RadioCallingInPoint")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("RadioCallingInPoint")]
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

		private trafficFlow? _trafficFlow  = default;

		[Category("RadioCallingInPoint")]
		[Editor(typeof(Editors.HorizonEditor<RadioCallingInPoint>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public trafficFlow? trafficFlow {
			get {
				return _trafficFlow;
			}
			set {
				SetValue(ref _trafficFlow, value);
			}
		}

		[Browsable(false)]
		public trafficFlow[] trafficFlowList => [(trafficFlow)1,(trafficFlow)2,(trafficFlow)3,(trafficFlow)4];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public RadioCallingInPointViewModel Load(RadioCallingInPoint instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RadioCallingInPoint._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RadioCallingInPoint._featureBindingDefinitions;

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
		[Editor(typeof(Editors.HorizonEditor<PatrolArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("PatrolArea")]
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

		private String? _nationality  = default;

		[Category("PatrolArea")]
		[Editor(typeof(Editors.HorizonEditor<PatrolArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<PatrolArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? controllingAuthority {
			get {
				return _controllingAuthority;
			}
			set {
				SetValue(ref _controllingAuthority, value);
			}
		}

		private categoryOfPatrolArea? _categoryOfPatrolArea  = default;

		[Category("PatrolArea")]
		[Editor(typeof(Editors.HorizonEditor<PatrolArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public categoryOfPatrolArea? categoryOfPatrolArea {
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
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		[Category("PatrolArea")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Category("PatrolArea")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("PatrolArea")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)501];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public PatrolAreaViewModel Load(PatrolArea instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. PatrolArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => PatrolArea._featureBindingDefinitions;

		public PatrolAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public PatrolAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Editor(typeof(Editors.HorizonEditor<Checkpoint>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? controllingAuthority {
			get {
				return _controllingAuthority;
			}
			set {
				SetValue(ref _controllingAuthority, value);
			}
		}

		[Category("Checkpoint")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _agencyResponsibleForProduction  = default;

		[Category("Checkpoint")]
		[Editor(typeof(Editors.HorizonEditor<Checkpoint>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}

		[Category("Checkpoint")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)5,(status)7,(status)9,(status)12];

		[Category("Checkpoint")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private String? _interoperabilityIdentifier  = default;

		[Category("Checkpoint")]
		[Editor(typeof(Editors.HorizonEditor<Checkpoint>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Checkpoint>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Checkpoint>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public CheckpointViewModel Load(Checkpoint instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Checkpoint._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Checkpoint._featureBindingDefinitions;

		public CheckpointViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public CheckpointViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Editor(typeof(Editors.HorizonEditor<MarineManagementArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		[Category("MarineManagementArea")]
		[Optional]
		public ObservableCollection<speciesGrouping> speciesGrouping  { get; set; } = new ();

		[Browsable(false)]
		public speciesGrouping[] speciesGroupingList => [(speciesGrouping)501,(speciesGrouping)502,(speciesGrouping)503,(speciesGrouping)504,(speciesGrouping)505,(speciesGrouping)506,(speciesGrouping)507,(speciesGrouping)508,(speciesGrouping)509,(speciesGrouping)510];

		[Category("MarineManagementArea")]
		[Multiplicity(1)]
		public ObservableCollection<String> nationalMaritimeAuthority  { get; set; } = new ();

		private jurisdiction? _jurisdiction  = default;

		[Category("MarineManagementArea")]
		[Editor(typeof(Editors.HorizonEditor<MarineManagementArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public jurisdiction? jurisdiction {
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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private categoryofMarineProtectedArea? _categoryofMarineProtectedArea  = default;

		[Category("MarineManagementArea")]
		[Editor(typeof(Editors.HorizonEditor<MarineManagementArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private String? _reportedDate  = default;

		[Category("MarineManagementArea")]
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

		private String? _agencyResponsibleForProduction  = default;

		[Category("MarineManagementArea")]
		[Editor(typeof(Editors.HorizonEditor<MarineManagementArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}

		[Category("MarineManagementArea")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _controllingAuthority  = default;

		[Category("MarineManagementArea")]
		[Editor(typeof(Editors.HorizonEditor<MarineManagementArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<MarineManagementArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<MarineManagementArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<categoryofRestrictions> categoryofRestrictions  { get; set; } = new ();

		[Browsable(false)]
		public categoryofRestrictions[] categoryofRestrictionsList => [(categoryofRestrictions)4,(categoryofRestrictions)5,(categoryofRestrictions)6,(categoryofRestrictions)7,(categoryofRestrictions)10,(categoryofRestrictions)20,(categoryofRestrictions)22,(categoryofRestrictions)23,(categoryofRestrictions)27,(categoryofRestrictions)28,(categoryofRestrictions)31,(categoryofRestrictions)32];

		[Category("MarineManagementArea")]
		[Optional]
		public ObservableCollection<String> species  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public MarineManagementAreaViewModel Load(MarineManagementArea instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. MarineManagementArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => MarineManagementArea._featureBindingDefinitions;

		public MarineManagementAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public MarineManagementAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Category("DepthContour")]
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

		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("DepthContour")]
		[ExpandableObject]
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		private double? _valueOfDepthContour  = default;

		[Category("DepthContour")]
		[Editor(typeof(Editors.HorizonEditor<DepthContour>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? valueOfDepthContour {
			get {
				return _valueOfDepthContour;
			}
			set {
				SetValue(ref _valueOfDepthContour, value);
			}
		}

		private String? _agencyResponsibleForProduction  = default;

		[Category("DepthContour")]
		[Editor(typeof(Editors.HorizonEditor<DepthContour>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<DepthContour>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<DepthContour>), typeof(Editors.HorizonEditor))]
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

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public DepthContourViewModel Load(DepthContour instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. DepthContour._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => DepthContour._featureBindingDefinitions;

		public DepthContourViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public DepthContourViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _controllingAuthority  = default;

		[Category("EnvironmentallySensitiveSeaArea")]
		[Editor(typeof(Editors.HorizonEditor<EnvironmentallySensitiveSeaArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? controllingAuthority {
			get {
				return _controllingAuthority;
			}
			set {
				SetValue(ref _controllingAuthority, value);
			}
		}

		[Category("EnvironmentallySensitiveSeaArea")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public EnvironmentallySensitiveSeaAreaViewModel Load(EnvironmentallySensitiveSeaArea instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. EnvironmentallySensitiveSeaArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => EnvironmentallySensitiveSeaArea._featureBindingDefinitions;

		public EnvironmentallySensitiveSeaAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public EnvironmentallySensitiveSeaAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)4,(natureOfConstruction)5];

		[Category("Road")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _pictorialRepresentation  = default;

		[Category("Road")]
		[Editor(typeof(Editors.HorizonEditor<Road>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("Road")]
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

		private categoryOfRoad? _categoryOfRoad  = default;

		[Category("Road")]
		[Editor(typeof(Editors.HorizonEditor<Road>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Road>), typeof(Editors.HorizonEditor))]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)5,(condition)501];

		private String? _interoperabilityIdentifier  = default;

		[Category("Road")]
		[Editor(typeof(Editors.HorizonEditor<Road>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("Road")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("Road")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)4,(status)6,(status)7,(status)8,(status)12,(status)13,(status)14];

		private int? _scaleMinimum  = default;

		[Category("Road")]
		[Editor(typeof(Editors.HorizonEditor<Road>), typeof(Editors.HorizonEditor))]
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

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public RoadViewModel Load(Road instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Road._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Road._featureBindingDefinitions;

		public RoadViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public RoadViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Editor(typeof(Editors.HorizonEditor<River>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("River")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Category("River")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)5];

		private String? _interoperabilityIdentifier  = default;

		[Category("River")]
		[Editor(typeof(Editors.HorizonEditor<River>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("River")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public RiverViewModel Load(River instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. River._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => River._featureBindingDefinitions;

		public RiverViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public RiverViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public altitudeRangeViewModel? altitudeRange {
			get {
				return _altitudeRange;
			}
			set {
				SetValue(ref _altitudeRange, value);
			}
		}

		private String? _depthRestriction  = default;

		[Category("MilitaryPracticeArea")]
		[Editor(typeof(Editors.HorizonEditor<MilitaryPracticeArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String? depthRestriction {
			get {
				return _depthRestriction;
			}
			set {
				SetValue(ref _depthRestriction, value);
			}
		}

		private depthUnits? _depthUnits  = default;

		[Category("MilitaryPracticeArea")]
		[Editor(typeof(Editors.HorizonEditor<MilitaryPracticeArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _nationality  = default;

		[Category("MilitaryPracticeArea")]
		[Editor(typeof(Editors.HorizonEditor<MilitaryPracticeArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}

		[Category("MilitaryPracticeArea")]
		[Optional]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)7,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)15,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)26,(restriction)27,(restriction)39];

		private int? _scaleMinimum  = default;

		[Category("MilitaryPracticeArea")]
		[Editor(typeof(Editors.HorizonEditor<MilitaryPracticeArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("MilitaryPracticeArea")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("MilitaryPracticeArea")]
		[Optional]
		public ObservableCollection<typeofMilitaryActivity> typeofMilitaryActivity  { get; set; } = new ();

		[Browsable(false)]
		public typeofMilitaryActivity[] typeofMilitaryActivityList => [(typeofMilitaryActivity)501,(typeofMilitaryActivity)502,(typeofMilitaryActivity)503,(typeofMilitaryActivity)504,(typeofMilitaryActivity)505,(typeofMilitaryActivity)506,(typeofMilitaryActivity)507,(typeofMilitaryActivity)508,(typeofMilitaryActivity)509,(typeofMilitaryActivity)510,(typeofMilitaryActivity)511,(typeofMilitaryActivity)512,(typeofMilitaryActivity)513,(typeofMilitaryActivity)514,(typeofMilitaryActivity)515,(typeofMilitaryActivity)516,(typeofMilitaryActivity)517,(typeofMilitaryActivity)518,(typeofMilitaryActivity)519,(typeofMilitaryActivity)520,(typeofMilitaryActivity)521,(typeofMilitaryActivity)522,(typeofMilitaryActivity)523,(typeofMilitaryActivity)524,(typeofMilitaryActivity)525,(typeofMilitaryActivity)526,(typeofMilitaryActivity)527,(typeofMilitaryActivity)528,(typeofMilitaryActivity)529,(typeofMilitaryActivity)530,(typeofMilitaryActivity)531,(typeofMilitaryActivity)532,(typeofMilitaryActivity)533,(typeofMilitaryActivity)534,(typeofMilitaryActivity)535,(typeofMilitaryActivity)536,(typeofMilitaryActivity)537,(typeofMilitaryActivity)538,(typeofMilitaryActivity)539,(typeofMilitaryActivity)540,(typeofMilitaryActivity)541,(typeofMilitaryActivity)542,(typeofMilitaryActivity)543,(typeofMilitaryActivity)544,(typeofMilitaryActivity)545,(typeofMilitaryActivity)546,(typeofMilitaryActivity)547,(typeofMilitaryActivity)598,(typeofMilitaryActivity)599];

		private String? _activePeriod  = default;

		[Category("MilitaryPracticeArea")]
		[Editor(typeof(Editors.HorizonEditor<MilitaryPracticeArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? activePeriod {
			get {
				return _activePeriod;
			}
			set {
				SetValue(ref _activePeriod, value);
			}
		}

		[Category("MilitaryPracticeArea")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _minimumSafeDepth  = default;

		[Category("MilitaryPracticeArea")]
		[Editor(typeof(Editors.HorizonEditor<MilitaryPracticeArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? minimumSafeDepth {
			get {
				return _minimumSafeDepth;
			}
			set {
				SetValue(ref _minimumSafeDepth, value);
			}
		}

		[Category("MilitaryPracticeArea")]
		[Optional]
		public ObservableCollection<categoryofMilitaryPracticeArea> categoryofMilitaryPracticeArea  { get; set; } = new ();

		[Browsable(false)]
		public categoryofMilitaryPracticeArea[] categoryofMilitaryPracticeAreaList => [(categoryofMilitaryPracticeArea)2,(categoryofMilitaryPracticeArea)3,(categoryofMilitaryPracticeArea)4,(categoryofMilitaryPracticeArea)5,(categoryofMilitaryPracticeArea)501,(categoryofMilitaryPracticeArea)502,(categoryofMilitaryPracticeArea)503,(categoryofMilitaryPracticeArea)506,(categoryofMilitaryPracticeArea)507,(categoryofMilitaryPracticeArea)508,(categoryofMilitaryPracticeArea)510,(categoryofMilitaryPracticeArea)599];

		private int? _bottomVerticalSafetySeparation  = default;

		[Category("MilitaryPracticeArea")]
		[Editor(typeof(Editors.HorizonEditor<MilitaryPracticeArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<MilitaryPracticeArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<MilitaryPracticeArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<MilitaryPracticeArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<MilitaryPracticeArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("MilitaryPracticeArea")]
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

		[Category("MilitaryPracticeArea")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)5,(status)6,(status)7,(status)16,(status)17,(status)501,(status)503,(status)517,(status)520];

		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("MilitaryPracticeArea")]
		[ExpandableObject]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<MilitaryPracticeArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? controllingAuthority {
			get {
				return _controllingAuthority;
			}
			set {
				SetValue(ref _controllingAuthority, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public MilitaryPracticeAreaViewModel Load(MilitaryPracticeArea instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. MilitaryPracticeArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => MilitaryPracticeArea._featureBindingDefinitions;

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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("DiscolouredWater")]
		[Editor(typeof(Editors.HorizonEditor<DiscolouredWater>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("DiscolouredWater")]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public DiscolouredWaterViewModel Load(DiscolouredWater instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. DiscolouredWater._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => DiscolouredWater._featureBindingDefinitions;

		public DiscolouredWaterViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public DiscolouredWaterViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		private categoryOfCardinalMark? _categoryOfCardinalMark  = default;

		[Category("CardinalBuoy")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public categoryOfCardinalMark? categoryOfCardinalMark {
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
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		[Category("CardinalBuoy")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("CardinalBuoy")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("CardinalBuoy")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)11];

		private buoyShape? _buoyShape  = default;

		[Category("CardinalBuoy")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public buoyShape? buoyShape {
			get {
				return _buoyShape;
			}
			set {
				SetValue(ref _buoyShape, value);
			}
		}

		[Browsable(false)]
		public buoyShape[] buoyShapeList => [(buoyShape)1,(buoyShape)2,(buoyShape)3,(buoyShape)4,(buoyShape)5,(buoyShape)6,(buoyShape)7,(buoyShape)8];

		private double? _verticalLength  = default;

		[Category("CardinalBuoy")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private String? _interoperabilityIdentifier  = default;

		[Category("CardinalBuoy")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("CardinalBuoy")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)5,(status)7,(status)8,(status)18];

		private Boolean? _radarConspicuous  = default;

		[Category("CardinalBuoy")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("CardinalBuoy")]
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

		[Category("CardinalBuoy")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("CardinalBuoy")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		private colourPattern? _colourPattern  = default;

		[Category("CardinalBuoy")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
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
		[Optional]
		public topmarkViewModel? topmark {
			get {
				return _topmark;
			}
			set {
				SetValue(ref _topmark, value);
			}
		}

		[Category("CardinalBuoy")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private String? _pictorialRepresentation  = default;

		[Category("CardinalBuoy")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public CardinalBuoyViewModel Load(CardinalBuoy instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. CardinalBuoy._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => CardinalBuoy._featureBindingDefinitions;

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
		private buoyShape? _buoyShape  = default;

		[Category("SafeWaterBuoy")]
		[Editor(typeof(Editors.HorizonEditor<SafeWaterBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public buoyShape? buoyShape {
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
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		private double? _verticalLength  = default;

		[Category("SafeWaterBuoy")]
		[Editor(typeof(Editors.HorizonEditor<SafeWaterBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Category("SafeWaterBuoy")]
		[Editor(typeof(Editors.HorizonEditor<SafeWaterBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		[Category("SafeWaterBuoy")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private topmarkViewModel? _topmark  = default;

		[Category("SafeWaterBuoy")]
		[ExpandableObject]
		[Optional]
		public topmarkViewModel? topmark {
			get {
				return _topmark;
			}
			set {
				SetValue(ref _topmark, value);
			}
		}

		[Category("SafeWaterBuoy")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)5,(status)7,(status)8,(status)18];

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("SafeWaterBuoy")]
		[Editor(typeof(Editors.HorizonEditor<SafeWaterBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<SafeWaterBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("SafeWaterBuoy")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)11];

		[Category("SafeWaterBuoy")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _interoperabilityIdentifier  = default;

		[Category("SafeWaterBuoy")]
		[Editor(typeof(Editors.HorizonEditor<SafeWaterBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("SafeWaterBuoy")]
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

		private colourPattern? _colourPattern  = default;

		[Category("SafeWaterBuoy")]
		[Editor(typeof(Editors.HorizonEditor<SafeWaterBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<SafeWaterBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Category("SafeWaterBuoy")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public SafeWaterBuoyViewModel Load(SafeWaterBuoy instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SafeWaterBuoy._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SafeWaterBuoy._featureBindingDefinitions;

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
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("RadioStation")]
		[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("RadioStation")]
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

		[Category("RadioStation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private frequencyPairViewModel? _frequencyPair  = default;

		[Category("RadioStation")]
		[ExpandableObject]
		[Optional]
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? communicationChannel {
			get {
				return _communicationChannel;
			}
			set {
				SetValue(ref _communicationChannel, value);
			}
		}

		[Category("RadioStation")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8];

		[Category("RadioStation")]
		[Optional]
		public ObservableCollection<categoryOfRadioStation> categoryOfRadioStation  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfRadioStation[] categoryOfRadioStationList => [(categoryOfRadioStation)5,(categoryOfRadioStation)10,(categoryOfRadioStation)11,(categoryOfRadioStation)14,(categoryOfRadioStation)19,(categoryOfRadioStation)20];

		[Category("RadioStation")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private double? _estimatedRangeofTransmission  = default;

		[Category("RadioStation")]
		[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? estimatedRangeofTransmission {
			get {
				return _estimatedRangeofTransmission;
			}
			set {
				SetValue(ref _estimatedRangeofTransmission, value);
			}
		}

		private String? _interoperabilityIdentifier  = default;

		[Category("RadioStation")]
		[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public RadioStationViewModel Load(RadioStation instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RadioStation._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RadioStation._featureBindingDefinitions;

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
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Category("MilitaryExerciseAirspace")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private String? _pictorialRepresentation  = default;

		[Category("MilitaryExerciseAirspace")]
		[Editor(typeof(Editors.HorizonEditor<MilitaryExerciseAirspace>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<MilitaryExerciseAirspace>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<MilitaryExerciseAirspace>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<MilitaryExerciseAirspace>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public flightLevelViewModel? flightLevel {
			get {
				return _flightLevel;
			}
			set {
				SetValue(ref _flightLevel, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public MilitaryExerciseAirspaceViewModel Load(MilitaryExerciseAirspace instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. MilitaryExerciseAirspace._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => MilitaryExerciseAirspace._featureBindingDefinitions;

		public MilitaryExerciseAirspaceViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public MilitaryExerciseAirspaceViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<ContiguousZone>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<ContiguousZone>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("ContiguousZone")]
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

		[Category("ContiguousZone")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)502,(status)504,(status)520];

		private Boolean? _inDispute  = default;

		[Category("ContiguousZone")]
		[Editor(typeof(Editors.HorizonEditor<ContiguousZone>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? inDispute {
			get {
				return _inDispute;
			}
			set {
				SetValue(ref _inDispute, value);
			}
		}

		[Category("ContiguousZone")]
		[Multiplicity(1)]
		public ObservableCollection<String> nationality  { get; set; } = new ();

		[Category("ContiguousZone")]
		[Multiplicity(1)]
		public ObservableCollection<String> nationalMaritimeAuthority  { get; set; } = new ();

		[Category("ContiguousZone")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public ContiguousZoneViewModel Load(ContiguousZone instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. ContiguousZone._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => ContiguousZone._featureBindingDefinitions;

		public ContiguousZoneViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public ContiguousZoneViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("NormalBaseline")]
		[Editor(typeof(Editors.HorizonEditor<NormalBaseline>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("NormalBaseline")]
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

		private String? _nationality  = default;

		[Category("NormalBaseline")]
		[Editor(typeof(Editors.HorizonEditor<NormalBaseline>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String? nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}

		private String? _agencyResponsibleForProduction  = default;

		[Category("NormalBaseline")]
		[Editor(typeof(Editors.HorizonEditor<NormalBaseline>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<NormalBaseline>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public NormalBaselineViewModel Load(NormalBaseline instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. NormalBaseline._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => NormalBaseline._featureBindingDefinitions;

		public NormalBaselineViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public NormalBaselineViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("CableArea")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)7,(status)13];

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("CableArea")]
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

		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("CableArea")]
		[ExpandableObject]
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		[Category("CableArea")]
		[Optional]
		public ObservableCollection<vesselSpeedLimitViewModel> vesselSpeedLimit  { get; set; } = new ();

		[Category("CableArea")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _reportedDate  = default;

		[Category("CableArea")]
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

		private int? _scaleMinimum  = default;

		[Category("CableArea")]
		[Editor(typeof(Editors.HorizonEditor<CableArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("CableArea")]
		[Optional]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)7,(restriction)8,(restriction)9,(restriction)11,(restriction)12,(restriction)13,(restriction)14,(restriction)16,(restriction)17,(restriction)18,(restriction)20,(restriction)23,(restriction)24,(restriction)25,(restriction)27,(restriction)39];

		private String? _interoperabilityIdentifier  = default;

		[Category("CableArea")]
		[Editor(typeof(Editors.HorizonEditor<CableArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("CableArea")]
		[Optional]
		public ObservableCollection<categoryOfCable> categoryOfCable  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfCable[] categoryOfCableList => [(categoryOfCable)1,(categoryOfCable)7,(categoryOfCable)10];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public CableAreaViewModel Load(CableArea instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. CableArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => CableArea._featureBindingDefinitions;

		public CableAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public CableAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Editor(typeof(Editors.HorizonEditor<ContinentalShelfArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<ContinentalShelfArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		[Category("ContinentalShelfArea")]
		[Multiplicity(1)]
		public ObservableCollection<String> nationalMaritimeAuthority  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("ContinentalShelfArea")]
		[Editor(typeof(Editors.HorizonEditor<ContinentalShelfArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("ContinentalShelfArea")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Category("ContinentalShelfArea")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("ContinentalShelfArea")]
		[Multiplicity(1)]
		public ObservableCollection<String> nationality  { get; set; } = new ();

		private String? _interoperabilityIdentifier  = default;

		[Category("ContinentalShelfArea")]
		[Editor(typeof(Editors.HorizonEditor<ContinentalShelfArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public ContinentalShelfAreaViewModel Load(ContinentalShelfArea instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. ContinentalShelfArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => ContinentalShelfArea._featureBindingDefinitions;

		public ContinentalShelfAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public ContinentalShelfAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Multiplicity(1)]
		public ObservableCollection<String> nationality  { get; set; } = new ();

		[Category("InternalWaters")]
		[Multiplicity(1)]
		public ObservableCollection<String> nationalMaritimeAuthority  { get; set; } = new ();

		private Boolean? _inDispute  = default;

		[Category("InternalWaters")]
		[Editor(typeof(Editors.HorizonEditor<InternalWaters>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<InternalWaters>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		[Category("InternalWaters")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private Boolean? _lineTypeGeodesic  = default;

		[Category("InternalWaters")]
		[Editor(typeof(Editors.HorizonEditor<InternalWaters>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? lineTypeGeodesic {
			get {
				return _lineTypeGeodesic;
			}
			set {
				SetValue(ref _lineTypeGeodesic, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("InternalWaters")]
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

		private status? _status  = default;

		[Category("InternalWaters")]
		[Editor(typeof(Editors.HorizonEditor<InternalWaters>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public InternalWatersViewModel Load(InternalWaters instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. InternalWaters._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => InternalWaters._featureBindingDefinitions;

		public InternalWatersViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public InternalWatersViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Editor(typeof(Editors.HorizonEditor<AdministrationArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<AdministrationArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? inDispute {
			get {
				return _inDispute;
			}
			set {
				SetValue(ref _inDispute, value);
			}
		}

		private jurisdiction? _jurisdiction  = default;

		[Category("AdministrationArea")]
		[Editor(typeof(Editors.HorizonEditor<AdministrationArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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

		private int? _scaleMinimum  = default;

		[Category("AdministrationArea")]
		[Editor(typeof(Editors.HorizonEditor<AdministrationArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("AdministrationArea")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AdministrationArea")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Category("AdministrationArea")]
		[Optional]
		public ObservableCollection<String> nationality  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public AdministrationAreaViewModel Load(AdministrationArea instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. AdministrationArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => AdministrationArea._featureBindingDefinitions;

		public AdministrationAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public AdministrationAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Editor(typeof(Editors.HorizonEditor<Bollard>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("Bollard")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("Bollard")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("Bollard")]
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

		private String? _reportedDate  = default;

		[Category("Bollard")]
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

		[Category("Bollard")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private String? _pictorialRepresentation  = default;

		[Category("Bollard")]
		[Editor(typeof(Editors.HorizonEditor<Bollard>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Bollard>), typeof(Editors.HorizonEditor))]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)5];

		[Category("Bollard")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)3,(status)4,(status)6,(status)7,(status)8,(status)12,(status)14,(status)18];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public BollardViewModel Load(Bollard instance) {
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
		[Editor(typeof(Editors.HorizonEditor<Dolphin>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private double? _verticalLength  = default;

		[Category("Dolphin")]
		[Editor(typeof(Editors.HorizonEditor<Dolphin>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private colourPattern? _colourPattern  = default;

		[Category("Dolphin")]
		[Editor(typeof(Editors.HorizonEditor<Dolphin>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private categoryOfDolphin? _categoryOfDolphin  = default;

		[Category("Dolphin")]
		[Editor(typeof(Editors.HorizonEditor<Dolphin>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public categoryOfDolphin? categoryOfDolphin {
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
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private visualProminence? _visualProminence  = default;

		[Category("Dolphin")]
		[Editor(typeof(Editors.HorizonEditor<Dolphin>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("Dolphin")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private double? _elevation  = default;

		[Category("Dolphin")]
		[Editor(typeof(Editors.HorizonEditor<Dolphin>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}

		[Category("Dolphin")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)12,(status)14,(status)18];

		[Category("Dolphin")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Category("Dolphin")]
		[Editor(typeof(Editors.HorizonEditor<Dolphin>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("Dolphin")]
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

		private condition? _condition  = default;

		[Category("Dolphin")]
		[Editor(typeof(Editors.HorizonEditor<Dolphin>), typeof(Editors.HorizonEditor))]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)5];

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("Dolphin")]
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

		private int? _scaleMinimum  = default;

		[Category("Dolphin")]
		[Editor(typeof(Editors.HorizonEditor<Dolphin>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private double? _height  = default;

		[Category("Dolphin")]
		[Editor(typeof(Editors.HorizonEditor<Dolphin>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		[Category("Dolphin")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)6,(natureOfConstruction)7];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public DolphinViewModel Load(Dolphin instance) {
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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private String? _interoperabilityIdentifier  = default;

		[Category("RadarRange")]
		[Editor(typeof(Editors.HorizonEditor<RadarRange>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("RadarRange")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("RadarRange")]
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

		private int? _scaleMinimum  = default;

		[Category("RadarRange")]
		[Editor(typeof(Editors.HorizonEditor<RadarRange>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("RadarRange")]
		[Optional]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();

		[Category("RadarRange")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)7];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public RadarRangeViewModel Load(RadarRange instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RadarRange._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RadarRange._featureBindingDefinitions;

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
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBeacon>), typeof(Editors.HorizonEditor))]
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

		[Category("IsolatedDangerBeacon")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _reportedDate  = default;

		[Category("IsolatedDangerBeacon")]
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

		private beaconShape? _beaconShape  = default;

		[Category("IsolatedDangerBeacon")]
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBeacon>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public beaconShape? beaconShape {
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
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Category("IsolatedDangerBeacon")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8];

		[Category("IsolatedDangerBeacon")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)12,(status)18];

		[Category("IsolatedDangerBeacon")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("IsolatedDangerBeacon")]
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private double? _elevation  = default;

		[Category("IsolatedDangerBeacon")]
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}

		private String? _agencyResponsibleForProduction  = default;

		[Category("IsolatedDangerBeacon")]
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private double? _height  = default;

		[Category("IsolatedDangerBeacon")]
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private visualProminence? _visualProminence  = default;

		[Category("IsolatedDangerBeacon")]
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private double? _verticalLength  = default;

		[Category("IsolatedDangerBeacon")]
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		[Category("IsolatedDangerBeacon")]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("IsolatedDangerBeacon")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("IsolatedDangerBeacon")]
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

		private String? _interoperabilityIdentifier  = default;

		[Category("IsolatedDangerBeacon")]
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public IsolatedDangerBeaconViewModel Load(IsolatedDangerBeacon instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. IsolatedDangerBeacon._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => IsolatedDangerBeacon._featureBindingDefinitions;

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
		[Optional]
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
		[Optional]
		public topmarkViewModel? topmark {
			get {
				return _topmark;
			}
			set {
				SetValue(ref _topmark, value);
			}
		}

		[Category("IsolatedDangerBuoy")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private Boolean? _radarConspicuous  = default;

		[Category("IsolatedDangerBuoy")]
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private double? _verticalLength  = default;

		[Category("IsolatedDangerBuoy")]
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		[Category("IsolatedDangerBuoy")]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		private String? _interoperabilityIdentifier  = default;

		[Category("IsolatedDangerBuoy")]
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("IsolatedDangerBuoy")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("IsolatedDangerBuoy")]
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private buoyShape? _buoyShape  = default;

		[Category("IsolatedDangerBuoy")]
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public buoyShape? buoyShape {
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
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private colourPattern? _colourPattern  = default;

		[Category("IsolatedDangerBuoy")]
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<IsolatedDangerBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		[Category("IsolatedDangerBuoy")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)11];

		[Category("IsolatedDangerBuoy")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)5,(status)7,(status)8,(status)18];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public IsolatedDangerBuoyViewModel Load(IsolatedDangerBuoy instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. IsolatedDangerBuoy._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => IsolatedDangerBuoy._featureBindingDefinitions;

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
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _interoperabilityIdentifier  = default;

		[Category("SubmarineTransitLane")]
		[Editor(typeof(Editors.HorizonEditor<SubmarineTransitLane>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<SubmarineTransitLane>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<SubmarineTransitLane>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? bottomVerticalSafetySeparation {
			get {
				return _bottomVerticalSafetySeparation;
			}
			set {
				SetValue(ref _bottomVerticalSafetySeparation, value);
			}
		}

		[Category("SubmarineTransitLane")]
		[Optional]
		public ObservableCollection<vesselSpeedLimitViewModel> vesselSpeedLimit  { get; set; } = new ();

		private String? _controllingAuthority  = default;

		[Category("SubmarineTransitLane")]
		[Editor(typeof(Editors.HorizonEditor<SubmarineTransitLane>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? controllingAuthority {
			get {
				return _controllingAuthority;
			}
			set {
				SetValue(ref _controllingAuthority, value);
			}
		}

		[Category("SubmarineTransitLane")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("SubmarineTransitLane")]
		[Optional]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)7,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)27];

		private String? _agencyResponsibleForProduction  = default;

		[Category("SubmarineTransitLane")]
		[Editor(typeof(Editors.HorizonEditor<SubmarineTransitLane>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<SubmarineTransitLane>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<SubmarineTransitLane>), typeof(Editors.HorizonEditor))]
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

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public SubmarineTransitLaneViewModel Load(SubmarineTransitLane instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SubmarineTransitLane._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SubmarineTransitLane._featureBindingDefinitions;

		public SubmarineTransitLaneViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SubmarineTransitLaneViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		private String? _reportedDate  = default;

		[Category("MaritimeSafetyInformationArea")]
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

		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("MaritimeSafetyInformationArea")]
		[ExpandableObject]
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		[Category("MaritimeSafetyInformationArea")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private String? _agencyResponsibleForProduction  = default;

		[Category("MaritimeSafetyInformationArea")]
		[Editor(typeof(Editors.HorizonEditor<MaritimeSafetyInformationArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}

		[Category("MaritimeSafetyInformationArea")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public MaritimeSafetyInformationAreaViewModel Load(MaritimeSafetyInformationArea instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. MaritimeSafetyInformationArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => MaritimeSafetyInformationArea._featureBindingDefinitions;

		public MaritimeSafetyInformationAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public MaritimeSafetyInformationAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _agencyResponsibleForProduction  = default;

		[Category("AirspaceRestriction")]
		[Editor(typeof(Editors.HorizonEditor<AirspaceRestriction>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<AirspaceRestriction>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public altitudeRangeViewModel? altitudeRange {
			get {
				return _altitudeRange;
			}
			set {
				SetValue(ref _altitudeRange, value);
			}
		}

		[Category("AirspaceRestriction")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private verticalDatum? _verticalDatum  = default;

		[Category("AirspaceRestriction")]
		[Editor(typeof(Editors.HorizonEditor<AirspaceRestriction>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("AirspaceRestriction")]
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

		private heightLengthUnits? _heightLengthUnits  = default;

		[Category("AirspaceRestriction")]
		[Editor(typeof(Editors.HorizonEditor<AirspaceRestriction>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<AirspaceRestriction>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public AirspaceRestrictionViewModel Load(AirspaceRestriction instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. AirspaceRestriction._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => AirspaceRestriction._featureBindingDefinitions;

		public AirspaceRestrictionViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public AirspaceRestrictionViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Editor(typeof(Editors.HorizonEditor<Sounding>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1,(techniqueOfVerticalMeasurement)2,(techniqueOfVerticalMeasurement)3,(techniqueOfVerticalMeasurement)4,(techniqueOfVerticalMeasurement)5,(techniqueOfVerticalMeasurement)8,(techniqueOfVerticalMeasurement)9,(techniqueOfVerticalMeasurement)10,(techniqueOfVerticalMeasurement)11,(techniqueOfVerticalMeasurement)12,(techniqueOfVerticalMeasurement)13,(techniqueOfVerticalMeasurement)15,(techniqueOfVerticalMeasurement)16,(techniqueOfVerticalMeasurement)17,(techniqueOfVerticalMeasurement)18];

		private int? _scaleMinimum  = default;

		[Category("Sounding")]
		[Editor(typeof(Editors.HorizonEditor<Sounding>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("Sounding")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("Sounding")]
		[Optional]
		public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1,(qualityOfVerticalMeasurement)3,(qualityOfVerticalMeasurement)4,(qualityOfVerticalMeasurement)8,(qualityOfVerticalMeasurement)9];

		[Category("Sounding")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("Sounding")]
		[ExpandableObject]
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("Sounding")]
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

		private Boolean? _displayUncertainties  = default;

		[Category("Sounding")]
		[Editor(typeof(Editors.HorizonEditor<Sounding>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? displayUncertainties {
			get {
				return _displayUncertainties;
			}
			set {
				SetValue(ref _displayUncertainties, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public SoundingViewModel Load(Sounding instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Sounding._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Sounding._featureBindingDefinitions;

		public SoundingViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SoundingViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Editor(typeof(Editors.HorizonEditor<TrafficSeparationSchemeBoundary>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("TrafficSeparationSchemeBoundary")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)3,(status)9,(status)28];

		private String? _reportedDate  = default;

		[Category("TrafficSeparationSchemeBoundary")]
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

		[Category("TrafficSeparationSchemeBoundary")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("TrafficSeparationSchemeBoundary")]
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

		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("TrafficSeparationSchemeBoundary")]
		[ExpandableObject]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<TrafficSeparationSchemeBoundary>), typeof(Editors.HorizonEditor))]
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

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public TrafficSeparationSchemeBoundaryViewModel Load(TrafficSeparationSchemeBoundary instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. TrafficSeparationSchemeBoundary._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeBoundary._featureBindingDefinitions;

		public TrafficSeparationSchemeBoundaryViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public TrafficSeparationSchemeBoundaryViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<categoryOfDumpingGround> categoryOfDumpingGround  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfDumpingGround[] categoryOfDumpingGroundList => [(categoryOfDumpingGround)2,(categoryOfDumpingGround)3,(categoryOfDumpingGround)4,(categoryOfDumpingGround)5,(categoryOfDumpingGround)6];

		[Category("DumpingGround")]
		[Optional]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)7,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)27];

		[Category("DumpingGround")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)6,(status)7];

		private int? _scaleMinimum  = default;

		[Category("DumpingGround")]
		[Editor(typeof(Editors.HorizonEditor<DumpingGround>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private String? _dateDisused  = default;

		[Category("DumpingGround")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? dateDisused {
			get {
				return _dateDisused;
			}
			set {
				SetValue(ref _dateDisused, value);
			}
		}

		[Category("DumpingGround")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Category("DumpingGround")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public DumpingGroundViewModel Load(DumpingGround instance) {
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
		[Optional]
		public ObservableCollection<categoryOfAirportAirfield> categoryOfAirportAirfield  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfAirportAirfield[] categoryOfAirportAirfieldList => [(categoryOfAirportAirfield)1,(categoryOfAirportAirfield)2,(categoryOfAirportAirfield)3,(categoryOfAirportAirfield)4,(categoryOfAirportAirfield)5,(categoryOfAirportAirfield)6,(categoryOfAirportAirfield)8,(categoryOfAirportAirfield)9];

		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("AirportAirfield")]
		[ExpandableObject]
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		[Category("AirportAirfield")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private condition? _condition  = default;

		[Category("AirportAirfield")]
		[Editor(typeof(Editors.HorizonEditor<AirportAirfield>), typeof(Editors.HorizonEditor))]
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

		private int? _runwayLength  = default;

		[Category("AirportAirfield")]
		[Editor(typeof(Editors.HorizonEditor<AirportAirfield>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<AirportAirfield>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<AirportAirfield>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<AirportAirfield>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? controllingAuthority {
			get {
				return _controllingAuthority;
			}
			set {
				SetValue(ref _controllingAuthority, value);
			}
		}

		private double? _elevation  = default;

		[Category("AirportAirfield")]
		[Editor(typeof(Editors.HorizonEditor<AirportAirfield>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}

		private verticalDatum? _verticalDatum  = default;

		[Category("AirportAirfield")]
		[Editor(typeof(Editors.HorizonEditor<AirportAirfield>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<AirportAirfield>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<AirportAirfield>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<AirportAirfield>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iCAOcode {
			get {
				return _iCAOcode;
			}
			set {
				SetValue(ref _iCAOcode, value);
			}
		}

		[Category("AirportAirfield")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AirportAirfield")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Category("AirportAirfield")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)6,(status)7,(status)8,(status)12,(status)14];

		private String? _reportedDate  = default;

		[Category("AirportAirfield")]
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

		private String? _interoperabilityIdentifier  = default;

		[Category("AirportAirfield")]
		[Editor(typeof(Editors.HorizonEditor<AirportAirfield>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public AirportAirfieldViewModel Load(AirportAirfield instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. AirportAirfield._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => AirportAirfield._featureBindingDefinitions;

		public AirportAirfieldViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public AirportAirfieldViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)13,(status)18,(status)28];

		private double? _valueOfSounding  = default;

		[Category("FoulGround")]
		[Editor(typeof(Editors.HorizonEditor<FoulGround>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? valueOfSounding {
			get {
				return _valueOfSounding;
			}
			set {
				SetValue(ref _valueOfSounding, value);
			}
		}

		[Category("FoulGround")]
		[Optional]
		public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1,(qualityOfVerticalMeasurement)2,(qualityOfVerticalMeasurement)3,(qualityOfVerticalMeasurement)4,(qualityOfVerticalMeasurement)6,(qualityOfVerticalMeasurement)7,(qualityOfVerticalMeasurement)8,(qualityOfVerticalMeasurement)9];

		[Category("FoulGround")]
		[Optional]
		public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1,(techniqueOfVerticalMeasurement)2,(techniqueOfVerticalMeasurement)3,(techniqueOfVerticalMeasurement)4,(techniqueOfVerticalMeasurement)5,(techniqueOfVerticalMeasurement)8,(techniqueOfVerticalMeasurement)9,(techniqueOfVerticalMeasurement)10,(techniqueOfVerticalMeasurement)11,(techniqueOfVerticalMeasurement)12,(techniqueOfVerticalMeasurement)13,(techniqueOfVerticalMeasurement)15,(techniqueOfVerticalMeasurement)16,(techniqueOfVerticalMeasurement)17,(techniqueOfVerticalMeasurement)18];

		private String? _reportedDate  = default;

		[Category("FoulGround")]
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

		private int? _scaleMinimum  = default;

		[Category("FoulGround")]
		[Editor(typeof(Editors.HorizonEditor<FoulGround>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public verticalUncertaintyViewModel? verticalUncertainty {
			get {
				return _verticalUncertainty;
			}
			set {
				SetValue(ref _verticalUncertainty, value);
			}
		}

		[Category("FoulGround")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Category("FoulGround")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public FoulGroundViewModel Load(FoulGround instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. FoulGround._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FoulGround._featureBindingDefinitions;

		public FoulGroundViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public FoulGroundViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		private String? _pictorialRepresentation  = default;

		[Category("LightAirObstruction")]
		[Editor(typeof(Editors.HorizonEditor<LightAirObstruction>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private double? _valueOfNominalRange  = default;

		[Category("LightAirObstruction")]
		[Editor(typeof(Editors.HorizonEditor<LightAirObstruction>), typeof(Editors.HorizonEditor))]
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

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("LightAirObstruction")]
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

		[Category("LightAirObstruction")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private rythmOfLightViewModel? _rythmOfLight  = default;

		[Category("LightAirObstruction")]
		[ExpandableObject]
		[Optional]
		public rythmOfLightViewModel? rythmOfLight {
			get {
				return _rythmOfLight;
			}
			set {
				SetValue(ref _rythmOfLight, value);
			}
		}

		[Category("LightAirObstruction")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)6,(status)7,(status)8,(status)11,(status)14,(status)15,(status)16,(status)17];

		private int? _scaleMinimum  = default;

		[Category("LightAirObstruction")]
		[Editor(typeof(Editors.HorizonEditor<LightAirObstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LightAirObstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? flareBearing {
			get {
				return _flareBearing;
			}
			set {
				SetValue(ref _flareBearing, value);
			}
		}

		private double? _height  = default;

		[Category("LightAirObstruction")]
		[Editor(typeof(Editors.HorizonEditor<LightAirObstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("LightAirObstruction")]
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

		private heightLengthUnits? _heightLengthUnits  = default;

		[Category("LightAirObstruction")]
		[Editor(typeof(Editors.HorizonEditor<LightAirObstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<lightVisibility> lightVisibility  { get; set; } = new ();

		[Browsable(false)]
		public lightVisibility[] lightVisibilityList => [(lightVisibility)1,(lightVisibility)2,(lightVisibility)3,(lightVisibility)4,(lightVisibility)5,(lightVisibility)6,(lightVisibility)7,(lightVisibility)8,(lightVisibility)9];

		[Category("LightAirObstruction")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private double? _relativeHorizontalAccuracy  = default;

		[Category("LightAirObstruction")]
		[Editor(typeof(Editors.HorizonEditor<LightAirObstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? relativeHorizontalAccuracy {
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LightAirObstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LightAirObstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private double? _relativeVerticalAccuracy  = default;

		[Category("LightAirObstruction")]
		[Editor(typeof(Editors.HorizonEditor<LightAirObstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? relativeVerticalAccuracy {
			get {
				return _relativeVerticalAccuracy;
			}
			set {
				SetValue(ref _relativeVerticalAccuracy, value);
			}
		}

		private exhibitionConditionOfLight? _exhibitionConditionOfLight  = default;

		[Category("LightAirObstruction")]
		[Editor(typeof(Editors.HorizonEditor<LightAirObstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("LightAirObstruction")]
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)3,(colour)4,(colour)5,(colour)6,(colour)9,(colour)10,(colour)11];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public LightAirObstructionViewModel Load(LightAirObstruction instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LightAirObstruction._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LightAirObstruction._featureBindingDefinitions;

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

		[Category("MooringBuoy")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("MooringBuoy")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)11];

		private colourPattern? _colourPattern  = default;

		[Category("MooringBuoy")]
		[Editor(typeof(Editors.HorizonEditor<MooringBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("MooringBuoy")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)18];

		[Category("MooringBuoy")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("MooringBuoy")]
		[Editor(typeof(Editors.HorizonEditor<MooringBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private buoyShape? _buoyShape  = default;

		[Category("MooringBuoy")]
		[Editor(typeof(Editors.HorizonEditor<MooringBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public buoyShape? buoyShape {
			get {
				return _buoyShape;
			}
			set {
				SetValue(ref _buoyShape, value);
			}
		}

		[Browsable(false)]
		public buoyShape[] buoyShapeList => [(buoyShape)1,(buoyShape)2,(buoyShape)3,(buoyShape)4,(buoyShape)5,(buoyShape)6,(buoyShape)7,(buoyShape)8];

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

		private String? _pictorialRepresentation  = default;

		[Category("MooringBuoy")]
		[Editor(typeof(Editors.HorizonEditor<MooringBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private String? _interoperabilityIdentifier  = default;

		[Category("MooringBuoy")]
		[Editor(typeof(Editors.HorizonEditor<MooringBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("MooringBuoy")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("MooringBuoy")]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public MooringBuoyViewModel Load(MooringBuoy instance) {
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
		private double? _valueOfSounding  = default;

		[Category("UnderwaterAwashRock")]
		[Editor(typeof(Editors.HorizonEditor<UnderwaterAwashRock>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? valueOfSounding {
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
		[Optional]
		public verticalUncertaintyViewModel? verticalUncertainty {
			get {
				return _verticalUncertainty;
			}
			set {
				SetValue(ref _verticalUncertainty, value);
			}
		}

		private double? _horizontalWidth  = default;

		[Category("UnderwaterAwashRock")]
		[Editor(typeof(Editors.HorizonEditor<UnderwaterAwashRock>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalWidth {
			get {
				return _horizontalWidth;
			}
			set {
				SetValue(ref _horizontalWidth, value);
			}
		}

		private waterLevelEffect? _waterLevelEffect  = default;

		[Category("UnderwaterAwashRock")]
		[Editor(typeof(Editors.HorizonEditor<UnderwaterAwashRock>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public waterLevelEffect? waterLevelEffect {
			get {
				return _waterLevelEffect;
			}
			set {
				SetValue(ref _waterLevelEffect, value);
			}
		}

		[Browsable(false)]
		public waterLevelEffect[] waterLevelEffectList => [(waterLevelEffect)3,(waterLevelEffect)4,(waterLevelEffect)5];

		private double? _surroundingDepth  = default;

		[Category("UnderwaterAwashRock")]
		[Editor(typeof(Editors.HorizonEditor<UnderwaterAwashRock>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? surroundingDepth {
			get {
				return _surroundingDepth;
			}
			set {
				SetValue(ref _surroundingDepth, value);
			}
		}

		[Category("UnderwaterAwashRock")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private natureOfSurface? _natureOfSurface  = default;

		[Category("UnderwaterAwashRock")]
		[Editor(typeof(Editors.HorizonEditor<UnderwaterAwashRock>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<UnderwaterAwashRock>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<UnderwaterAwashRock>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<UnderwaterAwashRock>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private double? _defaultClearanceDepth  = default;

		[Category("UnderwaterAwashRock")]
		[Editor(typeof(Editors.HorizonEditor<UnderwaterAwashRock>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? defaultClearanceDepth {
			get {
				return _defaultClearanceDepth;
			}
			set {
				SetValue(ref _defaultClearanceDepth, value);
			}
		}

		[Category("UnderwaterAwashRock")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)18];

		[Category("UnderwaterAwashRock")]
		[Optional]
		public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1,(techniqueOfVerticalMeasurement)2,(techniqueOfVerticalMeasurement)3,(techniqueOfVerticalMeasurement)4,(techniqueOfVerticalMeasurement)5,(techniqueOfVerticalMeasurement)8,(techniqueOfVerticalMeasurement)9,(techniqueOfVerticalMeasurement)10,(techniqueOfVerticalMeasurement)11,(techniqueOfVerticalMeasurement)12,(techniqueOfVerticalMeasurement)13,(techniqueOfVerticalMeasurement)15,(techniqueOfVerticalMeasurement)16,(techniqueOfVerticalMeasurement)17,(techniqueOfVerticalMeasurement)18];

		private double? _verticalLength  = default;

		[Category("UnderwaterAwashRock")]
		[Editor(typeof(Editors.HorizonEditor<UnderwaterAwashRock>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		[Category("UnderwaterAwashRock")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private double? _horizontalLength  = default;

		[Category("UnderwaterAwashRock")]
		[Editor(typeof(Editors.HorizonEditor<UnderwaterAwashRock>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalLength {
			get {
				return _horizontalLength;
			}
			set {
				SetValue(ref _horizontalLength, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("UnderwaterAwashRock")]
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

		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("UnderwaterAwashRock")]
		[ExpandableObject]
		[Optional]
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
		[Optional]
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<UnderwaterAwashRock>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public UnderwaterAwashRockViewModel Load(UnderwaterAwashRock instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. UnderwaterAwashRock._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => UnderwaterAwashRock._featureBindingDefinitions;

		public UnderwaterAwashRockViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public UnderwaterAwashRockViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Editor(typeof(Editors.HorizonEditor<CableOverhead>), typeof(Editors.HorizonEditor))]
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
		public condition[] conditionList => [(condition)1,(condition)5];

		[Category("CableOverhead")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)4,(status)5,(status)7,(status)12,(status)28];

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("CableOverhead")]
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

		private verticalDatum? _verticalDatum  = default;

		[Category("CableOverhead")]
		[Editor(typeof(Editors.HorizonEditor<CableOverhead>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<CableOverhead>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public verticalClearanceSafeViewModel? verticalClearanceSafe {
			get {
				return _verticalClearanceSafe;
			}
			set {
				SetValue(ref _verticalClearanceSafe, value);
			}
		}

		[Category("CableOverhead")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _reportedDate  = default;

		[Category("CableOverhead")]
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

		private verticalClearanceFixedViewModel? _verticalClearanceFixed  = default;

		[Category("CableOverhead")]
		[ExpandableObject]
		[Optional]
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<CableOverhead>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("CableOverhead")]
		[Editor(typeof(Editors.HorizonEditor<CableOverhead>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<CableOverhead>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private double? _iceFactor  = default;

		[Category("CableOverhead")]
		[Editor(typeof(Editors.HorizonEditor<CableOverhead>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? iceFactor {
			get {
				return _iceFactor;
			}
			set {
				SetValue(ref _iceFactor, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public CableOverheadViewModel Load(CableOverhead instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. CableOverhead._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => CableOverhead._featureBindingDefinitions;

		public CableOverheadViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public CableOverheadViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Editor(typeof(Editors.HorizonEditor<ControlledAirspace>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("ControlledAirspace")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private categoryOfControlledAirspace? _categoryOfControlledAirspace  = default;

		[Category("ControlledAirspace")]
		[Editor(typeof(Editors.HorizonEditor<ControlledAirspace>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<ControlledAirspace>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<ControlledAirspace>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<ControlledAirspace>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<ControlledAirspace>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("ControlledAirspace")]
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

		private flightLevelViewModel? _flightLevel  = default;

		[Category("ControlledAirspace")]
		[ExpandableObject]
		[Optional]
		public flightLevelViewModel? flightLevel {
			get {
				return _flightLevel;
			}
			set {
				SetValue(ref _flightLevel, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public ControlledAirspaceViewModel Load(ControlledAirspace instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. ControlledAirspace._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => ControlledAirspace._featureBindingDefinitions;

		public ControlledAirspaceViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public ControlledAirspaceViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)11,(natureOfConstruction)12];

		private String? _controllingAuthority  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? controllingAuthority {
			get {
				return _controllingAuthority;
			}
			set {
				SetValue(ref _controllingAuthority, value);
			}
		}

		[Category("Obstruction")]
		[Optional]
		public ObservableCollection<product> product  { get; set; } = new ();

		[Browsable(false)]
		public product[] productList => [(product)1,(product)3,(product)4,(product)5,(product)6,(product)7,(product)8,(product)9,(product)10,(product)11,(product)12,(product)13,(product)14,(product)15,(product)16,(product)17,(product)18,(product)19,(product)20,(product)21,(product)22,(product)23,(product)25,(product)502,(product)503,(product)505,(product)506,(product)507,(product)508,(product)509,(product)510,(product)511,(product)513,(product)514,(product)515,(product)516,(product)517,(product)519,(product)520,(product)521,(product)522,(product)523,(product)524,(product)525,(product)526,(product)527,(product)528,(product)529,(product)530,(product)531,(product)532,(product)533,(product)534,(product)535,(product)536,(product)537,(product)540,(product)541,(product)542];

		private Boolean? _existenceOfRestrictedArea  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? existenceOfRestrictedArea {
			get {
				return _existenceOfRestrictedArea;
			}
			set {
				SetValue(ref _existenceOfRestrictedArea, value);
			}
		}

		private double? _horizontalDistanceUncertainty  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalDistanceUncertainty {
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public firstSourceInformationViewModel? firstSourceInformation {
			get {
				return _firstSourceInformation;
			}
			set {
				SetValue(ref _firstSourceInformation, value);
			}
		}

		private String? _abandonmentDate  = default;

		[Category("Obstruction")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? abandonmentDate {
			get {
				return _abandonmentDate;
			}
			set {
				SetValue(ref _abandonmentDate, value);
			}
		}

		private double? _verticalLength  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private double? _soundingDepth  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? soundingDepth {
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private magneticInformationViewModel? _magneticInformation  = default;

		[Category("Obstruction")]
		[ExpandableObject]
		[Optional]
		public magneticInformationViewModel? magneticInformation {
			get {
				return _magneticInformation;
			}
			set {
				SetValue(ref _magneticInformation, value);
			}
		}

		private double? _horizontalWidth  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalWidth {
			get {
				return _horizontalWidth;
			}
			set {
				SetValue(ref _horizontalWidth, value);
			}
		}

		[Category("Obstruction")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)4,(status)5,(status)7,(status)8,(status)13,(status)18,(status)28,(status)501,(status)503,(status)505,(status)506,(status)507,(status)508,(status)509,(status)510,(status)511,(status)512,(status)516,(status)517,(status)518];

		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Category("Obstruction")]
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

		private condition? _condition  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)5];

		private int? _generalWaterDepth  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? generalWaterDepth {
			get {
				return _generalWaterDepth;
			}
			set {
				SetValue(ref _generalWaterDepth, value);
			}
		}

		[Category("Obstruction")]
		[Optional]
		public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1,(qualityOfVerticalMeasurement)2,(qualityOfVerticalMeasurement)3,(qualityOfVerticalMeasurement)4,(qualityOfVerticalMeasurement)6,(qualityOfVerticalMeasurement)7,(qualityOfVerticalMeasurement)8,(qualityOfVerticalMeasurement)9];

		private detectionDateRangeViewModel? _detectionDateRange  = default;

		[Category("Obstruction")]
		[ExpandableObject]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private double? _height  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private sonarSignalStrength? _sonarSignalStrength  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private double? _maximumPermittedDraught  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? maximumPermittedDraught {
			get {
				return _maximumPermittedDraught;
			}
			set {
				SetValue(ref _maximumPermittedDraught, value);
			}
		}

		[Category("Obstruction")]
		[Optional]
		public ObservableCollection<natureOfSurface> natureOfSurface  { get; set; } = new ();

		[Browsable(false)]
		public natureOfSurface[] natureOfSurfaceList => [(natureOfSurface)1,(natureOfSurface)2,(natureOfSurface)3,(natureOfSurface)4,(natureOfSurface)5,(natureOfSurface)6,(natureOfSurface)7,(natureOfSurface)8,(natureOfSurface)9,(natureOfSurface)11,(natureOfSurface)14,(natureOfSurface)17,(natureOfSurface)18];

		private String? _spuddedDate  = default;

		[Category("Obstruction")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? spuddedDate {
			get {
				return _spuddedDate;
			}
			set {
				SetValue(ref _spuddedDate, value);
			}
		}

		private categoryOfObstruction? _categoryOfObstruction  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private String? _dateSunk  = default;

		[Category("Obstruction")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? dateSunk {
			get {
				return _dateSunk;
			}
			set {
				SetValue(ref _dateSunk, value);
			}
		}

		private double? _horizontalLength  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalLength {
			get {
				return _horizontalLength;
			}
			set {
				SetValue(ref _horizontalLength, value);
			}
		}

		[Category("Obstruction")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("Obstruction")]
		[ExpandableObject]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? currentScourDimensions {
			get {
				return _currentScourDimensions;
			}
			set {
				SetValue(ref _currentScourDimensions, value);
			}
		}

		[Category("Obstruction")]
		[Optional]
		public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1,(techniqueOfVerticalMeasurement)2,(techniqueOfVerticalMeasurement)3,(techniqueOfVerticalMeasurement)4,(techniqueOfVerticalMeasurement)5,(techniqueOfVerticalMeasurement)8,(techniqueOfVerticalMeasurement)9,(techniqueOfVerticalMeasurement)10,(techniqueOfVerticalMeasurement)11,(techniqueOfVerticalMeasurement)12,(techniqueOfVerticalMeasurement)13,(techniqueOfVerticalMeasurement)15,(techniqueOfVerticalMeasurement)16,(techniqueOfVerticalMeasurement)17,(techniqueOfVerticalMeasurement)18];

		private String? _reportedDate  = default;

		[Category("Obstruction")]
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

		private cardinalPointOrientation? _cardinalPointOrientation  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private double? _valueOfSounding  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? valueOfSounding {
			get {
				return _valueOfSounding;
			}
			set {
				SetValue(ref _valueOfSounding, value);
			}
		}

		private waterLevelEffect? _waterLevelEffect  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public waterLevelEffect? waterLevelEffect {
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
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? nation {
			get {
				return _nation;
			}
			set {
				SetValue(ref _nation, value);
			}
		}

		private double? _defaultClearanceDepth  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? defaultClearanceDepth {
			get {
				return _defaultClearanceDepth;
			}
			set {
				SetValue(ref _defaultClearanceDepth, value);
			}
		}

		private Boolean? _displayUncertainties  = default;

		[Category("Obstruction")]
		[Editor(typeof(Editors.HorizonEditor<Obstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? displayUncertainties {
			get {
				return _displayUncertainties;
			}
			set {
				SetValue(ref _displayUncertainties, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public ObstructionViewModel Load(Obstruction instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Obstruction._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Obstruction._featureBindingDefinitions;

		public ObstructionViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public ObstructionViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)5,(status)6,(status)7,(status)8,(status)14,(status)16,(status)17,(status)28];

		private String? _reportedDate  = default;

		[Category("FishingGround")]
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

		private String? _interoperabilityIdentifier  = default;

		[Category("FishingGround")]
		[Editor(typeof(Editors.HorizonEditor<FishingGround>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("FishingGround")]
		[Optional]
		public ObservableCollection<vesselSpeedLimitViewModel> vesselSpeedLimit  { get; set; } = new ();

		[Category("FishingGround")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("FishingGround")]
		[ExpandableObject]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<FishingGround>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("FishingGround")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Category("FishingGround")]
		[Optional]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)4,(restriction)5,(restriction)6,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)15,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)26,(restriction)27,(restriction)39];

		[Category("FishingGround")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public FishingGroundViewModel Load(FishingGround instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. FishingGround._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FishingGround._featureBindingDefinitions;

		public FishingGroundViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public FishingGroundViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("FishingFacility")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private condition? _condition  = default;

		[Category("FishingFacility")]
		[Editor(typeof(Editors.HorizonEditor<FishingFacility>), typeof(Editors.HorizonEditor))]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)5];

		private String? _interoperabilityIdentifier  = default;

		[Category("FishingFacility")]
		[Editor(typeof(Editors.HorizonEditor<FishingFacility>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		private double? _verticalLength  = default;

		[Category("FishingFacility")]
		[Editor(typeof(Editors.HorizonEditor<FishingFacility>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		[Category("FishingFacility")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)4,(status)5,(status)6,(status)7,(status)8,(status)12,(status)18,(status)28];

		private categoryOfFishingFacility? _categoryOfFishingFacility  = default;

		[Category("FishingFacility")]
		[Editor(typeof(Editors.HorizonEditor<FishingFacility>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<FishingFacility>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("FishingFacility")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _reportedDate  = default;

		[Category("FishingFacility")]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public FishingFacilityViewModel Load(FishingFacility instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. FishingFacility._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FishingFacility._featureBindingDefinitions;

		public FishingFacilityViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public FishingFacilityViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		[Category("NavigationSystem")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private String? _agencyResponsibleForProduction  = default;

		[Category("NavigationSystem")]
		[Editor(typeof(Editors.HorizonEditor<NavigationSystem>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<NavigationSystem>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private String? _reportedDate  = default;

		[Category("NavigationSystem")]
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

		private String? _callsign  = default;

		[Category("NavigationSystem")]
		[Editor(typeof(Editors.HorizonEditor<NavigationSystem>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? callsign {
			get {
				return _callsign;
			}
			set {
				SetValue(ref _callsign, value);
			}
		}

		[Category("NavigationSystem")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _communicationChannel  = default;

		[Category("NavigationSystem")]
		[Editor(typeof(Editors.HorizonEditor<NavigationSystem>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<NavigationSystem>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? signalFrequency {
			get {
				return _signalFrequency;
			}
			set {
				SetValue(ref _signalFrequency, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public NavigationSystemViewModel Load(NavigationSystem instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. NavigationSystem._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => NavigationSystem._featureBindingDefinitions;

		public NavigationSystemViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public NavigationSystemViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)27];

		[Category("TrafficSeparationSchemeCrossing")]
		[Optional]
		public ObservableCollection<vesselSpeedLimitViewModel> vesselSpeedLimit  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("TrafficSeparationSchemeCrossing")]
		[Editor(typeof(Editors.HorizonEditor<TrafficSeparationSchemeCrossing>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<TrafficSeparationSchemeCrossing>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("TrafficSeparationSchemeCrossing")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)3,(status)6,(status)9];

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("TrafficSeparationSchemeCrossing")]
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

		[Category("TrafficSeparationSchemeCrossing")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private String? _reportedDate  = default;

		[Category("TrafficSeparationSchemeCrossing")]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public TrafficSeparationSchemeCrossingViewModel Load(TrafficSeparationSchemeCrossing instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. TrafficSeparationSchemeCrossing._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeCrossing._featureBindingDefinitions;

		public TrafficSeparationSchemeCrossingViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public TrafficSeparationSchemeCrossingViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private String? _reportedDate  = default;

		[Category("TrafficSeparationSchemeLanePart")]
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

		[Category("TrafficSeparationSchemeLanePart")]
		[Optional]
		public ObservableCollection<vesselSpeedLimitViewModel> vesselSpeedLimit  { get; set; } = new ();

		private String? _interoperabilityIdentifier  = default;

		[Category("TrafficSeparationSchemeLanePart")]
		[Editor(typeof(Editors.HorizonEditor<TrafficSeparationSchemeLanePart>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("TrafficSeparationSchemeLanePart")]
		[Optional]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)27];

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("TrafficSeparationSchemeLanePart")]
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

		private double? _orientationValue  = default;

		[Category("TrafficSeparationSchemeLanePart")]
		[Editor(typeof(Editors.HorizonEditor<TrafficSeparationSchemeLanePart>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? orientationValue {
			get {
				return _orientationValue;
			}
			set {
				SetValue(ref _orientationValue, value);
			}
		}

		[Category("TrafficSeparationSchemeLanePart")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)3,(status)9,(status)28];

		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("TrafficSeparationSchemeLanePart")]
		[ExpandableObject]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<TrafficSeparationSchemeLanePart>), typeof(Editors.HorizonEditor))]
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

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public TrafficSeparationSchemeLanePartViewModel Load(TrafficSeparationSchemeLanePart instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. TrafficSeparationSchemeLanePart._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeLanePart._featureBindingDefinitions;

		public TrafficSeparationSchemeLanePartViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public TrafficSeparationSchemeLanePartViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Multiplicity(1)]
		public ObservableCollection<String> nationality  { get; set; } = new ();

		[Category("TerritorialSeaArea")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private status? _status  = default;

		[Category("TerritorialSeaArea")]
		[Editor(typeof(Editors.HorizonEditor<TerritorialSeaArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<TerritorialSeaArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<TerritorialSeaArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}

		[Category("TerritorialSeaArea")]
		[Optional]
		public ObservableCollection<vesselSpeedLimitViewModel> vesselSpeedLimit  { get; set; } = new ();

		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("TerritorialSeaArea")]
		[ExpandableObject]
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("TerritorialSeaArea")]
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

		[Category("TerritorialSeaArea")]
		[Optional]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)2,(restriction)4,(restriction)6,(restriction)8,(restriction)9,(restriction)10,(restriction)12,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)27];

		private int? _scaleMinimum  = default;

		[Category("TerritorialSeaArea")]
		[Editor(typeof(Editors.HorizonEditor<TerritorialSeaArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("TerritorialSeaArea")]
		[Multiplicity(1)]
		public ObservableCollection<String> nationalMaritimeAuthority  { get; set; } = new ();

		[Category("TerritorialSeaArea")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public TerritorialSeaAreaViewModel Load(TerritorialSeaArea instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. TerritorialSeaArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => TerritorialSeaArea._featureBindingDefinitions;

		public TerritorialSeaAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public TerritorialSeaAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		private double? _elevation  = default;

		[Category("LateralBeacon")]
		[Editor(typeof(Editors.HorizonEditor<LateralBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}

		private beaconShape? _beaconShape  = default;

		[Category("LateralBeacon")]
		[Editor(typeof(Editors.HorizonEditor<LateralBeacon>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public beaconShape? beaconShape {
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
		[Editor(typeof(Editors.HorizonEditor<LateralBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LateralBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private categoryOfLateralMark? _categoryOfLateralMark  = default;

		[Category("LateralBeacon")]
		[Editor(typeof(Editors.HorizonEditor<LateralBeacon>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public categoryOfLateralMark? categoryOfLateralMark {
			get {
				return _categoryOfLateralMark;
			}
			set {
				SetValue(ref _categoryOfLateralMark, value);
			}
		}

		[Browsable(false)]
		public categoryOfLateralMark[] categoryOfLateralMarkList => [(categoryOfLateralMark)1,(categoryOfLateralMark)2,(categoryOfLateralMark)3,(categoryOfLateralMark)4];

		private String? _reportedDate  = default;

		[Category("LateralBeacon")]
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

		[Category("LateralBeacon")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)12,(status)18];

		private visualProminence? _visualProminence  = default;

		[Category("LateralBeacon")]
		[Editor(typeof(Editors.HorizonEditor<LateralBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		private double? _verticalLength  = default;

		[Category("LateralBeacon")]
		[Editor(typeof(Editors.HorizonEditor<LateralBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		[Category("LateralBeacon")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("LateralBeacon")]
		[ExpandableObject]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LateralBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LateralBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("LateralBeacon")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private colourPattern? _colourPattern  = default;

		[Category("LateralBeacon")]
		[Editor(typeof(Editors.HorizonEditor<LateralBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("LateralBeacon")]
		[Editor(typeof(Editors.HorizonEditor<LateralBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public topmarkViewModel? topmark {
			get {
				return _topmark;
			}
			set {
				SetValue(ref _topmark, value);
			}
		}

		private double? _height  = default;

		[Category("LateralBeacon")]
		[Editor(typeof(Editors.HorizonEditor<LateralBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private condition? _condition  = default;

		[Category("LateralBeacon")]
		[Editor(typeof(Editors.HorizonEditor<LateralBeacon>), typeof(Editors.HorizonEditor))]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)5];

		[Category("LateralBeacon")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8];

		[Category("LateralBeacon")]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public LateralBeaconViewModel Load(LateralBeacon instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LateralBeacon._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LateralBeacon._featureBindingDefinitions;

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
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)4,(status)5,(status)16,(status)17];

		private int? _scaleMinimum  = default;

		[Category("CoastGuardStation")]
		[Editor(typeof(Editors.HorizonEditor<CoastGuardStation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("CoastGuardStation")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("CoastGuardStation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("CoastGuardStation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private Boolean? _isMRCC  = default;

		[Category("CoastGuardStation")]
		[Editor(typeof(Editors.HorizonEditor<CoastGuardStation>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		[Category("CoastGuardStation")]
		[Optional]
		public ObservableCollection<String> communicationsChannel  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public CoastGuardStationViewModel Load(CoastGuardStation instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. CoastGuardStation._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => CoastGuardStation._featureBindingDefinitions;

		public CoastGuardStationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public CoastGuardStationViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		private String? _reportedDate  = default;

		[Category("SeparationZoneOrLine")]
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

		private String? _interoperabilityIdentifier  = default;

		[Category("SeparationZoneOrLine")]
		[Editor(typeof(Editors.HorizonEditor<SeparationZoneOrLine>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("SeparationZoneOrLine")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)3,(status)9,(status)28];

		[Category("SeparationZoneOrLine")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("SeparationZoneOrLine")]
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

		private int? _scaleMinimum  = default;

		[Category("SeparationZoneOrLine")]
		[Editor(typeof(Editors.HorizonEditor<SeparationZoneOrLine>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public SeparationZoneOrLineViewModel Load(SeparationZoneOrLine instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SeparationZoneOrLine._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SeparationZoneOrLine._featureBindingDefinitions;

		public SeparationZoneOrLineViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SeparationZoneOrLineViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private int? _migrationDirection  = default;

		[Category("BottomFeature")]
		[Editor(typeof(Editors.HorizonEditor<BottomFeature>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? migrationDirection {
			get {
				return _migrationDirection;
			}
			set {
				SetValue(ref _migrationDirection, value);
			}
		}

		[Category("BottomFeature")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private double? _horizontalLength  = default;

		[Category("BottomFeature")]
		[Editor(typeof(Editors.HorizonEditor<BottomFeature>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalLength {
			get {
				return _horizontalLength;
			}
			set {
				SetValue(ref _horizontalLength, value);
			}
		}

		private bottomFeatureClassification? _bottomFeatureClassification  = default;

		[Category("BottomFeature")]
		[Editor(typeof(Editors.HorizonEditor<BottomFeature>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private String? _reportedDate  = default;

		[Category("BottomFeature")]
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

		private double? _verticalLength  = default;

		[Category("BottomFeature")]
		[Editor(typeof(Editors.HorizonEditor<BottomFeature>), typeof(Editors.HorizonEditor))]
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


		public BottomFeatureViewModel Load(BottomFeature instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. BottomFeature._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => BottomFeature._featureBindingDefinitions;

		public BottomFeatureViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public BottomFeatureViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		private String? _reportedDate  = default;

		[Category("ArchipelagicBaseline")]
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

		private status? _status  = default;

		[Category("ArchipelagicBaseline")]
		[Editor(typeof(Editors.HorizonEditor<ArchipelagicBaseline>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<ArchipelagicBaseline>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? inDispute {
			get {
				return _inDispute;
			}
			set {
				SetValue(ref _inDispute, value);
			}
		}

		private String? _nationality  = default;

		[Category("ArchipelagicBaseline")]
		[Editor(typeof(Editors.HorizonEditor<ArchipelagicBaseline>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String? nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}

		[Category("ArchipelagicBaseline")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("ArchipelagicBaseline")]
		[ExpandableObject]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<ArchipelagicBaseline>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<ArchipelagicBaseline>), typeof(Editors.HorizonEditor))]
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

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public ArchipelagicBaselineViewModel Load(ArchipelagicBaseline instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. ArchipelagicBaseline._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => ArchipelagicBaseline._featureBindingDefinitions;

		public ArchipelagicBaselineViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public ArchipelagicBaselineViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Editor(typeof(Editors.HorizonEditor<SmallBottomObject>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<SmallBottomObject>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Category("SmallBottomObject")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private double? _valueOfSounding  = default;

		[Category("SmallBottomObject")]
		[Editor(typeof(Editors.HorizonEditor<SmallBottomObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? valueOfSounding {
			get {
				return _valueOfSounding;
			}
			set {
				SetValue(ref _valueOfSounding, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public SmallBottomObjectViewModel Load(SmallBottomObject instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SmallBottomObject._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SmallBottomObject._featureBindingDefinitions;

		public SmallBottomObjectViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SmallBottomObjectViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Multiplicity(1)]
		public ObservableCollection<String> nationalMaritimeAuthority  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("ExclusiveEconomicZone")]
		[Editor(typeof(Editors.HorizonEditor<ExclusiveEconomicZone>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		[Category("ExclusiveEconomicZone")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private String? _reportedDate  = default;

		[Category("ExclusiveEconomicZone")]
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

		[Category("ExclusiveEconomicZone")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _interoperabilityIdentifier  = default;

		[Category("ExclusiveEconomicZone")]
		[Editor(typeof(Editors.HorizonEditor<ExclusiveEconomicZone>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<ExclusiveEconomicZone>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? inDispute {
			get {
				return _inDispute;
			}
			set {
				SetValue(ref _inDispute, value);
			}
		}

		[Category("ExclusiveEconomicZone")]
		[Multiplicity(1)]
		public ObservableCollection<String> nationality  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public ExclusiveEconomicZoneViewModel Load(ExclusiveEconomicZone instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. ExclusiveEconomicZone._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => ExclusiveEconomicZone._featureBindingDefinitions;

		public ExclusiveEconomicZoneViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public ExclusiveEconomicZoneViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)7,(status)8];

		private categoryOfRadarStation? _categoryOfRadarStation  = default;

		[Category("RadarStation")]
		[Editor(typeof(Editors.HorizonEditor<RadarStation>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private double? _height  = default;

		[Category("RadarStation")]
		[Editor(typeof(Editors.HorizonEditor<RadarStation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private String? _interoperabilityIdentifier  = default;

		[Category("RadarStation")]
		[Editor(typeof(Editors.HorizonEditor<RadarStation>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<RadarStation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? callsign {
			get {
				return _callsign;
			}
			set {
				SetValue(ref _callsign, value);
			}
		}

		[Category("RadarStation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("RadarStation")]
		[Editor(typeof(Editors.HorizonEditor<RadarStation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("RadarStation")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("RadarStation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("RadarStation")]
		[Optional]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();

		private double? _valueOfMaximumRange  = default;

		[Category("RadarStation")]
		[Editor(typeof(Editors.HorizonEditor<RadarStation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? valueOfMaximumRange {
			get {
				return _valueOfMaximumRange;
			}
			set {
				SetValue(ref _valueOfMaximumRange, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public RadarStationViewModel Load(RadarStation instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RadarStation._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RadarStation._featureBindingDefinitions;

		public RadarStationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public RadarStationViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		private double? _waterClarity  = default;

		[Category("DivingLocation")]
		[Editor(typeof(Editors.HorizonEditor<DivingLocation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? waterClarity {
			get {
				return _waterClarity;
			}
			set {
				SetValue(ref _waterClarity, value);
			}
		}

		[Category("DivingLocation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private divingActivity? _divingActivity  = default;

		[Category("DivingLocation")]
		[Editor(typeof(Editors.HorizonEditor<DivingLocation>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public DivingLocationViewModel Load(DivingLocation instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. DivingLocation._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => DivingLocation._featureBindingDefinitions;

		public DivingLocationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public DivingLocationViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("RestrictedArea")]
		[Editor(typeof(Editors.HorizonEditor<RestrictedArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("RestrictedArea")]
		[Optional]
		public ObservableCollection<categoryOfRestrictedArea> categoryOfRestrictedArea  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfRestrictedArea[] categoryOfRestrictedAreaList => [(categoryOfRestrictedArea)1,(categoryOfRestrictedArea)4,(categoryOfRestrictedArea)5,(categoryOfRestrictedArea)6,(categoryOfRestrictedArea)7,(categoryOfRestrictedArea)8,(categoryOfRestrictedArea)9,(categoryOfRestrictedArea)10,(categoryOfRestrictedArea)12,(categoryOfRestrictedArea)14,(categoryOfRestrictedArea)18,(categoryOfRestrictedArea)19,(categoryOfRestrictedArea)20,(categoryOfRestrictedArea)21,(categoryOfRestrictedArea)22,(categoryOfRestrictedArea)23,(categoryOfRestrictedArea)24,(categoryOfRestrictedArea)25,(categoryOfRestrictedArea)27,(categoryOfRestrictedArea)28,(categoryOfRestrictedArea)29,(categoryOfRestrictedArea)30,(categoryOfRestrictedArea)31,(categoryOfRestrictedArea)32,(categoryOfRestrictedArea)501];

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("RestrictedArea")]
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

		private String? _nationality  = default;

		[Category("RestrictedArea")]
		[Editor(typeof(Editors.HorizonEditor<RestrictedArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}

		[Category("RestrictedArea")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)9,(status)18,(status)28,(status)501];

		[Category("RestrictedArea")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("RestrictedArea")]
		[Optional]
		public ObservableCollection<vesselSpeedLimitViewModel> vesselSpeedLimit  { get; set; } = new ();

		[Category("RestrictedArea")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _interoperabilityIdentifier  = default;

		[Category("RestrictedArea")]
		[Editor(typeof(Editors.HorizonEditor<RestrictedArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<RestrictedArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? controllingAuthority {
			get {
				return _controllingAuthority;
			}
			set {
				SetValue(ref _controllingAuthority, value);
			}
		}

		[Category("RestrictedArea")]
		[Multiplicity(1)]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)7,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)14,(restriction)15,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)26,(restriction)27,(restriction)39,(restriction)42];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public RestrictedAreaViewModel Load(RestrictedArea instance) {
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
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)4,(status)13,(status)18];

		private double? _depthRangeMinimumValue  = default;

		[Category("CableSubmarine")]
		[Editor(typeof(Editors.HorizonEditor<CableSubmarine>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? depthRangeMinimumValue {
			get {
				return _depthRangeMinimumValue;
			}
			set {
				SetValue(ref _depthRangeMinimumValue, value);
			}
		}

		private double? _buriedDepth  = default;

		[Category("CableSubmarine")]
		[Editor(typeof(Editors.HorizonEditor<CableSubmarine>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? buriedDepth {
			get {
				return _buriedDepth;
			}
			set {
				SetValue(ref _buriedDepth, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("CableSubmarine")]
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

		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("CableSubmarine")]
		[ExpandableObject]
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		[Category("CableSubmarine")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private categoryOfCable? _categoryOfCable  = default;

		[Category("CableSubmarine")]
		[Editor(typeof(Editors.HorizonEditor<CableSubmarine>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<CableSubmarine>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<CableSubmarine>), typeof(Editors.HorizonEditor))]
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
		public condition[] conditionList => [(condition)1,(condition)5];

		[Category("CableSubmarine")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("CableSubmarine")]
		[Editor(typeof(Editors.HorizonEditor<CableSubmarine>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<CableSubmarine>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public CableSubmarineViewModel Load(CableSubmarine instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. CableSubmarine._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => CableSubmarine._featureBindingDefinitions;

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
		private double? _surroundingDepth  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? surroundingDepth {
			get {
				return _surroundingDepth;
			}
			set {
				SetValue(ref _surroundingDepth, value);
			}
		}

		[Category("Wreck")]
		[Optional]
		public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1,(techniqueOfVerticalMeasurement)2,(techniqueOfVerticalMeasurement)3,(techniqueOfVerticalMeasurement)4,(techniqueOfVerticalMeasurement)5,(techniqueOfVerticalMeasurement)8,(techniqueOfVerticalMeasurement)9,(techniqueOfVerticalMeasurement)10,(techniqueOfVerticalMeasurement)11,(techniqueOfVerticalMeasurement)12,(techniqueOfVerticalMeasurement)13,(techniqueOfVerticalMeasurement)15,(techniqueOfVerticalMeasurement)16,(techniqueOfVerticalMeasurement)17,(techniqueOfVerticalMeasurement)18];

		private horizontalPositionUncertaintyViewModel? _horizontalPositionUncertainty  = default;

		[Category("Wreck")]
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

		private visualProminence? _visualProminence  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private String? _reportedDate  = default;

		[Category("Wreck")]
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

		private double? _horizontalLength  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalLength {
			get {
				return _horizontalLength;
			}
			set {
				SetValue(ref _horizontalLength, value);
			}
		}

		private Boolean? _radarConspicuous  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? currentScourDimensions {
			get {
				return _currentScourDimensions;
			}
			set {
				SetValue(ref _currentScourDimensions, value);
			}
		}

		[Category("Wreck")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)7,(status)13,(status)18];

		private sonarSignalStrength? _sonarSignalStrength  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private magneticInformationViewModel? _magneticInformation  = default;

		[Category("Wreck")]
		[ExpandableObject]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}

		[Category("Wreck")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8];

		private double? _defaultClearanceDepth  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? defaultClearanceDepth {
			get {
				return _defaultClearanceDepth;
			}
			set {
				SetValue(ref _defaultClearanceDepth, value);
			}
		}

		private natureOfSurface? _natureOfSurface  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private double? _orientationValue  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? orientationValue {
			get {
				return _orientationValue;
			}
			set {
				SetValue(ref _orientationValue, value);
			}
		}

		private String? _typeOfWreck  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? typeOfWreck {
			get {
				return _typeOfWreck;
			}
			set {
				SetValue(ref _typeOfWreck, value);
			}
		}

		private waterLevelEffect? _waterLevelEffect  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public waterLevelEffect? waterLevelEffect {
			get {
				return _waterLevelEffect;
			}
			set {
				SetValue(ref _waterLevelEffect, value);
			}
		}

		[Browsable(false)]
		public waterLevelEffect[] waterLevelEffectList => [(waterLevelEffect)1,(waterLevelEffect)2,(waterLevelEffect)3,(waterLevelEffect)4,(waterLevelEffect)5];

		private double? _verticalLength  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private categoryOfWreck? _categoryOfWreck  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
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
		public qualityOfHorizontalMeasurement[] qualityOfHorizontalMeasurementList => [(qualityOfHorizontalMeasurement)4,(qualityOfHorizontalMeasurement)5];

		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

		[Category("Wreck")]
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

		private double? _height  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private int? _scaleMinimum  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? debrisField {
			get {
				return _debrisField;
			}
			set {
				SetValue(ref _debrisField, value);
			}
		}

		[Category("Wreck")]
		[Multiplicity(1)]
		public ObservableCollection<String> nationality  { get; set; } = new ();

		private lastSourceInformationViewModel? _lastSourceInformation  = default;

		[Category("Wreck")]
		[ExpandableObject]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<vesselMeasurementsSpecificationViewModel> vesselMeasurementsSpecification  { get; set; } = new ();

		private Boolean? _existenceOfRestrictedArea  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? existenceOfRestrictedArea {
			get {
				return _existenceOfRestrictedArea;
			}
			set {
				SetValue(ref _existenceOfRestrictedArea, value);
			}
		}

		private String? _dateSunk  = default;

		[Category("Wreck")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? dateSunk {
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
		[Optional]
		public firstSourceInformationViewModel? firstSourceInformation {
			get {
				return _firstSourceInformation;
			}
			set {
				SetValue(ref _firstSourceInformation, value);
			}
		}

		private double? _horizontalWidth  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalWidth {
			get {
				return _horizontalWidth;
			}
			set {
				SetValue(ref _horizontalWidth, value);
			}
		}

		private double? _valueOfSounding  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? valueOfSounding {
			get {
				return _valueOfSounding;
			}
			set {
				SetValue(ref _valueOfSounding, value);
			}
		}

		[Category("Wreck")]
		[Optional]
		public ObservableCollection<product> product  { get; set; } = new ();

		[Browsable(false)]
		public product[] productList => [(product)1,(product)2,(product)3,(product)4,(product)5,(product)6,(product)7,(product)8,(product)9,(product)10,(product)11,(product)12,(product)13,(product)14,(product)15,(product)16,(product)17,(product)18,(product)19,(product)20,(product)21,(product)22,(product)23,(product)24,(product)25];

		private String? _pictorialRepresentation  = default;

		[Category("Wreck")]
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Wreck>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public WreckViewModel Load(Wreck instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Wreck._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Wreck._featureBindingDefinitions;

		public WreckViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public WreckViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Editor(typeof(Editors.HorizonEditor<QRoute>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}

		[Category("QRoute")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("QRoute")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Category("QRoute")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)2,(status)503];

		private qRouteChannelWidthViewModel? _qRouteChannelWidth  = default;

		[Category("QRoute")]
		[ExpandableObject]
		[Optional]
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<QRoute>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public QRouteViewModel Load(QRoute instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. QRoute._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => QRoute._featureBindingDefinitions;

		public QRouteViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public QRouteViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Editor(typeof(Editors.HorizonEditor<CompletenessOfProductSpecification>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? agencyResponsibleForProduction {
			get {
				return _agencyResponsibleForProduction;
			}
			set {
				SetValue(ref _agencyResponsibleForProduction, value);
			}
		}

		private categoryOfCompleteness? _categoryOfCompleteness  = default;

		[Category("CompletenessOfProductSpecification")]
		[Editor(typeof(Editors.HorizonEditor<CompletenessOfProductSpecification>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public categoryOfCompleteness? categoryOfCompleteness {
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
		[Editor(typeof(Editors.HorizonEditor<CompletenessOfProductSpecification>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? copyrightStatement {
			get {
				return _copyrightStatement;
			}
			set {
				SetValue(ref _copyrightStatement, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("CompletenessOfProductSpecification")]
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

		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("CompletenessOfProductSpecification")]
		[ExpandableObject]
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		[Category("CompletenessOfProductSpecification")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public CompletenessOfProductSpecificationViewModel Load(CompletenessOfProductSpecification instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. CompletenessOfProductSpecification._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => CompletenessOfProductSpecification._featureBindingDefinitions;

		public CompletenessOfProductSpecificationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public CompletenessOfProductSpecificationViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)14,(status)16,(status)17];

		[Category("RescueStation")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("RescueStation")]
		[Optional]
		public ObservableCollection<String> communicationChannel  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("RescueStation")]
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

		[Category("RescueStation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _interoperabilityIdentifier  = default;

		[Category("RescueStation")]
		[Editor(typeof(Editors.HorizonEditor<RescueStation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("RescueStation")]
		[Optional]
		public ObservableCollection<categoryOfRescueStation> categoryOfRescueStation  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfRescueStation[] categoryOfRescueStationList => [(categoryOfRescueStation)1,(categoryOfRescueStation)2,(categoryOfRescueStation)4,(categoryOfRescueStation)5,(categoryOfRescueStation)6,(categoryOfRescueStation)7,(categoryOfRescueStation)8];

		private int? _scaleMinimum  = default;

		[Category("RescueStation")]
		[Editor(typeof(Editors.HorizonEditor<RescueStation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("RescueStation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public RescueStationViewModel Load(RescueStation instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RescueStation._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RescueStation._featureBindingDefinitions;

		public RescueStationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public RescueStationViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("CardinalBeacon")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8];

		private colourPattern? _colourPattern  = default;

		[Category("CardinalBeacon")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<CardinalBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private beaconShape? _beaconShape  = default;

		[Category("CardinalBeacon")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBeacon>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public beaconShape? beaconShape {
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
		[Optional]
		public topmarkViewModel? topmark {
			get {
				return _topmark;
			}
			set {
				SetValue(ref _topmark, value);
			}
		}

		private categoryOfCardinalMark? _categoryOfCardinalMark  = default;

		[Category("CardinalBeacon")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBeacon>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public categoryOfCardinalMark? categoryOfCardinalMark {
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
		[Editor(typeof(Editors.HorizonEditor<CardinalBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)12,(status)18];

		private double? _height  = default;

		[Category("CardinalBeacon")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		[Category("CardinalBeacon")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("CardinalBeacon")]
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

		private double? _verticalLength  = default;

		[Category("CardinalBeacon")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private int? _scaleMinimum  = default;

		[Category("CardinalBeacon")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("CardinalBeacon")]
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

		private String? _interoperabilityIdentifier  = default;

		[Category("CardinalBeacon")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("CardinalBeacon")]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		private double? _elevation  = default;

		[Category("CardinalBeacon")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}

		private String? _pictorialRepresentation  = default;

		[Category("CardinalBeacon")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<CardinalBeacon>), typeof(Editors.HorizonEditor))]
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

		private visualProminence? _visualProminence  = default;

		[Category("CardinalBeacon")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public CardinalBeaconViewModel Load(CardinalBeacon instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. CardinalBeacon._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => CardinalBeacon._featureBindingDefinitions;

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
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)14,(status)16,(status)17];

		private visualProminence? _visualProminence  = default;

		[Category("LightVessel")]
		[Editor(typeof(Editors.HorizonEditor<LightVessel>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LightVessel>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LightVessel>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LightVessel>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Category("LightVessel")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private String? _pictorialRepresentation  = default;

		[Category("LightVessel")]
		[Editor(typeof(Editors.HorizonEditor<LightVessel>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private double? _horizontalLength  = default;

		[Category("LightVessel")]
		[Editor(typeof(Editors.HorizonEditor<LightVessel>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalLength {
			get {
				return _horizontalLength;
			}
			set {
				SetValue(ref _horizontalLength, value);
			}
		}

		[Category("LightVessel")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("LightVessel")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6,(natureOfConstruction)7];

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("LightVessel")]
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

		[Category("LightVessel")]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		private colourPattern? _colourPattern  = default;

		[Category("LightVessel")]
		[Editor(typeof(Editors.HorizonEditor<LightVessel>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private double? _horizontalWidth  = default;

		[Category("LightVessel")]
		[Editor(typeof(Editors.HorizonEditor<LightVessel>), typeof(Editors.HorizonEditor))]
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

		[Category("LightVessel")]
		[Editor(typeof(Editors.HorizonEditor<LightVessel>), typeof(Editors.HorizonEditor))]
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


		public LightVesselViewModel Load(LightVessel instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LightVessel._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LightVessel._featureBindingDefinitions;

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
		[Editor(typeof(Editors.HorizonEditor<FisheryZone>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		private String? _nationality  = default;

		[Category("FisheryZone")]
		[Editor(typeof(Editors.HorizonEditor<FisheryZone>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String? nationality {
			get {
				return _nationality;
			}
			set {
				SetValue(ref _nationality, value);
			}
		}

		[Category("FisheryZone")]
		[Multiplicity(1)]
		public ObservableCollection<String> nationalMaritimeAuthority  { get; set; } = new ();

		[Category("FisheryZone")]
		[Optional]
		public ObservableCollection<String> species  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("FisheryZone")]
		[Editor(typeof(Editors.HorizonEditor<FisheryZone>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("FisheryZone")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("FisheryZone")]
		[ExpandableObject]
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		[Category("FisheryZone")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private status? _status  = default;

		[Category("FisheryZone")]
		[Editor(typeof(Editors.HorizonEditor<FisheryZone>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public FisheryZoneViewModel Load(FisheryZone instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. FisheryZone._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FisheryZone._featureBindingDefinitions;

		public FisheryZoneViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public FisheryZoneViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		private double? _maximumPermittedDraught  = default;

		[Category("DredgedArea")]
		[Editor(typeof(Editors.HorizonEditor<DredgedArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? maximumPermittedDraught {
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
		[Optional]
		public verticalUncertaintyViewModel? verticalUncertainty {
			get {
				return _verticalUncertainty;
			}
			set {
				SetValue(ref _verticalUncertainty, value);
			}
		}

		private String? _dredgedDate  = default;

		[Category("DredgedArea")]
		[S100TruncatedDateAttribute]
		[Editor(typeof(Editors.S100TruncatedDateEditor), typeof(Editors.S100TruncatedDateEditor))]
		[Optional]
		public String? dredgedDate {
			get {
				return _dredgedDate;
			}
			set {
				SetValue(ref _dredgedDate, value);
			}
		}

		[Category("DredgedArea")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private double? _depthRangeMaximumValue  = default;

		[Category("DredgedArea")]
		[Editor(typeof(Editors.HorizonEditor<DredgedArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? depthRangeMaximumValue {
			get {
				return _depthRangeMaximumValue;
			}
			set {
				SetValue(ref _depthRangeMaximumValue, value);
			}
		}

		private qualityOfVerticalMeasurement? _qualityOfVerticalMeasurement  = default;

		[Category("DredgedArea")]
		[Editor(typeof(Editors.HorizonEditor<DredgedArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1,(techniqueOfVerticalMeasurement)2,(techniqueOfVerticalMeasurement)3,(techniqueOfVerticalMeasurement)8,(techniqueOfVerticalMeasurement)9,(techniqueOfVerticalMeasurement)13,(techniqueOfVerticalMeasurement)15,(techniqueOfVerticalMeasurement)16,(techniqueOfVerticalMeasurement)17,(techniqueOfVerticalMeasurement)18];

		private double? _depthRangeMinimumValue  = default;

		[Category("DredgedArea")]
		[Editor(typeof(Editors.HorizonEditor<DredgedArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? depthRangeMinimumValue {
			get {
				return _depthRangeMinimumValue;
			}
			set {
				SetValue(ref _depthRangeMinimumValue, value);
			}
		}

		[Category("DredgedArea")]
		[Optional]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)8,(restriction)11,(restriction)12,(restriction)13,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)23,(restriction)25,(restriction)27,(restriction)39];

		[Category("DredgedArea")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public DredgedAreaViewModel Load(DredgedArea instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. DredgedArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => DredgedArea._featureBindingDefinitions;

		public DredgedAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public DredgedAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)14];

		private String? _interoperabilityIdentifier  = default;

		[Category("FerryRoute")]
		[Editor(typeof(Editors.HorizonEditor<FerryRoute>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<FerryRoute>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("FerryRoute")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("FerryRoute")]
		[ExpandableObject]
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		[Category("FerryRoute")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private String? _agencyResponsibleForProduction  = default;

		[Category("FerryRoute")]
		[Editor(typeof(Editors.HorizonEditor<FerryRoute>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<FerryRoute>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("FerryRoute")]
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

		[Category("FerryRoute")]
		[Multiplicity(1)]
		public ObservableCollection<categoryOfFerry> categoryOfFerry  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfFerry[] categoryOfFerryList => [(categoryOfFerry)1,(categoryOfFerry)2,(categoryOfFerry)3,(categoryOfFerry)5];

		[Category("FerryRoute")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("FerryRoute")]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public FerryRouteViewModel Load(FerryRoute instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. FerryRoute._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FerryRoute._featureBindingDefinitions;

		public FerryRouteViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public FerryRouteViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		private double? _horizontalLength  = default;

		[Category("ShorelineConstruction")]
		[Editor(typeof(Editors.HorizonEditor<ShorelineConstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalLength {
			get {
				return _horizontalLength;
			}
			set {
				SetValue(ref _horizontalLength, value);
			}
		}

		private gradientOfSlope? _gradientOfSlope  = default;

		[Category("ShorelineConstruction")]
		[Editor(typeof(Editors.HorizonEditor<ShorelineConstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private condition? _condition  = default;

		[Category("ShorelineConstruction")]
		[Editor(typeof(Editors.HorizonEditor<ShorelineConstruction>), typeof(Editors.HorizonEditor))]
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

		private visualProminence? _visualProminence  = default;

		[Category("ShorelineConstruction")]
		[Editor(typeof(Editors.HorizonEditor<ShorelineConstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		private double? _horizontalWidth  = default;

		[Category("ShorelineConstruction")]
		[Editor(typeof(Editors.HorizonEditor<ShorelineConstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalWidth {
			get {
				return _horizontalWidth;
			}
			set {
				SetValue(ref _horizontalWidth, value);
			}
		}

		private Boolean? _radarConspicuous  = default;

		[Category("ShorelineConstruction")]
		[Editor(typeof(Editors.HorizonEditor<ShorelineConstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<ShorelineConstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<ShorelineConstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		[Category("ShorelineConstruction")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)6,(status)7,(status)8,(status)12,(status)13,(status)14,(status)28];

		private double? _verticalLength  = default;

		[Category("ShorelineConstruction")]
		[Editor(typeof(Editors.HorizonEditor<ShorelineConstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		[Category("ShorelineConstruction")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private waterLevelEffect? _waterLevelEffect  = default;

		[Category("ShorelineConstruction")]
		[Editor(typeof(Editors.HorizonEditor<ShorelineConstruction>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public waterLevelEffect? waterLevelEffect {
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
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)11];

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("ShorelineConstruction")]
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

		private categoryOfShorelineConstruction? _categoryOfShorelineConstruction  = default;

		[Category("ShorelineConstruction")]
		[Editor(typeof(Editors.HorizonEditor<ShorelineConstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<ShorelineConstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private double? _height  = default;

		[Category("ShorelineConstruction")]
		[Editor(typeof(Editors.HorizonEditor<ShorelineConstruction>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("ShorelineConstruction")]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public ShorelineConstructionViewModel Load(ShorelineConstruction instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. ShorelineConstruction._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => ShorelineConstruction._featureBindingDefinitions;

		public ShorelineConstructionViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public ShorelineConstructionViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		private String? _reportedDate  = default;

		[Category("CautionArea")]
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

		[Category("CautionArea")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("CautionArea")]
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

		private status? _status  = default;

		[Category("CautionArea")]
		[Editor(typeof(Editors.HorizonEditor<CautionArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<CautionArea>), typeof(Editors.HorizonEditor))]
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
		public condition[] conditionList => [(condition)1,(condition)3,(condition)5];

		private int? _scaleMinimum  = default;

		[Category("CautionArea")]
		[Editor(typeof(Editors.HorizonEditor<CautionArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<CautionArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		[Category("CautionArea")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public CautionAreaViewModel Load(CautionArea instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. CautionArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => CautionArea._featureBindingDefinitions;

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
		[Editor(typeof(Editors.HorizonEditor<DeepWaterRoutePart>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public verticalUncertaintyViewModel? verticalUncertainty {
			get {
				return _verticalUncertainty;
			}
			set {
				SetValue(ref _verticalUncertainty, value);
			}
		}

		[Category("DeepWaterRoutePart")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private trafficFlow? _trafficFlow  = default;

		[Category("DeepWaterRoutePart")]
		[Editor(typeof(Editors.HorizonEditor<DeepWaterRoutePart>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public trafficFlow? trafficFlow {
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
		[Editor(typeof(Editors.HorizonEditor<DeepWaterRoutePart>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("DeepWaterRoutePart")]
		[Optional]
		public ObservableCollection<vesselSpeedLimitViewModel> vesselSpeedLimit  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("DeepWaterRoutePart")]
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

		private String? _interoperabilityIdentifier  = default;

		[Category("DeepWaterRoutePart")]
		[Editor(typeof(Editors.HorizonEditor<DeepWaterRoutePart>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		private double? _depthRangeMinimumValue  = default;

		[Category("DeepWaterRoutePart")]
		[Editor(typeof(Editors.HorizonEditor<DeepWaterRoutePart>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? depthRangeMinimumValue {
			get {
				return _depthRangeMinimumValue;
			}
			set {
				SetValue(ref _depthRangeMinimumValue, value);
			}
		}

		[Category("DeepWaterRoutePart")]
		[Optional]
		public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1,(techniqueOfVerticalMeasurement)3,(techniqueOfVerticalMeasurement)5,(techniqueOfVerticalMeasurement)8,(techniqueOfVerticalMeasurement)9,(techniqueOfVerticalMeasurement)13,(techniqueOfVerticalMeasurement)15,(techniqueOfVerticalMeasurement)16,(techniqueOfVerticalMeasurement)17,(techniqueOfVerticalMeasurement)18];

		[Category("DeepWaterRoutePart")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Category("DeepWaterRoutePart")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)3,(status)6,(status)9,(status)28];

		private double? _orientationValue  = default;

		[Category("DeepWaterRoutePart")]
		[Editor(typeof(Editors.HorizonEditor<DeepWaterRoutePart>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? orientationValue {
			get {
				return _orientationValue;
			}
			set {
				SetValue(ref _orientationValue, value);
			}
		}

		[Category("DeepWaterRoutePart")]
		[Optional]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)27];

		[Category("DeepWaterRoutePart")]
		[Optional]
		public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1,(qualityOfVerticalMeasurement)2,(qualityOfVerticalMeasurement)3,(qualityOfVerticalMeasurement)4,(qualityOfVerticalMeasurement)6,(qualityOfVerticalMeasurement)7];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public DeepWaterRoutePartViewModel Load(DeepWaterRoutePart instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. DeepWaterRoutePart._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => DeepWaterRoutePart._featureBindingDefinitions;

		public DeepWaterRoutePartViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public DeepWaterRoutePartViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Category("CurrentNonGravitational")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("CurrentNonGravitational")]
		[Editor(typeof(Editors.HorizonEditor<CurrentNonGravitational>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private orientationViewModel? _orientation  = default;

		[Category("CurrentNonGravitational")]
		[ExpandableObject]
		[Mandatory]
		public orientationViewModel? orientation {
			get {
				return _orientation;
			}
			set {
				SetValue(ref _orientation, value);
			}
		}

		[Category("CurrentNonGravitational")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("CurrentNonGravitational")]
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

		private speedViewModel? _speed  = default;

		[Category("CurrentNonGravitational")]
		[ExpandableObject]
		[Mandatory]
		public speedViewModel? speed {
			get {
				return _speed;
			}
			set {
				SetValue(ref _speed, value);
			}
		}

		private status? _status  = default;

		[Category("CurrentNonGravitational")]
		[Editor(typeof(Editors.HorizonEditor<CurrentNonGravitational>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public CurrentNonGravitationalViewModel Load(CurrentNonGravitational instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. CurrentNonGravitational._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => CurrentNonGravitational._featureBindingDefinitions;

		public CurrentNonGravitationalViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public CurrentNonGravitationalViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Editor(typeof(Editors.HorizonEditor<DataCoverage>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<DataCoverage>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<DataCoverage>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private int? _optimumDisplayScale  = default;

		[Category("DataCoverage")]
		[Editor(typeof(Editors.HorizonEditor<DataCoverage>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int? optimumDisplayScale {
			get {
				return _optimumDisplayScale;
			}
			set {
				SetValue(ref _optimumDisplayScale, value);
			}
		}

		private int? _minimumDisplayScale  = default;

		[Category("DataCoverage")]
		[Editor(typeof(Editors.HorizonEditor<DataCoverage>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int? minimumDisplayScale {
			get {
				return _minimumDisplayScale;
			}
			set {
				SetValue(ref _minimumDisplayScale, value);
			}
		}

		[Category("DataCoverage")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private int? _maximumDisplayScale  = default;

		[Category("DataCoverage")]
		[Editor(typeof(Editors.HorizonEditor<DataCoverage>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public int? maximumDisplayScale {
			get {
				return _maximumDisplayScale;
			}
			set {
				SetValue(ref _maximumDisplayScale, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public DataCoverageViewModel Load(DataCoverage instance) {
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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private String? _agencyResponsibleForProduction  = default;

		[Category("SeabedArea")]
		[Editor(typeof(Editors.HorizonEditor<SeabedArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<SeabedArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private waterLevelEffect? _waterLevelEffect  = default;

		[Category("SeabedArea")]
		[Editor(typeof(Editors.HorizonEditor<SeabedArea>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public waterLevelEffect? waterLevelEffect {
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
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Category("SeabedArea")]
		[Multiplicity(1)]
		public ObservableCollection<surfaceCharacteristicsViewModel> surfaceCharacteristics  { get; set; } = new ();

		private double? _attenuation  = default;

		[Category("SeabedArea")]
		[Editor(typeof(Editors.HorizonEditor<SeabedArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? attenuation {
			get {
				return _attenuation;
			}
			set {
				SetValue(ref _attenuation, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public SeabedAreaViewModel Load(SeabedArea instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SeabedArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SeabedArea._featureBindingDefinitions;

		public SeabedAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SeabedAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private buoyShape? _buoyShape  = default;

		[Category("SpecialPurposeGeneralBuoy")]
		[Editor(typeof(Editors.HorizonEditor<SpecialPurposeGeneralBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public buoyShape? buoyShape {
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
		[Editor(typeof(Editors.HorizonEditor<SpecialPurposeGeneralBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("SpecialPurposeGeneralBuoy")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("SpecialPurposeGeneralBuoy")]
		[ExpandableObject]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<SpecialPurposeGeneralBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Multiplicity(1)]
		public ObservableCollection<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfSpecialPurposeMark[] categoryOfSpecialPurposeMarkList => [(categoryOfSpecialPurposeMark)1,(categoryOfSpecialPurposeMark)2,(categoryOfSpecialPurposeMark)3,(categoryOfSpecialPurposeMark)4,(categoryOfSpecialPurposeMark)5,(categoryOfSpecialPurposeMark)6,(categoryOfSpecialPurposeMark)7,(categoryOfSpecialPurposeMark)8,(categoryOfSpecialPurposeMark)9,(categoryOfSpecialPurposeMark)10,(categoryOfSpecialPurposeMark)11,(categoryOfSpecialPurposeMark)12,(categoryOfSpecialPurposeMark)14,(categoryOfSpecialPurposeMark)15,(categoryOfSpecialPurposeMark)17,(categoryOfSpecialPurposeMark)18,(categoryOfSpecialPurposeMark)19,(categoryOfSpecialPurposeMark)20,(categoryOfSpecialPurposeMark)21,(categoryOfSpecialPurposeMark)22,(categoryOfSpecialPurposeMark)23,(categoryOfSpecialPurposeMark)24,(categoryOfSpecialPurposeMark)25,(categoryOfSpecialPurposeMark)26,(categoryOfSpecialPurposeMark)27,(categoryOfSpecialPurposeMark)28,(categoryOfSpecialPurposeMark)29,(categoryOfSpecialPurposeMark)30,(categoryOfSpecialPurposeMark)31,(categoryOfSpecialPurposeMark)32,(categoryOfSpecialPurposeMark)33,(categoryOfSpecialPurposeMark)34,(categoryOfSpecialPurposeMark)35,(categoryOfSpecialPurposeMark)36,(categoryOfSpecialPurposeMark)37,(categoryOfSpecialPurposeMark)39,(categoryOfSpecialPurposeMark)40,(categoryOfSpecialPurposeMark)42,(categoryOfSpecialPurposeMark)43,(categoryOfSpecialPurposeMark)45,(categoryOfSpecialPurposeMark)46,(categoryOfSpecialPurposeMark)47,(categoryOfSpecialPurposeMark)48,(categoryOfSpecialPurposeMark)49,(categoryOfSpecialPurposeMark)50,(categoryOfSpecialPurposeMark)51,(categoryOfSpecialPurposeMark)52,(categoryOfSpecialPurposeMark)53,(categoryOfSpecialPurposeMark)54,(categoryOfSpecialPurposeMark)55,(categoryOfSpecialPurposeMark)56,(categoryOfSpecialPurposeMark)57,(categoryOfSpecialPurposeMark)58,(categoryOfSpecialPurposeMark)59,(categoryOfSpecialPurposeMark)60,(categoryOfSpecialPurposeMark)61,(categoryOfSpecialPurposeMark)62,(categoryOfSpecialPurposeMark)63];

		private String? _pictorialRepresentation  = default;

		[Category("SpecialPurposeGeneralBuoy")]
		[Editor(typeof(Editors.HorizonEditor<SpecialPurposeGeneralBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		[Category("SpecialPurposeGeneralBuoy")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)5,(status)7,(status)8,(status)18,(status)503];

		private double? _verticalLength  = default;

		[Category("SpecialPurposeGeneralBuoy")]
		[Editor(typeof(Editors.HorizonEditor<SpecialPurposeGeneralBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private Boolean? _radarConspicuous  = default;

		[Category("SpecialPurposeGeneralBuoy")]
		[Editor(typeof(Editors.HorizonEditor<SpecialPurposeGeneralBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public topmarkViewModel? topmark {
			get {
				return _topmark;
			}
			set {
				SetValue(ref _topmark, value);
			}
		}

		[Category("SpecialPurposeGeneralBuoy")]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("SpecialPurposeGeneralBuoy")]
		[Editor(typeof(Editors.HorizonEditor<SpecialPurposeGeneralBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)11];

		[Category("SpecialPurposeGeneralBuoy")]
		[Optional]
		public ObservableCollection<fixedDateRangeViewModel> fixedDateRange  { get; set; } = new ();

		private String? _interoperabilityIdentifier  = default;

		[Category("SpecialPurposeGeneralBuoy")]
		[Editor(typeof(Editors.HorizonEditor<SpecialPurposeGeneralBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("SpecialPurposeGeneralBuoy")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public SpecialPurposeGeneralBuoyViewModel Load(SpecialPurposeGeneralBuoy instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SpecialPurposeGeneralBuoy._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SpecialPurposeGeneralBuoy._featureBindingDefinitions;

		public SpecialPurposeGeneralBuoyViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SpecialPurposeGeneralBuoyViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)6,(status)7,(status)8,(status)11,(status)14,(status)15,(status)16,(status)17];

		private double? _relativeHorizontalAccuracy  = default;

		[Category("LightSectored")]
		[Editor(typeof(Editors.HorizonEditor<LightSectored>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? relativeHorizontalAccuracy {
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
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		[Category("LightSectored")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private double? _relativeVerticalAccuracy  = default;

		[Category("LightSectored")]
		[Editor(typeof(Editors.HorizonEditor<LightSectored>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? relativeVerticalAccuracy {
			get {
				return _relativeVerticalAccuracy;
			}
			set {
				SetValue(ref _relativeVerticalAccuracy, value);
			}
		}

		[Category("LightSectored")]
		[Optional]
		public ObservableCollection<categoryOfLight> categoryOfLight  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfLight[] categoryOfLightList => [(categoryOfLight)4,(categoryOfLight)5,(categoryOfLight)8,(categoryOfLight)9,(categoryOfLight)10,(categoryOfLight)11,(categoryOfLight)12,(categoryOfLight)13,(categoryOfLight)14,(categoryOfLight)15,(categoryOfLight)17,(categoryOfLight)18,(categoryOfLight)19,(categoryOfLight)20];

		private exhibitionConditionOfLight? _exhibitionConditionOfLight  = default;

		[Category("LightSectored")]
		[Editor(typeof(Editors.HorizonEditor<LightSectored>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private String? _reportedDate  = default;

		[Category("LightSectored")]
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

		private int? _scaleMinimum  = default;

		[Category("LightSectored")]
		[Editor(typeof(Editors.HorizonEditor<LightSectored>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("LightSectored")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private String? _pictorialRepresentation  = default;

		[Category("LightSectored")]
		[Editor(typeof(Editors.HorizonEditor<LightSectored>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private double? _height  = default;

		[Category("LightSectored")]
		[Editor(typeof(Editors.HorizonEditor<LightSectored>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private heightLengthUnits? _heightLengthUnits  = default;

		[Category("LightSectored")]
		[Editor(typeof(Editors.HorizonEditor<LightSectored>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LightSectored>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("LightSectored")]
		[Multiplicity(1)]
		public ObservableCollection<sectorCharacteristicsViewModel> sectorCharacteristics  { get; set; } = new ();

		private verticalDatum? _verticalDatum  = default;

		[Category("LightSectored")]
		[Editor(typeof(Editors.HorizonEditor<LightSectored>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LightSectored>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LightSectored>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public LightSectoredViewModel Load(LightSectored instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LightSectored._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LightSectored._featureBindingDefinitions;

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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("IceLine")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public IceLineViewModel Load(IceLine instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. IceLine._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => IceLine._featureBindingDefinitions;

		public IceLineViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public IceLineViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)15,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)23,(restriction)24,(restriction)27,(restriction)39];

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("AnchorageArea")]
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

		[Category("AnchorageArea")]
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

		[Category("AnchorageArea")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Category("AnchorageArea")]
		[Optional]
		public ObservableCollection<categoryOfAnchorage> categoryOfAnchorage  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfAnchorage[] categoryOfAnchorageList => [(categoryOfAnchorage)1,(categoryOfAnchorage)2,(categoryOfAnchorage)3,(categoryOfAnchorage)5,(categoryOfAnchorage)6,(categoryOfAnchorage)7,(categoryOfAnchorage)9,(categoryOfAnchorage)10,(categoryOfAnchorage)14,(categoryOfAnchorage)15];

		private int? _scaleMinimum  = default;

		[Category("AnchorageArea")]
		[Editor(typeof(Editors.HorizonEditor<AnchorageArea>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("AnchorageArea")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)5,(status)6,(status)7,(status)8,(status)9,(status)14];

		[Category("AnchorageArea")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AnchorageArea")]
		[Optional]
		public ObservableCollection<categoryOfCargo> categoryOfCargo  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfCargo[] categoryOfCargoList => [(categoryOfCargo)1,(categoryOfCargo)2,(categoryOfCargo)3,(categoryOfCargo)4,(categoryOfCargo)5,(categoryOfCargo)6,(categoryOfCargo)7,(categoryOfCargo)8,(categoryOfCargo)9,(categoryOfCargo)10,(categoryOfCargo)11,(categoryOfCargo)12,(categoryOfCargo)13,(categoryOfCargo)14,(categoryOfCargo)15];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public AnchorageAreaViewModel Load(AnchorageArea instance) {
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
		[Editor(typeof(Editors.HorizonEditor<LateralBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		[Category("LateralBuoy")]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		private String? _interoperabilityIdentifier  = default;

		[Category("LateralBuoy")]
		[Editor(typeof(Editors.HorizonEditor<LateralBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LateralBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		[Category("LateralBuoy")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("LateralBuoy")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Category("LateralBuoy")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)5,(status)7,(status)8,(status)18];

		private categoryOfLateralMark? _categoryOfLateralMark  = default;

		[Category("LateralBuoy")]
		[Editor(typeof(Editors.HorizonEditor<LateralBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public categoryOfLateralMark? categoryOfLateralMark {
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
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		private colourPattern? _colourPattern  = default;

		[Category("LateralBuoy")]
		[Editor(typeof(Editors.HorizonEditor<LateralBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private buoyShape? _buoyShape  = default;

		[Category("LateralBuoy")]
		[Editor(typeof(Editors.HorizonEditor<LateralBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public buoyShape? buoyShape {
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LateralBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("LateralBuoy")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)11];

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("LateralBuoy")]
		[Editor(typeof(Editors.HorizonEditor<LateralBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		private double? _verticalLength  = default;

		[Category("LateralBuoy")]
		[Editor(typeof(Editors.HorizonEditor<LateralBuoy>), typeof(Editors.HorizonEditor))]
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


		public LateralBuoyViewModel Load(LateralBuoy instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LateralBuoy._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LateralBuoy._featureBindingDefinitions;

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
		[Optional]
		public ObservableCollection<vesselSpeedLimitViewModel> vesselSpeedLimit  { get; set; } = new ();

		private String? _interoperabilityIdentifier  = default;

		[Category("TrafficSeparationSchemeRoundabout")]
		[Editor(typeof(Editors.HorizonEditor<TrafficSeparationSchemeRoundabout>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<TrafficSeparationSchemeRoundabout>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("TrafficSeparationSchemeRoundabout")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("TrafficSeparationSchemeRoundabout")]
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

		[Category("TrafficSeparationSchemeRoundabout")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)3,(status)6,(status)9];

		private String? _reportedDate  = default;

		[Category("TrafficSeparationSchemeRoundabout")]
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

		[Category("TrafficSeparationSchemeRoundabout")]
		[Optional]
		public ObservableCollection<restriction> restriction  { get; set; } = new ();

		[Browsable(false)]
		public restriction[] restrictionList => [(restriction)1,(restriction)2,(restriction)3,(restriction)4,(restriction)5,(restriction)6,(restriction)8,(restriction)9,(restriction)10,(restriction)11,(restriction)12,(restriction)13,(restriction)16,(restriction)17,(restriction)18,(restriction)19,(restriction)20,(restriction)21,(restriction)22,(restriction)23,(restriction)24,(restriction)25,(restriction)27];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public TrafficSeparationSchemeRoundaboutViewModel Load(TrafficSeparationSchemeRoundabout instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. TrafficSeparationSchemeRoundabout._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeRoundabout._featureBindingDefinitions;

		public TrafficSeparationSchemeRoundaboutViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public TrafficSeparationSchemeRoundaboutViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1,(qualityOfVerticalMeasurement)2,(qualityOfVerticalMeasurement)3,(qualityOfVerticalMeasurement)4,(qualityOfVerticalMeasurement)6,(qualityOfVerticalMeasurement)7];

		private double? _orientationValue  = default;

		[Category("DeepWaterRouteCentreline")]
		[Editor(typeof(Editors.HorizonEditor<DeepWaterRouteCentreline>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double? orientationValue {
			get {
				return _orientationValue;
			}
			set {
				SetValue(ref _orientationValue, value);
			}
		}

		[Category("DeepWaterRouteCentreline")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private trafficFlow? _trafficFlow  = default;

		[Category("DeepWaterRouteCentreline")]
		[Editor(typeof(Editors.HorizonEditor<DeepWaterRouteCentreline>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public trafficFlow? trafficFlow {
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<DeepWaterRouteCentreline>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("DeepWaterRouteCentreline")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)3,(status)6,(status)9];

		private Boolean? _imoAdopted  = default;

		[Category("DeepWaterRouteCentreline")]
		[Editor(typeof(Editors.HorizonEditor<DeepWaterRouteCentreline>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? imoAdopted {
			get {
				return _imoAdopted;
			}
			set {
				SetValue(ref _imoAdopted, value);
			}
		}

		[Category("DeepWaterRouteCentreline")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("DeepWaterRouteCentreline")]
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

		private String? _interoperabilityIdentifier  = default;

		[Category("DeepWaterRouteCentreline")]
		[Editor(typeof(Editors.HorizonEditor<DeepWaterRouteCentreline>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		private double? _depthRangeMinimumValue  = default;

		[Category("DeepWaterRouteCentreline")]
		[Editor(typeof(Editors.HorizonEditor<DeepWaterRouteCentreline>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? depthRangeMinimumValue {
			get {
				return _depthRangeMinimumValue;
			}
			set {
				SetValue(ref _depthRangeMinimumValue, value);
			}
		}

		private Boolean? _basedOnFixedMarks  = default;

		[Category("DeepWaterRouteCentreline")]
		[Editor(typeof(Editors.HorizonEditor<DeepWaterRouteCentreline>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public Boolean? basedOnFixedMarks {
			get {
				return _basedOnFixedMarks;
			}
			set {
				SetValue(ref _basedOnFixedMarks, value);
			}
		}

		[Category("DeepWaterRouteCentreline")]
		[Optional]
		public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1,(techniqueOfVerticalMeasurement)3,(techniqueOfVerticalMeasurement)5,(techniqueOfVerticalMeasurement)8,(techniqueOfVerticalMeasurement)9,(techniqueOfVerticalMeasurement)13,(techniqueOfVerticalMeasurement)15,(techniqueOfVerticalMeasurement)16,(techniqueOfVerticalMeasurement)17,(techniqueOfVerticalMeasurement)18];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public DeepWaterRouteCentrelineViewModel Load(DeepWaterRouteCentreline instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. DeepWaterRouteCentreline._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => DeepWaterRouteCentreline._featureBindingDefinitions;

		public DeepWaterRouteCentrelineViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public DeepWaterRouteCentrelineViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		private double? _verticalLength  = default;

		[Category("LightFloat")]
		[Editor(typeof(Editors.HorizonEditor<LightFloat>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		[Category("LightFloat")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)14,(status)16,(status)17];

		private colourPattern? _colourPattern  = default;

		[Category("LightFloat")]
		[Editor(typeof(Editors.HorizonEditor<LightFloat>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("LightFloat")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)11];

		[Category("LightFloat")]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		private double? _horizontalWidth  = default;

		[Category("LightFloat")]
		[Editor(typeof(Editors.HorizonEditor<LightFloat>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalWidth {
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
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		private double? _horizontalLength  = default;

		[Category("LightFloat")]
		[Editor(typeof(Editors.HorizonEditor<LightFloat>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? horizontalLength {
			get {
				return _horizontalLength;
			}
			set {
				SetValue(ref _horizontalLength, value);
			}
		}

		private visualProminence? _visualProminence  = default;

		[Category("LightFloat")]
		[Editor(typeof(Editors.HorizonEditor<LightFloat>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LightFloat>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LightFloat>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LightFloat>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public topmarkViewModel? topmark {
			get {
				return _topmark;
			}
			set {
				SetValue(ref _topmark, value);
			}
		}

		[Category("LightFloat")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("LightFloat")]
		[Editor(typeof(Editors.HorizonEditor<LightFloat>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("LightFloat")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public LightFloatViewModel Load(LightFloat instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LightFloat._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LightFloat._featureBindingDefinitions;

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
		private double? _verticalLength  = default;

		[Category("LightAllAround")]
		[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("LightAllAround")]
		[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private double? _valueOfNominalRange  = default;

		[Category("LightAllAround")]
		[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? valueOfNominalRange {
			get {
				return _valueOfNominalRange;
			}
			set {
				SetValue(ref _valueOfNominalRange, value);
			}
		}

		private String? _interoperabilityIdentifier  = default;

		[Category("LightAllAround")]
		[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("LightAllAround")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)6,(status)7,(status)8,(status)11,(status)14,(status)15,(status)16,(status)17];

		private fixedDateRangeViewModel? _fixedDateRange  = default;

		[Category("LightAllAround")]
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

		private int? _scaleMinimum  = default;

		[Category("LightAllAround")]
		[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private multiplicityOfFeaturesViewModel? _multiplicityOfFeatures  = default;

		[Category("LightAllAround")]
		[ExpandableObject]
		[Mandatory]
		public multiplicityOfFeaturesViewModel? multiplicityOfFeatures {
			get {
				return _multiplicityOfFeatures;
			}
			set {
				SetValue(ref _multiplicityOfFeatures, value);
			}
		}

		private exhibitionConditionOfLight? _exhibitionConditionOfLight  = default;

		[Category("LightAllAround")]
		[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private double? _height  = default;

		[Category("LightAllAround")]
		[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private double? _relativeHorizontalAccuracy  = default;

		[Category("LightAllAround")]
		[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? relativeHorizontalAccuracy {
			get {
				return _relativeHorizontalAccuracy;
			}
			set {
				SetValue(ref _relativeHorizontalAccuracy, value);
			}
		}

		private verticalDatum? _verticalDatum  = default;

		[Category("LightAllAround")]
		[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private Boolean? _majorLight  = default;

		[Category("LightAllAround")]
		[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LightAllAround>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<categoryOfLight> categoryOfLight  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfLight[] categoryOfLightList => [(categoryOfLight)4,(categoryOfLight)5,(categoryOfLight)8,(categoryOfLight)9,(categoryOfLight)10,(categoryOfLight)11,(categoryOfLight)12,(categoryOfLight)13,(categoryOfLight)14,(categoryOfLight)15,(categoryOfLight)17,(categoryOfLight)18,(categoryOfLight)19,(categoryOfLight)20];

		private rythmOfLightViewModel? _rythmOfLight  = default;

		[Category("LightAllAround")]
		[ExpandableObject]
		[Mandatory]
		public rythmOfLightViewModel? rythmOfLight {
			get {
				return _rythmOfLight;
			}
			set {
				SetValue(ref _rythmOfLight, value);
			}
		}

		[Category("LightAllAround")]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)3,(colour)4,(colour)5,(colour)6,(colour)9,(colour)10,(colour)11];

		[Category("LightAllAround")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("LightAllAround")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public LightAllAroundViewModel Load(LightAllAround instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LightAllAround._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LightAllAround._featureBindingDefinitions;

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
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)6,(colour)7,(colour)8,(colour)11,(colour)13];

		[Category("Coastline")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private categoryOfCoastline? _categoryOfCoastline  = default;

		[Category("Coastline")]
		[Editor(typeof(Editors.HorizonEditor<Coastline>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private double? _elevation  = default;

		[Category("Coastline")]
		[Editor(typeof(Editors.HorizonEditor<Coastline>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? elevation {
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Coastline>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("Coastline")]
		[Optional]
		public ObservableCollection<natureOfSurface> natureOfSurface  { get; set; } = new ();

		[Browsable(false)]
		public natureOfSurface[] natureOfSurfaceList => [(natureOfSurface)1,(natureOfSurface)2,(natureOfSurface)3,(natureOfSurface)4,(natureOfSurface)5,(natureOfSurface)6,(natureOfSurface)7,(natureOfSurface)8,(natureOfSurface)9,(natureOfSurface)11,(natureOfSurface)14,(natureOfSurface)17];

		[Category("Coastline")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private visualProminence? _visualProminence  = default;

		[Category("Coastline")]
		[Editor(typeof(Editors.HorizonEditor<Coastline>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Coastline>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("Coastline")]
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

		private Boolean? _radarConspicuous  = default;

		[Category("Coastline")]
		[Editor(typeof(Editors.HorizonEditor<Coastline>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public CoastlineViewModel Load(Coastline instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Coastline._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Coastline._featureBindingDefinitions;

		public CoastlineViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public CoastlineViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Editor(typeof(Editors.HorizonEditor<SeaAreaNamedWaterArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private String? _reportedDate  = default;

		[Category("SeaAreaNamedWaterArea")]
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

		[Category("SeaAreaNamedWaterArea")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private gradient? _gradient  = default;

		[Category("SeaAreaNamedWaterArea")]
		[Editor(typeof(Editors.HorizonEditor<SeaAreaNamedWaterArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<SeaAreaNamedWaterArea>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<SeaAreaNamedWaterArea>), typeof(Editors.HorizonEditor))]
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
		public qualityOfHorizontalMeasurement[] qualityOfHorizontalMeasurementList => [(qualityOfHorizontalMeasurement)4];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public SeaAreaNamedWaterAreaViewModel Load(SeaAreaNamedWaterArea instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SeaAreaNamedWaterArea._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SeaAreaNamedWaterArea._featureBindingDefinitions;

		public SeaAreaNamedWaterAreaViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SeaAreaNamedWaterAreaViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public DropZoneViewModel Load(DropZone instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. DropZone._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => DropZone._featureBindingDefinitions;

		public DropZoneViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public DropZoneViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Editor(typeof(Editors.HorizonEditor<Conveyor>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private condition? _condition  = default;

		[Category("Conveyor")]
		[Editor(typeof(Editors.HorizonEditor<Conveyor>), typeof(Editors.HorizonEditor))]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)5];

		private String? _reportedDate  = default;

		[Category("Conveyor")]
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

		[Category("Conveyor")]
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("Conveyor")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private visualProminence? _visualProminence  = default;

		[Category("Conveyor")]
		[Editor(typeof(Editors.HorizonEditor<Conveyor>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private double? _height  = default;

		[Category("Conveyor")]
		[Editor(typeof(Editors.HorizonEditor<Conveyor>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private Boolean? _radarConspicuous  = default;

		[Category("Conveyor")]
		[Editor(typeof(Editors.HorizonEditor<Conveyor>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public multiplicityOfFeaturesViewModel? multiplicityOfFeatures {
			get {
				return _multiplicityOfFeatures;
			}
			set {
				SetValue(ref _multiplicityOfFeatures, value);
			}
		}

		[Category("Conveyor")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)4,(status)12];

		private double? _liftingCapacity  = default;

		[Category("Conveyor")]
		[Editor(typeof(Editors.HorizonEditor<Conveyor>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? liftingCapacity {
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Conveyor>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Conveyor>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Conveyor>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<Conveyor>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		[Category("Conveyor")]
		[Optional]
		public ObservableCollection<product> product  { get; set; } = new ();

		[Browsable(false)]
		public product[] productList => [(product)4,(product)5,(product)6,(product)10,(product)11,(product)12,(product)13,(product)14,(product)15,(product)16,(product)17,(product)22,(product)25];

		private double? _verticalLength  = default;

		[Category("Conveyor")]
		[Editor(typeof(Editors.HorizonEditor<Conveyor>), typeof(Editors.HorizonEditor))]
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


		public ConveyorViewModel Load(Conveyor instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Conveyor._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Conveyor._featureBindingDefinitions;

		public ConveyorViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public ConveyorViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Multiplicity(1)]
		public ObservableCollection<String> nationalMaritimeAuthority  { get; set; } = new ();

		private boundaryStatusType? _boundaryStatusType  = default;

		[Category("LineOfDelimitation")]
		[Editor(typeof(Editors.HorizonEditor<LineOfDelimitation>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private String? _reportedDate  = default;

		[Category("LineOfDelimitation")]
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

		private sourceIdentificationViewModel? _sourceIdentification  = default;

		[Category("LineOfDelimitation")]
		[ExpandableObject]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LineOfDelimitation>), typeof(Editors.HorizonEditor))]
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

		private categoryofBoundaryLine? _categoryofBoundaryLine  = default;

		[Category("LineOfDelimitation")]
		[Editor(typeof(Editors.HorizonEditor<LineOfDelimitation>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<LineOfDelimitation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? inDispute {
			get {
				return _inDispute;
			}
			set {
				SetValue(ref _inDispute, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public LineOfDelimitationViewModel Load(LineOfDelimitation instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LineOfDelimitation._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LineOfDelimitation._featureBindingDefinitions;

		public LineOfDelimitationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public LineOfDelimitationViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		private String? _nationality  = default;

		[Category("StraightTerritorialSeaBaseline")]
		[Editor(typeof(Editors.HorizonEditor<StraightTerritorialSeaBaseline>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String? nationality {
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
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("StraightTerritorialSeaBaseline")]
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

		[Category("StraightTerritorialSeaBaseline")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private status? _status  = default;

		[Category("StraightTerritorialSeaBaseline")]
		[Editor(typeof(Editors.HorizonEditor<StraightTerritorialSeaBaseline>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<StraightTerritorialSeaBaseline>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<StraightTerritorialSeaBaseline>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<StraightTerritorialSeaBaseline>), typeof(Editors.HorizonEditor))]
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

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public StraightTerritorialSeaBaselineViewModel Load(StraightTerritorialSeaBaseline instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. StraightTerritorialSeaBaseline._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => StraightTerritorialSeaBaseline._featureBindingDefinitions;

		public StraightTerritorialSeaBaselineViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public StraightTerritorialSeaBaselineViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("SafeWaterBeacon")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private double? _elevation  = default;

		[Category("SafeWaterBeacon")]
		[Editor(typeof(Editors.HorizonEditor<SafeWaterBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}

		private int? _scaleMinimum  = default;

		[Category("SafeWaterBeacon")]
		[Editor(typeof(Editors.HorizonEditor<SafeWaterBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private double? _height  = default;

		[Category("SafeWaterBeacon")]
		[Editor(typeof(Editors.HorizonEditor<SafeWaterBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
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
		[Optional]
		public topmarkViewModel? topmark {
			get {
				return _topmark;
			}
			set {
				SetValue(ref _topmark, value);
			}
		}

		[Category("SafeWaterBeacon")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8];

		private Boolean? _radarConspicuous  = default;

		[Category("SafeWaterBeacon")]
		[Editor(typeof(Editors.HorizonEditor<SafeWaterBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private String? _reportedDate  = default;

		[Category("SafeWaterBeacon")]
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

		private condition? _condition  = default;

		[Category("SafeWaterBeacon")]
		[Editor(typeof(Editors.HorizonEditor<SafeWaterBeacon>), typeof(Editors.HorizonEditor))]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)5];

		private colourPattern? _colourPattern  = default;

		[Category("SafeWaterBeacon")]
		[Editor(typeof(Editors.HorizonEditor<SafeWaterBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public fixedDateRangeViewModel? fixedDateRange {
			get {
				return _fixedDateRange;
			}
			set {
				SetValue(ref _fixedDateRange, value);
			}
		}

		private double? _verticalLength  = default;

		[Category("SafeWaterBeacon")]
		[Editor(typeof(Editors.HorizonEditor<SafeWaterBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private beaconShape? _beaconShape  = default;

		[Category("SafeWaterBeacon")]
		[Editor(typeof(Editors.HorizonEditor<SafeWaterBeacon>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public beaconShape? beaconShape {
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
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)5,(status)7,(status)8,(status)12,(status)18];

		private String? _pictorialRepresentation  = default;

		[Category("SafeWaterBeacon")]
		[Editor(typeof(Editors.HorizonEditor<SafeWaterBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<SafeWaterBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<SafeWaterBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		[Category("SafeWaterBeacon")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Category("SafeWaterBeacon")]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		private visualProminence? _visualProminence  = default;

		[Category("SafeWaterBeacon")]
		[Editor(typeof(Editors.HorizonEditor<SafeWaterBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public SafeWaterBeaconViewModel Load(SafeWaterBeacon instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SafeWaterBeacon._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SafeWaterBeacon._featureBindingDefinitions;

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
		[Optional]
		public sourceIdentificationViewModel? sourceIdentification {
			get {
				return _sourceIdentification;
			}
			set {
				SetValue(ref _sourceIdentification, value);
			}
		}

		[Category("SpecialPurposeGeneralBeacon")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("SpecialPurposeGeneralBeacon")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)4,(status)5,(status)7,(status)8,(status)12,(status)18];

		[Category("SpecialPurposeGeneralBeacon")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8];

		private String? _interoperabilityIdentifier  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		[Editor(typeof(Editors.HorizonEditor<SpecialPurposeGeneralBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<SpecialPurposeGeneralBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public int? scaleMinimum {
			get {
				return _scaleMinimum;
			}
			set {
				SetValue(ref _scaleMinimum, value);
			}
		}

		private double? _height  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		[Editor(typeof(Editors.HorizonEditor<SpecialPurposeGeneralBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		private condition? _condition  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		[Editor(typeof(Editors.HorizonEditor<SpecialPurposeGeneralBeacon>), typeof(Editors.HorizonEditor))]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)5];

		private double? _verticalLength  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		[Editor(typeof(Editors.HorizonEditor<SpecialPurposeGeneralBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private double? _elevation  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		[Editor(typeof(Editors.HorizonEditor<SpecialPurposeGeneralBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? elevation {
			get {
				return _elevation;
			}
			set {
				SetValue(ref _elevation, value);
			}
		}

		private colourPattern? _colourPattern  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		[Editor(typeof(Editors.HorizonEditor<SpecialPurposeGeneralBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<SpecialPurposeGeneralBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<SpecialPurposeGeneralBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private beaconShape? _beaconShape  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		[Editor(typeof(Editors.HorizonEditor<SpecialPurposeGeneralBeacon>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public beaconShape? beaconShape {
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
		[Optional]
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
		[Optional]
		public topmarkViewModel? topmark {
			get {
				return _topmark;
			}
			set {
				SetValue(ref _topmark, value);
			}
		}

		[Category("SpecialPurposeGeneralBeacon")]
		[Multiplicity(1)]
		public ObservableCollection<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfSpecialPurposeMark[] categoryOfSpecialPurposeMarkList => [(categoryOfSpecialPurposeMark)1,(categoryOfSpecialPurposeMark)2,(categoryOfSpecialPurposeMark)3,(categoryOfSpecialPurposeMark)4,(categoryOfSpecialPurposeMark)5,(categoryOfSpecialPurposeMark)6,(categoryOfSpecialPurposeMark)7,(categoryOfSpecialPurposeMark)8,(categoryOfSpecialPurposeMark)10,(categoryOfSpecialPurposeMark)11,(categoryOfSpecialPurposeMark)12,(categoryOfSpecialPurposeMark)14,(categoryOfSpecialPurposeMark)16,(categoryOfSpecialPurposeMark)17,(categoryOfSpecialPurposeMark)18,(categoryOfSpecialPurposeMark)19,(categoryOfSpecialPurposeMark)20,(categoryOfSpecialPurposeMark)21,(categoryOfSpecialPurposeMark)22,(categoryOfSpecialPurposeMark)23,(categoryOfSpecialPurposeMark)24,(categoryOfSpecialPurposeMark)25,(categoryOfSpecialPurposeMark)26,(categoryOfSpecialPurposeMark)27,(categoryOfSpecialPurposeMark)28,(categoryOfSpecialPurposeMark)29,(categoryOfSpecialPurposeMark)30,(categoryOfSpecialPurposeMark)31,(categoryOfSpecialPurposeMark)32,(categoryOfSpecialPurposeMark)33,(categoryOfSpecialPurposeMark)34,(categoryOfSpecialPurposeMark)35,(categoryOfSpecialPurposeMark)36,(categoryOfSpecialPurposeMark)37,(categoryOfSpecialPurposeMark)39,(categoryOfSpecialPurposeMark)40,(categoryOfSpecialPurposeMark)41,(categoryOfSpecialPurposeMark)42,(categoryOfSpecialPurposeMark)43,(categoryOfSpecialPurposeMark)44,(categoryOfSpecialPurposeMark)45,(categoryOfSpecialPurposeMark)46,(categoryOfSpecialPurposeMark)47,(categoryOfSpecialPurposeMark)48,(categoryOfSpecialPurposeMark)49,(categoryOfSpecialPurposeMark)50,(categoryOfSpecialPurposeMark)51,(categoryOfSpecialPurposeMark)52,(categoryOfSpecialPurposeMark)53,(categoryOfSpecialPurposeMark)54,(categoryOfSpecialPurposeMark)55,(categoryOfSpecialPurposeMark)56,(categoryOfSpecialPurposeMark)57,(categoryOfSpecialPurposeMark)58,(categoryOfSpecialPurposeMark)60,(categoryOfSpecialPurposeMark)61,(categoryOfSpecialPurposeMark)62,(categoryOfSpecialPurposeMark)63];

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		[Editor(typeof(Editors.HorizonEditor<SpecialPurposeGeneralBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		private String? _reportedDate  = default;

		[Category("SpecialPurposeGeneralBeacon")]
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

		private visualProminence? _visualProminence  = default;

		[Category("SpecialPurposeGeneralBeacon")]
		[Editor(typeof(Editors.HorizonEditor<SpecialPurposeGeneralBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("SpecialPurposeGeneralBeacon")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		[Category("SpecialPurposeGeneralBeacon")]
		[Optional]
		public ObservableCollection<periodicDateRangeViewModel> periodicDateRange  { get; set; } = new ();

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public SpecialPurposeGeneralBeaconViewModel Load(SpecialPurposeGeneralBeacon instance) {
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
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SpecialPurposeGeneralBeacon._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SpecialPurposeGeneralBeacon._featureBindingDefinitions;

		public SpecialPurposeGeneralBeaconViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SpecialPurposeGeneralBeaconViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

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



	public static class InformationBindingExtension {
		public static ReferenceToAPublicationViewModel LoadInformationBinding(this ReferenceToAPublicationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static InstallationBuoyViewModel LoadInformationBinding(this InstallationBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DepthAreaViewModel LoadInformationBinding(this DepthAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RadioCallingInPointViewModel LoadInformationBinding(this RadioCallingInPointViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static PatrolAreaViewModel LoadInformationBinding(this PatrolAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static CheckpointViewModel LoadInformationBinding(this CheckpointViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static MarineManagementAreaViewModel LoadInformationBinding(this MarineManagementAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DepthContourViewModel LoadInformationBinding(this DepthContourViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static EnvironmentallySensitiveSeaAreaViewModel LoadInformationBinding(this EnvironmentallySensitiveSeaAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RoadViewModel LoadInformationBinding(this RoadViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RiverViewModel LoadInformationBinding(this RiverViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static MilitaryPracticeAreaViewModel LoadInformationBinding(this MilitaryPracticeAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DiscolouredWaterViewModel LoadInformationBinding(this DiscolouredWaterViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static CardinalBuoyViewModel LoadInformationBinding(this CardinalBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SafeWaterBuoyViewModel LoadInformationBinding(this SafeWaterBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RadioStationViewModel LoadInformationBinding(this RadioStationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static MilitaryExerciseAirspaceViewModel LoadInformationBinding(this MilitaryExerciseAirspaceViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static ContiguousZoneViewModel LoadInformationBinding(this ContiguousZoneViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static NormalBaselineViewModel LoadInformationBinding(this NormalBaselineViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static CableAreaViewModel LoadInformationBinding(this CableAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static ContinentalShelfAreaViewModel LoadInformationBinding(this ContinentalShelfAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static InternalWatersViewModel LoadInformationBinding(this InternalWatersViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static AdministrationAreaViewModel LoadInformationBinding(this AdministrationAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static BollardViewModel LoadInformationBinding(this BollardViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DolphinViewModel LoadInformationBinding(this DolphinViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RadarRangeViewModel LoadInformationBinding(this RadarRangeViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static IsolatedDangerBeaconViewModel LoadInformationBinding(this IsolatedDangerBeaconViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static IsolatedDangerBuoyViewModel LoadInformationBinding(this IsolatedDangerBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SubmarineTransitLaneViewModel LoadInformationBinding(this SubmarineTransitLaneViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static MaritimeSafetyInformationAreaViewModel LoadInformationBinding(this MaritimeSafetyInformationAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static AirspaceRestrictionViewModel LoadInformationBinding(this AirspaceRestrictionViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SoundingViewModel LoadInformationBinding(this SoundingViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static TrafficSeparationSchemeBoundaryViewModel LoadInformationBinding(this TrafficSeparationSchemeBoundaryViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DumpingGroundViewModel LoadInformationBinding(this DumpingGroundViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static AirportAirfieldViewModel LoadInformationBinding(this AirportAirfieldViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static FoulGroundViewModel LoadInformationBinding(this FoulGroundViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LightAirObstructionViewModel LoadInformationBinding(this LightAirObstructionViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static MooringBuoyViewModel LoadInformationBinding(this MooringBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static UnderwaterAwashRockViewModel LoadInformationBinding(this UnderwaterAwashRockViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static CableOverheadViewModel LoadInformationBinding(this CableOverheadViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static ControlledAirspaceViewModel LoadInformationBinding(this ControlledAirspaceViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static ObstructionViewModel LoadInformationBinding(this ObstructionViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static FishingGroundViewModel LoadInformationBinding(this FishingGroundViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static FishingFacilityViewModel LoadInformationBinding(this FishingFacilityViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static NavigationSystemViewModel LoadInformationBinding(this NavigationSystemViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static TrafficSeparationSchemeCrossingViewModel LoadInformationBinding(this TrafficSeparationSchemeCrossingViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static TrafficSeparationSchemeLanePartViewModel LoadInformationBinding(this TrafficSeparationSchemeLanePartViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static TerritorialSeaAreaViewModel LoadInformationBinding(this TerritorialSeaAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LateralBeaconViewModel LoadInformationBinding(this LateralBeaconViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static CoastGuardStationViewModel LoadInformationBinding(this CoastGuardStationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SeparationZoneOrLineViewModel LoadInformationBinding(this SeparationZoneOrLineViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static BottomFeatureViewModel LoadInformationBinding(this BottomFeatureViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static ArchipelagicBaselineViewModel LoadInformationBinding(this ArchipelagicBaselineViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SmallBottomObjectViewModel LoadInformationBinding(this SmallBottomObjectViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static ExclusiveEconomicZoneViewModel LoadInformationBinding(this ExclusiveEconomicZoneViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RadarStationViewModel LoadInformationBinding(this RadarStationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DivingLocationViewModel LoadInformationBinding(this DivingLocationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RestrictedAreaViewModel LoadInformationBinding(this RestrictedAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static CableSubmarineViewModel LoadInformationBinding(this CableSubmarineViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static WreckViewModel LoadInformationBinding(this WreckViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static QRouteViewModel LoadInformationBinding(this QRouteViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static CompletenessOfProductSpecificationViewModel LoadInformationBinding(this CompletenessOfProductSpecificationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RescueStationViewModel LoadInformationBinding(this RescueStationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static CardinalBeaconViewModel LoadInformationBinding(this CardinalBeaconViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LightVesselViewModel LoadInformationBinding(this LightVesselViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static FisheryZoneViewModel LoadInformationBinding(this FisheryZoneViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DredgedAreaViewModel LoadInformationBinding(this DredgedAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static FerryRouteViewModel LoadInformationBinding(this FerryRouteViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static ShorelineConstructionViewModel LoadInformationBinding(this ShorelineConstructionViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static CautionAreaViewModel LoadInformationBinding(this CautionAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DeepWaterRoutePartViewModel LoadInformationBinding(this DeepWaterRoutePartViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static CurrentNonGravitationalViewModel LoadInformationBinding(this CurrentNonGravitationalViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DataCoverageViewModel LoadInformationBinding(this DataCoverageViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SeabedAreaViewModel LoadInformationBinding(this SeabedAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SpecialPurposeGeneralBuoyViewModel LoadInformationBinding(this SpecialPurposeGeneralBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LightSectoredViewModel LoadInformationBinding(this LightSectoredViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static IceLineViewModel LoadInformationBinding(this IceLineViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static AnchorageAreaViewModel LoadInformationBinding(this AnchorageAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LateralBuoyViewModel LoadInformationBinding(this LateralBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static TrafficSeparationSchemeRoundaboutViewModel LoadInformationBinding(this TrafficSeparationSchemeRoundaboutViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DeepWaterRouteCentrelineViewModel LoadInformationBinding(this DeepWaterRouteCentrelineViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LightFloatViewModel LoadInformationBinding(this LightFloatViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LightAllAroundViewModel LoadInformationBinding(this LightAllAroundViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static CoastlineViewModel LoadInformationBinding(this CoastlineViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SeaAreaNamedWaterAreaViewModel LoadInformationBinding(this SeaAreaNamedWaterAreaViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DropZoneViewModel LoadInformationBinding(this DropZoneViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static ConveyorViewModel LoadInformationBinding(this ConveyorViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LineOfDelimitationViewModel LoadInformationBinding(this LineOfDelimitationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static StraightTerritorialSeaBaselineViewModel LoadInformationBinding(this StraightTerritorialSeaBaselineViewModel instance, informationBinding[] bindings) {
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

	}

	public static class FeatureBindingExtension {
		public static InstallationBuoyViewModel LoadFeatureBinding(this InstallationBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static DepthAreaViewModel LoadFeatureBinding(this DepthAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static RadioCallingInPointViewModel LoadFeatureBinding(this RadioCallingInPointViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static PatrolAreaViewModel LoadFeatureBinding(this PatrolAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static CheckpointViewModel LoadFeatureBinding(this CheckpointViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static MarineManagementAreaViewModel LoadFeatureBinding(this MarineManagementAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static DepthContourViewModel LoadFeatureBinding(this DepthContourViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static EnvironmentallySensitiveSeaAreaViewModel LoadFeatureBinding(this EnvironmentallySensitiveSeaAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static RoadViewModel LoadFeatureBinding(this RoadViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static RiverViewModel LoadFeatureBinding(this RiverViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static MilitaryPracticeAreaViewModel LoadFeatureBinding(this MilitaryPracticeAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static DiscolouredWaterViewModel LoadFeatureBinding(this DiscolouredWaterViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static CardinalBuoyViewModel LoadFeatureBinding(this CardinalBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static SafeWaterBuoyViewModel LoadFeatureBinding(this SafeWaterBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static RadioStationViewModel LoadFeatureBinding(this RadioStationViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static MilitaryExerciseAirspaceViewModel LoadFeatureBinding(this MilitaryExerciseAirspaceViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static ContiguousZoneViewModel LoadFeatureBinding(this ContiguousZoneViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static NormalBaselineViewModel LoadFeatureBinding(this NormalBaselineViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static CableAreaViewModel LoadFeatureBinding(this CableAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static ContinentalShelfAreaViewModel LoadFeatureBinding(this ContinentalShelfAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static InternalWatersViewModel LoadFeatureBinding(this InternalWatersViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static AdministrationAreaViewModel LoadFeatureBinding(this AdministrationAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static BollardViewModel LoadFeatureBinding(this BollardViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static DolphinViewModel LoadFeatureBinding(this DolphinViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static RadarRangeViewModel LoadFeatureBinding(this RadarRangeViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static IsolatedDangerBeaconViewModel LoadFeatureBinding(this IsolatedDangerBeaconViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static IsolatedDangerBuoyViewModel LoadFeatureBinding(this IsolatedDangerBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static SubmarineTransitLaneViewModel LoadFeatureBinding(this SubmarineTransitLaneViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static MaritimeSafetyInformationAreaViewModel LoadFeatureBinding(this MaritimeSafetyInformationAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static AirspaceRestrictionViewModel LoadFeatureBinding(this AirspaceRestrictionViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static SoundingViewModel LoadFeatureBinding(this SoundingViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static TrafficSeparationSchemeBoundaryViewModel LoadFeatureBinding(this TrafficSeparationSchemeBoundaryViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static DumpingGroundViewModel LoadFeatureBinding(this DumpingGroundViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static AirportAirfieldViewModel LoadFeatureBinding(this AirportAirfieldViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static FoulGroundViewModel LoadFeatureBinding(this FoulGroundViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LightAirObstructionViewModel LoadFeatureBinding(this LightAirObstructionViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static MooringBuoyViewModel LoadFeatureBinding(this MooringBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static UnderwaterAwashRockViewModel LoadFeatureBinding(this UnderwaterAwashRockViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static CableOverheadViewModel LoadFeatureBinding(this CableOverheadViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static ControlledAirspaceViewModel LoadFeatureBinding(this ControlledAirspaceViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static ObstructionViewModel LoadFeatureBinding(this ObstructionViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static FishingGroundViewModel LoadFeatureBinding(this FishingGroundViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static FishingFacilityViewModel LoadFeatureBinding(this FishingFacilityViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static NavigationSystemViewModel LoadFeatureBinding(this NavigationSystemViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static TrafficSeparationSchemeCrossingViewModel LoadFeatureBinding(this TrafficSeparationSchemeCrossingViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static TrafficSeparationSchemeLanePartViewModel LoadFeatureBinding(this TrafficSeparationSchemeLanePartViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static TerritorialSeaAreaViewModel LoadFeatureBinding(this TerritorialSeaAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LateralBeaconViewModel LoadFeatureBinding(this LateralBeaconViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static CoastGuardStationViewModel LoadFeatureBinding(this CoastGuardStationViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static SeparationZoneOrLineViewModel LoadFeatureBinding(this SeparationZoneOrLineViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static BottomFeatureViewModel LoadFeatureBinding(this BottomFeatureViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static ArchipelagicBaselineViewModel LoadFeatureBinding(this ArchipelagicBaselineViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static SmallBottomObjectViewModel LoadFeatureBinding(this SmallBottomObjectViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static ExclusiveEconomicZoneViewModel LoadFeatureBinding(this ExclusiveEconomicZoneViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static RadarStationViewModel LoadFeatureBinding(this RadarStationViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static DivingLocationViewModel LoadFeatureBinding(this DivingLocationViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static RestrictedAreaViewModel LoadFeatureBinding(this RestrictedAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static CableSubmarineViewModel LoadFeatureBinding(this CableSubmarineViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static WreckViewModel LoadFeatureBinding(this WreckViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static QRouteViewModel LoadFeatureBinding(this QRouteViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static CompletenessOfProductSpecificationViewModel LoadFeatureBinding(this CompletenessOfProductSpecificationViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static RescueStationViewModel LoadFeatureBinding(this RescueStationViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static CardinalBeaconViewModel LoadFeatureBinding(this CardinalBeaconViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LightVesselViewModel LoadFeatureBinding(this LightVesselViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static FisheryZoneViewModel LoadFeatureBinding(this FisheryZoneViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static DredgedAreaViewModel LoadFeatureBinding(this DredgedAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static FerryRouteViewModel LoadFeatureBinding(this FerryRouteViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static ShorelineConstructionViewModel LoadFeatureBinding(this ShorelineConstructionViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static CautionAreaViewModel LoadFeatureBinding(this CautionAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static DeepWaterRoutePartViewModel LoadFeatureBinding(this DeepWaterRoutePartViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static CurrentNonGravitationalViewModel LoadFeatureBinding(this CurrentNonGravitationalViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static DataCoverageViewModel LoadFeatureBinding(this DataCoverageViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static SeabedAreaViewModel LoadFeatureBinding(this SeabedAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static SpecialPurposeGeneralBuoyViewModel LoadFeatureBinding(this SpecialPurposeGeneralBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LightSectoredViewModel LoadFeatureBinding(this LightSectoredViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static IceLineViewModel LoadFeatureBinding(this IceLineViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static AnchorageAreaViewModel LoadFeatureBinding(this AnchorageAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LateralBuoyViewModel LoadFeatureBinding(this LateralBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static TrafficSeparationSchemeRoundaboutViewModel LoadFeatureBinding(this TrafficSeparationSchemeRoundaboutViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static DeepWaterRouteCentrelineViewModel LoadFeatureBinding(this DeepWaterRouteCentrelineViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LightFloatViewModel LoadFeatureBinding(this LightFloatViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LightAllAroundViewModel LoadFeatureBinding(this LightAllAroundViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static CoastlineViewModel LoadFeatureBinding(this CoastlineViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static SeaAreaNamedWaterAreaViewModel LoadFeatureBinding(this SeaAreaNamedWaterAreaViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static DropZoneViewModel LoadFeatureBinding(this DropZoneViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static ConveyorViewModel LoadFeatureBinding(this ConveyorViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LineOfDelimitationViewModel LoadFeatureBinding(this LineOfDelimitationViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static StraightTerritorialSeaBaselineViewModel LoadFeatureBinding(this StraightTerritorialSeaBaselineViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
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

	}

}
