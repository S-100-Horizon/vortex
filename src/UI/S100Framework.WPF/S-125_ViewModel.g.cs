using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ComponentModel;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S125;
using S100Framework.DomainModel.S125.ComplexAttributes;
using S100Framework.DomainModel.S125.InformationTypes;
using S100Framework.DomainModel.S125.FeatureTypes;
using S100Framework.DomainModel.S125.InformationAssociations;
using S100Framework.DomainModel.S125.FeatureAssociations;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using System.Text.Json;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.WPF.ViewModel.S125 {
	internal static class Bootstrap {
		public static AssociationViewModel CreateInformationAssociation(string type, string? name = default) => type switch {
			"Atonstatus" => new AtonstatusViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static AssociationViewModel CreateFeatureAssociation(string type, string? name = default) => type switch {
			"BuoyTopmark" => new BuoyTopmarkViewModel { Name = name },
			"StructureEquipment" => new StructureEquipmentViewModel { Name = name },
			"PhysicalAIS" => new PhysicalAISViewModel { Name = name },
			"SyntheticAIS" => new SyntheticAISViewModel { Name = name },
			"VirtualAIS" => new VirtualAISViewModel { Name = name },
			"AtonAggregations" => new AtonAggregationsViewModel { Name = name },
			"AtonAssociations" => new AtonAssociationsViewModel { Name = name },
			"RangeSystem" => new RangeSystemViewModel { Name = name },
			"DangerousFeatureAssociation" => new DangerousFeatureAssociationViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static InformationViewModel CreateInformationType(string type, string? name = default) => type switch {
			"AtonStatusInformation" => new AtonStatusInformationViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static FeatureViewModel CreateFeatureType(string type, string? name = default) => type switch {
			"Equipment" => new EquipmentViewModel { Name = name },
			"GenericBuoy" => new GenericBuoyViewModel { Name = name },
			"Pile" => new PileViewModel { Name = name },
			"SiloTank" => new SiloTankViewModel { Name = name },
			"CardinalBuoy" => new CardinalBuoyViewModel { Name = name },
			"EmergencyWreckMarkingBuoy" => new EmergencyWreckMarkingBuoyViewModel { Name = name },
			"InstallationBuoy" => new InstallationBuoyViewModel { Name = name },
			"IsolatedDangerBuoy" => new IsolatedDangerBuoyViewModel { Name = name },
			"LateralBuoy" => new LateralBuoyViewModel { Name = name },
			"LightFloat" => new LightFloatViewModel { Name = name },
			"LightVessel" => new LightVesselViewModel { Name = name },
			"MooringBuoy" => new MooringBuoyViewModel { Name = name },
			"OffshorePlatform" => new OffshorePlatformViewModel { Name = name },
			"SafeWaterBuoy" => new SafeWaterBuoyViewModel { Name = name },
			"SpecialPurposeGeneralBuoy" => new SpecialPurposeGeneralBuoyViewModel { Name = name },
			"NavigationLine" => new NavigationLineViewModel { Name = name },
			"RecommendedTrack" => new RecommendedTrackViewModel { Name = name },
			"VirtualAISAidToNavigation" => new VirtualAISAidToNavigationViewModel { Name = name },
			"Daymark" => new DaymarkViewModel { Name = name },
			"StructureObject" => new StructureObjectViewModel { Name = name },
			"FogSignal" => new FogSignalViewModel { Name = name },
			"RadarReflector" => new RadarReflectorViewModel { Name = name },
			"GenericBeacon" => new GenericBeaconViewModel { Name = name },
			"RadarTransponderBeacon" => new RadarTransponderBeaconViewModel { Name = name },
			"RadioStation" => new RadioStationViewModel { Name = name },
			"LightAirObstruction" => new LightAirObstructionViewModel { Name = name },
			"Retroreflector" => new RetroreflectorViewModel { Name = name },
			"LightAllAround" => new LightAllAroundViewModel { Name = name },
			"LightFogDetector" => new LightFogDetectorViewModel { Name = name },
			"LightSectored" => new LightSectoredViewModel { Name = name },
			"CardinalBeacon" => new CardinalBeaconViewModel { Name = name },
			"IsolatedDangerBeacon" => new IsolatedDangerBeaconViewModel { Name = name },
			"Landmark" => new LandmarkViewModel { Name = name },
			"LateralBeacon" => new LateralBeaconViewModel { Name = name },
			"Lighthouse" => new LighthouseViewModel { Name = name },
			"SafeWaterBeacon" => new SafeWaterBeaconViewModel { Name = name },
			"SpecialPurposeGeneralBeacon" => new SpecialPurposeGeneralBeaconViewModel { Name = name },
			"DangerousFeature" => new DangerousFeatureViewModel { Name = name },
			"AtonAssociation" => new AtonAssociationViewModel { Name = name },
			"AtonAggregation" => new AtonAggregationViewModel { Name = name },
			"Topmark" => new TopmarkViewModel { Name = name },
			"PhysicalAISAidToNavigation" => new PhysicalAISAidToNavigationViewModel { Name = name },
			"SyntheticAISAidToNavigation" => new SyntheticAISAidToNavigationViewModel { Name = name },
			_ or "" => throw new InvalidOperationException(),
		};

		public static ICollection<string> InformationAssociationBindings(string association, string role) => (association, role) switch {
			("Atonstatus", "Statuspart") => ["AtonStatusInformation"],
			_ => throw new InvalidOperationException(),
		};

		public static ICollection<string> FeatureAssociationBindings(string association, string role) => (association, role) switch {
			("AtonAggregations", "peerAtonAggregation") => ["AtonAggregation"],
			("AtonAssociations", "peerAtonAssociation") => ["AtonAssociation"],
			("StructureEquipment", "parent") => ["StructureObject"],
			("RangeSystem", "navigableTrack") => ["RecommendedTrack"],
			("RangeSystem", "navigationLine") => ["NavigationLine"],
			("StructureEquipment", "child") => ["Equipment"],
			("PhysicalAIS", "physicalAISbroadcastBy") => ["PhysicalAISAidToNavigation"],
			("SyntheticAIS", "syntheticAISbroadcastBy") => ["SyntheticAISAidToNavigation"],
			("VirtualAIS", "virtualAISbroadcastBy") => ["VirtualAISAidToNavigation"],
			("DangerousFeatureAssociation", "markingAton") => ["AtonAssociation"],
			("DangerousFeatureAssociation", "danger") => ["DangerousFeature"],
			("AtonAssociations", "atonAssociationBy") => ["AidsToNavigation"],
			("AtonAggregations", "atonAggregationBy") => ["AidsToNavigation"],
			("BuoyTopmark", "buoyPart") => ["GenericBuoy"],
			("PhysicalAIS", "physicalAISbroadcasts") => ["RadioStation"],
			("SyntheticAIS", "syntheticAISbroadcasts") => ["RadioStation"],
			("BuoyTopmark", "topmarkPart") => ["Topmark"],
			("VirtualAIS", "virtualAISbroadcasts") => ["RadioStation"],
			_ => throw new InvalidOperationException(),
		};
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
	/// A directional light is a light illuminating a sector of very narrow angle and intended to mark a direction to follow.
	/// </summary>
	[CategoryOrder("directionalCharacter",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class directionalCharacterViewModel : ComplexViewModel<directionalCharacter> {
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

		private orientationViewModel _orientation  = default;

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

		private S100Framework.DomainModel.S100.Time? _timeOfDayEnd  = default;

		[Editor(typeof(Editors.HorizonEditor<fixedDateRange>), typeof(Editors.HorizonEditor))]
		[Optional]
		public S100Framework.DomainModel.S100.Time? timeOfDayEnd {
			get {
				return _timeOfDayEnd;
			}
			set {
				SetValue(ref _timeOfDayEnd, value);
			}
		}

		private S100Framework.DomainModel.S100.Time? _timeOfDayStart  = default;

		[Editor(typeof(Editors.HorizonEditor<fixedDateRange>), typeof(Editors.HorizonEditor))]
		[Optional]
		public S100Framework.DomainModel.S100.Time? timeOfDayStart {
			get {
				return _timeOfDayStart;
			}
			set {
				SetValue(ref _timeOfDayStart, value);
			}
		}


		public fixedDateRangeViewModel Load(fixedDateRange instance) {
			dateEnd = instance.dateEnd;
			dateStart = instance.dateStart;
			timeOfDayEnd = instance.timeOfDayEnd;
			timeOfDayStart = instance.timeOfDayStart;
			return this;
		}

		public override string Serialize() {
			var instance = new fixedDateRange {
				dateEnd = this.dateEnd,
				dateStart = this.dateStart,
				timeOfDayEnd = this.timeOfDayEnd,
				timeOfDayStart = this.timeOfDayStart,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public fixedDateRange Model => new () {
			dateEnd = this._dateEnd,
			dateStart = this._dateStart,
			timeOfDayEnd = this._timeOfDayEnd,
			timeOfDayStart = this._timeOfDayStart,
		};

		public override string? ToString() => $"Fixed Date Range";
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

		private String _language  = string.Empty;

		[Editor(typeof(Editors.HorizonEditor<information>), typeof(Editors.HorizonEditor))]
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
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference.
	/// </summary>
	[CategoryOrder("lightSector",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class lightSectorViewModel : ComplexViewModel<lightSector> {
		[Multiplicity(1, 99)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

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

		[Multiplicity(0, 99)]
		public ObservableCollection<lightVisibility> lightVisibility  { get; set; } = new ();

		[Browsable(false)]
		public lightVisibility[] lightVisibilityList => [(lightVisibility)1,(lightVisibility)2,(lightVisibility)3,(lightVisibility)4,(lightVisibility)5,(lightVisibility)6,(lightVisibility)7,(lightVisibility)8,(lightVisibility)9];

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

		[Multiplicity(0, 99)]
		public ObservableCollection<sectorInformationViewModel> sectorInformation  { get; set; } = new ();

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
	[CategoryOrder("multiplicityOfFeatures",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class multiplicityOfFeaturesViewModel : ComplexViewModel<multiplicityOfFeatures> {
		private Boolean _multiplicityKnown  = false;

		[Editor(typeof(Editors.HorizonEditor<multiplicityOfFeatures>), typeof(Editors.HorizonEditor))]
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
	/// The angular distance measured from true north to the major axis of the feature.
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
	public partial class radarWaveLengthViewModel : ComplexViewModel<radarWaveLength> {
		private String _radarBand  = string.Empty;

		[Editor(typeof(Editors.HorizonEditor<radarWaveLength>), typeof(Editors.HorizonEditor))]
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

		[Editor(typeof(Editors.HorizonEditor<radarWaveLength>), typeof(Editors.HorizonEditor))]
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
	[CategoryOrder("rhythmOfLight",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class rhythmOfLightViewModel : ComplexViewModel<rhythmOfLight> {
		private lightCharacteristic _lightCharacteristic  = default;

		[Editor(typeof(Editors.HorizonEditor<rhythmOfLight>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public lightCharacteristic lightCharacteristic {
			get {
				return _lightCharacteristic;
			}
			set {
				SetValue(ref _lightCharacteristic, value);
			}
		}

		[Browsable(false)]
		public lightCharacteristic[] lightCharacteristicList => [(lightCharacteristic)1,(lightCharacteristic)2,(lightCharacteristic)3,(lightCharacteristic)4,(lightCharacteristic)5,(lightCharacteristic)6,(lightCharacteristic)7,(lightCharacteristic)8,(lightCharacteristic)9,(lightCharacteristic)10,(lightCharacteristic)11,(lightCharacteristic)12,(lightCharacteristic)13,(lightCharacteristic)14,(lightCharacteristic)15,(lightCharacteristic)16,(lightCharacteristic)17,(lightCharacteristic)18,(lightCharacteristic)19,(lightCharacteristic)20,(lightCharacteristic)25,(lightCharacteristic)26,(lightCharacteristic)27,(lightCharacteristic)28,(lightCharacteristic)29];

		[Multiplicity(0, 10)]
		public ObservableCollection<String> signalGroup  { get; set; } = new ();

		private double? _signalPeriod  = default;

		[Editor(typeof(Editors.HorizonEditor<rhythmOfLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? signalPeriod {
			get {
				return _signalPeriod;
			}
			set {
				SetValue(ref _signalPeriod, value);
			}
		}

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
	[CategoryOrder("sectorCharacteristics",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorCharacteristicsViewModel : ComplexViewModel<sectorCharacteristics> {
		private lightCharacteristic _lightCharacteristic  = default;

		[Editor(typeof(Editors.HorizonEditor<sectorCharacteristics>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public lightCharacteristic lightCharacteristic {
			get {
				return _lightCharacteristic;
			}
			set {
				SetValue(ref _lightCharacteristic, value);
			}
		}

		[Browsable(false)]
		public lightCharacteristic[] lightCharacteristicList => [(lightCharacteristic)1,(lightCharacteristic)2,(lightCharacteristic)3,(lightCharacteristic)4,(lightCharacteristic)5,(lightCharacteristic)6,(lightCharacteristic)7,(lightCharacteristic)8,(lightCharacteristic)9,(lightCharacteristic)10,(lightCharacteristic)11,(lightCharacteristic)12,(lightCharacteristic)13,(lightCharacteristic)14,(lightCharacteristic)15,(lightCharacteristic)16,(lightCharacteristic)17,(lightCharacteristic)18,(lightCharacteristic)19,(lightCharacteristic)20,(lightCharacteristic)25,(lightCharacteristic)26,(lightCharacteristic)27,(lightCharacteristic)28,(lightCharacteristic)29];

		[Multiplicity(1, 10)]
		public ObservableCollection<lightSectorViewModel> lightSector  { get; set; } = new ();

		[Multiplicity(0, 10)]
		public ObservableCollection<String> signalGroup  { get; set; } = new ();

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
	/// -
	/// </summary>
	[CategoryOrder("ObscuredSector",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ObscuredSectorViewModel : ComplexViewModel<ObscuredSector> {
		private sectorLimitViewModel _sectorLimit  = default;

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
	/// Additional textual information about a light sector.
	/// </summary>
	[CategoryOrder("sectorInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorInformationViewModel : ComplexViewModel<sectorInformation> {
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

		private String _text  = string.Empty;

		[Editor(typeof(Editors.HorizonEditor<sectorInformation>), typeof(Editors.HorizonEditor))]
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
	[CategoryOrder("sectorLimit",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorLimitViewModel : ComplexViewModel<sectorLimit> {
		private sectorLimitOneViewModel _sectorLimitOne  = default;

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
	[CategoryOrder("sectorLimitOne",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class sectorLimitOneViewModel : ComplexViewModel<sectorLimitOne> {
		private double _sectorBearing  = default;

		[Editor(typeof(Editors.HorizonEditor<sectorLimitOne>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double sectorBearing {
			get {
				return _sectorBearing;
			}
			set {
				SetValue(ref _sectorBearing, value);
			}
		}

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
	public partial class sectorLimitTwoViewModel : ComplexViewModel<sectorLimitTwo> {
		private double _sectorBearing  = default;

		[Editor(typeof(Editors.HorizonEditor<sectorLimitTwo>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public double sectorBearing {
			get {
				return _sectorBearing;
			}
			set {
				SetValue(ref _sectorBearing, value);
			}
		}

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
	/// The sequence of times occupied by intervals of light and eclipse for all light characteristics.
	/// </summary>
	[CategoryOrder("signalSequence",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class signalSequenceViewModel : ComplexViewModel<signalSequence> {
		private double _signalDuration  = default;

		[Editor(typeof(Editors.HorizonEditor<signalSequence>), typeof(Editors.HorizonEditor))]
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

		[Editor(typeof(Editors.HorizonEditor<signalSequence>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
	/// -
	/// </summary>
	[CategoryOrder("ChangeDetails",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class ChangeDetailsViewModel : ComplexViewModel<ChangeDetails> {
		private atonCommissioning? _atonCommissioning  = default;

		[Editor(typeof(Editors.HorizonEditor<ChangeDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Editor(typeof(Editors.HorizonEditor<ChangeDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Editor(typeof(Editors.HorizonEditor<ChangeDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Editor(typeof(Editors.HorizonEditor<ChangeDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Editor(typeof(Editors.HorizonEditor<ChangeDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Editor(typeof(Editors.HorizonEditor<ChangeDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Editor(typeof(Editors.HorizonEditor<ChangeDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Editor(typeof(Editors.HorizonEditor<ChangeDetails>), typeof(Editors.HorizonEditor))]
		[Optional]
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
	/// 
	/// </summary>
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
	/// A feature association for the binding between a navigation aid equipment feature and the structure that supports it.
	/// </summary>
	[CategoryOrder("StructureEquipment",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class StructureEquipmentViewModel : FeatureAssociationViewModel {


		public override string Serialize() {
			var instance = new StructureEquipment {
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		public override string? ToString() => $"Structure/Equipment";
	}



	/// <summary>
	/// 
	/// </summary>
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
	/// Navigation system limited in their positioning capability to coastal regions, or those systems limited to making landfall
	/// </summary>
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
	/// -
	/// </summary>
	[CategoryOrder("AtonStatusInformation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonStatusInformationViewModel : InformationViewModel<AtonStatusInformation> {
		private ChangeDetailsViewModel _ChangeDetails  = default;

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

		[Category("AtonStatusInformation")]
		[Editor(typeof(Editors.HorizonEditor<AtonStatusInformation>), typeof(Editors.HorizonEditor))]
		[Optional]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


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

		public override informationBindingDefinition[] informationBindingDefinitions => AtonStatusInformation._informationBindingDefinitions;

		public AtonStatusInformationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Aton Status Information";
	}



	/// <summary>
	/// The implements used in an operation or activity.
	/// </summary>
	[CategoryOrder("Equipment",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class EquipmentViewModel : FeatureViewModel<Equipment> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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


		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		#region FeatureBindings

		public class StructureEquipmentViewModel : ViewModelBase, IFeatureBinding {
			public StructureEquipmentViewModel() {
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

			private S125.StructureEquipmentViewModel _association = new();

			[ExpandableObject]
			public S125.StructureEquipmentViewModel association {
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
					association = "StructureEquipment",
					role = "parent",
					roleType = roleType.association,
					featureTypes = ["StructureObject"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<StructureEquipment> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = StructureEquipment,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<EquipmentViewModel.StructureEquipmentViewModel> StructureEquipments { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. StructureEquipments.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public EquipmentViewModel Load(Equipment instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Equipment {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Equipment Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Equipment._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Equipment._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Equipment._featureBindingDefinitions;

		public EquipmentViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public EquipmentViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Equipment";

		public EquipmentViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			StructureEquipments.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(StructureEquipments));
			};
		}
	}



	/// <summary>
	/// A floating object moored to the bottom in a particular (charted) place, as an aid to navigation or for other specific purposes.
	/// </summary>
	[CategoryOrder("GenericBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class GenericBuoyViewModel : FeatureViewModel<GenericBuoy> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private buoyShape _buoyShape  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private Boolean? _radarConspicuous  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)15];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private String? _typeOfBuoy  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		#region FeatureBindings

		public class BuoyTopmarkViewModel : ViewModelBase, IFeatureBinding {
			public BuoyTopmarkViewModel() {
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

			private S125.BuoyTopmarkViewModel _association = new();

			[ExpandableObject]
			public S125.BuoyTopmarkViewModel association {
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
					lower = 0,
					upper = default,
					association = "BuoyTopmark",
					role = "topmarkPart",
					roleType = roleType.association,
					featureTypes = ["Topmark"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<BuoyTopmark> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = BuoyTopmark,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<GenericBuoyViewModel.BuoyTopmarkViewModel> BuoyTopmarks { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. BuoyTopmarks.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public GenericBuoyViewModel Load(GenericBuoy instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
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
			typeOfBuoy = instance.typeOfBuoy;
			return this;
		}

		public override string Serialize() {
			var instance = new GenericBuoy {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				buoyShape = this.buoyShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
				typeOfBuoy = this.typeOfBuoy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public GenericBuoy Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => GenericBuoy._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. GenericBuoy._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => GenericBuoy._featureBindingDefinitions;

		public GenericBuoyViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public GenericBuoyViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Generic Buoy";

		public GenericBuoyViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
			BuoyTopmarks.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(BuoyTopmarks));
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
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private categoryOfPile? _categoryOfPile  = default;

		[Category("Pile")]
		[Editor(typeof(Editors.HorizonEditor<Pile>), typeof(Editors.HorizonEditor))]
		[Optional]
		public categoryOfPile? categoryOfPile {
			get {
				return _categoryOfPile;
			}
			set {
				SetValue(ref _categoryOfPile, value);
			}
		}

		[Browsable(false)]
		public categoryOfPile[] categoryOfPileList => [(categoryOfPile)1,(categoryOfPile)3,(categoryOfPile)4,(categoryOfPile)5,(categoryOfPile)6,(categoryOfPile)7,(categoryOfPile)8];

		[Category("Pile")]
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("Pile")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private visualProminence? _visualProminence  = default;

		[Category("Pile")]
		[Editor(typeof(Editors.HorizonEditor<Pile>), typeof(Editors.HorizonEditor))]
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

		[Category("Pile")]
		[Editor(typeof(Editors.HorizonEditor<Pile>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public PileViewModel Load(Pile instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			visualProminence = instance.visualProminence;
			height = instance.height;
			return this;
		}

		public override string Serialize() {
			var instance = new Pile {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				categoryOfPile = this.categoryOfPile,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				visualProminence = this.visualProminence,
				height = this.height,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Pile Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			categoryOfPile = this._categoryOfPile,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			visualProminence = this._visualProminence,
			height = this._height,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Pile._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Pile._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Pile._featureBindingDefinitions;

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
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			colourPattern.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colourPattern));
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
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private buildingShape? _buildingShape  = default;

		[Category("SiloTank")]
		[Editor(typeof(Editors.HorizonEditor<SiloTank>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Editor(typeof(Editors.HorizonEditor<SiloTank>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("SiloTank")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private Boolean? _radarConspicuous  = default;

		[Category("SiloTank")]
		[Editor(typeof(Editors.HorizonEditor<SiloTank>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private visualProminence? _visualProminence  = default;

		[Category("SiloTank")]
		[Editor(typeof(Editors.HorizonEditor<SiloTank>), typeof(Editors.HorizonEditor))]
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

		[Category("SiloTank")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		[Category("SiloTank")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private double? _height  = default;

		[Category("SiloTank")]
		[Editor(typeof(Editors.HorizonEditor<SiloTank>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public SiloTankViewModel Load(SiloTank instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			visualProminence = instance.visualProminence;
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
			height = instance.height;
			return this;
		}

		public override string Serialize() {
			var instance = new SiloTank {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				buildingShape = this.buildingShape,
				categoryOfSiloTank = this.categoryOfSiloTank,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				visualProminence = this.visualProminence,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
				height = this.height,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SiloTank Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			buildingShape = this._buildingShape,
			categoryOfSiloTank = this._categoryOfSiloTank,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			visualProminence = this._visualProminence,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
			height = this._height,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => SiloTank._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SiloTank._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SiloTank._featureBindingDefinitions;

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
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private buoyShape _buoyShape  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private Boolean? _radarConspicuous  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)15];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private String? _typeOfBuoy  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}

		private categoryOfCardinalMark _categoryOfCardinalMark  = default;

		[Category("CardinalBuoy")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public CardinalBuoyViewModel Load(CardinalBuoy instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
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
			typeOfBuoy = instance.typeOfBuoy;
			categoryOfCardinalMark = instance.categoryOfCardinalMark;
			return this;
		}

		public override string Serialize() {
			var instance = new CardinalBuoy {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				buoyShape = this.buoyShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
				typeOfBuoy = this.typeOfBuoy,
				categoryOfCardinalMark = this.categoryOfCardinalMark,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CardinalBuoy Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
			categoryOfCardinalMark = this._categoryOfCardinalMark,
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
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
	/// An emergency wreck marking buoy is a buoy moored on or above a new wreck, designed to provide a prominent (both visual and radio) and easily identifiable temporary first response.
	/// </summary>
	[CategoryOrder("EmergencyWreckMarkingBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class EmergencyWreckMarkingBuoyViewModel : FeatureViewModel<EmergencyWreckMarkingBuoy> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private buoyShape _buoyShape  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private Boolean? _radarConspicuous  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)15];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private String? _typeOfBuoy  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}


		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public EmergencyWreckMarkingBuoyViewModel Load(EmergencyWreckMarkingBuoy instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
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
			typeOfBuoy = instance.typeOfBuoy;
			return this;
		}

		public override string Serialize() {
			var instance = new EmergencyWreckMarkingBuoy {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				buoyShape = this.buoyShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
				typeOfBuoy = this.typeOfBuoy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public EmergencyWreckMarkingBuoy Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => EmergencyWreckMarkingBuoy._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. EmergencyWreckMarkingBuoy._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => EmergencyWreckMarkingBuoy._featureBindingDefinitions;

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
	/// An installation buoy is a buoy used for loading tankers with gas or oil.
	/// </summary>
	[CategoryOrder("InstallationBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class InstallationBuoyViewModel : FeatureViewModel<InstallationBuoy> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private buoyShape _buoyShape  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private Boolean? _radarConspicuous  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)15];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private String? _typeOfBuoy  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}

		private categoryOfInstallationBuoy _categoryOfInstallationBuoy  = default;

		[Category("InstallationBuoy")]
		[Editor(typeof(Editors.HorizonEditor<InstallationBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public InstallationBuoyViewModel Load(InstallationBuoy instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
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
			typeOfBuoy = instance.typeOfBuoy;
			categoryOfInstallationBuoy = instance.categoryOfInstallationBuoy;
			return this;
		}

		public override string Serialize() {
			var instance = new InstallationBuoy {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				buoyShape = this.buoyShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
				typeOfBuoy = this.typeOfBuoy,
				categoryOfInstallationBuoy = this.categoryOfInstallationBuoy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public InstallationBuoy Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
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
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
	[CategoryOrder("IsolatedDangerBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class IsolatedDangerBuoyViewModel : FeatureViewModel<IsolatedDangerBuoy> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private buoyShape _buoyShape  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private Boolean? _radarConspicuous  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)15];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private String? _typeOfBuoy  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}


		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public IsolatedDangerBuoyViewModel Load(IsolatedDangerBuoy instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
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
			typeOfBuoy = instance.typeOfBuoy;
			return this;
		}

		public override string Serialize() {
			var instance = new IsolatedDangerBuoy {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				buoyShape = this.buoyShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
				typeOfBuoy = this.typeOfBuoy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public IsolatedDangerBuoy Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
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
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
	[CategoryOrder("LateralBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LateralBuoyViewModel : FeatureViewModel<LateralBuoy> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private buoyShape _buoyShape  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private Boolean? _radarConspicuous  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)15];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private String? _typeOfBuoy  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}

		private categoryOfLateralMark _categoryOfLateralMark  = default;

		[Category("LateralBuoy")]
		[Editor(typeof(Editors.HorizonEditor<LateralBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public LateralBuoyViewModel Load(LateralBuoy instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
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
			typeOfBuoy = instance.typeOfBuoy;
			categoryOfLateralMark = instance.categoryOfLateralMark;
			return this;
		}

		public override string Serialize() {
			var instance = new LateralBuoy {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				buoyShape = this.buoyShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
				typeOfBuoy = this.typeOfBuoy,
				categoryOfLateralMark = this.categoryOfLateralMark,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LateralBuoy Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
			categoryOfLateralMark = this._categoryOfLateralMark,
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
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
	/// A boat-like structure used instead of a light buoy in waters where strong streams or currents are experienced, or when a greater elevation than that of a light buoy is necessary.
	/// </summary>
	[CategoryOrder("LightFloat",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LightFloatViewModel : FeatureViewModel<LightFloat> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		[Category("LightFloat")]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("LightFloat")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

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

		[Category("LightFloat")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		[Category("LightFloat")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public LightFloatViewModel Load(LightFloat instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			visualProminence = instance.visualProminence;
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
			var instance = new LightFloat {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				visualProminence = this.visualProminence,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LightFloat Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			visualProminence = this._visualProminence,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
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
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		[Category("LightVessel")]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("LightVessel")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

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

		[Category("LightVessel")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		[Category("LightVessel")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public LightVesselViewModel Load(LightVessel instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			visualProminence = instance.visualProminence;
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
			var instance = new LightVessel {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				visualProminence = this.visualProminence,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LightVessel Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			visualProminence = this._visualProminence,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
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
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
	/// A buoy secured to the bottom by permanent moorings with means for mooring a vessel by use of its anchor chain or mooring lines.
	/// </summary>
	[CategoryOrder("MooringBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class MooringBuoyViewModel : FeatureViewModel<MooringBuoy> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private buoyShape _buoyShape  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private Boolean? _radarConspicuous  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)15];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private String? _typeOfBuoy  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}


		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public MooringBuoyViewModel Load(MooringBuoy instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
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
			typeOfBuoy = instance.typeOfBuoy;
			return this;
		}

		public override string Serialize() {
			var instance = new MooringBuoy {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				buoyShape = this.buoyShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
				typeOfBuoy = this.typeOfBuoy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public MooringBuoy Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
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
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		[Category("OffshorePlatform")]
		[Optional]
		public ObservableCollection<categoryOfOffshorePlatform> categoryOfOffshorePlatform  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfOffshorePlatform[] categoryOfOffshorePlatformList => [(categoryOfOffshorePlatform)1,(categoryOfOffshorePlatform)2,(categoryOfOffshorePlatform)3,(categoryOfOffshorePlatform)4,(categoryOfOffshorePlatform)5,(categoryOfOffshorePlatform)6,(categoryOfOffshorePlatform)7,(categoryOfOffshorePlatform)8,(categoryOfOffshorePlatform)9,(categoryOfOffshorePlatform)10,(categoryOfOffshorePlatform)11];

		[Category("OffshorePlatform")]
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("OffshorePlatform")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private condition? _condition  = default;

		[Category("OffshorePlatform")]
		[Editor(typeof(Editors.HorizonEditor<OffshorePlatform>), typeof(Editors.HorizonEditor))]
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
		public condition[] conditionList => [(condition)1,(condition)2,(condition)3,(condition)4,(condition)5];

		private Boolean? _radarConspicuous  = default;

		[Category("OffshorePlatform")]
		[Editor(typeof(Editors.HorizonEditor<OffshorePlatform>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private visualProminence? _visualProminence  = default;

		[Category("OffshorePlatform")]
		[Editor(typeof(Editors.HorizonEditor<OffshorePlatform>), typeof(Editors.HorizonEditor))]
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

		[Category("OffshorePlatform")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		[Category("OffshorePlatform")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public OffshorePlatformViewModel Load(OffshorePlatform instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			condition = instance.condition;
			radarConspicuous = instance.radarConspicuous;
			visualProminence = instance.visualProminence;
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
			var instance = new OffshorePlatform {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				categoryOfOffshorePlatform = this.categoryOfOffshorePlatform.ToList(),
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				condition = this.condition,
				radarConspicuous = this.radarConspicuous,
				visualProminence = this.visualProminence,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public OffshorePlatform Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			categoryOfOffshorePlatform = this.categoryOfOffshorePlatform.ToList(),
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			condition = this._condition,
			radarConspicuous = this._radarConspicuous,
			visualProminence = this._visualProminence,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => OffshorePlatform._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. OffshorePlatform._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => OffshorePlatform._featureBindingDefinitions;

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
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
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
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private buoyShape _buoyShape  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private Boolean? _radarConspicuous  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)15];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private String? _typeOfBuoy  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}


		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public SafeWaterBuoyViewModel Load(SafeWaterBuoy instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
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
			typeOfBuoy = instance.typeOfBuoy;
			return this;
		}

		public override string Serialize() {
			var instance = new SafeWaterBuoy {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				buoyShape = this.buoyShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
				typeOfBuoy = this.typeOfBuoy,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SafeWaterBuoy Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
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
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
	[CategoryOrder("SpecialPurposeGeneralBuoy",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SpecialPurposeGeneralBuoyViewModel : FeatureViewModel<SpecialPurposeGeneralBuoy> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private buoyShape _buoyShape  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private Boolean? _radarConspicuous  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)15];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		[Category("GenericBuoy")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private String? _typeOfBuoy  = default;

		[Category("GenericBuoy")]
		[Editor(typeof(Editors.HorizonEditor<GenericBuoy>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? typeOfBuoy {
			get {
				return _typeOfBuoy;
			}
			set {
				SetValue(ref _typeOfBuoy, value);
			}
		}

		[Category("SpecialPurposeGeneralBuoy")]
		[Multiplicity(1)]
		public ObservableCollection<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfSpecialPurposeMark[] categoryOfSpecialPurposeMarkList => [(categoryOfSpecialPurposeMark)1,(categoryOfSpecialPurposeMark)2,(categoryOfSpecialPurposeMark)3,(categoryOfSpecialPurposeMark)4,(categoryOfSpecialPurposeMark)5,(categoryOfSpecialPurposeMark)6,(categoryOfSpecialPurposeMark)7,(categoryOfSpecialPurposeMark)8,(categoryOfSpecialPurposeMark)9,(categoryOfSpecialPurposeMark)10,(categoryOfSpecialPurposeMark)11,(categoryOfSpecialPurposeMark)12,(categoryOfSpecialPurposeMark)13,(categoryOfSpecialPurposeMark)14,(categoryOfSpecialPurposeMark)15,(categoryOfSpecialPurposeMark)16,(categoryOfSpecialPurposeMark)17,(categoryOfSpecialPurposeMark)18,(categoryOfSpecialPurposeMark)19,(categoryOfSpecialPurposeMark)20,(categoryOfSpecialPurposeMark)21,(categoryOfSpecialPurposeMark)22,(categoryOfSpecialPurposeMark)23,(categoryOfSpecialPurposeMark)24,(categoryOfSpecialPurposeMark)25,(categoryOfSpecialPurposeMark)26,(categoryOfSpecialPurposeMark)27,(categoryOfSpecialPurposeMark)28,(categoryOfSpecialPurposeMark)29,(categoryOfSpecialPurposeMark)30,(categoryOfSpecialPurposeMark)31,(categoryOfSpecialPurposeMark)32,(categoryOfSpecialPurposeMark)33,(categoryOfSpecialPurposeMark)34,(categoryOfSpecialPurposeMark)35,(categoryOfSpecialPurposeMark)36,(categoryOfSpecialPurposeMark)37,(categoryOfSpecialPurposeMark)39,(categoryOfSpecialPurposeMark)40,(categoryOfSpecialPurposeMark)41,(categoryOfSpecialPurposeMark)42,(categoryOfSpecialPurposeMark)43,(categoryOfSpecialPurposeMark)44,(categoryOfSpecialPurposeMark)45,(categoryOfSpecialPurposeMark)46,(categoryOfSpecialPurposeMark)47,(categoryOfSpecialPurposeMark)48,(categoryOfSpecialPurposeMark)49,(categoryOfSpecialPurposeMark)50,(categoryOfSpecialPurposeMark)51,(categoryOfSpecialPurposeMark)52,(categoryOfSpecialPurposeMark)53,(categoryOfSpecialPurposeMark)54,(categoryOfSpecialPurposeMark)55,(categoryOfSpecialPurposeMark)56,(categoryOfSpecialPurposeMark)57,(categoryOfSpecialPurposeMark)58,(categoryOfSpecialPurposeMark)59,(categoryOfSpecialPurposeMark)60,(categoryOfSpecialPurposeMark)61,(categoryOfSpecialPurposeMark)62,(categoryOfSpecialPurposeMark)63,(categoryOfSpecialPurposeMark)64];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public SpecialPurposeGeneralBuoyViewModel Load(SpecialPurposeGeneralBuoy instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
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
			typeOfBuoy = instance.typeOfBuoy;
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
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				buoyShape = this.buoyShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
				typeOfBuoy = this.typeOfBuoy,
				categoryOfSpecialPurposeMark = this.categoryOfSpecialPurposeMark.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SpecialPurposeGeneralBuoy Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			buoyShape = this._buoyShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
			typeOfBuoy = this._typeOfBuoy,
			categoryOfSpecialPurposeMark = this.categoryOfSpecialPurposeMark.ToList(),
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
	/// A straight line extending towards an area of navigational interest and generally generated by two navigational aids or one navigational aid and a bearing.
	/// </summary>
	[CategoryOrder("NavigationLine",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class NavigationLineViewModel : FeatureViewModel<NavigationLine> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private categoryOfNavigationLine _categoryOfNavigationLine  = default;

		[Category("NavigationLine")]
		[Editor(typeof(Editors.HorizonEditor<NavigationLine>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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

		private orientationViewModel _orientation  = default;

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

		[Category("NavigationLine")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		#region FeatureBindings

		public class RangeSystemViewModel : ViewModelBase, IFeatureBinding {
			public RangeSystemViewModel() {
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

			private S125.RangeSystemViewModel _association = new();

			[ExpandableObject]
			public S125.RangeSystemViewModel association {
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
					lower = 0,
					upper = default,
					association = "RangeSystem",
					role = "navigableTrack",
					roleType = roleType.association,
					featureTypes = ["RecommendedTrack"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<RangeSystem> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = RangeSystem,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<NavigationLineViewModel.RangeSystemViewModel> RangeSystems { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. RangeSystems.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public NavigationLineViewModel Load(NavigationLine instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			categoryOfNavigationLine = instance.categoryOfNavigationLine;
			orientation = new ();
			if (instance.orientation != default) {
				orientation.Load(instance.orientation);
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new NavigationLine {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				categoryOfNavigationLine = this.categoryOfNavigationLine,
				orientation = this.orientation?.Model,
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public NavigationLine Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			categoryOfNavigationLine = this._categoryOfNavigationLine,
			orientation = this._orientation?.Model,
			status = this.status.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => NavigationLine._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. NavigationLine._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => NavigationLine._featureBindingDefinitions;

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
	[CategoryOrder("RecommendedTrack",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RecommendedTrackViewModel : FeatureViewModel<RecommendedTrack> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private Boolean _basedOnFixedMarks  = false;

		[Category("RecommendedTrack")]
		[Editor(typeof(Editors.HorizonEditor<RecommendedTrack>), typeof(Editors.HorizonEditor))]
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

		[Category("RecommendedTrack")]
		[Editor(typeof(Editors.HorizonEditor<RecommendedTrack>), typeof(Editors.HorizonEditor))]
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

		[Category("RecommendedTrack")]
		[Editor(typeof(Editors.HorizonEditor<RecommendedTrack>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? maximalPermittedDraught {
			get {
				return _maximalPermittedDraught;
			}
			set {
				SetValue(ref _maximalPermittedDraught, value);
			}
		}

		private orientationViewModel _orientation  = default;

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

		[Category("RecommendedTrack")]
		[Optional]
		public ObservableCollection<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public qualityOfVerticalMeasurement[] qualityOfVerticalMeasurementList => [(qualityOfVerticalMeasurement)1,(qualityOfVerticalMeasurement)2,(qualityOfVerticalMeasurement)3,(qualityOfVerticalMeasurement)4,(qualityOfVerticalMeasurement)5,(qualityOfVerticalMeasurement)6,(qualityOfVerticalMeasurement)7,(qualityOfVerticalMeasurement)8,(qualityOfVerticalMeasurement)9,(qualityOfVerticalMeasurement)10,(qualityOfVerticalMeasurement)11];

		private verticalUncertaintyViewModel? _verticalUncertainty  = default;

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

		[Category("RecommendedTrack")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		[Category("RecommendedTrack")]
		[Optional]
		public ObservableCollection<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement  { get; set; } = new ();

		[Browsable(false)]
		public techniqueOfVerticalMeasurement[] techniqueOfVerticalMeasurementList => [(techniqueOfVerticalMeasurement)1,(techniqueOfVerticalMeasurement)2,(techniqueOfVerticalMeasurement)3,(techniqueOfVerticalMeasurement)4,(techniqueOfVerticalMeasurement)5,(techniqueOfVerticalMeasurement)6,(techniqueOfVerticalMeasurement)7,(techniqueOfVerticalMeasurement)8,(techniqueOfVerticalMeasurement)9,(techniqueOfVerticalMeasurement)10,(techniqueOfVerticalMeasurement)11,(techniqueOfVerticalMeasurement)12,(techniqueOfVerticalMeasurement)13,(techniqueOfVerticalMeasurement)14,(techniqueOfVerticalMeasurement)15,(techniqueOfVerticalMeasurement)16,(techniqueOfVerticalMeasurement)17,(techniqueOfVerticalMeasurement)18];

		private trafficFlow _trafficFlow  = default;

		[Category("RecommendedTrack")]
		[Editor(typeof(Editors.HorizonEditor<RecommendedTrack>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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

		private verticalDatum? _verticalDatum  = default;

		[Category("RecommendedTrack")]
		[Editor(typeof(Editors.HorizonEditor<RecommendedTrack>), typeof(Editors.HorizonEditor))]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45,(verticalDatum)46,(verticalDatum)47,(verticalDatum)48,(verticalDatum)49];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		#region FeatureBindings

		public class RangeSystemViewModel : ViewModelBase, IFeatureBinding {
			public RangeSystemViewModel() {
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

			private S125.RangeSystemViewModel _association = new();

			[ExpandableObject]
			public S125.RangeSystemViewModel association {
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
					upper = default,
					association = "RangeSystem",
					role = "navigationLine",
					roleType = roleType.association,
					featureTypes = ["NavigationLine"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<RangeSystem> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = RangeSystem,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<RecommendedTrackViewModel.RangeSystemViewModel> RangeSystems { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. RangeSystems.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public RecommendedTrackViewModel Load(RecommendedTrack instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			basedOnFixedMarks = instance.basedOnFixedMarks;
			depthRangeMinimumValue = instance.depthRangeMinimumValue;
			maximalPermittedDraught = instance.maximalPermittedDraught;
			orientation = new ();
			if (instance.orientation != default) {
				orientation.Load(instance.orientation);
			}
			qualityOfVerticalMeasurement.Clear();
			if (instance.qualityOfVerticalMeasurement is not null) {
				foreach(var e in instance.qualityOfVerticalMeasurement)
					qualityOfVerticalMeasurement.Add(e);
			}
			verticalUncertainty = new ();
			if (instance.verticalUncertainty != default) {
				verticalUncertainty.Load(instance.verticalUncertainty);
			}
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
			trafficFlow = instance.trafficFlow;
			verticalDatum = instance.verticalDatum;
			return this;
		}

		public override string Serialize() {
			var instance = new RecommendedTrack {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				basedOnFixedMarks = this.basedOnFixedMarks,
				depthRangeMinimumValue = this.depthRangeMinimumValue,
				maximalPermittedDraught = this.maximalPermittedDraught,
				orientation = this.orientation?.Model,
				qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
				verticalUncertainty = this.verticalUncertainty?.Model,
				status = this.status.ToList(),
				techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
				trafficFlow = this.trafficFlow,
				verticalDatum = this.verticalDatum,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RecommendedTrack Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			basedOnFixedMarks = this._basedOnFixedMarks,
			depthRangeMinimumValue = this._depthRangeMinimumValue,
			maximalPermittedDraught = this._maximalPermittedDraught,
			orientation = this._orientation?.Model,
			qualityOfVerticalMeasurement = this.qualityOfVerticalMeasurement.ToList(),
			verticalUncertainty = this._verticalUncertainty?.Model,
			status = this.status.ToList(),
			techniqueOfVerticalMeasurement = this.techniqueOfVerticalMeasurement.ToList(),
			trafficFlow = this._trafficFlow,
			verticalDatum = this._verticalDatum,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => RecommendedTrack._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RecommendedTrack._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RecommendedTrack._featureBindingDefinitions;

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
			qualityOfVerticalMeasurement.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(qualityOfVerticalMeasurement));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
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
	/// An Automatic Identification System (AIS) message 21 transmitted from an AIS station to simulate on navigation systems an Aid to Navigation which does not physically exist.
	/// </summary>
	[CategoryOrder("VirtualAISAidToNavigation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class VirtualAISAidToNavigationViewModel : FeatureViewModel<VirtualAISAidToNavigation> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String? _AtoNNumber  = default;

		[Category("ElectronicAton")]
		[Editor(typeof(Editors.HorizonEditor<ElectronicAton>), typeof(Editors.HorizonEditor))]
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

		[Category("ElectronicAton")]
		[Editor(typeof(Editors.HorizonEditor<ElectronicAton>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String mMSICode {
			get {
				return _mMSICode;
			}
			set {
				SetValue(ref _mMSICode, value);
			}
		}

		[Category("ElectronicAton")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => Enum.GetValues<status>();

		private virtualAISAidToNavigationType _virtualAISAidToNavigationType  = default;

		[Category("VirtualAISAidToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<VirtualAISAidToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		#region FeatureBindings

		public class VirtualAISViewModel : ViewModelBase, IFeatureBinding {
			public VirtualAISViewModel() {
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

			private S125.VirtualAISViewModel _association = new();

			[ExpandableObject]
			public S125.VirtualAISViewModel association {
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
					lower = 0,
					upper = default,
					association = "VirtualAIS",
					role = "virtualAISbroadcasts",
					roleType = roleType.association,
					featureTypes = ["RadioStation"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<VirtualAIS> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = VirtualAIS,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<VirtualAISAidToNavigationViewModel.VirtualAISViewModel> VirtualAIS { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. VirtualAIS.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public VirtualAISAidToNavigationViewModel Load(VirtualAISAidToNavigation instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
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
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
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
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			mMSICode = this._mMSICode,
			status = this.status.ToList(),
			virtualAISAidToNavigationType = this._virtualAISAidToNavigationType,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => VirtualAISAidToNavigation._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. VirtualAISAidToNavigation._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => VirtualAISAidToNavigation._featureBindingDefinitions;

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
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			VirtualAIS.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(VirtualAIS));
			};
		}
	}



	/// <summary>
	/// The identifying characteristics of an aid to navigation which serve to facilitate its recognition against a daylight viewing background. On those structures that do not by themselves present an adequate viewing area to be seen at the required distance, the aid is made more visible by affixing a daymark to the structure. A daymark so affixed has a distinctive colour and shape depending on the purpose of the aid.
	/// </summary>
	[CategoryOrder("Daymark",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class DaymarkViewModel : FeatureViewModel<Daymark> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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


		private categoryOfSpecialPurposeMark? _categoryOfSpecialPurposeMark  = default;

		[Category("Daymark")]
		[Editor(typeof(Editors.HorizonEditor<Daymark>), typeof(Editors.HorizonEditor))]
		[Optional]
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
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("Daymark")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private double? _height  = default;

		[Category("Daymark")]
		[Editor(typeof(Editors.HorizonEditor<Daymark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		[Category("Daymark")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		[Category("Daymark")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private topmarkDaymarkShape _topmarkDaymarkShape  = default;

		[Category("Daymark")]
		[Editor(typeof(Editors.HorizonEditor<Daymark>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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

		private orientationViewModel? _orientation  = default;

		[Category("Daymark")]
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

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public DaymarkViewModel Load(Daymark instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
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
			height = instance.height;
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
			topmarkDaymarkShape = instance.topmarkDaymarkShape;
			orientation = new ();
			if (instance.orientation != default) {
				orientation.Load(instance.orientation);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new Daymark {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				categoryOfSpecialPurposeMark = this.categoryOfSpecialPurposeMark,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				height = this.height,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
				topmarkDaymarkShape = this.topmarkDaymarkShape,
				orientation = this.orientation?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Daymark Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			categoryOfSpecialPurposeMark = this._categoryOfSpecialPurposeMark,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			height = this._height,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
			topmarkDaymarkShape = this._topmarkDaymarkShape,
			orientation = this._orientation?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Daymark._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Daymark._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Daymark._featureBindingDefinitions;

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
	/// Something (such as a house, tower, bridge, etc.) that is built by putting parts together and that usually stands on its own.
	/// </summary>
	[CategoryOrder("StructureObject",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class StructureObjectViewModel : FeatureViewModel<StructureObject> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		#region FeatureBindings

		public class StructureEquipmentViewModel : ViewModelBase, IFeatureBinding {
			public StructureEquipmentViewModel() {
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

			private S125.StructureEquipmentViewModel _association = new();

			[ExpandableObject]
			public S125.StructureEquipmentViewModel association {
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
					lower = 0,
					upper = default,
					association = "StructureEquipment",
					role = "child",
					roleType = roleType.association,
					featureTypes = ["Equipment"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<StructureEquipment> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = StructureEquipment,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<StructureObjectViewModel.StructureEquipmentViewModel> StructureEquipments { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. StructureEquipments.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public StructureObjectViewModel Load(StructureObject instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
			return this;
		}

		public override string Serialize() {
			var instance = new StructureObject {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public StructureObject Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => StructureObject._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. StructureObject._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => StructureObject._featureBindingDefinitions;

		public StructureObjectViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public StructureObjectViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Structure Object";

		public StructureObjectViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			StructureEquipments.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(StructureEquipments));
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
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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


		private categoryOfFogSignal _categoryOfFogSignal  = default;

		[Category("FogSignal")]
		[Editor(typeof(Editors.HorizonEditor<FogSignal>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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

		[Category("FogSignal")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private signalSequenceViewModel? _signalSequence  = default;

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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public FogSignalViewModel Load(FogSignal instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			categoryOfFogSignal = instance.categoryOfFogSignal;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			signalSequence = new ();
			if (instance.signalSequence != default) {
				signalSequence.Load(instance.signalSequence);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new FogSignal {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				categoryOfFogSignal = this.categoryOfFogSignal,
				status = this.status.ToList(),
				signalSequence = this.signalSequence?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public FogSignal Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			categoryOfFogSignal = this._categoryOfFogSignal,
			status = this.status.ToList(),
			signalSequence = this._signalSequence?.Model,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => FogSignal._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. FogSignal._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => FogSignal._featureBindingDefinitions;

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
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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


		private double? _height  = default;

		[Category("RadarReflector")]
		[Editor(typeof(Editors.HorizonEditor<RadarReflector>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		[Category("RadarReflector")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public RadarReflectorViewModel Load(RadarReflector instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			height = instance.height;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new RadarReflector {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				height = this.height,
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RadarReflector Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			height = this._height,
			status = this.status.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => RadarReflector._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RadarReflector._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RadarReflector._featureBindingDefinitions;

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
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
		}
	}



	/// <summary>
	/// A fixed artificial navigation mark that can be recognized by its shape, colour, pattern, topmark or light character, or a combination of these. It may carry various additional aids to navigation.
	/// </summary>
	[CategoryOrder("GenericBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class GenericBeaconViewModel : FeatureViewModel<GenericBeacon> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private beaconShape _beaconShape  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("GenericBeacon")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private Boolean? _radarConspicuous  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private visualProminence? _visualProminence  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
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

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
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

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)15];

		[Category("GenericBeacon")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		private double? _verticalLength  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		[Category("GenericBeacon")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public GenericBeaconViewModel Load(GenericBeacon instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			visualProminence = instance.visualProminence;
			height = instance.height;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			verticalLength = instance.verticalLength;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new GenericBeacon {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				beaconShape = this.beaconShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				visualProminence = this.visualProminence,
				height = this.height,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				verticalLength = this.verticalLength,
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public GenericBeacon Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			beaconShape = this._beaconShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			visualProminence = this._visualProminence,
			height = this._height,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			verticalLength = this._verticalLength,
			status = this.status.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => GenericBeacon._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. GenericBeacon._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => GenericBeacon._featureBindingDefinitions;

		public GenericBeaconViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public GenericBeaconViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Generic Beacon";

		public GenericBeaconViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
	/// A transponder beacon transmitting a coded signal on radar frequency, permitting an interrogating craft to determine the bearing and range of the transponder.
	/// </summary>
	[CategoryOrder("RadarTransponderBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class RadarTransponderBeaconViewModel : FeatureViewModel<RadarTransponderBeacon> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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


		private categoryOfRadarTransponderBeacon _categoryOfRadarTransponderBeacon  = default;

		[Category("RadarTransponderBeacon")]
		[Editor(typeof(Editors.HorizonEditor<RadarTransponderBeacon>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
		[Optional]
		public radarWaveLengthViewModel? radarWaveLength {
			get {
				return _radarWaveLength;
			}
			set {
				SetValue(ref _radarWaveLength, value);
			}
		}

		private sectorLimitOneViewModel? _sectorLimitOne  = default;

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

		private String? _signalGroup  = default;

		[Category("RadarTransponderBeacon")]
		[Editor(typeof(Editors.HorizonEditor<RadarTransponderBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? signalGroup {
			get {
				return _signalGroup;
			}
			set {
				SetValue(ref _signalGroup, value);
			}
		}

		private signalSequenceViewModel? _signalSequence  = default;

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

		[Category("RadarTransponderBeacon")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private double? _valueOfNominalRange  = default;

		[Category("RadarTransponderBeacon")]
		[Editor(typeof(Editors.HorizonEditor<RadarTransponderBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? valueOfNominalRange {
			get {
				return _valueOfNominalRange;
			}
			set {
				SetValue(ref _valueOfNominalRange, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public RadarTransponderBeaconViewModel Load(RadarTransponderBeacon instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			categoryOfRadarTransponderBeacon = instance.categoryOfRadarTransponderBeacon;
			radarWaveLength = new ();
			if (instance.radarWaveLength != default) {
				radarWaveLength.Load(instance.radarWaveLength);
			}
			sectorLimitOne = new ();
			if (instance.sectorLimitOne != default) {
				sectorLimitOne.Load(instance.sectorLimitOne);
			}
			sectorLimitTwo = new ();
			if (instance.sectorLimitTwo != default) {
				sectorLimitTwo.Load(instance.sectorLimitTwo);
			}
			signalGroup = instance.signalGroup;
			signalSequence = new ();
			if (instance.signalSequence != default) {
				signalSequence.Load(instance.signalSequence);
			}
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			valueOfNominalRange = instance.valueOfNominalRange;
			return this;
		}

		public override string Serialize() {
			var instance = new RadarTransponderBeacon {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				categoryOfRadarTransponderBeacon = this.categoryOfRadarTransponderBeacon,
				radarWaveLength = this.radarWaveLength?.Model,
				sectorLimitOne = this.sectorLimitOne?.Model,
				sectorLimitTwo = this.sectorLimitTwo?.Model,
				signalGroup = this.signalGroup,
				signalSequence = this.signalSequence?.Model,
				status = this.status.ToList(),
				valueOfNominalRange = this.valueOfNominalRange,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RadarTransponderBeacon Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			categoryOfRadarTransponderBeacon = this._categoryOfRadarTransponderBeacon,
			radarWaveLength = this._radarWaveLength?.Model,
			sectorLimitOne = this._sectorLimitOne?.Model,
			sectorLimitTwo = this._sectorLimitTwo?.Model,
			signalGroup = this._signalGroup,
			signalSequence = this._signalSequence?.Model,
			status = this.status.ToList(),
			valueOfNominalRange = this._valueOfNominalRange,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => RadarTransponderBeacon._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. RadarTransponderBeacon._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => RadarTransponderBeacon._featureBindingDefinitions;

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
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
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
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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


		private categoryOfRadioStation _categoryOfRadioStation  = default;

		[Category("RadioStation")]
		[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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

		private double? _estimatedRangeOfTransmission  = default;

		[Category("RadioStation")]
		[Editor(typeof(Editors.HorizonEditor<RadioStation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? estimatedRangeOfTransmission {
			get {
				return _estimatedRangeOfTransmission;
			}
			set {
				SetValue(ref _estimatedRangeOfTransmission, value);
			}
		}

		[Category("RadioStation")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		#region FeatureBindings

		public class PhysicalAISViewModel : ViewModelBase, IFeatureBinding {
			public PhysicalAISViewModel() {
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

			private S125.PhysicalAISViewModel _association = new();

			[ExpandableObject]
			public S125.PhysicalAISViewModel association {
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
					lower = 0,
					upper = 1,
					association = "PhysicalAIS",
					role = "physicalAISbroadcastBy",
					roleType = roleType.association,
					featureTypes = ["PhysicalAISAidToNavigation"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<PhysicalAIS> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = PhysicalAIS,
			};
		}

		public class SyntheticAISViewModel : ViewModelBase, IFeatureBinding {
			public SyntheticAISViewModel() {
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

			private S125.SyntheticAISViewModel _association = new();

			[ExpandableObject]
			public S125.SyntheticAISViewModel association {
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
					lower = 0,
					upper = 1,
					association = "SyntheticAIS",
					role = "syntheticAISbroadcastBy",
					roleType = roleType.association,
					featureTypes = ["SyntheticAISAidToNavigation"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<SyntheticAIS> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = SyntheticAIS,
			};
		}

		public class VirtualAISViewModel : ViewModelBase, IFeatureBinding {
			public VirtualAISViewModel() {
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

			private S125.VirtualAISViewModel _association = new();

			[ExpandableObject]
			public S125.VirtualAISViewModel association {
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
					lower = 0,
					upper = 1,
					association = "VirtualAIS",
					role = "virtualAISbroadcastBy",
					roleType = roleType.association,
					featureTypes = ["VirtualAISAidToNavigation"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<VirtualAIS> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = VirtualAIS,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<RadioStationViewModel.PhysicalAISViewModel> PhysicalAIS { get; set; } = new();

		[Category("FeatureBindings")]
		public ObservableCollection<RadioStationViewModel.SyntheticAISViewModel> SyntheticAIS { get; set; } = new();

		[Category("FeatureBindings")]
		public ObservableCollection<RadioStationViewModel.VirtualAISViewModel> VirtualAIS { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. PhysicalAIS.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. SyntheticAIS.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. VirtualAIS.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public RadioStationViewModel Load(RadioStation instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			categoryOfRadioStation = instance.categoryOfRadioStation;
			estimatedRangeOfTransmission = instance.estimatedRangeOfTransmission;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new RadioStation {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				categoryOfRadioStation = this.categoryOfRadioStation,
				estimatedRangeOfTransmission = this.estimatedRangeOfTransmission,
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public RadioStation Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			categoryOfRadioStation = this._categoryOfRadioStation,
			estimatedRangeOfTransmission = this._estimatedRangeOfTransmission,
			status = this.status.ToList(),
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
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
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
	/// An air obstruction light is a light marking an obstacle which constitutes a danger to air navigation.
	/// </summary>
	[CategoryOrder("LightAirObstruction",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LightAirObstructionViewModel : FeatureViewModel<LightAirObstruction> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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


		private double? _height  = default;

		[Category("GenericLight")]
		[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
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

		[Category("GenericLight")]
		[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private verticalDatum? _verticalDatum  = default;

		[Category("GenericLight")]
		[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45];

		[Category("GenericLight")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private double? _effectiveIntensity  = default;

		[Category("GenericLight")]
		[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
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

		[Category("GenericLight")]
		[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? peakIntensity {
			get {
				return _peakIntensity;
			}
			set {
				SetValue(ref _peakIntensity, value);
			}
		}

		[Category("LightAirObstruction")]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("LightAirObstruction")]
		[Optional]
		public ObservableCollection<lightVisibility> lightVisibility  { get; set; } = new ();

		[Browsable(false)]
		public lightVisibility[] lightVisibilityList => [(lightVisibility)1,(lightVisibility)2,(lightVisibility)3,(lightVisibility)4,(lightVisibility)5,(lightVisibility)6,(lightVisibility)7,(lightVisibility)8,(lightVisibility)9];

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

		private rhythmOfLightViewModel _rhythmOfLight  = default;

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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public LightAirObstructionViewModel Load(LightAirObstruction instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			height = instance.height;
			verticalLength = instance.verticalLength;
			verticalDatum = instance.verticalDatum;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			effectiveIntensity = instance.effectiveIntensity;
			peakIntensity = instance.peakIntensity;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			lightVisibility.Clear();
			if (instance.lightVisibility is not null) {
				foreach(var e in instance.lightVisibility)
					lightVisibility.Add(e);
			}
			exhibitionConditionOfLight = instance.exhibitionConditionOfLight;
			valueOfNominalRange = instance.valueOfNominalRange;
			flareBearing = instance.flareBearing;
			multiplicityOfFeatures = new ();
			if (instance.multiplicityOfFeatures != default) {
				multiplicityOfFeatures.Load(instance.multiplicityOfFeatures);
			}
			rhythmOfLight = new ();
			if (instance.rhythmOfLight != default) {
				rhythmOfLight.Load(instance.rhythmOfLight);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new LightAirObstruction {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				height = this.height,
				verticalLength = this.verticalLength,
				verticalDatum = this.verticalDatum,
				status = this.status.ToList(),
				effectiveIntensity = this.effectiveIntensity,
				peakIntensity = this.peakIntensity,
				colour = this.colour.ToList(),
				lightVisibility = this.lightVisibility.ToList(),
				exhibitionConditionOfLight = this.exhibitionConditionOfLight,
				valueOfNominalRange = this.valueOfNominalRange,
				flareBearing = this.flareBearing,
				multiplicityOfFeatures = this.multiplicityOfFeatures?.Model,
				rhythmOfLight = this.rhythmOfLight?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LightAirObstruction Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			height = this._height,
			verticalLength = this._verticalLength,
			verticalDatum = this._verticalDatum,
			status = this.status.ToList(),
			effectiveIntensity = this._effectiveIntensity,
			peakIntensity = this._peakIntensity,
			colour = this.colour.ToList(),
			lightVisibility = this.lightVisibility.ToList(),
			exhibitionConditionOfLight = this._exhibitionConditionOfLight,
			valueOfNominalRange = this._valueOfNominalRange,
			flareBearing = this._flareBearing,
			multiplicityOfFeatures = this._multiplicityOfFeatures?.Model,
			rhythmOfLight = this._rhythmOfLight?.Model,
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
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			colour.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(colour));
			};
			lightVisibility.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(lightVisibility));
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
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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


		[Category("Retroreflector")]
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("Retroreflector")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private marksNavigationalSystemOf? _marksNavigationalSystemOf  = default;

		[Category("Retroreflector")]
		[Editor(typeof(Editors.HorizonEditor<Retroreflector>), typeof(Editors.HorizonEditor))]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)15];

		[Category("Retroreflector")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public RetroreflectorViewModel Load(Retroreflector instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
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
			return this;
		}

		public override string Serialize() {
			var instance = new Retroreflector {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Retroreflector Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			status = this.status.ToList(),
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Retroreflector._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Retroreflector._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Retroreflector._featureBindingDefinitions;

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
	/// An all around light is a light that is visible over the whole horizon of interest to marine navigation and having no change in the characteristics of the light.
	/// </summary>
	[CategoryOrder("LightAllAround",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LightAllAroundViewModel : FeatureViewModel<LightAllAround> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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


		private double? _height  = default;

		[Category("GenericLight")]
		[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
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

		[Category("GenericLight")]
		[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private verticalDatum? _verticalDatum  = default;

		[Category("GenericLight")]
		[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45];

		[Category("GenericLight")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private double? _effectiveIntensity  = default;

		[Category("GenericLight")]
		[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
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

		[Category("GenericLight")]
		[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? peakIntensity {
			get {
				return _peakIntensity;
			}
			set {
				SetValue(ref _peakIntensity, value);
			}
		}

		[Category("LightAllAround")]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

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
		public signalGeneration[] signalGenerationList => [(signalGeneration)1,(signalGeneration)2,(signalGeneration)3,(signalGeneration)4,(signalGeneration)5,(signalGeneration)6];

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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)15];

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
		public lightVisibility[] lightVisibilityList => [(lightVisibility)1,(lightVisibility)2,(lightVisibility)3,(lightVisibility)4,(lightVisibility)5,(lightVisibility)6,(lightVisibility)7,(lightVisibility)8,(lightVisibility)9];

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

		[Category("LightAllAround")]
		[Optional]
		public ObservableCollection<categoryOfLight> categoryOfLight  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfLight[] categoryOfLightList => [(categoryOfLight)1,(categoryOfLight)4,(categoryOfLight)5,(categoryOfLight)6,(categoryOfLight)8,(categoryOfLight)9,(categoryOfLight)10,(categoryOfLight)11,(categoryOfLight)12,(categoryOfLight)13,(categoryOfLight)14,(categoryOfLight)15,(categoryOfLight)17,(categoryOfLight)18,(categoryOfLight)19,(categoryOfLight)20];

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

		private multiplicityOfFeaturesViewModel? _multiplicityOfFeatures  = default;

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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public LightAllAroundViewModel Load(LightAllAround instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			height = instance.height;
			verticalLength = instance.verticalLength;
			verticalDatum = instance.verticalDatum;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			effectiveIntensity = instance.effectiveIntensity;
			peakIntensity = instance.peakIntensity;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			signalGeneration = instance.signalGeneration;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			majorLight = instance.majorLight;
			lightVisibility = instance.lightVisibility;
			exhibitionConditionOfLight = instance.exhibitionConditionOfLight;
			categoryOfLight.Clear();
			if (instance.categoryOfLight is not null) {
				foreach(var e in instance.categoryOfLight)
					categoryOfLight.Add(e);
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
			return this;
		}

		public override string Serialize() {
			var instance = new LightAllAround {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				height = this.height,
				verticalLength = this.verticalLength,
				verticalDatum = this.verticalDatum,
				status = this.status.ToList(),
				effectiveIntensity = this.effectiveIntensity,
				peakIntensity = this.peakIntensity,
				colour = this.colour.ToList(),
				signalGeneration = this.signalGeneration,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				majorLight = this.majorLight,
				lightVisibility = this.lightVisibility,
				exhibitionConditionOfLight = this.exhibitionConditionOfLight,
				categoryOfLight = this.categoryOfLight.ToList(),
				valueOfNominalRange = this.valueOfNominalRange,
				multiplicityOfFeatures = this.multiplicityOfFeatures?.Model,
				rhythmOfLight = this.rhythmOfLight?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LightAllAround Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			height = this._height,
			verticalLength = this._verticalLength,
			verticalDatum = this._verticalDatum,
			status = this.status.ToList(),
			effectiveIntensity = this._effectiveIntensity,
			peakIntensity = this._peakIntensity,
			colour = this.colour.ToList(),
			signalGeneration = this._signalGeneration,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			majorLight = this._majorLight,
			lightVisibility = this._lightVisibility,
			exhibitionConditionOfLight = this._exhibitionConditionOfLight,
			categoryOfLight = this.categoryOfLight.ToList(),
			valueOfNominalRange = this._valueOfNominalRange,
			multiplicityOfFeatures = this._multiplicityOfFeatures?.Model,
			rhythmOfLight = this._rhythmOfLight?.Model,
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
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
	/// A fog detector light is a light used to automatically determine conditions of visibility which warrant the turning on or off of a sound signal.
	/// </summary>
	[CategoryOrder("LightFogDetector",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LightFogDetectorViewModel : FeatureViewModel<LightFogDetector> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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


		private double? _height  = default;

		[Category("GenericLight")]
		[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
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

		[Category("GenericLight")]
		[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private verticalDatum? _verticalDatum  = default;

		[Category("GenericLight")]
		[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45];

		[Category("GenericLight")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private double? _effectiveIntensity  = default;

		[Category("GenericLight")]
		[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
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

		[Category("GenericLight")]
		[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? peakIntensity {
			get {
				return _peakIntensity;
			}
			set {
				SetValue(ref _peakIntensity, value);
			}
		}

		private rhythmOfLightViewModel _rhythmOfLight  = default;

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

		private signalGeneration? _signalGeneration  = default;

		[Category("LightFogDetector")]
		[Editor(typeof(Editors.HorizonEditor<LightFogDetector>), typeof(Editors.HorizonEditor))]
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
		public signalGeneration[] signalGenerationList => [(signalGeneration)1,(signalGeneration)2,(signalGeneration)3,(signalGeneration)4,(signalGeneration)5,(signalGeneration)6];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public LightFogDetectorViewModel Load(LightFogDetector instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			height = instance.height;
			verticalLength = instance.verticalLength;
			verticalDatum = instance.verticalDatum;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			effectiveIntensity = instance.effectiveIntensity;
			peakIntensity = instance.peakIntensity;
			rhythmOfLight = new ();
			if (instance.rhythmOfLight != default) {
				rhythmOfLight.Load(instance.rhythmOfLight);
			}
			signalGeneration = instance.signalGeneration;
			return this;
		}

		public override string Serialize() {
			var instance = new LightFogDetector {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				height = this.height,
				verticalLength = this.verticalLength,
				verticalDatum = this.verticalDatum,
				status = this.status.ToList(),
				effectiveIntensity = this.effectiveIntensity,
				peakIntensity = this.peakIntensity,
				rhythmOfLight = this.rhythmOfLight?.Model,
				signalGeneration = this.signalGeneration,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LightFogDetector Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			height = this._height,
			verticalLength = this._verticalLength,
			verticalDatum = this._verticalDatum,
			status = this.status.ToList(),
			effectiveIntensity = this._effectiveIntensity,
			peakIntensity = this._peakIntensity,
			rhythmOfLight = this._rhythmOfLight?.Model,
			signalGeneration = this._signalGeneration,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => LightFogDetector._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. LightFogDetector._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => LightFogDetector._featureBindingDefinitions;

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
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
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
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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


		private double? _height  = default;

		[Category("GenericLight")]
		[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
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

		[Category("GenericLight")]
		[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		private verticalDatum? _verticalDatum  = default;

		[Category("GenericLight")]
		[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
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
		public verticalDatum[] verticalDatumList => [(verticalDatum)1,(verticalDatum)2,(verticalDatum)3,(verticalDatum)4,(verticalDatum)5,(verticalDatum)6,(verticalDatum)7,(verticalDatum)8,(verticalDatum)9,(verticalDatum)10,(verticalDatum)11,(verticalDatum)12,(verticalDatum)13,(verticalDatum)14,(verticalDatum)15,(verticalDatum)16,(verticalDatum)17,(verticalDatum)18,(verticalDatum)19,(verticalDatum)20,(verticalDatum)21,(verticalDatum)22,(verticalDatum)23,(verticalDatum)24,(verticalDatum)25,(verticalDatum)26,(verticalDatum)27,(verticalDatum)28,(verticalDatum)29,(verticalDatum)30,(verticalDatum)31,(verticalDatum)32,(verticalDatum)33,(verticalDatum)34,(verticalDatum)35,(verticalDatum)36,(verticalDatum)37,(verticalDatum)38,(verticalDatum)39,(verticalDatum)40,(verticalDatum)41,(verticalDatum)43,(verticalDatum)44,(verticalDatum)45];

		[Category("GenericLight")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private double? _effectiveIntensity  = default;

		[Category("GenericLight")]
		[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
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

		[Category("GenericLight")]
		[Editor(typeof(Editors.HorizonEditor<GenericLight>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? peakIntensity {
			get {
				return _peakIntensity;
			}
			set {
				SetValue(ref _peakIntensity, value);
			}
		}

		[Category("LightSectored")]
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

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
		public signalGeneration[] signalGenerationList => [(signalGeneration)1,(signalGeneration)2,(signalGeneration)3,(signalGeneration)4,(signalGeneration)5,(signalGeneration)6];

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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)15];

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
		public exhibitionConditionOfLight[] exhibitionConditionOfLightList => [(exhibitionConditionOfLight)1,(exhibitionConditionOfLight)2,(exhibitionConditionOfLight)3,(exhibitionConditionOfLight)4];

		[Category("LightSectored")]
		[Optional]
		public ObservableCollection<categoryOfLight> categoryOfLight  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfLight[] categoryOfLightList => [(categoryOfLight)1,(categoryOfLight)4,(categoryOfLight)5,(categoryOfLight)6,(categoryOfLight)8,(categoryOfLight)9,(categoryOfLight)10,(categoryOfLight)11,(categoryOfLight)12,(categoryOfLight)13,(categoryOfLight)14,(categoryOfLight)15,(categoryOfLight)17,(categoryOfLight)18,(categoryOfLight)19,(categoryOfLight)20];

		[Category("LightSectored")]
		[Multiplicity(1)]
		public ObservableCollection<sectorCharacteristicsViewModel> sectorCharacteristics  { get; set; } = new ();

		private multiplicityOfFeaturesViewModel? _multiplicityOfFeatures  = default;

		[Category("LightSectored")]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public LightSectoredViewModel Load(LightSectored instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			height = instance.height;
			verticalLength = instance.verticalLength;
			verticalDatum = instance.verticalDatum;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			effectiveIntensity = instance.effectiveIntensity;
			peakIntensity = instance.peakIntensity;
			colour.Clear();
			if (instance.colour is not null) {
				foreach(var e in instance.colour)
					colour.Add(e);
			}
			signalGeneration = instance.signalGeneration;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			exhibitionConditionOfLight = instance.exhibitionConditionOfLight;
			categoryOfLight.Clear();
			if (instance.categoryOfLight is not null) {
				foreach(var e in instance.categoryOfLight)
					categoryOfLight.Add(e);
			}
			sectorCharacteristics.Clear();
			if (instance.sectorCharacteristics is not null) {
				foreach(var e in instance.sectorCharacteristics)
					sectorCharacteristics.Add(new sectorCharacteristicsViewModel().Load(e));
			}
			multiplicityOfFeatures = new ();
			if (instance.multiplicityOfFeatures != default) {
				multiplicityOfFeatures.Load(instance.multiplicityOfFeatures);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new LightSectored {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				height = this.height,
				verticalLength = this.verticalLength,
				verticalDatum = this.verticalDatum,
				status = this.status.ToList(),
				effectiveIntensity = this.effectiveIntensity,
				peakIntensity = this.peakIntensity,
				colour = this.colour.ToList(),
				signalGeneration = this.signalGeneration,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				exhibitionConditionOfLight = this.exhibitionConditionOfLight,
				categoryOfLight = this.categoryOfLight.ToList(),
				sectorCharacteristics = this.sectorCharacteristics.Select(e => e.Model).ToList(),
				multiplicityOfFeatures = this.multiplicityOfFeatures?.Model,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LightSectored Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			height = this._height,
			verticalLength = this._verticalLength,
			verticalDatum = this._verticalDatum,
			status = this.status.ToList(),
			effectiveIntensity = this._effectiveIntensity,
			peakIntensity = this._peakIntensity,
			colour = this.colour.ToList(),
			signalGeneration = this._signalGeneration,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			exhibitionConditionOfLight = this._exhibitionConditionOfLight,
			categoryOfLight = this.categoryOfLight.ToList(),
			sectorCharacteristics = this.sectorCharacteristics.Select(e => e.Model).ToList(),
			multiplicityOfFeatures = this._multiplicityOfFeatures?.Model,
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
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
			sectorCharacteristics.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(sectorCharacteristics));
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
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private beaconShape _beaconShape  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("GenericBeacon")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private Boolean? _radarConspicuous  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private visualProminence? _visualProminence  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
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

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
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

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)15];

		[Category("GenericBeacon")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		private double? _verticalLength  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		[Category("GenericBeacon")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private categoryOfCardinalMark _categoryOfCardinalMark  = default;

		[Category("CardinalBeacon")]
		[Editor(typeof(Editors.HorizonEditor<CardinalBeacon>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public CardinalBeaconViewModel Load(CardinalBeacon instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			visualProminence = instance.visualProminence;
			height = instance.height;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			verticalLength = instance.verticalLength;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			categoryOfCardinalMark = instance.categoryOfCardinalMark;
			return this;
		}

		public override string Serialize() {
			var instance = new CardinalBeacon {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				beaconShape = this.beaconShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				visualProminence = this.visualProminence,
				height = this.height,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				verticalLength = this.verticalLength,
				status = this.status.ToList(),
				categoryOfCardinalMark = this.categoryOfCardinalMark,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public CardinalBeacon Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			beaconShape = this._beaconShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			visualProminence = this._visualProminence,
			height = this._height,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			verticalLength = this._verticalLength,
			status = this.status.ToList(),
			categoryOfCardinalMark = this._categoryOfCardinalMark,
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
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
	/// An isolated danger beacon is a beacon erected on an isolated danger of limited extent, which has navigable water all around it.
	/// </summary>
	[CategoryOrder("IsolatedDangerBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class IsolatedDangerBeaconViewModel : FeatureViewModel<IsolatedDangerBeacon> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private beaconShape _beaconShape  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("GenericBeacon")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private Boolean? _radarConspicuous  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private visualProminence? _visualProminence  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
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

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
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

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)15];

		[Category("GenericBeacon")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		private double? _verticalLength  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		[Category("GenericBeacon")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];


		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public IsolatedDangerBeaconViewModel Load(IsolatedDangerBeacon instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			visualProminence = instance.visualProminence;
			height = instance.height;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			verticalLength = instance.verticalLength;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new IsolatedDangerBeacon {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				beaconShape = this.beaconShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				visualProminence = this.visualProminence,
				height = this.height,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				verticalLength = this.verticalLength,
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public IsolatedDangerBeacon Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			beaconShape = this._beaconShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			visualProminence = this._visualProminence,
			height = this._height,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			verticalLength = this._verticalLength,
			status = this.status.ToList(),
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
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
	/// A prominent object at a fixed location on land which can be used in determining a location or a direction.
	/// </summary>
	[CategoryOrder("Landmark",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LandmarkViewModel : FeatureViewModel<Landmark> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		[Category("Landmark")]
		[Multiplicity(1)]
		public ObservableCollection<categoryOfLandmark> categoryOfLandmark  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfLandmark[] categoryOfLandmarkList => [(categoryOfLandmark)1,(categoryOfLandmark)2,(categoryOfLandmark)3,(categoryOfLandmark)4,(categoryOfLandmark)5,(categoryOfLandmark)6,(categoryOfLandmark)7,(categoryOfLandmark)8,(categoryOfLandmark)9,(categoryOfLandmark)10,(categoryOfLandmark)11,(categoryOfLandmark)12,(categoryOfLandmark)13,(categoryOfLandmark)14,(categoryOfLandmark)15,(categoryOfLandmark)16,(categoryOfLandmark)17,(categoryOfLandmark)18,(categoryOfLandmark)19,(categoryOfLandmark)20,(categoryOfLandmark)21,(categoryOfLandmark)22,(categoryOfLandmark)23,(categoryOfLandmark)24,(categoryOfLandmark)25,(categoryOfLandmark)26,(categoryOfLandmark)27];

		[Category("Landmark")]
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("Landmark")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private Boolean? _radarConspicuous  = default;

		[Category("Landmark")]
		[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private visualProminence _visualProminence  = default;

		[Category("Landmark")]
		[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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

		[Category("Landmark")]
		[Optional]
		public ObservableCollection<function> function  { get; set; } = new ();

		[Browsable(false)]
		public function[] functionList => [(function)2,(function)3,(function)4,(function)5,(function)6,(function)7,(function)8,(function)9,(function)10,(function)11,(function)12,(function)13,(function)14,(function)15,(function)16,(function)17,(function)18,(function)19,(function)20,(function)21,(function)22,(function)23,(function)24,(function)25,(function)26,(function)27,(function)28,(function)29,(function)30,(function)31,(function)32,(function)33,(function)34,(function)35,(function)36,(function)37,(function)38,(function)39,(function)40,(function)41,(function)42,(function)43,(function)44,(function)45,(function)46,(function)47,(function)48,(function)49,(function)50];

		[Category("Landmark")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		[Category("Landmark")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private double? _height  = default;

		[Category("Landmark")]
		[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public LandmarkViewModel Load(Landmark instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			visualProminence = instance.visualProminence;
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
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			height = instance.height;
			return this;
		}

		public override string Serialize() {
			var instance = new Landmark {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				categoryOfLandmark = this.categoryOfLandmark.ToList(),
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				visualProminence = this.visualProminence,
				function = this.function.ToList(),
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
				height = this.height,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Landmark Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			categoryOfLandmark = this.categoryOfLandmark.ToList(),
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			visualProminence = this._visualProminence,
			function = this.function.ToList(),
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
			height = this._height,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Landmark._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Landmark._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Landmark._featureBindingDefinitions;

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
	[CategoryOrder("LateralBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class LateralBeaconViewModel : FeatureViewModel<LateralBeacon> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private beaconShape _beaconShape  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("GenericBeacon")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private Boolean? _radarConspicuous  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private visualProminence? _visualProminence  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
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

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
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

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)15];

		[Category("GenericBeacon")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		private double? _verticalLength  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		[Category("GenericBeacon")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private categoryOfLateralMark _categoryOfLateralMark  = default;

		[Category("LateralBeacon")]
		[Editor(typeof(Editors.HorizonEditor<LateralBeacon>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public LateralBeaconViewModel Load(LateralBeacon instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			visualProminence = instance.visualProminence;
			height = instance.height;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			verticalLength = instance.verticalLength;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			categoryOfLateralMark = instance.categoryOfLateralMark;
			return this;
		}

		public override string Serialize() {
			var instance = new LateralBeacon {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				beaconShape = this.beaconShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				visualProminence = this.visualProminence,
				height = this.height,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				verticalLength = this.verticalLength,
				status = this.status.ToList(),
				categoryOfLateralMark = this.categoryOfLateralMark,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public LateralBeacon Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			beaconShape = this._beaconShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			visualProminence = this._visualProminence,
			height = this._height,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			verticalLength = this._verticalLength,
			status = this.status.ToList(),
			categoryOfLateralMark = this._categoryOfLateralMark,
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
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		[Category("Landmark")]
		[Multiplicity(1)]
		public ObservableCollection<categoryOfLandmark> categoryOfLandmark  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfLandmark[] categoryOfLandmarkList => [(categoryOfLandmark)1,(categoryOfLandmark)2,(categoryOfLandmark)3,(categoryOfLandmark)4,(categoryOfLandmark)5,(categoryOfLandmark)6,(categoryOfLandmark)7,(categoryOfLandmark)8,(categoryOfLandmark)9,(categoryOfLandmark)10,(categoryOfLandmark)11,(categoryOfLandmark)12,(categoryOfLandmark)13,(categoryOfLandmark)14,(categoryOfLandmark)15,(categoryOfLandmark)16,(categoryOfLandmark)17,(categoryOfLandmark)18,(categoryOfLandmark)19,(categoryOfLandmark)20,(categoryOfLandmark)21,(categoryOfLandmark)22,(categoryOfLandmark)23,(categoryOfLandmark)24,(categoryOfLandmark)25,(categoryOfLandmark)26,(categoryOfLandmark)27];

		[Category("Landmark")]
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("Landmark")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private Boolean? _radarConspicuous  = default;

		[Category("Landmark")]
		[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private visualProminence _visualProminence  = default;

		[Category("Landmark")]
		[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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

		[Category("Landmark")]
		[Optional]
		public ObservableCollection<function> function  { get; set; } = new ();

		[Browsable(false)]
		public function[] functionList => [(function)2,(function)3,(function)4,(function)5,(function)6,(function)7,(function)8,(function)9,(function)10,(function)11,(function)12,(function)13,(function)14,(function)15,(function)16,(function)17,(function)18,(function)19,(function)20,(function)21,(function)22,(function)23,(function)24,(function)25,(function)26,(function)27,(function)28,(function)29,(function)30,(function)31,(function)32,(function)33,(function)34,(function)35,(function)36,(function)37,(function)38,(function)39,(function)40,(function)41,(function)42,(function)43,(function)44,(function)45,(function)46,(function)47,(function)48,(function)49,(function)50];

		[Category("Landmark")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		[Category("Landmark")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private double? _height  = default;

		[Category("Landmark")]
		[Editor(typeof(Editors.HorizonEditor<Landmark>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? height {
			get {
				return _height;
			}
			set {
				SetValue(ref _height, value);
			}
		}


		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public LighthouseViewModel Load(Lighthouse instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			visualProminence = instance.visualProminence;
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
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			height = instance.height;
			return this;
		}

		public override string Serialize() {
			var instance = new Lighthouse {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				categoryOfLandmark = this.categoryOfLandmark.ToList(),
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				visualProminence = this.visualProminence,
				function = this.function.ToList(),
				natureOfConstruction = this.natureOfConstruction.ToList(),
				status = this.status.ToList(),
				height = this.height,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Lighthouse Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			categoryOfLandmark = this.categoryOfLandmark.ToList(),
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			visualProminence = this._visualProminence,
			function = this.function.ToList(),
			natureOfConstruction = this.natureOfConstruction.ToList(),
			status = this.status.ToList(),
			height = this._height,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Lighthouse._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Lighthouse._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Lighthouse._featureBindingDefinitions;

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
	/// A safe water beacon is used to indicate that there is navigable water around the mark.
	/// </summary>
	[CategoryOrder("SafeWaterBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SafeWaterBeaconViewModel : FeatureViewModel<SafeWaterBeacon> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private beaconShape _beaconShape  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("GenericBeacon")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private Boolean? _radarConspicuous  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private visualProminence? _visualProminence  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
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

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
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

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)15];

		[Category("GenericBeacon")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		private double? _verticalLength  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		[Category("GenericBeacon")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];


		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public SafeWaterBeaconViewModel Load(SafeWaterBeacon instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			visualProminence = instance.visualProminence;
			height = instance.height;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			verticalLength = instance.verticalLength;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
			return this;
		}

		public override string Serialize() {
			var instance = new SafeWaterBeacon {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				beaconShape = this.beaconShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				visualProminence = this.visualProminence,
				height = this.height,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				verticalLength = this.verticalLength,
				status = this.status.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SafeWaterBeacon Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			beaconShape = this._beaconShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			visualProminence = this._visualProminence,
			height = this._height,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			verticalLength = this._verticalLength,
			status = this.status.ToList(),
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
	[CategoryOrder("SpecialPurposeGeneralBeacon",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SpecialPurposeGeneralBeaconViewModel : FeatureViewModel<SpecialPurposeGeneralBeacon> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String _AtoNNumber  = string.Empty;

		[Category("StructureObject")]
		[Editor(typeof(Editors.HorizonEditor<StructureObject>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String AtoNNumber {
			get {
				return _AtoNNumber;
			}
			set {
				SetValue(ref _AtoNNumber, value);
			}
		}

		private beaconShape _beaconShape  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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
		[Multiplicity(1)]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("GenericBeacon")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		private Boolean? _radarConspicuous  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public Boolean? radarConspicuous {
			get {
				return _radarConspicuous;
			}
			set {
				SetValue(ref _radarConspicuous, value);
			}
		}

		private visualProminence? _visualProminence  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
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

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
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

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
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
		public marksNavigationalSystemOf[] marksNavigationalSystemOfList => [(marksNavigationalSystemOf)1,(marksNavigationalSystemOf)2,(marksNavigationalSystemOf)9,(marksNavigationalSystemOf)10,(marksNavigationalSystemOf)11,(marksNavigationalSystemOf)12,(marksNavigationalSystemOf)13,(marksNavigationalSystemOf)15];

		[Category("GenericBeacon")]
		[Optional]
		public ObservableCollection<natureOfConstruction> natureOfConstruction  { get; set; } = new ();

		[Browsable(false)]
		public natureOfConstruction[] natureOfConstructionList => [(natureOfConstruction)1,(natureOfConstruction)2,(natureOfConstruction)3,(natureOfConstruction)4,(natureOfConstruction)5,(natureOfConstruction)6,(natureOfConstruction)7,(natureOfConstruction)8,(natureOfConstruction)9,(natureOfConstruction)10,(natureOfConstruction)11,(natureOfConstruction)12,(natureOfConstruction)13,(natureOfConstruction)14];

		private double? _verticalLength  = default;

		[Category("GenericBeacon")]
		[Editor(typeof(Editors.HorizonEditor<GenericBeacon>), typeof(Editors.HorizonEditor))]
		[Optional]
		public double? verticalLength {
			get {
				return _verticalLength;
			}
			set {
				SetValue(ref _verticalLength, value);
			}
		}

		[Category("GenericBeacon")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		[Category("SpecialPurposeGeneralBeacon")]
		[Multiplicity(1)]
		public ObservableCollection<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark  { get; set; } = new ();

		[Browsable(false)]
		public categoryOfSpecialPurposeMark[] categoryOfSpecialPurposeMarkList => [(categoryOfSpecialPurposeMark)1,(categoryOfSpecialPurposeMark)2,(categoryOfSpecialPurposeMark)3,(categoryOfSpecialPurposeMark)4,(categoryOfSpecialPurposeMark)5,(categoryOfSpecialPurposeMark)6,(categoryOfSpecialPurposeMark)7,(categoryOfSpecialPurposeMark)8,(categoryOfSpecialPurposeMark)9,(categoryOfSpecialPurposeMark)10,(categoryOfSpecialPurposeMark)11,(categoryOfSpecialPurposeMark)12,(categoryOfSpecialPurposeMark)13,(categoryOfSpecialPurposeMark)14,(categoryOfSpecialPurposeMark)15,(categoryOfSpecialPurposeMark)16,(categoryOfSpecialPurposeMark)17,(categoryOfSpecialPurposeMark)18,(categoryOfSpecialPurposeMark)19,(categoryOfSpecialPurposeMark)20,(categoryOfSpecialPurposeMark)21,(categoryOfSpecialPurposeMark)22,(categoryOfSpecialPurposeMark)23,(categoryOfSpecialPurposeMark)24,(categoryOfSpecialPurposeMark)25,(categoryOfSpecialPurposeMark)26,(categoryOfSpecialPurposeMark)27,(categoryOfSpecialPurposeMark)28,(categoryOfSpecialPurposeMark)29,(categoryOfSpecialPurposeMark)30,(categoryOfSpecialPurposeMark)31,(categoryOfSpecialPurposeMark)32,(categoryOfSpecialPurposeMark)33,(categoryOfSpecialPurposeMark)34,(categoryOfSpecialPurposeMark)35,(categoryOfSpecialPurposeMark)36,(categoryOfSpecialPurposeMark)37,(categoryOfSpecialPurposeMark)39,(categoryOfSpecialPurposeMark)40,(categoryOfSpecialPurposeMark)41,(categoryOfSpecialPurposeMark)42,(categoryOfSpecialPurposeMark)43,(categoryOfSpecialPurposeMark)44,(categoryOfSpecialPurposeMark)45,(categoryOfSpecialPurposeMark)46,(categoryOfSpecialPurposeMark)47,(categoryOfSpecialPurposeMark)48,(categoryOfSpecialPurposeMark)49,(categoryOfSpecialPurposeMark)50,(categoryOfSpecialPurposeMark)51,(categoryOfSpecialPurposeMark)52,(categoryOfSpecialPurposeMark)53,(categoryOfSpecialPurposeMark)54,(categoryOfSpecialPurposeMark)55,(categoryOfSpecialPurposeMark)56,(categoryOfSpecialPurposeMark)57,(categoryOfSpecialPurposeMark)58,(categoryOfSpecialPurposeMark)59,(categoryOfSpecialPurposeMark)60,(categoryOfSpecialPurposeMark)61,(categoryOfSpecialPurposeMark)62,(categoryOfSpecialPurposeMark)63,(categoryOfSpecialPurposeMark)64];

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];

		[Browsable(false)]
		public override featureBinding[] featureBindings => [];


		public SpecialPurposeGeneralBeaconViewModel Load(SpecialPurposeGeneralBeacon instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
			}
			AtoNNumber = instance.AtoNNumber;
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
			radarConspicuous = instance.radarConspicuous;
			visualProminence = instance.visualProminence;
			height = instance.height;
			marksNavigationalSystemOf = instance.marksNavigationalSystemOf;
			natureOfConstruction.Clear();
			if (instance.natureOfConstruction is not null) {
				foreach(var e in instance.natureOfConstruction)
					natureOfConstruction.Add(e);
			}
			verticalLength = instance.verticalLength;
			status.Clear();
			if (instance.status is not null) {
				foreach(var e in instance.status)
					status.Add(e);
			}
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
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				AtoNNumber = this.AtoNNumber,
				beaconShape = this.beaconShape,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				radarConspicuous = this.radarConspicuous,
				visualProminence = this.visualProminence,
				height = this.height,
				marksNavigationalSystemOf = this.marksNavigationalSystemOf,
				natureOfConstruction = this.natureOfConstruction.ToList(),
				verticalLength = this.verticalLength,
				status = this.status.ToList(),
				categoryOfSpecialPurposeMark = this.categoryOfSpecialPurposeMark.ToList(),
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public SpecialPurposeGeneralBeacon Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			beaconShape = this._beaconShape,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			radarConspicuous = this._radarConspicuous,
			visualProminence = this._visualProminence,
			height = this._height,
			marksNavigationalSystemOf = this._marksNavigationalSystemOf,
			natureOfConstruction = this.natureOfConstruction.ToList(),
			verticalLength = this._verticalLength,
			status = this.status.ToList(),
			categoryOfSpecialPurposeMark = this.categoryOfSpecialPurposeMark.ToList(),
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
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
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
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		private String? _interoperabilityIdentifier  = default;

		[Category("DangerousFeature")]
		[Editor(typeof(Editors.HorizonEditor<DangerousFeature>), typeof(Editors.HorizonEditor))]
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


		#region FeatureBindings

		public class DangerousFeatureAssociationViewModel : ViewModelBase, IFeatureBinding {
			public DangerousFeatureAssociationViewModel() {
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

			private S125.DangerousFeatureAssociationViewModel _association = new();

			[ExpandableObject]
			public S125.DangerousFeatureAssociationViewModel association {
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
					upper = default,
					association = "DangerousFeatureAssociation",
					role = "markingAton",
					roleType = roleType.association,
					featureTypes = ["AtonAssociation"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<DangerousFeatureAssociation> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = DangerousFeatureAssociation,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<DangerousFeatureViewModel.DangerousFeatureAssociationViewModel> DangerousFeatureAssociations { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. DangerousFeatureAssociations.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public DangerousFeatureViewModel Load(DangerousFeature instance) {
			information.Clear();
			if (instance.information is not null) {
				foreach(var e in instance.information)
					information.Add(new informationViewModel().Load(e));
			}
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
			return this;
		}

		public override string Serialize() {
			var instance = new DangerousFeature {
				information = this.information.Select(e => e.Model).ToList(),
				interoperabilityIdentifier = this.interoperabilityIdentifier,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public DangerousFeature Model => new () {
			information = this.information.Select(e => e.Model).ToList(),
			interoperabilityIdentifier = this._interoperabilityIdentifier,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => DangerousFeature._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. DangerousFeature._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => DangerousFeature._featureBindingDefinitions;

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
	/// Used to identify an association between two or more objects. The association may be named content of categoryOfAssociation should be put in information attribute when converting to S-57
	/// </summary>
	[CategoryOrder("AtonAssociation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonAssociationViewModel : FeatureViewModel<AtonAssociation> {
		private CategoryOfAssociation _CategoryOfAssociation  = default;

		[Category("AtonAssociation")]
		[Editor(typeof(Editors.HorizonEditor<AtonAssociation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		#region FeatureBindings

		public class DangerousFeatureAssociationViewModel : ViewModelBase, IFeatureBinding {
			public DangerousFeatureAssociationViewModel() {
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

			private S125.DangerousFeatureAssociationViewModel _association = new();

			[ExpandableObject]
			public S125.DangerousFeatureAssociationViewModel association {
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
					lower = 0,
					upper = default,
					association = "DangerousFeatureAssociation",
					role = "danger",
					roleType = roleType.association,
					featureTypes = ["DangerousFeature"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<DangerousFeatureAssociation> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = DangerousFeatureAssociation,
			};
		}

		public class AtonAssociationsViewModel : ViewModelBase, IFeatureBinding {
			public AtonAssociationsViewModel() {
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

			private S125.AtonAssociationsViewModel _association = new();

			[ExpandableObject]
			public S125.AtonAssociationsViewModel association {
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
					lower = 0,
					upper = default,
					association = "AtonAssociations",
					role = "atonAssociationBy",
					roleType = roleType.association,
					featureTypes = ["AidsToNavigation"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<AtonAssociations> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = AtonAssociations,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<AtonAssociationViewModel.DangerousFeatureAssociationViewModel> DangerousFeatureAssociations { get; set; } = new();

		[Category("FeatureBindings")]
		public ObservableCollection<AtonAssociationViewModel.AtonAssociationsViewModel> AtonAssociations { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. DangerousFeatureAssociations.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model),.. AtonAssociations.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

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

		public override informationBindingDefinition[] informationBindingDefinitions => AtonAssociation._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. AtonAssociation._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => AtonAssociation._featureBindingDefinitions;

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
	/// Used to identify an aggregation of two or more objects. This aggregation may be named content of categoryOfAggregation should be put in information attribute when converting to S-57.
	/// </summary>
	[CategoryOrder("AtonAggregation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class AtonAggregationViewModel : FeatureViewModel<AtonAggregation> {
		private CategoryOfAggregation _CategoryOfAggregation  = default;

		[Category("AtonAggregation")]
		[Editor(typeof(Editors.HorizonEditor<AtonAggregation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		#region FeatureBindings

		public class AtonAggregationsViewModel : ViewModelBase, IFeatureBinding {
			public AtonAggregationsViewModel() {
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

			private S125.AtonAggregationsViewModel _association = new();

			[ExpandableObject]
			public S125.AtonAggregationsViewModel association {
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
					lower = 0,
					upper = default,
					association = "AtonAggregations",
					role = "atonAggregationBy",
					roleType = roleType.association,
					featureTypes = ["AidsToNavigation"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<AtonAggregations> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = AtonAggregations,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<AtonAggregationViewModel.AtonAggregationsViewModel> AtonAggregations { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. AtonAggregations.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

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

		public override informationBindingDefinition[] informationBindingDefinitions => AtonAggregation._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. AtonAggregation._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => AtonAggregation._featureBindingDefinitions;

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
	/// A characteristic shape secured at the top of a buoy or beacon to aid in its identification.
	/// </summary>
	[CategoryOrder("Topmark",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class TopmarkViewModel : FeatureViewModel<Topmark> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("Topmark")]
		[Optional]
		public ObservableCollection<colour> colour  { get; set; } = new ();

		[Browsable(false)]
		public colour[] colourList => [(colour)1,(colour)2,(colour)3,(colour)4,(colour)5,(colour)6,(colour)7,(colour)8,(colour)9,(colour)10,(colour)11,(colour)12,(colour)13];

		[Category("Topmark")]
		[Optional]
		public ObservableCollection<colourPattern> colourPattern  { get; set; } = new ();

		[Browsable(false)]
		public colourPattern[] colourPatternList => [(colourPattern)1,(colourPattern)2,(colourPattern)3,(colourPattern)4,(colourPattern)5,(colourPattern)6,(colourPattern)7,(colourPattern)8,(colourPattern)9];

		[Category("Topmark")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => [(status)1,(status)2,(status)3,(status)4,(status)5,(status)6,(status)7,(status)8,(status)9,(status)11,(status)12,(status)13,(status)14,(status)15,(status)16,(status)17,(status)18,(status)19,(status)20,(status)21,(status)22,(status)23,(status)24,(status)25,(status)26,(status)27,(status)28,(status)29,(status)30,(status)31,(status)32,(status)33,(status)34,(status)35,(status)36,(status)37,(status)38,(status)39,(status)41,(status)42,(status)43];

		private topmarkDaymarkShape _topmarkDaymarkShape  = default;

		[Category("Topmark")]
		[Editor(typeof(Editors.HorizonEditor<Topmark>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		#region FeatureBindings

		public class BuoyTopmarkViewModel : ViewModelBase, IFeatureBinding {
			public BuoyTopmarkViewModel() {
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

			private S125.BuoyTopmarkViewModel _association = new();

			[ExpandableObject]
			public S125.BuoyTopmarkViewModel association {
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
					association = "BuoyTopmark",
					role = "buoyPart",
					roleType = roleType.association,
					featureTypes = ["GenericBuoy"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<BuoyTopmark> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = BuoyTopmark,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<TopmarkViewModel.BuoyTopmarkViewModel> BuoyTopmarks { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. BuoyTopmarks.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public TopmarkViewModel Load(Topmark instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
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
			return this;
		}

		public override string Serialize() {
			var instance = new Topmark {
				iDCode = this.iDCode,
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
				colour = this.colour.ToList(),
				colourPattern = this.colourPattern.ToList(),
				status = this.status.ToList(),
				topmarkDaymarkShape = this.topmarkDaymarkShape,
			};
			return System.Text.Json.JsonSerializer.Serialize(instance);
		}

		[Browsable(false)]
		public Topmark Model => new () {
			iDCode = this._iDCode,
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			colour = this.colour.ToList(),
			colourPattern = this.colourPattern.ToList(),
			status = this.status.ToList(),
			topmarkDaymarkShape = this._topmarkDaymarkShape,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => Topmark._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. Topmark._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => Topmark._featureBindingDefinitions;

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
	/// An Automatic Identification System (AIS) message 21 transmitted from a physical Aid to Navigation, or transmitted from an AIS station for an Aid to Navigation which physically exists.
	/// </summary>
	[CategoryOrder("PhysicalAISAidToNavigation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class PhysicalAISAidToNavigationViewModel : FeatureViewModel<PhysicalAISAidToNavigation> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String? _AtoNNumber  = default;

		[Category("ElectronicAton")]
		[Editor(typeof(Editors.HorizonEditor<ElectronicAton>), typeof(Editors.HorizonEditor))]
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

		[Category("ElectronicAton")]
		[Editor(typeof(Editors.HorizonEditor<ElectronicAton>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String mMSICode {
			get {
				return _mMSICode;
			}
			set {
				SetValue(ref _mMSICode, value);
			}
		}

		[Category("ElectronicAton")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => Enum.GetValues<status>();

		private CategoryOfPhysicalAISAidToNavigation _CategoryOfPhysicalAISAidToNavigation  = default;

		[Category("PhysicalAISAidToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<PhysicalAISAidToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		#region FeatureBindings

		public class PhysicalAISViewModel : ViewModelBase, IFeatureBinding {
			public PhysicalAISViewModel() {
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

			private S125.PhysicalAISViewModel _association = new();

			[ExpandableObject]
			public S125.PhysicalAISViewModel association {
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
					lower = 0,
					upper = default,
					association = "PhysicalAIS",
					role = "physicalAISbroadcasts",
					roleType = roleType.association,
					featureTypes = ["RadioStation"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<PhysicalAIS> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = PhysicalAIS,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<PhysicalAISAidToNavigationViewModel.PhysicalAISViewModel> PhysicalAIS { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. PhysicalAIS.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public PhysicalAISAidToNavigationViewModel Load(PhysicalAISAidToNavigation instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
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
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
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
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			mMSICode = this._mMSICode,
			status = this.status.ToList(),
			CategoryOfPhysicalAISAidToNavigation = this._CategoryOfPhysicalAISAidToNavigation,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => PhysicalAISAidToNavigation._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. PhysicalAISAidToNavigation._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => PhysicalAISAidToNavigation._featureBindingDefinitions;

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
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			PhysicalAIS.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(PhysicalAIS));
			};
		}
	}



	/// <summary>
	/// An Automatic Identification System (AIS) message 21 transmitted from an AIS station located remotely from the intended physical Aid to Navigation.
	/// </summary>
	[CategoryOrder("SyntheticAISAidToNavigation",0)]
	[CategoryOrder("InformationBindings",100)]
	[CategoryOrder("FeatureBindings",200)]
	public partial class SyntheticAISAidToNavigationViewModel : FeatureViewModel<SyntheticAISAidToNavigation> {
		private String? _iDCode  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? iDCode {
			get {
				return _iDCode;
			}
			set {
				SetValue(ref _iDCode, value);
			}
		}

		private String _interoperabilityIdentifier  = string.Empty;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String interoperabilityIdentifier {
			get {
				return _interoperabilityIdentifier;
			}
			set {
				SetValue(ref _interoperabilityIdentifier, value);
			}
		}

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<informationViewModel> information  { get; set; } = new ();

		[Category("AidsToNavigation")]
		[Optional]
		public ObservableCollection<featureNameViewModel> featureName  { get; set; } = new ();

		private int? _scaleMinimum  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
		[Optional]
		public String? pictorialRepresentation {
			get {
				return _pictorialRepresentation;
			}
			set {
				SetValue(ref _pictorialRepresentation, value);
			}
		}

		private DateOnly? _installationDate  = default;

		[Category("AidsToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<AidsToNavigation>), typeof(Editors.HorizonEditor))]
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

		private String? _AtoNNumber  = default;

		[Category("ElectronicAton")]
		[Editor(typeof(Editors.HorizonEditor<ElectronicAton>), typeof(Editors.HorizonEditor))]
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

		[Category("ElectronicAton")]
		[Editor(typeof(Editors.HorizonEditor<ElectronicAton>), typeof(Editors.HorizonEditor))]
		[Mandatory]
		public String mMSICode {
			get {
				return _mMSICode;
			}
			set {
				SetValue(ref _mMSICode, value);
			}
		}

		[Category("ElectronicAton")]
		[Optional]
		public ObservableCollection<status> status  { get; set; } = new ();

		[Browsable(false)]
		public status[] statusList => Enum.GetValues<status>();

		private CategoryOfSyntheticAISAidtoNavigation _CategoryOfSyntheticAISAidtoNavigation  = default;

		[Category("SyntheticAISAidToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<SyntheticAISAidToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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

		private virtualAISAidToNavigationType _virtualAISAidToNavigationType  = default;

		[Category("SyntheticAISAidToNavigation")]
		[Editor(typeof(Editors.HorizonEditor<SyntheticAISAidToNavigation>), typeof(Editors.HorizonEditor))]
		[Mandatory]
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

		[Browsable(false)]
		public override informationBinding[] informationBindings => [];


		#region FeatureBindings

		public class SyntheticAISViewModel : ViewModelBase, IFeatureBinding {
			public SyntheticAISViewModel() {
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

			private S125.SyntheticAISViewModel _association = new();

			[ExpandableObject]
			public S125.SyntheticAISViewModel association {
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
					lower = 0,
					upper = default,
					association = "SyntheticAIS",
					role = "syntheticAISbroadcasts",
					roleType = roleType.association,
					featureTypes = ["RadioStation"],
				},
			];
			public override string Serialize() {
				throw new NotImplementedException();
			}

			[Browsable(false)]
			public featureBinding Model => new featureBinding<SyntheticAIS> {
				referenceId = this.featureId,
				featureType = this.featureType,
				role = this.role,
				roleType = featureBindings.Single(e=>e.role.Equals(this.role)).roleType.ToString(),
				//association = SyntheticAIS,
			};
		}

		[Category("FeatureBindings")]
		public ObservableCollection<SyntheticAISAidToNavigationViewModel.SyntheticAISViewModel> SyntheticAIS { get; set; } = new();
		[Browsable(false)]

		public override featureBinding[] featureBindings => [.. SyntheticAIS.Where(e => !string.IsNullOrEmpty(e.role)).Select(e=>e.Model)];

		#endregion


		public SyntheticAISAidToNavigationViewModel Load(SyntheticAISAidToNavigation instance) {
			iDCode = instance.iDCode;
			interoperabilityIdentifier = instance.interoperabilityIdentifier;
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
			installationDate = instance.installationDate;
			fixedDateRange = new ();
			if (instance.fixedDateRange != default) {
				fixedDateRange.Load(instance.fixedDateRange);
			}
			periodicDateRange = new ();
			if (instance.periodicDateRange != default) {
				periodicDateRange.Load(instance.periodicDateRange);
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
				interoperabilityIdentifier = this.interoperabilityIdentifier,
				information = this.information.Select(e => e.Model).ToList(),
				featureName = this.featureName.Select(e => e.Model).ToList(),
				scaleMinimum = this.scaleMinimum,
				sourceDate = this.sourceDate,
				source = this.source,
				pictorialRepresentation = this.pictorialRepresentation,
				installationDate = this.installationDate,
				fixedDateRange = this.fixedDateRange?.Model,
				periodicDateRange = this.periodicDateRange?.Model,
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
			interoperabilityIdentifier = this._interoperabilityIdentifier,
			information = this.information.Select(e => e.Model).ToList(),
			featureName = this.featureName.Select(e => e.Model).ToList(),
			scaleMinimum = this._scaleMinimum,
			sourceDate = this._sourceDate,
			source = this._source,
			pictorialRepresentation = this._pictorialRepresentation,
			installationDate = this._installationDate,
			fixedDateRange = this._fixedDateRange?.Model,
			periodicDateRange = this._periodicDateRange?.Model,
			AtoNNumber = this._AtoNNumber,
			mMSICode = this._mMSICode,
			status = this.status.ToList(),
			CategoryOfSyntheticAISAidtoNavigation = this._CategoryOfSyntheticAISAidtoNavigation,
			virtualAISAidToNavigationType = this._virtualAISAidToNavigationType,
		};

		public override informationBindingDefinition[] informationBindingDefinitions => SyntheticAISAidToNavigation._informationBindingDefinitions;
		public override informationBindingDefinition[] informationBindingDefinitionsByPrimitive(Primitives primitive) => [.. SyntheticAISAidToNavigation._informationBindingDefinitions.Where(e => !e.primitives.Any() || e.primitives.Contains(primitive))];

		public override featureBindingDefinition[] featureBindingDefinitions => SyntheticAISAidToNavigation._featureBindingDefinitions;

		public SyntheticAISAidToNavigationViewModel ParseInformationBindings(informationBinding[] bindings) {
			this.LoadInformationBinding(bindings);
			return this;
		}

		public SyntheticAISAidToNavigationViewModel ParseFeatureBindings(featureBinding[] bindings) {
			this.LoadFeatureBinding(bindings);
			return this;
		}

		public override string? ToString() => $"Synthetic AIS Aid to Navigation";

		public SyntheticAISAidToNavigationViewModel() : base() {
			information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(information));
			};
			featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(featureName));
			};
			status.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnPropertyChanged(nameof(status));
			};
			SyntheticAIS.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				OnFeatureBindingCollectionChanged(nameof(SyntheticAIS));
			};
		}
	}



	public static class InformationBindingExtension {
		public static AtonStatusInformationViewModel LoadInformationBinding(this AtonStatusInformationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static EquipmentViewModel LoadInformationBinding(this EquipmentViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static GenericBuoyViewModel LoadInformationBinding(this GenericBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static PileViewModel LoadInformationBinding(this PileViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static SiloTankViewModel LoadInformationBinding(this SiloTankViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static CardinalBuoyViewModel LoadInformationBinding(this CardinalBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static EmergencyWreckMarkingBuoyViewModel LoadInformationBinding(this EmergencyWreckMarkingBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static InstallationBuoyViewModel LoadInformationBinding(this InstallationBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static IsolatedDangerBuoyViewModel LoadInformationBinding(this IsolatedDangerBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LateralBuoyViewModel LoadInformationBinding(this LateralBuoyViewModel instance, informationBinding[] bindings) {
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

		public static MooringBuoyViewModel LoadInformationBinding(this MooringBuoyViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static OffshorePlatformViewModel LoadInformationBinding(this OffshorePlatformViewModel instance, informationBinding[] bindings) {
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

		public static VirtualAISAidToNavigationViewModel LoadInformationBinding(this VirtualAISAidToNavigationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static DaymarkViewModel LoadInformationBinding(this DaymarkViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static StructureObjectViewModel LoadInformationBinding(this StructureObjectViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static FogSignalViewModel LoadInformationBinding(this FogSignalViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RadarReflectorViewModel LoadInformationBinding(this RadarReflectorViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static GenericBeaconViewModel LoadInformationBinding(this GenericBeaconViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RadarTransponderBeaconViewModel LoadInformationBinding(this RadarTransponderBeaconViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RadioStationViewModel LoadInformationBinding(this RadioStationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LightAirObstructionViewModel LoadInformationBinding(this LightAirObstructionViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static RetroreflectorViewModel LoadInformationBinding(this RetroreflectorViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LightAllAroundViewModel LoadInformationBinding(this LightAllAroundViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LightFogDetectorViewModel LoadInformationBinding(this LightFogDetectorViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static LightSectoredViewModel LoadInformationBinding(this LightSectoredViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static CardinalBeaconViewModel LoadInformationBinding(this CardinalBeaconViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static IsolatedDangerBeaconViewModel LoadInformationBinding(this IsolatedDangerBeaconViewModel instance, informationBinding[] bindings) {
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

		public static LighthouseViewModel LoadInformationBinding(this LighthouseViewModel instance, informationBinding[] bindings) {
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

		public static DangerousFeatureViewModel LoadInformationBinding(this DangerousFeatureViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static AtonAssociationViewModel LoadInformationBinding(this AtonAssociationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static AtonAggregationViewModel LoadInformationBinding(this AtonAggregationViewModel instance, informationBinding[] bindings) {
			foreach (var informationBinding in bindings) {
			}
			return instance;
		}

		public static TopmarkViewModel LoadInformationBinding(this TopmarkViewModel instance, informationBinding[] bindings) {
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

	}

	public static class FeatureBindingExtension {
		public static EquipmentViewModel LoadFeatureBinding(this EquipmentViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<StructureEquipment> structureEquipment) {
					instance.StructureEquipments.Add(new EquipmentViewModel.StructureEquipmentViewModel {
						featureId = structureEquipment.referenceId,
						featureType = structureEquipment.featureType,
						role = structureEquipment.role,
					});
				}
			}
			return instance;
		}

		public static GenericBuoyViewModel LoadFeatureBinding(this GenericBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<BuoyTopmark> buoyTopmark) {
					instance.BuoyTopmarks.Add(new GenericBuoyViewModel.BuoyTopmarkViewModel {
						featureId = buoyTopmark.referenceId,
						featureType = buoyTopmark.featureType,
						role = buoyTopmark.role,
					});
				}
			}
			return instance;
		}

		public static PileViewModel LoadFeatureBinding(this PileViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static SiloTankViewModel LoadFeatureBinding(this SiloTankViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static CardinalBuoyViewModel LoadFeatureBinding(this CardinalBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static EmergencyWreckMarkingBuoyViewModel LoadFeatureBinding(this EmergencyWreckMarkingBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static InstallationBuoyViewModel LoadFeatureBinding(this InstallationBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static IsolatedDangerBuoyViewModel LoadFeatureBinding(this IsolatedDangerBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LateralBuoyViewModel LoadFeatureBinding(this LateralBuoyViewModel instance, featureBinding[] bindings) {
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

		public static MooringBuoyViewModel LoadFeatureBinding(this MooringBuoyViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static OffshorePlatformViewModel LoadFeatureBinding(this OffshorePlatformViewModel instance, featureBinding[] bindings) {
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

		public static NavigationLineViewModel LoadFeatureBinding(this NavigationLineViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<RangeSystem> rangeSystem) {
					instance.RangeSystems.Add(new NavigationLineViewModel.RangeSystemViewModel {
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
					instance.RangeSystems.Add(new RecommendedTrackViewModel.RangeSystemViewModel {
						featureId = rangeSystem.referenceId,
						featureType = rangeSystem.featureType,
						role = rangeSystem.role,
					});
				}
			}
			return instance;
		}

		public static VirtualAISAidToNavigationViewModel LoadFeatureBinding(this VirtualAISAidToNavigationViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<VirtualAIS> virtualAIS) {
					instance.VirtualAIS.Add(new VirtualAISAidToNavigationViewModel.VirtualAISViewModel {
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

		public static StructureObjectViewModel LoadFeatureBinding(this StructureObjectViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<StructureEquipment> structureEquipment) {
					instance.StructureEquipments.Add(new StructureObjectViewModel.StructureEquipmentViewModel {
						featureId = structureEquipment.referenceId,
						featureType = structureEquipment.featureType,
						role = structureEquipment.role,
					});
				}
			}
			return instance;
		}

		public static FogSignalViewModel LoadFeatureBinding(this FogSignalViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static RadarReflectorViewModel LoadFeatureBinding(this RadarReflectorViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static GenericBeaconViewModel LoadFeatureBinding(this GenericBeaconViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static RadarTransponderBeaconViewModel LoadFeatureBinding(this RadarTransponderBeaconViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static RadioStationViewModel LoadFeatureBinding(this RadioStationViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<PhysicalAIS> physicalAIS) {
					instance.PhysicalAIS.Add(new RadioStationViewModel.PhysicalAISViewModel {
						featureId = physicalAIS.referenceId,
						featureType = physicalAIS.featureType,
						role = physicalAIS.role,
					});
				}
				if(featureBinding is featureBinding<SyntheticAIS> syntheticAIS) {
					instance.SyntheticAIS.Add(new RadioStationViewModel.SyntheticAISViewModel {
						featureId = syntheticAIS.referenceId,
						featureType = syntheticAIS.featureType,
						role = syntheticAIS.role,
					});
				}
				if(featureBinding is featureBinding<VirtualAIS> virtualAIS) {
					instance.VirtualAIS.Add(new RadioStationViewModel.VirtualAISViewModel {
						featureId = virtualAIS.referenceId,
						featureType = virtualAIS.featureType,
						role = virtualAIS.role,
					});
				}
			}
			return instance;
		}

		public static LightAirObstructionViewModel LoadFeatureBinding(this LightAirObstructionViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static RetroreflectorViewModel LoadFeatureBinding(this RetroreflectorViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LightAllAroundViewModel LoadFeatureBinding(this LightAllAroundViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LightFogDetectorViewModel LoadFeatureBinding(this LightFogDetectorViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static LightSectoredViewModel LoadFeatureBinding(this LightSectoredViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static CardinalBeaconViewModel LoadFeatureBinding(this CardinalBeaconViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

		public static IsolatedDangerBeaconViewModel LoadFeatureBinding(this IsolatedDangerBeaconViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
			}
			return instance;
		}

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

		public static LighthouseViewModel LoadFeatureBinding(this LighthouseViewModel instance, featureBinding[] bindings) {
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

		public static DangerousFeatureViewModel LoadFeatureBinding(this DangerousFeatureViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<DangerousFeatureAssociation> dangerousFeatureAssociation) {
					instance.DangerousFeatureAssociations.Add(new DangerousFeatureViewModel.DangerousFeatureAssociationViewModel {
						featureId = dangerousFeatureAssociation.referenceId,
						featureType = dangerousFeatureAssociation.featureType,
						role = dangerousFeatureAssociation.role,
					});
				}
			}
			return instance;
		}

		public static AtonAssociationViewModel LoadFeatureBinding(this AtonAssociationViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<DangerousFeatureAssociation> dangerousFeatureAssociation) {
					instance.DangerousFeatureAssociations.Add(new AtonAssociationViewModel.DangerousFeatureAssociationViewModel {
						featureId = dangerousFeatureAssociation.referenceId,
						featureType = dangerousFeatureAssociation.featureType,
						role = dangerousFeatureAssociation.role,
					});
				}
				if(featureBinding is featureBinding<AtonAssociations> atonAssociations) {
					instance.AtonAssociations.Add(new AtonAssociationViewModel.AtonAssociationsViewModel {
						featureId = atonAssociations.referenceId,
						featureType = atonAssociations.featureType,
						role = atonAssociations.role,
					});
				}
			}
			return instance;
		}

		public static AtonAggregationViewModel LoadFeatureBinding(this AtonAggregationViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<AtonAggregations> atonAggregations) {
					instance.AtonAggregations.Add(new AtonAggregationViewModel.AtonAggregationsViewModel {
						featureId = atonAggregations.referenceId,
						featureType = atonAggregations.featureType,
						role = atonAggregations.role,
					});
				}
			}
			return instance;
		}

		public static TopmarkViewModel LoadFeatureBinding(this TopmarkViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<BuoyTopmark> buoyTopmark) {
					instance.BuoyTopmarks.Add(new TopmarkViewModel.BuoyTopmarkViewModel {
						featureId = buoyTopmark.referenceId,
						featureType = buoyTopmark.featureType,
						role = buoyTopmark.role,
					});
				}
			}
			return instance;
		}

		public static PhysicalAISAidToNavigationViewModel LoadFeatureBinding(this PhysicalAISAidToNavigationViewModel instance, featureBinding[] bindings) {
			foreach (var featureBinding in bindings) {
				if(featureBinding is featureBinding<PhysicalAIS> physicalAIS) {
					instance.PhysicalAIS.Add(new PhysicalAISAidToNavigationViewModel.PhysicalAISViewModel {
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
					instance.SyntheticAIS.Add(new SyntheticAISAidToNavigationViewModel.SyntheticAISViewModel {
						featureId = syntheticAIS.referenceId,
						featureType = syntheticAIS.featureType,
						role = syntheticAIS.role,
					});
				}
			}
			return instance;
		}

	}

}
